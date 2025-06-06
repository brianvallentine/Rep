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
using Sias.Auto.DB2.AU9303B;

namespace Code
{
    public class AU9303B
    {
        public bool IsCall { get; set; }

        public AU9303B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  RENOVACAO                          *      */
        /*"      *   PROGRAMA ...............  AU9303B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  WANGER CORREIA DA SILVA            *      */
        /*"      *   PROGRAMADOR ............  WANGER CORREIA DA SILVA            *      */
        /*"      *   DATA CODIFICACAO .......  JULHO/1.999                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  - ALTERAR A SITUACAO DE ENDOSSO DE *      */
        /*"      *                               RESTITUICAO NA AUTOAPOL COLOCANDO*      */
        /*"      *                               SITUACAO = ' '.                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      *                                     V1AUTO_RENOVACAO  INPUT    *      */
        /*"      *                                     V1FONTE           INPUT    *      */
        /*"      *                                     V1AGENCIACEF      INPUT    *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      * ---------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V0EMPR-COD-EMP               PIC S9(004)     COMP.*/
        public IntBasis V0EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0EMPR-NOM-EMP               PIC  X(040).*/
        public StringBasis V0EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  V1AUTA-NUM-APOLICE           PIC S9(013)    COMP-3.*/
        public IntBasis V1AUTA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V1AUTA-NRENDOS               PIC S9(009)    COMP.*/
        public IntBasis V1AUTA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V1AUTA-FONTE                 PIC S9(004)    COMP.*/
        public IntBasis V1AUTA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1AUTA-NRPROPOS              PIC S9(009)    COMP.*/
        public IntBasis V1AUTA_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V1AUTA-NRITEM                PIC S9(009)    COMP.*/
        public IntBasis V1AUTA_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V1ENDO-NUM-APOLICE           PIC S9(013)    COMP-3.*/
        public IntBasis V1ENDO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V1ENDO-NRENDOS               PIC S9(009)    COMP.*/
        public IntBasis V1ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V1ENDO-SITUACAO              PIC  X(001).*/
        public StringBasis V1ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0ENDO-SITUACAO              PIC  X(001).*/
        public StringBasis V0ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0AUTP-SITUACAO              PIC  X(001).*/
        public StringBasis V0AUTP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0PARC-SITUACAO              PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  PROSOMW099.*/
        public AU9303B_PROSOMW099 PROSOMW099 { get; set; } = new AU9303B_PROSOMW099();
        public class AU9303B_PROSOMW099 : VarBasis
        {
            /*"    03  W-DATA01                PIC  9(08).*/
            public IntBasis W_DATA01 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    03  W-QTDIA                 PIC S9(05)  COMP-3.*/
            public IntBasis W_QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
            /*"    03  W-DATA02                PIC  9(08).*/
            public IntBasis W_DATA02 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"01  AREA-DE-TRABALHO.*/
        }
        public AU9303B_AREA_DE_TRABALHO AREA_DE_TRABALHO { get; set; } = new AU9303B_AREA_DE_TRABALHO();
        public class AU9303B_AREA_DE_TRABALHO : VarBasis
        {
            /*"  05   WFIM-V1AUTOAPOL           PIC  X(001)   VALUE SPACES.*/
            public StringBasis WFIM_V1AUTOAPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05   WQTPARCEL                PIC  9(004)   VALUE ZEROS.*/
            public IntBasis WQTPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05   WLIDOS                   PIC  9(004)   VALUE ZEROS.*/
            public IntBasis WLIDOS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05   WATUAL                   PIC  9(004)   VALUE ZEROS.*/
            public IntBasis WATUAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05   AC-L-V1ENDOSSO           PIC  9(004)   VALUE ZEROS.*/
            public IntBasis AC_L_V1ENDOSSO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05   AC-L-V0ENDOSSO           PIC  9(004)   VALUE ZEROS.*/
            public IntBasis AC_L_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05   AC-L-V1AUTOAPOL          PIC  9(004)   VALUE ZEROS.*/
            public IntBasis AC_L_V1AUTOAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05   AC-L-V0AUTOPROP          PIC  9(004)   VALUE ZEROS.*/
            public IntBasis AC_L_V0AUTOPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05   AC-L-V0PARCELA           PIC  9(004)   VALUE ZEROS.*/
            public IntBasis AC_L_V0PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05   AC-U-V0AUTOAPOL          PIC  9(004)   VALUE ZEROS.*/
            public IntBasis AC_U_V0AUTOAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"01  W-DATA-EDITADA.*/
        }
        public AU9303B_W_DATA_EDITADA W_DATA_EDITADA { get; set; } = new AU9303B_W_DATA_EDITADA();
        public class AU9303B_W_DATA_EDITADA : VarBasis
        {
            /*"    03  W-ANO                   PIC  9(04).*/
            public IntBasis W_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03  FILLER                  PIC  X(01).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-MES                   PIC  9(02).*/
            public IntBasis W_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  FILLER                  PIC  X(01).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-DIA                   PIC  9(02).*/
            public IntBasis W_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  W-DATA-EDITADA-2.*/
        }
        public AU9303B_W_DATA_EDITADA_2 W_DATA_EDITADA_2 { get; set; } = new AU9303B_W_DATA_EDITADA_2();
        public class AU9303B_W_DATA_EDITADA_2 : VarBasis
        {
            /*"    03  W-ANO-2                 PIC  9(04).*/
            public IntBasis W_ANO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03  FILLER                  PIC  X(01).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-MES-2                 PIC  9(02).*/
            public IntBasis W_MES_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  FILLER                  PIC  X(01).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-DIA-2                 PIC  9(02).*/
            public IntBasis W_DIA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01        WABEND.*/
        }
        public AU9303B_WABEND WABEND { get; set; } = new AU9303B_WABEND();
        public class AU9303B_WABEND : VarBasis
        {
            /*"    10      FILLER              PIC  X(010) VALUE           ' AU9303B'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AU9303B");
            /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01        WPARAGRAFO          PIC  X(040)    VALUE SPACES.*/
        }
        public StringBasis WPARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");


        public AU9303B_V1AUTOAPOL V1AUTOAPOL { get; set; } = new AU9303B_V1AUTOAPOL();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -144- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -147- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -150- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -150- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -159- MOVE 'R0000-00-PRINCIPAL' TO WPARAGRAFO */
            _.Move("R0000-00-PRINCIPAL", WPARAGRAFO);

            /*" -161- PERFORM R0050-00-DECLARE-V1AUTOAPOL. */

            R0050_00_DECLARE_V1AUTOAPOL_SECTION();

            /*" -163- PERFORM R0060-00-FETCH-V1AUTOAPOL. */

            R0060_00_FETCH_V1AUTOAPOL_SECTION();

            /*" -164- IF WFIM-V1AUTOAPOL NOT EQUAL SPACES */

            if (!AREA_DE_TRABALHO.WFIM_V1AUTOAPOL.IsEmpty())
            {

                /*" -166- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -169- PERFORM R0070-00-PROCESSA-APOLICE UNTIL WFIM-V1AUTOAPOL NOT EQUAL SPACES. */

            while (!(!AREA_DE_TRABALHO.WFIM_V1AUTOAPOL.IsEmpty()))
            {

                R0070_00_PROCESSA_APOLICE_SECTION();
            }

            /*" -170- DISPLAY 'LIDOS JOIN AUTO-RENOVACAO = ' WLIDOS. */
            _.Display($"LIDOS JOIN AUTO-RENOVACAO = {AREA_DE_TRABALHO.WLIDOS}");

            /*" -170- DISPLAY 'ATUALIZADOS NA HISTOPARC  = ' WATUAL. */
            _.Display($"ATUALIZADOS NA HISTOPARC  = {AREA_DE_TRABALHO.WATUAL}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -174- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -178- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -178- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-DECLARE-V1AUTOAPOL-SECTION */
        private void R0050_00_DECLARE_V1AUTOAPOL_SECTION()
        {
            /*" -190- MOVE 'R0050-00-DECLARE-V1AUTOAPOL       ' TO WPARAGRAFO */
            _.Move("R0050-00-DECLARE-V1AUTOAPOL       ", WPARAGRAFO);

            /*" -192- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -210- PERFORM R0050_00_DECLARE_V1AUTOAPOL_DB_DECLARE_1 */

            R0050_00_DECLARE_V1AUTOAPOL_DB_DECLARE_1();

            /*" -212- PERFORM R0050_00_DECLARE_V1AUTOAPOL_DB_OPEN_1 */

            R0050_00_DECLARE_V1AUTOAPOL_DB_OPEN_1();

            /*" -215- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -216- DISPLAY 'AU9303B - ' WPARAGRAFO */
                _.Display($"AU9303B - {WPARAGRAFO}");

                /*" -217- DISPLAY 'ERRO NO OPEN ' */
                _.Display($"ERRO NO OPEN ");

                /*" -217- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0050-00-DECLARE-V1AUTOAPOL-DB-DECLARE-1 */
        public void R0050_00_DECLARE_V1AUTOAPOL_DB_DECLARE_1()
        {
            /*" -210- EXEC SQL DECLARE V1AUTOAPOL CURSOR FOR SELECT A.NUM_APOLICE , A.NRENDOS , A.FONTE , A.NRPROPOS , A.NRITEM FROM SEGUROS.V0AUTOAPOL A, SEGUROS.V0ENDOSSO E WHERE E.NUM_APOLICE BETWEEN 0103100000000 AND 0105399999999 AND A.NUM_APOLICE = E.NUM_APOLICE AND A.NRENDOS = E.NRENDOS AND E.SITUACAO IN ( '0' , '1' ) AND A.SITUACAO = '2' AND A.NRITEM = ( SELECT MAX(B.NRITEM) FROM SEGUROS.V0AUTOAPOL B WHERE A.NUM_APOLICE = B.NUM_APOLICE) ORDER BY A.NUM_APOLICE , A.NRENDOS END-EXEC. */
            V1AUTOAPOL = new AU9303B_V1AUTOAPOL(false);
            string GetQuery_V1AUTOAPOL()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.FONTE
							, 
							A.NRPROPOS
							, 
							A.NRITEM 
							FROM SEGUROS.V0AUTOAPOL A
							, SEGUROS.V0ENDOSSO E 
							WHERE E.NUM_APOLICE BETWEEN 
							0103100000000 AND 0105399999999 
							AND A.NUM_APOLICE = E.NUM_APOLICE 
							AND A.NRENDOS = E.NRENDOS 
							AND E.SITUACAO IN ( '0'
							, '1' ) 
							AND A.SITUACAO = '2' 
							AND A.NRITEM = ( SELECT MAX(B.NRITEM) 
							FROM SEGUROS.V0AUTOAPOL B 
							WHERE A.NUM_APOLICE = B.NUM_APOLICE) 
							ORDER BY A.NUM_APOLICE
							, 
							A.NRENDOS";

                return query;
            }
            V1AUTOAPOL.GetQueryEvent += GetQuery_V1AUTOAPOL;

        }

        [StopWatch]
        /*" R0050-00-DECLARE-V1AUTOAPOL-DB-OPEN-1 */
        public void R0050_00_DECLARE_V1AUTOAPOL_DB_OPEN_1()
        {
            /*" -212- EXEC SQL OPEN V1AUTOAPOL END-EXEC. */

            V1AUTOAPOL.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0060-00-FETCH-V1AUTOAPOL-SECTION */
        private void R0060_00_FETCH_V1AUTOAPOL_SECTION()
        {
            /*" -226- MOVE 'R0060-00-V1AUTOAPOL           ' TO WPARAGRAFO */
            _.Move("R0060-00-V1AUTOAPOL           ", WPARAGRAFO);

            /*" -226- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0060_10_LEITURA */

            R0060_10_LEITURA();

        }

        [StopWatch]
        /*" R0060-10-LEITURA */
        private void R0060_10_LEITURA(bool isPerform = false)
        {
            /*" -236- PERFORM R0060_10_LEITURA_DB_FETCH_1 */

            R0060_10_LEITURA_DB_FETCH_1();

            /*" -239- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -240- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -241- MOVE 'S' TO WFIM-V1AUTOAPOL */
                    _.Move("S", AREA_DE_TRABALHO.WFIM_V1AUTOAPOL);

                    /*" -241- PERFORM R0060_10_LEITURA_DB_CLOSE_1 */

                    R0060_10_LEITURA_DB_CLOSE_1();

                    /*" -243- GO TO R0060-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/ //GOTO
                    return;

                    /*" -244- ELSE */
                }
                else
                {


                    /*" -245- DISPLAY 'AU9303B - ' WPARAGRAFO */
                    _.Display($"AU9303B - {WPARAGRAFO}");

                    /*" -247- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -247- ADD 1 TO AC-L-V1AUTOAPOL. */
            AREA_DE_TRABALHO.AC_L_V1AUTOAPOL.Value = AREA_DE_TRABALHO.AC_L_V1AUTOAPOL + 1;

        }

        [StopWatch]
        /*" R0060-10-LEITURA-DB-FETCH-1 */
        public void R0060_10_LEITURA_DB_FETCH_1()
        {
            /*" -236- EXEC SQL FETCH V1AUTOAPOL INTO :V1AUTA-NUM-APOLICE, :V1AUTA-NRENDOS , :V1AUTA-FONTE , :V1AUTA-NRPROPOS , :V1AUTA-NRITEM END-EXEC. */

            if (V1AUTOAPOL.Fetch())
            {
                _.Move(V1AUTOAPOL.V1AUTA_NUM_APOLICE, V1AUTA_NUM_APOLICE);
                _.Move(V1AUTOAPOL.V1AUTA_NRENDOS, V1AUTA_NRENDOS);
                _.Move(V1AUTOAPOL.V1AUTA_FONTE, V1AUTA_FONTE);
                _.Move(V1AUTOAPOL.V1AUTA_NRPROPOS, V1AUTA_NRPROPOS);
                _.Move(V1AUTOAPOL.V1AUTA_NRITEM, V1AUTA_NRITEM);
            }

        }

        [StopWatch]
        /*" R0060-10-LEITURA-DB-CLOSE-1 */
        public void R0060_10_LEITURA_DB_CLOSE_1()
        {
            /*" -241- EXEC SQL CLOSE V1AUTOAPOL END-EXEC */

            V1AUTOAPOL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/

        [StopWatch]
        /*" R0070-00-PROCESSA-APOLICE-SECTION */
        private void R0070_00_PROCESSA_APOLICE_SECTION()
        {
            /*" -255- MOVE 'R0070-00-PROCESSA-APOLICE     ' TO WPARAGRAFO */
            _.Move("R0070-00-PROCESSA-APOLICE     ", WPARAGRAFO);

            /*" -257- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WABEND.WNR_EXEC_SQL);

            /*" -259- PERFORM R0075-00-SELECT-V1ENDOSSO. */

            R0075_00_SELECT_V1ENDOSSO_SECTION();

            /*" -263- IF V1ENDO-SITUACAO = '2' */

            if (V1ENDO_SITUACAO == "2")
            {

                /*" -265- GO TO R0070-00-PROXIMA-LEITURA. */

                R0070_00_PROXIMA_LEITURA(); //GOTO
                return;
            }


            /*" -267- PERFORM R0080-00-SELECT-V0ENDOSSO. */

            R0080_00_SELECT_V0ENDOSSO_SECTION();

            /*" -270- IF V0ENDO-SITUACAO = '2' */

            if (V0ENDO_SITUACAO == "2")
            {

                /*" -272- GO TO R0070-00-PROXIMA-LEITURA. */

                R0070_00_PROXIMA_LEITURA(); //GOTO
                return;
            }


            /*" -274- PERFORM R0083-00-SELECT-V0PARCELA. */

            R0083_00_SELECT_V0PARCELA_SECTION();

            /*" -278- IF V0PARC-SITUACAO = '2' */

            if (V0PARC_SITUACAO == "2")
            {

                /*" -280- GO TO R0070-00-PROXIMA-LEITURA. */

                R0070_00_PROXIMA_LEITURA(); //GOTO
                return;
            }


            /*" -282- PERFORM R0085-00-SELECT-V0AUTOPROP. */

            R0085_00_SELECT_V0AUTOPROP_SECTION();

            /*" -283- IF V0AUTP-SITUACAO EQUAL ' ' */

            if (V0AUTP_SITUACAO == " ")
            {

                /*" -283- PERFORM R0090-00-UPDATE-V0AUTOAPOL. */

                R0090_00_UPDATE_V0AUTOAPOL_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0070_00_PROXIMA_LEITURA */

            R0070_00_PROXIMA_LEITURA();

        }

        [StopWatch]
        /*" R0070-00-PROXIMA-LEITURA */
        private void R0070_00_PROXIMA_LEITURA(bool isPerform = false)
        {
            /*" -289- PERFORM R0060-00-FETCH-V1AUTOAPOL. */

            R0060_00_FETCH_V1AUTOAPOL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_99_SAIDA*/

        [StopWatch]
        /*" R0075-00-SELECT-V1ENDOSSO-SECTION */
        private void R0075_00_SELECT_V1ENDOSSO_SECTION()
        {
            /*" -298- ADD +1 TO AC-L-V1ENDOSSO. */
            AREA_DE_TRABALHO.AC_L_V1ENDOSSO.Value = AREA_DE_TRABALHO.AC_L_V1ENDOSSO + +1;

            /*" -299- MOVE 'R0075-00-SELECT-V1ENDOSSO    ' TO WPARAGRAFO */
            _.Move("R0075-00-SELECT-V1ENDOSSO    ", WPARAGRAFO);

            /*" -301- MOVE '075' TO WNR-EXEC-SQL. */
            _.Move("075", WABEND.WNR_EXEC_SQL);

            /*" -307- PERFORM R0075_00_SELECT_V1ENDOSSO_DB_SELECT_1 */

            R0075_00_SELECT_V1ENDOSSO_DB_SELECT_1();

            /*" -310- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -311- DISPLAY 'R0075-00 (ERRO - SELECT V1ENDOSSO)' */
                _.Display($"R0075-00 (ERRO - SELECT V1ENDOSSO)");

                /*" -312- DISPLAY 'APOLICE  : ' V1AUTA-NUM-APOLICE */
                _.Display($"APOLICE  : {V1AUTA_NUM_APOLICE}");

                /*" -313- DISPLAY 'ENDOSSO  : ' V1AUTA-NRENDOS */
                _.Display($"ENDOSSO  : {V1AUTA_NRENDOS}");

                /*" -313- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0075-00-SELECT-V1ENDOSSO-DB-SELECT-1 */
        public void R0075_00_SELECT_V1ENDOSSO_DB_SELECT_1()
        {
            /*" -307- EXEC SQL SELECT SITUACAO INTO :V1ENDO-SITUACAO FROM SEGUROS.V1ENDOSSO WHERE NUM_APOLICE = :V1AUTA-NUM-APOLICE AND NRENDOS = :V1AUTA-NRENDOS END-EXEC. */

            var r0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 = new R0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1()
            {
                V1AUTA_NUM_APOLICE = V1AUTA_NUM_APOLICE.ToString(),
                V1AUTA_NRENDOS = V1AUTA_NRENDOS.ToString(),
            };

            var executed_1 = R0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1.Execute(r0075_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDO_SITUACAO, V1ENDO_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0075_99_SAIDA*/

        [StopWatch]
        /*" R0080-00-SELECT-V0ENDOSSO-SECTION */
        private void R0080_00_SELECT_V0ENDOSSO_SECTION()
        {
            /*" -323- ADD +1 TO AC-L-V0ENDOSSO. */
            AREA_DE_TRABALHO.AC_L_V0ENDOSSO.Value = AREA_DE_TRABALHO.AC_L_V0ENDOSSO + +1;

            /*" -324- MOVE 'R0080-00-SELECT-V0ENDOSSO    ' TO WPARAGRAFO */
            _.Move("R0080-00-SELECT-V0ENDOSSO    ", WPARAGRAFO);

            /*" -326- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WABEND.WNR_EXEC_SQL);

            /*" -332- PERFORM R0080_00_SELECT_V0ENDOSSO_DB_SELECT_1 */

            R0080_00_SELECT_V0ENDOSSO_DB_SELECT_1();

            /*" -335- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -336- DISPLAY 'R0080-00 (ERRO - SELECT V0ENDOSSO)' */
                _.Display($"R0080-00 (ERRO - SELECT V0ENDOSSO)");

                /*" -337- DISPLAY 'APOLICE  : ' V1AUTA-NUM-APOLICE */
                _.Display($"APOLICE  : {V1AUTA_NUM_APOLICE}");

                /*" -337- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0080-00-SELECT-V0ENDOSSO-DB-SELECT-1 */
        public void R0080_00_SELECT_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -332- EXEC SQL SELECT SITUACAO INTO :V0ENDO-SITUACAO FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V1AUTA-NUM-APOLICE AND NRENDOS = 0 END-EXEC. */

            var r0080_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 = new R0080_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                V1AUTA_NUM_APOLICE = V1AUTA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0080_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r0080_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_SITUACAO, V0ENDO_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_99_SAIDA*/

        [StopWatch]
        /*" R0083-00-SELECT-V0PARCELA-SECTION */
        private void R0083_00_SELECT_V0PARCELA_SECTION()
        {
            /*" -347- ADD +1 TO AC-L-V0PARCELA. */
            AREA_DE_TRABALHO.AC_L_V0PARCELA.Value = AREA_DE_TRABALHO.AC_L_V0PARCELA + +1;

            /*" -348- MOVE 'R0083-00-SELECT-V0PARCELA    ' TO WPARAGRAFO */
            _.Move("R0083-00-SELECT-V0PARCELA    ", WPARAGRAFO);

            /*" -350- MOVE '083' TO WNR-EXEC-SQL. */
            _.Move("083", WABEND.WNR_EXEC_SQL);

            /*" -357- PERFORM R0083_00_SELECT_V0PARCELA_DB_SELECT_1 */

            R0083_00_SELECT_V0PARCELA_DB_SELECT_1();

            /*" -360- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -361- DISPLAY 'R0083-00 (ERRO - SELECT V0PARCELA)' */
                _.Display($"R0083-00 (ERRO - SELECT V0PARCELA)");

                /*" -362- DISPLAY 'APOLICE  : ' V1AUTA-NUM-APOLICE */
                _.Display($"APOLICE  : {V1AUTA_NUM_APOLICE}");

                /*" -363- DISPLAY 'ENDOSSO  : ' V1AUTA-NRENDOS */
                _.Display($"ENDOSSO  : {V1AUTA_NRENDOS}");

                /*" -363- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0083-00-SELECT-V0PARCELA-DB-SELECT-1 */
        public void R0083_00_SELECT_V0PARCELA_DB_SELECT_1()
        {
            /*" -357- EXEC SQL SELECT SITUACAO INTO :V0PARC-SITUACAO FROM SEGUROS.V0PARCELA WHERE NUM_APOLICE = :V1AUTA-NUM-APOLICE AND NRENDOS = :V1AUTA-NRENDOS AND NRPARCEL IN ( 0 , 1 ) END-EXEC. */

            var r0083_00_SELECT_V0PARCELA_DB_SELECT_1_Query1 = new R0083_00_SELECT_V0PARCELA_DB_SELECT_1_Query1()
            {
                V1AUTA_NUM_APOLICE = V1AUTA_NUM_APOLICE.ToString(),
                V1AUTA_NRENDOS = V1AUTA_NRENDOS.ToString(),
            };

            var executed_1 = R0083_00_SELECT_V0PARCELA_DB_SELECT_1_Query1.Execute(r0083_00_SELECT_V0PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_SITUACAO, V0PARC_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0083_99_SAIDA*/

        [StopWatch]
        /*" R0085-00-SELECT-V0AUTOPROP-SECTION */
        private void R0085_00_SELECT_V0AUTOPROP_SECTION()
        {
            /*" -373- ADD +1 TO AC-L-V0AUTOPROP. */
            AREA_DE_TRABALHO.AC_L_V0AUTOPROP.Value = AREA_DE_TRABALHO.AC_L_V0AUTOPROP + +1;

            /*" -374- MOVE 'R0085-00-SELECT-V0AUTOPROP   ' TO WPARAGRAFO */
            _.Move("R0085-00-SELECT-V0AUTOPROP   ", WPARAGRAFO);

            /*" -376- MOVE '085' TO WNR-EXEC-SQL. */
            _.Move("085", WABEND.WNR_EXEC_SQL);

            /*" -383- PERFORM R0085_00_SELECT_V0AUTOPROP_DB_SELECT_1 */

            R0085_00_SELECT_V0AUTOPROP_DB_SELECT_1();

            /*" -386- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -387- DISPLAY 'R0085-00 (ERRO - SELECT V0AUTOPROP)' */
                _.Display($"R0085-00 (ERRO - SELECT V0AUTOPROP)");

                /*" -388- DISPLAY 'FONTE    : ' V1AUTA-FONTE */
                _.Display($"FONTE    : {V1AUTA_FONTE}");

                /*" -389- DISPLAY 'PROPOSTA : ' V1AUTA-NRPROPOS */
                _.Display($"PROPOSTA : {V1AUTA_NRPROPOS}");

                /*" -389- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0085-00-SELECT-V0AUTOPROP-DB-SELECT-1 */
        public void R0085_00_SELECT_V0AUTOPROP_DB_SELECT_1()
        {
            /*" -383- EXEC SQL SELECT SITUACAO INTO :V0AUTP-SITUACAO FROM SEGUROS.V0AUTOPROP WHERE FONTE = :V1AUTA-FONTE AND NRPROPOS = :V1AUTA-NRPROPOS AND NRITEM = :V1AUTA-NRITEM END-EXEC. */

            var r0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1 = new R0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1()
            {
                V1AUTA_NRPROPOS = V1AUTA_NRPROPOS.ToString(),
                V1AUTA_NRITEM = V1AUTA_NRITEM.ToString(),
                V1AUTA_FONTE = V1AUTA_FONTE.ToString(),
            };

            var executed_1 = R0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1.Execute(r0085_00_SELECT_V0AUTOPROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0AUTP_SITUACAO, V0AUTP_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_99_SAIDA*/

        [StopWatch]
        /*" R0090-00-UPDATE-V0AUTOAPOL-SECTION */
        private void R0090_00_UPDATE_V0AUTOAPOL_SECTION()
        {
            /*" -398- MOVE 'R0090-00-SELECT-VAUTOAPOL    ' TO WPARAGRAFO */
            _.Move("R0090-00-SELECT-VAUTOAPOL    ", WPARAGRAFO);

            /*" -400- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -402- ADD +1 TO AC-U-V0AUTOAPOL. */
            AREA_DE_TRABALHO.AC_U_V0AUTOAPOL.Value = AREA_DE_TRABALHO.AC_U_V0AUTOAPOL + +1;

            /*" -410- PERFORM R0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1 */

            R0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1();

            /*" -413- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -414- DISPLAY 'AU9303B - ' WPARAGRAFO */
                _.Display($"AU9303B - {WPARAGRAFO}");

                /*" -415- DISPLAY 'V1AUTA-NUM-APOLICE =' V1AUTA-NUM-APOLICE */
                _.Display($"V1AUTA-NUM-APOLICE ={V1AUTA_NUM_APOLICE}");

                /*" -416- DISPLAY 'V1AUTA-NRENDOS     =' V1AUTA-NRENDOS */
                _.Display($"V1AUTA-NRENDOS     ={V1AUTA_NRENDOS}");

                /*" -417- DISPLAY 'V1AUTA-FONTE       =' V1AUTA-FONTE */
                _.Display($"V1AUTA-FONTE       ={V1AUTA_FONTE}");

                /*" -418- DISPLAY 'V1AUTA-NRPROPOS    =' V1AUTA-NRPROPOS */
                _.Display($"V1AUTA-NRPROPOS    ={V1AUTA_NRPROPOS}");

                /*" -419- DISPLAY 'V1AUTA-NRITEM      =' V1AUTA-NRITEM */
                _.Display($"V1AUTA-NRITEM      ={V1AUTA_NRITEM}");

                /*" -427- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -427- ADD 1 TO WATUAL. */
            AREA_DE_TRABALHO.WATUAL.Value = AREA_DE_TRABALHO.WATUAL + 1;

        }

        [StopWatch]
        /*" R0090-00-UPDATE-V0AUTOAPOL-DB-UPDATE-1 */
        public void R0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1()
        {
            /*" -410- EXEC SQL UPDATE SEGUROS.V0AUTOAPOL SET SITUACAO = :V0AUTP-SITUACAO WHERE NUM_APOLICE = :V1AUTA-NUM-APOLICE AND NRENDOS = :V1AUTA-NRENDOS AND FONTE = :V1AUTA-FONTE AND NRPROPOS = :V1AUTA-NRPROPOS AND NRITEM = :V1AUTA-NRITEM END-EXEC. */

            var r0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1_Update1 = new R0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1_Update1()
            {
                V0AUTP_SITUACAO = V0AUTP_SITUACAO.ToString(),
                V1AUTA_NUM_APOLICE = V1AUTA_NUM_APOLICE.ToString(),
                V1AUTA_NRPROPOS = V1AUTA_NRPROPOS.ToString(),
                V1AUTA_NRENDOS = V1AUTA_NRENDOS.ToString(),
                V1AUTA_NRITEM = V1AUTA_NRITEM.ToString(),
                V1AUTA_FONTE = V1AUTA_FONTE.ToString(),
            };

            R0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1_Update1.Execute(r0090_00_UPDATE_V0AUTOAPOL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0090_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -437- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -439- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -439- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -441- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -443- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}