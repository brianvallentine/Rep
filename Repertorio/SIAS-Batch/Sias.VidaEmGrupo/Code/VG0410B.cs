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
using Sias.VidaEmGrupo.DB2.VG0410B;

namespace Code
{
    public class VG0410B
    {
        public bool IsCall { get; set; }

        public VG0410B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *            EMISSAO DE CERTIFICADO INDIVIDUAL                   *      */
        /*"      ******************************************************************      */
        /*"JV108 *----------------------------------------------------------------*      */
        /*"JV108 *VERSAO 08: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV108 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV108 *           - PROCURAR POR JV108                                 *      */
        /*"JV108 *----------------------------------------------------------------*      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     *  09/10/91  *   PROCAS     *                       *      */
        /*"      *     02     *    /  /    *   PROCAS     *                       *      */
        /*"      *     03     *    /  /    *   PROCAS     *                       *      */
        /*"      *     04     *    /  /    *   PROCAS     *                       *      */
        /*"      *     05     *    /  /    *   PROCAS     *                       *      */
        /*"      *     06     *  07/08/92  *   SOLON      *EXIBE PREMIO TOTAL     *      */
        /*"      *            *            *              *                       *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 07 - JAZZ 200.461                                     *      */
        /*"      *                                                                *      */
        /*"      *              - PREPARAR PROGRAMA PARA JV1                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/05/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR JV101     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - CAD 144.445                                      *      */
        /*"      *                                                                *      */
        /*"      *              - INCLUIR TRATAMENTO DO UNIC - FORMULARIOS DE     *      */
        /*"      *                RENOVACAO VD08 E VD09.                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/01/2017 -  LUIGI CONTE                                 *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.06      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CAD 96.034                                       *      */
        /*"      *                                                                *      */
        /*"      *              - RETIRADA DE CERTIFICADOS INCLUIDOS PELO VG1613B *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/03/2014 -  ELIERMES OLIVEIRA                           *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.05      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.04      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD 72.603                                       *      */
        /*"      *                                                                *      */
        /*"      *               - CORRECAO DA GERACAO INDEVIDA DE SEGUNDA VIA    *      */
        /*"      *                 DE CERTIFICADOS DE VIDA.                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/07/2012 - FAST COMPUTER - AUGUSTO ANASTACIO            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 002- CAD 041.441                                      *      */
        /*"      *                                                                *      */
        /*"      *               - CORRECAO PARA EVITAR DUPLICIDADE DE SOLICI-    *      */
        /*"      *                 TACAO DE EMISSAO DE CERTIFICADO NA TABELA      *      */
        /*"      *                 SEGUROS.RELATORIOS.                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/04/2010 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 13/10/2008 - INCLUIR CLAUSULA WITH UR NO SELECT     - WV1008   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO:                                                    *      */
        /*"      *            DATA INICIO  : 12.05.93                             *      */
        /*"      *            DATA FIM     :                                      *      */
        /*"      *            PROGRAMADOR  : ANDREA CORREA DE OLIVEIRA            *      */
        /*"      *            NOVO OBJETIVO: INCLUIR DADOS DA TABELA MOVIMENTO    *      */
        /*"      *                           NA TABELA V0RELATORIO PARA POSTERIOR *      */
        /*"      *                           GERACAO DOS CERTIFICADOS             *      */
        /*"      *                                                                *      */
        /*"      *  ALTERACAO: 30.11.93  (JOSE AGNALDO)                           *      */
        /*"      *            INIBIDO A SELECAO DE MOVIMENTO DE ALTERACAO DE      *      */
        /*"      *            CAPITAL COLETIVO DAS SEGUINTES APOLICES (PEDIDO     *      */
        /*"      *            DA DIVAP):                                          *      */
        /*"      *            93010000890,0109300000008                           *      */
        /*"      *                                                                *      */
        /*"      *  ALTERACAO: 13.02.95  (FONSECA)                                *      */
        /*"      *            PASSA A GERAR SOLICITACAO PARA AUMENTOS DE CAPITAL  *      */
        /*"      *            DA APOLICE VIDAZUL                                  *      */
        /*"      *                                                                *      */
        /*"      *  ALTERACAO: 09.07.01  (MESSIAS) - PROCURE MM0701               *      */
        /*"      *            CONTROLE DE EMISSOA DE CERTIFICADOS NA NOVA VERSAO. *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 02/06/1998.   *      */
        /*"      ******************************************************************      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01          RELAT-IDSISTEM           PIC  X(002).*/
        public StringBasis RELAT_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"01          RELAT-CODRELAT           PIC  X(008).*/
        public StringBasis RELAT_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01          RELAT-CODRELAT-I         PIC S9(004) COMP.*/
        public IntBasis RELAT_CODRELAT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          PRDVG-ESTR-EMISS-W       PIC S9(004) COMP.*/
        public IntBasis PRDVG_ESTR_EMISS_W { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          RELAT-NUM-APOLICE        PIC S9(013) COMP-3.*/
        public IntBasis RELAT_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          RELAT-COD-SUBES          PIC S9(004) COMP.*/
        public IntBasis RELAT_COD_SUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          RELAT-SITUACAO           PIC  X(001).*/
        public StringBasis RELAT_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          RELAT-NRPARCEL           PIC S9(004) COMP.*/
        public IntBasis RELAT_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          RELAT-OPERACAO           PIC S9(004) COMP.*/
        public IntBasis RELAT_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          MOVTO-COD-USUARIO        PIC  X(008).*/
        public StringBasis MOVTO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01          MOVTO-NUM-APOLICE        PIC S9(013) COMP-3.*/
        public IntBasis MOVTO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          MOVTO-COD-SUBES          PIC S9(004) COMP.*/
        public IntBasis MOVTO_COD_SUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          MOVTO-NUM-CERTIFIC       PIC S9(015) COMP-3.*/
        public IntBasis MOVTO_NUM_CERTIFIC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          MOVTO-COD-EMPRESA        PIC S9(009) COMP.*/
        public IntBasis MOVTO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          MOVTO-PERI-RENOVACAO     PIC S9(004) COMP.*/
        public IntBasis MOVTO_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          MOVTO-COD-OPER           PIC S9(004) COMP.*/
        public IntBasis MOVTO_COD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          PRDVG-ESTR-EMISS         PIC X(010).*/
        public StringBasis PRDVG_ESTR_EMISS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          PRDVG-ORIG-PRODU         PIC X(010).*/
        public StringBasis PRDVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          SEGUVG-SITUACAO          PIC X(01).*/
        public StringBasis SEGUVG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01          SISTEMA-DTMOVABE         PIC X(10).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01          SISTEMA-DTCURRENT        PIC X(010).*/
        public StringBasis SISTEMA_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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

        /*"    05      IND-TAB                    PIC S9(004) COMP.*/
        public IntBasis IND_TAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    05      IND-CARGA                  PIC S9(004) COMP.*/
        public IntBasis IND_CARGA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    05      CONT-LIDOS-MOVIMENTO       PIC 9(005) COMP.*/
        public IntBasis CONT_LIDOS_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"    05      CONT-GRAVADOS-V0RELATORIOS PIC S9(004) COMP.*/
        public IntBasis CONT_GRAVADOS_V0RELATORIOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    05      WABEND.*/
        public VG0410B_WABEND WABEND { get; set; } = new VG0410B_WABEND();
        public class VG0410B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'VG0410B  '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VG0410B  ");
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
        public VG0410B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VG0410B_LOCALIZA_ABEND_1();
        public class VG0410B_LOCALIZA_ABEND_1 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
            /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"    05      LOCALIZA-ABEND-2.*/
        }
        public VG0410B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VG0410B_LOCALIZA_ABEND_2();
        public class VG0410B_LOCALIZA_ABEND_2 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
            /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
            public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
        }


        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VG0410B_MOVIMENTO MOVIMENTO { get; set; } = new VG0410B_MOVIMENTO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PROCEDURE-SECTION */

                M_0000_PROCEDURE_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PROCEDURE-SECTION */
        private void M_0000_PROCEDURE_SECTION()
        {
            /*" -239- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -241- MOVE 'SELECT... FROM SEGUROS.V1SISTEMA' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1SISTEMA", LOCALIZA_ABEND_2.COMANDO);

            /*" -242- DISPLAY ' ' */
            _.Display($" ");

            /*" -244- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -252- DISPLAY 'PROGRAMA EM EXECUCAO VG0410B-' 'VERSAO V.08 - DEMANDA 259990 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VG0410B-VERSAO V.08 - DEMANDA 259990 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -254- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -259- DISPLAY ' ' */
            _.Display($" ");

            /*" -264- PERFORM M_0000_PROCEDURE_DB_SELECT_1 */

            M_0000_PROCEDURE_DB_SELECT_1();

            /*" -267- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -269- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -291- PERFORM M_0000_PROCEDURE_DB_DECLARE_1 */

            M_0000_PROCEDURE_DB_DECLARE_1();

            /*" -294- MOVE 'OPEN ...  FROM SEGUROS.V1MOVIMENTO' TO COMANDO. */
            _.Move("OPEN ...  FROM SEGUROS.V1MOVIMENTO", LOCALIZA_ABEND_2.COMANDO);

            /*" -294- PERFORM M_0000_PROCEDURE_DB_OPEN_1 */

            M_0000_PROCEDURE_DB_OPEN_1();

            /*" -297- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -299- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -301- PERFORM 0010-ACESSA-MOVIMENTO. */

            M_0010_ACESSA_MOVIMENTO_SECTION();

            /*" -303- PERFORM 0020-PROCESSA-MOVIMENTO UNTIL FIM-MOVIMENTO. */

            while (!(FLAG_FIM_MOVIMENTO["FIM_MOVIMENTO"]))
            {

                M_0020_PROCESSA_MOVIMENTO_SECTION();
            }

            /*" -304- IF HOUVE-MOVIMENTO */

            if (FLAG_EXISTE_MOV["HOUVE_MOVIMENTO"])
            {

                /*" -306- DISPLAY 'VG0410B - CERTIFICADOS A EMITIR = ' CONT-LIDOS-MOVIMENTO */
                _.Display($"VG0410B - CERTIFICADOS A EMITIR = {CONT_LIDOS_MOVIMENTO}");

                /*" -307- ELSE */
            }
            else
            {


                /*" -309- DISPLAY 'VG0410B - NENHUM REGISTRO FOI SELECIONADO' . */
                _.Display($"VG0410B - NENHUM REGISTRO FOI SELECIONADO");
            }


            /*" -310- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -311- MOVE 'CLOSE...  FROM SEGUROS.V1MOVIMENTO' TO COMANDO. */
            _.Move("CLOSE...  FROM SEGUROS.V1MOVIMENTO", LOCALIZA_ABEND_2.COMANDO);

            /*" -311- PERFORM M_0000_PROCEDURE_DB_CLOSE_1 */

            M_0000_PROCEDURE_DB_CLOSE_1();

            /*" -314- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -316- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -316- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -320- DISPLAY 'FIM NORMAL      **** VG0410B ****' . */
            _.Display($"FIM NORMAL      **** VG0410B ****");

            /*" -322- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -322- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PROCEDURE-DB-SELECT-1 */
        public void M_0000_PROCEDURE_DB_SELECT_1()
        {
            /*" -264- EXEC SQL SELECT DTMOVABE INTO :SISTEMA-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC. */

            var m_0000_PROCEDURE_DB_SELECT_1_Query1 = new M_0000_PROCEDURE_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PROCEDURE_DB_SELECT_1_Query1.Execute(m_0000_PROCEDURE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-0000-PROCEDURE-DB-DECLARE-1 */
        public void M_0000_PROCEDURE_DB_DECLARE_1()
        {
            /*" -291- EXEC SQL DECLARE MOVIMENTO CURSOR FOR SELECT DISTINCT NUM_APOLICE, COD_SUBGRUPO, NUM_CERTIFICADO, COD_USUARIO, COD_OPERACAO FROM SEGUROS.V1MOVIMENTO WHERE DATA_INCLUSAO = :SISTEMA-DTMOVABE AND NUM_APOLICE <> 97010000889 AND ((COD_OPERACAO BETWEEN 100 AND 299) OR (COD_OPERACAO BETWEEN 700 AND 899)) AND COD_OPERACAO <> 0103 AND COD_USUARIO NOT IN ( 'VA0601B' , 'VP0601B' , 'VG1613B' ) ORDER BY NUM_APOLICE, COD_SUBGRUPO, NUM_CERTIFICADO, COD_USUARIO, COD_OPERACAO WITH UR END-EXEC. */
            MOVIMENTO = new VG0410B_MOVIMENTO(true);
            string GetQuery_MOVIMENTO()
            {
                var query = @$"SELECT DISTINCT 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_CERTIFICADO
							, 
							COD_USUARIO
							, 
							COD_OPERACAO 
							FROM SEGUROS.V1MOVIMENTO 
							WHERE DATA_INCLUSAO = '{SISTEMA_DTMOVABE}' 
							AND NUM_APOLICE <> 97010000889 
							AND ((COD_OPERACAO BETWEEN 100 AND 299) OR 
							(COD_OPERACAO BETWEEN 700 AND 899)) 
							AND COD_OPERACAO <> 0103 
							AND COD_USUARIO NOT IN ( 'VA0601B'
							, 'VP0601B'
							, 
							'VG1613B' ) 
							ORDER BY NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_CERTIFICADO
							, 
							COD_USUARIO
							, 
							COD_OPERACAO";

                return query;
            }
            MOVIMENTO.GetQueryEvent += GetQuery_MOVIMENTO;

        }

        [StopWatch]
        /*" M-0000-PROCEDURE-DB-OPEN-1 */
        public void M_0000_PROCEDURE_DB_OPEN_1()
        {
            /*" -294- EXEC SQL OPEN MOVIMENTO END-EXEC. */

            MOVIMENTO.Open();

        }

        [StopWatch]
        /*" M-0000-PROCEDURE-DB-CLOSE-1 */
        public void M_0000_PROCEDURE_DB_CLOSE_1()
        {
            /*" -311- EXEC SQL CLOSE MOVIMENTO END-EXEC. */

            MOVIMENTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_EXIT*/

        [StopWatch]
        /*" M-0010-ACESSA-MOVIMENTO-SECTION */
        private void M_0010_ACESSA_MOVIMENTO_SECTION()
        {
            /*" -328- MOVE '0010-ACESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("0010-ACESSA-MOVIMENTO", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -330- MOVE 'FETCH...  FROM SEGUROS.V1MOVIMENTO' TO COMANDO. */
            _.Move("FETCH...  FROM SEGUROS.V1MOVIMENTO", LOCALIZA_ABEND_2.COMANDO);

            /*" -336- PERFORM M_0010_ACESSA_MOVIMENTO_DB_FETCH_1 */

            M_0010_ACESSA_MOVIMENTO_DB_FETCH_1();

            /*" -339- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -340- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -341- MOVE 1 TO FLAG-FIM-MOVIMENTO */
                    _.Move(1, FLAG_FIM_MOVIMENTO);

                    /*" -342- GO TO 0010-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_EXIT*/ //GOTO
                    return;

                    /*" -343- ELSE */
                }
                else
                {


                    /*" -345- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -346- MOVE '0015-ACESSA-PRODUTOS_VG' TO PARAGRAFO. */
            _.Move("0015-ACESSA-PRODUTOS_VG", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -348- MOVE 'FETCH...  FROM SEGUROS.PRODUTO_VG' TO COMANDO. */
            _.Move("FETCH...  FROM SEGUROS.PRODUTO_VG", LOCALIZA_ABEND_2.COMANDO);

            /*" -357- PERFORM M_0010_ACESSA_MOVIMENTO_DB_SELECT_1 */

            M_0010_ACESSA_MOVIMENTO_DB_SELECT_1();

            /*" -360- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -362- IF SQLCODE EQUAL +100 OR PRDVG-ESTR-EMISS-W LESS ZEROS */

                if (DB.SQLCODE == +100 || PRDVG_ESTR_EMISS_W < 00)
                {

                    /*" -364- MOVE SPACES TO PRDVG-ESTR-EMISS PRDVG-ORIG-PRODU */
                    _.Move("", PRDVG_ESTR_EMISS, PRDVG_ORIG_PRODU);

                    /*" -365- ELSE */
                }
                else
                {


                    /*" -367- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -400- IF (MOVTO-NUM-APOLICE = 93010000890 AND MOVTO-COD-OPER = 891) OR MOVTO-COD-OPER = 796 OR MOVTO-COD-OPER = 896 OR (PRDVG-ESTR-EMISS = 'MULT ' AND PRDVG-ORIG-PRODU = 'MULT ' AND MOVTO-COD-OPER <= 299) OR (MOVTO-NUM-APOLICE = 0109300000559 AND MOVTO-COD-OPER < 200) OR (MOVTO-NUM-APOLICE = 0109300000008 AND MOVTO-COD-OPER = 891) OR (MOVTO-NUM-APOLICE = 0109300000027 AND MOVTO-COD-OPER < 300) OR (MOVTO-NUM-APOLICE = 0109300000531) OR (MOVTO-NUM-APOLICE = 0109300000586) OR (MOVTO-NUM-APOLICE = 0109300000550) OR (MOVTO-NUM-APOLICE = 0093605000853) OR (MOVTO-NUM-APOLICE = 0109300000645) OR (MOVTO-NUM-APOLICE = 0107700000003) OR (MOVTO-NUM-APOLICE = 0108207548015) OR (MOVTO-NUM-APOLICE = 0108207553052) OR (MOVTO-NUM-APOLICE = 0107700000005) OR (MOVTO-NUM-APOLICE = 0109300000680 AND MOVTO-COD-OPER < 200) OR (MOVTO-COD-USUARIO = 'VA1184B' ) */

            if ((MOVTO_NUM_APOLICE == 93010000890 && MOVTO_COD_OPER == 891) || MOVTO_COD_OPER == 796 || MOVTO_COD_OPER == 896 || (PRDVG_ESTR_EMISS == "MULT " && PRDVG_ORIG_PRODU == "MULT " && MOVTO_COD_OPER <= 299) || (MOVTO_NUM_APOLICE == 0109300000559 && MOVTO_COD_OPER < 200) || (MOVTO_NUM_APOLICE == 0109300000008 && MOVTO_COD_OPER == 891) || (MOVTO_NUM_APOLICE == 0109300000027 && MOVTO_COD_OPER < 300) || (MOVTO_NUM_APOLICE == 0109300000531) || (MOVTO_NUM_APOLICE == 0109300000586) || (MOVTO_NUM_APOLICE == 0109300000550) || (MOVTO_NUM_APOLICE == 0093605000853) || (MOVTO_NUM_APOLICE == 0109300000645) || (MOVTO_NUM_APOLICE == 0107700000003) || (MOVTO_NUM_APOLICE == 0108207548015) || (MOVTO_NUM_APOLICE == 0108207553052) || (MOVTO_NUM_APOLICE == 0107700000005) || (MOVTO_NUM_APOLICE == 0109300000680 && MOVTO_COD_OPER < 200) || (MOVTO_COD_USUARIO == "VA1184B"))
            {

                /*" -403- GO TO 0010-ACESSA-MOVIMENTO. */
                new Task(() => M_0010_ACESSA_MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -404- ADD 1 TO CONT-LIDOS-MOVIMENTO */
            CONT_LIDOS_MOVIMENTO.Value = CONT_LIDOS_MOVIMENTO + 1;

            /*" -413- MOVE 1 TO FLAG-EXISTE-MOV */
            _.Move(1, FLAG_EXISTE_MOV);

            /*" -415- MOVE 'SELECT..  FROM SEGUROS.V1SEGURAVG ' TO COMANDO. */
            _.Move("SELECT..  FROM SEGUROS.V1SEGURAVG ", LOCALIZA_ABEND_2.COMANDO);

            /*" -422- PERFORM M_0010_ACESSA_MOVIMENTO_DB_SELECT_2 */

            M_0010_ACESSA_MOVIMENTO_DB_SELECT_2();

            /*" -426- IF SQLCODE EQUAL ZEROS NEXT SENTENCE */

            if (DB.SQLCODE == 00)
            {

                /*" -427- ELSE */
            }
            else
            {


                /*" -428- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -429- GO TO 0010-ACESSA-MOVIMENTO */
                    new Task(() => M_0010_ACESSA_MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -430- ELSE */
                }
                else
                {


                    /*" -430- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0010-ACESSA-MOVIMENTO-DB-FETCH-1 */
        public void M_0010_ACESSA_MOVIMENTO_DB_FETCH_1()
        {
            /*" -336- EXEC SQL FETCH MOVIMENTO INTO :MOVTO-NUM-APOLICE, :MOVTO-COD-SUBES, :MOVTO-NUM-CERTIFIC, :MOVTO-COD-USUARIO, :MOVTO-COD-OPER END-EXEC. */

            if (MOVIMENTO.Fetch())
            {
                _.Move(MOVIMENTO.MOVTO_NUM_APOLICE, MOVTO_NUM_APOLICE);
                _.Move(MOVIMENTO.MOVTO_COD_SUBES, MOVTO_COD_SUBES);
                _.Move(MOVIMENTO.MOVTO_NUM_CERTIFIC, MOVTO_NUM_CERTIFIC);
                _.Move(MOVIMENTO.MOVTO_COD_USUARIO, MOVTO_COD_USUARIO);
                _.Move(MOVIMENTO.MOVTO_COD_OPER, MOVTO_COD_OPER);
            }

        }

        [StopWatch]
        /*" M-0010-ACESSA-MOVIMENTO-DB-SELECT-1 */
        public void M_0010_ACESSA_MOVIMENTO_DB_SELECT_1()
        {
            /*" -357- EXEC SQL SELECT ESTR_EMISS, ORIG_PRODU INTO :PRDVG-ESTR-EMISS:PRDVG-ESTR-EMISS-W, :PRDVG-ORIG-PRODU FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :MOVTO-NUM-APOLICE AND COD_SUBGRUPO = :MOVTO-COD-SUBES WITH UR END-EXEC. */

            var m_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1 = new M_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1()
            {
                MOVTO_NUM_APOLICE = MOVTO_NUM_APOLICE.ToString(),
                MOVTO_COD_SUBES = MOVTO_COD_SUBES.ToString(),
            };

            var executed_1 = M_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1.Execute(m_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDVG_ESTR_EMISS, PRDVG_ESTR_EMISS);
                _.Move(executed_1.PRDVG_ESTR_EMISS_W, PRDVG_ESTR_EMISS_W);
                _.Move(executed_1.PRDVG_ORIG_PRODU, PRDVG_ORIG_PRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_EXIT*/

        [StopWatch]
        /*" M-0010-ACESSA-MOVIMENTO-DB-SELECT-2 */
        public void M_0010_ACESSA_MOVIMENTO_DB_SELECT_2()
        {
            /*" -422- EXEC SQL SELECT SIT_REGISTRO INTO :SEGUVG-SITUACAO FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :MOVTO-NUM-CERTIFIC AND TIPO_SEGURADO = '1' AND SIT_REGISTRO IN ( '0' , '1' ) WITH UR END-EXEC. */

            var m_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1 = new M_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1()
            {
                MOVTO_NUM_CERTIFIC = MOVTO_NUM_CERTIFIC.ToString(),
            };

            var executed_1 = M_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1.Execute(m_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGUVG_SITUACAO, SEGUVG_SITUACAO);
            }


        }

        [StopWatch]
        /*" M-0020-PROCESSA-MOVIMENTO-SECTION */
        private void M_0020_PROCESSA_MOVIMENTO_SECTION()
        {
            /*" -437- PERFORM 0090-INCLUI-DADOS-V0RELATORIOS. */

            M_0090_INCLUI_DADOS_V0RELATORIOS_SECTION();

            /*" -437- PERFORM 0010-ACESSA-MOVIMENTO. */

            M_0010_ACESSA_MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_EXIT*/

        [StopWatch]
        /*" M-0090-INCLUI-DADOS-V0RELATORIOS-SECTION */
        private void M_0090_INCLUI_DADOS_V0RELATORIOS_SECTION()
        {
            /*" -452- PERFORM M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1 */

            M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1();

            /*" -455- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -456- IF RELAT-CODRELAT-I LESS ZEROS */

                if (RELAT_CODRELAT_I < 00)
                {

                    /*" -457- MOVE 'VG0410B' TO RELAT-CODRELAT */
                    _.Move("VG0410B", RELAT_CODRELAT);

                    /*" -458- MOVE 'VG' TO RELAT-IDSISTEM */
                    _.Move("VG", RELAT_IDSISTEM);

                    /*" -460- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -461- ELSE */
                }

            }
            else
            {


                /*" -462- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -463- MOVE 'VG0410B' TO RELAT-CODRELAT */
                    _.Move("VG0410B", RELAT_CODRELAT);

                    /*" -464- MOVE 'VG' TO RELAT-IDSISTEM */
                    _.Move("VG", RELAT_IDSISTEM);

                    /*" -465- ELSE */
                }
                else
                {


                    /*" -466- MOVE 'VG0410B' TO RELAT-CODRELAT */
                    _.Move("VG0410B", RELAT_CODRELAT);

                    /*" -468- MOVE 'VG' TO RELAT-IDSISTEM. */
                    _.Move("VG", RELAT_IDSISTEM);
                }

            }


            /*" -469- MOVE '0090-INCLUI-DADOS-V0RELATORIOS' TO PARAGRAFO */
            _.Move("0090-INCLUI-DADOS-V0RELATORIOS", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -470- MOVE 'SELECT COBRANCA_MENS_VGAP' TO COMANDO */
            _.Move("SELECT COBRANCA_MENS_VGAP", LOCALIZA_ABEND_2.COMANDO);

            /*" -481- PERFORM M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2 */

            M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2();

            /*" -483- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -484- IF MOVTO-COD-USUARIO EQUAL 'VA0130B' */

                if (MOVTO_COD_USUARIO == "VA0130B")
                {

                    /*" -485- MOVE 10 TO RELAT-OPERACAO */
                    _.Move(10, RELAT_OPERACAO);

                    /*" -486- MOVE 2 TO RELAT-NRPARCEL */
                    _.Move(2, RELAT_NRPARCEL);

                    /*" -487- ELSE */
                }
                else
                {


                    /*" -489- MOVE 2 TO RELAT-OPERACAO RELAT-NRPARCEL */
                    _.Move(2, RELAT_OPERACAO, RELAT_NRPARCEL);

                    /*" -490- ELSE */
                }

            }
            else
            {


                /*" -493- MOVE ZEROS TO RELAT-OPERACAO RELAT-NRPARCEL. */
                _.Move(0, RELAT_OPERACAO, RELAT_NRPARCEL);
            }


            /*" -494- IF MOVTO-NUM-APOLICE = 0109300000672 */

            if (MOVTO_NUM_APOLICE == 0109300000672)
            {

                /*" -495- MOVE 'X' TO RELAT-SITUACAO */
                _.Move("X", RELAT_SITUACAO);

                /*" -496- ELSE */
            }
            else
            {


                /*" -498- MOVE '0' TO RELAT-SITUACAO. */
                _.Move("0", RELAT_SITUACAO);
            }


            /*" -541- PERFORM M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1 */

            M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1();

            /*" -544- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -545- ADD 1 TO CONT-GRAVADOS-V0RELATORIOS */
                CONT_GRAVADOS_V0RELATORIOS.Value = CONT_GRAVADOS_V0RELATORIOS + 1;

                /*" -546- ELSE */
            }
            else
            {


                /*" -546- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0090-INCLUI-DADOS-V0RELATORIOS-DB-SELECT-1 */
        public void M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -452- EXEC SQL SELECT CODRELAT, IDSISTEM INTO :RELAT-CODRELAT:RELAT-CODRELAT-I, :RELAT-IDSISTEM FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :MOVTO-NUM-APOLICE AND CODSUBES = :MOVTO-COD-SUBES WITH UR END-EXEC. */

            var m_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1 = new M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1()
            {
                MOVTO_NUM_APOLICE = MOVTO_NUM_APOLICE.ToString(),
                MOVTO_COD_SUBES = MOVTO_COD_SUBES.ToString(),
            };

            var executed_1 = M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1.Execute(m_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELAT_CODRELAT, RELAT_CODRELAT);
                _.Move(executed_1.RELAT_CODRELAT_I, RELAT_CODRELAT_I);
                _.Move(executed_1.RELAT_IDSISTEM, RELAT_IDSISTEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0090_EXIT*/

        [StopWatch]
        /*" M-0090-INCLUI-DADOS-V0RELATORIOS-DB-INSERT-1 */
        public void M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1()
        {
            /*" -541- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:MOVTO-COD-USUARIO, :SISTEMA-DTMOVABE, :RELAT-IDSISTEM, :RELAT-CODRELAT, 0, 0, :SISTEMA-DTMOVABE, :SISTEMA-DTMOVABE, :SISTEMA-DTMOVABE, 0, 0, 0, 0, 0, 0, 0, 0, :MOVTO-NUM-APOLICE, 0, :RELAT-NRPARCEL, :MOVTO-NUM-CERTIFIC, 0, :MOVTO-COD-SUBES, :RELAT-OPERACAO, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , :RELAT-SITUACAO, ' ' , ' ' , NULL, NULL, NULL, CURRENT TIMESTAMP) END-EXEC. */

            var m_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1 = new M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1()
            {
                MOVTO_COD_USUARIO = MOVTO_COD_USUARIO.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                RELAT_IDSISTEM = RELAT_IDSISTEM.ToString(),
                RELAT_CODRELAT = RELAT_CODRELAT.ToString(),
                MOVTO_NUM_APOLICE = MOVTO_NUM_APOLICE.ToString(),
                RELAT_NRPARCEL = RELAT_NRPARCEL.ToString(),
                MOVTO_NUM_CERTIFIC = MOVTO_NUM_CERTIFIC.ToString(),
                MOVTO_COD_SUBES = MOVTO_COD_SUBES.ToString(),
                RELAT_OPERACAO = RELAT_OPERACAO.ToString(),
                RELAT_SITUACAO = RELAT_SITUACAO.ToString(),
            };

            M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1.Execute(m_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0090-INCLUI-DADOS-V0RELATORIOS-DB-SELECT-2 */
        public void M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2()
        {
            /*" -481- EXEC SQL SELECT NUM_APOLICE, CODSUBES INTO :RELAT-NUM-APOLICE, :RELAT-COD-SUBES FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A4' AND NUM_APOLICE = :MOVTO-NUM-APOLICE AND CODSUBES = :MOVTO-COD-SUBES AND COD_OPERACAO = 2 WITH UR END-EXEC */

            var m_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1 = new M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1()
            {
                MOVTO_NUM_APOLICE = MOVTO_NUM_APOLICE.ToString(),
                MOVTO_COD_SUBES = MOVTO_COD_SUBES.ToString(),
            };

            var executed_1 = M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1.Execute(m_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELAT_NUM_APOLICE, RELAT_NUM_APOLICE);
                _.Move(executed_1.RELAT_COD_SUBES, RELAT_COD_SUBES);
            }


        }

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -556- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -557- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -558- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -559- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -560- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(LOCALIZA_ABEND_1);

            /*" -562- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(LOCALIZA_ABEND_2);

            /*" -562- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -564- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -567- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -567- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}