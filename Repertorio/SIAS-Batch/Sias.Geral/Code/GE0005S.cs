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
using Sias.Geral.DB2.GE0005S;

namespace Code
{
    public class GE0005S
    {
        public bool IsCall { get; set; }

        public GE0005S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *------------------------------------                                   */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ...............  SUBROTINAS                          *      */
        /*"      *   PROGRAMA ..............  GE0005S                             *      */
        /*"      *   ANALISTA ..............  PRODEXTER                           *      */
        /*"      *   PROGRAMADOR ...........  PRODEXTER                           *      */
        /*"      *   DATA CODIFICACAO ......  DEZEMBRO / 2004                     *      */
        /*"      *   FUNCAO ................  INFORMADO O RAMO EMISSOR, MODALIDA- *      */
        /*"      *                            DE E VIGENCIA,  RETORNA O RAMO COR- *      */
        /*"      *                            RESPONDENTE (SUSEP)                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                           BOOK                 ACESSO   *      */
        /*"      * ----------------------------------------------------- -------- *      */
        /*"      * CALENDARIO                       CALENDAR             INPUT    *      */
        /*"      * GE_GRUPO_SUSEP                   GE292                INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERA��ES:                                                    *      */
        /*"      * -------------------------------------------------------------- *      */
        /*"F74934* 2012-10: CORRIGIR TRATATIVA PARA RAMO EMISSOR 48.              *      */
        /*"      *          SE DATA EMISSAO > '2010-12-31' USAR TABELA            *      */
        /*"      *             GE_GRUPO_SUSEP.                                    *      */
        /*"      *          HERVAL SOUZA    -  FSI74934.                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"01           AREA-DE-WORK.*/
        public GE0005S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0005S_AREA_DE_WORK();
        public class GE0005S_AREA_DE_WORK : VarBasis
        {
            /*"  05         WZEROS              PIC S9(003)    VALUE +0 COMP-3.*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         WRETORNO            PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WRETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-CALENDAR       PIC  X(003)    VALUE  SPACES.*/
            public StringBasis WTEM_CALENDAR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WTEM-GE292          PIC  X(003)    VALUE  SPACES.*/
            public StringBasis WTEM_GE292 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WLINK-LINKAGE.*/
            public GE0005S_WLINK_LINKAGE WLINK_LINKAGE { get; set; } = new GE0005S_WLINK_LINKAGE();
            public class GE0005S_WLINK_LINKAGE : VarBasis
            {
                /*"    10       WLINK-INPUT.*/
                public GE0005S_WLINK_INPUT WLINK_INPUT { get; set; } = new GE0005S_WLINK_INPUT();
                public class GE0005S_WLINK_INPUT : VarBasis
                {
                    /*"      15     WLINK-RAMO-EMISSOR  PIC  9(004)    VALUE  ZEROS.*/
                    public IntBasis WLINK_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"      15     WLINK-MODALIDADE    PIC  9(004)    VALUE  ZEROS.*/
                    public IntBasis WLINK_MODALIDADE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"      15     WLINK-PRODUTO       PIC  9(004)    VALUE  ZEROS.*/
                    public IntBasis WLINK_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"      15     WLINK-INIVIGENCIA   PIC  X(010)    VALUE  SPACES.*/
                    public StringBasis WLINK_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"    10       WLINK-OUTPUT.*/
                }
                public GE0005S_WLINK_OUTPUT WLINK_OUTPUT { get; set; } = new GE0005S_WLINK_OUTPUT();
                public class GE0005S_WLINK_OUTPUT : VarBasis
                {
                    /*"      15     WLINK-GRUPO-SUSEP   PIC  9(004).*/
                    public IntBasis WLINK_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15     WLINK-RAMO-SUSEP    PIC  9(004).*/
                    public IntBasis WLINK_RAMO_SUSEP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10       WLINK-SQLCODE       PIC  ---9.*/
                }
                public IntBasis WLINK_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
                /*"    10       WLINK-MENSAGEM      PIC  X(070)    VALUE  SPACES.*/
                public StringBasis WLINK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"  05        WABEND.*/
            }
            public GE0005S_WABEND WABEND { get; set; } = new GE0005S_WABEND();
            public class GE0005S_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC X(010) VALUE           ' GE0005S '.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" GE0005S ");
                /*"    10      FILLER              PIC X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01           GE0005S-LINKAGE.*/
            }
        }
        public GE0005S_GE0005S_LINKAGE GE0005S_LINKAGE { get; set; } = new GE0005S_GE0005S_LINKAGE();
        public class GE0005S_GE0005S_LINKAGE : VarBasis
        {
            /*"  05         GE0005S-RAMO-EMISSOR   PIC  9(004).*/
            public IntBasis GE0005S_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         GE0005S-MODALIDADE     PIC  9(004).*/
            public IntBasis GE0005S_MODALIDADE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         GE0005S-PRODUTO        PIC  9(004).*/
            public IntBasis GE0005S_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         GE0005S-INIVIGENCIA    PIC  X(010).*/
            public StringBasis GE0005S_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         GE0005S-GRUPO-SUSEP    PIC  9(004).*/
            public IntBasis GE0005S_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         GE0005S-RAMO-SUSEP     PIC  9(004).*/
            public IntBasis GE0005S_RAMO_SUSEP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         GE0005S-SQLCODE        PIC   ---9.*/
            public IntBasis GE0005S_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
            /*"  05         GE0005S-MENSAGEM       PIC  X(070).*/
            public StringBasis GE0005S_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        }


        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.GE292 GE292 { get; set; } = new Dclgens.GE292();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0005S_GE0005S_LINKAGE GE0005S_GE0005S_LINKAGE_P) //PROCEDURE DIVISION USING 
        /*GE0005S_LINKAGE*/
        {
            try
            {
                this.GE0005S_LINKAGE = GE0005S_GE0005S_LINKAGE_P;

                /*" -115- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -116- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -117- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -120- MOVE SPACES TO WRETORNO */
                _.Move("", AREA_DE_WORK.WRETORNO);

                /*" -121- PERFORM R0500-00-CONSISTE-PARAMETRO */

                R0500_00_CONSISTE_PARAMETRO_SECTION();

                /*" -122- IF WRETORNO EQUAL SPACES */

                if (AREA_DE_WORK.WRETORNO.IsEmpty())
                {

                    /*" -124- PERFORM R1000-00-BUSCA-RAMO. */

                    R1000_00_BUSCA_RAMO_SECTION();
                }


                /*" -125- MOVE WLINK-RAMO-EMISSOR TO GE0005S-RAMO-EMISSOR */
                _.Move(AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_RAMO_EMISSOR, GE0005S_LINKAGE.GE0005S_RAMO_EMISSOR);

                /*" -126- MOVE WLINK-MODALIDADE TO GE0005S-MODALIDADE */
                _.Move(AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_MODALIDADE, GE0005S_LINKAGE.GE0005S_MODALIDADE);

                /*" -127- MOVE WLINK-PRODUTO TO GE0005S-PRODUTO */
                _.Move(AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_PRODUTO, GE0005S_LINKAGE.GE0005S_PRODUTO);

                /*" -128- MOVE WLINK-INIVIGENCIA TO GE0005S-INIVIGENCIA */
                _.Move(AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_INIVIGENCIA, GE0005S_LINKAGE.GE0005S_INIVIGENCIA);

                /*" -129- MOVE WLINK-GRUPO-SUSEP TO GE0005S-GRUPO-SUSEP */
                _.Move(AREA_DE_WORK.WLINK_LINKAGE.WLINK_OUTPUT.WLINK_GRUPO_SUSEP, GE0005S_LINKAGE.GE0005S_GRUPO_SUSEP);

                /*" -131- MOVE WLINK-RAMO-SUSEP TO GE0005S-RAMO-SUSEP */
                _.Move(AREA_DE_WORK.WLINK_LINKAGE.WLINK_OUTPUT.WLINK_RAMO_SUSEP, GE0005S_LINKAGE.GE0005S_RAMO_SUSEP);

                /*" -132- MOVE WLINK-SQLCODE TO GE0005S-SQLCODE */
                _.Move(AREA_DE_WORK.WLINK_LINKAGE.WLINK_SQLCODE, GE0005S_LINKAGE.GE0005S_SQLCODE);

                /*" -134- MOVE WLINK-MENSAGEM TO GE0005S-MENSAGEM. */
                _.Move(AREA_DE_WORK.WLINK_LINKAGE.WLINK_MENSAGEM, GE0005S_LINKAGE.GE0005S_MENSAGEM);

                /*" -134- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { GE0005S_LINKAGE };
            return Result;
        }

        [StopWatch]
        /*" R0500-00-CONSISTE-PARAMETRO-SECTION */
        private void R0500_00_CONSISTE_PARAMETRO_SECTION()
        {
            /*" -143- MOVE GE0005S-LINKAGE TO WLINK-LINKAGE */
            _.Move(GE0005S_LINKAGE, AREA_DE_WORK.WLINK_LINKAGE);

            /*" -144- MOVE ZEROS TO WLINK-SQLCODE */
            _.Move(0, AREA_DE_WORK.WLINK_LINKAGE.WLINK_SQLCODE);

            /*" -146- MOVE SPACES TO WLINK-MENSAGEM */
            _.Move("", AREA_DE_WORK.WLINK_LINKAGE.WLINK_MENSAGEM);

            /*" -147- IF WLINK-INIVIGENCIA EQUAL SPACES OR ZEROS */

            if (AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_INIVIGENCIA.In(string.Empty, "00"))
            {

                /*" -148- MOVE '*' TO WRETORNO */
                _.Move("*", AREA_DE_WORK.WRETORNO);

                /*" -150- MOVE 'INICIO DE VIGENCIA NAO INFORMADO' TO WLINK-MENSAGEM */
                _.Move("INICIO DE VIGENCIA NAO INFORMADO", AREA_DE_WORK.WLINK_LINKAGE.WLINK_MENSAGEM);

                /*" -152- GO TO R0500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -154- MOVE WLINK-INIVIGENCIA TO CALENDAR-DATA-CALENDARIO */
            _.Move(AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_INIVIGENCIA, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

            /*" -154- PERFORM R0510-00-SELECT-CALENDAR. */

            R0510_00_SELECT_CALENDAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-SELECT-CALENDAR-SECTION */
        private void R0510_00_SELECT_CALENDAR_SECTION()
        {
            /*" -172- PERFORM R0510_00_SELECT_CALENDAR_DB_SELECT_1 */

            R0510_00_SELECT_CALENDAR_DB_SELECT_1();

            /*" -175- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -176- MOVE '*' TO WRETORNO */
                _.Move("*", AREA_DE_WORK.WRETORNO);

                /*" -177- IF SQLCODE EQUAL 100 OR -180 OR -181 */

                if (DB.SQLCODE.In("100", "-180", "-181"))
                {

                    /*" -179- MOVE 'INICIO DE VIGENCIA INVALIDO' TO WLINK-MENSAGEM */
                    _.Move("INICIO DE VIGENCIA INVALIDO", AREA_DE_WORK.WLINK_LINKAGE.WLINK_MENSAGEM);

                    /*" -180- ELSE */
                }
                else
                {


                    /*" -181- MOVE SQLCODE TO WLINK-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WLINK_LINKAGE.WLINK_SQLCODE);

                    /*" -182- MOVE 'PROBLEMAS NO ACESSO A TABELA CALENDAR   ' TO WLINK-MENSAGEM. */
                    _.Move("PROBLEMAS NO ACESSO A TABELA CALENDAR   ", AREA_DE_WORK.WLINK_LINKAGE.WLINK_MENSAGEM);
                }

            }


        }

        [StopWatch]
        /*" R0510-00-SELECT-CALENDAR-DB-SELECT-1 */
        public void R0510_00_SELECT_CALENDAR_DB_SELECT_1()
        {
            /*" -172- EXEC SQL SELECT DIA_SEMANA , FERIADO INTO :CALENDAR-DIA-SEMANA , :CALENDAR-FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO END-EXEC. */

            var r0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1 = new R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1.Execute(r0510_00_SELECT_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(executed_1.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-BUSCA-RAMO-SECTION */
        private void R1000_00_BUSCA_RAMO_SECTION()
        {
            /*" -194- MOVE WLINK-RAMO-EMISSOR TO GE292-RAMO-EMISSOR */
            _.Move(AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_RAMO_EMISSOR, GE292.DCLGE_GRUPO_SUSEP.GE292_RAMO_EMISSOR);

            /*" -195- MOVE WLINK-MODALIDADE TO GE292-COD-MODALIDADE */
            _.Move(AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_MODALIDADE, GE292.DCLGE_GRUPO_SUSEP.GE292_COD_MODALIDADE);

            /*" -197- MOVE WLINK-INIVIGENCIA TO GE292-DTH-INI-VIGENCIA */
            _.Move(AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_INIVIGENCIA, GE292.DCLGE_GRUPO_SUSEP.GE292_DTH_INI_VIGENCIA);

            /*" -198- MOVE ZEROS TO WLINK-GRUPO-SUSEP */
            _.Move(0, AREA_DE_WORK.WLINK_LINKAGE.WLINK_OUTPUT.WLINK_GRUPO_SUSEP);

            /*" -200- MOVE ZEROS TO WLINK-RAMO-SUSEP */
            _.Move(0, AREA_DE_WORK.WLINK_LINKAGE.WLINK_OUTPUT.WLINK_RAMO_SUSEP);

            /*" -201- IF WLINK-RAMO-EMISSOR EQUAL ZEROS */

            if (AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_RAMO_EMISSOR == 00)
            {

                /*" -203- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -206- IF GE292-RAMO-EMISSOR EQUAL 48 AND WLINK-INIVIGENCIA < '2011-01-01' */

            if (GE292.DCLGE_GRUPO_SUSEP.GE292_RAMO_EMISSOR == 48 && AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_INIVIGENCIA < "2011-01-01")
            {

                /*" -207- MOVE 08 TO WLINK-GRUPO-SUSEP */
                _.Move(08, AREA_DE_WORK.WLINK_LINKAGE.WLINK_OUTPUT.WLINK_GRUPO_SUSEP);

                /*" -208- IF WLINK-PRODUTO EQUAL ZEROS */

                if (AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_PRODUTO == 00)
                {

                    /*" -209- MOVE 0870 TO WLINK-RAMO-SUSEP */
                    _.Move(0870, AREA_DE_WORK.WLINK_LINKAGE.WLINK_OUTPUT.WLINK_RAMO_SUSEP);

                    /*" -210- GO TO R1000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                    return;

                    /*" -211- ELSE */
                }
                else
                {


                    /*" -214- IF WLINK-PRODUTO EQUAL 4801 OR 4803 OR 4806 OR 4807 OR 4808 OR 4809 OR 4811 OR 4812 */

                    if (AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_PRODUTO.In("4801", "4803", "4806", "4807", "4808", "4809", "4811", "4812"))
                    {

                        /*" -215- MOVE 0870 TO WLINK-RAMO-SUSEP */
                        _.Move(0870, AREA_DE_WORK.WLINK_LINKAGE.WLINK_OUTPUT.WLINK_RAMO_SUSEP);

                        /*" -216- GO TO R1000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                        return;

                        /*" -217- ELSE */
                    }
                    else
                    {


                        /*" -220- IF WLINK-PRODUTO EQUAL 4800 OR 4802 OR 4804 OR 4805 OR 4810 OR 4888 OR 4889 OR 4899 */

                        if (AREA_DE_WORK.WLINK_LINKAGE.WLINK_INPUT.WLINK_PRODUTO.In("4800", "4802", "4804", "4805", "4810", "4888", "4889", "4899"))
                        {

                            /*" -221- MOVE 0860 TO WLINK-RAMO-SUSEP */
                            _.Move(0860, AREA_DE_WORK.WLINK_LINKAGE.WLINK_OUTPUT.WLINK_RAMO_SUSEP);

                            /*" -222- GO TO R1000-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                            return;

                            /*" -223- ELSE */
                        }
                        else
                        {


                            /*" -224- MOVE 0870 TO WLINK-RAMO-SUSEP */
                            _.Move(0870, AREA_DE_WORK.WLINK_LINKAGE.WLINK_OUTPUT.WLINK_RAMO_SUSEP);

                            /*" -226- GO TO R1000-99-SAIDA. */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -228- PERFORM R1100-00-SELECT-GE292 */

            R1100_00_SELECT_GE292_SECTION();

            /*" -229- IF WRETORNO EQUAL SPACES */

            if (AREA_DE_WORK.WRETORNO.IsEmpty())
            {

                /*" -230- MOVE GE292-COD-GRUPO-SUSEP TO WLINK-GRUPO-SUSEP */
                _.Move(GE292.DCLGE_GRUPO_SUSEP.GE292_COD_GRUPO_SUSEP, AREA_DE_WORK.WLINK_LINKAGE.WLINK_OUTPUT.WLINK_GRUPO_SUSEP);

                /*" -230- MOVE GE292-COD-RAMO-SUSEP TO WLINK-RAMO-SUSEP. */
                _.Move(GE292.DCLGE_GRUPO_SUSEP.GE292_COD_RAMO_SUSEP, AREA_DE_WORK.WLINK_LINKAGE.WLINK_OUTPUT.WLINK_RAMO_SUSEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-GE292-SECTION */
        private void R1100_00_SELECT_GE292_SECTION()
        {
            /*" -251- PERFORM R1100_00_SELECT_GE292_DB_SELECT_1 */

            R1100_00_SELECT_GE292_DB_SELECT_1();

            /*" -254- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -255- MOVE '*' TO WRETORNO */
                _.Move("*", AREA_DE_WORK.WRETORNO);

                /*" -256- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -258- MOVE 'RAMO EMISSOR NAO CADASTRADO' TO WLINK-MENSAGEM */
                    _.Move("RAMO EMISSOR NAO CADASTRADO", AREA_DE_WORK.WLINK_LINKAGE.WLINK_MENSAGEM);

                    /*" -259- ELSE */
                }
                else
                {


                    /*" -260- MOVE SQLCODE TO WLINK-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WLINK_LINKAGE.WLINK_SQLCODE);

                    /*" -261- MOVE 'PROBLEMAS NO ACESSO A TABELA GE292' TO WLINK-MENSAGEM. */
                    _.Move("PROBLEMAS NO ACESSO A TABELA GE292", AREA_DE_WORK.WLINK_LINKAGE.WLINK_MENSAGEM);
                }

            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-GE292-DB-SELECT-1 */
        public void R1100_00_SELECT_GE292_DB_SELECT_1()
        {
            /*" -251- EXEC SQL SELECT A.COD_GRUPO_SUSEP , A.COD_RAMO_SUSEP INTO :GE292-COD-GRUPO-SUSEP , :GE292-COD-RAMO-SUSEP FROM SEGUROS.GE_GRUPO_SUSEP A WHERE A.RAMO_EMISSOR = :GE292-RAMO-EMISSOR AND A.COD_MODALIDADE = :GE292-COD-MODALIDADE AND A.DTH_INI_VIGENCIA <= :GE292-DTH-INI-VIGENCIA AND A.DTH_FIM_VIGENCIA >= :GE292-DTH-INI-VIGENCIA END-EXEC. */

            var r1100_00_SELECT_GE292_DB_SELECT_1_Query1 = new R1100_00_SELECT_GE292_DB_SELECT_1_Query1()
            {
                GE292_DTH_INI_VIGENCIA = GE292.DCLGE_GRUPO_SUSEP.GE292_DTH_INI_VIGENCIA.ToString(),
                GE292_COD_MODALIDADE = GE292.DCLGE_GRUPO_SUSEP.GE292_COD_MODALIDADE.ToString(),
                GE292_RAMO_EMISSOR = GE292.DCLGE_GRUPO_SUSEP.GE292_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R1100_00_SELECT_GE292_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_GE292_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE292_COD_GRUPO_SUSEP, GE292.DCLGE_GRUPO_SUSEP.GE292_COD_GRUPO_SUSEP);
                _.Move(executed_1.GE292_COD_RAMO_SUSEP, GE292.DCLGE_GRUPO_SUSEP.GE292_COD_RAMO_SUSEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/
    }
}