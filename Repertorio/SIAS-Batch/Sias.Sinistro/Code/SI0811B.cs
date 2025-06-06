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
using Sias.Sinistro.DB2.SI0811B;

namespace Code
{
    public class SI0811B
    {
        public bool IsCall { get; set; }

        public SI0811B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI0811B                             *      */
        /*"      *   ANALISTA ............... BARAN / HEIDER                      *      */
        /*"      *   PROGRAMADOR ............ HEIDER                              *      */
        /*"      *   DATA CODIFICACAO ....... JUNHO / 1995                        *      */
        /*"      *   FUNCAO ................. DEMONSTRATIVO DE EXCEDENTE TECNICO  *      */
        /*"      *                            RELACAO DOS SINISTROS PENDENTES     *      */
        /*"      *                            NO PERIODO                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                             VIEW              ACESSO    *      */
        /*"      * SISTEMAS                           V1SISTEMA         INPUT     *      */
        /*"      * RELATORIOS                         V1RELATORIOS      I-O       *      */
        /*"      * MESTRE DE SINISTRO                 V0MESTSINI        INPUT     *      */
        /*"      * HISTORICO DO SINISTRO              V0HISTSINI        INPUT     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  *   VERSAO 03 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO BARAN 27/01/97 : NAO LER MAIS V0APOLICE E NAO RODAR  *      */
        /*"      *                            MAIS POR RAMO, APENAS POR APOLICE.  *      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO RILDO SICO - 21/09/2000 : REFORMULACAO LOGICA DO     *      */
        /*"      *                            PROGRAMA - PROCURAR RS001           *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 18/04/2005 - PRODEXTER                                         *      */
        /*"      * SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO E   *      */
        /*"      * PELA CHAMADA A SUB-ROTINAS DE CALCULO DO SINISTRO              *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RSI0811B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RSI0811B
        {
            get
            {
                _.Move(REG_SI0811B, _RSI0811B); VarBasis.RedefinePassValue(REG_SI0811B, _RSI0811B, REG_SI0811B); return _RSI0811B;
            }
        }
        /*"01                  REG-SI0811B.*/
        public SI0811B_REG_SI0811B REG_SI0811B { get; set; } = new SI0811B_REG_SI0811B();
        public class SI0811B_REG_SI0811B : VarBasis
        {
            /*"      05            LINHA              PIC  X(150).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V1SIST-DTCURRENT           PIC  X(010)  VALUE SPACES.*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  V0MEST-NUM-APOL-I          PIC S9(013)V USAGE COMP-3.*/
        public DoubleBasis V0MEST_NUM_APOL_I { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V"), 0);
        /*"77  V0MEST-NUM-APOL-F          PIC S9(013)V USAGE COMP-3.*/
        public DoubleBasis V0MEST_NUM_APOL_F { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V"), 0);
        /*"77  V0MEST-RAMO-I              PIC S9(004)  USAGE COMP.*/
        public IntBasis V0MEST_RAMO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0MEST-RAMO-F              PIC S9(004)  USAGE COMP.*/
        public IntBasis V0MEST_RAMO_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-DATA-INICIO          PIC  X(010).*/
        public StringBasis WHOST_DATA_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  AREA-DE-WORK.*/
        public SI0811B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0811B_AREA_DE_WORK();
        public class SI0811B_AREA_DE_WORK : VarBasis
        {
            /*"    05 W-VALOR-AVISADO       PIC S9(013)V9(2) VALUE +0 COMP-3.*/
            public DoubleBasis W_VALOR_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"    05 W-VALOR-PENDENTE      PIC S9(013)V9(2) VALUE +0 COMP-3.*/
            public DoubleBasis W_VALOR_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"    05 W-VALOR-PAGO-ANT-PER  PIC S9(013)V9(2) VALUE +0 COMP-3.*/
            public DoubleBasis W_VALOR_PAGO_ANT_PER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"    05 W-VALOR-PAGO-NO-PER   PIC S9(013)V9(2) VALUE +0 COMP-3.*/
            public DoubleBasis W_VALOR_PAGO_NO_PER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"    05 WCH-FINAL             PIC  X(001)      VALUE SPACES.*/
            public StringBasis WCH_FINAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05 WFIM-JOIN-HIST-MEST   PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_JOIN_HIST_MEST { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05 WFIM-V1RELATOR        PIC  X(003)      VALUE SPACES.*/
            public StringBasis WFIM_V1RELATOR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05 W-AC-LINHAS           PIC  9(002)      VALUE  80.*/
            public IntBasis W_AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"    05 W-AC-PAGINA           PIC  9(004)      VALUE  ZEROS.*/
            public IntBasis W_AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05 CH-CHAVE-ATU.*/
            public SI0811B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new SI0811B_CH_CHAVE_ATU();
            public class SI0811B_CH_CHAVE_ATU : VarBasis
            {
                /*"       10 W-APOLICE-ANT       PIC S9(013)      VALUE  +0 COMP-3.*/
                public IntBasis W_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"       10 W-SINISTRO-ANT      PIC S9(013)      VALUE  +0 COMP-3.*/
                public IntBasis W_SINISTRO_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"       10 W-NOVA-APOLICE      PIC  X(003)      VALUE SPACES.*/
                public StringBasis W_NOVA_APOLICE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05 W-AC-AVISADO           PIC S9(013)V9(5) VALUE +0  COMP-3.*/
            }
            public DoubleBasis W_AC_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"    05 W-AC-PENDEN            PIC S9(013)V9(5) VALUE +0  COMP-3.*/
            public DoubleBasis W_AC_PENDEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"    05 W-AC-VAL-OPERACAO      PIC S9(013)V9(5) VALUE +0  COMP-3.*/
            public DoubleBasis W_AC_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"    05 W-AC-PAGO-ANT          PIC S9(013)V9(5) VALUE +0  COMP-3.*/
            public DoubleBasis W_AC_PAGO_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"    05 W-AC-PAGO-PERI         PIC S9(013)V9(5) VALUE +0  COMP-3.*/
            public DoubleBasis W_AC_PAGO_PERI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"    05 W-TOTAL-PARCIAL.*/
            public SI0811B_W_TOTAL_PARCIAL W_TOTAL_PARCIAL { get; set; } = new SI0811B_W_TOTAL_PARCIAL();
            public class SI0811B_W_TOTAL_PARCIAL : VarBasis
            {
                /*"       07 W-TOT-AVISADO        PIC S9(013)V9(5) VALUE +0 COMP-3.*/
                public DoubleBasis W_TOT_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
                /*"       07 W-TOT-OPERACAO       PIC S9(013)V9(5) VALUE +0 COMP-3.*/
                public DoubleBasis W_TOT_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
                /*"       07 W-TOT-OPERACAO-ANT   PIC S9(013)V9(5) VALUE +0 COMP-3.*/
                public DoubleBasis W_TOT_OPERACAO_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
                /*"       07 W-TOT-OPERACAO-PERI  PIC S9(013)V9(5) VALUE +0 COMP-3.*/
                public DoubleBasis W_TOT_OPERACAO_PERI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
                /*"       07 W-TOT-PENDEN         PIC S9(013)V9(5) VALUE +0 COMP-3.*/
                public DoubleBasis W_TOT_PENDEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
                /*"    05 W-TOTAL-GERAL.*/
            }
            public SI0811B_W_TOTAL_GERAL W_TOTAL_GERAL { get; set; } = new SI0811B_W_TOTAL_GERAL();
            public class SI0811B_W_TOTAL_GERAL : VarBasis
            {
                /*"       07 W-TOT-GERAL-AVISADO      PIC S9(13)V9(5)                                               VALUE +0 COMP-3.*/
                public DoubleBasis W_TOT_GERAL_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
                /*"       07 W-TOT-GERAL-OPERACAO     PIC S9(13)V9(5)                                               VALUE +0 COMP-3.*/
                public DoubleBasis W_TOT_GERAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
                /*"       07 W-TOT-GERAL-OPERACAO-ANT PIC S9(13)V9(5)                                               VALUE +0 COMP-3.*/
                public DoubleBasis W_TOT_GERAL_OPERACAO_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
                /*"       07 W-TOT-GERAL-OPERACAO-PERI PIC S9(13)V9(5)                                               VALUE +0 COMP-3.*/
                public DoubleBasis W_TOT_GERAL_OPERACAO_PERI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
                /*"       07 W-TOT-GERAL-PENDEN       PIC S9(13)V9(5)                                               VALUE +0 COMP-3.*/
                public DoubleBasis W_TOT_GERAL_PENDEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(5)"), 5);
                /*"  05 W-COTACAO-HOJE              PIC S9(06)V9(9) VALUE +0 COMP-3*/
                public DoubleBasis W_COTACAO_HOJE { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(9)"), 9);
                /*"  05    DB2-DATA.*/
                public SI0811B_DB2_DATA DB2_DATA { get; set; } = new SI0811B_DB2_DATA();
                public class SI0811B_DB2_DATA : VarBasis
                {
                    /*"     10 DB2-ANO                  PIC  9(004)    VALUE ZEROS.*/
                    public IntBasis DB2_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10 FILLER                   PIC  X(001)    VALUE SPACE.*/
                    public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"     10 DB2-MES                  PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis DB2_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10 FILLER                   PIC  X(001)    VALUE SPACE.*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"     10 DB2-DIA                  PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis DB2_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"  05    EDIT-DATA.*/
                }
                public SI0811B_EDIT_DATA EDIT_DATA { get; set; } = new SI0811B_EDIT_DATA();
                public class SI0811B_EDIT_DATA : VarBasis
                {
                    /*"     10 EDIT-DIA                 PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis EDIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10 FILLER                   PIC  X(001)    VALUE '/'.*/
                    public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"     10 EDIT-MES                 PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis EDIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10 FILLER                   PIC  X(001)    VALUE '/'.*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"     10 EDIT-ANO                 PIC  9(004)    VALUE ZEROS.*/
                    public IntBasis EDIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"  05    SIST-HORA.*/
                }
                public SI0811B_SIST_HORA SIST_HORA { get; set; } = new SI0811B_SIST_HORA();
                public class SI0811B_SIST_HORA : VarBasis
                {
                    /*"     10 SIST-HH                  PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis SIST_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10 SIST-MM                  PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis SIST_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10 SIST-SS                  PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis SIST_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10 SIST-CC                  PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis SIST_CC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"  05    EDIT-HORA.*/
                }
                public SI0811B_EDIT_HORA EDIT_HORA { get; set; } = new SI0811B_EDIT_HORA();
                public class SI0811B_EDIT_HORA : VarBasis
                {
                    /*"     10 EDIT-HH                  PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis EDIT_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10 FILLER                   PIC  X(001)    VALUE ':'.*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                    /*"     10 EDIT-MM                  PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis EDIT_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10 FILLER                   PIC  X(001)    VALUE ':'.*/
                    public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                    /*"     10 EDIT-SS                  PIC  9(002)    VALUE ZEROS.*/
                    public IntBasis EDIT_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"01  W-MSG-ERROR.*/
                }
            }
        }
        public SI0811B_W_MSG_ERROR W_MSG_ERROR { get; set; } = new SI0811B_W_MSG_ERROR();
        public class SI0811B_W_MSG_ERROR : VarBasis
        {
            /*"    03 WSQLCODE3              PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03 WABEND.*/
            public SI0811B_WABEND WABEND { get; set; } = new SI0811B_WABEND();
            public class SI0811B_WABEND : VarBasis
            {
                /*"       05 FILLER              PIC  X(010) VALUE           ' SI0811B'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0811B");
                /*"       05 FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"       05 WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"       05 FILLER              PIC  X(017) VALUE            ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"       05 PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"       05 FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"       05 WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"       05 FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"       05 WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"       05 FILLER              PIC  X(014) VALUE            '    SQLCODE2= '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"       05 WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01  FILLER.*/
            }
        }
        public SI0811B_FILLER_12 FILLER_12 { get; set; } = new SI0811B_FILLER_12();
        public class SI0811B_FILLER_12 : VarBasis
        {
            /*"    05 LC01.*/
            public SI0811B_LC01 LC01 { get; set; } = new SI0811B_LC01();
            public class SI0811B_LC01 : VarBasis
            {
                /*"       10 LC01-RELATOR         PIC  X(010) VALUE 'SI0811B.1'.*/
                public StringBasis LC01_RELATOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0811B.1");
                /*"       10 FILLER               PIC  X(033) VALUE  SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"       10 LC01-EMPRESA         PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"       10 FILLER               PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"       10 FILLER               PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"       10 LC01-PAGINA          PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    05 LC02.*/
            }
            public SI0811B_LC02 LC02 { get; set; } = new SI0811B_LC02();
            public class SI0811B_LC02 : VarBasis
            {
                /*"       10 FILLER               PIC  X(010) VALUE 'SI0811B.1'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0811B.1");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(032) VALUE         'APURACAO DOS EXCEDENTES TECNICOS'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"APURACAO DOS EXCEDENTES TECNICOS");
                /*"       10 FILLER               PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"       10 FILLER               PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"       10 LC02-DATA            PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05 LC03.*/
            }
            public SI0811B_LC03 LC03 { get; set; } = new SI0811B_LC03();
            public class SI0811B_LC03 : VarBasis
            {
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(033) VALUE        'SINISTROS PENDENTES NO PERIODO - '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"SINISTROS PENDENTES NO PERIODO - ");
                /*"       10 LC03-DATA-INI        PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC03_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10 FILLER               PIC  X(003) VALUE ' A '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"       10 LC03-DATA-TER        PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC03_DATA_TER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10 FILLER               PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"       10 FILLER               PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"       10 LC03-HORA            PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    05 LC04.*/
            }
            public SI0811B_LC04 LC04 { get; set; } = new SI0811B_LC04();
            public class SI0811B_LC04 : VarBasis
            {
                /*"       10 FILLER               PIC  X(022) VALUE       'USUARIO SOLICITANTE - '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"USUARIO SOLICITANTE - ");
                /*"       10 LC04-CODUSU          PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC04_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"       10 FILLER               PIC  X(002) VALUE  SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"       10 FILLER               PIC  X(019) VALUE       'DATA SOLICITACAO - '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"DATA SOLICITACAO - ");
                /*"       10 LC04-DATA-SOLIC      PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC04_DATA_SOLIC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10 FILLER               PIC  X(039) VALUE  SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"");
                /*"       10 FILLER               PIC  X(021) VALUE                                  'FATORES EXPRESSOS EM '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"FATORES EXPRESSOS EM ");
                /*"       10 LC04-MOEDA           PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC04_MOEDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05 LC05.*/
            }
            public SI0811B_LC05 LC05 { get; set; } = new SI0811B_LC05();
            public class SI0811B_LC05 : VarBasis
            {
                /*"       10 FILLER               PIC  X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"    05 LC06.*/
            }
            public SI0811B_LC06 LC06 { get; set; } = new SI0811B_LC06();
            public class SI0811B_LC06 : VarBasis
            {
                /*"       10 FILLER               PIC  X(013) VALUE 'APOLICE'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(033) VALUE 'SEGURADO'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"SEGURADO");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(013) VALUE 'SINISTRO'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SINISTRO");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(010) VALUE 'DT AVISO'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT AVISO");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(014) VALUE                                       '   VLR AVISADO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   VLR AVISADO");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(014) VALUE                                       '    PAGO ANTES'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    PAGO ANTES");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(014) VALUE                                       '      PAGO NO'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"      PAGO NO");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(014) VALUE                                       '  VLR PENDENTE'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"  VLR PENDENTE");
                /*"    05 LC07.*/
            }
            public SI0811B_LC07 LC07 { get; set; } = new SI0811B_LC07();
            public class SI0811B_LC07 : VarBasis
            {
                /*"       10 FILLER               PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(033) VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(004) VALUE 'ATE '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"ATE ");
                /*"       10 LC07-DT-AVISO        PIC  X(010) VALUE SPACES.*/
                public StringBasis LC07_DT_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(004) VALUE ' DE '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" DE ");
                /*"       10 LC07-DT-PAG-ANT      PIC  X(010) VALUE SPACES.*/
                public StringBasis LC07_DT_PAG_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(014) VALUE                                       '      PERIODO'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"      PERIODO");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 FILLER               PIC  X(004) VALUE ' EM '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" EM ");
                /*"       10 LC07-DT-PEND         PIC  X(010) VALUE SPACES.*/
                public StringBasis LC07_DT_PEND { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05 LD00.*/
            }
            public SI0811B_LD00 LD00 { get; set; } = new SI0811B_LD00();
            public class SI0811B_LD00 : VarBasis
            {
                /*"       10 FILLER               PIC  X(070) VALUE         '***** NENHUM SINISTRO FOI SELECIONADO PARA O PERIODO IN         'FORMADO *****'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"***** NENHUM SINISTRO FOI SELECIONADO PARA O PERIODO IN         ");
                /*"    05 LD01.*/
            }
            public SI0811B_LD01 LD01 { get; set; } = new SI0811B_LD01();
            public class SI0811B_LD01 : VarBasis
            {
                /*"       10 LD01-APOLICE         PIC  X(013) VALUE SPACES.*/
                public StringBasis LD01_APOLICE { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 LD01-NOME            PIC  X(033) VALUE SPACES.*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 LD01-NUM-SINI        PIC  X(013) VALUE SPACES.*/
                public StringBasis LD01_NUM_SINI { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 LD01-DATA-AVISO      PIC  X(010) VALUE SPACES.*/
                public StringBasis LD01_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 LD01-VLAVISO         PIC  ------.--9,99                                           BLANK WHEN ZERO.*/
                public DoubleBasis LD01_VLAVISO { get; set; } = new DoubleBasis(new PIC("9", "9", "------.--9V99"), 2);
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 LD01-VLPAGO-ANT      PIC  ------.--9,99                                           BLANK WHEN ZERO.*/
                public DoubleBasis LD01_VLPAGO_ANT { get; set; } = new DoubleBasis(new PIC("9", "9", "------.--9V99"), 2);
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 LD01-VLPAGO-PER      PIC  ------.--9,99                                       BLANK WHEN ZERO.*/
                public DoubleBasis LD01_VLPAGO_PER { get; set; } = new DoubleBasis(new PIC("9", "9", "------.--9V99"), 2);
                /*"       10 FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 LD01-VLPENDEN        PIC  ------.--9,99                                       BLANK WHEN ZERO.*/
                public DoubleBasis LD01_VLPENDEN { get; set; } = new DoubleBasis(new PIC("9", "9", "------.--9V99"), 2);
                /*"    05 LD02.*/
            }
            public SI0811B_LD02 LD02 { get; set; } = new SI0811B_LD02();
            public class SI0811B_LD02 : VarBasis
            {
                /*"       10 FILLER                       PIC  X(020) VALUE           'TOTAL APOLICE  .... '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"TOTAL APOLICE  .... ");
                /*"       10 FILLER                       PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"       10 LD02-TOT-AVISADO             PIC  ------.--9,99                                            BLANK WHEN ZERO.*/
                public DoubleBasis LD02_TOT_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "9", "------.--9V99"), 2);
                /*"       10 FILLER                       PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 LD02-TOT-OPERACAO-ANT        PIC  ------.--9,99                                            BLANK WHEN ZERO.*/
                public DoubleBasis LD02_TOT_OPERACAO_ANT { get; set; } = new DoubleBasis(new PIC("9", "9", "------.--9V99"), 2);
                /*"       10 FILLER                       PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 LD02-TOT-OPERACAO-PERI       PIC  ------.--9,99                                            BLANK WHEN ZERO.*/
                public DoubleBasis LD02_TOT_OPERACAO_PERI { get; set; } = new DoubleBasis(new PIC("9", "9", "------.--9V99"), 2);
                /*"       10 FILLER                       PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 LD02-TOT-PENDEN              PIC  ------.--9,99                                            BLANK WHEN ZERO.*/
                public DoubleBasis LD02_TOT_PENDEN { get; set; } = new DoubleBasis(new PIC("9", "9", "------.--9V99"), 2);
                /*"    05 LD03.*/
            }
            public SI0811B_LD03 LD03 { get; set; } = new SI0811B_LD03();
            public class SI0811B_LD03 : VarBasis
            {
                /*"       10 FILLER                       PIC  X(020) VALUE          'TOTAL GERAL    ....'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"TOTAL GERAL    ....");
                /*"       10 FILLER                       PIC  X(004) VALUE ';;;;'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @";;;;");
                /*"       10 LD03-TOT-GERAL-AVISADO       PIC  ------.--9,99                                           BLANK WHEN ZERO.*/
                public DoubleBasis LD03_TOT_GERAL_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "9", "------.--9V99"), 2);
                /*"       10 FILLER                       PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 LD03-TOT-GERAL-OPERACAO-ANT  PIC  ------.--9,99                                           BLANK WHEN ZERO.*/
                public DoubleBasis LD03_TOT_GERAL_OPERACAO_ANT { get; set; } = new DoubleBasis(new PIC("9", "9", "------.--9V99"), 2);
                /*"       10 FILLER                       PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 LD03-TOT-GERAL-OPERACAO-PERI PIC  ------.--9,99                                           BLANK WHEN ZERO.*/
                public DoubleBasis LD03_TOT_GERAL_OPERACAO_PERI { get; set; } = new DoubleBasis(new PIC("9", "9", "------.--9V99"), 2);
                /*"       10 FILLER                       PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"       10 LD03-TOT-GERAL-PENDEN        PIC  ------.--9,99                                           BLANK WHEN ZERO.*/
                public DoubleBasis LD03_TOT_GERAL_PENDEN { get; set; } = new DoubleBasis(new PIC("9", "9", "------.--9V99"), 2);
                /*"    05 LD04.*/
            }
            public SI0811B_LD04 LD04 { get; set; } = new SI0811B_LD04();
            public class SI0811B_LD04 : VarBasis
            {
                /*"       10 FILLER         PIC  X(003) VALUE '** '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"** ");
                /*"       10 LD04-DEBITAR-CREDITAR  PIC  X(008) VALUE SPACES.*/
                public StringBasis LD04_DEBITAR_CREDITAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"       10 FILLER         PIC  X(059) VALUE        ' O TOTAL GERAL DO VALOR DE PENDENTE DA APURACAO, PORQUE        'EH '.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "59", "X(059)"), @" O TOTAL GERAL DO VALOR DE PENDENTE DA APURACAO, PORQUE        ");
                /*"       10 LD04-POSITIVO-NEGATIVO PIC  X(008) VALUE SPACES.*/
                public StringBasis LD04_POSITIVO_NEGATIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"       10         FILLER         PIC  X(003) VALUE ' **'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" **");
                /*"       10         FILLER         PIC  X(026) VALUE SPACES.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"01          LK-LINK.*/
            }
        }
        public SI0811B_LK_LINK LK_LINK { get; set; } = new SI0811B_LK_LINK();
        public class SI0811B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.V1MOEDA V1MOEDA { get; set; } = new Dclgens.V1MOEDA();
        public Dclgens.MOEDAS MOEDAS { get; set; } = new Dclgens.MOEDAS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public SI0811B_CRELATORIOS CRELATORIOS { get; set; } = new SI0811B_CRELATORIOS();
        public SI0811B_JOIN_HIST_MEST JOIN_HIST_MEST { get; set; } = new SI0811B_JOIN_HIST_MEST();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RSI0811B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RSI0811B.SetFile(RSI0811B_FILE_NAME_P);

                /*" -413- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

                /*" -414- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -417- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -420- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -420- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -429- MOVE '000' TO WNR-EXEC-SQL */
            _.Move("000", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -433- OPEN OUTPUT RSI0811B */
            RSI0811B.Open(REG_SI0811B);

            /*" -435- PERFORM 0000-00-ACESSA-V1SISTEMA */

            M_0000_00_ACESSA_V1SISTEMA_SECTION();

            /*" -436- DISPLAY '********************************' */
            _.Display($"********************************");

            /*" -437- DISPLAY 'DATA DO SISTEMA (SI): ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA DO SISTEMA (SI): {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -438- DISPLAY 'DATA CORRENTE       : ' V1SIST-DTCURRENT */
            _.Display($"DATA CORRENTE       : {V1SIST_DTCURRENT}");

            /*" -442- DISPLAY '********************************' */
            _.Display($"********************************");

            /*" -446- PERFORM 0000-00-ACESSA-EMPRESAS */

            M_0000_00_ACESSA_EMPRESAS_SECTION();

            /*" -447- MOVE 'NAO' TO WFIM-V1RELATOR */
            _.Move("NAO", AREA_DE_WORK.WFIM_V1RELATOR);

            /*" -448- PERFORM 0000-00-DECLARE-V1RELATORIOS */

            M_0000_00_DECLARE_V1RELATORIOS_SECTION();

            /*" -450- PERFORM 0000-00-FETCH-V1RELATORIOS */

            M_0000_00_FETCH_V1RELATORIOS_SECTION();

            /*" -451- IF WFIM-V1RELATOR EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_V1RELATOR == "SIM")
            {

                /*" -452- MOVE 'A' TO WCH-FINAL */
                _.Move("A", AREA_DE_WORK.WCH_FINAL);

                /*" -454- GO TO 0000-00-ENCERRA. */

                M_0000_00_ENCERRA_SECTION(); //GOTO
                return;
            }


            /*" -457- PERFORM 0000-00-PROCESSA-V1RELATORIO UNTIL WFIM-V1RELATOR EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_V1RELATOR == "SIM"))
            {

                M_0000_00_PROCESSA_V1RELATORIO_SECTION();
            }

            /*" -459- PERFORM 0000-00-DELETE-V1RELATORIOS */

            M_0000_00_DELETE_V1RELATORIOS_SECTION();

            /*" -459- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -463- MOVE SPACES TO WCH-FINAL */
            _.Move("", AREA_DE_WORK.WCH_FINAL);

            /*" -463- GO TO 0000-00-ENCERRA. */

            M_0000_00_ENCERRA_SECTION(); //GOTO
            return;

        }

        [StopWatch]
        /*" M-0000-00-ACESSA-V1SISTEMA-SECTION */
        private void M_0000_00_ACESSA_V1SISTEMA_SECTION()
        {
            /*" -470- MOVE '001' TO WNR-EXEC-SQL */
            _.Move("001", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -477- PERFORM M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1 */

            M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1();

            /*" -480- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -481- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -482- MOVE 'B' TO WCH-FINAL */
                    _.Move("B", AREA_DE_WORK.WCH_FINAL);

                    /*" -483- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -484- ELSE */
                }
                else
                {


                    /*" -485- DISPLAY 'ERRO ACESSO V1SISTEMA' */
                    _.Display($"ERRO ACESSO V1SISTEMA");

                    /*" -485- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-ACESSA-V1SISTEMA-DB-SELECT-1 */
        public void M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1()
        {
            /*" -477- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :V1SIST-DTCURRENT FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC */

            var m_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1 = new M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1.Execute(m_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }

        [StopWatch]
        /*" M-0000-00-ACESSA-EMPRESAS-SECTION */
        private void M_0000_00_ACESSA_EMPRESAS_SECTION()
        {
            /*" -492- MOVE '002' TO WNR-EXEC-SQL */
            _.Move("002", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -497- PERFORM M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1 */

            M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1();

            /*" -500- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -501- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -502- MOVE 'D' TO WCH-FINAL */
                    _.Move("D", AREA_DE_WORK.WCH_FINAL);

                    /*" -503- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -504- ELSE */
                }
                else
                {


                    /*" -505- DISPLAY 'PROBLEMAS ACESSO V1EMPRESA' */
                    _.Display($"PROBLEMAS ACESSO V1EMPRESA");

                    /*" -509- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -511- MOVE EMPRESAS-NOME-EMPRESA TO LK-TITULO */
            _.Move(EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA, LK_LINK.LK_TITULO);

            /*" -513- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -514- IF LK-RTCODE NOT EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE != 00)
            {

                /*" -515- MOVE 'E' TO WCH-FINAL */
                _.Move("E", AREA_DE_WORK.WCH_FINAL);

                /*" -515- GO TO 0000-00-ENCERRA. */

                M_0000_00_ENCERRA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-00-ACESSA-EMPRESAS-DB-SELECT-1 */
        public void M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1()
        {
            /*" -497- EXEC SQL SELECT NOME_EMPRESA INTO :EMPRESAS-NOME-EMPRESA FROM SEGUROS.EMPRESAS WHERE COD_EMPRESA = 0 END-EXEC */

            var m_0000_00_ACESSA_EMPRESAS_DB_SELECT_1_Query1 = new M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1_Query1.Execute(m_0000_00_ACESSA_EMPRESAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EMPRESAS_NOME_EMPRESA, EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA);
            }


        }

        [StopWatch]
        /*" M-0000-00-PROCESSA-V1RELATORIO-SECTION */
        private void M_0000_00_PROCESSA_V1RELATORIO_SECTION()
        {
            /*" -522- DISPLAY ' ' */
            _.Display($" ");

            /*" -523- DISPLAY 'SOLICITADO EM... ' RELATORI-DATA-SOLICITACAO */
            _.Display($"SOLICITADO EM... {RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO}");

            /*" -528- DISPLAY '      PERIODO DE ' RELATORI-PERI-INICIAL ' A ' RELATORI-PERI-FINAL */

            $"      PERIODO DE {RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL} A {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}"
            .Display();

            /*" -529- MOVE 'G' TO WCH-FINAL */
            _.Move("G", AREA_DE_WORK.WCH_FINAL);

            /*" -530- PERFORM 0000-00-ACESSA-COTACAO-MOEDA */

            M_0000_00_ACESSA_COTACAO_MOEDA_SECTION();

            /*" -534- MOVE V1MOEDA-VLCRUZAD TO W-COTACAO-HOJE. */
            _.Move(V1MOEDA.DCLV1MOEDA.V1MOEDA_VLCRUZAD, AREA_DE_WORK.W_TOTAL_GERAL.W_COTACAO_HOJE);

            /*" -536- PERFORM 0000-00-MONTA-CABECALHO */

            M_0000_00_MONTA_CABECALHO_SECTION();

            /*" -537- MOVE ZEROS TO W-AC-PAGINA */
            _.Move(0, AREA_DE_WORK.W_AC_PAGINA);

            /*" -546- MOVE 80 TO W-AC-LINHAS */
            _.Move(80, AREA_DE_WORK.W_AC_LINHAS);

            /*" -548- MOVE ZEROS TO V0MEST-NUM-APOL-I V0MEST-RAMO-I */
            _.Move(0, V0MEST_NUM_APOL_I, V0MEST_RAMO_I);

            /*" -549- MOVE 9999999999999 TO V0MEST-NUM-APOL-F */
            _.Move(9999999999999, V0MEST_NUM_APOL_F);

            /*" -551- MOVE 99 TO V0MEST-RAMO-F */
            _.Move(99, V0MEST_RAMO_F);

            /*" -552- IF RELATORI-RAMO-EMISSOR NOT EQUAL ZEROS */

            if (RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR != 00)
            {

                /*" -554- MOVE RELATORI-RAMO-EMISSOR TO V0MEST-RAMO-I V0MEST-RAMO-F */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR, V0MEST_RAMO_I, V0MEST_RAMO_F);

                /*" -555- ELSE */
            }
            else
            {


                /*" -556- IF RELATORI-NUM-APOLICE NOT EQUAL ZEROS */

                if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE != 00)
                {

                    /*" -558- MOVE RELATORI-NUM-APOLICE TO V0MEST-NUM-APOL-I V0MEST-NUM-APOL-F */
                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, V0MEST_NUM_APOL_I, V0MEST_NUM_APOL_F);

                    /*" -559- END-IF */
                }


                /*" -561- END-IF */
            }


            /*" -562- MOVE 'NAO' TO WFIM-JOIN-HIST-MEST */
            _.Move("NAO", AREA_DE_WORK.WFIM_JOIN_HIST_MEST);

            /*" -563- PERFORM 0000-00-DECLARE-JOIN-HIST-MEST */

            M_0000_00_DECLARE_JOIN_HIST_MEST_SECTION();

            /*" -565- PERFORM 0000-00-FETCH-JOIN-HIST-MEST */

            M_0000_00_FETCH_JOIN_HIST_MEST_SECTION();

            /*" -566- IF WFIM-JOIN-HIST-MEST EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_JOIN_HIST_MEST == "SIM")
            {

                /*" -567- WRITE REG-SI0811B FROM LD00 */
                _.Move(FILLER_12.LD00.GetMoveValues(), REG_SI0811B);

                RSI0811B.Write(REG_SI0811B.GetMoveValues().ToString());

                /*" -568- MOVE 'C' TO WCH-FINAL */
                _.Move("C", AREA_DE_WORK.WCH_FINAL);

                /*" -569- PERFORM 0000-00-ENCERRA */

                M_0000_00_ENCERRA_SECTION();

                /*" -570- ELSE */
            }
            else
            {


                /*" -571- DISPLAY '///////////// PARAMETRO ////////////////' */
                _.Display($"///////////// PARAMETRO ////////////////");

                /*" -572- DISPLAY 'RAMO.............: ' RELATORI-RAMO-EMISSOR */
                _.Display($"RAMO.............: {RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR}");

                /*" -573- DISPLAY 'APOLICE..........: ' RELATORI-NUM-APOLICE */
                _.Display($"APOLICE..........: {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                /*" -574- DISPLAY 'COD MOEDA........: ' RELATORI-COD-MOEDA */
                _.Display($"COD MOEDA........: {RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA}");

                /*" -575- DISPLAY 'PERI.INICIAL.....: ' RELATORI-PERI-INICIAL */
                _.Display($"PERI.INICIAL.....: {RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}");

                /*" -576- DISPLAY 'PERI.FINAL.......: ' RELATORI-PERI-FINAL */
                _.Display($"PERI.FINAL.......: {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}");

                /*" -577- DISPLAY 'USUARIO..........: ' RELATORI-COD-USUARIO */
                _.Display($"USUARIO..........: {RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO}");

                /*" -578- DISPLAY 'DATA SOLICITACAO : ' RELATORI-DATA-SOLICITACAO */
                _.Display($"DATA SOLICITACAO : {RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO}");

                /*" -580- DISPLAY '////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////");

                /*" -581- INITIALIZE CH-CHAVE-ATU */
                _.Initialize(
                    AREA_DE_WORK.CH_CHAVE_ATU
                );

                /*" -582- INITIALIZE W-TOTAL-PARCIAL */
                _.Initialize(
                    AREA_DE_WORK.W_TOTAL_PARCIAL
                );

                /*" -584- INITIALIZE W-TOTAL-GERAL */
                _.Initialize(
                    AREA_DE_WORK.W_TOTAL_GERAL
                );

                /*" -585- MOVE RELATORI-NUM-APOLICE TO W-APOLICE-ANT */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT);

                /*" -587- MOVE 'SIM' TO W-NOVA-APOLICE */
                _.Move("SIM", AREA_DE_WORK.CH_CHAVE_ATU.W_NOVA_APOLICE);

                /*" -590- PERFORM 0000-00-TRATA-JOIN-HIST-MEST UNTIL WFIM-JOIN-HIST-MEST EQUAL 'SIM' */

                while (!(AREA_DE_WORK.WFIM_JOIN_HIST_MEST == "SIM"))
                {

                    M_0000_00_TRATA_JOIN_HIST_MEST_SECTION();
                }

                /*" -591- PERFORM 0000-00-TOTAL-APOLICE */

                M_0000_00_TOTAL_APOLICE_SECTION();

                /*" -592- PERFORM 0000-00-TOTAL-RELATORIO */

                M_0000_00_TOTAL_RELATORIO_SECTION();

                /*" -594- END-IF */
            }


            /*" -596- PERFORM 0000-00-CLOSE-JOIN-HIST-MEST */

            M_0000_00_CLOSE_JOIN_HIST_MEST_SECTION();

            /*" -596- PERFORM 0000-00-FETCH-V1RELATORIOS. */

            M_0000_00_FETCH_V1RELATORIOS_SECTION();

        }

        [StopWatch]
        /*" M-0000-00-TRATA-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_TRATA_JOIN_HIST_MEST_SECTION()
        {
            /*" -603- IF (SINISMES-NUM-APOLICE NOT EQUAL W-APOLICE-ANT) */

            if ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE != AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT))
            {

                /*" -604- PERFORM 0000-00-TOTAL-APOLICE */

                M_0000_00_TOTAL_APOLICE_SECTION();

                /*" -607- MOVE ZEROS TO W-TOT-AVISADO W-TOT-OPERACAO W-TOT-PENDEN */
                _.Move(0, AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_AVISADO, AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_OPERACAO, AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_PENDEN);

                /*" -608- MOVE 'SIM' TO W-NOVA-APOLICE */
                _.Move("SIM", AREA_DE_WORK.CH_CHAVE_ATU.W_NOVA_APOLICE);

                /*" -610- MOVE SINISMES-NUM-APOLICE TO W-APOLICE-ANT. */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, AREA_DE_WORK.CH_CHAVE_ATU.W_APOLICE_ANT);
            }


            /*" -614- MOVE ZEROS TO W-AC-AVISADO W-AC-PENDEN W-AC-VAL-OPERACAO */
            _.Move(0, AREA_DE_WORK.W_AC_AVISADO, AREA_DE_WORK.W_AC_PENDEN, AREA_DE_WORK.W_AC_VAL_OPERACAO);

            /*" -615- MOVE 'H' TO WCH-FINAL */
            _.Move("H", AREA_DE_WORK.WCH_FINAL);

            /*" -617- PERFORM 0000-00-ACESSA-COTACAO-MOEDA */

            M_0000_00_ACESSA_COTACAO_MOEDA_SECTION();

            /*" -620- COMPUTE W-AC-AVISADO = W-VALOR-AVISADO / V1MOEDA-VLCRUZAD */
            AREA_DE_WORK.W_AC_AVISADO.Value = AREA_DE_WORK.W_VALOR_AVISADO / V1MOEDA.DCLV1MOEDA.V1MOEDA_VLCRUZAD;

            /*" -621- PERFORM 0000-00-SELECT-PAGO-ANT-PER */

            M_0000_00_SELECT_PAGO_ANT_PER_SECTION();

            /*" -624- COMPUTE W-AC-PAGO-ANT = W-VALOR-PAGO-ANT-PER / V1MOEDA-VLCRUZAD */
            AREA_DE_WORK.W_AC_PAGO_ANT.Value = AREA_DE_WORK.W_VALOR_PAGO_ANT_PER / V1MOEDA.DCLV1MOEDA.V1MOEDA_VLCRUZAD;

            /*" -625- PERFORM 0000-00-SELECT-PAGO-NO-PER */

            M_0000_00_SELECT_PAGO_NO_PER_SECTION();

            /*" -631- COMPUTE W-AC-PAGO-PERI = W-VALOR-PAGO-NO-PER / V1MOEDA-VLCRUZAD */
            AREA_DE_WORK.W_AC_PAGO_PERI.Value = AREA_DE_WORK.W_VALOR_PAGO_NO_PER / V1MOEDA.DCLV1MOEDA.V1MOEDA_VLCRUZAD;

            /*" -633- PERFORM 0000-00-PREPARA-DETALHE */

            M_0000_00_PREPARA_DETALHE_SECTION();

            /*" -635- PERFORM 0000-00-IMPRIME-REGISTRO. */

            M_0000_00_IMPRIME_REGISTRO_SECTION();

            /*" -635- PERFORM 0000-00-FETCH-JOIN-HIST-MEST. */

            M_0000_00_FETCH_JOIN_HIST_MEST_SECTION();

        }

        [StopWatch]
        /*" M-0000-00-IMPRIME-REGISTRO-SECTION */
        private void M_0000_00_IMPRIME_REGISTRO_SECTION()
        {
            /*" -648- MOVE SINISMES-NUM-APOLICE TO LD01-APOLICE */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, FILLER_12.LD01.LD01_APOLICE);

            /*" -649- MOVE W-AC-AVISADO TO LD01-VLAVISO */
            _.Move(AREA_DE_WORK.W_AC_AVISADO, FILLER_12.LD01.LD01_VLAVISO);

            /*" -650- MOVE W-AC-PAGO-ANT TO LD01-VLPAGO-ANT. */
            _.Move(AREA_DE_WORK.W_AC_PAGO_ANT, FILLER_12.LD01.LD01_VLPAGO_ANT);

            /*" -651- MOVE W-AC-PAGO-PERI TO LD01-VLPAGO-PER. */
            _.Move(AREA_DE_WORK.W_AC_PAGO_PERI, FILLER_12.LD01.LD01_VLPAGO_PER);

            /*" -654- COMPUTE W-AC-PENDEN = W-AC-AVISADO - W-AC-PAGO-ANT - W-AC-PAGO-PERI. */
            AREA_DE_WORK.W_AC_PENDEN.Value = AREA_DE_WORK.W_AC_AVISADO - AREA_DE_WORK.W_AC_PAGO_ANT - AREA_DE_WORK.W_AC_PAGO_PERI;

            /*" -656- MOVE W-AC-PENDEN TO LD01-VLPENDEN. */
            _.Move(AREA_DE_WORK.W_AC_PENDEN, FILLER_12.LD01.LD01_VLPENDEN);

            /*" -658- ADD W-AC-AVISADO TO W-TOT-AVISADO W-TOT-GERAL-AVISADO. */
            AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_AVISADO.Value = AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_AVISADO + AREA_DE_WORK.W_AC_AVISADO;
            AREA_DE_WORK.W_TOTAL_GERAL.W_TOT_GERAL_AVISADO.Value = AREA_DE_WORK.W_TOTAL_GERAL.W_TOT_GERAL_AVISADO + AREA_DE_WORK.W_AC_AVISADO;

            /*" -660- ADD W-AC-PAGO-ANT TO W-TOT-OPERACAO-ANT W-TOT-GERAL-OPERACAO-ANT. */
            AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_OPERACAO_ANT.Value = AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_OPERACAO_ANT + AREA_DE_WORK.W_AC_PAGO_ANT;
            AREA_DE_WORK.W_TOTAL_GERAL.W_TOT_GERAL_OPERACAO_ANT.Value = AREA_DE_WORK.W_TOTAL_GERAL.W_TOT_GERAL_OPERACAO_ANT + AREA_DE_WORK.W_AC_PAGO_ANT;

            /*" -662- ADD W-AC-PAGO-PERI TO W-TOT-OPERACAO-PERI W-TOT-GERAL-OPERACAO-PERI. */
            AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_OPERACAO_PERI.Value = AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_OPERACAO_PERI + AREA_DE_WORK.W_AC_PAGO_PERI;
            AREA_DE_WORK.W_TOTAL_GERAL.W_TOT_GERAL_OPERACAO_PERI.Value = AREA_DE_WORK.W_TOTAL_GERAL.W_TOT_GERAL_OPERACAO_PERI + AREA_DE_WORK.W_AC_PAGO_PERI;

            /*" -670- ADD W-AC-PENDEN TO W-TOT-PENDEN W-TOT-GERAL-PENDEN. */
            AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_PENDEN.Value = AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_PENDEN + AREA_DE_WORK.W_AC_PENDEN;
            AREA_DE_WORK.W_TOTAL_GERAL.W_TOT_GERAL_PENDEN.Value = AREA_DE_WORK.W_TOTAL_GERAL.W_TOT_GERAL_PENDEN + AREA_DE_WORK.W_AC_PENDEN;

            /*" -671- WRITE REG-SI0811B FROM LD01. */
            _.Move(FILLER_12.LD01.GetMoveValues(), REG_SI0811B);

            RSI0811B.Write(REG_SI0811B.GetMoveValues().ToString());

            /*" -671- ADD 1 TO W-AC-LINHAS. */
            AREA_DE_WORK.W_AC_LINHAS.Value = AREA_DE_WORK.W_AC_LINHAS + 1;

        }

        [StopWatch]
        /*" M-0000-00-PREPARA-DETALHE-SECTION */
        private void M_0000_00_PREPARA_DETALHE_SECTION()
        {
            /*" -678- IF SINISMES-RAMO EQUAL 97 OR 93 OR 81 OR 80 OR 81 OR 91 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.In("97", "93", "81", "80", "81", "91"))
            {

                /*" -679- MOVE SINISMES-NUM-CERTIFICADO TO SEGURVGA-NUM-CERTIFICADO */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);

                /*" -680- PERFORM 0000-00-SELECT-V1SEGURAVG */

                M_0000_00_SELECT_V1SEGURAVG_SECTION();

                /*" -681- MOVE SEGURVGA-COD-CLIENTE TO CLIENTES-COD-CLIENTE */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

                /*" -682- ELSE */
            }
            else
            {


                /*" -683- MOVE SINISMES-NUM-APOLICE TO APOLICES-NUM-APOLICE */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

                /*" -684- PERFORM 0000-00-SELECT-APOLICE */

                M_0000_00_SELECT_APOLICE_SECTION();

                /*" -685- MOVE APOLICES-COD-CLIENTE TO CLIENTES-COD-CLIENTE */
                _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

                /*" -687- END-IF */
            }


            /*" -689- PERFORM 0000-00-SELECT-V1CLIENTE */

            M_0000_00_SELECT_V1CLIENTE_SECTION();

            /*" -690- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -691- MOVE '* CLIENTE  N A O  CADASTRADO *' TO LD01-NOME */
                _.Move("* CLIENTE  N A O  CADASTRADO *", FILLER_12.LD01.LD01_NOME);

                /*" -692- ELSE */
            }
            else
            {


                /*" -693- MOVE CLIENTES-NOME-RAZAO TO LD01-NOME */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, FILLER_12.LD01.LD01_NOME);

                /*" -695- END-IF */
            }


            /*" -697- MOVE SINISMES-NUM-APOL-SINISTRO TO LD01-NUM-SINI */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, FILLER_12.LD01.LD01_NUM_SINI);

            /*" -698- MOVE SINISMES-DATA-COMUNICADO TO DB2-DATA */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO, AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA);

            /*" -699- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_DIA, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_DIA);

            /*" -700- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_MES, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_MES);

            /*" -701- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_ANO, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_ANO);

            /*" -701- MOVE EDIT-DATA TO LD01-DATA-AVISO. */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA, FILLER_12.LD01.LD01_DATA_AVISO);

        }

        [StopWatch]
        /*" M-0000-00-MONTA-CABECALHO-SECTION */
        private void M_0000_00_MONTA_CABECALHO_SECTION()
        {
            /*" -711- MOVE LK-TITULO TO LC01-EMPRESA */
            _.Move(LK_LINK.LK_TITULO, FILLER_12.LC01.LC01_EMPRESA);

            /*" -712- ADD 1 TO W-AC-PAGINA */
            AREA_DE_WORK.W_AC_PAGINA.Value = AREA_DE_WORK.W_AC_PAGINA + 1;

            /*" -714- MOVE W-AC-PAGINA TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.W_AC_PAGINA, FILLER_12.LC01.LC01_PAGINA);

            /*" -715- MOVE V1SIST-DTCURRENT TO DB2-DATA */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA);

            /*" -716- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_DIA, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_DIA);

            /*" -717- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_MES, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_MES);

            /*" -718- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_ANO, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_ANO);

            /*" -720- MOVE EDIT-DATA TO LC02-DATA */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA, FILLER_12.LC02.LC02_DATA);

            /*" -722- MOVE RELATORI-PERI-INICIAL TO DB2-DATA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA);

            /*" -723- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_DIA, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_DIA);

            /*" -724- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_MES, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_MES);

            /*" -725- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_ANO, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_ANO);

            /*" -727- MOVE EDIT-DATA TO LC03-DATA-INI */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA, FILLER_12.LC03.LC03_DATA_INI);

            /*" -729- MOVE RELATORI-PERI-FINAL TO DB2-DATA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA);

            /*" -730- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_DIA, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_DIA);

            /*" -731- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_MES, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_MES);

            /*" -732- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_ANO, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_ANO);

            /*" -734- MOVE EDIT-DATA TO LC03-DATA-TER */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA, FILLER_12.LC03.LC03_DATA_TER);

            /*" -735- ACCEPT SIST-HORA FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.W_TOTAL_GERAL.SIST_HORA);

            /*" -736- MOVE SIST-HH TO EDIT-HH */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.SIST_HORA.SIST_HH, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_HORA.EDIT_HH);

            /*" -737- MOVE SIST-MM TO EDIT-MM */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.SIST_HORA.SIST_MM, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_HORA.EDIT_MM);

            /*" -738- MOVE SIST-SS TO EDIT-SS */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.SIST_HORA.SIST_SS, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_HORA.EDIT_SS);

            /*" -740- MOVE EDIT-HORA TO LC03-HORA */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.EDIT_HORA, FILLER_12.LC03.LC03_HORA);

            /*" -742- MOVE RELATORI-COD-USUARIO TO LC04-CODUSU */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, FILLER_12.LC04.LC04_CODUSU);

            /*" -744- MOVE V1MOEDA-SIGLUNIM TO LC04-MOEDA */
            _.Move(V1MOEDA.DCLV1MOEDA.V1MOEDA_SIGLUNIM, FILLER_12.LC04.LC04_MOEDA);

            /*" -746- MOVE RELATORI-DATA-SOLICITACAO TO DB2-DATA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO, AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA);

            /*" -747- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_DIA, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_DIA);

            /*" -748- MOVE DB2-MES TO EDIT-MES */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_MES, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_MES);

            /*" -749- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.DB2_DATA.DB2_ANO, AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA.EDIT_ANO);

            /*" -751- MOVE EDIT-DATA TO LC04-DATA-SOLIC */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.EDIT_DATA, FILLER_12.LC04.LC04_DATA_SOLIC);

            /*" -752- MOVE LC03-DATA-TER TO LC07-DT-AVISO */
            _.Move(FILLER_12.LC03.LC03_DATA_TER, FILLER_12.LC07.LC07_DT_AVISO);

            /*" -753- MOVE LC03-DATA-TER TO LC07-DT-PEND */
            _.Move(FILLER_12.LC03.LC03_DATA_TER, FILLER_12.LC07.LC07_DT_PEND);

            /*" -756- MOVE LC03-DATA-INI TO LC07-DT-PAG-ANT */
            _.Move(FILLER_12.LC03.LC03_DATA_INI, FILLER_12.LC07.LC07_DT_PAG_ANT);

            /*" -757- WRITE REG-SI0811B FROM LC02. */
            _.Move(FILLER_12.LC02.GetMoveValues(), REG_SI0811B);

            RSI0811B.Write(REG_SI0811B.GetMoveValues().ToString());

            /*" -758- WRITE REG-SI0811B FROM LC03. */
            _.Move(FILLER_12.LC03.GetMoveValues(), REG_SI0811B);

            RSI0811B.Write(REG_SI0811B.GetMoveValues().ToString());

            /*" -760- WRITE REG-SI0811B FROM LC04. */
            _.Move(FILLER_12.LC04.GetMoveValues(), REG_SI0811B);

            RSI0811B.Write(REG_SI0811B.GetMoveValues().ToString());

            /*" -761- WRITE REG-SI0811B FROM LC06. */
            _.Move(FILLER_12.LC06.GetMoveValues(), REG_SI0811B);

            RSI0811B.Write(REG_SI0811B.GetMoveValues().ToString());

            /*" -761- WRITE REG-SI0811B FROM LC07. */
            _.Move(FILLER_12.LC07.GetMoveValues(), REG_SI0811B);

            RSI0811B.Write(REG_SI0811B.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-0000-00-SELECT-APOLICE-SECTION */
        private void M_0000_00_SELECT_APOLICE_SECTION()
        {
            /*" -770- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -775- PERFORM M_0000_00_SELECT_APOLICE_DB_SELECT_1 */

            M_0000_00_SELECT_APOLICE_DB_SELECT_1();

            /*" -778- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -779- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -780- MOVE ZEROS TO APOLICES-COD-CLIENTE */
                    _.Move(0, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);

                    /*" -781- ELSE */
                }
                else
                {


                    /*" -782- DISPLAY 'ERRO ACESSO APOLICE' */
                    _.Display($"ERRO ACESSO APOLICE");

                    /*" -783- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -784- END-IF */
                }


                /*" -784- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-APOLICE-DB-SELECT-1 */
        public void M_0000_00_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -775- EXEC SQL SELECT COD_CLIENTE INTO :APOLICES-COD-CLIENTE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE END-EXEC */

            var m_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1 = new M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1.Execute(m_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1SEGURAVG-SECTION */
        private void M_0000_00_SELECT_V1SEGURAVG_SECTION()
        {
            /*" -792- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -798- PERFORM M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1 */

            M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1();

            /*" -801- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -802- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -803- MOVE ZEROS TO SEGURVGA-COD-CLIENTE */
                    _.Move(0, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);

                    /*" -804- ELSE */
                }
                else
                {


                    /*" -805- DISPLAY 'ERRO ACESSO V1SUBGRUPO' */
                    _.Display($"ERRO ACESSO V1SUBGRUPO");

                    /*" -806- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -807- END-IF */
                }


                /*" -807- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1SEGURAVG-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1()
        {
            /*" -798- EXEC SQL SELECT COD_CLIENTE INTO :SEGURVGA-COD-CLIENTE FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC */

            var m_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1 = new M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1.Execute(m_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1CLIENTE-SECTION */
        private void M_0000_00_SELECT_V1CLIENTE_SECTION()
        {
            /*" -815- MOVE '005' TO WNR-EXEC-SQL */
            _.Move("005", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -820- PERFORM M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1 */

            M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1();

            /*" -823- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -824- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -825- MOVE 'SEGURADO NAO CADASTRADO' TO CLIENTES-NOME-RAZAO */
                    _.Move("SEGURADO NAO CADASTRADO", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                    /*" -826- ELSE */
                }
                else
                {


                    /*" -827- DISPLAY 'ERRO ACESSO V1CLIENTE' */
                    _.Display($"ERRO ACESSO V1CLIENTE");

                    /*" -828- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -829- END-IF */
                }


                /*" -829- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0000-00-SELECT-V1CLIENTE-DB-SELECT-1 */
        public void M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1()
        {
            /*" -820- EXEC SQL SELECT NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE END-EXEC. */

            var m_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1 = new M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1.Execute(m_0000_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }

        [StopWatch]
        /*" M-0000-00-ACESSA-COTACAO-MOEDA-SECTION */
        private void M_0000_00_ACESSA_COTACAO_MOEDA_SECTION()
        {
            /*" -837- MOVE '006' TO WNR-EXEC-SQL */
            _.Move("006", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -846- PERFORM M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1 */

            M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1();

            /*" -849- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -850- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -851- GO TO 0000-00-ENCERRA */

                    M_0000_00_ENCERRA_SECTION(); //GOTO
                    return;

                    /*" -852- ELSE */
                }
                else
                {


                    /*" -853- DISPLAY '/////////////////////////////////////////' */
                    _.Display($"/////////////////////////////////////////");

                    /*" -854- DISPLAY '// CODUNIMO   ' RELATORI-COD-MOEDA */
                    _.Display($"// CODUNIMO   {RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA}");

                    /*" -855- DISPLAY '// DTINIVIG   ' SISTEMAS-DATA-MOV-ABERTO */
                    _.Display($"// DTINIVIG   {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                    /*" -856- DISPLAY '// PROBLEMAS SELECT V1MOEDA ... ' */
                    _.Display($"// PROBLEMAS SELECT V1MOEDA ... ");

                    /*" -857- DISPLAY '/////////////////////////////////////////' */
                    _.Display($"/////////////////////////////////////////");

                    /*" -858- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -859- END-IF */
                }


                /*" -859- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0000-00-ACESSA-COTACAO-MOEDA-DB-SELECT-1 */
        public void M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1()
        {
            /*" -846- EXEC SQL SELECT VLCRUZAD, SIGLUNIM INTO :V1MOEDA-VLCRUZAD, :V1MOEDA-SIGLUNIM FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :RELATORI-COD-MOEDA AND DTINIVIG <= :SISTEMAS-DATA-MOV-ABERTO AND DTTERVIG >= :SISTEMAS-DATA-MOV-ABERTO END-EXEC */

            var m_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1 = new M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                RELATORI_COD_MOEDA = RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA.ToString(),
            };

            var executed_1 = M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1.Execute(m_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MOEDA_VLCRUZAD, V1MOEDA.DCLV1MOEDA.V1MOEDA_VLCRUZAD);
                _.Move(executed_1.V1MOEDA_SIGLUNIM, V1MOEDA.DCLV1MOEDA.V1MOEDA_SIGLUNIM);
            }


        }

        [StopWatch]
        /*" M-0000-00-TOTAL-APOLICE-SECTION */
        private void M_0000_00_TOTAL_APOLICE_SECTION()
        {
            /*" -866- MOVE W-TOT-AVISADO TO LD02-TOT-AVISADO */
            _.Move(AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_AVISADO, FILLER_12.LD02.LD02_TOT_AVISADO);

            /*" -867- MOVE W-TOT-OPERACAO-ANT TO LD02-TOT-OPERACAO-ANT */
            _.Move(AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_OPERACAO_ANT, FILLER_12.LD02.LD02_TOT_OPERACAO_ANT);

            /*" -868- MOVE W-TOT-OPERACAO-PERI TO LD02-TOT-OPERACAO-PERI */
            _.Move(AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_OPERACAO_PERI, FILLER_12.LD02.LD02_TOT_OPERACAO_PERI);

            /*" -874- MOVE W-TOT-PENDEN TO LD02-TOT-PENDEN */
            _.Move(AREA_DE_WORK.W_TOTAL_PARCIAL.W_TOT_PENDEN, FILLER_12.LD02.LD02_TOT_PENDEN);

            /*" -874- WRITE REG-SI0811B FROM LD02. */
            _.Move(FILLER_12.LD02.GetMoveValues(), REG_SI0811B);

            RSI0811B.Write(REG_SI0811B.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-0000-00-TOTAL-RELATORIO-SECTION */
        private void M_0000_00_TOTAL_RELATORIO_SECTION()
        {
            /*" -881- MOVE W-TOT-GERAL-AVISADO TO LD03-TOT-GERAL-AVISADO */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.W_TOT_GERAL_AVISADO, FILLER_12.LD03.LD03_TOT_GERAL_AVISADO);

            /*" -883- MOVE W-TOT-GERAL-OPERACAO-ANT TO LD03-TOT-GERAL-OPERACAO-ANT */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.W_TOT_GERAL_OPERACAO_ANT, FILLER_12.LD03.LD03_TOT_GERAL_OPERACAO_ANT);

            /*" -885- MOVE W-TOT-GERAL-OPERACAO-PERI TO LD03-TOT-GERAL-OPERACAO-PERI */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.W_TOT_GERAL_OPERACAO_PERI, FILLER_12.LD03.LD03_TOT_GERAL_OPERACAO_PERI);

            /*" -891- MOVE W-TOT-GERAL-PENDEN TO LD03-TOT-GERAL-PENDEN */
            _.Move(AREA_DE_WORK.W_TOTAL_GERAL.W_TOT_GERAL_PENDEN, FILLER_12.LD03.LD03_TOT_GERAL_PENDEN);

            /*" -893- WRITE REG-SI0811B FROM LD03. */
            _.Move(FILLER_12.LD03.GetMoveValues(), REG_SI0811B);

            RSI0811B.Write(REG_SI0811B.GetMoveValues().ToString());

            /*" -894- IF W-TOT-GERAL-PENDEN LESS ZERO */

            if (AREA_DE_WORK.W_TOTAL_GERAL.W_TOT_GERAL_PENDEN < 00)
            {

                /*" -895- MOVE 'DEBITAR' TO LD04-DEBITAR-CREDITAR */
                _.Move("DEBITAR", FILLER_12.LD04.LD04_DEBITAR_CREDITAR);

                /*" -896- MOVE 'NEGATIVO' TO LD04-POSITIVO-NEGATIVO */
                _.Move("NEGATIVO", FILLER_12.LD04.LD04_POSITIVO_NEGATIVO);

                /*" -897- ELSE */
            }
            else
            {


                /*" -898- MOVE 'CREDITAR' TO LD04-DEBITAR-CREDITAR */
                _.Move("CREDITAR", FILLER_12.LD04.LD04_DEBITAR_CREDITAR);

                /*" -899- MOVE 'POSITIVO' TO LD04-POSITIVO-NEGATIVO */
                _.Move("POSITIVO", FILLER_12.LD04.LD04_POSITIVO_NEGATIVO);

                /*" -901- END-IF */
            }


            /*" -901- WRITE REG-SI0811B FROM LD04. */
            _.Move(FILLER_12.LD04.GetMoveValues(), REG_SI0811B);

            RSI0811B.Write(REG_SI0811B.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V1RELATORIOS-SECTION */
        private void M_0000_00_DECLARE_V1RELATORIOS_SECTION()
        {
            /*" -909- MOVE '007' TO WNR-EXEC-SQL */
            _.Move("007", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -922- PERFORM M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1 */

            M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1();

            /*" -924- PERFORM M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1 */

            M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1();

            /*" -927- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -928- DISPLAY 'PROBLEMAS DECLARE V1RELATORIOS ... ' */
                _.Display($"PROBLEMAS DECLARE V1RELATORIOS ... ");

                /*" -929- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -929- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V1RELATORIOS-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1()
        {
            /*" -922- EXEC SQL DECLARE CRELATORIOS CURSOR FOR SELECT RAMO_EMISSOR, NUM_APOLICE , COD_MOEDA , PERI_INICIAL, PERI_FINAL , COD_USUARIO , DATA_SOLICITACAO, (PERI_INICIAL - 1 DAY) FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'SI0811B' ORDER BY COD_USUARIO, DATA_SOLICITACAO, PERI_INICIAL, RAMO_EMISSOR, NUM_APOLICE END-EXEC */
            CRELATORIOS = new SI0811B_CRELATORIOS(false);
            string GetQuery_CRELATORIOS()
            {
                var query = @$"SELECT RAMO_EMISSOR
							, 
							NUM_APOLICE
							, 
							COD_MOEDA
							, 
							PERI_INICIAL
							, 
							PERI_FINAL
							, 
							COD_USUARIO
							, 
							DATA_SOLICITACAO
							, 
							(PERI_INICIAL - 1 DAY) 
							FROM SEGUROS.RELATORIOS 
							WHERE COD_RELATORIO = 'SI0811B' 
							ORDER BY COD_USUARIO
							, DATA_SOLICITACAO
							, 
							PERI_INICIAL
							, RAMO_EMISSOR
							, NUM_APOLICE";

                return query;
            }
            CRELATORIOS.GetQueryEvent += GetQuery_CRELATORIOS;

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-V1RELATORIOS-DB-OPEN-1 */
        public void M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1()
        {
            /*" -924- EXEC SQL OPEN CRELATORIOS END-EXEC */

            CRELATORIOS.Open();

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-JOIN-HIST-MEST-DB-DECLARE-1 */
        public void M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1()
        {
            /*" -1009- EXEC SQL DECLARE JOIN-HIST-MEST CURSOR FOR SELECT M.NUM_APOLICE, M.NUM_APOL_SINISTRO , M.RAMO , M.NUM_CERTIFICADO , M.SIT_REGISTRO , M.DATA_COMUNICADO FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO O WHERE M.NUM_APOLICE = :RELATORI-NUM-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H.DATA_MOVIMENTO <= :RELATORI-PERI-FINAL AND H.COD_OPERACAO = O.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.IND_TIPO_FUNCAO IN ( 'AV' , 'IN' ) GROUP BY M.NUM_APOLICE, M.NUM_APOL_SINISTRO , M.RAMO , M.NUM_CERTIFICADO , M.SIT_REGISTRO , M.DATA_COMUNICADO ORDER BY M.NUM_APOLICE, M.NUM_APOL_SINISTRO , M.RAMO , M.NUM_CERTIFICADO , M.SIT_REGISTRO , M.DATA_COMUNICADO END-EXEC */
            JOIN_HIST_MEST = new SI0811B_JOIN_HIST_MEST(true);
            string GetQuery_JOIN_HIST_MEST()
            {
                var query = @$"SELECT M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.RAMO
							, 
							M.NUM_CERTIFICADO
							, 
							M.SIT_REGISTRO
							, 
							M.DATA_COMUNICADO 
							FROM SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.GE_OPERACAO O 
							WHERE M.NUM_APOLICE = '{RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}' 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H.DATA_MOVIMENTO <= '{RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}' 
							AND H.COD_OPERACAO = O.COD_OPERACAO 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.IND_TIPO_FUNCAO IN ( 'AV'
							, 'IN' ) 
							GROUP BY M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.RAMO
							, 
							M.NUM_CERTIFICADO
							, 
							M.SIT_REGISTRO
							, 
							M.DATA_COMUNICADO 
							ORDER BY M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.RAMO
							, 
							M.NUM_CERTIFICADO
							, 
							M.SIT_REGISTRO
							, 
							M.DATA_COMUNICADO";

                return query;
            }
            JOIN_HIST_MEST.GetQueryEvent += GetQuery_JOIN_HIST_MEST;

        }

        [StopWatch]
        /*" M-0000-00-FETCH-V1RELATORIOS-SECTION */
        private void M_0000_00_FETCH_V1RELATORIOS_SECTION()
        {
            /*" -937- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -946- PERFORM M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1 */

            M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1();

            /*" -949- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -950- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -951- MOVE 'SIM' TO WFIM-V1RELATOR */
                    _.Move("SIM", AREA_DE_WORK.WFIM_V1RELATOR);

                    /*" -952- ELSE */
                }
                else
                {


                    /*" -953- DISPLAY 'PROBLEMAS ACESSO V1RELATORIOS' */
                    _.Display($"PROBLEMAS ACESSO V1RELATORIOS");

                    /*" -954- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -955- END-IF */
                }


                /*" -957- END-IF */
            }


            /*" -958- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -959- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -960- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -961- DISPLAY '*      ==>     SI0811B      <==         *' */
                _.Display($"*      ==>     SI0811B      <==         *");

                /*" -962- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -963- DISPLAY '*  DISPLAY DOS DADOS INFORMADOS PELO    *' */
                _.Display($"*  DOS DADOS INFORMADOS PELO    *");

                /*" -964- DISPLAY '*  USUARIO NA V1RELATORIOS              *' */
                _.Display($"*  USUARIO NA V1RELATORIOS              *");

                /*" -965- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -966- DISPLAY '* COD-EMPRESA ...... ' RELATORI-COD-EMPRESA */
                _.Display($"* COD-EMPRESA ...... {RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA}");

                /*" -967- DISPLAY '* RAMO        ...... ' RELATORI-RAMO-EMISSOR */
                _.Display($"* RAMO        ...... {RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR}");

                /*" -968- DISPLAY '* NUM. APOL.  ...... ' RELATORI-NUM-APOLICE */
                _.Display($"* NUM. APOL.  ...... {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                /*" -969- DISPLAY '* CODUNIMO    ...... ' RELATORI-COD-MOEDA */
                _.Display($"* CODUNIMO    ...... {RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA}");

                /*" -970- DISPLAY '* PERI. INIC. ...... ' RELATORI-PERI-INICIAL */
                _.Display($"* PERI. INIC. ...... {RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}");

                /*" -971- DISPLAY '* PERI. FIM   ...... ' RELATORI-PERI-FINAL */
                _.Display($"* PERI. FIM   ...... {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}");

                /*" -972- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -973- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -973- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0000-00-FETCH-V1RELATORIOS-DB-FETCH-1 */
        public void M_0000_00_FETCH_V1RELATORIOS_DB_FETCH_1()
        {
            /*" -946- EXEC SQL FETCH CRELATORIOS INTO :RELATORI-RAMO-EMISSOR, :RELATORI-NUM-APOLICE , :RELATORI-COD-MOEDA , :RELATORI-PERI-INICIAL, :RELATORI-PERI-FINAL , :RELATORI-COD-USUARIO , :RELATORI-DATA-SOLICITACAO, :WHOST-DATA-INICIO END-EXEC */

            if (CRELATORIOS.Fetch())
            {
                _.Move(CRELATORIOS.RELATORI_RAMO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);
                _.Move(CRELATORIOS.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(CRELATORIOS.RELATORI_COD_MOEDA, RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA);
                _.Move(CRELATORIOS.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
                _.Move(CRELATORIOS.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
                _.Move(CRELATORIOS.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(CRELATORIOS.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(CRELATORIOS.WHOST_DATA_INICIO, WHOST_DATA_INICIO);
            }

        }

        [StopWatch]
        /*" M-0000-00-DECLARE-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_DECLARE_JOIN_HIST_MEST_SECTION()
        {
            /*" -981- MOVE '009' TO WNR-EXEC-SQL */
            _.Move("009", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -1009- PERFORM M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1 */

            M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1();

            /*" -1011- PERFORM M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1 */

            M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1();

            /*" -1014- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1015- DISPLAY 'PROBLEMAS OPEN JOIN-HIST-MEST.. ' */
                _.Display($"PROBLEMAS OPEN JOIN-HIST-MEST.. ");

                /*" -1016- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1016- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0000-00-DECLARE-JOIN-HIST-MEST-DB-OPEN-1 */
        public void M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1()
        {
            /*" -1011- EXEC SQL OPEN JOIN-HIST-MEST END-EXEC */

            JOIN_HIST_MEST.Open();

        }

        [StopWatch]
        /*" M-0000-00-FETCH-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_FETCH_JOIN_HIST_MEST_SECTION()
        {
            /*" -1022- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM M_0000_00_LE_PROXIMO */

            M_0000_00_LE_PROXIMO();

        }

        [StopWatch]
        /*" M-0000-00-LE-PROXIMO */
        private void M_0000_00_LE_PROXIMO(bool isPerform = false)
        {
            /*" -1033- PERFORM M_0000_00_LE_PROXIMO_DB_FETCH_1 */

            M_0000_00_LE_PROXIMO_DB_FETCH_1();

            /*" -1037- DISPLAY '>>> SQLCODE >> ' SQLCODE */
            _.Display($">>> SQLCODE >> {DB.SQLCODE}");

            /*" -1038- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1039- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1040- MOVE 'SIM' TO WFIM-JOIN-HIST-MEST */
                    _.Move("SIM", AREA_DE_WORK.WFIM_JOIN_HIST_MEST);

                    /*" -1041- ELSE */
                }
                else
                {


                    /*" -1042- DISPLAY 'PROBLEMAS NO FETCH DA JOIN-HIST-MEST' */
                    _.Display($"PROBLEMAS NO FETCH DA JOIN-HIST-MEST");

                    /*" -1043- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1044- END-IF */
                }


                /*" -1046- ELSE */
            }
            else
            {


                /*" -1047- PERFORM 0000-00-CALCULA-VALORES */

                M_0000_00_CALCULA_VALORES_SECTION();

                /*" -1048- IF W-VALOR-PENDENTE EQUAL ZEROS */

                if (AREA_DE_WORK.W_VALOR_PENDENTE == 00)
                {

                    /*" -1048- GO TO 0000-00-LE-PROXIMO. */
                    new Task(() => M_0000_00_LE_PROXIMO()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


        }

        [StopWatch]
        /*" M-0000-00-LE-PROXIMO-DB-FETCH-1 */
        public void M_0000_00_LE_PROXIMO_DB_FETCH_1()
        {
            /*" -1033- EXEC SQL FETCH JOIN-HIST-MEST INTO :SINISMES-NUM-APOLICE , :SINISMES-NUM-APOL-SINISTRO, :SINISMES-RAMO , :SINISMES-NUM-CERTIFICADO, :SINISMES-SIT-REGISTRO , :SINISMES-DATA-COMUNICADO END-EXEC */

            if (JOIN_HIST_MEST.Fetch())
            {
                _.Move(JOIN_HIST_MEST.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(JOIN_HIST_MEST.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(JOIN_HIST_MEST.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(JOIN_HIST_MEST.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
                _.Move(JOIN_HIST_MEST.SINISMES_SIT_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);
                _.Move(JOIN_HIST_MEST.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
            }

        }

        [StopWatch]
        /*" M-0000-00-CALCULA-VALORES-SECTION */
        private void M_0000_00_CALCULA_VALORES_SECTION()
        {
            /*" -1057- MOVE '011' TO WNR-EXEC-SQL */
            _.Move("011", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -1059- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -1060- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -1062- MOVE RELATORI-PERI-FINAL TO SI1001S-DATA-FIM */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -1064- CALL 'SI1001S' USING SI1001S-PARAMETROS */
            _.Call("SI1001S", LBSI1001.SI1001S_PARAMETROS);

            /*" -1065- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -1066- DISPLAY 'PROBLEMA CALL SI1001S ' */
                _.Display($"PROBLEMA CALL SI1001S ");

                /*" -1067- DISPLAY 'SQLCODE  - ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE  - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -1068- DISPLAY 'MENSAGEM - ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -1069- DISPLAY ' ' SI1001S-NUM-APOL-SINISTRO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                /*" -1070- DISPLAY ' ' SI1001S-DATA-FIM */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM}");

                /*" -1072- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1073- MOVE SI1001S-VALOR-CALCULADO TO W-VALOR-PENDENTE. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, AREA_DE_WORK.W_VALOR_PENDENTE);

            /*" -1077- DISPLAY 'PENDENTE.... ' W-VALOR-PENDENTE. */
            _.Display($"PENDENTE.... {AREA_DE_WORK.W_VALOR_PENDENTE}");

            /*" -1079- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -1080- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -1082- MOVE RELATORI-PERI-FINAL TO SI1001S-DATA-FIM */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -1084- CALL 'SI1003S' USING SI1001S-PARAMETROS */
            _.Call("SI1003S", LBSI1001.SI1001S_PARAMETROS);

            /*" -1085- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -1086- DISPLAY 'PROBLEMA CALL SI1003S ' */
                _.Display($"PROBLEMA CALL SI1003S ");

                /*" -1087- DISPLAY 'SQLCODE  - ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE  - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -1088- DISPLAY 'MENSAGEM - ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -1089- DISPLAY ' ' SI1001S-NUM-APOL-SINISTRO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                /*" -1090- DISPLAY ' ' SI1001S-DATA-FIM */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM}");

                /*" -1092- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1093- MOVE SI1001S-VALOR-CALCULADO TO W-VALOR-AVISADO. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, AREA_DE_WORK.W_VALOR_AVISADO);

            /*" -1093- DISPLAY 'AVISADO..... ' W-VALOR-AVISADO. */
            _.Display($"AVISADO..... {AREA_DE_WORK.W_VALOR_AVISADO}");

        }

        [StopWatch]
        /*" M-0000-00-CLOSE-JOIN-HIST-MEST-SECTION */
        private void M_0000_00_CLOSE_JOIN_HIST_MEST_SECTION()
        {
            /*" -1101- MOVE '012' TO WNR-EXEC-SQL */
            _.Move("012", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -1101- PERFORM M_0000_00_CLOSE_JOIN_HIST_MEST_DB_CLOSE_1 */

            M_0000_00_CLOSE_JOIN_HIST_MEST_DB_CLOSE_1();

            /*" -1104- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1105- DISPLAY 'PROBLEMAS CLOSE JOIN-HIST-MEST.. ' */
                _.Display($"PROBLEMAS CLOSE JOIN-HIST-MEST.. ");

                /*" -1106- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1106- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0000-00-CLOSE-JOIN-HIST-MEST-DB-CLOSE-1 */
        public void M_0000_00_CLOSE_JOIN_HIST_MEST_DB_CLOSE_1()
        {
            /*" -1101- EXEC SQL CLOSE JOIN-HIST-MEST END-EXEC */

            JOIN_HIST_MEST.Close();

        }

        [StopWatch]
        /*" M-0000-00-SELECT-PAGO-ANT-PER-SECTION */
        private void M_0000_00_SELECT_PAGO_ANT_PER_SECTION()
        {
            /*" -1116- MOVE '013' TO WNR-EXEC-SQL */
            _.Move("013", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -1120- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -1121- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -1123- MOVE WHOST-DATA-INICIO TO SI1001S-DATA-INICIO */
            _.Move(WHOST_DATA_INICIO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_INICIO);

            /*" -1125- CALL 'SI1002S' USING SI1001S-PARAMETROS */
            _.Call("SI1002S", LBSI1001.SI1001S_PARAMETROS);

            /*" -1126- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -1127- DISPLAY 'PROBLEMA CALL SI1002S ' */
                _.Display($"PROBLEMA CALL SI1002S ");

                /*" -1128- DISPLAY 'SQLCODE  - ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE  - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -1129- DISPLAY 'MENSAGEM - ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -1130- DISPLAY ' ' SI1001S-NUM-APOL-SINISTRO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                /*" -1131- DISPLAY ' ' SI1001S-DATA-INICIO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_INICIO}");

                /*" -1133- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1133- MOVE SI1001S-VALOR-CALCULADO TO W-VALOR-PAGO-ANT-PER. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, AREA_DE_WORK.W_VALOR_PAGO_ANT_PER);

        }

        [StopWatch]
        /*" M-0000-00-SELECT-PAGO-NO-PER-SECTION */
        private void M_0000_00_SELECT_PAGO_NO_PER_SECTION()
        {
            /*" -1143- MOVE '014' TO WNR-EXEC-SQL */
            _.Move("014", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -1145- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -1146- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -1147- MOVE RELATORI-PERI-INICIAL TO SI1001S-DATA-INICIO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_INICIO);

            /*" -1149- MOVE RELATORI-PERI-FINAL TO SI1001S-DATA-FIM */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -1151- CALL 'SI1002S' USING SI1001S-PARAMETROS */
            _.Call("SI1002S", LBSI1001.SI1001S_PARAMETROS);

            /*" -1152- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -1153- DISPLAY 'PROBLEMA CALL SI1002S ' */
                _.Display($"PROBLEMA CALL SI1002S ");

                /*" -1154- DISPLAY 'SQLCODE  - ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE  - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -1155- DISPLAY 'MENSAGEM - ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -1156- DISPLAY ' ' SI1001S-NUM-APOL-SINISTRO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                /*" -1157- DISPLAY ' ' SI1001S-DATA-INICIO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_INICIO}");

                /*" -1158- DISPLAY ' ' SI1001S-DATA-FIM */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM}");

                /*" -1160- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1160- MOVE SI1001S-VALOR-CALCULADO TO W-VALOR-PAGO-NO-PER. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, AREA_DE_WORK.W_VALOR_PAGO_NO_PER);

        }

        [StopWatch]
        /*" M-0000-00-DELETE-V1RELATORIOS-SECTION */
        private void M_0000_00_DELETE_V1RELATORIOS_SECTION()
        {
            /*" -1169- MOVE '015' TO WNR-EXEC-SQL */
            _.Move("015", W_MSG_ERROR.WABEND.WNR_EXEC_SQL);

            /*" -1172- PERFORM M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1 */

            M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1();

            /*" -1175- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1176- DISPLAY 'PROBLEMA DELETE V1RELATORIOS' */
                _.Display($"PROBLEMA DELETE V1RELATORIOS");

                /*" -1177- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1177- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0000-00-DELETE-V1RELATORIOS-DB-DELETE-1 */
        public void M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1()
        {
            /*" -1172- EXEC SQL DELETE FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'SI0811B' END-EXEC */

            var m_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1 = new M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1()
            {
            };

            M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1.Execute(m_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1_Delete1);

        }

        [StopWatch]
        /*" M-0000-00-ENCERRA-SECTION */
        private void M_0000_00_ENCERRA_SECTION()
        {
            /*" -1186- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1187-  EVALUATE WCH-FINAL  */

            /*" -1188-  WHEN SPACES  */

            /*" -1188- IF   WCH-FINAL EQUALS  SPACES */

            if (AREA_DE_WORK.WCH_FINAL.IsEmpty())
            {

                /*" -1189- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1190- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1191- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1192- DISPLAY '//     ==>     SI0811B      <==        //' */
                _.Display($"//     ==>     SI0811B      <==        //");

                /*" -1193- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1194- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' */
                _.Display($"//     ==>  TERMINO NORMAL  <==        //");

                /*" -1195- DISPLAY '//                                     //' */
                _.Display($"//                                     //");

                /*" -1196- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1197- DISPLAY '/////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////");

                /*" -1198-  WHEN 'A'  */

                /*" -1198- ELSE IF   WCH-FINAL EQUALS  'A' */
            }
            else

            if (AREA_DE_WORK.WCH_FINAL == "A")
            {

                /*" -1199- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1200- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1201- DISPLAY '*      ==>     SI0811B      <==         *' */
                _.Display($"*      ==>     SI0811B      <==         *");

                /*" -1202- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1203- DISPLAY '*      ==>  TERMINO NORMAL  <==         *' */
                _.Display($"*      ==>  TERMINO NORMAL  <==         *");

                /*" -1204- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1205- DISPLAY '*  NAO HOUVE SOLICITACAO PELO USUARIO,  *' */
                _.Display($"*  NAO HOUVE SOLICITACAO PELO USUARIO,  *");

                /*" -1206- DISPLAY '*  PARA EXECUCAO DO PROGRAMA SI0811B.   *' */
                _.Display($"*  PARA EXECUCAO DO PROGRAMA SI0811B.   *");

                /*" -1207- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1208- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1209-  WHEN 'B'  */

                /*" -1209- ELSE IF   WCH-FINAL EQUALS  'B' */
            }
            else

            if (AREA_DE_WORK.WCH_FINAL == "B")
            {

                /*" -1210- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1211- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1212- DISPLAY '*      ==>     SI0811B      <==         *' */
                _.Display($"*      ==>     SI0811B      <==         *");

                /*" -1213- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1214- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                /*" -1215- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1216- DISPLAY '*  DATA DO SISTEMA NAO FOI ENCONTRADO   *' */
                _.Display($"*  DATA DO SISTEMA NAO FOI ENCONTRADO   *");

                /*" -1217- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1218- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1219-  WHEN 'C'  */

                /*" -1219- ELSE IF   WCH-FINAL EQUALS  'C' */
            }
            else

            if (AREA_DE_WORK.WCH_FINAL == "C")
            {

                /*" -1220- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1221- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1222- DISPLAY '*      ==>     SI0811B      <==         *' */
                _.Display($"*      ==>     SI0811B      <==         *");

                /*" -1223- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1224- DISPLAY '*      ==>  TERMINO NORMAL  <==         *' */
                _.Display($"*      ==>  TERMINO NORMAL  <==         *");

                /*" -1225- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1226- DISPLAY '*  NAO HOUVE NENHUMA SELECAO DE SINISTRO*' */
                _.Display($"*  NAO HOUVE NENHUMA SELECAO DE SINISTRO*");

                /*" -1227- DISPLAY '*  PARA OS PARAMETROS INFORMADOS.       *' */
                _.Display($"*  PARA OS PARAMETROS INFORMADOS.       *");

                /*" -1228- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1229- DISPLAY '*  RAMO   .......... ' RELATORI-RAMO-EMISSOR */
                _.Display($"*  RAMO   .......... {RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR}");

                /*" -1230- DISPLAY '*  APOLICE ......... ' RELATORI-NUM-APOLICE */
                _.Display($"*  APOLICE ......... {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                /*" -1231- DISPLAY '*  PERIODO INCIAL .. ' RELATORI-PERI-INICIAL */
                _.Display($"*  PERIODO INCIAL .. {RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}");

                /*" -1232- DISPLAY '*  PERIODO FINAL  .. ' RELATORI-PERI-FINAL */
                _.Display($"*  PERIODO FINAL  .. {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}");

                /*" -1233- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1234- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1235-  WHEN 'D'  */

                /*" -1235- ELSE IF   WCH-FINAL EQUALS  'D' */
            }
            else

            if (AREA_DE_WORK.WCH_FINAL == "D")
            {

                /*" -1236- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1237- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1238- DISPLAY '*      ==>     SI0811B      <==         *' */
                _.Display($"*      ==>     SI0811B      <==         *");

                /*" -1239- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1240- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                /*" -1241- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1242- DISPLAY '*       EMPRESA NAO CADASTRADA          *' */
                _.Display($"*       EMPRESA NAO CADASTRADA          *");

                /*" -1243- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1244- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1245-  WHEN 'E'  */

                /*" -1245- ELSE IF   WCH-FINAL EQUALS  'E' */
            }
            else

            if (AREA_DE_WORK.WCH_FINAL == "E")
            {

                /*" -1246- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1247- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1248- DISPLAY '*      ==>     SI0811B      <==         *' */
                _.Display($"*      ==>     SI0811B      <==         *");

                /*" -1249- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1250- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                /*" -1251- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1252- DISPLAY '*  PROBLEMA NO LINK PARA A SUBROTINA    *' */
                _.Display($"*  PROBLEMA NO LINK PARA A SUBROTINA    *");

                /*" -1253- DISPLAY '*  PROALN01 PARA ACESSO AO NOME EMPRESA *' */
                _.Display($"*  PROALN01 PARA ACESSO AO NOME EMPRESA *");

                /*" -1254- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1255- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1256-  WHEN 'F'  */

                /*" -1256- ELSE IF   WCH-FINAL EQUALS  'F' */
            }
            else

            if (AREA_DE_WORK.WCH_FINAL == "F")
            {

                /*" -1257- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1258- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1259- DISPLAY '*      ==>     SI0811B      <==         *' */
                _.Display($"*      ==>     SI0811B      <==         *");

                /*" -1260- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1261- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                /*" -1262- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1263- DISPLAY '*  MOEDA SOLICITADA NAO CADASTRADA      *' */
                _.Display($"*  MOEDA SOLICITADA NAO CADASTRADA      *");

                /*" -1264- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1265- DISPLAY '* CODIGO DA MOEDA ..... ' RELATORI-COD-MOEDA */
                _.Display($"* CODIGO DA MOEDA ..... {RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA}");

                /*" -1266- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1267- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1268-  WHEN 'I'  */

                /*" -1269-  WHEN 'G'  */

                /*" -1270-  WHEN 'H'  */

                /*" -1271-  WHEN 'J'  */

                /*" -1271- ELSE IF   WCH-FINAL EQUALS 'I'  OR  'G'   OR  'H' OR  'J' */
            }
            else

            if (AREA_DE_WORK.WCH_FINAL.In("I", "G", "H", "J"))
            {

                /*" -1272- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1273- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1274- DISPLAY '*      ==>     SI0811B      <==         *' */
                _.Display($"*      ==>     SI0811B      <==         *");

                /*" -1275- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1276- DISPLAY '*    ==>   TERMINO ANORMAL    <==       *' */
                _.Display($"*    ==>   TERMINO ANORMAL    <==       *");

                /*" -1277- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1278- DISPLAY '*  COTACAO PARA A DATA DO SISTEMA       *' */
                _.Display($"*  COTACAO PARA A DATA DO SISTEMA       *");

                /*" -1279- DISPLAY '*  NAO CADASTRADA                       *' */
                _.Display($"*  NAO CADASTRADA                       *");

                /*" -1280- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1282- DISPLAY '* CODIGO DA MOEDA ....... ' RELATORI-COD-MOEDA */
                _.Display($"* CODIGO DA MOEDA ....... {RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA}");

                /*" -1284- DISPLAY '* DATA DA MOEDA   ....... ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"* DATA DA MOEDA   ....... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -1285- DISPLAY '* WCH-FINAL       ....... ' WCH-FINAL */
                _.Display($"* WCH-FINAL       ....... {AREA_DE_WORK.WCH_FINAL}");

                /*" -1286- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -1287- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1289-  END-EVALUATE  */

                /*" -1289- END-IF */
            }


            /*" -1290- IF WCH-FINAL NOT EQUAL 'C' */

            if (AREA_DE_WORK.WCH_FINAL != "C")
            {

                /*" -1291- CLOSE RSI0811B */
                RSI0811B.Close();

                /*" -1292- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1292- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1301- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1302- DISPLAY ' ' */
                _.Display($" ");

                /*" -1303- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1304- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0811B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0811B  *");

                /*" -1305- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -1306- DISPLAY ' ' */
                _.Display($" ");

                /*" -1307- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {W_MSG_ERROR.WABEND.WNR_EXEC_SQL}");

                /*" -1308- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W_MSG_ERROR.WABEND.WSQLCODE);

                /*" -1309- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W_MSG_ERROR.WABEND.WSQLCODE1);

                /*" -1310- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W_MSG_ERROR.WABEND.WSQLCODE2);

                /*" -1311- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, W_MSG_ERROR.WSQLCODE3);

                /*" -1313- DISPLAY WABEND. */
                _.Display(W_MSG_ERROR.WABEND);
            }


            /*" -1315- CLOSE RSI0811B. */
            RSI0811B.Close();

            /*" -1315- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1318- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1318- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}