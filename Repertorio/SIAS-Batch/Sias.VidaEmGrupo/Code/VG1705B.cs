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
using Sias.VidaEmGrupo.DB2.VG1705B;

namespace Code
{
    public class VG1705B
    {
        public bool IsCall { get; set; }

        public VG1705B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *   CALCULA E GRAVA COMISSOES DE AGENCIAMENTO PARA AS APOLICES   *      */
        /*"      *   ESPECIFICAS DOS RAMOS 81, 93 , 97 , 82 , 77.                 *      */
        /*"      *                                                                *      */
        /*"      *   DATA.  12/04/2001.                                           *      */
        /*"      *                                                                *      */
        /*"      *   AUTOR. FREDERICO FONSECA.                                    *      */
        /*"      *                                                                *      */
        /*"      *                                                   PPVGD05      *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01 ENDOSSOS-AGE-PRODUTORA        PIC S9(004)     COMP.*/
        public IntBasis ENDOSSOS_AGE_PRODUTORA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 WTOT-PRM-AP                   PIC S9(013)V99  COMP-3                                 VALUE ZEROS.*/
        public DoubleBasis WTOT_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WPRM-AP                       PIC S9(013)V99  COMP-3                                 VALUE ZEROS.*/
        public DoubleBasis WPRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WPRM-AP82                     PIC S9(013)V99  COMP-3                                 VALUE ZEROS.*/
        public DoubleBasis WPRM_AP82 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WTOT-PRM-VG                   PIC S9(013)V99  COMP-3                                 VALUE ZEROS.*/
        public DoubleBasis WTOT_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WPRM-VG                       PIC S9(013)V99  COMP-3                                 VALUE ZEROS.*/
        public DoubleBasis WPRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WPRM-VG77                     PIC S9(013)V99  COMP-3                                 VALUE ZEROS.*/
        public DoubleBasis WPRM_VG77 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WPRM-TT                       PIC S9(013)V99  COMP-3                                 VALUE ZEROS.*/
        public DoubleBasis WPRM_TT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WCONT-PARCELAS                PIC  9(009) VALUE ZEROS.*/
        public IntBasis WCONT_PARCELAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01           AREA-DE-WORK.*/
        public VG1705B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG1705B_AREA_DE_WORK();
        public class VG1705B_AREA_DE_WORK : VarBasis
        {
            /*"    05       WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05       WFIM-AGENCTOAPOL   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_AGENCTOAPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05       WFIM-V0COMISSAO    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0COMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05       WFIM-V0PLANCOMISVF PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0PLANCOMISVF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05       WFIM-FATURAS       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_FATURAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05       AC-L-AGENCTOAPOL  PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_AGENCTOAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       AC-I-COMISSAO     PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_COMISSAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       AC-I-AGENCIAMENTO PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_AGENCIAMENTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       AC-I-FUNDAO       PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_FUNDAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05       FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VG1705B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VG1705B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VG1705B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VG1705B_FILLER_0 : VarBasis
            {
                /*"      10     WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       WDAT-REL-LIT.*/

                public _REDEF_VG1705B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG1705B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VG1705B_WDAT_REL_LIT();
            public class VG1705B_WDAT_REL_LIT : VarBasis
            {
                /*"      10     WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10     FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10     WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10     FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10     WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05       WTIME-DAY         PIC  99999999.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99999999."));
            /*"    05       WTIME-DAY1        REDEFINES      WTIME-DAY.*/
            private _REDEF_VG1705B_WTIME_DAY1 _wtime_day1 { get; set; }
            public _REDEF_VG1705B_WTIME_DAY1 WTIME_DAY1
            {
                get { _wtime_day1 = new _REDEF_VG1705B_WTIME_DAY1(); _.Move(WTIME_DAY, _wtime_day1); VarBasis.RedefinePassValue(WTIME_DAY, _wtime_day1, WTIME_DAY); _wtime_day1.ValueChanged += () => { _.Move(_wtime_day1, WTIME_DAY); }; return _wtime_day1; }
                set { VarBasis.RedefinePassValue(value, _wtime_day1, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VG1705B_WTIME_DAY1 : VarBasis
            {
                /*"      10     WTIME-HORA        PIC  X(002).*/
                public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10     WTIME-MINU        PIC  X(002).*/
                public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10     WTIME-SEGU        PIC  X(002).*/
                public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10     WTIME-CCCC        PIC  X(002).*/
                public StringBasis WTIME_CCCC { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05       WTIME-DAYR.*/

                public _REDEF_VG1705B_WTIME_DAY1()
                {
                    WTIME_HORA.ValueChanged += OnValueChanged;
                    WTIME_MINU.ValueChanged += OnValueChanged;
                    WTIME_SEGU.ValueChanged += OnValueChanged;
                    WTIME_CCCC.ValueChanged += OnValueChanged;
                }

            }
            public VG1705B_WTIME_DAYR WTIME_DAYR { get; set; } = new VG1705B_WTIME_DAYR();
            public class VG1705B_WTIME_DAYR : VarBasis
            {
                /*"      10     WTIME-HORA        PIC  X(002).*/
                public StringBasis WTIME_HORA_0 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10     FILLER            PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"      10     WTIME-MINU        PIC  X(002).*/
                public StringBasis WTIME_MINU_0 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10     FILLER            PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"      10     WTIME-SEGU        PIC  X(002).*/
                public StringBasis WTIME_SEGU_0 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05      WABEND.*/
            }
            public VG1705B_WABEND WABEND { get; set; } = new VG1705B_WABEND();
            public class VG1705B_WABEND : VarBasis
            {
                /*"      10    FILLER              PIC  X(010) VALUE           ' VG1705B'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG1705B");
                /*"      10    FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10    WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"      10    FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10    WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.AGEAPOVG AGEAPOVG { get; set; } = new Dclgens.AGEAPOVG();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.COMISSOE COMISSOE { get; set; } = new Dclgens.COMISSOE();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.FATURAS FATURAS { get; set; } = new Dclgens.FATURAS();
        public Dclgens.FUNCOMVA FUNCOMVA { get; set; } = new Dclgens.FUNCOMVA();
        public Dclgens.MOEDACOT MOEDACOT { get; set; } = new Dclgens.MOEDACOT();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public VG1705B_AGENCTOAPOL AGENCTOAPOL { get; set; } = new VG1705B_AGENCTOAPOL();
        public VG1705B_FATURASC FATURASC { get; set; } = new VG1705B_FATURASC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-INICIO */

                M_0000_INICIO();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-INICIO */
        private void M_0000_INICIO(bool isPerform = false)
        {
            /*" -133- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -134- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -137- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -140- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -148- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -153- PERFORM M_0000_INICIO_DB_SELECT_1 */

            M_0000_INICIO_DB_SELECT_1();

            /*" -156- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -157- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -158- DISPLAY '*** VG1705B *** SISTEMA CO NAO CADASTRADO' */
                    _.Display($"*** VG1705B *** SISTEMA CO NAO CADASTRADO");

                    /*" -159- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -160- ELSE */
                }
                else
                {


                    /*" -166- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -168- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -188- PERFORM M_0000_INICIO_DB_DECLARE_1 */

            M_0000_INICIO_DB_DECLARE_1();

            /*" -192- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -193- DISPLAY '*** VG1705B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VG1705B *** ABRINDO CURSOR ...");

            /*" -193- PERFORM M_0000_INICIO_DB_OPEN_1 */

            M_0000_INICIO_DB_OPEN_1();

            /*" -197- PERFORM 1100-FETCH THRU 1100-FIM. */

            M_1100_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


            /*" -198- IF WFIM-AGENCTOAPOL EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_AGENCTOAPOL == "S")
            {

                /*" -199- PERFORM M-9000-ENCERRA-SEM-MOVTO THRU 9000-FIM */

                M_9000_ENCERRA_SEM_MOVTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


                /*" -201- GO TO 0002-FINALIZA. */

                M_0002_FINALIZA(); //GOTO
                return;
            }


            /*" -202- DISPLAY '*** VG1705B *** PROCESSANDO ...' . */
            _.Display($"*** VG1705B *** PROCESSANDO ...");

            /*" -205- PERFORM 1000-PROCESSA-EVENTO THRU 1000-FIM UNTIL WFIM-AGENCTOAPOL EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_AGENCTOAPOL == "S"))
            {

                M_1000_PROCESSA_EVENTO(true);

                M_1000_CONTINUA(true);

                M_1000_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

            }

            /*" -206- DISPLAY 'SOLICITACOES LIDAS          ' AC-L-AGENCTOAPOL. */
            _.Display($"SOLICITACOES LIDAS          {AREA_DE_WORK.AC_L_AGENCTOAPOL}");

            /*" -207- DISPLAY ' ' . */
            _.Display($" ");

            /*" -208- DISPLAY 'AGENCIAMENTOS INSERIDOS     ' AC-I-AGENCIAMENTO. */
            _.Display($"AGENCIAMENTOS INSERIDOS     {AREA_DE_WORK.AC_I_AGENCIAMENTO}");

            /*" -209- DISPLAY ' ' . */
            _.Display($" ");

            /*" -210- DISPLAY 'INSERIDOS V0COMISSAO        ' AC-I-COMISSAO. */
            _.Display($"INSERIDOS V0COMISSAO        {AREA_DE_WORK.AC_I_COMISSAO}");

            /*" -211- DISPLAY ' ' . */
            _.Display($" ");

            /*" -212- DISPLAY 'INSERIDOS V0FUNDOCOMISVA    ' AC-I-FUNDAO. */
            _.Display($"INSERIDOS V0FUNDOCOMISVA    {AREA_DE_WORK.AC_I_FUNDAO}");

            /*" -212- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" M-0000-INICIO-DB-SELECT-1 */
        public void M_0000_INICIO_DB_SELECT_1()
        {
            /*" -153- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CO' END-EXEC. */

            var m_0000_INICIO_DB_SELECT_1_Query1 = new M_0000_INICIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_INICIO_DB_SELECT_1_Query1.Execute(m_0000_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }

        [StopWatch]
        /*" M-0000-INICIO-DB-DECLARE-1 */
        public void M_0000_INICIO_DB_DECLARE_1()
        {
            /*" -188- EXEC SQL DECLARE AGENCTOAPOL CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_PARCELA, COD_AGENCIADOR, MATRIC_INDICADOR, PERC_PAG_PARCELA, COD_PAG_ANGARIACAO, NUM_ENDOSSO, DATA_MOVIMENTO, SITUACAO_AGENCTO, TIMESTAMP FROM SEGUROS.AGENCTO_APOL_VGAP WHERE SITUACAO_AGENCTO = '0' FOR UPDATE OF NUM_ENDOSSO, DATA_MOVIMENTO, SITUACAO_AGENCTO, TIMESTAMP END-EXEC. */
            AGENCTOAPOL = new VG1705B_AGENCTOAPOL(false);
            string GetQuery_AGENCTOAPOL()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_PARCELA
							, 
							COD_AGENCIADOR
							, 
							MATRIC_INDICADOR
							, 
							PERC_PAG_PARCELA
							, 
							COD_PAG_ANGARIACAO
							, 
							NUM_ENDOSSO
							, 
							DATA_MOVIMENTO
							, 
							SITUACAO_AGENCTO
							, 
							TIMESTAMP 
							FROM SEGUROS.AGENCTO_APOL_VGAP 
							WHERE SITUACAO_AGENCTO = '0'";

                return query;
            }
            AGENCTOAPOL.GetQueryEvent += GetQuery_AGENCTOAPOL;

        }

        [StopWatch]
        /*" M-0000-INICIO-DB-OPEN-1 */
        public void M_0000_INICIO_DB_OPEN_1()
        {
            /*" -193- EXEC SQL OPEN AGENCTOAPOL END-EXEC. */

            AGENCTOAPOL.Open();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-EVENTO-DB-DECLARE-1 */
        public void M_1000_PROCESSA_EVENTO_DB_DECLARE_1()
        {
            /*" -309- EXEC SQL DECLARE FATURASC CURSOR FOR SELECT NUM_FATURA, NUM_ENDOSSO FROM SEGUROS.FATURAS WHERE NUM_APOLICE = :AGEAPOVG-NUM-APOLICE AND COD_SUBGRUPO = :AGEAPOVG-COD-SUBGRUPO AND NUM_ENDOSSO > 0 AND SIT_REGISTRO = '0' ORDER BY NUM_FATURA END-EXEC. */
            FATURASC = new VG1705B_FATURASC(true);
            string GetQuery_FATURASC()
            {
                var query = @$"SELECT NUM_FATURA
							, 
							NUM_ENDOSSO 
							FROM SEGUROS.FATURAS 
							WHERE NUM_APOLICE = '{AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE}' 
							AND COD_SUBGRUPO = '{AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_SUBGRUPO}' 
							AND NUM_ENDOSSO > 0 
							AND SIT_REGISTRO = '0' 
							ORDER BY NUM_FATURA";

                return query;
            }
            FATURASC.GetQueryEvent += GetQuery_FATURASC;

        }

        [StopWatch]
        /*" M-0002-FINALIZA */
        private void M_0002_FINALIZA(bool isPerform = false)
        {
            /*" -218- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -218- PERFORM M_0002_FINALIZA_DB_CLOSE_1 */

            M_0002_FINALIZA_DB_CLOSE_1();

            /*" -222- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -222- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -226- DISPLAY '*** VG1705B *** TERMINO NORMAL' . */
            _.Display($"*** VG1705B *** TERMINO NORMAL");

            /*" -228- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -228- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0002-FINALIZA-DB-CLOSE-1 */
        public void M_0002_FINALIZA_DB_CLOSE_1()
        {
            /*" -218- EXEC SQL CLOSE AGENCTOAPOL END-EXEC. */

            AGENCTOAPOL.Close();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-EVENTO */
        private void M_1000_PROCESSA_EVENTO(bool isPerform = false)
        {
            /*" -235- IF AGEAPOVG-COD-PAG-ANGARIACAO NOT EQUAL 02 */

            if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_PAG_ANGARIACAO != 02)
            {

                /*" -236- MOVE '2' TO AGEAPOVG-SITUACAO-AGENCTO */
                _.Move("2", AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO);

                /*" -237- MOVE 0 TO AGEAPOVG-NUM-ENDOSSO */
                _.Move(0, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO);

                /*" -239- GO TO 1000-CONTINUA. */

                M_1000_CONTINUA(); //GOTO
                return;
            }


            /*" -240- IF AGEAPOVG-COD-AGENCIADOR EQUAL 999105 */

            if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_AGENCIADOR == 999105)
            {

                /*" -241- MOVE '2' TO AGEAPOVG-SITUACAO-AGENCTO */
                _.Move("2", AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO);

                /*" -242- MOVE 0 TO AGEAPOVG-NUM-ENDOSSO */
                _.Move(0, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO);

                /*" -244- GO TO 1000-CONTINUA. */

                M_1000_CONTINUA(); //GOTO
                return;
            }


            /*" -245- IF AGEAPOVG-MATRIC-INDICADOR NOT EQUAL ZEROS */

            if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_MATRIC_INDICADOR != 00)
            {

                /*" -246- IF AGEAPOVG-NUM-ENDOSSO EQUAL ZEROS */

                if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO == 00)
                {

                    /*" -247- IF AGEAPOVG-NUM-PARCELA GREATER 01 */

                    if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_PARCELA > 01)
                    {

                        /*" -248- MOVE '2' TO AGEAPOVG-SITUACAO-AGENCTO */
                        _.Move("2", AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO);

                        /*" -249- MOVE 0 TO AGEAPOVG-NUM-ENDOSSO */
                        _.Move(0, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO);

                        /*" -251- GO TO 1000-CONTINUA. */

                        M_1000_CONTINUA(); //GOTO
                        return;
                    }

                }

            }


            /*" -253- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -255- MOVE AGEAPOVG-NUM-APOLICE TO APOLICES-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -263- PERFORM M_1000_PROCESSA_EVENTO_DB_SELECT_1 */

            M_1000_PROCESSA_EVENTO_DB_SELECT_1();

            /*" -266- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -267- DISPLAY ' PROBLEMAS ACESSO APOLICE  ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO APOLICE  {DB.SQLCODE}");

                /*" -268- DISPLAY APOLICES-NUM-APOLICE */
                _.Display(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

                /*" -270- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -271- IF APOLICES-TIPO-APOLICE NOT EQUAL '5' */

            if (APOLICES.DCLAPOLICES.APOLICES_TIPO_APOLICE != "5")
            {

                /*" -272- MOVE '2' TO AGEAPOVG-SITUACAO-AGENCTO */
                _.Move("2", AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO);

                /*" -273- MOVE 0 TO AGEAPOVG-NUM-ENDOSSO */
                _.Move(0, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO);

                /*" -275- GO TO 1000-CONTINUA. */

                M_1000_CONTINUA(); //GOTO
                return;
            }


            /*" -277- MOVE '101' TO WNR-EXEC-SQL. */
            _.Move("101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -278- MOVE AGEAPOVG-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -280- MOVE ZEROS TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -289- PERFORM M_1000_PROCESSA_EVENTO_DB_SELECT_2 */

            M_1000_PROCESSA_EVENTO_DB_SELECT_2();

            /*" -292- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -293- DISPLAY ' PROBLEMAS ACESSO ENDOSSO 0' SQLCODE */
                _.Display($" PROBLEMAS ACESSO ENDOSSO 0{DB.SQLCODE}");

                /*" -294- DISPLAY APOLICES-NUM-APOLICE */
                _.Display(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

                /*" -297- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -299- MOVE '102' TO WNR-EXEC-SQL. */
            _.Move("102", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -309- PERFORM M_1000_PROCESSA_EVENTO_DB_DECLARE_1 */

            M_1000_PROCESSA_EVENTO_DB_DECLARE_1();

            /*" -311- PERFORM M_1000_PROCESSA_EVENTO_DB_OPEN_1 */

            M_1000_PROCESSA_EVENTO_DB_OPEN_1();

            /*" -314- MOVE ZEROS TO WCONT-PARCELAS. */
            _.Move(0, WCONT_PARCELAS);

            /*" -315- MOVE ZEROS TO WPRM-VG. */
            _.Move(0, WPRM_VG);

            /*" -316- MOVE ZEROS TO WPRM-AP. */
            _.Move(0, WPRM_AP);

            /*" -318- MOVE ZEROS TO WPRM-TT. */
            _.Move(0, WPRM_TT);

            /*" -320- MOVE 'N' TO WFIM-FATURAS. */
            _.Move("N", AREA_DE_WORK.WFIM_FATURAS);

            /*" -322- PERFORM 1510-FETCH THRU 1510-FIM. */

            M_1510_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1510_FIM*/


            /*" -323- IF WFIM-FATURAS EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_FATURAS == "S")
            {

                /*" -323- PERFORM M_1000_PROCESSA_EVENTO_DB_CLOSE_1 */

                M_1000_PROCESSA_EVENTO_DB_CLOSE_1();

                /*" -326- GO TO 1000-NEXT. */

                M_1000_NEXT(); //GOTO
                return;
            }


            /*" -329- PERFORM 1500-PROC-FATURAS THRU 1500-FIM UNTIL WFIM-FATURAS EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_FATURAS == "S"))
            {

                M_1500_PROC_FATURAS(true);

                M_1500_FUNDAO(true);

                M_1500_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/

            }

            /*" -330- MOVE '103' TO WNR-EXEC-SQL. */
            _.Move("103", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -330- PERFORM M_1000_PROCESSA_EVENTO_DB_CLOSE_2 */

            M_1000_PROCESSA_EVENTO_DB_CLOSE_2();

            /*" -333- IF WCONT-PARCELAS LESS AGEAPOVG-NUM-PARCELA */

            if (WCONT_PARCELAS < AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_PARCELA)
            {

                /*" -333- GO TO 1000-NEXT. */

                M_1000_NEXT(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-EVENTO-DB-SELECT-1 */
        public void M_1000_PROCESSA_EVENTO_DB_SELECT_1()
        {
            /*" -263- EXEC SQL SELECT TIPO_APOLICE INTO :APOLICES-TIPO-APOLICE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE END-EXEC. */

            var m_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1 = new M_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1.Execute(m_1000_PROCESSA_EVENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_TIPO_APOLICE, APOLICES.DCLAPOLICES.APOLICES_TIPO_APOLICE);
            }


        }

        [StopWatch]
        /*" M-1000-CONTINUA */
        private void M_1000_CONTINUA(bool isPerform = false)
        {
            /*" -345- PERFORM M_1000_CONTINUA_DB_UPDATE_1 */

            M_1000_CONTINUA_DB_UPDATE_1();

            /*" -348- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -348- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1000-CONTINUA-DB-UPDATE-1 */
        public void M_1000_CONTINUA_DB_UPDATE_1()
        {
            /*" -345- EXEC SQL UPDATE SEGUROS.AGENCTO_APOL_VGAP SET NUM_ENDOSSO = :AGEAPOVG-NUM-ENDOSSO, DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO, SITUACAO_AGENCTO = :AGEAPOVG-SITUACAO-AGENCTO, TIMESTAMP = CURRENT TIMESTAMP WHERE CURRENT OF AGENCTOAPOL END-EXEC. */

            var m_1000_CONTINUA_DB_UPDATE_1_Update1 = new M_1000_CONTINUA_DB_UPDATE_1_Update1(AGENCTOAPOL)
            {
                AGEAPOVG_SITUACAO_AGENCTO = AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                AGEAPOVG_NUM_ENDOSSO = AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO.ToString(),
            };

            M_1000_CONTINUA_DB_UPDATE_1_Update1.Execute(m_1000_CONTINUA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1000-PROCESSA-EVENTO-DB-OPEN-1 */
        public void M_1000_PROCESSA_EVENTO_DB_OPEN_1()
        {
            /*" -311- EXEC SQL OPEN FATURASC END-EXEC. */

            FATURASC.Open();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-EVENTO-DB-CLOSE-1 */
        public void M_1000_PROCESSA_EVENTO_DB_CLOSE_1()
        {
            /*" -323- EXEC SQL CLOSE FATURASC END-EXEC */

            FATURASC.Close();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-EVENTO-DB-SELECT-2 */
        public void M_1000_PROCESSA_EVENTO_DB_SELECT_2()
        {
            /*" -289- EXEC SQL SELECT AGE_RCAP INTO :ENDOSSOS-AGE-PRODUTORA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO END-EXEC. */

            var m_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1 = new M_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1.Execute(m_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_AGE_PRODUTORA, ENDOSSOS_AGE_PRODUTORA);
            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-EVENTO-DB-CLOSE-2 */
        public void M_1000_PROCESSA_EVENTO_DB_CLOSE_2()
        {
            /*" -330- EXEC SQL CLOSE FATURASC END-EXEC. */

            FATURASC.Close();

        }

        [StopWatch]
        /*" M-1000-NEXT */
        private void M_1000_NEXT(bool isPerform = false)
        {
            /*" -351- PERFORM 1100-FETCH THRU 1100-FIM. */

            M_1100_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1100-FETCH */
        private void M_1100_FETCH(bool isPerform = false)
        {
            /*" -361- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -374- PERFORM M_1100_FETCH_DB_FETCH_1 */

            M_1100_FETCH_DB_FETCH_1();

            /*" -377- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -378- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -379- MOVE 'S' TO WFIM-AGENCTOAPOL */
                    _.Move("S", AREA_DE_WORK.WFIM_AGENCTOAPOL);

                    /*" -380- ELSE */
                }
                else
                {


                    /*" -381- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -382- ELSE */
                }

            }
            else
            {


                /*" -382- ADD 1 TO AC-L-AGENCTOAPOL. */
                AREA_DE_WORK.AC_L_AGENCTOAPOL.Value = AREA_DE_WORK.AC_L_AGENCTOAPOL + 1;
            }


        }

        [StopWatch]
        /*" M-1100-FETCH-DB-FETCH-1 */
        public void M_1100_FETCH_DB_FETCH_1()
        {
            /*" -374- EXEC SQL FETCH AGENCTOAPOL INTO :AGEAPOVG-NUM-APOLICE, :AGEAPOVG-COD-SUBGRUPO, :AGEAPOVG-NUM-PARCELA, :AGEAPOVG-COD-AGENCIADOR, :AGEAPOVG-MATRIC-INDICADOR, :AGEAPOVG-PERC-PAG-PARCELA, :AGEAPOVG-COD-PAG-ANGARIACAO, :AGEAPOVG-NUM-ENDOSSO, :AGEAPOVG-DATA-MOVIMENTO, :AGEAPOVG-SITUACAO-AGENCTO, :AGEAPOVG-TIMESTAMP END-EXEC. */

            if (AGENCTOAPOL.Fetch())
            {
                _.Move(AGENCTOAPOL.AGEAPOVG_NUM_APOLICE, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE);
                _.Move(AGENCTOAPOL.AGEAPOVG_COD_SUBGRUPO, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_SUBGRUPO);
                _.Move(AGENCTOAPOL.AGEAPOVG_NUM_PARCELA, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_PARCELA);
                _.Move(AGENCTOAPOL.AGEAPOVG_COD_AGENCIADOR, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_AGENCIADOR);
                _.Move(AGENCTOAPOL.AGEAPOVG_MATRIC_INDICADOR, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_MATRIC_INDICADOR);
                _.Move(AGENCTOAPOL.AGEAPOVG_PERC_PAG_PARCELA, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA);
                _.Move(AGENCTOAPOL.AGEAPOVG_COD_PAG_ANGARIACAO, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_PAG_ANGARIACAO);
                _.Move(AGENCTOAPOL.AGEAPOVG_NUM_ENDOSSO, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO);
                _.Move(AGENCTOAPOL.AGEAPOVG_DATA_MOVIMENTO, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_DATA_MOVIMENTO);
                _.Move(AGENCTOAPOL.AGEAPOVG_SITUACAO_AGENCTO, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO);
                _.Move(AGENCTOAPOL.AGEAPOVG_TIMESTAMP, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_TIMESTAMP);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

        [StopWatch]
        /*" M-1500-PROC-FATURAS */
        private void M_1500_PROC_FATURAS(bool isPerform = false)
        {
            /*" -392- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -394- MOVE AGEAPOVG-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -395- IF AGEAPOVG-NUM-ENDOSSO NOT GREATER ZEROS */

            if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO <= 00)
            {

                /*" -396- MOVE FATURAS-NUM-ENDOSSO TO ENDOSSOS-NUM-ENDOSSO */
                _.Move(FATURAS.DCLFATURAS.FATURAS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                /*" -397- ELSE */
            }
            else
            {


                /*" -398- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -400- MOVE AGEAPOVG-NUM-ENDOSSO TO ENDOSSOS-NUM-ENDOSSO. */
                _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
            }


            /*" -475- PERFORM M_1500_PROC_FATURAS_DB_SELECT_1 */

            M_1500_PROC_FATURAS_DB_SELECT_1();

            /*" -478- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -479- DISPLAY ' PROBLEMAS ACESSO ENDOSSOS ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO ENDOSSOS {DB.SQLCODE}");

                /*" -480- DISPLAY ENDOSSOS-NUM-APOLICE */
                _.Display(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

                /*" -481- DISPLAY ENDOSSOS-NUM-ENDOSSO */
                _.Display(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                /*" -482- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -483- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -485- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -486- IF ENDOSSOS-SIT-REGISTRO NOT EQUAL '1' */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO != "1")
            {

                /*" -487- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -488- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -490- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -491- IF ENDOSSOS-TIPO-ENDOSSO NOT EQUAL '1' */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO != "1")
            {

                /*" -492- DISPLAY 'ENDOSSO ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($"ENDOSSO {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -493- DISPLAY 'NAO E DE COBRANCA ' ENDOSSOS-NUM-APOLICE */
                _.Display($"NAO E DE COBRANCA {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -494- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -495- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -497- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -499- ADD 01 TO WCONT-PARCELAS. */
            WCONT_PARCELAS.Value = WCONT_PARCELAS + 01;

            /*" -500- IF WCONT-PARCELAS LESS AGEAPOVG-NUM-PARCELA */

            if (WCONT_PARCELAS < AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_PARCELA)
            {

                /*" -501- IF AGEAPOVG-NUM-ENDOSSO GREATER ZEROS */

                if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO > 00)
                {

                    /*" -502- MOVE AGEAPOVG-NUM-PARCELA TO WCONT-PARCELAS */
                    _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_PARCELA, WCONT_PARCELAS);

                    /*" -503- ELSE */
                }
                else
                {


                    /*" -505- GO TO 1500-NEXT. */

                    M_1500_NEXT(); //GOTO
                    return;
                }

            }


            /*" -507- MOVE '15A' TO WNR-EXEC-SQL. */
            _.Move("15A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -517- PERFORM M_1500_PROC_FATURAS_DB_SELECT_2 */

            M_1500_PROC_FATURAS_DB_SELECT_2();

            /*" -520- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -521- DISPLAY ' PROBLEMAS ACESSO COTACAO  ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO COTACAO  {DB.SQLCODE}");

                /*" -522- DISPLAY ENDOSSOS-COD-MOEDA-PRM */
                _.Display(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);

                /*" -523- DISPLAY ENDOSSOS-DATA-INIVIGENCIA */
                _.Display(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                /*" -524- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -525- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -527- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -529- MOVE '15B' TO WNR-EXEC-SQL. */
            _.Move("15B", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -544- PERFORM M_1500_PROC_FATURAS_DB_SELECT_3 */

            M_1500_PROC_FATURAS_DB_SELECT_3();

            /*" -547- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -548- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -549- MOVE ZEROS TO APOLICOB-PRM-TARIFARIO-IX */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

                    /*" -550- MOVE ZEROS TO APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -551- ELSE */
                }
                else
                {


                    /*" -553- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -557- COMPUTE WPRM-VG = APOLICOB-PRM-TARIFARIO-IX * MOEDACOT-VAL-VENDA * APOLICOB-FATOR-MULTIPLICA. */
            WPRM_VG.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -559- MOVE '15H' TO WNR-EXEC-SQL. */
            _.Move("15H", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -574- PERFORM M_1500_PROC_FATURAS_DB_SELECT_4 */

            M_1500_PROC_FATURAS_DB_SELECT_4();

            /*" -577- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -578- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -579- MOVE ZEROS TO APOLICOB-PRM-TARIFARIO-IX */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

                    /*" -580- MOVE ZEROS TO APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -581- ELSE */
                }
                else
                {


                    /*" -583- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -587- COMPUTE WPRM-VG77 = APOLICOB-PRM-TARIFARIO-IX * MOEDACOT-VAL-VENDA * APOLICOB-FATOR-MULTIPLICA. */
            WPRM_VG77.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -589- MOVE '15C' TO WNR-EXEC-SQL. */
            _.Move("15C", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -604- PERFORM M_1500_PROC_FATURAS_DB_SELECT_5 */

            M_1500_PROC_FATURAS_DB_SELECT_5();

            /*" -607- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -608- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -609- MOVE ZEROS TO APOLICOB-PRM-TARIFARIO-IX */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

                    /*" -610- MOVE ZEROS TO APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -611- ELSE */
                }
                else
                {


                    /*" -613- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -617- COMPUTE WPRM-AP = APOLICOB-PRM-TARIFARIO-IX * MOEDACOT-VAL-VENDA * APOLICOB-FATOR-MULTIPLICA. */
            WPRM_AP.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -619- MOVE '15I' TO WNR-EXEC-SQL. */
            _.Move("15I", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -634- PERFORM M_1500_PROC_FATURAS_DB_SELECT_6 */

            M_1500_PROC_FATURAS_DB_SELECT_6();

            /*" -637- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -638- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -639- MOVE ZEROS TO APOLICOB-PRM-TARIFARIO-IX */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

                    /*" -640- MOVE ZEROS TO APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -641- ELSE */
                }
                else
                {


                    /*" -643- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -647- COMPUTE WPRM-AP82 = APOLICOB-PRM-TARIFARIO-IX * MOEDACOT-VAL-VENDA * APOLICOB-FATOR-MULTIPLICA. */
            WPRM_AP82.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -650- COMPUTE WPRM-TT = WPRM-VG + WPRM-AP + WPRM-VG77 + WPRM-AP82. */
            WPRM_TT.Value = WPRM_VG + WPRM_AP + WPRM_VG77 + WPRM_AP82;

            /*" -651- IF WPRM-TT NOT GREATER ZEROS */

            if (WPRM_TT <= 00)
            {

                /*" -652- DISPLAY ' PREMIOS ZERADOS ' AGEAPOVG-NUM-APOLICE */
                _.Display($" PREMIOS ZERADOS {AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE}");

                /*" -653- DISPLAY '         ENDOSSO ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($"         ENDOSSO {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -654- SUBTRACT 01 FROM WCONT-PARCELAS */
                WCONT_PARCELAS.Value = WCONT_PARCELAS - 01;

                /*" -656- GO TO 1500-NEXT. */

                M_1500_NEXT(); //GOTO
                return;
            }


            /*" -658- MOVE '15D' TO WNR-EXEC-SQL. */
            _.Move("15D", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -660- MOVE AGEAPOVG-NUM-APOLICE TO APOLICES-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -668- PERFORM M_1500_PROC_FATURAS_DB_SELECT_7 */

            M_1500_PROC_FATURAS_DB_SELECT_7();

            /*" -671- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -672- DISPLAY ' PROBLEMAS ACESSO APOLICE  ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO APOLICE  {DB.SQLCODE}");

                /*" -673- DISPLAY APOLICES-NUM-APOLICE */
                _.Display(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

                /*" -674- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -675- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -677- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -679- MOVE '15E' TO WNR-EXEC-SQL. */
            _.Move("15E", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -680- MOVE AGEAPOVG-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -682- MOVE AGEAPOVG-COD-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -695- PERFORM M_1500_PROC_FATURAS_DB_SELECT_8 */

            M_1500_PROC_FATURAS_DB_SELECT_8();

            /*" -698- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -699- DISPLAY ' PROBLEMAS ACESSO SUBGRUPO ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO SUBGRUPO {DB.SQLCODE}");

                /*" -700- DISPLAY SUBGVGAP-NUM-APOLICE */
                _.Display(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

                /*" -701- DISPLAY SUBGVGAP-COD-SUBGRUPO */
                _.Display(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

                /*" -702- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -703- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -705- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -707- MOVE '15F' TO WNR-EXEC-SQL. */
            _.Move("15F", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -708- MOVE AGEAPOVG-NUM-APOLICE TO PARCELAS-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

            /*" -709- MOVE ENDOSSOS-NUM-ENDOSSO TO PARCELAS-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

            /*" -711- MOVE ZEROS TO PARCELAS-NUM-PARCELA. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);

            /*" -723- PERFORM M_1500_PROC_FATURAS_DB_SELECT_9 */

            M_1500_PROC_FATURAS_DB_SELECT_9();

            /*" -726- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -727- DISPLAY ' PROBLEMAS ACESSO PARCELAS ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO PARCELAS {DB.SQLCODE}");

                /*" -728- DISPLAY PARCELAS-NUM-APOLICE */
                _.Display(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

                /*" -729- DISPLAY PARCELAS-NUM-ENDOSSO */
                _.Display(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

                /*" -730- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -731- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -733- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -735- MOVE '15G' TO WNR-EXEC-SQL. */
            _.Move("15G", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -736- MOVE PARCELAS-NUM-APOLICE TO PARCEHIS-NUM-APOLICE. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -737- MOVE PARCELAS-NUM-ENDOSSO TO PARCEHIS-NUM-ENDOSSO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -738- MOVE ZEROS TO PARCEHIS-NUM-PARCELA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

            /*" -740- MOVE PARCELAS-OCORR-HISTORICO TO PARCEHIS-OCORR-HISTORICO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -752- PERFORM M_1500_PROC_FATURAS_DB_SELECT_10 */

            M_1500_PROC_FATURAS_DB_SELECT_10();

            /*" -755- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -756- DISPLAY ' PROBLEMAS ACESSO PARCELAS_H ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO PARCELAS_H {DB.SQLCODE}");

                /*" -757- DISPLAY PARCEHIS-NUM-APOLICE */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

                /*" -758- DISPLAY PARCEHIS-NUM-ENDOSSO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

                /*" -759- DISPLAY PARCEHIS-NUM-PARCELA */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

                /*" -760- DISPLAY PARCEHIS-OCORR-HISTORICO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

                /*" -761- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -762- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -764- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -765- IF PARCEHIS-DATA-QUITACAO EQUAL '9999-12-31' */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO == "9999-12-31")
            {

                /*" -766- DISPLAY 'DATA DE QUITACAO INVALIDA - AGENCTO RECUSADO ' */
                _.Display($"DATA DE QUITACAO INVALIDA - AGENCTO RECUSADO ");

                /*" -767- DISPLAY PARCEHIS-NUM-APOLICE */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

                /*" -768- DISPLAY PARCEHIS-NUM-ENDOSSO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

                /*" -769- DISPLAY PARCEHIS-NUM-PARCELA */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

                /*" -770- DISPLAY PARCEHIS-OCORR-HISTORICO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

                /*" -771- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -772- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -774- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -775- IF AGEAPOVG-MATRIC-INDICADOR GREATER ZEROS */

            if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_MATRIC_INDICADOR > 00)
            {

                /*" -777- GO TO 1500-FUNDAO. */

                M_1500_FUNDAO(); //GOTO
                return;
            }


            /*" -778- MOVE AGEAPOVG-NUM-APOLICE TO COMISSOE-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_APOLICE);

            /*" -779- MOVE ENDOSSOS-NUM-ENDOSSO TO COMISSOE-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_ENDOSSO);

            /*" -780- MOVE ZEROS TO COMISSOE-NUM-CERTIFICADO. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_CERTIFICADO);

            /*" -781- MOVE ' ' TO COMISSOE-DAC-CERTIFICADO. */
            _.Move(" ", COMISSOE.DCLCOMISSOES.COMISSOE_DAC_CERTIFICADO);

            /*" -782- MOVE '0' TO COMISSOE-TIPO-SEGURADO. */
            _.Move("0", COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_SEGURADO);

            /*" -783- MOVE ZEROS TO COMISSOE-NUM-PARCELA. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_PARCELA);

            /*" -784- MOVE 1101 TO COMISSOE-COD-OPERACAO. */
            _.Move(1101, COMISSOE.DCLCOMISSOES.COMISSOE_COD_OPERACAO);

            /*" -785- MOVE AGEAPOVG-COD-AGENCIADOR TO COMISSOE-COD-PRODUTOR. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_AGENCIADOR, COMISSOE.DCLCOMISSOES.COMISSOE_COD_PRODUTOR);

            /*" -786- MOVE PARCELAS-OCORR-HISTORICO TO COMISSOE-OCORR-HISTORICO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO, COMISSOE.DCLCOMISSOES.COMISSOE_OCORR_HISTORICO);

            /*" -787- MOVE ENDOSSOS-COD-FONTE TO COMISSOE-COD-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, COMISSOE.DCLCOMISSOES.COMISSOE_COD_FONTE);

            /*" -788- MOVE SUBGVGAP-COD-CLIENTE TO COMISSOE-COD-CLIENTE. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE, COMISSOE.DCLCOMISSOES.COMISSOE_COD_CLIENTE);

            /*" -789- MOVE SISTEMAS-DATA-MOV-ABERTO TO COMISSOE-DATA-CALCULO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_CALCULO);

            /*" -791- MOVE 0 TO COMISSOE-NUM-RECIBO. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_RECIBO);

            /*" -793- MOVE '3' TO COMISSOE-TIPO-COMISSAO. */
            _.Move("3", COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_COMISSAO);

            /*" -794- MOVE 0 TO COMISSOE-QTD-PARCELAS. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_QTD_PARCELAS);

            /*" -795- MOVE AGEAPOVG-PERC-PAG-PARCELA TO COMISSOE-PCT-COM-CORRETOR. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR);

            /*" -796- MOVE 0 TO COMISSOE-PCT-DESC-PREMIO. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_DESC_PREMIO);

            /*" -797- MOVE AGEAPOVG-COD-SUBGRUPO TO COMISSOE-COD-SUBGRUPO. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_SUBGRUPO, COMISSOE.DCLCOMISSOES.COMISSOE_COD_SUBGRUPO);

            /*" -798- MOVE SISTEMAS-DATA-MOV-ABERTO TO COMISSOE-DATA-SELECAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_SELECAO);

            /*" -802- MOVE PARCEHIS-DATA-QUITACAO TO COMISSOE-DATA-QUITACAO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_QUITACAO);

            /*" -804- COMPUTE COMISSOE-VAL-COMISSAO = WPRM-AP * AGEAPOVG-PERC-PAG-PARCELA / 100. */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.Value = WPRM_AP * AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA / 100f;

            /*" -805- MOVE 81 TO COMISSOE-RAMO-COBERTURA. */
            _.Move(81, COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

            /*" -806- MOVE 0 TO COMISSOE-MODALI-COBERTURA. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA);

            /*" -808- MOVE WPRM-AP TO COMISSOE-VAL-BASICO. */
            _.Move(WPRM_AP, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO);

            /*" -809- IF WPRM-AP GREATER ZEROS */

            if (WPRM_AP > 00)
            {

                /*" -811- PERFORM 2000-GRAVA-COMISSAO THRU 2000-FIM. */

                M_2000_GRAVA_COMISSAO(true);

                M_2000_LOOP_TIME(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

            }


            /*" -813- COMPUTE COMISSOE-VAL-COMISSAO = WPRM-AP82 * AGEAPOVG-PERC-PAG-PARCELA / 100. */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.Value = WPRM_AP82 * AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA / 100f;

            /*" -814- MOVE 82 TO COMISSOE-RAMO-COBERTURA. */
            _.Move(82, COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

            /*" -815- MOVE 0 TO COMISSOE-MODALI-COBERTURA. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA);

            /*" -817- MOVE WPRM-AP82 TO COMISSOE-VAL-BASICO. */
            _.Move(WPRM_AP82, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO);

            /*" -818- IF WPRM-AP82 GREATER ZEROS */

            if (WPRM_AP82 > 00)
            {

                /*" -822- PERFORM 2000-GRAVA-COMISSAO THRU 2000-FIM. */

                M_2000_GRAVA_COMISSAO(true);

                M_2000_LOOP_TIME(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

            }


            /*" -824- COMPUTE COMISSOE-VAL-COMISSAO = WPRM-VG * AGEAPOVG-PERC-PAG-PARCELA / 100. */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.Value = WPRM_VG * AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA / 100f;

            /*" -825- MOVE 93 TO COMISSOE-RAMO-COBERTURA. */
            _.Move(93, COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

            /*" -826- MOVE 0 TO COMISSOE-MODALI-COBERTURA. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA);

            /*" -828- MOVE WPRM-VG TO COMISSOE-VAL-BASICO. */
            _.Move(WPRM_VG, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO);

            /*" -829- IF WPRM-VG GREATER ZEROS */

            if (WPRM_VG > 00)
            {

                /*" -831- PERFORM 2000-GRAVA-COMISSAO THRU 2000-FIM. */

                M_2000_GRAVA_COMISSAO(true);

                M_2000_LOOP_TIME(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

            }


            /*" -833- COMPUTE COMISSOE-VAL-COMISSAO = WPRM-VG77 * AGEAPOVG-PERC-PAG-PARCELA / 100. */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.Value = WPRM_VG77 * AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA / 100f;

            /*" -834- MOVE 77 TO COMISSOE-RAMO-COBERTURA. */
            _.Move(77, COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

            /*" -835- MOVE 0 TO COMISSOE-MODALI-COBERTURA. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA);

            /*" -837- MOVE WPRM-VG77 TO COMISSOE-VAL-BASICO. */
            _.Move(WPRM_VG77, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO);

            /*" -838- IF WPRM-VG77 GREATER ZEROS */

            if (WPRM_VG77 > 00)
            {

                /*" -840- PERFORM 2000-GRAVA-COMISSAO THRU 2000-FIM. */

                M_2000_GRAVA_COMISSAO(true);

                M_2000_LOOP_TIME(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

            }


            /*" -841- MOVE '1' TO AGEAPOVG-SITUACAO-AGENCTO. */
            _.Move("1", AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO);

            /*" -842- MOVE ENDOSSOS-NUM-ENDOSSO TO AGEAPOVG-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO);

            /*" -843- MOVE 'S' TO WFIM-FATURAS. */
            _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

            /*" -843- GO TO 1500-FIM. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
            return;

        }

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-1 */
        public void M_1500_PROC_FATURAS_DB_SELECT_1()
        {
            /*" -475- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , DATA_PROPOSTA , DATA_LIBERACAO , DATA_EMISSAO , NUM_RCAP , VAL_RCAP , BCO_RCAP , AGE_RCAP , DAC_RCAP , TIPO_RCAP , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , DATA_INIVIGENCIA , DATA_TERVIGENCIA , PLANO_SEGURO , PCT_ENTRADA , PCT_ADIC_FRACIO , QTD_DIAS_PRIMEIRA , QTD_PARCELAS , QTD_PRESTACOES , QTD_ITENS , COD_TEXTO_PADRAO , COD_ACEITACAO , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SIT_REGISTRO INTO :ENDOSSOS-NUM-APOLICE , :ENDOSSOS-NUM-ENDOSSO , :ENDOSSOS-COD-SUBGRUPO , :ENDOSSOS-COD-FONTE , :ENDOSSOS-NUM-PROPOSTA , :ENDOSSOS-DATA-PROPOSTA , :ENDOSSOS-DATA-LIBERACAO , :ENDOSSOS-DATA-EMISSAO , :ENDOSSOS-NUM-RCAP , :ENDOSSOS-VAL-RCAP , :ENDOSSOS-BCO-RCAP , :ENDOSSOS-AGE-RCAP , :ENDOSSOS-DAC-RCAP , :ENDOSSOS-TIPO-RCAP , :ENDOSSOS-BCO-COBRANCA , :ENDOSSOS-AGE-COBRANCA , :ENDOSSOS-DAC-COBRANCA , :ENDOSSOS-DATA-INIVIGENCIA , :ENDOSSOS-DATA-TERVIGENCIA , :ENDOSSOS-PLANO-SEGURO , :ENDOSSOS-PCT-ENTRADA , :ENDOSSOS-PCT-ADIC-FRACIO , :ENDOSSOS-QTD-DIAS-PRIMEIRA, :ENDOSSOS-QTD-PARCELAS , :ENDOSSOS-QTD-PRESTACOES , :ENDOSSOS-QTD-ITENS , :ENDOSSOS-COD-TEXTO-PADRAO , :ENDOSSOS-COD-ACEITACAO , :ENDOSSOS-COD-MOEDA-IMP , :ENDOSSOS-COD-MOEDA-PRM , :ENDOSSOS-TIPO-ENDOSSO , :ENDOSSOS-COD-USUARIO , :ENDOSSOS-OCORR-ENDERECO , :ENDOSSOS-SIT-REGISTRO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO END-EXEC. */

            var m_1500_PROC_FATURAS_DB_SELECT_1_Query1 = new M_1500_PROC_FATURAS_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = M_1500_PROC_FATURAS_DB_SELECT_1_Query1.Execute(m_1500_PROC_FATURAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(executed_1.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_COD_SUBGRUPO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO);
                _.Move(executed_1.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(executed_1.ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_DATA_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_DATA_LIBERACAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO);
                _.Move(executed_1.ENDOSSOS_DATA_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);
                _.Move(executed_1.ENDOSSOS_NUM_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP);
                _.Move(executed_1.ENDOSSOS_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP);
                _.Move(executed_1.ENDOSSOS_BCO_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP);
                _.Move(executed_1.ENDOSSOS_AGE_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP);
                _.Move(executed_1.ENDOSSOS_DAC_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP);
                _.Move(executed_1.ENDOSSOS_TIPO_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP);
                _.Move(executed_1.ENDOSSOS_BCO_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA);
                _.Move(executed_1.ENDOSSOS_AGE_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA);
                _.Move(executed_1.ENDOSSOS_DAC_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(executed_1.ENDOSSOS_PLANO_SEGURO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO);
                _.Move(executed_1.ENDOSSOS_PCT_ENTRADA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA);
                _.Move(executed_1.ENDOSSOS_PCT_ADIC_FRACIO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO);
                _.Move(executed_1.ENDOSSOS_QTD_DIAS_PRIMEIRA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA);
                _.Move(executed_1.ENDOSSOS_QTD_PARCELAS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS);
                _.Move(executed_1.ENDOSSOS_QTD_PRESTACOES, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES);
                _.Move(executed_1.ENDOSSOS_QTD_ITENS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS);
                _.Move(executed_1.ENDOSSOS_COD_TEXTO_PADRAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO);
                _.Move(executed_1.ENDOSSOS_COD_ACEITACAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO);
                _.Move(executed_1.ENDOSSOS_COD_MOEDA_IMP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP);
                _.Move(executed_1.ENDOSSOS_COD_MOEDA_PRM, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);
                _.Move(executed_1.ENDOSSOS_TIPO_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_COD_USUARIO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO);
                _.Move(executed_1.ENDOSSOS_OCORR_ENDERECO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);
                _.Move(executed_1.ENDOSSOS_SIT_REGISTRO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);
            }


        }

        [StopWatch]
        /*" M-1500-FUNDAO */
        private void M_1500_FUNDAO(bool isPerform = false)
        {
            /*" -848- MOVE APOLICES-COD-PRODUTO TO FUNCOMVA-CODIGO-PRODUTO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_CODIGO_PRODUTO);

            /*" -849- MOVE ZEROS TO FUNCOMVA-NUM-CERTIFICADO. */
            _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_CERTIFICADO);

            /*" -850- MOVE ZEROS TO FUNCOMVA-NUM-PROPOSTA-AZUL. */
            _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_PROPOSTA_AZUL);

            /*" -851- MOVE ZEROS TO FUNCOMVA-NUM-TERMO. */
            _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TERMO);

            /*" -852- MOVE '0' TO FUNCOMVA-SITUACAO. */
            _.Move("0", FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO);

            /*" -853- MOVE 1101 TO FUNCOMVA-COD-OPERACAO. */
            _.Move(1101, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_OPERACAO);

            /*" -855- MOVE ENDOSSOS-COD-FONTE TO FUNCOMVA-COD-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_FONTE);

            /*" -856- IF ENDOSSOS-AGE-PRODUTORA EQUAL ZEROS */

            if (ENDOSSOS_AGE_PRODUTORA == 00)
            {

                /*" -858- MOVE ENDOSSOS-AGE-RCAP TO ENDOSSOS-AGE-PRODUTORA. */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP, ENDOSSOS_AGE_PRODUTORA);
            }


            /*" -859- MOVE ENDOSSOS-AGE-PRODUTORA TO FUNCOMVA-COD-AGENCIA. */
            _.Move(ENDOSSOS_AGE_PRODUTORA, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_AGENCIA);

            /*" -860- MOVE SUBGVGAP-COD-CLIENTE TO FUNCOMVA-COD-CLIENTE. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_CLIENTE);

            /*" -865- MOVE AGEAPOVG-MATRIC-INDICADOR TO FUNCOMVA-NUM-MATRI-VENDEDOR. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_MATRIC_INDICADOR, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_MATRI_VENDEDOR);

            /*" -867- COMPUTE WTOT-PRM-AP = WPRM-AP + WPRM-AP82. */
            WTOT_PRM_AP.Value = WPRM_AP + WPRM_AP82;

            /*" -869- COMPUTE FUNCOMVA-VAL-COMISSAO-AP = WTOT-PRM-AP * AGEAPOVG-PERC-PAG-PARCELA / 100. */
            FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_COMISSAO_AP.Value = WTOT_PRM_AP * AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA / 100f;

            /*" -873- MOVE WTOT-PRM-AP TO FUNCOMVA-VAL-BASICO-AP. */
            _.Move(WTOT_PRM_AP, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_AP);

            /*" -875- COMPUTE WTOT-PRM-VG = WPRM-VG + WPRM-VG77. */
            WTOT_PRM_VG.Value = WPRM_VG + WPRM_VG77;

            /*" -877- COMPUTE FUNCOMVA-VAL-COMISSAO-VG = WTOT-PRM-VG * AGEAPOVG-PERC-PAG-PARCELA / 100. */
            FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_COMISSAO_VG.Value = WTOT_PRM_VG * AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA / 100f;

            /*" -879- MOVE WTOT-PRM-VG TO FUNCOMVA-VAL-BASICO-VG. */
            _.Move(WTOT_PRM_VG, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_VG);

            /*" -880- MOVE PARCEHIS-DATA-QUITACAO TO FUNCOMVA-DATA-QUITACAO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_QUITACAO);

            /*" -881- MOVE AGEAPOVG-PERC-PAG-PARCELA TO FUNCOMVA-PCCOMIND. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_PCCOMIND);

            /*" -882- MOVE ZEROS TO FUNCOMVA-PCCOMGER. */
            _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_PCCOMGER);

            /*" -883- MOVE ZEROS TO FUNCOMVA-PCCOMSUP. */
            _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_PCCOMSUP);

            /*" -884- MOVE SISTEMAS-DATA-MOV-ABERTO TO FUNCOMVA-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_MOVIMENTO);

            /*" -886- MOVE 'VG1705B' TO FUNCOMVA-COD-USUARIO. */
            _.Move("VG1705B", FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_USUARIO);

            /*" -887- MOVE AGEAPOVG-NUM-APOLICE TO FUNCOMVA-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_APOLICE);

            /*" -888- MOVE AGEAPOVG-COD-SUBGRUPO TO FUNCOMVA-COD-SUBGRUPO. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_SUBGRUPO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_SUBGRUPO);

            /*" -889- MOVE ENDOSSOS-NUM-ENDOSSO TO FUNCOMVA-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_ENDOSSO);

            /*" -891- MOVE PARCELAS-NUM-TITULO TO FUNCOMVA-NUM-TITULO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TITULO);

            /*" -893- PERFORM 3000-GRAVA-FUNDAO THRU 3000-FIM. */

            M_3000_GRAVA_FUNDAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/


            /*" -894- MOVE '1' TO AGEAPOVG-SITUACAO-AGENCTO. */
            _.Move("1", AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO);

            /*" -895- MOVE ENDOSSOS-NUM-ENDOSSO TO AGEAPOVG-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO);

            /*" -896- MOVE 'S' TO WFIM-FATURAS. */
            _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

            /*" -896- GO TO 1500-FIM. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
            return;

        }

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-2 */
        public void M_1500_PROC_FATURAS_DB_SELECT_2()
        {
            /*" -517- EXEC SQL SELECT VAL_VENDA INTO :MOEDACOT-VAL-VENDA FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = :ENDOSSOS-COD-MOEDA-PRM AND DATA_INIVIGENCIA <= :ENDOSSOS-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :ENDOSSOS-DATA-INIVIGENCIA END-EXEC. */

            var m_1500_PROC_FATURAS_DB_SELECT_2_Query1 = new M_1500_PROC_FATURAS_DB_SELECT_2_Query1()
            {
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                ENDOSSOS_COD_MOEDA_PRM = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM.ToString(),
            };

            var executed_1 = M_1500_PROC_FATURAS_DB_SELECT_2_Query1.Execute(m_1500_PROC_FATURAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOEDACOT_VAL_VENDA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA);
            }


        }

        [StopWatch]
        /*" M-1500-NEXT */
        private void M_1500_NEXT(bool isPerform = false)
        {
            /*" -899- PERFORM 1510-FETCH THRU 1510-FIM. */

            M_1510_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1510_FIM*/


        }

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-3 */
        public void M_1500_PROC_FATURAS_DB_SELECT_3()
        {
            /*" -544- EXEC SQL SELECT PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND NUM_ITEM = 0 AND OCORR_HISTORICO = 0 AND RAMO_COBERTURA = 93 AND COD_COBERTURA = 0 END-EXEC. */

            var m_1500_PROC_FATURAS_DB_SELECT_3_Query1 = new M_1500_PROC_FATURAS_DB_SELECT_3_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = M_1500_PROC_FATURAS_DB_SELECT_3_Query1.Execute(m_1500_PROC_FATURAS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-4 */
        public void M_1500_PROC_FATURAS_DB_SELECT_4()
        {
            /*" -574- EXEC SQL SELECT PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND NUM_ITEM = 0 AND OCORR_HISTORICO = 0 AND RAMO_COBERTURA = 77 AND COD_COBERTURA = 0 END-EXEC. */

            var m_1500_PROC_FATURAS_DB_SELECT_4_Query1 = new M_1500_PROC_FATURAS_DB_SELECT_4_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = M_1500_PROC_FATURAS_DB_SELECT_4_Query1.Execute(m_1500_PROC_FATURAS_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" M-1510-FETCH */
        private void M_1510_FETCH(bool isPerform = false)
        {
            /*" -909- MOVE '151' TO WNR-EXEC-SQL. */
            _.Move("151", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -913- PERFORM M_1510_FETCH_DB_FETCH_1 */

            M_1510_FETCH_DB_FETCH_1();

            /*" -916- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -917- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -918- MOVE 'S' TO WFIM-FATURAS */
                    _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                    /*" -919- ELSE */
                }
                else
                {


                    /*" -919- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-1510-FETCH-DB-FETCH-1 */
        public void M_1510_FETCH_DB_FETCH_1()
        {
            /*" -913- EXEC SQL FETCH FATURASC INTO :FATURAS-NUM-FATURA, :FATURAS-NUM-ENDOSSO END-EXEC. */

            if (FATURASC.Fetch())
            {
                _.Move(FATURASC.FATURAS_NUM_FATURA, FATURAS.DCLFATURAS.FATURAS_NUM_FATURA);
                _.Move(FATURASC.FATURAS_NUM_ENDOSSO, FATURAS.DCLFATURAS.FATURAS_NUM_ENDOSSO);
            }

        }

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-5 */
        public void M_1500_PROC_FATURAS_DB_SELECT_5()
        {
            /*" -604- EXEC SQL SELECT PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND NUM_ITEM = 0 AND OCORR_HISTORICO = 0 AND RAMO_COBERTURA = 81 AND COD_COBERTURA = 0 END-EXEC. */

            var m_1500_PROC_FATURAS_DB_SELECT_5_Query1 = new M_1500_PROC_FATURAS_DB_SELECT_5_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = M_1500_PROC_FATURAS_DB_SELECT_5_Query1.Execute(m_1500_PROC_FATURAS_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1510_FIM*/

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-6 */
        public void M_1500_PROC_FATURAS_DB_SELECT_6()
        {
            /*" -634- EXEC SQL SELECT PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND NUM_ITEM = 0 AND OCORR_HISTORICO = 0 AND RAMO_COBERTURA = 82 AND COD_COBERTURA = 0 END-EXEC. */

            var m_1500_PROC_FATURAS_DB_SELECT_6_Query1 = new M_1500_PROC_FATURAS_DB_SELECT_6_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = M_1500_PROC_FATURAS_DB_SELECT_6_Query1.Execute(m_1500_PROC_FATURAS_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" M-2000-GRAVA-COMISSAO */
        private void M_2000_GRAVA_COMISSAO(bool isPerform = false)
        {
            /*" -927- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

        }

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-7 */
        public void M_1500_PROC_FATURAS_DB_SELECT_7()
        {
            /*" -668- EXEC SQL SELECT COD_PRODUTO INTO :APOLICES-COD-PRODUTO FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE END-EXEC. */

            var m_1500_PROC_FATURAS_DB_SELECT_7_Query1 = new M_1500_PROC_FATURAS_DB_SELECT_7_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_1500_PROC_FATURAS_DB_SELECT_7_Query1.Execute(m_1500_PROC_FATURAS_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" M-2000-LOOP-TIME */
        private void M_2000_LOOP_TIME(bool isPerform = false)
        {
            /*" -932- ACCEPT WTIME-DAY FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -933- MOVE CORR WTIME-DAY1 TO WTIME-DAYR. */
            _.MoveCorr(AREA_DE_WORK.WTIME_DAY1, AREA_DE_WORK.WTIME_DAYR);

            /*" -935- MOVE WTIME-DAYR TO COMISSOE-HORA-OPERACAO. */
            _.Move(AREA_DE_WORK.WTIME_DAYR, COMISSOE.DCLCOMISSOES.COMISSOE_HORA_OPERACAO);

            /*" -999- PERFORM M_2000_LOOP_TIME_DB_INSERT_1 */

            M_2000_LOOP_TIME_DB_INSERT_1();

            /*" -1002- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1003- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1004- GO TO 2000-LOOP-TIME */
                    new Task(() => M_2000_LOOP_TIME()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1005- ELSE */
                }
                else
                {


                    /*" -1006- DISPLAY 'ERRO INSERT COMISSOES ' SQLCODE */
                    _.Display($"ERRO INSERT COMISSOES {DB.SQLCODE}");

                    /*" -1007- DISPLAY COMISSOE-NUM-APOLICE */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_NUM_APOLICE);

                    /*" -1008- DISPLAY COMISSOE-NUM-ENDOSSO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_NUM_ENDOSSO);

                    /*" -1009- DISPLAY COMISSOE-NUM-CERTIFICADO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_NUM_CERTIFICADO);

                    /*" -1010- DISPLAY COMISSOE-DAC-CERTIFICADO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_DAC_CERTIFICADO);

                    /*" -1011- DISPLAY COMISSOE-TIPO-SEGURADO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_SEGURADO);

                    /*" -1012- DISPLAY COMISSOE-NUM-PARCELA */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_NUM_PARCELA);

                    /*" -1013- DISPLAY COMISSOE-COD-OPERACAO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_COD_OPERACAO);

                    /*" -1014- DISPLAY COMISSOE-COD-PRODUTOR */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_COD_PRODUTOR);

                    /*" -1015- DISPLAY COMISSOE-RAMO-COBERTURA */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

                    /*" -1016- DISPLAY COMISSOE-MODALI-COBERTURA */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA);

                    /*" -1017- DISPLAY COMISSOE-OCORR-HISTORICO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_OCORR_HISTORICO);

                    /*" -1018- DISPLAY COMISSOE-COD-FONTE */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_COD_FONTE);

                    /*" -1019- DISPLAY COMISSOE-COD-CLIENTE */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_COD_CLIENTE);

                    /*" -1020- DISPLAY COMISSOE-VAL-COMISSAO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO);

                    /*" -1021- DISPLAY COMISSOE-DATA-CALCULO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_DATA_CALCULO);

                    /*" -1022- DISPLAY COMISSOE-NUM-RECIBO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_NUM_RECIBO);

                    /*" -1023- DISPLAY COMISSOE-VAL-BASICO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO);

                    /*" -1024- DISPLAY COMISSOE-TIPO-COMISSAO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_COMISSAO);

                    /*" -1025- DISPLAY COMISSOE-QTD-PARCELAS */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_QTD_PARCELAS);

                    /*" -1026- DISPLAY COMISSOE-PCT-COM-CORRETOR */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR);

                    /*" -1027- DISPLAY COMISSOE-PCT-DESC-PREMIO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_PCT_DESC_PREMIO);

                    /*" -1028- DISPLAY COMISSOE-COD-SUBGRUPO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_COD_SUBGRUPO);

                    /*" -1029- DISPLAY COMISSOE-HORA-OPERACAO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_HORA_OPERACAO);

                    /*" -1030- DISPLAY COMISSOE-DATA-SELECAO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_DATA_SELECAO);

                    /*" -1031- DISPLAY COMISSOE-DATA-QUITACAO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_DATA_QUITACAO);

                    /*" -1033- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1035- ADD 1 TO AC-I-COMISSAO. */
            AREA_DE_WORK.AC_I_COMISSAO.Value = AREA_DE_WORK.AC_I_COMISSAO + 1;

            /*" -1035- ADD 1 TO AC-I-AGENCIAMENTO. */
            AREA_DE_WORK.AC_I_AGENCIAMENTO.Value = AREA_DE_WORK.AC_I_AGENCIAMENTO + 1;

        }

        [StopWatch]
        /*" M-2000-LOOP-TIME-DB-INSERT-1 */
        public void M_2000_LOOP_TIME_DB_INSERT_1()
        {
            /*" -999- EXEC SQL INSERT INTO SEGUROS.COMISSOES (NUM_APOLICE , NUM_ENDOSSO , NUM_CERTIFICADO , DAC_CERTIFICADO , TIPO_SEGURADO , NUM_PARCELA , COD_OPERACAO , COD_PRODUTOR , RAMO_COBERTURA , MODALI_COBERTURA , OCORR_HISTORICO , COD_FONTE , COD_CLIENTE , VAL_COMISSAO , DATA_CALCULO , NUM_RECIBO , VAL_BASICO , TIPO_COMISSAO , QTD_PARCELAS , PCT_COM_CORRETOR , PCT_DESC_PREMIO , COD_SUBGRUPO , HORA_OPERACAO , DATA_MOVIMENTO , DATA_SELECAO , COD_EMPRESA , COD_PREPOSTO , TIMESTAMP , NUM_BILHETE , VAL_VARMON , DATA_QUITACAO) VALUES (:COMISSOE-NUM-APOLICE , :COMISSOE-NUM-ENDOSSO , :COMISSOE-NUM-CERTIFICADO , :COMISSOE-DAC-CERTIFICADO , :COMISSOE-TIPO-SEGURADO , :COMISSOE-NUM-PARCELA , :COMISSOE-COD-OPERACAO , :COMISSOE-COD-PRODUTOR , :COMISSOE-RAMO-COBERTURA , :COMISSOE-MODALI-COBERTURA , :COMISSOE-OCORR-HISTORICO , :COMISSOE-COD-FONTE , :COMISSOE-COD-CLIENTE , :COMISSOE-VAL-COMISSAO , :COMISSOE-DATA-CALCULO , :COMISSOE-NUM-RECIBO , :COMISSOE-VAL-BASICO , :COMISSOE-TIPO-COMISSAO , :COMISSOE-QTD-PARCELAS , :COMISSOE-PCT-COM-CORRETOR , :COMISSOE-PCT-DESC-PREMIO , :COMISSOE-COD-SUBGRUPO , :COMISSOE-HORA-OPERACAO , NULL , :COMISSOE-DATA-SELECAO , NULL , NULL , CURRENT TIMESTAMP , NULL , NULL , :COMISSOE-DATA-QUITACAO) END-EXEC. */

            var m_2000_LOOP_TIME_DB_INSERT_1_Insert1 = new M_2000_LOOP_TIME_DB_INSERT_1_Insert1()
            {
                COMISSOE_NUM_APOLICE = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_APOLICE.ToString(),
                COMISSOE_NUM_ENDOSSO = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_ENDOSSO.ToString(),
                COMISSOE_NUM_CERTIFICADO = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_CERTIFICADO.ToString(),
                COMISSOE_DAC_CERTIFICADO = COMISSOE.DCLCOMISSOES.COMISSOE_DAC_CERTIFICADO.ToString(),
                COMISSOE_TIPO_SEGURADO = COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_SEGURADO.ToString(),
                COMISSOE_NUM_PARCELA = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_PARCELA.ToString(),
                COMISSOE_COD_OPERACAO = COMISSOE.DCLCOMISSOES.COMISSOE_COD_OPERACAO.ToString(),
                COMISSOE_COD_PRODUTOR = COMISSOE.DCLCOMISSOES.COMISSOE_COD_PRODUTOR.ToString(),
                COMISSOE_RAMO_COBERTURA = COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA.ToString(),
                COMISSOE_MODALI_COBERTURA = COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA.ToString(),
                COMISSOE_OCORR_HISTORICO = COMISSOE.DCLCOMISSOES.COMISSOE_OCORR_HISTORICO.ToString(),
                COMISSOE_COD_FONTE = COMISSOE.DCLCOMISSOES.COMISSOE_COD_FONTE.ToString(),
                COMISSOE_COD_CLIENTE = COMISSOE.DCLCOMISSOES.COMISSOE_COD_CLIENTE.ToString(),
                COMISSOE_VAL_COMISSAO = COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.ToString(),
                COMISSOE_DATA_CALCULO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_CALCULO.ToString(),
                COMISSOE_NUM_RECIBO = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_RECIBO.ToString(),
                COMISSOE_VAL_BASICO = COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO.ToString(),
                COMISSOE_TIPO_COMISSAO = COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_COMISSAO.ToString(),
                COMISSOE_QTD_PARCELAS = COMISSOE.DCLCOMISSOES.COMISSOE_QTD_PARCELAS.ToString(),
                COMISSOE_PCT_COM_CORRETOR = COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR.ToString(),
                COMISSOE_PCT_DESC_PREMIO = COMISSOE.DCLCOMISSOES.COMISSOE_PCT_DESC_PREMIO.ToString(),
                COMISSOE_COD_SUBGRUPO = COMISSOE.DCLCOMISSOES.COMISSOE_COD_SUBGRUPO.ToString(),
                COMISSOE_HORA_OPERACAO = COMISSOE.DCLCOMISSOES.COMISSOE_HORA_OPERACAO.ToString(),
                COMISSOE_DATA_SELECAO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_SELECAO.ToString(),
                COMISSOE_DATA_QUITACAO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_QUITACAO.ToString(),
            };

            M_2000_LOOP_TIME_DB_INSERT_1_Insert1.Execute(m_2000_LOOP_TIME_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-8 */
        public void M_1500_PROC_FATURAS_DB_SELECT_8()
        {
            /*" -695- EXEC SQL SELECT PERI_FATURAMENTO , COD_CLIENTE , COD_PAG_ANGARIACAO INTO :SUBGVGAP-PERI-FATURAMENTO , :SUBGVGAP-COD-CLIENTE , :SUBGVGAP-COD-PAG-ANGARIACAO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO END-EXEC. */

            var m_1500_PROC_FATURAS_DB_SELECT_8_Query1 = new M_1500_PROC_FATURAS_DB_SELECT_8_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_1500_PROC_FATURAS_DB_SELECT_8_Query1.Execute(m_1500_PROC_FATURAS_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_PERI_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_COD_CLIENTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE);
                _.Move(executed_1.SUBGVGAP_COD_PAG_ANGARIACAO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_PAG_ANGARIACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-9 */
        public void M_1500_PROC_FATURAS_DB_SELECT_9()
        {
            /*" -723- EXEC SQL SELECT NUM_TITULO , OCORR_HISTORICO INTO :PARCELAS-NUM-TITULO , :PARCELAS-OCORR-HISTORICO FROM SEGUROS.PARCELAS WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO AND NUM_PARCELA = :PARCELAS-NUM-PARCELA END-EXEC. */

            var m_1500_PROC_FATURAS_DB_SELECT_9_Query1 = new M_1500_PROC_FATURAS_DB_SELECT_9_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
                PARCELAS_NUM_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.ToString(),
            };

            var executed_1 = M_1500_PROC_FATURAS_DB_SELECT_9_Query1.Execute(m_1500_PROC_FATURAS_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCELAS_NUM_TITULO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO);
                _.Move(executed_1.PARCELAS_OCORR_HISTORICO, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);
            }


        }

        [StopWatch]
        /*" M-3000-GRAVA-FUNDAO */
        private void M_3000_GRAVA_FUNDAO(bool isPerform = false)
        {
            /*" -1045- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1097- PERFORM M_3000_GRAVA_FUNDAO_DB_INSERT_1 */

            M_3000_GRAVA_FUNDAO_DB_INSERT_1();

            /*" -1100- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1101- DISPLAY 'ERRO INSERT FUNDAO    ' SQLCODE */
                _.Display($"ERRO INSERT FUNDAO    {DB.SQLCODE}");

                /*" -1102- DISPLAY FUNCOMVA-NUM-APOLICE */
                _.Display(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_APOLICE);

                /*" -1103- DISPLAY FUNCOMVA-COD-SUBGRUPO */
                _.Display(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_SUBGRUPO);

                /*" -1104- DISPLAY FUNCOMVA-NUM-ENDOSSO */
                _.Display(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_ENDOSSO);

                /*" -1105- DISPLAY FUNCOMVA-NUM-TITULO */
                _.Display(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TITULO);

                /*" -1106- DISPLAY FUNCOMVA-NUM-MATRI-VENDEDOR */
                _.Display(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_MATRI_VENDEDOR);

                /*" -1108- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1110- ADD 1 TO AC-I-FUNDAO. */
            AREA_DE_WORK.AC_I_FUNDAO.Value = AREA_DE_WORK.AC_I_FUNDAO + 1;

            /*" -1110- ADD 1 TO AC-I-AGENCIAMENTO. */
            AREA_DE_WORK.AC_I_AGENCIAMENTO.Value = AREA_DE_WORK.AC_I_AGENCIAMENTO + 1;

        }

        [StopWatch]
        /*" M-3000-GRAVA-FUNDAO-DB-INSERT-1 */
        public void M_3000_GRAVA_FUNDAO_DB_INSERT_1()
        {
            /*" -1097- EXEC SQL INSERT INTO SEGUROS.FUNDO_COMISSAO_VA (CODIGO_PRODUTO , NUM_CERTIFICADO , NUM_PROPOSTA_AZUL , NUM_TERMO , SITUACAO , COD_OPERACAO , COD_FONTE , COD_AGENCIA , COD_CLIENTE , NUM_MATRI_VENDEDOR , VAL_BASICO_VG , VAL_BASICO_AP , VAL_COMISSAO_VG , VAL_COMISSAO_AP , DATA_QUITACAO , PCCOMIND , PCCOMGER , PCCOMSUP , DATA_MOVIMENTO , COD_USUARIO , TIMESTAMP , NUM_APOLICE , COD_SUBGRUPO , NUM_ENDOSSO , NUM_TITULO ) VALUES (:FUNCOMVA-CODIGO-PRODUTO , :FUNCOMVA-NUM-CERTIFICADO , :FUNCOMVA-NUM-PROPOSTA-AZUL , :FUNCOMVA-NUM-TERMO , :FUNCOMVA-SITUACAO , :FUNCOMVA-COD-OPERACAO , :FUNCOMVA-COD-FONTE , :FUNCOMVA-COD-AGENCIA , :FUNCOMVA-COD-CLIENTE , :FUNCOMVA-NUM-MATRI-VENDEDOR , :FUNCOMVA-VAL-BASICO-VG , :FUNCOMVA-VAL-BASICO-AP , :FUNCOMVA-VAL-COMISSAO-VG , :FUNCOMVA-VAL-COMISSAO-AP , :FUNCOMVA-DATA-QUITACAO , :FUNCOMVA-PCCOMIND , :FUNCOMVA-PCCOMGER , :FUNCOMVA-PCCOMSUP , :FUNCOMVA-DATA-MOVIMENTO , :FUNCOMVA-COD-USUARIO , CURRENT TIMESTAMP , :FUNCOMVA-NUM-APOLICE , :FUNCOMVA-COD-SUBGRUPO , :FUNCOMVA-NUM-ENDOSSO , :FUNCOMVA-NUM-TITULO ) END-EXEC. */

            var m_3000_GRAVA_FUNDAO_DB_INSERT_1_Insert1 = new M_3000_GRAVA_FUNDAO_DB_INSERT_1_Insert1()
            {
                FUNCOMVA_CODIGO_PRODUTO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_CODIGO_PRODUTO.ToString(),
                FUNCOMVA_NUM_CERTIFICADO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_CERTIFICADO.ToString(),
                FUNCOMVA_NUM_PROPOSTA_AZUL = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_PROPOSTA_AZUL.ToString(),
                FUNCOMVA_NUM_TERMO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TERMO.ToString(),
                FUNCOMVA_SITUACAO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO.ToString(),
                FUNCOMVA_COD_OPERACAO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_OPERACAO.ToString(),
                FUNCOMVA_COD_FONTE = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_FONTE.ToString(),
                FUNCOMVA_COD_AGENCIA = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_AGENCIA.ToString(),
                FUNCOMVA_COD_CLIENTE = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_CLIENTE.ToString(),
                FUNCOMVA_NUM_MATRI_VENDEDOR = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_MATRI_VENDEDOR.ToString(),
                FUNCOMVA_VAL_BASICO_VG = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_VG.ToString(),
                FUNCOMVA_VAL_BASICO_AP = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_AP.ToString(),
                FUNCOMVA_VAL_COMISSAO_VG = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_COMISSAO_VG.ToString(),
                FUNCOMVA_VAL_COMISSAO_AP = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_COMISSAO_AP.ToString(),
                FUNCOMVA_DATA_QUITACAO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_QUITACAO.ToString(),
                FUNCOMVA_PCCOMIND = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_PCCOMIND.ToString(),
                FUNCOMVA_PCCOMGER = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_PCCOMGER.ToString(),
                FUNCOMVA_PCCOMSUP = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_PCCOMSUP.ToString(),
                FUNCOMVA_DATA_MOVIMENTO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_MOVIMENTO.ToString(),
                FUNCOMVA_COD_USUARIO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_USUARIO.ToString(),
                FUNCOMVA_NUM_APOLICE = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_APOLICE.ToString(),
                FUNCOMVA_COD_SUBGRUPO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_SUBGRUPO.ToString(),
                FUNCOMVA_NUM_ENDOSSO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_ENDOSSO.ToString(),
                FUNCOMVA_NUM_TITULO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TITULO.ToString(),
            };

            M_3000_GRAVA_FUNDAO_DB_INSERT_1_Insert1.Execute(m_3000_GRAVA_FUNDAO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-10 */
        public void M_1500_PROC_FATURAS_DB_SELECT_10()
        {
            /*" -752- EXEC SQL SELECT VALUE(DATA_QUITACAO, DATE( '9999-12-31' )) INTO :PARCEHIS-DATA-QUITACAO FROM SEGUROS.PARCELA_HISTORICO WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA AND OCORR_HISTORICO = :PARCEHIS-OCORR-HISTORICO AND COD_OPERACAO BETWEEN 200 AND 299 END-EXEC. */

            var m_1500_PROC_FATURAS_DB_SELECT_10_Query1 = new M_1500_PROC_FATURAS_DB_SELECT_10_Query1()
            {
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            var executed_1 = M_1500_PROC_FATURAS_DB_SELECT_10_Query1.Execute(m_1500_PROC_FATURAS_DB_SELECT_10_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEHIS_DATA_QUITACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/

        [StopWatch]
        /*" M-9000-ENCERRA-SEM-MOVTO */
        private void M_9000_ENCERRA_SEM_MOVTO(bool isPerform = false)
        {
            /*" -1122- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA_REL);

            /*" -1123- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -1124- MOVE WDAT-REL-MES TO WDAT-LIT-MES. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -1126- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -1127- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1128- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1129- DISPLAY '*   VG1705B - ATUALIZACAO DB COMISSOES     *' */
            _.Display($"*   VG1705B - ATUALIZACAO DB COMISSOES     *");

            /*" -1130- DISPLAY '*   -------   ----------- -- ---------     *' */
            _.Display($"*   -------   ----------- -- ---------     *");

            /*" -1131- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1132- DISPLAY '*   NAO HOUVE MOVIMENTACAO                 *' */
            _.Display($"*   NAO HOUVE MOVIMENTACAO                 *");

            /*" -1134- DISPLAY '*   NESTA DATA ' WDAT-REL-LIT '                    *' */

            $"*   NESTA DATA {AREA_DE_WORK.WDAT_REL_LIT}                    *"
            .Display();

            /*" -1135- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1135- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -1147- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1149- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1150- DISPLAY 'APOLICE ' AGEAPOVG-NUM-APOLICE. */
            _.Display($"APOLICE {AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE}");

            /*" -1151- DISPLAY 'SUBGR.  ' AGEAPOVG-COD-SUBGRUPO. */
            _.Display($"SUBGR.  {AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_SUBGRUPO}");

            /*" -1152- DISPLAY 'INDIC.  ' AGEAPOVG-MATRIC-INDICADOR. */
            _.Display($"INDIC.  {AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_MATRIC_INDICADOR}");

            /*" -1153- DISPLAY 'AGENC.  ' AGEAPOVG-COD-AGENCIADOR. */
            _.Display($"AGENC.  {AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_AGENCIADOR}");

            /*" -1154- DISPLAY 'PARCE.  ' AGEAPOVG-NUM-PARCELA. */
            _.Display($"PARCE.  {AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_PARCELA}");

            /*" -1156- DISPLAY 'ENDOS.  ' ENDOSSOS-NUM-ENDOSSO. */
            _.Display($"ENDOS.  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

            /*" -1156- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1158- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1161- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1161- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}