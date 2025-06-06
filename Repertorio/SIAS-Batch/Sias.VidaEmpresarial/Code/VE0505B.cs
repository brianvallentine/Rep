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
using Sias.VidaEmpresarial.DB2.VE0505B;

namespace Code
{
    public class VE0505B
    {
        public bool IsCall { get; set; }

        public VE0505B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  CONVERTE PARA O FUNDO DE COMISSOES AS COMISSOES               *      */
        /*"      *  PENDENTES DE PAGAMENTO E QUE SE REFEREM A VENDAS DO VIDAZUL   *      */
        /*"      *  EMPRESARIAL A PARTIR DE 01/04/98.                             *      */
        /*"      *                                                                *      */
        /*"      *                          ALEXANDRE FONSECA      15/04/98       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                 A L T E R A C O E S                            *      */
        /*"      ******************************************************************      */
        /*"      * 002 - MANOEL MESSIAS - 27/11/2003                              *      */
        /*"      *    ALTERACAO PARA PROCESSAR MULTI-PRODUTOS EMPRESARIAL.        *      */
        /*"      *                                                                *      */
        /*"      *                                           PROCURE POR MM1103   *      */
        /*"      ******************************************************************      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 28/05/1998.   *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  AGENCIA                          PIC S9(04) COMP.*/
        public IntBasis AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COMI-NUM-APOLICE               PIC S9(13)    COMP-3.*/
        public IntBasis V0COMI_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0COMI-NRPARCEL                  PIC S9(13)    COMP-3.*/
        public IntBasis V0COMI_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  CODSUBES                         PIC S9(04) COMP.*/
        public IntBasis CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  CODCLIEN                         PIC S9(09) COMP.*/
        public IntBasis CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  CODOPER                          PIC S9(04) COMP.*/
        public IntBasis CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  DTQITBCO                         PIC  X(10).*/
        public StringBasis DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  DTMOVABE                         PIC  X(10).*/
        public StringBasis DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  FONTE                            PIC S9(04) COMP.*/
        public IntBasis FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  RAMO                             PIC S9(04) COMP.*/
        public IntBasis RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  NRMATRVEN                        PIC S9(15)    COMP-3.*/
        public IntBasis NRMATRVEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  NRTERMO                          PIC S9(11)    COMP-3.*/
        public IntBasis NRTERMO { get; set; } = new IntBasis(new PIC("S9", "11", "S9(11)"));
        /*"01  PCCOMCOR                         PIC S9(03)V99 COMP-3.*/
        public DoubleBasis PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  PCCOMIND                         PIC S9(03)V99 COMP-3.*/
        public DoubleBasis PCCOMIND { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  PCCOMGER                         PIC S9(03)V99 COMP-3.*/
        public DoubleBasis PCCOMGER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  PCCOMSUP                         PIC S9(03)V99 COMP-3.*/
        public DoubleBasis PCCOMSUP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  TIPCOM                           PIC  X(01).*/
        public StringBasis TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  VALBAS                           PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VALBAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VLCOMIS                          PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VALBASVG                         PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VALBASVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VALBASAP                         PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VALBASAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VLCOMISVG                        PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VLCOMISVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VLCOMISAP                        PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VLCOMISAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  NUM-APOLICE                      PIC S9(13)    COMP-3.*/
        public IntBasis NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PERI-PAGAMENTO                   PIC S9(04) COMP.*/
        public IntBasis PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COD-PRODUTO                      PIC S9(04) COMP.*/
        public IntBasis COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WORK-AREA.*/
        public VE0505B_WORK_AREA WORK_AREA { get; set; } = new VE0505B_WORK_AREA();
        public class VE0505B_WORK_AREA : VarBasis
        {
            /*"    05 WS-CODSUBES                   PIC 9(05) VALUE 0.*/
            public IntBasis WS_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    05 WS-EOF                        PIC 9(01) VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05 AC-INSERIDOS                  PIC 9(06) VALUE 0.*/
            public IntBasis AC_INSERIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05 AC-DELETADOS                  PIC 9(06) VALUE 0.*/
            public IntBasis AC_DELETADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05      WABEND.*/
            public VE0505B_WABEND WABEND { get; set; } = new VE0505B_WABEND();
            public class VE0505B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VE0505B  '.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VE0505B  ");
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
            public VE0505B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VE0505B_LOCALIZA_ABEND_1();
            public class VE0505B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VE0505B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VE0505B_LOCALIZA_ABEND_2();
            public class VE0505B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public VE0505B_CCOMIS CCOMIS { get; set; } = new VE0505B_CCOMIS();
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
            /*" -120- MOVE 'INICIO' TO PARAGRAFO. */
            _.Move("INICIO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -121- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -124- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -127- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -131- MOVE 'SELECT V0SISTEMA' TO COMANDO. */
            _.Move("SELECT V0SISTEMA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -136- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -139- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -141- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -143- MOVE 'SELECT PARAMRAM ' TO COMANDO. */
            _.Move("SELECT PARAMRAM ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -154- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -157- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -158- DISPLAY ' ERRO ACESSO SEGUROS.PARAMETROS_RAMOS ' SQLCODE */
                _.Display($" ERRO ACESSO SEGUROS.PARAMETROS_RAMOS {DB.SQLCODE}");

                /*" -160- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -162- MOVE 'DECLARE CURSOR' TO COMANDO. */
            _.Move("DECLARE CURSOR", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -181- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -184- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -186- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -187- MOVE 'OPEN CURSOR' TO COMANDO. */
            _.Move("OPEN CURSOR", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -187- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -190- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -192- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -194- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -197- PERFORM 0100-PROCESSA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WORK_AREA.WS_EOF == 1))
            {

                M_0100_PROCESSA(true);

                M_0100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

            /*" -198- MOVE 'FIM' TO PARAGRAFO. */
            _.Move("FIM", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -199- MOVE 'CLOSE CURSOR' TO COMANDO. */
            _.Move("CLOSE CURSOR", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -199- PERFORM M_0000_PRINCIPAL_DB_CLOSE_1 */

            M_0000_PRINCIPAL_DB_CLOSE_1();

            /*" -202- MOVE 'COMMIT' TO COMANDO. */
            _.Move("COMMIT", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -202- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -206- DISPLAY AC-INSERIDOS ' LANCAMENTOS APROPRIADOS PARA O FUNDO DE COMISSOES.' . */
            _.Display($"{WORK_AREA.AC_INSERIDOS} LANCAMENTOS APROPRIADOS PARA O FUNDO DE COMISSOES.");

            /*" -208- DISPLAY AC-DELETADOS ' LINHAS DELETADAS DA V0COMISSAO.' . */
            _.Display($"{WORK_AREA.AC_DELETADOS} LINHAS DELETADAS DA V0COMISSAO.");

            /*" -210- DISPLAY '*** VE0505B *** TERMINO NORMAL' . */
            _.Display($"*** VE0505B *** TERMINO NORMAL");

            /*" -211- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -211- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -136- EXEC SQL SELECT DTMOVABE INTO :DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

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
        /*" M-0100-PROCESSA */
        private void M_0100_PROCESSA(bool isPerform = false)
        {
            /*" -220- MOVE '0100-PROCESSA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -222- MOVE 'SELECT V0TERMOADESAO' TO COMANDO. */
            _.Move("SELECT V0TERMOADESAO", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -238- PERFORM M_0100_PROCESSA_DB_SELECT_1 */

            M_0100_PROCESSA_DB_SELECT_1();

            /*" -241- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -242- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -245- MOVE CODSUBES TO WS-CODSUBES */
                    _.Move(CODSUBES, WORK_AREA.WS_CODSUBES);

                    /*" -246- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -247- ELSE */
                }
                else
                {


                    /*" -249- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -257- PERFORM M_0100_PROCESSA_DB_SELECT_2 */

            M_0100_PROCESSA_DB_SELECT_2();

            /*" -260- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -261- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -262- MOVE CODSUBES TO WS-CODSUBES */
                    _.Move(CODSUBES, WORK_AREA.WS_CODSUBES);

                    /*" -264- DISPLAY 'PRODUTO NAO ENCONTRADO ' V0COMI-NUM-APOLICE ' ' WS-CODSUBES */

                    $"PRODUTO NAO ENCONTRADO {V0COMI_NUM_APOLICE} {WORK_AREA.WS_CODSUBES}"
                    .Display();

                    /*" -265- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -266- ELSE */
                }
                else
                {


                    /*" -268- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -269- IF DTQITBCO > '1998-03-31' */

            if (DTQITBCO > "1998-03-31")
            {

                /*" -269- PERFORM M-0200-APROPRIA-FUNDO THRU 0200-FIM. */

                M_0200_APROPRIA_FUNDO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/

            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-DB-SELECT-1 */
        public void M_0100_PROCESSA_DB_SELECT_1()
        {
            /*" -238- EXEC SQL SELECT DATA_ADESAO, COD_AGENCIA_OP, NUM_TERMO, NUM_MATRICULA_VEN, PERI_PAGAMENTO, NUM_APOLICE INTO :DTQITBCO, :AGENCIA, :NRTERMO, :NRMATRVEN, :PERI-PAGAMENTO, :NUM-APOLICE FROM SEGUROS.V0TERMOADESAO WHERE NUM_APOLICE = :V0COMI-NUM-APOLICE AND COD_SUBGRUPO = :CODSUBES END-EXEC. */

            var m_0100_PROCESSA_DB_SELECT_1_Query1 = new M_0100_PROCESSA_DB_SELECT_1_Query1()
            {
                V0COMI_NUM_APOLICE = V0COMI_NUM_APOLICE.ToString(),
                CODSUBES = CODSUBES.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_DB_SELECT_1_Query1.Execute(m_0100_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DTQITBCO, DTQITBCO);
                _.Move(executed_1.AGENCIA, AGENCIA);
                _.Move(executed_1.NRTERMO, NRTERMO);
                _.Move(executed_1.NRMATRVEN, NRMATRVEN);
                _.Move(executed_1.PERI_PAGAMENTO, PERI_PAGAMENTO);
                _.Move(executed_1.NUM_APOLICE, NUM_APOLICE);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -181- EXEC SQL DECLARE CCOMIS CURSOR FOR SELECT NUM_APOLICE, CODSUBES, TIPCOM, RAMOFR, VALBAS, VLCOMIS, FONTE, CODCLIEN, OPERACAO, PCCOMCOR, NRPARCEL FROM SEGUROS.V0COMISSAO WHERE DATSEL = '9999-12-31' AND TIPCOM IN ( 'G' , 'H' , 'I' ) AND NUMREC = 0 AND VLCOMIS > 0 FOR UPDATE OF TIPCOM, RAMOFR END-EXEC. */
            CCOMIS = new VE0505B_CCOMIS(false);
            string GetQuery_CCOMIS()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							TIPCOM
							, 
							RAMOFR
							, 
							VALBAS
							, 
							VLCOMIS
							, 
							FONTE
							, 
							CODCLIEN
							, 
							OPERACAO
							, 
							PCCOMCOR
							, 
							NRPARCEL 
							FROM SEGUROS.V0COMISSAO 
							WHERE DATSEL = '9999-12-31' 
							AND TIPCOM IN ( 'G'
							, 'H'
							, 'I' ) 
							AND NUMREC = 0 
							AND VLCOMIS > 0";

                return query;
            }
            CCOMIS.GetQueryEvent += GetQuery_CCOMIS;

        }

        [StopWatch]
        /*" M-0100-PROCESSA-DB-SELECT-2 */
        public void M_0100_PROCESSA_DB_SELECT_2()
        {
            /*" -257- EXEC SQL SELECT COD_PRODUTO INTO :COD-PRODUTO FROM SEGUROS.VG_PRODUTO_SIAS WHERE NUM_APOLICE = :NUM-APOLICE AND NUM_PERIODO_PAG = :PERI-PAGAMENTO END-EXEC. */

            var m_0100_PROCESSA_DB_SELECT_2_Query1 = new M_0100_PROCESSA_DB_SELECT_2_Query1()
            {
                PERI_PAGAMENTO = PERI_PAGAMENTO.ToString(),
                NUM_APOLICE = NUM_APOLICE.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_DB_SELECT_2_Query1.Execute(m_0100_PROCESSA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PRODUTO, COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -187- EXEC SQL OPEN CCOMIS END-EXEC. */

            CCOMIS.Open();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-CLOSE-1 */
        public void M_0000_PRINCIPAL_DB_CLOSE_1()
        {
            /*" -199- EXEC SQL CLOSE CCOMIS END-EXEC. */

            CCOMIS.Close();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -154- EXEC SQL SELECT RAMO_VGAPC, RAMO_VG, RAMO_AP, NUM_RAMO_PRSTMISTA INTO :PARAMRAM-RAMO-VGAPC, :PARAMRAM-RAMO-VG, :PARAMRAM-RAMO-AP, :PARAMRAM-NUM-RAMO-PRSTMISTA FROM SEGUROS.PARAMETROS_RAMOS WHERE 1 = 1 END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_2_Query1 = new M_0000_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMRAM_RAMO_VGAPC, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VGAPC);
                _.Move(executed_1.PARAMRAM_RAMO_VG, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG);
                _.Move(executed_1.PARAMRAM_RAMO_AP, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP);
                _.Move(executed_1.PARAMRAM_NUM_RAMO_PRSTMISTA, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA);
            }


        }

        [StopWatch]
        /*" M-0100-NEXT */
        private void M_0100_NEXT(bool isPerform = false)
        {
            /*" -273- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0110-FETCH */
        private void M_0110_FETCH(bool isPerform = false)
        {
            /*" -280- MOVE '0110-FETCH' TO PARAGRAFO. */
            _.Move("0110-FETCH", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -282- MOVE 'FETCH CCOMIS' TO COMANDO. */
            _.Move("FETCH CCOMIS", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -295- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -298- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -298- MOVE 1 TO WS-EOF. */
                _.Move(1, WORK_AREA.WS_EOF);
            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -295- EXEC SQL FETCH CCOMIS INTO :V0COMI-NUM-APOLICE, :CODSUBES, :TIPCOM, :RAMO, :VALBAS, :VLCOMIS, :FONTE, :CODCLIEN, :CODOPER, :PCCOMCOR, :V0COMI-NRPARCEL END-EXEC. */

            if (CCOMIS.Fetch())
            {
                _.Move(CCOMIS.V0COMI_NUM_APOLICE, V0COMI_NUM_APOLICE);
                _.Move(CCOMIS.CODSUBES, CODSUBES);
                _.Move(CCOMIS.TIPCOM, TIPCOM);
                _.Move(CCOMIS.RAMO, RAMO);
                _.Move(CCOMIS.VALBAS, VALBAS);
                _.Move(CCOMIS.VLCOMIS, VLCOMIS);
                _.Move(CCOMIS.FONTE, FONTE);
                _.Move(CCOMIS.CODCLIEN, CODCLIEN);
                _.Move(CCOMIS.CODOPER, CODOPER);
                _.Move(CCOMIS.PCCOMCOR, PCCOMCOR);
                _.Move(CCOMIS.V0COMI_NRPARCEL, V0COMI_NRPARCEL);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0200-APROPRIA-FUNDO */
        private void M_0200_APROPRIA_FUNDO(bool isPerform = false)
        {
            /*" -305- MOVE '0200-APROPRIA-FUNDO' TO PARAGRAFO. */
            _.Move("0200-APROPRIA-FUNDO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -307- MOVE 'SELECT V0FUNDOCOMISVA' TO COMANDO. */
            _.Move("SELECT V0FUNDOCOMISVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -325- PERFORM M_0200_APROPRIA_FUNDO_DB_SELECT_1 */

            M_0200_APROPRIA_FUNDO_DB_SELECT_1();

            /*" -328- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -329- PERFORM 0300-GRAVA-FUNDO THRU 0300-FIM */

                M_0300_GRAVA_FUNDO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/


                /*" -330- ELSE */
            }
            else
            {


                /*" -331- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -333- PERFORM 0400-ATUALIZA-FUNDO THRU 0400-FIM. */

                    M_0400_ATUALIZA_FUNDO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0400_FIM*/

                }

            }


            /*" -335- MOVE 'DELETE V0COMISSAO' TO COMANDO. */
            _.Move("DELETE V0COMISSAO", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -338- PERFORM M_0200_APROPRIA_FUNDO_DB_DELETE_1 */

            M_0200_APROPRIA_FUNDO_DB_DELETE_1();

            /*" -341- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -342- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -344- END-IF. */
            }


            /*" -344- ADD 1 TO AC-DELETADOS. */
            WORK_AREA.AC_DELETADOS.Value = WORK_AREA.AC_DELETADOS + 1;

        }

        [StopWatch]
        /*" M-0200-APROPRIA-FUNDO-DB-SELECT-1 */
        public void M_0200_APROPRIA_FUNDO_DB_SELECT_1()
        {
            /*" -325- EXEC SQL SELECT VLBASVG, VALBASAP, VLCOMISVG, VLCOMISAP, PCCOMIND, PCCOMGER, PCCOMSUP INTO :VALBASVG, :VALBASAP, :VLCOMISVG, :VLCOMISAP, :PCCOMIND, :PCCOMGER, :PCCOMSUP FROM SEGUROS.V0FUNDOCOMISVA WHERE NUM_TERMO = :NRTERMO AND CODOPER = :CODOPER END-EXEC. */

            var m_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1 = new M_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1()
            {
                NRTERMO = NRTERMO.ToString(),
                CODOPER = CODOPER.ToString(),
            };

            var executed_1 = M_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1.Execute(m_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VALBASVG, VALBASVG);
                _.Move(executed_1.VALBASAP, VALBASAP);
                _.Move(executed_1.VLCOMISVG, VLCOMISVG);
                _.Move(executed_1.VLCOMISAP, VLCOMISAP);
                _.Move(executed_1.PCCOMIND, PCCOMIND);
                _.Move(executed_1.PCCOMGER, PCCOMGER);
                _.Move(executed_1.PCCOMSUP, PCCOMSUP);
            }


        }

        [StopWatch]
        /*" M-0200-APROPRIA-FUNDO-DB-DELETE-1 */
        public void M_0200_APROPRIA_FUNDO_DB_DELETE_1()
        {
            /*" -338- EXEC SQL DELETE FROM SEGUROS.V0COMISSAO WHERE CURRENT OF CCOMIS END-EXEC. */

            var m_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1 = new M_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1(CCOMIS)
            {
            };

            M_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1.Execute(m_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/

        [StopWatch]
        /*" M-0300-GRAVA-FUNDO */
        private void M_0300_GRAVA_FUNDO(bool isPerform = false)
        {
            /*" -352- MOVE '0300-GRAVA-FUNDO' TO PARAGRAFO. */
            _.Move("0300-GRAVA-FUNDO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -355- IF RAMO = PARAMRAM-RAMO-VGAPC OR PARAMRAM-RAMO-VG OR PARAMRAM-NUM-RAMO-PRSTMISTA */

            if (RAMO.In(PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VGAPC.ToString(), PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG.ToString(), PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA.ToString()))
            {

                /*" -356- MOVE VALBAS TO VALBASVG */
                _.Move(VALBAS, VALBASVG);

                /*" -358- MOVE 0 TO VALBASAP. */
                _.Move(0, VALBASAP);
            }


            /*" -359- IF RAMO = PARAMRAM-RAMO-AP OR 81 */

            if (RAMO.In(PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP.ToString(), "81"))
            {

                /*" -360- MOVE VALBAS TO VALBASAP */
                _.Move(VALBAS, VALBASAP);

                /*" -362- MOVE 0 TO VALBASVG. */
                _.Move(0, VALBASVG);
            }


            /*" -363- COMPUTE VLCOMISVG ROUNDED = (VALBASVG * PCCOMCOR) / 100. */
            VLCOMISVG.Value = (VALBASVG * PCCOMCOR) / 100f;

            /*" -365- COMPUTE VLCOMISAP ROUNDED = (VALBASAP * PCCOMCOR) / 100. */
            VLCOMISAP.Value = (VALBASAP * PCCOMCOR) / 100f;

            /*" -369- MOVE 0 TO PCCOMIND PCCOMGER PCCOMSUP. */
            _.Move(0, PCCOMIND, PCCOMGER, PCCOMSUP);

            /*" -370- IF TIPCOM = 'G' */

            if (TIPCOM == "G")
            {

                /*" -372- MOVE PCCOMCOR TO PCCOMIND. */
                _.Move(PCCOMCOR, PCCOMIND);
            }


            /*" -373- IF TIPCOM = 'H' */

            if (TIPCOM == "H")
            {

                /*" -375- MOVE PCCOMCOR TO PCCOMGER. */
                _.Move(PCCOMCOR, PCCOMGER);
            }


            /*" -376- IF TIPCOM = 'I' */

            if (TIPCOM == "I")
            {

                /*" -378- MOVE PCCOMCOR TO PCCOMSUP. */
                _.Move(PCCOMCOR, PCCOMSUP);
            }


            /*" -380- MOVE 'INSERT V0FUNDOCOMISVA' TO COMANDO. */
            _.Move("INSERT V0FUNDOCOMISVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -434- PERFORM M_0300_GRAVA_FUNDO_DB_INSERT_1 */

            M_0300_GRAVA_FUNDO_DB_INSERT_1();

            /*" -437- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -439- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -439- ADD 1 TO AC-INSERIDOS. */
            WORK_AREA.AC_INSERIDOS.Value = WORK_AREA.AC_INSERIDOS + 1;

        }

        [StopWatch]
        /*" M-0300-GRAVA-FUNDO-DB-INSERT-1 */
        public void M_0300_GRAVA_FUNDO_DB_INSERT_1()
        {
            /*" -434- EXEC SQL INSERT INTO SEGUROS.V0FUNDOCOMISVA (CODPRODU , NRCERTIF , NRPROPAZ , NUM_TERMO, SITUACAO , CODOPER , FONTE , AGENCIA , CODCLIEN , NRMATRVEN, VLBASVG , VALBASAP , VLCOMISVG, VLCOMISAP, DTQITBCO , PCCOMIND , PCCOMGER , PCCOMSUP , DTMOVTO , COD_USUARIO, TIMESTAMP, NUM_APOLICE, COD_SUBGRUPO, NUM_ENDOSSO, NUM_TITULO, NUM_PARCELA) VALUES (:COD-PRODUTO, 0, 0, :NRTERMO, '0' , :CODOPER, :FONTE, :AGENCIA, :CODCLIEN, :NRMATRVEN, :VALBASVG, :VALBASAP, :VLCOMISVG, :VLCOMISAP, :DTQITBCO, :PCCOMIND, :PCCOMGER, :PCCOMSUP, :DTMOVABE, 'VE0505B' , CURRENT TIMESTAMP, :NUM-APOLICE, :CODSUBES, 0, 0, :V0COMI-NRPARCEL) END-EXEC. */

            var m_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1 = new M_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1()
            {
                COD_PRODUTO = COD_PRODUTO.ToString(),
                NRTERMO = NRTERMO.ToString(),
                CODOPER = CODOPER.ToString(),
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
                NUM_APOLICE = NUM_APOLICE.ToString(),
                CODSUBES = CODSUBES.ToString(),
                V0COMI_NRPARCEL = V0COMI_NRPARCEL.ToString(),
            };

            M_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1.Execute(m_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/

        [StopWatch]
        /*" M-0400-ATUALIZA-FUNDO */
        private void M_0400_ATUALIZA_FUNDO(bool isPerform = false)
        {
            /*" -447- MOVE '0400-ATUALIZA-FUNDO' TO PARAGRAFO. */
            _.Move("0400-ATUALIZA-FUNDO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -450- IF RAMO = PARAMRAM-RAMO-VGAPC OR PARAMRAM-RAMO-VG OR PARAMRAM-NUM-RAMO-PRSTMISTA */

            if (RAMO.In(PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VGAPC.ToString(), PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG.ToString(), PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA.ToString()))
            {

                /*" -452- MOVE VALBAS TO VALBASVG. */
                _.Move(VALBAS, VALBASVG);
            }


            /*" -453- IF RAMO = 81 OR PARAMRAM-RAMO-AP */

            if (RAMO.In("81", PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP.ToString()))
            {

                /*" -455- MOVE VALBAS TO VALBASAP. */
                _.Move(VALBAS, VALBASAP);
            }


            /*" -459- MOVE 0 TO PCCOMIND PCCOMGER PCCOMSUP. */
            _.Move(0, PCCOMIND, PCCOMGER, PCCOMSUP);

            /*" -460- IF TIPCOM = 'G' */

            if (TIPCOM == "G")
            {

                /*" -462- MOVE PCCOMCOR TO PCCOMIND. */
                _.Move(PCCOMCOR, PCCOMIND);
            }


            /*" -463- IF TIPCOM = 'H' */

            if (TIPCOM == "H")
            {

                /*" -465- MOVE PCCOMCOR TO PCCOMGER. */
                _.Move(PCCOMCOR, PCCOMGER);
            }


            /*" -466- IF TIPCOM = 'I' */

            if (TIPCOM == "I")
            {

                /*" -468- MOVE PCCOMCOR TO PCCOMSUP. */
                _.Move(PCCOMCOR, PCCOMSUP);
            }


            /*" -470- COMPUTE PCCOMCOR = PCCOMIND + PCCOMGER + PCCOMSUP. */
            PCCOMCOR.Value = PCCOMIND + PCCOMGER + PCCOMSUP;

            /*" -471- COMPUTE VLCOMISVG ROUNDED = (VALBASVG * PCCOMCOR) / 100. */
            VLCOMISVG.Value = (VALBASVG * PCCOMCOR) / 100f;

            /*" -473- COMPUTE VLCOMISAP ROUNDED = (VALBASAP * PCCOMCOR) / 100. */
            VLCOMISAP.Value = (VALBASAP * PCCOMCOR) / 100f;

            /*" -475- MOVE 'UPDATE V0FUNDOCOMISVA' TO COMANDO. */
            _.Move("UPDATE V0FUNDOCOMISVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -487- PERFORM M_0400_ATUALIZA_FUNDO_DB_UPDATE_1 */

            M_0400_ATUALIZA_FUNDO_DB_UPDATE_1();

            /*" -490- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -490- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0400-ATUALIZA-FUNDO-DB-UPDATE-1 */
        public void M_0400_ATUALIZA_FUNDO_DB_UPDATE_1()
        {
            /*" -487- EXEC SQL UPDATE SEGUROS.V0FUNDOCOMISVA SET VLCOMISVG = :VLCOMISVG, VLCOMISAP = :VLCOMISAP, PCCOMIND = :PCCOMIND, PCCOMGER = :PCCOMGER, PCCOMSUP = :PCCOMSUP, NUM_APOLICE = :NUM-APOLICE, COD_SUBGRUPO = :CODSUBES, NUM_PARCELA = :V0COMI-NRPARCEL WHERE NUM_TERMO = :NRTERMO AND CODOPER = :CODOPER END-EXEC. */

            var m_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1 = new M_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1()
            {
                V0COMI_NRPARCEL = V0COMI_NRPARCEL.ToString(),
                NUM_APOLICE = NUM_APOLICE.ToString(),
                VLCOMISVG = VLCOMISVG.ToString(),
                VLCOMISAP = VLCOMISAP.ToString(),
                PCCOMIND = PCCOMIND.ToString(),
                PCCOMGER = PCCOMGER.ToString(),
                PCCOMSUP = PCCOMSUP.ToString(),
                CODSUBES = CODSUBES.ToString(),
                NRTERMO = NRTERMO.ToString(),
                CODOPER = CODOPER.ToString(),
            };

            M_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1.Execute(m_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0400_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -501- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -502- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -503- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -504- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -505- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -507- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -508- DISPLAY 'NUM_APOLICE  = ' V0COMI-NUM-APOLICE. */
            _.Display($"NUM_APOLICE  = {V0COMI_NUM_APOLICE}");

            /*" -509- DISPLAY 'COD_SUBGRUPO = ' CODSUBES. */
            _.Display($"COD_SUBGRUPO = {CODSUBES}");

            /*" -511- DISPLAY 'NUM_PARCELA  = ' V0COMI-NRPARCEL. */
            _.Display($"NUM_PARCELA  = {V0COMI_NRPARCEL}");

            /*" -511- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -513- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -517- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -517- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}