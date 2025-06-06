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
using Sias.Outros.DB2.FC1112S;

namespace Code
{
    public class FC1112S
    {
        public bool IsCall { get; set; }

        public FC1112S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  FC                                 *      */
        /*"      *   PROGRAMA ...............  FC1112S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CELIA/EDUILTON                     *      */
        /*"      *   PROGRAMADOR ............  CELIA/EDUILTON                     *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO/2011                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO: MULTIEMPRESA - ALCIONE - APENAS COMPILACAO                  */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... SUB-ROTINA PARA CONTROLE DE EXECUCAO DE PROGMS*      */
        /*"      *                  BATCHES                                       *      */
        /*"      *                                                                *      */
        /*"      *   PARAMETROS....                                               *      */
        /*"      *                                                                *      */
        /*"      *01     REGISTRO-LINKAFC.                                        *      */
        /*"      *                                                                *      */
        /*"      *  05   LKFC-PARM-INPUT.                                         *      */
        /*"      *    10 LKFC-COD-SISTEM      PIC  X(002).   CODIGO DO SISTEMA    *      */
        /*"      *    10 LKFC-NOM-ROTINA      PIC  X(008).   NOME DA ROTINA       *      */
        /*"      *    10 LKFC-SEQ-ETAPA       PIC  9(004).   SEQC DA ETAPA        *      */
        /*"      *    10 LKFC-NOM-PROGM       PIC  X(008).   NOME DO PROGRAMA     *      */
        /*"      *    10 LKFC-QTD-REG-LIDOS   PIC  9(009).   QTDE REGT LIDOS      *      */
        /*"      *    10 LKFC-QTD-REG-PROCS   PIC  9(009).   QTDE REGT PROCESSADOS*      */
        /*"      *    10 LKFC-QTD-REG-GRAVD   PIC  9(009).   QTDE REGT GRAVADOS   *      */
        /*"      *    10 LKFC-QTD-REG-ALTER   PIC  9(009).   QTDE REGT ALTERADOS  *      */
        /*"      *    10 LKFC-QTD-REG-EXCLU   PIC  9(009).   QTDE REGT EXCLUIDOS  *      */
        /*"      *    10 LKFC-STA-EXECUCAO    PIC  X(001).   (=1 OK) OU (=2 ERRO) *      */
        /*"      *                                                                *      */
        /*"      *  05   LKFC-PARM-OUTPUT.                                        *      */
        /*"      *    10 LKFC-SQL-CODE        PIC -9(009).   RETORNO DB2 (=0 OK)  *      */
        /*"      *    10 LKFC-RETN-CODE       PIC  9(002).   CODIGO ERRO (=0 OK)  *      */
        /*"      *    10 LKFC-MENS-ERRO       PIC  X(050).   MENSAFCM DO ERRO     *      */
        /*"      *                                           (MENSAFCM =  ' ' OK) *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  .INFORMAR (INPUT)                                             *      */
        /*"      *                                                                *      */
        /*"      *   - CODIGO DO SISTEMA       - EX.: GL                          *      */
        /*"      *   - NOME DA ROTINA          - EX.: JPGLD01                     *      */
        /*"      *   - SEQC DA ETAPA DA ROTINA - EX.: 01                          *      */
        /*"      *   - NOME DO PROGRAMA        - EX.: GL0037A                     *      */
        /*"      *   - QTDE REGISTROS LIDOS    - EX.: 2573                        *      */
        /*"      *   - QTDE REGT PROCESSADOS   - EX.: 1350                        *      */
        /*"      *   - QTDE REGT GRAVADOS      - EX.: 2416                        *      */
        /*"      *   - QTDE REGT ALTERADOS     - EX.: 38                          *      */
        /*"      *   - QTDE REGT EXCLUIDOS     - EX.: 00                          *      */
        /*"      *   - STATUS DA EXECUCAO DA ETAPA/PROGRAMA                       *      */
        /*"      *     '1' - EXECUCAO OK                                          *      */
        /*"      *     '2' - EXECUCAO COM ERRO (ABEND)                            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  .SAIDA DA SUB-ROTINA (OUTPUT)                                 *      */
        /*"      *                                                                *      */
        /*"      *   - CODIGO DE RETORNO DO SQL(DB2) - EX.: -811                  *      */
        /*"      *   - CODIGO DO ERRO DE CRITICA     - EX.:  99                   *      */
        /*"      *   - MENSAFCM DE ERRO DE CRITICA   - EX.: 'REGISTRO DUPLICADO'  *      */
        /*"      *                                                                *      */
        /*"      *  .VALIDAR NA RESPOSTA O LKFC-RETN-CODE, SE DIFERENTE DE ZERO,  *      */
        /*"      *   HOUVE ERRO NA OBTENCAO E O CAMPO LKFC-MENS-ERRO RETORNA UMA  *      */
        /*"      *   MENSAFCM COM A DESCRICAO DO ERRO ECONTRADO.                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"77      VIND-NOM-PROGRAMA         PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_NOM_PROGRAMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      VIND-DTH-FIM-VIGC         PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DTH_FIM_VIGC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      WHOST-DTCURRENT           PIC  X(010)    VALUE SPACES.*/
        public StringBasis WHOST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01      AREA-DE-WORK.*/
        public FC1112S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new FC1112S_AREA_DE_WORK();
        public class FC1112S_AREA_DE_WORK : VarBasis
        {
            /*" 05     WROT-ATUAL                PIC  X(001)    VALUE SPACES.*/
            public StringBasis WROT_ATUAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*" 05     WETP-ATUAL                PIC  X(001)    VALUE SPACES.*/
            public StringBasis WETP_ATUAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01      REGISTRO-LINKAFC.*/
        }
        public FC1112S_REGISTRO_LINKAFC REGISTRO_LINKAFC { get; set; } = new FC1112S_REGISTRO_LINKAFC();
        public class FC1112S_REGISTRO_LINKAFC : VarBasis
        {
            /*"  05    LKFC-PARM-INPUT.*/
            public FC1112S_LKFC_PARM_INPUT LKFC_PARM_INPUT { get; set; } = new FC1112S_LKFC_PARM_INPUT();
            public class FC1112S_LKFC_PARM_INPUT : VarBasis
            {
                /*"    10  LKFC-COD-SISTEM           PIC  X(002).*/
                public StringBasis LKFC_COD_SISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10  LKFC-NOM-ROTINA           PIC  X(008).*/
                public StringBasis LKFC_NOM_ROTINA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10  LKFC-SEQ-ETAPA            PIC  9(004).*/
                public IntBasis LKFC_SEQ_ETAPA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  LKFC-NOM-PROGM            PIC  X(008).*/
                public StringBasis LKFC_NOM_PROGM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10  LKFC-QTD-REG-LIDOS        PIC  9(009).*/
                public IntBasis LKFC_QTD_REG_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10  LKFC-QTD-REG-PROCS        PIC  9(009).*/
                public IntBasis LKFC_QTD_REG_PROCS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10  LKFC-QTD-REG-GRAVD        PIC  9(009).*/
                public IntBasis LKFC_QTD_REG_GRAVD { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10  LKFC-QTD-REG-ALTER        PIC  9(009).*/
                public IntBasis LKFC_QTD_REG_ALTER { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10  LKFC-QTD-REG-EXCLU        PIC  9(009).*/
                public IntBasis LKFC_QTD_REG_EXCLU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10  LKFC-STA-EXECUCAO         PIC  X(001).*/
                public StringBasis LKFC_STA_EXECUCAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05    LKFC-PARM-OUTPUT.*/
            }
            public FC1112S_LKFC_PARM_OUTPUT LKFC_PARM_OUTPUT { get; set; } = new FC1112S_LKFC_PARM_OUTPUT();
            public class FC1112S_LKFC_PARM_OUTPUT : VarBasis
            {
                /*"    10  LKFC-SQL-CODE             PIC -9(009).*/
                public IntBasis LKFC_SQL_CODE { get; set; } = new IntBasis(new PIC("-9", "9", "-9(009)."));
                /*"    10  LKFC-RETN-CODE            PIC  9(002).*/
                public IntBasis LKFC_RETN_CODE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  LKFC-MENS-ERRO            PIC  X(050).*/
                public StringBasis LKFC_MENS_ERRO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.GE385 GE385 { get; set; } = new Dclgens.GE385();
        public Dclgens.GE386 GE386 { get; set; } = new Dclgens.GE386();
        public Dclgens.GE387 GE387 { get; set; } = new Dclgens.GE387();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(FC1112S_REGISTRO_LINKAFC FC1112S_REGISTRO_LINKAFC_P) //PROCEDURE DIVISION USING 
        /*REGISTRO_LINKAFC*/
        {
            try
            {
                this.REGISTRO_LINKAFC = FC1112S_REGISTRO_LINKAFC_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-ROT-PRINCIPAL-SECTION */

                R0000_00_ROT_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { REGISTRO_LINKAFC };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-ROT-PRINCIPAL-SECTION */
        private void R0000_00_ROT_PRINCIPAL_SECTION()
        {
            /*" -184- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -187- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -190- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -197- INITIALIZE LKFC-PARM-OUTPUT. */
            _.Initialize(
                REGISTRO_LINKAFC.LKFC_PARM_OUTPUT
            );

            /*" -199- IF LKFC-COD-SISTEM = SPACES OR LKFC-COD-SISTEM IS NUMERIC */

            if (REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_COD_SISTEM.IsEmpty() || REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_COD_SISTEM.IsNumeric())
            {

                /*" -201- MOVE 'FC1112S - CODIGO DO SISTEMA INVALIDO' TO LKFC-MENS-ERRO */
                _.Move("FC1112S - CODIGO DO SISTEMA INVALIDO", REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -202- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -204- END-IF. */
            }


            /*" -206- IF LKFC-NOM-ROTINA = SPACES OR LKFC-NOM-ROTINA IS NUMERIC */

            if (REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_NOM_ROTINA.IsEmpty() || REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_NOM_ROTINA.IsNumeric())
            {

                /*" -208- MOVE 'FC1112S - NOME DA ROTINA ESTA INVALIDO' TO LKFC-MENS-ERRO */
                _.Move("FC1112S - NOME DA ROTINA ESTA INVALIDO", REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -209- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -211- END-IF. */
            }


            /*" -212- IF LKFC-SEQ-ETAPA NOT NUMERIC */

            if (!REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_SEQ_ETAPA.IsNumeric())
            {

                /*" -214- MOVE 'FC1112S - SEQUENCIA DA ETAPA NA ROTINA INVALIDA' TO LKFC-MENS-ERRO */
                _.Move("FC1112S - SEQUENCIA DA ETAPA NA ROTINA INVALIDA", REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -215- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -217- END-IF. */
            }


            /*" -218- IF LKFC-NOM-PROGM = SPACES */

            if (REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_NOM_PROGM.IsEmpty())
            {

                /*" -220- MOVE 'FC1112S - NOME DO PROGRAMA ESTA INVALIDO' TO LKFC-MENS-ERRO */
                _.Move("FC1112S - NOME DO PROGRAMA ESTA INVALIDO", REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -221- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -223- END-IF. */
            }


            /*" -224- IF LKFC-STA-EXECUCAO = SPACES */

            if (REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_STA_EXECUCAO.IsEmpty())
            {

                /*" -226- MOVE 'FC1112S - STATUS DE EXECUCAO ESTA INVALIDO' TO LKFC-MENS-ERRO */
                _.Move("FC1112S - STATUS DE EXECUCAO ESTA INVALIDO", REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -227- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -228- ELSE */
            }
            else
            {


                /*" -230- IF LKFC-STA-EXECUCAO = '1' OR '2' OR '0' NEXT SENTENCE */

                if (REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_STA_EXECUCAO.In("1", "2", "0"))
                {

                    /*" -231- ELSE */
                }
                else
                {


                    /*" -233- MOVE 'FC1112S - STATUS DE EXECUCAO NAO PREVISTO' TO LKFC-MENS-ERRO */
                    _.Move("FC1112S - STATUS DE EXECUCAO NAO PREVISTO", REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -234- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -235- END-IF */
                }


                /*" -239- END-IF. */
            }


            /*" -242- INITIALIZE DCLSISTEMAS. */
            _.Initialize(
                SISTEMAS.DCLSISTEMAS
            );

            /*" -244- MOVE LKFC-COD-SISTEM TO SISTEMAS-IDE-SISTEMA. */
            _.Move(REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_COD_SISTEM, SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -249- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -251- INITIALIZE DCLGE-ROTINA-ETAPA. */
            _.Initialize(
                GE386.DCLGE_ROTINA_ETAPA
            );

            /*" -252- MOVE LKFC-NOM-ROTINA TO GE386-NOM-ROTINA. */
            _.Move(REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_NOM_ROTINA, GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_ROTINA);

            /*" -253- MOVE LKFC-SEQ-ETAPA TO GE386-SEQ-ETAPA. */
            _.Move(REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_SEQ_ETAPA, GE386.DCLGE_ROTINA_ETAPA.GE386_SEQ_ETAPA);

            /*" -254- MOVE ZEROS TO GE386-IND-TIPO-ETAPA. */
            _.Move(0, GE386.DCLGE_ROTINA_ETAPA.GE386_IND_TIPO_ETAPA);

            /*" -255- MOVE LKFC-NOM-PROGM TO GE386-NOM-PROGRAMA. */
            _.Move(REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_NOM_PROGM, GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_PROGRAMA);

            /*" -257- MOVE '0' TO GE386-STA-ETAPA. */
            _.Move("0", GE386.DCLGE_ROTINA_ETAPA.GE386_STA_ETAPA);

            /*" -262- PERFORM R0200-00-SELECT-FC-ROT-ETAPA. */

            R0200_00_SELECT_FC_ROT_ETAPA_SECTION();

            /*" -264- INITIALIZE DCLGE-EXEC-ROTINA-ETAPA. */
            _.Initialize(
                GE387.DCLGE_EXEC_ROTINA_ETAPA
            );

            /*" -265- MOVE GE386-NOM-ROTINA TO GE387-NOM-ROTINA. */
            _.Move(GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_ROTINA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NOM_ROTINA);

            /*" -266- MOVE GE386-SEQ-ETAPA TO GE387-SEQ-ETAPA. */
            _.Move(GE386.DCLGE_ROTINA_ETAPA.GE386_SEQ_ETAPA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_SEQ_ETAPA);

            /*" -267- MOVE GE386-DTH-INI-VIGENCIA TO GE387-DTH-INI-VIGENCIA. */
            _.Move(GE386.DCLGE_ROTINA_ETAPA.GE386_DTH_INI_VIGENCIA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTH_INI_VIGENCIA);

            /*" -269- MOVE GE386-QTD-EXEC-ETAPA TO GE387-NUM-EXEC-ETAPA. */
            _.Move(GE386.DCLGE_ROTINA_ETAPA.GE386_QTD_EXEC_ETAPA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NUM_EXEC_ETAPA);

            /*" -270- MOVE LKFC-QTD-REG-LIDOS TO GE387-QTD-REG-LIDOS. */
            _.Move(REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_QTD_REG_LIDOS, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_LIDOS);

            /*" -271- MOVE LKFC-QTD-REG-PROCS TO GE387-QTD-REG-PROCS. */
            _.Move(REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_QTD_REG_PROCS, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_PROCS);

            /*" -272- MOVE LKFC-QTD-REG-GRAVD TO GE387-QTD-REG-GRAVD. */
            _.Move(REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_QTD_REG_GRAVD, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_GRAVD);

            /*" -273- MOVE LKFC-QTD-REG-ALTER TO GE387-QTD-REG-ALTER. */
            _.Move(REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_QTD_REG_ALTER, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_ALTER);

            /*" -275- MOVE LKFC-QTD-REG-EXCLU TO GE387-QTD-REG-EXCLU. */
            _.Move(REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_QTD_REG_EXCLU, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_EXCLU);

            /*" -277- MOVE LKFC-STA-EXECUCAO TO GE387-STA-EXECUCAO. */
            _.Move(REGISTRO_LINKAFC.LKFC_PARM_INPUT.LKFC_STA_EXECUCAO, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_STA_EXECUCAO);

            /*" -278- PERFORM R0300-00-UPD-FC-EXC-ROT-ETP. */

            R0300_00_UPD_FC_EXC_ROT_ETP_SECTION();

            /*" -280- MOVE SQLCODE TO LKFC-SQL-CODE. */
            _.Move(DB.SQLCODE, REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_SQL_CODE);

            /*" -285- MOVE 00 TO LKFC-RETN-CODE. */
            _.Move(00, REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_RETN_CODE);

            /*" -285- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -301- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -304- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -306- MOVE 'R0100 - ERRO NO SELECT DA TABELA SISTEMAS' TO LKFC-MENS-ERRO */
                _.Move("R0100 - ERRO NO SELECT DA TABELA SISTEMAS", REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -307- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -307- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -301- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :WHOST-DTCURRENT FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DTCURRENT, WHOST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-FC-ROT-ETAPA-SECTION */
        private void R0200_00_SELECT_FC_ROT_ETAPA_SECTION()
        {
            /*" -343- PERFORM R0200_00_SELECT_FC_ROT_ETAPA_DB_SELECT_1 */

            R0200_00_SELECT_FC_ROT_ETAPA_DB_SELECT_1();

            /*" -346- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -347- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -349- MOVE 'R0200 - PROG/ETAPA NAO ESTA CADASTRADA OU ATIVA' TO LKFC-MENS-ERRO */
                    _.Move("R0200 - PROG/ETAPA NAO ESTA CADASTRADA OU ATIVA", REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -350- ELSE */
                }
                else
                {


                    /*" -352- MOVE 'R0200 - ERRO NO SELECT DA FC-ROTINA-ETAPA' TO LKFC-MENS-ERRO */
                    _.Move("R0200 - ERRO NO SELECT DA FC-ROTINA-ETAPA", REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -353- END-IF */
                }


                /*" -354- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -354- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-SELECT-FC-ROT-ETAPA-DB-SELECT-1 */
        public void R0200_00_SELECT_FC_ROT_ETAPA_DB_SELECT_1()
        {
            /*" -343- EXEC SQL SELECT NOM_ROTINA, SEQ_ETAPA, DTH_INI_VIGENCIA, DTH_FIM_VIGENCIA, IND_TIPO_ETAPA, NOM_PROGRAMA, STA_ETAPA, QTD_EXEC_ETAPA INTO :GE386-NOM-ROTINA, :GE386-SEQ-ETAPA, :GE386-DTH-INI-VIGENCIA, :GE386-DTH-FIM-VIGENCIA:VIND-DTH-FIM-VIGC, :GE386-IND-TIPO-ETAPA, :GE386-NOM-PROGRAMA:VIND-NOM-PROGRAMA, :GE386-STA-ETAPA, :GE386-QTD-EXEC-ETAPA FROM SEGUROS.GE_ROTINA_ETAPA WHERE NOM_ROTINA = :GE386-NOM-ROTINA AND SEQ_ETAPA = :GE386-SEQ-ETAPA AND IND_TIPO_ETAPA = :GE386-IND-TIPO-ETAPA AND NOM_PROGRAMA = :GE386-NOM-PROGRAMA AND STA_ETAPA = :GE386-STA-ETAPA AND DTH_FIM_VIGENCIA IS NULL WITH UR END-EXEC. */

            var r0200_00_SELECT_FC_ROT_ETAPA_DB_SELECT_1_Query1 = new R0200_00_SELECT_FC_ROT_ETAPA_DB_SELECT_1_Query1()
            {
                GE386_IND_TIPO_ETAPA = GE386.DCLGE_ROTINA_ETAPA.GE386_IND_TIPO_ETAPA.ToString(),
                GE386_NOM_PROGRAMA = GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_PROGRAMA.ToString(),
                GE386_NOM_ROTINA = GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_ROTINA.ToString(),
                GE386_SEQ_ETAPA = GE386.DCLGE_ROTINA_ETAPA.GE386_SEQ_ETAPA.ToString(),
                GE386_STA_ETAPA = GE386.DCLGE_ROTINA_ETAPA.GE386_STA_ETAPA.ToString(),
            };

            var executed_1 = R0200_00_SELECT_FC_ROT_ETAPA_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_FC_ROT_ETAPA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE386_NOM_ROTINA, GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_ROTINA);
                _.Move(executed_1.GE386_SEQ_ETAPA, GE386.DCLGE_ROTINA_ETAPA.GE386_SEQ_ETAPA);
                _.Move(executed_1.GE386_DTH_INI_VIGENCIA, GE386.DCLGE_ROTINA_ETAPA.GE386_DTH_INI_VIGENCIA);
                _.Move(executed_1.GE386_DTH_FIM_VIGENCIA, GE386.DCLGE_ROTINA_ETAPA.GE386_DTH_FIM_VIGENCIA);
                _.Move(executed_1.VIND_DTH_FIM_VIGC, VIND_DTH_FIM_VIGC);
                _.Move(executed_1.GE386_IND_TIPO_ETAPA, GE386.DCLGE_ROTINA_ETAPA.GE386_IND_TIPO_ETAPA);
                _.Move(executed_1.GE386_NOM_PROGRAMA, GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_PROGRAMA);
                _.Move(executed_1.VIND_NOM_PROGRAMA, VIND_NOM_PROGRAMA);
                _.Move(executed_1.GE386_STA_ETAPA, GE386.DCLGE_ROTINA_ETAPA.GE386_STA_ETAPA);
                _.Move(executed_1.GE386_QTD_EXEC_ETAPA, GE386.DCLGE_ROTINA_ETAPA.GE386_QTD_EXEC_ETAPA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-UPD-FC-EXC-ROT-ETP-SECTION */
        private void R0300_00_UPD_FC_EXC_ROT_ETP_SECTION()
        {
            /*" -382- PERFORM R0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1 */

            R0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1();

            /*" -385- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -387- MOVE 'R0300 - ERRO NO UPDATE DA FC-EXEC-ROTINA-ETAPA' TO LKFC-MENS-ERRO */
                _.Move("R0300 - ERRO NO UPDATE DA FC-EXEC-ROTINA-ETAPA", REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -388- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -388- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-UPD-FC-EXC-ROT-ETP-DB-UPDATE-1 */
        public void R0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1()
        {
            /*" -382- EXEC SQL UPDATE SEGUROS.GE_EXEC_ROTINA_ETAPA SET QTD_REG_LIDOS = :GE387-QTD-REG-LIDOS, QTD_REG_PROCS = :GE387-QTD-REG-PROCS, QTD_REG_GRAVD = :GE387-QTD-REG-GRAVD, QTD_REG_ALTER = :GE387-QTD-REG-ALTER, QTD_REG_EXCLU = :GE387-QTD-REG-EXCLU, STA_EXECUCAO = :GE387-STA-EXECUCAO, DTH_FIM_EXECUCAO = CURRENT TIMESTAMP WHERE NOM_ROTINA = :GE387-NOM-ROTINA AND SEQ_ETAPA = :GE387-SEQ-ETAPA AND DTH_INI_VIGENCIA = :GE387-DTH-INI-VIGENCIA AND NUM_EXEC_ETAPA = ( SELECT MAX (NUM_EXEC_ETAPA) FROM SEGUROS.GE_EXEC_ROTINA_ETAPA WHERE NOM_ROTINA = :GE387-NOM-ROTINA AND SEQ_ETAPA = :GE387-SEQ-ETAPA ) END-EXEC. */

            var r0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1_Update1 = new R0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1_Update1()
            {
                GE387_QTD_REG_LIDOS = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_LIDOS.ToString(),
                GE387_QTD_REG_PROCS = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_PROCS.ToString(),
                GE387_QTD_REG_GRAVD = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_GRAVD.ToString(),
                GE387_QTD_REG_ALTER = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_ALTER.ToString(),
                GE387_QTD_REG_EXCLU = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_EXCLU.ToString(),
                GE387_STA_EXECUCAO = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_STA_EXECUCAO.ToString(),
                GE387_DTH_INI_VIGENCIA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTH_INI_VIGENCIA.ToString(),
                GE387_NOM_ROTINA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NOM_ROTINA.ToString(),
                GE387_SEQ_ETAPA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_SEQ_ETAPA.ToString(),
            };

            R0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1_Update1.Execute(r0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -401- MOVE SQLCODE TO LKFC-SQL-CODE. */
            _.Move(DB.SQLCODE, REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_SQL_CODE);

            /*" -404- MOVE 99 TO LKFC-RETN-CODE. */
            _.Move(99, REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_RETN_CODE);

            /*" -404- GOBACK. */

            throw new GoBack();

        }
    }
}