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
using Sias.Sinistro.DB2.SICP002S;

namespace Code
{
    public class SICP002S
    {
        public bool IsCall { get; set; }

        public SICP002S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO/FINANCEIRO                *      */
        /*"      *   PROGRAMA ...............  SICP002S                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HERVAL SOUZA                       *      */
        /*"      *   PROGRAMADOR ............  HERVAL SOUZA                       *      */
        /*"      *   DATA CODIFICACAO .......  NOVEMBRO/ 2021                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                                                      *      */
        /*"      *   CARREGAR OS DADOS DA SI_MOVTO_PAG_COB PARA A TABELA DE       *      */
        /*"      *      HISTORICO: SI_MOVTO_PAG_COB_HIST.                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORICO DE VERSOES                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO: V.03  DATA:27-09-2023  JAZZ: 536680     HERVAL SOUZA   *      */
        /*"      * ALTERACAO: 1- Copiar novos campos da tabela origem e destino   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO: V.02  DATA:28-06-2023  JAZZ: 508892     HERVAL SOUZA   *      */
        /*"      * ALTERACAO: 1- Copiar novos campos da tabela origem e destino   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-PRIMEIRA-VEZ                       PIC  X(003)                                          VALUE 'SIM'.*/
        public StringBasis WS_PRIMEIRA_VEZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIM");
        /*"01     WS-AREA.*/
        public SICP002S_WS_AREA WS_AREA { get; set; } = new SICP002S_WS_AREA();
        public class SICP002S_WS_AREA : VarBasis
        {
            /*"  05   WS-NUM-SINISTRO-ED                 PIC  9(013).*/
            public IntBasis WS_NUM_SINISTRO_ED { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05   WS-COD-OPERACAO-ED                 PIC  9(004).*/
            public IntBasis WS_COD_OPERACAO_ED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05   WS-OCORR-HISTORICO-ED              PIC  9(005).*/
            public IntBasis WS_OCORR_HISTORICO_ED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05   WS-PROGRAMA                        PIC  X(008).*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        }


        public Copies.RSGEWDTA RSGEWDTA { get; set; } = new Copies.RSGEWDTA();
        public Copies.RSGEWERR RSGEWERR { get; set; } = new Copies.RSGEWERR();
        public Copies.SICPW002 SICPW002 { get; set; } = new Copies.SICPW002();
        public Copies.RSGEWCNT RSGEWCNT { get; set; } = new Copies.RSGEWCNT();
        public Dclgens.SI237 SI237 { get; set; } = new Dclgens.SI237();
        public Dclgens.SI238 SI238 { get; set; } = new Dclgens.SI238();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SICPW002 SICPW002_P, RSGEWCNT RSGEWCNT_P) //PROCEDURE DIVISION USING 
        /*SICPW002
        LK_RSGEWCNT_IND_ERRO
        LK_RSGEWCNT_MENSAGEM_RETORNO
        LK_RSGEWCNT_NOME_TABELA
        LK_RSGEWCNT_SQLCODE
        LK_RSGEWCNT_SQLERRMC*/
        {
            try
            {
                this.SICPW002 = SICPW002_P;
                this.RSGEWCNT = RSGEWCNT_P;

                /*" -114- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -116- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -118- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -121- MOVE SPACES TO LK-ERRO-DB2 */
                _.Move("", RSGEWERR.LK_ERRO_DB2);

                /*" -122- . */

                /*" -124- INITIALIZE LK-RSGEWCNT-IND-ERRO LK-RSGEWCNT-MENSAGEM-RETORNO LK-RSGEWCNT-NOME-TABELA LK-RSGEWCNT-SQLCODE LK-RSGEWCNT-SQLERRMC. */
                _.Initialize(
                    RSGEWCNT.LK_RSGEWCNT_IND_ERRO
                    , RSGEWCNT.LK_RSGEWCNT_MENSAGEM_RETORNO
                    , RSGEWCNT.LK_RSGEWCNT_NOME_TABELA
                    , RSGEWCNT.LK_RSGEWCNT_SQLCODE
                    , RSGEWCNT.LK_RSGEWCNT_SQLERRMC
                );

                /*" -124- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
                _.Move(_.CurrentDate(), RSGEWDTA.RSS_WORK_DATAS.WS_CURRENT_DATE);

                /*" -124- MOVE FUNCTION WHEN-COMPILED TO WS-WHEN-COMPILED */
                _.Move(_.WhenCompiled(), RSGEWDTA.RSS_WORK_DATAS.WS_WHEN_COMPILED);

                /*" -124- STRING WS-WHEN-ANO '-' WS-WHEN-MES '-' WS-WHEN-DIA ' ' WS-WHEN-HORA ':' WS-WHEN-MIN ':' WS-WHEN-SEG ',' WS-WHEN-DECSEG DELIMITED BY SIZE INTO WS-COMPILED-EDIT */
                #region STRING
                var spl1 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_ANO.GetMoveValues();
                spl1 += "-";
                var spl2 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_MES.GetMoveValues();
                spl2 += "-";
                var spl3 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_DIA.GetMoveValues();
                spl3 += " ";
                var spl4 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_HORA.GetMoveValues();
                spl4 += ":";
                var spl5 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_MIN.GetMoveValues();
                spl5 += ":";
                var spl6 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_SEG.GetMoveValues();
                spl6 += ",";
                var spl7 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_DECSEG.GetMoveValues();
                var results8 = spl1 + spl2 + spl3 + spl4 + spl5 + spl6 + spl7;
                _.Move(results8, RSGEWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT);
                #endregion

                /*" -125- STRING WS-CDTE-ANO '-' WS-CDTE-MES '-' WS-CDTE-DIA ' ' WS-CDTE-HORA ':' WS-CDTE-MIN ':' WS-CDTE-SEG ',' WS-CDTE-DECSEG DELIMITED BY SIZE INTO WS-CURRENT-EDIT */
                #region STRING
                var spl8 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_ANO.GetMoveValues();
                spl8 += "-";
                var spl9 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_MES.GetMoveValues();
                spl9 += "-";
                var spl10 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_DIA.GetMoveValues();
                spl10 += " ";
                var spl11 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_HORA.GetMoveValues();
                spl11 += ":";
                var spl12 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_MIN.GetMoveValues();
                spl12 += ":";
                var spl13 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_SEG.GetMoveValues();
                spl13 += ",";
                var spl14 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_DECSEG.GetMoveValues();
                var results15 = spl8 + spl9 + spl10 + spl11 + spl12 + spl13 + spl14;
                _.Move(results15, RSGEWDTA.RSS_WORK_DATAS.WS_CURRENT_EDIT);
                #endregion

                /*" -127- . */

                /*" -128- IF WS-PRIMEIRA-VEZ = 'SIM' */

                if (WS_PRIMEIRA_VEZ == "SIM")
                {

                    /*" -129- MOVE 'NAO' TO WS-PRIMEIRA-VEZ */
                    _.Move("NAO", WS_PRIMEIRA_VEZ);

                    /*" -130- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -132- DISPLAY '*  SICP002S -  V.03   CATALOGADO EM: ' WS-COMPILED-EDIT(1:19) */
                    _.Display($"*  SICP002S -  V.03   CATALOGADO EM: {RSGEWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT.Substring(1, 19)}");

                    /*" -133- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -135- END-IF. */
                }


                /*" -136- MOVE LK-SICPW002-NUM-SINISTRO TO SI238-NUM-SINISTRO */
                _.Move(SICPW002.SSICPW002.LK_SICPW002_NUM_SINISTRO, SI238.DCLSI_MOVTO_PGTO_COB_HIST.SI238_NUM_SINISTRO);

                /*" -138- MOVE LK-SICPW002-OCORR-HISTORICO TO SI238-OCORR-HISTORICO */
                _.Move(SICPW002.SSICPW002.LK_SICPW002_OCORR_HISTORICO, SI238.DCLSI_MOVTO_PGTO_COB_HIST.SI238_OCORR_HISTORICO);

                /*" -140- MOVE LK-SICPW002-COD-OPERACAO TO SI238-COD-OPERACAO */
                _.Move(SICPW002.SSICPW002.LK_SICPW002_COD_OPERACAO, SI238.DCLSI_MOVTO_PGTO_COB_HIST.SI238_COD_OPERACAO);

                /*" -142- PERFORM P7238-SI1-INSERT THRU P7238-SI1-EXIT. */

                P7238_SI1_INSERT_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P7238_SI1_EXIT*/


                /*" -142- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { SICPW002, RSGEWCNT, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" P7238-SI1-INSERT-SECTION */
        private void P7238_SI1_INSERT_SECTION()
        {
            /*" -178- PERFORM P7238_SI1_INSERT_DB_INSERT_1 */

            P7238_SI1_INSERT_DB_INSERT_1();

            /*" -181- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -182- MOVE 'ERRO NO INSERT' TO LK-RSGEWCNT-MENSAGEM-RETORNO */
                _.Move("ERRO NO INSERT", RSGEWCNT.LK_RSGEWCNT_MENSAGEM_RETORNO);

                /*" -184- MOVE 'SEGUROS.SI_MOVTO_PGTO_COB_HIST' TO LK-RSGEWCNT-NOME-TABELA */
                _.Move("SEGUROS.SI_MOVTO_PGTO_COB_HIST", RSGEWCNT.LK_RSGEWCNT_NOME_TABELA);

                /*" -185- MOVE 2 TO LK-RSGEWCNT-IND-ERRO */
                _.Move(2, RSGEWCNT.LK_RSGEWCNT_IND_ERRO);

                /*" -186- MOVE SQLCODE TO LK-RSGEWCNT-SQLCODE */
                _.Move(DB.SQLCODE, RSGEWCNT.LK_RSGEWCNT_SQLCODE);

                /*" -187- MOVE SQLERRMC TO LK-RSGEWCNT-SQLERRMC */
                _.Move(DB.SQLERRMC, RSGEWCNT.LK_RSGEWCNT_SQLERRMC);

                /*" -189- MOVE 'P7238-SI1-INSERT' TO LKERR-ROTINA */
                _.Move("P7238-SI1-INSERT", RSGEWERR.LKERR_REG.LKERR_ROTINA);

                /*" -190- MOVE 'INSERT' TO LKERR-FUNCAO */
                _.Move("INSERT", RSGEWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -193- MOVE 'SEGUROS.SI_MOVTO_PGTO_COB_HIST' TO LKERR-OBJETOS */
                _.Move("SEGUROS.SI_MOVTO_PGTO_COB_HIST", RSGEWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -194- MOVE SPACES TO LKERR-ELEMENTOS */
                _.Move("", RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);

                /*" -195- MOVE SI238-NUM-SINISTRO TO WS-NUM-SINISTRO-ED */
                _.Move(SI238.DCLSI_MOVTO_PGTO_COB_HIST.SI238_NUM_SINISTRO, WS_AREA.WS_NUM_SINISTRO_ED);

                /*" -196- MOVE SI238-COD-OPERACAO TO WS-COD-OPERACAO-ED */
                _.Move(SI238.DCLSI_MOVTO_PGTO_COB_HIST.SI238_COD_OPERACAO, WS_AREA.WS_COD_OPERACAO_ED);

                /*" -198- MOVE SI238-OCORR-HISTORICO TO WS-OCORR-HISTORICO-ED */
                _.Move(SI238.DCLSI_MOVTO_PGTO_COB_HIST.SI238_OCORR_HISTORICO, WS_AREA.WS_OCORR_HISTORICO_ED);

                /*" -199- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR_SECTION(); //GOTO
                return;

                /*" -199- END-IF. */
            }


        }

        [StopWatch]
        /*" P7238-SI1-INSERT-DB-INSERT-1 */
        public void P7238_SI1_INSERT_DB_INSERT_1()
        {
            /*" -178- EXEC SQL INSERT INTO SEGUROS.SI_MOVTO_PGTO_COB_HIST ( SELECT NUM_SINISTRO ,OCORR_HISTORICO ,IDE_SISTEMA ,COD_OPERACAO ,SEQ_ID_ENVIO_HIST AS SEQ_SI_PGTO_COB_HIST ,NUM_ID_ENVIO ,SEQ_ID_ENVIO_HIST ,STA_ENVIO_MOVIMENTO ,DTA_SI_ENVIO ,DTA_SI_RETORNO_H ,DTA_EFETIVO_PGTO ,COD_USUARIO ,COD_PROGRAMA ,DTH_CADASTRAMENTO ,SEQ_MOVTO_ARQH ,STA_MOVTO_HISTORICO ,QTD_RETORNO_ARQH ,COD_EMPRESA FROM SEGUROS.SI_MOVTO_PGTO_COB WHERE NUM_SINISTRO = :SI238-NUM-SINISTRO AND COD_OPERACAO = :SI238-COD-OPERACAO AND OCORR_HISTORICO = :SI238-OCORR-HISTORICO ) END-EXEC. */

            var p7238_SI1_INSERT_DB_INSERT_1_Insert1 = new P7238_SI1_INSERT_DB_INSERT_1_Insert1()
            {
                SI238_NUM_SINISTRO = SI238.DCLSI_MOVTO_PGTO_COB_HIST.SI238_NUM_SINISTRO.ToString(),
                SI238_COD_OPERACAO = SI238.DCLSI_MOVTO_PGTO_COB_HIST.SI238_COD_OPERACAO.ToString(),
                SI238_OCORR_HISTORICO = SI238.DCLSI_MOVTO_PGTO_COB_HIST.SI238_OCORR_HISTORICO.ToString(),
            };

            P7238_SI1_INSERT_DB_INSERT_1_Insert1.Execute(p7238_SI1_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7238_SI1_EXIT*/

        [StopWatch]
        /*" P9999-CHAMA-RSGESERR-SECTION */
        private void P9999_CHAMA_RSGESERR_SECTION()
        {
            /*" -210- MOVE LK-SICPW002-NOM-PROGRAMA TO LKERR-ORIGEM. */
            _.Move(SICPW002.SSICPW002.LK_SICPW002_NOM_PROGRAMA, RSGEWERR.LKERR_REG.LKERR_ORIGEM);

            /*" -212- MOVE LK-SICPW002-COD-USUARIO TO LKERR-USUARIO. */
            _.Move(SICPW002.SSICPW002.LK_SICPW002_COD_USUARIO, RSGEWERR.LKERR_REG.LKERR_USUARIO);

            /*" -213- MOVE 'SICP002S' TO LKERR-PROGRAMA. */
            _.Move("SICP002S", RSGEWERR.LKERR_REG.LKERR_PROGRAMA);

            /*" -214- MOVE WS-COMPILED-EDIT TO LKERR-DTHCATAL. */
            _.Move(RSGEWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT, RSGEWERR.LKERR_REG.LKERR_DTHCATAL);

            /*" -216- MOVE LK-RSGEWCNT-MENSAGEM-RETORNO TO LKERR-MENSAGEM. */
            _.Move(RSGEWCNT.LK_RSGEWCNT_MENSAGEM_RETORNO, RSGEWERR.LKERR_REG.LKERR_MENSAGEM);

            /*" -217- MOVE LK-RSGEWCNT-IND-ERRO TO LKERR-IND-ERRO. */
            _.Move(RSGEWCNT.LK_RSGEWCNT_IND_ERRO, RSGEWERR.LKERR_REG.LKERR_IND_ERRO);

            /*" -220- MOVE SPACES TO LKERR-LINKAGE. */
            _.Move("", RSGEWERR.LKERR_REG.LKERR_LINKAGE);

            /*" -228- STRING 'LK-SICP002S:  ' 'COD-USUARIO = "' LK-SICPW002-COD-USUARIO '" NOM-PROGRAMA = "' LK-SICPW002-NOM-PROGRAMA '" NUM-SINISTRO = "' WS-NUM-SINISTRO-ED '" COD-OPERACAO = "' WS-COD-OPERACAO-ED '" OCORR-HISTORICO = "' WS-OCORR-HISTORICO-ED '"' DELIMITED BY SIZE INTO LKERR-LINKAGE */
            #region STRING
            var spl15 = "LK-SICP002S: " + "COD-USUARIO = \"" + SICPW002.SSICPW002.LK_SICPW002_COD_USUARIO.GetMoveValues();
            spl15 += "\" NOM-PROGRAMA = \"";
            var spl16 = SICPW002.SSICPW002.LK_SICPW002_NOM_PROGRAMA.GetMoveValues();
            spl16 += "\" NUM-SINISTRO = \"";
            var spl17 = WS_AREA.WS_NUM_SINISTRO_ED.GetMoveValues();
            spl17 += "\" COD-OPERACAO = \"";
            var spl18 = WS_AREA.WS_COD_OPERACAO_ED.GetMoveValues();
            spl18 += "\" OCORR-HISTORICO = \"";
            var spl19 = WS_AREA.WS_OCORR_HISTORICO_ED.GetMoveValues();
            spl19 += "\"";
            var results20 = spl15 + spl16 + spl17 + spl18 + spl19;
            _.Move(results20, RSGEWERR.LKERR_REG.LKERR_LINKAGE);
            #endregion

            /*" -230- MOVE 'RSGESERR' TO WS-PROGRAMA. */
            _.Move("RSGESERR", WS_AREA.WS_PROGRAMA);

            /*" -233- CALL WS-PROGRAMA USING SQLCA LK-ERRO-DB2. */
            _.Call(WS_AREA.WS_PROGRAMA, RSGEWERR);

            /*" -235- MOVE LKERR-MENSAGEM-RETORNO TO LK-RSGEWCNT-MENSAGEM-RETORNO. */
            _.Move(RSGEWERR.LKERR_REG.LKERR_MENSAGEM_RETORNO, RSGEWCNT.LK_RSGEWCNT_MENSAGEM_RETORNO);

            /*" -236- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -236- MOVE 2 TO LK-RSGEWCNT-IND-ERRO. */
            _.Move(2, RSGEWCNT.LK_RSGEWCNT_IND_ERRO);

            /*" -0- FLUXCONTROL_PERFORM P9999_99_EXIT */

            P9999_99_EXIT();

        }

        [StopWatch]
        /*" P9999-99-EXIT */
        private void P9999_99_EXIT(bool isPerform = false)
        {
            /*" -239- GOBACK. */

            throw new GoBack();

        }
    }
}