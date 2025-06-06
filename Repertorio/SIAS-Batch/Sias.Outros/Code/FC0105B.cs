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
using Sias.Outros.DB2.FC0105B;

namespace Code
{
    public class FC0105B
    {
        public bool IsCall { get; set; }

        public FC0105B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SIATC                               *      */
        /*"      *   ANALISTA ............... ALCIONE ARAUJO                      *      */
        /*"      *   PROG/ANALISTA........... ALCIONE ARAUJO                      *      */
        /*"      *   DATA CODIFICACAO ....... 01/07/2015                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO..................  CANCELA TITULOS ACOPLADOS COM MAIS *      */
        /*"      *                             DE 90 DIAS COM STATUS 'EMT/RSV'.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *VERSAO: 27/12/2019 AS 09:16 - 179492 - TRATA ABEND              *      */
        /*"      *      : 12/11/2018 AS 13:00 - 999999 - VOLTA VERSAO             *      */
        /*"      *      : 09/11/2018 AS 15:40 - XXX999 - ATUALIZA RISCO ACOPLADO  *      */
        /*"      *      : 30/10/2017 AS 15:40 - XXXXXX - ALTERA LOGICA DE CANCELA *      */
        /*"      *      : 06/10/2017 AS 15:40 - 154701 - MANTER STATUS DE 'EMT'   *      */
        /*"      *      : 07/02/2017 AS 15:40 - 143615 - INSERE MONITORAMENTO     *      */
        /*"      *      : 12/01/2016 AS 14:30 - 117064 - PROGRAMA PROMVIDO PRD    *      */
        /*"      *      : 10/07/2015 AS 14:00 - 117064 - IMPLEMENTACAO            *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  FILLER                         PIC X(001) VALUE SPACES.*/

        public SelectorBasis FILLER_0 { get; set; } = new SelectorBasis("001", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88   W88-OPEN-OK                             VALUE '0'. */
							new SelectorItemBasis("W88_OPEN_OK", "0"),
							/*" 88   W88-OPEN-NOK                            VALUE '1'. */
							new SelectorItemBasis("W88_OPEN_NOK", "1")
                }
        };

        /*"77  FILLER                         PIC X(001)  VALUE SPACES.*/

        public SelectorBasis FILLER_1 { get; set; } = new SelectorBasis("001", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88   W88-INI-CURSOR1                         VALUE '0'. */
							new SelectorItemBasis("W88_INI_CURSOR1", "0"),
							/*" 88   W88-FIM-CURSOR1                         VALUE '1'. */
							new SelectorItemBasis("W88_FIM_CURSOR1", "1")
                }
        };

        /*"77  FILLER                         PIC X(001)  VALUE SPACES.*/

        public SelectorBasis FILLER_2 { get; set; } = new SelectorBasis("001", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88   W88-INI-CURSOR2                         VALUE '0'. */
							new SelectorItemBasis("W88_INI_CURSOR2", "0"),
							/*" 88   W88-FIM-CURSOR2                         VALUE '1'. */
							new SelectorItemBasis("W88_FIM_CURSOR2", "1")
                }
        };

        /*"01          WABEND.*/
        public FC0105B_WABEND WABEND { get; set; } = new FC0105B_WABEND();
        public class FC0105B_WABEND : VarBasis
        {
            /*"    10      FILLER                PIC  X(008)   VALUE           ' FC0105B'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @" FC0105B");
            /*"    10      FILLER                PIC  X(026)   VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"    10      FILLER                PIC  X(013)   VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    10      WSQLCODE              PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    10      W77-SQLCODE           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis W77_SQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    10      FILLER                PIC  X(002)   VALUE ' <'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" <");
            /*"    10      WSQLERRMC             PIC  X(060)   VALUE SPACES.*/
            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            /*"    10      FILLER                PIC  X(005)   VALUE '> ***'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"> ***");
            /*"01      AREA-DE-WORK.*/
        }
        public FC0105B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new FC0105B_AREA_DE_WORK();
        public class FC0105B_AREA_DE_WORK : VarBasis
        {
            /*"        05  W77-PROGRAMA           PIC X(008) VALUE 'FC0105B'.*/
            public StringBasis W77_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"FC0105B");
            /*"        05  W77-ROTINA             PIC X(008) VALUE 'JPFCS02'.*/
            public StringBasis W77_ROTINA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"JPFCS02");
            /*"        05  W77-RETC               PIC 9999.*/
            public IntBasis W77_RETC { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
            /*"        05  W77-OUT-RETC           PIC 9999.*/
            public IntBasis W77_OUT_RETC { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
            /*"        05  W77-UPD-TITULO         PIC 9(008) VALUE ZEROS.*/
            public IntBasis W77_UPD_TITULO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"        05  W77-UPD-PROPOSTA       PIC 9(008) VALUE ZEROS.*/
            public IntBasis W77_UPD_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"        05  W77-NAO-ENCONTRADO     PIC 9(008) VALUE ZEROS.*/
            public IntBasis W77_NAO_ENCONTRADO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"        05  W77-MENSAGEM           PIC X(120) VALUE SPACES.*/
            public StringBasis W77_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"");
            /*"        05  W77-LIDOS-C01          PIC 9(008) VALUE ZEROS.*/
            public IntBasis W77_LIDOS_C01 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"        05  W77-LIDOS-C02          PIC 9(008) VALUE ZEROS.*/
            public IntBasis W77_LIDOS_C02 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"        05  W77-VLR-TOT-CANCEL     PIC S9(08)V99 VALUE ZEROS.*/
            public DoubleBasis W77_VLR_TOT_CANCEL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V99"), 2);
            /*"        05  W77-VLR-TOT-CANCEL-EDT PIC -ZZZZZZZ9,99.*/
            public DoubleBasis W77_VLR_TOT_CANCEL_EDT { get; set; } = new DoubleBasis(new PIC("9", "8", "-ZZZZZZZ9V99."), 2);
            /*"        05  W77-PLANO              PIC 9(004) VALUE ZEROS.*/
            public IntBasis W77_PLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"        05  W77-MOD-PLANO          PIC 9(004) VALUE ZEROS.*/
            public IntBasis W77_MOD_PLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"        05  W77-SERIE              PIC 9(004) VALUE ZEROS.*/
            public IntBasis W77_SERIE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"        05  W77-TITULO             PIC 9(010) VALUE ZEROS.*/
            public IntBasis W77_TITULO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"        05  W77-NSA                PIC 9(004) VALUE ZEROS.*/
            public IntBasis W77_NSA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"        05  W77-RAMO               PIC 9(004) VALUE ZEROS.*/
            public IntBasis W77_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"        05  W77-PROPOSTA           PIC 9(015) VALUE ZEROS.*/
            public IntBasis W77_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"01     REGISTR1-LINKAGE.*/
        }
        public FC0105B_REGISTR1_LINKAGE REGISTR1_LINKAGE { get; set; } = new FC0105B_REGISTR1_LINKAGE();
        public class FC0105B_REGISTR1_LINKAGE : VarBasis
        {
            /*"  05   LKG1-PARM-INPUT.*/
            public FC0105B_LKG1_PARM_INPUT LKG1_PARM_INPUT { get; set; } = new FC0105B_LKG1_PARM_INPUT();
            public class FC0105B_LKG1_PARM_INPUT : VarBasis
            {
                /*"    10  LKG1-COD-SISTEM           PIC  X(002).*/
                public StringBasis LKG1_COD_SISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10  LKG1-NOM-ROTINA           PIC  X(008).*/
                public StringBasis LKG1_NOM_ROTINA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10  LKG1-SEQ-ETAPA            PIC  9(004).*/
                public IntBasis LKG1_SEQ_ETAPA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  LKG1-NOM-PROGM            PIC  X(008).*/
                public StringBasis LKG1_NOM_PROGM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10  LKG1-TIP-PROCS            PIC  X(002).*/
                public StringBasis LKG1_TIP_PROCS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05   LKG1-PARM-OUTPUT.*/
            }
            public FC0105B_LKG1_PARM_OUTPUT LKG1_PARM_OUTPUT { get; set; } = new FC0105B_LKG1_PARM_OUTPUT();
            public class FC0105B_LKG1_PARM_OUTPUT : VarBasis
            {
                /*"    10  LKG1-DATA-MOVTO           PIC  X(010).*/
                public StringBasis LKG1_DATA_MOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10  LKG1-DAT-INIMOV           PIC  X(010).*/
                public StringBasis LKG1_DAT_INIMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10  LKG1-DAT-TERMOV           PIC  X(010).*/
                public StringBasis LKG1_DAT_TERMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10  LKG1-DAT-CURRNT           PIC  X(010).*/
                public StringBasis LKG1_DAT_CURRNT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10  LKG1-SQL-CODE             PIC -9(009).*/
                public IntBasis LKG1_SQL_CODE { get; set; } = new IntBasis(new PIC("-9", "9", "-9(009)."));
                /*"    10  LKG1-RETN-CODE            PIC  9(002).*/
                public IntBasis LKG1_RETN_CODE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  LKG1-MENS-ERRO            PIC  X(050).*/
                public StringBasis LKG1_MENS_ERRO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"01     REGISTR2-LINKAGE.*/
            }
        }
        public FC0105B_REGISTR2_LINKAGE REGISTR2_LINKAGE { get; set; } = new FC0105B_REGISTR2_LINKAGE();
        public class FC0105B_REGISTR2_LINKAGE : VarBasis
        {
            /*"  05   LKG2-PARM-INPUT.*/
            public FC0105B_LKG2_PARM_INPUT LKG2_PARM_INPUT { get; set; } = new FC0105B_LKG2_PARM_INPUT();
            public class FC0105B_LKG2_PARM_INPUT : VarBasis
            {
                /*"    10  LKG2-COD-SISTEM           PIC  X(002).*/
                public StringBasis LKG2_COD_SISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10  LKG2-NOM-ROTINA           PIC  X(008).*/
                public StringBasis LKG2_NOM_ROTINA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10  LKG2-SEQ-ETAPA            PIC  9(004).*/
                public IntBasis LKG2_SEQ_ETAPA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  LKG2-NOM-PROGM            PIC  X(008).*/
                public StringBasis LKG2_NOM_PROGM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10  LKG2-QTD-REG-LIDOS        PIC  9(009).*/
                public IntBasis LKG2_QTD_REG_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10  LKG2-QTD-REG-PROCS        PIC  9(009).*/
                public IntBasis LKG2_QTD_REG_PROCS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10  LKG2-QTD-REG-GRAVD        PIC  9(009).*/
                public IntBasis LKG2_QTD_REG_GRAVD { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10  LKG2-QTD-REG-ALTER        PIC  9(009).*/
                public IntBasis LKG2_QTD_REG_ALTER { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10  LKG2-QTD-REG-EXCLU        PIC  9(009).*/
                public IntBasis LKG2_QTD_REG_EXCLU { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10  LKG2-STA-EXECUCAO         PIC  X(001).*/
                public StringBasis LKG2_STA_EXECUCAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05   LKG2-PARM-OUTPUT.*/
            }
            public FC0105B_LKG2_PARM_OUTPUT LKG2_PARM_OUTPUT { get; set; } = new FC0105B_LKG2_PARM_OUTPUT();
            public class FC0105B_LKG2_PARM_OUTPUT : VarBasis
            {
                /*"    10  LKG2-SQL-CODE     PIC -9(009).*/
                public IntBasis LKG2_SQL_CODE { get; set; } = new IntBasis(new PIC("-9", "9", "-9(009)."));
                /*"    10  LKG2-RETN-CODE    PIC  9(002).*/
                public IntBasis LKG2_RETN_CODE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  LKG2-MENS-ERRO    PIC  X(050).*/
                public StringBasis LKG2_MENS_ERRO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"01 LK-IN-COD-SEQ                   PIC X(005).*/
            }
        }
        public StringBasis LK_IN_COD_SEQ { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"01 LK-IN-QTD-SEQ                   PIC S9(004) COMP.*/
        public IntBasis LK_IN_QTD_SEQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-OUT-NUM-SEQ-INI              PIC S9(009) COMP.*/
        public IntBasis LK_OUT_NUM_SEQ_INI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 LK-OUT-NUM-SEQ-FIM              PIC S9(009) COMP.*/
        public IntBasis LK_OUT_NUM_SEQ_FIM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 LK-OUT-COD-RETORNO              PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-OUT-SQLCODE                  PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 LK-OUT-MENSAGEM                 PIC X(070).*/
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01 LK-OUT-SQLERRMC                 PIC X(070).*/
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01 LK-OUT-SQLSTATE                 PIC X(005).*/
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"01  LK-PARAMETRO.*/
        public FC0105B_LK_PARAMETRO LK_PARAMETRO { get; set; } = new FC0105B_LK_PARAMETRO();
        public class FC0105B_LK_PARAMETRO : VarBasis
        {
            /*"    03  FILLER                  PIC X(002).*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    03  LK-OPERACAO             PIC X(008).*/

            public SelectorBasis LK_OPERACAO { get; set; } = new SelectorBasis("008")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88  W88-COMMIT                VALUE 'COMMIT  '. */
							new SelectorItemBasis("W88_COMMIT", "COMMIT "),
							/*" 88  W88-ROLLBACK              VALUE 'ROLLBACK'. */
							new SelectorItemBasis("W88_ROLLBACK", "ROLLBACK")
                }
            };

            /*"    03  FILLER                  PIC X(001).*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  LK-TRACE                PIC X(008).*/

            public SelectorBasis LK_TRACE { get; set; } = new SelectorBasis("008")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88  W88-TRACE-ON              VALUE 'TRACEON '. */
							new SelectorItemBasis("W88_TRACE_ON", "TRACEON "),
							/*" 88  W88-TRACE-OFF             VALUE 'TRACEOFF'. */
							new SelectorItemBasis("W88_TRACE_OFF", "TRACEOFF")
                }
            };

        }


        public Dclgens.FCPROPOS FCPROPOS { get; set; } = new Dclgens.FCPROPOS();
        public Dclgens.FCTITULO FCTITULO { get; set; } = new Dclgens.FCTITULO();
        public Dclgens.FCHISTIT FCHISTIT { get; set; } = new Dclgens.FCHISTIT();
        public Dclgens.FCHISPRO FCHISPRO { get; set; } = new Dclgens.FCHISPRO();
        public Dclgens.FC239 FC239 { get; set; } = new Dclgens.FC239();
        public Dclgens.FC240 FC240 { get; set; } = new Dclgens.FC240();

        public FC0105B_C01_CURSOR1 C01_CURSOR1 { get; set; } = new FC0105B_C01_CURSOR1(false);
        string GetQuery_C01_CURSOR1()
        {
            var query = @$"SELECT NUM_PLANO
							, IDE_CLIENTE
							, COD_RAMO
							, NUM_MOD_PLANO
							, QTD_DIAS_CANCELA
							FROM FDRCAP.FC_PLANO_EMP_PARC WHERE STA_ATIVACAO = 'N' AND STA_CANCELAMENTO = 'S' FOR FETCH ONLY";

            return query;
        }


        public FC0105B_C02_CURSOR2 C02_CURSOR2 { get; set; } = new FC0105B_C02_CURSOR2(true);
        string GetQuery_C02_CURSOR2()
        {
            var query = @$"SELECT PRO.NUM_PROPOSTA
							, PRO.NUM_NSA
							, TIT.NUM_PLANO
							, TIT.NUM_SERIE
							, TIT.NUM_TITULO
							, TIT.IDE_TITULAR
							, TIT.VLR_MENSALIDADE
							FROM FDRCAP.FC_PROPOSTA PRO
							JOIN FDRCAP.FC_TITULO TIT ON PRO.NUM_PLANO = TIT.NUM_PLANO AND PRO.NUM_PROPOSTA = TIT.NUM_PROPOSTA AND PRO.NUM_NSA = TIT.NUM_NSA WHERE PRO.NUM_PLANO = '{FC239.DCLFC_PLANO_EMP_PARC.FC239_NUM_PLANO}' AND PRO.STA_PROPOSTA = 'AGC' AND TIT.COD_STA_TITULO = 'EMT' AND TIT.COD_SUB_STATUS = 'RSV' and TIT.NUM_MOD_PLANO = '{FC239.DCLFC_PLANO_EMP_PARC.FC239_NUM_MOD_PLANO}' AND PRO.COD_RAMO = '{FC239.DCLFC_PLANO_EMP_PARC.FC239_COD_RAMO}' AND DAYS(DTH_PROPOSTA) <= DAYS(CURRENT DATE - {FC239.DCLFC_PLANO_EMP_PARC.FC239_QTD_DIAS_CANCELA} DAYS) ORDER BY PRO.NUM_PLANO
							, PRO.NUM_PROPOSTA FOR FETCH ONLY";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(FC0105B_LK_PARAMETRO FC0105B_LK_PARAMETRO_P) //PROCEDURE DIVISION USING 
        /*LK_PARAMETRO*/
        {
            try
            {
                this.LK_PARAMETRO = FC0105B_LK_PARAMETRO_P;
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM P000-INICIA-PROGRAMA-SECTION */

                P000_INICIA_PROGRAMA_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_PARAMETRO, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        public void InitializeGetQuery()
        {
            C01_CURSOR1.GetQueryEvent += GetQuery_C01_CURSOR1;
            C02_CURSOR2.GetQueryEvent += GetQuery_C02_CURSOR2;
        }

        [StopWatch]
        /*" P000-INICIA-PROGRAMA-SECTION */
        private void P000_INICIA_PROGRAMA_SECTION()
        {
            /*" -219- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P000_INICIA */

            P000_INICIA();

        }

        [StopWatch]
        /*" P000-INICIA */
        private void P000_INICIA(bool isPerform = false)
        {
            /*" -223- PERFORM P010-INICIO THRU P010-SAIDA */

            P010_INICIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P010_SAIDA*/


            /*" -225- PERFORM P020-ABRE-CURSOR-C01 THRU P020-SAIDA */

            P020_ABRE_CURSOR_C01(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P020_SAIDA*/


            /*" -227- PERFORM P999-FINAL THRU P999-SAIDA */

            P999_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P999_SAIDA*/


            /*" -227- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" P010-INICIO */
        private void P010_INICIO(bool isPerform = false)
        {
            /*" -234- DISPLAY '**************************************************' */
            _.Display($"**************************************************");

            /*" -235- DISPLAY '* CANCELA TITULOS ACOPLADOS COM MAIS DE 90 DIAS  *' */
            _.Display($"* CANCELA TITULOS ACOPLADOS COM MAIS DE 90 DIAS  *");

            /*" -237- DISPLAY '* COM STATUS "EMT/RSV". *' ' ' */

            $"* COM STATUS EMT/RSV. * "
            .Display();

            /*" -244- DISPLAY '* VERSAO: ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) '                 *' */

            $"* VERSAO: FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}                 *"
            .Display();

            /*" -245- DISPLAY '* CADMUS: 179492 - V08                           *' */
            _.Display($"* CADMUS: 179492 - V08                           *");

            /*" -247- DISPLAY '**************************************************' */
            _.Display($"**************************************************");

            /*" -254- DISPLAY '*** INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ' ***' */

            $"*** INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss} ***"
            .Display();

            /*" -256- DISPLAY ' ' */
            _.Display($" ");

            /*" -264- INITIALIZE AREA-DE-WORK W77-PLANO W77-SERIE W77-TITULO W77-NSA W77-PROPOSTA W77-LIDOS-C01 W77-LIDOS-C02 */
            _.Initialize(
                AREA_DE_WORK
                , AREA_DE_WORK.W77_PLANO
                , AREA_DE_WORK.W77_SERIE
                , AREA_DE_WORK.W77_TITULO
                , AREA_DE_WORK.W77_NSA
                , AREA_DE_WORK.W77_PROPOSTA
                , AREA_DE_WORK.W77_LIDOS_C01
                , AREA_DE_WORK.W77_LIDOS_C02
            );

            /*" -266- . */

            /*" -267- DISPLAY '--------------------------------------------' */
            _.Display($"--------------------------------------------");

            /*" -268- DISPLAY '          PARAMETRO INFORMADO' */
            _.Display($"          PARAMETRO INFORMADO");

            /*" -269- DISPLAY '--------------------------------------------' */
            _.Display($"--------------------------------------------");

            /*" -270- DISPLAY 'OPERACAO ...: <' LK-OPERACAO '>' */

            $"OPERACAO ...: <{LK_PARAMETRO.LK_OPERACAO}>"
            .Display();

            /*" -271- DISPLAY 'TRACE ......: <' LK-TRACE '>' */

            $"TRACE ......: <{LK_PARAMETRO.LK_TRACE}>"
            .Display();

            /*" -273- DISPLAY ' ' */
            _.Display($" ");

            /*" -275- IF (LK-OPERACAO NOT = 'COMMIT  ' AND 'ROLLBACK' ) OR (LK-TRACE NOT = 'TRACEON ' AND 'TRACEOFF' ) */

            if ((!LK_PARAMETRO.LK_OPERACAO.In("COMMIT ", "ROLLBACK")) || (!LK_PARAMETRO.LK_TRACE.In("TRACEON ", "TRACEOFF")))
            {

                /*" -276- DISPLAY 'PARAMETROS INVALIDOS' */
                _.Display($"PARAMETROS INVALIDOS");

                /*" -277- DISPLAY LK-OPERACAO */
                _.Display(LK_PARAMETRO.LK_OPERACAO);

                /*" -278- DISPLAY LK-TRACE */
                _.Display(LK_PARAMETRO.LK_TRACE);

                /*" -279- GO TO P999-CANCELA-PROGRAMA */

                P999_CANCELA_PROGRAMA(); //GOTO
                return;

                /*" -281- END-IF */
            }


            /*" -282- IF W88-COMMIT */

            if (LK_PARAMETRO.LK_OPERACAO["W88_COMMIT"])
            {

                /*" -283- MOVE 'FC' TO LKG1-COD-SISTEM */
                _.Move("FC", REGISTR1_LINKAGE.LKG1_PARM_INPUT.LKG1_COD_SISTEM);

                /*" -284- MOVE W77-ROTINA TO LKG1-NOM-ROTINA */
                _.Move(AREA_DE_WORK.W77_ROTINA, REGISTR1_LINKAGE.LKG1_PARM_INPUT.LKG1_NOM_ROTINA);

                /*" -285- MOVE 04 TO LKG1-SEQ-ETAPA */
                _.Move(04, REGISTR1_LINKAGE.LKG1_PARM_INPUT.LKG1_SEQ_ETAPA);

                /*" -286- MOVE W77-PROGRAMA TO LKG1-NOM-PROGM */
                _.Move(AREA_DE_WORK.W77_PROGRAMA, REGISTR1_LINKAGE.LKG1_PARM_INPUT.LKG1_NOM_PROGM);

                /*" -287- MOVE 'P0' TO LKG1-TIP-PROCS */
                _.Move("P0", REGISTR1_LINKAGE.LKG1_PARM_INPUT.LKG1_TIP_PROCS);

                /*" -289- CALL 'FC1111S' USING REGISTR1-LINKAGE */
                _.Call("FC1111S", REGISTR1_LINKAGE);

                /*" -290- IF LKG1-RETN-CODE EQUAL 0 */

                if (REGISTR1_LINKAGE.LKG1_PARM_OUTPUT.LKG1_RETN_CODE == 0)
                {

                    /*" -290- EXEC SQL COMMIT END-EXEC */

                    DatabaseConnection.Instance.CommitTransaction();

                    /*" -292- ELSE */
                }
                else
                {


                    /*" -292- EXEC SQL ROLLBACK END-EXEC */

                    DatabaseConnection.Instance.RollbackTransaction();

                    /*" -294- DISPLAY 'ERRO NA CHAMADA DA FC1111S' */
                    _.Display($"ERRO NA CHAMADA DA FC1111S");

                    /*" -296- DISPLAY 'MENSAGEM: <' LKG1-MENS-ERRO '> <' LKG1-SQL-CODE '> <' LKG1-RETN-CODE '>' */

                    $"MENSAGEM: <{REGISTR1_LINKAGE.LKG1_PARM_OUTPUT.LKG1_MENS_ERRO}> <{REGISTR1_LINKAGE.LKG1_PARM_OUTPUT.LKG1_SQL_CODE}> <{REGISTR1_LINKAGE.LKG1_PARM_OUTPUT.LKG1_RETN_CODE}>"
                    .Display();

                    /*" -297- END-IF */
                }


                /*" -299- END-IF */
            }


            /*" -299- INITIALIZE W77-MENSAGEM. */
            _.Initialize(
                AREA_DE_WORK.W77_MENSAGEM
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P010_SAIDA*/

        [StopWatch]
        /*" P020-ABRE-CURSOR-C01 */
        private void P020_ABRE_CURSOR_C01(bool isPerform = false)
        {
            /*" -310- DISPLAY 'ABRE O CURSOR C01' */
            _.Display($"ABRE O CURSOR C01");

            /*" -310- PERFORM P020_ABRE_CURSOR_C01_DB_OPEN_1 */

            P020_ABRE_CURSOR_C01_DB_OPEN_1();

            /*" -313- IF SQLCODE = ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -314- IF W88-TRACE-ON */

                if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
                {

                    /*" -315- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -316- DISPLAY 'P020 - ABRIU O CURSOR C01' */
                    _.Display($"P020 - ABRIU O CURSOR C01");

                    /*" -317- END-IF */
                }


                /*" -318- SET W88-INI-CURSOR1 TO TRUE */
                FILLER_1["W88_INI_CURSOR1"] = true;

                /*" -319- ELSE */
            }
            else
            {


                /*" -320- DISPLAY ' ' */
                _.Display($" ");

                /*" -321- DISPLAY 'ERRO NA ABERTURA DO CURSOR C01' */
                _.Display($"ERRO NA ABERTURA DO CURSOR C01");

                /*" -322- MOVE '*** ANALISE SQLCODE ***' TO W77-MENSAGEM */
                _.Move("*** ANALISE SQLCODE ***", AREA_DE_WORK.W77_MENSAGEM);

                /*" -323- GO TO P999-DB2-ERROR */

                P999_DB2_ERROR_SECTION(); //GOTO
                return;

                /*" -327- END-IF */
            }


            /*" -329- PERFORM P030-FETCH-PLANOS THRU P030-SAIDA */

            P030_FETCH_PLANOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P030_SAIDA*/


            /*" -330- PERFORM UNTIL W88-FIM-CURSOR1 */

            while (!(FILLER_1["W88_FIM_CURSOR1"]))
            {

                /*" -331- PERFORM P040-BUSCA-TITULOS THRU P040-SAIDA */

                P040_BUSCA_TITULOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P040_SAIDA*/


                /*" -332- PERFORM P030-FETCH-PLANOS THRU P030-SAIDA */

                P030_FETCH_PLANOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P030_SAIDA*/


                /*" -332- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" P020-ABRE-CURSOR-C01-DB-OPEN-1 */
        public void P020_ABRE_CURSOR_C01_DB_OPEN_1()
        {
            /*" -310- EXEC SQL OPEN C01-CURSOR1 END-EXEC */

            C01_CURSOR1.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P020_SAIDA*/

        [StopWatch]
        /*" P030-FETCH-PLANOS */
        private void P030_FETCH_PLANOS(bool isPerform = false)
        {
            /*" -348- PERFORM P030_FETCH_PLANOS_DB_FETCH_1 */

            P030_FETCH_PLANOS_DB_FETCH_1();

            /*" -351-  EVALUATE SQLCODE  */

            /*" -352-  WHEN ZEROS  */

            /*" -352- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -353- MOVE FC239-NUM-PLANO TO W77-PLANO */
                _.Move(FC239.DCLFC_PLANO_EMP_PARC.FC239_NUM_PLANO, AREA_DE_WORK.W77_PLANO);

                /*" -354- MOVE FC239-COD-RAMO TO W77-RAMO */
                _.Move(FC239.DCLFC_PLANO_EMP_PARC.FC239_COD_RAMO, AREA_DE_WORK.W77_RAMO);

                /*" -355- MOVE FC239-NUM-MOD-PLANO TO W77-MOD-PLANO */
                _.Move(FC239.DCLFC_PLANO_EMP_PARC.FC239_NUM_MOD_PLANO, AREA_DE_WORK.W77_MOD_PLANO);

                /*" -356- ADD 1 TO W77-LIDOS-C01 */
                AREA_DE_WORK.W77_LIDOS_C01.Value = AREA_DE_WORK.W77_LIDOS_C01 + 1;

                /*" -357- IF W88-TRACE-ON */

                if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
                {

                    /*" -360- DISPLAY 'P030 - LEU O PLANO/RAMO <' W77-PLANO '/' W77-RAMO '/' W77-MOD-PLANO '>' */

                    $"P030 - LEU O PLANO/RAMO <{AREA_DE_WORK.W77_PLANO}/{AREA_DE_WORK.W77_RAMO}/{AREA_DE_WORK.W77_MOD_PLANO}>"
                    .Display();

                    /*" -361- END-IF */
                }


                /*" -362- CONTINUE */

                /*" -363-  WHEN +100  */

                /*" -363- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -364- IF W77-LIDOS-C01 EQUAL ZEROS */

                if (AREA_DE_WORK.W77_LIDOS_C01 == 00)
                {

                    /*" -365- DISPLAY 'P030 - NENHUM PLANO ENCONTRADO NO CURSOR' */
                    _.Display($"P030 - NENHUM PLANO ENCONTRADO NO CURSOR");

                    /*" -367- END-IF */
                }


                /*" -367- PERFORM P030_FETCH_PLANOS_DB_CLOSE_1 */

                P030_FETCH_PLANOS_DB_CLOSE_1();

                /*" -370- SET W88-FIM-CURSOR1 TO TRUE */
                FILLER_1["W88_FIM_CURSOR1"] = true;

                /*" -371-  WHEN OTHER  */

                /*" -371- ELSE */
            }
            else
            {


                /*" -372- DISPLAY ' ' */
                _.Display($" ");

                /*" -373- DISPLAY ' ERRO FETCH CURSOR <C01-CURSOR1>' */
                _.Display($" ERRO FETCH CURSOR <C01-CURSOR1>");

                /*" -374- MOVE '*** ANALISE SQLCODE ***' TO W77-MENSAGEM */
                _.Move("*** ANALISE SQLCODE ***", AREA_DE_WORK.W77_MENSAGEM);

                /*" -375- GO TO P999-DB2-ERROR */

                P999_DB2_ERROR_SECTION(); //GOTO
                return;

                /*" -375-  END-EVALUATE.  */

                /*" -375- END-IF. */
            }


        }

        [StopWatch]
        /*" P030-FETCH-PLANOS-DB-FETCH-1 */
        public void P030_FETCH_PLANOS_DB_FETCH_1()
        {
            /*" -348- EXEC SQL FETCH C01-CURSOR1 INTO :FC239-NUM-PLANO , :FC239-IDE-CLIENTE , :FC239-COD-RAMO , :FC239-NUM-MOD-PLANO , :FC239-QTD-DIAS-CANCELA END-EXEC */

            if (C01_CURSOR1.Fetch())
            {
                _.Move(C01_CURSOR1.FC239_NUM_PLANO, FC239.DCLFC_PLANO_EMP_PARC.FC239_NUM_PLANO);
                _.Move(C01_CURSOR1.FC239_IDE_CLIENTE, FC239.DCLFC_PLANO_EMP_PARC.FC239_IDE_CLIENTE);
                _.Move(C01_CURSOR1.FC239_COD_RAMO, FC239.DCLFC_PLANO_EMP_PARC.FC239_COD_RAMO);
                _.Move(C01_CURSOR1.FC239_NUM_MOD_PLANO, FC239.DCLFC_PLANO_EMP_PARC.FC239_NUM_MOD_PLANO);
                _.Move(C01_CURSOR1.FC239_QTD_DIAS_CANCELA, FC239.DCLFC_PLANO_EMP_PARC.FC239_QTD_DIAS_CANCELA);
            }

        }

        [StopWatch]
        /*" P030-FETCH-PLANOS-DB-CLOSE-1 */
        public void P030_FETCH_PLANOS_DB_CLOSE_1()
        {
            /*" -367- EXEC SQL CLOSE C01-CURSOR1 END-EXEC */

            C01_CURSOR1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P030_SAIDA*/

        [StopWatch]
        /*" P040-BUSCA-TITULOS */
        private void P040_BUSCA_TITULOS(bool isPerform = false)
        {
            /*" -383- PERFORM P040_BUSCA_TITULOS_DB_OPEN_1 */

            P040_BUSCA_TITULOS_DB_OPEN_1();

            /*" -386- IF SQLCODE = ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -387- IF W88-TRACE-ON */

                if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
                {

                    /*" -388- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -389- DISPLAY 'P030 - ABRIU O CURSOR C02' */
                    _.Display($"P030 - ABRIU O CURSOR C02");

                    /*" -390- END-IF */
                }


                /*" -391- SET W88-INI-CURSOR2 TO TRUE */
                FILLER_2["W88_INI_CURSOR2"] = true;

                /*" -392- ELSE */
            }
            else
            {


                /*" -393- DISPLAY ' ' */
                _.Display($" ");

                /*" -394- DISPLAY 'ERRO NA ABERTURA DO CURSOR C02' */
                _.Display($"ERRO NA ABERTURA DO CURSOR C02");

                /*" -395- MOVE '*** ANALISE SQLCODE ***' TO W77-MENSAGEM */
                _.Move("*** ANALISE SQLCODE ***", AREA_DE_WORK.W77_MENSAGEM);

                /*" -396- GO TO P999-DB2-ERROR */

                P999_DB2_ERROR_SECTION(); //GOTO
                return;

                /*" -398- END-IF */
            }


            /*" -399- PERFORM UNTIL W88-FIM-CURSOR2 */

            while (!(FILLER_2["W88_FIM_CURSOR2"]))
            {

                /*" -400- PERFORM P050-FETCH-TITULOS THRU P050-SAIDA */

                P050_FETCH_TITULOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P050_SAIDA*/


                /*" -400- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" P040-BUSCA-TITULOS-DB-OPEN-1 */
        public void P040_BUSCA_TITULOS_DB_OPEN_1()
        {
            /*" -383- EXEC SQL OPEN C02-CURSOR2 END-EXEC */

            C02_CURSOR2.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P040_SAIDA*/

        [StopWatch]
        /*" P050-FETCH-TITULOS */
        private void P050_FETCH_TITULOS(bool isPerform = false)
        {
            /*" -416- PERFORM P050_FETCH_TITULOS_DB_FETCH_1 */

            P050_FETCH_TITULOS_DB_FETCH_1();

            /*" -419- MOVE FCPROPOS-NUM-PROPOSTA TO W77-PROPOSTA */
            _.Move(FCPROPOS.DCLFC_PROPOSTA.FCPROPOS_NUM_PROPOSTA, AREA_DE_WORK.W77_PROPOSTA);

            /*" -420- MOVE FCPROPOS-NUM-NSA TO W77-NSA */
            _.Move(FCPROPOS.DCLFC_PROPOSTA.FCPROPOS_NUM_NSA, AREA_DE_WORK.W77_NSA);

            /*" -421- MOVE FCTITULO-NUM-PLANO TO W77-PLANO */
            _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_PLANO, AREA_DE_WORK.W77_PLANO);

            /*" -422- MOVE FCTITULO-NUM-SERIE TO W77-SERIE */
            _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_SERIE, AREA_DE_WORK.W77_SERIE);

            /*" -424- MOVE FCTITULO-NUM-TITULO TO W77-TITULO */
            _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_TITULO, AREA_DE_WORK.W77_TITULO);

            /*" -425-  EVALUATE SQLCODE  */

            /*" -426-  WHEN ZEROS  */

            /*" -426- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -427- ADD 1 TO W77-LIDOS-C02 */
                AREA_DE_WORK.W77_LIDOS_C02.Value = AREA_DE_WORK.W77_LIDOS_C02 + 1;

                /*" -428- IF W88-TRACE-ON */

                if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
                {

                    /*" -432- DISPLAY 'TITULO <' W77-PROPOSTA '/' W77-PLANO '/' W77-SERIE '/' W77-TITULO '> ENCONTRADO' */

                    $"TITULO <{AREA_DE_WORK.W77_PROPOSTA}/{AREA_DE_WORK.W77_PLANO}/{AREA_DE_WORK.W77_SERIE}/{AREA_DE_WORK.W77_TITULO}> ENCONTRADO"
                    .Display();

                    /*" -433- END-IF */
                }


                /*" -434- PERFORM P060-UPDATE-STA-TITULO THRU P060-SAIDA */

                P060_UPDATE_STA_TITULO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P060_SAIDA*/


                /*" -437- COMPUTE W77-VLR-TOT-CANCEL = W77-VLR-TOT-CANCEL + FCTITULO-VLR-MENSALIDADE */
                AREA_DE_WORK.W77_VLR_TOT_CANCEL.Value = AREA_DE_WORK.W77_VLR_TOT_CANCEL + FCTITULO.DCLFC_TITULO.FCTITULO_VLR_MENSALIDADE;

                /*" -438- PERFORM P090-CANCELA-PROPOSTA THRU P090-SAIDA */

                P090_CANCELA_PROPOSTA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P090_SAIDA*/


                /*" -439-  WHEN +100  */

                /*" -439- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -440- IF W77-LIDOS-C02 EQUAL ZEROS */

                if (AREA_DE_WORK.W77_LIDOS_C02 == 00)
                {

                    /*" -443- DISPLAY 'NAO EXISTEM TITULOS PARA O PLANO/RAMO <' W77-PLANO '/' W77-RAMO '> - LE PROXIMO.' */

                    $"NAO EXISTEM TITULOS PARA O PLANO/RAMO <{AREA_DE_WORK.W77_PLANO}/{AREA_DE_WORK.W77_RAMO}> - LE PROXIMO."
                    .Display();

                    /*" -445- END-IF */
                }


                /*" -445- PERFORM P050_FETCH_TITULOS_DB_CLOSE_1 */

                P050_FETCH_TITULOS_DB_CLOSE_1();

                /*" -448- SET W88-FIM-CURSOR2 TO TRUE */
                FILLER_2["W88_FIM_CURSOR2"] = true;

                /*" -449-  WHEN OTHER  */

                /*" -449- ELSE */
            }
            else
            {


                /*" -453- STRING 'ERRO SQLCODE <' W77-PLANO '/' W77-RAMO '>' DELIMITED BY SIZE INTO W77-MENSAGEM END-STRING */
                #region STRING
                var spl1 = "ERRO SQLCODE <" + AREA_DE_WORK.W77_PLANO.GetMoveValues();
                spl1 += "/";
                var spl2 = AREA_DE_WORK.W77_RAMO.GetMoveValues();
                spl2 += ">";
                var results3 = spl1 + spl2;
                _.Move(results3, AREA_DE_WORK.W77_MENSAGEM);
                #endregion

                /*" -454- GO TO P999-DB2-ERROR */

                P999_DB2_ERROR_SECTION(); //GOTO
                return;

                /*" -454-  END-EVALUATE.  */

                /*" -454- END-IF. */
            }


        }

        [StopWatch]
        /*" P050-FETCH-TITULOS-DB-FETCH-1 */
        public void P050_FETCH_TITULOS_DB_FETCH_1()
        {
            /*" -416- EXEC SQL FETCH C02-CURSOR2 INTO :FCPROPOS-NUM-PROPOSTA , :FCPROPOS-NUM-NSA , :FCTITULO-NUM-PLANO , :FCTITULO-NUM-SERIE , :FCTITULO-NUM-TITULO , :FCTITULO-IDE-TITULAR , :FCTITULO-VLR-MENSALIDADE END-EXEC */

            if (C02_CURSOR2.Fetch())
            {
                _.Move(C02_CURSOR2.FCPROPOS_NUM_PROPOSTA, FCPROPOS.DCLFC_PROPOSTA.FCPROPOS_NUM_PROPOSTA);
                _.Move(C02_CURSOR2.FCPROPOS_NUM_NSA, FCPROPOS.DCLFC_PROPOSTA.FCPROPOS_NUM_NSA);
                _.Move(C02_CURSOR2.FCTITULO_NUM_PLANO, FCTITULO.DCLFC_TITULO.FCTITULO_NUM_PLANO);
                _.Move(C02_CURSOR2.FCTITULO_NUM_SERIE, FCTITULO.DCLFC_TITULO.FCTITULO_NUM_SERIE);
                _.Move(C02_CURSOR2.FCTITULO_NUM_TITULO, FCTITULO.DCLFC_TITULO.FCTITULO_NUM_TITULO);
                _.Move(C02_CURSOR2.FCTITULO_IDE_TITULAR, FCTITULO.DCLFC_TITULO.FCTITULO_IDE_TITULAR);
                _.Move(C02_CURSOR2.FCTITULO_VLR_MENSALIDADE, FCTITULO.DCLFC_TITULO.FCTITULO_VLR_MENSALIDADE);
            }

        }

        [StopWatch]
        /*" P050-FETCH-TITULOS-DB-CLOSE-1 */
        public void P050_FETCH_TITULOS_DB_CLOSE_1()
        {
            /*" -445- EXEC SQL CLOSE C02-CURSOR2 END-EXEC */

            C02_CURSOR2.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P050_SAIDA*/

        [StopWatch]
        /*" P060-UPDATE-STA-TITULO */
        private void P060_UPDATE_STA_TITULO(bool isPerform = false)
        {
            /*" -463- IF W88-TRACE-ON */

            if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
            {

                /*" -464- DISPLAY 'P060-UPDATE-STA-TITULO' */
                _.Display($"P060-UPDATE-STA-TITULO");

                /*" -466- END-IF */
            }


            /*" -474- PERFORM P060_UPDATE_STA_TITULO_DB_UPDATE_1 */

            P060_UPDATE_STA_TITULO_DB_UPDATE_1();

            /*" -477-  EVALUATE SQLCODE  */

            /*" -478-  WHEN ZEROS  */

            /*" -478- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -479- ADD 1 TO W77-UPD-TITULO */
                AREA_DE_WORK.W77_UPD_TITULO.Value = AREA_DE_WORK.W77_UPD_TITULO + 1;

                /*" -480- IF W88-TRACE-ON */

                if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
                {

                    /*" -483- DISPLAY 'TITULO CANCELADO <' W77-PLANO '/' W77-SERIE '/' W77-TITULO '>' */

                    $"TITULO CANCELADO <{AREA_DE_WORK.W77_PLANO}/{AREA_DE_WORK.W77_SERIE}/{AREA_DE_WORK.W77_TITULO}>"
                    .Display();

                    /*" -484- END-IF */
                }


                /*" -486- PERFORM P070-GRAVA-HIST-TITULO THRU P070-SAIDA */

                P070_GRAVA_HIST_TITULO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P070_SAIDA*/


                /*" -487-  WHEN OTHER  */

                /*" -487- ELSE */
            }
            else
            {


                /*" -493- STRING 'ERRO AO CANCELAR TITULO <' W77-PLANO '/' W77-SERIE '/' W77-TITULO '>' DELIMITED BY SIZE INTO W77-MENSAGEM END-STRING */
                #region STRING
                var spl3 = "ERRO AO CANCELAR TITULO <" + AREA_DE_WORK.W77_PLANO.GetMoveValues();
                spl3 += "/";
                var spl4 = AREA_DE_WORK.W77_SERIE.GetMoveValues();
                spl4 += "/";
                var spl5 = AREA_DE_WORK.W77_TITULO.GetMoveValues();
                spl5 += ">";
                var results6 = spl3 + spl4 + spl5;
                _.Move(results6, AREA_DE_WORK.W77_MENSAGEM);
                #endregion

                /*" -494- GO TO P999-DB2-ERROR */

                P999_DB2_ERROR_SECTION(); //GOTO
                return;

                /*" -494-  END-EVALUATE.  */

                /*" -494- END-IF. */
            }


        }

        [StopWatch]
        /*" P060-UPDATE-STA-TITULO-DB-UPDATE-1 */
        public void P060_UPDATE_STA_TITULO_DB_UPDATE_1()
        {
            /*" -474- EXEC SQL UPDATE FDRCAP.FC_TITULO SET COD_SUB_STATUS = 'CAN' ,NOM_ULT_PROGRAMA = 'FC0105B' WHERE NUM_PLANO = :FCTITULO-NUM-PLANO AND NUM_SERIE = :FCTITULO-NUM-SERIE AND NUM_TITULO = :FCTITULO-NUM-TITULO END-EXEC */

            var p060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1 = new P060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1()
            {
                FCTITULO_NUM_TITULO = FCTITULO.DCLFC_TITULO.FCTITULO_NUM_TITULO.ToString(),
                FCTITULO_NUM_PLANO = FCTITULO.DCLFC_TITULO.FCTITULO_NUM_PLANO.ToString(),
                FCTITULO_NUM_SERIE = FCTITULO.DCLFC_TITULO.FCTITULO_NUM_SERIE.ToString(),
            };

            P060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1.Execute(p060_UPDATE_STA_TITULO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P060_SAIDA*/

        [StopWatch]
        /*" P070-GRAVA-HIST-TITULO */
        private void P070_GRAVA_HIST_TITULO(bool isPerform = false)
        {
            /*" -503- IF W88-TRACE-ON */

            if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
            {

                /*" -504- DISPLAY 'P070-GRAVA-HIST-TITULO' */
                _.Display($"P070-GRAVA-HIST-TITULO");

                /*" -506- END-IF */
            }


            /*" -507- INITIALIZE DCLFC-HIST-TITULO. */
            _.Initialize(
                FCHISTIT.DCLFC_HIST_TITULO
            );

            /*" -508- MOVE 'LIVR' TO FCHISTIT-COD-OPERACAO */
            _.Move("LIVR", FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_COD_OPERACAO);

            /*" -511- STRING 'Titulo cancelado. Com mais de 90 dias reservado.' DELIMITED BY SIZE INTO FCHISTIT-DES-MSG-ORIGEM-TEXT */
            #region STRING
            var spl6 = "Titulo cancelado. Com mais de 90 dias reservado.";
            _.Move(spl6, FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_DES_MSG_ORIGEM.FCHISTIT_DES_MSG_ORIGEM_TEXT);
            #endregion

            /*" -514- MOVE LENGTH OF FCHISTIT-DES-MSG-ORIGEM-TEXT TO FCHISTIT-DES-MSG-ORIGEM-LEN */
            _.Move(FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_DES_MSG_ORIGEM.FCHISTIT_DES_MSG_ORIGEM_TEXT.Value.Length, FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_DES_MSG_ORIGEM.FCHISTIT_DES_MSG_ORIGEM_LEN);

            /*" -515- MOVE SPACES TO FCHISTIT-DES-MSG-DESTINO-TEXT */
            _.Move("", FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_DES_MSG_DESTINO.FCHISTIT_DES_MSG_DESTINO_TEXT);

            /*" -518- MOVE LENGTH OF FCHISTIT-DES-MSG-DESTINO-TEXT TO FCHISTIT-DES-MSG-DESTINO-LEN */
            _.Move(FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_DES_MSG_DESTINO.FCHISTIT_DES_MSG_DESTINO_TEXT.Value.Length, FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_DES_MSG_DESTINO.FCHISTIT_DES_MSG_DESTINO_LEN);

            /*" -519- MOVE 'HTI' TO LK-IN-COD-SEQ */
            _.Move("HTI", LK_IN_COD_SEQ);

            /*" -520- PERFORM P100-ACESSA-SEQUENCE THRU P100-SAIDA */

            P100_ACESSA_SEQUENCE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P100_SAIDA*/


            /*" -522- MOVE LK-OUT-NUM-SEQ-FIM TO FCHISTIT-IDE-HIST-TITULO */
            _.Move(LK_OUT_NUM_SEQ_FIM, FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_IDE_HIST_TITULO);

            /*" -523- IF W88-TRACE-ON */

            if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
            {

                /*" -524- DISPLAY 'P070-GRAVA-HIST-TITULO' */
                _.Display($"P070-GRAVA-HIST-TITULO");

                /*" -526- END-IF */
            }


            /*" -527- MOVE 1 TO FCHISTIT-IDE-USUARIO */
            _.Move(1, FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_IDE_USUARIO);

            /*" -528- MOVE FCTITULO-NUM-PLANO TO FCHISTIT-NUM-PLANO */
            _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_PLANO, FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_NUM_PLANO);

            /*" -529- MOVE FCTITULO-NUM-SERIE TO FCHISTIT-NUM-SERIE */
            _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_SERIE, FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_NUM_SERIE);

            /*" -530- MOVE FCTITULO-NUM-TITULO TO FCHISTIT-NUM-TITULO */
            _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_TITULO, FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_NUM_TITULO);

            /*" -532- MOVE FCTITULO-IDE-TITULAR TO FCHISTIT-IDE-CLIENTE */
            _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_IDE_TITULAR, FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_IDE_CLIENTE);

            /*" -558- PERFORM P070_GRAVA_HIST_TITULO_DB_INSERT_1 */

            P070_GRAVA_HIST_TITULO_DB_INSERT_1();

            /*" -561-  EVALUATE SQLCODE  */

            /*" -562-  WHEN ZEROS  */

            /*" -562- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -563- CONTINUE */

                /*" -564-  WHEN OTHER  */

                /*" -564- ELSE */
            }
            else
            {


                /*" -565- MOVE FCTITULO-NUM-PLANO TO W77-PLANO */
                _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_PLANO, AREA_DE_WORK.W77_PLANO);

                /*" -566- MOVE FCTITULO-NUM-SERIE TO W77-SERIE */
                _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_SERIE, AREA_DE_WORK.W77_SERIE);

                /*" -567- MOVE FCTITULO-NUM-TITULO TO W77-TITULO */
                _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_TITULO, AREA_DE_WORK.W77_TITULO);

                /*" -568- MOVE LK-OUT-NUM-SEQ-FIM TO W77-NSA */
                _.Move(LK_OUT_NUM_SEQ_FIM, AREA_DE_WORK.W77_NSA);

                /*" -575- DISPLAY ' ' '==> ROTINA P070-GRAVA-HIST-TITULO' '    ERRO AO GRAVAR HISTORICO DO TITULO <' W77-PLANO '/' W77-SERIE '/' W77-TITULO '/' W77-PROPOSTA '>' */

                $" ==>ROTINAP070-GRAVA-HIST-TITULO ERROAOGRAVARHISTORICODOTITULO<{AREA_DE_WORK.W77_PLANO}/{AREA_DE_WORK.W77_SERIE}/{AREA_DE_WORK.W77_TITULO}/{AREA_DE_WORK.W77_PROPOSTA}>"
                .Display();

                /*" -576- MOVE '*** ANALISE SQLCODE ***' TO W77-MENSAGEM */
                _.Move("*** ANALISE SQLCODE ***", AREA_DE_WORK.W77_MENSAGEM);

                /*" -577- GO TO P999-DB2-ERROR */

                P999_DB2_ERROR_SECTION(); //GOTO
                return;

                /*" -577-  END-EVALUATE.  */

                /*" -577- END-IF. */
            }


        }

        [StopWatch]
        /*" P070-GRAVA-HIST-TITULO-DB-INSERT-1 */
        public void P070_GRAVA_HIST_TITULO_DB_INSERT_1()
        {
            /*" -558- EXEC SQL INSERT INTO FDRCAP.FC_HIST_TITULO (IDE_HIST_TITULO, COD_OPERACAO, DTH_REGISTRO, IDE_USUARIO, NUM_PLANO, NUM_SERIE, NUM_TITULO, COD_DETALHE, DES_MSG_ORIGEM, DES_MSG_DESTINO, IDE_CLIENTE, IDE_ENDERECO) VALUES (:FCHISTIT-IDE-HIST-TITULO, :FCHISTIT-COD-OPERACAO, CURRENT TIMESTAMP, :FCHISTIT-IDE-USUARIO, :FCHISTIT-NUM-PLANO, :FCHISTIT-NUM-SERIE, :FCHISTIT-NUM-TITULO, NULL, :FCHISTIT-DES-MSG-ORIGEM, :FCHISTIT-DES-MSG-DESTINO, :FCHISTIT-IDE-CLIENTE, NULL) END-EXEC */

            var p070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1 = new P070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1()
            {
                FCHISTIT_IDE_HIST_TITULO = FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_IDE_HIST_TITULO.ToString(),
                FCHISTIT_COD_OPERACAO = FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_COD_OPERACAO.ToString(),
                FCHISTIT_IDE_USUARIO = FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_IDE_USUARIO.ToString(),
                FCHISTIT_NUM_PLANO = FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_NUM_PLANO.ToString(),
                FCHISTIT_NUM_SERIE = FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_NUM_SERIE.ToString(),
                FCHISTIT_NUM_TITULO = FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_NUM_TITULO.ToString(),
                FCHISTIT_DES_MSG_ORIGEM = FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_DES_MSG_ORIGEM.ToString(),
                FCHISTIT_DES_MSG_DESTINO = FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_DES_MSG_DESTINO.ToString(),
                FCHISTIT_IDE_CLIENTE = FCHISTIT.DCLFC_HIST_TITULO.FCHISTIT_IDE_CLIENTE.ToString(),
            };

            P070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1.Execute(p070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P070_SAIDA*/

        [StopWatch]
        /*" P080-ATUALIZA-RISCO-AC */
        private void P080_ATUALIZA_RISCO_AC(bool isPerform = false)
        {
            /*" -589- MOVE FCTITULO-NUM-PLANO TO W77-PLANO */
            _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_PLANO, AREA_DE_WORK.W77_PLANO);

            /*" -591- MOVE FCTITULO-NUM-TITULO TO W77-TITULO */
            _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_TITULO, AREA_DE_WORK.W77_TITULO);

            /*" -592- IF W88-TRACE-ON */

            if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
            {

                /*" -593- DISPLAY 'P080-ATUALIZA-RISCO-AC' */
                _.Display($"P080-ATUALIZA-RISCO-AC");

                /*" -595- END-IF */
            }


            /*" -600- PERFORM P080_ATUALIZA_RISCO_AC_DB_UPDATE_1 */

            P080_ATUALIZA_RISCO_AC_DB_UPDATE_1();

            /*" -603-  EVALUATE SQLCODE  */

            /*" -604-  WHEN ZEROS  */

            /*" -604- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -605- IF W88-TRACE-ON */

                if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
                {

                    /*" -608- DISPLAY '==> UPDATE NA QTD FC_RISCO_ACOPLADO - ' 'PLA/TIT <' W77-PLANO '/' W77-TITULO '>' */

                    $"==> UPDATE NA QTD FC_RISCO_ACOPLADO - PLA/TIT <{AREA_DE_WORK.W77_PLANO}/{AREA_DE_WORK.W77_TITULO}>"
                    .Display();

                    /*" -609- END-IF */
                }


                /*" -611- CONTINUE */

                /*" -612-  WHEN OTHER  */

                /*" -612- ELSE */
            }
            else
            {


                /*" -617- STRING 'ERRO UPDATE FC_RISCO_ACOPLADO P/ PLA/TIT <' W77-PLANO '/' W77-TITULO '>' DELIMITED BY SIZE INTO W77-MENSAGEM END-STRING */
                #region STRING
                var spl7 = "ERRO UPDATE FC_RISCO_ACOPLADO P/ PLA/TIT <" + AREA_DE_WORK.W77_PLANO.GetMoveValues();
                spl7 += "/";
                var spl8 = AREA_DE_WORK.W77_TITULO.GetMoveValues();
                spl8 += ">";
                var results9 = spl7 + spl8;
                _.Move(results9, AREA_DE_WORK.W77_MENSAGEM);
                #endregion

                /*" -618- GO TO P999-DB2-ERROR */

                P999_DB2_ERROR_SECTION(); //GOTO
                return;

                /*" -618-  END-EVALUATE.  */

                /*" -618- END-IF. */
            }


        }

        [StopWatch]
        /*" P080-ATUALIZA-RISCO-AC-DB-UPDATE-1 */
        public void P080_ATUALIZA_RISCO_AC_DB_UPDATE_1()
        {
            /*" -600- EXEC SQL UPDATE FDRCAP.FC_RISCO_ACOPLADO SET QTD_TITULOS = QTD_TITULOS - 1 WHERE NUM_PLANO = :FCTITULO-NUM-PLANO AND NUM_TITULO = :FCTITULO-NUM-TITULO END-EXEC */

            var p080_ATUALIZA_RISCO_AC_DB_UPDATE_1_Update1 = new P080_ATUALIZA_RISCO_AC_DB_UPDATE_1_Update1()
            {
                FCTITULO_NUM_TITULO = FCTITULO.DCLFC_TITULO.FCTITULO_NUM_TITULO.ToString(),
                FCTITULO_NUM_PLANO = FCTITULO.DCLFC_TITULO.FCTITULO_NUM_PLANO.ToString(),
            };

            P080_ATUALIZA_RISCO_AC_DB_UPDATE_1_Update1.Execute(p080_ATUALIZA_RISCO_AC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P080_SAIDA*/

        [StopWatch]
        /*" P090-CANCELA-PROPOSTA */
        private void P090_CANCELA_PROPOSTA(bool isPerform = false)
        {
            /*" -626- IF W88-TRACE-ON */

            if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
            {

                /*" -631- DISPLAY 'P090-CANCELA-PROPOSTA' W77-PROPOSTA '/' W77-PLANO '/' W77-SERIE '/' W77-TITULO '/' W77-NSA '>' */

                $"P090-CANCELA-PROPOSTA{AREA_DE_WORK.W77_PROPOSTA}/{AREA_DE_WORK.W77_PLANO}/{AREA_DE_WORK.W77_SERIE}/{AREA_DE_WORK.W77_TITULO}/{AREA_DE_WORK.W77_NSA}>"
                .Display();

                /*" -632- DISPLAY ' ' */
                _.Display($" ");

                /*" -634- END-IF */
            }


            /*" -642- PERFORM P090_CANCELA_PROPOSTA_DB_UPDATE_1 */

            P090_CANCELA_PROPOSTA_DB_UPDATE_1();

            /*" -645-  EVALUATE SQLCODE  */

            /*" -646-  WHEN ZEROS  */

            /*" -646- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -647- ADD 1 TO W77-UPD-PROPOSTA */
                AREA_DE_WORK.W77_UPD_PROPOSTA.Value = AREA_DE_WORK.W77_UPD_PROPOSTA + 1;

                /*" -648- IF W88-TRACE-ON */

                if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
                {

                    /*" -651- DISPLAY 'PROPOSTA CANCELADA <' W77-PLANO '/' W77-PROPOSTA '/' W77-NSA '>' */

                    $"PROPOSTA CANCELADA <{AREA_DE_WORK.W77_PLANO}/{AREA_DE_WORK.W77_PROPOSTA}/{AREA_DE_WORK.W77_NSA}>"
                    .Display();

                    /*" -652- END-IF */
                }


                /*" -653-  WHEN OTHER  */

                /*" -653- ELSE */
            }
            else
            {


                /*" -659- STRING 'ERRO AO CANCELAR PROPOSTA <' W77-PLANO '/' W77-PROPOSTA '/' W77-NSA '>' DELIMITED BY SIZE INTO W77-MENSAGEM END-STRING */
                #region STRING
                var spl9 = "ERRO AO CANCELAR PROPOSTA <" + AREA_DE_WORK.W77_PLANO.GetMoveValues();
                spl9 += "/";
                var spl10 = AREA_DE_WORK.W77_PROPOSTA.GetMoveValues();
                spl10 += "/";
                var spl11 = AREA_DE_WORK.W77_NSA.GetMoveValues();
                spl11 += ">";
                var results12 = spl9 + spl10 + spl11;
                _.Move(results12, AREA_DE_WORK.W77_MENSAGEM);
                #endregion

                /*" -660- GO TO P999-DB2-ERROR */

                P999_DB2_ERROR_SECTION(); //GOTO
                return;

                /*" -663-  END-EVALUATE.  */

                /*" -663- END-IF. */
            }


            /*" -664- MOVE FCTITULO-NUM-PLANO TO FCHISPRO-NUM-PLANO */
            _.Move(FCTITULO.DCLFC_TITULO.FCTITULO_NUM_PLANO, FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_NUM_PLANO);

            /*" -665- MOVE FCPROPOS-NUM-PROPOSTA TO FCHISPRO-NUM-PROPOSTA */
            _.Move(FCPROPOS.DCLFC_PROPOSTA.FCPROPOS_NUM_PROPOSTA, FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_NUM_PROPOSTA);

            /*" -666- MOVE FCPROPOS-NUM-NSA TO FCHISPRO-NUM-NSA */
            _.Move(FCPROPOS.DCLFC_PROPOSTA.FCPROPOS_NUM_NSA, FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_NUM_NSA);

            /*" -667- MOVE 1 TO FCHISPRO-IDE-USUARIO */
            _.Move(1, FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_IDE_USUARIO);

            /*" -669- MOVE 'CANC' TO FCHISPRO-COD-OPERACAO */
            _.Move("CANC", FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_COD_OPERACAO);

            /*" -672- INITIALIZE FCHISPRO-DES-MSG-ORIGEM FCHISPRO-DES-MSG-DESTINO */
            _.Initialize(
                FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_DES_MSG_ORIGEM
                , FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_DES_MSG_DESTINO
            );

            /*" -674- MOVE 'Proposta cancelada. Mais de 90 dias aguardando pagto.' TO FCHISPRO-DES-MSG-ORIGEM */
            _.Move("Proposta cancelada. Mais de 90 dias aguardando pagto.", FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_DES_MSG_ORIGEM);

            /*" -676- MOVE SPACES TO FCHISPRO-DES-MSG-DESTINO */
            _.Move("", FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_DES_MSG_DESTINO);

            /*" -696- PERFORM P090_CANCELA_PROPOSTA_DB_INSERT_1 */

            P090_CANCELA_PROPOSTA_DB_INSERT_1();

            /*" -699- IF W88-TRACE-ON */

            if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
            {

                /*" -700- DISPLAY ' ' */
                _.Display($" ");

                /*" -701- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -702- DISPLAY '*** FEZ INSERT FC_HIST_PROPOSTA        ***' */
                _.Display($"*** FEZ INSERT FC_HIST_PROPOSTA        ***");

                /*" -703- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -704- DISPLAY '*** NUM_PLANO        = ' FCHISPRO-NUM-PLANO */
                _.Display($"*** NUM_PLANO        = {FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_NUM_PLANO}");

                /*" -705- DISPLAY '*** NUM_PROPOSTA     = ' FCHISPRO-NUM-PROPOSTA */
                _.Display($"*** NUM_PROPOSTA     = {FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_NUM_PROPOSTA}");

                /*" -706- DISPLAY '*** NUM_NSA          = ' FCHISPRO-NUM-NSA */
                _.Display($"*** NUM_NSA          = {FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_NUM_NSA}");

                /*" -707- DISPLAY '*** DTH/HRS REGISTRO = ' FUNCTION CURRENT-DATE */
                _.Display($"*** DTH/HRS REGISTRO = {_.CurrentDate()}");

                /*" -708- DISPLAY '*** IDE_USUARIO      = ' FCHISPRO-IDE-USUARIO */
                _.Display($"*** IDE_USUARIO      = {FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_IDE_USUARIO}");

                /*" -709- DISPLAY '*** COD_OPERACAO     = ' FCHISPRO-COD-OPERACAO */
                _.Display($"*** COD_OPERACAO     = {FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_COD_OPERACAO}");

                /*" -710- DISPLAY '*** DES_MSG_ORIGEM   = ' FCHISPRO-DES-MSG-ORIGEM */
                _.Display($"*** DES_MSG_ORIGEM   = {FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_DES_MSG_ORIGEM}");

                /*" -711- DISPLAY '*** DES_MSG_DESTINO  = ' FCHISPRO-DES-MSG-DESTINO */
                _.Display($"*** DES_MSG_DESTINO  = {FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_DES_MSG_DESTINO}");

                /*" -712- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -713- DISPLAY ' ' */
                _.Display($" ");

                /*" -715- END-IF. */
            }


            /*" -716- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -717- WHEN 000 */
                case 000:

                    /*" -718- WHEN -803 */
                    break;
                case -803:

                /*" -719- CONTINUE */

                /*" -720- WHEN OTHER */
                default:

                    /*" -721- MOVE FCHISPRO-NUM-PLANO TO W77-PLANO */
                    _.Move(FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_NUM_PLANO, AREA_DE_WORK.W77_PLANO);

                    /*" -722- MOVE FCHISPRO-NUM-PROPOSTA TO W77-PROPOSTA */
                    _.Move(FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_NUM_PROPOSTA, AREA_DE_WORK.W77_PROPOSTA);

                    /*" -723- MOVE FCHISPRO-NUM-NSA TO W77-NSA */
                    _.Move(FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_NUM_NSA, AREA_DE_WORK.W77_NSA);

                    /*" -727- STRING '*** ERRO NO INSERT <FC_HIST_PROPOSTA> ' 'NUM-PLA <' W77-PLANO '> NUM-PRO <' W77-PROPOSTA '> NUM NSA <' W77-NSA '> ***' DELIMITED BY SIZE INTO W77-MENSAGEM */
                    #region STRING
                    var spl12 = "*** ERRO NO INSERT <FC_HIST_PROPOSTA> " + "NUM-PLA <" + AREA_DE_WORK.W77_PLANO.GetMoveValues();
                    spl12 += "> NUM-PRO <";
                    var spl13 = AREA_DE_WORK.W77_PROPOSTA.GetMoveValues();
                    spl13 += "> NUM NSA <";
                    var spl14 = AREA_DE_WORK.W77_NSA.GetMoveValues();
                    spl14 += "> ***";
                    var results15 = spl12 + spl13 + spl14;
                    _.Move(results15, AREA_DE_WORK.W77_MENSAGEM);
                    #endregion

                    /*" -728- GO TO P999-DB2-ERROR */

                    P999_DB2_ERROR_SECTION(); //GOTO
                    return;

                    /*" -729- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" P090-CANCELA-PROPOSTA-DB-UPDATE-1 */
        public void P090_CANCELA_PROPOSTA_DB_UPDATE_1()
        {
            /*" -642- EXEC SQL UPDATE FDRCAP.FC_PROPOSTA SET STA_PROPOSTA = 'CAN' , IND_ENVIO_SIGPF = 2 WHERE NUM_PLANO = :FCTITULO-NUM-PLANO AND NUM_PROPOSTA = :FCPROPOS-NUM-PROPOSTA AND NUM_NSA = :FCPROPOS-NUM-NSA AND NUM_MOD_PLANO = :FC239-NUM-MOD-PLANO END-EXEC */

            var p090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1 = new P090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1()
            {
                FCPROPOS_NUM_PROPOSTA = FCPROPOS.DCLFC_PROPOSTA.FCPROPOS_NUM_PROPOSTA.ToString(),
                FC239_NUM_MOD_PLANO = FC239.DCLFC_PLANO_EMP_PARC.FC239_NUM_MOD_PLANO.ToString(),
                FCTITULO_NUM_PLANO = FCTITULO.DCLFC_TITULO.FCTITULO_NUM_PLANO.ToString(),
                FCPROPOS_NUM_NSA = FCPROPOS.DCLFC_PROPOSTA.FCPROPOS_NUM_NSA.ToString(),
            };

            P090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1.Execute(p090_CANCELA_PROPOSTA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" P090-CANCELA-PROPOSTA-DB-INSERT-1 */
        public void P090_CANCELA_PROPOSTA_DB_INSERT_1()
        {
            /*" -696- EXEC SQL INSERT INTO FDRCAP.FC_HIST_PROPOSTA ( NUM_PLANO , NUM_PROPOSTA , NUM_NSA , DTH_REGISTRO , HRS_REGISTRO , IDE_USUARIO , COD_OPERACAO , DES_MSG_ORIGEM , DES_MSG_DESTINO) VALUES( :FCHISPRO-NUM-PLANO , :FCHISPRO-NUM-PROPOSTA , :FCHISPRO-NUM-NSA , CURRENT DATE , CURRENT TIME , :FCHISPRO-IDE-USUARIO , :FCHISPRO-COD-OPERACAO , :FCHISPRO-DES-MSG-ORIGEM , :FCHISPRO-DES-MSG-DESTINO) END-EXEC. */

            var p090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1 = new P090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1()
            {
                FCHISPRO_NUM_PLANO = FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_NUM_PLANO.ToString(),
                FCHISPRO_NUM_PROPOSTA = FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_NUM_PROPOSTA.ToString(),
                FCHISPRO_NUM_NSA = FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_NUM_NSA.ToString(),
                FCHISPRO_IDE_USUARIO = FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_IDE_USUARIO.ToString(),
                FCHISPRO_COD_OPERACAO = FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_COD_OPERACAO.ToString(),
                FCHISPRO_DES_MSG_ORIGEM = FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_DES_MSG_ORIGEM.ToString(),
                FCHISPRO_DES_MSG_DESTINO = FCHISPRO.DCLFC_HIST_PROPOSTA.FCHISPRO_DES_MSG_DESTINO.ToString(),
            };

            P090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1.Execute(p090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P090_SAIDA*/

        [StopWatch]
        /*" P100-ACESSA-SEQUENCE */
        private void P100_ACESSA_SEQUENCE(bool isPerform = false)
        {
            /*" -746- IF W88-TRACE-ON */

            if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
            {

                /*" -747- DISPLAY 'P100-ACESSA-SEQUENCE' */
                _.Display($"P100-ACESSA-SEQUENCE");

                /*" -749- END-IF */
            }


            /*" -760- INITIALIZE W77-RETC W77-OUT-RETC LK-IN-QTD-SEQ LK-OUT-NUM-SEQ-INI LK-OUT-NUM-SEQ-FIM LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE */
            _.Initialize(
                AREA_DE_WORK.W77_RETC
                , AREA_DE_WORK.W77_OUT_RETC
                , LK_IN_QTD_SEQ
                , LK_OUT_NUM_SEQ_INI
                , LK_OUT_NUM_SEQ_FIM
                , LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
            );

            /*" -762- MOVE 1 TO LK-IN-QTD-SEQ */
            _.Move(1, LK_IN_QTD_SEQ);

            /*" -772- CALL 'SPBFC003' USING LK-IN-COD-SEQ LK-IN-QTD-SEQ LK-OUT-NUM-SEQ-INI LK-OUT-NUM-SEQ-FIM LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE */
            _.Call("SPBFC003", LK_IN_COD_SEQ, LK_IN_QTD_SEQ, LK_OUT_NUM_SEQ_INI, LK_OUT_NUM_SEQ_FIM, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE);

            /*" -774- MOVE RETURN-CODE TO W77-RETC */
            _.Move(RETURN_CODE, AREA_DE_WORK.W77_RETC);

            /*" -775- IF W77-RETC NOT EQUAL ZEROS */

            if (AREA_DE_WORK.W77_RETC != 00)
            {

                /*" -779- STRING '*** ERRO NO CALL SPBFC003. ' 'RETURN-CODE <' W77-RETC '> ' 'COD-SEQ <' LK-IN-COD-SEQ '>' ' ***' DELIMITED BY SIZE INTO W77-MENSAGEM */
                #region STRING
                var spl15 = "*** ERRO NO CALL SPBFC003. " + "RETURN-CODE <" + AREA_DE_WORK.W77_RETC.GetMoveValues();
                spl15 += "> ";
                spl15 += "COD-SEQ <";
                var spl16 = LK_IN_COD_SEQ.GetMoveValues();
                spl16 += ">";
                spl16 += " ***";
                var results17 = spl15 + spl16;
                _.Move(results17, AREA_DE_WORK.W77_MENSAGEM);
                #endregion

                /*" -780- GO TO P999-DB2-ERROR */

                P999_DB2_ERROR_SECTION(); //GOTO
                return;

                /*" -782- END-IF */
            }


            /*" -784- MOVE LK-OUT-COD-RETORNO TO W77-OUT-RETC */
            _.Move(LK_OUT_COD_RETORNO, AREA_DE_WORK.W77_OUT_RETC);

            /*" -786- IF (W77-OUT-RETC NOT EQUAL ZEROS) OR (LK-OUT-MENSAGEM NOT = SPACES) */

            if ((AREA_DE_WORK.W77_OUT_RETC != 00) || (!LK_OUT_MENSAGEM.IsEmpty()))
            {

                /*" -787- MOVE LK-OUT-SQLCODE TO W77-SQLCODE */
                _.Move(LK_OUT_SQLCODE, WABEND.W77_SQLCODE);

                /*" -788- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -789- DISPLAY 'ERRO RETORNADO DA STORED PROCEDURE - SPBFC003' */
                _.Display($"ERRO RETORNADO DA STORED PROCEDURE - SPBFC003");

                /*" -790- DISPLAY '    COD-SEQ     <' LK-IN-COD-SEQ '>' */

                $"    COD-SEQ     <{LK_IN_COD_SEQ}>"
                .Display();

                /*" -791- DISPLAY '    RETCODE     <' W77-OUT-RETC '>' */

                $"    RETCODE     <{AREA_DE_WORK.W77_OUT_RETC}>"
                .Display();

                /*" -792- DISPLAY '    SQLCODE     <' W77-SQLCODE '>' */

                $"    SQLCODE     <{WABEND.W77_SQLCODE}>"
                .Display();

                /*" -793- DISPLAY '    MENSAGEM    <' LK-OUT-MENSAGEM '>' */

                $"    MENSAGEM    <{LK_OUT_MENSAGEM}>"
                .Display();

                /*" -794- DISPLAY '    ERRMC       <' LK-OUT-SQLERRMC '>' */

                $"    ERRMC       <{LK_OUT_SQLERRMC}>"
                .Display();

                /*" -795- DISPLAY '    SQLSTATE    <' LK-OUT-SQLSTATE '>' */

                $"    SQLSTATE    <{LK_OUT_SQLSTATE}>"
                .Display();

                /*" -796- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -797- GO TO P999-DB2-ERROR */

                P999_DB2_ERROR_SECTION(); //GOTO
                return;

                /*" -799- END-IF */
            }


            /*" -800- IF W88-TRACE-ON */

            if (LK_PARAMETRO.LK_TRACE["W88_TRACE_ON"])
            {

                /*" -801- DISPLAY ' ' */
                _.Display($" ");

                /*" -802- DISPLAY '===============================================' */
                _.Display($"===============================================");

                /*" -803- DISPLAY '>>> SEQUENCIA ATUALIZADA:' */
                _.Display($">>> SEQUENCIA ATUALIZADA:");

                /*" -804- DISPLAY '===============================================' */
                _.Display($"===============================================");

                /*" -805- DISPLAY '    COD SEQ   <' LK-IN-COD-SEQ '>' */

                $"    COD SEQ   <{LK_IN_COD_SEQ}>"
                .Display();

                /*" -806- DISPLAY '    NUM SEQ   <' LK-OUT-NUM-SEQ-FIM '>' */

                $"    NUM SEQ   <{LK_OUT_NUM_SEQ_FIM}>"
                .Display();

                /*" -807- DISPLAY '===============================================' */
                _.Display($"===============================================");

                /*" -807- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P100_SAIDA*/

        [StopWatch]
        /*" P999-FINAL-SECTION */
        private void P999_FINAL_SECTION()
        {
            /*" -818- MOVE W77-VLR-TOT-CANCEL TO W77-VLR-TOT-CANCEL-EDT */
            _.Move(AREA_DE_WORK.W77_VLR_TOT_CANCEL, AREA_DE_WORK.W77_VLR_TOT_CANCEL_EDT);

            /*" -819- DISPLAY ' ' */
            _.Display($" ");

            /*" -820- DISPLAY '              TOTALIZADORES           ' */
            _.Display($"              TOTALIZADORES           ");

            /*" -821- DISPLAY '--------------------------------------' */
            _.Display($"--------------------------------------");

            /*" -822- DISPLAY 'LIDOS NO CURSOR C01...: ' W77-LIDOS-C01 */
            _.Display($"LIDOS NO CURSOR C01...: {AREA_DE_WORK.W77_LIDOS_C01}");

            /*" -823- DISPLAY 'LIDOS NO CURSOR C02...: ' W77-LIDOS-C02 */
            _.Display($"LIDOS NO CURSOR C02...: {AREA_DE_WORK.W77_LIDOS_C02}");

            /*" -824- DISPLAY 'TITULOS CANCELADOS....: ' W77-UPD-TITULO */
            _.Display($"TITULOS CANCELADOS....: {AREA_DE_WORK.W77_UPD_TITULO}");

            /*" -825- DISPLAY 'PROPOSTAS CANCELADAS..: ' W77-UPD-PROPOSTA */
            _.Display($"PROPOSTAS CANCELADAS..: {AREA_DE_WORK.W77_UPD_PROPOSTA}");

            /*" -826- DISPLAY 'VLR TOTAL CANCELAMENTO: ' W77-VLR-TOT-CANCEL-EDT */
            _.Display($"VLR TOTAL CANCELAMENTO: {AREA_DE_WORK.W77_VLR_TOT_CANCEL_EDT}");

            /*" -827- DISPLAY ' ' */
            _.Display($" ");

            /*" -829- DISPLAY '--------------------------------------' . */
            _.Display($"--------------------------------------");

            /*" -830- IF W88-COMMIT */

            if (LK_PARAMETRO.LK_OPERACAO["W88_COMMIT"])
            {

                /*" -830- EXEC SQL COMMIT END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -832- DISPLAY ' ' */
                _.Display($" ");

                /*" -833- MOVE 'FC' TO LKG2-COD-SISTEM */
                _.Move("FC", REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_COD_SISTEM);

                /*" -834- MOVE W77-ROTINA TO LKG2-NOM-ROTINA */
                _.Move(AREA_DE_WORK.W77_ROTINA, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_NOM_ROTINA);

                /*" -835- MOVE 04 TO LKG2-SEQ-ETAPA */
                _.Move(04, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_SEQ_ETAPA);

                /*" -836- MOVE W77-PROGRAMA TO LKG2-NOM-PROGM */
                _.Move(AREA_DE_WORK.W77_PROGRAMA, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_NOM_PROGM);

                /*" -837- MOVE W77-LIDOS-C02 TO LKG2-QTD-REG-LIDOS */
                _.Move(AREA_DE_WORK.W77_LIDOS_C02, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_QTD_REG_LIDOS);

                /*" -838- MOVE W77-UPD-TITULO TO LKG2-QTD-REG-PROCS */
                _.Move(AREA_DE_WORK.W77_UPD_TITULO, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_QTD_REG_PROCS);

                /*" -839- MOVE W77-UPD-PROPOSTA TO LKG2-QTD-REG-ALTER */
                _.Move(AREA_DE_WORK.W77_UPD_PROPOSTA, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_QTD_REG_ALTER);

                /*" -840- MOVE 0 TO LKG2-QTD-REG-EXCLU */
                _.Move(0, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_QTD_REG_EXCLU);

                /*" -841- MOVE '1' TO LKG2-STA-EXECUCAO */
                _.Move("1", REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_STA_EXECUCAO);

                /*" -843- CALL 'FC1112S' USING REGISTR2-LINKAGE */
                _.Call("FC1112S", REGISTR2_LINKAGE);

                /*" -844- IF LKG2-RETN-CODE EQUAL 0 */

                if (REGISTR2_LINKAGE.LKG2_PARM_OUTPUT.LKG2_RETN_CODE == 0)
                {

                    /*" -844- EXEC SQL COMMIT END-EXEC */

                    DatabaseConnection.Instance.CommitTransaction();

                    /*" -846- ELSE */
                }
                else
                {


                    /*" -846- EXEC SQL ROLLBACK END-EXEC */

                    DatabaseConnection.Instance.RollbackTransaction();

                    /*" -848- DISPLAY 'EXECUTOU ROLLBACK - RETORNO FC1112S.' */
                    _.Display($"EXECUTOU ROLLBACK - RETORNO FC1112S.");

                    /*" -850- DISPLAY '<' LKG2-SQL-CODE '> ' '<' LKG2-RETN-CODE '> ' */

                    $"<{REGISTR2_LINKAGE.LKG2_PARM_OUTPUT.LKG2_SQL_CODE}> <{REGISTR2_LINKAGE.LKG2_PARM_OUTPUT.LKG2_RETN_CODE}> "
                    .Display();

                    /*" -851- DISPLAY '<' LKG2-MENS-ERRO '>' */

                    $"<{REGISTR2_LINKAGE.LKG2_PARM_OUTPUT.LKG2_MENS_ERRO}>"
                    .Display();

                    /*" -852- END-IF */
                }


                /*" -853- ELSE */
            }
            else
            {


                /*" -853- EXEC SQL ROLLBACK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -857- DISPLAY '--------------------------------------------' */
                _.Display($"--------------------------------------------");

                /*" -858- PERFORM 3 TIMES */

                for (int i = 0; i < 3; i++)
                {

                    /*" -859- DISPLAY '** ROLLBACK EFETUADO CONFORME PARAMETRO **' */
                    _.Display($"** ROLLBACK EFETUADO CONFORME PARAMETRO **");

                    /*" -861- END-PERFORM */
                }

                /*" -862- DISPLAY '--------------------------------------------' */
                _.Display($"--------------------------------------------");

                /*" -864- END-IF. */
            }


            /*" -865- DISPLAY ' ' */
            _.Display($" ");

            /*" -871- DISPLAY '*** FIM DO PROGRAMA FC0105B EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ' ***' . */

            $"*** FIM DO PROGRAMA FC0105B EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss} ***"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P999_SAIDA*/

        [StopWatch]
        /*" P999-DB2-ERROR-SECTION */
        private void P999_DB2_ERROR_SECTION()
        {
            /*" -879- DISPLAY ' ' */
            _.Display($" ");

            /*" -880- DISPLAY '*************************************' */
            _.Display($"*************************************");

            /*" -881- DISPLAY '* ERRO DE ACESSO NO BANCO DE DADOS  *' */
            _.Display($"* ERRO DE ACESSO NO BANCO DE DADOS  *");

            /*" -882- DISPLAY '*************************************' */
            _.Display($"*************************************");

            /*" -883- DISPLAY ' ' */
            _.Display($" ");

            /*" -884- DISPLAY W77-MENSAGEM */
            _.Display(AREA_DE_WORK.W77_MENSAGEM);

            /*" -885- DISPLAY ' ' */
            _.Display($" ");

            /*" -886- MOVE SQLCODE TO W77-SQLCODE */
            _.Move(DB.SQLCODE, WABEND.W77_SQLCODE);

            /*" -887- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, WABEND.WSQLERRMC);

            /*" -888- DISPLAY '==> SQLCODE  <' W77-SQLCODE '> ' */

            $"==> SQLCODE  <{WABEND.W77_SQLCODE}> "
            .Display();

            /*" -889- DISPLAY '==> SQLSTATE <' SQLSTATE '>' */

            $"==> SQLSTATE <{DB.SQLSTATE}>"
            .Display();

            /*" -890- DISPLAY '==> SQLERRMC <' SQLERRMC '> ' . */

            $"==> SQLERRMC <{DB.SQLERRMC}> "
            .Display();

            /*" -891- DISPLAY ' ' */
            _.Display($" ");

            /*" -891- EXEC SQL ROLLBACK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -893- DISPLAY ' ' */
            _.Display($" ");

            /*" -894- DISPLAY '*** ROLLBACK EXECUTADO ***' */
            _.Display($"*** ROLLBACK EXECUTADO ***");

            /*" -894- DISPLAY ' ' . */
            _.Display($" ");

            /*" -0- FLUXCONTROL_PERFORM P999_CANCELA_PROGRAMA */

            P999_CANCELA_PROGRAMA();

        }

        [StopWatch]
        /*" P999-CANCELA-PROGRAMA */
        private void P999_CANCELA_PROGRAMA(bool isPerform = false)
        {
            /*" -899- IF W88-COMMIT */

            if (LK_PARAMETRO.LK_OPERACAO["W88_COMMIT"])
            {

                /*" -899- EXEC SQL COMMIT END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -901- DISPLAY ' ' */
                _.Display($" ");

                /*" -902- MOVE 'FC' TO LKG2-COD-SISTEM */
                _.Move("FC", REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_COD_SISTEM);

                /*" -903- MOVE W77-ROTINA TO LKG2-NOM-ROTINA */
                _.Move(AREA_DE_WORK.W77_ROTINA, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_NOM_ROTINA);

                /*" -904- MOVE 04 TO LKG2-SEQ-ETAPA */
                _.Move(04, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_SEQ_ETAPA);

                /*" -905- MOVE W77-PROGRAMA TO LKG2-NOM-PROGM */
                _.Move(AREA_DE_WORK.W77_PROGRAMA, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_NOM_PROGM);

                /*" -906- MOVE 0 TO LKG2-QTD-REG-LIDOS */
                _.Move(0, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_QTD_REG_LIDOS);

                /*" -907- MOVE 0 TO LKG2-QTD-REG-PROCS */
                _.Move(0, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_QTD_REG_PROCS);

                /*" -908- MOVE 0 TO LKG2-QTD-REG-ALTER */
                _.Move(0, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_QTD_REG_ALTER);

                /*" -909- MOVE 0 TO LKG2-QTD-REG-EXCLU */
                _.Move(0, REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_QTD_REG_EXCLU);

                /*" -910- MOVE '1' TO LKG2-STA-EXECUCAO */
                _.Move("1", REGISTR2_LINKAGE.LKG2_PARM_INPUT.LKG2_STA_EXECUCAO);

                /*" -912- CALL 'FC1112S' USING REGISTR2-LINKAGE */
                _.Call("FC1112S", REGISTR2_LINKAGE);

                /*" -913- IF LKG2-RETN-CODE EQUAL 0 */

                if (REGISTR2_LINKAGE.LKG2_PARM_OUTPUT.LKG2_RETN_CODE == 0)
                {

                    /*" -913- EXEC SQL COMMIT END-EXEC */

                    DatabaseConnection.Instance.CommitTransaction();

                    /*" -915- ELSE */
                }
                else
                {


                    /*" -915- EXEC SQL ROLLBACK END-EXEC */

                    DatabaseConnection.Instance.RollbackTransaction();

                    /*" -917- DISPLAY 'EXECUTOU ROLLBACK - RETORNO FC1112S.' */
                    _.Display($"EXECUTOU ROLLBACK - RETORNO FC1112S.");

                    /*" -919- DISPLAY '<' LKG2-SQL-CODE '> ' '<' LKG2-RETN-CODE '> ' */

                    $"<{REGISTR2_LINKAGE.LKG2_PARM_OUTPUT.LKG2_SQL_CODE}> <{REGISTR2_LINKAGE.LKG2_PARM_OUTPUT.LKG2_RETN_CODE}> "
                    .Display();

                    /*" -920- DISPLAY '<' LKG2-MENS-ERRO '>' */

                    $"<{REGISTR2_LINKAGE.LKG2_PARM_OUTPUT.LKG2_MENS_ERRO}>"
                    .Display();

                    /*" -921- END-IF */
                }


                /*" -923- END-IF */
            }


            /*" -924- DISPLAY ' ' */
            _.Display($" ");

            /*" -931- DISPLAY '*** PROGRAMA FC0105B CANCELADO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ' ***' */

            $"*** PROGRAMA FC0105B CANCELADO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss} ***"
            .Display();

            /*" -931- EXEC SQL ROLLBACK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -933- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -933- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}