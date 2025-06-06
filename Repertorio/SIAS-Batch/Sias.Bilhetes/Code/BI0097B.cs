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
using Sias.Bilhetes.DB2.BI0097B;

namespace Code
{
    public class BI0097B
    {
        public bool IsCall { get; set; }

        public BI0097B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ BILHETES                            *      */
        /*"      *   PROGRAMA ............... BI0097B                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  19/04/2017                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ................. ATENDE CADMUS 145360                *      */
        /*"      *                                                                *      */
        /*"      *   01. OBJETIVO GERAL :                                         *      */
        /*"      *   CRIACAO DA REGRA QUE PERMITA O CANCELAMENTO POR INADIPLENCIA *      */
        /*"      *   DOS BILHETES COM PERIDIOCIDADE DE COBRANCA MENSAL QUANDO     *      */
        /*"      *   ATINGIREM 03(TRES) PARCELAS CONSECUTIVAS SEM O DEVIDO        *      */
        /*"      *   PAGAMENTO.                                                   *      */
        /*"      *   OS BILHETES QUE JA ESTIVEREM COM 03(TRES) OU MAIS PARCELAS   *      */
        /*"      *   INADIMPLENTES DEVEM SER CANCELADOS DE IMEDIATO.              *      */
        /*"      *                                                                *      */
        /*"      *   02. PREMISSA                                                 *      */
        /*"      *   PRODUTOS QUE CONTEMPLAM ESTA ESPECIFICACAO:                  *      */
        /*"      *   A) FARMA FACIL MICROSSEGURO - 3710                           *      */
        /*"      *   B) FACIL ASSISTENCIA PREMIADA                                *      */
        /*"      *     (8114,8115,8116,8117,8118,8119,8120,8121,8122 E 8123)      *      */
        /*"      *   C) FAMILIA TRANQUILA MICROSSEGURO - 3704                     *      */
        /*"      *                                                                *      */
        /*"JV102 *----------------------------------------------------------------*      */
        /*"JV102 *VERSAO 02: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV102 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV102 *           - PROCURAR POR JV102                                 *      */
        /*"JV102 *----------------------------------------------------------------*      */
        /*"JV.01 *   VERSAO 01 - PROJETO JOINT VENTURE (JV)                       *      */
        /*"=     *             - AVALIAR IMPACTO PRODUTO, APOLICE, ORGAO, ETC.    *      */
        /*"=     *             - Historia: 181375.                                *      */
        /*"=     *    EM 24/01/2019 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR JV.01       *      */
        /*"JV.01 *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public SortBasis<BI0097B_REG_SBI0097B> SBI0097B { get; set; } = new SortBasis<BI0097B_REG_SBI0097B>(new BI0097B_REG_SBI0097B());
        /*"01         REG-SBI0097B.*/
        public BI0097B_REG_SBI0097B REG_SBI0097B { get; set; } = new BI0097B_REG_SBI0097B();
        public class BI0097B_REG_SBI0097B : VarBasis
        {
            /*"    05     SOR-NUMAPOL           PIC  9(013).*/
            public IntBasis SOR_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05     SOR-DTVENCTO          PIC  X(010).*/
            public StringBasis SOR_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05     SOR-QTDE              PIC  9(004).*/
            public IntBasis SOR_QTDE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COUNT                PIC S9(004)     COMP.*/
        public IntBasis VIND_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-COUNT              PIC S9(015)     VALUE +0 COMP-3.*/
        public IntBasis WSHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WSHOST-DATA030            PIC  X(010).*/
        public StringBasis WSHOST_DATA030 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    VIND-DATA-QUITACAO        PIC S9(004)     COMP.*/
        public IntBasis VIND_DATA_QUITACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W.*/
        public BI0097B_W W { get; set; } = new BI0097B_W();
        public class BI0097B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-SORT                 PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-PARCELAS             PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_PARCELAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-SINISTRO             PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-FOLLOUP              PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_FOLLOUP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-MOVIMENTO              PIC  9(009)         VALUE ZEROS.*/
            public IntBasis LD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  LD-PARCELAS               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis LD_PARCELAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-SINISTRO               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_SINISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-FOLLOUP                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_FOLLOUP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  LD-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-CANCELA                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis AC_CANCELA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-BILHETE                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis AC_BILHETE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-QTDE                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis AC_QTDE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  WS-REATIVA                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis WS_REATIVA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-REATIVA                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis AC_REATIVA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  ATU-NRENDOS               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis ATU_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  ANT-NRENDOS               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis ANT_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  ATU-NUMAPOL               PIC  9(013)         VALUE ZEROS.*/
            public IntBasis ATU_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03  ANT-NUMAPOL               PIC  9(013)         VALUE ZEROS.*/
            public IntBasis ANT_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_BI0097B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI0097B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI0097B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_BI0097B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_BI0097B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI0097B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI0097B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI0097B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI0097B_FILLER_1 : VarBasis
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

                public _REDEF_BI0097B_FILLER_1()
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
            private _REDEF_BI0097B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_BI0097B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_BI0097B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_BI0097B_FILLER_4 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public BI0097B_WTIME_DAYR WTIME_DAYR { get; set; } = new BI0097B_WTIME_DAYR();
                public class BI0097B_WTIME_DAYR : VarBasis
                {
                    /*"      10     WTIME-HORA         PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      10     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     WTIME-MINU         PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      10     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     WTIME-SEGU         PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    05       WTIME-2PT3         PIC  X(001).*/

                    public BI0097B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WTIME-CCSE         PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03         WS-TIME.*/

                public _REDEF_BI0097B_FILLER_4()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public BI0097B_WS_TIME WS_TIME { get; set; } = new BI0097B_WS_TIME();
            public class BI0097B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01          WABEND.*/
            }
        }
        public BI0097B_WABEND WABEND { get; set; } = new BI0097B_WABEND();
        public class BI0097B_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(010) VALUE           ' BI0097B  '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0097B  ");
            /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRMC = '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRMC = ");
            /*"    05      WSQLERRMC           PIC  X(070) VALUE    SPACES.*/
            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.FOLLOUP FOLLOUP { get; set; } = new Dclgens.FOLLOUP();
        public Dclgens.NUMERAES NUMERAES { get; set; } = new Dclgens.NUMERAES();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public BI0097B_V0ENDOSSO V0ENDOSSO { get; set; } = new BI0097B_V0ENDOSSO();
        public BI0097B_C0PARCEHIS C0PARCEHIS { get; set; } = new BI0097B_C0PARCEHIS();
        public BI0097B_C0PARCELAS C0PARCELAS { get; set; } = new BI0097B_C0PARCELAS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SBI0097B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SBI0097B.SetFile(SBI0097B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -179- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -187- SORT SBI0097B ON ASCENDING KEY SOR-NUMAPOL INPUT PROCEDURE R0200-00-SELECIONA THRU R0200-99-SAIDA OUTPUT PROCEDURE R1000-00-PROCESSA-SORT THRU R1000-99-SAIDA. */
            SBI0097B.Sort("SOR-NUMAPOL", () => R0200_00_SELECIONA_SECTION(), () => R1000_00_PROCESSA_SORT_SECTION());

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -192- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -197- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -198- DISPLAY ' ' . */
            _.Display($" ");

            /*" -199- DISPLAY 'BI0097B - FIM NORMAL' . */
            _.Display($"BI0097B - FIM NORMAL");

            /*" -202- DISPLAY ' ' . */
            _.Display($" ");

            /*" -202- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -208- DISPLAY ' ' */
            _.Display($" ");

            /*" -210- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -218- DISPLAY 'PROGRAMA BI0097B-' 'VERSAO V.02 - DEMANDA 259990 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA BI0097B-VERSAO V.02 - DEMANDA 259990 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -220- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -221- DISPLAY ' ' */
            _.Display($" ");

            /*" -223- DISPLAY 'INICIO PROGRAMA BI0097B ' FUNCTION CURRENT-DATE */
            _.Display($"INICIO PROGRAMA BI0097B {_.CurrentDate()}");

            /*" -225- DISPLAY ' ' . */
            _.Display($" ");

            /*" -228- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -228- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -240- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -247- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -251- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -252- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -255- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -256- DISPLAY ' ' . */
            _.Display($" ");

            /*" -258- DISPLAY 'DATA SISTEMA BI ................ ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA SISTEMA BI ................ {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -258- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -247- EXEC SQL SELECT DATA_MOV_ABERTO ,(DATA_MOV_ABERTO - 30 DAYS) INTO :SISTEMAS-DATA-MOV-ABERTO ,:WSHOST-DATA030 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WSHOST_DATA030, WSHOST_DATA030);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECIONA-SECTION */
        private void R0200_00_SELECIONA_SECTION()
        {
            /*" -271- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -272- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -273- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -274- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -275- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -276- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -277- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -278- DISPLAY 'INICIO LEITURA ENDOSSO         ' WTIME-DAYR. */
            _.Display($"INICIO LEITURA ENDOSSO         {W.FILLER_4.WTIME_DAYR}");

            /*" -281- DISPLAY ' ' . */
            _.Display($" ");

            /*" -283- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -285- PERFORM R0210-00-DECLARE-ENDOSSOS. */

            R0210_00_DECLARE_ENDOSSOS_SECTION();

            /*" -287- PERFORM R0220-00-FETCH-ENDOSSOS. */

            R0220_00_FETCH_ENDOSSOS_SECTION();

            /*" -291- PERFORM R0250-00-PROCESSA-ENDOSSOS UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0250_00_PROCESSA_ENDOSSOS_SECTION();
            }

            /*" -292- DISPLAY ' ' */
            _.Display($" ");

            /*" -293- DISPLAY 'LIDOS ENDOSSOS ............ ' LD-MOVIMENTO */
            _.Display($"LIDOS ENDOSSOS ............ {W.LD_MOVIMENTO}");

            /*" -294- DISPLAY ' ' . */
            _.Display($" ");

            /*" -295- DISPLAY 'APOLICE COM SINISTRO ...... ' DP-SINISTRO */
            _.Display($"APOLICE COM SINISTRO ...... {W.DP_SINISTRO}");

            /*" -296- DISPLAY 'APOLICE COM CREDITO  ...... ' DP-FOLLOUP */
            _.Display($"APOLICE COM CREDITO  ...... {W.DP_FOLLOUP}");

            /*" -297- DISPLAY ' ' . */
            _.Display($" ");

            /*" -298- DISPLAY 'GRAVADOS SORT ............. ' GV-SORT */
            _.Display($"GRAVADOS SORT ............. {W.GV_SORT}");

            /*" -301- DISPLAY ' ' . */
            _.Display($" ");

            /*" -301- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-DECLARE-ENDOSSOS-SECTION */
        private void R0210_00_DECLARE_ENDOSSOS_SECTION()
        {
            /*" -314- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", WABEND.WNR_EXEC_SQL);

            /*" -339- PERFORM R0210_00_DECLARE_ENDOSSOS_DB_DECLARE_1 */

            R0210_00_DECLARE_ENDOSSOS_DB_DECLARE_1();

            /*" -341- PERFORM R0210_00_DECLARE_ENDOSSOS_DB_OPEN_1 */

            R0210_00_DECLARE_ENDOSSOS_DB_OPEN_1();

            /*" -345- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -346- DISPLAY 'R0210-00 - PROBLEMAS DECLARE (ENDOSSOS)   ' */
                _.Display($"R0210-00 - PROBLEMAS DECLARE (ENDOSSOS)   ");

                /*" -346- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0210-00-DECLARE-ENDOSSOS-DB-DECLARE-1 */
        public void R0210_00_DECLARE_ENDOSSOS_DB_DECLARE_1()
        {
            /*" -339- EXEC SQL DECLARE V0ENDOSSO CURSOR WITH HOLD FOR SELECT A.NUM_APOLICE ,COUNT(*) ,MAX(C.DATA_VENCIMENTO) FROM SEGUROS.ENDOSSOS A ,SEGUROS.PARCELAS B ,SEGUROS.PARCELA_HISTORICO C WHERE (A.COD_PRODUTO IN ( 3704,3710,8114,8115,8116,8117,8118,8119,8120,8121,8122,8123) OR A.COD_PRODUTO IN ( :JVPRD8114, :JVPRD8115, :JVPRD8116, :JVPRD8117, :JVPRD8118, :JVPRD8119, :JVPRD8120, :JVPRD8121, :JVPRD8122, :JVPRD8123)) AND A.TIPO_ENDOSSO IN ( '0' , '1' ) AND A.NUM_ENDOSSO <> 0 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.SIT_REGISTRO = '0' AND C.NUM_APOLICE = B.NUM_APOLICE AND C.NUM_ENDOSSO = B.NUM_ENDOSSO AND C.NUM_PARCELA = B.NUM_PARCELA AND C.OCORR_HISTORICO = B.OCORR_HISTORICO GROUP BY A.NUM_APOLICE HAVING COUNT(*) > 2 END-EXEC. */
            V0ENDOSSO = new BI0097B_V0ENDOSSO(true);
            string GetQuery_V0ENDOSSO()
            {
                var query = @$"SELECT A.NUM_APOLICE 
							,COUNT(*) 
							,MAX(C.DATA_VENCIMENTO) 
							FROM SEGUROS.ENDOSSOS A 
							,SEGUROS.PARCELAS B 
							,SEGUROS.PARCELA_HISTORICO C 
							WHERE (A.COD_PRODUTO IN ( 
							3704
							,3710
							,8114
							,8115
							,8116
							,8117
							,8118
							,8119
							,8120
							,8121
							,8122
							,8123) 
							OR A.COD_PRODUTO IN ( 
							'{JVBKINCL.JV_PRODUTOS.JVPRD8114}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8115}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8116}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD8117}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8118}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8119}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8120}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD8121}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8122}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8123}')) 
							AND A.TIPO_ENDOSSO IN ( '0'
							, '1' ) 
							AND A.NUM_ENDOSSO <> 0 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND B.SIT_REGISTRO = '0' 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.NUM_ENDOSSO = B.NUM_ENDOSSO 
							AND C.NUM_PARCELA = B.NUM_PARCELA 
							AND C.OCORR_HISTORICO = B.OCORR_HISTORICO 
							GROUP BY A.NUM_APOLICE 
							HAVING COUNT(*) > 2";

                return query;
            }
            V0ENDOSSO.GetQueryEvent += GetQuery_V0ENDOSSO;

        }

        [StopWatch]
        /*" R0210-00-DECLARE-ENDOSSOS-DB-OPEN-1 */
        public void R0210_00_DECLARE_ENDOSSOS_DB_OPEN_1()
        {
            /*" -341- EXEC SQL OPEN V0ENDOSSO END-EXEC. */

            V0ENDOSSO.Open();

        }

        [StopWatch]
        /*" R1300-00-DECLARE-PARCELAS-DB-DECLARE-1 */
        public void R1300_00_DECLARE_PARCELAS_DB_DECLARE_1()
        {
            /*" -680- EXEC SQL DECLARE C0PARCEHIS CURSOR FOR SELECT A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA FROM SEGUROS.PARCELA_HISTORICO A ,SEGUROS.PARCELAS B ,SEGUROS.ENDOSSOS C WHERE A.NUM_APOLICE = :APOLICES-NUM-APOLICE AND A.NUM_ENDOSSO <> 0 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_PARCELA = A.NUM_PARCELA AND B.OCORR_HISTORICO = A.OCORR_HISTORICO AND B.SIT_REGISTRO = '0' AND C.NUM_APOLICE = A.NUM_APOLICE AND C.NUM_ENDOSSO = A.NUM_ENDOSSO AND C.TIPO_ENDOSSO IN ( '0' , '1' ) ORDER BY A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA END-EXEC. */
            C0PARCEHIS = new BI0097B_C0PARCEHIS(true);
            string GetQuery_C0PARCEHIS()
            {
                var query = @$"SELECT 
							A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_PARCELA 
							FROM 
							SEGUROS.PARCELA_HISTORICO A 
							,SEGUROS.PARCELAS B 
							,SEGUROS.ENDOSSOS C 
							WHERE A.NUM_APOLICE = '{APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}' 
							AND A.NUM_ENDOSSO <> 0 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND B.NUM_PARCELA = A.NUM_PARCELA 
							AND B.OCORR_HISTORICO = A.OCORR_HISTORICO 
							AND B.SIT_REGISTRO = '0' 
							AND C.NUM_APOLICE = A.NUM_APOLICE 
							AND C.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND C.TIPO_ENDOSSO IN ( '0'
							, '1' ) 
							ORDER BY 
							A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_PARCELA";

                return query;
            }
            C0PARCEHIS.GetQueryEvent += GetQuery_C0PARCEHIS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-FETCH-ENDOSSOS-SECTION */
        private void R0220_00_FETCH_ENDOSSOS_SECTION()
        {
            /*" -359- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", WABEND.WNR_EXEC_SQL);

            /*" -363- PERFORM R0220_00_FETCH_ENDOSSOS_DB_FETCH_1 */

            R0220_00_FETCH_ENDOSSOS_DB_FETCH_1();

            /*" -367- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -367- PERFORM R0220_00_FETCH_ENDOSSOS_DB_CLOSE_1 */

                R0220_00_FETCH_ENDOSSOS_DB_CLOSE_1();

                /*" -369- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -371- GO TO R0220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -372- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -373- DISPLAY 'R0220-00 - PROBLEMAS FETCH   (ENDOSSOS)   ' */
                _.Display($"R0220-00 - PROBLEMAS FETCH   (ENDOSSOS)   ");

                /*" -376- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -377- IF VIND-COUNT LESS ZEROS */

            if (VIND_COUNT < 00)
            {

                /*" -381- MOVE ZEROS TO WSHOST-COUNT. */
                _.Move(0, WSHOST_COUNT);
            }


            /*" -383- ADD 1 TO LD-MOVIMENTO. */
            W.LD_MOVIMENTO.Value = W.LD_MOVIMENTO + 1;

            /*" -385- MOVE LD-MOVIMENTO TO AC-LIDOS. */
            _.Move(W.LD_MOVIMENTO, W.AC_LIDOS);

            /*" -387- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -388- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -389- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -390- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -391- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -392- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -393- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -394- DISPLAY 'LIDOS ENDOSSOS     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS ENDOSSOS     {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0220-00-FETCH-ENDOSSOS-DB-FETCH-1 */
        public void R0220_00_FETCH_ENDOSSOS_DB_FETCH_1()
        {
            /*" -363- EXEC SQL FETCH V0ENDOSSO INTO :ENDOSSOS-NUM-APOLICE ,:WSHOST-COUNT:VIND-COUNT ,:PARCEHIS-DATA-VENCIMENTO END-EXEC. */

            if (V0ENDOSSO.Fetch())
            {
                _.Move(V0ENDOSSO.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(V0ENDOSSO.WSHOST_COUNT, WSHOST_COUNT);
                _.Move(V0ENDOSSO.VIND_COUNT, VIND_COUNT);
                _.Move(V0ENDOSSO.PARCEHIS_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);
            }

        }

        [StopWatch]
        /*" R0220-00-FETCH-ENDOSSOS-DB-CLOSE-1 */
        public void R0220_00_FETCH_ENDOSSOS_DB_CLOSE_1()
        {
            /*" -367- EXEC SQL CLOSE V0ENDOSSO END-EXEC */

            V0ENDOSSO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-PROCESSA-ENDOSSOS-SECTION */
        private void R0250_00_PROCESSA_ENDOSSOS_SECTION()
        {
            /*" -410- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", WABEND.WNR_EXEC_SQL);

            /*" -412- MOVE SPACES TO WTEM-SINISTRO. */
            _.Move("", W.WTEM_SINISTRO);

            /*" -414- PERFORM R0260-00-SELECT-V0SINISMES. */

            R0260_00_SELECT_V0SINISMES_SECTION();

            /*" -415- IF WTEM-SINISTRO EQUAL 'S' */

            if (W.WTEM_SINISTRO == "S")
            {

                /*" -416- ADD 1 TO DP-SINISTRO */
                W.DP_SINISTRO.Value = W.DP_SINISTRO + 1;

                /*" -422- GO TO R0250-90-LEITURA. */

                R0250_90_LEITURA(); //GOTO
                return;
            }


            /*" -424- MOVE SPACES TO WTEM-FOLLOUP. */
            _.Move("", W.WTEM_FOLLOUP);

            /*" -426- PERFORM R0280-00-SELECT-V0FOLLOUP. */

            R0280_00_SELECT_V0FOLLOUP_SECTION();

            /*" -427- IF WTEM-FOLLOUP EQUAL 'S' */

            if (W.WTEM_FOLLOUP == "S")
            {

                /*" -428- ADD 1 TO DP-FOLLOUP */
                W.DP_FOLLOUP.Value = W.DP_FOLLOUP + 1;

                /*" -431- GO TO R0250-90-LEITURA. */

                R0250_90_LEITURA(); //GOTO
                return;
            }


            /*" -432- MOVE SPACES TO REG-SBI0097B. */
            _.Move("", REG_SBI0097B);

            /*" -434- MOVE ENDOSSOS-NUM-APOLICE TO SOR-NUMAPOL. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, REG_SBI0097B.SOR_NUMAPOL);

            /*" -436- MOVE WSHOST-COUNT TO SOR-QTDE. */
            _.Move(WSHOST_COUNT, REG_SBI0097B.SOR_QTDE);

            /*" -440- MOVE PARCEHIS-DATA-VENCIMENTO TO SOR-DTVENCTO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO, REG_SBI0097B.SOR_DTVENCTO);

            /*" -441- RELEASE REG-SBI0097B. */
            SBI0097B.Release(REG_SBI0097B);

            /*" -441- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R0250_90_LEITURA */

            R0250_90_LEITURA();

        }

        [StopWatch]
        /*" R0250-90-LEITURA */
        private void R0250_90_LEITURA(bool isPerform = false)
        {
            /*" -446- PERFORM R0220-00-FETCH-ENDOSSOS. */

            R0220_00_FETCH_ENDOSSOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-SELECT-V0SINISMES-SECTION */
        private void R0260_00_SELECT_V0SINISMES_SECTION()
        {
            /*" -458- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", WABEND.WNR_EXEC_SQL);

            /*" -466- PERFORM R0260_00_SELECT_V0SINISMES_DB_SELECT_1 */

            R0260_00_SELECT_V0SINISMES_DB_SELECT_1();

            /*" -470- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -471- MOVE 'N' TO WTEM-SINISTRO */
                _.Move("N", W.WTEM_SINISTRO);

                /*" -472- ELSE */
            }
            else
            {


                /*" -473- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -474- DISPLAY 'R0260-00 - PROBLEMAS NO SELECT(SINISMES)' */
                    _.Display($"R0260-00 - PROBLEMAS NO SELECT(SINISMES)");

                    /*" -475- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -476- ELSE */
                }
                else
                {


                    /*" -476- MOVE 'S' TO WTEM-SINISTRO. */
                    _.Move("S", W.WTEM_SINISTRO);
                }

            }


        }

        [StopWatch]
        /*" R0260-00-SELECT-V0SINISMES-DB-SELECT-1 */
        public void R0260_00_SELECT_V0SINISMES_DB_SELECT_1()
        {
            /*" -466- EXEC SQL SELECT NUM_APOLICE INTO :SINISMES-NUM-APOLICE FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND SIT_REGISTRO = '0' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0260_00_SELECT_V0SINISMES_DB_SELECT_1_Query1 = new R0260_00_SELECT_V0SINISMES_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0260_00_SELECT_V0SINISMES_DB_SELECT_1_Query1.Execute(r0260_00_SELECT_V0SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0280-00-SELECT-V0FOLLOUP-SECTION */
        private void R0280_00_SELECT_V0FOLLOUP_SECTION()
        {
            /*" -489- MOVE '0280' TO WNR-EXEC-SQL. */
            _.Move("0280", WABEND.WNR_EXEC_SQL);

            /*" -497- PERFORM R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1 */

            R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1();

            /*" -501- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -502- MOVE 'N' TO WTEM-FOLLOUP */
                _.Move("N", W.WTEM_FOLLOUP);

                /*" -503- ELSE */
            }
            else
            {


                /*" -504- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -505- DISPLAY 'R0280-00 - PROBLEMAS NO SELECT(FOLLOUP)' */
                    _.Display($"R0280-00 - PROBLEMAS NO SELECT(FOLLOUP)");

                    /*" -506- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -507- ELSE */
                }
                else
                {


                    /*" -507- MOVE 'S' TO WTEM-FOLLOUP. */
                    _.Move("S", W.WTEM_FOLLOUP);
                }

            }


        }

        [StopWatch]
        /*" R0280-00-SELECT-V0FOLLOUP-DB-SELECT-1 */
        public void R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1()
        {
            /*" -497- EXEC SQL SELECT NUM_APOLICE INTO :FOLLOUP-NUM-APOLICE FROM SEGUROS.FOLLOW_UP WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND SIT_REGISTRO = '0' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1 = new R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1.Execute(r0280_00_SELECT_V0FOLLOUP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FOLLOUP_NUM_APOLICE, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0280_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SORT-SECTION */
        private void R1000_00_PROCESSA_SORT_SECTION()
        {
            /*" -520- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -521- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -523- PERFORM R1010-00-LER-SORT. */

            R1010_00_LER_SORT_SECTION();

            /*" -524- IF WFIM-SORT NOT EQUAL SPACES */

            if (!W.WFIM_SORT.IsEmpty())
            {

                /*" -527- GO TO R1000-90-DISPLAY. */

                R1000_90_DISPLAY(); //GOTO
                return;
            }


            /*" -528- PERFORM R1050-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R1050_00_PROCESSA_SORT_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R1000_90_DISPLAY */

            R1000_90_DISPLAY();

        }

        [StopWatch]
        /*" R1000-90-DISPLAY */
        private void R1000_90_DISPLAY(bool isPerform = false)
        {
            /*" -534- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -538- DISPLAY ' ' . */
            _.Display($" ");

            /*" -539- DISPLAY 'LIDOS SORT ................ ' LD-SORT */
            _.Display($"LIDOS SORT ................ {W.LD_SORT}");

            /*" -540- DISPLAY 'DESPREZA SORT ............. ' DP-SORT */
            _.Display($"DESPREZA SORT ............. {W.DP_SORT}");

            /*" -541- DISPLAY 'BILHETES CANCELADOS ....... ' AC-BILHETE */
            _.Display($"BILHETES CANCELADOS ....... {W.AC_BILHETE}");

            /*" -542- DISPLAY 'PARCELAS CANCELADAS ....... ' AC-CANCELA */
            _.Display($"PARCELAS CANCELADAS ....... {W.AC_CANCELA}");

            /*" -542- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-LER-SORT-SECTION */
        private void R1010_00_LER_SORT_SECTION()
        {
            /*" -555- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", WABEND.WNR_EXEC_SQL);

            /*" -557- RETURN SBI0097B AT END */
            try
            {
                SBI0097B.Return(REG_SBI0097B, () =>
                {

                    /*" -558- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -561- GO TO R1010-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -564- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

            /*" -566- MOVE LD-SORT TO AC-LIDOS. */
            _.Move(W.LD_SORT, W.AC_LIDOS);

            /*" -568- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -569- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -570- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -571- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -572- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -573- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -574- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -575- DISPLAY 'LIDOS SORT         ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS SORT         {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-PROCESSA-SORT-SECTION */
        private void R1050_00_PROCESSA_SORT_SECTION()
        {
            /*" -587- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", WABEND.WNR_EXEC_SQL);

            /*" -589- IF SOR-DTVENCTO GREATER WSHOST-DATA030 AND SOR-QTDE EQUAL 03 */

            if (REG_SBI0097B.SOR_DTVENCTO > WSHOST_DATA030 && REG_SBI0097B.SOR_QTDE == 03)
            {

                /*" -590- ADD 1 TO DP-SORT */
                W.DP_SORT.Value = W.DP_SORT + 1;

                /*" -593- GO TO R1050-90-LEITURA. */

                R1050_90_LEITURA(); //GOTO
                return;
            }


            /*" -595- MOVE SOR-NUMAPOL TO APOLICES-NUM-APOLICE. */
            _.Move(REG_SBI0097B.SOR_NUMAPOL, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -598- PERFORM R1090-00-SELECT-APOLICES. */

            R1090_00_SELECT_APOLICES_SECTION();

            /*" -601- MOVE ZEROS TO AC-QTDE ATU-NRENDOS ANT-NRENDOS. */
            _.Move(0, W.AC_QTDE, W.ATU_NRENDOS, W.ANT_NRENDOS);

            /*" -603- MOVE SPACES TO WFIM-PARCELAS. */
            _.Move("", W.WFIM_PARCELAS);

            /*" -605- PERFORM R1300-00-DECLARE-PARCELAS. */

            R1300_00_DECLARE_PARCELAS_SECTION();

            /*" -607- PERFORM R1310-00-FETCH-PARCELAS. */

            R1310_00_FETCH_PARCELAS_SECTION();

            /*" -611- PERFORM R1500-00-PROCESSA-PARCELAS UNTIL WFIM-PARCELAS NOT EQUAL SPACES. */

            while (!(!W.WFIM_PARCELAS.IsEmpty()))
            {

                R1500_00_PROCESSA_PARCELAS_SECTION();
            }

            /*" -612- IF AC-QTDE GREATER 2 */

            if (W.AC_QTDE > 2)
            {

                /*" -612- PERFORM R2000-00-ROTINA-CANCELA. */

                R2000_00_ROTINA_CANCELA_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R1050_90_LEITURA */

            R1050_90_LEITURA();

        }

        [StopWatch]
        /*" R1050-90-LEITURA */
        private void R1050_90_LEITURA(bool isPerform = false)
        {
            /*" -617- PERFORM R1010-00-LER-SORT. */

            R1010_00_LER_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1090-00-SELECT-APOLICES-SECTION */
        private void R1090_00_SELECT_APOLICES_SECTION()
        {
            /*" -628- MOVE '1090' TO WNR-EXEC-SQL. */
            _.Move("1090", WABEND.WNR_EXEC_SQL);

            /*" -640- PERFORM R1090_00_SELECT_APOLICES_DB_SELECT_1 */

            R1090_00_SELECT_APOLICES_DB_SELECT_1();

            /*" -643- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -644- DISPLAY 'R1090-00 - PROBLEMAS NO SELECT(APOLICES)' */
                _.Display($"R1090-00 - PROBLEMAS NO SELECT(APOLICES)");

                /*" -645- DISPLAY 'APOLICE = ' APOLICES-NUM-APOLICE */
                _.Display($"APOLICE = {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -645- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1090-00-SELECT-APOLICES-DB-SELECT-1 */
        public void R1090_00_SELECT_APOLICES_DB_SELECT_1()
        {
            /*" -640- EXEC SQL SELECT ORGAO_EMISSOR ,RAMO_EMISSOR ,NUM_BILHETE INTO :APOLICES-ORGAO-EMISSOR ,:APOLICES-RAMO-EMISSOR ,:APOLICES-NUM-BILHETE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE END-EXEC. */

            var r1090_00_SELECT_APOLICES_DB_SELECT_1_Query1 = new R1090_00_SELECT_APOLICES_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1090_00_SELECT_APOLICES_DB_SELECT_1_Query1.Execute(r1090_00_SELECT_APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
                _.Move(executed_1.APOLICES_NUM_BILHETE, APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1090_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-DECLARE-PARCELAS-SECTION */
        private void R1300_00_DECLARE_PARCELAS_SECTION()
        {
            /*" -657- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -680- PERFORM R1300_00_DECLARE_PARCELAS_DB_DECLARE_1 */

            R1300_00_DECLARE_PARCELAS_DB_DECLARE_1();

            /*" -682- PERFORM R1300_00_DECLARE_PARCELAS_DB_OPEN_1 */

            R1300_00_DECLARE_PARCELAS_DB_OPEN_1();

            /*" -685- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -686- DISPLAY 'R1300 - ERRO DECLARE PARCELA_HISTORICO/PARCELAS' */
                _.Display($"R1300 - ERRO DECLARE PARCELA_HISTORICO/PARCELAS");

                /*" -687- DISPLAY 'APOLICE = ' APOLICES-NUM-APOLICE */
                _.Display($"APOLICE = {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -687- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-DECLARE-PARCELAS-DB-OPEN-1 */
        public void R1300_00_DECLARE_PARCELAS_DB_OPEN_1()
        {
            /*" -682- EXEC SQL OPEN C0PARCEHIS END-EXEC. */

            C0PARCEHIS.Open();

        }

        [StopWatch]
        /*" R2300-00-DECLARE-PARCELAS-DB-DECLARE-1 */
        public void R2300_00_DECLARE_PARCELAS_DB_DECLARE_1()
        {
            /*" -899- EXEC SQL DECLARE C0PARCELAS CURSOR FOR SELECT A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA ,A.DAC_PARCELA ,A.OCORR_HISTORICO ,A.PRM_TARIFARIO ,A.VAL_DESCONTO ,A.PRM_LIQUIDO ,A.ADICIONAL_FRACIO ,A.VAL_CUSTO_EMISSAO ,A.VAL_IOCC ,A.PRM_TOTAL ,A.DATA_VENCIMENTO ,A.BCO_COBRANCA ,A.AGE_COBRANCA FROM SEGUROS.PARCELA_HISTORICO A ,SEGUROS.PARCELAS B ,SEGUROS.ENDOSSOS C WHERE A.NUM_APOLICE = :APOLICES-NUM-APOLICE AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_PARCELA = A.NUM_PARCELA AND B.OCORR_HISTORICO = A.OCORR_HISTORICO AND B.SIT_REGISTRO = '0' AND C.NUM_APOLICE = A.NUM_APOLICE AND C.NUM_ENDOSSO = A.NUM_ENDOSSO AND C.TIPO_ENDOSSO IN ( '0' , '1' ) ORDER BY A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA END-EXEC. */
            C0PARCELAS = new BI0097B_C0PARCELAS(true);
            string GetQuery_C0PARCELAS()
            {
                var query = @$"SELECT 
							A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_PARCELA 
							,A.DAC_PARCELA 
							,A.OCORR_HISTORICO 
							,A.PRM_TARIFARIO 
							,A.VAL_DESCONTO 
							,A.PRM_LIQUIDO 
							,A.ADICIONAL_FRACIO 
							,A.VAL_CUSTO_EMISSAO 
							,A.VAL_IOCC 
							,A.PRM_TOTAL 
							,A.DATA_VENCIMENTO 
							,A.BCO_COBRANCA 
							,A.AGE_COBRANCA 
							FROM 
							SEGUROS.PARCELA_HISTORICO A 
							,SEGUROS.PARCELAS B 
							,SEGUROS.ENDOSSOS C 
							WHERE 
							A.NUM_APOLICE = '{APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND B.NUM_PARCELA = A.NUM_PARCELA 
							AND B.OCORR_HISTORICO = A.OCORR_HISTORICO 
							AND B.SIT_REGISTRO = '0' 
							AND C.NUM_APOLICE = A.NUM_APOLICE 
							AND C.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND C.TIPO_ENDOSSO IN ( '0'
							, '1' ) 
							ORDER BY 
							A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_PARCELA";

                return query;
            }
            C0PARCELAS.GetQueryEvent += GetQuery_C0PARCELAS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1310-00-FETCH-PARCELAS-SECTION */
        private void R1310_00_FETCH_PARCELAS_SECTION()
        {
            /*" -699- MOVE '1310' TO WNR-EXEC-SQL. */
            _.Move("1310", WABEND.WNR_EXEC_SQL);

            /*" -704- PERFORM R1310_00_FETCH_PARCELAS_DB_FETCH_1 */

            R1310_00_FETCH_PARCELAS_DB_FETCH_1();

            /*" -708- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -709- MOVE 'S' TO WFIM-PARCELAS */
                _.Move("S", W.WFIM_PARCELAS);

                /*" -709- PERFORM R1310_00_FETCH_PARCELAS_DB_CLOSE_1 */

                R1310_00_FETCH_PARCELAS_DB_CLOSE_1();

                /*" -713- GO TO R1310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -714- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -715- DISPLAY 'R1310 - ERRO FETCH CURSOR C0PARCELAS' */
                _.Display($"R1310 - ERRO FETCH CURSOR C0PARCELAS");

                /*" -716- DISPLAY 'APOLICE = ' APOLICES-NUM-APOLICE */
                _.Display($"APOLICE = {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -719- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -720- MOVE PARCEHIS-NUM-ENDOSSO TO ATU-NRENDOS. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, W.ATU_NRENDOS);

        }

        [StopWatch]
        /*" R1310-00-FETCH-PARCELAS-DB-FETCH-1 */
        public void R1310_00_FETCH_PARCELAS_DB_FETCH_1()
        {
            /*" -704- EXEC SQL FETCH C0PARCEHIS INTO :PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA END-EXEC. */

            if (C0PARCEHIS.Fetch())
            {
                _.Move(C0PARCEHIS.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(C0PARCEHIS.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(C0PARCEHIS.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
            }

        }

        [StopWatch]
        /*" R1310-00-FETCH-PARCELAS-DB-CLOSE-1 */
        public void R1310_00_FETCH_PARCELAS_DB_CLOSE_1()
        {
            /*" -709- EXEC SQL CLOSE C0PARCEHIS END-EXEC */

            C0PARCEHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1310_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-PROCESSA-PARCELAS-SECTION */
        private void R1500_00_PROCESSA_PARCELAS_SECTION()
        {
            /*" -733- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -734- IF AC-QTDE EQUAL ZEROS */

            if (W.AC_QTDE == 00)
            {

                /*" -735- MOVE ATU-NRENDOS TO ANT-NRENDOS */
                _.Move(W.ATU_NRENDOS, W.ANT_NRENDOS);

                /*" -737- ADD 1 TO ANT-NRENDOS AC-QTDE */
                W.ANT_NRENDOS.Value = W.ANT_NRENDOS + 1;
                W.AC_QTDE.Value = W.AC_QTDE + 1;

                /*" -740- GO TO R1500-90-LEITURA. */

                R1500_90_LEITURA(); //GOTO
                return;
            }


            /*" -741- IF ATU-NRENDOS EQUAL ANT-NRENDOS */

            if (W.ATU_NRENDOS == W.ANT_NRENDOS)
            {

                /*" -743- ADD 1 TO ANT-NRENDOS AC-QTDE */
                W.ANT_NRENDOS.Value = W.ANT_NRENDOS + 1;
                W.AC_QTDE.Value = W.AC_QTDE + 1;

                /*" -744- ELSE */
            }
            else
            {


                /*" -745- MOVE ATU-NRENDOS TO ANT-NRENDOS */
                _.Move(W.ATU_NRENDOS, W.ANT_NRENDOS);

                /*" -746- ADD 1 TO ANT-NRENDOS */
                W.ANT_NRENDOS.Value = W.ANT_NRENDOS + 1;

                /*" -749- MOVE 1 TO AC-QTDE. */
                _.Move(1, W.AC_QTDE);
            }


            /*" -750- IF AC-QTDE GREATER 2 */

            if (W.AC_QTDE > 2)
            {

                /*" -751- MOVE 'S' TO WFIM-PARCELAS */
                _.Move("S", W.WFIM_PARCELAS);

                /*" -751- PERFORM R1500_00_PROCESSA_PARCELAS_DB_CLOSE_1 */

                R1500_00_PROCESSA_PARCELAS_DB_CLOSE_1();

                /*" -752- GO TO R1500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1500_90_LEITURA */

            R1500_90_LEITURA();

        }

        [StopWatch]
        /*" R1500-00-PROCESSA-PARCELAS-DB-CLOSE-1 */
        public void R1500_00_PROCESSA_PARCELAS_DB_CLOSE_1()
        {
            /*" -751- EXEC SQL CLOSE C0PARCEHIS END-EXEC */

            C0PARCEHIS.Close();

        }

        [StopWatch]
        /*" R1500-90-LEITURA */
        private void R1500_90_LEITURA(bool isPerform = false)
        {
            /*" -757- PERFORM R1310-00-FETCH-PARCELAS. */

            R1310_00_FETCH_PARCELAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-ROTINA-CANCELA-SECTION */
        private void R2000_00_ROTINA_CANCELA_SECTION()
        {
            /*" -769- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -770- PERFORM R2100-00-SELECT-NUMERO-AES. */

            R2100_00_SELECT_NUMERO_AES_SECTION();

            /*" -772- ADD 1 TO NUMERAES-ENDOS-CANCELA. */
            NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA.Value = NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA + 1;

            /*" -775- PERFORM R2200-00-UPDATE-NUMERO-AES. */

            R2200_00_UPDATE_NUMERO_AES_SECTION();

            /*" -777- MOVE SPACES TO WFIM-PARCELAS. */
            _.Move("", W.WFIM_PARCELAS);

            /*" -779- PERFORM R2300-00-DECLARE-PARCELAS. */

            R2300_00_DECLARE_PARCELAS_SECTION();

            /*" -781- PERFORM R2310-00-FETCH-PARCELAS. */

            R2310_00_FETCH_PARCELAS_SECTION();

            /*" -788- PERFORM R2500-00-PROCESSA-PARCELAS UNTIL WFIM-PARCELAS NOT EQUAL SPACES. */

            while (!(!W.WFIM_PARCELAS.IsEmpty()))
            {

                R2500_00_PROCESSA_PARCELAS_SECTION();
            }

            /*" -790- MOVE 'P' TO BILHETE-SITUACAO. */
            _.Move("P", BILHETE.DCLBILHETE.BILHETE_SITUACAO);

            /*" -792- MOVE '0' TO BILHETE-TIP-CANCELAMENTO. */
            _.Move("0", BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO);

            /*" -794- MOVE SISTEMAS-DATA-MOV-ABERTO TO BILHETE-DATA-CANCELAMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO);

            /*" -795- MOVE ZEROS TO VIND-NULL01. */
            _.Move(0, VIND_NULL01);

            /*" -796- PERFORM R4000-00-UPDATE-V0BILHETE. */

            R4000_00_UPDATE_V0BILHETE_SECTION();

            /*" -796- ADD 1 TO AC-BILHETE. */
            W.AC_BILHETE.Value = W.AC_BILHETE + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-NUMERO-AES-SECTION */
        private void R2100_00_SELECT_NUMERO_AES_SECTION()
        {
            /*" -808- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -817- PERFORM R2100_00_SELECT_NUMERO_AES_DB_SELECT_1 */

            R2100_00_SELECT_NUMERO_AES_DB_SELECT_1();

            /*" -820- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -821- DISPLAY 'R2100-00 - PROBLEMAS NO SELECT(NUMEROAES)' */
                _.Display($"R2100-00 - PROBLEMAS NO SELECT(NUMEROAES)");

                /*" -822- DISPLAY 'APOLICE = ' APOLICES-NUM-APOLICE */
                _.Display($"APOLICE = {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -823- DISPLAY 'ORGAO   = ' APOLICES-ORGAO-EMISSOR */
                _.Display($"ORGAO   = {APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR}");

                /*" -824- DISPLAY 'RAMO    = ' APOLICES-RAMO-EMISSOR */
                _.Display($"RAMO    = {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -824- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-NUMERO-AES-DB-SELECT-1 */
        public void R2100_00_SELECT_NUMERO_AES_DB_SELECT_1()
        {
            /*" -817- EXEC SQL SELECT ENDOS_CANCELA INTO :NUMERAES-ENDOS-CANCELA FROM SEGUROS.NUMERO_AES WHERE ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR AND RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR END-EXEC. */

            var r2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 = new R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1()
            {
                APOLICES_ORGAO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMERAES_ENDOS_CANCELA, NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-UPDATE-NUMERO-AES-SECTION */
        private void R2200_00_UPDATE_NUMERO_AES_SECTION()
        {
            /*" -836- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -844- PERFORM R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1 */

            R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1();

            /*" -848- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -849- DISPLAY 'R2200-00 - PROBLEMAS NO UPDATE(NUMEROAES)' */
                _.Display($"R2200-00 - PROBLEMAS NO UPDATE(NUMEROAES)");

                /*" -850- DISPLAY 'APOLICE = ' APOLICES-NUM-APOLICE */
                _.Display($"APOLICE = {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -851- DISPLAY 'ORGAO   = ' APOLICES-ORGAO-EMISSOR */
                _.Display($"ORGAO   = {APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR}");

                /*" -852- DISPLAY 'RAMO    = ' APOLICES-RAMO-EMISSOR */
                _.Display($"RAMO    = {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -852- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-UPDATE-NUMERO-AES-DB-UPDATE-1 */
        public void R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1()
        {
            /*" -844- EXEC SQL UPDATE SEGUROS.NUMERO_AES SET ENDOS_CANCELA = :NUMERAES-ENDOS-CANCELA, TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR AND RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR END-EXEC. */

            var r2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 = new R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1()
            {
                NUMERAES_ENDOS_CANCELA = NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA.ToString(),
                APOLICES_ORGAO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
            };

            R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1.Execute(r2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-DECLARE-PARCELAS-SECTION */
        private void R2300_00_DECLARE_PARCELAS_SECTION()
        {
            /*" -864- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -899- PERFORM R2300_00_DECLARE_PARCELAS_DB_DECLARE_1 */

            R2300_00_DECLARE_PARCELAS_DB_DECLARE_1();

            /*" -901- PERFORM R2300_00_DECLARE_PARCELAS_DB_OPEN_1 */

            R2300_00_DECLARE_PARCELAS_DB_OPEN_1();

            /*" -904- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -905- DISPLAY 'R2300 - ERRO DECLARE PARCELA_HISTORICO/PARCELAS' */
                _.Display($"R2300 - ERRO DECLARE PARCELA_HISTORICO/PARCELAS");

                /*" -906- DISPLAY 'APOLICE = ' APOLICES-NUM-APOLICE */
                _.Display($"APOLICE = {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -906- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2300-00-DECLARE-PARCELAS-DB-OPEN-1 */
        public void R2300_00_DECLARE_PARCELAS_DB_OPEN_1()
        {
            /*" -901- EXEC SQL OPEN C0PARCELAS END-EXEC. */

            C0PARCELAS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-FETCH-PARCELAS-SECTION */
        private void R2310_00_FETCH_PARCELAS_SECTION()
        {
            /*" -918- MOVE '2310' TO WNR-EXEC-SQL. */
            _.Move("2310", WABEND.WNR_EXEC_SQL);

            /*" -935- PERFORM R2310_00_FETCH_PARCELAS_DB_FETCH_1 */

            R2310_00_FETCH_PARCELAS_DB_FETCH_1();

            /*" -939- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -940- MOVE 'S' TO WFIM-PARCELAS */
                _.Move("S", W.WFIM_PARCELAS);

                /*" -940- PERFORM R2310_00_FETCH_PARCELAS_DB_CLOSE_1 */

                R2310_00_FETCH_PARCELAS_DB_CLOSE_1();

                /*" -944- GO TO R2310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -945- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -946- DISPLAY 'R2310 - ERRO FETCH CURSOR C0PARCELAS' */
                _.Display($"R2310 - ERRO FETCH CURSOR C0PARCELAS");

                /*" -947- DISPLAY 'APOLICE = ' APOLICES-NUM-APOLICE */
                _.Display($"APOLICE = {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -947- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2310-00-FETCH-PARCELAS-DB-FETCH-1 */
        public void R2310_00_FETCH_PARCELAS_DB_FETCH_1()
        {
            /*" -935- EXEC SQL FETCH C0PARCELAS INTO :PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA ,:PARCEHIS-DAC-PARCELA ,:PARCEHIS-OCORR-HISTORICO ,:PARCEHIS-PRM-TARIFARIO ,:PARCEHIS-VAL-DESCONTO ,:PARCEHIS-PRM-LIQUIDO ,:PARCEHIS-ADICIONAL-FRACIO ,:PARCEHIS-VAL-CUSTO-EMISSAO ,:PARCEHIS-VAL-IOCC ,:PARCEHIS-PRM-TOTAL ,:PARCEHIS-DATA-VENCIMENTO ,:PARCEHIS-BCO-COBRANCA ,:PARCEHIS-AGE-COBRANCA END-EXEC. */

            if (C0PARCELAS.Fetch())
            {
                _.Move(C0PARCELAS.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(C0PARCELAS.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(C0PARCELAS.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(C0PARCELAS.PARCEHIS_DAC_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);
                _.Move(C0PARCELAS.PARCEHIS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);
                _.Move(C0PARCELAS.PARCEHIS_PRM_TARIFARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO);
                _.Move(C0PARCELAS.PARCEHIS_VAL_DESCONTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO);
                _.Move(C0PARCELAS.PARCEHIS_PRM_LIQUIDO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO);
                _.Move(C0PARCELAS.PARCEHIS_ADICIONAL_FRACIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);
                _.Move(C0PARCELAS.PARCEHIS_VAL_CUSTO_EMISSAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO);
                _.Move(C0PARCELAS.PARCEHIS_VAL_IOCC, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC);
                _.Move(C0PARCELAS.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);
                _.Move(C0PARCELAS.PARCEHIS_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);
                _.Move(C0PARCELAS.PARCEHIS_BCO_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);
                _.Move(C0PARCELAS.PARCEHIS_AGE_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);
            }

        }

        [StopWatch]
        /*" R2310-00-FETCH-PARCELAS-DB-CLOSE-1 */
        public void R2310_00_FETCH_PARCELAS_DB_CLOSE_1()
        {
            /*" -940- EXEC SQL CLOSE C0PARCELAS END-EXEC */

            C0PARCELAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-PROCESSA-PARCELAS-SECTION */
        private void R2500_00_PROCESSA_PARCELAS_SECTION()
        {
            /*" -960- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -962- PERFORM R2900-00-MONTA-OP-CANC. */

            R2900_00_MONTA_OP_CANC_SECTION();

            /*" -964- PERFORM R3000-00-INSERT-PARCEHIS. */

            R3000_00_INSERT_PARCEHIS_SECTION();

            /*" -965- MOVE '2' TO PARCELAS-SIT-REGISTRO. */
            _.Move("2", PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);

            /*" -967- PERFORM R3100-00-UPDATE-PARCELAS. */

            R3100_00_UPDATE_PARCELAS_SECTION();

            /*" -968- MOVE '2' TO ENDOSSOS-SIT-REGISTRO. */
            _.Move("2", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);

            /*" -968- PERFORM R3200-00-UPDATE-ENDOSSOS. */

            R3200_00_UPDATE_ENDOSSOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R2500_90_LEITURA */

            R2500_90_LEITURA();

        }

        [StopWatch]
        /*" R2500-90-LEITURA */
        private void R2500_90_LEITURA(bool isPerform = false)
        {
            /*" -973- PERFORM R2310-00-FETCH-PARCELAS. */

            R2310_00_FETCH_PARCELAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-MONTA-OP-CANC-SECTION */
        private void R2900_00_MONTA_OP_CANC_SECTION()
        {
            /*" -985- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", WABEND.WNR_EXEC_SQL);

            /*" -987- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -989- MOVE 0401 TO PARCEHIS-COD-OPERACAO. */
            _.Move(0401, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -990- ADD 1 TO PARCEHIS-OCORR-HISTORICO. */
            PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.Value = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO + 1;

            /*" -991- MOVE ZEROS TO PARCEHIS-VAL-OPERACAO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

            /*" -993- MOVE ZEROS TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -995- MOVE NUMERAES-ENDOS-CANCELA TO PARCEHIS-ENDOS-CANCELA. */
            _.Move(NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_CANCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -996- MOVE '0' TO PARCEHIS-SIT-CONTABIL. */
            _.Move("0", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

            /*" -997- MOVE 'BI0097B' TO PARCEHIS-COD-USUARIO. */
            _.Move("BI0097B", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -998- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

            /*" -999- MOVE -1 TO VIND-DATA-QUITACAO. */
            _.Move(-1, VIND_DATA_QUITACAO);

            /*" -1000- MOVE SPACES TO PARCEHIS-DATA-QUITACAO. */
            _.Move("", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -1002- MOVE ZEROS TO PARCEHIS-COD-EMPRESA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);

            /*" -1002- ADD 1 TO AC-CANCELA. */
            W.AC_CANCELA.Value = W.AC_CANCELA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-INSERT-PARCEHIS-SECTION */
        private void R3000_00_INSERT_PARCEHIS_SECTION()
        {
            /*" -1015- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WABEND.WNR_EXEC_SQL);

            /*" -1072- PERFORM R3000_00_INSERT_PARCEHIS_DB_INSERT_1 */

            R3000_00_INSERT_PARCEHIS_DB_INSERT_1();

            /*" -1075- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1076- DISPLAY 'R3000- ERRO INSERT PARCELA_HISTORICO' */
                _.Display($"R3000- ERRO INSERT PARCELA_HISTORICO");

                /*" -1077- DISPLAY 'APOLICE = ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1078- DISPLAY 'ENDOSSO = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1079- DISPLAY 'PARCELA = ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -1079- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3000-00-INSERT-PARCEHIS-DB-INSERT-1 */
        public void R3000_00_INSERT_PARCEHIS_DB_INSERT_1()
        {
            /*" -1072- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO (NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DAC_PARCELA ,DATA_MOVIMENTO ,COD_OPERACAO ,HORA_OPERACAO ,OCORR_HISTORICO ,PRM_TARIFARIO ,VAL_DESCONTO ,PRM_LIQUIDO ,ADICIONAL_FRACIO ,VAL_CUSTO_EMISSAO ,VAL_IOCC ,PRM_TOTAL ,VAL_OPERACAO ,DATA_VENCIMENTO ,BCO_COBRANCA ,AGE_COBRANCA ,NUM_AVISO_CREDITO ,ENDOS_CANCELA ,SIT_CONTABIL ,COD_USUARIO ,RENUM_DOCUMENTO ,DATA_QUITACAO ,COD_EMPRESA ,TIMESTAMP) VALUES (:PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA ,:PARCEHIS-DAC-PARCELA ,:PARCEHIS-DATA-MOVIMENTO ,:PARCEHIS-COD-OPERACAO , CURRENT TIME ,:PARCEHIS-OCORR-HISTORICO ,:PARCEHIS-PRM-TARIFARIO ,:PARCEHIS-VAL-DESCONTO ,:PARCEHIS-PRM-LIQUIDO ,:PARCEHIS-ADICIONAL-FRACIO ,:PARCEHIS-VAL-CUSTO-EMISSAO ,:PARCEHIS-VAL-IOCC ,:PARCEHIS-PRM-TOTAL ,:PARCEHIS-VAL-OPERACAO ,:PARCEHIS-DATA-VENCIMENTO ,:PARCEHIS-BCO-COBRANCA ,:PARCEHIS-AGE-COBRANCA ,:PARCEHIS-NUM-AVISO-CREDITO ,:PARCEHIS-ENDOS-CANCELA ,:PARCEHIS-SIT-CONTABIL ,:PARCEHIS-COD-USUARIO ,:PARCEHIS-RENUM-DOCUMENTO ,:PARCEHIS-DATA-QUITACAO:VIND-DATA-QUITACAO ,:PARCEHIS-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1 = new R3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                PARCEHIS_DAC_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.ToString(),
                PARCEHIS_DATA_MOVIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.ToString(),
                PARCEHIS_COD_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_PRM_TARIFARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO.ToString(),
                PARCEHIS_VAL_DESCONTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO.ToString(),
                PARCEHIS_PRM_LIQUIDO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO.ToString(),
                PARCEHIS_ADICIONAL_FRACIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO.ToString(),
                PARCEHIS_VAL_CUSTO_EMISSAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO.ToString(),
                PARCEHIS_VAL_IOCC = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC.ToString(),
                PARCEHIS_PRM_TOTAL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL.ToString(),
                PARCEHIS_VAL_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.ToString(),
                PARCEHIS_DATA_VENCIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_SIT_CONTABIL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.ToString(),
                PARCEHIS_COD_USUARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.ToString(),
                PARCEHIS_RENUM_DOCUMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.ToString(),
                PARCEHIS_DATA_QUITACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.ToString(),
                VIND_DATA_QUITACAO = VIND_DATA_QUITACAO.ToString(),
                PARCEHIS_COD_EMPRESA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.ToString(),
            };

            R3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1.Execute(r3000_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-UPDATE-PARCELAS-SECTION */
        private void R3100_00_UPDATE_PARCELAS_SECTION()
        {
            /*" -1092- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -1102- PERFORM R3100_00_UPDATE_PARCELAS_DB_UPDATE_1 */

            R3100_00_UPDATE_PARCELAS_DB_UPDATE_1();

            /*" -1105- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1106- DISPLAY 'R3100- ERRO UPDATE PARCELAS' */
                _.Display($"R3100- ERRO UPDATE PARCELAS");

                /*" -1107- DISPLAY 'APOLICE = ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1108- DISPLAY 'ENDOSSO = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1109- DISPLAY 'PARCELA = ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -1109- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-UPDATE-PARCELAS-DB-UPDATE-1 */
        public void R3100_00_UPDATE_PARCELAS_DB_UPDATE_1()
        {
            /*" -1102- EXEC SQL UPDATE SEGUROS.PARCELAS SET OCORR_HISTORICO = :PARCEHIS-OCORR-HISTORICO ,SIT_REGISTRO = :PARCELAS-SIT-REGISTRO ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA END-EXEC. */

            var r3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 = new R3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1()
            {
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCELAS_SIT_REGISTRO = PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            R3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1.Execute(r3100_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-UPDATE-ENDOSSOS-SECTION */
        private void R3200_00_UPDATE_ENDOSSOS_SECTION()
        {
            /*" -1122- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", WABEND.WNR_EXEC_SQL);

            /*" -1130- PERFORM R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1 */

            R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1();

            /*" -1133- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1134- DISPLAY 'R3200- ERRO UPDATE ENDOSSOS' */
                _.Display($"R3200- ERRO UPDATE ENDOSSOS");

                /*" -1135- DISPLAY 'APOLICE = ' ENDOSSOS-NUM-APOLICE */
                _.Display($"APOLICE = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -1136- DISPLAY 'ENDOSSO = ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($"ENDOSSO = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -1136- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3200-00-UPDATE-ENDOSSOS-DB-UPDATE-1 */
        public void R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1()
        {
            /*" -1130- EXEC SQL UPDATE SEGUROS.ENDOSSOS SET SIT_REGISTRO = :ENDOSSOS-SIT-REGISTRO ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO END-EXEC. */

            var r3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 = new R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1()
            {
                ENDOSSOS_SIT_REGISTRO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
            };

            R3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1.Execute(r3200_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-UPDATE-V0BILHETE-SECTION */
        private void R4000_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -1149- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WABEND.WNR_EXEC_SQL);

            /*" -1162- PERFORM R4000_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R4000_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -1166- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1167- DISPLAY 'R4000-00 - PROBLEMAS UPDATE (BILHETE)   ' */
                _.Display($"R4000-00 - PROBLEMAS UPDATE (BILHETE)   ");

                /*" -1167- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4000-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R4000_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -1162- EXEC SQL UPDATE SEGUROS.BILHETE SET SITUACAO = :BILHETE-SITUACAO ,TIP_CANCELAMENTO = :BILHETE-TIP-CANCELAMENTO ,COD_USUARIO = 'BI0097B' ,DATA_CANCELAMENTO = :BILHETE-DATA-CANCELAMENTO:VIND-NULL01 WHERE NUM_BILHETE = :APOLICES-NUM-BILHETE END-EXEC. */

            var r4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                BILHETE_DATA_CANCELAMENTO = BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                BILHETE_TIP_CANCELAMENTO = BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO.ToString(),
                BILHETE_SITUACAO = BILHETE.DCLBILHETE.BILHETE_SITUACAO.ToString(),
                APOLICES_NUM_BILHETE = APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE.ToString(),
            };

            R4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1178- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1179- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -1180- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -1181- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, WABEND.WSQLERRMC);

            /*" -1183- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1183- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1188- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1188- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}