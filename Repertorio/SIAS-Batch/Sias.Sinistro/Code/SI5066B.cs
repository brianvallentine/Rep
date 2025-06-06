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
using Sias.Sinistro.DB2.SI5066B;

namespace Code
{
    public class SI5066B
    {
        public bool IsCall { get; set; }

        public SI5066B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  FINANCEIRO/SINISTRO                *      */
        /*"      *   PROGRAMA ...............  SI5066B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  HEIDER COELHO                      *      */
        /*"      *   DATA CODIFICACAO .......  MAIO / 2009                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                                                      *      */
        /*"      *   ROTINA COM OS PAGAMENTOS DE SINISTRO PARA O SISTEMA SIACC DA *      */
        /*"      *   CAIXA.                                                       *      */
        /*"      *   ==> APENAS PARA REPASSE DE MATCON - MATERIAL DE CONSTRUCAO   *      */
        /*"      *   CONVENIO FEBRABAN 240. CONVENIO CAIXA = 043350               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  *   25/05/2022 - HERVAL SOUZA  - JAZZ-387049                     *      */
        /*"      *              - CORRIGIR CURSOR                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - OS 0316/2021                                     *      */
        /*"      *                                                                *      */
        /*"      *               - ALTERACAO NA REGRA DA BAIXA DE INDENIZACAO DE  *      */
        /*"      *  SINISTROS TENDO EM VISTA QUE A BAIXA SERA FEITA NO RETORNO    *      */
        /*"      *  DO MCP.                                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/10/2021 - MARCO PAIVA                                  *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  *   03/11/2010 - HEIDER - PROCURAR V3                            *      */
        /*"      *              - INCLUSAO DO SQLERRM NA ROTINA DE ABEND          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  *   05/08/2009 - GEORGES CLAESSEN - CONTRASTE - V.02             *      */
        /*"      *              - AUMENTAR O PICTURE DE EDICAO                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   HEIDER - 22/06/09 PROCURAR V.01                              *      */
        /*"      *          AJUSTE DO OCORRHIST DA RALACAO COM HISTSINI           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WPARM01-AUX                PIC S9(009) COMP-3 VALUE +0.*/
        public IntBasis WPARM01_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WQUOCIENTE                 PIC S9(004) COMP-3 VALUE +0.*/
        public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WRESTO                     PIC S9(004) COMP-3 VALUE +0.*/
        public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HOST-ANO                   PIC S9(004) COMP   VALUE +0.*/
        public IntBasis HOST_ANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HOST-MES                   PIC S9(004) COMP   VALUE +0.*/
        public IntBasis HOST_MES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HOST-ULTIMO-DIA-UTIL       PIC  X(010)        VALUE SPACES.*/
        public StringBasis HOST_ULTIMO_DIA_UTIL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  HOST-PRIMEIRO-DIA-UTIL     PIC  X(010)        VALUE SPACES.*/
        public StringBasis HOST_PRIMEIRO_DIA_UTIL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  HOST-SI-DATA-MOV-ABERTO    PIC  X(010)        VALUE SPACES.*/
        public StringBasis HOST_SI_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  NL-COD-AGENCIA             PIC S9(004) COMP   VALUE +0.*/
        public IntBasis NL_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  NL-COD-TP-RECIBO           PIC S9(004) COMP   VALUE +0.*/
        public IntBasis NL_COD_TP_RECIBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  AC-GRAVA-MOVTO-DEB-CC      PIC  9(005)        VALUE ZEROS.*/
        public IntBasis AC_GRAVA_MOVTO_DEB_CC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01 AREA-DE-WORK.*/
        public SI5066B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI5066B_AREA_DE_WORK();
        public class SI5066B_AREA_DE_WORK : VarBasis
        {
            /*"  05 WDATA                                     VALUE SPACES.*/
            public SI5066B_WDATA WDATA { get; set; } = new SI5066B_WDATA();
            public class SI5066B_WDATA : VarBasis
            {
                /*"     07 WDATA-ANO                    PIC  9(04).*/
                public IntBasis WDATA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     07 FILLER                       PIC  X(01).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     07 WDATA-MES                    PIC  9(02).*/
                public IntBasis WDATA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     07 FILLER                       PIC  X(01).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     07 WDATA-DIA                    PIC  9(02).*/
                public IntBasis WDATA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  05 WHORA-CURR.*/
            }
            public SI5066B_WHORA_CURR WHORA_CURR { get; set; } = new SI5066B_WHORA_CURR();
            public class SI5066B_WHORA_CURR : VarBasis
            {
                /*"     10 WHORA-HH-CURR                PIC 9(02) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10 WHORA-MM-CURR                PIC 9(02) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10 WHORA-SS-CURR                PIC 9(02) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10 WHORA-CC-CURR                PIC 9(02) VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  05 WK-HORA-2.*/
            }
            public SI5066B_WK_HORA_2 WK_HORA_2 { get; set; } = new SI5066B_WK_HORA_2();
            public class SI5066B_WK_HORA_2 : VarBasis
            {
                /*"     07 WK-HH-2                      PIC 9(02) VALUE ZEROS.*/
                public IntBasis WK_HH_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     07 FILLE                        PIC X(01) VALUE '.'.*/
                public StringBasis FILLE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"     07 WK-MM-2                      PIC 9(02) VALUE ZEROS.*/
                public IntBasis WK_MM_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     07 FILLE                        PIC X(01) VALUE '.'.*/
                public StringBasis FILLE_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"     07 WK-SS-2                      PIC 9(02) VALUE ZEROS.*/
                public IntBasis WK_SS_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  05 WMONTA-ENDOSSO                  PIC 9(009) VALUE ZEROS.*/
            }
            public IntBasis WMONTA_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05 FILLER REDEFINES  WMONTA-ENDOSSO.*/
            private _REDEF_SI5066B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_SI5066B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_SI5066B_FILLER_2(); _.Move(WMONTA_ENDOSSO, _filler_2); VarBasis.RedefinePassValue(WMONTA_ENDOSSO, _filler_2, WMONTA_ENDOSSO); _filler_2.ValueChanged += () => { _.Move(_filler_2, WMONTA_ENDOSSO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WMONTA_ENDOSSO); }
            }  //Redefines
            public class _REDEF_SI5066B_FILLER_2 : VarBasis
            {
                /*"     10 WENDOSSO-ZERO                PIC 9(001).*/
                public IntBasis WENDOSSO_ZERO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"     10 WENDOSSO-PRODUTO             PIC 9(004).*/
                public IntBasis WENDOSSO_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10 WENDOSSO-OPERACAO            PIC 9(004).*/
                public IntBasis WENDOSSO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05 WFIM-SELECAO                    PIC X(03) VALUE 'NAO'.*/

                public _REDEF_SI5066B_FILLER_2()
                {
                    WENDOSSO_ZERO.ValueChanged += OnValueChanged;
                    WENDOSSO_PRODUTO.ValueChanged += OnValueChanged;
                    WENDOSSO_OPERACAO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WFIM_SELECAO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05 W-AGENCIA-ANTERIOR              PIC S9(04) COMP-3 VALUE +0.*/
            public IntBasis W_AGENCIA_ANTERIOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 W-AGENCIA-CONTRATO              PIC S9(04) COMP-3 VALUE +0.*/
            public IntBasis W_AGENCIA_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 W-UNO                           PIC S9(04) COMP-3 VALUE +0.*/
            public IntBasis W_UNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 W-VALOR-CREDITO              PIC S9(13)V99 COMP-3 VALUE +0.*/
            public DoubleBasis W_VALOR_CREDITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 HOST-TIMESTAMP                  PIC  X(26)        VALUE ' '*/
            public StringBasis HOST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @" ");
            /*"  05 W-QTD-LINHAS-MOVDEBCC           PIC S9(04) COMP-3 VALUE +0.*/
            public IntBasis W_QTD_LINHAS_MOVDEBCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 W-VALOR-TOTAL-PAGO           PIC S9(13)V99 COMP-3 VALUE +0.*/
            public DoubleBasis W_VALOR_TOTAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 W-CHAVE-VIRADA-DE-MES           PIC X(03) VALUE SPACES.*/
            public StringBasis W_CHAVE_VIRADA_DE_MES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"  05 W-CHAVE-PROCESSA                PIC X(03) VALUE SPACES.*/
            public StringBasis W_CHAVE_PROCESSA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"  05 W-CONTA-CHEQUES-GERADOS         PIC 9(03) VALUE ZEROS.*/
            public IntBasis W_CONTA_CHEQUES_GERADOS { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  05 W-DATA-UTIL-ANTERIOR            PIC X(10) VALUE ' '.*/
            public StringBasis W_DATA_UTIL_ANTERIOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
            /*"  05 W-EDICAO1                       PIC ZZZ.ZZZ.ZZZ.ZZ9.*/
            public IntBasis W_EDICAO1 { get; set; } = new IntBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9."));
            /*"  05 W-EDICAO2                       PIC ZZZ.ZZZ.ZZZ.ZZ9,99- .*/
            public DoubleBasis W_EDICAO2 { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99-"), 3);
            /*"  05 W-NUM-APOL-SINISTRO-NUM         PIC 9(13) VALUE ZEROS.*/
            public IntBasis W_NUM_APOL_SINISTRO_NUM { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"  05 W-NUM-APOL-SINISTRO             PIC 9(13) VALUE ZEROS.*/
            public IntBasis W_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"  05 W-DATA-PRIMEIRO-DIA-UTIL        PIC X(10) VALUE SPACES.*/
            public StringBasis W_DATA_PRIMEIRO_DIA_UTIL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 W-DIA01-MES-CORRENTE            PIC X(10) VALUE SPACES.*/
            public StringBasis W_DIA01_MES_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 W-DIA15-MES-CORRENTE            PIC X(10) VALUE SPACES.*/
            public StringBasis W_DIA15_MES_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"01 W-SI0505B                 PIC X(07)      VALUE 'SI0505B'.*/
        }
        public StringBasis W_SI0505B { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI0505B");
        /*"    03 W-DATA-AAAA-MM-DD.*/
        public SI5066B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new SI5066B_W_DATA_AAAA_MM_DD();
        public class SI5066B_W_DATA_AAAA_MM_DD : VarBasis
        {
            /*"       05 W-DATA-AAAA-MM-DD-AAAA      PIC 9(04) VALUE ZEROS.*/
            public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"       05 FILLER                      PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"       05 W-DATA-AAAA-MM-DD-MM        PIC 9(02) VALUE ZEROS.*/
            public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"       05 FILLER                      PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"       05 W-DATA-AAAA-MM-DD-DD        PIC 9(04) VALUE ZEROS.*/
            public IntBasis W_DATA_AAAA_MM_DD_DD { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"01  SI4922B-LK-PARAMETRO.*/
        }
        public SI5066B_SI4922B_LK_PARAMETRO SI4922B_LK_PARAMETRO { get; set; } = new SI5066B_SI4922B_LK_PARAMETRO();
        public class SI5066B_SI4922B_LK_PARAMETRO : VarBasis
        {
            /*"    05 SI4922B-LK-FORMA-PAGAMENTO    PIC 9(01).*/
            public IntBasis SI4922B_LK_FORMA_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"    05 SI4922B-LK-DATA-SIST.*/
            public SI5066B_SI4922B_LK_DATA_SIST SI4922B_LK_DATA_SIST { get; set; } = new SI5066B_SI4922B_LK_DATA_SIST();
            public class SI5066B_SI4922B_LK_DATA_SIST : VarBasis
            {
                /*"       10 SI4922B-LK-DATA-SIST-AAAA      PIC X(04).*/
                public StringBasis SI4922B_LK_DATA_SIST_AAAA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"       10 SI4922B-LK-DATA-SIST-FILLER1   PIC X(01).*/
                public StringBasis SI4922B_LK_DATA_SIST_FILLER1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 SI4922B-LK-DATA-SIST-MM        PIC X(02).*/
                public StringBasis SI4922B_LK_DATA_SIST_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"       10 SI4922B-LK-DATA-SIST-FILLER2   PIC X(01).*/
                public StringBasis SI4922B_LK_DATA_SIST_FILLER2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 SI4922B-LK-DATA-SIST-DD        PIC X(02).*/
                public StringBasis SI4922B_LK_DATA_SIST_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"    05 SI4922B-LK-DATA-NEG.*/
            }
            public SI5066B_SI4922B_LK_DATA_NEG SI4922B_LK_DATA_NEG { get; set; } = new SI5066B_SI4922B_LK_DATA_NEG();
            public class SI5066B_SI4922B_LK_DATA_NEG : VarBasis
            {
                /*"       10 SI4922B-LK-DATA-NEG-AAAA       PIC X(04).*/
                public StringBasis SI4922B_LK_DATA_NEG_AAAA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"       10 SI4922B-LK-DATA-NEG-FILLER1    PIC X(01).*/
                public StringBasis SI4922B_LK_DATA_NEG_FILLER1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 SI4922B-LK-DATA-NEG-MM         PIC X(02).*/
                public StringBasis SI4922B_LK_DATA_NEG_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"       10 SI4922B-LK-DATA-NEG-FILLER2    PIC X(01).*/
                public StringBasis SI4922B_LK_DATA_NEG_FILLER2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 SI4922B-LK-DATA-NEG-DD         PIC X(02).*/
                public StringBasis SI4922B_LK_DATA_NEG_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"    05 SI4922B-LK-PARAMETROS-SAIDA.*/
            }
            public SI5066B_SI4922B_LK_PARAMETROS_SAIDA SI4922B_LK_PARAMETROS_SAIDA { get; set; } = new SI5066B_SI4922B_LK_PARAMETROS_SAIDA();
            public class SI5066B_SI4922B_LK_PARAMETROS_SAIDA : VarBasis
            {
                /*"       10 SI4922B-LK-DATA-CRED-EM-CONTA  PIC X(10).*/
                public StringBasis SI4922B_LK_DATA_CRED_EM_CONTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"       10 SI4922B-LK-CHAVE-GERA-BAIXA    PIC X(03).*/
                public StringBasis SI4922B_LK_CHAVE_GERA_BAIXA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"       10 SI4922B-LK-IND-ERRO            PIC X(03).*/
                public StringBasis SI4922B_LK_IND_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"       10 SI4922B-LK-MSG-ERRO            PIC X(80).*/
                public StringBasis SI4922B_LK_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
                /*"       10 SI4922B-LK-SQLCODE             PIC S9(004) COMP.*/
                public IntBasis SI4922B_LK_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"       10 SI4922B-LK-NOME-TABELA         PIC X(30).*/
                public StringBasis SI4922B_LK_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
                /*"01 WABEND.*/
            }
        }
        public SI5066B_WABEND WABEND { get; set; } = new SI5066B_WABEND();
        public class SI5066B_WABEND : VarBasis
        {
            /*"   10 FILLER              PIC  X(009) VALUE 'SI5066B '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI5066B ");
            /*"   10 FILLER              PIC  X(035) VALUE      ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
            /*"   10 WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"   10 FILLER              PIC  X(013) VALUE      ' *** SQLCODE '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"   10 WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01              LPARM01X.*/
        }
        public SI5066B_LPARM01X LPARM01X { get; set; } = new SI5066B_LPARM01X();
        public class SI5066B_LPARM01X : VarBasis
        {
            /*"  03            LPARM01         PIC  9(015).*/
            public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  03            LPARM01-R       REDEFINES   LPARM01.*/
            private _REDEF_SI5066B_LPARM01_R _lparm01_r { get; set; }
            public _REDEF_SI5066B_LPARM01_R LPARM01_R
            {
                get { _lparm01_r = new _REDEF_SI5066B_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
                set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
            }  //Redefines
            public class _REDEF_SI5066B_LPARM01_R : VarBasis
            {
                /*"    05          LPARM01-1       PIC  9(001).*/
                public IntBasis LPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-2       PIC  9(001).*/
                public IntBasis LPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-3       PIC  9(001).*/
                public IntBasis LPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-4       PIC  9(001).*/
                public IntBasis LPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-5       PIC  9(001).*/
                public IntBasis LPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-6       PIC  9(001).*/
                public IntBasis LPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-7       PIC  9(001).*/
                public IntBasis LPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-8       PIC  9(001).*/
                public IntBasis LPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-9       PIC  9(001).*/
                public IntBasis LPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-10      PIC  9(001).*/
                public IntBasis LPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-11      PIC  9(001).*/
                public IntBasis LPARM01_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-12      PIC  9(001).*/
                public IntBasis LPARM01_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-13      PIC  9(001).*/
                public IntBasis LPARM01_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-14      PIC  9(001).*/
                public IntBasis LPARM01_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-15      PIC  9(001).*/
                public IntBasis LPARM01_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03            LPARM02         PIC S9(004) COMP.*/

                public _REDEF_SI5066B_LPARM01_R()
                {
                    LPARM01_1.ValueChanged += OnValueChanged;
                    LPARM01_2.ValueChanged += OnValueChanged;
                    LPARM01_3.ValueChanged += OnValueChanged;
                    LPARM01_4.ValueChanged += OnValueChanged;
                    LPARM01_5.ValueChanged += OnValueChanged;
                    LPARM01_6.ValueChanged += OnValueChanged;
                    LPARM01_7.ValueChanged += OnValueChanged;
                    LPARM01_8.ValueChanged += OnValueChanged;
                    LPARM01_9.ValueChanged += OnValueChanged;
                    LPARM01_10.ValueChanged += OnValueChanged;
                    LPARM01_11.ValueChanged += OnValueChanged;
                    LPARM01_12.ValueChanged += OnValueChanged;
                    LPARM01_13.ValueChanged += OnValueChanged;
                    LPARM01_14.ValueChanged += OnValueChanged;
                    LPARM01_15.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03            LPARM03         PIC  9(001).*/
            public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03            LPARM03-R       REDEFINES   LPARM03                                PIC  X(001).*/
            private _REDEF_StringBasis _lparm03_r { get; set; }
            public _REDEF_StringBasis LPARM03_R
            {
                get { _lparm03_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM03, _lparm03_r); VarBasis.RedefinePassValue(LPARM03, _lparm03_r, LPARM03); _lparm03_r.ValueChanged += () => { _.Move(_lparm03_r, LPARM03); }; return _lparm03_r; }
                set { VarBasis.RedefinePassValue(value, _lparm03_r, LPARM03); }
            }  //Redefines
            /*" 01 SI1040S                     PIC X(07)      VALUE 'SI1040S'.*/
            public StringBasis SI1040S { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI1040S");
        }


        public Copies.LBSI505B LBSI505B { get; set; } = new Copies.LBSI505B();
        public Copies.LBSI1040 LBSI1040 { get; set; } = new Copies.LBSI1040();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.PARAMCON PARAMCON { get; set; } = new Dclgens.PARAMCON();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.RALCHEDO RALCHEDO { get; set; } = new Dclgens.RALCHEDO();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.CHEQUEMI CHEQUEMI { get; set; } = new Dclgens.CHEQUEMI();
        public Dclgens.SISINCHE SISINCHE { get; set; } = new Dclgens.SISINCHE();
        public Dclgens.HISTOCHE HISTOCHE { get; set; } = new Dclgens.HISTOCHE();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SISINACO SISINACO { get; set; } = new Dclgens.SISINACO();
        public Dclgens.SIHISACO SIHISACO { get; set; } = new Dclgens.SIHISACO();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.GE369 GE369 { get; set; } = new Dclgens.GE369();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public SI5066B_SINISTRO SINISTRO { get; set; } = new SI5066B_SINISTRO();
        public SI5066B_C01_RALCHEDO C01_RALCHEDO { get; set; } = new SI5066B_C01_RALCHEDO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -322- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -323- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -324- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -331- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -335- DISPLAY 'INICIO PARTE 1 - ' HOST-TIMESTAMP */
                _.Display($"INICIO PARTE 1 - {AREA_DE_WORK.HOST_TIMESTAMP}");

                /*" -337- MOVE 'NAO' TO W-CHAVE-PROCESSA. */
                _.Move("NAO", AREA_DE_WORK.W_CHAVE_PROCESSA);

                /*" -339- PERFORM R0010-SELECT-SISTEMAS THRU R0010-EXIT. */

                R0010_SELECT_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_EXIT*/


                /*" -353- PERFORM R0015-MONTA-DATA-VENCIMENTO THRU R0015-EXIT. */

                R0015_MONTA_DATA_VENCIMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_EXIT*/


                /*" -354- IF W-CHAVE-PROCESSA EQUAL 'NAO' */

                if (AREA_DE_WORK.W_CHAVE_PROCESSA == "NAO")
                {

                    /*" -355- DISPLAY '*************************************************' */
                    _.Display($"*************************************************");

                    /*" -356- DISPLAY '*                                               *' */
                    _.Display($"*                                               *");

                    /*" -357- DISPLAY '*                  SI5066B                     *' */
                    _.Display($"*                  SI5066B                     *");

                    /*" -358- DISPLAY '*                                               *' */
                    _.Display($"*                                               *");

                    /*" -359- DISPLAY '* ESTE PROGRAMA SO PROCESSA NO PRIMEIRO DIA UTIL*' */
                    _.Display($"* ESTE PROGRAMA SO PROCESSA NO PRIMEIRO DIA UTIL*");

                    /*" -360- DISPLAY '* DO MES QUE EH ' W-DATA-PRIMEIRO-DIA-UTIL */
                    _.Display($"* DO MES QUE EH {AREA_DE_WORK.W_DATA_PRIMEIRO_DIA_UTIL}");

                    /*" -361- DISPLAY '*                                               *' */
                    _.Display($"*                                               *");

                    /*" -362- DISPLAY '* SO QUE HOJE EH ' HOST-SI-DATA-MOV-ABERTO */
                    _.Display($"* SO QUE HOJE EH {HOST_SI_DATA_MOV_ABERTO}");

                    /*" -363- DISPLAY '*                                               *' */
                    _.Display($"*                                               *");

                    /*" -364- DISPLAY '*   PROGRAMA TERMINADO COM CONDICAO NORMAL      *' */
                    _.Display($"*   PROGRAMA TERMINADO COM CONDICAO NORMAL      *");

                    /*" -365- DISPLAY '*                                               *' */
                    _.Display($"*                                               *");

                    /*" -366- DISPLAY '*************************************************' */
                    _.Display($"*************************************************");

                    /*" -377- GO TO FINAL-PROGRAMA. */

                    FINAL_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -383- PERFORM Execute_DB_SELECT_2 */

                Execute_DB_SELECT_2();

                /*" -387- DISPLAY 'INICIO PARTE 2 - GERANDO RALACAO ' HOST-TIMESTAMP */
                _.Display($"INICIO PARTE 2 - GERANDO RALACAO {AREA_DE_WORK.HOST_TIMESTAMP}");

                /*" -389- MOVE 'NAO' TO WFIM-SELECAO. */
                _.Move("NAO", AREA_DE_WORK.WFIM_SELECAO);

                /*" -390- PERFORM R0020-DECLARE-PRINCIPAL THRU R0020-EXIT. */

                R0020_DECLARE_PRINCIPAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/


                /*" -392- PERFORM R0021-FETCH-PRINCIPAL THRU R0021-EXIT. */

                R0021_FETCH_PRINCIPAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0021_EXIT*/


                /*" -393- IF WFIM-SELECAO EQUAL 'SIM' */

                if (AREA_DE_WORK.WFIM_SELECAO == "SIM")
                {

                    /*" -394- DISPLAY '*************************************************' */
                    _.Display($"*************************************************");

                    /*" -395- DISPLAY '*                                               *' */
                    _.Display($"*                                               *");

                    /*" -396- DISPLAY '*                   SI5066B                     *' */
                    _.Display($"*                   SI5066B                     *");

                    /*" -397- DISPLAY '*                                               *' */
                    _.Display($"*                                               *");

                    /*" -398- DISPLAY '*        NADA SELECIONADO NA DATA DE HOJE       *' */
                    _.Display($"*        NADA SELECIONADO NA DATA DE HOJE       *");

                    /*" -399- DISPLAY '*                                               *' */
                    _.Display($"*                                               *");

                    /*" -400- DISPLAY '*                TERMINO NORMAL                 *' */
                    _.Display($"*                TERMINO NORMAL                 *");

                    /*" -401- DISPLAY '*                                               *' */
                    _.Display($"*                                               *");

                    /*" -402- DISPLAY '*************************************************' */
                    _.Display($"*************************************************");

                    /*" -404- GO TO FINAL-PROGRAMA. */

                    FINAL_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -414- PERFORM R0100-PROCESSA-PRINCIPAL THRU R0100-EXIT UNTIL WFIM-SELECAO EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_SELECAO == "SIM"))
                {

                    R0100_PROCESSA_PRINCIPAL(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_EXIT*/

                }

                /*" -420- PERFORM Execute_DB_SELECT_3 */

                Execute_DB_SELECT_3();

                /*" -424- DISPLAY 'INICIO PARTE 3 - GERANDO CHEQUE  ' HOST-TIMESTAMP */
                _.Display($"INICIO PARTE 3 - GERANDO CHEQUE  {AREA_DE_WORK.HOST_TIMESTAMP}");

                /*" -426- MOVE 'NAO' TO WFIM-SELECAO. */
                _.Move("NAO", AREA_DE_WORK.WFIM_SELECAO);

                /*" -427- PERFORM R0200-DECLARE-RALCHEDO THRU R0200-EXIT. */

                R0200_DECLARE_RALCHEDO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_EXIT*/


                /*" -429- PERFORM R0201-FETCH-RALCHEDO THRU R0201-EXIT. */

                R0201_FETCH_RALCHEDO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0201_EXIT*/


                /*" -432- PERFORM R0300-PROCESSA-RALCHEDO THRU R0300-EXIT UNTIL WFIM-SELECAO EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_SELECAO == "SIM"))
                {

                    R0300_PROCESSA_RALCHEDO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_EXIT*/

                }

                /*" -433- DISPLAY '*************************************************' */
                _.Display($"*************************************************");

                /*" -434- DISPLAY '*                                               *' */
                _.Display($"*                                               *");

                /*" -435- DISPLAY '*                   SI5066B                     *' */
                _.Display($"*                   SI5066B                     *");

                /*" -436- DISPLAY '*                                               *' */
                _.Display($"*                                               *");

                /*" -437- DISPLAY '*                TERMINO NORMAL                 *' */
                _.Display($"*                TERMINO NORMAL                 *");

                /*" -438- DISPLAY '*                                               *' */
                _.Display($"*                                               *");

                /*" -439- DISPLAY '*************************************************' */
                _.Display($"*************************************************");

                /*" -440- MOVE W-QTD-LINHAS-MOVDEBCC TO W-EDICAO1 */
                _.Move(AREA_DE_WORK.W_QTD_LINHAS_MOVDEBCC, AREA_DE_WORK.W_EDICAO1);

                /*" -442- DISPLAY 'QTD. DE CHEQUES E MOVDEBCC GERADOS = ' W-EDICAO1 */
                _.Display($"QTD. DE CHEQUES E MOVDEBCC GERADOS = {AREA_DE_WORK.W_EDICAO1}");

                /*" -443- MOVE W-VALOR-TOTAL-PAGO TO W-EDICAO2 */
                _.Move(AREA_DE_WORK.W_VALOR_TOTAL_PAGO, AREA_DE_WORK.W_EDICAO2);

                /*" -445- DISPLAY 'VALOR TOTAL DE REPASSES = ' W-EDICAO2. */
                _.Display($"VALOR TOTAL DE REPASSES = {AREA_DE_WORK.W_EDICAO2}");

                /*" -451- PERFORM Execute_DB_SELECT_4 */

                Execute_DB_SELECT_4();

                /*" -453- DISPLAY 'FIM DO PROGRAMA ' HOST-TIMESTAMP . */
                _.Display($"FIM DO PROGRAMA {AREA_DE_WORK.HOST_TIMESTAMP}");

                /*" -453- FLUXCONTROL_PERFORM Execute-DB-SELECT-1 */

                Execute_DB_SELECT_1();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SELECT-1 */
        public void Execute_DB_SELECT_1()
        {
            /*" -331- EXEC SQL SELECT CURRENT TIMESTAMP INTO :HOST-TIMESTAMP FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_TIMESTAMP, AREA_DE_WORK.HOST_TIMESTAMP);
            }


        }

        [StopWatch]
        /*" FINAL-PROGRAMA */
        private void FINAL_PROGRAMA(bool isPerform = false)
        {
            /*" -460- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -460- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -462- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" Execute-DB-SELECT-2 */
        public void Execute_DB_SELECT_2()
        {
            /*" -383- EXEC SQL SELECT CURRENT TIMESTAMP INTO :HOST-TIMESTAMP FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

            var execute_DB_SELECT_2_Query1 = new Execute_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_2_Query1.Execute(execute_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_TIMESTAMP, AREA_DE_WORK.HOST_TIMESTAMP);
            }


        }

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS */
        private void R0010_SELECT_SISTEMAS(bool isPerform = false)
        {
            /*" -469- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -475- PERFORM R0010_SELECT_SISTEMAS_DB_SELECT_1 */

            R0010_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -478- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -479- DISPLAY 'SI5066B - ERRO NO ACESSO SISTEMAS - FI' */
                _.Display($"SI5066B - ERRO NO ACESSO SISTEMAS - FI");

                /*" -481- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -487- PERFORM R0010_SELECT_SISTEMAS_DB_SELECT_2 */

            R0010_SELECT_SISTEMAS_DB_SELECT_2();

            /*" -490- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -491- DISPLAY 'SI5066B - ERRO NO ACESSO SISTEMAS - SI' */
                _.Display($"SI5066B - ERRO NO ACESSO SISTEMAS - SI");

                /*" -499- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -500- MOVE HOST-SI-DATA-MOV-ABERTO TO WDATA. */
            _.Move(HOST_SI_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA);

            /*" -502- MOVE HOST-SI-DATA-MOV-ABERTO TO SISTEMAS-DATA-MOV-ABERTO */
            _.Move(HOST_SI_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

            /*" -503- DISPLAY ' ' */
            _.Display($" ");

            /*" -504- DISPLAY '**************************************************' */
            _.Display($"**************************************************");

            /*" -505- DISPLAY '* SI5066B - PROGRAMA DE GERACAO DOS PAGAMENTOS   *' */
            _.Display($"* SI5066B - PROGRAMA DE GERACAO DOS PAGAMENTOS   *");

            /*" -506- DISPLAY '* PELO CONVENIO SIACC DA CAIXA                   *' */
            _.Display($"* PELO CONVENIO SIACC DA CAIXA                   *");

            /*" -507- DISPLAY '* CONVENIO CAIXA = 043350                        *' */
            _.Display($"* CONVENIO CAIXA = 043350                        *");

            /*" -508- DISPLAY '* ESTE PROGRAMA PROCESSA APENAS REPASSE DE       *' */
            _.Display($"* ESTE PROGRAMA PROCESSA APENAS REPASSE DE       *");

            /*" -509- DISPLAY '* RESSARCIMENTO                                  *' */
            _.Display($"* RESSARCIMENTO                                  *");

            /*" -513- DISPLAY '* DATA DO PROCESSAMENTO (FI) - FINANCEIRO ' WDATA-DIA '/' WDATA-MES '/' WDATA-ANO '          *' */

            $"* DATA DO PROCESSAMENTO (FI) - FINANCEIRO {AREA_DE_WORK.WDATA.WDATA_DIA}/{AREA_DE_WORK.WDATA.WDATA_MES}/{AREA_DE_WORK.WDATA.WDATA_ANO}          *"
            .Display();

            /*" -517- DISPLAY '* DATA DO PROCESSAMENTO (SI) - SINISTRO   ' WDATA-DIA '/' WDATA-MES '/' WDATA-ANO '          *' */

            $"* DATA DO PROCESSAMENTO (SI) - SINISTRO   {AREA_DE_WORK.WDATA.WDATA_DIA}/{AREA_DE_WORK.WDATA.WDATA_MES}/{AREA_DE_WORK.WDATA.WDATA_ANO}          *"
            .Display();

            /*" -519- DISPLAY '**************************************************' . */
            _.Display($"**************************************************");

            /*" -520- MOVE HOST-SI-DATA-MOV-ABERTO TO W-DIA01-MES-CORRENTE */
            _.Move(HOST_SI_DATA_MOV_ABERTO, AREA_DE_WORK.W_DIA01_MES_CORRENTE);

            /*" -522- MOVE '01' TO W-DIA01-MES-CORRENTE(9:2). */
            _.MoveAtPosition("01", AREA_DE_WORK.W_DIA01_MES_CORRENTE, 9, 2);

            /*" -531- PERFORM R0010_SELECT_SISTEMAS_DB_SELECT_3 */

            R0010_SELECT_SISTEMAS_DB_SELECT_3();

            /*" -534- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -535- DISPLAY 'SI5066B - ERRO NO ACESSO SISTEMAS - SI' */
                _.Display($"SI5066B - ERRO NO ACESSO SISTEMAS - SI");

                /*" -537- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -538- IF W-DATA-PRIMEIRO-DIA-UTIL EQUAL HOST-SI-DATA-MOV-ABERTO */

            if (AREA_DE_WORK.W_DATA_PRIMEIRO_DIA_UTIL == HOST_SI_DATA_MOV_ABERTO)
            {

                /*" -539- MOVE 'SIM' TO W-CHAVE-PROCESSA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_PROCESSA);

                /*" -540- ELSE */
            }
            else
            {


                /*" -541- MOVE 'NAO' TO W-CHAVE-PROCESSA */
                _.Move("NAO", AREA_DE_WORK.W_CHAVE_PROCESSA);

                /*" -542- DISPLAY ' ' */
                _.Display($" ");

                /*" -543- DISPLAY '***************************************************' */
                _.Display($"***************************************************");

                /*" -544- DISPLAY '*                                                 *' */
                _.Display($"*                                                 *");

                /*" -545- DISPLAY '* ESTE PROGRAMA NAO VAI EXECUTAR HOJE, PORQUE NAO *' */
                _.Display($"* ESTE PROGRAMA NAO VAI EXECUTAR HOJE, PORQUE NAO *");

                /*" -546- DISPLAY '* EH O PRIMEIRO DIA UTIL DO MES.                  *' */
                _.Display($"* EH O PRIMEIRO DIA UTIL DO MES.                  *");

                /*" -547- DISPLAY '*                                                 *' */
                _.Display($"*                                                 *");

                /*" -548- DISPLAY '***************************************************' */
                _.Display($"***************************************************");

                /*" -549- DISPLAY 'CHAVE DE PROCESSA O DIA? ' W-CHAVE-PROCESSA */
                _.Display($"CHAVE DE PROCESSA O DIA? {AREA_DE_WORK.W_CHAVE_PROCESSA}");

                /*" -549- DISPLAY ' ' . */
                _.Display($" ");
            }


        }

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0010_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -475- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

            var r0010_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0010_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }

        [StopWatch]
        /*" Execute-DB-SELECT-3 */
        public void Execute_DB_SELECT_3()
        {
            /*" -420- EXEC SQL SELECT CURRENT TIMESTAMP INTO :HOST-TIMESTAMP FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

            var execute_DB_SELECT_3_Query1 = new Execute_DB_SELECT_3_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_3_Query1.Execute(execute_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_TIMESTAMP, AREA_DE_WORK.HOST_TIMESTAMP);
            }


        }

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS-DB-SELECT-2 */
        public void R0010_SELECT_SISTEMAS_DB_SELECT_2()
        {
            /*" -487- EXEC SQL SELECT DATA_MOV_ABERTO INTO :HOST-SI-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

            var r0010_SELECT_SISTEMAS_DB_SELECT_2_Query1 = new R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1.Execute(r0010_SELECT_SISTEMAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_SI_DATA_MOV_ABERTO, HOST_SI_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_EXIT*/

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS-DB-SELECT-3 */
        public void R0010_SELECT_SISTEMAS_DB_SELECT_3()
        {
            /*" -531- EXEC SQL SELECT VALUE(MIN(DATA_CALENDARIO), '0001-01-01' ) INTO :W-DATA-PRIMEIRO-DIA-UTIL FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO <= :HOST-SI-DATA-MOV-ABERTO AND DATA_CALENDARIO >= :W-DIA01-MES-CORRENTE AND DIA_SEMANA NOT IN ( 'S' , 'D' ) AND FERIADO = ' ' WITH UR END-EXEC. */

            var r0010_SELECT_SISTEMAS_DB_SELECT_3_Query1 = new R0010_SELECT_SISTEMAS_DB_SELECT_3_Query1()
            {
                HOST_SI_DATA_MOV_ABERTO = HOST_SI_DATA_MOV_ABERTO.ToString(),
                W_DIA01_MES_CORRENTE = AREA_DE_WORK.W_DIA01_MES_CORRENTE.ToString(),
            };

            var executed_1 = R0010_SELECT_SISTEMAS_DB_SELECT_3_Query1.Execute(r0010_SELECT_SISTEMAS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_DATA_PRIMEIRO_DIA_UTIL, AREA_DE_WORK.W_DATA_PRIMEIRO_DIA_UTIL);
            }


        }

        [StopWatch]
        /*" Execute-DB-SELECT-4 */
        public void Execute_DB_SELECT_4()
        {
            /*" -451- EXEC SQL SELECT CURRENT TIMESTAMP INTO :HOST-TIMESTAMP FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

            var execute_DB_SELECT_4_Query1 = new Execute_DB_SELECT_4_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_4_Query1.Execute(execute_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_TIMESTAMP, AREA_DE_WORK.HOST_TIMESTAMP);
            }


        }

        [StopWatch]
        /*" R0015-MONTA-DATA-VENCIMENTO */
        private void R0015_MONTA_DATA_VENCIMENTO(bool isPerform = false)
        {
            /*" -560- MOVE '7' TO SI4922B-LK-FORMA-PAGAMENTO. */
            _.Move("7", SI4922B_LK_PARAMETRO.SI4922B_LK_FORMA_PAGAMENTO);

            /*" -564- MOVE SISTEMAS-DATA-MOV-ABERTO TO SI4922B-LK-DATA-SIST SI4922B-LK-DATA-NEG. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SI4922B_LK_PARAMETRO.SI4922B_LK_DATA_SIST, SI4922B_LK_PARAMETRO.SI4922B_LK_DATA_NEG);

            /*" -565- DISPLAY ' ' */
            _.Display($" ");

            /*" -567- DISPLAY 'SI4922B - SUBROTINA DE CALCULO DAS DATAS DE FLOAT DO 'S CONVENIOS SIACC, BANCO BRASIL E SICOV' */

            $"SI4922B - SUBROTINA DE CALCULO DAS DATAS DE FLOAT DO {LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_RC}CONVENIOSSIACC,BANCOBRASILESICOV"
            .Display();

            /*" -568- DISPLAY ' ' */
            _.Display($" ");

            /*" -569- DISPLAY 'FORMAS DE PAGAMENTO: 2 - SICOV OU BB | 7 - SIACC' */
            _.Display($"FORMAS DE PAGAMENTO: 2 - SICOV OU BB | 7 - SIACC");

            /*" -572- DISPLAY 'FORMA - ' SI4922B-LK-FORMA-PAGAMENTO ' DT SIS ' SI4922B-LK-DATA-SIST */

            $"FORMA - {SI4922B_LK_PARAMETRO.SI4922B_LK_FORMA_PAGAMENTO} DT SIS {SI4922B_LK_PARAMETRO.SI4922B_LK_DATA_SIST}"
            .Display();

            /*" -573- DISPLAY ' ' */
            _.Display($" ");

            /*" -575- DISPLAY 'VAI CHAMAR SI4922B' . */
            _.Display($"VAI CHAMAR SI4922B");

            /*" -576- CALL 'SI4922B' USING SI4922B-LK-PARAMETRO. */
            _.Call("SI4922B", SI4922B_LK_PARAMETRO);

            /*" -580- DISPLAY 'RETORNO DA SI4922B' . */
            _.Display($"RETORNO DA SI4922B");

            /*" -581- DISPLAY ' ' */
            _.Display($" ");

            /*" -582- DISPLAY 'A DATA ABAIXO SERA A UTILIZADA PARA O CREDITO NA ' */
            _.Display($"A DATA ABAIXO SERA A UTILIZADA PARA O CREDITO NA ");

            /*" -583- DISPLAY 'AGENCIA - MOVTO_DEBITOCC_CEF.DATA_VENCIMENTO' */
            _.Display($"AGENCIA - MOVTO_DEBITOCC_CEF.DATA_VENCIMENTO");

            /*" -584- DISPLAY ' ' */
            _.Display($" ");

            /*" -586- DISPLAY 'LK-DATA-CREDITO-EM-CONTA..' SI4922B-LK-DATA-CRED-EM-CONTA */
            _.Display($"LK-DATA-CREDITO-EM-CONTA..{SI4922B_LK_PARAMETRO.SI4922B_LK_PARAMETROS_SAIDA.SI4922B_LK_DATA_CRED_EM_CONTA}");

            /*" -593- DISPLAY 'LK-CHAVE-GERA-BAIXA.......' SI4922B-LK-CHAVE-GERA-BAIXA */
            _.Display($"LK-CHAVE-GERA-BAIXA.......{SI4922B_LK_PARAMETRO.SI4922B_LK_PARAMETROS_SAIDA.SI4922B_LK_CHAVE_GERA_BAIXA}");

            /*" -594- IF SI4922B-LK-IND-ERRO EQUAL 'SIM' */

            if (SI4922B_LK_PARAMETRO.SI4922B_LK_PARAMETROS_SAIDA.SI4922B_LK_IND_ERRO == "SIM")
            {

                /*" -595- DISPLAY 'ERRO NA CHAMADA DA SI4922B' */
                _.Display($"ERRO NA CHAMADA DA SI4922B");

                /*" -596- DISPLAY 'MSG - ' SI4922B-LK-MSG-ERRO */
                _.Display($"MSG - {SI4922B_LK_PARAMETRO.SI4922B_LK_PARAMETROS_SAIDA.SI4922B_LK_MSG_ERRO}");

                /*" -597- DISPLAY 'SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -598- DISPLAY 'OCORHIST  = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -599- DISPLAY 'OPERACAO  = ' SINISHIS-COD-OPERACAO */
                _.Display($"OPERACAO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

                /*" -600- DISPLAY 'LINK-IND-ERRO..... ' SI4922B-LK-IND-ERRO */
                _.Display($"LINK-IND-ERRO..... {SI4922B_LK_PARAMETRO.SI4922B_LK_PARAMETROS_SAIDA.SI4922B_LK_IND_ERRO}");

                /*" -601- DISPLAY 'LINK-MSG-ERRO..... ' SI4922B-LK-MSG-ERRO */
                _.Display($"LINK-MSG-ERRO..... {SI4922B_LK_PARAMETRO.SI4922B_LK_PARAMETROS_SAIDA.SI4922B_LK_MSG_ERRO}");

                /*" -602- DISPLAY 'LINK-SQLCODE...... ' SI4922B-LK-SQLCODE */
                _.Display($"LINK-SQLCODE...... {SI4922B_LK_PARAMETRO.SI4922B_LK_PARAMETROS_SAIDA.SI4922B_LK_SQLCODE}");

                /*" -603- DISPLAY 'LINK-NOME-TABELA.. ' SI4922B-LK-NOME-TABELA */
                _.Display($"LINK-NOME-TABELA.. {SI4922B_LK_PARAMETRO.SI4922B_LK_PARAMETROS_SAIDA.SI4922B_LK_NOME_TABELA}");

                /*" -603- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_EXIT*/

        [StopWatch]
        /*" R0020-DECLARE-PRINCIPAL */
        private void R0020_DECLARE_PRINCIPAL(bool isPerform = false)
        {
            /*" -611- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -635- PERFORM R0020_DECLARE_PRINCIPAL_DB_DECLARE_1 */

            R0020_DECLARE_PRINCIPAL_DB_DECLARE_1();

            /*" -637- PERFORM R0020_DECLARE_PRINCIPAL_DB_OPEN_1 */

            R0020_DECLARE_PRINCIPAL_DB_OPEN_1();

            /*" -639- IF SQLCODE < 0 */

            if (DB.SQLCODE < 0)
            {

                /*" -639- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0020-DECLARE-PRINCIPAL-DB-DECLARE-1 */
        public void R0020_DECLARE_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -635- EXEC SQL DECLARE SINISTRO CURSOR FOR SELECT H.NUM_APOL_SINISTRO, H.OCORR_HISTORICO, S.PONTO_VENDA FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_HABIT01 S, SEGUROS.GE_OPERACAO O WHERE H.DATA_MOVIMENTO >= '2009-03-01' AND H.SIT_REGISTRO = '5' AND H.SIT_CONTABIL = '7' AND S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND O.IDE_SISTEMA = 'SI' AND O.COD_OPERACAO = H.COD_OPERACAO AND O.FUNCAO_OPERACAO = 'RSRLB' ORDER BY H.NUM_APOL_SINISTRO, H.OCORR_HISTORICO WITH UR END-EXEC. */
            SINISTRO = new SI5066B_SINISTRO(false);
            string GetQuery_SINISTRO()
            {
                var query = @$"SELECT H.NUM_APOL_SINISTRO
							, 
							H.OCORR_HISTORICO
							, 
							S.PONTO_VENDA 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_HABIT01 S
							, 
							SEGUROS.GE_OPERACAO O 
							WHERE H.DATA_MOVIMENTO >= '2009-03-01' 
							AND H.SIT_REGISTRO = '5' 
							AND H.SIT_CONTABIL = '7' 
							AND S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.COD_OPERACAO = H.COD_OPERACAO 
							AND O.FUNCAO_OPERACAO = 'RSRLB' 
							ORDER BY H.NUM_APOL_SINISTRO
							, H.OCORR_HISTORICO";

                return query;
            }
            SINISTRO.GetQueryEvent += GetQuery_SINISTRO;

        }

        [StopWatch]
        /*" R0020-DECLARE-PRINCIPAL-DB-OPEN-1 */
        public void R0020_DECLARE_PRINCIPAL_DB_OPEN_1()
        {
            /*" -637- EXEC SQL OPEN SINISTRO END-EXEC. */

            SINISTRO.Open();

        }

        [StopWatch]
        /*" R0200-DECLARE-RALCHEDO-DB-DECLARE-1 */
        public void R0200_DECLARE_RALCHEDO_DB_DECLARE_1()
        {
            /*" -809- EXEC SQL DECLARE C01_RALCHEDO CURSOR FOR SELECT H.NUM_APOL_SINISTRO, H.NUM_APOLICE, H.OCORR_HISTORICO, H.COD_OPERACAO, H.DATA_MOVIMENTO, H.NOME_FAVORECIDO, H.VAL_OPERACAO, H.DATA_LIM_CORRECAO, H.TIPO_FAVORECIDO, H.COD_PREST_SERVICO, H.COD_SERVICO, H.NUM_RECIBO, H.SIT_CONTABIL, H.SIT_REGISTRO, M.COD_PRODUTO, M.NUM_APOLICE, M.RAMO, M.COD_FONTE, M.NUM_PROTOCOLO_SINI, M.DAC_PROTOCOLO_SINI, O.FUNCAO_OPERACAO, R.AGE_CENTRAL_PROD01, R.NUMDOC_NUM01, R.OCORR_HISTORICO FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.RALACAO_CHEQ_DOCTO R, SEGUROS.GE_OPERACAO O WHERE H.DATA_MOVIMENTO >= '2009-03-01' AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.SIT_REGISTRO = '5' AND H.SIT_CONTABIL = '7' AND O.IDE_SISTEMA = 'SI' AND O.COD_OPERACAO = H.COD_OPERACAO AND O.FUNCAO_OPERACAO = 'RSRLB' AND R.NUMDOC_NUM01 = H.NUM_APOL_SINISTRO AND R.OCORR_HISTORICO = H.OCORR_HISTORICO AND R.TIMESTAMP = '2999-01-01-01.01.01.010101' ORDER BY R.AGE_CENTRAL_PROD01, H.NUM_APOL_SINISTRO, H.OCORR_HISTORICO WITH UR END-EXEC. */
            C01_RALCHEDO = new SI5066B_C01_RALCHEDO(false);
            string GetQuery_C01_RALCHEDO()
            {
                var query = @$"SELECT H.NUM_APOL_SINISTRO
							, 
							H.NUM_APOLICE
							, 
							H.OCORR_HISTORICO
							, 
							H.COD_OPERACAO
							, 
							H.DATA_MOVIMENTO
							, 
							H.NOME_FAVORECIDO
							, 
							H.VAL_OPERACAO
							, 
							H.DATA_LIM_CORRECAO
							, 
							H.TIPO_FAVORECIDO
							, 
							H.COD_PREST_SERVICO
							, 
							H.COD_SERVICO
							, 
							H.NUM_RECIBO
							, 
							H.SIT_CONTABIL
							, 
							H.SIT_REGISTRO
							, 
							M.COD_PRODUTO
							, 
							M.NUM_APOLICE
							, 
							M.RAMO
							, 
							M.COD_FONTE
							, 
							M.NUM_PROTOCOLO_SINI
							, 
							M.DAC_PROTOCOLO_SINI
							, 
							O.FUNCAO_OPERACAO
							, 
							R.AGE_CENTRAL_PROD01
							, 
							R.NUMDOC_NUM01
							, 
							R.OCORR_HISTORICO 
							FROM SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.RALACAO_CHEQ_DOCTO R
							, 
							SEGUROS.GE_OPERACAO O 
							WHERE H.DATA_MOVIMENTO >= '2009-03-01' 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND H.SIT_REGISTRO = '5' 
							AND H.SIT_CONTABIL = '7' 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.COD_OPERACAO = H.COD_OPERACAO 
							AND O.FUNCAO_OPERACAO = 'RSRLB' 
							AND R.NUMDOC_NUM01 = H.NUM_APOL_SINISTRO 
							AND R.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND R.TIMESTAMP = '2999-01-01-01.01.01.010101' 
							ORDER BY R.AGE_CENTRAL_PROD01
							, 
							H.NUM_APOL_SINISTRO
							, 
							H.OCORR_HISTORICO";

                return query;
            }
            C01_RALCHEDO.GetQueryEvent += GetQuery_C01_RALCHEDO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/

        [StopWatch]
        /*" R0021-FETCH-PRINCIPAL */
        private void R0021_FETCH_PRINCIPAL(bool isPerform = false)
        {
            /*" -647- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -651- PERFORM R0021_FETCH_PRINCIPAL_DB_FETCH_1 */

            R0021_FETCH_PRINCIPAL_DB_FETCH_1();

            /*" -654- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -654- PERFORM R0021_FETCH_PRINCIPAL_DB_CLOSE_1 */

                R0021_FETCH_PRINCIPAL_DB_CLOSE_1();

                /*" -656- MOVE 'SIM' TO WFIM-SELECAO */
                _.Move("SIM", AREA_DE_WORK.WFIM_SELECAO);

                /*" -658- GO TO R0021-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0021_EXIT*/ //GOTO
                return;
            }


            /*" -659- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -660- DISPLAY 'R0021 - ERRO NO FETCH DA SINISTRO_HISTORICO' */
                _.Display($"R0021 - ERRO NO FETCH DA SINISTRO_HISTORICO");

                /*" -660- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0021-FETCH-PRINCIPAL-DB-FETCH-1 */
        public void R0021_FETCH_PRINCIPAL_DB_FETCH_1()
        {
            /*" -651- EXEC SQL FETCH SINISTRO INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINIHAB1-PONTO-VENDA END-EXEC. */

            if (SINISTRO.Fetch())
            {
                _.Move(SINISTRO.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(SINISTRO.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(SINISTRO.SINIHAB1_PONTO_VENDA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);
            }

        }

        [StopWatch]
        /*" R0021-FETCH-PRINCIPAL-DB-CLOSE-1 */
        public void R0021_FETCH_PRINCIPAL_DB_CLOSE_1()
        {
            /*" -654- EXEC SQL CLOSE SINISTRO END-EXEC */

            SINISTRO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0021_EXIT*/

        [StopWatch]
        /*" R0100-PROCESSA-PRINCIPAL */
        private void R0100_PROCESSA_PRINCIPAL(bool isPerform = false)
        {
            /*" -668- INITIALIZE DCLRALACAO-CHEQ-DOCTO. */
            _.Initialize(
                RALCHEDO.DCLRALACAO_CHEQ_DOCTO
            );

            /*" -669- MOVE 0 TO RALCHEDO-COD-EMPRESA. */
            _.Move(0, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_COD_EMPRESA);

            /*" -671- MOVE SINISHIS-NUM-APOL-SINISTRO TO RALCHEDO-NUMDOC-NUM01. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMDOC_NUM01);

            /*" -673- MOVE SINISHIS-NUM-APOL-SINISTRO TO W-NUM-APOL-SINISTRO-NUM. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.W_NUM_APOL_SINISTRO_NUM);

            /*" -674- MOVE W-NUM-APOL-SINISTRO-NUM TO RALCHEDO-NUM-DOCUMENTO. */
            _.Move(AREA_DE_WORK.W_NUM_APOL_SINISTRO_NUM, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUM_DOCUMENTO);

            /*" -675- MOVE SINISHIS-OCORR-HISTORICO TO RALCHEDO-OCORR-HISTORICO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_OCORR_HISTORICO);

            /*" -679- MOVE '1' TO RALCHEDO-TIPO-MOVIMENTO. */
            _.Move("1", RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_TIPO_MOVIMENTO);

            /*" -681- INITIALIZE SI0505B-PARAMETROS. */
            _.Initialize(
                LBSI505B.SI0505B_PARAMETROS
            );

            /*" -683- MOVE W-NUM-APOL-SINISTRO-NUM TO SI0505B-NUM-APOL-SINISTRO. */
            _.Move(AREA_DE_WORK.W_NUM_APOL_SINISTRO_NUM, LBSI505B.SI0505B_PARAMETROS.SI0505B_ENTRADA.SI0505B_NUM_APOL_SINISTRO);

            /*" -685- CALL W-SI0505B USING SI0505B-PARAMETROS. */
            _.Call(W_SI0505B, LBSI505B.SI0505B_PARAMETROS);

            /*" -686- IF (SI0505B-RC NOT = 0) */

            if ((LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_RC != 0))
            {

                /*" -687- DISPLAY '*** ERRO NO ACESSO A SUBROTINA SI0505B ***' */
                _.Display($"*** ERRO NO ACESSO A SUBROTINA SI0505B ***");

                /*" -688- DISPLAY '  SINISTRO  = ' SI0505B-NUM-APOL-SINISTRO */
                _.Display($"  SINISTRO  = {LBSI505B.SI0505B_PARAMETROS.SI0505B_ENTRADA.SI0505B_NUM_APOL_SINISTRO}");

                /*" -689- DISPLAY '  RC        = ' SI0505B-RC */
                _.Display($"  RC        = {LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_RC}");

                /*" -690- DISPLAY '  NUM-SQL   = ' SI0505B-NUM-SQL */
                _.Display($"  NUM-SQL   = {LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_NUM_SQL}");

                /*" -691- DISPLAY '  SQLCODE   = ' SI0505B-SQLCODE */
                _.Display($"  SQLCODE   = {LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_SQLCODE}");

                /*" -692- DISPLAY '  MENSAGEM  = ' SI0505B-MENSAGEM */
                _.Display($"  MENSAGEM  = {LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_MENSAGEM}");

                /*" -693- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -699- END-IF. */
            }


            /*" -700- MOVE SI0505B-AG-CONTRATO TO W-AGENCIA-CONTRATO. */
            _.Move(LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_AG_CONTRATO, AREA_DE_WORK.W_AGENCIA_CONTRATO);

            /*" -702- MOVE SI0505B-UNO TO W-UNO. */
            _.Move(LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_UNO, AREA_DE_WORK.W_UNO);

            /*" -703- MOVE W-AGENCIA-CONTRATO TO RALCHEDO-AGENCIA-CONTRATO */
            _.Move(AREA_DE_WORK.W_AGENCIA_CONTRATO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGENCIA_CONTRATO);

            /*" -705- MOVE W-UNO TO RALCHEDO-AGE-CENTRAL-PROD01 */
            _.Move(AREA_DE_WORK.W_UNO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGE_CENTRAL_PROD01);

            /*" -708- MOVE '2999-01-01-01.01.01.010101' TO RALCHEDO-TIMESTAMP. */
            _.Move("2999-01-01-01.01.01.010101", RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_TIMESTAMP);

            /*" -710- PERFORM R0120-GRAVA-RALCHEDO THRU R0120-EXIT. */

            R0120_GRAVA_RALCHEDO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_EXIT*/


            /*" -710- PERFORM R0021-FETCH-PRINCIPAL THRU R0021-EXIT. */

            R0021_FETCH_PRINCIPAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0021_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_EXIT*/

        [StopWatch]
        /*" R0120-GRAVA-RALCHEDO */
        private void R0120_GRAVA_RALCHEDO(bool isPerform = false)
        {
            /*" -744- PERFORM R0120_GRAVA_RALCHEDO_DB_INSERT_1 */

            R0120_GRAVA_RALCHEDO_DB_INSERT_1();

            /*" -747- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -748- DISPLAY 'R1400 - ERRO INSERT RALACAO_CHEQ_DOCTO' */
                _.Display($"R1400 - ERRO INSERT RALACAO_CHEQ_DOCTO");

                /*" -749- DISPLAY 'NUM. SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM. SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -750- DISPLAY 'OCORHIST      = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST      = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -751- DISPLAY 'COD_PREST_SERV= ' SINISHIS-COD-PREST-SERVICO */
                _.Display($"COD_PREST_SERV= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

                /*" -752- DISPLAY 'NOME FAVOREC. = ' SINISHIS-NOME-FAVORECIDO */
                _.Display($"NOME FAVOREC. = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO}");

                /*" -753- DISPLAY 'CHEQUEMI-TPMOV= ' CHEQUEMI-TIPO-MOVIMENTO */
                _.Display($"CHEQUEMI-TPMOV= {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_MOVIMENTO}");

                /*" -754- DISPLAY 'CHQINT        = ' CHEQUEMI-NUM-CHEQUE-INTERNO */
                _.Display($"CHQINT        = {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO}");

                /*" -754- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0120-GRAVA-RALCHEDO-DB-INSERT-1 */
        public void R0120_GRAVA_RALCHEDO_DB_INSERT_1()
        {
            /*" -744- EXEC SQL INSERT INTO SEGUROS.RALACAO_CHEQ_DOCTO (COD_EMPRESA, NUM_CHEQUE_INTERNO, DIG_CHEQUE_INTERNO, NUM_DOCUMENTO, OCORR_HISTORICO, TIPO_MOVIMENTO, TIMESTAMP, AGENCIA_CONTRATO, NUMERO_SIVAT, DV_SIVAT, DATA_SIVAT, AGE_CENTRAL_PROD01, NUMDOC_NUM01) VALUES (:RALCHEDO-COD-EMPRESA, :RALCHEDO-NUM-CHEQUE-INTERNO, :RALCHEDO-DIG-CHEQUE-INTERNO, :RALCHEDO-NUM-DOCUMENTO, :RALCHEDO-OCORR-HISTORICO, :RALCHEDO-TIPO-MOVIMENTO, :RALCHEDO-TIMESTAMP, :RALCHEDO-AGENCIA-CONTRATO, :RALCHEDO-NUMERO-SIVAT, :RALCHEDO-DV-SIVAT, NULL, :RALCHEDO-AGE-CENTRAL-PROD01, :RALCHEDO-NUMDOC-NUM01) END-EXEC. */

            var r0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1 = new R0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1()
            {
                RALCHEDO_COD_EMPRESA = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_COD_EMPRESA.ToString(),
                RALCHEDO_NUM_CHEQUE_INTERNO = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUM_CHEQUE_INTERNO.ToString(),
                RALCHEDO_DIG_CHEQUE_INTERNO = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DIG_CHEQUE_INTERNO.ToString(),
                RALCHEDO_NUM_DOCUMENTO = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUM_DOCUMENTO.ToString(),
                RALCHEDO_OCORR_HISTORICO = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_OCORR_HISTORICO.ToString(),
                RALCHEDO_TIPO_MOVIMENTO = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_TIPO_MOVIMENTO.ToString(),
                RALCHEDO_TIMESTAMP = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_TIMESTAMP.ToString(),
                RALCHEDO_AGENCIA_CONTRATO = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGENCIA_CONTRATO.ToString(),
                RALCHEDO_NUMERO_SIVAT = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT.ToString(),
                RALCHEDO_DV_SIVAT = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DV_SIVAT.ToString(),
                RALCHEDO_AGE_CENTRAL_PROD01 = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGE_CENTRAL_PROD01.ToString(),
                RALCHEDO_NUMDOC_NUM01 = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMDOC_NUM01.ToString(),
            };

            R0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1.Execute(r0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_EXIT*/

        [StopWatch]
        /*" R0200-DECLARE-RALCHEDO */
        private void R0200_DECLARE_RALCHEDO(bool isPerform = false)
        {
            /*" -762- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -809- PERFORM R0200_DECLARE_RALCHEDO_DB_DECLARE_1 */

            R0200_DECLARE_RALCHEDO_DB_DECLARE_1();

            /*" -811- PERFORM R0200_DECLARE_RALCHEDO_DB_OPEN_1 */

            R0200_DECLARE_RALCHEDO_DB_OPEN_1();

            /*" -813- IF SQLCODE < 0 */

            if (DB.SQLCODE < 0)
            {

                /*" -813- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-DECLARE-RALCHEDO-DB-OPEN-1 */
        public void R0200_DECLARE_RALCHEDO_DB_OPEN_1()
        {
            /*" -811- EXEC SQL OPEN C01_RALCHEDO END-EXEC. */

            C01_RALCHEDO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_EXIT*/

        [StopWatch]
        /*" R0201-FETCH-RALCHEDO */
        private void R0201_FETCH_RALCHEDO(bool isPerform = false)
        {
            /*" -821- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -846- PERFORM R0201_FETCH_RALCHEDO_DB_FETCH_1 */

            R0201_FETCH_RALCHEDO_DB_FETCH_1();

            /*" -849- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -849- PERFORM R0201_FETCH_RALCHEDO_DB_CLOSE_1 */

                R0201_FETCH_RALCHEDO_DB_CLOSE_1();

                /*" -851- MOVE 'SIM' TO WFIM-SELECAO */
                _.Move("SIM", AREA_DE_WORK.WFIM_SELECAO);

                /*" -853- GO TO R0201-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0201_EXIT*/ //GOTO
                return;
            }


            /*" -854- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -855- DISPLAY 'R0500 - ERRO NO FETCH DA RALCHEDO + HISTSINI' */
                _.Display($"R0500 - ERRO NO FETCH DA RALCHEDO + HISTSINI");

                /*" -855- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0201-FETCH-RALCHEDO-DB-FETCH-1 */
        public void R0201_FETCH_RALCHEDO_DB_FETCH_1()
        {
            /*" -846- EXEC SQL FETCH C01_RALCHEDO INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-NUM-APOLICE, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-NOME-FAVORECIDO, :SINISHIS-VAL-OPERACAO, :SINISHIS-DATA-LIM-CORRECAO, :SINISHIS-TIPO-FAVORECIDO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-NUM-RECIBO, :SINISHIS-SIT-CONTABIL, :SINISHIS-SIT-REGISTRO, :SINISMES-COD-PRODUTO, :SINISMES-NUM-APOLICE, :SINISMES-RAMO, :SINISMES-COD-FONTE, :SINISMES-NUM-PROTOCOLO-SINI, :SINISMES-DAC-PROTOCOLO-SINI, :GEOPERAC-FUNCAO-OPERACAO, :RALCHEDO-AGE-CENTRAL-PROD01, :RALCHEDO-NUMDOC-NUM01, :RALCHEDO-OCORR-HISTORICO END-EXEC. */

            if (C01_RALCHEDO.Fetch())
            {
                _.Move(C01_RALCHEDO.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(C01_RALCHEDO.SINISHIS_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);
                _.Move(C01_RALCHEDO.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(C01_RALCHEDO.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(C01_RALCHEDO.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(C01_RALCHEDO.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(C01_RALCHEDO.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(C01_RALCHEDO.SINISHIS_DATA_LIM_CORRECAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO);
                _.Move(C01_RALCHEDO.SINISHIS_TIPO_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO);
                _.Move(C01_RALCHEDO.SINISHIS_COD_PREST_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);
                _.Move(C01_RALCHEDO.SINISHIS_COD_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO);
                _.Move(C01_RALCHEDO.SINISHIS_NUM_RECIBO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_RECIBO);
                _.Move(C01_RALCHEDO.SINISHIS_SIT_CONTABIL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                _.Move(C01_RALCHEDO.SINISHIS_SIT_REGISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);
                _.Move(C01_RALCHEDO.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(C01_RALCHEDO.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(C01_RALCHEDO.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(C01_RALCHEDO.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(C01_RALCHEDO.SINISMES_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);
                _.Move(C01_RALCHEDO.SINISMES_DAC_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DAC_PROTOCOLO_SINI);
                _.Move(C01_RALCHEDO.GEOPERAC_FUNCAO_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);
                _.Move(C01_RALCHEDO.RALCHEDO_AGE_CENTRAL_PROD01, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGE_CENTRAL_PROD01);
                _.Move(C01_RALCHEDO.RALCHEDO_NUMDOC_NUM01, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMDOC_NUM01);
                _.Move(C01_RALCHEDO.RALCHEDO_OCORR_HISTORICO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_OCORR_HISTORICO);
            }

        }

        [StopWatch]
        /*" R0201-FETCH-RALCHEDO-DB-CLOSE-1 */
        public void R0201_FETCH_RALCHEDO_DB_CLOSE_1()
        {
            /*" -849- EXEC SQL CLOSE C01_RALCHEDO END-EXEC */

            C01_RALCHEDO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0201_EXIT*/

        [StopWatch]
        /*" R0300-PROCESSA-RALCHEDO */
        private void R0300_PROCESSA_RALCHEDO(bool isPerform = false)
        {
            /*" -863- INITIALIZE DCLCHEQUES-EMITIDOS. */
            _.Initialize(
                CHEQUEMI.DCLCHEQUES_EMITIDOS
            );

            /*" -865- PERFORM R0310-SELECT-MAX-CHEQUES THRU R0310-EXIT. */

            R0310_SELECT_MAX_CHEQUES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_EXIT*/


            /*" -867- ADD 1 TO CHEQUEMI-NUM-CHEQUE-INTERNO. */
            CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO.Value = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO + 1;

            /*" -869- PERFORM R0320-CALC-DV-CHEQUE-INT THRU R0320-EXIT. */

            R0320_CALC_DV_CHEQUE_INT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_EXIT*/


            /*" -871- PERFORM R0330-INSERT-CHEQUE-EMIT THRU R0330-EXIT. */

            R0330_INSERT_CHEQUE_EMIT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_EXIT*/


            /*" -873- PERFORM R0340-INSERT-HIST-CHEQUE THRU R0340-EXIT. */

            R0340_INSERT_HIST_CHEQUE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_EXIT*/


            /*" -875- PERFORM R0350-MONTA-MOVDEBCC THRU R0350-EXIT. */

            R0350_MONTA_MOVDEBCC(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_EXIT*/


            /*" -877- MOVE RALCHEDO-AGE-CENTRAL-PROD01 TO W-AGENCIA-ANTERIOR. */
            _.Move(RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGE_CENTRAL_PROD01, AREA_DE_WORK.W_AGENCIA_ANTERIOR);

            /*" -879- MOVE ZEROS TO W-VALOR-CREDITO. */
            _.Move(0, AREA_DE_WORK.W_VALOR_CREDITO);

            /*" -884- PERFORM R0400-PCS-SINISTROS THRU R0400-EXIT UNTIL (WFIM-SELECAO EQUAL 'SIM' ) OR (RALCHEDO-AGE-CENTRAL-PROD01 NOT EQUAL W-AGENCIA-ANTERIOR). */

            while (!((AREA_DE_WORK.WFIM_SELECAO == "SIM") || (RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGE_CENTRAL_PROD01 != AREA_DE_WORK.W_AGENCIA_ANTERIOR)))
            {

                R0400_PCS_SINISTROS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_EXIT*/

            }

            /*" -887- MOVE W-VALOR-CREDITO TO CHEQUEMI-VAL-CHEQUE MOVDEBCE-VLR-CREDITO. */
            _.Move(AREA_DE_WORK.W_VALOR_CREDITO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_CHEQUE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);

            /*" -889- PERFORM R0360-UPD-CHEQUES-EMITIDOS THRU R0360-EXIT. */

            R0360_UPD_CHEQUES_EMITIDOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_EXIT*/


            /*" -890- ADD 1 TO W-QTD-LINHAS-MOVDEBCC. */
            AREA_DE_WORK.W_QTD_LINHAS_MOVDEBCC.Value = AREA_DE_WORK.W_QTD_LINHAS_MOVDEBCC + 1;

            /*" -892- ADD MOVDEBCE-VLR-CREDITO TO W-VALOR-TOTAL-PAGO . */
            AREA_DE_WORK.W_VALOR_TOTAL_PAGO.Value = AREA_DE_WORK.W_VALOR_TOTAL_PAGO + MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO;

            /*" -892- PERFORM R1000-GRAVA-MOVDEBCC THRU R1000-EXIT. */

            R1000_GRAVA_MOVDEBCC(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_EXIT*/

        [StopWatch]
        /*" R0310-SELECT-MAX-CHEQUES */
        private void R0310_SELECT_MAX_CHEQUES(bool isPerform = false)
        {
            /*" -900- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -902- EXEC SQL LOCK TABLE SEGUROS.CHEQUES_EMITIDOS IN EXCLUSIVE MODE END-EXEC. */

            /* EXEC SQL LOCK TABLE SEGUROS.CHEQUES_EMITIDOS IN EXCLUSIVE MODE END-EXEC. */

            /*" -905- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -906- DISPLAY 'ERRO LOCK CHEQUES_EMITIDOS ..............' */
                _.Display($"ERRO LOCK CHEQUES_EMITIDOS ..............");

                /*" -908- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -910- INITIALIZE DCLCHEQUES-EMITIDOS. */
            _.Initialize(
                CHEQUEMI.DCLCHEQUES_EMITIDOS
            );

            /*" -915- PERFORM R0310_SELECT_MAX_CHEQUES_DB_SELECT_1 */

            R0310_SELECT_MAX_CHEQUES_DB_SELECT_1();

            /*" -918- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -919- DISPLAY 'ERRO SELECT MAX NA CHEQUES_EMITIDOS' */
                _.Display($"ERRO SELECT MAX NA CHEQUES_EMITIDOS");

                /*" -919- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0310-SELECT-MAX-CHEQUES-DB-SELECT-1 */
        public void R0310_SELECT_MAX_CHEQUES_DB_SELECT_1()
        {
            /*" -915- EXEC SQL SELECT VALUE(MAX(NUM_CHEQUE_INTERNO),0) INTO :CHEQUEMI-NUM-CHEQUE-INTERNO FROM SEGUROS.CHEQUES_EMITIDOS WITH UR END-EXEC. */

            var r0310_SELECT_MAX_CHEQUES_DB_SELECT_1_Query1 = new R0310_SELECT_MAX_CHEQUES_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0310_SELECT_MAX_CHEQUES_DB_SELECT_1_Query1.Execute(r0310_SELECT_MAX_CHEQUES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CHEQUEMI_NUM_CHEQUE_INTERNO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_EXIT*/

        [StopWatch]
        /*" R0320-CALC-DV-CHEQUE-INT */
        private void R0320_CALC_DV_CHEQUE_INT(bool isPerform = false)
        {
            /*" -927- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", WABEND.WNR_EXEC_SQL);

            /*" -929- MOVE CHEQUEMI-NUM-CHEQUE-INTERNO TO LPARM01. */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO, LPARM01X.LPARM01);

            /*" -946- COMPUTE WPARM01-AUX = LPARM01-1 * 8 + LPARM01-2 * 7 + LPARM01-3 * 6 + LPARM01-4 * 5 + LPARM01-5 * 4 + LPARM01-6 * 3 + LPARM01-7 * 2 + LPARM01-8 * 9 + LPARM01-9 * 8 + LPARM01-10 * 7 + LPARM01-11 * 6 + LPARM01-12 * 5 + LPARM01-13 * 4 + LPARM01-14 * 3 + LPARM01-15 * 2. */
            WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_1 * 8 + LPARM01X.LPARM01_R.LPARM01_2 * 7 + LPARM01X.LPARM01_R.LPARM01_3 * 6 + LPARM01X.LPARM01_R.LPARM01_4 * 5 + LPARM01X.LPARM01_R.LPARM01_5 * 4 + LPARM01X.LPARM01_R.LPARM01_6 * 3 + LPARM01X.LPARM01_R.LPARM01_7 * 2 + LPARM01X.LPARM01_R.LPARM01_8 * 9 + LPARM01X.LPARM01_R.LPARM01_9 * 8 + LPARM01X.LPARM01_R.LPARM01_10 * 7 + LPARM01X.LPARM01_R.LPARM01_11 * 6 + LPARM01X.LPARM01_R.LPARM01_12 * 5 + LPARM01X.LPARM01_R.LPARM01_13 * 4 + LPARM01X.LPARM01_R.LPARM01_14 * 3 + LPARM01X.LPARM01_R.LPARM01_15 * 2;

            /*" -949- DIVIDE WPARM01-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(WPARM01_AUX, 11, WQUOCIENTE, WRESTO);

            /*" -950- IF WRESTO = 1 */

            if (WRESTO == 1)
            {

                /*" -951- MOVE 0 TO LPARM03 */
                _.Move(0, LPARM01X.LPARM03);

                /*" -952- ELSE */
            }
            else
            {


                /*" -953- IF WRESTO = 0 */

                if (WRESTO == 0)
                {

                    /*" -954- MOVE 1 TO LPARM03 */
                    _.Move(1, LPARM01X.LPARM03);

                    /*" -955- ELSE */
                }
                else
                {


                    /*" -957- SUBTRACT WRESTO FROM 11 GIVING LPARM03. */
                    LPARM01X.LPARM03.Value = 11 - WRESTO;
                }

            }


            /*" -957- MOVE LPARM03 TO CHEQUEMI-DIG-CHEQUE-INTERNO. */
            _.Move(LPARM01X.LPARM03, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DIG_CHEQUE_INTERNO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_EXIT*/

        [StopWatch]
        /*" R0330-INSERT-CHEQUE-EMIT */
        private void R0330_INSERT_CHEQUE_EMIT(bool isPerform = false)
        {
            /*" -965- MOVE 10 TO CHEQUEMI-COD-FONTE. */
            _.Move(10, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_FONTE);

            /*" -966- MOVE '1' TO CHEQUEMI-TIPO-MOVIMENTO */
            _.Move("1", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_MOVIMENTO);

            /*" -967- MOVE 'SIN-SIACC' TO CHEQUEMI-NUM-DOCUMENTO. */
            _.Move("SIN-SIACC", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_DOCUMENTO);

            /*" -968- MOVE 'CAIXA ECONOMICA FEDERAL' TO CHEQUEMI-NOME-FAVORECIDO. */
            _.Move("CAIXA ECONOMICA FEDERAL", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NOME_FAVORECIDO);

            /*" -969- MOVE ZEROS TO CHEQUEMI-VAL-CHEQUE. */
            _.Move(0, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_CHEQUE);

            /*" -971- MOVE SISTEMAS-DATA-MOV-ABERTO TO CHEQUEMI-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_MOVIMENTO);

            /*" -972- MOVE '9999-12-31' TO CHEQUEMI-DATA-EMISSAO. */
            _.Move("9999-12-31", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO);

            /*" -973- MOVE '1' TO CHEQUEMI-SIT-REGISTRO. */
            _.Move("1", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_SIT_REGISTRO);

            /*" -974- MOVE '7' TO CHEQUEMI-TIPO-PAGAMENTO. */
            _.Move("7", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_PAGAMENTO);

            /*" -975- MOVE SISTEMAS-DATA-MOV-ABERTO TO CHEQUEMI-DATA-COMPETENCIA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_COMPETENCIA);

            /*" -976- MOVE 'BRASILIA' TO CHEQUEMI-PRACA-PAGAMENTO. */
            _.Move("BRASILIA", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_PRACA_PAGAMENTO);

            /*" -977- MOVE ZEROS TO CHEQUEMI-NUM-RECIBO. */
            _.Move(0, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_RECIBO);

            /*" -978- MOVE 0 TO CHEQUEMI-OCORR-HISTORICO. */
            _.Move(0, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_OCORR_HISTORICO);

            /*" -979- MOVE 101 TO CHEQUEMI-COD-OPERACAO. */
            _.Move(101, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_OPERACAO);

            /*" -980- MOVE ZEROS TO CHEQUEMI-VAL-IRF. */
            _.Move(0, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_IRF);

            /*" -981- MOVE ZEROS TO CHEQUEMI-VAL-ISS. */
            _.Move(0, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_ISS);

            /*" -982- MOVE ZEROS TO CHEQUEMI-VAL-IAPAS. */
            _.Move(0, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_IAPAS);

            /*" -983- MOVE 9999 TO CHEQUEMI-COD-LANCAMENTO. */
            _.Move(9999, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_LANCAMENTO);

            /*" -984- MOVE 9999 TO CHEQUEMI-COD-DESPESA. */
            _.Move(9999, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_DESPESA);

            /*" -985- MOVE SISTEMAS-DATA-MOV-ABERTO TO CHEQUEMI-DATA-LANCAMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_LANCAMENTO);

            /*" -986- MOVE 0 TO CHEQUEMI-COD-EMPRESA. */
            _.Move(0, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_EMPRESA);

            /*" -987- MOVE 891733 TO CHEQUEMI-COD-FAVORECIDO. */
            _.Move(891733, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_FAVORECIDO);

            /*" -989- MOVE ZEROS TO CHEQUEMI-VAL-INSS. */
            _.Move(0, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_INSS);

            /*" -1043- PERFORM R0330_INSERT_CHEQUE_EMIT_DB_INSERT_1 */

            R0330_INSERT_CHEQUE_EMIT_DB_INSERT_1();

            /*" -1046- IF SQLCODE = 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1048- ADD 1 TO W-CONTA-CHEQUES-GERADOS. */
                AREA_DE_WORK.W_CONTA_CHEQUES_GERADOS.Value = AREA_DE_WORK.W_CONTA_CHEQUES_GERADOS + 1;
            }


            /*" -1049- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1050- DISPLAY 'R0330 - ERRO INSERT CHEQUES_EMITIDOS' */
                _.Display($"R0330 - ERRO INSERT CHEQUES_EMITIDOS");

                /*" -1051- DISPLAY 'NUM. SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM. SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1052- DISPLAY 'OCORHIST      = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST      = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1053- DISPLAY 'COD_PREST_SERV= ' SINISHIS-COD-PREST-SERVICO */
                _.Display($"COD_PREST_SERV= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

                /*" -1054- DISPLAY 'NOME FAVOREC. = ' SINISHIS-NOME-FAVORECIDO */
                _.Display($"NOME FAVOREC. = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO}");

                /*" -1055- DISPLAY 'CHEQUEMI-TPMOV= ' CHEQUEMI-TIPO-MOVIMENTO */
                _.Display($"CHEQUEMI-TPMOV= {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_MOVIMENTO}");

                /*" -1056- DISPLAY 'CHQINT        = ' CHEQUEMI-NUM-CHEQUE-INTERNO */
                _.Display($"CHQINT        = {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO}");

                /*" -1056- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0330-INSERT-CHEQUE-EMIT-DB-INSERT-1 */
        public void R0330_INSERT_CHEQUE_EMIT_DB_INSERT_1()
        {
            /*" -1043- EXEC SQL INSERT INTO SEGUROS.CHEQUES_EMITIDOS (TIPO_MOVIMENTO, COD_FONTE, NUM_DOCUMENTO, NOME_FAVORECIDO, VAL_CHEQUE, DATA_MOVIMENTO, DATA_EMISSAO, NUM_CHEQUE_INTERNO, DIG_CHEQUE_INTERNO, SIT_REGISTRO, TIPO_PAGAMENTO, DATA_COMPETENCIA, PRACA_PAGAMENTO, NUM_RECIBO, OCORR_HISTORICO, COD_OPERACAO, COD_DESPESA, VAL_IRF, VAL_ISS, VAL_IAPAS, COD_LANCAMENTO, DATA_LANCAMENTO, COD_EMPRESA, TIMESTAMP, COD_FAVORECIDO, VAL_INSS) VALUES (:CHEQUEMI-TIPO-MOVIMENTO, :CHEQUEMI-COD-FONTE, :CHEQUEMI-NUM-DOCUMENTO, :CHEQUEMI-NOME-FAVORECIDO, :CHEQUEMI-VAL-CHEQUE, :CHEQUEMI-DATA-MOVIMENTO, :CHEQUEMI-DATA-EMISSAO, :CHEQUEMI-NUM-CHEQUE-INTERNO, :CHEQUEMI-DIG-CHEQUE-INTERNO, :CHEQUEMI-SIT-REGISTRO, :CHEQUEMI-TIPO-PAGAMENTO, :CHEQUEMI-DATA-COMPETENCIA, :CHEQUEMI-PRACA-PAGAMENTO, :CHEQUEMI-NUM-RECIBO, :CHEQUEMI-OCORR-HISTORICO, :CHEQUEMI-COD-OPERACAO, :CHEQUEMI-COD-DESPESA, :CHEQUEMI-VAL-IRF, :CHEQUEMI-VAL-ISS, :CHEQUEMI-VAL-IAPAS, :CHEQUEMI-COD-LANCAMENTO, :CHEQUEMI-DATA-LANCAMENTO, :CHEQUEMI-COD-EMPRESA, CURRENT TIMESTAMP, :CHEQUEMI-COD-FAVORECIDO, :CHEQUEMI-VAL-INSS) END-EXEC. */

            var r0330_INSERT_CHEQUE_EMIT_DB_INSERT_1_Insert1 = new R0330_INSERT_CHEQUE_EMIT_DB_INSERT_1_Insert1()
            {
                CHEQUEMI_TIPO_MOVIMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_MOVIMENTO.ToString(),
                CHEQUEMI_COD_FONTE = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_FONTE.ToString(),
                CHEQUEMI_NUM_DOCUMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_DOCUMENTO.ToString(),
                CHEQUEMI_NOME_FAVORECIDO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NOME_FAVORECIDO.ToString(),
                CHEQUEMI_VAL_CHEQUE = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_CHEQUE.ToString(),
                CHEQUEMI_DATA_MOVIMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_MOVIMENTO.ToString(),
                CHEQUEMI_DATA_EMISSAO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO.ToString(),
                CHEQUEMI_NUM_CHEQUE_INTERNO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO.ToString(),
                CHEQUEMI_DIG_CHEQUE_INTERNO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DIG_CHEQUE_INTERNO.ToString(),
                CHEQUEMI_SIT_REGISTRO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_SIT_REGISTRO.ToString(),
                CHEQUEMI_TIPO_PAGAMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_PAGAMENTO.ToString(),
                CHEQUEMI_DATA_COMPETENCIA = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_COMPETENCIA.ToString(),
                CHEQUEMI_PRACA_PAGAMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_PRACA_PAGAMENTO.ToString(),
                CHEQUEMI_NUM_RECIBO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_RECIBO.ToString(),
                CHEQUEMI_OCORR_HISTORICO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_OCORR_HISTORICO.ToString(),
                CHEQUEMI_COD_OPERACAO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_OPERACAO.ToString(),
                CHEQUEMI_COD_DESPESA = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_DESPESA.ToString(),
                CHEQUEMI_VAL_IRF = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_IRF.ToString(),
                CHEQUEMI_VAL_ISS = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_ISS.ToString(),
                CHEQUEMI_VAL_IAPAS = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_IAPAS.ToString(),
                CHEQUEMI_COD_LANCAMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_LANCAMENTO.ToString(),
                CHEQUEMI_DATA_LANCAMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_LANCAMENTO.ToString(),
                CHEQUEMI_COD_EMPRESA = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_EMPRESA.ToString(),
                CHEQUEMI_COD_FAVORECIDO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_FAVORECIDO.ToString(),
                CHEQUEMI_VAL_INSS = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_INSS.ToString(),
            };

            R0330_INSERT_CHEQUE_EMIT_DB_INSERT_1_Insert1.Execute(r0330_INSERT_CHEQUE_EMIT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_EXIT*/

        [StopWatch]
        /*" R0350-MONTA-MOVDEBCC */
        private void R0350_MONTA_MOVDEBCC(bool isPerform = false)
        {
            /*" -1064- INITIALIZE DCLPARAM-CONTACEF. */
            _.Initialize(
                PARAMCON.DCLPARAM_CONTACEF
            );

            /*" -1066- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -1083- PERFORM R0350_MONTA_MOVDEBCC_DB_SELECT_1 */

            R0350_MONTA_MOVDEBCC_DB_SELECT_1();

            /*" -1089- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -1090- DISPLAY 'R0335 - ERRO LEITURA PARAM_CONTACEF' */
                _.Display($"R0335 - ERRO LEITURA PARAM_CONTACEF");

                /*" -1091- DISPLAY 'NUM. SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM. SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1092- DISPLAY 'OCORHIST      = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST      = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1093- DISPLAY 'COD_PREST_SERV= ' SINISHIS-COD-PREST-SERVICO */
                _.Display($"COD_PREST_SERV= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

                /*" -1094- DISPLAY 'NOME FAVOREC. = ' SINISHIS-NOME-FAVORECIDO */
                _.Display($"NOME FAVOREC. = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO}");

                /*" -1095- DISPLAY 'CHEQUEMI-TPMOV= ' CHEQUEMI-TIPO-MOVIMENTO */
                _.Display($"CHEQUEMI-TPMOV= {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_MOVIMENTO}");

                /*" -1096- DISPLAY 'CHQINT        = ' CHEQUEMI-NUM-CHEQUE-INTERNO */
                _.Display($"CHQINT        = {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO}");

                /*" -1100- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1101- MOVE ZEROS TO MOVDEBCE-COD-EMPRESA. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);

            /*" -1103- MOVE CHEQUEMI-NUM-CHEQUE-INTERNO TO MOVDEBCE-NUM-APOLICE. */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -1105- MOVE CHEQUEMI-NUM-CHEQUE-INTERNO TO MOVDEBCE-NUM-CARTAO. */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

            /*" -1106- MOVE 7777 TO MOVDEBCE-NUM-ENDOSSO. */
            _.Move(7777, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -1108- MOVE 7777 TO MOVDEBCE-NUM-PARCELA. */
            _.Move(7777, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -1109- MOVE '0' TO MOVDEBCE-SITUACAO-COBRANCA. */
            _.Move("0", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -1110- MOVE ZEROS TO MOVDEBCE-VALOR-DEBITO. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -1111- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -1112- MOVE 630 TO MOVDEBCE-COD-AGENCIA-DEB. */
            _.Move(630, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -1113- MOVE 003 TO MOVDEBCE-OPER-CONTA-DEB. */
            _.Move(003, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

            /*" -1114- MOVE 215 TO MOVDEBCE-NUM-CONTA-DEB. */
            _.Move(215, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -1115- MOVE 555 TO MOVDEBCE-NUM-CONTA-DEB. */
            _.Move(555, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -1116- MOVE 1 TO MOVDEBCE-DIG-CONTA-DEB. */
            _.Move(1, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

            /*" -1117- MOVE 0 TO MOVDEBCE-DIG-CONTA-DEB. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

            /*" -1118- MOVE 43350 TO MOVDEBCE-COD-CONVENIO. */
            _.Move(43350, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -1119- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-ENVIO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO);

            /*" -1120- MOVE 0 TO MOVDEBCE-NSAS. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -1121- MOVE 'SI5066B' TO MOVDEBCE-COD-USUARIO. */
            _.Move("SI5066B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -1122- MOVE ZEROS TO MOVDEBCE-NUM-REQUISICAO. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);

            /*" -1123- MOVE 0 TO MOVDEBCE-SEQUENCIA. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA);

            /*" -1124- MOVE 0 TO MOVDEBCE-NUM-LOTE. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE);

            /*" -1149- MOVE SINISHIS-VAL-OPERACAO TO MOVDEBCE-VLR-CREDITO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);

            /*" -1150- MOVE SI4922B-LK-DATA-CRED-EM-CONTA TO MOVDEBCE-DATA-VENCIMENTO. */
            _.Move(SI4922B_LK_PARAMETRO.SI4922B_LK_PARAMETROS_SAIDA.SI4922B_LK_DATA_CRED_EM_CONTA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

        }

        [StopWatch]
        /*" R0350-MONTA-MOVDEBCC-DB-SELECT-1 */
        public void R0350_MONTA_MOVDEBCC_DB_SELECT_1()
        {
            /*" -1083- EXEC SQL SELECT COD_BANCO, COD_AGENCIA_SASS, OPER_CONTA_SASS, NUM_CONTA_SASS, DIG_CONTA_SASS INTO :PARAMCON-COD-BANCO, :PARAMCON-COD-AGENCIA-SASS, :PARAMCON-OPER-CONTA-SASS, :PARAMCON-NUM-CONTA-SASS, :PARAMCON-DIG-CONTA-SASS FROM SEGUROS.PARAM_CONTACEF WHERE COD_CONVENIO = 43350 AND COD_PRODUTO = (SELECT MAX(COD_PRODUTO) FROM SEGUROS.PARAM_CONTACEF WHERE COD_CONVENIO = 43350) AND SIT_REGISTRO = 'A' END-EXEC. */

            var r0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1 = new R0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1.Execute(r0350_MONTA_MOVDEBCC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMCON_COD_BANCO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_BANCO);
                _.Move(executed_1.PARAMCON_COD_AGENCIA_SASS, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_AGENCIA_SASS);
                _.Move(executed_1.PARAMCON_OPER_CONTA_SASS, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_OPER_CONTA_SASS);
                _.Move(executed_1.PARAMCON_NUM_CONTA_SASS, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NUM_CONTA_SASS);
                _.Move(executed_1.PARAMCON_DIG_CONTA_SASS, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DIG_CONTA_SASS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_EXIT*/

        [StopWatch]
        /*" R0355-GRAVA-PARAMCON */
        private void R0355_GRAVA_PARAMCON(bool isPerform = false)
        {
            /*" -1191- PERFORM R0355_GRAVA_PARAMCON_DB_INSERT_1 */

            R0355_GRAVA_PARAMCON_DB_INSERT_1();

            /*" -1194- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1195- DISPLAY 'R0355 - ERRO INSERT PARAM_CONTACEF ' */
                _.Display($"R0355 - ERRO INSERT PARAM_CONTACEF ");

                /*" -1196- DISPLAY 'NUM. SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM. SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1197- DISPLAY 'OCORHIST      = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST      = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1198- DISPLAY 'COD_PREST_SERV= ' SINISHIS-COD-PREST-SERVICO */
                _.Display($"COD_PREST_SERV= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

                /*" -1198- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0355-GRAVA-PARAMCON-DB-INSERT-1 */
        public void R0355_GRAVA_PARAMCON_DB_INSERT_1()
        {
            /*" -1191- EXEC SQL INSERT INTO SEGUROS.PARAM_CONTACEF ( COD_EMPRESA, COD_BANCO , TIPO_MOVTO_CC, COD_PRODUTO , COD_CONVENIO , NSAS , COD_AGENCIA_SASS, OPER_CONTA_SASS, NUM_CONTA_SASS, DIG_CONTA_SASS, DATA_MOVIMENTO, DATA_PROXIMO_DEB, DIA_DEBITO , SIT_REGISTRO , TIMESTAMP , DESCR_CONVENIO ) VALUES ( 0, 104, 1, 1, 43350, 0, 0630, 003, 255, 0, :SISTEMAS-DATA-MOV-ABERTO, '9999-12-31' , 0, 'A' , CURRENT TIMESTAMP, 'SIACC - CONV. PGTO CAIXA' ) END-EXEC. */

            var r0355_GRAVA_PARAMCON_DB_INSERT_1_Insert1 = new R0355_GRAVA_PARAMCON_DB_INSERT_1_Insert1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R0355_GRAVA_PARAMCON_DB_INSERT_1_Insert1.Execute(r0355_GRAVA_PARAMCON_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0355_EXIT*/

        [StopWatch]
        /*" R0360-UPD-CHEQUES-EMITIDOS */
        private void R0360_UPD_CHEQUES_EMITIDOS(bool isPerform = false)
        {
            /*" -1207- PERFORM R0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1 */

            R0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1();

            /*" -1210- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1211- DISPLAY 'R0360 - ERRO UDPATE CHEQUES_EMITIDOS' */
                _.Display($"R0360 - ERRO UDPATE CHEQUES_EMITIDOS");

                /*" -1212- DISPLAY 'NUM. SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM. SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1213- DISPLAY 'OCORHIST      = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST      = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1214- DISPLAY 'CHQINT        = ' CHEQUEMI-NUM-CHEQUE-INTERNO */
                _.Display($"CHQINT        = {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO}");

                /*" -1214- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0360-UPD-CHEQUES-EMITIDOS-DB-UPDATE-1 */
        public void R0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1()
        {
            /*" -1207- EXEC SQL UPDATE SEGUROS.CHEQUES_EMITIDOS SET VAL_CHEQUE = :CHEQUEMI-VAL-CHEQUE WHERE NUM_CHEQUE_INTERNO = :CHEQUEMI-NUM-CHEQUE-INTERNO END-EXEC. */

            var r0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1_Update1 = new R0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1_Update1()
            {
                CHEQUEMI_VAL_CHEQUE = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_CHEQUE.ToString(),
                CHEQUEMI_NUM_CHEQUE_INTERNO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO.ToString(),
            };

            R0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1_Update1.Execute(r0360_UPD_CHEQUES_EMITIDOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_EXIT*/

        [StopWatch]
        /*" R0340-INSERT-HIST-CHEQUE */
        private void R0340_INSERT_HIST_CHEQUE(bool isPerform = false)
        {
            /*" -1222- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", WABEND.WNR_EXEC_SQL);

            /*" -1224- MOVE CHEQUEMI-NUM-CHEQUE-INTERNO TO HISTOCHE-NUM-CHEQUE-INTERNO. */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO, HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_NUM_CHEQUE_INTERNO);

            /*" -1229- MOVE CHEQUEMI-DIG-CHEQUE-INTERNO TO HISTOCHE-DIG-CHEQUE-INTERNO. */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DIG_CHEQUE_INTERNO, HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DIG_CHEQUE_INTERNO);

            /*" -1233- MOVE CHEQUEMI-DATA-EMISSAO TO HISTOCHE-DATA-MOVIMENTO. */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO, HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DATA_MOVIMENTO);

            /*" -1234- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -1235- MOVE WHORA-HH-CURR TO WK-HH-2 */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WK_HORA_2.WK_HH_2);

            /*" -1236- MOVE WHORA-MM-CURR TO WK-MM-2 */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WK_HORA_2.WK_MM_2);

            /*" -1237- MOVE WHORA-SS-CURR TO WK-SS-2 */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WK_HORA_2.WK_SS_2);

            /*" -1239- MOVE WK-HORA-2 TO HISTOCHE-HORA-OPERACAO */
            _.Move(AREA_DE_WORK.WK_HORA_2, HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_HORA_OPERACAO);

            /*" -1240- MOVE 101 TO HISTOCHE-COD-OPERACAO. */
            _.Move(101, HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_COD_OPERACAO);

            /*" -1242- MOVE ZEROS TO HISTOCHE-COD-EMPRESA. */
            _.Move(0, HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_COD_EMPRESA);

            /*" -1260- PERFORM R0340_INSERT_HIST_CHEQUE_DB_INSERT_1 */

            R0340_INSERT_HIST_CHEQUE_DB_INSERT_1();

            /*" -1263- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1264- DISPLAY 'R0340 - ERRO INSERT HISTORICO_CHEQUES' */
                _.Display($"R0340 - ERRO INSERT HISTORICO_CHEQUES");

                /*" -1265- DISPLAY 'NUM. SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM. SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1266- DISPLAY 'OCORHIST      = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST      = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1267- DISPLAY 'COD_PREST_SERV= ' SINISHIS-COD-PREST-SERVICO */
                _.Display($"COD_PREST_SERV= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

                /*" -1268- DISPLAY 'NOME FAVOREC. = ' SINISHIS-NOME-FAVORECIDO */
                _.Display($"NOME FAVOREC. = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO}");

                /*" -1269- DISPLAY 'CHEQUEMI-TPMOV= ' CHEQUEMI-TIPO-MOVIMENTO */
                _.Display($"CHEQUEMI-TPMOV= {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_MOVIMENTO}");

                /*" -1270- DISPLAY 'CHQINT        = ' CHEQUEMI-NUM-CHEQUE-INTERNO */
                _.Display($"CHQINT        = {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO}");

                /*" -1270- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0340-INSERT-HIST-CHEQUE-DB-INSERT-1 */
        public void R0340_INSERT_HIST_CHEQUE_DB_INSERT_1()
        {
            /*" -1260- EXEC SQL INSERT INTO SEGUROS.HISTORICO_CHEQUES (NUM_CHEQUE_INTERNO, DIG_CHEQUE_INTERNO, DATA_MOVIMENTO, HORA_OPERACAO, COD_OPERACAO, COD_EMPRESA, TIMESTAMP, DATA_COMPENSACAO) VALUES (:HISTOCHE-NUM-CHEQUE-INTERNO, :HISTOCHE-DIG-CHEQUE-INTERNO, :HISTOCHE-DATA-MOVIMENTO, :HISTOCHE-HORA-OPERACAO, :HISTOCHE-COD-OPERACAO, :HISTOCHE-COD-EMPRESA, CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r0340_INSERT_HIST_CHEQUE_DB_INSERT_1_Insert1 = new R0340_INSERT_HIST_CHEQUE_DB_INSERT_1_Insert1()
            {
                HISTOCHE_NUM_CHEQUE_INTERNO = HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_NUM_CHEQUE_INTERNO.ToString(),
                HISTOCHE_DIG_CHEQUE_INTERNO = HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DIG_CHEQUE_INTERNO.ToString(),
                HISTOCHE_DATA_MOVIMENTO = HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DATA_MOVIMENTO.ToString(),
                HISTOCHE_HORA_OPERACAO = HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_HORA_OPERACAO.ToString(),
                HISTOCHE_COD_OPERACAO = HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_COD_OPERACAO.ToString(),
                HISTOCHE_COD_EMPRESA = HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_COD_EMPRESA.ToString(),
            };

            R0340_INSERT_HIST_CHEQUE_DB_INSERT_1_Insert1.Execute(r0340_INSERT_HIST_CHEQUE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_EXIT*/

        [StopWatch]
        /*" R0400-PCS-SINISTROS */
        private void R0400_PCS_SINISTROS(bool isPerform = false)
        {
            /*" -1278- MOVE CHEQUEMI-NUM-CHEQUE-INTERNO TO RALCHEDO-NUM-CHEQUE-INTERNO. */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUM_CHEQUE_INTERNO);

            /*" -1281- MOVE CHEQUEMI-DIG-CHEQUE-INTERNO, TO RALCHEDO-DIG-CHEQUE-INTERNO. */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DIG_CHEQUE_INTERNO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DIG_CHEQUE_INTERNO);

            /*" -1283- PERFORM R0410-UPDATE-RALCHEDO THRU R0410-EXIT. */

            R0410_UPDATE_RALCHEDO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_EXIT*/


            /*" -1285- PERFORM R0420-UPDATE-HISTSINI THRU R0420-EXIT. */

            R0420_UPDATE_HISTSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_EXIT*/


            /*" -1287- PERFORM R0430-GRAVA-SINI-CHEQUE THRU R0430-EXIT. */

            R0430_GRAVA_SINI_CHEQUE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_EXIT*/


            /*" -1290- COMPUTE W-VALOR-CREDITO = W-VALOR-CREDITO + SINISHIS-VAL-OPERACAO. */
            AREA_DE_WORK.W_VALOR_CREDITO.Value = AREA_DE_WORK.W_VALOR_CREDITO + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

            /*" -1290- PERFORM R0201-FETCH-RALCHEDO THRU R0201-EXIT. */

            R0201_FETCH_RALCHEDO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0201_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_EXIT*/

        [StopWatch]
        /*" R0410-UPDATE-RALCHEDO */
        private void R0410_UPDATE_RALCHEDO(bool isPerform = false)
        {
            /*" -1298- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -1304- PERFORM R0410_UPDATE_RALCHEDO_DB_UPDATE_1 */

            R0410_UPDATE_RALCHEDO_DB_UPDATE_1();

            /*" -1307- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1308- DISPLAY 'SI5066B - ERRO UPDATE RALACAO_CHEQ_DOCTO' */
                _.Display($"SI5066B - ERRO UPDATE RALACAO_CHEQ_DOCTO");

                /*" -1309- DISPLAY 'NUM. SINISTRO = ' RALCHEDO-NUMDOC-NUM01 */
                _.Display($"NUM. SINISTRO = {RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMDOC_NUM01}");

                /*" -1310- DISPLAY 'OCORHIST      = ' RALCHEDO-OCORR-HISTORICO */
                _.Display($"OCORHIST      = {RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_OCORR_HISTORICO}");

                /*" -1310- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0410-UPDATE-RALCHEDO-DB-UPDATE-1 */
        public void R0410_UPDATE_RALCHEDO_DB_UPDATE_1()
        {
            /*" -1304- EXEC SQL UPDATE SEGUROS.RALACAO_CHEQ_DOCTO SET NUM_CHEQUE_INTERNO = :RALCHEDO-NUM-CHEQUE-INTERNO, DIG_CHEQUE_INTERNO = :RALCHEDO-DIG-CHEQUE-INTERNO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUMDOC_NUM01 = :RALCHEDO-NUMDOC-NUM01 AND OCORR_HISTORICO = :RALCHEDO-OCORR-HISTORICO END-EXEC. */

            var r0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1 = new R0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1()
            {
                RALCHEDO_NUM_CHEQUE_INTERNO = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUM_CHEQUE_INTERNO.ToString(),
                RALCHEDO_DIG_CHEQUE_INTERNO = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DIG_CHEQUE_INTERNO.ToString(),
                RALCHEDO_OCORR_HISTORICO = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_OCORR_HISTORICO.ToString(),
                RALCHEDO_NUMDOC_NUM01 = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMDOC_NUM01.ToString(),
            };

            R0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1.Execute(r0410_UPDATE_RALCHEDO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_EXIT*/

        [StopWatch]
        /*" R0420-UPDATE-HISTSINI */
        private void R0420_UPDATE_HISTSINI(bool isPerform = false)
        {
            /*" -1324- PERFORM R0420_UPDATE_HISTSINI_DB_UPDATE_1 */

            R0420_UPDATE_HISTSINI_DB_UPDATE_1();

            /*" -1327- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1328- DISPLAY 'SI5066B - ERRO UPDATE SINISTRO_HISTORICO' */
                _.Display($"SI5066B - ERRO UPDATE SINISTRO_HISTORICO");

                /*" -1329- DISPLAY 'NUM. SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM. SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1330- DISPLAY 'OCORHIST      = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST      = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1331- DISPLAY 'OPERACAO      = ' SINISHIS-COD-OPERACAO */
                _.Display($"OPERACAO      = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

                /*" -1331- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0420-UPDATE-HISTSINI-DB-UPDATE-1 */
        public void R0420_UPDATE_HISTSINI_DB_UPDATE_1()
        {
            /*" -1324- EXEC SQL UPDATE SEGUROS.SINISTRO_HISTORICO SET SIT_REGISTRO = '1' , NOM_PROGRAMA = 'SI5066B' WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO END-EXEC. */

            var r0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1 = new R0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            R0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1.Execute(r0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_EXIT*/

        [StopWatch]
        /*" R0430-GRAVA-SINI-CHEQUE */
        private void R0430_GRAVA_SINI_CHEQUE(bool isPerform = false)
        {
            /*" -1339- MOVE SINISHIS-NUM-APOL-SINISTRO TO SISINCHE-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_APOL_SINISTRO);

            /*" -1340- MOVE SINISHIS-COD-OPERACAO TO SISINCHE-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_COD_OPERACAO);

            /*" -1341- MOVE SINISHIS-OCORR-HISTORICO TO SISINCHE-OCORR-HISTORICO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_OCORR_HISTORICO);

            /*" -1343- MOVE CHEQUEMI-NUM-CHEQUE-INTERNO TO SISINCHE-NUM-CHEQUE-INTERNO. */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);

            /*" -1345- MOVE CHEQUEMI-COD-EMPRESA TO SISINCHE-COD-EMPRESA. */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_EMPRESA, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_COD_EMPRESA);

            /*" -1347- INITIALIZE SI1040S-PARAMETROS. */
            _.Initialize(
                LBSI1040.SI1040S_PARAMETROS
            );

            /*" -1348- MOVE SINISMES-RAMO TO SI1040S-RAMO-EMISSOR. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR);

            /*" -1349- MOVE SINISHIS-COD-OPERACAO TO SI1040S-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_OPERACAO);

            /*" -1361- MOVE '0' TO SI1040S-TIP-REGISTRO. */
            _.Move("0", LBSI1040.SI1040S_PARAMETROS.SI1040S_TIP_REGISTRO);

            /*" -1373- CALL SI1040S USING SI1040S-PARAMETROS. */
            _.Call(LPARM01X.SI1040S, LBSI1040.SI1040S_PARAMETROS);

            /*" -1374- IF SI1040S-RC NOT = 0 */

            if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RC != 0)
            {

                /*" -1375- DISPLAY '*** SI5066B - ERRO ACESSO SUBROTINA SI1040S ***' */
                _.Display($"*** SI5066B - ERRO ACESSO SUBROTINA SI1040S ***");

                /*" -1376- DISPLAY 'RC        = ' SI1040S-RC */
                _.Display($"RC        = {LBSI1040.SI1040S_PARAMETROS.SI1040S_RC}");

                /*" -1377- DISPLAY 'SQLCODE   = ' SI1040S-ERRO-SQLCODE */
                _.Display($"SQLCODE   = {LBSI1040.SI1040S_PARAMETROS.SI1040S_ERRO_SQLCODE}");

                /*" -1378- DISPLAY 'MENSAGEM  = ' SI1040S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM  = {LBSI1040.SI1040S_PARAMETROS.SI1040S_ERRO_MENSAGEM}");

                /*" -1380- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1382- MOVE SI1040S-COD-DESPESA TO SISINCHE-COD-DESPESA. */
            _.Move(LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_COD_DESPESA);

            /*" -1396- PERFORM R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1 */

            R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1();

            /*" -1399- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1400- DISPLAY 'R0430 - ERRO INSERT SI_SINI_CHEQUE' */
                _.Display($"R0430 - ERRO INSERT SI_SINI_CHEQUE");

                /*" -1401- DISPLAY 'NUM. SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM. SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1402- DISPLAY 'OCORHIST      = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST      = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1403- DISPLAY 'COD_PREST_SERV= ' SINISHIS-COD-PREST-SERVICO */
                _.Display($"COD_PREST_SERV= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

                /*" -1404- DISPLAY 'NOME FAVOREC. = ' SINISHIS-NOME-FAVORECIDO */
                _.Display($"NOME FAVOREC. = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO}");

                /*" -1405- DISPLAY 'CHEQUEMI-TPMOV= ' CHEQUEMI-TIPO-MOVIMENTO */
                _.Display($"CHEQUEMI-TPMOV= {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_MOVIMENTO}");

                /*" -1406- DISPLAY 'CHQINT        = ' CHEQUEMI-NUM-CHEQUE-INTERNO */
                _.Display($"CHQINT        = {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO}");

                /*" -1406- GO TO R9999-00-ROT-ERRO . */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0430-GRAVA-SINI-CHEQUE-DB-INSERT-1 */
        public void R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1()
        {
            /*" -1396- EXEC SQL INSERT INTO SEGUROS.SI_SINI_CHEQUE (NUM_APOL_SINISTRO, COD_OPERACAO, OCORR_HISTORICO, NUM_CHEQUE_INTERNO, COD_DESPESA, COD_EMPRESA) VALUES (:SISINCHE-NUM-APOL-SINISTRO, :SISINCHE-COD-OPERACAO, :SISINCHE-OCORR-HISTORICO, :SISINCHE-NUM-CHEQUE-INTERNO, :SISINCHE-COD-DESPESA, :SISINCHE-COD-EMPRESA) END-EXEC. */

            var r0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1 = new R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1()
            {
                SISINCHE_NUM_APOL_SINISTRO = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_APOL_SINISTRO.ToString(),
                SISINCHE_COD_OPERACAO = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_COD_OPERACAO.ToString(),
                SISINCHE_OCORR_HISTORICO = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_OCORR_HISTORICO.ToString(),
                SISINCHE_NUM_CHEQUE_INTERNO = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO.ToString(),
                SISINCHE_COD_DESPESA = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_COD_DESPESA.ToString(),
                SISINCHE_COD_EMPRESA = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_COD_EMPRESA.ToString(),
            };

            R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1.Execute(r0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_EXIT*/

        [StopWatch]
        /*" R1000-GRAVA-MOVDEBCC */
        private void R1000_GRAVA_MOVDEBCC(bool isPerform = false)
        {
            /*" -1468- PERFORM R1000_GRAVA_MOVDEBCC_DB_INSERT_1 */

            R1000_GRAVA_MOVDEBCC_DB_INSERT_1();

            /*" -1471- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1472- DISPLAY 'R1000 - ERRO INSERT MOVTO_DEBITOCC_CEF' */
                _.Display($"R1000 - ERRO INSERT MOVTO_DEBITOCC_CEF");

                /*" -1473- DISPLAY 'NUM-APOLICE = ' MOVDEBCE-NUM-APOLICE */
                _.Display($"NUM-APOLICE = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -1474- DISPLAY 'NUM-ENDOSSO = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -1475- DISPLAY 'NUM-PARCELA = ' MOVDEBCE-NUM-PARCELA */
                _.Display($"NUM-PARCELA = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -1477- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1479- INITIALIZE DCLGE-MOVTO-CONTA. */
            _.Initialize(
                GE369.DCLGE_MOVTO_CONTA
            );

            /*" -1481- MOVE W-AGENCIA-ANTERIOR TO GE369-COD-AGENCIA. */
            _.Move(AREA_DE_WORK.W_AGENCIA_ANTERIOR, GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA);

            /*" -1482- MOVE MOVDEBCE-NUM-APOLICE TO GE369-NUM-APOLICE */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_APOLICE);

            /*" -1483- MOVE MOVDEBCE-NUM-ENDOSSO TO GE369-NUM-ENDOSSO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_ENDOSSO);

            /*" -1484- MOVE MOVDEBCE-NUM-PARCELA TO GE369-NUM-PARCELA */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_PARCELA);

            /*" -1485- MOVE MOVDEBCE-COD-CONVENIO TO GE369-COD-CONVENIO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, GE369.DCLGE_MOVTO_CONTA.GE369_COD_CONVENIO);

            /*" -1486- MOVE MOVDEBCE-NSAS TO GE369-NSAS */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, GE369.DCLGE_MOVTO_CONTA.GE369_NSAS);

            /*" -1487- MOVE 104 TO GE369-COD-BANCO */
            _.Move(104, GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO);

            /*" -1488- MOVE ZEROS TO GE369-NUM-CONTA-CNB */
            _.Move(0, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB);

            /*" -1489- MOVE ZEROS TO GE369-NUM-DV-CONTA-CNB. */
            _.Move(0, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB);

            /*" -1491- MOVE ZEROS TO GE369-IND-CONTA-BANCARIA. */
            _.Move(0, GE369.DCLGE_MOVTO_CONTA.GE369_IND_CONTA_BANCARIA);

            /*" -1512- PERFORM R1000_GRAVA_MOVDEBCC_DB_INSERT_2 */

            R1000_GRAVA_MOVDEBCC_DB_INSERT_2();

            /*" -1515- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1516- DISPLAY 'R1000 - ERRO INSERT GE_MOVTO_CONTA' */
                _.Display($"R1000 - ERRO INSERT GE_MOVTO_CONTA");

                /*" -1517- DISPLAY 'NUM-APOLICE = ' MOVDEBCE-NUM-APOLICE */
                _.Display($"NUM-APOLICE = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -1518- DISPLAY 'NUM-ENDOSSO = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -1519- DISPLAY 'NUM-PARCELA = ' MOVDEBCE-NUM-PARCELA */
                _.Display($"NUM-PARCELA = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -1520- DISPLAY 'GE369-COD-CONVENIO     = ' GE369-COD-CONVENIO */
                _.Display($"GE369-COD-CONVENIO     = {GE369.DCLGE_MOVTO_CONTA.GE369_COD_CONVENIO}");

                /*" -1521- DISPLAY 'GE369-NSAS             = ' GE369-NSAS */
                _.Display($"GE369-NSAS             = {GE369.DCLGE_MOVTO_CONTA.GE369_NSAS}");

                /*" -1522- DISPLAY 'GE369-COD-AGENCIA      = ' GE369-COD-AGENCIA */
                _.Display($"GE369-COD-AGENCIA      = {GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA}");

                /*" -1523- DISPLAY 'GE369-COD-BANCO        = ' GE369-COD-BANCO */
                _.Display($"GE369-COD-BANCO        = {GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO}");

                /*" -1524- DISPLAY 'GE369-NUM-CONTA-CNB    = ' GE369-NUM-CONTA-CNB */
                _.Display($"GE369-NUM-CONTA-CNB    = {GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB}");

                /*" -1525- DISPLAY 'GE369-NUM-DV-CONTA-CNB = ' GE369-NUM-DV-CONTA-CNB */
                _.Display($"GE369-NUM-DV-CONTA-CNB = {GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB}");

                /*" -1527- DISPLAY 'GE369-IND-CONTA-BANCARIA = ' GE369-IND-CONTA-BANCARIA */
                _.Display($"GE369-IND-CONTA-BANCARIA = {GE369.DCLGE_MOVTO_CONTA.GE369_IND_CONTA_BANCARIA}");

                /*" -1527- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1000-GRAVA-MOVDEBCC-DB-INSERT-1 */
        public void R1000_GRAVA_MOVDEBCC_DB_INSERT_1()
        {
            /*" -1468- EXEC SQL INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF (COD_EMPRESA , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , DATA_VENCIMENTO , VALOR_DEBITO , DATA_MOVIMENTO , TIMESTAMP , DIA_DEBITO , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , COD_CONVENIO , DATA_ENVIO , DATA_RETORNO , COD_RETORNO_CEF , NSAS , COD_USUARIO , NUM_REQUISICAO , NUM_CARTAO , SEQUENCIA , NUM_LOTE , DTCREDITO , STATUS_CARTAO , VLR_CREDITO) VALUES (:MOVDEBCE-COD-EMPRESA, :MOVDEBCE-NUM-APOLICE, :MOVDEBCE-NUM-ENDOSSO, :MOVDEBCE-NUM-PARCELA, :MOVDEBCE-SITUACAO-COBRANCA, :MOVDEBCE-DATA-VENCIMENTO, :MOVDEBCE-VALOR-DEBITO, :MOVDEBCE-DATA-MOVIMENTO, CURRENT TIMESTAMP, :MOVDEBCE-DIA-DEBITO, :MOVDEBCE-COD-AGENCIA-DEB, :MOVDEBCE-OPER-CONTA-DEB, :MOVDEBCE-NUM-CONTA-DEB, :MOVDEBCE-DIG-CONTA-DEB, :MOVDEBCE-COD-CONVENIO, NULL, NULL, NULL, :MOVDEBCE-NSAS, :MOVDEBCE-COD-USUARIO, :MOVDEBCE-NUM-REQUISICAO, :MOVDEBCE-NUM-CARTAO, :MOVDEBCE-SEQUENCIA, :MOVDEBCE-NUM-LOTE, NULL, NULL, :MOVDEBCE-VLR-CREDITO) END-EXEC. */

            var r1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1 = new R1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1()
            {
                MOVDEBCE_COD_EMPRESA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_DATA_VENCIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.ToString(),
                MOVDEBCE_VALOR_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO.ToString(),
                MOVDEBCE_DATA_MOVIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.ToString(),
                MOVDEBCE_DIA_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO.ToString(),
                MOVDEBCE_COD_AGENCIA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB.ToString(),
                MOVDEBCE_OPER_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB.ToString(),
                MOVDEBCE_NUM_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB.ToString(),
                MOVDEBCE_DIG_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
                MOVDEBCE_COD_USUARIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.ToString(),
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                MOVDEBCE_NUM_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO.ToString(),
                MOVDEBCE_SEQUENCIA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA.ToString(),
                MOVDEBCE_NUM_LOTE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE.ToString(),
                MOVDEBCE_VLR_CREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO.ToString(),
            };

            R1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1.Execute(r1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" R1000-GRAVA-MOVDEBCC-DB-INSERT-2 */
        public void R1000_GRAVA_MOVDEBCC_DB_INSERT_2()
        {
            /*" -1512- EXEC SQL INSERT INTO SEGUROS.GE_MOVTO_CONTA ( NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, COD_CONVENIO, NSAS , COD_AGENCIA , COD_BANCO , NUM_CONTA_CNB, NUM_DV_CONTA_CNB, IND_CONTA_BANCARIA) VALUES (:GE369-NUM-APOLICE, :GE369-NUM-ENDOSSO, :GE369-NUM-PARCELA, :GE369-COD-CONVENIO, :GE369-NSAS , :GE369-COD-AGENCIA , :GE369-COD-BANCO , :GE369-NUM-CONTA-CNB, :GE369-NUM-DV-CONTA-CNB, :GE369-IND-CONTA-BANCARIA) END-EXEC. */

            var r1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1 = new R1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1()
            {
                GE369_NUM_APOLICE = GE369.DCLGE_MOVTO_CONTA.GE369_NUM_APOLICE.ToString(),
                GE369_NUM_ENDOSSO = GE369.DCLGE_MOVTO_CONTA.GE369_NUM_ENDOSSO.ToString(),
                GE369_NUM_PARCELA = GE369.DCLGE_MOVTO_CONTA.GE369_NUM_PARCELA.ToString(),
                GE369_COD_CONVENIO = GE369.DCLGE_MOVTO_CONTA.GE369_COD_CONVENIO.ToString(),
                GE369_NSAS = GE369.DCLGE_MOVTO_CONTA.GE369_NSAS.ToString(),
                GE369_COD_AGENCIA = GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA.ToString(),
                GE369_COD_BANCO = GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO.ToString(),
                GE369_NUM_CONTA_CNB = GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB.ToString(),
                GE369_NUM_DV_CONTA_CNB = GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB.ToString(),
                GE369_IND_CONTA_BANCARIA = GE369.DCLGE_MOVTO_CONTA.GE369_IND_CONTA_BANCARIA.ToString(),
            };

            R1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1.Execute(r1000_GRAVA_MOVDEBCC_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1537- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1538- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1539- DISPLAY 'SQLCODE ......... ' WSQLCODE */
            _.Display($"SQLCODE ......... {WABEND.WSQLCODE}");

            /*" -1540- DISPLAY 'SQLERRMC ........ ' SQLERRMC */
            _.Display($"SQLERRMC ........ {DB.SQLERRMC}");

            /*" -1540- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1541- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1543- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1543- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK-SECTION */
        private void R10010199_MENSAGEM_LOCK_SECTION()
        {
            /*" -1556- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1559- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -1562- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1565- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE. */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -1568- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1571- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1574- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE. */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -1577- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE. */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -1580- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' UPON CONSOLE. */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -1583- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE. */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -1586- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1589- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' UPON CONSOLE. */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -1592- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1595- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1598- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE. */
            _.Display($"*     SQLCODE DO ABEND ....... {WABEND.WSQLCODE}");

            /*" -1601- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1607- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -1609- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1611- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1613- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -1615- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1617- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1619- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -1621- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -1623- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -1625- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -1627- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1629- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -1631- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1633- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1635- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1637- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {WABEND.WSQLCODE}");

            /*" -1639- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1639- GO TO R9999-00-ROT-ERRO. */

            R9999_00_ROT_ERRO_SECTION(); //GOTO
            return;

        }
    }
}