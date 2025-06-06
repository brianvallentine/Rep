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
using Sias.Emissao.DB2.EM0135B;

namespace Code
{
    public class EM0135B
    {
        public bool IsCall { get; set; }

        public EM0135B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    DECLARA RESTITUICOES PENDENTES DE PAGAMENTO (AUTO)          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *               A L T E R A C O E S                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * DIEGO DIAS        - 13/05/2013        PROCURAR V.08            *      */
        /*"      *                                                                *      */
        /*"      *    FORCAR O PAGAMENTO VIA CHEQUE PARA O SEGURADO               *      */
        /*"      *   APOLICE - 1103100161899 ENDOSSO - 1                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VIVIANE FONSECA   - 04/03/2013        PROCURAR V.07            *      */
        /*"      *                                                                *      */
        /*"      *    FORCAR O PAGAMENTO VIA CHEQUE PARA O SEGURADO               *      */
        /*"      *   APOLICE - 1103100121720 ENDOSSO - 2                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      * viviane fonseca   - 23/11/2012        PROCURAR V.06            *      */
        /*"      *                                                                *      */
        /*"      *    segurar o credito na conta do Segurado                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * GUILHERME CORREIA - 09/11/2012        PROCURAR V.05            *      */
        /*"      *                                                                *      */
        /*"      *    APOLICE CANCELADA POR EMISSAO INDEVIDA, NOVA APOLICE FOI    *      */
        /*"      *    GERADA, RESTITUICAO NAO DEVE SER CREDITADA.                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   RILDO SICO    - 10/09/2012            PROCURAR V.04          *      */
        /*"      *                                                                *      */
        /*"      *       PROCESSAMENTO ESPECIAL PARA AS APOLICE/ENDOSSO ABAIXO    *      */
        /*"      *       FORCADA A GERACAO DO CHEQUE PARA ATENDER O CADMUS 73481. *      */
        /*"      *                                                                *      */
        /*"      *   APOLICE - 1103100100698 ENDOSSO - 1                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03                                                           */
        /*"      *               ALTERACAO PARA AJUSTE DE ACEITACAO DE VALOR PAGO *      */
        /*"      *               MAIOR OU IGUAL PARA O PRODUTO AUTO SULAMERICA    *      */
        /*"      *               ONDE O PREMIO PAGO EH O PREMIO TOTAL PAGO        *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/11/2011 - VIVIANE A FONSECA        PROCURE POR V.03    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * HEIDER COELHO - 21/01/2011                 PROCURAR V.02       *      */
        /*"      *   AJUSTE DA CONSULTA DA MOVDEBCC COM SITUACAO_COBRANCA         *      */
        /*"      *   ' ' - PENDENTE DE ENVIO AO SAP / BANCO                       *      */
        /*"      *   '1' - PENDENTE DE RETORNO AO SAP / BANCO                     *      */
        /*"      *   '2' - CREDITO / DEBITO REALIZADO COM SUCESSO                 *      */
        /*"      *   '3' - CREDITO / DEBITO REJEITADO PELO BANCO                  *      */
        /*"      *         EM TESE ESTE MOVIMENTO, AUTOMATICAMENTE, VIRA CHEQUE   *      */
        /*"      *         ESTE � O CONCEITO DO PROJETO REDUCAO DE CHEQUE         *      */
        /*"      *         NO CASO DA SUL AMERICA, PARECE QUE A ROTINA FAZ O      *      */
        /*"      *         ESTORNO DO CREDITO / DEBITO. A CONFERIR                *      */
        /*"      *   '6' - CANCELADO A PEDIDO DO USUARIO. NEM FOI PARA O SAP/BCO  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01                                                           */
        /*"      *               ALTERACAO PARA AJUSTE CONFORME NECESSIDADES DO   *      */
        /*"      *               PROJETO DE REDUCAO DE CHEQUES, PARA VERIFICACAO  *      */
        /*"      *               DE RESTITUICAO JA CADASTRADA NA TABELA           *      */
        /*"      *               MOVDEBCC_CEF A EMISSAO DO CHEQUE SEJA IGNORADA   *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/03/2008 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"SAS01 * PROJETO PROJAUTO (SULAMERICA) - BRSEG - 01/06/2011             *      */
        /*"SAS01 * - INCLUSAO DO ORGAO 110                                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 10/06/2008   INIBIR O COMANDO DISPLAY               - WV0608   *      */
        /*"      * 17/09/2008   INIBIR O COMANDO DISPLAY               - WV0908   *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         WHOST-APOL-FX-INI   PIC S9(013)    VALUE +0 COMP-3.*/
        public IntBasis WHOST_APOL_FX_INI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         WHOST-APOL-FX-FIM   PIC S9(013)    VALUE +0 COMP-3.*/
        public IntBasis WHOST_APOL_FX_FIM { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         WHOST-ORGAO         PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010)    VALUE  SPACES.*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V0EDIA-CODRELAT     PIC  X(008)    VALUE  SPACES.*/
        public StringBasis V0EDIA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77         V0EDIA-NUM-APOL     PIC S9(013)    VALUE +0    COMP-3*/
        public IntBasis V0EDIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0EDIA-NRENDOS      PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0EDIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0EDIA-NRPARCEL     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V0EDIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-DTMOVTO      PIC  X(010)    VALUE  SPACES.*/
        public StringBasis V0EDIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V0EDIA-ORGAO        PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V0EDIA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-RAMO         PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V0EDIA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-FONTE        PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V0EDIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-CONGENER     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V0EDIA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-CODCORR      PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0EDIA_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0EDIA-SITUACAO     PIC  X(001)    VALUE  SPACES.*/
        public StringBasis V0EDIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V0EDIA-COD-EMP      PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V0EDIA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HISP-DATA-VENCTO  PIC  X(010)    VALUE  SPACES.*/
        public StringBasis V1HISP_DATA_VENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1PARC-PREMIO-PAGO  PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V1PARC_PREMIO_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-PREMIO-REST  PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V1PARC_PREMIO_REST { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-PREMIO-PEND  PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V1PARC_PREMIO_PEND { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-PREMIO-DIFE  PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V1PARC_PREMIO_DIFE { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PARC-PREMIO-ARES  PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V1PARC_PREMIO_ARES { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01           AREA-DE-WORK.*/
        public EM0135B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new EM0135B_AREA_DE_WORK();
        public class EM0135B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WZEROS               PIC S9(003)    VALUE +0 COMP-3*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         WS1-STATUS           PIC  X(002)    VALUE '00'.*/
            public StringBasis WS1_STATUS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"00");
            /*"  05         WS-TEM-MOVDEBCC      PIC  X(001)    VALUE  'N'.*/
            public StringBasis WS_TEM_MOVDEBCC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05         WFIM-ENDOSSOS        PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WFIM_ENDOSSOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WMENSAGEM            PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WMENSAGEM { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05         WS-QTD-REG-LID       PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_QTD_REG_LID { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-LID-110           PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_LID_110 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-REJ-110           PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_REJ_110 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-INS-110           PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_INS_110 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-QTD-REG-REJ       PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_QTD_REG_REJ { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-QTD-REG-INS       PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_QTD_REG_INS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WPREMIO-PAGO         PIC  Z.ZZZ.ZZ9,99-.*/
            public DoubleBasis WPREMIO_PAGO { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99-."), 3);
            /*"  05         WPREMIO-REST         PIC  Z.ZZZ.ZZ9,99-.*/
            public DoubleBasis WPREMIO_REST { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99-."), 3);
            /*"  05         WPREMIO-PEND         PIC  Z.ZZZ.ZZ9,99-.*/
            public DoubleBasis WPREMIO_PEND { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99-."), 3);
            /*"  05         WPREMIO-DIFE         PIC  Z.ZZZ.ZZ9,99-.*/
            public DoubleBasis WPREMIO_DIFE { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99-."), 3);
            /*"  05         WPREMIO-ARES         PIC  Z.ZZZ.ZZ9,99-.*/
            public DoubleBasis WPREMIO_ARES { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99-."), 3);
            /*"  05         WABEND.*/
            public EM0135B_WABEND WABEND { get; set; } = new EM0135B_WABEND();
            public class EM0135B_WABEND : VarBasis
            {
                /*"    10       FILLER              PIC X(010) VALUE            ' EM0135B'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM0135B");
                /*"    10       FILLER              PIC X(026) VALUE            ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10       WNR-EXEC-SQL        PIC X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10       FILLER              PIC X(013) VALUE            ' *** SQLCODE '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10       WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"  05         WS-DATA-ACCEPT.*/
            }
            public EM0135B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new EM0135B_WS_DATA_ACCEPT();
            public class EM0135B_WS_DATA_ACCEPT : VarBasis
            {
                /*"    10       WS-ANO-ACCEPT     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-MES-ACCEPT     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-DIA-ACCEPT     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-HORA-ACCEPT.*/
            }
            public EM0135B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new EM0135B_WS_HORA_ACCEPT();
            public class EM0135B_WS_HORA_ACCEPT : VarBasis
            {
                /*"    10       WS-HOR-ACCEPT     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-MIN-ACCEPT     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-SEG-ACCEPT     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-DATA-CURR.*/
            }
            public EM0135B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new EM0135B_WS_DATA_CURR();
            public class EM0135B_WS_DATA_CURR : VarBasis
            {
                /*"    10       WS-DIA-CURR       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-MES-CURR       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-ANO-CURR       PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WS-HORA-CURR.*/
            }
            public EM0135B_WS_HORA_CURR WS_HORA_CURR { get; set; } = new EM0135B_WS_HORA_CURR();
            public class EM0135B_WS_HORA_CURR : VarBasis
            {
                /*"    10       WS-HOR-CURR       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-MIN-CURR       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-SEG-CURR       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            }
        }


        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public EM0135B_C01_ENDOSSOS C01_ENDOSSOS { get; set; } = new EM0135B_C01_ENDOSSOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -181- MOVE '0001' TO WNR-EXEC-SQL. */
                _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -181- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -182- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -183- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -187- PERFORM R0050-00-INICIO */

                R0050_00_INICIO_SECTION();

                /*" -188- PERFORM R0100-00-SELECT-SISTEMAS */

                R0100_00_SELECT_SISTEMAS_SECTION();

                /*" -190- PERFORM R1000-00-PROCESSO-PRINCIPAL */

                R1000_00_PROCESSO_PRINCIPAL_SECTION();

                /*" -191- PERFORM R9950-00-FIM */

                R9950_00_FIM_SECTION();

                /*" -192- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -192- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -195- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -206- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -211- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -214- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -215- DISPLAY 'R0100 - PROBLEMAS SELECT SISTEMAS' */
                _.Display($"R0100 - PROBLEMAS SELECT SISTEMAS");

                /*" -215- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -211- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -227- MOVE '00/00/0000' TO WS-DATA-CURR */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_CURR);

            /*" -228- ACCEPT WS-DATA-ACCEPT FROM DATE */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WS_DATA_ACCEPT);

            /*" -229- MOVE WS-DIA-ACCEPT TO WS-DIA-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_DIA_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_DIA_CURR);

            /*" -230- MOVE WS-MES-ACCEPT TO WS-MES-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_MES_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_MES_CURR);

            /*" -231- MOVE WS-ANO-ACCEPT TO WS-ANO-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_ANO_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR);

            /*" -233- ADD 2000 TO WS-ANO-CURR */
            AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR.Value = AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR + 2000;

            /*" -234- MOVE '00:00:00' TO WS-HORA-CURR */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_CURR);

            /*" -235- ACCEPT WS-HORA-ACCEPT FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -236- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_HOR_CURR);

            /*" -237- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_MIN_CURR);

            /*" -239- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_SEG_CURR);

            /*" -240- DISPLAY '-----------------------------------' */
            _.Display($"-----------------------------------");

            /*" -241- DISPLAY '            EM0135B                ' */
            _.Display($"            EM0135B                ");

            /*" -242- DISPLAY ' VERSAO V.4 - CAD 73481            ' */
            _.Display($" VERSAO V.4 - CAD 73481            ");

            /*" -243- DISPLAY ' EM 10/09/2012                     ' */
            _.Display($" EM 10/09/2012                     ");

            /*" -244- DISPLAY '                                   ' */
            _.Display($"                                   ");

            /*" -245- DISPLAY '-----------------------------------' */
            _.Display($"-----------------------------------");

            /*" -246- DISPLAY '                                   ' */
            _.Display($"                                   ");

            /*" -247- DISPLAY 'EM0135B - INICIO DO PROCESSAMENTO (' WS-DATA-CURR ' - ' WS-HORA-CURR ')' . */

            $"EM0135B - INICIO DO PROCESSAMENTO ({AREA_DE_WORK.WS_DATA_CURR} - {AREA_DE_WORK.WS_HORA_CURR})"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSO-PRINCIPAL-SECTION */
        private void R1000_00_PROCESSO_PRINCIPAL_SECTION()
        {
            /*" -260- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -267- DISPLAY 'APOLICE       ENDOSSO     VALOR PAGO    RESTITUIDO' '      PENDENTE     DIFERENCA   A RESTITUIR' */
            _.Display($"APOLICE       ENDOSSO     VALOR PAGO    RESTITUIDO      PENDENTE     DIFERENCA   A RESTITUIR");

            /*" -268- MOVE 1003100000000 TO WHOST-APOL-FX-INI */
            _.Move(1003100000000, WHOST_APOL_FX_INI);

            /*" -269- MOVE 1003199999999 TO WHOST-APOL-FX-FIM */
            _.Move(1003199999999, WHOST_APOL_FX_FIM);

            /*" -270- MOVE 100 TO WHOST-ORGAO */
            _.Move(100, WHOST_ORGAO);

            /*" -271- MOVE SPACES TO WFIM-ENDOSSOS */
            _.Move("", AREA_DE_WORK.WFIM_ENDOSSOS);

            /*" -272- PERFORM R1100-00-DECLARE-ENDOSSOS */

            R1100_00_DECLARE_ENDOSSOS_SECTION();

            /*" -273- PERFORM R1110-00-FETCH-ENDOSSOS */

            R1110_00_FETCH_ENDOSSOS_SECTION();

            /*" -278- PERFORM R1200-00-PROCESSA-ENDOSSOS UNTIL WFIM-ENDOSSOS NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_ENDOSSOS.IsEmpty()))
            {

                R1200_00_PROCESSA_ENDOSSOS_SECTION();
            }

            /*" -279- MOVE 1103100000000 TO WHOST-APOL-FX-INI */
            _.Move(1103100000000, WHOST_APOL_FX_INI);

            /*" -280- MOVE 1103199999999 TO WHOST-APOL-FX-FIM */
            _.Move(1103199999999, WHOST_APOL_FX_FIM);

            /*" -281- MOVE 110 TO WHOST-ORGAO */
            _.Move(110, WHOST_ORGAO);

            /*" -282- MOVE SPACES TO WFIM-ENDOSSOS */
            _.Move("", AREA_DE_WORK.WFIM_ENDOSSOS);

            /*" -283- PERFORM R1100-00-DECLARE-ENDOSSOS */

            R1100_00_DECLARE_ENDOSSOS_SECTION();

            /*" -284- PERFORM R1110-00-FETCH-ENDOSSOS */

            R1110_00_FETCH_ENDOSSOS_SECTION();

            /*" -285- PERFORM R1200-00-PROCESSA-ENDOSSOS UNTIL WFIM-ENDOSSOS NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_ENDOSSOS.IsEmpty()))
            {

                R1200_00_PROCESSA_ENDOSSOS_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-DECLARE-ENDOSSOS-SECTION */
        private void R1100_00_DECLARE_ENDOSSOS_SECTION()
        {
            /*" -299- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -314- PERFORM R1100_00_DECLARE_ENDOSSOS_DB_DECLARE_1 */

            R1100_00_DECLARE_ENDOSSOS_DB_DECLARE_1();

            /*" -316- PERFORM R1100_00_DECLARE_ENDOSSOS_DB_OPEN_1 */

            R1100_00_DECLARE_ENDOSSOS_DB_OPEN_1();

            /*" -318- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -319- DISPLAY 'ERRO OPEN ENDOSSOS' */
                _.Display($"ERRO OPEN ENDOSSOS");

                /*" -319- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-DECLARE-ENDOSSOS-DB-DECLARE-1 */
        public void R1100_00_DECLARE_ENDOSSOS_DB_DECLARE_1()
        {
            /*" -314- EXEC SQL DECLARE C01_ENDOSSOS CURSOR FOR SELECT B.NUM_APOLICE , B.NUM_ENDOSSO , B.TIPO_ENDOSSO , B.COD_FONTE FROM SEGUROS.APOLICES A , SEGUROS.ENDOSSOS B WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_APOLICE BETWEEN :WHOST-APOL-FX-INI AND :WHOST-APOL-FX-FIM AND B.DATA_EMISSAO <= :V1SIST-DTMOVABE AND B.SIT_REGISTRO = '0' AND A.TIPO_SEGURO = '1' AND A.ORGAO_EMISSOR = :WHOST-ORGAO AND B.TIPO_ENDOSSO IN ( '3' , '5' ) END-EXEC. */
            C01_ENDOSSOS = new EM0135B_C01_ENDOSSOS(true);
            string GetQuery_C01_ENDOSSOS()
            {
                var query = @$"SELECT B.NUM_APOLICE
							, 
							B.NUM_ENDOSSO
							, 
							B.TIPO_ENDOSSO
							, 
							B.COD_FONTE 
							FROM SEGUROS.APOLICES A
							, 
							SEGUROS.ENDOSSOS B 
							WHERE A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.NUM_APOLICE BETWEEN '{WHOST_APOL_FX_INI}' 
							AND '{WHOST_APOL_FX_FIM}' 
							AND B.DATA_EMISSAO <= '{V1SIST_DTMOVABE}' 
							AND B.SIT_REGISTRO = '0' 
							AND A.TIPO_SEGURO = '1' 
							AND A.ORGAO_EMISSOR = '{WHOST_ORGAO}' 
							AND B.TIPO_ENDOSSO IN ( '3'
							, '5' )";

                return query;
            }
            C01_ENDOSSOS.GetQueryEvent += GetQuery_C01_ENDOSSOS;

        }

        [StopWatch]
        /*" R1100-00-DECLARE-ENDOSSOS-DB-OPEN-1 */
        public void R1100_00_DECLARE_ENDOSSOS_DB_OPEN_1()
        {
            /*" -316- EXEC SQL OPEN C01_ENDOSSOS END-EXEC. */

            C01_ENDOSSOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-FETCH-ENDOSSOS-SECTION */
        private void R1110_00_FETCH_ENDOSSOS_SECTION()
        {
            /*" -333- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -338- PERFORM R1110_00_FETCH_ENDOSSOS_DB_FETCH_1 */

            R1110_00_FETCH_ENDOSSOS_DB_FETCH_1();

            /*" -341- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -342- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -342- PERFORM R1110_00_FETCH_ENDOSSOS_DB_CLOSE_1 */

                    R1110_00_FETCH_ENDOSSOS_DB_CLOSE_1();

                    /*" -344- MOVE 'S' TO WFIM-ENDOSSOS */
                    _.Move("S", AREA_DE_WORK.WFIM_ENDOSSOS);

                    /*" -345- GO TO R1110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/ //GOTO
                    return;

                    /*" -346- ELSE */
                }
                else
                {


                    /*" -347- DISPLAY 'ERRO NO FETCH ENDOSSOS' */
                    _.Display($"ERRO NO FETCH ENDOSSOS");

                    /*" -348- DISPLAY 'APOLICE - ' ENDOSSOS-NUM-APOLICE */
                    _.Display($"APOLICE - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                    /*" -349- DISPLAY 'ENDOSSO - ' ENDOSSOS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                    /*" -351- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -395- IF ((ENDOSSOS-NUM-APOLICE EQUAL 1003100005301 AND ENDOSSOS-NUM-ENDOSSO EQUAL 2) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100007489 AND ENDOSSOS-NUM-ENDOSSO EQUAL 2) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100009734 AND ENDOSSOS-NUM-ENDOSSO EQUAL 2) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100023163 AND ENDOSSOS-NUM-ENDOSSO EQUAL 3) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100026556 AND ENDOSSOS-NUM-ENDOSSO EQUAL 2) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100030982 AND ENDOSSOS-NUM-ENDOSSO EQUAL 2) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100031405 AND ENDOSSOS-NUM-ENDOSSO EQUAL 2) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100038836 AND ENDOSSOS-NUM-ENDOSSO EQUAL 2) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100169557 AND ENDOSSOS-NUM-ENDOSSO EQUAL 1) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100139450 AND ENDOSSOS-NUM-ENDOSSO EQUAL 1) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100116519 AND ENDOSSOS-NUM-ENDOSSO EQUAL 1) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100125781 AND ENDOSSOS-NUM-ENDOSSO EQUAL 1) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100149359 AND ENDOSSOS-NUM-ENDOSSO EQUAL 1) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100122441 AND ENDOSSOS-NUM-ENDOSSO EQUAL 1) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100212658 AND ENDOSSOS-NUM-ENDOSSO EQUAL 3) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100259372 AND ENDOSSOS-NUM-ENDOSSO EQUAL 1) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100276856 AND ENDOSSOS-NUM-ENDOSSO EQUAL 3) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100238788 AND ENDOSSOS-NUM-ENDOSSO EQUAL 2) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100240560 AND ENDOSSOS-NUM-ENDOSSO EQUAL 1) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100240560 AND ENDOSSOS-NUM-ENDOSSO EQUAL 3) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100242243 AND ENDOSSOS-NUM-ENDOSSO EQUAL 2) OR (ENDOSSOS-NUM-APOLICE EQUAL 1003100362620 AND ENDOSSOS-NUM-ENDOSSO EQUAL 3)) */

            if (((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100005301 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 2) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100007489 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 2) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100009734 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 2) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100023163 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 3) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100026556 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 2) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100030982 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 2) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100031405 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 2) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100038836 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 2) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100169557 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 1) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100139450 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 1) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100116519 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 1) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100125781 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 1) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100149359 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 1) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100122441 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 1) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100212658 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 3) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100259372 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 1) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100276856 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 3) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100238788 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 2) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100240560 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 1) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100240560 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 3) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100242243 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 2) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 1003100362620 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 3)))
            {

                /*" -402- GO TO R1110-00-FETCH-ENDOSSOS. */
                new Task(() => R1110_00_FETCH_ENDOSSOS_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -404- PERFORM R1330-00-SELECT-MOVDEBCE */

            R1330_00_SELECT_MOVDEBCE_SECTION();

            /*" -405- IF WS-TEM-MOVDEBCC EQUAL 'S' */

            if (AREA_DE_WORK.WS_TEM_MOVDEBCC == "S")
            {

                /*" -407- IF MOVDEBCE-SITUACAO-COBRANCA EQUAL '3' OR '6' NEXT SENTENCE */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.In("3", "6"))
                {

                    /*" -408- ELSE */
                }
                else
                {


                    /*" -409- GO TO R1110-00-FETCH-ENDOSSOS */
                    new Task(() => R1110_00_FETCH_ENDOSSOS_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -410- END-IF */
                }


                /*" -412- END-IF. */
            }


            /*" -413- IF WHOST-ORGAO EQUAL 110 */

            if (WHOST_ORGAO == 110)
            {

                /*" -414- ADD 1 TO WS-LID-110 */
                AREA_DE_WORK.WS_LID_110.Value = AREA_DE_WORK.WS_LID_110 + 1;

                /*" -415- ELSE */
            }
            else
            {


                /*" -415- ADD 1 TO WS-QTD-REG-LID. */
                AREA_DE_WORK.WS_QTD_REG_LID.Value = AREA_DE_WORK.WS_QTD_REG_LID + 1;
            }


        }

        [StopWatch]
        /*" R1110-00-FETCH-ENDOSSOS-DB-FETCH-1 */
        public void R1110_00_FETCH_ENDOSSOS_DB_FETCH_1()
        {
            /*" -338- EXEC SQL FETCH C01_ENDOSSOS INTO :ENDOSSOS-NUM-APOLICE , :ENDOSSOS-NUM-ENDOSSO , :ENDOSSOS-TIPO-ENDOSSO , :ENDOSSOS-COD-FONTE END-EXEC. */

            if (C01_ENDOSSOS.Fetch())
            {
                _.Move(C01_ENDOSSOS.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(C01_ENDOSSOS.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(C01_ENDOSSOS.ENDOSSOS_TIPO_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);
                _.Move(C01_ENDOSSOS.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
            }

        }

        [StopWatch]
        /*" R1110-00-FETCH-ENDOSSOS-DB-CLOSE-1 */
        public void R1110_00_FETCH_ENDOSSOS_DB_CLOSE_1()
        {
            /*" -342- EXEC SQL CLOSE C01_ENDOSSOS END-EXEC */

            C01_ENDOSSOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-PROCESSA-ENDOSSOS-SECTION */
        private void R1200_00_PROCESSA_ENDOSSOS_SECTION()
        {
            /*" -430- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -432- MOVE ENDOSSOS-NUM-APOLICE TO PARCELAS-NUM-APOLICE */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

            /*" -433- PERFORM R1210-00-SELECT-PARCELAS */

            R1210_00_SELECT_PARCELAS_SECTION();

            /*" -434- IF WHOST-ORGAO EQUAL 110 */

            if (WHOST_ORGAO == 110)
            {

                /*" -435- MOVE PARCELAS-PRM-TOTAL-IX TO V1PARC-PREMIO-PAGO */
                _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX, V1PARC_PREMIO_PAGO);

                /*" -436- ELSE */
            }
            else
            {


                /*" -437- MOVE PARCELAS-PRM-LIQUIDO-IX TO V1PARC-PREMIO-PAGO */
                _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX, V1PARC_PREMIO_PAGO);

                /*" -439- END-IF */
            }


            /*" -440- PERFORM R1220-00-SELECT-PARCELAS */

            R1220_00_SELECT_PARCELAS_SECTION();

            /*" -443- MOVE PARCELAS-PRM-TOTAL-IX TO V1PARC-PREMIO-REST */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX, V1PARC_PREMIO_REST);

            /*" -444- MOVE ENDOSSOS-NUM-ENDOSSO TO PARCELAS-NUM-ENDOSSO */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

            /*" -445- PERFORM R1230-00-SELECT-PARCELAS */

            R1230_00_SELECT_PARCELAS_SECTION();

            /*" -448- MOVE PARCELAS-PRM-TOTAL-IX TO V1PARC-PREMIO-PEND */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX, V1PARC_PREMIO_PEND);

            /*" -451- COMPUTE V1PARC-PREMIO-DIFE = V1PARC-PREMIO-PAGO - V1PARC-PREMIO-REST */
            V1PARC_PREMIO_DIFE.Value = V1PARC_PREMIO_PAGO - V1PARC_PREMIO_REST;

            /*" -453- MOVE SPACES TO WMENSAGEM */
            _.Move("", AREA_DE_WORK.WMENSAGEM);

            /*" -461- IF (ENDOSSOS-NUM-APOLICE EQUAL 1103100100698 AND ENDOSSOS-NUM-ENDOSSO EQUAL 1) OR (ENDOSSOS-NUM-APOLICE EQUAL 1103100121720 AND ENDOSSOS-NUM-ENDOSSO EQUAL 2) OR (ENDOSSOS-NUM-APOLICE EQUAL 1103100161899 AND ENDOSSOS-NUM-ENDOSSO EQUAL 1) OR (ENDOSSOS-NUM-APOLICE EQUAL 1103100160859) OR (ENDOSSOS-NUM-APOLICE EQUAL 1103100154513) */

            if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.GetMoveValues().ToInt() == 1103100100698 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 1) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.GetMoveValues().ToInt() == 1103100121720 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 2) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.GetMoveValues().ToInt() == 1103100161899 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO == 1) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.GetMoveValues().ToInt() == 1103100160859) || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.GetMoveValues().ToInt() == 1103100154513))
            {

                /*" -462- ADD 1 TO WS-INS-110 */
                AREA_DE_WORK.WS_INS_110.Value = AREA_DE_WORK.WS_INS_110 + 1;

                /*" -463- PERFORM R1310-00-INSERT-V0EMISDIA */

                R1310_00_INSERT_V0EMISDIA_SECTION();

                /*" -465- PERFORM R1320-00-UPDATE-PARCEHIS */

                R1320_00_UPDATE_PARCEHIS_SECTION();

                /*" -466- DISPLAY '*--------------------------------*' */
                _.Display($"*--------------------------------*");

                /*" -467- DISPLAY 'EMISSAO DE PGTO FORCADO ' */
                _.Display($"EMISSAO DE PGTO FORCADO ");

                /*" -468- DISPLAY 'APOLICE = ' ENDOSSOS-NUM-APOLICE */
                _.Display($"APOLICE = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -469- DISPLAY 'ENDOSSO = ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -471- DISPLAY '*--------------------------------*' */
                _.Display($"*--------------------------------*");

                /*" -473- GO TO R1200-01-PULA-CRITICA-PREMIO */

                R1200_01_PULA_CRITICA_PREMIO(); //GOTO
                return;

                /*" -475- END-IF. */
            }


            /*" -476- IF WHOST-ORGAO EQUAL 110 */

            if (WHOST_ORGAO == 110)
            {

                /*" -477- IF V1PARC-PREMIO-PEND NOT GREATER V1PARC-PREMIO-DIFE */

                if (V1PARC_PREMIO_PEND <= V1PARC_PREMIO_DIFE)
                {

                    /*" -478- MOVE 'ATUALIZADO' TO WMENSAGEM */
                    _.Move("ATUALIZADO", AREA_DE_WORK.WMENSAGEM);

                    /*" -479- ADD 1 TO WS-INS-110 */
                    AREA_DE_WORK.WS_INS_110.Value = AREA_DE_WORK.WS_INS_110 + 1;

                    /*" -480- PERFORM R1310-00-INSERT-V0EMISDIA */

                    R1310_00_INSERT_V0EMISDIA_SECTION();

                    /*" -481- PERFORM R1320-00-UPDATE-PARCEHIS */

                    R1320_00_UPDATE_PARCEHIS_SECTION();

                    /*" -482- ELSE */
                }
                else
                {


                    /*" -483- ADD 1 TO WS-REJ-110 */
                    AREA_DE_WORK.WS_REJ_110.Value = AREA_DE_WORK.WS_REJ_110 + 1;

                    /*" -484- END-IF */
                }


                /*" -485- ELSE */
            }
            else
            {


                /*" -486- IF V1PARC-PREMIO-PEND LESS V1PARC-PREMIO-DIFE */

                if (V1PARC_PREMIO_PEND < V1PARC_PREMIO_DIFE)
                {

                    /*" -487- MOVE 'ATUALIZADO' TO WMENSAGEM */
                    _.Move("ATUALIZADO", AREA_DE_WORK.WMENSAGEM);

                    /*" -488- ADD 1 TO WS-QTD-REG-INS */
                    AREA_DE_WORK.WS_QTD_REG_INS.Value = AREA_DE_WORK.WS_QTD_REG_INS + 1;

                    /*" -489- PERFORM R1310-00-INSERT-V0EMISDIA */

                    R1310_00_INSERT_V0EMISDIA_SECTION();

                    /*" -490- PERFORM R1320-00-UPDATE-PARCEHIS */

                    R1320_00_UPDATE_PARCEHIS_SECTION();

                    /*" -491- ELSE */
                }
                else
                {


                    /*" -492- ADD 1 TO WS-QTD-REG-REJ */
                    AREA_DE_WORK.WS_QTD_REG_REJ.Value = AREA_DE_WORK.WS_QTD_REG_REJ + 1;

                    /*" -493- END-IF */
                }


                /*" -493- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1200_01_PULA_CRITICA_PREMIO */

            R1200_01_PULA_CRITICA_PREMIO();

        }

        [StopWatch]
        /*" R1200-01-PULA-CRITICA-PREMIO */
        private void R1200_01_PULA_CRITICA_PREMIO(bool isPerform = false)
        {
            /*" -500- MOVE V1PARC-PREMIO-PAGO TO WPREMIO-PAGO */
            _.Move(V1PARC_PREMIO_PAGO, AREA_DE_WORK.WPREMIO_PAGO);

            /*" -501- MOVE V1PARC-PREMIO-REST TO WPREMIO-REST */
            _.Move(V1PARC_PREMIO_REST, AREA_DE_WORK.WPREMIO_REST);

            /*" -502- MOVE V1PARC-PREMIO-PEND TO WPREMIO-PEND */
            _.Move(V1PARC_PREMIO_PEND, AREA_DE_WORK.WPREMIO_PEND);

            /*" -503- MOVE V1PARC-PREMIO-DIFE TO WPREMIO-DIFE */
            _.Move(V1PARC_PREMIO_DIFE, AREA_DE_WORK.WPREMIO_DIFE);

            /*" -505- MOVE V1PARC-PREMIO-PEND TO WPREMIO-ARES */
            _.Move(V1PARC_PREMIO_PEND, AREA_DE_WORK.WPREMIO_ARES);

            /*" -511- DISPLAY PARCELAS-NUM-APOLICE ' ' PARCELAS-NUM-ENDOSSO ' ' WPREMIO-PAGO ' ' WPREMIO-REST ' ' WPREMIO-PEND ' ' WPREMIO-DIFE ' ' WPREMIO-ARES ' ' WMENSAGEM. */

            $"{PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE} {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO} {AREA_DE_WORK.WPREMIO_PAGO} {AREA_DE_WORK.WPREMIO_REST} {AREA_DE_WORK.WPREMIO_PEND} {AREA_DE_WORK.WPREMIO_DIFE} {AREA_DE_WORK.WPREMIO_ARES} {AREA_DE_WORK.WMENSAGEM}"
            .Display();

            /*" -511- PERFORM R1110-00-FETCH-ENDOSSOS. */

            R1110_00_FETCH_ENDOSSOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-SELECT-PARCELAS-SECTION */
        private void R1210_00_SELECT_PARCELAS_SECTION()
        {
            /*" -525- MOVE 'R1210' TO WNR-EXEC-SQL. */
            _.Move("R1210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -538- PERFORM R1210_00_SELECT_PARCELAS_DB_SELECT_1 */

            R1210_00_SELECT_PARCELAS_DB_SELECT_1();

            /*" -541- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -543- DISPLAY 'R1210 - PROBLEMAS SELECT PARCELAS' ' ' ENDOSSOS-NUM-APOLICE */

                $"R1210 - PROBLEMAS SELECT PARCELAS {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}"
                .Display();

                /*" -543- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1210-00-SELECT-PARCELAS-DB-SELECT-1 */
        public void R1210_00_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -538- EXEC SQL SELECT VALUE(SUM(B.PRM_LIQUIDO_IX), 0), VALUE(SUM(B.PRM_TOTAL_IX), 0) INTO :PARCELAS-PRM-LIQUIDO-IX, :PARCELAS-PRM-TOTAL-IX FROM SEGUROS.ENDOSSOS A , SEGUROS.PARCELAS B WHERE A.NUM_APOLICE = :PARCELAS-NUM-APOLICE AND A.TIPO_ENDOSSO IN ( '0' , '1' ) AND B.SIT_REGISTRO = '1' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO END-EXEC. */

            var r1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCELAS_PRM_LIQUIDO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX);
                _.Move(executed_1.PARCELAS_PRM_TOTAL_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-SELECT-PARCELAS-SECTION */
        private void R1220_00_SELECT_PARCELAS_SECTION()
        {
            /*" -557- MOVE 'R1230' TO WNR-EXEC-SQL. */
            _.Move("R1230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -567- PERFORM R1220_00_SELECT_PARCELAS_DB_SELECT_1 */

            R1220_00_SELECT_PARCELAS_DB_SELECT_1();

            /*" -570- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -573- DISPLAY 'R1220 - PROBLEMAS SELECT PARCELAS' ' ' PARCELAS-NUM-APOLICE ' ' PARCELAS-NUM-ENDOSSO */

                $"R1220 - PROBLEMAS SELECT PARCELAS {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE} {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}"
                .Display();

                /*" -573- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1220-00-SELECT-PARCELAS-DB-SELECT-1 */
        public void R1220_00_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -567- EXEC SQL SELECT VALUE(SUM(B.PRM_TOTAL_IX), 0) INTO :PARCELAS-PRM-TOTAL-IX FROM SEGUROS.ENDOSSOS A , SEGUROS.PARCELAS B WHERE A.NUM_APOLICE = :PARCELAS-NUM-APOLICE AND A.TIPO_ENDOSSO IN ( '3' , '5' ) AND B.SIT_REGISTRO = '1' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO END-EXEC. */

            var r1220_00_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R1220_00_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1220_00_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r1220_00_SELECT_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCELAS_PRM_TOTAL_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1230-00-SELECT-PARCELAS-SECTION */
        private void R1230_00_SELECT_PARCELAS_SECTION()
        {
            /*" -587- MOVE 'R1230' TO WNR-EXEC-SQL. */
            _.Move("R1230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -598- PERFORM R1230_00_SELECT_PARCELAS_DB_SELECT_1 */

            R1230_00_SELECT_PARCELAS_DB_SELECT_1();

            /*" -601- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -604- DISPLAY 'R1230 - PROBLEMAS SELECT PARCELAS' ' ' PARCELAS-NUM-APOLICE ' ' PARCELAS-NUM-ENDOSSO */

                $"R1230 - PROBLEMAS SELECT PARCELAS {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE} {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}"
                .Display();

                /*" -604- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1230-00-SELECT-PARCELAS-DB-SELECT-1 */
        public void R1230_00_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -598- EXEC SQL SELECT VALUE(SUM(B.PRM_TOTAL_IX), 0) INTO :PARCELAS-PRM-TOTAL-IX FROM SEGUROS.ENDOSSOS A , SEGUROS.PARCELAS B WHERE A.NUM_APOLICE = :PARCELAS-NUM-APOLICE AND A.NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO AND A.TIPO_ENDOSSO IN ( '3' , '5' ) AND B.SIT_REGISTRO = '0' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO END-EXEC. */

            var r1230_00_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R1230_00_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1230_00_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r1230_00_SELECT_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCELAS_PRM_TOTAL_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1230_99_SAIDA*/

        [StopWatch]
        /*" R1310-00-INSERT-V0EMISDIA-SECTION */
        private void R1310_00_INSERT_V0EMISDIA_SECTION()
        {
            /*" -618- MOVE '1310' TO WNR-EXEC-SQL. */
            _.Move("1310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -619- MOVE 'EM0202B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0202B1", V0EDIA_CODRELAT);

            /*" -620- MOVE ENDOSSOS-NUM-APOLICE TO V0EDIA-NUM-APOL. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, V0EDIA_NUM_APOL);

            /*" -621- MOVE ENDOSSOS-NUM-ENDOSSO TO V0EDIA-NRENDOS. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, V0EDIA_NRENDOS);

            /*" -622- MOVE ZEROS TO V0EDIA-NRPARCEL. */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -624- MOVE V1SIST-DTMOVABE TO V0EDIA-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -625- IF ENDOSSOS-NUM-APOLICE = 0103100478439 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.GetMoveValues().ToInt() == 0103100478439)
            {

                /*" -626- MOVE 010 TO V0EDIA-ORGAO */
                _.Move(010, V0EDIA_ORGAO);

                /*" -627- ELSE */
            }
            else
            {


                /*" -629- MOVE WHOST-ORGAO TO V0EDIA-ORGAO. */
                _.Move(WHOST_ORGAO, V0EDIA_ORGAO);
            }


            /*" -630- MOVE 31 TO V0EDIA-RAMO. */
            _.Move(31, V0EDIA_RAMO);

            /*" -631- MOVE ENDOSSOS-COD-FONTE TO V0EDIA-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, V0EDIA_FONTE);

            /*" -632- MOVE ZEROS TO V0EDIA-CONGENER. */
            _.Move(0, V0EDIA_CONGENER);

            /*" -633- MOVE ZEROS TO V0EDIA-CODCORR. */
            _.Move(0, V0EDIA_CODCORR);

            /*" -634- MOVE ZEROS TO V0EDIA-COD-EMP. */
            _.Move(0, V0EDIA_COD_EMP);

            /*" -636- MOVE '0' TO V0EDIA-SITUACAO. */
            _.Move("0", V0EDIA_SITUACAO);

            /*" -651- PERFORM R1310_00_INSERT_V0EMISDIA_DB_INSERT_1 */

            R1310_00_INSERT_V0EMISDIA_DB_INSERT_1();

            /*" -654- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -655- DISPLAY 'ERRO NO INSERT' */
                _.Display($"ERRO NO INSERT");

                /*" -656- DISPLAY 'CODRELAT   ' V0EDIA-CODRELAT */
                _.Display($"CODRELAT   {V0EDIA_CODRELAT}");

                /*" -657- DISPLAY 'NUM-APOL   ' V0EDIA-NUM-APOL */
                _.Display($"NUM-APOL   {V0EDIA_NUM_APOL}");

                /*" -658- DISPLAY 'NRENDOS    ' V0EDIA-NRENDOS */
                _.Display($"NRENDOS    {V0EDIA_NRENDOS}");

                /*" -659- DISPLAY 'NRPARCEL   ' V0EDIA-NRPARCEL */
                _.Display($"NRPARCEL   {V0EDIA_NRPARCEL}");

                /*" -659- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1310-00-INSERT-V0EMISDIA-DB-INSERT-1 */
        public void R1310_00_INSERT_V0EMISDIA_DB_INSERT_1()
        {
            /*" -651- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , :V0EDIA-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

            var r1310_00_INSERT_V0EMISDIA_DB_INSERT_1_Insert1 = new R1310_00_INSERT_V0EMISDIA_DB_INSERT_1_Insert1()
            {
                V0EDIA_CODRELAT = V0EDIA_CODRELAT.ToString(),
                V0EDIA_NUM_APOL = V0EDIA_NUM_APOL.ToString(),
                V0EDIA_NRENDOS = V0EDIA_NRENDOS.ToString(),
                V0EDIA_NRPARCEL = V0EDIA_NRPARCEL.ToString(),
                V0EDIA_DTMOVTO = V0EDIA_DTMOVTO.ToString(),
                V0EDIA_ORGAO = V0EDIA_ORGAO.ToString(),
                V0EDIA_RAMO = V0EDIA_RAMO.ToString(),
                V0EDIA_FONTE = V0EDIA_FONTE.ToString(),
                V0EDIA_CONGENER = V0EDIA_CONGENER.ToString(),
                V0EDIA_CODCORR = V0EDIA_CODCORR.ToString(),
                V0EDIA_SITUACAO = V0EDIA_SITUACAO.ToString(),
                V0EDIA_COD_EMP = V0EDIA_COD_EMP.ToString(),
            };

            R1310_00_INSERT_V0EMISDIA_DB_INSERT_1_Insert1.Execute(r1310_00_INSERT_V0EMISDIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1310_99_SAIDA*/

        [StopWatch]
        /*" R1320-00-UPDATE-PARCEHIS-SECTION */
        private void R1320_00_UPDATE_PARCEHIS_SECTION()
        {
            /*" -673- MOVE 'R1320' TO WNR-EXEC-SQL. */
            _.Move("R1320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -679- PERFORM R1320_00_UPDATE_PARCEHIS_DB_UPDATE_1 */

            R1320_00_UPDATE_PARCEHIS_DB_UPDATE_1();

            /*" -682- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -686- DISPLAY 'R1320 - PROBLEMAS UPDATE PARCEHIS' ' ' PARCELAS-NUM-APOLICE ' ' PARCELAS-NUM-ENDOSSO ' 0' */

                $"R1320 - PROBLEMAS UPDATE PARCEHIS {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE} {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO} 0"
                .Display();

                /*" -686- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1320-00-UPDATE-PARCEHIS-DB-UPDATE-1 */
        public void R1320_00_UPDATE_PARCEHIS_DB_UPDATE_1()
        {
            /*" -679- EXEC SQL UPDATE SEGUROS.PARCELA_HISTORICO SET DATA_VENCIMENTO = :V1SIST-DTMOVABE WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND NUM_PARCELA = 0 END-EXEC. */

            var r1320_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1 = new R1320_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            R1320_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1.Execute(r1320_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1320_99_SAIDA*/

        [StopWatch]
        /*" R1330-00-SELECT-MOVDEBCE-SECTION */
        private void R1330_00_SELECT_MOVDEBCE_SECTION()
        {
            /*" -700- MOVE 'R1330' TO WNR-EXEC-SQL. */
            _.Move("R1330", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -702- MOVE 'N' TO WS-TEM-MOVDEBCC */
            _.Move("N", AREA_DE_WORK.WS_TEM_MOVDEBCC);

            /*" -722- PERFORM R1330_00_SELECT_MOVDEBCE_DB_SELECT_1 */

            R1330_00_SELECT_MOVDEBCE_DB_SELECT_1();

            /*" -726- IF SQLCODE EQUAL ZEROS OR SQLCODE EQUAL -811 */

            if (DB.SQLCODE == 00 || DB.SQLCODE == -811)
            {

                /*" -727- MOVE 'S' TO WS-TEM-MOVDEBCC */
                _.Move("S", AREA_DE_WORK.WS_TEM_MOVDEBCC);

                /*" -728- ELSE */
            }
            else
            {


                /*" -729- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -730- MOVE 'N' TO WS-TEM-MOVDEBCC */
                    _.Move("N", AREA_DE_WORK.WS_TEM_MOVDEBCC);

                    /*" -731- ELSE */
                }
                else
                {


                    /*" -732- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -735- DISPLAY 'R1330 - PROBLEMAS SELECT MOVDEBCC' ' ' ENDOSSOS-NUM-APOLICE ' ' ENDOSSOS-NUM-ENDOSSO */

                        $"R1330 - PROBLEMAS SELECT MOVDEBCC {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}"
                        .Display();

                        /*" -736- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R1330-00-SELECT-MOVDEBCE-DB-SELECT-1 */
        public void R1330_00_SELECT_MOVDEBCE_DB_SELECT_1()
        {
            /*" -722- EXEC SQL SELECT NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, SITUACAO_COBRANCA INTO :MOVDEBCE-NUM-APOLICE, :MOVDEBCE-NUM-ENDOSSO, :MOVDEBCE-NUM-PARCELA, :MOVDEBCE-SITUACAO-COBRANCA FROM SEGUROS.MOVTO_DEBITOCC_CEF MO1 WHERE MO1.COD_EMPRESA = 0 AND MO1.NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND MO1.NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND MO1.TIMESTAMP = (SELECT MAX(MO2.TIMESTAMP) FROM SEGUROS.MOVTO_DEBITOCC_CEF MO2 WHERE MO2.COD_EMPRESA = MO1.COD_EMPRESA AND MO2.NUM_APOLICE = MO1.NUM_APOLICE AND MO2.NUM_ENDOSSO = MO1.NUM_ENDOSSO AND MO2.NUM_PARCELA = MO1.NUM_PARCELA ) END-EXEC. */

            var r1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 = new R1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1.Execute(r1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1330_99_SAIDA*/

        [StopWatch]
        /*" R9950-00-FIM-SECTION */
        private void R9950_00_FIM_SECTION()
        {
            /*" -746- DISPLAY '                 ' */
            _.Display($"                 ");

            /*" -747- DISPLAY 'ORGAO 100        ' */
            _.Display($"ORGAO 100        ");

            /*" -748- DISPLAY 'Lidos .......... ' WS-QTD-REG-LID */
            _.Display($"Lidos .......... {AREA_DE_WORK.WS_QTD_REG_LID}");

            /*" -749- DISPLAY 'Rejeitados ..... ' WS-QTD-REG-REJ */
            _.Display($"Rejeitados ..... {AREA_DE_WORK.WS_QTD_REG_REJ}");

            /*" -750- DISPLAY 'Inseridos ...... ' WS-QTD-REG-INS */
            _.Display($"Inseridos ...... {AREA_DE_WORK.WS_QTD_REG_INS}");

            /*" -751- DISPLAY '                 ' */
            _.Display($"                 ");

            /*" -752- DISPLAY 'ORGAO 110        ' */
            _.Display($"ORGAO 110        ");

            /*" -753- DISPLAY 'Lidos .......... ' WS-LID-110 */
            _.Display($"Lidos .......... {AREA_DE_WORK.WS_LID_110}");

            /*" -754- DISPLAY 'Rejeitados ..... ' WS-REJ-110 */
            _.Display($"Rejeitados ..... {AREA_DE_WORK.WS_REJ_110}");

            /*" -756- DISPLAY 'Inseridos ...... ' WS-INS-110 */
            _.Display($"Inseridos ...... {AREA_DE_WORK.WS_INS_110}");

            /*" -757- MOVE '00/00/0000' TO WS-DATA-CURR */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_CURR);

            /*" -758- ACCEPT WS-DATA-ACCEPT FROM DATE */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WS_DATA_ACCEPT);

            /*" -759- MOVE WS-DIA-ACCEPT TO WS-DIA-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_DIA_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_DIA_CURR);

            /*" -760- MOVE WS-MES-ACCEPT TO WS-MES-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_MES_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_MES_CURR);

            /*" -761- MOVE WS-ANO-ACCEPT TO WS-ANO-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_ANO_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR);

            /*" -763- ADD 2000 TO WS-ANO-CURR */
            AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR.Value = AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR + 2000;

            /*" -764- MOVE '00:00:00' TO WS-HORA-CURR */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_CURR);

            /*" -765- ACCEPT WS-HORA-ACCEPT FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -766- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_HOR_CURR);

            /*" -767- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_MIN_CURR);

            /*" -768- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_SEG_CURR);

            /*" -769- DISPLAY ' ' */
            _.Display($" ");

            /*" -770- DISPLAY 'EM0135B - FINAL  DO PROCESSAMENTO (' WS-DATA-CURR ' - ' WS-HORA-CURR ')' . */

            $"EM0135B - FINAL  DO PROCESSAMENTO ({AREA_DE_WORK.WS_DATA_CURR} - {AREA_DE_WORK.WS_HORA_CURR})"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9950_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -785- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -787- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -787- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -789- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -793- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -793- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}