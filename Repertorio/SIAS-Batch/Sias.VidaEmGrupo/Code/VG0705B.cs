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
using Sias.VidaEmGrupo.DB2.VG0705B;

namespace Code
{
    public class VG0705B
    {
        public bool IsCall { get; set; }

        public VG0705B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *   CALCULA E GERA COMISSOES DE AGENCIAMENTO PARA AS APOLICES    *      */
        /*"      *     DO VG/APC (EXCETO VIDAZUL E PREFERENCIAL VIDA)             *      */
        /*"      ******************************************************************      */
        /*"      *                                 ALEXANDRE F FONSECA 26.10.94   *      */
        /*"      *                                                                *      */
        /*"      *   O PROGRAMA CALCULA AS COMISSOES DE AGENCIAMENTO DAS APOLICES *      */
        /*"      *   A PARTIR DA TABELA V0MOVIMENTO E GRAVA V0COMISSAO            *      */
        /*"      *   A TABELA V0COMISSAO.                                         *      */
        /*"      *                                                                *      */
        /*"      *   SAO SELECIONADAS TODAS AS INCLUSOES E AUMENTOS DE CAPITAL    *      */
        /*"      *   A PEDIDO COM DATA DE INCLUSAO = DATA DO SISTEMA 'VG'. OS     *      */
        /*"      *   AUMENTOS COLETIVOS NAO GERAM COMISSAO.                       *      */
        /*"      *                                                                *      */
        /*"      *   A COMISSAO INCIDIRA SOBRE OS PREMIOS (INCLUSAO) OU SOBRE     *      */
        /*"      *   AS DIFERENCAS DE PREMIO (AUMENTOS) LIQUIDOS DE IOF (2%).     *      */
        /*"      *                                                                *      */
        /*"      *   AS COMISSOES DA APOLICE DIRECIONADAS PARA A SASSE NAO        *      */
        /*"      *   IRAO GERAR COMISSOES.                                        *      */
        /*"      *                                                                *      */
        /*"      *   A EMISSAO DAS COMISSOES (PAGAMENTO) SERAO PROCESSADAS TODOS  *      */
        /*"      *   OS DIAS SOBRE O MOVIMENTO DIGITADO.                          *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"JV103 *VERSAO 03: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV103 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV103 *           - PROCURAR POR JV103                                 *      */
        /*"JV103 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - HIST 181.585                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 25/01/1999 - FONSECA (PROCURE POR AF0199)        *      */
        /*"      *                                                                *      */
        /*"      *      O PROGRAMA NAO PROCESSA MOVIMENTOS DO FEDERAL PLUS,       *      */
        /*"      *      APOLICE 0109700000028.                                    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  SQL-NOT-NULL                 PIC S9(004)     COMP VALUE +1.*/
        public IntBasis SQL_NOT_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +1);
        /*"01  SQL-DTMOVABE                 PIC  X(010).*/
        public StringBasis SQL_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SQL-NUM-APOL                 PIC S9(013)     COMP-3.*/
        public IntBasis SQL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  SQL-COD-SUB                  PIC S9(004)     COMP.*/
        public IntBasis SQL_COD_SUB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-COD-FONTE                PIC S9(004)     COMP.*/
        public IntBasis SQL_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-PROPOSTA                 PIC S9(009)     COMP.*/
        public IntBasis SQL_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  SQL-TIPO-SEG                 PIC  X(001).*/
        public StringBasis SQL_TIPO_SEG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  SQL-NUM-CERT                 PIC S9(015)     COMP-3.*/
        public IntBasis SQL_NUM_CERT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  SQL-DAC-CERT                 PIC  X(001).*/
        public StringBasis SQL_DAC_CERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  SQL-COD-CLIE                 PIC S9(009)     COMP.*/
        public IntBasis SQL_COD_CLIE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  SQL-COD-AGEN                 PIC S9(009)     COMP.*/
        public IntBasis SQL_COD_AGEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  SQL-PRM-VG                   PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-PRM-AP                   PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-COD-OPERAC               PIC S9(004)     COMP.*/
        public IntBasis SQL_COD_OPERAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-DATSEL                   PIC  X(010).*/
        public StringBasis SQL_DATSEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SQL-PCT-AGENC                PIC S9(003)V99  COMP-3.*/
        public DoubleBasis SQL_PCT_AGENC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01  SQL-VLCOMIS                  PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-VALBAS                   PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_VALBAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-RAMOFR                   PIC S9(004)     COMP.*/
        public IntBasis SQL_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-PCCOMCOR                 PIC S9(003)V99  COMP-3.*/
        public DoubleBasis SQL_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01  SQL-HORAOPER                 PIC  X(008).*/
        public StringBasis SQL_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  SQL-NUMBIL                   PIC S9(015)     COMP-3.*/
        public IntBasis SQL_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  SQL-NUMBILI                  PIC S9(004)     COMP.*/
        public IntBasis SQL_NUMBILI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-TIPAPO                   PIC  X(001).*/
        public StringBasis SQL_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01           AREA-DE-WORK.*/
        public VG0705B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0705B_AREA_DE_WORK();
        public class VG0705B_AREA_DE_WORK : VarBasis
        {
            /*"    05 WS-SEM-PLANO            PIC  9(001).*/
            public IntBasis WS_SEM_PLANO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05 WS-APOL-ANT             PIC S9(013)     COMP-3.*/
            public IntBasis WS_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05 WS-SUBGR-ANT            PIC S9(004)     COMP.*/
            public IntBasis WS_SUBGR_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05       WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05       WFIM-V0MOVIMENTO  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05       AC-L-V0MOVIMENTO  PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V0MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       AC-I-V0COMISSAO   PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0COMISSAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05       FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VG0705B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VG0705B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VG0705B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VG0705B_FILLER_0 : VarBasis
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

                public _REDEF_VG0705B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG0705B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VG0705B_WDAT_REL_LIT();
            public class VG0705B_WDAT_REL_LIT : VarBasis
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
                /*"    05       W01DTSQL.*/
            }
            public VG0705B_W01DTSQL W01DTSQL { get; set; } = new VG0705B_W01DTSQL();
            public class VG0705B_W01DTSQL : VarBasis
            {
                /*"      10     W01AASQL          PIC  9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     W01T1SQL          PIC  X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     W01MMSQL          PIC  9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     W01T2SQL          PIC  X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     W01DDSQL          PIC  9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       WTIME-DAY         PIC  99999999.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99999999."));
            /*"    05       WTIME-DAY1        REDEFINES      WTIME-DAY.*/
            private _REDEF_VG0705B_WTIME_DAY1 _wtime_day1 { get; set; }
            public _REDEF_VG0705B_WTIME_DAY1 WTIME_DAY1
            {
                get { _wtime_day1 = new _REDEF_VG0705B_WTIME_DAY1(); _.Move(WTIME_DAY, _wtime_day1); VarBasis.RedefinePassValue(WTIME_DAY, _wtime_day1, WTIME_DAY); _wtime_day1.ValueChanged += () => { _.Move(_wtime_day1, WTIME_DAY); }; return _wtime_day1; }
                set { VarBasis.RedefinePassValue(value, _wtime_day1, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VG0705B_WTIME_DAY1 : VarBasis
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

                public _REDEF_VG0705B_WTIME_DAY1()
                {
                    WTIME_HORA.ValueChanged += OnValueChanged;
                    WTIME_MINU.ValueChanged += OnValueChanged;
                    WTIME_SEGU.ValueChanged += OnValueChanged;
                    WTIME_CCCC.ValueChanged += OnValueChanged;
                }

            }
            public VG0705B_WTIME_DAYR WTIME_DAYR { get; set; } = new VG0705B_WTIME_DAYR();
            public class VG0705B_WTIME_DAYR : VarBasis
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
            public VG0705B_WABEND WABEND { get; set; } = new VG0705B_WABEND();
            public class VG0705B_WABEND : VarBasis
            {
                /*"      10    FILLER              PIC  X(010) VALUE           ' VG0705B'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0705B");
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


        public VG0705B_V0MOVIMENTO V0MOVIMENTO { get; set; } = new VG0705B_V0MOVIMENTO();
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
            /*" -157- DISPLAY ' ' */
            _.Display($" ");

            /*" -159- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -160- DISPLAY 'PROGRAMA VG0705B' */
            _.Display($"PROGRAMA VG0705B");

            /*" -167- DISPLAY 'VERSAO V.03 - DEMANDA 259990 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"VERSAO V.03 - DEMANDA 259990 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -169- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -175- DISPLAY ' ' */
            _.Display($" ");

            /*" -181- MOVE '9999-12-31' TO SQL-DATSEL. */
            _.Move("9999-12-31", SQL_DATSEL);

            /*" -183- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -188- PERFORM M_0000_INICIO_DB_SELECT_1 */

            M_0000_INICIO_DB_SELECT_1();

            /*" -191- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -192- DISPLAY '*** VG0705B *** SISTEMA VG NAO CADASTRADO' */
                _.Display($"*** VG0705B *** SISTEMA VG NAO CADASTRADO");

                /*" -198- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -200- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -227- PERFORM M_0000_INICIO_DB_DECLARE_1 */

            M_0000_INICIO_DB_DECLARE_1();

            /*" -231- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -232- DISPLAY '*** VG0705B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VG0705B *** ABRINDO CURSOR ...");

            /*" -232- PERFORM M_0000_INICIO_DB_OPEN_1 */

            M_0000_INICIO_DB_OPEN_1();

            /*" -240- PERFORM 1100-FETCH THRU 1100-FIM. */

            M_1100_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


            /*" -241- IF WFIM-V0MOVIMENTO EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V0MOVIMENTO == "S")
            {

                /*" -242- PERFORM 9000-ENCERRA-SEM-MOVTO THRU 9000-FIM */

                M_9000_ENCERRA_SEM_MOVTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


                /*" -244- GO TO 0002-FINALIZA. */

                M_0002_FINALIZA(); //GOTO
                return;
            }


            /*" -245- DISPLAY '*** VG0705B *** PROCESSANDO ...' . */
            _.Display($"*** VG0705B *** PROCESSANDO ...");

            /*" -248- PERFORM M-1000-PROCESSA-MOVIMENTO THRU 1000-FIM UNTIL WFIM-V0MOVIMENTO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0MOVIMENTO == "S"))
            {

                M_1000_PROCESSA_MOVIMENTO(true);

                M_1000_PROC_COMIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

            }

            /*" -250- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -264- PERFORM M_0000_INICIO_DB_UPDATE_1 */

            M_0000_INICIO_DB_UPDATE_1();

            /*" -267- DISPLAY '*** VG0705B *** MOV LIDOS       ' AC-L-V0MOVIMENTO. */
            _.Display($"*** VG0705B *** MOV LIDOS       {AREA_DE_WORK.AC_L_V0MOVIMENTO}");

            /*" -267- DISPLAY '*** VG0705B *** COMIS INSERIDAS ' AC-I-V0COMISSAO. */
            _.Display($"*** VG0705B *** COMIS INSERIDAS {AREA_DE_WORK.AC_I_V0COMISSAO}");

        }

        [StopWatch]
        /*" M-0000-INICIO-DB-SELECT-1 */
        public void M_0000_INICIO_DB_SELECT_1()
        {
            /*" -188- EXEC SQL SELECT DTMOVABE INTO :SQL-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var m_0000_INICIO_DB_SELECT_1_Query1 = new M_0000_INICIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_INICIO_DB_SELECT_1_Query1.Execute(m_0000_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_DTMOVABE, SQL_DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-0000-INICIO-DB-DECLARE-1 */
        public void M_0000_INICIO_DB_DECLARE_1()
        {
            /*" -227- EXEC SQL DECLARE V0MOVIMENTO CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, COD_CLIENTE, COD_AGENCIADOR, PRM_VG_ATU - PRM_VG_ANT, PRM_AP_ATU - PRM_AP_ANT, COD_OPERACAO FROM SEGUROS.V0MOVIMENTO WHERE DATA_INCLUSAO = :SQL-DTMOVABE AND SIT_REGISTRO IN ( '0' , '1' ) AND NUM_APOLICE NOT IN (93010000890, 97010000889, 0109300000027, 109700000021,109700000022,109700000023, 109700000033, 109700000028,109300000550,109300000559, 3009300000559) AND COD_AGENCIADOR NOT IN (0, 999105) AND (COD_OPERACAO BETWEEN 0100 AND 0199 OR COD_OPERACAO BETWEEN 0800 AND 0890) AND COD_OPERACAO = 820 ORDER BY 1, 2 END-EXEC. */
            V0MOVIMENTO = new VG0705B_V0MOVIMENTO(true);
            string GetQuery_V0MOVIMENTO()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							COD_FONTE
							, 
							NUM_PROPOSTA
							, 
							TIPO_SEGURADO
							, 
							NUM_CERTIFICADO
							, 
							DAC_CERTIFICADO
							, 
							COD_CLIENTE
							, 
							COD_AGENCIADOR
							, 
							PRM_VG_ATU - PRM_VG_ANT
							, 
							PRM_AP_ATU - PRM_AP_ANT
							, 
							COD_OPERACAO 
							FROM SEGUROS.V0MOVIMENTO 
							WHERE DATA_INCLUSAO = '{SQL_DTMOVABE}' 
							AND SIT_REGISTRO IN ( '0'
							, '1' ) 
							AND NUM_APOLICE NOT IN 
							(93010000890
							, 97010000889
							, 0109300000027
							, 
							109700000021
							,109700000022
							,109700000023
							, 
							109700000033
							, 
							109700000028
							,109300000550
							,109300000559
							, 
							3009300000559) 
							AND COD_AGENCIADOR NOT IN (0
							, 999105) 
							AND (COD_OPERACAO BETWEEN 0100 AND 0199 OR 
							COD_OPERACAO BETWEEN 0800 AND 0890) 
							AND COD_OPERACAO = 820 
							ORDER BY 1
							, 2";

                return query;
            }
            V0MOVIMENTO.GetQueryEvent += GetQuery_V0MOVIMENTO;

        }

        [StopWatch]
        /*" M-0000-INICIO-DB-OPEN-1 */
        public void M_0000_INICIO_DB_OPEN_1()
        {
            /*" -232- EXEC SQL OPEN V0MOVIMENTO END-EXEC. */

            V0MOVIMENTO.Open();

        }

        [StopWatch]
        /*" M-0000-INICIO-DB-UPDATE-1 */
        public void M_0000_INICIO_DB_UPDATE_1()
        {
            /*" -264- EXEC SQL UPDATE SEGUROS.V0MOVIMENTO SET SIT_REGISTRO = '3' WHERE DATA_INCLUSAO = :SQL-DTMOVABE AND SIT_REGISTRO IN ( '0' , '1' ) AND NUM_APOLICE NOT IN (93010000890, 97010000889, 0109300000027, 109700000021,109700000022,109700000023, 109700000033, 109700000028,109300000550,109300000559, 3009300000559) AND COD_AGENCIADOR NOT IN (0, 999105) AND (COD_OPERACAO BETWEEN 0100 AND 0199 OR COD_OPERACAO BETWEEN 0800 AND 0890) END-EXEC. */

            var m_0000_INICIO_DB_UPDATE_1_Update1 = new M_0000_INICIO_DB_UPDATE_1_Update1()
            {
                SQL_DTMOVABE = SQL_DTMOVABE.ToString(),
            };

            M_0000_INICIO_DB_UPDATE_1_Update1.Execute(m_0000_INICIO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0002-FINALIZA */
        private void M_0002_FINALIZA(bool isPerform = false)
        {
            /*" -273- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -273- PERFORM M_0002_FINALIZA_DB_CLOSE_1 */

            M_0002_FINALIZA_DB_CLOSE_1();

            /*" -277- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -277- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -281- DISPLAY '*** VG0705B *** TERMINO NORMAL' . */
            _.Display($"*** VG0705B *** TERMINO NORMAL");

            /*" -283- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -283- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0002-FINALIZA-DB-CLOSE-1 */
        public void M_0002_FINALIZA_DB_CLOSE_1()
        {
            /*" -273- EXEC SQL CLOSE V0MOVIMENTO END-EXEC. */

            V0MOVIMENTO.Close();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-MOVIMENTO */
        private void M_1000_PROCESSA_MOVIMENTO(bool isPerform = false)
        {
            /*" -291- PERFORM 1210-LE-APOLICE THRU 1210-FIM. */

            M_1210_LE_APOLICE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1210_FIM*/


            /*" -292- IF WS-SEM-PLANO = 1 */

            if (AREA_DE_WORK.WS_SEM_PLANO == 1)
            {

                /*" -294- GO TO 1000-PROC-COMIS. */

                M_1000_PROC_COMIS(); //GOTO
                return;
            }


            /*" -294- PERFORM 1200-LE-PLANO-AGENC THRU 1200-FIM. */

            M_1200_LE_PLANO_AGENC(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/


        }

        [StopWatch]
        /*" M-1000-PROC-COMIS */
        private void M_1000_PROC_COMIS(bool isPerform = false)
        {
            /*" -299- IF WS-SEM-PLANO = 0 */

            if (AREA_DE_WORK.WS_SEM_PLANO == 0)
            {

                /*" -303- PERFORM 1300-PROC-COMIS-SUBGR THRU 1300-FIM UNTIL SQL-NUM-APOL NOT EQUAL WS-APOL-ANT OR SQL-COD-SUB NOT EQUAL WS-SUBGR-ANT OR WFIM-V0MOVIMENTO EQUAL 'S' */

                while (!(SQL_NUM_APOL != AREA_DE_WORK.WS_APOL_ANT || SQL_COD_SUB != AREA_DE_WORK.WS_SUBGR_ANT || AREA_DE_WORK.WFIM_V0MOVIMENTO == "S"))
                {

                    M_1300_PROC_COMIS_SUBGR(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/

                }

                /*" -304- ELSE */
            }
            else
            {


                /*" -307- PERFORM 1100-FETCH THRU 1100-FIM UNTIL SQL-NUM-APOL NOT EQUAL WS-APOL-ANT OR SQL-COD-SUB NOT EQUAL WS-SUBGR-ANT OR WFIM-V0MOVIMENTO EQUAL 'S' . */

                while (!(SQL_NUM_APOL != AREA_DE_WORK.WS_APOL_ANT || SQL_COD_SUB != AREA_DE_WORK.WS_SUBGR_ANT || AREA_DE_WORK.WFIM_V0MOVIMENTO == "S"))
                {

                    M_1100_FETCH(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1100-FETCH */
        private void M_1100_FETCH(bool isPerform = false)
        {
            /*" -317- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -331- PERFORM M_1100_FETCH_DB_FETCH_1 */

            M_1100_FETCH_DB_FETCH_1();

            /*" -334- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -335- MOVE 'S' TO WFIM-V0MOVIMENTO */
                _.Move("S", AREA_DE_WORK.WFIM_V0MOVIMENTO);

                /*" -336- ELSE */
            }
            else
            {


                /*" -337- COMPUTE SQL-PRM-VG ROUNDED = SQL-PRM-VG / 1,07 */
                SQL_PRM_VG.Value = SQL_PRM_VG / 1.07f;

                /*" -338- COMPUTE SQL-PRM-AP ROUNDED = SQL-PRM-AP / 1,07 */
                SQL_PRM_AP.Value = SQL_PRM_AP / 1.07f;

                /*" -338- ADD 1 TO AC-L-V0MOVIMENTO. */
                AREA_DE_WORK.AC_L_V0MOVIMENTO.Value = AREA_DE_WORK.AC_L_V0MOVIMENTO + 1;
            }


        }

        [StopWatch]
        /*" M-1100-FETCH-DB-FETCH-1 */
        public void M_1100_FETCH_DB_FETCH_1()
        {
            /*" -331- EXEC SQL FETCH V0MOVIMENTO INTO :SQL-NUM-APOL, :SQL-COD-SUB, :SQL-COD-FONTE, :SQL-PROPOSTA, :SQL-TIPO-SEG, :SQL-NUM-CERT, :SQL-DAC-CERT, :SQL-COD-CLIE, :SQL-COD-AGEN, :SQL-PRM-VG, :SQL-PRM-AP, :SQL-COD-OPERAC END-EXEC. */

            if (V0MOVIMENTO.Fetch())
            {
                _.Move(V0MOVIMENTO.SQL_NUM_APOL, SQL_NUM_APOL);
                _.Move(V0MOVIMENTO.SQL_COD_SUB, SQL_COD_SUB);
                _.Move(V0MOVIMENTO.SQL_COD_FONTE, SQL_COD_FONTE);
                _.Move(V0MOVIMENTO.SQL_PROPOSTA, SQL_PROPOSTA);
                _.Move(V0MOVIMENTO.SQL_TIPO_SEG, SQL_TIPO_SEG);
                _.Move(V0MOVIMENTO.SQL_NUM_CERT, SQL_NUM_CERT);
                _.Move(V0MOVIMENTO.SQL_DAC_CERT, SQL_DAC_CERT);
                _.Move(V0MOVIMENTO.SQL_COD_CLIE, SQL_COD_CLIE);
                _.Move(V0MOVIMENTO.SQL_COD_AGEN, SQL_COD_AGEN);
                _.Move(V0MOVIMENTO.SQL_PRM_VG, SQL_PRM_VG);
                _.Move(V0MOVIMENTO.SQL_PRM_AP, SQL_PRM_AP);
                _.Move(V0MOVIMENTO.SQL_COD_OPERAC, SQL_COD_OPERAC);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

        [StopWatch]
        /*" M-1200-LE-PLANO-AGENC */
        private void M_1200_LE_PLANO_AGENC(bool isPerform = false)
        {
            /*" -348- MOVE 0 TO WS-SEM-PLANO. */
            _.Move(0, AREA_DE_WORK.WS_SEM_PLANO);

            /*" -350- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -356- PERFORM M_1200_LE_PLANO_AGENC_DB_SELECT_1 */

            M_1200_LE_PLANO_AGENC_DB_SELECT_1();

            /*" -359- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -361- MOVE 1 TO WS-SEM-PLANO. */
                _.Move(1, AREA_DE_WORK.WS_SEM_PLANO);
            }


            /*" -362- MOVE SQL-NUM-APOL TO WS-APOL-ANT. */
            _.Move(SQL_NUM_APOL, AREA_DE_WORK.WS_APOL_ANT);

            /*" -362- MOVE SQL-COD-SUB TO WS-SUBGR-ANT. */
            _.Move(SQL_COD_SUB, AREA_DE_WORK.WS_SUBGR_ANT);

        }

        [StopWatch]
        /*" M-1200-LE-PLANO-AGENC-DB-SELECT-1 */
        public void M_1200_LE_PLANO_AGENC_DB_SELECT_1()
        {
            /*" -356- EXEC SQL SELECT PCT_PAGA_PARCELA INTO :SQL-PCT-AGENC FROM SEGUROS.V1PLANOAGEN WHERE NUM_APOLICE = :SQL-NUM-APOL AND COD_SUBGRUPO = :SQL-COD-SUB END-EXEC. */

            var m_1200_LE_PLANO_AGENC_DB_SELECT_1_Query1 = new M_1200_LE_PLANO_AGENC_DB_SELECT_1_Query1()
            {
                SQL_NUM_APOL = SQL_NUM_APOL.ToString(),
                SQL_COD_SUB = SQL_COD_SUB.ToString(),
            };

            var executed_1 = M_1200_LE_PLANO_AGENC_DB_SELECT_1_Query1.Execute(m_1200_LE_PLANO_AGENC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_PCT_AGENC, SQL_PCT_AGENC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/

        [StopWatch]
        /*" M-1210-LE-APOLICE */
        private void M_1210_LE_APOLICE(bool isPerform = false)
        {
            /*" -372- MOVE 0 TO WS-SEM-PLANO. */
            _.Move(0, AREA_DE_WORK.WS_SEM_PLANO);

            /*" -374- MOVE '121' TO WNR-EXEC-SQL. */
            _.Move("121", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -379- PERFORM M_1210_LE_APOLICE_DB_SELECT_1 */

            M_1210_LE_APOLICE_DB_SELECT_1();

            /*" -382- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -383- MOVE 1 TO WS-SEM-PLANO */
                _.Move(1, AREA_DE_WORK.WS_SEM_PLANO);

                /*" -384- MOVE SQL-NUM-APOL TO WS-APOL-ANT */
                _.Move(SQL_NUM_APOL, AREA_DE_WORK.WS_APOL_ANT);

                /*" -385- MOVE SQL-COD-SUB TO WS-SUBGR-ANT */
                _.Move(SQL_COD_SUB, AREA_DE_WORK.WS_SUBGR_ANT);

                /*" -391- GO TO 1210-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1210_FIM*/ //GOTO
                return;
            }


            /*" -392- IF SQL-TIPAPO EQUAL '5' */

            if (SQL_TIPAPO == "5")
            {

                /*" -397- IF (SQL-NUM-APOL = 109300000218) OR (SQL-NUM-APOL = 109300000566 AND SQL-COD-SUB = 3) OR (SQL-NUM-APOL = 109300000680) NEXT SENTENCE */

                if ((SQL_NUM_APOL == 109300000218) || (SQL_NUM_APOL == 109300000566 && SQL_COD_SUB == 3) || (SQL_NUM_APOL == 109300000680))
                {

                    /*" -398- ELSE */
                }
                else
                {


                    /*" -399- MOVE 1 TO WS-SEM-PLANO */
                    _.Move(1, AREA_DE_WORK.WS_SEM_PLANO);

                    /*" -400- MOVE SQL-NUM-APOL TO WS-APOL-ANT */
                    _.Move(SQL_NUM_APOL, AREA_DE_WORK.WS_APOL_ANT);

                    /*" -400- MOVE SQL-COD-SUB TO WS-SUBGR-ANT. */
                    _.Move(SQL_COD_SUB, AREA_DE_WORK.WS_SUBGR_ANT);
                }

            }


        }

        [StopWatch]
        /*" M-1210-LE-APOLICE-DB-SELECT-1 */
        public void M_1210_LE_APOLICE_DB_SELECT_1()
        {
            /*" -379- EXEC SQL SELECT TIPAPO INTO :SQL-TIPAPO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :SQL-NUM-APOL END-EXEC. */

            var m_1210_LE_APOLICE_DB_SELECT_1_Query1 = new M_1210_LE_APOLICE_DB_SELECT_1_Query1()
            {
                SQL_NUM_APOL = SQL_NUM_APOL.ToString(),
            };

            var executed_1 = M_1210_LE_APOLICE_DB_SELECT_1_Query1.Execute(m_1210_LE_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_TIPAPO, SQL_TIPAPO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1210_FIM*/

        [StopWatch]
        /*" M-1300-PROC-COMIS-SUBGR */
        private void M_1300_PROC_COMIS_SUBGR(bool isPerform = false)
        {
            /*" -409- IF SQL-PRM-VG > ZEROES */

            if (SQL_PRM_VG > 00)
            {

                /*" -411- PERFORM 1310-PROC-COMIS-VG THRU 1310-FIM. */

                M_1310_PROC_COMIS_VG(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1310_FIM*/

            }


            /*" -412- IF SQL-PRM-AP > ZEROES */

            if (SQL_PRM_AP > 00)
            {

                /*" -414- PERFORM 1320-PROC-COMIS-AP THRU 1320-FIM. */

                M_1320_PROC_COMIS_AP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1320_FIM*/

            }


            /*" -414- PERFORM 1100-FETCH THRU 1100-FIM. */

            M_1100_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/

        [StopWatch]
        /*" M-1310-PROC-COMIS-VG */
        private void M_1310_PROC_COMIS_VG(bool isPerform = false)
        {
            /*" -423- MOVE 93 TO SQL-RAMOFR. */
            _.Move(93, SQL_RAMOFR);

            /*" -425- MOVE SQL-PRM-VG TO SQL-VALBAS. */
            _.Move(SQL_PRM_VG, SQL_VALBAS);

            /*" -428- COMPUTE SQL-VLCOMIS ROUNDED = (SQL-VALBAS * SQL-PCT-AGENC) / 100. */
            SQL_VLCOMIS.Value = (SQL_VALBAS * SQL_PCT_AGENC) / 100f;

            /*" -428- PERFORM 1400-GRAVA-COMIS THRU 1400-FIM. */

            M_1400_GRAVA_COMIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1400_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1310_FIM*/

        [StopWatch]
        /*" M-1320-PROC-COMIS-AP */
        private void M_1320_PROC_COMIS_AP(bool isPerform = false)
        {
            /*" -437- MOVE 82 TO SQL-RAMOFR. */
            _.Move(82, SQL_RAMOFR);

            /*" -439- MOVE SQL-PRM-AP TO SQL-VALBAS. */
            _.Move(SQL_PRM_AP, SQL_VALBAS);

            /*" -442- COMPUTE SQL-VLCOMIS ROUNDED = (SQL-VALBAS * SQL-PCT-AGENC) / 100. */
            SQL_VLCOMIS.Value = (SQL_VALBAS * SQL_PCT_AGENC) / 100f;

            /*" -442- PERFORM 1400-GRAVA-COMIS THRU 1400-FIM. */

            M_1400_GRAVA_COMIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1400_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1320_FIM*/

        [StopWatch]
        /*" M-1400-GRAVA-COMIS */
        private void M_1400_GRAVA_COMIS(bool isPerform = false)
        {
            /*" -451- ACCEPT WTIME-DAY FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -452- MOVE CORR WTIME-DAY1 TO WTIME-DAYR. */
            _.MoveCorr(AREA_DE_WORK.WTIME_DAY1, AREA_DE_WORK.WTIME_DAYR);

            /*" -454- MOVE WTIME-DAYR TO SQL-HORAOPER. */
            _.Move(AREA_DE_WORK.WTIME_DAYR, SQL_HORAOPER);

            /*" -456- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -458- MOVE -1 TO SQL-NUMBILI. */
            _.Move(-1, SQL_NUMBILI);

            /*" -491- PERFORM M_1400_GRAVA_COMIS_DB_INSERT_1 */

            M_1400_GRAVA_COMIS_DB_INSERT_1();

            /*" -493- ADD +1 TO AC-I-V0COMISSAO. */
            AREA_DE_WORK.AC_I_V0COMISSAO.Value = AREA_DE_WORK.AC_I_V0COMISSAO + +1;

        }

        [StopWatch]
        /*" M-1400-GRAVA-COMIS-DB-INSERT-1 */
        public void M_1400_GRAVA_COMIS_DB_INSERT_1()
        {
            /*" -491- EXEC SQL INSERT INTO SEGUROS.V0COMISSAO VALUES (:SQL-NUM-APOL , 0, :SQL-NUM-CERT , :SQL-DAC-CERT , :SQL-TIPO-SEG , 0, 1101, :SQL-COD-AGEN , :SQL-RAMOFR , 0, 0, :SQL-COD-FONTE, :SQL-COD-CLIE , :SQL-VLCOMIS , :SQL-DTMOVABE , 0, :SQL-VALBAS , 'O' , 0, :SQL-PCT-AGENC, 0, :SQL-COD-SUB, :SQL-HORAOPER, NULL, :SQL-DATSEL:SQL-NOT-NULL, NULL, :SQL-PROPOSTA:SQL-NOT-NULL, CURRENT TIMESTAMP, :SQL-NUMBIL:SQL-NUMBILI, 0, NULL) END-EXEC. */

            var m_1400_GRAVA_COMIS_DB_INSERT_1_Insert1 = new M_1400_GRAVA_COMIS_DB_INSERT_1_Insert1()
            {
                SQL_NUM_APOL = SQL_NUM_APOL.ToString(),
                SQL_NUM_CERT = SQL_NUM_CERT.ToString(),
                SQL_DAC_CERT = SQL_DAC_CERT.ToString(),
                SQL_TIPO_SEG = SQL_TIPO_SEG.ToString(),
                SQL_COD_AGEN = SQL_COD_AGEN.ToString(),
                SQL_RAMOFR = SQL_RAMOFR.ToString(),
                SQL_COD_FONTE = SQL_COD_FONTE.ToString(),
                SQL_COD_CLIE = SQL_COD_CLIE.ToString(),
                SQL_VLCOMIS = SQL_VLCOMIS.ToString(),
                SQL_DTMOVABE = SQL_DTMOVABE.ToString(),
                SQL_VALBAS = SQL_VALBAS.ToString(),
                SQL_PCT_AGENC = SQL_PCT_AGENC.ToString(),
                SQL_COD_SUB = SQL_COD_SUB.ToString(),
                SQL_HORAOPER = SQL_HORAOPER.ToString(),
                SQL_DATSEL = SQL_DATSEL.ToString(),
                SQL_NOT_NULL = SQL_NOT_NULL.ToString(),
                SQL_PROPOSTA = SQL_PROPOSTA.ToString(),
                SQL_NUMBIL = SQL_NUMBIL.ToString(),
                SQL_NUMBILI = SQL_NUMBILI.ToString(),
            };

            M_1400_GRAVA_COMIS_DB_INSERT_1_Insert1.Execute(m_1400_GRAVA_COMIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1400_FIM*/

        [StopWatch]
        /*" M-9000-ENCERRA-SEM-MOVTO */
        private void M_9000_ENCERRA_SEM_MOVTO(bool isPerform = false)
        {
            /*" -504- MOVE SQL-DTMOVABE TO WDATA-REL. */
            _.Move(SQL_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -505- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -506- MOVE WDAT-REL-MES TO WDAT-LIT-MES. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -508- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -509- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -510- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -511- DISPLAY '*   VG0705B - ATUALIZACAO DB COMISSOES     *' */
            _.Display($"*   VG0705B - ATUALIZACAO DB COMISSOES     *");

            /*" -512- DISPLAY '*   -------   ----------- -- ---------     *' */
            _.Display($"*   -------   ----------- -- ---------     *");

            /*" -513- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -514- DISPLAY '*   NAO HOUVE MOVIMENTACAO                 *' */
            _.Display($"*   NAO HOUVE MOVIMENTACAO                 *");

            /*" -516- DISPLAY '*   NESTA DATA ' WDAT-REL-LIT '                    *' */

            $"*   NESTA DATA {AREA_DE_WORK.WDAT_REL_LIT}                    *"
            .Display();

            /*" -517- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -517- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -529- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -531- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -531- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -533- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -536- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -536- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}