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
using Sias.VidaEmGrupo.DB2.VG5001B;

namespace Code
{
    public class VG5001B
    {
        public bool IsCall { get; set; }

        public VG5001B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------                                              */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *  EMISSAO COLETIVA DE CERTIFICADOS DE VIDA POR SUB-ESTIPULANTE  *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     *  03/11/92  * J. AGNALDO   *                       *      */
        /*"      *     02     *    /  /    *              *                       *      */
        /*"      *     03     *    /  /    *              *                       *      */
        /*"      *     04     *    /  /    *              *                       *      */
        /*"      *     05     *    /  /    *              *                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *             A L T E R A C O E S                                *      */
        /*"      ******************************************************************      */
        /*"      *            DATA INICIO  : 17.05.93                             *      */
        /*"      *            DATA FIM     :                                      *      */
        /*"      *            PROGRAMADOR  : ANDREA CORREA DE OLIVEIRA            *      */
        /*"      *            NOVO OBJETIVO: INCLUIR DADOS DA TABELA RELATORIO E  *      */
        /*"      *                           SEGURAVG NA TABELA V0RELATORIO PARA  *      */
        /*"      *                           POSTERIOR GERACAO DOS CERTIFICADOS   *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 1  - CADMUS 119494                                    *      */
        /*"      *                                                                *      */
        /*"      *             - PROJETO UNIC - RECUPERAR E TRANSPORTAR A         *      */
        /*"      *               INFORMACAO DO TIPO DE RELATORIO INSERIDO NA      *      */
        /*"      *               TABELA RELATORIO PELAS APLICACOES VGRAA E VGABA. *      */
        /*"      *                                                                *      */
        /*"      *    EM 15/06/2016 - FRANK CARVALHO (INDRA COMPANY)              *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.01        *      */
        /*"      ******************************************************************      */
        /*"      *            DATA INICIO  : 10.07.01                             *      */
        /*"      *            ANALISTA     : MANOEL MESSIAS                       *      */
        /*"      *            ALTERACAO    : CONTROLE DE EMISSAO DE CERTIFICADOS  *      */
        /*"      *                           NA NOVA VERSAO.                      *      */
        /*"      *                                               PROCURE MM0701.  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01          SISTEMA-DTMOVABE         PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          SNUM-CERTIFICADO           PIC S9(015)      COMP-3.*/
        public IntBasis SNUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  R-NUM-APOLICE             PIC S9(013) COMP-3.*/
        public IntBasis R_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  R-CODUSU                  PIC  X(008).*/
        public StringBasis R_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  R-CODSUBES                PIC S9(004) COMP.*/
        public IntBasis R_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  R-NRPARCEL                PIC S9(004) COMP.*/
        public IntBasis R_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  R-OPERACAO                PIC S9(004) COMP.*/
        public IntBasis R_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  R-COD-EMPRESA             PIC S9(004) COMP.*/
        public IntBasis R_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  R-PERI-RENOVACAO          PIC S9(004) COMP.*/
        public IntBasis R_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  R-PCT-AUMENTO             PIC S9(004) COMP.*/
        public IntBasis R_PCT_AUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  R-CORRECAO                PIC  X(001).*/
        public StringBasis R_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"    05      FLAG-FIM-MOVIMENTO       PIC  9(001) VALUE 0.*/

        public SelectorBasis FLAG_FIM_MOVIMENTO { get; set; } = new SelectorBasis("001", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-MOVIMENTO            VALUE 1. */
							new SelectorItemBasis("FIM_MOVIMENTO", "1")
                }
        };

        /*"    05      FLAG-EXISTE-MOV          PIC  9(001) VALUE 0.*/

        public SelectorBasis FLAG_EXISTE_MOV { get; set; } = new SelectorBasis("001", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88    HOUVE-MOVIMENTO          VALUE 1. */
							new SelectorItemBasis("HOUVE_MOVIMENTO", "1")
                }
        };

        /*"    05      FLAG-EXISTE-REL          PIC  9(001) VALUE 0.*/

        public SelectorBasis FLAG_EXISTE_REL { get; set; } = new SelectorBasis("001", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88    HOUVE-RELATORIO          VALUE 1. */
							new SelectorItemBasis("HOUVE_RELATORIO", "1")
                }
        };

        /*"    05      FLAG-EXISTE-SEG          PIC  9(001) VALUE 0.*/

        public SelectorBasis FLAG_EXISTE_SEG { get; set; } = new SelectorBasis("001", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88    HOUVE-SEGURAVG           VALUE 1. */
							new SelectorItemBasis("HOUVE_SEGURAVG", "1")
                }
        };

        /*"    05      FLAG-FIM-RELATORIO       PIC  9(001) VALUE 0.*/

        public SelectorBasis FLAG_FIM_RELATORIO { get; set; } = new SelectorBasis("001", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-RELATORIO            VALUE 1. */
							new SelectorItemBasis("FIM_RELATORIO", "1")
                }
        };

        /*"    05      WFIM-SEGURAVG            PIC  X(001) VALUE 'N'.*/
        public StringBasis WFIM_SEGURAVG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"    05      W-LIDOS                  PIC  9(07) VALUE 0.*/
        public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"    05      W-GRAVADOS               PIC  9(07) VALUE 0.*/
        public IntBasis W_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"    05      IND-TAB                  PIC S9(004) COMP.*/
        public IntBasis IND_TAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    05      IND-CARGA                PIC S9(004) COMP.*/
        public IntBasis IND_CARGA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    05      CONT-LIDOS-V0RELATORIO    PIC 9(007) VALUE ZEROS.*/
        public IntBasis CONT_LIDOS_V0RELATORIO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05      CONT-GRAVADOS-V0RELATORIO PIC 9(007) VALUE ZEROS.*/
        public IntBasis CONT_GRAVADOS_V0RELATORIO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05      CONT-LIDOS-SEGURAVG       PIC 9(007) VALUE ZEROS.*/
        public IntBasis CONT_LIDOS_SEGURAVG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05      WABEND.*/
        public VG5001B_WABEND WABEND { get; set; } = new VG5001B_WABEND();
        public class VG5001B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'VG5001B  '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VG5001B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO EXEC SQL  ****'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO EXEC SQL  ****");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    05      LOCALIZA-ABEND-1.*/
        }
        public VG5001B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VG5001B_LOCALIZA_ABEND_1();
        public class VG5001B_LOCALIZA_ABEND_1 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
            /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"    05      LOCALIZA-ABEND-2.*/
        }
        public VG5001B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VG5001B_LOCALIZA_ABEND_2();
        public class VG5001B_LOCALIZA_ABEND_2 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
            /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
            public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
        }


        public VG5001B_RELATORIO RELATORIO { get; set; } = new VG5001B_RELATORIO();
        public VG5001B_SEGURAVG SEGURAVG { get; set; } = new VG5001B_SEGURAVG();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -180- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -183- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -186- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -189- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -192- MOVE 'SELECT... FROM SEGUROS.V1SISTEMA' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1SISTEMA", LOCALIZA_ABEND_2.COMANDO);

            /*" -196- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -199- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -201- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -201- PERFORM 010-000-INICIO-PROCESSO. */

            M_010_000_INICIO_PROCESSO(true);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -196- EXEC SQL SELECT DTMOVABE INTO :SISTEMA-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-010-000-INICIO-PROCESSO */
        private void M_010_000_INICIO_PROCESSO(bool isPerform = false)
        {
            /*" -207- PERFORM 050-000-DECLARA-RELATORIO. */

            M_050_000_DECLARA_RELATORIO_SECTION();

            /*" -210- PERFORM 060-000-FETCH-RELATORIO. */

            M_060_000_FETCH_RELATORIO_SECTION();

            /*" -213- PERFORM 020-000-PROCESSA UNTIL FIM-RELATORIO. */

            while (!(FLAG_FIM_RELATORIO["FIM_RELATORIO"]))
            {

                M_020_000_PROCESSA_SECTION();
            }

            /*" -214- IF HOUVE-RELATORIO */

            if (FLAG_EXISTE_REL["HOUVE_RELATORIO"])
            {

                /*" -217- DISPLAY 'VG5001B - CERTIFICADOS GRAVADOS = ' CONT-GRAVADOS-V0RELATORIO */
                _.Display($"VG5001B - CERTIFICADOS GRAVADOS = {CONT_GRAVADOS_V0RELATORIO}");

                /*" -219- PERFORM 070-000-UPDATE-RELATORIOS */

                M_070_000_UPDATE_RELATORIOS_SECTION();

                /*" -220- ELSE */
            }
            else
            {


                /*" -222- DISPLAY ' VG5001B - NAO HOUVE SELECAO DE SOLICITACAO NEST 'A DATA - ' SISTEMA-DTMOVABE */

                $" VG5001B - NAO HOUVE SELECAO DE SOLICITACAO NEST ADATA-{SISTEMA_DTMOVABE}"
                .Display();

                /*" -225- DISPLAY ' ' . */
                _.Display($" ");
            }


            /*" -225- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -230- DISPLAY 'FIM NORMAL      **** VG5001B ****' . */
            _.Display($"FIM NORMAL      **** VG5001B ****");

            /*" -232- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -232- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-020-000-PROCESSA-SECTION */
        private void M_020_000_PROCESSA_SECTION()
        {
            /*" -238- MOVE SPACES TO WFIM-SEGURAVG. */
            _.Move("", WFIM_SEGURAVG);

            /*" -240- MOVE 0 TO FLAG-EXISTE-SEG. */
            _.Move(0, FLAG_EXISTE_SEG);

            /*" -241- PERFORM 090-000-CURSOR-V1SEGURAVG. */

            M_090_000_CURSOR_V1SEGURAVG_SECTION();

            /*" -244- PERFORM 100-000-FETCH-V1SEGURAVG UNTIL WFIM-SEGURAVG EQUAL 'S' . */

            while (!(WFIM_SEGURAVG == "S"))
            {

                M_100_000_FETCH_V1SEGURAVG_SECTION();
            }

            /*" -244- PERFORM 060-000-FETCH-RELATORIO. */

            M_060_000_FETCH_RELATORIO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/

        [StopWatch]
        /*" M-050-000-DECLARA-RELATORIO-SECTION */
        private void M_050_000_DECLARA_RELATORIO_SECTION()
        {
            /*" -260- MOVE '050-000-DECLARA-RELATORIO' TO PARAGRAFO. */
            _.Move("050-000-DECLARA-RELATORIO", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -262- MOVE '050' TO COMANDO. */
            _.Move("050", LOCALIZA_ABEND_2.COMANDO);

            /*" -274- PERFORM M_050_000_DECLARA_RELATORIO_DB_DECLARE_1 */

            M_050_000_DECLARA_RELATORIO_DB_DECLARE_1();

            /*" -278- PERFORM M_050_000_DECLARA_RELATORIO_DB_OPEN_1 */

            M_050_000_DECLARA_RELATORIO_DB_OPEN_1();

            /*" -281- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -282- DISPLAY 'VG5001B - ERRO NO DECLARE NA V1RELATORIO' */
                _.Display($"VG5001B - ERRO NO DECLARE NA V1RELATORIO");

                /*" -282- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-050-000-DECLARA-RELATORIO-DB-DECLARE-1 */
        public void M_050_000_DECLARA_RELATORIO_DB_DECLARE_1()
        {
            /*" -274- EXEC SQL DECLARE RELATORIO CURSOR FOR SELECT NUM_APOLICE, NRPARCEL, CODSUBES, OPERACAO, CODUSU, CORRECAO FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'VG' AND SITUACAO = '0' AND CODRELAT = 'VG5001B1' END-EXEC. */
            RELATORIO = new VG5001B_RELATORIO(false);
            string GetQuery_RELATORIO()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NRPARCEL
							, 
							CODSUBES
							, 
							OPERACAO
							, 
							CODUSU
							, 
							CORRECAO 
							FROM SEGUROS.V0RELATORIOS 
							WHERE IDSISTEM = 'VG' 
							AND SITUACAO = '0' 
							AND CODRELAT = 'VG5001B1'";

                return query;
            }
            RELATORIO.GetQueryEvent += GetQuery_RELATORIO;

        }

        [StopWatch]
        /*" M-050-000-DECLARA-RELATORIO-DB-OPEN-1 */
        public void M_050_000_DECLARA_RELATORIO_DB_OPEN_1()
        {
            /*" -278- EXEC SQL OPEN RELATORIO END-EXEC. */

            RELATORIO.Open();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1SEGURAVG-DB-DECLARE-1 */
        public void M_090_000_CURSOR_V1SEGURAVG_DB_DECLARE_1()
        {
            /*" -341- EXEC SQL DECLARE SEGURAVG CURSOR FOR SELECT NUM_CERTIFICADO FROM SEGUROS.V1SEGURAVG WHERE NUM_APOLICE = :R-NUM-APOLICE AND COD_SUBGRUPO = :R-CODSUBES AND SIT_REGISTRO = '0' AND TIPO_SEGURADO = '1' END-EXEC. */
            SEGURAVG = new VG5001B_SEGURAVG(true);
            string GetQuery_SEGURAVG()
            {
                var query = @$"SELECT NUM_CERTIFICADO 
							FROM SEGUROS.V1SEGURAVG 
							WHERE NUM_APOLICE = '{R_NUM_APOLICE}' 
							AND COD_SUBGRUPO = '{R_CODSUBES}' 
							AND SIT_REGISTRO = '0' 
							AND TIPO_SEGURADO = '1'";

                return query;
            }
            SEGURAVG.GetQueryEvent += GetQuery_SEGURAVG;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_050_999_EXIT*/

        [StopWatch]
        /*" M-060-000-FETCH-RELATORIO-SECTION */
        private void M_060_000_FETCH_RELATORIO_SECTION()
        {
            /*" -296- MOVE '060-000-FETCH-RELATORIO' TO PARAGRAFO. */
            _.Move("060-000-FETCH-RELATORIO", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -298- MOVE '060' TO COMANDO. */
            _.Move("060", LOCALIZA_ABEND_2.COMANDO);

            /*" -305- PERFORM M_060_000_FETCH_RELATORIO_DB_FETCH_1 */

            M_060_000_FETCH_RELATORIO_DB_FETCH_1();

            /*" -309- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -310- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -311- DISPLAY 'ATENCAO ----------------------------------' */
                    _.Display($"ATENCAO ----------------------------------");

                    /*" -312- DISPLAY '    VG5001B  - ERRO NO FETCH DO RELATORIOS' */
                    _.Display($"    VG5001B  - ERRO NO FETCH DO RELATORIOS");

                    /*" -313- DISPLAY '------------------------------------------' */
                    _.Display($"------------------------------------------");

                    /*" -314- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -315- ELSE */
                }
                else
                {


                    /*" -316- MOVE 1 TO FLAG-FIM-RELATORIO */
                    _.Move(1, FLAG_FIM_RELATORIO);

                    /*" -317- ELSE */
                }

            }
            else
            {


                /*" -318- MOVE 1 TO FLAG-EXISTE-REL */
                _.Move(1, FLAG_EXISTE_REL);

                /*" -318- ADD 1 TO CONT-LIDOS-V0RELATORIO. */
                CONT_LIDOS_V0RELATORIO.Value = CONT_LIDOS_V0RELATORIO + 1;
            }


        }

        [StopWatch]
        /*" M-060-000-FETCH-RELATORIO-DB-FETCH-1 */
        public void M_060_000_FETCH_RELATORIO_DB_FETCH_1()
        {
            /*" -305- EXEC SQL FETCH RELATORIO INTO :R-NUM-APOLICE, :R-NRPARCEL, :R-CODSUBES, :R-OPERACAO, :R-CODUSU, :R-CORRECAO END-EXEC. */

            if (RELATORIO.Fetch())
            {
                _.Move(RELATORIO.R_NUM_APOLICE, R_NUM_APOLICE);
                _.Move(RELATORIO.R_NRPARCEL, R_NRPARCEL);
                _.Move(RELATORIO.R_CODSUBES, R_CODSUBES);
                _.Move(RELATORIO.R_OPERACAO, R_OPERACAO);
                _.Move(RELATORIO.R_CODUSU, R_CODUSU);
                _.Move(RELATORIO.R_CORRECAO, R_CORRECAO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-V1SEGURAVG-SECTION */
        private void M_090_000_CURSOR_V1SEGURAVG_SECTION()
        {
            /*" -332- MOVE '090-000-DECLARA-V1SEGURAVG' TO PARAGRAFO. */
            _.Move("090-000-DECLARA-V1SEGURAVG", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -334- MOVE '090' TO COMANDO. */
            _.Move("090", LOCALIZA_ABEND_2.COMANDO);

            /*" -341- PERFORM M_090_000_CURSOR_V1SEGURAVG_DB_DECLARE_1 */

            M_090_000_CURSOR_V1SEGURAVG_DB_DECLARE_1();

            /*" -345- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -346- DISPLAY 'VG5001B - ERRO NO DECLARE NA V1SEGURAVG' */
                _.Display($"VG5001B - ERRO NO DECLARE NA V1SEGURAVG");

                /*" -348- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -349- PERFORM M_090_000_CURSOR_V1SEGURAVG_DB_OPEN_1 */

            M_090_000_CURSOR_V1SEGURAVG_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1SEGURAVG-DB-OPEN-1 */
        public void M_090_000_CURSOR_V1SEGURAVG_DB_OPEN_1()
        {
            /*" -349- EXEC SQL OPEN SEGURAVG END-EXEC. */

            SEGURAVG.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-100-000-FETCH-V1SEGURAVG-SECTION */
        private void M_100_000_FETCH_V1SEGURAVG_SECTION()
        {
            /*" -362- MOVE '100-000-FETCH-SEGURAVG' TO PARAGRAFO. */
            _.Move("100-000-FETCH-SEGURAVG", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -364- MOVE '100' TO COMANDO. */
            _.Move("100", LOCALIZA_ABEND_2.COMANDO);

            /*" -366- PERFORM M_100_000_FETCH_V1SEGURAVG_DB_FETCH_1 */

            M_100_000_FETCH_V1SEGURAVG_DB_FETCH_1();

            /*" -370- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -371- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -372- DISPLAY 'ATENCAO -----------------------------------' */
                    _.Display($"ATENCAO -----------------------------------");

                    /*" -373- DISPLAY '    VG5001BB - ERRO NO FETCH DO SEGURAVG   ' */
                    _.Display($"    VG5001BB - ERRO NO FETCH DO SEGURAVG   ");

                    /*" -374- DISPLAY '-------------------------------------------' */
                    _.Display($"-------------------------------------------");

                    /*" -375- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -376- ELSE */
                }
                else
                {


                    /*" -377- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -378- MOVE 'S' TO WFIM-SEGURAVG */
                        _.Move("S", WFIM_SEGURAVG);

                        /*" -378- PERFORM M_100_000_FETCH_V1SEGURAVG_DB_CLOSE_1 */

                        M_100_000_FETCH_V1SEGURAVG_DB_CLOSE_1();

                        /*" -381- GO TO 100-999-EXIT. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                        return;
                    }

                }

            }


            /*" -382- MOVE 1 TO FLAG-EXISTE-SEG. */
            _.Move(1, FLAG_EXISTE_SEG);

            /*" -383- ADD 1 TO CONT-LIDOS-SEGURAVG. */
            CONT_LIDOS_SEGURAVG.Value = CONT_LIDOS_SEGURAVG + 1;

            /*" -383- PERFORM 040-000-GRAVA-V0RELATORIO. */

            M_040_000_GRAVA_V0RELATORIO_SECTION();

        }

        [StopWatch]
        /*" M-100-000-FETCH-V1SEGURAVG-DB-FETCH-1 */
        public void M_100_000_FETCH_V1SEGURAVG_DB_FETCH_1()
        {
            /*" -366- EXEC SQL FETCH SEGURAVG INTO :SNUM-CERTIFICADO END-EXEC. */

            if (SEGURAVG.Fetch())
            {
                _.Move(SEGURAVG.SNUM_CERTIFICADO, SNUM_CERTIFICADO);
            }

        }

        [StopWatch]
        /*" M-100-000-FETCH-V1SEGURAVG-DB-CLOSE-1 */
        public void M_100_000_FETCH_V1SEGURAVG_DB_CLOSE_1()
        {
            /*" -378- EXEC SQL CLOSE SEGURAVG END-EXEC */

            SEGURAVG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/

        [StopWatch]
        /*" M-040-000-GRAVA-V0RELATORIO-SECTION */
        private void M_040_000_GRAVA_V0RELATORIO_SECTION()
        {
            /*" -397- MOVE '040-000-GRAVA-RELATORIO  ' TO PARAGRAFO. */
            _.Move("040-000-GRAVA-RELATORIO  ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -399- MOVE '040' TO COMANDO. */
            _.Move("040", LOCALIZA_ABEND_2.COMANDO);

            /*" -444- PERFORM M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1 */

            M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1();

            /*" -447- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -448- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -449- ELSE */
            }
            else
            {


                /*" -449- ADD 1 TO CONT-GRAVADOS-V0RELATORIO. */
                CONT_GRAVADOS_V0RELATORIO.Value = CONT_GRAVADOS_V0RELATORIO + 1;
            }


        }

        [StopWatch]
        /*" M-040-000-GRAVA-V0RELATORIO-DB-INSERT-1 */
        public void M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1()
        {
            /*" -444- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:R-CODUSU, :SISTEMA-DTMOVABE, 'VG' , 'VG5001B' , 0, 0, :SISTEMA-DTMOVABE, :SISTEMA-DTMOVABE, :SISTEMA-DTMOVABE, 0, 0, 0, 0, 0, 0, 0, 0, :R-NUM-APOLICE, 0, :R-NRPARCEL, :SNUM-CERTIFICADO, 0, :R-CODSUBES, :R-OPERACAO, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, :R-CORRECAO, '0' , ' ' , ' ' , NULL, NULL, NULL, CURRENT TIMESTAMP) END-EXEC. */

            var m_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1 = new M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1()
            {
                R_CODUSU = R_CODUSU.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                R_NUM_APOLICE = R_NUM_APOLICE.ToString(),
                R_NRPARCEL = R_NRPARCEL.ToString(),
                SNUM_CERTIFICADO = SNUM_CERTIFICADO.ToString(),
                R_CODSUBES = R_CODSUBES.ToString(),
                R_OPERACAO = R_OPERACAO.ToString(),
                R_CORRECAO = R_CORRECAO.ToString(),
            };

            M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1.Execute(m_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_999_EXIT*/

        [StopWatch]
        /*" M-070-000-UPDATE-RELATORIOS-SECTION */
        private void M_070_000_UPDATE_RELATORIOS_SECTION()
        {
            /*" -460- MOVE '070-000-UPDATE-RELATORIOS    ' TO PARAGRAFO. */
            _.Move("070-000-UPDATE-RELATORIOS    ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -462- MOVE 'UPDATE...  SEGUROS.V0RELATORIOS  ' TO COMANDO. */
            _.Move("UPDATE...  SEGUROS.V0RELATORIOS  ", LOCALIZA_ABEND_2.COMANDO);

            /*" -467- PERFORM M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1 */

            M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1();

            /*" -470- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -471- DISPLAY 'VG5001B - ERRO NA ATUAL. V0RELATORIOS ' */
                _.Display($"VG5001B - ERRO NA ATUAL. V0RELATORIOS ");

                /*" -471- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-070-000-UPDATE-RELATORIOS-DB-UPDATE-1 */
        public void M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1()
        {
            /*" -467- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODRELAT = 'VG5001B1' AND SITUACAO = '0' END-EXEC. */

            var m_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 = new M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1()
            {
            };

            M_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1.Execute(m_070_000_UPDATE_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_070_000_EXIT*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -483- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -484- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -485- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -486- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -487- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(LOCALIZA_ABEND_1);

            /*" -489- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(LOCALIZA_ABEND_2);

            /*" -489- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -491- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -494- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -494- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_EXIT*/
    }
}