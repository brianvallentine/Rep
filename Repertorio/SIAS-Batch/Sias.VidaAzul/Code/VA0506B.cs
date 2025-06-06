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
using Sias.VidaAzul.DB2.VA0506B;

namespace Code
{
    public class VA0506B
    {
        public bool IsCall { get; set; }

        public VA0506B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COMISSAO                           *      */
        /*"      *   PROGRAMA ...............  VA0506B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  28/01/2015                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERA TABELA SEGUROS.COMISSOES PARA *      */
        /*"      *                             LANCAMENTOS APROPRIADOS NA TABELA  *      */
        /*"      *                             FUNDO_COMISSAO_VA PARA REPASSE     *      */
        /*"      *                             A PAR CORRETORA DAS COMISSOES DOS  *      */
        /*"      *                             FUNCIONARIOS CEF, POR MEIO DO      *      */
        /*"      *                             CORRETOR 19224.                    *      */
        /*"      *                             NOVO ACORDO OPERACIONAL 2014/2015. *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   CADMUS 126956.                                 *      */
        /*"      *             -   ADEQUACAO PARA PAGAMENTO DE INDICADORES        *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/12/2015 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NULL01               PIC S9(004)         COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)         COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL03               PIC S9(004)         COMP.*/
        public IntBasis VIND_NULL03 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL04               PIC S9(004)         COMP.*/
        public IntBasis VIND_NULL04 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL05               PIC S9(004)         COMP.*/
        public IntBasis VIND_NULL05 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-PCTCOB               PIC S9(004)         COMP.*/
        public IntBasis VIND_PCTCOB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTMOVTO              PIC S9(004)         COMP.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DATSEL               PIC S9(004)         COMP.*/
        public IntBasis VIND_DATSEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODEMP               PIC S9(004)         COMP.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRP               PIC S9(004)         COMP.*/
        public IntBasis VIND_CODPRP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUMBIL               PIC S9(004)         COMP.*/
        public IntBasis VIND_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VLVARMON             PIC S9(004)         COMP.*/
        public IntBasis VIND_VLVARMON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTQITBCO             PIC S9(004)         COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-PCTCOBER            PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WHOST_PCTCOBER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VAL-BASE           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WSHOST_VAL_BASE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01           AREA-DE-WORK.*/
        public VA0506B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA0506B_AREA_DE_WORK();
        public class VA0506B_AREA_DE_WORK : VarBasis
        {
            /*"  03         WFIM-MOVIMENTO    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         WFIM-COBERAPOL    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_COBERAPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         WTEM-PAGTO        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         LD-FUNCOMVA       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_FUNCOMVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         TT-NRCERTIF       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis TT_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         TT-TERMO          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis TT_TERMO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         TT-APOLICE        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis TT_APOLICE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         UP-VALOR          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis UP_VALOR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         UP-PARCELA        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis UP_PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         UP-V0FUNDO        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis UP_V0FUNDO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         UP-DESEP          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis UP_DESEP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-V0FUNDO        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis DP_V0FUNDO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-PAGTO          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis DP_PAGTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-OPCPAGVI       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis DP_OPCPAGVI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-DESEP          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis DP_DESEP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-COMISSOE       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis DP_COMISSOE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-APOLICOB       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis DP_APOLICOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         IN-COMISSOE       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis IN_COMISSOE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-DUPLICA        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_DUPLICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-HISCONPA       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_HISCONPA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-HISCONPA       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis DP_HISCONPA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-LIDOS           PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_VA0506B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VA0506B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VA0506B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_VA0506B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(003).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VA0506B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VA0506B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_VA0506B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_VA0506B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VA0506B_FILLER_1 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_VA0506B_FILLER_1()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_VA0506B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_VA0506B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_VA0506B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VA0506B_FILLER_4 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public VA0506B_WTIME_DAYR WTIME_DAYR { get; set; } = new VA0506B_WTIME_DAYR();
                public class VA0506B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA         PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU         PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU         PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3         PIC  X(001).*/

                    public VA0506B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSE         PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03         WS-TIME.*/

                public _REDEF_VA0506B_FILLER_4()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public VA0506B_WS_TIME WS_TIME { get; set; } = new VA0506B_WS_TIME();
            public class VA0506B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WABEND.*/
            }
            public VA0506B_WABEND WABEND { get; set; } = new VA0506B_WABEND();
            public class VA0506B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' VA0506B'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0506B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LD99-ABEND.*/
            }
        }
        public VA0506B_LD99_ABEND LD99_ABEND { get; set; } = new VA0506B_LD99_ABEND();
        public class VA0506B_LD99_ABEND : VarBasis
        {
            /*"      10    FILLER              PIC  X(050) VALUE           ' REINICIAR JOB NO PROXIMO STEP               '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" REINICIAR JOB NO PROXIMO STEP               ");
            /*"      10    FILLER              PIC  X(050) VALUE           ' QUANDO SQLCODE IGUAL (-911) RESTART MESMO STEP '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" QUANDO SQLCODE IGUAL (-911) RESTART MESMO STEP ");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.FUNCOMVA FUNCOMVA { get; set; } = new Dclgens.FUNCOMVA();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.PARAMPRO PARAMPRO { get; set; } = new Dclgens.PARAMPRO();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.COMISSOE COMISSOE { get; set; } = new Dclgens.COMISSOE();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public VA0506B_V0FUNDO V0FUNDO { get; set; } = new VA0506B_V0FUNDO();
        public VA0506B_V0COBERAPOL V0COBERAPOL { get; set; } = new VA0506B_V0COBERAPOL();
        public VA0506B_V0HISCONPA V0HISCONPA { get; set; } = new VA0506B_V0HISCONPA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -177- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -180- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -183- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -187- DISPLAY '----------------------------------' */
            _.Display($"----------------------------------");

            /*" -188- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -189- DISPLAY 'PROGRAMA EM EXECUCAO VA0506B      ' */
            _.Display($"PROGRAMA EM EXECUCAO VA0506B      ");

            /*" -190- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -191- DISPLAY 'VERSAO V.01 - 15/12/2015          ' */
            _.Display($"VERSAO V.01 - 15/12/2015          ");

            /*" -192- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -193- DISPLAY '----------------------------------' . */
            _.Display($"----------------------------------");

            /*" -196- DISPLAY ' ' . */
            _.Display($" ");

            /*" -199- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -202- PERFORM R0290-00-TRATA-FUNCOMVA. */

            R0290_00_TRATA_FUNCOMVA_SECTION();

            /*" -202- PERFORM R3390-00-TRATA-FATURAS. */

            R3390_00_TRATA_FATURAS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -208- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -214- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -215- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -216- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -217- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -218- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -219- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -220- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -221- DISPLAY ' ' . */
            _.Display($" ");

            /*" -222- DISPLAY 'VA0506B - FIM NORMAL' WTIME-DAYR. */
            _.Display($"VA0506B - FIM NORMAL{AREA_DE_WORK.FILLER_4.WTIME_DAYR}");

            /*" -225- DISPLAY ' ' . */
            _.Display($" ");

            /*" -225- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -234- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -235- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -236- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -237- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -238- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -239- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -240- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -243- DISPLAY 'INICIO VA0506B    ' WTIME-DAYR. */
            _.Display($"INICIO VA0506B    {AREA_DE_WORK.FILLER_4.WTIME_DAYR}");

            /*" -246- PERFORM R0100-00-SELECT-SISTEMA. */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -247- DISPLAY '                    ' . */
            _.Display($"                    ");

            /*" -248- DISPLAY 'DATA SISTEMA  ..... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA SISTEMA  ..... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -251- DISPLAY '                    ' . */
            _.Display($"                    ");

            /*" -251- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -263- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -269- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -273- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -274- DISPLAY 'VA0506B - SISTEMA NAO ESTA CADASTRADO' */
                _.Display($"VA0506B - SISTEMA NAO ESTA CADASTRADO");

                /*" -274- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -269- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CO' WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0290-00-TRATA-FUNCOMVA-SECTION */
        private void R0290_00_TRATA_FUNCOMVA_SECTION()
        {
            /*" -287- MOVE '0290' TO WNR-EXEC-SQL. */
            _.Move("0290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -288- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -289- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -290- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -291- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -292- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -293- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -296- DISPLAY 'DECLARE FUNCOMVA  ' WTIME-DAYR. */
            _.Display($"DECLARE FUNCOMVA  {AREA_DE_WORK.FILLER_4.WTIME_DAYR}");

            /*" -297- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -298- PERFORM R0300-00-DECLARE-V0FUNDO. */

            R0300_00_DECLARE_V0FUNDO_SECTION();

            /*" -301- PERFORM R0310-00-FETCH-V0FUNDO. */

            R0310_00_FETCH_V0FUNDO_SECTION();

            /*" -305- PERFORM R0350-00-PROCESSA-V0FUNDO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_V0FUNDO_SECTION();
            }

            /*" -305- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -308- DISPLAY ' ' . */
            _.Display($" ");

            /*" -309- DISPLAY 'LIDOS FUNCOMVA ............. ' LD-FUNCOMVA */
            _.Display($"LIDOS FUNCOMVA ............. {AREA_DE_WORK.LD_FUNCOMVA}");

            /*" -310- DISPLAY 'DESPREZA DESEP ............. ' DP-DESEP */
            _.Display($"DESPREZA DESEP ............. {AREA_DE_WORK.DP_DESEP}");

            /*" -311- DISPLAY 'ALTERA REGISTRO SEM VALOR .. ' UP-VALOR */
            _.Display($"ALTERA REGISTRO SEM VALOR .. {AREA_DE_WORK.UP_VALOR}");

            /*" -312- DISPLAY 'ALTERA PARCELA MAIOR 01 .... ' UP-PARCELA */
            _.Display($"ALTERA PARCELA MAIOR 01 .... {AREA_DE_WORK.UP_PARCELA}");

            /*" -313- DISPLAY 'DESPREZA REGISTRO .......... ' DP-V0FUNDO */
            _.Display($"DESPREZA REGISTRO .......... {AREA_DE_WORK.DP_V0FUNDO}");

            /*" -314- DISPLAY 'TRATA CERTIFICADO .......... ' TT-NRCERTIF */
            _.Display($"TRATA CERTIFICADO .......... {AREA_DE_WORK.TT_NRCERTIF}");

            /*" -315- DISPLAY 'TRATA TERMO ADESAO ......... ' TT-TERMO */
            _.Display($"TRATA TERMO ADESAO ......... {AREA_DE_WORK.TT_TERMO}");

            /*" -316- DISPLAY 'TRATA APOLICE .............. ' TT-APOLICE */
            _.Display($"TRATA APOLICE .............. {AREA_DE_WORK.TT_APOLICE}");

            /*" -317- DISPLAY 'DESPREZA PAGAMENTO ......... ' DP-PAGTO */
            _.Display($"DESPREZA PAGAMENTO ......... {AREA_DE_WORK.DP_PAGTO}");

            /*" -318- DISPLAY 'DESPREZA OPCPAGVI .......... ' DP-OPCPAGVI */
            _.Display($"DESPREZA OPCPAGVI .......... {AREA_DE_WORK.DP_OPCPAGVI}");

            /*" -319- DISPLAY 'REGISTRO SEM PARAMETRO ..... ' UP-V0FUNDO */
            _.Display($"REGISTRO SEM PARAMETRO ..... {AREA_DE_WORK.UP_V0FUNDO}");

            /*" -320- DISPLAY 'ALTERA DESEP ............... ' UP-DESEP */
            _.Display($"ALTERA DESEP ............... {AREA_DE_WORK.UP_DESEP}");

            /*" -321- DISPLAY 'DESPREZA APOLICOB .......... ' DP-APOLICOB */
            _.Display($"DESPREZA APOLICOB .......... {AREA_DE_WORK.DP_APOLICOB}");

            /*" -322- DISPLAY ' ' . */
            _.Display($" ");

            /*" -323- DISPLAY 'INSERE COMISSOES ........... ' IN-COMISSOE */
            _.Display($"INSERE COMISSOES ........... {AREA_DE_WORK.IN_COMISSOE}");

            /*" -324- DISPLAY 'DESPREZA COMISSOES ......... ' DP-COMISSOE */
            _.Display($"DESPREZA COMISSOES ......... {AREA_DE_WORK.DP_COMISSOE}");

            /*" -325- DISPLAY 'DUPLICA  COMISSOES ......... ' AC-DUPLICA */
            _.Display($"DUPLICA  COMISSOES ......... {AREA_DE_WORK.AC_DUPLICA}");

            /*" -325- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-V0FUNDO-SECTION */
        private void R0300_00_DECLARE_V0FUNDO_SECTION()
        {
            /*" -338- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -367- PERFORM R0300_00_DECLARE_V0FUNDO_DB_DECLARE_1 */

            R0300_00_DECLARE_V0FUNDO_DB_DECLARE_1();

            /*" -369- PERFORM R0300_00_DECLARE_V0FUNDO_DB_OPEN_1 */

            R0300_00_DECLARE_V0FUNDO_DB_OPEN_1();

            /*" -373- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -374- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (FUNCOMVA)  ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (FUNCOMVA)  ");

                /*" -377- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -378- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -379- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -380- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -381- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -382- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -383- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -383- DISPLAY 'FETCH   FUNCOMVA  ' WTIME-DAYR. */
            _.Display($"FETCH   FUNCOMVA  {AREA_DE_WORK.FILLER_4.WTIME_DAYR}");

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0FUNDO-DB-DECLARE-1 */
        public void R0300_00_DECLARE_V0FUNDO_DB_DECLARE_1()
        {
            /*" -367- EXEC SQL DECLARE V0FUNDO CURSOR WITH HOLD FOR SELECT CODIGO_PRODUTO , NUM_CERTIFICADO , NUM_TERMO , SITUACAO , COD_OPERACAO , COD_FONTE , COD_AGENCIA , COD_CLIENTE , NUM_MATRI_VENDEDOR , VAL_BASICO_VG , VAL_BASICO_AP , VAL_COMISSAO_VG , VAL_COMISSAO_AP , DATA_QUITACAO , PCCOMIND , PCCOMGER , PCCOMSUP , DATA_MOVIMENTO , NUM_APOLICE , COD_SUBGRUPO , NUM_ENDOSSO , NUM_TITULO , NUM_PARCELA FROM SEGUROS.FUNDO_COMISSAO_VA WHERE SITUACAO = '0' FOR UPDATE OF SITUACAO , NUM_MATRI_VENDEDOR END-EXEC. */
            V0FUNDO = new VA0506B_V0FUNDO(false);
            string GetQuery_V0FUNDO()
            {
                var query = @$"SELECT CODIGO_PRODUTO 
							, NUM_CERTIFICADO 
							, NUM_TERMO 
							, SITUACAO 
							, COD_OPERACAO 
							, COD_FONTE 
							, COD_AGENCIA 
							, COD_CLIENTE 
							, NUM_MATRI_VENDEDOR 
							, VAL_BASICO_VG 
							, VAL_BASICO_AP 
							, VAL_COMISSAO_VG 
							, VAL_COMISSAO_AP 
							, DATA_QUITACAO 
							, PCCOMIND 
							, PCCOMGER 
							, PCCOMSUP 
							, DATA_MOVIMENTO 
							, NUM_APOLICE 
							, COD_SUBGRUPO 
							, NUM_ENDOSSO 
							, NUM_TITULO 
							, NUM_PARCELA 
							FROM SEGUROS.FUNDO_COMISSAO_VA 
							WHERE SITUACAO = '0'";

                return query;
            }
            V0FUNDO.GetQueryEvent += GetQuery_V0FUNDO;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0FUNDO-DB-OPEN-1 */
        public void R0300_00_DECLARE_V0FUNDO_DB_OPEN_1()
        {
            /*" -369- EXEC SQL OPEN V0FUNDO END-EXEC. */

            V0FUNDO.Open();

        }

        [StopWatch]
        /*" R2600-00-DECLARE-COBERAPOL-DB-DECLARE-1 */
        public void R2600_00_DECLARE_COBERAPOL_DB_DECLARE_1()
        {
            /*" -954- EXEC SQL DECLARE V0COBERAPOL CURSOR WITH HOLD FOR SELECT RAMO_COBERTURA , PCT_COBERTURA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO AND NUM_ITEM = 0 AND COD_COBERTURA = 0 AND PCT_COBERTURA > 0 AND DATA_INIVIGENCIA <= :ENDOSSOS-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :ENDOSSOS-DATA-INIVIGENCIA WITH UR END-EXEC. */
            V0COBERAPOL = new VA0506B_V0COBERAPOL(true);
            string GetQuery_V0COBERAPOL()
            {
                var query = @$"SELECT RAMO_COBERTURA 
							, PCT_COBERTURA 
							FROM SEGUROS.APOLICE_COBERTURAS 
							WHERE NUM_APOLICE = '{HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE}' 
							AND NUM_ENDOSSO = '{HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}' 
							AND NUM_ITEM = 0 
							AND COD_COBERTURA = 0 
							AND PCT_COBERTURA > 0 
							AND DATA_INIVIGENCIA <= '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}' 
							AND DATA_TERVIGENCIA >= '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}'";

                return query;
            }
            V0COBERAPOL.GetQueryEvent += GetQuery_V0COBERAPOL;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-V0FUNDO-SECTION */
        private void R0310_00_FETCH_V0FUNDO_SECTION()
        {
            /*" -396- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -420- PERFORM R0310_00_FETCH_V0FUNDO_DB_FETCH_1 */

            R0310_00_FETCH_V0FUNDO_DB_FETCH_1();

            /*" -424- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -424- PERFORM R0310_00_FETCH_V0FUNDO_DB_CLOSE_1 */

                R0310_00_FETCH_V0FUNDO_DB_CLOSE_1();

                /*" -426- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                /*" -428- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -429- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -430- DISPLAY 'R0310-00 - PROBLEMAS FETCH (FUNCOMVA)    ' */
                _.Display($"R0310-00 - PROBLEMAS FETCH (FUNCOMVA)    ");

                /*" -433- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -436- ADD 1 TO LD-FUNCOMVA. */
            AREA_DE_WORK.LD_FUNCOMVA.Value = AREA_DE_WORK.LD_FUNCOMVA + 1;

            /*" -438- MOVE LD-FUNCOMVA TO AC-LIDOS. */
            _.Move(AREA_DE_WORK.LD_FUNCOMVA, AREA_DE_WORK.AC_LIDOS);

            /*" -440- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (AREA_DE_WORK.FILLER_0.LD_PARTE2 == 00 || AREA_DE_WORK.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -441- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

                /*" -442- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -443- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -444- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -445- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -446- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -450- DISPLAY 'LIDOS FUNCOMVA     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS FUNCOMVA     {AREA_DE_WORK.AC_LIDOS}    {AREA_DE_WORK.FILLER_4.WTIME_DAYR}"
                .Display();
            }


            /*" -451- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -454- MOVE ZEROS TO FUNCOMVA-NUM-APOLICE. */
                _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_APOLICE);
            }


            /*" -455- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -458- MOVE ZEROS TO FUNCOMVA-COD-SUBGRUPO. */
                _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_SUBGRUPO);
            }


            /*" -459- IF VIND-NULL03 LESS ZEROS */

            if (VIND_NULL03 < 00)
            {

                /*" -462- MOVE ZEROS TO FUNCOMVA-NUM-ENDOSSO. */
                _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_ENDOSSO);
            }


            /*" -463- IF VIND-NULL04 LESS ZEROS */

            if (VIND_NULL04 < 00)
            {

                /*" -466- MOVE ZEROS TO FUNCOMVA-NUM-TITULO. */
                _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TITULO);
            }


            /*" -467- IF VIND-NULL05 LESS ZEROS */

            if (VIND_NULL05 < 00)
            {

                /*" -468- MOVE ZEROS TO FUNCOMVA-NUM-PARCELA. */
                _.Move(0, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_PARCELA);
            }


        }

        [StopWatch]
        /*" R0310-00-FETCH-V0FUNDO-DB-FETCH-1 */
        public void R0310_00_FETCH_V0FUNDO_DB_FETCH_1()
        {
            /*" -420- EXEC SQL FETCH V0FUNDO INTO :FUNCOMVA-CODIGO-PRODUTO ,:FUNCOMVA-NUM-CERTIFICADO ,:FUNCOMVA-NUM-TERMO ,:FUNCOMVA-SITUACAO ,:FUNCOMVA-COD-OPERACAO ,:FUNCOMVA-COD-FONTE ,:FUNCOMVA-COD-AGENCIA ,:FUNCOMVA-COD-CLIENTE ,:FUNCOMVA-NUM-MATRI-VENDEDOR ,:FUNCOMVA-VAL-BASICO-VG ,:FUNCOMVA-VAL-BASICO-AP ,:FUNCOMVA-VAL-COMISSAO-VG ,:FUNCOMVA-VAL-COMISSAO-AP ,:FUNCOMVA-DATA-QUITACAO ,:FUNCOMVA-PCCOMIND ,:FUNCOMVA-PCCOMGER ,:FUNCOMVA-PCCOMSUP ,:FUNCOMVA-DATA-MOVIMENTO ,:FUNCOMVA-NUM-APOLICE:VIND-NULL01 ,:FUNCOMVA-COD-SUBGRUPO:VIND-NULL02 ,:FUNCOMVA-NUM-ENDOSSO:VIND-NULL03 ,:FUNCOMVA-NUM-TITULO:VIND-NULL04 ,:FUNCOMVA-NUM-PARCELA:VIND-NULL05 END-EXEC. */

            if (V0FUNDO.Fetch())
            {
                _.Move(V0FUNDO.FUNCOMVA_CODIGO_PRODUTO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_CODIGO_PRODUTO);
                _.Move(V0FUNDO.FUNCOMVA_NUM_CERTIFICADO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_CERTIFICADO);
                _.Move(V0FUNDO.FUNCOMVA_NUM_TERMO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TERMO);
                _.Move(V0FUNDO.FUNCOMVA_SITUACAO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO);
                _.Move(V0FUNDO.FUNCOMVA_COD_OPERACAO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_OPERACAO);
                _.Move(V0FUNDO.FUNCOMVA_COD_FONTE, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_FONTE);
                _.Move(V0FUNDO.FUNCOMVA_COD_AGENCIA, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_AGENCIA);
                _.Move(V0FUNDO.FUNCOMVA_COD_CLIENTE, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_CLIENTE);
                _.Move(V0FUNDO.FUNCOMVA_NUM_MATRI_VENDEDOR, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_MATRI_VENDEDOR);
                _.Move(V0FUNDO.FUNCOMVA_VAL_BASICO_VG, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_VG);
                _.Move(V0FUNDO.FUNCOMVA_VAL_BASICO_AP, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_AP);
                _.Move(V0FUNDO.FUNCOMVA_VAL_COMISSAO_VG, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_COMISSAO_VG);
                _.Move(V0FUNDO.FUNCOMVA_VAL_COMISSAO_AP, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_COMISSAO_AP);
                _.Move(V0FUNDO.FUNCOMVA_DATA_QUITACAO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_QUITACAO);
                _.Move(V0FUNDO.FUNCOMVA_PCCOMIND, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_PCCOMIND);
                _.Move(V0FUNDO.FUNCOMVA_PCCOMGER, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_PCCOMGER);
                _.Move(V0FUNDO.FUNCOMVA_PCCOMSUP, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_PCCOMSUP);
                _.Move(V0FUNDO.FUNCOMVA_DATA_MOVIMENTO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_MOVIMENTO);
                _.Move(V0FUNDO.FUNCOMVA_NUM_APOLICE, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_APOLICE);
                _.Move(V0FUNDO.VIND_NULL01, VIND_NULL01);
                _.Move(V0FUNDO.FUNCOMVA_COD_SUBGRUPO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_SUBGRUPO);
                _.Move(V0FUNDO.VIND_NULL02, VIND_NULL02);
                _.Move(V0FUNDO.FUNCOMVA_NUM_ENDOSSO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_ENDOSSO);
                _.Move(V0FUNDO.VIND_NULL03, VIND_NULL03);
                _.Move(V0FUNDO.FUNCOMVA_NUM_TITULO, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TITULO);
                _.Move(V0FUNDO.VIND_NULL04, VIND_NULL04);
                _.Move(V0FUNDO.FUNCOMVA_NUM_PARCELA, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_PARCELA);
                _.Move(V0FUNDO.VIND_NULL05, VIND_NULL05);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-V0FUNDO-DB-CLOSE-1 */
        public void R0310_00_FETCH_V0FUNDO_DB_CLOSE_1()
        {
            /*" -424- EXEC SQL CLOSE V0FUNDO END-EXEC */

            V0FUNDO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-V0FUNDO-SECTION */
        private void R0350_00_PROCESSA_V0FUNDO_SECTION()
        {
            /*" -481- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -482- IF FUNCOMVA-NUM-MATRI-VENDEDOR EQUAL 1111111 */

            if (FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_MATRI_VENDEDOR == 1111111)
            {

                /*" -483- ADD 1 TO DP-DESEP */
                AREA_DE_WORK.DP_DESEP.Value = AREA_DE_WORK.DP_DESEP + 1;

                /*" -486- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -488- IF FUNCOMVA-VAL-BASICO-VG EQUAL ZEROS AND FUNCOMVA-VAL-BASICO-AP EQUAL ZEROS */

            if (FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_VG == 00 && FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_AP == 00)
            {

                /*" -489- ADD 1 TO UP-VALOR */
                AREA_DE_WORK.UP_VALOR.Value = AREA_DE_WORK.UP_VALOR + 1;

                /*" -491- MOVE '2' TO FUNCOMVA-SITUACAO */
                _.Move("2", FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO);

                /*" -492- PERFORM R1500-00-UPDATE-V0FUNDO */

                R1500_00_UPDATE_V0FUNDO_SECTION();

                /*" -495- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -496- IF FUNCOMVA-NUM-PARCELA GREATER 1 */

            if (FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_PARCELA > 1)
            {

                /*" -497- ADD 1 TO UP-PARCELA */
                AREA_DE_WORK.UP_PARCELA.Value = AREA_DE_WORK.UP_PARCELA + 1;

                /*" -499- MOVE '2' TO FUNCOMVA-SITUACAO */
                _.Move("2", FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO);

                /*" -500- PERFORM R1500-00-UPDATE-V0FUNDO */

                R1500_00_UPDATE_V0FUNDO_SECTION();

                /*" -503- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -506- MOVE SPACES TO WTEM-PAGTO. */
            _.Move("", AREA_DE_WORK.WTEM_PAGTO);

            /*" -507- IF FUNCOMVA-NUM-CERTIFICADO NOT EQUAL ZEROS */

            if (FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_CERTIFICADO != 00)
            {

                /*" -508- ADD 1 TO TT-NRCERTIF */
                AREA_DE_WORK.TT_NRCERTIF.Value = AREA_DE_WORK.TT_NRCERTIF + 1;

                /*" -510- MOVE FUNCOMVA-NUM-CERTIFICADO TO HISCONPA-NUM-CERTIFICADO */
                _.Move(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

                /*" -511- PERFORM R0410-00-SELECT-HISCONPA */

                R0410_00_SELECT_HISCONPA_SECTION();

                /*" -512- ELSE */
            }
            else
            {


                /*" -513- IF FUNCOMVA-NUM-TERMO NOT EQUAL ZEROS */

                if (FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TERMO != 00)
                {

                    /*" -514- ADD 1 TO TT-TERMO */
                    AREA_DE_WORK.TT_TERMO.Value = AREA_DE_WORK.TT_TERMO + 1;

                    /*" -516- MOVE FUNCOMVA-NUM-TERMO TO HISCONPA-NUM-CERTIFICADO */
                    _.Move(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TERMO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

                    /*" -517- PERFORM R0410-00-SELECT-HISCONPA */

                    R0410_00_SELECT_HISCONPA_SECTION();

                    /*" -518- ELSE */
                }
                else
                {


                    /*" -520- IF FUNCOMVA-NUM-APOLICE NOT EQUAL ZEROS AND FUNCOMVA-NUM-ENDOSSO NOT EQUAL ZEROS */

                    if (FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_APOLICE != 00 && FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_ENDOSSO != 00)
                    {

                        /*" -521- ADD 1 TO TT-APOLICE */
                        AREA_DE_WORK.TT_APOLICE.Value = AREA_DE_WORK.TT_APOLICE + 1;

                        /*" -522- PERFORM R0420-00-SELECT-HISCONPA */

                        R0420_00_SELECT_HISCONPA_SECTION();

                        /*" -523- ELSE */
                    }
                    else
                    {


                        /*" -524- ADD 1 TO DP-V0FUNDO */
                        AREA_DE_WORK.DP_V0FUNDO.Value = AREA_DE_WORK.DP_V0FUNDO + 1;

                        /*" -526- MOVE '3' TO FUNCOMVA-SITUACAO */
                        _.Move("3", FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO);

                        /*" -527- PERFORM R1500-00-UPDATE-V0FUNDO */

                        R1500_00_UPDATE_V0FUNDO_SECTION();

                        /*" -530- GO TO R0350-90-LEITURA. */

                        R0350_90_LEITURA(); //GOTO
                        return;
                    }

                }

            }


            /*" -531- IF WTEM-PAGTO NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_PAGTO != "S")
            {

                /*" -532- ADD 1 TO DP-PAGTO */
                AREA_DE_WORK.DP_PAGTO.Value = AREA_DE_WORK.DP_PAGTO + 1;

                /*" -535- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -537- PERFORM R0430-00-SELECT-OPCPAGVI. */

            R0430_00_SELECT_OPCPAGVI_SECTION();

            /*" -538- IF WTEM-PAGTO NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_PAGTO != "S")
            {

                /*" -539- ADD 1 TO DP-OPCPAGVI */
                AREA_DE_WORK.DP_OPCPAGVI.Value = AREA_DE_WORK.DP_OPCPAGVI + 1;

                /*" -541- MOVE '4' TO FUNCOMVA-SITUACAO */
                _.Move("4", FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO);

                /*" -542- PERFORM R1500-00-UPDATE-V0FUNDO */

                R1500_00_UPDATE_V0FUNDO_SECTION();

                /*" -548- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -550- MOVE '1' TO PARAMPRO-TIPO-FUNCIONARIO. */
            _.Move("1", PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_TIPO_FUNCIONARIO);

            /*" -552- MOVE FUNCOMVA-CODIGO-PRODUTO TO PARAMPRO-COD-PRODUTO. */
            _.Move(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_CODIGO_PRODUTO, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_COD_PRODUTO);

            /*" -554- MOVE OPCPAGVI-DATA-INIVIGENCIA TO PARAMPRO-DATA-INIVIGENCIA. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_DATA_INIVIGENCIA);

            /*" -556- MOVE 'N' TO PARAMPRO-STA-RENOVACAO. */
            _.Move("N", PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_STA_RENOVACAO);

            /*" -559- MOVE ZEROS TO PARAMPRO-MARGEM. */
            _.Move(0, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_MARGEM);

            /*" -561- PERFORM R0450-00-SELECT-PARAM-PRODUTO. */

            R0450_00_SELECT_PARAM_PRODUTO_SECTION();

            /*" -563- IF PARAMPRO-VALOR-COMISSAO-PRD EQUAL ZEROS AND PARAMPRO-PERCEN-COMIS-FUNC EQUAL ZEROS */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD == 00 && PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC == 00)
            {

                /*" -564- ADD 1 TO UP-V0FUNDO */
                AREA_DE_WORK.UP_V0FUNDO.Value = AREA_DE_WORK.UP_V0FUNDO + 1;

                /*" -566- MOVE '2' TO FUNCOMVA-SITUACAO */
                _.Move("2", FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO);

                /*" -567- PERFORM R1500-00-UPDATE-V0FUNDO */

                R1500_00_UPDATE_V0FUNDO_SECTION();

                /*" -570- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -573- MOVE SPACES TO WTEM-PAGTO. */
            _.Move("", AREA_DE_WORK.WTEM_PAGTO);

            /*" -574- IF PARAMPRO-VALOR-COMISSAO-PRD NOT EQUAL ZEROS */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD != 00)
            {

                /*" -575- PERFORM R2000-00-VALOR-FIXO */

                R2000_00_VALOR_FIXO_SECTION();

                /*" -578- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -580- PERFORM R0500-00-SELECT-V0COBERAPOL. */

            R0500_00_SELECT_V0COBERAPOL_SECTION();

            /*" -581- IF WHOST-PCTCOBER NOT EQUAL 100 */

            if (WHOST_PCTCOBER != 100)
            {

                /*" -582- ADD 1 TO DP-APOLICOB */
                AREA_DE_WORK.DP_APOLICOB.Value = AREA_DE_WORK.DP_APOLICOB + 1;

                /*" -585- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -585- PERFORM R2500-00-CALCULA-COBERTURAS. */

            R2500_00_CALCULA_COBERTURAS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -590- PERFORM R0310-00-FETCH-V0FUNDO. */

            R0310_00_FETCH_V0FUNDO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-SELECT-HISCONPA-SECTION */
        private void R0410_00_SELECT_HISCONPA_SECTION()
        {
            /*" -602- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -635- PERFORM R0410_00_SELECT_HISCONPA_DB_SELECT_1 */

            R0410_00_SELECT_HISCONPA_DB_SELECT_1();

            /*" -639- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -640- MOVE 'N' TO WTEM-PAGTO */
                _.Move("N", AREA_DE_WORK.WTEM_PAGTO);

                /*" -641- ELSE */
            }
            else
            {


                /*" -642- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -643- DISPLAY 'R0410-00 - PROBLEMAS NO SELECT(HISCONPA)' */
                    _.Display($"R0410-00 - PROBLEMAS NO SELECT(HISCONPA)");

                    /*" -644- DISPLAY ' CERTIFICADO ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($" CERTIFICADO {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -645- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -646- ELSE */
                }
                else
                {


                    /*" -646- MOVE 'S' TO WTEM-PAGTO. */
                    _.Move("S", AREA_DE_WORK.WTEM_PAGTO);
                }

            }


        }

        [StopWatch]
        /*" R0410-00-SELECT-HISCONPA-DB-SELECT-1 */
        public void R0410_00_SELECT_HISCONPA_DB_SELECT_1()
        {
            /*" -635- EXEC SQL SELECT A.NUM_CERTIFICADO , A.NUM_PARCELA , A.NUM_TITULO , A.OCORR_HISTORICO , A.NUM_APOLICE , A.COD_SUBGRUPO , A.NUM_ENDOSSO , B.RAMO_EMISSOR , B.DATA_INIVIGENCIA , C.COD_MODALIDADE INTO :HISCONPA-NUM-CERTIFICADO ,:HISCONPA-NUM-PARCELA ,:HISCONPA-NUM-TITULO ,:HISCONPA-OCORR-HISTORICO ,:HISCONPA-NUM-APOLICE ,:HISCONPA-COD-SUBGRUPO ,:HISCONPA-NUM-ENDOSSO ,:ENDOSSOS-RAMO-EMISSOR ,:ENDOSSOS-DATA-INIVIGENCIA ,:APOLICES-COD-MODALIDADE FROM SEGUROS.HIST_CONT_PARCELVA A , SEGUROS.ENDOSSOS B , SEGUROS.APOLICES C WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND A.NUM_PARCELA IN (0,1) AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_ENDOSSO > 0 AND B.TIPO_ENDOSSO IN ( '0' , '1' ) AND C.NUM_APOLICE = B.NUM_APOLICE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0410_00_SELECT_HISCONPA_DB_SELECT_1_Query1 = new R0410_00_SELECT_HISCONPA_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0410_00_SELECT_HISCONPA_DB_SELECT_1_Query1.Execute(r0410_00_SELECT_HISCONPA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCONPA_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);
                _.Move(executed_1.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(executed_1.HISCONPA_NUM_TITULO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO);
                _.Move(executed_1.HISCONPA_OCORR_HISTORICO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);
                _.Move(executed_1.HISCONPA_NUM_APOLICE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE);
                _.Move(executed_1.HISCONPA_COD_SUBGRUPO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO);
                _.Move(executed_1.HISCONPA_NUM_ENDOSSO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.APOLICES_COD_MODALIDADE, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-SELECT-HISCONPA-SECTION */
        private void R0420_00_SELECT_HISCONPA_SECTION()
        {
            /*" -659- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -693- PERFORM R0420_00_SELECT_HISCONPA_DB_SELECT_1 */

            R0420_00_SELECT_HISCONPA_DB_SELECT_1();

            /*" -697- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -698- MOVE 'N' TO WTEM-PAGTO */
                _.Move("N", AREA_DE_WORK.WTEM_PAGTO);

                /*" -699- ELSE */
            }
            else
            {


                /*" -700- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -701- DISPLAY 'R0420-00 - PROBLEMAS NO SELECT(HISCONPA)' */
                    _.Display($"R0420-00 - PROBLEMAS NO SELECT(HISCONPA)");

                    /*" -702- DISPLAY ' APOLICE     ' FUNCOMVA-NUM-APOLICE */
                    _.Display($" APOLICE     {FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_APOLICE}");

                    /*" -703- DISPLAY ' ENDOSSO     ' FUNCOMVA-NUM-ENDOSSO */
                    _.Display($" ENDOSSO     {FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_ENDOSSO}");

                    /*" -704- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -705- ELSE */
                }
                else
                {


                    /*" -705- MOVE 'S' TO WTEM-PAGTO. */
                    _.Move("S", AREA_DE_WORK.WTEM_PAGTO);
                }

            }


        }

        [StopWatch]
        /*" R0420-00-SELECT-HISCONPA-DB-SELECT-1 */
        public void R0420_00_SELECT_HISCONPA_DB_SELECT_1()
        {
            /*" -693- EXEC SQL SELECT A.NUM_CERTIFICADO , A.NUM_PARCELA , A.NUM_TITULO , A.OCORR_HISTORICO , A.NUM_APOLICE , A.COD_SUBGRUPO , A.NUM_ENDOSSO , B.RAMO_EMISSOR , B.DATA_INIVIGENCIA , C.COD_MODALIDADE INTO :HISCONPA-NUM-CERTIFICADO ,:HISCONPA-NUM-PARCELA ,:HISCONPA-NUM-TITULO ,:HISCONPA-OCORR-HISTORICO ,:HISCONPA-NUM-APOLICE ,:HISCONPA-COD-SUBGRUPO ,:HISCONPA-NUM-ENDOSSO ,:ENDOSSOS-RAMO-EMISSOR ,:ENDOSSOS-DATA-INIVIGENCIA ,:APOLICES-COD-MODALIDADE FROM SEGUROS.HIST_CONT_PARCELVA A , SEGUROS.ENDOSSOS B , SEGUROS.APOLICES C WHERE A.NUM_APOLICE = :FUNCOMVA-NUM-APOLICE AND A.NUM_ENDOSSO = :FUNCOMVA-NUM-ENDOSSO AND A.NUM_TITULO = :FUNCOMVA-NUM-TITULO AND A.NUM_PARCELA IN (0,1) AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.TIPO_ENDOSSO IN ( '0' , '1' ) AND C.NUM_APOLICE = B.NUM_APOLICE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1 = new R0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1()
            {
                FUNCOMVA_NUM_APOLICE = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_APOLICE.ToString(),
                FUNCOMVA_NUM_ENDOSSO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_ENDOSSO.ToString(),
                FUNCOMVA_NUM_TITULO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_TITULO.ToString(),
            };

            var executed_1 = R0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1.Execute(r0420_00_SELECT_HISCONPA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCONPA_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);
                _.Move(executed_1.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(executed_1.HISCONPA_NUM_TITULO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO);
                _.Move(executed_1.HISCONPA_OCORR_HISTORICO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);
                _.Move(executed_1.HISCONPA_NUM_APOLICE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE);
                _.Move(executed_1.HISCONPA_COD_SUBGRUPO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO);
                _.Move(executed_1.HISCONPA_NUM_ENDOSSO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.APOLICES_COD_MODALIDADE, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0430-00-SELECT-OPCPAGVI-SECTION */
        private void R0430_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -718- MOVE '0430' TO WNR-EXEC-SQL. */
            _.Move("0430", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -733- PERFORM R0430_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R0430_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -737- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -738- MOVE 'N' TO WTEM-PAGTO */
                _.Move("N", AREA_DE_WORK.WTEM_PAGTO);

                /*" -740- MOVE '2014-12-31' TO OPCPAGVI-DATA-INIVIGENCIA */
                _.Move("2014-12-31", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA);

                /*" -741- ELSE */
            }
            else
            {


                /*" -742- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -743- DISPLAY 'R0430-00 - PROBLEMAS NO SELECT(OPCPAGVI)' */
                    _.Display($"R0430-00 - PROBLEMAS NO SELECT(OPCPAGVI)");

                    /*" -744- DISPLAY ' CERTIFICADO ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($" CERTIFICADO {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -745- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -746- ELSE */
                }
                else
                {


                    /*" -747- IF OPCPAGVI-DATA-INIVIGENCIA LESS '2015-01-01' */

                    if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA < "2015-01-01")
                    {

                        /*" -748- MOVE 'N' TO WTEM-PAGTO */
                        _.Move("N", AREA_DE_WORK.WTEM_PAGTO);

                        /*" -749- ELSE */
                    }
                    else
                    {


                        /*" -749- MOVE 'S' TO WTEM-PAGTO. */
                        _.Move("S", AREA_DE_WORK.WTEM_PAGTO);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0430-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R0430_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -733- EXEC SQL SELECT DATA_INIVIGENCIA , DATA_TERVIGENCIA , OPCAO_PAGAMENTO , PERI_PAGAMENTO INTO :OPCPAGVI-DATA-INIVIGENCIA ,:OPCPAGVI-DATA-TERVIGENCIA ,:OPCPAGVI-OPCAO-PAGAMENTO ,:OPCPAGVI-PERI-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND DATA_INIVIGENCIA <= :FUNCOMVA-DATA-QUITACAO AND DATA_TERVIGENCIA >= :FUNCOMVA-DATA-QUITACAO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0430_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R0430_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                FUNCOMVA_DATA_QUITACAO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_QUITACAO.ToString(),
            };

            var executed_1 = R0430_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r0430_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_DATA_INIVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA);
                _.Move(executed_1.OPCPAGVI_DATA_TERVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA);
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-SELECT-PARAM-PRODUTO-SECTION */
        private void R0450_00_SELECT_PARAM_PRODUTO_SECTION()
        {
            /*" -762- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -777- PERFORM R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1 */

            R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1();

            /*" -781- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -785- MOVE ZEROS TO PARAMPRO-COD-PRODUTO PARAMPRO-VALOR-COMISSAO-PRD PARAMPRO-PERCEN-COMIS-FUNC */
                _.Move(0, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_COD_PRODUTO, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);

                /*" -786- ELSE */
            }
            else
            {


                /*" -787- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -788- DISPLAY 'R0450-00 - PROBLEMAS NO SELECT(PARAMPRO)' */
                    _.Display($"R0450-00 - PROBLEMAS NO SELECT(PARAMPRO)");

                    /*" -789- DISPLAY ' PRODUTO ' PARAMPRO-COD-PRODUTO */
                    _.Display($" PRODUTO {PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_COD_PRODUTO}");

                    /*" -789- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0450-00-SELECT-PARAM-PRODUTO-DB-SELECT-1 */
        public void R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1()
        {
            /*" -777- EXEC SQL SELECT COD_PRODUTO , VALOR_COMISSAO_PRD , PERCEN_COMIS_FUNC INTO :PARAMPRO-COD-PRODUTO , :PARAMPRO-VALOR-COMISSAO-PRD , :PARAMPRO-PERCEN-COMIS-FUNC FROM SEGUROS.PARAM_PRODUTO WHERE COD_PRODUTO = :PARAMPRO-COD-PRODUTO AND TIPO_FUNCIONARIO = :PARAMPRO-TIPO-FUNCIONARIO AND DATA_INIVIGENCIA <= :PARAMPRO-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :PARAMPRO-DATA-INIVIGENCIA AND MARGEM = :PARAMPRO-MARGEM AND STA_RENOVACAO = :PARAMPRO-STA-RENOVACAO WITH UR END-EXEC. */

            var r0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1 = new R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1()
            {
                PARAMPRO_TIPO_FUNCIONARIO = PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_TIPO_FUNCIONARIO.ToString(),
                PARAMPRO_DATA_INIVIGENCIA = PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_DATA_INIVIGENCIA.ToString(),
                PARAMPRO_STA_RENOVACAO = PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_STA_RENOVACAO.ToString(),
                PARAMPRO_COD_PRODUTO = PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_COD_PRODUTO.ToString(),
                PARAMPRO_MARGEM = PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_MARGEM.ToString(),
            };

            var executed_1 = R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1.Execute(r0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMPRO_COD_PRODUTO, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_COD_PRODUTO);
                _.Move(executed_1.PARAMPRO_VALOR_COMISSAO_PRD, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD);
                _.Move(executed_1.PARAMPRO_PERCEN_COMIS_FUNC, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-SELECT-V0COBERAPOL-SECTION */
        private void R0500_00_SELECT_V0COBERAPOL_SECTION()
        {
            /*" -802- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -814- PERFORM R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1 */

            R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1();

            /*" -818- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -819- MOVE ZEROS TO WHOST-PCTCOBER */
                _.Move(0, WHOST_PCTCOBER);

                /*" -820- ELSE */
            }
            else
            {


                /*" -821- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -822- DISPLAY 'R0500-00 - PROBLEMAS NO SELECT(APOLICOB)' */
                    _.Display($"R0500-00 - PROBLEMAS NO SELECT(APOLICOB)");

                    /*" -823- DISPLAY ' APOLICE     ' HISCONPA-NUM-APOLICE */
                    _.Display($" APOLICE     {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE}");

                    /*" -824- DISPLAY ' ENDOSSO     ' HISCONPA-NUM-ENDOSSO */
                    _.Display($" ENDOSSO     {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}");

                    /*" -825- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -826- ELSE */
                }
                else
                {


                    /*" -827- IF VIND-PCTCOB LESS ZEROS */

                    if (VIND_PCTCOB < 00)
                    {

                        /*" -827- MOVE ZEROS TO WHOST-PCTCOBER. */
                        _.Move(0, WHOST_PCTCOBER);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0500-00-SELECT-V0COBERAPOL-DB-SELECT-1 */
        public void R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1()
        {
            /*" -814- EXEC SQL SELECT SUM(PCT_COBERTURA) INTO :WHOST-PCTCOBER:VIND-PCTCOB FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO AND NUM_ITEM = 0 AND COD_COBERTURA = 0 AND PCT_COBERTURA > 0 AND DATA_INIVIGENCIA <= :ENDOSSOS-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :ENDOSSOS-DATA-INIVIGENCIA WITH UR END-EXEC. */

            var r0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 = new R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1()
            {
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1.Execute(r0500_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_PCTCOBER, WHOST_PCTCOBER);
                _.Move(executed_1.VIND_PCTCOB, VIND_PCTCOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-UPDATE-V0FUNDO-SECTION */
        private void R1500_00_UPDATE_V0FUNDO_SECTION()
        {
            /*" -840- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -845- PERFORM R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1 */

            R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1();

            /*" -848- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -849- DISPLAY 'R1500-00 - PROBLEMAS UPDATE (V0FUNDO)     ' */
                _.Display($"R1500-00 - PROBLEMAS UPDATE (V0FUNDO)     ");

                /*" -849- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1500-00-UPDATE-V0FUNDO-DB-UPDATE-1 */
        public void R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1()
        {
            /*" -845- EXEC SQL UPDATE SEGUROS.FUNDO_COMISSAO_VA SET SITUACAO = :FUNCOMVA-SITUACAO ,NUM_MATRI_VENDEDOR = :FUNCOMVA-NUM-MATRI-VENDEDOR WHERE CURRENT OF V0FUNDO END-EXEC. */

            var r1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1 = new R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1(V0FUNDO)
            {
                FUNCOMVA_NUM_MATRI_VENDEDOR = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_MATRI_VENDEDOR.ToString(),
                FUNCOMVA_SITUACAO = FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO.ToString(),
            };

            R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1.Execute(r1500_00_UPDATE_V0FUNDO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-VALOR-FIXO-SECTION */
        private void R2000_00_VALOR_FIXO_SECTION()
        {
            /*" -862- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -865- MOVE ENDOSSOS-RAMO-EMISSOR TO COMISSOE-RAMO-COBERTURA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR, COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

            /*" -870- MOVE ZEROS TO COMISSOE-VAL-COMISSAO COMISSOE-VAL-BASICO COMISSOE-PCT-COM-CORRETOR. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR);

            /*" -874- COMPUTE COMISSOE-VAL-BASICO EQUAL (FUNCOMVA-VAL-BASICO-VG + FUNCOMVA-VAL-BASICO-AP). */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO.Value = (FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_VG + FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_AP);

            /*" -877- MOVE PARAMPRO-VALOR-COMISSAO-PRD TO COMISSOE-VAL-COMISSAO. */
            _.Move(PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_VALOR_COMISSAO_PRD, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO);

            /*" -882- COMPUTE COMISSOE-PCT-COM-CORRETOR EQUAL ((COMISSOE-VAL-COMISSAO * 100) / COMISSOE-VAL-BASICO). */
            COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR.Value = ((COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO * 100) / COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO);

            /*" -885- PERFORM R3200-00-GRAVA-COMISSAO. */

            R3200_00_GRAVA_COMISSAO_SECTION();

            /*" -886- IF WTEM-PAGTO NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_PAGTO != "S")
            {

                /*" -888- MOVE '2' TO FUNCOMVA-SITUACAO */
                _.Move("2", FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO);

                /*" -889- ELSE */
            }
            else
            {


                /*" -893- MOVE '1' TO FUNCOMVA-SITUACAO. */
                _.Move("1", FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO);
            }


            /*" -893- PERFORM R1500-00-UPDATE-V0FUNDO. */

            R1500_00_UPDATE_V0FUNDO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-CALCULA-COBERTURAS-SECTION */
        private void R2500_00_CALCULA_COBERTURAS_SECTION()
        {
            /*" -906- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -910- COMPUTE WSHOST-VAL-BASE EQUAL (FUNCOMVA-VAL-BASICO-VG + FUNCOMVA-VAL-BASICO-AP). */
            WSHOST_VAL_BASE.Value = (FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_VG + FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_VAL_BASICO_AP);

            /*" -914- MOVE PARAMPRO-PERCEN-COMIS-FUNC TO COMISSOE-PCT-COM-CORRETOR. */
            _.Move(PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR);

            /*" -915- MOVE SPACES TO WFIM-COBERAPOL. */
            _.Move("", AREA_DE_WORK.WFIM_COBERAPOL);

            /*" -916- PERFORM R2600-00-DECLARE-COBERAPOL. */

            R2600_00_DECLARE_COBERAPOL_SECTION();

            /*" -920- PERFORM R2610-00-FETCH-COBERAPOL UNTIL WFIM-COBERAPOL NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_COBERAPOL.IsEmpty()))
            {

                R2610_00_FETCH_COBERAPOL_SECTION();
            }

            /*" -921- IF WTEM-PAGTO NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_PAGTO != "S")
            {

                /*" -923- MOVE '2' TO FUNCOMVA-SITUACAO */
                _.Move("2", FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO);

                /*" -924- ELSE */
            }
            else
            {


                /*" -928- MOVE '1' TO FUNCOMVA-SITUACAO. */
                _.Move("1", FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO);
            }


            /*" -928- PERFORM R1500-00-UPDATE-V0FUNDO. */

            R1500_00_UPDATE_V0FUNDO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-DECLARE-COBERAPOL-SECTION */
        private void R2600_00_DECLARE_COBERAPOL_SECTION()
        {
            /*" -941- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -954- PERFORM R2600_00_DECLARE_COBERAPOL_DB_DECLARE_1 */

            R2600_00_DECLARE_COBERAPOL_DB_DECLARE_1();

            /*" -956- PERFORM R2600_00_DECLARE_COBERAPOL_DB_OPEN_1 */

            R2600_00_DECLARE_COBERAPOL_DB_OPEN_1();

            /*" -960- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -961- DISPLAY 'R2600-00 - PROBLEMAS DECLARE (APOLICOB)  ' */
                _.Display($"R2600-00 - PROBLEMAS DECLARE (APOLICOB)  ");

                /*" -961- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2600-00-DECLARE-COBERAPOL-DB-OPEN-1 */
        public void R2600_00_DECLARE_COBERAPOL_DB_OPEN_1()
        {
            /*" -956- EXEC SQL OPEN V0COBERAPOL END-EXEC. */

            V0COBERAPOL.Open();

        }

        [StopWatch]
        /*" R3400-00-DECLARE-V0HISCONPA-DB-DECLARE-1 */
        public void R3400_00_DECLARE_V0HISCONPA_DB_DECLARE_1()
        {
            /*" -1264- EXEC SQL DECLARE V0HISCONPA CURSOR WITH HOLD FOR SELECT A.NUM_CERTIFICADO , A.NUM_PARCELA , A.NUM_TITULO , A.OCORR_HISTORICO , A.NUM_APOLICE , A.COD_SUBGRUPO , A.COD_FONTE , A.NUM_ENDOSSO , A.PREMIO_VG , A.PREMIO_AP , A.DTFATUR , B.COD_PRODUTO , B.RAMO_EMISSOR , B.DATA_INIVIGENCIA , C.COD_MODALIDADE , D.COD_CLIENTE , D.NUM_MATRI_VENDEDOR FROM SEGUROS.HIST_CONT_PARCELVA A , SEGUROS.ENDOSSOS B , SEGUROS.APOLICES C , SEGUROS.PROPOSTAS_VA D WHERE A.DTFATUR = :SISTEMAS-DATA-MOV-ABERTO AND A.NUM_PARCELA IN (0,1) AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_ENDOSSO > 0 AND B.TIPO_ENDOSSO IN ( '0' , '1' ) AND C.NUM_APOLICE = B.NUM_APOLICE AND D.NUM_CERTIFICADO = A.NUM_CERTIFICADO END-EXEC. */
            V0HISCONPA = new VA0506B_V0HISCONPA(true);
            string GetQuery_V0HISCONPA()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO 
							, A.NUM_PARCELA 
							, A.NUM_TITULO 
							, A.OCORR_HISTORICO 
							, A.NUM_APOLICE 
							, A.COD_SUBGRUPO 
							, A.COD_FONTE 
							, A.NUM_ENDOSSO 
							, A.PREMIO_VG 
							, A.PREMIO_AP 
							, A.DTFATUR 
							, B.COD_PRODUTO 
							, B.RAMO_EMISSOR 
							, B.DATA_INIVIGENCIA 
							, C.COD_MODALIDADE 
							, D.COD_CLIENTE 
							, D.NUM_MATRI_VENDEDOR 
							FROM SEGUROS.HIST_CONT_PARCELVA A 
							, SEGUROS.ENDOSSOS B 
							, SEGUROS.APOLICES C 
							, SEGUROS.PROPOSTAS_VA D 
							WHERE A.DTFATUR = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.NUM_PARCELA IN (0
							,1) 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND B.NUM_ENDOSSO > 0 
							AND B.TIPO_ENDOSSO IN ( '0'
							, '1' ) 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND D.NUM_CERTIFICADO = A.NUM_CERTIFICADO";

                return query;
            }
            V0HISCONPA.GetQueryEvent += GetQuery_V0HISCONPA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2610-00-FETCH-COBERAPOL-SECTION */
        private void R2610_00_FETCH_COBERAPOL_SECTION()
        {
            /*" -974- MOVE '2610' TO WNR-EXEC-SQL. */
            _.Move("2610", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -977- PERFORM R2610_00_FETCH_COBERAPOL_DB_FETCH_1 */

            R2610_00_FETCH_COBERAPOL_DB_FETCH_1();

            /*" -981- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -981- PERFORM R2610_00_FETCH_COBERAPOL_DB_CLOSE_1 */

                R2610_00_FETCH_COBERAPOL_DB_CLOSE_1();

                /*" -983- MOVE 'S' TO WFIM-COBERAPOL */
                _.Move("S", AREA_DE_WORK.WFIM_COBERAPOL);

                /*" -985- GO TO R2610-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/ //GOTO
                return;
            }


            /*" -986- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -987- DISPLAY 'R2610-00 - PROBLEMAS FETCH (APOLICOB)    ' */
                _.Display($"R2610-00 - PROBLEMAS FETCH (APOLICOB)    ");

                /*" -990- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -993- MOVE APOLICOB-RAMO-COBERTURA TO COMISSOE-RAMO-COBERTURA. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

            /*" -998- MOVE ZEROS TO COMISSOE-VAL-COMISSAO COMISSOE-VAL-BASICO. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO);

            /*" -1002- COMPUTE COMISSOE-VAL-BASICO EQUAL ((WSHOST-VAL-BASE * APOLICOB-PCT-COBERTURA) / 100). */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO.Value = ((WSHOST_VAL_BASE * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA) / 100f);

            /*" -1007- COMPUTE COMISSOE-VAL-COMISSAO EQUAL ((COMISSOE-VAL-BASICO * COMISSOE-PCT-COM-CORRETOR) / 100). */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.Value = ((COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO * COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR) / 100f);

            /*" -1007- PERFORM R3200-00-GRAVA-COMISSAO. */

            R3200_00_GRAVA_COMISSAO_SECTION();

        }

        [StopWatch]
        /*" R2610-00-FETCH-COBERAPOL-DB-FETCH-1 */
        public void R2610_00_FETCH_COBERAPOL_DB_FETCH_1()
        {
            /*" -977- EXEC SQL FETCH V0COBERAPOL INTO :APOLICOB-RAMO-COBERTURA ,:APOLICOB-PCT-COBERTURA END-EXEC. */

            if (V0COBERAPOL.Fetch())
            {
                _.Move(V0COBERAPOL.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
                _.Move(V0COBERAPOL.APOLICOB_PCT_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);
            }

        }

        [StopWatch]
        /*" R2610-00-FETCH-COBERAPOL-DB-CLOSE-1 */
        public void R2610_00_FETCH_COBERAPOL_DB_CLOSE_1()
        {
            /*" -981- EXEC SQL CLOSE V0COBERAPOL END-EXEC */

            V0COBERAPOL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-GRAVA-COMISSAO-SECTION */
        private void R3200_00_GRAVA_COMISSAO_SECTION()
        {
            /*" -1020- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1022- MOVE ZEROS TO COMISSOE-COD-EMPRESA. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_COD_EMPRESA);

            /*" -1024- MOVE 19224 TO COMISSOE-COD-PRODUTOR. */
            _.Move(19224, COMISSOE.DCLCOMISSOES.COMISSOE_COD_PRODUTOR);

            /*" -1026- MOVE HISCONPA-NUM-APOLICE TO COMISSOE-NUM-APOLICE. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_APOLICE);

            /*" -1028- MOVE HISCONPA-NUM-CERTIFICADO TO COMISSOE-NUM-CERTIFICADO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_CERTIFICADO);

            /*" -1030- MOVE HISCONPA-NUM-ENDOSSO TO COMISSOE-NUM-ENDOSSO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_ENDOSSO);

            /*" -1033- MOVE HISCONPA-NUM-PARCELA TO COMISSOE-NUM-PARCELA COMISSOE-QTD-PARCELAS */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_PARCELA, COMISSOE.DCLCOMISSOES.COMISSOE_QTD_PARCELAS);

            /*" -1035- MOVE APOLICES-COD-MODALIDADE TO COMISSOE-MODALI-COBERTURA. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE, COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA);

            /*" -1037- MOVE HISCONPA-OCORR-HISTORICO TO COMISSOE-OCORR-HISTORICO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO, COMISSOE.DCLCOMISSOES.COMISSOE_OCORR_HISTORICO);

            /*" -1039- MOVE HISCONPA-COD-SUBGRUPO TO COMISSOE-COD-SUBGRUPO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO, COMISSOE.DCLCOMISSOES.COMISSOE_COD_SUBGRUPO);

            /*" -1041- MOVE FUNCOMVA-COD-FONTE TO COMISSOE-COD-FONTE. */
            _.Move(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_FONTE, COMISSOE.DCLCOMISSOES.COMISSOE_COD_FONTE);

            /*" -1043- MOVE FUNCOMVA-DATA-QUITACAO TO COMISSOE-DATA-QUITACAO. */
            _.Move(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_QUITACAO, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_QUITACAO);

            /*" -1045- MOVE FUNCOMVA-COD-CLIENTE TO COMISSOE-COD-CLIENTE. */
            _.Move(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_CLIENTE, COMISSOE.DCLCOMISSOES.COMISSOE_COD_CLIENTE);

            /*" -1047- MOVE FUNCOMVA-COD-OPERACAO TO COMISSOE-COD-OPERACAO. */
            _.Move(FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_OPERACAO, COMISSOE.DCLCOMISSOES.COMISSOE_COD_OPERACAO);

            /*" -1050- MOVE SISTEMAS-DATA-MOV-ABERTO TO COMISSOE-DATA-CALCULO COMISSOE-DATA-SELECAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_CALCULO, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_SELECAO);

            /*" -1055- MOVE '1' TO COMISSOE-TIPO-COMISSAO COMISSOE-TIPO-SEGURADO. */
            _.Move("1", COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_COMISSAO, COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_SEGURADO);

            /*" -1062- MOVE ZEROS TO COMISSOE-COD-PREPOSTO COMISSOE-NUM-RECIBO COMISSOE-PCT-DESC-PREMIO COMISSOE-NUM-BILHETE COMISSOE-VAL-VARMON. */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_COD_PREPOSTO, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_RECIBO, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_DESC_PREMIO, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_BILHETE, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_VARMON);

            /*" -1066- MOVE SPACES TO COMISSOE-DAC-CERTIFICADO COMISSOE-DATA-MOVIMENTO. */
            _.Move("", COMISSOE.DCLCOMISSOES.COMISSOE_DAC_CERTIFICADO, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_MOVIMENTO);

            /*" -1073- MOVE ZEROS TO VIND-DATSEL VIND-CODEMP VIND-CODPRP VIND-VLVARMON VIND-DTQITBCO. */
            _.Move(0, VIND_DATSEL, VIND_CODEMP, VIND_CODPRP, VIND_VLVARMON, VIND_DTQITBCO);

            /*" -1077- MOVE -1 TO VIND-DTMOVTO VIND-NUMBIL. */
            _.Move(-1, VIND_DTMOVTO, VIND_NUMBIL);

            /*" -1078- IF COMISSOE-VAL-COMISSAO GREATER ZEROS */

            if (COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO > 00)
            {

                /*" -1079- PERFORM R3300-00-INSERT-COMISSOE */

                R3300_00_INSERT_COMISSOE_SECTION();

                /*" -1080- ELSE */
            }
            else
            {


                /*" -1080- ADD 1 TO DP-COMISSOE. */
                AREA_DE_WORK.DP_COMISSOE.Value = AREA_DE_WORK.DP_COMISSOE + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-INSERT-COMISSOE-SECTION */
        private void R3300_00_INSERT_COMISSOE_SECTION()
        {
            /*" -1093- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1158- PERFORM R3300_00_INSERT_COMISSOE_DB_INSERT_1 */

            R3300_00_INSERT_COMISSOE_DB_INSERT_1();

            /*" -1162- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1163- ADD 1 TO IN-COMISSOE */
                AREA_DE_WORK.IN_COMISSOE.Value = AREA_DE_WORK.IN_COMISSOE + 1;

                /*" -1164- MOVE 'S' TO WTEM-PAGTO */
                _.Move("S", AREA_DE_WORK.WTEM_PAGTO);

                /*" -1165- ELSE */
            }
            else
            {


                /*" -1166- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1167- ADD 1 TO AC-DUPLICA */
                    AREA_DE_WORK.AC_DUPLICA.Value = AREA_DE_WORK.AC_DUPLICA + 1;

                    /*" -1168- ELSE */
                }
                else
                {


                    /*" -1169- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1170- DISPLAY 'R3300-00 - PROBLEMAS NO INSERT(COMISSOE)   ' */
                        _.Display($"R3300-00 - PROBLEMAS NO INSERT(COMISSOE)   ");

                        /*" -1171- DISPLAY ' APOLICE     ' COMISSOE-NUM-APOLICE */
                        _.Display($" APOLICE     {COMISSOE.DCLCOMISSOES.COMISSOE_NUM_APOLICE}");

                        /*" -1172- DISPLAY ' ENDOSSO     ' COMISSOE-NUM-ENDOSSO */
                        _.Display($" ENDOSSO     {COMISSOE.DCLCOMISSOES.COMISSOE_NUM_ENDOSSO}");

                        /*" -1173- DISPLAY ' PARCELA     ' COMISSOE-NUM-PARCELA */
                        _.Display($" PARCELA     {COMISSOE.DCLCOMISSOES.COMISSOE_NUM_PARCELA}");

                        /*" -1174- DISPLAY ' CERTIFICADO ' COMISSOE-NUM-CERTIFICADO */
                        _.Display($" CERTIFICADO {COMISSOE.DCLCOMISSOES.COMISSOE_NUM_CERTIFICADO}");

                        /*" -1175- DISPLAY 'R3300-00 - PROBLEMAS NO INSERT(COMISSOE)   ' */
                        _.Display($"R3300-00 - PROBLEMAS NO INSERT(COMISSOE)   ");

                        /*" -1175- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R3300-00-INSERT-COMISSOE-DB-INSERT-1 */
        public void R3300_00_INSERT_COMISSOE_DB_INSERT_1()
        {
            /*" -1158- EXEC SQL INSERT INTO SEGUROS.COMISSOES (NUM_APOLICE , NUM_ENDOSSO , NUM_CERTIFICADO , DAC_CERTIFICADO , TIPO_SEGURADO , NUM_PARCELA , COD_OPERACAO , COD_PRODUTOR , RAMO_COBERTURA , MODALI_COBERTURA , OCORR_HISTORICO , COD_FONTE , COD_CLIENTE , VAL_COMISSAO , DATA_CALCULO , NUM_RECIBO , VAL_BASICO , TIPO_COMISSAO , QTD_PARCELAS , PCT_COM_CORRETOR , PCT_DESC_PREMIO , COD_SUBGRUPO , HORA_OPERACAO , DATA_MOVIMENTO , DATA_SELECAO , COD_EMPRESA , COD_PREPOSTO , TIMESTAMP , NUM_BILHETE , VAL_VARMON , DATA_QUITACAO) VALUES (:COMISSOE-NUM-APOLICE ,:COMISSOE-NUM-ENDOSSO ,:COMISSOE-NUM-CERTIFICADO ,:COMISSOE-DAC-CERTIFICADO ,:COMISSOE-TIPO-SEGURADO ,:COMISSOE-NUM-PARCELA ,:COMISSOE-COD-OPERACAO ,:COMISSOE-COD-PRODUTOR ,:COMISSOE-RAMO-COBERTURA ,:COMISSOE-MODALI-COBERTURA ,:COMISSOE-OCORR-HISTORICO ,:COMISSOE-COD-FONTE ,:COMISSOE-COD-CLIENTE ,:COMISSOE-VAL-COMISSAO ,:COMISSOE-DATA-CALCULO ,:COMISSOE-NUM-RECIBO ,:COMISSOE-VAL-BASICO ,:COMISSOE-TIPO-COMISSAO ,:COMISSOE-QTD-PARCELAS ,:COMISSOE-PCT-COM-CORRETOR ,:COMISSOE-PCT-DESC-PREMIO ,:COMISSOE-COD-SUBGRUPO , CURRENT TIME ,:COMISSOE-DATA-MOVIMENTO:VIND-DTMOVTO ,:COMISSOE-DATA-SELECAO:VIND-DATSEL ,:COMISSOE-COD-EMPRESA:VIND-CODEMP ,:COMISSOE-COD-PREPOSTO:VIND-CODPRP , CURRENT TIMESTAMP ,:COMISSOE-NUM-BILHETE:VIND-NUMBIL ,:COMISSOE-VAL-VARMON:VIND-VLVARMON ,:COMISSOE-DATA-QUITACAO:VIND-DTQITBCO) END-EXEC. */

            var r3300_00_INSERT_COMISSOE_DB_INSERT_1_Insert1 = new R3300_00_INSERT_COMISSOE_DB_INSERT_1_Insert1()
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
                COMISSOE_DATA_MOVIMENTO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_MOVIMENTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
                COMISSOE_DATA_SELECAO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_SELECAO.ToString(),
                VIND_DATSEL = VIND_DATSEL.ToString(),
                COMISSOE_COD_EMPRESA = COMISSOE.DCLCOMISSOES.COMISSOE_COD_EMPRESA.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                COMISSOE_COD_PREPOSTO = COMISSOE.DCLCOMISSOES.COMISSOE_COD_PREPOSTO.ToString(),
                VIND_CODPRP = VIND_CODPRP.ToString(),
                COMISSOE_NUM_BILHETE = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_BILHETE.ToString(),
                VIND_NUMBIL = VIND_NUMBIL.ToString(),
                COMISSOE_VAL_VARMON = COMISSOE.DCLCOMISSOES.COMISSOE_VAL_VARMON.ToString(),
                VIND_VLVARMON = VIND_VLVARMON.ToString(),
                COMISSOE_DATA_QUITACAO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_QUITACAO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
            };

            R3300_00_INSERT_COMISSOE_DB_INSERT_1_Insert1.Execute(r3300_00_INSERT_COMISSOE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3390-00-TRATA-FATURAS-SECTION */
        private void R3390_00_TRATA_FATURAS_SECTION()
        {
            /*" -1188- MOVE '3390' TO WNR-EXEC-SQL. */
            _.Move("3390", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1194- MOVE ZEROS TO LD-HISCONPA DP-HISCONPA IN-COMISSOE DP-COMISSOE. */
            _.Move(0, AREA_DE_WORK.LD_HISCONPA, AREA_DE_WORK.DP_HISCONPA, AREA_DE_WORK.IN_COMISSOE, AREA_DE_WORK.DP_COMISSOE);

            /*" -1195- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -1196- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -1197- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -1198- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -1199- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -1200- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -1203- DISPLAY 'TRATA FATURAS     ' WTIME-DAYR. */
            _.Display($"TRATA FATURAS     {AREA_DE_WORK.FILLER_4.WTIME_DAYR}");

            /*" -1204- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -1205- PERFORM R3400-00-DECLARE-V0HISCONPA */

            R3400_00_DECLARE_V0HISCONPA_SECTION();

            /*" -1208- PERFORM R3410-00-FETCH-V0HISCONPA. */

            R3410_00_FETCH_V0HISCONPA_SECTION();

            /*" -1212- PERFORM R3450-00-PROCESSA-V0HISCONPA UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R3450_00_PROCESSA_V0HISCONPA_SECTION();
            }

            /*" -1212- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1215- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1216- DISPLAY 'LIDOS HISCONPA ............. ' LD-HISCONPA */
            _.Display($"LIDOS HISCONPA ............. {AREA_DE_WORK.LD_HISCONPA}");

            /*" -1217- DISPLAY 'DESPREZA HISCONPA .......... ' DP-HISCONPA */
            _.Display($"DESPREZA HISCONPA .......... {AREA_DE_WORK.DP_HISCONPA}");

            /*" -1218- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1219- DISPLAY 'INSERE COMISSOES ........... ' IN-COMISSOE */
            _.Display($"INSERE COMISSOES ........... {AREA_DE_WORK.IN_COMISSOE}");

            /*" -1220- DISPLAY 'DESPREZA COMISSOES ......... ' DP-COMISSOE */
            _.Display($"DESPREZA COMISSOES ......... {AREA_DE_WORK.DP_COMISSOE}");

            /*" -1220- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3390_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-DECLARE-V0HISCONPA-SECTION */
        private void R3400_00_DECLARE_V0HISCONPA_SECTION()
        {
            /*" -1233- MOVE '3400' TO WNR-EXEC-SQL. */
            _.Move("3400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1264- PERFORM R3400_00_DECLARE_V0HISCONPA_DB_DECLARE_1 */

            R3400_00_DECLARE_V0HISCONPA_DB_DECLARE_1();

            /*" -1266- PERFORM R3400_00_DECLARE_V0HISCONPA_DB_OPEN_1 */

            R3400_00_DECLARE_V0HISCONPA_DB_OPEN_1();

            /*" -1270- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1271- DISPLAY 'R3400-00 - PROBLEMAS DECLARE (HISCONPA)  ' */
                _.Display($"R3400-00 - PROBLEMAS DECLARE (HISCONPA)  ");

                /*" -1274- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1275- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -1276- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -1277- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -1278- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -1279- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -1280- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -1280- DISPLAY 'FETCH   HISCONPA  ' WTIME-DAYR. */
            _.Display($"FETCH   HISCONPA  {AREA_DE_WORK.FILLER_4.WTIME_DAYR}");

        }

        [StopWatch]
        /*" R3400-00-DECLARE-V0HISCONPA-DB-OPEN-1 */
        public void R3400_00_DECLARE_V0HISCONPA_DB_OPEN_1()
        {
            /*" -1266- EXEC SQL OPEN V0HISCONPA END-EXEC. */

            V0HISCONPA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3410-00-FETCH-V0HISCONPA-SECTION */
        private void R3410_00_FETCH_V0HISCONPA_SECTION()
        {
            /*" -1293- MOVE '3410' TO WNR-EXEC-SQL. */
            _.Move("3410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1311- PERFORM R3410_00_FETCH_V0HISCONPA_DB_FETCH_1 */

            R3410_00_FETCH_V0HISCONPA_DB_FETCH_1();

            /*" -1315- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1315- PERFORM R3410_00_FETCH_V0HISCONPA_DB_CLOSE_1 */

                R3410_00_FETCH_V0HISCONPA_DB_CLOSE_1();

                /*" -1317- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                /*" -1319- GO TO R3410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1320- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1321- DISPLAY 'R3410-00 - PROBLEMAS FETCH (HISCONPA)    ' */
                _.Display($"R3410-00 - PROBLEMAS FETCH (HISCONPA)    ");

                /*" -1324- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1325- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -1329- MOVE SISTEMAS-DATA-MOV-ABERTO TO HISCONPA-DTFATUR. */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR);
            }


            /*" -1332- ADD 1 TO LD-HISCONPA. */
            AREA_DE_WORK.LD_HISCONPA.Value = AREA_DE_WORK.LD_HISCONPA + 1;

            /*" -1334- MOVE LD-HISCONPA TO AC-LIDOS. */
            _.Move(AREA_DE_WORK.LD_HISCONPA, AREA_DE_WORK.AC_LIDOS);

            /*" -1336- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (AREA_DE_WORK.FILLER_0.LD_PARTE2 == 00 || AREA_DE_WORK.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -1337- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

                /*" -1338- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -1339- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -1340- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -1341- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -1342- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -1343- DISPLAY 'LIDOS HISCONPA     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS HISCONPA     {AREA_DE_WORK.AC_LIDOS}    {AREA_DE_WORK.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R3410-00-FETCH-V0HISCONPA-DB-FETCH-1 */
        public void R3410_00_FETCH_V0HISCONPA_DB_FETCH_1()
        {
            /*" -1311- EXEC SQL FETCH V0HISCONPA INTO :HISCONPA-NUM-CERTIFICADO ,:HISCONPA-NUM-PARCELA ,:HISCONPA-NUM-TITULO ,:HISCONPA-OCORR-HISTORICO ,:HISCONPA-NUM-APOLICE ,:HISCONPA-COD-SUBGRUPO ,:HISCONPA-COD-FONTE ,:HISCONPA-NUM-ENDOSSO ,:HISCONPA-PREMIO-VG ,:HISCONPA-PREMIO-AP ,:HISCONPA-DTFATUR:VIND-NULL01 ,:ENDOSSOS-COD-PRODUTO ,:ENDOSSOS-RAMO-EMISSOR ,:ENDOSSOS-DATA-INIVIGENCIA ,:APOLICES-COD-MODALIDADE ,:PROPOVA-COD-CLIENTE ,:PROPOVA-NUM-MATRI-VENDEDOR END-EXEC. */

            if (V0HISCONPA.Fetch())
            {
                _.Move(V0HISCONPA.HISCONPA_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);
                _.Move(V0HISCONPA.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(V0HISCONPA.HISCONPA_NUM_TITULO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO);
                _.Move(V0HISCONPA.HISCONPA_OCORR_HISTORICO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);
                _.Move(V0HISCONPA.HISCONPA_NUM_APOLICE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE);
                _.Move(V0HISCONPA.HISCONPA_COD_SUBGRUPO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO);
                _.Move(V0HISCONPA.HISCONPA_COD_FONTE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_FONTE);
                _.Move(V0HISCONPA.HISCONPA_NUM_ENDOSSO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);
                _.Move(V0HISCONPA.HISCONPA_PREMIO_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);
                _.Move(V0HISCONPA.HISCONPA_PREMIO_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);
                _.Move(V0HISCONPA.HISCONPA_DTFATUR, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR);
                _.Move(V0HISCONPA.VIND_NULL01, VIND_NULL01);
                _.Move(V0HISCONPA.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(V0HISCONPA.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
                _.Move(V0HISCONPA.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(V0HISCONPA.APOLICES_COD_MODALIDADE, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);
                _.Move(V0HISCONPA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(V0HISCONPA.PROPOVA_NUM_MATRI_VENDEDOR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR);
            }

        }

        [StopWatch]
        /*" R3410-00-FETCH-V0HISCONPA-DB-CLOSE-1 */
        public void R3410_00_FETCH_V0HISCONPA_DB_CLOSE_1()
        {
            /*" -1315- EXEC SQL CLOSE V0HISCONPA END-EXEC */

            V0HISCONPA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3410_99_SAIDA*/

        [StopWatch]
        /*" R3450-00-PROCESSA-V0HISCONPA-SECTION */
        private void R3450_00_PROCESSA_V0HISCONPA_SECTION()
        {
            /*" -1356- MOVE '3450' TO WNR-EXEC-SQL. */
            _.Move("3450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1358- IF HISCONPA-PREMIO-VG EQUAL ZEROS AND HISCONPA-PREMIO-AP EQUAL ZEROS */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG == 00 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP == 00)
            {

                /*" -1359- ADD 1 TO DP-HISCONPA */
                AREA_DE_WORK.DP_HISCONPA.Value = AREA_DE_WORK.DP_HISCONPA + 1;

                /*" -1362- GO TO R3450-90-LEITURA. */

                R3450_90_LEITURA(); //GOTO
                return;
            }


            /*" -1363- IF HISCONPA-NUM-PARCELA GREATER 1 */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA > 1)
            {

                /*" -1364- ADD 1 TO DP-HISCONPA */
                AREA_DE_WORK.DP_HISCONPA.Value = AREA_DE_WORK.DP_HISCONPA + 1;

                /*" -1367- GO TO R3450-90-LEITURA. */

                R3450_90_LEITURA(); //GOTO
                return;
            }


            /*" -1368- MOVE SPACES TO WTEM-PAGTO. */
            _.Move("", AREA_DE_WORK.WTEM_PAGTO);

            /*" -1371- MOVE HISCONPA-DTFATUR TO FUNCOMVA-DATA-QUITACAO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_QUITACAO);

            /*" -1373- PERFORM R0430-00-SELECT-OPCPAGVI. */

            R0430_00_SELECT_OPCPAGVI_SECTION();

            /*" -1374- IF WTEM-PAGTO NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_PAGTO != "S")
            {

                /*" -1375- ADD 1 TO DP-HISCONPA */
                AREA_DE_WORK.DP_HISCONPA.Value = AREA_DE_WORK.DP_HISCONPA + 1;

                /*" -1381- GO TO R3450-90-LEITURA. */

                R3450_90_LEITURA(); //GOTO
                return;
            }


            /*" -1383- MOVE '1' TO PARAMPRO-TIPO-FUNCIONARIO. */
            _.Move("1", PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_TIPO_FUNCIONARIO);

            /*" -1385- MOVE ENDOSSOS-COD-PRODUTO TO PARAMPRO-COD-PRODUTO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_COD_PRODUTO);

            /*" -1387- MOVE OPCPAGVI-DATA-INIVIGENCIA TO PARAMPRO-DATA-INIVIGENCIA. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_DATA_INIVIGENCIA);

            /*" -1389- MOVE 'N' TO PARAMPRO-STA-RENOVACAO. */
            _.Move("N", PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_STA_RENOVACAO);

            /*" -1392- MOVE ZEROS TO PARAMPRO-MARGEM. */
            _.Move(0, PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_MARGEM);

            /*" -1394- PERFORM R0450-00-SELECT-PARAM-PRODUTO. */

            R0450_00_SELECT_PARAM_PRODUTO_SECTION();

            /*" -1395- IF PARAMPRO-PERCEN-COMIS-FUNC EQUAL ZEROS */

            if (PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC == 00)
            {

                /*" -1396- ADD 1 TO DP-HISCONPA */
                AREA_DE_WORK.DP_HISCONPA.Value = AREA_DE_WORK.DP_HISCONPA + 1;

                /*" -1399- GO TO R3450-90-LEITURA. */

                R3450_90_LEITURA(); //GOTO
                return;
            }


            /*" -1401- PERFORM R0500-00-SELECT-V0COBERAPOL. */

            R0500_00_SELECT_V0COBERAPOL_SECTION();

            /*" -1402- IF WHOST-PCTCOBER NOT EQUAL 100 */

            if (WHOST_PCTCOBER != 100)
            {

                /*" -1403- ADD 1 TO DP-APOLICOB */
                AREA_DE_WORK.DP_APOLICOB.Value = AREA_DE_WORK.DP_APOLICOB + 1;

                /*" -1409- GO TO R3450-90-LEITURA. */

                R3450_90_LEITURA(); //GOTO
                return;
            }


            /*" -1410- MOVE SPACES TO WTEM-PAGTO. */
            _.Move("", AREA_DE_WORK.WTEM_PAGTO);

            /*" -1412- PERFORM R3500-00-SELECT-V0COMISSAO. */

            R3500_00_SELECT_V0COMISSAO_SECTION();

            /*" -1413- IF WTEM-PAGTO EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_PAGTO == "S")
            {

                /*" -1414- ADD 1 TO DP-COMISSOE */
                AREA_DE_WORK.DP_COMISSOE.Value = AREA_DE_WORK.DP_COMISSOE + 1;

                /*" -1417- GO TO R3450-90-LEITURA. */

                R3450_90_LEITURA(); //GOTO
                return;
            }


            /*" -1417- PERFORM R3600-00-CALCULA-COBERTURAS. */

            R3600_00_CALCULA_COBERTURAS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R3450_90_LEITURA */

            R3450_90_LEITURA();

        }

        [StopWatch]
        /*" R3450-90-LEITURA */
        private void R3450_90_LEITURA(bool isPerform = false)
        {
            /*" -1422- PERFORM R3410-00-FETCH-V0HISCONPA. */

            R3410_00_FETCH_V0HISCONPA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3450_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-SELECT-V0COMISSAO-SECTION */
        private void R3500_00_SELECT_V0COMISSAO_SECTION()
        {
            /*" -1434- MOVE '3500' TO WNR-EXEC-SQL. */
            _.Move("3500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1443- PERFORM R3500_00_SELECT_V0COMISSAO_DB_SELECT_1 */

            R3500_00_SELECT_V0COMISSAO_DB_SELECT_1();

            /*" -1447- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1448- MOVE 'N' TO WTEM-PAGTO */
                _.Move("N", AREA_DE_WORK.WTEM_PAGTO);

                /*" -1449- ELSE */
            }
            else
            {


                /*" -1450- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1451- MOVE 'S' TO WTEM-PAGTO */
                    _.Move("S", AREA_DE_WORK.WTEM_PAGTO);

                    /*" -1452- ELSE */
                }
                else
                {


                    /*" -1453- DISPLAY 'R3500-00 - PROBLEMAS NO SELECT(COMISSOE)' */
                    _.Display($"R3500-00 - PROBLEMAS NO SELECT(COMISSOE)");

                    /*" -1454- DISPLAY ' APOLICE     ' HISCONPA-NUM-APOLICE */
                    _.Display($" APOLICE     {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE}");

                    /*" -1455- DISPLAY ' ENDOSSO     ' HISCONPA-NUM-ENDOSSO */
                    _.Display($" ENDOSSO     {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO}");

                    /*" -1456- DISPLAY ' NRCERTIF    ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($" NRCERTIF    {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -1456- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3500-00-SELECT-V0COMISSAO-DB-SELECT-1 */
        public void R3500_00_SELECT_V0COMISSAO_DB_SELECT_1()
        {
            /*" -1443- EXEC SQL SELECT NUM_RECIBO INTO :COMISSOE-NUM-RECIBO FROM SEGUROS.COMISSOES WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO AND NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1 = new R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1.Execute(r3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COMISSOE_NUM_RECIBO, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_RECIBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-CALCULA-COBERTURAS-SECTION */
        private void R3600_00_CALCULA_COBERTURAS_SECTION()
        {
            /*" -1469- MOVE '3600' TO WNR-EXEC-SQL. */
            _.Move("3600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1471- MOVE HISCONPA-COD-FONTE TO FUNCOMVA-COD-FONTE. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_FONTE, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_FONTE);

            /*" -1473- MOVE HISCONPA-DTFATUR TO FUNCOMVA-DATA-QUITACAO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_QUITACAO);

            /*" -1475- MOVE PROPOVA-COD-CLIENTE TO FUNCOMVA-COD-CLIENTE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_CLIENTE);

            /*" -1479- MOVE 1101 TO FUNCOMVA-COD-OPERACAO. */
            _.Move(1101, FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_COD_OPERACAO);

            /*" -1483- COMPUTE WSHOST-VAL-BASE EQUAL (HISCONPA-PREMIO-VG + HISCONPA-PREMIO-AP). */
            WSHOST_VAL_BASE.Value = (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG + HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

            /*" -1487- MOVE PARAMPRO-PERCEN-COMIS-FUNC TO COMISSOE-PCT-COM-CORRETOR. */
            _.Move(PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_PERCEN_COMIS_FUNC, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR);

            /*" -1488- MOVE SPACES TO WFIM-COBERAPOL. */
            _.Move("", AREA_DE_WORK.WFIM_COBERAPOL);

            /*" -1489- PERFORM R2600-00-DECLARE-COBERAPOL. */

            R2600_00_DECLARE_COBERAPOL_SECTION();

            /*" -1490- PERFORM R2610-00-FETCH-COBERAPOL UNTIL WFIM-COBERAPOL NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_COBERAPOL.IsEmpty()))
            {

                R2610_00_FETCH_COBERAPOL_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1502- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1504- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1507- DISPLAY LD99-ABEND. */
            _.Display(LD99_ABEND);

            /*" -1507- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1511- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1512- DISPLAY ' ' */
            _.Display($" ");

            /*" -1513- DISPLAY 'CO9388B - FIM COM ERRO     ' . */
            _.Display($"CO9388B - FIM COM ERRO     ");

            /*" -1515- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1515- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}