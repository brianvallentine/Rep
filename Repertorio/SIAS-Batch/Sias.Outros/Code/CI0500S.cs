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
using Sias.Outros.DB2.CI0500S;

namespace Code
{
    public class CI0500S
    {
        public bool IsCall { get; set; }

        public CI0500S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  CREDITO INTERNO                    *      */
        /*"      *   PROGRAMA ...............  CI0500S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   COORDENADOR.............  LUIZ F GONCALVES                   *      */
        /*"      *   ANALISTA ...............  OLIVEIRA                           *      */
        /*"      *   DATA CODIFICACAO .......  JUN/2006                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  SUBROTINA PARA INFORMAR O NR DA    *      */
        /*"      *                             APOLICE E COD.DO PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      *   ENTRADA: COD-OPERACAO ------------> 9(03)                    *      */
        /*"      *            COD-NATUREZA ------------> 9(04)                    *      */
        /*"      *            DATA INICIO VIGENCIA ----> 9(08) AAAAMMDD           *      */
        /*"      *                                                                *      */
        /*"      *   SAIDA  : APOLICE -----------------> 9(13)                    *      */
        /*"      *            CODIGO DO PRODUTO -------> 9(04)                    *      */
        /*"      *            CODIGO DO RAMO    -------> 9(04)                    *      */
        /*"      *                                                                *      */
        /*"      *    CHAMADA PELOS PROG: CI0005B E SI3040B                      *       */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *-----------------------------------------------------------------      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"    05       WS-DATA-AAAAMMDD         PIC   9(08).*/
        public IntBasis WS_DATA_AAAAMMDD { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
        /*"    05       WS-DATA-AAAAMMDD-R REDEFINES WS-DATA-AAAAMMDD.*/
        private _REDEF_CI0500S_WS_DATA_AAAAMMDD_R _ws_data_aaaammdd_r { get; set; }
        public _REDEF_CI0500S_WS_DATA_AAAAMMDD_R WS_DATA_AAAAMMDD_R
        {
            get { _ws_data_aaaammdd_r = new _REDEF_CI0500S_WS_DATA_AAAAMMDD_R(); _.Move(WS_DATA_AAAAMMDD, _ws_data_aaaammdd_r); VarBasis.RedefinePassValue(WS_DATA_AAAAMMDD, _ws_data_aaaammdd_r, WS_DATA_AAAAMMDD); _ws_data_aaaammdd_r.ValueChanged += () => { _.Move(_ws_data_aaaammdd_r, WS_DATA_AAAAMMDD); }; return _ws_data_aaaammdd_r; }
            set { VarBasis.RedefinePassValue(value, _ws_data_aaaammdd_r, WS_DATA_AAAAMMDD); }
        }  //Redefines
        public class _REDEF_CI0500S_WS_DATA_AAAAMMDD_R : VarBasis
        {
            /*"      07       WS-AA-AAAAMMDD         PIC   9(04).*/
            public IntBasis WS_AA_AAAAMMDD { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"      07       WS-MM-AAAAMMDD         PIC   9(02).*/
            public IntBasis WS_MM_AAAAMMDD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"      07       WS-DD-AAAAMMDD         PIC   9(02).*/
            public IntBasis WS_DD_AAAAMMDD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05       WS-DATA-SQL           PIC  X(10).*/

            public _REDEF_CI0500S_WS_DATA_AAAAMMDD_R()
            {
                WS_AA_AAAAMMDD.ValueChanged += OnValueChanged;
                WS_MM_AAAAMMDD.ValueChanged += OnValueChanged;
                WS_DD_AAAAMMDD.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    05       WS-DATA-SQL-R REDEFINES WS-DATA-SQL.*/
        private _REDEF_CI0500S_WS_DATA_SQL_R _ws_data_sql_r { get; set; }
        public _REDEF_CI0500S_WS_DATA_SQL_R WS_DATA_SQL_R
        {
            get { _ws_data_sql_r = new _REDEF_CI0500S_WS_DATA_SQL_R(); _.Move(WS_DATA_SQL, _ws_data_sql_r); VarBasis.RedefinePassValue(WS_DATA_SQL, _ws_data_sql_r, WS_DATA_SQL); _ws_data_sql_r.ValueChanged += () => { _.Move(_ws_data_sql_r, WS_DATA_SQL); }; return _ws_data_sql_r; }
            set { VarBasis.RedefinePassValue(value, _ws_data_sql_r, WS_DATA_SQL); }
        }  //Redefines
        public class _REDEF_CI0500S_WS_DATA_SQL_R : VarBasis
        {
            /*"      07     WS-ANO-SQL            PIC  9(004).*/
            public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"      07     WS-ANO-SQL-RED REDEFINES WS-ANO-SQL.*/
            private _REDEF_CI0500S_WS_ANO_SQL_RED _ws_ano_sql_red { get; set; }
            public _REDEF_CI0500S_WS_ANO_SQL_RED WS_ANO_SQL_RED
            {
                get { _ws_ano_sql_red = new _REDEF_CI0500S_WS_ANO_SQL_RED(); _.Move(WS_ANO_SQL, _ws_ano_sql_red); VarBasis.RedefinePassValue(WS_ANO_SQL, _ws_ano_sql_red, WS_ANO_SQL); _ws_ano_sql_red.ValueChanged += () => { _.Move(_ws_ano_sql_red, WS_ANO_SQL); }; return _ws_ano_sql_red; }
                set { VarBasis.RedefinePassValue(value, _ws_ano_sql_red, WS_ANO_SQL); }
            }  //Redefines
            public class _REDEF_CI0500S_WS_ANO_SQL_RED : VarBasis
            {
                /*"        10   WS-SEC-SQL-R          PIC  9(02).*/
                public IntBasis WS_SEC_SQL_R { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"        10   WS-ANO-SQL-R          PIC  9(02).*/
                public IntBasis WS_ANO_SQL_R { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      07     WS-BARRA1-SQL         PIC  X(001).*/

                public _REDEF_CI0500S_WS_ANO_SQL_RED()
                {
                    WS_SEC_SQL_R.ValueChanged += OnValueChanged;
                    WS_ANO_SQL_R.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_BARRA1_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      07     WS-MES-SQL            PIC  9(002).*/
            public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      07     WS-BARRA2-SQL         PIC  X(001).*/
            public StringBasis WS_BARRA2_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      07     WS-DIA-SQL            PIC  9(002).*/
            public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05            WABEND.*/
            public CI0500S_WABEND WABEND { get; set; } = new CI0500S_WABEND();
            public class CI0500S_WABEND : VarBasis
            {
                /*"    10          FILLER           PIC  X(008)      VALUE               'CI0500S '.*/
            }

            public _REDEF_CI0500S_WS_DATA_SQL_R()
            {
                WS_ANO_SQL.ValueChanged += OnValueChanged;
                WS_ANO_SQL_RED.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CI0500S ");
        /*"    10          FILLER           PIC  X(025)      VALUE               '*** ERRO EXEC SQL NUMERO '.*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
        /*"    10          WNR-EXEC-SQL     PIC  X(004)      VALUE   '0000'*/
        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
        /*"    10          FILLER           PIC  X(013)      VALUE               ' *** SQLCODE '.*/
        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
        /*"    10          WSQLCODE         PIC  ZZZZZ999-   VALUE    ZEROS*/
        public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        /*"  01        LK-AREA-LINK.*/
        public CI0500S_LK_AREA_LINK LK_AREA_LINK { get; set; } = new CI0500S_LK_AREA_LINK();
        public class CI0500S_LK_AREA_LINK : VarBasis
        {
            /*"    05      LK-COD-OPERACAO     PIC S9(04)       COMP.*/
            public IntBasis LK_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05      LK-COD-NATUREZA     PIC S9(04)       COMP.*/
            public IntBasis LK_COD_NATUREZA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05      LK-DTINIVIG         PIC S9(08)       COMP.*/
            public IntBasis LK_DTINIVIG { get; set; } = new IntBasis(new PIC("S9", "8", "S9(08)"));
            /*"    05      LK-NUM-APOLICE      PIC S9(13)       COMP-3.*/
            public IntBasis LK_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05      LK-COD-PRODUTO      PIC S9(04)       COMP.*/
            public IntBasis LK_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05      LK-COD-RAMO         PIC S9(04)       COMP.*/
            public IntBasis LK_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05      LK-COD-ERRO         PIC S9(04)       COMP.*/
            public IntBasis LK_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(CI0500S_LK_AREA_LINK CI0500S_LK_AREA_LINK_P) //PROCEDURE DIVISION USING 
        /*LK_AREA_LINK*/
        {
            try
            {
                this.LK_AREA_LINK = CI0500S_LK_AREA_LINK_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_AREA_LINK, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -128- PERFORM R1000-00-PROCESSAMENTO. */

            R1000_00_PROCESSAMENTO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -143- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R1000-00-PROCESSAMENTO-SECTION */
        private void R1000_00_PROCESSAMENTO_SECTION()
        {
            /*" -155- PERFORM R1460-00-SELEC-APOLICE. */

            R1460_00_SELEC_APOLICE_SECTION();

            /*" -156- IF LK-COD-ERRO EQUAL ZEROS */

            if (LK_AREA_LINK.LK_COD_ERRO == 00)
            {

                /*" -156- PERFORM R1480-00-LER-V0ENDOSSO. */

                R1480_00_LER_V0ENDOSSO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1460-00-SELEC-APOLICE-SECTION */
        private void R1460_00_SELEC_APOLICE_SECTION()
        {
            /*" -172- MOVE 0 TO LK-NUM-APOLICE LK-COD-ERRO LK-COD-PRODUTO LK-COD-RAMO */
            _.Move(0, LK_AREA_LINK.LK_NUM_APOLICE, LK_AREA_LINK.LK_COD_ERRO, LK_AREA_LINK.LK_COD_PRODUTO, LK_AREA_LINK.LK_COD_RAMO);

            /*" -175- IF LK-COD-OPERACAO EQUAL ZEROS OR LK-DTINIVIG < 19990101 OR LK-DTINIVIG > 20201231 */

            if (LK_AREA_LINK.LK_COD_OPERACAO == 00 || LK_AREA_LINK.LK_DTINIVIG.GetMoveValues().ToInt() < 19990101 || LK_AREA_LINK.LK_DTINIVIG.GetMoveValues().ToInt() > 20201231)
            {

                /*" -176- MOVE 1 TO LK-COD-ERRO */
                _.Move(1, LK_AREA_LINK.LK_COD_ERRO);

                /*" -177- DISPLAY 'CI0500S-ERRO OPERACAO OU DTINIVIG INVALIDA ' */
                _.Display($"CI0500S-ERRO OPERACAO OU DTINIVIG INVALIDA ");

                /*" -184- GO TO R1460-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1460_99_SAIDA*/ //GOTO
                return;
            }


            /*" -185- IF LK-DTINIVIG > 20050331 */

            if (LK_AREA_LINK.LK_DTINIVIG.GetMoveValues().ToInt() > 20050331)
            {

                /*" -186- PERFORM R1471-SELECIONA-APOLICE-2005 */

                R1471_SELECIONA_APOLICE_2005_SECTION();

                /*" -187- GO TO R1460-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1460_99_SAIDA*/ //GOTO
                return;

                /*" -192- END-IF. */
            }


            /*" -193- IF LK-DTINIVIG > 20040229 */

            if (LK_AREA_LINK.LK_DTINIVIG.GetMoveValues().ToInt() > 20040229)
            {

                /*" -194- PERFORM R1470-SELECIONA-APOLICE */

                R1470_SELECIONA_APOLICE_SECTION();

                /*" -196- GO TO R1460-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1460_99_SAIDA*/ //GOTO
                return;
            }


            /*" -197- IF LK-DTINIVIG < 19990912 */

            if (LK_AREA_LINK.LK_DTINIVIG.GetMoveValues().ToInt() < 19990912)
            {

                /*" -198- IF LK-COD-OPERACAO EQUAL ( 110 OR 111 ) */

                if (LK_AREA_LINK.LK_COD_OPERACAO.In("110", "111"))
                {

                    /*" -199- MOVE 104800000032 TO LK-NUM-APOLICE */
                    _.Move(104800000032, LK_AREA_LINK.LK_NUM_APOLICE);

                    /*" -200- ELSE */
                }
                else
                {


                    /*" -202- IF LK-COD-NATUREZA EQUAL 61 OR LK-COD-NATUREZA EQUAL 65 */

                    if (LK_AREA_LINK.LK_COD_NATUREZA == 61 || LK_AREA_LINK.LK_COD_NATUREZA == 65)
                    {

                        /*" -203- MOVE 104800000030 TO LK-NUM-APOLICE */
                        _.Move(104800000030, LK_AREA_LINK.LK_NUM_APOLICE);

                        /*" -204- ELSE */
                    }
                    else
                    {


                        /*" -205- MOVE 104800000029 TO LK-NUM-APOLICE */
                        _.Move(104800000029, LK_AREA_LINK.LK_NUM_APOLICE);

                        /*" -206- END-IF */
                    }


                    /*" -207- END-IF */
                }


                /*" -208- ELSE */
            }
            else
            {


                /*" -209- IF LK-COD-OPERACAO EQUAL 107 */

                if (LK_AREA_LINK.LK_COD_OPERACAO == 107)
                {

                    /*" -210- IF LK-DTINIVIG < 20020131 */

                    if (LK_AREA_LINK.LK_DTINIVIG.GetMoveValues().ToInt() < 20020131)
                    {

                        /*" -211- MOVE 104800000036 TO LK-NUM-APOLICE */
                        _.Move(104800000036, LK_AREA_LINK.LK_NUM_APOLICE);

                        /*" -212- ELSE */
                    }
                    else
                    {


                        /*" -213- MOVE 104800000048 TO LK-NUM-APOLICE */
                        _.Move(104800000048, LK_AREA_LINK.LK_NUM_APOLICE);

                        /*" -214- END-IF */
                    }


                    /*" -215- ELSE */
                }
                else
                {


                    /*" -216- IF LK-COD-OPERACAO EQUAL (171 OR 173 OR 174) */

                    if (LK_AREA_LINK.LK_COD_OPERACAO.In("171", "173", "174"))
                    {

                        /*" -217- IF LK-DTINIVIG < 20020208 */

                        if (LK_AREA_LINK.LK_DTINIVIG.GetMoveValues().ToInt() < 20020208)
                        {

                            /*" -218- MOVE 104800000039 TO LK-NUM-APOLICE */
                            _.Move(104800000039, LK_AREA_LINK.LK_NUM_APOLICE);

                            /*" -219- ELSE */
                        }
                        else
                        {


                            /*" -220- MOVE 104800000049 TO LK-NUM-APOLICE */
                            _.Move(104800000049, LK_AREA_LINK.LK_NUM_APOLICE);

                            /*" -221- END-IF */
                        }


                        /*" -222- ELSE */
                    }
                    else
                    {


                        /*" -223- IF LK-COD-OPERACAO EQUAL (181 OR 182) */

                        if (LK_AREA_LINK.LK_COD_OPERACAO.In("181", "182"))
                        {

                            /*" -224- MOVE 104800000038 TO LK-NUM-APOLICE */
                            _.Move(104800000038, LK_AREA_LINK.LK_NUM_APOLICE);

                            /*" -225- ELSE */
                        }
                        else
                        {


                            /*" -226- IF LK-COD-OPERACAO EQUAL 731 */

                            if (LK_AREA_LINK.LK_COD_OPERACAO == 731)
                            {

                                /*" -227- MOVE 104800000042 TO LK-NUM-APOLICE */
                                _.Move(104800000042, LK_AREA_LINK.LK_NUM_APOLICE);

                                /*" -228- ELSE */
                            }
                            else
                            {


                                /*" -229- IF LK-COD-OPERACAO EQUAL ( 110 OR 111 ) */

                                if (LK_AREA_LINK.LK_COD_OPERACAO.In("110", "111"))
                                {

                                    /*" -230- IF LK-DTINIVIG < 20000831 */

                                    if (LK_AREA_LINK.LK_DTINIVIG.GetMoveValues().ToInt() < 20000831)
                                    {

                                        /*" -231- MOVE 104800000032 TO LK-NUM-APOLICE */
                                        _.Move(104800000032, LK_AREA_LINK.LK_NUM_APOLICE);

                                        /*" -232- ELSE */
                                    }
                                    else
                                    {


                                        /*" -233- IF LK-DTINIVIG < 20020228 */

                                        if (LK_AREA_LINK.LK_DTINIVIG.GetMoveValues().ToInt() < 20020228)
                                        {

                                            /*" -234- MOVE 104800000044 TO LK-NUM-APOLICE */
                                            _.Move(104800000044, LK_AREA_LINK.LK_NUM_APOLICE);

                                            /*" -235- ELSE */
                                        }
                                        else
                                        {


                                            /*" -236- MOVE 104800000050 TO LK-NUM-APOLICE */
                                            _.Move(104800000050, LK_AREA_LINK.LK_NUM_APOLICE);

                                            /*" -237- END-IF */
                                        }


                                        /*" -238- END-IF */
                                    }


                                    /*" -239- ELSE */
                                }
                                else
                                {


                                    /*" -241- IF LK-COD-NATUREZA EQUAL 61 OR LK-COD-NATUREZA EQUAL 65 */

                                    if (LK_AREA_LINK.LK_COD_NATUREZA == 61 || LK_AREA_LINK.LK_COD_NATUREZA == 65)
                                    {

                                        /*" -242- IF LK-DTINIVIG < 20000913 */

                                        if (LK_AREA_LINK.LK_DTINIVIG.GetMoveValues().ToInt() < 20000913)
                                        {

                                            /*" -243- MOVE 104800000035 TO LK-NUM-APOLICE */
                                            _.Move(104800000035, LK_AREA_LINK.LK_NUM_APOLICE);

                                            /*" -244- ELSE */
                                        }
                                        else
                                        {


                                            /*" -245- IF LK-DTINIVIG < 20020412 */

                                            if (LK_AREA_LINK.LK_DTINIVIG.GetMoveValues().ToInt() < 20020412)
                                            {

                                                /*" -246- MOVE 104800000046 TO LK-NUM-APOLICE */
                                                _.Move(104800000046, LK_AREA_LINK.LK_NUM_APOLICE);

                                                /*" -247- ELSE */
                                            }
                                            else
                                            {


                                                /*" -248- MOVE 104800000051 TO LK-NUM-APOLICE */
                                                _.Move(104800000051, LK_AREA_LINK.LK_NUM_APOLICE);

                                                /*" -249- END-IF */
                                            }


                                            /*" -250- END-IF */
                                        }


                                        /*" -251- ELSE */
                                    }
                                    else
                                    {


                                        /*" -252- IF LK-DTINIVIG < 20000913 */

                                        if (LK_AREA_LINK.LK_DTINIVIG.GetMoveValues().ToInt() < 20000913)
                                        {

                                            /*" -253- MOVE 104800000034 TO LK-NUM-APOLICE */
                                            _.Move(104800000034, LK_AREA_LINK.LK_NUM_APOLICE);

                                            /*" -254- ELSE */
                                        }
                                        else
                                        {


                                            /*" -255- MOVE 104800000045 TO LK-NUM-APOLICE */
                                            _.Move(104800000045, LK_AREA_LINK.LK_NUM_APOLICE);

                                            /*" -256- END-IF */
                                        }


                                        /*" -256- END-IF. */
                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1460_99_SAIDA*/

        [StopWatch]
        /*" R1470-SELECIONA-APOLICE-SECTION */
        private void R1470_SELECIONA_APOLICE_SECTION()
        {
            /*" -271- IF LK-COD-OPERACAO EQUAL 701 OR 702 OR 703 OR 704 OR 649 OR 650 OR 652 OR 653 OR 731 OR 690 OR 691 */

            if (LK_AREA_LINK.LK_COD_OPERACAO.In("701", "702", "703", "704", "649", "650", "652", "653", "731", "690", "691"))
            {

                /*" -272- MOVE 106000000001 TO LK-NUM-APOLICE */
                _.Move(106000000001, LK_AREA_LINK.LK_NUM_APOLICE);

                /*" -273- ELSE */
            }
            else
            {


                /*" -273- MOVE 107000000002 TO LK-NUM-APOLICE . */
                _.Move(107000000002, LK_AREA_LINK.LK_NUM_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1470_99_EXIT*/

        [StopWatch]
        /*" R1471-SELECIONA-APOLICE-2005-SECTION */
        private void R1471_SELECIONA_APOLICE_2005_SECTION()
        {
            /*" -290- IF LK-COD-OPERACAO EQUAL 701 OR 702 OR 703 OR 704 OR 649 OR 650 OR 652 OR 653 OR 731 OR 690 OR 691 */

            if (LK_AREA_LINK.LK_COD_OPERACAO.In("701", "702", "703", "704", "649", "650", "652", "653", "731", "690", "691"))
            {

                /*" -291- MOVE 0106000000002 TO LK-NUM-APOLICE */
                _.Move(0106000000002, LK_AREA_LINK.LK_NUM_APOLICE);

                /*" -292- ELSE */
            }
            else
            {


                /*" -293- MOVE 0107000000005 TO LK-NUM-APOLICE */
                _.Move(0107000000005, LK_AREA_LINK.LK_NUM_APOLICE);

                /*" -293- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1471_99_EXIT*/

        [StopWatch]
        /*" R1480-00-LER-V0ENDOSSO-SECTION */
        private void R1480_00_LER_V0ENDOSSO_SECTION()
        {
            /*" -304- MOVE '1480' TO WNR-EXEC-SQL. */
            _.Move("1480", WNR_EXEC_SQL);

            /*" -316- PERFORM R1480_00_LER_V0ENDOSSO_DB_SELECT_1 */

            R1480_00_LER_V0ENDOSSO_DB_SELECT_1();

            /*" -319- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -320- DISPLAY 'R1480-PROBLEMA NO SELECT DA V0ENDOSSO' */
                _.Display($"R1480-PROBLEMA NO SELECT DA V0ENDOSSO");

                /*" -320- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1480-00-LER-V0ENDOSSO-DB-SELECT-1 */
        public void R1480_00_LER_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -316- EXEC SQL SELECT CODPRODU ,RAMO INTO :LK-COD-PRODUTO ,:LK-COD-RAMO FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :LK-NUM-APOLICE AND NRENDOS = 0 END-EXEC. */

            var r1480_00_LER_V0ENDOSSO_DB_SELECT_1_Query1 = new R1480_00_LER_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                LK_NUM_APOLICE = LK_AREA_LINK.LK_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1480_00_LER_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r1480_00_LER_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_COD_PRODUTO, LK_AREA_LINK.LK_COD_PRODUTO);
                _.Move(executed_1.LK_COD_RAMO, LK_AREA_LINK.LK_COD_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1480_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -332- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WSQLCODE);

            /*" -334- DISPLAY WABEND */
            _.Display(WS_DATA_SQL_R.WABEND);

            /*" -334- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -336- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -340- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -340- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}