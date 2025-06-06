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
using Sias.VidaAzul.DB2.VA0143B;

namespace Code
{
    public class VA0143B
    {
        public bool IsCall { get; set; }

        public VA0143B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDAZUL                            *      */
        /*"      *   PROGRAMA ...............  VA0143B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  14/10/2020                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   AJUSTA VIGENCIA SEGUROS.ENDOSSOS E SEGUROS.APOLICE_COBERTURAS*      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.02                                               *      */
        /*"      *  JAZZ.....: 471.213            PROGRAMADOR: TERCIO CARVALHO    *      */
        /*"      *  DATA ....: 16/11/2023                                         *      */
        /*"      *  DESCRICAO: RETIRADA A QUEBRA POR APOLICE.                     *      */
        /*"      *                                          PROCURE POR V.02      *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.01                                               *      */
        /*"      *  JAZZ.....: 471.213            PROGRAMADOR: TERCIO CARVALHO    *      */
        /*"      *  DATA ....: 16/11/2023                                         *      */
        /*"      *  DESCRICAO: VOLTA A GERAR ENDOSSOS DE COBRANCAS MENSAIS        *      */
        /*"      *             COM INICIO E TERMINO DE VIGENCIA CORRESPONDENTES   *      */
        /*"      *             AO MES DE VENCIMENTO DA FATURA EM FUNCAO DE        *      */
        /*"      *             APONTAMENTO DE AUDITORIA.                          *      */
        /*"      *                                          PROCURE POR V.01      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public SortBasis<VA0143B_REG_SVA0143B> SVA0143B { get; set; } = new SortBasis<VA0143B_REG_SVA0143B>(new VA0143B_REG_SVA0143B());
        /*"01         REG-SVA0143B.*/
        public VA0143B_REG_SVA0143B REG_SVA0143B { get; set; } = new VA0143B_REG_SVA0143B();
        public class VA0143B_REG_SVA0143B : VarBasis
        {
            /*"  05       SOR-NUM-CERTIFICADO   PIC  9(015).*/
            public IntBasis SOR_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       SOR-NUM-PARCELA       PIC  9(004).*/
            public IntBasis SOR_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-TIPO-ENDOSSO      PIC  X(001).*/
            public StringBasis SOR_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-COD-SUBGRUPO      PIC  9(009).*/
            public IntBasis SOR_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-NUM-APOLICE       PIC  9(013).*/
            public IntBasis SOR_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       SOR-NUM-ENDOSSO       PIC  9(009).*/
            public IntBasis SOR_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-DATA-EMISSAO      PIC  X(010).*/
            public StringBasis SOR_DATA_EMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-DATA-INIVIGENCIA  PIC  X(010).*/
            public StringBasis SOR_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-DATA-TERVIGENCIA  PIC  X(010).*/
            public StringBasis SOR_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-PERI-PAGAMENTO    PIC  9(004).*/
            public IntBasis SOR_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    WHOST-NUM-APOL-ANT        PIC S9(015)     COMP-3 VALUE +0.*/
        public IntBasis WHOST_NUM_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WHOST-DTINIVIG            PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DTTERVIG            PIC  X(010).*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DTINI01             PIC  X(010).*/
        public StringBasis WHOST_DTINI01 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DTTER01             PIC  X(010).*/
        public StringBasis WHOST_DTTER01 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-PERI                PIC S9(009)     COMP.*/
        public IntBasis WHOST_PERI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WHOST-DATA-INIVIGENCIA    PIC  X(010).*/
        public StringBasis WHOST_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DATA-TERVIGENCIA    PIC  X(010).*/
        public StringBasis WHOST_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  W.*/
        public VA0143B_W W { get; set; } = new VA0143B_W();
        public class VA0143B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-SORT                 PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-APOLICOB             PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_APOLICOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-PARCEVID             PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_PARCEVID { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-OPCPAGVI             PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_OPCPAGVI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-RCAPS                PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_RCAPS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  AC-FATURA                 PIC  X(001)         VALUE SPACES*/
            public StringBasis AC_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-HISCONPA               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis LD_HISCONPA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  TP-ENDOSSO                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis TP_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-PARCELAS               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis AC_PARCELAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-ADESAO                 PIC  9(009)         VALUE ZEROS.*/
            public IntBasis AC_ADESAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-VIGENCIA               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_VIGENCIA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-ENDOSSOS               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis UP_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  LD-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-ENDOSSO                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-PARCELA                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_PARCELA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-VIGENCIA1              PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_VIGENCIA1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-ENDOSSOS1              PIC  9(009)         VALUE ZEROS.*/
            public IntBasis UP_ENDOSSOS1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-FATURA                 PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_FATURA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_VA0143B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VA0143B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VA0143B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_VA0143B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VA0143B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VA0143B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_VA0143B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_VA0143B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VA0143B_FILLER_1 : VarBasis
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

                public _REDEF_VA0143B_FILLER_1()
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
            private _REDEF_VA0143B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_VA0143B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_VA0143B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VA0143B_FILLER_4 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public VA0143B_WTIME_DAYR WTIME_DAYR { get; set; } = new VA0143B_WTIME_DAYR();
                public class VA0143B_WTIME_DAYR : VarBasis
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

                    public VA0143B_WTIME_DAYR()
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

                public _REDEF_VA0143B_FILLER_4()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public VA0143B_WS_TIME WS_TIME { get; set; } = new VA0143B_WS_TIME();
            public class VA0143B_WS_TIME : VarBasis
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
            public VA0143B_WABEND WABEND { get; set; } = new VA0143B_WABEND();
            public class VA0143B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' VA0143B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0143B  ");
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
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public VA0143B_V0HISCONPA V0HISCONPA { get; set; } = new VA0143B_V0HISCONPA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SVA0143B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SVA0143B.SetFile(SVA0143B_FILE_NAME_P);

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
            /*" -182- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -183- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -185- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -187- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -190- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -191- DISPLAY '           VA0143B - AJUSTE DE VIGENCIA           ' */
            _.Display($"           VA0143B - AJUSTE DE VIGENCIA           ");

            /*" -192- DISPLAY ' ' */
            _.Display($" ");

            /*" -193- DISPLAY 'VERSAO V.02 : ' FUNCTION WHEN-COMPILED ' - 471.213' */

            $"VERSAO V.02 : FUNCTION{_.WhenCompiled()} - 471.213"
            .Display();

            /*" -194- DISPLAY ' ' */
            _.Display($" ");

            /*" -201- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -202- DISPLAY '   ' */
            _.Display($"   ");

            /*" -204- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -207- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -219- SORT SVA0143B ON ASCENDING KEY SOR-TIPO-ENDOSSO SOR-NUM-CERTIFICADO SOR-NUM-PARCELA SOR-NUM-APOLICE SOR-NUM-ENDOSSO INPUT PROCEDURE R0190-00-SELECIONA THRU R0190-99-SAIDA OUTPUT PROCEDURE R0500-00-PROCESSA-SORT THRU R0500-99-SAIDA. */
            SVA0143B.Sort("SOR-TIPO-ENDOSSO,SOR-NUM-CERTIFICADO,SOR-NUM-PARCELA,SOR-NUM-APOLICE,SOR-NUM-ENDOSSO", () => R0190_00_SELECIONA_SECTION(), () => R0500_00_PROCESSA_SORT_SECTION());

            /*" -223- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -224- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -225- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -226- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -227- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -228- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -228- DISPLAY 'FIM    VA0143B    ' WTIME-DAYR. */
            _.Display($"FIM    VA0143B    {W.FILLER_4.WTIME_DAYR}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -233- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -237- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -238- DISPLAY ' ' */
            _.Display($" ");

            /*" -239- DISPLAY 'VA0143B - FIM NORMAL' */
            _.Display($"VA0143B - FIM NORMAL");

            /*" -242- DISPLAY ' ' */
            _.Display($" ");

            /*" -242- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -251- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", W.WABEND.WNR_EXEC_SQL);

            /*" -252- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -253- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -254- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -255- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -256- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -257- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -260- DISPLAY 'INICIO VA0143B    ' WTIME-DAYR. */
            _.Display($"INICIO VA0143B    {W.FILLER_4.WTIME_DAYR}");

            /*" -263- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -264- DISPLAY ' ' . */
            _.Display($" ");

            /*" -266- DISPLAY 'DATA DE MOVIMENTO ..... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DE MOVIMENTO ..... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -269- DISPLAY ' ' . */
            _.Display($" ");

            /*" -269- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -282- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -289- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -293- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -294- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -294- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -289- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

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
            /*" -307- MOVE '0190' TO WNR-EXEC-SQL. */
            _.Move("0190", W.WABEND.WNR_EXEC_SQL);

            /*" -308- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -309- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -310- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -311- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -312- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -313- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -315- DISPLAY 'DECLARE HISCONPA  ' WTIME-DAYR. */
            _.Display($"DECLARE HISCONPA  {W.FILLER_4.WTIME_DAYR}");

            /*" -316- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -318- PERFORM R0200-00-DECLARE-HISCONPA. */

            R0200_00_DECLARE_HISCONPA_SECTION();

            /*" -320- PERFORM R0210-00-FETCH-HISCONPA. */

            R0210_00_FETCH_HISCONPA_SECTION();

            /*" -324- PERFORM R0220-00-PROCESSA-HISCONPA UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0220_00_PROCESSA_HISCONPA_SECTION();
            }

            /*" -324- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -328- DISPLAY ' ' . */
            _.Display($" ");

            /*" -329- DISPLAY 'LIDOS HISCONPA ............. ' LD-HISCONPA */
            _.Display($"LIDOS HISCONPA ............. {W.LD_HISCONPA}");

            /*" -330- DISPLAY ' ' . */
            _.Display($" ");

            /*" -331- DISPLAY 'PARCELA ADESAO ............. ' AC-ADESAO */
            _.Display($"PARCELA ADESAO ............. {W.AC_ADESAO}");

            /*" -332- DISPLAY 'VIGENCIA OK ................ ' DP-VIGENCIA */
            _.Display($"VIGENCIA OK ................ {W.DP_VIGENCIA}");

            /*" -333- DISPLAY 'ALTERA VIGENCIA ............ ' UP-ENDOSSOS */
            _.Display($"ALTERA VIGENCIA ............ {W.UP_ENDOSSOS}");

            /*" -334- DISPLAY ' ' . */
            _.Display($" ");

            /*" -335- DISPLAY 'TIPO ENDOSSO 3 ............. ' TP-ENDOSSO */
            _.Display($"TIPO ENDOSSO 3 ............. {W.TP_ENDOSSO}");

            /*" -336- DISPLAY 'DEMAIS PARCELAS ............ ' AC-PARCELAS */
            _.Display($"DEMAIS PARCELAS ............ {W.AC_PARCELAS}");

            /*" -337- DISPLAY ' ' . */
            _.Display($" ");

            /*" -338- DISPLAY 'GRAVADOS SORT .............. ' GV-SORT. */
            _.Display($"GRAVADOS SORT .............. {W.GV_SORT}");

            /*" -338- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0190_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-HISCONPA-SECTION */
        private void R0200_00_DECLARE_HISCONPA_SECTION()
        {
            /*" -351- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", W.WABEND.WNR_EXEC_SQL);

            /*" -374- PERFORM R0200_00_DECLARE_HISCONPA_DB_DECLARE_1 */

            R0200_00_DECLARE_HISCONPA_DB_DECLARE_1();

            /*" -376- PERFORM R0200_00_DECLARE_HISCONPA_DB_OPEN_1 */

            R0200_00_DECLARE_HISCONPA_DB_OPEN_1();

            /*" -380- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -381- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (HISCONPA)  ' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (HISCONPA)  ");

                /*" -381- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-HISCONPA-DB-DECLARE-1 */
        public void R0200_00_DECLARE_HISCONPA_DB_DECLARE_1()
        {
            /*" -374- EXEC SQL DECLARE V0HISCONPA CURSOR WITH HOLD FOR SELECT A.NUM_APOLICE ,A.COD_SUBGRUPO ,A.NUM_CERTIFICADO ,A.NUM_PARCELA ,A.COD_SUBGRUPO ,F.NUM_APOLICE ,F.NUM_ENDOSSO ,F.DATA_EMISSAO ,F.DATA_INIVIGENCIA ,F.DATA_TERVIGENCIA ,F.TIPO_ENDOSSO FROM SEGUROS.HIST_CONT_PARCELVA A ,SEGUROS.ENDOSSOS F WHERE F.DATA_EMISSAO = :SISTEMAS-DATA-MOV-ABERTO AND F.NUM_ENDOSSO > 0 AND F.TIPO_ENDOSSO IN ( '1' , '3' ) AND A.NUM_APOLICE = F.NUM_APOLICE AND A.NUM_ENDOSSO = F.NUM_ENDOSSO ORDER BY A.NUM_CERTIFICADO ,A.NUM_PARCELA END-EXEC. */
            V0HISCONPA = new VA0143B_V0HISCONPA(true);
            string GetQuery_V0HISCONPA()
            {
                var query = @$"SELECT 
							A.NUM_APOLICE 
							,A.COD_SUBGRUPO 
							,A.NUM_CERTIFICADO 
							,A.NUM_PARCELA 
							,A.COD_SUBGRUPO 
							,F.NUM_APOLICE 
							,F.NUM_ENDOSSO 
							,F.DATA_EMISSAO 
							,F.DATA_INIVIGENCIA 
							,F.DATA_TERVIGENCIA 
							,F.TIPO_ENDOSSO 
							FROM SEGUROS.HIST_CONT_PARCELVA A 
							,SEGUROS.ENDOSSOS F 
							WHERE F.DATA_EMISSAO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND F.NUM_ENDOSSO > 0 
							AND F.TIPO_ENDOSSO IN ( '1'
							, '3' ) 
							AND A.NUM_APOLICE = F.NUM_APOLICE 
							AND A.NUM_ENDOSSO = F.NUM_ENDOSSO 
							ORDER BY A.NUM_CERTIFICADO 
							,A.NUM_PARCELA";

                return query;
            }
            V0HISCONPA.GetQueryEvent += GetQuery_V0HISCONPA;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-HISCONPA-DB-OPEN-1 */
        public void R0200_00_DECLARE_HISCONPA_DB_OPEN_1()
        {
            /*" -376- EXEC SQL OPEN V0HISCONPA END-EXEC. */

            V0HISCONPA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-HISCONPA-SECTION */
        private void R0210_00_FETCH_HISCONPA_SECTION()
        {
            /*" -394- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", W.WABEND.WNR_EXEC_SQL);

            /*" -407- PERFORM R0210_00_FETCH_HISCONPA_DB_FETCH_1 */

            R0210_00_FETCH_HISCONPA_DB_FETCH_1();

            /*" -411- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -411- PERFORM R0210_00_FETCH_HISCONPA_DB_CLOSE_1 */

                R0210_00_FETCH_HISCONPA_DB_CLOSE_1();

                /*" -413- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -415- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -416- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -417- DISPLAY 'R0210-00 - PROBLEMAS FETCH   (HISCONPA)  ' */
                _.Display($"R0210-00 - PROBLEMAS FETCH   (HISCONPA)  ");

                /*" -420- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -422- ADD 1 TO LD-HISCONPA. */
            W.LD_HISCONPA.Value = W.LD_HISCONPA + 1;

            /*" -424- MOVE LD-HISCONPA TO AC-LIDOS. */
            _.Move(W.LD_HISCONPA, W.AC_LIDOS);

            /*" -426- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -427- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -428- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -429- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -430- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -431- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -432- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -433- DISPLAY 'LIDOS HISCONPA     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS HISCONPA     {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0210-00-FETCH-HISCONPA-DB-FETCH-1 */
        public void R0210_00_FETCH_HISCONPA_DB_FETCH_1()
        {
            /*" -407- EXEC SQL FETCH V0HISCONPA INTO :HISCONPA-NUM-APOLICE ,:HISCONPA-COD-SUBGRUPO ,:HISCONPA-NUM-CERTIFICADO ,:HISCONPA-NUM-PARCELA ,:HISCONPA-COD-SUBGRUPO ,:ENDOSSOS-NUM-APOLICE ,:ENDOSSOS-NUM-ENDOSSO ,:ENDOSSOS-DATA-EMISSAO ,:ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA ,:ENDOSSOS-TIPO-ENDOSSO END-EXEC. */

            if (V0HISCONPA.Fetch())
            {
                _.Move(V0HISCONPA.HISCONPA_NUM_APOLICE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE);
                _.Move(V0HISCONPA.HISCONPA_COD_SUBGRUPO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO);
                _.Move(V0HISCONPA.HISCONPA_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);
                _.Move(V0HISCONPA.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(V0HISCONPA.HISCONPA_COD_SUBGRUPO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO);
                _.Move(V0HISCONPA.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(V0HISCONPA.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(V0HISCONPA.ENDOSSOS_DATA_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);
                _.Move(V0HISCONPA.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(V0HISCONPA.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(V0HISCONPA.ENDOSSOS_TIPO_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-HISCONPA-DB-CLOSE-1 */
        public void R0210_00_FETCH_HISCONPA_DB_CLOSE_1()
        {
            /*" -411- EXEC SQL CLOSE V0HISCONPA END-EXEC */

            V0HISCONPA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-PROCESSA-HISCONPA-SECTION */
        private void R0220_00_PROCESSA_HISCONPA_SECTION()
        {
            /*" -448- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", W.WABEND.WNR_EXEC_SQL);

            /*" -450- PERFORM R0240-00-SELECT-PRODUVG */

            R0240_00_SELECT_PRODUVG_SECTION();

            /*" -451- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -452- GO TO R0220-90-LEITURA */

                R0220_90_LEITURA(); //GOTO
                return;

                /*" -454- END-IF */
            }


            /*" -456- PERFORM R0250-00-SELECT-PARCEVID. */

            R0250_00_SELECT_PARCEVID_SECTION();

            /*" -459- PERFORM R0260-00-SELECT-OPCPAGVI. */

            R0260_00_SELECT_OPCPAGVI_SECTION();

            /*" -460- IF ENDOSSOS-TIPO-ENDOSSO EQUAL '3' */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO == "3")
            {

                /*" -461- ADD 1 TO TP-ENDOSSO */
                W.TP_ENDOSSO.Value = W.TP_ENDOSSO + 1;

                /*" -462- PERFORM R0300-00-GRAVA-SORT */

                R0300_00_GRAVA_SORT_SECTION();

                /*" -465- GO TO R0220-90-LEITURA. */

                R0220_90_LEITURA(); //GOTO
                return;
            }


            /*" -469- MOVE SPACES TO WHOST-DTINIVIG WHOST-DTTERVIG. */
            _.Move("", WHOST_DTINIVIG, WHOST_DTTERVIG);

            /*" -470- IF HISCONPA-NUM-PARCELA EQUAL 1 */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA == 1)
            {

                /*" -471- ADD 1 TO AC-ADESAO */
                W.AC_ADESAO.Value = W.AC_ADESAO + 1;

                /*" -472- PERFORM R0360-00-VER-VIGENCIA */

                R0360_00_VER_VIGENCIA_SECTION();

                /*" -473- ELSE */
            }
            else
            {


                /*" -474- ADD 1 TO AC-PARCELAS */
                W.AC_PARCELAS.Value = W.AC_PARCELAS + 1;

                /*" -475- PERFORM R0300-00-GRAVA-SORT */

                R0300_00_GRAVA_SORT_SECTION();

                /*" -478- GO TO R0220-90-LEITURA. */

                R0220_90_LEITURA(); //GOTO
                return;
            }


            /*" -480- IF ENDOSSOS-DATA-INIVIGENCIA EQUAL WHOST-DTINIVIG AND ENDOSSOS-DATA-TERVIGENCIA EQUAL WHOST-DTTERVIG */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA == WHOST_DTINIVIG && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA == WHOST_DTTERVIG)
            {

                /*" -481- ADD 1 TO DP-VIGENCIA */
                W.DP_VIGENCIA.Value = W.DP_VIGENCIA + 1;

                /*" -482- ELSE */
            }
            else
            {


                /*" -484- IF WHOST-DTINIVIG NOT EQUAL SPACES AND WHOST-DTTERVIG NOT EQUAL SPACES */

                if (!WHOST_DTINIVIG.IsEmpty() && !WHOST_DTTERVIG.IsEmpty())
                {

                    /*" -485- ADD 1 TO UP-ENDOSSOS */
                    W.UP_ENDOSSOS.Value = W.UP_ENDOSSOS + 1;

                    /*" -486- PERFORM R0400-00-UPDATE-ENDOSSOS */

                    R0400_00_UPDATE_ENDOSSOS_SECTION();

                    /*" -487- ELSE */
                }
                else
                {


                    /*" -487- PERFORM R0300-00-GRAVA-SORT. */

                    R0300_00_GRAVA_SORT_SECTION();
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0220_90_LEITURA */

            R0220_90_LEITURA();

        }

        [StopWatch]
        /*" R0220-90-LEITURA */
        private void R0220_90_LEITURA(bool isPerform = false)
        {
            /*" -492- PERFORM R0210-00-FETCH-HISCONPA. */

            R0210_00_FETCH_HISCONPA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0240-00-SELECT-PRODUVG-SECTION */
        private void R0240_00_SELECT_PRODUVG_SECTION()
        {
            /*" -504- MOVE '0240' TO WNR-EXEC-SQL. */
            _.Move("0240", W.WABEND.WNR_EXEC_SQL);

            /*" -513- PERFORM R0240_00_SELECT_PRODUVG_DB_SELECT_1 */

            R0240_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -517- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -519- MOVE ENDOSSOS-DATA-EMISSAO TO PARCEVID-DATA-VENCIMENTO */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO);

                /*" -520- ELSE */
            }
            else
            {


                /*" -521- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -524- DISPLAY 'R0240-00 - PROBLEMAS NO SELECT(PRODUVG)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' PARCELA     = ' HISCONPA-NUM-PARCELA */

                    $"R0240-00 - PROBLEMAS NO SELECT(PRODUVG) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}"
                    .Display();

                    /*" -524- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0240-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R0240_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -513- EXEC SQL SELECT ORIG_PRODU INTO :PRODUVG-ORIG-PRODU FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND COD_SUBGRUPO = :HISCONPA-COD-SUBGRUPO AND ORIG_PRODU = 'ESPEC' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                HISCONPA_COD_SUBGRUPO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO.ToString(),
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_ORIG_PRODU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-SELECT-PARCEVID-SECTION */
        private void R0250_00_SELECT_PARCEVID_SECTION()
        {
            /*" -536- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", W.WABEND.WNR_EXEC_SQL);

            /*" -544- PERFORM R0250_00_SELECT_PARCEVID_DB_SELECT_1 */

            R0250_00_SELECT_PARCEVID_DB_SELECT_1();

            /*" -548- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -550- MOVE ENDOSSOS-DATA-EMISSAO TO PARCEVID-DATA-VENCIMENTO */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO);

                /*" -551- ELSE */
            }
            else
            {


                /*" -552- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -555- DISPLAY 'R0250-00 - PROBLEMAS NO SELECT(PARCEVID)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' PARCELA     = ' HISCONPA-NUM-PARCELA */

                    $"R0250-00 - PROBLEMAS NO SELECT(PARCEVID) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}"
                    .Display();

                    /*" -555- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0250-00-SELECT-PARCEVID-DB-SELECT-1 */
        public void R0250_00_SELECT_PARCEVID_DB_SELECT_1()
        {
            /*" -544- EXEC SQL SELECT DATA_VENCIMENTO INTO :PARCEVID-DATA-VENCIMENTO FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1 = new R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1.Execute(r0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEVID_DATA_VENCIMENTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-SELECT-OPCPAGVI-SECTION */
        private void R0260_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -568- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", W.WABEND.WNR_EXEC_SQL);

            /*" -585- PERFORM R0260_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R0260_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -589- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -590- PERFORM R0270-00-SELECT-OPCPAGVI */

                R0270_00_SELECT_OPCPAGVI_SECTION();

                /*" -591- ELSE */
            }
            else
            {


                /*" -592- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -595- DISPLAY 'R0260-00 - PROBLEMAS NO SELECT(OPCPAGVI)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' VENCIMENTO  = ' PARCEVID-DATA-VENCIMENTO */

                    $"R0260-00 - PROBLEMAS NO SELECT(OPCPAGVI) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} VENCIMENTO  = {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO}"
                    .Display();

                    /*" -595- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0260-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R0260_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -585- EXEC SQL SELECT DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,OPCAO_PAGAMENTO ,PERI_PAGAMENTO ,DIA_DEBITO INTO :OPCPAGVI-DATA-INIVIGENCIA ,:OPCPAGVI-DATA-TERVIGENCIA ,:OPCPAGVI-OPCAO-PAGAMENTO ,:OPCPAGVI-PERI-PAGAMENTO ,:OPCPAGVI-DIA-DEBITO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND DATA_INIVIGENCIA <= :PARCEVID-DATA-VENCIMENTO AND DATA_TERVIGENCIA >= :PARCEVID-DATA-VENCIMENTO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                PARCEVID_DATA_VENCIMENTO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO.ToString(),
            };

            var executed_1 = R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_DATA_INIVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA);
                _.Move(executed_1.OPCPAGVI_DATA_TERVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA);
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0270-00-SELECT-OPCPAGVI-SECTION */
        private void R0270_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -608- MOVE '0270' TO WNR-EXEC-SQL. */
            _.Move("0270", W.WABEND.WNR_EXEC_SQL);

            /*" -624- PERFORM R0270_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R0270_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -628- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -632- MOVE SPACES TO OPCPAGVI-DATA-INIVIGENCIA OPCPAGVI-DATA-TERVIGENCIA OPCPAGVI-OPCAO-PAGAMENTO */
                _.Move("", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                /*" -635- MOVE ZEROS TO OPCPAGVI-PERI-PAGAMENTO OPCPAGVI-DIA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);

                /*" -636- ELSE */
            }
            else
            {


                /*" -637- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -639- DISPLAY 'R0270-00 - PROBLEMAS NO SELECT(OPCPAGVI)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */

                    $"R0270-00 - PROBLEMAS NO SELECT(OPCPAGVI) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}"
                    .Display();

                    /*" -639- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0270-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R0270_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -624- EXEC SQL SELECT DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,OPCAO_PAGAMENTO ,PERI_PAGAMENTO ,DIA_DEBITO INTO :OPCPAGVI-DATA-INIVIGENCIA ,:OPCPAGVI-DATA-TERVIGENCIA ,:OPCPAGVI-OPCAO-PAGAMENTO ,:OPCPAGVI-PERI-PAGAMENTO ,:OPCPAGVI-DIA-DEBITO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0270_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R0270_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0270_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r0270_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_DATA_INIVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA);
                _.Move(executed_1.OPCPAGVI_DATA_TERVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA);
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-GRAVA-SORT-SECTION */
        private void R0300_00_GRAVA_SORT_SECTION()
        {
            /*" -652- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -654- MOVE SPACES TO REG-SVA0143B. */
            _.Move("", REG_SVA0143B);

            /*" -656- MOVE HISCONPA-NUM-CERTIFICADO TO SOR-NUM-CERTIFICADO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, REG_SVA0143B.SOR_NUM_CERTIFICADO);

            /*" -658- MOVE HISCONPA-NUM-PARCELA TO SOR-NUM-PARCELA. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, REG_SVA0143B.SOR_NUM_PARCELA);

            /*" -660- MOVE HISCONPA-COD-SUBGRUPO TO SOR-COD-SUBGRUPO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO, REG_SVA0143B.SOR_COD_SUBGRUPO);

            /*" -662- MOVE ENDOSSOS-NUM-APOLICE TO SOR-NUM-APOLICE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, REG_SVA0143B.SOR_NUM_APOLICE);

            /*" -664- MOVE ENDOSSOS-NUM-ENDOSSO TO SOR-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, REG_SVA0143B.SOR_NUM_ENDOSSO);

            /*" -666- MOVE ENDOSSOS-DATA-EMISSAO TO SOR-DATA-EMISSAO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO, REG_SVA0143B.SOR_DATA_EMISSAO);

            /*" -668- MOVE ENDOSSOS-DATA-INIVIGENCIA TO SOR-DATA-INIVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, REG_SVA0143B.SOR_DATA_INIVIGENCIA);

            /*" -670- MOVE ENDOSSOS-DATA-TERVIGENCIA TO SOR-DATA-TERVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, REG_SVA0143B.SOR_DATA_TERVIGENCIA);

            /*" -672- MOVE ENDOSSOS-TIPO-ENDOSSO TO SOR-TIPO-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO, REG_SVA0143B.SOR_TIPO_ENDOSSO);

            /*" -676- MOVE OPCPAGVI-PERI-PAGAMENTO TO SOR-PERI-PAGAMENTO. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO, REG_SVA0143B.SOR_PERI_PAGAMENTO);

            /*" -677- RELEASE REG-SVA0143B. */
            SVA0143B.Release(REG_SVA0143B);

            /*" -677- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0360-00-VER-VIGENCIA-SECTION */
        private void R0360_00_VER_VIGENCIA_SECTION()
        {
            /*" -690- MOVE '0360' TO WNR-EXEC-SQL. */
            _.Move("0360", W.WABEND.WNR_EXEC_SQL);

            /*" -692- PERFORM R0365-00-VIGENCIA-PARCELA1. */

            R0365_00_VIGENCIA_PARCELA1_SECTION();

            /*" -693- IF WHOST-DTINI01 EQUAL SPACES */

            if (WHOST_DTINI01.IsEmpty())
            {

                /*" -696- GO TO R0360-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/ //GOTO
                return;
            }


            /*" -697- IF WHOST-PERI EQUAL ZEROS */

            if (WHOST_PERI == 00)
            {

                /*" -700- MOVE 36 TO WHOST-PERI. */
                _.Move(36, WHOST_PERI);
            }


            /*" -700- PERFORM R0370-00-SELECT-CALENDAR. */

            R0370_00_SELECT_CALENDAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/

        [StopWatch]
        /*" R0365-00-VIGENCIA-PARCELA1-SECTION */
        private void R0365_00_VIGENCIA_PARCELA1_SECTION()
        {
            /*" -713- MOVE '0365' TO WNR-EXEC-SQL. */
            _.Move("0365", W.WABEND.WNR_EXEC_SQL);

            /*" -725- PERFORM R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1 */

            R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1();

            /*" -729- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -733- MOVE SPACES TO WHOST-DTINIVIG WHOST-DTTERVIG WHOST-DTINI01 */
                _.Move("", WHOST_DTINIVIG, WHOST_DTTERVIG, WHOST_DTINI01);

                /*" -734- ELSE */
            }
            else
            {


                /*" -735- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -737- DISPLAY 'R0365-00 - PROBLEMAS NO SELECT(HISCOBPR)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */

                    $"R0365-00 - PROBLEMAS NO SELECT(HISCOBPR) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}"
                    .Display();

                    /*" -737- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0365-00-VIGENCIA-PARCELA1-DB-SELECT-1 */
        public void R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1()
        {
            /*" -725- EXEC SQL SELECT B.DATA_INIVIGENCIA ,B.PERI_PAGAMENTO INTO :WHOST-DTINI01 ,:WHOST-PERI FROM SEGUROS.HIS_COBER_PROPOST A ,SEGUROS.OPCAO_PAG_VIDAZUL B WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND A.OCORR_HISTORICO = 1 AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1 = new R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1.Execute(r0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINI01, WHOST_DTINI01);
                _.Move(executed_1.WHOST_PERI, WHOST_PERI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0365_99_SAIDA*/

        [StopWatch]
        /*" R0370-00-SELECT-CALENDAR-SECTION */
        private void R0370_00_SELECT_CALENDAR_SECTION()
        {
            /*" -750- MOVE '0370' TO WNR-EXEC-SQL. */
            _.Move("0370", W.WABEND.WNR_EXEC_SQL);

            /*" -760- PERFORM R0370_00_SELECT_CALENDAR_DB_SELECT_1 */

            R0370_00_SELECT_CALENDAR_DB_SELECT_1();

            /*" -764- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -767- MOVE SPACES TO WHOST-DTINIVIG WHOST-DTTERVIG */
                _.Move("", WHOST_DTINIVIG, WHOST_DTTERVIG);

                /*" -768- ELSE */
            }
            else
            {


                /*" -769- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -772- DISPLAY 'R0370-00 - PROBLEMAS NO SELECT(CALENDAR)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' DATA        = ' WHOST-DTINI01 */

                    $"R0370-00 - PROBLEMAS NO SELECT(CALENDAR) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} DATA        = {WHOST_DTINI01}"
                    .Display();

                    /*" -773- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -774- ELSE */
                }
                else
                {


                    /*" -776- MOVE WHOST-DTINI01 TO WHOST-DTINIVIG */
                    _.Move(WHOST_DTINI01, WHOST_DTINIVIG);

                    /*" -777- MOVE WHOST-DTTER01 TO WHOST-DTTERVIG. */
                    _.Move(WHOST_DTTER01, WHOST_DTTERVIG);
                }

            }


        }

        [StopWatch]
        /*" R0370-00-SELECT-CALENDAR-DB-SELECT-1 */
        public void R0370_00_SELECT_CALENDAR_DB_SELECT_1()
        {
            /*" -760- EXEC SQL SELECT DATA_CALENDARIO ,DATA_CALENDARIO + :WHOST-PERI MONTHS - 1 DAYS INTO :WHOST-DTINI01 ,:WHOST-DTTER01 FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :WHOST-DTINI01 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1 = new R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1()
            {
                WHOST_DTINI01 = WHOST_DTINI01.ToString(),
                WHOST_PERI = WHOST_PERI.ToString(),
            };

            var executed_1 = R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1.Execute(r0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINI01, WHOST_DTINI01);
                _.Move(executed_1.WHOST_DTTER01, WHOST_DTTER01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-UPDATE-ENDOSSOS-SECTION */
        private void R0400_00_UPDATE_ENDOSSOS_SECTION()
        {
            /*" -790- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", W.WABEND.WNR_EXEC_SQL);

            /*" -792- MOVE WHOST-DTINIVIG TO ENDOSSOS-DATA-INIVIGENCIA. */
            _.Move(WHOST_DTINIVIG, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

            /*" -796- MOVE WHOST-DTTERVIG TO ENDOSSOS-DATA-TERVIGENCIA. */
            _.Move(WHOST_DTTERVIG, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

            /*" -803- PERFORM R0400_00_UPDATE_ENDOSSOS_DB_UPDATE_1 */

            R0400_00_UPDATE_ENDOSSOS_DB_UPDATE_1();

            /*" -807- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -808- DISPLAY 'R0400-00 - PROBLEMAS UPDATE (ENDOSSOS)' */
                _.Display($"R0400-00 - PROBLEMAS UPDATE (ENDOSSOS)");

                /*" -809- DISPLAY ' APOLICE   =  ' ENDOSSOS-NUM-APOLICE */
                _.Display($" APOLICE   =  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -810- DISPLAY ' ENDOSSO   =  ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($" ENDOSSO   =  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -813- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -814- ADD 1 TO UP-ENDOSSOS. */
            W.UP_ENDOSSOS.Value = W.UP_ENDOSSOS + 1;

            /*" -814- PERFORM R0410-00-UPDATE-APOLICOB. */

            R0410_00_UPDATE_APOLICOB_SECTION();

        }

        [StopWatch]
        /*" R0400-00-UPDATE-ENDOSSOS-DB-UPDATE-1 */
        public void R0400_00_UPDATE_ENDOSSOS_DB_UPDATE_1()
        {
            /*" -803- EXEC SQL UPDATE SEGUROS.ENDOSSOS SET DATA_INIVIGENCIA = :ENDOSSOS-DATA-INIVIGENCIA ,DATA_TERVIGENCIA = :ENDOSSOS-DATA-TERVIGENCIA WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO END-EXEC. */

            var r0400_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 = new R0400_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1()
            {
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                ENDOSSOS_DATA_TERVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.ToString(),
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            R0400_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1.Execute(r0400_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-UPDATE-APOLICOB-SECTION */
        private void R0410_00_UPDATE_APOLICOB_SECTION()
        {
            /*" -827- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", W.WABEND.WNR_EXEC_SQL);

            /*" -834- PERFORM R0410_00_UPDATE_APOLICOB_DB_UPDATE_1 */

            R0410_00_UPDATE_APOLICOB_DB_UPDATE_1();

            /*" -838- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -839- DISPLAY 'R0410-00 - PROBLEMAS UPDATE (APOLICOB)' */
                _.Display($"R0410-00 - PROBLEMAS UPDATE (APOLICOB)");

                /*" -840- DISPLAY ' APOLICE   =  ' ENDOSSOS-NUM-APOLICE */
                _.Display($" APOLICE   =  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -841- DISPLAY ' ENDOSSO   =  ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($" ENDOSSO   =  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -841- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0410-00-UPDATE-APOLICOB-DB-UPDATE-1 */
        public void R0410_00_UPDATE_APOLICOB_DB_UPDATE_1()
        {
            /*" -834- EXEC SQL UPDATE SEGUROS.APOLICE_COBERTURAS SET DATA_INIVIGENCIA = :ENDOSSOS-DATA-INIVIGENCIA ,DATA_TERVIGENCIA = :ENDOSSOS-DATA-TERVIGENCIA WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO END-EXEC. */

            var r0410_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1 = new R0410_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1()
            {
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                ENDOSSOS_DATA_TERVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.ToString(),
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            R0410_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1.Execute(r0410_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-PROCESSA-SORT-SECTION */
        private void R0500_00_PROCESSA_SORT_SECTION()
        {
            /*" -854- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", W.WABEND.WNR_EXEC_SQL);

            /*" -856- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -858- PERFORM R0510-00-LER-SORT. */

            R0510_00_LER_SORT_SECTION();

            /*" -859- IF WFIM-SORT NOT EQUAL SPACES */

            if (!W.WFIM_SORT.IsEmpty())
            {

                /*" -862- GO TO R0500-90-DISPLAY. */

                R0500_90_DISPLAY(); //GOTO
                return;
            }


            /*" -863- PERFORM R0520-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

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
            /*" -869- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -873- DISPLAY ' ' . */
            _.Display($" ");

            /*" -874- DISPLAY 'LIDOS SORT ................ ' LD-SORT */
            _.Display($"LIDOS SORT ................ {W.LD_SORT}");

            /*" -875- DISPLAY 'DESPREZA PARCELA .......... ' DP-PARCELA */
            _.Display($"DESPREZA PARCELA .......... {W.DP_PARCELA}");

            /*" -876- DISPLAY 'DESPREZA FATURA ........... ' DP-FATURA */
            _.Display($"DESPREZA FATURA ........... {W.DP_FATURA}");

            /*" -877- DISPLAY 'VIGENCIA OK ................ ' DP-VIGENCIA1 */
            _.Display($"VIGENCIA OK ................ {W.DP_VIGENCIA1}");

            /*" -878- DISPLAY 'ALTERA VIGENCIA ............ ' UP-ENDOSSOS1 */
            _.Display($"ALTERA VIGENCIA ............ {W.UP_ENDOSSOS1}");

            /*" -878- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-LER-SORT-SECTION */
        private void R0510_00_LER_SORT_SECTION()
        {
            /*" -891- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", W.WABEND.WNR_EXEC_SQL);

            /*" -893- RETURN SVA0143B AT END */
            try
            {
                SVA0143B.Return(REG_SVA0143B, () =>
                {

                    /*" -894- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -897- GO TO R0510-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -900- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

            /*" -902- MOVE LD-SORT TO AC-LIDOS. */
            _.Move(W.LD_SORT, W.AC_LIDOS);

            /*" -904- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -905- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -906- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -907- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -908- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -909- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -910- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -911- DISPLAY 'LIDOS SORT         ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS SORT         {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-PROCESSA-SORT-SECTION */
        private void R0520_00_PROCESSA_SORT_SECTION()
        {
            /*" -927- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", W.WABEND.WNR_EXEC_SQL);

            /*" -928- IF SOR-TIPO-ENDOSSO EQUAL '3' */

            if (REG_SVA0143B.SOR_TIPO_ENDOSSO == "3")
            {

                /*" -929- PERFORM R0630-00-SELECT-HISCONPA */

                R0630_00_SELECT_HISCONPA_SECTION();

                /*" -933- ELSE */
            }
            else
            {


                /*" -934- IF SOR-NUM-PARCELA GREATER 1 */

                if (REG_SVA0143B.SOR_NUM_PARCELA > 1)
                {

                    /*" -935- PERFORM R0640-00-SELECT-HISCONPA */

                    R0640_00_SELECT_HISCONPA_SECTION();

                    /*" -936- ELSE */
                }
                else
                {


                    /*" -937- ADD 1 TO DP-PARCELA */
                    W.DP_PARCELA.Value = W.DP_PARCELA + 1;

                    /*" -940- GO TO R0520-90-LEITURA. */

                    R0520_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -942- IF ENDOSSOS-DATA-INIVIGENCIA EQUAL SOR-DATA-INIVIGENCIA AND ENDOSSOS-DATA-TERVIGENCIA EQUAL SOR-DATA-TERVIGENCIA */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA == REG_SVA0143B.SOR_DATA_INIVIGENCIA && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA == REG_SVA0143B.SOR_DATA_TERVIGENCIA)
            {

                /*" -943- ADD 1 TO DP-VIGENCIA1 */
                W.DP_VIGENCIA1.Value = W.DP_VIGENCIA1 + 1;

                /*" -944- ELSE */
            }
            else
            {


                /*" -946- IF ENDOSSOS-DATA-INIVIGENCIA NOT EQUAL SPACES AND ENDOSSOS-DATA-TERVIGENCIA NOT EQUAL SPACES */

                if (!ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.IsEmpty() && !ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.IsEmpty())
                {

                    /*" -947- PERFORM R0600-00-UPDATE-ENDOSSOS */

                    R0600_00_UPDATE_ENDOSSOS_SECTION();

                    /*" -947- EXEC SQL COMMIT WORK END-EXEC */

                    DatabaseConnection.Instance.CommitTransaction();

                    /*" -949- ELSE */
                }
                else
                {


                    /*" -949- ADD 1 TO DP-FATURA. */
                    W.DP_FATURA.Value = W.DP_FATURA + 1;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0520_90_LEITURA */

            R0520_90_LEITURA();

        }

        [StopWatch]
        /*" R0520-90-LEITURA */
        private void R0520_90_LEITURA(bool isPerform = false)
        {
            /*" -954- PERFORM R0510-00-LER-SORT. */

            R0510_00_LER_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-UPDATE-ENDOSSOS-SECTION */
        private void R0600_00_UPDATE_ENDOSSOS_SECTION()
        {
            /*" -966- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", W.WABEND.WNR_EXEC_SQL);

            /*" -968- MOVE SOR-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(REG_SVA0143B.SOR_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -972- MOVE SOR-NUM-ENDOSSO TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(REG_SVA0143B.SOR_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -979- PERFORM R0600_00_UPDATE_ENDOSSOS_DB_UPDATE_1 */

            R0600_00_UPDATE_ENDOSSOS_DB_UPDATE_1();

            /*" -983- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -984- DISPLAY 'R0600-00 - PROBLEMAS UPDATE (ENDOSSOS)' */
                _.Display($"R0600-00 - PROBLEMAS UPDATE (ENDOSSOS)");

                /*" -985- DISPLAY ' APOLICE   =  ' ENDOSSOS-NUM-APOLICE */
                _.Display($" APOLICE   =  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -986- DISPLAY ' ENDOSSO   =  ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($" ENDOSSO   =  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -989- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -990- ADD 1 TO UP-ENDOSSOS1. */
            W.UP_ENDOSSOS1.Value = W.UP_ENDOSSOS1 + 1;

            /*" -990- PERFORM R0410-00-UPDATE-APOLICOB. */

            R0410_00_UPDATE_APOLICOB_SECTION();

        }

        [StopWatch]
        /*" R0600-00-UPDATE-ENDOSSOS-DB-UPDATE-1 */
        public void R0600_00_UPDATE_ENDOSSOS_DB_UPDATE_1()
        {
            /*" -979- EXEC SQL UPDATE SEGUROS.ENDOSSOS SET DATA_INIVIGENCIA = :ENDOSSOS-DATA-INIVIGENCIA ,DATA_TERVIGENCIA = :ENDOSSOS-DATA-TERVIGENCIA WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO END-EXEC. */

            var r0600_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 = new R0600_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1()
            {
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                ENDOSSOS_DATA_TERVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.ToString(),
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            R0600_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1.Execute(r0600_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0630-00-SELECT-HISCONPA-SECTION */
        private void R0630_00_SELECT_HISCONPA_SECTION()
        {
            /*" -1003- MOVE '0630' TO WNR-EXEC-SQL. */
            _.Move("0630", W.WABEND.WNR_EXEC_SQL);

            /*" -1005- MOVE SOR-NUM-CERTIFICADO TO HISCONPA-NUM-CERTIFICADO. */
            _.Move(REG_SVA0143B.SOR_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -1009- MOVE SOR-NUM-PARCELA TO HISCONPA-NUM-PARCELA. */
            _.Move(REG_SVA0143B.SOR_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -1036- PERFORM R0630_00_SELECT_HISCONPA_DB_SELECT_1 */

            R0630_00_SELECT_HISCONPA_DB_SELECT_1();

            /*" -1040- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1043- MOVE SPACES TO ENDOSSOS-DATA-INIVIGENCIA ENDOSSOS-DATA-TERVIGENCIA */
                _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                /*" -1044- ELSE */
            }
            else
            {


                /*" -1045- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1046- DISPLAY 'R0630-00 - PROBLEMAS SELECT  (HISCONPA)  ' */
                    _.Display($"R0630-00 - PROBLEMAS SELECT  (HISCONPA)  ");

                    /*" -1046- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0630-00-SELECT-HISCONPA-DB-SELECT-1 */
        public void R0630_00_SELECT_HISCONPA_DB_SELECT_1()
        {
            /*" -1036- EXEC SQL SELECT B.NUM_APOLICE ,B.NUM_ENDOSSO ,B.RAMO_EMISSOR ,B.COD_PRODUTO ,B.COD_SUBGRUPO ,B.COD_FONTE ,B.DATA_INIVIGENCIA ,B.DATA_TERVIGENCIA INTO :ENDOSSOS-NUM-APOLICE ,:ENDOSSOS-NUM-ENDOSSO ,:ENDOSSOS-RAMO-EMISSOR ,:ENDOSSOS-COD-PRODUTO ,:ENDOSSOS-COD-SUBGRUPO ,:ENDOSSOS-COD-FONTE ,:ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.HIST_CONT_PARCELVA A ,SEGUROS.ENDOSSOS B WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND A.NUM_PARCELA = :HISCONPA-NUM-PARCELA AND A.NUM_ENDOSSO <> 0 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.TIPO_ENDOSSO = '1' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1 = new R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1.Execute(r0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(executed_1.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_COD_SUBGRUPO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO);
                _.Move(executed_1.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0630_99_SAIDA*/

        [StopWatch]
        /*" R0640-00-SELECT-HISCONPA-SECTION */
        private void R0640_00_SELECT_HISCONPA_SECTION()
        {
            /*" -1059- MOVE '0640' TO WNR-EXEC-SQL. */
            _.Move("0640", W.WABEND.WNR_EXEC_SQL);

            /*" -1061- MOVE SOR-NUM-CERTIFICADO TO HISCONPA-NUM-CERTIFICADO. */
            _.Move(REG_SVA0143B.SOR_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -1063- MOVE SOR-NUM-PARCELA TO HISCONPA-NUM-PARCELA. */
            _.Move(REG_SVA0143B.SOR_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -1066- MOVE SOR-PERI-PAGAMENTO TO WHOST-PERI. */
            _.Move(REG_SVA0143B.SOR_PERI_PAGAMENTO, WHOST_PERI);

            /*" -1067- IF WHOST-PERI EQUAL ZEROS */

            if (WHOST_PERI == 00)
            {

                /*" -1070- MOVE 36 TO WHOST-PERI. */
                _.Move(36, WHOST_PERI);
            }


            /*" -1088- PERFORM R0640_00_SELECT_HISCONPA_DB_SELECT_1 */

            R0640_00_SELECT_HISCONPA_DB_SELECT_1();

            /*" -1092- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1094- MOVE SOR-DATA-EMISSAO TO CALENDAR-DATA-CALENDARIO */
                _.Move(REG_SVA0143B.SOR_DATA_EMISSAO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

                /*" -1095- PERFORM R0650-00-SELECT-CALENDAR */

                R0650_00_SELECT_CALENDAR_SECTION();

                /*" -1096- ELSE */
            }
            else
            {


                /*" -1097- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1098- DISPLAY 'R0640-00 - PROBLEMAS SELECT  (HISCONPA)  ' */
                    _.Display($"R0640-00 - PROBLEMAS SELECT  (HISCONPA)  ");

                    /*" -1098- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0640-00-SELECT-HISCONPA-DB-SELECT-1 */
        public void R0640_00_SELECT_HISCONPA_DB_SELECT_1()
        {
            /*" -1088- EXEC SQL SELECT A.NUM_PARCELA ,B.DATA_TERVIGENCIA + 1 DAYS ,B.DATA_TERVIGENCIA + :WHOST-PERI MONTHS INTO :HISCONPA-NUM-PARCELA ,:ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.HIST_CONT_PARCELVA A ,SEGUROS.ENDOSSOS B WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND A.NUM_PARCELA < :HISCONPA-NUM-PARCELA AND A.NUM_ENDOSSO <> 0 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.TIPO_ENDOSSO = '1' ORDER BY A.NUM_PARCELA DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1 = new R0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
                WHOST_PERI = WHOST_PERI.ToString(),
            };

            var executed_1 = R0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1.Execute(r0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0640_99_SAIDA*/

        [StopWatch]
        /*" R0650-00-SELECT-CALENDAR-SECTION */
        private void R0650_00_SELECT_CALENDAR_SECTION()
        {
            /*" -1111- MOVE '0650' TO WNR-EXEC-SQL. */
            _.Move("0650", W.WABEND.WNR_EXEC_SQL);

            /*" -1120- PERFORM R0650_00_SELECT_CALENDAR_DB_SELECT_1 */

            R0650_00_SELECT_CALENDAR_DB_SELECT_1();

            /*" -1124- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1127- MOVE SPACES TO ENDOSSOS-DATA-INIVIGENCIA ENDOSSOS-DATA-TERVIGENCIA */
                _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                /*" -1130- GO TO R0650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1131- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1133- DISPLAY 'R0650-00 - PROBLEMAS NO SELECT(CALENDAR)' ' DATA        = ' CALENDAR-DATA-CALENDARIO */

                $"R0650-00 - PROBLEMAS NO SELECT(CALENDAR) DATA        = {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}"
                .Display();

                /*" -1136- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1138- MOVE CALENDAR-DATA-CALENDARIO TO WDATA-REL. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, W.WDATA_REL);

            /*" -1139- MOVE 01 TO WDAT-REL-DIA. */
            _.Move(01, W.FILLER_1.WDAT_REL_DIA);

            /*" -1142- MOVE WDATA-REL TO ENDOSSOS-DATA-INIVIGENCIA. */
            _.Move(W.WDATA_REL, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

            /*" -1143- MOVE CALENDAR-DTH-ULT-DIA-MES TO ENDOSSOS-DATA-TERVIGENCIA. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

        }

        [StopWatch]
        /*" R0650-00-SELECT-CALENDAR-DB-SELECT-1 */
        public void R0650_00_SELECT_CALENDAR_DB_SELECT_1()
        {
            /*" -1120- EXEC SQL SELECT DATA_CALENDARIO ,DTH_ULT_DIA_MES INTO :CALENDAR-DATA-CALENDARIO ,:CALENDAR-DTH-ULT-DIA-MES FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0650_00_SELECT_CALENDAR_DB_SELECT_1_Query1 = new R0650_00_SELECT_CALENDAR_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R0650_00_SELECT_CALENDAR_DB_SELECT_1_Query1.Execute(r0650_00_SELECT_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.CALENDAR_DTH_ULT_DIA_MES, CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1154- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -1155- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -1156- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -1157- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, W.WABEND.WSQLERRMC);

            /*" -1159- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1159- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1163- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1163- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}