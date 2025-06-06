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
using Sias.Sinistro.DB2.SI0861B;

namespace Code
{
    public class SI0861B
    {
        public bool IsCall { get; set; }

        public SI0861B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINSITROS                          *      */
        /*"      *   PROGRAMA ...............  SI0861B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  HEIDER COELHO                      *      */
        /*"      *   CRIACAO ................  19/04/2001.                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ..... GERAR O ARQUIVO DE SINISTROS PAGOS E PENDENTES  *      */
        /*"      *    PARAMETROS DE SELECAO:                                      *      */
        /*"      *        APOLICE OU RAMO OU PRODUTO OU SUBGRUPO                  *      */
        /*"      *        PARA PERIODO SOLICITADO                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 06/04/2005 - PRODEXTER                                         *      */
        /*"      * (1) SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO *      */
        /*"      * (2) SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A   *      */
        /*"      * SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO     *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQ_SAIDA { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis ARQ_SAIDA
        {
            get
            {
                _.Move(REG_ARQ_SAIDA, _ARQ_SAIDA); VarBasis.RedefinePassValue(REG_ARQ_SAIDA, _ARQ_SAIDA, REG_ARQ_SAIDA); return _ARQ_SAIDA;
            }
        }
        /*"01  REG-ARQ-SAIDA                  PIC X(150).*/
        public StringBasis REG_ARQ_SAIDA { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-DATA-INICIAL                 PIC  X(10).*/
        public StringBasis HOST_DATA_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-DATA-FINAL                   PIC  X(10).*/
        public StringBasis HOST_DATA_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-APOLICE-INICIAL              PIC S9(13) COMP-3 VALUE +0*/
        public IntBasis HOST_APOLICE_INICIAL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-APOLICE-FINAL                PIC S9(13) COMP-3 VALUE +0*/
        public IntBasis HOST_APOLICE_FINAL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-PRODUTO-INICIAL              PIC S9(04) COMP   VALUE +0*/
        public IntBasis HOST_PRODUTO_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-PRODUTO-FINAL                PIC S9(04) COMP   VALUE +0*/
        public IntBasis HOST_PRODUTO_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-CODSUBES-INICIAL             PIC S9(04) COMP   VALUE +0*/
        public IntBasis HOST_CODSUBES_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-CODSUBES-FINAL               PIC S9(04) COMP   VALUE +0*/
        public IntBasis HOST_CODSUBES_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-RAMO-INICIAL                 PIC S9(04) COMP   VALUE +0*/
        public IntBasis HOST_RAMO_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-RAMO-FINAL                   PIC S9(04) COMP   VALUE +0*/
        public IntBasis HOST_RAMO_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-FONTE                        PIC S9(04) COMP   VALUE +0*/
        public IntBasis HOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-QTD-PAGO                 PIC S9(13)    COMP-3 VALUE +0.*/
        public IntBasis HOST_QTD_PAGO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-VAL-PAGO                 PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-QTD-PENDENTE             PIC S9(13)    COMP-3 VALUE +0.*/
        public IntBasis HOST_QTD_PENDENTE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-VAL-PENDENTE             PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VAL_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  AREA-DE-WORK.*/
        public SI0861B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0861B_AREA_DE_WORK();
        public class SI0861B_AREA_DE_WORK : VarBasis
        {
            /*"   05 WSL-SQLCODE                    PIC  9(009) VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"01  W-INICIO-WORK.*/
        }
        public SI0861B_W_INICIO_WORK W_INICIO_WORK { get; set; } = new SI0861B_W_INICIO_WORK();
        public class SI0861B_W_INICIO_WORK : VarBasis
        {
            /*"    03 W-FIM-PAGO                     PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_PAGO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-FIM-PENDENTE                 PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_PENDENTE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-FIM-RELATORIO                PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_RELATORIO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-CHAVE-ARQ-SAIDA-JA-ABERTO    PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_CHAVE_ARQ_SAIDA_JA_ABERTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-IND                          PIC 9(03)  VALUE ZEROS.*/
            public IntBasis W_IND { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    03 W-CONTADOR-USUARIO             PIC 9(13)  VALUE ZEROS.*/
            public IntBasis W_CONTADOR_USUARIO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03 W-CONTADOR-GERAL               PIC 9(13)  VALUE ZEROS.*/
            public IntBasis W_CONTADOR_GERAL { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03 W-TABELA1.*/
            public SI0861B_W_TABELA1 W_TABELA1 { get; set; } = new SI0861B_W_TABELA1();
            public class SI0861B_W_TABELA1 : VarBasis
            {
                /*"    05 W-TABELA-NOSSA-LIDERANCA    OCCURS  100  TIMES.*/
                public ListBasis<SI0861B_W_TABELA_NOSSA_LIDERANCA> W_TABELA_NOSSA_LIDERANCA { get; set; } = new ListBasis<SI0861B_W_TABELA_NOSSA_LIDERANCA>(100);
                public class SI0861B_W_TABELA_NOSSA_LIDERANCA : VarBasis
                {
                    /*"       10 W-TAB-FONTE              PIC S9(03)    VALUE ZEROS.*/
                    public IntBasis W_TAB_FONTE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
                    /*"       10 W-TAB-QTD-PAGO           PIC S9(13)    VALUE ZEROS.*/
                    public IntBasis W_TAB_QTD_PAGO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                    /*"       10 W-TAB-VAL-PAGO           PIC S9(13)V99 VALUE ZEROS.*/
                    public DoubleBasis W_TAB_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                    /*"       10 W-TAB-QTD-PENDENTE       PIC S9(13)    VALUE ZEROS.*/
                    public IntBasis W_TAB_QTD_PENDENTE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                    /*"       10 W-TAB-VAL-PENDENTE       PIC S9(13)V99 VALUE ZEROS.*/
                    public DoubleBasis W_TAB_VAL_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                    /*"    03 W-TABELA2.*/
                }
                public SI0861B_W_TABELA2 W_TABELA2 { get; set; } = new SI0861B_W_TABELA2();
                public class SI0861B_W_TABELA2 : VarBasis
                {
                    /*"    05 W-TABELA-COSSEGURO-ACEITO   OCCURS  100  TIMES.*/
                    public ListBasis<SI0861B_W_TABELA_COSSEGURO_ACEITO> W_TABELA_COSSEGURO_ACEITO { get; set; } = new ListBasis<SI0861B_W_TABELA_COSSEGURO_ACEITO>(100);
                    public class SI0861B_W_TABELA_COSSEGURO_ACEITO : VarBasis
                    {
                        /*"       10 W-TAB-ACE-FONTE          PIC S9(03)    VALUE ZEROS.*/
                        public IntBasis W_TAB_ACE_FONTE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
                        /*"       10 W-TAB-ACE-QTD-PAGO       PIC S9(13)    VALUE ZEROS.*/
                        public IntBasis W_TAB_ACE_QTD_PAGO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                        /*"       10 W-TAB-ACE-VAL-PAGO       PIC S9(13)V99 VALUE ZEROS.*/
                        public DoubleBasis W_TAB_ACE_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                        /*"       10 W-TAB-ACE-QTD-PENDENTE   PIC S9(13)    VALUE ZEROS.*/
                        public IntBasis W_TAB_ACE_QTD_PENDENTE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                        /*"       10 W-TAB-ACE-VAL-PENDENTE   PIC S9(13)V99 VALUE ZEROS.*/
                        public DoubleBasis W_TAB_ACE_VAL_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                        /*"01  FILLER.*/
                    }
                }
                public SI0861B_FILLER_0 FILLER_0 { get; set; } = new SI0861B_FILLER_0();
                public class SI0861B_FILLER_0 : VarBasis
                {
                    /*"    05 WABEND.*/
                    public SI0861B_WABEND WABEND { get; set; } = new SI0861B_WABEND();
                    public class SI0861B_WABEND : VarBasis
                    {
                        /*"       10 FILLER                     PIC  X(009) VALUE          'SI0861B '.*/
                        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0861B ");
                        /*"       10 FILLER                     PIC  X(035) VALUE          ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
                        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
                        /*"       10 WNR-EXEC-SQL               PIC  X(003) VALUE '000'.*/
                        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                        /*"       10 FILLER                     PIC  X(013) VALUE          ' *** SQLCODE '.*/
                        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                        /*"       10 WSQLCODE                   PIC  ZZZZZ999- VALUE ZEROS.*/
                        public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                        /*"01  C01.*/
                    }
                }
                public SI0861B_C01 C01 { get; set; } = new SI0861B_C01();
                public class SI0861B_C01 : VarBasis
                {
                    /*"    03 C01-CODUSU                PIC  X(08) VALUE SPACES.*/
                    public StringBasis C01_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C01-NOME                  PIC  X(40) VALUE SPACES.*/
                    public StringBasis C01_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(80) VALUE       'SINISTRO - RELATORIO DE SINISTRALIDADE'.*/
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"SINISTRO - RELATORIO DE SINISTRALIDADE");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C01-FILLER                PIC  X(40) VALUE SPACES.*/
                    public StringBasis C01_FILLER { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"01  C02.*/
                }
                public SI0861B_C02 C02 { get; set; } = new SI0861B_C02();
                public class SI0861B_C02 : VarBasis
                {
                    /*"    03 C02-CODUSU                PIC  X(08) VALUE SPACES.*/
                    public StringBasis C02_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C02-NOME                  PIC  X(40) VALUE SPACES.*/
                    public StringBasis C02_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(14) VALUE       'PROCESSADO EM:'.*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"PROCESSADO EM:");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C02-DATA                  PIC  X(10) VALUE SPACES.*/
                    public StringBasis C02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(26) VALUE       'SOLICITACOES EFETUADAS EM:'.*/
                    public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"SOLICITACOES EFETUADAS EM:");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C02-DATA1                 PIC  X(10) VALUE SPACES.*/
                    public StringBasis C02_DATA1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"01  C03.*/
                }
                public SI0861B_C03 C03 { get; set; } = new SI0861B_C03();
                public class SI0861B_C03 : VarBasis
                {
                    /*"    03 C03-CODUSU                PIC  X(08) VALUE SPACES.*/
                    public StringBasis C03_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C03-NOME                  PIC  X(40) VALUE SPACES.*/
                    public StringBasis C03_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(13) VALUE       'APOLICE'.*/
                    public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"APOLICE");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C03-APOLICE               PIC  X(20) VALUE SPACES.*/
                    public StringBasis C03_APOLICE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"01  C04.*/
                }
                public SI0861B_C04 C04 { get; set; } = new SI0861B_C04();
                public class SI0861B_C04 : VarBasis
                {
                    /*"    03 C04-CODUSU                PIC  X(08) VALUE SPACES.*/
                    public StringBasis C04_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C04-NOME                  PIC  X(40) VALUE SPACES.*/
                    public StringBasis C04_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(13) VALUE       'RAMO'.*/
                    public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"RAMO");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C04-RAMO                  PIC  X(20) VALUE SPACES.*/
                    public StringBasis C04_RAMO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"01  C05.*/
                }
                public SI0861B_C05 C05 { get; set; } = new SI0861B_C05();
                public class SI0861B_C05 : VarBasis
                {
                    /*"    03 C05-CODUSU                PIC  X(08) VALUE SPACES.*/
                    public StringBasis C05_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C05-NOME                  PIC  X(40) VALUE SPACES.*/
                    public StringBasis C05_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(13) VALUE       'PRODUTO'.*/
                    public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"PRODUTO");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C05-PRODUTO               PIC  X(20) VALUE SPACES.*/
                    public StringBasis C05_PRODUTO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"01  C06.*/
                }
                public SI0861B_C06 C06 { get; set; } = new SI0861B_C06();
                public class SI0861B_C06 : VarBasis
                {
                    /*"    03 C06-CODUSU                PIC  X(08) VALUE SPACES.*/
                    public StringBasis C06_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C06-NOME                  PIC  X(40) VALUE SPACES.*/
                    public StringBasis C06_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(13) VALUE       'SUB-GRUPO'.*/
                    public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"SUB-GRUPO");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C06-SUBGRUPO              PIC  X(20) VALUE SPACES.*/
                    public StringBasis C06_SUBGRUPO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"01  C07.*/
                }
                public SI0861B_C07 C07 { get; set; } = new SI0861B_C07();
                public class SI0861B_C07 : VarBasis
                {
                    /*"    03 C07-CODUSU                PIC  X(08) VALUE SPACES.*/
                    public StringBasis C07_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C07-NOME                  PIC  X(40) VALUE SPACES.*/
                    public StringBasis C07_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(20) VALUE       'PAGOS NO PERIODO DE:'.*/
                    public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"PAGOS NO PERIODO DE:");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C07-DATA-INICIAL          PIC  X(10) VALUE SPACES.*/
                    public StringBasis C07_DATA_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(03) VALUE 'A'.*/
                    public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"A");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C07-DATA-FINAL            PIC  X(10) VALUE SPACES.*/
                    public StringBasis C07_DATA_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"01  C08.*/
                }
                public SI0861B_C08 C08 { get; set; } = new SI0861B_C08();
                public class SI0861B_C08 : VarBasis
                {
                    /*"    03 C08-CODUSU                PIC  X(08) VALUE SPACES.*/
                    public StringBasis C08_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C08-NOME                  PIC  X(40) VALUE SPACES.*/
                    public StringBasis C08_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(13) VALUE       'PENDENTES EM:'.*/
                    public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"PENDENTES EM:");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C08-DATA-FINAL            PIC  X(10) VALUE SPACES.*/
                    public StringBasis C08_DATA_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"01  C09.*/
                }
                public SI0861B_C09 C09 { get; set; } = new SI0861B_C09();
                public class SI0861B_C09 : VarBasis
                {
                    /*"    03 C09-CODUSU                PIC  X(08) VALUE SPACES.*/
                    public StringBasis C09_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 C09-NOME                  PIC  X(40) VALUE SPACES.*/
                    public StringBasis C09_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(30) VALUE 'TIPO SEGURO'.*/
                    public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"TIPO SEGURO");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(05) VALUE 'FONTE'.*/
                    public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"FONTE");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(13) VALUE 'QTD. PAGO'.*/
                    public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"QTD. PAGO");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(16) VALUE 'VAL. PAGO'.*/
                    public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"VAL. PAGO");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(13) VALUE 'QTD. PEND.'.*/
                    public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"QTD. PEND.");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 FILLER                    PIC  X(16) VALUE 'VAL. PEND.'.*/
                    public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"VAL. PEND.");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"01  LD01.*/
                }
                public SI0861B_LD01 LD01 { get; set; } = new SI0861B_LD01();
                public class SI0861B_LD01 : VarBasis
                {
                    /*"    03 LD01-CODUSU               PIC  X(08) VALUE SPACES.*/
                    public StringBasis LD01_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 LD01-NOME                 PIC  X(40) VALUE SPACES.*/
                    public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 LD01-TIPO-SEGURO          PIC  X(30) VALUE SPACES.*/
                    public StringBasis LD01_TIPO_SEGURO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 LD01-FONTE                PIC  --999.*/
                    public IntBasis LD01_FONTE { get; set; } = new IntBasis(new PIC("9", "5", "--999."));
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 LD01-QTD-PAGO             PIC  ------------9.*/
                    public IntBasis LD01_QTD_PAGO { get; set; } = new IntBasis(new PIC("9", "13", "------------9."));
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 LD01-VAL-PAGO             PIC  ------------9,99.*/
                    public DoubleBasis LD01_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 LD01-QTD-PENDENTE         PIC  ------------9.*/
                    public IntBasis LD01_QTD_PENDENTE { get; set; } = new IntBasis(new PIC("9", "13", "------------9."));
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                    /*"    03 LD01-VAL-PENDENTE         PIC  ------------9,99.*/
                    public DoubleBasis LD01_VAL_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                    /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                    public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                }
            }
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public SI0861B_RELATORIOS RELATORIOS { get; set; } = new SI0861B_RELATORIOS();
        public SI0861B_PAGO PAGO { get; set; } = new SI0861B_PAGO();
        public SI0861B_PENDENTE PENDENTE { get; set; } = new SI0861B_PENDENTE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQ_SAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQ_SAIDA.SetFile(ARQ_SAIDA_FILE_NAME_P);

                /*" -288- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC */

                /*" -289- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC */

                /*" -290- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC */

                /*" -294- MOVE 'NAO' TO W-CHAVE-ARQ-SAIDA-JA-ABERTO */
                _.Move("NAO", W_INICIO_WORK.W_CHAVE_ARQ_SAIDA_JA_ABERTO);

                /*" -296- PERFORM R010-SELECT-SISTEMA THRU R010-EXIT. */

                R010_SELECT_SISTEMA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -297- PERFORM R020-DECLARE-RELATORIO THRU R020-EXIT. */

                R020_DECLARE_RELATORIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -298- MOVE 'NAO' TO W-FIM-RELATORIO. */
                _.Move("NAO", W_INICIO_WORK.W_FIM_RELATORIO);

                /*" -300- PERFORM R021-FETCH-RELATORIO THRU R021-EXIT. */

                R021_FETCH_RELATORIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


                /*" -301- IF W-FIM-RELATORIO EQUAL 'SIM' */

                if (W_INICIO_WORK.W_FIM_RELATORIO == "SIM")
                {

                    /*" -302- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -303- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -304- DISPLAY '       NADA SELECIONADO NA DATA DE HOJE         ' */
                    _.Display($"       NADA SELECIONADO NA DATA DE HOJE         ");

                    /*" -305- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -306- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -307- OPEN OUTPUT ARQ-SAIDA */
                    ARQ_SAIDA.Open(REG_ARQ_SAIDA);

                    /*" -308- MOVE 'NAO HOUVE SOLICITACAO NA DATA DE HOJE' TO C01-FILLER */
                    _.Move("NAO HOUVE SOLICITACAO NA DATA DE HOJE", W_INICIO_WORK.W_TABELA1.C01.C01_FILLER);

                    /*" -309- WRITE REG-ARQ-SAIDA FROM C01 */
                    _.Move(W_INICIO_WORK.W_TABELA1.C01.GetMoveValues(), REG_ARQ_SAIDA);

                    ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                    /*" -310- CLOSE ARQ-SAIDA */
                    ARQ_SAIDA.Close();

                    /*" -312- GO TO 000-TERMINA. */

                    M_000_TERMINA(); //GOTO
                    return Result;
                }


                /*" -315- PERFORM R030-PROCESSA-RELATORIO THRU R030-EXIT UNTIL (W-FIM-RELATORIO EQUAL 'SIM' ). */

                while (!((W_INICIO_WORK.W_FIM_RELATORIO == "SIM")))
                {

                    R030_PROCESSA_RELATORIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

                }

                /*" -317- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", W_INICIO_WORK.W_TABELA1.FILLER_0.WABEND.WNR_EXEC_SQL);

                /*" -323- PERFORM Execute_DB_UPDATE_1 */

                Execute_DB_UPDATE_1();

                /*" -326- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -327- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -328- DISPLAY 'ERRO NO UPDATE RELATORIOS.......' */
                    _.Display($"ERRO NO UPDATE RELATORIOS.......");

                    /*" -329- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -329- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -329- FLUXCONTROL_PERFORM Execute-DB-UPDATE-1 */

                Execute_DB_UPDATE_1();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-UPDATE-1 */
        public void Execute_DB_UPDATE_1()
        {
            /*" -323- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE IDE_SISTEMA = 'SI' AND COD_RELATORIO = 'SI0861B' AND SIT_REGISTRO = '0' END-EXEC. */

            var execute_DB_UPDATE_1_Update1 = new Execute_DB_UPDATE_1_Update1()
            {
            };

            Execute_DB_UPDATE_1_Update1.Execute(execute_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-000-TERMINA */
        private void M_000_TERMINA(bool isPerform = false)
        {
            /*" -334- DISPLAY '************************************' */
            _.Display($"************************************");

            /*" -335- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -336- DISPLAY '*   TERMINO NORMAL DO PROGRAMA     *' */
            _.Display($"*   TERMINO NORMAL DO PROGRAMA     *");

            /*" -337- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -338- DISPLAY '*            SI0861B               *' */
            _.Display($"*            SI0861B               *");

            /*" -339- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -339- DISPLAY '************************************' . */
            _.Display($"************************************");

        }

        [StopWatch]
        /*" M-000-FIM-PROGRAMA */
        private void M_000_FIM_PROGRAMA(bool isPerform = false)
        {
            /*" -344- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -344- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R010-SELECT-SISTEMA */
        private void R010_SELECT_SISTEMA(bool isPerform = false)
        {
            /*" -350- MOVE '002' TO WNR-EXEC-SQL */
            _.Move("002", W_INICIO_WORK.W_TABELA1.FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -355- PERFORM R010_SELECT_SISTEMA_DB_SELECT_1 */

            R010_SELECT_SISTEMA_DB_SELECT_1();

            /*" -358- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -359- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -360- DISPLAY 'ERRO NO ACESSO - SISTEMA .......' */
                _.Display($"ERRO NO ACESSO - SISTEMA .......");

                /*" -361- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -362- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -363- ELSE */
            }
            else
            {


                /*" -364- MOVE SISTEMAS-DATA-MOV-ABERTO(09:02) TO C02-DATA(01:02) */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), W_INICIO_WORK.W_TABELA1.C02.C02_DATA, 1, 2);

                /*" -365- MOVE '/' TO C02-DATA(03:01) */
                _.MoveAtPosition("/", W_INICIO_WORK.W_TABELA1.C02.C02_DATA, 3, 1);

                /*" -366- MOVE SISTEMAS-DATA-MOV-ABERTO(06:02) TO C02-DATA(04:02) */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), W_INICIO_WORK.W_TABELA1.C02.C02_DATA, 4, 2);

                /*" -367- MOVE '/' TO C02-DATA(06:01) */
                _.MoveAtPosition("/", W_INICIO_WORK.W_TABELA1.C02.C02_DATA, 6, 1);

                /*" -368- MOVE SISTEMAS-DATA-MOV-ABERTO(01:04) TO C02-DATA(07:04) */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), W_INICIO_WORK.W_TABELA1.C02.C02_DATA, 7, 4);

                /*" -368- END-IF. */
            }


        }

        [StopWatch]
        /*" R010-SELECT-SISTEMA-DB-SELECT-1 */
        public void R010_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -355- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC */

            var r010_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R010_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R010_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r010_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-DECLARE-RELATORIO */
        private void R020_DECLARE_RELATORIO(bool isPerform = false)
        {
            /*" -376- MOVE '003' TO WNR-EXEC-SQL */
            _.Move("003", W_INICIO_WORK.W_TABELA1.FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -397- PERFORM R020_DECLARE_RELATORIO_DB_DECLARE_1 */

            R020_DECLARE_RELATORIO_DB_DECLARE_1();

            /*" -399- PERFORM R020_DECLARE_RELATORIO_DB_OPEN_1 */

            R020_DECLARE_RELATORIO_DB_OPEN_1();

        }

        [StopWatch]
        /*" R020-DECLARE-RELATORIO-DB-DECLARE-1 */
        public void R020_DECLARE_RELATORIO_DB_DECLARE_1()
        {
            /*" -397- EXEC SQL DECLARE RELATORIOS CURSOR FOR SELECT COD_USUARIO, DATA_SOLICITACAO, PERI_INICIAL, PERI_FINAL, RAMO_EMISSOR, COD_SUBGRUPO, NUM_APOLICE, COD_FONTE FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'SI' AND COD_RELATORIO = 'SI0861B' AND SIT_REGISTRO = '0' ORDER BY DATA_SOLICITACAO, RAMO_EMISSOR, NUM_APOLICE, COD_SUBGRUPO, PERI_INICIAL, PERI_FINAL WITH UR END-EXEC */
            RELATORIOS = new SI0861B_RELATORIOS(false);
            string GetQuery_RELATORIOS()
            {
                var query = @$"SELECT COD_USUARIO
							, 
							DATA_SOLICITACAO
							, 
							PERI_INICIAL
							, 
							PERI_FINAL
							, 
							RAMO_EMISSOR
							, 
							COD_SUBGRUPO
							, 
							NUM_APOLICE
							, 
							COD_FONTE 
							FROM SEGUROS.RELATORIOS 
							WHERE IDE_SISTEMA = 'SI' 
							AND COD_RELATORIO = 'SI0861B' 
							AND SIT_REGISTRO = '0' 
							ORDER BY DATA_SOLICITACAO
							, 
							RAMO_EMISSOR
							, 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							PERI_INICIAL
							, 
							PERI_FINAL";

                return query;
            }
            RELATORIOS.GetQueryEvent += GetQuery_RELATORIOS;

        }

        [StopWatch]
        /*" R020-DECLARE-RELATORIO-DB-OPEN-1 */
        public void R020_DECLARE_RELATORIO_DB_OPEN_1()
        {
            /*" -399- EXEC SQL OPEN RELATORIOS END-EXEC. */

            RELATORIOS.Open();

        }

        [StopWatch]
        /*" R100-DECLARE-PAGO-DB-DECLARE-1 */
        public void R100_DECLARE_PAGO_DB_DECLARE_1()
        {
            /*" -681- EXEC SQL DECLARE PAGO CURSOR FOR SELECT M.TIPO_REGISTRO, E.COD_FONTE, M.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.ENDOSSOS E, SEGUROS.GE_OPERACAO O, SEGUROS.SINISTRO_MESTRE M WHERE H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL AND M.NUM_APOLICE BETWEEN :HOST-APOLICE-INICIAL AND :HOST-APOLICE-FINAL AND M.RAMO BETWEEN :HOST-RAMO-INICIAL AND :HOST-RAMO-FINAL AND M.COD_SUBGRUPO BETWEEN :HOST-CODSUBES-INICIAL AND :HOST-CODSUBES-FINAL AND M.COD_PRODUTO BETWEEN :HOST-PRODUTO-INICIAL AND :HOST-PRODUTO-FINAL AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND O.IDE_SISTEMA = 'SI' AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IND_TIPO_FUNCAO = 'IN' AND E.NUM_APOLICE = M.NUM_APOLICE AND E.NUM_ENDOSSO = 0 AND E.COD_FONTE <> 0 GROUP BY M.TIPO_REGISTRO, E.COD_FONTE, M.NUM_APOL_SINISTRO ORDER BY M.TIPO_REGISTRO, E.COD_FONTE, M.NUM_APOL_SINISTRO WITH UR END-EXEC. */
            PAGO = new SI0861B_PAGO(true);
            string GetQuery_PAGO()
            {
                var query = @$"SELECT M.TIPO_REGISTRO
							, 
							E.COD_FONTE
							, 
							M.NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.ENDOSSOS E
							, 
							SEGUROS.GE_OPERACAO O
							, 
							SEGUROS.SINISTRO_MESTRE M 
							WHERE H.DATA_MOVIMENTO BETWEEN '{HOST_DATA_INICIAL}' 
							AND '{HOST_DATA_FINAL}' 
							AND M.NUM_APOLICE BETWEEN '{HOST_APOLICE_INICIAL}' 
							AND '{HOST_APOLICE_FINAL}' 
							AND M.RAMO BETWEEN '{HOST_RAMO_INICIAL}' 
							AND '{HOST_RAMO_FINAL}' 
							AND M.COD_SUBGRUPO BETWEEN '{HOST_CODSUBES_INICIAL}' 
							AND '{HOST_CODSUBES_FINAL}' 
							AND M.COD_PRODUTO BETWEEN '{HOST_PRODUTO_INICIAL}' 
							AND '{HOST_PRODUTO_FINAL}' 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.COD_OPERACAO = H.COD_OPERACAO 
							AND O.IND_TIPO_FUNCAO = 'IN' 
							AND E.NUM_APOLICE = M.NUM_APOLICE 
							AND E.NUM_ENDOSSO = 0 
							AND E.COD_FONTE <> 0 
							GROUP BY M.TIPO_REGISTRO
							, E.COD_FONTE
							, M.NUM_APOL_SINISTRO 
							ORDER BY M.TIPO_REGISTRO
							, E.COD_FONTE
							, M.NUM_APOL_SINISTRO";

                return query;
            }
            PAGO.GetQueryEvent += GetQuery_PAGO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R021-FETCH-RELATORIO */
        private void R021_FETCH_RELATORIO(bool isPerform = false)
        {
            /*" -407- MOVE '004' TO WNR-EXEC-SQL */
            _.Move("004", W_INICIO_WORK.W_TABELA1.FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -416- PERFORM R021_FETCH_RELATORIO_DB_FETCH_1 */

            R021_FETCH_RELATORIO_DB_FETCH_1();

            /*" -419- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -420- MOVE 'SIM' TO W-FIM-RELATORIO */
                _.Move("SIM", W_INICIO_WORK.W_FIM_RELATORIO);

                /*" -420- PERFORM R021_FETCH_RELATORIO_DB_CLOSE_1 */

                R021_FETCH_RELATORIO_DB_CLOSE_1();

                /*" -423- GO TO R021-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/ //GOTO
                return;
            }


            /*" -424- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -425- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -426- DISPLAY 'ERRO FETCH NA RELATORIOS...........' */
                _.Display($"ERRO FETCH NA RELATORIOS...........");

                /*" -427- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -429- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -435- MOVE ALL '*' TO C01-NOME C02-NOME C03-NOME C04-NOME C05-NOME C06-NOME C07-NOME C08-NOME C09-NOME LD01-NOME */
            _.MoveAll("*", W_INICIO_WORK.W_TABELA1.C01.C01_NOME, W_INICIO_WORK.W_TABELA1.C02.C02_NOME, W_INICIO_WORK.W_TABELA1.C03.C03_NOME, W_INICIO_WORK.W_TABELA1.C04.C04_NOME, W_INICIO_WORK.W_TABELA1.C05.C05_NOME, W_INICIO_WORK.W_TABELA1.C06.C06_NOME, W_INICIO_WORK.W_TABELA1.C07.C07_NOME, W_INICIO_WORK.W_TABELA1.C08.C08_NOME, W_INICIO_WORK.W_TABELA1.C09.C09_NOME, W_INICIO_WORK.W_TABELA1.LD01.LD01_NOME);

            /*" -441- MOVE RELATORI-COD-USUARIO TO C01-CODUSU C02-CODUSU C03-CODUSU C04-CODUSU C05-CODUSU C06-CODUSU C07-CODUSU C08-CODUSU C09-CODUSU LD01-CODUSU. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, W_INICIO_WORK.W_TABELA1.C01.C01_CODUSU, W_INICIO_WORK.W_TABELA1.C02.C02_CODUSU, W_INICIO_WORK.W_TABELA1.C03.C03_CODUSU, W_INICIO_WORK.W_TABELA1.C04.C04_CODUSU, W_INICIO_WORK.W_TABELA1.C05.C05_CODUSU, W_INICIO_WORK.W_TABELA1.C06.C06_CODUSU, W_INICIO_WORK.W_TABELA1.C07.C07_CODUSU, W_INICIO_WORK.W_TABELA1.C08.C08_CODUSU, W_INICIO_WORK.W_TABELA1.C09.C09_CODUSU, W_INICIO_WORK.W_TABELA1.LD01.LD01_CODUSU);

            /*" -442- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", W_INICIO_WORK.W_TABELA1.FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -447- PERFORM R021_FETCH_RELATORIO_DB_SELECT_1 */

            R021_FETCH_RELATORIO_DB_SELECT_1();

            /*" -454- MOVE USUARIOS-NOME-USUARIO TO C01-NOME C02-NOME C03-NOME C04-NOME C05-NOME C06-NOME C07-NOME C08-NOME C09-NOME LD01-NOME */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, W_INICIO_WORK.W_TABELA1.C01.C01_NOME, W_INICIO_WORK.W_TABELA1.C02.C02_NOME, W_INICIO_WORK.W_TABELA1.C03.C03_NOME, W_INICIO_WORK.W_TABELA1.C04.C04_NOME, W_INICIO_WORK.W_TABELA1.C05.C05_NOME, W_INICIO_WORK.W_TABELA1.C06.C06_NOME, W_INICIO_WORK.W_TABELA1.C07.C07_NOME, W_INICIO_WORK.W_TABELA1.C08.C08_NOME, W_INICIO_WORK.W_TABELA1.C09.C09_NOME, W_INICIO_WORK.W_TABELA1.LD01.LD01_NOME);

            /*" -460- MOVE RELATORI-COD-USUARIO TO C01-CODUSU C02-CODUSU C03-CODUSU C04-CODUSU C05-CODUSU C06-CODUSU C07-CODUSU C08-CODUSU C09-CODUSU LD01-CODUSU */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, W_INICIO_WORK.W_TABELA1.C01.C01_CODUSU, W_INICIO_WORK.W_TABELA1.C02.C02_CODUSU, W_INICIO_WORK.W_TABELA1.C03.C03_CODUSU, W_INICIO_WORK.W_TABELA1.C04.C04_CODUSU, W_INICIO_WORK.W_TABELA1.C05.C05_CODUSU, W_INICIO_WORK.W_TABELA1.C06.C06_CODUSU, W_INICIO_WORK.W_TABELA1.C07.C07_CODUSU, W_INICIO_WORK.W_TABELA1.C08.C08_CODUSU, W_INICIO_WORK.W_TABELA1.C09.C09_CODUSU, W_INICIO_WORK.W_TABELA1.LD01.LD01_CODUSU);

            /*" -461- MOVE RELATORI-DATA-SOLICITACAO(09:02) TO C02-DATA1(01:02) */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(9, 2), W_INICIO_WORK.W_TABELA1.C02.C02_DATA1, 1, 2);

            /*" -462- MOVE '/' TO C02-DATA1(03:01) */
            _.MoveAtPosition("/", W_INICIO_WORK.W_TABELA1.C02.C02_DATA1, 3, 1);

            /*" -463- MOVE RELATORI-DATA-SOLICITACAO(06:02) TO C02-DATA1(04:02) */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(6, 2), W_INICIO_WORK.W_TABELA1.C02.C02_DATA1, 4, 2);

            /*" -464- MOVE '/' TO C02-DATA1(06:01) */
            _.MoveAtPosition("/", W_INICIO_WORK.W_TABELA1.C02.C02_DATA1, 6, 1);

            /*" -465- MOVE RELATORI-DATA-SOLICITACAO(01:04) TO C02-DATA1(07:04) */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(1, 4), W_INICIO_WORK.W_TABELA1.C02.C02_DATA1, 7, 4);

            /*" -466- IF HOST-RAMO-INICIAL EQUAL ZERO */

            if (HOST_RAMO_INICIAL == 00)
            {

                /*" -467- MOVE 99 TO HOST-RAMO-FINAL */
                _.Move(99, HOST_RAMO_FINAL);

                /*" -468- ELSE */
            }
            else
            {


                /*" -469- MOVE HOST-RAMO-INICIAL TO HOST-RAMO-FINAL */
                _.Move(HOST_RAMO_INICIAL, HOST_RAMO_FINAL);

                /*" -470- END-IF */
            }


            /*" -471- IF HOST-CODSUBES-INICIAL EQUAL 0 */

            if (HOST_CODSUBES_INICIAL == 0)
            {

                /*" -472- MOVE 9999 TO HOST-CODSUBES-FINAL */
                _.Move(9999, HOST_CODSUBES_FINAL);

                /*" -473- ELSE */
            }
            else
            {


                /*" -474- MOVE HOST-CODSUBES-INICIAL TO HOST-CODSUBES-FINAL */
                _.Move(HOST_CODSUBES_INICIAL, HOST_CODSUBES_FINAL);

                /*" -475- END-IF */
            }


            /*" -476- IF HOST-APOLICE-INICIAL EQUAL 0 */

            if (HOST_APOLICE_INICIAL == 0)
            {

                /*" -477- MOVE 9999999999999 TO HOST-APOLICE-FINAL */
                _.Move(9999999999999, HOST_APOLICE_FINAL);

                /*" -478- ELSE */
            }
            else
            {


                /*" -479- MOVE HOST-APOLICE-INICIAL TO HOST-APOLICE-FINAL */
                _.Move(HOST_APOLICE_INICIAL, HOST_APOLICE_FINAL);

                /*" -480- END-IF */
            }


            /*" -481- IF HOST-PRODUTO-INICIAL EQUAL 0 */

            if (HOST_PRODUTO_INICIAL == 0)
            {

                /*" -482- MOVE 9999 TO HOST-PRODUTO-FINAL */
                _.Move(9999, HOST_PRODUTO_FINAL);

                /*" -483- ELSE */
            }
            else
            {


                /*" -484- MOVE HOST-PRODUTO-INICIAL TO HOST-PRODUTO-FINAL */
                _.Move(HOST_PRODUTO_INICIAL, HOST_PRODUTO_FINAL);

                /*" -485- END-IF */
            }


            /*" -487- MOVE HOST-DATA-INICIAL(09:02) TO C07-DATA-INICIAL(01:02) */
            _.MoveAtPosition(HOST_DATA_INICIAL.Substring(9, 2), W_INICIO_WORK.W_TABELA1.C07.C07_DATA_INICIAL, 1, 2);

            /*" -488- MOVE '/' TO C07-DATA-INICIAL(03:01) */
            _.MoveAtPosition("/", W_INICIO_WORK.W_TABELA1.C07.C07_DATA_INICIAL, 3, 1);

            /*" -490- MOVE HOST-DATA-INICIAL(06:02) TO C07-DATA-INICIAL(04:02) */
            _.MoveAtPosition(HOST_DATA_INICIAL.Substring(6, 2), W_INICIO_WORK.W_TABELA1.C07.C07_DATA_INICIAL, 4, 2);

            /*" -491- MOVE '/' TO C07-DATA-INICIAL(06:01) */
            _.MoveAtPosition("/", W_INICIO_WORK.W_TABELA1.C07.C07_DATA_INICIAL, 6, 1);

            /*" -493- MOVE HOST-DATA-INICIAL(01:04) TO C07-DATA-INICIAL(07:04) */
            _.MoveAtPosition(HOST_DATA_INICIAL.Substring(1, 4), W_INICIO_WORK.W_TABELA1.C07.C07_DATA_INICIAL, 7, 4);

            /*" -496- MOVE HOST-DATA-FINAL(09:02) TO C08-DATA-FINAL(01:02) */
            _.MoveAtPosition(HOST_DATA_FINAL.Substring(9, 2), W_INICIO_WORK.W_TABELA1.C08.C08_DATA_FINAL, 1, 2);

            /*" -496- MOVE HOST-DATA-FINAL(09:02) TO C07-DATA-FINAL(01:02) */
            _.MoveAtPosition(HOST_DATA_FINAL.Substring(9, 2), W_INICIO_WORK.W_TABELA1.C07.C07_DATA_FINAL, 1, 2);

            /*" -498- MOVE '/' TO C08-DATA-FINAL(03:01) */
            _.MoveAtPosition("/", W_INICIO_WORK.W_TABELA1.C08.C08_DATA_FINAL, 3, 1);

            /*" -498- MOVE '/' TO C07-DATA-FINAL(03:01) */
            _.MoveAtPosition("/", W_INICIO_WORK.W_TABELA1.C07.C07_DATA_FINAL, 3, 1);

            /*" -501- MOVE HOST-DATA-FINAL(06:02) TO C08-DATA-FINAL(04:02) */
            _.MoveAtPosition(HOST_DATA_FINAL.Substring(6, 2), W_INICIO_WORK.W_TABELA1.C08.C08_DATA_FINAL, 4, 2);

            /*" -501- MOVE HOST-DATA-FINAL(06:02) TO C07-DATA-FINAL(04:02) */
            _.MoveAtPosition(HOST_DATA_FINAL.Substring(6, 2), W_INICIO_WORK.W_TABELA1.C07.C07_DATA_FINAL, 4, 2);

            /*" -503- MOVE '/' TO C08-DATA-FINAL(06:01) */
            _.MoveAtPosition("/", W_INICIO_WORK.W_TABELA1.C08.C08_DATA_FINAL, 6, 1);

            /*" -503- MOVE '/' TO C07-DATA-FINAL(06:01) */
            _.MoveAtPosition("/", W_INICIO_WORK.W_TABELA1.C07.C07_DATA_FINAL, 6, 1);

            /*" -506- MOVE HOST-DATA-FINAL(01:04) TO C08-DATA-FINAL(07:04) */
            _.MoveAtPosition(HOST_DATA_FINAL.Substring(1, 4), W_INICIO_WORK.W_TABELA1.C08.C08_DATA_FINAL, 7, 4);

            /*" -506- MOVE HOST-DATA-FINAL(01:04) TO C07-DATA-FINAL(07:04) */
            _.MoveAtPosition(HOST_DATA_FINAL.Substring(1, 4), W_INICIO_WORK.W_TABELA1.C07.C07_DATA_FINAL, 7, 4);

            /*" -507- IF HOST-RAMO-INICIAL EQUAL 0 */

            if (HOST_RAMO_INICIAL == 0)
            {

                /*" -508- MOVE 'NAO INFORMADO' TO C04-RAMO */
                _.Move("NAO INFORMADO", W_INICIO_WORK.W_TABELA1.C04.C04_RAMO);

                /*" -509- ELSE */
            }
            else
            {


                /*" -510- MOVE HOST-RAMO-INICIAL TO C04-RAMO */
                _.Move(HOST_RAMO_INICIAL, W_INICIO_WORK.W_TABELA1.C04.C04_RAMO);

                /*" -511- END-IF */
            }


            /*" -512- IF HOST-CODSUBES-INICIAL EQUAL ZEROS */

            if (HOST_CODSUBES_INICIAL == 00)
            {

                /*" -513- MOVE 'NAO INFORMADO' TO C06-SUBGRUPO */
                _.Move("NAO INFORMADO", W_INICIO_WORK.W_TABELA1.C06.C06_SUBGRUPO);

                /*" -514- ELSE */
            }
            else
            {


                /*" -515- MOVE HOST-CODSUBES-INICIAL TO C06-SUBGRUPO */
                _.Move(HOST_CODSUBES_INICIAL, W_INICIO_WORK.W_TABELA1.C06.C06_SUBGRUPO);

                /*" -516- END-IF */
            }


            /*" -517- IF HOST-APOLICE-INICIAL EQUAL ZEROS */

            if (HOST_APOLICE_INICIAL == 00)
            {

                /*" -518- MOVE 'NAO INFORMADO' TO C03-APOLICE */
                _.Move("NAO INFORMADO", W_INICIO_WORK.W_TABELA1.C03.C03_APOLICE);

                /*" -519- ELSE */
            }
            else
            {


                /*" -520- MOVE HOST-APOLICE-INICIAL TO C03-APOLICE */
                _.Move(HOST_APOLICE_INICIAL, W_INICIO_WORK.W_TABELA1.C03.C03_APOLICE);

                /*" -521- END-IF */
            }


            /*" -522- IF HOST-PRODUTO-INICIAL EQUAL ZEROS */

            if (HOST_PRODUTO_INICIAL == 00)
            {

                /*" -523- MOVE 'NAO INFORMADO' TO C05-PRODUTO */
                _.Move("NAO INFORMADO", W_INICIO_WORK.W_TABELA1.C05.C05_PRODUTO);

                /*" -524- ELSE */
            }
            else
            {


                /*" -525- MOVE HOST-PRODUTO-INICIAL TO C05-PRODUTO */
                _.Move(HOST_PRODUTO_INICIAL, W_INICIO_WORK.W_TABELA1.C05.C05_PRODUTO);

                /*" -525- END-IF. */
            }


        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-FETCH-1 */
        public void R021_FETCH_RELATORIO_DB_FETCH_1()
        {
            /*" -416- EXEC SQL FETCH RELATORIOS INTO :RELATORI-COD-USUARIO, :RELATORI-DATA-SOLICITACAO, :HOST-DATA-INICIAL, :HOST-DATA-FINAL, :HOST-RAMO-INICIAL, :HOST-CODSUBES-INICIAL, :HOST-APOLICE-INICIAL, :HOST-PRODUTO-INICIAL END-EXEC */

            if (RELATORIOS.Fetch())
            {
                _.Move(RELATORIOS.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(RELATORIOS.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(RELATORIOS.HOST_DATA_INICIAL, HOST_DATA_INICIAL);
                _.Move(RELATORIOS.HOST_DATA_FINAL, HOST_DATA_FINAL);
                _.Move(RELATORIOS.HOST_RAMO_INICIAL, HOST_RAMO_INICIAL);
                _.Move(RELATORIOS.HOST_CODSUBES_INICIAL, HOST_CODSUBES_INICIAL);
                _.Move(RELATORIOS.HOST_APOLICE_INICIAL, HOST_APOLICE_INICIAL);
                _.Move(RELATORIOS.HOST_PRODUTO_INICIAL, HOST_PRODUTO_INICIAL);
            }

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-CLOSE-1 */
        public void R021_FETCH_RELATORIO_DB_CLOSE_1()
        {
            /*" -420- EXEC SQL CLOSE RELATORIOS END-EXEC */

            RELATORIOS.Close();

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-SELECT-1 */
        public void R021_FETCH_RELATORIO_DB_SELECT_1()
        {
            /*" -447- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :RELATORI-COD-USUARIO WITH UR END-EXEC. */

            var r021_FETCH_RELATORIO_DB_SELECT_1_Query1 = new R021_FETCH_RELATORIO_DB_SELECT_1_Query1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
            };

            var executed_1 = R021_FETCH_RELATORIO_DB_SELECT_1_Query1.Execute(r021_FETCH_RELATORIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_NOME_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/

        [StopWatch]
        /*" R030-PROCESSA-RELATORIO */
        private void R030_PROCESSA_RELATORIO(bool isPerform = false)
        {
            /*" -532- INITIALIZE W-TABELA1 W-TABELA2. */
            _.Initialize(
                W_INICIO_WORK.W_TABELA1
                , W_INICIO_WORK.W_TABELA1.W_TABELA2
            );

            /*" -534- INITIALIZE W-CONTADOR-USUARIO. */
            _.Initialize(
                W_INICIO_WORK.W_CONTADOR_USUARIO
            );

            /*" -535- PERFORM R100-DECLARE-PAGO THRU R100-EXIT. */

            R100_DECLARE_PAGO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/


            /*" -536- MOVE 'NAO' TO W-FIM-PAGO. */
            _.Move("NAO", W_INICIO_WORK.W_FIM_PAGO);

            /*" -542- PERFORM R101-FETCH-PAGO THRU R101-EXIT. */

            R101_FETCH_PAGO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/


            /*" -543- IF (W-FIM-PAGO EQUAL 'NAO' ) */

            if ((W_INICIO_WORK.W_FIM_PAGO == "NAO"))
            {

                /*" -545- PERFORM R110-PROCESSA-PAGO THRU R110-EXIT UNTIL (W-FIM-PAGO EQUAL 'SIM' ) */

                while (!((W_INICIO_WORK.W_FIM_PAGO == "SIM")))
                {

                    R110_PROCESSA_PAGO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

                }

                /*" -547- END-IF */
            }


            /*" -548- PERFORM R200-DECLARE-PENDENTE THRU R200-EXIT. */

            R200_DECLARE_PENDENTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/


            /*" -549- MOVE 'NAO' TO W-FIM-PENDENTE. */
            _.Move("NAO", W_INICIO_WORK.W_FIM_PENDENTE);

            /*" -554- PERFORM R201-FETCH-PENDENTE THRU R201-EXIT. */

            R201_FETCH_PENDENTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R201_EXIT*/


            /*" -555- IF (W-FIM-PENDENTE EQUAL 'NAO' ) */

            if ((W_INICIO_WORK.W_FIM_PENDENTE == "NAO"))
            {

                /*" -557- PERFORM R210-PROCESSA-PENDENTE THRU R210-EXIT UNTIL (W-FIM-PENDENTE EQUAL 'SIM' ) */

                while (!((W_INICIO_WORK.W_FIM_PENDENTE == "SIM")))
                {

                    R210_PROCESSA_PENDENTE(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/

                }

                /*" -559- END-IF */
            }


            /*" -560- IF W-CONTADOR-USUARIO EQUAL ZERO */

            if (W_INICIO_WORK.W_CONTADOR_USUARIO == 00)
            {

                /*" -561- IF W-CHAVE-ARQ-SAIDA-JA-ABERTO EQUAL 'NAO' */

                if (W_INICIO_WORK.W_CHAVE_ARQ_SAIDA_JA_ABERTO == "NAO")
                {

                    /*" -562- PERFORM R035-ABRE-ARQUIVO THRU R035-EXIT */

                    R035_ABRE_ARQUIVO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R035_EXIT*/


                    /*" -563- MOVE 'SIM' TO W-CHAVE-ARQ-SAIDA-JA-ABERTO */
                    _.Move("SIM", W_INICIO_WORK.W_CHAVE_ARQ_SAIDA_JA_ABERTO);

                    /*" -564- END-IF */
                }


                /*" -565- WRITE REG-ARQ-SAIDA FROM C01 */
                _.Move(W_INICIO_WORK.W_TABELA1.C01.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -566- WRITE REG-ARQ-SAIDA FROM C02 */
                _.Move(W_INICIO_WORK.W_TABELA1.C02.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -567- WRITE REG-ARQ-SAIDA FROM C03 */
                _.Move(W_INICIO_WORK.W_TABELA1.C03.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -568- WRITE REG-ARQ-SAIDA FROM C04 */
                _.Move(W_INICIO_WORK.W_TABELA1.C04.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -569- WRITE REG-ARQ-SAIDA FROM C05 */
                _.Move(W_INICIO_WORK.W_TABELA1.C05.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -570- WRITE REG-ARQ-SAIDA FROM C06 */
                _.Move(W_INICIO_WORK.W_TABELA1.C06.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -571- WRITE REG-ARQ-SAIDA FROM C07 */
                _.Move(W_INICIO_WORK.W_TABELA1.C07.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -572- WRITE REG-ARQ-SAIDA FROM C08 */
                _.Move(W_INICIO_WORK.W_TABELA1.C08.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -573- WRITE REG-ARQ-SAIDA FROM C09 */
                _.Move(W_INICIO_WORK.W_TABELA1.C09.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -575- MOVE 'NADA SELECIONADO PARA OS PARAMETROS INFORMADOS' TO LD01-TIPO-SEGURO */
                _.Move("NADA SELECIONADO PARA OS PARAMETROS INFORMADOS", W_INICIO_WORK.W_TABELA1.LD01.LD01_TIPO_SEGURO);

                /*" -580- MOVE ZEROS TO LD01-FONTE LD01-QTD-PAGO LD01-VAL-PAGO LD01-QTD-PENDENTE LD01-VAL-PENDENTE */
                _.Move(0, W_INICIO_WORK.W_TABELA1.LD01.LD01_FONTE, W_INICIO_WORK.W_TABELA1.LD01.LD01_QTD_PAGO, W_INICIO_WORK.W_TABELA1.LD01.LD01_VAL_PAGO, W_INICIO_WORK.W_TABELA1.LD01.LD01_QTD_PENDENTE, W_INICIO_WORK.W_TABELA1.LD01.LD01_VAL_PENDENTE);

                /*" -582- WRITE REG-ARQ-SAIDA FROM LD01. */
                _.Move(W_INICIO_WORK.W_TABELA1.LD01.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());
            }


            /*" -583- IF W-CONTADOR-USUARIO NOT EQUAL ZERO */

            if (W_INICIO_WORK.W_CONTADOR_USUARIO != 00)
            {

                /*" -584- IF W-CHAVE-ARQ-SAIDA-JA-ABERTO EQUAL 'NAO' */

                if (W_INICIO_WORK.W_CHAVE_ARQ_SAIDA_JA_ABERTO == "NAO")
                {

                    /*" -585- PERFORM R035-ABRE-ARQUIVO THRU R035-EXIT */

                    R035_ABRE_ARQUIVO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R035_EXIT*/


                    /*" -586- MOVE 'SIM' TO W-CHAVE-ARQ-SAIDA-JA-ABERTO */
                    _.Move("SIM", W_INICIO_WORK.W_CHAVE_ARQ_SAIDA_JA_ABERTO);

                    /*" -587- END-IF */
                }


                /*" -588- WRITE REG-ARQ-SAIDA FROM C01 */
                _.Move(W_INICIO_WORK.W_TABELA1.C01.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -589- WRITE REG-ARQ-SAIDA FROM C02 */
                _.Move(W_INICIO_WORK.W_TABELA1.C02.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -590- WRITE REG-ARQ-SAIDA FROM C03 */
                _.Move(W_INICIO_WORK.W_TABELA1.C03.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -591- WRITE REG-ARQ-SAIDA FROM C04 */
                _.Move(W_INICIO_WORK.W_TABELA1.C04.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -592- WRITE REG-ARQ-SAIDA FROM C05 */
                _.Move(W_INICIO_WORK.W_TABELA1.C05.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -593- WRITE REG-ARQ-SAIDA FROM C06 */
                _.Move(W_INICIO_WORK.W_TABELA1.C06.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -594- WRITE REG-ARQ-SAIDA FROM C07 */
                _.Move(W_INICIO_WORK.W_TABELA1.C07.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -595- WRITE REG-ARQ-SAIDA FROM C08 */
                _.Move(W_INICIO_WORK.W_TABELA1.C08.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -596- WRITE REG-ARQ-SAIDA FROM C09 */
                _.Move(W_INICIO_WORK.W_TABELA1.C09.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -597- MOVE 1 TO W-IND */
                _.Move(1, W_INICIO_WORK.W_IND);

                /*" -599- PERFORM R040-IMPRIME-TAB-NOSSA-LID THRU R040-EXIT UNTIL (W-IND GREATER 100) */

                while (!((W_INICIO_WORK.W_IND > 100)))
                {

                    R040_IMPRIME_TAB_NOSSA_LID(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

                }

                /*" -600- MOVE 1 TO W-IND */
                _.Move(1, W_INICIO_WORK.W_IND);

                /*" -603- PERFORM R050-IMPRIME-TAB-COSS-ACE THRU R050-EXIT UNTIL (W-IND GREATER 100). */

                while (!((W_INICIO_WORK.W_IND > 100)))
                {

                    R050_IMPRIME_TAB_COSS_ACE(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/

                }
            }


            /*" -603- PERFORM R021-FETCH-RELATORIO THRU R021-EXIT. */

            R021_FETCH_RELATORIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R035-ABRE-ARQUIVO */
        private void R035_ABRE_ARQUIVO(bool isPerform = false)
        {
            /*" -609- OPEN OUTPUT ARQ-SAIDA. */
            ARQ_SAIDA.Open(REG_ARQ_SAIDA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R035_EXIT*/

        [StopWatch]
        /*" R040-IMPRIME-TAB-NOSSA-LID */
        private void R040_IMPRIME_TAB_NOSSA_LID(bool isPerform = false)
        {
            /*" -616- IF W-TAB-FONTE(W-IND) NOT EQUAL ZERO */

            if (W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[W_INICIO_WORK.W_IND].W_TAB_FONTE != 00)
            {

                /*" -617- MOVE SPACES TO LD01-TIPO-SEGURO */
                _.Move("", W_INICIO_WORK.W_TABELA1.LD01.LD01_TIPO_SEGURO);

                /*" -619- MOVE ZEROS TO LD01-FONTE LD01-QTD-PAGO LD01-VAL-PAGO LD01-QTD-PENDENTE LD01-VAL-PENDENTE */
                _.Move(0, W_INICIO_WORK.W_TABELA1.LD01.LD01_FONTE, W_INICIO_WORK.W_TABELA1.LD01.LD01_QTD_PAGO, W_INICIO_WORK.W_TABELA1.LD01.LD01_VAL_PAGO, W_INICIO_WORK.W_TABELA1.LD01.LD01_QTD_PENDENTE, W_INICIO_WORK.W_TABELA1.LD01.LD01_VAL_PENDENTE);

                /*" -620- MOVE 'NOSSA LIDERANCA' TO LD01-TIPO-SEGURO */
                _.Move("NOSSA LIDERANCA", W_INICIO_WORK.W_TABELA1.LD01.LD01_TIPO_SEGURO);

                /*" -621- MOVE W-TAB-FONTE(W-IND) TO LD01-FONTE */
                _.Move(W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[W_INICIO_WORK.W_IND].W_TAB_FONTE, W_INICIO_WORK.W_TABELA1.LD01.LD01_FONTE);

                /*" -622- MOVE W-TAB-QTD-PAGO(W-IND) TO LD01-QTD-PAGO */
                _.Move(W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[W_INICIO_WORK.W_IND].W_TAB_QTD_PAGO, W_INICIO_WORK.W_TABELA1.LD01.LD01_QTD_PAGO);

                /*" -623- MOVE W-TAB-VAL-PAGO(W-IND) TO LD01-VAL-PAGO */
                _.Move(W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[W_INICIO_WORK.W_IND].W_TAB_VAL_PAGO, W_INICIO_WORK.W_TABELA1.LD01.LD01_VAL_PAGO);

                /*" -624- MOVE W-TAB-QTD-PENDENTE(W-IND) TO LD01-QTD-PENDENTE */
                _.Move(W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[W_INICIO_WORK.W_IND].W_TAB_QTD_PENDENTE, W_INICIO_WORK.W_TABELA1.LD01.LD01_QTD_PENDENTE);

                /*" -625- MOVE W-TAB-VAL-PENDENTE(W-IND) TO LD01-VAL-PENDENTE */
                _.Move(W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[W_INICIO_WORK.W_IND].W_TAB_VAL_PENDENTE, W_INICIO_WORK.W_TABELA1.LD01.LD01_VAL_PENDENTE);

                /*" -627- WRITE REG-ARQ-SAIDA FROM LD01. */
                _.Move(W_INICIO_WORK.W_TABELA1.LD01.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());
            }


            /*" -627- ADD 1 TO W-IND. */
            W_INICIO_WORK.W_IND.Value = W_INICIO_WORK.W_IND + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

        [StopWatch]
        /*" R050-IMPRIME-TAB-COSS-ACE */
        private void R050_IMPRIME_TAB_COSS_ACE(bool isPerform = false)
        {
            /*" -634- IF W-TAB-ACE-FONTE(W-IND) NOT EQUAL ZERO */

            if (W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[W_INICIO_WORK.W_IND].W_TAB_ACE_FONTE != 00)
            {

                /*" -635- MOVE SPACES TO LD01-TIPO-SEGURO */
                _.Move("", W_INICIO_WORK.W_TABELA1.LD01.LD01_TIPO_SEGURO);

                /*" -637- MOVE ZEROS TO LD01-FONTE LD01-QTD-PAGO LD01-VAL-PAGO LD01-QTD-PENDENTE LD01-VAL-PENDENTE */
                _.Move(0, W_INICIO_WORK.W_TABELA1.LD01.LD01_FONTE, W_INICIO_WORK.W_TABELA1.LD01.LD01_QTD_PAGO, W_INICIO_WORK.W_TABELA1.LD01.LD01_VAL_PAGO, W_INICIO_WORK.W_TABELA1.LD01.LD01_QTD_PENDENTE, W_INICIO_WORK.W_TABELA1.LD01.LD01_VAL_PENDENTE);

                /*" -638- MOVE 'COSSEGURO ACEITO' TO LD01-TIPO-SEGURO */
                _.Move("COSSEGURO ACEITO", W_INICIO_WORK.W_TABELA1.LD01.LD01_TIPO_SEGURO);

                /*" -639- MOVE W-TAB-ACE-FONTE(W-IND) TO LD01-FONTE */
                _.Move(W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[W_INICIO_WORK.W_IND].W_TAB_ACE_FONTE, W_INICIO_WORK.W_TABELA1.LD01.LD01_FONTE);

                /*" -640- MOVE W-TAB-ACE-QTD-PAGO(W-IND) TO LD01-QTD-PAGO */
                _.Move(W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[W_INICIO_WORK.W_IND].W_TAB_ACE_QTD_PAGO, W_INICIO_WORK.W_TABELA1.LD01.LD01_QTD_PAGO);

                /*" -641- MOVE W-TAB-ACE-VAL-PAGO(W-IND) TO LD01-VAL-PAGO */
                _.Move(W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[W_INICIO_WORK.W_IND].W_TAB_ACE_VAL_PAGO, W_INICIO_WORK.W_TABELA1.LD01.LD01_VAL_PAGO);

                /*" -642- MOVE W-TAB-ACE-QTD-PENDENTE(W-IND) TO LD01-QTD-PENDENTE */
                _.Move(W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[W_INICIO_WORK.W_IND].W_TAB_ACE_QTD_PENDENTE, W_INICIO_WORK.W_TABELA1.LD01.LD01_QTD_PENDENTE);

                /*" -643- MOVE W-TAB-ACE-VAL-PENDENTE(W-IND) TO LD01-VAL-PENDENTE */
                _.Move(W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[W_INICIO_WORK.W_IND].W_TAB_ACE_VAL_PENDENTE, W_INICIO_WORK.W_TABELA1.LD01.LD01_VAL_PENDENTE);

                /*" -645- WRITE REG-ARQ-SAIDA FROM LD01. */
                _.Move(W_INICIO_WORK.W_TABELA1.LD01.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());
            }


            /*" -645- ADD 1 TO W-IND. */
            W_INICIO_WORK.W_IND.Value = W_INICIO_WORK.W_IND + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/

        [StopWatch]
        /*" R100-DECLARE-PAGO */
        private void R100_DECLARE_PAGO(bool isPerform = false)
        {
            /*" -653- MOVE '006' TO WNR-EXEC-SQL */
            _.Move("006", W_INICIO_WORK.W_TABELA1.FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -681- PERFORM R100_DECLARE_PAGO_DB_DECLARE_1 */

            R100_DECLARE_PAGO_DB_DECLARE_1();

            /*" -683- PERFORM R100_DECLARE_PAGO_DB_OPEN_1 */

            R100_DECLARE_PAGO_DB_OPEN_1();

        }

        [StopWatch]
        /*" R100-DECLARE-PAGO-DB-OPEN-1 */
        public void R100_DECLARE_PAGO_DB_OPEN_1()
        {
            /*" -683- EXEC SQL OPEN PAGO END-EXEC. */

            PAGO.Open();

        }

        [StopWatch]
        /*" R200-DECLARE-PENDENTE-DB-DECLARE-1 */
        public void R200_DECLARE_PENDENTE_DB_DECLARE_1()
        {
            /*" -777- EXEC SQL DECLARE PENDENTE CURSOR FOR SELECT M.TIPO_REGISTRO, E.COD_FONTE, M.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.ENDOSSOS E, SEGUROS.GE_OPERACAO O, SEGUROS.SINISTRO_MESTRE M WHERE H.DATA_MOVIMENTO <= :HOST-DATA-FINAL AND M.NUM_APOLICE = :HOST-APOLICE-INICIAL AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND O.IDE_SISTEMA = 'SI' AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IND_TIPO_FUNCAO IN ( 'AV' , 'IN' ) AND E.NUM_APOLICE = M.NUM_APOLICE AND E.NUM_ENDOSSO = 0 AND E.COD_FONTE <> 0 GROUP BY M.TIPO_REGISTRO, E.COD_FONTE, M.NUM_APOL_SINISTRO ORDER BY M.TIPO_REGISTRO, E.COD_FONTE, M.NUM_APOL_SINISTRO WITH UR END-EXEC */
            PENDENTE = new SI0861B_PENDENTE(true);
            string GetQuery_PENDENTE()
            {
                var query = @$"SELECT M.TIPO_REGISTRO
							, 
							E.COD_FONTE
							, 
							M.NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.ENDOSSOS E
							, 
							SEGUROS.GE_OPERACAO O
							, 
							SEGUROS.SINISTRO_MESTRE M 
							WHERE H.DATA_MOVIMENTO <= '{HOST_DATA_FINAL}' 
							AND M.NUM_APOLICE = '{HOST_APOLICE_INICIAL}' 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.COD_OPERACAO = H.COD_OPERACAO 
							AND O.IND_TIPO_FUNCAO IN ( 'AV'
							, 'IN' ) 
							AND E.NUM_APOLICE = M.NUM_APOLICE 
							AND E.NUM_ENDOSSO = 0 
							AND E.COD_FONTE <> 0 
							GROUP BY M.TIPO_REGISTRO
							, E.COD_FONTE
							, M.NUM_APOL_SINISTRO 
							ORDER BY M.TIPO_REGISTRO
							, E.COD_FONTE
							, M.NUM_APOL_SINISTRO";

                return query;
            }
            PENDENTE.GetQueryEvent += GetQuery_PENDENTE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R101-FETCH-PAGO */
        private void R101_FETCH_PAGO(bool isPerform = false)
        {
            /*" -692- MOVE '007' TO WNR-EXEC-SQL */
            _.Move("007", W_INICIO_WORK.W_TABELA1.FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -696- PERFORM R101_FETCH_PAGO_DB_FETCH_1 */

            R101_FETCH_PAGO_DB_FETCH_1();

            /*" -701- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -702- MOVE 'SIM' TO W-FIM-PAGO */
                _.Move("SIM", W_INICIO_WORK.W_FIM_PAGO);

                /*" -702- PERFORM R101_FETCH_PAGO_DB_CLOSE_1 */

                R101_FETCH_PAGO_DB_CLOSE_1();

                /*" -705- END-IF */
            }


            /*" -706- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -707- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -708- DISPLAY 'ERRO FETCH NA PAGO.................' */
                _.Display($"ERRO FETCH NA PAGO.................");

                /*" -709- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -709- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R101-FETCH-PAGO-DB-FETCH-1 */
        public void R101_FETCH_PAGO_DB_FETCH_1()
        {
            /*" -696- EXEC SQL FETCH PAGO INTO :SINISMES-TIPO-REGISTRO, :HOST-FONTE, :SINISMES-NUM-APOL-SINISTRO END-EXEC. */

            if (PAGO.Fetch())
            {
                _.Move(PAGO.SINISMES_TIPO_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO);
                _.Move(PAGO.HOST_FONTE, HOST_FONTE);
                _.Move(PAGO.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
            }

        }

        [StopWatch]
        /*" R101-FETCH-PAGO-DB-CLOSE-1 */
        public void R101_FETCH_PAGO_DB_CLOSE_1()
        {
            /*" -702- EXEC SQL CLOSE PAGO END-EXEC */

            PAGO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/

        [StopWatch]
        /*" R110-PROCESSA-PAGO */
        private void R110_PROCESSA_PAGO(bool isPerform = false)
        {
            /*" -719- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -720- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -721- MOVE HOST-DATA-INICIAL TO SI1001S-DATA-INICIO */
            _.Move(HOST_DATA_INICIAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_INICIO);

            /*" -723- MOVE HOST-DATA-FINAL TO SI1001S-DATA-FIM */
            _.Move(HOST_DATA_FINAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -725- CALL 'SI1002S' USING SI1001S-PARAMETROS */
            _.Call("SI1002S", LBSI1001.SI1001S_PARAMETROS);

            /*" -726- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -727- DISPLAY 'PROBLEMA CALL SI1002S ' */
                _.Display($"PROBLEMA CALL SI1002S ");

                /*" -728- DISPLAY 'SQLCODE  - ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE  - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -729- DISPLAY 'MENSAGEM - ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -730- DISPLAY ' ' SI1001S-NUM-APOL-SINISTRO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                /*" -731- DISPLAY ' ' SI1001S-DATA-INICIO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_INICIO}");

                /*" -732- DISPLAY ' ' SI1001S-DATA-FIM */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM}");

                /*" -734- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -736- MOVE SI1001S-VALOR-CALCULADO TO HOST-VAL-PAGO. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_VAL_PAGO);

            /*" -737- IF HOST-VAL-PAGO NOT EQUAL ZEROS */

            if (HOST_VAL_PAGO != 00)
            {

                /*" -738- ADD 1 TO W-CONTADOR-USUARIO W-CONTADOR-GERAL */
                W_INICIO_WORK.W_CONTADOR_USUARIO.Value = W_INICIO_WORK.W_CONTADOR_USUARIO + 1;
                W_INICIO_WORK.W_CONTADOR_GERAL.Value = W_INICIO_WORK.W_CONTADOR_GERAL + 1;

                /*" -739- IF SINISMES-TIPO-REGISTRO = '0' */

                if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO == "0")
                {

                    /*" -740- MOVE HOST-FONTE TO W-TAB-ACE-FONTE(HOST-FONTE) */
                    _.Move(HOST_FONTE, W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[HOST_FONTE].W_TAB_ACE_FONTE);

                    /*" -741- ADD 1 TO W-TAB-ACE-QTD-PAGO(HOST-FONTE) */
                    W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[HOST_FONTE].W_TAB_ACE_QTD_PAGO.Value = W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[HOST_FONTE].W_TAB_ACE_QTD_PAGO + 1;

                    /*" -742- ADD HOST-VAL-PAGO TO W-TAB-ACE-VAL-PAGO(HOST-FONTE) */
                    W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[HOST_FONTE].W_TAB_ACE_VAL_PAGO.Value = W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[HOST_FONTE].W_TAB_ACE_VAL_PAGO + HOST_VAL_PAGO;

                    /*" -743- ELSE */
                }
                else
                {


                    /*" -744- MOVE HOST-FONTE TO W-TAB-FONTE(HOST-FONTE) */
                    _.Move(HOST_FONTE, W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[HOST_FONTE].W_TAB_FONTE);

                    /*" -745- ADD 1 TO W-TAB-QTD-PAGO(HOST-FONTE) */
                    W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[HOST_FONTE].W_TAB_QTD_PAGO.Value = W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[HOST_FONTE].W_TAB_QTD_PAGO + 1;

                    /*" -746- ADD HOST-VAL-PAGO TO W-TAB-VAL-PAGO(HOST-FONTE) */
                    W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[HOST_FONTE].W_TAB_VAL_PAGO.Value = W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[HOST_FONTE].W_TAB_VAL_PAGO + HOST_VAL_PAGO;

                    /*" -747- END-IF */
                }


                /*" -749- END-IF */
            }


            /*" -749- PERFORM R101-FETCH-PAGO THRU R101-EXIT. */

            R101_FETCH_PAGO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R101_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R200-DECLARE-PENDENTE */
        private void R200_DECLARE_PENDENTE(bool isPerform = false)
        {
            /*" -757- MOVE '008' TO WNR-EXEC-SQL */
            _.Move("008", W_INICIO_WORK.W_TABELA1.FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -777- PERFORM R200_DECLARE_PENDENTE_DB_DECLARE_1 */

            R200_DECLARE_PENDENTE_DB_DECLARE_1();

            /*" -779- PERFORM R200_DECLARE_PENDENTE_DB_OPEN_1 */

            R200_DECLARE_PENDENTE_DB_OPEN_1();

        }

        [StopWatch]
        /*" R200-DECLARE-PENDENTE-DB-OPEN-1 */
        public void R200_DECLARE_PENDENTE_DB_OPEN_1()
        {
            /*" -779- EXEC SQL OPEN PENDENTE END-EXEC. */

            PENDENTE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R201-FETCH-PENDENTE */
        private void R201_FETCH_PENDENTE(bool isPerform = false)
        {
            /*" -787- MOVE '009' TO WNR-EXEC-SQL */
            _.Move("009", W_INICIO_WORK.W_TABELA1.FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -791- PERFORM R201_FETCH_PENDENTE_DB_FETCH_1 */

            R201_FETCH_PENDENTE_DB_FETCH_1();

            /*" -797- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -798- MOVE 'SIM' TO W-FIM-PENDENTE */
                _.Move("SIM", W_INICIO_WORK.W_FIM_PENDENTE);

                /*" -798- PERFORM R201_FETCH_PENDENTE_DB_CLOSE_1 */

                R201_FETCH_PENDENTE_DB_CLOSE_1();

                /*" -801- END-IF */
            }


            /*" -802- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -803- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -804- DISPLAY 'ERRO FETCH NA PENDENTE.............' */
                _.Display($"ERRO FETCH NA PENDENTE.............");

                /*" -805- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -805- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R201-FETCH-PENDENTE-DB-FETCH-1 */
        public void R201_FETCH_PENDENTE_DB_FETCH_1()
        {
            /*" -791- EXEC SQL FETCH PENDENTE INTO :SINISMES-TIPO-REGISTRO, :HOST-FONTE, :SINISMES-NUM-APOL-SINISTRO END-EXEC. */

            if (PENDENTE.Fetch())
            {
                _.Move(PENDENTE.SINISMES_TIPO_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO);
                _.Move(PENDENTE.HOST_FONTE, HOST_FONTE);
                _.Move(PENDENTE.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
            }

        }

        [StopWatch]
        /*" R201-FETCH-PENDENTE-DB-CLOSE-1 */
        public void R201_FETCH_PENDENTE_DB_CLOSE_1()
        {
            /*" -798- EXEC SQL CLOSE PENDENTE END-EXEC */

            PENDENTE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R201_EXIT*/

        [StopWatch]
        /*" R210-PROCESSA-PENDENTE */
        private void R210_PROCESSA_PENDENTE(bool isPerform = false)
        {
            /*" -815- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -816- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -818- MOVE HOST-DATA-FINAL TO SI1001S-DATA-FIM */
            _.Move(HOST_DATA_FINAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -820- CALL 'SI1001S' USING SI1001S-PARAMETROS */
            _.Call("SI1001S", LBSI1001.SI1001S_PARAMETROS);

            /*" -821- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -822- DISPLAY 'PROBLEMA CALL SI1001S ' */
                _.Display($"PROBLEMA CALL SI1001S ");

                /*" -823- DISPLAY 'SQLCODE  - ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE  - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -824- DISPLAY 'MENSAGEM - ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -825- DISPLAY ' ' SI1001S-NUM-APOL-SINISTRO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                /*" -826- DISPLAY ' ' SI1001S-DATA-FIM */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM}");

                /*" -828- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -830- MOVE SI1001S-VALOR-CALCULADO TO HOST-VAL-PENDENTE. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_VAL_PENDENTE);

            /*" -831- IF HOST-VAL-PENDENTE NOT EQUAL ZEROS */

            if (HOST_VAL_PENDENTE != 00)
            {

                /*" -832- ADD 1 TO W-CONTADOR-USUARIO W-CONTADOR-GERAL */
                W_INICIO_WORK.W_CONTADOR_USUARIO.Value = W_INICIO_WORK.W_CONTADOR_USUARIO + 1;
                W_INICIO_WORK.W_CONTADOR_GERAL.Value = W_INICIO_WORK.W_CONTADOR_GERAL + 1;

                /*" -833- IF SINISMES-TIPO-REGISTRO = '0' */

                if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO == "0")
                {

                    /*" -834- MOVE HOST-FONTE TO W-TAB-ACE-FONTE(HOST-FONTE) */
                    _.Move(HOST_FONTE, W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[HOST_FONTE].W_TAB_ACE_FONTE);

                    /*" -835- ADD 1 TO W-TAB-ACE-QTD-PENDENTE(HOST-FONTE) */
                    W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[HOST_FONTE].W_TAB_ACE_QTD_PENDENTE.Value = W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[HOST_FONTE].W_TAB_ACE_QTD_PENDENTE + 1;

                    /*" -837- ADD HOST-VAL-PENDENTE TO W-TAB-ACE-VAL-PENDENTE(HOST-FONTE) */
                    W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[HOST_FONTE].W_TAB_ACE_VAL_PENDENTE.Value = W_INICIO_WORK.W_TABELA1.W_TABELA2.W_TABELA_COSSEGURO_ACEITO[HOST_FONTE].W_TAB_ACE_VAL_PENDENTE + HOST_VAL_PENDENTE;

                    /*" -838- ELSE */
                }
                else
                {


                    /*" -839- MOVE HOST-FONTE TO W-TAB-FONTE(HOST-FONTE) */
                    _.Move(HOST_FONTE, W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[HOST_FONTE].W_TAB_FONTE);

                    /*" -840- ADD 1 TO W-TAB-QTD-PENDENTE(HOST-FONTE) */
                    W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[HOST_FONTE].W_TAB_QTD_PENDENTE.Value = W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[HOST_FONTE].W_TAB_QTD_PENDENTE + 1;

                    /*" -842- ADD HOST-VAL-PENDENTE TO W-TAB-VAL-PENDENTE(HOST-FONTE) */
                    W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[HOST_FONTE].W_TAB_VAL_PENDENTE.Value = W_INICIO_WORK.W_TABELA1.W_TABELA_NOSSA_LIDERANCA[HOST_FONTE].W_TAB_VAL_PENDENTE + HOST_VAL_PENDENTE;

                    /*" -843- END-IF */
                }


                /*" -845- END-IF */
            }


            /*" -845- PERFORM R201-FETCH-PENDENTE THRU R201-EXIT. */

            R201_FETCH_PENDENTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R201_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -855- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W_INICIO_WORK.W_TABELA1.FILLER_0.WABEND.WSQLCODE);

            /*" -856- IF W-CHAVE-ARQ-SAIDA-JA-ABERTO EQUAL 'SIM' */

            if (W_INICIO_WORK.W_CHAVE_ARQ_SAIDA_JA_ABERTO == "SIM")
            {

                /*" -858- CLOSE ARQ-SAIDA. */
                ARQ_SAIDA.Close();
            }


            /*" -860- DISPLAY WABEND */
            _.Display(W_INICIO_WORK.W_TABELA1.FILLER_0.WABEND);

            /*" -860- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC */

            /*" -862- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -866- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -866- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}