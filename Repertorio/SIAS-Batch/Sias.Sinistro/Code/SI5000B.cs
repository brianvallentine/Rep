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
using Sias.Sinistro.DB2.SI5000B;

namespace Code
{
    public class SI5000B
    {
        public bool IsCall { get; set; }

        public SI5000B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO / LOTERICO                *      */
        /*"      *   PROGRAMA ...............  SI5000B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER                             *      */
        /*"      *   PROGRAMADOR ............  HEIDER                             *      */
        /*"      *   DATA CODIFICACAO .......  MAIO / 2001                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... GERACAO DOS LANCAMENTOS DE CREDITO            *      */
        /*"      *                  REFERENTE AO ADIANTAMENTO DO AVISO DO SINISTRO*      */
        /*"      *                  DA CARTEIRA DE LOTERICO                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 01/04/2005 - PRODEXTER                                         *      */
        /*"      * SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 05/05/2008 - BRSEG                                             *      */
        /*"      * INIBIR DISPLAY'S DE TRACE   -   PROCURAR POR : BR.V01          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - WELLINGTON VERAS (POLITEC)                         *      */
        /*"      *             PROJETO FGV                                        *      */
        /*"      *                                                                *      */
        /*"      * 01/09/2008  INCLUSAO DA CLAUS. WITH UR NO COMANDO SELECT-WV0908*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - OLIVEIRA                                           *      */
        /*"      *                                                                *      */
        /*"      * 23/11/2012  INCLUSAO DA SUSPENDER COB - R105                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 02/02/2015 - GUILHERME CORREIA                                 *      */
        /*"      *                                                                *      */
        /*"      *             GERA MOVIMENTO DE RESSARCIMENTO PARA CONV 600123   *      */
        /*"      *                                                                *      */
        /*"      *                               CAD 129207   PROCURAR V.01       *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-DATA-CORRENTE               PIC X(10).*/
        public StringBasis HOST_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-VALOR-AVISADO               PIC S9(13)V99 COMP-3                                                        VALUE +0*/
        public DoubleBasis HOST_VALOR_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-COD-CONVENIO                PIC S9(09) COMP    VALUE +0*/
        public IntBasis HOST_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  HOST-COUNT                       PIC S9(09) COMP    VALUE +0*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  AREA-DE-WORK.*/
        public SI5000B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI5000B_AREA_DE_WORK();
        public class SI5000B_AREA_DE_WORK : VarBasis
        {
            /*"    05 W-LIDOS                      PIC 9(05)        VALUE ZEROS*/
            public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    05 W-GRAVADOS-DEB-CC            PIC 9(05)        VALUE ZEROS*/
            public IntBasis W_GRAVADOS_DEB_CC { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    05 W-CONTA-DIAS-UTEIS           PIC 9(02)        VALUE ZEROS*/
            public IntBasis W_CONTA_DIAS_UTEIS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05 W-CONTA-PRX-DIA-UTIL-CREDITO PIC 9(02)        VALUE ZEROS*/
            public IntBasis W_CONTA_PRX_DIA_UTIL_CREDITO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05 W-CONTA-PRX-DIA-UTIL-DEBITO  PIC 9(02)        VALUE ZEROS*/
            public IntBasis W_CONTA_PRX_DIA_UTIL_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05 WS-CONTADOR                  PIC S9(04)     COMP VALUE +0*/
            public IntBasis WS_CONTADOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 W-DATA-PRX-DIA-UTIL-CREDITO  PIC X(10)       VALUE SPACES*/
            public StringBasis W_DATA_PRX_DIA_UTIL_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 W-DATA-PRX-DIA-UTIL-DEBITO   PIC X(10)       VALUE SPACES*/
            public StringBasis W_DATA_PRX_DIA_UTIL_DEBITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 W-PRODUTO-OPERACAO             PIC 9(09).*/
            public IntBasis W_PRODUTO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05 FILLER         REDEFINES       W-PRODUTO-OPERACAO.*/
            private _REDEF_SI5000B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_SI5000B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_SI5000B_FILLER_0(); _.Move(W_PRODUTO_OPERACAO, _filler_0); VarBasis.RedefinePassValue(W_PRODUTO_OPERACAO, _filler_0, W_PRODUTO_OPERACAO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_PRODUTO_OPERACAO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_PRODUTO_OPERACAO); }
            }  //Redefines
            public class _REDEF_SI5000B_FILLER_0 : VarBasis
            {
                /*"       10 FILELR                      PIC 9(01).*/
                public IntBasis FILELR { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"       10 W-PRODUTO-OPERACAO-PRODUTO  PIC 9(04).*/
                public IntBasis W_PRODUTO_OPERACAO_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 W-PRODUTO-OPERACAO-OPERACAO PIC 9(04).*/
                public IntBasis W_PRODUTO_OPERACAO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05 WFIM-SINISTROS               PIC X(03)        VALUE 'NAO'*/

                public _REDEF_SI5000B_FILLER_0()
                {
                    FILELR.ValueChanged += OnValueChanged;
                    W_PRODUTO_OPERACAO_PRODUTO.ValueChanged += OnValueChanged;
                    W_PRODUTO_OPERACAO_OPERACAO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WFIM_SINISTROS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 WABEND.*/
            public SI5000B_WABEND WABEND { get; set; } = new SI5000B_WABEND();
            public class SI5000B_WABEND : VarBasis
            {
                /*"       07 WABEND1.*/
                public SI5000B_WABEND1 WABEND1 { get; set; } = new SI5000B_WABEND1();
                public class SI5000B_WABEND1 : VarBasis
                {
                    /*"       10 FILLER         PIC  X(008)      VALUE          'SI5000B '.*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SI5000B ");
                    /*"       07 WABEND2.*/
                    public SI5000B_WABEND2 WABEND2 { get; set; } = new SI5000B_WABEND2();
                    public class SI5000B_WABEND2 : VarBasis
                    {
                        /*"       10 FILLER         PIC  X(025)      VALUE          '*** ERRO EXEC SQL NUMERO '.*/
                        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                        /*"       10 WNR-EXEC-SQL   PIC  X(004)      VALUE   '0000'.*/
                        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                        /*"       07 WABEND3.*/
                        public SI5000B_WABEND3 WABEND3 { get; set; } = new SI5000B_WABEND3();
                        public class SI5000B_WABEND3 : VarBasis
                        {
                            /*"       10 FILLER         PIC  X(013)      VALUE          ' *** SQLCODE '.*/
                            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                            /*"       10 WSQLCODE       PIC  ZZZZZ999-   VALUE    ZEROS.*/
                            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                            /*"01  LINK-PARM-CONV-PROCESSADO.*/
                        }
                    }
                }
            }
        }
        public SI5000B_LINK_PARM_CONV_PROCESSADO LINK_PARM_CONV_PROCESSADO { get; set; } = new SI5000B_LINK_PARM_CONV_PROCESSADO();
        public class SI5000B_LINK_PARM_CONV_PROCESSADO : VarBasis
        {
            /*"    05 TAMANHO-PARM                PIC S9(04) COMP.*/
            public IntBasis TAMANHO_PARM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PARM-CONV-PROCESSADO        PIC  X(06)     .*/
            public StringBasis PARM_CONV_PROCESSADO { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.LOTERI01 LOTERI01 { get; set; } = new Dclgens.LOTERI01();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.SINILT01 SINILT01 { get; set; } = new Dclgens.SINILT01();
        public Dclgens.PARAMCON PARAMCON { get; set; } = new Dclgens.PARAMCON();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SI111 SI111 { get; set; } = new Dclgens.SI111();
        public Dclgens.SI112 SI112 { get; set; } = new Dclgens.SI112();
        public SI5000B_CALENDARIO CALENDARIO { get; set; } = new SI5000B_CALENDARIO();
        public SI5000B_SINISTROS SINISTROS { get; set; } = new SI5000B_SINISTROS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SI5000B_LINK_PARM_CONV_PROCESSADO SI5000B_LINK_PARM_CONV_PROCESSADO_P) //PROCEDURE DIVISION USING 
        /*LINK_PARM_CONV_PROCESSADO*/
        {
            try
            {
                this.LINK_PARM_CONV_PROCESSADO = SI5000B_LINK_PARM_CONV_PROCESSADO_P;

                /*" -170- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -171- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -172- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -176- MOVE PARM-CONV-PROCESSADO TO HOST-COD-CONVENIO. */
                _.Move(LINK_PARM_CONV_PROCESSADO.PARM_CONV_PROCESSADO, HOST_COD_CONVENIO);

                /*" -177- DISPLAY '***************************************************' */
                _.Display($"***************************************************");

                /*" -178- DISPLAY ' CODIGO DO CONVENIO QUE ESTA SENDO PROCESSADO' */
                _.Display($" CODIGO DO CONVENIO QUE ESTA SENDO PROCESSADO");

                /*" -179- DISPLAY ' INFORMADO VIA PARM = ' PARM-CONV-PROCESSADO. */
                _.Display($" INFORMADO VIA PARM = {LINK_PARM_CONV_PROCESSADO.PARM_CONV_PROCESSADO}");

                /*" -181- DISPLAY '***************************************************' */
                _.Display($"***************************************************");

                /*" -183- PERFORM R010-SISTEMAS THRU R010-EXIT. */

                R010_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -185- PERFORM R020-DECLARE-CALENDARIO THRU R020-EXIT. */

                R020_DECLARE_CALENDARIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -196- MOVE 1 TO W-CONTA-DIAS-UTEIS. */
                _.Move(1, AREA_DE_WORK.W_CONTA_DIAS_UTEIS);

                /*" -197- IF HOST-COD-CONVENIO EQUAL 600120 */

                if (HOST_COD_CONVENIO == 600120)
                {

                    /*" -198- MOVE 2 TO W-CONTA-PRX-DIA-UTIL-CREDITO */
                    _.Move(2, AREA_DE_WORK.W_CONTA_PRX_DIA_UTIL_CREDITO);

                    /*" -199- ELSE */
                }
                else
                {


                    /*" -203- MOVE 5 TO W-CONTA-PRX-DIA-UTIL-CREDITO. */
                    _.Move(5, AREA_DE_WORK.W_CONTA_PRX_DIA_UTIL_CREDITO);
                }


                /*" -205- MOVE 5 TO W-CONTA-PRX-DIA-UTIL-DEBITO. */
                _.Move(5, AREA_DE_WORK.W_CONTA_PRX_DIA_UTIL_DEBITO);

                /*" -207- PERFORM R021-LE-PRX-DIA-UTIL THRU R021-EXIT. */

                R021_LE_PRX_DIA_UTIL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


                /*" -209- IF W-DATA-PRX-DIA-UTIL-CREDITO EQUAL SPACES OR W-DATA-PRX-DIA-UTIL-DEBITO EQUAL SPACES */

                if (AREA_DE_WORK.W_DATA_PRX_DIA_UTIL_CREDITO.IsEmpty() || AREA_DE_WORK.W_DATA_PRX_DIA_UTIL_DEBITO.IsEmpty())
                {

                    /*" -210- DISPLAY '*----------------------------------------------*' */
                    _.Display($"*----------------------------------------------*");

                    /*" -211- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -212- DISPLAY '*           PROGRAMA SI5000B                   *' */
                    _.Display($"*           PROGRAMA SI5000B                   *");

                    /*" -213- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -214- DISPLAY '*             ERRO ANORMAL                     *' */
                    _.Display($"*             ERRO ANORMAL                     *");

                    /*" -215- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -216- DISPLAY '*   NAO FOI ENCONTRADO O PROXIMO DIA UTIL      *' */
                    _.Display($"*   NAO FOI ENCONTRADO O PROXIMO DIA UTIL      *");

                    /*" -217- DISPLAY '*   NA TABELA SEGUROS.CALENDARIO               *' */
                    _.Display($"*   NA TABELA SEGUROS.CALENDARIO               *");

                    /*" -218- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -219- DISPLAY '*----------------------------------------------*' */
                    _.Display($"*----------------------------------------------*");

                    /*" -221- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -223- PERFORM R100-DECLARE-HISTSINI THRU R100-EXIT. */

                R100_DECLARE_HISTSINI(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/


                /*" -225- MOVE 'NAO' TO WFIM-SINISTROS. */
                _.Move("NAO", AREA_DE_WORK.WFIM_SINISTROS);

                /*" -227- PERFORM R101-FETCH-HISTSINI THRU R101-EXIT. */

                R101_FETCH_HISTSINI(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/


                /*" -228- IF WFIM-SINISTROS EQUAL 'SIM' */

                if (AREA_DE_WORK.WFIM_SINISTROS == "SIM")
                {

                    /*" -229- DISPLAY '*----------------------------------------------*' */
                    _.Display($"*----------------------------------------------*");

                    /*" -230- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -231- DISPLAY '*           PROGRAMA SI5000B                   *' */
                    _.Display($"*           PROGRAMA SI5000B                   *");

                    /*" -232- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -233- DISPLAY '*       SEM MOVIMENTO PARA PROCESSAMENTO       *' */
                    _.Display($"*       SEM MOVIMENTO PARA PROCESSAMENTO       *");

                    /*" -234- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -235- DISPLAY '*----------------------------------------------*' */
                    _.Display($"*----------------------------------------------*");

                    /*" -237- GO TO R0000-90-FINALIZA. */

                    R0000_90_FINALIZA(); //GOTO
                    return Result;
                }


                /*" -239- INITIALIZE DCLMOVTO-DEBITOCC-CEF. */
                _.Initialize(
                    MOVDEBCE.DCLMOVTO_DEBITOCC_CEF
                );

                /*" -240- PERFORM R200-PROCESSA-SINISTRO THRU R200-EXIT UNTIL WFIM-SINISTROS EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_SINISTROS == "SIM"))
                {

                    R200_PROCESSA_SINISTRO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

                }

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LINK_PARM_CONV_PROCESSADO, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -245- DISPLAY '*----------------------------------------------*' . */
            _.Display($"*----------------------------------------------*");

            /*" -246- DISPLAY '*                                              *' . */
            _.Display($"*                                              *");

            /*" -247- DISPLAY '*           PROGRAMA SI5000B                   *' . */
            _.Display($"*           PROGRAMA SI5000B                   *");

            /*" -248- DISPLAY '*                                              *' . */
            _.Display($"*                                              *");

            /*" -249- DISPLAY '*        TERMINO => N O R M A L                *' . */
            _.Display($"*        TERMINO => N O R M A L                *");

            /*" -250- DISPLAY '*                                              *' . */
            _.Display($"*                                              *");

            /*" -251- DISPLAY '*----------------------------------------------*' . */
            _.Display($"*----------------------------------------------*");

            /*" -252- DISPLAY 'SINISTROS LIDOS ...... ' W-LIDOS. */
            _.Display($"SINISTROS LIDOS ...... {AREA_DE_WORK.W_LIDOS}");

            /*" -254- DISPLAY 'DEBITO CC GRAVADOS ... ' W-GRAVADOS-DEB-CC. */
            _.Display($"DEBITO CC GRAVADOS ... {AREA_DE_WORK.W_GRAVADOS_DEB_CC}");

            /*" -254- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -259- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -259- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R010-SISTEMAS */
        private void R010_SISTEMAS(bool isPerform = false)
        {
            /*" -265- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -273- PERFORM R010_SISTEMAS_DB_SELECT_1 */

            R010_SISTEMAS_DB_SELECT_1();

            /*" -276- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -277- DISPLAY 'SI5000B - SISTEMA CB NAO CADASTRADO' */
                _.Display($"SI5000B - SISTEMA CB NAO CADASTRADO");

                /*" -279- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -286- DISPLAY 'DATA DO SISTEMA DE COBRANCA (CB) ' SISTEMAS-DATA-MOV-ABERTO(9:2) SISTEMAS-DATA-MOV-ABERTO(8:1) SISTEMAS-DATA-MOV-ABERTO(6:2) SISTEMAS-DATA-MOV-ABERTO(5:1) SISTEMAS-DATA-MOV-ABERTO(1:4). */

            $"DATA DO SISTEMA DE COBRANCA (CB) {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -288- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -294- PERFORM R010_SISTEMAS_DB_SELECT_2 */

            R010_SISTEMAS_DB_SELECT_2();

            /*" -297- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -298- DISPLAY 'SI5000B - SISTEMA SI NAO CADASTRADO' */
                _.Display($"SI5000B - SISTEMA SI NAO CADASTRADO");

                /*" -300- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -305- DISPLAY 'DATA DO SISTEMA DE SINISTRO (SI)' SISTEMAS-DATA-MOV-ABERTO(9:2) SISTEMAS-DATA-MOV-ABERTO(8:1) SISTEMAS-DATA-MOV-ABERTO(6:2) SISTEMAS-DATA-MOV-ABERTO(5:1) SISTEMAS-DATA-MOV-ABERTO(1:4). */

            $"DATA DO SISTEMA DE SINISTRO (SI){SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

        }

        [StopWatch]
        /*" R010-SISTEMAS-DB-SELECT-1 */
        public void R010_SISTEMAS_DB_SELECT_1()
        {
            /*" -273- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :HOST-DATA-CORRENTE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

            var r010_SISTEMAS_DB_SELECT_1_Query1 = new R010_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R010_SISTEMAS_DB_SELECT_1_Query1.Execute(r010_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.HOST_DATA_CORRENTE, HOST_DATA_CORRENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R010-SISTEMAS-DB-SELECT-2 */
        public void R010_SISTEMAS_DB_SELECT_2()
        {
            /*" -294- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

            var r010_SISTEMAS_DB_SELECT_2_Query1 = new R010_SISTEMAS_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R010_SISTEMAS_DB_SELECT_2_Query1.Execute(r010_SISTEMAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }

        [StopWatch]
        /*" R020-DECLARE-CALENDARIO */
        private void R020_DECLARE_CALENDARIO(bool isPerform = false)
        {
            /*" -313- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -327- PERFORM R020_DECLARE_CALENDARIO_DB_DECLARE_1 */

            R020_DECLARE_CALENDARIO_DB_DECLARE_1();

            /*" -329- PERFORM R020_DECLARE_CALENDARIO_DB_OPEN_1 */

            R020_DECLARE_CALENDARIO_DB_OPEN_1();

            /*" -331- IF SQLCODE < 0 */

            if (DB.SQLCODE < 0)
            {

                /*" -331- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R020-DECLARE-CALENDARIO-DB-DECLARE-1 */
        public void R020_DECLARE_CALENDARIO_DB_DECLARE_1()
        {
            /*" -327- EXEC SQL DECLARE CALENDARIO CURSOR FOR SELECT DATA_CALENDARIO, DIA_SEMANA, FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO >= DATE(CURRENT DATE) AND DATA_CALENDARIO <= DATE(CURRENT DATE) + 20 DAY AND DIA_SEMANA NOT IN ( 'S' , 'D' ) AND FERIADO <> 'N' ORDER BY DATA_CALENDARIO ASC WITH UR END-EXEC. */
            CALENDARIO = new SI5000B_CALENDARIO(false);
            string GetQuery_CALENDARIO()
            {
                var query = @$"SELECT DATA_CALENDARIO
							, 
							DIA_SEMANA
							, 
							FERIADO 
							FROM SEGUROS.CALENDARIO 
							WHERE DATA_CALENDARIO >= 
							DATE(CURRENT DATE) 
							AND DATA_CALENDARIO <= 
							DATE(CURRENT DATE) + 20 DAY 
							AND DIA_SEMANA NOT IN ( 'S'
							, 'D' ) 
							AND FERIADO <> 'N' 
							ORDER BY DATA_CALENDARIO ASC";

                return query;
            }
            CALENDARIO.GetQueryEvent += GetQuery_CALENDARIO;

        }

        [StopWatch]
        /*" R020-DECLARE-CALENDARIO-DB-OPEN-1 */
        public void R020_DECLARE_CALENDARIO_DB_OPEN_1()
        {
            /*" -329- EXEC SQL OPEN CALENDARIO END-EXEC. */

            CALENDARIO.Open();

        }

        [StopWatch]
        /*" R100-DECLARE-HISTSINI-DB-DECLARE-1 */
        public void R100_DECLARE_HISTSINI_DB_DECLARE_1()
        {
            /*" -437- EXEC SQL DECLARE SINISTROS CURSOR FOR SELECT H.NUM_APOLICE, H.NUM_APOL_SINISTRO, H.COD_OPERACAO, H.COD_PRODUTO, H.OCORR_HISTORICO, H.VAL_OPERACAO, H.SIT_REGISTRO, SL.COD_LOT_FENAL, SL.COD_LOT_CEF, SL.COD_CLIENTE, SL.DTINIVIG, C.NOME_RAZAO, A.VAL_OPERACAO AS VALOR_AVISADO, M.DATA_OCORRENCIA, P.COD_CONVENIO, P.COD_PRODUTO, P.SIT_REGISTRO, H.DATA_MOVIMENTO, C.CGCCPF FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_HISTORICO A, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.CLIENTES C, SEGUROS.GE_OPERACAO O, SEGUROS.LOTERICO01 L, SEGUROS.PARAM_CONTACEF P WHERE P.COD_CONVENIO = :HOST-COD-CONVENIO AND ( (P.SIT_REGISTRO = 'A' AND H.COD_OPERACAO = 1070 ) OR (P.SIT_REGISTRO = 'B' AND H.COD_OPERACAO IN (1071, 1072, 1073, 1074, 1040, 4000) ) OR (P.SIT_REGISTRO = 'C' AND H.COD_OPERACAO IN (1030, 1040) ) ) AND H.COD_PRODUTO = P.COD_PRODUTO AND H.COD_OPERACAO IN (1070, 4000, 1071, 1072, 1073, 1074, 1030, 1040) AND H.SIT_REGISTRO = '9' AND H.SIT_CONTABIL = '2' AND O.COD_OPERACAO = H.COD_OPERACAO AND O.FUNCAO_OPERACAO IN ( 'LIB' , 'EIND' , 'RSPPR' ) AND O.IDE_SISTEMA = 'SI' AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.COD_OPERACAO = 101 AND SL.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND L.NUM_CONTROLE_FENAL = SL.NUM_CONTROLE_FENAL AND L.COD_LOT_CEF = SL.COD_LOT_CEF AND L.COD_CLIENTE = SL.COD_CLIENTE AND L.DTINIVIG = SL.DTINIVIG AND C.COD_CLIENTE = L.COD_CLIENTE ORDER BY P.COD_PRODUTO, H.NUM_APOL_SINISTRO END-EXEC. */
            SINISTROS = new SI5000B_SINISTROS(true);
            string GetQuery_SINISTROS()
            {
                var query = @$"SELECT H.NUM_APOLICE
							, 
							H.NUM_APOL_SINISTRO
							, 
							H.COD_OPERACAO
							, 
							H.COD_PRODUTO
							, 
							H.OCORR_HISTORICO
							, 
							H.VAL_OPERACAO
							, 
							H.SIT_REGISTRO
							, 
							SL.COD_LOT_FENAL
							, 
							SL.COD_LOT_CEF
							, 
							SL.COD_CLIENTE
							, 
							SL.DTINIVIG
							, 
							C.NOME_RAZAO
							, 
							A.VAL_OPERACAO AS VALOR_AVISADO
							, 
							M.DATA_OCORRENCIA
							, 
							P.COD_CONVENIO
							, 
							P.COD_PRODUTO
							, 
							P.SIT_REGISTRO
							, 
							H.DATA_MOVIMENTO
							, 
							C.CGCCPF 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_HISTORICO A
							, 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINI_LOTERICO01 SL
							, 
							SEGUROS.CLIENTES C
							, 
							SEGUROS.GE_OPERACAO O
							, 
							SEGUROS.LOTERICO01 L
							, 
							SEGUROS.PARAM_CONTACEF P 
							WHERE P.COD_CONVENIO = '{HOST_COD_CONVENIO}' 
							AND ( (P.SIT_REGISTRO = 'A' 
							AND H.COD_OPERACAO = 1070 ) 
							OR (P.SIT_REGISTRO = 'B' 
							AND H.COD_OPERACAO IN 
							(1071
							, 1072
							, 1073
							, 1074
							, 1040
							, 4000) ) 
							OR (P.SIT_REGISTRO = 'C' 
							AND H.COD_OPERACAO IN (1030
							, 1040) ) 
							) 
							AND H.COD_PRODUTO = P.COD_PRODUTO 
							AND H.COD_OPERACAO IN (1070
							, 4000
							, 
							1071
							, 1072
							, 1073
							, 1074
							, 1030
							, 1040) 
							AND H.SIT_REGISTRO = '9' 
							AND H.SIT_CONTABIL = '2' 
							AND O.COD_OPERACAO = H.COD_OPERACAO 
							AND O.FUNCAO_OPERACAO IN ( 'LIB'
							, 'EIND'
							, 'RSPPR' ) 
							AND O.IDE_SISTEMA = 'SI' 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND A.COD_OPERACAO = 101 
							AND SL.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND L.NUM_CONTROLE_FENAL = SL.NUM_CONTROLE_FENAL 
							AND L.COD_LOT_CEF = SL.COD_LOT_CEF 
							AND L.COD_CLIENTE = SL.COD_CLIENTE 
							AND L.DTINIVIG = SL.DTINIVIG 
							AND C.COD_CLIENTE = L.COD_CLIENTE 
							ORDER BY P.COD_PRODUTO
							, H.NUM_APOL_SINISTRO";

                return query;
            }
            SINISTROS.GetQueryEvent += GetQuery_SINISTROS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R021-LE-PRX-DIA-UTIL */
        private void R021_LE_PRX_DIA_UTIL(bool isPerform = false)
        {
            /*" -338- IF W-CONTA-DIAS-UTEIS > 20 */

            if (AREA_DE_WORK.W_CONTA_DIAS_UTEIS > 20)
            {

                /*" -338- PERFORM R021_LE_PRX_DIA_UTIL_DB_CLOSE_1 */

                R021_LE_PRX_DIA_UTIL_DB_CLOSE_1();

                /*" -341- GO TO R021-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/ //GOTO
                return;
            }


            /*" -343- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -347- PERFORM R021_LE_PRX_DIA_UTIL_DB_FETCH_1 */

            R021_LE_PRX_DIA_UTIL_DB_FETCH_1();

            /*" -351- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -352- DISPLAY 'ERRO NO ACESSO DA CALENDARIO - PRX. DIA UTIL' */
                _.Display($"ERRO NO ACESSO DA CALENDARIO - PRX. DIA UTIL");

                /*" -354- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -355- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -358- DISPLAY 'DATAS SELECIONADAS ......... ' CALENDAR-DATA-CALENDARIO. */
                _.Display($"DATAS SELECIONADAS ......... {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}");
            }


            /*" -359- IF W-CONTA-DIAS-UTEIS EQUAL W-CONTA-PRX-DIA-UTIL-CREDITO */

            if (AREA_DE_WORK.W_CONTA_DIAS_UTEIS == AREA_DE_WORK.W_CONTA_PRX_DIA_UTIL_CREDITO)
            {

                /*" -361- MOVE CALENDAR-DATA-CALENDARIO TO W-DATA-PRX-DIA-UTIL-CREDITO */
                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, AREA_DE_WORK.W_DATA_PRX_DIA_UTIL_CREDITO);

                /*" -364- DISPLAY 'DATA UTILIZADA PARA CREDITO => ' W-DATA-PRX-DIA-UTIL-CREDITO. */
                _.Display($"DATA UTILIZADA PARA CREDITO => {AREA_DE_WORK.W_DATA_PRX_DIA_UTIL_CREDITO}");
            }


            /*" -365- IF W-CONTA-DIAS-UTEIS EQUAL W-CONTA-PRX-DIA-UTIL-DEBITO */

            if (AREA_DE_WORK.W_CONTA_DIAS_UTEIS == AREA_DE_WORK.W_CONTA_PRX_DIA_UTIL_DEBITO)
            {

                /*" -367- MOVE CALENDAR-DATA-CALENDARIO TO W-DATA-PRX-DIA-UTIL-DEBITO */
                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, AREA_DE_WORK.W_DATA_PRX_DIA_UTIL_DEBITO);

                /*" -370- DISPLAY 'DATA UTILIZADA PARA DEBITO  => ' W-DATA-PRX-DIA-UTIL-DEBITO. */
                _.Display($"DATA UTILIZADA PARA DEBITO  => {AREA_DE_WORK.W_DATA_PRX_DIA_UTIL_DEBITO}");
            }


            /*" -372- ADD 1 TO W-CONTA-DIAS-UTEIS. */
            AREA_DE_WORK.W_CONTA_DIAS_UTEIS.Value = AREA_DE_WORK.W_CONTA_DIAS_UTEIS + 1;

            /*" -372- GO TO R021-LE-PRX-DIA-UTIL. */
            new Task(() => R021_LE_PRX_DIA_UTIL()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R021-LE-PRX-DIA-UTIL-DB-CLOSE-1 */
        public void R021_LE_PRX_DIA_UTIL_DB_CLOSE_1()
        {
            /*" -338- EXEC SQL CLOSE CALENDARIO END-EXEC */

            CALENDARIO.Close();

        }

        [StopWatch]
        /*" R021-LE-PRX-DIA-UTIL-DB-FETCH-1 */
        public void R021_LE_PRX_DIA_UTIL_DB_FETCH_1()
        {
            /*" -347- EXEC SQL FETCH CALENDARIO INTO :CALENDAR-DATA-CALENDARIO, :CALENDAR-DIA-SEMANA, :CALENDAR-FERIADO END-EXEC. */

            if (CALENDARIO.Fetch())
            {
                _.Move(CALENDARIO.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(CALENDARIO.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(CALENDARIO.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/

        [StopWatch]
        /*" R100-DECLARE-HISTSINI */
        private void R100_DECLARE_HISTSINI(bool isPerform = false)
        {
            /*" -380- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -437- PERFORM R100_DECLARE_HISTSINI_DB_DECLARE_1 */

            R100_DECLARE_HISTSINI_DB_DECLARE_1();

            /*" -439- PERFORM R100_DECLARE_HISTSINI_DB_OPEN_1 */

            R100_DECLARE_HISTSINI_DB_OPEN_1();

            /*" -441- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -442- DISPLAY 'R100-ERRO NO OPEN CURSOR SINISTROS ' */
                _.Display($"R100-ERRO NO OPEN CURSOR SINISTROS ");

                /*" -443- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -444- END-IF */
            }


            /*" -444- . */

        }

        [StopWatch]
        /*" R100-DECLARE-HISTSINI-DB-OPEN-1 */
        public void R100_DECLARE_HISTSINI_DB_OPEN_1()
        {
            /*" -439- EXEC SQL OPEN SINISTROS END-EXEC. */

            SINISTROS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R101-FETCH-HISTSINI */
        private void R101_FETCH_HISTSINI(bool isPerform = false)
        {
            /*" -451- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -471- PERFORM R101_FETCH_HISTSINI_DB_FETCH_1 */

            R101_FETCH_HISTSINI_DB_FETCH_1();

            /*" -474- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -475- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -476- MOVE 'SIM' TO WFIM-SINISTROS */
                    _.Move("SIM", AREA_DE_WORK.WFIM_SINISTROS);

                    /*" -476- PERFORM R101_FETCH_HISTSINI_DB_CLOSE_1 */

                    R101_FETCH_HISTSINI_DB_CLOSE_1();

                    /*" -478- GO TO R101-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/ //GOTO
                    return;

                    /*" -479- ELSE */
                }
                else
                {


                    /*" -481- DISPLAY ' R101-ERRO FETCH HISTSINI ' ' SQLCODE =' SQLCODE */

                    $" R101-ERRO FETCH HISTSINI  SQLCODE ={DB.SQLCODE}"
                    .Display();

                    /*" -482- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -483- END-IF */
                }


                /*" -485- END-IF */
            }


            /*" -487- ADD 1 TO W-LIDOS. */
            AREA_DE_WORK.W_LIDOS.Value = AREA_DE_WORK.W_LIDOS + 1;

            /*" -488- PERFORM R105-00-VER-COBRANCA-SUSP THRU R105-EXIT. */

            R105_00_VER_COBRANCA_SUSP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R105_EXIT*/


            /*" -489- IF WS-CONTADOR > 0 */

            if (AREA_DE_WORK.WS_CONTADOR > 0)
            {

                /*" -495- DISPLAY 'R101-DEBITO/CREDITO - SUSPENSO ' ' LOT=' SINILT01-COD-LOT-CEF ' APO=' SINISHIS-NUM-APOLICE ' SIN=' SINISHIS-NUM-APOL-SINISTRO ' OPE=' SINISHIS-COD-OPERACAO ' VAL=' SINISHIS-VAL-OPERACAO */

                $"R101-DEBITO/CREDITO - SUSPENSO  LOT={SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF} APO={SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE} SIN={SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} OPE={SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO} VAL={SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO}"
                .Display();

                /*" -496- GO TO R101-FETCH-HISTSINI */
                new Task(() => R101_FETCH_HISTSINI()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -520- END-IF. */
            }


            /*" -522- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -523- IF HOST-COD-CONVENIO EQUAL 600119 */

                if (HOST_COD_CONVENIO == 600119)
                {

                    /*" -524- PERFORM R110-VE-SE-ESTORNO-ADIANT THRU R110-EXIT */

                    R110_VE_SE_ESTORNO_ADIANT(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


                    /*" -525- IF HOST-COUNT EQUAL ZERO */

                    if (HOST_COUNT == 00)
                    {

                        /*" -526- GO TO R101-FETCH-HISTSINI */
                        new Task(() => R101_FETCH_HISTSINI()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -527- END-IF */
                    }


                    /*" -528- END-IF */
                }


                /*" -529- END-IF */
            }


            /*" -529- . */

        }

        [StopWatch]
        /*" R101-FETCH-HISTSINI-DB-FETCH-1 */
        public void R101_FETCH_HISTSINI_DB_FETCH_1()
        {
            /*" -471- EXEC SQL FETCH SINISTROS INTO :SINISHIS-NUM-APOLICE, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-COD-OPERACAO, :SINISHIS-COD-PRODUTO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-VAL-OPERACAO, :SINISHIS-SIT-REGISTRO, :SINILT01-COD-LOT-FENAL, :SINILT01-COD-LOT-CEF, :SINILT01-COD-CLIENTE, :SINILT01-DTINIVIG, :CLIENTES-NOME-RAZAO, :HOST-VALOR-AVISADO, :SINISMES-DATA-OCORRENCIA, :PARAMCON-COD-CONVENIO, :PARAMCON-COD-PRODUTO, :PARAMCON-SIT-REGISTRO, :SINISHIS-DATA-MOVIMENTO, :CLIENTES-CGCCPF END-EXEC. */

            if (SINISTROS.Fetch())
            {
                _.Move(SINISTROS.SINISHIS_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);
                _.Move(SINISTROS.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(SINISTROS.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(SINISTROS.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
                _.Move(SINISTROS.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(SINISTROS.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(SINISTROS.SINISHIS_SIT_REGISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);
                _.Move(SINISTROS.SINILT01_COD_LOT_FENAL, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL);
                _.Move(SINISTROS.SINILT01_COD_LOT_CEF, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF);
                _.Move(SINISTROS.SINILT01_COD_CLIENTE, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_CLIENTE);
                _.Move(SINISTROS.SINILT01_DTINIVIG, SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG);
                _.Move(SINISTROS.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(SINISTROS.HOST_VALOR_AVISADO, HOST_VALOR_AVISADO);
                _.Move(SINISTROS.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(SINISTROS.PARAMCON_COD_CONVENIO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO);
                _.Move(SINISTROS.PARAMCON_COD_PRODUTO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO);
                _.Move(SINISTROS.PARAMCON_SIT_REGISTRO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_SIT_REGISTRO);
                _.Move(SINISTROS.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(SINISTROS.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }

        }

        [StopWatch]
        /*" R101-FETCH-HISTSINI-DB-CLOSE-1 */
        public void R101_FETCH_HISTSINI_DB_CLOSE_1()
        {
            /*" -476- EXEC SQL CLOSE SINISTROS END-EXEC */

            SINISTROS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

        [StopWatch]
        /*" R105-00-VER-COBRANCA-SUSP */
        private void R105_00_VER_COBRANCA_SUSP(bool isPerform = false)
        {
            /*" -540- MOVE 0 TO WS-CONTADOR */
            _.Move(0, AREA_DE_WORK.WS_CONTADOR);

            /*" -546- PERFORM R105_00_VER_COBRANCA_SUSP_DB_SELECT_1 */

            R105_00_VER_COBRANCA_SUSP_DB_SELECT_1();

            /*" -548- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -549- DISPLAY 'R105-ERRO LER LOTERICO01 ** - SQLCODE=' SQLCODE */
                _.Display($"R105-ERRO LER LOTERICO01 ** - SQLCODE={DB.SQLCODE}");

                /*" -550- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -551- END-IF */
            }


            /*" -551- . */

        }

        [StopWatch]
        /*" R105-00-VER-COBRANCA-SUSP-DB-SELECT-1 */
        public void R105_00_VER_COBRANCA_SUSP_DB_SELECT_1()
        {
            /*" -546- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-CONTADOR FROM SEGUROS.LOTERICO01 WHERE COD_LOT_FENAL = :SINILT01-COD-LOT-CEF AND OPCAO_DEP = 'S' END-EXEC. */

            var r105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1 = new R105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1()
            {
                SINILT01_COD_LOT_CEF = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF.ToString(),
            };

            var executed_1 = R105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1.Execute(r105_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CONTADOR, AREA_DE_WORK.WS_CONTADOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R105_EXIT*/

        [StopWatch]
        /*" R110-VE-SE-ESTORNO-ADIANT */
        private void R110_VE_SE_ESTORNO_ADIANT(bool isPerform = false)
        {
            /*" -559- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -567- PERFORM R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1 */

            R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1();

            /*" -570- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -571- DISPLAY 'R110-ERRO ACESSO SE CANC. ADIANTAMENTO (1070)' */
                _.Display($"R110-ERRO ACESSO SE CANC. ADIANTAMENTO (1070)");

                /*" -572- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -573- END-IF */
            }


            /*" -573- . */

        }

        [StopWatch]
        /*" R110-VE-SE-ESTORNO-ADIANT-DB-SELECT-1 */
        public void R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1()
        {
            /*" -567- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_PRODUTO = :SINISHIS-COD-PRODUTO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = 1070 END-EXEC */

            var r110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1 = new R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_PRODUTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO.ToString(),
            };

            var executed_1 = R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1.Execute(r110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R200-PROCESSA-SINISTRO */
        private void R200_PROCESSA_SINISTRO(bool isPerform = false)
        {
            /*" -582- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -606- PERFORM R200_PROCESSA_SINISTRO_DB_SELECT_1 */

            R200_PROCESSA_SINISTRO_DB_SELECT_1();

            /*" -613- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -614- DISPLAY 'R200-ERRO NO ACESSO LOTERICO01 (NUM.CONTA)' */
                _.Display($"R200-ERRO NO ACESSO LOTERICO01 (NUM.CONTA)");

                /*" -615- DISPLAY 'COD_LOT_CEF = ' SINILT01-COD-LOT-CEF */
                _.Display($"COD_LOT_CEF = {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF}");

                /*" -616- DISPLAY 'SINISTRO    = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -617- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -619- END-IF */
            }


            /*" -620- MOVE ZEROS TO MOVDEBCE-COD-EMPRESA */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);

            /*" -622- MOVE SINISHIS-NUM-APOL-SINISTRO TO MOVDEBCE-NUM-APOLICE */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -624- MOVE ZEROS TO W-PRODUTO-OPERACAO. */
            _.Move(0, AREA_DE_WORK.W_PRODUTO_OPERACAO);

            /*" -626- MOVE SINISHIS-COD-PRODUTO TO W-PRODUTO-OPERACAO-PRODUTO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO, AREA_DE_WORK.FILLER_0.W_PRODUTO_OPERACAO_PRODUTO);

            /*" -628- MOVE SINISHIS-COD-OPERACAO TO W-PRODUTO-OPERACAO-OPERACAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, AREA_DE_WORK.FILLER_0.W_PRODUTO_OPERACAO_OPERACAO);

            /*" -630- MOVE W-PRODUTO-OPERACAO TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(AREA_DE_WORK.W_PRODUTO_OPERACAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -631- MOVE SINISHIS-OCORR-HISTORICO TO MOVDEBCE-NUM-PARCELA */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -652- MOVE '0' TO MOVDEBCE-SITUACAO-COBRANCA */
            _.Move("0", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -654- MOVE ZEROS TO MOVDEBCE-VLR-CREDITO MOVDEBCE-VALOR-DEBITO. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -656- MOVE PARAMCON-COD-CONVENIO TO MOVDEBCE-COD-CONVENIO. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -657- IF SINISHIS-COD-OPERACAO EQUAL 1070 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 1070)
            {

                /*" -658- MOVE SINISHIS-VAL-OPERACAO TO MOVDEBCE-VLR-CREDITO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);

                /*" -659- ELSE */
            }
            else
            {


                /*" -660- IF SINISHIS-COD-OPERACAO EQUAL 1030 OR 1040 */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1030", "1040"))
                {

                    /*" -661- MOVE SINISHIS-VAL-OPERACAO TO MOVDEBCE-VALOR-DEBITO */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

                    /*" -663- COMPUTE MOVDEBCE-VALOR-DEBITO = MOVDEBCE-VALOR-DEBITO * -1 */
                    MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO.Value = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO * -1;

                    /*" -664- ELSE */
                }
                else
                {


                    /*" -666- IF SINISHIS-COD-OPERACAO EQUAL 1071 OR 1072 OR 1073 OR 1074 */

                    if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1071", "1072", "1073", "1074"))
                    {

                        /*" -667- IF SINISHIS-VAL-OPERACAO >= ZERO */

                        if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO >= 00)
                        {

                            /*" -668- MOVE SINISHIS-VAL-OPERACAO TO MOVDEBCE-VLR-CREDITO */
                            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);

                            /*" -669- ELSE */
                        }
                        else
                        {


                            /*" -670- MOVE SINISHIS-VAL-OPERACAO TO MOVDEBCE-VALOR-DEBITO */
                            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

                            /*" -672- COMPUTE MOVDEBCE-VALOR-DEBITO = MOVDEBCE-VALOR-DEBITO * -1 */
                            MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO.Value = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO * -1;

                            /*" -673- END-IF */
                        }


                        /*" -674- ELSE */
                    }
                    else
                    {


                        /*" -675- IF SINISHIS-COD-OPERACAO EQUAL 4000 */

                        if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 4000)
                        {

                            /*" -676- MOVE SINISHIS-VAL-OPERACAO TO MOVDEBCE-VALOR-DEBITO */
                            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

                            /*" -677- END-IF */
                        }


                        /*" -678- END-IF */
                    }


                    /*" -679- END-IF */
                }


                /*" -681- END-IF */
            }


            /*" -682- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -684- MOVE LOTERI01-AGENCIA TO MOVDEBCE-COD-AGENCIA-DEB */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_AGENCIA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -686- MOVE LOTERI01-OPERACAO-CONTA TO MOVDEBCE-OPER-CONTA-DEB */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_OPERACAO_CONTA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

            /*" -688- MOVE LOTERI01-NUMERO-CONTA TO MOVDEBCE-NUM-CONTA-DEB */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUMERO_CONTA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -691- MOVE LOTERI01-DV-CONTA TO MOVDEBCE-DIG-CONTA-DEB */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_DV_CONTA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

            /*" -692- MOVE ZEROS TO MOVDEBCE-NSAS */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -693- MOVE 'SI5000B' TO MOVDEBCE-COD-USUARIO */
            _.Move("SI5000B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -694- MOVE ZEROS TO MOVDEBCE-NUM-REQUISICAO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);

            /*" -695- MOVE ZEROS TO MOVDEBCE-NUM-CARTAO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

            /*" -696- MOVE ZEROS TO MOVDEBCE-SEQUENCIA */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA);

            /*" -698- MOVE ZEROS TO MOVDEBCE-NUM-LOTE */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE);

            /*" -699- IF MOVDEBCE-VLR-CREDITO NOT EQUAL ZERO */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO != 00)
            {

                /*" -702- MOVE W-DATA-PRX-DIA-UTIL-CREDITO TO MOVDEBCE-DATA-VENCIMENTO. */
                _.Move(AREA_DE_WORK.W_DATA_PRX_DIA_UTIL_CREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
            }


            /*" -703- IF MOVDEBCE-VALOR-DEBITO NOT EQUAL ZERO */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO != 00)
            {

                /*" -708- MOVE W-DATA-PRX-DIA-UTIL-DEBITO TO MOVDEBCE-DATA-VENCIMENTO. */
                _.Move(AREA_DE_WORK.W_DATA_PRX_DIA_UTIL_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
            }


            /*" -710- MOVE '00' TO MOVDEBCE-STATUS-CARTAO */
            _.Move("00", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO);

            /*" -712- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -768- PERFORM R200_PROCESSA_SINISTRO_DB_INSERT_1 */

            R200_PROCESSA_SINISTRO_DB_INSERT_1();

            /*" -771- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -772- DISPLAY 'ERRO INSERT MOVTO_DEBITOCC_CEF...............' */
                _.Display($"ERRO INSERT MOVTO_DEBITOCC_CEF...............");

                /*" -773- DISPLAY 'NUM. SINISTRO .... ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM. SINISTRO .... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -774- DISPLAY 'OCORHIST ......... ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST ......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -775- DISPLAY 'OPERACAO ......... ' SINISHIS-COD-OPERACAO */
                _.Display($"OPERACAO ......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

                /*" -806- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -808- ADD 1 TO W-GRAVADOS-DEB-CC. */
            AREA_DE_WORK.W_GRAVADOS_DEB_CC.Value = AREA_DE_WORK.W_GRAVADOS_DEB_CC + 1;

            /*" -815- PERFORM R210-UPDATE-SINISTROS THRU R210-EXIT. */

            R210_UPDATE_SINISTROS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/


            /*" -815- PERFORM R101-FETCH-HISTSINI THRU R101-EXIT. */

            R101_FETCH_HISTSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/


        }

        [StopWatch]
        /*" R200-PROCESSA-SINISTRO-DB-SELECT-1 */
        public void R200_PROCESSA_SINISTRO_DB_SELECT_1()
        {
            /*" -606- EXEC SQL SELECT L.BANCO, L.AGENCIA, L.OPERACAO_CONTA, L.NUMERO_CONTA, L.DV_CONTA INTO :LOTERI01-BANCO, :LOTERI01-AGENCIA, :LOTERI01-OPERACAO-CONTA, :LOTERI01-NUMERO-CONTA, :LOTERI01-DV-CONTA FROM SEGUROS.LOTERICO01 L WHERE L.COD_LOT_CEF = :SINILT01-COD-LOT-CEF AND L.COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL AND L.NUM_APOLICE = :SINISHIS-NUM-APOLICE AND L.DTTERVIG = (SELECT MAX(L.DTTERVIG) FROM SEGUROS.LOTERICO01 L WHERE L.COD_LOT_CEF = :SINILT01-COD-LOT-CEF AND L.COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL AND L.NUM_APOLICE = :SINISHIS-NUM-APOLICE) END-EXEC. */

            var r200_PROCESSA_SINISTRO_DB_SELECT_1_Query1 = new R200_PROCESSA_SINISTRO_DB_SELECT_1_Query1()
            {
                SINILT01_COD_LOT_FENAL = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL.ToString(),
                SINILT01_COD_LOT_CEF = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF.ToString(),
                SINISHIS_NUM_APOLICE = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R200_PROCESSA_SINISTRO_DB_SELECT_1_Query1.Execute(r200_PROCESSA_SINISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTERI01_BANCO, LOTERI01.DCLLOTERICO01.LOTERI01_BANCO);
                _.Move(executed_1.LOTERI01_AGENCIA, LOTERI01.DCLLOTERICO01.LOTERI01_AGENCIA);
                _.Move(executed_1.LOTERI01_OPERACAO_CONTA, LOTERI01.DCLLOTERICO01.LOTERI01_OPERACAO_CONTA);
                _.Move(executed_1.LOTERI01_NUMERO_CONTA, LOTERI01.DCLLOTERICO01.LOTERI01_NUMERO_CONTA);
                _.Move(executed_1.LOTERI01_DV_CONTA, LOTERI01.DCLLOTERICO01.LOTERI01_DV_CONTA);
            }


        }

        [StopWatch]
        /*" R200-PROCESSA-SINISTRO-DB-INSERT-1 */
        public void R200_PROCESSA_SINISTRO_DB_INSERT_1()
        {
            /*" -768- EXEC SQL INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF ( COD_EMPRESA, NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, SITUACAO_COBRANCA, DATA_VENCIMENTO, VALOR_DEBITO, DATA_MOVIMENTO, TIMESTAMP, DIA_DEBITO, COD_AGENCIA_DEB, OPER_CONTA_DEB, NUM_CONTA_DEB, DIG_CONTA_DEB, COD_CONVENIO, DATA_ENVIO, DATA_RETORNO, COD_RETORNO_CEF, NSAS, COD_USUARIO, NUM_REQUISICAO, NUM_CARTAO, SEQUENCIA, NUM_LOTE, DTCREDITO, STATUS_CARTAO, VLR_CREDITO) VALUES (:MOVDEBCE-COD-EMPRESA, :MOVDEBCE-NUM-APOLICE, :MOVDEBCE-NUM-ENDOSSO, :MOVDEBCE-NUM-PARCELA, :MOVDEBCE-SITUACAO-COBRANCA, :MOVDEBCE-DATA-VENCIMENTO, :MOVDEBCE-VALOR-DEBITO, :MOVDEBCE-DATA-MOVIMENTO, CURRENT TIMESTAMP , NULL, :MOVDEBCE-COD-AGENCIA-DEB, :MOVDEBCE-OPER-CONTA-DEB, :MOVDEBCE-NUM-CONTA-DEB, :MOVDEBCE-DIG-CONTA-DEB, :MOVDEBCE-COD-CONVENIO, NULL, NULL, NULL, :MOVDEBCE-NSAS, :MOVDEBCE-COD-USUARIO, :MOVDEBCE-NUM-REQUISICAO, :MOVDEBCE-NUM-CARTAO, :MOVDEBCE-SEQUENCIA, :MOVDEBCE-NUM-LOTE, NULL, :MOVDEBCE-STATUS-CARTAO, :MOVDEBCE-VLR-CREDITO) END-EXEC. */

            var r200_PROCESSA_SINISTRO_DB_INSERT_1_Insert1 = new R200_PROCESSA_SINISTRO_DB_INSERT_1_Insert1()
            {
                MOVDEBCE_COD_EMPRESA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_DATA_VENCIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.ToString(),
                MOVDEBCE_VALOR_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO.ToString(),
                MOVDEBCE_DATA_MOVIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.ToString(),
                MOVDEBCE_COD_AGENCIA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB.ToString(),
                MOVDEBCE_OPER_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB.ToString(),
                MOVDEBCE_NUM_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB.ToString(),
                MOVDEBCE_DIG_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
                MOVDEBCE_COD_USUARIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.ToString(),
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                MOVDEBCE_NUM_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO.ToString(),
                MOVDEBCE_SEQUENCIA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA.ToString(),
                MOVDEBCE_NUM_LOTE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE.ToString(),
                MOVDEBCE_STATUS_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO.ToString(),
                MOVDEBCE_VLR_CREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO.ToString(),
            };

            R200_PROCESSA_SINISTRO_DB_INSERT_1_Insert1.Execute(r200_PROCESSA_SINISTRO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R210-UPDATE-SINISTROS */
        private void R210_UPDATE_SINISTROS(bool isPerform = false)
        {
            /*" -823- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -828- PERFORM R210_UPDATE_SINISTROS_DB_UPDATE_1 */

            R210_UPDATE_SINISTROS_DB_UPDATE_1();

            /*" -831- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -832- DISPLAY 'ERRO UPDATE SINISTRO_HISTORICO...............' */
                _.Display($"ERRO UPDATE SINISTRO_HISTORICO...............");

                /*" -833- DISPLAY 'NUM. SINISTRO .... ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM. SINISTRO .... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -834- DISPLAY 'OCORHIST ......... ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST ......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -834- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R210-UPDATE-SINISTROS-DB-UPDATE-1 */
        public void R210_UPDATE_SINISTROS_DB_UPDATE_1()
        {
            /*" -828- EXEC SQL UPDATE SEGUROS.SINISTRO_HISTORICO SET SIT_REGISTRO = '8' WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO END-EXEC. */

            var r210_UPDATE_SINISTROS_DB_UPDATE_1_Update1 = new R210_UPDATE_SINISTROS_DB_UPDATE_1_Update1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            R210_UPDATE_SINISTROS_DB_UPDATE_1_Update1.Execute(r210_UPDATE_SINISTROS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/

        [StopWatch]
        /*" R220-GRAVA-RESSARC */
        private void R220_GRAVA_RESSARC(bool isPerform = false)
        {
            /*" -842- MOVE SINISHIS-NUM-APOL-SINISTRO TO SI112-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_APOL_SINISTRO);

            /*" -845- PERFORM R221-MAX-NUM-RESSARC THRU R221-EXIT. */

            R221_MAX_NUM_RESSARC(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R221_EXIT*/


            /*" -846- MOVE 8 TO SI112-COD-SISTEMA-ORIGEM */
            _.Move(8, SI112.DCLSI_RESSARC_ACORDO.SI112_COD_SISTEMA_ORIGEM);

            /*" -847- MOVE CLIENTES-CGCCPF TO SI112-NUM-CPFCGC-ACORDO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_CPFCGC_ACORDO);

            /*" -848- MOVE 0 TO SI112-IND-PESSOA-ACORDO */
            _.Move(0, SI112.DCLSI_RESSARC_ACORDO.SI112_IND_PESSOA_ACORDO);

            /*" -849- MOVE CLIENTES-NOME-RAZAO TO SI112-NOM-RESP-ACORDO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, SI112.DCLSI_RESSARC_ACORDO.SI112_NOM_RESP_ACORDO);

            /*" -850- MOVE 'A' TO SI112-STA-ACORDO */
            _.Move("A", SI112.DCLSI_RESSARC_ACORDO.SI112_STA_ACORDO);

            /*" -851- MOVE SINISHIS-DATA-MOVIMENTO TO SI112-DTH-ACORDO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, SI112.DCLSI_RESSARC_ACORDO.SI112_DTH_ACORDO);

            /*" -853- MOVE 1 TO SI112-QTD-PARCELAS SI112-COD-CONDICAO */
            _.Move(1, SI112.DCLSI_RESSARC_ACORDO.SI112_QTD_PARCELAS, SI112.DCLSI_RESSARC_ACORDO.SI112_COD_CONDICAO);

            /*" -856- MOVE HOST-VALOR-AVISADO TO SI112-VLR-INDENIZACAO SI112-VLR-DIVIDA SI112-VLR-TOTAL-ACORDO */
            _.Move(HOST_VALOR_AVISADO, SI112.DCLSI_RESSARC_ACORDO.SI112_VLR_INDENIZACAO, SI112.DCLSI_RESSARC_ACORDO.SI112_VLR_DIVIDA, SI112.DCLSI_RESSARC_ACORDO.SI112_VLR_TOTAL_ACORDO);

            /*" -857- MOVE 1 TO SI112-COD-MOEDA-ACORDO */
            _.Move(1, SI112.DCLSI_RESSARC_ACORDO.SI112_COD_MOEDA_ACORDO);

            /*" -858- MOVE MOVDEBCE-DATA-VENCIMENTO TO SI112-DTH-INDENIZACAO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, SI112.DCLSI_RESSARC_ACORDO.SI112_DTH_INDENIZACAO);

            /*" -861- MOVE 0 TO SI112-VLR-PART-TERCEIROS SI112-PCT-DESCONTO SI112-COD-FORNECEDOR */
            _.Move(0, SI112.DCLSI_RESSARC_ACORDO.SI112_VLR_PART_TERCEIROS, SI112.DCLSI_RESSARC_ACORDO.SI112_PCT_DESCONTO, SI112.DCLSI_RESSARC_ACORDO.SI112_COD_FORNECEDOR);

            /*" -863- MOVE 0 TO SI112-SEQ-RESSARC */
            _.Move(0, SI112.DCLSI_RESSARC_ACORDO.SI112_SEQ_RESSARC);

            /*" -865- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -910- PERFORM R220_GRAVA_RESSARC_DB_INSERT_1 */

            R220_GRAVA_RESSARC_DB_INSERT_1();

            /*" -913- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -914- DISPLAY 'ERRO INSERT SI_RESSARC_ACORDO..............' */
                _.Display($"ERRO INSERT SI_RESSARC_ACORDO..............");

                /*" -915- DISPLAY 'NUM. SINISTRO .... ' SI112-NUM-APOL-SINISTRO */
                _.Display($"NUM. SINISTRO .... {SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_APOL_SINISTRO}");

                /*" -916- DISPLAY 'NUM RESSARC....... ' SI112-NUM-RESSARC */
                _.Display($"NUM RESSARC....... {SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_RESSARC}");

                /*" -916- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R220-GRAVA-RESSARC-DB-INSERT-1 */
        public void R220_GRAVA_RESSARC_DB_INSERT_1()
        {
            /*" -910- EXEC SQL INSERT INTO SEGUROS.SI_RESSARC_ACORDO (NUM_APOL_SINISTRO, NUM_RESSARC, SEQ_RESSARC, COD_SISTEMA_ORIGEM, IND_PESSOA_ACORDO, NUM_CPFCGC_ACORDO, NOM_RESP_ACORDO, STA_ACORDO, DTH_ACORDO, QTD_PARCELAS, COD_CONDICAO, VLR_INDENIZACAO, DTH_INDENIZACAO, VLR_PART_TERCEIROS, COD_MOEDA_ACORDO, VLR_DIVIDA, PCT_DESCONTO, VLR_TOTAL_ACORDO, COD_FORNECEDOR, DTH_CADASTRAMENTO, NOM_PROGRAMA, DTH_CANCELA_ACORDO) VALUES (:SI112-NUM-APOL-SINISTRO, :SI112-NUM-RESSARC, :SI112-SEQ-RESSARC, :SI112-COD-SISTEMA-ORIGEM, :SI112-IND-PESSOA-ACORDO, :SI112-NUM-CPFCGC-ACORDO, :SI112-NOM-RESP-ACORDO, :SI112-STA-ACORDO, :SI112-DTH-ACORDO, :SI112-QTD-PARCELAS, :SI112-COD-CONDICAO, :SI112-VLR-INDENIZACAO, :SI112-DTH-INDENIZACAO, :SI112-VLR-PART-TERCEIROS, :SI112-COD-MOEDA-ACORDO, :SI112-VLR-DIVIDA, :SI112-PCT-DESCONTO, :SI112-VLR-TOTAL-ACORDO, :SI112-COD-FORNECEDOR, CURRENT TIMESTAMP, 'SI5000B' , NULL) END-EXEC. */

            var r220_GRAVA_RESSARC_DB_INSERT_1_Insert1 = new R220_GRAVA_RESSARC_DB_INSERT_1_Insert1()
            {
                SI112_NUM_APOL_SINISTRO = SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_APOL_SINISTRO.ToString(),
                SI112_NUM_RESSARC = SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_RESSARC.ToString(),
                SI112_SEQ_RESSARC = SI112.DCLSI_RESSARC_ACORDO.SI112_SEQ_RESSARC.ToString(),
                SI112_COD_SISTEMA_ORIGEM = SI112.DCLSI_RESSARC_ACORDO.SI112_COD_SISTEMA_ORIGEM.ToString(),
                SI112_IND_PESSOA_ACORDO = SI112.DCLSI_RESSARC_ACORDO.SI112_IND_PESSOA_ACORDO.ToString(),
                SI112_NUM_CPFCGC_ACORDO = SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_CPFCGC_ACORDO.ToString(),
                SI112_NOM_RESP_ACORDO = SI112.DCLSI_RESSARC_ACORDO.SI112_NOM_RESP_ACORDO.ToString(),
                SI112_STA_ACORDO = SI112.DCLSI_RESSARC_ACORDO.SI112_STA_ACORDO.ToString(),
                SI112_DTH_ACORDO = SI112.DCLSI_RESSARC_ACORDO.SI112_DTH_ACORDO.ToString(),
                SI112_QTD_PARCELAS = SI112.DCLSI_RESSARC_ACORDO.SI112_QTD_PARCELAS.ToString(),
                SI112_COD_CONDICAO = SI112.DCLSI_RESSARC_ACORDO.SI112_COD_CONDICAO.ToString(),
                SI112_VLR_INDENIZACAO = SI112.DCLSI_RESSARC_ACORDO.SI112_VLR_INDENIZACAO.ToString(),
                SI112_DTH_INDENIZACAO = SI112.DCLSI_RESSARC_ACORDO.SI112_DTH_INDENIZACAO.ToString(),
                SI112_VLR_PART_TERCEIROS = SI112.DCLSI_RESSARC_ACORDO.SI112_VLR_PART_TERCEIROS.ToString(),
                SI112_COD_MOEDA_ACORDO = SI112.DCLSI_RESSARC_ACORDO.SI112_COD_MOEDA_ACORDO.ToString(),
                SI112_VLR_DIVIDA = SI112.DCLSI_RESSARC_ACORDO.SI112_VLR_DIVIDA.ToString(),
                SI112_PCT_DESCONTO = SI112.DCLSI_RESSARC_ACORDO.SI112_PCT_DESCONTO.ToString(),
                SI112_VLR_TOTAL_ACORDO = SI112.DCLSI_RESSARC_ACORDO.SI112_VLR_TOTAL_ACORDO.ToString(),
                SI112_COD_FORNECEDOR = SI112.DCLSI_RESSARC_ACORDO.SI112_COD_FORNECEDOR.ToString(),
            };

            R220_GRAVA_RESSARC_DB_INSERT_1_Insert1.Execute(r220_GRAVA_RESSARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R220_EXIT*/

        [StopWatch]
        /*" R221-MAX-NUM-RESSARC */
        private void R221_MAX_NUM_RESSARC(bool isPerform = false)
        {
            /*" -924- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -926- MOVE ZEROS TO SI112-NUM-RESSARC */
            _.Move(0, SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_RESSARC);

            /*" -932- PERFORM R221_MAX_NUM_RESSARC_DB_SELECT_1 */

            R221_MAX_NUM_RESSARC_DB_SELECT_1();

            /*" -935- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -936- DISPLAY 'SI5000B - ERRO MAX SI_RESSARC_ACORDO' */
                _.Display($"SI5000B - ERRO MAX SI_RESSARC_ACORDO");

                /*" -937- DISPLAY 'NUM_APOL_SINISTRO = ' SI112-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO = {SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_APOL_SINISTRO}");

                /*" -938- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -939- ELSE */
            }
            else
            {


                /*" -940- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -941- MOVE 0 TO SI112-NUM-RESSARC */
                    _.Move(0, SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_RESSARC);

                    /*" -942- END-IF */
                }


                /*" -944- END-IF */
            }


            /*" -944- COMPUTE SI112-NUM-RESSARC = SI112-NUM-RESSARC + 1. */
            SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_RESSARC.Value = SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_RESSARC + 1;

        }

        [StopWatch]
        /*" R221-MAX-NUM-RESSARC-DB-SELECT-1 */
        public void R221_MAX_NUM_RESSARC_DB_SELECT_1()
        {
            /*" -932- EXEC SQL SELECT MAX((NUM_RESSARC),0) INTO :SI112-NUM-RESSARC FROM SEGUROS.SI_RESSARC_ACORDO WHERE NUM_APOL_SINISTRO = :SI112-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r221_MAX_NUM_RESSARC_DB_SELECT_1_Query1 = new R221_MAX_NUM_RESSARC_DB_SELECT_1_Query1()
            {
                SI112_NUM_APOL_SINISTRO = SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R221_MAX_NUM_RESSARC_DB_SELECT_1_Query1.Execute(r221_MAX_NUM_RESSARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SI112_NUM_RESSARC, SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_RESSARC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R221_EXIT*/

        [StopWatch]
        /*" R230-GRAVA-RESSARC-PCLA */
        private void R230_GRAVA_RESSARC_PCLA(bool isPerform = false)
        {
            /*" -951- MOVE SINISHIS-NUM-APOL-SINISTRO TO SI111-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO);

            /*" -952- MOVE SI112-NUM-RESSARC TO SI111-NUM-RESSARC */
            _.Move(SI112.DCLSI_RESSARC_ACORDO.SI112_NUM_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC);

            /*" -953- MOVE SINISHIS-OCORR-HISTORICO TO SI111-OCORR-HISTORICO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO);

            /*" -960- MOVE 0 TO SI111-SEQ-RESSARC SI111-COD-AGENCIA-CEDENT SI111-NUM-CEDENTE SI111-NUM-CEDENTE-DV SI111-IND-INTEGRACAO SI111-PCT-OPERACAO */
            _.Move(0, SI111.DCLSI_RESSARC_PARCELA.SI111_SEQ_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_AGENCIA_CEDENT, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE_DV, SI111.DCLSI_RESSARC_PARCELA.SI111_IND_INTEGRACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_PCT_OPERACAO);

            /*" -961- MOVE 8 TO SI111-COD-SISTEMA-ORIGEM */
            _.Move(8, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_SISTEMA_ORIGEM);

            /*" -962- MOVE SINISHIS-COD-OPERACAO TO SI111-COD-OPERACAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);

            /*" -964- MOVE 1 TO SI111-NUM-PARCELA SI111-IND-FORMA-BAIXA */
            _.Move(1, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA, SI111.DCLSI_RESSARC_PARCELA.SI111_IND_FORMA_BAIXA);

            /*" -966- MOVE MOVDEBCE-DATA-VENCIMENTO TO SI111-DTH-VENCIMENTO SI111-DTH-PAGAMENTO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_VENCIMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO);

            /*" -967- MOVE 0 TO SI111-NUM-NOSSO-TITULO */
            _.Move(0, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO);

            /*" -969- MOVE 0 TO SI111-NUM-TITULO-SIGCB */
            _.Move(0, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_TITULO_SIGCB);

            /*" -971- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1010- PERFORM R230_GRAVA_RESSARC_PCLA_DB_INSERT_1 */

            R230_GRAVA_RESSARC_PCLA_DB_INSERT_1();

            /*" -1013- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1014- DISPLAY 'ERRO INSERT SI_RESSARC_PARCELA.............' */
                _.Display($"ERRO INSERT SI_RESSARC_PARCELA.............");

                /*" -1015- DISPLAY 'NUM. SINISTRO .... ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM. SINISTRO .... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1016- DISPLAY 'OCORHIST ......... ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST ......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1017- DISPLAY 'OPERACAO ......... ' SINISHIS-COD-OPERACAO */
                _.Display($"OPERACAO ......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

                /*" -1018- DISPLAY 'SI111-NUM-RESSARC ' SI111-NUM-RESSARC */
                _.Display($"SI111-NUM-RESSARC {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC}");

                /*" -1019- DISPLAY 'SI111-SEQ-RESSARC ' SI111-SEQ-RESSARC */
                _.Display($"SI111-SEQ-RESSARC {SI111.DCLSI_RESSARC_PARCELA.SI111_SEQ_RESSARC}");

                /*" -1020- DISPLAY 'SI111-NUM-PARCELA ' SI111-NUM-PARCELA */
                _.Display($"SI111-NUM-PARCELA {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA}");

                /*" -1021- DISPLAY 'SI111-CODCIA-CEDENT ' SI111-COD-AGENCIA-CEDENT */
                _.Display($"SI111-CODCIA-CEDENT {SI111.DCLSI_RESSARC_PARCELA.SI111_COD_AGENCIA_CEDENT}");

                /*" -1022- DISPLAY 'SI111-CODTEMA-ORIGEM ' SI111-COD-SISTEMA-ORIGEM */
                _.Display($"SI111-CODTEMA-ORIGEM {SI111.DCLSI_RESSARC_PARCELA.SI111_COD_SISTEMA_ORIGEM}");

                /*" -1023- DISPLAY 'SI111-NUM-CEDENTE ' SI111-NUM-CEDENTE */
                _.Display($"SI111-NUM-CEDENTE {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE}");

                /*" -1024- DISPLAY 'SI111-NUM-CEDENTE-DV ' SI111-NUM-CEDENTE-DV */
                _.Display($"SI111-NUM-CEDENTE-DV {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE_DV}");

                /*" -1025- DISPLAY 'SI111-DTH-VENCIMENTO ' SI111-DTH-VENCIMENTO */
                _.Display($"SI111-DTH-VENCIMENTO {SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_VENCIMENTO}");

                /*" -1026- DISPLAY 'SI111-NUM-NOSSO-TITULO ' SI111-NUM-NOSSO-TITULO */
                _.Display($"SI111-NUM-NOSSO-TITULO {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO}");

                /*" -1027- DISPLAY 'SI111-PCT-OPERACAO ' SI111-PCT-OPERACAO */
                _.Display($"SI111-PCT-OPERACAO {SI111.DCLSI_RESSARC_PARCELA.SI111_PCT_OPERACAO}");

                /*" -1028- DISPLAY 'SI111-IND-FORMA-BAIXA ' SI111-IND-FORMA-BAIXA */
                _.Display($"SI111-IND-FORMA-BAIXA {SI111.DCLSI_RESSARC_PARCELA.SI111_IND_FORMA_BAIXA}");

                /*" -1029- DISPLAY 'SI111-IND-INTEGRACAO ' SI111-IND-INTEGRACAO */
                _.Display($"SI111-IND-INTEGRACAO {SI111.DCLSI_RESSARC_PARCELA.SI111_IND_INTEGRACAO}");

                /*" -1029- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R230-GRAVA-RESSARC-PCLA-DB-INSERT-1 */
        public void R230_GRAVA_RESSARC_PCLA_DB_INSERT_1()
        {
            /*" -1010- EXEC SQL INSERT INTO SEGUROS.SI_RESSARC_PARCELA (NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, NUM_RESSARC, SEQ_RESSARC, NUM_PARCELA, COD_AGENCIA_CEDENT, COD_SISTEMA_ORIGEM, NUM_CEDENTE, NUM_CEDENTE_DV, DTH_VENCIMENTO, NUM_NOSSO_TITULO, DTH_CADASTRAMENTO, PCT_OPERACAO, IND_FORMA_BAIXA, NOM_PROGRAMA, DTH_PAGAMENTO, IND_INTEGRACAO, NUM_TITULO_SIGCB) VALUES (:SI111-NUM-APOL-SINISTRO, :SI111-OCORR-HISTORICO, :SI111-COD-OPERACAO, :SI111-NUM-RESSARC, :SI111-SEQ-RESSARC, :SI111-NUM-PARCELA, :SI111-COD-AGENCIA-CEDENT, :SI111-COD-SISTEMA-ORIGEM, :SI111-NUM-CEDENTE, :SI111-NUM-CEDENTE-DV, :SI111-DTH-VENCIMENTO, :SI111-NUM-NOSSO-TITULO, CURRENT TIMESTAMP, :SI111-PCT-OPERACAO, :SI111-IND-FORMA-BAIXA, 'SI5000B' , :SI111-DTH-PAGAMENTO, :SI111-IND-INTEGRACAO, :SI111-NUM-TITULO-SIGCB) END-EXEC. */

            var r230_GRAVA_RESSARC_PCLA_DB_INSERT_1_Insert1 = new R230_GRAVA_RESSARC_PCLA_DB_INSERT_1_Insert1()
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

            R230_GRAVA_RESSARC_PCLA_DB_INSERT_1_Insert1.Execute(r230_GRAVA_RESSARC_PCLA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R230_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -1038- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -1039- DISPLAY ' ' */
            _.Display($" ");

            /*" -1040- DISPLAY ' ' */
            _.Display($" ");

            /*" -1041- DISPLAY ' ' */
            _.Display($" ");

            /*" -1042- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -1043- DISPLAY ' ' */
            _.Display($" ");

            /*" -1044- DISPLAY ' ' */
            _.Display($" ");

            /*" -1045- DISPLAY ' ' */
            _.Display($" ");

            /*" -1046- DISPLAY WABEND1. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1);

            /*" -1047- DISPLAY WABEND2. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2);

            /*" -1048- DISPLAY WABEND3. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3);

            /*" -1048- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1049- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1051- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1051- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK */
        private void R10010199_MENSAGEM_LOCK(bool isPerform = false)
        {
            /*" -1058- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -1061- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -1064- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -1067- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      A T E N C A O       S R.   O P E R A D O R         *WITHNOADVANCING"
            .Display();

            /*" -1070- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -1073- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1076- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                   PROGRAMA ABENDADO                     *WITHNOADVANCING"
            .Display();

            /*" -1079- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                 PROVAVELMENTE POR LOCK                  *WITHNOADVANCING"
            .Display();

            /*" -1082- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' UPON CONSOLE WITH NO ADVANCING. */

            $"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *WITHNOADVANCING"
            .Display();

            /*" -1085- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE WITH NO ADVANCING. */

            $"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *WITHNOADVANCING"
            .Display();

            /*" -1088- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1091- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *WITHNOADVANCING"
            .Display();

            /*" -1094- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1097- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1100- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE WITH NO ADVANCING. */

            $"*     SQLCODE DO ABEND ....... {AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE}WITHNOADVANCING"
            .Display();

            /*" -1103- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1109- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -1111- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1113- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1115- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -1117- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1119- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1121- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -1123- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -1125- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -1127- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -1129- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1131- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -1133- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1135- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1137- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1139- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE}");

            /*" -1141- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1141- GO TO R9999-00-ROT-ERRO. */

            R9999_00_ROT_ERRO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010199_EXIT*/
    }
}