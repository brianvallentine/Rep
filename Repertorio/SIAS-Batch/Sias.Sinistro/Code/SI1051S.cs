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
using Sias.Sinistro.DB2.SI1051S;

namespace Code
{
    public class SI1051S
    {
        public bool IsCall { get; set; }

        public SI1051S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO / RESSARCIMENTO           *      */
        /*"      *   PROGRAMA ...............  SI1051S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER / EDUARDO (PRODEXTER)       *      */
        /*"      *   PROGRAMADOR ............  HEIDER / EDUARDO (PRODEXTER)       *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO  / 2005                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... PROGRAMA RESPONSAVEL PELA GERACAO DA OPERACAO *      */
        /*"      *          PARA REEMISSAO DE REPASSE                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   M A N U T E N C A O - O R D E M  D E C R E S C E N T E       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.XX  * DD/MM/AAAA  -EMPRESA   - NOME                                  *      */
        /*"      *             -DESCRICAO DESCRICAO DESCRICAO DESCRICAO           *      */
        /*"      *              DESCRICAO DESCRICAO DESCRICAO DESCRICAO           *      */
        /*"      *             -PROCURAR POR V.XX                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * 08/04/2009  -CONTRASTE - GEORGES DA MATA CLAESSEN              *      */
        /*"      *             -INCLUSAO DA VERIFICACAO DE RUNOFF PARA CREDITO    *      */
        /*"      *              COMERCIAL. PARA IDENTIFICAR O RUNOFF DO CREDITO   *      */
        /*"      *              COMERCIAL A PRIMEIRA INDENIZACAO DEVE SER ANTERIOR*      */
        /*"      *              A 01/01/2005                                      *      */
        /*"      *             -PROCURAR POR V.01                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"77  HOST-COUNT                       PIC S9(09) VALUE +0 COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  HOST-MAX-OCORR-HISTORICO         PIC S9(04) VALUE +0 COMP.*/
        public IntBasis HOST_MAX_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-MIN-DATA-MOVIMENTO          PIC  X(10) VALUE SPACES.*/
        public StringBasis HOST_MIN_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-SINISTRO-CRED-INT              PIC  X(03) VALUE 'NAO'.*/
        public StringBasis W_SINISTRO_CRED_INT { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"77  W-MIN-DATA-MOV-INDENIZADO        PIC  X(10) VALUE SPACES.*/
        public StringBasis W_MIN_DATA_MOV_INDENIZADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  AREA-DE-WORK.*/
        public SI1051S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI1051S_AREA_DE_WORK();
        public class SI1051S_AREA_DE_WORK : VarBasis
        {
            /*"    05 WABEND.*/
            public SI1051S_WABEND WABEND { get; set; } = new SI1051S_WABEND();
            public class SI1051S_WABEND : VarBasis
            {
                /*"       07 WABEND1.*/
                public SI1051S_WABEND1 WABEND1 { get; set; } = new SI1051S_WABEND1();
                public class SI1051S_WABEND1 : VarBasis
                {
                    /*"       10 FILLER         PIC  X(008)      VALUE          'SI1051S '.*/
                    public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SI1051S ");
                    /*"       07 WABEND2.*/
                    public SI1051S_WABEND2 WABEND2 { get; set; } = new SI1051S_WABEND2();
                    public class SI1051S_WABEND2 : VarBasis
                    {
                        /*"       10 FILLER         PIC  X(025)      VALUE          '*** ERRO EXEC SQL NUMERO '.*/
                        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                        /*"       10 WNR-EXEC-SQL   PIC  X(004)      VALUE   '0000'.*/
                        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                        /*"       07 WABEND3.*/
                        public SI1051S_WABEND3 WABEND3 { get; set; } = new SI1051S_WABEND3();
                        public class SI1051S_WABEND3 : VarBasis
                        {
                            /*"       10 FILLER         PIC  X(013)      VALUE          ' *** SQLCODE '.*/
                            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                            /*"       10 WSQLCODE       PIC  ZZZZZ999-   VALUE    ZEROS.*/
                            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                            /*"       10 WSQLERRMC      PIC  X(40)      VALUE    SPACES.*/
                            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                            /*"       10 WSQLCAID     PIC X(8).*/
                            public StringBasis WSQLCAID { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
                            /*"       10 WSQLCABC     PIC S9(9) COMP-4.*/
                            public IntBasis WSQLCABC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
                            /*"       10 WSQLERRP     PIC X(8).*/
                            public StringBasis WSQLERRP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
                            /*"       10 WSQLWARN.*/
                            public SI1051S_WSQLWARN WSQLWARN { get; set; } = new SI1051S_WSQLWARN();
                            public class SI1051S_WSQLWARN : VarBasis
                            {
                                /*"          15 WSQLWARN0 PIC X.*/
                                public StringBasis WSQLWARN0 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN1 PIC X.*/
                                public StringBasis WSQLWARN1 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN2 PIC X.*/
                                public StringBasis WSQLWARN2 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN3 PIC X.*/
                                public StringBasis WSQLWARN3 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN4 PIC X.*/
                                public StringBasis WSQLWARN4 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN5 PIC X.*/
                                public StringBasis WSQLWARN5 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"01  LINK-ESTORNA-REPASSE.*/
                            }
                        }
                    }
                }
            }
        }
        public SI1051S_LINK_ESTORNA_REPASSE LINK_ESTORNA_REPASSE { get; set; } = new SI1051S_LINK_ESTORNA_REPASSE();
        public class SI1051S_LINK_ESTORNA_REPASSE : VarBasis
        {
            /*"    05 PARM-TAMANHO                PIC S9(04) COMP.*/
            public IntBasis PARM_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PARM-NUM-APOL-SINISTRO      PIC S9(13) COMP-3.*/
            public IntBasis PARM_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05 PARM-OCORR-HISTORICO        PIC S9(04) COMP.*/
            public IntBasis PARM_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PARM-COD-OPERACAO           PIC S9(04) COMP.*/
            public IntBasis PARM_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PARM-VAL-OPERACAO           PIC S9(13)V99 COMP-3.*/
            public DoubleBasis PARM_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 PARM-COD-USUARIO            PIC  X(08).*/
            public StringBasis PARM_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 PARM-IND-RETORNO            PIC  X(01).*/
            public StringBasis PARM_IND_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 PARM-MENSAGEM-RETORNO       PIC  X(100).*/
            public StringBasis PARM_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
            /*"    05 PARM-SQLCODE                PIC S9(04).*/
            public IntBasis PARM_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)."));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINCREIN SINCREIN { get; set; } = new Dclgens.SINCREIN();
        public Dclgens.SI111 SI111 { get; set; } = new Dclgens.SI111();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SI1051S_LINK_ESTORNA_REPASSE SI1051S_LINK_ESTORNA_REPASSE_P) //PROCEDURE DIVISION USING 
        /*LINK_ESTORNA_REPASSE*/
        {
            try
            {
                this.LINK_ESTORNA_REPASSE = SI1051S_LINK_ESTORNA_REPASSE_P;

                /*" -143- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -144- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -145- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -150- PERFORM R100-ROTINA-CRITICA THRU R100-EXIT. */

                R100_ROTINA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_PULA_CRITICA_DATA_IND*/

                /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/


                /*" -152- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

                /*" -154- PERFORM R500-LE-SISTEMAS THRU R500-EXIT. */

                R500_LE_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/


                /*" -156- PERFORM R1000-LE-MESTSINI THRU R1000-EXIT. */

                R1000_LE_MESTSINI(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/


                /*" -157- IF (W-SINISTRO-CRED-INT = 'SIM' ) */

                if ((W_SINISTRO_CRED_INT == "SIM"))
                {

                    /*" -158- PERFORM R1500-VALIDAR-RUNOFF THRU R1500-EXIT */

                    R1500_VALIDAR_RUNOFF(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_EXIT*/


                    /*" -160- END-IF. */
                }


                /*" -162- PERFORM R2000-INSERT-HISTSINI THRU R2000-EXIT. */

                R2000_INSERT_HISTSINI(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_EXIT*/


                /*" -164- PERFORM R2100-INSERT-PARCELA THRU R2100-EXIT. */

                R2100_INSERT_PARCELA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_EXIT*/


                /*" -165- MOVE '0' TO PARM-IND-RETORNO. */
                _.Move("0", LINK_ESTORNA_REPASSE.PARM_IND_RETORNO);

                /*" -166- MOVE ZEROS TO PARM-SQLCODE. */
                _.Move(0, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -168- MOVE 'REEMISSAO EFETUADA COM SUCESSO' TO PARM-MENSAGEM-RETORNO. */
                _.Move("REEMISSAO EFETUADA COM SUCESSO", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -168- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LINK_ESTORNA_REPASSE };
            return Result;
        }

        [StopWatch]
        /*" R100-ROTINA-CRITICA */
        private void R100_ROTINA_CRITICA(bool isPerform = false)
        {
            /*" -175- MOVE '0' TO PARM-IND-RETORNO. */
            _.Move("0", LINK_ESTORNA_REPASSE.PARM_IND_RETORNO);

            /*" -176- MOVE ZEROS TO PARM-SQLCODE. */
            _.Move(0, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

            /*" -178- MOVE SPACES TO PARM-MENSAGEM-RETORNO. */
            _.Move("", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

            /*" -179- IF PARM-NUM-APOL-SINISTRO EQUAL ZERO */

            if (LINK_ESTORNA_REPASSE.PARM_NUM_APOL_SINISTRO == 00)
            {

                /*" -181- MOVE 'SINISTRO NAO INFORMADO' TO PARM-MENSAGEM-RETORNO */
                _.Move("SINISTRO NAO INFORMADO", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -183- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -184- IF PARM-OCORR-HISTORICO EQUAL ZERO */

            if (LINK_ESTORNA_REPASSE.PARM_OCORR_HISTORICO == 00)
            {

                /*" -186- MOVE 'OCORRENCIA DE HISTORICO NAO INFORMADO' TO PARM-MENSAGEM-RETORNO */
                _.Move("OCORRENCIA DE HISTORICO NAO INFORMADO", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -188- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -189- IF PARM-COD-OPERACAO EQUAL ZERO */

            if (LINK_ESTORNA_REPASSE.PARM_COD_OPERACAO == 00)
            {

                /*" -191- MOVE 'CODIGO OPERACAO NAO INFORMADO' TO PARM-MENSAGEM-RETORNO */
                _.Move("CODIGO OPERACAO NAO INFORMADO", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -193- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -194- IF PARM-COD-OPERACAO NOT EQUAL 4292 */

            if (LINK_ESTORNA_REPASSE.PARM_COD_OPERACAO != 4292)
            {

                /*" -196- MOVE 'OPERACAO INFORMADA DIFERE DE 4292 - PAGTO ESTORNADO' TO PARM-MENSAGEM-RETORNO */
                _.Move("OPERACAO INFORMADA DIFERE DE 4292 - PAGTO ESTORNADO", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -203- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -204- IF PARM-COD-USUARIO EQUAL SPACES */

            if (LINK_ESTORNA_REPASSE.PARM_COD_USUARIO.IsEmpty())
            {

                /*" -206- MOVE 'CODIGO DO USUARIO NAO INFORMADO' TO PARM-MENSAGEM-RETORNO */
                _.Move("CODIGO DO USUARIO NAO INFORMADO", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -208- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -210- INITIALIZE DCLSINISTRO-HISTORICO. */
            _.Initialize(
                SINISHIS.DCLSINISTRO_HISTORICO
            );

            /*" -211- MOVE PARM-NUM-APOL-SINISTRO TO SINISHIS-NUM-APOL-SINISTRO. */
            _.Move(LINK_ESTORNA_REPASSE.PARM_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);

            /*" -212- MOVE PARM-OCORR-HISTORICO TO SINISHIS-OCORR-HISTORICO. */
            _.Move(LINK_ESTORNA_REPASSE.PARM_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

            /*" -213- MOVE PARM-COD-OPERACAO TO SINISHIS-COD-OPERACAO. */
            _.Move(LINK_ESTORNA_REPASSE.PARM_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -215- MOVE PARM-COD-USUARIO TO SINISHIS-COD-USUARIO. */
            _.Move(LINK_ESTORNA_REPASSE.PARM_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);

            /*" -217- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -272- PERFORM R100_ROTINA_CRITICA_DB_SELECT_1 */

            R100_ROTINA_CRITICA_DB_SELECT_1();

            /*" -275- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -277- MOVE 'ERRO NO SELECT SINISTRO_HISTORICO (1)' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO NO SELECT SINISTRO_HISTORICO (1)", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -278- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -280- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -281- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -283- MOVE 'SOLICITADO REEMISSAO P/ ESTORNO NAO ENCONTRADO' TO PARM-MENSAGEM-RETORNO */
                _.Move("SOLICITADO REEMISSAO P/ ESTORNO NAO ENCONTRADO", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -284- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -286- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -287- IF PARM-VAL-OPERACAO GREATER SINISHIS-VAL-OPERACAO */

            if (LINK_ESTORNA_REPASSE.PARM_VAL_OPERACAO > SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO)
            {

                /*" -289- MOVE 'VALOR INFORMADO MAIOR QUE VALOR ESTORNADO' TO PARM-MENSAGEM-RETORNO */
                _.Move("VALOR INFORMADO MAIOR QUE VALOR ESTORNADO", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -291- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -293- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -336- PERFORM R100_ROTINA_CRITICA_DB_SELECT_2 */

            R100_ROTINA_CRITICA_DB_SELECT_2();

            /*" -339- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -341- MOVE 'ERRO NO SELECT SI_RESSARC_PARCELA' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO NO SELECT SI_RESSARC_PARCELA", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -342- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -344- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -345- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -347- MOVE 'NAO ENCONTRADO OPERACAO DE ESTORNO NA PARCELA' TO PARM-MENSAGEM-RETORNO */
                _.Move("NAO ENCONTRADO OPERACAO DE ESTORNO NA PARCELA", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -348- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -350- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -352- MOVE 0 TO HOST-COUNT. */
            _.Move(0, HOST_COUNT);

            /*" -354- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -375- PERFORM R100_ROTINA_CRITICA_DB_SELECT_3 */

            R100_ROTINA_CRITICA_DB_SELECT_3();

            /*" -378- IF (SQLCODE NOT EQUAL ZERO) */

            if ((DB.SQLCODE != 00))
            {

                /*" -380- MOVE 'ERRO DE ACESSO NA PESQUISA 4290 ATIVA' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO DE ACESSO NA PESQUISA 4290 ATIVA", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -381- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -383- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -384- IF HOST-COUNT EQUAL 1 */

            if (HOST_COUNT == 1)
            {

                /*" -385- MOVE '0' TO PARM-IND-RETORNO */
                _.Move("0", LINK_ESTORNA_REPASSE.PARM_IND_RETORNO);

                /*" -391- GOBACK. */

                throw new GoBack();
            }


            /*" -392- IF HOST-COUNT GREATER 1 */

            if (HOST_COUNT > 1)
            {

                /*" -394- MOVE 'ERRO IMPREVISTO. + REEMISSAO SOLICITADA' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO IMPREVISTO. + REEMISSAO SOLICITADA", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -395- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -401- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -402- IF SINISHIS-COD-PRODUTO EQUAL 4801 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO == 4801)
            {

                /*" -404- MOVE 'NAO PODE TER REPASSE PARA PRODUTO 4801 - FUNDAO' TO PARM-MENSAGEM-RETORNO */
                _.Move("NAO PODE TER REPASSE PARA PRODUTO 4801 - FUNDAO", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -405- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -409- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -410- IF SINISHIS-COD-PRODUTO EQUAL 4812 OR 7001 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO.In("4812", "7001"))
            {

                /*" -415- GO TO R100-PULA-CRITICA-DATA-IND. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_PULA_CRITICA_DATA_IND*/ //GOTO
                return;
            }


            /*" -417- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -424- PERFORM R100_ROTINA_CRITICA_DB_SELECT_4 */

            R100_ROTINA_CRITICA_DB_SELECT_4();

            /*" -427- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -429- MOVE 'ERRO ACESSO SINISTRO_CRED_INT' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO ACESSO SINISTRO_CRED_INT", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -430- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -434- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -436- MOVE 'NAO' TO W-SINISTRO-CRED-INT */
            _.Move("NAO", W_SINISTRO_CRED_INT);

            /*" -437- IF (SQLCODE = 0) */

            if ((DB.SQLCODE == 0))
            {

                /*" -438- MOVE 'SIM' TO W-SINISTRO-CRED-INT */
                _.Move("SIM", W_SINISTRO_CRED_INT);

                /*" -440- END-IF. */
            }


            /*" -441- IF SINCREIN-COD-AGENCIA EQUAL 9999 */

            if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA == 9999)
            {

                /*" -443- MOVE 'SINISTRO/ACORDO SEM IDENTIFICACAO DE CONTRATO' TO PARM-MENSAGEM-RETORNO */
                _.Move("SINISTRO/ACORDO SEM IDENTIFICACAO DE CONTRATO", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -444- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -446- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -448- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -457- PERFORM R100_ROTINA_CRITICA_DB_SELECT_5 */

            R100_ROTINA_CRITICA_DB_SELECT_5();

            /*" -460- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -462- MOVE 'ERRO ACESSO SINISTRO_HISTORICO MENOR DATA CREDITO' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO ACESSO SINISTRO_HISTORICO MENOR DATA CREDITO", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -463- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -465- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -466- IF HOST-MIN-DATA-MOVIMENTO NOT LESS '2005-01-01' */

            if (HOST_MIN_DATA_MOVIMENTO >= "2005-01-01")
            {

                /*" -468- MOVE 'NAO PODE TER REPASSE. INDENIZ. POSTERIOR 01/01/05' TO PARM-MENSAGEM-RETORNO */
                _.Move("NAO PODE TER REPASSE. INDENIZ. POSTERIOR 01/01/05", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -469- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -469- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


        }

        [StopWatch]
        /*" R100-ROTINA-CRITICA-DB-SELECT-1 */
        public void R100_ROTINA_CRITICA_DB_SELECT_1()
        {
            /*" -272- EXEC SQL SELECT H.COD_EMPRESA , H.TIPO_REGISTRO , H.NUM_APOL_SINISTRO , H.OCORR_HISTORICO , H.COD_OPERACAO , H.DATA_MOVIMENTO , H.HORA_OPERACAO , H.NOME_FAVORECIDO , H.VAL_OPERACAO , H.DATA_LIM_CORRECAO , H.TIPO_FAVORECIDO , H.DATA_NEGOCIADA , H.FONTE_PAGAMENTO , H.COD_PREST_SERVICO , H.COD_SERVICO , H.ORDEM_PAGAMENTO , H.NUM_RECIBO , H.NUM_MOV_SINISTRO , H.COD_USUARIO , H.SIT_CONTABIL , H.SIT_REGISTRO , H.TIMESTAMP , H.NUM_APOLICE , H.COD_PRODUTO , H.NOM_PROGRAMA INTO :SINISHIS-COD-EMPRESA , :SINISHIS-TIPO-REGISTRO , :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-HORA-OPERACAO, :SINISHIS-NOME-FAVORECIDO, :SINISHIS-VAL-OPERACAO, :SINISHIS-DATA-LIM-CORRECAO, :SINISHIS-TIPO-FAVORECIDO, :SINISHIS-DATA-NEGOCIADA, :SINISHIS-FONTE-PAGAMENTO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-ORDEM-PAGAMENTO, :SINISHIS-NUM-RECIBO, :SINISHIS-NUM-MOV-SINISTRO, :SINISHIS-COD-USUARIO, :SINISHIS-SIT-CONTABIL, :SINISHIS-SIT-REGISTRO, :SINISHIS-TIMESTAMP, :SINISHIS-NUM-APOLICE, :SINISHIS-COD-PRODUTO, :SINISHIS-NOM-PROGRAMA FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO END-EXEC. */

            var r100_ROTINA_CRITICA_DB_SELECT_1_Query1 = new R100_ROTINA_CRITICA_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R100_ROTINA_CRITICA_DB_SELECT_1_Query1.Execute(r100_ROTINA_CRITICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_COD_EMPRESA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_EMPRESA);
                _.Move(executed_1.SINISHIS_TIPO_REGISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO);
                _.Move(executed_1.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(executed_1.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(executed_1.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(executed_1.SINISHIS_HORA_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_HORA_OPERACAO);
                _.Move(executed_1.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(executed_1.SINISHIS_DATA_LIM_CORRECAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO);
                _.Move(executed_1.SINISHIS_TIPO_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO);
                _.Move(executed_1.SINISHIS_DATA_NEGOCIADA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA);
                _.Move(executed_1.SINISHIS_FONTE_PAGAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_FONTE_PAGAMENTO);
                _.Move(executed_1.SINISHIS_COD_PREST_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);
                _.Move(executed_1.SINISHIS_COD_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO);
                _.Move(executed_1.SINISHIS_ORDEM_PAGAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_ORDEM_PAGAMENTO);
                _.Move(executed_1.SINISHIS_NUM_RECIBO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_RECIBO);
                _.Move(executed_1.SINISHIS_NUM_MOV_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_MOV_SINISTRO);
                _.Move(executed_1.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
                _.Move(executed_1.SINISHIS_SIT_CONTABIL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                _.Move(executed_1.SINISHIS_SIT_REGISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);
                _.Move(executed_1.SINISHIS_TIMESTAMP, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIMESTAMP);
                _.Move(executed_1.SINISHIS_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);
                _.Move(executed_1.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
                _.Move(executed_1.SINISHIS_NOM_PROGRAMA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_PULA_CRITICA_DATA_IND*/

        [StopWatch]
        /*" R100-ROTINA-CRITICA-DB-SELECT-2 */
        public void R100_ROTINA_CRITICA_DB_SELECT_2()
        {
            /*" -336- EXEC SQL SELECT P.NUM_APOL_SINISTRO , P.OCORR_HISTORICO , P.COD_OPERACAO , P.NUM_RESSARC , P.SEQ_RESSARC , P.NUM_PARCELA , P.COD_AGENCIA_CEDENT , P.COD_SISTEMA_ORIGEM , P.NUM_CEDENTE , P.NUM_CEDENTE_DV , P.DTH_VENCIMENTO , P.NUM_NOSSO_TITULO , P.DTH_CADASTRAMENTO , P.PCT_OPERACAO , P.IND_FORMA_BAIXA , P.NOM_PROGRAMA , P.DTH_PAGAMENTO , P.IND_INTEGRACAO , P.NUM_TITULO_SIGCB INTO :SI111-NUM-APOL-SINISTRO, :SI111-OCORR-HISTORICO, :SI111-COD-OPERACAO, :SI111-NUM-RESSARC, :SI111-SEQ-RESSARC, :SI111-NUM-PARCELA, :SI111-COD-AGENCIA-CEDENT, :SI111-COD-SISTEMA-ORIGEM, :SI111-NUM-CEDENTE, :SI111-NUM-CEDENTE-DV, :SI111-DTH-VENCIMENTO, :SI111-NUM-NOSSO-TITULO, :SI111-DTH-CADASTRAMENTO, :SI111-PCT-OPERACAO, :SI111-IND-FORMA-BAIXA, :SI111-NOM-PROGRAMA, :SI111-DTH-PAGAMENTO, :SI111-IND-INTEGRACAO, :SI111-NUM-TITULO-SIGCB FROM SEGUROS.SI_RESSARC_PARCELA P WHERE P.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND P.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND P.COD_OPERACAO = :SINISHIS-COD-OPERACAO END-EXEC. */

            var r100_ROTINA_CRITICA_DB_SELECT_2_Query1 = new R100_ROTINA_CRITICA_DB_SELECT_2_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R100_ROTINA_CRITICA_DB_SELECT_2_Query1.Execute(r100_ROTINA_CRITICA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SI111_NUM_APOL_SINISTRO, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO);
                _.Move(executed_1.SI111_OCORR_HISTORICO, SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO);
                _.Move(executed_1.SI111_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);
                _.Move(executed_1.SI111_NUM_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC);
                _.Move(executed_1.SI111_SEQ_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_SEQ_RESSARC);
                _.Move(executed_1.SI111_NUM_PARCELA, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA);
                _.Move(executed_1.SI111_COD_AGENCIA_CEDENT, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_AGENCIA_CEDENT);
                _.Move(executed_1.SI111_COD_SISTEMA_ORIGEM, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_SISTEMA_ORIGEM);
                _.Move(executed_1.SI111_NUM_CEDENTE, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE);
                _.Move(executed_1.SI111_NUM_CEDENTE_DV, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE_DV);
                _.Move(executed_1.SI111_DTH_VENCIMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_VENCIMENTO);
                _.Move(executed_1.SI111_NUM_NOSSO_TITULO, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO);
                _.Move(executed_1.SI111_DTH_CADASTRAMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_CADASTRAMENTO);
                _.Move(executed_1.SI111_PCT_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_PCT_OPERACAO);
                _.Move(executed_1.SI111_IND_FORMA_BAIXA, SI111.DCLSI_RESSARC_PARCELA.SI111_IND_FORMA_BAIXA);
                _.Move(executed_1.SI111_NOM_PROGRAMA, SI111.DCLSI_RESSARC_PARCELA.SI111_NOM_PROGRAMA);
                _.Move(executed_1.SI111_DTH_PAGAMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO);
                _.Move(executed_1.SI111_IND_INTEGRACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_IND_INTEGRACAO);
                _.Move(executed_1.SI111_NUM_TITULO_SIGCB, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_TITULO_SIGCB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R100-ROTINA-CRITICA-DB-SELECT-3 */
        public void R100_ROTINA_CRITICA_DB_SELECT_3()
        {
            /*" -375- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.SI_RESSARC_PARCELA P WHERE P.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND P.NUM_RESSARC = :SI111-NUM-RESSARC AND P.SEQ_RESSARC = :SI111-SEQ-RESSARC AND P.NUM_PARCELA = :SI111-NUM-PARCELA AND P.COD_OPERACAO = 4290 AND EXISTS (SELECT H.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO AND H.OCORR_HISTORICO = P.OCORR_HISTORICO AND H.COD_OPERACAO = P.COD_OPERACAO) AND NOT EXISTS (SELECT H.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO AND H.OCORR_HISTORICO = P.OCORR_HISTORICO AND H.COD_OPERACAO IN (4291,4293,4292)) END-EXEC. */

            var r100_ROTINA_CRITICA_DB_SELECT_3_Query1 = new R100_ROTINA_CRITICA_DB_SELECT_3_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SI111_NUM_RESSARC = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC.ToString(),
                SI111_SEQ_RESSARC = SI111.DCLSI_RESSARC_PARCELA.SI111_SEQ_RESSARC.ToString(),
                SI111_NUM_PARCELA = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA.ToString(),
            };

            var executed_1 = R100_ROTINA_CRITICA_DB_SELECT_3_Query1.Execute(r100_ROTINA_CRITICA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }

        [StopWatch]
        /*" R101-RETORNA-CRITICA */
        private void R101_RETORNA_CRITICA(bool isPerform = false)
        {
            /*" -479- MOVE '1' TO PARM-IND-RETORNO. */
            _.Move("1", LINK_ESTORNA_REPASSE.PARM_IND_RETORNO);

            /*" -479- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R100-ROTINA-CRITICA-DB-SELECT-4 */
        public void R100_ROTINA_CRITICA_DB_SELECT_4()
        {
            /*" -424- EXEC SQL SELECT COD_OPERACAO, COD_AGENCIA INTO :SINCREIN-COD-OPERACAO, :SINCREIN-COD-AGENCIA FROM SEGUROS.SINISTRO_CRED_INT WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r100_ROTINA_CRITICA_DB_SELECT_4_Query1 = new R100_ROTINA_CRITICA_DB_SELECT_4_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R100_ROTINA_CRITICA_DB_SELECT_4_Query1.Execute(r100_ROTINA_CRITICA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINCREIN_COD_OPERACAO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO);
                _.Move(executed_1.SINCREIN_COD_AGENCIA, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

        [StopWatch]
        /*" R100-ROTINA-CRITICA-DB-SELECT-5 */
        public void R100_ROTINA_CRITICA_DB_SELECT_5()
        {
            /*" -457- EXEC SQL SELECT VALUE(MIN(A.DATA_MOVIMENTO), '9999-12-31' ) INTO :HOST-MIN-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO A, SEGUROS.GE_OPERACAO B WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND B.FUNCAO_OPERACAO = 'IND' AND A.COD_OPERACAO = B.COD_OPERACAO AND B.IDE_SISTEMA = 'SI' END-EXEC. */

            var r100_ROTINA_CRITICA_DB_SELECT_5_Query1 = new R100_ROTINA_CRITICA_DB_SELECT_5_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R100_ROTINA_CRITICA_DB_SELECT_5_Query1.Execute(r100_ROTINA_CRITICA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_MIN_DATA_MOVIMENTO, HOST_MIN_DATA_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" R500-LE-SISTEMAS */
        private void R500_LE_SISTEMAS(bool isPerform = false)
        {
            /*" -487- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -492- PERFORM R500_LE_SISTEMAS_DB_SELECT_1 */

            R500_LE_SISTEMAS_DB_SELECT_1();

            /*" -495- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -497- MOVE 'ERRO NO SELECT SISTEMA - SI' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO NO SELECT SISTEMA - SI", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -498- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -498- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


        }

        [StopWatch]
        /*" R500-LE-SISTEMAS-DB-SELECT-1 */
        public void R500_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -492- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r500_LE_SISTEMAS_DB_SELECT_1_Query1 = new R500_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R500_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r500_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/

        [StopWatch]
        /*" R1000-LE-MESTSINI */
        private void R1000_LE_MESTSINI(bool isPerform = false)
        {
            /*" -511- MOVE SINISHIS-NUM-APOL-SINISTRO TO SINISMES-NUM-APOL-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);

            /*" -513- MOVE '108' TO WNR-EXEC-SQL. */
            _.Move("108", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -518- PERFORM R1000_LE_MESTSINI_DB_SELECT_1 */

            R1000_LE_MESTSINI_DB_SELECT_1();

            /*" -521- IF (SQLCODE NOT EQUAL ZERO) */

            if ((DB.SQLCODE != 00))
            {

                /*" -523- MOVE 'ERRO NO SELECT MAX SINISTRO_HISTORICO' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO NO SELECT MAX SINISTRO_HISTORICO", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -524- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -526- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -528- ADD 1 TO HOST-MAX-OCORR-HISTORICO. */
            HOST_MAX_OCORR_HISTORICO.Value = HOST_MAX_OCORR_HISTORICO + 1;

            /*" -530- MOVE '109' TO WNR-EXEC-SQL. */
            _.Move("109", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -533- PERFORM R1000_LE_MESTSINI_DB_UPDATE_1 */

            R1000_LE_MESTSINI_DB_UPDATE_1();

            /*" -536- IF (SQLCODE NOT EQUAL ZERO) */

            if ((DB.SQLCODE != 00))
            {

                /*" -538- MOVE 'ERRO NO UPDATE MAX SINISTRO_HISTORICO' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO NO UPDATE MAX SINISTRO_HISTORICO", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -539- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -544- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -546- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -551- PERFORM R1000_LE_MESTSINI_DB_SELECT_2 */

            R1000_LE_MESTSINI_DB_SELECT_2();

            /*" -554- IF (SQLCODE NOT EQUAL ZERO) */

            if ((DB.SQLCODE != 00))
            {

                /*" -556- MOVE 'ERRO NO SELECT SINISTRO_MESTRE' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO NO SELECT SINISTRO_MESTRE", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -557- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -562- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -563- ADD 1 TO SINISMES-OCORR-HISTORICO. */
            SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.Value = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO + 1;

            /*" -565- DISPLAY 'SOMA 1' */
            _.Display($"SOMA 1");

            /*" -567- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -570- PERFORM R1000_LE_MESTSINI_DB_UPDATE_2 */

            R1000_LE_MESTSINI_DB_UPDATE_2();

            /*" -573- IF (SQLCODE NOT EQUAL ZERO) */

            if ((DB.SQLCODE != 00))
            {

                /*" -575- MOVE 'ERRO NO UPDATE SINISTRO_MESTRE' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO NO UPDATE SINISTRO_MESTRE", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -576- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -578- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


            /*" -578- MOVE SINISMES-OCORR-HISTORICO TO SINISHIS-OCORR-HISTORICO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

        }

        [StopWatch]
        /*" R1000-LE-MESTSINI-DB-SELECT-1 */
        public void R1000_LE_MESTSINI_DB_SELECT_1()
        {
            /*" -518- EXEC SQL SELECT VALUE(MAX(OCORR_HISTORICO),0) INTO :HOST-MAX-OCORR-HISTORICO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO END-EXEC. */

            var r1000_LE_MESTSINI_DB_SELECT_1_Query1 = new R1000_LE_MESTSINI_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1000_LE_MESTSINI_DB_SELECT_1_Query1.Execute(r1000_LE_MESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_MAX_OCORR_HISTORICO, HOST_MAX_OCORR_HISTORICO);
            }


        }

        [StopWatch]
        /*" R1000-LE-MESTSINI-DB-UPDATE-1 */
        public void R1000_LE_MESTSINI_DB_UPDATE_1()
        {
            /*" -533- EXEC SQL UPDATE SEGUROS.SINISTRO_MESTRE SET OCORR_HISTORICO = :HOST-MAX-OCORR-HISTORICO WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO END-EXEC. */

            var r1000_LE_MESTSINI_DB_UPDATE_1_Update1 = new R1000_LE_MESTSINI_DB_UPDATE_1_Update1()
            {
                HOST_MAX_OCORR_HISTORICO = HOST_MAX_OCORR_HISTORICO.ToString(),
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            R1000_LE_MESTSINI_DB_UPDATE_1_Update1.Execute(r1000_LE_MESTSINI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" R1000-LE-MESTSINI-DB-SELECT-2 */
        public void R1000_LE_MESTSINI_DB_SELECT_2()
        {
            /*" -551- EXEC SQL SELECT OCORR_HISTORICO INTO :SINISMES-OCORR-HISTORICO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO END-EXEC. */

            var r1000_LE_MESTSINI_DB_SELECT_2_Query1 = new R1000_LE_MESTSINI_DB_SELECT_2_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1000_LE_MESTSINI_DB_SELECT_2_Query1.Execute(r1000_LE_MESTSINI_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_OCORR_HISTORICO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO);
            }


        }

        [StopWatch]
        /*" R1000-LE-MESTSINI-DB-UPDATE-2 */
        public void R1000_LE_MESTSINI_DB_UPDATE_2()
        {
            /*" -570- EXEC SQL UPDATE SEGUROS.SINISTRO_MESTRE SET OCORR_HISTORICO = :SINISMES-OCORR-HISTORICO WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO END-EXEC. */

            var r1000_LE_MESTSINI_DB_UPDATE_2_Update1 = new R1000_LE_MESTSINI_DB_UPDATE_2_Update1()
            {
                SINISMES_OCORR_HISTORICO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.ToString(),
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            R1000_LE_MESTSINI_DB_UPDATE_2_Update1.Execute(r1000_LE_MESTSINI_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1500-VALIDAR-RUNOFF */
        private void R1500_VALIDAR_RUNOFF(bool isPerform = false)
        {
            /*" -596- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -605- PERFORM R1500_VALIDAR_RUNOFF_DB_SELECT_1 */

            R1500_VALIDAR_RUNOFF_DB_SELECT_1();

            /*" -608- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -609- MOVE 'ERRO NO SELECT MIN - SI' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO NO SELECT MIN - SI", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -610- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -611- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/


                /*" -619- END-IF. */
            }


            /*" -621- IF (W-MIN-DATA-MOV-INDENIZADO LESS '2005-01-01' ) AND (SINISHIS-COD-PREST-SERVICO = 891733) */

            if ((W_MIN_DATA_MOV_INDENIZADO < "2005-01-01") && (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO == 891733))
            {

                /*" -622- MOVE '1' TO SINISHIS-SIT-CONTABIL */
                _.Move("1", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);

                /*" -622- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-VALIDAR-RUNOFF-DB-SELECT-1 */
        public void R1500_VALIDAR_RUNOFF_DB_SELECT_1()
        {
            /*" -605- EXEC SQL SELECT VALUE(MIN(A.DATA_MOVIMENTO), '9999-12-31' ) INTO :W-MIN-DATA-MOV-INDENIZADO FROM SEGUROS.SINISTRO_HISTORICO A, SEGUROS.GE_OPERACAO B WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND B.FUNCAO_OPERACAO = 'IND' AND A.COD_OPERACAO = B.COD_OPERACAO AND B.IDE_SISTEMA = 'SI' END-EXEC. */

            var r1500_VALIDAR_RUNOFF_DB_SELECT_1_Query1 = new R1500_VALIDAR_RUNOFF_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1500_VALIDAR_RUNOFF_DB_SELECT_1_Query1.Execute(r1500_VALIDAR_RUNOFF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_MIN_DATA_MOV_INDENIZADO, W_MIN_DATA_MOV_INDENIZADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_EXIT*/

        [StopWatch]
        /*" R2000-INSERT-HISTSINI */
        private void R2000_INSERT_HISTSINI(bool isPerform = false)
        {
            /*" -630- MOVE '0' TO SINISHIS-SIT-REGISTRO */
            _.Move("0", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

            /*" -631- MOVE 4290 TO SINISHIS-COD-OPERACAO. */
            _.Move(4290, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -634- MOVE SISTEMAS-DATA-MOV-ABERTO TO SINISHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);

            /*" -636- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -687- PERFORM R2000_INSERT_HISTSINI_DB_INSERT_1 */

            R2000_INSERT_HISTSINI_DB_INSERT_1();

            /*" -690- IF (SQLCODE NOT EQUAL ZERO) */

            if ((DB.SQLCODE != 00))
            {

                /*" -692- MOVE 'ERRO NO INSERT SINISTRO_HISTORICO ' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO NO INSERT SINISTRO_HISTORICO ", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -693- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -693- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


        }

        [StopWatch]
        /*" R2000-INSERT-HISTSINI-DB-INSERT-1 */
        public void R2000_INSERT_HISTSINI_DB_INSERT_1()
        {
            /*" -687- EXEC SQL INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES (:SINISHIS-COD-EMPRESA, :SINISHIS-TIPO-REGISTRO, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-DATA-MOVIMENTO, CURRENT TIME , :SINISHIS-NOME-FAVORECIDO, :SINISHIS-VAL-OPERACAO, :SINISHIS-DATA-LIM-CORRECAO, :SINISHIS-TIPO-FAVORECIDO, :SINISHIS-DATA-NEGOCIADA, :SINISHIS-FONTE-PAGAMENTO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-ORDEM-PAGAMENTO, :SINISHIS-NUM-RECIBO, :SINISHIS-NUM-MOV-SINISTRO, :SINISHIS-COD-USUARIO, :SINISHIS-SIT-CONTABIL, :SINISHIS-SIT-REGISTRO, CURRENT TIMESTAMP, :SINISHIS-NUM-APOLICE, :SINISHIS-COD-PRODUTO, 'SI1051S' ) END-EXEC. */

            var r2000_INSERT_HISTSINI_DB_INSERT_1_Insert1 = new R2000_INSERT_HISTSINI_DB_INSERT_1_Insert1()
            {
                SINISHIS_COD_EMPRESA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_EMPRESA.ToString(),
                SINISHIS_TIPO_REGISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                SINISHIS_DATA_MOVIMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.ToString(),
                SINISHIS_NOME_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO.ToString(),
                SINISHIS_VAL_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.ToString(),
                SINISHIS_DATA_LIM_CORRECAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO.ToString(),
                SINISHIS_TIPO_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO.ToString(),
                SINISHIS_DATA_NEGOCIADA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA.ToString(),
                SINISHIS_FONTE_PAGAMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_FONTE_PAGAMENTO.ToString(),
                SINISHIS_COD_PREST_SERVICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO.ToString(),
                SINISHIS_COD_SERVICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO.ToString(),
                SINISHIS_ORDEM_PAGAMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_ORDEM_PAGAMENTO.ToString(),
                SINISHIS_NUM_RECIBO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_RECIBO.ToString(),
                SINISHIS_NUM_MOV_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_MOV_SINISTRO.ToString(),
                SINISHIS_COD_USUARIO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO.ToString(),
                SINISHIS_SIT_CONTABIL = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL.ToString(),
                SINISHIS_SIT_REGISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO.ToString(),
                SINISHIS_NUM_APOLICE = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE.ToString(),
                SINISHIS_COD_PRODUTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO.ToString(),
            };

            R2000_INSERT_HISTSINI_DB_INSERT_1_Insert1.Execute(r2000_INSERT_HISTSINI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_EXIT*/

        [StopWatch]
        /*" R2100-INSERT-PARCELA */
        private void R2100_INSERT_PARCELA(bool isPerform = false)
        {
            /*" -700- MOVE SINISHIS-OCORR-HISTORICO TO SI111-OCORR-HISTORICO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO);

            /*" -702- MOVE SINISHIS-COD-OPERACAO TO SI111-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);

            /*" -704- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -743- PERFORM R2100_INSERT_PARCELA_DB_INSERT_1 */

            R2100_INSERT_PARCELA_DB_INSERT_1();

            /*" -746- IF (SQLCODE NOT EQUAL ZERO) */

            if ((DB.SQLCODE != 00))
            {

                /*" -748- MOVE 'ERRO NO INSERT SI_RESSARC_PARCELA ' TO PARM-MENSAGEM-RETORNO */
                _.Move("ERRO NO INSERT SI_RESSARC_PARCELA ", LINK_ESTORNA_REPASSE.PARM_MENSAGEM_RETORNO);

                /*" -749- MOVE SQLCODE TO PARM-SQLCODE */
                _.Move(DB.SQLCODE, LINK_ESTORNA_REPASSE.PARM_SQLCODE);

                /*" -749- PERFORM R101-RETORNA-CRITICA THRU R101-EXIT. */

                R101_RETORNA_CRITICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

            }


        }

        [StopWatch]
        /*" R2100-INSERT-PARCELA-DB-INSERT-1 */
        public void R2100_INSERT_PARCELA_DB_INSERT_1()
        {
            /*" -743- EXEC SQL INSERT INTO SEGUROS.SI_RESSARC_PARCELA (NUM_APOL_SINISTRO , OCORR_HISTORICO , COD_OPERACAO , NUM_RESSARC , SEQ_RESSARC , NUM_PARCELA , COD_AGENCIA_CEDENT , COD_SISTEMA_ORIGEM , NUM_CEDENTE , NUM_CEDENTE_DV , DTH_VENCIMENTO , NUM_NOSSO_TITULO , DTH_CADASTRAMENTO , PCT_OPERACAO , IND_FORMA_BAIXA , NOM_PROGRAMA , DTH_PAGAMENTO , IND_INTEGRACAO , NUM_TITULO_SIGCB ) VALUES (:SI111-NUM-APOL-SINISTRO, :SI111-OCORR-HISTORICO, :SI111-COD-OPERACAO, :SI111-NUM-RESSARC, :SI111-SEQ-RESSARC, :SI111-NUM-PARCELA, :SI111-COD-AGENCIA-CEDENT, :SI111-COD-SISTEMA-ORIGEM, :SI111-NUM-CEDENTE, :SI111-NUM-CEDENTE-DV, :SI111-DTH-VENCIMENTO, :SI111-NUM-NOSSO-TITULO, CURRENT TIMESTAMP, :SI111-PCT-OPERACAO, :SI111-IND-FORMA-BAIXA, 'SI1051S' , :SI111-DTH-PAGAMENTO, :SI111-IND-INTEGRACAO, :SI111-NUM-TITULO-SIGCB) END-EXEC. */

            var r2100_INSERT_PARCELA_DB_INSERT_1_Insert1 = new R2100_INSERT_PARCELA_DB_INSERT_1_Insert1()
            {
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
                SI111_OCORR_HISTORICO = SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO.ToString(),
                SI111_COD_OPERACAO = SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO.ToString(),
                SI111_NUM_RESSARC = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC.ToString(),
                SI111_SEQ_RESSARC = SI111.DCLSI_RESSARC_PARCELA.SI111_SEQ_RESSARC.ToString(),
                SI111_NUM_PARCELA = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA.ToString(),
                SI111_COD_AGENCIA_CEDENT = SI111.DCLSI_RESSARC_PARCELA.SI111_COD_AGENCIA_CEDENT.ToString(),
                SI111_COD_SISTEMA_ORIGEM = SI111.DCLSI_RESSARC_PARCELA.SI111_COD_SISTEMA_ORIGEM.ToString(),
                SI111_NUM_CEDENTE = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE.ToString(),
                SI111_NUM_CEDENTE_DV = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE_DV.ToString(),
                SI111_DTH_VENCIMENTO = SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_VENCIMENTO.ToString(),
                SI111_NUM_NOSSO_TITULO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO.ToString(),
                SI111_PCT_OPERACAO = SI111.DCLSI_RESSARC_PARCELA.SI111_PCT_OPERACAO.ToString(),
                SI111_IND_FORMA_BAIXA = SI111.DCLSI_RESSARC_PARCELA.SI111_IND_FORMA_BAIXA.ToString(),
                SI111_DTH_PAGAMENTO = SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO.ToString(),
                SI111_IND_INTEGRACAO = SI111.DCLSI_RESSARC_PARCELA.SI111_IND_INTEGRACAO.ToString(),
                SI111_NUM_TITULO_SIGCB = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_TITULO_SIGCB.ToString(),
            };

            R2100_INSERT_PARCELA_DB_INSERT_1_Insert1.Execute(r2100_INSERT_PARCELA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_EXIT*/
    }
}