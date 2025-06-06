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
using Sias.Sinistro.DB2.SI0202B;

namespace Code
{
    public class SI0202B
    {
        public bool IsCall { get; set; }

        public SI0202B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------------------------------  *      */
        /*"      *--------------------------------------------------------------  *      */
        /*"      *   SISTEMA ................  SINISTRO/RESSARCIMENTO             *      */
        /*"      *   PROGRAMA ...............  SI0202B                            *      */
        /*"      *--------------------------------------------------------------  *      */
        /*"      *   ANALISTA ...............  HEIDER                             *      */
        /*"      *   PROGRAMADOR ............  HEIDER                             *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO/2002                       *      */
        /*"      *--------------------------------------------------------------  *      */
        /*"      *   FUNCAO .................  GERACAO DO MOVIMENTO DE SINISTRO   *      */
        /*"      *                                                                *      */
        /*"      * ATENCAO - ESTA VERSAO PASSA A VIGORAR A PARTIR DE 24/11/05     *      */
        /*"      *                                                                *      */
        /*"      *       PARA O SISTEMA DE RESSARCIMENTO => CREDMAC (MAT CONST)   *      */
        /*"      *   A PARTIR DE 24/11/05 - PASSOU A ENVIA O VALOR TOTAL A SER    *      */
        /*"      *   RESSARCIDO PARA O RESSARCIMENTOWEB.O RESSARCIMENTOWEB PARA   *      */
        /*"      *   DE EFETUAR QUALQUER ACRESCIMO AO VALOR A ELE INFORMADO       *      */
        /*"      *--------------------------------------------------------------  *      */
        /*"      *  M A N U T E N C A O  ( O R D E M  D E C R E S C E N T E )     *      */
        /*"      *--------------------------------------------------------------  *      */
        /*"      *  Avaliado pelo projeto JV1 em 15/01/2019                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.08  *   VERSAO 08 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.08    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.07  * CADMUS          70068 - 22/05/2012 - PROCURAR: V.07            *      */
        /*"      *                                                                *      */
        /*"      * ANALISTA: DIOGO MATHEUS                                        *      */
        /*"      * 1- SELECIONAR APENAS UM CODIGO OPERACAO DE SINISTRO PAGO /     *      */
        /*"      *    ESTORNADA.                                                  *      */
        /*"      *                                                                *      */
        /*"      *--------------------------------------------------------------*        */
        /*"V.06  * CADMUS          33880 - 10/12/2009 - PROCURAR: V.06            *      */
        /*"      *                                                                *      */
        /*"      * ANALISTA: HEIDER COELHO                                        *      */
        /*"      * 1- PARA CADA EXECUCAO DIARIA SELECIONAR TODOS OS SINISTROS     *      */
        /*"      *    INDENIZADOS NOS ULTIMOS 5 DIAS UTEIS A DATA_MOV_ABERTO DO   *      */
        /*"      *    SINISTRO => OU <= SE HOUVER ESTORNO                         *      */
        /*"      *                                                                *      */
        /*"      *--------------------------------------------------------------*        */
        /*"      *                                                                *      */
        /*"V.05  * CADMUS 33.846 E 34286 - 10/12/2009 - PROCURAR: V.05            *      */
        /*"      *                                                                *      */
        /*"      * ANALISTA: HEIDER COELHO                                        *      */
        /*"      * 1- CONSIDERAR ZERO NO % DE FRANQUIA SE A OPERACAO DO CONTRATO  *      */
        /*"      *    DE CREDITO NAO ESTIVER DEFINIDA                             *      */
        /*"      * 2- EXCLUIR DO PROCESSAMENTO TODOS OS MOVIMENTOS GERADOS PELO   *      */
        /*"      *    PROGRAMA SI0170B - AJUSTE CONTABIL DO PREMIO DE MATCON      *      */
        /*"      *                                                                *      */
        /*"      *--------------------------------------------------------------*        */
        /*"      *                                                                *      */
        /*"V.04  * CADMUS 31.731 - 27/10/2009 - PROCURAR: V.04                    *      */
        /*"      * ANALISTA: HEIDER COELHO                                        *      */
        /*"      *    ALTERACAO DAS DATAS DE SELECAO DOS SINISTROS INDENIZADOS    *      */
        /*"      *    PARA CARGA NO RESSARCIMENTOWEB                              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.03  * CADMUS 30.616 - 14/10/2009 - PROCURAR: V.03                    *      */
        /*"      * ANALISTA: HEIDER COELHO                                        *      */
        /*"      *    OS PRODUTOS 6008 E 6009 NAO DEVERAO SER ENVIADOS PARA O     *      */
        /*"      *    SISTEMA DE RESSARCIMENTO                                    *      */
        /*"      *                                                                *      */
        /*"V.02  * 20/08/2009 - HEIDER COELHO - PROCURAR V.02                   *        */
        /*"      *            BAIXAR NA MAO GRANDE O SINISTRO 107000151409               */
        /*"      *            A PEDIDO DA GEREA - SSI 25468                     *        */
        /*"      *--------------------------------------------------------------*        */
        /*"V.01  * 20/02/2009 - POLITEC - GEORGES DA MATA CLAESSEN              *        */
        /*"      *            - PROCURAR POR V.01                               *        */
        /*"      *            - MANUTENCAO PARA MODIFICAR A FORMA DE OBTER      *        */
        /*"      *              ENDERECOS. A PARTIR DE AGORA, A SELECAO TAMBEM  *        */
        /*"      *              EH FEITA NA BASE DO EF. TAMBEM E REALIZADA NA   *        */
        /*"      *              NA BASE DO HABITACIONAL                         *        */
        /*"      *              A ROTINA EH A SI0202S COM A BOOK LBSI0202       *        */
        /*"      *--------------------------------------------------------------*        */
        /*"      * 11/01/2008 - HEIDER                                          *        */
        /*"      *            O HEIDER RETORNO O PROCESSO ANTIGO DE TRAZER      *        */
        /*"      * VALOR DA INDENIZACAO + FRANQUIA + PREMIOS REMANESCENTES      *        */
        /*"      * + PREMIOS_REMANESCENTES.                                     *        */
        /*"      *--------------------------------------------------------------*        */
        /*"      * 25/12/2007 - JEFFERSON                                       *        */
        /*"      * MUDOU A FORMA DE TRAZER O VALOR DA INDENIZACAO + FRANQUIA CER*        */
        /*"      * + PREMIOS_REMANESCENTES.                                     *        */
        /*"      *--------------------------------------------------------------*        */
        /*"      * 06/06/2006 - ALEXIS VEAS ITURRIAGA                           *        */
        /*"      * INCLUIDO OS CAMPOS DE PREMIO, FRANQUIA, RESSARCIMENTO E      *        */
        /*"      * VALOR FINANCEIRO.                                            *        */
        /*"      *--------------------------------------------------------------*        */
        /*"      * 30/05/2005 - PRODEXTER                                       *        */
        /*"      * (1) SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA           *        */
        /*"      *     GE_OPERACAO                                              *        */
        /*"      * (2) SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A *        */
        /*"      * SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO   *        */
        /*"      *--------------------------------------------------------------*        */
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
        /*"      *--------------------------------------------------------------*        */
        #endregion


        #region VARIABLES

        public FileBasis _SIH202A { get; set; } = new FileBasis(new PIC("X", "600", "X(600)"));

        public FileBasis SIH202A
        {
            get
            {
                _.Move(REG_SIH202A, _SIH202A); VarBasis.RedefinePassValue(REG_SIH202A, _SIH202A, REG_SIH202A); return _SIH202A;
            }
        }
        /*"01  REG-SIH202A.*/
        public SI0202B_REG_SIH202A REG_SIH202A { get; set; } = new SI0202B_REG_SIH202A();
        public class SI0202B_REG_SIH202A : VarBasis
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
        /*"77  HOST-DATA-INICIO-INDENIZACAO   PIC  X(10)    VALUE SPACES.*/
        public StringBasis HOST_DATA_INICIO_INDENIZACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-DATA-INICIO-SELECAO          PIC  X(10)    VALUE SPACES.*/
        public StringBasis W_DATA_INICIO_SELECAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-DATA-FIM-SELECAO             PIC  X(10)    VALUE SPACES.*/
        public StringBasis W_DATA_FIM_SELECAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-GRAVADOS                     PIC  9(05)    VALUE ZEROS.*/
        public IntBasis W_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
        /*"77  W-SI0202S                      PIC X(07)  VALUE 'SI0202S'.*/
        public StringBasis W_SI0202S { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI0202S");
        /*"01  AREA-DE-WORK.*/
        public SI0202B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0202B_AREA_DE_WORK();
        public class SI0202B_AREA_DE_WORK : VarBasis
        {
            /*"  05 WFIM-SINISHIS                 PIC X(03)  VALUE 'NAO'.*/
            public StringBasis WFIM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
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
            public DoubleBasis W_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
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
            /*"  05 W-CHAVE-TEM-PLANILHA          PIC  X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_TEM_PLANILHA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05 W-DATA-AAAAMMDD.*/
            public SI0202B_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new SI0202B_W_DATA_AAAAMMDD();
            public class SI0202B_W_DATA_AAAAMMDD : VarBasis
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
            public SI0202B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new SI0202B_W_DATA_DD_MM_AAAA();
            public class SI0202B_W_DATA_DD_MM_AAAA : VarBasis
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
        public SI0202B_WABEND WABEND { get; set; } = new SI0202B_WABEND();
        public class SI0202B_WABEND : VarBasis
        {
            /*"    10 FILLER              PIC  X(008) VALUE       'SI0202B '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SI0202B ");
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
        public SI0202B_LINK_PARM_DE_EXECUCAO LINK_PARM_DE_EXECUCAO { get; set; } = new SI0202B_LINK_PARM_DE_EXECUCAO();
        public class SI0202B_LINK_PARM_DE_EXECUCAO : VarBasis
        {
            /*"    05 TAMANHO-PARM                PIC S9(04) COMP.*/
            public IntBasis TAMANHO_PARM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PARM-FORMA-EXECUCAO         PIC  X(03)     .*/
            public StringBasis PARM_FORMA_EXECUCAO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    05 PARM-STRING-PARM            PIC  X(70)     .*/
            public StringBasis PARM_STRING_PARM { get; set; } = new StringBasis(new PIC("X", "70", "X(70)"), @"");
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Copies.LBSI0202 LBSI0202 { get; set; } = new Copies.LBSI0202();
        public Dclgens.RALCHEDO RALCHEDO { get; set; } = new Dclgens.RALCHEDO();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
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
        public Dclgens.ENDHABIT ENDHABIT { get; set; } = new Dclgens.ENDHABIT();
        public Dclgens.SINIPLAN SINIPLAN { get; set; } = new Dclgens.SINIPLAN();
        public SI0202B_XXXXX XXXXX { get; set; } = new SI0202B_XXXXX();
        public SI0202B_C01_SINISHIS C01_SINISHIS { get; set; } = new SI0202B_C01_SINISHIS();
        public SI0202B_YYY YYY { get; set; } = new SI0202B_YYY();
        public SI0202B_XXX XXX { get; set; } = new SI0202B_XXX();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SI0202B_LINK_PARM_DE_EXECUCAO SI0202B_LINK_PARM_DE_EXECUCAO_P, string SIH202A_FILE_NAME_P) //PROCEDURE DIVISION USING 
        /*LINK_PARM_DE_EXECUCAO*/
        {
            try
            {
                this.LINK_PARM_DE_EXECUCAO = SI0202B_LINK_PARM_DE_EXECUCAO_P;
                SIH202A.SetFile(SIH202A_FILE_NAME_P);

                /*" -340- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -341- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -342- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -352- INITIALIZE SI0202S-LOGRADOURO SI0202S-BAIRRO SI0202S-CIDADE SI0202S-UF SI0202S-CEP. */
                _.Initialize(
                    LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_LOGRADOURO
                    , LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_BAIRRO
                    , LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CIDADE
                    , LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_UF
                    , LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CEP
                );

                /*" -356- PERFORM R010-SELECT-SISTEMAS THRU R010-EXIT. */

                R010_SELECT_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -357- DISPLAY '*************************************************' */
                _.Display($"*************************************************");

                /*" -358- DISPLAY '*                                               *' */
                _.Display($"*                                               *");

                /*" -360- DISPLAY '* PARAMETRO DE EXECUCAO ==>' PARM-FORMA-EXECUCAO '<== * ' */

                $"* PARAMETRO DE EXECUCAO ==>{LINK_PARM_DE_EXECUCAO.PARM_FORMA_EXECUCAO}<== * "
                .Display();

                /*" -361- DISPLAY '* TODO O REGISTRO ==>' LINK-PARM-DE-EXECUCAO */
                _.Display($"* TODO O REGISTRO ==>{LINK_PARM_DE_EXECUCAO}");

                /*" -363- DISPLAY '*                                               *' */
                _.Display($"*                                               *");

                /*" -365- IF (PARM-FORMA-EXECUCAO NOT EQUAL '111' ) AND (PARM-FORMA-EXECUCAO NOT EQUAL '222' ) */

                if ((LINK_PARM_DE_EXECUCAO.PARM_FORMA_EXECUCAO != "111") && (LINK_PARM_DE_EXECUCAO.PARM_FORMA_EXECUCAO != "222"))
                {

                    /*" -366- DISPLAY '*                                               *' */
                    _.Display($"*                                               *");

                    /*" -367- DISPLAY '* PARAMETRO INVALIDO. SERA ASSUMIDO PARAMETRO   *' */
                    _.Display($"* PARAMETRO INVALIDO. SERA ASSUMIDO PARAMETRO   *");

                    /*" -368- DISPLAY '* PARA EXECUCAO POR DIAS UTEIS.                 *' */
                    _.Display($"* PARA EXECUCAO POR DIAS UTEIS.                 *");

                    /*" -369- DISPLAY '*                                               *' */
                    _.Display($"*                                               *");

                    /*" -370- MOVE '111' TO PARM-FORMA-EXECUCAO */
                    _.Move("111", LINK_PARM_DE_EXECUCAO.PARM_FORMA_EXECUCAO);

                    /*" -371- ELSE */
                }
                else
                {


                    /*" -372- DISPLAY '* PARAMETRO CORRETO.                            *' */
                    _.Display($"* PARAMETRO CORRETO.                            *");

                    /*" -373- IF PARM-FORMA-EXECUCAO EQUAL '111' */

                    if (LINK_PARM_DE_EXECUCAO.PARM_FORMA_EXECUCAO == "111")
                    {

                        /*" -374- DISPLAY '* VAI PROCESSAR PELA REGRA DE DIAS UTEIS        *' */
                        _.Display($"* VAI PROCESSAR PELA REGRA DE DIAS UTEIS        *");

                        /*" -375- ELSE */
                    }
                    else
                    {


                        /*" -376- DISPLAY '* VAI PROCESSAR TODO O ESTOQUE                  *' */
                        _.Display($"* VAI PROCESSAR TODO O ESTOQUE                  *");

                        /*" -377- DISPLAY '*                                               *' */
                        _.Display($"*                                               *");

                        /*" -381- END-IF. */
                    }

                }


                /*" -383- PERFORM R020-ACHA-DATA-HOJE-MENOS-10 THRU R020-EXIT */

                R020_ACHA_DATA_HOJE_MENOS_10(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -384- IF PARM-FORMA-EXECUCAO EQUAL '222' */

                if (LINK_PARM_DE_EXECUCAO.PARM_FORMA_EXECUCAO == "222")
                {

                    /*" -385- MOVE '1900-01-01' TO W-DATA-INICIO-SELECAO */
                    _.Move("1900-01-01", W_DATA_INICIO_SELECAO);

                    /*" -387- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-FIM-SELECAO. */
                    _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W_DATA_FIM_SELECAO);
                }


                /*" -388- DISPLAY ' ' */
                _.Display($" ");

                /*" -389- DISPLAY '*************************************************' */
                _.Display($"*************************************************");

                /*" -390- DISPLAY ' A PARTIR DE 08/12/2009 PELA SSI 25.978 DEVERA   ' */
                _.Display($" A PARTIR DE 08/12/2009 PELA SSI 25.978 DEVERA   ");

                /*" -391- DISPLAY ' HAVER UMA DEFASAGEM DE 05 DIAS UTEIS ENTRE A DATA' */
                _.Display($" HAVER UMA DEFASAGEM DE 05 DIAS UTEIS ENTRE A DATA");

                /*" -392- DISPLAY ' DE INDENIZACAO E A CARGA PARA O RESSARCIMENTO.' */
                _.Display($" DE INDENIZACAO E A CARGA PARA O RESSARCIMENTO.");

                /*" -393- DISPLAY ' ' */
                _.Display($" ");

                /*" -394- DISPLAY ' TODAS AS INDENIZACOES E ESTORNOS ENTRE ESTAS DATAS' */
                _.Display($" TODAS AS INDENIZACOES E ESTORNOS ENTRE ESTAS DATAS");

                /*" -395- DISPLAY ' ESTAO SENDO SELECIONADOS PARA O RESSARCIMENTO' */
                _.Display($" ESTAO SENDO SELECIONADOS PARA O RESSARCIMENTO");

                /*" -396- DISPLAY ' ' */
                _.Display($" ");

                /*" -400- DISPLAY ' DATA DO SISTEMA DE SINISTRO ... ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

                $" DATA DO SISTEMA DE SINISTRO ... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
                .Display();

                /*" -401- DISPLAY ' ' */
                _.Display($" ");

                /*" -405- DISPLAY ' DATA INICIAL DA SELECAO ....... ' W-DATA-INICIO-SELECAO(9:2) '/' W-DATA-INICIO-SELECAO(6:2) '/' W-DATA-INICIO-SELECAO(1:4). */

                $" DATA INICIAL DA SELECAO ....... {W_DATA_INICIO_SELECAO.Substring(9, 2)}/{W_DATA_INICIO_SELECAO.Substring(6, 2)}/{W_DATA_INICIO_SELECAO.Substring(1, 4)}"
                .Display();

                /*" -409- DISPLAY ' DATA FINAL DA SELECAO ......... ' W-DATA-FIM-SELECAO(9:2) '/' W-DATA-FIM-SELECAO(6:2) '/' W-DATA-FIM-SELECAO(1:4). */

                $" DATA FINAL DA SELECAO ......... {W_DATA_FIM_SELECAO.Substring(9, 2)}/{W_DATA_FIM_SELECAO.Substring(6, 2)}/{W_DATA_FIM_SELECAO.Substring(1, 4)}"
                .Display();

                /*" -414- DISPLAY ' ' . */
                _.Display($" ");

                /*" -416- OPEN OUTPUT SIH202A. */
                SIH202A.Open(REG_SIH202A);

                /*" -418- PERFORM R030-DECLARE-SINISHIS THRU R030-EXIT. */

                R030_DECLARE_SINISHIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/


                /*" -419- MOVE 'NAO' TO WFIM-SINISHIS. */
                _.Move("NAO", AREA_DE_WORK.WFIM_SINISHIS);

                /*" -421- PERFORM R031-FETCH-SINISHIS THRU R031-EXIT. */

                R031_FETCH_SINISHIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/


                /*" -422- IF (WFIM-SINISHIS = 'SIM' ) */

                if ((AREA_DE_WORK.WFIM_SINISHIS == "SIM"))
                {

                    /*" -423- DISPLAY '***************************************************' */
                    _.Display($"***************************************************");

                    /*" -424- DISPLAY '*                                                 *' */
                    _.Display($"*                                                 *");

                    /*" -425- DISPLAY '*        NADA SELECIONADO NA DATA DE HOJE         *' */
                    _.Display($"*        NADA SELECIONADO NA DATA DE HOJE         *");

                    /*" -426- DISPLAY '*                                                 *' */
                    _.Display($"*                                                 *");

                    /*" -427- DISPLAY '***************************************************' */
                    _.Display($"***************************************************");

                    /*" -428- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -430- END-IF. */
                }


                /*" -433- PERFORM R100-PROCESSA-HISTSINI THRU R100-EXIT UNTIL WFIM-SINISHIS EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_SINISHIS == "SIM"))
                {

                    R100_PROCESSA_HISTSINI(true);

                    R100_GRAVA_REGISTRO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }

                /*" -434- DISPLAY '***************************************************' */
                _.Display($"***************************************************");

                /*" -435- DISPLAY '*                                                 *' */
                _.Display($"*                                                 *");

                /*" -436- DISPLAY '*                FIM NORMAL                       *' */
                _.Display($"*                FIM NORMAL                       *");

                /*" -437- DISPLAY '*                                                 *' */
                _.Display($"*                                                 *");

                /*" -438- DISPLAY '***************************************************' */
                _.Display($"***************************************************");

                /*" -439- DISPLAY ' ' */
                _.Display($" ");

                /*" -441- DISPLAY ' GRAVADOS ' W-GRAVADOS */
                _.Display($" GRAVADOS {W_GRAVADOS}");

                /*" -443- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -446- CLOSE SIH202A. */
                SIH202A.Close();

                /*" -446- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -448- STOP RUN. */

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
            /*" -455- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", WABEND.WNR_EXEC_SQL);

            /*" -463- PERFORM R010_SELECT_SISTEMAS_DB_SELECT_1 */

            R010_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -466- IF (SQLCODE = 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -467- DISPLAY 'ERRO ACESSO SISTEMAS' */
                _.Display($"ERRO ACESSO SISTEMAS");

                /*" -468- DISPLAY 'SI0202B - SISTEMA SINISTRO NAO CADASTRADO' */
                _.Display($"SI0202B - SISTEMA SINISTRO NAO CADASTRADO");

                /*" -469- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -471- END-IF. */
            }


            /*" -475- DISPLAY 'SI0202B - DATA DO PROCESSAMENTO (SI) = ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

            $"SI0202B - DATA DO PROCESSAMENTO (SI) = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -475- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R010-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R010_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -463- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :HOST-CURRENT-DATE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

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
            /*" -485- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", WABEND.WNR_EXEC_SQL);

            /*" -497- PERFORM R020_ACHA_DATA_HOJE_MENOS_10_DB_DECLARE_1 */

            R020_ACHA_DATA_HOJE_MENOS_10_DB_DECLARE_1();

            /*" -499- PERFORM R020_ACHA_DATA_HOJE_MENOS_10_DB_OPEN_1 */

            R020_ACHA_DATA_HOJE_MENOS_10_DB_OPEN_1();

            /*" -502- IF (SQLCODE NOT = 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -503- DISPLAY 'ERRO NO OPEN CURSOR DATALIMITE' */
                _.Display($"ERRO NO OPEN CURSOR DATALIMITE");

                /*" -504- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -507- END-IF. */
            }


            /*" -510- MOVE 1 TO W-CONTA-05-DIAS-UTEIS. */
            _.Move(1, AREA_DE_WORK.W_CONTA_05_DIAS_UTEIS);

            /*" -513- PERFORM VARYING W-CONTA-05-DIAS-UTEIS FROM 1 BY 1 UNTIL W-CONTA-05-DIAS-UTEIS > 05 */

            for (AREA_DE_WORK.W_CONTA_05_DIAS_UTEIS.Value = 1; !(AREA_DE_WORK.W_CONTA_05_DIAS_UTEIS > 05); AREA_DE_WORK.W_CONTA_05_DIAS_UTEIS.Value += 1)
            {

                /*" -514- MOVE '003' TO WNR-EXEC-SQL */
                _.Move("003", WABEND.WNR_EXEC_SQL);

                /*" -518- PERFORM R020_ACHA_DATA_HOJE_MENOS_10_DB_FETCH_1 */

                R020_ACHA_DATA_HOJE_MENOS_10_DB_FETCH_1();

                /*" -521- IF (SQLCODE NOT = 0) */

                if ((DB.SQLCODE != 0))
                {

                    /*" -522- IF (SQLCODE = 100) */

                    if ((DB.SQLCODE == 100))
                    {

                        /*" -522- PERFORM R020_ACHA_DATA_HOJE_MENOS_10_DB_CLOSE_1 */

                        R020_ACHA_DATA_HOJE_MENOS_10_DB_CLOSE_1();

                        /*" -524- ELSE */
                    }
                    else
                    {


                        /*" -525- DISPLAY 'ERRO NO FETCH DA CALENDARIO' */
                        _.Display($"ERRO NO FETCH DA CALENDARIO");

                        /*" -526- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO(); //GOTO
                        return;

                        /*" -527- END-IF */
                    }


                    /*" -528- END-IF */
                }


                /*" -530- END-PERFORM. */
            }

            /*" -532- MOVE HOST-DATA-HOJE-MENOS-40-DIAS TO W-DATA-INICIO-SELECAO. */
            _.Move(HOST_DATA_HOJE_MENOS_40_DIAS, W_DATA_INICIO_SELECAO);

            /*" -532- MOVE HOST-DATA-HOJE-MENOS-05-DIAS TO W-DATA-FIM-SELECAO. */
            _.Move(HOST_DATA_HOJE_MENOS_05_DIAS, W_DATA_FIM_SELECAO);

        }

        [StopWatch]
        /*" R020-ACHA-DATA-HOJE-MENOS-10-DB-DECLARE-1 */
        public void R020_ACHA_DATA_HOJE_MENOS_10_DB_DECLARE_1()
        {
            /*" -497- EXEC SQL DECLARE XXXXX CURSOR FOR SELECT DATA_CALENDARIO, DATA_CALENDARIO - 40 DAYS FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO >= DATE(:SISTEMAS-DATA-MOV-ABERTO) - 30 DAYS AND DATA_CALENDARIO <= :SISTEMAS-DATA-MOV-ABERTO AND FERIADO <> 'N' AND DIA_SEMANA NOT IN ( 'S' , 'D' ) ORDER BY DATA_CALENDARIO DESC FETCH FIRST 10 ROWS ONLY WITH UR END-EXEC. */
            XXXXX = new SI0202B_XXXXX(true);
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
            /*" -499- EXEC SQL OPEN XXXXX END-EXEC. */

            XXXXX.Open();

        }

        [StopWatch]
        /*" R030-DECLARE-SINISHIS-DB-DECLARE-1 */
        public void R030_DECLARE_SINISHIS_DB_DECLARE_1()
        {
            /*" -706- EXEC SQL DECLARE C01_SINISHIS CURSOR FOR SELECT DISTINCT M.NUM_APOL_SINISTRO, M.NUM_APOLICE, M.COD_PRODUTO, M.COD_FONTE, M.DATA_OCORRENCIA, M.SIT_REGISTRO, M.NUM_PROTOCOLO_SINI, A.OPERACAO, A.PONTO_VENDA, A.NUM_CONTRATO, A.NOME_SEGURADO, A.COD_CLIENTE, A.CGCCPF, S.GRUPO_CAUSAS, S.DESCR_CAUSA FROM SEGUROS.SINISTRO_MESTRE M , SEGUROS.SINISTRO_HISTORICO H , SEGUROS.GE_SIS_FUNCAO_OPER Y , SEGUROS.SINISTRO_HABIT01 A , SEGUROS.SINISTRO_CAUSA S WHERE ( M.NUM_APOL_SINISTRO BETWEEN 0104800000000 AND 0104899999999 OR M.NUM_APOL_SINISTRO BETWEEN 0106000000000 AND 0106099999999 OR M.NUM_APOL_SINISTRO BETWEEN 0107000000000 AND 0107099999999 ) AND H.DATA_MOVIMENTO BETWEEN :W-DATA-INICIO-SELECAO AND :W-DATA-FIM-SELECAO AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) AND M.COD_PRODUTO NOT IN ( 6008 , 6009 , 4813 , 4814 ) AND M.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND S.RAMO_EMISSOR = M.RAMO AND S.COD_CAUSA = M.COD_CAUSA AND S.GRUPO_CAUSAS = 'INADIMP.' AND Y.COD_OPERACAO = H.COD_OPERACAO AND Y.IDE_SISTEMA = 'SI' AND Y.COD_FUNCAO = 2 UNION ALL SELECT DISTINCT M.NUM_APOL_SINISTRO, M.NUM_APOLICE, M.COD_PRODUTO, M.COD_FONTE, M.DATA_OCORRENCIA, M.SIT_REGISTRO, M.NUM_PROTOCOLO_SINI, A.OPERACAO, A.PONTO_VENDA, A.NUM_CONTRATO, A.NOME_SEGURADO, A.COD_CLIENTE, A.CGCCPF, S.GRUPO_CAUSAS, S.DESCR_CAUSA FROM SEGUROS.SINISTRO_MESTRE M , SEGUROS.SINISTRO_HISTORICO H , SEGUROS.GE_SIS_FUNCAO_OPER Y , SEGUROS.SINISTRO_HABIT01 A , SEGUROS.SINISTRO_CAUSA S WHERE M.NUM_APOL_SINISTRO = 107000151409 AND M.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND S.RAMO_EMISSOR = M.RAMO AND S.COD_CAUSA = M.COD_CAUSA AND S.GRUPO_CAUSAS = 'INADIMP.' AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) AND Y.COD_OPERACAO = H.COD_OPERACAO AND Y.IDE_SISTEMA = 'SI' AND Y.COD_FUNCAO = 2 ORDER BY 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15 WITH UR END-EXEC. */
            C01_SINISHIS = new SI0202B_C01_SINISHIS(true);
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
							A.OPERACAO
							, 
							A.PONTO_VENDA
							, 
							A.NUM_CONTRATO
							, 
							A.NOME_SEGURADO
							, 
							A.COD_CLIENTE
							, 
							A.CGCCPF
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
							SEGUROS.SINISTRO_HABIT01 A
							, 
							SEGUROS.SINISTRO_CAUSA S 
							WHERE ( M.NUM_APOL_SINISTRO BETWEEN 0104800000000 
							AND 0104899999999 
							OR M.NUM_APOL_SINISTRO BETWEEN 0106000000000 
							AND 0106099999999 
							OR M.NUM_APOL_SINISTRO BETWEEN 0107000000000 
							AND 0107099999999 ) 
							AND H.DATA_MOVIMENTO BETWEEN 
							'{W_DATA_INICIO_SELECAO}' 
							AND '{W_DATA_FIM_SELECAO}' 
							AND ( H.NOM_PROGRAMA <> 'SI0170B' 
							OR H.NOM_PROGRAMA IS NULL) 
							AND M.COD_PRODUTO NOT IN ( 6008
							, 6009
							, 4813
							, 4814 ) 
							AND M.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND S.RAMO_EMISSOR = M.RAMO 
							AND S.COD_CAUSA = M.COD_CAUSA 
							AND S.GRUPO_CAUSAS = 'INADIMP.' 
							AND Y.COD_OPERACAO = H.COD_OPERACAO 
							AND Y.IDE_SISTEMA = 'SI' 
							AND Y.COD_FUNCAO = 2 
							UNION ALL 
							SELECT DISTINCT 
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
							A.OPERACAO
							, 
							A.PONTO_VENDA
							, 
							A.NUM_CONTRATO
							, 
							A.NOME_SEGURADO
							, 
							A.COD_CLIENTE
							, 
							A.CGCCPF
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
							SEGUROS.SINISTRO_HABIT01 A
							, 
							SEGUROS.SINISTRO_CAUSA S 
							WHERE M.NUM_APOL_SINISTRO = 107000151409 
							AND M.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND S.RAMO_EMISSOR = M.RAMO 
							AND S.COD_CAUSA = M.COD_CAUSA 
							AND S.GRUPO_CAUSAS = 'INADIMP.' 
							AND ( H.NOM_PROGRAMA <> 'SI0170B' 
							OR H.NOM_PROGRAMA IS NULL) 
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
							,14
							,15";

                return query;
            }
            C01_SINISHIS.GetQueryEvent += GetQuery_C01_SINISHIS;

        }

        [StopWatch]
        /*" R020-ACHA-DATA-HOJE-MENOS-10-DB-FETCH-1 */
        public void R020_ACHA_DATA_HOJE_MENOS_10_DB_FETCH_1()
        {
            /*" -518- EXEC SQL FETCH XXXXX INTO :HOST-DATA-HOJE-MENOS-05-DIAS, :HOST-DATA-HOJE-MENOS-40-DIAS END-EXEC */

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
            /*" -522- EXEC SQL CLOSE XXXXX END-EXEC */

            XXXXX.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R030-DECLARE-SINISHIS */
        private void R030_DECLARE_SINISHIS(bool isPerform = false)
        {
            /*" -541- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", WABEND.WNR_EXEC_SQL);

            /*" -706- PERFORM R030_DECLARE_SINISHIS_DB_DECLARE_1 */

            R030_DECLARE_SINISHIS_DB_DECLARE_1();

            /*" -708- PERFORM R030_DECLARE_SINISHIS_DB_OPEN_1 */

            R030_DECLARE_SINISHIS_DB_OPEN_1();

            /*" -711- IF (SQLCODE NOT = 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -712- DISPLAY 'SI0202B - ERRO NO OPEN CURSOR SINISHIS' */
                _.Display($"SI0202B - ERRO NO OPEN CURSOR SINISHIS");

                /*" -713- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -714- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -714- END-IF. */
            }


        }

        [StopWatch]
        /*" R030-DECLARE-SINISHIS-DB-OPEN-1 */
        public void R030_DECLARE_SINISHIS_DB_OPEN_1()
        {
            /*" -708- EXEC SQL OPEN C01_SINISHIS END-EXEC. */

            C01_SINISHIS.Open();

        }

        [StopWatch]
        /*" R110-LE-AGENCIA-INDENIZA-DB-DECLARE-1 */
        public void R110_LE_AGENCIA_INDENIZA_DB_DECLARE_1()
        {
            /*" -1247- EXEC SQL DECLARE YYY CURSOR FOR SELECT VALUE(R.AGE_CENTRAL_PROD01,9876), MIN(H.OCORR_HISTORICO), H.DATA_MOVIMENTO FROM SEGUROS.RALACAO_CHEQ_DOCTO R, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO O WHERE R.NUMDOC_NUM01 = :SINISMES-NUM-APOL-SINISTRO AND H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND R.NUMDOC_NUM01 = H.NUM_APOL_SINISTRO AND R.OCORR_HISTORICO = H.OCORR_HISTORICO AND O.IDE_SISTEMA = 'SI' AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IND_TIPO_FUNCAO = 'IN' AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) GROUP BY R.AGE_CENTRAL_PROD01,H.DATA_MOVIMENTO ORDER BY R.AGE_CENTRAL_PROD01,H.DATA_MOVIMENTO WITH UR END-EXEC. */
            YYY = new SI0202B_YYY(true);
            string GetQuery_YYY()
            {
                var query = @$"SELECT VALUE(R.AGE_CENTRAL_PROD01
							,9876)
							, 
							MIN(H.OCORR_HISTORICO)
							, 
							H.DATA_MOVIMENTO 
							FROM SEGUROS.RALACAO_CHEQ_DOCTO R
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.GE_OPERACAO O 
							WHERE R.NUMDOC_NUM01 = '{SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}' 
							AND H.NUM_APOL_SINISTRO = '{SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}' 
							AND R.NUMDOC_NUM01 = H.NUM_APOL_SINISTRO 
							AND R.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.COD_OPERACAO = H.COD_OPERACAO 
							AND O.IND_TIPO_FUNCAO = 'IN' 
							AND ( H.NOM_PROGRAMA <> 'SI0170B' 
							OR H.NOM_PROGRAMA IS NULL) 
							GROUP BY R.AGE_CENTRAL_PROD01
							,H.DATA_MOVIMENTO 
							ORDER BY R.AGE_CENTRAL_PROD01
							,H.DATA_MOVIMENTO";

                return query;
            }
            YYY.GetQueryEvent += GetQuery_YYY;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R031-FETCH-SINISHIS */
        private void R031_FETCH_SINISHIS(bool isPerform = false)
        {
            /*" -724- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", WABEND.WNR_EXEC_SQL);

            /*" -740- PERFORM R031_FETCH_SINISHIS_DB_FETCH_1 */

            R031_FETCH_SINISHIS_DB_FETCH_1();

            /*" -743- IF (SQLCODE NOT = ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -744- IF (SQLCODE = 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -744- PERFORM R031_FETCH_SINISHIS_DB_CLOSE_1 */

                    R031_FETCH_SINISHIS_DB_CLOSE_1();

                    /*" -746- IF (SQLCODE NOT = ZEROS) */

                    if ((DB.SQLCODE != 00))
                    {

                        /*" -747- DISPLAY 'SI0202B - ERRO NO CLOSE CURSOR SINISHIS' */
                        _.Display($"SI0202B - ERRO NO CLOSE CURSOR SINISHIS");

                        /*" -748- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                        _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                        /*" -749- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO(); //GOTO
                        return;

                        /*" -750- END-IF */
                    }


                    /*" -751- MOVE 'SIM' TO WFIM-SINISHIS */
                    _.Move("SIM", AREA_DE_WORK.WFIM_SINISHIS);

                    /*" -752- GO TO R031-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/ //GOTO
                    return;

                    /*" -753- ELSE */
                }
                else
                {


                    /*" -754- DISPLAY 'ERRO NO FETCH DA SINISTRO_HISTORICO' */
                    _.Display($"ERRO NO FETCH DA SINISTRO_HISTORICO");

                    /*" -755- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -756- END-IF */
                }


                /*" -756- END-IF. */
            }


        }

        [StopWatch]
        /*" R031-FETCH-SINISHIS-DB-FETCH-1 */
        public void R031_FETCH_SINISHIS_DB_FETCH_1()
        {
            /*" -740- EXEC SQL FETCH C01_SINISHIS INTO :SINISMES-NUM-APOL-SINISTRO, :SINISMES-NUM-APOLICE, :SINISMES-COD-PRODUTO, :SINISMES-COD-FONTE, :SINISMES-DATA-OCORRENCIA, :SINISMES-SIT-REGISTRO, :SINISMES-NUM-PROTOCOLO-SINI, :SINIHAB1-OPERACAO, :SINIHAB1-PONTO-VENDA, :SINIHAB1-NUM-CONTRATO, :SINIHAB1-NOME-SEGURADO, :SINIHAB1-COD-CLIENTE, :SINIHAB1-CGCCPF, :SINISCAU-GRUPO-CAUSAS, :SINISCAU-DESCR-CAUSA END-EXEC. */

            if (C01_SINISHIS.Fetch())
            {
                _.Move(C01_SINISHIS.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(C01_SINISHIS.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(C01_SINISHIS.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(C01_SINISHIS.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(C01_SINISHIS.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(C01_SINISHIS.SINISMES_SIT_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);
                _.Move(C01_SINISHIS.SINISMES_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);
                _.Move(C01_SINISHIS.SINIHAB1_OPERACAO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO);
                _.Move(C01_SINISHIS.SINIHAB1_PONTO_VENDA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);
                _.Move(C01_SINISHIS.SINIHAB1_NUM_CONTRATO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO);
                _.Move(C01_SINISHIS.SINIHAB1_NOME_SEGURADO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO);
                _.Move(C01_SINISHIS.SINIHAB1_COD_CLIENTE, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_COD_CLIENTE);
                _.Move(C01_SINISHIS.SINIHAB1_CGCCPF, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_CGCCPF);
                _.Move(C01_SINISHIS.SINISCAU_GRUPO_CAUSAS, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS);
                _.Move(C01_SINISHIS.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
            }

        }

        [StopWatch]
        /*" R031-FETCH-SINISHIS-DB-CLOSE-1 */
        public void R031_FETCH_SINISHIS_DB_CLOSE_1()
        {
            /*" -744- EXEC SQL CLOSE C01_SINISHIS END-EXEC */

            C01_SINISHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-HISTSINI */
        private void R100_PROCESSA_HISTSINI(bool isPerform = false)
        {
            /*" -766- INITIALIZE REG-SIH202A. */
            _.Initialize(
                REG_SIH202A
            );

            /*" -767- MOVE SINISMES-NUM-APOL-SINISTRO TO REG-NUM-APOL-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, REG_SIH202A.REG_NUM_APOL_SINISTRO);

            /*" -768- MOVE SINISMES-NUM-PROTOCOLO-SINI TO REG-NUM-PROTOCOLO-SINI. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI, REG_SIH202A.REG_NUM_PROTOCOLO_SINI);

            /*" -769- MOVE SINISMES-NUM-APOLICE TO REG-NUM-APOLICE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, REG_SIH202A.REG_NUM_APOLICE);

            /*" -770- MOVE ZEROS TO REG-SUREG. */
            _.Move(0, REG_SIH202A.REG_SUREG);

            /*" -771- MOVE SINIHAB1-PONTO-VENDA TO REG-AGENCIA. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, REG_SIH202A.REG_AGENCIA);

            /*" -772- MOVE SINIHAB1-OPERACAO TO REG-OPERACAO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO, REG_SIH202A.REG_OPERACAO);

            /*" -773- MOVE SINIHAB1-NUM-CONTRATO TO REG-CONTRATO */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO, REG_SIH202A.REG_CONTRATO);

            /*" -774- MOVE ZEROS TO REG-DV. */
            _.Move(0, REG_SIH202A.REG_DV);

            /*" -775- MOVE SINISMES-COD-PRODUTO TO REG-NUM-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, REG_SIH202A.REG_NUM_PRODUTO);

            /*" -776- MOVE SINISMES-COD-FONTE TO REG-NUM-FONTE-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, REG_SIH202A.REG_NUM_FONTE_SINISTRO);

            /*" -777- MOVE 1 TO REG-MOEDA-INDENIZACAO. */
            _.Move(1, REG_SIH202A.REG_MOEDA_INDENIZACAO);

            /*" -778- MOVE SINIHAB1-NOME-SEGURADO TO REG-NOME-SEGURADO */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO, REG_SIH202A.REG_NOME_SEGURADO);

            /*" -779- MOVE SPACES TO REG-NOME-DEVEDOR. */
            _.Move("", REG_SIH202A.REG_NOME_DEVEDOR);

            /*" -780- MOVE SPACES TO REG-SEXO-DEVEDOR. */
            _.Move("", REG_SIH202A.REG_SEXO_DEVEDOR);

            /*" -781- MOVE SPACES TO REG-TELEF-RESID-DEVEDOR. */
            _.Move("", REG_SIH202A.REG_TELEF_RESID_DEVEDOR);

            /*" -782- MOVE SPACES TO REG-TELEF-TRAB-DEVEDOR. */
            _.Move("", REG_SIH202A.REG_TELEF_TRAB_DEVEDOR);

            /*" -783- MOVE SPACES TO REG-TELEF-FAX-DEVEDOR. */
            _.Move("", REG_SIH202A.REG_TELEF_FAX_DEVEDOR);

            /*" -784- MOVE SINIHAB1-CGCCPF TO REG-CIC-DEVEDOR. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_CGCCPF, REG_SIH202A.REG_CIC_DEVEDOR);

            /*" -785- MOVE SPACES TO REG-IDENTIDADE-DEVEDOR. */
            _.Move("", REG_SIH202A.REG_IDENTIDADE_DEVEDOR);

            /*" -788- MOVE SINISMES-DATA-OCORRENCIA TO REG-DATA-OCORR-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, REG_SIH202A.REG_DATA_OCORR_SINISTRO);

            /*" -789- MOVE 0 TO REG-OCORR-HISTORICO. */
            _.Move(0, REG_SIH202A.REG_OCORR_HISTORICO);

            /*" -790- MOVE 0 TO REG-COD-OPERACAO. */
            _.Move(0, REG_SIH202A.REG_COD_OPERACAO);

            /*" -791- MOVE SINISCAU-GRUPO-CAUSAS TO REG-NATUREZA-SINISTRO. */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS, REG_SIH202A.REG_NATUREZA_SINISTRO);

            /*" -793- MOVE SINISCAU-DESCR-CAUSA TO REG-DESCR-CAUSA-SINISTRO. */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, REG_SIH202A.REG_DESCR_CAUSA_SINISTRO);

            /*" -795- PERFORM R110-LE-AGENCIA-INDENIZA THRU R110-EXIT. */

            R110_LE_AGENCIA_INDENIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


            /*" -796- IF (RALCHEDO-AGE-CENTRAL-PROD01 = 0) */

            if ((RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGE_CENTRAL_PROD01 == 0))
            {

                /*" -797- MOVE SINIHAB1-PONTO-VENDA TO REG-AGENCIA-INDENIZACAO */
                _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, REG_SIH202A.REG_AGENCIA_INDENIZACAO);

                /*" -798- ELSE */
            }
            else
            {


                /*" -800- MOVE RALCHEDO-AGE-CENTRAL-PROD01 TO REG-AGENCIA-INDENIZACAO */
                _.Move(RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGE_CENTRAL_PROD01, REG_SIH202A.REG_AGENCIA_INDENIZACAO);

                /*" -803- END-IF. */
            }


            /*" -804- PERFORM R160-OBTER-ENDERECO THRU R160-EXIT */

            R160_OBTER_ENDERECO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/


            /*" -808- PERFORM R165-SET-REG-ARQ-SAIDA THRU R165-EXIT */

            R165_SET_REG_ARQ_SAIDA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R165_EXIT*/


            /*" -809- IF (SINISMES-SIT-REGISTRO = '2' ) */

            if ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO == "2"))
            {

                /*" -810- MOVE 0 TO REG-VALOR-INDENIZACAO */
                _.Move(0, REG_SIH202A.REG_VALOR_INDENIZACAO);

                /*" -811- PERFORM R105-PRIMEIRA-DATA-INDENIZA-1 THRU R105-EXIT */

                R105_PRIMEIRA_DATA_INDENIZA_1(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R105_EXIT*/


                /*" -812- MOVE SINISHIS-DATA-MOVIMENTO TO REG-DATA-INDENIZACAO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, REG_SIH202A.REG_DATA_INDENIZACAO);

                /*" -813- GO TO R100-GRAVA-REGISTRO */

                R100_GRAVA_REGISTRO(); //GOTO
                return;

                /*" -837- END-IF. */
            }


            /*" -863- MOVE 0 TO W-VALOR-PAGO-FINANCEIRO W-VALOR-FRANQUIA W-VALOR-PREMIO W-VALOR-RESSARCIMENTO W-VALOR-TOTAL-PRE-LIBERADO W-VALOR-TOTAL-ESTORNADO. */
            _.Move(0, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO, AREA_DE_WORK.W_VALOR_FRANQUIA, AREA_DE_WORK.W_VALOR_PREMIO, AREA_DE_WORK.W_VALOR_RESSARCIMENTO, AREA_DE_WORK.W_VALOR_TOTAL_PRE_LIBERADO, AREA_DE_WORK.W_VALOR_TOTAL_ESTORNADO);

            /*" -864- PERFORM R200-LE-PRE-LIBERACOES THRU R200-EXIT. */

            R200_LE_PRE_LIBERACOES(true);

            R200_PULA_CANCELAMENTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/


            /*" -866- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-TOTAL-PRE-LIBERADO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_TOTAL_PRE_LIBERADO);

            /*" -867- PERFORM R210-LE-ESTORNO THRU R210-EXIT. */

            R210_LE_ESTORNO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/


            /*" -879- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-TOTAL-ESTORNADO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_TOTAL_ESTORNADO);

            /*" -881- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-PAGO-FINANCEIRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO);

            /*" -901- COMPUTE W-VALOR-PAGO-FINANCEIRO = W-VALOR-TOTAL-PRE-LIBERADO - W-VALOR-TOTAL-ESTORNADO. */
            AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO.Value = AREA_DE_WORK.W_VALOR_TOTAL_PRE_LIBERADO - AREA_DE_WORK.W_VALOR_TOTAL_ESTORNADO;

            /*" -903- IF (W-VALOR-PAGO-FINANCEIRO = ZERO) OR (W-VALOR-PAGO-FINANCEIRO < ZERO) */

            if ((AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO == 00) || (AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO < 00))
            {

                /*" -904- PERFORM R105-PRIMEIRA-DATA-INDENIZA-1 THRU R105-EXIT */

                R105_PRIMEIRA_DATA_INDENIZA_1(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R105_EXIT*/


                /*" -905- MOVE SINISHIS-DATA-MOVIMENTO TO REG-DATA-INDENIZACAO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, REG_SIH202A.REG_DATA_INDENIZACAO);

                /*" -906- MOVE 0 TO REG-VALOR-INDENIZACAO */
                _.Move(0, REG_SIH202A.REG_VALOR_INDENIZACAO);

                /*" -907- IF (W-VALOR-PAGO-FINANCEIRO < ZERO) */

                if ((AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO < 00))
                {

                    /*" -909- DISPLAY 'SIT 1 - TOT ESTORNO > TOT INDENIZ ' SINISMES-NUM-APOL-SINISTRO */
                    _.Display($"SIT 1 - TOT ESTORNO > TOT INDENIZ {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                    /*" -910- MOVE W-VALOR-TOTAL-PRE-LIBERADO TO W-EDICAO */
                    _.Move(AREA_DE_WORK.W_VALOR_TOTAL_PRE_LIBERADO, AREA_DE_WORK.W_EDICAO);

                    /*" -911- DISPLAY 'TOTAL PRE-LIB.... ' W-EDICAO */
                    _.Display($"TOTAL PRE-LIB.... {AREA_DE_WORK.W_EDICAO}");

                    /*" -912- MOVE W-VALOR-TOTAL-ESTORNADO TO W-EDICAO */
                    _.Move(AREA_DE_WORK.W_VALOR_TOTAL_ESTORNADO, AREA_DE_WORK.W_EDICAO);

                    /*" -913- DISPLAY 'TOTAL LIB........ ' W-EDICAO */
                    _.Display($"TOTAL LIB........ {AREA_DE_WORK.W_EDICAO}");

                    /*" -914- END-IF */
                }


                /*" -915- GO TO R100-GRAVA-REGISTRO */

                R100_GRAVA_REGISTRO(); //GOTO
                return;

                /*" -918- END-IF. */
            }


            /*" -921- MOVE 'NAO' TO W-CHAVE-TEM-PLANILHA. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_PLANILHA);

            /*" -924- PERFORM R510-LE-PLANILHA-SELECT THRU R510-EXIT. */

            R510_LE_PLANILHA_SELECT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R510_EXIT*/


            /*" -929- IF W-CHAVE-TEM-PLANILHA EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_TEM_PLANILHA == "SIM")
            {

                /*" -931- PERFORM R520-TRAZ-VALOR-FRANQUIA THRU R520-EXIT */

                R520_TRAZ_VALOR_FRANQUIA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R520_EXIT*/


                /*" -936- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-FRANQUIA */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_FRANQUIA);

                /*" -937- IF (SINIPLAN-QTD-PRE-ARECUPERAR < 0) */

                if ((SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_QTD_PRE_ARECUPERAR < 0))
                {

                    /*" -941- COMPUTE SINIPLAN-QTD-PRE-ARECUPERAR = SINIPLAN-QTD-PRE-ARECUPERAR * -1 */
                    SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_QTD_PRE_ARECUPERAR.Value = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_QTD_PRE_ARECUPERAR * -1;

                    /*" -944- END-IF */
                }


                /*" -952- COMPUTE W-VALOR-PREMIO = SINIPLAN-QTD-PRE-ARECUPERAR * SINIPLAN-VAL-PREMIO */
                AREA_DE_WORK.W_VALOR_PREMIO.Value = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_QTD_PRE_ARECUPERAR * SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_PREMIO;

                /*" -953- MOVE SINISHIS-DATA-MOVIMENTO TO REG-DATA-INDENIZACAO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, REG_SIH202A.REG_DATA_INDENIZACAO);

                /*" -956- END-IF. */
            }


            /*" -959- IF (W-CHAVE-TEM-PLANILHA = 'NAO' ) */

            if ((AREA_DE_WORK.W_CHAVE_TEM_PLANILHA == "NAO"))
            {

                /*" -961- PERFORM R150-PRIMEIRA-DATA-INDENIZA-2 THRU R150-EXIT */

                R150_PRIMEIRA_DATA_INDENIZA_2(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R150_EXIT*/


                /*" -963- MOVE SINISHIS-DATA-MOVIMENTO TO REG-DATA-INDENIZACAO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, REG_SIH202A.REG_DATA_INDENIZACAO);

                /*" -967- COMPUTE W-VALOR-FRANQUIA = ((W-VALOR-PAGO-FINANCEIRO * 100) / 80) - W-VALOR-PAGO-FINANCEIRO */
                AREA_DE_WORK.W_VALOR_FRANQUIA.Value = ((AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO * 100) / 80f) - AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO;

                /*" -969- PERFORM R107-LE-VALOR-PREMIO THRU R107-EXIT */

                R107_LE_VALOR_PREMIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R107_EXIT*/


                /*" -970- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-PREMIO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_PREMIO);

                /*" -982- END-IF. */
            }


            /*" -985- IF (SINISMES-COD-PRODUTO = 4801) AND (SINISHIS-DATA-MOVIMENTO > '2004-03-31' ) */

            if ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4801) && (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO > "2004-03-31"))
            {

                /*" -986- MOVE 0 TO W-VALOR-FRANQUIA */
                _.Move(0, AREA_DE_WORK.W_VALOR_FRANQUIA);

                /*" -989- END-IF. */
            }


            /*" -995- COMPUTE W-VALOR-RESSARCIMENTO = W-VALOR-PAGO-FINANCEIRO + W-VALOR-FRANQUIA + W-VALOR-PREMIO. */
            AREA_DE_WORK.W_VALOR_RESSARCIMENTO.Value = AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO + AREA_DE_WORK.W_VALOR_FRANQUIA + AREA_DE_WORK.W_VALOR_PREMIO;

            /*" -996- MOVE W-VALOR-RESSARCIMENTO TO REG-VALOR-RESSARCIMENTO. */
            _.Move(AREA_DE_WORK.W_VALOR_RESSARCIMENTO, REG_SIH202A.REG_VALOR_RESSARCIMENTO);

            /*" -997- MOVE W-VALOR-PAGO-FINANCEIRO TO REG-VALOR-PAGO-FINANCEIRO. */
            _.Move(AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO, REG_SIH202A.REG_VALOR_PAGO_FINANCEIRO);

            /*" -998- MOVE W-VALOR-FRANQUIA TO REG-VALOR-FRANQUIA. */
            _.Move(AREA_DE_WORK.W_VALOR_FRANQUIA, REG_SIH202A.REG_VALOR_FRANQUIA);

            /*" -999- MOVE W-VALOR-PREMIO TO REG-VALOR-PREMIO. */
            _.Move(AREA_DE_WORK.W_VALOR_PREMIO, REG_SIH202A.REG_VALOR_PREMIO);

            /*" -1000- MOVE W-VALOR-RESSARCIMENTO TO W-EDICAO-1. */
            _.Move(AREA_DE_WORK.W_VALOR_RESSARCIMENTO, AREA_DE_WORK.W_EDICAO_1);

            /*" -1001- MOVE W-VALOR-PAGO-FINANCEIRO TO W-EDICAO-2. */
            _.Move(AREA_DE_WORK.W_VALOR_PAGO_FINANCEIRO, AREA_DE_WORK.W_EDICAO_2);

            /*" -1002- MOVE W-VALOR-FRANQUIA TO W-EDICAO-3. */
            _.Move(AREA_DE_WORK.W_VALOR_FRANQUIA, AREA_DE_WORK.W_EDICAO_3);

            /*" -1008- MOVE W-VALOR-PREMIO TO W-EDICAO-4. */
            _.Move(AREA_DE_WORK.W_VALOR_PREMIO, AREA_DE_WORK.W_EDICAO_4);

            /*" -1008- MOVE W-VALOR-RESSARCIMENTO TO REG-VALOR-INDENIZACAO. */
            _.Move(AREA_DE_WORK.W_VALOR_RESSARCIMENTO, REG_SIH202A.REG_VALOR_INDENIZACAO);

        }

        [StopWatch]
        /*" R100-GRAVA-REGISTRO */
        private void R100_GRAVA_REGISTRO(bool isPerform = false)
        {
            /*" -1016- INSPECT REG-SIH202A CONVERTING LOW-VALUE TO ' ' . */
            if (REG_SIH202A.IsEmpty())
            {
                _.Initialize(REG_SIH202A);
            }

            /*" -1017- WRITE REG-SIH202A. */
            SIH202A.Write(REG_SIH202A.GetMoveValues().ToString());

            /*" -1019- ADD 1 TO W-GRAVADOS. */
            W_GRAVADOS.Value = W_GRAVADOS + 1;

            /*" -1019- PERFORM R031-FETCH-SINISHIS THRU R031-EXIT. */

            R031_FETCH_SINISHIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R105-PRIMEIRA-DATA-INDENIZA-1 */
        private void R105_PRIMEIRA_DATA_INDENIZA_1(bool isPerform = false)
        {
            /*" -1029- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -1030- MOVE '9999-12-31' TO SINISHIS-DATA-MOVIMENTO. */
            _.Move("9999-12-31", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);

            /*" -1047- PERFORM R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1 */

            R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1();

            /*" -1050- IF (SINISMES-NUM-APOL-SINISTRO = 104800041631) */

            if ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO == 104800041631))
            {

                /*" -1052- DISPLAY 'SIN DATA - ' SINISMES-NUM-APOL-SINISTRO ' ' SINISHIS-DATA-MOVIMENTO */

                $"SIN DATA - {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO}"
                .Display();

                /*" -1054- END-IF. */
            }


            /*" -1055- IF (SQLCODE NOT = 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -1056- DISPLAY 'ERRO NO SELECT MIN(H.DATA_MOVIMENTO). 1 .' */
                _.Display($"ERRO NO SELECT MIN(H.DATA_MOVIMENTO). 1 .");

                /*" -1057- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1058- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1058- END-IF. */
            }


        }

        [StopWatch]
        /*" R105-PRIMEIRA-DATA-INDENIZA-1-DB-SELECT-1 */
        public void R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1()
        {
            /*" -1047- EXEC SQL SELECT MIN(H.DATA_MOVIMENTO) INTO :SINISHIS-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_SIS_FUNCAO_OPER O WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.NUM_FATOR = 1 AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) WITH UR END-EXEC. */

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
            /*" -1107- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", WABEND.WNR_EXEC_SQL);

            /*" -1125- PERFORM R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1 */

            R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1();

            /*" -1128- IF (SQLCODE NOT = 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -1129- DISPLAY 'ERRO NO SELECT MIN(H.DATA_MOVIMENTO). 3 .' */
                _.Display($"ERRO NO SELECT MIN(H.DATA_MOVIMENTO). 3 .");

                /*" -1130- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1131- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1131- END-IF. */
            }


        }

        [StopWatch]
        /*" R150-PRIMEIRA-DATA-INDENIZA-2-DB-SELECT-1 */
        public void R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1()
        {
            /*" -1125- EXEC SQL SELECT MIN(H.DATA_MOVIMENTO) INTO :SINISHIS-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_SIS_FUNCAO_OPER O WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.NUM_FATOR = 1 AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) WITH UR END-EXEC. */

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

        [StopWatch]
        /*" R107-LE-VALOR-PREMIO */
        private void R107_LE_VALOR_PREMIO(bool isPerform = false)
        {
            /*" -1181- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", WABEND.WNR_EXEC_SQL);

            /*" -1183- MOVE 0 TO SINISHIS-VAL-OPERACAO. */
            _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

            /*" -1204- PERFORM R107_LE_VALOR_PREMIO_DB_SELECT_1 */

            R107_LE_VALOR_PREMIO_DB_SELECT_1();

            /*" -1207- IF (SQLCODE = 0) */

            if ((DB.SQLCODE == 0))
            {

                /*" -1209- DISPLAY 'SIN S/ PLANILHA COM OP 11 OU 28 ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SIN S/ PLANILHA COM OP 11 OU 28 {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1211- END-IF. */
            }


            /*" -1212- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -1213- DISPLAY 'ERRO NO SELECT DO VALOR DO PREMIO.....' */
                _.Display($"ERRO NO SELECT DO VALOR DO PREMIO.....");

                /*" -1214- DISPLAY 'PARA SINISTRO SEM PLANILHA' */
                _.Display($"PARA SINISTRO SEM PLANILHA");

                /*" -1215- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1216- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1216- END-IF. */
            }


        }

        [StopWatch]
        /*" R107-LE-VALOR-PREMIO-DB-SELECT-1 */
        public void R107_LE_VALOR_PREMIO_DB_SELECT_1()
        {
            /*" -1204- EXEC SQL SELECT H.VAL_OPERACAO INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND H.COD_OPERACAO IN (11,28) AND NOT EXISTS (SELECT X.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO X, SEGUROS.GE_SIS_FUNCAO_OPER O WHERE X.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND X.OCORR_HISTORICO = H.OCORR_HISTORICO AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.NUM_FATOR = -1) AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) WITH UR END-EXEC. */

            var r107_LE_VALOR_PREMIO_DB_SELECT_1_Query1 = new R107_LE_VALOR_PREMIO_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R107_LE_VALOR_PREMIO_DB_SELECT_1_Query1.Execute(r107_LE_VALOR_PREMIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R107_EXIT*/

        [StopWatch]
        /*" R110-LE-AGENCIA-INDENIZA */
        private void R110_LE_AGENCIA_INDENIZA(bool isPerform = false)
        {
            /*" -1226- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", WABEND.WNR_EXEC_SQL);

            /*" -1247- PERFORM R110_LE_AGENCIA_INDENIZA_DB_DECLARE_1 */

            R110_LE_AGENCIA_INDENIZA_DB_DECLARE_1();

            /*" -1251- PERFORM R110_LE_AGENCIA_INDENIZA_DB_OPEN_1 */

            R110_LE_AGENCIA_INDENIZA_DB_OPEN_1();

            /*" -1254- IF (SQLCODE NOT = 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -1255- DISPLAY 'SI0202B - ERRO NO OPEN CURSOR YYY' */
                _.Display($"SI0202B - ERRO NO OPEN CURSOR YYY");

                /*" -1256- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1257- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1259- END-IF. */
            }


            /*" -1261- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", WABEND.WNR_EXEC_SQL);

            /*" -1265- PERFORM R110_LE_AGENCIA_INDENIZA_DB_FETCH_1 */

            R110_LE_AGENCIA_INDENIZA_DB_FETCH_1();

            /*" -1269- IF (SQLCODE = 0) AND (RALCHEDO-AGE-CENTRAL-PROD01 EQUAL 9876) */

            if ((DB.SQLCODE == 0) && (RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGE_CENTRAL_PROD01 == 9876))
            {

                /*" -1273- DISPLAY 'SINISTRO SEM SIVAT (V0RECHEQDOC = ' ' SIN ' SINISMES-NUM-APOL-SINISTRO ' OCOR ' SINISHIS-OCORR-HISTORICO ' DT ' SINISHIS-DATA-MOVIMENTO */

                $"SINISTRO SEM SIVAT (V0RECHEQDOC =  SIN {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO} OCOR {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} DT {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO}"
                .Display();

                /*" -1275- END-IF. */
            }


            /*" -1276- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -1277- DISPLAY 'ERRO NO SELECT RALACAO_CHEQ_DOC (AGE. CENTRAL.' */
                _.Display($"ERRO NO SELECT RALACAO_CHEQ_DOC (AGE. CENTRAL.");

                /*" -1278- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1279- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1281- END-IF. */
            }


            /*" -1281- PERFORM R110_LE_AGENCIA_INDENIZA_DB_CLOSE_1 */

            R110_LE_AGENCIA_INDENIZA_DB_CLOSE_1();

            /*" -1284- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1285- DISPLAY 'SI0202B - ERRO NO CLOSE CURSOR YYY' */
                _.Display($"SI0202B - ERRO NO CLOSE CURSOR YYY");

                /*" -1286- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1287- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1287- END-IF. */
            }


        }

        [StopWatch]
        /*" R110-LE-AGENCIA-INDENIZA-DB-OPEN-1 */
        public void R110_LE_AGENCIA_INDENIZA_DB_OPEN_1()
        {
            /*" -1251- EXEC SQL OPEN YYY END-EXEC. */

            YYY.Open();

        }

        [StopWatch]
        /*" R500-LE-PLANILHA-DECLARE-DB-DECLARE-1 */
        public void R500_LE_PLANILHA_DECLARE_DB_DECLARE_1()
        {
            /*" -1694- EXEC SQL DECLARE XXX CURSOR FOR SELECT H.NUM_APOL_SINISTRO , P.VAL_SALDO_DEVEDOR , P.VAL_ACORRIGIR , P.QTD_PRE_ARECUPERAR , P.VAL_PREMIO , MIN(H.DATA_MOVIMENTO) FROM SEGUROS.SINISTRO_HISTORICO H , SEGUROS.SINI_PLANHABIT01 P , SEGUROS.GE_SIS_FUNCAO_OPER O WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND P.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND P.OCORHIST = H.OCORR_HISTORICO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.NUM_FATOR = 1 AND NOT EXISTS (SELECT X.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO X WHERE X.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND X.OCORR_HISTORICO = H.OCORR_HISTORICO AND ( X.NOM_PROGRAMA <> 'SI0170B' OR X.NOM_PROGRAMA IS NULL) AND X.COD_OPERACAO = (SELECT O.COD_OPERACAO FROM SEGUROS.GE_SIS_FUNCAO_OPER O WHERE O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.NUM_FATOR = -1) ) AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) GROUP BY H.NUM_APOL_SINISTRO , P.VAL_SALDO_DEVEDOR , P.VAL_ACORRIGIR , P.QTD_PRE_ARECUPERAR , P.VAL_PREMIO ORDER BY H.NUM_APOL_SINISTRO , P.VAL_SALDO_DEVEDOR , P.VAL_ACORRIGIR , P.QTD_PRE_ARECUPERAR , P.VAL_PREMIO WITH UR END-EXEC. */
            XXX = new SI0202B_XXX(true);
            string GetQuery_XXX()
            {
                var query = @$"SELECT H.NUM_APOL_SINISTRO
							, 
							P.VAL_SALDO_DEVEDOR
							, 
							P.VAL_ACORRIGIR
							, 
							P.QTD_PRE_ARECUPERAR
							, 
							P.VAL_PREMIO
							, 
							MIN(H.DATA_MOVIMENTO) 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINI_PLANHABIT01 P
							, 
							SEGUROS.GE_SIS_FUNCAO_OPER O 
							WHERE H.NUM_APOL_SINISTRO = '{SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}' 
							AND P.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND P.OCORHIST = H.OCORR_HISTORICO 
							AND O.COD_OPERACAO = H.COD_OPERACAO 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.COD_FUNCAO = 2 
							AND O.NUM_FATOR = 1 
							AND NOT EXISTS 
							(SELECT X.NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_HISTORICO X 
							WHERE X.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND X.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND ( X.NOM_PROGRAMA <> 'SI0170B' 
							OR X.NOM_PROGRAMA IS NULL) 
							AND X.COD_OPERACAO = 
							(SELECT O.COD_OPERACAO 
							FROM SEGUROS.GE_SIS_FUNCAO_OPER O 
							WHERE O.IDE_SISTEMA = 'SI' 
							AND O.COD_FUNCAO = 2 
							AND O.NUM_FATOR = -1) ) 
							AND ( H.NOM_PROGRAMA <> 'SI0170B' 
							OR H.NOM_PROGRAMA IS NULL) 
							GROUP BY H.NUM_APOL_SINISTRO
							, 
							P.VAL_SALDO_DEVEDOR
							, 
							P.VAL_ACORRIGIR
							, 
							P.QTD_PRE_ARECUPERAR
							, 
							P.VAL_PREMIO 
							ORDER BY H.NUM_APOL_SINISTRO
							, 
							P.VAL_SALDO_DEVEDOR
							, 
							P.VAL_ACORRIGIR
							, 
							P.QTD_PRE_ARECUPERAR
							, 
							P.VAL_PREMIO";

                return query;
            }
            XXX.GetQueryEvent += GetQuery_XXX;

        }

        [StopWatch]
        /*" R110-LE-AGENCIA-INDENIZA-DB-FETCH-1 */
        public void R110_LE_AGENCIA_INDENIZA_DB_FETCH_1()
        {
            /*" -1265- EXEC SQL FETCH YYY INTO :RALCHEDO-AGE-CENTRAL-PROD01, :SINISHIS-OCORR-HISTORICO, :SINISHIS-DATA-MOVIMENTO END-EXEC. */

            if (YYY.Fetch())
            {
                _.Move(YYY.RALCHEDO_AGE_CENTRAL_PROD01, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGE_CENTRAL_PROD01);
                _.Move(YYY.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(YYY.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
            }

        }

        [StopWatch]
        /*" R110-LE-AGENCIA-INDENIZA-DB-CLOSE-1 */
        public void R110_LE_AGENCIA_INDENIZA_DB_CLOSE_1()
        {
            /*" -1281- EXEC SQL CLOSE YYY END-EXEC. */

            YYY.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R160-OBTER-ENDERECO */
        private void R160_OBTER_ENDERECO(bool isPerform = false)
        {
            /*" -1473- MOVE SINISMES-NUM-APOL-SINISTRO TO SI0202S-NUM-APOL-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI0202.SI0202S_PARAMETROS.SI0202S_ENTRADA.SI0202S_NUM_APOL_SINISTRO);

            /*" -1475- CALL W-SI0202S USING SI0202S-PARAMETROS. */
            _.Call(W_SI0202S, LBSI0202.SI0202S_PARAMETROS);

            /*" -1476- IF (SI0202S-RC = 0) */

            if ((LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_RC == 0))
            {

                /*" -1477- MOVE SI0202S-LOGRADOURO TO ENDHABIT-NOME-LOGRADOURO */
                _.Move(LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_LOGRADOURO, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_NOME_LOGRADOURO);

                /*" -1478- MOVE SI0202S-BAIRRO TO ENDHABIT-BAIRRO */
                _.Move(LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_BAIRRO, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_BAIRRO);

                /*" -1479- MOVE SI0202S-CIDADE TO ENDHABIT-CIDADE */
                _.Move(LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CIDADE, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_CIDADE);

                /*" -1480- MOVE SI0202S-UF TO ENDHABIT-UF */
                _.Move(LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_UF, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_UF);

                /*" -1481- MOVE SI0202S-CEP TO ENDHABIT-CEP */
                _.Move(LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CEP, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_CEP);

                /*" -1482- ELSE */
            }
            else
            {


                /*" -1483- IF (SI0202S-RC = 99) */

                if ((LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_RC == 99))
                {

                    /*" -1484- MOVE ALL '*' TO ENDHABIT-NOME-LOGRADOURO */
                    _.MoveAll("*", ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_NOME_LOGRADOURO);

                    /*" -1485- MOVE ALL '*' TO ENDHABIT-BAIRRO */
                    _.MoveAll("*", ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_BAIRRO);

                    /*" -1486- MOVE ALL '*' TO ENDHABIT-CIDADE */
                    _.MoveAll("*", ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_CIDADE);

                    /*" -1487- MOVE 'DF' TO ENDHABIT-UF */
                    _.Move("DF", ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_UF);

                    /*" -1488- MOVE ZEROS TO ENDHABIT-CEP */
                    _.Move(0, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_CEP);

                    /*" -1489- MOVE ZEROS TO ENDHABIT-NUM-IMOVEL */
                    _.Move(0, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_NUM_IMOVEL);

                    /*" -1490- END-IF */
                }


                /*" -1490- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/

        [StopWatch]
        /*" R165-SET-REG-ARQ-SAIDA */
        private void R165_SET_REG_ARQ_SAIDA(bool isPerform = false)
        {
            /*" -1499- MOVE ENDHABIT-NOME-LOGRADOURO TO REG-LOGRADOURO-DEVEDOR. */
            _.Move(ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_NOME_LOGRADOURO, REG_SIH202A.REG_LOGRADOURO_DEVEDOR);

            /*" -1500- MOVE ENDHABIT-BAIRRO TO REG-BAIRRO-DEVEDOR. */
            _.Move(ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_BAIRRO, REG_SIH202A.REG_BAIRRO_DEVEDOR);

            /*" -1501- MOVE ENDHABIT-CIDADE TO REG-CIDADE-DEVEDOR. */
            _.Move(ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_CIDADE, REG_SIH202A.REG_CIDADE_DEVEDOR);

            /*" -1502- MOVE ENDHABIT-UF TO REG-UF-DEVEDOR. */
            _.Move(ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_UF, REG_SIH202A.REG_UF_DEVEDOR);

            /*" -1503- MOVE ENDHABIT-UF TO REG-UF-SINISTRO. */
            _.Move(ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_UF, REG_SIH202A.REG_UF_SINISTRO);

            /*" -1504- MOVE ENDHABIT-CEP TO REG-CEP-DEVEDOR. */
            _.Move(ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_CEP, REG_SIH202A.REG_CEP_DEVEDOR);

            /*" -1505- MOVE ENDHABIT-CIDADE TO REG-CIDADE-SINISTRO. */
            _.Move(ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_CIDADE, REG_SIH202A.REG_CIDADE_SINISTRO);

            /*" -1505- MOVE SPACES TO REG-DATA-INDENIZACAO. */
            _.Move("", REG_SIH202A.REG_DATA_INDENIZACAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R165_EXIT*/

        [StopWatch]
        /*" R200-LE-PRE-LIBERACOES */
        private void R200_LE_PRE_LIBERACOES(bool isPerform = false)
        {
            /*" -1516- MOVE 0 TO HOST-TOTAL-PRE-LIBERACAO HOST-TOTAL-CANC-PRE-LIBERACAO. */
            _.Move(0, AREA_DE_WORK.HOST_TOTAL_PRE_LIBERACAO, AREA_DE_WORK.HOST_TOTAL_CANC_PRE_LIBERACAO);

            /*" -1518- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", WABEND.WNR_EXEC_SQL);

            /*" -1539- PERFORM R200_LE_PRE_LIBERACOES_DB_SELECT_1 */

            R200_LE_PRE_LIBERACOES_DB_SELECT_1();

            /*" -1542- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1543- DISPLAY 'ERRO NO SELECT SUM(H.VAL_OPERACAO) - (2).' */
                _.Display($"ERRO NO SELECT SUM(H.VAL_OPERACAO) - (2).");

                /*" -1544- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1546- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1549- GO TO R200-PULA-CANCELAMENTO. */

            R200_PULA_CANCELAMENTO(); //GOTO
            return;


        }

        [StopWatch]
        /*" R200-LE-PRE-LIBERACOES-DB-SELECT-1 */
        public void R200_LE_PRE_LIBERACOES_DB_SELECT_1()
        {
            /*" -1539- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :HOST-TOTAL-PRE-LIBERACAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO O WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.FUNCAO_OPERACAO = 'PRE' AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) AND NOT EXISTS (SELECT 1 FROM SEGUROS.SINISTRO_HISTORICO K WHERE K.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND K.OCORR_HISTORICO = H.OCORR_HISTORICO AND K.COD_OPERACAO IN (1191,1192,1193,1194,1091,1092,1093,1094) ) WITH UR END-EXEC. */

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
            /*" -1576- COMPUTE SINISHIS-VAL-OPERACAO = HOST-TOTAL-PRE-LIBERACAO + HOST-TOTAL-CANC-PRE-LIBERACAO. */
            SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = AREA_DE_WORK.HOST_TOTAL_PRE_LIBERACAO + AREA_DE_WORK.HOST_TOTAL_CANC_PRE_LIBERACAO;

        }

        [StopWatch]
        /*" R200-LE-PRE-LIBERACOES-DB-SELECT-2 */
        public void R200_LE_PRE_LIBERACOES_DB_SELECT_2()
        {
            /*" -1565- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO * -1),0) INTO :HOST-TOTAL-CANC-PRE-LIBERACAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO O WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.FUNCAO_OPERACAO = 'CPRE' AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) WITH UR END-EXEC. */

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
            /*" -1585- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", WABEND.WNR_EXEC_SQL);

            /*" -1601- PERFORM R210_LE_ESTORNO_DB_SELECT_1 */

            R210_LE_ESTORNO_DB_SELECT_1();

            /*" -1604- IF (SQLCODE NOT = 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -1605- DISPLAY 'ERRO NO SELECT SUM(H.VAL_OPERACAO) - (1).' */
                _.Display($"ERRO NO SELECT SUM(H.VAL_OPERACAO) - (1).");

                /*" -1606- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1607- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1607- END-IF. */
            }


        }

        [StopWatch]
        /*" R210-LE-ESTORNO-DB-SELECT-1 */
        public void R210_LE_ESTORNO_DB_SELECT_1()
        {
            /*" -1601- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_SIS_FUNCAO_OPER O WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.NUM_FATOR = -1 AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) WITH UR END-EXEC. */

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
        /*" R220-LE-VALOR-PAGO-EST */
        private void R220_LE_VALOR_PAGO_EST(bool isPerform = false)
        {
            /*" -1615- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WABEND.WNR_EXEC_SQL);

            /*" -1629- PERFORM R220_LE_VALOR_PAGO_EST_DB_SELECT_1 */

            R220_LE_VALOR_PAGO_EST_DB_SELECT_1();

            /*" -1632- IF (SQLCODE NOT = 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -1633- DISPLAY 'ERRO NO SELECT SUM(H.VAL_OPERACAO) - (3).' */
                _.Display($"ERRO NO SELECT SUM(H.VAL_OPERACAO) - (3).");

                /*" -1634- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1635- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1635- END-IF. */
            }


        }

        [StopWatch]
        /*" R220-LE-VALOR-PAGO-EST-DB-SELECT-1 */
        public void R220_LE_VALOR_PAGO_EST_DB_SELECT_1()
        {
            /*" -1629- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_SIS_FUNCAO_OPER O WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) WITH UR END-EXEC. */

            var r220_LE_VALOR_PAGO_EST_DB_SELECT_1_Query1 = new R220_LE_VALOR_PAGO_EST_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R220_LE_VALOR_PAGO_EST_DB_SELECT_1_Query1.Execute(r220_LE_VALOR_PAGO_EST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R220_EXIT*/

        [StopWatch]
        /*" R500-LE-PLANILHA-DECLARE */
        private void R500_LE_PLANILHA_DECLARE(bool isPerform = false)
        {
            /*" -1644- INITIALIZE DCLSINI-PLANHABIT01. */
            _.Initialize(
                SINIPLAN.DCLSINI_PLANHABIT01
            );

            /*" -1646- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", WABEND.WNR_EXEC_SQL);

            /*" -1694- PERFORM R500_LE_PLANILHA_DECLARE_DB_DECLARE_1 */

            R500_LE_PLANILHA_DECLARE_DB_DECLARE_1();

            /*" -1696- PERFORM R500_LE_PLANILHA_DECLARE_DB_OPEN_1 */

            R500_LE_PLANILHA_DECLARE_DB_OPEN_1();

            /*" -1699- IF (SQLCODE NOT = 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -1700- DISPLAY 'SI0202B - ERRO NO OPEN CURSOR XXX' */
                _.Display($"SI0202B - ERRO NO OPEN CURSOR XXX");

                /*" -1701- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1702- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1704- END-IF. */
            }


            /*" -1706- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WABEND.WNR_EXEC_SQL);

            /*" -1713- PERFORM R500_LE_PLANILHA_DECLARE_DB_FETCH_1 */

            R500_LE_PLANILHA_DECLARE_DB_FETCH_1();

            /*" -1716- IF (SQLCODE = 0) */

            if ((DB.SQLCODE == 0))
            {

                /*" -1717- MOVE 'SIM' TO W-CHAVE-TEM-PLANILHA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_PLANILHA);

                /*" -1719- END-IF. */
            }


            /*" -1720- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -1721- DISPLAY 'ERRO NA LEITURA DA SINI_PLANHABIT01 - 1' */
                _.Display($"ERRO NA LEITURA DA SINI_PLANHABIT01 - 1");

                /*" -1722- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1723- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1725- END-IF. */
            }


            /*" -1725- PERFORM R500_LE_PLANILHA_DECLARE_DB_CLOSE_1 */

            R500_LE_PLANILHA_DECLARE_DB_CLOSE_1();

            /*" -1728- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1729- DISPLAY 'SI0202B - ERRO NO CLOSE CURSOR XXX' */
                _.Display($"SI0202B - ERRO NO CLOSE CURSOR XXX");

                /*" -1730- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1731- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1731- END-IF. */
            }


        }

        [StopWatch]
        /*" R500-LE-PLANILHA-DECLARE-DB-OPEN-1 */
        public void R500_LE_PLANILHA_DECLARE_DB_OPEN_1()
        {
            /*" -1696- EXEC SQL OPEN XXX END-EXEC. */

            XXX.Open();

        }

        [StopWatch]
        /*" R500-LE-PLANILHA-DECLARE-DB-FETCH-1 */
        public void R500_LE_PLANILHA_DECLARE_DB_FETCH_1()
        {
            /*" -1713- EXEC SQL FETCH XXX INTO :SINISHIS-NUM-APOL-SINISTRO , :SINIPLAN-VAL-SALDO-DEVEDOR , :SINIPLAN-VAL-ACORRIGIR , :SINIPLAN-QTD-PRE-ARECUPERAR , :SINIPLAN-VAL-PREMIO , :SINISHIS-DATA-MOVIMENTO END-EXEC. */

            if (XXX.Fetch())
            {
                _.Move(XXX.HOST_DATA_HOJE_MENOS_05_DIAS, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(XXX.HOST_DATA_HOJE_MENOS_40_DIAS, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_SALDO_DEVEDOR);
            }

        }

        [StopWatch]
        /*" R500-LE-PLANILHA-DECLARE-DB-CLOSE-1 */
        public void R500_LE_PLANILHA_DECLARE_DB_CLOSE_1()
        {
            /*" -1725- EXEC SQL CLOSE XXX END-EXEC. */

            XXX.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/

        [StopWatch]
        /*" R510-LE-PLANILHA-SELECT */
        private void R510_LE_PLANILHA_SELECT(bool isPerform = false)
        {
            /*" -1741- INITIALIZE DCLSINI-PLANHABIT01. */
            _.Initialize(
                SINIPLAN.DCLSINI_PLANHABIT01
            );

            /*" -1743- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", WABEND.WNR_EXEC_SQL);

            /*" -1796- PERFORM R510_LE_PLANILHA_SELECT_DB_SELECT_1 */

            R510_LE_PLANILHA_SELECT_DB_SELECT_1();

            /*" -1805- IF (SQLCODE = 0) */

            if ((DB.SQLCODE == 0))
            {

                /*" -1806- MOVE 'SIM' TO W-CHAVE-TEM-PLANILHA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_PLANILHA);

                /*" -1808- END-IF. */
            }


            /*" -1809- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -1810- DISPLAY 'ERRO NA LEITURA DA SINI_PLANHABIT01 - 2' */
                _.Display($"ERRO NA LEITURA DA SINI_PLANHABIT01 - 2");

                /*" -1811- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -1812- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1812- END-IF. */
            }


        }

        [StopWatch]
        /*" R510-LE-PLANILHA-SELECT-DB-SELECT-1 */
        public void R510_LE_PLANILHA_SELECT_DB_SELECT_1()
        {
            /*" -1796- EXEC SQL SELECT H.NUM_APOL_SINISTRO , P.VAL_INDENIZACAO , P.VAL_SALDO_DEVEDOR , P.VAL_ACORRIGIR , P.QTD_PRE_ARECUPERAR , P.VAL_PREMIO , H.DATA_MOVIMENTO INTO :SINISHIS-NUM-APOL-SINISTRO , :SINIPLAN-VAL-INDENIZACAO , :SINIPLAN-VAL-SALDO-DEVEDOR , :SINIPLAN-VAL-ACORRIGIR , :SINIPLAN-QTD-PRE-ARECUPERAR , :SINIPLAN-VAL-PREMIO , :SINISHIS-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO H , SEGUROS.SINI_PLANHABIT01 P , SEGUROS.GE_SIS_FUNCAO_OPER O WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND H.COD_OPERACAO <> 1004 AND P.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND P.OCORHIST = H.OCORR_HISTORICO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.NUM_FATOR = 1 AND NOT EXISTS (SELECT X.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO X WHERE X.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND X.OCORR_HISTORICO = H.OCORR_HISTORICO AND ( X.NOM_PROGRAMA <> 'SI0170B' OR X.NOM_PROGRAMA IS NULL) AND X.COD_OPERACAO = (SELECT O.COD_OPERACAO FROM SEGUROS.GE_SIS_FUNCAO_OPER O WHERE O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.COD_OPERACAO <> 29 AND O.NUM_FATOR = -1) ) AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) WITH UR END-EXEC. */

            var r510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1 = new R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1.Execute(r510_LE_PLANILHA_SELECT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(executed_1.SINIPLAN_VAL_INDENIZACAO, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_INDENIZACAO);
                _.Move(executed_1.SINIPLAN_VAL_SALDO_DEVEDOR, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_SALDO_DEVEDOR);
                _.Move(executed_1.SINIPLAN_VAL_ACORRIGIR, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_ACORRIGIR);
                _.Move(executed_1.SINIPLAN_QTD_PRE_ARECUPERAR, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_QTD_PRE_ARECUPERAR);
                _.Move(executed_1.SINIPLAN_VAL_PREMIO, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_PREMIO);
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R510_EXIT*/

        [StopWatch]
        /*" R520-TRAZ-VALOR-FRANQUIA */
        private void R520_TRAZ_VALOR_FRANQUIA(bool isPerform = false)
        {
            /*" -1825- MOVE '520' TO WNR-EXEC-SQL. */
            _.Move("520", WABEND.WNR_EXEC_SQL);

            /*" -1830- MOVE ZEROS TO SINISHIS-VAL-OPERACAO. */
            _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

            /*" -1841- PERFORM R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1 */

            R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1();

            /*" -1862- PERFORM R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2 */

            R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2();

            /*" -1866- IF (SQLCODE NOT = 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -1867- IF (SQLCODE = 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -1868- MOVE ZEROS TO SINISHIS-VAL-OPERACAO */
                    _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                    /*" -1869- ELSE */
                }
                else
                {


                    /*" -1870- DISPLAY 'ERRO ACESSO SINISTRO_HISTORICO OPERACAO=2' */
                    _.Display($"ERRO ACESSO SINISTRO_HISTORICO OPERACAO=2");

                    /*" -1871- DISPLAY 'VALOR DA FRANQUIA DA CEF' */
                    _.Display($"VALOR DA FRANQUIA DA CEF");

                    /*" -1872- DISPLAY 'SINISTRO  = ' SINISMES-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO  = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                    /*" -1873- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -1874- END-IF */
                }


                /*" -1874- END-IF. */
            }


        }

        [StopWatch]
        /*" R520-TRAZ-VALOR-FRANQUIA-DB-SELECT-1 */
        public void R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1()
        {
            /*" -1841- EXEC SQL SELECT VALUE(SUM(VAL_OPERACAO),0) INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND H.COD_OPERACAO = 2 AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) WITH UR END-EXEC. */

            var r520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1_Query1 = new R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1_Query1.Execute(r520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R520_EXIT*/

        [StopWatch]
        /*" R520-TRAZ-VALOR-FRANQUIA-DB-SELECT-2 */
        public void R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2()
        {
            /*" -1862- EXEC SQL SELECT VALUE(SUM(VAL_OPERACAO),0) INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND H.COD_OPERACAO = 2 AND NOT EXISTS (SELECT Y.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO Y WHERE Y.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND Y.OCORR_HISTORICO = H.OCORR_HISTORICO AND Y.COD_OPERACAO = 1050) AND ( H.NOM_PROGRAMA <> 'SI0170B' OR H.NOM_PROGRAMA IS NULL) WITH UR END-EXEC. */

            var r520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1 = new R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1.Execute(r520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -1909- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1910- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1911- DISPLAY SQLERRMC. */
            _.Display(DB.SQLERRMC);

            /*" -1911- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1912- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1916- CLOSE SIH202A. */
            SIH202A.Close();

            /*" -1918- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1918- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_EXIT*/
    }
}