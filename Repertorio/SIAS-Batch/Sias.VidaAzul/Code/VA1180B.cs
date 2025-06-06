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
using Sias.VidaAzul.DB2.VA1180B;

namespace Code
{
    public class VA1180B
    {
        public bool IsCall { get; set; }

        public VA1180B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   GERA OS PEDIDOS DE COMPRA DE TITULOS DE CAPITALIZACAO DA     *      */
        /*"      *   FEDERALCAP NA V0MOVFDCAPVA PARA OS TITULOS VENCIDOS DA ICATU.*      */
        /*"      *                                                                *      */
        /*"      *   PRODUTOS TRADICIONAL, MASTER E PREMIADO.                     *      */
        /*"      *                                                                *      */
        /*"      *   DATA DE CRIACAO.      31.10.2000                             *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR. FREDERICO FONSECA.                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  AREA-WORK.*/
        public VA1180B_AREA_WORK AREA_WORK { get; set; } = new VA1180B_AREA_WORK();
        public class VA1180B_AREA_WORK : VarBasis
        {
            /*"  05 W01DTSQL                   PIC X(010).*/
            public StringBasis W01DTSQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05 W01DTSQL-R                 REDEFINES     W01DTSQL.*/
            private _REDEF_VA1180B_W01DTSQL_R _w01dtsql_r { get; set; }
            public _REDEF_VA1180B_W01DTSQL_R W01DTSQL_R
            {
                get { _w01dtsql_r = new _REDEF_VA1180B_W01DTSQL_R(); _.Move(W01DTSQL, _w01dtsql_r); VarBasis.RedefinePassValue(W01DTSQL, _w01dtsql_r, W01DTSQL); _w01dtsql_r.ValueChanged += () => { _.Move(_w01dtsql_r, W01DTSQL); }; return _w01dtsql_r; }
                set { VarBasis.RedefinePassValue(value, _w01dtsql_r, W01DTSQL); }
            }  //Redefines
            public class _REDEF_VA1180B_W01DTSQL_R : VarBasis
            {
                /*"     10 W01AASQL                PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10 FILLER                  PIC X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10 W01MMSQL                PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10 FILLER                  PIC X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10 W01DDSQL                PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05 W02DTSQL                   PIC X(010).*/

                public _REDEF_VA1180B_W01DTSQL_R()
                {
                    W01AASQL.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                    W01MMSQL.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    W01DDSQL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W02DTSQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05 W02DTSQL-R                 REDEFINES     W02DTSQL.*/
            private _REDEF_VA1180B_W02DTSQL_R _w02dtsql_r { get; set; }
            public _REDEF_VA1180B_W02DTSQL_R W02DTSQL_R
            {
                get { _w02dtsql_r = new _REDEF_VA1180B_W02DTSQL_R(); _.Move(W02DTSQL, _w02dtsql_r); VarBasis.RedefinePassValue(W02DTSQL, _w02dtsql_r, W02DTSQL); _w02dtsql_r.ValueChanged += () => { _.Move(_w02dtsql_r, W02DTSQL); }; return _w02dtsql_r; }
                set { VarBasis.RedefinePassValue(value, _w02dtsql_r, W02DTSQL); }
            }  //Redefines
            public class _REDEF_VA1180B_W02DTSQL_R : VarBasis
            {
                /*"     10 W02AASQL                PIC 9(004).*/
                public IntBasis W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10 FILLER                  PIC X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10 W02MMSQL                PIC 9(002).*/
                public IntBasis W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10 FILLER                  PIC X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10 W02DDSQL                PIC 9(002).*/
                public IntBasis W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05 W99MMSQL                   PIC S9(02).*/

                public _REDEF_VA1180B_W02DTSQL_R()
                {
                    W02AASQL.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    W02MMSQL.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    W02DDSQL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W99MMSQL { get; set; } = new IntBasis(new PIC("S9", "2", "S9(02)."));
            /*"  05 QUOCIENTE                  PIC  9(04) VALUE ZEROS.*/
            public IntBasis QUOCIENTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"  05 RESTO                      PIC  9(04) VALUE ZEROS.*/
            public IntBasis RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"  05 WS-EOF                     PIC 9(001) VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05 AC-GRAVADOS                PIC 9(006) VALUE 0.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05       TABELA-ULTIMOS-DIAS.*/
            public VA1180B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VA1180B_TABELA_ULTIMOS_DIAS();
            public class VA1180B_TABELA_ULTIMOS_DIAS : VarBasis
            {
                /*"       07  FILLER               PIC  X(024)           VALUE '312831303130313130313031'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
                /*"  05       TAB-ULTIMOS-DIAS     REDEFINES           TABELA-ULTIMOS-DIAS.*/
            }
            private _REDEF_VA1180B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
            public _REDEF_VA1180B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
            {
                get { _tab_ultimos_dias = new _REDEF_VA1180B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
                set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
            }  //Redefines
            public class _REDEF_VA1180B_TAB_ULTIMOS_DIAS : VarBasis
            {
                /*"       07  TAB-DIA-MESES        OCCURS 12.*/
                public ListBasis<VA1180B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VA1180B_TAB_DIA_MESES>(12);
                public class VA1180B_TAB_DIA_MESES : VarBasis
                {
                    /*"           10 TAB-ULT-DIA       PIC 9(002).*/
                    public IntBasis TAB_ULT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"  05        WABEND.*/

                    public VA1180B_TAB_DIA_MESES()
                    {
                        TAB_ULT_DIA.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VA1180B_TAB_ULTIMOS_DIAS()
                {
                    TAB_DIA_MESES.ValueChanged += OnValueChanged;
                }

            }
            public VA1180B_WABEND WABEND { get; set; } = new VA1180B_WABEND();
            public class VA1180B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(009) VALUE           'VA1180B '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"VA1180B ");
                /*"    10      FILLER              PIC  X(035) VALUE           ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.TITFEDCA TITFEDCA { get; set; } = new Dclgens.TITFEDCA();
        public Dclgens.MOVFEDCA MOVFEDCA { get; set; } = new Dclgens.MOVFEDCA();
        public Dclgens.TCAPITVG TCAPITVG { get; set; } = new Dclgens.TCAPITVG();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public VA1180B_CMVFDCAP CMVFDCAP { get; set; } = new VA1180B_CMVFDCAP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -102- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -105- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

                /*" -108- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -108- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -117- MOVE '9999' TO WNR-EXEC-SQL. */
            _.Move("9999", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -125- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -129- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -130- DISPLAY ' ERRO ACESSO SISTEMAS  ' */
                _.Display($" ERRO ACESSO SISTEMAS  ");

                /*" -132- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -134- MOVE SISTEMAS-DATA-MOV-ABERTO TO W01DTSQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_WORK.W01DTSQL);

            /*" -136- MOVE TAB-ULT-DIA(W01MMSQL) TO W01DDSQL. */
            _.Move(AREA_WORK.TAB_ULTIMOS_DIAS.TAB_DIA_MESES[AREA_WORK.W01DTSQL_R.W01MMSQL].TAB_ULT_DIA, AREA_WORK.W01DTSQL_R.W01DDSQL);

            /*" -137- IF W01MMSQL = 02 */

            if (AREA_WORK.W01DTSQL_R.W01MMSQL == 02)
            {

                /*" -138- DIVIDE W01AASQL BY 4 GIVING QUOCIENTE REMAINDER RESTO */
                _.Divide(AREA_WORK.W01DTSQL_R.W01AASQL, 4, AREA_WORK.QUOCIENTE, AREA_WORK.RESTO);

                /*" -139- IF RESTO = ZEROS */

                if (AREA_WORK.RESTO == 00)
                {

                    /*" -141- COMPUTE W01DDSQL = W01DDSQL + 1. */
                    AREA_WORK.W01DTSQL_R.W01DDSQL.Value = AREA_WORK.W01DTSQL_R.W01DDSQL + 1;
                }

            }


            /*" -143- DISPLAY '*** PROCESSANDO MOVIMENTO DE  ' W01DTSQL. */
            _.Display($"*** PROCESSANDO MOVIMENTO DE  {AREA_WORK.W01DTSQL}");

            /*" -145- MOVE '9998' TO WNR-EXEC-SQL. */
            _.Move("9998", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -154- PERFORM R0000_00_PRINCIPAL_DB_SELECT_2 */

            R0000_00_PRINCIPAL_DB_SELECT_2();

            /*" -158- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -159- DISPLAY ' ERRO ACESSO PRODUTOS_VG ' */
                _.Display($" ERRO ACESSO PRODUTOS_VG ");

                /*" -162- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -164- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -177- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -180- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -180- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -183- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -185- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -187- PERFORM R0110-00-FETCH. */

            R0110_00_FETCH_SECTION();

            /*" -188- IF WS-EOF = 1 */

            if (AREA_WORK.WS_EOF == 1)
            {

                /*" -189- DISPLAY '*** VA1180B *** NENHUMA PARCELA ENCONTRADA' */
                _.Display($"*** VA1180B *** NENHUMA PARCELA ENCONTRADA");

                /*" -191- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -194- PERFORM R0100-00-GERA-MOVIMENTO UNTIL WS-EOF = 1. */

            while (!(AREA_WORK.WS_EOF == 1))
            {

                R0100_00_GERA_MOVIMENTO_SECTION();
            }

            /*" -196- MOVE '0008' TO WNR-EXEC-SQL. */
            _.Move("0008", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -196- PERFORM R0000_00_PRINCIPAL_DB_CLOSE_1 */

            R0000_00_PRINCIPAL_DB_CLOSE_1();

            /*" -199- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -201- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -203- MOVE '0009' TO WNR-EXEC-SQL. */
            _.Move("0009", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -203- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -206- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -208- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -209- DISPLAY '*** VA1180B *** GRAVADOS       ' AC-GRAVADOS. */
            _.Display($"*** VA1180B *** GRAVADOS       {AREA_WORK.AC_GRAVADOS}");

            /*" -211- DISPLAY '*** VA1180B *** TERMINO NORMAL' . */
            _.Display($"*** VA1180B *** TERMINO NORMAL");

            /*" -213- MOVE ZEROES TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -213- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -125- EXEC SQL SELECT CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }

        [StopWatch]
        /*" R0100-00-GERA-MOVIMENTO-SECTION */
        private void R0100_00_GERA_MOVIMENTO_SECTION()
        {
            /*" -218- PERFORM R0250-00-PESQUISA-SEGURADO */

            R0250_00_PESQUISA_SEGURADO_SECTION();

            /*" -219- IF SEGURVGA-SIT-REGISTRO NOT EQUAL '0' AND '1' */

            if (!SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO.In("0", "1"))
            {

                /*" -221- GO TO R0100-00-NEXT. */

                R0100_00_NEXT(); //GOTO
                return;
            }


            /*" -223- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -233- PERFORM R0100_00_GERA_MOVIMENTO_DB_SELECT_1 */

            R0100_00_GERA_MOVIMENTO_DB_SELECT_1();

            /*" -236- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -237- DISPLAY ' NAO ACHEI COBERPROPVA ' PROPOVA-NUM-CERTIFICADO */
                _.Display($" NAO ACHEI COBERPROPVA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -239- GO TO R0100-00-NEXT. */

                R0100_00_NEXT(); //GOTO
                return;
            }


            /*" -240- IF HISCOBPR-QTDE-TIT-CAPITALIZ EQUAL ZEROES */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ == 00)
            {

                /*" -244- GO TO R0100-00-NEXT. */

                R0100_00_NEXT(); //GOTO
                return;
            }


            /*" -246- MOVE '0102' TO WNR-EXEC-SQL. */
            _.Move("0102", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -254- PERFORM R0100_00_GERA_MOVIMENTO_DB_SELECT_2 */

            R0100_00_GERA_MOVIMENTO_DB_SELECT_2();

            /*" -257- IF MOVFEDCA-QUANT-TIT-CAPITALI GREATER ZEROS */

            if (MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_QUANT_TIT_CAPITALI > 00)
            {

                /*" -259- GO TO R0100-00-NEXT. */

                R0100_00_NEXT(); //GOTO
                return;
            }


            /*" -261- MOVE '0103' TO WNR-EXEC-SQL. */
            _.Move("0103", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -266- PERFORM R0100_00_GERA_MOVIMENTO_DB_SELECT_3 */

            R0100_00_GERA_MOVIMENTO_DB_SELECT_3();

            /*" -269- IF MOVFEDCA-QUANT-TIT-CAPITALI GREATER ZEROS */

            if (MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_QUANT_TIT_CAPITALI > 00)
            {

                /*" -271- GO TO R0100-00-NEXT. */

                R0100_00_NEXT(); //GOTO
                return;
            }


            /*" -273- MOVE '0104' TO WNR-EXEC-SQL. */
            _.Move("0104", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -278- PERFORM R0100_00_GERA_MOVIMENTO_DB_SELECT_4 */

            R0100_00_GERA_MOVIMENTO_DB_SELECT_4();

            /*" -281- IF TCAPITVG-DATA-TERVIGENCIA GREATER W01DTSQL */

            if (TCAPITVG.DCLTIT_CAPITALIZ_VG.TCAPITVG_DATA_TERVIGENCIA > AREA_WORK.W01DTSQL)
            {

                /*" -283- GO TO R0100-00-NEXT. */

                R0100_00_NEXT(); //GOTO
                return;
            }


            /*" -283- PERFORM R1000-00-GRAVA-MOVIMENTO. */

            R1000_00_GRAVA_MOVIMENTO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0100_00_NEXT */

            R0100_00_NEXT();

        }

        [StopWatch]
        /*" R0100-00-GERA-MOVIMENTO-DB-SELECT-1 */
        public void R0100_00_GERA_MOVIMENTO_DB_SELECT_1()
        {
            /*" -233- EXEC SQL SELECT QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ, VLPREMIO INTO :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1 = new R0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1.Execute(r0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_QTDE_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VAL_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -177- EXEC SQL DECLARE CMVFDCAP CURSOR FOR SELECT NUM_CERTIFICADO, COD_PRODUTO, NUM_APOLICE, COD_SUBGRUPO, NUM_PARCELA FROM SEGUROS.PROPOSTAS_VA WHERE NUM_APOLICE = 97010000889 AND COD_SUBGRUPO IN (0001, 1948, 1951) AND SIT_REGISTRO IN ( '3' , '6' ) END-EXEC. */
            CMVFDCAP = new VA1180B_CMVFDCAP(false);
            string GetQuery_CMVFDCAP()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							COD_PRODUTO
							, 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_PARCELA 
							FROM 
							SEGUROS.PROPOSTAS_VA 
							WHERE 
							NUM_APOLICE = 97010000889 
							AND COD_SUBGRUPO IN (0001
							, 1948
							, 1951) 
							AND SIT_REGISTRO IN ( '3'
							, '6' )";

                return query;
            }
            CMVFDCAP.GetQueryEvent += GetQuery_CMVFDCAP;

        }

        [StopWatch]
        /*" R0100-00-GERA-MOVIMENTO-DB-SELECT-2 */
        public void R0100_00_GERA_MOVIMENTO_DB_SELECT_2()
        {
            /*" -254- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :MOVFEDCA-QUANT-TIT-CAPITALI FROM SEGUROS.TITULOS_FED_CAP_VA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_INIVIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND DATA_TERVIGENCIA >= :SISTEMAS-DATA-MOV-ABERTO AND SITUACAO = '0' END-EXEC. */

            var r0100_00_GERA_MOVIMENTO_DB_SELECT_2_Query1 = new R0100_00_GERA_MOVIMENTO_DB_SELECT_2_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0100_00_GERA_MOVIMENTO_DB_SELECT_2_Query1.Execute(r0100_00_GERA_MOVIMENTO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVFEDCA_QUANT_TIT_CAPITALI, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_QUANT_TIT_CAPITALI);
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -180- EXEC SQL OPEN CMVFDCAP END-EXEC. */

            CMVFDCAP.Open();

        }

        [StopWatch]
        /*" R0100-00-GERA-MOVIMENTO-DB-SELECT-3 */
        public void R0100_00_GERA_MOVIMENTO_DB_SELECT_3()
        {
            /*" -266- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :MOVFEDCA-QUANT-TIT-CAPITALI FROM SEGUROS.MOVIMEN_FED_CAP_VA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1 = new R0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1.Execute(r0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVFEDCA_QUANT_TIT_CAPITALI, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_QUANT_TIT_CAPITALI);
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-CLOSE-1 */
        public void R0000_00_PRINCIPAL_DB_CLOSE_1()
        {
            /*" -196- EXEC SQL CLOSE CMVFDCAP END-EXEC. */

            CMVFDCAP.Close();

        }

        [StopWatch]
        /*" R0100-00-GERA-MOVIMENTO-DB-SELECT-4 */
        public void R0100_00_GERA_MOVIMENTO_DB_SELECT_4()
        {
            /*" -278- EXEC SQL SELECT VALUE(MAX(DATA_TERVIGENCIA), DATE( '9999-12-31' )) INTO :TCAPITVG-DATA-TERVIGENCIA FROM SEGUROS.TIT_CAPITALIZ_VG WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r0100_00_GERA_MOVIMENTO_DB_SELECT_4_Query1 = new R0100_00_GERA_MOVIMENTO_DB_SELECT_4_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0100_00_GERA_MOVIMENTO_DB_SELECT_4_Query1.Execute(r0100_00_GERA_MOVIMENTO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TCAPITVG_DATA_TERVIGENCIA, TCAPITVG.DCLTIT_CAPITALIZ_VG.TCAPITVG_DATA_TERVIGENCIA);
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-2 */
        public void R0000_00_PRINCIPAL_DB_SELECT_2()
        {
            /*" -154- EXEC SQL SELECT DTMVFDCAP INTO :PRODUVG-DTMVFDCAP FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = 97010000889 AND COD_SUBGRUPO = 3603 END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_2_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_2_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_DTMVFDCAP, PRODUVG.DCLPRODUTOS_VG.PRODUVG_DTMVFDCAP);
            }


        }

        [StopWatch]
        /*" R0100-00-NEXT */
        private void R0100_00_NEXT(bool isPerform = false)
        {
            /*" -287- PERFORM R0110-00-FETCH. */

            R0110_00_FETCH_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-FETCH-SECTION */
        private void R0110_00_FETCH_SECTION()
        {
            /*" -295- MOVE '0110' TO WNR-EXEC-SQL. */
            _.Move("0110", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -302- PERFORM R0110_00_FETCH_DB_FETCH_1 */

            R0110_00_FETCH_DB_FETCH_1();

            /*" -305- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -305- MOVE 1 TO WS-EOF. */
                _.Move(1, AREA_WORK.WS_EOF);
            }


        }

        [StopWatch]
        /*" R0110-00-FETCH-DB-FETCH-1 */
        public void R0110_00_FETCH_DB_FETCH_1()
        {
            /*" -302- EXEC SQL FETCH CMVFDCAP INTO :PROPOVA-NUM-CERTIFICADO, :PROPOVA-COD-PRODUTO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-NUM-PARCELA END-EXEC. */

            if (CMVFDCAP.Fetch())
            {
                _.Move(CMVFDCAP.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CMVFDCAP.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(CMVFDCAP.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CMVFDCAP.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CMVFDCAP.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-PESQUISA-SEGURADO-SECTION */
        private void R0250_00_PESQUISA_SEGURADO_SECTION()
        {
            /*" -317- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -323- PERFORM R0250_00_PESQUISA_SEGURADO_DB_SELECT_1 */

            R0250_00_PESQUISA_SEGURADO_DB_SELECT_1();

            /*" -326- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -328- DISPLAY 'CERTIFICADO ' PROPOVA-NUM-CERTIFICADO ' NAO ENCONTRADO NA SEGURAVG. SERA PULADO.' */

                $"CERTIFICADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} NAO ENCONTRADO NA SEGURAVG. SERA PULADO."
                .Display();

                /*" -328- MOVE '2' TO SEGURVGA-SIT-REGISTRO. */
                _.Move("2", SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO);
            }


        }

        [StopWatch]
        /*" R0250-00-PESQUISA-SEGURADO-DB-SELECT-1 */
        public void R0250_00_PESQUISA_SEGURADO_DB_SELECT_1()
        {
            /*" -323- EXEC SQL SELECT SIT_REGISTRO INTO :SEGURVGA-SIT-REGISTRO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC. */

            var r0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1 = new R0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1.Execute(r0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_SIT_REGISTRO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-GRAVA-MOVIMENTO-SECTION */
        private void R1000_00_GRAVA_MOVIMENTO_SECTION()
        {
            /*" -339- MOVE 1 TO MOVFEDCA-COD-OPERACAO. */
            _.Move(1, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_COD_OPERACAO);

            /*" -342- MOVE HISCOBPR-QTDE-TIT-CAPITALIZ TO MOVFEDCA-QUANT-TIT-CAPITALI. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_QUANT_TIT_CAPITALI);

            /*" -345- COMPUTE MOVFEDCA-VAL-CUSTO-CAPITALI = HISCOBPR-QTDE-TIT-CAPITALIZ * HISCOBPR-VAL-TIT-CAPITALIZ. */
            MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_VAL_CUSTO_CAPITALI.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ * HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ;

            /*" -347- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -377- PERFORM R1000_00_GRAVA_MOVIMENTO_DB_INSERT_1 */

            R1000_00_GRAVA_MOVIMENTO_DB_INSERT_1();

            /*" -380- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -382- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -382- ADD 1 TO AC-GRAVADOS. */
            AREA_WORK.AC_GRAVADOS.Value = AREA_WORK.AC_GRAVADOS + 1;

        }

        [StopWatch]
        /*" R1000-00-GRAVA-MOVIMENTO-DB-INSERT-1 */
        public void R1000_00_GRAVA_MOVIMENTO_DB_INSERT_1()
        {
            /*" -377- EXEC SQL INSERT INTO SEGUROS.MOVIMEN_FED_CAP_VA ( NUM_CERTIFICADO, COD_OPERACAO, COD_FONTE, NUM_PROPOSTA, DTMVFDCAP, NUM_PARCELA, QUANT_TIT_CAPITALI, VAL_CUSTO_CAPITALI, SITUACAO, NRTITFDCAP, NRMSCAP, NUM_SEQUENCIA, TIMESTAMP, CODPRODU) VALUES (:PROPOVA-NUM-CERTIFICADO, :MOVFEDCA-COD-OPERACAO, 0, 0, :PRODUVG-DTMVFDCAP, :PROPOVA-NUM-PARCELA, :MOVFEDCA-QUANT-TIT-CAPITALI, :MOVFEDCA-VAL-CUSTO-CAPITALI, '0' , 0, 0, 0, CURRENT TIMESTAMP, :PROPOVA-COD-PRODUTO) END-EXEC. */

            var r1000_00_GRAVA_MOVIMENTO_DB_INSERT_1_Insert1 = new R1000_00_GRAVA_MOVIMENTO_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                MOVFEDCA_COD_OPERACAO = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_COD_OPERACAO.ToString(),
                PRODUVG_DTMVFDCAP = PRODUVG.DCLPRODUTOS_VG.PRODUVG_DTMVFDCAP.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
                MOVFEDCA_QUANT_TIT_CAPITALI = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_QUANT_TIT_CAPITALI.ToString(),
                MOVFEDCA_VAL_CUSTO_CAPITALI = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_VAL_CUSTO_CAPITALI.ToString(),
                PROPOVA_COD_PRODUTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.ToString(),
            };

            R1000_00_GRAVA_MOVIMENTO_DB_INSERT_1_Insert1.Execute(r1000_00_GRAVA_MOVIMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -389- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_WORK.WABEND.WSQLCODE);

            /*" -390- DISPLAY WABEND. */
            _.Display(AREA_WORK.WABEND);

            /*" -391- DISPLAY ' ' . */
            _.Display($" ");

            /*" -393- DISPLAY 'CERTIFICADO ' PROPOVA-NUM-CERTIFICADO. */
            _.Display($"CERTIFICADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -394- MOVE '9999' TO WNR-EXEC-SQL. */
            _.Move("9999", AREA_WORK.WABEND.WNR_EXEC_SQL);

            /*" -394- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -396- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -399- DISPLAY '*** VA1180B *** TERMINO ANORMAL' . */
            _.Display($"*** VA1180B *** TERMINO ANORMAL");

            /*" -400- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -400- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}