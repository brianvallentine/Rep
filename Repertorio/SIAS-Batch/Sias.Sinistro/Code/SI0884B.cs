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
using Sias.Sinistro.DB2.SI0884B;

namespace Code
{
    public class SI0884B
    {
        public bool IsCall { get; set; }

        public SI0884B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SI - SINISTRO                      *      */
        /*"      *   PROGRAMA ...............  SI0884B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   RESPONSAVEL ............  EDUARDO (PRODEXTER)                *      */
        /*"      *   DATA CODIFICACAO .......  SETEMBRO / 2003                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ARQUIVO DE PRAZO MEDIO DE REGULACAO*      */
        /*"      *                             CONVERTIDOS (ANTES DE 17/03/2003)  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 18/04/2005 - PRODEXTER                                         *      */
        /*"      * SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A       *      */
        /*"      * SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        public FileBasis _RSICV23B { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis RSICV23B
        {
            get
            {
                _.Move(REG_ARQUIVO, _RSICV23B); VarBasis.RedefinePassValue(REG_ARQUIVO, _RSICV23B, REG_ARQUIVO); return _RSICV23B;
            }
        }
        /*"01               REG-ARQUIVO               PIC X(200).*/
        public StringBasis REG_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01        WFIM-CURS01             PIC  X(001)       VALUE SPACES*/
        public StringBasis WFIM_CURS01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01        WTEM-FASE               PIC  X(001)       VALUE SPACES*/
        public StringBasis WTEM_FASE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01 WS-ARQUIVO.*/
        public SI0884B_WS_ARQUIVO WS_ARQUIVO { get; set; } = new SI0884B_WS_ARQUIVO();
        public class SI0884B_WS_ARQUIVO : VarBasis
        {
            /*"    03 WS-COD-FONTE             PIC 9(004).*/
            public IntBasis WS_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 WS-PONTO-01              PIC X(001).*/
            public StringBasis WS_PONTO_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03 WS-NUM-PROTOCOLO-SINI    PIC 9(009).*/
            public IntBasis WS_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 WS-PONTO-02              PIC X(001).*/
            public StringBasis WS_PONTO_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03 WS-DAC-PROTOCOLO-SINI    PIC X(001).*/
            public StringBasis WS_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03 WS-PONTO-03              PIC X(001).*/
            public StringBasis WS_PONTO_03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03 WS-DATA-AVISO            PIC X(010).*/
            public StringBasis WS_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 WS-PONTO-04              PIC X(001).*/
            public StringBasis WS_PONTO_04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03 WS-COD-FASE              PIC 9(004).*/
            public IntBasis WS_COD_FASE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 WS-PONTO-05              PIC X(001).*/
            public StringBasis WS_PONTO_05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03 WS-SIGLA-FASE            PIC X(012).*/
            public StringBasis WS_SIGLA_FASE { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"    03 WS-PONTO-06              PIC X(001).*/
            public StringBasis WS_PONTO_06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03 WS-DATA-FASE             PIC X(010).*/
            public StringBasis WS_DATA_FASE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 WS-PONTO-07              PIC X(001).*/
            public StringBasis WS_PONTO_07 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03 WS-QTD-DIAS              PIC 9(004).*/
            public IntBasis WS_QTD_DIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 WS-PONTO-08              PIC X(001).*/
            public StringBasis WS_PONTO_08 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03 WS-TIPO-SINISTRO         PIC 9(001).*/
            public IntBasis WS_TIPO_SINISTRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    03 WS-PONTO-09              PIC X(001).*/
            public StringBasis WS_PONTO_09 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03 WS-VALOR-PENDENTE        PIC ------------9,99.*/
            public DoubleBasis WS_VALOR_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 WS-PONTO-10              PIC X(001).*/
            public StringBasis WS_PONTO_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03 WS-COD-SUBESTIPULANTE    PIC 9(004).*/
            public IntBasis WS_COD_SUBESTIPULANTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 WS-PONTO-11              PIC X(001).*/
            public StringBasis WS_PONTO_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03 WS-NOME-SEGURADO         PIC X(040).*/
            public StringBasis WS_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03 WS-PONTO-12              PIC X(001).*/
            public StringBasis WS_PONTO_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03 WS-NOME-USUARIO          PIC X(040).*/
            public StringBasis WS_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03 WS-PONTO-13              PIC X(001).*/
            public StringBasis WS_PONTO_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01        HOST-VALOR-PENDENTE     PIC  S9(13)V99 COMP-3 VALUE +0*/
        }
        public DoubleBasis HOST_VALOR_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01        W-DATA-INI              PIC  X(010)      VALUE SPACES.*/
        public StringBasis W_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01        W-DATA-FIM              PIC  X(010)      VALUE SPACES.*/
        public StringBasis W_DATA_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01        AC-L-CURS01             PIC  9(006)       VALUE ZEROS.*/
        public IntBasis AC_L_CURS01 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"01        AC-G-ARQUIVO            PIC  9(006)       VALUE ZEROS.*/
        public IntBasis AC_G_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"01        WS-COUNT                PIC S9(004) COMP  VALUE ZEROS.*/
        public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01        WCOUNT                  PIC  9(004)       VALUE ZEROS.*/
        public IntBasis WCOUNT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01        WABEND.*/
        public SI0884B_WABEND WABEND { get; set; } = new SI0884B_WABEND();
        public class SI0884B_WABEND : VarBasis
        {
            /*"  05      FILLER                  PIC  X(010)       VALUE          ' SICV23B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SICV23B");
            /*"  05      FILLER                  PIC  X(026)       VALUE          ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05      WNR-EXEC-SQL            PIC  X(005)       VALUE          '00000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"00000");
            /*"  05      FILLER                  PIC  X(013)       VALUE          ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05      WSQLCODE                PIC  ZZZZZZ999-   VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SIFASTIP SIFASTIP { get; set; } = new Dclgens.SIFASTIP();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.PAROPESI PAROPESI { get; set; } = new Dclgens.PAROPESI();
        public Dclgens.SISINACO SISINACO { get; set; } = new Dclgens.SISINACO();
        public Dclgens.SISINFAS SISINFAS { get; set; } = new Dclgens.SISINFAS();
        public Dclgens.SIMOVSIN SIMOVSIN { get; set; } = new Dclgens.SIMOVSIN();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SIANAROD SIANAROD { get; set; } = new Dclgens.SIANAROD();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public SI0884B_CURS01 CURS01 { get; set; } = new SI0884B_CURS01();
        public SI0884B_CURS02 CURS02 { get; set; } = new SI0884B_CURS02();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RSICV23B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RSICV23B.SetFile(RSICV23B_FILE_NAME_P);

                /*" -130- MOVE '0001' TO WNR-EXEC-SQL. */
                _.Move("0001", WABEND.WNR_EXEC_SQL);

                /*" -130- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -131- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -132- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -132- FLUXCONTROL_PERFORM M-0000-00-PRINCIPAL-SECTION */

                M_0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-00-PRINCIPAL-SECTION */
        private void M_0000_00_PRINCIPAL_SECTION()
        {
            /*" -140- PERFORM 0100-00-INICIALIZA */

            M_0100_00_INICIALIZA_SECTION();

            /*" -143- PERFORM 1000-00-PROCESSA UNTIL WFIM-CURS01 NOT EQUAL SPACES */

            while (!(!WFIM_CURS01.IsEmpty()))
            {

                M_1000_00_PROCESSA_SECTION();
            }

            /*" -145- PERFORM 9000-00-FINALIZA. */

            M_9000_00_FINALIZA_SECTION();

            /*" -145- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0100-00-INICIALIZA-SECTION */
        private void M_0100_00_INICIALIZA_SECTION()
        {
            /*" -153- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", WABEND.WNR_EXEC_SQL);

            /*" -155- PERFORM 0200-00-LE-SISTEMAS */

            M_0200_00_LE_SISTEMAS_SECTION();

            /*" -157- OPEN OUTPUT RSICV23B. */
            RSICV23B.Open(REG_ARQUIVO);

            /*" -158- PERFORM 0700-00-DC-SISINFAS */

            M_0700_00_DC_SISINFAS_SECTION();

            /*" -158- PERFORM 0900-00-LE-CURS01. */

            M_0900_00_LE_CURS01_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_99_SAIDA*/

        [StopWatch]
        /*" M-0200-00-LE-SISTEMAS-SECTION */
        private void M_0200_00_LE_SISTEMAS_SECTION()
        {
            /*" -169- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", WABEND.WNR_EXEC_SQL);

            /*" -175- PERFORM M_0200_00_LE_SISTEMAS_DB_SELECT_1 */

            M_0200_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -178- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -179- DISPLAY 'PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"PROBLEMAS NO SELECT SISTEMAS");

                /*" -179- GO TO 9999-00-ROT-ERRO. */

                M_9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0200-00-LE-SISTEMAS-DB-SELECT-1 */
        public void M_0200_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -175- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

            var m_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(m_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_99_SAIDA*/

        [StopWatch]
        /*" M-0700-00-DC-SISINFAS-SECTION */
        private void M_0700_00_DC_SISINFAS_SECTION()
        {
            /*" -190- MOVE '0004' TO WNR-EXEC-SQL. */
            _.Move("0004", WABEND.WNR_EXEC_SQL);

            /*" -216- PERFORM M_0700_00_DC_SISINFAS_DB_DECLARE_1 */

            M_0700_00_DC_SISINFAS_DB_DECLARE_1();

            /*" -218- PERFORM M_0700_00_DC_SISINFAS_DB_OPEN_1 */

            M_0700_00_DC_SISINFAS_DB_OPEN_1();

            /*" -221- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -222- DISPLAY 'PROBLEMAS NO OPEN DO JOIN' */
                _.Display($"PROBLEMAS NO OPEN DO JOIN");

                /*" -222- GO TO 9999-00-ROT-ERRO. */

                M_9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0700-00-DC-SISINFAS-DB-DECLARE-1 */
        public void M_0700_00_DC_SISINFAS_DB_DECLARE_1()
        {
            /*" -216- EXEC SQL DECLARE CURS01 CURSOR WITH HOLD FOR SELECT A.COD_FONTE, A.NUM_PROTOCOLO_SINI, A.DAC_PROTOCOLO_SINI, A.DATA_MOVTO_SINIACO, A.NUM_OCORR_SINIACO, C.NATUREZA_SINISTRO, C.COD_SUBESTIPULANTE, C.NOME_SEGURADO FROM SEGUROS.SI_SINISTRO_ACOMP A, SEGUROS.SI_MOVIMENTO_SINI C WHERE A.COD_EVENTO = 1001 AND A.COD_FONTE = C.COD_FONTE AND A.NUM_PROTOCOLO_SINI = C.NUM_PROTOCOLO_SINI AND A.DAC_PROTOCOLO_SINI = C.DAC_PROTOCOLO_SINI AND EXISTS (SELECT B.COD_USUARIO FROM SEGUROS.SI_SINISTRO_ACOMP B WHERE A.COD_FONTE = B.COD_FONTE AND A.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI AND A.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI AND B.NUM_OCORR_SINIACO = 1 AND B.COD_USUARIO = 'SICV01B' ) ORDER BY A.COD_FONTE, A.NUM_PROTOCOLO_SINI, A.DAC_PROTOCOLO_SINI END-EXEC. */
            CURS01 = new SI0884B_CURS01(false);
            string GetQuery_CURS01()
            {
                var query = @$"SELECT A.COD_FONTE
							, 
							A.NUM_PROTOCOLO_SINI
							, 
							A.DAC_PROTOCOLO_SINI
							, 
							A.DATA_MOVTO_SINIACO
							, 
							A.NUM_OCORR_SINIACO
							, 
							C.NATUREZA_SINISTRO
							, 
							C.COD_SUBESTIPULANTE
							, 
							C.NOME_SEGURADO 
							FROM SEGUROS.SI_SINISTRO_ACOMP A
							, 
							SEGUROS.SI_MOVIMENTO_SINI C 
							WHERE A.COD_EVENTO = 1001 
							AND A.COD_FONTE = C.COD_FONTE 
							AND A.NUM_PROTOCOLO_SINI = C.NUM_PROTOCOLO_SINI 
							AND A.DAC_PROTOCOLO_SINI = C.DAC_PROTOCOLO_SINI 
							AND EXISTS 
							(SELECT B.COD_USUARIO 
							FROM SEGUROS.SI_SINISTRO_ACOMP B 
							WHERE A.COD_FONTE = B.COD_FONTE 
							AND A.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI 
							AND A.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI 
							AND B.NUM_OCORR_SINIACO = 1 
							AND B.COD_USUARIO = 'SICV01B' ) 
							ORDER BY A.COD_FONTE
							, 
							A.NUM_PROTOCOLO_SINI
							, 
							A.DAC_PROTOCOLO_SINI";

                return query;
            }
            CURS01.GetQueryEvent += GetQuery_CURS01;

        }

        [StopWatch]
        /*" M-0700-00-DC-SISINFAS-DB-OPEN-1 */
        public void M_0700_00_DC_SISINFAS_DB_OPEN_1()
        {
            /*" -218- EXEC SQL OPEN CURS01 END-EXEC. */

            CURS01.Open();

        }

        [StopWatch]
        /*" M-1100-00-LE-PROXIMA-FASE-DB-DECLARE-1 */
        public void M_1100_00_LE_PROXIMA_FASE_DB_DECLARE_1()
        {
            /*" -401- EXEC SQL DECLARE CURS02 CURSOR WITH HOLD FOR SELECT A.COD_FASE, B.SIGLA_FASE, A.DATA_ABERTURA_SIFA, A.NUM_OCORR_SINIACO FROM SEGUROS.SI_SINISTRO_FASE A, SEGUROS.SI_FASE_TIPO B WHERE A.COD_FASE = B.COD_FASE AND A.COD_FONTE = :SISINACO-COD-FONTE AND A.NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND A.DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI AND A.NUM_OCORR_SINIACO > :SISINACO-NUM-OCORR-SINIACO AND A.COD_FASE IN (3, 4) ORDER BY A.NUM_OCORR_SINIACO END-EXEC. */
            CURS02 = new SI0884B_CURS02(true);
            string GetQuery_CURS02()
            {
                var query = @$"SELECT A.COD_FASE
							, 
							B.SIGLA_FASE
							, 
							A.DATA_ABERTURA_SIFA
							, 
							A.NUM_OCORR_SINIACO 
							FROM SEGUROS.SI_SINISTRO_FASE A
							, 
							SEGUROS.SI_FASE_TIPO B 
							WHERE A.COD_FASE = B.COD_FASE 
							AND A.COD_FONTE = '{SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE}' 
							AND A.NUM_PROTOCOLO_SINI = 
							'{SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI}' 
							AND A.DAC_PROTOCOLO_SINI = 
							'{SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}' 
							AND A.NUM_OCORR_SINIACO > 
							'{SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO}' 
							AND A.COD_FASE IN (3
							, 4) 
							ORDER BY A.NUM_OCORR_SINIACO";

                return query;
            }
            CURS02.GetQueryEvent += GetQuery_CURS02;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0700_99_SAIDA*/

        [StopWatch]
        /*" M-0900-00-LE-CURS01-SECTION */
        private void M_0900_00_LE_CURS01_SECTION()
        {
            /*" -233- MOVE '0005' TO WNR-EXEC-SQL. */
            _.Move("0005", WABEND.WNR_EXEC_SQL);

            /*" -242- PERFORM M_0900_00_LE_CURS01_DB_FETCH_1 */

            M_0900_00_LE_CURS01_DB_FETCH_1();

            /*" -245- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -246- ADD 1 TO AC-L-CURS01 */
                AC_L_CURS01.Value = AC_L_CURS01 + 1;

                /*" -247- ELSE */
            }
            else
            {


                /*" -248- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -249- MOVE 'S' TO WFIM-CURS01 */
                    _.Move("S", WFIM_CURS01);

                    /*" -249- PERFORM M_0900_00_LE_CURS01_DB_CLOSE_1 */

                    M_0900_00_LE_CURS01_DB_CLOSE_1();

                    /*" -251- ELSE */
                }
                else
                {


                    /*" -252- DISPLAY 'PROBLEMAS NO CURS01' */
                    _.Display($"PROBLEMAS NO CURS01");

                    /*" -252- GO TO 9999-00-ROT-ERRO. */

                    M_9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0900-00-LE-CURS01-DB-FETCH-1 */
        public void M_0900_00_LE_CURS01_DB_FETCH_1()
        {
            /*" -242- EXEC SQL FETCH CURS01 INTO :SISINACO-COD-FONTE, :SISINACO-NUM-PROTOCOLO-SINI, :SISINACO-DAC-PROTOCOLO-SINI, :SISINACO-DATA-MOVTO-SINIACO, :SISINACO-NUM-OCORR-SINIACO, :SIMOVSIN-NATUREZA-SINISTRO, :SIMOVSIN-COD-SUBESTIPULANTE, :SIMOVSIN-NOME-SEGURADO END-EXEC. */

            if (CURS01.Fetch())
            {
                _.Move(CURS01.SISINACO_COD_FONTE, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE);
                _.Move(CURS01.SISINACO_NUM_PROTOCOLO_SINI, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI);
                _.Move(CURS01.SISINACO_DAC_PROTOCOLO_SINI, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI);
                _.Move(CURS01.SISINACO_DATA_MOVTO_SINIACO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO);
                _.Move(CURS01.SISINACO_NUM_OCORR_SINIACO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO);
                _.Move(CURS01.SIMOVSIN_NATUREZA_SINISTRO, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO);
                _.Move(CURS01.SIMOVSIN_COD_SUBESTIPULANTE, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE);
                _.Move(CURS01.SIMOVSIN_NOME_SEGURADO, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_SEGURADO);
            }

        }

        [StopWatch]
        /*" M-0900-00-LE-CURS01-DB-CLOSE-1 */
        public void M_0900_00_LE_CURS01_DB_CLOSE_1()
        {
            /*" -249- EXEC SQL CLOSE CURS01 END-EXEC */

            CURS01.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0900_99_SAIDA*/

        [StopWatch]
        /*" M-1000-00-PROCESSA-SECTION */
        private void M_1000_00_PROCESSA_SECTION()
        {
            /*" -263- MOVE '0006' TO WNR-EXEC-SQL. */
            _.Move("0006", WABEND.WNR_EXEC_SQL);

            /*" -272- PERFORM M_1000_00_PROCESSA_DB_SELECT_1 */

            M_1000_00_PROCESSA_DB_SELECT_1();

            /*" -275- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -276- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -277- MOVE 'USUARIO NAO CADASTRADO' TO USUARIOS-NOME-USUARIO */
                    _.Move("USUARIO NAO CADASTRADO", USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);

                    /*" -278- ELSE */
                }
                else
                {


                    /*" -279- DISPLAY '*** SI0884B - ERRO NO SELECT USUARIOS ***' */
                    _.Display($"*** SI0884B - ERRO NO SELECT USUARIOS ***");

                    /*" -280- GO TO 9999-00-ROT-ERRO */

                    M_9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -281- END-IF */
                }


                /*" -283- END-IF. */
            }


            /*" -284- MOVE SPACES TO WS-ARQUIVO. */
            _.Move("", WS_ARQUIVO);

            /*" -285- MOVE ';' TO WS-PONTO-01. */
            _.Move(";", WS_ARQUIVO.WS_PONTO_01);

            /*" -286- MOVE ';' TO WS-PONTO-02. */
            _.Move(";", WS_ARQUIVO.WS_PONTO_02);

            /*" -287- MOVE ';' TO WS-PONTO-03. */
            _.Move(";", WS_ARQUIVO.WS_PONTO_03);

            /*" -288- MOVE ';' TO WS-PONTO-04. */
            _.Move(";", WS_ARQUIVO.WS_PONTO_04);

            /*" -289- MOVE ';' TO WS-PONTO-05. */
            _.Move(";", WS_ARQUIVO.WS_PONTO_05);

            /*" -290- MOVE ';' TO WS-PONTO-06. */
            _.Move(";", WS_ARQUIVO.WS_PONTO_06);

            /*" -291- MOVE ';' TO WS-PONTO-07. */
            _.Move(";", WS_ARQUIVO.WS_PONTO_07);

            /*" -292- MOVE ';' TO WS-PONTO-08. */
            _.Move(";", WS_ARQUIVO.WS_PONTO_08);

            /*" -293- MOVE ';' TO WS-PONTO-09. */
            _.Move(";", WS_ARQUIVO.WS_PONTO_09);

            /*" -294- MOVE ';' TO WS-PONTO-10. */
            _.Move(";", WS_ARQUIVO.WS_PONTO_10);

            /*" -295- MOVE ';' TO WS-PONTO-11. */
            _.Move(";", WS_ARQUIVO.WS_PONTO_11);

            /*" -296- MOVE ';' TO WS-PONTO-12. */
            _.Move(";", WS_ARQUIVO.WS_PONTO_12);

            /*" -297- MOVE ';' TO WS-PONTO-13. */
            _.Move(";", WS_ARQUIVO.WS_PONTO_13);

            /*" -298- MOVE SISINACO-COD-FONTE TO WS-COD-FONTE */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE, WS_ARQUIVO.WS_COD_FONTE);

            /*" -299- MOVE SISINACO-NUM-PROTOCOLO-SINI TO WS-NUM-PROTOCOLO-SINI */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI, WS_ARQUIVO.WS_NUM_PROTOCOLO_SINI);

            /*" -300- MOVE SISINACO-DAC-PROTOCOLO-SINI TO WS-DAC-PROTOCOLO-SINI */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI, WS_ARQUIVO.WS_DAC_PROTOCOLO_SINI);

            /*" -301- MOVE SISINACO-DATA-MOVTO-SINIACO TO WS-DATA-AVISO */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO, WS_ARQUIVO.WS_DATA_AVISO);

            /*" -302- MOVE SIMOVSIN-NATUREZA-SINISTRO TO WS-TIPO-SINISTRO */
            _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NATUREZA_SINISTRO, WS_ARQUIVO.WS_TIPO_SINISTRO);

            /*" -303- MOVE SIMOVSIN-COD-SUBESTIPULANTE TO WS-COD-SUBESTIPULANTE. */
            _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_SUBESTIPULANTE, WS_ARQUIVO.WS_COD_SUBESTIPULANTE);

            /*" -304- MOVE SIMOVSIN-NOME-SEGURADO TO WS-NOME-SEGURADO. */
            _.Move(SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_SEGURADO, WS_ARQUIVO.WS_NOME_SEGURADO);

            /*" -306- MOVE USUARIOS-NOME-USUARIO TO WS-NOME-USUARIO. */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, WS_ARQUIVO.WS_NOME_USUARIO);

            /*" -307- MOVE SPACES TO WTEM-FASE */
            _.Move("", WTEM_FASE);

            /*" -312- PERFORM 1100-00-LE-PROXIMA-FASE */

            M_1100_00_LE_PROXIMA_FASE_SECTION();

            /*" -313- IF WTEM-FASE EQUAL 'N' */

            if (WTEM_FASE == "N")
            {

                /*" -314- MOVE 0 TO WS-COD-FASE */
                _.Move(0, WS_ARQUIVO.WS_COD_FASE);

                /*" -315- MOVE 'PENDENTE' TO WS-SIGLA-FASE */
                _.Move("PENDENTE", WS_ARQUIVO.WS_SIGLA_FASE);

                /*" -317- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-FASE W-DATA-FIM */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_ARQUIVO.WS_DATA_FASE, W_DATA_FIM);

                /*" -318- ELSE */
            }
            else
            {


                /*" -319- MOVE SISINFAS-COD-FASE TO WS-COD-FASE */
                _.Move(SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE, WS_ARQUIVO.WS_COD_FASE);

                /*" -320- MOVE SIFASTIP-SIGLA-FASE TO WS-SIGLA-FASE */
                _.Move(SIFASTIP.DCLSI_FASE_TIPO.SIFASTIP_SIGLA_FASE, WS_ARQUIVO.WS_SIGLA_FASE);

                /*" -321- MOVE SISINFAS-DATA-ABERTURA-SIFA TO WS-DATA-FASE */
                _.Move(SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_ABERTURA_SIFA, WS_ARQUIVO.WS_DATA_FASE);

                /*" -322- MOVE SISINFAS-DATA-ABERTURA-SIFA TO W-DATA-FIM */
                _.Move(SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_ABERTURA_SIFA, W_DATA_FIM);

                /*" -324- GO TO 1000-10-LER. */

                M_1000_10_LER(); //GOTO
                return;
            }


            /*" -325- MOVE SISINACO-DATA-MOVTO-SINIACO TO W-DATA-INI */
            _.Move(SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO, W_DATA_INI);

            /*" -326- PERFORM 1200-00-CALCULA-DIAS */

            M_1200_00_CALCULA_DIAS_SECTION();

            /*" -328- MOVE WS-COUNT TO WS-QTD-DIAS */
            _.Move(WS_COUNT, WS_ARQUIVO.WS_QTD_DIAS);

            /*" -329- MOVE WS-COD-FONTE TO SINISMES-COD-FONTE */
            _.Move(WS_ARQUIVO.WS_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);

            /*" -331- MOVE WS-NUM-PROTOCOLO-SINI TO SINISMES-NUM-PROTOCOLO-SINI. */
            _.Move(WS_ARQUIVO.WS_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);

            /*" -333- MOVE '0007' TO WNR-EXEC-SQL. */
            _.Move("0007", WABEND.WNR_EXEC_SQL);

            /*" -339- PERFORM M_1000_00_PROCESSA_DB_SELECT_2 */

            M_1000_00_PROCESSA_DB_SELECT_2();

            /*" -342- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -345- DISPLAY 'ERRO NO ACESSO AO SINISTRO_MESTRE .......' ' ' SINISMES-COD-FONTE ' ' SINISMES-NUM-PROTOCOLO-SINI */

                $"ERRO NO ACESSO AO SINISTRO_MESTRE ....... {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI}"
                .Display();

                /*" -349- GO TO 9999-00-ROT-ERRO. */

                M_9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -351- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -353- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -355- CALL 'SI1001S' USING SI1001S-PARAMETROS */
            _.Call("SI1001S", LBSI1001.SI1001S_PARAMETROS);

            /*" -356- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -360- DISPLAY 'PROBLEMA CALL SI1001S ' ' ' SINISMES-COD-FONTE ' ' SINISMES-NUM-PROTOCOLO-SINI ' ' SI1001S-NUM-APOL-SINISTRO */

                $"PROBLEMA CALL SI1001S  {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI} {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}"
                .Display();

                /*" -361- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -362- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -363- GO TO 9999-00-ROT-ERRO */

                M_9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -364- ELSE */
            }
            else
            {


                /*" -366- MOVE SI1001S-VALOR-CALCULADO TO HOST-VALOR-PENDENTE. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_VALOR_PENDENTE);
            }


            /*" -368- MOVE HOST-VALOR-PENDENTE TO WS-VALOR-PENDENTE. */
            _.Move(HOST_VALOR_PENDENTE, WS_ARQUIVO.WS_VALOR_PENDENTE);

            /*" -369- WRITE REG-ARQUIVO FROM WS-ARQUIVO */
            _.Move(WS_ARQUIVO.GetMoveValues(), REG_ARQUIVO);

            RSICV23B.Write(REG_ARQUIVO.GetMoveValues().ToString());

            /*" -369- ADD 1 TO AC-G-ARQUIVO. */
            AC_G_ARQUIVO.Value = AC_G_ARQUIVO + 1;

            /*" -0- FLUXCONTROL_PERFORM M_1000_10_LER */

            M_1000_10_LER();

        }

        [StopWatch]
        /*" M-1000-00-PROCESSA-DB-SELECT-1 */
        public void M_1000_00_PROCESSA_DB_SELECT_1()
        {
            /*" -272- EXEC SQL SELECT U.NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.SI_ANALISTA_RODIZI E, SEGUROS.USUARIOS U WHERE E.COD_FONTE = :SISINACO-COD-FONTE AND E.NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND E.DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI AND U.COD_USUARIO = E.COD_USUARIO END-EXEC. */

            var m_1000_00_PROCESSA_DB_SELECT_1_Query1 = new M_1000_00_PROCESSA_DB_SELECT_1_Query1()
            {
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
            };

            var executed_1 = M_1000_00_PROCESSA_DB_SELECT_1_Query1.Execute(m_1000_00_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_NOME_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);
            }


        }

        [StopWatch]
        /*" M-1000-10-LER */
        private void M_1000_10_LER(bool isPerform = false)
        {
            /*" -373- PERFORM 0900-00-LE-CURS01. */

            M_0900_00_LE_CURS01_SECTION();

        }

        [StopWatch]
        /*" M-1000-00-PROCESSA-DB-SELECT-2 */
        public void M_1000_00_PROCESSA_DB_SELECT_2()
        {
            /*" -339- EXEC SQL SELECT NUM_APOL_SINISTRO INTO :SINISMES-NUM-APOL-SINISTRO FROM SEGUROS.SINISTRO_MESTRE WHERE COD_FONTE = :SINISMES-COD-FONTE AND NUM_PROTOCOLO_SINI = :SINISMES-NUM-PROTOCOLO-SINI END-EXEC. */

            var m_1000_00_PROCESSA_DB_SELECT_2_Query1 = new M_1000_00_PROCESSA_DB_SELECT_2_Query1()
            {
                SINISMES_NUM_PROTOCOLO_SINI = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI.ToString(),
                SINISMES_COD_FONTE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE.ToString(),
            };

            var executed_1 = M_1000_00_PROCESSA_DB_SELECT_2_Query1.Execute(m_1000_00_PROCESSA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_99_SAIDA*/

        [StopWatch]
        /*" M-1100-00-LE-PROXIMA-FASE-SECTION */
        private void M_1100_00_LE_PROXIMA_FASE_SECTION()
        {
            /*" -384- MOVE '0008' TO WNR-EXEC-SQL. */
            _.Move("0008", WABEND.WNR_EXEC_SQL);

            /*" -401- PERFORM M_1100_00_LE_PROXIMA_FASE_DB_DECLARE_1 */

            M_1100_00_LE_PROXIMA_FASE_DB_DECLARE_1();

            /*" -403- PERFORM M_1100_00_LE_PROXIMA_FASE_DB_OPEN_1 */

            M_1100_00_LE_PROXIMA_FASE_DB_OPEN_1();

            /*" -406- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -407- DISPLAY 'PROBLEMAS NO OPEN DO JOIN2' */
                _.Display($"PROBLEMAS NO OPEN DO JOIN2");

                /*" -409- GO TO 9999-00-ROT-ERRO. */

                M_9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -414- PERFORM M_1100_00_LE_PROXIMA_FASE_DB_FETCH_1 */

            M_1100_00_LE_PROXIMA_FASE_DB_FETCH_1();

            /*" -417- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -418- MOVE 'N' TO WTEM-FASE */
                _.Move("N", WTEM_FASE);

                /*" -419- ELSE */
            }
            else
            {


                /*" -420- IF SQLCODE NOT EQUAL 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -421- DISPLAY 'PROBLEMAS NO CURS02' */
                    _.Display($"PROBLEMAS NO CURS02");

                    /*" -424- DISPLAY ' ' SISINACO-COD-FONTE ' ' SISINACO-NUM-PROTOCOLO-SINI ' ' SISINACO-DAC-PROTOCOLO-SINI */

                    $" {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}"
                    .Display();

                    /*" -426- GO TO 9999-00-ROT-ERRO. */

                    M_9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -426- PERFORM M_1100_00_LE_PROXIMA_FASE_DB_CLOSE_1 */

            M_1100_00_LE_PROXIMA_FASE_DB_CLOSE_1();

        }

        [StopWatch]
        /*" M-1100-00-LE-PROXIMA-FASE-DB-OPEN-1 */
        public void M_1100_00_LE_PROXIMA_FASE_DB_OPEN_1()
        {
            /*" -403- EXEC SQL OPEN CURS02 END-EXEC. */

            CURS02.Open();

        }

        [StopWatch]
        /*" M-1100-00-LE-PROXIMA-FASE-DB-FETCH-1 */
        public void M_1100_00_LE_PROXIMA_FASE_DB_FETCH_1()
        {
            /*" -414- EXEC SQL FETCH CURS02 INTO :SISINFAS-COD-FASE, :SIFASTIP-SIGLA-FASE, :SISINFAS-DATA-ABERTURA-SIFA, :SISINFAS-NUM-OCORR-SINIACO END-EXEC. */

            if (CURS02.Fetch())
            {
                _.Move(CURS02.SISINFAS_COD_FASE, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE);
                _.Move(CURS02.SIFASTIP_SIGLA_FASE, SIFASTIP.DCLSI_FASE_TIPO.SIFASTIP_SIGLA_FASE);
                _.Move(CURS02.SISINFAS_DATA_ABERTURA_SIFA, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_ABERTURA_SIFA);
                _.Move(CURS02.SISINFAS_NUM_OCORR_SINIACO, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_OCORR_SINIACO);
            }

        }

        [StopWatch]
        /*" M-1100-00-LE-PROXIMA-FASE-DB-CLOSE-1 */
        public void M_1100_00_LE_PROXIMA_FASE_DB_CLOSE_1()
        {
            /*" -426- EXEC SQL CLOSE CURS02 END-EXEC. */

            CURS02.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_99_SAIDA*/

        [StopWatch]
        /*" M-1200-00-CALCULA-DIAS-SECTION */
        private void M_1200_00_CALCULA_DIAS_SECTION()
        {
            /*" -437- MOVE '0009' TO WNR-EXEC-SQL. */
            _.Move("0009", WABEND.WNR_EXEC_SQL);

            /*" -443- PERFORM M_1200_00_CALCULA_DIAS_DB_SELECT_1 */

            M_1200_00_CALCULA_DIAS_DB_SELECT_1();

            /*" -446- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -447- DISPLAY 'PROBLEMAS NO SELECT DA QTD DIAS: ' WS-COUNT */
                _.Display($"PROBLEMAS NO SELECT DA QTD DIAS: {WS_COUNT}");

                /*" -450- DISPLAY ' ' SISINACO-COD-FONTE ' ' SISINACO-NUM-PROTOCOLO-SINI ' ' SISINACO-DAC-PROTOCOLO-SINI */

                $" {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -450- GO TO 9999-00-ROT-ERRO. */

                M_9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1200-00-CALCULA-DIAS-DB-SELECT-1 */
        public void M_1200_00_CALCULA_DIAS_DB_SELECT_1()
        {
            /*" -443- EXEC SQL SELECT COUNT(*) INTO :WS-COUNT FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO BETWEEN :W-DATA-INI AND :W-DATA-FIM END-EXEC. */

            var m_1200_00_CALCULA_DIAS_DB_SELECT_1_Query1 = new M_1200_00_CALCULA_DIAS_DB_SELECT_1_Query1()
            {
                W_DATA_INI = W_DATA_INI.ToString(),
                W_DATA_FIM = W_DATA_FIM.ToString(),
            };

            var executed_1 = M_1200_00_CALCULA_DIAS_DB_SELECT_1_Query1.Execute(m_1200_00_CALCULA_DIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WS_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_99_SAIDA*/

        [StopWatch]
        /*" M-9000-00-FINALIZA-SECTION */
        private void M_9000_00_FINALIZA_SECTION()
        {
            /*" -461- MOVE '0010' TO WNR-EXEC-SQL. */
            _.Move("0010", WABEND.WNR_EXEC_SQL);

            /*" -461- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -464- DISPLAY '***************************' */
            _.Display($"***************************");

            /*" -465- DISPLAY '*   SICV23B - FIM NORMAL  *' */
            _.Display($"*   SICV23B - FIM NORMAL  *");

            /*" -466- DISPLAY '***************************' */
            _.Display($"***************************");

            /*" -467- DISPLAY 'LIDOS      SISINFAS - ' AC-L-CURS01 */
            _.Display($"LIDOS      SISINFAS - {AC_L_CURS01}");

            /*" -469- DISPLAY 'GRAVADOS NO ARQUIVO - ' AC-G-ARQUIVO */
            _.Display($"GRAVADOS NO ARQUIVO - {AC_G_ARQUIVO}");

            /*" -469- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_99_SAIDA*/

        [StopWatch]
        /*" M-9999-00-ROT-ERRO-SECTION */
        private void M_9999_00_ROT_ERRO_SECTION()
        {
            /*" -479- DISPLAY '***************************' */
            _.Display($"***************************");

            /*" -480- DISPLAY '*   SICV23B - CANCELADO   *' */
            _.Display($"*   SICV23B - CANCELADO   *");

            /*" -482- DISPLAY '***************************' */
            _.Display($"***************************");

            /*" -483- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -485- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -487- DISPLAY SQLCA */
            _.Display(DB.SQLCA);

            /*" -487- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -490- DISPLAY ' ' */
            _.Display($" ");

            /*" -491- DISPLAY '***************************' */
            _.Display($"***************************");

            /*" -492- DISPLAY '*      ROLLBACK WORK      *' */
            _.Display($"*      ROLLBACK WORK      *");

            /*" -494- DISPLAY '***************************' */
            _.Display($"***************************");

            /*" -495- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -495- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}