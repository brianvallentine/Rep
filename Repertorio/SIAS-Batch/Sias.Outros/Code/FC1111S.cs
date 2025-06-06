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
using Sias.Outros.DB2.FC1111S;

namespace Code
{
    public class FC1111S
    {
        public bool IsCall { get; set; }

        public FC1111S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  FC                                 *      */
        /*"      *   PROGRAMA ...............  FC1111S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  EDUILTON/CELIA                     *      */
        /*"      *   PROGRAMADOR ............  EDUILTON/CELIA                     *      */
        /*"      *   DATA CODIFICACAO .......  MAIO/2012                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO: MULTIEMPRESA - ALCIONE - APENAS COMPILACAO                  */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... SUB-ROTINA PARA MONITORAMENTO DE EXECUCAO DE  *      */
        /*"      *                  PROGRAMAS BATCH.                              *      */
        /*"      *                                                                *      */
        /*"      *   PARAMETROS....                                               *      */
        /*"      *                                                                *      */
        /*"      *01     REGISTRO-LINKAGE.                                        *      */
        /*"      *                                                                *      */
        /*"      *  05   LKFC-PARM-INPUT.                                         *      */
        /*"      *    10 LKFC-COD-SISTEM   PIC  X(002).      CODIGO DO SISTEMA    *      */
        /*"      *    10 LKFC-NOM-ROTINA   PIC  X(008).      NOME DA ROTINA       *      */
        /*"      *    10 LKFC-SEQ-ETAPA    PIC  9(004).      SEQC DA ETAPA        *      */
        /*"      *    10 LKFC-NOM-PROGM    PIC  X(008).      NOME DO PROGRAMA     *      */
        /*"      *    10 LKFC-TIP-PROCS    PIC  X(002).      TIPO DE PROCESSAMENTO*      */
        /*"      *                                                                *      */
        /*"      *  05   LKFC-PARM-OUTPUT.                                        *      */
        /*"      *    10 LKFC-DATA-MOVTO   PIC  X(010).      DATA MOVIMENTO       *      */
        /*"      *    10 LKFC-DAT-INIMOV   PIC  X(010).      DATA INICIAL DO MOVTO*      */
        /*"      *    10 LKFC-DAT-TERMOV   PIC  X(010).      DATA FINAL DO MOVTO  *      */
        /*"      *    10 LKFC-DAT-CURRNT   PIC  X(010).      DATA CORRENTE        *      */
        /*"      *    10 LKFC-SQL-CODE     PIC -9(009).      RETORNO DB2 (=0 OK)  *      */
        /*"      *    10 LKFC-RETN-CODE    PIC  9(002).      CODIGO ERRO (=0 OK)  *      */
        /*"      *    10 LKFC-MENS-ERRO    PIC  X(050).      MENSAGEM DO ERRO     *      */
        /*"      *                                          (MENSAGEM =  ' ' OK)  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  .INFORMAR (INPUT)                                             *      */
        /*"      *                                                                *      */
        /*"      *   - CODIGO DO SISTEMA       - EX.: FC                          *      */
        /*"      *   - NOME DA ROTINA          - EX.: JPFCD18                     *      */
        /*"      *   - SEQC DA ETAPA DA ROTINA - EX.: 01                          *      */
        /*"      *   - NOME DO PROGRAMA        - EX.: FC2008B                     *      */
        /*"      *   - TIPO DE PROCESSAMENTO:                                     *      */
        /*"      *     P0 - PROCESSAMENTO NORMAL DA ETAPA (S? UTILIZAREMOS ESTE)  *      */
        /*"      *   . R0 - REPROCESSA A ETAPA MANTENDO A DATA FINAL DO PERIODO   *      */
        /*"      *   . R1 - REPROCESSA A ETAPA ALTERANDO A DATA FINAL DO PERIODO  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  .SAIDA DA SUB-ROTINA (OUTPUT)                                 *      */
        /*"      *                                                                *      */
        /*"      *   - DATA DE MOVIMENTO DO SISTEMA  - EX.: '2011-07-15'          *      */
        /*"      *   - DATA DE INICIO DO MOVIMENTO   - EX.: '2011-07-12'          *      */
        /*"      *   - DATA DE TERMINO DO MOVIMENTO  - EX.: '2011-07-15'          *      */
        /*"      *   - DATA CORRENTE (ACCEPT)        - EX.: '2011-07-16'          *      */
        /*"      *   - CODIGO DE RETORNO DO SQL(DB2) - EX.:  -811                 *      */
        /*"      *   - CODIGO DO ERRO DE CRITICA     - EX.:  99                   *      */
        /*"      *   - MENSAGEM DE ERRO DE CRITICA   - EX.: 'REGISTRO DUPLICADO'  *      */
        /*"      *                                                                *      */
        /*"      *  .VALIDAR NA RESPOSTA O LKFC-RETN-CODE, SE DIFERENTE DE ZERO,  *      */
        /*"      *   HOUVE ERRO NA OBTENCAO E O CAMPO LKFC-MENS-ERRO RETORNA UMA  *      */
        /*"      *   MENSAGEM COM A DESCRICAO DO ERRO ECONTRADO.                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"77      WS-NULL                   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      WS-NULL1                  PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_NULL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      WS-NULL2                  PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_NULL2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      VIND-NOM-ROTINA-PREC      PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_NOM_ROTINA_PREC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      VIND-SEQ-ETAPA-PREC       PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_SEQ_ETAPA_PREC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      VIND-NOM-PROGRAMA         PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_NOM_PROGRAMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      VIND-SEQ-ETAPA-ANT        PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_SEQ_ETAPA_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      VIND-DTH-FIM-VIGC         PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DTH_FIM_VIGC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      WHOST-DTCURRENT           PIC  X(010)    VALUE SPACES.*/
        public StringBasis WHOST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77      WHOST-DTMOVTO-I           PIC  X(010)    VALUE SPACES.*/
        public StringBasis WHOST_DTMOVTO_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77      WHOST-NOM-ROT-PREC        PIC  X(008)    VALUE SPACES.*/
        public StringBasis WHOST_NOM_ROT_PREC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77      WHOST-SEQ-ETP-PREC        PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_SEQ_ETP_PREC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      WHOST-DTH-INI-VIGC        PIC  X(026)    VALUE SPACES.*/
        public StringBasis WHOST_DTH_INI_VIGC { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"77      WHOST-IND-TIPO-ETP        PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_IND_TIPO_ETP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      WHOST-QTD-EXEC-ETP        PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTD_EXEC_ETP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77      WHOST-QTD-ETP-POST        PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTD_ETP_POST { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77      GE386-SEQ-ETAPA1          PIC S9(004)    .*/
        public IntBasis GE386_SEQ_ETAPA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77      GE386-SEQ-ETAPA2          PIC -9.999     .*/
        public IntBasis GE386_SEQ_ETAPA2 { get; set; } = new IntBasis(new PIC("9", "4", "-9.999"));
        /*"01      AREA-DE-WORK.*/
        public FC1111S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new FC1111S_AREA_DE_WORK();
        public class FC1111S_AREA_DE_WORK : VarBasis
        {
            /*" 05     WROT-ATUAL                PIC  X(001)    VALUE SPACES.*/
            public StringBasis WROT_ATUAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*" 05     WETP-ATUAL                PIC  X(001)    VALUE SPACES.*/
            public StringBasis WETP_ATUAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01      REGISTRO-LINKAGE.*/
        }
        public FC1111S_REGISTRO_LINKAGE REGISTRO_LINKAGE { get; set; } = new FC1111S_REGISTRO_LINKAGE();
        public class FC1111S_REGISTRO_LINKAGE : VarBasis
        {
            /*"  05    LKFC-PARM-INPUT.*/
            public FC1111S_LKFC_PARM_INPUT LKFC_PARM_INPUT { get; set; } = new FC1111S_LKFC_PARM_INPUT();
            public class FC1111S_LKFC_PARM_INPUT : VarBasis
            {
                /*"    10  LKFC-COD-SISTEM           PIC  X(002).*/
                public StringBasis LKFC_COD_SISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10  LKFC-NOM-ROTINA           PIC  X(008).*/
                public StringBasis LKFC_NOM_ROTINA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10  LKFC-SEQ-ETAPA            PIC  9(004).*/
                public IntBasis LKFC_SEQ_ETAPA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  LKFC-NOM-PROGM            PIC  X(008).*/
                public StringBasis LKFC_NOM_PROGM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10  LKFC-TIP-PROCS            PIC  X(002).*/
                public StringBasis LKFC_TIP_PROCS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05    LKFC-PARM-OUTPUT.*/
            }
            public FC1111S_LKFC_PARM_OUTPUT LKFC_PARM_OUTPUT { get; set; } = new FC1111S_LKFC_PARM_OUTPUT();
            public class FC1111S_LKFC_PARM_OUTPUT : VarBasis
            {
                /*"    10  LKFC-DATA-MOVTO           PIC  X(010).*/
                public StringBasis LKFC_DATA_MOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10  LKFC-DAT-INIMOV           PIC  X(010).*/
                public StringBasis LKFC_DAT_INIMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10  LKFC-DAT-TERMOV           PIC  X(010).*/
                public StringBasis LKFC_DAT_TERMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10  LKFC-DAT-CURRNT           PIC  X(010).*/
                public StringBasis LKFC_DAT_CURRNT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        public dynamic Execute(FC1111S_REGISTRO_LINKAGE FC1111S_REGISTRO_LINKAGE_P) //PROCEDURE DIVISION USING 
        /*REGISTRO_LINKAGE*/
        {
            try
            {
                this.REGISTRO_LINKAGE = FC1111S_REGISTRO_LINKAGE_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-ROT-PRINCIPAL-SECTION */

                R0000_00_ROT_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { REGISTRO_LINKAGE };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-ROT-PRINCIPAL-SECTION */
        private void R0000_00_ROT_PRINCIPAL_SECTION()
        {
            /*" -197- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -200- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -203- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -210- INITIALIZE LKFC-PARM-OUTPUT. */
            _.Initialize(
                REGISTRO_LINKAGE.LKFC_PARM_OUTPUT
            );

            /*" -212- IF LKFC-COD-SISTEM = SPACES OR LKFC-COD-SISTEM IS NUMERIC */

            if (REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_COD_SISTEM.IsEmpty() || REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_COD_SISTEM.IsNumeric())
            {

                /*" -214- MOVE 'FC1111S - CODIGO DO SISTEMA INVALIDO' TO LKFC-MENS-ERRO */
                _.Move("FC1111S - CODIGO DO SISTEMA INVALIDO", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -215- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -217- END-IF. */
            }


            /*" -219- IF LKFC-NOM-ROTINA = SPACES OR LKFC-NOM-ROTINA IS NUMERIC */

            if (REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_NOM_ROTINA.IsEmpty() || REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_NOM_ROTINA.IsNumeric())
            {

                /*" -221- MOVE 'FC1111S - NOME DA ROTINA ESTA INVALIDO' TO LKFC-MENS-ERRO */
                _.Move("FC1111S - NOME DA ROTINA ESTA INVALIDO", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -222- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -224- END-IF. */
            }


            /*" -225- IF LKFC-SEQ-ETAPA NOT NUMERIC */

            if (!REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_SEQ_ETAPA.IsNumeric())
            {

                /*" -227- MOVE 'FC1111S - SEQUENCIA DA ETAPA NA ROTINA INVALIDA' TO LKFC-MENS-ERRO */
                _.Move("FC1111S - SEQUENCIA DA ETAPA NA ROTINA INVALIDA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -228- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -230- END-IF. */
            }


            /*" -231- IF LKFC-NOM-PROGM = SPACES */

            if (REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_NOM_PROGM.IsEmpty())
            {

                /*" -233- MOVE 'FC1111S - NOME DO PROGRAMA ESTA INVALIDO' TO LKFC-MENS-ERRO */
                _.Move("FC1111S - NOME DO PROGRAMA ESTA INVALIDO", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -234- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -236- END-IF. */
            }


            /*" -237- IF LKFC-TIP-PROCS = SPACES */

            if (REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_TIP_PROCS.IsEmpty())
            {

                /*" -239- MOVE 'FC1111S - TIPO DE PROCESSAMENTO INVALIDO' TO LKFC-MENS-ERRO */
                _.Move("FC1111S - TIPO DE PROCESSAMENTO INVALIDO", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -240- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -241- ELSE */
            }
            else
            {


                /*" -243- IF LKFC-TIP-PROCS = 'P0' OR 'R0' OR 'R1' NEXT SENTENCE */

                if (REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_TIP_PROCS.In("P0", "R0", "R1"))
                {

                    /*" -244- ELSE */
                }
                else
                {


                    /*" -246- MOVE 'FC1111S - TIPO DE PROCESSAMENTO NAO PREVISTO' TO LKFC-MENS-ERRO */
                    _.Move("FC1111S - TIPO DE PROCESSAMENTO NAO PREVISTO", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -247- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -248- END-IF */
                }


                /*" -252- END-IF. */
            }


            /*" -254- INITIALIZE DCLSISTEMAS. */
            _.Initialize(
                SISTEMAS.DCLSISTEMAS
            );

            /*" -256- MOVE LKFC-COD-SISTEM TO SISTEMAS-IDE-SISTEMA. */
            _.Move(REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_COD_SISTEM, SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -260- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -262- MOVE 'S' TO WROT-ATUAL. */
            _.Move("S", AREA_DE_WORK.WROT_ATUAL);

            /*" -264- INITIALIZE DCLGE-ROTINA-BATCH. */
            _.Initialize(
                GE385.DCLGE_ROTINA_BATCH
            );

            /*" -266- MOVE LKFC-NOM-ROTINA TO GE385-NOM-ROTINA. */
            _.Move(REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_NOM_ROTINA, GE385.DCLGE_ROTINA_BATCH.GE385_NOM_ROTINA);

            /*" -271- PERFORM R0200-00-CRITICA-ROTN-BATCH. */

            R0200_00_CRITICA_ROTN_BATCH_SECTION();

            /*" -272- MOVE SPACES TO WHOST-NOM-ROT-PREC */
            _.Move("", WHOST_NOM_ROT_PREC);

            /*" -277- MOVE ZEROS TO WHOST-SEQ-ETP-PREC */
            _.Move(0, WHOST_SEQ_ETP_PREC);

            /*" -279- INITIALIZE DCLGE-ROTINA-ETAPA. */
            _.Initialize(
                GE386.DCLGE_ROTINA_ETAPA
            );

            /*" -281- MOVE 'S' TO WETP-ATUAL. */
            _.Move("S", AREA_DE_WORK.WETP_ATUAL);

            /*" -283- MOVE SPACES TO WHOST-DTH-INI-VIGC. */
            _.Move("", WHOST_DTH_INI_VIGC);

            /*" -286- MOVE ZEROS TO WHOST-IND-TIPO-ETP WHOST-QTD-EXEC-ETP. */
            _.Move(0, WHOST_IND_TIPO_ETP, WHOST_QTD_EXEC_ETP);

            /*" -287- MOVE LKFC-NOM-ROTINA TO GE386-NOM-ROTINA. */
            _.Move(REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_NOM_ROTINA, GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_ROTINA);

            /*" -289- MOVE LKFC-SEQ-ETAPA TO GE386-SEQ-ETAPA. */
            _.Move(REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_SEQ_ETAPA, GE386.DCLGE_ROTINA_ETAPA.GE386_SEQ_ETAPA);

            /*" -294- PERFORM R0400-00-CRITICA-ROTN-ETAPA. */

            R0400_00_CRITICA_ROTN_ETAPA_SECTION();

            /*" -295- IF GE386-NOM-PROGRAMA = LKFC-NOM-PROGM */

            if (GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_PROGRAMA == REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_NOM_PROGM)
            {

                /*" -296- IF GE386-IND-TIPO-ETAPA = ZEROS */

                if (GE386.DCLGE_ROTINA_ETAPA.GE386_IND_TIPO_ETAPA == 00)
                {

                    /*" -297- MOVE GE386-DTH-INI-VIGENCIA TO WHOST-DTH-INI-VIGC */
                    _.Move(GE386.DCLGE_ROTINA_ETAPA.GE386_DTH_INI_VIGENCIA, WHOST_DTH_INI_VIGC);

                    /*" -298- MOVE GE386-IND-TIPO-ETAPA TO WHOST-IND-TIPO-ETP */
                    _.Move(GE386.DCLGE_ROTINA_ETAPA.GE386_IND_TIPO_ETAPA, WHOST_IND_TIPO_ETP);

                    /*" -299- MOVE GE386-QTD-EXEC-ETAPA TO WHOST-QTD-EXEC-ETP */
                    _.Move(GE386.DCLGE_ROTINA_ETAPA.GE386_QTD_EXEC_ETAPA, WHOST_QTD_EXEC_ETP);

                    /*" -300- ELSE */
                }
                else
                {


                    /*" -302- MOVE 'R0000 - TIPO ETAPA INVALIDA PARA PROGM BATCH' TO LKFC-MENS-ERRO */
                    _.Move("R0000 - TIPO ETAPA INVALIDA PARA PROGM BATCH", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -303- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -304- END-IF */
                }


                /*" -305- ELSE */
            }
            else
            {


                /*" -307- MOVE 'R0000 - ETAPA E/OU PROGRAMA ATUAL ESTAO INVALIDOS' TO LKFC-MENS-ERRO */
                _.Move("R0000 - ETAPA E/OU PROGRAMA ATUAL ESTAO INVALIDOS", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -308- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -314- END-IF. */
            }


            /*" -315- MOVE 'S' TO WROT-ATUAL. */
            _.Move("S", AREA_DE_WORK.WROT_ATUAL);

            /*" -317- MOVE 'S' TO WETP-ATUAL. */
            _.Move("S", AREA_DE_WORK.WETP_ATUAL);

            /*" -319- MOVE ZEROS TO WHOST-QTD-ETP-POST. */
            _.Move(0, WHOST_QTD_ETP_POST);

            /*" -321- INITIALIZE DCLGE-EXEC-ROTINA-ETAPA. */
            _.Initialize(
                GE387.DCLGE_EXEC_ROTINA_ETAPA
            );

            /*" -322- MOVE LKFC-NOM-ROTINA TO GE386-NOM-ROTINA. */
            _.Move(REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_NOM_ROTINA, GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_ROTINA);

            /*" -323- MOVE LKFC-SEQ-ETAPA TO GE386-SEQ-ETAPA. */
            _.Move(REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_SEQ_ETAPA, GE386.DCLGE_ROTINA_ETAPA.GE386_SEQ_ETAPA);

            /*" -324- MOVE WHOST-DTH-INI-VIGC TO GE386-DTH-INI-VIGENCIA */
            _.Move(WHOST_DTH_INI_VIGC, GE386.DCLGE_ROTINA_ETAPA.GE386_DTH_INI_VIGENCIA);

            /*" -326- MOVE WHOST-QTD-EXEC-ETP TO GE386-QTD-EXEC-ETAPA. */
            _.Move(WHOST_QTD_EXEC_ETP, GE386.DCLGE_ROTINA_ETAPA.GE386_QTD_EXEC_ETAPA);

            /*" -327- IF WHOST-IND-TIPO-ETP = ZEROS */

            if (WHOST_IND_TIPO_ETP == 00)
            {

                /*" -328- PERFORM R0600-00-CRITICA-EXEC-ROT-ETP */

                R0600_00_CRITICA_EXEC_ROT_ETP_SECTION();

                /*" -329- IF WHOST-QTD-ETP-POST = ZEROS */

                if (WHOST_QTD_ETP_POST == 00)
                {

                    /*" -330- IF LKFC-TIP-PROCS = 'P0' */

                    if (REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_TIP_PROCS == "P0")
                    {

                        /*" -331- PERFORM R1000-00-MONTA-PARM-LKFC-P0 */

                        R1000_00_MONTA_PARM_LKFC_P0_SECTION();

                        /*" -332- END-IF */
                    }


                    /*" -333- END-IF */
                }


                /*" -334- ELSE */
            }
            else
            {


                /*" -336- MOVE 'R0000 - TIPO ETAPA INVALIDA PARA PROGM BATCH ATUAL' TO LKFC-MENS-ERRO */
                _.Move("R0000 - TIPO ETAPA INVALIDA PARA PROGM BATCH ATUAL", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -337- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -342- END-IF. */
            }


            /*" -342- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -357- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -360- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -362- MOVE 'R0100 - ERRO NO SELECT DA TABELA SISTEMAS' TO LKFC-MENS-ERRO */
                _.Move("R0100 - ERRO NO SELECT DA TABELA SISTEMAS", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -363- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -363- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -357- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :WHOST-DTCURRENT FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA END-EXEC. */

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
        /*" R0200-00-CRITICA-ROTN-BATCH-SECTION */
        private void R0200_00_CRITICA_ROTN_BATCH_SECTION()
        {
            /*" -376- PERFORM R0300-00-SELECT-GE-ROT-BATCH. */

            R0300_00_SELECT_GE_ROT_BATCH_SECTION();

            /*" -377- IF GE385-STA-ROTINA = '0' */

            if (GE385.DCLGE_ROTINA_BATCH.GE385_STA_ROTINA == "0")
            {

                /*" -378- CONTINUE */

                /*" -379- ELSE */
            }
            else
            {


                /*" -380- IF GE385-STA-ROTINA = ' ' */

                if (GE385.DCLGE_ROTINA_BATCH.GE385_STA_ROTINA == " ")
                {

                    /*" -382- MOVE 'R0200 - ROTINA ATUAL ESTA INATIVA' TO LKFC-MENS-ERRO */
                    _.Move("R0200 - ROTINA ATUAL ESTA INATIVA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -383- ELSE */
                }
                else
                {


                    /*" -384- IF GE385-STA-ROTINA = '1' */

                    if (GE385.DCLGE_ROTINA_BATCH.GE385_STA_ROTINA == "1")
                    {

                        /*" -386- MOVE 'R0200 - ROTINA ATUAL ESTA DESATIVADA' TO LKFC-MENS-ERRO */
                        _.Move("R0200 - ROTINA ATUAL ESTA DESATIVADA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                        /*" -387- ELSE */
                    }
                    else
                    {


                        /*" -389- MOVE 'R0200 - SIT DA ROTN ATUAL NAO PREVISTA' TO LKFC-MENS-ERRO */
                        _.Move("R0200 - SIT DA ROTN ATUAL NAO PREVISTA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                        /*" -390- END-IF */
                    }


                    /*" -391- END-IF */
                }


                /*" -392- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -392- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-SELECT-GE-ROT-BATCH-SECTION */
        private void R0300_00_SELECT_GE_ROT_BATCH_SECTION()
        {
            /*" -410- PERFORM R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1 */

            R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1();

            /*" -413- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -414- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -416- MOVE 'R0300 - ROTINA ATUAL NAO ESTA CADASTRADA' TO LKFC-MENS-ERRO */
                    _.Move("R0300 - ROTINA ATUAL NAO ESTA CADASTRADA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -417- ELSE */
                }
                else
                {


                    /*" -419- MOVE 'R0300 - ERRO SELECT GE-ROTINA-BATCH ' TO LKFC-MENS-ERRO */
                    _.Move("R0300 - ERRO SELECT GE-ROTINA-BATCH ", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -420- END-IF */
                }


                /*" -421- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -421- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-SELECT-GE-ROT-BATCH-DB-SELECT-1 */
        public void R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1()
        {
            /*" -410- EXEC SQL SELECT NOM_ROTINA, STA_ROTINA INTO :GE385-NOM-ROTINA, :GE385-STA-ROTINA FROM SEGUROS.GE_ROTINA_BATCH WHERE NOM_ROTINA = :GE385-NOM-ROTINA END-EXEC. */

            var r0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1 = new R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1()
            {
                GE385_NOM_ROTINA = GE385.DCLGE_ROTINA_BATCH.GE385_NOM_ROTINA.ToString(),
            };

            var executed_1 = R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1.Execute(r0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE385_NOM_ROTINA, GE385.DCLGE_ROTINA_BATCH.GE385_NOM_ROTINA);
                _.Move(executed_1.GE385_STA_ROTINA, GE385.DCLGE_ROTINA_BATCH.GE385_STA_ROTINA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-CRITICA-ROTN-ETAPA-SECTION */
        private void R0400_00_CRITICA_ROTN_ETAPA_SECTION()
        {
            /*" -434- PERFORM R0500-00-SELECT-GE-ROT-ETAPA. */

            R0500_00_SELECT_GE_ROT_ETAPA_SECTION();

            /*" -436- IF GE386-STA-ETAPA = '0' NEXT SENTENCE */

            if (GE386.DCLGE_ROTINA_ETAPA.GE386_STA_ETAPA == "0")
            {

                /*" -437- ELSE */
            }
            else
            {


                /*" -438- IF GE386-STA-ETAPA = ' ' */

                if (GE386.DCLGE_ROTINA_ETAPA.GE386_STA_ETAPA == " ")
                {

                    /*" -440- MOVE 'R0400 - ETAPA ATUAL ESTA INATIVA' TO LKFC-MENS-ERRO */
                    _.Move("R0400 - ETAPA ATUAL ESTA INATIVA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -441- ELSE */
                }
                else
                {


                    /*" -442- IF GE386-STA-ETAPA = '1' */

                    if (GE386.DCLGE_ROTINA_ETAPA.GE386_STA_ETAPA == "1")
                    {

                        /*" -444- MOVE 'R0400 - ETAPA ATUAL ESTA DESATIVADA' TO LKFC-MENS-ERRO */
                        _.Move("R0400 - ETAPA ATUAL ESTA DESATIVADA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                        /*" -445- ELSE */
                    }
                    else
                    {


                        /*" -446- IF WETP-ATUAL = 'S' */

                        if (AREA_DE_WORK.WETP_ATUAL == "S")
                        {

                            /*" -448- MOVE 'R0400 - SIT DA ETP ATUAL NAO PREVISTA' TO LKFC-MENS-ERRO */
                            _.Move("R0400 - SIT DA ETP ATUAL NAO PREVISTA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                            /*" -449- END-IF */
                        }


                        /*" -450- END-IF */
                    }


                    /*" -451- END-IF */
                }


                /*" -452- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -452- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-SELECT-GE-ROT-ETAPA-SECTION */
        private void R0500_00_SELECT_GE_ROT_ETAPA_SECTION()
        {
            /*" -484- PERFORM R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1 */

            R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1();

            /*" -487- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -488- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -490- MOVE 'R0500 - ETAPA ATUAL NAO ESTA CADASTRADA' TO LKFC-MENS-ERRO */
                    _.Move("R0500 - ETAPA ATUAL NAO ESTA CADASTRADA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -491- ELSE */
                }
                else
                {


                    /*" -493- MOVE 'R0500 - ERRO SELECT GE-ROTINA-ETAPA : ATUAL' TO LKFC-MENS-ERRO */
                    _.Move("R0500 - ERRO SELECT GE-ROTINA-ETAPA : ATUAL", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -494- END-IF */
                }


                /*" -495- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -496- ELSE */
            }
            else
            {


                /*" -497- IF VIND-NOM-PROGRAMA < ZEROS */

                if (VIND_NOM_PROGRAMA < 00)
                {

                    /*" -498- IF VIND-DTH-FIM-VIGC < ZEROS */

                    if (VIND_DTH_FIM_VIGC < 00)
                    {

                        /*" -499- MOVE SPACES TO GE386-NOM-PROGRAMA */
                        _.Move("", GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_PROGRAMA);

                        /*" -500- MOVE SPACES TO GE386-DTH-FIM-VIGENCIA */
                        _.Move("", GE386.DCLGE_ROTINA_ETAPA.GE386_DTH_FIM_VIGENCIA);

                        /*" -501- ELSE */
                    }
                    else
                    {


                        /*" -502- MOVE SPACES TO GE386-NOM-PROGRAMA */
                        _.Move("", GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_PROGRAMA);

                        /*" -503- END-IF */
                    }


                    /*" -504- ELSE */
                }
                else
                {


                    /*" -505- IF VIND-DTH-FIM-VIGC < ZEROS */

                    if (VIND_DTH_FIM_VIGC < 00)
                    {

                        /*" -506- MOVE SPACES TO GE386-DTH-FIM-VIGENCIA */
                        _.Move("", GE386.DCLGE_ROTINA_ETAPA.GE386_DTH_FIM_VIGENCIA);

                        /*" -507- END-IF */
                    }


                    /*" -508- END-IF */
                }


                /*" -508- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-00-SELECT-GE-ROT-ETAPA-DB-SELECT-1 */
        public void R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1()
        {
            /*" -484- EXEC SQL SELECT NOM_ROTINA, SEQ_ETAPA, DTH_INI_VIGENCIA, IND_TIPO_ETAPA, NOM_PROGRAMA, STA_ETAPA, QTD_EXEC_ETAPA INTO :GE386-NOM-ROTINA, :GE386-SEQ-ETAPA, :GE386-DTH-INI-VIGENCIA, :GE386-IND-TIPO-ETAPA, :GE386-NOM-PROGRAMA:VIND-NOM-PROGRAMA, :GE386-STA-ETAPA, :GE386-QTD-EXEC-ETAPA FROM SEGUROS.GE_ROTINA_ETAPA WHERE NOM_ROTINA = :GE386-NOM-ROTINA AND SEQ_ETAPA = :GE386-SEQ-ETAPA AND DTH_FIM_VIGENCIA IS NULL END-EXEC. */

            var r0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1 = new R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1()
            {
                GE386_NOM_ROTINA = GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_ROTINA.ToString(),
                GE386_SEQ_ETAPA = GE386.DCLGE_ROTINA_ETAPA.GE386_SEQ_ETAPA.ToString(),
            };

            var executed_1 = R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1.Execute(r0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE386_NOM_ROTINA, GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_ROTINA);
                _.Move(executed_1.GE386_SEQ_ETAPA, GE386.DCLGE_ROTINA_ETAPA.GE386_SEQ_ETAPA);
                _.Move(executed_1.GE386_DTH_INI_VIGENCIA, GE386.DCLGE_ROTINA_ETAPA.GE386_DTH_INI_VIGENCIA);
                _.Move(executed_1.GE386_IND_TIPO_ETAPA, GE386.DCLGE_ROTINA_ETAPA.GE386_IND_TIPO_ETAPA);
                _.Move(executed_1.GE386_NOM_PROGRAMA, GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_PROGRAMA);
                _.Move(executed_1.VIND_NOM_PROGRAMA, VIND_NOM_PROGRAMA);
                _.Move(executed_1.GE386_STA_ETAPA, GE386.DCLGE_ROTINA_ETAPA.GE386_STA_ETAPA);
                _.Move(executed_1.GE386_QTD_EXEC_ETAPA, GE386.DCLGE_ROTINA_ETAPA.GE386_QTD_EXEC_ETAPA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-CRITICA-EXEC-ROT-ETP-SECTION */
        private void R0600_00_CRITICA_EXEC_ROT_ETP_SECTION()
        {
            /*" -521- INITIALIZE DCLGE-EXEC-ROTINA-ETAPA. */
            _.Initialize(
                GE387.DCLGE_EXEC_ROTINA_ETAPA
            );

            /*" -522- MOVE GE386-NOM-ROTINA TO GE387-NOM-ROTINA. */
            _.Move(GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_ROTINA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NOM_ROTINA);

            /*" -523- MOVE GE386-SEQ-ETAPA TO GE387-SEQ-ETAPA. */
            _.Move(GE386.DCLGE_ROTINA_ETAPA.GE386_SEQ_ETAPA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_SEQ_ETAPA);

            /*" -524- MOVE GE386-DTH-INI-VIGENCIA TO GE387-DTH-INI-VIGENCIA. */
            _.Move(GE386.DCLGE_ROTINA_ETAPA.GE386_DTH_INI_VIGENCIA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTH_INI_VIGENCIA);

            /*" -526- MOVE GE386-QTD-EXEC-ETAPA TO GE387-NUM-EXEC-ETAPA. */
            _.Move(GE386.DCLGE_ROTINA_ETAPA.GE386_QTD_EXEC_ETAPA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NUM_EXEC_ETAPA);

            /*" -528- PERFORM R0700-00-SELECT-GE-EXC-ROT-ETP. */

            R0700_00_SELECT_GE_EXC_ROT_ETP_SECTION();

            /*" -529- IF GE387-STA-EXECUCAO = '1' */

            if (GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_STA_EXECUCAO == "1")
            {

                /*" -531- IF LKFC-TIP-PROCS = 'P0' NEXT SENTENCE */

                if (REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_TIP_PROCS == "P0")
                {

                    /*" -532- ELSE */
                }
                else
                {


                    /*" -534- MOVE 'R0600 - TIPO DE PROCESS INVALIDO PARA ETAPA/PROG' TO LKFC-MENS-ERRO */
                    _.Move("R0600 - TIPO DE PROCESS INVALIDO PARA ETAPA/PROG", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -535- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -536- END-IF */
                }


                /*" -537- ELSE */
            }
            else
            {


                /*" -538- IF GE387-STA-EXECUCAO = '0' */

                if (GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_STA_EXECUCAO == "0")
                {

                    /*" -539- IF WROT-ATUAL = 'S' */

                    if (AREA_DE_WORK.WROT_ATUAL == "S")
                    {

                        /*" -540- IF WETP-ATUAL = 'S' */

                        if (AREA_DE_WORK.WETP_ATUAL == "S")
                        {

                            /*" -542- MOVE 'R0600 - ULTIMO PROCS DA ETP ATUAL PENDT EXEC' TO LKFC-MENS-ERRO */
                            _.Move("R0600 - ULTIMO PROCS DA ETP ATUAL PENDT EXEC", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                            /*" -543- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -544- ELSE */
                        }
                        else
                        {


                            /*" -546- MOVE 'R0600 - ETP/PROGM ANTERIOR PENDT DE EXECUCAO' TO LKFC-MENS-ERRO */
                            _.Move("R0600 - ETP/PROGM ANTERIOR PENDT DE EXECUCAO", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                            /*" -547- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -548- END-IF */
                        }


                        /*" -549- ELSE */
                    }
                    else
                    {


                        /*" -551- MOVE 'R0600 - ROTINA/ETAPA PRECED PENDENTE DE EXECUCAO' TO LKFC-MENS-ERRO */
                        _.Move("R0600 - ROTINA/ETAPA PRECED PENDENTE DE EXECUCAO", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                        /*" -552- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -553- END-IF */
                    }


                    /*" -554- ELSE */
                }
                else
                {


                    /*" -555- IF GE387-STA-EXECUCAO = '2' */

                    if (GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_STA_EXECUCAO == "2")
                    {

                        /*" -556- IF LKFC-TIP-PROCS = 'R0' OR 'R1' */

                        if (REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_TIP_PROCS.In("R0", "R1"))
                        {

                            /*" -557- IF WROT-ATUAL = 'S' */

                            if (AREA_DE_WORK.WROT_ATUAL == "S")
                            {

                                /*" -559- IF WETP-ATUAL = 'S' NEXT SENTENCE */

                                if (AREA_DE_WORK.WETP_ATUAL == "S")
                                {

                                    /*" -560- ELSE */
                                }
                                else
                                {


                                    /*" -562- MOVE 'R0600 - ETAPA/PROGM ANTERIOR COM ERRO EXEC' TO LKFC-MENS-ERRO */
                                    _.Move("R0600 - ETAPA/PROGM ANTERIOR COM ERRO EXEC", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                                    /*" -563- GO TO R9999-00-ROT-ERRO */

                                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                                    return;

                                    /*" -564- END-IF */
                                }


                                /*" -565- ELSE */
                            }
                            else
                            {


                                /*" -567- MOVE 'R0600 - ROTINA/ETAPA PRECED COM ERRO DE EXEC' TO LKFC-MENS-ERRO */
                                _.Move("R0600 - ROTINA/ETAPA PRECED COM ERRO DE EXEC", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                                /*" -568- GO TO R9999-00-ROT-ERRO */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;

                                /*" -569- END-IF */
                            }


                            /*" -570- ELSE */
                        }
                        else
                        {


                            /*" -571- IF WROT-ATUAL = 'S' */

                            if (AREA_DE_WORK.WROT_ATUAL == "S")
                            {

                                /*" -572- IF WETP-ATUAL = 'S' */

                                if (AREA_DE_WORK.WETP_ATUAL == "S")
                                {

                                    /*" -574- MOVE 'R0600 - TP DE PROCS INVALIDO PARA ETAPA ATUAL' TO LKFC-MENS-ERRO */
                                    _.Move("R0600 - TP DE PROCS INVALIDO PARA ETAPA ATUAL", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                                    /*" -575- GO TO R9999-00-ROT-ERRO */

                                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                                    return;

                                    /*" -576- ELSE */
                                }
                                else
                                {


                                    /*" -578- MOVE 'R0600 - ETAPA/PROGM ANTERIOR COM ERRO DE EXEC' TO LKFC-MENS-ERRO */
                                    _.Move("R0600 - ETAPA/PROGM ANTERIOR COM ERRO DE EXEC", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                                    /*" -579- GO TO R9999-00-ROT-ERRO */

                                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                                    return;

                                    /*" -580- END-IF */
                                }


                                /*" -581- ELSE */
                            }
                            else
                            {


                                /*" -583- MOVE 'R0600 - ROTINA/ETAPA PRECEDENTE COM ERRO DE EXEC' TO LKFC-MENS-ERRO */
                                _.Move("R0600 - ROTINA/ETAPA PRECEDENTE COM ERRO DE EXEC", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                                /*" -584- GO TO R9999-00-ROT-ERRO */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;

                                /*" -585- END-IF */
                            }


                            /*" -586- ELSE */
                        }

                    }
                    else
                    {


                        /*" -588- MOVE 'R0600 - SITUACAO DE EXECUCAO NAO PREVISTA' TO LKFC-MENS-ERRO */
                        _.Move("R0600 - SITUACAO DE EXECUCAO NAO PREVISTA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                        /*" -589- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -590- END-IF */
                    }


                    /*" -591- END-IF */
                }


                /*" -591- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-SELECT-GE-EXC-ROT-ETP-SECTION */
        private void R0700_00_SELECT_GE_EXC_ROT_ETP_SECTION()
        {
            /*" -633- PERFORM R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1 */

            R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1();

            /*" -636- IF WS-NULL LESS ZEROS */

            if (WS_NULL < 00)
            {

                /*" -637- DISPLAY 'INIVIG ' GE387-DTH-INI-VIGENCIA. */
                _.Display($"INIVIG {GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTH_INI_VIGENCIA}");
            }


            /*" -638- IF WS-NULL1 LESS ZEROS */

            if (WS_NULL1 < 00)
            {

                /*" -639- DISPLAY 'INIMOV ' GE387-DTA-INI-MOVIMENTO. */
                _.Display($"INIMOV {GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_INI_MOVIMENTO}");
            }


            /*" -640- IF WS-NULL2 LESS ZEROS */

            if (WS_NULL2 < 00)
            {

                /*" -641- DISPLAY 'FIMMOV ' GE387-DTA-FIM-MOVIMENTO. */
                _.Display($"FIMMOV {GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_FIM_MOVIMENTO}");
            }


            /*" -642- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -643- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -644- MOVE LKFC-NOM-ROTINA TO GE387-NOM-ROTINA */
                    _.Move(REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_NOM_ROTINA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NOM_ROTINA);

                    /*" -645- MOVE LKFC-SEQ-ETAPA TO GE387-SEQ-ETAPA */
                    _.Move(REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_SEQ_ETAPA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_SEQ_ETAPA);

                    /*" -646- MOVE WHOST-DTH-INI-VIGC TO GE387-DTH-INI-VIGENCIA */
                    _.Move(WHOST_DTH_INI_VIGC, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTH_INI_VIGENCIA);

                    /*" -648- MOVE ZEROS TO GE387-NUM-EXEC-ETAPA */
                    _.Move(0, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NUM_EXEC_ETAPA);

                    /*" -649- MOVE LKFC-DAT-INIMOV TO GE387-DTA-INI-MOVIMENTO */
                    _.Move(REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_DAT_INIMOV, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_INI_MOVIMENTO);

                    /*" -651- MOVE LKFC-DAT-TERMOV TO GE387-DTA-FIM-MOVIMENTO */
                    _.Move(REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_DAT_TERMOV, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_FIM_MOVIMENTO);

                    /*" -657- MOVE ZEROS TO GE387-QTD-REG-LIDOS GE387-QTD-REG-PROCS GE387-QTD-REG-GRAVD GE387-QTD-REG-ALTER GE387-QTD-REG-EXCLU */
                    _.Move(0, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_LIDOS, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_PROCS, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_GRAVD, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_ALTER, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_EXCLU);

                    /*" -659- MOVE '1' TO GE387-STA-EXECUCAO */
                    _.Move("1", GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_STA_EXECUCAO);

                    /*" -660- ELSE */
                }
                else
                {


                    /*" -662- MOVE 'R0700 - ERRO NO SELECT GE-EXEC-ROTINA-ETP' TO LKFC-MENS-ERRO */
                    _.Move("R0700 - ERRO NO SELECT GE-EXEC-ROTINA-ETP", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -663- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -664- END-IF */
                }


                /*" -665- ELSE */
            }
            else
            {


                /*" -666- MOVE LKFC-DAT-INIMOV TO GE387-DTA-INI-MOVIMENTO */
                _.Move(REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_DAT_INIMOV, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_INI_MOVIMENTO);

                /*" -668- MOVE LKFC-DAT-TERMOV TO GE387-DTA-FIM-MOVIMENTO */
                _.Move(REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_DAT_TERMOV, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_FIM_MOVIMENTO);

                /*" -674- MOVE ZEROS TO GE387-QTD-REG-LIDOS GE387-QTD-REG-PROCS GE387-QTD-REG-GRAVD GE387-QTD-REG-ALTER GE387-QTD-REG-EXCLU */
                _.Move(0, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_LIDOS, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_PROCS, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_GRAVD, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_ALTER, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_EXCLU);

                /*" -675- MOVE '1' TO GE387-STA-EXECUCAO */
                _.Move("1", GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_STA_EXECUCAO);

                /*" -676- END-IF */
            }


            /*" -677- PERFORM R1200-00-INS-GE-EXC-ROT-ETP THRU R1200-99-SAIDA. */

            R1200_00_INS_GE_EXC_ROT_ETP_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/


        }

        [StopWatch]
        /*" R0700-00-SELECT-GE-EXC-ROT-ETP-DB-SELECT-1 */
        public void R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1()
        {
            /*" -633- EXEC SQL SELECT NOM_ROTINA, SEQ_ETAPA, DTH_INI_VIGENCIA, NUM_EXEC_ETAPA, DTA_INI_MOVIMENTO, DTA_FIM_MOVIMENTO, STA_EXECUCAO INTO :GE387-NOM-ROTINA, :GE387-SEQ-ETAPA, :GE387-DTH-INI-VIGENCIA:WS-NULL, :GE387-NUM-EXEC-ETAPA, :GE387-DTA-INI-MOVIMENTO:WS-NULL1, :GE387-DTA-FIM-MOVIMENTO:WS-NULL2, :GE387-STA-EXECUCAO FROM SEGUROS.GE_EXEC_ROTINA_ETAPA WHERE NOM_ROTINA = :GE387-NOM-ROTINA AND SEQ_ETAPA = :GE387-SEQ-ETAPA AND DTH_INI_VIGENCIA = :GE387-DTH-INI-VIGENCIA AND NUM_EXEC_ETAPA = (SELECT MAX (NUM_EXEC_ETAPA) FROM SEGUROS.GE_EXEC_ROTINA_ETAPA WHERE NOM_ROTINA = :GE387-NOM-ROTINA AND SEQ_ETAPA = :GE387-SEQ-ETAPA AND DTH_INI_VIGENCIA = :GE387-DTH-INI-VIGENCIA) WITH UR END-EXEC. */

            var r0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1 = new R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1()
            {
                GE387_DTH_INI_VIGENCIA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTH_INI_VIGENCIA.ToString(),
                GE387_NOM_ROTINA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NOM_ROTINA.ToString(),
                GE387_SEQ_ETAPA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_SEQ_ETAPA.ToString(),
            };

            var executed_1 = R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1.Execute(r0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE387_NOM_ROTINA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NOM_ROTINA);
                _.Move(executed_1.GE387_SEQ_ETAPA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_SEQ_ETAPA);
                _.Move(executed_1.GE387_DTH_INI_VIGENCIA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTH_INI_VIGENCIA);
                _.Move(executed_1.WS_NULL, WS_NULL);
                _.Move(executed_1.GE387_NUM_EXEC_ETAPA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NUM_EXEC_ETAPA);
                _.Move(executed_1.GE387_DTA_INI_MOVIMENTO, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_INI_MOVIMENTO);
                _.Move(executed_1.WS_NULL1, WS_NULL1);
                _.Move(executed_1.GE387_DTA_FIM_MOVIMENTO, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_FIM_MOVIMENTO);
                _.Move(executed_1.WS_NULL2, WS_NULL2);
                _.Move(executed_1.GE387_STA_EXECUCAO, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_STA_EXECUCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-VERIFICA-PRECEDENCIA-SECTION */
        private void R0800_00_VERIFICA_PRECEDENCIA_SECTION()
        {
            /*" -690- MOVE 'N' TO WROT-ATUAL. */
            _.Move("N", AREA_DE_WORK.WROT_ATUAL);

            /*" -692- INITIALIZE DCLGE-ROTINA-BATCH. */
            _.Initialize(
                GE385.DCLGE_ROTINA_BATCH
            );

            /*" -694- MOVE WHOST-NOM-ROT-PREC TO GE385-NOM-ROTINA. */
            _.Move(WHOST_NOM_ROT_PREC, GE385.DCLGE_ROTINA_BATCH.GE385_NOM_ROTINA);

            /*" -696- PERFORM R0200-00-CRITICA-ROTN-BATCH. */

            R0200_00_CRITICA_ROTN_BATCH_SECTION();

            /*" -698- INITIALIZE DCLGE-ROTINA-ETAPA. */
            _.Initialize(
                GE386.DCLGE_ROTINA_ETAPA
            );

            /*" -700- MOVE 'N' TO WETP-ATUAL. */
            _.Move("N", AREA_DE_WORK.WETP_ATUAL);

            /*" -701- MOVE WHOST-NOM-ROT-PREC TO GE386-NOM-ROTINA. */
            _.Move(WHOST_NOM_ROT_PREC, GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_ROTINA);

            /*" -703- MOVE WHOST-SEQ-ETP-PREC TO GE386-SEQ-ETAPA. */
            _.Move(WHOST_SEQ_ETP_PREC, GE386.DCLGE_ROTINA_ETAPA.GE386_SEQ_ETAPA);

            /*" -705- PERFORM R0400-00-CRITICA-ROTN-ETAPA. */

            R0400_00_CRITICA_ROTN_ETAPA_SECTION();

            /*" -706- IF GE386-IND-TIPO-ETAPA = ZEROS */

            if (GE386.DCLGE_ROTINA_ETAPA.GE386_IND_TIPO_ETAPA == 00)
            {

                /*" -707- PERFORM R0600-00-CRITICA-EXEC-ROT-ETP */

                R0600_00_CRITICA_EXEC_ROT_ETP_SECTION();

                /*" -707- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-CRITICA-EXEC-ETP-POS-SECTION */
        private void R0900_00_CRITICA_EXEC_ETP_POS_SECTION()
        {
            /*" -733- PERFORM R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1 */

            R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1();

            /*" -736- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -737- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -738- MOVE ZEROS TO WHOST-QTD-ETP-POST */
                    _.Move(0, WHOST_QTD_ETP_POST);

                    /*" -739- ELSE */
                }
                else
                {


                    /*" -741- MOVE 'R0900 - ERRO SELECT DO JOIN GE386/GE387' TO LKFC-MENS-ERRO */
                    _.Move("R0900 - ERRO SELECT DO JOIN GE386/GE387", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                    /*" -742- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -743- END-IF */
                }


                /*" -743- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-CRITICA-EXEC-ETP-POS-DB-SELECT-1 */
        public void R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1()
        {
            /*" -733- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-QTD-ETP-POST FROM SEGUROS.GE_ROTINA_ETAPA A, SEGUROS.GE_EXEC_ROTINA_ETAPA B WHERE A.NOM_ROTINA = :GE386-NOM-ROTINA AND A.SEQ_ETAPA > :GE386-SEQ-ETAPA AND A.DTH_FIM_VIGENCIA IS NULL AND A.IND_TIPO_ETAPA = 0 AND B.NOM_ROTINA = A.NOM_ROTINA AND B.SEQ_ETAPA = A.SEQ_ETAPA AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA AND B.NUM_EXEC_ETAPA = A.QTD_EXEC_ETAPA END-EXEC. */

            var r0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1 = new R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1()
            {
                GE386_NOM_ROTINA = GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_ROTINA.ToString(),
                GE386_SEQ_ETAPA = GE386.DCLGE_ROTINA_ETAPA.GE386_SEQ_ETAPA.ToString(),
            };

            var executed_1 = R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1.Execute(r0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTD_ETP_POST, WHOST_QTD_ETP_POST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-MONTA-PARM-LKFC-P0-SECTION */
        private void R1000_00_MONTA_PARM_LKFC_P0_SECTION()
        {
            /*" -756- PERFORM R1100-00-SELECT-CALENDARIO. */

            R1100_00_SELECT_CALENDARIO_SECTION();

            /*" -757- MOVE SISTEMAS-DATA-MOV-ABERTO TO LKFC-DATA-MOVTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_DATA_MOVTO);

            /*" -758- MOVE WHOST-DTMOVTO-I TO LKFC-DAT-TERMOV. */
            _.Move(WHOST_DTMOVTO_I, REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_DAT_TERMOV);

            /*" -759- MOVE SISTEMAS-DATA-MOV-ABERTO TO LKFC-DAT-INIMOV. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_DAT_INIMOV);

            /*" -761- MOVE WHOST-DTCURRENT TO LKFC-DAT-CURRNT. */
            _.Move(WHOST_DTCURRENT, REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_DAT_CURRNT);

            /*" -764- MOVE ZEROS TO LKFC-SQL-CODE LKFC-RETN-CODE. */
            _.Move(0, REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_SQL_CODE, REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_RETN_CODE);

            /*" -766- MOVE SPACES TO LKFC-MENS-ERRO. */
            _.Move("", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

            /*" -767- IF LKFC-DAT-INIMOV > LKFC-DAT-TERMOV */

            if (REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_DAT_INIMOV > REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_DAT_TERMOV)
            {

                /*" -769- MOVE 'R1000 - DATA MOVTO INICIAL MAIOR QUE A FINAL' TO LKFC-MENS-ERRO */
                _.Move("R1000 - DATA MOVTO INICIAL MAIOR QUE A FINAL", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -770- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -772- END-IF. */
            }


            /*" -773- MOVE LKFC-NOM-ROTINA TO GE387-NOM-ROTINA. */
            _.Move(REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_NOM_ROTINA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NOM_ROTINA);

            /*" -774- MOVE LKFC-SEQ-ETAPA TO GE387-SEQ-ETAPA. */
            _.Move(REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_SEQ_ETAPA, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_SEQ_ETAPA);

            /*" -775- MOVE WHOST-DTH-INI-VIGC TO GE387-DTH-INI-VIGENCIA. */
            _.Move(WHOST_DTH_INI_VIGC, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTH_INI_VIGENCIA);

            /*" -777- MOVE ZEROS TO GE387-NUM-EXEC-ETAPA. */
            _.Move(0, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NUM_EXEC_ETAPA);

            /*" -779- COMPUTE GE387-NUM-EXEC-ETAPA = WHOST-QTD-EXEC-ETP + 1. */
            GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NUM_EXEC_ETAPA.Value = WHOST_QTD_EXEC_ETP + 1;

            /*" -780- MOVE LKFC-DAT-INIMOV TO GE387-DTA-INI-MOVIMENTO. */
            _.Move(REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_DAT_INIMOV, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_INI_MOVIMENTO);

            /*" -782- MOVE LKFC-DAT-TERMOV TO GE387-DTA-FIM-MOVIMENTO. */
            _.Move(REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_DAT_TERMOV, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_FIM_MOVIMENTO);

            /*" -788- MOVE ZEROS TO GE387-QTD-REG-LIDOS GE387-QTD-REG-PROCS GE387-QTD-REG-GRAVD GE387-QTD-REG-ALTER GE387-QTD-REG-EXCLU. */
            _.Move(0, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_LIDOS, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_PROCS, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_GRAVD, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_ALTER, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_EXCLU);

            /*" -794- MOVE '0' TO GE387-STA-EXECUCAO. */
            _.Move("0", GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_STA_EXECUCAO);

            /*" -795- MOVE GE387-NOM-ROTINA TO GE386-NOM-ROTINA. */
            _.Move(GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NOM_ROTINA, GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_ROTINA);

            /*" -796- MOVE GE387-SEQ-ETAPA TO GE386-SEQ-ETAPA. */
            _.Move(GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_SEQ_ETAPA, GE386.DCLGE_ROTINA_ETAPA.GE386_SEQ_ETAPA);

            /*" -797- MOVE GE387-DTH-INI-VIGENCIA TO GE386-DTH-INI-VIGENCIA. */
            _.Move(GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTH_INI_VIGENCIA, GE386.DCLGE_ROTINA_ETAPA.GE386_DTH_INI_VIGENCIA);

            /*" -798- MOVE WHOST-IND-TIPO-ETP TO GE386-IND-TIPO-ETAPA. */
            _.Move(WHOST_IND_TIPO_ETP, GE386.DCLGE_ROTINA_ETAPA.GE386_IND_TIPO_ETAPA);

            /*" -802- MOVE LKFC-NOM-PROGM TO GE386-NOM-PROGRAMA. */
            _.Move(REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_NOM_PROGM, GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_PROGRAMA);

            /*" -802- PERFORM R1300-00-UPD-GE-ROT-ETAPA. */

            R1300_00_UPD_GE_ROT_ETAPA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-CALENDARIO-SECTION */
        private void R1100_00_SELECT_CALENDARIO_SECTION()
        {
            /*" -815- MOVE WHOST-DTCURRENT TO GE387-DTA-FIM-MOVIMENTO */
            _.Move(WHOST_DTCURRENT, GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_FIM_MOVIMENTO);

            /*" -820- PERFORM R1100_00_SELECT_CALENDARIO_DB_SELECT_1 */

            R1100_00_SELECT_CALENDARIO_DB_SELECT_1();

            /*" -823- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -825- MOVE 'R1100 - ERRO NO SELECT DA TAB CALENDARIO' TO LKFC-MENS-ERRO */
                _.Move("R1100 - ERRO NO SELECT DA TAB CALENDARIO", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -826- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -826- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-CALENDARIO-DB-SELECT-1 */
        public void R1100_00_SELECT_CALENDARIO_DB_SELECT_1()
        {
            /*" -820- EXEC SQL SELECT DATA_CALENDARIO + 1 DAY INTO :WHOST-DTMOVTO-I FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :GE387-DTA-FIM-MOVIMENTO END-EXEC. */

            var r1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1 = new R1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1()
            {
                GE387_DTA_FIM_MOVIMENTO = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_FIM_MOVIMENTO.ToString(),
            };

            var executed_1 = R1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTMOVTO_I, WHOST_DTMOVTO_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-INS-GE-EXC-ROT-ETP-SECTION */
        private void R1200_00_INS_GE_EXC_ROT_ETP_SECTION()
        {
            /*" -839- ADD 1 TO GE387-NUM-EXEC-ETAPA */
            GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NUM_EXEC_ETAPA.Value = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NUM_EXEC_ETAPA + 1;

            /*" -870- PERFORM R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1 */

            R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1();

            /*" -873- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -875- MOVE 'R1200 - ERRO NO INSERT DA GE-EXEC-ROTINA-ETAPA' TO LKFC-MENS-ERRO */
                _.Move("R1200 - ERRO NO INSERT DA GE-EXEC-ROTINA-ETAPA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -876- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -876- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-INS-GE-EXC-ROT-ETP-DB-INSERT-1 */
        public void R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1()
        {
            /*" -870- EXEC SQL INSERT INTO SEGUROS.GE_EXEC_ROTINA_ETAPA (NOM_ROTINA, SEQ_ETAPA, DTH_INI_VIGENCIA, NUM_EXEC_ETAPA, DTA_INI_MOVIMENTO, DTA_FIM_MOVIMENTO, QTD_REG_LIDOS, QTD_REG_PROCS, QTD_REG_GRAVD, QTD_REG_ALTER, QTD_REG_EXCLU, STA_EXECUCAO, DTH_INI_EXECUCAO, DTH_FIM_EXECUCAO) VALUES (:GE387-NOM-ROTINA, :GE387-SEQ-ETAPA, :GE387-DTH-INI-VIGENCIA, :GE387-NUM-EXEC-ETAPA, CURRENT DATE, CURRENT DATE, :GE387-QTD-REG-LIDOS, :GE387-QTD-REG-PROCS, :GE387-QTD-REG-GRAVD, :GE387-QTD-REG-ALTER, :GE387-QTD-REG-EXCLU, :GE387-STA-EXECUCAO, CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1 = new R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1()
            {
                GE387_NOM_ROTINA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NOM_ROTINA.ToString(),
                GE387_SEQ_ETAPA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_SEQ_ETAPA.ToString(),
                GE387_DTH_INI_VIGENCIA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTH_INI_VIGENCIA.ToString(),
                GE387_NUM_EXEC_ETAPA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NUM_EXEC_ETAPA.ToString(),
                GE387_QTD_REG_LIDOS = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_LIDOS.ToString(),
                GE387_QTD_REG_PROCS = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_PROCS.ToString(),
                GE387_QTD_REG_GRAVD = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_GRAVD.ToString(),
                GE387_QTD_REG_ALTER = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_ALTER.ToString(),
                GE387_QTD_REG_EXCLU = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_EXCLU.ToString(),
                GE387_STA_EXECUCAO = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_STA_EXECUCAO.ToString(),
            };

            R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1.Execute(r1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-UPD-GE-ROT-ETAPA-SECTION */
        private void R1300_00_UPD_GE_ROT_ETAPA_SECTION()
        {
            /*" -888- ADD 1 TO GE386-QTD-EXEC-ETAPA. */
            GE386.DCLGE_ROTINA_ETAPA.GE386_QTD_EXEC_ETAPA.Value = GE386.DCLGE_ROTINA_ETAPA.GE386_QTD_EXEC_ETAPA + 1;

            /*" -897- PERFORM R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1 */

            R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1();

            /*" -900- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -902- MOVE 'R1300 - ERRO NO UPDATE DA GE-ROTINA-ETAPA' TO LKFC-MENS-ERRO */
                _.Move("R1300 - ERRO NO UPDATE DA GE-ROTINA-ETAPA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -903- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -903- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1300_99_SAIDA */

            R1300_99_SAIDA();

        }

        [StopWatch]
        /*" R1300-00-UPD-GE-ROT-ETAPA-DB-UPDATE-1 */
        public void R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1()
        {
            /*" -897- EXEC SQL UPDATE SEGUROS.GE_ROTINA_ETAPA SET QTD_EXEC_ETAPA = :GE386-QTD-EXEC-ETAPA WHERE NOM_ROTINA = :GE386-NOM-ROTINA AND SEQ_ETAPA = :GE386-SEQ-ETAPA AND DTH_INI_VIGENCIA = :GE386-DTH-INI-VIGENCIA AND DTH_FIM_VIGENCIA IS NULL AND IND_TIPO_ETAPA = :GE386-IND-TIPO-ETAPA AND NOM_PROGRAMA = :GE386-NOM-PROGRAMA END-EXEC. */

            var r1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1 = new R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1()
            {
                GE386_QTD_EXEC_ETAPA = GE386.DCLGE_ROTINA_ETAPA.GE386_QTD_EXEC_ETAPA.ToString(),
                GE386_DTH_INI_VIGENCIA = GE386.DCLGE_ROTINA_ETAPA.GE386_DTH_INI_VIGENCIA.ToString(),
                GE386_IND_TIPO_ETAPA = GE386.DCLGE_ROTINA_ETAPA.GE386_IND_TIPO_ETAPA.ToString(),
                GE386_NOM_PROGRAMA = GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_PROGRAMA.ToString(),
                GE386_NOM_ROTINA = GE386.DCLGE_ROTINA_ETAPA.GE386_NOM_ROTINA.ToString(),
                GE386_SEQ_ETAPA = GE386.DCLGE_ROTINA_ETAPA.GE386_SEQ_ETAPA.ToString(),
            };

            R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1.Execute(r1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1300-99-SAIDA */
        private void R1300_99_SAIDA(bool isPerform = false)
        {
            /*" -947- EXIT. */

            return;

        }

        [StopWatch]
        /*" R1500-00-UPD-GE-EXC-ROT-ETP-SECTION */
        private void R1500_00_UPD_GE_EXC_ROT_ETP_SECTION()
        {
            /*" -969- PERFORM R1500_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1 */

            R1500_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1();

            /*" -972- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -974- MOVE 'R1500 - ERRO NO UPDATE DA GE-EXEC-ROTINA-ETAPA' TO LKFC-MENS-ERRO */
                _.Move("R1500 - ERRO NO UPDATE DA GE-EXEC-ROTINA-ETAPA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -975- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -975- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-UPD-GE-EXC-ROT-ETP-DB-UPDATE-1 */
        public void R1500_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1()
        {
            /*" -969- EXEC SQL UPDATE SEGUROS.GE_EXEC_ROTINA_ETAPA SET QTD_REG_LIDOS = :GE387-QTD-REG-LIDOS, QTD_REG_PROCS = :GE387-QTD-REG-PROCS, QTD_REG_GRAVD = :GE387-QTD-REG-GRAVD, QTD_REG_ALTER = :GE387-QTD-REG-ALTER, QTD_REG_EXCLU = :GE387-QTD-REG-EXCLU, STA_EXECUCAO = :GE387-STA-EXECUCAO, DTH_INI_EXECUCAO = CURRENT TIMESTAMP, DTH_FIM_EXECUCAO = NULL WHERE NOM_ROTINA = :GE387-NOM-ROTINA AND SEQ_ETAPA = :GE387-SEQ-ETAPA AND DTH_INI_VIGENCIA = :GE387-DTH-INI-VIGENCIA AND NUM_EXEC_ETAPA = :GE387-NUM-EXEC-ETAPA END-EXEC. */

            var r1500_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1 = new R1500_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1()
            {
                GE387_QTD_REG_LIDOS = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_LIDOS.ToString(),
                GE387_QTD_REG_PROCS = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_PROCS.ToString(),
                GE387_QTD_REG_GRAVD = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_GRAVD.ToString(),
                GE387_QTD_REG_ALTER = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_ALTER.ToString(),
                GE387_QTD_REG_EXCLU = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_EXCLU.ToString(),
                GE387_STA_EXECUCAO = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_STA_EXECUCAO.ToString(),
                GE387_DTH_INI_VIGENCIA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTH_INI_VIGENCIA.ToString(),
                GE387_NUM_EXEC_ETAPA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NUM_EXEC_ETAPA.ToString(),
                GE387_NOM_ROTINA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NOM_ROTINA.ToString(),
                GE387_SEQ_ETAPA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_SEQ_ETAPA.ToString(),
            };

            R1500_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1.Execute(r1500_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-UPD-GE-EXC-ROT-ETP-SECTION */
        private void R1700_00_UPD_GE_EXC_ROT_ETP_SECTION()
        {
            /*" -1043- PERFORM R1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1 */

            R1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1();

            /*" -1046- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1048- MOVE 'R1700 - ERRO NO UPDATE DA GE-EXEC-ROTINA-ETAPA' TO LKFC-MENS-ERRO */
                _.Move("R1700 - ERRO NO UPDATE DA GE-EXEC-ROTINA-ETAPA", REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_MENS_ERRO);

                /*" -1049- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1049- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-UPD-GE-EXC-ROT-ETP-DB-UPDATE-1 */
        public void R1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1()
        {
            /*" -1043- EXEC SQL UPDATE SEGUROS.GE_EXEC_ROTINA_ETAPA SET DTA_FIM_MOVIMENTO = :GE387-DTA-FIM-MOVIMENTO, QTD_REG_LIDOS = :GE387-QTD-REG-LIDOS, QTD_REG_PROCS = :GE387-QTD-REG-PROCS, QTD_REG_GRAVD = :GE387-QTD-REG-GRAVD, QTD_REG_ALTER = :GE387-QTD-REG-ALTER, QTD_REG_EXCLU = :GE387-QTD-REG-EXCLU, STA_EXECUCAO = :GE387-STA-EXECUCAO, DTH_INI_EXECUCAO = CURRENT TIMESTAMP, DTH_FIM_EXECUCAO = NULL WHERE NOM_ROTINA = :GE387-NOM-ROTINA AND SEQ_ETAPA = :GE387-SEQ-ETAPA AND DTH_INI_VIGENCIA = :GE387-DTH-INI-VIGENCIA AND NUM_EXEC_ETAPA = :GE387-NUM-EXEC-ETAPA END-EXEC. */

            var r1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1 = new R1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1()
            {
                GE387_DTA_FIM_MOVIMENTO = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_FIM_MOVIMENTO.ToString(),
                GE387_QTD_REG_LIDOS = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_LIDOS.ToString(),
                GE387_QTD_REG_PROCS = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_PROCS.ToString(),
                GE387_QTD_REG_GRAVD = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_GRAVD.ToString(),
                GE387_QTD_REG_ALTER = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_ALTER.ToString(),
                GE387_QTD_REG_EXCLU = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_QTD_REG_EXCLU.ToString(),
                GE387_STA_EXECUCAO = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_STA_EXECUCAO.ToString(),
                GE387_DTH_INI_VIGENCIA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTH_INI_VIGENCIA.ToString(),
                GE387_NUM_EXEC_ETAPA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NUM_EXEC_ETAPA.ToString(),
                GE387_NOM_ROTINA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_NOM_ROTINA.ToString(),
                GE387_SEQ_ETAPA = GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_SEQ_ETAPA.ToString(),
            };

            R1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1.Execute(r1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1062- MOVE SQLCODE TO LKFC-SQL-CODE. */
            _.Move(DB.SQLCODE, REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_SQL_CODE);

            /*" -1065- MOVE 99 TO LKFC-RETN-CODE. */
            _.Move(99, REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_RETN_CODE);

            /*" -1065- GOBACK. */

            throw new GoBack();

        }
    }
}