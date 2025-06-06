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
using Sias.Sinistro.DB2.SI0846B;

namespace Code
{
    public class SI0846B
    {
        public bool IsCall { get; set; }

        public SI0846B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SISTEMA DE SINISTROS               *      */
        /*"      *   PROGRAMA ...............  SI0846B.                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PASTORE                            *      */
        /*"      *   PROG/ANALISTA...........  JEFFERSON                          *      */
        /*"      *   DATA CODIFICACAO .......  JULHO/1998                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  EMITIR ANALISE DE FREQUENCIA DE    *      */
        /*"      *                             SINISTROS DA APOLICE VASPEX        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *--------------------------------------------------------------- *      */
        /*"      * RELATORIOS                          V0RELATORIOS       I/O     *      */
        /*"      * SISTEMA                             V0SISTEMA          I       *      */
        /*"      * CLIENTE                             V0CLIENTE          I       *      */
        /*"      * SINISTRO-TRANSP1                    V0SINISTRO-TRANSP1 I       *      */
        /*"      * SINISTRO-MESTRE                     V0MESTSINI         I       *      */
        /*"      * SINISTRO-HISTORICO                  V0HISTSINI         I       *      */
        /*"      *                                                                *      */
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           11/09/1998  *      */
        /*"      *--------------------------------------------------------------- *      */
        #endregion


        #region VARIABLES

        public FileBasis _RSI0846B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RSI0846B
        {
            get
            {
                _.Move(REG_MOVTO, _RSI0846B); VarBasis.RedefinePassValue(REG_MOVTO, _RSI0846B, REG_MOVTO); return _RSI0846B;
            }
        }
        /*"01              REG-MOVTO           PIC  X(132).*/
        public StringBasis REG_MOVTO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V0DTMOVABE             PIC   X(010).*/
        public StringBasis V0DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0NUM-APOL-SINISTRO    PIC  S9(013)        VALUE +0 COMP-3.*/
        public IntBasis V0NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0COD-FRANQUE          PIC  S9(009)        VALUE +0 COMP.*/
        public IntBasis V0COD_FRANQUE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0IND-VAL-DECLARADO    PIC   X(001).*/
        public StringBasis V0IND_VAL_DECLARADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0QTD-ITENS-SINI       PIC  S9(004)        VALUE +0 COMP.*/
        public IntBasis V0QTD_ITENS_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0QTD-ITENS-TRANSP     PIC  S9(004)        VALUE +0 COMP.*/
        public IntBasis V0QTD_ITENS_TRANSP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0NUM-SINI-FRANQUE     PIC  S9(009)        VALUE +0 COMP.*/
        public IntBasis V0NUM_SINI_FRANQUE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0ANO-SINI-FRANQUE     PIC  S9(004)        VALUE +0 COMP.*/
        public IntBasis V0ANO_SINI_FRANQUE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0NUM-APOLICE          PIC  S9(013)        VALUE +0 COMP-3.*/
        public IntBasis V0NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0DATA-OCORR           PIC   X(010).*/
        public StringBasis V0DATA_OCORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0SITUACAO             PIC   X(001).*/
        public StringBasis V0SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0NOMEFAV              PIC   X(040).*/
        public StringBasis V0NOMEFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  V0DTMOVTO              PIC   X(010).*/
        public StringBasis V0DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0VAL-OPERACAO         PIC  S9(011)V9(2)   VALUE +0 COMP-3.*/
        public DoubleBasis V0VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(011)V9(2)"), 2);
        /*"77  V0VAL-OPERACAO-PEND    PIC  S9(011)V9(2)   VALUE +0 COMP-3.*/
        public DoubleBasis V0VAL_OPERACAO_PEND { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(011)V9(2)"), 2);
        /*"77  V0VAL-OPERACAO-PEND1   PIC  S9(011)V9(2)   VALUE +0 COMP-3.*/
        public DoubleBasis V0VAL_OPERACAO_PEND1 { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(011)V9(2)"), 2);
        /*"77  V0FRANQ-COD-CLIENTE    PIC  S9(009)        VALUE +0 COMP.*/
        public IntBasis V0FRANQ_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0FRANQ-COD-FRANQUEADO PIC  S9(015)        VALUE +0 COMP-3.*/
        public IntBasis V0FRANQ_COD_FRANQUEADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  V0CLIENTE-COD-CLIENTE  PIC  S9(009)        VALUE +0 COMP.*/
        public IntBasis V0CLIENTE_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0NOME-RAZAO           PIC   X(040).*/
        public StringBasis V0NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  V0CODUSU               PIC   X(008).*/
        public StringBasis V0CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  V0PERI-INICIAL         PIC   X(010).*/
        public StringBasis V0PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0PERI-FINAL           PIC   X(010).*/
        public StringBasis V0PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01        AREA-DE-WORK.*/
        public SI0846B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0846B_AREA_DE_WORK();
        public class SI0846B_AREA_DE_WORK : VarBasis
        {
            /*"  05      AC-LINHAS               PIC 9(002)      VALUE 80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05      WLIDOS-RELATORIOS       PIC 9(003)      VALUE ZEROS.*/
            public IntBasis WLIDOS_RELATORIOS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      WFIM-RELATORIOS         PIC X(001)      VALUE SPACES.*/
            public StringBasis WFIM_RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      ACUMUL-ZEROS.*/
            public SI0846B_ACUMUL_ZEROS ACUMUL_ZEROS { get; set; } = new SI0846B_ACUMUL_ZEROS();
            public class SI0846B_ACUMUL_ZEROS : VarBasis
            {
                /*"    07    AC-PAGINA               PIC 9(006)      VALUE ZEROS.*/
                public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    07    WLIDOS-V0TRANSP1        PIC 9(006)      VALUE ZEROS.*/
                public IntBasis WLIDOS_V0TRANSP1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    07    WLIDOS-V0SIN-PAGOS      PIC 9(006)      VALUE ZEROS.*/
                public IntBasis WLIDOS_V0SIN_PAGOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    07    WNUM-APOL-SINI-ANT      PIC 9(013)      VALUE ZEROS.*/
                public IntBasis WNUM_APOL_SINI_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    07    WTOT-SINISTRO-X         PIC 9(005)      VALUE ZEROS.*/
                public IntBasis WTOT_SINISTRO_X { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"    07    WTOT-ENCOM-SINI-X       PIC 9(005)      VALUE ZEROS.*/
                public IntBasis WTOT_ENCOM_SINI_X { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"    07    WTOT-ENCOM-TRANSP-X     PIC 9(005)      VALUE ZEROS.*/
                public IntBasis WTOT_ENCOM_TRANSP_X { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"    07    WTOT-INDENIZADO-X       PIC 9(010)V9(2) VALUE ZEROS.*/
                public DoubleBasis WTOT_INDENIZADO_X { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V9(2)"), 2);
                /*"    07    WTOT-PENDENTE-X         PIC 9(010)V9(2) VALUE ZEROS.*/
                public DoubleBasis WTOT_PENDENTE_X { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V9(2)"), 2);
                /*"  05      ACUMUL-SPACE.*/
            }
            public SI0846B_ACUMUL_SPACE ACUMUL_SPACE { get; set; } = new SI0846B_ACUMUL_SPACE();
            public class SI0846B_ACUMUL_SPACE : VarBasis
            {
                /*"    07    WFIM-V0TRANSP1          PIC X(001)      VALUE SPACES.*/
                public StringBasis WFIM_V0TRANSP1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    07    WFIM-V0SIN-PAGOS        PIC X(001)      VALUE SPACES.*/
                public StringBasis WFIM_V0SIN_PAGOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  05         AHRC-DATA-REL.*/
            }
            public SI0846B_AHRC_DATA_REL AHRC_DATA_REL { get; set; } = new SI0846B_AHRC_DATA_REL();
            public class SI0846B_AHRC_DATA_REL : VarBasis
            {
                /*"     10      AH-DD-REL            PIC  9(002)      VALUE ZEROS.*/
                public IntBasis AH_DD_REL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLER               PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10      AH-MM-REL            PIC  9(002)      VALUE ZEROS.*/
                public IntBasis AH_MM_REL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLER               PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10      AH-AA-REL            PIC  9(004)      VALUE ZEROS.*/
                public IntBasis AH_AA_REL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         AHRC-HORA-REL.*/
            }
            public SI0846B_AHRC_HORA_REL AHRC_HORA_REL { get; set; } = new SI0846B_AHRC_HORA_REL();
            public class SI0846B_AHRC_HORA_REL : VarBasis
            {
                /*"     10      AH-HH-REL            PIC  9(002)      VALUE ZEROS.*/
                public IntBasis AH_HH_REL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLER               PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"     10      AH-MN-REL            PIC  9(002)      VALUE ZEROS.*/
                public IntBasis AH_MN_REL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLER               PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"     10      AH-SS-REL            PIC  9(002)      VALUE ZEROS.*/
                public IntBasis AH_SS_REL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         AH-DATE.*/
            }
            public SI0846B_AH_DATE AH_DATE { get; set; } = new SI0846B_AH_DATE();
            public class SI0846B_AH_DATE : VarBasis
            {
                /*"     10      AH-AA-DATE           PIC  9(004)      VALUE ZEROS.*/
                public IntBasis AH_AA_DATE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     10      FILLER               PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     10      AH-MM-DATE           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis AH_MM_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLER               PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     10      AH-DD-DATE           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis AH_DD_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         AH-TIME.*/
            }
            public SI0846B_AH_TIME AH_TIME { get; set; } = new SI0846B_AH_TIME();
            public class SI0846B_AH_TIME : VarBasis
            {
                /*"     10      AH-HH-TIME           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis AH_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      AH-MM-TIME           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis AH_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      AH-SS-TIME           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis AH_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      AH-CC-TIME           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis AH_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-REL01.*/
            }
            public SI0846B_WDATA_REL01 WDATA_REL01 { get; set; } = new SI0846B_WDATA_REL01();
            public class SI0846B_WDATA_REL01 : VarBasis
            {
                /*"     10      W-AA-REL01           PIC  X(004)      VALUE SPACES.*/
                public StringBasis W_AA_REL01 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"     10      FILLER               PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     10      W-MM-REL01           PIC  X(002)      VALUE SPACES.*/
                public StringBasis W_MM_REL01 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"     10      FILLER               PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     10      W-DD-REL01           PIC  X(002)      VALUE SPACES.*/
                public StringBasis W_DD_REL01 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"  05         WDATA-REL02.*/
            }
            public SI0846B_WDATA_REL02 WDATA_REL02 { get; set; } = new SI0846B_WDATA_REL02();
            public class SI0846B_WDATA_REL02 : VarBasis
            {
                /*"     10      W-DD-REL02           PIC  X(002)      VALUE SPACES.*/
                public StringBasis W_DD_REL02 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"     10      FILLER               PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10      W-MM-REL02           PIC  X(002)      VALUE SPACES.*/
                public StringBasis W_MM_REL02 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"     10      FILLER               PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10      W-AA-REL02           PIC  X(004)      VALUE SPACES.*/
                public StringBasis W_AA_REL02 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"  05         WDATA-AUXILIAR.*/
            }
            public SI0846B_WDATA_AUXILIAR WDATA_AUXILIAR { get; set; } = new SI0846B_WDATA_AUXILIAR();
            public class SI0846B_WDATA_AUXILIAR : VarBasis
            {
                /*"     10      W-AA-AUX             PIC  9(004)      VALUE ZEROS.*/
                public IntBasis W_AA_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     10      FILLER               PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     10      W-MM-AUX             PIC  9(002)      VALUE ZEROS.*/
                public IntBasis W_MM_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLER               PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     10      W-DD-AUX             PIC  9(002)      VALUE ZEROS.*/
                public IntBasis W_DD_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATAPERIODO.*/
            }
            public SI0846B_WDATAPERIODO WDATAPERIODO { get; set; } = new SI0846B_WDATAPERIODO();
            public class SI0846B_WDATAPERIODO : VarBasis
            {
                /*"     10      W-DD-PERIO           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis W_DD_PERIO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLER               PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10      W-MM-PERIO           PIC  9(002)      VALUE ZEROS.*/
                public IntBasis W_MM_PERIO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLER               PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10      W-AA-PERIO           PIC  9(004)      VALUE ZEROS.*/
                public IntBasis W_AA_PERIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05        LC-01.*/
            }
            public SI0846B_LC_01 LC_01 { get; set; } = new SI0846B_LC_01();
            public class SI0846B_LC_01 : VarBasis
            {
                /*"     10     FILLER                PIC  X(045)   VALUE 'SI0846B'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"SI0846B");
                /*"     10     FILLER                PIC  X(071)   VALUE            'SASSE CIA. NACIONAL DE SEGUROS GERAIS'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "71", "X(071)"), @"SASSE CIA. NACIONAL DE SEGUROS GERAIS");
                /*"     10     FILLER                PIC  X(013)   VALUE 'PAGINA:'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"PAGINA:");
                /*"     10     LC-01-PAGINA          PIC  999.*/
                public IntBasis LC_01_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"  05        LC-02.*/
            }
            public SI0846B_LC_02 LC_02 { get; set; } = new SI0846B_LC_02();
            public class SI0846B_LC_02 : VarBasis
            {
                /*"     10     FILLER                PIC  X(043)   VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
                /*"     10     FILLER                PIC  X(073)   VALUE            '             SINISTROS VASPEX            '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "73", "X(073)"), @"             SINISTROS VASPEX            ");
                /*"     10     FILLER                PIC  X(006)   VALUE 'DATA:'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"DATA:");
                /*"     10     LC-02-DATA            PIC  X(010)   VALUE SPACES.*/
                public StringBasis LC_02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05        LC-03.*/
            }
            public SI0846B_LC_03 LC_03 { get; set; } = new SI0846B_LC_03();
            public class SI0846B_LC_03 : VarBasis
            {
                /*"     10     FILLER                PIC  X(009)   VALUE            'APOLICE: '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"APOLICE: ");
                /*"     10     WNUM-APOLICE          PIC  9(013)   VALUE ZEROS.*/
                public IntBasis WNUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"     10     FILLER                PIC  X(003)   VALUE ' - '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"     10     WDESCRPRODU           PIC  X(040)   VALUE 'VASPEX'.*/
                public StringBasis WDESCRPRODU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"VASPEX");
                /*"     10     FILLER                PIC  X(051)   VALUE SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"");
                /*"     10     FILLER                PIC  X(008)   VALUE 'HORA  :'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"HORA  :");
                /*"     10     LC-03-HORA            PIC  X(008)   VALUE SPACES.*/
                public StringBasis LC_03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05        LC-04.*/
            }
            public SI0846B_LC_04 LC_04 { get; set; } = new SI0846B_LC_04();
            public class SI0846B_LC_04 : VarBasis
            {
                /*"     10     WIND-VAL-DECLARADO    PIC  X(049)   VALUE SPACES.*/
                public StringBasis WIND_VAL_DECLARADO { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"");
                /*"     10     FILLER                PIC  X(009)   VALUE            'PERIODO: '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"PERIODO: ");
                /*"     10     WPERI-INICIAL         PIC  X(010)   VALUE SPACES.*/
                public StringBasis WPERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"     10     FILLER                PIC  X(003)   VALUE ' A '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"     10     WPERI-FINAL           PIC  X(010)   VALUE SPACES.*/
                public StringBasis WPERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05        LC-06.*/
            }
            public SI0846B_LC_06 LC_06 { get; set; } = new SI0846B_LC_06();
            public class SI0846B_LC_06 : VarBasis
            {
                /*"     10     FILLER                PIC  X(132)   VALUE ALL '-'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05        LC-07.*/
            }
            public SI0846B_LC_07 LC_07 { get; set; } = new SI0846B_LC_07();
            public class SI0846B_LC_07 : VarBasis
            {
                /*"     10     FILLER                PIC  X(027)   VALUE            '  N.SINISTRO   N.SINISTRO '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"  N.SINISTRO   N.SINISTRO ");
                /*"     10     FILLER                PIC  X(040)   VALUE            'NOME DO FAVORECIDO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"NOME DO FAVORECIDO");
                /*"     10     FILLER                PIC  X(025)   VALUE            ' DATA DA    QTD    QTD   '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @" DATA DA    QTD    QTD   ");
                /*"     10     FILLER                PIC  X(040)   VALUE            '      VALOR     DATA DA          VALOR  '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"      VALOR     DATA DA          VALOR  ");
                /*"  05        LC-08.*/
            }
            public SI0846B_LC_08 LC_08 { get; set; } = new SI0846B_LC_08();
            public class SI0846B_LC_08 : VarBasis
            {
                /*"     10     FILLER                PIC  X(027)   VALUE            '    VASPEX       SASSE    '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"    VASPEX       SASSE    ");
                /*"     10     FILLER                PIC  X(040)   VALUE SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"     10     FILLER                PIC  X(025)   VALUE            'OCORRENCIA TRANSP SINIST '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"OCORRENCIA TRANSP SINIST ");
                /*"     10     FILLER                PIC  X(040)   VALUE            '    INDENIZADO INDENIZAC.       PENDENTE'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"    INDENIZADO INDENIZAC.       PENDENTE");
                /*"  05        LC-09.*/
            }
            public SI0846B_LC_09 LC_09 { get; set; } = new SI0846B_LC_09();
            public class SI0846B_LC_09 : VarBasis
            {
                /*"     10     FILLER                PIC  X(067)   VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "67", "X(067)"), @"");
                /*"     10     FILLER                PIC  X(025)   VALUE            '           ------ ------ '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"           ------ ------ ");
                /*"     10     FILLER                PIC  X(040)   VALUE            '--------------            --------------'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"--------------            --------------");
                /*"01        LD-01.*/
            }
        }
        public SI0846B_LD_01 LD_01 { get; set; } = new SI0846B_LD_01();
        public class SI0846B_LD_01 : VarBasis
        {
            /*"  05      WNUM-VASPEX.*/
            public SI0846B_WNUM_VASPEX WNUM_VASPEX { get; set; } = new SI0846B_WNUM_VASPEX();
            public class SI0846B_WNUM_VASPEX : VarBasis
            {
                /*"    07    WNUM-SIN-VASPEX          PIC ZZZZZZ9.*/
                public IntBasis WNUM_SIN_VASPEX { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    07    WBARRA-VASPEX            PIC X(001)   VALUE '/'.*/
                public StringBasis WBARRA_VASPEX { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    07    WANO-SINISTRO            PIC ZZZ9B.*/
                public IntBasis WANO_SINISTRO { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9B."));
                /*"  05      WNUM-SASSE.*/
            }
            public SI0846B_WNUM_SASSE WNUM_SASSE { get; set; } = new SI0846B_WNUM_SASSE();
            public class SI0846B_WNUM_SASSE : VarBasis
            {
                /*"    07    WNUM-SIN-SASSE           PIC ZZZZZZZZZZZZ9B.*/
                public IntBasis WNUM_SIN_SASSE { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9B."));
                /*"  05      WNOME-FAVORECIDO         PIC X(039)   VALUE SPACES.*/
            }
            public StringBasis WNOME_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"");
            /*"  05      FILLER                   PIC X(001)   VALUE SPACES.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WDATA-OCORR.*/
            public SI0846B_WDATA_OCORR WDATA_OCORR { get; set; } = new SI0846B_WDATA_OCORR();
            public class SI0846B_WDATA_OCORR : VarBasis
            {
                /*"    07    W-DD-OCORR               PIC 9(002)   VALUE ZEROS.*/
                public IntBasis W_DD_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    07    WBARRA-DT-OCOR01         PIC X(001)   VALUE '/'.*/
                public StringBasis WBARRA_DT_OCOR01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    07    W-MM-OCORR               PIC 9(002)   VALUE ZEROS.*/
                public IntBasis W_MM_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    07    WBARRA-DT-OCOR02         PIC X(001)   VALUE '/'.*/
                public StringBasis WBARRA_DT_OCOR02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    07    W-AA-OCORR               PIC 9(004)   VALUE ZEROS.*/
                public IntBasis W_AA_OCORR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05      FILLER                   PIC X(002)   VALUE SPACES.*/
            }
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      WQTD-ENCOM-TRANSP1.*/
            public SI0846B_WQTD_ENCOM_TRANSP1 WQTD_ENCOM_TRANSP1 { get; set; } = new SI0846B_WQTD_ENCOM_TRANSP1();
            public class SI0846B_WQTD_ENCOM_TRANSP1 : VarBasis
            {
                /*"    07    WQTD-ENCOM-TRANSP        PIC ZZZZ9BB.*/
                public IntBasis WQTD_ENCOM_TRANSP { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9BB."));
                /*"  05      WQTD-ENCOM-SINI1.*/
            }
            public SI0846B_WQTD_ENCOM_SINI1 WQTD_ENCOM_SINI1 { get; set; } = new SI0846B_WQTD_ENCOM_SINI1();
            public class SI0846B_WQTD_ENCOM_SINI1 : VarBasis
            {
                /*"    07    WQTD-ENCOM-SINI          PIC ZZZZ9B.*/
                public IntBasis WQTD_ENCOM_SINI { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9B."));
                /*"  05      WVAL-INDENIZADO          PIC ZZZ.ZZZ.ZZ9,99B.*/
            }
            public DoubleBasis WVAL_INDENIZADO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99B."), 2);
            /*"  05      WDATA-INDENIZAC.*/
            public SI0846B_WDATA_INDENIZAC WDATA_INDENIZAC { get; set; } = new SI0846B_WDATA_INDENIZAC();
            public class SI0846B_WDATA_INDENIZAC : VarBasis
            {
                /*"    07    W-DD-INDEN               PIC 9(002)   VALUE ZEROS.*/
                public IntBasis W_DD_INDEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    07    WBARRA-DT-OCOR03         PIC X(001)   VALUE '/'.*/
                public StringBasis WBARRA_DT_OCOR03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    07    W-MM-INDEN               PIC 9(002)   VALUE ZEROS.*/
                public IntBasis W_MM_INDEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    07    WBARRA-DT-OCOR04         PIC X(001)   VALUE '/'.*/
                public StringBasis WBARRA_DT_OCOR04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    07    W-AA-INDEN               PIC 9(004)   VALUE ZEROS.*/
                public IntBasis W_AA_INDEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05      FILLER                   PIC X(001)   VALUE SPACES.*/
            }
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WVAL-PENDENTE1.*/
            public SI0846B_WVAL_PENDENTE1 WVAL_PENDENTE1 { get; set; } = new SI0846B_WVAL_PENDENTE1();
            public class SI0846B_WVAL_PENDENTE1 : VarBasis
            {
                /*"    07    WVAL-PENDENTE            PIC ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis WVAL_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"01        LD-02.*/
            }
        }
        public SI0846B_LD_02 LD_02 { get; set; } = new SI0846B_LD_02();
        public class SI0846B_LD_02 : VarBasis
        {
            /*"  05      FILLER                   PIC X(015)   VALUE          'QTD SINISTROS: '.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"QTD SINISTROS: ");
            /*"  05      WTOT-SINISTRO            PIC ZZZZ9.*/
            public IntBasis WTOT_SINISTRO { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
            /*"  05      FILLER                   PIC X(050)   VALUE SPACES.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
            /*"  05      FILLER                   PIC X(009)   VALUE          'TOTAIS: '.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"TOTAIS: ");
            /*"  05      WTOT-ENCOM-TRANSP        PIC ZZZZ9BB.*/
            public IntBasis WTOT_ENCOM_TRANSP { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9BB."));
            /*"  05      WTOT-ENCOM-SINI          PIC ZZZZ9B.*/
            public IntBasis WTOT_ENCOM_SINI { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9B."));
            /*"  05      WTOT-INDENIZADO          PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WTOT_INDENIZADO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05      FILLER                   PIC X(012)   VALUE SPACES.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05      WTOT-PENDENTE            PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WTOT_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"01        WABEND.*/
        }
        public SI0846B_WABEND WABEND { get; set; } = new SI0846B_WABEND();
        public class SI0846B_WABEND : VarBasis
        {
            /*"  05      FILLER                 PIC  X(010) VALUE         ' SI0846B'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0846B");
            /*"  05      FILLER                 PIC  X(026) VALUE         ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05      WNR-EXEC-SQL           PIC  X(005) VALUE '00000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"00000");
            /*"  05      FILLER                 PIC  X(013) VALUE         ' *** SQLCODE '.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05      WSQLCODE               PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }


        public SI0846B_V0RELATORIOS V0RELATORIOS { get; set; } = new SI0846B_V0RELATORIOS();
        public SI0846B_V0TRANSP1 V0TRANSP1 { get; set; } = new SI0846B_V0TRANSP1();
        public SI0846B_V0SIN_PAGOS V0SIN_PAGOS { get; set; } = new SI0846B_V0SIN_PAGOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RSI0846B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RSI0846B.SetFile(RSI0846B_FILE_NAME_P);

                /*" -330- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", WABEND.WNR_EXEC_SQL);

                /*" -331- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -334- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -337- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -337- FLUXCONTROL_PERFORM R0000-00-ROTINA-INICIAL-SECTION */

                R0000_00_ROTINA_INICIAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-ROTINA-INICIAL-SECTION */
        private void R0000_00_ROTINA_INICIAL_SECTION()
        {
            /*" -345- PERFORM R0100-00-OBTER-DATA-SISTEMA */

            R0100_00_OBTER_DATA_SISTEMA_SECTION();

            /*" -347- MOVE V0DTMOVABE TO AH-DATE */
            _.Move(V0DTMOVABE, AREA_DE_WORK.AH_DATE);

            /*" -348- MOVE AH-DD-DATE TO AH-DD-REL */
            _.Move(AREA_DE_WORK.AH_DATE.AH_DD_DATE, AREA_DE_WORK.AHRC_DATA_REL.AH_DD_REL);

            /*" -349- MOVE AH-MM-DATE TO AH-MM-REL */
            _.Move(AREA_DE_WORK.AH_DATE.AH_MM_DATE, AREA_DE_WORK.AHRC_DATA_REL.AH_MM_REL);

            /*" -351- MOVE AH-AA-DATE TO AH-AA-REL */
            _.Move(AREA_DE_WORK.AH_DATE.AH_AA_DATE, AREA_DE_WORK.AHRC_DATA_REL.AH_AA_REL);

            /*" -353- MOVE AHRC-DATA-REL TO LC-02-DATA */
            _.Move(AREA_DE_WORK.AHRC_DATA_REL, AREA_DE_WORK.LC_02.LC_02_DATA);

            /*" -355- ACCEPT AH-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.AH_TIME);

            /*" -356- MOVE AH-HH-TIME TO AH-HH-REL */
            _.Move(AREA_DE_WORK.AH_TIME.AH_HH_TIME, AREA_DE_WORK.AHRC_HORA_REL.AH_HH_REL);

            /*" -357- MOVE AH-MM-TIME TO AH-MN-REL */
            _.Move(AREA_DE_WORK.AH_TIME.AH_MM_TIME, AREA_DE_WORK.AHRC_HORA_REL.AH_MN_REL);

            /*" -359- MOVE AH-SS-TIME TO AH-SS-REL */
            _.Move(AREA_DE_WORK.AH_TIME.AH_SS_TIME, AREA_DE_WORK.AHRC_HORA_REL.AH_SS_REL);

            /*" -361- MOVE AHRC-HORA-REL TO LC-03-HORA */
            _.Move(AREA_DE_WORK.AHRC_HORA_REL, AREA_DE_WORK.LC_03.LC_03_HORA);

            /*" -363- PERFORM R0110-00-ABRIR-ARQUIVOS */

            R0110_00_ABRIR_ARQUIVOS_SECTION();

            /*" -364- PERFORM R0200-00-DECLARE-V0RELATORIOS */

            R0200_00_DECLARE_V0RELATORIOS_SECTION();

            /*" -365- PERFORM R0210-00-FETCH-V0RELATORIOS */

            R0210_00_FETCH_V0RELATORIOS_SECTION();

            /*" -368- PERFORM R0220-00-ROTINA-PRINCIPAL UNTIL WFIM-RELATORIOS NOT EQUAL SPACE */

            while (!(AREA_DE_WORK.WFIM_RELATORIOS != " "))
            {

                R0220_00_ROTINA_PRINCIPAL_SECTION();
            }

            /*" -370- PERFORM R0120-00-FECHAR-ARQUIVOS */

            R0120_00_FECHAR_ARQUIVOS_SECTION();

            /*" -371- DISPLAY 'SOLICITADO POR..........: ' V0CODUSU. */
            _.Display($"SOLICITADO POR..........: {V0CODUSU}");

            /*" -372- DISPLAY 'TOTAL SINISTROS.........: ' WLIDOS-V0TRANSP1. */
            _.Display($"TOTAL SINISTROS.........: {AREA_DE_WORK.ACUMUL_ZEROS.WLIDOS_V0TRANSP1}");

            /*" -373- DISPLAY 'TOTAL ENCOMEND. PAG/PEND: ' WTOT-ENCOM-SINI-X. */
            _.Display($"TOTAL ENCOMEND. PAG/PEND: {AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_SINI_X}");

            /*" -374- DISPLAY 'TOTAL ENCOMEND. TRANSP..: ' WTOT-ENCOM-TRANSP-X. */
            _.Display($"TOTAL ENCOMEND. TRANSP..: {AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_TRANSP_X}");

            /*" -375- DISPLAY 'TOTAL LIDOS NA RELATOR..: ' WLIDOS-RELATORIOS. */
            _.Display($"TOTAL LIDOS NA RELATOR..: {AREA_DE_WORK.WLIDOS_RELATORIOS}");

            /*" -377- DISPLAY '***  SI0846B - FIM NORMAL  ***' */
            _.Display($"***  SI0846B - FIM NORMAL  ***");

            /*" -379- PERFORM R0130-00-DELETE-V0RELATORIOS. */

            R0130_00_DELETE_V0RELATORIOS_SECTION();

            /*" -379- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -383- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -383- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-OBTER-DATA-SISTEMA-SECTION */
        private void R0100_00_OBTER_DATA_SISTEMA_SECTION()
        {
            /*" -395- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", WABEND.WNR_EXEC_SQL);

            /*" -400- PERFORM R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1 */

            R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1();

            /*" -403- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -404- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -405- DISPLAY 'PROGRAMA : SI0846B' */
                    _.Display($"PROGRAMA : SI0846B");

                    /*" -406- DISPLAY 'FALTA DATA DO SISTEMA SI' */
                    _.Display($"FALTA DATA DO SISTEMA SI");

                    /*" -407- DISPLAY 'ERRO DE ACESSO EM V0SISTEMA' */
                    _.Display($"ERRO DE ACESSO EM V0SISTEMA");

                    /*" -407- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0100-00-OBTER-DATA-SISTEMA-DB-SELECT-1 */
        public void R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1()
        {
            /*" -400- EXEC SQL SELECT DTMOVABE INTO :V0DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var r0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1 = new R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0DTMOVABE, V0DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-ABRIR-ARQUIVOS-SECTION */
        private void R0110_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -416- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", WABEND.WNR_EXEC_SQL);

            /*" -416- OPEN OUTPUT RSI0846B. */
            RSI0846B.Open(REG_MOVTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-FECHAR-ARQUIVOS-SECTION */
        private void R0120_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -424- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", WABEND.WNR_EXEC_SQL);

            /*" -424- CLOSE RSI0846B. */
            RSI0846B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V0RELATORIOS-SECTION */
        private void R0200_00_DECLARE_V0RELATORIOS_SECTION()
        {
            /*" -434- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WABEND.WNR_EXEC_SQL);

            /*" -443- PERFORM R0200_00_DECLARE_V0RELATORIOS_DB_DECLARE_1 */

            R0200_00_DECLARE_V0RELATORIOS_DB_DECLARE_1();

            /*" -445- PERFORM R0200_00_DECLARE_V0RELATORIOS_DB_OPEN_1 */

            R0200_00_DECLARE_V0RELATORIOS_DB_OPEN_1();

            /*" -448- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -449- DISPLAY 'ERRO NO DECLARE DO V0RELATORIOS' */
                _.Display($"ERRO NO DECLARE DO V0RELATORIOS");

                /*" -449- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0RELATORIOS-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V0RELATORIOS_DB_DECLARE_1()
        {
            /*" -443- EXEC SQL DECLARE V0RELATORIOS CURSOR FOR SELECT CODUSU , PERI_INICIAL , PERI_FINAL , NUM_APOLICE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0846B' AND DATA_SOLICITACAO = :V0DTMOVABE END-EXEC. */
            V0RELATORIOS = new SI0846B_V0RELATORIOS(true);
            string GetQuery_V0RELATORIOS()
            {
                var query = @$"SELECT CODUSU
							, 
							PERI_INICIAL
							, 
							PERI_FINAL
							, 
							NUM_APOLICE 
							FROM SEGUROS.V0RELATORIOS 
							WHERE IDSISTEM = 'SI' 
							AND CODRELAT = 'SI0846B' 
							AND DATA_SOLICITACAO = '{V0DTMOVABE}'";

                return query;
            }
            V0RELATORIOS.GetQueryEvent += GetQuery_V0RELATORIOS;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0RELATORIOS-DB-OPEN-1 */
        public void R0200_00_DECLARE_V0RELATORIOS_DB_OPEN_1()
        {
            /*" -445- EXEC SQL OPEN V0RELATORIOS END-EXEC. */

            V0RELATORIOS.Open();

        }

        [StopWatch]
        /*" R0300-00-DECLARE-SINI-TRANSP1-DB-DECLARE-1 */
        public void R0300_00_DECLARE_SINI_TRANSP1_DB_DECLARE_1()
        {
            /*" -578- EXEC SQL DECLARE V0TRANSP1 CURSOR FOR SELECT T.NUM_APOL_SINISTRO , T.COD_FRANQUE , T.QTD_ITENS_SINI , T.QTD_ITENS_TRANSP , T.NUM_SINI_FRANQUE , T.ANO_SINI_FRANQUE , M.DATORR , M.NUM_APOLICE FROM SEGUROS.V0MESTSINI M, SEGUROS.V0SINISTRO_TRANSP1 T WHERE M.NUM_APOLICE = :V0NUM-APOLICE AND M.SITUACAO <> '2' AND M.NUM_APOL_SINISTRO = T.NUM_APOL_SINISTRO AND M.DATORR BETWEEN :V0PERI-INICIAL AND :V0PERI-FINAL ORDER BY T.NUM_SINI_FRANQUE, T.ANO_SINI_FRANQUE, T.COD_FRANQUE, T.NUM_APOL_SINISTRO END-EXEC. */
            V0TRANSP1 = new SI0846B_V0TRANSP1(true);
            string GetQuery_V0TRANSP1()
            {
                var query = @$"SELECT T.NUM_APOL_SINISTRO
							, 
							T.COD_FRANQUE
							, 
							T.QTD_ITENS_SINI
							, 
							T.QTD_ITENS_TRANSP
							, 
							T.NUM_SINI_FRANQUE
							, 
							T.ANO_SINI_FRANQUE
							, 
							M.DATORR
							, 
							M.NUM_APOLICE 
							FROM SEGUROS.V0MESTSINI M
							, 
							SEGUROS.V0SINISTRO_TRANSP1 T 
							WHERE M.NUM_APOLICE = '{V0NUM_APOLICE}' 
							AND M.SITUACAO <> '2' 
							AND M.NUM_APOL_SINISTRO = T.NUM_APOL_SINISTRO 
							AND M.DATORR BETWEEN '{V0PERI_INICIAL}' 
							AND '{V0PERI_FINAL}' 
							ORDER BY T.NUM_SINI_FRANQUE
							, 
							T.ANO_SINI_FRANQUE
							, 
							T.COD_FRANQUE
							, 
							T.NUM_APOL_SINISTRO";

                return query;
            }
            V0TRANSP1.GetQueryEvent += GetQuery_V0TRANSP1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0RELATORIOS-SECTION */
        private void R0210_00_FETCH_V0RELATORIOS_SECTION()
        {
            /*" -461- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", WABEND.WNR_EXEC_SQL);

            /*" -466- PERFORM R0210_00_FETCH_V0RELATORIOS_DB_FETCH_1 */

            R0210_00_FETCH_V0RELATORIOS_DB_FETCH_1();

            /*" -469- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -470- DISPLAY '** DADOS SOLICITADOS VIA V0RELATORIOS **' */
                _.Display($"** DADOS SOLICITADOS VIA V0RELATORIOS **");

                /*" -475- DISPLAY 'USUARIO = ' V0CODUSU ' APOLICE = ' V0NUM-APOLICE ' PERIODO INICIAL = ' V0PERI-INICIAL ' PERIODO FINAL = ' V0PERI-FINAL. */

                $"USUARIO = {V0CODUSU} APOLICE = {V0NUM_APOLICE} PERIODO INICIAL = {V0PERI_INICIAL} PERIODO FINAL = {V0PERI_FINAL}"
                .Display();
            }


            /*" -476- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -477- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -478- MOVE 'S' TO WFIM-RELATORIOS */
                    _.Move("S", AREA_DE_WORK.WFIM_RELATORIOS);

                    /*" -478- PERFORM R0210_00_FETCH_V0RELATORIOS_DB_CLOSE_1 */

                    R0210_00_FETCH_V0RELATORIOS_DB_CLOSE_1();

                    /*" -480- ELSE */
                }
                else
                {


                    /*" -481- DISPLAY 'ERRO NO FETCH DO V0RELATORIOS' */
                    _.Display($"ERRO NO FETCH DO V0RELATORIOS");

                    /*" -482- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -483- END-IF */
                }


                /*" -484- ELSE */
            }
            else
            {


                /*" -484- ADD 1 TO WLIDOS-RELATORIOS. */
                AREA_DE_WORK.WLIDOS_RELATORIOS.Value = AREA_DE_WORK.WLIDOS_RELATORIOS + 1;
            }


        }

        [StopWatch]
        /*" R0210-00-FETCH-V0RELATORIOS-DB-FETCH-1 */
        public void R0210_00_FETCH_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -466- EXEC SQL FETCH V0RELATORIOS INTO :V0CODUSU , :V0PERI-INICIAL , :V0PERI-FINAL , :V0NUM-APOLICE END-EXEC. */

            if (V0RELATORIOS.Fetch())
            {
                _.Move(V0RELATORIOS.V0CODUSU, V0CODUSU);
                _.Move(V0RELATORIOS.V0PERI_INICIAL, V0PERI_INICIAL);
                _.Move(V0RELATORIOS.V0PERI_FINAL, V0PERI_FINAL);
                _.Move(V0RELATORIOS.V0NUM_APOLICE, V0NUM_APOLICE);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0RELATORIOS-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0RELATORIOS_DB_CLOSE_1()
        {
            /*" -478- EXEC SQL CLOSE V0RELATORIOS END-EXEC */

            V0RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-ROTINA-PRINCIPAL-SECTION */
        private void R0220_00_ROTINA_PRINCIPAL_SECTION()
        {
            /*" -496- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", WABEND.WNR_EXEC_SQL);

            /*" -497- MOVE ZEROS TO ACUMUL-ZEROS. */
            _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS);

            /*" -498- MOVE SPACES TO ACUMUL-SPACE. */
            _.Move("", AREA_DE_WORK.ACUMUL_SPACE);

            /*" -500- MOVE 80 TO AC-LINHAS. */
            _.Move(80, AREA_DE_WORK.AC_LINHAS);

            /*" -501- MOVE V0PERI-INICIAL TO WDATA-AUXILIAR */
            _.Move(V0PERI_INICIAL, AREA_DE_WORK.WDATA_AUXILIAR);

            /*" -502- MOVE W-AA-AUX TO W-AA-PERIO */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_AA_AUX, AREA_DE_WORK.WDATAPERIODO.W_AA_PERIO);

            /*" -503- MOVE W-MM-AUX TO W-MM-PERIO */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_MM_AUX, AREA_DE_WORK.WDATAPERIODO.W_MM_PERIO);

            /*" -504- MOVE W-DD-AUX TO W-DD-PERIO */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_DD_AUX, AREA_DE_WORK.WDATAPERIODO.W_DD_PERIO);

            /*" -506- MOVE WDATAPERIODO TO WPERI-INICIAL */
            _.Move(AREA_DE_WORK.WDATAPERIODO, AREA_DE_WORK.LC_04.WPERI_INICIAL);

            /*" -507- MOVE V0PERI-FINAL TO WDATA-AUXILIAR */
            _.Move(V0PERI_FINAL, AREA_DE_WORK.WDATA_AUXILIAR);

            /*" -508- MOVE W-AA-AUX TO W-AA-PERIO */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_AA_AUX, AREA_DE_WORK.WDATAPERIODO.W_AA_PERIO);

            /*" -509- MOVE W-MM-AUX TO W-MM-PERIO */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_MM_AUX, AREA_DE_WORK.WDATAPERIODO.W_MM_PERIO);

            /*" -510- MOVE W-DD-AUX TO W-DD-PERIO */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_DD_AUX, AREA_DE_WORK.WDATAPERIODO.W_DD_PERIO);

            /*" -512- MOVE WDATAPERIODO TO WPERI-FINAL */
            _.Move(AREA_DE_WORK.WDATAPERIODO, AREA_DE_WORK.LC_04.WPERI_FINAL);

            /*" -514- MOVE V0NUM-APOLICE TO WNUM-APOLICE */
            _.Move(V0NUM_APOLICE, AREA_DE_WORK.LC_03.WNUM_APOLICE);

            /*" -515- PERFORM R0300-00-DECLARE-SINI-TRANSP1 */

            R0300_00_DECLARE_SINI_TRANSP1_SECTION();

            /*" -516- PERFORM R0310-00-FETCH-SINI-TRANSP1 */

            R0310_00_FETCH_SINI_TRANSP1_SECTION();

            /*" -519- PERFORM R0320-00-TRATA-COD-VASPEX UNTIL WFIM-V0TRANSP1 NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.ACUMUL_SPACE.WFIM_V0TRANSP1.IsEmpty()))
            {

                R0320_00_TRATA_COD_VASPEX_SECTION();
            }

            /*" -524- PERFORM R0800-00-IMPRIME-LINHA-TOT. */

            R0800_00_IMPRIME_LINHA_TOT_SECTION();

            /*" -524- PERFORM R0210-00-FETCH-V0RELATORIOS. */

            R0210_00_FETCH_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-DELETE-V0RELATORIOS-SECTION */
        private void R0130_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -536- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", WABEND.WNR_EXEC_SQL);

            /*" -541- PERFORM R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -544- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -545- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -546- DISPLAY 'ERRO DE DELECAO NA V0RELATORIOS' */
                    _.Display($"ERRO DE DELECAO NA V0RELATORIOS");

                    /*" -546- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0130-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -541- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0846B' AND DATA_SOLICITACAO = :V0DTMOVABE END-EXEC. */

            var r0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
                V0DTMOVABE = V0DTMOVABE.ToString(),
            };

            R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(r0130_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-SINI-TRANSP1-SECTION */
        private void R0300_00_DECLARE_SINI_TRANSP1_SECTION()
        {
            /*" -558- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", WABEND.WNR_EXEC_SQL);

            /*" -578- PERFORM R0300_00_DECLARE_SINI_TRANSP1_DB_DECLARE_1 */

            R0300_00_DECLARE_SINI_TRANSP1_DB_DECLARE_1();

            /*" -580- PERFORM R0300_00_DECLARE_SINI_TRANSP1_DB_OPEN_1 */

            R0300_00_DECLARE_SINI_TRANSP1_DB_OPEN_1();

            /*" -583- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -584- DISPLAY 'ERRO NO DECLARE DA V0MESTSINI/V0SINISTRO-TRANSP' */
                _.Display($"ERRO NO DECLARE DA V0MESTSINI/V0SINISTRO-TRANSP");

                /*" -584- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-SINI-TRANSP1-DB-OPEN-1 */
        public void R0300_00_DECLARE_SINI_TRANSP1_DB_OPEN_1()
        {
            /*" -580- EXEC SQL OPEN V0TRANSP1 END-EXEC. */

            V0TRANSP1.Open();

        }

        [StopWatch]
        /*" R0500-00-SELECT-V0HISTSINI-DB-DECLARE-1 */
        public void R0500_00_SELECT_V0HISTSINI_DB_DECLARE_1()
        {
            /*" -712- EXEC SQL DECLARE V0SIN-PAGOS CURSOR FOR SELECT NOMFAV , DTMOVTO , VALUE(SUM(VAL_OPERACAO),0) FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V0NUM-APOL-SINISTRO AND SITUACAO <> '2' AND OPERACAO IN (1001,1002,1003,1004,1009) GROUP BY DTMOVTO, NOMFAV ORDER BY DTMOVTO, NOMFAV END-EXEC. */
            V0SIN_PAGOS = new SI0846B_V0SIN_PAGOS(true);
            string GetQuery_V0SIN_PAGOS()
            {
                var query = @$"SELECT NOMFAV
							, 
							DTMOVTO
							, 
							VALUE(SUM(VAL_OPERACAO)
							,0) 
							FROM SEGUROS.V0HISTSINI 
							WHERE NUM_APOL_SINISTRO = '{V0NUM_APOL_SINISTRO}' 
							AND SITUACAO <> '2' 
							AND OPERACAO IN (1001
							,1002
							,1003
							,1004
							,1009) 
							GROUP BY DTMOVTO
							, 
							NOMFAV 
							ORDER BY DTMOVTO
							, 
							NOMFAV";

                return query;
            }
            V0SIN_PAGOS.GetQueryEvent += GetQuery_V0SIN_PAGOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-SINI-TRANSP1-SECTION */
        private void R0310_00_FETCH_SINI_TRANSP1_SECTION()
        {
            /*" -596- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -605- PERFORM R0310_00_FETCH_SINI_TRANSP1_DB_FETCH_1 */

            R0310_00_FETCH_SINI_TRANSP1_DB_FETCH_1();

            /*" -608- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -610- ADD 1 TO WLIDOS-V0TRANSP1. */
                AREA_DE_WORK.ACUMUL_ZEROS.WLIDOS_V0TRANSP1.Value = AREA_DE_WORK.ACUMUL_ZEROS.WLIDOS_V0TRANSP1 + 1;
            }


            /*" -611- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -612- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -613- MOVE 'S' TO WFIM-V0TRANSP1 */
                    _.Move("S", AREA_DE_WORK.ACUMUL_SPACE.WFIM_V0TRANSP1);

                    /*" -613- PERFORM R0310_00_FETCH_SINI_TRANSP1_DB_CLOSE_1 */

                    R0310_00_FETCH_SINI_TRANSP1_DB_CLOSE_1();

                    /*" -615- ELSE */
                }
                else
                {


                    /*" -616- DISPLAY 'ERRO NO FETCH DA V0MESTSINI/V0SINISTRO-TRANS' */
                    _.Display($"ERRO NO FETCH DA V0MESTSINI/V0SINISTRO-TRANS");

                    /*" -616- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0310-00-FETCH-SINI-TRANSP1-DB-FETCH-1 */
        public void R0310_00_FETCH_SINI_TRANSP1_DB_FETCH_1()
        {
            /*" -605- EXEC SQL FETCH V0TRANSP1 INTO :V0NUM-APOL-SINISTRO , :V0COD-FRANQUE , :V0QTD-ITENS-SINI , :V0QTD-ITENS-TRANSP , :V0NUM-SINI-FRANQUE , :V0ANO-SINI-FRANQUE , :V0DATA-OCORR , :V0NUM-APOLICE END-EXEC. */

            if (V0TRANSP1.Fetch())
            {
                _.Move(V0TRANSP1.V0NUM_APOL_SINISTRO, V0NUM_APOL_SINISTRO);
                _.Move(V0TRANSP1.V0COD_FRANQUE, V0COD_FRANQUE);
                _.Move(V0TRANSP1.V0QTD_ITENS_SINI, V0QTD_ITENS_SINI);
                _.Move(V0TRANSP1.V0QTD_ITENS_TRANSP, V0QTD_ITENS_TRANSP);
                _.Move(V0TRANSP1.V0NUM_SINI_FRANQUE, V0NUM_SINI_FRANQUE);
                _.Move(V0TRANSP1.V0ANO_SINI_FRANQUE, V0ANO_SINI_FRANQUE);
                _.Move(V0TRANSP1.V0DATA_OCORR, V0DATA_OCORR);
                _.Move(V0TRANSP1.V0NUM_APOLICE, V0NUM_APOLICE);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-SINI-TRANSP1-DB-CLOSE-1 */
        public void R0310_00_FETCH_SINI_TRANSP1_DB_CLOSE_1()
        {
            /*" -613- EXEC SQL CLOSE V0TRANSP1 END-EXEC */

            V0TRANSP1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-TRATA-COD-VASPEX-SECTION */
        private void R0320_00_TRATA_COD_VASPEX_SECTION()
        {
            /*" -628- IF V0NUM-APOLICE LESS 0107100034848 */

            if (V0NUM_APOLICE < 0107100034848)
            {

                /*" -629- MOVE V0COD-FRANQUE TO V0CLIENTE-COD-CLIENTE */
                _.Move(V0COD_FRANQUE, V0CLIENTE_COD_CLIENTE);

                /*" -630- ELSE */
            }
            else
            {


                /*" -631- MOVE V0COD-FRANQUE TO V0FRANQ-COD-FRANQUEADO */
                _.Move(V0COD_FRANQUE, V0FRANQ_COD_FRANQUEADO);

                /*" -632- PERFORM R040-000-SELECT-V0FRANQ-VASPEX */

                R040_000_SELECT_V0FRANQ_VASPEX_SECTION();

                /*" -634- MOVE V0FRANQ-COD-CLIENTE TO V0CLIENTE-COD-CLIENTE. */
                _.Move(V0FRANQ_COD_CLIENTE, V0CLIENTE_COD_CLIENTE);
            }


            /*" -636- PERFORM R0450-00-SELECT-V0CLIENTE. */

            R0450_00_SELECT_V0CLIENTE_SECTION();

            /*" -638- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", WABEND.WNR_EXEC_SQL);

            /*" -641- PERFORM R0500-00-SELECT-V0HISTSINI UNTIL WFIM-V0SIN-PAGOS NOT = SPACES. */

            while (!(!AREA_DE_WORK.ACUMUL_SPACE.WFIM_V0SIN_PAGOS.IsEmpty()))
            {

                R0500_00_SELECT_V0HISTSINI_SECTION();
            }

            /*" -642- ADD 1 TO WTOT-SINISTRO-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X.Value = AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X + 1;

            /*" -643- MOVE SPACES TO WFIM-V0SIN-PAGOS. */
            _.Move("", AREA_DE_WORK.ACUMUL_SPACE.WFIM_V0SIN_PAGOS);

            /*" -644- MOVE ZEROS TO WLIDOS-V0SIN-PAGOS. */
            _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WLIDOS_V0SIN_PAGOS);

            /*" -645- MOVE ZEROS TO V0VAL-OPERACAO. */
            _.Move(0, V0VAL_OPERACAO);

            /*" -646- MOVE SPACES TO V0NOMEFAV. */
            _.Move("", V0NOMEFAV);

            /*" -651- MOVE SPACES TO V0DTMOVTO. */
            _.Move("", V0DTMOVTO);

            /*" -651- PERFORM R0310-00-FETCH-SINI-TRANSP1. */

            R0310_00_FETCH_SINI_TRANSP1_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R040-000-SELECT-V0FRANQ-VASPEX-SECTION */
        private void R040_000_SELECT_V0FRANQ_VASPEX_SECTION()
        {
            /*" -660- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", WABEND.WNR_EXEC_SQL);

            /*" -666- PERFORM R040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1 */

            R040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1();

            /*" -669- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -670- DISPLAY 'ERRO DE ACESSO V0FRANQ_VASPEX ' */
                _.Display($"ERRO DE ACESSO V0FRANQ_VASPEX ");

                /*" -672- DISPLAY 'SINISTRO = ' V0NUM-APOL-SINISTRO 'COD. FRANQUEADO = ' V0FRANQ-COD-FRANQUEADO */

                $"SINISTRO = {V0NUM_APOL_SINISTRO}COD. FRANQUEADO = {V0FRANQ_COD_FRANQUEADO}"
                .Display();

                /*" -672- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R040-000-SELECT-V0FRANQ-VASPEX-DB-SELECT-1 */
        public void R040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1()
        {
            /*" -666- EXEC SQL SELECT COD_CLIENTE INTO :V0FRANQ-COD-CLIENTE FROM SEGUROS.V0FRANQ_VASPEX WHERE COD_FRANQUEADO = :V0FRANQ-COD-FRANQUEADO AND SITUACAO = '0' END-EXEC. */

            var r040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1_Query1 = new R040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1_Query1()
            {
                V0FRANQ_COD_FRANQUEADO = V0FRANQ_COD_FRANQUEADO.ToString(),
            };

            var executed_1 = R040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1_Query1.Execute(r040_000_SELECT_V0FRANQ_VASPEX_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FRANQ_COD_CLIENTE, V0FRANQ_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-SELECT-V0CLIENTE-SECTION */
        private void R0450_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -680- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", WABEND.WNR_EXEC_SQL);

            /*" -685- PERFORM R0450_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R0450_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -688- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -689- DISPLAY 'ERRO DE ACESSO EM V0CLIENTE' */
                _.Display($"ERRO DE ACESSO EM V0CLIENTE");

                /*" -691- DISPLAY 'SINISTRO = ' V0NUM-APOL-SINISTRO ' COD. FRANQUEADO = ' V0COD-FRANQUE */

                $"SINISTRO = {V0NUM_APOL_SINISTRO} COD. FRANQUEADO = {V0COD_FRANQUE}"
                .Display();

                /*" -691- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0450-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R0450_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -685- EXEC SQL SELECT NOME_RAZAO INTO :V0NOME-RAZAO FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0CLIENTE-COD-CLIENTE END-EXEC. */

            var r0450_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 = new R0450_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1()
            {
                V0CLIENTE_COD_CLIENTE = V0CLIENTE_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0450_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1.Execute(r0450_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0NOME_RAZAO, V0NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-SELECT-V0HISTSINI-SECTION */
        private void R0500_00_SELECT_V0HISTSINI_SECTION()
        {
            /*" -700- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", WABEND.WNR_EXEC_SQL);

            /*" -712- PERFORM R0500_00_SELECT_V0HISTSINI_DB_DECLARE_1 */

            R0500_00_SELECT_V0HISTSINI_DB_DECLARE_1();

            /*" -713- PERFORM R0500_00_SELECT_V0HISTSINI_DB_OPEN_1 */

            R0500_00_SELECT_V0HISTSINI_DB_OPEN_1();

            /*" -0- FLUXCONTROL_PERFORM R0501_LER_FETCH_SIN_PAGOS */

            R0501_LER_FETCH_SIN_PAGOS();

        }

        [StopWatch]
        /*" R0500-00-SELECT-V0HISTSINI-DB-OPEN-1 */
        public void R0500_00_SELECT_V0HISTSINI_DB_OPEN_1()
        {
            /*" -713- EXEC SQL OPEN V0SIN-PAGOS END-EXEC. */

            V0SIN_PAGOS.Open();

        }

        [StopWatch]
        /*" R0501-LER-FETCH-SIN-PAGOS */
        private void R0501_LER_FETCH_SIN_PAGOS(bool isPerform = false)
        {
            /*" -720- PERFORM R0501_LER_FETCH_SIN_PAGOS_DB_FETCH_1 */

            R0501_LER_FETCH_SIN_PAGOS_DB_FETCH_1();

            /*" -723- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -724- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -725- MOVE 'S' TO WFIM-V0SIN-PAGOS */
                    _.Move("S", AREA_DE_WORK.ACUMUL_SPACE.WFIM_V0SIN_PAGOS);

                    /*" -725- PERFORM R0501_LER_FETCH_SIN_PAGOS_DB_CLOSE_1 */

                    R0501_LER_FETCH_SIN_PAGOS_DB_CLOSE_1();

                    /*" -727- ELSE */
                }
                else
                {


                    /*" -728- DISPLAY 'ERRO NO SELECT DA V0HISTSINI' */
                    _.Display($"ERRO NO SELECT DA V0HISTSINI");

                    /*" -729- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -730- END-IF */
                }


                /*" -731- ELSE */
            }
            else
            {


                /*" -732- ADD 1 TO WLIDOS-V0SIN-PAGOS */
                AREA_DE_WORK.ACUMUL_ZEROS.WLIDOS_V0SIN_PAGOS.Value = AREA_DE_WORK.ACUMUL_ZEROS.WLIDOS_V0SIN_PAGOS + 1;

                /*" -735- END-IF. */
            }


            /*" -743- PERFORM R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_1 */

            R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_1();

            /*" -753- PERFORM R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2 */

            R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2();

            /*" -756- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -757- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -758- DISPLAY 'ERRO NO SELECT DA V0HISTSINI' */
                    _.Display($"ERRO NO SELECT DA V0HISTSINI");

                    /*" -759- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -760- END-IF */
                }


                /*" -762- END-IF. */
            }


            /*" -766- COMPUTE V0VAL-OPERACAO-PEND = V0VAL-OPERACAO-PEND - V0VAL-OPERACAO-PEND1. */
            V0VAL_OPERACAO_PEND.Value = V0VAL_OPERACAO_PEND - V0VAL_OPERACAO_PEND1;

            /*" -767- IF WFIM-V0SIN-PAGOS EQUAL SPACES */

            if (AREA_DE_WORK.ACUMUL_SPACE.WFIM_V0SIN_PAGOS.IsEmpty())
            {

                /*" -768- MOVE V0DTMOVTO TO WDATA-AUXILIAR */
                _.Move(V0DTMOVTO, AREA_DE_WORK.WDATA_AUXILIAR);

                /*" -769- MOVE W-AA-AUX TO W-AA-INDEN */
                _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_AA_AUX, LD_01.WDATA_INDENIZAC.W_AA_INDEN);

                /*" -770- MOVE W-MM-AUX TO W-MM-INDEN */
                _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_MM_AUX, LD_01.WDATA_INDENIZAC.W_MM_INDEN);

                /*" -771- MOVE W-DD-AUX TO W-DD-INDEN */
                _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_DD_AUX, LD_01.WDATA_INDENIZAC.W_DD_INDEN);

                /*" -772- MOVE '/' TO WBARRA-DT-OCOR03 */
                _.Move("/", LD_01.WDATA_INDENIZAC.WBARRA_DT_OCOR03);

                /*" -773- MOVE '/' TO WBARRA-DT-OCOR04 */
                _.Move("/", LD_01.WDATA_INDENIZAC.WBARRA_DT_OCOR04);

                /*" -774- PERFORM R0600-00-IMPRIME-LINHA-DET */

                R0600_00_IMPRIME_LINHA_DET_SECTION();

                /*" -776- GO TO R0501-LER-FETCH-SIN-PAGOS. */
                new Task(() => R0501_LER_FETCH_SIN_PAGOS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -777- IF WLIDOS-V0SIN-PAGOS = 0 */

            if (AREA_DE_WORK.ACUMUL_ZEROS.WLIDOS_V0SIN_PAGOS == 0)
            {

                /*" -778- MOVE SPACES TO WDATA-INDENIZAC */
                _.Move("", LD_01.WDATA_INDENIZAC);

                /*" -778- PERFORM R0600-00-IMPRIME-LINHA-DET. */

                R0600_00_IMPRIME_LINHA_DET_SECTION();
            }


        }

        [StopWatch]
        /*" R0501-LER-FETCH-SIN-PAGOS-DB-FETCH-1 */
        public void R0501_LER_FETCH_SIN_PAGOS_DB_FETCH_1()
        {
            /*" -720- EXEC SQL FETCH V0SIN-PAGOS INTO :V0NOMEFAV , :V0DTMOVTO , :V0VAL-OPERACAO END-EXEC. */

            if (V0SIN_PAGOS.Fetch())
            {
                _.Move(V0SIN_PAGOS.V0NOMEFAV, V0NOMEFAV);
                _.Move(V0SIN_PAGOS.V0DTMOVTO, V0DTMOVTO);
                _.Move(V0SIN_PAGOS.V0VAL_OPERACAO, V0VAL_OPERACAO);
            }

        }

        [StopWatch]
        /*" R0501-LER-FETCH-SIN-PAGOS-DB-CLOSE-1 */
        public void R0501_LER_FETCH_SIN_PAGOS_DB_CLOSE_1()
        {
            /*" -725- EXEC SQL CLOSE V0SIN-PAGOS END-EXEC */

            V0SIN_PAGOS.Close();

        }

        [StopWatch]
        /*" R0501-LER-FETCH-SIN-PAGOS-DB-SELECT-1 */
        public void R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_1()
        {
            /*" -743- EXEC SQL SELECT VALUE(SUM(VAL_OPERACAO),0) INTO :V0VAL-OPERACAO-PEND FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V0NUM-APOL-SINISTRO AND OPERACAO IN (101,102,103,104,112, 113,114,122,123,1050) END-EXEC. */

            var r0501_LER_FETCH_SIN_PAGOS_DB_SELECT_1_Query1 = new R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_1_Query1()
            {
                V0NUM_APOL_SINISTRO = V0NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_1_Query1.Execute(r0501_LER_FETCH_SIN_PAGOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0VAL_OPERACAO_PEND, V0VAL_OPERACAO_PEND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0501-LER-FETCH-SIN-PAGOS-DB-SELECT-2 */
        public void R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2()
        {
            /*" -753- EXEC SQL SELECT VALUE(SUM(VAL_OPERACAO),0) INTO :V0VAL-OPERACAO-PEND1 FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V0NUM-APOL-SINISTRO AND OPERACAO IN (105,106,107,108,115,116,117, 118,1001,1002,1003,1004,1009) END-EXEC. */

            var r0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2_Query1 = new R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2_Query1()
            {
                V0NUM_APOL_SINISTRO = V0NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2_Query1.Execute(r0501_LER_FETCH_SIN_PAGOS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0VAL_OPERACAO_PEND1, V0VAL_OPERACAO_PEND1);
            }


        }

        [StopWatch]
        /*" R0600-00-IMPRIME-LINHA-DET-SECTION */
        private void R0600_00_IMPRIME_LINHA_DET_SECTION()
        {
            /*" -790- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", WABEND.WNR_EXEC_SQL);

            /*" -791- IF AC-LINHAS GREATER 60 */

            if (AREA_DE_WORK.AC_LINHAS > 60)
            {

                /*" -794- PERFORM R0700-00-IMPRIME-CABECALHO. */

                R0700_00_IMPRIME_CABECALHO_SECTION();
            }


            /*" -795- MOVE V0NUM-SINI-FRANQUE TO WNUM-SIN-VASPEX. */
            _.Move(V0NUM_SINI_FRANQUE, LD_01.WNUM_VASPEX.WNUM_SIN_VASPEX);

            /*" -796- MOVE '/' TO WBARRA-VASPEX. */
            _.Move("/", LD_01.WNUM_VASPEX.WBARRA_VASPEX);

            /*" -797- MOVE V0ANO-SINI-FRANQUE TO WANO-SINISTRO. */
            _.Move(V0ANO_SINI_FRANQUE, LD_01.WNUM_VASPEX.WANO_SINISTRO);

            /*" -798- MOVE V0NUM-APOL-SINISTRO TO WNUM-SIN-SASSE. */
            _.Move(V0NUM_APOL_SINISTRO, LD_01.WNUM_SASSE.WNUM_SIN_SASSE);

            /*" -799- MOVE V0NOMEFAV TO WNOME-FAVORECIDO. */
            _.Move(V0NOMEFAV, LD_01.WNOME_FAVORECIDO);

            /*" -800- MOVE V0QTD-ITENS-SINI TO WQTD-ENCOM-SINI. */
            _.Move(V0QTD_ITENS_SINI, LD_01.WQTD_ENCOM_SINI1.WQTD_ENCOM_SINI);

            /*" -801- MOVE V0QTD-ITENS-TRANSP TO WQTD-ENCOM-TRANSP. */
            _.Move(V0QTD_ITENS_TRANSP, LD_01.WQTD_ENCOM_TRANSP1.WQTD_ENCOM_TRANSP);

            /*" -802- MOVE V0VAL-OPERACAO TO WVAL-INDENIZADO. */
            _.Move(V0VAL_OPERACAO, LD_01.WVAL_INDENIZADO);

            /*" -803- MOVE V0VAL-OPERACAO-PEND TO WVAL-PENDENTE. */
            _.Move(V0VAL_OPERACAO_PEND, LD_01.WVAL_PENDENTE1.WVAL_PENDENTE);

            /*" -804- MOVE V0DATA-OCORR TO WDATA-AUXILIAR. */
            _.Move(V0DATA_OCORR, AREA_DE_WORK.WDATA_AUXILIAR);

            /*" -805- MOVE W-AA-AUX TO W-AA-OCORR. */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_AA_AUX, LD_01.WDATA_OCORR.W_AA_OCORR);

            /*" -806- MOVE W-MM-AUX TO W-MM-OCORR. */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_MM_AUX, LD_01.WDATA_OCORR.W_MM_OCORR);

            /*" -807- MOVE W-DD-AUX TO W-DD-OCORR. */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_DD_AUX, LD_01.WDATA_OCORR.W_DD_OCORR);

            /*" -808- MOVE '/' TO WBARRA-DT-OCOR01. */
            _.Move("/", LD_01.WDATA_OCORR.WBARRA_DT_OCOR01);

            /*" -810- MOVE '/' TO WBARRA-DT-OCOR02. */
            _.Move("/", LD_01.WDATA_OCORR.WBARRA_DT_OCOR02);

            /*" -811- IF V0NUM-APOL-SINISTRO = WNUM-APOL-SINI-ANT */

            if (V0NUM_APOL_SINISTRO == AREA_DE_WORK.ACUMUL_ZEROS.WNUM_APOL_SINI_ANT)
            {

                /*" -812- MOVE SPACES TO WNUM-VASPEX */
                _.Move("", LD_01.WNUM_VASPEX);

                /*" -813- MOVE SPACES TO WNUM-SASSE */
                _.Move("", LD_01.WNUM_SASSE);

                /*" -814- MOVE SPACES TO WDATA-OCORR */
                _.Move("", LD_01.WDATA_OCORR);

                /*" -815- MOVE ZEROS TO V0QTD-ITENS-SINI */
                _.Move(0, V0QTD_ITENS_SINI);

                /*" -816- MOVE SPACES TO WQTD-ENCOM-SINI1 */
                _.Move("", LD_01.WQTD_ENCOM_SINI1);

                /*" -817- MOVE ZEROS TO V0QTD-ITENS-TRANSP */
                _.Move(0, V0QTD_ITENS_TRANSP);

                /*" -818- MOVE SPACES TO WQTD-ENCOM-TRANSP1 */
                _.Move("", LD_01.WQTD_ENCOM_TRANSP1);

                /*" -819- MOVE ZEROS TO V0VAL-OPERACAO-PEND */
                _.Move(0, V0VAL_OPERACAO_PEND);

                /*" -820- MOVE SPACES TO WVAL-PENDENTE1 */
                _.Move("", LD_01.WVAL_PENDENTE1);

                /*" -822- END-IF. */
            }


            /*" -824- WRITE REG-MOVTO FROM LD-01 AFTER 1. */
            _.Move(LD_01.GetMoveValues(), REG_MOVTO);

            RSI0846B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -825- ADD 01 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 01;

            /*" -827- MOVE V0NUM-APOL-SINISTRO TO WNUM-APOL-SINI-ANT. */
            _.Move(V0NUM_APOL_SINISTRO, AREA_DE_WORK.ACUMUL_ZEROS.WNUM_APOL_SINI_ANT);

            /*" -829- COMPUTE WTOT-ENCOM-SINI-X = V0QTD-ITENS-SINI + WTOT-ENCOM-SINI-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_SINI_X.Value = V0QTD_ITENS_SINI + AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_SINI_X;

            /*" -831- COMPUTE WTOT-ENCOM-TRANSP-X = V0QTD-ITENS-TRANSP + WTOT-ENCOM-TRANSP-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_TRANSP_X.Value = V0QTD_ITENS_TRANSP + AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_TRANSP_X;

            /*" -833- COMPUTE WTOT-INDENIZADO-X = V0VAL-OPERACAO + WTOT-INDENIZADO-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WTOT_INDENIZADO_X.Value = V0VAL_OPERACAO + AREA_DE_WORK.ACUMUL_ZEROS.WTOT_INDENIZADO_X;

            /*" -834- COMPUTE WTOT-PENDENTE-X = V0VAL-OPERACAO-PEND + WTOT-PENDENTE-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WTOT_PENDENTE_X.Value = V0VAL_OPERACAO_PEND + AREA_DE_WORK.ACUMUL_ZEROS.WTOT_PENDENTE_X;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-IMPRIME-CABECALHO-SECTION */
        private void R0700_00_IMPRIME_CABECALHO_SECTION()
        {
            /*" -845- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", WABEND.WNR_EXEC_SQL);

            /*" -846- ADD 1 TO AC-PAGINA */
            AREA_DE_WORK.ACUMUL_ZEROS.AC_PAGINA.Value = AREA_DE_WORK.ACUMUL_ZEROS.AC_PAGINA + 1;

            /*" -847- MOVE ZEROS TO AC-LINHAS */
            _.Move(0, AREA_DE_WORK.AC_LINHAS);

            /*" -849- MOVE AC-PAGINA TO LC-01-PAGINA */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.AC_PAGINA, AREA_DE_WORK.LC_01.LC_01_PAGINA);

            /*" -850- WRITE REG-MOVTO FROM LC-01 AFTER PAGE */
            _.Move(AREA_DE_WORK.LC_01.GetMoveValues(), REG_MOVTO);

            RSI0846B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -851- WRITE REG-MOVTO FROM LC-02 AFTER 1. */
            _.Move(AREA_DE_WORK.LC_02.GetMoveValues(), REG_MOVTO);

            RSI0846B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -852- WRITE REG-MOVTO FROM LC-03 AFTER 1. */
            _.Move(AREA_DE_WORK.LC_03.GetMoveValues(), REG_MOVTO);

            RSI0846B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -853- WRITE REG-MOVTO FROM LC-04 AFTER 2. */
            _.Move(AREA_DE_WORK.LC_04.GetMoveValues(), REG_MOVTO);

            RSI0846B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -854- WRITE REG-MOVTO FROM LC-06 AFTER 1. */
            _.Move(AREA_DE_WORK.LC_06.GetMoveValues(), REG_MOVTO);

            RSI0846B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -855- WRITE REG-MOVTO FROM LC-07 AFTER 1. */
            _.Move(AREA_DE_WORK.LC_07.GetMoveValues(), REG_MOVTO);

            RSI0846B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -856- WRITE REG-MOVTO FROM LC-08 AFTER 1. */
            _.Move(AREA_DE_WORK.LC_08.GetMoveValues(), REG_MOVTO);

            RSI0846B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -858- WRITE REG-MOVTO FROM LC-06 AFTER 1. */
            _.Move(AREA_DE_WORK.LC_06.GetMoveValues(), REG_MOVTO);

            RSI0846B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -858- MOVE 12 TO AC-LINHAS. */
            _.Move(12, AREA_DE_WORK.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-IMPRIME-LINHA-TOT-SECTION */
        private void R0800_00_IMPRIME_LINHA_TOT_SECTION()
        {
            /*" -871- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", WABEND.WNR_EXEC_SQL);

            /*" -872- MOVE WTOT-SINISTRO-X TO WTOT-SINISTRO. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X, LD_02.WTOT_SINISTRO);

            /*" -873- MOVE WTOT-ENCOM-SINI-X TO WTOT-ENCOM-SINI. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_SINI_X, LD_02.WTOT_ENCOM_SINI);

            /*" -874- MOVE WTOT-ENCOM-TRANSP-X TO WTOT-ENCOM-TRANSP. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_TRANSP_X, LD_02.WTOT_ENCOM_TRANSP);

            /*" -875- MOVE WTOT-INDENIZADO-X TO WTOT-INDENIZADO. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_INDENIZADO_X, LD_02.WTOT_INDENIZADO);

            /*" -877- MOVE WTOT-PENDENTE-X TO WTOT-PENDENTE. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_PENDENTE_X, LD_02.WTOT_PENDENTE);

            /*" -878- WRITE REG-MOVTO FROM LC-09 AFTER 1. */
            _.Move(AREA_DE_WORK.LC_09.GetMoveValues(), REG_MOVTO);

            RSI0846B.Write(REG_MOVTO.GetMoveValues().ToString());

            /*" -878- WRITE REG-MOVTO FROM LD-02 AFTER 1. */
            _.Move(LD_02.GetMoveValues(), REG_MOVTO);

            RSI0846B.Write(REG_MOVTO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -890- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -891- DISPLAY 'CODIGO DO FRANQUEADO.....: ' V0COD-FRANQUE */
            _.Display($"CODIGO DO FRANQUEADO.....: {V0COD_FRANQUE}");

            /*" -892- DISPLAY 'NUMERO DA APOLICE........: ' V0NUM-APOLICE */
            _.Display($"NUMERO DA APOLICE........: {V0NUM_APOLICE}");

            /*" -893- DISPLAY 'NUMERO DO SINISTRO.......: ' V0NUM-APOL-SINISTRO */
            _.Display($"NUMERO DO SINISTRO.......: {V0NUM_APOL_SINISTRO}");

            /*" -895- DISPLAY 'QUANTIDADE DE LIDOS......: ' WLIDOS-V0TRANSP1 */
            _.Display($"QUANTIDADE DE LIDOS......: {AREA_DE_WORK.ACUMUL_ZEROS.WLIDOS_V0TRANSP1}");

            /*" -897- CLOSE RSI0846B. */
            RSI0846B.Close();

            /*" -899- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -899- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -901- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -903- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -903- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}