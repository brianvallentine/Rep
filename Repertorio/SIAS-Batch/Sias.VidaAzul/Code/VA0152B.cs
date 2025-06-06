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
using Sias.VidaAzul.DB2.VA0152B;

namespace Code
{
    public class VA0152B
    {
        public bool IsCall { get; set; }

        public VA0152B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *      GERA O ESTORNO DO FUNDO DE COMISSOES SOBRE OS SEGUROS     *      */
        /*"      *     CANCELADOS COM PRAZO INFERIOR A 90 DIAS DO MULTIPREMIADO   *      */
        /*"      *                                                                *      */
        /*"      *                                      FONSECA - 24/4/98         *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4           01/06/1998  *      */
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD- 125813 - ABEND V0SEGURAVG - SQLCODE 100     *      */
        /*"      *               BYPASSAR CERTIFICADO NAO ENCONTRADO V0SEGURAVG   *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/11/2015 - MAURO ROCHA              PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD- 66.936 -811 NO SELECT DA V0FUNDOCOMISVA     *      */
        /*"      *               PARA OPERACO 1103                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/02/2012 - MARCO PAIVA              PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CADMUS 2876 -811 NO SELECT DA V0FUNDOCOMISVA     *      */
        /*"      *               PARA OPERACO 1101                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/04/2007 - MARCO LIMA               PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - 19/05/2003 - FREDERICO FONSECA                     *      */
        /*"      *                          PASSA A RECUPERAR O AGENCIAMENTO DE   *      */
        /*"      * TODOS OS PRODUTOS COM IDSISTEM = 'VL' NA V0PRODUTOSVG.         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  AGENCIA                          PIC S9(4)       COMP.*/
        public IntBasis AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  CODCLIEN                         PIC S9(9)       COMP.*/
        public IntBasis CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  CODPRODU                         PIC S9(4)       COMP.*/
        public IntBasis CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  DTMOVABE                         PIC  X(10).*/
        public StringBasis DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  DTMOVTO                          PIC  X(10).*/
        public StringBasis DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  DTMAXCAN                         PIC  X(10).*/
        public StringBasis DTMAXCAN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  DTQITBCO                         PIC  X(10).*/
        public StringBasis DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  FONTE                            PIC S9(4)       COMP.*/
        public IntBasis FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  NRCERTIF                         PIC S9(15)      COMP-3.*/
        public IntBasis NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  NRMATRVEN                        PIC S9(15)      COMP-3.*/
        public IntBasis NRMATRVEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PCCOMIND                         PIC S9(3)V99    COMP-3.*/
        public DoubleBasis PCCOMIND { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V99"), 2);
        /*"01  PCCOMGER                         PIC S9(3)V99    COMP-3.*/
        public DoubleBasis PCCOMGER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V99"), 2);
        /*"01  PCCOMSUP                         PIC S9(3)V99    COMP-3.*/
        public DoubleBasis PCCOMSUP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V99"), 2);
        /*"01  VALADT                           PIC S9(13)V99   COMP-3.*/
        public DoubleBasis VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VALBASVG                         PIC S9(13)V99   COMP-3.*/
        public DoubleBasis VALBASVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VALBASAP                         PIC S9(13)V99   COMP-3.*/
        public DoubleBasis VALBASAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VLCOMISVG                        PIC S9(13)V99   COMP-3.*/
        public DoubleBasis VLCOMISVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VLCOMISAP                        PIC S9(13)V99   COMP-3.*/
        public DoubleBasis VLCOMISAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  ON-INTERVAL      PIC 9(05) VALUE 100.*/
        public IntBasis ON_INTERVAL { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"), 100);
        /*"01  ON-COUNTER       PIC 9(05) VALUE 0.*/
        public IntBasis ON_COUNTER { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
        /*"01  WS-TIME          PIC 99.99.99.99.*/
        public IntBasis WS_TIME { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
        /*"01  WORK-AREA.*/
        public VA0152B_WORK_AREA WORK_AREA { get; set; } = new VA0152B_WORK_AREA();
        public class VA0152B_WORK_AREA : VarBasis
        {
            /*"    05 AC-LIDOS                      PIC  9(009) VALUE 0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05 AC-GRAVFUN                    PIC  9(009) VALUE 0.*/
            public IntBasis AC_GRAVFUN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05 WS-EOF                        PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WABEND.*/
            public VA0152B_WABEND WABEND { get; set; } = new VA0152B_WABEND();
            public class VA0152B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA0152B  '.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0152B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL ***'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL ***");
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
            public VA0152B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0152B_LOCALIZA_ABEND_1();
            public class VA0152B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA0152B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0152B_LOCALIZA_ABEND_2();
            public class VA0152B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public VA0152B_CMOVIM CMOVIM { get; set; } = new VA0152B_CMOVIM();
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
            /*" -131- MOVE '0001-INICIO               ' TO PARAGRAFO. */
            _.Move("0001-INICIO               ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -132- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -135- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -138- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -141- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -142- DISPLAY 'PROGRAMA EM EXECUCAO VA0152B   ' */
            _.Display($"PROGRAMA EM EXECUCAO VA0152B   ");

            /*" -143- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -145- DISPLAY 'VERSAO V.03 125.813 19/11/2015 ' */
            _.Display($"VERSAO V.03 125.813 19/11/2015 ");

            /*" -146- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -148- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -149- MOVE 'SELECT V0SISTEMA' TO COMANDO. */
            _.Move("SELECT V0SISTEMA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -154- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -157- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -158- DISPLAY 'ERRO SELECT V0SISTEMA' */
                _.Display($"ERRO SELECT V0SISTEMA");

                /*" -160- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -172- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -175- MOVE 'OPEN CMOVIM' TO COMANDO. */
            _.Move("OPEN CMOVIM", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -175- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -178- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -179- DISPLAY 'ERRO OPEN CMOVIM     ' */
                _.Display($"ERRO OPEN CMOVIM     ");

                /*" -181- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -183- PERFORM 1010-FETCH THRU 1010-FIM. */

            M_1010_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1010_FIM*/


            /*" -184- DISPLAY '*** VA0152B *** PROCESSANDO ...' . */
            _.Display($"*** VA0152B *** PROCESSANDO ...");

            /*" -187- PERFORM 1000-PROCESSA-CANCEL THRU 1000-FIM UNTIL WS-EOF = 1. */

            while (!(WORK_AREA.WS_EOF == 1))
            {

                M_1000_PROCESSA_CANCEL(true);

                M_1000_10_CONTINUA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

            }

            /*" -187- PERFORM M_0000_PRINCIPAL_DB_CLOSE_1 */

            M_0000_PRINCIPAL_DB_CLOSE_1();

            /*" -190- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -191- DISPLAY 'ERRO CLOSE CMOVIM     ' */
                _.Display($"ERRO CLOSE CMOVIM     ");

                /*" -193- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -193- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -196- DISPLAY '*** VA0152B *** LIDOS               ' AC-LIDOS. */
            _.Display($"*** VA0152B *** LIDOS               {WORK_AREA.AC_LIDOS}");

            /*" -198- DISPLAY '*** VA0152B *** ESTORNOS V0FUNDOCOM ' AC-GRAVFUN. */
            _.Display($"*** VA0152B *** ESTORNOS V0FUNDOCOM {WORK_AREA.AC_GRAVFUN}");

            /*" -200- DISPLAY '*** VA0152B *** TERMINO NORMAL' . */
            _.Display($"*** VA0152B *** TERMINO NORMAL");

            /*" -201- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -201- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -154- EXEC SQL SELECT DTMOVABE INTO :DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DTMOVABE, DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -172- EXEC SQL DECLARE CMOVIM CURSOR FOR SELECT A.NUM_CERTIFICADO, A.DATA_MOVIMENTO FROM SEGUROS.V0MOVIMENTO A, SEGUROS.V0PRODUTOSVG B WHERE B.IDSISTEM = 'VL' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.CODSUBES AND A.DATA_INCLUSAO = :DTMOVABE AND A.COD_OPERACAO >= 400 AND A.COD_OPERACAO <= 499 END-EXEC. */
            CMOVIM = new VA0152B_CMOVIM(true);
            string GetQuery_CMOVIM()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.DATA_MOVIMENTO 
							FROM SEGUROS.V0MOVIMENTO A
							, 
							SEGUROS.V0PRODUTOSVG B 
							WHERE B.IDSISTEM = 'VL' 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.COD_SUBGRUPO = B.CODSUBES 
							AND A.DATA_INCLUSAO = '{DTMOVABE}' 
							AND A.COD_OPERACAO >= 400 
							AND A.COD_OPERACAO <= 499";

                return query;
            }
            CMOVIM.GetQueryEvent += GetQuery_CMOVIM;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -175- EXEC SQL OPEN CMOVIM END-EXEC. */

            CMOVIM.Open();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-CLOSE-1 */
        public void M_0000_PRINCIPAL_DB_CLOSE_1()
        {
            /*" -187- EXEC SQL CLOSE CMOVIM END-EXEC. */

            CMOVIM.Close();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-CANCEL */
        private void M_1000_PROCESSA_CANCEL(bool isPerform = false)
        {
            /*" -209- MOVE '1000-CANCEL' TO PARAGRAFO. */
            _.Move("1000-CANCEL", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -211- MOVE 'SELECT V0SEGURAVG' TO COMANDO. */
            _.Move("SELECT V0SEGURAVG", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -214- ADD 1 TO AC-LIDOS ON-COUNTER. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;
            ON_COUNTER.Value = ON_COUNTER + 1;

            /*" -216- IF AC-LIDOS EQUAL 1 OR ON-COUNTER EQUAL ON-INTERVAL */

            if (WORK_AREA.AC_LIDOS == 1 || ON_COUNTER == ON_INTERVAL)
            {

                /*" -217- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -218- DISPLAY 'LIDOS ' AC-LIDOS ' ' WS-TIME */

                $"LIDOS {WORK_AREA.AC_LIDOS} {WS_TIME}"
                .Display();

                /*" -220- MOVE 0 TO ON-COUNTER. */
                _.Move(0, ON_COUNTER);
            }


            /*" -226- PERFORM M_1000_PROCESSA_CANCEL_DB_SELECT_1 */

            M_1000_PROCESSA_CANCEL_DB_SELECT_1();

            /*" -229- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -230- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -231- DISPLAY 'CERTIFICADO NAO EXISTE V0SEGURAVG  ' NRCERTIF */
                    _.Display($"CERTIFICADO NAO EXISTE V0SEGURAVG  {NRCERTIF}");

                    /*" -232- GO TO 1000-10-CONTINUA */

                    M_1000_10_CONTINUA(); //GOTO
                    return;

                    /*" -233- ELSE */
                }
                else
                {


                    /*" -236- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -237- IF DTMOVTO NOT GREATER DTMAXCAN */

            if (DTMOVTO <= DTMAXCAN)
            {

                /*" -237- PERFORM M-1100-ESTORNA-COMISSAO THRU 1100-FIM. */

                M_1100_ESTORNA_COMISSAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-CANCEL-DB-SELECT-1 */
        public void M_1000_PROCESSA_CANCEL_DB_SELECT_1()
        {
            /*" -226- EXEC SQL SELECT DATA_INIVIGENCIA + 3 MONTH INTO :DTMAXCAN FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var m_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1 = new M_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1()
            {
                NRCERTIF = NRCERTIF.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1.Execute(m_1000_PROCESSA_CANCEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DTMAXCAN, DTMAXCAN);
            }


        }

        [StopWatch]
        /*" M-1000-10-CONTINUA */
        private void M_1000_10_CONTINUA(bool isPerform = false)
        {
            /*" -241- PERFORM 1010-FETCH THRU 1010-FIM. */

            M_1010_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1010_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1010-FETCH */
        private void M_1010_FETCH(bool isPerform = false)
        {
            /*" -251- MOVE '1010-FETCH' TO PARAGRAFO. */
            _.Move("1010-FETCH", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -253- MOVE 'FETCH CMOVIM' TO COMANDO. */
            _.Move("FETCH CMOVIM", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -257- PERFORM M_1010_FETCH_DB_FETCH_1 */

            M_1010_FETCH_DB_FETCH_1();

            /*" -260- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -261- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -262- MOVE 1 TO WS-EOF */
                    _.Move(1, WORK_AREA.WS_EOF);

                    /*" -263- ELSE */
                }
                else
                {


                    /*" -264- DISPLAY 'ERRO FETCH CMOVIM     ' */
                    _.Display($"ERRO FETCH CMOVIM     ");

                    /*" -264- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-1010-FETCH-DB-FETCH-1 */
        public void M_1010_FETCH_DB_FETCH_1()
        {
            /*" -257- EXEC SQL FETCH CMOVIM INTO :NRCERTIF, :DTMOVTO END-EXEC. */

            if (CMOVIM.Fetch())
            {
                _.Move(CMOVIM.NRCERTIF, NRCERTIF);
                _.Move(CMOVIM.DTMOVTO, DTMOVTO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1010_FIM*/

        [StopWatch]
        /*" M-1100-ESTORNA-COMISSAO */
        private void M_1100_ESTORNA_COMISSAO(bool isPerform = false)
        {
            /*" -275- MOVE '1100-ESTORNA-COMISSAO' TO PARAGRAFO. */
            _.Move("1100-ESTORNA-COMISSAO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -277- MOVE 'SELECT V0COMISICOBVA' TO COMANDO. */
            _.Move("SELECT V0COMISICOBVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -282- PERFORM M_1100_ESTORNA_COMISSAO_DB_SELECT_1 */

            M_1100_ESTORNA_COMISSAO_DB_SELECT_1();

            /*" -285- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -286- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -287- MOVE ZEROS TO VALADT */
                    _.Move(0, VALADT);

                    /*" -288- ELSE */
                }
                else
                {


                    /*" -290- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -291- IF VALADT = 0 */

            if (VALADT == 0)
            {

                /*" -291- PERFORM 1500-ESTORNA-FUNDO THRU 1500-FIM. */

                M_1500_ESTORNA_FUNDO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/

            }


        }

        [StopWatch]
        /*" M-1100-ESTORNA-COMISSAO-DB-SELECT-1 */
        public void M_1100_ESTORNA_COMISSAO_DB_SELECT_1()
        {
            /*" -282- EXEC SQL SELECT VALADT INTO :VALADT FROM SEGUROS.V0COMISICOBVA WHERE NRCERTIF = :NRCERTIF END-EXEC. */

            var m_1100_ESTORNA_COMISSAO_DB_SELECT_1_Query1 = new M_1100_ESTORNA_COMISSAO_DB_SELECT_1_Query1()
            {
                NRCERTIF = NRCERTIF.ToString(),
            };

            var executed_1 = M_1100_ESTORNA_COMISSAO_DB_SELECT_1_Query1.Execute(m_1100_ESTORNA_COMISSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VALADT, VALADT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

        [StopWatch]
        /*" M-1500-ESTORNA-FUNDO */
        private void M_1500_ESTORNA_FUNDO(bool isPerform = false)
        {
            /*" -301- MOVE '1500-ESTORNA-FUNDO' TO PARAGRAFO. */
            _.Move("1500-ESTORNA-FUNDO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -303- MOVE 'SELECT V0FUNDOCOMISVA 1103' TO COMANDO. */
            _.Move("SELECT V0FUNDOCOMISVA 1103", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -309- PERFORM M_1500_ESTORNA_FUNDO_DB_SELECT_1 */

            M_1500_ESTORNA_FUNDO_DB_SELECT_1();

            /*" -312- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -313- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -314- GO TO 1500-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                    return;

                    /*" -315- ELSE */
                }
                else
                {


                    /*" -317- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -318- ELSE */
                    }
                    else
                    {


                        /*" -319- DISPLAY 'ERRO SELECT V0FUNDOCOMISVA 1103 ' */
                        _.Display($"ERRO SELECT V0FUNDOCOMISVA 1103 ");

                        /*" -321- GO TO 9999-ERRO. */

                        M_9999_ERRO(); //GOTO
                        return;
                    }

                }

            }


            /*" -323- MOVE 'SELECT V0FUNDOCOMISVA 1101' TO COMANDO. */
            _.Move("SELECT V0FUNDOCOMISVA 1101", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -353- PERFORM M_1500_ESTORNA_FUNDO_DB_SELECT_2 */

            M_1500_ESTORNA_FUNDO_DB_SELECT_2();

            /*" -356- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -357- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -358- GO TO 1500-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                    return;

                    /*" -359- ELSE */
                }
                else
                {


                    /*" -361- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -362- ELSE */
                    }
                    else
                    {


                        /*" -364- GO TO 9999-ERRO. */

                        M_9999_ERRO(); //GOTO
                        return;
                    }

                }

            }


            /*" -366- MOVE 'INSERT V0FUNDOCOMISVA' TO COMANDO. */
            _.Move("INSERT V0FUNDOCOMISVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -410- PERFORM M_1500_ESTORNA_FUNDO_DB_INSERT_1 */

            M_1500_ESTORNA_FUNDO_DB_INSERT_1();

            /*" -413- IF SQLCODE NOT EQUAL ZEROES AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -415- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -415- ADD 1 TO AC-GRAVFUN. */
            WORK_AREA.AC_GRAVFUN.Value = WORK_AREA.AC_GRAVFUN + 1;

        }

        [StopWatch]
        /*" M-1500-ESTORNA-FUNDO-DB-SELECT-1 */
        public void M_1500_ESTORNA_FUNDO_DB_SELECT_1()
        {
            /*" -309- EXEC SQL SELECT CODPRODU INTO :CODPRODU FROM SEGUROS.V0FUNDOCOMISVA WHERE NRCERTIF = :NRCERTIF AND CODOPER = 1103 END-EXEC. */

            var m_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1 = new M_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1()
            {
                NRCERTIF = NRCERTIF.ToString(),
            };

            var executed_1 = M_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1.Execute(m_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CODPRODU, CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/

        [StopWatch]
        /*" M-1500-ESTORNA-FUNDO-DB-INSERT-1 */
        public void M_1500_ESTORNA_FUNDO_DB_INSERT_1()
        {
            /*" -410- EXEC SQL INSERT INTO SEGUROS.V0FUNDOCOMISVA (CODPRODU , NRCERTIF , NRPROPAZ , NUM_TERMO, SITUACAO , CODOPER , FONTE , AGENCIA , CODCLIEN , NRMATRVEN, VLBASVG , VALBASAP , VLCOMISVG, VLCOMISAP, DTQITBCO , PCCOMIND , PCCOMGER , PCCOMSUP , DTMOVTO , COD_USUARIO, TIMESTAMP) VALUES (:CODPRODU, :NRCERTIF, 0, 0, '0' , 1103, :FONTE, :AGENCIA, :CODCLIEN, :NRMATRVEN, :VALBASVG, :VALBASAP, :VLCOMISVG, :VLCOMISAP, :DTQITBCO, :PCCOMIND, :PCCOMGER, :PCCOMSUP, :DTMOVABE, 'VA0152B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_1500_ESTORNA_FUNDO_DB_INSERT_1_Insert1 = new M_1500_ESTORNA_FUNDO_DB_INSERT_1_Insert1()
            {
                CODPRODU = CODPRODU.ToString(),
                NRCERTIF = NRCERTIF.ToString(),
                FONTE = FONTE.ToString(),
                AGENCIA = AGENCIA.ToString(),
                CODCLIEN = CODCLIEN.ToString(),
                NRMATRVEN = NRMATRVEN.ToString(),
                VALBASVG = VALBASVG.ToString(),
                VALBASAP = VALBASAP.ToString(),
                VLCOMISVG = VLCOMISVG.ToString(),
                VLCOMISAP = VLCOMISAP.ToString(),
                DTQITBCO = DTQITBCO.ToString(),
                PCCOMIND = PCCOMIND.ToString(),
                PCCOMGER = PCCOMGER.ToString(),
                PCCOMSUP = PCCOMSUP.ToString(),
                DTMOVABE = DTMOVABE.ToString(),
            };

            M_1500_ESTORNA_FUNDO_DB_INSERT_1_Insert1.Execute(m_1500_ESTORNA_FUNDO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-1500-ESTORNA-FUNDO-DB-SELECT-2 */
        public void M_1500_ESTORNA_FUNDO_DB_SELECT_2()
        {
            /*" -353- EXEC SQL SELECT CODPRODU, FONTE, AGENCIA, CODCLIEN, NRMATRVEN, VLBASVG, VALBASAP, VLCOMISVG, VLCOMISAP, DTQITBCO, PCCOMIND, PCCOMGER, PCCOMSUP INTO :CODPRODU, :FONTE, :AGENCIA, :CODCLIEN, :NRMATRVEN, :VALBASVG, :VALBASAP, :VLCOMISVG, :VLCOMISAP, :DTQITBCO, :PCCOMIND, :PCCOMGER, :PCCOMSUP FROM SEGUROS.V0FUNDOCOMISVA WHERE NRCERTIF = :NRCERTIF AND CODOPER = 1101 END-EXEC. */

            var m_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1 = new M_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1()
            {
                NRCERTIF = NRCERTIF.ToString(),
            };

            var executed_1 = M_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1.Execute(m_1500_ESTORNA_FUNDO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CODPRODU, CODPRODU);
                _.Move(executed_1.FONTE, FONTE);
                _.Move(executed_1.AGENCIA, AGENCIA);
                _.Move(executed_1.CODCLIEN, CODCLIEN);
                _.Move(executed_1.NRMATRVEN, NRMATRVEN);
                _.Move(executed_1.VALBASVG, VALBASVG);
                _.Move(executed_1.VALBASAP, VALBASAP);
                _.Move(executed_1.VLCOMISVG, VLCOMISVG);
                _.Move(executed_1.VLCOMISAP, VLCOMISAP);
                _.Move(executed_1.DTQITBCO, DTQITBCO);
                _.Move(executed_1.PCCOMIND, PCCOMIND);
                _.Move(executed_1.PCCOMGER, PCCOMGER);
                _.Move(executed_1.PCCOMSUP, PCCOMSUP);
            }


        }

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -426- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -427- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -428- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -429- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -430- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -432- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -432- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -434- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -438- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -440- DISPLAY 'NRCERTIF      ' NRCERTIF. */
            _.Display($"NRCERTIF      {NRCERTIF}");

            /*" -440- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}