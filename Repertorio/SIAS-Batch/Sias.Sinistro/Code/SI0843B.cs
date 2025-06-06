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
using Sias.Sinistro.DB2.SI0843B;

namespace Code
{
    public class SI0843B
    {
        public bool IsCall { get; set; }

        public SI0843B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SISTEMA DE SINISTROS               *      */
        /*"      *   PROGRAMA ...............  SI0843B.                           *      */
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

        public FileBasis _SI0843 { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis SI0843
        {
            get
            {
                _.Move(REG_ARQ_SI0843, _SI0843); VarBasis.RedefinePassValue(REG_ARQ_SI0843, _SI0843, REG_ARQ_SI0843); return _SI0843;
            }
        }
        public FileBasis _RSI0843B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RSI0843B
        {
            get
            {
                _.Move(REG_MOVTO, _RSI0843B); VarBasis.RedefinePassValue(REG_MOVTO, _RSI0843B, REG_MOVTO); return _RSI0843B;
            }
        }
        /*"01              REG-ARQ-SI0843      PIC  X(132).*/
        public StringBasis REG_ARQ_SI0843 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
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
        /*"77  V0DATA-OCORR           PIC   X(010).*/
        public StringBasis V0DATA_OCORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0SITUACAO             PIC   X(001).*/
        public StringBasis V0SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0VAL-OPERACAO         PIC  S9(011)V9(2)   VALUE +0 COMP-3.*/
        public DoubleBasis V0VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(011)V9(2)"), 2);
        /*"77  V0VAL-OPERACAO-PEND    PIC  S9(011)V9(2)   VALUE +0 COMP-3.*/
        public DoubleBasis V0VAL_OPERACAO_PEND { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(011)V9(2)"), 2);
        /*"77  V0VAL-OPERACAO-PEND1   PIC  S9(011)V9(2)   VALUE +0 COMP-3.*/
        public DoubleBasis V0VAL_OPERACAO_PEND1 { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(011)V9(2)"), 2);
        /*"77  V0NOME-RAZAO           PIC   X(040).*/
        public StringBasis V0NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  V0CODUSU               PIC   X(008).*/
        public StringBasis V0CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  V0PERI-INICIAL         PIC   X(010).*/
        public StringBasis V0PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0PERI-FINAL           PIC   X(010).*/
        public StringBasis V0PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0NUM-APOLICE          PIC  S9(013)        VALUE +0 COMP-3.*/
        public IntBasis V0NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01        TAB-INT-SINI-VASPEX                     VALUE ZEROS.*/
        public SI0843B_TAB_INT_SINI_VASPEX TAB_INT_SINI_VASPEX { get; set; } = new SI0843B_TAB_INT_SINI_VASPEX();
        public class SI0843B_TAB_INT_SINI_VASPEX : VarBasis
        {
            /*"  05      TAB-INT-SINI        OCCURS 1000 TIMES.*/
            public ListBasis<SI0843B_TAB_INT_SINI> TAB_INT_SINI { get; set; } = new ListBasis<SI0843B_TAB_INT_SINI>(1000);
            public class SI0843B_TAB_INT_SINI : VarBasis
            {
                /*"    07    WNOME-CLIENTE-T         PIC X(040).*/
                public StringBasis WNOME_CLIENTE_T { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    07    WTOT-SINISTRO-T         PIC 9(005).*/
                public IntBasis WTOT_SINISTRO_T { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    07    WTOT-ENCOM-SINI-T       PIC 9(005).*/
                public IntBasis WTOT_ENCOM_SINI_T { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    07    WTOT-ENCOM-TRANSP-T     PIC 9(005).*/
                public IntBasis WTOT_ENCOM_TRANSP_T { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    07    WTOT-INDENIZADO-T       PIC 9(010)V9(002).*/
                public DoubleBasis WTOT_INDENIZADO_T { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V9(002)."), 2);
                /*"    07    WTOT-PENDENTE-T         PIC 9(010)V9(002).*/
                public DoubleBasis WTOT_PENDENTE_T { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V9(002)."), 2);
                /*"    07    WTOT-MEDIO-INDENIZ-T    PIC 9(005)V9(002).*/
                public DoubleBasis WTOT_MEDIO_INDENIZ_T { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V9(002)."), 2);
                /*"01        AREA-DE-WORK.*/
            }
        }
        public SI0843B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0843B_AREA_DE_WORK();
        public class SI0843B_AREA_DE_WORK : VarBasis
        {
            /*"  05      AC-LINHAS               PIC 9(002)      VALUE 80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05      WLIDOS-RELATORIOS       PIC 9(003)      VALUE ZEROS.*/
            public IntBasis WLIDOS_RELATORIOS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      WFIM-RELATORIOS         PIC X(001)      VALUE SPACES.*/
            public StringBasis WFIM_RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WIND                    PIC 9(004)      VALUE 1.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"), 1);
            /*"  05      WCONT-TAB               PIC 9(004)      VALUE 1.*/
            public IntBasis WCONT_TAB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"), 1);
            /*"  05      ACUMUL-ZEROS.*/
            public SI0843B_ACUMUL_ZEROS ACUMUL_ZEROS { get; set; } = new SI0843B_ACUMUL_ZEROS();
            public class SI0843B_ACUMUL_ZEROS : VarBasis
            {
                /*"    07    AC-PAGINA               PIC 9(003)      VALUE ZEROS.*/
                public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    07    WLIDOS-V0TRANSP1        PIC 9(003)      VALUE ZEROS.*/
                public IntBasis WLIDOS_V0TRANSP1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    07    WCOD-FRANQUE-ANT        PIC 9(009)      VALUE ZEROS.*/
                public IntBasis WCOD_FRANQUE_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"    07    WNUM-SINISTRO-X         PIC 9(007)      VALUE ZEROS.*/
                public IntBasis WNUM_SINISTRO_X { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
                /*"    07    WVAL-MEDIO-INDENIZ-X    PIC 9(011)V9(2) VALUE ZEROS.*/
                public DoubleBasis WVAL_MEDIO_INDENIZ_X { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V9(2)"), 2);
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
                /*"    07    WTOT-MEDIO-INDENIZ-X    PIC 9(005)V9(2) VALUE ZEROS.*/
                public DoubleBasis WTOT_MEDIO_INDENIZ_X { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V9(2)"), 2);
                /*"    07    WRTOT-SINISTRO-X        PIC 9(005)      VALUE ZEROS.*/
                public IntBasis WRTOT_SINISTRO_X { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"    07    WRTOT-ENCOM-SINI-X      PIC 9(005)      VALUE ZEROS.*/
                public IntBasis WRTOT_ENCOM_SINI_X { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"    07    WRTOT-ENCOM-TRANSP-X    PIC 9(005)      VALUE ZEROS.*/
                public IntBasis WRTOT_ENCOM_TRANSP_X { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"    07    WRTOT-INDENIZADO-X      PIC 9(010)V9(2) VALUE ZEROS.*/
                public DoubleBasis WRTOT_INDENIZADO_X { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V9(2)"), 2);
                /*"    07    WRTOT-PENDENTE-X        PIC 9(010)V9(2) VALUE ZEROS.*/
                public DoubleBasis WRTOT_PENDENTE_X { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V9(2)"), 2);
                /*"    07    WRTOT-MEDIO-INDENIZ-X   PIC 9(005)V9(2) VALUE ZEROS.*/
                public DoubleBasis WRTOT_MEDIO_INDENIZ_X { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V9(2)"), 2);
                /*"  05      ACUMUL-SPACE.*/
            }
            public SI0843B_ACUMUL_SPACE ACUMUL_SPACE { get; set; } = new SI0843B_ACUMUL_SPACE();
            public class SI0843B_ACUMUL_SPACE : VarBasis
            {
                /*"    07    WSEM-DATA-SIS           PIC X(001)      VALUE SPACES.*/
                public StringBasis WSEM_DATA_SIS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    07    WFIM-V0TRANSP1          PIC X(001)      VALUE SPACES.*/
                public StringBasis WFIM_V0TRANSP1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    07    WIND-VAL-DEC-ANT        PIC X(001)      VALUE SPACES.*/
                public StringBasis WIND_VAL_DEC_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    07    WNOME-CLIENTE-ANT       PIC X(040)      VALUE SPACES.*/
                public StringBasis WNOME_CLIENTE_ANT { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  05         AHRC-DATA-REL.*/
            }
            public SI0843B_AHRC_DATA_REL AHRC_DATA_REL { get; set; } = new SI0843B_AHRC_DATA_REL();
            public class SI0843B_AHRC_DATA_REL : VarBasis
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
            public SI0843B_AHRC_HORA_REL AHRC_HORA_REL { get; set; } = new SI0843B_AHRC_HORA_REL();
            public class SI0843B_AHRC_HORA_REL : VarBasis
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
            public SI0843B_AH_DATE AH_DATE { get; set; } = new SI0843B_AH_DATE();
            public class SI0843B_AH_DATE : VarBasis
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
            public SI0843B_AH_TIME AH_TIME { get; set; } = new SI0843B_AH_TIME();
            public class SI0843B_AH_TIME : VarBasis
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
            public SI0843B_WDATA_REL01 WDATA_REL01 { get; set; } = new SI0843B_WDATA_REL01();
            public class SI0843B_WDATA_REL01 : VarBasis
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
            public SI0843B_WDATA_REL02 WDATA_REL02 { get; set; } = new SI0843B_WDATA_REL02();
            public class SI0843B_WDATA_REL02 : VarBasis
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
            public SI0843B_WDATA_AUXILIAR WDATA_AUXILIAR { get; set; } = new SI0843B_WDATA_AUXILIAR();
            public class SI0843B_WDATA_AUXILIAR : VarBasis
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
            public SI0843B_WDATAPERIODO WDATAPERIODO { get; set; } = new SI0843B_WDATAPERIODO();
            public class SI0843B_WDATAPERIODO : VarBasis
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
            public SI0843B_LC_01 LC_01 { get; set; } = new SI0843B_LC_01();
            public class SI0843B_LC_01 : VarBasis
            {
                /*"     10     FILLER                PIC  X(045)   VALUE 'SI0843B'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"SI0843B");
                /*"     10     FILLER                PIC  X(071)   VALUE            'SASSE CIA. NACIONAL DE SEGUROS GERAIS'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "71", "X(071)"), @"SASSE CIA. NACIONAL DE SEGUROS GERAIS");
                /*"     10     FILLER                PIC  X(013)   VALUE 'PAGINA:'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"PAGINA:");
                /*"     10     LC-01-PAGINA          PIC  999.*/
                public IntBasis LC_01_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"  05        LC-02.*/
            }
            public SI0843B_LC_02 LC_02 { get; set; } = new SI0843B_LC_02();
            public class SI0843B_LC_02 : VarBasis
            {
                /*"     10     FILLER                PIC  X(043)   VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
                /*"     10     FILLER                PIC  X(073)   VALUE            'ANALISE DE FREQUENCIA DE SINISTROS VASPEX'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "73", "X(073)"), @"ANALISE DE FREQUENCIA DE SINISTROS VASPEX");
                /*"     10     FILLER                PIC  X(006)   VALUE 'DATA:'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"DATA:");
                /*"     10     LC-02-DATA            PIC  X(010)   VALUE SPACES.*/
                public StringBasis LC_02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05        LC-03.*/
            }
            public SI0843B_LC_03 LC_03 { get; set; } = new SI0843B_LC_03();
            public class SI0843B_LC_03 : VarBasis
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
            public SI0843B_LC_04 LC_04 { get; set; } = new SI0843B_LC_04();
            public class SI0843B_LC_04 : VarBasis
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
                /*"  05        LC-05.*/
            }
            public SI0843B_LC_05 LC_05 { get; set; } = new SI0843B_LC_05();
            public class SI0843B_LC_05 : VarBasis
            {
                /*"     10     FILLER                PIC  X(025)   VALUE SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"     10     FILLER                PIC  X(012)   VALUE            'FRANQUEADO: '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"FRANQUEADO: ");
                /*"     10     WNOME-CLIENTE         PIC  X(040)   VALUE SPACES.*/
                public StringBasis WNOME_CLIENTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  05        LC-06.*/
            }
            public SI0843B_LC_06 LC_06 { get; set; } = new SI0843B_LC_06();
            public class SI0843B_LC_06 : VarBasis
            {
                /*"     10     FILLER                PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"     10     FILLER                PIC  X(118)   VALUE ALL '-'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "118", "X(118)"), @"ALL");
                /*"     10     FILLER                PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"  05        LC-07.*/
            }
            public SI0843B_LC_07 LC_07 { get; set; } = new SI0843B_LC_07();
            public class SI0843B_LC_07 : VarBasis
            {
                /*"     10     FILLER                PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"     10     FILLER                PIC  X(019)   VALUE            'NUM DO SINISTRO    '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"NUM DO SINISTRO    ");
                /*"     10     FILLER                PIC  X(014)   VALUE            ' DATA DE      '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" DATA DE      ");
                /*"     10     FILLER                PIC  X(017)   VALUE            '  QTD ENCOM      '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"  QTD ENCOM      ");
                /*"     10     FILLER                PIC  X(017)   VALUE            '  QTD ENCOM      '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"  QTD ENCOM      ");
                /*"     10     FILLER                PIC  X(018)   VALUE            '    VALOR         '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"    VALOR         ");
                /*"     10     FILLER                PIC  X(018)   VALUE            '    VALOR         '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"    VALOR         ");
                /*"     10     FILLER                PIC  X(015)   VALUE            '  VALOR MEDIO  '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"  VALOR MEDIO  ");
                /*"     10     FILLER                PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"  05        LC-08.*/
            }
            public SI0843B_LC_08 LC_08 { get; set; } = new SI0843B_LC_08();
            public class SI0843B_LC_08 : VarBasis
            {
                /*"     10     FILLER                PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"     10     FILLER                PIC  X(019)   VALUE            '    VASPEX         '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"    VASPEX         ");
                /*"     10     FILLER                PIC  X(014)   VALUE            'OCORRENCIA    '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"OCORRENCIA    ");
                /*"     10     FILLER                PIC  X(017)   VALUE            'TRANSPORTADA     '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"TRANSPORTADA     ");
                /*"     10     FILLER                PIC  X(017)   VALUE            'SINISTRADA(Z)    '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"SINISTRADA(Z)    ");
                /*"     10     FILLER                PIC  X(018)   VALUE            'INDENIZADO(Y)     '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"INDENIZADO(Y)     ");
                /*"     10     FILLER                PIC  X(018)   VALUE            '   PENDENTE       '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"   PENDENTE       ");
                /*"     10     FILLER                PIC  X(015)   VALUE            'INDENIZADO(Y/Z)'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"INDENIZADO(Y/Z)");
                /*"     10     FILLER                PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"  05        LC-09.*/
            }
            public SI0843B_LC_09 LC_09 { get; set; } = new SI0843B_LC_09();
            public class SI0843B_LC_09 : VarBasis
            {
                /*"     10     FILLER                PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"     10     FILLER                PIC  X(019)   VALUE            '---------------    '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"---------------    ");
                /*"     10     FILLER                PIC  X(014)   VALUE            '              '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"              ");
                /*"     10     FILLER                PIC  X(017)   VALUE            '-------------    '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"-------------    ");
                /*"     10     FILLER                PIC  X(017)   VALUE            '-------------    '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"-------------    ");
                /*"     10     FILLER                PIC  X(018)   VALUE            '--------------    '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"--------------    ");
                /*"     10     FILLER                PIC  X(018)   VALUE            '--------------    '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"--------------    ");
                /*"     10     FILLER                PIC  X(015)   VALUE            '---------------'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"---------------");
                /*"     10     FILLER                PIC  X(007)   VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"  05        LR-01.*/
            }
            public SI0843B_LR_01 LR_01 { get; set; } = new SI0843B_LR_01();
            public class SI0843B_LR_01 : VarBasis
            {
                /*"     10     FILLER                PIC  X(034)   VALUE SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"     10     FILLER                PIC  X(064)   VALUE            '** QUADRO RESUMO DA ANALISE DE FREQUENCIA DE SINISTR            'OS VASPEX **'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "64", "X(064)"), @"** QUADRO RESUMO DA ANALISE DE FREQUENCIA DE SINISTR            ");
                /*"     10     FILLER                PIC  X(034)   VALUE SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"  05        LR-02.*/
            }
            public SI0843B_LR_02 LR_02 { get; set; } = new SI0843B_LR_02();
            public class SI0843B_LR_02 : VarBasis
            {
                /*"     10     FILLER                PIC  X(132)   VALUE ALL '='.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05        LR-03.*/
            }
            public SI0843B_LR_03 LR_03 { get; set; } = new SI0843B_LR_03();
            public class SI0843B_LR_03 : VarBasis
            {
                /*"     10     FILLER                PIC  X(040)   VALUE            'FRANQUEADO         '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"FRANQUEADO         ");
                /*"     10     FILLER                PIC  X(013)   VALUE            '    QTD      '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"    QTD      ");
                /*"     10     FILLER                PIC  X(015)   VALUE            '  QTD ENCOM    '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"  QTD ENCOM    ");
                /*"     10     FILLER                PIC  X(015)   VALUE            '  QTD ENCOM    '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"  QTD ENCOM    ");
                /*"     10     FILLER                PIC  X(017)   VALUE            '    VALOR        '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"    VALOR        ");
                /*"     10     FILLER                PIC  X(017)   VALUE            '    VALOR        '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"    VALOR        ");
                /*"     10     FILLER                PIC  X(015)   VALUE            '  VALOR MEDIO  '.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"  VALOR MEDIO  ");
                /*"  05        LR-04.*/
            }
            public SI0843B_LR_04 LR_04 { get; set; } = new SI0843B_LR_04();
            public class SI0843B_LR_04 : VarBasis
            {
                /*"     10     FILLER                PIC  X(040)   VALUE SPACES.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"     10     FILLER                PIC  X(013)   VALUE            '  SINISTRO   '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"  SINISTRO   ");
                /*"     10     FILLER                PIC  X(015)   VALUE            'TRANSPORTADA   '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"TRANSPORTADA   ");
                /*"     10     FILLER                PIC  X(015)   VALUE            'SINISTRADA(Z)  '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"SINISTRADA(Z)  ");
                /*"     10     FILLER                PIC  X(017)   VALUE            'INDENIZADO(Y)    '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"INDENIZADO(Y)    ");
                /*"     10     FILLER                PIC  X(017)   VALUE            '   PENDENTE      '.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"   PENDENTE      ");
                /*"     10     FILLER                PIC  X(015)   VALUE            'INDENIZADO(Y/Z)'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"INDENIZADO(Y/Z)");
                /*"  05        LR-05.*/
            }
            public SI0843B_LR_05 LR_05 { get; set; } = new SI0843B_LR_05();
            public class SI0843B_LR_05 : VarBasis
            {
                /*"     10     FILLER                PIC  X(040)   VALUE SPACES.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"     10     FILLER                PIC  X(013)   VALUE            '----------   '.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"----------   ");
                /*"     10     FILLER                PIC  X(015)   VALUE            '-------------  '.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"-------------  ");
                /*"     10     FILLER                PIC  X(015)   VALUE            '-------------  '.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"-------------  ");
                /*"     10     FILLER                PIC  X(017)   VALUE            '-------------    '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"-------------    ");
                /*"     10     FILLER                PIC  X(017)   VALUE            '-------------    '.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"-------------    ");
                /*"     10     FILLER                PIC  X(015)   VALUE            '---------------'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"---------------");
                /*"01        LD-01.*/
            }
        }
        public SI0843B_LD_01 LD_01 { get; set; } = new SI0843B_LD_01();
        public class SI0843B_LD_01 : VarBasis
        {
            /*"  05      FILLER                   PIC X(007)   VALUE SPACES.*/
            public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"  05      FILLER                   PIC X(003)   VALUE SPACES.*/
            public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05      WNUM-VASPEX.*/
            public SI0843B_WNUM_VASPEX WNUM_VASPEX { get; set; } = new SI0843B_WNUM_VASPEX();
            public class SI0843B_WNUM_VASPEX : VarBasis
            {
                /*"    07    WNUM-SINISTRO            PIC ZZZZZZ9.*/
                public IntBasis WNUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    07    FILLER                   PIC X(001)   VALUE '/'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    07    WANO-SINISTRO            PIC 9(004)   VALUE ZEROS.*/
                public IntBasis WANO_SINISTRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05      FILLER                   PIC X(004)   VALUE SPACES.*/
            }
            public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05      WDATA-OCORR.*/
            public SI0843B_WDATA_OCORR WDATA_OCORR { get; set; } = new SI0843B_WDATA_OCORR();
            public class SI0843B_WDATA_OCORR : VarBasis
            {
                /*"    07    W-DD-OCORR               PIC 9(002)   VALUE ZEROS.*/
                public IntBasis W_DD_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    07    FILLER                   PIC X(001)   VALUE '/'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    07    W-MM-OCORR               PIC 9(002)   VALUE ZEROS.*/
                public IntBasis W_MM_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    07    FILLER                   PIC X(001)   VALUE '/'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    07    W-AA-OCORR               PIC 9(004)   VALUE ZEROS.*/
                public IntBasis W_AA_OCORR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05      FILLER                   PIC X(012)   VALUE SPACES.*/
            }
            public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05      WQTD-ENCOM-TRANSP        PIC ZZZZ9.*/
            public IntBasis WQTD_ENCOM_TRANSP { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
            /*"  05      FILLER                   PIC X(012)   VALUE SPACES.*/
            public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05      WQTD-ENCOM-SINI          PIC ZZZZ9.*/
            public IntBasis WQTD_ENCOM_SINI { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
            /*"  05      FILLER                   PIC X(004)   VALUE SPACES.*/
            public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05      WVAL-INDENIZADO          PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WVAL_INDENIZADO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05      FILLER                   PIC X(004)   VALUE SPACES.*/
            public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05      WVAL-PENDENTE            PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WVAL_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05      FILLER                   PIC X(005)   VALUE SPACES.*/
            public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05      WVAL-MEDIO-INDENIZ       PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WVAL_MEDIO_INDENIZ { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05      FILLER                   PIC X(007)   VALUE SPACES.*/
            public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"01        LD-02.*/
        }
        public SI0843B_LD_02 LD_02 { get; set; } = new SI0843B_LD_02();
        public class SI0843B_LD_02 : VarBasis
        {
            /*"  05      FILLER                   PIC X(007)   VALUE SPACES.*/
            public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"  05      FILLER                   PIC X(010)   VALUE 'TOT.SIN:'*/
            public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"TOT.SIN:");
            /*"  05      WTOT-SINISTRO            PIC ZZZZ9.*/
            public IntBasis WTOT_SINISTRO { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
            /*"  05      FILLER                   PIC X(026)   VALUE SPACES.*/
            public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
            /*"  05      WTOT-ENCOM-TRANSP        PIC ZZZZ9.*/
            public IntBasis WTOT_ENCOM_TRANSP { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
            /*"  05      FILLER                   PIC X(012)   VALUE SPACES.*/
            public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05      WTOT-ENCOM-SINI          PIC ZZZZ9.*/
            public IntBasis WTOT_ENCOM_SINI { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
            /*"  05      FILLER                   PIC X(004)   VALUE SPACES.*/
            public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05      WTOT-INDENIZADO          PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WTOT_INDENIZADO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05      FILLER                   PIC X(004)   VALUE SPACES.*/
            public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05      WTOT-PENDENTE            PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WTOT_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05      FILLER                   PIC X(005)   VALUE SPACES.*/
            public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05      WTOT-MEDIO-INDENIZ       PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WTOT_MEDIO_INDENIZ { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05      FILLER                   PIC X(007)   VALUE SPACES.*/
            public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"01        LRD-01.*/
        }
        public SI0843B_LRD_01 LRD_01 { get; set; } = new SI0843B_LRD_01();
        public class SI0843B_LRD_01 : VarBasis
        {
            /*"  05      WRNOME-CLIENTE           PIC X(040)   VALUE SPACES.*/
            public StringBasis WRNOME_CLIENTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05      FILLER                   PIC X(005)   VALUE SPACES.*/
            public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05      WRQTD-SINISTRO           PIC ZZZZ9.*/
            public IntBasis WRQTD_SINISTRO { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
            /*"  05      FILLER                   PIC X(011)   VALUE SPACES.*/
            public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
            /*"  05      WRQTD-ENCOM-TRANSP       PIC ZZZZ9.*/
            public IntBasis WRQTD_ENCOM_TRANSP { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
            /*"  05      FILLER                   PIC X(010)   VALUE SPACES.*/
            public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WRQTD-ENCOM-SINI         PIC ZZZZ9.*/
            public IntBasis WRQTD_ENCOM_SINI { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
            /*"  05      FILLER                   PIC X(001)   VALUE SPACES.*/
            public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WRVAL-INDENIZADO         PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WRVAL_INDENIZADO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05      FILLER                   PIC X(003)   VALUE SPACES.*/
            public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05      WRVAL-PENDENTE           PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WRVAL_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05      FILLER                   PIC X(005)   VALUE SPACES.*/
            public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05      WRVAL-MEDIO-INDENIZ      PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WRVAL_MEDIO_INDENIZ { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"01        LRD-02.*/
        }
        public SI0843B_LRD_02 LRD_02 { get; set; } = new SI0843B_LRD_02();
        public class SI0843B_LRD_02 : VarBasis
        {
            /*"  05      FILLER                   PIC X(040)   VALUE          'TOTAL GERAL: '.*/
            public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"TOTAL GERAL: ");
            /*"  05      FILLER                   PIC X(005)   VALUE SPACES.*/
            public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05      WRTOT-SINISTRO           PIC ZZZZ9.*/
            public IntBasis WRTOT_SINISTRO { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
            /*"  05      FILLER                   PIC X(011)   VALUE SPACES.*/
            public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
            /*"  05      WRTOT-ENCOM-TRANSP       PIC ZZZZ9.*/
            public IntBasis WRTOT_ENCOM_TRANSP { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
            /*"  05      FILLER                   PIC X(010)   VALUE SPACES.*/
            public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WRTOT-ENCOM-SINI         PIC ZZZZ9.*/
            public IntBasis WRTOT_ENCOM_SINI { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
            /*"  05      FILLER                   PIC X(001)   VALUE SPACES.*/
            public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WRTOT-INDENIZADO         PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WRTOT_INDENIZADO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05      FILLER                   PIC X(003)   VALUE SPACES.*/
            public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05      WRTOT-PENDENTE           PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WRTOT_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05      FILLER                   PIC X(005)   VALUE SPACES.*/
            public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05      WRTOT-MEDIO-INDENIZ      PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis WRTOT_MEDIO_INDENIZ { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"01        WABEND.*/
        }
        public SI0843B_WABEND WABEND { get; set; } = new SI0843B_WABEND();
        public class SI0843B_WABEND : VarBasis
        {
            /*"  05      FILLER                 PIC  X(010) VALUE         ' SI0843B'.*/
            public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0843B");
            /*"  05      FILLER                 PIC  X(026) VALUE         ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05      WNR-EXEC-SQL           PIC  X(005) VALUE '00000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"00000");
            /*"  05      FILLER                 PIC  X(013) VALUE         ' *** SQLCODE '.*/
            public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05      WSQLCODE               PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }


        public SI0843B_V0RELATORIOS V0RELATORIOS { get; set; } = new SI0843B_V0RELATORIOS();
        public SI0843B_V0TRANSP1 V0TRANSP1 { get; set; } = new SI0843B_V0TRANSP1();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0843_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0843.SetFile(SI0843_FILE_NAME_P);

                /*" -500- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", WABEND.WNR_EXEC_SQL);

                /*" -501- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -504- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -507- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -507- FLUXCONTROL_PERFORM R0000-00-ROTINA-INICIAL-SECTION */

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
            /*" -514- PERFORM R0100-00-OBTER-DATA-SISTEMA. */

            R0100_00_OBTER_DATA_SISTEMA_SECTION();

            /*" -515- IF WSEM-DATA-SIS EQUAL SPACES */

            if (AREA_DE_WORK.ACUMUL_SPACE.WSEM_DATA_SIS.IsEmpty())
            {

                /*" -517- MOVE V0DTMOVABE TO AH-DATE */
                _.Move(V0DTMOVABE, AREA_DE_WORK.AH_DATE);

                /*" -518- MOVE AH-DD-DATE TO AH-DD-REL */
                _.Move(AREA_DE_WORK.AH_DATE.AH_DD_DATE, AREA_DE_WORK.AHRC_DATA_REL.AH_DD_REL);

                /*" -519- MOVE AH-MM-DATE TO AH-MM-REL */
                _.Move(AREA_DE_WORK.AH_DATE.AH_MM_DATE, AREA_DE_WORK.AHRC_DATA_REL.AH_MM_REL);

                /*" -521- MOVE AH-AA-DATE TO AH-AA-REL */
                _.Move(AREA_DE_WORK.AH_DATE.AH_AA_DATE, AREA_DE_WORK.AHRC_DATA_REL.AH_AA_REL);

                /*" -523- MOVE AHRC-DATA-REL TO LC-02-DATA */
                _.Move(AREA_DE_WORK.AHRC_DATA_REL, AREA_DE_WORK.LC_02.LC_02_DATA);

                /*" -525- ACCEPT AH-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.AH_TIME);

                /*" -526- MOVE AH-HH-TIME TO AH-HH-REL */
                _.Move(AREA_DE_WORK.AH_TIME.AH_HH_TIME, AREA_DE_WORK.AHRC_HORA_REL.AH_HH_REL);

                /*" -527- MOVE AH-MM-TIME TO AH-MN-REL */
                _.Move(AREA_DE_WORK.AH_TIME.AH_MM_TIME, AREA_DE_WORK.AHRC_HORA_REL.AH_MN_REL);

                /*" -529- MOVE AH-SS-TIME TO AH-SS-REL */
                _.Move(AREA_DE_WORK.AH_TIME.AH_SS_TIME, AREA_DE_WORK.AHRC_HORA_REL.AH_SS_REL);

                /*" -531- MOVE AHRC-HORA-REL TO LC-03-HORA */
                _.Move(AREA_DE_WORK.AHRC_HORA_REL, AREA_DE_WORK.LC_03.LC_03_HORA);

                /*" -533- PERFORM R0110-00-ABRIR-ARQUIVOS */

                R0110_00_ABRIR_ARQUIVOS_SECTION();

                /*" -534- PERFORM R0200-00-DECLARE-V0RELATORIOS */

                R0200_00_DECLARE_V0RELATORIOS_SECTION();

                /*" -535- PERFORM R0210-00-FETCH-V0RELATORIOS */

                R0210_00_FETCH_V0RELATORIOS_SECTION();

                /*" -538- PERFORM R0220-00-ROTINA-PRINCIPAL UNTIL WFIM-RELATORIOS NOT EQUAL SPACE */

                while (!(AREA_DE_WORK.WFIM_RELATORIOS != " "))
                {

                    R0220_00_ROTINA_PRINCIPAL_SECTION();
                }

                /*" -540- PERFORM R0120-00-FECHAR-ARQUIVOS. */

                R0120_00_FECHAR_ARQUIVOS_SECTION();
            }


            /*" -541- DISPLAY 'SOLICITADO POR..........:  ' V0CODUSU */
            _.Display($"SOLICITADO POR..........:  {V0CODUSU}");

            /*" -542- DISPLAY 'TOTAL SINISTROS.........: ' WLIDOS-V0TRANSP1 */
            _.Display($"TOTAL SINISTROS.........: {AREA_DE_WORK.ACUMUL_ZEROS.WLIDOS_V0TRANSP1}");

            /*" -543- DISPLAY 'TOTAL ENCOMEND. PAG/PEND: ' WTOT-ENCOM-SINI-X */
            _.Display($"TOTAL ENCOMEND. PAG/PEND: {AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_SINI_X}");

            /*" -544- DISPLAY 'TOTAL ENCOMEND. TRANSP..: ' WTOT-ENCOM-TRANSP-X */
            _.Display($"TOTAL ENCOMEND. TRANSP..: {AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_TRANSP_X}");

            /*" -546- DISPLAY '***  SI0843B - FIM NORMAL  ***' */
            _.Display($"***  SI0843B - FIM NORMAL  ***");

            /*" -548- PERFORM R0130-00-DELETE-V0RELATORIOS. */

            R0130_00_DELETE_V0RELATORIOS_SECTION();

            /*" -548- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -552- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -552- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-OBTER-DATA-SISTEMA-SECTION */
        private void R0100_00_OBTER_DATA_SISTEMA_SECTION()
        {
            /*" -565- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -570- PERFORM R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1 */

            R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1();

            /*" -573- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -574- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -575- MOVE 'S' TO WSEM-DATA-SIS */
                    _.Move("S", AREA_DE_WORK.ACUMUL_SPACE.WSEM_DATA_SIS);

                    /*" -576- DISPLAY 'PROGRAMA : SI0843B' */
                    _.Display($"PROGRAMA : SI0843B");

                    /*" -577- DISPLAY 'FALTA DATA DO SISTEMA SI' */
                    _.Display($"FALTA DATA DO SISTEMA SI");

                    /*" -578- DISPLAY 'PROGRAMA CANCELADO' */
                    _.Display($"PROGRAMA CANCELADO");

                    /*" -579- ELSE */
                }
                else
                {


                    /*" -580- DISPLAY 'ERRO DE ACESSO EM V0SISTEMA' */
                    _.Display($"ERRO DE ACESSO EM V0SISTEMA");

                    /*" -580- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0100-00-OBTER-DATA-SISTEMA-DB-SELECT-1 */
        public void R0100_00_OBTER_DATA_SISTEMA_DB_SELECT_1()
        {
            /*" -570- EXEC SQL SELECT DTMOVABE INTO :V0DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

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
            /*" -589- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -590- OPEN OUTPUT RSI0843B SI0843. */
            RSI0843B.Open(REG_MOVTO);
            SI0843.Open(REG_ARQ_SI0843);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-FECHAR-ARQUIVOS-SECTION */
        private void R0120_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -598- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -599- CLOSE RSI0843B SI0843. */
            RSI0843B.Close();
            SI0843.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V0RELATORIOS-SECTION */
        private void R0200_00_DECLARE_V0RELATORIOS_SECTION()
        {
            /*" -609- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -618- PERFORM R0200_00_DECLARE_V0RELATORIOS_DB_DECLARE_1 */

            R0200_00_DECLARE_V0RELATORIOS_DB_DECLARE_1();

            /*" -620- PERFORM R0200_00_DECLARE_V0RELATORIOS_DB_OPEN_1 */

            R0200_00_DECLARE_V0RELATORIOS_DB_OPEN_1();

            /*" -623- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -624- DISPLAY 'ERRO NO DECLARE DO V0RELATORIOS' */
                _.Display($"ERRO NO DECLARE DO V0RELATORIOS");

                /*" -624- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0RELATORIOS-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V0RELATORIOS_DB_DECLARE_1()
        {
            /*" -618- EXEC SQL DECLARE V0RELATORIOS CURSOR FOR SELECT CODUSU , PERI_INICIAL , PERI_FINAL , NUM_APOLICE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0843B' AND DATA_SOLICITACAO = :V0DTMOVABE END-EXEC. */
            V0RELATORIOS = new SI0843B_V0RELATORIOS(true);
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
							AND CODRELAT = 'SI0843B' 
							AND DATA_SOLICITACAO = '{V0DTMOVABE}'";

                return query;
            }
            V0RELATORIOS.GetQueryEvent += GetQuery_V0RELATORIOS;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0RELATORIOS-DB-OPEN-1 */
        public void R0200_00_DECLARE_V0RELATORIOS_DB_OPEN_1()
        {
            /*" -620- EXEC SQL OPEN V0RELATORIOS END-EXEC. */

            V0RELATORIOS.Open();

        }

        [StopWatch]
        /*" R0300-00-DECLARE-SINI-TRANSP1-DB-DECLARE-1 */
        public void R0300_00_DECLARE_SINI_TRANSP1_DB_DECLARE_1()
        {
            /*" -766- EXEC SQL DECLARE V0TRANSP1 CURSOR FOR SELECT T.NUM_APOL_SINISTRO , T.COD_FRANQUE , T.IND_VAL_DECLADADO , T.QTD_ITENS_SINI , T.QTD_ITENS_TRANSP , T.NUM_SINI_FRANQUE , T.ANO_SINI_FRANQUE , M.DATORR , M.SITUACAO FROM SEGUROS.V0MESTSINI M, SEGUROS.V0SINISTRO_TRANSP1 T WHERE M.NUM_APOLICE = :V0NUM-APOLICE AND M.SITUACAO <> '2' AND M.NUM_APOL_SINISTRO = T.NUM_APOL_SINISTRO AND M.DATORR BETWEEN :V0PERI-INICIAL AND :V0PERI-FINAL ORDER BY T.IND_VAL_DECLADADO, T.COD_FRANQUE, T.NUM_APOL_SINISTRO END-EXEC. */
            V0TRANSP1 = new SI0843B_V0TRANSP1(true);
            string GetQuery_V0TRANSP1()
            {
                var query = @$"SELECT T.NUM_APOL_SINISTRO
							, 
							T.COD_FRANQUE
							, 
							T.IND_VAL_DECLADADO
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
							M.SITUACAO 
							FROM SEGUROS.V0MESTSINI M
							, 
							SEGUROS.V0SINISTRO_TRANSP1 T 
							WHERE M.NUM_APOLICE = '{V0NUM_APOLICE}' 
							AND M.SITUACAO <> '2' 
							AND M.NUM_APOL_SINISTRO = T.NUM_APOL_SINISTRO 
							AND M.DATORR BETWEEN '{V0PERI_INICIAL}' 
							AND '{V0PERI_FINAL}' 
							ORDER BY T.IND_VAL_DECLADADO
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
            /*" -637- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WABEND.WNR_EXEC_SQL);

            /*" -642- PERFORM R0210_00_FETCH_V0RELATORIOS_DB_FETCH_1 */

            R0210_00_FETCH_V0RELATORIOS_DB_FETCH_1();

            /*" -645- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -646- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -647- MOVE 'S' TO WFIM-RELATORIOS */
                    _.Move("S", AREA_DE_WORK.WFIM_RELATORIOS);

                    /*" -648- IF WLIDOS-RELATORIOS EQUAL ZEROS */

                    if (AREA_DE_WORK.WLIDOS_RELATORIOS == 00)
                    {

                        /*" -649- DISPLAY 'NAO HA SOLICITACAO PARA O RELATORIO.' */
                        _.Display($"NAO HA SOLICITACAO PARA O RELATORIO.");

                        /*" -650- DISPLAY 'PROGRAMA TERMINADO' */
                        _.Display($"PROGRAMA TERMINADO");

                        /*" -651- END-IF */
                    }


                    /*" -651- PERFORM R0210_00_FETCH_V0RELATORIOS_DB_CLOSE_1 */

                    R0210_00_FETCH_V0RELATORIOS_DB_CLOSE_1();

                    /*" -653- ELSE */
                }
                else
                {


                    /*" -654- DISPLAY 'ERRO NO FETCH DO V0RELATORIOS' */
                    _.Display($"ERRO NO FETCH DO V0RELATORIOS");

                    /*" -656- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -656- ADD 1 TO WLIDOS-RELATORIOS. */
            AREA_DE_WORK.WLIDOS_RELATORIOS.Value = AREA_DE_WORK.WLIDOS_RELATORIOS + 1;

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0RELATORIOS-DB-FETCH-1 */
        public void R0210_00_FETCH_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -642- EXEC SQL FETCH V0RELATORIOS INTO :V0CODUSU , :V0PERI-INICIAL , :V0PERI-FINAL , :V0NUM-APOLICE END-EXEC. */

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
            /*" -651- EXEC SQL CLOSE V0RELATORIOS END-EXEC */

            V0RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-ROTINA-PRINCIPAL-SECTION */
        private void R0220_00_ROTINA_PRINCIPAL_SECTION()
        {
            /*" -669- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WABEND.WNR_EXEC_SQL);

            /*" -670- MOVE ZEROS TO ACUMUL-ZEROS. */
            _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS);

            /*" -671- MOVE ZEROS TO TAB-INT-SINI-VASPEX. */
            _.Move(0, TAB_INT_SINI_VASPEX);

            /*" -672- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -673- MOVE 1 TO WCONT-TAB. */
            _.Move(1, AREA_DE_WORK.WCONT_TAB);

            /*" -674- MOVE SPACES TO ACUMUL-SPACE. */
            _.Move("", AREA_DE_WORK.ACUMUL_SPACE);

            /*" -676- MOVE 80 TO AC-LINHAS. */
            _.Move(80, AREA_DE_WORK.AC_LINHAS);

            /*" -677- MOVE V0PERI-INICIAL TO WDATA-AUXILIAR */
            _.Move(V0PERI_INICIAL, AREA_DE_WORK.WDATA_AUXILIAR);

            /*" -678- MOVE W-AA-AUX TO W-AA-PERIO */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_AA_AUX, AREA_DE_WORK.WDATAPERIODO.W_AA_PERIO);

            /*" -679- MOVE W-MM-AUX TO W-MM-PERIO */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_MM_AUX, AREA_DE_WORK.WDATAPERIODO.W_MM_PERIO);

            /*" -680- MOVE W-DD-AUX TO W-DD-PERIO */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_DD_AUX, AREA_DE_WORK.WDATAPERIODO.W_DD_PERIO);

            /*" -682- MOVE WDATAPERIODO TO WPERI-INICIAL */
            _.Move(AREA_DE_WORK.WDATAPERIODO, AREA_DE_WORK.LC_04.WPERI_INICIAL);

            /*" -683- MOVE V0PERI-FINAL TO WDATA-AUXILIAR */
            _.Move(V0PERI_FINAL, AREA_DE_WORK.WDATA_AUXILIAR);

            /*" -684- MOVE W-AA-AUX TO W-AA-PERIO */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_AA_AUX, AREA_DE_WORK.WDATAPERIODO.W_AA_PERIO);

            /*" -685- MOVE W-MM-AUX TO W-MM-PERIO */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_MM_AUX, AREA_DE_WORK.WDATAPERIODO.W_MM_PERIO);

            /*" -686- MOVE W-DD-AUX TO W-DD-PERIO */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_DD_AUX, AREA_DE_WORK.WDATAPERIODO.W_DD_PERIO);

            /*" -688- MOVE WDATAPERIODO TO WPERI-FINAL */
            _.Move(AREA_DE_WORK.WDATAPERIODO, AREA_DE_WORK.LC_04.WPERI_FINAL);

            /*" -690- MOVE V0NUM-APOLICE TO WNUM-APOLICE */
            _.Move(V0NUM_APOLICE, AREA_DE_WORK.LC_03.WNUM_APOLICE);

            /*" -691- PERFORM R0300-00-DECLARE-SINI-TRANSP1 */

            R0300_00_DECLARE_SINI_TRANSP1_SECTION();

            /*" -692- PERFORM R0310-00-FETCH-SINI-TRANSP1 */

            R0310_00_FETCH_SINI_TRANSP1_SECTION();

            /*" -695- PERFORM R0320-00-TRATA-IND-DECLARADO UNTIL WFIM-V0TRANSP1 NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.ACUMUL_SPACE.WFIM_V0TRANSP1.IsEmpty()))
            {

                R0320_00_TRATA_IND_DECLARADO_SECTION();
            }

            /*" -697- PERFORM R0800-00-IMPRIME-LINHA-TOT. */

            R0800_00_IMPRIME_LINHA_TOT_SECTION();

            /*" -698- MOVE 1 TO WIND */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -700- PERFORM R0710-00-IMPRIME-CAB-RESUMO. */

            R0710_00_IMPRIME_CAB_RESUMO_SECTION();

            /*" -702- PERFORM R0910-00-IMPRIME-QDRESUMO UNTIL WIND = WCONT-TAB. */

            while (!(AREA_DE_WORK.WIND == AREA_DE_WORK.WCONT_TAB))
            {

                R0910_00_IMPRIME_QDRESUMO_SECTION();
            }

            /*" -703- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -704- PERFORM R0914-00-IMPRIME-CABECALHO-ARQ. */

            R0914_00_IMPRIME_CABECALHO_ARQ_SECTION();

            /*" -706- PERFORM R0915-00-IMPRIME-QDRESUMO-ARQ UNTIL WIND = WCONT-TAB. */

            while (!(AREA_DE_WORK.WIND == AREA_DE_WORK.WCONT_TAB))
            {

                R0915_00_IMPRIME_QDRESUMO_ARQ_SECTION();
            }

            /*" -711- PERFORM R0920-00-IMPRIME-TOTRESUMO. */

            R0920_00_IMPRIME_TOTRESUMO_SECTION();

            /*" -711- PERFORM R0210-00-FETCH-V0RELATORIOS. */

            R0210_00_FETCH_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-DELETE-V0RELATORIOS-SECTION */
        private void R0130_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -723- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -728- PERFORM R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -731- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -732- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -733- DISPLAY 'ERRO DE DELECAO NA V0RELATORIOS' */
                    _.Display($"ERRO DE DELECAO NA V0RELATORIOS");

                    /*" -733- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0130-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void R0130_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -728- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0843B' AND DATA_SOLICITACAO = :V0DTMOVABE END-EXEC. */

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
            /*" -746- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WABEND.WNR_EXEC_SQL);

            /*" -766- PERFORM R0300_00_DECLARE_SINI_TRANSP1_DB_DECLARE_1 */

            R0300_00_DECLARE_SINI_TRANSP1_DB_DECLARE_1();

            /*" -768- PERFORM R0300_00_DECLARE_SINI_TRANSP1_DB_OPEN_1 */

            R0300_00_DECLARE_SINI_TRANSP1_DB_OPEN_1();

            /*" -771- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -772- DISPLAY 'ERRO NO DECLARE DA V0MESTSINI/V0SINISTRO-TRANSP' */
                _.Display($"ERRO NO DECLARE DA V0MESTSINI/V0SINISTRO-TRANSP");

                /*" -772- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-SINI-TRANSP1-DB-OPEN-1 */
        public void R0300_00_DECLARE_SINI_TRANSP1_DB_OPEN_1()
        {
            /*" -768- EXEC SQL OPEN V0TRANSP1 END-EXEC. */

            V0TRANSP1.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-SINI-TRANSP1-SECTION */
        private void R0310_00_FETCH_SINI_TRANSP1_SECTION()
        {
            /*" -785- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WABEND.WNR_EXEC_SQL);

            /*" -795- PERFORM R0310_00_FETCH_SINI_TRANSP1_DB_FETCH_1 */

            R0310_00_FETCH_SINI_TRANSP1_DB_FETCH_1();

            /*" -798- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -799- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -800- MOVE 'S' TO WFIM-V0TRANSP1 */
                    _.Move("S", AREA_DE_WORK.ACUMUL_SPACE.WFIM_V0TRANSP1);

                    /*" -800- PERFORM R0310_00_FETCH_SINI_TRANSP1_DB_CLOSE_1 */

                    R0310_00_FETCH_SINI_TRANSP1_DB_CLOSE_1();

                    /*" -802- ELSE */
                }
                else
                {


                    /*" -803- DISPLAY 'ERRO NO FETCH DA V0MESTSINI/V0SINISTRO-TRANS' */
                    _.Display($"ERRO NO FETCH DA V0MESTSINI/V0SINISTRO-TRANS");

                    /*" -804- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -805- END-IF */
                }


                /*" -806- ELSE */
            }
            else
            {


                /*" -807- ADD 1 TO WLIDOS-V0TRANSP1 */
                AREA_DE_WORK.ACUMUL_ZEROS.WLIDOS_V0TRANSP1.Value = AREA_DE_WORK.ACUMUL_ZEROS.WLIDOS_V0TRANSP1 + 1;

                /*" -809- PERFORM R0400-00-SELECT-V0CLIENTE */

                R0400_00_SELECT_V0CLIENTE_SECTION();

                /*" -811- END-IF. */
            }


            /*" -812- IF WLIDOS-V0TRANSP1 EQUAL 1 */

            if (AREA_DE_WORK.ACUMUL_ZEROS.WLIDOS_V0TRANSP1 == 1)
            {

                /*" -813- MOVE V0NOME-RAZAO TO WNOME-CLIENTE-ANT */
                _.Move(V0NOME_RAZAO, AREA_DE_WORK.ACUMUL_SPACE.WNOME_CLIENTE_ANT);

                /*" -813- MOVE V0IND-VAL-DECLARADO TO WIND-VAL-DEC-ANT. */
                _.Move(V0IND_VAL_DECLARADO, AREA_DE_WORK.ACUMUL_SPACE.WIND_VAL_DEC_ANT);
            }


        }

        [StopWatch]
        /*" R0310-00-FETCH-SINI-TRANSP1-DB-FETCH-1 */
        public void R0310_00_FETCH_SINI_TRANSP1_DB_FETCH_1()
        {
            /*" -795- EXEC SQL FETCH V0TRANSP1 INTO :V0NUM-APOL-SINISTRO , :V0COD-FRANQUE , :V0IND-VAL-DECLARADO , :V0QTD-ITENS-SINI , :V0QTD-ITENS-TRANSP , :V0NUM-SINI-FRANQUE , :V0ANO-SINI-FRANQUE , :V0DATA-OCORR , :V0SITUACAO END-EXEC. */

            if (V0TRANSP1.Fetch())
            {
                _.Move(V0TRANSP1.V0NUM_APOL_SINISTRO, V0NUM_APOL_SINISTRO);
                _.Move(V0TRANSP1.V0COD_FRANQUE, V0COD_FRANQUE);
                _.Move(V0TRANSP1.V0IND_VAL_DECLARADO, V0IND_VAL_DECLARADO);
                _.Move(V0TRANSP1.V0QTD_ITENS_SINI, V0QTD_ITENS_SINI);
                _.Move(V0TRANSP1.V0QTD_ITENS_TRANSP, V0QTD_ITENS_TRANSP);
                _.Move(V0TRANSP1.V0NUM_SINI_FRANQUE, V0NUM_SINI_FRANQUE);
                _.Move(V0TRANSP1.V0ANO_SINI_FRANQUE, V0ANO_SINI_FRANQUE);
                _.Move(V0TRANSP1.V0DATA_OCORR, V0DATA_OCORR);
                _.Move(V0TRANSP1.V0SITUACAO, V0SITUACAO);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-SINI-TRANSP1-DB-CLOSE-1 */
        public void R0310_00_FETCH_SINI_TRANSP1_DB_CLOSE_1()
        {
            /*" -800- EXEC SQL CLOSE V0TRANSP1 END-EXEC */

            V0TRANSP1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-TRATA-IND-DECLARADO-SECTION */
        private void R0320_00_TRATA_IND_DECLARADO_SECTION()
        {
            /*" -825- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", WABEND.WNR_EXEC_SQL);

            /*" -826- IF V0IND-VAL-DECLARADO = 'N' */

            if (V0IND_VAL_DECLARADO == "N")
            {

                /*" -827- MOVE 'SEM VALOR DECLARADO' TO WIND-VAL-DECLARADO */
                _.Move("SEM VALOR DECLARADO", AREA_DE_WORK.LC_04.WIND_VAL_DECLARADO);

                /*" -828- PERFORM R0330-00-TRATA-COD-FRANQUE */

                R0330_00_TRATA_COD_FRANQUE_SECTION();

                /*" -829- ELSE */
            }
            else
            {


                /*" -830- IF WIND-VAL-DEC-ANT = 'N' */

                if (AREA_DE_WORK.ACUMUL_SPACE.WIND_VAL_DEC_ANT == "N")
                {

                    /*" -831- PERFORM R0800-00-IMPRIME-LINHA-TOT */

                    R0800_00_IMPRIME_LINHA_TOT_SECTION();

                    /*" -832- MOVE ZEROS TO WVAL-MEDIO-INDENIZ-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WVAL_MEDIO_INDENIZ_X);

                    /*" -833- MOVE ZEROS TO WTOT-SINISTRO-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X);

                    /*" -834- MOVE ZEROS TO WTOT-ENCOM-SINI-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_SINI_X);

                    /*" -835- MOVE ZEROS TO WTOT-ENCOM-TRANSP-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_TRANSP_X);

                    /*" -836- MOVE ZEROS TO WTOT-INDENIZADO-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WTOT_INDENIZADO_X);

                    /*" -837- MOVE ZEROS TO WTOT-PENDENTE-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WTOT_PENDENTE_X);

                    /*" -838- MOVE ZEROS TO WTOT-MEDIO-INDENIZ-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WTOT_MEDIO_INDENIZ_X);

                    /*" -839- MOVE ZEROS TO WCOD-FRANQUE-ANT */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WCOD_FRANQUE_ANT);

                    /*" -840- MOVE 1 TO WIND */
                    _.Move(1, AREA_DE_WORK.WIND);

                    /*" -841- PERFORM R0710-00-IMPRIME-CAB-RESUMO */

                    R0710_00_IMPRIME_CAB_RESUMO_SECTION();

                    /*" -843- PERFORM R0910-00-IMPRIME-QDRESUMO UNTIL WIND = WCONT-TAB */

                    while (!(AREA_DE_WORK.WIND == AREA_DE_WORK.WCONT_TAB))
                    {

                        R0910_00_IMPRIME_QDRESUMO_SECTION();
                    }

                    /*" -844- MOVE 1 TO WIND */
                    _.Move(1, AREA_DE_WORK.WIND);

                    /*" -845- PERFORM R0914-00-IMPRIME-CABECALHO-ARQ */

                    R0914_00_IMPRIME_CABECALHO_ARQ_SECTION();

                    /*" -847- PERFORM R0915-00-IMPRIME-QDRESUMO-ARQ UNTIL WIND = WCONT-TAB */

                    while (!(AREA_DE_WORK.WIND == AREA_DE_WORK.WCONT_TAB))
                    {

                        R0915_00_IMPRIME_QDRESUMO_ARQ_SECTION();
                    }

                    /*" -848- PERFORM R0920-00-IMPRIME-TOTRESUMO */

                    R0920_00_IMPRIME_TOTRESUMO_SECTION();

                    /*" -849- MOVE 1 TO WIND */
                    _.Move(1, AREA_DE_WORK.WIND);

                    /*" -850- MOVE 1 TO WCONT-TAB */
                    _.Move(1, AREA_DE_WORK.WCONT_TAB);

                    /*" -851- MOVE ZEROS TO TAB-INT-SINI-VASPEX */
                    _.Move(0, TAB_INT_SINI_VASPEX);

                    /*" -852- MOVE 80 TO AC-LINHAS */
                    _.Move(80, AREA_DE_WORK.AC_LINHAS);

                    /*" -853- END-IF */
                }


                /*" -854- MOVE 'S' TO WIND-VAL-DEC-ANT */
                _.Move("S", AREA_DE_WORK.ACUMUL_SPACE.WIND_VAL_DEC_ANT);

                /*" -855- MOVE 'COM VALOR DECLARADO' TO WIND-VAL-DECLARADO */
                _.Move("COM VALOR DECLARADO", AREA_DE_WORK.LC_04.WIND_VAL_DECLARADO);

                /*" -861- PERFORM R0330-00-TRATA-COD-FRANQUE. */

                R0330_00_TRATA_COD_FRANQUE_SECTION();
            }


            /*" -861- PERFORM R0310-00-FETCH-SINI-TRANSP1. */

            R0310_00_FETCH_SINI_TRANSP1_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-TRATA-COD-FRANQUE-SECTION */
        private void R0330_00_TRATA_COD_FRANQUE_SECTION()
        {
            /*" -874- MOVE '330' TO WNR-EXEC-SQL. */
            _.Move("330", WABEND.WNR_EXEC_SQL);

            /*" -875- IF V0COD-FRANQUE EQUAL WCOD-FRANQUE-ANT */

            if (V0COD_FRANQUE == AREA_DE_WORK.ACUMUL_ZEROS.WCOD_FRANQUE_ANT)
            {

                /*" -877- PERFORM R0500-00-SELECT-V0HISTSINI */

                R0500_00_SELECT_V0HISTSINI_SECTION();

                /*" -878- ADD 1 TO WTOT-SINISTRO-X */
                AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X.Value = AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X + 1;

                /*" -879- PERFORM R0600-00-IMPRIME-LINHA-DET */

                R0600_00_IMPRIME_LINHA_DET_SECTION();

                /*" -880- ELSE */
            }
            else
            {


                /*" -881- MOVE V0COD-FRANQUE TO WCOD-FRANQUE-ANT */
                _.Move(V0COD_FRANQUE, AREA_DE_WORK.ACUMUL_ZEROS.WCOD_FRANQUE_ANT);

                /*" -883- MOVE V0NOME-RAZAO TO WNOME-CLIENTE */
                _.Move(V0NOME_RAZAO, AREA_DE_WORK.LC_05.WNOME_CLIENTE);

                /*" -885- IF WTOT-SINISTRO-X > 0 */

                if (AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X > 0)
                {

                    /*" -886- PERFORM R0800-00-IMPRIME-LINHA-TOT */

                    R0800_00_IMPRIME_LINHA_TOT_SECTION();

                    /*" -887- MOVE ZEROS TO WVAL-MEDIO-INDENIZ-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WVAL_MEDIO_INDENIZ_X);

                    /*" -888- MOVE ZEROS TO WTOT-SINISTRO-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X);

                    /*" -889- MOVE ZEROS TO WTOT-ENCOM-SINI-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_SINI_X);

                    /*" -890- MOVE ZEROS TO WTOT-ENCOM-TRANSP-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_TRANSP_X);

                    /*" -891- MOVE ZEROS TO WTOT-INDENIZADO-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WTOT_INDENIZADO_X);

                    /*" -892- MOVE ZEROS TO WTOT-PENDENTE-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WTOT_PENDENTE_X);

                    /*" -893- MOVE ZEROS TO WTOT-MEDIO-INDENIZ-X */
                    _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WTOT_MEDIO_INDENIZ_X);

                    /*" -894- MOVE 80 TO AC-LINHAS */
                    _.Move(80, AREA_DE_WORK.AC_LINHAS);

                    /*" -895- MOVE V0NOME-RAZAO TO WNOME-CLIENTE-ANT */
                    _.Move(V0NOME_RAZAO, AREA_DE_WORK.ACUMUL_SPACE.WNOME_CLIENTE_ANT);

                    /*" -897- PERFORM R0500-00-SELECT-V0HISTSINI */

                    R0500_00_SELECT_V0HISTSINI_SECTION();

                    /*" -898- ADD 1 TO WTOT-SINISTRO-X */
                    AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X.Value = AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X + 1;

                    /*" -899- PERFORM R0600-00-IMPRIME-LINHA-DET */

                    R0600_00_IMPRIME_LINHA_DET_SECTION();

                    /*" -900- ELSE */
                }
                else
                {


                    /*" -902- PERFORM R0500-00-SELECT-V0HISTSINI */

                    R0500_00_SELECT_V0HISTSINI_SECTION();

                    /*" -903- ADD 1 TO WTOT-SINISTRO-X */
                    AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X.Value = AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X + 1;

                    /*" -903- PERFORM R0600-00-IMPRIME-LINHA-DET. */

                    R0600_00_IMPRIME_LINHA_DET_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-SELECT-V0CLIENTE-SECTION */
        private void R0400_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -916- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", WABEND.WNR_EXEC_SQL);

            /*" -921- PERFORM R0400_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R0400_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -924- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -925- DISPLAY 'ERRO DE ACESSO EM V0CLIENTE' */
                _.Display($"ERRO DE ACESSO EM V0CLIENTE");

                /*" -925- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0400-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R0400_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -921- EXEC SQL SELECT NOME_RAZAO INTO :V0NOME-RAZAO FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0COD-FRANQUE END-EXEC. */

            var r0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 = new R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1()
            {
                V0COD_FRANQUE = V0COD_FRANQUE.ToString(),
            };

            var executed_1 = R0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1.Execute(r0400_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0NOME_RAZAO, V0NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-SELECT-V0HISTSINI-SECTION */
        private void R0500_00_SELECT_V0HISTSINI_SECTION()
        {
            /*" -938- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", WABEND.WNR_EXEC_SQL);

            /*" -945- PERFORM R0500_00_SELECT_V0HISTSINI_DB_SELECT_1 */

            R0500_00_SELECT_V0HISTSINI_DB_SELECT_1();

            /*" -948- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -949- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -950- DISPLAY 'ERRO NO SELECT DA V0HISTSINI' */
                    _.Display($"ERRO NO SELECT DA V0HISTSINI");

                    /*" -951- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -952- END-IF */
                }


                /*" -955- END-IF. */
            }


            /*" -963- PERFORM R0500_00_SELECT_V0HISTSINI_DB_SELECT_2 */

            R0500_00_SELECT_V0HISTSINI_DB_SELECT_2();

            /*" -973- PERFORM R0500_00_SELECT_V0HISTSINI_DB_SELECT_3 */

            R0500_00_SELECT_V0HISTSINI_DB_SELECT_3();

            /*" -976- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -977- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -978- DISPLAY 'ERRO NO SELECT DA V0HISTSINI' */
                    _.Display($"ERRO NO SELECT DA V0HISTSINI");

                    /*" -979- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -980- END-IF */
                }


                /*" -982- END-IF. */
            }


            /*" -983- COMPUTE V0VAL-OPERACAO-PEND = V0VAL-OPERACAO-PEND - V0VAL-OPERACAO-PEND1. */
            V0VAL_OPERACAO_PEND.Value = V0VAL_OPERACAO_PEND - V0VAL_OPERACAO_PEND1;

        }

        [StopWatch]
        /*" R0500-00-SELECT-V0HISTSINI-DB-SELECT-1 */
        public void R0500_00_SELECT_V0HISTSINI_DB_SELECT_1()
        {
            /*" -945- EXEC SQL SELECT VALUE(SUM(VAL_OPERACAO),0) INTO :V0VAL-OPERACAO FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V0NUM-APOL-SINISTRO AND SITUACAO <> '2' AND OPERACAO IN (1001,1002,1003,1004,1009) END-EXEC. */

            var r0500_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 = new R0500_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1()
            {
                V0NUM_APOL_SINISTRO = V0NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R0500_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1.Execute(r0500_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0VAL_OPERACAO, V0VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-SELECT-V0HISTSINI-DB-SELECT-2 */
        public void R0500_00_SELECT_V0HISTSINI_DB_SELECT_2()
        {
            /*" -963- EXEC SQL SELECT VALUE(SUM(VAL_OPERACAO),0) INTO :V0VAL-OPERACAO-PEND FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V0NUM-APOL-SINISTRO AND SITUACAO <> '2' AND OPERACAO IN (101,102,103,104,112, 113,114,122,123,1050) END-EXEC. */

            var r0500_00_SELECT_V0HISTSINI_DB_SELECT_2_Query1 = new R0500_00_SELECT_V0HISTSINI_DB_SELECT_2_Query1()
            {
                V0NUM_APOL_SINISTRO = V0NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R0500_00_SELECT_V0HISTSINI_DB_SELECT_2_Query1.Execute(r0500_00_SELECT_V0HISTSINI_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0VAL_OPERACAO_PEND, V0VAL_OPERACAO_PEND);
            }


        }

        [StopWatch]
        /*" R0600-00-IMPRIME-LINHA-DET-SECTION */
        private void R0600_00_IMPRIME_LINHA_DET_SECTION()
        {
            /*" -995- MOVE '600' TO WNR-EXEC-SQL. */
            _.Move("600", WABEND.WNR_EXEC_SQL);

            /*" -996- IF AC-LINHAS GREATER 53 */

            if (AREA_DE_WORK.AC_LINHAS > 53)
            {

                /*" -998- PERFORM R0700-00-IMPRIME-CABECALHO. */

                R0700_00_IMPRIME_CABECALHO_SECTION();
            }


            /*" -999- IF V0VAL-OPERACAO NOT EQUAL ZERO */

            if (V0VAL_OPERACAO != 00)
            {

                /*" -1004- COMPUTE WVAL-MEDIO-INDENIZ-X ROUNDED = V0VAL-OPERACAO / V0QTD-ITENS-SINI. */
                AREA_DE_WORK.ACUMUL_ZEROS.WVAL_MEDIO_INDENIZ_X.Value = V0VAL_OPERACAO / V0QTD_ITENS_SINI;
            }


            /*" -1005- MOVE V0NUM-SINI-FRANQUE TO WNUM-SINISTRO. */
            _.Move(V0NUM_SINI_FRANQUE, LD_01.WNUM_VASPEX.WNUM_SINISTRO);

            /*" -1006- MOVE V0ANO-SINI-FRANQUE TO WANO-SINISTRO. */
            _.Move(V0ANO_SINI_FRANQUE, LD_01.WNUM_VASPEX.WANO_SINISTRO);

            /*" -1007- MOVE V0QTD-ITENS-SINI TO WQTD-ENCOM-SINI. */
            _.Move(V0QTD_ITENS_SINI, LD_01.WQTD_ENCOM_SINI);

            /*" -1008- MOVE V0QTD-ITENS-TRANSP TO WQTD-ENCOM-TRANSP. */
            _.Move(V0QTD_ITENS_TRANSP, LD_01.WQTD_ENCOM_TRANSP);

            /*" -1009- MOVE V0VAL-OPERACAO TO WVAL-INDENIZADO. */
            _.Move(V0VAL_OPERACAO, LD_01.WVAL_INDENIZADO);

            /*" -1010- MOVE V0VAL-OPERACAO-PEND TO WVAL-PENDENTE. */
            _.Move(V0VAL_OPERACAO_PEND, LD_01.WVAL_PENDENTE);

            /*" -1011- MOVE WVAL-MEDIO-INDENIZ-X TO WVAL-MEDIO-INDENIZ */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WVAL_MEDIO_INDENIZ_X, LD_01.WVAL_MEDIO_INDENIZ);

            /*" -1012- MOVE V0DATA-OCORR TO WDATA-AUXILIAR. */
            _.Move(V0DATA_OCORR, AREA_DE_WORK.WDATA_AUXILIAR);

            /*" -1013- MOVE W-AA-AUX TO W-AA-OCORR. */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_AA_AUX, LD_01.WDATA_OCORR.W_AA_OCORR);

            /*" -1014- MOVE W-MM-AUX TO W-MM-OCORR. */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_MM_AUX, LD_01.WDATA_OCORR.W_MM_OCORR);

            /*" -1018- MOVE W-DD-AUX TO W-DD-OCORR. */
            _.Move(AREA_DE_WORK.WDATA_AUXILIAR.W_DD_AUX, LD_01.WDATA_OCORR.W_DD_OCORR);

            /*" -1020- ADD 01 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 01;

            /*" -1022- COMPUTE WTOT-ENCOM-SINI-X = V0QTD-ITENS-SINI + WTOT-ENCOM-SINI-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_SINI_X.Value = V0QTD_ITENS_SINI + AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_SINI_X;

            /*" -1024- COMPUTE WTOT-ENCOM-TRANSP-X = V0QTD-ITENS-TRANSP + WTOT-ENCOM-TRANSP-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_TRANSP_X.Value = V0QTD_ITENS_TRANSP + AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_TRANSP_X;

            /*" -1026- COMPUTE WTOT-INDENIZADO-X = V0VAL-OPERACAO + WTOT-INDENIZADO-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WTOT_INDENIZADO_X.Value = V0VAL_OPERACAO + AREA_DE_WORK.ACUMUL_ZEROS.WTOT_INDENIZADO_X;

            /*" -1028- COMPUTE WTOT-PENDENTE-X = V0VAL-OPERACAO-PEND + WTOT-PENDENTE-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WTOT_PENDENTE_X.Value = V0VAL_OPERACAO_PEND + AREA_DE_WORK.ACUMUL_ZEROS.WTOT_PENDENTE_X;

            /*" -1029- COMPUTE WTOT-MEDIO-INDENIZ-X = WVAL-MEDIO-INDENIZ-X + WTOT-MEDIO-INDENIZ-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WTOT_MEDIO_INDENIZ_X.Value = AREA_DE_WORK.ACUMUL_ZEROS.WVAL_MEDIO_INDENIZ_X + AREA_DE_WORK.ACUMUL_ZEROS.WTOT_MEDIO_INDENIZ_X;

        }

        [StopWatch]
        /*" R0500-00-SELECT-V0HISTSINI-DB-SELECT-3 */
        public void R0500_00_SELECT_V0HISTSINI_DB_SELECT_3()
        {
            /*" -973- EXEC SQL SELECT VALUE(SUM(VAL_OPERACAO),0) INTO :V0VAL-OPERACAO-PEND1 FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V0NUM-APOL-SINISTRO AND SITUACAO <> '2' AND OPERACAO IN (105,106,107,108,115,116,117, 118,1001,1002,1003,1004,1009) END-EXEC. */

            var r0500_00_SELECT_V0HISTSINI_DB_SELECT_3_Query1 = new R0500_00_SELECT_V0HISTSINI_DB_SELECT_3_Query1()
            {
                V0NUM_APOL_SINISTRO = V0NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R0500_00_SELECT_V0HISTSINI_DB_SELECT_3_Query1.Execute(r0500_00_SELECT_V0HISTSINI_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0VAL_OPERACAO_PEND1, V0VAL_OPERACAO_PEND1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-IMPRIME-CABECALHO-SECTION */
        private void R0700_00_IMPRIME_CABECALHO_SECTION()
        {
            /*" -1041- MOVE '700' TO WNR-EXEC-SQL. */
            _.Move("700", WABEND.WNR_EXEC_SQL);

            /*" -1042- ADD 1 TO AC-PAGINA */
            AREA_DE_WORK.ACUMUL_ZEROS.AC_PAGINA.Value = AREA_DE_WORK.ACUMUL_ZEROS.AC_PAGINA + 1;

            /*" -1043- MOVE ZEROS TO AC-LINHAS */
            _.Move(0, AREA_DE_WORK.AC_LINHAS);

            /*" -1055- MOVE AC-PAGINA TO LC-01-PAGINA */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.AC_PAGINA, AREA_DE_WORK.LC_01.LC_01_PAGINA);

            /*" -1055- MOVE 12 TO AC-LINHAS. */
            _.Move(12, AREA_DE_WORK.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0710-00-IMPRIME-CAB-RESUMO-SECTION */
        private void R0710_00_IMPRIME_CAB_RESUMO_SECTION()
        {
            /*" -1068- MOVE '710' TO WNR-EXEC-SQL. */
            _.Move("710", WABEND.WNR_EXEC_SQL);

            /*" -1069- ADD 1 TO AC-PAGINA */
            AREA_DE_WORK.ACUMUL_ZEROS.AC_PAGINA.Value = AREA_DE_WORK.ACUMUL_ZEROS.AC_PAGINA + 1;

            /*" -1070- MOVE ZEROS TO AC-LINHAS */
            _.Move(0, AREA_DE_WORK.AC_LINHAS);

            /*" -1083- MOVE AC-PAGINA TO LC-01-PAGINA */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.AC_PAGINA, AREA_DE_WORK.LC_01.LC_01_PAGINA);

            /*" -1083- MOVE 15 TO AC-LINHAS. */
            _.Move(15, AREA_DE_WORK.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-IMPRIME-LINHA-TOT-SECTION */
        private void R0800_00_IMPRIME_LINHA_TOT_SECTION()
        {
            /*" -1096- MOVE '800' TO WNR-EXEC-SQL. */
            _.Move("800", WABEND.WNR_EXEC_SQL);

            /*" -1098- IF WTOT-SINISTRO-X NOT EQUAL ZERO AND WTOT-INDENIZADO-X NOT EQUAL ZERO */

            if (AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X != 00 && AREA_DE_WORK.ACUMUL_ZEROS.WTOT_INDENIZADO_X != 00)
            {

                /*" -1103- COMPUTE WTOT-MEDIO-INDENIZ-X ROUNDED = WTOT-INDENIZADO-X / WTOT-ENCOM-SINI-X. */
                AREA_DE_WORK.ACUMUL_ZEROS.WTOT_MEDIO_INDENIZ_X.Value = AREA_DE_WORK.ACUMUL_ZEROS.WTOT_INDENIZADO_X / AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_SINI_X;
            }


            /*" -1104- MOVE WTOT-SINISTRO-X TO WTOT-SINISTRO. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X, LD_02.WTOT_SINISTRO);

            /*" -1105- MOVE WTOT-ENCOM-SINI-X TO WTOT-ENCOM-SINI. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_SINI_X, LD_02.WTOT_ENCOM_SINI);

            /*" -1106- MOVE WTOT-ENCOM-TRANSP-X TO WTOT-ENCOM-TRANSP. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_TRANSP_X, LD_02.WTOT_ENCOM_TRANSP);

            /*" -1107- MOVE WTOT-INDENIZADO-X TO WTOT-INDENIZADO. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_INDENIZADO_X, LD_02.WTOT_INDENIZADO);

            /*" -1108- MOVE WTOT-PENDENTE-X TO WTOT-PENDENTE. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_PENDENTE_X, LD_02.WTOT_PENDENTE);

            /*" -1110- MOVE WTOT-MEDIO-INDENIZ-X TO WTOT-MEDIO-INDENIZ */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_MEDIO_INDENIZ_X, LD_02.WTOT_MEDIO_INDENIZ);

            /*" -1110- PERFORM R0900-00-MONTA-TAB-INT-SIN. */

            R0900_00_MONTA_TAB_INT_SIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-MONTA-TAB-INT-SIN-SECTION */
        private void R0900_00_MONTA_TAB_INT_SIN_SECTION()
        {
            /*" -1125- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", WABEND.WNR_EXEC_SQL);

            /*" -1126- MOVE WNOME-CLIENTE-ANT TO WNOME-CLIENTE-T(WIND). */
            _.Move(AREA_DE_WORK.ACUMUL_SPACE.WNOME_CLIENTE_ANT, TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WNOME_CLIENTE_T);

            /*" -1127- MOVE WTOT-SINISTRO-X TO WTOT-SINISTRO-T(WIND) */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_SINISTRO_X, TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_SINISTRO_T);

            /*" -1128- MOVE WTOT-ENCOM-SINI-X TO WTOT-ENCOM-SINI-T(WIND) */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_SINI_X, TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_ENCOM_SINI_T);

            /*" -1129- MOVE WTOT-ENCOM-TRANSP-X TO WTOT-ENCOM-TRANSP-T(WIND) */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_ENCOM_TRANSP_X, TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_ENCOM_TRANSP_T);

            /*" -1130- MOVE WTOT-INDENIZADO-X TO WTOT-INDENIZADO-T(WIND). */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_INDENIZADO_X, TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_INDENIZADO_T);

            /*" -1131- MOVE WTOT-PENDENTE-X TO WTOT-PENDENTE-T(WIND). */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_PENDENTE_X, TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_PENDENTE_T);

            /*" -1132- MOVE WTOT-MEDIO-INDENIZ-X TO WTOT-MEDIO-INDENIZ-T(WIND). */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WTOT_MEDIO_INDENIZ_X, TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_MEDIO_INDENIZ_T);

            /*" -1133- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -1135- ADD 1 TO WCONT-TAB. */
            AREA_DE_WORK.WCONT_TAB.Value = AREA_DE_WORK.WCONT_TAB + 1;

            /*" -1136- IF WIND GREATER 1000 */

            if (AREA_DE_WORK.WIND > 1000)
            {

                /*" -1137- DISPLAY 'COD. DO PROGRAMA : SI0843B' */
                _.Display($"COD. DO PROGRAMA : SI0843B");

                /*" -1138- DISPLAY 'ESTOURO NA TABELA INTERNA' */
                _.Display($"ESTOURO NA TABELA INTERNA");

                /*" -1139- DISPLAY 'TAMANHO DA TABELA: 1000' */
                _.Display($"TAMANHO DA TABELA: 1000");

                /*" -1140- DISPLAY 'VALOR DO INDICE  : ' WIND */
                _.Display($"VALOR DO INDICE  : {AREA_DE_WORK.WIND}");

                /*" -1140- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-IMPRIME-QDRESUMO-SECTION */
        private void R0910_00_IMPRIME_QDRESUMO_SECTION()
        {
            /*" -1153- MOVE '910' TO WNR-EXEC-SQL. */
            _.Move("910", WABEND.WNR_EXEC_SQL);

            /*" -1154- IF AC-LINHAS GREATER 50 */

            if (AREA_DE_WORK.AC_LINHAS > 50)
            {

                /*" -1156- PERFORM R0710-00-IMPRIME-CAB-RESUMO. */

                R0710_00_IMPRIME_CAB_RESUMO_SECTION();
            }


            /*" -1157- MOVE WNOME-CLIENTE-T(WIND) TO WRNOME-CLIENTE. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WNOME_CLIENTE_T, LRD_01.WRNOME_CLIENTE);

            /*" -1158- MOVE WTOT-SINISTRO-T(WIND) TO WRQTD-SINISTRO. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_SINISTRO_T, LRD_01.WRQTD_SINISTRO);

            /*" -1159- MOVE WTOT-ENCOM-SINI-T(WIND) TO WRQTD-ENCOM-SINI. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_ENCOM_SINI_T, LRD_01.WRQTD_ENCOM_SINI);

            /*" -1160- MOVE WTOT-ENCOM-TRANSP-T(WIND) TO WRQTD-ENCOM-TRANSP. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_ENCOM_TRANSP_T, LRD_01.WRQTD_ENCOM_TRANSP);

            /*" -1161- MOVE WTOT-INDENIZADO-T(WIND) TO WRVAL-INDENIZADO. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_INDENIZADO_T, LRD_01.WRVAL_INDENIZADO);

            /*" -1162- MOVE WTOT-PENDENTE-T(WIND) TO WRVAL-PENDENTE. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_PENDENTE_T, LRD_01.WRVAL_PENDENTE);

            /*" -1166- MOVE WTOT-MEDIO-INDENIZ-T(WIND) TO WRVAL-MEDIO-INDENIZ. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_MEDIO_INDENIZ_T, LRD_01.WRVAL_MEDIO_INDENIZ);

            /*" -1168- COMPUTE WRTOT-SINISTRO-X = WTOT-SINISTRO-T(WIND) + WRTOT-SINISTRO-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_SINISTRO_X.Value = TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_SINISTRO_T.Value + AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_SINISTRO_X;

            /*" -1170- COMPUTE WRTOT-ENCOM-SINI-X = WTOT-ENCOM-SINI-T(WIND) + WRTOT-ENCOM-SINI-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_ENCOM_SINI_X.Value = TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_ENCOM_SINI_T.Value + AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_ENCOM_SINI_X;

            /*" -1172- COMPUTE WRTOT-ENCOM-TRANSP-X = WTOT-ENCOM-TRANSP-T(WIND) + WRTOT-ENCOM-TRANSP-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_ENCOM_TRANSP_X.Value = TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_ENCOM_TRANSP_T.Value + AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_ENCOM_TRANSP_X;

            /*" -1174- COMPUTE WRTOT-INDENIZADO-X = WTOT-INDENIZADO-T(WIND) + WRTOT-INDENIZADO-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_INDENIZADO_X.Value = TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_INDENIZADO_T.Value + AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_INDENIZADO_X;

            /*" -1176- COMPUTE WRTOT-PENDENTE-X = WTOT-PENDENTE-T(WIND) + WRTOT-PENDENTE-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_PENDENTE_X.Value = TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_PENDENTE_T.Value + AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_PENDENTE_X;

            /*" -1179- COMPUTE WRTOT-MEDIO-INDENIZ-X = WRTOT-INDENIZADO-X / WRTOT-ENCOM-SINI-X. */
            AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_MEDIO_INDENIZ_X.Value = AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_INDENIZADO_X / AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_ENCOM_SINI_X;

            /*" -1180- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -1180- ADD 1 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0914-00-IMPRIME-CABECALHO-ARQ-SECTION */
        private void R0914_00_IMPRIME_CABECALHO_ARQ_SECTION()
        {
            /*" -1192- MOVE '914' TO WNR-EXEC-SQL. */
            _.Move("914", WABEND.WNR_EXEC_SQL);

            /*" -1193- WRITE REG-ARQ-SI0843 FROM LC-01 AFTER 1. */
            _.Move(AREA_DE_WORK.LC_01.GetMoveValues(), REG_ARQ_SI0843);

            SI0843.Write(REG_ARQ_SI0843.GetMoveValues().ToString());

            /*" -1194- WRITE REG-ARQ-SI0843 FROM LC-02 AFTER 1. */
            _.Move(AREA_DE_WORK.LC_02.GetMoveValues(), REG_ARQ_SI0843);

            SI0843.Write(REG_ARQ_SI0843.GetMoveValues().ToString());

            /*" -1195- WRITE REG-ARQ-SI0843 FROM LC-03 AFTER 1. */
            _.Move(AREA_DE_WORK.LC_03.GetMoveValues(), REG_ARQ_SI0843);

            SI0843.Write(REG_ARQ_SI0843.GetMoveValues().ToString());

            /*" -1196- WRITE REG-ARQ-SI0843 FROM LC-04 AFTER 1. */
            _.Move(AREA_DE_WORK.LC_04.GetMoveValues(), REG_ARQ_SI0843);

            SI0843.Write(REG_ARQ_SI0843.GetMoveValues().ToString());

            /*" -1197- WRITE REG-ARQ-SI0843 FROM LR-02 AFTER 1. */
            _.Move(AREA_DE_WORK.LR_02.GetMoveValues(), REG_ARQ_SI0843);

            SI0843.Write(REG_ARQ_SI0843.GetMoveValues().ToString());

            /*" -1198- WRITE REG-ARQ-SI0843 FROM LR-01 AFTER 1. */
            _.Move(AREA_DE_WORK.LR_01.GetMoveValues(), REG_ARQ_SI0843);

            SI0843.Write(REG_ARQ_SI0843.GetMoveValues().ToString());

            /*" -1199- WRITE REG-ARQ-SI0843 FROM LR-02 AFTER 1. */
            _.Move(AREA_DE_WORK.LR_02.GetMoveValues(), REG_ARQ_SI0843);

            SI0843.Write(REG_ARQ_SI0843.GetMoveValues().ToString());

            /*" -1200- WRITE REG-ARQ-SI0843 FROM LR-03 AFTER 1. */
            _.Move(AREA_DE_WORK.LR_03.GetMoveValues(), REG_ARQ_SI0843);

            SI0843.Write(REG_ARQ_SI0843.GetMoveValues().ToString());

            /*" -1201- WRITE REG-ARQ-SI0843 FROM LR-04 AFTER 1. */
            _.Move(AREA_DE_WORK.LR_04.GetMoveValues(), REG_ARQ_SI0843);

            SI0843.Write(REG_ARQ_SI0843.GetMoveValues().ToString());

            /*" -1201- WRITE REG-ARQ-SI0843 FROM LR-02 AFTER 1. */
            _.Move(AREA_DE_WORK.LR_02.GetMoveValues(), REG_ARQ_SI0843);

            SI0843.Write(REG_ARQ_SI0843.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0914_99_SAIDA*/

        [StopWatch]
        /*" R0915-00-IMPRIME-QDRESUMO-ARQ-SECTION */
        private void R0915_00_IMPRIME_QDRESUMO_ARQ_SECTION()
        {
            /*" -1213- MOVE '915' TO WNR-EXEC-SQL. */
            _.Move("915", WABEND.WNR_EXEC_SQL);

            /*" -1214- MOVE WNOME-CLIENTE-T(WIND) TO WRNOME-CLIENTE. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WNOME_CLIENTE_T, LRD_01.WRNOME_CLIENTE);

            /*" -1215- MOVE WTOT-SINISTRO-T(WIND) TO WRQTD-SINISTRO. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_SINISTRO_T, LRD_01.WRQTD_SINISTRO);

            /*" -1216- MOVE WTOT-ENCOM-SINI-T(WIND) TO WRQTD-ENCOM-SINI. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_ENCOM_SINI_T, LRD_01.WRQTD_ENCOM_SINI);

            /*" -1217- MOVE WTOT-ENCOM-TRANSP-T(WIND) TO WRQTD-ENCOM-TRANSP. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_ENCOM_TRANSP_T, LRD_01.WRQTD_ENCOM_TRANSP);

            /*" -1218- MOVE WTOT-INDENIZADO-T(WIND) TO WRVAL-INDENIZADO. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_INDENIZADO_T, LRD_01.WRVAL_INDENIZADO);

            /*" -1219- MOVE WTOT-PENDENTE-T(WIND) TO WRVAL-PENDENTE. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_PENDENTE_T, LRD_01.WRVAL_PENDENTE);

            /*" -1221- MOVE WTOT-MEDIO-INDENIZ-T(WIND) TO WRVAL-MEDIO-INDENIZ. */
            _.Move(TAB_INT_SINI_VASPEX.TAB_INT_SINI[AREA_DE_WORK.WIND].WTOT_MEDIO_INDENIZ_T, LRD_01.WRVAL_MEDIO_INDENIZ);

            /*" -1223- WRITE REG-ARQ-SI0843 FROM LRD-01 AFTER 1. */
            _.Move(LRD_01.GetMoveValues(), REG_ARQ_SI0843);

            SI0843.Write(REG_ARQ_SI0843.GetMoveValues().ToString());

            /*" -1223- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0915_99_SAIDA*/

        [StopWatch]
        /*" R0920-00-IMPRIME-TOTRESUMO-SECTION */
        private void R0920_00_IMPRIME_TOTRESUMO_SECTION()
        {
            /*" -1235- MOVE '920' TO WNR-EXEC-SQL. */
            _.Move("920", WABEND.WNR_EXEC_SQL);

            /*" -1236- MOVE WRTOT-SINISTRO-X TO WRTOT-SINISTRO. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_SINISTRO_X, LRD_02.WRTOT_SINISTRO);

            /*" -1237- MOVE WRTOT-ENCOM-SINI-X TO WRTOT-ENCOM-SINI. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_ENCOM_SINI_X, LRD_02.WRTOT_ENCOM_SINI);

            /*" -1238- MOVE WRTOT-ENCOM-TRANSP-X TO WRTOT-ENCOM-TRANSP. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_ENCOM_TRANSP_X, LRD_02.WRTOT_ENCOM_TRANSP);

            /*" -1239- MOVE WRTOT-INDENIZADO-X TO WRTOT-INDENIZADO. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_INDENIZADO_X, LRD_02.WRTOT_INDENIZADO);

            /*" -1240- MOVE WRTOT-PENDENTE-X TO WRTOT-PENDENTE. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_PENDENTE_X, LRD_02.WRTOT_PENDENTE);

            /*" -1245- MOVE WRTOT-MEDIO-INDENIZ-X TO WRTOT-MEDIO-INDENIZ. */
            _.Move(AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_MEDIO_INDENIZ_X, LRD_02.WRTOT_MEDIO_INDENIZ);

            /*" -1246- WRITE REG-ARQ-SI0843 FROM LR-05 AFTER 1. */
            _.Move(AREA_DE_WORK.LR_05.GetMoveValues(), REG_ARQ_SI0843);

            SI0843.Write(REG_ARQ_SI0843.GetMoveValues().ToString());

            /*" -1248- WRITE REG-ARQ-SI0843 FROM LRD-02 AFTER 1. */
            _.Move(LRD_02.GetMoveValues(), REG_ARQ_SI0843);

            SI0843.Write(REG_ARQ_SI0843.GetMoveValues().ToString());

            /*" -1249- MOVE ZEROS TO WRTOT-SINISTRO-X. */
            _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_SINISTRO_X);

            /*" -1250- MOVE ZEROS TO WRTOT-ENCOM-SINI-X. */
            _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_ENCOM_SINI_X);

            /*" -1251- MOVE ZEROS TO WRTOT-ENCOM-TRANSP-X. */
            _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_ENCOM_TRANSP_X);

            /*" -1252- MOVE ZEROS TO WRTOT-INDENIZADO-X. */
            _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_INDENIZADO_X);

            /*" -1253- MOVE ZEROS TO WRTOT-PENDENTE-X. */
            _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_PENDENTE_X);

            /*" -1253- MOVE ZEROS TO WRTOT-MEDIO-INDENIZ-X. */
            _.Move(0, AREA_DE_WORK.ACUMUL_ZEROS.WRTOT_MEDIO_INDENIZ_X);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1265- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1266- DISPLAY 'CODIGO DO FRANQUEADO       ' V0COD-FRANQUE */
            _.Display($"CODIGO DO FRANQUEADO       {V0COD_FRANQUE}");

            /*" -1267- DISPLAY 'NUMERO DA APOLICE          ' V0NUM-APOLICE */
            _.Display($"NUMERO DA APOLICE          {V0NUM_APOLICE}");

            /*" -1268- DISPLAY 'NUMERO DO SINISTRO         ' V0NUM-APOL-SINISTRO */
            _.Display($"NUMERO DO SINISTRO         {V0NUM_APOL_SINISTRO}");

            /*" -1270- DISPLAY 'QUANTIDADE DE LIDOS        ' WLIDOS-V0TRANSP1 */
            _.Display($"QUANTIDADE DE LIDOS        {AREA_DE_WORK.ACUMUL_ZEROS.WLIDOS_V0TRANSP1}");

            /*" -1273- CLOSE RSI0843B SI0843. */
            RSI0843B.Close();
            SI0843.Close();

            /*" -1275- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1275- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1277- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1279- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1279- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}