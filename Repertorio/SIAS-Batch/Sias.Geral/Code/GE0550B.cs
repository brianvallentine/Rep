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
using Sias.Geral.DB2.GE0550B;

namespace Code
{
    public class GE0550B
    {
        public bool IsCall { get; set; }

        public GE0550B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *SINISTRO DE TESTE = 109300014843 OCOR = 26 APO = 93010000890           */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ CADASTRO E TABELAS                  *      */
        /*"      *   STORED PROCEDURE ....... GE0550B                             *      */
        /*"      *   ANALISTA ............... FAST COMPUTER                       *      */
        /*"      *   PROGRAMADOR ............ FAST COMPUTER                       *      */
        /*"      *   DATA CODIFICACAO ....... DEZEMBRO  / 2007                    *      */
        /*"      *   FUNCAO ................. PROCEDE A INCLUSAO NA ESTRUTURA     *      */
        /*"      *                            DE PESSOA/LEGADO.                   *      */
        /*"      *   GE0550B - COBOL / DB2 / CICS                                 *      */
        /*"      *   GE0550B - COBOL / DB2                                               */
        /*"      *                                                                *      */
        /*"      *  => ROTINA COBOL / CICS OU COBOL / BATCH                       *      */
        /*"      *                                                                *      */
        /*"      *   01. CADASTRA PESSOA/PENDENCIA (CB_PESS_PENDENCIA)            *      */
        /*"      *       SEGUROS.FOLLOW_UP X ODS.OD_PESSOA                        *      */
        /*"      *                                                                *      */
        /*"      *   02. CADASTRA PESSOA/RECIBO ANTECIPADO (CB_PESS_REC_ANT)      *      */
        /*"      *       SEGUROS.RCAPS X ODS.OD_PESSOA                            *      */
        /*"      *                                                                *      */
        /*"      *   03. CADASTRA PESSOA/PARCELA  (CB_PESS_PARCELA)               *      */
        /*"      *       SEGUROS.PARCELA_HISTORICO X ODS.OD_PESSOA                *      */
        /*"      *                                                                *      */
        /*"      *   04. CADASTRA PESSOA/SINISTRO (SI_PESS_SINISTRO)              *      */
        /*"      *       SEGUROS.SINISTRO_HISTORICO X ODS.OD_PESSOA               *      */
        /*"      *                                                                *      */
        /*"      *   05. CADASTRA PESSOA/VGPARCELA (VG_PESS_PARCELA)              *      */
        /*"      *       SEGUROS.COBER_HIST_VIDAZUL X ODS.OD_PESSOA               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERS�O     DATA         FEITO POR                   CADMUS     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 2         09/04/2012    DIOGO                       68465      *      */
        /*"      *           RETIRAR O ABEND SQLCODE 100 DA AD_PROGRAMA           *      */
        /*"      *                                                     PROCURE V2 *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"01  WIND-NOM-PROGRAMA             PIC S9(004) COMP VALUE +0.*/
        public IntBasis WIND_NOM_PROGRAMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WIND-COD-USUARIO              PIC S9(004) COMP VALUE +0.*/
        public IntBasis WIND_COD_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W-EDICAO                      PIC ----9.*/
        public IntBasis W_EDICAO { get; set; } = new IntBasis(new PIC("9", "5", "----9."));
        /*"01  W-IND-PONTEIRO                PIC  9(002) VALUE 0.*/
        public IntBasis W_IND_PONTEIRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"01  W-CONTA-PONTEIRO              PIC  9(002) VALUE 0.*/
        public IntBasis W_CONTA_PONTEIRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"01  W-CHAVE-GRAVA-ENDERECO        PIC  X(003) VALUE 'NAO'.*/
        public StringBasis W_CHAVE_GRAVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  W-CHAVE-GRAVA-CARTA-CREDITO   PIC  X(003) VALUE 'NAO'.*/
        public StringBasis W_CHAVE_GRAVA_CARTA_CREDITO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  W-CHAVE-GRAVA-CONTA-BANCO     PIC  X(003) VALUE 'NAO'.*/
        public StringBasis W_CHAVE_GRAVA_CONTA_BANCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  W-CHAVE-GRAVA-EMAIL           PIC  X(003) VALUE 'NAO'.*/
        public StringBasis W_CHAVE_GRAVA_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  W-CHAVE-GRAVA-TELEFONE        PIC  X(003) VALUE 'NAO'.*/
        public StringBasis W_CHAVE_GRAVA_TELEFONE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  W-CHAVE-GRAVA-PESSOA-FISICA   PIC  X(003) VALUE 'NAO'.*/
        public StringBasis W_CHAVE_GRAVA_PESSOA_FISICA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  W-CHAVE-GRAVA-PESSOA-JURIDICA PIC  X(003) VALUE 'NAO'.*/
        public StringBasis W_CHAVE_GRAVA_PESSOA_JURIDICA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  WS-AREA.*/
        public GE0550B_WS_AREA WS_AREA { get; set; } = new GE0550B_WS_AREA();
        public class GE0550B_WS_AREA : VarBasis
        {
            /*"    05    WTEM-ODPESSOA           PIC  X(003) VALUE SPACES.*/
            public StringBasis WTEM_ODPESSOA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"01        PROTOCOLO-ENVIO.*/
        }
        public GE0550B_PROTOCOLO_ENVIO PROTOCOLO_ENVIO { get; set; } = new GE0550B_PROTOCOLO_ENVIO();
        public class GE0550B_PROTOCOLO_ENVIO : VarBasis
        {
            /*"      10  OUT-COD-RETORNO               PIC S9(004) COMP.*/

            public SelectorBasis OUT_COD_RETORNO { get; set; } = new SelectorBasis("004")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 OUT-RET-VALIDO        VALUE 00. */
							new SelectorItemBasis("OUT_RET_VALIDO", "00"),
							/*" 88 OUT-RET-OPER-INVALIDA VALUE 01. */
							new SelectorItemBasis("OUT_RET_OPER_INVALIDA", "01")
                }
            };

            /*"      10  OUT-COD-RETORNO-SQL           PIC S9(004) COMP.*/
            public IntBasis OUT_COD_RETORNO_SQL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"      10  OUT-MENSAGEM                  PIC X(070).*/
            public StringBasis OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"      10  OUT-SQLERRMC                  PIC X(070).*/
            public StringBasis OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"      10  OUT-SQLSTATE                  PIC X(005).*/
            public StringBasis OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"01  PARAMETROS.*/
        }
        public GE0550B_PARAMETROS PARAMETROS { get; set; } = new GE0550B_PARAMETROS();
        public class GE0550B_PARAMETROS : VarBasis
        {
            /*"  05     LK-COD-OPERACAO        PIC S9(004) COMP.*/
            public IntBasis LK_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     LK-NUM-APOLICE         PIC S9(013) COMP-3.*/
            public IntBasis LK_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05     LK-NUM-ENDOSSO         PIC S9(009) COMP.*/
            public IntBasis LK_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05     LK-NUM-PARCELA         PIC S9(004) COMP.*/
            public IntBasis LK_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     LK-OCORR-HISTORICO     PIC S9(004) COMP.*/
            public IntBasis LK_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     LK-NUM-PESSOA          PIC S9(009) COMP.*/
            public IntBasis LK_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05     LK-NUM-OCORR-MOVTO     PIC S9(009) COMP.*/
            public IntBasis LK_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05     LK-TABELA-PONTEIRO     OCCURS  30  TIMES.*/
            public ListBasis<GE0550B_LK_TABELA_PONTEIRO> LK_TABELA_PONTEIRO { get; set; } = new ListBasis<GE0550B_LK_TABELA_PONTEIRO>(30);
            public class GE0550B_LK_TABELA_PONTEIRO : VarBasis
            {
                /*"         10 LK-IND-ENTIDADE-PEDIDA      PIC S9(004) COMP.*/
                public IntBasis LK_IND_ENTIDADE_PEDIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"         10 LK-IND-INFORMACAO-PEDIDA    PIC  X(001).*/
                public StringBasis LK_IND_INFORMACAO_PEDIDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"         10 LK-SEQ-ENTIDADE             PIC S9(004) COMP.*/
                public IntBasis LK_SEQ_ENTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05     LK-COD-EVENTO          PIC S9(004) COMP.*/
            }
            public IntBasis LK_COD_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     LK-IDE-SISTEMA         PIC  X(002).*/
            public StringBasis LK_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05     LK-DTH-MOVIMENTO       PIC  X(010).*/
            public StringBasis LK_DTH_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05     LK-IND-ESTRUTURA       PIC S9(004) COMP.*/
            public IntBasis LK_IND_ESTRUTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     LK-IND-ORIGEM-FUNC     PIC S9(004) COMP.*/
            public IntBasis LK_IND_ORIGEM_FUNC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     LK-IND-EVENTO          PIC S9(004) COMP.*/
            public IntBasis LK_IND_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     LK-NOM-PROGRAMA        PIC  X(008).*/
            public StringBasis LK_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05     LK-COD-USUARIO         PIC  X(008).*/
            public StringBasis LK_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05     LK-IND-RELACIONAMENTO  PIC S9(004) COMP.*/
            public IntBasis LK_IND_RELACIONAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     LK-HORA-OPERACAO       PIC  X(008).*/
            public StringBasis LK_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05     LK-COD-FONTE           PIC S9(004) COMP.*/
            public IntBasis LK_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     LK-NUM-RCAP            PIC S9(009) COMP.*/
            public IntBasis LK_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05     LK-NUM-APOL-SINISTRO   PIC S9(013) COMP-3.*/
            public IntBasis LK_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05     LK-COD-OPERACAO-SI     PIC S9(004) COMP.*/
            public IntBasis LK_COD_OPERACAO_SI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     LK-NUM-CERTIFICADO     PIC S9(015) COMP-3.*/
            public IntBasis LK_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05     LK-NUM-TITULO          PIC S9(013) COMP-3.*/
            public IntBasis LK_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05  H-OUT-COD-RETORNO               PIC S9(004) COMP.*/
            public IntBasis H_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  H-OUT-COD-RETORNO-SQL           PIC S9(004) COMP.*/
            public IntBasis H_OUT_COD_RETORNO_SQL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05  H-OUT-MENSAGEM                  PIC X(070).*/
            public StringBasis H_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05  H-OUT-SQLERRMC                  PIC X(070).*/
            public StringBasis H_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05  H-OUT-SQLSTATE                  PIC X(005).*/
            public StringBasis H_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        }


        public Dclgens.ABEND ABEND { get; set; } = new Dclgens.ABEND();
        public Dclgens.OD001 OD001 { get; set; } = new Dclgens.OD001();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.ADPROGRA ADPROGRA { get; set; } = new Dclgens.ADPROGRA();
        public Dclgens.SI175 SI175 { get; set; } = new Dclgens.SI175();
        public Dclgens.GE354 GE354 { get; set; } = new Dclgens.GE354();
        public Dclgens.CB039 CB039 { get; set; } = new Dclgens.CB039();
        public Dclgens.CB040 CB040 { get; set; } = new Dclgens.CB040();
        public Dclgens.CB041 CB041 { get; set; } = new Dclgens.CB041();
        public Dclgens.VG079 VG079 { get; set; } = new Dclgens.VG079();
        public Dclgens.GE366 GE366 { get; set; } = new Dclgens.GE366();
        public Dclgens.GE367 GE367 { get; set; } = new Dclgens.GE367();
        public Dclgens.GE368 GE368 { get; set; } = new Dclgens.GE368();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0550B_PARAMETROS GE0550B_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*PARAMETROS*/
        {
            try
            {
                this.PARAMETROS = GE0550B_PARAMETROS_P;

                /*" -333- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -334- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -335- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -345- MOVE LK-IDE-SISTEMA TO SISTEMAS-IDE-SISTEMA */
                _.Move(PARAMETROS.LK_IDE_SISTEMA, SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

                /*" -350- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -353- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -354- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -355- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                        _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                        /*" -356- MOVE 1 TO OUT-COD-RETORNO */
                        _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                        /*" -358- MOVE 'SISTEMA NAO CADASTRADO NA SISTEMAS' TO OUT-MENSAGEM */
                        _.Move("SISTEMA NAO CADASTRADO NA SISTEMAS", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                        /*" -359- DISPLAY 'SISTEMA NAO CADASTRADO NA SISTEMAS - ' SQLCODE */
                        _.Display($"SISTEMA NAO CADASTRADO NA SISTEMAS - {DB.SQLCODE}");

                        /*" -360- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO(); //GOTO
                        return Result;

                        /*" -361- ELSE */
                    }
                    else
                    {


                        /*" -362- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                        _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                        /*" -363- MOVE 1 TO OUT-COD-RETORNO */
                        _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                        /*" -365- MOVE 'PROBLEMAS NO ACESSO A TABELA SISTEMAS' TO OUT-MENSAGEM */
                        _.Move("PROBLEMAS NO ACESSO A TABELA SISTEMAS", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                        /*" -373- GO TO R9999-00-ROT-ERRO . */

                        R9999_00_ROT_ERRO(); //GOTO
                        return Result;
                    }

                }


                /*" -375- MOVE 'R0000' TO ABEND-COD-PROCESSO */
                _.Move("R0000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

                /*" -390- INITIALIZE OUT-COD-RETORNO H-OUT-COD-RETORNO OUT-COD-RETORNO-SQL H-OUT-COD-RETORNO-SQL OUT-MENSAGEM H-OUT-MENSAGEM OUT-SQLERRMC H-OUT-SQLERRMC OUT-SQLSTATE H-OUT-SQLSTATE. */
                _.Initialize(
                    PROTOCOLO_ENVIO.OUT_COD_RETORNO
                    , PARAMETROS.H_OUT_COD_RETORNO
                    , PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL
                    , PARAMETROS.H_OUT_COD_RETORNO_SQL
                    , PROTOCOLO_ENVIO.OUT_MENSAGEM
                    , PARAMETROS.H_OUT_MENSAGEM
                    , PROTOCOLO_ENVIO.OUT_SQLERRMC
                    , PARAMETROS.H_OUT_SQLERRMC
                    , PROTOCOLO_ENVIO.OUT_SQLSTATE
                    , PARAMETROS.H_OUT_SQLSTATE
                );

                /*" -398- PERFORM R0100-00-VERIFICA-PARAMETROS */

                R0100_00_VERIFICA_PARAMETROS_SECTION();

                /*" -398- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { PARAMETROS };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SELECT-1 */
        public void Execute_DB_SELECT_1()
        {
            /*" -350- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }

        [StopWatch]
        /*" R0100-00-VERIFICA-PARAMETROS-SECTION */
        private void R0100_00_VERIFICA_PARAMETROS_SECTION()
        {
            /*" -419- MOVE 'R0100' TO ABEND-COD-PROCESSO */
            _.Move("R0100", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -424- IF LK-COD-OPERACAO NOT EQUAL 1 AND 2 AND 3 AND 4 AND 5 */

            if (!PARAMETROS.LK_COD_OPERACAO.In("1", "2", "3", "4", "5"))
            {

                /*" -425- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -427- MOVE 'GE0550B - OPERACAO INVALIDA' TO OUT-MENSAGEM */
                _.Move("GE0550B - OPERACAO INVALIDA", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -429- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -430- IF LK-NUM-PESSOA EQUAL ZEROS */

            if (PARAMETROS.LK_NUM_PESSOA == 00)
            {

                /*" -431- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -433- MOVE 'GE0550B - NUMERO DA PESSOA INVALIDO' TO OUT-MENSAGEM */
                _.Move("GE0550B - NUMERO DA PESSOA INVALIDO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -435- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -436- IF LK-COD-EVENTO EQUAL ZEROS */

            if (PARAMETROS.LK_COD_EVENTO == 00)
            {

                /*" -437- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -439- MOVE 'GE0550B - CODIGO DO EVENTO INVALIDO' TO OUT-MENSAGEM */
                _.Move("GE0550B - CODIGO DO EVENTO INVALIDO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -441- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -442- IF LK-IDE-SISTEMA EQUAL SPACES */

            if (PARAMETROS.LK_IDE_SISTEMA.IsEmpty())
            {

                /*" -443- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -445- MOVE 'GE0550B - IDENTIFICACAO DO SISTEMA INVALIDO' TO OUT-MENSAGEM */
                _.Move("GE0550B - IDENTIFICACAO DO SISTEMA INVALIDO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -447- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -448- IF LK-IDE-SISTEMA EQUAL SPACES */

            if (PARAMETROS.LK_IDE_SISTEMA.IsEmpty())
            {

                /*" -449- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -451- MOVE 'GE0550B - IDENTIFICACAO DO SISTEMA INVALIDO' TO OUT-MENSAGEM */
                _.Move("GE0550B - IDENTIFICACAO DO SISTEMA INVALIDO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -453- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -454- IF LK-DTH-MOVIMENTO EQUAL SPACES */

            if (PARAMETROS.LK_DTH_MOVIMENTO.IsEmpty())
            {

                /*" -455- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -457- MOVE 'GE0550B - DATA MOVIMENTO INVALIDA' TO OUT-MENSAGEM */
                _.Move("GE0550B - DATA MOVIMENTO INVALIDA", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -459- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -460- IF LK-COD-EVENTO EQUAL ZEROS */

            if (PARAMETROS.LK_COD_EVENTO == 00)
            {

                /*" -461- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -463- MOVE 'GE0550B - CODIGO DO EVENTO INVALIDO' TO OUT-MENSAGEM */
                _.Move("GE0550B - CODIGO DO EVENTO INVALIDO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -473- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -478- IF LK-IND-ESTRUTURA NOT EQUAL 1 AND 2 AND 3 AND 4 AND 5 */

            if (!PARAMETROS.LK_IND_ESTRUTURA.In("1", "2", "3", "4", "5"))
            {

                /*" -479- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -481- MOVE 'GE0550B - INDICADOR DE ESTRUTURA INVALIDO' TO OUT-MENSAGEM */
                _.Move("GE0550B - INDICADOR DE ESTRUTURA INVALIDO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -492- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -499- IF LK-IND-ORIGEM-FUNC NOT EQUAL 1 AND 2 AND 3 AND 4 AND 5 AND 6 AND 7 */

            if (!PARAMETROS.LK_IND_ORIGEM_FUNC.In("1", "2", "3", "4", "5", "6", "7"))
            {

                /*" -500- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -502- MOVE 'GE0550B - INDICADOR ORIGEM FUNC  INVALIDO' TO OUT-MENSAGEM */
                _.Move("GE0550B - INDICADOR ORIGEM FUNC  INVALIDO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -513- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -519- IF LK-IND-EVENTO NOT EQUAL 1 AND 2 AND 3 AND 4 AND 5 AND 6 */

            if (!PARAMETROS.LK_IND_EVENTO.In("1", "2", "3", "4", "5", "6"))
            {

                /*" -520- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -522- MOVE 'GE0550B - INDICADOR DE EVENTO INVALIDO' TO OUT-MENSAGEM */
                _.Move("GE0550B - INDICADOR DE EVENTO INVALIDO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -565- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -566- IF LK-COD-OPERACAO EQUAL 1 */

            if (PARAMETROS.LK_COD_OPERACAO == 1)
            {

                /*" -567- IF LK-NUM-APOLICE EQUAL ZEROS */

                if (PARAMETROS.LK_NUM_APOLICE == 00)
                {

                    /*" -568- MOVE 01 TO OUT-COD-RETORNO */
                    _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -570- MOVE 'GE0550B - APOLICE OBRIGATORIA' TO OUT-MENSAGEM */
                    _.Move("GE0550B - APOLICE OBRIGATORIA", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -571- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -586- END-IF */
                }


                /*" -593- IF LK-COD-OPERACAO EQUAL 2 */

                if (PARAMETROS.LK_COD_OPERACAO == 2)
                {

                    /*" -594- IF LK-NUM-RCAP EQUAL ZEROS */

                    if (PARAMETROS.LK_NUM_RCAP == 00)
                    {

                        /*" -595- MOVE 01 TO OUT-COD-RETORNO */
                        _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                        /*" -597- MOVE 'GE0550B - RECIBO OBRIGATORIO' TO OUT-MENSAGEM */
                        _.Move("GE0550B - RECIBO OBRIGATORIO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                        /*" -601- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO(); //GOTO
                        return;
                    }

                }

            }


            /*" -602- IF LK-COD-OPERACAO EQUAL 3 */

            if (PARAMETROS.LK_COD_OPERACAO == 3)
            {

                /*" -603- IF LK-NUM-APOLICE EQUAL ZEROS */

                if (PARAMETROS.LK_NUM_APOLICE == 00)
                {

                    /*" -604- MOVE 01 TO OUT-COD-RETORNO */
                    _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -606- MOVE 'GE0550B - APOLICE OBRIGATORIA' TO OUT-MENSAGEM */
                    _.Move("GE0550B - APOLICE OBRIGATORIA", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -607- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -620- END-IF */
                }


                /*" -621- IF LK-OCORR-HISTORICO EQUAL ZEROS */

                if (PARAMETROS.LK_OCORR_HISTORICO == 00)
                {

                    /*" -622- MOVE 01 TO OUT-COD-RETORNO */
                    _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -624- MOVE 'GE0550B - OCORR HISTORICO OBRIGATORIO' TO OUT-MENSAGEM */
                    _.Move("GE0550B - OCORR HISTORICO OBRIGATORIO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -628- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -629- IF LK-COD-OPERACAO EQUAL 4 */

            if (PARAMETROS.LK_COD_OPERACAO == 4)
            {

                /*" -630- IF LK-NUM-APOL-SINISTRO EQUAL ZEROS */

                if (PARAMETROS.LK_NUM_APOL_SINISTRO == 00)
                {

                    /*" -631- MOVE 01 TO OUT-COD-RETORNO */
                    _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -633- MOVE 'GE0550B - NUMERO SINISTRO OBRIGATORIO' TO OUT-MENSAGEM */
                    _.Move("GE0550B - NUMERO SINISTRO OBRIGATORIO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -634- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -635- END-IF */
                }


                /*" -636- IF LK-OCORR-HISTORICO EQUAL ZEROS */

                if (PARAMETROS.LK_OCORR_HISTORICO == 00)
                {

                    /*" -637- MOVE 01 TO OUT-COD-RETORNO */
                    _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -639- MOVE 'GE0550B - OCORR HISTORICO SINISTRO OBRIGATORIO' TO OUT-MENSAGEM */
                    _.Move("GE0550B - OCORR HISTORICO SINISTRO OBRIGATORIO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -640- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -641- END-IF */
                }


                /*" -642- IF LK-COD-OPERACAO-SI EQUAL ZEROS */

                if (PARAMETROS.LK_COD_OPERACAO_SI == 00)
                {

                    /*" -643- MOVE 01 TO OUT-COD-RETORNO */
                    _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -645- MOVE 'GE0550B - CODIGO OPERACAO SINISTRO OBRIGATORIO' TO OUT-MENSAGEM */
                    _.Move("GE0550B - CODIGO OPERACAO SINISTRO OBRIGATORIO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -647- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -649- PERFORM R0310-00-SELECT-SISTEMAS. */

            R0310_00_SELECT_SISTEMAS_SECTION();

            /*" -651- PERFORM R0315-00-SELECT-GE354. */

            R0315_00_SELECT_GE354_SECTION();

            /*" -653- PERFORM R0300-00-SELECT-OD001. */

            R0300_00_SELECT_OD001_SECTION();

            /*" -654- IF LK-NOM-PROGRAMA NOT EQUAL SPACES */

            if (!PARAMETROS.LK_NOM_PROGRAMA.IsEmpty())
            {

                /*" -656- PERFORM R0400-00-SELECT-ADPROGRA . */

                R0400_00_SELECT_ADPROGRA_SECTION();
            }


            /*" -657- IF LK-COD-USUARIO NOT EQUAL SPACES */

            if (!PARAMETROS.LK_COD_USUARIO.IsEmpty())
            {

                /*" -659- PERFORM R0410-00-SELECT-USUARIOS . */

                R0410_00_SELECT_USUARIOS_SECTION();
            }


            /*" -660- IF LK-COD-FONTE NOT EQUAL ZEROS */

            if (PARAMETROS.LK_COD_FONTE != 00)
            {

                /*" -670- PERFORM R0420-00-SELECT-FONTES . */

                R0420_00_SELECT_FONTES_SECTION();
            }


            /*" -671- MOVE 0 TO W-CONTA-PONTEIRO. */
            _.Move(0, W_CONTA_PONTEIRO);

            /*" -672- MOVE 1 TO W-IND-PONTEIRO. */
            _.Move(1, W_IND_PONTEIRO);

            /*" -673- MOVE 'NAO' TO W-CHAVE-GRAVA-ENDERECO . */
            _.Move("NAO", W_CHAVE_GRAVA_ENDERECO);

            /*" -674- MOVE 'NAO' TO W-CHAVE-GRAVA-CARTA-CREDITO . */
            _.Move("NAO", W_CHAVE_GRAVA_CARTA_CREDITO);

            /*" -675- MOVE 'NAO' TO W-CHAVE-GRAVA-CONTA-BANCO . */
            _.Move("NAO", W_CHAVE_GRAVA_CONTA_BANCO);

            /*" -676- MOVE 'NAO' TO W-CHAVE-GRAVA-EMAIL . */
            _.Move("NAO", W_CHAVE_GRAVA_EMAIL);

            /*" -677- MOVE 'NAO' TO W-CHAVE-GRAVA-TELEFONE . */
            _.Move("NAO", W_CHAVE_GRAVA_TELEFONE);

            /*" -678- MOVE 'NAO' TO W-CHAVE-GRAVA-PESSOA-FISICA. */
            _.Move("NAO", W_CHAVE_GRAVA_PESSOA_FISICA);

            /*" -680- MOVE 'NAO' TO W-CHAVE-GRAVA-PESSOA-JURIDICA. */
            _.Move("NAO", W_CHAVE_GRAVA_PESSOA_JURIDICA);

            /*" -684- PERFORM R0200-CRITICA-ENTIDADE VARYING W-IND-PONTEIRO FROM 1 BY 1 UNTIL W-IND-PONTEIRO > 30 */

            for (W_IND_PONTEIRO.Value = 1; !(W_IND_PONTEIRO > 30); W_IND_PONTEIRO.Value += 1)
            {

                R0200_CRITICA_ENTIDADE_SECTION();
            }

            /*" -685- IF W-CONTA-PONTEIRO EQUAL 0 */

            if (W_CONTA_PONTEIRO == 0)
            {

                /*" -686- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -688- MOVE 'GE0550B - NAO FOI INFORMADA ENTIDADE P/ CADASTRO' TO OUT-MENSAGEM */
                _.Move("GE0550B - NAO FOI INFORMADA ENTIDADE P/ CADASTRO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -690- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -697- IF W-CHAVE-GRAVA-ENDERECO EQUAL 'NAO' AND W-CHAVE-GRAVA-CARTA-CREDITO EQUAL 'NAO' AND W-CHAVE-GRAVA-CONTA-BANCO EQUAL 'NAO' AND W-CHAVE-GRAVA-EMAIL EQUAL 'NAO' AND W-CHAVE-GRAVA-TELEFONE EQUAL 'NAO' AND W-CHAVE-GRAVA-PESSOA-FISICA EQUAL 'NAO' AND W-CHAVE-GRAVA-PESSOA-JURIDICA EQUAL 'NAO' */

            if (W_CHAVE_GRAVA_ENDERECO == "NAO" && W_CHAVE_GRAVA_CARTA_CREDITO == "NAO" && W_CHAVE_GRAVA_CONTA_BANCO == "NAO" && W_CHAVE_GRAVA_EMAIL == "NAO" && W_CHAVE_GRAVA_TELEFONE == "NAO" && W_CHAVE_GRAVA_PESSOA_FISICA == "NAO" && W_CHAVE_GRAVA_PESSOA_JURIDICA == "NAO")
            {

                /*" -698- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -700- MOVE 'GE0550B - ENTIDADE DE GRAVACAO NAO PREVISTA' TO OUT-MENSAGEM */
                _.Move("GE0550B - ENTIDADE DE GRAVACAO NAO PREVISTA", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -704- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -708- PERFORM R0900-00-SELECT-GE366. */

            R0900_00_SELECT_GE366_SECTION();

            /*" -712- PERFORM R0910-00-INSERT-GE366. */

            R0910_00_INSERT_GE366_SECTION();

            /*" -716- PERFORM R0920-00-INSERT-GE367. */

            R0920_00_INSERT_GE367_SECTION();

            /*" -717- IF W-CHAVE-GRAVA-ENDERECO EQUAL 'SIM' */

            if (W_CHAVE_GRAVA_ENDERECO == "SIM")
            {

                /*" -718- MOVE 1 TO W-IND-PONTEIRO */
                _.Move(1, W_IND_PONTEIRO);

                /*" -720- PERFORM R0930-00-INSERT-GE368 . */

                R0930_00_INSERT_GE368_SECTION();
            }


            /*" -721- IF W-CHAVE-GRAVA-CARTA-CREDITO EQUAL 'SIM' */

            if (W_CHAVE_GRAVA_CARTA_CREDITO == "SIM")
            {

                /*" -722- MOVE 2 TO W-IND-PONTEIRO */
                _.Move(2, W_IND_PONTEIRO);

                /*" -724- PERFORM R0930-00-INSERT-GE368 . */

                R0930_00_INSERT_GE368_SECTION();
            }


            /*" -725- IF W-CHAVE-GRAVA-CONTA-BANCO EQUAL 'SIM' */

            if (W_CHAVE_GRAVA_CONTA_BANCO == "SIM")
            {

                /*" -726- MOVE 3 TO W-IND-PONTEIRO */
                _.Move(3, W_IND_PONTEIRO);

                /*" -728- PERFORM R0930-00-INSERT-GE368 . */

                R0930_00_INSERT_GE368_SECTION();
            }


            /*" -729- IF W-CHAVE-GRAVA-EMAIL EQUAL 'SIM' */

            if (W_CHAVE_GRAVA_EMAIL == "SIM")
            {

                /*" -730- MOVE 4 TO W-IND-PONTEIRO */
                _.Move(4, W_IND_PONTEIRO);

                /*" -732- PERFORM R0930-00-INSERT-GE368 . */

                R0930_00_INSERT_GE368_SECTION();
            }


            /*" -733- IF W-CHAVE-GRAVA-TELEFONE EQUAL 'SIM' */

            if (W_CHAVE_GRAVA_TELEFONE == "SIM")
            {

                /*" -734- MOVE 5 TO W-IND-PONTEIRO */
                _.Move(5, W_IND_PONTEIRO);

                /*" -736- PERFORM R0930-00-INSERT-GE368 . */

                R0930_00_INSERT_GE368_SECTION();
            }


            /*" -737- IF W-CHAVE-GRAVA-PESSOA-FISICA EQUAL 'SIM' */

            if (W_CHAVE_GRAVA_PESSOA_FISICA == "SIM")
            {

                /*" -738- MOVE 6 TO W-IND-PONTEIRO */
                _.Move(6, W_IND_PONTEIRO);

                /*" -740- PERFORM R0930-00-INSERT-GE368 . */

                R0930_00_INSERT_GE368_SECTION();
            }


            /*" -741- IF W-CHAVE-GRAVA-PESSOA-JURIDICA EQUAL 'SIM' */

            if (W_CHAVE_GRAVA_PESSOA_JURIDICA == "SIM")
            {

                /*" -742- MOVE 7 TO W-IND-PONTEIRO */
                _.Move(7, W_IND_PONTEIRO);

                /*" -749- PERFORM R0930-00-INSERT-GE368 . */

                R0930_00_INSERT_GE368_SECTION();
            }


            /*" -750- IF LK-COD-OPERACAO EQUAL 1 */

            if (PARAMETROS.LK_COD_OPERACAO == 1)
            {

                /*" -751- PERFORM R1000-00-PROCESSA-OPERACAO-1 */

                R1000_00_PROCESSA_OPERACAO_1_SECTION();

                /*" -752- ELSE */
            }
            else
            {


                /*" -753- IF LK-COD-OPERACAO EQUAL 2 */

                if (PARAMETROS.LK_COD_OPERACAO == 2)
                {

                    /*" -754- PERFORM R2000-00-PROCESSA-OPERACAO-2 */

                    R2000_00_PROCESSA_OPERACAO_2_SECTION();

                    /*" -755- ELSE */
                }
                else
                {


                    /*" -756- IF LK-COD-OPERACAO EQUAL 3 */

                    if (PARAMETROS.LK_COD_OPERACAO == 3)
                    {

                        /*" -757- PERFORM R3000-00-PROCESSA-OPERACAO-3 */

                        R3000_00_PROCESSA_OPERACAO_3_SECTION();

                        /*" -758- ELSE */
                    }
                    else
                    {


                        /*" -759- IF LK-COD-OPERACAO EQUAL 4 */

                        if (PARAMETROS.LK_COD_OPERACAO == 4)
                        {

                            /*" -760- PERFORM R4000-00-PROCESSA-OPERACAO-4 */

                            R4000_00_PROCESSA_OPERACAO_4_SECTION();

                            /*" -761- ELSE */
                        }
                        else
                        {


                            /*" -762- IF LK-COD-OPERACAO EQUAL 5 */

                            if (PARAMETROS.LK_COD_OPERACAO == 5)
                            {

                                /*" -762- PERFORM R5000-00-PROCESSA-OPERACAO-5 . */

                                R5000_00_PROCESSA_OPERACAO_5_SECTION();
                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_EXIT*/

        [StopWatch]
        /*" R0200-CRITICA-ENTIDADE-SECTION */
        private void R0200_CRITICA_ENTIDADE_SECTION()
        {
            /*" -770- IF (LK-IND-ENTIDADE-PEDIDA(W-IND-PONTEIRO) NOT EQUAL 0) AND (LK-SEQ-ENTIDADE(W-IND-PONTEIRO) NOT EQUAL 0) */

            if ((PARAMETROS.LK_TABELA_PONTEIRO[W_IND_PONTEIRO].LK_IND_ENTIDADE_PEDIDA != 0) && (PARAMETROS.LK_TABELA_PONTEIRO[W_IND_PONTEIRO].LK_SEQ_ENTIDADE != 0))
            {

                /*" -771- ADD 1 TO W-CONTA-PONTEIRO */
                W_CONTA_PONTEIRO.Value = W_CONTA_PONTEIRO + 1;

                /*" -772- IF W-IND-PONTEIRO EQUAL 1 */

                if (W_IND_PONTEIRO == 1)
                {

                    /*" -773- MOVE 'SIM' TO W-CHAVE-GRAVA-ENDERECO */
                    _.Move("SIM", W_CHAVE_GRAVA_ENDERECO);

                    /*" -774- ELSE */
                }
                else
                {


                    /*" -775- IF W-IND-PONTEIRO EQUAL 2 */

                    if (W_IND_PONTEIRO == 2)
                    {

                        /*" -776- MOVE 'SIM' TO W-CHAVE-GRAVA-CARTA-CREDITO */
                        _.Move("SIM", W_CHAVE_GRAVA_CARTA_CREDITO);

                        /*" -777- ELSE */
                    }
                    else
                    {


                        /*" -778- IF W-IND-PONTEIRO EQUAL 3 */

                        if (W_IND_PONTEIRO == 3)
                        {

                            /*" -779- MOVE 'SIM' TO W-CHAVE-GRAVA-CONTA-BANCO */
                            _.Move("SIM", W_CHAVE_GRAVA_CONTA_BANCO);

                            /*" -780- ELSE */
                        }
                        else
                        {


                            /*" -781- IF W-IND-PONTEIRO EQUAL 4 */

                            if (W_IND_PONTEIRO == 4)
                            {

                                /*" -782- MOVE 'SIM' TO W-CHAVE-GRAVA-EMAIL */
                                _.Move("SIM", W_CHAVE_GRAVA_EMAIL);

                                /*" -783- ELSE */
                            }
                            else
                            {


                                /*" -784- IF W-IND-PONTEIRO EQUAL 5 */

                                if (W_IND_PONTEIRO == 5)
                                {

                                    /*" -784- MOVE 'SIM' TO W-CHAVE-GRAVA-TELEFONE . */
                                    _.Move("SIM", W_CHAVE_GRAVA_TELEFONE);
                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_EXIT*/

        [StopWatch]
        /*" R0300-00-SELECT-OD001-SECTION */
        private void R0300_00_SELECT_OD001_SECTION()
        {
            /*" -794- MOVE 'R0300' TO ABEND-COD-PROCESSO */
            _.Move("R0300", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -796- MOVE LK-NUM-PESSOA TO OD001-NUM-PESSOA */
            _.Move(PARAMETROS.LK_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);

            /*" -801- PERFORM R0300_00_SELECT_OD001_DB_SELECT_1 */

            R0300_00_SELECT_OD001_DB_SELECT_1();

            /*" -804- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -805- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -806- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                    _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                    /*" -807- MOVE 1 TO OUT-COD-RETORNO */
                    _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -809- MOVE 'PESSOA NAO CADASTRADA NA ODS.OD_PESSOA' TO OUT-MENSAGEM */
                    _.Move("PESSOA NAO CADASTRADA NA ODS.OD_PESSOA", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -810- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -811- ELSE */
                }
                else
                {


                    /*" -812- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                    _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                    /*" -813- MOVE 1 TO OUT-COD-RETORNO */
                    _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -815- MOVE 'PROBLEMAS NO ACESSO A TABELA ODS.OD_PESSOA' TO OUT-MENSAGEM */
                    _.Move("PROBLEMAS NO ACESSO A TABELA ODS.OD_PESSOA", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -815- GO TO R9999-00-ROT-ERRO . */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0300-00-SELECT-OD001-DB-SELECT-1 */
        public void R0300_00_SELECT_OD001_DB_SELECT_1()
        {
            /*" -801- EXEC SQL SELECT NUM_DV_PESSOA INTO :OD001-NUM-DV-PESSOA FROM ODS.OD_PESSOA WHERE NUM_PESSOA = :OD001-NUM-PESSOA END-EXEC. */

            var r0300_00_SELECT_OD001_DB_SELECT_1_Query1 = new R0300_00_SELECT_OD001_DB_SELECT_1_Query1()
            {
                OD001_NUM_PESSOA = OD001.DCLOD_PESSOA.OD001_NUM_PESSOA.ToString(),
            };

            var executed_1 = R0300_00_SELECT_OD001_DB_SELECT_1_Query1.Execute(r0300_00_SELECT_OD001_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD001_NUM_DV_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-SELECT-SISTEMAS-SECTION */
        private void R0310_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -825- MOVE 'R0310' TO ABEND-COD-PROCESSO */
            _.Move("R0310", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -827- MOVE LK-IDE-SISTEMA TO SISTEMAS-IDE-SISTEMA */
            _.Move(PARAMETROS.LK_IDE_SISTEMA, SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -832- PERFORM R0310_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0310_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -835- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -836- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -837- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                    _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                    /*" -838- MOVE 1 TO OUT-COD-RETORNO */
                    _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -840- MOVE 'SISTEMA NAO CADASTRADO NA SISTEMAS' TO OUT-MENSAGEM */
                    _.Move("SISTEMA NAO CADASTRADO NA SISTEMAS", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -841- DISPLAY 'SISTEMA NAO CADASTRADO NA SISTEMAS - ' SQLCODE */
                    _.Display($"SISTEMA NAO CADASTRADO NA SISTEMAS - {DB.SQLCODE}");

                    /*" -842- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -843- ELSE */
                }
                else
                {


                    /*" -844- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                    _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                    /*" -845- MOVE 1 TO OUT-COD-RETORNO */
                    _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -847- MOVE 'PROBLEMAS NO ACESSO A TABELA SISTEMAS' TO OUT-MENSAGEM */
                    _.Move("PROBLEMAS NO ACESSO A TABELA SISTEMAS", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -847- GO TO R9999-00-ROT-ERRO . */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0310-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0310_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -832- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA END-EXEC. */

            var r0310_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0310_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0310_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0310_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0315-00-SELECT-GE354-SECTION */
        private void R0315_00_SELECT_GE354_SECTION()
        {
            /*" -861- MOVE 'R0315' TO ABEND-COD-PROCESSO */
            _.Move("R0315", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -862- MOVE LK-COD-EVENTO TO GE354-COD-EVENTO */
            _.Move(PARAMETROS.LK_COD_EVENTO, GE354.DCLGE_EVENTO.GE354_COD_EVENTO);

            /*" -864- MOVE LK-IDE-SISTEMA TO GE354-IDE-SISTEMA */
            _.Move(PARAMETROS.LK_IDE_SISTEMA, GE354.DCLGE_EVENTO.GE354_IDE_SISTEMA);

            /*" -870- PERFORM R0315_00_SELECT_GE354_DB_SELECT_1 */

            R0315_00_SELECT_GE354_DB_SELECT_1();

            /*" -873- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -874- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -875- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                    _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                    /*" -876- MOVE 1 TO OUT-COD-RETORNO */
                    _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -878- MOVE 'EVENTO NAO CADASTRADO NA GE_EVENTO' TO OUT-MENSAGEM */
                    _.Move("EVENTO NAO CADASTRADO NA GE_EVENTO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -879- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -880- ELSE */
                }
                else
                {


                    /*" -881- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                    _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                    /*" -882- MOVE 1 TO OUT-COD-RETORNO */
                    _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -884- MOVE 'PROBLEMAS NO ACESSO A TABELA GE_EVENTO' TO OUT-MENSAGEM */
                    _.Move("PROBLEMAS NO ACESSO A TABELA GE_EVENTO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -885- DISPLAY 'PROBLEMAS NO ACESSO A TABELA GE_EVENTO' */
                    _.Display($"PROBLEMAS NO ACESSO A TABELA GE_EVENTO");

                    /*" -886- DISPLAY 'GE354-COD-EVENTO...... ' GE354-COD-EVENTO */
                    _.Display($"GE354-COD-EVENTO...... {GE354.DCLGE_EVENTO.GE354_COD_EVENTO}");

                    /*" -887- DISPLAY 'GE354-IDE-SISTEMA..... ' GE354-IDE-SISTEMA */
                    _.Display($"GE354-IDE-SISTEMA..... {GE354.DCLGE_EVENTO.GE354_IDE_SISTEMA}");

                    /*" -887- GO TO R9999-00-ROT-ERRO . */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0315-00-SELECT-GE354-DB-SELECT-1 */
        public void R0315_00_SELECT_GE354_DB_SELECT_1()
        {
            /*" -870- EXEC SQL SELECT DES_EVENTO INTO :GE354-DES-EVENTO FROM SEGUROS.GE_EVENTO WHERE COD_EVENTO = :GE354-COD-EVENTO AND IDE_SISTEMA = :GE354-IDE-SISTEMA END-EXEC. */

            var r0315_00_SELECT_GE354_DB_SELECT_1_Query1 = new R0315_00_SELECT_GE354_DB_SELECT_1_Query1()
            {
                GE354_IDE_SISTEMA = GE354.DCLGE_EVENTO.GE354_IDE_SISTEMA.ToString(),
                GE354_COD_EVENTO = GE354.DCLGE_EVENTO.GE354_COD_EVENTO.ToString(),
            };

            var executed_1 = R0315_00_SELECT_GE354_DB_SELECT_1_Query1.Execute(r0315_00_SELECT_GE354_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE354_DES_EVENTO, GE354.DCLGE_EVENTO.GE354_DES_EVENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0315_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-SELECT-ADPROGRA-SECTION */
        private void R0400_00_SELECT_ADPROGRA_SECTION()
        {
            /*" -901- MOVE 'R0400' TO ABEND-COD-PROCESSO */
            _.Move("R0400", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -903- MOVE LK-NOM-PROGRAMA TO ADPROGRA-NOM-PROGRAMA */
            _.Move(PARAMETROS.LK_NOM_PROGRAMA, ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_NOM_PROGRAMA);

            /*" -908- PERFORM R0400_00_SELECT_ADPROGRA_DB_SELECT_1 */

            R0400_00_SELECT_ADPROGRA_DB_SELECT_1();

            /*" -918- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -919- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -920- MOVE 1 TO OUT-COD-RETORNO */
                _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -922- MOVE 'PROBLEMAS NO ACESSO A TABELA AD_PROGRAMA' TO OUT-MENSAGEM */
                _.Move("PROBLEMAS NO ACESSO A TABELA AD_PROGRAMA", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -924- GO TO R9999-00-ROT-ERRO . */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -925- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -925- PERFORM R0405-00-INSERT-PROGRAMAS. */

                R0405_00_INSERT_PROGRAMAS_SECTION();
            }


        }

        [StopWatch]
        /*" R0400-00-SELECT-ADPROGRA-DB-SELECT-1 */
        public void R0400_00_SELECT_ADPROGRA_DB_SELECT_1()
        {
            /*" -908- EXEC SQL SELECT DTH_INCLUSAO INTO :ADPROGRA-DTH-INCLUSAO FROM SEGUROS.AD_PROGRAMA WHERE NOM_PROGRAMA = :ADPROGRA-NOM-PROGRAMA END-EXEC. */

            var r0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1 = new R0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1()
            {
                ADPROGRA_NOM_PROGRAMA = ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_NOM_PROGRAMA.ToString(),
            };

            var executed_1 = R0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1.Execute(r0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ADPROGRA_DTH_INCLUSAO, ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_DTH_INCLUSAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0405-00-INSERT-PROGRAMAS-SECTION */
        private void R0405_00_INSERT_PROGRAMAS_SECTION()
        {
            /*" -937- MOVE 'GE0550B' TO ADPROGRA-NOM-PROGRAMA */
            _.Move("GE0550B", ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_NOM_PROGRAMA);

            /*" -938- MOVE SISTEMAS-DATA-MOV-ABERTO TO ADPROGRA-DTH-INCLUSAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_DTH_INCLUSAO);

            /*" -939- MOVE SISTEMAS-DATA-MOV-ABERTO TO ADPROGRA-DTH-COMPILACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_DTH_COMPILACAO);

            /*" -940- MOVE 0 TO ADPROGRA-IND-PROGRAMA. */
            _.Move(0, ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_IND_PROGRAMA);

            /*" -941- MOVE 'S' TO ADPROGRA-STA-DCLGEN. */
            _.Move("S", ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_STA_DCLGEN);

            /*" -942- MOVE 'B' TO ADPROGRA-STA-AMBIENTE. */
            _.Move("B", ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_STA_AMBIENTE);

            /*" -944- MOVE 'CARGA DA PESSOA / LEAGADO' TO ADPROGRA-DES-PROGRAMA. */
            _.Move("CARGA DA PESSOA / LEAGADO", ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_DES_PROGRAMA);

            /*" -946- MOVE 'TE21425' TO ADPROGRA-COD-USUARIO. */
            _.Move("TE21425", ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_COD_USUARIO);

            /*" -967- PERFORM R0405_00_INSERT_PROGRAMAS_DB_INSERT_1 */

            R0405_00_INSERT_PROGRAMAS_DB_INSERT_1();

            /*" -970- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -971- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -972- MOVE 1 TO OUT-COD-RETORNO */
                _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -974- MOVE 'PROBLEMAS NO INSERT DA TABELA AD_PROGRAMA' TO OUT-MENSAGEM */
                _.Move("PROBLEMAS NO INSERT DA TABELA AD_PROGRAMA", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -974- GO TO R9999-00-ROT-ERRO . */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0405-00-INSERT-PROGRAMAS-DB-INSERT-1 */
        public void R0405_00_INSERT_PROGRAMAS_DB_INSERT_1()
        {
            /*" -967- EXEC SQL INSERT INTO SEGUROS.AD_PROGRAMA (NOM_PROGRAMA , DTH_INCLUSAO , DTH_COMPILACAO, IND_PROGRAMA , STA_DCLGEN , STA_AMBIENTE , DES_PROGRAMA , COD_USUARIO , DTH_TIMESTAMP ) VALUES (:ADPROGRA-NOM-PROGRAMA, :ADPROGRA-DTH-INCLUSAO, :ADPROGRA-DTH-COMPILACAO, :ADPROGRA-IND-PROGRAMA, :ADPROGRA-STA-DCLGEN, :ADPROGRA-STA-AMBIENTE, :ADPROGRA-DES-PROGRAMA, :ADPROGRA-COD-USUARIO:WIND-COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0405_00_INSERT_PROGRAMAS_DB_INSERT_1_Insert1 = new R0405_00_INSERT_PROGRAMAS_DB_INSERT_1_Insert1()
            {
                ADPROGRA_NOM_PROGRAMA = ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_NOM_PROGRAMA.ToString(),
                ADPROGRA_DTH_INCLUSAO = ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_DTH_INCLUSAO.ToString(),
                ADPROGRA_DTH_COMPILACAO = ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_DTH_COMPILACAO.ToString(),
                ADPROGRA_IND_PROGRAMA = ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_IND_PROGRAMA.ToString(),
                ADPROGRA_STA_DCLGEN = ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_STA_DCLGEN.ToString(),
                ADPROGRA_STA_AMBIENTE = ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_STA_AMBIENTE.ToString(),
                ADPROGRA_DES_PROGRAMA = ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_DES_PROGRAMA.ToString(),
                ADPROGRA_COD_USUARIO = ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_COD_USUARIO.ToString(),
                WIND_COD_USUARIO = WIND_COD_USUARIO.ToString(),
            };

            R0405_00_INSERT_PROGRAMAS_DB_INSERT_1_Insert1.Execute(r0405_00_INSERT_PROGRAMAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0405_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-SELECT-USUARIOS-SECTION */
        private void R0410_00_SELECT_USUARIOS_SECTION()
        {
            /*" -987- MOVE 'R0410' TO ABEND-COD-PROCESSO */
            _.Move("R0410", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -989- MOVE LK-COD-USUARIO TO USUARIOS-COD-USUARIO */
            _.Move(PARAMETROS.LK_COD_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO);

            /*" -996- PERFORM R0410_00_SELECT_USUARIOS_DB_SELECT_1 */

            R0410_00_SELECT_USUARIOS_DB_SELECT_1();

            /*" -999- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1001- MOVE +1 TO WIND-COD-USUARIO . */
                _.Move(+1, WIND_COD_USUARIO);
            }


            /*" -1002- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1004- MOVE -1 TO WIND-COD-USUARIO . */
                _.Move(-1, WIND_COD_USUARIO);
            }


            /*" -1005- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1014- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1015- ELSE */
                }
                else
                {


                    /*" -1016- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                    _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                    /*" -1017- MOVE 1 TO OUT-COD-RETORNO */
                    _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -1019- MOVE 'PROBLEMAS NO ACESSO A TABELA USUARIOS' TO OUT-MENSAGEM */
                    _.Move("PROBLEMAS NO ACESSO A TABELA USUARIOS", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -1019- GO TO R9999-00-ROT-ERRO . */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0410-00-SELECT-USUARIOS-DB-SELECT-1 */
        public void R0410_00_SELECT_USUARIOS_DB_SELECT_1()
        {
            /*" -996- EXEC SQL SELECT COD_FONTE , VALUE(COD_USUARIO, ' ' ) INTO :USUARIOS-COD-FONTE , :USUARIOS-COD-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :USUARIOS-COD-USUARIO END-EXEC. */

            var r0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1 = new R0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1()
            {
                USUARIOS_COD_USUARIO = USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO.ToString(),
            };

            var executed_1 = R0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1.Execute(r0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_COD_FONTE, USUARIOS.DCLUSUARIOS.USUARIOS_COD_FONTE);
                _.Move(executed_1.USUARIOS_COD_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-SELECT-FONTES-SECTION */
        private void R0420_00_SELECT_FONTES_SECTION()
        {
            /*" -1033- MOVE 'R0420' TO ABEND-COD-PROCESSO */
            _.Move("R0420", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1035- MOVE LK-COD-FONTE TO FONTES-COD-FONTE */
            _.Move(PARAMETROS.LK_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);

            /*" -1040- PERFORM R0420_00_SELECT_FONTES_DB_SELECT_1 */

            R0420_00_SELECT_FONTES_DB_SELECT_1();

            /*" -1043- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1044- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1045- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                    _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                    /*" -1046- MOVE 1 TO OUT-COD-RETORNO */
                    _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -1048- MOVE 'FONTE NAO CADASTRADA NA FONTES' TO OUT-MENSAGEM */
                    _.Move("FONTE NAO CADASTRADA NA FONTES", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -1049- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -1050- ELSE */
                }
                else
                {


                    /*" -1051- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                    _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                    /*" -1052- MOVE 1 TO OUT-COD-RETORNO */
                    _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -1054- MOVE 'PROBLEMAS NO ACESSO A TABELA FONTES' TO OUT-MENSAGEM */
                    _.Move("PROBLEMAS NO ACESSO A TABELA FONTES", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -1055- DISPLAY 'PROBLEMAS NO ACESSO A TABELA FONTES - ' SQLCODE */
                    _.Display($"PROBLEMAS NO ACESSO A TABELA FONTES - {DB.SQLCODE}");

                    /*" -1056- DISPLAY 'FONTES-COD-FONTE  ' FONTES-COD-FONTE */
                    _.Display($"FONTES-COD-FONTE  {FONTES.DCLFONTES.FONTES_COD_FONTE}");

                    /*" -1056- GO TO R9999-00-ROT-ERRO . */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0420-00-SELECT-FONTES-DB-SELECT-1 */
        public void R0420_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -1040- EXEC SQL SELECT NOME_FONTE INTO :FONTES-NOME-FONTE FROM SEGUROS.FONTES WHERE COD_FONTE = :FONTES-COD-FONTE END-EXEC. */

            var r0420_00_SELECT_FONTES_DB_SELECT_1_Query1 = new R0420_00_SELECT_FONTES_DB_SELECT_1_Query1()
            {
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
            };

            var executed_1 = R0420_00_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r0420_00_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-SELECT-GE366-SECTION */
        private void R0900_00_SELECT_GE366_SECTION()
        {
            /*" -1070- MOVE 'R0900' TO ABEND-COD-PROCESSO */
            _.Move("R0900", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1074- PERFORM R0900_00_SELECT_GE366_DB_SELECT_1 */

            R0900_00_SELECT_GE366_DB_SELECT_1();

            /*" -1077- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1078- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -1079- MOVE 1 TO OUT-COD-RETORNO */
                _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -1081- MOVE 'PROBLEMAS NO ACESSO A TABELA GE_MOVIMENTO' TO OUT-MENSAGEM */
                _.Move("PROBLEMAS NO ACESSO A TABELA GE_MOVIMENTO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -1082- DISPLAY 'ERRO NO MAX DA GE_MOVIMENTO' */
                _.Display($"ERRO NO MAX DA GE_MOVIMENTO");

                /*" -1084- GO TO R9999-00-ROT-ERRO . */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1086- ADD 1 TO GE366-NUM-OCORR-MOVTO */
            GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO.Value = GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO + 1;

            /*" -1087- MOVE GE366-NUM-OCORR-MOVTO TO LK-NUM-OCORR-MOVTO. */
            _.Move(GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO, PARAMETROS.LK_NUM_OCORR_MOVTO);

        }

        [StopWatch]
        /*" R0900-00-SELECT-GE366-DB-SELECT-1 */
        public void R0900_00_SELECT_GE366_DB_SELECT_1()
        {
            /*" -1074- EXEC SQL SELECT VALUE(MAX(NUM_OCORR_MOVTO),0) INTO :GE366-NUM-OCORR-MOVTO FROM SEGUROS.GE_MOVIMENTO END-EXEC. */

            var r0900_00_SELECT_GE366_DB_SELECT_1_Query1 = new R0900_00_SELECT_GE366_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0900_00_SELECT_GE366_DB_SELECT_1_Query1.Execute(r0900_00_SELECT_GE366_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE366_NUM_OCORR_MOVTO, GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-INSERT-GE366-SECTION */
        private void R0910_00_INSERT_GE366_SECTION()
        {
            /*" -1097- MOVE 'R0910' TO ABEND-COD-PROCESSO */
            _.Move("R0910", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1100- MOVE LK-COD-EVENTO TO GE366-COD-EVENTO. */
            _.Move(PARAMETROS.LK_COD_EVENTO, GE366.DCLGE_MOVIMENTO.GE366_COD_EVENTO);

            /*" -1103- MOVE LK-IDE-SISTEMA TO GE366-IDE-SISTEMA. */
            _.Move(PARAMETROS.LK_IDE_SISTEMA, GE366.DCLGE_MOVIMENTO.GE366_IDE_SISTEMA);

            /*" -1107- MOVE SISTEMAS-DATA-MOV-ABERTO TO GE366-DTH-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, GE366.DCLGE_MOVIMENTO.GE366_DTH_MOVIMENTO);

            /*" -1110- MOVE LK-IND-ESTRUTURA TO GE366-IND-ESTRUTURA. */
            _.Move(PARAMETROS.LK_IND_ESTRUTURA, GE366.DCLGE_MOVIMENTO.GE366_IND_ESTRUTURA);

            /*" -1113- MOVE LK-IND-ORIGEM-FUNC TO GE366-IND-ORIGEM-FUNC. */
            _.Move(PARAMETROS.LK_IND_ORIGEM_FUNC, GE366.DCLGE_MOVIMENTO.GE366_IND_ORIGEM_FUNC);

            /*" -1116- MOVE LK-IND-EVENTO TO GE366-IND-EVENTO. */
            _.Move(PARAMETROS.LK_IND_EVENTO, GE366.DCLGE_MOVIMENTO.GE366_IND_EVENTO);

            /*" -1119- MOVE LK-NOM-PROGRAMA TO GE366-NOM-PROGRAMA. */
            _.Move(PARAMETROS.LK_NOM_PROGRAMA, GE366.DCLGE_MOVIMENTO.GE366_NOM_PROGRAMA);

            /*" -1122- MOVE LK-COD-USUARIO TO GE366-COD-USUARIO. */
            _.Move(PARAMETROS.LK_COD_USUARIO, GE366.DCLGE_MOVIMENTO.GE366_COD_USUARIO);

            /*" -1123- IF LK-NOM-PROGRAMA EQUAL SPACES */

            if (PARAMETROS.LK_NOM_PROGRAMA.IsEmpty())
            {

                /*" -1124- MOVE -1 TO WIND-NOM-PROGRAMA */
                _.Move(-1, WIND_NOM_PROGRAMA);

                /*" -1125- ELSE */
            }
            else
            {


                /*" -1132- MOVE +0 TO WIND-NOM-PROGRAMA. */
                _.Move(+0, WIND_NOM_PROGRAMA);
            }


            /*" -1155- PERFORM R0910_00_INSERT_GE366_DB_INSERT_1 */

            R0910_00_INSERT_GE366_DB_INSERT_1();

            /*" -1171- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1172- DISPLAY 'TABELA GE_MOVIMENTO - ERRO INSERT ' */
                _.Display($"TABELA GE_MOVIMENTO - ERRO INSERT ");

                /*" -1173- DISPLAY 'GE366-NUM-OCORR-MOVTO. ' GE366-NUM-OCORR-MOVTO */
                _.Display($"GE366-NUM-OCORR-MOVTO. {GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO}");

                /*" -1174- DISPLAY 'GE366-COD-EVENTO...... ' GE366-COD-EVENTO */
                _.Display($"GE366-COD-EVENTO...... {GE366.DCLGE_MOVIMENTO.GE366_COD_EVENTO}");

                /*" -1175- DISPLAY 'GE366-IDE-SISTEMA..... ' GE366-IDE-SISTEMA */
                _.Display($"GE366-IDE-SISTEMA..... {GE366.DCLGE_MOVIMENTO.GE366_IDE_SISTEMA}");

                /*" -1176- DISPLAY 'GE366-DTH-MOVIMENTO... ' GE366-DTH-MOVIMENTO */
                _.Display($"GE366-DTH-MOVIMENTO... {GE366.DCLGE_MOVIMENTO.GE366_DTH_MOVIMENTO}");

                /*" -1177- DISPLAY 'GE366-IND-ESTRUTURA... ' GE366-IND-ESTRUTURA */
                _.Display($"GE366-IND-ESTRUTURA... {GE366.DCLGE_MOVIMENTO.GE366_IND_ESTRUTURA}");

                /*" -1178- DISPLAY 'GE366-IND-ORIGEM-FUNC. ' GE366-IND-ORIGEM-FUNC */
                _.Display($"GE366-IND-ORIGEM-FUNC. {GE366.DCLGE_MOVIMENTO.GE366_IND_ORIGEM_FUNC}");

                /*" -1179- DISPLAY 'GE366-IND-EVENTO...... ' GE366-IND-EVENTO */
                _.Display($"GE366-IND-EVENTO...... {GE366.DCLGE_MOVIMENTO.GE366_IND_EVENTO}");

                /*" -1180- DISPLAY 'GE366-NOM-PROGRAMA.... ' GE366-NOM-PROGRAMA */
                _.Display($"GE366-NOM-PROGRAMA.... {GE366.DCLGE_MOVIMENTO.GE366_NOM_PROGRAMA}");

                /*" -1181- DISPLAY 'GE366-COD-USUARIO..... ' GE366-COD-USUARIO */
                _.Display($"GE366-COD-USUARIO..... {GE366.DCLGE_MOVIMENTO.GE366_COD_USUARIO}");

                /*" -1182- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -1183- MOVE 1 TO OUT-COD-RETORNO */
                _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -1185- MOVE 'PROBLEMAS NO INSERT DA TABELA GE_MOVIMENTO' TO OUT-MENSAGEM */
                _.Move("PROBLEMAS NO INSERT DA TABELA GE_MOVIMENTO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -1185- GO TO R9999-00-ROT-ERRO . */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0910-00-INSERT-GE366-DB-INSERT-1 */
        public void R0910_00_INSERT_GE366_DB_INSERT_1()
        {
            /*" -1155- EXEC SQL INSERT INTO SEGUROS.GE_MOVIMENTO (NUM_OCORR_MOVTO, COD_EVENTO, IDE_SISTEMA, DTH_MOVIMENTO, IND_ESTRUTURA, IND_ORIGEM_FUNC, DTH_CADASTRAMENTO, IND_EVENTO, NOM_PROGRAMA, COD_USUARIO ) VALUES (:GE366-NUM-OCORR-MOVTO, :GE366-COD-EVENTO, :GE366-IDE-SISTEMA, :GE366-DTH-MOVIMENTO, :GE366-IND-ESTRUTURA, :GE366-IND-ORIGEM-FUNC, CURRENT TIMESTAMP, :GE366-IND-EVENTO, :GE366-NOM-PROGRAMA, :GE366-COD-USUARIO:WIND-COD-USUARIO) END-EXEC. */

            var r0910_00_INSERT_GE366_DB_INSERT_1_Insert1 = new R0910_00_INSERT_GE366_DB_INSERT_1_Insert1()
            {
                GE366_NUM_OCORR_MOVTO = GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO.ToString(),
                GE366_COD_EVENTO = GE366.DCLGE_MOVIMENTO.GE366_COD_EVENTO.ToString(),
                GE366_IDE_SISTEMA = GE366.DCLGE_MOVIMENTO.GE366_IDE_SISTEMA.ToString(),
                GE366_DTH_MOVIMENTO = GE366.DCLGE_MOVIMENTO.GE366_DTH_MOVIMENTO.ToString(),
                GE366_IND_ESTRUTURA = GE366.DCLGE_MOVIMENTO.GE366_IND_ESTRUTURA.ToString(),
                GE366_IND_ORIGEM_FUNC = GE366.DCLGE_MOVIMENTO.GE366_IND_ORIGEM_FUNC.ToString(),
                GE366_IND_EVENTO = GE366.DCLGE_MOVIMENTO.GE366_IND_EVENTO.ToString(),
                GE366_NOM_PROGRAMA = GE366.DCLGE_MOVIMENTO.GE366_NOM_PROGRAMA.ToString(),
                GE366_COD_USUARIO = GE366.DCLGE_MOVIMENTO.GE366_COD_USUARIO.ToString(),
                WIND_COD_USUARIO = WIND_COD_USUARIO.ToString(),
            };

            R0910_00_INSERT_GE366_DB_INSERT_1_Insert1.Execute(r0910_00_INSERT_GE366_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0920-00-INSERT-GE367-SECTION */
        private void R0920_00_INSERT_GE367_SECTION()
        {
            /*" -1195- MOVE 'R0920' TO ABEND-COD-PROCESSO */
            _.Move("R0920", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1198- MOVE LK-NUM-PESSOA TO GE367-NUM-PESSOA. */
            _.Move(PARAMETROS.LK_NUM_PESSOA, GE367.DCLGE_LEGADO_PESSOA.GE367_NUM_PESSOA);

            /*" -1201- MOVE GE366-NUM-OCORR-MOVTO TO GE367-NUM-OCORR-MOVTO. */
            _.Move(GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO, GE367.DCLGE_LEGADO_PESSOA.GE367_NUM_OCORR_MOVTO);

            /*" -1204- MOVE LK-IND-RELACIONAMENTO TO GE367-IND-RELACIONAMENTO */
            _.Move(PARAMETROS.LK_IND_RELACIONAMENTO, GE367.DCLGE_LEGADO_PESSOA.GE367_IND_RELACIONAMENTO);

            /*" -1215- PERFORM R0920_00_INSERT_GE367_DB_INSERT_1 */

            R0920_00_INSERT_GE367_DB_INSERT_1();

            /*" -1225- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1226- DISPLAY 'TAB GE_LEGADO_PESSOA  - ERRO INSERT - ' SQLCODE */
                _.Display($"TAB GE_LEGADO_PESSOA  - ERRO INSERT - {DB.SQLCODE}");

                /*" -1227- DISPLAY 'GE367-NUM-PESSOA.........' GE367-NUM-PESSOA */
                _.Display($"GE367-NUM-PESSOA.........{GE367.DCLGE_LEGADO_PESSOA.GE367_NUM_PESSOA}");

                /*" -1228- DISPLAY 'GE367-NUM-OCORR-MOVTO....' GE367-NUM-OCORR-MOVTO */
                _.Display($"GE367-NUM-OCORR-MOVTO....{GE367.DCLGE_LEGADO_PESSOA.GE367_NUM_OCORR_MOVTO}");

                /*" -1229- DISPLAY 'GE367-IND-RELACIONAMENTO.' GE367-IND-RELACIONAMENTO */
                _.Display($"GE367-IND-RELACIONAMENTO.{GE367.DCLGE_LEGADO_PESSOA.GE367_IND_RELACIONAMENTO}");

                /*" -1230- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -1231- MOVE 1 TO OUT-COD-RETORNO */
                _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -1233- MOVE 'PROBLEMAS NO INSERT DA TABELA GE_LEGADO_PESSOA' TO OUT-MENSAGEM */
                _.Move("PROBLEMAS NO INSERT DA TABELA GE_LEGADO_PESSOA", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -1233- GO TO R9999-00-ROT-ERRO . */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0920-00-INSERT-GE367-DB-INSERT-1 */
        public void R0920_00_INSERT_GE367_DB_INSERT_1()
        {
            /*" -1215- EXEC SQL INSERT INTO SEGUROS.GE_LEGADO_PESSOA (NUM_PESSOA, NUM_OCORR_MOVTO, IND_RELACIONAMENTO, DTH_CADASTRAMENTO) VALUES (:GE367-NUM-PESSOA, :GE367-NUM-OCORR-MOVTO, :GE367-IND-RELACIONAMENTO, CURRENT TIMESTAMP) END-EXEC. */

            var r0920_00_INSERT_GE367_DB_INSERT_1_Insert1 = new R0920_00_INSERT_GE367_DB_INSERT_1_Insert1()
            {
                GE367_NUM_PESSOA = GE367.DCLGE_LEGADO_PESSOA.GE367_NUM_PESSOA.ToString(),
                GE367_NUM_OCORR_MOVTO = GE367.DCLGE_LEGADO_PESSOA.GE367_NUM_OCORR_MOVTO.ToString(),
                GE367_IND_RELACIONAMENTO = GE367.DCLGE_LEGADO_PESSOA.GE367_IND_RELACIONAMENTO.ToString(),
            };

            R0920_00_INSERT_GE367_DB_INSERT_1_Insert1.Execute(r0920_00_INSERT_GE367_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/

        [StopWatch]
        /*" R0930-00-INSERT-GE368-SECTION */
        private void R0930_00_INSERT_GE368_SECTION()
        {
            /*" -1243- MOVE 'R0930' TO ABEND-COD-PROCESSO */
            _.Move("R0930", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1245- MOVE LK-NUM-PESSOA TO GE368-NUM-PESSOA. */
            _.Move(PARAMETROS.LK_NUM_PESSOA, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA);

            /*" -1247- MOVE GE366-NUM-OCORR-MOVTO TO GE368-NUM-OCORR-MOVTO. */
            _.Move(GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO);

            /*" -1250- MOVE LK-SEQ-ENTIDADE(W-IND-PONTEIRO) TO GE368-SEQ-ENTIDADE */
            _.Move(PARAMETROS.LK_TABELA_PONTEIRO[W_IND_PONTEIRO].LK_SEQ_ENTIDADE, GE368.DCLGE_LEG_PESS_EVENTO.GE368_SEQ_ENTIDADE);

            /*" -1253- MOVE LK-IND-ENTIDADE-PEDIDA(W-IND-PONTEIRO) TO GE368-IND-ENTIDADE */
            _.Move(PARAMETROS.LK_TABELA_PONTEIRO[W_IND_PONTEIRO].LK_IND_ENTIDADE_PEDIDA, GE368.DCLGE_LEG_PESS_EVENTO.GE368_IND_ENTIDADE);

            /*" -1266- PERFORM R0930_00_INSERT_GE368_DB_INSERT_1 */

            R0930_00_INSERT_GE368_DB_INSERT_1();

            /*" -1269- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1270- DISPLAY 'TAB GE_LEG_PESS_EVENTO ERRO INSERT - ' SQLCODE */
                _.Display($"TAB GE_LEG_PESS_EVENTO ERRO INSERT - {DB.SQLCODE}");

                /*" -1271- DISPLAY 'GE368-NUM-PESSOA...... ' GE368-NUM-PESSOA */
                _.Display($"GE368-NUM-PESSOA...... {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA}");

                /*" -1272- DISPLAY 'GE368-NUM-OCORR-MOVTO. ' GE368-NUM-OCORR-MOVTO */
                _.Display($"GE368-NUM-OCORR-MOVTO. {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO}");

                /*" -1273- DISPLAY 'GE368-SEQ-ENTIDADE.... ' GE368-SEQ-ENTIDADE */
                _.Display($"GE368-SEQ-ENTIDADE.... {GE368.DCLGE_LEG_PESS_EVENTO.GE368_SEQ_ENTIDADE}");

                /*" -1274- DISPLAY 'GE368-IND-ENTIDADE.... ' GE368-IND-ENTIDADE */
                _.Display($"GE368-IND-ENTIDADE.... {GE368.DCLGE_LEG_PESS_EVENTO.GE368_IND_ENTIDADE}");

                /*" -1275- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -1276- MOVE 1 TO OUT-COD-RETORNO */
                _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -1278- MOVE 'PROBLEMAS NO INSERT DA TABELA GE_LEG_PESS_EVENTO' TO OUT-MENSAGEM */
                _.Move("PROBLEMAS NO INSERT DA TABELA GE_LEG_PESS_EVENTO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -1278- GO TO R9999-00-ROT-ERRO . */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0930-00-INSERT-GE368-DB-INSERT-1 */
        public void R0930_00_INSERT_GE368_DB_INSERT_1()
        {
            /*" -1266- EXEC SQL INSERT INTO SEGUROS.GE_LEG_PESS_EVENTO (NUM_PESSOA, NUM_OCORR_MOVTO, SEQ_ENTIDADE, IND_ENTIDADE, DTH_CADASTRAMENTO) VALUES (:GE368-NUM-PESSOA, :GE368-NUM-OCORR-MOVTO, :GE368-SEQ-ENTIDADE, :GE368-IND-ENTIDADE, CURRENT TIMESTAMP) END-EXEC. */

            var r0930_00_INSERT_GE368_DB_INSERT_1_Insert1 = new R0930_00_INSERT_GE368_DB_INSERT_1_Insert1()
            {
                GE368_NUM_PESSOA = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA.ToString(),
                GE368_NUM_OCORR_MOVTO = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO.ToString(),
                GE368_SEQ_ENTIDADE = GE368.DCLGE_LEG_PESS_EVENTO.GE368_SEQ_ENTIDADE.ToString(),
                GE368_IND_ENTIDADE = GE368.DCLGE_LEG_PESS_EVENTO.GE368_IND_ENTIDADE.ToString(),
            };

            R0930_00_INSERT_GE368_DB_INSERT_1_Insert1.Execute(r0930_00_INSERT_GE368_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0930_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-OPERACAO-1-SECTION */
        private void R1000_00_PROCESSA_OPERACAO_1_SECTION()
        {
            /*" -1288- MOVE 'R1000' TO ABEND-COD-PROCESSO */
            _.Move("R1000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1291- MOVE GE366-NUM-OCORR-MOVTO TO CB039-NUM-OCORR-MOVTO. */
            _.Move(GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO, CB039.DCLCB_PESS_PENDENCIA.CB039_NUM_OCORR_MOVTO);

            /*" -1294- MOVE LK-NUM-APOLICE TO CB039-NUM-APOLICE */
            _.Move(PARAMETROS.LK_NUM_APOLICE, CB039.DCLCB_PESS_PENDENCIA.CB039_NUM_APOLICE);

            /*" -1297- MOVE LK-NUM-ENDOSSO TO CB039-NUM-ENDOSSO */
            _.Move(PARAMETROS.LK_NUM_ENDOSSO, CB039.DCLCB_PESS_PENDENCIA.CB039_NUM_ENDOSSO);

            /*" -1300- MOVE LK-NUM-PARCELA TO CB039-NUM-PARCELA */
            _.Move(PARAMETROS.LK_NUM_PARCELA, CB039.DCLCB_PESS_PENDENCIA.CB039_NUM_PARCELA);

            /*" -1303- MOVE LK-DTH-MOVIMENTO TO CB039-DATA-MOVIMENTO */
            _.Move(PARAMETROS.LK_DTH_MOVIMENTO, CB039.DCLCB_PESS_PENDENCIA.CB039_DATA_MOVIMENTO);

            /*" -1306- MOVE LK-HORA-OPERACAO TO CB039-HORA-OPERACAO */
            _.Move(PARAMETROS.LK_HORA_OPERACAO, CB039.DCLCB_PESS_PENDENCIA.CB039_HORA_OPERACAO);

            /*" -1321- PERFORM R1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1 */

            R1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1();

            /*" -1324- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1325- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -1326- MOVE 1 TO OUT-COD-RETORNO */
                _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -1328- MOVE 'PROBLEMAS NO INSERT DA TABELA CB_PESS_PENDENCIA' TO OUT-MENSAGEM */
                _.Move("PROBLEMAS NO INSERT DA TABELA CB_PESS_PENDENCIA", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -1329- DISPLAY 'TAB CB_PESS_PENDENCIA - ERRO INSERT ' SQLCODE */
                _.Display($"TAB CB_PESS_PENDENCIA - ERRO INSERT {DB.SQLCODE}");

                /*" -1330- DISPLAY 'CB039-NUM-OCORR-MOVTO. ' CB039-NUM-OCORR-MOVTO */
                _.Display($"CB039-NUM-OCORR-MOVTO. {CB039.DCLCB_PESS_PENDENCIA.CB039_NUM_OCORR_MOVTO}");

                /*" -1331- DISPLAY 'CB039-NUM-APOLICE..... ' CB039-NUM-APOLICE */
                _.Display($"CB039-NUM-APOLICE..... {CB039.DCLCB_PESS_PENDENCIA.CB039_NUM_APOLICE}");

                /*" -1332- DISPLAY 'CB039-NUM-ENDOSSO..... ' CB039-NUM-ENDOSSO */
                _.Display($"CB039-NUM-ENDOSSO..... {CB039.DCLCB_PESS_PENDENCIA.CB039_NUM_ENDOSSO}");

                /*" -1333- DISPLAY 'CB039-NUM-PARCELA..... ' CB039-NUM-PARCELA */
                _.Display($"CB039-NUM-PARCELA..... {CB039.DCLCB_PESS_PENDENCIA.CB039_NUM_PARCELA}");

                /*" -1334- DISPLAY 'CB039-DATA-MOVIMENTO.. ' CB039-DATA-MOVIMENTO */
                _.Display($"CB039-DATA-MOVIMENTO.. {CB039.DCLCB_PESS_PENDENCIA.CB039_DATA_MOVIMENTO}");

                /*" -1335- DISPLAY 'CB039-HORA-OPERACAO... ' CB039-HORA-OPERACAO */
                _.Display($"CB039-HORA-OPERACAO... {CB039.DCLCB_PESS_PENDENCIA.CB039_HORA_OPERACAO}");

                /*" -1335- GO TO R9999-00-ROT-ERRO . */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-OPERACAO-1-DB-INSERT-1 */
        public void R1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1()
        {
            /*" -1321- EXEC SQL INSERT INTO SEGUROS.CB_PESS_PENDENCIA ( NUM_OCORR_MOVTO, NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, DATA_MOVIMENTO, HORA_OPERACAO) VALUES (:CB039-NUM-OCORR-MOVTO, :CB039-NUM-APOLICE, :CB039-NUM-ENDOSSO, :CB039-NUM-PARCELA, :CB039-DATA-MOVIMENTO, :CB039-HORA-OPERACAO) END-EXEC. */

            var r1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1_Insert1 = new R1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1_Insert1()
            {
                CB039_NUM_OCORR_MOVTO = CB039.DCLCB_PESS_PENDENCIA.CB039_NUM_OCORR_MOVTO.ToString(),
                CB039_NUM_APOLICE = CB039.DCLCB_PESS_PENDENCIA.CB039_NUM_APOLICE.ToString(),
                CB039_NUM_ENDOSSO = CB039.DCLCB_PESS_PENDENCIA.CB039_NUM_ENDOSSO.ToString(),
                CB039_NUM_PARCELA = CB039.DCLCB_PESS_PENDENCIA.CB039_NUM_PARCELA.ToString(),
                CB039_DATA_MOVIMENTO = CB039.DCLCB_PESS_PENDENCIA.CB039_DATA_MOVIMENTO.ToString(),
                CB039_HORA_OPERACAO = CB039.DCLCB_PESS_PENDENCIA.CB039_HORA_OPERACAO.ToString(),
            };

            R1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1_Insert1.Execute(r1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OPERACAO-2-SECTION */
        private void R2000_00_PROCESSA_OPERACAO_2_SECTION()
        {
            /*" -1345- MOVE 'R2000' TO ABEND-COD-PROCESSO */
            _.Move("R2000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1348- MOVE GE366-NUM-OCORR-MOVTO TO CB040-NUM-OCORR-MOVTO. */
            _.Move(GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO, CB040.DCLCB_PESS_REC_ANT.CB040_NUM_OCORR_MOVTO);

            /*" -1351- MOVE LK-COD-FONTE TO CB040-COD-FONTE */
            _.Move(PARAMETROS.LK_COD_FONTE, CB040.DCLCB_PESS_REC_ANT.CB040_COD_FONTE);

            /*" -1354- MOVE LK-NUM-RCAP TO CB040-NUM-RCAP */
            _.Move(PARAMETROS.LK_NUM_RCAP, CB040.DCLCB_PESS_REC_ANT.CB040_NUM_RCAP);

            /*" -1363- PERFORM R2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1 */

            R2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1();

            /*" -1366- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1367- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -1368- MOVE 1 TO OUT-COD-RETORNO */
                _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -1370- MOVE 'PROBLEMAS NO INSERT DA TABELA CB_PESS_REC_ANT' TO OUT-MENSAGEM */
                _.Move("PROBLEMAS NO INSERT DA TABELA CB_PESS_REC_ANT", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -1371- DISPLAY 'TAB CB_PESS_REC_ANT - ERRO INSERT - ' SQLCODE */
                _.Display($"TAB CB_PESS_REC_ANT - ERRO INSERT - {DB.SQLCODE}");

                /*" -1372- DISPLAY 'CB040-NUM-OCORR-MOVTO. ' CB040-NUM-OCORR-MOVTO */
                _.Display($"CB040-NUM-OCORR-MOVTO. {CB040.DCLCB_PESS_REC_ANT.CB040_NUM_OCORR_MOVTO}");

                /*" -1373- DISPLAY 'CB040-COD-FONTE....... ' CB040-COD-FONTE */
                _.Display($"CB040-COD-FONTE....... {CB040.DCLCB_PESS_REC_ANT.CB040_COD_FONTE}");

                /*" -1374- DISPLAY 'CB040-NUM-RCAP........ ' CB040-NUM-RCAP */
                _.Display($"CB040-NUM-RCAP........ {CB040.DCLCB_PESS_REC_ANT.CB040_NUM_RCAP}");

                /*" -1374- GO TO R9999-00-ROT-ERRO . */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2000-00-PROCESSA-OPERACAO-2-DB-INSERT-1 */
        public void R2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1()
        {
            /*" -1363- EXEC SQL INSERT INTO SEGUROS.CB_PESS_REC_ANT ( NUM_OCORR_MOVTO, COD_FONTE, NUM_RCAP) VALUES (:CB040-NUM-OCORR-MOVTO, :CB040-COD-FONTE, :CB040-NUM-RCAP) END-EXEC. */

            var r2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1_Insert1 = new R2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1_Insert1()
            {
                CB040_NUM_OCORR_MOVTO = CB040.DCLCB_PESS_REC_ANT.CB040_NUM_OCORR_MOVTO.ToString(),
                CB040_COD_FONTE = CB040.DCLCB_PESS_REC_ANT.CB040_COD_FONTE.ToString(),
                CB040_NUM_RCAP = CB040.DCLCB_PESS_REC_ANT.CB040_NUM_RCAP.ToString(),
            };

            R2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1_Insert1.Execute(r2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PROCESSA-OPERACAO-3-SECTION */
        private void R3000_00_PROCESSA_OPERACAO_3_SECTION()
        {
            /*" -1384- MOVE 'R3000' TO ABEND-COD-PROCESSO */
            _.Move("R3000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1387- MOVE GE366-NUM-OCORR-MOVTO TO CB041-NUM-OCORR-MOVTO. */
            _.Move(GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO, CB041.DCLCB_PESS_PARCELA.CB041_NUM_OCORR_MOVTO);

            /*" -1390- MOVE LK-NUM-APOLICE TO CB041-NUM-APOLICE */
            _.Move(PARAMETROS.LK_NUM_APOLICE, CB041.DCLCB_PESS_PARCELA.CB041_NUM_APOLICE);

            /*" -1393- MOVE LK-NUM-ENDOSSO TO CB041-NUM-ENDOSSO */
            _.Move(PARAMETROS.LK_NUM_ENDOSSO, CB041.DCLCB_PESS_PARCELA.CB041_NUM_ENDOSSO);

            /*" -1396- MOVE LK-NUM-PARCELA TO CB041-NUM-PARCELA */
            _.Move(PARAMETROS.LK_NUM_PARCELA, CB041.DCLCB_PESS_PARCELA.CB041_NUM_PARCELA);

            /*" -1399- MOVE LK-OCORR-HISTORICO TO CB041-OCORR-HISTORICO */
            _.Move(PARAMETROS.LK_OCORR_HISTORICO, CB041.DCLCB_PESS_PARCELA.CB041_OCORR_HISTORICO);

            /*" -1412- PERFORM R3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1 */

            R3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1();

            /*" -1415- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1416- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -1417- MOVE 1 TO OUT-COD-RETORNO */
                _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -1419- MOVE 'PROBLEMAS NO INSERT DA TABELA CB_PESS_PARCELA' TO OUT-MENSAGEM */
                _.Move("PROBLEMAS NO INSERT DA TABELA CB_PESS_PARCELA", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -1420- DISPLAY 'TAB CB_PESS_PARCELA ERRO INSERT - ' SQLCODE */
                _.Display($"TAB CB_PESS_PARCELA ERRO INSERT - {DB.SQLCODE}");

                /*" -1421- DISPLAY 'CB041-NUM-OCORR-MOVTO. ' CB041-NUM-OCORR-MOVTO */
                _.Display($"CB041-NUM-OCORR-MOVTO. {CB041.DCLCB_PESS_PARCELA.CB041_NUM_OCORR_MOVTO}");

                /*" -1422- DISPLAY 'CB041-NUM-APOLICE.....' CB041-NUM-APOLICE */
                _.Display($"CB041-NUM-APOLICE.....{CB041.DCLCB_PESS_PARCELA.CB041_NUM_APOLICE}");

                /*" -1423- DISPLAY 'CB041-NUM-ENDOSSO.....' CB041-NUM-ENDOSSO */
                _.Display($"CB041-NUM-ENDOSSO.....{CB041.DCLCB_PESS_PARCELA.CB041_NUM_ENDOSSO}");

                /*" -1424- DISPLAY 'CB041-NUM-PARCELA.....' CB041-NUM-PARCELA */
                _.Display($"CB041-NUM-PARCELA.....{CB041.DCLCB_PESS_PARCELA.CB041_NUM_PARCELA}");

                /*" -1425- DISPLAY 'CB041-OCORR-HISTORICO.' CB041-OCORR-HISTORICO */
                _.Display($"CB041-OCORR-HISTORICO.{CB041.DCLCB_PESS_PARCELA.CB041_OCORR_HISTORICO}");

                /*" -1425- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3000-00-PROCESSA-OPERACAO-3-DB-INSERT-1 */
        public void R3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1()
        {
            /*" -1412- EXEC SQL INSERT INTO SEGUROS.CB_PESS_PARCELA ( NUM_OCORR_MOVTO, NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, OCORR_HISTORICO) VALUES (:CB041-NUM-OCORR-MOVTO, :CB041-NUM-APOLICE, :CB041-NUM-ENDOSSO, :CB041-NUM-PARCELA, :CB041-OCORR-HISTORICO) END-EXEC. */

            var r3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1_Insert1 = new R3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1_Insert1()
            {
                CB041_NUM_OCORR_MOVTO = CB041.DCLCB_PESS_PARCELA.CB041_NUM_OCORR_MOVTO.ToString(),
                CB041_NUM_APOLICE = CB041.DCLCB_PESS_PARCELA.CB041_NUM_APOLICE.ToString(),
                CB041_NUM_ENDOSSO = CB041.DCLCB_PESS_PARCELA.CB041_NUM_ENDOSSO.ToString(),
                CB041_NUM_PARCELA = CB041.DCLCB_PESS_PARCELA.CB041_NUM_PARCELA.ToString(),
                CB041_OCORR_HISTORICO = CB041.DCLCB_PESS_PARCELA.CB041_OCORR_HISTORICO.ToString(),
            };

            R3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1_Insert1.Execute(r3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-PROCESSA-OPERACAO-4-SECTION */
        private void R4000_00_PROCESSA_OPERACAO_4_SECTION()
        {
            /*" -1435- MOVE 'R4000' TO ABEND-COD-PROCESSO */
            _.Move("R4000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1438- MOVE GE366-NUM-OCORR-MOVTO TO SI175-NUM-OCORR-MOVTO. */
            _.Move(GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO, SI175.DCLSI_PESS_SINISTRO.SI175_NUM_OCORR_MOVTO);

            /*" -1441- MOVE LK-NUM-APOL-SINISTRO TO SI175-NUM-APOL-SINISTRO */
            _.Move(PARAMETROS.LK_NUM_APOL_SINISTRO, SI175.DCLSI_PESS_SINISTRO.SI175_NUM_APOL_SINISTRO);

            /*" -1444- MOVE LK-OCORR-HISTORICO TO SI175-OCORR-HISTORICO */
            _.Move(PARAMETROS.LK_OCORR_HISTORICO, SI175.DCLSI_PESS_SINISTRO.SI175_OCORR_HISTORICO);

            /*" -1447- MOVE LK-COD-OPERACAO-SI TO SI175-COD-OPERACAO */
            _.Move(PARAMETROS.LK_COD_OPERACAO_SI, SI175.DCLSI_PESS_SINISTRO.SI175_COD_OPERACAO);

            /*" -1458- PERFORM R4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1 */

            R4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1();

            /*" -1461- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1462- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -1463- MOVE 1 TO OUT-COD-RETORNO */
                _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -1465- MOVE 'PROBLEMAS NO INSERT DA TABELA SI_PESS_SINISTRO' TO OUT-MENSAGEM */
                _.Move("PROBLEMAS NO INSERT DA TABELA SI_PESS_SINISTRO", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -1466- DISPLAY 'TAB SI_PESS_SINISTRO ERRO INSERT - ' SQLCODE */
                _.Display($"TAB SI_PESS_SINISTRO ERRO INSERT - {DB.SQLCODE}");

                /*" -1467- DISPLAY 'SI175-NUM-OCORR-MOVTO... ' SI175-NUM-OCORR-MOVTO */
                _.Display($"SI175-NUM-OCORR-MOVTO... {SI175.DCLSI_PESS_SINISTRO.SI175_NUM_OCORR_MOVTO}");

                /*" -1468- DISPLAY 'SI175-NUM-APOL-SINISTRO. ' SI175-NUM-APOL-SINISTRO */
                _.Display($"SI175-NUM-APOL-SINISTRO. {SI175.DCLSI_PESS_SINISTRO.SI175_NUM_APOL_SINISTRO}");

                /*" -1469- DISPLAY 'SI175-OCORR-HISTORICO... ' SI175-OCORR-HISTORICO */
                _.Display($"SI175-OCORR-HISTORICO... {SI175.DCLSI_PESS_SINISTRO.SI175_OCORR_HISTORICO}");

                /*" -1470- DISPLAY 'SI175-COD-OPERACAO...... ' SI175-COD-OPERACAO */
                _.Display($"SI175-COD-OPERACAO...... {SI175.DCLSI_PESS_SINISTRO.SI175_COD_OPERACAO}");

                /*" -1470- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4000-00-PROCESSA-OPERACAO-4-DB-INSERT-1 */
        public void R4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1()
        {
            /*" -1458- EXEC SQL INSERT INTO SEGUROS.SI_PESS_SINISTRO ( NUM_OCORR_MOVTO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO) VALUES (:SI175-NUM-OCORR-MOVTO, :SI175-NUM-APOL-SINISTRO, :SI175-OCORR-HISTORICO, :SI175-COD-OPERACAO) END-EXEC. */

            var r4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1_Insert1 = new R4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1_Insert1()
            {
                SI175_NUM_OCORR_MOVTO = SI175.DCLSI_PESS_SINISTRO.SI175_NUM_OCORR_MOVTO.ToString(),
                SI175_NUM_APOL_SINISTRO = SI175.DCLSI_PESS_SINISTRO.SI175_NUM_APOL_SINISTRO.ToString(),
                SI175_OCORR_HISTORICO = SI175.DCLSI_PESS_SINISTRO.SI175_OCORR_HISTORICO.ToString(),
                SI175_COD_OPERACAO = SI175.DCLSI_PESS_SINISTRO.SI175_COD_OPERACAO.ToString(),
            };

            R4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1_Insert1.Execute(r4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-PROCESSA-OPERACAO-5-SECTION */
        private void R5000_00_PROCESSA_OPERACAO_5_SECTION()
        {
            /*" -1480- MOVE 'R5000' TO ABEND-COD-PROCESSO */
            _.Move("R5000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1483- MOVE GE366-NUM-OCORR-MOVTO TO VG079-NUM-OCORR-MOVTO. */
            _.Move(GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO, VG079.DCLVG_PESS_PARCELA.VG079_NUM_OCORR_MOVTO);

            /*" -1486- MOVE LK-NUM-CERTIFICADO TO VG079-NUM-CERTIFICADO */
            _.Move(PARAMETROS.LK_NUM_CERTIFICADO, VG079.DCLVG_PESS_PARCELA.VG079_NUM_CERTIFICADO);

            /*" -1489- MOVE LK-NUM-PARCELA TO VG079-NUM-PARCELA */
            _.Move(PARAMETROS.LK_NUM_PARCELA, VG079.DCLVG_PESS_PARCELA.VG079_NUM_PARCELA);

            /*" -1492- MOVE LK-NUM-TITULO TO VG079-NUM-TITULO */
            _.Move(PARAMETROS.LK_NUM_TITULO, VG079.DCLVG_PESS_PARCELA.VG079_NUM_TITULO);

            /*" -1503- PERFORM R5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1 */

            R5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1();

            /*" -1506- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1507- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -1508- MOVE 1 TO OUT-COD-RETORNO */
                _.Move(1, PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -1510- MOVE 'PROBLEMAS NO INSERT DA TABELA VG_PESS_PARCELA' TO OUT-MENSAGEM */
                _.Move("PROBLEMAS NO INSERT DA TABELA VG_PESS_PARCELA", PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -1511- DISPLAY 'TAB VG_PESS_PARCELA INSERT TABELA - ' SQLCODE */
                _.Display($"TAB VG_PESS_PARCELA INSERT TABELA - {DB.SQLCODE}");

                /*" -1512- DISPLAY 'VG079-NUM-OCORR-MOVTO. ' VG079-NUM-OCORR-MOVTO */
                _.Display($"VG079-NUM-OCORR-MOVTO. {VG079.DCLVG_PESS_PARCELA.VG079_NUM_OCORR_MOVTO}");

                /*" -1513- DISPLAY 'VG079-NUM-CERTIFICADO. ' VG079-NUM-CERTIFICADO */
                _.Display($"VG079-NUM-CERTIFICADO. {VG079.DCLVG_PESS_PARCELA.VG079_NUM_CERTIFICADO}");

                /*" -1514- DISPLAY 'VG079-NUM-PARCELA..... ' VG079-NUM-PARCELA */
                _.Display($"VG079-NUM-PARCELA..... {VG079.DCLVG_PESS_PARCELA.VG079_NUM_PARCELA}");

                /*" -1515- DISPLAY 'VG079-NUM-TITULO...... ' VG079-NUM-TITULO */
                _.Display($"VG079-NUM-TITULO...... {VG079.DCLVG_PESS_PARCELA.VG079_NUM_TITULO}");

                /*" -1515- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-00-PROCESSA-OPERACAO-5-DB-INSERT-1 */
        public void R5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1()
        {
            /*" -1503- EXEC SQL INSERT INTO SEGUROS.VG_PESS_PARCELA ( NUM_OCORR_MOVTO, NUM_CERTIFICADO, NUM_PARCELA, NUM_TITULO) VALUES (:VG079-NUM-OCORR-MOVTO, :VG079-NUM-CERTIFICADO, :VG079-NUM-PARCELA, :VG079-NUM-TITULO) END-EXEC. */

            var r5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1_Insert1 = new R5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1_Insert1()
            {
                VG079_NUM_OCORR_MOVTO = VG079.DCLVG_PESS_PARCELA.VG079_NUM_OCORR_MOVTO.ToString(),
                VG079_NUM_CERTIFICADO = VG079.DCLVG_PESS_PARCELA.VG079_NUM_CERTIFICADO.ToString(),
                VG079_NUM_PARCELA = VG079.DCLVG_PESS_PARCELA.VG079_NUM_PARCELA.ToString(),
                VG079_NUM_TITULO = VG079.DCLVG_PESS_PARCELA.VG079_NUM_TITULO.ToString(),
            };

            R5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1_Insert1.Execute(r5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -1522- MOVE SQLERRMC TO OUT-SQLERRMC */
            _.Move(DB.SQLERRMC, PROTOCOLO_ENVIO.OUT_SQLERRMC);

            /*" -1524- MOVE SQLSTATE TO OUT-SQLSTATE */
            _.Move(DB.SQLSTATE, PROTOCOLO_ENVIO.OUT_SQLSTATE);

            /*" -1525- MOVE OUT-COD-RETORNO TO H-OUT-COD-RETORNO */
            _.Move(PROTOCOLO_ENVIO.OUT_COD_RETORNO, PARAMETROS.H_OUT_COD_RETORNO);

            /*" -1526- MOVE OUT-COD-RETORNO-SQL TO H-OUT-COD-RETORNO-SQL */
            _.Move(PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL, PARAMETROS.H_OUT_COD_RETORNO_SQL);

            /*" -1527- MOVE OUT-MENSAGEM TO H-OUT-MENSAGEM */
            _.Move(PROTOCOLO_ENVIO.OUT_MENSAGEM, PARAMETROS.H_OUT_MENSAGEM);

            /*" -1528- MOVE OUT-SQLERRMC TO H-OUT-SQLERRMC */
            _.Move(PROTOCOLO_ENVIO.OUT_SQLERRMC, PARAMETROS.H_OUT_SQLERRMC);

            /*" -1532- MOVE OUT-SQLSTATE TO H-OUT-SQLSTATE. */
            _.Move(PROTOCOLO_ENVIO.OUT_SQLSTATE, PARAMETROS.H_OUT_SQLSTATE);

            /*" -1533- MOVE SQLERRMC TO OUT-SQLERRMC */
            _.Move(DB.SQLERRMC, PROTOCOLO_ENVIO.OUT_SQLERRMC);

            /*" -1535- MOVE SQLSTATE TO OUT-SQLSTATE */
            _.Move(DB.SQLSTATE, PROTOCOLO_ENVIO.OUT_SQLSTATE);

            /*" -1536- MOVE OUT-COD-RETORNO TO H-OUT-COD-RETORNO */
            _.Move(PROTOCOLO_ENVIO.OUT_COD_RETORNO, PARAMETROS.H_OUT_COD_RETORNO);

            /*" -1537- MOVE OUT-COD-RETORNO-SQL TO H-OUT-COD-RETORNO-SQL */
            _.Move(PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL, PARAMETROS.H_OUT_COD_RETORNO_SQL);

            /*" -1538- MOVE OUT-MENSAGEM TO H-OUT-MENSAGEM */
            _.Move(PROTOCOLO_ENVIO.OUT_MENSAGEM, PARAMETROS.H_OUT_MENSAGEM);

            /*" -1539- MOVE OUT-SQLERRMC TO H-OUT-SQLERRMC */
            _.Move(PROTOCOLO_ENVIO.OUT_SQLERRMC, PARAMETROS.H_OUT_SQLERRMC);

            /*" -1541- MOVE OUT-SQLSTATE TO H-OUT-SQLSTATE. */
            _.Move(PROTOCOLO_ENVIO.OUT_SQLSTATE, PARAMETROS.H_OUT_SQLSTATE);

            /*" -1542- DISPLAY 'GE0550B - ROTINA DE CADASTRO DE PESSOA X LEGADO' */
            _.Display($"GE0550B - ROTINA DE CADASTRO DE PESSOA X LEGADO");

            /*" -1543- DISPLAY 'EXECUCAO APRESENTOU ERRO / REGISTRO PROCESSADO' */
            _.Display($"EXECUCAO APRESENTOU ERRO / REGISTRO PROCESSADO");

            /*" -1544- PERFORM R10000-DISPLAY-REGISTRO THRU R10000-EXIT. */

            R10000_DISPLAY_REGISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R10000_EXIT*/


            /*" -1545- DISPLAY 'SQLCA............. ' SQLCA. */
            _.Display($"SQLCA............. {DB.SQLCA}");

            /*" -1546- DISPLAY 'SQLCAID........... ' SQLCAID. */
            _.Display($"SQLCAID........... {DB.SQLCAID}");

            /*" -1548- DISPLAY 'SQLCABC........... ' SQLCABC. */
            _.Display($"SQLCABC........... {DB.SQLCABC}");

            /*" -1550- MOVE OUT-COD-RETORNO-SQL TO W-EDICAO. */
            _.Move(PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL, W_EDICAO);

            /*" -1551- DISPLAY 'SQLCODE........... ' W-EDICAO. */
            _.Display($"SQLCODE........... {W_EDICAO}");

            /*" -1552- DISPLAY 'SQLERRM........... ' SQLERRM. */
            _.Display($"SQLERRM........... SQLERRM");

            /*" -1553- DISPLAY 'SQLERRP........... ' SQLERRP. */
            _.Display($"SQLERRP........... {DB.SQLERRP}");

            /*" -1560- DISPLAY 'SQLWARN........... ' SQLWARN. */
            _.Display($"SQLWARN........... {DB.SQLWARN}");

            /*" -1560- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/

        [StopWatch]
        /*" R10000-DISPLAY-REGISTRO */
        private void R10000_DISPLAY_REGISTRO(bool isPerform = false)
        {
            /*" -1571- DISPLAY 'LK-COD-OPERACAO.......' LK-COD-OPERACAO */
            _.Display($"LK-COD-OPERACAO.......{PARAMETROS.LK_COD_OPERACAO}");

            /*" -1572- DISPLAY 'LK-NUM-APOLICE........' LK-NUM-APOLICE */
            _.Display($"LK-NUM-APOLICE........{PARAMETROS.LK_NUM_APOLICE}");

            /*" -1573- DISPLAY 'LK-NUM-ENDOSSO........' LK-NUM-ENDOSSO */
            _.Display($"LK-NUM-ENDOSSO........{PARAMETROS.LK_NUM_ENDOSSO}");

            /*" -1574- DISPLAY 'LK-NUM-PARCELA........' LK-NUM-PARCELA */
            _.Display($"LK-NUM-PARCELA........{PARAMETROS.LK_NUM_PARCELA}");

            /*" -1575- DISPLAY 'LK-OCORR-HISTORICO....' LK-OCORR-HISTORICO */
            _.Display($"LK-OCORR-HISTORICO....{PARAMETROS.LK_OCORR_HISTORICO}");

            /*" -1576- DISPLAY 'LK-NUM-PESSOA.........' LK-NUM-PESSOA */
            _.Display($"LK-NUM-PESSOA.........{PARAMETROS.LK_NUM_PESSOA}");

            /*" -1577- DISPLAY 'LK-NUM-OCORR-MOVTO....' LK-NUM-OCORR-MOVTO */
            _.Display($"LK-NUM-OCORR-MOVTO....{PARAMETROS.LK_NUM_OCORR_MOVTO}");

            /*" -1579- DISPLAY 'LK-SEQ-ENTIDADE.......' LK-SEQ-ENTIDADE(W-IND-PONTEIRO) */
            _.Display($"LK-SEQ-ENTIDADE.......{PARAMETROS.LK_TABELA_PONTEIRO[W_IND_PONTEIRO]}");

            /*" -1581- DISPLAY 'LK-IND-ENTIDADE.......' LK-IND-ENTIDADE-PEDIDA(W-IND-PONTEIRO) */
            _.Display($"LK-IND-ENTIDADE.......{PARAMETROS.LK_TABELA_PONTEIRO[W_IND_PONTEIRO]}");

            /*" -1582- DISPLAY 'LK-COD-EVENTO.........' LK-COD-EVENTO */
            _.Display($"LK-COD-EVENTO.........{PARAMETROS.LK_COD_EVENTO}");

            /*" -1583- DISPLAY 'LK-IDE-SISTEMA........' LK-IDE-SISTEMA */
            _.Display($"LK-IDE-SISTEMA........{PARAMETROS.LK_IDE_SISTEMA}");

            /*" -1584- DISPLAY 'LK-DTH-MOVIMENTO......' LK-DTH-MOVIMENTO */
            _.Display($"LK-DTH-MOVIMENTO......{PARAMETROS.LK_DTH_MOVIMENTO}");

            /*" -1585- DISPLAY 'LK-IND-ESTRUTURA......' LK-IND-ESTRUTURA */
            _.Display($"LK-IND-ESTRUTURA......{PARAMETROS.LK_IND_ESTRUTURA}");

            /*" -1586- DISPLAY 'LK-IND-ORIGEM-FUNC....' LK-IND-ORIGEM-FUNC */
            _.Display($"LK-IND-ORIGEM-FUNC....{PARAMETROS.LK_IND_ORIGEM_FUNC}");

            /*" -1587- DISPLAY 'LK-IND-EVENTO.........' LK-IND-EVENTO */
            _.Display($"LK-IND-EVENTO.........{PARAMETROS.LK_IND_EVENTO}");

            /*" -1588- DISPLAY 'LK-NOM-PROGRAMA.......' LK-NOM-PROGRAMA */
            _.Display($"LK-NOM-PROGRAMA.......{PARAMETROS.LK_NOM_PROGRAMA}");

            /*" -1589- DISPLAY 'LK-COD-USUARIO........' LK-COD-USUARIO */
            _.Display($"LK-COD-USUARIO........{PARAMETROS.LK_COD_USUARIO}");

            /*" -1590- DISPLAY 'LK-IND-RELACIONAMENTO.' LK-IND-RELACIONAMENTO */
            _.Display($"LK-IND-RELACIONAMENTO.{PARAMETROS.LK_IND_RELACIONAMENTO}");

            /*" -1591- DISPLAY 'LK-HORA-OPERACAO......' LK-HORA-OPERACAO */
            _.Display($"LK-HORA-OPERACAO......{PARAMETROS.LK_HORA_OPERACAO}");

            /*" -1592- DISPLAY 'LK-COD-FONTE..........' LK-COD-FONTE */
            _.Display($"LK-COD-FONTE..........{PARAMETROS.LK_COD_FONTE}");

            /*" -1593- DISPLAY 'LK-NUM-RCAP...........' LK-NUM-RCAP */
            _.Display($"LK-NUM-RCAP...........{PARAMETROS.LK_NUM_RCAP}");

            /*" -1594- DISPLAY 'LK-NUM-APOL-SINISTRO..' LK-NUM-APOL-SINISTRO */
            _.Display($"LK-NUM-APOL-SINISTRO..{PARAMETROS.LK_NUM_APOL_SINISTRO}");

            /*" -1595- DISPLAY 'LK-COD-OPERACAO-SI....' LK-COD-OPERACAO-SI */
            _.Display($"LK-COD-OPERACAO-SI....{PARAMETROS.LK_COD_OPERACAO_SI}");

            /*" -1596- DISPLAY 'LK-NUM-CERTIFICADO....' LK-NUM-CERTIFICADO */
            _.Display($"LK-NUM-CERTIFICADO....{PARAMETROS.LK_NUM_CERTIFICADO}");

            /*" -1597- DISPLAY 'LK-NUM-TITULO.........' LK-NUM-TITULO */
            _.Display($"LK-NUM-TITULO.........{PARAMETROS.LK_NUM_TITULO}");

            /*" -1598- DISPLAY '===> PROTOCOLO DE SAIDA ' */
            _.Display($"===> PROTOCOLO DE SAIDA ");

            /*" -1599- DISPLAY 'H-OUT-COD-RETORNO.....' H-OUT-COD-RETORNO */
            _.Display($"H-OUT-COD-RETORNO.....{PARAMETROS.H_OUT_COD_RETORNO}");

            /*" -1600- DISPLAY 'H-OUT-COD-RETORNO-SQL.' H-OUT-COD-RETORNO-SQL */
            _.Display($"H-OUT-COD-RETORNO-SQL.{PARAMETROS.H_OUT_COD_RETORNO_SQL}");

            /*" -1601- DISPLAY 'H-OUT-MENSAGEM........' H-OUT-MENSAGEM */
            _.Display($"H-OUT-MENSAGEM........{PARAMETROS.H_OUT_MENSAGEM}");

            /*" -1602- DISPLAY 'H-OUT-SQLERRMC........' H-OUT-SQLERRMC */
            _.Display($"H-OUT-SQLERRMC........{PARAMETROS.H_OUT_SQLERRMC}");

            /*" -1602- DISPLAY 'H-OUT-SQLSTATE........' H-OUT-SQLSTATE. */
            _.Display($"H-OUT-SQLSTATE........{PARAMETROS.H_OUT_SQLSTATE}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10000_EXIT*/

        [StopWatch]
        /*" R10010-MONTA-REGISTRO */
        private void R10010_MONTA_REGISTRO(bool isPerform = false)
        {
            /*" -1609- MOVE 4 TO LK-COD-OPERACAO. */
            _.Move(4, PARAMETROS.LK_COD_OPERACAO);

            /*" -1610- MOVE 0 TO LK-NUM-APOLICE . */
            _.Move(0, PARAMETROS.LK_NUM_APOLICE);

            /*" -1611- MOVE 0 TO LK-NUM-ENDOSSO . */
            _.Move(0, PARAMETROS.LK_NUM_ENDOSSO);

            /*" -1612- MOVE 0 TO LK-NUM-PARCELA . */
            _.Move(0, PARAMETROS.LK_NUM_PARCELA);

            /*" -1613- MOVE 5 TO LK-OCORR-HISTORICO. */
            _.Move(5, PARAMETROS.LK_OCORR_HISTORICO);

            /*" -1614- MOVE 123456808 TO LK-NUM-PESSOA . */
            _.Move(123456808, PARAMETROS.LK_NUM_PESSOA);

            /*" -1617- MOVE 0 TO LK-NUM-OCORR-MOVTO. */
            _.Move(0, PARAMETROS.LK_NUM_OCORR_MOVTO);

            /*" -1618- MOVE 101 TO LK-COD-EVENTO . */
            _.Move(101, PARAMETROS.LK_COD_EVENTO);

            /*" -1619- MOVE 'XX' TO LK-IDE-SISTEMA . */
            _.Move("XX", PARAMETROS.LK_IDE_SISTEMA);

            /*" -1620- MOVE '0020071228' TO LK-DTH-MOVIMENTO . */
            _.Move("0020071228", PARAMETROS.LK_DTH_MOVIMENTO);

            /*" -1621- MOVE 4 TO LK-IND-ESTRUTURA . */
            _.Move(4, PARAMETROS.LK_IND_ESTRUTURA);

            /*" -1622- MOVE 6 TO LK-IND-ORIGEM-FUNC. */
            _.Move(6, PARAMETROS.LK_IND_ORIGEM_FUNC);

            /*" -1623- MOVE 1 TO LK-IND-EVENTO . */
            _.Move(1, PARAMETROS.LK_IND_EVENTO);

            /*" -1624- MOVE 'SIW7A' TO LK-NOM-PROGRAMA . */
            _.Move("SIW7A", PARAMETROS.LK_NOM_PROGRAMA);

            /*" -1625- MOVE 'TE71541' TO LK-COD-USUARIO . */
            _.Move("TE71541", PARAMETROS.LK_COD_USUARIO);

            /*" -1626- MOVE 3 TO LK-IND-RELACIONAMENTO. */
            _.Move(3, PARAMETROS.LK_IND_RELACIONAMENTO);

            /*" -1627- MOVE ' ' TO LK-HORA-OPERACAO . */
            _.Move(" ", PARAMETROS.LK_HORA_OPERACAO);

            /*" -1628- MOVE 0 TO LK-COD-FONTE . */
            _.Move(0, PARAMETROS.LK_COD_FONTE);

            /*" -1629- MOVE 0 TO LK-NUM-RCAP . */
            _.Move(0, PARAMETROS.LK_NUM_RCAP);

            /*" -1630- MOVE 109300001028 TO LK-NUM-APOL-SINISTRO. */
            _.Move(109300001028, PARAMETROS.LK_NUM_APOL_SINISTRO);

            /*" -1631- MOVE 1181 TO LK-COD-OPERACAO-SI. */
            _.Move(1181, PARAMETROS.LK_COD_OPERACAO_SI);

            /*" -1632- MOVE 0 TO LK-NUM-CERTIFICADO. */
            _.Move(0, PARAMETROS.LK_NUM_CERTIFICADO);

            /*" -1632- MOVE 0 TO LK-NUM-TITULO . */
            _.Move(0, PARAMETROS.LK_NUM_TITULO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010_EXIT*/
    }
}