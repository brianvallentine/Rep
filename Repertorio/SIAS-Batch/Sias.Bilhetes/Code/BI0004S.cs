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
using Sias.Bilhetes.DB2.BI0004S;

namespace Code
{
    public class BI0004S
    {
        public bool IsCall { get; set; }

        public BI0004S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------                                              */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  BI - BILHETES                      *      */
        /*"      *   PROGRAMA ...............  BI0004S.                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  CANETTA                            *      */
        /*"      *   PROGRAMADOR ............  CANETTA                            *      */
        /*"      *   DATA CODIFICACAO .......  04/2024                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  MANUTENCAO DO RELACIONAMENTO       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * ALTERACOES                                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.00  * VERSAO XX EM XX/XXXX - JAZZ XXXXXX                             *      */
        /*"      *   XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.00                        XXXXXXX             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01           WS-WORKING.*/
        public BI0004S_WS_WORKING WS_WORKING { get; set; } = new BI0004S_WS_WORKING();
        public class BI0004S_WS_WORKING : VarBasis
        {
            /*"  03         WS-AUXILIARES.*/
            public BI0004S_WS_AUXILIARES WS_AUXILIARES { get; set; } = new BI0004S_WS_AUXILIARES();
            public class BI0004S_WS_AUXILIARES : VarBasis
            {
                /*"    05       WS-SQLCODE         PIC   ---9.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
                /*"    05       WS-COD-PES-004     PIC S9(009)    VALUE +0 COMP.*/
                public IntBasis WS_COD_PES_004 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    05       WS-MAX-NUM-IDE     PIC S9(015)    VALUE +0 COMP.*/
                public IntBasis WS_MAX_NUM_IDE { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"    05       VIND-FILLER        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_FILLER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  03         NIVEIS-88.*/
            }
            public BI0004S_NIVEIS_88 NIVEIS_88 { get; set; } = new BI0004S_NIVEIS_88();
            public class BI0004S_NIVEIS_88 : VarBasis
            {
                /*"    05       N88-TIPORELAC      PIC  X(001)    VALUE '&'.*/

                public SelectorBasis N88_TIPORELAC { get; set; } = new SelectorBasis("001", "&")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     TEM-TIPORELAC                     VALUE 'S'. */
							new SelectorItemBasis("TEM_TIPORELAC", "S")
                }
                };

                /*"01     BI0004L-LINKAGE.*/
            }
        }
        public BI0004S_BI0004L_LINKAGE BI0004L_LINKAGE { get; set; } = new BI0004S_BI0004L_LINKAGE();
        public class BI0004S_BI0004L_LINKAGE : VarBasis
        {
            /*" 03    BI0004L-E-PESSOA.*/
            public BI0004S_BI0004L_E_PESSOA BI0004L_E_PESSOA { get; set; } = new BI0004S_BI0004L_E_PESSOA();
            public class BI0004S_BI0004L_E_PESSOA : VarBasis
            {
                /*"  05   BI0004L-E-COD-PES        PIC S9(009) COMP-3  VALUE +0.*/
                public IntBasis BI0004L_E_COD_PES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"  05   BI0004L-E-COD-PRD-SIG    PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis BI0004L_E_COD_PRD_SIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05   BI0004L-E-DAT-SIS        PIC  X(010)         VALUE SPACES*/
                public StringBasis BI0004L_E_DAT_SIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05   BI0004L-E-COD-USU        PIC  X(008)         VALUE SPACES*/
                public StringBasis BI0004L_E_COD_USU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*" 03    BI0004L-SAIDA.*/
            }
            public BI0004S_BI0004L_SAIDA BI0004L_SAIDA { get; set; } = new BI0004S_BI0004L_SAIDA();
            public class BI0004S_BI0004L_SAIDA : VarBasis
            {
                /*"  05   BI0004L-S-COD-ERR        PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis BI0004L_S_COD_ERR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05   BI0004L-S-COD-SQL        PIC   ---9.*/
                public IntBasis BI0004L_S_COD_SQL { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
                /*"  05   BI0004L-S-DES-ERR        PIC  X(030).*/
                public StringBasis BI0004L_S_DES_ERR { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"  05   BI0004L-S-COD-IDE        PIC S9(015) COMP-3  VALUE +0.*/
                public IntBasis BI0004L_S_COD_IDE { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.RTPRELAC RTPRELAC { get; set; } = new Dclgens.RTPRELAC();
        public Dclgens.IDERELAC IDERELAC { get; set; } = new Dclgens.IDERELAC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(BI0004S_BI0004L_LINKAGE BI0004S_BI0004L_LINKAGE_P) //PROCEDURE DIVISION USING 
        /*BI0004L_LINKAGE*/
        {
            try
            {
                this.BI0004L_LINKAGE = BI0004S_BI0004L_LINKAGE_P;

                /*" -0- FLUXCONTROL_PERFORM M-0000-00-BI0004S-SECTION */

                M_0000_00_BI0004S_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { BI0004L_LINKAGE };
            return Result;
        }

        [StopWatch]
        /*" M-0000-00-BI0004S-SECTION */
        private void M_0000_00_BI0004S_SECTION()
        {
            /*" -105- DISPLAY '0000-00-BI0004S        ' */
            _.Display($"0000-00-BI0004S        ");

            /*" -107- PERFORM 10000-00-INICIAL THRU 10000-99-SAIDA */

            M_10000_00_INICIAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/


            /*" -109- PERFORM 30000-00-PESSOA THRU 30000-99-SAIDA */

            M_30000_00_PESSOA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_30000_99_SAIDA*/


            /*" -111- PERFORM 50000-00-PRODUTO-SIGPF THRU 50000-99-SAIDA */

            M_50000_00_PRODUTO_SIGPF_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_50000_99_SAIDA*/


            /*" -113- PERFORM 70000-00-RELAC-TIP THRU 70000-99-SAIDA */

            M_70000_00_RELAC_TIP_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_70000_99_SAIDA*/


            /*" -115- PERFORM 90000-00-INS-RELAC-TIP THRU 90000-99-SAIDA */

            M_90000_00_INS_RELAC_TIP_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_90000_99_SAIDA*/


            /*" -117- PERFORM B0000-INS-RELAC-IDE THRU B0000-99-SAIDA */

            B0000_INS_RELAC_IDE_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: B0000_99_SAIDA*/


            /*" -119- GOBACK */

            throw new GoBack();

            /*" -119- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_SAIDA*/

        [StopWatch]
        /*" M-10000-00-INICIAL-SECTION */
        private void M_10000_00_INICIAL_SECTION()
        {
            /*" -130- DISPLAY '10000-00-INICIAL       ' */
            _.Display($"10000-00-INICIAL       ");

            /*" -131- DISPLAY '=================================================' */
            _.Display($"=================================================");

            /*" -132- DISPLAY ' BI0004S - MANUTENCAO BASE RELACIONAMENTO - V.00 ' */
            _.Display($" BI0004S - MANUTENCAO BASE RELACIONAMENTO - V.00 ");

            /*" -133- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -139- DISPLAY ' VERSAO DE : ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $" VERSAO DE : FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -140- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -149- DISPLAY ' DATA DE PROCESSAMENTO: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $" DATA DE PROCESSAMENTO: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -150- DISPLAY 'BI0004L-E-COD-USU    : ' BI0004L-E-COD-USU */
            _.Display($"BI0004L-E-COD-USU    : {BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_USU}");

            /*" -151- DISPLAY 'BI0004L-E-COD-PES    : ' BI0004L-E-COD-PES */
            _.Display($"BI0004L-E-COD-PES    : {BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_PES}");

            /*" -152- DISPLAY 'BI0004L-E-COD-PRD-SIG: ' BI0004L-E-COD-PRD-SIG */
            _.Display($"BI0004L-E-COD-PRD-SIG: {BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_PRD_SIG}");

            /*" -155- DISPLAY 'BI0004L-E-DAT-SIS    : ' BI0004L-E-DAT-SIS */
            _.Display($"BI0004L-E-DAT-SIS    : {BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_DAT_SIS}");

            /*" -158- MOVE ZEROS TO BI0004L-S-COD-ERR BI0004L-S-COD-SQL BI0004L-S-COD-IDE */
            _.Move(0, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_SQL, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_IDE);

            /*" -160- MOVE 'PROCESSAMENTO NORMAL' TO BI0004L-S-DES-ERR */
            _.Move("PROCESSAMENTO NORMAL", BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_DES_ERR);

            /*" -162- IF (BI0004L-E-COD-PES NOT NUMERIC) OR (BI0004L-E-COD-PES EQUAL ZEROS) */

            if ((!BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_PES.IsNumeric()) || (BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_PES == 00))
            {

                /*" -163- MOVE 001 TO BI0004L-S-COD-ERR */
                _.Move(001, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR);

                /*" -164- MOVE 'CODIGO DE PESSOA INVALIDO' TO BI0004L-S-DES-ERR */
                _.Move("CODIGO DE PESSOA INVALIDO", BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_DES_ERR);

                /*" -165- GOBACK */

                throw new GoBack();

                /*" -167- END-IF */
            }


            /*" -169- IF (BI0004L-E-COD-PRD-SIG NOT NUMERIC) OR (BI0004L-E-COD-PRD-SIG EQUAL ZEROS) */

            if ((!BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_PRD_SIG.IsNumeric()) || (BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_PRD_SIG == 00))
            {

                /*" -170- MOVE 002 TO BI0004L-S-COD-ERR */
                _.Move(002, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR);

                /*" -171- MOVE 'CODIGO DO PRODUTO INVALIDO' TO BI0004L-S-DES-ERR */
                _.Move("CODIGO DO PRODUTO INVALIDO", BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_DES_ERR);

                /*" -172- GOBACK */

                throw new GoBack();

                /*" -174- END-IF */
            }


            /*" -175- IF (BI0004L-E-DAT-SIS EQUAL SPACES) */

            if ((BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_DAT_SIS.IsEmpty()))
            {

                /*" -176- MOVE 003 TO BI0004L-S-COD-ERR */
                _.Move(003, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR);

                /*" -177- MOVE 'DATA INVALIDA' TO BI0004L-S-DES-ERR */
                _.Move("DATA INVALIDA", BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_DES_ERR);

                /*" -178- GOBACK */

                throw new GoBack();

                /*" -180- END-IF */
            }


            /*" -181- IF (BI0004L-E-COD-USU EQUAL SPACES) */

            if ((BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_USU.IsEmpty()))
            {

                /*" -182- MOVE 004 TO BI0004L-S-COD-ERR */
                _.Move(004, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR);

                /*" -183- MOVE 'USUARIO INVALIDO' TO BI0004L-S-DES-ERR */
                _.Move("USUARIO INVALIDO", BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_DES_ERR);

                /*" -184- GOBACK */

                throw new GoBack();

                /*" -186- END-IF */
            }


            /*" -186- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/

        [StopWatch]
        /*" M-30000-00-PESSOA-SECTION */
        private void M_30000_00_PESSOA_SECTION()
        {
            /*" -198- DISPLAY '30000-00-PESSOA   ' */
            _.Display($"30000-00-PESSOA   ");

            /*" -204- PERFORM M_30000_00_PESSOA_DB_SELECT_1 */

            M_30000_00_PESSOA_DB_SELECT_1();

            /*" -208- DISPLAY 'SEL PESSOA: ' BI0004L-E-COD-PES ' SQLCODE: ' SQLCODE */

            $"SEL PESSOA: {BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_PES} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -209- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -210- MOVE 005 TO BI0004L-S-COD-ERR */
                _.Move(005, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR);

                /*" -211- MOVE 100 TO BI0004L-S-COD-SQL */
                _.Move(100, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_SQL);

                /*" -213- MOVE 'COD. DE PESSOA NAO CADASTRADO' TO BI0004L-S-DES-ERR */
                _.Move("COD. DE PESSOA NAO CADASTRADO", BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_DES_ERR);

                /*" -214- GOBACK */

                throw new GoBack();

                /*" -215- ELSE */
            }
            else
            {


                /*" -216- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -218- MOVE SQLCODE TO WS-SQLCODE BI0004L-S-COD-SQL */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_SQL);

                    /*" -219- MOVE 'ERRO SEL PESSOA' TO BI0004L-S-DES-ERR */
                    _.Move("ERRO SEL PESSOA", BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_DES_ERR);

                    /*" -220- DISPLAY '***' */
                    _.Display($"***");

                    /*" -221- DISPLAY ' 30000-00-PESSOA    ' */
                    _.Display($" 30000-00-PESSOA    ");

                    /*" -222- DISPLAY ' ERRO SEL PESSOA (' WS-SQLCODE ')' */

                    $" ERRO SEL PESSOA ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -223- DISPLAY '***' */
                    _.Display($"***");

                    /*" -224- GOBACK */

                    throw new GoBack();

                    /*" -225- END-IF */
                }


                /*" -227- END-IF */
            }


            /*" -227- . */

        }

        [StopWatch]
        /*" M-30000-00-PESSOA-DB-SELECT-1 */
        public void M_30000_00_PESSOA_DB_SELECT_1()
        {
            /*" -204- EXEC SQL SELECT COD_PESSOA INTO :WS-COD-PES-004 FROM SEGUROS.PESSOA WHERE COD_PESSOA = :BI0004L-E-COD-PES WITH UR END-EXEC */

            var m_30000_00_PESSOA_DB_SELECT_1_Query1 = new M_30000_00_PESSOA_DB_SELECT_1_Query1()
            {
                BI0004L_E_COD_PES = BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_PES.ToString(),
            };

            var executed_1 = M_30000_00_PESSOA_DB_SELECT_1_Query1.Execute(m_30000_00_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COD_PES_004, WS_WORKING.WS_AUXILIARES.WS_COD_PES_004);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_30000_99_SAIDA*/

        [StopWatch]
        /*" M-50000-00-PRODUTO-SIGPF-SECTION */
        private void M_50000_00_PRODUTO_SIGPF_SECTION()
        {
            /*" -239- DISPLAY '50000-00-PRODUTO-SIGPF      ' */
            _.Display($"50000-00-PRODUTO-SIGPF      ");

            /*" -252- PERFORM M_50000_00_PRODUTO_SIGPF_DB_SELECT_1 */

            M_50000_00_PRODUTO_SIGPF_DB_SELECT_1();

            /*" -256- DISPLAY 'SEL PRODUTO: ' BI0004L-E-COD-PRD-SIG ' SQLCODE: ' SQLCODE */

            $"SEL PRODUTO: {BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_PRD_SIG} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -257- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -259- MOVE SQLCODE TO BI0004L-S-COD-ERR BI0004L-S-COD-SQL */
                _.Move(DB.SQLCODE, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_SQL);

                /*" -260- MOVE 'ERRO SEL PRODUTO' TO BI0004L-S-DES-ERR */
                _.Move("ERRO SEL PRODUTO", BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_DES_ERR);

                /*" -261- DISPLAY '***' */
                _.Display($"***");

                /*" -262- DISPLAY ' 50000-00-PRODUTO-SIGPF    ' */
                _.Display($" 50000-00-PRODUTO-SIGPF    ");

                /*" -263- DISPLAY ' ERRO SEL PRODUTO (' WS-SQLCODE ')' */

                $" ERRO SEL PRODUTO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -264- DISPLAY '***' */
                _.Display($"***");

                /*" -265- GOBACK */

                throw new GoBack();

                /*" -267- END-IF */
            }


            /*" -267- . */

        }

        [StopWatch]
        /*" M-50000-00-PRODUTO-SIGPF-DB-SELECT-1 */
        public void M_50000_00_PRODUTO_SIGPF_DB_SELECT_1()
        {
            /*" -252- EXEC SQL SELECT DISTINCT COD_PRODUTO_SIVPF , COD_RELAC , COD_EMPRESA_SIVPF INTO :PRDSIVPF-COD-PRODUTO-SIVPF , :PRDSIVPF-COD-RELAC , :PRDSIVPF-COD-EMPRESA-SIVPF FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_PRODUTO_SIVPF = :BI0004L-E-COD-PRD-SIG AND DTH_INI_VIGENCIA < :BI0004L-E-DAT-SIS AND DTH_FIM_VIGENCIA > :BI0004L-E-DAT-SIS ORDER BY COD_PRODUTO_SIVPF, COD_RELAC, COD_EMPRESA_SIVPF WITH UR END-EXEC */

            var m_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1 = new M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1()
            {
                BI0004L_E_COD_PRD_SIG = BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_PRD_SIG.ToString(),
                BI0004L_E_DAT_SIS = BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_DAT_SIS.ToString(),
            };

            var executed_1 = M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1.Execute(m_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_COD_PRODUTO_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PRDSIVPF_COD_RELAC, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC);
                _.Move(executed_1.PRDSIVPF_COD_EMPRESA_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_50000_99_SAIDA*/

        [StopWatch]
        /*" M-70000-00-RELAC-TIP-SECTION */
        private void M_70000_00_RELAC_TIP_SECTION()
        {
            /*" -278- DISPLAY '70000-00-RELAC-TIP    ' */
            _.Display($"70000-00-RELAC-TIP    ");

            /*" -287- PERFORM M_70000_00_RELAC_TIP_DB_SELECT_1 */

            M_70000_00_RELAC_TIP_DB_SELECT_1();

            /*" -292- DISPLAY 'SEL R_PESSOA_TIPORELAC: ' WS-COD-PES-004 '/' PRDSIVPF-COD-RELAC ' SQLCODE: ' SQLCODE */

            $"SEL R_PESSOA_TIPORELAC: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_004}/{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -293- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -294- MOVE 'S' TO N88-TIPORELAC */
                _.Move("S", WS_WORKING.NIVEIS_88.N88_TIPORELAC);

                /*" -295- ELSE */
            }
            else
            {


                /*" -296- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -297- MOVE 'N' TO N88-TIPORELAC */
                    _.Move("N", WS_WORKING.NIVEIS_88.N88_TIPORELAC);

                    /*" -298- ELSE */
                }
                else
                {


                    /*" -300- MOVE SQLCODE TO BI0004L-S-COD-ERR BI0004L-S-COD-SQL */
                    _.Move(DB.SQLCODE, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_SQL);

                    /*" -301- MOVE 'ERRO SEL R_PESSOA_TIPOREL' TO BI0004L-S-DES-ERR */
                    _.Move("ERRO SEL R_PESSOA_TIPOREL", BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_DES_ERR);

                    /*" -302- DISPLAY '***' */
                    _.Display($"***");

                    /*" -303- DISPLAY ' 70000-00-RELAC-TIP ' */
                    _.Display($" 70000-00-RELAC-TIP ");

                    /*" -304- DISPLAY ' ERRO SEL R_PESSOA_TIPOREL (' WS-SQLCODE ')' */

                    $" ERRO SEL R_PESSOA_TIPOREL ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -305- DISPLAY '***' */
                    _.Display($"***");

                    /*" -306- GOBACK */

                    throw new GoBack();

                    /*" -307- END-IF */
                }


                /*" -309- END-IF */
            }


            /*" -309- . */

        }

        [StopWatch]
        /*" M-70000-00-RELAC-TIP-DB-SELECT-1 */
        public void M_70000_00_RELAC_TIP_DB_SELECT_1()
        {
            /*" -287- EXEC SQL SELECT COD_PESSOA , COD_RELAC INTO :DCLR-PESSOA-TIPORELAC.COD-PESSOA , :DCLR-PESSOA-TIPORELAC.COD-RELAC FROM SEGUROS.R_PESSOA_TIPORELAC WHERE COD_PESSOA = :WS-COD-PES-004 AND COD_RELAC = :PRDSIVPF-COD-RELAC WITH UR END-EXEC */

            var m_70000_00_RELAC_TIP_DB_SELECT_1_Query1 = new M_70000_00_RELAC_TIP_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_RELAC = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC.ToString(),
                WS_COD_PES_004 = WS_WORKING.WS_AUXILIARES.WS_COD_PES_004.ToString(),
            };

            var executed_1 = M_70000_00_RELAC_TIP_DB_SELECT_1_Query1.Execute(m_70000_00_RELAC_TIP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);
                _.Move(executed_1.COD_RELAC, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_70000_99_SAIDA*/

        [StopWatch]
        /*" M-90000-00-INS-RELAC-TIP-SECTION */
        private void M_90000_00_INS_RELAC_TIP_SECTION()
        {
            /*" -321- DISPLAY '90000-00-INS-RELAC-TIP     ' */
            _.Display($"90000-00-INS-RELAC-TIP     ");

            /*" -322- IF TEM-TIPORELAC */

            if (WS_WORKING.NIVEIS_88.N88_TIPORELAC["TEM_TIPORELAC"])
            {

                /*" -323- DISPLAY 'TEM-TIPORELAC' */
                _.Display($"TEM-TIPORELAC");

                /*" -324- GO TO 90000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_90000_99_SAIDA*/ //GOTO
                return;

                /*" -327- END-IF */
            }


            /*" -331- PERFORM M_90000_00_INS_RELAC_TIP_DB_INSERT_1 */

            M_90000_00_INS_RELAC_TIP_DB_INSERT_1();

            /*" -336- DISPLAY 'INS R_PESSOA_TIPORELAC: ' WS-COD-PES-004 '/' PRDSIVPF-COD-RELAC ' SQLCODE: ' SQLCODE */

            $"INS R_PESSOA_TIPORELAC: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_004}/{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -337- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -339- MOVE SQLCODE TO BI0004L-S-COD-ERR BI0004L-S-COD-SQL */
                _.Move(DB.SQLCODE, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_SQL);

                /*" -340- MOVE 'ERRO INS R_PESSOA_TIPOREL' TO BI0004L-S-DES-ERR */
                _.Move("ERRO INS R_PESSOA_TIPOREL", BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_DES_ERR);

                /*" -341- DISPLAY '***' */
                _.Display($"***");

                /*" -342- DISPLAY ' 90000-00-INS-RELAC-TIP        ' */
                _.Display($" 90000-00-INS-RELAC-TIP        ");

                /*" -343- DISPLAY ' ERRO INS R_PESSOA_TIPORELAC (' WS-SQLCODE ')' */

                $" ERRO INS R_PESSOA_TIPORELAC ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -344- DISPLAY ' CODIGO PESSOA: ' WS-COD-PES-004 */
                _.Display($" CODIGO PESSOA: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_004}");

                /*" -345- DISPLAY ' CODIGO RELACIONAMENTO: ' PRDSIVPF-COD-RELAC */
                _.Display($" CODIGO RELACIONAMENTO: {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC}");

                /*" -346- DISPLAY '***' */
                _.Display($"***");

                /*" -347- GOBACK */

                throw new GoBack();

                /*" -349- END-IF */
            }


            /*" -349- . */

        }

        [StopWatch]
        /*" M-90000-00-INS-RELAC-TIP-DB-INSERT-1 */
        public void M_90000_00_INS_RELAC_TIP_DB_INSERT_1()
        {
            /*" -331- EXEC SQL INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES (:WS-COD-PES-004 , :PRDSIVPF-COD-RELAC) END-EXEC */

            var m_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1 = new M_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1()
            {
                WS_COD_PES_004 = WS_WORKING.WS_AUXILIARES.WS_COD_PES_004.ToString(),
                PRDSIVPF_COD_RELAC = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC.ToString(),
            };

            M_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1.Execute(m_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_90000_99_SAIDA*/

        [StopWatch]
        /*" B0000-INS-RELAC-IDE-SECTION */
        private void B0000_INS_RELAC_IDE_SECTION()
        {
            /*" -361- DISPLAY 'B0000-INS-RELAC-IDE    ' */
            _.Display($"B0000-INS-RELAC-IDE    ");

            /*" -366- PERFORM B0000_INS_RELAC_IDE_DB_SELECT_1 */

            B0000_INS_RELAC_IDE_DB_SELECT_1();

            /*" -370- DISPLAY 'MAX IDENTIFICA_RELAC ' WS-MAX-NUM-IDE ' SQLCODE: ' SQLCODE */

            $"MAX IDENTIFICA_RELAC {WS_WORKING.WS_AUXILIARES.WS_MAX_NUM_IDE} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -371- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -373- MOVE SQLCODE TO BI0004L-S-COD-ERR BI0004L-S-COD-SQL */
                _.Move(DB.SQLCODE, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_SQL);

                /*" -374- DISPLAY '***' */
                _.Display($"***");

                /*" -375- DISPLAY ' B0000-INS-RELAC-IDE        ' */
                _.Display($" B0000-INS-RELAC-IDE        ");

                /*" -376- DISPLAY ' ERRO MAX IDENTIFICA_RELAC (' WS-SQLCODE ')' */

                $" ERRO MAX IDENTIFICA_RELAC ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -377- DISPLAY '***' */
                _.Display($"***");

                /*" -378- GOBACK */

                throw new GoBack();

                /*" -381- END-IF */
            }


            /*" -385- COMPUTE BI0004L-S-COD-IDE = (WS-MAX-NUM-IDE + 001) */
            BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_IDE.Value = (WS_WORKING.WS_AUXILIARES.WS_MAX_NUM_IDE + 001);

            /*" -392- PERFORM B0000_INS_RELAC_IDE_DB_INSERT_1 */

            B0000_INS_RELAC_IDE_DB_INSERT_1();

            /*" -398- DISPLAY 'INS IDENTIFICA_RELAC ' WS-MAX-NUM-IDE '/' WS-COD-PES-004 '/' PRDSIVPF-COD-RELAC ' SQLCODE: ' SQLCODE */

            $"INS IDENTIFICA_RELAC {WS_WORKING.WS_AUXILIARES.WS_MAX_NUM_IDE}/{WS_WORKING.WS_AUXILIARES.WS_COD_PES_004}/{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -399- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -401- MOVE SQLCODE TO BI0004L-S-COD-ERR BI0004L-S-COD-SQL */
                _.Move(DB.SQLCODE, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR, BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_SQL);

                /*" -402- DISPLAY '***' */
                _.Display($"***");

                /*" -403- DISPLAY ' B0000-INS-RELAC-IDE ' */
                _.Display($" B0000-INS-RELAC-IDE ");

                /*" -404- DISPLAY ' ERRO INS IDENTIFICA_RELAC (' WS-SQLCODE ')' */

                $" ERRO INS IDENTIFICA_RELAC ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -405- DISPLAY '***' */
                _.Display($"***");

                /*" -406- GOBACK */

                throw new GoBack();

                /*" -408- END-IF */
            }


            /*" -408- . */

        }

        [StopWatch]
        /*" B0000-INS-RELAC-IDE-DB-SELECT-1 */
        public void B0000_INS_RELAC_IDE_DB_SELECT_1()
        {
            /*" -366- EXEC SQL SELECT VALUE(MAX(NUM_IDENTIFICACAO),0) INTO :WS-MAX-NUM-IDE FROM SEGUROS.IDENTIFICA_RELAC WITH UR END-EXEC */

            var b0000_INS_RELAC_IDE_DB_SELECT_1_Query1 = new B0000_INS_RELAC_IDE_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = B0000_INS_RELAC_IDE_DB_SELECT_1_Query1.Execute(b0000_INS_RELAC_IDE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_NUM_IDE, WS_WORKING.WS_AUXILIARES.WS_MAX_NUM_IDE);
            }


        }

        [StopWatch]
        /*" B0000-INS-RELAC-IDE-DB-INSERT-1 */
        public void B0000_INS_RELAC_IDE_DB_INSERT_1()
        {
            /*" -392- EXEC SQL INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES (:BI0004L-S-COD-IDE , :WS-COD-PES-004 , :PRDSIVPF-COD-RELAC , :BI0004L-E-COD-USU , CURRENT TIMESTAMP ) END-EXEC */

            var b0000_INS_RELAC_IDE_DB_INSERT_1_Insert1 = new B0000_INS_RELAC_IDE_DB_INSERT_1_Insert1()
            {
                BI0004L_S_COD_IDE = BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_IDE.ToString(),
                WS_COD_PES_004 = WS_WORKING.WS_AUXILIARES.WS_COD_PES_004.ToString(),
                PRDSIVPF_COD_RELAC = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC.ToString(),
                BI0004L_E_COD_USU = BI0004L_LINKAGE.BI0004L_E_PESSOA.BI0004L_E_COD_USU.ToString(),
            };

            B0000_INS_RELAC_IDE_DB_INSERT_1_Insert1.Execute(b0000_INS_RELAC_IDE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B0000_99_SAIDA*/
    }
}