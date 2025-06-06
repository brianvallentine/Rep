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
using Sias.Sinistro.DB2.SI0218B;

namespace Code
{
    public class SI0218B
    {
        public bool IsCall { get; set; }

        public SI0218B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI0218B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PRODEXTER                          *      */
        /*"      *   PROGRAMADOR ............  PRODEXTER                          *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO/2005                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  PROCESSA SOLICITACOES PARA         *      */
        /*"      *                             REEMISSAO DE REPASSE DE            *      */
        /*"      *                             RESSARCIMENTO                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01       WFIM-RELATORI          PIC  X(003) VALUE SPACES.*/
        public StringBasis WFIM_RELATORI { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01       AC-L-RELATORI          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_RELATORI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-RELATORI          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_RELATORI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       SI1051S-PARM.*/
        public SI0218B_SI1051S_PARM SI1051S_PARM { get; set; } = new SI0218B_SI1051S_PARM();
        public class SI0218B_SI1051S_PARM : VarBasis
        {
            /*"  05     SI1051S-TAMANHO        PIC S9(004) COMP.*/
            public IntBasis SI1051S_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     SI1051S-NUM-APOL-SINISTRO                                PIC S9(013) COMP-3.*/
            public IntBasis SI1051S_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05     SI1051S-OCORR-HISTORICO                                PIC S9(004) COMP.*/
            public IntBasis SI1051S_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     SI1051S-COD-OPERACAO   PIC S9(004) COMP.*/
            public IntBasis SI1051S_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     SI1051S-VAL-OPERACAO   PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SI1051S_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05     SI1051S-COD-USUARIO    PIC  X(008).*/
            public StringBasis SI1051S_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05     SI1051S-IND-RETORNO    PIC  X(001).*/
            public StringBasis SI1051S_IND_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05     SI1051S-MENSAGEM-RETORNO                                PIC  X(100).*/
            public StringBasis SI1051S_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
            /*"  05     SI1051S-SQLCODE        PIC S9(004).*/
            public IntBasis SI1051S_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
            /*"01       WABEND.*/
        }
        public SI0218B_WABEND WABEND { get; set; } = new SI0218B_WABEND();
        public class SI0218B_WABEND : VarBasis
        {
            /*"  05     FILLER                 PIC  X(010) VALUE        ' SI0218B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0218B");
            /*"  05     FILLER                 PIC  X(026) VALUE        ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL           PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05     FILLER                 PIC  X(013) VALUE        ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05     WSQLCODE               PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public SI0218B_C01_RELATORI C01_RELATORI { get; set; } = new SI0218B_C01_RELATORI();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -78- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -79- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -80- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -80- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -88- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -90- PERFORM R0100-00-LE-SISTEMAS */

            R0100_00_LE_SISTEMAS_SECTION();

            /*" -93- DISPLAY 'DATA DO PROCESSAMENTO (SI)        -' ' ' SISTEMAS-DATA-MOV-ABERTO */

            $"DATA DO PROCESSAMENTO (SI)        - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

            /*" -94- MOVE 'NAO' TO WFIM-RELATORI */
            _.Move("NAO", WFIM_RELATORI);

            /*" -95- PERFORM R0900-00-DECLARA-RELATORI */

            R0900_00_DECLARA_RELATORI_SECTION();

            /*" -97- PERFORM R0910-00-LE-RELATORI */

            R0910_00_LE_RELATORI_SECTION();

            /*" -98- PERFORM R1000-00-PROCESSA-RELATORI UNTIL WFIM-RELATORI EQUAL 'SIM' . */

            while (!(WFIM_RELATORI == "SIM"))
            {

                R1000_00_PROCESSA_RELATORI_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -103- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -104- DISPLAY '*    SI0218B - FIM NORMAL    *' */
            _.Display($"*    SI0218B - FIM NORMAL    *");

            /*" -105- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -106- DISPLAY 'LIDOS     RELATORI - ' AC-L-RELATORI */
            _.Display($"LIDOS     RELATORI - {AC_L_RELATORI}");

            /*" -108- DISPLAY 'ALTERADOS RELATORI - ' AC-U-RELATORI */
            _.Display($"ALTERADOS RELATORI - {AC_U_RELATORI}");

            /*" -110- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -110- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-SECTION */
        private void R0100_00_LE_SISTEMAS_SECTION()
        {
            /*" -118- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -123- PERFORM R0100_00_LE_SISTEMAS_DB_SELECT_1 */

            R0100_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -126- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -127- DISPLAY 'PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"PROBLEMAS NO SELECT SISTEMAS");

                /*" -127- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -123- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARA-RELATORI-SECTION */
        private void R0900_00_DECLARA_RELATORI_SECTION()
        {
            /*" -137- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -159- PERFORM R0900_00_DECLARA_RELATORI_DB_DECLARE_1 */

            R0900_00_DECLARA_RELATORI_DB_DECLARE_1();

            /*" -161- PERFORM R0900_00_DECLARA_RELATORI_DB_OPEN_1 */

            R0900_00_DECLARA_RELATORI_DB_OPEN_1();

            /*" -164- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -165- DISPLAY 'PROBLEMAS NO OPEN RELATORI/SINISHIS' */
                _.Display($"PROBLEMAS NO OPEN RELATORI/SINISHIS");

                /*" -165- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-RELATORI-DB-DECLARE-1 */
        public void R0900_00_DECLARA_RELATORI_DB_DECLARE_1()
        {
            /*" -159- EXEC SQL DECLARE C01_RELATORI CURSOR FOR SELECT H.NUM_APOL_SINISTRO, H.OCORR_HISTORICO, H.COD_OPERACAO, R.NUM_ENDOSSO AS NUM_RESSARC, R.NUM_PARCELA, R.DATA_SOLICITACAO, R.COD_USUARIO, H.VAL_OPERACAO FROM SEGUROS.RELATORIOS R, SEGUROS.SINISTRO_HISTORICO H WHERE R.COD_RELATORIO = 'REEMREPA' AND R.IDE_SISTEMA = 'SI' AND R.NUM_APOL_LIDER = 'SIR1A' AND R.SIT_REGISTRO = 'S' AND R.COD_OPERACAO = 4292 AND R.NUM_SINISTRO = H.NUM_APOL_SINISTRO AND R.OCORR_HISTORICO = H.OCORR_HISTORICO AND R.COD_OPERACAO = H.COD_OPERACAO ORDER BY R.DATA_SOLICITACAO, H.NUM_APOL_SINISTRO, H.OCORR_HISTORICO END-EXEC. */
            C01_RELATORI = new SI0218B_C01_RELATORI(false);
            string GetQuery_C01_RELATORI()
            {
                var query = @$"SELECT H.NUM_APOL_SINISTRO
							, 
							H.OCORR_HISTORICO
							, 
							H.COD_OPERACAO
							, 
							R.NUM_ENDOSSO AS NUM_RESSARC
							, 
							R.NUM_PARCELA
							, 
							R.DATA_SOLICITACAO
							, 
							R.COD_USUARIO
							, 
							H.VAL_OPERACAO 
							FROM SEGUROS.RELATORIOS R
							, 
							SEGUROS.SINISTRO_HISTORICO H 
							WHERE R.COD_RELATORIO = 'REEMREPA' 
							AND R.IDE_SISTEMA = 'SI' 
							AND R.NUM_APOL_LIDER = 'SIR1A' 
							AND R.SIT_REGISTRO = 'S' 
							AND R.COD_OPERACAO = 4292 
							AND R.NUM_SINISTRO = H.NUM_APOL_SINISTRO 
							AND R.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND R.COD_OPERACAO = H.COD_OPERACAO 
							ORDER BY R.DATA_SOLICITACAO
							, 
							H.NUM_APOL_SINISTRO
							, 
							H.OCORR_HISTORICO";

                return query;
            }
            C01_RELATORI.GetQueryEvent += GetQuery_C01_RELATORI;

        }

        [StopWatch]
        /*" R0900-00-DECLARA-RELATORI-DB-OPEN-1 */
        public void R0900_00_DECLARA_RELATORI_DB_OPEN_1()
        {
            /*" -161- EXEC SQL OPEN C01_RELATORI END-EXEC. */

            C01_RELATORI.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-RELATORI-SECTION */
        private void R0910_00_LE_RELATORI_SECTION()
        {
            /*" -175- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -184- PERFORM R0910_00_LE_RELATORI_DB_FETCH_1 */

            R0910_00_LE_RELATORI_DB_FETCH_1();

            /*" -187- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -188- ADD 1 TO AC-L-RELATORI */
                AC_L_RELATORI.Value = AC_L_RELATORI + 1;

                /*" -189- ELSE */
            }
            else
            {


                /*" -190- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -191- MOVE 'SIM' TO WFIM-RELATORI */
                    _.Move("SIM", WFIM_RELATORI);

                    /*" -191- PERFORM R0910_00_LE_RELATORI_DB_CLOSE_1 */

                    R0910_00_LE_RELATORI_DB_CLOSE_1();

                    /*" -193- ELSE */
                }
                else
                {


                    /*" -194- DISPLAY 'PROBLEMAS NO FETCH RELATORI/SINISHIS' */
                    _.Display($"PROBLEMAS NO FETCH RELATORI/SINISHIS");

                    /*" -194- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-RELATORI-DB-FETCH-1 */
        public void R0910_00_LE_RELATORI_DB_FETCH_1()
        {
            /*" -184- EXEC SQL FETCH C01_RELATORI INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :RELATORI-NUM-ENDOSSO, :RELATORI-NUM-PARCELA, :RELATORI-DATA-SOLICITACAO, :RELATORI-COD-USUARIO, :SINISHIS-VAL-OPERACAO END-EXEC. */

            if (C01_RELATORI.Fetch())
            {
                _.Move(C01_RELATORI.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(C01_RELATORI.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(C01_RELATORI.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(C01_RELATORI.RELATORI_NUM_ENDOSSO, RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO);
                _.Move(C01_RELATORI.RELATORI_NUM_PARCELA, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);
                _.Move(C01_RELATORI.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(C01_RELATORI.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(C01_RELATORI.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-RELATORI-DB-CLOSE-1 */
        public void R0910_00_LE_RELATORI_DB_CLOSE_1()
        {
            /*" -191- EXEC SQL CLOSE C01_RELATORI END-EXEC */

            C01_RELATORI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-RELATORI-SECTION */
        private void R1000_00_PROCESSA_RELATORI_SECTION()
        {
            /*" -214- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -216- INITIALIZE SI1051S-PARM */
            _.Initialize(
                SI1051S_PARM
            );

            /*" -218- MOVE SINISHIS-NUM-APOL-SINISTRO TO SI1051S-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, SI1051S_PARM.SI1051S_NUM_APOL_SINISTRO);

            /*" -220- MOVE SINISHIS-OCORR-HISTORICO TO SI1051S-OCORR-HISTORICO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, SI1051S_PARM.SI1051S_OCORR_HISTORICO);

            /*" -222- MOVE SINISHIS-COD-OPERACAO TO SI1051S-COD-OPERACAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SI1051S_PARM.SI1051S_COD_OPERACAO);

            /*" -224- MOVE SINISHIS-VAL-OPERACAO TO SI1051S-VAL-OPERACAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, SI1051S_PARM.SI1051S_VAL_OPERACAO);

            /*" -227- MOVE RELATORI-COD-USUARIO TO SI1051S-COD-USUARIO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, SI1051S_PARM.SI1051S_COD_USUARIO);

            /*" -229- CALL 'SI1051S' USING SI1051S-PARM */
            _.Call("SI1051S", SI1051S_PARM);

            /*" -231- IF SI1051S-IND-RETORNO NOT EQUAL '0' */

            if (SI1051S_PARM.SI1051S_IND_RETORNO != "0")
            {

                /*" -232- DISPLAY 'PROBLEMAS NA SUB-ROTINA: SI1051A' */
                _.Display($"PROBLEMAS NA SUB-ROTINA: SI1051A");

                /*" -235- DISPLAY ' ' SI1051S-IND-RETORNO ' ' SI1051S-MENSAGEM-RETORNO ' ' SI1051S-SQLCODE */

                $" {SI1051S_PARM.SI1051S_IND_RETORNO} {SI1051S_PARM.SI1051S_MENSAGEM_RETORNO} {SI1051S_PARM.SI1051S_SQLCODE}"
                .Display();

                /*" -242- DISPLAY ' ' SI1051S-NUM-APOL-SINISTRO ' ' SI1051S-OCORR-HISTORICO ' ' SI1051S-COD-OPERACAO ' ' SI1051S-VAL-OPERACAO ' ' RELATORI-COD-USUARIO ' ' RELATORI-NUM-ENDOSSO ' ' RELATORI-NUM-PARCELA */

                $" {SI1051S_PARM.SI1051S_NUM_APOL_SINISTRO} {SI1051S_PARM.SI1051S_OCORR_HISTORICO} {SI1051S_PARM.SI1051S_COD_OPERACAO} {SI1051S_PARM.SI1051S_VAL_OPERACAO} {RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO} {RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO} {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}"
                .Display();

                /*" -243- MOVE SI1051S-SQLCODE TO SQLCODE */
                _.Move(SI1051S_PARM.SI1051S_SQLCODE, DB.SQLCODE);

                /*" -247- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -251- PERFORM R1100-00-ALTERA-RELATORI */

            R1100_00_ALTERA_RELATORI_SECTION();

            /*" -251- PERFORM R0910-00-LE-RELATORI. */

            R0910_00_LE_RELATORI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-ALTERA-RELATORI-SECTION */
        private void R1100_00_ALTERA_RELATORI_SECTION()
        {
            /*" -261- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -275- PERFORM R1100_00_ALTERA_RELATORI_DB_UPDATE_1 */

            R1100_00_ALTERA_RELATORI_DB_UPDATE_1();

            /*" -278- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -284- DISPLAY 'PROBLEMAS NO UPDATE RELATORI' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO ' ' RELATORI-NUM-ENDOSSO ' ' RELATORI-NUM-PARCELA */

                $"PROBLEMAS NO UPDATE RELATORI {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO} {RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO} {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}"
                .Display();

                /*" -286- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -286- ADD SQLERRD(3) TO AC-U-RELATORI. */
            AC_U_RELATORI.Value = AC_U_RELATORI + DB.SQLERRD[3];

        }

        [StopWatch]
        /*" R1100-00-ALTERA-RELATORI-DB-UPDATE-1 */
        public void R1100_00_ALTERA_RELATORI_DB_UPDATE_1()
        {
            /*" -275- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = 'P' , NUM_APOL_LIDER = 'SI0218B' , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_RELATORIO = 'REEMREPA' AND IDE_SISTEMA = 'SI' AND NUM_APOL_LIDER = 'SIR1A' AND SIT_REGISTRO = 'S' AND NUM_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO AND NUM_ENDOSSO = :RELATORI-NUM-ENDOSSO AND NUM_PARCELA = :RELATORI-NUM-PARCELA END-EXEC */

            var r1100_00_ALTERA_RELATORI_DB_UPDATE_1_Update1 = new R1100_00_ALTERA_RELATORI_DB_UPDATE_1_Update1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            R1100_00_ALTERA_RELATORI_DB_UPDATE_1_Update1.Execute(r1100_00_ALTERA_RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -300- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -302- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -303- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -304- DISPLAY '*    SI0218B - CANCELADO     *' */
            _.Display($"*    SI0218B - CANCELADO     *");

            /*" -306- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -306- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -310- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -310- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}