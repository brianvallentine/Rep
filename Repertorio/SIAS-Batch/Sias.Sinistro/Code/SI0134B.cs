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
using Sias.Sinistro.DB2.SI0134B;

namespace Code
{
    public class SI0134B
    {
        public bool IsCall { get; set; }

        public SI0134B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............ ROBERTO NOVAES ROCHA                *      */
        /*"      *   DATA CODIFICACAO ....... DEZ      / 2009                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO: RELACAO DE SINISTROS PRE-LIBERADOS.                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  13/02/2012 - CAD 66216/2012 - BUSCAR NOME SEGURADO EM BRANCO  *      */
        /*"      *                                                                *      */
        /*"      *               PATRICIA SALES            PROCURAR: V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  16/10/2010 - CAD 47494/2010 - CIRCULAR 395:                   *      */
        /*"      *               SUPORTAR O NOVO RAMO DE COMERCIALIZA��O DO       *      */
        /*"      *               HABITACIONAL, FORA DO SFH; SUPORTAR O NOVO       *      */
        /*"      *               RAMO DE COMERCIALIZA��O DO SEGURO GARANTIA       *      */
        /*"      *               CONSTRUTOR - SETOR P�BLICO E PRIVADO E SU-       *      */
        /*"      *               PORTAR NOVOS PRODUTOS QUE SER�O CRIADOS NO       *      */
        /*"      *               RAMO 48 DOS CONTRATOS DO CONS�RCIO.              *      */
        /*"      *                                                                *      */
        /*"      *               MARCELO NEVES (TE41729)   PROCURAR: C395         *      */
        /*"      *                                                                *      */
        /*"      *  13/10/2012   BENTO LEITE ARAUJO(TE18225) CAD 72054            *      */
        /*"      *               INCLUIR OPERA��O DE PRE-LIBERA��O DE DEPOSITOS.  *      */
        /*"      *               FUNCAO_OPERACAO INCLUIDA ==> 'JPDP'              *      */
        /*"      *                                         PROCURAR: V.04         *      */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  24/01/2017   MANOEL MENDES  --  CADMUS 145850                        */
        /*"      *               ALTERAR ALCADA PARA VALORES VARIAVEIS                   */
        /*"      *                                         PROCURAR: V.05                */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  10/05/2019   EDIJANE INACIO -- MAC x SMART x SIAS                    */
        /*"      *               PREVER SINISTRO HAB. SMART-MAC-SIAS      V06            */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _SAI0134B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis SAI0134B
        {
            get
            {
                _.Move(REG_VA0134B, _SAI0134B); VarBasis.RedefinePassValue(REG_VA0134B, _SAI0134B, REG_VA0134B); return _SAI0134B;
            }
        }
        /*"01          REG-VA0134B     PIC X(132).*/
        public StringBasis REG_VA0134B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          WHOST-DT-HOJE         PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DT_HOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77          WHOST-DATA-FIM        PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DATA_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77          WHOST-DATA-INI        PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77          W77-VAL-IN-TOTAL      PIC S9(13)V99 COMP VALUE +0.*/
        public DoubleBasis W77_VAL_IN_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          W77-VAL-AVISADO       PIC S9(13)V99 COMP VALUE +0.*/
        public DoubleBasis W77_VAL_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          W77-DESPREZ-SINISMES  PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_SINISMES { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DESPREZ-SEGURVGA  PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_SEGURVGA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DESPREZ-CLIENTES  PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_CLIENTES { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DESPREZ-AVISADO   PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_AVISADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DESPREZ-PRODUVG   PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_PRODUVG { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DATA-PRE          PIC  X(10)      VALUE ZEROS.*/
        public StringBasis W77_DATA_PRE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77          WHOST-DTFINAL         PIC  X(10)      VALUE ZEROS.*/
        public StringBasis WHOST_DTFINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  AREA-DE-WORK.*/
        public SI0134B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0134B_AREA_DE_WORK();
        public class SI0134B_AREA_DE_WORK : VarBasis
        {
            /*"   05       SIST-DT-MOV-ABERTO  PIC  X(10)     VALUE ZEROS.*/
            public StringBasis SIST_DT_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"   05       WFIM-SISTEMA        PIC  X(01)     VALUE  ' '.*/
            public StringBasis WFIM_SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"   05       WFIM-SINISHIS       PIC  X(01)     VALUE  ' '.*/
            public StringBasis WFIM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"   05       WFIM-SINISHIS1      PIC  X(01)     VALUE  ' '.*/
            public StringBasis WFIM_SINISHIS1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"   05       WTEM-USUARIO        PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_USUARIO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-PAGAMENTO      PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-SINISHIS       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-CLIENTES       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_CLIENTES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-APOLICES       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_APOLICES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-SEGURVGA       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-SISTEMAS       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_SISTEMAS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-FONTES         PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_FONTES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-PRODUVG        PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_PRODUVG { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05  AUX-TIME              PIC X(08)     VALUE  SPACES.*/
            public StringBasis AUX_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"   05  WVAL-ALCADA-DE        PIC S9(12)V99  VALUE ZEROS.*/
            public DoubleBasis WVAL_ALCADA_DE { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V99"), 2);
            /*"   05  WVAL-ALCADA-ATE       PIC S9(12)V99  VALUE ZEROS.*/
            public DoubleBasis WVAL_ALCADA_ATE { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V99"), 2);
            /*"   05  WVAL-ALCADA-DE-ANT    PIC S9(12)V99  VALUE ZEROS.*/
            public DoubleBasis WVAL_ALCADA_DE_ANT { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V99"), 2);
            /*"   05  WVAL-ALCADA-ATE-ANT   PIC S9(12)V99  VALUE ZEROS.*/
            public DoubleBasis WVAL_ALCADA_ATE_ANT { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V99"), 2);
            /*"   05  WXAV-Q-RAM-USU-ATU.*/
            public SI0134B_WXAV_Q_RAM_USU_ATU WXAV_Q_RAM_USU_ATU { get; set; } = new SI0134B_WXAV_Q_RAM_USU_ATU();
            public class SI0134B_WXAV_Q_RAM_USU_ATU : VarBasis
            {
                /*"       10 WRAMO-ATU          PIC 9(02).*/
                public IntBasis WRAMO_ATU { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       10 WUSUA-ATU          PIC X(11).*/
                public StringBasis WUSUA_ATU { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
                /*"   05  WXAV-Q-RAM-USU-ANT.*/
            }
            public SI0134B_WXAV_Q_RAM_USU_ANT WXAV_Q_RAM_USU_ANT { get; set; } = new SI0134B_WXAV_Q_RAM_USU_ANT();
            public class SI0134B_WXAV_Q_RAM_USU_ANT : VarBasis
            {
                /*"       10 WRAMO-ANT          PIC 9(02).*/
                public IntBasis WRAMO_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       10 WUSUA-ANT          PIC X(11).*/
                public StringBasis WUSUA_ANT { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
                /*"   05       AC-LIDOS            PIC  9(09)     VALUE  ZEROS.*/
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-LINHAS           PIC  9(02)     VALUE  80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 80);
            /*"   05       AC-PAGINA           PIC  9(02)     VALUE  ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"   05       AC-CONTA            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-GRAVADOS         PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-PRE-LIBERA       PIC  9(12)V99  VALUE  ZEROS.*/
            public DoubleBasis AC_PRE_LIBERA { get; set; } = new DoubleBasis(new PIC("9", "12", "9(12)V99"), 2);
            /*"   05       AC-PRE-LIBERA-TOT   PIC  9(12)V99  VALUE  ZEROS.*/
            public DoubleBasis AC_PRE_LIBERA_TOT { get; set; } = new DoubleBasis(new PIC("9", "12", "9(12)V99"), 2);
            /*"   05       AUX-RESULTADO      PIC  9(09)   VALUE   ZEROS.*/
            public IntBasis AUX_RESULTADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AUX-RESTO          PIC  9(09)   VALUE   ZEROS.*/
            public IntBasis AUX_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       WS-ERRO-DATA       PIC  X(003)  VALUE   SPACES.*/
            public StringBasis WS_ERRO_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"   05       WS-DTH-DETALHE.*/
            public SI0134B_WS_DTH_DETALHE WS_DTH_DETALHE { get; set; } = new SI0134B_WS_DTH_DETALHE();
            public class SI0134B_WS_DTH_DETALHE : VarBasis
            {
                /*"     10     WS-DETALHE-ANO     PIC  9(004).*/
                public IntBasis WS_DETALHE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10     FILLER             PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10     WS-DETALHE-MES     PIC  9(002).*/
                public IntBasis WS_DETALHE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10     FILLER             PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10     WS-DETALHE-DIA     PIC  9(002).*/
                public IntBasis WS_DETALHE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05       WS-DTH-DETALHE-I.*/
            }
            public SI0134B_WS_DTH_DETALHE_I WS_DTH_DETALHE_I { get; set; } = new SI0134B_WS_DTH_DETALHE_I();
            public class SI0134B_WS_DTH_DETALHE_I : VarBasis
            {
                /*"     10     WS-DETALHE-DIA-I   PIC  9(002).*/
                public IntBasis WS_DETALHE_DIA_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10     FILLER             PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10     WS-DETALHE-MES-I   PIC  9(002).*/
                public IntBasis WS_DETALHE_MES_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10     FILLER             PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10     WS-DETALHE-ANO-I   PIC  9(004).*/
                public IntBasis WS_DETALHE_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   05       WS-LIDOS           PIC 9(008)   VALUE   ZEROS.*/
            }
            public IntBasis WS_LIDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   05       WS-GRAVA-ARQ1      PIC 9(008)   VALUE   ZEROS.*/
            public IntBasis WS_GRAVA_ARQ1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   05       WS-GRAVA-DES       PIC 9(008)   VALUE   ZEROS.*/
            public IntBasis WS_GRAVA_DES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   05       WS-DATA-ACCEPT.*/
            public SI0134B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new SI0134B_WS_DATA_ACCEPT();
            public class SI0134B_WS_DATA_ACCEPT : VarBasis
            {
                /*"     10     WS-ANO-ACCEPT      PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     WS-MES-ACCEPT      PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     WS-DIA-ACCEPT      PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05       WS-HORA-ACCEPT.*/
            }
            public SI0134B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new SI0134B_WS_HORA_ACCEPT();
            public class SI0134B_WS_HORA_ACCEPT : VarBasis
            {
                /*"     10     WS-HOR-ACCEPT      PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     WS-MIN-ACCEPT      PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     WS-SEG-ACCEPT      PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05       WS-DATA-CURR.*/
            }
            public SI0134B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new SI0134B_WS_DATA_CURR();
            public class SI0134B_WS_DATA_CURR : VarBasis
            {
                /*"     10     WS-DIA-CURR        PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_DIA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     FILLER             PIC  X(001)  VALUE   '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10     WS-MES-CURR        PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MES_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     FILLER             PIC  X(001)  VALUE   '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10     WS-ANO-CURR        PIC  9(004)  VALUE   ZEROS.*/
                public IntBasis WS_ANO_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   05       HB-HORA-REL.*/
            }
            public SI0134B_HB_HORA_REL HB_HORA_REL { get; set; } = new SI0134B_HB_HORA_REL();
            public class SI0134B_HB_HORA_REL : VarBasis
            {
                /*"     10      HB-HH-REL         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis HB_HH_REL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLER            PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"     10      HB-MN-REL         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis HB_MN_REL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      FILLER            PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"     10      HB-SS-REL         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis HB_SS_REL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05        HB-TIME.*/
            }
            public SI0134B_HB_TIME HB_TIME { get; set; } = new SI0134B_HB_TIME();
            public class SI0134B_HB_TIME : VarBasis
            {
                /*"     10      HB-HH-TIME        PIC  9(002)      VALUE ZEROS.*/
                public IntBasis HB_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      HB-MM-TIME        PIC  9(002)      VALUE ZEROS.*/
                public IntBasis HB_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      HB-SS-TIME        PIC  9(002)      VALUE ZEROS.*/
                public IntBasis HB_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10      HB-CC-TIME        PIC  9(002)      VALUE ZEROS.*/
                public IntBasis HB_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05        WS-DATE.*/
            }
            public SI0134B_WS_DATE WS_DATE { get; set; } = new SI0134B_WS_DATE();
            public class SI0134B_WS_DATE : VarBasis
            {
                /*"     10      WS-AA-DATE        PIC  9(02).*/
                public IntBasis WS_AA_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10      WS-MM-DATE        PIC  9(02).*/
                public IntBasis WS_MM_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10      WS-DD-DATE        PIC  9(02).*/
                public IntBasis WS_DD_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05       WHOST-DATA-REF     PIC  X(010)  VALUE   SPACES.*/
            }
            public StringBasis WHOST_DATA_REF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"   05       WHOST-COD-PRODUTO  PIC S9(004)  VALUE  +0 COMP.*/
            public IntBasis WHOST_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05       WHOST-DTH-INI      PIC  X(010).*/
            public StringBasis WHOST_DTH_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05       WHOST-DTH-FIM      PIC  X(010).*/
            public StringBasis WHOST_DTH_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05       WHOST-DTCURRENT    PIC  X(010)  VALUE SPACES.*/
            public StringBasis WHOST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"   05       WS-DT-HJ10.*/
            public SI0134B_WS_DT_HJ10 WS_DT_HJ10 { get; set; } = new SI0134B_WS_DT_HJ10();
            public class SI0134B_WS_DT_HJ10 : VarBasis
            {
                /*"     10     WS-DT-HJ10-DD      PIC  X(002).*/
                public StringBasis WS_DT_HJ10_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"     10     FILLER             PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10     WS-DT-HJ10-MM      PIC  X(002).*/
                public StringBasis WS_DT_HJ10_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"     10     FILLER             PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10     WS-DT-HJ10-AA      PIC  X(004).*/
                public StringBasis WS_DT_HJ10_AA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"   05        WS-DT-INI10.*/
            }
            public SI0134B_WS_DT_INI10 WS_DT_INI10 { get; set; } = new SI0134B_WS_DT_INI10();
            public class SI0134B_WS_DT_INI10 : VarBasis
            {
                /*"     10     WS-DT-INI10-DD     PIC  X(002).*/
                public StringBasis WS_DT_INI10_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"     10     FILLER             PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10     WS-DT-INI10-MM     PIC  X(002).*/
                public StringBasis WS_DT_INI10_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"     10     FILLER             PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"     10     WS-DT-INI10-AA     PIC  X(004).*/
                public StringBasis WS_DT_INI10_AA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"   05       LD00-11.*/
            }
            public SI0134B_LD00_11 LD00_11 { get; set; } = new SI0134B_LD00_11();
            public class SI0134B_LD00_11 : VarBasis
            {
                /*"     10     FILLER             PIC X(09)   VALUE            'PERIODO:'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PERIODO:");
                /*"     10     LD00-11-DATAINI    PIC X(10).*/
                public StringBasis LD00_11_DATAINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10     LD00-11-A          PIC X(05)   VALUE   SPACES.*/
                public StringBasis LD00_11_A { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"     10     LD00-11-DATAFIN    PIC X(10)   VALUE   SPACES.*/
                public StringBasis LD00_11_DATAFIN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"     10     FILLER             PIC X(01)   VALUE '.'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"     10     FILLER             PIC X(01)   VALUE '.'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"   05       DATA-SQL.*/
            }
            public SI0134B_DATA_SQL DATA_SQL { get; set; } = new SI0134B_DATA_SQL();
            public class SI0134B_DATA_SQL : VarBasis
            {
                /*"     10     ANO-SQL            PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10     FILLER             PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     MES-SQL            PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10     FILLER             PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     FILLER             PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     DIA-SQL            PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05      LC-TRACO              PIC  X(132)   VALUE ALL '-'.*/
            }
            public StringBasis LC_TRACO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
            /*"   05      LC-SEMREG.*/
            public SI0134B_LC_SEMREG LC_SEMREG { get; set; } = new SI0134B_LC_SEMREG();
            public class SI0134B_LC_SEMREG : VarBasis
            {
                /*"       10  FILLER                PIC  X(050)   VALUE SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"       10  FILLER                PIC  X(041)   VALUE           'NAO EXISTE NENHUMA PRE-LIBERACAO PENDENTE'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"NAO EXISTE NENHUMA PRE-LIBERACAO PENDENTE");
                /*"   05      LC-TRACONTINUA.*/
            }
            public SI0134B_LC_TRACONTINUA LC_TRACONTINUA { get; set; } = new SI0134B_LC_TRACONTINUA();
            public class SI0134B_LC_TRACONTINUA : VarBasis
            {
                /*"       10  FILLER                PIC  X(121)   VALUE ALL '-'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "121", "X(121)"), @"ALL");
                /*"       10  FILLER                PIC  X(011)   VALUE           '(CONTINUA)-'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"(CONTINUA)-");
                /*"   05      LC-TRAFIM.*/
            }
            public SI0134B_LC_TRAFIM LC_TRAFIM { get; set; } = new SI0134B_LC_TRAFIM();
            public class SI0134B_LC_TRAFIM : VarBasis
            {
                /*"       10  FILLER                PIC  X(126)   VALUE ALL '-'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "126", "X(126)"), @"ALL");
                /*"       10  FILLER                PIC  X(006)   VALUE           '(FIM)-'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"(FIM)-");
                /*"   05       CAB1.*/
            }
            public SI0134B_CAB1 CAB1 { get; set; } = new SI0134B_CAB1();
            public class SI0134B_CAB1 : VarBasis
            {
                /*"       10     FILLER              PIC  X(052)   VALUE 'SI0134B'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"SI0134B");
                /*"       10     FILLER              PIC  X(021)   VALUE              'CAIXA SEGURADORA S.A.'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"CAIXA SEGURADORA S.A.");
                /*"       10     FILLER              PIC  X(047)   VALUE  SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"");
                /*"       10     FILLER              PIC  X(008)   VALUE 'PAGINA:'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PAGINA:");
                /*"       10     CAB1-PAGINA           PIC  Z999.*/
                public IntBasis CAB1_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "Z999."));
                /*"   05       CAB2.*/
            }
            public SI0134B_CAB2 CAB2 { get; set; } = new SI0134B_CAB2();
            public class SI0134B_CAB2 : VarBasis
            {
                /*"     10     FILLER                PIC  X(045)   VALUE SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"");
                /*"     10     FILLER                PIC  X(034)   VALUE            'RELACAO DE SINISTROS PRE-LIBERADOS'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"RELACAO DE SINISTROS PRE-LIBERADOS");
                /*"     10     FILLER                PIC  X(038)   VALUE SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"");
                /*"     10     FILLER                PIC  X(005)   VALUE 'DATA '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA ");
                /*"     10     CAB1-DATA-ATU         PIC  X(010)   VALUE SPACES.*/
                public StringBasis CAB1_DATA_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"   05       CAB3.*/
            }
            public SI0134B_CAB3 CAB3 { get; set; } = new SI0134B_CAB3();
            public class SI0134B_CAB3 : VarBasis
            {
                /*"     10     FILLER                PIC  X(006)   VALUE            'RAMO: '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"RAMO: ");
                /*"     10     CAB3-RAMO             PIC  9(002).*/
                public IntBasis CAB3_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10     FILLER                PIC  X(011)   VALUE            ' ANALISTA: '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" ANALISTA: ");
                /*"     10     CAB3-ANALISTA         PIC  X(011).*/
                public StringBasis CAB3_ANALISTA { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"     10     FILLER                PIC  X(003)   VALUE ' - '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"     10     CAB3-NOME-ANALISTA    PIC  X(025).*/
                public StringBasis CAB3_NOME_ANALISTA { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"     10     FILLER                PIC  X(016)   VALUE            '  ALCADA: DE R$ '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"  ALCADA: DE R$ ");
                /*"     10     CAB3-VALOR-DE         PIC ZZZ.ZZZ.ZZZ.999,99.*/
                public DoubleBasis CAB3_VALOR_DE { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.999V99."), 2);
                /*"     10     FILLER                PIC  X(006)   VALUE            ' A R$ '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" A R$ ");
                /*"     10     CAB3-VALOR-ATE        PIC ZZZ.ZZZ.ZZZ.999,99.*/
                public DoubleBasis CAB3_VALOR_ATE { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.999V99."), 2);
                /*"     10     FILLER                PIC  X(008)   VALUE                '   HORA '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"   HORA ");
                /*"     10     CAB3-HORA             PIC  X(008)   VALUE SPACES.*/
                public StringBasis CAB3_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"   05       CAB4.*/
            }
            public SI0134B_CAB4 CAB4 { get; set; } = new SI0134B_CAB4();
            public class SI0134B_CAB4 : VarBasis
            {
                /*"     10     FILLER              PIC  X(016) VALUE            'SINISTRO        '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"SINISTRO        ");
                /*"     10     FILLER              PIC  X(039) VALUE            'SEGURADO                              '.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"SEGURADO                              ");
                /*"     10     FILLER              PIC  X(016) VALUE            'DT PRE-LIBERACAO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"DT PRE-LIBERACAO");
                /*"     10     FILLER              PIC  X(015) VALUE            ' DT PAGAMENTO  '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @" DT PAGAMENTO  ");
                /*"     10     FILLER              PIC  X(018) VALUE            '   VLR INDENIZACAO'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"   VLR INDENIZACAO");
                /*"     10     FILLER              PIC  X(018) VALUE            '       TIPO RECIBO'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"       TIPO RECIBO");
                /*"     10     FILLER              PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"   05       SAI.*/
            }
            public SI0134B_SAI SAI { get; set; } = new SI0134B_SAI();
            public class SI0134B_SAI : VarBasis
            {
                /*"     10    SAI-NUM-APOL-SINISTRO PIC  9(13).*/
                public IntBasis SAI_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"     10    FILLER                PIC  X(02)  VALUE SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"     10    SAI-SEGURADO          PIC  X(40).*/
                public StringBasis SAI_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(06)  VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
                /*"     10    SAI-DT-PRE-LIBE       PIC  X(10).*/
                public StringBasis SAI_DT_PRE_LIBE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10    FILLER                PIC  X(03)  VALUE ' '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
                /*"     10    SAI-DT-PAGAMENTO      PIC  X(10).*/
                public StringBasis SAI_DT_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ' '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"     10    SAI-VALOR-INDENIZ     PIC  ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis SAI_VALOR_INDENIZ { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"     10    FILLER                PIC  X(03)  VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"     10    SAI-TIPO-RECIBO       PIC  X(21).*/
                public StringBasis SAI_TIPO_RECIBO { get; set; } = new StringBasis(new PIC("X", "21", "X(21)."), @"");
                /*"     10    FILLER                PIC  X(05)  VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"   05       SAI-TOTAL.*/
            }
            public SI0134B_SAI_TOTAL SAI_TOTAL { get; set; } = new SI0134B_SAI_TOTAL();
            public class SI0134B_SAI_TOTAL : VarBasis
            {
                /*"     10    FILLER                PIC  X(58)  VALUE SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "58", "X(58)"), @"");
                /*"     10    FILLER                PIC  X(27)    VALUE           'TOTAL PRE - LIBERACAO:     '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"TOTAL PRE - LIBERACAO:     ");
                /*"     10 SAI-TOTAL-LIBERACAO   PIC  ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis SAI_TOTAL_LIBERACAO { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"   05       WABEND.*/
            }
            public SI0134B_WABEND WABEND { get; set; } = new SI0134B_WABEND();
            public class SI0134B_WABEND : VarBasis
            {
                /*"     10     FILLER              PIC  X(010)    VALUE             'SI0134B'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0134B");
                /*"     10     FILLER              PIC  X(026)    VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"     10     WNR-EXEC-SQL        PIC  X(004)    VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"     10     FILLER              PIC  X(013)    VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"     10     WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.SIHABIT2 SIHABIT2 { get; set; } = new Dclgens.SIHABIT2();
        public Dclgens.AGTABCH1 AGTABCH1 { get; set; } = new Dclgens.AGTABCH1();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.APOLICRE APOLICRE { get; set; } = new Dclgens.APOLICRE();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SINCREIN SINCREIN { get; set; } = new Dclgens.SINCREIN();
        public SI0134B_SINISTRO SINISTRO { get; set; } = new SI0134B_SINISTRO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SAI0134B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SAI0134B.SetFile(SAI0134B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -374- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -377- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -380- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -382- PERFORM R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -393- OPEN OUTPUT SAI0134B */
            SAI0134B.Open(REG_VA0134B);

            /*" -395- ACCEPT HB-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.HB_TIME);

            /*" -396- MOVE HB-HH-TIME TO HB-HH-REL */
            _.Move(AREA_DE_WORK.HB_TIME.HB_HH_TIME, AREA_DE_WORK.HB_HORA_REL.HB_HH_REL);

            /*" -397- MOVE HB-MM-TIME TO HB-MN-REL */
            _.Move(AREA_DE_WORK.HB_TIME.HB_MM_TIME, AREA_DE_WORK.HB_HORA_REL.HB_MN_REL);

            /*" -398- MOVE HB-SS-TIME TO HB-SS-REL */
            _.Move(AREA_DE_WORK.HB_TIME.HB_SS_TIME, AREA_DE_WORK.HB_HORA_REL.HB_SS_REL);

            /*" -400- MOVE HB-HORA-REL TO CAB3-HORA */
            _.Move(AREA_DE_WORK.HB_HORA_REL, AREA_DE_WORK.CAB3.CAB3_HORA);

            /*" -402- ACCEPT WS-DATE FROM DATE */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WS_DATE);

            /*" -403- MOVE WS-DD-DATE TO WS-DIA-CURR */
            _.Move(AREA_DE_WORK.WS_DATE.WS_DD_DATE, AREA_DE_WORK.WS_DATA_CURR.WS_DIA_CURR);

            /*" -404- MOVE WS-MM-DATE TO WS-MES-CURR */
            _.Move(AREA_DE_WORK.WS_DATE.WS_MM_DATE, AREA_DE_WORK.WS_DATA_CURR.WS_MES_CURR);

            /*" -405- MOVE WS-AA-DATE TO WS-ANO-CURR */
            _.Move(AREA_DE_WORK.WS_DATE.WS_AA_DATE, AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR);

            /*" -406- ADD 2000 TO WS-ANO-CURR */
            AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR.Value = AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR + 2000;

            /*" -407- MOVE WS-DATA-CURR TO CAB1-DATA-ATU */
            _.Move(AREA_DE_WORK.WS_DATA_CURR, AREA_DE_WORK.CAB2.CAB1_DATA_ATU);

            /*" -408- MOVE WS-DATA-CURR TO CAB1-DATA-ATU */
            _.Move(AREA_DE_WORK.WS_DATA_CURR, AREA_DE_WORK.CAB2.CAB1_DATA_ATU);

            /*" -410- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -412- PERFORM 0200-00-LE-SISTEMAS. */

            M_0200_00_LE_SISTEMAS_SECTION();

            /*" -413- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -414- DISPLAY ' INICIO SI0134B       DATA : ' WS-DT-HJ10 */
            _.Display($" INICIO SI0134B       DATA : {AREA_DE_WORK.WS_DT_HJ10}");

            /*" -415- DISPLAY '                                             ' */
            _.Display($"                                             ");

            /*" -416- DISPLAY ' VERSAO ' 5 ' SMART x MAC x SIAS - MAIO/2019.' */

            $" VERSAO 5 SMART x MAC x SIAS - MAIO/2019."
            .Display();

            /*" -417- DISPLAY '                                             ' */
            _.Display($"                                             ");

            /*" -418- DISPLAY ' DATA MOVIMENTO ' WS-DT-INI10 */
            _.Display($" DATA MOVIMENTO {AREA_DE_WORK.WS_DT_INI10}");

            /*" -421- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -423- PERFORM R0900-00-DECLARE-CURSOR */

            R0900_00_DECLARE_CURSOR_SECTION();

            /*" -425- PERFORM R0910-00-FETCH-CURSOR */

            R0910_00_FETCH_CURSOR_SECTION();

            /*" -427- IF WFIM-SINISHIS EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SINISHIS == "S")
            {

                /*" -429- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -430- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -431- DISPLAY '*  NAO HA MOVIMENTO PARA O PERIODO  *' */
                _.Display($"*  NAO HA MOVIMENTO PARA O PERIODO  *");

                /*" -433- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -435- MOVE 1 TO CAB1-PAGINA */
                _.Move(1, AREA_DE_WORK.CAB1.CAB1_PAGINA);

                /*" -436- WRITE REG-VA0134B FROM CAB1 AFTER 1 */
                _.Move(AREA_DE_WORK.CAB1.GetMoveValues(), REG_VA0134B);

                SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

                /*" -437- WRITE REG-VA0134B FROM CAB2 AFTER 1 */
                _.Move(AREA_DE_WORK.CAB2.GetMoveValues(), REG_VA0134B);

                SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

                /*" -438- WRITE REG-VA0134B FROM LC-SEMREG AFTER 1 */
                _.Move(AREA_DE_WORK.LC_SEMREG.GetMoveValues(), REG_VA0134B);

                SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

                /*" -440- WRITE REG-VA0134B FROM LC-TRAFIM AFTER 2 */
                _.Move(AREA_DE_WORK.LC_TRAFIM.GetMoveValues(), REG_VA0134B);

                SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

                /*" -442- PERFORM R0000-90-FINALIZA */

                R0000_90_FINALIZA_SECTION();

                /*" -469- END-IF */
            }


            /*" -472- PERFORM R0910-00-FETCH-CURSOR UNTIL WFIM-SINISHIS EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SINISHIS == "S"))
            {

                R0910_00_FETCH_CURSOR_SECTION();
            }

            /*" -473- IF AC-PRE-LIBERA NOT EQUAL ZEROS */

            if (AREA_DE_WORK.AC_PRE_LIBERA != 00)
            {

                /*" -474- MOVE AC-PRE-LIBERA TO SAI-TOTAL-LIBERACAO */
                _.Move(AREA_DE_WORK.AC_PRE_LIBERA, AREA_DE_WORK.SAI_TOTAL.SAI_TOTAL_LIBERACAO);

                /*" -475- WRITE REG-VA0134B FROM SAI-TOTAL AFTER 1 */
                _.Move(AREA_DE_WORK.SAI_TOTAL.GetMoveValues(), REG_VA0134B);

                SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

                /*" -476- WRITE REG-VA0134B FROM LC-TRAFIM AFTER 1 */
                _.Move(AREA_DE_WORK.LC_TRAFIM.GetMoveValues(), REG_VA0134B);

                SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

                /*" -478- END-IF. */
            }


            /*" -478- PERFORM R0000-90-FINALIZA. */

            R0000_90_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0000-90-FINALIZA-SECTION */
        private void R0000_90_FINALIZA_SECTION()
        {
            /*" -488- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -488- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -493- DISPLAY ' ' . */
            _.Display($" ");

            /*" -495- CLOSE SAI0134B. */
            SAI0134B.Close();

            /*" -496- DISPLAY '*' . */
            _.Display($"*");

            /*" -497- DISPLAY '***SI0134B - TERMINO NORMAL***' . */
            _.Display($"***SI0134B - TERMINO NORMAL***");

            /*" -498- DISPLAY 'LIDOS TABELAS       - ' AC-LIDOS. */
            _.Display($"LIDOS TABELAS       - {AREA_DE_WORK.AC_LIDOS}");

            /*" -499- DISPLAY 'GRAVADOS NO ARQUIVO - ' AC-GRAVADOS. */
            _.Display($"GRAVADOS NO ARQUIVO - {AREA_DE_WORK.AC_GRAVADOS}");

            /*" -501- DISPLAY '*' . */
            _.Display($"*");

            /*" -501- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-SECTION */
        private void R0900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -511- MOVE 'R0900' TO WNR-EXEC-SQL. */
            _.Move("R0900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -561- PERFORM R0900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R0900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -563- PERFORM R0900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R0900_00_DECLARE_CURSOR_DB_OPEN_1();

            /*" -566- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -567- DISPLAY 'PROBLEMA NO CURSOR SINISTRO.' */
                _.Display($"PROBLEMA NO CURSOR SINISTRO.");

                /*" -568- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -568- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R0900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -561- EXEC SQL DECLARE SINISTRO CURSOR FOR SELECT T2.RAMO, T2.NUM_APOLICE, T2.COD_SUBGRUPO, T2.NUM_CERTIFICADO, T1.COD_USUARIO, T1.VAL_OPERACAO, T1.DATA_MOVIMENTO, T1.DATA_LIM_CORRECAO, T1.NUM_APOL_SINISTRO, T1.COD_OPERACAO, T1.OCORR_HISTORICO FROM SEGUROS.SINISTRO_HISTORICO T1, SEGUROS.SINISTRO_MESTRE T2, SEGUROS.GE_OPERACAO T3 WHERE (T1.NUM_APOL_SINISTRO BETWEEN 0104800000000 AND 0104899999999 OR T1.NUM_APOL_SINISTRO BETWEEN 0106000000000 AND 0106099999999 OR T1.NUM_APOL_SINISTRO BETWEEN 0107000000000 AND 0107099999999 OR T1.NUM_APOL_SINISTRO BETWEEN 0106600000000 AND 0106699999999 OR T1.NUM_APOL_SINISTRO BETWEEN 0106100000000 AND 0106199999999 OR T1.NUM_APOL_SINISTRO BETWEEN 0106500000000 AND 0106599999999 OR T1.NUM_APOL_SINISTRO BETWEEN 0106800000000 AND 0106899999999 OR T1.NUM_APOL_SINISTRO BETWEEN 0107700000000 AND 0107799999999 OR T1.NUM_APOL_SINISTRO BETWEEN 0109300000000 AND 0109399999999 OR T1.NUM_APOL_SINISTRO BETWEEN 1400000000000 AND 1409999999999 ) AND T2.NUM_APOL_SINISTRO = T1.NUM_APOL_SINISTRO AND T1.SIT_REGISTRO = '0' AND T1.COD_OPERACAO = T3.COD_OPERACAO AND T3.IDE_SISTEMA = 'SI' AND T3.FUNCAO_OPERACAO IN ( 'PRE' , 'JPIND' , 'JPDP' ) AND T1.DATA_MOVIMENTO > '2000-01-01' ORDER BY T2.RAMO, T1.COD_USUARIO, T1.VAL_OPERACAO WITH UR END-EXEC. */
            SINISTRO = new SI0134B_SINISTRO(false);
            string GetQuery_SINISTRO()
            {
                var query = @$"SELECT T2.RAMO
							, 
							T2.NUM_APOLICE
							, 
							T2.COD_SUBGRUPO
							, 
							T2.NUM_CERTIFICADO
							, 
							T1.COD_USUARIO
							, 
							T1.VAL_OPERACAO
							, 
							T1.DATA_MOVIMENTO
							, 
							T1.DATA_LIM_CORRECAO
							, 
							T1.NUM_APOL_SINISTRO
							, 
							T1.COD_OPERACAO
							, 
							T1.OCORR_HISTORICO 
							FROM SEGUROS.SINISTRO_HISTORICO T1
							, 
							SEGUROS.SINISTRO_MESTRE T2
							, 
							SEGUROS.GE_OPERACAO T3 
							WHERE 
							(T1.NUM_APOL_SINISTRO BETWEEN 
							0104800000000 AND 0104899999999 OR 
							T1.NUM_APOL_SINISTRO BETWEEN 
							0106000000000 AND 0106099999999 OR 
							T1.NUM_APOL_SINISTRO BETWEEN 
							0107000000000 AND 0107099999999 OR 
							T1.NUM_APOL_SINISTRO BETWEEN 
							0106600000000 AND 0106699999999 OR 
							T1.NUM_APOL_SINISTRO BETWEEN 
							0106100000000 AND 0106199999999 OR 
							T1.NUM_APOL_SINISTRO BETWEEN 
							0106500000000 AND 0106599999999 OR 
							T1.NUM_APOL_SINISTRO BETWEEN 
							0106800000000 AND 0106899999999 OR 
							T1.NUM_APOL_SINISTRO BETWEEN 
							0107700000000 AND 0107799999999 OR 
							T1.NUM_APOL_SINISTRO BETWEEN 
							0109300000000 AND 0109399999999 OR 
							T1.NUM_APOL_SINISTRO BETWEEN 
							1400000000000 AND 1409999999999 
							) 
							AND T2.NUM_APOL_SINISTRO = T1.NUM_APOL_SINISTRO 
							AND T1.SIT_REGISTRO = '0' 
							AND T1.COD_OPERACAO = T3.COD_OPERACAO 
							AND T3.IDE_SISTEMA = 'SI' 
							AND T3.FUNCAO_OPERACAO IN ( 'PRE'
							, 'JPIND'
							, 'JPDP' ) 
							AND T1.DATA_MOVIMENTO > '2000-01-01' 
							ORDER BY T2.RAMO
							, T1.COD_USUARIO
							, T1.VAL_OPERACAO";

                return query;
            }
            SINISTRO.GetQueryEvent += GetQuery_SINISTRO;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-OPEN-1 */
        public void R0900_00_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -563- EXEC SQL OPEN SINISTRO END-EXEC. */

            SINISTRO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-SECTION */
        private void R0910_00_FETCH_CURSOR_SECTION()
        {
            /*" -581- MOVE 'R0910' TO WNR-EXEC-SQL. */
            _.Move("R0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -594- PERFORM R0910_00_FETCH_CURSOR_DB_FETCH_1 */

            R0910_00_FETCH_CURSOR_DB_FETCH_1();

            /*" -597- IF SQLCODE NOT EQUAL ZEROS AND NOT EQUAL 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -598- DISPLAY ' PROBLEMAS NO FETCH DA SINISTRO' */
                _.Display($" PROBLEMAS NO FETCH DA SINISTRO");

                /*" -599- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -601- END-IF */
            }


            /*" -602- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -602- PERFORM R0910_00_FETCH_CURSOR_DB_CLOSE_1 */

                R0910_00_FETCH_CURSOR_DB_CLOSE_1();

                /*" -604- MOVE 'S' TO WFIM-SINISHIS */
                _.Move("S", AREA_DE_WORK.WFIM_SINISHIS);

                /*" -605- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -607- END-IF. */
            }


            /*" -609- ADD 1 TO AC-LIDOS. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

            /*" -610- IF SINISHIS-VAL-OPERACAO = 000000,00 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO == 000000.00)
            {

                /*" -611- GO TO R0910-00-FETCH-CURSOR */
                new Task(() => R0910_00_FETCH_CURSOR_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -613- END-IF. */
            }


            /*" -613- PERFORM R1000-00-PROCESSA-SINISHIS. */

            R1000_00_PROCESSA_SINISHIS_SECTION();

        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-FETCH-1 */
        public void R0910_00_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -594- EXEC SQL FETCH SINISTRO INTO :SINISMES-RAMO, :SINISMES-NUM-APOLICE, :SINISMES-COD-SUBGRUPO, :SINISMES-NUM-CERTIFICADO, :SINISHIS-COD-USUARIO, :SINISHIS-VAL-OPERACAO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-DATA-LIM-CORRECAO, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-COD-OPERACAO, :SINISHIS-OCORR-HISTORICO END-EXEC. */

            if (SINISTRO.Fetch())
            {
                _.Move(SINISTRO.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(SINISTRO.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(SINISTRO.SINISMES_COD_SUBGRUPO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO);
                _.Move(SINISTRO.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
                _.Move(SINISTRO.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
                _.Move(SINISTRO.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(SINISTRO.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(SINISTRO.SINISHIS_DATA_LIM_CORRECAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO);
                _.Move(SINISTRO.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(SINISTRO.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(SINISTRO.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-CLOSE-1 */
        public void R0910_00_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -602- EXEC SQL CLOSE SINISTRO END-EXEC */

            SINISTRO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SINISHIS-SECTION */
        private void R1000_00_PROCESSA_SINISHIS_SECTION()
        {
            /*" -628- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -630- MOVE ZEROS TO WVAL-ALCADA-DE WVAL-ALCADA-ATE */
            _.Move(0, AREA_DE_WORK.WVAL_ALCADA_DE, AREA_DE_WORK.WVAL_ALCADA_ATE);

            /*" -632- PERFORM UNTIL WVAL-ALCADA-ATE GREATER OR EQUAL SINISHIS-VAL-OPERACAO */

            while (!(AREA_DE_WORK.WVAL_ALCADA_ATE >= SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO))
            {

                /*" -633- IF SINISHIS-VAL-OPERACAO < 50000,01 */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO < 50000.01)
                {

                    /*" -634- MOVE 50000,00 TO WVAL-ALCADA-ATE */
                    _.Move(50000.00, AREA_DE_WORK.WVAL_ALCADA_ATE);

                    /*" -635- ELSE */
                }
                else
                {


                    /*" -636- IF SINISHIS-VAL-OPERACAO < 100000,01 */

                    if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO < 100000.01)
                    {

                        /*" -637- MOVE 50000,00 TO WVAL-ALCADA-DE */
                        _.Move(50000.00, AREA_DE_WORK.WVAL_ALCADA_DE);

                        /*" -638- MOVE 100000,00 TO WVAL-ALCADA-ATE */
                        _.Move(100000.00, AREA_DE_WORK.WVAL_ALCADA_ATE);

                        /*" -639- ELSE */
                    }
                    else
                    {


                        /*" -640- IF SINISHIS-VAL-OPERACAO > WVAL-ALCADA-ATE */

                        if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO > AREA_DE_WORK.WVAL_ALCADA_ATE)
                        {

                            /*" -641- MOVE WVAL-ALCADA-ATE TO WVAL-ALCADA-DE */
                            _.Move(AREA_DE_WORK.WVAL_ALCADA_ATE, AREA_DE_WORK.WVAL_ALCADA_DE);

                            /*" -642- ADD 100000,00 TO WVAL-ALCADA-ATE */
                            AREA_DE_WORK.WVAL_ALCADA_ATE.Value = AREA_DE_WORK.WVAL_ALCADA_ATE + 100000.00;

                            /*" -643- END-IF */
                        }


                        /*" -644- END-IF */
                    }


                    /*" -645- END-IF */
                }


                /*" -646- END-PERFORM */
            }

            /*" -648- ADD 0,01 TO WVAL-ALCADA-DE */
            AREA_DE_WORK.WVAL_ALCADA_DE.Value = AREA_DE_WORK.WVAL_ALCADA_DE + 0.01;

            /*" -649- MOVE SINISHIS-COD-USUARIO TO WUSUA-ATU. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, AREA_DE_WORK.WXAV_Q_RAM_USU_ATU.WUSUA_ATU);

            /*" -651- MOVE SINISMES-RAMO TO WRAMO-ATU. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, AREA_DE_WORK.WXAV_Q_RAM_USU_ATU.WRAMO_ATU);

            /*" -652- IF WVAL-ALCADA-DE NOT EQUAL WVAL-ALCADA-DE-ANT */

            if (AREA_DE_WORK.WVAL_ALCADA_DE != AREA_DE_WORK.WVAL_ALCADA_DE_ANT)
            {

                /*" -653- IF AC-PRE-LIBERA NOT EQUAL ZEROS */

                if (AREA_DE_WORK.AC_PRE_LIBERA != 00)
                {

                    /*" -654- MOVE AC-PRE-LIBERA TO SAI-TOTAL-LIBERACAO */
                    _.Move(AREA_DE_WORK.AC_PRE_LIBERA, AREA_DE_WORK.SAI_TOTAL.SAI_TOTAL_LIBERACAO);

                    /*" -655- WRITE REG-VA0134B FROM SAI-TOTAL AFTER 1 */
                    _.Move(AREA_DE_WORK.SAI_TOTAL.GetMoveValues(), REG_VA0134B);

                    SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

                    /*" -656- WRITE REG-VA0134B FROM LC-TRAFIM AFTER 1 */
                    _.Move(AREA_DE_WORK.LC_TRAFIM.GetMoveValues(), REG_VA0134B);

                    SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

                    /*" -657- MOVE ZEROS TO AC-PRE-LIBERA */
                    _.Move(0, AREA_DE_WORK.AC_PRE_LIBERA);

                    /*" -658- END-IF */
                }


                /*" -659- MOVE WVAL-ALCADA-DE TO CAB3-VALOR-DE WVAL-ALCADA-DE-ANT */
                _.Move(AREA_DE_WORK.WVAL_ALCADA_DE, AREA_DE_WORK.CAB3.CAB3_VALOR_DE, AREA_DE_WORK.WVAL_ALCADA_DE_ANT);

                /*" -660- MOVE WVAL-ALCADA-ATE TO CAB3-VALOR-ATE */
                _.Move(AREA_DE_WORK.WVAL_ALCADA_ATE, AREA_DE_WORK.CAB3.CAB3_VALOR_ATE);

                /*" -661- MOVE SINISHIS-COD-USUARIO TO WUSUA-ANT */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, AREA_DE_WORK.WXAV_Q_RAM_USU_ANT.WUSUA_ANT);

                /*" -662- MOVE SINISMES-RAMO TO WRAMO-ANT */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, AREA_DE_WORK.WXAV_Q_RAM_USU_ANT.WRAMO_ANT);

                /*" -663- PERFORM R1100-00-IMPRIMIR-CABECALHO */

                R1100_00_IMPRIMIR_CABECALHO_SECTION();

                /*" -664- ELSE */
            }
            else
            {


                /*" -665- IF WXAV-Q-RAM-USU-ATU NOT EQUAL WXAV-Q-RAM-USU-ANT */

                if (AREA_DE_WORK.WXAV_Q_RAM_USU_ATU != AREA_DE_WORK.WXAV_Q_RAM_USU_ANT)
                {

                    /*" -666- IF AC-PRE-LIBERA NOT EQUAL ZEROS */

                    if (AREA_DE_WORK.AC_PRE_LIBERA != 00)
                    {

                        /*" -667- MOVE AC-PRE-LIBERA TO SAI-TOTAL-LIBERACAO */
                        _.Move(AREA_DE_WORK.AC_PRE_LIBERA, AREA_DE_WORK.SAI_TOTAL.SAI_TOTAL_LIBERACAO);

                        /*" -668- WRITE REG-VA0134B FROM SAI-TOTAL AFTER 1 */
                        _.Move(AREA_DE_WORK.SAI_TOTAL.GetMoveValues(), REG_VA0134B);

                        SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

                        /*" -669- WRITE REG-VA0134B FROM LC-TRAFIM AFTER 1 */
                        _.Move(AREA_DE_WORK.LC_TRAFIM.GetMoveValues(), REG_VA0134B);

                        SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

                        /*" -670- MOVE ZEROS TO AC-PRE-LIBERA */
                        _.Move(0, AREA_DE_WORK.AC_PRE_LIBERA);

                        /*" -671- END-IF */
                    }


                    /*" -672- MOVE SINISHIS-COD-USUARIO TO WUSUA-ANT */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, AREA_DE_WORK.WXAV_Q_RAM_USU_ANT.WUSUA_ANT);

                    /*" -673- MOVE SINISMES-RAMO TO WRAMO-ANT */
                    _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, AREA_DE_WORK.WXAV_Q_RAM_USU_ANT.WRAMO_ANT);

                    /*" -674- PERFORM R1100-00-IMPRIMIR-CABECALHO */

                    R1100_00_IMPRIMIR_CABECALHO_SECTION();

                    /*" -675- ELSE */
                }
                else
                {


                    /*" -676- IF AC-LINHAS GREATER 56 */

                    if (AREA_DE_WORK.AC_LINHAS > 56)
                    {

                        /*" -677- IF AC-LINHAS NOT EQUAL 80 */

                        if (AREA_DE_WORK.AC_LINHAS != 80)
                        {

                            /*" -678- WRITE REG-VA0134B FROM LC-TRACONTINUA AFTER 1 */
                            _.Move(AREA_DE_WORK.LC_TRACONTINUA.GetMoveValues(), REG_VA0134B);

                            SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

                            /*" -679- END-IF */
                        }


                        /*" -680- PERFORM R1100-00-IMPRIMIR-CABECALHO */

                        R1100_00_IMPRIMIR_CABECALHO_SECTION();

                        /*" -681- END-IF */
                    }


                    /*" -682- END-IF */
                }


                /*" -684- END-IF. */
            }


            /*" -686- COMPUTE AC-PRE-LIBERA = SINISHIS-VAL-OPERACAO + AC-PRE-LIBERA. */
            AREA_DE_WORK.AC_PRE_LIBERA.Value = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO + AREA_DE_WORK.AC_PRE_LIBERA;

            /*" -689- COMPUTE AC-PRE-LIBERA-TOT = SINISHIS-VAL-OPERACAO + AC-PRE-LIBERA-TOT. */
            AREA_DE_WORK.AC_PRE_LIBERA_TOT.Value = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO + AREA_DE_WORK.AC_PRE_LIBERA_TOT;

            /*" -690- MOVE SINISHIS-NUM-APOL-SINISTRO TO SAI-NUM-APOL-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.SAI.SAI_NUM_APOL_SINISTRO);

            /*" -691- MOVE SINISHIS-DATA-MOVIMENTO TO WS-DTH-DETALHE. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, AREA_DE_WORK.WS_DTH_DETALHE);

            /*" -692- MOVE WS-DETALHE-ANO TO WS-DETALHE-ANO-I. */
            _.Move(AREA_DE_WORK.WS_DTH_DETALHE.WS_DETALHE_ANO, AREA_DE_WORK.WS_DTH_DETALHE_I.WS_DETALHE_ANO_I);

            /*" -693- MOVE WS-DETALHE-DIA TO WS-DETALHE-DIA-I. */
            _.Move(AREA_DE_WORK.WS_DTH_DETALHE.WS_DETALHE_DIA, AREA_DE_WORK.WS_DTH_DETALHE_I.WS_DETALHE_DIA_I);

            /*" -694- MOVE WS-DETALHE-MES TO WS-DETALHE-MES-I. */
            _.Move(AREA_DE_WORK.WS_DTH_DETALHE.WS_DETALHE_MES, AREA_DE_WORK.WS_DTH_DETALHE_I.WS_DETALHE_MES_I);

            /*" -695- MOVE WS-DTH-DETALHE-I TO SAI-DT-PRE-LIBE. */
            _.Move(AREA_DE_WORK.WS_DTH_DETALHE_I, AREA_DE_WORK.SAI.SAI_DT_PRE_LIBE);

            /*" -696- MOVE SINISHIS-DATA-LIM-CORRECAO TO WS-DTH-DETALHE. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO, AREA_DE_WORK.WS_DTH_DETALHE);

            /*" -697- MOVE WS-DETALHE-ANO TO WS-DETALHE-ANO-I. */
            _.Move(AREA_DE_WORK.WS_DTH_DETALHE.WS_DETALHE_ANO, AREA_DE_WORK.WS_DTH_DETALHE_I.WS_DETALHE_ANO_I);

            /*" -698- MOVE WS-DETALHE-DIA TO WS-DETALHE-DIA-I. */
            _.Move(AREA_DE_WORK.WS_DTH_DETALHE.WS_DETALHE_DIA, AREA_DE_WORK.WS_DTH_DETALHE_I.WS_DETALHE_DIA_I);

            /*" -699- MOVE WS-DETALHE-MES TO WS-DETALHE-MES-I. */
            _.Move(AREA_DE_WORK.WS_DTH_DETALHE.WS_DETALHE_MES, AREA_DE_WORK.WS_DTH_DETALHE_I.WS_DETALHE_MES_I);

            /*" -700- MOVE WS-DTH-DETALHE-I TO SAI-DT-PAGAMENTO. */
            _.Move(AREA_DE_WORK.WS_DTH_DETALHE_I, AREA_DE_WORK.SAI.SAI_DT_PAGAMENTO);

            /*" -702- MOVE SINISHIS-VAL-OPERACAO TO SAI-VALOR-INDENIZ. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.SAI.SAI_VALOR_INDENIZ);

            /*" -703- PERFORM R1102-00-SELECT-SEGURADO. */

            R1102_00_SELECT_SEGURADO_SECTION();

            /*" -705- PERFORM R1103-00-SELECT-NOM-SEGURADO. */

            R1103_00_SELECT_NOM_SEGURADO_SECTION();

            /*" -706- ADD 1 TO AC-LINHAS AC-GRAVADOS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;
            AREA_DE_WORK.AC_GRAVADOS.Value = AREA_DE_WORK.AC_GRAVADOS + 1;

            /*" -711- WRITE REG-VA0134B FROM SAI AFTER 1. R1000-99-SAIDA. */
            _.Move(AREA_DE_WORK.SAI.GetMoveValues(), REG_VA0134B);

            SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

            /*" -711- EXIT. */

            return;

        }

        [StopWatch]
        /*" R1100-00-IMPRIMIR-CABECALHO-SECTION */
        private void R1100_00_IMPRIMIR_CABECALHO_SECTION()
        {
            /*" -720- MOVE 'R1100' TO WNR-EXEC-SQL. */
            _.Move("R1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -721- ADD 1 TO AC-PAGINA. */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -722- MOVE AC-PAGINA TO CAB1-PAGINA. */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.CAB1.CAB1_PAGINA);

            /*" -723- MOVE SINISHIS-COD-USUARIO TO CAB3-ANALISTA. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, AREA_DE_WORK.CAB3.CAB3_ANALISTA);

            /*" -725- MOVE SINISMES-RAMO TO CAB3-RAMO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, AREA_DE_WORK.CAB3.CAB3_RAMO);

            /*" -726- PERFORM R1101-00-SELECT-USUARIO. */

            R1101_00_SELECT_USUARIO_SECTION();

            /*" -728- MOVE USUARIOS-NOME-USUARIO TO CAB3-NOME-ANALISTA. */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, AREA_DE_WORK.CAB3.CAB3_NOME_ANALISTA);

            /*" -729- WRITE REG-VA0134B FROM CAB1 AFTER PAGE. */
            _.Move(AREA_DE_WORK.CAB1.GetMoveValues(), REG_VA0134B);

            SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

            /*" -730- WRITE REG-VA0134B FROM CAB2 AFTER 1. */
            _.Move(AREA_DE_WORK.CAB2.GetMoveValues(), REG_VA0134B);

            SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

            /*" -731- WRITE REG-VA0134B FROM LC-TRACO AFTER 1. */
            _.Move(AREA_DE_WORK.LC_TRACO.GetMoveValues(), REG_VA0134B);

            SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

            /*" -732- WRITE REG-VA0134B FROM CAB3 AFTER 1. */
            _.Move(AREA_DE_WORK.CAB3.GetMoveValues(), REG_VA0134B);

            SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

            /*" -733- WRITE REG-VA0134B FROM CAB4 AFTER 1. */
            _.Move(AREA_DE_WORK.CAB4.GetMoveValues(), REG_VA0134B);

            SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

            /*" -734- WRITE REG-VA0134B FROM LC-TRACO AFTER 1. */
            _.Move(AREA_DE_WORK.LC_TRACO.GetMoveValues(), REG_VA0134B);

            SAI0134B.Write(REG_VA0134B.GetMoveValues().ToString());

            /*" -734- MOVE 11 TO AC-LINHAS. */
            _.Move(11, AREA_DE_WORK.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_00_SAIDA*/

        [StopWatch]
        /*" R1101-00-SELECT-USUARIO-SECTION */
        private void R1101_00_SELECT_USUARIO_SECTION()
        {
            /*" -746- MOVE 'R1101' TO WNR-EXEC-SQL. */
            _.Move("R1101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -748- MOVE 'SIM' TO WTEM-USUARIO. */
            _.Move("SIM", AREA_DE_WORK.WTEM_USUARIO);

            /*" -759- PERFORM R1101_00_SELECT_USUARIO_DB_SELECT_1 */

            R1101_00_SELECT_USUARIO_DB_SELECT_1();

            /*" -762- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -763- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -765- MOVE '** ANALISTA NAO ENCONTRADO **' TO USUARIOS-NOME-USUARIO */
                    _.Move("** ANALISTA NAO ENCONTRADO **", USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);

                    /*" -766- MOVE 'SIM' TO WTEM-USUARIO */
                    _.Move("SIM", AREA_DE_WORK.WTEM_USUARIO);

                    /*" -767- ELSE */
                }
                else
                {


                    /*" -768- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                    /*" -769- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -770- DISPLAY '* ERRO NA R1101-00-SELECT-USUARIO' */
                    _.Display($"* ERRO NA R1101-00-SELECT-USUARIO");

                    /*" -771- DISPLAY '* WSQLCODE = ' WSQLCODE */
                    _.Display($"* WSQLCODE = {AREA_DE_WORK.WABEND.WSQLCODE}");

                    /*" -773- DISPLAY '* COD-USUARIO       = ' SINISHIS-COD-USUARIO */
                    _.Display($"* COD-USUARIO       = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO}");

                    /*" -774- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -775- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -776- END-IF */
                }


                /*" -776- END-IF. */
            }


        }

        [StopWatch]
        /*" R1101-00-SELECT-USUARIO-DB-SELECT-1 */
        public void R1101_00_SELECT_USUARIO_DB_SELECT_1()
        {
            /*" -759- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :SINISHIS-COD-USUARIO WITH UR END-EXEC. */

            var r1101_00_SELECT_USUARIO_DB_SELECT_1_Query1 = new R1101_00_SELECT_USUARIO_DB_SELECT_1_Query1()
            {
                SINISHIS_COD_USUARIO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO.ToString(),
            };

            var executed_1 = R1101_00_SELECT_USUARIO_DB_SELECT_1_Query1.Execute(r1101_00_SELECT_USUARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_NOME_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1101_99_SAIDA*/

        [StopWatch]
        /*" R1102-00-SELECT-SEGURADO-SECTION */
        private void R1102_00_SELECT_SEGURADO_SECTION()
        {
            /*" -788- MOVE 'R1102' TO WNR-EXEC-SQL. */
            _.Move("R1102", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -790- MOVE 'SIM' TO WTEM-USUARIO. */
            _.Move("SIM", AREA_DE_WORK.WTEM_USUARIO);

            /*" -803- PERFORM R1102_00_SELECT_SEGURADO_DB_SELECT_1 */

            R1102_00_SELECT_SEGURADO_DB_SELECT_1();

            /*" -806- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -807- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -808- MOVE SPACES TO SAI-TIPO-RECIBO */
                    _.Move("", AREA_DE_WORK.SAI.SAI_TIPO_RECIBO);

                    /*" -809- ELSE */
                }
                else
                {


                    /*" -810- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                    /*" -811- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -812- DISPLAY '* ERRO NA R1102-00 SEGUROS.SINISTRO_HABIT2' */
                    _.Display($"* ERRO NA R1102-00 SEGUROS.SINISTRO_HABIT2");

                    /*" -813- DISPLAY '* WSQLCODE = ' WSQLCODE */
                    _.Display($"* WSQLCODE = {AREA_DE_WORK.WABEND.WSQLCODE}");

                    /*" -815- DISPLAY '* COD-USUARIO       = ' SIHABIT2-CODIGO-CH1-REC1 */
                    _.Display($"* COD-USUARIO       = {SIHABIT2.DCLSINISTRO_HABIT2.SIHABIT2_CODIGO_CH1_REC1}");

                    /*" -816- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -817- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -818- END-IF */
                }


                /*" -819- ELSE */
            }
            else
            {


                /*" -829- PERFORM R1102_00_SELECT_SEGURADO_DB_SELECT_2 */

                R1102_00_SELECT_SEGURADO_DB_SELECT_2();

                /*" -831- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -832- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -833- MOVE SPACES TO SAI-TIPO-RECIBO */
                        _.Move("", AREA_DE_WORK.SAI.SAI_TIPO_RECIBO);

                        /*" -834- ELSE */
                    }
                    else
                    {


                        /*" -835- MOVE SQLCODE TO WSQLCODE */
                        _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                        /*" -836- DISPLAY '******************************************' */
                        _.Display($"******************************************");

                        /*" -837- DISPLAY '* ERRO NA R1102-00 SEGUROS.AGRUPA_TABELAS_' */
                        _.Display($"* ERRO NA R1102-00 SEGUROS.AGRUPA_TABELAS_");

                        /*" -838- DISPLAY '* WSQLCODE = ' WSQLCODE */
                        _.Display($"* WSQLCODE = {AREA_DE_WORK.WABEND.WSQLCODE}");

                        /*" -840- DISPLAY '* COD-USUARIO       = ' SIHABIT2-CODIGO-CH1-REC1 */
                        _.Display($"* COD-USUARIO       = {SIHABIT2.DCLSINISTRO_HABIT2.SIHABIT2_CODIGO_CH1_REC1}");

                        /*" -841- DISPLAY '******************************************' */
                        _.Display($"******************************************");

                        /*" -842- PERFORM R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION();

                        /*" -843- END-IF */
                    }


                    /*" -844- ELSE */
                }
                else
                {


                    /*" -845- MOVE AGTABCH1-DESCRICAO TO SAI-TIPO-RECIBO */
                    _.Move(AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_DESCRICAO, AREA_DE_WORK.SAI.SAI_TIPO_RECIBO);

                    /*" -846- END-IF */
                }


                /*" -846- END-IF. */
            }


        }

        [StopWatch]
        /*" R1102-00-SELECT-SEGURADO-DB-SELECT-1 */
        public void R1102_00_SELECT_SEGURADO_DB_SELECT_1()
        {
            /*" -803- EXEC SQL SELECT CODIGO_CH1_REC1 INTO :SIHABIT2-CODIGO-CH1-REC1 FROM SEGUROS.SINISTRO_HABIT2 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO WITH UR END-EXEC. */

            var r1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1 = new R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1.Execute(r1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIHABIT2_CODIGO_CH1_REC1, SIHABIT2.DCLSINISTRO_HABIT2.SIHABIT2_CODIGO_CH1_REC1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1102_99_SAIDA*/

        [StopWatch]
        /*" R1102-00-SELECT-SEGURADO-DB-SELECT-2 */
        public void R1102_00_SELECT_SEGURADO_DB_SELECT_2()
        {
            /*" -829- EXEC SQL SELECT DESCRICAO INTO :AGTABCH1-DESCRICAO FROM SEGUROS.AGRUPA_TABELAS_CH1 WHERE IDTAB = 14 AND CODIGO_CH1 = :SIHABIT2-CODIGO-CH1-REC1 WITH UR END-EXEC */

            var r1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1 = new R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1()
            {
                SIHABIT2_CODIGO_CH1_REC1 = SIHABIT2.DCLSINISTRO_HABIT2.SIHABIT2_CODIGO_CH1_REC1.ToString(),
            };

            var executed_1 = R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1.Execute(r1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGTABCH1_DESCRICAO, AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_DESCRICAO);
            }


        }

        [StopWatch]
        /*" R1103-00-SELECT-NOM-SEGURADO-SECTION */
        private void R1103_00_SELECT_NOM_SEGURADO_SECTION()
        {
            /*" -858- MOVE 'R1103' TO WNR-EXEC-SQL. */
            _.Move("R1103", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -867- PERFORM R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1 */

            R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1();

            /*" -870- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -871- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -872- PERFORM R1104-00-SELECT-NOM-SEGURADO */

                    R1104_00_SELECT_NOM_SEGURADO_SECTION();

                    /*" -873- ELSE */
                }
                else
                {


                    /*" -874- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                    /*" -875- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -876- DISPLAY '* ERRO NA R1103-00 SEGUROS.SINISTRO_HABIT0' */
                    _.Display($"* ERRO NA R1103-00 SEGUROS.SINISTRO_HABIT0");

                    /*" -877- DISPLAY '* WSQLCODE = ' WSQLCODE */
                    _.Display($"* WSQLCODE = {AREA_DE_WORK.WABEND.WSQLCODE}");

                    /*" -879- DISPLAY '* NUM_APOL_SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"* NUM_APOL_SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -880- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -881- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -882- END-IF */
                }


                /*" -883- ELSE */
            }
            else
            {


                /*" -884- MOVE SINIHAB1-NOME-SEGURADO TO SAI-SEGURADO */
                _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO, AREA_DE_WORK.SAI.SAI_SEGURADO);

                /*" -884- END-IF. */
            }


        }

        [StopWatch]
        /*" R1103-00-SELECT-NOM-SEGURADO-DB-SELECT-1 */
        public void R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1()
        {
            /*" -867- EXEC SQL SELECT NOME_SEGURADO INTO :SINIHAB1-NOME-SEGURADO FROM SEGUROS.SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 = new R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1.Execute(r1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIHAB1_NOME_SEGURADO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1103_99_SAIDA*/

        [StopWatch]
        /*" R1104-00-SELECT-NOM-SEGURADO-SECTION */
        private void R1104_00_SELECT_NOM_SEGURADO_SECTION()
        {
            /*" -898- MOVE 'R1104' TO WNR-EXEC-SQL. */
            _.Move("R1104", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -914- PERFORM R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1 */

            R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1();

            /*" -917- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -918- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -919- PERFORM R1105-00-SELECT-NOM-SEGURADO */

                    R1105_00_SELECT_NOM_SEGURADO_SECTION();

                    /*" -920- ELSE */
                }
                else
                {


                    /*" -921- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                    /*" -922- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -923- DISPLAY '* ERRO NA R1104-00 SEGUROS.APOLICE_CREDITO' */
                    _.Display($"* ERRO NA R1104-00 SEGUROS.APOLICE_CREDITO");

                    /*" -924- DISPLAY '* WSQLCODE = ' WSQLCODE */
                    _.Display($"* WSQLCODE = {AREA_DE_WORK.WABEND.WSQLCODE}");

                    /*" -926- DISPLAY '* NUM_APOL_SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"* NUM_APOL_SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -927- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -928- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -929- END-IF */
                }


                /*" -930- ELSE */
            }
            else
            {


                /*" -931- MOVE APOLICRE-PROPRIET TO SAI-SEGURADO */
                _.Move(APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET, AREA_DE_WORK.SAI.SAI_SEGURADO);

                /*" -931- END-IF. */
            }


        }

        [StopWatch]
        /*" R1104-00-SELECT-NOM-SEGURADO-DB-SELECT-1 */
        public void R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1()
        {
            /*" -914- EXEC SQL SELECT PROPRIET INTO :APOLICRE-PROPRIET FROM SEGUROS.APOLICE_CREDITO TB1, SEGUROS.SINISTRO_CRED_INT TB2 WHERE TB2.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND TB2.COD_SUREG = TB1.COD_SUREG AND TB2.COD_AGENCIA = TB1.COD_AGENCIA AND TB2.COD_OPERACAO = TB1.COD_OPERACAO AND TB2.NUM_CONTRATO = TB1.NUM_CONTRATO AND TB2.CONTRATO_DIGITO = TB1.CONTRATO_DIGITO FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 = new R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1.Execute(r1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICRE_PROPRIET, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1104_01_SAIDA*/

        [StopWatch]
        /*" R1105-00-SELECT-NOM-SEGURADO-SECTION */
        private void R1105_00_SELECT_NOM_SEGURADO_SECTION()
        {
            /*" -944- MOVE 'R1105' TO WNR-EXEC-SQL. */
            _.Move("R1105", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -963- PERFORM R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1 */

            R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1();

            /*" -966- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -967- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -969- MOVE '**** SEGURADO NAO FOI LOCALIZADO ****' TO SAI-SEGURADO */
                    _.Move("**** SEGURADO NAO FOI LOCALIZADO ****", AREA_DE_WORK.SAI.SAI_SEGURADO);

                    /*" -970- ELSE */
                }
                else
                {


                    /*" -971- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                    /*" -972- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -973- DISPLAY '* ERRO NA R1105-00 SEGUROS.CLIENTES' */
                    _.Display($"* ERRO NA R1105-00 SEGUROS.CLIENTES");

                    /*" -974- DISPLAY '* WSQLCODE = ' WSQLCODE */
                    _.Display($"* WSQLCODE = {AREA_DE_WORK.WABEND.WSQLCODE}");

                    /*" -976- DISPLAY '* NUM_APOLICE = ' SINISMES-NUM-APOLICE */
                    _.Display($"* NUM_APOLICE = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                    /*" -978- DISPLAY '* COD_SUBGRUPO = ' SINISMES-COD-SUBGRUPO */
                    _.Display($"* COD_SUBGRUPO = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO}");

                    /*" -980- DISPLAY '* NUM_CERTIFICADO = ' SINISMES-NUM-CERTIFICADO */
                    _.Display($"* NUM_CERTIFICADO = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO}");

                    /*" -981- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -982- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -983- END-IF */
                }


                /*" -984- ELSE */
            }
            else
            {


                /*" -985- MOVE CLIENTES-NOME-RAZAO TO SAI-SEGURADO */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.SAI.SAI_SEGURADO);

                /*" -985- END-IF. */
            }


        }

        [StopWatch]
        /*" R1105-00-SELECT-NOM-SEGURADO-DB-SELECT-1 */
        public void R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1()
        {
            /*" -963- EXEC SQL SELECT TT1.NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.CLIENTES TT1, SEGUROS.SEGURADOS_VGAP TT2 WHERE TT2.NUM_APOLICE = :SINISMES-NUM-APOLICE AND TT2.COD_SUBGRUPO = :SINISMES-COD-SUBGRUPO AND TT2.NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO AND TT2.TIPO_SEGURADO = '1' AND TT2.COD_CLIENTE = TT1.COD_CLIENTE WITH UR END-EXEC. */

            var r1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 = new R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_CERTIFICADO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO.ToString(),
                SINISMES_COD_SUBGRUPO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO.ToString(),
                SINISMES_NUM_APOLICE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1.Execute(r1105_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1105_02_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -998- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1000- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1000- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1002- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1006- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1006- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_00_SAIDA*/

        [StopWatch]
        /*" M-0200-00-LE-SISTEMAS-SECTION */
        private void M_0200_00_LE_SISTEMAS_SECTION()
        {
            /*" -1024- PERFORM M_0200_00_LE_SISTEMAS_DB_SELECT_1 */

            M_0200_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -1027- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1028- DISPLAY 'PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"PROBLEMAS NO SELECT SISTEMAS");

                /*" -1030- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1032- MOVE SISTEMAS-DATA-MOV-ABERTO TO WHOST-DATA-FIM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WHOST_DATA_FIM);

            /*" -1033- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO WS-DT-INI10-AA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.WS_DT_INI10.WS_DT_INI10_AA);

            /*" -1034- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO WS-DT-INI10-MM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.WS_DT_INI10.WS_DT_INI10_MM);

            /*" -1036- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO WS-DT-INI10-DD. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.WS_DT_INI10.WS_DT_INI10_DD);

            /*" -1037- MOVE WHOST-DT-HOJE(1:4) TO WS-DT-HJ10-AA. */
            _.Move(WHOST_DT_HOJE.Substring(1, 4), AREA_DE_WORK.WS_DT_HJ10.WS_DT_HJ10_AA);

            /*" -1038- MOVE WHOST-DT-HOJE(6:2) TO WS-DT-HJ10-MM. */
            _.Move(WHOST_DT_HOJE.Substring(6, 2), AREA_DE_WORK.WS_DT_HJ10.WS_DT_HJ10_MM);

            /*" -1038- MOVE WHOST-DT-HOJE(9:2) TO WS-DT-HJ10-DD. */
            _.Move(WHOST_DT_HOJE.Substring(9, 2), AREA_DE_WORK.WS_DT_HJ10.WS_DT_HJ10_DD);

        }

        [StopWatch]
        /*" M-0200-00-LE-SISTEMAS-DB-SELECT-1 */
        public void M_0200_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -1024- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO - 12 MONTHS, CURRENT_DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :WHOST-DATA-INI, :WHOST-DT-HOJE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

            var m_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(m_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA_INI, WHOST_DATA_INI);
                _.Move(executed_1.WHOST_DT_HOJE, WHOST_DT_HOJE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_99_SAIDA*/
    }
}