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
using Sias.Geral.DB2.GEJVS002;

namespace Code
{
    public class GEJVS002
    {
        public bool IsCall { get; set; }

        public GEJVS002()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------                                              */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................                                            */
        /*"      *   PROGRAMA ...............  GEJVS002                                  */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA/PROGRAMADOR....  HERVAL SOUZA                       *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO/2019                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  RECUPERAR INFORMA��ES DA TABELA    *      */
        /*"      *                             PARAMETROS_GERAIS PARA OS PROGRAMAS*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              DCLGEN            ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * PARAMETROS_GERAIS                   PARAMGER          INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"01     WAREA-WORK.*/
        public GEJVS002_WAREA_WORK WAREA_WORK { get; set; } = new GEJVS002_WAREA_WORK();
        public class GEJVS002_WAREA_WORK : VarBasis
        {
            /*"  05   WHOST-SIAS               PIC S9(004) COMP-5 VALUE  +0.*/
            public IntBasis WHOST_SIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   WHOST-PREV               PIC S9(004) COMP-5 VALUE +10.*/
            public IntBasis WHOST_PREV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +10);
            /*"  05   WHOST-JV                 PIC S9(004) COMP-5 VALUE +11.*/
            public IntBasis WHOST_JV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +11);
            /*"  05   WS-GE074-FIMCUR          PIC  X(003)        VALUE 'NAO'.*/
            public StringBasis WS_GE074_FIMCUR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"  05   WS-PROGRAMA              PIC  X(008)        VALUE  SPACES*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05   WS-PRIMEIRA-VEZ          PIC  X(003)        VALUE 'SIM'.*/
            public StringBasis WS_PRIMEIRA_VEZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIM");
        }


        public Copies.GEJVWERR GEJVWERR { get; set; } = new Copies.GEJVWERR();
        public Copies.GEJVWDTA GEJVWDTA { get; set; } = new Copies.GEJVWDTA();
        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Dclgens.PARAMGER PARAMGER { get; set; } = new Dclgens.PARAMGER();
        public GEJVS002_GE074_CURSOR GE074_CURSOR { get; set; } = new GEJVS002_GE074_CURSOR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GEJVW002 GEJVW002_P, GEJVWCNT GEJVWCNT_P) //PROCEDURE DIVISION USING 
        /*PROCEDURE DIVISION
        LK_GEJVW002_NOM_PROG_ORIGEM
        LK_GEJVW002_COD_USUARIO_ORIGEM
        LK_GEJVW002_SIAS_NUM_EMP
        LK_GEJVW002_SIAS_DTA_INI
        LK_GEJVW002_SIAS_COD_LIDER
        LK_GEJVW002_SIAS_COD_CGCCPF
        LK_GEJVW002_SIAS_COD_EMP_CAP
        LK_GEJVW002_PREV_NUM_EMP
        LK_GEJVW002_PREV_DTA_INI
        LK_GEJVW002_PREV_COD_LIDER
        LK_GEJVW002_PREV_COD_CGCCPF
        LK_GEJVW002_PREV_COD_EMP_CAP
        LK_GEJVW002_JV_NUM_EMP
        LK_GEJVW002_JV_DTA_INI
        LK_GEJVW002_JV_COD_LIDER
        LK_GEJVW002_JV_COD_CGCCPF
        LK_GEJVW002_JV_COD_EMP_CAP
        LK_GEJVWCNT_IND_ERRO
        LK_GEJVWCNT_MENSAGEM_RETORNO
        LK_GEJVWCNT_NOME_TABELA
        LK_GEJVWCNT_SQLCODE
        LK_GEJVWCNT_SQLERRMC*/
        {
            try
            {
                this.GEJVW002 = GEJVW002_P;
                this.GEJVWCNT = GEJVWCNT_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-ROT-PRINCIPAL-SECTION */

                R0000_00_ROT_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { GEJVW002, GEJVWCNT };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-ROT-PRINCIPAL-SECTION */
        private void R0000_00_ROT_PRINCIPAL_SECTION()
        {
            /*" -117- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -120- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -123- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -129- INITIALIZE LK-ERRO-DB2. */
            _.Initialize(
                GEJVWERR.LK_ERRO_DB2
            );

            /*" -131- INITIALIZE LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Initialize(
                GEJVWCNT.LK_GEJVWCNT_IND_ERRO
                , GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO
                , GEJVWCNT.LK_GEJVWCNT_NOME_TABELA
                , GEJVWCNT.LK_GEJVWCNT_SQLCODE
                , GEJVWCNT.LK_GEJVWCNT_SQLERRMC
            );

            /*" -147- INITIALIZE LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-EMP-CAP. */
            _.Initialize(
                GEJVW002.LK_GEJVW002_SIAS_NUM_EMP
                , GEJVW002.LK_GEJVW002_SIAS_DTA_INI
                , GEJVW002.LK_GEJVW002_SIAS_COD_CGCCPF
                , GEJVW002.LK_GEJVW002_SIAS_COD_LIDER
                , GEJVW002.LK_GEJVW002_SIAS_COD_EMP_CAP
                , GEJVW002.LK_GEJVW002_PREV_NUM_EMP
                , GEJVW002.LK_GEJVW002_PREV_DTA_INI
                , GEJVW002.LK_GEJVW002_PREV_COD_CGCCPF
                , GEJVW002.LK_GEJVW002_PREV_COD_LIDER
                , GEJVW002.LK_GEJVW002_PREV_COD_EMP_CAP
                , GEJVW002.LK_GEJVW002_JV_NUM_EMP
                , GEJVW002.LK_GEJVW002_JV_DTA_INI
                , GEJVW002.LK_GEJVW002_JV_COD_CGCCPF
                , GEJVW002.LK_GEJVW002_JV_COD_LIDER
                , GEJVW002.LK_GEJVW002_JV_COD_EMP_CAP
            );

            /*" -150- MOVE '0001-01-01' TO LK-GEJVW002-SIAS-DTA-INI. */
            _.Move("0001-01-01", GEJVW002.LK_GEJVW002_SIAS_DTA_INI);

            /*" -154- MOVE '9999-12-31' TO LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-JV-DTA-INI. */
            _.Move("9999-12-31", GEJVW002.LK_GEJVW002_PREV_DTA_INI, GEJVW002.LK_GEJVW002_JV_DTA_INI);

            /*" -154- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), GEJVWDTA.RSS_WORK_DATAS.WS_CURRENT_DATE);

            /*" -154- MOVE FUNCTION WHEN-COMPILED TO WS-WHEN-COMPILED */
            _.Move(_.WhenCompiled(), GEJVWDTA.RSS_WORK_DATAS.WS_WHEN_COMPILED);

            /*" -154- STRING WS-WHEN-ANO '-' WS-WHEN-MES '-' WS-WHEN-DIA ' ' WS-WHEN-HORA ':' WS-WHEN-MIN ':' WS-WHEN-SEG ',' WS-WHEN-DECSEG DELIMITED BY SIZE INTO WS-COMPILED-EDIT */
            #region STRING
            var spl1 = GEJVWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_ANO.GetMoveValues();
            spl1 += "-";
            var spl2 = GEJVWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_MES.GetMoveValues();
            spl2 += "-";
            var spl3 = GEJVWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_DIA.GetMoveValues();
            spl3 += " ";
            var spl4 = GEJVWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_HORA.GetMoveValues();
            spl4 += ":";
            var spl5 = GEJVWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_MIN.GetMoveValues();
            spl5 += ":";
            var spl6 = GEJVWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_SEG.GetMoveValues();
            spl6 += ",";
            var spl7 = GEJVWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_DECSEG.GetMoveValues();
            var results8 = spl1 + spl2 + spl3 + spl4 + spl5 + spl6 + spl7;
            _.Move(results8, GEJVWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT);
            #endregion

            /*" -156- STRING WS-CDTE-ANO '-' WS-CDTE-MES '-' WS-CDTE-DIA ' ' WS-CDTE-HORA ':' WS-CDTE-MIN ':' WS-CDTE-SEG ',' WS-CDTE-DECSEG DELIMITED BY SIZE INTO WS-CURRENT-EDIT */
            #region STRING
            var spl8 = GEJVWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_ANO.GetMoveValues();
            spl8 += "-";
            var spl9 = GEJVWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_MES.GetMoveValues();
            spl9 += "-";
            var spl10 = GEJVWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_DIA.GetMoveValues();
            spl10 += " ";
            var spl11 = GEJVWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_HORA.GetMoveValues();
            spl11 += ":";
            var spl12 = GEJVWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_MIN.GetMoveValues();
            spl12 += ":";
            var spl13 = GEJVWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_SEG.GetMoveValues();
            spl13 += ",";
            var spl14 = GEJVWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_DECSEG.GetMoveValues();
            var results15 = spl8 + spl9 + spl10 + spl11 + spl12 + spl13 + spl14;
            _.Move(results15, GEJVWDTA.RSS_WORK_DATAS.WS_CURRENT_EDIT);
            #endregion

            /*" -157- IF WS-PRIMEIRA-VEZ = 'SIM' */

            if (WAREA_WORK.WS_PRIMEIRA_VEZ == "SIM")
            {

                /*" -158- MOVE 'NAO' TO WS-PRIMEIRA-VEZ */
                _.Move("NAO", WAREA_WORK.WS_PRIMEIRA_VEZ);

                /*" -160- DISPLAY 'GEJVS002: RECUPERAR INFORMACOES PARAMETROS. ' 'CATALOGA��O: ' WS-COMPILED-EDIT */

                $"GEJVS002: RECUPERAR INFORMACOES PARAMETROS. CATALOGA��O: {GEJVWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT}"
                .Display();

                /*" -162- END-IF. */
            }


            /*" -164- PERFORM P7074-GE4-DECLARE */

            P7074_GE4_DECLARE_SECTION();

            /*" -166- PERFORM P7074-GE5-FETCH */

            P7074_GE5_FETCH_SECTION();

            /*" -167- IF WS-GE074-FIMCUR = 'SIM' */

            if (WAREA_WORK.WS_GE074_FIMCUR == "SIM")
            {

                /*" -169- MOVE 'NAO ACHEI NENHUM DADO NA PARAMETROS_GERAIS' TO LK-GEJVWCNT-MENSAGEM-RETORNO */
                _.Move("NAO ACHEI NENHUM DADO NA PARAMETROS_GERAIS", GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO);

                /*" -171- MOVE 'SEGUROS.PARAMETROS_GERAIS' TO LK-GEJVWCNT-NOME-TABELA */
                _.Move("SEGUROS.PARAMETROS_GERAIS", GEJVWCNT.LK_GEJVWCNT_NOME_TABELA);

                /*" -172- MOVE 1 TO LK-GEJVWCNT-IND-ERRO */
                _.Move(1, GEJVWCNT.LK_GEJVWCNT_IND_ERRO);

                /*" -173- MOVE ZEROS TO LK-GEJVWCNT-SQLCODE */
                _.Move(0, GEJVWCNT.LK_GEJVWCNT_SQLCODE);

                /*" -174- MOVE SPACES TO LK-GEJVWCNT-SQLERRMC */
                _.Move("", GEJVWCNT.LK_GEJVWCNT_SQLERRMC);

                /*" -176- MOVE 'R0000-00-ROT-PRINCIPAL' TO LKERR-ROTINA */
                _.Move("R0000-00-ROT-PRINCIPAL", GEJVWERR.LKERR_REG.LKERR_ROTINA);

                /*" -177- MOVE SPACES TO LKERR-FUNCAO */
                _.Move("", GEJVWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -179- MOVE 'SEGUROS.PARAMETROS_GERAIS' TO LKERR-OBJETOS */
                _.Move("SEGUROS.PARAMETROS_GERAIS", GEJVWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -180- MOVE SPACES TO LKERR-ELEMENTOS */
                _.Move("", GEJVWERR.LKERR_REG.LKERR_ELEMENTOS);

                /*" -181- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR_SECTION(); //GOTO
                return;

                /*" -183- END-IF. */
            }


            /*" -184- PERFORM UNTIL WS-GE074-FIMCUR = 'SIM' */

            while (!(WAREA_WORK.WS_GE074_FIMCUR == "SIM"))
            {

                /*" -185- PERFORM P1000-00-MOVE */

                P1000_00_MOVE_SECTION();

                /*" -186- PERFORM P7074-GE5-FETCH */

                P7074_GE5_FETCH_SECTION();

                /*" -188- END-PERFORM. */
            }

            /*" -189- IF LK-GEJVW002-SIAS-COD-LIDER = ZEROS */

            if (GEJVW002.LK_GEJVW002_SIAS_COD_LIDER == 00)
            {

                /*" -191- MOVE 'NAO ACHEI DADOS DO SIAS NA PARAMETROS_GERAIS' TO LK-GEJVWCNT-MENSAGEM-RETORNO */
                _.Move("NAO ACHEI DADOS DO SIAS NA PARAMETROS_GERAIS", GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO);

                /*" -222- END-IF. */
            }


            /*" -222- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" P1000-00-MOVE-SECTION */
        private void P1000_00_MOVE_SECTION()
        {
            /*" -235- IF PARAMGER-COD-EMPRESA = WHOST-SIAS */

            if (PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA == WAREA_WORK.WHOST_SIAS)
            {

                /*" -236- MOVE PARAMGER-COD-EMPRESA TO LK-GEJVW002-SIAS-NUM-EMP */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA, GEJVW002.LK_GEJVW002_SIAS_NUM_EMP);

                /*" -238- MOVE PARAMGER-DATA-INIVIGENCIA TO LK-GEJVW002-SIAS-DTA-INI */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_DATA_INIVIGENCIA, GEJVW002.LK_GEJVW002_SIAS_DTA_INI);

                /*" -239- MOVE PARAMGER-COD-CGCCPF TO LK-GEJVW002-SIAS-COD-CGCCPF */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_CGCCPF, GEJVW002.LK_GEJVW002_SIAS_COD_CGCCPF);

                /*" -241- MOVE PARAMGER-CODIGO-LIDER TO LK-GEJVW002-SIAS-COD-LIDER */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_CODIGO_LIDER, GEJVW002.LK_GEJVW002_SIAS_COD_LIDER);

                /*" -243- MOVE PARAMGER-COD-EMPRESA-CAP TO LK-GEJVW002-SIAS-COD-EMP-CAP */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP, GEJVW002.LK_GEJVW002_SIAS_COD_EMP_CAP);

                /*" -245- END-IF. */
            }


            /*" -246- IF PARAMGER-COD-EMPRESA = WHOST-PREV */

            if (PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA == WAREA_WORK.WHOST_PREV)
            {

                /*" -247- MOVE PARAMGER-COD-EMPRESA TO LK-GEJVW002-PREV-NUM-EMP */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA, GEJVW002.LK_GEJVW002_PREV_NUM_EMP);

                /*" -249- MOVE PARAMGER-DATA-INIVIGENCIA TO LK-GEJVW002-PREV-DTA-INI */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_DATA_INIVIGENCIA, GEJVW002.LK_GEJVW002_PREV_DTA_INI);

                /*" -250- MOVE PARAMGER-COD-CGCCPF TO LK-GEJVW002-PREV-COD-CGCCPF */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_CGCCPF, GEJVW002.LK_GEJVW002_PREV_COD_CGCCPF);

                /*" -252- MOVE PARAMGER-CODIGO-LIDER TO LK-GEJVW002-PREV-COD-LIDER */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_CODIGO_LIDER, GEJVW002.LK_GEJVW002_PREV_COD_LIDER);

                /*" -254- MOVE PARAMGER-COD-EMPRESA-CAP TO LK-GEJVW002-PREV-COD-EMP-CAP */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP, GEJVW002.LK_GEJVW002_PREV_COD_EMP_CAP);

                /*" -256- END-IF. */
            }


            /*" -257- IF PARAMGER-COD-EMPRESA = WHOST-JV */

            if (PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA == WAREA_WORK.WHOST_JV)
            {

                /*" -258- MOVE PARAMGER-COD-EMPRESA TO LK-GEJVW002-JV-NUM-EMP */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA, GEJVW002.LK_GEJVW002_JV_NUM_EMP);

                /*" -260- MOVE PARAMGER-DATA-INIVIGENCIA TO LK-GEJVW002-JV-DTA-INI */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_DATA_INIVIGENCIA, GEJVW002.LK_GEJVW002_JV_DTA_INI);

                /*" -261- MOVE PARAMGER-COD-CGCCPF TO LK-GEJVW002-JV-COD-CGCCPF */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_CGCCPF, GEJVW002.LK_GEJVW002_JV_COD_CGCCPF);

                /*" -263- MOVE PARAMGER-CODIGO-LIDER TO LK-GEJVW002-JV-COD-LIDER */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_CODIGO_LIDER, GEJVW002.LK_GEJVW002_JV_COD_LIDER);

                /*" -265- MOVE PARAMGER-COD-EMPRESA-CAP TO LK-GEJVW002-JV-COD-EMP-CAP */
                _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP, GEJVW002.LK_GEJVW002_JV_COD_EMP_CAP);

                /*" -265- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" P7074-GE4-DECLARE-SECTION */
        private void P7074_GE4_DECLARE_SECTION()
        {
            /*" -307- PERFORM P7074_GE4_DECLARE_DB_DECLARE_1 */

            P7074_GE4_DECLARE_DB_DECLARE_1();

            /*" -309- PERFORM P7074_GE4_DECLARE_DB_OPEN_1 */

            P7074_GE4_DECLARE_DB_OPEN_1();

            /*" -312- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -313- MOVE 'ERRO NO FETCH' TO LK-GEJVWCNT-MENSAGEM-RETORNO */
                _.Move("ERRO NO FETCH", GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO);

                /*" -315- MOVE 'SEGUROS.PARAMETROS_GERAIS' TO LK-GEJVWCNT-NOME-TABELA */
                _.Move("SEGUROS.PARAMETROS_GERAIS", GEJVWCNT.LK_GEJVWCNT_NOME_TABELA);

                /*" -316- MOVE 2 TO LK-GEJVWCNT-IND-ERRO */
                _.Move(2, GEJVWCNT.LK_GEJVWCNT_IND_ERRO);

                /*" -317- MOVE SQLCODE TO LK-GEJVWCNT-SQLCODE */
                _.Move(DB.SQLCODE, GEJVWCNT.LK_GEJVWCNT_SQLCODE);

                /*" -318- MOVE SQLERRMC TO LK-GEJVWCNT-SQLERRMC */
                _.Move(DB.SQLERRMC, GEJVWCNT.LK_GEJVWCNT_SQLERRMC);

                /*" -319- MOVE 'P7074-GE4-DECLARE' TO LKERR-ROTINA */
                _.Move("P7074-GE4-DECLARE", GEJVWERR.LKERR_REG.LKERR_ROTINA);

                /*" -320- MOVE 'OPEN' TO LKERR-FUNCAO */
                _.Move("OPEN", GEJVWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -322- MOVE 'SEGUROS.PARAMETROS_GERAIS' TO LKERR-OBJETOS */
                _.Move("SEGUROS.PARAMETROS_GERAIS", GEJVWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -323- MOVE SPACES TO LKERR-ELEMENTOS */
                _.Move("", GEJVWERR.LKERR_REG.LKERR_ELEMENTOS);

                /*" -324- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR_SECTION(); //GOTO
                return;

                /*" -324- END-IF. */
            }


        }

        [StopWatch]
        /*" P7074-GE4-DECLARE-DB-DECLARE-1 */
        public void P7074_GE4_DECLARE_DB_DECLARE_1()
        {
            /*" -307- EXEC SQL DECLARE GE074_CURSOR CURSOR WITH HOLD FOR SELECT PARAMGER.DATA_INIVIGENCIA ,PARAMGER.DATA_TERVIGENCIA ,PARAMGER.COD_MOEDA ,PARAMGER.COD_BANCO ,PARAMGER.COD_AGENCIA ,PARAMGER.OPCAO_BANCO ,PARAMGER.DIF_PREMIOS ,PARAMGER.FAIXA_APOL_MANUAL ,PARAMGER.FAIXA_ENDOSCOB_MAN ,PARAMGER.DATA_FATURAVG_AUT ,PARAMGER.CAPITAL_SOCIAL ,PARAMGER.CAPITAL_REALIZADO ,PARAMGER.CAPITAL_VINCULADO ,PARAMGER.ULT_AVISO_CREDITO ,PARAMGER.CODIGO_LIDER ,PARAMGER.NUM_RELACAO ,PARAMGER.COD_EMPRESA ,VALUE(PARAMGER.COD_CGCCPF, 0) ,VALUE(PARAMGER.COD_EMPRESA_CAP, 0) FROM SEGUROS.PARAMETROS_GERAIS PARAMGER WHERE PARAMGER.COD_EMPRESA IN (:WHOST-SIAS, :WHOST-PREV, :WHOST-JV) ORDER BY PARAMGER.COD_EMPRESA WITH UR END-EXEC. */
            GE074_CURSOR = new GEJVS002_GE074_CURSOR(true);
            string GetQuery_GE074_CURSOR()
            {
                var query = @$"SELECT 
							PARAMGER.DATA_INIVIGENCIA 
							,PARAMGER.DATA_TERVIGENCIA 
							,PARAMGER.COD_MOEDA 
							,PARAMGER.COD_BANCO 
							,PARAMGER.COD_AGENCIA 
							,PARAMGER.OPCAO_BANCO 
							,PARAMGER.DIF_PREMIOS 
							,PARAMGER.FAIXA_APOL_MANUAL 
							,PARAMGER.FAIXA_ENDOSCOB_MAN 
							,PARAMGER.DATA_FATURAVG_AUT 
							,PARAMGER.CAPITAL_SOCIAL 
							,PARAMGER.CAPITAL_REALIZADO 
							,PARAMGER.CAPITAL_VINCULADO 
							,PARAMGER.ULT_AVISO_CREDITO 
							,PARAMGER.CODIGO_LIDER 
							,PARAMGER.NUM_RELACAO 
							,PARAMGER.COD_EMPRESA 
							,VALUE(PARAMGER.COD_CGCCPF
							, 0) 
							,VALUE(PARAMGER.COD_EMPRESA_CAP
							, 0) 
							FROM SEGUROS.PARAMETROS_GERAIS PARAMGER 
							WHERE PARAMGER.COD_EMPRESA IN ('{WAREA_WORK.WHOST_SIAS}'
							, 
							'{WAREA_WORK.WHOST_PREV}'
							, 
							'{WAREA_WORK.WHOST_JV}') 
							ORDER BY PARAMGER.COD_EMPRESA";

                return query;
            }
            GE074_CURSOR.GetQueryEvent += GetQuery_GE074_CURSOR;

        }

        [StopWatch]
        /*" P7074-GE4-DECLARE-DB-OPEN-1 */
        public void P7074_GE4_DECLARE_DB_OPEN_1()
        {
            /*" -309- EXEC SQL OPEN GE074_CURSOR END-EXEC. */

            GE074_CURSOR.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7029_RR4_EXIT*/

        [StopWatch]
        /*" P7074-GE5-FETCH-SECTION */
        private void P7074_GE5_FETCH_SECTION()
        {
            /*" -339- MOVE 'NAO' TO WS-GE074-FIMCUR. */
            _.Move("NAO", WAREA_WORK.WS_GE074_FIMCUR);

            /*" -361- PERFORM P7074_GE5_FETCH_DB_FETCH_1 */

            P7074_GE5_FETCH_DB_FETCH_1();

            /*" -364- IF SQLCODE NOT = ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -365- MOVE 'ERRO NO FETCH' TO LK-GEJVWCNT-MENSAGEM-RETORNO */
                _.Move("ERRO NO FETCH", GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO);

                /*" -367- MOVE 'SEGUROS.PARAMETROS_GERAIS' TO LK-GEJVWCNT-NOME-TABELA */
                _.Move("SEGUROS.PARAMETROS_GERAIS", GEJVWCNT.LK_GEJVWCNT_NOME_TABELA);

                /*" -368- MOVE 2 TO LK-GEJVWCNT-IND-ERRO */
                _.Move(2, GEJVWCNT.LK_GEJVWCNT_IND_ERRO);

                /*" -369- MOVE SQLCODE TO LK-GEJVWCNT-SQLCODE */
                _.Move(DB.SQLCODE, GEJVWCNT.LK_GEJVWCNT_SQLCODE);

                /*" -370- MOVE SQLERRMC TO LK-GEJVWCNT-SQLERRMC */
                _.Move(DB.SQLERRMC, GEJVWCNT.LK_GEJVWCNT_SQLERRMC);

                /*" -371- MOVE 'P7074-GE5-FETCH' TO LKERR-ROTINA */
                _.Move("P7074-GE5-FETCH", GEJVWERR.LKERR_REG.LKERR_ROTINA);

                /*" -372- MOVE 'FETCH CURSOR' TO LKERR-FUNCAO */
                _.Move("FETCH CURSOR", GEJVWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -374- MOVE 'SEGUROS.PARAMETROS_GERAIS' TO LKERR-OBJETOS */
                _.Move("SEGUROS.PARAMETROS_GERAIS", GEJVWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -375- MOVE SPACES TO LKERR-ELEMENTOS */
                _.Move("", GEJVWERR.LKERR_REG.LKERR_ELEMENTOS);

                /*" -376- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR_SECTION(); //GOTO
                return;

                /*" -378- END-IF. */
            }


            /*" -379- IF SQLCODE = ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -380- GO TO P7074-GE5-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P7074_GE5_EXIT*/ //GOTO
                return;

                /*" -382- END-IF. */
            }


            /*" -384- MOVE 'SIM' TO WS-GE074-FIMCUR. */
            _.Move("SIM", WAREA_WORK.WS_GE074_FIMCUR);

            /*" -384- PERFORM P7074_GE5_FETCH_DB_CLOSE_1 */

            P7074_GE5_FETCH_DB_CLOSE_1();

            /*" -387- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -388- MOVE 'ERRO NO CLOSE' TO LK-GEJVWCNT-MENSAGEM-RETORNO */
                _.Move("ERRO NO CLOSE", GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO);

                /*" -390- MOVE 'SEGUROS.PARAMETROS_GERAIS' TO LK-GEJVWCNT-NOME-TABELA */
                _.Move("SEGUROS.PARAMETROS_GERAIS", GEJVWCNT.LK_GEJVWCNT_NOME_TABELA);

                /*" -391- MOVE 2 TO LK-GEJVWCNT-IND-ERRO */
                _.Move(2, GEJVWCNT.LK_GEJVWCNT_IND_ERRO);

                /*" -392- MOVE SQLCODE TO LK-GEJVWCNT-SQLCODE */
                _.Move(DB.SQLCODE, GEJVWCNT.LK_GEJVWCNT_SQLCODE);

                /*" -393- MOVE SQLERRMC TO LK-GEJVWCNT-SQLERRMC */
                _.Move(DB.SQLERRMC, GEJVWCNT.LK_GEJVWCNT_SQLERRMC);

                /*" -394- MOVE 'P7074-GE5-FETCH' TO LKERR-ROTINA */
                _.Move("P7074-GE5-FETCH", GEJVWERR.LKERR_REG.LKERR_ROTINA);

                /*" -395- MOVE 'CLOSE CURSOR' TO LKERR-FUNCAO */
                _.Move("CLOSE CURSOR", GEJVWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -397- MOVE 'SEGUROS.PARAMETROS_GERAIS' TO LKERR-OBJETOS */
                _.Move("SEGUROS.PARAMETROS_GERAIS", GEJVWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -398- MOVE SPACES TO LKERR-ELEMENTOS */
                _.Move("", GEJVWERR.LKERR_REG.LKERR_ELEMENTOS);

                /*" -399- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR_SECTION(); //GOTO
                return;

                /*" -399- END-IF. */
            }


        }

        [StopWatch]
        /*" P7074-GE5-FETCH-DB-FETCH-1 */
        public void P7074_GE5_FETCH_DB_FETCH_1()
        {
            /*" -361- EXEC SQL FETCH GE074_CURSOR INTO :PARAMGER-DATA-INIVIGENCIA ,:PARAMGER-DATA-TERVIGENCIA ,:PARAMGER-COD-MOEDA ,:PARAMGER-COD-BANCO ,:PARAMGER-COD-AGENCIA ,:PARAMGER-OPCAO-BANCO ,:PARAMGER-DIF-PREMIOS ,:PARAMGER-FAIXA-APOL-MANUAL ,:PARAMGER-FAIXA-ENDOSCOB-MAN ,:PARAMGER-DATA-FATURAVG-AUT ,:PARAMGER-CAPITAL-SOCIAL ,:PARAMGER-CAPITAL-REALIZADO ,:PARAMGER-CAPITAL-VINCULADO ,:PARAMGER-ULT-AVISO-CREDITO ,:PARAMGER-CODIGO-LIDER ,:PARAMGER-NUM-RELACAO ,:PARAMGER-COD-EMPRESA ,:PARAMGER-COD-CGCCPF ,:PARAMGER-COD-EMPRESA-CAP END-EXEC. */

            if (GE074_CURSOR.Fetch())
            {
                _.Move(GE074_CURSOR.PARAMGER_DATA_INIVIGENCIA, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_DATA_INIVIGENCIA);
                _.Move(GE074_CURSOR.PARAMGER_DATA_TERVIGENCIA, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_DATA_TERVIGENCIA);
                _.Move(GE074_CURSOR.PARAMGER_COD_MOEDA, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_MOEDA);
                _.Move(GE074_CURSOR.PARAMGER_COD_BANCO, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_BANCO);
                _.Move(GE074_CURSOR.PARAMGER_COD_AGENCIA, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_AGENCIA);
                _.Move(GE074_CURSOR.PARAMGER_OPCAO_BANCO, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_OPCAO_BANCO);
                _.Move(GE074_CURSOR.PARAMGER_DIF_PREMIOS, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_DIF_PREMIOS);
                _.Move(GE074_CURSOR.PARAMGER_FAIXA_APOL_MANUAL, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_FAIXA_APOL_MANUAL);
                _.Move(GE074_CURSOR.PARAMGER_FAIXA_ENDOSCOB_MAN, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_FAIXA_ENDOSCOB_MAN);
                _.Move(GE074_CURSOR.PARAMGER_DATA_FATURAVG_AUT, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_DATA_FATURAVG_AUT);
                _.Move(GE074_CURSOR.PARAMGER_CAPITAL_SOCIAL, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_CAPITAL_SOCIAL);
                _.Move(GE074_CURSOR.PARAMGER_CAPITAL_REALIZADO, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_CAPITAL_REALIZADO);
                _.Move(GE074_CURSOR.PARAMGER_CAPITAL_VINCULADO, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_CAPITAL_VINCULADO);
                _.Move(GE074_CURSOR.PARAMGER_ULT_AVISO_CREDITO, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_ULT_AVISO_CREDITO);
                _.Move(GE074_CURSOR.PARAMGER_CODIGO_LIDER, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_CODIGO_LIDER);
                _.Move(GE074_CURSOR.PARAMGER_NUM_RELACAO, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_NUM_RELACAO);
                _.Move(GE074_CURSOR.PARAMGER_COD_EMPRESA, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA);
                _.Move(GE074_CURSOR.PARAMGER_COD_CGCCPF, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_CGCCPF);
                _.Move(GE074_CURSOR.PARAMGER_COD_EMPRESA_CAP, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP);
            }

        }

        [StopWatch]
        /*" P7074-GE5-FETCH-DB-CLOSE-1 */
        public void P7074_GE5_FETCH_DB_CLOSE_1()
        {
            /*" -384- EXEC SQL CLOSE GE074_CURSOR END-EXEC. */

            GE074_CURSOR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7074_GE5_EXIT*/

        [StopWatch]
        /*" P9999-CHAMA-RSGESERR-SECTION */
        private void P9999_CHAMA_RSGESERR_SECTION()
        {
            /*" -409- MOVE LK-GEJVW002-NOM-PROG-ORIGEM TO LKERR-ORIGEM. */
            _.Move(GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM, GEJVWERR.LKERR_REG.LKERR_ORIGEM);

            /*" -411- MOVE LK-GEJVW002-COD-USUARIO-ORIGEM TO LKERR-USUARIO. */
            _.Move(GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM, GEJVWERR.LKERR_REG.LKERR_USUARIO);

            /*" -412- MOVE 'GEJVS002' TO LKERR-PROGRAMA. */
            _.Move("GEJVS002", GEJVWERR.LKERR_REG.LKERR_PROGRAMA);

            /*" -413- MOVE WS-COMPILED-EDIT TO LKERR-DTHCATAL. */
            _.Move(GEJVWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT, GEJVWERR.LKERR_REG.LKERR_DTHCATAL);

            /*" -415- MOVE LK-GEJVWCNT-MENSAGEM-RETORNO TO LKERR-MENSAGEM. */
            _.Move(GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO, GEJVWERR.LKERR_REG.LKERR_MENSAGEM);

            /*" -417- MOVE LK-GEJVWCNT-IND-ERRO TO LKERR-IND-ERRO. */
            _.Move(GEJVWCNT.LK_GEJVWCNT_IND_ERRO, GEJVWERR.LKERR_REG.LKERR_IND_ERRO);

            /*" -419- MOVE SPACES TO LKERR-LINKAGE */
            _.Move("", GEJVWERR.LKERR_REG.LKERR_LINKAGE);

            /*" -421- MOVE 'GEJVSERR' TO WS-PROGRAMA. */
            _.Move("GEJVSERR", WAREA_WORK.WS_PROGRAMA);

            /*" -423- CALL WS-PROGRAMA USING SQLCA LK-ERRO-DB2. */
            _.Call(WAREA_WORK.WS_PROGRAMA, GEJVWERR);

            /*" -424- MOVE LKERR-MENSAGEM-RETORNO TO LK-GEJVWCNT-MENSAGEM-RETORNO. */
            _.Move(GEJVWERR.LKERR_REG.LKERR_MENSAGEM_RETORNO, GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO);

            /*" -0- FLUXCONTROL_PERFORM P9999_EXIT */

            P9999_EXIT();

        }

        [StopWatch]
        /*" P9999-EXIT */
        private void P9999_EXIT(bool isPerform = false)
        {
            /*" -427- GOBACK. */

            throw new GoBack();

        }
    }
}