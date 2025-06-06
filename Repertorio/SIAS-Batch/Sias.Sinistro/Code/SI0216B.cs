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
using Sias.Sinistro.DB2.SI0216B;

namespace Code
{
    public class SI0216B
    {
        public bool IsCall { get; set; }

        public SI0216B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO / RESSARCIMENTO           *      */
        /*"      *   PROGRAMA ...............  SI0216B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER                             *      */
        /*"      *   PROGRAMADOR ............  HEIDER                             *      */
        /*"      *   DATA CODIFICACAO .......  MARCO / 2004                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... GERAR DO ARQUIVO DE PROVISOES EFETUADAS NO DIA*      */
        /*"      *          PARA CONFIRMACAO DA INTEGRACAO NO RESSARCIMENTOWEB    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _REG_RET { get; set; } = new FileBasis(new PIC("X", "350", "X(350)"));

        public FileBasis REG_RET
        {
            get
            {
                _.Move(REGISTRO_RETORNO, _REG_RET); VarBasis.RedefinePassValue(REGISTRO_RETORNO, _REG_RET, REGISTRO_RETORNO); return _REG_RET;
            }
        }
        /*"01  REGISTRO-RETORNO  PIC X(350).*/
        public StringBasis REGISTRO_RETORNO { get; set; } = new StringBasis(new PIC("X", "350", "X(350)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  VIND-DTH-PAGAMENTO             PIC S9(04)    COMP   VALUE +0*/
        public IntBasis VIND_DTH_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-FOLLOUP-DATA-LIBERACAO    PIC S9(04)    COMP   VALUE +0*/
        public IntBasis VIND_FOLLOUP_DATA_LIBERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-COUNT                     PIC S9(04)    COMP   VALUE +0*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-VALOR-HONORARIO           PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis HOST_VALOR_HONORARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-VALOR-REPASSE             PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis HOST_VALOR_REPASSE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-DATA-MOVIMENTO-ABERTO-SI  PIC  X(10) VALUE SPACES.*/
        public StringBasis HOST_DATA_MOVIMENTO_ABERTO_SI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-DATA-CORRENTE             PIC  X(10) VALUE SPACES.*/
        public StringBasis HOST_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-SIT-REGISTRO              PIC  X(01) VALUE SPACES.*/
        public StringBasis HOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77  HOST-MIN-DATA-MOVIMENTO        PIC  X(10) VALUE SPACES.*/
        public StringBasis HOST_MIN_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77   HOST-TEXTO-FORMA-BAIXA PIC X(20) VALUE ' '.*/
        public StringBasis HOST_TEXTO_FORMA_BAIXA { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @" ");
        /*"77   HOST-IND-TIPO-BAIXA    PIC X(20) VALUE ' '.*/
        public StringBasis HOST_IND_TIPO_BAIXA { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @" ");
        /*"77   HOST-TEXTO-TIPO-BAIXA  PIC X(40) VALUE ' '.*/
        public StringBasis HOST_TEXTO_TIPO_BAIXA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @" ");
        /*"01  AREA-DE-WORK.*/
        public SI0216B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0216B_AREA_DE_WORK();
        public class SI0216B_AREA_DE_WORK : VarBasis
        {
            /*"    05 W-EDICAO                      PIC ZZZ.ZZZ.ZZ9.*/
            public IntBasis W_EDICAO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
            /*"    05 WFIM-PROVISAO                 PIC X(03) VALUE 'NAO'.*/
            public StringBasis WFIM_PROVISAO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 WFIM-SINISHIS                 PIC X(03) VALUE 'NAO'.*/
            public StringBasis WFIM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-CRITICA               PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_CRITICA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-PARCELA-JA-BAIXADA    PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_PARCELA_JA_BAIXADA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-GRAVA-FOLLOWUP        PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_GRAVA_FOLLOWUP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-ACHOU-PARCELA         PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_ACHOU_PARCELA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-CREDITO-INTERNO       PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_CREDITO_INTERNO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 WTEM-PAGTO-MAO-GRANDE         PIC X(03)    VALUE 'NAO'.*/
            public StringBasis WTEM_PAGTO_MAO_GRANDE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-DATA-ANTERIOR               PIC X(10)    VALUE ' '.*/
            public StringBasis W_DATA_ANTERIOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
            /*"    05 W-ULTIMO-COMMIT               PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_ULTIMO_COMMIT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-TOTAL-COMMIT                PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_TOTAL_COMMIT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-SALVA-SINISTRO             PIC S9(13) COMP-3 VALUE 0.*/
            public IntBasis W_SALVA_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05 W-TOTAL-PARCELA              PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis W_TOTAL_PARCELA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VAL-COMISSAO-HONORARIO     PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis W_VAL_COMISSAO_HONORARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HOST-VALOR-PAGTO-HON-REPASSE PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis HOST_VALOR_PAGTO_HON_REPASSE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VAL-REPASSE                PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis W_VAL_REPASSE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VALOR-MINIMO-BAIXA         PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis W_VALOR_MINIMO_BAIXA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VALOR-ACRESCIMO            PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis W_VALOR_ACRESCIMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VALOR-DESCONTO             PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis W_VALOR_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-NUM-APOL-SINISTRO          PIC 9(013)  VALUE ZEROS.*/
            public IntBasis W_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05 W-NUM-ACORDO                 PIC 9(013)  VALUE ZEROS.*/
            public IntBasis W_NUM_ACORDO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05 W-NUMERO-SINISTRO-NUM.*/
            public SI0216B_W_NUMERO_SINISTRO_NUM W_NUMERO_SINISTRO_NUM { get; set; } = new SI0216B_W_NUMERO_SINISTRO_NUM();
            public class SI0216B_W_NUMERO_SINISTRO_NUM : VarBasis
            {
                /*"       10 W-ORGAO-SINISTRO          PIC  9(03)     VALUE 0.*/
                public IntBasis W_ORGAO_SINISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 W-RAMO-SINISTRO           PIC  9(02)     VALUE 0.*/
                public IntBasis W_RAMO_SINISTRO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-NUM-SINISTRO            PIC  9(08)     VALUE 0.*/
                public IntBasis W_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
                /*"    05 W-LIDOS-TIPO-01               PIC 9(09)    VALUE ZEROS.*/
            }
            public IntBasis W_LIDOS_TIPO_01 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-LIDOS-TIPO-02               PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_LIDOS_TIPO_02 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-REG-GRAV-RETORNO            PIC 9(06)    VALUE ZEROS.*/
            public IntBasis W_REG_GRAV_RETORNO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05 W-REJEITADOS                  PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_REJEITADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-AVISADOS-SEM-ALTERACAO      PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_AVISADOS_SEM_ALTERACAO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-AVISADOS-COM-ALTERACAO      PIC 9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_AVISADOS_COM_ALTERACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 W-CONTA-SINISTRO              PIC 9(08)    VALUE ZEROS.*/
            public IntBasis W_CONTA_SINISTRO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-MOVIMENTO-PROVISAO      PIC 9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_MOVIMENTO_PROVISAO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-PARCELAS-BAIXADAS       PIC 9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_PARCELAS_BAIXADAS { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-FOLLOWUP                PIC 9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_FOLLOWUP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-SINISTRO-ANT                PIC 9(13)    VALUE ZEROS.*/
            public IntBasis W_SINISTRO_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    05 W-ACORDO-ANT                  PIC 9(13)    VALUE ZEROS.*/
            public IntBasis W_ACORDO_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    05 W-SUREG-ANT                   PIC 9(05)    VALUE ZEROS.*/
            public IntBasis W_SUREG_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    05 W-AGENCIA-ANT                 PIC 9(04)    VALUE ZEROS.*/
            public IntBasis W_AGENCIA_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    05 W-OPERACAO-ANT                PIC 9(04)    VALUE ZEROS.*/
            public IntBasis W_OPERACAO_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    05 W-CONTRATO-ANT                PIC 9(13)    VALUE ZEROS.*/
            public IntBasis W_CONTRATO_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    05 W-DIGITO-ANT                  PIC 9(02)    VALUE ZEROS.*/
            public IntBasis W_DIGITO_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05 W-TEXTO-NOMFAV.*/
            public SI0216B_W_TEXTO_NOMFAV W_TEXTO_NOMFAV { get; set; } = new SI0216B_W_TEXTO_NOMFAV();
            public class SI0216B_W_TEXTO_NOMFAV : VarBasis
            {
                /*"       10 W-TEXTO-NOMFAV-TEXTO       PIC X(37) VALUE SPACES.*/
                public StringBasis W_TEXTO_NOMFAV_TEXTO { get; set; } = new StringBasis(new PIC("X", "37", "X(37)"), @"");
                /*"       10 W-TEXTO-NOMFAV-PARCELA     PIC 9(03) VALUE ZEROS.*/
                public IntBasis W_TEXTO_NOMFAV_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"    05 W-TEXTO-NOMFAV-CAIXA.*/
            }
            public SI0216B_W_TEXTO_NOMFAV_CAIXA W_TEXTO_NOMFAV_CAIXA { get; set; } = new SI0216B_W_TEXTO_NOMFAV_CAIXA();
            public class SI0216B_W_TEXTO_NOMFAV_CAIXA : VarBasis
            {
                /*"       10 W-TEXTO-NOMFAV-TEXTO-CAIXA PIC X(24) VALUE SPACES.*/
                public StringBasis W_TEXTO_NOMFAV_TEXTO_CAIXA { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"");
                /*"       10 FILLER                     PIC X(40) VALUE          '/ REPASSE CAIXA '.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"/ REPASSE CAIXA ");
                /*"    05 W-CONTA-PAGINA                PIC 9(07)    VALUE ZEROS.*/
            }
            public IntBasis W_CONTA_PAGINA { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 W-CONTA-LINHA                 PIC 9(02)    VALUE 90.*/
            public IntBasis W_CONTA_LINHA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 90);
            /*"    05 W-CONTA-PAGINA-AVISOOK        PIC 9(07)    VALUE ZEROS.*/
            public IntBasis W_CONTA_PAGINA_AVISOOK { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 W-CONTA-LINHA-AVISOOK         PIC 9(02)    VALUE 90.*/
            public IntBasis W_CONTA_LINHA_AVISOOK { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 90);
            /*"    05 W-DATA-CORRENTE.*/
            public SI0216B_W_DATA_CORRENTE W_DATA_CORRENTE { get; set; } = new SI0216B_W_DATA_CORRENTE();
            public class SI0216B_W_DATA_CORRENTE : VarBasis
            {
                /*"       15 W-DATA-CORRENTE-ANO        PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       15 W-DATA-CORRENTE-FILLER-1   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_DATA_CORRENTE_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-DATA-CORRENTE-MES        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-DATA-CORRENTE-FILLER-2   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_DATA_CORRENTE_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-DATA-CORRENTE-DIA        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-CORRENTE.*/
            }
            public SI0216B_W_HORA_CORRENTE W_HORA_CORRENTE { get; set; } = new SI0216B_W_HORA_CORRENTE();
            public class SI0216B_W_HORA_CORRENTE : VarBasis
            {
                /*"       15 W-HORA-CORRENTE-ANO        PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       15 W-HORA-CORRENTE-FILLER-1   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_HORA_CORRENTE_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-HORA-CORRENTE-MES        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-HORA-CORRENTE-FILLER-2   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_HORA_CORRENTE_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-HORA-CORRENTE-DIA        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-HH-MM-SS.*/
            }
            public SI0216B_W_HORA_HH_MM_SS W_HORA_HH_MM_SS { get; set; } = new SI0216B_W_HORA_HH_MM_SS();
            public class SI0216B_W_HORA_HH_MM_SS : VarBasis
            {
                /*"       15 W-HORA-HH-MM-SS-HH         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 FILLER                     PIC X(01)       VALUE '.'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"       15 W-HORA-HH-MM-SS-MM         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 FILLER                     PIC X(01)       VALUE '.'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"       15 W-HORA-HH-MM-SS-SS         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-HHMM.*/
            }
            public SI0216B_W_HORA_HHMM W_HORA_HHMM { get; set; } = new SI0216B_W_HORA_HHMM();
            public class SI0216B_W_HORA_HHMM : VarBasis
            {
                /*"       15 W-HORA-HHMM-HH             PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HHMM_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-HORA-HHMM-MM             PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HHMM_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA-AAAAMMDD.*/
            }
            public SI0216B_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new SI0216B_W_DATA_AAAAMMDD();
            public class SI0216B_W_DATA_AAAAMMDD : VarBasis
            {
                /*"       10 W-DATA-AAAAMMDD-AAAA       PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 W-DATA-AAAAMMDD-MM         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-AAAAMMDD-DD         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA-DD-MM-AAAA.*/
            }
            public SI0216B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new SI0216B_W_DATA_DD_MM_AAAA();
            public class SI0216B_W_DATA_DD_MM_AAAA : VarBasis
            {
                /*"       10 W-DATA-DD-MM-AAAA-DD       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-MM       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-AAAA     PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05 W-DATA-AAAA-MM-DD.*/
            }
            public SI0216B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new SI0216B_W_DATA_AAAA_MM_DD();
            public class SI0216B_W_DATA_AAAA_MM_DD : VarBasis
            {
                /*"       10 W-DATA-AAAA-MM-DD-AAAA     PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-MM       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-DD       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-VALOR-LIMITE-01             PIC  9(13)V99 VALUE 0.*/
            }
            public DoubleBasis W_VALOR_LIMITE_01 { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 W-PERC-COMISSAO-HON-PADRAO-01 PIC  9(03)V99 VALUE 0.*/
            public DoubleBasis W_PERC_COMISSAO_HON_PADRAO_01 { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    05 W-PERC-COMISSAO-HON-PADRAO-02 PIC  9(03)V99 VALUE 0.*/
            public DoubleBasis W_PERC_COMISSAO_HON_PADRAO_02 { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    05 W-PERC-COMISSAO-DES-PADRAO-01 PIC  9(03)V99 VALUE 0.*/
            public DoubleBasis W_PERC_COMISSAO_DES_PADRAO_01 { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    05 W-PERCENTUAL-REPASSE          PIC  9(03)V99 VALUE 0.*/
            public DoubleBasis W_PERCENTUAL_REPASSE { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    05 W-OPERACAO-CONTRATO           PIC S9(04)   COMP   VALUE 0*/
            public IntBasis W_OPERACAO_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 W-PERC-REPASSE                PIC  9(03)V9(04)   VALUE 0.*/
            public DoubleBasis W_PERC_REPASSE { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(04)"), 4);
            /*"    05 W-PERC-HONORARIO              PIC  9(03)V99 VALUE 0.*/
            public DoubleBasis W_PERC_HONORARIO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    05 W-PERC-HONORARIO-FINAL        PIC  9(03)V99 VALUE 0.*/
            public DoubleBasis W_PERC_HONORARIO_FINAL { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    05 W-VAL-PERC-VAL-LIMITE-01      PIC S9(13)V99 VALUE 0.*/
            public DoubleBasis W_VAL_PERC_VAL_LIMITE_01 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VAL-EXCEDENTE-LIMITE        PIC S9(13)V99 VALUE 0.*/
            public DoubleBasis W_VAL_EXCEDENTE_LIMITE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VAL-PERC-VAL-LIMITE-02      PIC S9(13)V99 VALUE 0.*/
            public DoubleBasis W_VAL_PERC_VAL_LIMITE_02 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VAL-TOTAL-DEVIDO-COMISSAO   PIC S9(13)V99 VALUE 0.*/
            public DoubleBasis W_VAL_TOTAL_DEVIDO_COMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 LC01.*/
            public SI0216B_LC01 LC01 { get; set; } = new SI0216B_LC01();
            public class SI0216B_LC01 : VarBasis
            {
                /*"       10 LC01-TIPO-ARQUIVO          PIC X(02) VALUE '06'.*/
                public StringBasis LC01_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"06");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC01-TIPO-REGISTRO         PIC X(01) VALUE 'C'.*/
                public StringBasis LC01_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"C");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC01-RELATORIO             PIC X(10) VALUE          'SI0216B - '.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SI0216B - ");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC01-EMPRESA               PIC X(40) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC02.*/
            }
            public SI0216B_LC02 LC02 { get; set; } = new SI0216B_LC02();
            public class SI0216B_LC02 : VarBasis
            {
                /*"       10 LC02-TIPO-ARQUIVO          PIC X(02) VALUE '06'.*/
                public StringBasis LC02_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"06");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC02-TIPO-REGISTRO         PIC X(01) VALUE 'C'.*/
                public StringBasis LC02_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"C");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(19)  VALUE          'DATA SISTEMA (SI): '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA SISTEMA (SI): ");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC02-DATA-SISTEMA          PIC X(10)   VALUE SPACES.*/
                public StringBasis LC02_DATA_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC03.*/
            }
            public SI0216B_LC03 LC03 { get; set; } = new SI0216B_LC03();
            public class SI0216B_LC03 : VarBasis
            {
                /*"       10 LC03-TIPO-ARQUIVO          PIC X(02) VALUE '06'.*/
                public StringBasis LC03_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"06");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC03-TIPO-REGISTRO         PIC X(01) VALUE 'C'.*/
                public StringBasis LC03_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"C");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(15)  VALUE          'DATA CORRENTE: '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA CORRENTE: ");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC03-DATA-CORRENTE         PIC X(10)   VALUE SPACES.*/
                public StringBasis LC03_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 LC04.*/
            }
            public SI0216B_LC04 LC04 { get; set; } = new SI0216B_LC04();
            public class SI0216B_LC04 : VarBasis
            {
                /*"       10 LC04-TIPO-ARQUIVO          PIC X(02) VALUE '06'.*/
                public StringBasis LC04_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"06");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC04-TIPO-REGISTRO         PIC X(01) VALUE 'C'.*/
                public StringBasis LC04_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"C");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(51) VALUE         'RELAT. RETORNO DO PROCES. DAS PROVISOES DO DIA'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"RELAT. RETORNO DO PROCES. DAS PROVISOES DO DIA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC05.*/
            }
            public SI0216B_LC05 LC05 { get; set; } = new SI0216B_LC05();
            public class SI0216B_LC05 : VarBasis
            {
                /*"       10 LC05-TIPO-ARQUIVO          PIC X(02) VALUE '06'.*/
                public StringBasis LC05_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"06");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC05-TIPO-REGISTRO         PIC X(01) VALUE 'C'.*/
                public StringBasis LC05_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"C");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(08) VALUE          'SINISTRO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SINISTRO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(06) VALUE          'ACORDO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"ACORDO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(07) VALUE          'PARCELA'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PARCELA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(06) VALUE          'TITULO'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TITULO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(14) VALUE          'DT. VENCIMENTO'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DT. VENCIMENTO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(14) VALUE          'VALOR RECEBIDO'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"VALOR RECEBIDO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(14) VALUE          'DATA PAGAMENTO'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DATA PAGAMENTO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(18) VALUE          'DATA PROCESSAMENTO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"DATA PROCESSAMENTO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(16) VALUE          'INDICADOR ORIGEM'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"INDICADOR ORIGEM");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(12) VALUE          'TEXTO ORIGEM'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"TEXTO ORIGEM");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(18) VALUE          'IND. TIPO DE BAIXA'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"IND. TIPO DE BAIXA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(20) VALUE          'TEXTO TIPO DE BAIXA'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"TEXTO TIPO DE BAIXA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(15) VALUE          'INDICADOR BAIXA'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"INDICADOR BAIXA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(15) VALUE          'CNPJ ESCRITORIO'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"CNPJ ESCRITORIO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(15) VALUE          'NOME ESCRITORIO'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NOME ESCRITORIO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(15) VALUE          'VALOR HONORARIO'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VALOR HONORARIO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(15) VALUE          'VALOR REPASSE  '.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VALOR REPASSE  ");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(15) VALUE          'VALOR DESPESA  '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VALOR DESPESA  ");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(20) VALUE          'MENSAGEM DE BAIXA'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"MENSAGEM DE BAIXA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(20) VALUE          'OCORR-HISTORICO-SIAS'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"OCORR_HISTORICO_SIAS");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(20) VALUE          'COD-OPERACAO-SIAS'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"COD_OPERACAO_SIAS");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LD01.*/
            }
            public SI0216B_LD01 LD01 { get; set; } = new SI0216B_LD01();
            public class SI0216B_LD01 : VarBasis
            {
                /*"       10 LD01-TIPO-ARQUIVO          PIC X(02) VALUE '06'.*/
                public StringBasis LD01_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"06");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-TIPO-REGISTRO         PIC X(01) VALUE 'D'.*/
                public StringBasis LD01_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"D");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NUM-APOL-SINISTRO     PIC 9(13) VALUE ZEROS.*/
                public IntBasis LD01_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NUM-ACORDO            PIC 9(13) VALUE ZEROS.*/
                public IntBasis LD01_NUM_ACORDO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NUM-PARCELA           PIC 9(05) VALUE ZEROS.*/
                public IntBasis LD01_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NUM-TITULO            PIC 9(16) VALUE ZEROS.*/
                public IntBasis LD01_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "16", "9(16)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-DATA-VENCIMENTO       PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-VALOR-PROVISAO        PIC ---.---.--9,99.*/
                public DoubleBasis LD01_VALOR_PROVISAO { get; set; } = new DoubleBasis(new PIC("9", "9", "---.---.--9V99."), 2);
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-DATA-PAGAMENTO        PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-DATA-PROCESSAMENTO    PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-IND-ORIGEM            PIC X(01) VALUE SPACES.*/
                public StringBasis LD01_IND_ORIGEM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-MSG-ORIGEM            PIC X(30) VALUE SPACES.*/
                public StringBasis LD01_MSG_ORIGEM { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-IND-TIPO-BAIXA        PIC X(01) VALUE SPACES.*/
                public StringBasis LD01_IND_TIPO_BAIXA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-TIPO-BAIXA            PIC X(20) VALUE SPACES.*/
                public StringBasis LD01_TIPO_BAIXA { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-IND-PROCESSAMENTO     PIC X(01) VALUE SPACES.*/
                public StringBasis LD01_IND_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-CNPJ-ESCRITORIO       PIC X(15) VALUE SPACES.*/
                public StringBasis LD01_CNPJ_ESCRITORIO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NOME-ESCRITORIO       PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_NOME_ESCRITORIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-VALOR-HONORARIO       PIC ---.---.--9,99.*/
                public DoubleBasis LD01_VALOR_HONORARIO { get; set; } = new DoubleBasis(new PIC("9", "9", "---.---.--9V99."), 2);
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-VALOR-REPASSE         PIC ---.---.--9,99.*/
                public DoubleBasis LD01_VALOR_REPASSE { get; set; } = new DoubleBasis(new PIC("9", "9", "---.---.--9V99."), 2);
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-VALOR-DESPESA         PIC ---.---.--9,99.*/
                public DoubleBasis LD01_VALOR_DESPESA { get; set; } = new DoubleBasis(new PIC("9", "9", "---.---.--9V99."), 2);
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-MENSAGEM              PIC X(50) VALUE SPACES.*/
                public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-OCORHIST              PIC 9(05) VALUE ZEROS.*/
                public IntBasis LD01_OCORHIST { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-COD-OPERACAO          PIC 9(05) VALUE ZEROS.*/
                public IntBasis LD01_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC99-NAO-TEVE-MOVIMENTO.*/
            }
            public SI0216B_LC99_NAO_TEVE_MOVIMENTO LC99_NAO_TEVE_MOVIMENTO { get; set; } = new SI0216B_LC99_NAO_TEVE_MOVIMENTO();
            public class SI0216B_LC99_NAO_TEVE_MOVIMENTO : VarBasis
            {
                /*"       10 LC99-TIPO-ARQUIVO          PIC X(02) VALUE '06'.*/
                public StringBasis LC99_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"06");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC99-TIPO-REGISTRO         PIC X(01) VALUE 'C'.*/
                public StringBasis LC99_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"C");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(80) VALUE         'NENHUMA BAIXA FOI SELECIONADA PARA PROCESSAMENTO'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"NENHUMA BAIXA FOI SELECIONADA PARA PROCESSAMENTO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC-FIM.*/
            }
            public SI0216B_LC_FIM LC_FIM { get; set; } = new SI0216B_LC_FIM();
            public class SI0216B_LC_FIM : VarBasis
            {
                /*"       10 LCFIM-TIPO-ARQUIVO         PIC X(02) VALUE '06'.*/
                public StringBasis LCFIM_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"06");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC04-TIPO-REGISTRO         PIC X(01) VALUE 'F'.*/
                public StringBasis LC04_TIPO_REGISTRO_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"F");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(14) VALUE         'FIM DE ARQUIVO'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"FIM DE ARQUIVO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(330) VALUE ALL '.'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "330", "X(330)"), @"ALL");
                /*"    05 WABEND.*/
            }
            public SI0216B_WABEND WABEND { get; set; } = new SI0216B_WABEND();
            public class SI0216B_WABEND : VarBasis
            {
                /*"       07 WABEND1.*/
                public SI0216B_WABEND1 WABEND1 { get; set; } = new SI0216B_WABEND1();
                public class SI0216B_WABEND1 : VarBasis
                {
                    /*"       10 FILLER         PIC  X(008)      VALUE          'SI0216B '.*/
                    public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SI0216B ");
                    /*"       07 WABEND2.*/
                    public SI0216B_WABEND2 WABEND2 { get; set; } = new SI0216B_WABEND2();
                    public class SI0216B_WABEND2 : VarBasis
                    {
                        /*"       10 FILLER         PIC  X(025)      VALUE          '*** ERRO EXEC SQL NUMERO '.*/
                        public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                        /*"       10 WNR-EXEC-SQL   PIC  X(004)      VALUE   '0000'.*/
                        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                        /*"       07 WABEND3.*/
                        public SI0216B_WABEND3 WABEND3 { get; set; } = new SI0216B_WABEND3();
                        public class SI0216B_WABEND3 : VarBasis
                        {
                            /*"       10 FILLER         PIC  X(013)      VALUE          ' *** SQLCODE '.*/
                            public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                            /*"       10 WSQLCODE       PIC  ZZZZZ999-   VALUE    ZEROS.*/
                            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                            /*"       10 WSQLERRMC      PIC  X(40)      VALUE    SPACES.*/
                            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                            /*"       10 WSQLCAID     PIC X(8).*/
                            public StringBasis WSQLCAID { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
                            /*"       10 WSQLCABC     PIC S9(9) COMP-4.*/
                            public IntBasis WSQLCABC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
                            /*"       10 WSQLERRP     PIC X(8).*/
                            public StringBasis WSQLERRP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
                            /*"       10 WSQLWARN.*/
                            public SI0216B_WSQLWARN WSQLWARN { get; set; } = new SI0216B_WSQLWARN();
                            public class SI0216B_WSQLWARN : VarBasis
                            {
                                /*"          15 WSQLWARN0 PIC X.*/
                                public StringBasis WSQLWARN0 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN1 PIC X.*/
                                public StringBasis WSQLWARN1 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN2 PIC X.*/
                                public StringBasis WSQLWARN2 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN3 PIC X.*/
                                public StringBasis WSQLWARN3 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN4 PIC X.*/
                                public StringBasis WSQLWARN4 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN5 PIC X.*/
                                public StringBasis WSQLWARN5 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"01          LK-LINK.*/
                            }
                        }
                    }
                    public SI0216B_LK_LINK LK_LINK { get; set; } = new SI0216B_LK_LINK();
                    public class SI0216B_LK_LINK : VarBasis
                    {
                        /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
                        public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                        /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
                        public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
                        /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
                        public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                    }
                }
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.FORNECED FORNECED { get; set; } = new Dclgens.FORNECED();
        public Dclgens.GE284 GE284 { get; set; } = new Dclgens.GE284();
        public Dclgens.SI111 SI111 { get; set; } = new Dclgens.SI111();
        public Dclgens.SI112 SI112 { get; set; } = new Dclgens.SI112();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.PAROPESI PAROPESI { get; set; } = new Dclgens.PAROPESI();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public SI0216B_PROVISAO PROVISAO { get; set; } = new SI0216B_PROVISAO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string REG_RET_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                REG_RET.SetFile(REG_RET_FILE_NAME_P);

                /*" -465- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -466- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -467- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -471- OPEN OUTPUT REG-RET. */
                REG_RET.Open(REGISTRO_RETORNO);

                /*" -472- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

                /*" -474- PERFORM R010-LE-SISTEMAS THRU R010-EXIT. */

                R010_LE_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -476- PERFORM R015-LE-MONTA-NOME-EMPRESA THRU R015-EXIT. */

                R015_LE_MONTA_NOME_EMPRESA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R015_EXIT*/


                /*" -477- WRITE REGISTRO-RETORNO FROM LC01. */
                _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REGISTRO_RETORNO);

                REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -478- WRITE REGISTRO-RETORNO FROM LC02. */
                _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REGISTRO_RETORNO);

                REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -479- WRITE REGISTRO-RETORNO FROM LC03. */
                _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REGISTRO_RETORNO);

                REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -480- WRITE REGISTRO-RETORNO FROM LC04. */
                _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REGISTRO_RETORNO);

                REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -482- WRITE REGISTRO-RETORNO FROM LC05. */
                _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REGISTRO_RETORNO);

                REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -483- MOVE 'NAO' TO WFIM-PROVISAO. */
                _.Move("NAO", AREA_DE_WORK.WFIM_PROVISAO);

                /*" -484- PERFORM R020-LE-PROVISAO-DIA THRU R020-EXIT. */

                R020_LE_PROVISAO_DIA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -486- PERFORM R021-FETCH-PROVISAO THRU R021-EXIT. */

                R021_FETCH_PROVISAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


                /*" -489- PERFORM R100-PROCESSA-PROVISAO THRU R100-EXIT UNTIL WFIM-PROVISAO EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_PROVISAO == "SIM"))
                {

                    R100_PROCESSA_PROVISAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }

                /*" -491- WRITE REGISTRO-RETORNO FROM LC-FIM. */
                _.Move(AREA_DE_WORK.LC_FIM.GetMoveValues(), REGISTRO_RETORNO);

                REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -493- CLOSE REG-RET. */
                REG_RET.Close();

                /*" -494- DISPLAY ' ' . */
                _.Display($" ");

                /*" -495- DISPLAY '*************************************' . */
                _.Display($"*************************************");

                /*" -496- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -497- DISPLAY '*           SI0216B                 *' . */
                _.Display($"*           SI0216B                 *");

                /*" -498- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -499- DISPLAY '*  TERMINO NORMAL DE PROCESSAMENTO  *' . */
                _.Display($"*  TERMINO NORMAL DE PROCESSAMENTO  *");

                /*" -500- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -502- DISPLAY '*************************************' . */
                _.Display($"*************************************");

                /*" -502- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -505- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -505- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R010-LE-SISTEMAS */
        private void R010_LE_SISTEMAS(bool isPerform = false)
        {
            /*" -511- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -520- PERFORM R010_LE_SISTEMAS_DB_SELECT_1 */

            R010_LE_SISTEMAS_DB_SELECT_1();

            /*" -528- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -529- DISPLAY 'SI0216B - SISTEMA SI NAO CADASTRADO' */
                _.Display($"SI0216B - SISTEMA SI NAO CADASTRADO");

                /*" -531- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -532- DISPLAY ' ' . */
            _.Display($" ");

            /*" -533- DISPLAY 'DATA DO SISTEMA DE SINISTRO (SI)' . */
            _.Display($"DATA DO SISTEMA DE SINISTRO (SI)");

            /*" -538- DISPLAY HOST-DATA-MOVIMENTO-ABERTO-SI(9:2) '' HOST-DATA-MOVIMENTO-ABERTO-SI(8:1) HOST-DATA-MOVIMENTO-ABERTO-SI(6:2) HOST-DATA-MOVIMENTO-ABERTO-SI(5:1) HOST-DATA-MOVIMENTO-ABERTO-SI(1:4). */

            $"{HOST_DATA_MOVIMENTO_ABERTO_SI.Substring(9, 2)}{HOST_DATA_MOVIMENTO_ABERTO_SI.Substring(8, 1)}{HOST_DATA_MOVIMENTO_ABERTO_SI.Substring(6, 2)}{HOST_DATA_MOVIMENTO_ABERTO_SI.Substring(5, 1)}{HOST_DATA_MOVIMENTO_ABERTO_SI.Substring(1, 4)}"
            .Display();

            /*" -540- DISPLAY ' ' . */
            _.Display($" ");

            /*" -541- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO W-DATA-DD-MM-AAAA-DD */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -542- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO W-DATA-DD-MM-AAAA-MM */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -544- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -546- MOVE W-DATA-DD-MM-AAAA TO LC02-DATA-SISTEMA. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LC02.LC02_DATA_SISTEMA);

            /*" -547- MOVE HOST-DATA-CORRENTE(9:2) TO W-DATA-DD-MM-AAAA-DD */
            _.Move(HOST_DATA_CORRENTE.Substring(9, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -548- MOVE HOST-DATA-CORRENTE(6:2) TO W-DATA-DD-MM-AAAA-MM */
            _.Move(HOST_DATA_CORRENTE.Substring(6, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -550- MOVE HOST-DATA-CORRENTE(1:4) TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(HOST_DATA_CORRENTE.Substring(1, 4), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -550- MOVE W-DATA-DD-MM-AAAA TO LC03-DATA-CORRENTE. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LC03.LC03_DATA_CORRENTE);

        }

        [StopWatch]
        /*" R010-LE-SISTEMAS-DB-SELECT-1 */
        public void R010_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -520- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN, :HOST-DATA-CORRENTE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r010_LE_SISTEMAS_DB_SELECT_1_Query1 = new R010_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R010_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r010_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATULT_PROCESSAMEN, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);
                _.Move(executed_1.HOST_DATA_CORRENTE, HOST_DATA_CORRENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R015-LE-MONTA-NOME-EMPRESA */
        private void R015_LE_MONTA_NOME_EMPRESA(bool isPerform = false)
        {
            /*" -558- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -563- PERFORM R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1 */

            R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1();

            /*" -566- MOVE EMPRESAS-NOME-EMPRESA TO LK-TITULO */
            _.Move(EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA, AREA_DE_WORK.WABEND.WABEND1.LK_LINK.LK_TITULO);

            /*" -568- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", AREA_DE_WORK.WABEND.WABEND1.LK_LINK);

            /*" -569- IF LK-RTCODE EQUAL ZEROS */

            if (AREA_DE_WORK.WABEND.WABEND1.LK_LINK.LK_RTCODE == 00)
            {

                /*" -570- MOVE LK-TITULO TO LC01-EMPRESA LC01-EMPRESA */
                _.Move(AREA_DE_WORK.WABEND.WABEND1.LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -571- ELSE */
            }
            else
            {


                /*" -572- DISPLAY 'PROBLEMA CALL V0EMPRESA' */
                _.Display($"PROBLEMA CALL V0EMPRESA");

                /*" -572- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R015-LE-MONTA-NOME-EMPRESA-DB-SELECT-1 */
        public void R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1()
        {
            /*" -563- EXEC SQL SELECT NOME_EMPRESA INTO :EMPRESAS-NOME-EMPRESA FROM SEGUROS.EMPRESAS WHERE COD_EMPRESA = 0 END-EXEC. */

            var r015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1 = new R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1.Execute(r015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EMPRESAS_NOME_EMPRESA, EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R015_EXIT*/

        [StopWatch]
        /*" R020-LE-PROVISAO-DIA */
        private void R020_LE_PROVISAO_DIA(bool isPerform = false)
        {
            /*" -580- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -621- PERFORM R020_LE_PROVISAO_DIA_DB_DECLARE_1 */

            R020_LE_PROVISAO_DIA_DB_DECLARE_1();

            /*" -623- PERFORM R020_LE_PROVISAO_DIA_DB_OPEN_1 */

            R020_LE_PROVISAO_DIA_DB_OPEN_1();

            /*" -625- IF SQLCODE < 0 */

            if (DB.SQLCODE < 0)
            {

                /*" -625- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R020-LE-PROVISAO-DIA-DB-DECLARE-1 */
        public void R020_LE_PROVISAO_DIA_DB_DECLARE_1()
        {
            /*" -621- EXEC SQL DECLARE PROVISAO CURSOR FOR SELECT P.NUM_APOL_SINISTRO, P.NUM_RESSARC, P.NUM_PARCELA, P.NUM_NOSSO_TITULO, P.DTH_VENCIMENTO, H.OCORR_HISTORICO, H.COD_OPERACAO, H.VAL_OPERACAO, H.DATA_MOVIMENTO, H1.VAL_OPERACAO AS VALOR_HONORARIO, H2.VAL_OPERACAO AS VALOR_REPASSE FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_HISTORICO H1, SEGUROS.SINISTRO_HISTORICO H2, SEGUROS.SI_RESSARC_ACORDO A, SEGUROS.SI_RESSARC_PARCELA P WHERE H.DATA_MOVIMENTO >= :SISTEMAS-DATULT-PROCESSAMEN AND H.COD_OPERACAO = 4000 AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H1.OCORR_HISTORICO = H.OCORR_HISTORICO AND H1.COD_OPERACAO = 4003 AND H2.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H2.OCORR_HISTORICO = H.OCORR_HISTORICO AND H2.COD_OPERACAO = 4005 AND P.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND P.OCORR_HISTORICO = H.OCORR_HISTORICO AND P.COD_OPERACAO = H.COD_OPERACAO AND A.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO AND A.NUM_RESSARC = P.NUM_RESSARC AND A.SEQ_RESSARC = P.SEQ_RESSARC ORDER BY P.NUM_APOL_SINISTRO, P.NUM_RESSARC, P.NUM_PARCELA WITH UR END-EXEC. */
            PROVISAO = new SI0216B_PROVISAO(true);
            string GetQuery_PROVISAO()
            {
                var query = @$"SELECT P.NUM_APOL_SINISTRO
							, 
							P.NUM_RESSARC
							, 
							P.NUM_PARCELA
							, 
							P.NUM_NOSSO_TITULO
							, 
							P.DTH_VENCIMENTO
							, 
							H.OCORR_HISTORICO
							, 
							H.COD_OPERACAO
							, 
							H.VAL_OPERACAO
							, 
							H.DATA_MOVIMENTO
							, 
							H1.VAL_OPERACAO AS VALOR_HONORARIO
							, 
							H2.VAL_OPERACAO AS VALOR_REPASSE 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_HISTORICO H1
							, 
							SEGUROS.SINISTRO_HISTORICO H2
							, 
							SEGUROS.SI_RESSARC_ACORDO A
							, 
							SEGUROS.SI_RESSARC_PARCELA P 
							WHERE H.DATA_MOVIMENTO >= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN}' 
							AND H.COD_OPERACAO = 4000 
							AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H1.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND H1.COD_OPERACAO = 4003 
							AND H2.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H2.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND H2.COD_OPERACAO = 4005 
							AND P.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND P.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND P.COD_OPERACAO = H.COD_OPERACAO 
							AND A.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO 
							AND A.NUM_RESSARC = P.NUM_RESSARC 
							AND A.SEQ_RESSARC = P.SEQ_RESSARC 
							ORDER BY P.NUM_APOL_SINISTRO
							, P.NUM_RESSARC
							, P.NUM_PARCELA";

                return query;
            }
            PROVISAO.GetQueryEvent += GetQuery_PROVISAO;

        }

        [StopWatch]
        /*" R020-LE-PROVISAO-DIA-DB-OPEN-1 */
        public void R020_LE_PROVISAO_DIA_DB_OPEN_1()
        {
            /*" -623- EXEC SQL OPEN PROVISAO END-EXEC. */

            PROVISAO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R021-FETCH-PROVISAO */
        private void R021_FETCH_PROVISAO(bool isPerform = false)
        {
            /*" -634- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -646- PERFORM R021_FETCH_PROVISAO_DB_FETCH_1 */

            R021_FETCH_PROVISAO_DB_FETCH_1();

            /*" -649- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -651- ADD 1 TO W-QTD-MOVIMENTO-PROVISAO. */
                AREA_DE_WORK.W_QTD_MOVIMENTO_PROVISAO.Value = AREA_DE_WORK.W_QTD_MOVIMENTO_PROVISAO + 1;
            }


            /*" -652- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -653- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -653- PERFORM R021_FETCH_PROVISAO_DB_CLOSE_1 */

                    R021_FETCH_PROVISAO_DB_CLOSE_1();

                    /*" -655- MOVE 'SIM' TO WFIM-PROVISAO */
                    _.Move("SIM", AREA_DE_WORK.WFIM_PROVISAO);

                    /*" -656- ELSE */
                }
                else
                {


                    /*" -657- DISPLAY 'ERRO NO FETCH DA COBANCA' */
                    _.Display($"ERRO NO FETCH DA COBANCA");

                    /*" -657- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R021-FETCH-PROVISAO-DB-FETCH-1 */
        public void R021_FETCH_PROVISAO_DB_FETCH_1()
        {
            /*" -646- EXEC SQL FETCH PROVISAO INTO :SI111-NUM-APOL-SINISTRO, :SI111-NUM-RESSARC, :SI111-NUM-PARCELA, :SI111-NUM-NOSSO-TITULO, :SI111-DTH-VENCIMENTO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-VAL-OPERACAO, :SINISHIS-DATA-MOVIMENTO, :HOST-VALOR-HONORARIO, :HOST-VALOR-REPASSE END-EXEC. */

            if (PROVISAO.Fetch())
            {
                _.Move(PROVISAO.SI111_NUM_APOL_SINISTRO, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO);
                _.Move(PROVISAO.SI111_NUM_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC);
                _.Move(PROVISAO.SI111_NUM_PARCELA, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA);
                _.Move(PROVISAO.SI111_NUM_NOSSO_TITULO, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO);
                _.Move(PROVISAO.SI111_DTH_VENCIMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_VENCIMENTO);
                _.Move(PROVISAO.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(PROVISAO.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(PROVISAO.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(PROVISAO.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(PROVISAO.HOST_VALOR_HONORARIO, HOST_VALOR_HONORARIO);
                _.Move(PROVISAO.HOST_VALOR_REPASSE, HOST_VALOR_REPASSE);
            }

        }

        [StopWatch]
        /*" R021-FETCH-PROVISAO-DB-CLOSE-1 */
        public void R021_FETCH_PROVISAO_DB_CLOSE_1()
        {
            /*" -653- EXEC SQL CLOSE PROVISAO END-EXEC */

            PROVISAO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-PROVISAO */
        private void R100_PROCESSA_PROVISAO(bool isPerform = false)
        {
            /*" -664- MOVE '06' TO LD01-TIPO-ARQUIVO. */
            _.Move("06", AREA_DE_WORK.LD01.LD01_TIPO_ARQUIVO);

            /*" -665- MOVE 'D' TO LD01-TIPO-REGISTRO. */
            _.Move("D", AREA_DE_WORK.LD01.LD01_TIPO_REGISTRO);

            /*" -666- MOVE SI111-NUM-APOL-SINISTRO TO LD01-NUM-APOL-SINISTRO. */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO, AREA_DE_WORK.LD01.LD01_NUM_APOL_SINISTRO);

            /*" -667- MOVE SI111-NUM-RESSARC TO LD01-NUM-ACORDO. */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC, AREA_DE_WORK.LD01.LD01_NUM_ACORDO);

            /*" -668- MOVE SI111-NUM-PARCELA TO LD01-NUM-PARCELA. */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA, AREA_DE_WORK.LD01.LD01_NUM_PARCELA);

            /*" -669- MOVE SI111-NUM-NOSSO-TITULO TO LD01-NUM-TITULO. */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO, AREA_DE_WORK.LD01.LD01_NUM_TITULO);

            /*" -670- MOVE SI111-DTH-VENCIMENTO TO LD01-DATA-VENCIMENTO. */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_VENCIMENTO, AREA_DE_WORK.LD01.LD01_DATA_VENCIMENTO);

            /*" -671- MOVE SINISHIS-VAL-OPERACAO TO LD01-VALOR-PROVISAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.LD01.LD01_VALOR_PROVISAO);

            /*" -672- MOVE SINISHIS-DATA-MOVIMENTO TO LD01-DATA-PROCESSAMENTO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, AREA_DE_WORK.LD01.LD01_DATA_PROCESSAMENTO);

            /*" -673- MOVE SPACES TO LD01-IND-ORIGEM. */
            _.Move("", AREA_DE_WORK.LD01.LD01_IND_ORIGEM);

            /*" -674- MOVE SPACES TO LD01-MSG-ORIGEM. */
            _.Move("", AREA_DE_WORK.LD01.LD01_MSG_ORIGEM);

            /*" -675- MOVE SPACES TO LD01-IND-TIPO-BAIXA. */
            _.Move("", AREA_DE_WORK.LD01.LD01_IND_TIPO_BAIXA);

            /*" -676- MOVE SPACES TO LD01-TIPO-BAIXA. */
            _.Move("", AREA_DE_WORK.LD01.LD01_TIPO_BAIXA);

            /*" -677- MOVE SPACES TO LD01-IND-PROCESSAMENTO. */
            _.Move("", AREA_DE_WORK.LD01.LD01_IND_PROCESSAMENTO);

            /*" -678- MOVE 'PROVISAO EFETUADA COM SUCESSO' TO LD01-MENSAGEM. */
            _.Move("PROVISAO EFETUADA COM SUCESSO", AREA_DE_WORK.LD01.LD01_MENSAGEM);

            /*" -679- MOVE HOST-VALOR-HONORARIO TO LD01-VALOR-HONORARIO */
            _.Move(HOST_VALOR_HONORARIO, AREA_DE_WORK.LD01.LD01_VALOR_HONORARIO);

            /*" -680- MOVE SPACES TO LD01-CNPJ-ESCRITORIO */
            _.Move("", AREA_DE_WORK.LD01.LD01_CNPJ_ESCRITORIO);

            /*" -681- MOVE SPACES TO LD01-NOME-ESCRITORIO */
            _.Move("", AREA_DE_WORK.LD01.LD01_NOME_ESCRITORIO);

            /*" -683- MOVE HOST-VALOR-REPASSE TO LD01-VALOR-REPASSE */
            _.Move(HOST_VALOR_REPASSE, AREA_DE_WORK.LD01.LD01_VALOR_REPASSE);

            /*" -685- MOVE ZEROS TO LD01-VALOR-DESPESA. */
            _.Move(0, AREA_DE_WORK.LD01.LD01_VALOR_DESPESA);

            /*" -686- MOVE SINISHIS-OCORR-HISTORICO TO LD01-OCORHIST. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, AREA_DE_WORK.LD01.LD01_OCORHIST);

            /*" -688- MOVE SINISHIS-COD-OPERACAO TO LD01-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, AREA_DE_WORK.LD01.LD01_COD_OPERACAO);

            /*" -690- WRITE REGISTRO-RETORNO FROM LD01. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REGISTRO_RETORNO);

            REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

            /*" -690- PERFORM R021-FETCH-PROVISAO THRU R021-EXIT. */

            R021_FETCH_PROVISAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -698- CLOSE REG-RET. */
            REG_RET.Close();

            /*" -699- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -700- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLERRMC);

            /*" -701- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLERRMC);

            /*" -702- MOVE SQLCAID TO WSQLCAID . */
            _.Move(DB.SQLCAID, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCAID);

            /*" -703- MOVE SQLCABC TO WSQLCABC . */
            _.Move(DB.SQLCABC, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCABC);

            /*" -704- MOVE SQLCODE TO WSQLCODE . */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -706- MOVE SQLERRP TO WSQLERRP . */
            _.Move(DB.SQLERRP, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLERRP);

            /*" -707- MOVE SQLWARN TO WSQLWARN. */
            _.Move(DB.SQLWARN, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLWARN);

            /*" -708- DISPLAY ' ' */
            _.Display($" ");

            /*" -709- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -710- DISPLAY ' ' */
            _.Display($" ");

            /*" -711- DISPLAY WABEND1. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1);

            /*" -712- DISPLAY WABEND2. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2);

            /*" -713- DISPLAY WABEND3. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3);

            /*" -713- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -714- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -716- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -716- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_EXIT*/

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK */
        private void R10010199_MENSAGEM_LOCK(bool isPerform = false)
        {
            /*" -724- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -727- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -730- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -733- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      A T E N C A O       S R.   O P E R A D O R         *WITHNOADVANCING"
            .Display();

            /*" -736- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -739- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -742- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                   PROGRAMA ABENDADO                     *WITHNOADVANCING"
            .Display();

            /*" -745- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                 PROVAVELMENTE POR LOCK                  *WITHNOADVANCING"
            .Display();

            /*" -748- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' UPON CONSOLE WITH NO ADVANCING. */

            $"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *WITHNOADVANCING"
            .Display();

            /*" -751- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE WITH NO ADVANCING. */

            $"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *WITHNOADVANCING"
            .Display();

            /*" -754- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -757- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *WITHNOADVANCING"
            .Display();

            /*" -760- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -763- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -766- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE WITH NO ADVANCING. */

            $"*     SQLCODE DO ABEND ....... {AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE}WITHNOADVANCING"
            .Display();

            /*" -769- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -775- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -777- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -779- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -781- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -783- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -785- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -787- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -789- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -791- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -793- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -795- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -797- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -799- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -801- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -803- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -805- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE}");

            /*" -807- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -807- GO TO R9999-00-ROT-ERRO. */

            R9999_00_ROT_ERRO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010199_EXIT*/
    }
}