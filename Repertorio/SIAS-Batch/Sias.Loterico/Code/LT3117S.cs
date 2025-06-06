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
using Sias.Loterico.DB2.LT3117S;

namespace Code
{
    public class LT3117S
    {
        public bool IsCall { get; set; }

        public LT3117S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  LOTERICOS                          *      */
        /*"      *   PROGRAMA ...............  LT3117S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   COORDENADOR.............  LUIS FERNANDO GONCALVES            *      */
        /*"      *   ANALISTA ...............  JOSE G OLIVEIRA                    *      */
        /*"      *   PROGRAMADOR ............  JOSE G OLIVEIRA                    *      */
        /*"      *   DATA CODIFICACAO .......  OUT/2005                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  SUBROTINA PARA CALCULO DO PREMIO   *      */
        /*"      *                             A PARTIR DE DADOS INFORMADOS       *      */
        /*"      *                             I.S.                               *      */
        /*"      *                             TAXAS                              *      */
        /*"      *                                                                *      */
        /*"      *                             RENOVACAO 2006/2007/...            *      */
        /*"      *                                                                *      */
        /*"      *                             COPIA DA  LT3116S                  *      */
        /*"      *     CHAMADA POR: LT3020B                                       *      */
        /*"      *                  EM0010B                                       *      */
        /*"      *                  SPBLT021(LT3132S,LT3146S,LT3111S)             *      */
        /*"      *                  LT3084B                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * DADOS DE ENTRADA:                                              *      */
        /*"      * -----------------                                              *      */
        /*"      *                                                                *      */
        /*"      *        LT3117-COD-LOTERICO    -  CODIGO DO LOTERICO            *      */
        /*"      *        LT3117-QTD-PARCELAS    -  1 A 12                        *      */
        /*"      *        LT3117-DTINIVIG-APOLICE-  DATA INICIO VIG DA APOLICE    *      */
        /*"      *        LT3117-DTTERVIG-APOLICE   DATA TERMINO VIG DA APOLICE   *      */
        /*"      *                             CALCULADO A PARTIR DE 01/01/2007   *      */
        /*"      *        LT3117-TIPO-CALCULO    -  PR=PRO-RATA  PC=PRAZO CURTO   *      */
        /*"      *                             CALCULADO A PARTIR DE 01/01/2007   *      */
        /*"      *        LT3117-NUM-CLASSE-ADESAO  INDICE DA CLASSE              *      */
        /*"      *                                  VALORES 1 A 13                *      */
        /*"      *        LT3117-IMP-SEG         -  IMP.SEG 1 A 6                 *      */
        /*"      *        LT3117-TAXAS           -  TAXAS   1 A 6                 *      */
        /*"      *                                                                       */
        /*"      *-----------------------------------------------------------------      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01              LPARM.*/
        public LT3117S_LPARM LPARM { get; set; } = new LT3117S_LPARM();
        public class LT3117S_LPARM : VarBasis
        {
            /*"   03          LPARM01.*/
            public LT3117S_LPARM01 LPARM01 { get; set; } = new LT3117S_LPARM01();
            public class LT3117S_LPARM01 : VarBasis
            {
                /*"      05       LPARM01-DD      PIC  9(002).*/
                public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05       LPARM01-MM      PIC  9(002).*/
                public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05       LPARM01-AA      PIC  9(004).*/
                public IntBasis LPARM01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03          LPARM02         PIC S9(005)      COMP-3.*/
                public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    03          LPARM03.*/
                public LT3117S_LPARM03 LPARM03 { get; set; } = new LT3117S_LPARM03();
                public class LT3117S_LPARM03 : VarBasis
                {
                    /*"      05       LPARM03-DD      PIC  9(002).*/
                    public IntBasis LPARM03_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      05       LPARM03-MM      PIC  9(002).*/
                    public IntBasis LPARM03_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      05       LPARM03-AA      PIC  9(004).*/
                    public IntBasis LPARM03_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"01       WAREA-TRABALHO.*/
                }
            }
        }
        public LT3117S_WAREA_TRABALHO WAREA_TRABALHO { get; set; } = new LT3117S_WAREA_TRABALHO();
        public class LT3117S_WAREA_TRABALHO : VarBasis
        {
            /*"   05       HOST-COUNT                    PIC S9(004)  COMP.*/
            public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05       HOST-DATA-INI                 PIC  X(010).*/
            public StringBasis HOST_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05       HOST-DATA-FIM                 PIC  X(010).*/
            public StringBasis HOST_DATA_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05       WS-QTDIAS-VIGENCIA   PIC S9(004)  COMP.*/
            public IntBasis WS_QTDIAS_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05       WS-QTDIAS-DECORRIDOS PIC S9(004)  COMP.*/
            public IntBasis WS_QTDIAS_DECORRIDOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05       WS-QTDIAS-DECORRER   PIC S9(004)  COMP.*/
            public IntBasis WS_QTDIAS_DECORRER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05       V0APO-NUM-APOLICE    PIC S9(013)  COMP-3 VALUE +0.*/
            public IntBasis V0APO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"   05       VIND-NUM-TITULO      PIC S9(004)  COMP VALUE +0.*/
            public IntBasis VIND_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05       WS-FATOR                    PIC S9(009)V9(6)  COMP-3*/
            public DoubleBasis WS_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(009)V9(6)"), 6);
            /*"   05       WS-FATOR-S                 PIC ZZZZ9,999999.*/
            public DoubleBasis WS_FATOR_S { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZZZ9V999999."), 6);
            /*"   05       WS-PCT-PRM-ANUAL            PIC S9(003)V99    COMP-3*/
            public DoubleBasis WS_PCT_PRM_ANUAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"   05       WS-PCT-PRM-DECORRIDO       PIC S9(003)V99    COMP-3.*/
            public DoubleBasis WS_PCT_PRM_DECORRIDO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"   05       WS-PCT-COBERTURA           PIC S9(003)V9(9)  COMP-3.*/
            public DoubleBasis WS_PCT_COBERTURA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(9)"), 9);
            /*"   05       WS-PCT-IOF                 PIC S9(003)V9(6)  COMP-3.*/
            public DoubleBasis WS_PCT_IOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
            /*"   05         WS-DATE.*/
            public LT3117S_WS_DATE WS_DATE { get; set; } = new LT3117S_WS_DATE();
            public class LT3117S_WS_DATE : VarBasis
            {
                /*"     10       WS-AA-DATE         PIC  9(02).*/
                public IntBasis WS_AA_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10       WS-MM-DATE         PIC  9(02).*/
                public IntBasis WS_MM_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10       WS-DD-DATE         PIC  9(02).*/
                public IntBasis WS_DD_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05       WS-DATA-SQL-AUX               PIC X(10).*/
            }
            public StringBasis WS_DATA_SQL_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05       WS-DATA-SQL-AUX-R REDEFINES WS-DATA-SQL-AUX .*/
            private _REDEF_LT3117S_WS_DATA_SQL_AUX_R _ws_data_sql_aux_r { get; set; }
            public _REDEF_LT3117S_WS_DATA_SQL_AUX_R WS_DATA_SQL_AUX_R
            {
                get { _ws_data_sql_aux_r = new _REDEF_LT3117S_WS_DATA_SQL_AUX_R(); _.Move(WS_DATA_SQL_AUX, _ws_data_sql_aux_r); VarBasis.RedefinePassValue(WS_DATA_SQL_AUX, _ws_data_sql_aux_r, WS_DATA_SQL_AUX); _ws_data_sql_aux_r.ValueChanged += () => { _.Move(_ws_data_sql_aux_r, WS_DATA_SQL_AUX); }; return _ws_data_sql_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_sql_aux_r, WS_DATA_SQL_AUX); }
            }  //Redefines
            public class _REDEF_LT3117S_WS_DATA_SQL_AUX_R : VarBasis
            {
                /*"     10     WS-ANO-SQL-AUX                PIC 9(04).*/
                public IntBasis WS_ANO_SQL_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     10     FILLER                        PIC X(01).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-MES-SQL-AUX                PIC 9(02).*/
                public IntBasis WS_MES_SQL_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10     FILLER                        PIC X(01).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-DIA-SQL-AUX                PIC 9(02).*/
                public IntBasis WS_DIA_SQL_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05       WS-DATA-SQL.*/

                public _REDEF_LT3117S_WS_DATA_SQL_AUX_R()
                {
                    WS_ANO_SQL_AUX.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                    WS_MES_SQL_AUX.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WS_DIA_SQL_AUX.ValueChanged += OnValueChanged;
                }

            }
            public LT3117S_WS_DATA_SQL WS_DATA_SQL { get; set; } = new LT3117S_WS_DATA_SQL();
            public class LT3117S_WS_DATA_SQL : VarBasis
            {
                /*"     10     WS-ANO-SQL       PIC  9(004)          VALUE ZEROS.*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     10     FILLER           PIC  X(001)          VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     WS-MES-SQL       PIC  9(002)          VALUE ZEROS.*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     05     FILLER           PIC  X(001)          VALUE '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     05     WS-DIA-SQL       PIC  9(002)          VALUE ZEROS.*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05       WS-DISPLAY               PIC   X(01) VALUE ' '.*/
            }
            public StringBasis WS_DISPLAY { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"   05       WS-ERRO                  PIC   9(04).*/
            public IntBasis WS_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05       WS-QTD-PARCELAS          PIC   9(04).*/
            public IntBasis WS_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05       WTOTAL-PREMIO-BRUTO      PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_PREMIO_BRUTO { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WTOTAL-PREMIO-LIQNP      PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_PREMIO_LIQNP { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WTOTAL-PREMIO-LIQ1P      PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_PREMIO_LIQ1P { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WTOTAL-JURO-1P           PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_JURO_1P { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WTOTAL-JURO              PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_JURO { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WTOTAL-IOF               PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_IOF { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WS-IOF-PRIM              PIC   9(009)V99.*/
            public DoubleBasis WS_IOF_PRIM { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WS-IOF-OUTR              PIC   9(009)V99.*/
            public DoubleBasis WS_IOF_OUTR { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WS-IND                   PIC   9(006) VALUE 0.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05       WS-IND1                  PIC   9(006) VALUE 0.*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05 TAB-TAXAS-2007   COMP-3.*/
            public LT3117S_TAB_TAXAS_2007 TAB_TAXAS_2007 { get; set; } = new LT3117S_TAB_TAXAS_2007();
            public class LT3117S_TAB_TAXAS_2007 : VarBasis
            {
                /*"     10 TB-TAXAS-2007  PIC S9(03)V9(9) COMP-3 OCCURS 10 TIMES.*/
                public ListBasis<DoubleBasis, double> TB_TAXAS_2007 { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "3", "S9(03)V9(9)"), 10);
                /*"  05 TAB-PREMIO-LIQ   COMP-3.*/
            }
            public LT3117S_TAB_PREMIO_LIQ TAB_PREMIO_LIQ { get; set; } = new LT3117S_TAB_PREMIO_LIQ();
            public class LT3117S_TAB_PREMIO_LIQ : VarBasis
            {
                /*"     10 TB-PREMIO-LIQ  PIC S9(08)V99 COMP-3 OCCURS 10 TIMES.*/
                public ListBasis<DoubleBasis, double> TB_PREMIO_LIQ { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V99"), 10);
                /*"  05 TAB-PREMIO-LIQ-1PCL   COMP-3.*/
            }
            public LT3117S_TAB_PREMIO_LIQ_1PCL TAB_PREMIO_LIQ_1PCL { get; set; } = new LT3117S_TAB_PREMIO_LIQ_1PCL();
            public class LT3117S_TAB_PREMIO_LIQ_1PCL : VarBasis
            {
                /*"     10 TB-PREMIO-LIQ-1PCL PIC S9(08)V99 COMP-3 OCCURS 10 TIMES.*/
                public ListBasis<DoubleBasis, double> TB_PREMIO_LIQ_1PCL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V99"), 10);
                /*"  05 TAB-IOF       COMP-3.*/
            }
            public LT3117S_TAB_IOF TAB_IOF { get; set; } = new LT3117S_TAB_IOF();
            public class LT3117S_TAB_IOF : VarBasis
            {
                /*"     10 TB-IOF       PIC S9(08)V99 COMP-3 OCCURS 10 TIMES.*/
                public ListBasis<DoubleBasis, double> TB_IOF { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V99"), 10);
                /*"  05            WABEND.*/
            }
            public LT3117S_WABEND WABEND { get; set; } = new LT3117S_WABEND();
            public class LT3117S_WABEND : VarBasis
            {
                /*"    10          FILLER           PIC  X(008)      VALUE               'LT3117S '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"LT3117S ");
                /*"    10          FILLER           PIC  X(025)      VALUE               '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10          WNR-EXEC-SQL     PIC  X(004)      VALUE   '0000'*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10          FILLER           PIC  X(013)      VALUE               ' *** SQLCODE '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10          WSQLCODE         PIC  ZZZZZ999-   VALUE    ZEROS*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Copies.LBTB3100 LBTB3100 { get; set; } = new Copies.LBTB3100();
        public Copies.LBLT3142 LBLT3142 { get; set; } = new Copies.LBLT3142();
        public Copies.LBLT3117 LBLT3117 { get; set; } = new Copies.LBLT3117();
        public Dclgens.LOTERI01 LOTERI01 { get; set; } = new Dclgens.LOTERI01();
        public Dclgens.FCLOTERI FCLOTERI { get; set; } = new Dclgens.FCLOTERI();
        public Dclgens.FCCONBAN FCCONBAN { get; set; } = new Dclgens.FCCONBAN();
        public Dclgens.LTMVPRBO LTMVPRBO { get; set; } = new Dclgens.LTMVPRBO();
        public Dclgens.LTMVPRCO LTMVPRCO { get; set; } = new Dclgens.LTMVPRCO();
        public Dclgens.LTMVPROP LTMVPROP { get; set; } = new Dclgens.LTMVPROP();
        public Dclgens.LTSOLPAR LTSOLPAR { get; set; } = new Dclgens.LTSOLPAR();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PRAZOSEG PRAZOSEG { get; set; } = new Dclgens.PRAZOSEG();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBLT3117 LBLT3117_P) //PROCEDURE DIVISION USING 
        /*LT3117_TIPO_OPERACAO
        LT3117_COD_LOTERICO
        LT3117_NUM_CLASSE_ADESAO
        LT3117_NUM_APOLICE
        LT3117_DTINIVIG_APOLICE
        LT3117_DTTERVIG_APOLICE
        LT3117_QTD_PARCELAS
        LT3117_TIPO_CALCULO
        LT3117_CUSTO_APOLICE
        LT3117_PCT_IOF
        LT3117_TX_INCENDIO
        LT3117_TX_VALORES
        LT3117_TX_DANELET
        LT3117_TX_AP_EMPGDR
        LT3117_TX_AP_EMP
        LT3117_TX_RC
        LT3117_VL_IS_INCENDIO
        LT3117_VL_IS_VALORES
        LT3117_VL_IS_DANELET
        LT3117_VL_IS_AP_EMPGDR
        LT3117_VL_IS_AP_EMP
        LT3117_VL_IS_RC
        LT3117_IOF_PCL1
        LT3117_ADICIONAL_FRAC_PCL1
        LT3117_JUROS_PCL1
        LT3117_PERC_JUROS_PCL1
        LT3117_VL_PREMIO_LIQ_PCL1
        LT3117_VL_PREMIO_PCL1
        LT3117_IOF_PCLN
        LT3117_ADICIONAL_FRAC_PCLN
        LT3117_JUROS_PCLN
        LT3117_PERC_JUROS_PCLN
        LT3117_VL_PREMIO_LIQ_PCLN
        LT3117_VL_PREMIO_PCLN
        LT3117_VL_PREMIO_TOTAL
        LT3117_VL_PREMIO_TOTAL_1PCL
        LT3117_JURO_TOTAL
        LT3117_IOF_TOTAL
        LT3117_ADICIONAL_TOTAL
        LT3117_PREMIO_INCENDIO
        LT3117_PREMIO_VALORES
        LT3117_PREMIO_DANELET
        LT3117_PREMIO_AP_EMPGDR
        LT3117_PREMIO_AP_EMP
        LT3117_PREMIO_RC
        LT3117_COD_RETORNO*/
        {
            try
            {
                this.LBLT3117 = LBLT3117_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBLT3117, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -261- PERFORM R1000-00-PROCESSA-REGISTRO. */

            R1000_00_PROCESSA_REGISTRO_SECTION();

            /*" -261- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-CRITICA-PARAMETROS-SECTION */
        private void R0100_CRITICA_PARAMETROS_SECTION()
        {
            /*" -273- MOVE 0 TO WS-ERRO */
            _.Move(0, WAREA_TRABALHO.WS_ERRO);

            /*" -274- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 10 */

            for (WAREA_TRABALHO.WS_IND.Value = 1; !(WAREA_TRABALHO.WS_IND > 10); WAREA_TRABALHO.WS_IND.Value += 1)
            {

                /*" -277- IF TB-IMPSEG (WS-IND) > 0 AND TB-TAXAS (WS-IND) > 0 AND TB-TAXAS-2007 (WS-IND) > 0 */

                if (LBTB3100.TAB_IMPSEG.TB_IMPSEG[WAREA_TRABALHO.WS_IND] > 0 && LBTB3100.TAB_TAXAS.TB_TAXAS[WAREA_TRABALHO.WS_IND] > 0 && WAREA_TRABALHO.TAB_TAXAS_2007.TB_TAXAS_2007[WAREA_TRABALHO.WS_IND] > 0)
                {

                    /*" -278- ADD 1 TO WS-ERRO */
                    WAREA_TRABALHO.WS_ERRO.Value = WAREA_TRABALHO.WS_ERRO + 1;

                    /*" -279- END-IF */
                }


                /*" -281- END-PERFORM */
            }

            /*" -282- IF WS-ERRO < 2 */

            if (WAREA_TRABALHO.WS_ERRO < 2)
            {

                /*" -283- DISPLAY ' LT3117S-TAXA E I.S INSUFICIENTES PARA CALCULO ' */
                _.Display($" LT3117S-TAXA E I.S INSUFICIENTES PARA CALCULO ");

                /*" -284- MOVE 1 TO LT3117-COD-RETORNO */
                _.Move(1, LBLT3117.LT3117_COD_RETORNO);

                /*" -286- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -287- IF LT3117-QTD-PARCELAS < 1 OR > 12 */

            if (LBLT3117.LT3117_QTD_PARCELAS < 1 || LBLT3117.LT3117_QTD_PARCELAS > 12)
            {

                /*" -288- DISPLAY ' LT3117S-QTD PARCELAS INVALIDO  ' */
                _.Display($" LT3117S-QTD PARCELAS INVALIDO  ");

                /*" -289- MOVE 1 TO LT3117-COD-RETORNO */
                _.Move(1, LBLT3117.LT3117_COD_RETORNO);

                /*" -291- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -292- IF LT3117-NUM-CLASSE-ADESAO < 1 OR > 13 */

            if (LBLT3117.LT3117_NUM_CLASSE_ADESAO < 1 || LBLT3117.LT3117_NUM_CLASSE_ADESAO > 13)
            {

                /*" -293- DISPLAY ' LT3117S-INDICE DA CLASSE INVALIDO ' */
                _.Display($" LT3117S-INDICE DA CLASSE INVALIDO ");

                /*" -294- MOVE 1 TO LT3117-COD-RETORNO */
                _.Move(1, LBLT3117.LT3117_COD_RETORNO);

                /*" -296- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -297- IF LT3117-PCT-IOF EQUAL ZEROS */

            if (LBLT3117.LT3117_PCT_IOF == 00)
            {

                /*" -298- DISPLAY ' LT3117S-PERCENTUAL DE IOF ZERADO - INVALIDO ' */
                _.Display($" LT3117S-PERCENTUAL DE IOF ZERADO - INVALIDO ");

                /*" -299- MOVE 1 TO LT3117-COD-RETORNO */
                _.Move(1, LBLT3117.LT3117_COD_RETORNO);

                /*" -301- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -303- IF LT3117-TIPO-CALCULO EQUAL 'PR' OR 'PC' OR '  ' NEXT SENTENCE */

            if (LBLT3117.LT3117_TIPO_CALCULO.In("PR", "PC", " "))
            {

                /*" -304- ELSE */
            }
            else
            {


                /*" -305- DISPLAY ' LT3117S-TIPO CALCULO PR/PC - INVALIDO ' */
                _.Display($" LT3117S-TIPO CALCULO PR/PC - INVALIDO ");

                /*" -306- MOVE 1 TO LT3117-COD-RETORNO */
                _.Move(1, LBLT3117.LT3117_COD_RETORNO);

                /*" -308- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -309- MOVE LT3117-DTINIVIG-APOLICE TO WS-DATA-SQL-AUX */
            _.Move(LBLT3117.LT3117_DTINIVIG_APOLICE, WAREA_TRABALHO.WS_DATA_SQL_AUX);

            /*" -310- PERFORM R0140-CRITICA-DATA-SQL */

            R0140_CRITICA_DATA_SQL_SECTION();

            /*" -311- IF WS-ERRO > ZEROS */

            if (WAREA_TRABALHO.WS_ERRO > 00)
            {

                /*" -312- DISPLAY ' LT3117S-DTINIVIG-APOLICE - INVALIDA ' */
                _.Display($" LT3117S-DTINIVIG-APOLICE - INVALIDA ");

                /*" -313- MOVE 1 TO LT3117-COD-RETORNO */
                _.Move(1, LBLT3117.LT3117_COD_RETORNO);

                /*" -318- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -320- MOVE LT3117-DTINIVIG-APOLICE TO WS-DATA-SQL-AUX */
            _.Move(LBLT3117.LT3117_DTINIVIG_APOLICE, WAREA_TRABALHO.WS_DATA_SQL_AUX);

            /*" -321- MOVE 12 TO WS-MES-SQL-AUX */
            _.Move(12, WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX);

            /*" -322- MOVE 31 TO WS-DIA-SQL-AUX */
            _.Move(31, WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX);

            /*" -324- MOVE WS-DATA-SQL-AUX TO LT3117-DTTERVIG-APOLICE. */
            _.Move(WAREA_TRABALHO.WS_DATA_SQL_AUX, LBLT3117.LT3117_DTTERVIG_APOLICE);

            /*" -325- PERFORM R0140-CRITICA-DATA-SQL */

            R0140_CRITICA_DATA_SQL_SECTION();

            /*" -326- IF WS-ERRO > ZEROS */

            if (WAREA_TRABALHO.WS_ERRO > 00)
            {

                /*" -327- DISPLAY ' LT3117S-DTTERVIG-APOLICE - INVALIDA ' */
                _.Display($" LT3117S-DTTERVIG-APOLICE - INVALIDA ");

                /*" -328- MOVE 1 TO LT3117-COD-RETORNO */
                _.Move(1, LBLT3117.LT3117_COD_RETORNO);

                /*" -330- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -331- IF LT3117-DTINIVIG-APOLICE >= LT3117-DTTERVIG-APOLICE */

            if (LBLT3117.LT3117_DTINIVIG_APOLICE >= LBLT3117.LT3117_DTTERVIG_APOLICE)
            {

                /*" -332- DISPLAY ' LT3117S-DTINIVIG>=DTTERVIG - INVALIDA ' */
                _.Display($" LT3117S-DTINIVIG>=DTTERVIG - INVALIDA ");

                /*" -333- MOVE 1 TO LT3117-COD-RETORNO */
                _.Move(1, LBLT3117.LT3117_COD_RETORNO);

                /*" -345- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -347- MOVE LT3117-DTINIVIG-APOLICE TO WS-DATA-SQL-AUX */
            _.Move(LBLT3117.LT3117_DTINIVIG_APOLICE, WAREA_TRABALHO.WS_DATA_SQL_AUX);

            /*" -349- IF WS-MES-SQL-AUX EQUAL 1 AND WS-DIA-SQL-AUX EQUAL 1 */

            if (WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX == 1 && WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX == 1)
            {

                /*" -350- MOVE ' ' TO LT3117-TIPO-CALCULO */
                _.Move(" ", LBLT3117.LT3117_TIPO_CALCULO);

                /*" -351- ELSE */
            }
            else
            {


                /*" -351- MOVE 'PR' TO LT3117-TIPO-CALCULO . */
                _.Move("PR", LBLT3117.LT3117_TIPO_CALCULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0120-INICIALIZAR-VARIAVEIS-SECTION */
        private void R0120_INICIALIZAR_VARIAVEIS_SECTION()
        {
            /*" -365- MOVE '1001-01-01' TO WS-DATA-SQL */
            _.Move("1001-01-01", WAREA_TRABALHO.WS_DATA_SQL);

            /*" -366- ACCEPT WS-DATE FROM DATE */
            _.Move(_.AcceptDate("DATE"), WAREA_TRABALHO.WS_DATE);

            /*" -367- MOVE WS-DD-DATE TO WS-DIA-SQL */
            _.Move(WAREA_TRABALHO.WS_DATE.WS_DD_DATE, WAREA_TRABALHO.WS_DATA_SQL.WS_DIA_SQL);

            /*" -368- MOVE WS-MM-DATE TO WS-MES-SQL */
            _.Move(WAREA_TRABALHO.WS_DATE.WS_MM_DATE, WAREA_TRABALHO.WS_DATA_SQL.WS_MES_SQL);

            /*" -369- MOVE WS-AA-DATE TO WS-ANO-SQL */
            _.Move(WAREA_TRABALHO.WS_DATE.WS_AA_DATE, WAREA_TRABALHO.WS_DATA_SQL.WS_ANO_SQL);

            /*" -374- ADD 2000 TO WS-ANO-SQL */
            WAREA_TRABALHO.WS_DATA_SQL.WS_ANO_SQL.Value = WAREA_TRABALHO.WS_DATA_SQL.WS_ANO_SQL + 2000;

            /*" -375- IF WS-DATA-SQL >= '2007-11-09' AND <= '2008-01-10' */

            if (WAREA_TRABALHO.WS_DATA_SQL >= "2007-11-09" && WAREA_TRABALHO.WS_DATA_SQL <= "2008-01-10")
            {

                /*" -377- MOVE 'S' TO WS-DISPLAY. */
                _.Move("S", WAREA_TRABALHO.WS_DISPLAY);
            }


            /*" -381- PERFORM R0130-ZERAR-TABELAS VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 10. */

            for (WAREA_TRABALHO.WS_IND.Value = 1; !(WAREA_TRABALHO.WS_IND > 10); WAREA_TRABALHO.WS_IND.Value += 1)
            {

                R0130_ZERAR_TABELAS_SECTION();
            }

            /*" -409- MOVE 0 TO LT3117-VL-PREMIO-TOTAL LT3117-VL-PREMIO-TOTAL-1PCL LT3117-ADICIONAL-TOTAL LT3117-JURO-TOTAL LT3117-IOF-TOTAL LT3117-PREMIO-INCENDIO LT3117-PREMIO-DANELET LT3117-PREMIO-AP-EMP LT3117-PREMIO-VALORES LT3117-PREMIO-AP-EMPGDR LT3117-PREMIO-RC LT3117-COD-RETORNO LT3117-IOF-PCL1 LT3117-ADICIONAL-FRAC-PCL1 LT3117-JUROS-PCL1 LT3117-PERC-JUROS-PCL1 LT3117-VL-PREMIO-LIQ-PCL1 LT3117-VL-PREMIO-PCL1 LT3117-IOF-PCLN LT3117-ADICIONAL-FRAC-PCLN LT3117-JUROS-PCLN LT3117-PERC-JUROS-PCLN LT3117-VL-PREMIO-LIQ-PCLN LT3117-VL-PREMIO-PCLN WTOTAL-PREMIO-LIQNP WTOTAL-PREMIO-LIQ1P WS-ERRO. */
            _.Move(0, LBLT3117.LT3117_VL_PREMIO_TOTAL, LBLT3117.LT3117_VL_PREMIO_TOTAL_1PCL, LBLT3117.LT3117_ADICIONAL_TOTAL, LBLT3117.LT3117_JURO_TOTAL, LBLT3117.LT3117_IOF_TOTAL, LBLT3117.LT3117_PREMIO_INCENDIO, LBLT3117.LT3117_PREMIO_DANELET, LBLT3117.LT3117_PREMIO_AP_EMP, LBLT3117.LT3117_PREMIO_VALORES, LBLT3117.LT3117_PREMIO_AP_EMPGDR, LBLT3117.LT3117_PREMIO_RC, LBLT3117.LT3117_COD_RETORNO, LBLT3117.LT3117_IOF_PCL1, LBLT3117.LT3117_ADICIONAL_FRAC_PCL1, LBLT3117.LT3117_JUROS_PCL1, LBLT3117.LT3117_PERC_JUROS_PCL1, LBLT3117.LT3117_VL_PREMIO_LIQ_PCL1, LBLT3117.LT3117_VL_PREMIO_PCL1, LBLT3117.LT3117_IOF_PCLN, LBLT3117.LT3117_ADICIONAL_FRAC_PCLN, LBLT3117.LT3117_JUROS_PCLN, LBLT3117.LT3117_PERC_JUROS_PCLN, LBLT3117.LT3117_VL_PREMIO_LIQ_PCLN, LBLT3117.LT3117_VL_PREMIO_PCLN, WAREA_TRABALHO.WTOTAL_PREMIO_LIQNP, WAREA_TRABALHO.WTOTAL_PREMIO_LIQ1P, WAREA_TRABALHO.WS_ERRO);

            /*" -410- MOVE LT3117-VL-IS-INCENDIO TO TB-IMPSEG (1) */
            _.Move(LBLT3117.LT3117_VL_IS_INCENDIO, LBTB3100.TAB_IMPSEG.TB_IMPSEG[1]);

            /*" -411- MOVE LT3117-VL-IS-VALORES TO TB-IMPSEG (2) */
            _.Move(LBLT3117.LT3117_VL_IS_VALORES, LBTB3100.TAB_IMPSEG.TB_IMPSEG[2]);

            /*" -412- MOVE LT3117-VL-IS-DANELET TO TB-IMPSEG (3) */
            _.Move(LBLT3117.LT3117_VL_IS_DANELET, LBTB3100.TAB_IMPSEG.TB_IMPSEG[3]);

            /*" -413- MOVE LT3117-VL-IS-AP-EMPGDR TO TB-IMPSEG (4) */
            _.Move(LBLT3117.LT3117_VL_IS_AP_EMPGDR, LBTB3100.TAB_IMPSEG.TB_IMPSEG[4]);

            /*" -414- MOVE LT3117-VL-IS-AP-EMP TO TB-IMPSEG (5) */
            _.Move(LBLT3117.LT3117_VL_IS_AP_EMP, LBTB3100.TAB_IMPSEG.TB_IMPSEG[5]);

            /*" -416- MOVE LT3117-VL-IS-RC TO TB-IMPSEG (6) */
            _.Move(LBLT3117.LT3117_VL_IS_RC, LBTB3100.TAB_IMPSEG.TB_IMPSEG[6]);

            /*" -417- MOVE LT3117-TX-INCENDIO TO TB-TAXAS (1) */
            _.Move(LBLT3117.LT3117_TX_INCENDIO, LBTB3100.TAB_TAXAS.TB_TAXAS[1]);

            /*" -418- MOVE LT3117-TX-VALORES TO TB-TAXAS (2) */
            _.Move(LBLT3117.LT3117_TX_VALORES, LBTB3100.TAB_TAXAS.TB_TAXAS[2]);

            /*" -419- MOVE LT3117-TX-DANELET TO TB-TAXAS (3) */
            _.Move(LBLT3117.LT3117_TX_DANELET, LBTB3100.TAB_TAXAS.TB_TAXAS[3]);

            /*" -420- MOVE LT3117-TX-AP-EMPGDR TO TB-TAXAS (4) */
            _.Move(LBLT3117.LT3117_TX_AP_EMPGDR, LBTB3100.TAB_TAXAS.TB_TAXAS[4]);

            /*" -421- MOVE LT3117-TX-AP-EMP TO TB-TAXAS (5) */
            _.Move(LBLT3117.LT3117_TX_AP_EMP, LBTB3100.TAB_TAXAS.TB_TAXAS[5]);

            /*" -425- MOVE LT3117-TX-RC TO TB-TAXAS (6) . */
            _.Move(LBLT3117.LT3117_TX_RC, LBTB3100.TAB_TAXAS.TB_TAXAS[6]);

            /*" -425- PERFORM R0293-00-MONTAR-TAXAS-2007. */

            R0293_00_MONTAR_TAXAS_2007_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0130-ZERAR-TABELAS-SECTION */
        private void R0130_ZERAR_TABELAS_SECTION()
        {
            /*" -438- MOVE 0 TO TB-PREMIO-LIQ (WS-IND) TB-PREMIO-LIQ-1PCL (WS-IND) TB-IOF (WS-IND) TB-IMPSEG (WS-IND) TB-TAXAS (WS-IND) TB-TAXAS-2007 (WS-IND) . */
            _.Move(0, WAREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[WAREA_TRABALHO.WS_IND], WAREA_TRABALHO.TAB_PREMIO_LIQ_1PCL.TB_PREMIO_LIQ_1PCL[WAREA_TRABALHO.WS_IND], WAREA_TRABALHO.TAB_IOF.TB_IOF[WAREA_TRABALHO.WS_IND], LBTB3100.TAB_IMPSEG.TB_IMPSEG[WAREA_TRABALHO.WS_IND], LBTB3100.TAB_TAXAS.TB_TAXAS[WAREA_TRABALHO.WS_IND], WAREA_TRABALHO.TAB_TAXAS_2007.TB_TAXAS_2007[WAREA_TRABALHO.WS_IND]);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0140-CRITICA-DATA-SQL-SECTION */
        private void R0140_CRITICA_DATA_SQL_SECTION()
        {
            /*" -452- MOVE 0 TO WS-ERRO. */
            _.Move(0, WAREA_TRABALHO.WS_ERRO);

            /*" -458- IF WS-ANO-SQL-AUX LESS THAN 1900 OR WS-ANO-SQL-AUX GREATER 3000 OR WS-MES-SQL-AUX LESS THAN 1 OR WS-MES-SQL-AUX GREATER 12 OR WS-DIA-SQL-AUX LESS THAN 1 OR WS-DIA-SQL-AUX GREATER 31 */

            if (WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_ANO_SQL_AUX < 1900 || WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_ANO_SQL_AUX > 3000 || WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX < 1 || WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX > 12 || WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX < 1 || WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 31)
            {

                /*" -459- MOVE 1 TO WS-ERRO */
                _.Move(1, WAREA_TRABALHO.WS_ERRO);

                /*" -460- ELSE */
            }
            else
            {


                /*" -461- IF WS-MES-SQL-AUX EQUAL 4 OR 6 OR 9 OR 11 */

                if (WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX.In("4", "6", "9", "11"))
                {

                    /*" -462- IF WS-DIA-SQL-AUX GREATER 30 */

                    if (WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 30)
                    {

                        /*" -463- MOVE 1 TO WS-ERRO */
                        _.Move(1, WAREA_TRABALHO.WS_ERRO);

                        /*" -465- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -466- ELSE */
                    }

                }
                else
                {


                    /*" -467- IF WS-MES-SQL-AUX EQUAL 2 */

                    if (WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX == 2)
                    {

                        /*" -469- DIVIDE WS-ANO-SQL-AUX BY 4 GIVING WS-IND REMAINDER WS-IND1 */
                        _.Divide(WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_ANO_SQL_AUX, 4, WAREA_TRABALHO.WS_IND, WAREA_TRABALHO.WS_IND1);

                        /*" -470- IF WS-IND1 GREATER ZEROS */

                        if (WAREA_TRABALHO.WS_IND1 > 00)
                        {

                            /*" -471- IF WS-DIA-SQL-AUX GREATER 28 */

                            if (WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 28)
                            {

                                /*" -472- MOVE 1 TO WS-ERRO */
                                _.Move(1, WAREA_TRABALHO.WS_ERRO);

                                /*" -474- ELSE NEXT SENTENCE */
                            }
                            else
                            {


                                /*" -475- ELSE */
                            }

                        }
                        else
                        {


                            /*" -476- IF WS-DIA-SQL-AUX GREATER 29 */

                            if (WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 29)
                            {

                                /*" -477- MOVE 1 TO WS-ERRO */
                                _.Move(1, WAREA_TRABALHO.WS_ERRO);

                                /*" -479- ELSE NEXT SENTENCE */
                            }
                            else
                            {


                                /*" -480- ELSE */
                            }

                        }

                    }
                    else
                    {


                        /*" -481- IF WS-DIA-SQL-AUX GREATER 31 */

                        if (WAREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 31)
                        {

                            /*" -481- MOVE 1 TO WS-ERRO. */
                            _.Move(1, WAREA_TRABALHO.WS_ERRO);
                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0140_99_SAIDA*/

        [StopWatch]
        /*" R0293-00-MONTAR-TAXAS-2007-SECTION */
        private void R0293_00_MONTAR_TAXAS_2007_SECTION()
        {
            /*" -496- MOVE LT3117-NUM-CLASSE-ADESAO TO LT3142-NUM-CLASSE */
            _.Move(LBLT3117.LT3117_NUM_CLASSE_ADESAO, LBLT3142.LT3142_AREA_PARAMETROS.LT3142_NUM_CLASSE);

            /*" -497- MOVE 1 TO LT3142-QTD-PARCELAS */
            _.Move(1, LBLT3142.LT3142_AREA_PARAMETROS.LT3142_QTD_PARCELAS);

            /*" -498- MOVE LT3117-DTINIVIG-APOLICE TO LT3142-DTINIVIG */
            _.Move(LBLT3117.LT3117_DTINIVIG_APOLICE, LBLT3142.LT3142_AREA_PARAMETROS.LT3142_DTINIVIG);

            /*" -499- MOVE LT3117-DTTERVIG-APOLICE TO LT3142-DTTERVIG */
            _.Move(LBLT3117.LT3117_DTTERVIG_APOLICE, LBLT3142.LT3142_AREA_PARAMETROS.LT3142_DTTERVIG);

            /*" -500- MOVE ZEROS TO LT3142-COD-RETORNO */
            _.Move(0, LBLT3142.LT3142_AREA_PARAMETROS.LT3142_COD_RETORNO);

            /*" -502- MOVE SPACES TO LT3142-MENSAGEM */
            _.Move("", LBLT3142.LT3142_AREA_PARAMETROS.LT3142_MENSAGEM);

            /*" -505- CALL 'LT3142S' USING LT3142-AREA-PARAMETROS. */
            _.Call("LT3142S", LBLT3142.LT3142_AREA_PARAMETROS);

            /*" -506- IF LT3142-COD-RETORNO NOT EQUAL ZEROS */

            if (LBLT3142.LT3142_AREA_PARAMETROS.LT3142_COD_RETORNO != 00)
            {

                /*" -507- MOVE LT3142-COD-RETORNO TO LT3117-COD-RETORNO */
                _.Move(LBLT3142.LT3142_AREA_PARAMETROS.LT3142_COD_RETORNO, LBLT3117.LT3117_COD_RETORNO);

                /*" -508- DISPLAY LT3142-MENSAGEM */
                _.Display(LBLT3142.LT3142_AREA_PARAMETROS.LT3142_MENSAGEM);

                /*" -510- GO TO R0293-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0293_99_SAIDA*/ //GOTO
                return;
            }


            /*" -511- MOVE LT3142-TAXA(01) TO TB-TAXAS-2007(01) */
            _.Move(LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[01].LT3142_TAXA, WAREA_TRABALHO.TAB_TAXAS_2007.TB_TAXAS_2007[01]);

            /*" -512- MOVE LT3142-TAXA(02) TO TB-TAXAS-2007(02) */
            _.Move(LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[02].LT3142_TAXA, WAREA_TRABALHO.TAB_TAXAS_2007.TB_TAXAS_2007[02]);

            /*" -513- MOVE LT3142-TAXA(03) TO TB-TAXAS-2007(03) */
            _.Move(LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[03].LT3142_TAXA, WAREA_TRABALHO.TAB_TAXAS_2007.TB_TAXAS_2007[03]);

            /*" -514- MOVE LT3142-TAXA(04) TO TB-TAXAS-2007(04) */
            _.Move(LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[04].LT3142_TAXA, WAREA_TRABALHO.TAB_TAXAS_2007.TB_TAXAS_2007[04]);

            /*" -515- MOVE LT3142-TAXA(05) TO TB-TAXAS-2007(05) */
            _.Move(LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[05].LT3142_TAXA, WAREA_TRABALHO.TAB_TAXAS_2007.TB_TAXAS_2007[05]);

            /*" -517- MOVE LT3142-TAXA(06) TO TB-TAXAS-2007(06) */
            _.Move(LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[06].LT3142_TAXA, WAREA_TRABALHO.TAB_TAXAS_2007.TB_TAXAS_2007[06]);

            /*" -517- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0293_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -527- PERFORM R0120-INICIALIZAR-VARIAVEIS. */

            R0120_INICIALIZAR_VARIAVEIS_SECTION();

            /*" -528- IF LT3117-COD-RETORNO NOT EQUAL ZEROS */

            if (LBLT3117.LT3117_COD_RETORNO != 00)
            {

                /*" -530- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -532- PERFORM R0100-CRITICA-PARAMETROS. */

            R0100_CRITICA_PARAMETROS_SECTION();

            /*" -533- IF LT3117-COD-RETORNO NOT EQUAL ZEROS */

            if (LBLT3117.LT3117_COD_RETORNO != 00)
            {

                /*" -535- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -541- PERFORM R2200-CALCULAR-FATOR-PRORATA . */

            R2200_CALCULAR_FATOR_PRORATA_SECTION();

            /*" -548- PERFORM R2000-CALCULAR-PREMIOS VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 6 . */

            for (WAREA_TRABALHO.WS_IND.Value = 1; !(WAREA_TRABALHO.WS_IND > 6); WAREA_TRABALHO.WS_IND.Value += 1)
            {

                R2000_CALCULAR_PREMIOS_SECTION();
            }

            /*" -555- COMPUTE WTOTAL-JURO ROUNDED = WTOTAL-PREMIO-LIQNP - WTOTAL-PREMIO-LIQ1P . */
            WAREA_TRABALHO.WTOTAL_JURO.Value = WAREA_TRABALHO.WTOTAL_PREMIO_LIQNP - WAREA_TRABALHO.WTOTAL_PREMIO_LIQ1P;

            /*" -561- COMPUTE WTOTAL-JURO-1P = WTOTAL-JURO / LT3117-QTD-PARCELAS . */
            WAREA_TRABALHO.WTOTAL_JURO_1P.Value = WAREA_TRABALHO.WTOTAL_JURO / LBLT3117.LT3117_QTD_PARCELAS;

            /*" -563- COMPUTE WS-PCT-IOF = LT3117-PCT-IOF / 100 */
            WAREA_TRABALHO.WS_PCT_IOF.Value = LBLT3117.LT3117_PCT_IOF / 100f;

            /*" -565- DISPLAY 'LT3117 - WS-PCT-IOF =' WS-PCT-IOF */
            _.Display($"LT3117 - WS-PCT-IOF ={WAREA_TRABALHO.WS_PCT_IOF}");

            /*" -570- MOVE 0 TO WS-IOF-PRIM WS-IOF-OUTR LT3117-IOF-TOTAL LT3117-IOF-PCL1 LT3117-IOF-PCLN . */
            _.Move(0, WAREA_TRABALHO.WS_IOF_PRIM, WAREA_TRABALHO.WS_IOF_OUTR, LBLT3117.LT3117_IOF_TOTAL, LBLT3117.LT3117_IOF_PCL1, LBLT3117.LT3117_IOF_PCLN);

            /*" -571- MOVE 1 TO LT3117-PERC-JUROS-PCL1 */
            _.Move(1, LBLT3117.LT3117_PERC_JUROS_PCL1);

            /*" -572- MOVE 1 TO LT3117-PERC-JUROS-PCLN */
            _.Move(1, LBLT3117.LT3117_PERC_JUROS_PCLN);

            /*" -579- MOVE WTOTAL-JURO TO LT3117-JURO-TOTAL. */
            _.Move(WAREA_TRABALHO.WTOTAL_JURO, LBLT3117.LT3117_JURO_TOTAL);

            /*" -581- IF LT3117-QTD-PARCELAS = 1 */

            if (LBLT3117.LT3117_QTD_PARCELAS == 1)
            {

                /*" -584- MOVE WTOTAL-JURO-1P TO LT3117-JUROS-PCL1 LT3117-ADICIONAL-FRAC-PCL1 */
                _.Move(WAREA_TRABALHO.WTOTAL_JURO_1P, LBLT3117.LT3117_JUROS_PCL1, LBLT3117.LT3117_ADICIONAL_FRAC_PCL1);

                /*" -589- COMPUTE WS-IOF-PRIM ROUNDED = ( WTOTAL-PREMIO-LIQNP + LT3117-CUSTO-APOLICE ) * WS-PCT-IOF */
                WAREA_TRABALHO.WS_IOF_PRIM.Value = (WAREA_TRABALHO.WTOTAL_PREMIO_LIQNP + LBLT3117.LT3117_CUSTO_APOLICE) * WAREA_TRABALHO.WS_PCT_IOF;

                /*" -593- COMPUTE WTOTAL-PREMIO-BRUTO ROUNDED = WTOTAL-PREMIO-LIQNP + LT3117-CUSTO-APOLICE + WS-IOF-PRIM */
                WAREA_TRABALHO.WTOTAL_PREMIO_BRUTO.Value = WAREA_TRABALHO.WTOTAL_PREMIO_LIQNP + LBLT3117.LT3117_CUSTO_APOLICE + WAREA_TRABALHO.WS_IOF_PRIM;

                /*" -595- MOVE WTOTAL-PREMIO-BRUTO TO LT3117-VL-PREMIO-PCL1 LT3117-VL-PREMIO-TOTAL */
                _.Move(WAREA_TRABALHO.WTOTAL_PREMIO_BRUTO, LBLT3117.LT3117_VL_PREMIO_PCL1, LBLT3117.LT3117_VL_PREMIO_TOTAL);

                /*" -598- MOVE WS-IOF-PRIM TO LT3117-IOF-PCL1 LT3117-IOF-TOTAL */
                _.Move(WAREA_TRABALHO.WS_IOF_PRIM, LBLT3117.LT3117_IOF_PCL1, LBLT3117.LT3117_IOF_TOTAL);

                /*" -600- MOVE WTOTAL-PREMIO-LIQNP TO LT3117-VL-PREMIO-LIQ-PCL1 */
                _.Move(WAREA_TRABALHO.WTOTAL_PREMIO_LIQNP, LBLT3117.LT3117_VL_PREMIO_LIQ_PCL1);

                /*" -602- ELSE */
            }
            else
            {


                /*" -607- MOVE WTOTAL-JURO-1P TO LT3117-JUROS-PCL1 LT3117-JUROS-PCLN LT3117-ADICIONAL-FRAC-PCL1 LT3117-ADICIONAL-FRAC-PCLN */
                _.Move(WAREA_TRABALHO.WTOTAL_JURO_1P, LBLT3117.LT3117_JUROS_PCL1, LBLT3117.LT3117_JUROS_PCLN, LBLT3117.LT3117_ADICIONAL_FRAC_PCL1, LBLT3117.LT3117_ADICIONAL_FRAC_PCLN);

                /*" -610- COMPUTE LT3117-VL-PREMIO-PCLN = WTOTAL-PREMIO-LIQNP / LT3117-QTD-PARCELAS */
                LBLT3117.LT3117_VL_PREMIO_PCLN.Value = WAREA_TRABALHO.WTOTAL_PREMIO_LIQNP / LBLT3117.LT3117_QTD_PARCELAS;

                /*" -614- MOVE LT3117-VL-PREMIO-PCLN TO LT3117-VL-PREMIO-LIQ-PCL1 LT3117-VL-PREMIO-LIQ-PCLN */
                _.Move(LBLT3117.LT3117_VL_PREMIO_PCLN, LBLT3117.LT3117_VL_PREMIO_LIQ_PCL1, LBLT3117.LT3117_VL_PREMIO_LIQ_PCLN);

                /*" -618- COMPUTE WS-IOF-PRIM = ( LT3117-VL-PREMIO-PCLN + LT3117-CUSTO-APOLICE ) * WS-PCT-IOF */
                WAREA_TRABALHO.WS_IOF_PRIM.Value = (LBLT3117.LT3117_VL_PREMIO_PCLN + LBLT3117.LT3117_CUSTO_APOLICE) * WAREA_TRABALHO.WS_PCT_IOF;

                /*" -621- MOVE WS-IOF-PRIM TO LT3117-IOF-PCL1 */
                _.Move(WAREA_TRABALHO.WS_IOF_PRIM, LBLT3117.LT3117_IOF_PCL1);

                /*" -625- COMPUTE LT3117-VL-PREMIO-PCL1 = LT3117-VL-PREMIO-PCLN + LT3117-CUSTO-APOLICE + WS-IOF-PRIM */
                LBLT3117.LT3117_VL_PREMIO_PCL1.Value = LBLT3117.LT3117_VL_PREMIO_PCLN + LBLT3117.LT3117_CUSTO_APOLICE + WAREA_TRABALHO.WS_IOF_PRIM;

                /*" -629- COMPUTE WS-IOF-OUTR = LT3117-VL-PREMIO-PCLN * WS-PCT-IOF */
                WAREA_TRABALHO.WS_IOF_OUTR.Value = LBLT3117.LT3117_VL_PREMIO_PCLN * WAREA_TRABALHO.WS_PCT_IOF;

                /*" -632- COMPUTE LT3117-VL-PREMIO-PCLN = LT3117-VL-PREMIO-PCLN + WS-IOF-OUTR */
                LBLT3117.LT3117_VL_PREMIO_PCLN.Value = LBLT3117.LT3117_VL_PREMIO_PCLN + WAREA_TRABALHO.WS_IOF_OUTR;

                /*" -634- MOVE WS-IOF-OUTR TO LT3117-IOF-PCLN */
                _.Move(WAREA_TRABALHO.WS_IOF_OUTR, LBLT3117.LT3117_IOF_PCLN);

                /*" -637- COMPUTE WS-QTD-PARCELAS = LT3117-QTD-PARCELAS - 1 */
                WAREA_TRABALHO.WS_QTD_PARCELAS.Value = LBLT3117.LT3117_QTD_PARCELAS - 1;

                /*" -642- COMPUTE WTOTAL-PREMIO-BRUTO ROUNDED = LT3117-VL-PREMIO-PCL1 + ( LT3117-VL-PREMIO-PCLN * WS-QTD-PARCELAS ) */
                WAREA_TRABALHO.WTOTAL_PREMIO_BRUTO.Value = LBLT3117.LT3117_VL_PREMIO_PCL1 + (LBLT3117.LT3117_VL_PREMIO_PCLN * WAREA_TRABALHO.WS_QTD_PARCELAS);

                /*" -647- COMPUTE LT3117-IOF-TOTAL = LT3117-IOF-PCL1 + (LT3117-IOF-PCLN * WS-QTD-PARCELAS) . */
                LBLT3117.LT3117_IOF_TOTAL.Value = LBLT3117.LT3117_IOF_PCL1 + (LBLT3117.LT3117_IOF_PCLN * WAREA_TRABALHO.WS_QTD_PARCELAS);
            }


            /*" -652- MOVE WTOTAL-PREMIO-BRUTO TO LT3117-VL-PREMIO-TOTAL. */
            _.Move(WAREA_TRABALHO.WTOTAL_PREMIO_BRUTO, LBLT3117.LT3117_VL_PREMIO_TOTAL);

            /*" -653- MOVE TB-PREMIO-LIQ(1) TO LT3117-PREMIO-INCENDIO. */
            _.Move(WAREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[1], LBLT3117.LT3117_PREMIO_INCENDIO);

            /*" -654- MOVE TB-PREMIO-LIQ(2) TO LT3117-PREMIO-VALORES. */
            _.Move(WAREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[2], LBLT3117.LT3117_PREMIO_VALORES);

            /*" -655- MOVE TB-PREMIO-LIQ(3) TO LT3117-PREMIO-DANELET. */
            _.Move(WAREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[3], LBLT3117.LT3117_PREMIO_DANELET);

            /*" -656- MOVE TB-PREMIO-LIQ(4) TO LT3117-PREMIO-AP-EMPGDR. */
            _.Move(WAREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[4], LBLT3117.LT3117_PREMIO_AP_EMPGDR);

            /*" -657- MOVE TB-PREMIO-LIQ(5) TO LT3117-PREMIO-AP-EMP. */
            _.Move(WAREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[5], LBLT3117.LT3117_PREMIO_AP_EMP);

            /*" -666- MOVE TB-PREMIO-LIQ(6) TO LT3117-PREMIO-RC. */
            _.Move(WAREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[6], LBLT3117.LT3117_PREMIO_RC);

            /*" -670- COMPUTE LT3117-VL-PREMIO-TOTAL-1PCL ROUNDED = ( WTOTAL-PREMIO-LIQ1P + LT3117-CUSTO-APOLICE ) * ( 1 + WS-PCT-IOF ) . */
            LBLT3117.LT3117_VL_PREMIO_TOTAL_1PCL.Value = (WAREA_TRABALHO.WTOTAL_PREMIO_LIQ1P + LBLT3117.LT3117_CUSTO_APOLICE) * (1 + WAREA_TRABALHO.WS_PCT_IOF);

            /*" -670- PERFORM R1100-DISPLAY-CALCULO. */

            R1100_DISPLAY_CALCULO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-DISPLAY-CALCULO-SECTION */
        private void R1100_DISPLAY_CALCULO_SECTION()
        {
            /*" -680- IF WS-DISPLAY NOT EQUAL SPACES */

            if (!WAREA_TRABALHO.WS_DISPLAY.IsEmpty())
            {

                /*" -681- DISPLAY ' LT3117S-RESUMO=================================' */
                _.Display($" LT3117S-RESUMO=================================");

                /*" -688- DISPLAY ' LOT=' LT3117-COD-LOTERICO ' QTD-PCL=' LT3117-QTD-PARCELAS ' DTINI=' LT3117-DTINIVIG-APOLICE ' DTTER=' LT3117-DTTERVIG-APOLICE ' TCALC=' LT3117-TIPO-CALCULO ' CUSTO AP=' LT3117-CUSTO-APOLICE ' PCT IOF =' LT3117-PCT-IOF */

                $" LOT={LBLT3117.LT3117_COD_LOTERICO} QTD-PCL={LBLT3117.LT3117_QTD_PARCELAS} DTINI={LBLT3117.LT3117_DTINIVIG_APOLICE} DTTER={LBLT3117.LT3117_DTTERVIG_APOLICE} TCALC={LBLT3117.LT3117_TIPO_CALCULO} CUSTO AP={LBLT3117.LT3117_CUSTO_APOLICE} PCT IOF ={LBLT3117.LT3117_PCT_IOF}"
                .Display();

                /*" -690- DISPLAY '       PRMLIQ TOT PCL1=' WTOTAL-PREMIO-LIQ1P ' PRMLIQ TOT PCLN=' WTOTAL-PREMIO-LIQNP */

                $"       PRMLIQ TOT PCL1={WAREA_TRABALHO.WTOTAL_PREMIO_LIQ1P} PRMLIQ TOT PCLN={WAREA_TRABALHO.WTOTAL_PREMIO_LIQNP}"
                .Display();

                /*" -694- DISPLAY '       VAL PRIM PCL=' LT3117-VL-PREMIO-PCL1 ' VAL OUTR PCL=' LT3117-VL-PREMIO-PCLN ' IOF PRIM PCL=' WS-IOF-PRIM ' IOF OUTR PCL=' WS-IOF-OUTR */

                $"       VAL PRIM PCL={LBLT3117.LT3117_VL_PREMIO_PCL1} VAL OUTR PCL={LBLT3117.LT3117_VL_PREMIO_PCLN} IOF PRIM PCL={WAREA_TRABALHO.WS_IOF_PRIM} IOF OUTR PCL={WAREA_TRABALHO.WS_IOF_OUTR}"
                .Display();

                /*" -698- DISPLAY '       IOF TOTAL=' LT3117-IOF-TOTAL ' JURO P/PCL=' WTOTAL-JURO-1P ' JURO TOTAL=' WTOTAL-JURO */

                $"       IOF TOTAL={LBLT3117.LT3117_IOF_TOTAL} JURO P/PCL={WAREA_TRABALHO.WTOTAL_JURO_1P} JURO TOTAL={WAREA_TRABALHO.WTOTAL_JURO}"
                .Display();

                /*" -701- DISPLAY '       PRM BRU TOT PCL1=' LT3117-VL-PREMIO-TOTAL-1PCL ' PRM BRU TOT PCLN=' LT3117-VL-PREMIO-TOTAL */

                $"       PRM BRU TOT PCL1={LBLT3117.LT3117_VL_PREMIO_TOTAL_1PCL} PRM BRU TOT PCLN={LBLT3117.LT3117_VL_PREMIO_TOTAL}"
                .Display();

                /*" -705- DISPLAY '       PRM LIQ TOT A VISTA   =' WTOTAL-PREMIO-LIQ1P ' PRM LIQ TOT PARCELADO =' WTOTAL-PREMIO-LIQNP */

                $"       PRM LIQ TOT A VISTA   ={WAREA_TRABALHO.WTOTAL_PREMIO_LIQ1P} PRM LIQ TOT PARCELADO ={WAREA_TRABALHO.WTOTAL_PREMIO_LIQNP}"
                .Display();

                /*" -705- DISPLAY ' =============================================' . */
                _.Display($" =============================================");
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R2000-CALCULAR-PREMIOS-SECTION */
        private void R2000_CALCULAR_PREMIOS_SECTION()
        {
            /*" -729- IF LT3117-DTINIVIG-APOLICE LESS THAN '2007-01-01' */

            if (LBLT3117.LT3117_DTINIVIG_APOLICE < "2007-01-01")
            {

                /*" -730- IF WS-IND EQUAL 2 */

                if (WAREA_TRABALHO.WS_IND == 2)
                {

                    /*" -731- COMPUTE WS-IND1 = (LT3117-NUM-CLASSE-ADESAO * 12 ) - 11 */
                    WAREA_TRABALHO.WS_IND1.Value = (LBLT3117.LT3117_NUM_CLASSE_ADESAO * 12) - 11;

                    /*" -732- ELSE */
                }
                else
                {


                    /*" -733- COMPUTE WS-IND1 = (WS-IND + 13 ) * 12 - 11 */
                    WAREA_TRABALHO.WS_IND1.Value = (WAREA_TRABALHO.WS_IND + 13) * 12 - 11;

                    /*" -734- END-IF */
                }


                /*" -736- COMPUTE TB-PREMIO-LIQ-1PCL(WS-IND) ROUNDED = TB-IMPSEG(WS-IND) * TB-TAXAS-2006 (WS-IND1) */
                WAREA_TRABALHO.TAB_PREMIO_LIQ_1PCL.TB_PREMIO_LIQ_1PCL[WAREA_TRABALHO.WS_IND].Value = LBTB3100.TAB_IMPSEG.TB_IMPSEG[WAREA_TRABALHO.WS_IND].Value * LBTB3100.TAB_TAXAS_2006_R.TB_TAXAS_2006[WAREA_TRABALHO.WS_IND1].Value;

                /*" -737- IF WS-DISPLAY NOT EQUAL SPACES */

                if (!WAREA_TRABALHO.WS_DISPLAY.IsEmpty())
                {

                    /*" -740- DISPLAY 'LT3117-TX2006-1PCL=' TB-TAXAS-2006 (WS-IND1) ' IS=' TB-IMPSEG(WS-IND) ' CB=' WS-IND */

                    $"LT3117-TX2006-1PCL={LBTB3100.TAB_TAXAS_2006_R.TB_TAXAS_2006[WAREA_TRABALHO.WS_IND1]} IS={LBTB3100.TAB_IMPSEG.TB_IMPSEG[WAREA_TRABALHO.WS_IND]} CB={WAREA_TRABALHO.WS_IND}"
                    .Display();

                    /*" -741- END-IF */
                }


                /*" -742- ELSE */
            }
            else
            {


                /*" -744- COMPUTE TB-PREMIO-LIQ-1PCL(WS-IND) ROUNDED = TB-IMPSEG(WS-IND) * TB-TAXAS-2007 (WS-IND) */
                WAREA_TRABALHO.TAB_PREMIO_LIQ_1PCL.TB_PREMIO_LIQ_1PCL[WAREA_TRABALHO.WS_IND].Value = LBTB3100.TAB_IMPSEG.TB_IMPSEG[WAREA_TRABALHO.WS_IND].Value * WAREA_TRABALHO.TAB_TAXAS_2007.TB_TAXAS_2007[WAREA_TRABALHO.WS_IND].Value;

                /*" -745- IF WS-DISPLAY NOT EQUAL SPACES */

                if (!WAREA_TRABALHO.WS_DISPLAY.IsEmpty())
                {

                    /*" -749- DISPLAY 'LT3117-TX2007-2050=' ' 1PCL=' TB-TAXAS-2007 (WS-IND) ' IS=' TB-IMPSEG(WS-IND) ' CB=' WS-IND */

                    $"LT3117-TX2007-2050= 1PCL={WAREA_TRABALHO.TAB_TAXAS_2007.TB_TAXAS_2007[WAREA_TRABALHO.WS_IND]} IS={LBTB3100.TAB_IMPSEG.TB_IMPSEG[WAREA_TRABALHO.WS_IND]} CB={WAREA_TRABALHO.WS_IND}"
                    .Display();

                    /*" -750- END-IF */
                }


                /*" -756- END-IF . */
            }


            /*" -757- IF LT3117-TIPO-CALCULO EQUAL 'PR' */

            if (LBLT3117.LT3117_TIPO_CALCULO == "PR")
            {

                /*" -764- COMPUTE TB-PREMIO-LIQ-1PCL(WS-IND) ROUNDED = TB-PREMIO-LIQ-1PCL(WS-IND) * WS-FATOR . */
                WAREA_TRABALHO.TAB_PREMIO_LIQ_1PCL.TB_PREMIO_LIQ_1PCL[WAREA_TRABALHO.WS_IND].Value = WAREA_TRABALHO.TAB_PREMIO_LIQ_1PCL.TB_PREMIO_LIQ_1PCL[WAREA_TRABALHO.WS_IND].Value * WAREA_TRABALHO.WS_FATOR;
            }


            /*" -773- COMPUTE WTOTAL-PREMIO-LIQ1P ROUNDED = WTOTAL-PREMIO-LIQ1P + TB-PREMIO-LIQ-1PCL(WS-IND) . */
            WAREA_TRABALHO.WTOTAL_PREMIO_LIQ1P.Value = WAREA_TRABALHO.WTOTAL_PREMIO_LIQ1P + WAREA_TRABALHO.TAB_PREMIO_LIQ_1PCL.TB_PREMIO_LIQ_1PCL[WAREA_TRABALHO.WS_IND].Value;

            /*" -779- COMPUTE TB-PREMIO-LIQ(WS-IND) ROUNDED = TB-IMPSEG(WS-IND) * TB-TAXAS(WS-IND) . */
            WAREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[WAREA_TRABALHO.WS_IND].Value = LBTB3100.TAB_IMPSEG.TB_IMPSEG[WAREA_TRABALHO.WS_IND].Value * LBTB3100.TAB_TAXAS.TB_TAXAS[WAREA_TRABALHO.WS_IND].Value;

            /*" -780- IF LT3117-TIPO-CALCULO EQUAL 'PR' */

            if (LBLT3117.LT3117_TIPO_CALCULO == "PR")
            {

                /*" -785- COMPUTE TB-PREMIO-LIQ(WS-IND) ROUNDED = TB-PREMIO-LIQ(WS-IND) * WS-FATOR . */
                WAREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[WAREA_TRABALHO.WS_IND].Value = WAREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[WAREA_TRABALHO.WS_IND].Value * WAREA_TRABALHO.WS_FATOR;
            }


            /*" -790- COMPUTE WTOTAL-PREMIO-LIQNP ROUNDED = WTOTAL-PREMIO-LIQNP + TB-PREMIO-LIQ(WS-IND). */
            WAREA_TRABALHO.WTOTAL_PREMIO_LIQNP.Value = WAREA_TRABALHO.WTOTAL_PREMIO_LIQNP + WAREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[WAREA_TRABALHO.WS_IND].Value;

            /*" -791- IF WS-DISPLAY NOT EQUAL SPACES */

            if (!WAREA_TRABALHO.WS_DISPLAY.IsEmpty())
            {

                /*" -792- MOVE WS-FATOR TO WS-FATOR-S */
                _.Move(WAREA_TRABALHO.WS_FATOR, WAREA_TRABALHO.WS_FATOR_S);

                /*" -796- DISPLAY 'LT3117S-LOTERICO=' LT3117-COD-LOTERICO ' COB=' WS-IND ' TIPCALC=' LT3117-TIPO-CALCULO ' FT PRO-RATA=' WS-FATOR-S */

                $"LT3117S-LOTERICO={LBLT3117.LT3117_COD_LOTERICO} COB={WAREA_TRABALHO.WS_IND} TIPCALC={LBLT3117.LT3117_TIPO_CALCULO} FT PRO-RATA={WAREA_TRABALHO.WS_FATOR_S}"
                .Display();

                /*" -800- DISPLAY '      A VISTA-IS=' TB-IMPSEG(WS-IND) ' TX=' TB-TAXAS-2006 (WS-IND1) ' TX2007=' TB-TAXAS-2007 (WS-IND) ' PRM=' TB-PREMIO-LIQ-1PCL(WS-IND) */

                $"      A VISTA-IS={LBTB3100.TAB_IMPSEG.TB_IMPSEG[WAREA_TRABALHO.WS_IND]} TX={LBTB3100.TAB_TAXAS_2006_R.TB_TAXAS_2006[WAREA_TRABALHO.WS_IND1]} TX2007={WAREA_TRABALHO.TAB_TAXAS_2007.TB_TAXAS_2007[WAREA_TRABALHO.WS_IND]} PRM={WAREA_TRABALHO.TAB_PREMIO_LIQ_1PCL.TB_PREMIO_LIQ_1PCL[WAREA_TRABALHO.WS_IND]}"
                .Display();

                /*" -802- DISPLAY '      NORMAL  IS=' TB-IMPSEG(WS-IND) ' TX=' TB-TAXAS(WS-IND) ' PRM=' TB-PREMIO-LIQ(WS-IND) . */

                $"      NORMAL  IS={LBTB3100.TAB_IMPSEG.TB_IMPSEG[WAREA_TRABALHO.WS_IND]} TX={LBTB3100.TAB_TAXAS.TB_TAXAS[WAREA_TRABALHO.WS_IND]} PRM={WAREA_TRABALHO.TAB_PREMIO_LIQ.TB_PREMIO_LIQ[WAREA_TRABALHO.WS_IND]}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_SAIDA*/

        [StopWatch]
        /*" R2200-CALCULAR-FATOR-PRORATA-SECTION */
        private void R2200_CALCULAR_FATOR_PRORATA_SECTION()
        {
            /*" -817- MOVE 'R2200' TO WNR-EXEC-SQL. */
            _.Move("R2200", WAREA_TRABALHO.WABEND.WNR_EXEC_SQL);

            /*" -819- MOVE 1 TO WS-FATOR. */
            _.Move(1, WAREA_TRABALHO.WS_FATOR);

            /*" -821- IF LT3117-TIPO-CALCULO EQUAL 'PR' OR 'PC' NEXT SENTENCE */

            if (LBLT3117.LT3117_TIPO_CALCULO.In("PR", "PC"))
            {

                /*" -822- ELSE */
            }
            else
            {


                /*" -840- GO TO R2200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -846- MOVE 365 TO WS-QTDIAS-VIGENCIA. */
            _.Move(365, WAREA_TRABALHO.WS_QTDIAS_VIGENCIA);

            /*" -848- MOVE LT3117-DTINIVIG-APOLICE TO HOST-DATA-INI */
            _.Move(LBLT3117.LT3117_DTINIVIG_APOLICE, WAREA_TRABALHO.HOST_DATA_INI);

            /*" -850- MOVE LT3117-DTTERVIG-APOLICE TO HOST-DATA-FIM */
            _.Move(LBLT3117.LT3117_DTTERVIG_APOLICE, WAREA_TRABALHO.HOST_DATA_FIM);

            /*" -852- PERFORM R1100-00-OBTEM-QTD-DIAS */

            R1100_00_OBTEM_QTD_DIAS_SECTION();

            /*" -859- MOVE HOST-COUNT TO WS-QTDIAS-DECORRER */
            _.Move(WAREA_TRABALHO.HOST_COUNT, WAREA_TRABALHO.WS_QTDIAS_DECORRER);

            /*" -860- IF LT3117-TIPO-CALCULO EQUAL 'PR' */

            if (LBLT3117.LT3117_TIPO_CALCULO == "PR")
            {

                /*" -862- COMPUTE WS-FATOR = WS-QTDIAS-DECORRER / WS-QTDIAS-VIGENCIA */
                WAREA_TRABALHO.WS_FATOR.Value = WAREA_TRABALHO.WS_QTDIAS_DECORRER / WAREA_TRABALHO.WS_QTDIAS_VIGENCIA;

                /*" -863- ELSE */
            }
            else
            {


                /*" -864- IF LT3117-TIPO-CALCULO EQUAL 'PC' */

                if (LBLT3117.LT3117_TIPO_CALCULO == "PC")
                {

                    /*" -868- COMPUTE WS-FATOR = WS-PCT-PRM-DECORRIDO / 100 . */
                    WAREA_TRABALHO.WS_FATOR.Value = WAREA_TRABALHO.WS_PCT_PRM_DECORRIDO / 100f;
                }

            }


            /*" -869- IF WS-FATOR EQUAL ZEROS */

            if (WAREA_TRABALHO.WS_FATOR == 00)
            {

                /*" -871- MOVE 1 TO WS-FATOR . */
                _.Move(1, WAREA_TRABALHO.WS_FATOR);
            }


            /*" -872- IF WS-DISPLAY NOT EQUAL SPACES */

            if (!WAREA_TRABALHO.WS_DISPLAY.IsEmpty())
            {

                /*" -878- DISPLAY ' LT3117-CALCULO PRORATA ' ' LOT=' LT3117-COD-LOTERICO ' DTI=' LT3117-DTINIVIG-APOLICE ' DTT=' LT3117-DTTERVIG-APOLICE ' DIASVIG=' WS-QTDIAS-VIGENCIA ' DIASADEC=' WS-QTDIAS-DECORRER ' FT=' WS-FATOR. */

                $" LT3117-CALCULO PRORATA  LOT={LBLT3117.LT3117_COD_LOTERICO} DTI={LBLT3117.LT3117_DTINIVIG_APOLICE} DTT={LBLT3117.LT3117_DTTERVIG_APOLICE} DIASVIG={WAREA_TRABALHO.WS_QTDIAS_VIGENCIA} DIASADEC={WAREA_TRABALHO.WS_QTDIAS_DECORRER} FT={WAREA_TRABALHO.WS_FATOR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-OBTEM-QTD-DIAS-SECTION */
        private void R1100_00_OBTEM_QTD_DIAS_SECTION()
        {
            /*" -890- MOVE 'R1100' TO WNR-EXEC-SQL. */
            _.Move("R1100", WAREA_TRABALHO.WABEND.WNR_EXEC_SQL);

            /*" -896- PERFORM R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1 */

            R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1();

            /*" -899- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -903- DISPLAY 'LT3117S - PROBLEMAS NO SELECT CALENDARIO' ' ' LT3117-NUM-APOLICE ' ' HOST-DATA-INI ' ' HOST-DATA-FIM */

                $"LT3117S - PROBLEMAS NO SELECT CALENDARIO {LBLT3117.LT3117_NUM_APOLICE} {WAREA_TRABALHO.HOST_DATA_INI} {WAREA_TRABALHO.HOST_DATA_FIM}"
                .Display();

                /*" -905- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -906- IF HOST-COUNT > 366 */

            if (WAREA_TRABALHO.HOST_COUNT > 366)
            {

                /*" -912- DISPLAY ' LT3117S - PROBLEMAS NO COUNT DIAS VIG APO=' LT3117-NUM-APOLICE ' QTD DIAS=' HOST-COUNT ' DATA INI=' HOST-DATA-INI ' DATA TER=' HOST-DATA-FIM ' LIMITADO PARA 366' */

                $" LT3117S - PROBLEMAS NO COUNT DIAS VIG APO={LBLT3117.LT3117_NUM_APOLICE} QTD DIAS={WAREA_TRABALHO.HOST_COUNT} DATA INI={WAREA_TRABALHO.HOST_DATA_INI} DATA TER={WAREA_TRABALHO.HOST_DATA_FIM} LIMITADO PARA 366"
                .Display();

                /*" -914- MOVE 366 TO HOST-COUNT . */
                _.Move(366, WAREA_TRABALHO.HOST_COUNT);
            }


            /*" -915- IF WS-DISPLAY NOT EQUAL SPACES */

            if (!WAREA_TRABALHO.WS_DISPLAY.IsEmpty())
            {

                /*" -918- DISPLAY ' LT3117S - APO =' LT3117-NUM-APOLICE ' DATA-INI=' HOST-DATA-INI ' DATA-TER=' HOST-DATA-FIM ' QTD-DIAS=' HOST-COUNT . */

                $" LT3117S - APO ={LBLT3117.LT3117_NUM_APOLICE} DATA-INI={WAREA_TRABALHO.HOST_DATA_INI} DATA-TER={WAREA_TRABALHO.HOST_DATA_FIM} QTD-DIAS={WAREA_TRABALHO.HOST_COUNT}"
                .Display();
            }


        }

        [StopWatch]
        /*" R1100-00-OBTEM-QTD-DIAS-DB-SELECT-1 */
        public void R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1()
        {
            /*" -896- EXEC SQL SELECT COUNT(*) INTO :HOST-COUNT FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO >= :HOST-DATA-INI AND DATA_CALENDARIO < :HOST-DATA-FIM END-EXEC. */

            var r1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1 = new R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1()
            {
                HOST_DATA_INI = WAREA_TRABALHO.HOST_DATA_INI.ToString(),
                HOST_DATA_FIM = WAREA_TRABALHO.HOST_DATA_FIM.ToString(),
            };

            var executed_1 = R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1.Execute(r1100_00_OBTEM_QTD_DIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, WAREA_TRABALHO.HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-LE-PRAZOSEG-SECTION */
        private void R1200_00_LE_PRAZOSEG_SECTION()
        {
            /*" -931- MOVE 'R1200' TO WNR-EXEC-SQL. */
            _.Move("R1200", WAREA_TRABALHO.WABEND.WNR_EXEC_SQL);

            /*" -944- PERFORM R1200_00_LE_PRAZOSEG_DB_SELECT_1 */

            R1200_00_LE_PRAZOSEG_DB_SELECT_1();

            /*" -947- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -950- DISPLAY 'LT3117S - PROBLEMAS NO SELECT PRAZO_SEGURO' ' ' LTMVPROP-NUM-APOLICE ' ' PRAZOSEG-INICIO-PRAZO */

                $"LT3117S - PROBLEMAS NO SELECT PRAZO_SEGURO {LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_APOLICE} {PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_INICIO_PRAZO}"
                .Display();

                /*" -950- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-LE-PRAZOSEG-DB-SELECT-1 */
        public void R1200_00_LE_PRAZOSEG_DB_SELECT_1()
        {
            /*" -944- EXEC SQL SELECT A.PCT_PRM_ANUAL INTO :PRAZOSEG-PCT-PRM-ANUAL FROM SEGUROS.PRAZO_SEGURO A WHERE A.COD_TABELA = 5 AND A.INICIO_PRAZO <= :PRAZOSEG-INICIO-PRAZO AND A.FIM_PRAZO >= :PRAZOSEG-INICIO-PRAZO AND A.DATA_INIVIGENCIA = (SELECT MAX(B.DATA_INIVIGENCIA) FROM SEGUROS.PRAZO_SEGURO B WHERE A.COD_TABELA = B.COD_TABELA AND A.INICIO_PRAZO = B.INICIO_PRAZO AND A.FIM_PRAZO = B.FIM_PRAZO) END-EXEC. */

            var r1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1 = new R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1()
            {
                PRAZOSEG_INICIO_PRAZO = PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_INICIO_PRAZO.ToString(),
            };

            var executed_1 = R1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1.Execute(r1200_00_LE_PRAZOSEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRAZOSEG_PCT_PRM_ANUAL, PRAZOSEG.DCLPRAZO_SEGURO.PRAZOSEG_PCT_PRM_ANUAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-LE-ENDOSSOS-SECTION */
        private void R0200_00_LE_ENDOSSOS_SECTION()
        {
            /*" -960- MOVE 'R0200' TO WNR-EXEC-SQL. */
            _.Move("R0200", WAREA_TRABALHO.WABEND.WNR_EXEC_SQL);

            /*" -962- MOVE LT3117-NUM-APOLICE TO V0APO-NUM-APOLICE */
            _.Move(LBLT3117.LT3117_NUM_APOLICE, WAREA_TRABALHO.V0APO_NUM_APOLICE);

            /*" -970- PERFORM R0200_00_LE_ENDOSSOS_DB_SELECT_1 */

            R0200_00_LE_ENDOSSOS_DB_SELECT_1();

            /*" -973- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -975- DISPLAY 'LT3117S - PROBLEMAS NO SELECT ENDOSSOS' '  - ' LT3117-NUM-APOLICE */

                $"LT3117S - PROBLEMAS NO SELECT ENDOSSOS  - {LBLT3117.LT3117_NUM_APOLICE}"
                .Display();

                /*" -977- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -979- DISPLAY ' APOLICE=' V0APO-NUM-APOLICE ' DTINIVIG=' ENDOSSOS-DATA-INIVIGENCIA ' DTTERVIG=' ENDOSSOS-DATA-TERVIGENCIA . */

            $" APOLICE={WAREA_TRABALHO.V0APO_NUM_APOLICE} DTINIVIG={ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA} DTTERVIG={ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA}"
            .Display();

        }

        [StopWatch]
        /*" R0200-00-LE-ENDOSSOS-DB-SELECT-1 */
        public void R0200_00_LE_ENDOSSOS_DB_SELECT_1()
        {
            /*" -970- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :ENDOSSOS-DATA-INIVIGENCIA, :ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :V0APO-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC. */

            var r0200_00_LE_ENDOSSOS_DB_SELECT_1_Query1 = new R0200_00_LE_ENDOSSOS_DB_SELECT_1_Query1()
            {
                V0APO_NUM_APOLICE = WAREA_TRABALHO.V0APO_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0200_00_LE_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0200_00_LE_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -990- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WAREA_TRABALHO.WABEND.WSQLCODE);

            /*" -993- DISPLAY WABEND */
            _.Display(WAREA_TRABALHO.WABEND);

            /*" -993- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -995- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -999- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -999- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}