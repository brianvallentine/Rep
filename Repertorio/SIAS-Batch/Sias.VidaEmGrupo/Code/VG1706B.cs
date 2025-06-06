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
using Sias.VidaEmGrupo.DB2.VG1706B;

namespace Code
{
    public class VG1706B
    {
        public bool IsCall { get; set; }

        public VG1706B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *   CALCULA E GRAVA COMISSOES DE AGENCIAMENTO PARA AS APOLICES   *      */
        /*"      *   ESPECIFICAS DOS RAMOS 81, 93 E 97. (NOVO FATURAMENTO)        *      */
        /*"      *                         82 E 77                                *      */
        /*"      *   DATA.  08/03/2002.                                           *      */
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
        /*"01 WTOT-PRM-AP                   PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WTOT_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WPRM-AP                       PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WPRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WPRM-AP82                     PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WPRM_AP82 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WTOT-PRM-VG                   PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WTOT_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WPRM-VG                       PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WPRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WPRM-VG77                     PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WPRM_VG77 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WPRM-TT                       PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WPRM_TT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01 WCONT-PARCELAS                PIC  9(009).*/
        public IntBasis WCONT_PARCELAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01           AREA-DE-WORK.*/
        public VG1706B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG1706B_AREA_DE_WORK();
        public class VG1706B_AREA_DE_WORK : VarBasis
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
            private _REDEF_VG1706B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VG1706B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VG1706B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VG1706B_FILLER_0 : VarBasis
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

                public _REDEF_VG1706B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG1706B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VG1706B_WDAT_REL_LIT();
            public class VG1706B_WDAT_REL_LIT : VarBasis
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
            private _REDEF_VG1706B_WTIME_DAY1 _wtime_day1 { get; set; }
            public _REDEF_VG1706B_WTIME_DAY1 WTIME_DAY1
            {
                get { _wtime_day1 = new _REDEF_VG1706B_WTIME_DAY1(); _.Move(WTIME_DAY, _wtime_day1); VarBasis.RedefinePassValue(WTIME_DAY, _wtime_day1, WTIME_DAY); _wtime_day1.ValueChanged += () => { _.Move(_wtime_day1, WTIME_DAY); }; return _wtime_day1; }
                set { VarBasis.RedefinePassValue(value, _wtime_day1, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VG1706B_WTIME_DAY1 : VarBasis
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

                public _REDEF_VG1706B_WTIME_DAY1()
                {
                    WTIME_HORA.ValueChanged += OnValueChanged;
                    WTIME_MINU.ValueChanged += OnValueChanged;
                    WTIME_SEGU.ValueChanged += OnValueChanged;
                    WTIME_CCCC.ValueChanged += OnValueChanged;
                }

            }
            public VG1706B_WTIME_DAYR WTIME_DAYR { get; set; } = new VG1706B_WTIME_DAYR();
            public class VG1706B_WTIME_DAYR : VarBasis
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
            public VG1706B_WABEND WABEND { get; set; } = new VG1706B_WABEND();
            public class VG1706B_WABEND : VarBasis
            {
                /*"      10    FILLER              PIC  X(010) VALUE           ' VG1706B'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG1706B");
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
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public VG1706B_AGENCTOAPOL AGENCTOAPOL { get; set; } = new VG1706B_AGENCTOAPOL();
        public VG1706B_FATURASC FATURASC { get; set; } = new VG1706B_FATURASC();
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
            /*" -127- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -128- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -131- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -134- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -142- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -147- PERFORM M_0000_INICIO_DB_SELECT_1 */

            M_0000_INICIO_DB_SELECT_1();

            /*" -150- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -151- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -152- DISPLAY '*** VG1706B *** SISTEMA CO NAO CADASTRADO' */
                    _.Display($"*** VG1706B *** SISTEMA CO NAO CADASTRADO");

                    /*" -153- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -154- ELSE */
                }
                else
                {


                    /*" -160- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -162- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -182- PERFORM M_0000_INICIO_DB_DECLARE_1 */

            M_0000_INICIO_DB_DECLARE_1();

            /*" -186- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -187- DISPLAY '*** VG1706B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VG1706B *** ABRINDO CURSOR ...");

            /*" -187- PERFORM M_0000_INICIO_DB_OPEN_1 */

            M_0000_INICIO_DB_OPEN_1();

            /*" -191- PERFORM 1100-FETCH THRU 1100-FIM. */

            M_1100_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


            /*" -192- IF WFIM-AGENCTOAPOL EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_AGENCTOAPOL == "S")
            {

                /*" -193- PERFORM M-9000-ENCERRA-SEM-MOVTO THRU 9000-FIM */

                M_9000_ENCERRA_SEM_MOVTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


                /*" -195- GO TO 0002-FINALIZA. */

                M_0002_FINALIZA(); //GOTO
                return;
            }


            /*" -196- DISPLAY '*** VG1706B *** PROCESSANDO ...' . */
            _.Display($"*** VG1706B *** PROCESSANDO ...");

            /*" -199- PERFORM 1000-PROCESSA-EVENTO THRU 1000-FIM UNTIL WFIM-AGENCTOAPOL EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_AGENCTOAPOL == "S"))
            {

                M_1000_PROCESSA_EVENTO(true);

                M_1000_CONTINUA(true);

                M_1000_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

            }

            /*" -200- DISPLAY 'SOLICITACOES LIDAS          ' AC-L-AGENCTOAPOL. */
            _.Display($"SOLICITACOES LIDAS          {AREA_DE_WORK.AC_L_AGENCTOAPOL}");

            /*" -201- DISPLAY ' ' . */
            _.Display($" ");

            /*" -202- DISPLAY 'AGENCIAMENTOS INSERIDOS     ' AC-I-AGENCIAMENTO. */
            _.Display($"AGENCIAMENTOS INSERIDOS     {AREA_DE_WORK.AC_I_AGENCIAMENTO}");

            /*" -203- DISPLAY ' ' . */
            _.Display($" ");

            /*" -204- DISPLAY 'INSERIDOS V0COMISSAO        ' AC-I-COMISSAO. */
            _.Display($"INSERIDOS V0COMISSAO        {AREA_DE_WORK.AC_I_COMISSAO}");

            /*" -205- DISPLAY ' ' . */
            _.Display($" ");

            /*" -206- DISPLAY 'INSERIDOS V0FUNDOCOMISVA    ' AC-I-FUNDAO. */
            _.Display($"INSERIDOS V0FUNDOCOMISVA    {AREA_DE_WORK.AC_I_FUNDAO}");

            /*" -206- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" M-0000-INICIO-DB-SELECT-1 */
        public void M_0000_INICIO_DB_SELECT_1()
        {
            /*" -147- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CO' END-EXEC. */

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
            /*" -182- EXEC SQL DECLARE AGENCTOAPOL CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_PARCELA, COD_AGENCIADOR, MATRIC_INDICADOR, PERC_PAG_PARCELA, COD_PAG_ANGARIACAO, NUM_ENDOSSO, DATA_MOVIMENTO, SITUACAO_AGENCTO, TIMESTAMP FROM SEGUROS.AGENCTO_APOL_VGAP WHERE SITUACAO_AGENCTO = '0' FOR UPDATE OF NUM_ENDOSSO, DATA_MOVIMENTO, SITUACAO_AGENCTO, TIMESTAMP END-EXEC. */
            AGENCTOAPOL = new VG1706B_AGENCTOAPOL(false);
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
            /*" -187- EXEC SQL OPEN AGENCTOAPOL END-EXEC. */

            AGENCTOAPOL.Open();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-EVENTO-DB-DECLARE-1 */
        public void M_1000_PROCESSA_EVENTO_DB_DECLARE_1()
        {
            /*" -305- EXEC SQL DECLARE FATURASC CURSOR FOR SELECT NUM_PARCELA, NUM_ENDOSSO FROM SEGUROS.HIST_CONT_PARCELVA WHERE SIT_REGISTRO = '1' AND NUM_APOLICE = :AGEAPOVG-NUM-APOLICE AND COD_SUBGRUPO = :AGEAPOVG-COD-SUBGRUPO AND COD_FONTE > 0 AND NUM_ENDOSSO > 0 AND COD_OPERACAO BETWEEN 200 AND 299 ORDER BY NUM_PARCELA END-EXEC. */
            FATURASC = new VG1706B_FATURASC(true);
            string GetQuery_FATURASC()
            {
                var query = @$"SELECT NUM_PARCELA
							, 
							NUM_ENDOSSO 
							FROM SEGUROS.HIST_CONT_PARCELVA 
							WHERE SIT_REGISTRO = '1' 
							AND NUM_APOLICE = '{AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE}' 
							AND COD_SUBGRUPO = '{AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_SUBGRUPO}' 
							AND COD_FONTE > 0 
							AND NUM_ENDOSSO > 0 
							AND COD_OPERACAO BETWEEN 200 AND 299 
							ORDER BY NUM_PARCELA";

                return query;
            }
            FATURASC.GetQueryEvent += GetQuery_FATURASC;

        }

        [StopWatch]
        /*" M-0002-FINALIZA */
        private void M_0002_FINALIZA(bool isPerform = false)
        {
            /*" -212- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -212- PERFORM M_0002_FINALIZA_DB_CLOSE_1 */

            M_0002_FINALIZA_DB_CLOSE_1();

            /*" -216- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -216- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -220- DISPLAY '*** VG1706B *** TERMINO NORMAL' . */
            _.Display($"*** VG1706B *** TERMINO NORMAL");

            /*" -222- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -222- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0002-FINALIZA-DB-CLOSE-1 */
        public void M_0002_FINALIZA_DB_CLOSE_1()
        {
            /*" -212- EXEC SQL CLOSE AGENCTOAPOL END-EXEC. */

            AGENCTOAPOL.Close();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-EVENTO */
        private void M_1000_PROCESSA_EVENTO(bool isPerform = false)
        {
            /*" -229- IF AGEAPOVG-COD-PAG-ANGARIACAO NOT EQUAL 02 */

            if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_PAG_ANGARIACAO != 02)
            {

                /*" -230- MOVE '2' TO AGEAPOVG-SITUACAO-AGENCTO */
                _.Move("2", AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO);

                /*" -231- MOVE 0 TO AGEAPOVG-NUM-ENDOSSO */
                _.Move(0, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO);

                /*" -233- GO TO 1000-CONTINUA. */

                M_1000_CONTINUA(); //GOTO
                return;
            }


            /*" -234- IF AGEAPOVG-COD-AGENCIADOR EQUAL 999105 */

            if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_AGENCIADOR == 999105)
            {

                /*" -235- MOVE '2' TO AGEAPOVG-SITUACAO-AGENCTO */
                _.Move("2", AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO);

                /*" -236- MOVE 0 TO AGEAPOVG-NUM-ENDOSSO */
                _.Move(0, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO);

                /*" -238- GO TO 1000-CONTINUA. */

                M_1000_CONTINUA(); //GOTO
                return;
            }


            /*" -239- IF AGEAPOVG-MATRIC-INDICADOR NOT EQUAL ZEROS */

            if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_MATRIC_INDICADOR != 00)
            {

                /*" -240- IF AGEAPOVG-NUM-ENDOSSO EQUAL ZEROS */

                if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO == 00)
                {

                    /*" -241- IF AGEAPOVG-NUM-PARCELA GREATER 01 */

                    if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_PARCELA > 01)
                    {

                        /*" -242- MOVE '2' TO AGEAPOVG-SITUACAO-AGENCTO */
                        _.Move("2", AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO);

                        /*" -243- MOVE 0 TO AGEAPOVG-NUM-ENDOSSO */
                        _.Move(0, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO);

                        /*" -245- GO TO 1000-CONTINUA. */

                        M_1000_CONTINUA(); //GOTO
                        return;
                    }

                }

            }


            /*" -247- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -249- MOVE AGEAPOVG-NUM-APOLICE TO APOLICES-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -257- PERFORM M_1000_PROCESSA_EVENTO_DB_SELECT_1 */

            M_1000_PROCESSA_EVENTO_DB_SELECT_1();

            /*" -260- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -261- DISPLAY ' PROBLEMAS ACESSO APOLICE  ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO APOLICE  {DB.SQLCODE}");

                /*" -262- DISPLAY APOLICES-NUM-APOLICE */
                _.Display(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

                /*" -264- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -265- IF APOLICES-TIPO-APOLICE NOT EQUAL '5' */

            if (APOLICES.DCLAPOLICES.APOLICES_TIPO_APOLICE != "5")
            {

                /*" -266- MOVE '2' TO AGEAPOVG-SITUACAO-AGENCTO */
                _.Move("2", AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO);

                /*" -267- MOVE 0 TO AGEAPOVG-NUM-ENDOSSO */
                _.Move(0, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO);

                /*" -269- GO TO 1000-CONTINUA. */

                M_1000_CONTINUA(); //GOTO
                return;
            }


            /*" -271- MOVE '101' TO WNR-EXEC-SQL. */
            _.Move("101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -272- MOVE AGEAPOVG-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -274- MOVE ZEROS TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -283- PERFORM M_1000_PROCESSA_EVENTO_DB_SELECT_2 */

            M_1000_PROCESSA_EVENTO_DB_SELECT_2();

            /*" -286- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -287- DISPLAY ' PROBLEMAS ACESSO ENDOSSO 0' SQLCODE */
                _.Display($" PROBLEMAS ACESSO ENDOSSO 0{DB.SQLCODE}");

                /*" -288- DISPLAY APOLICES-NUM-APOLICE */
                _.Display(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

                /*" -291- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -293- MOVE '102' TO WNR-EXEC-SQL. */
            _.Move("102", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -305- PERFORM M_1000_PROCESSA_EVENTO_DB_DECLARE_1 */

            M_1000_PROCESSA_EVENTO_DB_DECLARE_1();

            /*" -307- PERFORM M_1000_PROCESSA_EVENTO_DB_OPEN_1 */

            M_1000_PROCESSA_EVENTO_DB_OPEN_1();

            /*" -310- MOVE ZEROS TO WCONT-PARCELAS. */
            _.Move(0, WCONT_PARCELAS);

            /*" -311- MOVE ZEROS TO WPRM-VG. */
            _.Move(0, WPRM_VG);

            /*" -312- MOVE ZEROS TO WPRM-AP. */
            _.Move(0, WPRM_AP);

            /*" -314- MOVE ZEROS TO WPRM-TT. */
            _.Move(0, WPRM_TT);

            /*" -316- MOVE 'N' TO WFIM-FATURAS. */
            _.Move("N", AREA_DE_WORK.WFIM_FATURAS);

            /*" -318- PERFORM 1510-FETCH THRU 1510-FIM. */

            M_1510_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1510_FIM*/


            /*" -319- IF WFIM-FATURAS EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_FATURAS == "S")
            {

                /*" -319- PERFORM M_1000_PROCESSA_EVENTO_DB_CLOSE_1 */

                M_1000_PROCESSA_EVENTO_DB_CLOSE_1();

                /*" -322- GO TO 1000-NEXT. */

                M_1000_NEXT(); //GOTO
                return;
            }


            /*" -325- PERFORM 1500-PROC-FATURAS THRU 1500-FIM UNTIL WFIM-FATURAS EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_FATURAS == "S"))
            {

                M_1500_PROC_FATURAS(true);

                M_1500_FUNDAO(true);

                M_1500_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/

            }

            /*" -326- MOVE '103' TO WNR-EXEC-SQL. */
            _.Move("103", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -326- PERFORM M_1000_PROCESSA_EVENTO_DB_CLOSE_2 */

            M_1000_PROCESSA_EVENTO_DB_CLOSE_2();

            /*" -329- IF WCONT-PARCELAS LESS AGEAPOVG-NUM-PARCELA */

            if (WCONT_PARCELAS < AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_PARCELA)
            {

                /*" -329- GO TO 1000-NEXT. */

                M_1000_NEXT(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-EVENTO-DB-SELECT-1 */
        public void M_1000_PROCESSA_EVENTO_DB_SELECT_1()
        {
            /*" -257- EXEC SQL SELECT TIPO_APOLICE INTO :APOLICES-TIPO-APOLICE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE END-EXEC. */

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
            /*" -341- PERFORM M_1000_CONTINUA_DB_UPDATE_1 */

            M_1000_CONTINUA_DB_UPDATE_1();

            /*" -344- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -344- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1000-CONTINUA-DB-UPDATE-1 */
        public void M_1000_CONTINUA_DB_UPDATE_1()
        {
            /*" -341- EXEC SQL UPDATE SEGUROS.AGENCTO_APOL_VGAP SET NUM_ENDOSSO = :AGEAPOVG-NUM-ENDOSSO, DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO, SITUACAO_AGENCTO = :AGEAPOVG-SITUACAO-AGENCTO, TIMESTAMP = CURRENT TIMESTAMP WHERE CURRENT OF AGENCTOAPOL END-EXEC. */

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
            /*" -307- EXEC SQL OPEN FATURASC END-EXEC. */

            FATURASC.Open();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-EVENTO-DB-CLOSE-1 */
        public void M_1000_PROCESSA_EVENTO_DB_CLOSE_1()
        {
            /*" -319- EXEC SQL CLOSE FATURASC END-EXEC */

            FATURASC.Close();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-EVENTO-DB-SELECT-2 */
        public void M_1000_PROCESSA_EVENTO_DB_SELECT_2()
        {
            /*" -283- EXEC SQL SELECT AGE_RCAP INTO :ENDOSSOS-AGE-PRODUTORA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO END-EXEC. */

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
            /*" -326- EXEC SQL CLOSE FATURASC END-EXEC. */

            FATURASC.Close();

        }

        [StopWatch]
        /*" M-1000-NEXT */
        private void M_1000_NEXT(bool isPerform = false)
        {
            /*" -347- PERFORM 1100-FETCH THRU 1100-FIM. */

            M_1100_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1100-FETCH */
        private void M_1100_FETCH(bool isPerform = false)
        {
            /*" -357- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -370- PERFORM M_1100_FETCH_DB_FETCH_1 */

            M_1100_FETCH_DB_FETCH_1();

            /*" -373- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -374- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -375- MOVE 'S' TO WFIM-AGENCTOAPOL */
                    _.Move("S", AREA_DE_WORK.WFIM_AGENCTOAPOL);

                    /*" -376- ELSE */
                }
                else
                {


                    /*" -377- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -378- ELSE */
                }

            }
            else
            {


                /*" -378- ADD 1 TO AC-L-AGENCTOAPOL. */
                AREA_DE_WORK.AC_L_AGENCTOAPOL.Value = AREA_DE_WORK.AC_L_AGENCTOAPOL + 1;
            }


        }

        [StopWatch]
        /*" M-1100-FETCH-DB-FETCH-1 */
        public void M_1100_FETCH_DB_FETCH_1()
        {
            /*" -370- EXEC SQL FETCH AGENCTOAPOL INTO :AGEAPOVG-NUM-APOLICE, :AGEAPOVG-COD-SUBGRUPO, :AGEAPOVG-NUM-PARCELA, :AGEAPOVG-COD-AGENCIADOR, :AGEAPOVG-MATRIC-INDICADOR, :AGEAPOVG-PERC-PAG-PARCELA, :AGEAPOVG-COD-PAG-ANGARIACAO, :AGEAPOVG-NUM-ENDOSSO, :AGEAPOVG-DATA-MOVIMENTO, :AGEAPOVG-SITUACAO-AGENCTO, :AGEAPOVG-TIMESTAMP END-EXEC. */

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
            /*" -388- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -390- MOVE AGEAPOVG-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -391- IF AGEAPOVG-NUM-ENDOSSO NOT GREATER ZEROS */

            if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO <= 00)
            {

                /*" -392- MOVE HISCONPA-NUM-ENDOSSO TO ENDOSSOS-NUM-ENDOSSO */
                _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                /*" -393- ELSE */
            }
            else
            {


                /*" -394- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -396- MOVE AGEAPOVG-NUM-ENDOSSO TO ENDOSSOS-NUM-ENDOSSO. */
                _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
            }


            /*" -471- PERFORM M_1500_PROC_FATURAS_DB_SELECT_1 */

            M_1500_PROC_FATURAS_DB_SELECT_1();

            /*" -474- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -475- DISPLAY ' PROBLEMAS ACESSO ENDOSSOS ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO ENDOSSOS {DB.SQLCODE}");

                /*" -476- DISPLAY ENDOSSOS-NUM-APOLICE */
                _.Display(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

                /*" -477- DISPLAY ENDOSSOS-NUM-ENDOSSO */
                _.Display(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                /*" -478- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -479- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -481- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -482- IF ENDOSSOS-SIT-REGISTRO NOT EQUAL '1' */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO != "1")
            {

                /*" -483- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -484- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -486- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -487- IF ENDOSSOS-TIPO-ENDOSSO NOT EQUAL '1' */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO != "1")
            {

                /*" -488- DISPLAY 'ENDOSSO ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($"ENDOSSO {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -489- DISPLAY 'NAO E DE COBRANCA ' ENDOSSOS-NUM-APOLICE */
                _.Display($"NAO E DE COBRANCA {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -490- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -491- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -493- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -495- ADD 01 TO WCONT-PARCELAS. */
            WCONT_PARCELAS.Value = WCONT_PARCELAS + 01;

            /*" -496- IF WCONT-PARCELAS LESS AGEAPOVG-NUM-PARCELA */

            if (WCONT_PARCELAS < AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_PARCELA)
            {

                /*" -497- IF AGEAPOVG-NUM-ENDOSSO GREATER ZEROS */

                if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO > 00)
                {

                    /*" -498- MOVE AGEAPOVG-NUM-PARCELA TO WCONT-PARCELAS */
                    _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_PARCELA, WCONT_PARCELAS);

                    /*" -499- ELSE */
                }
                else
                {


                    /*" -501- GO TO 1500-NEXT. */

                    M_1500_NEXT(); //GOTO
                    return;
                }

            }


            /*" -503- MOVE '15A' TO WNR-EXEC-SQL. */
            _.Move("15A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -513- PERFORM M_1500_PROC_FATURAS_DB_SELECT_2 */

            M_1500_PROC_FATURAS_DB_SELECT_2();

            /*" -516- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -517- DISPLAY ' PROBLEMAS ACESSO COTACAO  ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO COTACAO  {DB.SQLCODE}");

                /*" -518- DISPLAY ENDOSSOS-COD-MOEDA-PRM */
                _.Display(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);

                /*" -519- DISPLAY ENDOSSOS-DATA-INIVIGENCIA */
                _.Display(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                /*" -520- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -521- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -523- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -525- MOVE '15B' TO WNR-EXEC-SQL. */
            _.Move("15B", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -540- PERFORM M_1500_PROC_FATURAS_DB_SELECT_3 */

            M_1500_PROC_FATURAS_DB_SELECT_3();

            /*" -543- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -544- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -545- MOVE ZEROS TO APOLICOB-PRM-TARIFARIO-IX */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

                    /*" -546- MOVE ZEROS TO APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -547- ELSE */
                }
                else
                {


                    /*" -549- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -553- COMPUTE WPRM-VG = APOLICOB-PRM-TARIFARIO-IX * MOEDACOT-VAL-VENDA * APOLICOB-FATOR-MULTIPLICA. */
            WPRM_VG.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -555- MOVE '15H' TO WNR-EXEC-SQL. */
            _.Move("15H", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -570- PERFORM M_1500_PROC_FATURAS_DB_SELECT_4 */

            M_1500_PROC_FATURAS_DB_SELECT_4();

            /*" -573- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -574- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -575- MOVE ZEROS TO APOLICOB-PRM-TARIFARIO-IX */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

                    /*" -576- MOVE ZEROS TO APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -577- ELSE */
                }
                else
                {


                    /*" -579- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -583- COMPUTE WPRM-VG77 = APOLICOB-PRM-TARIFARIO-IX * MOEDACOT-VAL-VENDA * APOLICOB-FATOR-MULTIPLICA. */
            WPRM_VG77.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -585- MOVE '15C' TO WNR-EXEC-SQL. */
            _.Move("15C", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -600- PERFORM M_1500_PROC_FATURAS_DB_SELECT_5 */

            M_1500_PROC_FATURAS_DB_SELECT_5();

            /*" -603- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -604- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -605- MOVE ZEROS TO APOLICOB-PRM-TARIFARIO-IX */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

                    /*" -606- MOVE ZEROS TO APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -607- ELSE */
                }
                else
                {


                    /*" -609- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -613- COMPUTE WPRM-AP = APOLICOB-PRM-TARIFARIO-IX * MOEDACOT-VAL-VENDA * APOLICOB-FATOR-MULTIPLICA. */
            WPRM_AP.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -615- MOVE '15I' TO WNR-EXEC-SQL. */
            _.Move("15I", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -630- PERFORM M_1500_PROC_FATURAS_DB_SELECT_6 */

            M_1500_PROC_FATURAS_DB_SELECT_6();

            /*" -633- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -634- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -635- MOVE ZEROS TO APOLICOB-PRM-TARIFARIO-IX */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

                    /*" -636- MOVE ZEROS TO APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -637- ELSE */
                }
                else
                {


                    /*" -639- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -643- COMPUTE WPRM-AP82 = APOLICOB-PRM-TARIFARIO-IX * MOEDACOT-VAL-VENDA * APOLICOB-FATOR-MULTIPLICA. */
            WPRM_AP82.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -645- COMPUTE WPRM-TT = WPRM-VG + WPRM-AP + WPRM-VG77 + WPRM-AP82. */
            WPRM_TT.Value = WPRM_VG + WPRM_AP + WPRM_VG77 + WPRM_AP82;

            /*" -646- IF WPRM-TT NOT GREATER ZEROS */

            if (WPRM_TT <= 00)
            {

                /*" -647- DISPLAY ' PREMIOS ZERADOS ' AGEAPOVG-NUM-APOLICE */
                _.Display($" PREMIOS ZERADOS {AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE}");

                /*" -648- DISPLAY '         ENDOSSO ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($"         ENDOSSO {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -649- SUBTRACT 01 FROM WCONT-PARCELAS */
                WCONT_PARCELAS.Value = WCONT_PARCELAS - 01;

                /*" -651- GO TO 1500-NEXT. */

                M_1500_NEXT(); //GOTO
                return;
            }


            /*" -653- MOVE '15D' TO WNR-EXEC-SQL. */
            _.Move("15D", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -655- MOVE AGEAPOVG-NUM-APOLICE TO APOLICES-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -663- PERFORM M_1500_PROC_FATURAS_DB_SELECT_7 */

            M_1500_PROC_FATURAS_DB_SELECT_7();

            /*" -666- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -667- DISPLAY ' PROBLEMAS ACESSO APOLICE  ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO APOLICE  {DB.SQLCODE}");

                /*" -668- DISPLAY APOLICES-NUM-APOLICE */
                _.Display(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

                /*" -669- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -670- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -672- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -674- MOVE '15E' TO WNR-EXEC-SQL. */
            _.Move("15E", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -675- MOVE AGEAPOVG-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -677- MOVE AGEAPOVG-COD-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -690- PERFORM M_1500_PROC_FATURAS_DB_SELECT_8 */

            M_1500_PROC_FATURAS_DB_SELECT_8();

            /*" -693- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -694- DISPLAY ' PROBLEMAS ACESSO SUBGRUPO ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO SUBGRUPO {DB.SQLCODE}");

                /*" -695- DISPLAY SUBGVGAP-NUM-APOLICE */
                _.Display(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

                /*" -696- DISPLAY SUBGVGAP-COD-SUBGRUPO */
                _.Display(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

                /*" -697- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -698- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -700- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -702- MOVE '15F' TO WNR-EXEC-SQL. */
            _.Move("15F", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -703- MOVE AGEAPOVG-NUM-APOLICE TO PARCELAS-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

            /*" -704- MOVE ENDOSSOS-NUM-ENDOSSO TO PARCELAS-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

            /*" -706- MOVE ZEROS TO PARCELAS-NUM-PARCELA. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);

            /*" -718- PERFORM M_1500_PROC_FATURAS_DB_SELECT_9 */

            M_1500_PROC_FATURAS_DB_SELECT_9();

            /*" -721- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -722- DISPLAY ' PROBLEMAS ACESSO PARCELAS ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO PARCELAS {DB.SQLCODE}");

                /*" -723- DISPLAY PARCELAS-NUM-APOLICE */
                _.Display(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

                /*" -724- DISPLAY PARCELAS-NUM-ENDOSSO */
                _.Display(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

                /*" -725- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -726- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -728- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -730- MOVE '15G' TO WNR-EXEC-SQL. */
            _.Move("15G", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -731- MOVE PARCELAS-NUM-APOLICE TO PARCEHIS-NUM-APOLICE. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -732- MOVE PARCELAS-NUM-ENDOSSO TO PARCEHIS-NUM-ENDOSSO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -733- MOVE ZEROS TO PARCEHIS-NUM-PARCELA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

            /*" -735- MOVE PARCELAS-OCORR-HISTORICO TO PARCEHIS-OCORR-HISTORICO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -747- PERFORM M_1500_PROC_FATURAS_DB_SELECT_10 */

            M_1500_PROC_FATURAS_DB_SELECT_10();

            /*" -750- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -751- DISPLAY ' PROBLEMAS ACESSO PARCELAS_H ' SQLCODE */
                _.Display($" PROBLEMAS ACESSO PARCELAS_H {DB.SQLCODE}");

                /*" -752- DISPLAY PARCEHIS-NUM-APOLICE */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

                /*" -753- DISPLAY PARCEHIS-NUM-ENDOSSO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

                /*" -754- DISPLAY PARCEHIS-NUM-PARCELA */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

                /*" -755- DISPLAY PARCEHIS-OCORR-HISTORICO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

                /*" -756- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -757- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -759- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -760- IF PARCEHIS-DATA-QUITACAO EQUAL '9999-12-31' */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO == "9999-12-31")
            {

                /*" -761- DISPLAY 'DATA DE QUITACAO INVALIDA - AGENCTO RECUSADO ' */
                _.Display($"DATA DE QUITACAO INVALIDA - AGENCTO RECUSADO ");

                /*" -762- DISPLAY PARCEHIS-NUM-APOLICE */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

                /*" -763- DISPLAY PARCEHIS-NUM-ENDOSSO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

                /*" -764- DISPLAY PARCEHIS-NUM-PARCELA */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

                /*" -765- DISPLAY PARCEHIS-OCORR-HISTORICO */
                _.Display(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

                /*" -766- MOVE ZEROS TO WCONT-PARCELAS */
                _.Move(0, WCONT_PARCELAS);

                /*" -767- MOVE 'S' TO WFIM-FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                /*" -769- GO TO 1500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
                return;
            }


            /*" -770- IF AGEAPOVG-MATRIC-INDICADOR GREATER ZEROS */

            if (AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_MATRIC_INDICADOR > 00)
            {

                /*" -772- GO TO 1500-FUNDAO. */

                M_1500_FUNDAO(); //GOTO
                return;
            }


            /*" -773- MOVE AGEAPOVG-NUM-APOLICE TO COMISSOE-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_APOLICE);

            /*" -774- MOVE ENDOSSOS-NUM-ENDOSSO TO COMISSOE-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_ENDOSSO);

            /*" -775- MOVE ZEROS TO COMISSOE-NUM-CERTIFICADO. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_CERTIFICADO);

            /*" -776- MOVE ' ' TO COMISSOE-DAC-CERTIFICADO. */
            _.Move(" ", COMISSOE.DCLCOMISSOES.COMISSOE_DAC_CERTIFICADO);

            /*" -777- MOVE '0' TO COMISSOE-TIPO-SEGURADO. */
            _.Move("0", COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_SEGURADO);

            /*" -778- MOVE ZEROS TO COMISSOE-NUM-PARCELA. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_PARCELA);

            /*" -779- MOVE 1101 TO COMISSOE-COD-OPERACAO. */
            _.Move(1101, COMISSOE.DCLCOMISSOES.COMISSOE_COD_OPERACAO);

            /*" -780- MOVE AGEAPOVG-COD-AGENCIADOR TO COMISSOE-COD-PRODUTOR. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_AGENCIADOR, COMISSOE.DCLCOMISSOES.COMISSOE_COD_PRODUTOR);

            /*" -781- MOVE PARCELAS-OCORR-HISTORICO TO COMISSOE-OCORR-HISTORICO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO, COMISSOE.DCLCOMISSOES.COMISSOE_OCORR_HISTORICO);

            /*" -782- MOVE ENDOSSOS-COD-FONTE TO COMISSOE-COD-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, COMISSOE.DCLCOMISSOES.COMISSOE_COD_FONTE);

            /*" -783- MOVE SUBGVGAP-COD-CLIENTE TO COMISSOE-COD-CLIENTE. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE, COMISSOE.DCLCOMISSOES.COMISSOE_COD_CLIENTE);

            /*" -784- MOVE SISTEMAS-DATA-MOV-ABERTO TO COMISSOE-DATA-CALCULO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_CALCULO);

            /*" -786- MOVE 0 TO COMISSOE-NUM-RECIBO. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_RECIBO);

            /*" -788- MOVE '3' TO COMISSOE-TIPO-COMISSAO. */
            _.Move("3", COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_COMISSAO);

            /*" -789- MOVE 0 TO COMISSOE-QTD-PARCELAS. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_QTD_PARCELAS);

            /*" -790- MOVE AGEAPOVG-PERC-PAG-PARCELA TO COMISSOE-PCT-COM-CORRETOR. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR);

            /*" -791- MOVE 0 TO COMISSOE-PCT-DESC-PREMIO. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_DESC_PREMIO);

            /*" -792- MOVE AGEAPOVG-COD-SUBGRUPO TO COMISSOE-COD-SUBGRUPO. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_SUBGRUPO, COMISSOE.DCLCOMISSOES.COMISSOE_COD_SUBGRUPO);

            /*" -793- MOVE SISTEMAS-DATA-MOV-ABERTO TO COMISSOE-DATA-SELECAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_SELECAO);

            /*" -797- MOVE PARCEHIS-DATA-QUITACAO TO COMISSOE-DATA-QUITACAO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_QUITACAO);

            /*" -799- COMPUTE COMISSOE-VAL-COMISSAO = WPRM-AP * AGEAPOVG-PERC-PAG-PARCELA / 100. */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.Value = WPRM_AP * AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA / 100f;

            /*" -800- MOVE 81 TO COMISSOE-RAMO-COBERTURA. */
            _.Move(81, COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

            /*" -801- MOVE 0 TO COMISSOE-MODALI-COBERTURA. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA);

            /*" -803- MOVE WPRM-AP TO COMISSOE-VAL-BASICO. */
            _.Move(WPRM_AP, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO);

            /*" -804- IF WPRM-AP GREATER ZEROS */

            if (WPRM_AP > 00)
            {

                /*" -806- PERFORM 2000-GRAVA-COMISSAO THRU 2000-FIM. */

                M_2000_GRAVA_COMISSAO(true);

                M_2000_LOOP_TIME(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

            }


            /*" -808- COMPUTE COMISSOE-VAL-COMISSAO = WPRM-AP82 * AGEAPOVG-PERC-PAG-PARCELA / 100. */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.Value = WPRM_AP82 * AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA / 100f;

            /*" -809- MOVE 82 TO COMISSOE-RAMO-COBERTURA. */
            _.Move(82, COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

            /*" -810- MOVE 0 TO COMISSOE-MODALI-COBERTURA. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA);

            /*" -812- MOVE WPRM-AP82 TO COMISSOE-VAL-BASICO. */
            _.Move(WPRM_AP82, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO);

            /*" -813- IF WPRM-AP82 GREATER ZEROS */

            if (WPRM_AP82 > 00)
            {

                /*" -817- PERFORM 2000-GRAVA-COMISSAO THRU 2000-FIM. */

                M_2000_GRAVA_COMISSAO(true);

                M_2000_LOOP_TIME(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

            }


            /*" -819- COMPUTE COMISSOE-VAL-COMISSAO = WPRM-VG * AGEAPOVG-PERC-PAG-PARCELA / 100. */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.Value = WPRM_VG * AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA / 100f;

            /*" -820- MOVE 93 TO COMISSOE-RAMO-COBERTURA. */
            _.Move(93, COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

            /*" -821- MOVE 0 TO COMISSOE-MODALI-COBERTURA. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA);

            /*" -823- MOVE WPRM-VG TO COMISSOE-VAL-BASICO. */
            _.Move(WPRM_VG, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO);

            /*" -824- IF WPRM-VG GREATER ZEROS */

            if (WPRM_VG > 00)
            {

                /*" -826- PERFORM 2000-GRAVA-COMISSAO THRU 2000-FIM. */

                M_2000_GRAVA_COMISSAO(true);

                M_2000_LOOP_TIME(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

            }


            /*" -828- COMPUTE COMISSOE-VAL-COMISSAO = WPRM-VG77 * AGEAPOVG-PERC-PAG-PARCELA / 100. */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.Value = WPRM_VG77 * AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA / 100f;

            /*" -829- MOVE 77 TO COMISSOE-RAMO-COBERTURA. */
            _.Move(77, COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

            /*" -830- MOVE 0 TO COMISSOE-MODALI-COBERTURA. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA);

            /*" -832- MOVE WPRM-VG77 TO COMISSOE-VAL-BASICO. */
            _.Move(WPRM_VG77, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO);

            /*" -833- IF WPRM-VG77 GREATER ZEROS */

            if (WPRM_VG77 > 00)
            {

                /*" -835- PERFORM 2000-GRAVA-COMISSAO THRU 2000-FIM. */

                M_2000_GRAVA_COMISSAO(true);

                M_2000_LOOP_TIME(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

            }


            /*" -836- MOVE '1' TO AGEAPOVG-SITUACAO-AGENCTO. */
            _.Move("1", AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO);

            /*" -837- MOVE ENDOSSOS-NUM-ENDOSSO TO AGEAPOVG-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO);

            /*" -838- MOVE 'S' TO WFIM-FATURAS. */
            _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

            /*" -838- GO TO 1500-FIM. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
            return;

        }

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-1 */
        public void M_1500_PROC_FATURAS_DB_SELECT_1()
        {
            /*" -471- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , DATA_PROPOSTA , DATA_LIBERACAO , DATA_EMISSAO , NUM_RCAP , VAL_RCAP , BCO_RCAP , AGE_RCAP , DAC_RCAP , TIPO_RCAP , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , DATA_INIVIGENCIA , DATA_TERVIGENCIA , PLANO_SEGURO , PCT_ENTRADA , PCT_ADIC_FRACIO , QTD_DIAS_PRIMEIRA , QTD_PARCELAS , QTD_PRESTACOES , QTD_ITENS , COD_TEXTO_PADRAO , COD_ACEITACAO , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SIT_REGISTRO INTO :ENDOSSOS-NUM-APOLICE , :ENDOSSOS-NUM-ENDOSSO , :ENDOSSOS-COD-SUBGRUPO , :ENDOSSOS-COD-FONTE , :ENDOSSOS-NUM-PROPOSTA , :ENDOSSOS-DATA-PROPOSTA , :ENDOSSOS-DATA-LIBERACAO , :ENDOSSOS-DATA-EMISSAO , :ENDOSSOS-NUM-RCAP , :ENDOSSOS-VAL-RCAP , :ENDOSSOS-BCO-RCAP , :ENDOSSOS-AGE-RCAP , :ENDOSSOS-DAC-RCAP , :ENDOSSOS-TIPO-RCAP , :ENDOSSOS-BCO-COBRANCA , :ENDOSSOS-AGE-COBRANCA , :ENDOSSOS-DAC-COBRANCA , :ENDOSSOS-DATA-INIVIGENCIA , :ENDOSSOS-DATA-TERVIGENCIA , :ENDOSSOS-PLANO-SEGURO , :ENDOSSOS-PCT-ENTRADA , :ENDOSSOS-PCT-ADIC-FRACIO , :ENDOSSOS-QTD-DIAS-PRIMEIRA, :ENDOSSOS-QTD-PARCELAS , :ENDOSSOS-QTD-PRESTACOES , :ENDOSSOS-QTD-ITENS , :ENDOSSOS-COD-TEXTO-PADRAO , :ENDOSSOS-COD-ACEITACAO , :ENDOSSOS-COD-MOEDA-IMP , :ENDOSSOS-COD-MOEDA-PRM , :ENDOSSOS-TIPO-ENDOSSO , :ENDOSSOS-COD-USUARIO , :ENDOSSOS-OCORR-ENDERECO , :ENDOSSOS-SIT-REGISTRO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO END-EXEC. */

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
            /*" -843- MOVE APOLICES-COD-PRODUTO TO FUNCOMVA-CODIGO-PRODUTO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_CODIGO_PRODUTO);

            /*" -844- MOVE ZEROS TO FUNCOMVA-NUM-CERTIFICADO. */
            _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_CERTIFICADO);

            /*" -845- MOVE ZEROS TO FUNCOMVA-NUM-PROPOSTA-AZUL. */
            _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_PROPOSTA_AZUL);

            /*" -846- MOVE ZEROS TO FUNCOMVA-NUM-TERMO. */
            _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TERMO);

            /*" -847- MOVE '0' TO FUNCOMVA-SITUACAO. */
            _.Move("0", FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO);

            /*" -848- MOVE 1101 TO FUNCOMVA-COD-OPERACAO. */
            _.Move(1101, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_OPERACAO);

            /*" -850- MOVE ENDOSSOS-COD-FONTE TO FUNCOMVA-COD-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_FONTE);

            /*" -851- IF ENDOSSOS-AGE-PRODUTORA EQUAL ZEROS */

            if (ENDOSSOS_AGE_PRODUTORA == 00)
            {

                /*" -853- MOVE ENDOSSOS-AGE-RCAP TO ENDOSSOS-AGE-PRODUTORA. */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP, ENDOSSOS_AGE_PRODUTORA);
            }


            /*" -854- MOVE ENDOSSOS-AGE-PRODUTORA TO FUNCOMVA-COD-AGENCIA. */
            _.Move(ENDOSSOS_AGE_PRODUTORA, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_AGENCIA);

            /*" -855- MOVE SUBGVGAP-COD-CLIENTE TO FUNCOMVA-COD-CLIENTE. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_CLIENTE);

            /*" -860- MOVE AGEAPOVG-MATRIC-INDICADOR TO FUNCOMVA-NUM-MATRI-VENDEDOR. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_MATRIC_INDICADOR, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_MATRI_VENDEDOR);

            /*" -862- COMPUTE WTOT-PRM-AP = WPRM-AP + WPRM-AP82. */
            WTOT_PRM_AP.Value = WPRM_AP + WPRM_AP82;

            /*" -864- COMPUTE FUNCOMVA-VAL-COMISSAO-AP = WTOT-PRM-AP * AGEAPOVG-PERC-PAG-PARCELA / 100. */
            FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_COMISSAO_AP.Value = WTOT_PRM_AP * AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA / 100f;

            /*" -868- MOVE WTOT-PRM-AP TO FUNCOMVA-VAL-BASICO-AP. */
            _.Move(WTOT_PRM_AP, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_AP);

            /*" -870- COMPUTE WTOT-PRM-VG = WPRM-VG + WPRM-VG77. */
            WTOT_PRM_VG.Value = WPRM_VG + WPRM_VG77;

            /*" -872- COMPUTE FUNCOMVA-VAL-COMISSAO-VG = WTOT-PRM-VG * AGEAPOVG-PERC-PAG-PARCELA / 100. */
            FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_COMISSAO_VG.Value = WTOT_PRM_VG * AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA / 100f;

            /*" -874- MOVE WTOT-PRM-VG TO FUNCOMVA-VAL-BASICO-VG. */
            _.Move(WTOT_PRM_VG, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_VG);

            /*" -875- MOVE PARCEHIS-DATA-QUITACAO TO FUNCOMVA-DATA-QUITACAO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_QUITACAO);

            /*" -876- MOVE AGEAPOVG-PERC-PAG-PARCELA TO FUNCOMVA-PCCOMIND. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_PERC_PAG_PARCELA, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_PCCOMIND);

            /*" -877- MOVE ZEROS TO FUNCOMVA-PCCOMGER. */
            _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_PCCOMGER);

            /*" -878- MOVE ZEROS TO FUNCOMVA-PCCOMSUP. */
            _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_PCCOMSUP);

            /*" -879- MOVE SISTEMAS-DATA-MOV-ABERTO TO FUNCOMVA-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_MOVIMENTO);

            /*" -881- MOVE 'VG1706B' TO FUNCOMVA-COD-USUARIO. */
            _.Move("VG1706B", FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_USUARIO);

            /*" -882- MOVE AGEAPOVG-NUM-APOLICE TO FUNCOMVA-NUM-APOLICE. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_APOLICE);

            /*" -883- MOVE AGEAPOVG-COD-SUBGRUPO TO FUNCOMVA-COD-SUBGRUPO. */
            _.Move(AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_SUBGRUPO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_SUBGRUPO);

            /*" -884- MOVE ENDOSSOS-NUM-ENDOSSO TO FUNCOMVA-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_ENDOSSO);

            /*" -886- MOVE PARCELAS-NUM-TITULO TO FUNCOMVA-NUM-TITULO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TITULO);

            /*" -888- PERFORM 3000-GRAVA-FUNDAO THRU 3000-FIM. */

            M_3000_GRAVA_FUNDAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/


            /*" -889- MOVE '1' TO AGEAPOVG-SITUACAO-AGENCTO. */
            _.Move("1", AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_SITUACAO_AGENCTO);

            /*" -890- MOVE ENDOSSOS-NUM-ENDOSSO TO AGEAPOVG-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_ENDOSSO);

            /*" -891- MOVE 'S' TO WFIM-FATURAS. */
            _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

            /*" -891- GO TO 1500-FIM. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/ //GOTO
            return;

        }

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-2 */
        public void M_1500_PROC_FATURAS_DB_SELECT_2()
        {
            /*" -513- EXEC SQL SELECT VAL_VENDA INTO :MOEDACOT-VAL-VENDA FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = :ENDOSSOS-COD-MOEDA-PRM AND DATA_INIVIGENCIA <= :ENDOSSOS-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :ENDOSSOS-DATA-INIVIGENCIA END-EXEC. */

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
            /*" -894- PERFORM 1510-FETCH THRU 1510-FIM. */

            M_1510_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1510_FIM*/


        }

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-3 */
        public void M_1500_PROC_FATURAS_DB_SELECT_3()
        {
            /*" -540- EXEC SQL SELECT PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND NUM_ITEM = 0 AND OCORR_HISTORICO = 1 AND RAMO_COBERTURA = 93 AND COD_COBERTURA = 0 END-EXEC. */

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
            /*" -570- EXEC SQL SELECT PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND NUM_ITEM = 0 AND OCORR_HISTORICO = 1 AND RAMO_COBERTURA = 77 AND COD_COBERTURA = 0 END-EXEC. */

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
            /*" -904- MOVE '151' TO WNR-EXEC-SQL. */
            _.Move("151", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -908- PERFORM M_1510_FETCH_DB_FETCH_1 */

            M_1510_FETCH_DB_FETCH_1();

            /*" -911- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -912- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -913- MOVE 'S' TO WFIM-FATURAS */
                    _.Move("S", AREA_DE_WORK.WFIM_FATURAS);

                    /*" -914- ELSE */
                }
                else
                {


                    /*" -914- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-1510-FETCH-DB-FETCH-1 */
        public void M_1510_FETCH_DB_FETCH_1()
        {
            /*" -908- EXEC SQL FETCH FATURASC INTO :HISCONPA-NUM-PARCELA, :HISCONPA-NUM-ENDOSSO END-EXEC. */

            if (FATURASC.Fetch())
            {
                _.Move(FATURASC.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(FATURASC.HISCONPA_NUM_ENDOSSO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);
            }

        }

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-5 */
        public void M_1500_PROC_FATURAS_DB_SELECT_5()
        {
            /*" -600- EXEC SQL SELECT PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND NUM_ITEM = 0 AND OCORR_HISTORICO = 1 AND RAMO_COBERTURA = 81 AND COD_COBERTURA = 0 END-EXEC. */

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
            /*" -630- EXEC SQL SELECT PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND NUM_ITEM = 0 AND OCORR_HISTORICO = 1 AND RAMO_COBERTURA = 82 AND COD_COBERTURA = 0 END-EXEC. */

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
            /*" -922- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

        }

        [StopWatch]
        /*" M-1500-PROC-FATURAS-DB-SELECT-7 */
        public void M_1500_PROC_FATURAS_DB_SELECT_7()
        {
            /*" -663- EXEC SQL SELECT COD_PRODUTO INTO :APOLICES-COD-PRODUTO FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE END-EXEC. */

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
            /*" -927- ACCEPT WTIME-DAY FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -928- MOVE CORR WTIME-DAY1 TO WTIME-DAYR. */
            _.MoveCorr(AREA_DE_WORK.WTIME_DAY1, AREA_DE_WORK.WTIME_DAYR);

            /*" -930- MOVE WTIME-DAYR TO COMISSOE-HORA-OPERACAO. */
            _.Move(AREA_DE_WORK.WTIME_DAYR, COMISSOE.DCLCOMISSOES.COMISSOE_HORA_OPERACAO);

            /*" -994- PERFORM M_2000_LOOP_TIME_DB_INSERT_1 */

            M_2000_LOOP_TIME_DB_INSERT_1();

            /*" -997- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -998- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -999- GO TO 2000-LOOP-TIME */
                    new Task(() => M_2000_LOOP_TIME()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1000- ELSE */
                }
                else
                {


                    /*" -1001- DISPLAY 'ERRO INSERT COMISSOES ' SQLCODE */
                    _.Display($"ERRO INSERT COMISSOES {DB.SQLCODE}");

                    /*" -1002- DISPLAY COMISSOE-NUM-APOLICE */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_NUM_APOLICE);

                    /*" -1003- DISPLAY COMISSOE-NUM-ENDOSSO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_NUM_ENDOSSO);

                    /*" -1004- DISPLAY COMISSOE-NUM-CERTIFICADO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_NUM_CERTIFICADO);

                    /*" -1005- DISPLAY COMISSOE-DAC-CERTIFICADO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_DAC_CERTIFICADO);

                    /*" -1006- DISPLAY COMISSOE-TIPO-SEGURADO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_SEGURADO);

                    /*" -1007- DISPLAY COMISSOE-NUM-PARCELA */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_NUM_PARCELA);

                    /*" -1008- DISPLAY COMISSOE-COD-OPERACAO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_COD_OPERACAO);

                    /*" -1009- DISPLAY COMISSOE-COD-PRODUTOR */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_COD_PRODUTOR);

                    /*" -1010- DISPLAY COMISSOE-RAMO-COBERTURA */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

                    /*" -1011- DISPLAY COMISSOE-MODALI-COBERTURA */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA);

                    /*" -1012- DISPLAY COMISSOE-OCORR-HISTORICO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_OCORR_HISTORICO);

                    /*" -1013- DISPLAY COMISSOE-COD-FONTE */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_COD_FONTE);

                    /*" -1014- DISPLAY COMISSOE-COD-CLIENTE */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_COD_CLIENTE);

                    /*" -1015- DISPLAY COMISSOE-VAL-COMISSAO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO);

                    /*" -1016- DISPLAY COMISSOE-DATA-CALCULO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_DATA_CALCULO);

                    /*" -1017- DISPLAY COMISSOE-NUM-RECIBO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_NUM_RECIBO);

                    /*" -1018- DISPLAY COMISSOE-VAL-BASICO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO);

                    /*" -1019- DISPLAY COMISSOE-TIPO-COMISSAO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_COMISSAO);

                    /*" -1020- DISPLAY COMISSOE-QTD-PARCELAS */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_QTD_PARCELAS);

                    /*" -1021- DISPLAY COMISSOE-PCT-COM-CORRETOR */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR);

                    /*" -1022- DISPLAY COMISSOE-PCT-DESC-PREMIO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_PCT_DESC_PREMIO);

                    /*" -1023- DISPLAY COMISSOE-COD-SUBGRUPO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_COD_SUBGRUPO);

                    /*" -1024- DISPLAY COMISSOE-HORA-OPERACAO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_HORA_OPERACAO);

                    /*" -1025- DISPLAY COMISSOE-DATA-SELECAO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_DATA_SELECAO);

                    /*" -1026- DISPLAY COMISSOE-DATA-QUITACAO */
                    _.Display(COMISSOE.DCLCOMISSOES.COMISSOE_DATA_QUITACAO);

                    /*" -1028- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1030- ADD 1 TO AC-I-COMISSAO. */
            AREA_DE_WORK.AC_I_COMISSAO.Value = AREA_DE_WORK.AC_I_COMISSAO + 1;

            /*" -1030- ADD 1 TO AC-I-AGENCIAMENTO. */
            AREA_DE_WORK.AC_I_AGENCIAMENTO.Value = AREA_DE_WORK.AC_I_AGENCIAMENTO + 1;

        }

        [StopWatch]
        /*" M-2000-LOOP-TIME-DB-INSERT-1 */
        public void M_2000_LOOP_TIME_DB_INSERT_1()
        {
            /*" -994- EXEC SQL INSERT INTO SEGUROS.COMISSOES (NUM_APOLICE , NUM_ENDOSSO , NUM_CERTIFICADO , DAC_CERTIFICADO , TIPO_SEGURADO , NUM_PARCELA , COD_OPERACAO , COD_PRODUTOR , RAMO_COBERTURA , MODALI_COBERTURA , OCORR_HISTORICO , COD_FONTE , COD_CLIENTE , VAL_COMISSAO , DATA_CALCULO , NUM_RECIBO , VAL_BASICO , TIPO_COMISSAO , QTD_PARCELAS , PCT_COM_CORRETOR , PCT_DESC_PREMIO , COD_SUBGRUPO , HORA_OPERACAO , DATA_MOVIMENTO , DATA_SELECAO , COD_EMPRESA , COD_PREPOSTO , TIMESTAMP , NUM_BILHETE , VAL_VARMON , DATA_QUITACAO) VALUES (:COMISSOE-NUM-APOLICE , :COMISSOE-NUM-ENDOSSO , :COMISSOE-NUM-CERTIFICADO , :COMISSOE-DAC-CERTIFICADO , :COMISSOE-TIPO-SEGURADO , :COMISSOE-NUM-PARCELA , :COMISSOE-COD-OPERACAO , :COMISSOE-COD-PRODUTOR , :COMISSOE-RAMO-COBERTURA , :COMISSOE-MODALI-COBERTURA , :COMISSOE-OCORR-HISTORICO , :COMISSOE-COD-FONTE , :COMISSOE-COD-CLIENTE , :COMISSOE-VAL-COMISSAO , :COMISSOE-DATA-CALCULO , :COMISSOE-NUM-RECIBO , :COMISSOE-VAL-BASICO , :COMISSOE-TIPO-COMISSAO , :COMISSOE-QTD-PARCELAS , :COMISSOE-PCT-COM-CORRETOR , :COMISSOE-PCT-DESC-PREMIO , :COMISSOE-COD-SUBGRUPO , :COMISSOE-HORA-OPERACAO , NULL , :COMISSOE-DATA-SELECAO , NULL , NULL , CURRENT TIMESTAMP , NULL , NULL , :COMISSOE-DATA-QUITACAO) END-EXEC. */

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
            /*" -690- EXEC SQL SELECT PERI_FATURAMENTO , COD_CLIENTE , COD_PAG_ANGARIACAO INTO :SUBGVGAP-PERI-FATURAMENTO , :SUBGVGAP-COD-CLIENTE , :SUBGVGAP-COD-PAG-ANGARIACAO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO END-EXEC. */

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
            /*" -718- EXEC SQL SELECT NUM_TITULO , OCORR_HISTORICO INTO :PARCELAS-NUM-TITULO , :PARCELAS-OCORR-HISTORICO FROM SEGUROS.PARCELAS WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO AND NUM_PARCELA = :PARCELAS-NUM-PARCELA END-EXEC. */

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
            /*" -1040- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1092- PERFORM M_3000_GRAVA_FUNDAO_DB_INSERT_1 */

            M_3000_GRAVA_FUNDAO_DB_INSERT_1();

            /*" -1095- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1096- DISPLAY 'ERRO INSERT FUNDAO    ' SQLCODE */
                _.Display($"ERRO INSERT FUNDAO    {DB.SQLCODE}");

                /*" -1097- DISPLAY FUNCOMVA-NUM-APOLICE */
                _.Display(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_APOLICE);

                /*" -1098- DISPLAY FUNCOMVA-COD-SUBGRUPO */
                _.Display(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_SUBGRUPO);

                /*" -1099- DISPLAY FUNCOMVA-NUM-ENDOSSO */
                _.Display(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_ENDOSSO);

                /*" -1100- DISPLAY FUNCOMVA-NUM-TITULO */
                _.Display(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TITULO);

                /*" -1101- DISPLAY FUNCOMVA-NUM-MATRI-VENDEDOR */
                _.Display(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_MATRI_VENDEDOR);

                /*" -1103- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1105- ADD 1 TO AC-I-FUNDAO. */
            AREA_DE_WORK.AC_I_FUNDAO.Value = AREA_DE_WORK.AC_I_FUNDAO + 1;

            /*" -1105- ADD 1 TO AC-I-AGENCIAMENTO. */
            AREA_DE_WORK.AC_I_AGENCIAMENTO.Value = AREA_DE_WORK.AC_I_AGENCIAMENTO + 1;

        }

        [StopWatch]
        /*" M-3000-GRAVA-FUNDAO-DB-INSERT-1 */
        public void M_3000_GRAVA_FUNDAO_DB_INSERT_1()
        {
            /*" -1092- EXEC SQL INSERT INTO SEGUROS.FUNDO_COMISSAO_VA (CODIGO_PRODUTO , NUM_CERTIFICADO , NUM_PROPOSTA_AZUL , NUM_TERMO , SITUACAO , COD_OPERACAO , COD_FONTE , COD_AGENCIA , COD_CLIENTE , NUM_MATRI_VENDEDOR , VAL_BASICO_VG , VAL_BASICO_AP , VAL_COMISSAO_VG , VAL_COMISSAO_AP , DATA_QUITACAO , PCCOMIND , PCCOMGER , PCCOMSUP , DATA_MOVIMENTO , COD_USUARIO , TIMESTAMP , NUM_APOLICE , COD_SUBGRUPO , NUM_ENDOSSO , NUM_TITULO ) VALUES (:FUNCOMVA-CODIGO-PRODUTO , :FUNCOMVA-NUM-CERTIFICADO , :FUNCOMVA-NUM-PROPOSTA-AZUL , :FUNCOMVA-NUM-TERMO , :FUNCOMVA-SITUACAO , :FUNCOMVA-COD-OPERACAO , :FUNCOMVA-COD-FONTE , :FUNCOMVA-COD-AGENCIA , :FUNCOMVA-COD-CLIENTE , :FUNCOMVA-NUM-MATRI-VENDEDOR , :FUNCOMVA-VAL-BASICO-VG , :FUNCOMVA-VAL-BASICO-AP , :FUNCOMVA-VAL-COMISSAO-VG , :FUNCOMVA-VAL-COMISSAO-AP , :FUNCOMVA-DATA-QUITACAO , :FUNCOMVA-PCCOMIND , :FUNCOMVA-PCCOMGER , :FUNCOMVA-PCCOMSUP , :FUNCOMVA-DATA-MOVIMENTO , :FUNCOMVA-COD-USUARIO , CURRENT TIMESTAMP , :FUNCOMVA-NUM-APOLICE , :FUNCOMVA-COD-SUBGRUPO , :FUNCOMVA-NUM-ENDOSSO , :FUNCOMVA-NUM-TITULO ) END-EXEC. */

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
            /*" -747- EXEC SQL SELECT VALUE(DATA_QUITACAO, DATE( '9999-12-31' )) INTO :PARCEHIS-DATA-QUITACAO FROM SEGUROS.PARCELA_HISTORICO WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA AND OCORR_HISTORICO = :PARCEHIS-OCORR-HISTORICO AND COD_OPERACAO BETWEEN 200 AND 299 END-EXEC. */

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
            /*" -1117- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA_REL);

            /*" -1118- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -1119- MOVE WDAT-REL-MES TO WDAT-LIT-MES. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -1121- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -1122- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1123- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1124- DISPLAY '*   VG1706B - ATUALIZACAO DB COMISSOES     *' */
            _.Display($"*   VG1706B - ATUALIZACAO DB COMISSOES     *");

            /*" -1125- DISPLAY '*   -------   ----------- -- ---------     *' */
            _.Display($"*   -------   ----------- -- ---------     *");

            /*" -1126- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1127- DISPLAY '*   NAO HOUVE MOVIMENTACAO                 *' */
            _.Display($"*   NAO HOUVE MOVIMENTACAO                 *");

            /*" -1129- DISPLAY '*   NESTA DATA ' WDAT-REL-LIT '                    *' */

            $"*   NESTA DATA {AREA_DE_WORK.WDAT_REL_LIT}                    *"
            .Display();

            /*" -1130- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1130- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -1142- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1144- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1145- DISPLAY 'APOLICE ' AGEAPOVG-NUM-APOLICE. */
            _.Display($"APOLICE {AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_APOLICE}");

            /*" -1146- DISPLAY 'SUBGR.  ' AGEAPOVG-COD-SUBGRUPO. */
            _.Display($"SUBGR.  {AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_SUBGRUPO}");

            /*" -1147- DISPLAY 'INDIC.  ' AGEAPOVG-MATRIC-INDICADOR. */
            _.Display($"INDIC.  {AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_MATRIC_INDICADOR}");

            /*" -1148- DISPLAY 'AGENC.  ' AGEAPOVG-COD-AGENCIADOR. */
            _.Display($"AGENC.  {AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_COD_AGENCIADOR}");

            /*" -1149- DISPLAY 'PARCE.  ' AGEAPOVG-NUM-PARCELA. */
            _.Display($"PARCE.  {AGEAPOVG.DCLAGENCTO_APOL_VGAP.AGEAPOVG_NUM_PARCELA}");

            /*" -1151- DISPLAY 'ENDOS.  ' ENDOSSOS-NUM-ENDOSSO. */
            _.Display($"ENDOS.  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

            /*" -1151- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1153- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1156- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1156- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}