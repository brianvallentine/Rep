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
using Sias.Sinistro.DB2.SI0220B;

namespace Code
{
    public class SI0220B
    {
        public bool IsCall { get; set; }

        public SI0220B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO / RESSARCIMENTO           *      */
        /*"      *   PROGRAMA ...............  SI0220B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER                             *      */
        /*"      *   PROGRAMADOR ............  HEIDER                             *      */
        /*"      *   DATA CODIFICACAO .......  MARCO / 2004                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... GERAR DO ARQUIVO DOS VALORES DE REPASSE DAS   *      */
        /*"      *          PARCELAS RECEBIDAS NO DIA. ESTE ARQUIVO SERA UTILIZADO       */
        /*"      *          PELA FENAE/CAIXA PARA A BAIXA DE RESTRICAO DO DEVEDOR.       */
        /*"      *          A BAIXA DA RESTRICAO SERA FEITA MESMO ANTES DO ENVIO DO      */
        /*"      *          PAGAMENTO (EFETIVO) A CAIXA.                                 */
        /*"      *          SSI - 11527                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _REG_RET { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis REG_RET
        {
            get
            {
                _.Move(REGISTRO_RETORNO, _REG_RET); VarBasis.RedefinePassValue(REGISTRO_RETORNO, _REG_RET, REGISTRO_RETORNO); return _REG_RET;
            }
        }
        /*"01  REGISTRO-RETORNO  PIC X(400).*/
        public StringBasis REGISTRO_RETORNO { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  VIND-DTH-PAGAMENTO             PIC S9(04)    COMP   VALUE +0*/
        public IntBasis VIND_DTH_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-FOLLOUP-DATA-LIBERACAO    PIC S9(04)    COMP   VALUE +0*/
        public IntBasis VIND_FOLLOUP_DATA_LIBERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-COUNT                     PIC S9(04)    COMP   VALUE +0*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-VALOR-RECEBIDO            PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis HOST_VALOR_RECEBIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-VALOR-PRELIB-REPASSE      PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis HOST_VALOR_PRELIB_REPASSE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-DATA-BAIXA-SIAS           PIC  X(10) VALUE SPACES.*/
        public StringBasis HOST_DATA_BAIXA_SIAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-DATA-MOVIMENTO-ABERTO-SI  PIC  X(10) VALUE SPACES.*/
        public StringBasis HOST_DATA_MOVIMENTO_ABERTO_SI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-DATA-CORRENTE             PIC  X(10) VALUE SPACES.*/
        public StringBasis HOST_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-SIT-REGISTRO              PIC  X(01) VALUE SPACES.*/
        public StringBasis HOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77  HOST-MIN-DATA-MOVIMENTO        PIC  X(10) VALUE SPACES.*/
        public StringBasis HOST_MIN_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-COD-AGENCIA-CONTRATO      PIC S9(04)    COMP   VALUE +0*/
        public IntBasis HOST_COD_AGENCIA_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   HOST-TEXTO-FORMA-BAIXA PIC X(20) VALUE ' '.*/
        public StringBasis HOST_TEXTO_FORMA_BAIXA { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @" ");
        /*"77   HOST-IND-TIPO-BAIXA    PIC X(20) VALUE ' '.*/
        public StringBasis HOST_IND_TIPO_BAIXA { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @" ");
        /*"77   HOST-TEXTO-TIPO-BAIXA  PIC X(40) VALUE ' '.*/
        public StringBasis HOST_TEXTO_TIPO_BAIXA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @" ");
        /*"01  AREA-DE-WORK.*/
        public SI0220B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0220B_AREA_DE_WORK();
        public class SI0220B_AREA_DE_WORK : VarBasis
        {
            /*"    05 W-EDICAO                      PIC ZZZ.ZZZ.ZZ9.*/
            public IntBasis W_EDICAO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
            /*"    05 W-MATCON-CONTRATO.*/
            public SI0220B_W_MATCON_CONTRATO W_MATCON_CONTRATO { get; set; } = new SI0220B_W_MATCON_CONTRATO();
            public class SI0220B_W_MATCON_CONTRATO : VarBasis
            {
                /*"       10 W-MATCON-OPERACAO          PIC 9(03) VALUE ZEROS.*/
                public IntBasis W_MATCON_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-MATCON-AGENCIA           PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_MATCON_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-MATCON-NUM-CONTRATO      PIC 9(07) VALUE ZEROS.*/
                public IntBasis W_MATCON_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
                /*"    05 W-CREDITO-CONTRATO.*/
            }
            public SI0220B_W_CREDITO_CONTRATO W_CREDITO_CONTRATO { get; set; } = new SI0220B_W_CREDITO_CONTRATO();
            public class SI0220B_W_CREDITO_CONTRATO : VarBasis
            {
                /*"       10 W-CREDITO-COD-SUREG        PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_CREDITO_COD_SUREG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-CREDITO-COD-AGENCIA      PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_CREDITO_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-CREDITO-COD-OPERACAO     PIC 9(03) VALUE ZEROS.*/
                public IntBasis W_CREDITO_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-CREDITO-NUM-CONTRATO     PIC 9(07) VALUE ZEROS.*/
                public IntBasis W_CREDITO_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
                /*"       10 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-CREDITO-CONTRATO-DIGITO  PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_CREDITO_CONTRATO_DIGITO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 WFIM-PROVISAO                 PIC X(03) VALUE 'NAO'.*/
            }
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
            public SI0220B_W_NUMERO_SINISTRO_NUM W_NUMERO_SINISTRO_NUM { get; set; } = new SI0220B_W_NUMERO_SINISTRO_NUM();
            public class SI0220B_W_NUMERO_SINISTRO_NUM : VarBasis
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
            public SI0220B_W_TEXTO_NOMFAV W_TEXTO_NOMFAV { get; set; } = new SI0220B_W_TEXTO_NOMFAV();
            public class SI0220B_W_TEXTO_NOMFAV : VarBasis
            {
                /*"       10 W-TEXTO-NOMFAV-TEXTO       PIC X(37) VALUE SPACES.*/
                public StringBasis W_TEXTO_NOMFAV_TEXTO { get; set; } = new StringBasis(new PIC("X", "37", "X(37)"), @"");
                /*"       10 W-TEXTO-NOMFAV-PARCELA     PIC 9(03) VALUE ZEROS.*/
                public IntBasis W_TEXTO_NOMFAV_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"    05 W-TEXTO-NOMFAV-CAIXA.*/
            }
            public SI0220B_W_TEXTO_NOMFAV_CAIXA W_TEXTO_NOMFAV_CAIXA { get; set; } = new SI0220B_W_TEXTO_NOMFAV_CAIXA();
            public class SI0220B_W_TEXTO_NOMFAV_CAIXA : VarBasis
            {
                /*"       10 W-TEXTO-NOMFAV-TEXTO-CAIXA PIC X(24) VALUE SPACES.*/
                public StringBasis W_TEXTO_NOMFAV_TEXTO_CAIXA { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"");
                /*"       10 FILLER                     PIC X(40) VALUE          '/ REPASSE CAIXA '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"/ REPASSE CAIXA ");
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
            public SI0220B_W_DATA_CORRENTE W_DATA_CORRENTE { get; set; } = new SI0220B_W_DATA_CORRENTE();
            public class SI0220B_W_DATA_CORRENTE : VarBasis
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
            public SI0220B_W_HORA_CORRENTE W_HORA_CORRENTE { get; set; } = new SI0220B_W_HORA_CORRENTE();
            public class SI0220B_W_HORA_CORRENTE : VarBasis
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
            public SI0220B_W_HORA_HH_MM_SS W_HORA_HH_MM_SS { get; set; } = new SI0220B_W_HORA_HH_MM_SS();
            public class SI0220B_W_HORA_HH_MM_SS : VarBasis
            {
                /*"       15 W-HORA-HH-MM-SS-HH         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 FILLER                     PIC X(01)       VALUE '.'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"       15 W-HORA-HH-MM-SS-MM         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 FILLER                     PIC X(01)       VALUE '.'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"       15 W-HORA-HH-MM-SS-SS         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-HHMM.*/
            }
            public SI0220B_W_HORA_HHMM W_HORA_HHMM { get; set; } = new SI0220B_W_HORA_HHMM();
            public class SI0220B_W_HORA_HHMM : VarBasis
            {
                /*"       15 W-HORA-HHMM-HH             PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HHMM_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-HORA-HHMM-MM             PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HHMM_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA-AAAAMMDD.*/
            }
            public SI0220B_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new SI0220B_W_DATA_AAAAMMDD();
            public class SI0220B_W_DATA_AAAAMMDD : VarBasis
            {
                /*"       10 W-DATA-AAAAMMDD-AAAA       PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 W-DATA-AAAAMMDD-MM         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-AAAAMMDD-DD         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA-DD-MM-AAAA.*/
            }
            public SI0220B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new SI0220B_W_DATA_DD_MM_AAAA();
            public class SI0220B_W_DATA_DD_MM_AAAA : VarBasis
            {
                /*"       10 W-DATA-DD-MM-AAAA-DD       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '/'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-MM       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '/'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-AAAA     PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05 W-DATA-AAAA-MM-DD.*/
            }
            public SI0220B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new SI0220B_W_DATA_AAAA_MM_DD();
            public class SI0220B_W_DATA_AAAA_MM_DD : VarBasis
            {
                /*"       10 W-DATA-AAAA-MM-DD-AAAA     PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '-'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-MM       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '-'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
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
            public SI0220B_LC01 LC01 { get; set; } = new SI0220B_LC01();
            public class SI0220B_LC01 : VarBasis
            {
                /*"       10 LC01-RELATORIO             PIC X(11) VALUE          'SI0220B - '.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"SI0220B - ");
                /*"       10 LC01-EMPRESA               PIC X(40) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC02.*/
            }
            public SI0220B_LC02 LC02 { get; set; } = new SI0220B_LC02();
            public class SI0220B_LC02 : VarBasis
            {
                /*"       10 FILLER                     PIC X(19)  VALUE          'DATA SISTEMA (SI): '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA SISTEMA (SI): ");
                /*"       10 LC02-DATA-SISTEMA          PIC X(10)   VALUE SPACES.*/
                public StringBasis LC02_DATA_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC03.*/
            }
            public SI0220B_LC03 LC03 { get; set; } = new SI0220B_LC03();
            public class SI0220B_LC03 : VarBasis
            {
                /*"       10 FILLER                     PIC X(15)  VALUE          'DATA CORRENTE: '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA CORRENTE: ");
                /*"       10 LC03-DATA-CORRENTE         PIC X(10)   VALUE SPACES.*/
                public StringBasis LC03_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 LC04.*/
            }
            public SI0220B_LC04 LC04 { get; set; } = new SI0220B_LC04();
            public class SI0220B_LC04 : VarBasis
            {
                /*"       10 FILLER                     PIC X(51) VALUE         'RELATORIO DE PROVISOES DE REPASSE DO DIA '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"RELATORIO DE PROVISOES DE REPASSE DO DIA ");
                /*"       10 LC04-DATA-SISTEMA          PIC X(10)   VALUE SPACES.*/
                public StringBasis LC04_DATA_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC05.*/
            }
            public SI0220B_LC05 LC05 { get; set; } = new SI0220B_LC05();
            public class SI0220B_LC05 : VarBasis
            {
                /*"       10 FILLER                     PIC X(10) VALUE          'COD. GIPRO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"COD. GIPRO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(10) VALUE          'NOME GIPRO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"NOME GIPRO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(16) VALUE          'AGENCIA CONTRATO'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"AGENCIA CONTRATO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(22) VALUE          'NOME AGENCIA CONTRATO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"NOME AGENCIA CONTRATO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(15) VALUE          'NUMERO CONTRATO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NUMERO CONTRATO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(13) VALUE          'NOME SEGURADO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"NOME SEGURADO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(19) VALUE          'CPF / CNPJ SEGURADO'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"CPF / CNPJ SEGURADO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(08) VALUE          'SINISTRO'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SINISTRO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(11) VALUE          'DATA ACORDO'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"DATA ACORDO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(13) VALUE          'VALOR REPASSE'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"VALOR REPASSE");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(21) VALUE          'REFERENCIA DO REPASSE'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"REFERENCIA DO REPASSE");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(25) VALUE          'VALOR RECEBIDO DA PARCELA'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"VALOR RECEBIDO DA PARCELA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(17) VALUE          'DATA DO PAGAMENTO'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"DATA DO PAGAMENTO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(26) VALUE          'DATA VENCIMENTO DA PARCELA'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"DATA VENCIMENTO DA PARCELA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(21) VALUE          'DATA DE PROCESSAMENTO'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"DATA DE PROCESSAMENTO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(22) VALUE          'OCORR. HISTORICO (CXS)'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"OCORR. HISTORICO (CXS)");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(12) VALUE          'COD. PRODUTO'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"COD. PRODUTO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(12) VALUE          'NOME PRODUTO'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NOME PRODUTO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LD01.*/
            }
            public SI0220B_LD01 LD01 { get; set; } = new SI0220B_LD01();
            public class SI0220B_LD01 : VarBasis
            {
                /*"       10 LD01-COD-GIPRO             PIC 9(05) VALUE ZEROS.*/
                public IntBasis LD01_COD_GIPRO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NOME-GIPRO            PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_NOME_GIPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-COD-AGENCIA-CONTRATO  PIC 9(04) VALUE ZEROS.*/
                public IntBasis LD01_COD_AGENCIA_CONTRATO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NOME-AGENCIA-CONTRATO PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_NOME_AGENCIA_CONTRATO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NUM-CONTRATO          PIC X(22) VALUE SPACES.*/
                public StringBasis LD01_NUM_CONTRATO { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NOME-SEGURADO         PIC X(40) VALUE ' '.*/
                public StringBasis LD01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @" ");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-CGCCPF-SEGURADO       PIC 9(15) VALUE ZEROS.*/
                public IntBasis LD01_CGCCPF_SEGURADO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NUM-APOL-SINISTRO     PIC 9(13) VALUE ZEROS.*/
                public IntBasis LD01_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-DATA-ACORDO           PIC X(10) VALUE ' '.*/
                public StringBasis LD01_DATA_ACORDO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-VALOR-REPASSE         PIC ---.---.--9,99.*/
                public DoubleBasis LD01_VALOR_REPASSE { get; set; } = new DoubleBasis(new PIC("9", "9", "---.---.--9V99."), 2);
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-FIXO-01               PIC X(27) VALUE          'REPASSE DE RESSARC. ACORDO '.*/
                public StringBasis LD01_FIXO_01 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"REPASSE DE RESSARC. ACORDO ");
                /*"       10 LD01-NUM-ACORDO            PIC 9(03) VALUE ZEROS.*/
                public IntBasis LD01_NUM_ACORDO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 LD01-FIXO-02               PIC X(07) VALUE          ' PARC. '.*/
                public StringBasis LD01_FIXO_02 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @" PARC. ");
                /*"       10 LD01-NUM-PARCELA           PIC 9(03) VALUE ZEROS.*/
                public IntBasis LD01_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 FILLER                     PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 LD01-QTD-TOTAL-PARCELAS    PIC 9(03) VALUE ZEROS.*/
                public IntBasis LD01_QTD_TOTAL_PARCELAS { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-VALOR-RECEBIDO        PIC ---.---.--9,99.*/
                public DoubleBasis LD01_VALOR_RECEBIDO { get; set; } = new DoubleBasis(new PIC("9", "9", "---.---.--9V99."), 2);
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-DATA-PAGAMENTO        PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-DATA-VENCIMENTO       PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-DATA-PROCESSAMENTO    PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-OCORR-HISTORICO       PIC 9(03) VALUE ZEROS.*/
                public IntBasis LD01_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-COD-PRODUTO           PIC 9(04) VALUE ZEROS.*/
                public IntBasis LD01_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NOME-PRODUTO          PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC99-NAO-TEVE-MOVIMENTO.*/
            }
            public SI0220B_LC99_NAO_TEVE_MOVIMENTO LC99_NAO_TEVE_MOVIMENTO { get; set; } = new SI0220B_LC99_NAO_TEVE_MOVIMENTO();
            public class SI0220B_LC99_NAO_TEVE_MOVIMENTO : VarBasis
            {
                /*"       10 FILLER                     PIC X(80) VALUE         'NENHUMA BAIXA FOI SELECIONADA PARA PROCESSAMENTO'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"NENHUMA BAIXA FOI SELECIONADA PARA PROCESSAMENTO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC-FIM.*/
            }
            public SI0220B_LC_FIM LC_FIM { get; set; } = new SI0220B_LC_FIM();
            public class SI0220B_LC_FIM : VarBasis
            {
                /*"       10 FILLER                     PIC X(14) VALUE         'FIM DE ARQUIVO'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"FIM DE ARQUIVO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(330) VALUE ALL '.'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "330", "X(330)"), @"ALL");
                /*"    05 WABEND.*/
            }
            public SI0220B_WABEND WABEND { get; set; } = new SI0220B_WABEND();
            public class SI0220B_WABEND : VarBasis
            {
                /*"       07 WABEND1.*/
                public SI0220B_WABEND1 WABEND1 { get; set; } = new SI0220B_WABEND1();
                public class SI0220B_WABEND1 : VarBasis
                {
                    /*"       10 FILLER         PIC  X(008)      VALUE          'SI0220B '.*/
                    public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SI0220B ");
                    /*"       07 WABEND2.*/
                    public SI0220B_WABEND2 WABEND2 { get; set; } = new SI0220B_WABEND2();
                    public class SI0220B_WABEND2 : VarBasis
                    {
                        /*"       10 FILLER         PIC  X(025)      VALUE          '*** ERRO EXEC SQL NUMERO '.*/
                        public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                        /*"       10 WNR-EXEC-SQL   PIC  X(004)      VALUE   '0000'.*/
                        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                        /*"       07 WABEND3.*/
                        public SI0220B_WABEND3 WABEND3 { get; set; } = new SI0220B_WABEND3();
                        public class SI0220B_WABEND3 : VarBasis
                        {
                            /*"       10 FILLER         PIC  X(013)      VALUE          ' *** SQLCODE '.*/
                            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
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
                            public SI0220B_WSQLWARN WSQLWARN { get; set; } = new SI0220B_WSQLWARN();
                            public class SI0220B_WSQLWARN : VarBasis
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
                    public SI0220B_LK_LINK LK_LINK { get; set; } = new SI0220B_LK_LINK();
                    public class SI0220B_LK_LINK : VarBasis
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
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.APOLICRE APOLICRE { get; set; } = new Dclgens.APOLICRE();
        public Dclgens.SINCREIN SINCREIN { get; set; } = new Dclgens.SINCREIN();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.FORNECED FORNECED { get; set; } = new Dclgens.FORNECED();
        public Dclgens.SI111 SI111 { get; set; } = new Dclgens.SI111();
        public Dclgens.SI112 SI112 { get; set; } = new Dclgens.SI112();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.PAROPESI PAROPESI { get; set; } = new Dclgens.PAROPESI();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public SI0220B_PROVISAO PROVISAO { get; set; } = new SI0220B_PROVISAO();
        public SI0220B_CREDITO CREDITO { get; set; } = new SI0220B_CREDITO();
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

                /*" -476- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -477- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -478- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -482- OPEN OUTPUT REG-RET. */
                REG_RET.Open(REGISTRO_RETORNO);

                /*" -483- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

                /*" -485- PERFORM R010-LE-SISTEMAS THRU R010-EXIT. */

                R010_LE_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -487- PERFORM R015-LE-MONTA-NOME-EMPRESA THRU R015-EXIT. */

                R015_LE_MONTA_NOME_EMPRESA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R015_EXIT*/


                /*" -488- WRITE REGISTRO-RETORNO FROM LC01. */
                _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REGISTRO_RETORNO);

                REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -489- WRITE REGISTRO-RETORNO FROM LC04. */
                _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REGISTRO_RETORNO);

                REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -490- WRITE REGISTRO-RETORNO FROM LC02. */
                _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REGISTRO_RETORNO);

                REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -491- WRITE REGISTRO-RETORNO FROM LC03. */
                _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REGISTRO_RETORNO);

                REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -493- WRITE REGISTRO-RETORNO FROM LC05. */
                _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REGISTRO_RETORNO);

                REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -494- MOVE 'NAO' TO WFIM-PROVISAO. */
                _.Move("NAO", AREA_DE_WORK.WFIM_PROVISAO);

                /*" -495- PERFORM R020-LE-PROVISAO-DIA THRU R020-EXIT. */

                R020_LE_PROVISAO_DIA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -497- PERFORM R021-FETCH-PROVISAO THRU R021-EXIT. */

                R021_FETCH_PROVISAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


                /*" -500- PERFORM R100-PROCESSA-PROVISAO THRU R100-EXIT UNTIL WFIM-PROVISAO EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_PROVISAO == "SIM"))
                {

                    R100_PROCESSA_PROVISAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }

                /*" -502- WRITE REGISTRO-RETORNO FROM LC-FIM. */
                _.Move(AREA_DE_WORK.LC_FIM.GetMoveValues(), REGISTRO_RETORNO);

                REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -504- CLOSE REG-RET. */
                REG_RET.Close();

                /*" -505- DISPLAY ' ' . */
                _.Display($" ");

                /*" -506- DISPLAY '*************************************' . */
                _.Display($"*************************************");

                /*" -507- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -508- DISPLAY '*           SI0220B                 *' . */
                _.Display($"*           SI0220B                 *");

                /*" -509- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -510- DISPLAY '*  TERMINO NORMAL DE PROCESSAMENTO  *' . */
                _.Display($"*  TERMINO NORMAL DE PROCESSAMENTO  *");

                /*" -511- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -512- DISPLAY '*************************************' . */
                _.Display($"*************************************");

                /*" -514- DISPLAY 'QTD. REG. SELECIONADOS = ' W-QTD-MOVIMENTO-PROVISAO. */
                _.Display($"QTD. REG. SELECIONADOS = {AREA_DE_WORK.W_QTD_MOVIMENTO_PROVISAO}");

                /*" -514- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -517- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -517- STOP RUN. */

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
            /*" -523- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -533- PERFORM R010_LE_SISTEMAS_DB_SELECT_1 */

            R010_LE_SISTEMAS_DB_SELECT_1();

            /*" -539- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -540- DISPLAY 'SI0220B - SISTEMA SI NAO CADASTRADO' */
                _.Display($"SI0220B - SISTEMA SI NAO CADASTRADO");

                /*" -542- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -543- DISPLAY ' ' . */
            _.Display($" ");

            /*" -544- DISPLAY 'DATA DO SISTEMA DE SINISTRO (SI)' . */
            _.Display($"DATA DO SISTEMA DE SINISTRO (SI)");

            /*" -549- DISPLAY '' SISTEMAS-DATA-MOV-ABERTO(9:2) SISTEMAS-DATA-MOV-ABERTO(8:1) SISTEMAS-DATA-MOV-ABERTO(6:2) SISTEMAS-DATA-MOV-ABERTO(5:1) SISTEMAS-DATA-MOV-ABERTO(1:4). */

            $"{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -551- DISPLAY ' ' . */
            _.Display($" ");

            /*" -552- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO W-DATA-DD-MM-AAAA-DD */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -553- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO W-DATA-DD-MM-AAAA-MM */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -555- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -558- MOVE W-DATA-DD-MM-AAAA TO LC02-DATA-SISTEMA LC04-DATA-SISTEMA. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LC02.LC02_DATA_SISTEMA, AREA_DE_WORK.LC04.LC04_DATA_SISTEMA);

            /*" -559- MOVE HOST-DATA-CORRENTE(9:2) TO W-DATA-DD-MM-AAAA-DD */
            _.Move(HOST_DATA_CORRENTE.Substring(9, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -560- MOVE HOST-DATA-CORRENTE(6:2) TO W-DATA-DD-MM-AAAA-MM */
            _.Move(HOST_DATA_CORRENTE.Substring(6, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -562- MOVE HOST-DATA-CORRENTE(1:4) TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(HOST_DATA_CORRENTE.Substring(1, 4), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -562- MOVE W-DATA-DD-MM-AAAA TO LC03-DATA-CORRENTE. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LC03.LC03_DATA_CORRENTE);

        }

        [StopWatch]
        /*" R010-LE-SISTEMAS-DB-SELECT-1 */
        public void R010_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -533- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN, :HOST-DATA-CORRENTE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

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
            /*" -570- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -576- PERFORM R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1 */

            R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1();

            /*" -579- MOVE EMPRESAS-NOME-EMPRESA TO LK-TITULO */
            _.Move(EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA, AREA_DE_WORK.WABEND.WABEND1.LK_LINK.LK_TITULO);

            /*" -581- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", AREA_DE_WORK.WABEND.WABEND1.LK_LINK);

            /*" -582- IF LK-RTCODE EQUAL ZEROS */

            if (AREA_DE_WORK.WABEND.WABEND1.LK_LINK.LK_RTCODE == 00)
            {

                /*" -583- MOVE LK-TITULO TO LC01-EMPRESA LC01-EMPRESA */
                _.Move(AREA_DE_WORK.WABEND.WABEND1.LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -584- ELSE */
            }
            else
            {


                /*" -585- DISPLAY 'PROBLEMA CALL V0EMPRESA' */
                _.Display($"PROBLEMA CALL V0EMPRESA");

                /*" -585- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R015-LE-MONTA-NOME-EMPRESA-DB-SELECT-1 */
        public void R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1()
        {
            /*" -576- EXEC SQL SELECT NOME_EMPRESA INTO :EMPRESAS-NOME-EMPRESA FROM SEGUROS.EMPRESAS WHERE COD_EMPRESA = 0 WITH UR END-EXEC. */

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
            /*" -593- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -696- PERFORM R020_LE_PROVISAO_DIA_DB_DECLARE_1 */

            R020_LE_PROVISAO_DIA_DB_DECLARE_1();

            /*" -698- PERFORM R020_LE_PROVISAO_DIA_DB_OPEN_1 */

            R020_LE_PROVISAO_DIA_DB_OPEN_1();

            /*" -700- IF SQLCODE < 0 */

            if (DB.SQLCODE < 0)
            {

                /*" -700- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R020-LE-PROVISAO-DIA-DB-DECLARE-1 */
        public void R020_LE_PROVISAO_DIA_DB_DECLARE_1()
        {
            /*" -696- EXEC SQL DECLARE PROVISAO CURSOR FOR SELECT W.PONTO_VENDA, P.NUM_APOL_SINISTRO, P.NUM_RESSARC AS NUM_ACORDO, P.NUM_PARCELA AS NUM_PARCELA, P.NUM_NOSSO_TITULO AS NUM_TITULO, P.DTH_VENCIMENTO AS DT_VENC_PARCELA, P.DTH_PAGAMENTO AS DT_PGTO_PARCELA, A.DTH_ACORDO AS DT_ACORDO, A.QTD_PARCELAS AS QTD_PARCELAS, H.OCORR_HISTORICO, H.VAL_OPERACAO AS VALOR_RECEBIDO, H.DATA_MOVIMENTO AS DATA_BAIXA_SIAS, H1.VAL_OPERACAO AS VALOR_PRELIB_REP, H1.COD_PRODUTO AS COD_PRODUTO, Z.DESCR_PRODUTO AS NOME_PRODUTO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_HISTORICO H1, SEGUROS.SI_RESSARC_ACORDO A, SEGUROS.SI_RESSARC_PARCELA P, SEGUROS.SINISTRO_HABIT01 W, SEGUROS.PRODUTO Z WHERE H.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND W.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H.COD_OPERACAO = 4100 AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H1.OCORR_HISTORICO = H.OCORR_HISTORICO AND H1.COD_OPERACAO = 4290 AND NOT EXISTS (SELECT X.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO X WHERE X.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO AND X.OCORR_HISTORICO = H1.OCORR_HISTORICO AND X.COD_OPERACAO IN ( 4291 , 4292 , 4293 )) AND P.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND P.OCORR_HISTORICO = H.OCORR_HISTORICO AND P.COD_OPERACAO = H.COD_OPERACAO AND A.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO AND A.NUM_RESSARC = P.NUM_RESSARC AND A.SEQ_RESSARC = P.SEQ_RESSARC AND Z.COD_PRODUTO = H1.COD_PRODUTO UNION ALL SELECT W.COD_AGENCIA, P.NUM_APOL_SINISTRO, P.NUM_RESSARC AS NUM_ACORDO, P.NUM_PARCELA AS NUM_PARCELA, P.NUM_NOSSO_TITULO AS NUM_TITULO, P.DTH_VENCIMENTO AS DT_VENC_PARCELA, P.DTH_PAGAMENTO AS DT_PGTO_PARCELA, A.DTH_ACORDO AS DT_ACORDO, A.QTD_PARCELAS AS QTD_PARCELAS, H.OCORR_HISTORICO, H.VAL_OPERACAO AS VALOR_RECEBIDO, H.DATA_MOVIMENTO AS DATA_BAIXA_SIAS, H1.VAL_OPERACAO AS VALOR_PRELIB_REP, H1.COD_PRODUTO AS COD_PRODUTO, Z.DESCR_PRODUTO AS NOME_PRODUTO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_HISTORICO H1, SEGUROS.SI_RESSARC_ACORDO A, SEGUROS.SI_RESSARC_PARCELA P, SEGUROS.SINISTRO_CRED_INT W, SEGUROS.PRODUTO Z WHERE H.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND W.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H.COD_OPERACAO = 4100 AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H1.OCORR_HISTORICO = H.OCORR_HISTORICO AND H1.COD_OPERACAO = 4290 AND NOT EXISTS (SELECT X.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO X WHERE X.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO AND X.OCORR_HISTORICO = H1.OCORR_HISTORICO AND X.COD_OPERACAO IN ( 4291 , 4292 , 4293 )) AND P.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND P.OCORR_HISTORICO = H.OCORR_HISTORICO AND P.COD_OPERACAO = H.COD_OPERACAO AND A.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO AND A.NUM_RESSARC = P.NUM_RESSARC AND A.SEQ_RESSARC = P.SEQ_RESSARC AND Z.COD_PRODUTO = H1.COD_PRODUTO ORDER BY 1 , 14 WITH UR END-EXEC. */
            PROVISAO = new SI0220B_PROVISAO(true);
            string GetQuery_PROVISAO()
            {
                var query = @$"SELECT W.PONTO_VENDA
							, 
							P.NUM_APOL_SINISTRO
							, 
							P.NUM_RESSARC AS NUM_ACORDO
							, 
							P.NUM_PARCELA AS NUM_PARCELA
							, 
							P.NUM_NOSSO_TITULO AS NUM_TITULO
							, 
							P.DTH_VENCIMENTO AS DT_VENC_PARCELA
							, 
							P.DTH_PAGAMENTO AS DT_PGTO_PARCELA
							, 
							A.DTH_ACORDO AS DT_ACORDO
							, 
							A.QTD_PARCELAS AS QTD_PARCELAS
							, 
							H.OCORR_HISTORICO
							, 
							H.VAL_OPERACAO AS VALOR_RECEBIDO
							, 
							H.DATA_MOVIMENTO AS DATA_BAIXA_SIAS
							, 
							H1.VAL_OPERACAO AS VALOR_PRELIB_REP
							, 
							H1.COD_PRODUTO AS COD_PRODUTO
							, 
							Z.DESCR_PRODUTO AS NOME_PRODUTO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_HISTORICO H1
							, 
							SEGUROS.SI_RESSARC_ACORDO A
							, 
							SEGUROS.SI_RESSARC_PARCELA P
							, 
							SEGUROS.SINISTRO_HABIT01 W
							, 
							SEGUROS.PRODUTO Z 
							WHERE H.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND W.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H.COD_OPERACAO = 4100 
							AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H1.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND H1.COD_OPERACAO = 4290 
							AND NOT EXISTS 
							(SELECT X.NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_HISTORICO X 
							WHERE X.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO 
							AND X.OCORR_HISTORICO = H1.OCORR_HISTORICO 
							AND X.COD_OPERACAO IN ( 4291
							, 4292
							, 4293 )) 
							AND P.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND P.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND P.COD_OPERACAO = H.COD_OPERACAO 
							AND A.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO 
							AND A.NUM_RESSARC = P.NUM_RESSARC 
							AND A.SEQ_RESSARC = P.SEQ_RESSARC 
							AND Z.COD_PRODUTO = H1.COD_PRODUTO 
							UNION ALL 
							SELECT W.COD_AGENCIA
							, 
							P.NUM_APOL_SINISTRO
							, 
							P.NUM_RESSARC AS NUM_ACORDO
							, 
							P.NUM_PARCELA AS NUM_PARCELA
							, 
							P.NUM_NOSSO_TITULO AS NUM_TITULO
							, 
							P.DTH_VENCIMENTO AS DT_VENC_PARCELA
							, 
							P.DTH_PAGAMENTO AS DT_PGTO_PARCELA
							, 
							A.DTH_ACORDO AS DT_ACORDO
							, 
							A.QTD_PARCELAS AS QTD_PARCELAS
							, 
							H.OCORR_HISTORICO
							, 
							H.VAL_OPERACAO AS VALOR_RECEBIDO
							, 
							H.DATA_MOVIMENTO AS DATA_BAIXA_SIAS
							, 
							H1.VAL_OPERACAO AS VALOR_PRELIB_REP
							, 
							H1.COD_PRODUTO AS COD_PRODUTO
							, 
							Z.DESCR_PRODUTO AS NOME_PRODUTO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_HISTORICO H1
							, 
							SEGUROS.SI_RESSARC_ACORDO A
							, 
							SEGUROS.SI_RESSARC_PARCELA P
							, 
							SEGUROS.SINISTRO_CRED_INT W
							, 
							SEGUROS.PRODUTO Z 
							WHERE H.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND W.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H.COD_OPERACAO = 4100 
							AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H1.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND H1.COD_OPERACAO = 4290 
							AND NOT EXISTS 
							(SELECT X.NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_HISTORICO X 
							WHERE X.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO 
							AND X.OCORR_HISTORICO = H1.OCORR_HISTORICO 
							AND X.COD_OPERACAO IN ( 4291
							, 4292
							, 4293 )) 
							AND P.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND P.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND P.COD_OPERACAO = H.COD_OPERACAO 
							AND A.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO 
							AND A.NUM_RESSARC = P.NUM_RESSARC 
							AND A.SEQ_RESSARC = P.SEQ_RESSARC 
							AND Z.COD_PRODUTO = H1.COD_PRODUTO 
							ORDER BY 1
							, 14";

                return query;
            }
            PROVISAO.GetQueryEvent += GetQuery_PROVISAO;

        }

        [StopWatch]
        /*" R020-LE-PROVISAO-DIA-DB-OPEN-1 */
        public void R020_LE_PROVISAO_DIA_DB_OPEN_1()
        {
            /*" -698- EXEC SQL OPEN PROVISAO END-EXEC. */

            PROVISAO.Open();

        }

        [StopWatch]
        /*" R110-LE-CONTRATO-CLIENTE-DB-DECLARE-1 */
        public void R110_LE_CONTRATO_CLIENTE_DB_DECLARE_1()
        {
            /*" -898- EXEC SQL DECLARE CREDITO CURSOR FOR SELECT B.PROPRIET, B.CGCCPF, MIN(B.NUM_FATURA), MIN(B.DATA_INIVIGENCIA), MIN(B.TIMESTAMP) FROM SEGUROS.SINISTRO_CRED_INT A, SEGUROS.APOLICE_CREDITO B WHERE A.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND B.COD_SUREG = A.COD_SUREG AND B.COD_AGENCIA = A.COD_AGENCIA AND B.COD_OPERACAO = A.COD_OPERACAO AND B.NUM_CONTRATO = A.NUM_CONTRATO AND B.CONTRATO_DIGITO = A.CONTRATO_DIGITO GROUP BY B.PROPRIET, B.CGCCPF ORDER BY B.PROPRIET, B.CGCCPF WITH UR END-EXEC. */
            CREDITO = new SI0220B_CREDITO(false);
            string GetQuery_CREDITO()
            {
                var query = @$"SELECT B.PROPRIET
							, 
							B.CGCCPF
							, 
							MIN(B.NUM_FATURA)
							, 
							MIN(B.DATA_INIVIGENCIA)
							, 
							MIN(B.TIMESTAMP) 
							FROM SEGUROS.SINISTRO_CRED_INT A
							, 
							SEGUROS.APOLICE_CREDITO B 
							WHERE A.NUM_APOL_SINISTRO = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO} 
							AND B.COD_SUREG = A.COD_SUREG 
							AND B.COD_AGENCIA = A.COD_AGENCIA 
							AND B.COD_OPERACAO = A.COD_OPERACAO 
							AND B.NUM_CONTRATO = A.NUM_CONTRATO 
							AND B.CONTRATO_DIGITO = A.CONTRATO_DIGITO 
							GROUP BY B.PROPRIET
							, B.CGCCPF 
							ORDER BY B.PROPRIET
							, B.CGCCPF";

                return query;
            }
            CREDITO.GetQueryEvent += GetQuery_CREDITO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R021-FETCH-PROVISAO */
        private void R021_FETCH_PROVISAO(bool isPerform = false)
        {
            /*" -709- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -725- PERFORM R021_FETCH_PROVISAO_DB_FETCH_1 */

            R021_FETCH_PROVISAO_DB_FETCH_1();

            /*" -728- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -730- ADD 1 TO W-QTD-MOVIMENTO-PROVISAO. */
                AREA_DE_WORK.W_QTD_MOVIMENTO_PROVISAO.Value = AREA_DE_WORK.W_QTD_MOVIMENTO_PROVISAO + 1;
            }


            /*" -731- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -733- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -734- MOVE 'SIM' TO WFIM-PROVISAO */
                    _.Move("SIM", AREA_DE_WORK.WFIM_PROVISAO);

                    /*" -735- ELSE */
                }
                else
                {


                    /*" -736- DISPLAY 'ERRO NO FETCH DA COBRANCA' */
                    _.Display($"ERRO NO FETCH DA COBRANCA");

                    /*" -736- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R021-FETCH-PROVISAO-DB-FETCH-1 */
        public void R021_FETCH_PROVISAO_DB_FETCH_1()
        {
            /*" -725- EXEC SQL FETCH PROVISAO INTO :HOST-COD-AGENCIA-CONTRATO, :SI111-NUM-APOL-SINISTRO, :SI111-NUM-RESSARC, :SI111-NUM-PARCELA, :SI111-NUM-NOSSO-TITULO, :SI111-DTH-VENCIMENTO, :SI111-DTH-PAGAMENTO, :SI112-DTH-ACORDO, :SI112-QTD-PARCELAS, :SINISHIS-OCORR-HISTORICO, :HOST-VALOR-RECEBIDO, :HOST-DATA-BAIXA-SIAS, :HOST-VALOR-PRELIB-REPASSE, :SINISHIS-COD-PRODUTO, :PRODUTO-DESCR-PRODUTO END-EXEC. */

            if (PROVISAO.Fetch())
            {
                _.Move(PROVISAO.HOST_COD_AGENCIA_CONTRATO, HOST_COD_AGENCIA_CONTRATO);
                _.Move(PROVISAO.SI111_NUM_APOL_SINISTRO, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO);
                _.Move(PROVISAO.SI111_NUM_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC);
                _.Move(PROVISAO.SI111_NUM_PARCELA, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA);
                _.Move(PROVISAO.SI111_NUM_NOSSO_TITULO, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO);
                _.Move(PROVISAO.SI111_DTH_VENCIMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_VENCIMENTO);
                _.Move(PROVISAO.SI111_DTH_PAGAMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO);
                _.Move(PROVISAO.SI112_DTH_ACORDO, SI112.DCLSI_RESSARC_ACORDO.SI112_DTH_ACORDO);
                _.Move(PROVISAO.SI112_QTD_PARCELAS, SI112.DCLSI_RESSARC_ACORDO.SI112_QTD_PARCELAS);
                _.Move(PROVISAO.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(PROVISAO.HOST_VALOR_RECEBIDO, HOST_VALOR_RECEBIDO);
                _.Move(PROVISAO.HOST_DATA_BAIXA_SIAS, HOST_DATA_BAIXA_SIAS);
                _.Move(PROVISAO.HOST_VALOR_PRELIB_REPASSE, HOST_VALOR_PRELIB_REPASSE);
                _.Move(PROVISAO.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
                _.Move(PROVISAO.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-PROVISAO */
        private void R100_PROCESSA_PROVISAO(bool isPerform = false)
        {
            /*" -744- PERFORM R110-LE-CONTRATO-CLIENTE THRU R110-EXIT. */

            R110_LE_CONTRATO_CLIENTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


            /*" -745- MOVE SI111-NUM-APOL-SINISTRO TO LD01-NUM-APOL-SINISTRO. */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO, AREA_DE_WORK.LD01.LD01_NUM_APOL_SINISTRO);

            /*" -746- MOVE SI111-NUM-RESSARC TO LD01-NUM-ACORDO. */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC, AREA_DE_WORK.LD01.LD01_NUM_ACORDO);

            /*" -747- MOVE SI112-DTH-ACORDO TO W-DATA-AAAA-MM-DD */
            _.Move(SI112.DCLSI_RESSARC_ACORDO.SI112_DTH_ACORDO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -748- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -749- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -750- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -752- MOVE W-DATA-DD-MM-AAAA TO LD01-DATA-ACORDO */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LD01.LD01_DATA_ACORDO);

            /*" -754- MOVE SI111-NUM-PARCELA TO LD01-NUM-PARCELA. */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA, AREA_DE_WORK.LD01.LD01_NUM_PARCELA);

            /*" -755- MOVE SI111-DTH-VENCIMENTO TO W-DATA-AAAA-MM-DD */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_VENCIMENTO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -756- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -757- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -758- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -760- MOVE W-DATA-DD-MM-AAAA TO LD01-DATA-VENCIMENTO. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LD01.LD01_DATA_VENCIMENTO);

            /*" -761- MOVE SI111-DTH-PAGAMENTO TO W-DATA-AAAA-MM-DD */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -762- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -763- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -764- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -766- MOVE W-DATA-DD-MM-AAAA TO LD01-DATA-PAGAMENTO. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LD01.LD01_DATA_PAGAMENTO);

            /*" -767- MOVE SI112-QTD-PARCELAS TO LD01-QTD-TOTAL-PARCELAS */
            _.Move(SI112.DCLSI_RESSARC_ACORDO.SI112_QTD_PARCELAS, AREA_DE_WORK.LD01.LD01_QTD_TOTAL_PARCELAS);

            /*" -769- MOVE HOST-VALOR-PRELIB-REPASSE TO LD01-VALOR-REPASSE . */
            _.Move(HOST_VALOR_PRELIB_REPASSE, AREA_DE_WORK.LD01.LD01_VALOR_REPASSE);

            /*" -770- MOVE SINISHIS-DATA-MOVIMENTO TO W-DATA-AAAA-MM-DD */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -771- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -772- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -773- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -775- MOVE W-DATA-DD-MM-AAAA TO LD01-DATA-PROCESSAMENTO. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LD01.LD01_DATA_PROCESSAMENTO);

            /*" -777- MOVE HOST-VALOR-RECEBIDO TO LD01-VALOR-RECEBIDO */
            _.Move(HOST_VALOR_RECEBIDO, AREA_DE_WORK.LD01.LD01_VALOR_RECEBIDO);

            /*" -778- MOVE HOST-DATA-BAIXA-SIAS TO W-DATA-AAAA-MM-DD */
            _.Move(HOST_DATA_BAIXA_SIAS, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -779- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -780- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -781- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -783- MOVE W-DATA-DD-MM-AAAA TO LD01-DATA-PAGAMENTO. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LD01.LD01_DATA_PAGAMENTO);

            /*" -785- MOVE HOST-VALOR-PRELIB-REPASSE TO LD01-VALOR-REPASSE */
            _.Move(HOST_VALOR_PRELIB_REPASSE, AREA_DE_WORK.LD01.LD01_VALOR_REPASSE);

            /*" -786- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-AAAA-MM-DD */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -787- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -788- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -789- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -794- MOVE W-DATA-DD-MM-AAAA TO LD01-DATA-PROCESSAMENTO. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LD01.LD01_DATA_PROCESSAMENTO);

            /*" -795- MOVE SINISHIS-COD-PRODUTO TO LD01-COD-PRODUTO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO, AREA_DE_WORK.LD01.LD01_COD_PRODUTO);

            /*" -797- MOVE PRODUTO-DESCR-PRODUTO TO LD01-NOME-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, AREA_DE_WORK.LD01.LD01_NOME_PRODUTO);

            /*" -799- MOVE SINISHIS-OCORR-HISTORICO TO LD01-OCORR-HISTORICO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, AREA_DE_WORK.LD01.LD01_OCORR_HISTORICO);

            /*" -801- MOVE ALL '*' TO LD01-NOME-AGENCIA-CONTRATO. */
            _.MoveAll("*", AREA_DE_WORK.LD01.LD01_NOME_AGENCIA_CONTRATO);

            /*" -802- MOVE HOST-COD-AGENCIA-CONTRATO TO AGENCCEF-COD-AGENCIA. */
            _.Move(HOST_COD_AGENCIA_CONTRATO, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);

            /*" -804- PERFORM R130-LE-AGENCIA-CONTRATO THRU R130-EXIT. */

            R130_LE_AGENCIA_CONTRATO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/


            /*" -805- MOVE AGENCCEF-COD-AGENCIA TO LD01-COD-AGENCIA-CONTRATO. */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA, AREA_DE_WORK.LD01.LD01_COD_AGENCIA_CONTRATO);

            /*" -807- MOVE AGENCCEF-NOME-AGENCIA TO LD01-NOME-AGENCIA-CONTRATO. */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA, AREA_DE_WORK.LD01.LD01_NOME_AGENCIA_CONTRATO);

            /*" -809- WRITE REGISTRO-RETORNO FROM LD01. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REGISTRO_RETORNO);

            REG_RET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

            /*" -809- PERFORM R021-FETCH-PROVISAO THRU R021-EXIT. */

            R021_FETCH_PROVISAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R110-LE-CONTRATO-CLIENTE */
        private void R110_LE_CONTRATO_CLIENTE(bool isPerform = false)
        {
            /*" -817- MOVE 0 TO SINIHAB1-PONTO-VENDA SINCREIN-COD-AGENCIA. */
            _.Move(0, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA);

            /*" -819- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -833- PERFORM R110_LE_CONTRATO_CLIENTE_DB_SELECT_1 */

            R110_LE_CONTRATO_CLIENTE_DB_SELECT_1();

            /*" -836- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -837- MOVE SINIHAB1-OPERACAO TO W-MATCON-OPERACAO */
                _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO, AREA_DE_WORK.W_MATCON_CONTRATO.W_MATCON_OPERACAO);

                /*" -838- MOVE SINIHAB1-PONTO-VENDA TO W-MATCON-AGENCIA */
                _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, AREA_DE_WORK.W_MATCON_CONTRATO.W_MATCON_AGENCIA);

                /*" -839- MOVE SINIHAB1-NUM-CONTRATO TO W-MATCON-NUM-CONTRATO */
                _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO, AREA_DE_WORK.W_MATCON_CONTRATO.W_MATCON_NUM_CONTRATO);

                /*" -840- MOVE W-MATCON-CONTRATO TO LD01-NUM-CONTRATO */
                _.Move(AREA_DE_WORK.W_MATCON_CONTRATO, AREA_DE_WORK.LD01.LD01_NUM_CONTRATO);

                /*" -841- MOVE SINIHAB1-NOME-SEGURADO TO LD01-NOME-SEGURADO */
                _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO, AREA_DE_WORK.LD01.LD01_NOME_SEGURADO);

                /*" -842- MOVE SINIHAB1-CGCCPF TO LD01-CGCCPF-SEGURADO */
                _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_CGCCPF, AREA_DE_WORK.LD01.LD01_CGCCPF_SEGURADO);

                /*" -844- GO TO R110-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/ //GOTO
                return;
            }


            /*" -845- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -846- DISPLAY 'SI0220B - ERRO ACESSO SINISTRO_HABIT01' */
                _.Display($"SI0220B - ERRO ACESSO SINISTRO_HABIT01");

                /*" -848- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -850- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -864- PERFORM R110_LE_CONTRATO_CLIENTE_DB_SELECT_2 */

            R110_LE_CONTRATO_CLIENTE_DB_SELECT_2();

            /*" -867- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -868- DISPLAY 'SI0220B - ERRO ACESSO SINISTRO_CRED_INT' */
                _.Display($"SI0220B - ERRO ACESSO SINISTRO_CRED_INT");

                /*" -870- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -871- MOVE SINCREIN-COD-SUREG TO W-CREDITO-COD-SUREG */
            _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG, AREA_DE_WORK.W_CREDITO_CONTRATO.W_CREDITO_COD_SUREG);

            /*" -872- MOVE SINCREIN-COD-AGENCIA TO W-CREDITO-COD-AGENCIA */
            _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA, AREA_DE_WORK.W_CREDITO_CONTRATO.W_CREDITO_COD_AGENCIA);

            /*" -873- MOVE SINCREIN-COD-OPERACAO TO W-CREDITO-COD-OPERACAO */
            _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO, AREA_DE_WORK.W_CREDITO_CONTRATO.W_CREDITO_COD_OPERACAO);

            /*" -874- MOVE SINCREIN-NUM-CONTRATO TO W-CREDITO-NUM-CONTRATO */
            _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO, AREA_DE_WORK.W_CREDITO_CONTRATO.W_CREDITO_NUM_CONTRATO);

            /*" -875- MOVE SINCREIN-CONTRATO-DIGITO TO W-CREDITO-CONTRATO-DIGITO */
            _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO, AREA_DE_WORK.W_CREDITO_CONTRATO.W_CREDITO_CONTRATO_DIGITO);

            /*" -877- MOVE W-CREDITO-CONTRATO TO LD01-NUM-CONTRATO. */
            _.Move(AREA_DE_WORK.W_CREDITO_CONTRATO, AREA_DE_WORK.LD01.LD01_NUM_CONTRATO);

            /*" -879- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -898- PERFORM R110_LE_CONTRATO_CLIENTE_DB_DECLARE_1 */

            R110_LE_CONTRATO_CLIENTE_DB_DECLARE_1();

            /*" -900- PERFORM R110_LE_CONTRATO_CLIENTE_DB_OPEN_1 */

            R110_LE_CONTRATO_CLIENTE_DB_OPEN_1();

            /*" -903- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -904- MOVE '009' TO WNR-EXEC-SQL */
                _.Move("009", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

                /*" -905- DISPLAY 'ERRO NO OPEN DA CREDITO' */
                _.Display($"ERRO NO OPEN DA CREDITO");

                /*" -906- DISPLAY 'SINISTRO = ' SI111-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -908- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -910- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -916- PERFORM R110_LE_CONTRATO_CLIENTE_DB_FETCH_1 */

            R110_LE_CONTRATO_CLIENTE_DB_FETCH_1();

            /*" -919- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -920- MOVE APOLICRE-PROPRIET TO LD01-NOME-SEGURADO */
                _.Move(APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET, AREA_DE_WORK.LD01.LD01_NOME_SEGURADO);

                /*" -922- MOVE APOLICRE-CGCCPF TO LD01-CGCCPF-SEGURADO. */
                _.Move(APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_CGCCPF, AREA_DE_WORK.LD01.LD01_CGCCPF_SEGURADO);
            }


            /*" -923- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -924- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -925- PERFORM R120-BUSCA-CLIENTE */

                    R120_BUSCA_CLIENTE(true);

                    /*" -926- ELSE */
                }
                else
                {


                    /*" -928- DISPLAY 'PROBLEMAS NO FETCH A APOLICE_CREDITO ... ' ' ' SI111-NUM-APOL-SINISTRO */

                    $"PROBLEMAS NO FETCH A APOLICE_CREDITO ...  {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}"
                    .Display();

                    /*" -930- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -930- PERFORM R110_LE_CONTRATO_CLIENTE_DB_CLOSE_1 */

            R110_LE_CONTRATO_CLIENTE_DB_CLOSE_1();

            /*" -933- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -934- MOVE '011' TO WNR-EXEC-SQL */
                _.Move("011", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

                /*" -935- DISPLAY 'ERRO NO CLOSE DA CREDITO' */
                _.Display($"ERRO NO CLOSE DA CREDITO");

                /*" -936- DISPLAY 'SINISTRO = ' SI111-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -936- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R110-LE-CONTRATO-CLIENTE-DB-SELECT-1 */
        public void R110_LE_CONTRATO_CLIENTE_DB_SELECT_1()
        {
            /*" -833- EXEC SQL SELECT OPERACAO, PONTO_VENDA, NUM_CONTRATO, NOME_SEGURADO, CGCCPF INTO :SINIHAB1-OPERACAO, :SINIHAB1-PONTO-VENDA, :SINIHAB1-NUM-CONTRATO, :SINIHAB1-NOME-SEGURADO, :SINIHAB1-CGCCPF FROM SEGUROS.SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r110_LE_CONTRATO_CLIENTE_DB_SELECT_1_Query1 = new R110_LE_CONTRATO_CLIENTE_DB_SELECT_1_Query1()
            {
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R110_LE_CONTRATO_CLIENTE_DB_SELECT_1_Query1.Execute(r110_LE_CONTRATO_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIHAB1_OPERACAO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO);
                _.Move(executed_1.SINIHAB1_PONTO_VENDA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);
                _.Move(executed_1.SINIHAB1_NUM_CONTRATO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO);
                _.Move(executed_1.SINIHAB1_NOME_SEGURADO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO);
                _.Move(executed_1.SINIHAB1_CGCCPF, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R110-LE-CONTRATO-CLIENTE-DB-OPEN-1 */
        public void R110_LE_CONTRATO_CLIENTE_DB_OPEN_1()
        {
            /*" -900- EXEC SQL OPEN CREDITO END-EXEC. */

            CREDITO.Open();

        }

        [StopWatch]
        /*" R110-LE-CONTRATO-CLIENTE-DB-FETCH-1 */
        public void R110_LE_CONTRATO_CLIENTE_DB_FETCH_1()
        {
            /*" -916- EXEC SQL FETCH CREDITO INTO :APOLICRE-PROPRIET, :APOLICRE-CGCCPF, :APOLICRE-NUM-FATURA, :APOLICRE-DATA-INIVIGENCIA, :APOLICRE-TIMESTAMP END-EXEC. */

            if (CREDITO.Fetch())
            {
                _.Move(CREDITO.APOLICRE_PROPRIET, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET);
                _.Move(CREDITO.APOLICRE_CGCCPF, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_CGCCPF);
                _.Move(CREDITO.APOLICRE_NUM_FATURA, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_NUM_FATURA);
                _.Move(CREDITO.APOLICRE_DATA_INIVIGENCIA, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_DATA_INIVIGENCIA);
                _.Move(CREDITO.APOLICRE_TIMESTAMP, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_TIMESTAMP);
            }

        }

        [StopWatch]
        /*" R110-LE-CONTRATO-CLIENTE-DB-CLOSE-1 */
        public void R110_LE_CONTRATO_CLIENTE_DB_CLOSE_1()
        {
            /*" -930- EXEC SQL CLOSE CREDITO END-EXEC. */

            CREDITO.Close();

        }

        [StopWatch]
        /*" R110-LE-CONTRATO-CLIENTE-DB-SELECT-2 */
        public void R110_LE_CONTRATO_CLIENTE_DB_SELECT_2()
        {
            /*" -864- EXEC SQL SELECT COD_SUREG , COD_AGENCIA , COD_OPERACAO , NUM_CONTRATO , CONTRATO_DIGITO INTO :SINCREIN-COD-SUREG, :SINCREIN-COD-AGENCIA, :SINCREIN-COD-OPERACAO, :SINCREIN-NUM-CONTRATO, :SINCREIN-CONTRATO-DIGITO FROM SEGUROS.SINISTRO_CRED_INT WHERE NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1 = new R110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1()
            {
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1.Execute(r110_LE_CONTRATO_CLIENTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINCREIN_COD_SUREG, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG);
                _.Move(executed_1.SINCREIN_COD_AGENCIA, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA);
                _.Move(executed_1.SINCREIN_COD_OPERACAO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO);
                _.Move(executed_1.SINCREIN_NUM_CONTRATO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO);
                _.Move(executed_1.SINCREIN_CONTRATO_DIGITO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO);
            }


        }

        [StopWatch]
        /*" R120-BUSCA-CLIENTE */
        private void R120_BUSCA_CLIENTE(bool isPerform = false)
        {
            /*" -944- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -953- PERFORM R120_BUSCA_CLIENTE_DB_SELECT_1 */

            R120_BUSCA_CLIENTE_DB_SELECT_1();

            /*" -956- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -957- DISPLAY '*** SI0220B - ERRO ACESSO CLIENTES ***' */
                _.Display($"*** SI0220B - ERRO ACESSO CLIENTES ***");

                /*" -958- DISPLAY '*** SINISTRO = ' SI111-NUM-APOL-SINISTRO */
                _.Display($"*** SINISTRO = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -960- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -961- MOVE CLIENTES-NOME-RAZAO TO LD01-NOME-SEGURADO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.LD01.LD01_NOME_SEGURADO);

            /*" -961- MOVE CLIENTES-CGCCPF TO LD01-CGCCPF-SEGURADO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AREA_DE_WORK.LD01.LD01_CGCCPF_SEGURADO);

        }

        [StopWatch]
        /*" R120-BUSCA-CLIENTE-DB-SELECT-1 */
        public void R120_BUSCA_CLIENTE_DB_SELECT_1()
        {
            /*" -953- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES A, SEGUROS.SINISTRO_ITEM B WHERE B.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND A.COD_CLIENTE = B.COD_CLIENTE WITH UR END-EXEC. */

            var r120_BUSCA_CLIENTE_DB_SELECT_1_Query1 = new R120_BUSCA_CLIENTE_DB_SELECT_1_Query1()
            {
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R120_BUSCA_CLIENTE_DB_SELECT_1_Query1.Execute(r120_BUSCA_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R130-LE-AGENCIA-CONTRATO */
        private void R130_LE_AGENCIA_CONTRATO(bool isPerform = false)
        {
            /*" -969- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -977- PERFORM R130_LE_AGENCIA_CONTRATO_DB_SELECT_1 */

            R130_LE_AGENCIA_CONTRATO_DB_SELECT_1();

            /*" -980- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -981- DISPLAY '*** SI0220B - ERRO ACESSO AGENCIA_CEF ***' */
                _.Display($"*** SI0220B - ERRO ACESSO AGENCIA_CEF ***");

                /*" -982- DISPLAY '*** SINISTRO = ' SI111-NUM-APOL-SINISTRO */
                _.Display($"*** SINISTRO = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -982- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R130-LE-AGENCIA-CONTRATO-DB-SELECT-1 */
        public void R130_LE_AGENCIA_CONTRATO_DB_SELECT_1()
        {
            /*" -977- EXEC SQL SELECT COD_AGENCIA, NOME_AGENCIA INTO :AGENCCEF-COD-AGENCIA, :AGENCCEF-NOME-AGENCIA FROM SEGUROS.AGENCIAS_CEF WHERE COD_AGENCIA = :AGENCCEF-COD-AGENCIA WITH UR END-EXEC. */

            var r130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1 = new R130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1()
            {
                AGENCCEF_COD_AGENCIA = AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA.ToString(),
            };

            var executed_1 = R130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1.Execute(r130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCCEF_COD_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);
                _.Move(executed_1.AGENCCEF_NOME_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -990- CLOSE REG-RET. */
            REG_RET.Close();

            /*" -991- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -992- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLERRMC);

            /*" -993- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLERRMC);

            /*" -994- MOVE SQLCAID TO WSQLCAID . */
            _.Move(DB.SQLCAID, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCAID);

            /*" -995- MOVE SQLCABC TO WSQLCABC . */
            _.Move(DB.SQLCABC, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCABC);

            /*" -996- MOVE SQLCODE TO WSQLCODE . */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -998- MOVE SQLERRP TO WSQLERRP . */
            _.Move(DB.SQLERRP, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLERRP);

            /*" -999- MOVE SQLWARN TO WSQLWARN. */
            _.Move(DB.SQLWARN, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLWARN);

            /*" -1000- DISPLAY ' ' */
            _.Display($" ");

            /*" -1001- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -1002- DISPLAY ' ' */
            _.Display($" ");

            /*" -1003- DISPLAY WABEND1. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1);

            /*" -1004- DISPLAY WABEND2. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2);

            /*" -1005- DISPLAY WABEND3. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3);

            /*" -1005- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1006- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1008- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1008- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_EXIT*/

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK */
        private void R10010199_MENSAGEM_LOCK(bool isPerform = false)
        {
            /*" -1016- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -1019- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -1022- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -1025- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      A T E N C A O       S R.   O P E R A D O R         *WITHNOADVANCING"
            .Display();

            /*" -1028- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -1031- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1034- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                   PROGRAMA ABENDADO                     *WITHNOADVANCING"
            .Display();

            /*" -1037- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                 PROVAVELMENTE POR LOCK                  *WITHNOADVANCING"
            .Display();

            /*" -1040- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' UPON CONSOLE WITH NO ADVANCING. */

            $"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *WITHNOADVANCING"
            .Display();

            /*" -1043- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE WITH NO ADVANCING. */

            $"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *WITHNOADVANCING"
            .Display();

            /*" -1046- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1049- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *WITHNOADVANCING"
            .Display();

            /*" -1052- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1055- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1058- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE WITH NO ADVANCING. */

            $"*     SQLCODE DO ABEND ....... {AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE}WITHNOADVANCING"
            .Display();

            /*" -1061- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1067- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -1069- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1071- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1073- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -1075- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1077- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1079- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -1081- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -1083- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -1085- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -1087- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1089- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -1091- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1093- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1095- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1097- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE}");

            /*" -1099- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1099- GO TO R9999-00-ROT-ERRO. */

            R9999_00_ROT_ERRO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010199_EXIT*/
    }
}