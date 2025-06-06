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
using Sias.VidaAzul.DB2.VA0140B;

namespace Code
{
    public class VA0140B
    {
        public bool IsCall { get; set; }

        public VA0140B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDAZUL                            *      */
        /*"      *   PROGRAMA ...............  VA0140B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  15/08/2019                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   JUNCAO DOS PROGRAMAS VA0139B, VG0138B E VG0139B              *      */
        /*"      *                                                                *      */
        /*"      *   HISTORIA 208078/208877                                       *      */
        /*"      *   FUNCAO .................  A PARTIR DA LEITURA DOS REGISTROS  *      */
        /*"      *   CADASTRADOS NA TABELA SEGUROS.HIST_CONT_PARCELVA GERA OS     *      */
        /*"      *   ARQUIVOS:                                                    *      */
        /*"      *   ARQSAI1 = ARQUIVO CONTENDO INCONSISTENCIAS PARA ANALISE, E   *      */
        /*"      *   ARQSAI2 = ARQUIVO CONTENDO REGISTROS PARA EMISSAO DE FATURAS *      */
        /*"      *             PELO PROGRAMA VA0141B.                             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.04 - 12/09/2022 - FLAVIO BICALHO         - DEMAMDA 367.420   *      */
        /*"      *                               ACERTO NO CAMPO CODIGO SUBGRUPO  *      */
        /*"      *                               QUANDO ESTIVER DESATUALIZADO     *      */
        /*"      *                               NA TABELA ENDOSSOS               *      */
        /*"      * PROCURAR POR V.04                                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.03 - 05/02/2021 -   FRANK   - DEMAMDA 311.198                *      */
        /*"      *                               BUSCAR A OPCAO DE PAGAMENTO DO   *      */
        /*"      *                               CLIENTE NA DATA DA GERACAO DA    *      */
        /*"      *                               PARCELA.                         *      */
        /*"      * PROCURAR POR V.03                                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.02 - 24/03/2020 -   HUSNI   - DEMAMDA 238609                 *      */
        /*"      *                               ACERTAR ORDER BY NA SECTION      *      */
        /*"      *                               R0640-00-SELECT-HISCONPA         *      */
        /*"      * PROCURAR POR V.02                                              *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _SAIDA01 { get; set; } = new FileBasis(new PIC("X", "1000", "X(1000)"));

        public FileBasis SAIDA01
        {
            get
            {
                _.Move(REG_VA0140B1, _SAIDA01); VarBasis.RedefinePassValue(REG_VA0140B1, _SAIDA01, REG_VA0140B1); return _SAIDA01;
            }
        }
        public FileBasis _SAIDA02 { get; set; } = new FileBasis(new PIC("X", "1000", "X(1000)"));

        public FileBasis SAIDA02
        {
            get
            {
                _.Move(REG_VA0140B2, _SAIDA02); VarBasis.RedefinePassValue(REG_VA0140B2, _SAIDA02, REG_VA0140B2); return _SAIDA02;
            }
        }
        public SortBasis<VA0140B_REG_SVA0140B> SVA0140B { get; set; } = new SortBasis<VA0140B_REG_SVA0140B>(new VA0140B_REG_SVA0140B());
        /*"01         REG-SVA0140B.*/
        public VA0140B_REG_SVA0140B REG_SVA0140B { get; set; } = new VA0140B_REG_SVA0140B();
        public class VA0140B_REG_SVA0140B : VarBasis
        {
            /*"  05       SOR-PROGRAMA          PIC  X(008).*/
            public StringBasis SOR_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05       SOR-TIPO-ENDOSSO      PIC  X(001).*/
            public StringBasis SOR_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-NUM-CERTIFICADO   PIC  9(015).*/
            public IntBasis SOR_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       SOR-NUM-PARCELA       PIC  9(004).*/
            public IntBasis SOR_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-NUM-TITULO        PIC  9(013).*/
            public IntBasis SOR_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       SOR-OCORR-HISTORICO   PIC  9(004).*/
            public IntBasis SOR_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-NUM-APOLICE       PIC  9(013).*/
            public IntBasis SOR_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       SOR-COD-SUBGRUPO      PIC  9(009).*/
            public IntBasis SOR_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-COD-FONTE         PIC  9(004).*/
            public IntBasis SOR_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-ORGAO             PIC  9(004).*/
            public IntBasis SOR_ORGAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-RAMO              PIC  9(004).*/
            public IntBasis SOR_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-MODALIDA          PIC  9(004).*/
            public IntBasis SOR_MODALIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-PREMIO-VG         PIC S9(013)V99.*/
            public DoubleBasis SOR_PREMIO_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-PREMIO-AP         PIC S9(013)V99.*/
            public DoubleBasis SOR_PREMIO_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-DATA-MOVIMENTO    PIC  X(010).*/
            public StringBasis SOR_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-SIT-REGISTRO      PIC  X(001).*/
            public StringBasis SOR_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-COD-OPERACAO      PIC  9(004).*/
            public IntBasis SOR_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-COD-PRODUTO       PIC  9(004).*/
            public IntBasis SOR_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-DATA-QUITACAO     PIC  X(010).*/
            public StringBasis SOR_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-SITUACAO          PIC  X(001).*/
            public StringBasis SOR_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-OCORHIST          PIC  9(004).*/
            public IntBasis SOR_OCORHIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-DTPROXVEN         PIC  X(010).*/
            public StringBasis SOR_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-CLIENTE           PIC  9(009).*/
            public IntBasis SOR_CLIENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-CGCCPF            PIC  9(015).*/
            public IntBasis SOR_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       SOR-DATA-NASCIMENTO   PIC  X(010).*/
            public StringBasis SOR_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-TIPO-PESSOA       PIC  X(001).*/
            public StringBasis SOR_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-PRODUTO           PIC  9(004).*/
            public IntBasis SOR_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-PRODEMIS          PIC  9(004).*/
            public IntBasis SOR_PRODEMIS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-DTINIEMI          PIC  X(010).*/
            public StringBasis SOR_DTINIEMI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-DTTEREMI          PIC  X(010).*/
            public StringBasis SOR_DTTEREMI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-ESTR-COBR         PIC  X(010).*/
            public StringBasis SOR_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-ORIG-PRODU        PIC  X(010).*/
            public StringBasis SOR_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-IND-IOF           PIC  X(001).*/
            public StringBasis SOR_IND_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-PER-IOF           PIC S9(003)V99.*/
            public DoubleBasis SOR_PER_IOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99."), 2);
            /*"  05       SOR-DATA-VENCIMENTO   PIC  X(010).*/
            public StringBasis SOR_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-DATA-INIVIGENCIA  PIC  X(010).*/
            public StringBasis SOR_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-DATA-TERVIGENCIA  PIC  X(010).*/
            public StringBasis SOR_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-OPCAO-PAGAMENTO   PIC  X(001).*/
            public StringBasis SOR_OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-PERI-PAGAMENTO    PIC  9(004).*/
            public IntBasis SOR_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-DIA-DEBITO        PIC  9(004).*/
            public IntBasis SOR_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-RCAPS             PIC  X(003).*/
            public StringBasis SOR_RCAPS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05       SOR-SITRCAP           PIC  X(001).*/
            public StringBasis SOR_SITRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-OPERCAP           PIC  9(003).*/
            public IntBasis SOR_OPERCAP { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05       SOR-VAL-RCAP          PIC S9(013)V99.*/
            public DoubleBasis SOR_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-DATA-RCAP         PIC  X(010).*/
            public StringBasis SOR_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-NRRCAP            PIC  9(009).*/
            public IntBasis SOR_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-MOVIMCOB          PIC  X(003).*/
            public StringBasis SOR_MOVIMCOB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05       SOR-SITMCOB           PIC  X(001).*/
            public StringBasis SOR_SITMCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-VAL-TITULO        PIC S9(013)V99.*/
            public DoubleBasis SOR_VAL_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-SITMDEB           PIC  X(001).*/
            public StringBasis SOR_SITMDEB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       SOR-MOVDEBCE          PIC  X(003).*/
            public StringBasis SOR_MOVDEBCE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05       SOR-CONVENIO          PIC  9(008).*/
            public IntBasis SOR_CONVENIO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05       SOR-VALOR-DEBITO      PIC S9(013)V99.*/
            public DoubleBasis SOR_VALOR_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-VALVGAP           PIC S9(013)V99.*/
            public DoubleBasis SOR_VALVGAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-ITEM              PIC  9(008).*/
            public IntBasis SOR_ITEM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05       SOR-DTINIVIG          PIC  X(010).*/
            public StringBasis SOR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-DATA-ADMISSAO     PIC  X(010).*/
            public StringBasis SOR_DATA_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-ADICIEA           PIC S9(003)V99.*/
            public DoubleBasis SOR_ADICIEA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99."), 2);
            /*"  05       SOR-ADICIPA           PIC S9(003)V99.*/
            public DoubleBasis SOR_ADICIPA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99."), 2);
            /*"  05       SOR-ADICIPD           PIC S9(003)V99.*/
            public DoubleBasis SOR_ADICIPD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99."), 2);
            /*"  05       SOR-INIZERO           PIC  X(010).*/
            public StringBasis SOR_INIZERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-TERZERO           PIC  X(010).*/
            public StringBasis SOR_TERZERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-BCOAVISO          PIC  9(004).*/
            public IntBasis SOR_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-AGEAVISO          PIC  9(004).*/
            public IntBasis SOR_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-NRAVISO           PIC  9(009).*/
            public IntBasis SOR_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-IMPMORNATU        PIC S9(013)V99.*/
            public DoubleBasis SOR_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-IMPMORACID        PIC S9(013)V99.*/
            public DoubleBasis SOR_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-IMPINVPERM        PIC S9(013)V99.*/
            public DoubleBasis SOR_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-IMPAMDS           PIC S9(013)V99.*/
            public DoubleBasis SOR_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-IMPDH             PIC S9(013)V99.*/
            public DoubleBasis SOR_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-IMPDIT            PIC S9(013)V99.*/
            public DoubleBasis SOR_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-VLPREMIO          PIC S9(013)V99.*/
            public DoubleBasis SOR_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-PRMDIT            PIC S9(013)V99.*/
            public DoubleBasis SOR_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-SALDO             PIC S9(013)V99.*/
            public DoubleBasis SOR_SALDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-NRSEQ             PIC  9(004).*/
            public IntBasis SOR_NRSEQ { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01        REG-VA0140B1              PIC  X(1000).*/
        }
        public StringBasis REG_VA0140B1 { get; set; } = new StringBasis(new PIC("X", "1000", "X(1000)."), @"");
        /*"01        REG-VA0140B2              PIC  X(1000).*/
        public StringBasis REG_VA0140B2 { get; set; } = new StringBasis(new PIC("X", "1000", "X(1000)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL03               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL03 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL04               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL04 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COUNT                PIC S9(004)     COMP.*/
        public IntBasis VIND_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALOR                PIC S9(004)     COMP.*/
        public IntBasis VIND_VALOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-DATAMES1            PIC  X(010).*/
        public StringBasis WHOST_DATAMES1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DATAMES2            PIC  X(010).*/
        public StringBasis WHOST_DATAMES2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DATA10              PIC  X(010).*/
        public StringBasis WHOST_DATA10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DTINIVIG            PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DTTERVIG            PIC  X(010).*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DTINI01             PIC  X(010).*/
        public StringBasis WHOST_DTINI01 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DTTER01             PIC  X(010).*/
        public StringBasis WHOST_DTTER01 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DTINI02             PIC  X(010).*/
        public StringBasis WHOST_DTINI02 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-PERI                PIC S9(009)     COMP.*/
        public IntBasis WHOST_PERI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WHOST-COUNT               PIC S9(009)     COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WHOST-DATA-INIVIGENCIA    PIC  X(010).*/
        public StringBasis WHOST_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DATA-TERVIGENCIA    PIC  X(010).*/
        public StringBasis WHOST_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DATA-GEROU-PARCELA  PIC  X(010)    VALUE SPACES.*/
        public StringBasis WHOST_DATA_GEROU_PARCELA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  W.*/
        public VA0140B_W W { get; set; } = new VA0140B_W();
        public class VA0140B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-SORT                 PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-APOLICOB             PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_APOLICOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-PARCEVID             PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_PARCEVID { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-OPCPAGVI             PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_OPCPAGVI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-RCAPS                PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_RCAPS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  AC-FATURA                 PIC  X(001)         VALUE SPACES*/
            public StringBasis AC_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-HISCONPA               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis LD_HISCONPA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  LD-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-DATA                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_DATA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-RCAPS                  PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_RCAPS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-PRODUVG                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_PRODUVG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-OPERACAO               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_OPERACAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-VALOR                  PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_VALOR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-IMPSEG                 PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_IMPSEG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-HISCOBPR               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_HISCOBPR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-OPCPAGVI               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_OPCPAGVI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-PARCEVID               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_PARCEVID { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-PERI                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_PERI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-ENDOSSO                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-PRMDIT                 PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_PRMDIT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-VIGENCIA               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_VIGENCIA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAVA01                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis AC_GRAVA01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAVA02                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis AC_GRAVA02 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  TT-VA0139B                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis TT_VA0139B { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  TT-VG0138B                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis TT_VG0138B { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  TT-VG0139B                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis TT_VG0139B { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  TT-BAIXA                  PIC  9(009)         VALUE ZEROS.*/
            public IntBasis TT_BAIXA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  TT-ESTORNO                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis TT_ESTORNO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-HISCONPA               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis UP_HISCONPA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-RCAPS                  PIC  9(009)         VALUE ZEROS.*/
            public IntBasis UP_RCAPS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  WS-NRSEQ                  PIC  9(004)         VALUE ZEROS.*/
            public IntBasis WS_NRSEQ { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WS-VALOR                  PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03         WS-CHAVE-ATU.*/
            public VA0140B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new VA0140B_WS_CHAVE_ATU();
            public class VA0140B_WS_CHAVE_ATU : VarBasis
            {
                /*"      10     ATU-NRCERTIF       PIC  9(015).*/
                public IntBasis ATU_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"      10     ATU-TIPO           PIC  X(001).*/
                public StringBasis ATU_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  03         WS-CHAVE-ANT.*/
            }
            public VA0140B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VA0140B_WS_CHAVE_ANT();
            public class VA0140B_WS_CHAVE_ANT : VarBasis
            {
                /*"      10     ANT-NRCERTIF       PIC  9(015).*/
                public IntBasis ANT_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"      10     ANT-TIPO           PIC  X(001).*/
                public StringBasis ANT_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  03         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_VA0140B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VA0140B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VA0140B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_VA0140B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VA0140B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VA0140B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_VA0140B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_VA0140B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VA0140B_FILLER_1 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_VA0140B_FILLER_1()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_VA0140B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_VA0140B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_VA0140B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VA0140B_FILLER_4 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public VA0140B_WTIME_DAYR WTIME_DAYR { get; set; } = new VA0140B_WTIME_DAYR();
                public class VA0140B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA         PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU         PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU         PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3         PIC  X(001).*/

                    public VA0140B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSE         PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03         WS-TIME.*/

                public _REDEF_VA0140B_FILLER_4()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public VA0140B_WS_TIME WS_TIME { get; set; } = new VA0140B_WS_TIME();
            public class VA0140B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WABEND.*/
            }
            public VA0140B_WABEND WABEND { get; set; } = new VA0140B_WABEND();
            public class VA0140B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' VA0140B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0140B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRMC = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRMC = ");
                /*"    05      WSQLERRMC           PIC  X(070) VALUE    SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01  ARQUIVOS-SAIDA.*/
            }
        }
        public VA0140B_ARQUIVOS_SAIDA ARQUIVOS_SAIDA { get; set; } = new VA0140B_ARQUIVOS_SAIDA();
        public class VA0140B_ARQUIVOS_SAIDA : VarBasis
        {
            /*"  03          LC01.*/
            public VA0140B_LC01 LC01 { get; set; } = new VA0140B_LC01();
            public class VA0140B_LC01 : VarBasis
            {
                /*"    10        FILLER              PIC  X(008)  VALUE             'PROGRAMA'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PROGRAMA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'TIPO'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"TIPO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'CERTIFICADO'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"CERTIFICADO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PARCELA'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PARCELA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(013)  VALUE             'TITULO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"TITULO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'OCORHIST'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"OCORHIST");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(013)  VALUE             'APOLICE'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'SUBGRUPO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SUBGRUPO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'FONTE'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"FONTE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PRODUTO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PRODEMI'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODEMI");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTINIEMI '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTINIEMI ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTTEREMI'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTTEREMI");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'ORGAO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"ORGAO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'RAMO'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"RAMO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(006)  VALUE             'MODALI'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"MODALI");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'CLIENTE '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"CLIENTE ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'CGCCPF '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"CGCCPF ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'TIPO'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"TIPO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'NASCIMENTO'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"NASCIMENTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTMOVTO  '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTMOVTO  ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTQITBCO '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTQITBCO ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTPROXVEN'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTPROXVEN");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'OCORHIST'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"OCORHIST");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'OPERACAO'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"OPERACAO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'PREMIO VG'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PREMIO VG");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'PREMIO AP'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PREMIO AP");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'ESTR-COBR '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ESTR-COBR ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'ORIG-PRODU'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ORIG-PRODU");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTVENCTO '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTVENCTO ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTINIVIG '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTINIVIG ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTTERVIG'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTTERVIG");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'SITUACAO'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SITUACAO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(003)  VALUE             'IOF'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"IOF");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(003)  VALUE             'DIA'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"DIA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'OPCAO'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"OPCAO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'PERI'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"PERI");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(003)  VALUE             'BCO'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"BCO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'AGE'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"AGE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'AVISO'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"AVISO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'IMPMORNATU'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"IMPMORNATU");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'IMPMORACID'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"IMPMORACID");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'IMPINVPERM'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"IMPINVPERM");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'IMPAMDS   '.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"IMPAMDS   ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'IMPDH     '.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"IMPDH     ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'IMPDIT    '.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"IMPDIT    ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'PRMDIT    '.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PRMDIT    ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'PREMIO VG + AP'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PREMIO VG + AP");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'RCAPS'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"RCAPS");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'VAL RCAP  '.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VAL RCAP  ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'MOVIMCOB'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"MOVIMCOB");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'VAL TITULO'.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VAL TITULO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(016)  VALUE             'MOVDEBCE'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"MOVDEBCE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'VALOR     '.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VALOR     ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'INICIO   '.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"INICIO   ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'ADMISSAO '.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ADMISSAO ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(006)  VALUE             'IEA'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"IEA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(006)  VALUE             'IPA'.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"IPA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(006)  VALUE             'IPD'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"IPD");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'INI ZERO '.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"INI ZERO ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'TER ZERO '.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"TER ZERO ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(040)  VALUE             'OBSERVACAO'.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"OBSERVACAO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(153)  VALUE SPACES.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "153", "X(153)"), @"");
                /*"  03          LD01.*/
            }
            public VA0140B_LD01 LD01 { get; set; } = new VA0140B_LD01();
            public class VA0140B_LD01 : VarBasis
            {
                /*"    10        LD01-PROGRAMA       PIC  X(008).*/
                public StringBasis LD01_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-TIPO-ENDOSSO   PIC  X(001).*/
                public StringBasis LD01_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE SPACES.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NRCERTIF       PIC  9(015).*/
                public IntBasis LD01_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NRPARCEL       PIC  9(007).*/
                public IntBasis LD01_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NRTIT          PIC  9(013).*/
                public IntBasis LD01_NRTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-OCORHIST1      PIC  9(008).*/
                public IntBasis LD01_OCORHIST1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NUMAPOL        PIC  9(013).*/
                public IntBasis LD01_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-CODSUBES       PIC  9(008).*/
                public IntBasis LD01_CODSUBES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-FONTE          PIC  9(005).*/
                public IntBasis LD01_FONTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-CODPRODU       PIC  9(007).*/
                public IntBasis LD01_CODPRODU { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PRODEMI        PIC  9(007).*/
                public IntBasis LD01_PRODEMI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTINIEMI       PIC  X(010).*/
                public StringBasis LD01_DTINIEMI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTTEREMI       PIC  X(010).*/
                public StringBasis LD01_DTTEREMI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ORGAO          PIC  9(005).*/
                public IntBasis LD01_ORGAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-RAMO           PIC  9(004).*/
                public IntBasis LD01_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-MODALI         PIC  9(006).*/
                public IntBasis LD01_MODALI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-CLIENTE        PIC  9(009).*/
                public IntBasis LD01_CLIENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-CGCCPF         PIC  9(015).*/
                public IntBasis LD01_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-TPPESSOA       PIC  X(001).*/
                public StringBasis LD01_TPPESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE SPACES.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTNASC         PIC  X(010).*/
                public StringBasis LD01_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTMOVTO        PIC  X(010).*/
                public StringBasis LD01_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTQITBCO       PIC  X(010).*/
                public StringBasis LD01_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTPROXVEN      PIC  X(010).*/
                public StringBasis LD01_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-OCORHIST2      PIC  9(008).*/
                public IntBasis LD01_OCORHIST2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-OPERACAO       PIC  9(008).*/
                public IntBasis LD01_OPERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PRMVG          PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_PRMVG { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PRMAP          PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_PRMAP { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ESTR-COBR      PIC  X(010).*/
                public StringBasis LD01_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ORIG-PRODU     PIC  X(010).*/
                public StringBasis LD01_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTVENCTO       PIC  X(010).*/
                public StringBasis LD01_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTINIVIG       PIC  X(010).*/
                public StringBasis LD01_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTTERVIG       PIC  X(010).*/
                public StringBasis LD01_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-SIT-CERTIF     PIC  X(001).*/
                public StringBasis LD01_SIT_CERTIF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER              PIC  X(007)  VALUE SPACES.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IOF            PIC  X(001).*/
                public StringBasis LD01_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER              PIC  X(002)  VALUE SPACES.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DIA-DEBITO     PIC  9(003).*/
                public IntBasis LD01_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-OPCAO          PIC  X(001).*/
                public StringBasis LD01_OPCAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER              PIC  X(004)  VALUE SPACES.*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PERI           PIC  9(004).*/
                public IntBasis LD01_PERI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-BCOAVISO       PIC  9(003).*/
                public IntBasis LD01_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-AGEAVISO       PIC  9(004).*/
                public IntBasis LD01_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NRAVISO        PIC  9(009).*/
                public IntBasis LD01_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMPMORNATU     PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMPMORACID     PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_IMPMORACID { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMPINVPERM     PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMPAMDS        PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_IMPAMDS { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMPDH          PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_IMPDH { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMPDIT         PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_IMPDIT { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PRMDIT         PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_PRMDIT { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VALVGAP        PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VALVGAP { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-RCAPS          PIC  X(004).*/
                public StringBasis LD01_RCAPS { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10        LD01-SITRCAP        PIC  X(002).*/
                public StringBasis LD01_SITRCAP { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10        LD01-OPERCAP        PIC  9(003).*/
                public IntBasis LD01_OPERCAP { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VAL-RCAP       PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-MOVIMCOB       PIC  X(004).*/
                public StringBasis LD01_MOVIMCOB { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10        LD01-SITMCOB        PIC  X(004).*/
                public StringBasis LD01_SITMCOB { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VAL-TITULO     PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VAL_TITULO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-MOVDEBCE       PIC  X(004).*/
                public StringBasis LD01_MOVDEBCE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10        LD01-SITMDEB        PIC  X(004).*/
                public StringBasis LD01_SITMDEB { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10        LD01-CONVENIO       PIC  9(008).*/
                public IntBasis LD01_CONVENIO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VALOR-DEBITO   PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VALOR_DEBITO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTINICIO       PIC  X(010).*/
                public StringBasis LD01_DTINICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTADMISSAO     PIC  X(010).*/
                public StringBasis LD01_DTADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ADICIEA        PIC  ZZ9,99.*/
                public DoubleBasis LD01_ADICIEA { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V99."), 2);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ADICIPA        PIC  ZZ9,99.*/
                public DoubleBasis LD01_ADICIPA { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V99."), 2);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_198 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ADICIPD        PIC  ZZ9,99.*/
                public DoubleBasis LD01_ADICIPD { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V99."), 2);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_199 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-INIENDZERO     PIC  X(010).*/
                public StringBasis LD01_INIENDZERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_200 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-TERENDZERO     PIC  X(010).*/
                public StringBasis LD01_TERENDZERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_201 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-OBSERVA        PIC  X(040).*/
                public StringBasis LD01_OBSERVA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_202 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(153)  VALUE SPACES.*/
                public StringBasis FILLER_203 { get; set; } = new StringBasis(new PIC("X", "153", "X(153)"), @"");
                /*"  03          LD02.*/
            }
            public VA0140B_LD02 LD02 { get; set; } = new VA0140B_LD02();
            public class VA0140B_LD02 : VarBasis
            {
                /*"    10        LD02-PROGRAMA          PIC X(008).*/
                public StringBasis LD02_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_204 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-TIPO-ENDOSSO      PIC X(001).*/
                public StringBasis LD02_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_205 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-NUM-CERTIFICADO   PIC 9(015).*/
                public IntBasis LD02_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_206 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-NUM-PARCELA       PIC 9(004).*/
                public IntBasis LD02_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_207 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-NUM-TITULO        PIC 9(013).*/
                public IntBasis LD02_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_208 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-OCORR-HISTORICO   PIC 9(004).*/
                public IntBasis LD02_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_209 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-NUM-APOLICE       PIC 9(013).*/
                public IntBasis LD02_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_210 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-COD-SUBGRUPO      PIC 9(009).*/
                public IntBasis LD02_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_211 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-COD-FONTE         PIC 9(004).*/
                public IntBasis LD02_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_212 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-ORGAO             PIC 9(004).*/
                public IntBasis LD02_ORGAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_213 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-RAMO              PIC 9(004).*/
                public IntBasis LD02_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_214 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-MODALIDA          PIC 9(004).*/
                public IntBasis LD02_MODALIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_215 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-PREMIO-VG         PIC 9(013)V99.*/
                public DoubleBasis LD02_PREMIO_VG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_216 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-PREMIO-AP         PIC 9(013)V99.*/
                public DoubleBasis LD02_PREMIO_AP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_217 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DATA-MOVIMENTO    PIC X(010).*/
                public StringBasis LD02_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_218 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-SIT-REGISTRO      PIC X(001).*/
                public StringBasis LD02_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_219 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-COD-OPERACAO      PIC 9(004).*/
                public IntBasis LD02_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_220 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-COD-PRODUTO       PIC 9(004).*/
                public IntBasis LD02_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_221 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DATA-QUITACAO     PIC X(010).*/
                public StringBasis LD02_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_222 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-SITUACAO          PIC X(001).*/
                public StringBasis LD02_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_223 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-OCORHIST          PIC 9(004).*/
                public IntBasis LD02_OCORHIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_224 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DTPROXVEN         PIC X(010).*/
                public StringBasis LD02_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_225 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-CLIENTE           PIC 9(009).*/
                public IntBasis LD02_CLIENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_226 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-CGCCPF            PIC 9(015).*/
                public IntBasis LD02_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_227 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DATA-NASCIMENTO   PIC X(010).*/
                public StringBasis LD02_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_228 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-TIPO-PESSOA       PIC X(001).*/
                public StringBasis LD02_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_229 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-PRODUTO           PIC 9(004).*/
                public IntBasis LD02_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_230 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-PRODEMIS          PIC 9(004).*/
                public IntBasis LD02_PRODEMIS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_231 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DTINIEMI          PIC X(010).*/
                public StringBasis LD02_DTINIEMI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_232 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DTTEREMI          PIC X(010).*/
                public StringBasis LD02_DTTEREMI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_233 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-ESTR-COBR         PIC X(010).*/
                public StringBasis LD02_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_234 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-ORIG-PRODU        PIC X(010).*/
                public StringBasis LD02_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_235 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-IND-IOF           PIC X(001).*/
                public StringBasis LD02_IND_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_236 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-PER-IOF           PIC 9(003)V99.*/
                public DoubleBasis LD02_PER_IOF { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_237 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DATA-VENCIMENTO   PIC X(010).*/
                public StringBasis LD02_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_238 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DATA-INIVIGENCIA  PIC X(010).*/
                public StringBasis LD02_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_239 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DATA-TERVIGENCIA  PIC X(010).*/
                public StringBasis LD02_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_240 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-OPCAO-PAGAMENTO   PIC X(001).*/
                public StringBasis LD02_OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_241 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-PERI-PAGAMENTO    PIC 9(004).*/
                public IntBasis LD02_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_242 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DIA-DEBITO        PIC 9(004).*/
                public IntBasis LD02_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_243 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-RCAPS             PIC X(003).*/
                public StringBasis LD02_RCAPS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_244 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-SITRCAP           PIC X(001).*/
                public StringBasis LD02_SITRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_245 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-OPERCAP           PIC 9(003).*/
                public IntBasis LD02_OPERCAP { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_246 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-VAL-RCAP          PIC 9(013)V99.*/
                public DoubleBasis LD02_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_247 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-MOVIMCOB          PIC X(003).*/
                public StringBasis LD02_MOVIMCOB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_248 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-SITMCOB           PIC X(001).*/
                public StringBasis LD02_SITMCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_249 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-VAL-TITULO        PIC 9(013)V99.*/
                public DoubleBasis LD02_VAL_TITULO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_250 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-SITMDEB           PIC X(001).*/
                public StringBasis LD02_SITMDEB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_251 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-MOVDEBCE          PIC X(003).*/
                public StringBasis LD02_MOVDEBCE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_252 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-CONVENIO          PIC 9(008).*/
                public IntBasis LD02_CONVENIO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_253 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-VALOR-DEBITO      PIC 9(013)V99.*/
                public DoubleBasis LD02_VALOR_DEBITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_254 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-VALVGAP           PIC 9(013)V99.*/
                public DoubleBasis LD02_VALVGAP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_255 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DTINIVIG          PIC X(010).*/
                public StringBasis LD02_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_256 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DATA-ADMISSAO     PIC X(010).*/
                public StringBasis LD02_DATA_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_257 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-ADICIEA           PIC 9(003)V99.*/
                public DoubleBasis LD02_ADICIEA { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_258 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-ADICIPA           PIC 9(003)V99.*/
                public DoubleBasis LD02_ADICIPA { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_259 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-ADICIPD           PIC 9(003)V99.*/
                public DoubleBasis LD02_ADICIPD { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_260 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-INIZERO           PIC X(010).*/
                public StringBasis LD02_INIZERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_261 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-TERZERO           PIC X(010).*/
                public StringBasis LD02_TERZERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_262 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-BCOAVISO          PIC 9(004).*/
                public IntBasis LD02_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_263 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-AGEAVISO          PIC 9(004).*/
                public IntBasis LD02_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_264 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-NRAVISO           PIC 9(009).*/
                public IntBasis LD02_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_265 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-IMPMORNATU        PIC 9(013)V99.*/
                public DoubleBasis LD02_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_266 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-IMPMORACID        PIC 9(013)V99.*/
                public DoubleBasis LD02_IMPMORACID { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_267 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-IMPINVPERM        PIC 9(013)V99.*/
                public DoubleBasis LD02_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_268 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-IMPAMDS           PIC 9(013)V99.*/
                public DoubleBasis LD02_IMPAMDS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_269 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-IMPDH             PIC 9(013)V99.*/
                public DoubleBasis LD02_IMPDH { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_270 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-IMPDIT            PIC 9(013)V99.*/
                public DoubleBasis LD02_IMPDIT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_271 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-PRMDIT            PIC 9(013)V99.*/
                public DoubleBasis LD02_PRMDIT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_272 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-IMPRTO            PIC 9(013)V99.*/
                public DoubleBasis LD02_IMPRTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_273 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-PRMRTO            PIC 9(013)V99.*/
                public DoubleBasis LD02_PRMRTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_274 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-APOLICE           PIC 9(013).*/
                public IntBasis LD02_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_275 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-ENDOSSO           PIC 9(009).*/
                public IntBasis LD02_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_276 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-RAMO-EMISSOR      PIC 9(009).*/
                public IntBasis LD02_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_277 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-SUBGRUPO          PIC 9(009).*/
                public IntBasis LD02_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_278 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-FONTE             PIC 9(004).*/
                public IntBasis LD02_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_279 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-PARVG082          PIC 9(009).*/
                public IntBasis LD02_PARVG082 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_280 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-VALVG082          PIC 9(013)V99.*/
                public DoubleBasis LD02_VALVG082 { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_281 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-APOLICOB          PIC 9(009).*/
                public IntBasis LD02_APOLICOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_282 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-NRRCAP            PIC 9(009).*/
                public IntBasis LD02_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_283 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-DATA-RCAP         PIC X(010).*/
                public StringBasis LD02_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_284 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-SALDO             PIC 9(013)V99.*/
                public DoubleBasis LD02_SALDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_285 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-ITEM              PIC 9(009).*/
                public IntBasis LD02_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_286 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-VLPREMIO          PIC 9(013)V99.*/
                public DoubleBasis LD02_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_287 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-NRSEQ             PIC 9(004).*/
                public IntBasis LD02_NRSEQ { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_288 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD02-OCOVG082          PIC 9(004).*/
                public IntBasis LD02_OCOVG082 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_289 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.SEGVGAP SEGVGAP { get; set; } = new Dclgens.SEGVGAP();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.VG082 VG082 { get; set; } = new Dclgens.VG082();
        public VA0140B_V0HISCONPA V0HISCONPA { get; set; } = new VA0140B_V0HISCONPA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SVA0140B_FILE_NAME_P, string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SVA0140B.SetFile(SVA0140B_FILE_NAME_P);
                SAIDA01.SetFile(SAIDA01_FILE_NAME_P);
                SAIDA02.SetFile(SAIDA02_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -830- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -831- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -833- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -835- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -838- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -839- DISPLAY ' VA0140B - CONSISTENCIAS PARA EMISSAO DE FATURAS  ' */
            _.Display($" VA0140B - CONSISTENCIAS PARA EMISSAO DE FATURAS  ");

            /*" -840- DISPLAY ' ' */
            _.Display($" ");

            /*" -841- DISPLAY 'VERSAO V.04 : ' FUNCTION WHEN-COMPILED ' - 367.420' */

            $"VERSAO V.04 : FUNCTION{_.WhenCompiled()} - 367.420"
            .Display();

            /*" -842- DISPLAY ' ' */
            _.Display($" ");

            /*" -849- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -850- DISPLAY '   ' */
            _.Display($"   ");

            /*" -851- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -855- DISPLAY '   ' */
            _.Display($"   ");

            /*" -858- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -872- SORT SVA0140B ON ASCENDING KEY SOR-TIPO-ENDOSSO SOR-NUM-CERTIFICADO SOR-NUM-PARCELA SOR-OCORR-HISTORICO SOR-NUM-APOLICE SOR-COD-SUBGRUPO SOR-COD-FONTE INPUT PROCEDURE R0190-00-SELECIONA THRU R0190-99-SAIDA OUTPUT PROCEDURE R0500-00-PROCESSA-SORT THRU R0500-99-SAIDA. */
            SVA0140B.Sort("SOR-TIPO-ENDOSSO,SOR-NUM-CERTIFICADO,SOR-NUM-PARCELA,SOR-OCORR-HISTORICO,SOR-NUM-APOLICE,SOR-COD-SUBGRUPO,SOR-COD-FONTE", () => R0190_00_SELECIONA_SECTION(), () => R0500_00_PROCESSA_SORT_SECTION());

            /*" -876- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -877- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -878- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -879- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -880- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -881- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -881- DISPLAY 'FIM    VA0140B    ' WTIME-DAYR. */
            _.Display($"FIM    VA0140B    {W.FILLER_4.WTIME_DAYR}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -886- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -891- CLOSE SAIDA01 SAIDA02. */
            SAIDA01.Close();
            SAIDA02.Close();

            /*" -893- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -894- DISPLAY ' ' */
            _.Display($" ");

            /*" -895- DISPLAY 'VA0140B - FIM NORMAL' */
            _.Display($"VA0140B - FIM NORMAL");

            /*" -898- DISPLAY ' ' */
            _.Display($" ");

            /*" -898- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -907- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", W.WABEND.WNR_EXEC_SQL);

            /*" -908- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -909- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -910- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -911- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -912- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -913- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -916- DISPLAY 'INICIO VA0140B    ' WTIME-DAYR. */
            _.Display($"INICIO VA0140B    {W.FILLER_4.WTIME_DAYR}");

            /*" -920- OPEN OUTPUT SAIDA01 SAIDA02. */
            SAIDA01.Open(REG_VA0140B1);
            SAIDA02.Open(REG_VA0140B2);

            /*" -923- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -924- DISPLAY ' ' . */
            _.Display($" ");

            /*" -926- DISPLAY 'DATA DE MOVIMENTO ..... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DE MOVIMENTO ..... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -929- DISPLAY ' ' . */
            _.Display($" ");

            /*" -932- WRITE REG-VA0140B1 FROM LC01. */
            _.Move(ARQUIVOS_SAIDA.LC01.GetMoveValues(), REG_VA0140B1);

            SAIDA01.Write(REG_VA0140B1.GetMoveValues().ToString());

            /*" -932- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -945- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -954- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -958- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -959- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -959- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -954- EXEC SQL SELECT DATA_MOV_ABERTO ,DATA_MOV_ABERTO - 10 MONTHS INTO :SISTEMAS-DATA-MOV-ABERTO ,:WHOST-DATA10 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA10, WHOST_DATA10);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0190-00-SELECIONA-SECTION */
        private void R0190_00_SELECIONA_SECTION()
        {
            /*" -972- MOVE '0190' TO WNR-EXEC-SQL. */
            _.Move("0190", W.WABEND.WNR_EXEC_SQL);

            /*" -973- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -974- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -975- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -976- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -977- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -978- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -980- DISPLAY 'DECLARE HISCONPA  ' WTIME-DAYR. */
            _.Display($"DECLARE HISCONPA  {W.FILLER_4.WTIME_DAYR}");

            /*" -981- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -983- PERFORM R0200-00-DECLARE-HISCONPA. */

            R0200_00_DECLARE_HISCONPA_SECTION();

            /*" -985- PERFORM R0210-00-FETCH-HISCONPA. */

            R0210_00_FETCH_HISCONPA_SECTION();

            /*" -989- PERFORM R0220-00-PROCESSA-HISCONPA UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0220_00_PROCESSA_HISCONPA_SECTION();
            }

            /*" -989- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -993- DISPLAY ' ' . */
            _.Display($" ");

            /*" -994- DISPLAY 'LIDOS HISCONPA ............. ' LD-HISCONPA */
            _.Display($"LIDOS HISCONPA ............. {W.LD_HISCONPA}");

            /*" -995- DISPLAY ' ' . */
            _.Display($" ");

            /*" -996- DISPLAY 'DESPREZA DATA .............. ' DP-DATA */
            _.Display($"DESPREZA DATA .............. {W.DP_DATA}");

            /*" -997- DISPLAY 'DESPREZA RCAP DEVOLVIDO .... ' DP-RCAPS */
            _.Display($"DESPREZA RCAP DEVOLVIDO .... {W.DP_RCAPS}");

            /*" -998- DISPLAY 'DESPREZA ORIG-PRODU ........ ' DP-PRODUVG */
            _.Display($"DESPREZA ORIG-PRODU ........ {W.DP_PRODUVG}");

            /*" -999- DISPLAY 'DESPREZA OPERACAO .......... ' DP-OPERACAO */
            _.Display($"DESPREZA OPERACAO .......... {W.DP_OPERACAO}");

            /*" -1000- DISPLAY 'DESPREZA VALOR ............. ' DP-VALOR */
            _.Display($"DESPREZA VALOR ............. {W.DP_VALOR}");

            /*" -1001- DISPLAY 'DESPREZA I.S. .............. ' DP-IMPSEG */
            _.Display($"DESPREZA I.S. .............. {W.DP_IMPSEG}");

            /*" -1002- DISPLAY 'DESPREZA HISCOBPR .......... ' DP-HISCOBPR */
            _.Display($"DESPREZA HISCOBPR .......... {W.DP_HISCOBPR}");

            /*" -1003- DISPLAY 'DESPREZA OPCPAGVI .......... ' DP-OPCPAGVI */
            _.Display($"DESPREZA OPCPAGVI .......... {W.DP_OPCPAGVI}");

            /*" -1004- DISPLAY 'DESPREZA PARCEVID .......... ' DP-PARCEVID */
            _.Display($"DESPREZA PARCEVID .......... {W.DP_PARCEVID}");

            /*" -1005- DISPLAY 'DESPREZA PERI ZERO ......... ' DP-PERI */
            _.Display($"DESPREZA PERI ZERO ......... {W.DP_PERI}");

            /*" -1006- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1007- DISPLAY 'TRATA VA0139B .............. ' TT-VA0139B */
            _.Display($"TRATA VA0139B .............. {W.TT_VA0139B}");

            /*" -1008- DISPLAY 'TRATA VG0138B .............. ' TT-VG0138B */
            _.Display($"TRATA VG0138B .............. {W.TT_VG0138B}");

            /*" -1009- DISPLAY 'TRATA VG0139B .............. ' TT-VG0139B */
            _.Display($"TRATA VG0139B .............. {W.TT_VG0139B}");

            /*" -1010- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1011- DISPLAY 'TRATA BAIXA ................ ' TT-BAIXA */
            _.Display($"TRATA BAIXA ................ {W.TT_BAIXA}");

            /*" -1012- DISPLAY 'TRATA ESTORNO .............. ' TT-ESTORNO */
            _.Display($"TRATA ESTORNO .............. {W.TT_ESTORNO}");

            /*" -1013- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1014- DISPLAY 'GRAVADOS SORT .............. ' GV-SORT. */
            _.Display($"GRAVADOS SORT .............. {W.GV_SORT}");

            /*" -1014- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0190_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-HISCONPA-SECTION */
        private void R0200_00_DECLARE_HISCONPA_SECTION()
        {
            /*" -1027- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", W.WABEND.WNR_EXEC_SQL);

            /*" -1087- PERFORM R0200_00_DECLARE_HISCONPA_DB_DECLARE_1 */

            R0200_00_DECLARE_HISCONPA_DB_DECLARE_1();

            /*" -1089- PERFORM R0200_00_DECLARE_HISCONPA_DB_OPEN_1 */

            R0200_00_DECLARE_HISCONPA_DB_OPEN_1();

            /*" -1093- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1094- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (HISCONPA)  ' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (HISCONPA)  ");

                /*" -1094- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-HISCONPA-DB-DECLARE-1 */
        public void R0200_00_DECLARE_HISCONPA_DB_DECLARE_1()
        {
            /*" -1087- EXEC SQL DECLARE V0HISCONPA CURSOR WITH HOLD FOR SELECT A.NUM_CERTIFICADO ,A.NUM_PARCELA ,A.NUM_TITULO ,A.OCORR_HISTORICO ,A.NUM_APOLICE ,A.COD_SUBGRUPO ,A.COD_FONTE ,A.PREMIO_VG ,A.PREMIO_AP ,A.DATA_MOVIMENTO ,A.SIT_REGISTRO ,A.COD_OPERACAO ,B.COD_PRODUTO ,B.COD_CLIENTE ,B.COD_FONTE ,B.DATA_QUITACAO ,B.SIT_REGISTRO ,B.OCORR_HISTORICO ,B.DTPROXVEN ,UCASE(C.NOME_RAZAO) ,C.TIPO_PESSOA ,C.CGCCPF ,C.DATA_NASCIMENTO ,D.COD_PRODUTO ,D.ESTR_COBR ,D.ORIG_PRODU ,E.COD_MODALIDADE ,E.ORGAO_EMISSOR ,E.RAMO_EMISSOR ,F.DATA_INIVIGENCIA ,F.DATA_TERVIGENCIA ,F.DATA_TERVIGENCIA - 1 MONTHS FROM SEGUROS.HIST_CONT_PARCELVA A ,SEGUROS.PROPOSTAS_VA B ,SEGUROS.CLIENTES C ,SEGUROS.PRODUTOS_VG D ,SEGUROS.APOLICES E ,SEGUROS.ENDOSSOS F WHERE A.DTFATUR IS NULL AND A.SIT_REGISTRO IN ( '0' , '3' ) AND A.NUM_APOLICE <> 0103701139293 AND A.NUM_APOLICE <> 0103701139296 AND A.DATA_MOVIMENTO <= :SISTEMAS-DATA-MOV-ABERTO AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.SIT_REGISTRO IN ( '3' , '4' , '6' ) AND C.COD_CLIENTE = B.COD_CLIENTE AND D.NUM_APOLICE = B.NUM_APOLICE AND D.COD_SUBGRUPO = B.COD_SUBGRUPO AND D.ESTR_COBR IN ( 'MULT' , 'FEDERAL' ) AND D.DIA_FATURA = 31 AND E.NUM_APOLICE = A.NUM_APOLICE AND F.NUM_APOLICE = E.NUM_APOLICE AND F.NUM_ENDOSSO = 0 ORDER BY A.NUM_CERTIFICADO ,A.NUM_PARCELA ,A.OCORR_HISTORICO END-EXEC. */
            V0HISCONPA = new VA0140B_V0HISCONPA(true);
            string GetQuery_V0HISCONPA()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO 
							,A.NUM_PARCELA 
							,A.NUM_TITULO 
							,A.OCORR_HISTORICO 
							,A.NUM_APOLICE 
							,A.COD_SUBGRUPO 
							,A.COD_FONTE 
							,A.PREMIO_VG 
							,A.PREMIO_AP 
							,A.DATA_MOVIMENTO 
							,A.SIT_REGISTRO 
							,A.COD_OPERACAO 
							,B.COD_PRODUTO 
							,B.COD_CLIENTE 
							,B.COD_FONTE 
							,B.DATA_QUITACAO 
							,B.SIT_REGISTRO 
							,B.OCORR_HISTORICO 
							,B.DTPROXVEN 
							,UCASE(C.NOME_RAZAO) 
							,C.TIPO_PESSOA 
							,C.CGCCPF 
							,C.DATA_NASCIMENTO 
							,D.COD_PRODUTO 
							,D.ESTR_COBR 
							,D.ORIG_PRODU 
							,E.COD_MODALIDADE 
							,E.ORGAO_EMISSOR 
							,E.RAMO_EMISSOR 
							,F.DATA_INIVIGENCIA 
							,F.DATA_TERVIGENCIA 
							,F.DATA_TERVIGENCIA - 1 MONTHS 
							FROM SEGUROS.HIST_CONT_PARCELVA A 
							,SEGUROS.PROPOSTAS_VA B 
							,SEGUROS.CLIENTES C 
							,SEGUROS.PRODUTOS_VG D 
							,SEGUROS.APOLICES E 
							,SEGUROS.ENDOSSOS F 
							WHERE A.DTFATUR IS NULL 
							AND A.SIT_REGISTRO IN ( '0'
							, '3' ) 
							AND A.NUM_APOLICE <> 0103701139293 
							AND A.NUM_APOLICE <> 0103701139296 
							AND A.DATA_MOVIMENTO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.SIT_REGISTRO IN ( '3'
							, '4'
							, '6' ) 
							AND C.COD_CLIENTE = B.COD_CLIENTE 
							AND D.NUM_APOLICE = B.NUM_APOLICE 
							AND D.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND D.ESTR_COBR IN ( 'MULT'
							, 'FEDERAL' ) 
							AND D.DIA_FATURA = 31 
							AND E.NUM_APOLICE = A.NUM_APOLICE 
							AND F.NUM_APOLICE = E.NUM_APOLICE 
							AND F.NUM_ENDOSSO = 0 
							ORDER BY A.NUM_CERTIFICADO 
							,A.NUM_PARCELA 
							,A.OCORR_HISTORICO";

                return query;
            }
            V0HISCONPA.GetQueryEvent += GetQuery_V0HISCONPA;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-HISCONPA-DB-OPEN-1 */
        public void R0200_00_DECLARE_HISCONPA_DB_OPEN_1()
        {
            /*" -1089- EXEC SQL OPEN V0HISCONPA END-EXEC. */

            V0HISCONPA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-HISCONPA-SECTION */
        private void R0210_00_FETCH_HISCONPA_SECTION()
        {
            /*" -1107- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", W.WABEND.WNR_EXEC_SQL);

            /*" -1140- PERFORM R0210_00_FETCH_HISCONPA_DB_FETCH_1 */

            R0210_00_FETCH_HISCONPA_DB_FETCH_1();

            /*" -1144- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1144- PERFORM R0210_00_FETCH_HISCONPA_DB_CLOSE_1 */

                R0210_00_FETCH_HISCONPA_DB_CLOSE_1();

                /*" -1146- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -1148- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1149- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1150- DISPLAY 'R0210-00 - PROBLEMAS FETCH   (HISCONPA)  ' */
                _.Display($"R0210-00 - PROBLEMAS FETCH   (HISCONPA)  ");

                /*" -1153- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1154- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -1157- MOVE SPACES TO CLIENTES-DATA-NASCIMENTO. */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
            }


            /*" -1158- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -1161- MOVE SPACES TO PRODUVG-ESTR-COBR. */
                _.Move("", PRODUVG.DCLPRODUTOS_VG.PRODUVG_ESTR_COBR);
            }


            /*" -1162- IF VIND-NULL03 LESS ZEROS */

            if (VIND_NULL03 < 00)
            {

                /*" -1166- MOVE SPACES TO PRODUVG-ORIG-PRODU. */
                _.Move("", PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);
            }


            /*" -1167- IF HISCONPA-COD-FONTE EQUAL ZEROS */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_FONTE == 00)
            {

                /*" -1168- IF PROPOVA-COD-FONTE EQUAL ZEROS */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE == 00)
                {

                    /*" -1170- MOVE 5 TO HISCONPA-COD-FONTE */
                    _.Move(5, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_FONTE);

                    /*" -1171- ELSE */
                }
                else
                {


                    /*" -1175- MOVE PROPOVA-COD-FONTE TO HISCONPA-COD-FONTE. */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_FONTE);
                }

            }


            /*" -1179- MOVE ENDOSSOS-DATA-TERVIGENCIA TO WHOST-DATAMES2. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, WHOST_DATAMES2);

            /*" -1181- ADD 1 TO LD-HISCONPA. */
            W.LD_HISCONPA.Value = W.LD_HISCONPA + 1;

            /*" -1183- MOVE LD-HISCONPA TO AC-LIDOS. */
            _.Move(W.LD_HISCONPA, W.AC_LIDOS);

            /*" -1185- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -1186- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -1187- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -1188- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -1189- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -1190- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -1191- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -1192- DISPLAY 'LIDOS HISCONPA     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS HISCONPA     {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0210-00-FETCH-HISCONPA-DB-FETCH-1 */
        public void R0210_00_FETCH_HISCONPA_DB_FETCH_1()
        {
            /*" -1140- EXEC SQL FETCH V0HISCONPA INTO :HISCONPA-NUM-CERTIFICADO ,:HISCONPA-NUM-PARCELA ,:HISCONPA-NUM-TITULO ,:HISCONPA-OCORR-HISTORICO ,:HISCONPA-NUM-APOLICE ,:HISCONPA-COD-SUBGRUPO ,:HISCONPA-COD-FONTE ,:HISCONPA-PREMIO-VG ,:HISCONPA-PREMIO-AP ,:HISCONPA-DATA-MOVIMENTO ,:HISCONPA-SIT-REGISTRO ,:HISCONPA-COD-OPERACAO ,:PROPOVA-COD-PRODUTO ,:PROPOVA-COD-CLIENTE ,:PROPOVA-COD-FONTE ,:PROPOVA-DATA-QUITACAO ,:PROPOVA-SIT-REGISTRO ,:PROPOVA-OCORR-HISTORICO ,:PROPOVA-DTPROXVEN ,:CLIENTES-NOME-RAZAO ,:CLIENTES-TIPO-PESSOA ,:CLIENTES-CGCCPF ,:CLIENTES-DATA-NASCIMENTO:VIND-NULL01 ,:PRODUVG-COD-PRODUTO ,:PRODUVG-ESTR-COBR:VIND-NULL02 ,:PRODUVG-ORIG-PRODU:VIND-NULL03 ,:APOLICES-COD-MODALIDADE ,:APOLICES-ORGAO-EMISSOR ,:APOLICES-RAMO-EMISSOR ,:ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA ,:WHOST-DATAMES1 END-EXEC. */

            if (V0HISCONPA.Fetch())
            {
                _.Move(V0HISCONPA.HISCONPA_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);
                _.Move(V0HISCONPA.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(V0HISCONPA.HISCONPA_NUM_TITULO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO);
                _.Move(V0HISCONPA.HISCONPA_OCORR_HISTORICO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);
                _.Move(V0HISCONPA.HISCONPA_NUM_APOLICE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE);
                _.Move(V0HISCONPA.HISCONPA_COD_SUBGRUPO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO);
                _.Move(V0HISCONPA.HISCONPA_COD_FONTE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_FONTE);
                _.Move(V0HISCONPA.HISCONPA_PREMIO_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);
                _.Move(V0HISCONPA.HISCONPA_PREMIO_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);
                _.Move(V0HISCONPA.HISCONPA_DATA_MOVIMENTO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO);
                _.Move(V0HISCONPA.HISCONPA_SIT_REGISTRO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO);
                _.Move(V0HISCONPA.HISCONPA_COD_OPERACAO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);
                _.Move(V0HISCONPA.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(V0HISCONPA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(V0HISCONPA.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(V0HISCONPA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(V0HISCONPA.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(V0HISCONPA.PROPOVA_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);
                _.Move(V0HISCONPA.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
                _.Move(V0HISCONPA.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(V0HISCONPA.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(V0HISCONPA.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(V0HISCONPA.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(V0HISCONPA.VIND_NULL01, VIND_NULL01);
                _.Move(V0HISCONPA.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(V0HISCONPA.PRODUVG_ESTR_COBR, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ESTR_COBR);
                _.Move(V0HISCONPA.VIND_NULL02, VIND_NULL02);
                _.Move(V0HISCONPA.PRODUVG_ORIG_PRODU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);
                _.Move(V0HISCONPA.VIND_NULL03, VIND_NULL03);
                _.Move(V0HISCONPA.APOLICES_COD_MODALIDADE, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);
                _.Move(V0HISCONPA.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
                _.Move(V0HISCONPA.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
                _.Move(V0HISCONPA.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(V0HISCONPA.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(V0HISCONPA.WHOST_DATAMES1, WHOST_DATAMES1);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-HISCONPA-DB-CLOSE-1 */
        public void R0210_00_FETCH_HISCONPA_DB_CLOSE_1()
        {
            /*" -1144- EXEC SQL CLOSE V0HISCONPA END-EXEC */

            V0HISCONPA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-PROCESSA-HISCONPA-SECTION */
        private void R0220_00_PROCESSA_HISCONPA_SECTION()
        {
            /*" -1205- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", W.WABEND.WNR_EXEC_SQL);

            /*" -1207- IF HISCONPA-PREMIO-VG NOT GREATER ZEROS AND HISCONPA-PREMIO-AP NOT GREATER ZEROS */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG <= 00 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP <= 00)
            {

                /*" -1210- MOVE ZEROS TO HISCONPA-PREMIO-VG HISCONPA-PREMIO-AP */
                _.Move(0, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

                /*" -1211- ELSE */
            }
            else
            {


                /*" -1213- IF HISCONPA-PREMIO-VG GREATER ZEROS AND HISCONPA-PREMIO-AP NOT GREATER ZEROS */

                if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG > 00 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP <= 00)
                {

                    /*" -1215- COMPUTE HISCONPA-PREMIO-VG EQUAL (HISCONPA-PREMIO-VG + HISCONPA-PREMIO-AP) */
                    HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG.Value = (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG + HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

                    /*" -1217- MOVE ZEROS TO HISCONPA-PREMIO-AP */
                    _.Move(0, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

                    /*" -1218- ELSE */
                }
                else
                {


                    /*" -1220- IF HISCONPA-PREMIO-AP GREATER ZEROS AND HISCONPA-PREMIO-VG NOT GREATER ZEROS */

                    if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP > 00 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG <= 00)
                    {

                        /*" -1222- COMPUTE HISCONPA-PREMIO-AP EQUAL (HISCONPA-PREMIO-VG + HISCONPA-PREMIO-AP) */
                        HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP.Value = (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG + HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

                        /*" -1226- MOVE ZEROS TO HISCONPA-PREMIO-VG. */
                        _.Move(0, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);
                    }

                }

            }


            /*" -1230- COMPUTE WS-VALOR EQUAL (HISCONPA-PREMIO-VG + HISCONPA-PREMIO-AP). */
            W.WS_VALOR.Value = (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG + HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

            /*" -1232- PERFORM R0230-00-SELECT-SUBGVGAP. */

            R0230_00_SELECT_SUBGVGAP_SECTION();

            /*" -1234- PERFORM R0250-00-SELECT-PARCEVID. */

            R0250_00_SELECT_PARCEVID_SECTION();

            /*" -1236- PERFORM R0260-00-SELECT-OPCPAGVI. */

            R0260_00_SELECT_OPCPAGVI_SECTION();

            /*" -1238- PERFORM R0300-00-SELECT-COBHISVI. */

            R0300_00_SELECT_COBHISVI_SECTION();

            /*" -1240- PERFORM R0310-00-SELECT-HISCOBPR. */

            R0310_00_SELECT_HISCOBPR_SECTION();

            /*" -1242- PERFORM R0330-00-SELECT-CONDITEC. */

            R0330_00_SELECT_CONDITEC_SECTION();

            /*" -1244- PERFORM R0340-00-SELECT-SEGVGAP. */

            R0340_00_SELECT_SEGVGAP_SECTION();

            /*" -1247- PERFORM R0350-00-SELECT-RAMOCOMP. */

            R0350_00_SELECT_RAMOCOMP_SECTION();

            /*" -1248- IF HISCONPA-NUM-PARCELA EQUAL 1 */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA == 1)
            {

                /*" -1249- PERFORM R0360-00-VER-VIGENCIA */

                R0360_00_VER_VIGENCIA_SECTION();

                /*" -1250- ELSE */
            }
            else
            {


                /*" -1255- MOVE SPACES TO WHOST-DTINIVIG WHOST-DTTERVIG. */
                _.Move("", WHOST_DTINIVIG, WHOST_DTTERVIG);
            }


            /*" -1257- PERFORM R0380-00-VER-VALORES. */

            R0380_00_VER_VALORES_SECTION();

            /*" -1259- PERFORM R0400-00-MOVE-DADOS-SORT. */

            R0400_00_MOVE_DADOS_SORT_SECTION();

            /*" -1261- PERFORM R0410-00-SELECT-RCAPS. */

            R0410_00_SELECT_RCAPS_SECTION();

            /*" -1263- PERFORM R0420-00-SELECT-MOVIMCOB. */

            R0420_00_SELECT_MOVIMCOB_SECTION();

            /*" -1265- PERFORM R0430-00-SELECT-MOVDEBCE. */

            R0430_00_SELECT_MOVDEBCE_SECTION();

            /*" -1267- PERFORM R0450-00-CONSISTE-REGISTRO. */

            R0450_00_CONSISTE_REGISTRO_SECTION();

            /*" -1268- IF LD01-OBSERVA NOT EQUAL SPACES */

            if (!ARQUIVOS_SAIDA.LD01.LD01_OBSERVA.IsEmpty())
            {

                /*" -1269- WRITE REG-VA0140B1 FROM LD01 */
                _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_VA0140B1);

                SAIDA01.Write(REG_VA0140B1.GetMoveValues().ToString());

                /*" -1270- ADD 1 TO AC-GRAVA01 */
                W.AC_GRAVA01.Value = W.AC_GRAVA01 + 1;

                /*" -1273- GO TO R0220-90-LEITURA. */

                R0220_90_LEITURA(); //GOTO
                return;
            }


            /*" -1276- PERFORM R0460-00-SELECT-AVISOSAL. */

            R0460_00_SELECT_AVISOSAL_SECTION();

            /*" -1277- RELEASE REG-SVA0140B. */
            SVA0140B.Release(REG_SVA0140B);

            /*" -1277- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R0220_90_LEITURA */

            R0220_90_LEITURA();

        }

        [StopWatch]
        /*" R0220-90-LEITURA */
        private void R0220_90_LEITURA(bool isPerform = false)
        {
            /*" -1282- PERFORM R0210-00-FETCH-HISCONPA. */

            R0210_00_FETCH_HISCONPA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0230-00-SELECT-SUBGVGAP-SECTION */
        private void R0230_00_SELECT_SUBGVGAP_SECTION()
        {
            /*" -1294- MOVE '0230' TO WNR-EXEC-SQL. */
            _.Move("0230", W.WABEND.WNR_EXEC_SQL);

            /*" -1303- PERFORM R0230_00_SELECT_SUBGVGAP_DB_SELECT_1 */

            R0230_00_SELECT_SUBGVGAP_DB_SELECT_1();

            /*" -1307- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1308- PERFORM R0240-00-SELECT-SUBGVGAP */

                R0240_00_SELECT_SUBGVGAP_SECTION();

                /*" -1309- ELSE */
            }
            else
            {


                /*" -1310- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1314- DISPLAY 'R0230-00 - PROBLEMAS NO SELECT(SUBGVGAP)' ' APOLICE     = ' HISCONPA-NUM-APOLICE ' SUBGRUPO    = ' HISCONPA-COD-SUBGRUPO ' CLIENTE     = ' PROPOVA-COD-CLIENTE */

                    $"R0230-00 - PROBLEMAS NO SELECT(SUBGVGAP) APOLICE     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE} SUBGRUPO    = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO} CLIENTE     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}"
                    .Display();

                    /*" -1315- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1316- ELSE */
                }
                else
                {


                    /*" -1317- IF VIND-NULL01 LESS ZEROS */

                    if (VIND_NULL01 < 00)
                    {

                        /*" -1318- MOVE 'S' TO SUBGVGAP-IND-IOF. */
                        _.Move("S", SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_IOF);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0230-00-SELECT-SUBGVGAP-DB-SELECT-1 */
        public void R0230_00_SELECT_SUBGVGAP_DB_SELECT_1()
        {
            /*" -1303- EXEC SQL SELECT IND_IOF INTO :SUBGVGAP-IND-IOF:VIND-NULL04 FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND COD_SUBGRUPO = :HISCONPA-COD-SUBGRUPO AND COD_CLIENTE = :PROPOVA-COD-CLIENTE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0230_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 = new R0230_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1()
            {
                HISCONPA_COD_SUBGRUPO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO.ToString(),
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0230_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1.Execute(r0230_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_IND_IOF, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_IOF);
                _.Move(executed_1.VIND_NULL04, VIND_NULL04);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/

        [StopWatch]
        /*" R0240-00-SELECT-SUBGVGAP-SECTION */
        private void R0240_00_SELECT_SUBGVGAP_SECTION()
        {
            /*" -1331- MOVE '0240' TO WNR-EXEC-SQL. */
            _.Move("0240", W.WABEND.WNR_EXEC_SQL);

            /*" -1339- PERFORM R0240_00_SELECT_SUBGVGAP_DB_SELECT_1 */

            R0240_00_SELECT_SUBGVGAP_DB_SELECT_1();

            /*" -1343- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1345- MOVE 'S' TO SUBGVGAP-IND-IOF */
                _.Move("S", SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_IOF);

                /*" -1346- ELSE */
            }
            else
            {


                /*" -1347- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1350- DISPLAY 'R0240-00 - PROBLEMAS NO SELECT(SUBGVGAP)' ' APOLICE     = ' HISCONPA-NUM-APOLICE ' SUBGRUPO    = ' HISCONPA-COD-SUBGRUPO */

                    $"R0240-00 - PROBLEMAS NO SELECT(SUBGVGAP) APOLICE     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE} SUBGRUPO    = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO}"
                    .Display();

                    /*" -1351- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1352- ELSE */
                }
                else
                {


                    /*" -1353- IF VIND-NULL01 LESS ZEROS */

                    if (VIND_NULL01 < 00)
                    {

                        /*" -1354- MOVE 'S' TO SUBGVGAP-IND-IOF. */
                        _.Move("S", SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_IOF);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0240-00-SELECT-SUBGVGAP-DB-SELECT-1 */
        public void R0240_00_SELECT_SUBGVGAP_DB_SELECT_1()
        {
            /*" -1339- EXEC SQL SELECT IND_IOF INTO :SUBGVGAP-IND-IOF:VIND-NULL04 FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND COD_SUBGRUPO = :HISCONPA-COD-SUBGRUPO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 = new R0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1()
            {
                HISCONPA_COD_SUBGRUPO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO.ToString(),
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1.Execute(r0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_IND_IOF, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_IOF);
                _.Move(executed_1.VIND_NULL04, VIND_NULL04);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-SELECT-PARCEVID-SECTION */
        private void R0250_00_SELECT_PARCEVID_SECTION()
        {
            /*" -1367- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", W.WABEND.WNR_EXEC_SQL);

            /*" -1377- PERFORM R0250_00_SELECT_PARCEVID_DB_SELECT_1 */

            R0250_00_SELECT_PARCEVID_DB_SELECT_1();

            /*" -1381- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1382- MOVE 'N' TO WTEM-PARCEVID */
                _.Move("N", W.WTEM_PARCEVID);

                /*" -1385- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEVID-DATA-VENCIMENTO WHOST-DATA-GEROU-PARCELA */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO, WHOST_DATA_GEROU_PARCELA);

                /*" -1386- ELSE */
            }
            else
            {


                /*" -1387- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1390- DISPLAY 'R0250-00 - PROBLEMAS NO SELECT(PARCEVID)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' PARCELA     = ' HISCONPA-NUM-PARCELA */

                    $"R0250-00 - PROBLEMAS NO SELECT(PARCEVID) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}"
                    .Display();

                    /*" -1391- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1392- ELSE */
                }
                else
                {


                    /*" -1392- MOVE 'S' TO WTEM-PARCEVID. */
                    _.Move("S", W.WTEM_PARCEVID);
                }

            }


        }

        [StopWatch]
        /*" R0250-00-SELECT-PARCEVID-DB-SELECT-1 */
        public void R0250_00_SELECT_PARCEVID_DB_SELECT_1()
        {
            /*" -1377- EXEC SQL SELECT DATA_VENCIMENTO , DATE(TIMESTAMP) INTO :PARCEVID-DATA-VENCIMENTO , :WHOST-DATA-GEROU-PARCELA FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1 = new R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1.Execute(r0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEVID_DATA_VENCIMENTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO);
                _.Move(executed_1.WHOST_DATA_GEROU_PARCELA, WHOST_DATA_GEROU_PARCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-SELECT-OPCPAGVI-SECTION */
        private void R0260_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -1405- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", W.WABEND.WNR_EXEC_SQL);

            /*" -1422- PERFORM R0260_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R0260_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -1426- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1427- PERFORM R0270-00-SELECT-OPCPAGVI */

                R0270_00_SELECT_OPCPAGVI_SECTION();

                /*" -1428- ELSE */
            }
            else
            {


                /*" -1429- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1432- DISPLAY 'R0260-00 - PROBLEMAS NO SELECT(OPCPAGVI)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' VENCIMENTO  = ' PARCEVID-DATA-VENCIMENTO */

                    $"R0260-00 - PROBLEMAS NO SELECT(OPCPAGVI) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} VENCIMENTO  = {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO}"
                    .Display();

                    /*" -1433- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1434- ELSE */
                }
                else
                {


                    /*" -1434- MOVE 'S' TO WTEM-OPCPAGVI. */
                    _.Move("S", W.WTEM_OPCPAGVI);
                }

            }


        }

        [StopWatch]
        /*" R0260-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R0260_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -1422- EXEC SQL SELECT DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,OPCAO_PAGAMENTO ,PERI_PAGAMENTO ,DIA_DEBITO INTO :OPCPAGVI-DATA-INIVIGENCIA ,:OPCPAGVI-DATA-TERVIGENCIA ,:OPCPAGVI-OPCAO-PAGAMENTO ,:OPCPAGVI-PERI-PAGAMENTO ,:OPCPAGVI-DIA-DEBITO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND DATA_INIVIGENCIA <= :WHOST-DATA-GEROU-PARCELA AND DATA_TERVIGENCIA >= :WHOST-DATA-GEROU-PARCELA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                WHOST_DATA_GEROU_PARCELA = WHOST_DATA_GEROU_PARCELA.ToString(),
            };

            var executed_1 = R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_DATA_INIVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA);
                _.Move(executed_1.OPCPAGVI_DATA_TERVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA);
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0270-00-SELECT-OPCPAGVI-SECTION */
        private void R0270_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -1447- MOVE '0270' TO WNR-EXEC-SQL. */
            _.Move("0270", W.WABEND.WNR_EXEC_SQL);

            /*" -1463- PERFORM R0270_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R0270_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -1467- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1468- MOVE 'N' TO WTEM-OPCPAGVI */
                _.Move("N", W.WTEM_OPCPAGVI);

                /*" -1472- MOVE SPACES TO OPCPAGVI-DATA-INIVIGENCIA OPCPAGVI-DATA-TERVIGENCIA OPCPAGVI-OPCAO-PAGAMENTO */
                _.Move("", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                /*" -1475- MOVE ZEROS TO OPCPAGVI-PERI-PAGAMENTO OPCPAGVI-DIA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);

                /*" -1476- ELSE */
            }
            else
            {


                /*" -1477- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1479- DISPLAY 'R0270-00 - PROBLEMAS NO SELECT(OPCPAGVI)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */

                    $"R0270-00 - PROBLEMAS NO SELECT(OPCPAGVI) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}"
                    .Display();

                    /*" -1480- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1481- ELSE */
                }
                else
                {


                    /*" -1481- MOVE 'S' TO WTEM-OPCPAGVI. */
                    _.Move("S", W.WTEM_OPCPAGVI);
                }

            }


        }

        [StopWatch]
        /*" R0270-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R0270_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -1463- EXEC SQL SELECT DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,OPCAO_PAGAMENTO ,PERI_PAGAMENTO ,DIA_DEBITO INTO :OPCPAGVI-DATA-INIVIGENCIA ,:OPCPAGVI-DATA-TERVIGENCIA ,:OPCPAGVI-OPCAO-PAGAMENTO ,:OPCPAGVI-PERI-PAGAMENTO ,:OPCPAGVI-DIA-DEBITO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0270_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R0270_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0270_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r0270_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_DATA_INIVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA);
                _.Move(executed_1.OPCPAGVI_DATA_TERVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA);
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-SELECT-COBHISVI-SECTION */
        private void R0300_00_SELECT_COBHISVI_SECTION()
        {
            /*" -1494- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -1506- PERFORM R0300_00_SELECT_COBHISVI_DB_SELECT_1 */

            R0300_00_SELECT_COBHISVI_DB_SELECT_1();

            /*" -1510- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1514- MOVE ZEROS TO COBHISVI-BCO-AVISO COBHISVI-AGE-AVISO COBHISVI-NUM-AVISO-CREDITO */
                _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_BCO_AVISO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_AGE_AVISO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_AVISO_CREDITO);

                /*" -1515- ELSE */
            }
            else
            {


                /*" -1516- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1519- DISPLAY 'R0300-00 - PROBLEMAS NO SELECT(COBHISVI)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' PARCELA     = ' HISCONPA-NUM-PARCELA */

                    $"R0300-00 - PROBLEMAS NO SELECT(COBHISVI) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}"
                    .Display();

                    /*" -1519- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0300-00-SELECT-COBHISVI-DB-SELECT-1 */
        public void R0300_00_SELECT_COBHISVI_DB_SELECT_1()
        {
            /*" -1506- EXEC SQL SELECT BCO_AVISO ,AGE_AVISO ,NUM_AVISO_CREDITO INTO :COBHISVI-BCO-AVISO ,:COBHISVI-AGE-AVISO ,:COBHISVI-NUM-AVISO-CREDITO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1 = new R0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1.Execute(r0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBHISVI_BCO_AVISO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_BCO_AVISO);
                _.Move(executed_1.COBHISVI_AGE_AVISO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_AGE_AVISO);
                _.Move(executed_1.COBHISVI_NUM_AVISO_CREDITO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_AVISO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-SELECT-HISCOBPR-SECTION */
        private void R0310_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -1532- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.WABEND.WNR_EXEC_SQL);

            /*" -1559- PERFORM R0310_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R0310_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -1563- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1564- PERFORM R0320-00-SELECT-HISCOBPR */

                R0320_00_SELECT_HISCOBPR_SECTION();

                /*" -1565- ELSE */
            }
            else
            {


                /*" -1566- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1569- DISPLAY 'R0310-00 - PROBLEMAS NO SELECT(HISCOBPR)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' VENCIMENTO  = ' PARCEVID-DATA-VENCIMENTO */

                    $"R0310-00 - PROBLEMAS NO SELECT(HISCOBPR) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} VENCIMENTO  = {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO}"
                    .Display();

                    /*" -1570- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1571- ELSE */
                }
                else
                {


                    /*" -1572- IF VIND-NULL01 LESS ZEROS */

                    if (VIND_NULL01 < 00)
                    {

                        /*" -1573- MOVE ZEROS TO HISCOBPR-PRMDIT. */
                        _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0310-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R0310_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -1559- EXEC SQL SELECT DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,IMP_MORNATU ,IMPMORACID ,IMPINVPERM ,IMPAMDS ,IMPDH ,IMPDIT ,VLPREMIO ,PRMDIT INTO :HISCOBPR-DATA-INIVIGENCIA ,:HISCOBPR-DATA-TERVIGENCIA ,:HISCOBPR-IMP-MORNATU ,:HISCOBPR-IMPMORACID ,:HISCOBPR-IMPINVPERM ,:HISCOBPR-IMPAMDS ,:HISCOBPR-IMPDH ,:HISCOBPR-IMPDIT ,:HISCOBPR-VLPREMIO ,:HISCOBPR-PRMDIT:VIND-NULL01 FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND DATA_INIVIGENCIA <= :PARCEVID-DATA-VENCIMENTO AND DATA_TERVIGENCIA >= :PARCEVID-DATA-VENCIMENTO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0310_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R0310_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                PARCEVID_DATA_VENCIMENTO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO.ToString(),
            };

            var executed_1 = R0310_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r0310_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(executed_1.HISCOBPR_DATA_TERVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
                _.Move(executed_1.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);
                _.Move(executed_1.HISCOBPR_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);
                _.Move(executed_1.HISCOBPR_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);
                _.Move(executed_1.HISCOBPR_IMPDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_PRMDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-SELECT-HISCOBPR-SECTION */
        private void R0320_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -1586- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", W.WABEND.WNR_EXEC_SQL);

            /*" -1612- PERFORM R0320_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R0320_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -1616- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1619- MOVE SPACES TO HISCOBPR-DATA-INIVIGENCIA HISCOBPR-DATA-TERVIGENCIA */
                _.Move("", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

                /*" -1628- MOVE ZEROS TO HISCOBPR-IMP-MORNATU HISCOBPR-IMPMORACID HISCOBPR-IMPINVPERM HISCOBPR-IMPAMDS HISCOBPR-IMPDH HISCOBPR-IMPDIT HISCOBPR-VLPREMIO HISCOBPR-PRMDIT */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT);

                /*" -1629- ELSE */
            }
            else
            {


                /*" -1630- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1633- DISPLAY 'R0320-00 - PROBLEMAS NO SELECT(HISCOBPR)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' VENCIMENTO  = ' PARCEVID-DATA-VENCIMENTO */

                    $"R0320-00 - PROBLEMAS NO SELECT(HISCOBPR) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} VENCIMENTO  = {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO}"
                    .Display();

                    /*" -1634- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1635- ELSE */
                }
                else
                {


                    /*" -1636- IF VIND-NULL01 LESS ZEROS */

                    if (VIND_NULL01 < 00)
                    {

                        /*" -1637- MOVE ZEROS TO HISCOBPR-PRMDIT. */
                        _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0320-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R0320_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -1612- EXEC SQL SELECT DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,IMP_MORNATU ,IMPMORACID ,IMPINVPERM ,IMPAMDS ,IMPDH ,IMPDIT ,VLPREMIO ,PRMDIT INTO :HISCOBPR-DATA-INIVIGENCIA ,:HISCOBPR-DATA-TERVIGENCIA ,:HISCOBPR-IMP-MORNATU ,:HISCOBPR-IMPMORACID ,:HISCOBPR-IMPINVPERM ,:HISCOBPR-IMPAMDS ,:HISCOBPR-IMPDH ,:HISCOBPR-IMPDIT ,:HISCOBPR-VLPREMIO ,:HISCOBPR-PRMDIT:VIND-NULL01 FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(executed_1.HISCOBPR_DATA_TERVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
                _.Move(executed_1.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);
                _.Move(executed_1.HISCOBPR_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);
                _.Move(executed_1.HISCOBPR_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);
                _.Move(executed_1.HISCOBPR_IMPDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_PRMDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-SELECT-CONDITEC-SECTION */
        private void R0330_00_SELECT_CONDITEC_SECTION()
        {
            /*" -1650- MOVE '0330' TO WNR-EXEC-SQL. */
            _.Move("0330", W.WABEND.WNR_EXEC_SQL);

            /*" -1662- PERFORM R0330_00_SELECT_CONDITEC_DB_SELECT_1 */

            R0330_00_SELECT_CONDITEC_DB_SELECT_1();

            /*" -1666- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1670- MOVE ZEROS TO CONDITEC-GARAN-ADIC-IEA CONDITEC-GARAN-ADIC-IPA CONDITEC-GARAN-ADIC-IPD */
                _.Move(0, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD);

                /*" -1671- ELSE */
            }
            else
            {


                /*" -1672- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1675- DISPLAY 'R0330-00 - PROBLEMAS NO SELECT(CONDITEC)' ' APOLICE     = ' HISCONPA-NUM-APOLICE ' SUBGRUPO    = ' HISCONPA-COD-SUBGRUPO */

                    $"R0330-00 - PROBLEMAS NO SELECT(CONDITEC) APOLICE     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE} SUBGRUPO    = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO}"
                    .Display();

                    /*" -1675- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0330-00-SELECT-CONDITEC-DB-SELECT-1 */
        public void R0330_00_SELECT_CONDITEC_DB_SELECT_1()
        {
            /*" -1662- EXEC SQL SELECT GARAN_ADIC_IEA ,GARAN_ADIC_IPA ,GARAN_ADIC_IPD INTO :CONDITEC-GARAN-ADIC-IEA ,:CONDITEC-GARAN-ADIC-IPA ,:CONDITEC-GARAN-ADIC-IPD FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE AND COD_SUBGRUPO = :HISCONPA-COD-SUBGRUPO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1 = new R0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1()
            {
                HISCONPA_COD_SUBGRUPO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO.ToString(),
                HISCONPA_NUM_APOLICE = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1.Execute(r0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IEA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0340-00-SELECT-SEGVGAP-SECTION */
        private void R0340_00_SELECT_SEGVGAP_SECTION()
        {
            /*" -1688- MOVE '0340' TO WNR-EXEC-SQL. */
            _.Move("0340", W.WABEND.WNR_EXEC_SQL);

            /*" -1700- PERFORM R0340_00_SELECT_SEGVGAP_DB_SELECT_1 */

            R0340_00_SELECT_SEGVGAP_DB_SELECT_1();

            /*" -1704- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1706- MOVE ZEROS TO SEGVGAP-NUM-ITEM */
                _.Move(0, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM);

                /*" -1709- MOVE SPACES TO SEGVGAP-DATA-INIVIGENCIA SEGVGAP-DATA-ADMISSAO */
                _.Move("", SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_DATA_INIVIGENCIA, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_DATA_ADMISSAO);

                /*" -1710- ELSE */
            }
            else
            {


                /*" -1711- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1713- DISPLAY 'R0340-00 - PROBLEMAS NO SELECT(SEGVGAP) ' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */

                    $"R0340-00 - PROBLEMAS NO SELECT(SEGVGAP)  CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}"
                    .Display();

                    /*" -1714- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1715- ELSE */
                }
                else
                {


                    /*" -1716- IF VIND-NULL01 LESS ZEROS */

                    if (VIND_NULL01 < 00)
                    {

                        /*" -1717- MOVE SPACES TO SEGVGAP-DATA-ADMISSAO. */
                        _.Move("", SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_DATA_ADMISSAO);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0340-00-SELECT-SEGVGAP-DB-SELECT-1 */
        public void R0340_00_SELECT_SEGVGAP_DB_SELECT_1()
        {
            /*" -1700- EXEC SQL SELECT NUM_ITEM ,DATA_INIVIGENCIA ,DATA_ADMISSAO INTO :SEGVGAP-NUM-ITEM ,:SEGVGAP-DATA-INIVIGENCIA ,:SEGVGAP-DATA-ADMISSAO:VIND-NULL01 FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0340_00_SELECT_SEGVGAP_DB_SELECT_1_Query1 = new R0340_00_SELECT_SEGVGAP_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0340_00_SELECT_SEGVGAP_DB_SELECT_1_Query1.Execute(r0340_00_SELECT_SEGVGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGVGAP_NUM_ITEM, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM);
                _.Move(executed_1.SEGVGAP_DATA_INIVIGENCIA, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_DATA_INIVIGENCIA);
                _.Move(executed_1.SEGVGAP_DATA_ADMISSAO, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_DATA_ADMISSAO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-SELECT-RAMOCOMP-SECTION */
        private void R0350_00_SELECT_RAMOCOMP_SECTION()
        {
            /*" -1730- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", W.WABEND.WNR_EXEC_SQL);

            /*" -1732- MOVE APOLICES-RAMO-EMISSOR TO RAMOCOMP-RAMO-EMISSOR. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR);

            /*" -1736- MOVE PARCEVID-DATA-VENCIMENTO TO RAMOCOMP-DATA-INIVIGENCIA. */
            _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA);

            /*" -1744- PERFORM R0350_00_SELECT_RAMOCOMP_DB_SELECT_1 */

            R0350_00_SELECT_RAMOCOMP_DB_SELECT_1();

            /*" -1748- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1750- MOVE ZEROS TO RAMOCOMP-PCT-IOCC-RAMO */
                _.Move(0, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);

                /*" -1751- ELSE */
            }
            else
            {


                /*" -1752- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1754- DISPLAY 'R0350-00 - PROBLEMAS NO SELECT(RAMOCOMP)' ' RAMO   =   ' RAMOCOMP-RAMO-EMISSOR */

                    $"R0350-00 - PROBLEMAS NO SELECT(RAMOCOMP) RAMO   =   {RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR}"
                    .Display();

                    /*" -1754- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0350-00-SELECT-RAMOCOMP-DB-SELECT-1 */
        public void R0350_00_SELECT_RAMOCOMP_DB_SELECT_1()
        {
            /*" -1744- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :RAMOCOMP-RAMO-EMISSOR AND DATA_INIVIGENCIA <= :RAMOCOMP-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :RAMOCOMP-DATA-INIVIGENCIA WITH UR END-EXEC. */

            var r0350_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1 = new R0350_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1()
            {
                RAMOCOMP_DATA_INIVIGENCIA = RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA.ToString(),
                RAMOCOMP_RAMO_EMISSOR = RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R0350_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1.Execute(r0350_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0360-00-VER-VIGENCIA-SECTION */
        private void R0360_00_VER_VIGENCIA_SECTION()
        {
            /*" -1767- MOVE '0360' TO WNR-EXEC-SQL. */
            _.Move("0360", W.WABEND.WNR_EXEC_SQL);

            /*" -1769- PERFORM R0365-00-VIGENCIA-PARCELA1. */

            R0365_00_VIGENCIA_PARCELA1_SECTION();

            /*" -1770- IF WHOST-DTINI01 EQUAL SPACES */

            if (WHOST_DTINI01.IsEmpty())
            {

                /*" -1773- GO TO R0360-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1774- IF WHOST-PERI EQUAL ZEROS */

            if (WHOST_PERI == 00)
            {

                /*" -1777- MOVE 36 TO WHOST-PERI. */
                _.Move(36, WHOST_PERI);
            }


            /*" -1777- PERFORM R0370-00-SELECT-CALENDAR. */

            R0370_00_SELECT_CALENDAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/

        [StopWatch]
        /*" R0365-00-VIGENCIA-PARCELA1-SECTION */
        private void R0365_00_VIGENCIA_PARCELA1_SECTION()
        {
            /*" -1790- MOVE '0365' TO WNR-EXEC-SQL. */
            _.Move("0365", W.WABEND.WNR_EXEC_SQL);

            /*" -1802- PERFORM R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1 */

            R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1();

            /*" -1806- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1810- MOVE SPACES TO WHOST-DTINIVIG WHOST-DTTERVIG WHOST-DTINI01 */
                _.Move("", WHOST_DTINIVIG, WHOST_DTTERVIG, WHOST_DTINI01);

                /*" -1811- ELSE */
            }
            else
            {


                /*" -1812- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1814- DISPLAY 'R0365-00 - PROBLEMAS NO SELECT(HISCOBPR)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO */

                    $"R0365-00 - PROBLEMAS NO SELECT(HISCOBPR) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}"
                    .Display();

                    /*" -1814- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0365-00-VIGENCIA-PARCELA1-DB-SELECT-1 */
        public void R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1()
        {
            /*" -1802- EXEC SQL SELECT B.DATA_INIVIGENCIA ,B.PERI_PAGAMENTO INTO :WHOST-DTINI01 ,:WHOST-PERI FROM SEGUROS.HIS_COBER_PROPOST A ,SEGUROS.OPCAO_PAG_VIDAZUL B WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND A.OCORR_HISTORICO = 1 AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1 = new R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1.Execute(r0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINI01, WHOST_DTINI01);
                _.Move(executed_1.WHOST_PERI, WHOST_PERI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0365_99_SAIDA*/

        [StopWatch]
        /*" R0370-00-SELECT-CALENDAR-SECTION */
        private void R0370_00_SELECT_CALENDAR_SECTION()
        {
            /*" -1827- MOVE '0370' TO WNR-EXEC-SQL. */
            _.Move("0370", W.WABEND.WNR_EXEC_SQL);

            /*" -1837- PERFORM R0370_00_SELECT_CALENDAR_DB_SELECT_1 */

            R0370_00_SELECT_CALENDAR_DB_SELECT_1();

            /*" -1841- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1844- MOVE SPACES TO WHOST-DTINIVIG WHOST-DTTERVIG */
                _.Move("", WHOST_DTINIVIG, WHOST_DTTERVIG);

                /*" -1845- ELSE */
            }
            else
            {


                /*" -1846- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1849- DISPLAY 'R0370-00 - PROBLEMAS NO SELECT(CALENDAR)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' DATA        = ' WHOST-DTINI01 */

                    $"R0370-00 - PROBLEMAS NO SELECT(CALENDAR) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} DATA        = {WHOST_DTINI01}"
                    .Display();

                    /*" -1850- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1851- ELSE */
                }
                else
                {


                    /*" -1853- MOVE WHOST-DTINI01 TO WHOST-DTINIVIG */
                    _.Move(WHOST_DTINI01, WHOST_DTINIVIG);

                    /*" -1854- MOVE WHOST-DTTER01 TO WHOST-DTTERVIG. */
                    _.Move(WHOST_DTTER01, WHOST_DTTERVIG);
                }

            }


        }

        [StopWatch]
        /*" R0370-00-SELECT-CALENDAR-DB-SELECT-1 */
        public void R0370_00_SELECT_CALENDAR_DB_SELECT_1()
        {
            /*" -1837- EXEC SQL SELECT DATA_CALENDARIO ,DATA_CALENDARIO + :WHOST-PERI MONTHS - 1 DAYS INTO :WHOST-DTINI01 ,:WHOST-DTTER01 FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :WHOST-DTINI01 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1 = new R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1()
            {
                WHOST_DTINI01 = WHOST_DTINI01.ToString(),
                WHOST_PERI = WHOST_PERI.ToString(),
            };

            var executed_1 = R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1.Execute(r0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINI01, WHOST_DTINI01);
                _.Move(executed_1.WHOST_DTTER01, WHOST_DTTER01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/

        [StopWatch]
        /*" R0380-00-VER-VALORES-SECTION */
        private void R0380_00_VER_VALORES_SECTION()
        {
            /*" -1867- MOVE '0380' TO WNR-EXEC-SQL. */
            _.Move("0380", W.WABEND.WNR_EXEC_SQL);

            /*" -1870- IF APOLICES-RAMO-EMISSOR EQUAL 82 AND HISCONPA-PREMIO-AP EQUAL ZEROS AND HISCONPA-PREMIO-VG NOT EQUAL ZEROS */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 82 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP == 00 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG != 00)
            {

                /*" -1872- MOVE HISCONPA-PREMIO-VG TO HISCONPA-PREMIO-AP */
                _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

                /*" -1876- MOVE ZEROS TO HISCONPA-PREMIO-VG. */
                _.Move(0, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);
            }


            /*" -1879- IF APOLICES-RAMO-EMISSOR EQUAL 82 AND HISCOBPR-IMPMORACID EQUAL ZEROS AND HISCOBPR-IMP-MORNATU NOT EQUAL ZEROS */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 82 && HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID == 00 && HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU != 00)
            {

                /*" -1881- MOVE HISCOBPR-IMP-MORNATU TO HISCOBPR-IMPMORACID */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);

                /*" -1885- MOVE ZEROS TO HISCOBPR-IMP-MORNATU. */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
            }


            /*" -1888- IF APOLICES-RAMO-EMISSOR EQUAL 93 AND HISCONPA-PREMIO-VG EQUAL ZEROS AND HISCONPA-PREMIO-AP NOT EQUAL ZEROS */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 93 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG == 00 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP != 00)
            {

                /*" -1890- MOVE HISCONPA-PREMIO-AP TO HISCONPA-PREMIO-VG */
                _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);

                /*" -1894- MOVE ZEROS TO HISCONPA-PREMIO-AP. */
                _.Move(0, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);
            }


            /*" -1897- IF APOLICES-RAMO-EMISSOR EQUAL 93 AND HISCOBPR-IMP-MORNATU EQUAL ZEROS AND HISCOBPR-IMPMORACID NOT EQUAL ZEROS */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 93 && HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU == 00 && HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID != 00)
            {

                /*" -1899- MOVE HISCOBPR-IMPMORACID TO HISCOBPR-IMP-MORNATU */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

                /*" -1903- MOVE ZEROS TO HISCOBPR-IMPMORACID. */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
            }


            /*" -1906- IF APOLICES-RAMO-EMISSOR EQUAL 97 AND HISCOBPR-IMP-MORNATU EQUAL ZEROS AND HISCOBPR-IMPMORACID NOT EQUAL ZEROS */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 97 && HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU == 00 && HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID != 00)
            {

                /*" -1908- MOVE HISCOBPR-IMPMORACID TO HISCOBPR-IMP-MORNATU */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

                /*" -1912- MOVE ZEROS TO HISCOBPR-IMPMORACID. */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
            }


            /*" -1915- IF APOLICES-RAMO-EMISSOR EQUAL 97 AND HISCOBPR-IMPMORACID EQUAL ZEROS AND HISCOBPR-IMP-MORNATU NOT EQUAL ZEROS */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 97 && HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID == 00 && HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU != 00)
            {

                /*" -1916- MOVE HISCOBPR-IMP-MORNATU TO HISCOBPR-IMPMORACID. */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0380_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-MOVE-DADOS-SORT-SECTION */
        private void R0400_00_MOVE_DADOS_SORT_SECTION()
        {
            /*" -1929- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", W.WABEND.WNR_EXEC_SQL);

            /*" -1932- MOVE SPACES TO REG-SVA0140B. */
            _.Move("", REG_SVA0140B);

            /*" -1935- MOVE HISCONPA-NUM-CERTIFICADO TO SOR-NUM-CERTIFICADO LD01-NRCERTIF. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, REG_SVA0140B.SOR_NUM_CERTIFICADO, ARQUIVOS_SAIDA.LD01.LD01_NRCERTIF);

            /*" -1938- MOVE HISCONPA-NUM-PARCELA TO SOR-NUM-PARCELA LD01-NRPARCEL. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, REG_SVA0140B.SOR_NUM_PARCELA, ARQUIVOS_SAIDA.LD01.LD01_NRPARCEL);

            /*" -1941- MOVE HISCONPA-NUM-TITULO TO SOR-NUM-TITULO LD01-NRTIT. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO, REG_SVA0140B.SOR_NUM_TITULO, ARQUIVOS_SAIDA.LD01.LD01_NRTIT);

            /*" -1944- MOVE HISCONPA-OCORR-HISTORICO TO SOR-OCORR-HISTORICO LD01-OCORHIST1. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO, REG_SVA0140B.SOR_OCORR_HISTORICO, ARQUIVOS_SAIDA.LD01.LD01_OCORHIST1);

            /*" -1947- MOVE HISCONPA-NUM-APOLICE TO SOR-NUM-APOLICE LD01-NUMAPOL. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE, REG_SVA0140B.SOR_NUM_APOLICE, ARQUIVOS_SAIDA.LD01.LD01_NUMAPOL);

            /*" -1950- MOVE HISCONPA-COD-SUBGRUPO TO SOR-COD-SUBGRUPO LD01-CODSUBES. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO, REG_SVA0140B.SOR_COD_SUBGRUPO, ARQUIVOS_SAIDA.LD01.LD01_CODSUBES);

            /*" -1953- MOVE HISCONPA-COD-FONTE TO SOR-COD-FONTE LD01-FONTE. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_FONTE, REG_SVA0140B.SOR_COD_FONTE, ARQUIVOS_SAIDA.LD01.LD01_FONTE);

            /*" -1956- MOVE HISCONPA-PREMIO-VG TO SOR-PREMIO-VG LD01-PRMVG. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG, REG_SVA0140B.SOR_PREMIO_VG, ARQUIVOS_SAIDA.LD01.LD01_PRMVG);

            /*" -1959- MOVE HISCONPA-PREMIO-AP TO SOR-PREMIO-AP LD01-PRMAP. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP, REG_SVA0140B.SOR_PREMIO_AP, ARQUIVOS_SAIDA.LD01.LD01_PRMAP);

            /*" -1962- MOVE HISCONPA-DATA-MOVIMENTO TO SOR-DATA-MOVIMENTO LD01-DTMOVTO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO, REG_SVA0140B.SOR_DATA_MOVIMENTO, ARQUIVOS_SAIDA.LD01.LD01_DTMOVTO);

            /*" -1964- MOVE HISCONPA-SIT-REGISTRO TO SOR-SIT-REGISTRO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO, REG_SVA0140B.SOR_SIT_REGISTRO);

            /*" -1967- MOVE HISCONPA-COD-OPERACAO TO SOR-COD-OPERACAO LD01-OPERACAO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO, REG_SVA0140B.SOR_COD_OPERACAO, ARQUIVOS_SAIDA.LD01.LD01_OPERACAO);

            /*" -1969- MOVE PROPOVA-COD-PRODUTO TO SOR-COD-PRODUTO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, REG_SVA0140B.SOR_COD_PRODUTO);

            /*" -1972- MOVE PROPOVA-DATA-QUITACAO TO SOR-DATA-QUITACAO LD01-DTQITBCO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, REG_SVA0140B.SOR_DATA_QUITACAO, ARQUIVOS_SAIDA.LD01.LD01_DTQITBCO);

            /*" -1975- MOVE PROPOVA-SIT-REGISTRO TO SOR-SITUACAO LD01-SIT-CERTIF. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO, REG_SVA0140B.SOR_SITUACAO, ARQUIVOS_SAIDA.LD01.LD01_SIT_CERTIF);

            /*" -1978- MOVE PROPOVA-OCORR-HISTORICO TO SOR-OCORHIST LD01-OCORHIST2. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO, REG_SVA0140B.SOR_OCORHIST, ARQUIVOS_SAIDA.LD01.LD01_OCORHIST2);

            /*" -1981- MOVE PROPOVA-DTPROXVEN TO SOR-DTPROXVEN LD01-DTPROXVEN. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN, REG_SVA0140B.SOR_DTPROXVEN, ARQUIVOS_SAIDA.LD01.LD01_DTPROXVEN);

            /*" -1984- MOVE PROPOVA-COD-CLIENTE TO SOR-CLIENTE LD01-CLIENTE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE, REG_SVA0140B.SOR_CLIENTE, ARQUIVOS_SAIDA.LD01.LD01_CLIENTE);

            /*" -1987- MOVE CLIENTES-TIPO-PESSOA TO SOR-TIPO-PESSOA LD01-TPPESSOA. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA, REG_SVA0140B.SOR_TIPO_PESSOA, ARQUIVOS_SAIDA.LD01.LD01_TPPESSOA);

            /*" -1990- MOVE CLIENTES-CGCCPF TO SOR-CGCCPF LD01-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, REG_SVA0140B.SOR_CGCCPF, ARQUIVOS_SAIDA.LD01.LD01_CGCCPF);

            /*" -1993- MOVE CLIENTES-DATA-NASCIMENTO TO SOR-DATA-NASCIMENTO LD01-DTNASC. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, REG_SVA0140B.SOR_DATA_NASCIMENTO, ARQUIVOS_SAIDA.LD01.LD01_DTNASC);

            /*" -1998- MOVE PRODUVG-COD-PRODUTO TO SOR-PRODUTO LD01-CODPRODU SOR-PRODEMIS LD01-PRODEMI. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, REG_SVA0140B.SOR_PRODUTO, ARQUIVOS_SAIDA.LD01.LD01_CODPRODU, REG_SVA0140B.SOR_PRODEMIS, ARQUIVOS_SAIDA.LD01.LD01_PRODEMI);

            /*" -2001- MOVE PRODUVG-ESTR-COBR TO SOR-ESTR-COBR LD01-ESTR-COBR. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_ESTR_COBR, REG_SVA0140B.SOR_ESTR_COBR, ARQUIVOS_SAIDA.LD01.LD01_ESTR_COBR);

            /*" -2004- MOVE PRODUVG-ORIG-PRODU TO SOR-ORIG-PRODU LD01-ORIG-PRODU. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU, REG_SVA0140B.SOR_ORIG_PRODU, ARQUIVOS_SAIDA.LD01.LD01_ORIG_PRODU);

            /*" -2007- MOVE PARCEVID-DATA-VENCIMENTO TO SOR-DATA-VENCIMENTO LD01-DTVENCTO. */
            _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO, REG_SVA0140B.SOR_DATA_VENCIMENTO, ARQUIVOS_SAIDA.LD01.LD01_DTVENCTO);

            /*" -2010- MOVE HISCOBPR-DATA-INIVIGENCIA TO SOR-DATA-INIVIGENCIA LD01-DTINIVIG. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA, REG_SVA0140B.SOR_DATA_INIVIGENCIA, ARQUIVOS_SAIDA.LD01.LD01_DTINIVIG);

            /*" -2013- MOVE HISCOBPR-DATA-TERVIGENCIA TO SOR-DATA-TERVIGENCIA LD01-DTTERVIG. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA, REG_SVA0140B.SOR_DATA_TERVIGENCIA, ARQUIVOS_SAIDA.LD01.LD01_DTTERVIG);

            /*" -2016- MOVE SUBGVGAP-IND-IOF TO SOR-IND-IOF LD01-IOF. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_IOF, REG_SVA0140B.SOR_IND_IOF, ARQUIVOS_SAIDA.LD01.LD01_IOF);

            /*" -2019- MOVE OPCPAGVI-OPCAO-PAGAMENTO TO SOR-OPCAO-PAGAMENTO LD01-OPCAO. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO, REG_SVA0140B.SOR_OPCAO_PAGAMENTO, ARQUIVOS_SAIDA.LD01.LD01_OPCAO);

            /*" -2022- MOVE OPCPAGVI-PERI-PAGAMENTO TO SOR-PERI-PAGAMENTO LD01-PERI. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO, REG_SVA0140B.SOR_PERI_PAGAMENTO, ARQUIVOS_SAIDA.LD01.LD01_PERI);

            /*" -2025- MOVE OPCPAGVI-DIA-DEBITO TO SOR-DIA-DEBITO LD01-DIA-DEBITO. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, REG_SVA0140B.SOR_DIA_DEBITO, ARQUIVOS_SAIDA.LD01.LD01_DIA_DEBITO);

            /*" -2028- MOVE APOLICES-ORGAO-EMISSOR TO SOR-ORGAO LD01-ORGAO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR, REG_SVA0140B.SOR_ORGAO, ARQUIVOS_SAIDA.LD01.LD01_ORGAO);

            /*" -2031- MOVE APOLICES-RAMO-EMISSOR TO SOR-RAMO LD01-RAMO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, REG_SVA0140B.SOR_RAMO, ARQUIVOS_SAIDA.LD01.LD01_RAMO);

            /*" -2034- MOVE APOLICES-COD-MODALIDADE TO SOR-MODALIDA LD01-MODALI. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE, REG_SVA0140B.SOR_MODALIDA, ARQUIVOS_SAIDA.LD01.LD01_MODALI);

            /*" -2037- MOVE WS-VALOR TO SOR-VALVGAP LD01-VALVGAP. */
            _.Move(W.WS_VALOR, REG_SVA0140B.SOR_VALVGAP, ARQUIVOS_SAIDA.LD01.LD01_VALVGAP);

            /*" -2040- MOVE ENDOSSOS-DATA-INIVIGENCIA TO SOR-INIZERO LD01-INIENDZERO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, REG_SVA0140B.SOR_INIZERO, ARQUIVOS_SAIDA.LD01.LD01_INIENDZERO);

            /*" -2043- MOVE ENDOSSOS-DATA-TERVIGENCIA TO SOR-TERZERO LD01-TERENDZERO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, REG_SVA0140B.SOR_TERZERO, ARQUIVOS_SAIDA.LD01.LD01_TERENDZERO);

            /*" -2046- MOVE CONDITEC-GARAN-ADIC-IEA TO SOR-ADICIEA LD01-ADICIEA. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA, REG_SVA0140B.SOR_ADICIEA, ARQUIVOS_SAIDA.LD01.LD01_ADICIEA);

            /*" -2049- MOVE CONDITEC-GARAN-ADIC-IPA TO SOR-ADICIPA LD01-ADICIPA. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA, REG_SVA0140B.SOR_ADICIPA, ARQUIVOS_SAIDA.LD01.LD01_ADICIPA);

            /*" -2052- MOVE CONDITEC-GARAN-ADIC-IPD TO SOR-ADICIPD LD01-ADICIPD. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD, REG_SVA0140B.SOR_ADICIPD, ARQUIVOS_SAIDA.LD01.LD01_ADICIPD);

            /*" -2054- MOVE SEGVGAP-NUM-ITEM TO SOR-ITEM. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM, REG_SVA0140B.SOR_ITEM);

            /*" -2057- MOVE SEGVGAP-DATA-INIVIGENCIA TO SOR-DTINIVIG LD01-DTINICIO. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_DATA_INIVIGENCIA, REG_SVA0140B.SOR_DTINIVIG, ARQUIVOS_SAIDA.LD01.LD01_DTINICIO);

            /*" -2060- MOVE SEGVGAP-DATA-ADMISSAO TO SOR-DATA-ADMISSAO LD01-DTADMISSAO. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_DATA_ADMISSAO, REG_SVA0140B.SOR_DATA_ADMISSAO, ARQUIVOS_SAIDA.LD01.LD01_DTADMISSAO);

            /*" -2063- MOVE COBHISVI-BCO-AVISO TO SOR-BCOAVISO LD01-BCOAVISO. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_BCO_AVISO, REG_SVA0140B.SOR_BCOAVISO, ARQUIVOS_SAIDA.LD01.LD01_BCOAVISO);

            /*" -2066- MOVE COBHISVI-AGE-AVISO TO SOR-AGEAVISO LD01-AGEAVISO. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_AGE_AVISO, REG_SVA0140B.SOR_AGEAVISO, ARQUIVOS_SAIDA.LD01.LD01_AGEAVISO);

            /*" -2069- MOVE COBHISVI-NUM-AVISO-CREDITO TO SOR-NRAVISO LD01-NRAVISO. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_AVISO_CREDITO, REG_SVA0140B.SOR_NRAVISO, ARQUIVOS_SAIDA.LD01.LD01_NRAVISO);

            /*" -2072- MOVE HISCOBPR-IMP-MORNATU TO SOR-IMPMORNATU LD01-IMPMORNATU. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, REG_SVA0140B.SOR_IMPMORNATU, ARQUIVOS_SAIDA.LD01.LD01_IMPMORNATU);

            /*" -2075- MOVE HISCOBPR-IMPMORACID TO SOR-IMPMORACID LD01-IMPMORACID. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, REG_SVA0140B.SOR_IMPMORACID, ARQUIVOS_SAIDA.LD01.LD01_IMPMORACID);

            /*" -2078- MOVE HISCOBPR-IMPINVPERM TO SOR-IMPINVPERM LD01-IMPINVPERM. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, REG_SVA0140B.SOR_IMPINVPERM, ARQUIVOS_SAIDA.LD01.LD01_IMPINVPERM);

            /*" -2081- MOVE HISCOBPR-IMPAMDS TO SOR-IMPAMDS LD01-IMPAMDS. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS, REG_SVA0140B.SOR_IMPAMDS, ARQUIVOS_SAIDA.LD01.LD01_IMPAMDS);

            /*" -2084- MOVE HISCOBPR-IMPDH TO SOR-IMPDH LD01-IMPDH. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH, REG_SVA0140B.SOR_IMPDH, ARQUIVOS_SAIDA.LD01.LD01_IMPDH);

            /*" -2087- MOVE HISCOBPR-IMPDIT TO SOR-IMPDIT LD01-IMPDIT. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT, REG_SVA0140B.SOR_IMPDIT, ARQUIVOS_SAIDA.LD01.LD01_IMPDIT);

            /*" -2089- MOVE HISCOBPR-VLPREMIO TO SOR-VLPREMIO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, REG_SVA0140B.SOR_VLPREMIO);

            /*" -2092- MOVE HISCOBPR-PRMDIT TO SOR-PRMDIT LD01-PRMDIT. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT, REG_SVA0140B.SOR_PRMDIT, ARQUIVOS_SAIDA.LD01.LD01_PRMDIT);

            /*" -2095- MOVE WHOST-DTINIVIG TO SOR-DTINIEMI LD01-DTINIEMI. */
            _.Move(WHOST_DTINIVIG, REG_SVA0140B.SOR_DTINIEMI, ARQUIVOS_SAIDA.LD01.LD01_DTINIEMI);

            /*" -2098- MOVE WHOST-DTTERVIG TO SOR-DTTEREMI LD01-DTTEREMI. */
            _.Move(WHOST_DTTERVIG, REG_SVA0140B.SOR_DTTEREMI, ARQUIVOS_SAIDA.LD01.LD01_DTTEREMI);

            /*" -2100- MOVE RAMOCOMP-PCT-IOCC-RAMO TO SOR-PER-IOF. */
            _.Move(RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO, REG_SVA0140B.SOR_PER_IOF);

            /*" -2103- MOVE ZEROS TO SOR-NRSEQ. */
            _.Move(0, REG_SVA0140B.SOR_NRSEQ);

            /*" -2108- MOVE SPACES TO LD01-OBSERVA LD01-PROGRAMA. */
            _.Move("", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA, ARQUIVOS_SAIDA.LD01.LD01_PROGRAMA);

            /*" -2110- IF PRODUVG-ESTR-COBR EQUAL 'MULT' OR 'FEDERAL' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ESTR_COBR.In("MULT", "FEDERAL"))
            {

                /*" -2118- IF PRODUVG-ORIG-PRODU NOT EQUAL 'EMPRE' AND PRODUVG-ORIG-PRODU NOT EQUAL 'ESPEC' AND PRODUVG-ORIG-PRODU NOT EQUAL 'ESPE1' AND PRODUVG-ORIG-PRODU NOT EQUAL 'ESPE2' AND PRODUVG-ORIG-PRODU NOT EQUAL 'ESPE3' AND PRODUVG-ORIG-PRODU NOT EQUAL 'ESPE4' AND PRODUVG-ORIG-PRODU NOT EQUAL 'ESPE5' AND PRODUVG-ORIG-PRODU NOT EQUAL 'GLOBAL' */

                if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU != "EMPRE" && PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU != "ESPEC" && PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU != "ESPE1" && PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU != "ESPE2" && PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU != "ESPE3" && PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU != "ESPE4" && PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU != "ESPE5" && PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU != "GLOBAL")
                {

                    /*" -2120- IF HISCONPA-NUM-APOLICE GREATER ZEROS AND HISCONPA-COD-SUBGRUPO GREATER ZEROS */

                    if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE > 00 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO > 00)
                    {

                        /*" -2121- ADD 1 TO TT-VA0139B */
                        W.TT_VA0139B.Value = W.TT_VA0139B + 1;

                        /*" -2123- MOVE 'VA0139B' TO SOR-PROGRAMA LD01-PROGRAMA */
                        _.Move("VA0139B", REG_SVA0140B.SOR_PROGRAMA, ARQUIVOS_SAIDA.LD01.LD01_PROGRAMA);

                        /*" -2125- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -2126- ELSE */
                    }

                }
                else
                {


                    /*" -2127- IF PRODUVG-ESTR-COBR EQUAL 'MULT' */

                    if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ESTR_COBR == "MULT")
                    {

                        /*" -2129- IF HISCONPA-COD-OPERACAO GREATER 499 AND HISCONPA-COD-OPERACAO LESS 600 */

                        if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO > 499 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO < 600)
                        {

                            /*" -2130- ADD 1 TO TT-VG0138B */
                            W.TT_VG0138B.Value = W.TT_VG0138B + 1;

                            /*" -2132- MOVE 'VG0138B' TO SOR-PROGRAMA LD01-PROGRAMA */
                            _.Move("VG0138B", REG_SVA0140B.SOR_PROGRAMA, ARQUIVOS_SAIDA.LD01.LD01_PROGRAMA);

                            /*" -2133- ELSE */
                        }
                        else
                        {


                            /*" -2141- IF PRODUVG-ORIG-PRODU EQUAL 'EMPRE' OR 'ESPEC' OR 'ESPE1' OR 'ESPE2' OR 'ESPE3' OR 'ESPE4' OR 'ESPE5' OR 'GLOBAL' */

                            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.In("EMPRE", "ESPEC", "ESPE1", "ESPE2", "ESPE3", "ESPE4", "ESPE5", "GLOBAL"))
                            {

                                /*" -2142- ADD 1 TO TT-VG0139B */
                                W.TT_VG0139B.Value = W.TT_VG0139B + 1;

                                /*" -2143- MOVE 'VG0139B' TO SOR-PROGRAMA LD01-PROGRAMA. */
                                _.Move("VG0139B", REG_SVA0140B.SOR_PROGRAMA, ARQUIVOS_SAIDA.LD01.LD01_PROGRAMA);
                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-SELECT-RCAPS-SECTION */
        private void R0410_00_SELECT_RCAPS_SECTION()
        {
            /*" -2156- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", W.WABEND.WNR_EXEC_SQL);

            /*" -2181- PERFORM R0410_00_SELECT_RCAPS_DB_SELECT_1 */

            R0410_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -2185- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2187- MOVE 'NAO' TO SOR-RCAPS LD01-RCAPS */
                _.Move("NAO", REG_SVA0140B.SOR_RCAPS, ARQUIVOS_SAIDA.LD01.LD01_RCAPS);

                /*" -2190- MOVE SPACES TO SOR-SITRCAP LD01-SITRCAP SOR-DATA-RCAP */
                _.Move("", REG_SVA0140B.SOR_SITRCAP, ARQUIVOS_SAIDA.LD01.LD01_SITRCAP, REG_SVA0140B.SOR_DATA_RCAP);

                /*" -2195- MOVE ZEROS TO SOR-OPERCAP LD01-OPERCAP SOR-NRRCAP SOR-VAL-RCAP LD01-VAL-RCAP */
                _.Move(0, REG_SVA0140B.SOR_OPERCAP, ARQUIVOS_SAIDA.LD01.LD01_OPERCAP, REG_SVA0140B.SOR_NRRCAP, REG_SVA0140B.SOR_VAL_RCAP, ARQUIVOS_SAIDA.LD01.LD01_VAL_RCAP);

                /*" -2196- ELSE */
            }
            else
            {


                /*" -2197- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2201- DISPLAY 'R0410-00 - PROBLEMAS NO SELECT(RCAPS)   ' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' PARCELA     = ' HISCONPA-NUM-PARCELA ' TITULO      = ' HISCONPA-NUM-PARCELA */

                    $"R0410-00 - PROBLEMAS NO SELECT(RCAPS)    CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA} TITULO      = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}"
                    .Display();

                    /*" -2202- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2203- ELSE */
                }
                else
                {


                    /*" -2205- MOVE 'SIM' TO SOR-RCAPS LD01-RCAPS */
                    _.Move("SIM", REG_SVA0140B.SOR_RCAPS, ARQUIVOS_SAIDA.LD01.LD01_RCAPS);

                    /*" -2207- MOVE RCAPS-SIT-REGISTRO TO SOR-SITRCAP LD01-SITRCAP */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO, REG_SVA0140B.SOR_SITRCAP, ARQUIVOS_SAIDA.LD01.LD01_SITRCAP);

                    /*" -2209- MOVE RCAPS-COD-OPERACAO TO SOR-OPERCAP LD01-OPERCAP */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO, REG_SVA0140B.SOR_OPERCAP, ARQUIVOS_SAIDA.LD01.LD01_OPERCAP);

                    /*" -2211- MOVE RCAPS-VAL-RCAP TO SOR-VAL-RCAP LD01-VAL-RCAP */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, REG_SVA0140B.SOR_VAL_RCAP, ARQUIVOS_SAIDA.LD01.LD01_VAL_RCAP);

                    /*" -2212- MOVE RCAPS-NUM-RCAP TO SOR-NRRCAP */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, REG_SVA0140B.SOR_NRRCAP);

                    /*" -2214- MOVE RCAPS-DATA-CADASTRAMENTO TO SOR-DATA-RCAP */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO, REG_SVA0140B.SOR_DATA_RCAP);

                    /*" -2216- MOVE RCAPCOMP-BCO-AVISO TO SOR-BCOAVISO LD01-BCOAVISO */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, REG_SVA0140B.SOR_BCOAVISO, ARQUIVOS_SAIDA.LD01.LD01_BCOAVISO);

                    /*" -2218- MOVE RCAPCOMP-AGE-AVISO TO SOR-AGEAVISO LD01-AGEAVISO */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, REG_SVA0140B.SOR_AGEAVISO, ARQUIVOS_SAIDA.LD01.LD01_AGEAVISO);

                    /*" -2220- MOVE RCAPCOMP-NUM-AVISO-CREDITO TO SOR-NRAVISO LD01-NRAVISO. */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, REG_SVA0140B.SOR_NRAVISO, ARQUIVOS_SAIDA.LD01.LD01_NRAVISO);
                }

            }


        }

        [StopWatch]
        /*" R0410-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R0410_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -2181- EXEC SQL SELECT A.NUM_RCAP ,A.VAL_RCAP ,A.DATA_CADASTRAMENTO ,A.SIT_REGISTRO ,A.COD_OPERACAO ,B.BCO_AVISO ,B.AGE_AVISO ,B.NUM_AVISO_CREDITO INTO :RCAPS-NUM-RCAP ,:RCAPS-VAL-RCAP ,:RCAPS-DATA-CADASTRAMENTO ,:RCAPS-SIT-REGISTRO ,:RCAPS-COD-OPERACAO ,:RCAPCOMP-BCO-AVISO ,:RCAPCOMP-AGE-AVISO ,:RCAPCOMP-NUM-AVISO-CREDITO FROM SEGUROS.RCAPS A ,SEGUROS.RCAP_COMPLEMENTAR B WHERE A.NUM_TITULO = :HISCONPA-NUM-TITULO AND B.COD_FONTE = A.COD_FONTE AND B.NUM_RCAP = A.NUM_RCAP AND B.SIT_REGISTRO = '0' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0410_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R0410_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_TITULO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO.ToString(),
            };

            var executed_1 = R0410_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r0410_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-SELECT-MOVIMCOB-SECTION */
        private void R0420_00_SELECT_MOVIMCOB_SECTION()
        {
            /*" -2233- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", W.WABEND.WNR_EXEC_SQL);

            /*" -2242- PERFORM R0420_00_SELECT_MOVIMCOB_DB_SELECT_1 */

            R0420_00_SELECT_MOVIMCOB_DB_SELECT_1();

            /*" -2246- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2248- MOVE 'NAO' TO SOR-MOVIMCOB LD01-MOVIMCOB */
                _.Move("NAO", REG_SVA0140B.SOR_MOVIMCOB, ARQUIVOS_SAIDA.LD01.LD01_MOVIMCOB);

                /*" -2250- MOVE SPACES TO SOR-SITMCOB LD01-SITMCOB */
                _.Move("", REG_SVA0140B.SOR_SITMCOB, ARQUIVOS_SAIDA.LD01.LD01_SITMCOB);

                /*" -2252- MOVE ZEROS TO SOR-VAL-TITULO LD01-VAL-TITULO */
                _.Move(0, REG_SVA0140B.SOR_VAL_TITULO, ARQUIVOS_SAIDA.LD01.LD01_VAL_TITULO);

                /*" -2253- ELSE */
            }
            else
            {


                /*" -2254- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2258- DISPLAY 'R0420-00 - PROBLEMAS NO SELECT(MOVIMCOB)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' PARCELA     = ' HISCONPA-NUM-PARCELA ' TITULO      = ' HISCONPA-NUM-PARCELA */

                    $"R0420-00 - PROBLEMAS NO SELECT(MOVIMCOB) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA} TITULO      = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}"
                    .Display();

                    /*" -2259- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2260- ELSE */
                }
                else
                {


                    /*" -2262- MOVE 'SIM' TO SOR-MOVIMCOB LD01-MOVIMCOB */
                    _.Move("SIM", REG_SVA0140B.SOR_MOVIMCOB, ARQUIVOS_SAIDA.LD01.LD01_MOVIMCOB);

                    /*" -2264- MOVE MOVIMCOB-SIT-REGISTRO TO SOR-SITMCOB LD01-SITMCOB */
                    _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO, REG_SVA0140B.SOR_SITMCOB, ARQUIVOS_SAIDA.LD01.LD01_SITMCOB);

                    /*" -2265- MOVE MOVIMCOB-VAL-TITULO TO SOR-VAL-TITULO LD01-VAL-TITULO. */
                    _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, REG_SVA0140B.SOR_VAL_TITULO, ARQUIVOS_SAIDA.LD01.LD01_VAL_TITULO);
                }

            }


        }

        [StopWatch]
        /*" R0420-00-SELECT-MOVIMCOB-DB-SELECT-1 */
        public void R0420_00_SELECT_MOVIMCOB_DB_SELECT_1()
        {
            /*" -2242- EXEC SQL SELECT SIT_REGISTRO ,VAL_TITULO INTO :MOVIMCOB-SIT-REGISTRO ,:MOVIMCOB-VAL-TITULO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE NUM_TITULO = :HISCONPA-NUM-TITULO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 = new R0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_TITULO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO.ToString(),
            };

            var executed_1 = R0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1.Execute(r0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMCOB_SIT_REGISTRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
                _.Move(executed_1.MOVIMCOB_VAL_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0430-00-SELECT-MOVDEBCE-SECTION */
        private void R0430_00_SELECT_MOVDEBCE_SECTION()
        {
            /*" -2278- MOVE '0430' TO WNR-EXEC-SQL. */
            _.Move("0430", W.WABEND.WNR_EXEC_SQL);

            /*" -2292- PERFORM R0430_00_SELECT_MOVDEBCE_DB_SELECT_1 */

            R0430_00_SELECT_MOVDEBCE_DB_SELECT_1();

            /*" -2296- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2298- MOVE 'NAO' TO SOR-MOVDEBCE LD01-MOVDEBCE */
                _.Move("NAO", REG_SVA0140B.SOR_MOVDEBCE, ARQUIVOS_SAIDA.LD01.LD01_MOVDEBCE);

                /*" -2300- MOVE SPACES TO SOR-SITMDEB LD01-SITMDEB */
                _.Move("", REG_SVA0140B.SOR_SITMDEB, ARQUIVOS_SAIDA.LD01.LD01_SITMDEB);

                /*" -2304- MOVE ZEROS TO SOR-VALOR-DEBITO LD01-VALOR-DEBITO SOR-CONVENIO LD01-CONVENIO */
                _.Move(0, REG_SVA0140B.SOR_VALOR_DEBITO, ARQUIVOS_SAIDA.LD01.LD01_VALOR_DEBITO, REG_SVA0140B.SOR_CONVENIO, ARQUIVOS_SAIDA.LD01.LD01_CONVENIO);

                /*" -2307- GO TO R0430-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2308- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2312- DISPLAY 'R0430-00 - PROBLEMAS NO SELECT(MOVDEBCE)' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' PARCELA     = ' HISCONPA-NUM-PARCELA ' TITULO      = ' HISCONPA-NUM-PARCELA */

                $"R0430-00 - PROBLEMAS NO SELECT(MOVDEBCE) CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA} TITULO      = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}"
                .Display();

                /*" -2315- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2316- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -2320- MOVE ZEROS TO MOVDEBCE-VLR-CREDITO. */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);
            }


            /*" -2322- MOVE 'SIM' TO SOR-MOVDEBCE LD01-MOVDEBCE. */
            _.Move("SIM", REG_SVA0140B.SOR_MOVDEBCE, ARQUIVOS_SAIDA.LD01.LD01_MOVDEBCE);

            /*" -2325- MOVE MOVDEBCE-SITUACAO-COBRANCA TO SOR-SITMDEB LD01-SITMDEB. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA, REG_SVA0140B.SOR_SITMDEB, ARQUIVOS_SAIDA.LD01.LD01_SITMDEB);

            /*" -2328- MOVE MOVDEBCE-COD-CONVENIO TO SOR-CONVENIO LD01-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, REG_SVA0140B.SOR_CONVENIO, ARQUIVOS_SAIDA.LD01.LD01_CONVENIO);

            /*" -2329- IF MOVDEBCE-VALOR-DEBITO NOT EQUAL ZEROS */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO != 00)
            {

                /*" -2332- MOVE MOVDEBCE-VALOR-DEBITO TO LD01-VALOR-DEBITO SOR-VALOR-DEBITO */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO, ARQUIVOS_SAIDA.LD01.LD01_VALOR_DEBITO, REG_SVA0140B.SOR_VALOR_DEBITO);

                /*" -2333- ELSE */
            }
            else
            {


                /*" -2335- MOVE MOVDEBCE-VLR-CREDITO TO LD01-VALOR-DEBITO SOR-VALOR-DEBITO. */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO, ARQUIVOS_SAIDA.LD01.LD01_VALOR_DEBITO, REG_SVA0140B.SOR_VALOR_DEBITO);
            }


        }

        [StopWatch]
        /*" R0430-00-SELECT-MOVDEBCE-DB-SELECT-1 */
        public void R0430_00_SELECT_MOVDEBCE_DB_SELECT_1()
        {
            /*" -2292- EXEC SQL SELECT SITUACAO_COBRANCA ,VALOR_DEBITO ,COD_CONVENIO ,VLR_CREDITO INTO :MOVDEBCE-SITUACAO-COBRANCA ,:MOVDEBCE-VALOR-DEBITO ,:MOVDEBCE-COD-CONVENIO ,:MOVDEBCE-VLR-CREDITO:VIND-NULL01 FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_CARTAO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 = new R0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1.Execute(r0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(executed_1.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
                _.Move(executed_1.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(executed_1.MOVDEBCE_VLR_CREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-CONSISTE-REGISTRO-SECTION */
        private void R0450_00_CONSISTE_REGISTRO_SECTION()
        {
            /*" -2348- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", W.WABEND.WNR_EXEC_SQL);

            /*" -2349- IF WS-VALOR NOT GREATER ZEROS */

            if (W.WS_VALOR <= 00)
            {

                /*" -2350- PERFORM R4000-00-UPDATE-HISCONPA */

                R4000_00_UPDATE_HISCONPA_SECTION();

                /*" -2352- MOVE 'VALOR VG+AP NAO MAIOR QUE ZEROS       ' TO LD01-OBSERVA */
                _.Move("VALOR VG+AP NAO MAIOR QUE ZEROS       ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2353- ADD 1 TO DP-VALOR */
                W.DP_VALOR.Value = W.DP_VALOR + 1;

                /*" -2354- PERFORM R4000-00-UPDATE-HISCONPA */

                R4000_00_UPDATE_HISCONPA_SECTION();

                /*" -2357- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2359- IF HISCONPA-PREMIO-VG EQUAL ZEROS AND HISCONPA-PREMIO-AP EQUAL ZEROS */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG == 00 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP == 00)
            {

                /*" -2361- MOVE 'REGISTRO SEM VALOR INFORMADO    ' TO LD01-OBSERVA */
                _.Move("REGISTRO SEM VALOR INFORMADO    ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2362- ADD 1 TO DP-VALOR */
                W.DP_VALOR.Value = W.DP_VALOR + 1;

                /*" -2363- PERFORM R4000-00-UPDATE-HISCONPA */

                R4000_00_UPDATE_HISCONPA_SECTION();

                /*" -2366- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2367- IF SOR-OPERCAP EQUAL 210 */

            if (REG_SVA0140B.SOR_OPERCAP == 210)
            {

                /*" -2369- MOVE 'RCAP DEVOLVIDO                  ' TO LD01-OBSERVA */
                _.Move("RCAP DEVOLVIDO                  ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2370- PERFORM R4000-00-UPDATE-HISCONPA */

                R4000_00_UPDATE_HISCONPA_SECTION();

                /*" -2371- ADD 1 TO DP-RCAPS */
                W.DP_RCAPS.Value = W.DP_RCAPS + 1;

                /*" -2374- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2375- IF HISCONPA-DATA-MOVIMENTO LESS WHOST-DATA10 */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO < WHOST_DATA10)
            {

                /*" -2377- MOVE 'DTMOVTO LESS 10 MESES           ' TO LD01-OBSERVA */
                _.Move("DTMOVTO LESS 10 MESES           ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2378- PERFORM R4000-00-UPDATE-HISCONPA */

                R4000_00_UPDATE_HISCONPA_SECTION();

                /*" -2379- ADD 1 TO DP-DATA */
                W.DP_DATA.Value = W.DP_DATA + 1;

                /*" -2382- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2383- IF SOR-PROGRAMA EQUAL SPACES */

            if (REG_SVA0140B.SOR_PROGRAMA.IsEmpty())
            {

                /*" -2385- MOVE 'DESPREZA ESTR-COBR - ORIG-PRODU ' TO LD01-OBSERVA */
                _.Move("DESPREZA ESTR-COBR - ORIG-PRODU ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2386- ADD 1 TO DP-PRODUVG */
                W.DP_PRODUVG.Value = W.DP_PRODUVG + 1;

                /*" -2388- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2391- IF SOR-PROGRAMA EQUAL 'VG0139B' AND PRODUVG-ORIG-PRODU EQUAL 'EMPRE' AND HISCONPA-COD-SUBGRUPO EQUAL ZEROS */

            if (REG_SVA0140B.SOR_PROGRAMA == "VG0139B" && PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "EMPRE" && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO == 00)
            {

                /*" -2393- MOVE 'ORIG-PRODU = EMPRE - CODSUBES = ZEROS' TO LD01-OBSERVA */
                _.Move("ORIG-PRODU = EMPRE - CODSUBES = ZEROS", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2394- ADD 1 TO DP-PRODUVG */
                W.DP_PRODUVG.Value = W.DP_PRODUVG + 1;

                /*" -2399- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2401- IF HISCONPA-COD-OPERACAO GREATER 199 AND HISCONPA-COD-OPERACAO LESS 300 */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO > 199 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO < 300)
            {

                /*" -2402- ADD 1 TO TT-BAIXA */
                W.TT_BAIXA.Value = W.TT_BAIXA + 1;

                /*" -2405- MOVE '1' TO SOR-TIPO-ENDOSSO LD01-TIPO-ENDOSSO */
                _.Move("1", REG_SVA0140B.SOR_TIPO_ENDOSSO, ARQUIVOS_SAIDA.LD01.LD01_TIPO_ENDOSSO);

                /*" -2409- ELSE */
            }
            else
            {


                /*" -2411- IF HISCONPA-COD-OPERACAO GREATER 499 AND HISCONPA-COD-OPERACAO LESS 600 */

                if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO > 499 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO < 600)
                {

                    /*" -2412- ADD 1 TO TT-ESTORNO */
                    W.TT_ESTORNO.Value = W.TT_ESTORNO + 1;

                    /*" -2415- MOVE '3' TO SOR-TIPO-ENDOSSO LD01-TIPO-ENDOSSO */
                    _.Move("3", REG_SVA0140B.SOR_TIPO_ENDOSSO, ARQUIVOS_SAIDA.LD01.LD01_TIPO_ENDOSSO);

                    /*" -2416- ELSE */
                }
                else
                {


                    /*" -2418- MOVE 'DESPREZA OPERACAO               ' TO LD01-OBSERVA */
                    _.Move("DESPREZA OPERACAO               ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                    /*" -2419- PERFORM R4000-00-UPDATE-HISCONPA */

                    R4000_00_UPDATE_HISCONPA_SECTION();

                    /*" -2420- ADD 1 TO DP-OPERACAO */
                    W.DP_OPERACAO.Value = W.DP_OPERACAO + 1;

                    /*" -2423- GO TO R0450-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2425- IF HISCOBPR-DATA-INIVIGENCIA EQUAL SPACES OR HISCOBPR-DATA-TERVIGENCIA EQUAL SPACES */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.IsEmpty() || HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA.IsEmpty())
            {

                /*" -2427- MOVE 'HISCOBPR NAO CADASTRADA              ' TO LD01-OBSERVA */
                _.Move("HISCOBPR NAO CADASTRADA              ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2428- ADD 1 TO DP-HISCOBPR */
                W.DP_HISCOBPR.Value = W.DP_HISCOBPR + 1;

                /*" -2431- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2432- IF WTEM-OPCPAGVI NOT EQUAL 'S' */

            if (W.WTEM_OPCPAGVI != "S")
            {

                /*" -2434- MOVE 'OPCPAGVI NAO CADASTRADA              ' TO LD01-OBSERVA */
                _.Move("OPCPAGVI NAO CADASTRADA              ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2435- ADD 1 TO DP-OPCPAGVI */
                W.DP_OPCPAGVI.Value = W.DP_OPCPAGVI + 1;

                /*" -2438- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2439- IF WTEM-PARCEVID NOT EQUAL 'S' */

            if (W.WTEM_PARCEVID != "S")
            {

                /*" -2441- MOVE 'PARCEVID NAO CADASTRADA              ' TO LD01-OBSERVA */
                _.Move("PARCEVID NAO CADASTRADA              ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2442- ADD 1 TO DP-PARCEVID */
                W.DP_PARCEVID.Value = W.DP_PARCEVID + 1;

                /*" -2445- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2447- IF SOR-DTINIEMI EQUAL SPACES AND SOR-PERI-PAGAMENTO EQUAL ZEROS */

            if (REG_SVA0140B.SOR_DTINIEMI.IsEmpty() && REG_SVA0140B.SOR_PERI_PAGAMENTO == 00)
            {

                /*" -2449- MOVE 'PERI ZERO SEM VIGENCIA               ' TO LD01-OBSERVA */
                _.Move("PERI ZERO SEM VIGENCIA               ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2450- ADD 1 TO DP-PERI */
                W.DP_PERI.Value = W.DP_PERI + 1;

                /*" -2453- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2455- IF APOLICES-RAMO-EMISSOR EQUAL 77 AND HISCONPA-PREMIO-VG NOT GREATER ZEROS */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 77 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG <= 00)
            {

                /*" -2457- MOVE 'RAMO 77 - PREMIO VG NAO MAIOR ZEROS ' TO LD01-OBSERVA */
                _.Move("RAMO 77 - PREMIO VG NAO MAIOR ZEROS ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2458- ADD 1 TO DP-VALOR */
                W.DP_VALOR.Value = W.DP_VALOR + 1;

                /*" -2461- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2463- IF APOLICES-RAMO-EMISSOR EQUAL 81 AND HISCONPA-PREMIO-AP NOT GREATER ZEROS */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 81 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP <= 00)
            {

                /*" -2465- MOVE 'RAMO 81 - PREMIO AP NAO MAIOR ZEROS ' TO LD01-OBSERVA */
                _.Move("RAMO 81 - PREMIO AP NAO MAIOR ZEROS ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2466- ADD 1 TO DP-VALOR */
                W.DP_VALOR.Value = W.DP_VALOR + 1;

                /*" -2469- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2471- IF APOLICES-RAMO-EMISSOR EQUAL 82 AND HISCONPA-PREMIO-AP NOT GREATER ZEROS */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 82 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP <= 00)
            {

                /*" -2473- MOVE 'RAMO 82 - PREMIO AP NAO MAIOR ZEROS ' TO LD01-OBSERVA */
                _.Move("RAMO 82 - PREMIO AP NAO MAIOR ZEROS ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2474- ADD 1 TO DP-VALOR */
                W.DP_VALOR.Value = W.DP_VALOR + 1;

                /*" -2477- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2479- IF APOLICES-RAMO-EMISSOR EQUAL 93 AND HISCONPA-PREMIO-VG NOT GREATER ZEROS */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 93 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG <= 00)
            {

                /*" -2481- MOVE 'RAMO 93 - PREMIO VG NAO MAIOR ZEROS ' TO LD01-OBSERVA */
                _.Move("RAMO 93 - PREMIO VG NAO MAIOR ZEROS ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2482- ADD 1 TO DP-VALOR */
                W.DP_VALOR.Value = W.DP_VALOR + 1;

                /*" -2482- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0460-00-SELECT-AVISOSAL-SECTION */
        private void R0460_00_SELECT_AVISOSAL_SECTION()
        {
            /*" -2527- MOVE '0460' TO WNR-EXEC-SQL. */
            _.Move("0460", W.WABEND.WNR_EXEC_SQL);

            /*" -2528- IF SOR-NRAVISO EQUAL ZEROS */

            if (REG_SVA0140B.SOR_NRAVISO == 00)
            {

                /*" -2530- MOVE 7777777777777 TO SOR-SALDO LD02-SALDO */
                _.Move(7777777777777, REG_SVA0140B.SOR_SALDO, ARQUIVOS_SAIDA.LD02.LD02_SALDO);

                /*" -2533- GO TO R0460-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2535- MOVE SOR-BCOAVISO TO AVISOSAL-BCO-AVISO. */
            _.Move(REG_SVA0140B.SOR_BCOAVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO);

            /*" -2537- MOVE SOR-AGEAVISO TO AVISOSAL-AGE-AVISO. */
            _.Move(REG_SVA0140B.SOR_AGEAVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO);

            /*" -2541- MOVE SOR-NRAVISO TO AVISOSAL-NUM-AVISO-CREDITO. */
            _.Move(REG_SVA0140B.SOR_NRAVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO);

            /*" -2550- PERFORM R0460_00_SELECT_AVISOSAL_DB_SELECT_1 */

            R0460_00_SELECT_AVISOSAL_DB_SELECT_1();

            /*" -2554- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2556- MOVE 9999999999999 TO SOR-SALDO LD02-SALDO */
                _.Move(9999999999999, REG_SVA0140B.SOR_SALDO, ARQUIVOS_SAIDA.LD02.LD02_SALDO);

                /*" -2557- ELSE */
            }
            else
            {


                /*" -2558- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2562- DISPLAY 'R0460-00 - PROBLEMAS NO SELECT(AVISOSAL)' ' BCO         = ' AVISOSAL-BCO-AVISO ' AGE         = ' AVISOSAL-AGE-AVISO ' AVISO       = ' AVISOSAL-NUM-AVISO-CREDITO */

                    $"R0460-00 - PROBLEMAS NO SELECT(AVISOSAL) BCO         = {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO} AGE         = {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO} AVISO       = {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO}"
                    .Display();

                    /*" -2563- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2564- ELSE */
                }
                else
                {


                    /*" -2566- MOVE AVISOSAL-SALDO-ATUAL TO SOR-SALDO LD02-SALDO. */
                    _.Move(AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL, REG_SVA0140B.SOR_SALDO, ARQUIVOS_SAIDA.LD02.LD02_SALDO);
                }

            }


        }

        [StopWatch]
        /*" R0460-00-SELECT-AVISOSAL-DB-SELECT-1 */
        public void R0460_00_SELECT_AVISOSAL_DB_SELECT_1()
        {
            /*" -2550- EXEC SQL SELECT SALDO_ATUAL INTO :AVISOSAL-SALDO-ATUAL FROM SEGUROS.AVISOS_SALDOS WHERE BCO_AVISO = :AVISOSAL-BCO-AVISO AND AGE_AVISO = :AVISOSAL-AGE-AVISO AND NUM_AVISO_CREDITO = :AVISOSAL-NUM-AVISO-CREDITO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1 = new R0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1()
            {
                AVISOSAL_NUM_AVISO_CREDITO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO.ToString(),
                AVISOSAL_BCO_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO.ToString(),
                AVISOSAL_AGE_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO.ToString(),
            };

            var executed_1 = R0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1.Execute(r0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOSAL_SALDO_ATUAL, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-PROCESSA-SORT-SECTION */
        private void R0500_00_PROCESSA_SORT_SECTION()
        {
            /*" -2579- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", W.WABEND.WNR_EXEC_SQL);

            /*" -2582- MOVE ZEROS TO ATU-NRCERTIF ANT-NRCERTIF WS-NRSEQ. */
            _.Move(0, W.WS_CHAVE_ATU.ATU_NRCERTIF, W.WS_CHAVE_ANT.ANT_NRCERTIF, W.WS_NRSEQ);

            /*" -2584- MOVE SPACES TO ATU-TIPO ANT-TIPO. */
            _.Move("", W.WS_CHAVE_ATU.ATU_TIPO, W.WS_CHAVE_ANT.ANT_TIPO);

            /*" -2585- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -2587- PERFORM R0510-00-LER-SORT. */

            R0510_00_LER_SORT_SECTION();

            /*" -2588- IF WFIM-SORT NOT EQUAL SPACES */

            if (!W.WFIM_SORT.IsEmpty())
            {

                /*" -2591- GO TO R0500-90-DISPLAY. */

                R0500_90_DISPLAY(); //GOTO
                return;
            }


            /*" -2592- PERFORM R0520-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R0520_00_PROCESSA_SORT_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0500_90_DISPLAY */

            R0500_90_DISPLAY();

        }

        [StopWatch]
        /*" R0500-90-DISPLAY */
        private void R0500_90_DISPLAY(bool isPerform = false)
        {
            /*" -2598- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -2602- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2603- DISPLAY 'LIDOS SORT ................ ' LD-SORT */
            _.Display($"LIDOS SORT ................ {W.LD_SORT}");

            /*" -2604- DISPLAY 'DESPREZA SORT ............. ' DP-SORT */
            _.Display($"DESPREZA SORT ............. {W.DP_SORT}");

            /*" -2605- DISPLAY 'DESPREZA ENDOSSO .......... ' DP-ENDOSSO */
            _.Display($"DESPREZA ENDOSSO .......... {W.DP_ENDOSSO}");

            /*" -2606- DISPLAY 'DESPREZA PRMDIT ........... ' DP-PRMDIT */
            _.Display($"DESPREZA PRMDIT ........... {W.DP_PRMDIT}");

            /*" -2607- DISPLAY 'DESPREZA VIGENCIA ......... ' DP-VIGENCIA */
            _.Display($"DESPREZA VIGENCIA ......... {W.DP_VIGENCIA}");

            /*" -2608- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2609- DISPLAY 'GRAVADOS ARQUIVO 1 ........ ' AC-GRAVA01 */
            _.Display($"GRAVADOS ARQUIVO 1 ........ {W.AC_GRAVA01}");

            /*" -2610- DISPLAY 'GRAVADOS ARQUIVO 2 ........ ' AC-GRAVA02 */
            _.Display($"GRAVADOS ARQUIVO 2 ........ {W.AC_GRAVA02}");

            /*" -2611- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2612- DISPLAY 'UPDATE HISCONPA ........... ' UP-HISCONPA */
            _.Display($"UPDATE HISCONPA ........... {W.UP_HISCONPA}");

            /*" -2613- DISPLAY 'UPDATE RCAPS .............. ' UP-RCAPS */
            _.Display($"UPDATE RCAPS .............. {W.UP_RCAPS}");

            /*" -2613- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-LER-SORT-SECTION */
        private void R0510_00_LER_SORT_SECTION()
        {
            /*" -2626- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", W.WABEND.WNR_EXEC_SQL);

            /*" -2628- RETURN SVA0140B AT END */
            try
            {
                SVA0140B.Return(REG_SVA0140B, () =>
                {

                    /*" -2629- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -2632- GO TO R0510-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -2635- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

            /*" -2637- MOVE LD-SORT TO AC-LIDOS. */
            _.Move(W.LD_SORT, W.AC_LIDOS);

            /*" -2639- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -2640- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -2641- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -2642- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -2643- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -2644- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -2645- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -2649- DISPLAY 'LIDOS SORT         ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS SORT         {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


            /*" -2651- MOVE SOR-NUM-CERTIFICADO TO ATU-NRCERTIF. */
            _.Move(REG_SVA0140B.SOR_NUM_CERTIFICADO, W.WS_CHAVE_ATU.ATU_NRCERTIF);

            /*" -2652- MOVE SOR-TIPO-ENDOSSO TO ATU-TIPO. */
            _.Move(REG_SVA0140B.SOR_TIPO_ENDOSSO, W.WS_CHAVE_ATU.ATU_TIPO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-PROCESSA-SORT-SECTION */
        private void R0520_00_PROCESSA_SORT_SECTION()
        {
            /*" -2665- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", W.WABEND.WNR_EXEC_SQL);

            /*" -2670- MOVE SPACES TO WHOST-DATA-INIVIGENCIA WHOST-DATA-TERVIGENCIA. */
            _.Move("", WHOST_DATA_INIVIGENCIA, WHOST_DATA_TERVIGENCIA);

            /*" -2676- PERFORM R0550-00-MOVE-DADOS-SAIDA. */

            R0550_00_MOVE_DADOS_SAIDA_SECTION();

            /*" -2677- IF SOR-SITUACAO EQUAL '4' */

            if (REG_SVA0140B.SOR_SITUACAO == "4")
            {

                /*" -2679- IF SOR-NUM-PARCELA GREATER 1 NEXT SENTENCE */

                if (REG_SVA0140B.SOR_NUM_PARCELA > 1)
                {

                    /*" -2680- ELSE */
                }
                else
                {


                    /*" -2681- PERFORM R0610-00-SELECT-HISCONPA */

                    R0610_00_SELECT_HISCONPA_SECTION();

                    /*" -2682- IF AC-FATURA NOT EQUAL 'S' */

                    if (W.AC_FATURA != "S")
                    {

                        /*" -2684- MOVE ' PARCELA DE ADESAO NAO INTEGRADA' TO LD01-OBSERVA */
                        _.Move(" PARCELA DE ADESAO NAO INTEGRADA", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                        /*" -2685- PERFORM R1300-00-MONTA-RCAP */

                        R1300_00_MONTA_RCAP_SECTION();

                        /*" -2686- WRITE REG-VA0140B1 FROM LD01 */
                        _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_VA0140B1);

                        SAIDA01.Write(REG_VA0140B1.GetMoveValues().ToString());

                        /*" -2687- ADD 1 TO AC-GRAVA01 */
                        W.AC_GRAVA01.Value = W.AC_GRAVA01 + 1;

                        /*" -2688- ADD 1 TO DP-SORT */
                        W.DP_SORT.Value = W.DP_SORT + 1;

                        /*" -2695- GO TO R0520-90-LEITURA. */

                        R0520_90_LEITURA(); //GOTO
                        return;
                    }

                }

            }


            /*" -2696- IF SOR-TIPO-ENDOSSO EQUAL '3' */

            if (REG_SVA0140B.SOR_TIPO_ENDOSSO == "3")
            {

                /*" -2697- PERFORM R0630-00-SELECT-HISCONPA */

                R0630_00_SELECT_HISCONPA_SECTION();

                /*" -2701- ELSE */
            }
            else
            {


                /*" -2702- IF SOR-NUM-PARCELA GREATER 1 */

                if (REG_SVA0140B.SOR_NUM_PARCELA > 1)
                {

                    /*" -2703- PERFORM R0640-00-SELECT-HISCONPA */

                    R0640_00_SELECT_HISCONPA_SECTION();

                    /*" -2704- ELSE */
                }
                else
                {


                    /*" -2707- MOVE 'S' TO AC-FATURA. */
                    _.Move("S", W.AC_FATURA);
                }

            }


            /*" -2708- IF AC-FATURA NOT EQUAL 'S' */

            if (W.AC_FATURA != "S")
            {

                /*" -2710- MOVE ' ENDOSSO NAO CADASTRADO VIGENCIA' TO LD01-OBSERVA */
                _.Move(" ENDOSSO NAO CADASTRADO VIGENCIA", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2711- ADD 1 TO AC-GRAVA01 */
                W.AC_GRAVA01.Value = W.AC_GRAVA01 + 1;

                /*" -2712- WRITE REG-VA0140B1 FROM LD01 */
                _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_VA0140B1);

                SAIDA01.Write(REG_VA0140B1.GetMoveValues().ToString());

                /*" -2713- ADD 1 TO DP-ENDOSSO */
                W.DP_ENDOSSO.Value = W.DP_ENDOSSO + 1;

                /*" -2716- GO TO R0520-90-LEITURA. */

                R0520_90_LEITURA(); //GOTO
                return;
            }


            /*" -2718- IF SOR-DTINIEMI EQUAL SPACES OR SOR-DTTEREMI EQUAL SPACES */

            if (REG_SVA0140B.SOR_DTINIEMI.IsEmpty() || REG_SVA0140B.SOR_DTTEREMI.IsEmpty())
            {

                /*" -2720- MOVE ' SEM VIGENCIA PARA EMISSAO      ' TO LD01-OBSERVA */
                _.Move(" SEM VIGENCIA PARA EMISSAO      ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2721- ADD 1 TO AC-GRAVA01 */
                W.AC_GRAVA01.Value = W.AC_GRAVA01 + 1;

                /*" -2722- WRITE REG-VA0140B1 FROM LD01 */
                _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_VA0140B1);

                SAIDA01.Write(REG_VA0140B1.GetMoveValues().ToString());

                /*" -2723- ADD 1 TO DP-VIGENCIA */
                W.DP_VIGENCIA.Value = W.DP_VIGENCIA + 1;

                /*" -2726- GO TO R0520-90-LEITURA. */

                R0520_90_LEITURA(); //GOTO
                return;
            }


            /*" -2727- IF SOR-NUM-CERTIFICADO EQUAL 95429351280 */

            if (REG_SVA0140B.SOR_NUM_CERTIFICADO == 95429351280)
            {

                /*" -2728- IF SOR-NUM-PARCELA EQUAL 79 */

                if (REG_SVA0140B.SOR_NUM_PARCELA == 79)
                {

                    /*" -2732- MOVE '2019-11-01' TO SOR-DTINIEMI LD01-DTINIEMI LD02-DTINIEMI */
                    _.Move("2019-11-01", REG_SVA0140B.SOR_DTINIEMI, ARQUIVOS_SAIDA.LD01.LD01_DTINIEMI, ARQUIVOS_SAIDA.LD02.LD02_DTINIEMI);

                    /*" -2736- MOVE '2019-11-30' TO SOR-DTTEREMI LD01-DTTEREMI LD02-DTTEREMI */
                    _.Move("2019-11-30", REG_SVA0140B.SOR_DTTEREMI, ARQUIVOS_SAIDA.LD01.LD01_DTTEREMI, ARQUIVOS_SAIDA.LD02.LD02_DTTEREMI);

                    /*" -2737- ELSE */
                }
                else
                {


                    /*" -2738- IF SOR-NUM-PARCELA EQUAL 80 */

                    if (REG_SVA0140B.SOR_NUM_PARCELA == 80)
                    {

                        /*" -2742- MOVE '2019-12-01' TO SOR-DTINIEMI LD01-DTINIEMI LD02-DTINIEMI */
                        _.Move("2019-12-01", REG_SVA0140B.SOR_DTINIEMI, ARQUIVOS_SAIDA.LD01.LD01_DTINIEMI, ARQUIVOS_SAIDA.LD02.LD02_DTINIEMI);

                        /*" -2746- MOVE '2019-12-31' TO SOR-DTTEREMI LD01-DTTEREMI LD02-DTTEREMI */
                        _.Move("2019-12-31", REG_SVA0140B.SOR_DTTEREMI, ARQUIVOS_SAIDA.LD01.LD01_DTTEREMI, ARQUIVOS_SAIDA.LD02.LD02_DTTEREMI);

                        /*" -2747- ELSE */
                    }
                    else
                    {


                        /*" -2748- IF SOR-NUM-PARCELA EQUAL 81 */

                        if (REG_SVA0140B.SOR_NUM_PARCELA == 81)
                        {

                            /*" -2752- MOVE '2020-01-01' TO SOR-DTINIEMI LD01-DTINIEMI LD02-DTINIEMI */
                            _.Move("2020-01-01", REG_SVA0140B.SOR_DTINIEMI, ARQUIVOS_SAIDA.LD01.LD01_DTINIEMI, ARQUIVOS_SAIDA.LD02.LD02_DTINIEMI);

                            /*" -2758- MOVE '2020-01-31' TO SOR-DTTEREMI LD01-DTTEREMI LD02-DTTEREMI. */
                            _.Move("2020-01-31", REG_SVA0140B.SOR_DTTEREMI, ARQUIVOS_SAIDA.LD01.LD01_DTTEREMI, ARQUIVOS_SAIDA.LD02.LD02_DTTEREMI);
                        }

                    }

                }

            }


            /*" -2759- IF SOR-DTTEREMI GREATER SOR-TERZERO */

            if (REG_SVA0140B.SOR_DTTEREMI > REG_SVA0140B.SOR_TERZERO)
            {

                /*" -2760- PERFORM R0530-00-SELECT-ENDOSSOS */

                R0530_00_SELECT_ENDOSSOS_SECTION();

                /*" -2762- MOVE WHOST-DATAMES1 TO SOR-DTINIEMI */
                _.Move(WHOST_DATAMES1, REG_SVA0140B.SOR_DTINIEMI);

                /*" -2766- MOVE WHOST-DATAMES2 TO SOR-DTTEREMI. */
                _.Move(WHOST_DATAMES2, REG_SVA0140B.SOR_DTTEREMI);
            }


            /*" -2767- IF SOR-DTTEREMI GREATER SOR-TERZERO */

            if (REG_SVA0140B.SOR_DTTEREMI > REG_SVA0140B.SOR_TERZERO)
            {

                /*" -2769- MOVE ' PRORROGAR VIGENCIA DA APOLICE  ' TO LD01-OBSERVA */
                _.Move(" PRORROGAR VIGENCIA DA APOLICE  ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2770- ADD 1 TO AC-GRAVA01 */
                W.AC_GRAVA01.Value = W.AC_GRAVA01 + 1;

                /*" -2771- WRITE REG-VA0140B1 FROM LD01 */
                _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_VA0140B1);

                SAIDA01.Write(REG_VA0140B1.GetMoveValues().ToString());

                /*" -2772- ADD 1 TO DP-VIGENCIA */
                W.DP_VIGENCIA.Value = W.DP_VIGENCIA + 1;

                /*" -2775- GO TO R0520-90-LEITURA. */

                R0520_90_LEITURA(); //GOTO
                return;
            }


            /*" -2777- IF SOR-TIPO-ENDOSSO EQUAL '1' AND WS-CHAVE-ATU EQUAL WS-CHAVE-ANT */

            if (REG_SVA0140B.SOR_TIPO_ENDOSSO == "1" && W.WS_CHAVE_ATU == W.WS_CHAVE_ANT)
            {

                /*" -2778- ADD 1 TO WS-NRSEQ */
                W.WS_NRSEQ.Value = W.WS_NRSEQ + 1;

                /*" -2779- ELSE */
            }
            else
            {


                /*" -2782- MOVE 1 TO WS-NRSEQ. */
                _.Move(1, W.WS_NRSEQ);
            }


            /*" -2784- IF SISTEMAS-DATA-MOV-ABERTO LESS SOR-DTINIEMI AND SOR-NUM-PARCELA GREATER 1 */

            if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO < REG_SVA0140B.SOR_DTINIEMI && REG_SVA0140B.SOR_NUM_PARCELA > 1)
            {

                /*" -2787- PERFORM R0670-00-VER-VIGENCIA. */

                R0670_00_VER_VIGENCIA_SECTION();
            }


            /*" -2788- MOVE WS-NRSEQ TO LD02-NRSEQ. */
            _.Move(W.WS_NRSEQ, ARQUIVOS_SAIDA.LD02.LD02_NRSEQ);

            /*" -2790- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT. */
            _.Move(W.WS_CHAVE_ATU, W.WS_CHAVE_ANT);

            /*" -2790- PERFORM R0700-00-PROCESSA-REGISTRO. */

            R0700_00_PROCESSA_REGISTRO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0520_90_LEITURA */

            R0520_90_LEITURA();

        }

        [StopWatch]
        /*" R0520-90-LEITURA */
        private void R0520_90_LEITURA(bool isPerform = false)
        {
            /*" -2795- PERFORM R0510-00-LER-SORT. */

            R0510_00_LER_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0530-00-SELECT-ENDOSSOS-SECTION */
        private void R0530_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -2807- MOVE '0530' TO WNR-EXEC-SQL. */
            _.Move("0530", W.WABEND.WNR_EXEC_SQL);

            /*" -2809- MOVE SOR-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(REG_SVA0140B.SOR_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -2813- MOVE ZEROS TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -2823- PERFORM R0530_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0530_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -2827- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2829- MOVE SOR-DTINIEMI TO WHOST-DATAMES1 */
                _.Move(REG_SVA0140B.SOR_DTINIEMI, WHOST_DATAMES1);

                /*" -2831- MOVE SOR-DTTEREMI TO WHOST-DATAMES2 */
                _.Move(REG_SVA0140B.SOR_DTTEREMI, WHOST_DATAMES2);

                /*" -2832- ELSE */
            }
            else
            {


                /*" -2833- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2834- DISPLAY 'R0530-00 - PROBLEMAS SELECT  (ENDOSSOS)  ' */
                    _.Display($"R0530-00 - PROBLEMAS SELECT  (ENDOSSOS)  ");

                    /*" -2834- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0530-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0530_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -2823- EXEC SQL SELECT DATA_TERVIGENCIA ,DATA_TERVIGENCIA - 1 MONTHS INTO :WHOST-DATAMES2 ,:WHOST-DATAMES1 FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATAMES2, WHOST_DATAMES2);
                _.Move(executed_1.WHOST_DATAMES1, WHOST_DATAMES1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-MOVE-DADOS-SAIDA-SECTION */
        private void R0550_00_MOVE_DADOS_SAIDA_SECTION()
        {
            /*" -2847- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", W.WABEND.WNR_EXEC_SQL);

            /*" -2850- MOVE SOR-PROGRAMA TO LD02-PROGRAMA LD01-PROGRAMA. */
            _.Move(REG_SVA0140B.SOR_PROGRAMA, ARQUIVOS_SAIDA.LD02.LD02_PROGRAMA, ARQUIVOS_SAIDA.LD01.LD01_PROGRAMA);

            /*" -2853- MOVE SOR-TIPO-ENDOSSO TO LD02-TIPO-ENDOSSO LD01-TIPO-ENDOSSO. */
            _.Move(REG_SVA0140B.SOR_TIPO_ENDOSSO, ARQUIVOS_SAIDA.LD02.LD02_TIPO_ENDOSSO, ARQUIVOS_SAIDA.LD01.LD01_TIPO_ENDOSSO);

            /*" -2856- MOVE SOR-NUM-CERTIFICADO TO LD02-NUM-CERTIFICADO LD01-NRCERTIF. */
            _.Move(REG_SVA0140B.SOR_NUM_CERTIFICADO, ARQUIVOS_SAIDA.LD02.LD02_NUM_CERTIFICADO, ARQUIVOS_SAIDA.LD01.LD01_NRCERTIF);

            /*" -2859- MOVE SOR-NUM-PARCELA TO LD02-NUM-PARCELA LD01-NRPARCEL. */
            _.Move(REG_SVA0140B.SOR_NUM_PARCELA, ARQUIVOS_SAIDA.LD02.LD02_NUM_PARCELA, ARQUIVOS_SAIDA.LD01.LD01_NRPARCEL);

            /*" -2862- MOVE SOR-NUM-TITULO TO LD02-NUM-TITULO LD01-NRTIT. */
            _.Move(REG_SVA0140B.SOR_NUM_TITULO, ARQUIVOS_SAIDA.LD02.LD02_NUM_TITULO, ARQUIVOS_SAIDA.LD01.LD01_NRTIT);

            /*" -2865- MOVE SOR-OCORR-HISTORICO TO LD02-OCORR-HISTORICO LD01-OCORHIST1. */
            _.Move(REG_SVA0140B.SOR_OCORR_HISTORICO, ARQUIVOS_SAIDA.LD02.LD02_OCORR_HISTORICO, ARQUIVOS_SAIDA.LD01.LD01_OCORHIST1);

            /*" -2869- MOVE SOR-NUM-APOLICE TO LD02-NUM-APOLICE LD02-APOLICE LD01-NUMAPOL. */
            _.Move(REG_SVA0140B.SOR_NUM_APOLICE, ARQUIVOS_SAIDA.LD02.LD02_NUM_APOLICE, ARQUIVOS_SAIDA.LD02.LD02_APOLICE, ARQUIVOS_SAIDA.LD01.LD01_NUMAPOL);

            /*" -2871- MOVE ZEROS TO LD02-ENDOSSO. */
            _.Move(0, ARQUIVOS_SAIDA.LD02.LD02_ENDOSSO);

            /*" -2875- MOVE SOR-COD-SUBGRUPO TO LD02-COD-SUBGRUPO LD02-SUBGRUPO LD01-CODSUBES. */
            _.Move(REG_SVA0140B.SOR_COD_SUBGRUPO, ARQUIVOS_SAIDA.LD02.LD02_COD_SUBGRUPO, ARQUIVOS_SAIDA.LD02.LD02_SUBGRUPO, ARQUIVOS_SAIDA.LD01.LD01_CODSUBES);

            /*" -2879- MOVE SOR-COD-FONTE TO LD02-COD-FONTE LD02-FONTE LD01-FONTE. */
            _.Move(REG_SVA0140B.SOR_COD_FONTE, ARQUIVOS_SAIDA.LD02.LD02_COD_FONTE, ARQUIVOS_SAIDA.LD02.LD02_FONTE, ARQUIVOS_SAIDA.LD01.LD01_FONTE);

            /*" -2882- MOVE SOR-ORGAO TO LD02-ORGAO LD01-ORGAO. */
            _.Move(REG_SVA0140B.SOR_ORGAO, ARQUIVOS_SAIDA.LD02.LD02_ORGAO, ARQUIVOS_SAIDA.LD01.LD01_ORGAO);

            /*" -2886- MOVE SOR-RAMO TO LD02-RAMO LD02-RAMO-EMISSOR LD01-RAMO. */
            _.Move(REG_SVA0140B.SOR_RAMO, ARQUIVOS_SAIDA.LD02.LD02_RAMO, ARQUIVOS_SAIDA.LD02.LD02_RAMO_EMISSOR, ARQUIVOS_SAIDA.LD01.LD01_RAMO);

            /*" -2889- MOVE SOR-MODALIDA TO LD02-MODALIDA LD01-MODALI. */
            _.Move(REG_SVA0140B.SOR_MODALIDA, ARQUIVOS_SAIDA.LD02.LD02_MODALIDA, ARQUIVOS_SAIDA.LD01.LD01_MODALI);

            /*" -2892- MOVE SOR-PREMIO-VG TO LD02-PREMIO-VG LD01-PRMVG. */
            _.Move(REG_SVA0140B.SOR_PREMIO_VG, ARQUIVOS_SAIDA.LD02.LD02_PREMIO_VG, ARQUIVOS_SAIDA.LD01.LD01_PRMVG);

            /*" -2895- MOVE SOR-PREMIO-AP TO LD02-PREMIO-AP LD01-PRMAP. */
            _.Move(REG_SVA0140B.SOR_PREMIO_AP, ARQUIVOS_SAIDA.LD02.LD02_PREMIO_AP, ARQUIVOS_SAIDA.LD01.LD01_PRMAP);

            /*" -2898- MOVE SOR-DATA-MOVIMENTO TO LD02-DATA-MOVIMENTO LD01-DTMOVTO. */
            _.Move(REG_SVA0140B.SOR_DATA_MOVIMENTO, ARQUIVOS_SAIDA.LD02.LD02_DATA_MOVIMENTO, ARQUIVOS_SAIDA.LD01.LD01_DTMOVTO);

            /*" -2900- MOVE SOR-SIT-REGISTRO TO LD02-SIT-REGISTRO. */
            _.Move(REG_SVA0140B.SOR_SIT_REGISTRO, ARQUIVOS_SAIDA.LD02.LD02_SIT_REGISTRO);

            /*" -2903- MOVE SOR-COD-OPERACAO TO LD02-COD-OPERACAO LD01-OPERACAO. */
            _.Move(REG_SVA0140B.SOR_COD_OPERACAO, ARQUIVOS_SAIDA.LD02.LD02_COD_OPERACAO, ARQUIVOS_SAIDA.LD01.LD01_OPERACAO);

            /*" -2905- MOVE SOR-COD-PRODUTO TO LD02-COD-PRODUTO. */
            _.Move(REG_SVA0140B.SOR_COD_PRODUTO, ARQUIVOS_SAIDA.LD02.LD02_COD_PRODUTO);

            /*" -2908- MOVE SOR-DATA-QUITACAO TO LD02-DATA-QUITACAO LD01-DTQITBCO. */
            _.Move(REG_SVA0140B.SOR_DATA_QUITACAO, ARQUIVOS_SAIDA.LD02.LD02_DATA_QUITACAO, ARQUIVOS_SAIDA.LD01.LD01_DTQITBCO);

            /*" -2911- MOVE SOR-SITUACAO TO LD02-SITUACAO LD01-SIT-CERTIF. */
            _.Move(REG_SVA0140B.SOR_SITUACAO, ARQUIVOS_SAIDA.LD02.LD02_SITUACAO, ARQUIVOS_SAIDA.LD01.LD01_SIT_CERTIF);

            /*" -2914- MOVE SOR-OCORHIST TO LD02-OCORHIST LD01-OCORHIST2, */
            _.Move(REG_SVA0140B.SOR_OCORHIST, ARQUIVOS_SAIDA.LD02.LD02_OCORHIST, ARQUIVOS_SAIDA.LD01.LD01_OCORHIST2);

            /*" -2917- MOVE SOR-DTPROXVEN TO LD02-DTPROXVEN LD01-DTPROXVEN. */
            _.Move(REG_SVA0140B.SOR_DTPROXVEN, ARQUIVOS_SAIDA.LD02.LD02_DTPROXVEN, ARQUIVOS_SAIDA.LD01.LD01_DTPROXVEN);

            /*" -2920- MOVE SOR-CLIENTE TO LD02-CLIENTE LD01-CLIENTE. */
            _.Move(REG_SVA0140B.SOR_CLIENTE, ARQUIVOS_SAIDA.LD02.LD02_CLIENTE, ARQUIVOS_SAIDA.LD01.LD01_CLIENTE);

            /*" -2923- MOVE SOR-CGCCPF TO LD02-CGCCPF LD01-CGCCPF. */
            _.Move(REG_SVA0140B.SOR_CGCCPF, ARQUIVOS_SAIDA.LD02.LD02_CGCCPF, ARQUIVOS_SAIDA.LD01.LD01_CGCCPF);

            /*" -2926- MOVE SOR-DATA-NASCIMENTO TO LD02-DATA-NASCIMENTO LD01-DTNASC. */
            _.Move(REG_SVA0140B.SOR_DATA_NASCIMENTO, ARQUIVOS_SAIDA.LD02.LD02_DATA_NASCIMENTO, ARQUIVOS_SAIDA.LD01.LD01_DTNASC);

            /*" -2929- MOVE SOR-TIPO-PESSOA TO LD02-TIPO-PESSOA LD01-TPPESSOA. */
            _.Move(REG_SVA0140B.SOR_TIPO_PESSOA, ARQUIVOS_SAIDA.LD02.LD02_TIPO_PESSOA, ARQUIVOS_SAIDA.LD01.LD01_TPPESSOA);

            /*" -2932- MOVE SOR-PRODUTO TO LD02-PRODUTO LD01-CODPRODU. */
            _.Move(REG_SVA0140B.SOR_PRODUTO, ARQUIVOS_SAIDA.LD02.LD02_PRODUTO, ARQUIVOS_SAIDA.LD01.LD01_CODPRODU);

            /*" -2935- MOVE SOR-PRODEMIS TO LD02-PRODEMIS LD01-PRODEMI. */
            _.Move(REG_SVA0140B.SOR_PRODEMIS, ARQUIVOS_SAIDA.LD02.LD02_PRODEMIS, ARQUIVOS_SAIDA.LD01.LD01_PRODEMI);

            /*" -2938- MOVE SOR-DTINIEMI TO LD02-DTINIEMI LD01-DTINIEMI. */
            _.Move(REG_SVA0140B.SOR_DTINIEMI, ARQUIVOS_SAIDA.LD02.LD02_DTINIEMI, ARQUIVOS_SAIDA.LD01.LD01_DTINIEMI);

            /*" -2941- MOVE SOR-DTTEREMI TO LD02-DTTEREMI LD01-DTTEREMI. */
            _.Move(REG_SVA0140B.SOR_DTTEREMI, ARQUIVOS_SAIDA.LD02.LD02_DTTEREMI, ARQUIVOS_SAIDA.LD01.LD01_DTTEREMI);

            /*" -2944- MOVE SOR-ESTR-COBR TO LD02-ESTR-COBR LD01-ESTR-COBR. */
            _.Move(REG_SVA0140B.SOR_ESTR_COBR, ARQUIVOS_SAIDA.LD02.LD02_ESTR_COBR, ARQUIVOS_SAIDA.LD01.LD01_ESTR_COBR);

            /*" -2947- MOVE SOR-ORIG-PRODU TO LD02-ORIG-PRODU LD01-ORIG-PRODU. */
            _.Move(REG_SVA0140B.SOR_ORIG_PRODU, ARQUIVOS_SAIDA.LD02.LD02_ORIG_PRODU, ARQUIVOS_SAIDA.LD01.LD01_ORIG_PRODU);

            /*" -2950- MOVE SOR-IND-IOF TO LD02-IND-IOF LD01-IOF. */
            _.Move(REG_SVA0140B.SOR_IND_IOF, ARQUIVOS_SAIDA.LD02.LD02_IND_IOF, ARQUIVOS_SAIDA.LD01.LD01_IOF);

            /*" -2952- MOVE SOR-PER-IOF TO LD02-PER-IOF. */
            _.Move(REG_SVA0140B.SOR_PER_IOF, ARQUIVOS_SAIDA.LD02.LD02_PER_IOF);

            /*" -2955- MOVE SOR-DATA-VENCIMENTO TO LD02-DATA-VENCIMENTO LD01-DTVENCTO. */
            _.Move(REG_SVA0140B.SOR_DATA_VENCIMENTO, ARQUIVOS_SAIDA.LD02.LD02_DATA_VENCIMENTO, ARQUIVOS_SAIDA.LD01.LD01_DTVENCTO);

            /*" -2958- MOVE SOR-DATA-INIVIGENCIA TO LD02-DATA-INIVIGENCIA LD01-DTINIVIG. */
            _.Move(REG_SVA0140B.SOR_DATA_INIVIGENCIA, ARQUIVOS_SAIDA.LD02.LD02_DATA_INIVIGENCIA, ARQUIVOS_SAIDA.LD01.LD01_DTINIVIG);

            /*" -2961- MOVE SOR-DATA-TERVIGENCIA TO LD02-DATA-TERVIGENCIA LD01-DTTERVIG. */
            _.Move(REG_SVA0140B.SOR_DATA_TERVIGENCIA, ARQUIVOS_SAIDA.LD02.LD02_DATA_TERVIGENCIA, ARQUIVOS_SAIDA.LD01.LD01_DTTERVIG);

            /*" -2964- MOVE SOR-OPCAO-PAGAMENTO TO LD02-OPCAO-PAGAMENTO LD01-OPCAO. */
            _.Move(REG_SVA0140B.SOR_OPCAO_PAGAMENTO, ARQUIVOS_SAIDA.LD02.LD02_OPCAO_PAGAMENTO, ARQUIVOS_SAIDA.LD01.LD01_OPCAO);

            /*" -2967- MOVE SOR-PERI-PAGAMENTO TO LD02-PERI-PAGAMENTO LD01-PERI. */
            _.Move(REG_SVA0140B.SOR_PERI_PAGAMENTO, ARQUIVOS_SAIDA.LD02.LD02_PERI_PAGAMENTO, ARQUIVOS_SAIDA.LD01.LD01_PERI);

            /*" -2970- MOVE SOR-DIA-DEBITO TO LD02-DIA-DEBITO LD01-DIA-DEBITO. */
            _.Move(REG_SVA0140B.SOR_DIA_DEBITO, ARQUIVOS_SAIDA.LD02.LD02_DIA_DEBITO, ARQUIVOS_SAIDA.LD01.LD01_DIA_DEBITO);

            /*" -2973- MOVE SOR-RCAPS TO LD02-RCAPS LD01-RCAPS. */
            _.Move(REG_SVA0140B.SOR_RCAPS, ARQUIVOS_SAIDA.LD02.LD02_RCAPS, ARQUIVOS_SAIDA.LD01.LD01_RCAPS);

            /*" -2976- MOVE SOR-SITRCAP TO LD02-SITRCAP LD01-SITRCAP. */
            _.Move(REG_SVA0140B.SOR_SITRCAP, ARQUIVOS_SAIDA.LD02.LD02_SITRCAP, ARQUIVOS_SAIDA.LD01.LD01_SITRCAP);

            /*" -2979- MOVE SOR-OPERCAP TO LD02-OPERCAP LD01-OPERCAP. */
            _.Move(REG_SVA0140B.SOR_OPERCAP, ARQUIVOS_SAIDA.LD02.LD02_OPERCAP, ARQUIVOS_SAIDA.LD01.LD01_OPERCAP);

            /*" -2982- MOVE SOR-VAL-RCAP TO LD02-VAL-RCAP LD01-VAL-RCAP. */
            _.Move(REG_SVA0140B.SOR_VAL_RCAP, ARQUIVOS_SAIDA.LD02.LD02_VAL_RCAP, ARQUIVOS_SAIDA.LD01.LD01_VAL_RCAP);

            /*" -2984- MOVE SOR-NRRCAP TO LD02-NRRCAP. */
            _.Move(REG_SVA0140B.SOR_NRRCAP, ARQUIVOS_SAIDA.LD02.LD02_NRRCAP);

            /*" -2986- MOVE SOR-DATA-RCAP TO LD02-DATA-RCAP. */
            _.Move(REG_SVA0140B.SOR_DATA_RCAP, ARQUIVOS_SAIDA.LD02.LD02_DATA_RCAP);

            /*" -2989- MOVE SOR-MOVIMCOB TO LD02-MOVIMCOB LD01-MOVIMCOB. */
            _.Move(REG_SVA0140B.SOR_MOVIMCOB, ARQUIVOS_SAIDA.LD02.LD02_MOVIMCOB, ARQUIVOS_SAIDA.LD01.LD01_MOVIMCOB);

            /*" -2992- MOVE SOR-SITMCOB TO LD02-SITMCOB LD01-SITMCOB. */
            _.Move(REG_SVA0140B.SOR_SITMCOB, ARQUIVOS_SAIDA.LD02.LD02_SITMCOB, ARQUIVOS_SAIDA.LD01.LD01_SITMCOB);

            /*" -2995- MOVE SOR-VAL-TITULO TO LD02-VAL-TITULO LD01-VAL-TITULO. */
            _.Move(REG_SVA0140B.SOR_VAL_TITULO, ARQUIVOS_SAIDA.LD02.LD02_VAL_TITULO, ARQUIVOS_SAIDA.LD01.LD01_VAL_TITULO);

            /*" -2998- MOVE SOR-SITMDEB TO LD02-SITMDEB LD01-SITMDEB. */
            _.Move(REG_SVA0140B.SOR_SITMDEB, ARQUIVOS_SAIDA.LD02.LD02_SITMDEB, ARQUIVOS_SAIDA.LD01.LD01_SITMDEB);

            /*" -3001- MOVE SOR-MOVDEBCE TO LD02-MOVDEBCE LD01-MOVDEBCE. */
            _.Move(REG_SVA0140B.SOR_MOVDEBCE, ARQUIVOS_SAIDA.LD02.LD02_MOVDEBCE, ARQUIVOS_SAIDA.LD01.LD01_MOVDEBCE);

            /*" -3004- MOVE SOR-CONVENIO TO LD02-CONVENIO LD01-CONVENIO. */
            _.Move(REG_SVA0140B.SOR_CONVENIO, ARQUIVOS_SAIDA.LD02.LD02_CONVENIO, ARQUIVOS_SAIDA.LD01.LD01_CONVENIO);

            /*" -3007- MOVE SOR-VALOR-DEBITO TO LD02-VALOR-DEBITO LD01-VALOR-DEBITO. */
            _.Move(REG_SVA0140B.SOR_VALOR_DEBITO, ARQUIVOS_SAIDA.LD02.LD02_VALOR_DEBITO, ARQUIVOS_SAIDA.LD01.LD01_VALOR_DEBITO);

            /*" -3010- MOVE SOR-VALVGAP TO LD02-VALVGAP LD01-VALVGAP. */
            _.Move(REG_SVA0140B.SOR_VALVGAP, ARQUIVOS_SAIDA.LD02.LD02_VALVGAP, ARQUIVOS_SAIDA.LD01.LD01_VALVGAP);

            /*" -3012- MOVE SOR-ITEM TO LD02-ITEM. */
            _.Move(REG_SVA0140B.SOR_ITEM, ARQUIVOS_SAIDA.LD02.LD02_ITEM);

            /*" -3015- MOVE SOR-DTINIVIG TO LD02-DTINIVIG LD01-DTINICIO. */
            _.Move(REG_SVA0140B.SOR_DTINIVIG, ARQUIVOS_SAIDA.LD02.LD02_DTINIVIG, ARQUIVOS_SAIDA.LD01.LD01_DTINICIO);

            /*" -3018- MOVE SOR-DATA-ADMISSAO TO LD02-DATA-ADMISSAO LD01-DTADMISSAO. */
            _.Move(REG_SVA0140B.SOR_DATA_ADMISSAO, ARQUIVOS_SAIDA.LD02.LD02_DATA_ADMISSAO, ARQUIVOS_SAIDA.LD01.LD01_DTADMISSAO);

            /*" -3021- MOVE SOR-ADICIEA TO LD02-ADICIEA LD01-ADICIEA. */
            _.Move(REG_SVA0140B.SOR_ADICIEA, ARQUIVOS_SAIDA.LD02.LD02_ADICIEA, ARQUIVOS_SAIDA.LD01.LD01_ADICIEA);

            /*" -3024- MOVE SOR-ADICIPA TO LD02-ADICIPA LD01-ADICIPA. */
            _.Move(REG_SVA0140B.SOR_ADICIPA, ARQUIVOS_SAIDA.LD02.LD02_ADICIPA, ARQUIVOS_SAIDA.LD01.LD01_ADICIPA);

            /*" -3027- MOVE SOR-ADICIPD TO LD02-ADICIPD LD01-ADICIPD. */
            _.Move(REG_SVA0140B.SOR_ADICIPD, ARQUIVOS_SAIDA.LD02.LD02_ADICIPD, ARQUIVOS_SAIDA.LD01.LD01_ADICIPD);

            /*" -3030- MOVE SOR-INIZERO TO LD02-INIZERO LD01-INIENDZERO. */
            _.Move(REG_SVA0140B.SOR_INIZERO, ARQUIVOS_SAIDA.LD02.LD02_INIZERO, ARQUIVOS_SAIDA.LD01.LD01_INIENDZERO);

            /*" -3033- MOVE SOR-TERZERO TO LD02-TERZERO LD01-TERENDZERO. */
            _.Move(REG_SVA0140B.SOR_TERZERO, ARQUIVOS_SAIDA.LD02.LD02_TERZERO, ARQUIVOS_SAIDA.LD01.LD01_TERENDZERO);

            /*" -3036- MOVE SOR-BCOAVISO TO LD02-BCOAVISO LD01-BCOAVISO. */
            _.Move(REG_SVA0140B.SOR_BCOAVISO, ARQUIVOS_SAIDA.LD02.LD02_BCOAVISO, ARQUIVOS_SAIDA.LD01.LD01_BCOAVISO);

            /*" -3039- MOVE SOR-AGEAVISO TO LD02-AGEAVISO LD01-AGEAVISO. */
            _.Move(REG_SVA0140B.SOR_AGEAVISO, ARQUIVOS_SAIDA.LD02.LD02_AGEAVISO, ARQUIVOS_SAIDA.LD01.LD01_AGEAVISO);

            /*" -3042- MOVE SOR-NRAVISO TO LD02-NRAVISO LD01-NRAVISO. */
            _.Move(REG_SVA0140B.SOR_NRAVISO, ARQUIVOS_SAIDA.LD02.LD02_NRAVISO, ARQUIVOS_SAIDA.LD01.LD01_NRAVISO);

            /*" -3045- MOVE SOR-IMPMORNATU TO LD02-IMPMORNATU LD01-IMPMORNATU. */
            _.Move(REG_SVA0140B.SOR_IMPMORNATU, ARQUIVOS_SAIDA.LD02.LD02_IMPMORNATU, ARQUIVOS_SAIDA.LD01.LD01_IMPMORNATU);

            /*" -3048- MOVE SOR-IMPMORACID TO LD02-IMPMORACID LD01-IMPMORACID. */
            _.Move(REG_SVA0140B.SOR_IMPMORACID, ARQUIVOS_SAIDA.LD02.LD02_IMPMORACID, ARQUIVOS_SAIDA.LD01.LD01_IMPMORACID);

            /*" -3051- MOVE SOR-IMPINVPERM TO LD02-IMPINVPERM LD01-IMPINVPERM. */
            _.Move(REG_SVA0140B.SOR_IMPINVPERM, ARQUIVOS_SAIDA.LD02.LD02_IMPINVPERM, ARQUIVOS_SAIDA.LD01.LD01_IMPINVPERM);

            /*" -3054- MOVE SOR-IMPAMDS TO LD02-IMPAMDS LD01-IMPAMDS. */
            _.Move(REG_SVA0140B.SOR_IMPAMDS, ARQUIVOS_SAIDA.LD02.LD02_IMPAMDS, ARQUIVOS_SAIDA.LD01.LD01_IMPAMDS);

            /*" -3057- MOVE SOR-IMPDH TO LD02-IMPDH LD01-IMPDH. */
            _.Move(REG_SVA0140B.SOR_IMPDH, ARQUIVOS_SAIDA.LD02.LD02_IMPDH, ARQUIVOS_SAIDA.LD01.LD01_IMPDH);

            /*" -3060- MOVE SOR-IMPDIT TO LD02-IMPDIT LD01-IMPDIT. */
            _.Move(REG_SVA0140B.SOR_IMPDIT, ARQUIVOS_SAIDA.LD02.LD02_IMPDIT, ARQUIVOS_SAIDA.LD01.LD01_IMPDIT);

            /*" -3062- MOVE SOR-VLPREMIO TO LD02-VLPREMIO. */
            _.Move(REG_SVA0140B.SOR_VLPREMIO, ARQUIVOS_SAIDA.LD02.LD02_VLPREMIO);

            /*" -3065- MOVE SOR-PRMDIT TO LD02-PRMDIT LD01-PRMDIT. */
            _.Move(REG_SVA0140B.SOR_PRMDIT, ARQUIVOS_SAIDA.LD02.LD02_PRMDIT, ARQUIVOS_SAIDA.LD01.LD01_PRMDIT);

            /*" -3069- MOVE SOR-SALDO TO LD02-SALDO. */
            _.Move(REG_SVA0140B.SOR_SALDO, ARQUIVOS_SAIDA.LD02.LD02_SALDO);

            /*" -3072- MOVE ZEROS TO LD02-IMPRTO LD02-PRMRTO. */
            _.Move(0, ARQUIVOS_SAIDA.LD02.LD02_IMPRTO, ARQUIVOS_SAIDA.LD02.LD02_PRMRTO);

            /*" -3073- IF SOR-ESTR-COBR EQUAL 'FEDERAL' */

            if (REG_SVA0140B.SOR_ESTR_COBR == "FEDERAL")
            {

                /*" -3075- COMPUTE LD02-IMPRTO ROUNDED EQUAL LD02-IMPMORNATU * 0,2 */
                ARQUIVOS_SAIDA.LD02.LD02_IMPRTO.Value = ARQUIVOS_SAIDA.LD02.LD02_IMPMORNATU * 0.2;

                /*" -3076- COMPUTE LD02-PRMRTO ROUNDED EQUAL (LD02-IMPRTO * 0,0058) / 1000. */
                ARQUIVOS_SAIDA.LD02.LD02_PRMRTO.Value = (ARQUIVOS_SAIDA.LD02.LD02_IMPRTO * 0.0058) / 1000f;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0610-00-SELECT-HISCONPA-SECTION */
        private void R0610_00_SELECT_HISCONPA_SECTION()
        {
            /*" -3089- MOVE '0610' TO WNR-EXEC-SQL. */
            _.Move("0610", W.WABEND.WNR_EXEC_SQL);

            /*" -3090- MOVE 'S' TO AC-FATURA. */
            _.Move("S", W.AC_FATURA);

            /*" -3092- MOVE SOR-NUM-CERTIFICADO TO HISCONPA-NUM-CERTIFICADO. */
            _.Move(REG_SVA0140B.SOR_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -3094- MOVE SOR-NUM-PARCELA TO HISCONPA-NUM-PARCELA. */
            _.Move(REG_SVA0140B.SOR_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -3101- MOVE SOR-COD-OPERACAO TO HISCONPA-COD-OPERACAO. */
            _.Move(REG_SVA0140B.SOR_COD_OPERACAO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

            /*" -3103- IF HISCONPA-COD-OPERACAO GREATER 199 AND HISCONPA-COD-OPERACAO LESS 300 */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO > 199 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO < 300)
            {

                /*" -3104- PERFORM R0620-00-SELECT-HISCONPA */

                R0620_00_SELECT_HISCONPA_SECTION();

                /*" -3110- GO TO R0610-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3112- IF HISCONPA-COD-OPERACAO LESS 500 AND HISCONPA-COD-OPERACAO GREATER 599 */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO < 500 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO > 599)
            {

                /*" -3115- GO TO R0610-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3125- PERFORM R0610_00_SELECT_HISCONPA_DB_SELECT_1 */

            R0610_00_SELECT_HISCONPA_DB_SELECT_1();

            /*" -3129- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3130- MOVE 'N' TO AC-FATURA */
                _.Move("N", W.AC_FATURA);

                /*" -3131- ELSE */
            }
            else
            {


                /*" -3132- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -3133- MOVE 'S' TO AC-FATURA */
                    _.Move("S", W.AC_FATURA);

                    /*" -3134- ELSE */
                }
                else
                {


                    /*" -3135- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -3136- DISPLAY 'R0610-00 - PROBLEMAS SELECT  (HISCONPA)  ' */
                        _.Display($"R0610-00 - PROBLEMAS SELECT  (HISCONPA)  ");

                        /*" -3136- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R0610-00-SELECT-HISCONPA-DB-SELECT-1 */
        public void R0610_00_SELECT_HISCONPA_DB_SELECT_1()
        {
            /*" -3125- EXEC SQL SELECT NUM_ENDOSSO INTO :HISCONPA-NUM-ENDOSSO FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA AND COD_OPERACAO BETWEEN 200 AND 299 AND NUM_ENDOSSO > 0 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0610_00_SELECT_HISCONPA_DB_SELECT_1_Query1 = new R0610_00_SELECT_HISCONPA_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0610_00_SELECT_HISCONPA_DB_SELECT_1_Query1.Execute(r0610_00_SELECT_HISCONPA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCONPA_NUM_ENDOSSO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/

        [StopWatch]
        /*" R0620-00-SELECT-HISCONPA-SECTION */
        private void R0620_00_SELECT_HISCONPA_SECTION()
        {
            /*" -3149- MOVE '0620' TO WNR-EXEC-SQL. */
            _.Move("0620", W.WABEND.WNR_EXEC_SQL);

            /*" -3158- PERFORM R0620_00_SELECT_HISCONPA_DB_SELECT_1 */

            R0620_00_SELECT_HISCONPA_DB_SELECT_1();

            /*" -3162- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3163- MOVE 'S' TO AC-FATURA */
                _.Move("S", W.AC_FATURA);

                /*" -3164- ELSE */
            }
            else
            {


                /*" -3165- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -3166- MOVE 'N' TO AC-FATURA */
                    _.Move("N", W.AC_FATURA);

                    /*" -3167- ELSE */
                }
                else
                {


                    /*" -3168- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -3169- DISPLAY 'R0620-00 - PROBLEMAS SELECT  (HISCONPA)  ' */
                        _.Display($"R0620-00 - PROBLEMAS SELECT  (HISCONPA)  ");

                        /*" -3169- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R0620-00-SELECT-HISCONPA-DB-SELECT-1 */
        public void R0620_00_SELECT_HISCONPA_DB_SELECT_1()
        {
            /*" -3158- EXEC SQL SELECT NUM_ENDOSSO INTO :HISCONPA-NUM-ENDOSSO FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA AND COD_OPERACAO BETWEEN 500 AND 599 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0620_00_SELECT_HISCONPA_DB_SELECT_1_Query1 = new R0620_00_SELECT_HISCONPA_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0620_00_SELECT_HISCONPA_DB_SELECT_1_Query1.Execute(r0620_00_SELECT_HISCONPA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCONPA_NUM_ENDOSSO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_99_SAIDA*/

        [StopWatch]
        /*" R0630-00-SELECT-HISCONPA-SECTION */
        private void R0630_00_SELECT_HISCONPA_SECTION()
        {
            /*" -3182- MOVE '0630' TO WNR-EXEC-SQL. */
            _.Move("0630", W.WABEND.WNR_EXEC_SQL);

            /*" -3184- MOVE SOR-NUM-CERTIFICADO TO HISCONPA-NUM-CERTIFICADO. */
            _.Move(REG_SVA0140B.SOR_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -3188- MOVE SOR-NUM-PARCELA TO HISCONPA-NUM-PARCELA. */
            _.Move(REG_SVA0140B.SOR_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -3215- PERFORM R0630_00_SELECT_HISCONPA_DB_SELECT_1 */

            R0630_00_SELECT_HISCONPA_DB_SELECT_1();

            /*" -3219- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3220- MOVE 'N' TO AC-FATURA */
                _.Move("N", W.AC_FATURA);

                /*" -3221- ELSE */
            }
            else
            {


                /*" -3222- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -3223- MOVE 'S' TO AC-FATURA */
                    _.Move("S", W.AC_FATURA);

                    /*" -3225- MOVE ENDOSSOS-NUM-APOLICE TO LD02-APOLICE */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, ARQUIVOS_SAIDA.LD02.LD02_APOLICE);

                    /*" -3227- MOVE ENDOSSOS-NUM-ENDOSSO TO LD02-ENDOSSO */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, ARQUIVOS_SAIDA.LD02.LD02_ENDOSSO);

                    /*" -3229- MOVE ENDOSSOS-RAMO-EMISSOR TO LD02-RAMO-EMISSOR */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR, ARQUIVOS_SAIDA.LD02.LD02_RAMO_EMISSOR);

                    /*" -3231- MOVE ENDOSSOS-COD-SUBGRUPO TO LD02-SUBGRUPO */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO, ARQUIVOS_SAIDA.LD02.LD02_SUBGRUPO);

                    /*" -3233- MOVE ENDOSSOS-COD-FONTE TO LD02-FONTE */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, ARQUIVOS_SAIDA.LD02.LD02_FONTE);

                    /*" -3237- MOVE ENDOSSOS-COD-PRODUTO TO SOR-PRODEMIS LD01-PRODEMI LD02-PRODEMIS */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, REG_SVA0140B.SOR_PRODEMIS, ARQUIVOS_SAIDA.LD01.LD01_PRODEMI, ARQUIVOS_SAIDA.LD02.LD02_PRODEMIS);

                    /*" -3241- MOVE ENDOSSOS-DATA-INIVIGENCIA TO SOR-DTINIEMI LD01-DTINIEMI LD02-DTINIEMI */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, REG_SVA0140B.SOR_DTINIEMI, ARQUIVOS_SAIDA.LD01.LD01_DTINIEMI, ARQUIVOS_SAIDA.LD02.LD02_DTINIEMI);

                    /*" -3245- MOVE ENDOSSOS-DATA-TERVIGENCIA TO SOR-DTTEREMI LD01-DTTEREMI LD02-DTTEREMI */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, REG_SVA0140B.SOR_DTTEREMI, ARQUIVOS_SAIDA.LD01.LD01_DTTEREMI, ARQUIVOS_SAIDA.LD02.LD02_DTTEREMI);

                    /*" -3246- ELSE */
                }
                else
                {


                    /*" -3247- DISPLAY 'R0630-00 - PROBLEMAS SELECT  (HISCONPA)  ' */
                    _.Display($"R0630-00 - PROBLEMAS SELECT  (HISCONPA)  ");

                    /*" -3247- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0630-00-SELECT-HISCONPA-DB-SELECT-1 */
        public void R0630_00_SELECT_HISCONPA_DB_SELECT_1()
        {
            /*" -3215- EXEC SQL SELECT B.NUM_APOLICE ,B.NUM_ENDOSSO ,B.RAMO_EMISSOR ,B.COD_PRODUTO ,B.COD_SUBGRUPO ,B.COD_FONTE ,B.DATA_INIVIGENCIA ,B.DATA_TERVIGENCIA INTO :ENDOSSOS-NUM-APOLICE ,:ENDOSSOS-NUM-ENDOSSO ,:ENDOSSOS-RAMO-EMISSOR ,:ENDOSSOS-COD-PRODUTO ,:ENDOSSOS-COD-SUBGRUPO ,:ENDOSSOS-COD-FONTE ,:ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.HIST_CONT_PARCELVA A ,SEGUROS.ENDOSSOS B WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND A.NUM_PARCELA = :HISCONPA-NUM-PARCELA AND A.NUM_ENDOSSO <> 0 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.TIPO_ENDOSSO = '1' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1 = new R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1.Execute(r0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(executed_1.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_COD_SUBGRUPO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO);
                _.Move(executed_1.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0630_99_SAIDA*/

        [StopWatch]
        /*" R0640-00-SELECT-HISCONPA-SECTION */
        private void R0640_00_SELECT_HISCONPA_SECTION()
        {
            /*" -3260- MOVE '0640' TO WNR-EXEC-SQL. */
            _.Move("0640", W.WABEND.WNR_EXEC_SQL);

            /*" -3262- MOVE SOR-NUM-CERTIFICADO TO HISCONPA-NUM-CERTIFICADO. */
            _.Move(REG_SVA0140B.SOR_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -3264- MOVE SOR-NUM-PARCELA TO HISCONPA-NUM-PARCELA. */
            _.Move(REG_SVA0140B.SOR_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -3267- MOVE SOR-PERI-PAGAMENTO TO WHOST-PERI. */
            _.Move(REG_SVA0140B.SOR_PERI_PAGAMENTO, WHOST_PERI);

            /*" -3268- IF WHOST-PERI EQUAL ZEROS */

            if (WHOST_PERI == 00)
            {

                /*" -3271- MOVE 36 TO WHOST-PERI. */
                _.Move(36, WHOST_PERI);
            }


            /*" -3307- PERFORM R0640_00_SELECT_HISCONPA_DB_SELECT_1 */

            R0640_00_SELECT_HISCONPA_DB_SELECT_1();

            /*" -3311- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3313- MOVE SOR-DATA-VENCIMENTO TO CALENDAR-DATA-CALENDARIO */
                _.Move(REG_SVA0140B.SOR_DATA_VENCIMENTO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

                /*" -3314- PERFORM R0650-00-SELECT-CALENDAR */

                R0650_00_SELECT_CALENDAR_SECTION();

                /*" -3315- ELSE */
            }
            else
            {


                /*" -3316- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -3317- MOVE 'S' TO AC-FATURA */
                    _.Move("S", W.AC_FATURA);

                    /*" -3319- MOVE ENDOSSOS-NUM-APOLICE TO LD02-APOLICE */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, ARQUIVOS_SAIDA.LD02.LD02_APOLICE);

                    /*" -3321- MOVE ENDOSSOS-NUM-ENDOSSO TO LD02-ENDOSSO */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, ARQUIVOS_SAIDA.LD02.LD02_ENDOSSO);

                    /*" -3323- MOVE ENDOSSOS-RAMO-EMISSOR TO LD02-RAMO-EMISSOR */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR, ARQUIVOS_SAIDA.LD02.LD02_RAMO_EMISSOR);

                    /*" -3325- MOVE ENDOSSOS-COD-SUBGRUPO TO LD02-SUBGRUPO */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO, ARQUIVOS_SAIDA.LD02.LD02_SUBGRUPO);

                    /*" -3327- MOVE ENDOSSOS-COD-FONTE TO LD02-FONTE */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, ARQUIVOS_SAIDA.LD02.LD02_FONTE);

                    /*" -3331- MOVE ENDOSSOS-DATA-INIVIGENCIA TO SOR-DTINIEMI LD01-DTINIEMI LD02-DTINIEMI */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, REG_SVA0140B.SOR_DTINIEMI, ARQUIVOS_SAIDA.LD01.LD01_DTINIEMI, ARQUIVOS_SAIDA.LD02.LD02_DTINIEMI);

                    /*" -3335- MOVE ENDOSSOS-DATA-TERVIGENCIA TO SOR-DTTEREMI LD01-DTTEREMI LD02-DTTEREMI */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, REG_SVA0140B.SOR_DTTEREMI, ARQUIVOS_SAIDA.LD01.LD01_DTTEREMI, ARQUIVOS_SAIDA.LD02.LD02_DTTEREMI);

                    /*" -3336- ELSE */
                }
                else
                {


                    /*" -3337- DISPLAY 'R0640-00 - PROBLEMAS SELECT  (HISCONPA)  ' */
                    _.Display($"R0640-00 - PROBLEMAS SELECT  (HISCONPA)  ");

                    /*" -3339- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3341- IF (SQLCODE EQUAL ZEROS) AND (LD02-COD-SUBGRUPO NOT EQUAL LD02-SUBGRUPO) */

            if ((DB.SQLCODE == 00) && (ARQUIVOS_SAIDA.LD02.LD02_COD_SUBGRUPO != ARQUIVOS_SAIDA.LD02.LD02_SUBGRUPO))
            {

                /*" -3341- MOVE LD02-COD-SUBGRUPO TO LD02-SUBGRUPO. */
                _.Move(ARQUIVOS_SAIDA.LD02.LD02_COD_SUBGRUPO, ARQUIVOS_SAIDA.LD02.LD02_SUBGRUPO);
            }


        }

        [StopWatch]
        /*" R0640-00-SELECT-HISCONPA-DB-SELECT-1 */
        public void R0640_00_SELECT_HISCONPA_DB_SELECT_1()
        {
            /*" -3307- EXEC SQL SELECT B.NUM_APOLICE ,B.NUM_ENDOSSO ,B.RAMO_EMISSOR ,B.COD_PRODUTO ,B.COD_SUBGRUPO ,B.COD_FONTE ,B.DATA_TERVIGENCIA + 1 DAYS ,B.DATA_TERVIGENCIA + :WHOST-PERI MONTHS ,B.DATA_INIVIGENCIA ,B.DATA_TERVIGENCIA ,A.DTFATUR ,A.NUM_PARCELA INTO :ENDOSSOS-NUM-APOLICE ,:ENDOSSOS-NUM-ENDOSSO ,:ENDOSSOS-RAMO-EMISSOR ,:ENDOSSOS-COD-PRODUTO ,:ENDOSSOS-COD-SUBGRUPO ,:ENDOSSOS-COD-FONTE ,:ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA ,:WHOST-DATA-INIVIGENCIA ,:WHOST-DATA-TERVIGENCIA ,:HISCONPA-DTFATUR ,:HISCONPA-NUM-PARCELA FROM SEGUROS.HIST_CONT_PARCELVA A ,SEGUROS.ENDOSSOS B WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND A.NUM_PARCELA < :HISCONPA-NUM-PARCELA AND A.NUM_ENDOSSO <> 0 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.TIPO_ENDOSSO = '1' ORDER BY A.NUM_PARCELA DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1 = new R0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
                WHOST_PERI = WHOST_PERI.ToString(),
            };

            var executed_1 = R0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1.Execute(r0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(executed_1.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_COD_SUBGRUPO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO);
                _.Move(executed_1.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(executed_1.WHOST_DATA_INIVIGENCIA, WHOST_DATA_INIVIGENCIA);
                _.Move(executed_1.WHOST_DATA_TERVIGENCIA, WHOST_DATA_TERVIGENCIA);
                _.Move(executed_1.HISCONPA_DTFATUR, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR);
                _.Move(executed_1.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0640_99_SAIDA*/

        [StopWatch]
        /*" R0650-00-SELECT-CALENDAR-SECTION */
        private void R0650_00_SELECT_CALENDAR_SECTION()
        {
            /*" -3354- MOVE '0650' TO WNR-EXEC-SQL. */
            _.Move("0650", W.WABEND.WNR_EXEC_SQL);

            /*" -3363- PERFORM R0650_00_SELECT_CALENDAR_DB_SELECT_1 */

            R0650_00_SELECT_CALENDAR_DB_SELECT_1();

            /*" -3367- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3368- MOVE 'N' TO AC-FATURA */
                _.Move("N", W.AC_FATURA);

                /*" -3371- GO TO R0650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3372- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3374- DISPLAY 'R0650-00 - PROBLEMAS NO SELECT(CALENDAR)' ' DATA        = ' CALENDAR-DATA-CALENDARIO */

                $"R0650-00 - PROBLEMAS NO SELECT(CALENDAR) DATA        = {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}"
                .Display();

                /*" -3377- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3379- MOVE CALENDAR-DATA-CALENDARIO TO WDATA-REL. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, W.WDATA_REL);

            /*" -3380- MOVE 01 TO WDAT-REL-DIA. */
            _.Move(01, W.FILLER_1.WDAT_REL_DIA);

            /*" -3383- MOVE WDATA-REL TO SOR-DTINIEMI LD01-DTINIEMI LD02-DTINIEMI. */
            _.Move(W.WDATA_REL, REG_SVA0140B.SOR_DTINIEMI, ARQUIVOS_SAIDA.LD01.LD01_DTINIEMI, ARQUIVOS_SAIDA.LD02.LD02_DTINIEMI);

            /*" -3388- MOVE CALENDAR-DTH-ULT-DIA-MES TO SOR-DTTEREMI LD01-DTTEREMI LD02-DTTEREMI. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES, REG_SVA0140B.SOR_DTTEREMI, ARQUIVOS_SAIDA.LD01.LD01_DTTEREMI, ARQUIVOS_SAIDA.LD02.LD02_DTTEREMI);

            /*" -3389- MOVE 'S' TO AC-FATURA. */
            _.Move("S", W.AC_FATURA);

            /*" -3391- MOVE SOR-NUM-APOLICE TO LD02-APOLICE. */
            _.Move(REG_SVA0140B.SOR_NUM_APOLICE, ARQUIVOS_SAIDA.LD02.LD02_APOLICE);

            /*" -3393- MOVE ZEROS TO LD02-ENDOSSO. */
            _.Move(0, ARQUIVOS_SAIDA.LD02.LD02_ENDOSSO);

            /*" -3395- MOVE SOR-RAMO TO LD02-RAMO-EMISSOR. */
            _.Move(REG_SVA0140B.SOR_RAMO, ARQUIVOS_SAIDA.LD02.LD02_RAMO_EMISSOR);

            /*" -3397- MOVE SOR-COD-SUBGRUPO TO LD02-SUBGRUPO. */
            _.Move(REG_SVA0140B.SOR_COD_SUBGRUPO, ARQUIVOS_SAIDA.LD02.LD02_SUBGRUPO);

            /*" -3398- MOVE SOR-COD-FONTE TO LD02-FONTE. */
            _.Move(REG_SVA0140B.SOR_COD_FONTE, ARQUIVOS_SAIDA.LD02.LD02_FONTE);

        }

        [StopWatch]
        /*" R0650-00-SELECT-CALENDAR-DB-SELECT-1 */
        public void R0650_00_SELECT_CALENDAR_DB_SELECT_1()
        {
            /*" -3363- EXEC SQL SELECT DATA_CALENDARIO ,DTH_ULT_DIA_MES INTO :CALENDAR-DATA-CALENDARIO ,:CALENDAR-DTH-ULT-DIA-MES FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0650_00_SELECT_CALENDAR_DB_SELECT_1_Query1 = new R0650_00_SELECT_CALENDAR_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R0650_00_SELECT_CALENDAR_DB_SELECT_1_Query1.Execute(r0650_00_SELECT_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.CALENDAR_DTH_ULT_DIA_MES, CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/

        [StopWatch]
        /*" R0670-00-VER-VIGENCIA-SECTION */
        private void R0670_00_VER_VIGENCIA_SECTION()
        {
            /*" -3411- MOVE '0670' TO WNR-EXEC-SQL. */
            _.Move("0670", W.WABEND.WNR_EXEC_SQL);

            /*" -3414- MOVE SOR-DTINIEMI TO WHOST-DTINI01. */
            _.Move(REG_SVA0140B.SOR_DTINIEMI, WHOST_DTINI01);

            /*" -3416- PERFORM R0680-00-SELECT-CALENDAR. */

            R0680_00_SELECT_CALENDAR_SECTION();

            /*" -3417- IF CALENDAR-DATA-CALENDARIO NOT EQUAL SPACES */

            if (!CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.IsEmpty())
            {

                /*" -3423- MOVE CALENDAR-DATA-CALENDARIO TO SOR-DTINIEMI LD01-DTINIEMI LD02-DTINIEMI. */
                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, REG_SVA0140B.SOR_DTINIEMI, ARQUIVOS_SAIDA.LD01.LD01_DTINIEMI, ARQUIVOS_SAIDA.LD02.LD02_DTINIEMI);
            }


            /*" -3426- MOVE SOR-DTTEREMI TO WHOST-DTINI01. */
            _.Move(REG_SVA0140B.SOR_DTTEREMI, WHOST_DTINI01);

            /*" -3428- PERFORM R0680-00-SELECT-CALENDAR. */

            R0680_00_SELECT_CALENDAR_SECTION();

            /*" -3429- IF CALENDAR-DATA-CALENDARIO NOT EQUAL SPACES */

            if (!CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.IsEmpty())
            {

                /*" -3432- MOVE CALENDAR-DATA-CALENDARIO TO SOR-DTTEREMI LD01-DTTEREMI LD02-DTTEREMI. */
                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, REG_SVA0140B.SOR_DTTEREMI, ARQUIVOS_SAIDA.LD01.LD01_DTTEREMI, ARQUIVOS_SAIDA.LD02.LD02_DTTEREMI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0670_99_SAIDA*/

        [StopWatch]
        /*" R0680-00-SELECT-CALENDAR-SECTION */
        private void R0680_00_SELECT_CALENDAR_SECTION()
        {
            /*" -3445- MOVE '0680' TO WNR-EXEC-SQL. */
            _.Move("0680", W.WABEND.WNR_EXEC_SQL);

            /*" -3452- PERFORM R0680_00_SELECT_CALENDAR_DB_SELECT_1 */

            R0680_00_SELECT_CALENDAR_DB_SELECT_1();

            /*" -3456- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3458- MOVE SPACES TO CALENDAR-DATA-CALENDARIO */
                _.Move("", CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

                /*" -3459- ELSE */
            }
            else
            {


                /*" -3460- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3462- DISPLAY 'R0680-00 - PROBLEMAS NO SELECT(CALENDAR)' ' DATA        = ' WHOST-DTINI01 */

                    $"R0680-00 - PROBLEMAS NO SELECT(CALENDAR) DATA        = {WHOST_DTINI01}"
                    .Display();

                    /*" -3462- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0680-00-SELECT-CALENDAR-DB-SELECT-1 */
        public void R0680_00_SELECT_CALENDAR_DB_SELECT_1()
        {
            /*" -3452- EXEC SQL SELECT DATA_CALENDARIO - 1 MONTHS INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :WHOST-DTINI01 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0680_00_SELECT_CALENDAR_DB_SELECT_1_Query1 = new R0680_00_SELECT_CALENDAR_DB_SELECT_1_Query1()
            {
                WHOST_DTINI01 = WHOST_DTINI01.ToString(),
            };

            var executed_1 = R0680_00_SELECT_CALENDAR_DB_SELECT_1_Query1.Execute(r0680_00_SELECT_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0680_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROCESSA-REGISTRO-SECTION */
        private void R0700_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -3475- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", W.WABEND.WNR_EXEC_SQL);

            /*" -3481- MOVE ZEROS TO LD02-PARVG082 LD02-VALVG082 LD02-APOLICOB LD02-OCOVG082. */
            _.Move(0, ARQUIVOS_SAIDA.LD02.LD02_PARVG082, ARQUIVOS_SAIDA.LD02.LD02_VALVG082, ARQUIVOS_SAIDA.LD02.LD02_APOLICOB, ARQUIVOS_SAIDA.LD02.LD02_OCOVG082);

            /*" -3484- PERFORM R0760-00-SELECT-VG082. */

            R0760_00_SELECT_VG082_SECTION();

            /*" -3485- IF LD02-ENDOSSO NOT EQUAL ZEROS */

            if (ARQUIVOS_SAIDA.LD02.LD02_ENDOSSO != 00)
            {

                /*" -3488- PERFORM R0770-00-SELECT-APOLICOB. */

                R0770_00_SELECT_APOLICOB_SECTION();
            }


            /*" -3489- WRITE REG-VA0140B2 FROM LD02 */
            _.Move(ARQUIVOS_SAIDA.LD02.GetMoveValues(), REG_VA0140B2);

            SAIDA02.Write(REG_VA0140B2.GetMoveValues().ToString());

            /*" -3489- ADD 1 TO AC-GRAVA02. */
            W.AC_GRAVA02.Value = W.AC_GRAVA02 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0760-00-SELECT-VG082-SECTION */
        private void R0760_00_SELECT_VG082_SECTION()
        {
            /*" -3502- MOVE '0760' TO WNR-EXEC-SQL. */
            _.Move("0760", W.WABEND.WNR_EXEC_SQL);

            /*" -3504- MOVE SOR-NUM-CERTIFICADO TO VG082-NUM-CERTIFICADO. */
            _.Move(REG_SVA0140B.SOR_NUM_CERTIFICADO, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_CERTIFICADO);

            /*" -3506- MOVE SOR-NUM-PARCELA TO VG082-NUM-PARCELA. */
            _.Move(REG_SVA0140B.SOR_NUM_PARCELA, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_PARCELA);

            /*" -3508- MOVE SOR-NUM-TITULO TO VG082-NUM-TITULO. */
            _.Move(REG_SVA0140B.SOR_NUM_TITULO, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_TITULO);

            /*" -3512- MOVE SOR-OCORR-HISTORICO TO VG082-OCORR-HISTORICO. */
            _.Move(REG_SVA0140B.SOR_OCORR_HISTORICO, VG082.DCLVG_HIST_CONT_COBER.VG082_OCORR_HISTORICO);

            /*" -3524- PERFORM R0760_00_SELECT_VG082_DB_SELECT_1 */

            R0760_00_SELECT_VG082_DB_SELECT_1();

            /*" -3528- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3529- PERFORM R0765-00-SELECT-VG082 */

                R0765_00_SELECT_VG082_SECTION();

                /*" -3530- ELSE */
            }
            else
            {


                /*" -3531- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3536- DISPLAY 'R0760-00 - PROBLEMAS NO SELECT(VG082)' ' CERTIFICADO = ' VG082-NUM-CERTIFICADO ' PARCELA     = ' VG082-NUM-PARCELA ' TITULO      = ' VG082-NUM-TITULO ' OCORRHIST   = ' VG082-OCORR-HISTORICO */

                    $"R0760-00 - PROBLEMAS NO SELECT(VG082) CERTIFICADO = {VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_CERTIFICADO} PARCELA     = {VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_PARCELA} TITULO      = {VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_TITULO} OCORRHIST   = {VG082.DCLVG_HIST_CONT_COBER.VG082_OCORR_HISTORICO}"
                    .Display();

                    /*" -3537- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3538- ELSE */
                }
                else
                {


                    /*" -3540- IF VIND-COUNT LESS ZEROS OR VIND-VALOR LESS ZEROS */

                    if (VIND_COUNT < 00 || VIND_VALOR < 00)
                    {

                        /*" -3541- PERFORM R0765-00-SELECT-VG082 */

                        R0765_00_SELECT_VG082_SECTION();

                        /*" -3542- ELSE */
                    }
                    else
                    {


                        /*" -3543- MOVE WHOST-COUNT TO LD02-PARVG082 */
                        _.Move(WHOST_COUNT, ARQUIVOS_SAIDA.LD02.LD02_PARVG082);

                        /*" -3545- MOVE SOR-OCORR-HISTORICO TO LD02-OCOVG082 */
                        _.Move(REG_SVA0140B.SOR_OCORR_HISTORICO, ARQUIVOS_SAIDA.LD02.LD02_OCOVG082);

                        /*" -3546- MOVE VG082-VLR-PREMIO-RAMO TO LD02-VALVG082. */
                        _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO, ARQUIVOS_SAIDA.LD02.LD02_VALVG082);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0760-00-SELECT-VG082-DB-SELECT-1 */
        public void R0760_00_SELECT_VG082_DB_SELECT_1()
        {
            /*" -3524- EXEC SQL SELECT COUNT(*) ,SUM(VLR_PREMIO_RAMO) INTO :WHOST-COUNT:VIND-COUNT ,:VG082-VLR-PREMIO-RAMO:VIND-VALOR FROM SEGUROS.VG_HIST_CONT_COBER WHERE NUM_CERTIFICADO = :VG082-NUM-CERTIFICADO AND NUM_PARCELA = :VG082-NUM-PARCELA AND NUM_TITULO = :VG082-NUM-TITULO AND OCORR_HISTORICO = :VG082-OCORR-HISTORICO AND VLR_PREMIO_RAMO > 0 WITH UR END-EXEC. */

            var r0760_00_SELECT_VG082_DB_SELECT_1_Query1 = new R0760_00_SELECT_VG082_DB_SELECT_1_Query1()
            {
                VG082_NUM_CERTIFICADO = VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_CERTIFICADO.ToString(),
                VG082_OCORR_HISTORICO = VG082.DCLVG_HIST_CONT_COBER.VG082_OCORR_HISTORICO.ToString(),
                VG082_NUM_PARCELA = VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_PARCELA.ToString(),
                VG082_NUM_TITULO = VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_TITULO.ToString(),
            };

            var executed_1 = R0760_00_SELECT_VG082_DB_SELECT_1_Query1.Execute(r0760_00_SELECT_VG082_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
                _.Move(executed_1.VIND_COUNT, VIND_COUNT);
                _.Move(executed_1.VG082_VLR_PREMIO_RAMO, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);
                _.Move(executed_1.VIND_VALOR, VIND_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0760_99_SAIDA*/

        [StopWatch]
        /*" R0765-00-SELECT-VG082-SECTION */
        private void R0765_00_SELECT_VG082_SECTION()
        {
            /*" -3559- MOVE '0765' TO WNR-EXEC-SQL. */
            _.Move("0765", W.WABEND.WNR_EXEC_SQL);

            /*" -3561- MOVE SOR-NUM-CERTIFICADO TO VG082-NUM-CERTIFICADO. */
            _.Move(REG_SVA0140B.SOR_NUM_CERTIFICADO, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_CERTIFICADO);

            /*" -3563- MOVE SOR-NUM-PARCELA TO VG082-NUM-PARCELA. */
            _.Move(REG_SVA0140B.SOR_NUM_PARCELA, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_PARCELA);

            /*" -3565- MOVE SOR-NUM-TITULO TO VG082-NUM-TITULO. */
            _.Move(REG_SVA0140B.SOR_NUM_TITULO, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_TITULO);

            /*" -3569- MOVE 1 TO VG082-OCORR-HISTORICO. */
            _.Move(1, VG082.DCLVG_HIST_CONT_COBER.VG082_OCORR_HISTORICO);

            /*" -3581- PERFORM R0765_00_SELECT_VG082_DB_SELECT_1 */

            R0765_00_SELECT_VG082_DB_SELECT_1();

            /*" -3585- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3588- MOVE ZEROS TO LD02-PARVG082 LD02-VALVG082 LD02-OCOVG082 */
                _.Move(0, ARQUIVOS_SAIDA.LD02.LD02_PARVG082, ARQUIVOS_SAIDA.LD02.LD02_VALVG082, ARQUIVOS_SAIDA.LD02.LD02_OCOVG082);

                /*" -3591- GO TO R0765-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0765_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3592- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3597- DISPLAY 'R0765-00 - PROBLEMAS NO SELECT(VG082)' ' CERTIFICADO = ' VG082-NUM-CERTIFICADO ' PARCELA     = ' VG082-NUM-PARCELA ' TITULO      = ' VG082-NUM-TITULO ' OCORRHIST   = ' VG082-OCORR-HISTORICO */

                $"R0765-00 - PROBLEMAS NO SELECT(VG082) CERTIFICADO = {VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_CERTIFICADO} PARCELA     = {VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_PARCELA} TITULO      = {VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_TITULO} OCORRHIST   = {VG082.DCLVG_HIST_CONT_COBER.VG082_OCORR_HISTORICO}"
                .Display();

                /*" -3600- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3601- IF VIND-COUNT LESS ZEROS */

            if (VIND_COUNT < 00)
            {

                /*" -3602- MOVE ZEROS TO LD02-PARVG082 */
                _.Move(0, ARQUIVOS_SAIDA.LD02.LD02_PARVG082);

                /*" -3603- ELSE */
            }
            else
            {


                /*" -3605- MOVE WHOST-COUNT TO LD02-PARVG082. */
                _.Move(WHOST_COUNT, ARQUIVOS_SAIDA.LD02.LD02_PARVG082);
            }


            /*" -3606- IF VIND-VALOR LESS ZEROS */

            if (VIND_VALOR < 00)
            {

                /*" -3607- MOVE ZEROS TO LD02-VALVG082 */
                _.Move(0, ARQUIVOS_SAIDA.LD02.LD02_VALVG082);

                /*" -3608- ELSE */
            }
            else
            {


                /*" -3610- MOVE 1 TO LD02-OCOVG082 */
                _.Move(1, ARQUIVOS_SAIDA.LD02.LD02_OCOVG082);

                /*" -3611- MOVE VG082-VLR-PREMIO-RAMO TO LD02-VALVG082. */
                _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO, ARQUIVOS_SAIDA.LD02.LD02_VALVG082);
            }


        }

        [StopWatch]
        /*" R0765-00-SELECT-VG082-DB-SELECT-1 */
        public void R0765_00_SELECT_VG082_DB_SELECT_1()
        {
            /*" -3581- EXEC SQL SELECT COUNT(*) ,SUM(VLR_PREMIO_RAMO) INTO :WHOST-COUNT:VIND-COUNT ,:VG082-VLR-PREMIO-RAMO:VIND-VALOR FROM SEGUROS.VG_HIST_CONT_COBER WHERE NUM_CERTIFICADO = :VG082-NUM-CERTIFICADO AND NUM_PARCELA = :VG082-NUM-PARCELA AND NUM_TITULO = :VG082-NUM-TITULO AND OCORR_HISTORICO = :VG082-OCORR-HISTORICO AND VLR_PREMIO_RAMO > 0 WITH UR END-EXEC. */

            var r0765_00_SELECT_VG082_DB_SELECT_1_Query1 = new R0765_00_SELECT_VG082_DB_SELECT_1_Query1()
            {
                VG082_NUM_CERTIFICADO = VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_CERTIFICADO.ToString(),
                VG082_OCORR_HISTORICO = VG082.DCLVG_HIST_CONT_COBER.VG082_OCORR_HISTORICO.ToString(),
                VG082_NUM_PARCELA = VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_PARCELA.ToString(),
                VG082_NUM_TITULO = VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_TITULO.ToString(),
            };

            var executed_1 = R0765_00_SELECT_VG082_DB_SELECT_1_Query1.Execute(r0765_00_SELECT_VG082_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
                _.Move(executed_1.VIND_COUNT, VIND_COUNT);
                _.Move(executed_1.VG082_VLR_PREMIO_RAMO, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);
                _.Move(executed_1.VIND_VALOR, VIND_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0765_99_SAIDA*/

        [StopWatch]
        /*" R0770-00-SELECT-APOLICOB-SECTION */
        private void R0770_00_SELECT_APOLICOB_SECTION()
        {
            /*" -3624- MOVE '0770' TO WNR-EXEC-SQL. */
            _.Move("0770", W.WABEND.WNR_EXEC_SQL);

            /*" -3626- MOVE LD02-APOLICE TO APOLICOB-NUM-APOLICE. */
            _.Move(ARQUIVOS_SAIDA.LD02.LD02_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);

            /*" -3630- MOVE LD02-ENDOSSO TO APOLICOB-NUM-ENDOSSO. */
            _.Move(ARQUIVOS_SAIDA.LD02.LD02_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);

            /*" -3639- PERFORM R0770_00_SELECT_APOLICOB_DB_SELECT_1 */

            R0770_00_SELECT_APOLICOB_DB_SELECT_1();

            /*" -3643- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3644- MOVE ZEROS TO LD02-APOLICOB */
                _.Move(0, ARQUIVOS_SAIDA.LD02.LD02_APOLICOB);

                /*" -3645- ELSE */
            }
            else
            {


                /*" -3646- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3649- DISPLAY 'R0770-00 - PROBLEMAS NO SELECT(APOLICOB)' ' APOLICE     = ' APOLICOB-NUM-APOLICE ' ENDOSSO     = ' APOLICOB-NUM-ENDOSSO */

                    $"R0770-00 - PROBLEMAS NO SELECT(APOLICOB) APOLICE     = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE} ENDOSSO     = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}"
                    .Display();

                    /*" -3650- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3651- ELSE */
                }
                else
                {


                    /*" -3652- IF VIND-COUNT LESS ZEROS */

                    if (VIND_COUNT < 00)
                    {

                        /*" -3653- MOVE ZEROS TO LD02-APOLICOB */
                        _.Move(0, ARQUIVOS_SAIDA.LD02.LD02_APOLICOB);

                        /*" -3654- ELSE */
                    }
                    else
                    {


                        /*" -3654- MOVE WHOST-COUNT TO LD02-APOLICOB. */
                        _.Move(WHOST_COUNT, ARQUIVOS_SAIDA.LD02.LD02_APOLICOB);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0770-00-SELECT-APOLICOB-DB-SELECT-1 */
        public void R0770_00_SELECT_APOLICOB_DB_SELECT_1()
        {
            /*" -3639- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT:VIND-COUNT FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :APOLICOB-NUM-APOLICE AND NUM_ENDOSSO = :APOLICOB-NUM-ENDOSSO AND NUM_ITEM = 0 AND COD_COBERTURA = 0 WITH UR END-EXEC. */

            var r0770_00_SELECT_APOLICOB_DB_SELECT_1_Query1 = new R0770_00_SELECT_APOLICOB_DB_SELECT_1_Query1()
            {
                APOLICOB_NUM_APOLICE = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.ToString(),
                APOLICOB_NUM_ENDOSSO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0770_00_SELECT_APOLICOB_DB_SELECT_1_Query1.Execute(r0770_00_SELECT_APOLICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
                _.Move(executed_1.VIND_COUNT, VIND_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0770_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-MONTA-RCAP-SECTION */
        private void R1300_00_MONTA_RCAP_SECTION()
        {
            /*" -3667- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", W.WABEND.WNR_EXEC_SQL);

            /*" -3669- PERFORM R1320-00-SELECT-RCAPS. */

            R1320_00_SELECT_RCAPS_SECTION();

            /*" -3670- IF WTEM-RCAPS EQUAL 'N' */

            if (W.WTEM_RCAPS == "N")
            {

                /*" -3671- MOVE 'N' TO WTEM-RCAPS */
                _.Move("N", W.WTEM_RCAPS);

                /*" -3677- GO TO R1300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3680- MOVE ' ADESAO NAO INTEGRADA - CONTABILIZADA' TO LD01-OBSERVA */
            _.Move(" ADESAO NAO INTEGRADA - CONTABILIZADA", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

            /*" -3683- PERFORM R4000-00-UPDATE-HISCONPA. */

            R4000_00_UPDATE_HISCONPA_SECTION();

            /*" -3684- IF SOR-TIPO-ENDOSSO EQUAL '1' */

            if (REG_SVA0140B.SOR_TIPO_ENDOSSO == "1")
            {

                /*" -3691- GO TO R1300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3692- ADD 1 TO UP-RCAPS. */
            W.UP_RCAPS.Value = W.UP_RCAPS + 1;

            /*" -3694- MOVE '1' TO RCAPS-SIT-REGISTRO. */
            _.Move("1", RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);

            /*" -3698- MOVE 210 TO RCAPS-COD-OPERACAO. */
            _.Move(210, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);

            /*" -3704- PERFORM R1330-00-UPDATE-RCAP. */

            R1330_00_UPDATE_RCAP_SECTION();

            /*" -3710- PERFORM R1340-00-UPDATE-RCAPCOMP. */

            R1340_00_UPDATE_RCAPCOMP_SECTION();

            /*" -3712- MOVE SISTEMAS-DATA-MOV-ABERTO TO RCAPCOMP-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);

            /*" -3714- MOVE '0' TO RCAPCOMP-SIT-CONTABIL. */
            _.Move("0", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL);

            /*" -3717- MOVE ZEROS TO RCAPCOMP-COD-EMPRESA. */
            _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);

            /*" -3718- MOVE ZEROS TO VIND-NULL01. */
            _.Move(0, VIND_NULL01);

            /*" -3720- MOVE 320 TO RCAPCOMP-COD-OPERACAO. */
            _.Move(320, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);

            /*" -3724- MOVE '1' TO RCAPCOMP-SIT-REGISTRO. */
            _.Move("1", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO);

            /*" -3730- PERFORM R1350-00-INSERT-RCAPCOMP. */

            R1350_00_INSERT_RCAPCOMP_SECTION();

            /*" -3732- MOVE 210 TO RCAPCOMP-COD-OPERACAO. */
            _.Move(210, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);

            /*" -3736- MOVE '0' TO RCAPCOMP-SIT-REGISTRO. */
            _.Move("0", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO);

            /*" -3736- PERFORM R1350-00-INSERT-RCAPCOMP. */

            R1350_00_INSERT_RCAPCOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1320-00-SELECT-RCAPS-SECTION */
        private void R1320_00_SELECT_RCAPS_SECTION()
        {
            /*" -3749- MOVE '1320' TO WNR-EXEC-SQL. */
            _.Move("1320", W.WABEND.WNR_EXEC_SQL);

            /*" -3753- MOVE SOR-NUM-TITULO TO RCAPS-NUM-TITULO. */
            _.Move(REG_SVA0140B.SOR_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -3789- PERFORM R1320_00_SELECT_RCAPS_DB_SELECT_1 */

            R1320_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -3793- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3794- MOVE 'N' TO WTEM-RCAPS */
                _.Move("N", W.WTEM_RCAPS);

                /*" -3796- GO TO R1320-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1320_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3797- IF SQLCODE EQUAL -811 */

            if (DB.SQLCODE == -811)
            {

                /*" -3798- MOVE 'N' TO WTEM-RCAPS */
                _.Move("N", W.WTEM_RCAPS);

                /*" -3800- GO TO R1320-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1320_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3801- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3802- DISPLAY 'R1320-00 - PROBLEMAS NO SELECT(RCAPS)   ' */
                _.Display($"R1320-00 - PROBLEMAS NO SELECT(RCAPS)   ");

                /*" -3803- DISPLAY ' TITULO    =      ' RCAPS-NUM-TITULO */
                _.Display($" TITULO    =      {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                /*" -3805- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3806- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -3810- MOVE ZEROS TO RCAPCOMP-COD-EMPRESA. */
                _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);
            }


            /*" -3811- IF RCAPS-COD-OPERACAO EQUAL 210 */

            if (RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO == 210)
            {

                /*" -3812- MOVE 'N' TO WTEM-RCAPS */
                _.Move("N", W.WTEM_RCAPS);

                /*" -3813- ELSE */
            }
            else
            {


                /*" -3815- IF RCAPS-COD-OPERACAO EQUAL 200 OR 220 */

                if (RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO.In("200", "220"))
                {

                    /*" -3816- MOVE 'S' TO WTEM-RCAPS */
                    _.Move("S", W.WTEM_RCAPS);

                    /*" -3817- ELSE */
                }
                else
                {


                    /*" -3817- MOVE 'N' TO WTEM-RCAPS. */
                    _.Move("N", W.WTEM_RCAPS);
                }

            }


        }

        [StopWatch]
        /*" R1320-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R1320_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -3789- EXEC SQL SELECT A.SIT_REGISTRO ,A.COD_OPERACAO ,B.COD_FONTE ,B.NUM_RCAP ,B.NUM_RCAP_COMPLEMEN ,B.COD_OPERACAO ,B.BCO_AVISO ,B.AGE_AVISO ,B.NUM_AVISO_CREDITO ,B.VAL_RCAP ,B.DATA_RCAP ,B.DATA_CADASTRAMENTO ,B.SIT_CONTABIL ,B.COD_EMPRESA INTO :RCAPS-SIT-REGISTRO ,:RCAPS-COD-OPERACAO ,:RCAPCOMP-COD-FONTE ,:RCAPCOMP-NUM-RCAP ,:RCAPCOMP-NUM-RCAP-COMPLEMEN ,:RCAPCOMP-COD-OPERACAO ,:RCAPCOMP-BCO-AVISO ,:RCAPCOMP-AGE-AVISO ,:RCAPCOMP-NUM-AVISO-CREDITO ,:RCAPCOMP-VAL-RCAP ,:RCAPCOMP-DATA-RCAP ,:RCAPCOMP-DATA-CADASTRAMENTO ,:RCAPCOMP-SIT-CONTABIL ,:RCAPCOMP-COD-EMPRESA:VIND-NULL01 FROM SEGUROS.RCAPS A ,SEGUROS.RCAP_COMPLEMENTAR B WHERE A.NUM_TITULO = :RCAPS-NUM-TITULO AND B.NUM_RCAP = A.NUM_RCAP AND B.COD_FONTE = A.COD_FONTE AND B.SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var r1320_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R1320_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = R1320_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r1320_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPCOMP_COD_FONTE, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE);
                _.Move(executed_1.RCAPCOMP_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);
                _.Move(executed_1.RCAPCOMP_NUM_RCAP_COMPLEMEN, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN);
                _.Move(executed_1.RCAPCOMP_COD_OPERACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(executed_1.RCAPCOMP_DATA_CADASTRAMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPCOMP_SIT_CONTABIL, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL);
                _.Move(executed_1.RCAPCOMP_COD_EMPRESA, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1320_99_SAIDA*/

        [StopWatch]
        /*" R1330-00-UPDATE-RCAP-SECTION */
        private void R1330_00_UPDATE_RCAP_SECTION()
        {
            /*" -3830- MOVE '1330' TO WNR-EXEC-SQL. */
            _.Move("1330", W.WABEND.WNR_EXEC_SQL);

            /*" -3835- PERFORM R1330_00_UPDATE_RCAP_DB_UPDATE_1 */

            R1330_00_UPDATE_RCAP_DB_UPDATE_1();

            /*" -3838- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3839- DISPLAY 'R1330-00 - PROBLEMAS UPDATE (RCAPS)   ' */
                _.Display($"R1330-00 - PROBLEMAS UPDATE (RCAPS)   ");

                /*" -3840- DISPLAY ' TITULO    =      ' RCAPS-NUM-TITULO */
                _.Display($" TITULO    =      {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                /*" -3840- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1330-00-UPDATE-RCAP-DB-UPDATE-1 */
        public void R1330_00_UPDATE_RCAP_DB_UPDATE_1()
        {
            /*" -3835- EXEC SQL UPDATE SEGUROS.RCAPS SET SIT_REGISTRO = :RCAPS-SIT-REGISTRO ,COD_OPERACAO = :RCAPS-COD-OPERACAO WHERE NUM_RCAP = :RCAPCOMP-NUM-RCAP END-EXEC. */

            var r1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1 = new R1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1()
            {
                RCAPS_SIT_REGISTRO = RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO.ToString(),
                RCAPS_COD_OPERACAO = RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
            };

            R1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1.Execute(r1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1330_99_SAIDA*/

        [StopWatch]
        /*" R1340-00-UPDATE-RCAPCOMP-SECTION */
        private void R1340_00_UPDATE_RCAPCOMP_SECTION()
        {
            /*" -3853- MOVE '1340' TO WNR-EXEC-SQL. */
            _.Move("1340", W.WABEND.WNR_EXEC_SQL);

            /*" -3857- PERFORM R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1 */

            R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1();

            /*" -3860- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3861- DISPLAY 'R1340-00 - PROBLEMAS UPDATE (RCAPCOMP)' */
                _.Display($"R1340-00 - PROBLEMAS UPDATE (RCAPCOMP)");

                /*" -3862- DISPLAY ' TITULO    =      ' RCAPS-NUM-TITULO */
                _.Display($" TITULO    =      {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                /*" -3862- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1340-00-UPDATE-RCAPCOMP-DB-UPDATE-1 */
        public void R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1()
        {
            /*" -3857- EXEC SQL UPDATE SEGUROS.RCAP_COMPLEMENTAR SET SIT_REGISTRO = '1' WHERE NUM_RCAP = :RCAPCOMP-NUM-RCAP END-EXEC. */

            var r1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 = new R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1()
            {
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
            };

            R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1.Execute(r1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1340_99_SAIDA*/

        [StopWatch]
        /*" R1350-00-INSERT-RCAPCOMP-SECTION */
        private void R1350_00_INSERT_RCAPCOMP_SECTION()
        {
            /*" -3875- MOVE '1350' TO WNR-EXEC-SQL. */
            _.Move("1350", W.WABEND.WNR_EXEC_SQL);

            /*" -3910- PERFORM R1350_00_INSERT_RCAPCOMP_DB_INSERT_1 */

            R1350_00_INSERT_RCAPCOMP_DB_INSERT_1();

            /*" -3914- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3915- DISPLAY ' R1350-00 - PROBLEMAS NO INSERT(RCAPCOMP)   ' */
                _.Display($" R1350-00 - PROBLEMAS NO INSERT(RCAPCOMP)   ");

                /*" -3916- DISPLAY ' TITULO    =      ' RCAPS-NUM-TITULO */
                _.Display($" TITULO    =      {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                /*" -3916- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1350-00-INSERT-RCAPCOMP-DB-INSERT-1 */
        public void R1350_00_INSERT_RCAPCOMP_DB_INSERT_1()
        {
            /*" -3910- EXEC SQL INSERT INTO SEGUROS.RCAP_COMPLEMENTAR (COD_FONTE , NUM_RCAP , NUM_RCAP_COMPLEMEN , COD_OPERACAO , DATA_MOVIMENTO , HORA_OPERACAO , SIT_REGISTRO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , VAL_RCAP , DATA_RCAP , DATA_CADASTRAMENTO , SIT_CONTABIL , COD_EMPRESA , TIMESTAMP) VALUES (:RCAPCOMP-COD-FONTE , :RCAPCOMP-NUM-RCAP , :RCAPCOMP-NUM-RCAP-COMPLEMEN , :RCAPCOMP-COD-OPERACAO , :RCAPCOMP-DATA-MOVIMENTO , CURRENT TIME , :RCAPCOMP-SIT-REGISTRO , :RCAPCOMP-BCO-AVISO , :RCAPCOMP-AGE-AVISO , :RCAPCOMP-NUM-AVISO-CREDITO , :RCAPCOMP-VAL-RCAP , :RCAPCOMP-DATA-RCAP , :RCAPCOMP-DATA-CADASTRAMENTO , :RCAPCOMP-SIT-CONTABIL , :RCAPCOMP-COD-EMPRESA:VIND-NULL01 , CURRENT TIMESTAMP) END-EXEC. */

            var r1350_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1 = new R1350_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1()
            {
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
                RCAPCOMP_NUM_RCAP_COMPLEMEN = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN.ToString(),
                RCAPCOMP_COD_OPERACAO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO.ToString(),
                RCAPCOMP_DATA_MOVIMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.ToString(),
                RCAPCOMP_SIT_REGISTRO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_VAL_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP.ToString(),
                RCAPCOMP_DATA_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.ToString(),
                RCAPCOMP_DATA_CADASTRAMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO.ToString(),
                RCAPCOMP_SIT_CONTABIL = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL.ToString(),
                RCAPCOMP_COD_EMPRESA = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
            };

            R1350_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1.Execute(r1350_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-UPDATE-HISCONPA-SECTION */
        private void R4000_00_UPDATE_HISCONPA_SECTION()
        {
            /*" -3929- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", W.WABEND.WNR_EXEC_SQL);

            /*" -3931- MOVE SOR-NUM-CERTIFICADO TO HISCONPA-NUM-CERTIFICADO. */
            _.Move(REG_SVA0140B.SOR_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -3933- MOVE SOR-NUM-PARCELA TO HISCONPA-NUM-PARCELA. */
            _.Move(REG_SVA0140B.SOR_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -3935- MOVE SOR-NUM-TITULO TO HISCONPA-NUM-TITULO. */
            _.Move(REG_SVA0140B.SOR_NUM_TITULO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO);

            /*" -3937- MOVE SOR-OCORR-HISTORICO TO HISCONPA-OCORR-HISTORICO. */
            _.Move(REG_SVA0140B.SOR_OCORR_HISTORICO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);

            /*" -3939- MOVE SOR-COD-OPERACAO TO HISCONPA-COD-OPERACAO. */
            _.Move(REG_SVA0140B.SOR_COD_OPERACAO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

            /*" -3943- MOVE '1' TO HISCONPA-SIT-REGISTRO. */
            _.Move("1", HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO);

            /*" -3952- PERFORM R4000_00_UPDATE_HISCONPA_DB_UPDATE_1 */

            R4000_00_UPDATE_HISCONPA_DB_UPDATE_1();

            /*" -3956- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3957- DISPLAY 'R4000-00 - PROBLEMAS UPDATE (HISCONPA)' */
                _.Display($"R4000-00 - PROBLEMAS UPDATE (HISCONPA)");

                /*" -3958- DISPLAY ' NRCERTIF  =  ' HISCONPA-NUM-CERTIFICADO */
                _.Display($" NRCERTIF  =  {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -3959- DISPLAY ' PARCELA   =  ' HISCONPA-NUM-PARCELA */
                _.Display($" PARCELA   =  {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                /*" -3960- DISPLAY ' TITULO    =  ' HISCONPA-NUM-TITULO */
                _.Display($" TITULO    =  {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO}");

                /*" -3961- DISPLAY ' OCORHIST  =  ' HISCONPA-OCORR-HISTORICO */
                _.Display($" OCORHIST  =  {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO}");

                /*" -3962- DISPLAY ' OPERACAO  =  ' HISCONPA-COD-OPERACAO */
                _.Display($" OPERACAO  =  {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO}");

                /*" -3965- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3965- ADD 1 TO UP-HISCONPA. */
            W.UP_HISCONPA.Value = W.UP_HISCONPA + 1;

        }

        [StopWatch]
        /*" R4000-00-UPDATE-HISCONPA-DB-UPDATE-1 */
        public void R4000_00_UPDATE_HISCONPA_DB_UPDATE_1()
        {
            /*" -3952- EXEC SQL UPDATE SEGUROS.HIST_CONT_PARCELVA SET SIT_REGISTRO = :HISCONPA-SIT-REGISTRO WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA AND NUM_TITULO = :HISCONPA-NUM-TITULO AND OCORR_HISTORICO = :HISCONPA-OCORR-HISTORICO AND COD_OPERACAO = :HISCONPA-COD-OPERACAO END-EXEC. */

            var r4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1 = new R4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1()
            {
                HISCONPA_SIT_REGISTRO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO.ToString(),
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_OCORR_HISTORICO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO.ToString(),
                HISCONPA_COD_OPERACAO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
                HISCONPA_NUM_TITULO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO.ToString(),
            };

            R4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1.Execute(r4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3976- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -3977- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -3978- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -3979- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, W.WABEND.WSQLERRMC);

            /*" -3981- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -3981- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3986- CLOSE SAIDA01 SAIDA02. */
            SAIDA01.Close();
            SAIDA02.Close();

            /*" -3988- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -3988- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}