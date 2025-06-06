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
using Sias.VidaAzul.DB2.VA0850B;

namespace Code
{
    public class VA0850B
    {
        public bool IsCall { get; set; }

        public VA0850B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDAZUL EMPRESA GLOBAL/MULTIPREM   *      */
        /*"      *   PROGRAMA ...............  VA0850B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FONSECA                            *      */
        /*"      *   PROGRAMADOR ............  FONSECA                            *      */
        /*"      *   DATA CODIFICACAO .......  21/01/1998                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ACERTA COBRANCA EM ATRASO          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * PROPOSTAS VA                        V0PROPOSTAVA      INPUT    *      */
        /*"      * PARCELAS VA                         V0PARCELVA        I-O      *      */
        /*"      * HISTORICO COBRANCA VA               V0HISTCOBVA       I-O      *      */
        /*"      * DIFERENCAS DE PARCELA               V0DIFPARCELVA     OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * O PGM NAO TRATA AS PROPOSTAS DO SAUDE - PRODUTO 208            *      */
        /*"      *     LIBERAR POSTERIORMENTE - FONSECA - PROCURE POR AF0698      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - CAD 104.181                                      *      */
        /*"      *                                                                *      */
        /*"      *             - ALTERACAO PARA PEGAR APENAS UMA PARCELA, EVITANDO*      */
        /*"      *               SQLCODE -811                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/10/2014 -  ELIERMES OLIVEIRA                           *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.08    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.07    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"MM0399* ALTERACAO 04/03/99 - MANOEL MESSIAS  (MM0399)                  *      */
        /*"MM0399*     ALTERADO PARA TRATAR OS SEGURADOS EM ATRASO COM OPCAO DE   *      */
        /*"MM0399* PAGAMENTO EM DEBITO EM CONTA:                                  *      */
        /*"MM0399*     1 - NAO CANCELA AS PARCELAS EM ATRASO                      *      */
        /*"MM0399*     2 - NAO ACUMULA OS VALORES NA PARCELA MAIS RECENTE.        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LC0499* ALTERACAO 29/04/99 - LUIZ CARLOS                               *      */
        /*"LC0499*     ALTERADO PARA DESPRESAR SEGURADOS EM ATRASO COM OPCAO DE   *      */
        /*"LC0499*     PAGAMENTO EM DEBITO EM CONTA.   PROCURE POR LC0499.        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 24/06/99 - TERCIO CARVALHO                           *      */
        /*"      *     PASSA A NAO MAIS TRATAR POR PRODUTO.                       *      */
        /*"      *                                     PROCURE POR TL9906.        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 08/04/02 - MESSIAS / FREDERICO                       *      */
        /*"      *    NAO PERMITE SUMARIZAR AS PARCELAS DOS PRODUTOS EMPRESARIAL  *      */
        /*"      *  E ESPECIFICA.                      PROCURE POR MM0402.        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 09/08/06 - LUCIA  VIEIRA                             *      */
        /*"      *     PERMITE PROSSEGUIR QUANDO NAO ENCONTRAR PARCELA NA  TABELA *      */
        /*"      *     SEGUROS.V0PARCELVA.             PROCURE POR V.05           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06                                                    *      */
        /*"      *             - CAD 82.590                                       *      */
        /*"      *               AJUSTE NO PROGRAMA PARA CORRECAO DO ABENDE       *      */
        /*"      *               SQLCODE = -811 NA TABELA SEGUROS.V0HISTCOBVA     *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/05/2013 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.06             *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-ESTR-COBR      PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ORIG-PRODU     PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HCOB-NRCERTIF     PIC S9(015) COMP-3.*/
        public IntBasis V0HCOB_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0HCOB-COUNT        PIC S9(009) COMP.*/
        public IntBasis V0HCOB_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HCOB-NRPARCELMIN  PIC S9(004) COMP.*/
        public IntBasis V0HCOB_NRPARCELMIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HCOB-NRPARCELMAX  PIC S9(004) COMP.*/
        public IntBasis V0HCOB_NRPARCELMAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HCOB-NRTIT        PIC S9(013) COMP-3.*/
        public IntBasis V0HCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HCOB-VLPRMTOT     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0HCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HCOB-OPCAOPAG     PIC  X(001).*/
        public StringBasis V0HCOB_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PROP-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-SITUACAO     PIC  X(001).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PROP-ESTR-COBR    PIC  X(010).*/
        public StringBasis V0PROP_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-ORIG-PRODU   PIC  X(010).*/
        public StringBasis V0PROP_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-QTDPARATZ    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-PRMVGTOT     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMVGTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-PRMAPTOT     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMAPTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-DTVENCTO     PIC  X(010).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0DIFP-VLPRMTOT     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFVG     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFAP     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2DIFP-PRMDIFVG     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V2DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2DIFP-PRMDIFAP     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V2DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           AREA-DE-WORK.*/
        public VA0850B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA0850B_AREA_DE_WORK();
        public class VA0850B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-LIDOS        PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-GRAVADOS     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFIM-CHISTCB    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CHISTCB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CPARCEL    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CPARCEL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WABEND.*/
            public VA0850B_WABEND WABEND { get; set; } = new VA0850B_WABEND();
            public class VA0850B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VA0850B '.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA0850B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public VA0850B_CHISTCB CHISTCB { get; set; } = new VA0850B_CHISTCB();
        public VA0850B_CPARCEL CPARCEL { get; set; } = new VA0850B_CPARCEL();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -196- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -199- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -203- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -206- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -207- DISPLAY 'PROGRAMA EM EXECUCAO VA0850B   ' */
            _.Display($"PROGRAMA EM EXECUCAO VA0850B   ");

            /*" -208- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -210- DISPLAY 'VERSAO V.08 104.181 06/10/2014 ' */
            _.Display($"VERSAO V.08 104.181 06/10/2014 ");

            /*" -211- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -213- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -223- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -227- DISPLAY '*** VA0850B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VA0850B *** ABRINDO CURSOR ...");

            /*" -228- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -228- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -231- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -232- DISPLAY 'PROBLEMAS NO OPEN (CHISTCB   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CHISTCB   ) ... ");

                /*" -234- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -236- DISPLAY '*** VA0850B *** PROCESSANDO ... ' . */
            _.Display($"*** VA0850B *** PROCESSANDO ... ");

            /*" -238- PERFORM R0910-00-FETCH-CHISTCB. */

            R0910_00_FETCH_CHISTCB_SECTION();

            /*" -239- IF WFIM-CHISTCB NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CHISTCB.IsEmpty())
            {

                /*" -241- DISPLAY '*** VA0850B *** NENHUMA PARCELA A PROCESSAR' */
                _.Display($"*** VA0850B *** NENHUMA PARCELA A PROCESSAR");

                /*" -243- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -246- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-CHISTCB NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_CHISTCB.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -247- DISPLAY 'SEGUROS  LIDOS ............. ' WACC-LIDOS. */
            _.Display($"SEGUROS  LIDOS ............. {AREA_DE_WORK.WACC_LIDOS}");

            /*" -249- DISPLAY 'ACERTOS EFETUADOS .......... ' WACC-GRAVADOS. */
            _.Display($"ACERTOS EFETUADOS .......... {AREA_DE_WORK.WACC_GRAVADOS}");

            /*" -249- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -223- EXEC SQL DECLARE CHISTCB CURSOR FOR SELECT NRCERTIF, COUNT(*) FROM SEGUROS.V0HISTCOBVA WHERE SITUACAO IN ( ' ' , '0' , '5' ) AND OPCAOPAG NOT IN ( '1' , '2' , '5' ) GROUP BY NRCERTIF HAVING COUNT(*) > 1 ORDER BY NRCERTIF END-EXEC. */
            CHISTCB = new VA0850B_CHISTCB(false);
            string GetQuery_CHISTCB()
            {
                var query = @$"SELECT NRCERTIF
							, 
							COUNT(*) 
							FROM SEGUROS.V0HISTCOBVA 
							WHERE SITUACAO IN ( ' '
							, '0'
							, '5' ) 
							AND OPCAOPAG NOT IN ( '1'
							, '2'
							, '5' ) 
							GROUP BY NRCERTIF 
							HAVING COUNT(*) > 1 
							ORDER BY NRCERTIF";

                return query;
            }
            CHISTCB.GetQueryEvent += GetQuery_CHISTCB;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -228- EXEC SQL OPEN CHISTCB END-EXEC. */

            CHISTCB.Open();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-DECLARE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_DECLARE_1()
        {
            /*" -406- EXEC SQL DECLARE CPARCEL CURSOR FOR SELECT NRPARCEL, PRMVG, PRMAP, DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND SITUACAO = ' ' ORDER BY NRPARCEL END-EXEC. */
            CPARCEL = new VA0850B_CPARCEL(true);
            string GetQuery_CPARCEL()
            {
                var query = @$"SELECT NRPARCEL
							, 
							PRMVG
							, 
							PRMAP
							, 
							DTVENCTO 
							FROM SEGUROS.V0PARCELVA 
							WHERE NRCERTIF = '{V0HCOB_NRCERTIF}' 
							AND SITUACAO = ' ' 
							ORDER BY NRPARCEL";

                return query;
            }
            CPARCEL.GetQueryEvent += GetQuery_CPARCEL;

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -255- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -256- DISPLAY ' ' */
            _.Display($" ");

            /*" -258- DISPLAY '*--------  VA0850B - FIM NORMAL  --------*' */
            _.Display($"*--------  VA0850B - FIM NORMAL  --------*");

            /*" -258- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-CHISTCB-SECTION */
        private void R0910_00_FETCH_CHISTCB_SECTION()
        {
            /*" -269- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -272- PERFORM R0910_00_FETCH_CHISTCB_DB_FETCH_1 */

            R0910_00_FETCH_CHISTCB_DB_FETCH_1();

            /*" -275- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -276- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -276- PERFORM R0910_00_FETCH_CHISTCB_DB_CLOSE_1 */

                    R0910_00_FETCH_CHISTCB_DB_CLOSE_1();

                    /*" -278- MOVE 'S' TO WFIM-CHISTCB */
                    _.Move("S", AREA_DE_WORK.WFIM_CHISTCB);

                    /*" -279- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -280- ELSE */
                }
                else
                {


                    /*" -281- DISPLAY 'R0910-00 (ERRO -  FETCH CHISTCB   )...' */
                    _.Display($"R0910-00 (ERRO -  FETCH CHISTCB   )...");

                    /*" -283- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -283- ADD 1 TO WACC-LIDOS. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-CHISTCB-DB-FETCH-1 */
        public void R0910_00_FETCH_CHISTCB_DB_FETCH_1()
        {
            /*" -272- EXEC SQL FETCH CHISTCB INTO :V0HCOB-NRCERTIF, :V0HCOB-COUNT END-EXEC. */

            if (CHISTCB.Fetch())
            {
                _.Move(CHISTCB.V0HCOB_NRCERTIF, V0HCOB_NRCERTIF);
                _.Move(CHISTCB.V0HCOB_COUNT, V0HCOB_COUNT);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CHISTCB-DB-CLOSE-1 */
        public void R0910_00_FETCH_CHISTCB_DB_CLOSE_1()
        {
            /*" -276- EXEC SQL CLOSE CHISTCB END-EXEC */

            CHISTCB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -296- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -310- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -313- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -315- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -316- IF VIND-ESTR-COBR LESS 0 */

            if (VIND_ESTR_COBR < 0)
            {

                /*" -318- MOVE ' ' TO V0PROP-ESTR-COBR. */
                _.Move(" ", V0PROP_ESTR_COBR);
            }


            /*" -319- IF VIND-ORIG-PRODU LESS 0 */

            if (VIND_ORIG_PRODU < 0)
            {

                /*" -321- MOVE ' ' TO V0PROP-ORIG-PRODU. */
                _.Move(" ", V0PROP_ORIG_PRODU);
            }


            /*" -324- IF V0PROP-ORIG-PRODU EQUAL 'EMPRE' OR 'ESPEC' OR 'ESPE1' OR 'ESPE2' OR 'ESPE3' */

            if (V0PROP_ORIG_PRODU.In("EMPRE", "ESPEC", "ESPE1", "ESPE2", "ESPE3"))
            {

                /*" -326- GO TO R1000-90-LEITURA. */

                R1000_90_LEITURA(); //GOTO
                return;
            }


            /*" -328- IF V0PROP-SITUACAO = '4' OR V0PROP-ESTR-COBR NOT EQUAL 'MULT' */

            if (V0PROP_SITUACAO == "4" || V0PROP_ESTR_COBR != "MULT")
            {

                /*" -330- GO TO R1000-90-LEITURA. */

                R1000_90_LEITURA(); //GOTO
                return;
            }


            /*" -332- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -338- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -341- IF V0HCOB-NRPARCELMAX EQUAL 0 */

            if (V0HCOB_NRPARCELMAX == 0)
            {

                /*" -343- DISPLAY 'V0HISTCOBVA MAX NAO ENCONTRADA. ' 'CERTIFICADO ' V0HCOB-NRCERTIF */

                $"V0HISTCOBVA MAX NAO ENCONTRADA. CERTIFICADO {V0HCOB_NRCERTIF}"
                .Display();

                /*" -345- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -347- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -355- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

            /*" -358- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -359- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -360- MOVE '1021' TO WNR-EXEC-SQL */
                    _.Move("1021", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -381- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_4 */

                    R1000_00_PROCESSA_REGISTRO_DB_SELECT_4();

                    /*" -383- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -386- DISPLAY 'V0HISTCOBVA PARCELA NAO ENCONTR(1) ' 'CERTIF ' V0HCOB-NRCERTIF ' ' 'PARCEL ' V0HCOB-NRPARCELMAX */

                        $"V0HISTCOBVA PARCELA NAO ENCONTR(1) CERTIF {V0HCOB_NRCERTIF} PARCEL {V0HCOB_NRPARCELMAX}"
                        .Display();

                        /*" -387- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -388- END-IF */
                    }


                    /*" -389- ELSE */
                }
                else
                {


                    /*" -392- DISPLAY 'V0HISTCOBVA PARCELA NAO ENCONTR(2) ' 'CERTIFICADO ' V0HCOB-NRCERTIF ' ' 'PARCELA ' V0HCOB-NRPARCELMAX */

                    $"V0HISTCOBVA PARCELA NAO ENCONTR(2) CERTIFICADO {V0HCOB_NRCERTIF} PARCELA {V0HCOB_NRPARCELMAX}"
                    .Display();

                    /*" -393- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -394- END-IF */
                }


                /*" -396- END-IF. */
            }


            /*" -406- PERFORM R1000_00_PROCESSA_REGISTRO_DB_DECLARE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_DECLARE_1();

            /*" -410- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -410- PERFORM R1000_00_PROCESSA_REGISTRO_DB_OPEN_1 */

            R1000_00_PROCESSA_REGISTRO_DB_OPEN_1();

            /*" -413- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -414- DISPLAY 'PROBLEMAS NO OPEN (CPARCEL   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CPARCEL   ) ... ");

                /*" -416- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -417- MOVE SPACES TO WFIM-CPARCEL. */
            _.Move("", AREA_DE_WORK.WFIM_CPARCEL);

            /*" -419- PERFORM R1110-00-FETCH-CPARCEL. */

            R1110_00_FETCH_CPARCEL_SECTION();

            /*" -420- IF WFIM-CPARCEL NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CPARCEL.IsEmpty())
            {

                /*" -423- DISPLAY 'CPARCEL NAO ENCONTRADAS. ' 'CERTIFICADO ' V0HCOB-NRCERTIF */

                $"CPARCEL NAO ENCONTRADAS. CERTIFICADO {V0HCOB_NRCERTIF}"
                .Display();

                /*" -425- GO TO R1000-90-LEITURA. */

                R1000_90_LEITURA(); //GOTO
                return;
            }


            /*" -430- MOVE 0 TO V0PARC-PRMVGTOT V0PARC-PRMAPTOT V0PROP-QTDPARATZ V0HCOB-NRPARCELMIN. */
            _.Move(0, V0PARC_PRMVGTOT, V0PARC_PRMAPTOT, V0PROP_QTDPARATZ, V0HCOB_NRPARCELMIN);

            /*" -431- IF V0HCOB-OPCAOPAG NOT EQUAL '1' AND '2' AND '5' */

            if (!V0HCOB_OPCAOPAG.In("1", "2", "5"))
            {

                /*" -433- PERFORM R1100-00-PARC-EM-CARNE UNTIL WFIM-CPARCEL NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_CPARCEL.IsEmpty()))
                {

                    R1100_00_PARC_EM_CARNE_SECTION();
                }

                /*" -434- ELSE */
            }
            else
            {


                /*" -437- PERFORM R2100-00-PARC-EM-DEBITO UNTIL WFIM-CPARCEL NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_CPARCEL.IsEmpty()))
                {

                    R2100_00_PARC_EM_DEBITO_SECTION();
                }
            }


            /*" -438- IF V0HCOB-OPCAOPAG NOT EQUAL '1' AND '2' AND '5' */

            if (!V0HCOB_OPCAOPAG.In("1", "2", "5"))
            {

                /*" -440- COMPUTE V0HCOB-VLPRMTOT = V0PARC-PRMVGTOT + V0PARC-PRMAPTOT */
                V0HCOB_VLPRMTOT.Value = V0PARC_PRMVGTOT + V0PARC_PRMAPTOT;

                /*" -441- MOVE '1050' TO WNR-EXEC-SQL */
                _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -447- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

                R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();

                /*" -449- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -451- DISPLAY 'CERTIFICADO ' V0HCOB-NRCERTIF ' ' 'PARCELA ' V0HCOB-NRPARCELMAX */

                    $"CERTIFICADO {V0HCOB_NRCERTIF} PARCELA {V0HCOB_NRPARCELMAX}"
                    .Display();

                    /*" -452- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -453- END-IF */
                }


                /*" -454- MOVE '1060' TO WNR-EXEC-SQL */
                _.Move("1060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -460- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2 */

                R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2();

                /*" -462- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -464- DISPLAY 'CERTIFICADO ' V0HCOB-NRCERTIF ' ' 'PARCELA ' V0HCOB-NRPARCELMAX */

                    $"CERTIFICADO {V0HCOB_NRCERTIF} PARCELA {V0HCOB_NRPARCELMAX}"
                    .Display();

                    /*" -466- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -468- MOVE '1070' TO WNR-EXEC-SQL. */
            _.Move("1070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -474- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_3 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_3();

            /*" -477- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -478- DISPLAY 'CERTIFICADO ' V0HCOB-NRCERTIF */
                _.Display($"CERTIFICADO {V0HCOB_NRCERTIF}");

                /*" -480- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -480- ADD 1 TO WACC-GRAVADOS. */
            AREA_DE_WORK.WACC_GRAVADOS.Value = AREA_DE_WORK.WACC_GRAVADOS + 1;

            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -310- EXEC SQL SELECT A.CODPRODU, A.SITUACAO, B.ESTR_COBR, B.ORIG_PRODU INTO :V0PROP-CODPRODU, :V0PROP-SITUACAO, :V0PROP-ESTR-COBR:VIND-ESTR-COBR, :V0PROP-ORIG-PRODU:VIND-ORIG-PRODU FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B WHERE A.NRCERTIF = :V0HCOB-NRCERTIF AND B.NUM_APOLICE= A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(executed_1.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(executed_1.V0PROP_ESTR_COBR, V0PROP_ESTR_COBR);
                _.Move(executed_1.VIND_ESTR_COBR, VIND_ESTR_COBR);
                _.Move(executed_1.V0PROP_ORIG_PRODU, V0PROP_ORIG_PRODU);
                _.Move(executed_1.VIND_ORIG_PRODU, VIND_ORIG_PRODU);
            }


        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -484- PERFORM R0910-00-FETCH-CHISTCB. */

            R0910_00_FETCH_CHISTCB_SECTION();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -338- EXEC SQL SELECT VALUE(MAX(NRPARCEL),0) INTO :V0HCOB-NRPARCELMAX FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND SITUACAO IN ( ' ' , '0' , '5' ) END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRPARCELMAX, V0HCOB_NRPARCELMAX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-OPEN-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_OPEN_1()
        {
            /*" -410- EXEC SQL OPEN CPARCEL END-EXEC. */

            CPARCEL.Open();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -447- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET CODOPER = :V0DIFP-CODOPER, VLPRMTOT = :V0HCOB-VLPRMTOT WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCELMAX END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1()
            {
                V0HCOB_VLPRMTOT = V0HCOB_VLPRMTOT.ToString(),
                V0DIFP_CODOPER = V0DIFP_CODOPER.ToString(),
                V0HCOB_NRPARCELMAX = V0HCOB_NRPARCELMAX.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -355- EXEC SQL SELECT NRTIT, OPCAOPAG INTO :V0HCOB-NRTIT, :V0HCOB-OPCAOPAG FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCELMAX END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                V0HCOB_NRPARCELMAX = V0HCOB_NRPARCELMAX.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
                _.Move(executed_1.V0HCOB_OPCAOPAG, V0HCOB_OPCAOPAG);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2()
        {
            /*" -460- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET PRMVG = :V0PARC-PRMVGTOT, PRMAP = :V0PARC-PRMAPTOT WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCELMAX END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1()
            {
                V0PARC_PRMVGTOT = V0PARC_PRMVGTOT.ToString(),
                V0PARC_PRMAPTOT = V0PARC_PRMAPTOT.ToString(),
                V0HCOB_NRPARCELMAX = V0HCOB_NRPARCELMAX.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1100-00-PARC-EM-CARNE-SECTION */
        private void R1100_00_PARC_EM_CARNE_SECTION()
        {
            /*" -496- IF V0HCOB-NRPARCELMIN EQUAL 0 */

            if (V0HCOB_NRPARCELMIN == 0)
            {

                /*" -498- MOVE V0PARC-NRPARCEL TO V0HCOB-NRPARCELMIN. */
                _.Move(V0PARC_NRPARCEL, V0HCOB_NRPARCELMIN);
            }


            /*" -499- IF V0PARC-NRPARCEL < V0HCOB-NRPARCELMAX */

            if (V0PARC_NRPARCEL < V0HCOB_NRPARCELMAX)
            {

                /*" -500- MOVE '1100' TO WNR-EXEC-SQL */
                _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -506- PERFORM R1100_00_PARC_EM_CARNE_DB_UPDATE_1 */

                R1100_00_PARC_EM_CARNE_DB_UPDATE_1();

                /*" -508- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -510- DISPLAY 'CERTIFICADO ' V0HCOB-NRCERTIF ' ' 'PARCELA ' V0HCOB-NRPARCELMAX */

                    $"CERTIFICADO {V0HCOB_NRCERTIF} PARCELA {V0HCOB_NRPARCELMAX}"
                    .Display();

                    /*" -511- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -512- END-IF */
                }


                /*" -513- MOVE '1105' TO WNR-EXEC-SQL */
                _.Move("1105", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -519- PERFORM R1100_00_PARC_EM_CARNE_DB_UPDATE_2 */

                R1100_00_PARC_EM_CARNE_DB_UPDATE_2();

                /*" -521- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -522- DISPLAY 'CERTIF: ' V0HCOB-NRCERTIF ' ' V0PARC-NRPARCEL */

                    $"CERTIF: {V0HCOB_NRCERTIF} {V0PARC_NRPARCEL}"
                    .Display();

                    /*" -524- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -525- ADD V0PARC-PRMVG TO V0PARC-PRMVGTOT. */
            V0PARC_PRMVGTOT.Value = V0PARC_PRMVGTOT + V0PARC_PRMVG;

            /*" -527- ADD V0PARC-PRMAP TO V0PARC-PRMAPTOT. */
            V0PARC_PRMAPTOT.Value = V0PARC_PRMAPTOT + V0PARC_PRMAP;

            /*" -529- ADD 1 TO V0PROP-QTDPARATZ. */
            V0PROP_QTDPARATZ.Value = V0PROP_QTDPARATZ + 1;

            /*" -530- IF V0PROP-QTDPARATZ = 1 */

            if (V0PROP_QTDPARATZ == 1)
            {

                /*" -531- MOVE 121 TO V0DIFP-CODOPER */
                _.Move(121, V0DIFP_CODOPER);

                /*" -532- ELSE */
            }
            else
            {


                /*" -533- IF V0PROP-QTDPARATZ = 2 */

                if (V0PROP_QTDPARATZ == 2)
                {

                    /*" -534- MOVE 122 TO V0DIFP-CODOPER */
                    _.Move(122, V0DIFP_CODOPER);

                    /*" -535- ELSE */
                }
                else
                {


                    /*" -537- MOVE 123 TO V0DIFP-CODOPER. */
                    _.Move(123, V0DIFP_CODOPER);
                }

            }


            /*" -538- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -0- FLUXCONTROL_PERFORM R1100_00_GRAVA_DIFPARCEL */

            R1100_00_GRAVA_DIFPARCEL();

        }

        [StopWatch]
        /*" R1100-00-PARC-EM-CARNE-DB-UPDATE-1 */
        public void R1100_00_PARC_EM_CARNE_DB_UPDATE_1()
        {
            /*" -506- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL END-EXEC */

            var r1100_00_PARC_EM_CARNE_DB_UPDATE_1_Update1 = new R1100_00_PARC_EM_CARNE_DB_UPDATE_1_Update1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            R1100_00_PARC_EM_CARNE_DB_UPDATE_1_Update1.Execute(r1100_00_PARC_EM_CARNE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_3()
        {
            /*" -474- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET QTDPARATZ = :V0PROP-QTDPARATZ, NRPRIPARATZ = :V0HCOB-NRPARCELMIN, SITUACAO = '6' WHERE NRCERTIF = :V0HCOB-NRCERTIF END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_3_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_3_Update1()
            {
                V0HCOB_NRPARCELMIN = V0HCOB_NRPARCELMIN.ToString(),
                V0PROP_QTDPARATZ = V0PROP_QTDPARATZ.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_3_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R1100-00-PARC-EM-CARNE-DB-UPDATE-2 */
        public void R1100_00_PARC_EM_CARNE_DB_UPDATE_2()
        {
            /*" -519- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '2' , NRTITCOMP = :V0HCOB-NRTIT WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL END-EXEC */

            var r1100_00_PARC_EM_CARNE_DB_UPDATE_2_Update1 = new R1100_00_PARC_EM_CARNE_DB_UPDATE_2_Update1()
            {
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            R1100_00_PARC_EM_CARNE_DB_UPDATE_2_Update1.Execute(r1100_00_PARC_EM_CARNE_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-4 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_4()
        {
            /*" -381- EXEC SQL SELECT A.NRTIT, A.OPCAOPAG INTO :V0HCOB-NRTIT, :V0HCOB-OPCAOPAG FROM SEGUROS.V0HISTCOBVA A WHERE A.NRCERTIF = :V0HCOB-NRCERTIF AND A.NRPARCEL = :V0HCOB-NRPARCELMAX AND A.NRTIT = (SELECT MIN(B.NRTIT) FROM SEGUROS.V0HISTCOBVA B WHERE B.NRCERTIF = :V0HCOB-NRCERTIF AND B.NRPARCEL = :V0HCOB-NRPARCELMAX AND B.SITUACAO IN ( ' ' , '0' , '5' ) AND B.VLPRMTOT = (SELECT MIN(C.VLPRMTOT) FROM SEGUROS.V0HISTCOBVA C WHERE C.NRCERTIF = :V0HCOB-NRCERTIF AND C.NRPARCEL = :V0HCOB-NRPARCELMAX AND C.VLPRMTOT > 0 AND C.SITUACAO IN ( ' ' , '0' , '5' ))) END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1()
            {
                V0HCOB_NRPARCELMAX = V0HCOB_NRPARCELMAX.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
                _.Move(executed_1.V0HCOB_OPCAOPAG, V0HCOB_OPCAOPAG);
            }


        }

        [StopWatch]
        /*" R1100-00-GRAVA-DIFPARCEL */
        private void R1100_00_GRAVA_DIFPARCEL(bool isPerform = false)
        {
            /*" -544- MOVE '1104' TO WNR-EXEC-SQL. */
            _.Move("1104", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -559- PERFORM R1100_00_GRAVA_DIFPARCEL_DB_INSERT_1 */

            R1100_00_GRAVA_DIFPARCEL_DB_INSERT_1();

            /*" -562- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -563- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -564- MOVE '1106' TO WNR-EXEC-SQL */
                    _.Move("1106", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -570- PERFORM R1100_00_GRAVA_DIFPARCEL_DB_DELETE_1 */

                    R1100_00_GRAVA_DIFPARCEL_DB_DELETE_1();

                    /*" -572- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -573- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -574- END-IF */
                    }


                    /*" -575- GO TO R1100-00-GRAVA-DIFPARCEL */
                    new Task(() => R1100_00_GRAVA_DIFPARCEL()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -576- ELSE */
                }
                else
                {


                    /*" -578- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -579- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -581- PERFORM R1110-00-FETCH-CPARCEL. */

            R1110_00_FETCH_CPARCEL_SECTION();

        }

        [StopWatch]
        /*" R1100-00-GRAVA-DIFPARCEL-DB-INSERT-1 */
        public void R1100_00_GRAVA_DIFPARCEL_DB_INSERT_1()
        {
            /*" -559- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HCOB-NRCERTIF, :V0HCOB-NRPARCELMAX, :V0PARC-NRPARCEL, :V0DIFP-CODOPER, :V0PARC-DTVENCTO, :V0PARC-PRMVG, :V0PARC-PRMAP, 0, 0, :V0PARC-PRMVG, :V0PARC-PRMAP, 0, '1' ) END-EXEC. */

            var r1100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1 = new R1100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCELMAX = V0HCOB_NRPARCELMAX.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0DIFP_CODOPER = V0DIFP_CODOPER.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                V0PARC_PRMVG = V0PARC_PRMVG.ToString(),
                V0PARC_PRMAP = V0PARC_PRMAP.ToString(),
            };

            R1100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1.Execute(r1100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1100-00-GRAVA-DIFPARCEL-DB-DELETE-1 */
        public void R1100_00_GRAVA_DIFPARCEL_DB_DELETE_1()
        {
            /*" -570- EXEC SQL DELETE FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCELMAX AND NRPARCELDIF = :V0PARC-NRPARCEL AND CODOPER = :V0DIFP-CODOPER END-EXEC */

            var r1100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1 = new R1100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCELMAX = V0HCOB_NRPARCELMAX.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0DIFP_CODOPER = V0DIFP_CODOPER.ToString(),
            };

            R1100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1.Execute(r1100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-FETCH-CPARCEL-SECTION */
        private void R1110_00_FETCH_CPARCEL_SECTION()
        {
            /*" -591- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -596- PERFORM R1110_00_FETCH_CPARCEL_DB_FETCH_1 */

            R1110_00_FETCH_CPARCEL_DB_FETCH_1();

            /*" -599- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -600- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -600- PERFORM R1110_00_FETCH_CPARCEL_DB_CLOSE_1 */

                    R1110_00_FETCH_CPARCEL_DB_CLOSE_1();

                    /*" -602- MOVE 'S' TO WFIM-CPARCEL */
                    _.Move("S", AREA_DE_WORK.WFIM_CPARCEL);

                    /*" -603- ELSE */
                }
                else
                {


                    /*" -604- DISPLAY 'R1110-00 (ERRO -  FETCH CPARCEL   )...' */
                    _.Display($"R1110-00 (ERRO -  FETCH CPARCEL   )...");

                    /*" -604- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1110-00-FETCH-CPARCEL-DB-FETCH-1 */
        public void R1110_00_FETCH_CPARCEL_DB_FETCH_1()
        {
            /*" -596- EXEC SQL FETCH CPARCEL INTO :V0PARC-NRPARCEL, :V0PARC-PRMVG, :V0PARC-PRMAP, :V0PARC-DTVENCTO END-EXEC. */

            if (CPARCEL.Fetch())
            {
                _.Move(CPARCEL.V0PARC_NRPARCEL, V0PARC_NRPARCEL);
                _.Move(CPARCEL.V0PARC_PRMVG, V0PARC_PRMVG);
                _.Move(CPARCEL.V0PARC_PRMAP, V0PARC_PRMAP);
                _.Move(CPARCEL.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }

        }

        [StopWatch]
        /*" R1110-00-FETCH-CPARCEL-DB-CLOSE-1 */
        public void R1110_00_FETCH_CPARCEL_DB_CLOSE_1()
        {
            /*" -600- EXEC SQL CLOSE CPARCEL END-EXEC */

            CPARCEL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PARC-EM-DEBITO-SECTION */
        private void R2100_00_PARC_EM_DEBITO_SECTION()
        {
            /*" -616- IF V0HCOB-NRPARCELMIN EQUAL 0 */

            if (V0HCOB_NRPARCELMIN == 0)
            {

                /*" -618- MOVE V0PARC-NRPARCEL TO V0HCOB-NRPARCELMIN. */
                _.Move(V0PARC_NRPARCEL, V0HCOB_NRPARCELMIN);
            }


            /*" -619- ADD 1 TO V0PROP-QTDPARATZ. */
            V0PROP_QTDPARATZ.Value = V0PROP_QTDPARATZ + 1;

            /*" -620- IF V0PROP-QTDPARATZ = 1 */

            if (V0PROP_QTDPARATZ == 1)
            {

                /*" -621- MOVE 121 TO V0DIFP-CODOPER */
                _.Move(121, V0DIFP_CODOPER);

                /*" -622- ELSE */
            }
            else
            {


                /*" -623- IF V0PROP-QTDPARATZ = 2 */

                if (V0PROP_QTDPARATZ == 2)
                {

                    /*" -624- MOVE 122 TO V0DIFP-CODOPER */
                    _.Move(122, V0DIFP_CODOPER);

                    /*" -625- ELSE */
                }
                else
                {


                    /*" -627- MOVE 123 TO V0DIFP-CODOPER. */
                    _.Move(123, V0DIFP_CODOPER);
                }

            }


            /*" -628- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -0- FLUXCONTROL_PERFORM R2100_00_GRAVA_DIFPARCEL */

            R2100_00_GRAVA_DIFPARCEL();

        }

        [StopWatch]
        /*" R2100-00-GRAVA-DIFPARCEL */
        private void R2100_00_GRAVA_DIFPARCEL(bool isPerform = false)
        {
            /*" -634- MOVE '2105' TO WNR-EXEC-SQL. */
            _.Move("2105", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -649- PERFORM R2100_00_GRAVA_DIFPARCEL_DB_INSERT_1 */

            R2100_00_GRAVA_DIFPARCEL_DB_INSERT_1();

            /*" -652- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -653- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -654- MOVE '2106' TO WNR-EXEC-SQL */
                    _.Move("2106", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -660- PERFORM R2100_00_GRAVA_DIFPARCEL_DB_DELETE_1 */

                    R2100_00_GRAVA_DIFPARCEL_DB_DELETE_1();

                    /*" -662- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -663- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -664- ELSE */
                    }
                    else
                    {


                        /*" -665- GO TO R2100-00-GRAVA-DIFPARCEL */
                        new Task(() => R2100_00_GRAVA_DIFPARCEL()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -666- ELSE */
                    }

                }
                else
                {


                    /*" -668- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -669- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -672- PERFORM R1110-00-FETCH-CPARCEL. */

            R1110_00_FETCH_CPARCEL_SECTION();

        }

        [StopWatch]
        /*" R2100-00-GRAVA-DIFPARCEL-DB-INSERT-1 */
        public void R2100_00_GRAVA_DIFPARCEL_DB_INSERT_1()
        {
            /*" -649- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HCOB-NRCERTIF, :V0HCOB-NRPARCELMAX, :V0PARC-NRPARCEL, :V0DIFP-CODOPER, :V0PARC-DTVENCTO, :V0PARC-PRMVG, :V0PARC-PRMAP, 0, 0, :V0PARC-PRMVG, :V0PARC-PRMAP, 0, '1' ) END-EXEC. */

            var r2100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1 = new R2100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCELMAX = V0HCOB_NRPARCELMAX.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0DIFP_CODOPER = V0DIFP_CODOPER.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                V0PARC_PRMVG = V0PARC_PRMVG.ToString(),
                V0PARC_PRMAP = V0PARC_PRMAP.ToString(),
            };

            R2100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1.Execute(r2100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R2100-00-GRAVA-DIFPARCEL-DB-DELETE-1 */
        public void R2100_00_GRAVA_DIFPARCEL_DB_DELETE_1()
        {
            /*" -660- EXEC SQL DELETE FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCELMAX AND NRPARCELDIF = :V0PARC-NRPARCEL AND CODOPER = :V0DIFP-CODOPER END-EXEC */

            var r2100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1 = new R2100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCELMAX = V0HCOB_NRPARCELMAX.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0DIFP_CODOPER = V0DIFP_CODOPER.ToString(),
            };

            R2100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1.Execute(r2100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -683- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -685- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -686- DISPLAY 'LIDOS ' WACC-LIDOS. */
            _.Display($"LIDOS {AREA_DE_WORK.WACC_LIDOS}");

            /*" -688- DISPLAY 'CERTIFICADO ' V0HCOB-NRCERTIF */
            _.Display($"CERTIFICADO {V0HCOB_NRCERTIF}");

            /*" -688- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -690- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -694- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -694- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}