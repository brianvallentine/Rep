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
using Sias.VidaAzul.DB2.VA0142B;

namespace Code
{
    public class VA0142B
    {
        public bool IsCall { get; set; }

        public VA0142B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDAZUL                            *      */
        /*"      *   PROGRAMA ...............  VA0142B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  18/11/2019                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   HISTORIA                                                     *      */
        /*"      *   FUNCAO .................  A PARTIR DA LEITURA DOS REGISTROS  *      */
        /*"      *   CADASTRADOS NA TABELA SEGUROS.HIST_CONT_PARCELVA AJUSTA      *      */
        /*"      *   ITENS DO ENDOSSO ZERO CADASTRADO NA TABELA                   *      */
        /*"      *   SEGUROS.APOLICE_COBERTURAS.                                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 02 - INCIDENTE 383389                                   *      */
        /*"      *                                                                *      */
        /*"      *  IDENTIFICACAO DO CERTIFICADO NA ATUALIZACAO DA APOLICE        *      */
        /*"      *                                                                *      */
        /*"      * EM 20/04/2022 - FLAVIO BICALHO.                                *      */
        /*"      *                                               PROCURE POR V.02 *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public SortBasis<VA0142B_REG_SVA0142B> SVA0142B { get; set; } = new SortBasis<VA0142B_REG_SVA0142B>(new VA0142B_REG_SVA0142B());
        /*"01         REG-SVA0142B.*/
        public VA0142B_REG_SVA0142B REG_SVA0142B { get; set; } = new VA0142B_REG_SVA0142B();
        public class VA0142B_REG_SVA0142B : VarBasis
        {
            /*"  05       SOR-NUM-CERTIFICADO   PIC  9(015).*/
            public IntBasis SOR_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       SOR-NUM-PARCELA       PIC  9(004).*/
            public IntBasis SOR_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-NUM-APOLICE       PIC  9(013).*/
            public IntBasis SOR_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       SOR-NUM-ENDOSSO       PIC  9(009).*/
            public IntBasis SOR_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-DATA-INIVIGENCIA  PIC  X(010).*/
            public StringBasis SOR_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-NUM-ITEM          PIC  9(009).*/
            public IntBasis SOR_NUM_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-PRM-TOTAL         PIC S9(013)V99.*/
            public DoubleBasis SOR_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-OCORHIST          PIC  9(009).*/
            public IntBasis SOR_OCORHIST { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-DTINIVIG          PIC  X(010).*/
            public StringBasis SOR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-DTTERVIG          PIC  X(010).*/
            public StringBasis SOR_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COUNT                PIC S9(004)     COMP.*/
        public IntBasis VIND_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-COUNT1              PIC S9(009)     COMP.*/
        public IntBasis WHOST_COUNT1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WHOST-COUNT2              PIC S9(009)     COMP.*/
        public IntBasis WHOST_COUNT2 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WS-PERCENT                PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WS_PERCENT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WS-PRM-TOTAL              PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WS_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WS-VALOR                  PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WS-VALOR1                 PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WS_VALOR1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  W.*/
        public VA0142B_W W { get; set; } = new VA0142B_W();
        public class VA0142B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-APOLICOB             PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_APOLICOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-SORT                 PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-HISCONPA               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis LD_HISCONPA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  LD-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-ITEM                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-PARCEHIS               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_PARCEHIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-APOLICOB               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_APOLICOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-AJUSTE                 PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_AJUSTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-DATA                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_DATA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-APOLICOB               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis UP_APOLICOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  IN-APOLICOB               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis IN_APOLICOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_VA0142B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VA0142B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VA0142B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_VA0142B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VA0142B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VA0142B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_VA0142B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_VA0142B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VA0142B_FILLER_1 : VarBasis
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

                public _REDEF_VA0142B_FILLER_1()
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
            private _REDEF_VA0142B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_VA0142B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_VA0142B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VA0142B_FILLER_4 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public VA0142B_WTIME_DAYR WTIME_DAYR { get; set; } = new VA0142B_WTIME_DAYR();
                public class VA0142B_WTIME_DAYR : VarBasis
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

                    public VA0142B_WTIME_DAYR()
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

                public _REDEF_VA0142B_FILLER_4()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public VA0142B_WS_TIME WS_TIME { get; set; } = new VA0142B_WS_TIME();
            public class VA0142B_WS_TIME : VarBasis
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
            public VA0142B_WABEND WABEND { get; set; } = new VA0142B_WABEND();
            public class VA0142B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' VA0142B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0142B  ");
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
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.SEGVGAP SEGVGAP { get; set; } = new Dclgens.SEGVGAP();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public VA0142B_V0HISCONPA V0HISCONPA { get; set; } = new VA0142B_V0HISCONPA();
        public VA0142B_V0APOLICOB V0APOLICOB { get; set; } = new VA0142B_V0APOLICOB();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SVA0142B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SVA0142B.SetFile(SVA0142B_FILE_NAME_P);

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
            /*" -165- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -166- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -168- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -170- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -173- DISPLAY '----------------------------------' */
            _.Display($"----------------------------------");

            /*" -174- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -175- DISPLAY 'PROGRAMA EM EXECUCAO VA0142B      ' */
            _.Display($"PROGRAMA EM EXECUCAO VA0142B      ");

            /*" -176- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -177- DISPLAY '----------------------------------' . */
            _.Display($"----------------------------------");

            /*" -180- DISPLAY ' ' . */
            _.Display($" ");

            /*" -183- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -192- SORT SVA0142B ON ASCENDING KEY SOR-NUM-CERTIFICADO SOR-NUM-PARCELA INPUT PROCEDURE R0190-00-SELECIONA THRU R0190-99-SAIDA OUTPUT PROCEDURE R0500-00-PROCESSA-SORT THRU R0500-99-SAIDA. */
            SVA0142B.Sort("SOR-NUM-CERTIFICADO,SOR-NUM-PARCELA", () => R0190_00_SELECIONA_SECTION(), () => R0500_00_PROCESSA_SORT_SECTION());

            /*" -196- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -197- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -198- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -199- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -200- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -201- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -201- DISPLAY 'FIM    VA0142B    ' WTIME-DAYR. */
            _.Display($"FIM    VA0142B    {W.FILLER_4.WTIME_DAYR}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -206- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -210- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -211- DISPLAY ' ' */
            _.Display($" ");

            /*" -212- DISPLAY 'VA0142B - FIM NORMAL' */
            _.Display($"VA0142B - FIM NORMAL");

            /*" -215- DISPLAY ' ' */
            _.Display($" ");

            /*" -215- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -224- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", W.WABEND.WNR_EXEC_SQL);

            /*" -225- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -226- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -227- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -228- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -229- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -230- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -233- DISPLAY 'INICIO VA0142B    ' WTIME-DAYR. */
            _.Display($"INICIO VA0142B    {W.FILLER_4.WTIME_DAYR}");

            /*" -236- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -237- DISPLAY ' ' . */
            _.Display($" ");

            /*" -239- DISPLAY 'DATA DE MOVIMENTO ..... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DE MOVIMENTO ..... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -242- DISPLAY ' ' . */
            _.Display($" ");

            /*" -242- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -255- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -262- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -266- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -267- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -267- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -262- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0190-00-SELECIONA-SECTION */
        private void R0190_00_SELECIONA_SECTION()
        {
            /*" -280- MOVE '0190' TO WNR-EXEC-SQL. */
            _.Move("0190", W.WABEND.WNR_EXEC_SQL);

            /*" -281- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -282- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -283- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -284- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -285- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -286- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -288- DISPLAY 'DECLARE HISCONPA  ' WTIME-DAYR. */
            _.Display($"DECLARE HISCONPA  {W.FILLER_4.WTIME_DAYR}");

            /*" -289- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -291- PERFORM R0200-00-DECLARE-HISCONPA. */

            R0200_00_DECLARE_HISCONPA_SECTION();

            /*" -293- PERFORM R0210-00-FETCH-HISCONPA. */

            R0210_00_FETCH_HISCONPA_SECTION();

            /*" -297- PERFORM R0220-00-PROCESSA-HISCONPA UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0220_00_PROCESSA_HISCONPA_SECTION();
            }

            /*" -297- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -301- DISPLAY ' ' . */
            _.Display($" ");

            /*" -302- DISPLAY 'LIDOS HISCONPA ............. ' LD-HISCONPA */
            _.Display($"LIDOS HISCONPA ............. {W.LD_HISCONPA}");

            /*" -303- DISPLAY 'DESPREZA ITEM .............. ' DP-ITEM */
            _.Display($"DESPREZA ITEM .............. {W.DP_ITEM}");

            /*" -304- DISPLAY 'DESPREZA PARCEHIS .......... ' DP-PARCEHIS */
            _.Display($"DESPREZA PARCEHIS .......... {W.DP_PARCEHIS}");

            /*" -305- DISPLAY 'DESPREZA APOLICOB .......... ' DP-APOLICOB */
            _.Display($"DESPREZA APOLICOB .......... {W.DP_APOLICOB}");

            /*" -306- DISPLAY 'DESPREZA ALTERADO .......... ' DP-AJUSTE */
            _.Display($"DESPREZA ALTERADO .......... {W.DP_AJUSTE}");

            /*" -307- DISPLAY 'DESPREZA DATA .............. ' DP-DATA */
            _.Display($"DESPREZA DATA .............. {W.DP_DATA}");

            /*" -308- DISPLAY 'GRAVADOS SORT .............. ' GV-SORT. */
            _.Display($"GRAVADOS SORT .............. {W.GV_SORT}");

            /*" -308- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0190_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-HISCONPA-SECTION */
        private void R0200_00_DECLARE_HISCONPA_SECTION()
        {
            /*" -321- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", W.WABEND.WNR_EXEC_SQL);

            /*" -335- PERFORM R0200_00_DECLARE_HISCONPA_DB_DECLARE_1 */

            R0200_00_DECLARE_HISCONPA_DB_DECLARE_1();

            /*" -337- PERFORM R0200_00_DECLARE_HISCONPA_DB_OPEN_1 */

            R0200_00_DECLARE_HISCONPA_DB_OPEN_1();

            /*" -341- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -342- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (HISCONPA)  ' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (HISCONPA)  ");

                /*" -342- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-HISCONPA-DB-DECLARE-1 */
        public void R0200_00_DECLARE_HISCONPA_DB_DECLARE_1()
        {
            /*" -335- EXEC SQL DECLARE V0HISCONPA CURSOR WITH HOLD FOR SELECT A.NUM_CERTIFICADO ,A.NUM_PARCELA ,B.NUM_APOLICE ,B.NUM_ENDOSSO ,B.DATA_INIVIGENCIA FROM SEGUROS.HIST_CONT_PARCELVA A ,SEGUROS.ENDOSSOS B WHERE A.DTFATUR = :SISTEMAS-DATA-MOV-ABERTO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.TIPO_ENDOSSO = '1' AND B.NUM_ENDOSSO <> 0 END-EXEC. */
            V0HISCONPA = new VA0142B_V0HISCONPA(true);
            string GetQuery_V0HISCONPA()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO 
							,A.NUM_PARCELA 
							,B.NUM_APOLICE 
							,B.NUM_ENDOSSO 
							,B.DATA_INIVIGENCIA 
							FROM SEGUROS.HIST_CONT_PARCELVA A 
							,SEGUROS.ENDOSSOS B 
							WHERE A.DTFATUR = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND B.TIPO_ENDOSSO = '1' 
							AND B.NUM_ENDOSSO <> 0";

                return query;
            }
            V0HISCONPA.GetQueryEvent += GetQuery_V0HISCONPA;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-HISCONPA-DB-OPEN-1 */
        public void R0200_00_DECLARE_HISCONPA_DB_OPEN_1()
        {
            /*" -337- EXEC SQL OPEN V0HISCONPA END-EXEC. */

            V0HISCONPA.Open();

        }

        [StopWatch]
        /*" R0600-00-DECLARE-V0APOLICOB-DB-DECLARE-1 */
        public void R0600_00_DECLARE_V0APOLICOB_DB_DECLARE_1()
        {
            /*" -794- EXEC SQL DECLARE V0APOLICOB CURSOR WITH HOLD FOR SELECT NUM_APOLICE ,RAMO_COBERTURA ,MODALI_COBERTURA ,COD_COBERTURA ,IMP_SEGURADA_IX ,IMP_SEGURADA_VAR ,PCT_COBERTURA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND NUM_ITEM = 0 AND COD_COBERTURA <> 0 WITH UR END-EXEC. */
            V0APOLICOB = new VA0142B_V0APOLICOB(true);
            string GetQuery_V0APOLICOB()
            {
                var query = @$"SELECT NUM_APOLICE 
							,RAMO_COBERTURA 
							,MODALI_COBERTURA 
							,COD_COBERTURA 
							,IMP_SEGURADA_IX 
							,IMP_SEGURADA_VAR 
							,PCT_COBERTURA 
							FROM SEGUROS.APOLICE_COBERTURAS 
							WHERE NUM_APOLICE = '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}' 
							AND NUM_ENDOSSO = '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}' 
							AND NUM_ITEM = 0 
							AND COD_COBERTURA <> 0";

                return query;
            }
            V0APOLICOB.GetQueryEvent += GetQuery_V0APOLICOB;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-HISCONPA-SECTION */
        private void R0210_00_FETCH_HISCONPA_SECTION()
        {
            /*" -355- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", W.WABEND.WNR_EXEC_SQL);

            /*" -361- PERFORM R0210_00_FETCH_HISCONPA_DB_FETCH_1 */

            R0210_00_FETCH_HISCONPA_DB_FETCH_1();

            /*" -365- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -365- PERFORM R0210_00_FETCH_HISCONPA_DB_CLOSE_1 */

                R0210_00_FETCH_HISCONPA_DB_CLOSE_1();

                /*" -367- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -369- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -370- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -371- DISPLAY 'R0210-00 - PROBLEMAS FETCH   (HISCONPA)  ' */
                _.Display($"R0210-00 - PROBLEMAS FETCH   (HISCONPA)  ");

                /*" -374- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -376- ADD 1 TO LD-HISCONPA. */
            W.LD_HISCONPA.Value = W.LD_HISCONPA + 1;

            /*" -378- MOVE LD-HISCONPA TO AC-LIDOS. */
            _.Move(W.LD_HISCONPA, W.AC_LIDOS);

            /*" -380- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -381- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -382- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -383- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -384- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -385- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -386- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -387- DISPLAY 'LIDOS HISCONPA     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS HISCONPA     {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0210-00-FETCH-HISCONPA-DB-FETCH-1 */
        public void R0210_00_FETCH_HISCONPA_DB_FETCH_1()
        {
            /*" -361- EXEC SQL FETCH V0HISCONPA INTO :HISCONPA-NUM-CERTIFICADO ,:HISCONPA-NUM-PARCELA ,:ENDOSSOS-NUM-APOLICE ,:ENDOSSOS-NUM-ENDOSSO ,:ENDOSSOS-DATA-INIVIGENCIA END-EXEC. */

            if (V0HISCONPA.Fetch())
            {
                _.Move(V0HISCONPA.HISCONPA_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);
                _.Move(V0HISCONPA.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(V0HISCONPA.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(V0HISCONPA.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(V0HISCONPA.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-HISCONPA-DB-CLOSE-1 */
        public void R0210_00_FETCH_HISCONPA_DB_CLOSE_1()
        {
            /*" -365- EXEC SQL CLOSE V0HISCONPA END-EXEC */

            V0HISCONPA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-PROCESSA-HISCONPA-SECTION */
        private void R0220_00_PROCESSA_HISCONPA_SECTION()
        {
            /*" -400- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", W.WABEND.WNR_EXEC_SQL);

            /*" -402- MOVE HISCONPA-NUM-CERTIFICADO TO SOR-NUM-CERTIFICADO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, REG_SVA0142B.SOR_NUM_CERTIFICADO);

            /*" -404- MOVE HISCONPA-NUM-PARCELA TO SOR-NUM-PARCELA. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, REG_SVA0142B.SOR_NUM_PARCELA);

            /*" -406- MOVE ENDOSSOS-NUM-APOLICE TO SOR-NUM-APOLICE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, REG_SVA0142B.SOR_NUM_APOLICE);

            /*" -408- MOVE ENDOSSOS-NUM-ENDOSSO TO SOR-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, REG_SVA0142B.SOR_NUM_ENDOSSO);

            /*" -412- MOVE ENDOSSOS-DATA-INIVIGENCIA TO SOR-DATA-INIVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, REG_SVA0142B.SOR_DATA_INIVIGENCIA);

            /*" -414- PERFORM R0230-00-SELECT-SEGVGAP. */

            R0230_00_SELECT_SEGVGAP_SECTION();

            /*" -415- IF SEGVGAP-NUM-ITEM EQUAL ZEROS */

            if (SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM == 00)
            {

                /*" -416- ADD 1 TO DP-ITEM */
                W.DP_ITEM.Value = W.DP_ITEM + 1;

                /*" -419- GO TO R0220-90-LEITURA. */

                R0220_90_LEITURA(); //GOTO
                return;
            }


            /*" -423- MOVE SEGVGAP-NUM-ITEM TO SOR-NUM-ITEM. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM, REG_SVA0142B.SOR_NUM_ITEM);

            /*" -425- PERFORM R0240-00-SELECT-PARCEHIS. */

            R0240_00_SELECT_PARCEHIS_SECTION();

            /*" -426- IF PARCEHIS-PRM-TOTAL EQUAL ZEROS */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL == 00)
            {

                /*" -427- ADD 1 TO DP-PARCEHIS */
                W.DP_PARCEHIS.Value = W.DP_PARCEHIS + 1;

                /*" -430- GO TO R0220-90-LEITURA. */

                R0220_90_LEITURA(); //GOTO
                return;
            }


            /*" -434- MOVE PARCEHIS-PRM-TOTAL TO SOR-PRM-TOTAL. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL, REG_SVA0142B.SOR_PRM_TOTAL);

            /*" -436- PERFORM R0270-00-SELECT-APOLICOB. */

            R0270_00_SELECT_APOLICOB_SECTION();

            /*" -437- IF SOR-OCORHIST EQUAL ZEROS */

            if (REG_SVA0142B.SOR_OCORHIST == 00)
            {

                /*" -438- ADD 1 TO DP-APOLICOB */
                W.DP_APOLICOB.Value = W.DP_APOLICOB + 1;

                /*" -441- GO TO R0220-90-LEITURA. */

                R0220_90_LEITURA(); //GOTO
                return;
            }


            /*" -443- PERFORM R0280-00-SELECT-APOLICOB. */

            R0280_00_SELECT_APOLICOB_SECTION();

            /*" -444- IF WHOST-COUNT1 EQUAL WHOST-COUNT2 */

            if (WHOST_COUNT1 == WHOST_COUNT2)
            {

                /*" -445- ADD 1 TO DP-AJUSTE */
                W.DP_AJUSTE.Value = W.DP_AJUSTE + 1;

                /*" -448- GO TO R0220-90-LEITURA. */

                R0220_90_LEITURA(); //GOTO
                return;
            }


            /*" -450- PERFORM R0290-00-SELECT-APOLICOB. */

            R0290_00_SELECT_APOLICOB_SECTION();

            /*" -452- IF SOR-DTINIVIG EQUAL SPACES OR SOR-DTTERVIG EQUAL SPACES */

            if (REG_SVA0142B.SOR_DTINIVIG.IsEmpty() || REG_SVA0142B.SOR_DTTERVIG.IsEmpty())
            {

                /*" -453- ADD 1 TO DP-DATA */
                W.DP_DATA.Value = W.DP_DATA + 1;

                /*" -456- GO TO R0220-90-LEITURA. */

                R0220_90_LEITURA(); //GOTO
                return;
            }


            /*" -457- RELEASE REG-SVA0142B. */
            SVA0142B.Release(REG_SVA0142B);

            /*" -457- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R0220_90_LEITURA */

            R0220_90_LEITURA();

        }

        [StopWatch]
        /*" R0220-90-LEITURA */
        private void R0220_90_LEITURA(bool isPerform = false)
        {
            /*" -462- PERFORM R0210-00-FETCH-HISCONPA. */

            R0210_00_FETCH_HISCONPA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0230-00-SELECT-SEGVGAP-SECTION */
        private void R0230_00_SELECT_SEGVGAP_SECTION()
        {
            /*" -474- MOVE '0230' TO WNR-EXEC-SQL. */
            _.Move("0230", W.WABEND.WNR_EXEC_SQL);

            /*" -481- PERFORM R0230_00_SELECT_SEGVGAP_DB_SELECT_1 */

            R0230_00_SELECT_SEGVGAP_DB_SELECT_1();

            /*" -485- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -487- MOVE ZEROS TO SEGVGAP-NUM-ITEM */
                _.Move(0, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM);

                /*" -490- GO TO R0230-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/ //GOTO
                return;
            }


            /*" -491- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -493- DISPLAY 'R0230-00 - PROBLEMAS NO SELECT(APOLICOB)' ' NRCERTIF    = ' HISCONPA-NUM-CERTIFICADO */

                $"R0230-00 - PROBLEMAS NO SELECT(APOLICOB) NRCERTIF    = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}"
                .Display();

                /*" -493- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0230-00-SELECT-SEGVGAP-DB-SELECT-1 */
        public void R0230_00_SELECT_SEGVGAP_DB_SELECT_1()
        {
            /*" -481- EXEC SQL SELECT NUM_ITEM INTO :SEGVGAP-NUM-ITEM FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var r0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1 = new R0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1.Execute(r0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGVGAP_NUM_ITEM, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/

        [StopWatch]
        /*" R0240-00-SELECT-PARCEHIS-SECTION */
        private void R0240_00_SELECT_PARCEHIS_SECTION()
        {
            /*" -506- MOVE '0240' TO WNR-EXEC-SQL. */
            _.Move("0240", W.WABEND.WNR_EXEC_SQL);

            /*" -514- PERFORM R0240_00_SELECT_PARCEHIS_DB_SELECT_1 */

            R0240_00_SELECT_PARCEHIS_DB_SELECT_1();

            /*" -518- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -520- MOVE ZEROS TO PARCEHIS-PRM-TOTAL */
                _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);

                /*" -523- GO TO R0240-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_99_SAIDA*/ //GOTO
                return;
            }


            /*" -524- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -527- DISPLAY 'R0240-00 - PROBLEMAS NO SELECT(PARCEHIS)' ' APOLICE     = ' ENDOSSOS-NUM-APOLICE ' ENDOSSO     = ' ENDOSSOS-NUM-ENDOSSO */

                $"R0240-00 - PROBLEMAS NO SELECT(PARCEHIS) APOLICE     = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE} ENDOSSO     = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}"
                .Display();

                /*" -527- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0240-00-SELECT-PARCEHIS-DB-SELECT-1 */
        public void R0240_00_SELECT_PARCEHIS_DB_SELECT_1()
        {
            /*" -514- EXEC SQL SELECT PRM_TOTAL INTO :PARCEHIS-PRM-TOTAL FROM SEGUROS.PARCELA_HISTORICO WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND COD_OPERACAO = 101 WITH UR END-EXEC. */

            var r0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 = new R0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1.Execute(r0240_00_SELECT_PARCEHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_99_SAIDA*/

        [StopWatch]
        /*" R0270-00-SELECT-APOLICOB-SECTION */
        private void R0270_00_SELECT_APOLICOB_SECTION()
        {
            /*" -540- MOVE '0270' TO WNR-EXEC-SQL. */
            _.Move("0270", W.WABEND.WNR_EXEC_SQL);

            /*" -552- PERFORM R0270_00_SELECT_APOLICOB_DB_SELECT_1 */

            R0270_00_SELECT_APOLICOB_DB_SELECT_1();

            /*" -556- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -558- MOVE ZEROS TO WHOST-COUNT1 SOR-OCORHIST */
                _.Move(0, WHOST_COUNT1, REG_SVA0142B.SOR_OCORHIST);

                /*" -561- GO TO R0270-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/ //GOTO
                return;
            }


            /*" -562- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -565- DISPLAY 'R0270-00 - PROBLEMAS NO SELECT(APOLICOB)' ' APOLICE     = ' ENDOSSOS-NUM-APOLICE ' ITEM        = ' SEGVGAP-NUM-ITEM */

                $"R0270-00 - PROBLEMAS NO SELECT(APOLICOB) APOLICE     = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE} ITEM        = {SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM}"
                .Display();

                /*" -568- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -569- IF VIND-COUNT LESS ZEROS */

            if (VIND_COUNT < 00)
            {

                /*" -571- MOVE ZEROS TO WHOST-COUNT1. */
                _.Move(0, WHOST_COUNT1);
            }


            /*" -572- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -574- MOVE ZEROS TO SOR-OCORHIST */
                _.Move(0, REG_SVA0142B.SOR_OCORHIST);

                /*" -575- ELSE */
            }
            else
            {


                /*" -576- MOVE APOLICOB-OCORR-HISTORICO TO SOR-OCORHIST. */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO, REG_SVA0142B.SOR_OCORHIST);
            }


        }

        [StopWatch]
        /*" R0270-00-SELECT-APOLICOB-DB-SELECT-1 */
        public void R0270_00_SELECT_APOLICOB_DB_SELECT_1()
        {
            /*" -552- EXEC SQL SELECT COUNT(*) ,MAX(OCORR_HISTORICO) INTO :WHOST-COUNT1:VIND-COUNT ,:APOLICOB-OCORR-HISTORICO:VIND-NULL01 FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGVGAP-NUM-ITEM AND DATA_INIVIGENCIA <= :ENDOSSOS-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :ENDOSSOS-DATA-INIVIGENCIA WITH UR END-EXEC. */

            var r0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1 = new R0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1()
            {
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                SEGVGAP_NUM_ITEM = SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM.ToString(),
            };

            var executed_1 = R0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1.Execute(r0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT1, WHOST_COUNT1);
                _.Move(executed_1.VIND_COUNT, VIND_COUNT);
                _.Move(executed_1.APOLICOB_OCORR_HISTORICO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/

        [StopWatch]
        /*" R0280-00-SELECT-APOLICOB-SECTION */
        private void R0280_00_SELECT_APOLICOB_SECTION()
        {
            /*" -589- MOVE '0280' TO WNR-EXEC-SQL. */
            _.Move("0280", W.WABEND.WNR_EXEC_SQL);

            /*" -598- PERFORM R0280_00_SELECT_APOLICOB_DB_SELECT_1 */

            R0280_00_SELECT_APOLICOB_DB_SELECT_1();

            /*" -602- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -603- MOVE ZEROS TO WHOST-COUNT2 */
                _.Move(0, WHOST_COUNT2);

                /*" -606- GO TO R0280-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0280_99_SAIDA*/ //GOTO
                return;
            }


            /*" -607- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -610- DISPLAY 'R0280-00 - PROBLEMAS NO SELECT(APOLICOB)' ' APOLICE     = ' ENDOSSOS-NUM-APOLICE ' ENDOSSO     = ' ENDOSSOS-NUM-ENDOSSO */

                $"R0280-00 - PROBLEMAS NO SELECT(APOLICOB) APOLICE     = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE} ENDOSSO     = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}"
                .Display();

                /*" -613- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -614- IF VIND-COUNT LESS ZEROS */

            if (VIND_COUNT < 00)
            {

                /*" -614- MOVE ZEROS TO WHOST-COUNT2. */
                _.Move(0, WHOST_COUNT2);
            }


        }

        [StopWatch]
        /*" R0280-00-SELECT-APOLICOB-DB-SELECT-1 */
        public void R0280_00_SELECT_APOLICOB_DB_SELECT_1()
        {
            /*" -598- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT2:VIND-COUNT FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND NUM_ITEM = 0 AND COD_COBERTURA <> 0 WITH UR END-EXEC. */

            var r0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1 = new R0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1.Execute(r0280_00_SELECT_APOLICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT2, WHOST_COUNT2);
                _.Move(executed_1.VIND_COUNT, VIND_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0280_99_SAIDA*/

        [StopWatch]
        /*" R0290-00-SELECT-APOLICOB-SECTION */
        private void R0290_00_SELECT_APOLICOB_SECTION()
        {
            /*" -627- MOVE '0290' TO WNR-EXEC-SQL. */
            _.Move("0290", W.WABEND.WNR_EXEC_SQL);

            /*" -631- MOVE SOR-OCORHIST TO APOLICOB-OCORR-HISTORICO. */
            _.Move(REG_SVA0142B.SOR_OCORHIST, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO);

            /*" -643- PERFORM R0290_00_SELECT_APOLICOB_DB_SELECT_1 */

            R0290_00_SELECT_APOLICOB_DB_SELECT_1();

            /*" -647- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -650- MOVE SPACES TO APOLICOB-DATA-INIVIGENCIA APOLICOB-DATA-TERVIGENCIA */
                _.Move("", APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);

                /*" -653- GO TO R0290-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_99_SAIDA*/ //GOTO
                return;
            }


            /*" -654- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -657- DISPLAY 'R0290-00 - PROBLEMAS NO SELECT(APOLICOB)' ' APOLICE     = ' ENDOSSOS-NUM-APOLICE ' ITEM        = ' SEGVGAP-NUM-ITEM */

                $"R0290-00 - PROBLEMAS NO SELECT(APOLICOB) APOLICE     = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE} ITEM        = {SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM}"
                .Display();

                /*" -660- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -662- MOVE APOLICOB-DATA-INIVIGENCIA TO SOR-DTINIVIG. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA, REG_SVA0142B.SOR_DTINIVIG);

            /*" -663- MOVE APOLICOB-DATA-TERVIGENCIA TO SOR-DTTERVIG. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA, REG_SVA0142B.SOR_DTTERVIG);

        }

        [StopWatch]
        /*" R0290-00-SELECT-APOLICOB-DB-SELECT-1 */
        public void R0290_00_SELECT_APOLICOB_DB_SELECT_1()
        {
            /*" -643- EXEC SQL SELECT DATA_INIVIGENCIA ,DATA_TERVIGENCIA INTO :APOLICOB-DATA-INIVIGENCIA ,:APOLICOB-DATA-TERVIGENCIA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGVGAP-NUM-ITEM AND OCORR_HISTORICO = :APOLICOB-OCORR-HISTORICO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1 = new R0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1()
            {
                APOLICOB_OCORR_HISTORICO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO.ToString(),
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                SEGVGAP_NUM_ITEM = SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM.ToString(),
            };

            var executed_1 = R0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1.Execute(r0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);
                _.Move(executed_1.APOLICOB_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-PROCESSA-SORT-SECTION */
        private void R0500_00_PROCESSA_SORT_SECTION()
        {
            /*" -676- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", W.WABEND.WNR_EXEC_SQL);

            /*" -677- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -679- PERFORM R0510-00-LER-SORT. */

            R0510_00_LER_SORT_SECTION();

            /*" -680- IF WFIM-SORT NOT EQUAL SPACES */

            if (!W.WFIM_SORT.IsEmpty())
            {

                /*" -683- GO TO R0500-90-DISPLAY. */

                R0500_90_DISPLAY(); //GOTO
                return;
            }


            /*" -684- PERFORM R0520-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R0520_00_PROCESSA_SORT_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0500_90_DISPLAY */

            R0500_90_DISPLAY();

        }

        [StopWatch]
        /*" R0500-90-DISPLAY */
        private void R0500_90_DISPLAY(bool isPerform = false)
        {
            /*" -690- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -694- DISPLAY ' ' . */
            _.Display($" ");

            /*" -695- DISPLAY 'LIDOS SORT ................ ' LD-SORT */
            _.Display($"LIDOS SORT ................ {W.LD_SORT}");

            /*" -696- DISPLAY 'DESPREZA SORT ............. ' DP-SORT */
            _.Display($"DESPREZA SORT ............. {W.DP_SORT}");

            /*" -697- DISPLAY ' ' . */
            _.Display($" ");

            /*" -698- DISPLAY 'UPDATE APOLICOB ........... ' UP-APOLICOB */
            _.Display($"UPDATE APOLICOB ........... {W.UP_APOLICOB}");

            /*" -699- DISPLAY 'INSERT APOLICOB ........... ' IN-APOLICOB */
            _.Display($"INSERT APOLICOB ........... {W.IN_APOLICOB}");

            /*" -699- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-LER-SORT-SECTION */
        private void R0510_00_LER_SORT_SECTION()
        {
            /*" -712- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", W.WABEND.WNR_EXEC_SQL);

            /*" -714- RETURN SVA0142B AT END */
            try
            {
                SVA0142B.Return(REG_SVA0142B, () =>
                {

                    /*" -715- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -718- GO TO R0510-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -721- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

            /*" -723- MOVE LD-SORT TO AC-LIDOS. */
            _.Move(W.LD_SORT, W.AC_LIDOS);

            /*" -725- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -726- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -727- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -728- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -729- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -730- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -731- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -732- DISPLAY 'LIDOS SORT         ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS SORT         {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-PROCESSA-SORT-SECTION */
        private void R0520_00_PROCESSA_SORT_SECTION()
        {
            /*" -745- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", W.WABEND.WNR_EXEC_SQL);

            /*" -746- MOVE SOR-PRM-TOTAL TO WS-PRM-TOTAL. */
            _.Move(REG_SVA0142B.SOR_PRM_TOTAL, WS_PRM_TOTAL);

            /*" -747- MOVE 100 TO WS-PERCENT. */
            _.Move(100, WS_PERCENT);

            /*" -750- MOVE ZEROS TO WS-VALOR WS-VALOR1. */
            _.Move(0, WS_VALOR, WS_VALOR1);

            /*" -752- MOVE SOR-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(REG_SVA0142B.SOR_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -755- MOVE SOR-NUM-ENDOSSO TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(REG_SVA0142B.SOR_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -757- MOVE SPACES TO WFIM-APOLICOB. */
            _.Move("", W.WFIM_APOLICOB);

            /*" -759- PERFORM R0600-00-DECLARE-V0APOLICOB. */

            R0600_00_DECLARE_V0APOLICOB_SECTION();

            /*" -761- PERFORM R0610-00-FETCH-V0APOLICOB. */

            R0610_00_FETCH_V0APOLICOB_SECTION();

            /*" -762- PERFORM R0650-00-PROCESSA-V0APOLICOB UNTIL WFIM-APOLICOB NOT EQUAL SPACES. */

            while (!(!W.WFIM_APOLICOB.IsEmpty()))
            {

                R0650_00_PROCESSA_V0APOLICOB_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0520_90_LEITURA */

            R0520_90_LEITURA();

        }

        [StopWatch]
        /*" R0520-90-LEITURA */
        private void R0520_90_LEITURA(bool isPerform = false)
        {
            /*" -767- PERFORM R0510-00-LER-SORT. */

            R0510_00_LER_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-DECLARE-V0APOLICOB-SECTION */
        private void R0600_00_DECLARE_V0APOLICOB_SECTION()
        {
            /*" -779- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", W.WABEND.WNR_EXEC_SQL);

            /*" -794- PERFORM R0600_00_DECLARE_V0APOLICOB_DB_DECLARE_1 */

            R0600_00_DECLARE_V0APOLICOB_DB_DECLARE_1();

            /*" -797- PERFORM R0600_00_DECLARE_V0APOLICOB_DB_OPEN_1 */

            R0600_00_DECLARE_V0APOLICOB_DB_OPEN_1();

            /*" -800- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -801- DISPLAY 'R0600-00 - PROBLEMAS DECLARE (V0APOLICOB) ' */
                _.Display($"R0600-00 - PROBLEMAS DECLARE (V0APOLICOB) ");

                /*" -801- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0600-00-DECLARE-V0APOLICOB-DB-OPEN-1 */
        public void R0600_00_DECLARE_V0APOLICOB_DB_OPEN_1()
        {
            /*" -797- EXEC SQL OPEN V0APOLICOB END-EXEC. */

            V0APOLICOB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0610-00-FETCH-V0APOLICOB-SECTION */
        private void R0610_00_FETCH_V0APOLICOB_SECTION()
        {
            /*" -814- MOVE '0610' TO WNR-EXEC-SQL. */
            _.Move("0610", W.WABEND.WNR_EXEC_SQL);

            /*" -822- PERFORM R0610_00_FETCH_V0APOLICOB_DB_FETCH_1 */

            R0610_00_FETCH_V0APOLICOB_DB_FETCH_1();

            /*" -826- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -826- PERFORM R0610_00_FETCH_V0APOLICOB_DB_CLOSE_1 */

                R0610_00_FETCH_V0APOLICOB_DB_CLOSE_1();

                /*" -828- MOVE 'S' TO WFIM-APOLICOB */
                _.Move("S", W.WFIM_APOLICOB);

                /*" -830- GO TO R0610-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/ //GOTO
                return;
            }


            /*" -831- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -832- DISPLAY 'R0610-00 - PROBLEMAS FETCH (V0APOLICOB)   ' */
                _.Display($"R0610-00 - PROBLEMAS FETCH (V0APOLICOB)   ");

                /*" -832- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0610-00-FETCH-V0APOLICOB-DB-FETCH-1 */
        public void R0610_00_FETCH_V0APOLICOB_DB_FETCH_1()
        {
            /*" -822- EXEC SQL FETCH V0APOLICOB INTO :APOLICOB-NUM-APOLICE ,:APOLICOB-RAMO-COBERTURA ,:APOLICOB-MODALI-COBERTURA ,:APOLICOB-COD-COBERTURA ,:APOLICOB-IMP-SEGURADA-IX ,:APOLICOB-IMP-SEGURADA-VAR ,:APOLICOB-PCT-COBERTURA END-EXEC. */

            if (V0APOLICOB.Fetch())
            {
                _.Move(V0APOLICOB.APOLICOB_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);
                _.Move(V0APOLICOB.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
                _.Move(V0APOLICOB.APOLICOB_MODALI_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA);
                _.Move(V0APOLICOB.APOLICOB_COD_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);
                _.Move(V0APOLICOB.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
                _.Move(V0APOLICOB.APOLICOB_IMP_SEGURADA_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);
                _.Move(V0APOLICOB.APOLICOB_PCT_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);
            }

        }

        [StopWatch]
        /*" R0610-00-FETCH-V0APOLICOB-DB-CLOSE-1 */
        public void R0610_00_FETCH_V0APOLICOB_DB_CLOSE_1()
        {
            /*" -826- EXEC SQL CLOSE V0APOLICOB END-EXEC */

            V0APOLICOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/

        [StopWatch]
        /*" R0650-00-PROCESSA-V0APOLICOB-SECTION */
        private void R0650_00_PROCESSA_V0APOLICOB_SECTION()
        {
            /*" -845- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", W.WABEND.WNR_EXEC_SQL);

            /*" -847- MOVE ZEROS TO APOLICOB-NUM-ENDOSSO. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);

            /*" -849- MOVE SOR-NUM-ITEM TO APOLICOB-NUM-ITEM. */
            _.Move(REG_SVA0142B.SOR_NUM_ITEM, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);

            /*" -851- MOVE SOR-OCORHIST TO APOLICOB-OCORR-HISTORICO. */
            _.Move(REG_SVA0142B.SOR_OCORHIST, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO);

            /*" -853- MOVE 1 TO APOLICOB-FATOR-MULTIPLICA. */
            _.Move(1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

            /*" -855- MOVE SOR-DTINIVIG TO APOLICOB-DATA-INIVIGENCIA. */
            _.Move(REG_SVA0142B.SOR_DTINIVIG, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);

            /*" -857- MOVE SOR-DTTERVIG TO APOLICOB-DATA-TERVIGENCIA. */
            _.Move(REG_SVA0142B.SOR_DTTERVIG, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);

            /*" -859- MOVE ZEROS TO APOLICOB-COD-EMPRESA. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA);

            /*" -861- MOVE '0' TO APOLICOB-SIT-REGISTRO. */
            _.Move("0", APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO);

            /*" -865- MOVE ZEROS TO VIND-NULL01 VIND-NULL02. */
            _.Move(0, VIND_NULL01, VIND_NULL02);

            /*" -867- COMPUTE WS-PERCENT EQUAL (WS-PERCENT - APOLICOB-PCT-COBERTURA). */
            WS_PERCENT.Value = (WS_PERCENT - APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);

            /*" -871- COMPUTE WS-VALOR1 EQUAL (SOR-PRM-TOTAL * APOLICOB-PCT-COBERTURA / 100). */
            WS_VALOR1.Value = (REG_SVA0142B.SOR_PRM_TOTAL * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA / 100f);

            /*" -872- IF WS-PERCENT EQUAL ZEROS */

            if (WS_PERCENT == 00)
            {

                /*" -874- COMPUTE WS-VALOR1 EQUAL (WS-PRM-TOTAL - WS-VALOR) */
                WS_VALOR1.Value = (WS_PRM_TOTAL - WS_VALOR);

                /*" -877- MOVE WS-VALOR1 TO APOLICOB-PRM-TARIFARIO-IX APOLICOB-PRM-TARIFARIO-VAR */
                _.Move(WS_VALOR1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);

                /*" -878- ELSE */
            }
            else
            {


                /*" -881- MOVE WS-VALOR1 TO APOLICOB-PRM-TARIFARIO-IX APOLICOB-PRM-TARIFARIO-VAR */
                _.Move(WS_VALOR1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);

                /*" -885- ADD WS-VALOR1 TO WS-VALOR. */
                WS_VALOR.Value = WS_VALOR + WS_VALOR1;
            }


            /*" -885- PERFORM R1000-00-UPDATE-APOLICOB. */

            R1000_00_UPDATE_APOLICOB_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0650_90_LEITURA */

            R0650_90_LEITURA();

        }

        [StopWatch]
        /*" R0650-90-LEITURA */
        private void R0650_90_LEITURA(bool isPerform = false)
        {
            /*" -890- PERFORM R0610-00-FETCH-V0APOLICOB. */

            R0610_00_FETCH_V0APOLICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-UPDATE-APOLICOB-SECTION */
        private void R1000_00_UPDATE_APOLICOB_SECTION()
        {
            /*" -902- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", W.WABEND.WNR_EXEC_SQL);

            /*" -923- PERFORM R1000_00_UPDATE_APOLICOB_DB_UPDATE_1 */

            R1000_00_UPDATE_APOLICOB_DB_UPDATE_1();

            /*" -927- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -928- PERFORM R1100-00-INSERT-APOLICOB */

                R1100_00_INSERT_APOLICOB_SECTION();

                /*" -929- ELSE */
            }
            else
            {


                /*" -930- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -937- DISPLAY 'R1000-00 - PROBLEMAS UPDATE (APOLICOB)' 'APOLICE         = ' APOLICOB-NUM-APOLICE 'ENDOSSO         = ' APOLICOB-NUM-ENDOSSO 'ITEM            = ' APOLICOB-NUM-ITEM 'OCORR-HISTORICO = ' APOLICOB-OCORR-HISTORICO 'RAMO-COBERTURA  = ' APOLICOB-RAMO-COBERTURA 'COD-COBERTURA   = ' APOLICOB-COD-COBERTURA */

                    $"R1000-00 - PROBLEMAS UPDATE (APOLICOB)APOLICE         = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}ENDOSSO         = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}ITEM            = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM}OCORR-HISTORICO = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO}RAMO-COBERTURA  = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}COD-COBERTURA   = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA}"
                    .Display();

                    /*" -938- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -939- ELSE */
                }
                else
                {


                    /*" -940- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -940- ADD 1 TO UP-APOLICOB. */
                        W.UP_APOLICOB.Value = W.UP_APOLICOB + 1;
                    }

                }

            }


        }

        [StopWatch]
        /*" R1000-00-UPDATE-APOLICOB-DB-UPDATE-1 */
        public void R1000_00_UPDATE_APOLICOB_DB_UPDATE_1()
        {
            /*" -923- EXEC SQL UPDATE SEGUROS.APOLICE_COBERTURAS SET RAMO_COBERTURA = :APOLICOB-RAMO-COBERTURA ,MODALI_COBERTURA = :APOLICOB-MODALI-COBERTURA ,COD_COBERTURA = :APOLICOB-COD-COBERTURA ,IMP_SEGURADA_IX = :APOLICOB-IMP-SEGURADA-IX ,PRM_TARIFARIO_IX = :APOLICOB-PRM-TARIFARIO-IX ,IMP_SEGURADA_VAR = :APOLICOB-IMP-SEGURADA-VAR ,PRM_TARIFARIO_VAR = :APOLICOB-PRM-TARIFARIO-VAR ,PCT_COBERTURA = :APOLICOB-PCT-COBERTURA ,COD_EMPRESA = :APOLICOB-COD-EMPRESA :VIND-NULL01 ,SIT_REGISTRO = :APOLICOB-SIT-REGISTRO :VIND-NULL02 WHERE NUM_APOLICE = :APOLICOB-NUM-APOLICE AND NUM_ENDOSSO = :APOLICOB-NUM-ENDOSSO AND NUM_ITEM = :APOLICOB-NUM-ITEM AND OCORR_HISTORICO = :APOLICOB-OCORR-HISTORICO AND RAMO_COBERTURA = :APOLICOB-RAMO-COBERTURA AND COD_COBERTURA = :APOLICOB-COD-COBERTURA END-EXEC. */

            var r1000_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1 = new R1000_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1()
            {
                APOLICOB_SIT_REGISTRO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
                APOLICOB_COD_EMPRESA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                APOLICOB_PRM_TARIFARIO_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR.ToString(),
                APOLICOB_MODALI_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA.ToString(),
                APOLICOB_PRM_TARIFARIO_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX.ToString(),
                APOLICOB_IMP_SEGURADA_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR.ToString(),
                APOLICOB_IMP_SEGURADA_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.ToString(),
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                APOLICOB_PCT_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA.ToString(),
                APOLICOB_OCORR_HISTORICO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO.ToString(),
                APOLICOB_NUM_APOLICE = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.ToString(),
                APOLICOB_NUM_ENDOSSO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.ToString(),
                APOLICOB_NUM_ITEM = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM.ToString(),
            };

            R1000_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1.Execute(r1000_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-INSERT-APOLICOB-SECTION */
        private void R1100_00_INSERT_APOLICOB_SECTION()
        {
            /*" -953- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", W.WABEND.WNR_EXEC_SQL);

            /*" -956- ADD 1 TO IN-APOLICOB. */
            W.IN_APOLICOB.Value = W.IN_APOLICOB + 1;

            /*" -995- PERFORM R1100_00_INSERT_APOLICOB_DB_INSERT_1 */

            R1100_00_INSERT_APOLICOB_DB_INSERT_1();

            /*" -999- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1000- DISPLAY 'R1100-00 - PROBLEMAS NO INSERT(APOLICOB)   ' */
                _.Display($"R1100-00 - PROBLEMAS NO INSERT(APOLICOB)   ");

                /*" -1001- DISPLAY ' APOLICE    = ' APOLICOB-NUM-APOLICE */
                _.Display($" APOLICE    = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}");

                /*" -1002- DISPLAY ' ENDOSSO    = ' APOLICOB-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}");

                /*" -1003- DISPLAY ' ITEM       = ' APOLICOB-NUM-ITEM */
                _.Display($" ITEM       = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM}");

                /*" -1004- DISPLAY ' OCORHIST   = ' APOLICOB-OCORR-HISTORICO */
                _.Display($" OCORHIST   = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO}");

                /*" -1005- DISPLAY ' RAMO       = ' APOLICOB-RAMO-COBERTURA */
                _.Display($" RAMO       = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}");

                /*" -1006- DISPLAY ' COBERTURA  = ' APOLICOB-COD-COBERTURA */
                _.Display($" COBERTURA  = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA}");

                /*" -1006- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-INSERT-APOLICOB-DB-INSERT-1 */
        public void R1100_00_INSERT_APOLICOB_DB_INSERT_1()
        {
            /*" -995- EXEC SQL INSERT INTO SEGUROS.APOLICE_COBERTURAS (NUM_APOLICE ,NUM_ENDOSSO ,NUM_ITEM ,OCORR_HISTORICO ,RAMO_COBERTURA ,MODALI_COBERTURA ,COD_COBERTURA ,IMP_SEGURADA_IX ,PRM_TARIFARIO_IX ,IMP_SEGURADA_VAR ,PRM_TARIFARIO_VAR ,PCT_COBERTURA ,FATOR_MULTIPLICA ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,COD_EMPRESA ,TIMESTAMP ,SIT_REGISTRO) VALUES (:APOLICOB-NUM-APOLICE ,:APOLICOB-NUM-ENDOSSO ,:APOLICOB-NUM-ITEM ,:APOLICOB-OCORR-HISTORICO ,:APOLICOB-RAMO-COBERTURA ,:APOLICOB-MODALI-COBERTURA ,:APOLICOB-COD-COBERTURA ,:APOLICOB-IMP-SEGURADA-IX ,:APOLICOB-PRM-TARIFARIO-IX ,:APOLICOB-IMP-SEGURADA-VAR ,:APOLICOB-PRM-TARIFARIO-VAR ,:APOLICOB-PCT-COBERTURA ,:APOLICOB-FATOR-MULTIPLICA ,:APOLICOB-DATA-INIVIGENCIA ,:APOLICOB-DATA-TERVIGENCIA ,:APOLICOB-COD-EMPRESA:VIND-NULL01 , CURRENT TIMESTAMP ,:APOLICOB-SIT-REGISTRO:VIND-NULL02) END-EXEC. */

            var r1100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 = new R1100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1()
            {
                APOLICOB_NUM_APOLICE = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.ToString(),
                APOLICOB_NUM_ENDOSSO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.ToString(),
                APOLICOB_NUM_ITEM = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM.ToString(),
                APOLICOB_OCORR_HISTORICO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO.ToString(),
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                APOLICOB_MODALI_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                APOLICOB_IMP_SEGURADA_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.ToString(),
                APOLICOB_PRM_TARIFARIO_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX.ToString(),
                APOLICOB_IMP_SEGURADA_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR.ToString(),
                APOLICOB_PRM_TARIFARIO_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR.ToString(),
                APOLICOB_PCT_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA.ToString(),
                APOLICOB_FATOR_MULTIPLICA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA.ToString(),
                APOLICOB_DATA_INIVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.ToString(),
                APOLICOB_DATA_TERVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.ToString(),
                APOLICOB_COD_EMPRESA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                APOLICOB_SIT_REGISTRO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
            };

            R1100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1.Execute(r1100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1017- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -1018- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -1019- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -1020- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, W.WABEND.WSQLERRMC);

            /*" -1022- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1022- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1026- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1026- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}