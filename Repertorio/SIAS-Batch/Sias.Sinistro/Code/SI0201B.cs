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
using Sias.Sinistro.DB2.SI0201B;

namespace Code
{
    public class SI0201B
    {
        public bool IsCall { get; set; }

        public SI0201B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO/RESSARCIMENTO             *      */
        /*"      *   PROGRAMA ...............  SI0201B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER                             *      */
        /*"      *   PROGRAMADOR ............  HEIDER                             *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO/2002                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERACAO DO MOVIMENTO DE SINISTRO          */
        /*"      *         PARA O SISTEMA DE RESSARCIMENTO => CREDITO INTERNO            */
        /*"      *                                                                       */
        /*"      * ATENCAO - ESTA VERSAO PASSA A VIGORAR A PARTIR DE 24/11/05            */
        /*"      *                                                                       */
        /*"      *   A PARTIR DE 24/11/05 - PASSOU A ENVIA O VALOR TOTAL A SER           */
        /*"      *   RESSARCIDO PARA O RESSARCIMENTOWEB. O RESSARCIMENTOWEB PARA         */
        /*"      *   DE EFETUAR QUALQUER ACRESCIMO AO VALOR A ELE INFORMADO              */
        /*"      *--------------------------------------------------------------*        */
        /*"      *  M A N U T E N C A O  ( O R D E M  D E C R E S C E N T E )   *        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  Avaliado pelo projeto JV1 em 15/01/2019                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.07  *   VERSAO 07 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.07    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.06  * CADMUS 33880 - 10/12/2009 - PROCURAR: V.06                     *      */
        /*"      *                                                                *      */
        /*"      * ANALISTA: HEIDER COELHO                                        *      */
        /*"      * 1- PARA CADA EXECUCAO DIARIA SELECIONAR TODOS OS SINISTROS     *      */
        /*"      *    INDENIZADOS NOS ULTIMOS 5 DIAS UTEIS A DATA_MOV_ABERTO DO   *      */
        /*"      *    SINISTRO => OU <= SE HOUVER ESTORNO                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.05  * CADMUS 33.846 E 34286 - 10/12/2009 - PROCURAR: V.05            *      */
        /*"      *                                                                *      */
        /*"      * ANALISTA: HEIDER COELHO                                        *      */
        /*"      * 1- CONSIDERAR ZERO NO % DE FRANQUIA SE A OPERACAO DO CONTRATO  *      */
        /*"      *    DE CREDITO NAO ESTIVER DEFINIDA                             *      */
        /*"      * 2- EXCLUIR DO PROCESSAMENTO TODOS OS MOVIMENTOS GERADOS PELO   *      */
        /*"      *    PROGRAMA SI0170B - AJUSTE CONTABIL DO PREMIO DE MATCON      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.04  * CADMUS 31.731 - 27/10/2009 - PROCURAR: V.04                    *      */
        /*"      * ANALISTA: HEIDER COELHO                                        *      */
        /*"      *    ALTERACAO DAS DATAS DE SELECAO DOS SINISTROS INDENIZADOS    *      */
        /*"      *    PARA CARGA NO RESSARCIMENTOWEB                              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 30/05/2005 - PRODEXTER                                         *      */
        /*"      * (1) SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO *      */
        /*"      * (2) SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A   *      */
        /*"      * SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 06/06/2006 - ALEXIS VEAS ITURRIAGA                             *      */
        /*"      * INCLUIDO OS CAMPOS DE PREMIO, FRANQUIA, RESSARCIMENTO E        *      */
        /*"      * VALOR FINANCEIRO.                                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  19/10/2010 - CADIMUS 47494/2010 - CIRCULAR 395:               *      */
        /*"      *               SUPORTAR O NOVO RAMO DE COMERCIALIZA��O DO       *      */
        /*"      *               HABITACIONAL, FORA DO SFH; SUPORTAR O NOVO       *      */
        /*"      *               RAMO DE COMERCIALIZA��O DO SEGURO GARANTIA       *      */
        /*"      *               CONSTRUTOR - SETOR P�BLICO E PRIVADO E SU-       *      */
        /*"      *               PORTAR NOVOS PRODUTOS QUE SER�O CRIADOS NO       *      */
        /*"      *               RAMO 48 DOS CONTRATOS DO CONS�RCIO.              *      */
        /*"      *                                                                *      */
        /*"      *               MARCELO NEVES (TE41729)   PROCURAR: C395         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0201A { get; set; } = new FileBasis(new PIC("X", "600", "X(600)"));

        public FileBasis SI0201A
        {
            get
            {
                _.Move(REG_SI0201A, _SI0201A); VarBasis.RedefinePassValue(REG_SI0201A, _SI0201A, REG_SI0201A); return _SI0201A;
            }
        }
        /*"01  REG-SI0201A.*/
        public SI0201B_REG_SI0201A REG_SI0201A { get; set; } = new SI0201B_REG_SI0201A();
        public class SI0201B_REG_SI0201A : VarBasis
        {
            /*"    05 REG-NUM-APOL-SINISTRO         PIC X(13).*/
            public StringBasis REG_NUM_APOL_SINISTRO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
            /*"    05 REG-SUREG                     PIC 9(03).*/
            public IntBasis REG_SUREG { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 REG-AGENCIA                   PIC 9(04).*/
            public IntBasis REG_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 REG-OPERACAO                  PIC 9(04).*/
            public IntBasis REG_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 REG-CONTRATO                  PIC 9(13).*/
            public IntBasis REG_CONTRATO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    05 REG-DV                        PIC 9(02).*/
            public IntBasis REG_DV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 REG-NUM-APOLICE               PIC 9(13).*/
            public IntBasis REG_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    05 REG-NUM-PRODUTO               PIC 9(04).*/
            public IntBasis REG_NUM_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 REG-NUM-FONTE-SINISTRO        PIC 9(03).*/
            public IntBasis REG_NUM_FONTE_SINISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 REG-CIDADE-SINISTRO           PIC X(40).*/
            public StringBasis REG_CIDADE_SINISTRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 REG-UF-SINISTRO               PIC X(02).*/
            public StringBasis REG_UF_SINISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 REG-VALOR-FRANQUIA            PIC 9(13)V99+.*/
            public DoubleBasis REG_VALOR_FRANQUIA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99+."), 2);
            /*"    05 REG-DATA-INDENIZACAO          PIC X(10).*/
            public StringBasis REG_DATA_INDENIZACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 REG-VALOR-INDENIZACAO         PIC 9(13)V99+.*/
            public DoubleBasis REG_VALOR_INDENIZACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99+."), 2);
            /*"    05 REG-MOEDA-INDENIZACAO         PIC 9(01).*/
            public IntBasis REG_MOEDA_INDENIZACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"    05 REG-NOME-SEGURADO             PIC X(40).*/
            public StringBasis REG_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 REG-NOME-DEVEDOR              PIC X(40).*/
            public StringBasis REG_NOME_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 REG-SEXO-DEVEDOR              PIC X(01).*/
            public StringBasis REG_SEXO_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 REG-LOGRADOURO-DEVEDOR        PIC X(40).*/
            public StringBasis REG_LOGRADOURO_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 REG-BAIRRO-DEVEDOR            PIC X(40).*/
            public StringBasis REG_BAIRRO_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 REG-CIDADE-DEVEDOR            PIC X(40).*/
            public StringBasis REG_CIDADE_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 REG-UF-DEVEDOR                PIC X(02).*/
            public StringBasis REG_UF_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 REG-CEP-DEVEDOR               PIC 9(08).*/
            public IntBasis REG_CEP_DEVEDOR { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    05 REG-TELEF-RESID-DEVEDOR       PIC X(10).*/
            public StringBasis REG_TELEF_RESID_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 REG-TELEF-TRAB-DEVEDOR        PIC X(10).*/
            public StringBasis REG_TELEF_TRAB_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 REG-TELEF-FAX-DEVEDOR         PIC X(10).*/
            public StringBasis REG_TELEF_FAX_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 REG-CIC-DEVEDOR               PIC 9(15).*/
            public IntBasis REG_CIC_DEVEDOR { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"    05 REG-IDENTIDADE-DEVEDOR        PIC X(20).*/
            public StringBasis REG_IDENTIDADE_DEVEDOR { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"    05 REG-DATA-OCORR-SINISTRO       PIC X(10).*/
            public StringBasis REG_DATA_OCORR_SINISTRO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 REG-OCORR-HISTORICO           PIC 9(03).*/
            public IntBasis REG_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 REG-COD-OPERACAO              PIC 9(04).*/
            public IntBasis REG_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 REG-NATUREZA-SINISTRO         PIC X(40).*/
            public StringBasis REG_NATUREZA_SINISTRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 REG-DESCR-CAUSA-SINISTRO      PIC X(40).*/
            public StringBasis REG_DESCR_CAUSA_SINISTRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 REG-AGENCIA-INDENIZACAO       PIC 9(04).*/
            public IntBasis REG_AGENCIA_INDENIZACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 REG-NUM-PROTOCOLO-SINI        PIC 9(09).*/
            public IntBasis REG_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05 REG-VALOR-RESSARCIMENTO       PIC 9(13)V99+.*/
            public DoubleBasis REG_VALOR_RESSARCIMENTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99+."), 2);
            /*"    05 REG-VALOR-PAGO-FINANCEIRO     PIC 9(13)V99+.*/
            public DoubleBasis REG_VALOR_PAGO_FINANCEIRO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99+."), 2);
            /*"    05 REG-VALOR-PREMIO              PIC 9(13)V99+.*/
            public DoubleBasis REG_VALOR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99+."), 2);
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-VAL-OPERACAO-SGTO         PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis HOST_VAL_OPERACAO_SGTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-CURRENT-DATE              PIC  X(10)    VALUE SPACES.*/
        public StringBasis HOST_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-DATA-HOJE-MENOS-05-DIAS   PIC  X(10)    VALUE SPACES.*/
        public StringBasis HOST_DATA_HOJE_MENOS_05_DIAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-DATA-HOJE-MENOS-40-DIAS   PIC  X(10)    VALUE SPACES.*/
        public StringBasis HOST_DATA_HOJE_MENOS_40_DIAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-DATA-INICIO-SELECAO          PIC  X(10)    VALUE SPACES.*/
        public StringBasis W_DATA_INICIO_SELECAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-DATA-FIM-SELECAO             PIC  X(10)    VALUE SPACES.*/
        public StringBasis W_DATA_FIM_SELECAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-SINISTRO-48-INICIO           PIC S9(13)    COMP-3 VALUE +0*/
        public IntBasis W_SINISTRO_48_INICIO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  W-SINISTRO-48-FIM              PIC S9(13)    COMP-3 VALUE +0*/
        public IntBasis W_SINISTRO_48_FIM { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  W-SINISTRO-60-INICIO           PIC S9(13)    COMP-3 VALUE +0*/
        public IntBasis W_SINISTRO_60_INICIO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  W-SINISTRO-60-FIM              PIC S9(13)    COMP-3 VALUE +0*/
        public IntBasis W_SINISTRO_60_FIM { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  W-SINISTRO-70-INICIO           PIC S9(13)    COMP-3 VALUE +0*/
        public IntBasis W_SINISTRO_70_INICIO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  W-SINISTRO-70-FIM              PIC S9(13)    COMP-3 VALUE +0*/
        public IntBasis W_SINISTRO_70_FIM { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  AREA-DE-WORK.*/
        public SI0201B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0201B_AREA_DE_WORK();
        public class SI0201B_AREA_DE_WORK : VarBasis
        {
            /*"  05 WFIM-SINISHIS                 PIC X(03)  VALUE 'NAO'.*/
            public StringBasis WFIM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05 W-VALOR                       PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis W_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05 W-CONTA-05-DIAS-UTEIS         PIC 9(03) VALUE ZEROS.*/
            public IntBasis W_CONTA_05_DIAS_UTEIS { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  05 W-EDICAO                      PIC ZZZ.ZZ9.*/
            public IntBasis W_EDICAO { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
            /*"  05 W-EDICAO-1                    PIC ---.--9,99.*/
            public DoubleBasis W_EDICAO_1 { get; set; } = new DoubleBasis(new PIC("9", "6", "---.--9V99."), 2);
            /*"  05 W-EDICAO-2                    PIC ---.--9,99.*/
            public DoubleBasis W_EDICAO_2 { get; set; } = new DoubleBasis(new PIC("9", "6", "---.--9V99."), 2);
            /*"  05 W-EDICAO-3                    PIC ---.--9,99.*/
            public DoubleBasis W_EDICAO_3 { get; set; } = new DoubleBasis(new PIC("9", "6", "---.--9V99."), 2);
            /*"  05 W-EDICAO-4                    PIC ---.--9,99.*/
            public DoubleBasis W_EDICAO_4 { get; set; } = new DoubleBasis(new PIC("9", "6", "---.--9V99."), 2);
            /*"  05 W-VALOR                       PIC ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis W_VALOR_0 { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"  05 W-VALOR-PAGO-FINANCEIRO PIC S9(13)V99 COMP-3 VALUE +0.*/
            public DoubleBasis W_VALOR_PAGO_FINANCEIRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 W-VALOR-FRANQUIA              PIC S9(13)V99 COMP-3 VALUE +0*/
            public DoubleBasis W_VALOR_FRANQUIA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 W-VALOR-PREMIO                PIC S9(13)V99 COMP-3 VALUE +0*/
            public DoubleBasis W_VALOR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 W-VALOR-RESSARCIMENTO         PIC S9(13)V99 COMP-3 VALUE +0*/
            public DoubleBasis W_VALOR_RESSARCIMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 W-VALOR-TOTAL-PRE-LIBERADO    PIC S9(13)V99 COMP-3 VALUE +0*/
            public DoubleBasis W_VALOR_TOTAL_PRE_LIBERADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 W-VALOR-TOTAL-ESTORNADO       PIC S9(13)V99 COMP-3 VALUE +0*/
            public DoubleBasis W_VALOR_TOTAL_ESTORNADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 HOST-TOTAL-PRE-LIBERACAO      PIC S9(13)V99 COMP-3 VALUE +0*/
            public DoubleBasis HOST_TOTAL_PRE_LIBERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 HOST-TOTAL-CANC-PRE-LIBERACAO PIC S9(13)V99 COMP-3 VALUE +0*/
            public DoubleBasis HOST_TOTAL_CANC_PRE_LIBERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 W-PERC-FRANQUIA               PIC  9(03)V999 VALUE 0.*/
            public DoubleBasis W_PERC_FRANQUIA { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V999"), 3);
            /*"  05 W-CHAVE-TEM-PLANILHA          PIC  X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_TEM_PLANILHA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05 W-DATA-AAAAMMDD.*/
            public SI0201B_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new SI0201B_W_DATA_AAAAMMDD();
            public class SI0201B_W_DATA_AAAAMMDD : VarBasis
            {
                /*"     10 W-DATA-AAAAMMDD-AAAA       PIC 9(04)  VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"     10 FILLER                     PIC X(01)  VALUE SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"     10 W-DATA-AAAAMMDD-MM         PIC 9(02)  VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10 FILLER                     PIC X(01)  VALUE SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"     10 W-DATA-AAAAMMDD-DD         PIC 9(02)  VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  05 W-DATA-DD-MM-AAAA.*/
            }
            public SI0201B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new SI0201B_W_DATA_DD_MM_AAAA();
            public class SI0201B_W_DATA_DD_MM_AAAA : VarBasis
            {
                /*"     10 W-DATA-DD-MM-AAAA-DD       PIC 9(02)  VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10 FILLER                     PIC X(01)  VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"     10 W-DATA-DD-MM-AAAA-MM       PIC 9(02)  VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10 FILLER                     PIC X(01)  VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"     10 W-DATA-DD-MM-AAAA-AAAA     PIC 9(04)  VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"01  WABEND.*/
            }
        }
        public SI0201B_WABEND WABEND { get; set; } = new SI0201B_WABEND();
        public class SI0201B_WABEND : VarBasis
        {
            /*"    10 FILLER              PIC  X(008) VALUE       'SI0201B '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SI0201B ");
            /*"    10 FILLER              PIC  X(035) VALUE       ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
            /*"    10 WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"    10 FILLER              PIC  X(013) VALUE       ' * SQLCODE * '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" * SQLCODE * ");
            /*"    10 WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  LINK-PARM-DE-EXECUCAO.*/
        }
        public SI0201B_LINK_PARM_DE_EXECUCAO LINK_PARM_DE_EXECUCAO { get; set; } = new SI0201B_LINK_PARM_DE_EXECUCAO();
        public class SI0201B_LINK_PARM_DE_EXECUCAO : VarBasis
        {
            /*"    05 TAMANHO-PARM                PIC S9(04) COMP.*/
            public IntBasis TAMANHO_PARM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PARM-FORMA-EXECUCAO         PIC  X(03)     .*/
            public StringBasis PARM_FORMA_EXECUCAO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    05 PARM-STRING-PARM            PIC  X(70)     .*/
            public StringBasis PARM_STRING_PARM { get; set; } = new StringBasis(new PIC("X", "70", "X(70)"), @"");
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.RALCHEDO RALCHEDO { get; set; } = new Dclgens.RALCHEDO();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.UNIDACEF UNIDACEF { get; set; } = new Dclgens.UNIDACEF();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.SINCREIN SINCREIN { get; set; } = new Dclgens.SINCREIN();
        public Dclgens.APOLICRE APOLICRE { get; set; } = new Dclgens.APOLICRE();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.CONTRHAB CONTRHAB { get; set; } = new Dclgens.CONTRHAB();
        public Dclgens.SEGUHABI SEGUHABI { get; set; } = new Dclgens.SEGUHABI();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.AGENCIAS AGENCIAS { get; set; } = new Dclgens.AGENCIAS();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public Dclgens.SINIITEM SINIITEM { get; set; } = new Dclgens.SINIITEM();
        public SI0201B_XXXXX XXXXX { get; set; } = new SI0201B_XXXXX();
        public SI0201B_C01_SINISHIS C01_SINISHIS { get; set; } = new SI0201B_C01_SINISHIS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SI0201B_LINK_PARM_DE_EXECUCAO SI0201B_LINK_PARM_DE_EXECUCAO_P, string SI0201A_FILE_NAME_P) //PROCEDURE DIVISION USING 
        /*LINK_PARM_DE_EXECUCAO*/
        {
            try
            {
                this.LINK_PARM_DE_EXECUCAO = SI0201B_LINK_PARM_DE_EXECUCAO_P;
                SI0201A.SetFile(SI0201A_FILE_NAME_P);

                /*" -322- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -323- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -324- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -330- PERFORM R010-SELECT-SISTEMAS THRU R010-EXIT. */

                R010_SELECT_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -331- DISPLAY '*************************************************' */
                _.Display($"*************************************************");

                /*" -332- DISPLAY '*                                               *' */
                _.Display($"*                                               *");

                /*" -334- DISPLAY '* PARAMETRO DE EXECUCAO ==>' PARM-FORMA-EXECUCAO '<== * ' */

                $"* PARAMETRO DE EXECUCAO ==>{LINK_PARM_DE_EXECUCAO.PARM_FORMA_EXECUCAO}<== * "
                .Display();

                /*" -335- DISPLAY '* TODO O REGISTRO ==>' LINK-PARM-DE-EXECUCAO */
                _.Display($"* TODO O REGISTRO ==>{LINK_PARM_DE_EXECUCAO}");

                /*" -337- DISPLAY '*                                               *' */
                _.Display($"*                                               *");

                /*" -339- IF (PARM-FORMA-EXECUCAO NOT EQUAL '111' ) AND (PARM-FORMA-EXECUCAO NOT EQUAL '222' ) */

                if ((LINK_PARM_DE_EXECUCAO.PARM_FORMA_EXECUCAO != "111") && (LINK_PARM_DE_EXECUCAO.PARM_FORMA_EXECUCAO != "222"))
                {

                    /*" -340- DISPLAY '*                                               *' */
                    _.Display($"*                                               *");

                    /*" -341- DISPLAY '* PARAMETRO INVALIDO. SERA ASSUMIDO PARAMETRO   *' */
                    _.Display($"* PARAMETRO INVALIDO. SERA ASSUMIDO PARAMETRO   *");

                    /*" -342- DISPLAY '* PARA EXECUCAO POR DIAS UTEIS.                 *' */
                    _.Display($"* PARA EXECUCAO POR DIAS UTEIS.                 *");

                    /*" -343- DISPLAY '*                                               *' */
                    _.Display($"*                                               *");

                    /*" -344- MOVE '111' TO PARM-FORMA-EXECUCAO */
                    _.Move("111", LINK_PARM_DE_EXECUCAO.PARM_FORMA_EXECUCAO);

                    /*" -345- ELSE */
                }
                else
                {


                    /*" -346- DISPLAY '* PARAMETRO CORRETO.                            *' */
                    _.Display($"* PARAMETRO CORRETO.                            *");

                    /*" -347- IF PARM-FORMA-EXECUCAO EQUAL '111' */

                    if (LINK_PARM_DE_EXECUCAO.PARM_FORMA_EXECUCAO == "111")
                    {

                        /*" -348- DISPLAY '* VAI PROCESSAR PELA REGRA DE DIAS UTEIS        *' */
                        _.Display($"* VAI PROCESSAR PELA REGRA DE DIAS UTEIS        *");

                        /*" -349- ELSE */
                    }
                    else
                    {


                        /*" -350- DISPLAY '* VAI PROCESSAR TODO O ESTOQUE                  *' */
                        _.Display($"* VAI PROCESSAR TODO O ESTOQUE                  *");

                        /*" -351- DISPLAY '*                                               *' */
                        _.Display($"*                                               *");

                        /*" -355- END-IF. */
                    }

                }


                /*" -357- PERFORM R020-ACHA-DATA-HOJE-MENOS-10 THRU R020-EXIT */

                R020_ACHA_DATA_HOJE_MENOS_10(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -358- IF PARM-FORMA-EXECUCAO EQUAL '222' */

                if (LINK_PARM_DE_EXECUCAO.PARM_FORMA_EXECUCAO == "222")
                {

                    /*" -359- MOVE '1900-01-01' TO W-DATA-INICIO-SELECAO */
                    _.Move("1900-01-01", W_DATA_INICIO_SELECAO);

                    /*" -361- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-FIM-SELECAO. */
                    _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W_DATA_FIM_SELECAO);
                }


                /*" -362- DISPLAY ' ' */
                _.Display($" ");

                /*" -363- DISPLAY '*************************************************' */
                _.Display($"*************************************************");

                /*" -364- DISPLAY ' A PARTIR DE 08/12/2009 PELA SSI 25.978 DEVERA   ' */
                _.Display($" A PARTIR DE 08/12/2009 PELA SSI 25.978 DEVERA   ");

                /*" -365- DISPLAY ' HAVER UMA DEFASAGEM DE 05 DIAS UTEIS ENTRE A DATA' */
                _.Display($" HAVER UMA DEFASAGEM DE 05 DIAS UTEIS ENTRE A DATA");

                /*" -366- DISPLAY ' DE INDENIZACAO E A CARGA PARA O RESSARCIMENTO.' */
                _.Display($" DE INDENIZACAO E A CARGA PARA O RESSARCIMENTO.");

                /*" -367- DISPLAY ' ' */
                _.Display($" ");

                /*" -368- DISPLAY ' TODAS AS INDENIZACOES E ESTORNOS ENTRE ESTAS DATAS' */
                _.Display($" TODAS AS INDENIZACOES E ESTORNOS ENTRE ESTAS DATAS");

                /*" -369- DISPLAY ' ESTAO SENDO SELECIONADOS PARA O RESSARCIMENTO' */
                _.Display($" ESTAO SENDO SELECIONADOS PARA O RESSARCIMENTO");

                /*" -370- DISPLAY ' ' */
                _.Display($" ");

                /*" -374- DISPLAY ' DATA DO SISTEMA DE SINISTRO ... ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

                $" DATA DO SISTEMA DE SINISTRO ... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
                .Display();

                /*" -375- DISPLAY ' ' */
                _.Display($" ");

                /*" -379- DISPLAY ' DATA INICIAL DA SELECAO ....... ' W-DATA-INICIO-SELECAO(9:2) '/' W-DATA-INICIO-SELECAO(6:2) '/' W-DATA-INICIO-SELECAO(1:4). */

                $" DATA INICIAL DA SELECAO ....... {W_DATA_INICIO_SELECAO.Substring(9, 2)}/{W_DATA_INICIO_SELECAO.Substring(6, 2)}/{W_DATA_INICIO_SELECAO.Substring(1, 4)}"
                .Display();

                /*" -383- DISPLAY ' DATA FINAL DA SELECAO ......... ' W-DATA-FIM-SELECAO(9:2) '/' W-DATA-FIM-SELECAO(6:2) '/' W-DATA-FIM-SELECAO(1:4). */

                $" DATA FINAL DA SELECAO ......... {W_DATA_FIM_SELECAO.Substring(9, 2)}/{W_DATA_FIM_SELECAO.Substring(6, 2)}/{W_DATA_FIM_SELECAO.Substring(1, 4)}"
                .Display();

                /*" -387- DISPLAY ' ' . */
                _.Display($" ");

                /*" -389- OPEN OUTPUT SI0201A. */
                SI0201A.Open(REG_SI0201A);

                /*" -391- PERFORM R030-DECLARE-SINISHIS THRU R030-EXIT. */

                R030_DECLARE_SINISHIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/


                /*" -392- MOVE 'NAO' TO WFIM-SINISHIS. */
                _.Move("NAO", AREA_DE_WORK.WFIM_SINISHIS);

                /*" -394- PERFORM R031-FETCH-SINISHIS THRU R031-EXIT. */

                R031_FETCH_SINISHIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/


                /*" -395- IF WFIM-SINISHIS EQUAL 'SIM' */

                if (AREA_DE_WORK.WFIM_SINISHIS == "SIM")
                {

                    /*" -396- DISPLAY '***************************************************' */
                    _.Display($"***************************************************");

                    /*" -397- DISPLAY '*                                                 *' */
                    _.Display($"*                                                 *");

                    /*" -398- DISPLAY '*        NADA SELECIONADO NA DATA DE HOJE         *' */
                    _.Display($"*        NADA SELECIONADO NA DATA DE HOJE         *");

                    /*" -399- DISPLAY '*                                                 *' */
                    _.Display($"*                                                 *");

                    /*" -400- DISPLAY '***************************************************' */
                    _.Display($"***************************************************");

                    /*" -402- DISPLAY ' ' . */
                    _.Display($" ");
                }


                /*" -405- PERFORM R100-PROCESSA-HISTSINI THRU R100-EXIT UNTIL WFIM-SINISHIS EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_SINISHIS == "SIM"))
                {

                    R100_PROCESSA_HISTSINI(true);

                    R100_GRAVA_REGISTRO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }

                /*" -406- DISPLAY '***************************************************' */
                _.Display($"***************************************************");

                /*" -407- DISPLAY '*                                                 *' */
                _.Display($"*                                                 *");

                /*" -408- DISPLAY '*                FIM NORMAL                       *' */
                _.Display($"*                FIM NORMAL                       *");

                /*" -409- DISPLAY '*                                                 *' */
                _.Display($"*                                                 *");

                /*" -410- DISPLAY '***************************************************' */
                _.Display($"***************************************************");

                /*" -412- DISPLAY ' ' */
                _.Display($" ");

                /*" -414- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -417- CLOSE SI0201A. */
                SI0201A.Close();

                /*" -417- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -419- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LINK_PARM_DE_EXECUCAO, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R010-SELECT-SISTEMAS */
        private void R010_SELECT_SISTEMAS(bool isPerform = false)
        {
            /*" -425- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", WABEND.WNR_EXEC_SQL);

            /*" -433- PERFORM R010_SELECT_SISTEMAS_DB_SELECT_1 */

            R010_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -439- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -440- DISPLAY 'ERRO ACESSO SISTEMAS' */
                _.Display($"ERRO ACESSO SISTEMAS");

                /*" -441- DISPLAY 'SI0201B - SISTEMA SINISTRO NAO CADASTRADO' */
                _.Display($"SI0201B - SISTEMA SINISTRO NAO CADASTRADO");

                /*" -443- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -447- DISPLAY 'SI0201B - DATA DO PROCESSAMENTO (SI) = ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

            $"SI0201B - DATA DO PROCESSAMENTO (SI) = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -447- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R010-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R010_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -433- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :HOST-CURRENT-DATE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

            var r010_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R010_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R010_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r010_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.HOST_CURRENT_DATE, HOST_CURRENT_DATE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-ACHA-DATA-HOJE-MENOS-10 */
        private void R020_ACHA_DATA_HOJE_MENOS_10(bool isPerform = false)
        {
            /*" -455- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", WABEND.WNR_EXEC_SQL);

            /*" -467- PERFORM R020_ACHA_DATA_HOJE_MENOS_10_DB_DECLARE_1 */

            R020_ACHA_DATA_HOJE_MENOS_10_DB_DECLARE_1();

            /*" -469- PERFORM R020_ACHA_DATA_HOJE_MENOS_10_DB_OPEN_1 */

            R020_ACHA_DATA_HOJE_MENOS_10_DB_OPEN_1();

            /*" -472- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -473- DISPLAY 'ERRO NO OPEN CURSOR DATALIMITE' */
                _.Display($"ERRO NO OPEN CURSOR DATALIMITE");

                /*" -476- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;
            }


            /*" -479- MOVE 1 TO W-CONTA-05-DIAS-UTEIS. */
            _.Move(1, AREA_DE_WORK.W_CONTA_05_DIAS_UTEIS);

            /*" -482- PERFORM VARYING W-CONTA-05-DIAS-UTEIS FROM 1 BY 1 UNTIL W-CONTA-05-DIAS-UTEIS > 05 */

            for (AREA_DE_WORK.W_CONTA_05_DIAS_UTEIS.Value = 1; !(AREA_DE_WORK.W_CONTA_05_DIAS_UTEIS > 05); AREA_DE_WORK.W_CONTA_05_DIAS_UTEIS.Value += 1)
            {

                /*" -483- MOVE '003' TO WNR-EXEC-SQL */
                _.Move("003", WABEND.WNR_EXEC_SQL);

                /*" -487- PERFORM R020_ACHA_DATA_HOJE_MENOS_10_DB_FETCH_1 */

                R020_ACHA_DATA_HOJE_MENOS_10_DB_FETCH_1();

                /*" -490- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -491- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -491- PERFORM R020_ACHA_DATA_HOJE_MENOS_10_DB_CLOSE_1 */

                        R020_ACHA_DATA_HOJE_MENOS_10_DB_CLOSE_1();

                        /*" -493- ELSE */
                    }
                    else
                    {


                        /*" -494- DISPLAY 'ERRO NO FETCH DA CALENDARIO' */
                        _.Display($"ERRO NO FETCH DA CALENDARIO");

                        /*" -495- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO(); //GOTO
                        return;

                        /*" -496- END-IF */
                    }


                    /*" -497- END-IF */
                }


                /*" -499- END-PERFORM. */
            }

            /*" -501- MOVE HOST-DATA-HOJE-MENOS-40-DIAS TO W-DATA-INICIO-SELECAO. */
            _.Move(HOST_DATA_HOJE_MENOS_40_DIAS, W_DATA_INICIO_SELECAO);

            /*" -501- MOVE HOST-DATA-HOJE-MENOS-05-DIAS TO W-DATA-FIM-SELECAO. */
            _.Move(HOST_DATA_HOJE_MENOS_05_DIAS, W_DATA_FIM_SELECAO);

        }

        [StopWatch]
        /*" R020-ACHA-DATA-HOJE-MENOS-10-DB-DECLARE-1 */
        public void R020_ACHA_DATA_HOJE_MENOS_10_DB_DECLARE_1()
        {
            /*" -467- EXEC SQL DECLARE XXXXX CURSOR FOR SELECT DATA_CALENDARIO, DATA_CALENDARIO - 40 DAYS FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO >= DATE(:SISTEMAS-DATA-MOV-ABERTO) - 30 DAYS AND DATA_CALENDARIO <= :SISTEMAS-DATA-MOV-ABERTO AND FERIADO <> 'N' AND DIA_SEMANA NOT IN ( 'S' , 'D' ) ORDER BY DATA_CALENDARIO DESC FETCH FIRST 10 ROWS ONLY WITH UR END-EXEC. */
            XXXXX = new SI0201B_XXXXX(true);
            string GetQuery_XXXXX()
            {
                var query = @$"SELECT DATA_CALENDARIO
							, 
							DATA_CALENDARIO - 40 DAYS 
							FROM SEGUROS.CALENDARIO 
							WHERE DATA_CALENDARIO >= 
							DATE('{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}') - 30 DAYS 
							AND DATA_CALENDARIO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND FERIADO <> 'N' 
							AND DIA_SEMANA NOT IN ( 'S'
							, 'D' ) 
							ORDER BY DATA_CALENDARIO DESC 
							FETCH FIRST 10 ROWS ONLY";

                return query;
            }
            XXXXX.GetQueryEvent += GetQuery_XXXXX;

        }

        [StopWatch]
        /*" R020-ACHA-DATA-HOJE-MENOS-10-DB-OPEN-1 */
        public void R020_ACHA_DATA_HOJE_MENOS_10_DB_OPEN_1()
        {
            /*" -469- EXEC SQL OPEN XXXXX END-EXEC. */

            XXXXX.Open();

        }

        [StopWatch]
        /*" R030-DECLARE-SINISHIS-DB-DECLARE-1 */
        public void R030_DECLARE_SINISHIS_DB_DECLARE_1()
        {
            /*" -641- EXEC SQL DECLARE C01_SINISHIS CURSOR FOR SELECT DISTINCT M.NUM_APOL_SINISTRO, M.NUM_APOLICE, M.COD_PRODUTO, M.COD_FONTE, M.DATA_OCORRENCIA, M.SIT_REGISTRO, M.NUM_PROTOCOLO_SINI, A.COD_SUREG, A.COD_AGENCIA, A.COD_OPERACAO, A.NUM_CONTRATO, A.CONTRATO_DIGITO, S.GRUPO_CAUSAS, S.DESCR_CAUSA FROM SEGUROS.SINISTRO_MESTRE M , SEGUROS.SINISTRO_HISTORICO H , SEGUROS.GE_SIS_FUNCAO_OPER Y , SEGUROS.SINISTRO_CRED_INT A , SEGUROS.SINISTRO_CAUSA S WHERE ( M.NUM_APOL_SINISTRO BETWEEN :W-SINISTRO-48-INICIO AND :W-SINISTRO-48-FIM OR M.NUM_APOL_SINISTRO BETWEEN :W-SINISTRO-60-INICIO AND :W-SINISTRO-60-FIM OR M.NUM_APOL_SINISTRO BETWEEN :W-SINISTRO-70-INICIO AND :W-SINISTRO-70-FIM ) AND H.DATA_MOVIMENTO BETWEEN :W-DATA-INICIO-SELECAO AND :W-DATA-FIM-SELECAO AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) AND M.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.COD_PRODUTO NOT IN ( 6008 , 6009 , 4813 , 4814 ) AND S.RAMO_EMISSOR = M.RAMO AND S.COD_CAUSA = M.COD_CAUSA AND S.GRUPO_CAUSAS = 'INADIMP.' AND Y.COD_OPERACAO = H.COD_OPERACAO AND Y.IDE_SISTEMA = 'SI' AND Y.COD_FUNCAO = 2 ORDER BY 1,2,3,4,5,6,7,8,9,10,11,12,13,14 WITH UR END-EXEC. */
            C01_SINISHIS = new SI0201B_C01_SINISHIS(false);
            string GetQuery_C01_SINISHIS()
            {
                var query = @$"SELECT DISTINCT 
							M.NUM_APOL_SINISTRO
							, 
							M.NUM_APOLICE
							, 
							M.COD_PRODUTO
							, 
							M.COD_FONTE
							, 
							M.DATA_OCORRENCIA
							, 
							M.SIT_REGISTRO
							, 
							M.NUM_PROTOCOLO_SINI
							, 
							A.COD_SUREG
							, 
							A.COD_AGENCIA
							, 
							A.COD_OPERACAO
							, 
							A.NUM_CONTRATO
							, 
							A.CONTRATO_DIGITO
							, 
							S.GRUPO_CAUSAS
							, 
							S.DESCR_CAUSA 
							FROM SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.GE_SIS_FUNCAO_OPER Y
							, 
							SEGUROS.SINISTRO_CRED_INT A
							, 
							SEGUROS.SINISTRO_CAUSA S 
							WHERE ( M.NUM_APOL_SINISTRO BETWEEN 
							{W_SINISTRO_48_INICIO} 
							AND {W_SINISTRO_48_FIM} 
							OR M.NUM_APOL_SINISTRO BETWEEN 
							{W_SINISTRO_60_INICIO} 
							AND {W_SINISTRO_60_FIM} 
							OR M.NUM_APOL_SINISTRO BETWEEN 
							{W_SINISTRO_70_INICIO} 
							AND {W_SINISTRO_70_FIM} ) 
							AND H.DATA_MOVIMENTO BETWEEN 
							'{W_DATA_INICIO_SELECAO}' 
							AND '{W_DATA_FIM_SELECAO}' 
							AND ( H.NOM_PROGRAMA <> 'SI0170B' 
							OR H.NOM_PROGRAMA IS NULL) 
							AND M.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND M.COD_PRODUTO NOT IN ( 6008
							, 6009
							, 4813
							, 4814 ) 
							AND S.RAMO_EMISSOR = M.RAMO 
							AND S.COD_CAUSA = M.COD_CAUSA 
							AND S.GRUPO_CAUSAS = 'INADIMP.' 
							AND Y.COD_OPERACAO = H.COD_OPERACAO 
							AND Y.IDE_SISTEMA = 'SI' 
							AND Y.COD_FUNCAO = 2 
							ORDER BY 1
							,2
							,3
							,4
							,5
							,6
							,7
							,8
							,9
							,10
							,11
							,12
							,13
							,14";

                return query;
            }
            C01_SINISHIS.GetQueryEvent += GetQuery_C01_SINISHIS;

        }

        [StopWatch]
        /*" R020-ACHA-DATA-HOJE-MENOS-10-DB-FETCH-1 */
        public void R020_ACHA_DATA_HOJE_MENOS_10_DB_FETCH_1()
        {
            /*" -487- EXEC SQL FETCH XXXXX INTO :HOST-DATA-HOJE-MENOS-05-DIAS, :HOST-DATA-HOJE-MENOS-40-DIAS END-EXEC */

            if (XXXXX.Fetch())
            {
                _.Move(XXXXX.HOST_DATA_HOJE_MENOS_05_DIAS, HOST_DATA_HOJE_MENOS_05_DIAS);
                _.Move(XXXXX.HOST_DATA_HOJE_MENOS_40_DIAS, HOST_DATA_HOJE_MENOS_40_DIAS);
            }

        }

        [StopWatch]
        /*" R020-ACHA-DATA-HOJE-MENOS-10-DB-CLOSE-1 */
        public void R020_ACHA_DATA_HOJE_MENOS_10_DB_CLOSE_1()
        {
            /*" -491- EXEC SQL CLOSE XXXXX END-EXEC */

            XXXXX.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R030-DECLARE-SINISHIS */
        private void R030_DECLARE_SINISHIS(bool isPerform = false)
        {
            /*" -512- MOVE 0104800000000 TO W-SINISTRO-48-INICIO. */
            _.Move(0104800000000, W_SINISTRO_48_INICIO);

            /*" -513- MOVE 0104899999999 TO W-SINISTRO-48-FIM. */
            _.Move(0104899999999, W_SINISTRO_48_FIM);

            /*" -514- MOVE 0106000000000 TO W-SINISTRO-60-INICIO. */
            _.Move(0106000000000, W_SINISTRO_60_INICIO);

            /*" -515- MOVE 0106099999999 TO W-SINISTRO-60-FIM. */
            _.Move(0106099999999, W_SINISTRO_60_FIM);

            /*" -516- MOVE 0107000000000 TO W-SINISTRO-70-INICIO. */
            _.Move(0107000000000, W_SINISTRO_70_INICIO);

            /*" -518- MOVE 0107099999999 TO W-SINISTRO-70-FIM. */
            _.Move(0107099999999, W_SINISTRO_70_FIM);

            /*" -520- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", WABEND.WNR_EXEC_SQL);

            /*" -641- PERFORM R030_DECLARE_SINISHIS_DB_DECLARE_1 */

            R030_DECLARE_SINISHIS_DB_DECLARE_1();

            /*" -643- PERFORM R030_DECLARE_SINISHIS_DB_OPEN_1 */

            R030_DECLARE_SINISHIS_DB_OPEN_1();

            /*" -646- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -647- DISPLAY 'ERRO NO OPEN CURSOR SINISHIS' */
                _.Display($"ERRO NO OPEN CURSOR SINISHIS");

                /*" -648- GO TO R10010199-MENSAGEM-LOCK */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;

                /*" -648- END-IF. */
            }


        }

        [StopWatch]
        /*" R030-DECLARE-SINISHIS-DB-OPEN-1 */
        public void R030_DECLARE_SINISHIS_DB_OPEN_1()
        {
            /*" -643- EXEC SQL OPEN C01_SINISHIS END-EXEC. */

            C01_SINISHIS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R031-FETCH-SINISHIS */
        private void R031_FETCH_SINISHIS(bool isPerform = false)
        {
            /*" -656- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WABEND.WNR_EXEC_SQL);

            /*" -671- PERFORM R031_FETCH_SINISHIS_DB_FETCH_1 */

            R031_FETCH_SINISHIS_DB_FETCH_1();

            /*" -674- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -675- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -675- PERFORM R031_FETCH_SINISHIS_DB_CLOSE_1 */

                    R031_FETCH_SINISHIS_DB_CLOSE_1();

                    /*" -677- MOVE 'SIM' TO WFIM-SINISHIS */
                    _.Move("SIM", AREA_DE_WORK.WFIM_SINISHIS);

                    /*" -678- GO TO R031-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/ //GOTO
                    return;

                    /*" -679- ELSE */
                }
                else
                {


                    /*" -680- DISPLAY 'ERRO NO FETCH DA SINISTRO_HISTORICO' */
                    _.Display($"ERRO NO FETCH DA SINISTRO_HISTORICO");

                    /*" -681- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -682- END-IF */
                }


                /*" -682- END-IF. */
            }


        }

        [StopWatch]
        /*" R031-FETCH-SINISHIS-DB-FETCH-1 */
        public void R031_FETCH_SINISHIS_DB_FETCH_1()
        {
            /*" -671- EXEC SQL FETCH C01_SINISHIS INTO :SINISMES-NUM-APOL-SINISTRO, :SINISMES-NUM-APOLICE, :SINISMES-COD-PRODUTO, :SINISMES-COD-FONTE, :SINISMES-DATA-OCORRENCIA, :SINISMES-SIT-REGISTRO, :SINISMES-NUM-PROTOCOLO-SINI, :SINCREIN-COD-SUREG, :SINCREIN-COD-AGENCIA, :SINCREIN-COD-OPERACAO, :SINCREIN-NUM-CONTRATO, :SINCREIN-CONTRATO-DIGITO, :SINISCAU-GRUPO-CAUSAS, :SINISCAU-DESCR-CAUSA END-EXEC. */

            if (C01_SINISHIS.Fetch())
            {
                _.Move(C01_SINISHIS.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(C01_SINISHIS.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(C01_SINISHIS.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(C01_SINISHIS.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(C01_SINISHIS.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(C01_SINISHIS.SINISMES_SIT_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);
                _.Move(C01_SINISHIS.SINISMES_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);
                _.Move(C01_SINISHIS.SINCREIN_COD_SUREG, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG);
                _.Move(C01_SINISHIS.SINCREIN_COD_AGENCIA, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA);
                _.Move(C01_SINISHIS.SINCREIN_COD_OPERACAO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO);
                _.Move(C01_SINISHIS.SINCREIN_NUM_CONTRATO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO);
                _.Move(C01_SINISHIS.SINCREIN_CONTRATO_DIGITO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO);
                _.Move(C01_SINISHIS.SINISCAU_GRUPO_CAUSAS, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS);
                _.Move(C01_SINISHIS.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
            }

        }

        [StopWatch]
        /*" R031-FETCH-SINISHIS-DB-CLOSE-1 */
        public void R031_FETCH_SINISHIS_DB_CLOSE_1()
        {
            /*" -675- EXEC SQL CLOSE C01_SINISHIS END-EXEC */

            C01_SINISHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-HISTSINI */
        private void R100_PROCESSA_HISTSINI(bool isPerform = false)
        {
            /*" -690- INITIALIZE REG-SI0201A. */
            _.Initialize(
                REG_SI0201A
            );

            /*" -691- MOVE SINISMES-NUM-APOL-SINISTRO TO REG-NUM-APOL-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, REG_SI0201A.REG_NUM_APOL_SINISTRO);

            /*" -692- MOVE SINISMES-NUM-PROTOCOLO-SINI TO REG-NUM-PROTOCOLO-SINI. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI, REG_SI0201A.REG_NUM_PROTOCOLO_SINI);

            /*" -693- MOVE SINISMES-NUM-APOLICE TO REG-NUM-APOLICE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, REG_SI0201A.REG_NUM_APOLICE);

            /*" -694- MOVE SINCREIN-COD-SUREG TO REG-SUREG. */
            _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG, REG_SI0201A.REG_SUREG);

            /*" -695- MOVE SINCREIN-COD-AGENCIA TO REG-AGENCIA. */
            _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA, REG_SI0201A.REG_AGENCIA);

            /*" -696- MOVE SINCREIN-COD-OPERACAO TO REG-OPERACAO. */
            _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO, REG_SI0201A.REG_OPERACAO);

            /*" -697- MOVE SINCREIN-NUM-CONTRATO TO REG-CONTRATO */
            _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO, REG_SI0201A.REG_CONTRATO);

            /*" -698- MOVE SINCREIN-CONTRATO-DIGITO TO REG-DV. */
            _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO, REG_SI0201A.REG_DV);

            /*" -699- MOVE SINISMES-COD-PRODUTO TO REG-NUM-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, REG_SI0201A.REG_NUM_PRODUTO);

            /*" -700- MOVE SINISMES-COD-FONTE TO REG-NUM-FONTE-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, REG_SI0201A.REG_NUM_FONTE_SINISTRO);

            /*" -701- MOVE 1 TO REG-MOEDA-INDENIZACAO. */
            _.Move(1, REG_SI0201A.REG_MOEDA_INDENIZACAO);

            /*" -702- MOVE SPACES TO REG-NOME-DEVEDOR. */
            _.Move("", REG_SI0201A.REG_NOME_DEVEDOR);

            /*" -703- MOVE SPACES TO REG-SEXO-DEVEDOR. */
            _.Move("", REG_SI0201A.REG_SEXO_DEVEDOR);

            /*" -704- MOVE SPACES TO REG-TELEF-RESID-DEVEDOR. */
            _.Move("", REG_SI0201A.REG_TELEF_RESID_DEVEDOR);

            /*" -705- MOVE SPACES TO REG-TELEF-TRAB-DEVEDOR. */
            _.Move("", REG_SI0201A.REG_TELEF_TRAB_DEVEDOR);

            /*" -706- MOVE SPACES TO REG-TELEF-FAX-DEVEDOR. */
            _.Move("", REG_SI0201A.REG_TELEF_FAX_DEVEDOR);

            /*" -711- PERFORM R130-LE-APOLICRE THRU R130-EXIT. */

            R130_LE_APOLICRE(true);

            R130_LE_SINISTRO_ITEM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/


            /*" -712- IF SINCREIN-COD-AGENCIA EQUAL 9999 */

            if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA == 9999)
            {

                /*" -713- MOVE 'BRASILIA' TO REG-CIDADE-SINISTRO */
                _.Move("BRASILIA", REG_SI0201A.REG_CIDADE_SINISTRO);

                /*" -714- MOVE 'DF' TO REG-UF-SINISTRO */
                _.Move("DF", REG_SI0201A.REG_UF_SINISTRO);

                /*" -719- ELSE */
            }
            else
            {


                /*" -727- PERFORM R121-SELECT-AGENCIAS THRU R121-EXIT */

                R121_SELECT_AGENCIAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R121_EXIT*/


                /*" -730- MOVE ZEROS TO REG-VALOR-FRANQUIA. */
                _.Move(0, REG_SI0201A.REG_VALOR_FRANQUIA);
            }


            /*" -731- MOVE SPACES TO REG-LOGRADOURO-DEVEDOR. */
            _.Move("", REG_SI0201A.REG_LOGRADOURO_DEVEDOR);

            /*" -732- MOVE SPACES TO REG-BAIRRO-DEVEDOR. */
            _.Move("", REG_SI0201A.REG_BAIRRO_DEVEDOR);

            /*" -733- MOVE SPACES TO REG-IDENTIDADE-DEVEDOR. */
            _.Move("", REG_SI0201A.REG_IDENTIDADE_DEVEDOR);

            /*" -736- MOVE SINISMES-DATA-OCORRENCIA TO REG-DATA-OCORR-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, REG_SI0201A.REG_DATA_OCORR_SINISTRO);

            /*" -737- MOVE 0 TO REG-OCORR-HISTORICO. */
            _.Move(0, REG_SI0201A.REG_OCORR_HISTORICO);

            /*" -738- MOVE 0 TO REG-COD-OPERACAO. */
            _.Move(0, REG_SI0201A.REG_COD_OPERACAO);

            /*" -739- MOVE SINISCAU-GRUPO-CAUSAS TO REG-NATUREZA-SINISTRO. */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS, REG_SI0201A.REG_NATUREZA_SINISTRO);

            /*" -745- MOVE SINISCAU-DESCR-CAUSA TO REG-DESCR-CAUSA-SINISTRO. */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, REG_SI0201A.REG_DESCR_CAUSA_SINISTRO);

            /*" -747- IF SINISMES-SIT-REGISTRO EQUAL '2' */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO == "2")
            {

                /*" -748- MOVE 0 TO REG-VALOR-INDENIZACAO */
                _.Move(0, REG_SI0201A.REG_VALOR_INDENIZACAO);

                /*" -749- PERFORM R105-PRIMEIRA-DATA-INDENIZA-1 THRU R105-EXIT */

                R105_PRIMEIRA_DATA_INDENIZA_1(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R105_EXIT*/


                /*" -750- MOVE SINISHIS-DATA-MOVIMENTO TO REG-DATA-INDENIZACAO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, REG_SI0201A.REG_DATA_INDENIZACAO);

                /*" -755- GO TO R100-GRAVA-REGISTRO. */

                R100_GRAVA_REGISTRO(); //GOTO
                return;
            }


            /*" -771- MOVE 0 TO W-VALOR-PAGO-FINANCEIRO W-VALOR-FRANQUIA W-VALOR-PREMIO W-VALOR-RESSARCIMENTO W-VALOR-TOTAL-PRE-LIBERADO W-VALOR-TOTAL-ESTORNADO W-PERC-FRANQUIA. */
            _.Move(0, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO, AREA_DE_WORK.W_VALOR_FRANQUIA, AREA_DE_WORK.W_VALOR_PREMIO, AREA_DE_WORK.W_VALOR_RESSARCIMENTO, AREA_DE_WORK.W_VALOR_TOTAL_PRE_LIBERADO, AREA_DE_WORK.W_VALOR_TOTAL_ESTORNADO, AREA_DE_WORK.W_PERC_FRANQUIA);

            /*" -772- PERFORM R200-LE-PRE-LIBERACOES THRU R200-EXIT */

            R200_LE_PRE_LIBERACOES(true);

            R200_PULA_CANCELAMENTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/


            /*" -774- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-TOTAL-PRE-LIBERADO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_TOTAL_PRE_LIBERADO);

            /*" -775- PERFORM R210-LE-ESTORNO THRU R210-EXIT. */

            R210_LE_ESTORNO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/


            /*" -777- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-TOTAL-ESTORNADO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_TOTAL_ESTORNADO);

            /*" -790- COMPUTE W-VALOR-PAGO-FINANCEIRO = W-VALOR-TOTAL-PRE-LIBERADO - W-VALOR-TOTAL-ESTORNADO. */
            AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO.Value = AREA_DE_WORK.W_VALOR_TOTAL_PRE_LIBERADO - AREA_DE_WORK.W_VALOR_TOTAL_ESTORNADO;

            /*" -791- IF SINISMES-NUM-APOL-SINISTRO = 0104800002029 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 0104800002029)
            {

                /*" -792- MOVE 791,69 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(791.69, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -793- IF SINISMES-NUM-APOL-SINISTRO = 104800001565 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001565)
            {

                /*" -794- MOVE 1875,09 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(1875.09, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -795- IF SINISMES-NUM-APOL-SINISTRO = 104800001950 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001950)
            {

                /*" -796- MOVE 7095,18 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(7095.18, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -797- IF SINISMES-NUM-APOL-SINISTRO = 104800001952 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001952)
            {

                /*" -798- MOVE 6338,54 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(6338.54, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -799- IF SINISMES-NUM-APOL-SINISTRO = 104800001957 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001957)
            {

                /*" -800- MOVE 1589,41 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(1589.41, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -801- IF SINISMES-NUM-APOL-SINISTRO = 104800001959 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001959)
            {

                /*" -802- MOVE 1071,11 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(1071.11, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -803- IF SINISMES-NUM-APOL-SINISTRO = 104800001965 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001965)
            {

                /*" -804- MOVE 1957,59 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(1957.59, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -805- IF SINISMES-NUM-APOL-SINISTRO = 104800001968 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001968)
            {

                /*" -806- MOVE 1482,67 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(1482.67, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -807- IF SINISMES-NUM-APOL-SINISTRO = 104800001972 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001972)
            {

                /*" -808- MOVE 3916,50 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(3916.50, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -809- IF SINISMES-NUM-APOL-SINISTRO = 104800001945 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001945)
            {

                /*" -810- MOVE 2489,39 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(2489.39, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -811- IF SINISMES-NUM-APOL-SINISTRO = 104800001903 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001903)
            {

                /*" -812- MOVE 3431,16 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(3431.16, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -813- IF SINISMES-NUM-APOL-SINISTRO = 104800001905 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001905)
            {

                /*" -814- MOVE 19585,65 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(19585.65, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -815- IF SINISMES-NUM-APOL-SINISTRO = 104800000086 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800000086)
            {

                /*" -816- MOVE 125,82 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(125.82, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -817- IF SINISMES-NUM-APOL-SINISTRO = 104800000146 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800000146)
            {

                /*" -818- MOVE 4,38 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(4.38, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -819- IF SINISMES-NUM-APOL-SINISTRO = 104800000147 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800000147)
            {

                /*" -820- MOVE 2,55 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(2.55, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -821- IF SINISMES-NUM-APOL-SINISTRO = 104800000148 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800000148)
            {

                /*" -822- MOVE 2,51 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(2.51, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -823- IF SINISMES-NUM-APOL-SINISTRO = 104800000149 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800000149)
            {

                /*" -824- MOVE 2,65 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(2.65, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -825- IF SINISMES-NUM-APOL-SINISTRO = 104800000150 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800000150)
            {

                /*" -826- MOVE 2,27 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(2.27, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -827- IF SINISMES-NUM-APOL-SINISTRO = 104800000151 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800000151)
            {

                /*" -828- MOVE 4,20 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(4.20, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -829- IF SINISMES-NUM-APOL-SINISTRO = 104800000152 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800000152)
            {

                /*" -830- MOVE 3,24 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(3.24, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -831- IF SINISMES-NUM-APOL-SINISTRO = 0104800001561 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 0104800001561)
            {

                /*" -832- MOVE 497,92 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(497.92, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -833- IF SINISMES-NUM-APOL-SINISTRO = 0104800001562 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 0104800001562)
            {

                /*" -834- MOVE 2264,45 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(2264.45, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -835- IF SINISMES-NUM-APOL-SINISTRO = 0104800001423 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 0104800001423)
            {

                /*" -836- MOVE 609,27 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(609.27, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -837- IF SINISMES-NUM-APOL-SINISTRO = 104800001927 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001927)
            {

                /*" -838- MOVE 331,68 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(331.68, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -839- IF SINISMES-NUM-APOL-SINISTRO = 104800001954 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001954)
            {

                /*" -840- MOVE 2988,66 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(2988.66, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -841- IF SINISMES-NUM-APOL-SINISTRO = 104800001951 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001951)
            {

                /*" -842- MOVE 293,85 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(293.85, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -843- IF SINISMES-NUM-APOL-SINISTRO = 104800001926 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001926)
            {

                /*" -844- MOVE 274,80 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(274.80, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -845- IF SINISMES-NUM-APOL-SINISTRO = 104800001929 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800001929)
            {

                /*" -854- MOVE 141,04 TO W-VALOR-PAGO-FINANCEIRO. */
                _.Move(141.04, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);
            }


            /*" -856- IF (W-VALOR-PAGO-FINANCEIRO EQUAL ZERO) OR (W-VALOR-PAGO-FINANCEIRO < ZERO) */

            if ((AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO == 00) || (AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO < 00))
            {

                /*" -857- PERFORM R105-PRIMEIRA-DATA-INDENIZA-1 THRU R105-EXIT */

                R105_PRIMEIRA_DATA_INDENIZA_1(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R105_EXIT*/


                /*" -858- MOVE SINISHIS-DATA-MOVIMENTO TO REG-DATA-INDENIZACAO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, REG_SI0201A.REG_DATA_INDENIZACAO);

                /*" -859- MOVE 0 TO REG-VALOR-INDENIZACAO */
                _.Move(0, REG_SI0201A.REG_VALOR_INDENIZACAO);

                /*" -860- IF W-VALOR-PAGO-FINANCEIRO < ZERO */

                if (AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO < 00)
                {

                    /*" -862- DISPLAY 'SIT 1 - TOT ESTORNO > TOT INDENIZ ' SINISMES-NUM-APOL-SINISTRO */
                    _.Display($"SIT 1 - TOT ESTORNO > TOT INDENIZ {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                    /*" -863- MOVE W-VALOR-TOTAL-PRE-LIBERADO TO W-EDICAO */
                    _.Move(AREA_DE_WORK.W_VALOR_TOTAL_PRE_LIBERADO, AREA_DE_WORK.W_EDICAO);

                    /*" -864- DISPLAY 'TOTAL PRE-LIB.... ' W-EDICAO */
                    _.Display($"TOTAL PRE-LIB.... {AREA_DE_WORK.W_EDICAO}");

                    /*" -865- MOVE W-VALOR-TOTAL-ESTORNADO TO W-EDICAO */
                    _.Move(AREA_DE_WORK.W_VALOR_TOTAL_ESTORNADO, AREA_DE_WORK.W_EDICAO);

                    /*" -866- DISPLAY 'TOTAL LIB........ ' W-EDICAO */
                    _.Display($"TOTAL LIB........ {AREA_DE_WORK.W_EDICAO}");

                    /*" -867- END-IF */
                }


                /*" -871- GO TO R100-GRAVA-REGISTRO. */

                R100_GRAVA_REGISTRO(); //GOTO
                return;
            }


            /*" -882- MOVE 'NAO' TO W-CHAVE-TEM-PLANILHA. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_PLANILHA);

            /*" -884- IF W-CHAVE-TEM-PLANILHA EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_TEM_PLANILHA == "NAO")
            {

                /*" -885- PERFORM R150-PRIMEIRA-DATA-INDENIZA-2 THRU R150-EXIT */

                R150_PRIMEIRA_DATA_INDENIZA_2(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R150_EXIT*/


                /*" -887- MOVE SINISHIS-DATA-MOVIMENTO TO REG-DATA-INDENIZACAO. */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, REG_SI0201A.REG_DATA_INDENIZACAO);
            }


            /*" -888- IF W-CHAVE-TEM-PLANILHA EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_TEM_PLANILHA == "NAO")
            {

                /*" -889- MOVE 0 TO W-PERC-FRANQUIA */
                _.Move(0, AREA_DE_WORK.W_PERC_FRANQUIA);

                /*" -890- IF SINCREIN-COD-AGENCIA EQUAL 9999 */

                if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA == 9999)
                {

                    /*" -891- MOVE 85 TO W-PERC-FRANQUIA */
                    _.Move(85, AREA_DE_WORK.W_PERC_FRANQUIA);

                    /*" -892- ELSE */
                }
                else
                {


                    /*" -893- PERFORM R160-IDENTIFICA-FRANQUIA THRU R160-EXIT */

                    R160_IDENTIFICA_FRANQUIA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/


                    /*" -898- END-IF */
                }


                /*" -899- IF W-PERC-FRANQUIA EQUAL 0 */

                if (AREA_DE_WORK.W_PERC_FRANQUIA == 0)
                {

                    /*" -900- MOVE 0 TO W-VALOR-FRANQUIA */
                    _.Move(0, AREA_DE_WORK.W_VALOR_FRANQUIA);

                    /*" -901- ELSE */
                }
                else
                {


                    /*" -905- COMPUTE W-VALOR-FRANQUIA = ((W-VALOR-PAGO-FINANCEIRO * 100) / W-PERC-FRANQUIA) - W-VALOR-PAGO-FINANCEIRO. */
                    AREA_DE_WORK.W_VALOR_FRANQUIA.Value = ((AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO * 100) / AREA_DE_WORK.W_PERC_FRANQUIA) - AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO;
                }

            }


            /*" -910- COMPUTE W-VALOR-RESSARCIMENTO = W-VALOR-PAGO-FINANCEIRO + W-VALOR-FRANQUIA + W-VALOR-PREMIO. */
            AREA_DE_WORK.W_VALOR_RESSARCIMENTO.Value = AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO + AREA_DE_WORK.W_VALOR_FRANQUIA + AREA_DE_WORK.W_VALOR_PREMIO;

            /*" -911- MOVE W-VALOR-RESSARCIMENTO TO REG-VALOR-RESSARCIMENTO. */
            _.Move(AREA_DE_WORK.W_VALOR_RESSARCIMENTO, REG_SI0201A.REG_VALOR_RESSARCIMENTO);

            /*" -912- MOVE W-VALOR-PAGO-FINANCEIRO TO REG-VALOR-PAGO-FINANCEIRO. */
            _.Move(AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO, REG_SI0201A.REG_VALOR_PAGO_FINANCEIRO);

            /*" -913- MOVE W-VALOR-FRANQUIA TO REG-VALOR-FRANQUIA. */
            _.Move(AREA_DE_WORK.W_VALOR_FRANQUIA, REG_SI0201A.REG_VALOR_FRANQUIA);

            /*" -914- MOVE W-VALOR-PREMIO TO REG-VALOR-PREMIO. */
            _.Move(AREA_DE_WORK.W_VALOR_PREMIO, REG_SI0201A.REG_VALOR_PREMIO);

            /*" -915- MOVE W-VALOR-RESSARCIMENTO TO W-EDICAO-1. */
            _.Move(AREA_DE_WORK.W_VALOR_RESSARCIMENTO, AREA_DE_WORK.W_EDICAO_1);

            /*" -916- MOVE W-VALOR-PAGO-FINANCEIRO TO W-EDICAO-2. */
            _.Move(AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO, AREA_DE_WORK.W_EDICAO_2);

            /*" -917- MOVE W-VALOR-FRANQUIA TO W-EDICAO-3. */
            _.Move(AREA_DE_WORK.W_VALOR_FRANQUIA, AREA_DE_WORK.W_EDICAO_3);

            /*" -924- MOVE W-VALOR-PREMIO TO W-EDICAO-4. */
            _.Move(AREA_DE_WORK.W_VALOR_PREMIO, AREA_DE_WORK.W_EDICAO_4);

            /*" -924- MOVE W-VALOR-RESSARCIMENTO TO REG-VALOR-INDENIZACAO. */
            _.Move(AREA_DE_WORK.W_VALOR_RESSARCIMENTO, REG_SI0201A.REG_VALOR_INDENIZACAO);

        }

        [StopWatch]
        /*" R100-GRAVA-REGISTRO */
        private void R100_GRAVA_REGISTRO(bool isPerform = false)
        {
            /*" -931- INSPECT REG-SI0201A CONVERTING LOW-VALUE TO ' ' . */
            if (REG_SI0201A.IsEmpty())
            {
                _.Initialize(REG_SI0201A);
            }

            /*" -933- WRITE REG-SI0201A. */
            SI0201A.Write(REG_SI0201A.GetMoveValues().ToString());

            /*" -933- PERFORM R031-FETCH-SINISHIS THRU R031-EXIT. */

            R031_FETCH_SINISHIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R160-IDENTIFICA-FRANQUIA */
        private void R160_IDENTIFICA_FRANQUIA(bool isPerform = false)
        {
            /*" -952- IF (SINISMES-COD-PRODUTO NOT EQUAL 4800) AND (SINISMES-COD-PRODUTO NOT EQUAL 4802) AND (SINISMES-COD-PRODUTO NOT EQUAL 4803) AND (SINISMES-COD-PRODUTO NOT EQUAL 4805) AND (SINISMES-COD-PRODUTO NOT EQUAL 4807) AND (SINISMES-COD-PRODUTO NOT EQUAL 4809) AND (SINISMES-COD-PRODUTO NOT EQUAL 4810) AND (SINISMES-COD-PRODUTO NOT EQUAL 4899) AND (SINISMES-COD-PRODUTO NOT EQUAL 6007) AND (SINISMES-COD-PRODUTO NOT EQUAL 7009) */

            if ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO != 4800) && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO != 4802) && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO != 4803) && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO != 4805) && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO != 4807) && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO != 4809) && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO != 4810) && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO != 4899) && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO != 6007) && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO != 7009))
            {

                /*" -954- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -955- DISPLAY '* AVISE AO ANALISTA RESPONSAVEL A MENSAGEM ABAIX' */
                _.Display($"* AVISE AO ANALISTA RESPONSAVEL A MENSAGEM ABAIX");

                /*" -957- DISPLAY '* ' */
                _.Display($"* ");

                /*" -958- DISPLAY '* VAI MOVER ZERO PARA O % DE FRANQUIA       ' */
                _.Display($"* VAI MOVER ZERO PARA O % DE FRANQUIA       ");

                /*" -959- DISPLAY '* PROCESSANDO CODIGO DE PRODUTO NAO PREVISTO' */
                _.Display($"* PROCESSANDO CODIGO DE PRODUTO NAO PREVISTO");

                /*" -960- DISPLAY '* ' */
                _.Display($"* ");

                /*" -961- DISPLAY '* SIN...' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"* SIN...{SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -962- DISPLAY '* PRODUTO NAO PREVISTO = ' SINISMES-COD-PRODUTO */
                _.Display($"* PRODUTO NAO PREVISTO = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

                /*" -964- DISPLAY '* ' */
                _.Display($"* ");

                /*" -966- END-IF. */
            }


            /*" -968- MOVE 0 TO W-PERC-FRANQUIA */
            _.Move(0, AREA_DE_WORK.W_PERC_FRANQUIA);

            /*" -969- IF SINISMES-COD-PRODUTO EQUAL 4899 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4899)
            {

                /*" -970- MOVE 85 TO W-PERC-FRANQUIA */
                _.Move(85, AREA_DE_WORK.W_PERC_FRANQUIA);

                /*" -972- GO TO R160-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/ //GOTO
                return;
            }


            /*" -975- IF SINISMES-COD-PRODUTO EQUAL 4800 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4800)
            {

                /*" -976- IF SINCREIN-COD-OPERACAO EQUAL 152 OR 649 */

                if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("152", "649"))
                {

                    /*" -977- MOVE 90 TO W-PERC-FRANQUIA */
                    _.Move(90, AREA_DE_WORK.W_PERC_FRANQUIA);

                    /*" -978- ELSE */
                }
                else
                {


                    /*" -981- IF SINCREIN-COD-OPERACAO EQUAL 20 OR 652 OR 653 OR 692 OR 701 OR 703 OR 999 */

                    if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("20", "652", "653", "692", "701", "703", "999"))
                    {

                        /*" -982- MOVE 85 TO W-PERC-FRANQUIA */
                        _.Move(85, AREA_DE_WORK.W_PERC_FRANQUIA);

                        /*" -984- ELSE */
                    }
                    else
                    {


                        /*" -985- IF SINCREIN-COD-OPERACAO EQUAL 105 OR 106 OR 110 */

                        if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("105", "106", "110"))
                        {

                            /*" -986- MOVE 90 TO W-PERC-FRANQUIA */
                            _.Move(90, AREA_DE_WORK.W_PERC_FRANQUIA);

                            /*" -987- ELSE */
                        }
                        else
                        {


                            /*" -988- IF SINCREIN-COD-OPERACAO EQUAL 149 OR 150 OR 151 */

                            if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("149", "150", "151"))
                            {

                                /*" -989- MOVE 90 TO W-PERC-FRANQUIA */
                                _.Move(90, AREA_DE_WORK.W_PERC_FRANQUIA);

                                /*" -990- ELSE */
                            }
                            else
                            {


                                /*" -991- IF SINCREIN-COD-OPERACAO EQUAL 650 */

                                if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO == 650)
                                {

                                    /*" -992- MOVE 90 TO W-PERC-FRANQUIA */
                                    _.Move(90, AREA_DE_WORK.W_PERC_FRANQUIA);

                                    /*" -993- ELSE */
                                }
                                else
                                {


                                    /*" -994- IF SINCREIN-COD-OPERACAO EQUAL 702 */

                                    if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO == 702)
                                    {

                                        /*" -995- MOVE 85 TO W-PERC-FRANQUIA */
                                        _.Move(85, AREA_DE_WORK.W_PERC_FRANQUIA);

                                        /*" -996- ELSE */
                                    }
                                    else
                                    {


                                        /*" -997- IF SINCREIN-COD-OPERACAO EQUAL 704 */

                                        if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO == 704)
                                        {

                                            /*" -998- MOVE 85 TO W-PERC-FRANQUIA */
                                            _.Move(85, AREA_DE_WORK.W_PERC_FRANQUIA);

                                            /*" -1000- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1001- MOVE 0 TO W-PERC-FRANQUIA */
                                            _.Move(0, AREA_DE_WORK.W_PERC_FRANQUIA);

                                            /*" -1003- PERFORM R171-OPERACAO-NAO-PREVISTA THRU R171-EXIT. */

                                            R171_OPERACAO_NAO_PREVISTA(true);
                                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R171_EXIT*/

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -1004- IF SINISMES-COD-PRODUTO EQUAL 4802 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4802)
            {

                /*" -1005- IF SINCREIN-COD-OPERACAO EQUAL 702 OR 704 */

                if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("702", "704"))
                {

                    /*" -1006- MOVE 85 TO W-PERC-FRANQUIA */
                    _.Move(85, AREA_DE_WORK.W_PERC_FRANQUIA);

                    /*" -1007- ELSE */
                }
                else
                {


                    /*" -1009- PERFORM R170-ERRO-PRODUTO-OPERACAO THRU R170-EXIT. */

                    R170_ERRO_PRODUTO_OPERACAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/

                }

            }


            /*" -1010- IF SINISMES-COD-PRODUTO EQUAL 4803 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4803)
            {

                /*" -1011- IF SINCREIN-COD-OPERACAO EQUAL 110 */

                if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO == 110)
                {

                    /*" -1012- MOVE 90 TO W-PERC-FRANQUIA */
                    _.Move(90, AREA_DE_WORK.W_PERC_FRANQUIA);

                    /*" -1013- ELSE */
                }
                else
                {


                    /*" -1015- PERFORM R170-ERRO-PRODUTO-OPERACAO THRU R170-EXIT. */

                    R170_ERRO_PRODUTO_OPERACAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/

                }

            }


            /*" -1016- IF SINISMES-COD-PRODUTO EQUAL 4805 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4805)
            {

                /*" -1018- MOVE 0 TO W-PERC-FRANQUIA. */
                _.Move(0, AREA_DE_WORK.W_PERC_FRANQUIA);
            }


            /*" -1019- IF SINISMES-COD-PRODUTO EQUAL 4807 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4807)
            {

                /*" -1020- IF SINCREIN-COD-OPERACAO EQUAL 107 */

                if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO == 107)
                {

                    /*" -1021- MOVE 90 TO W-PERC-FRANQUIA */
                    _.Move(90, AREA_DE_WORK.W_PERC_FRANQUIA);

                    /*" -1022- ELSE */
                }
                else
                {


                    /*" -1024- PERFORM R170-ERRO-PRODUTO-OPERACAO THRU R170-EXIT. */

                    R170_ERRO_PRODUTO_OPERACAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/

                }

            }


            /*" -1025- IF SINISMES-COD-PRODUTO EQUAL 4809 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4809)
            {

                /*" -1026- IF SINCREIN-COD-OPERACAO EQUAL 171 OR 173 OR 174 */

                if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("171", "173", "174"))
                {

                    /*" -1027- MOVE 85 TO W-PERC-FRANQUIA */
                    _.Move(85, AREA_DE_WORK.W_PERC_FRANQUIA);

                    /*" -1028- ELSE */
                }
                else
                {


                    /*" -1030- PERFORM R170-ERRO-PRODUTO-OPERACAO THRU R170-EXIT. */

                    R170_ERRO_PRODUTO_OPERACAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/

                }

            }


            /*" -1031- IF SINISMES-COD-PRODUTO EQUAL 4810 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4810)
            {

                /*" -1032- IF SINCREIN-COD-OPERACAO EQUAL 731 */

                if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO == 731)
                {

                    /*" -1033- MOVE 85 TO W-PERC-FRANQUIA */
                    _.Move(85, AREA_DE_WORK.W_PERC_FRANQUIA);

                    /*" -1034- ELSE */
                }
                else
                {


                    /*" -1036- PERFORM R170-ERRO-PRODUTO-OPERACAO THRU R170-EXIT. */

                    R170_ERRO_PRODUTO_OPERACAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/

                }

            }


            /*" -1037- IF SINISMES-COD-PRODUTO EQUAL 6007 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 6007)
            {

                /*" -1039- IF SINCREIN-COD-OPERACAO EQUAL 650 OR 690 OR 691 OR 702 OR 704 OR 731 */

                if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("650", "690", "691", "702", "704", "731"))
                {

                    /*" -1040- MOVE ZERO TO W-PERC-FRANQUIA */
                    _.Move(0, AREA_DE_WORK.W_PERC_FRANQUIA);

                    /*" -1041- ELSE */
                }
                else
                {


                    /*" -1043- PERFORM R170-ERRO-PRODUTO-OPERACAO THRU R170-EXIT. */

                    R170_ERRO_PRODUTO_OPERACAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/

                }

            }


            /*" -1044- IF SINISMES-COD-PRODUTO EQUAL 7009 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 7009)
            {

                /*" -1049- IF SINCREIN-COD-OPERACAO EQUAL 105 OR 106 OR 107 OR 110 OR 149 OR 150 OR 171 OR 173 OR 174 OR 190 OR 191 OR 690 OR 691 */

                if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("105", "106", "107", "110", "149", "150", "171", "173", "174", "190", "191", "690", "691"))
                {

                    /*" -1050- MOVE ZERO TO W-PERC-FRANQUIA */
                    _.Move(0, AREA_DE_WORK.W_PERC_FRANQUIA);

                    /*" -1051- ELSE */
                }
                else
                {


                    /*" -1053- PERFORM R170-ERRO-PRODUTO-OPERACAO THRU R170-EXIT. */

                    R170_ERRO_PRODUTO_OPERACAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/

                }

            }


            /*" -1054- IF SINISHIS-DATA-MOVIMENTO GREATER '2005-01-01' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO > "2005-01-01")
            {

                /*" -1054- MOVE ZERO TO W-PERC-FRANQUIA. */
                _.Move(0, AREA_DE_WORK.W_PERC_FRANQUIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/

        [StopWatch]
        /*" R170-ERRO-PRODUTO-OPERACAO */
        private void R170_ERRO_PRODUTO_OPERACAO(bool isPerform = false)
        {
            /*" -1060- DISPLAY '************************************************' */
            _.Display($"************************************************");

            /*" -1061- DISPLAY '* PROGRAMA ABENDADO NA MAO GRANDE' */
            _.Display($"* PROGRAMA ABENDADO NA MAO GRANDE");

            /*" -1062- DISPLAY '* AVISE AO ANALISTA RESPONSAVEL A MENSAGEM ABAIX' */
            _.Display($"* AVISE AO ANALISTA RESPONSAVEL A MENSAGEM ABAIX");

            /*" -1063- DISPLAY '* ' */
            _.Display($"* ");

            /*" -1064- DISPLAY '* PROGRAMA ABENDADO POR QUE O PROGRAMA ESTA ' */
            _.Display($"* PROGRAMA ABENDADO POR QUE O PROGRAMA ESTA ");

            /*" -1065- DISPLAY '* PROCESSANDO CODIGO DE PRODUTO NAO PREVISTO' */
            _.Display($"* PROCESSANDO CODIGO DE PRODUTO NAO PREVISTO");

            /*" -1066- DISPLAY '* ' */
            _.Display($"* ");

            /*" -1067- DISPLAY '* SIN...' SINISMES-NUM-APOL-SINISTRO */
            _.Display($"* SIN...{SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

            /*" -1068- DISPLAY '* PRODUTO NAO PREVISTO  = ' SINISMES-COD-PRODUTO */
            _.Display($"* PRODUTO NAO PREVISTO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

            /*" -1071- DISPLAY '* OPERACAO NAO PREVISTA (1) = ' SINCREIN-COD-OPERACAO */
            _.Display($"* OPERACAO NAO PREVISTA (1) = {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO}");

            /*" -1071- DISPLAY '* ' . */
            _.Display($"* ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/

        [StopWatch]
        /*" R171-OPERACAO-NAO-PREVISTA */
        private void R171_OPERACAO_NAO_PREVISTA(bool isPerform = false)
        {
            /*" -1077- DISPLAY '************************************************' */
            _.Display($"************************************************");

            /*" -1078- DISPLAY '* SINISTRO DE CREDITO COMERCIAL COM CODIGO DE' */
            _.Display($"* SINISTRO DE CREDITO COMERCIAL COM CODIGO DE");

            /*" -1079- DISPLAY '* OPERACAO DO CONTRATO DE CREDITO NAO PREVISTA' */
            _.Display($"* OPERACAO DO CONTRATO DE CREDITO NAO PREVISTA");

            /*" -1080- DISPLAY '* PARA O PERCENTUAL DE FRANQUIA.' */
            _.Display($"* PARA O PERCENTUAL DE FRANQUIA.");

            /*" -1081- DISPLAY '* APENAS DISPLAY. COLOCADO ZERO PARA PERC. FRANQ' */
            _.Display($"* APENAS DISPLAY. COLOCADO ZERO PARA PERC. FRANQ");

            /*" -1082- DISPLAY '* ' */
            _.Display($"* ");

            /*" -1083- DISPLAY '* SIN...' SINISMES-NUM-APOL-SINISTRO */
            _.Display($"* SIN...{SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

            /*" -1086- DISPLAY '* OPERACAO NAO PREVISTA (2) = ' SINCREIN-COD-OPERACAO */
            _.Display($"* OPERACAO NAO PREVISTA (2) = {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO}");

            /*" -1086- DISPLAY '* ' . */
            _.Display($"* ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R171_EXIT*/

        [StopWatch]
        /*" R200-LE-PRE-LIBERACOES */
        private void R200_LE_PRE_LIBERACOES(bool isPerform = false)
        {
            /*" -1095- MOVE 0 TO HOST-TOTAL-PRE-LIBERACAO HOST-TOTAL-CANC-PRE-LIBERACAO. */
            _.Move(0, AREA_DE_WORK.HOST_TOTAL_PRE_LIBERACAO, AREA_DE_WORK.HOST_TOTAL_CANC_PRE_LIBERACAO);

            /*" -1097- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", WABEND.WNR_EXEC_SQL);

            /*" -1113- PERFORM R200_LE_PRE_LIBERACOES_DB_SELECT_1 */

            R200_LE_PRE_LIBERACOES_DB_SELECT_1();

            /*" -1116- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1117- DISPLAY 'ERRO NO SELECT SUM(H.VAL_OPERACAO) - (2).' */
                _.Display($"ERRO NO SELECT SUM(H.VAL_OPERACAO) - (2).");

                /*" -1118- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1120- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1122- GO TO R200-PULA-CANCELAMENTO. */

            R200_PULA_CANCELAMENTO(); //GOTO
            return;


        }

        [StopWatch]
        /*" R200-LE-PRE-LIBERACOES-DB-SELECT-1 */
        public void R200_LE_PRE_LIBERACOES_DB_SELECT_1()
        {
            /*" -1113- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :HOST-TOTAL-PRE-LIBERACAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO O WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.FUNCAO_OPERACAO = 'PRE' AND NOT EXISTS (SELECT 1 FROM SEGUROS.SINISTRO_HISTORICO K WHERE K.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND K.OCORR_HISTORICO = H.OCORR_HISTORICO AND K.COD_OPERACAO IN (1191,1192,1193,1194,1091,1092,1093,1094) ) WITH UR END-EXEC. */

            var r200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1 = new R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1.Execute(r200_LE_PRE_LIBERACOES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_TOTAL_PRE_LIBERACAO, AREA_DE_WORK.HOST_TOTAL_PRE_LIBERACAO);
            }


        }

        [StopWatch]
        /*" R200-PULA-CANCELAMENTO */
        private void R200_PULA_CANCELAMENTO(bool isPerform = false)
        {
            /*" -1144- COMPUTE SINISHIS-VAL-OPERACAO = HOST-TOTAL-PRE-LIBERACAO + HOST-TOTAL-CANC-PRE-LIBERACAO. */
            SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = AREA_DE_WORK.HOST_TOTAL_PRE_LIBERACAO + AREA_DE_WORK.HOST_TOTAL_CANC_PRE_LIBERACAO;

        }

        [StopWatch]
        /*" R200-LE-PRE-LIBERACOES-DB-SELECT-2 */
        public void R200_LE_PRE_LIBERACOES_DB_SELECT_2()
        {
            /*" -1134- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO * -1),0) INTO :HOST-TOTAL-CANC-PRE-LIBERACAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO O WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.FUNCAO_OPERACAO = 'CPRE' WITH UR END-EXEC. */

            var r200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1 = new R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1.Execute(r200_LE_PRE_LIBERACOES_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_TOTAL_CANC_PRE_LIBERACAO, AREA_DE_WORK.HOST_TOTAL_CANC_PRE_LIBERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R210-LE-ESTORNO */
        private void R210_LE_ESTORNO(bool isPerform = false)
        {
            /*" -1152- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", WABEND.WNR_EXEC_SQL);

            /*" -1164- PERFORM R210_LE_ESTORNO_DB_SELECT_1 */

            R210_LE_ESTORNO_DB_SELECT_1();

            /*" -1167- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1168- DISPLAY 'ERRO NO SELECT SUM(H.VAL_OPERACAO) - (1).' */
                _.Display($"ERRO NO SELECT SUM(H.VAL_OPERACAO) - (1).");

                /*" -1169- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1169- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R210-LE-ESTORNO-DB-SELECT-1 */
        public void R210_LE_ESTORNO_DB_SELECT_1()
        {
            /*" -1164- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_SIS_FUNCAO_OPER O WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.NUM_FATOR = -1 WITH UR END-EXEC. */

            var r210_LE_ESTORNO_DB_SELECT_1_Query1 = new R210_LE_ESTORNO_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R210_LE_ESTORNO_DB_SELECT_1_Query1.Execute(r210_LE_ESTORNO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/

        [StopWatch]
        /*" R105-PRIMEIRA-DATA-INDENIZA-1 */
        private void R105_PRIMEIRA_DATA_INDENIZA_1(bool isPerform = false)
        {
            /*" -1177- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", WABEND.WNR_EXEC_SQL);

            /*" -1178- MOVE '9999-12-31' TO SINISHIS-DATA-MOVIMENTO. */
            _.Move("9999-12-31", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);

            /*" -1191- PERFORM R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1 */

            R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1();

            /*" -1194- IF SINISMES-NUM-APOL-SINISTRO = 104800041631 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800041631)
            {

                /*" -1196- DISPLAY 'SIN DATA - ' SINISMES-NUM-APOL-SINISTRO ' ' SINISHIS-DATA-MOVIMENTO. */

                $"SIN DATA - {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO}"
                .Display();
            }


            /*" -1197- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1198- DISPLAY 'ERRO NO SELECT MIN(H.DATA_MOVIMENTO).....' */
                _.Display($"ERRO NO SELECT MIN(H.DATA_MOVIMENTO).....");

                /*" -1199- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1199- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R105-PRIMEIRA-DATA-INDENIZA-1-DB-SELECT-1 */
        public void R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1()
        {
            /*" -1191- EXEC SQL SELECT MIN(H.DATA_MOVIMENTO) INTO :SINISHIS-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_SIS_FUNCAO_OPER O WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.NUM_FATOR = 1 WITH UR END-EXEC. */

            var r105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1 = new R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1.Execute(r105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R105_EXIT*/

        [StopWatch]
        /*" R150-PRIMEIRA-DATA-INDENIZA-2 */
        private void R150_PRIMEIRA_DATA_INDENIZA_2(bool isPerform = false)
        {
            /*" -1247- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", WABEND.WNR_EXEC_SQL);

            /*" -1261- PERFORM R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1 */

            R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1();

            /*" -1264- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1265- DISPLAY 'ERRO NO SELECT MIN(H.DATA_MOVIMENTO).....' */
                _.Display($"ERRO NO SELECT MIN(H.DATA_MOVIMENTO).....");

                /*" -1266- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1266- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R150-PRIMEIRA-DATA-INDENIZA-2-DB-SELECT-1 */
        public void R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1()
        {
            /*" -1261- EXEC SQL SELECT MIN(H.DATA_MOVIMENTO) INTO :SINISHIS-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_SIS_FUNCAO_OPER O WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.NUM_FATOR = 1 WITH UR END-EXEC. */

            var r150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1 = new R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1.Execute(r150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R150_EXIT*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_SELECT_AGENCIAS*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R121-SELECT-AGENCIAS */
        private void R121_SELECT_AGENCIAS(bool isPerform = false)
        {
            /*" -1331- INITIALIZE DCLUNIDADE-CEF. */
            _.Initialize(
                UNIDACEF.DCLUNIDADE_CEF
            );

            /*" -1333- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", WABEND.WNR_EXEC_SQL);

            /*" -1341- PERFORM R121_SELECT_AGENCIAS_DB_SELECT_1 */

            R121_SELECT_AGENCIAS_DB_SELECT_1();

            /*" -1344- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1345- MOVE UNIDACEF-CIDADE TO REG-CIDADE-SINISTRO */
                _.Move(UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_CIDADE, REG_SI0201A.REG_CIDADE_SINISTRO);

                /*" -1347- MOVE UNIDACEF-UF TO REG-UF-SINISTRO. */
                _.Move(UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_UF, REG_SI0201A.REG_UF_SINISTRO);
            }


            /*" -1348- IF SQLCODE EQUAL 100 OR UNIDACEF-UF EQUAL SPACES */

            if (DB.SQLCODE == 100 || UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_UF.IsEmpty())
            {

                /*" -1349- MOVE 'DF' TO REG-UF-SINISTRO */
                _.Move("DF", REG_SI0201A.REG_UF_SINISTRO);

                /*" -1351- MOVE 'BRASILIA' TO REG-CIDADE-SINISTRO. */
                _.Move("BRASILIA", REG_SI0201A.REG_CIDADE_SINISTRO);
            }


            /*" -1352- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1353- DISPLAY 'ERRO ACESSO AGENCIAS P/ BUSCA DA UF DA AGENCIA' */
                _.Display($"ERRO ACESSO AGENCIAS P/ BUSCA DA UF DA AGENCIA");

                /*" -1354- DISPLAY 'SI0201B - AGENCIA NA TAB. UNIDADE_CEF' */
                _.Display($"SI0201B - AGENCIA NA TAB. UNIDADE_CEF");

                /*" -1355- DISPLAY 'COD AGENCIA: ' SINCREIN-COD-AGENCIA */
                _.Display($"COD AGENCIA: {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA}");

                /*" -1355- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R121-SELECT-AGENCIAS-DB-SELECT-1 */
        public void R121_SELECT_AGENCIAS_DB_SELECT_1()
        {
            /*" -1341- EXEC SQL SELECT CIDADE, UF INTO :UNIDACEF-CIDADE, :UNIDACEF-UF FROM SEGUROS.UNIDADE_CEF WHERE COD_UNIDADE = :SINCREIN-COD-AGENCIA WITH UR END-EXEC. */

            var r121_SELECT_AGENCIAS_DB_SELECT_1_Query1 = new R121_SELECT_AGENCIAS_DB_SELECT_1_Query1()
            {
                SINCREIN_COD_AGENCIA = SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA.ToString(),
            };

            var executed_1 = R121_SELECT_AGENCIAS_DB_SELECT_1_Query1.Execute(r121_SELECT_AGENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.UNIDACEF_CIDADE, UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_CIDADE);
                _.Move(executed_1.UNIDACEF_UF, UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R121_EXIT*/

        [StopWatch]
        /*" R130-LE-APOLICRE */
        private void R130_LE_APOLICRE(bool isPerform = false)
        {
            /*" -1363- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", WABEND.WNR_EXEC_SQL);

            /*" -1377- PERFORM R130_LE_APOLICRE_DB_SELECT_1 */

            R130_LE_APOLICRE_DB_SELECT_1();

            /*" -1380- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1381- GO TO R130-LE-SINISTRO-ITEM */

                R130_LE_SINISTRO_ITEM(); //GOTO
                return;

                /*" -1382- ELSE */
            }
            else
            {


                /*" -1383- MOVE APOLICRE-PROPRIET TO REG-NOME-SEGURADO */
                _.Move(APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET, REG_SI0201A.REG_NOME_SEGURADO);

                /*" -1384- MOVE APOLICRE-CGCCPF TO REG-CIC-DEVEDOR */
                _.Move(APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_CGCCPF, REG_SI0201A.REG_CIC_DEVEDOR);

                /*" -1384- GO TO R130-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R130-LE-APOLICRE-DB-SELECT-1 */
        public void R130_LE_APOLICRE_DB_SELECT_1()
        {
            /*" -1377- EXEC SQL SELECT B.PROPRIET, B.CGCCPF INTO :APOLICRE-PROPRIET, :APOLICRE-CGCCPF FROM SEGUROS.SINISTRO_CRED_INT A, SEGUROS.APOLICE_CREDITO B WHERE A.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND B.COD_SUREG = A.COD_SUREG AND B.COD_AGENCIA = A.COD_AGENCIA AND B.COD_OPERACAO = A.COD_OPERACAO AND B.NUM_CONTRATO = A.NUM_CONTRATO AND B.CONTRATO_DIGITO = A.CONTRATO_DIGITO WITH UR END-EXEC. */

            var r130_LE_APOLICRE_DB_SELECT_1_Query1 = new R130_LE_APOLICRE_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R130_LE_APOLICRE_DB_SELECT_1_Query1.Execute(r130_LE_APOLICRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICRE_PROPRIET, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET);
                _.Move(executed_1.APOLICRE_CGCCPF, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_CGCCPF);
            }


        }

        [StopWatch]
        /*" R130-LE-SINISTRO-ITEM */
        private void R130_LE_SINISTRO_ITEM(bool isPerform = false)
        {
            /*" -1390- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", WABEND.WNR_EXEC_SQL);

            /*" -1400- PERFORM R130_LE_SINISTRO_ITEM_DB_SELECT_1 */

            R130_LE_SINISTRO_ITEM_DB_SELECT_1();

            /*" -1403- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1404- MOVE 'NAO IDENTIFICADO' TO REG-NOME-SEGURADO */
                _.Move("NAO IDENTIFICADO", REG_SI0201A.REG_NOME_SEGURADO);

                /*" -1405- MOVE 999999999999999 TO REG-CIC-DEVEDOR */
                _.Move(999999999999999, REG_SI0201A.REG_CIC_DEVEDOR);

                /*" -1406- ELSE */
            }
            else
            {


                /*" -1407- MOVE CLIENTES-NOME-RAZAO TO REG-NOME-SEGURADO */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REG_SI0201A.REG_NOME_SEGURADO);

                /*" -1407- MOVE CLIENTES-CGCCPF TO REG-CIC-DEVEDOR. */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, REG_SI0201A.REG_CIC_DEVEDOR);
            }


        }

        [StopWatch]
        /*" R130-LE-SINISTRO-ITEM-DB-SELECT-1 */
        public void R130_LE_SINISTRO_ITEM_DB_SELECT_1()
        {
            /*" -1400- EXEC SQL SELECT B.NOME_RAZAO, B.CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.SINISTRO_ITEM A, SEGUROS.CLIENTES B WHERE A.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND B.COD_CLIENTE = A.COD_CLIENTE WITH UR END-EXEC. */

            var r130_LE_SINISTRO_ITEM_DB_SELECT_1_Query1 = new R130_LE_SINISTRO_ITEM_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R130_LE_SINISTRO_ITEM_DB_SELECT_1_Query1.Execute(r130_LE_SINISTRO_ITEM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK */
        private void R10010199_MENSAGEM_LOCK(bool isPerform = false)
        {
            /*" -1417- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1420- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -1423- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1426- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE. */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -1429- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1432- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1435- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE. */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -1438- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE. */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -1441- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' UPON CONSOLE. */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -1445- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE. */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -1448- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1451- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' UPON CONSOLE. */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -1454- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1457- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1460- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE. */
            _.Display($"*     SQLCODE DO ABEND ....... {WABEND.WSQLCODE}");

            /*" -1463- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1469- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -1471- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1473- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1475- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -1477- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1479- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1481- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -1483- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -1485- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -1487- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -1489- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1491- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -1493- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1495- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1497- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1499- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {WABEND.WSQLCODE}");

            /*" -1501- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1501- GO TO R9999-00-ROT-ERRO. */

            R9999_00_ROT_ERRO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010199_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -1511- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1512- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1513- DISPLAY SQLERRMC. */
            _.Display(DB.SQLERRMC);

            /*" -1513- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1514- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1516- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1517- CLOSE SI0201A. */
            SI0201A.Close();

            /*" -1517- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_EXIT*/
    }
}