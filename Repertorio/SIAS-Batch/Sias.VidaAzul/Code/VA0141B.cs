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
using Sias.VidaAzul.DB2.VA0141B;

namespace Code
{
    public class VA0141B
    {
        public bool IsCall { get; set; }

        public VA0141B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDAZUL                            *      */
        /*"      *   PROGRAMA ...............  VA0141B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  05/09/2019                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   JUNCAO DOS PROGRAMAS VA0139B, VG0138B E VG0139B              *      */
        /*"      *                                                                *      */
        /*"      *   HISTORIA 208078/208877                                       *      */
        /*"      *   FUNCAO .................  A PARTIR DA LEITURA DO ARQUIVO     *      */
        /*"      *   GERADO PELO PROGRAMA VA0140B, EMITE AS FATURAS RESPECTIVAS.  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.10                                               *      */
        /*"      *  JAZZ.....: 560.871            PROGRAMADOR: TERCIO CARVALHO    *      */
        /*"      *  DATA ....: 18/12/2023                                         *      */
        /*"      *  DESCRICAO: ABEND -438 DATA_TERVIGENCIA < DATA_INIVIGENCIA.    *      */
        /*"      *                                          PROCURE POR V.10      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.09                                               *      */
        /*"      *  JAZZ.....: 471.213            PROGRAMADOR: TERCIO CARVALHO    *      */
        /*"      *  DATA ....: 14/12/2023                                         *      */
        /*"      *  DESCRICAO: TRATAMENTO ENDOSSO ZERO.                           *      */
        /*"      *                                          PROCURE POR V.09      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.08                                               *      */
        /*"      *  JAZZ.....: 471.213            PROGRAMADOR: TERCIO CARVALHO    *      */
        /*"      *  DATA ....: 11/12/2023                                         *      */
        /*"      *  DESCRICAO: TRATAMENTO SUBGRUPO ZERO.                          *      */
        /*"      *                                          PROCURE POR V.08      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.07                                               *      */
        /*"      *  JAZZ.....: 471.213            PROGRAMADOR: TERCIO CARVALHO    *      */
        /*"      *  DATA ....: 04/12/2023                                         *      */
        /*"      *  DESCRICAO: TRATAMENTO DEMAIS PARCELAS.                        *      */
        /*"      *                                          PROCURE POR V.07      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.06                                               *      */
        /*"      *  JAZZ.....: 471.213            PROGRAMADOR: TERCIO CARVALHO    *      */
        /*"      *  DATA ....: 01/12/2023                                         *      */
        /*"      *  DESCRICAO: TRATAMENTO PARCELA DE ADESAO.                      *      */
        /*"      *                                          PROCURE POR V.06      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.05                                               *      */
        /*"      *  JAZZ.....: 556.277            PROGRAMADOR: TERCIO CARVALHO    *      */
        /*"      *  DATA ....: 29/11/2023                                         *      */
        /*"      *  DESCRICAO: TRAMENTO DO ABEND -438.                            *      */
        /*"      *                                          PROCURE POR V.05      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.04                                               *      */
        /*"      *  JAZZ.....: 553.339            PROGRAMADOR: TERCIO CARVALHO    *      */
        /*"      *  DATA ....: 27/11/2023                                         *      */
        /*"      *  DESCRICAO: MONITOR PARA IDENTIFICAR OS CENARIOS QUE FALTAM    *      */
        /*"      *             PARA CORRIGIR.                                     *      */
        /*"      *                                          PROCURE POR V.04      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.03                                               *      */
        /*"      *  JAZZ.....: 553.339            PROGRAMADOR: TERCIO CARVALHO    *      */
        /*"      *  DATA ....: 21/11/2023                                         *      */
        /*"      *  DESCRICAO: TRATA ABEND SQLCODE +100 NO ACESSO A ENDOSSOS      *      */
        /*"      *             NO PARAGRAFO R2514-00.                             *      */
        /*"      *                                          PROCURE POR V.03      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.02                                               *      */
        /*"      *  JAZZ.....: 471.213            PROGRAMADOR: TERCIO CARVALHO    *      */
        /*"      *  DATA ....: 01/11/2023                                         *      */
        /*"      *  DESCRICAO: VOLTA A GERAR ENDOSSOS DE COBRANCAS MENSAIS        *      */
        /*"      *             COM INICIO E TERMINO DE VIGENCIA CORRESPONDENTES   *      */
        /*"      *             AO MES DE VENCIMENTO DA FATURA EM FUNCAO DE        *      */
        /*"      *             APONTAMENTO DE AUDITORIA.                          *      */
        /*"      *                                          PROCURE POR V.02      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.01                                               *      */
        /*"      *  JAZZ.....: 318.037            PROGRAMADOR: FRANK CARVALHO     *      */
        /*"      *  DATA ....: 16/09/2021                                         *      */
        /*"      *  DESCRICAO: ENDOSSOS GERADOS DE PAGAMENTO COM OPCAO DE PAGAMEN-*      */
        /*"      *             TO CARTAO DE CREDITO DEVE SER GERADO COM SITUACAO  *      */
        /*"      *             DE PENDENTE INDEPENDENTE DE EXISTIR NA TABELA      *      */
        /*"      *             MOVIMENTO_COBRANCA.                                *      */
        /*"      *                                          PROCURE POR V.01      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _ENTRADA1 { get; set; } = new FileBasis(new PIC("X", "1000", "X(1000)"));

        public FileBasis ENTRADA1
        {
            get
            {
                _.Move(REG_ENTRADA1, _ENTRADA1); VarBasis.RedefinePassValue(REG_ENTRADA1, _ENTRADA1, REG_ENTRADA1); return _ENTRADA1;
            }
        }
        public FileBasis _SAIDA01 { get; set; } = new FileBasis(new PIC("X", "1200", "X(1200)"));

        public FileBasis SAIDA01
        {
            get
            {
                _.Move(REG_SAIDA01, _SAIDA01); VarBasis.RedefinePassValue(REG_SAIDA01, _SAIDA01, REG_SAIDA01); return _SAIDA01;
            }
        }
        public SortBasis<VA0141B_REG_SVA0141B> SVA0141B { get; set; } = new SortBasis<VA0141B_REG_SVA0141B>(new VA0141B_REG_SVA0141B());
        /*"01         REG-SVA0141B.*/
        public VA0141B_REG_SVA0141B REG_SVA0141B { get; set; } = new VA0141B_REG_SVA0141B();
        public class VA0141B_REG_SVA0141B : VarBasis
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
            /*"  05       SOR-PRMDIT            PIC S9(013)V99.*/
            public DoubleBasis SOR_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05       SOR-IMPRTO            PIC  9(013)V99.*/
            public DoubleBasis SOR_IMPRTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05       SOR-PRMRTO            PIC  9(013)V99.*/
            public DoubleBasis SOR_PRMRTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05       SOR-APOLICE           PIC  9(013).*/
            public IntBasis SOR_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       SOR-ENDOSSO           PIC  9(009).*/
            public IntBasis SOR_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-RAMO-EMISSOR      PIC  9(009).*/
            public IntBasis SOR_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-SUBGRUPO          PIC  9(009).*/
            public IntBasis SOR_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-FONTE             PIC  9(004).*/
            public IntBasis SOR_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-PARVG082          PIC  9(009).*/
            public IntBasis SOR_PARVG082 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-VALVG082          PIC  9(013)V99.*/
            public DoubleBasis SOR_VALVG082 { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05       SOR-APOLICOB          PIC  9(009).*/
            public IntBasis SOR_APOLICOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-NRRCAP            PIC  9(009).*/
            public IntBasis SOR_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-DATA-RCAP         PIC  X(010).*/
            public StringBasis SOR_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       SOR-SALDO             PIC  9(013)V99.*/
            public DoubleBasis SOR_SALDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05       SOR-ITEM              PIC  9(009).*/
            public IntBasis SOR_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       SOR-VLPREMIO          PIC  9(013)V99.*/
            public DoubleBasis SOR_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05       SOR-NRSEQ             PIC  9(004).*/
            public IntBasis SOR_NRSEQ { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       SOR-OCOVG082          PIC  9(004).*/
            public IntBasis SOR_OCOVG082 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01        REG-ENTRADA1.*/
        }
        public VA0141B_REG_ENTRADA1 REG_ENTRADA1 { get; set; } = new VA0141B_REG_ENTRADA1();
        public class VA0141B_REG_ENTRADA1 : VarBasis
        {
            /*"    10    ENT-PROGRAMA            PIC  X(008).*/
            public StringBasis ENT_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-TIPO-ENDOSSO        PIC  X(001).*/
            public StringBasis ENT_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-NUM-CERTIFICADO     PIC  9(015).*/
            public IntBasis ENT_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-NUM-PARCELA         PIC  9(004).*/
            public IntBasis ENT_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-NUM-TITULO          PIC  9(013).*/
            public IntBasis ENT_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-OCORR-HISTORICO     PIC  9(004).*/
            public IntBasis ENT_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-NUM-APOLICE         PIC  9(013).*/
            public IntBasis ENT_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-COD-SUBGRUPO        PIC  9(009).*/
            public IntBasis ENT_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-COD-FONTE           PIC  9(004).*/
            public IntBasis ENT_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-ORGAO               PIC  9(004).*/
            public IntBasis ENT_ORGAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-RAMO                PIC  9(004).*/
            public IntBasis ENT_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-MODALIDA            PIC  9(004).*/
            public IntBasis ENT_MODALIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-PREMIO-VG           PIC  9(013)V99.*/
            public DoubleBasis ENT_PREMIO_VG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-PREMIO-AP           PIC  9(013)V99.*/
            public DoubleBasis ENT_PREMIO_AP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-DATA-MOVIMENTO      PIC  X(010).*/
            public StringBasis ENT_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-SIT-REGISTRO        PIC  X(001).*/
            public StringBasis ENT_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-COD-OPERACAO        PIC  9(004).*/
            public IntBasis ENT_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-COD-PRODUTO         PIC  9(004).*/
            public IntBasis ENT_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-DATA-QUITACAO       PIC  X(010).*/
            public StringBasis ENT_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-SITUACAO            PIC  X(001).*/
            public StringBasis ENT_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-OCORHIST            PIC  9(004).*/
            public IntBasis ENT_OCORHIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-DTPROXVEN           PIC  X(010).*/
            public StringBasis ENT_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-CLIENTE             PIC  9(009).*/
            public IntBasis ENT_CLIENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-CGCCPF              PIC  9(015).*/
            public IntBasis ENT_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-DATA-NASCIMENTO     PIC  X(010).*/
            public StringBasis ENT_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-TIPO-PESSOA         PIC  X(001).*/
            public StringBasis ENT_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-PRODUTO             PIC  9(004).*/
            public IntBasis ENT_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-PRODEMIS            PIC  9(004).*/
            public IntBasis ENT_PRODEMIS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-DTINIEMI            PIC  X(010).*/
            public StringBasis ENT_DTINIEMI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-DTTEREMI            PIC  X(010).*/
            public StringBasis ENT_DTTEREMI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-ESTR-COBR           PIC  X(010).*/
            public StringBasis ENT_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-ORIG-PRODU          PIC  X(010).*/
            public StringBasis ENT_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-IND-IOF             PIC  X(001).*/
            public StringBasis ENT_IND_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-PER-IOF             PIC  9(003)V99.*/
            public DoubleBasis ENT_PER_IOF { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-DATA-VENCIMENTO     PIC  X(010).*/
            public StringBasis ENT_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-DATA-INIVIGENCIA    PIC  X(010).*/
            public StringBasis ENT_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-DATA-TERVIGENCIA    PIC  X(010).*/
            public StringBasis ENT_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-OPCAO-PAGAMENTO     PIC  X(001).*/
            public StringBasis ENT_OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-PERI-PAGAMENTO      PIC  9(004).*/
            public IntBasis ENT_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-DIA-DEBITO          PIC  9(004).*/
            public IntBasis ENT_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-RCAPS               PIC  X(003).*/
            public StringBasis ENT_RCAPS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-SITRCAP             PIC  X(001).*/
            public StringBasis ENT_SITRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-OPERCAP             PIC  9(003).*/
            public IntBasis ENT_OPERCAP { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-VAL-RCAP            PIC  9(013)V99.*/
            public DoubleBasis ENT_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-MOVIMCOB            PIC  X(003).*/
            public StringBasis ENT_MOVIMCOB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-SITMCOB             PIC  X(001).*/
            public StringBasis ENT_SITMCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-VAL-TITULO          PIC  9(013)V99.*/
            public DoubleBasis ENT_VAL_TITULO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-SITMDEB             PIC  X(001).*/
            public StringBasis ENT_SITMDEB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-MOVDEBCE            PIC  X(003).*/
            public StringBasis ENT_MOVDEBCE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-CONVENIO            PIC  9(008).*/
            public IntBasis ENT_CONVENIO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-VALOR-DEBITO        PIC  9(013)V99.*/
            public DoubleBasis ENT_VALOR_DEBITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-VALVGAP             PIC  9(013)V99.*/
            public DoubleBasis ENT_VALVGAP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-DTINIVIG            PIC  X(010).*/
            public StringBasis ENT_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-DATA-ADMISSAO       PIC  X(010).*/
            public StringBasis ENT_DATA_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-ADICIEA             PIC  9(003)V99.*/
            public DoubleBasis ENT_ADICIEA { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-ADICIPA             PIC  9(003)V99.*/
            public DoubleBasis ENT_ADICIPA { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-ADICIPD             PIC  9(003)V99.*/
            public DoubleBasis ENT_ADICIPD { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-INIZERO             PIC  X(010).*/
            public StringBasis ENT_INIZERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-TERZERO             PIC  X(010).*/
            public StringBasis ENT_TERZERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-BCOAVISO            PIC  9(004).*/
            public IntBasis ENT_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-AGEAVISO            PIC  9(004).*/
            public IntBasis ENT_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-NRAVISO             PIC  9(009).*/
            public IntBasis ENT_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-IMPMORNATU          PIC  9(013)V99.*/
            public DoubleBasis ENT_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-IMPMORACID          PIC  9(013)V99.*/
            public DoubleBasis ENT_IMPMORACID { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-IMPINVPERM          PIC  9(013)V99.*/
            public DoubleBasis ENT_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-IMPAMDS             PIC  9(013)V99.*/
            public DoubleBasis ENT_IMPAMDS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-IMPDH               PIC  9(013)V99.*/
            public DoubleBasis ENT_IMPDH { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-IMPDIT              PIC  9(013)V99.*/
            public DoubleBasis ENT_IMPDIT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-PRMDIT              PIC  9(013)V99.*/
            public DoubleBasis ENT_PRMDIT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-IMPRTO              PIC  9(013)V99.*/
            public DoubleBasis ENT_IMPRTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-PRMRTO              PIC  9(013)V99.*/
            public DoubleBasis ENT_PRMRTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-APOLICE             PIC  9(013).*/
            public IntBasis ENT_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-ENDOSSO             PIC  9(009).*/
            public IntBasis ENT_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-RAMO-EMISSOR        PIC  9(009).*/
            public IntBasis ENT_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-SUBGRUPO            PIC  9(009).*/
            public IntBasis ENT_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-FONTE               PIC  9(004).*/
            public IntBasis ENT_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-PARVG082            PIC  9(009).*/
            public IntBasis ENT_PARVG082 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-VALVG082            PIC  9(013)V99.*/
            public DoubleBasis ENT_VALVG082 { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-APOLICOB            PIC  9(009).*/
            public IntBasis ENT_APOLICOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-NRRCAP              PIC  9(009).*/
            public IntBasis ENT_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-DATA-RCAP           PIC  X(010).*/
            public StringBasis ENT_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-SALDO               PIC  9(013)V99.*/
            public DoubleBasis ENT_SALDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-ITEM                PIC  9(009).*/
            public IntBasis ENT_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-VLPREMIO            PIC  9(013)V99.*/
            public DoubleBasis ENT_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-NRSEQ               PIC  9(004).*/
            public IntBasis ENT_NRSEQ { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    10    ENT-OCOVG082            PIC  9(004).*/
            public IntBasis ENT_OCOVG082 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10    FILLER                  PIC  X(003).*/
            public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"01         REG-SAIDA01           PIC  X(1200).*/
        }
        public StringBasis REG_SAIDA01 { get; set; } = new StringBasis(new PIC("X", "1200", "X(1200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_COB00 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_COB01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77    WHOST-NUM-ENDOSSO         PIC S9(009)         COMP.*/
        public IntBasis WHOST_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    VIND-NULL01               PIC S9(004)         COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)         COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL03               PIC S9(004)         COMP.*/
        public IntBasis VIND_NULL03 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DATARCAP             PIC S9(004)         COMP.*/
        public IntBasis VIND_DATARCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTVENCTO             PIC S9(004)         COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VLCUSEMI             PIC S9(004)         COMP.*/
        public IntBasis VIND_VLCUSEMI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CFPREFIX             PIC S9(004)         COMP.*/
        public IntBasis VIND_CFPREFIX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COD-EMPRESA          PIC S9(004)         COMP.*/
        public IntBasis VIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TIPO-CORRECAO        PIC S9(004)         COMP.*/
        public IntBasis VIND_TIPO_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ISENTA-CUSTO         PIC S9(004)         COMP.*/
        public IntBasis VIND_ISENTA_CUSTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-SITCOB               PIC S9(004)         COMP.*/
        public IntBasis VIND_SITCOB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTQITBCO             PIC S9(004)         COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-QTDPARCEL           PIC S9(004)         COMP.*/
        public IntBasis WHOST_QTDPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-NUMPARCEL           PIC S9(004)         COMP.*/
        public IntBasis WHOST_NUMPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-PERI                PIC S9(004)         COMP.*/
        public IntBasis WHOST_PERI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WS-IND-IOF                PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WS_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WS-PREMIO-LIQ             PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WS_PREMIO_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WS-PRMBASE                PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WS_PRMBASE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WS-PERCENT                PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WS_PERCENT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WS-VALOR                  PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WHOST-DATA15              PIC  X(010).*/
        public StringBasis WHOST_DATA15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DATAINI             PIC  X(010).*/
        public StringBasis WHOST_DATAINI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DATATER             PIC  X(010).*/
        public StringBasis WHOST_DATATER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WS-IND                    PIC S9(004)         COMP.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    PARCEVID-DATA-VENCIMENTO-1M  PIC  X(010).*/
        public StringBasis PARCEVID_DATA_VENCIMENTO_1M { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-DATA-VENCIMENTO        PIC  X(010).*/
        public StringBasis WHOST_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WS-ANO                    PIC S9(004)         COMP.*/
        public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WS-RESULTADO              PIC S9(004)         COMP.*/
        public IntBasis WS_RESULTADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WS-RESTO                  PIC S9(004)         COMP.*/
        public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W.*/
        public VA0141B_W W { get; set; } = new VA0141B_W();
        public class VA0141B_W : VarBasis
        {
            /*"  03  WFIM-ENTRADA1             PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_ENTRADA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-SORT                 PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-ENTRADA1               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis LD_ENTRADA1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  LD-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  GV-SORT                   PIC  9(009)         VALUE ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAVA01                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis AC_GRAVA01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAVA02                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis AC_GRAVA02 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-CONTROLE               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  TT-COBRANCA               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis TT_COBRANCA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  TT-RESTITUI               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis TT_RESTITUI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  TT-EMISSAO                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis TT_EMISSAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  TT-BAIXA                  PIC  9(009)         VALUE ZEROS.*/
            public IntBasis TT_BAIXA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  IN-ENDOSSOS               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis IN_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  IN-PARCELAS               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis IN_PARCELAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  IN-PARCEHIS               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis IN_PARCEHIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  IN-ORDEMCOS               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis IN_ORDEMCOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  IN-EMISSDIA               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis IN_EMISSDIA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  IN-APOLICOB               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis IN_APOLICOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-HISCONPA               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis UP_HISCONPA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-COBHISVI               PIC  9(009)         VALUE ZEROS.*/
            public IntBasis UP_COBHISVI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-RCAPS                  PIC  9(009)         VALUE ZEROS.*/
            public IntBasis UP_RCAPS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_VA0141B_FILLER_86 _filler_86 { get; set; }
            public _REDEF_VA0141B_FILLER_86 FILLER_86
            {
                get { _filler_86 = new _REDEF_VA0141B_FILLER_86(); _.Move(AC_LIDOS, _filler_86); VarBasis.RedefinePassValue(AC_LIDOS, _filler_86, AC_LIDOS); _filler_86.ValueChanged += () => { _.Move(_filler_86, AC_LIDOS); }; return _filler_86; }
                set { VarBasis.RedefinePassValue(value, _filler_86, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_VA0141B_FILLER_86 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_VA0141B_FILLER_86()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VA0141B_FILLER_87 _filler_87 { get; set; }
            public _REDEF_VA0141B_FILLER_87 FILLER_87
            {
                get { _filler_87 = new _REDEF_VA0141B_FILLER_87(); _.Move(WDATA_REL, _filler_87); VarBasis.RedefinePassValue(WDATA_REL, _filler_87, WDATA_REL); _filler_87.ValueChanged += () => { _.Move(_filler_87, WDATA_REL); }; return _filler_87; }
                set { VarBasis.RedefinePassValue(value, _filler_87, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VA0141B_FILLER_87 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_VA0141B_FILLER_87()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_88.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_89.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_VA0141B_FILLER_90 _filler_90 { get; set; }
            public _REDEF_VA0141B_FILLER_90 FILLER_90
            {
                get { _filler_90 = new _REDEF_VA0141B_FILLER_90(); _.Move(WTIME_DAY, _filler_90); VarBasis.RedefinePassValue(WTIME_DAY, _filler_90, WTIME_DAY); _filler_90.ValueChanged += () => { _.Move(_filler_90, WTIME_DAY); }; return _filler_90; }
                set { VarBasis.RedefinePassValue(value, _filler_90, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_VA0141B_FILLER_90 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public VA0141B_WTIME_DAYR WTIME_DAYR { get; set; } = new VA0141B_WTIME_DAYR();
                public class VA0141B_WTIME_DAYR : VarBasis
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

                    public VA0141B_WTIME_DAYR()
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

                public _REDEF_VA0141B_FILLER_90()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public VA0141B_WS_TIME WS_TIME { get; set; } = new VA0141B_WS_TIME();
            public class VA0141B_WS_TIME : VarBasis
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
            public VA0141B_WABEND WABEND { get; set; } = new VA0141B_WABEND();
            public class VA0141B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' VA0141B  '.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0141B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRMC = '.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRMC = ");
                /*"    05      WSQLERRMC           PIC  X(070) VALUE    SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01  ARQUIVOS-SAIDA.*/
            }
        }
        public VA0141B_ARQUIVOS_SAIDA ARQUIVOS_SAIDA { get; set; } = new VA0141B_ARQUIVOS_SAIDA();
        public class VA0141B_ARQUIVOS_SAIDA : VarBasis
        {
            /*"  03          LC01.*/
            public VA0141B_LC01 LC01 { get; set; } = new VA0141B_LC01();
            public class VA0141B_LC01 : VarBasis
            {
                /*"    10        FILLER              PIC  X(008)  VALUE             'PROGRAMA'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PROGRAMA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'TIPO'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"TIPO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'CERTIFICADO'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"CERTIFICADO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PARCELA'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PARCELA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(013)  VALUE             'TITULO'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"TITULO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'OCORH'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"OCORH");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(013)  VALUE             'APOLICE'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'SUBGRUPO'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SUBGRUPO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'FONTE'.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"FONTE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'ORGAO'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"ORGAO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'RAMO'.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"RAMO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(006)  VALUE             'MODALI'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"MODALI");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'PREMIO VG'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PREMIO VG");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'PREMIO AP'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PREMIO AP");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTMOVTO  '.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTMOVTO  ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'SITH'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"SITH");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'OPERA'.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"OPERA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PRODUVA'.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUVA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTQITBCO '.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTQITBCO ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'SITP'.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"SITP");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'OCORP'.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"OCORP");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTPROXVEN'.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTPROXVEN");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'CLIENTE '.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"CLIENTE ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'CGCCPF '.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"CGCCPF ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'NASCIMENTO'.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"NASCIMENTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(006)  VALUE             'TIPO'.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"TIPO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PRODUVG'.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUVG");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PRODEMI'.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODEMI");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTINIEMI '.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTINIEMI ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTTEREMI'.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTTEREMI");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'ESTR-COBR '.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ESTR-COBR ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'ORIG-PRODU'.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ORIG-PRODU");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'IND-IOF'.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"IND-IOF");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PER-IOF'.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PER-IOF");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTVENCTO '.*/
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTVENCTO ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTINIVIG '.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTINIVIG ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DTTERVIG'.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTTERVIG");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'OPCAO'.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"OPCAO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'PERI'.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"PERI");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(006)  VALUE             'DIADEB'.*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"DIADEB");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'RCAPS'.*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"RCAPS");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(003)  VALUE             'SIT'.*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIT");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'OPE'.*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"OPE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'VAL RCAP  '.*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VAL RCAP  ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'MOVIMCOB'.*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"MOVIMCOB");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(003)  VALUE             'SIT'.*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIT");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'VAL TITULO'.*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VAL TITULO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(003)  VALUE             'SIT'.*/
                public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIT");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'MOVDEBCE'.*/
                public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"MOVDEBCE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'CONVENIO'.*/
                public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CONVENIO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'VALOR     '.*/
                public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VALOR     ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_198 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'PREMIO VG + AP'.*/
                public StringBasis FILLER_199 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PREMIO VG + AP");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_200 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'INICIO   '.*/
                public StringBasis FILLER_201 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"INICIO   ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_202 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'ADMISSAO '.*/
                public StringBasis FILLER_203 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ADMISSAO ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_204 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'IEA'.*/
                public StringBasis FILLER_205 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"IEA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_206 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'IPA'.*/
                public StringBasis FILLER_207 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"IPA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_208 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'IPD'.*/
                public StringBasis FILLER_209 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"IPD");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_210 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'INI ZERO '.*/
                public StringBasis FILLER_211 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"INI ZERO ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_212 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'TER ZERO '.*/
                public StringBasis FILLER_213 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"TER ZERO ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_214 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'BCO'.*/
                public StringBasis FILLER_215 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"BCO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_216 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'AGE'.*/
                public StringBasis FILLER_217 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"AGE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_218 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'AVISO'.*/
                public StringBasis FILLER_219 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"AVISO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_220 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'IMPMORNATU'.*/
                public StringBasis FILLER_221 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"IMPMORNATU");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_222 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'IMPMORACID'.*/
                public StringBasis FILLER_223 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"IMPMORACID");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_224 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'IMPINVPERM'.*/
                public StringBasis FILLER_225 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"IMPINVPERM");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_226 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'IMPAMDS   '.*/
                public StringBasis FILLER_227 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"IMPAMDS   ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_228 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'IMPDH     '.*/
                public StringBasis FILLER_229 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"IMPDH     ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_230 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'IMPDIT    '.*/
                public StringBasis FILLER_231 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"IMPDIT    ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_232 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'PRMDIT    '.*/
                public StringBasis FILLER_233 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PRMDIT    ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_234 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'IMPRTO    '.*/
                public StringBasis FILLER_235 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"IMPRTO    ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_236 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'PRMRTO    '.*/
                public StringBasis FILLER_237 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PRMRTO    ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_238 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(013)  VALUE             'APOLICE'.*/
                public StringBasis FILLER_239 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_240 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'ENDOSSO'.*/
                public StringBasis FILLER_241 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"ENDOSSO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_242 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(004)  VALUE             'RAMO'.*/
                public StringBasis FILLER_243 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"RAMO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_244 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'SUBGRUPO'.*/
                public StringBasis FILLER_245 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SUBGRUPO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_246 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'FONTE'.*/
                public StringBasis FILLER_247 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"FONTE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_248 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'PAR82'.*/
                public StringBasis FILLER_249 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"PAR82");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_250 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'VALVG082'.*/
                public StringBasis FILLER_251 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VALVG082");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_252 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'APOLICOB'.*/
                public StringBasis FILLER_253 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"APOLICOB");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_254 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'NRRCAP  '.*/
                public StringBasis FILLER_255 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"NRRCAP  ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_256 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DATA RCAP'.*/
                public StringBasis FILLER_257 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DATA RCAP");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_258 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'SALDO   '.*/
                public StringBasis FILLER_259 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"SALDO   ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_260 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'ITEM '.*/
                public StringBasis FILLER_261 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"ITEM ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_262 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             'VLPREMIO'.*/
                public StringBasis FILLER_263 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VLPREMIO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_264 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(005)  VALUE             'NRSEQ'.*/
                public StringBasis FILLER_265 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"NRSEQ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_266 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(080)  VALUE             'OBSERVACAO'.*/
                public StringBasis FILLER_267 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"OBSERVACAO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_268 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(080)  VALUE  SPACES.*/
                public StringBasis FILLER_269 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"  03          LD01.*/
            }
            public VA0141B_LD01 LD01 { get; set; } = new VA0141B_LD01();
            public class VA0141B_LD01 : VarBasis
            {
                /*"    10        LD01-PROGRAMA          PIC X(008).*/
                public StringBasis LD01_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_270 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-TIPO-ENDOSSO      PIC X(001).*/
                public StringBasis LD01_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE '  '.*/
                public StringBasis FILLER_271 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"  ");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_272 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NUM-CERTIFICADO   PIC 9(015).*/
                public IntBasis LD01_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_273 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NUM-PARCELA       PIC 9(007).*/
                public IntBasis LD01_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_274 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NUM-TITULO        PIC 9(013).*/
                public IntBasis LD01_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_275 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-OCORR-HISTORICO   PIC 9(008).*/
                public IntBasis LD01_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_276 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NUM-APOLICE       PIC 9(013).*/
                public IntBasis LD01_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_277 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-COD-SUBGRUPO      PIC 9(009).*/
                public IntBasis LD01_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_278 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-COD-FONTE         PIC 9(005).*/
                public IntBasis LD01_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_279 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ORGAO             PIC 9(005).*/
                public IntBasis LD01_ORGAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_280 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-RAMO              PIC 9(004).*/
                public IntBasis LD01_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_281 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-MODALIDA          PIC 9(006).*/
                public IntBasis LD01_MODALIDA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_282 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PREMIO-VG         PIC 9(013)V99.*/
                public DoubleBasis LD01_PREMIO_VG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_283 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PREMIO-AP         PIC 9(013)V99.*/
                public DoubleBasis LD01_PREMIO_AP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_284 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DATA-MOVIMENTO    PIC X(010).*/
                public StringBasis LD01_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_285 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-SIT-REGISTRO      PIC X(001).*/
                public StringBasis LD01_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE '  '.*/
                public StringBasis FILLER_286 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"  ");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_287 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-COD-OPERACAO      PIC 9(005).*/
                public IntBasis LD01_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_288 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-COD-PRODUTO       PIC 9(007).*/
                public IntBasis LD01_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_289 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DATA-QUITACAO     PIC X(010).*/
                public StringBasis LD01_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_290 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-SITUACAO          PIC X(001).*/
                public StringBasis LD01_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE '  '.*/
                public StringBasis FILLER_291 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"  ");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_292 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-OCORHIST          PIC 9(005).*/
                public IntBasis LD01_OCORHIST { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_293 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTPROXVEN         PIC X(010).*/
                public StringBasis LD01_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_294 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-CLIENTE           PIC 9(009).*/
                public IntBasis LD01_CLIENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_295 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-CGCCPF            PIC 9(015).*/
                public IntBasis LD01_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_296 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DATA-NASCIMENTO   PIC X(010).*/
                public StringBasis LD01_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_297 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-TIPO-PESSOA       PIC X(001).*/
                public StringBasis LD01_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(005)  VALUE '  '.*/
                public StringBasis FILLER_298 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  ");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_299 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PRODUTO           PIC 9(007).*/
                public IntBasis LD01_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_300 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PRODEMIS          PIC 9(007).*/
                public IntBasis LD01_PRODEMIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_301 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTINIEMI          PIC X(010).*/
                public StringBasis LD01_DTINIEMI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_302 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTTEREMI          PIC X(010).*/
                public StringBasis LD01_DTTEREMI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_303 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ESTR-COBR         PIC X(010).*/
                public StringBasis LD01_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_304 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ORIG-PRODU        PIC X(010).*/
                public StringBasis LD01_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_305 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IND-IOF           PIC X(001).*/
                public StringBasis LD01_IND_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(006)  VALUE '  '.*/
                public StringBasis FILLER_306 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"  ");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_307 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PER-IOF           PIC 9(005)V99.*/
                public DoubleBasis LD01_PER_IOF { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_308 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DATA-VENCIMENTO   PIC X(010).*/
                public StringBasis LD01_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_309 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DATA-INIVIGENCIA  PIC X(010).*/
                public StringBasis LD01_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_310 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DATA-TERVIGENCIA  PIC X(010).*/
                public StringBasis LD01_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_311 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-OPCAO-PAGAMENTO   PIC X(001).*/
                public StringBasis LD01_OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(004)  VALUE '  '.*/
                public StringBasis FILLER_312 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"  ");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_313 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PERI-PAGAMENTO    PIC 9(004).*/
                public IntBasis LD01_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_314 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DIA-DEBITO        PIC 9(006).*/
                public IntBasis LD01_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_315 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-RCAPS             PIC X(003).*/
                public StringBasis LD01_RCAPS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        FILLER                 PIC X(002)  VALUE '  '.*/
                public StringBasis FILLER_316 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"  ");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_317 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-SITRCAP           PIC X(001).*/
                public StringBasis LD01_SITRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(002)  VALUE '  '.*/
                public StringBasis FILLER_318 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"  ");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_319 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-OPERCAP           PIC 9(004).*/
                public IntBasis LD01_OPERCAP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_320 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VAL-RCAP          PIC 9(013)V99.*/
                public DoubleBasis LD01_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_321 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-MOVIMCOB          PIC X(003).*/
                public StringBasis LD01_MOVIMCOB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        FILLER                 PIC X(005)  VALUE '  '.*/
                public StringBasis FILLER_322 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  ");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_323 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-SITMCOB           PIC X(001).*/
                public StringBasis LD01_SITMCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(002)  VALUE '  '.*/
                public StringBasis FILLER_324 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"  ");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_325 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VAL-TITULO        PIC 9(013)V99.*/
                public DoubleBasis LD01_VAL_TITULO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_326 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-SITMDEB           PIC X(001).*/
                public StringBasis LD01_SITMDEB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        FILLER                 PIC X(002)  VALUE '  '.*/
                public StringBasis FILLER_327 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"  ");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_328 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-MOVDEBCE          PIC X(003).*/
                public StringBasis LD01_MOVDEBCE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10        FILLER                 PIC X(005)  VALUE '  '.*/
                public StringBasis FILLER_329 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  ");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_330 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-CONVENIO          PIC 9(008).*/
                public IntBasis LD01_CONVENIO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_331 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VALOR-DEBITO      PIC 9(013)V99.*/
                public DoubleBasis LD01_VALOR_DEBITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_332 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VALVGAP           PIC 9(013)V99.*/
                public DoubleBasis LD01_VALVGAP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_333 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTINIVIG          PIC X(010).*/
                public StringBasis LD01_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_334 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DATA-ADMISSAO     PIC X(010).*/
                public StringBasis LD01_DATA_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_335 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ADICIEA           PIC 9(005)V99.*/
                public DoubleBasis LD01_ADICIEA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_336 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ADICIPA           PIC 9(005)V99.*/
                public DoubleBasis LD01_ADICIPA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_337 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ADICIPD           PIC 9(005)V99.*/
                public DoubleBasis LD01_ADICIPD { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_338 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-INIZERO           PIC X(010).*/
                public StringBasis LD01_INIZERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_339 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-TERZERO           PIC X(010).*/
                public StringBasis LD01_TERZERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_340 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-BCOAVISO          PIC 9(004).*/
                public IntBasis LD01_BCOAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_341 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-AGEAVISO          PIC 9(004).*/
                public IntBasis LD01_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_342 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NRAVISO           PIC 9(009).*/
                public IntBasis LD01_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_343 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMPMORNATU        PIC 9(013)V99.*/
                public DoubleBasis LD01_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_344 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMPMORACID        PIC 9(013)V99.*/
                public DoubleBasis LD01_IMPMORACID { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_345 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMPINVPERM        PIC 9(013)V99.*/
                public DoubleBasis LD01_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_346 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMPAMDS           PIC 9(013)V99.*/
                public DoubleBasis LD01_IMPAMDS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_347 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMPDH             PIC 9(013)V99.*/
                public DoubleBasis LD01_IMPDH { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_348 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMPDIT            PIC 9(013)V99.*/
                public DoubleBasis LD01_IMPDIT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_349 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PRMDIT            PIC 9(013)V99.*/
                public DoubleBasis LD01_PRMDIT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_350 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMPRTO            PIC 9(013)V99.*/
                public DoubleBasis LD01_IMPRTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_351 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PRMRTO            PIC 9(013)V99.*/
                public DoubleBasis LD01_PRMRTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_352 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-APOLICE           PIC 9(013).*/
                public IntBasis LD01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_353 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ENDOSSO           PIC 9(009).*/
                public IntBasis LD01_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_354 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-RAMO-EMISSOR      PIC 9(004).*/
                public IntBasis LD01_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_355 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-SUBGRUPO          PIC 9(009).*/
                public IntBasis LD01_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_356 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-FONTE             PIC 9(005).*/
                public IntBasis LD01_FONTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_357 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PARVG082          PIC 9(005).*/
                public IntBasis LD01_PARVG082 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_358 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VALVG082          PIC 9(013)V99.*/
                public DoubleBasis LD01_VALVG082 { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_359 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-APOLICOB          PIC 9(009).*/
                public IntBasis LD01_APOLICOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_360 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NRRCAP            PIC 9(009).*/
                public IntBasis LD01_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_361 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DATA-RCAP         PIC X(010).*/
                public StringBasis LD01_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_362 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-SALDO             PIC 9(013)V99.*/
                public DoubleBasis LD01_SALDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_363 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ITEM              PIC 9(009).*/
                public IntBasis LD01_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_364 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VLPREMIO          PIC 9(013)V99.*/
                public DoubleBasis LD01_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_365 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NRSEQ             PIC 9(005).*/
                public IntBasis LD01_NRSEQ { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_366 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-OBSERVA           PIC X(080).*/
                public StringBasis LD01_OBSERVA { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_367 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-OBSERVA1          PIC X(080)  VALUE  SPACES.*/
                public StringBasis LD01_OBSERVA1 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"  03          WS01.*/
            }
            public VA0141B_WS01 WS01 { get; set; } = new VA0141B_WS01();
            public class VA0141B_WS01 : VarBasis
            {
                /*"    10        WS01-OBSERVA           PIC X(030).*/
                public StringBasis WS01_OBSERVA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    10        FILLER                 PIC X(003)  VALUE '  '.*/
                public StringBasis FILLER_368 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"  ");
                /*"    10        WS01-LIQUIDO           PIC 9(013)V99.*/
                public DoubleBasis WS01_LIQUIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE '  '.*/
                public StringBasis FILLER_369 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"  ");
                /*"    10        WS01-VALOR             PIC 9(013)V99.*/
                public DoubleBasis WS01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10        FILLER                 PIC X(003)  VALUE '  '.*/
                public StringBasis FILLER_370 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"  ");
                /*"    10        WS01-PERCENT           PIC 9(003)V99.*/
                public DoubleBasis WS01_PERCENT { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"    10        FILLER                 PIC X(006)  VALUE '  '.*/
                public StringBasis FILLER_371 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"  ");
                /*"01  TABELA-COBERTURA.*/
            }
        }
        public VA0141B_TABELA_COBERTURA TABELA_COBERTURA { get; set; } = new VA0141B_TABELA_COBERTURA();
        public class VA0141B_TABELA_COBERTURA : VarBasis
        {
            /*"  03          WCOB00-COBE00.*/
            public VA0141B_WCOB00_COBE00 WCOB00_COBE00 { get; set; } = new VA0141B_WCOB00_COBE00();
            public class VA0141B_WCOB00_COBE00 : VarBasis
            {
                /*"    05        WCOB00-OCORRECOB    OCCURS       010   TIMES                                  INDEXED      BY    WS-COB00.*/
                public ListBasis<VA0141B_WCOB00_OCORRECOB> WCOB00_OCORRECOB { get; set; } = new ListBasis<VA0141B_WCOB00_OCORRECOB>(010);
                public class VA0141B_WCOB00_OCORRECOB : VarBasis
                {
                    /*"      10      WCOB00-RAMO         PIC S9(004)        COMP.*/
                    public IntBasis WCOB00_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB00-COBE         PIC S9(004)        COMP.*/
                    public IntBasis WCOB00_COBE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB00-IMPSEG       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB00_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB00-PRMTAR       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB00_PRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB00-PERCEN       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB00_PERCEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"  03          WCOB01-COBE01.*/
                }
            }
            public VA0141B_WCOB01_COBE01 WCOB01_COBE01 { get; set; } = new VA0141B_WCOB01_COBE01();
            public class VA0141B_WCOB01_COBE01 : VarBasis
            {
                /*"    05        WCOB01-OCORRECOB    OCCURS       010   TIMES                                  INDEXED      BY    WS-COB01.*/
                public ListBasis<VA0141B_WCOB01_OCORRECOB> WCOB01_OCORRECOB { get; set; } = new ListBasis<VA0141B_WCOB01_OCORRECOB>(010);
                public class VA0141B_WCOB01_OCORRECOB : VarBasis
                {
                    /*"      10      WCOB01-RAMO         PIC S9(004)        COMP.*/
                    public IntBasis WCOB01_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB01-COBE         PIC S9(004)        COMP.*/
                    public IntBasis WCOB01_COBE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB01-IMPSEG       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB01_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB01-PRMTAR       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB01_PRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB01-PERCEN       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB01_PERCEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                }
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.NUMERAES NUMERAES { get; set; } = new Dclgens.NUMERAES();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.APOLCOSS APOLCOSS { get; set; } = new Dclgens.APOLCOSS();
        public Dclgens.NUMERCOS NUMERCOS { get; set; } = new Dclgens.NUMERCOS();
        public Dclgens.ORDEMCOS ORDEMCOS { get; set; } = new Dclgens.ORDEMCOS();
        public Dclgens.EMISSDIA EMISSDIA { get; set; } = new Dclgens.EMISSDIA();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.VG082 VG082 { get; set; } = new Dclgens.VG082();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.GE403 GE403 { get; set; } = new Dclgens.GE403();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public VA0141B_V0VG082 V0VG082 { get; set; } = new VA0141B_V0VG082();
        public VA0141B_V0APOLCOSS V0APOLCOSS { get; set; } = new VA0141B_V0APOLCOSS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SVA0141B_FILE_NAME_P, string ENTRADA1_FILE_NAME_P, string SAIDA01_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SVA0141B.SetFile(SVA0141B_FILE_NAME_P);
                ENTRADA1.SetFile(ENTRADA1_FILE_NAME_P);
                SAIDA01.SetFile(SAIDA01_FILE_NAME_P);

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
            /*" -1031- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -1034- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1035- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1037- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1039- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1042- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -1043- DISPLAY '           VA0141B - EMISSAO DE FATURAS           ' */
            _.Display($"           VA0141B - EMISSAO DE FATURAS           ");

            /*" -1044- DISPLAY ' ' */
            _.Display($" ");

            /*" -1045- DISPLAY 'VERSAO V.10 : ' FUNCTION WHEN-COMPILED ' - 560.871' */

            $"VERSAO V.10 : FUNCTION{_.WhenCompiled()} - 560.871"
            .Display();

            /*" -1046- DISPLAY ' ' */
            _.Display($" ");

            /*" -1053- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1054- DISPLAY '   ' */
            _.Display($"   ");

            /*" -1055- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1057- DISPLAY '   ' */
            _.Display($"   ");

            /*" -1060- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -1074- SORT SVA0141B ON ASCENDING KEY SOR-TIPO-ENDOSSO SOR-NUM-APOLICE SOR-NUM-CERTIFICADO SOR-NUM-PARCELA SOR-OCORR-HISTORICO SOR-COD-SUBGRUPO SOR-COD-FONTE INPUT PROCEDURE R0150-00-SELECIONA THRU R0150-99-SAIDA OUTPUT PROCEDURE R0400-00-PROCESSA-SORT THRU R0400-99-SAIDA. */
            SVA0141B.Sort("SOR-TIPO-ENDOSSO,SOR-NUM-APOLICE,SOR-NUM-CERTIFICADO,SOR-NUM-PARCELA,SOR-OCORR-HISTORICO,SOR-COD-SUBGRUPO,SOR-COD-FONTE", () => R0150_00_SELECIONA_SECTION(), () => R0400_00_PROCESSA_SORT_SECTION());

            /*" -1078- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -1079- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_90.WTIME_DAYR.WTIME_HORA);

            /*" -1080- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_90.WTIME_DAYR.WTIME_2PT1);

            /*" -1081- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_90.WTIME_DAYR.WTIME_MINU);

            /*" -1082- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_90.WTIME_DAYR.WTIME_2PT2);

            /*" -1083- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_90.WTIME_DAYR.WTIME_SEGU);

            /*" -1083- DISPLAY 'FIM    VA0141B    ' WTIME-DAYR. */
            _.Display($"FIM    VA0141B    {W.FILLER_90.WTIME_DAYR}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1088- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1094- PERFORM R9000-00-INSERT-RELATORI. */

            R9000_00_INSERT_RELATORI_SECTION();

            /*" -1097- CLOSE ENTRADA1 SAIDA01. */
            ENTRADA1.Close();
            SAIDA01.Close();

            /*" -1099- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1100- DISPLAY ' ' */
            _.Display($" ");

            /*" -1101- DISPLAY 'VA0141B - FIM NORMAL' */
            _.Display($"VA0141B - FIM NORMAL");

            /*" -1104- DISPLAY ' ' */
            _.Display($" ");

            /*" -1104- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -1111- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", W.WABEND.WNR_EXEC_SQL);

            /*" -1114- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1115- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -1116- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_90.WTIME_DAYR.WTIME_HORA);

            /*" -1117- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_90.WTIME_DAYR.WTIME_2PT1);

            /*" -1118- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_90.WTIME_DAYR.WTIME_MINU);

            /*" -1119- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_90.WTIME_DAYR.WTIME_2PT2);

            /*" -1120- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_90.WTIME_DAYR.WTIME_SEGU);

            /*" -1123- DISPLAY 'INICIO VA0141B    ' WTIME-DAYR. */
            _.Display($"INICIO VA0141B    {W.FILLER_90.WTIME_DAYR}");

            /*" -1124- OPEN INPUT ENTRADA1 */
            ENTRADA1.Open(REG_ENTRADA1);

            /*" -1127- OUTPUT SAIDA01. */
            SAIDA01.Open(REG_SAIDA01);

            /*" -1129- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -1132- PERFORM R0120-00-SELECT-CALENDAR. */

            R0120_00_SELECT_CALENDAR_SECTION();

            /*" -1133- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1135- DISPLAY 'DATA DE MOVIMENTO ..... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DE MOVIMENTO ..... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -1138- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1140- WRITE REG-SAIDA01 FROM LC01. */
            _.Move(ARQUIVOS_SAIDA.LC01.GetMoveValues(), REG_SAIDA01);

            SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

            /*" -1140- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -1151- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -1154- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1163- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -1167- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1168- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -1168- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -1163- EXEC SQL SELECT DATA_MOV_ABERTO ,DATA_MOV_ABERTO - 15 MONTHS INTO :SISTEMAS-DATA-MOV-ABERTO ,:WHOST-DATA15 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA15, WHOST_DATA15);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-SELECT-CALENDAR-SECTION */
        private void R0120_00_SELECT_CALENDAR_SECTION()
        {
            /*" -1179- MOVE '0120' TO WNR-EXEC-SQL. */
            _.Move("0120", W.WABEND.WNR_EXEC_SQL);

            /*" -1182- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1191- PERFORM R0120_00_SELECT_CALENDAR_DB_SELECT_1 */

            R0120_00_SELECT_CALENDAR_DB_SELECT_1();

            /*" -1195- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1197- MOVE SPACES TO WHOST-DATAINI WHOST-DATATER */
                _.Move("", WHOST_DATAINI, WHOST_DATATER);

                /*" -1200- GO TO R0120-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1201- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1203- DISPLAY 'R0120-00 - PROBLEMAS NO SELECT(CALENDAR)' ' DATA        = ' CALENDAR-DATA-CALENDARIO */

                $"R0120-00 - PROBLEMAS NO SELECT(CALENDAR) DATA        = {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}"
                .Display();

                /*" -1206- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1208- MOVE CALENDAR-DATA-CALENDARIO TO WDATA-REL. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, W.WDATA_REL);

            /*" -1209- MOVE 01 TO WDAT-REL-DIA. */
            _.Move(01, W.FILLER_87.WDAT_REL_DIA);

            /*" -1210- MOVE WDATA-REL TO WHOST-DATAINI. */
            _.Move(W.WDATA_REL, WHOST_DATAINI);

            /*" -1211- MOVE CALENDAR-DTH-ULT-DIA-MES TO WHOST-DATATER. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES, WHOST_DATATER);

        }

        [StopWatch]
        /*" R0120-00-SELECT-CALENDAR-DB-SELECT-1 */
        public void R0120_00_SELECT_CALENDAR_DB_SELECT_1()
        {
            /*" -1191- EXEC SQL SELECT DATA_CALENDARIO ,DTH_ULT_DIA_MES INTO :CALENDAR-DATA-CALENDARIO ,:CALENDAR-DTH-ULT-DIA-MES FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :SISTEMAS-DATA-MOV-ABERTO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1 = new R0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1.Execute(r0120_00_SELECT_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.CALENDAR_DTH_ULT_DIA_MES, CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-SELECIONA-SECTION */
        private void R0150_00_SELECIONA_SECTION()
        {
            /*" -1222- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", W.WABEND.WNR_EXEC_SQL);

            /*" -1225- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1226- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -1227- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_90.WTIME_DAYR.WTIME_HORA);

            /*" -1228- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_90.WTIME_DAYR.WTIME_2PT1);

            /*" -1229- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_90.WTIME_DAYR.WTIME_MINU);

            /*" -1230- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_90.WTIME_DAYR.WTIME_2PT2);

            /*" -1231- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_90.WTIME_DAYR.WTIME_SEGU);

            /*" -1234- DISPLAY 'LEITURA ENTRADA   ' WTIME-DAYR. */
            _.Display($"LEITURA ENTRADA   {W.FILLER_90.WTIME_DAYR}");

            /*" -1235- MOVE SPACES TO WFIM-ENTRADA1 */
            _.Move("", W.WFIM_ENTRADA1);

            /*" -1237- PERFORM R0160-00-LE-ENTRADA1. */

            R0160_00_LE_ENTRADA1_SECTION();

            /*" -1238- IF WFIM-ENTRADA1 NOT EQUAL SPACES */

            if (!W.WFIM_ENTRADA1.IsEmpty())
            {

                /*" -1239- DISPLAY 'ENTRADA1 SEM MOVTO ' */
                _.Display($"ENTRADA1 SEM MOVTO ");

                /*" -1242- GO TO R0150-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1246- PERFORM R0170-00-PROCESSA-ENTRADA1 UNTIL WFIM-ENTRADA1 NOT EQUAL SPACES. */

            while (!(!W.WFIM_ENTRADA1.IsEmpty()))
            {

                R0170_00_PROCESSA_ENTRADA1_SECTION();
            }

            /*" -1247- DISPLAY ' ' */
            _.Display($" ");

            /*" -1248- DISPLAY 'LIDOS ENTRADA1 ........ ' LD-ENTRADA1 */
            _.Display($"LIDOS ENTRADA1 ........ {W.LD_ENTRADA1}");

            /*" -1249- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1250- DISPLAY 'GRAVADOS SORT ......... ' GV-SORT. */
            _.Display($"GRAVADOS SORT ......... {W.GV_SORT}");

            /*" -1251- DISPLAY 'GRAVADOS ARQUIVO 1 .... ' AC-GRAVA01 */
            _.Display($"GRAVADOS ARQUIVO 1 .... {W.AC_GRAVA01}");

            /*" -1254- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1254- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-LE-ENTRADA1-SECTION */
        private void R0160_00_LE_ENTRADA1_SECTION()
        {
            /*" -1265- MOVE '0160' TO WNR-EXEC-SQL. */
            _.Move("0160", W.WABEND.WNR_EXEC_SQL);

            /*" -1267- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1268- READ ENTRADA1 AT END */
            try
            {
                ENTRADA1.Read(() =>
                {

                    /*" -1270- MOVE 'S' TO WFIM-ENTRADA1 */
                    _.Move("S", W.WFIM_ENTRADA1);

                    /*" -1273- GO TO R0160-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(ENTRADA1.Value, REG_ENTRADA1);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1276- ADD 1 TO LD-ENTRADA1. */
            W.LD_ENTRADA1.Value = W.LD_ENTRADA1 + 1;

            /*" -1278- MOVE LD-ENTRADA1 TO AC-LIDOS. */
            _.Move(W.LD_ENTRADA1, W.AC_LIDOS);

            /*" -1280- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_86.LD_PARTE2 == 00 || W.FILLER_86.LD_PARTE2 == 5000)
            {

                /*" -1281- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -1282- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_90.WTIME_DAYR.WTIME_HORA);

                /*" -1283- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_90.WTIME_DAYR.WTIME_2PT1);

                /*" -1284- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_90.WTIME_DAYR.WTIME_MINU);

                /*" -1285- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_90.WTIME_DAYR.WTIME_2PT2);

                /*" -1286- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_90.WTIME_DAYR.WTIME_SEGU);

                /*" -1287- DISPLAY 'LIDOS ENTRADA      ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS ENTRADA      {W.AC_LIDOS}    {W.FILLER_90.WTIME_DAYR}"
                .Display();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0170-00-PROCESSA-ENTRADA1-SECTION */
        private void R0170_00_PROCESSA_ENTRADA1_SECTION()
        {
            /*" -1298- MOVE '0170' TO WNR-EXEC-SQL. */
            _.Move("0170", W.WABEND.WNR_EXEC_SQL);

            /*" -1301- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1307- IF ENT-RCAPS EQUAL 'NAO' AND ENT-MOVIMCOB EQUAL 'NAO' AND ENT-MOVDEBCE EQUAL 'NAO' AND ENT-OPCAO-PAGAMENTO NOT EQUAL '5' AND ENT-TIPO-ENDOSSO EQUAL '1' AND ENT-NUM-PARCELA EQUAL 1 */

            if (REG_ENTRADA1.ENT_RCAPS == "NAO" && REG_ENTRADA1.ENT_MOVIMCOB == "NAO" && REG_ENTRADA1.ENT_MOVDEBCE == "NAO" && REG_ENTRADA1.ENT_OPCAO_PAGAMENTO != "5" && REG_ENTRADA1.ENT_TIPO_ENDOSSO == "1" && REG_ENTRADA1.ENT_NUM_PARCELA == 1)
            {

                /*" -1310- PERFORM R0180-00-SELECT-GE403. */

                R0180_00_SELECT_GE403_SECTION();
            }


            /*" -1313- PERFORM R0260-00-MOVE-DADOS-ENTRADA. */

            R0260_00_MOVE_DADOS_ENTRADA_SECTION();

            /*" -1317- IF SOR-RCAPS EQUAL 'NAO' AND SOR-MOVIMCOB EQUAL 'NAO' AND SOR-MOVDEBCE EQUAL 'NAO' AND SOR-OPCAO-PAGAMENTO NOT EQUAL '5' */

            if (REG_SVA0141B.SOR_RCAPS == "NAO" && REG_SVA0141B.SOR_MOVIMCOB == "NAO" && REG_SVA0141B.SOR_MOVDEBCE == "NAO" && REG_SVA0141B.SOR_OPCAO_PAGAMENTO != "5")
            {

                /*" -1319- MOVE 'CERTIFICADO SEM CREDITO         ' TO LD01-OBSERVA */
                _.Move("CERTIFICADO SEM CREDITO         ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -1320- WRITE REG-SAIDA01 FROM LD01 */
                _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -1321- ADD 1 TO AC-GRAVA01 */
                W.AC_GRAVA01.Value = W.AC_GRAVA01 + 1;

                /*" -1324- GO TO R0170-90-LEITURA. */

                R0170_90_LEITURA(); //GOTO
                return;
            }


            /*" -1325- IF SOR-DATA-MOVIMENTO LESS WHOST-DATA15 */

            if (REG_SVA0141B.SOR_DATA_MOVIMENTO < WHOST_DATA15)
            {

                /*" -1327- MOVE 'DTMOVTO MENOR 15 MESES          ' TO LD01-OBSERVA */
                _.Move("DTMOVTO MENOR 15 MESES          ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -1328- WRITE REG-SAIDA01 FROM LD01 */
                _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -1329- ADD 1 TO AC-GRAVA01 */
                W.AC_GRAVA01.Value = W.AC_GRAVA01 + 1;

                /*" -1332- GO TO R0170-90-LEITURA. */

                R0170_90_LEITURA(); //GOTO
                return;
            }


            /*" -1335- IF SISTEMAS-DATA-MOV-ABERTO LESS SOR-DTINIEMI AND WHOST-DATAINI NOT EQUAL SPACES AND SOR-NUM-PARCELA NOT EQUAL 1 */

            if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO < REG_SVA0141B.SOR_DTINIEMI && !WHOST_DATAINI.IsEmpty() && REG_SVA0141B.SOR_NUM_PARCELA != 1)
            {

                /*" -1336- MOVE WHOST-DATAINI TO SOR-DTINIEMI */
                _.Move(WHOST_DATAINI, REG_SVA0141B.SOR_DTINIEMI);

                /*" -1339- MOVE WHOST-DATATER TO SOR-DTTEREMI. */
                _.Move(WHOST_DATATER, REG_SVA0141B.SOR_DTTEREMI);
            }


            /*" -1340- IF SISTEMAS-DATA-MOV-ABERTO LESS SOR-DTINIEMI */

            if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO < REG_SVA0141B.SOR_DTINIEMI)
            {

                /*" -1342- MOVE 'DTEMISS MENOR DTINIVIG          ' TO LD01-OBSERVA */
                _.Move("DTEMISS MENOR DTINIVIG          ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -1343- WRITE REG-SAIDA01 FROM LD01 */
                _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -1344- ADD 1 TO AC-GRAVA01 */
                W.AC_GRAVA01.Value = W.AC_GRAVA01 + 1;

                /*" -1347- GO TO R0170-90-LEITURA. */

                R0170_90_LEITURA(); //GOTO
                return;
            }


            /*" -1348- IF SOR-DTINIEMI LESS SOR-INIZERO */

            if (REG_SVA0141B.SOR_DTINIEMI < REG_SVA0141B.SOR_INIZERO)
            {

                /*" -1349- PERFORM R0300-00-UPDATE-ENDOSSOS */

                R0300_00_UPDATE_ENDOSSOS_SECTION();

                /*" -1351- MOVE 'DTINIEMI MENOR DTINIVIG ZERO     ' TO LD01-OBSERVA */
                _.Move("DTINIEMI MENOR DTINIVIG ZERO     ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -1352- WRITE REG-SAIDA01 FROM LD01 */
                _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -1353- ADD 1 TO AC-GRAVA01 */
                W.AC_GRAVA01.Value = W.AC_GRAVA01 + 1;

                /*" -1356- GO TO R0170-90-LEITURA. */

                R0170_90_LEITURA(); //GOTO
                return;
            }


            /*" -1358- IF SOR-VALVGAP EQUAL ZEROS AND SOR-VALVG082 EQUAL ZEROS */

            if (REG_SVA0141B.SOR_VALVGAP == 00 && REG_SVA0141B.SOR_VALVG082 == 00)
            {

                /*" -1360- MOVE 'VALVG IGUAL ZEROS                ' TO LD01-OBSERVA */
                _.Move("VALVG IGUAL ZEROS                ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -1361- WRITE REG-SAIDA01 FROM LD01 */
                _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -1362- ADD 1 TO AC-GRAVA01 */
                W.AC_GRAVA01.Value = W.AC_GRAVA01 + 1;

                /*" -1365- GO TO R0170-90-LEITURA. */

                R0170_90_LEITURA(); //GOTO
                return;
            }


            /*" -1366- RELEASE REG-SVA0141B. */
            SVA0141B.Release(REG_SVA0141B);

            /*" -1366- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R0170_90_LEITURA */

            R0170_90_LEITURA();

        }

        [StopWatch]
        /*" R0170-90-LEITURA */
        private void R0170_90_LEITURA(bool isPerform = false)
        {
            /*" -1371- PERFORM R0160-00-LE-ENTRADA1. */

            R0160_00_LE_ENTRADA1_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_99_SAIDA*/

        [StopWatch]
        /*" R0180-00-SELECT-GE403-SECTION */
        private void R0180_00_SELECT_GE403_SECTION()
        {
            /*" -1381- MOVE '0180' TO WNR-EXEC-SQL. */
            _.Move("0180", W.WABEND.WNR_EXEC_SQL);

            /*" -1384- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1388- MOVE ENT-NUM-APOLICE TO CONVERSI-NUM-SICOB. */
            _.Move(REG_ENTRADA1.ENT_NUM_APOLICE, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);

            /*" -1421- PERFORM R0180_00_SELECT_GE403_DB_SELECT_1 */

            R0180_00_SELECT_GE403_DB_SELECT_1();

            /*" -1425- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1426- PERFORM R0190-00-SELECT-RCAPS */

                R0190_00_SELECT_RCAPS_SECTION();

                /*" -1427- ELSE */
            }
            else
            {


                /*" -1428- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1429- DISPLAY 'R0180-00 - PROBLEMAS NO SELECT(GE403)   ' */
                    _.Display($"R0180-00 - PROBLEMAS NO SELECT(GE403)   ");

                    /*" -1430- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1431- ELSE */
                }
                else
                {


                    /*" -1432- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1433- MOVE 'SIM' TO ENT-RCAPS */
                        _.Move("SIM", REG_ENTRADA1.ENT_RCAPS);

                        /*" -1434- MOVE RCAPS-SIT-REGISTRO TO ENT-SITRCAP */
                        _.Move(RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO, REG_ENTRADA1.ENT_SITRCAP);

                        /*" -1435- MOVE RCAPS-COD-OPERACAO TO ENT-OPERCAP */
                        _.Move(RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO, REG_ENTRADA1.ENT_OPERCAP);

                        /*" -1436- MOVE RCAPS-VAL-RCAP TO ENT-VAL-RCAP */
                        _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, REG_ENTRADA1.ENT_VAL_RCAP);

                        /*" -1437- MOVE RCAPS-NUM-RCAP TO ENT-NRRCAP */
                        _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, REG_ENTRADA1.ENT_NRRCAP);

                        /*" -1438- MOVE RCAPS-NUM-TITULO TO ENT-NUM-TITULO */
                        _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_TITULO, REG_ENTRADA1.ENT_NUM_TITULO);

                        /*" -1440- MOVE RCAPS-DATA-CADASTRAMENTO TO ENT-DATA-RCAP */
                        _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO, REG_ENTRADA1.ENT_DATA_RCAP);

                        /*" -1441- MOVE RCAPCOMP-BCO-AVISO TO ENT-BCOAVISO */
                        _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, REG_ENTRADA1.ENT_BCOAVISO);

                        /*" -1442- MOVE RCAPCOMP-AGE-AVISO TO ENT-AGEAVISO */
                        _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, REG_ENTRADA1.ENT_AGEAVISO);

                        /*" -1444- MOVE RCAPCOMP-NUM-AVISO-CREDITO TO ENT-NRAVISO */
                        _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, REG_ENTRADA1.ENT_NRAVISO);

                        /*" -1445- PERFORM R0210-00-UPDATE-HISCONPA */

                        R0210_00_UPDATE_HISCONPA_SECTION();

                        /*" -1445- PERFORM R0220-00-UPDATE-COBHISVI. */

                        R0220_00_UPDATE_COBHISVI_SECTION();
                    }

                }

            }


        }

        [StopWatch]
        /*" R0180-00-SELECT-GE403-DB-SELECT-1 */
        public void R0180_00_SELECT_GE403_DB_SELECT_1()
        {
            /*" -1421- EXEC SQL SELECT C.NUM_RCAP ,C.VAL_RCAP ,C.DATA_CADASTRAMENTO ,C.SIT_REGISTRO ,C.COD_OPERACAO ,C.NUM_TITULO ,D.BCO_AVISO ,D.AGE_AVISO ,D.NUM_AVISO_CREDITO INTO :RCAPS-NUM-RCAP ,:RCAPS-VAL-RCAP ,:RCAPS-DATA-CADASTRAMENTO ,:RCAPS-SIT-REGISTRO ,:RCAPS-COD-OPERACAO ,:RCAPS-NUM-TITULO ,:RCAPCOMP-BCO-AVISO ,:RCAPCOMP-AGE-AVISO ,:RCAPCOMP-NUM-AVISO-CREDITO FROM SEGUROS.CONVERSAO_SICOB A ,SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B ,SEGUROS.RCAPS C ,SEGUROS.RCAP_COMPLEMENTAR D WHERE A.NUM_SICOB = :CONVERSI-NUM-SICOB AND B.NUM_PROPOSTA = A.NUM_PROPOSTA_SIVPF AND B.COD_SITUACAO = 'F' AND B.NUM_PARCELA = 1 AND C.NUM_CERTIFICADO = A.NUM_PROPOSTA_SIVPF AND D.COD_FONTE = C.COD_FONTE AND D.NUM_RCAP = C.NUM_RCAP AND D.SIT_REGISTRO = '0' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0180_00_SELECT_GE403_DB_SELECT_1_Query1 = new R0180_00_SELECT_GE403_DB_SELECT_1_Query1()
            {
                CONVERSI_NUM_SICOB = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB.ToString(),
            };

            var executed_1 = R0180_00_SELECT_GE403_DB_SELECT_1_Query1.Execute(r0180_00_SELECT_GE403_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPS_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_99_SAIDA*/

        [StopWatch]
        /*" R0190-00-SELECT-RCAPS-SECTION */
        private void R0190_00_SELECT_RCAPS_SECTION()
        {
            /*" -1456- MOVE '0190' TO WNR-EXEC-SQL. */
            _.Move("0190", W.WABEND.WNR_EXEC_SQL);

            /*" -1459- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1461- MOVE ENT-NUM-CERTIFICADO TO COBHISVI-NUM-CERTIFICADO. */
            _.Move(REG_ENTRADA1.ENT_NUM_CERTIFICADO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);

            /*" -1463- MOVE ENT-NUM-PARCELA TO COBHISVI-NUM-PARCELA. */
            _.Move(REG_ENTRADA1.ENT_NUM_PARCELA, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

            /*" -1465- MOVE ENT-NUM-APOLICE TO RCAPS-NUM-APOLICE. */
            _.Move(REG_ENTRADA1.ENT_NUM_APOLICE, RCAPS.DCLRCAPS.RCAPS_NUM_APOLICE);

            /*" -1469- MOVE ZEROS TO RCAPS-NUM-ENDOSSO. */
            _.Move(0, RCAPS.DCLRCAPS.RCAPS_NUM_ENDOSSO);

            /*" -1504- PERFORM R0190_00_SELECT_RCAPS_DB_SELECT_1 */

            R0190_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -1509- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1510- DISPLAY 'R0190-00 - PROBLEMAS NO SELECT(RCAPS)   ' */
                _.Display($"R0190-00 - PROBLEMAS NO SELECT(RCAPS)   ");

                /*" -1511- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1512- ELSE */
            }
            else
            {


                /*" -1513- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1514- MOVE 'SIM' TO ENT-RCAPS */
                    _.Move("SIM", REG_ENTRADA1.ENT_RCAPS);

                    /*" -1515- MOVE RCAPS-SIT-REGISTRO TO ENT-SITRCAP */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO, REG_ENTRADA1.ENT_SITRCAP);

                    /*" -1516- MOVE RCAPS-COD-OPERACAO TO ENT-OPERCAP */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO, REG_ENTRADA1.ENT_OPERCAP);

                    /*" -1517- MOVE RCAPS-VAL-RCAP TO ENT-VAL-RCAP */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, REG_ENTRADA1.ENT_VAL_RCAP);

                    /*" -1518- MOVE RCAPS-NUM-RCAP TO ENT-NRRCAP */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, REG_ENTRADA1.ENT_NRRCAP);

                    /*" -1519- MOVE RCAPS-NUM-TITULO TO ENT-NUM-TITULO */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_TITULO, REG_ENTRADA1.ENT_NUM_TITULO);

                    /*" -1521- MOVE RCAPS-DATA-CADASTRAMENTO TO ENT-DATA-RCAP */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO, REG_ENTRADA1.ENT_DATA_RCAP);

                    /*" -1522- MOVE RCAPCOMP-BCO-AVISO TO ENT-BCOAVISO */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, REG_ENTRADA1.ENT_BCOAVISO);

                    /*" -1523- MOVE RCAPCOMP-AGE-AVISO TO ENT-AGEAVISO */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, REG_ENTRADA1.ENT_AGEAVISO);

                    /*" -1525- MOVE RCAPCOMP-NUM-AVISO-CREDITO TO ENT-NRAVISO */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, REG_ENTRADA1.ENT_NRAVISO);

                    /*" -1526- PERFORM R0210-00-UPDATE-HISCONPA */

                    R0210_00_UPDATE_HISCONPA_SECTION();

                    /*" -1526- PERFORM R0220-00-UPDATE-COBHISVI. */

                    R0220_00_UPDATE_COBHISVI_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0190-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R0190_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -1504- EXEC SQL SELECT C.NUM_RCAP ,C.VAL_RCAP ,C.DATA_CADASTRAMENTO ,C.SIT_REGISTRO ,C.COD_OPERACAO ,C.NUM_TITULO ,B.BCO_AVISO ,B.AGE_AVISO ,B.NUM_AVISO_CREDITO INTO :RCAPS-NUM-RCAP ,:RCAPS-VAL-RCAP ,:RCAPS-DATA-CADASTRAMENTO ,:RCAPS-SIT-REGISTRO ,:RCAPS-COD-OPERACAO ,:RCAPS-NUM-TITULO ,:RCAPCOMP-BCO-AVISO ,:RCAPCOMP-AGE-AVISO ,:RCAPCOMP-NUM-AVISO-CREDITO FROM SEGUROS.COBER_HIST_VIDAZUL A ,SEGUROS.RCAP_COMPLEMENTAR B ,SEGUROS.RCAPS C WHERE A.NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO AND A.NUM_PARCELA = :COBHISVI-NUM-PARCELA AND B.BCO_AVISO = A.BCO_AVISO AND B.AGE_AVISO = A.AGE_AVISO AND B.NUM_AVISO_CREDITO = A.NUM_AVISO_CREDITO AND B.VAL_RCAP = A.PRM_TOTAL AND B.SIT_REGISTRO = '0' AND C.COD_FONTE = B.COD_FONTE AND C.NUM_RCAP = B.NUM_RCAP AND C.NUM_APOLICE = :RCAPS-NUM-APOLICE AND C.NUM_ENDOSSO = :RCAPS-NUM-ENDOSSO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0190_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R0190_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                COBHISVI_NUM_CERTIFICADO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO.ToString(),
                COBHISVI_NUM_PARCELA = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.ToString(),
                RCAPS_NUM_APOLICE = RCAPS.DCLRCAPS.RCAPS_NUM_APOLICE.ToString(),
                RCAPS_NUM_ENDOSSO = RCAPS.DCLRCAPS.RCAPS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0190_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r0190_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPS_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0190_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-UPDATE-HISCONPA-SECTION */
        private void R0210_00_UPDATE_HISCONPA_SECTION()
        {
            /*" -1537- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", W.WABEND.WNR_EXEC_SQL);

            /*" -1540- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1542- MOVE ENT-NUM-CERTIFICADO TO HISCONPA-NUM-CERTIFICADO. */
            _.Move(REG_ENTRADA1.ENT_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -1544- MOVE ENT-NUM-PARCELA TO HISCONPA-NUM-PARCELA. */
            _.Move(REG_ENTRADA1.ENT_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -1546- MOVE ENT-OCORR-HISTORICO TO HISCONPA-OCORR-HISTORICO. */
            _.Move(REG_ENTRADA1.ENT_OCORR_HISTORICO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);

            /*" -1550- MOVE RCAPS-NUM-TITULO TO HISCONPA-NUM-TITULO. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_TITULO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO);

            /*" -1557- PERFORM R0210_00_UPDATE_HISCONPA_DB_UPDATE_1 */

            R0210_00_UPDATE_HISCONPA_DB_UPDATE_1();

            /*" -1562- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1563- DISPLAY 'R0210-00 - PROBLEMAS UPDATE (HISCONPA)' */
                _.Display($"R0210-00 - PROBLEMAS UPDATE (HISCONPA)");

                /*" -1563- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0210-00-UPDATE-HISCONPA-DB-UPDATE-1 */
        public void R0210_00_UPDATE_HISCONPA_DB_UPDATE_1()
        {
            /*" -1557- EXEC SQL UPDATE SEGUROS.HIST_CONT_PARCELVA SET NUM_TITULO = :HISCONPA-NUM-TITULO WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA AND OCORR_HISTORICO = :HISCONPA-OCORR-HISTORICO END-EXEC. */

            var r0210_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1 = new R0210_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1()
            {
                HISCONPA_NUM_TITULO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO.ToString(),
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_OCORR_HISTORICO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            R0210_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1.Execute(r0210_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-UPDATE-COBHISVI-SECTION */
        private void R0220_00_UPDATE_COBHISVI_SECTION()
        {
            /*" -1574- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", W.WABEND.WNR_EXEC_SQL);

            /*" -1577- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1583- PERFORM R0220_00_UPDATE_COBHISVI_DB_UPDATE_1 */

            R0220_00_UPDATE_COBHISVI_DB_UPDATE_1();

            /*" -1588- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1589- DISPLAY 'R0220-00 - PROBLEMAS UPDATE (COBHISVI)' */
                _.Display($"R0220-00 - PROBLEMAS UPDATE (COBHISVI)");

                /*" -1590- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1591- ELSE */
            }
            else
            {


                /*" -1592- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1592- ADD 1 TO UP-COBHISVI. */
                    W.UP_COBHISVI.Value = W.UP_COBHISVI + 1;
                }

            }


        }

        [StopWatch]
        /*" R0220-00-UPDATE-COBHISVI-DB-UPDATE-1 */
        public void R0220_00_UPDATE_COBHISVI_DB_UPDATE_1()
        {
            /*" -1583- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET NUM_TITULO = :HISCONPA-NUM-TITULO WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA END-EXEC. */

            var r0220_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1 = new R0220_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1()
            {
                HISCONPA_NUM_TITULO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO.ToString(),
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            R0220_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1.Execute(r0220_00_UPDATE_COBHISVI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-MOVE-DADOS-ENTRADA-SECTION */
        private void R0260_00_MOVE_DADOS_ENTRADA_SECTION()
        {
            /*" -1603- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", W.WABEND.WNR_EXEC_SQL);

            /*" -1606- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1608- IF ENT-DTINIEMI LESS WHOST-DATA15 AND ENT-TIPO-ENDOSSO EQUAL '1' */

            if (REG_ENTRADA1.ENT_DTINIEMI < WHOST_DATA15 && REG_ENTRADA1.ENT_TIPO_ENDOSSO == "1")
            {

                /*" -1610- MOVE ENT-DATA-VENCIMENTO TO CALENDAR-DATA-CALENDARIO */
                _.Move(REG_ENTRADA1.ENT_DATA_VENCIMENTO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

                /*" -1613- PERFORM R0270-00-SELECT-CALENDAR. */

                R0270_00_SELECT_CALENDAR_SECTION();
            }


            /*" -1616- IF SISTEMAS-DATA-MOV-ABERTO LESS ENT-DTINIEMI AND ENT-TIPO-ENDOSSO EQUAL '1' AND ENT-NUM-PARCELA GREATER 1 */

            if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO < REG_ENTRADA1.ENT_DTINIEMI && REG_ENTRADA1.ENT_TIPO_ENDOSSO == "1" && REG_ENTRADA1.ENT_NUM_PARCELA > 1)
            {

                /*" -1619- PERFORM R0360-00-SELECT-HISCONPA. */

                R0360_00_SELECT_HISCONPA_SECTION();
            }


            /*" -1622- MOVE ENT-PROGRAMA TO LD01-PROGRAMA SOR-PROGRAMA. */
            _.Move(REG_ENTRADA1.ENT_PROGRAMA, ARQUIVOS_SAIDA.LD01.LD01_PROGRAMA, REG_SVA0141B.SOR_PROGRAMA);

            /*" -1625- MOVE ENT-TIPO-ENDOSSO TO LD01-TIPO-ENDOSSO SOR-TIPO-ENDOSSO. */
            _.Move(REG_ENTRADA1.ENT_TIPO_ENDOSSO, ARQUIVOS_SAIDA.LD01.LD01_TIPO_ENDOSSO, REG_SVA0141B.SOR_TIPO_ENDOSSO);

            /*" -1628- MOVE ENT-NUM-CERTIFICADO TO LD01-NUM-CERTIFICADO SOR-NUM-CERTIFICADO. */
            _.Move(REG_ENTRADA1.ENT_NUM_CERTIFICADO, ARQUIVOS_SAIDA.LD01.LD01_NUM_CERTIFICADO, REG_SVA0141B.SOR_NUM_CERTIFICADO);

            /*" -1631- MOVE ENT-NUM-PARCELA TO LD01-NUM-PARCELA SOR-NUM-PARCELA. */
            _.Move(REG_ENTRADA1.ENT_NUM_PARCELA, ARQUIVOS_SAIDA.LD01.LD01_NUM_PARCELA, REG_SVA0141B.SOR_NUM_PARCELA);

            /*" -1634- MOVE ENT-NUM-TITULO TO LD01-NUM-TITULO SOR-NUM-TITULO. */
            _.Move(REG_ENTRADA1.ENT_NUM_TITULO, ARQUIVOS_SAIDA.LD01.LD01_NUM_TITULO, REG_SVA0141B.SOR_NUM_TITULO);

            /*" -1637- MOVE ENT-OCORR-HISTORICO TO LD01-OCORR-HISTORICO SOR-OCORR-HISTORICO. */
            _.Move(REG_ENTRADA1.ENT_OCORR_HISTORICO, ARQUIVOS_SAIDA.LD01.LD01_OCORR_HISTORICO, REG_SVA0141B.SOR_OCORR_HISTORICO);

            /*" -1640- MOVE ENT-NUM-APOLICE TO LD01-NUM-APOLICE SOR-NUM-APOLICE. */
            _.Move(REG_ENTRADA1.ENT_NUM_APOLICE, ARQUIVOS_SAIDA.LD01.LD01_NUM_APOLICE, REG_SVA0141B.SOR_NUM_APOLICE);

            /*" -1643- MOVE ENT-COD-SUBGRUPO TO LD01-COD-SUBGRUPO SOR-COD-SUBGRUPO. */
            _.Move(REG_ENTRADA1.ENT_COD_SUBGRUPO, ARQUIVOS_SAIDA.LD01.LD01_COD_SUBGRUPO, REG_SVA0141B.SOR_COD_SUBGRUPO);

            /*" -1646- MOVE ENT-COD-FONTE TO LD01-COD-FONTE SOR-COD-FONTE. */
            _.Move(REG_ENTRADA1.ENT_COD_FONTE, ARQUIVOS_SAIDA.LD01.LD01_COD_FONTE, REG_SVA0141B.SOR_COD_FONTE);

            /*" -1649- MOVE ENT-ORGAO TO LD01-ORGAO SOR-ORGAO. */
            _.Move(REG_ENTRADA1.ENT_ORGAO, ARQUIVOS_SAIDA.LD01.LD01_ORGAO, REG_SVA0141B.SOR_ORGAO);

            /*" -1652- MOVE ENT-RAMO TO LD01-RAMO SOR-RAMO. */
            _.Move(REG_ENTRADA1.ENT_RAMO, ARQUIVOS_SAIDA.LD01.LD01_RAMO, REG_SVA0141B.SOR_RAMO);

            /*" -1655- MOVE ENT-MODALIDA TO LD01-MODALIDA SOR-MODALIDA. */
            _.Move(REG_ENTRADA1.ENT_MODALIDA, ARQUIVOS_SAIDA.LD01.LD01_MODALIDA, REG_SVA0141B.SOR_MODALIDA);

            /*" -1658- MOVE ENT-PREMIO-VG TO LD01-PREMIO-VG SOR-PREMIO-VG. */
            _.Move(REG_ENTRADA1.ENT_PREMIO_VG, ARQUIVOS_SAIDA.LD01.LD01_PREMIO_VG, REG_SVA0141B.SOR_PREMIO_VG);

            /*" -1661- MOVE ENT-PREMIO-AP TO LD01-PREMIO-AP SOR-PREMIO-AP. */
            _.Move(REG_ENTRADA1.ENT_PREMIO_AP, ARQUIVOS_SAIDA.LD01.LD01_PREMIO_AP, REG_SVA0141B.SOR_PREMIO_AP);

            /*" -1664- MOVE ENT-DATA-MOVIMENTO TO LD01-DATA-MOVIMENTO SOR-DATA-MOVIMENTO. */
            _.Move(REG_ENTRADA1.ENT_DATA_MOVIMENTO, ARQUIVOS_SAIDA.LD01.LD01_DATA_MOVIMENTO, REG_SVA0141B.SOR_DATA_MOVIMENTO);

            /*" -1667- MOVE ENT-SIT-REGISTRO TO LD01-SIT-REGISTRO SOR-SIT-REGISTRO. */
            _.Move(REG_ENTRADA1.ENT_SIT_REGISTRO, ARQUIVOS_SAIDA.LD01.LD01_SIT_REGISTRO, REG_SVA0141B.SOR_SIT_REGISTRO);

            /*" -1670- MOVE ENT-COD-OPERACAO TO LD01-COD-OPERACAO SOR-COD-OPERACAO. */
            _.Move(REG_ENTRADA1.ENT_COD_OPERACAO, ARQUIVOS_SAIDA.LD01.LD01_COD_OPERACAO, REG_SVA0141B.SOR_COD_OPERACAO);

            /*" -1673- MOVE ENT-COD-PRODUTO TO LD01-COD-PRODUTO SOR-COD-PRODUTO. */
            _.Move(REG_ENTRADA1.ENT_COD_PRODUTO, ARQUIVOS_SAIDA.LD01.LD01_COD_PRODUTO, REG_SVA0141B.SOR_COD_PRODUTO);

            /*" -1676- MOVE ENT-DATA-QUITACAO TO LD01-DATA-QUITACAO SOR-DATA-QUITACAO. */
            _.Move(REG_ENTRADA1.ENT_DATA_QUITACAO, ARQUIVOS_SAIDA.LD01.LD01_DATA_QUITACAO, REG_SVA0141B.SOR_DATA_QUITACAO);

            /*" -1679- MOVE ENT-SITUACAO TO LD01-SITUACAO SOR-SITUACAO. */
            _.Move(REG_ENTRADA1.ENT_SITUACAO, ARQUIVOS_SAIDA.LD01.LD01_SITUACAO, REG_SVA0141B.SOR_SITUACAO);

            /*" -1682- MOVE ENT-OCORHIST TO LD01-OCORHIST SOR-OCORHIST. */
            _.Move(REG_ENTRADA1.ENT_OCORHIST, ARQUIVOS_SAIDA.LD01.LD01_OCORHIST, REG_SVA0141B.SOR_OCORHIST);

            /*" -1685- MOVE ENT-DTPROXVEN TO LD01-DTPROXVEN SOR-DTPROXVEN. */
            _.Move(REG_ENTRADA1.ENT_DTPROXVEN, ARQUIVOS_SAIDA.LD01.LD01_DTPROXVEN, REG_SVA0141B.SOR_DTPROXVEN);

            /*" -1688- MOVE ENT-CLIENTE TO LD01-CLIENTE SOR-CLIENTE. */
            _.Move(REG_ENTRADA1.ENT_CLIENTE, ARQUIVOS_SAIDA.LD01.LD01_CLIENTE, REG_SVA0141B.SOR_CLIENTE);

            /*" -1691- MOVE ENT-CGCCPF TO LD01-CGCCPF SOR-CGCCPF. */
            _.Move(REG_ENTRADA1.ENT_CGCCPF, ARQUIVOS_SAIDA.LD01.LD01_CGCCPF, REG_SVA0141B.SOR_CGCCPF);

            /*" -1694- MOVE ENT-DATA-NASCIMENTO TO LD01-DATA-NASCIMENTO SOR-DATA-NASCIMENTO. */
            _.Move(REG_ENTRADA1.ENT_DATA_NASCIMENTO, ARQUIVOS_SAIDA.LD01.LD01_DATA_NASCIMENTO, REG_SVA0141B.SOR_DATA_NASCIMENTO);

            /*" -1697- MOVE ENT-TIPO-PESSOA TO LD01-TIPO-PESSOA SOR-TIPO-PESSOA. */
            _.Move(REG_ENTRADA1.ENT_TIPO_PESSOA, ARQUIVOS_SAIDA.LD01.LD01_TIPO_PESSOA, REG_SVA0141B.SOR_TIPO_PESSOA);

            /*" -1700- MOVE ENT-PRODUTO TO LD01-PRODUTO SOR-PRODUTO. */
            _.Move(REG_ENTRADA1.ENT_PRODUTO, ARQUIVOS_SAIDA.LD01.LD01_PRODUTO, REG_SVA0141B.SOR_PRODUTO);

            /*" -1703- MOVE ENT-PRODEMIS TO LD01-PRODEMIS SOR-PRODEMIS. */
            _.Move(REG_ENTRADA1.ENT_PRODEMIS, ARQUIVOS_SAIDA.LD01.LD01_PRODEMIS, REG_SVA0141B.SOR_PRODEMIS);

            /*" -1706- MOVE ENT-DTINIEMI TO LD01-DTINIEMI SOR-DTINIEMI. */
            _.Move(REG_ENTRADA1.ENT_DTINIEMI, ARQUIVOS_SAIDA.LD01.LD01_DTINIEMI, REG_SVA0141B.SOR_DTINIEMI);

            /*" -1709- MOVE ENT-DTTEREMI TO LD01-DTTEREMI SOR-DTTEREMI. */
            _.Move(REG_ENTRADA1.ENT_DTTEREMI, ARQUIVOS_SAIDA.LD01.LD01_DTTEREMI, REG_SVA0141B.SOR_DTTEREMI);

            /*" -1712- MOVE ENT-ESTR-COBR TO LD01-ESTR-COBR SOR-ESTR-COBR. */
            _.Move(REG_ENTRADA1.ENT_ESTR_COBR, ARQUIVOS_SAIDA.LD01.LD01_ESTR_COBR, REG_SVA0141B.SOR_ESTR_COBR);

            /*" -1715- MOVE ENT-ORIG-PRODU TO LD01-ORIG-PRODU SOR-ORIG-PRODU. */
            _.Move(REG_ENTRADA1.ENT_ORIG_PRODU, ARQUIVOS_SAIDA.LD01.LD01_ORIG_PRODU, REG_SVA0141B.SOR_ORIG_PRODU);

            /*" -1718- MOVE ENT-IND-IOF TO LD01-IND-IOF SOR-IND-IOF. */
            _.Move(REG_ENTRADA1.ENT_IND_IOF, ARQUIVOS_SAIDA.LD01.LD01_IND_IOF, REG_SVA0141B.SOR_IND_IOF);

            /*" -1721- MOVE ENT-PER-IOF TO LD01-PER-IOF SOR-PER-IOF. */
            _.Move(REG_ENTRADA1.ENT_PER_IOF, ARQUIVOS_SAIDA.LD01.LD01_PER_IOF, REG_SVA0141B.SOR_PER_IOF);

            /*" -1724- MOVE ENT-DATA-VENCIMENTO TO LD01-DATA-VENCIMENTO SOR-DATA-VENCIMENTO. */
            _.Move(REG_ENTRADA1.ENT_DATA_VENCIMENTO, ARQUIVOS_SAIDA.LD01.LD01_DATA_VENCIMENTO, REG_SVA0141B.SOR_DATA_VENCIMENTO);

            /*" -1727- MOVE ENT-DATA-INIVIGENCIA TO LD01-DATA-INIVIGENCIA SOR-DATA-INIVIGENCIA. */
            _.Move(REG_ENTRADA1.ENT_DATA_INIVIGENCIA, ARQUIVOS_SAIDA.LD01.LD01_DATA_INIVIGENCIA, REG_SVA0141B.SOR_DATA_INIVIGENCIA);

            /*" -1730- MOVE ENT-DATA-TERVIGENCIA TO LD01-DATA-TERVIGENCIA SOR-DATA-TERVIGENCIA. */
            _.Move(REG_ENTRADA1.ENT_DATA_TERVIGENCIA, ARQUIVOS_SAIDA.LD01.LD01_DATA_TERVIGENCIA, REG_SVA0141B.SOR_DATA_TERVIGENCIA);

            /*" -1733- MOVE ENT-OPCAO-PAGAMENTO TO LD01-OPCAO-PAGAMENTO SOR-OPCAO-PAGAMENTO. */
            _.Move(REG_ENTRADA1.ENT_OPCAO_PAGAMENTO, ARQUIVOS_SAIDA.LD01.LD01_OPCAO_PAGAMENTO, REG_SVA0141B.SOR_OPCAO_PAGAMENTO);

            /*" -1736- MOVE ENT-PERI-PAGAMENTO TO LD01-PERI-PAGAMENTO SOR-PERI-PAGAMENTO. */
            _.Move(REG_ENTRADA1.ENT_PERI_PAGAMENTO, ARQUIVOS_SAIDA.LD01.LD01_PERI_PAGAMENTO, REG_SVA0141B.SOR_PERI_PAGAMENTO);

            /*" -1739- MOVE ENT-DIA-DEBITO TO LD01-DIA-DEBITO SOR-DIA-DEBITO. */
            _.Move(REG_ENTRADA1.ENT_DIA_DEBITO, ARQUIVOS_SAIDA.LD01.LD01_DIA_DEBITO, REG_SVA0141B.SOR_DIA_DEBITO);

            /*" -1742- MOVE ENT-RCAPS TO LD01-RCAPS SOR-RCAPS. */
            _.Move(REG_ENTRADA1.ENT_RCAPS, ARQUIVOS_SAIDA.LD01.LD01_RCAPS, REG_SVA0141B.SOR_RCAPS);

            /*" -1745- MOVE ENT-SITRCAP TO LD01-SITRCAP SOR-SITRCAP. */
            _.Move(REG_ENTRADA1.ENT_SITRCAP, ARQUIVOS_SAIDA.LD01.LD01_SITRCAP, REG_SVA0141B.SOR_SITRCAP);

            /*" -1748- MOVE ENT-OPERCAP TO LD01-OPERCAP SOR-OPERCAP. */
            _.Move(REG_ENTRADA1.ENT_OPERCAP, ARQUIVOS_SAIDA.LD01.LD01_OPERCAP, REG_SVA0141B.SOR_OPERCAP);

            /*" -1751- MOVE ENT-VAL-RCAP TO LD01-VAL-RCAP SOR-VAL-RCAP. */
            _.Move(REG_ENTRADA1.ENT_VAL_RCAP, ARQUIVOS_SAIDA.LD01.LD01_VAL_RCAP, REG_SVA0141B.SOR_VAL_RCAP);

            /*" -1754- MOVE ENT-MOVIMCOB TO LD01-MOVIMCOB SOR-MOVIMCOB. */
            _.Move(REG_ENTRADA1.ENT_MOVIMCOB, ARQUIVOS_SAIDA.LD01.LD01_MOVIMCOB, REG_SVA0141B.SOR_MOVIMCOB);

            /*" -1757- MOVE ENT-SITMCOB TO LD01-SITMCOB SOR-SITMCOB. */
            _.Move(REG_ENTRADA1.ENT_SITMCOB, ARQUIVOS_SAIDA.LD01.LD01_SITMCOB, REG_SVA0141B.SOR_SITMCOB);

            /*" -1760- MOVE ENT-VAL-TITULO TO LD01-VAL-TITULO SOR-VAL-TITULO. */
            _.Move(REG_ENTRADA1.ENT_VAL_TITULO, ARQUIVOS_SAIDA.LD01.LD01_VAL_TITULO, REG_SVA0141B.SOR_VAL_TITULO);

            /*" -1763- MOVE ENT-SITMDEB TO LD01-SITMDEB SOR-SITMDEB. */
            _.Move(REG_ENTRADA1.ENT_SITMDEB, ARQUIVOS_SAIDA.LD01.LD01_SITMDEB, REG_SVA0141B.SOR_SITMDEB);

            /*" -1766- MOVE ENT-MOVDEBCE TO LD01-MOVDEBCE SOR-MOVDEBCE. */
            _.Move(REG_ENTRADA1.ENT_MOVDEBCE, ARQUIVOS_SAIDA.LD01.LD01_MOVDEBCE, REG_SVA0141B.SOR_MOVDEBCE);

            /*" -1769- MOVE ENT-CONVENIO TO LD01-CONVENIO SOR-CONVENIO. */
            _.Move(REG_ENTRADA1.ENT_CONVENIO, ARQUIVOS_SAIDA.LD01.LD01_CONVENIO, REG_SVA0141B.SOR_CONVENIO);

            /*" -1772- MOVE ENT-VALOR-DEBITO TO LD01-VALOR-DEBITO SOR-VALOR-DEBITO. */
            _.Move(REG_ENTRADA1.ENT_VALOR_DEBITO, ARQUIVOS_SAIDA.LD01.LD01_VALOR_DEBITO, REG_SVA0141B.SOR_VALOR_DEBITO);

            /*" -1775- MOVE ENT-VALVGAP TO LD01-VALVGAP SOR-VALVGAP. */
            _.Move(REG_ENTRADA1.ENT_VALVGAP, ARQUIVOS_SAIDA.LD01.LD01_VALVGAP, REG_SVA0141B.SOR_VALVGAP);

            /*" -1778- MOVE ENT-DTINIVIG TO LD01-DTINIVIG SOR-DTINIVIG. */
            _.Move(REG_ENTRADA1.ENT_DTINIVIG, ARQUIVOS_SAIDA.LD01.LD01_DTINIVIG, REG_SVA0141B.SOR_DTINIVIG);

            /*" -1781- MOVE ENT-DATA-ADMISSAO TO LD01-DATA-ADMISSAO SOR-DATA-ADMISSAO. */
            _.Move(REG_ENTRADA1.ENT_DATA_ADMISSAO, ARQUIVOS_SAIDA.LD01.LD01_DATA_ADMISSAO, REG_SVA0141B.SOR_DATA_ADMISSAO);

            /*" -1784- MOVE ENT-ADICIEA TO LD01-ADICIEA SOR-ADICIEA. */
            _.Move(REG_ENTRADA1.ENT_ADICIEA, ARQUIVOS_SAIDA.LD01.LD01_ADICIEA, REG_SVA0141B.SOR_ADICIEA);

            /*" -1787- MOVE ENT-ADICIPA TO LD01-ADICIPA SOR-ADICIPA. */
            _.Move(REG_ENTRADA1.ENT_ADICIPA, ARQUIVOS_SAIDA.LD01.LD01_ADICIPA, REG_SVA0141B.SOR_ADICIPA);

            /*" -1790- MOVE ENT-ADICIPD TO LD01-ADICIPD SOR-ADICIPD. */
            _.Move(REG_ENTRADA1.ENT_ADICIPD, ARQUIVOS_SAIDA.LD01.LD01_ADICIPD, REG_SVA0141B.SOR_ADICIPD);

            /*" -1793- MOVE ENT-INIZERO TO LD01-INIZERO SOR-INIZERO. */
            _.Move(REG_ENTRADA1.ENT_INIZERO, ARQUIVOS_SAIDA.LD01.LD01_INIZERO, REG_SVA0141B.SOR_INIZERO);

            /*" -1796- MOVE ENT-TERZERO TO LD01-TERZERO SOR-TERZERO. */
            _.Move(REG_ENTRADA1.ENT_TERZERO, ARQUIVOS_SAIDA.LD01.LD01_TERZERO, REG_SVA0141B.SOR_TERZERO);

            /*" -1799- MOVE ENT-BCOAVISO TO LD01-BCOAVISO SOR-BCOAVISO. */
            _.Move(REG_ENTRADA1.ENT_BCOAVISO, ARQUIVOS_SAIDA.LD01.LD01_BCOAVISO, REG_SVA0141B.SOR_BCOAVISO);

            /*" -1802- MOVE ENT-AGEAVISO TO LD01-AGEAVISO SOR-AGEAVISO. */
            _.Move(REG_ENTRADA1.ENT_AGEAVISO, ARQUIVOS_SAIDA.LD01.LD01_AGEAVISO, REG_SVA0141B.SOR_AGEAVISO);

            /*" -1805- MOVE ENT-NRAVISO TO LD01-NRAVISO SOR-NRAVISO. */
            _.Move(REG_ENTRADA1.ENT_NRAVISO, ARQUIVOS_SAIDA.LD01.LD01_NRAVISO, REG_SVA0141B.SOR_NRAVISO);

            /*" -1808- MOVE ENT-IMPMORNATU TO LD01-IMPMORNATU SOR-IMPMORNATU. */
            _.Move(REG_ENTRADA1.ENT_IMPMORNATU, ARQUIVOS_SAIDA.LD01.LD01_IMPMORNATU, REG_SVA0141B.SOR_IMPMORNATU);

            /*" -1811- MOVE ENT-IMPMORACID TO LD01-IMPMORACID SOR-IMPMORACID. */
            _.Move(REG_ENTRADA1.ENT_IMPMORACID, ARQUIVOS_SAIDA.LD01.LD01_IMPMORACID, REG_SVA0141B.SOR_IMPMORACID);

            /*" -1814- MOVE ENT-IMPINVPERM TO LD01-IMPINVPERM SOR-IMPINVPERM. */
            _.Move(REG_ENTRADA1.ENT_IMPINVPERM, ARQUIVOS_SAIDA.LD01.LD01_IMPINVPERM, REG_SVA0141B.SOR_IMPINVPERM);

            /*" -1817- MOVE ENT-IMPAMDS TO LD01-IMPAMDS SOR-IMPAMDS. */
            _.Move(REG_ENTRADA1.ENT_IMPAMDS, ARQUIVOS_SAIDA.LD01.LD01_IMPAMDS, REG_SVA0141B.SOR_IMPAMDS);

            /*" -1820- MOVE ENT-IMPDH TO LD01-IMPDH SOR-IMPDH. */
            _.Move(REG_ENTRADA1.ENT_IMPDH, ARQUIVOS_SAIDA.LD01.LD01_IMPDH, REG_SVA0141B.SOR_IMPDH);

            /*" -1823- MOVE ENT-IMPDIT TO LD01-IMPDIT SOR-IMPDIT. */
            _.Move(REG_ENTRADA1.ENT_IMPDIT, ARQUIVOS_SAIDA.LD01.LD01_IMPDIT, REG_SVA0141B.SOR_IMPDIT);

            /*" -1826- MOVE ENT-PRMDIT TO LD01-PRMDIT SOR-PRMDIT. */
            _.Move(REG_ENTRADA1.ENT_PRMDIT, ARQUIVOS_SAIDA.LD01.LD01_PRMDIT, REG_SVA0141B.SOR_PRMDIT);

            /*" -1829- MOVE ENT-IMPRTO TO LD01-IMPRTO SOR-IMPRTO. */
            _.Move(REG_ENTRADA1.ENT_IMPRTO, ARQUIVOS_SAIDA.LD01.LD01_IMPRTO, REG_SVA0141B.SOR_IMPRTO);

            /*" -1832- MOVE ENT-PRMRTO TO LD01-PRMRTO SOR-PRMRTO. */
            _.Move(REG_ENTRADA1.ENT_PRMRTO, ARQUIVOS_SAIDA.LD01.LD01_PRMRTO, REG_SVA0141B.SOR_PRMRTO);

            /*" -1835- MOVE ENT-APOLICE TO LD01-APOLICE SOR-APOLICE. */
            _.Move(REG_ENTRADA1.ENT_APOLICE, ARQUIVOS_SAIDA.LD01.LD01_APOLICE, REG_SVA0141B.SOR_APOLICE);

            /*" -1838- MOVE ENT-ENDOSSO TO LD01-ENDOSSO SOR-ENDOSSO. */
            _.Move(REG_ENTRADA1.ENT_ENDOSSO, ARQUIVOS_SAIDA.LD01.LD01_ENDOSSO, REG_SVA0141B.SOR_ENDOSSO);

            /*" -1841- MOVE ENT-RAMO-EMISSOR TO LD01-RAMO-EMISSOR SOR-RAMO-EMISSOR. */
            _.Move(REG_ENTRADA1.ENT_RAMO_EMISSOR, ARQUIVOS_SAIDA.LD01.LD01_RAMO_EMISSOR, REG_SVA0141B.SOR_RAMO_EMISSOR);

            /*" -1844- MOVE ENT-SUBGRUPO TO LD01-SUBGRUPO SOR-SUBGRUPO. */
            _.Move(REG_ENTRADA1.ENT_SUBGRUPO, ARQUIVOS_SAIDA.LD01.LD01_SUBGRUPO, REG_SVA0141B.SOR_SUBGRUPO);

            /*" -1847- MOVE ENT-FONTE TO LD01-FONTE SOR-FONTE. */
            _.Move(REG_ENTRADA1.ENT_FONTE, ARQUIVOS_SAIDA.LD01.LD01_FONTE, REG_SVA0141B.SOR_FONTE);

            /*" -1850- MOVE ENT-PARVG082 TO LD01-PARVG082 SOR-PARVG082. */
            _.Move(REG_ENTRADA1.ENT_PARVG082, ARQUIVOS_SAIDA.LD01.LD01_PARVG082, REG_SVA0141B.SOR_PARVG082);

            /*" -1853- MOVE ENT-VALVG082 TO LD01-VALVG082 SOR-VALVG082. */
            _.Move(REG_ENTRADA1.ENT_VALVG082, ARQUIVOS_SAIDA.LD01.LD01_VALVG082, REG_SVA0141B.SOR_VALVG082);

            /*" -1855- MOVE ENT-OCOVG082 TO SOR-OCOVG082. */
            _.Move(REG_ENTRADA1.ENT_OCOVG082, REG_SVA0141B.SOR_OCOVG082);

            /*" -1858- MOVE ENT-APOLICOB TO LD01-APOLICOB SOR-APOLICOB. */
            _.Move(REG_ENTRADA1.ENT_APOLICOB, ARQUIVOS_SAIDA.LD01.LD01_APOLICOB, REG_SVA0141B.SOR_APOLICOB);

            /*" -1861- MOVE ENT-NRRCAP TO LD01-NRRCAP SOR-NRRCAP. */
            _.Move(REG_ENTRADA1.ENT_NRRCAP, ARQUIVOS_SAIDA.LD01.LD01_NRRCAP, REG_SVA0141B.SOR_NRRCAP);

            /*" -1864- MOVE ENT-DATA-RCAP TO LD01-DATA-RCAP SOR-DATA-RCAP. */
            _.Move(REG_ENTRADA1.ENT_DATA_RCAP, ARQUIVOS_SAIDA.LD01.LD01_DATA_RCAP, REG_SVA0141B.SOR_DATA_RCAP);

            /*" -1867- MOVE ENT-SALDO TO LD01-SALDO SOR-SALDO. */
            _.Move(REG_ENTRADA1.ENT_SALDO, ARQUIVOS_SAIDA.LD01.LD01_SALDO, REG_SVA0141B.SOR_SALDO);

            /*" -1870- MOVE ENT-ITEM TO LD01-ITEM SOR-ITEM. */
            _.Move(REG_ENTRADA1.ENT_ITEM, ARQUIVOS_SAIDA.LD01.LD01_ITEM, REG_SVA0141B.SOR_ITEM);

            /*" -1873- MOVE ENT-VLPREMIO TO LD01-VLPREMIO SOR-VLPREMIO. */
            _.Move(REG_ENTRADA1.ENT_VLPREMIO, ARQUIVOS_SAIDA.LD01.LD01_VLPREMIO, REG_SVA0141B.SOR_VLPREMIO);

            /*" -1876- MOVE ENT-NRSEQ TO LD01-NRSEQ SOR-NRSEQ. */
            _.Move(REG_ENTRADA1.ENT_NRSEQ, ARQUIVOS_SAIDA.LD01.LD01_NRSEQ, REG_SVA0141B.SOR_NRSEQ);

            /*" -1877- MOVE SPACES TO LD01-OBSERVA. */
            _.Move("", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0270-00-SELECT-CALENDAR-SECTION */
        private void R0270_00_SELECT_CALENDAR_SECTION()
        {
            /*" -1888- MOVE '0270' TO WNR-EXEC-SQL. */
            _.Move("0270", W.WABEND.WNR_EXEC_SQL);

            /*" -1891- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1900- PERFORM R0270_00_SELECT_CALENDAR_DB_SELECT_1 */

            R0270_00_SELECT_CALENDAR_DB_SELECT_1();

            /*" -1904- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1907- GO TO R0270-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1908- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1910- DISPLAY 'R0270-00 - PROBLEMAS NO SELECT(CALENDAR)' ' DATA        = ' CALENDAR-DATA-CALENDARIO */

                $"R0270-00 - PROBLEMAS NO SELECT(CALENDAR) DATA        = {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}"
                .Display();

                /*" -1913- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1915- MOVE CALENDAR-DATA-CALENDARIO TO WDATA-REL. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, W.WDATA_REL);

            /*" -1916- MOVE 01 TO WDAT-REL-DIA. */
            _.Move(01, W.FILLER_87.WDAT_REL_DIA);

            /*" -1917- MOVE WDATA-REL TO ENT-DTINIEMI. */
            _.Move(W.WDATA_REL, REG_ENTRADA1.ENT_DTINIEMI);

            /*" -1918- MOVE CALENDAR-DTH-ULT-DIA-MES TO ENT-DTTEREMI. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES, REG_ENTRADA1.ENT_DTTEREMI);

        }

        [StopWatch]
        /*" R0270-00-SELECT-CALENDAR-DB-SELECT-1 */
        public void R0270_00_SELECT_CALENDAR_DB_SELECT_1()
        {
            /*" -1900- EXEC SQL SELECT DATA_CALENDARIO ,DTH_ULT_DIA_MES INTO :CALENDAR-DATA-CALENDARIO ,:CALENDAR-DTH-ULT-DIA-MES FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0270_00_SELECT_CALENDAR_DB_SELECT_1_Query1 = new R0270_00_SELECT_CALENDAR_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R0270_00_SELECT_CALENDAR_DB_SELECT_1_Query1.Execute(r0270_00_SELECT_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.CALENDAR_DTH_ULT_DIA_MES, CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-UPDATE-ENDOSSOS-SECTION */
        private void R0300_00_UPDATE_ENDOSSOS_SECTION()
        {
            /*" -1929- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -1932- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1934- MOVE ENT-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(REG_ENTRADA1.ENT_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -1936- MOVE ZEROS TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -1940- MOVE SOR-DTINIEMI TO ENDOSSOS-DATA-INIVIGENCIA. */
            _.Move(REG_SVA0141B.SOR_DTINIEMI, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

            /*" -1946- PERFORM R0300_00_UPDATE_ENDOSSOS_DB_UPDATE_1 */

            R0300_00_UPDATE_ENDOSSOS_DB_UPDATE_1();

            /*" -1951- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1952- DISPLAY 'R0300-00 - PROBLEMAS UPDATE (ENDOSSOS)' */
                _.Display($"R0300-00 - PROBLEMAS UPDATE (ENDOSSOS)");

                /*" -1953- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1954- ELSE */
            }
            else
            {


                /*" -1954- PERFORM R0310-00-UPDATE-APOLICOB. */

                R0310_00_UPDATE_APOLICOB_SECTION();
            }


        }

        [StopWatch]
        /*" R0300-00-UPDATE-ENDOSSOS-DB-UPDATE-1 */
        public void R0300_00_UPDATE_ENDOSSOS_DB_UPDATE_1()
        {
            /*" -1946- EXEC SQL UPDATE SEGUROS.ENDOSSOS SET DATA_INIVIGENCIA = :ENDOSSOS-DATA-INIVIGENCIA WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO END-EXEC. */

            var r0300_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 = new R0300_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1()
            {
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            R0300_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1.Execute(r0300_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-UPDATE-APOLICOB-SECTION */
        private void R0310_00_UPDATE_APOLICOB_SECTION()
        {
            /*" -1965- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.WABEND.WNR_EXEC_SQL);

            /*" -1968- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1974- PERFORM R0310_00_UPDATE_APOLICOB_DB_UPDATE_1 */

            R0310_00_UPDATE_APOLICOB_DB_UPDATE_1();

            /*" -1979- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1980- DISPLAY 'R0310-00 - PROBLEMAS UPDATE (APOLICOB)' */
                _.Display($"R0310-00 - PROBLEMAS UPDATE (APOLICOB)");

                /*" -1980- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0310-00-UPDATE-APOLICOB-DB-UPDATE-1 */
        public void R0310_00_UPDATE_APOLICOB_DB_UPDATE_1()
        {
            /*" -1974- EXEC SQL UPDATE SEGUROS.APOLICE_COBERTURAS SET DATA_INIVIGENCIA = :ENDOSSOS-DATA-INIVIGENCIA WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO END-EXEC. */

            var r0310_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1 = new R0310_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1()
            {
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            R0310_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1.Execute(r0310_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0360-00-SELECT-HISCONPA-SECTION */
        private void R0360_00_SELECT_HISCONPA_SECTION()
        {
            /*" -1991- MOVE '0360' TO WNR-EXEC-SQL. */
            _.Move("0360", W.WABEND.WNR_EXEC_SQL);

            /*" -1994- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -1996- MOVE ENT-NUM-CERTIFICADO TO HISCONPA-NUM-CERTIFICADO. */
            _.Move(REG_ENTRADA1.ENT_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -2000- MOVE ENT-NUM-PARCELA TO HISCONPA-NUM-PARCELA. */
            _.Move(REG_ENTRADA1.ENT_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -2018- PERFORM R0360_00_SELECT_HISCONPA_DB_SELECT_1 */

            R0360_00_SELECT_HISCONPA_DB_SELECT_1();

            /*" -2023- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2026- DISPLAY 'R0360-00 - PROBLEMAS SELECT  (HISCONPA)  ' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' PARCELA     = ' HISCONPA-NUM-PARCELA */

                $"R0360-00 - PROBLEMAS SELECT  (HISCONPA)   CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}"
                .Display();

                /*" -2027- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2028- ELSE */
            }
            else
            {


                /*" -2029- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -2031- MOVE ENDOSSOS-DATA-INIVIGENCIA TO ENT-DTINIEMI */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, REG_ENTRADA1.ENT_DTINIEMI);

                    /*" -2032- MOVE ENDOSSOS-DATA-TERVIGENCIA TO ENT-DTTEREMI. */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, REG_ENTRADA1.ENT_DTTEREMI);
                }

            }


        }

        [StopWatch]
        /*" R0360-00-SELECT-HISCONPA-DB-SELECT-1 */
        public void R0360_00_SELECT_HISCONPA_DB_SELECT_1()
        {
            /*" -2018- EXEC SQL SELECT B.DATA_INIVIGENCIA ,B.DATA_TERVIGENCIA ,A.NUM_PARCELA INTO :ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA ,:WHOST-NUMPARCEL FROM SEGUROS.HIST_CONT_PARCELVA A ,SEGUROS.ENDOSSOS B WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND A.NUM_PARCELA < :HISCONPA-NUM-PARCELA AND A.NUM_ENDOSSO <> 0 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.TIPO_ENDOSSO = '1' ORDER BY A.NUM_PARCELA DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0360_00_SELECT_HISCONPA_DB_SELECT_1_Query1 = new R0360_00_SELECT_HISCONPA_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0360_00_SELECT_HISCONPA_DB_SELECT_1_Query1.Execute(r0360_00_SELECT_HISCONPA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(executed_1.WHOST_NUMPARCEL, WHOST_NUMPARCEL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-SORT-SECTION */
        private void R0400_00_PROCESSA_SORT_SECTION()
        {
            /*" -2043- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", W.WABEND.WNR_EXEC_SQL);

            /*" -2046- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -2047- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -2049- PERFORM R0410-00-LER-SORT. */

            R0410_00_LER_SORT_SECTION();

            /*" -2050- IF WFIM-SORT NOT EQUAL SPACES */

            if (!W.WFIM_SORT.IsEmpty())
            {

                /*" -2053- GO TO R0400-90-DISPLAY. */

                R0400_90_DISPLAY(); //GOTO
                return;
            }


            /*" -2054- PERFORM R0420-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R0420_00_PROCESSA_SORT_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0400_90_DISPLAY */

            R0400_90_DISPLAY();

        }

        [StopWatch]
        /*" R0400-90-DISPLAY */
        private void R0400_90_DISPLAY(bool isPerform = false)
        {
            /*" -2060- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -2064- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2065- DISPLAY 'LIDOS SORT ................ ' LD-SORT */
            _.Display($"LIDOS SORT ................ {W.LD_SORT}");

            /*" -2066- DISPLAY 'DESPREZA SORT ............. ' DP-SORT */
            _.Display($"DESPREZA SORT ............. {W.DP_SORT}");

            /*" -2067- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2068- DISPLAY 'TRATA COBRANCA ............ ' TT-COBRANCA */
            _.Display($"TRATA COBRANCA ............ {W.TT_COBRANCA}");

            /*" -2069- DISPLAY 'TRATA RESTITUICAO ......... ' TT-RESTITUI */
            _.Display($"TRATA RESTITUICAO ......... {W.TT_RESTITUI}");

            /*" -2070- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2071- DISPLAY 'TRATA EMISSAO ............. ' TT-EMISSAO */
            _.Display($"TRATA EMISSAO ............. {W.TT_EMISSAO}");

            /*" -2072- DISPLAY 'TRATA BAIXA ............... ' TT-BAIXA */
            _.Display($"TRATA BAIXA ............... {W.TT_BAIXA}");

            /*" -2073- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2074- DISPLAY 'UPDATE COBHISVI ........... ' UP-COBHISVI */
            _.Display($"UPDATE COBHISVI ........... {W.UP_COBHISVI}");

            /*" -2075- DISPLAY 'UPDATE HISCONPA ........... ' UP-HISCONPA */
            _.Display($"UPDATE HISCONPA ........... {W.UP_HISCONPA}");

            /*" -2076- DISPLAY 'UPDATE RCAPS .............. ' UP-RCAPS */
            _.Display($"UPDATE RCAPS .............. {W.UP_RCAPS}");

            /*" -2077- DISPLAY 'INSERT ENDOSSOS ........... ' IN-ENDOSSOS */
            _.Display($"INSERT ENDOSSOS ........... {W.IN_ENDOSSOS}");

            /*" -2078- DISPLAY 'INSERT PARCELAS ........... ' IN-PARCELAS */
            _.Display($"INSERT PARCELAS ........... {W.IN_PARCELAS}");

            /*" -2079- DISPLAY 'INSERT PARCEHIS ........... ' IN-PARCEHIS */
            _.Display($"INSERT PARCEHIS ........... {W.IN_PARCEHIS}");

            /*" -2080- DISPLAY 'INSERT APOLICOB ........... ' IN-APOLICOB */
            _.Display($"INSERT APOLICOB ........... {W.IN_APOLICOB}");

            /*" -2081- DISPLAY 'INSERT COSSEGURO .......... ' IN-ORDEMCOS */
            _.Display($"INSERT COSSEGURO .......... {W.IN_ORDEMCOS}");

            /*" -2082- DISPLAY 'INSERT EMISSDIA ........... ' IN-EMISSDIA */
            _.Display($"INSERT EMISSDIA ........... {W.IN_EMISSDIA}");

            /*" -2083- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2084- DISPLAY 'GRAVADOS ARQUIVO 1 ........ ' AC-GRAVA02 */
            _.Display($"GRAVADOS ARQUIVO 1 ........ {W.AC_GRAVA02}");

            /*" -2084- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-LER-SORT-SECTION */
        private void R0410_00_LER_SORT_SECTION()
        {
            /*" -2095- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", W.WABEND.WNR_EXEC_SQL);

            /*" -2098- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -2100- RETURN SVA0141B AT END */
            try
            {
                SVA0141B.Return(REG_SVA0141B, () =>
                {

                    /*" -2101- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -2104- GO TO R0410-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -2107- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

            /*" -2109- MOVE LD-SORT TO AC-LIDOS. */
            _.Move(W.LD_SORT, W.AC_LIDOS);

            /*" -2111- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_86.LD_PARTE2 == 00 || W.FILLER_86.LD_PARTE2 == 5000)
            {

                /*" -2112- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -2113- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_90.WTIME_DAYR.WTIME_HORA);

                /*" -2114- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_90.WTIME_DAYR.WTIME_2PT1);

                /*" -2115- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_90.WTIME_DAYR.WTIME_MINU);

                /*" -2116- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_90.WTIME_DAYR.WTIME_2PT2);

                /*" -2117- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_90.WTIME_DAYR.WTIME_SEGU);

                /*" -2119- DISPLAY 'LIDOS SORT         ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS SORT         {W.AC_LIDOS}    {W.FILLER_90.WTIME_DAYR}"
                .Display();
            }


            /*" -2119- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-PROCESSA-SORT-SECTION */
        private void R0420_00_PROCESSA_SORT_SECTION()
        {
            /*" -2129- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", W.WABEND.WNR_EXEC_SQL);

            /*" -2132- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -2138- PERFORM R0450-00-MOVE-DADOS-SAIDA. */

            R0450_00_MOVE_DADOS_SAIDA_SECTION();

            /*" -2144- PERFORM R0600-00-SELECT-NUMERAES. */

            R0600_00_SELECT_NUMERAES_SECTION();

            /*" -2150- PERFORM R0700-00-SELECT-FONTES. */

            R0700_00_SELECT_FONTES_SECTION();

            /*" -2151- IF SOR-TIPO-ENDOSSO EQUAL '1' */

            if (REG_SVA0141B.SOR_TIPO_ENDOSSO == "1")
            {

                /*" -2152- ADD 1 TO TT-COBRANCA */
                W.TT_COBRANCA.Value = W.TT_COBRANCA + 1;

                /*" -2154- MOVE '1' TO ENDOSSOS-TIPO-ENDOSSO */
                _.Move("1", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);

                /*" -2156- MOVE NUMERAES-ENDOS-COBRANCA TO ENDOSSOS-NUM-ENDOSSO */
                _.Move(NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                /*" -2157- ELSE */
            }
            else
            {


                /*" -2158- ADD 1 TO TT-RESTITUI */
                W.TT_RESTITUI.Value = W.TT_RESTITUI + 1;

                /*" -2160- MOVE '3' TO ENDOSSOS-TIPO-ENDOSSO */
                _.Move("3", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);

                /*" -2163- MOVE NUMERAES-ENDOS-RESTITUICAO TO ENDOSSOS-NUM-ENDOSSO. */
                _.Move(NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_RESTITUICAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
            }


            /*" -2165- MOVE SOR-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(REG_SVA0141B.SOR_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -2167- MOVE SOR-RAMO TO ENDOSSOS-RAMO-EMISSOR. */
            _.Move(REG_SVA0141B.SOR_RAMO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

            /*" -2169- MOVE SOR-PRODEMIS TO ENDOSSOS-COD-PRODUTO. */
            _.Move(REG_SVA0141B.SOR_PRODEMIS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);

            /*" -2171- MOVE SOR-SUBGRUPO TO ENDOSSOS-COD-SUBGRUPO. */
            _.Move(REG_SVA0141B.SOR_SUBGRUPO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO);

            /*" -2173- MOVE SOR-COD-FONTE TO ENDOSSOS-COD-FONTE. */
            _.Move(REG_SVA0141B.SOR_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);

            /*" -2175- MOVE FONTES-ULT-PROP-AUTOMAT TO ENDOSSOS-NUM-PROPOSTA. */
            _.Move(FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);

            /*" -2177- MOVE SOR-DTINIEMI TO ENDOSSOS-DATA-PROPOSTA. */
            _.Move(REG_SVA0141B.SOR_DTINIEMI, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA);

            /*" -2179- MOVE SISTEMAS-DATA-MOV-ABERTO TO ENDOSSOS-DATA-LIBERACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO);

            /*" -2181- MOVE SISTEMAS-DATA-MOV-ABERTO TO ENDOSSOS-DATA-EMISSAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);

            /*" -2183- MOVE SOR-DTINIEMI TO ENDOSSOS-DATA-INIVIGENCIA. */
            _.Move(REG_SVA0141B.SOR_DTINIEMI, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

            /*" -2186- MOVE SOR-DTTEREMI TO ENDOSSOS-DATA-TERVIGENCIA. */
            _.Move(REG_SVA0141B.SOR_DTTEREMI, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

            /*" -2192- MOVE SPACES TO ENDOSSOS-DAC-RCAP ENDOSSOS-TIPO-RCAP ENDOSSOS-DATA-RCAP ENDOSSOS-COD-TEXTO-PADRAO ENDOSSOS-DATA-VENCIMENTO. */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO);

            /*" -2209- MOVE ZEROS TO ENDOSSOS-BCO-COBRANCA ENDOSSOS-AGE-COBRANCA ENDOSSOS-NUM-RCAP ENDOSSOS-VAL-RCAP ENDOSSOS-BCO-RCAP ENDOSSOS-AGE-RCAP ENDOSSOS-PLANO-SEGURO ENDOSSOS-PCT-ENTRADA ENDOSSOS-PCT-ADIC-FRACIO ENDOSSOS-QTD-DIAS-PRIMEIRA ENDOSSOS-QTD-PARCELAS ENDOSSOS-QTD-PRESTACOES ENDOSSOS-COD-EMPRESA ENDOSSOS-COEF-PREFIX ENDOSSOS-VAL-CUSTO-EMISSAO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COEF_PREFIX, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_CUSTO_EMISSAO);

            /*" -2212- MOVE '0' TO ENDOSSOS-DAC-COBRANCA ENDOSSOS-COD-ACEITACAO. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO);

            /*" -2217- MOVE 1 TO ENDOSSOS-QTD-ITENS ENDOSSOS-COD-MOEDA-IMP ENDOSSOS-COD-MOEDA-PRM ENDOSSOS-OCORR-ENDERECO. */
            _.Move(1, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);

            /*" -2219- MOVE '1' TO ENDOSSOS-TIPO-CORRECAO. */
            _.Move("1", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO);

            /*" -2221- MOVE 'S' TO ENDOSSOS-ISENTA-CUSTO. */
            _.Move("S", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO);

            /*" -2224- MOVE 'VA0141B' TO ENDOSSOS-COD-USUARIO. */
            _.Move("VA0141B", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO);

            /*" -2228- MOVE -1 TO VIND-DATARCAP VIND-DTVENCTO VIND-VLCUSEMI VIND-CFPREFIX. */
            _.Move(-1, VIND_DATARCAP, VIND_DTVENCTO, VIND_VLCUSEMI, VIND_CFPREFIX);

            /*" -2232- MOVE ZEROS TO VIND-COD-EMPRESA VIND-TIPO-CORRECAO VIND-ISENTA-CUSTO. */
            _.Move(0, VIND_COD_EMPRESA, VIND_TIPO_CORRECAO, VIND_ISENTA_CUSTO);

            /*" -2233- IF SOR-TIPO-ENDOSSO EQUAL '1' */

            if (REG_SVA0141B.SOR_TIPO_ENDOSSO == "1")
            {

                /*" -2234- IF SOR-RCAPS EQUAL 'SIM' */

                if (REG_SVA0141B.SOR_RCAPS == "SIM")
                {

                    /*" -2236- MOVE SOR-NRRCAP TO ENDOSSOS-NUM-RCAP */
                    _.Move(REG_SVA0141B.SOR_NRRCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP);

                    /*" -2238- MOVE SOR-VAL-RCAP TO ENDOSSOS-VAL-RCAP */
                    _.Move(REG_SVA0141B.SOR_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP);

                    /*" -2240- MOVE SOR-BCOAVISO TO ENDOSSOS-BCO-RCAP */
                    _.Move(REG_SVA0141B.SOR_BCOAVISO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP);

                    /*" -2242- MOVE SOR-AGEAVISO TO ENDOSSOS-AGE-RCAP */
                    _.Move(REG_SVA0141B.SOR_AGEAVISO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP);

                    /*" -2244- MOVE SOR-DATA-RCAP TO ENDOSSOS-DATA-RCAP */
                    _.Move(REG_SVA0141B.SOR_DATA_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP);

                    /*" -2247- MOVE ZEROS TO VIND-DATARCAP. */
                    _.Move(0, VIND_DATARCAP);
                }

            }


            /*" -2248- IF SOR-TIPO-ENDOSSO EQUAL '1' */

            if (REG_SVA0141B.SOR_TIPO_ENDOSSO == "1")
            {

                /*" -2252- IF ((SOR-RCAPS EQUAL 'SIM' OR SOR-MOVIMCOB EQUAL 'SIM' OR SOR-MOVDEBCE EQUAL 'SIM' ) AND SOR-OPCAO-PAGAMENTO NOT EQUAL '5' ) */

                if (((REG_SVA0141B.SOR_RCAPS == "SIM" || REG_SVA0141B.SOR_MOVIMCOB == "SIM" || REG_SVA0141B.SOR_MOVDEBCE == "SIM") && REG_SVA0141B.SOR_OPCAO_PAGAMENTO != "5"))
                {

                    /*" -2254- MOVE '1' TO ENDOSSOS-SIT-REGISTRO */
                    _.Move("1", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);

                    /*" -2255- ELSE */
                }
                else
                {


                    /*" -2257- MOVE '0' TO ENDOSSOS-SIT-REGISTRO */
                    _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);

                    /*" -2258- ELSE */
                }

            }
            else
            {


                /*" -2265- MOVE '1' TO ENDOSSOS-SIT-REGISTRO. */
                _.Move("1", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);
            }


            /*" -2267- MOVE ENDOSSOS-NUM-APOLICE TO PARCELAS-NUM-APOLICE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

            /*" -2269- MOVE ENDOSSOS-NUM-ENDOSSO TO PARCELAS-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

            /*" -2271- MOVE ZEROS TO PARCELAS-NUM-PARCELA. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);

            /*" -2273- MOVE '0' TO PARCELAS-DAC-PARCELA. */
            _.Move("0", PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA);

            /*" -2275- MOVE ENDOSSOS-COD-FONTE TO PARCELAS-COD-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE);

            /*" -2277- MOVE ZEROS TO PARCELAS-QTD-DOCUMENTOS. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS);

            /*" -2279- MOVE ENDOSSOS-COD-EMPRESA TO PARCELAS-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA);

            /*" -2281- MOVE SPACES TO PARCELAS-SITUACAO-COBRANCA. */
            _.Move("", PARCELAS.DCLPARCELAS.PARCELAS_SITUACAO_COBRANCA);

            /*" -2283- MOVE ENDOSSOS-SIT-REGISTRO TO PARCELAS-SIT-REGISTRO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO, PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);

            /*" -2286- MOVE SOR-NUM-TITULO TO PARCELAS-NUM-TITULO. */
            _.Move(REG_SVA0141B.SOR_NUM_TITULO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO);

            /*" -2288- MOVE -1 TO VIND-SITCOB. */
            _.Move(-1, VIND_SITCOB);

            /*" -2289- IF PARCELAS-SIT-REGISTRO EQUAL '1' */

            if (PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO == "1")
            {

                /*" -2291- MOVE 2 TO PARCELAS-OCORR-HISTORICO */
                _.Move(2, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);

                /*" -2292- ELSE */
            }
            else
            {


                /*" -2295- MOVE 1 TO PARCELAS-OCORR-HISTORICO. */
                _.Move(1, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);
            }


            /*" -2306- MOVE ZEROS TO PARCELAS-PRM-TARIFARIO-IX PARCELAS-VAL-DESCONTO-IX PARCELAS-PRM-LIQUIDO-IX PARCELAS-ADICIONAL-FRAC-IX PARCELAS-VAL-CUSTO-EMIS-IX PARCELAS-VAL-IOCC-IX PARCELAS-PRM-TOTAL-IX WS-IND-IOF WS-PREMIO-LIQ. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX, PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX, WS_IND_IOF, WS_PREMIO_LIQ);

            /*" -2307- IF SOR-TIPO-ENDOSSO NOT EQUAL '1' */

            if (REG_SVA0141B.SOR_TIPO_ENDOSSO != "1")
            {

                /*" -2308- MOVE ZEROS TO WS-IND-IOF */
                _.Move(0, WS_IND_IOF);

                /*" -2309- ELSE */
            }
            else
            {


                /*" -2310- IF SOR-IND-IOF EQUAL 'S' */

                if (REG_SVA0141B.SOR_IND_IOF == "S")
                {

                    /*" -2312- COMPUTE WS-IND-IOF ROUNDED EQUAL (SOR-PER-IOF * SOR-VALVGAP / 100) */
                    WS_IND_IOF.Value = (REG_SVA0141B.SOR_PER_IOF * REG_SVA0141B.SOR_VALVGAP / 100f);

                    /*" -2313- ELSE */
                }
                else
                {


                    /*" -2315- MOVE ZEROS TO WS-IND-IOF. */
                    _.Move(0, WS_IND_IOF);
                }

            }


            /*" -2317- MOVE WS-IND-IOF TO PARCELAS-VAL-IOCC-IX. */
            _.Move(WS_IND_IOF, PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX);

            /*" -2319- COMPUTE WS-PREMIO-LIQ EQUAL SOR-VALVGAP - WS-IND-IOF. */
            WS_PREMIO_LIQ.Value = REG_SVA0141B.SOR_VALVGAP - WS_IND_IOF;

            /*" -2322- MOVE WS-PREMIO-LIQ TO PARCELAS-PRM-TARIFARIO-IX PARCELAS-PRM-LIQUIDO-IX. */
            _.Move(WS_PREMIO_LIQ, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX);

            /*" -2329- MOVE SOR-VALVGAP TO PARCELAS-PRM-TOTAL-IX. */
            _.Move(REG_SVA0141B.SOR_VALVGAP, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);

            /*" -2331- MOVE PARCELAS-NUM-APOLICE TO PARCEHIS-NUM-APOLICE. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -2333- MOVE PARCELAS-NUM-ENDOSSO TO PARCEHIS-NUM-ENDOSSO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -2335- MOVE PARCELAS-NUM-PARCELA TO PARCEHIS-NUM-PARCELA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

            /*" -2337- MOVE PARCELAS-DAC-PARCELA TO PARCEHIS-DAC-PARCELA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);

            /*" -2339- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -2341- MOVE 101 TO PARCEHIS-COD-OPERACAO. */
            _.Move(101, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -2343- MOVE 1 TO PARCEHIS-OCORR-HISTORICO. */
            _.Move(1, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -2345- MOVE PARCELAS-PRM-TARIFARIO-IX TO PARCEHIS-PRM-TARIFARIO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO);

            /*" -2347- MOVE PARCELAS-VAL-DESCONTO-IX TO PARCEHIS-VAL-DESCONTO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO);

            /*" -2349- MOVE PARCELAS-PRM-LIQUIDO-IX TO PARCEHIS-PRM-LIQUIDO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO);

            /*" -2351- MOVE PARCELAS-ADICIONAL-FRAC-IX TO PARCEHIS-ADICIONAL-FRACIO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);

            /*" -2353- MOVE PARCELAS-VAL-CUSTO-EMIS-IX TO PARCEHIS-VAL-CUSTO-EMISSAO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO);

            /*" -2355- MOVE PARCELAS-VAL-IOCC-IX TO PARCEHIS-VAL-IOCC. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC);

            /*" -2357- MOVE PARCELAS-PRM-TOTAL-IX TO PARCEHIS-PRM-TOTAL. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);

            /*" -2359- MOVE ZEROS TO PARCEHIS-VAL-OPERACAO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

            /*" -2361- MOVE SOR-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO. */
            _.Move(REG_SVA0141B.SOR_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

            /*" -2363- MOVE 104 TO PARCEHIS-BCO-COBRANCA. */
            _.Move(104, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -2365- MOVE ZEROS TO PARCEHIS-AGE-COBRANCA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -2367- MOVE ZEROS TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -2369- MOVE ZEROS TO PARCEHIS-ENDOS-CANCELA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -2371- MOVE '0' TO PARCEHIS-SIT-CONTABIL. */
            _.Move("0", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

            /*" -2373- MOVE ENDOSSOS-COD-USUARIO TO PARCEHIS-COD-USUARIO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -2375- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

            /*" -2377- MOVE SPACES TO PARCEHIS-DATA-QUITACAO. */
            _.Move("", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -2380- MOVE PARCELAS-COD-EMPRESA TO PARCEHIS-COD-EMPRESA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);

            /*" -2381- MOVE -1 TO VIND-DTQITBCO. */
            _.Move(-1, VIND_DTQITBCO);

            /*" -2387- ADD 1 TO TT-EMISSAO. */
            W.TT_EMISSAO.Value = W.TT_EMISSAO + 1;

            /*" -2390- PERFORM R0900-00-TRATA-COBERTURAS. */

            R0900_00_TRATA_COBERTURAS_SECTION();

            /*" -2391- IF LD01-OBSERVA EQUAL SPACES */

            if (ARQUIVOS_SAIDA.LD01.LD01_OBSERVA.IsEmpty())
            {

                /*" -2394- PERFORM R1500-00-VER-COBERTURAS. */

                R1500_00_VER_COBERTURAS_SECTION();
            }


            /*" -2395- IF LD01-OBSERVA NOT EQUAL SPACES */

            if (!ARQUIVOS_SAIDA.LD01.LD01_OBSERVA.IsEmpty())
            {

                /*" -2396- WRITE REG-SAIDA01 FROM LD01 */
                _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -2397- ADD 1 TO AC-GRAVA02 */
                W.AC_GRAVA02.Value = W.AC_GRAVA02 + 1;

                /*" -2398- ELSE */
            }
            else
            {


                /*" -2398- PERFORM R2000-00-ATUALIZA-TABELAS. */

                R2000_00_ATUALIZA_TABELAS_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0420_90_LEITURA */

            R0420_90_LEITURA();

        }

        [StopWatch]
        /*" R0420-90-LEITURA */
        private void R0420_90_LEITURA(bool isPerform = false)
        {
            /*" -2403- PERFORM R0410-00-LER-SORT. */

            R0410_00_LER_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-MOVE-DADOS-SAIDA-SECTION */
        private void R0450_00_MOVE_DADOS_SAIDA_SECTION()
        {
            /*" -2413- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", W.WABEND.WNR_EXEC_SQL);

            /*" -2416- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -2418- MOVE SOR-PROGRAMA TO LD01-PROGRAMA. */
            _.Move(REG_SVA0141B.SOR_PROGRAMA, ARQUIVOS_SAIDA.LD01.LD01_PROGRAMA);

            /*" -2420- MOVE SOR-TIPO-ENDOSSO TO LD01-TIPO-ENDOSSO. */
            _.Move(REG_SVA0141B.SOR_TIPO_ENDOSSO, ARQUIVOS_SAIDA.LD01.LD01_TIPO_ENDOSSO);

            /*" -2423- MOVE SOR-NUM-CERTIFICADO TO LD01-NUM-CERTIFICADO PARCEVID-NUM-CERTIFICADO */
            _.Move(REG_SVA0141B.SOR_NUM_CERTIFICADO, ARQUIVOS_SAIDA.LD01.LD01_NUM_CERTIFICADO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO);

            /*" -2426- MOVE SOR-NUM-PARCELA TO LD01-NUM-PARCELA PARCEVID-NUM-PARCELA */
            _.Move(REG_SVA0141B.SOR_NUM_PARCELA, ARQUIVOS_SAIDA.LD01.LD01_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);

            /*" -2428- MOVE SOR-NUM-TITULO TO LD01-NUM-TITULO */
            _.Move(REG_SVA0141B.SOR_NUM_TITULO, ARQUIVOS_SAIDA.LD01.LD01_NUM_TITULO);

            /*" -2430- MOVE SOR-OCORR-HISTORICO TO LD01-OCORR-HISTORICO. */
            _.Move(REG_SVA0141B.SOR_OCORR_HISTORICO, ARQUIVOS_SAIDA.LD01.LD01_OCORR_HISTORICO);

            /*" -2432- MOVE SOR-NUM-APOLICE TO LD01-NUM-APOLICE. */
            _.Move(REG_SVA0141B.SOR_NUM_APOLICE, ARQUIVOS_SAIDA.LD01.LD01_NUM_APOLICE);

            /*" -2434- MOVE SOR-COD-SUBGRUPO TO LD01-COD-SUBGRUPO. */
            _.Move(REG_SVA0141B.SOR_COD_SUBGRUPO, ARQUIVOS_SAIDA.LD01.LD01_COD_SUBGRUPO);

            /*" -2436- MOVE SOR-COD-FONTE TO LD01-COD-FONTE. */
            _.Move(REG_SVA0141B.SOR_COD_FONTE, ARQUIVOS_SAIDA.LD01.LD01_COD_FONTE);

            /*" -2438- MOVE SOR-ORGAO TO LD01-ORGAO. */
            _.Move(REG_SVA0141B.SOR_ORGAO, ARQUIVOS_SAIDA.LD01.LD01_ORGAO);

            /*" -2440- MOVE SOR-RAMO TO LD01-RAMO. */
            _.Move(REG_SVA0141B.SOR_RAMO, ARQUIVOS_SAIDA.LD01.LD01_RAMO);

            /*" -2442- MOVE SOR-MODALIDA TO LD01-MODALIDA. */
            _.Move(REG_SVA0141B.SOR_MODALIDA, ARQUIVOS_SAIDA.LD01.LD01_MODALIDA);

            /*" -2444- MOVE SOR-PREMIO-VG TO LD01-PREMIO-VG. */
            _.Move(REG_SVA0141B.SOR_PREMIO_VG, ARQUIVOS_SAIDA.LD01.LD01_PREMIO_VG);

            /*" -2446- MOVE SOR-PREMIO-AP TO LD01-PREMIO-AP. */
            _.Move(REG_SVA0141B.SOR_PREMIO_AP, ARQUIVOS_SAIDA.LD01.LD01_PREMIO_AP);

            /*" -2448- MOVE SOR-DATA-MOVIMENTO TO LD01-DATA-MOVIMENTO. */
            _.Move(REG_SVA0141B.SOR_DATA_MOVIMENTO, ARQUIVOS_SAIDA.LD01.LD01_DATA_MOVIMENTO);

            /*" -2450- MOVE SOR-SIT-REGISTRO TO LD01-SIT-REGISTRO. */
            _.Move(REG_SVA0141B.SOR_SIT_REGISTRO, ARQUIVOS_SAIDA.LD01.LD01_SIT_REGISTRO);

            /*" -2452- MOVE SOR-COD-OPERACAO TO LD01-COD-OPERACAO. */
            _.Move(REG_SVA0141B.SOR_COD_OPERACAO, ARQUIVOS_SAIDA.LD01.LD01_COD_OPERACAO);

            /*" -2454- MOVE SOR-COD-PRODUTO TO LD01-COD-PRODUTO. */
            _.Move(REG_SVA0141B.SOR_COD_PRODUTO, ARQUIVOS_SAIDA.LD01.LD01_COD_PRODUTO);

            /*" -2456- MOVE SOR-DATA-QUITACAO TO LD01-DATA-QUITACAO. */
            _.Move(REG_SVA0141B.SOR_DATA_QUITACAO, ARQUIVOS_SAIDA.LD01.LD01_DATA_QUITACAO);

            /*" -2458- MOVE SOR-SITUACAO TO LD01-SITUACAO. */
            _.Move(REG_SVA0141B.SOR_SITUACAO, ARQUIVOS_SAIDA.LD01.LD01_SITUACAO);

            /*" -2460- MOVE SOR-OCORHIST TO LD01-OCORHIST. */
            _.Move(REG_SVA0141B.SOR_OCORHIST, ARQUIVOS_SAIDA.LD01.LD01_OCORHIST);

            /*" -2462- MOVE SOR-DTPROXVEN TO LD01-DTPROXVEN. */
            _.Move(REG_SVA0141B.SOR_DTPROXVEN, ARQUIVOS_SAIDA.LD01.LD01_DTPROXVEN);

            /*" -2464- MOVE SOR-CLIENTE TO LD01-CLIENTE. */
            _.Move(REG_SVA0141B.SOR_CLIENTE, ARQUIVOS_SAIDA.LD01.LD01_CLIENTE);

            /*" -2466- MOVE SOR-CGCCPF TO LD01-CGCCPF. */
            _.Move(REG_SVA0141B.SOR_CGCCPF, ARQUIVOS_SAIDA.LD01.LD01_CGCCPF);

            /*" -2468- MOVE SOR-DATA-NASCIMENTO TO LD01-DATA-NASCIMENTO. */
            _.Move(REG_SVA0141B.SOR_DATA_NASCIMENTO, ARQUIVOS_SAIDA.LD01.LD01_DATA_NASCIMENTO);

            /*" -2470- MOVE SOR-TIPO-PESSOA TO LD01-TIPO-PESSOA. */
            _.Move(REG_SVA0141B.SOR_TIPO_PESSOA, ARQUIVOS_SAIDA.LD01.LD01_TIPO_PESSOA);

            /*" -2472- MOVE SOR-PRODUTO TO LD01-PRODUTO. */
            _.Move(REG_SVA0141B.SOR_PRODUTO, ARQUIVOS_SAIDA.LD01.LD01_PRODUTO);

            /*" -2474- MOVE SOR-PRODEMIS TO LD01-PRODEMIS. */
            _.Move(REG_SVA0141B.SOR_PRODEMIS, ARQUIVOS_SAIDA.LD01.LD01_PRODEMIS);

            /*" -2476- MOVE SOR-DTINIEMI TO LD01-DTINIEMI. */
            _.Move(REG_SVA0141B.SOR_DTINIEMI, ARQUIVOS_SAIDA.LD01.LD01_DTINIEMI);

            /*" -2478- MOVE SOR-DTTEREMI TO LD01-DTTEREMI. */
            _.Move(REG_SVA0141B.SOR_DTTEREMI, ARQUIVOS_SAIDA.LD01.LD01_DTTEREMI);

            /*" -2480- MOVE SOR-ESTR-COBR TO LD01-ESTR-COBR. */
            _.Move(REG_SVA0141B.SOR_ESTR_COBR, ARQUIVOS_SAIDA.LD01.LD01_ESTR_COBR);

            /*" -2482- MOVE SOR-ORIG-PRODU TO LD01-ORIG-PRODU. */
            _.Move(REG_SVA0141B.SOR_ORIG_PRODU, ARQUIVOS_SAIDA.LD01.LD01_ORIG_PRODU);

            /*" -2484- MOVE SOR-IND-IOF TO LD01-IND-IOF. */
            _.Move(REG_SVA0141B.SOR_IND_IOF, ARQUIVOS_SAIDA.LD01.LD01_IND_IOF);

            /*" -2486- MOVE SOR-PER-IOF TO LD01-PER-IOF. */
            _.Move(REG_SVA0141B.SOR_PER_IOF, ARQUIVOS_SAIDA.LD01.LD01_PER_IOF);

            /*" -2488- MOVE SOR-DATA-VENCIMENTO TO LD01-DATA-VENCIMENTO. */
            _.Move(REG_SVA0141B.SOR_DATA_VENCIMENTO, ARQUIVOS_SAIDA.LD01.LD01_DATA_VENCIMENTO);

            /*" -2490- MOVE SOR-DATA-INIVIGENCIA TO LD01-DATA-INIVIGENCIA. */
            _.Move(REG_SVA0141B.SOR_DATA_INIVIGENCIA, ARQUIVOS_SAIDA.LD01.LD01_DATA_INIVIGENCIA);

            /*" -2492- MOVE SOR-DATA-TERVIGENCIA TO LD01-DATA-TERVIGENCIA. */
            _.Move(REG_SVA0141B.SOR_DATA_TERVIGENCIA, ARQUIVOS_SAIDA.LD01.LD01_DATA_TERVIGENCIA);

            /*" -2494- MOVE SOR-OPCAO-PAGAMENTO TO LD01-OPCAO-PAGAMENTO. */
            _.Move(REG_SVA0141B.SOR_OPCAO_PAGAMENTO, ARQUIVOS_SAIDA.LD01.LD01_OPCAO_PAGAMENTO);

            /*" -2496- MOVE SOR-PERI-PAGAMENTO TO LD01-PERI-PAGAMENTO. */
            _.Move(REG_SVA0141B.SOR_PERI_PAGAMENTO, ARQUIVOS_SAIDA.LD01.LD01_PERI_PAGAMENTO);

            /*" -2498- MOVE SOR-DIA-DEBITO TO LD01-DIA-DEBITO. */
            _.Move(REG_SVA0141B.SOR_DIA_DEBITO, ARQUIVOS_SAIDA.LD01.LD01_DIA_DEBITO);

            /*" -2500- MOVE SOR-RCAPS TO LD01-RCAPS. */
            _.Move(REG_SVA0141B.SOR_RCAPS, ARQUIVOS_SAIDA.LD01.LD01_RCAPS);

            /*" -2502- MOVE SOR-SITRCAP TO LD01-SITRCAP. */
            _.Move(REG_SVA0141B.SOR_SITRCAP, ARQUIVOS_SAIDA.LD01.LD01_SITRCAP);

            /*" -2504- MOVE SOR-OPERCAP TO LD01-OPERCAP. */
            _.Move(REG_SVA0141B.SOR_OPERCAP, ARQUIVOS_SAIDA.LD01.LD01_OPERCAP);

            /*" -2506- MOVE SOR-VAL-RCAP TO LD01-VAL-RCAP. */
            _.Move(REG_SVA0141B.SOR_VAL_RCAP, ARQUIVOS_SAIDA.LD01.LD01_VAL_RCAP);

            /*" -2508- MOVE SOR-MOVIMCOB TO LD01-MOVIMCOB. */
            _.Move(REG_SVA0141B.SOR_MOVIMCOB, ARQUIVOS_SAIDA.LD01.LD01_MOVIMCOB);

            /*" -2510- MOVE SOR-SITMCOB TO LD01-SITMCOB. */
            _.Move(REG_SVA0141B.SOR_SITMCOB, ARQUIVOS_SAIDA.LD01.LD01_SITMCOB);

            /*" -2512- MOVE SOR-VAL-TITULO TO LD01-VAL-TITULO. */
            _.Move(REG_SVA0141B.SOR_VAL_TITULO, ARQUIVOS_SAIDA.LD01.LD01_VAL_TITULO);

            /*" -2514- MOVE SOR-SITMDEB TO LD01-SITMDEB. */
            _.Move(REG_SVA0141B.SOR_SITMDEB, ARQUIVOS_SAIDA.LD01.LD01_SITMDEB);

            /*" -2516- MOVE SOR-MOVDEBCE TO LD01-MOVDEBCE. */
            _.Move(REG_SVA0141B.SOR_MOVDEBCE, ARQUIVOS_SAIDA.LD01.LD01_MOVDEBCE);

            /*" -2518- MOVE SOR-CONVENIO TO LD01-CONVENIO. */
            _.Move(REG_SVA0141B.SOR_CONVENIO, ARQUIVOS_SAIDA.LD01.LD01_CONVENIO);

            /*" -2520- MOVE SOR-VALOR-DEBITO TO LD01-VALOR-DEBITO. */
            _.Move(REG_SVA0141B.SOR_VALOR_DEBITO, ARQUIVOS_SAIDA.LD01.LD01_VALOR_DEBITO);

            /*" -2522- MOVE SOR-VALVGAP TO LD01-VALVGAP. */
            _.Move(REG_SVA0141B.SOR_VALVGAP, ARQUIVOS_SAIDA.LD01.LD01_VALVGAP);

            /*" -2524- MOVE SOR-DTINIVIG TO LD01-DTINIVIG. */
            _.Move(REG_SVA0141B.SOR_DTINIVIG, ARQUIVOS_SAIDA.LD01.LD01_DTINIVIG);

            /*" -2526- MOVE SOR-DATA-ADMISSAO TO LD01-DATA-ADMISSAO. */
            _.Move(REG_SVA0141B.SOR_DATA_ADMISSAO, ARQUIVOS_SAIDA.LD01.LD01_DATA_ADMISSAO);

            /*" -2528- MOVE SOR-ADICIEA TO LD01-ADICIEA. */
            _.Move(REG_SVA0141B.SOR_ADICIEA, ARQUIVOS_SAIDA.LD01.LD01_ADICIEA);

            /*" -2530- MOVE SOR-ADICIPA TO LD01-ADICIPA. */
            _.Move(REG_SVA0141B.SOR_ADICIPA, ARQUIVOS_SAIDA.LD01.LD01_ADICIPA);

            /*" -2532- MOVE SOR-ADICIPD TO LD01-ADICIPD. */
            _.Move(REG_SVA0141B.SOR_ADICIPD, ARQUIVOS_SAIDA.LD01.LD01_ADICIPD);

            /*" -2534- MOVE SOR-INIZERO TO LD01-INIZERO. */
            _.Move(REG_SVA0141B.SOR_INIZERO, ARQUIVOS_SAIDA.LD01.LD01_INIZERO);

            /*" -2536- MOVE SOR-TERZERO TO LD01-TERZERO. */
            _.Move(REG_SVA0141B.SOR_TERZERO, ARQUIVOS_SAIDA.LD01.LD01_TERZERO);

            /*" -2538- MOVE SOR-BCOAVISO TO LD01-BCOAVISO. */
            _.Move(REG_SVA0141B.SOR_BCOAVISO, ARQUIVOS_SAIDA.LD01.LD01_BCOAVISO);

            /*" -2540- MOVE SOR-AGEAVISO TO LD01-AGEAVISO. */
            _.Move(REG_SVA0141B.SOR_AGEAVISO, ARQUIVOS_SAIDA.LD01.LD01_AGEAVISO);

            /*" -2542- MOVE SOR-NRAVISO TO LD01-NRAVISO. */
            _.Move(REG_SVA0141B.SOR_NRAVISO, ARQUIVOS_SAIDA.LD01.LD01_NRAVISO);

            /*" -2544- MOVE SOR-IMPMORNATU TO LD01-IMPMORNATU. */
            _.Move(REG_SVA0141B.SOR_IMPMORNATU, ARQUIVOS_SAIDA.LD01.LD01_IMPMORNATU);

            /*" -2546- MOVE SOR-IMPMORACID TO LD01-IMPMORACID. */
            _.Move(REG_SVA0141B.SOR_IMPMORACID, ARQUIVOS_SAIDA.LD01.LD01_IMPMORACID);

            /*" -2548- MOVE SOR-IMPINVPERM TO LD01-IMPINVPERM. */
            _.Move(REG_SVA0141B.SOR_IMPINVPERM, ARQUIVOS_SAIDA.LD01.LD01_IMPINVPERM);

            /*" -2550- MOVE SOR-IMPAMDS TO LD01-IMPAMDS. */
            _.Move(REG_SVA0141B.SOR_IMPAMDS, ARQUIVOS_SAIDA.LD01.LD01_IMPAMDS);

            /*" -2552- MOVE SOR-IMPDH TO LD01-IMPDH. */
            _.Move(REG_SVA0141B.SOR_IMPDH, ARQUIVOS_SAIDA.LD01.LD01_IMPDH);

            /*" -2554- MOVE SOR-IMPDIT TO LD01-IMPDIT. */
            _.Move(REG_SVA0141B.SOR_IMPDIT, ARQUIVOS_SAIDA.LD01.LD01_IMPDIT);

            /*" -2556- MOVE SOR-PRMDIT TO LD01-PRMDIT. */
            _.Move(REG_SVA0141B.SOR_PRMDIT, ARQUIVOS_SAIDA.LD01.LD01_PRMDIT);

            /*" -2558- MOVE SOR-IMPRTO TO LD01-IMPRTO. */
            _.Move(REG_SVA0141B.SOR_IMPRTO, ARQUIVOS_SAIDA.LD01.LD01_IMPRTO);

            /*" -2560- MOVE SOR-PRMRTO TO LD01-PRMRTO. */
            _.Move(REG_SVA0141B.SOR_PRMRTO, ARQUIVOS_SAIDA.LD01.LD01_PRMRTO);

            /*" -2562- MOVE SOR-APOLICE TO LD01-APOLICE. */
            _.Move(REG_SVA0141B.SOR_APOLICE, ARQUIVOS_SAIDA.LD01.LD01_APOLICE);

            /*" -2564- MOVE SOR-ENDOSSO TO LD01-ENDOSSO. */
            _.Move(REG_SVA0141B.SOR_ENDOSSO, ARQUIVOS_SAIDA.LD01.LD01_ENDOSSO);

            /*" -2566- MOVE SOR-RAMO-EMISSOR TO LD01-RAMO-EMISSOR. */
            _.Move(REG_SVA0141B.SOR_RAMO_EMISSOR, ARQUIVOS_SAIDA.LD01.LD01_RAMO_EMISSOR);

            /*" -2568- MOVE SOR-SUBGRUPO TO LD01-SUBGRUPO. */
            _.Move(REG_SVA0141B.SOR_SUBGRUPO, ARQUIVOS_SAIDA.LD01.LD01_SUBGRUPO);

            /*" -2570- MOVE SOR-FONTE TO LD01-FONTE. */
            _.Move(REG_SVA0141B.SOR_FONTE, ARQUIVOS_SAIDA.LD01.LD01_FONTE);

            /*" -2572- MOVE SOR-PARVG082 TO LD01-PARVG082. */
            _.Move(REG_SVA0141B.SOR_PARVG082, ARQUIVOS_SAIDA.LD01.LD01_PARVG082);

            /*" -2574- MOVE SOR-VALVG082 TO LD01-VALVG082. */
            _.Move(REG_SVA0141B.SOR_VALVG082, ARQUIVOS_SAIDA.LD01.LD01_VALVG082);

            /*" -2576- MOVE SOR-APOLICOB TO LD01-APOLICOB. */
            _.Move(REG_SVA0141B.SOR_APOLICOB, ARQUIVOS_SAIDA.LD01.LD01_APOLICOB);

            /*" -2578- MOVE SOR-NRRCAP TO LD01-NRRCAP. */
            _.Move(REG_SVA0141B.SOR_NRRCAP, ARQUIVOS_SAIDA.LD01.LD01_NRRCAP);

            /*" -2580- MOVE SOR-DATA-RCAP TO LD01-DATA-RCAP. */
            _.Move(REG_SVA0141B.SOR_DATA_RCAP, ARQUIVOS_SAIDA.LD01.LD01_DATA_RCAP);

            /*" -2582- MOVE SOR-SALDO TO LD01-SALDO. */
            _.Move(REG_SVA0141B.SOR_SALDO, ARQUIVOS_SAIDA.LD01.LD01_SALDO);

            /*" -2584- MOVE SOR-ITEM TO LD01-ITEM. */
            _.Move(REG_SVA0141B.SOR_ITEM, ARQUIVOS_SAIDA.LD01.LD01_ITEM);

            /*" -2586- MOVE SOR-VLPREMIO TO LD01-VLPREMIO. */
            _.Move(REG_SVA0141B.SOR_VLPREMIO, ARQUIVOS_SAIDA.LD01.LD01_VLPREMIO);

            /*" -2588- MOVE SOR-NRSEQ TO LD01-NRSEQ. */
            _.Move(REG_SVA0141B.SOR_NRSEQ, ARQUIVOS_SAIDA.LD01.LD01_NRSEQ);

            /*" -2597- MOVE SPACES TO LD01-OBSERVA LD01-OBSERVA1. */
            _.Move("", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA, ARQUIVOS_SAIDA.LD01.LD01_OBSERVA1);

            /*" -2598- IF SOR-NRSEQ GREATER 1 */

            if (REG_SVA0141B.SOR_NRSEQ > 1)
            {

                /*" -2605- PERFORM R0460-00-SELECT-HISCONPA. */

                R0460_00_SELECT_HISCONPA_SECTION();
            }


            /*" -2608- MOVE ZEROS TO WHOST-QTDPARCEL WS-VALOR. */
            _.Move(0, WHOST_QTDPARCEL, WS_VALOR);

            /*" -2609- IF SOR-VLPREMIO EQUAL ZEROS */

            if (REG_SVA0141B.SOR_VLPREMIO == 00)
            {

                /*" -2610- MOVE 1 TO WHOST-QTDPARCEL */
                _.Move(1, WHOST_QTDPARCEL);

                /*" -2611- ELSE */
            }
            else
            {


                /*" -2613- COMPUTE WS-VALOR EQUAL SOR-VALVGAP / SOR-VLPREMIO */
                WS_VALOR.Value = REG_SVA0141B.SOR_VALVGAP / REG_SVA0141B.SOR_VLPREMIO;

                /*" -2615- MOVE WS-VALOR TO WHOST-QTDPARCEL. */
                _.Move(WS_VALOR, WHOST_QTDPARCEL);
            }


            /*" -2617- IF WHOST-QTDPARCEL GREATER 1 AND SOR-PERI-PAGAMENTO EQUAL 1 */

            if (WHOST_QTDPARCEL > 1 && REG_SVA0141B.SOR_PERI_PAGAMENTO == 1)
            {

                /*" -2619- MOVE SOR-DTINIEMI TO CALENDAR-DATA-CALENDARIO */
                _.Move(REG_SVA0141B.SOR_DTINIEMI, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

                /*" -2619- PERFORM R0470-00-SELECT-CALENDAR. */

                R0470_00_SELECT_CALENDAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0460-00-SELECT-HISCONPA-SECTION */
        private void R0460_00_SELECT_HISCONPA_SECTION()
        {
            /*" -2630- MOVE '0460' TO WNR-EXEC-SQL. */
            _.Move("0460", W.WABEND.WNR_EXEC_SQL);

            /*" -2633- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -2635- MOVE SOR-NUM-CERTIFICADO TO HISCONPA-NUM-CERTIFICADO. */
            _.Move(REG_SVA0141B.SOR_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -2637- MOVE SOR-NUM-PARCELA TO HISCONPA-NUM-PARCELA. */
            _.Move(REG_SVA0141B.SOR_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -2640- MOVE SOR-PERI-PAGAMENTO TO WHOST-PERI. */
            _.Move(REG_SVA0141B.SOR_PERI_PAGAMENTO, WHOST_PERI);

            /*" -2641- IF WHOST-PERI EQUAL ZEROS */

            if (WHOST_PERI == 00)
            {

                /*" -2644- MOVE 36 TO WHOST-PERI. */
                _.Move(36, WHOST_PERI);
            }


            /*" -2662- PERFORM R0460_00_SELECT_HISCONPA_DB_SELECT_1 */

            R0460_00_SELECT_HISCONPA_DB_SELECT_1();

            /*" -2667- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2670- DISPLAY 'R0460-00 - PROBLEMAS SELECT  (HISCONPA)  ' ' CERTIFICADO = ' HISCONPA-NUM-CERTIFICADO ' PARCELA     = ' HISCONPA-NUM-PARCELA */

                $"R0460-00 - PROBLEMAS SELECT  (HISCONPA)   CERTIFICADO = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO} PARCELA     = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}"
                .Display();

                /*" -2671- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2672- ELSE */
            }
            else
            {


                /*" -2673- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -2676- MOVE ENDOSSOS-DATA-INIVIGENCIA TO SOR-DTINIEMI LD01-DTINIEMI */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, REG_SVA0141B.SOR_DTINIEMI, ARQUIVOS_SAIDA.LD01.LD01_DTINIEMI);

                    /*" -2678- MOVE ENDOSSOS-DATA-TERVIGENCIA TO SOR-DTTEREMI LD01-DTTEREMI. */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, REG_SVA0141B.SOR_DTTEREMI, ARQUIVOS_SAIDA.LD01.LD01_DTTEREMI);
                }

            }


        }

        [StopWatch]
        /*" R0460-00-SELECT-HISCONPA-DB-SELECT-1 */
        public void R0460_00_SELECT_HISCONPA_DB_SELECT_1()
        {
            /*" -2662- EXEC SQL SELECT B.DATA_TERVIGENCIA + 1 DAYS ,B.DATA_TERVIGENCIA + :WHOST-PERI MONTHS ,A.NUM_PARCELA INTO :ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA ,:WHOST-NUMPARCEL FROM SEGUROS.HIST_CONT_PARCELVA A ,SEGUROS.ENDOSSOS B WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND A.NUM_PARCELA < :HISCONPA-NUM-PARCELA AND A.NUM_ENDOSSO <> 0 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.TIPO_ENDOSSO = '1' ORDER BY A.NUM_PARCELA DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1 = new R0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1()
            {
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
                WHOST_PERI = WHOST_PERI.ToString(),
            };

            var executed_1 = R0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1.Execute(r0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(executed_1.WHOST_NUMPARCEL, WHOST_NUMPARCEL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_99_SAIDA*/

        [StopWatch]
        /*" R0470-00-SELECT-CALENDAR-SECTION */
        private void R0470_00_SELECT_CALENDAR_SECTION()
        {
            /*" -2689- MOVE '0470' TO WNR-EXEC-SQL. */
            _.Move("0470", W.WABEND.WNR_EXEC_SQL);

            /*" -2692- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -2700- PERFORM R0470_00_SELECT_CALENDAR_DB_SELECT_1 */

            R0470_00_SELECT_CALENDAR_DB_SELECT_1();

            /*" -2705- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2707- DISPLAY 'R0470-00 - PROBLEMAS NO SELECT(CALENDAR)' ' DATA        = ' CALENDAR-DATA-CALENDARIO */

                $"R0470-00 - PROBLEMAS NO SELECT(CALENDAR) DATA        = {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}"
                .Display();

                /*" -2708- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2709- ELSE */
            }
            else
            {


                /*" -2711- MOVE CALENDAR-DATA-CALENDARIO TO SOR-DTTEREMI LD01-DTTEREMI. */
                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, REG_SVA0141B.SOR_DTTEREMI, ARQUIVOS_SAIDA.LD01.LD01_DTTEREMI);
            }


        }

        [StopWatch]
        /*" R0470-00-SELECT-CALENDAR-DB-SELECT-1 */
        public void R0470_00_SELECT_CALENDAR_DB_SELECT_1()
        {
            /*" -2700- EXEC SQL SELECT DATA_CALENDARIO + :WHOST-QTDPARCEL MONTHS - 1 DAYS INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1 = new R0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
                WHOST_QTDPARCEL = WHOST_QTDPARCEL.ToString(),
            };

            var executed_1 = R0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1.Execute(r0470_00_SELECT_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0470_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-SELECT-NUMERAES-SECTION */
        private void R0600_00_SELECT_NUMERAES_SECTION()
        {
            /*" -2722- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", W.WABEND.WNR_EXEC_SQL);

            /*" -2725- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -2727- MOVE SOR-ORGAO TO NUMERAES-ORGAO-EMISSOR. */
            _.Move(REG_SVA0141B.SOR_ORGAO, NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR);

            /*" -2731- MOVE SOR-RAMO TO NUMERAES-RAMO-EMISSOR. */
            _.Move(REG_SVA0141B.SOR_RAMO, NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR);

            /*" -2740- PERFORM R0600_00_SELECT_NUMERAES_DB_SELECT_1 */

            R0600_00_SELECT_NUMERAES_DB_SELECT_1();

            /*" -2744- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2745- DISPLAY 'R0600-00 - PROBLEMAS NO SELECT(NUMERAES)' */
                _.Display($"R0600-00 - PROBLEMAS NO SELECT(NUMERAES)");

                /*" -2746- DISPLAY ' ORGAO        =  ' NUMERAES-ORGAO-EMISSOR */
                _.Display($" ORGAO        =  {NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR}");

                /*" -2747- DISPLAY ' RAMO         =  ' NUMERAES-RAMO-EMISSOR */
                _.Display($" RAMO         =  {NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR}");

                /*" -2750- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2751- IF SOR-TIPO-ENDOSSO EQUAL '1' */

            if (REG_SVA0141B.SOR_TIPO_ENDOSSO == "1")
            {

                /*" -2753- COMPUTE NUMERAES-ENDOS-COBRANCA EQUAL (NUMERAES-ENDOS-COBRANCA + 1) */
                NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_COBRANCA.Value = (NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_COBRANCA + 1);

                /*" -2754- ELSE */
            }
            else
            {


                /*" -2755- COMPUTE NUMERAES-ENDOS-RESTITUICAO EQUAL (NUMERAES-ENDOS-RESTITUICAO + 1). */
                NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_RESTITUICAO.Value = (NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_RESTITUICAO + 1);
            }


        }

        [StopWatch]
        /*" R0600-00-SELECT-NUMERAES-DB-SELECT-1 */
        public void R0600_00_SELECT_NUMERAES_DB_SELECT_1()
        {
            /*" -2740- EXEC SQL SELECT ENDOS_COBRANCA ,ENDOS_RESTITUICAO INTO :NUMERAES-ENDOS-COBRANCA ,:NUMERAES-ENDOS-RESTITUICAO FROM SEGUROS.NUMERO_AES WHERE ORGAO_EMISSOR = :NUMERAES-ORGAO-EMISSOR AND RAMO_EMISSOR = :NUMERAES-RAMO-EMISSOR WITH UR END-EXEC. */

            var r0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1 = new R0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1()
            {
                NUMERAES_ORGAO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR.ToString(),
                NUMERAES_RAMO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1.Execute(r0600_00_SELECT_NUMERAES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMERAES_ENDOS_COBRANCA, NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_COBRANCA);
                _.Move(executed_1.NUMERAES_ENDOS_RESTITUICAO, NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_RESTITUICAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-SELECT-FONTES-SECTION */
        private void R0700_00_SELECT_FONTES_SECTION()
        {
            /*" -2766- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", W.WABEND.WNR_EXEC_SQL);

            /*" -2769- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -2773- MOVE SOR-COD-FONTE TO FONTES-COD-FONTE. */
            _.Move(REG_SVA0141B.SOR_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);

            /*" -2781- PERFORM R0700_00_SELECT_FONTES_DB_SELECT_1 */

            R0700_00_SELECT_FONTES_DB_SELECT_1();

            /*" -2785- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2786- DISPLAY 'R0700-00 - PROBLEMAS NO SELECT(FONTES)  ' */
                _.Display($"R0700-00 - PROBLEMAS NO SELECT(FONTES)  ");

                /*" -2787- DISPLAY ' FONTE        =  ' FONTES-COD-FONTE */
                _.Display($" FONTE        =  {FONTES.DCLFONTES.FONTES_COD_FONTE}");

                /*" -2790- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2794- COMPUTE FONTES-ULT-PROP-AUTOMAT EQUAL (FONTES-ULT-PROP-AUTOMAT + 1). */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = (FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1);

            /*" -2796- MOVE ZEROS TO AC-CONTROLE. */
            _.Move(0, W.AC_CONTROLE);

            /*" -2796- PERFORM R0710-00-SELECT-ENDOSSOS. */

            R0710_00_SELECT_ENDOSSOS_SECTION();

        }

        [StopWatch]
        /*" R0700-00-SELECT-FONTES-DB-SELECT-1 */
        public void R0700_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -2781- EXEC SQL SELECT ULT_PROP_AUTOMAT INTO :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :FONTES-COD-FONTE WITH UR END-EXEC. */

            var r0700_00_SELECT_FONTES_DB_SELECT_1_Query1 = new R0700_00_SELECT_FONTES_DB_SELECT_1_Query1()
            {
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
            };

            var executed_1 = R0700_00_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r0700_00_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0710-00-SELECT-ENDOSSOS-SECTION */
        private void R0710_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -2807- MOVE '0710' TO WNR-EXEC-SQL. */
            _.Move("0710", W.WABEND.WNR_EXEC_SQL);

            /*" -2810- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -2818- PERFORM R0710_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0710_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -2822- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2825- GO TO R0710-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2826- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2827- DISPLAY 'R0710-00 - PROBLEMAS NO SELECT(ENDOSSOS)' */
                _.Display($"R0710-00 - PROBLEMAS NO SELECT(ENDOSSOS)");

                /*" -2828- DISPLAY 'COD-FONTE        = ' FONTES-COD-FONTE */
                _.Display($"COD-FONTE        = {FONTES.DCLFONTES.FONTES_COD_FONTE}");

                /*" -2829- DISPLAY 'NUM_PROPOSTA     = ' FONTES-ULT-PROP-AUTOMAT */
                _.Display($"NUM_PROPOSTA     = {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}");

                /*" -2832- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2837- ADD 1 TO AC-CONTROLE. */
            W.AC_CONTROLE.Value = W.AC_CONTROLE + 1;

            /*" -2838- IF AC-CONTROLE GREATER 5000 */

            if (W.AC_CONTROLE > 5000)
            {

                /*" -2839- DISPLAY 'R0710-00 - PROPOSTA DUPLICIDADE ENDOSSOS' */
                _.Display($"R0710-00 - PROPOSTA DUPLICIDADE ENDOSSOS");

                /*" -2840- DISPLAY 'COD-FONTE        = ' FONTES-COD-FONTE */
                _.Display($"COD-FONTE        = {FONTES.DCLFONTES.FONTES_COD_FONTE}");

                /*" -2841- DISPLAY 'NUM_PROPOSTA     = ' FONTES-ULT-PROP-AUTOMAT */
                _.Display($"NUM_PROPOSTA     = {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}");

                /*" -2843- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2847- COMPUTE FONTES-ULT-PROP-AUTOMAT EQUAL (FONTES-ULT-PROP-AUTOMAT + 1). */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = (FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1);

            /*" -2847- GO TO R0710-00-SELECT-ENDOSSOS. */
            new Task(() => R0710_00_SELECT_ENDOSSOS_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0710-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0710_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -2818- EXEC SQL SELECT NUM_PROPOSTA INTO :ENDOSSOS-NUM-PROPOSTA FROM SEGUROS.ENDOSSOS WHERE COD_FONTE = :FONTES-COD-FONTE AND NUM_PROPOSTA = :FONTES-ULT-PROP-AUTOMAT WITH UR END-EXEC. */

            var r0710_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R0710_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
            };

            var executed_1 = R0710_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0710_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-TRATA-COBERTURAS-SECTION */
        private void R0900_00_TRATA_COBERTURAS_SECTION()
        {
            /*" -2858- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", W.WABEND.WNR_EXEC_SQL);

            /*" -2861- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -2862- IF SOR-VALVG082 NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_VALVG082 != 00)
            {

                /*" -2863- MOVE SOR-VALVG082 TO WS-PRMBASE */
                _.Move(REG_SVA0141B.SOR_VALVG082, WS_PRMBASE);

                /*" -2864- ELSE */
            }
            else
            {


                /*" -2867- MOVE SOR-VALVGAP TO WS-PRMBASE. */
                _.Move(REG_SVA0141B.SOR_VALVGAP, WS_PRMBASE);
            }


            /*" -2868- SET WS-COB00 TO 1. */
            WS_COB00.Value = 1;

            /*" -2870- SET WS-COB01 TO 1. */
            WS_COB01.Value = 1;

            /*" -2876- PERFORM R0910-00-LIMPA-COBERTURA 010 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R0910_00_LIMPA_COBERTURA_SECTION();

            }

            /*" -2878- IF SOR-IND-IOF EQUAL 'S' AND SOR-PREMIO-VG NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IND_IOF == "S" && REG_SVA0141B.SOR_PREMIO_VG != 00)
            {

                /*" -2880- COMPUTE WS-IND-IOF ROUNDED EQUAL (SOR-PER-IOF * SOR-PREMIO-VG / 100) */
                WS_IND_IOF.Value = (REG_SVA0141B.SOR_PER_IOF * REG_SVA0141B.SOR_PREMIO_VG / 100f);

                /*" -2887- COMPUTE SOR-PREMIO-VG EQUAL SOR-PREMIO-VG - WS-IND-IOF. */
                REG_SVA0141B.SOR_PREMIO_VG.Value = REG_SVA0141B.SOR_PREMIO_VG - WS_IND_IOF;
            }


            /*" -2889- IF SOR-IND-IOF EQUAL 'S' AND SOR-PREMIO-AP NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IND_IOF == "S" && REG_SVA0141B.SOR_PREMIO_AP != 00)
            {

                /*" -2891- COMPUTE WS-IND-IOF ROUNDED EQUAL (SOR-PER-IOF * SOR-PREMIO-AP / 100) */
                WS_IND_IOF.Value = (REG_SVA0141B.SOR_PER_IOF * REG_SVA0141B.SOR_PREMIO_AP / 100f);

                /*" -2898- COMPUTE SOR-PREMIO-AP EQUAL SOR-PREMIO-AP - WS-IND-IOF. */
                REG_SVA0141B.SOR_PREMIO_AP.Value = REG_SVA0141B.SOR_PREMIO_AP - WS_IND_IOF;
            }


            /*" -2900- IF SOR-IND-IOF EQUAL 'S' AND SOR-PRMDIT NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IND_IOF == "S" && REG_SVA0141B.SOR_PRMDIT != 00)
            {

                /*" -2902- COMPUTE WS-IND-IOF ROUNDED EQUAL (SOR-PER-IOF * SOR-PRMDIT / 100) */
                WS_IND_IOF.Value = (REG_SVA0141B.SOR_PER_IOF * REG_SVA0141B.SOR_PRMDIT / 100f);

                /*" -2909- COMPUTE SOR-PRMDIT EQUAL SOR-PRMDIT - WS-IND-IOF. */
                REG_SVA0141B.SOR_PRMDIT.Value = REG_SVA0141B.SOR_PRMDIT - WS_IND_IOF;
            }


            /*" -2911- IF SOR-IND-IOF EQUAL 'S' AND SOR-PRMRTO NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IND_IOF == "S" && REG_SVA0141B.SOR_PRMRTO != 00)
            {

                /*" -2913- COMPUTE WS-IND-IOF ROUNDED EQUAL (SOR-PER-IOF * SOR-PRMRTO / 100) */
                WS_IND_IOF.Value = (REG_SVA0141B.SOR_PER_IOF * REG_SVA0141B.SOR_PRMRTO / 100f);

                /*" -2917- COMPUTE SOR-PRMRTO EQUAL SOR-PRMRTO - WS-IND-IOF. */
                REG_SVA0141B.SOR_PRMRTO.Value = REG_SVA0141B.SOR_PRMRTO - WS_IND_IOF;
            }


            /*" -2918- SET WS-COB00 TO 1. */
            WS_COB00.Value = 1;

            /*" -2920- SET WS-COB01 TO 1. */
            WS_COB01.Value = 1;

            /*" -2921- IF SOR-PRMRTO NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_PRMRTO != 00)
            {

                /*" -2923- MOVE 'R0930-00-TRATA-FEDERAL         ' TO LD01-OBSERVA1 */
                _.Move("R0930-00-TRATA-FEDERAL         ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA1);

                /*" -2924- PERFORM R0930-00-TRATA-FEDERAL */

                R0930_00_TRATA_FEDERAL_SECTION();

                /*" -2925- ELSE */
            }
            else
            {


                /*" -2926- IF SOR-PARVG082 GREATER 1 */

                if (REG_SVA0141B.SOR_PARVG082 > 1)
                {

                    /*" -2927- PERFORM R1000-00-TRATA-VG082 */

                    R1000_00_TRATA_VG082_SECTION();

                    /*" -2928- ELSE */
                }
                else
                {


                    /*" -2929- IF SOR-PARVG082 LESS 2 */

                    if (REG_SVA0141B.SOR_PARVG082 < 2)
                    {

                        /*" -2931- MOVE 'R1300-00-COBERTURA-UNICA       ' TO LD01-OBSERVA1 */
                        _.Move("R1300-00-COBERTURA-UNICA       ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA1);

                        /*" -2932- PERFORM R1300-00-COBERTURA-UNICA */

                        R1300_00_COBERTURA_UNICA_SECTION();

                        /*" -2933- ELSE */
                    }
                    else
                    {


                        /*" -2934- MOVE 'R0900-00  FATURA NAO EMITIDA   ' TO LD01-OBSERVA. */
                        _.Move("R0900-00  FATURA NAO EMITIDA   ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LIMPA-COBERTURA-SECTION */
        private void R0910_00_LIMPA_COBERTURA_SECTION()
        {
            /*" -2945- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", W.WABEND.WNR_EXEC_SQL);

            /*" -2948- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -2955- MOVE ZEROS TO WCOB00-RAMO(WS-COB00) WCOB00-COBE(WS-COB00) WCOB00-IMPSEG(WS-COB00) WCOB00-PRMTAR(WS-COB00) WCOB00-PERCEN(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN);

            /*" -2958- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

            /*" -2965- MOVE ZEROS TO WCOB01-RAMO(WS-COB01) WCOB01-COBE(WS-COB01) WCOB01-IMPSEG(WS-COB01) WCOB01-PERCEN(WS-COB01) WCOB01-PRMTAR(WS-COB01). */
            _.Move(0, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -2965- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0930-00-TRATA-FEDERAL-SECTION */
        private void R0930_00_TRATA_FEDERAL_SECTION()
        {
            /*" -2976- MOVE '0930' TO WNR-EXEC-SQL. */
            _.Move("0930", W.WABEND.WNR_EXEC_SQL);

            /*" -2979- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -2980- IF SOR-PREMIO-VG GREATER SOR-PRMRTO */

            if (REG_SVA0141B.SOR_PREMIO_VG > REG_SVA0141B.SOR_PRMRTO)
            {

                /*" -2982- COMPUTE SOR-PREMIO-VG EQUAL (SOR-PREMIO-VG - SOR-PRMRTO) */
                REG_SVA0141B.SOR_PREMIO_VG.Value = (REG_SVA0141B.SOR_PREMIO_VG - REG_SVA0141B.SOR_PRMRTO);

                /*" -2983- ELSE */
            }
            else
            {


                /*" -2986- MOVE ZEROS TO SOR-PRMRTO SOR-IMPRTO. */
                _.Move(0, REG_SVA0141B.SOR_PRMRTO, REG_SVA0141B.SOR_IMPRTO);
            }


            /*" -2988- IF SOR-PREMIO-VG GREATER SOR-PREMIO-AP AND SOR-PREMIO-VG GREATER SOR-PRMDIT */

            if (REG_SVA0141B.SOR_PREMIO_VG > REG_SVA0141B.SOR_PREMIO_AP && REG_SVA0141B.SOR_PREMIO_VG > REG_SVA0141B.SOR_PRMDIT)
            {

                /*" -2990- COMPUTE SOR-PREMIO-VG EQUAL (SOR-PREMIO-VG - SOR-PRMDIT) */
                REG_SVA0141B.SOR_PREMIO_VG.Value = (REG_SVA0141B.SOR_PREMIO_VG - REG_SVA0141B.SOR_PRMDIT);

                /*" -2991- ELSE */
            }
            else
            {


                /*" -2992- IF SOR-PREMIO-AP GREATER SOR-PRMDIT */

                if (REG_SVA0141B.SOR_PREMIO_AP > REG_SVA0141B.SOR_PRMDIT)
                {

                    /*" -2994- COMPUTE SOR-PREMIO-AP EQUAL (SOR-PREMIO-AP - SOR-PRMDIT) */
                    REG_SVA0141B.SOR_PREMIO_AP.Value = (REG_SVA0141B.SOR_PREMIO_AP - REG_SVA0141B.SOR_PRMDIT);

                    /*" -2995- ELSE */
                }
                else
                {


                    /*" -2996- IF SOR-PRMDIT NOT EQUAL ZEROS */

                    if (REG_SVA0141B.SOR_PRMDIT != 00)
                    {

                        /*" -3000- MOVE ZEROS TO SOR-PRMDIT SOR-IMPDIT. */
                        _.Move(0, REG_SVA0141B.SOR_PRMDIT, REG_SVA0141B.SOR_IMPDIT);
                    }

                }

            }


            /*" -3001- IF SOR-PREMIO-VG GREATER ZEROS */

            if (REG_SVA0141B.SOR_PREMIO_VG > 00)
            {

                /*" -3003- MOVE 93 TO VG082-RAMO-EMISSOR */
                _.Move(93, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);

                /*" -3005- MOVE SOR-PREMIO-VG TO VG082-VLR-PREMIO-RAMO */
                _.Move(REG_SVA0141B.SOR_PREMIO_VG, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);

                /*" -3008- PERFORM R1193-00-DIFERE-RAMO93. */

                R1193_00_DIFERE_RAMO93_SECTION();
            }


            /*" -3009- IF SOR-PREMIO-AP GREATER ZEROS */

            if (REG_SVA0141B.SOR_PREMIO_AP > 00)
            {

                /*" -3011- MOVE 82 TO VG082-RAMO-EMISSOR */
                _.Move(82, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);

                /*" -3013- MOVE SOR-PREMIO-AP TO VG082-VLR-PREMIO-RAMO */
                _.Move(REG_SVA0141B.SOR_PREMIO_AP, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);

                /*" -3016- PERFORM R1182-00-DIFERE-RAMO82. */

                R1182_00_DIFERE_RAMO82_SECTION();
            }


            /*" -3017- IF SOR-PRMDIT GREATER ZEROS */

            if (REG_SVA0141B.SOR_PRMDIT > 00)
            {

                /*" -3019- MOVE 90 TO VG082-RAMO-EMISSOR */
                _.Move(90, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);

                /*" -3021- MOVE SOR-PRMDIT TO VG082-VLR-PREMIO-RAMO */
                _.Move(REG_SVA0141B.SOR_PRMDIT, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);

                /*" -3024- PERFORM R0940-00-DIFERE-DIT. */

                R0940_00_DIFERE_DIT_SECTION();
            }


            /*" -3025- IF SOR-PRMRTO GREATER ZEROS */

            if (REG_SVA0141B.SOR_PRMRTO > 00)
            {

                /*" -3027- MOVE 86 TO VG082-RAMO-EMISSOR */
                _.Move(86, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);

                /*" -3029- MOVE SOR-PRMRTO TO VG082-VLR-PREMIO-RAMO */
                _.Move(REG_SVA0141B.SOR_PRMRTO, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);

                /*" -3032- PERFORM R0950-00-DIFERE-RTO. */

                R0950_00_DIFERE_RTO_SECTION();
            }


            /*" -3032- PERFORM R1200-00-AJUSTA-COBERTURA. */

            R1200_00_AJUSTA_COBERTURA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0930_99_SAIDA*/

        [StopWatch]
        /*" R0940-00-DIFERE-DIT-SECTION */
        private void R0940_00_DIFERE_DIT_SECTION()
        {
            /*" -3043- MOVE '0940' TO WNR-EXEC-SQL. */
            _.Move("0940", W.WABEND.WNR_EXEC_SQL);

            /*" -3046- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3048- MOVE VG082-RAMO-EMISSOR TO WCOB00-RAMO(WS-COB00) */
            _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO);

            /*" -3051- MOVE ZEROS TO WCOB00-COBE(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

            /*" -3052- IF SOR-IMPDIT NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IMPDIT != 00)
            {

                /*" -3054- MOVE SOR-IMPDIT TO WCOB00-IMPSEG(WS-COB00) */
                _.Move(REG_SVA0141B.SOR_IMPDIT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);

                /*" -3055- ELSE */
            }
            else
            {


                /*" -3056- IF SOR-IMPMORNATU NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_IMPMORNATU != 00)
                {

                    /*" -3058- MOVE SOR-IMPMORNATU TO WCOB00-IMPSEG(WS-COB00) */
                    _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);

                    /*" -3059- ELSE */
                }
                else
                {


                    /*" -3060- IF SOR-IMPMORACID NOT EQUAL ZEROS */

                    if (REG_SVA0141B.SOR_IMPMORACID != 00)
                    {

                        /*" -3062- MOVE SOR-IMPMORACID TO WCOB00-IMPSEG(WS-COB00) */
                        _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);

                        /*" -3063- ELSE */
                    }
                    else
                    {


                        /*" -3067- MOVE 10000 TO WCOB00-IMPSEG(WS-COB00). */
                        _.Move(10000, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);
                    }

                }

            }


            /*" -3069- MOVE ZEROS TO WS-PERCENT WS-VALOR. */
            _.Move(0, WS_PERCENT, WS_VALOR);

            /*" -3072- COMPUTE WS-PERCENT EQUAL (VG082-VLR-PREMIO-RAMO * 100 / WS-PRMBASE). */
            WS_PERCENT.Value = (VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO * 100 / WS_PRMBASE);

            /*" -3075- COMPUTE WS-VALOR EQUAL (PARCELAS-PRM-TARIFARIO-IX * WS-PERCENT / 100). */
            WS_VALOR.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX * WS_PERCENT / 100f);

            /*" -3077- MOVE WS-VALOR TO WCOB00-PRMTAR(WS-COB00). */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR);

            /*" -3081- MOVE WS-PERCENT TO WCOB00-PERCEN(WS-COB00). */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN);

            /*" -3083- MOVE VG082-RAMO-EMISSOR TO WCOB01-RAMO(WS-COB01). */
            _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

            /*" -3085- MOVE 05 TO WCOB01-COBE(WS-COB01). */
            _.Move(05, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

            /*" -3087- MOVE WCOB00-IMPSEG(WS-COB00) TO WCOB01-IMPSEG(WS-COB01). */
            _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

            /*" -3089- MOVE SOR-PRMDIT TO WCOB01-PRMTAR(WS-COB01). */
            _.Move(REG_SVA0141B.SOR_PRMDIT, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -3090- MOVE ZEROS TO WS-PERCENT. */
            _.Move(0, WS_PERCENT);

            /*" -3093- COMPUTE WS-PERCENT EQUAL (SOR-PRMDIT * 100 / WS-PRMBASE). */
            WS_PERCENT.Value = (REG_SVA0141B.SOR_PRMDIT * 100 / WS_PRMBASE);

            /*" -3095- MOVE WS-PERCENT TO WCOB01-PERCEN(WS-COB01) */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

            /*" -3096- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

            /*" -3096- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0940_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-DIFERE-RTO-SECTION */
        private void R0950_00_DIFERE_RTO_SECTION()
        {
            /*" -3107- MOVE '0950' TO WNR-EXEC-SQL. */
            _.Move("0950", W.WABEND.WNR_EXEC_SQL);

            /*" -3110- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3113- MOVE VG082-RAMO-EMISSOR TO WCOB00-RAMO(WS-COB00) WCOB01-RAMO(WS-COB01). */
            _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

            /*" -3115- MOVE ZEROS TO WCOB00-COBE(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

            /*" -3118- MOVE 01 TO WCOB01-COBE(WS-COB01). */
            _.Move(01, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

            /*" -3119- IF SOR-IMPRTO NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IMPRTO != 00)
            {

                /*" -3122- MOVE SOR-IMPRTO TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                _.Move(REG_SVA0141B.SOR_IMPRTO, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                /*" -3123- ELSE */
            }
            else
            {


                /*" -3124- IF SOR-IMPMORACID NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_IMPMORACID != 00)
                {

                    /*" -3127- MOVE SOR-IMPMORACID TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                    _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                    /*" -3128- ELSE */
                }
                else
                {


                    /*" -3129- IF SOR-IMPMORNATU NOT EQUAL ZEROS */

                    if (REG_SVA0141B.SOR_IMPMORNATU != 00)
                    {

                        /*" -3132- MOVE SOR-IMPMORNATU TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                        _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                        /*" -3133- ELSE */
                    }
                    else
                    {


                        /*" -3138- MOVE 10000 TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01). */
                        _.Move(10000, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);
                    }

                }

            }


            /*" -3140- MOVE ZEROS TO WS-PERCENT WS-VALOR. */
            _.Move(0, WS_PERCENT, WS_VALOR);

            /*" -3143- COMPUTE WS-PERCENT EQUAL (VG082-VLR-PREMIO-RAMO * 100 / WS-PRMBASE). */
            WS_PERCENT.Value = (VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO * 100 / WS_PRMBASE);

            /*" -3146- COMPUTE WS-VALOR EQUAL (PARCELAS-PRM-TARIFARIO-IX * WS-PERCENT / 100). */
            WS_VALOR.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX * WS_PERCENT / 100f);

            /*" -3149- MOVE WS-VALOR TO WCOB00-PRMTAR(WS-COB00) WCOB01-PRMTAR(WS-COB01). */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -3154- MOVE WS-PERCENT TO WCOB00-PERCEN(WS-COB00) WCOB01-PERCEN(WS-COB01). */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

            /*" -3155- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

            /*" -3155- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-TRATA-VG082-SECTION */
        private void R1000_00_TRATA_VG082_SECTION()
        {
            /*" -3166- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", W.WABEND.WNR_EXEC_SQL);

            /*" -3169- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3170- SET WS-COB00 TO 1. */
            WS_COB00.Value = 1;

            /*" -3173- SET WS-COB01 TO 1. */
            WS_COB01.Value = 1;

            /*" -3174- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -3176- PERFORM R1010-00-DECLARE-VG082. */

            R1010_00_DECLARE_VG082_SECTION();

            /*" -3178- PERFORM R1020-00-FETCH-VG082. */

            R1020_00_FETCH_VG082_SECTION();

            /*" -3179- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!W.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -3181- MOVE 'R1300-00-COBERTURA-UNICA - VG082' TO LD01-OBSERVA1 */
                _.Move("R1300-00-COBERTURA-UNICA - VG082", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA1);

                /*" -3182- PERFORM R1300-00-COBERTURA-UNICA */

                R1300_00_COBERTURA_UNICA_SECTION();

                /*" -3185- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3187- MOVE 'R1030-00-PROCESSA-VG082         ' TO LD01-OBSERVA1 */
            _.Move("R1030-00-PROCESSA-VG082         ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA1);

            /*" -3191- PERFORM R1030-00-PROCESSA-VG082 UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R1030_00_PROCESSA_VG082_SECTION();
            }

            /*" -3191- PERFORM R1200-00-AJUSTA-COBERTURA. */

            R1200_00_AJUSTA_COBERTURA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-DECLARE-VG082-SECTION */
        private void R1010_00_DECLARE_VG082_SECTION()
        {
            /*" -3202- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", W.WABEND.WNR_EXEC_SQL);

            /*" -3205- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3207- MOVE SOR-NUM-CERTIFICADO TO VG082-NUM-CERTIFICADO. */
            _.Move(REG_SVA0141B.SOR_NUM_CERTIFICADO, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_CERTIFICADO);

            /*" -3209- MOVE SOR-NUM-PARCELA TO VG082-NUM-PARCELA. */
            _.Move(REG_SVA0141B.SOR_NUM_PARCELA, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_PARCELA);

            /*" -3211- MOVE SOR-NUM-TITULO TO VG082-NUM-TITULO. */
            _.Move(REG_SVA0141B.SOR_NUM_TITULO, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_TITULO);

            /*" -3215- MOVE SOR-OCOVG082 TO VG082-OCORR-HISTORICO. */
            _.Move(REG_SVA0141B.SOR_OCOVG082, VG082.DCLVG_HIST_CONT_COBER.VG082_OCORR_HISTORICO);

            /*" -3231- PERFORM R1010_00_DECLARE_VG082_DB_DECLARE_1 */

            R1010_00_DECLARE_VG082_DB_DECLARE_1();

            /*" -3233- PERFORM R1010_00_DECLARE_VG082_DB_OPEN_1 */

            R1010_00_DECLARE_VG082_DB_OPEN_1();

            /*" -3237- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3238- DISPLAY 'R1010-00 - PROBLEMAS DECLARE (VG082)     ' */
                _.Display($"R1010-00 - PROBLEMAS DECLARE (VG082)     ");

                /*" -3238- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1010-00-DECLARE-VG082-DB-DECLARE-1 */
        public void R1010_00_DECLARE_VG082_DB_DECLARE_1()
        {
            /*" -3231- EXEC SQL DECLARE V0VG082 CURSOR WITH HOLD FOR SELECT NUM_CERTIFICADO ,NUM_PARCELA ,RAMO_EMISSOR ,VLR_PREMIO_RAMO FROM SEGUROS.VG_HIST_CONT_COBER WHERE NUM_CERTIFICADO = :VG082-NUM-CERTIFICADO AND NUM_PARCELA = :VG082-NUM-PARCELA AND NUM_TITULO = :VG082-NUM-TITULO AND OCORR_HISTORICO = :VG082-OCORR-HISTORICO AND VLR_PREMIO_RAMO > 0 ORDER BY NUM_CERTIFICADO ,NUM_PARCELA ,VLR_PREMIO_RAMO DESC WITH UR END-EXEC. */
            V0VG082 = new VA0141B_V0VG082(true);
            string GetQuery_V0VG082()
            {
                var query = @$"SELECT NUM_CERTIFICADO 
							,NUM_PARCELA 
							,RAMO_EMISSOR 
							,VLR_PREMIO_RAMO 
							FROM SEGUROS.VG_HIST_CONT_COBER 
							WHERE NUM_CERTIFICADO = '{VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_CERTIFICADO}' 
							AND NUM_PARCELA = '{VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_PARCELA}' 
							AND NUM_TITULO = '{VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_TITULO}' 
							AND OCORR_HISTORICO = '{VG082.DCLVG_HIST_CONT_COBER.VG082_OCORR_HISTORICO}' 
							AND VLR_PREMIO_RAMO > 0 
							ORDER BY NUM_CERTIFICADO 
							,NUM_PARCELA 
							,VLR_PREMIO_RAMO DESC";

                return query;
            }
            V0VG082.GetQueryEvent += GetQuery_V0VG082;

        }

        [StopWatch]
        /*" R1010-00-DECLARE-VG082-DB-OPEN-1 */
        public void R1010_00_DECLARE_VG082_DB_OPEN_1()
        {
            /*" -3233- EXEC SQL OPEN V0VG082 END-EXEC. */

            V0VG082.Open();

        }

        [StopWatch]
        /*" R2710-00-DECLARE-APOLCOSS-DB-DECLARE-1 */
        public void R2710_00_DECLARE_APOLCOSS_DB_DECLARE_1()
        {
            /*" -5234- EXEC SQL DECLARE V0APOLCOSS CURSOR WITH HOLD FOR SELECT DISTINCT COD_COSSEGURADORA FROM SEGUROS.APOL_COSSEGURADORA WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND DATA_INIVIGENCIA <= :ENDOSSOS-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :ENDOSSOS-DATA-INIVIGENCIA ORDER BY COD_COSSEGURADORA WITH UR END-EXEC. */
            V0APOLCOSS = new VA0141B_V0APOLCOSS(true);
            string GetQuery_V0APOLCOSS()
            {
                var query = @$"SELECT DISTINCT COD_COSSEGURADORA 
							FROM SEGUROS.APOL_COSSEGURADORA 
							WHERE NUM_APOLICE = '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}' 
							AND DATA_INIVIGENCIA <= '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}' 
							AND DATA_TERVIGENCIA >= '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}' 
							ORDER BY COD_COSSEGURADORA";

                return query;
            }
            V0APOLCOSS.GetQueryEvent += GetQuery_V0APOLCOSS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-FETCH-VG082-SECTION */
        private void R1020_00_FETCH_VG082_SECTION()
        {
            /*" -3249- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", W.WABEND.WNR_EXEC_SQL);

            /*" -3252- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3258- PERFORM R1020_00_FETCH_VG082_DB_FETCH_1 */

            R1020_00_FETCH_VG082_DB_FETCH_1();

            /*" -3262- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3262- PERFORM R1020_00_FETCH_VG082_DB_CLOSE_1 */

                R1020_00_FETCH_VG082_DB_CLOSE_1();

                /*" -3264- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -3266- GO TO R1020-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3267- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3268- DISPLAY 'R1020-00 - PROBLEMAS FETCH   (VG082)     ' */
                _.Display($"R1020-00 - PROBLEMAS FETCH   (VG082)     ");

                /*" -3268- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1020-00-FETCH-VG082-DB-FETCH-1 */
        public void R1020_00_FETCH_VG082_DB_FETCH_1()
        {
            /*" -3258- EXEC SQL FETCH V0VG082 INTO :VG082-NUM-CERTIFICADO ,:VG082-NUM-PARCELA ,:VG082-RAMO-EMISSOR ,:VG082-VLR-PREMIO-RAMO END-EXEC. */

            if (V0VG082.Fetch())
            {
                _.Move(V0VG082.VG082_NUM_CERTIFICADO, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_CERTIFICADO);
                _.Move(V0VG082.VG082_NUM_PARCELA, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_PARCELA);
                _.Move(V0VG082.VG082_RAMO_EMISSOR, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);
                _.Move(V0VG082.VG082_VLR_PREMIO_RAMO, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);
            }

        }

        [StopWatch]
        /*" R1020-00-FETCH-VG082-DB-CLOSE-1 */
        public void R1020_00_FETCH_VG082_DB_CLOSE_1()
        {
            /*" -3262- EXEC SQL CLOSE V0VG082 END-EXEC */

            V0VG082.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-PROCESSA-VG082-SECTION */
        private void R1030_00_PROCESSA_VG082_SECTION()
        {
            /*" -3279- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", W.WABEND.WNR_EXEC_SQL);

            /*" -3282- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3283- IF VG082-RAMO-EMISSOR EQUAL 29 */

            if (VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR == 29)
            {

                /*" -3284- PERFORM R1129-00-DIFERE-RAMO29 */

                R1129_00_DIFERE_RAMO29_SECTION();

                /*" -3285- ELSE */
            }
            else
            {


                /*" -3286- IF VG082-RAMO-EMISSOR EQUAL 82 */

                if (VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR == 82)
                {

                    /*" -3287- PERFORM R1182-00-DIFERE-RAMO82 */

                    R1182_00_DIFERE_RAMO82_SECTION();

                    /*" -3288- ELSE */
                }
                else
                {


                    /*" -3289- IF VG082-RAMO-EMISSOR EQUAL 84 */

                    if (VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR == 84)
                    {

                        /*" -3290- PERFORM R1184-00-DIFERE-RAMO84 */

                        R1184_00_DIFERE_RAMO84_SECTION();

                        /*" -3291- ELSE */
                    }
                    else
                    {


                        /*" -3292- IF VG082-RAMO-EMISSOR EQUAL 86 */

                        if (VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR == 86)
                        {

                            /*" -3293- PERFORM R1186-00-DIFERE-RAMO86 */

                            R1186_00_DIFERE_RAMO86_SECTION();

                            /*" -3294- ELSE */
                        }
                        else
                        {


                            /*" -3295- IF VG082-RAMO-EMISSOR EQUAL 87 */

                            if (VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR == 87)
                            {

                                /*" -3296- PERFORM R1187-00-DIFERE-RAMO87 */

                                R1187_00_DIFERE_RAMO87_SECTION();

                                /*" -3297- ELSE */
                            }
                            else
                            {


                                /*" -3298- IF VG082-RAMO-EMISSOR EQUAL 90 */

                                if (VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR == 90)
                                {

                                    /*" -3299- PERFORM R1190-00-DIFERE-RAMO90 */

                                    R1190_00_DIFERE_RAMO90_SECTION();

                                    /*" -3300- ELSE */
                                }
                                else
                                {


                                    /*" -3301- IF VG082-RAMO-EMISSOR EQUAL 93 */

                                    if (VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR == 93)
                                    {

                                        /*" -3302- PERFORM R1193-00-DIFERE-RAMO93 */

                                        R1193_00_DIFERE_RAMO93_SECTION();

                                        /*" -3303- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3305- MOVE 'R1030-00  FATURA NAO EMITIDA   ' TO LD01-OBSERVA */
                                        _.Move("R1030-00  FATURA NAO EMITIDA   ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                                        /*" -3305- GO TO R1030-90-LEITURA. */

                                        R1030_90_LEITURA(); //GOTO
                                        return;
                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1030_90_LEITURA */

            R1030_90_LEITURA();

        }

        [StopWatch]
        /*" R1030-90-LEITURA */
        private void R1030_90_LEITURA(bool isPerform = false)
        {
            /*" -3310- PERFORM R1020-00-FETCH-VG082. */

            R1020_00_FETCH_VG082_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1129-00-DIFERE-RAMO29-SECTION */
        private void R1129_00_DIFERE_RAMO29_SECTION()
        {
            /*" -3320- MOVE '1129' TO WNR-EXEC-SQL. */
            _.Move("1129", W.WABEND.WNR_EXEC_SQL);

            /*" -3323- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3326- MOVE VG082-RAMO-EMISSOR TO WCOB00-RAMO(WS-COB00) WCOB01-RAMO(WS-COB01). */
            _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

            /*" -3328- MOVE ZEROS TO WCOB00-COBE(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

            /*" -3331- MOVE 01 TO WCOB01-COBE(WS-COB01). */
            _.Move(01, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

            /*" -3332- IF SOR-IMPMORNATU NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IMPMORNATU != 00)
            {

                /*" -3335- MOVE SOR-IMPMORNATU TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                /*" -3336- ELSE */
            }
            else
            {


                /*" -3337- IF SOR-IMPMORACID NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_IMPMORACID != 00)
                {

                    /*" -3340- MOVE SOR-IMPMORACID TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                    _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                    /*" -3341- ELSE */
                }
                else
                {


                    /*" -3346- MOVE 10000 TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01). */
                    _.Move(10000, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);
                }

            }


            /*" -3348- MOVE ZEROS TO WS-PERCENT WS-VALOR. */
            _.Move(0, WS_PERCENT, WS_VALOR);

            /*" -3351- COMPUTE WS-PERCENT EQUAL (VG082-VLR-PREMIO-RAMO * 100 / WS-PRMBASE). */
            WS_PERCENT.Value = (VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO * 100 / WS_PRMBASE);

            /*" -3354- COMPUTE WS-VALOR EQUAL (PARCELAS-PRM-TARIFARIO-IX * WS-PERCENT / 100). */
            WS_VALOR.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX * WS_PERCENT / 100f);

            /*" -3357- MOVE WS-VALOR TO WCOB00-PRMTAR(WS-COB00) WCOB01-PRMTAR(WS-COB01). */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -3362- MOVE WS-PERCENT TO WCOB00-PERCEN(WS-COB00) WCOB01-PERCEN(WS-COB01). */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

            /*" -3363- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

            /*" -3363- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1129_99_SAIDA*/

        [StopWatch]
        /*" R1182-00-DIFERE-RAMO82-SECTION */
        private void R1182_00_DIFERE_RAMO82_SECTION()
        {
            /*" -3374- MOVE '1182' TO WNR-EXEC-SQL. */
            _.Move("1182", W.WABEND.WNR_EXEC_SQL);

            /*" -3377- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3380- MOVE VG082-RAMO-EMISSOR TO WCOB00-RAMO(WS-COB00) WCOB01-RAMO(WS-COB01). */
            _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

            /*" -3382- MOVE ZEROS TO WCOB00-COBE(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

            /*" -3385- MOVE 01 TO WCOB01-COBE(WS-COB01). */
            _.Move(01, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

            /*" -3386- IF SOR-IMPMORACID NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IMPMORACID != 00)
            {

                /*" -3389- MOVE SOR-IMPMORACID TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                /*" -3390- ELSE */
            }
            else
            {


                /*" -3391- IF SOR-IMPMORNATU NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_IMPMORNATU != 00)
                {

                    /*" -3394- MOVE SOR-IMPMORNATU TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                    _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                    /*" -3395- ELSE */
                }
                else
                {


                    /*" -3400- MOVE 10000 TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01). */
                    _.Move(10000, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);
                }

            }


            /*" -3402- MOVE ZEROS TO WS-PERCENT WS-VALOR. */
            _.Move(0, WS_PERCENT, WS_VALOR);

            /*" -3405- COMPUTE WS-PERCENT EQUAL (VG082-VLR-PREMIO-RAMO * 100 / WS-PRMBASE). */
            WS_PERCENT.Value = (VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO * 100 / WS_PRMBASE);

            /*" -3408- COMPUTE WS-VALOR EQUAL (PARCELAS-PRM-TARIFARIO-IX * WS-PERCENT / 100). */
            WS_VALOR.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX * WS_PERCENT / 100f);

            /*" -3411- MOVE WS-VALOR TO WCOB00-PRMTAR(WS-COB00) WCOB01-PRMTAR(WS-COB01). */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -3416- MOVE WS-PERCENT TO WCOB00-PERCEN(WS-COB00) WCOB01-PERCEN(WS-COB01). */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

            /*" -3417- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

            /*" -3417- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1182_99_SAIDA*/

        [StopWatch]
        /*" R1184-00-DIFERE-RAMO84-SECTION */
        private void R1184_00_DIFERE_RAMO84_SECTION()
        {
            /*" -3428- MOVE '1184' TO WNR-EXEC-SQL. */
            _.Move("1184", W.WABEND.WNR_EXEC_SQL);

            /*" -3431- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3434- MOVE VG082-RAMO-EMISSOR TO WCOB00-RAMO(WS-COB00) WCOB01-RAMO(WS-COB01). */
            _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

            /*" -3436- MOVE ZEROS TO WCOB00-COBE(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

            /*" -3439- MOVE 01 TO WCOB01-COBE(WS-COB01). */
            _.Move(01, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

            /*" -3440- IF SOR-IMPMORACID NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IMPMORACID != 00)
            {

                /*" -3443- MOVE SOR-IMPMORACID TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                /*" -3444- ELSE */
            }
            else
            {


                /*" -3445- IF SOR-IMPMORNATU NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_IMPMORNATU != 00)
                {

                    /*" -3448- MOVE SOR-IMPMORNATU TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                    _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                    /*" -3449- ELSE */
                }
                else
                {


                    /*" -3454- MOVE 10000 TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01). */
                    _.Move(10000, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);
                }

            }


            /*" -3456- MOVE ZEROS TO WS-PERCENT WS-VALOR. */
            _.Move(0, WS_PERCENT, WS_VALOR);

            /*" -3459- COMPUTE WS-PERCENT EQUAL (VG082-VLR-PREMIO-RAMO * 100 / WS-PRMBASE). */
            WS_PERCENT.Value = (VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO * 100 / WS_PRMBASE);

            /*" -3462- COMPUTE WS-VALOR EQUAL (PARCELAS-PRM-TARIFARIO-IX * WS-PERCENT / 100). */
            WS_VALOR.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX * WS_PERCENT / 100f);

            /*" -3465- MOVE WS-VALOR TO WCOB00-PRMTAR(WS-COB00) WCOB01-PRMTAR(WS-COB01). */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -3470- MOVE WS-PERCENT TO WCOB00-PERCEN(WS-COB00) WCOB01-PERCEN(WS-COB01). */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

            /*" -3471- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

            /*" -3471- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1184_99_SAIDA*/

        [StopWatch]
        /*" R1186-00-DIFERE-RAMO86-SECTION */
        private void R1186_00_DIFERE_RAMO86_SECTION()
        {
            /*" -3482- MOVE '1186' TO WNR-EXEC-SQL. */
            _.Move("1186", W.WABEND.WNR_EXEC_SQL);

            /*" -3485- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3488- MOVE VG082-RAMO-EMISSOR TO WCOB00-RAMO(WS-COB00) WCOB01-RAMO(WS-COB01). */
            _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

            /*" -3490- MOVE ZEROS TO WCOB00-COBE(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

            /*" -3493- MOVE 01 TO WCOB01-COBE(WS-COB01). */
            _.Move(01, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

            /*" -3494- IF SOR-IMPMORACID NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IMPMORACID != 00)
            {

                /*" -3497- MOVE SOR-IMPMORACID TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                /*" -3498- ELSE */
            }
            else
            {


                /*" -3499- IF SOR-IMPMORNATU NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_IMPMORNATU != 00)
                {

                    /*" -3502- MOVE SOR-IMPMORNATU TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                    _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                    /*" -3503- ELSE */
                }
                else
                {


                    /*" -3508- MOVE 10000 TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01). */
                    _.Move(10000, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);
                }

            }


            /*" -3510- MOVE ZEROS TO WS-PERCENT WS-VALOR. */
            _.Move(0, WS_PERCENT, WS_VALOR);

            /*" -3513- COMPUTE WS-PERCENT EQUAL (VG082-VLR-PREMIO-RAMO * 100 / WS-PRMBASE). */
            WS_PERCENT.Value = (VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO * 100 / WS_PRMBASE);

            /*" -3516- COMPUTE WS-VALOR EQUAL (PARCELAS-PRM-TARIFARIO-IX * WS-PERCENT / 100). */
            WS_VALOR.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX * WS_PERCENT / 100f);

            /*" -3519- MOVE WS-VALOR TO WCOB00-PRMTAR(WS-COB00) WCOB01-PRMTAR(WS-COB01). */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -3524- MOVE WS-PERCENT TO WCOB00-PERCEN(WS-COB00) WCOB01-PERCEN(WS-COB01). */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

            /*" -3525- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

            /*" -3525- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1186_99_SAIDA*/

        [StopWatch]
        /*" R1187-00-DIFERE-RAMO87-SECTION */
        private void R1187_00_DIFERE_RAMO87_SECTION()
        {
            /*" -3536- MOVE '1187' TO WNR-EXEC-SQL. */
            _.Move("1187", W.WABEND.WNR_EXEC_SQL);

            /*" -3539- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3542- MOVE VG082-RAMO-EMISSOR TO WCOB00-RAMO(WS-COB00) WCOB01-RAMO(WS-COB01). */
            _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

            /*" -3544- MOVE ZEROS TO WCOB00-COBE(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

            /*" -3547- MOVE 01 TO WCOB01-COBE(WS-COB01). */
            _.Move(01, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

            /*" -3548- IF SOR-IMPMORACID NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IMPMORACID != 00)
            {

                /*" -3551- MOVE SOR-IMPMORACID TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                /*" -3552- ELSE */
            }
            else
            {


                /*" -3553- IF SOR-IMPMORNATU NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_IMPMORNATU != 00)
                {

                    /*" -3556- MOVE SOR-IMPMORNATU TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                    _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                    /*" -3557- ELSE */
                }
                else
                {


                    /*" -3562- MOVE 10000 TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01). */
                    _.Move(10000, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);
                }

            }


            /*" -3564- MOVE ZEROS TO WS-PERCENT WS-VALOR. */
            _.Move(0, WS_PERCENT, WS_VALOR);

            /*" -3567- COMPUTE WS-PERCENT EQUAL (VG082-VLR-PREMIO-RAMO * 100 / WS-PRMBASE). */
            WS_PERCENT.Value = (VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO * 100 / WS_PRMBASE);

            /*" -3570- COMPUTE WS-VALOR EQUAL (PARCELAS-PRM-TARIFARIO-IX * WS-PERCENT / 100). */
            WS_VALOR.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX * WS_PERCENT / 100f);

            /*" -3573- MOVE WS-VALOR TO WCOB00-PRMTAR(WS-COB00) WCOB01-PRMTAR(WS-COB01). */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -3578- MOVE WS-PERCENT TO WCOB00-PERCEN(WS-COB00) WCOB01-PERCEN(WS-COB01). */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

            /*" -3579- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

            /*" -3579- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1187_99_SAIDA*/

        [StopWatch]
        /*" R1190-00-DIFERE-RAMO90-SECTION */
        private void R1190_00_DIFERE_RAMO90_SECTION()
        {
            /*" -3590- MOVE '1190' TO WNR-EXEC-SQL. */
            _.Move("1190", W.WABEND.WNR_EXEC_SQL);

            /*" -3593- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3594- IF SOR-PRMDIT NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_PRMDIT != 00)
            {

                /*" -3595- PERFORM R1191-00-DIFERE-PRMDIT */

                R1191_00_DIFERE_PRMDIT_SECTION();

                /*" -3598- GO TO R1190-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1190_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3601- MOVE VG082-RAMO-EMISSOR TO WCOB00-RAMO(WS-COB00) WCOB01-RAMO(WS-COB01). */
            _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

            /*" -3603- MOVE ZEROS TO WCOB00-COBE(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

            /*" -3606- MOVE 01 TO WCOB01-COBE(WS-COB01). */
            _.Move(01, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

            /*" -3607- IF SOR-IMPMORNATU NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IMPMORNATU != 00)
            {

                /*" -3610- MOVE SOR-IMPMORNATU TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                /*" -3611- ELSE */
            }
            else
            {


                /*" -3612- IF SOR-IMPMORACID NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_IMPMORACID != 00)
                {

                    /*" -3615- MOVE SOR-IMPMORACID TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                    _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                    /*" -3616- ELSE */
                }
                else
                {


                    /*" -3621- MOVE 10000 TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01). */
                    _.Move(10000, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);
                }

            }


            /*" -3623- MOVE ZEROS TO WS-PERCENT WS-VALOR. */
            _.Move(0, WS_PERCENT, WS_VALOR);

            /*" -3626- COMPUTE WS-PERCENT EQUAL (VG082-VLR-PREMIO-RAMO * 100 / WS-PRMBASE). */
            WS_PERCENT.Value = (VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO * 100 / WS_PRMBASE);

            /*" -3629- COMPUTE WS-VALOR EQUAL (PARCELAS-PRM-TARIFARIO-IX * WS-PERCENT / 100). */
            WS_VALOR.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX * WS_PERCENT / 100f);

            /*" -3632- MOVE WS-VALOR TO WCOB00-PRMTAR(WS-COB00) WCOB01-PRMTAR(WS-COB01). */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -3637- MOVE WS-PERCENT TO WCOB00-PERCEN(WS-COB00) WCOB01-PERCEN(WS-COB01). */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

            /*" -3638- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

            /*" -3638- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1190_99_SAIDA*/

        [StopWatch]
        /*" R1191-00-DIFERE-PRMDIT-SECTION */
        private void R1191_00_DIFERE_PRMDIT_SECTION()
        {
            /*" -3649- MOVE '1191' TO WNR-EXEC-SQL. */
            _.Move("1191", W.WABEND.WNR_EXEC_SQL);

            /*" -3652- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3654- MOVE VG082-RAMO-EMISSOR TO WCOB00-RAMO(WS-COB00) */
            _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO);

            /*" -3657- MOVE ZEROS TO WCOB00-COBE(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

            /*" -3658- IF SOR-IMPDIT NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IMPDIT != 00)
            {

                /*" -3660- MOVE SOR-IMPDIT TO WCOB00-IMPSEG(WS-COB00) */
                _.Move(REG_SVA0141B.SOR_IMPDIT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);

                /*" -3661- ELSE */
            }
            else
            {


                /*" -3662- IF SOR-IMPMORNATU NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_IMPMORNATU != 00)
                {

                    /*" -3664- MOVE SOR-IMPMORNATU TO WCOB00-IMPSEG(WS-COB00) */
                    _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);

                    /*" -3665- ELSE */
                }
                else
                {


                    /*" -3666- IF SOR-IMPMORACID NOT EQUAL ZEROS */

                    if (REG_SVA0141B.SOR_IMPMORACID != 00)
                    {

                        /*" -3668- MOVE SOR-IMPMORACID TO WCOB00-IMPSEG(WS-COB00) */
                        _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);

                        /*" -3669- ELSE */
                    }
                    else
                    {


                        /*" -3673- MOVE 10000 TO WCOB00-IMPSEG(WS-COB00). */
                        _.Move(10000, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);
                    }

                }

            }


            /*" -3675- MOVE ZEROS TO WS-PERCENT WS-VALOR. */
            _.Move(0, WS_PERCENT, WS_VALOR);

            /*" -3678- COMPUTE WS-PERCENT EQUAL (VG082-VLR-PREMIO-RAMO * 100 / WS-PRMBASE). */
            WS_PERCENT.Value = (VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO * 100 / WS_PRMBASE);

            /*" -3681- COMPUTE WS-VALOR EQUAL (PARCELAS-PRM-TARIFARIO-IX * WS-PERCENT / 100). */
            WS_VALOR.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX * WS_PERCENT / 100f);

            /*" -3683- MOVE WS-VALOR TO WCOB00-PRMTAR(WS-COB00). */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR);

            /*" -3687- MOVE WS-PERCENT TO WCOB00-PERCEN(WS-COB00). */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN);

            /*" -3688- IF SOR-PRMDIT GREATER WS-VALOR */

            if (REG_SVA0141B.SOR_PRMDIT > WS_VALOR)
            {

                /*" -3690- MOVE VG082-RAMO-EMISSOR TO WCOB01-RAMO(WS-COB01) */
                _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

                /*" -3692- MOVE 01 TO WCOB01-COBE(WS-COB01) */
                _.Move(01, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

                /*" -3694- MOVE WCOB00-IMPSEG(WS-COB00) TO WCOB01-IMPSEG(WS-COB01) */
                _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                /*" -3696- MOVE WS-VALOR TO WCOB01-PRMTAR(WS-COB01) */
                _.Move(WS_VALOR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

                /*" -3698- MOVE WS-PERCENT TO WCOB01-PERCEN(WS-COB01) */
                _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

                /*" -3700- MOVE ZEROS TO SOR-PRMDIT SOR-IMPDIT */
                _.Move(0, REG_SVA0141B.SOR_PRMDIT, REG_SVA0141B.SOR_IMPDIT);

                /*" -3701- SET WS-COB00 UP BY 1 */
                WS_COB00.Value += 1;

                /*" -3702- SET WS-COB01 UP BY 1 */
                WS_COB01.Value += 1;

                /*" -3705- GO TO R1191-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1191_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3706- IF SOR-PRMDIT EQUAL WS-VALOR */

            if (REG_SVA0141B.SOR_PRMDIT == WS_VALOR)
            {

                /*" -3708- MOVE VG082-RAMO-EMISSOR TO WCOB01-RAMO(WS-COB01) */
                _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

                /*" -3710- MOVE 05 TO WCOB01-COBE(WS-COB01) */
                _.Move(05, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

                /*" -3712- MOVE WCOB00-IMPSEG(WS-COB00) TO WCOB01-IMPSEG(WS-COB01) */
                _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                /*" -3714- MOVE WS-VALOR TO WCOB01-PRMTAR(WS-COB01) */
                _.Move(WS_VALOR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

                /*" -3716- MOVE WS-PERCENT TO WCOB01-PERCEN(WS-COB01) */
                _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

                /*" -3718- MOVE ZEROS TO SOR-PRMDIT SOR-IMPDIT */
                _.Move(0, REG_SVA0141B.SOR_PRMDIT, REG_SVA0141B.SOR_IMPDIT);

                /*" -3719- SET WS-COB00 UP BY 1 */
                WS_COB00.Value += 1;

                /*" -3720- SET WS-COB01 UP BY 1 */
                WS_COB01.Value += 1;

                /*" -3723- GO TO R1191-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1191_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3725- MOVE VG082-RAMO-EMISSOR TO WCOB01-RAMO(WS-COB01). */
            _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

            /*" -3727- MOVE 05 TO WCOB01-COBE(WS-COB01). */
            _.Move(05, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

            /*" -3729- MOVE WCOB00-IMPSEG(WS-COB00) TO WCOB01-IMPSEG(WS-COB01). */
            _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

            /*" -3731- MOVE SOR-PRMDIT TO WCOB01-PRMTAR(WS-COB01). */
            _.Move(REG_SVA0141B.SOR_PRMDIT, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -3732- MOVE ZEROS TO WS-PERCENT. */
            _.Move(0, WS_PERCENT);

            /*" -3735- COMPUTE WS-PERCENT EQUAL (SOR-PRMDIT * 100 / WS-PRMBASE). */
            WS_PERCENT.Value = (REG_SVA0141B.SOR_PRMDIT * 100 / WS_PRMBASE);

            /*" -3737- MOVE WS-PERCENT TO WCOB01-PERCEN(WS-COB01) */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

            /*" -3740- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

            /*" -3742- MOVE VG082-RAMO-EMISSOR TO WCOB01-RAMO(WS-COB01). */
            _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

            /*" -3744- MOVE 01 TO WCOB01-COBE(WS-COB01). */
            _.Move(01, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

            /*" -3747- MOVE WCOB00-IMPSEG(WS-COB00) TO WCOB01-IMPSEG(WS-COB01). */
            _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

            /*" -3749- COMPUTE WCOB01-PRMTAR(WS-COB01) EQUAL (WS-VALOR - SOR-PRMDIT). */
            TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR.Value = (WS_VALOR - REG_SVA0141B.SOR_PRMDIT);

            /*" -3751- COMPUTE WCOB01-PERCEN(WS-COB01) EQUAL WCOB00-PERCEN(WS-COB00) - WS-PERCENT. */
            TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN.Value = TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN.Value - WS_PERCENT;

            /*" -3752- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

            /*" -3755- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

            /*" -3756- MOVE ZEROS TO SOR-PRMDIT SOR-IMPDIT. */
            _.Move(0, REG_SVA0141B.SOR_PRMDIT, REG_SVA0141B.SOR_IMPDIT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1191_99_SAIDA*/

        [StopWatch]
        /*" R1193-00-DIFERE-RAMO93-SECTION */
        private void R1193_00_DIFERE_RAMO93_SECTION()
        {
            /*" -3767- MOVE '1193' TO WNR-EXEC-SQL. */
            _.Move("1193", W.WABEND.WNR_EXEC_SQL);

            /*" -3770- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3773- MOVE VG082-RAMO-EMISSOR TO WCOB00-RAMO(WS-COB00) WCOB01-RAMO(WS-COB01). */
            _.Move(VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

            /*" -3775- MOVE ZEROS TO WCOB00-COBE(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

            /*" -3778- MOVE 11 TO WCOB01-COBE(WS-COB01). */
            _.Move(11, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

            /*" -3779- IF SOR-IMPMORNATU NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IMPMORNATU != 00)
            {

                /*" -3782- MOVE SOR-IMPMORNATU TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                /*" -3783- ELSE */
            }
            else
            {


                /*" -3784- IF SOR-IMPMORACID NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_IMPMORACID != 00)
                {

                    /*" -3787- MOVE SOR-IMPMORACID TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01) */
                    _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                    /*" -3788- ELSE */
                }
                else
                {


                    /*" -3793- MOVE 10000 TO WCOB00-IMPSEG(WS-COB00) WCOB01-IMPSEG(WS-COB01). */
                    _.Move(10000, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);
                }

            }


            /*" -3795- MOVE ZEROS TO WS-PERCENT WS-VALOR. */
            _.Move(0, WS_PERCENT, WS_VALOR);

            /*" -3798- COMPUTE WS-PERCENT EQUAL (VG082-VLR-PREMIO-RAMO * 100 / WS-PRMBASE). */
            WS_PERCENT.Value = (VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO * 100 / WS_PRMBASE);

            /*" -3801- COMPUTE WS-VALOR EQUAL (PARCELAS-PRM-TARIFARIO-IX * WS-PERCENT / 100). */
            WS_VALOR.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX * WS_PERCENT / 100f);

            /*" -3804- MOVE WS-VALOR TO WCOB00-PRMTAR(WS-COB00) WCOB01-PRMTAR(WS-COB01). */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -3809- MOVE WS-PERCENT TO WCOB00-PERCEN(WS-COB00) WCOB01-PERCEN(WS-COB01). */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

            /*" -3810- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

            /*" -3810- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1193_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-AJUSTA-COBERTURA-SECTION */
        private void R1200_00_AJUSTA_COBERTURA_SECTION()
        {
            /*" -3821- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", W.WABEND.WNR_EXEC_SQL);

            /*" -3824- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3826- MOVE PARCELAS-PRM-TARIFARIO-IX TO WS-VALOR. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, WS_VALOR);

            /*" -3828- MOVE 100 TO WS-PERCENT. */
            _.Move(100, WS_PERCENT);

            /*" -3829- MOVE 10 TO WS-IND. */
            _.Move(10, WS_IND);

            /*" -3832- PERFORM R1210-00-AJUSTA-COB00 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R1210_00_AJUSTA_COB00_SECTION();

            }

            /*" -3834- MOVE PARCELAS-PRM-TARIFARIO-IX TO WS-VALOR. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, WS_VALOR);

            /*" -3836- MOVE 100 TO WS-PERCENT. */
            _.Move(100, WS_PERCENT);

            /*" -3837- MOVE 10 TO WS-IND. */
            _.Move(10, WS_IND);

            /*" -3837- PERFORM R1220-00-AJUSTA-COB01 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R1220_00_AJUSTA_COB01_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-AJUSTA-COB00-SECTION */
        private void R1210_00_AJUSTA_COB00_SECTION()
        {
            /*" -3848- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", W.WABEND.WNR_EXEC_SQL);

            /*" -3851- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3853- SET WS-COB00 TO WS-IND. */
            WS_COB00.Value = WS_IND;

            /*" -3857- IF WCOB00-RAMO(WS-COB00) EQUAL ZEROS OR WCOB00-IMPSEG(WS-COB00) NOT GREATER ZEROS OR WCOB00-PRMTAR(WS-COB00) NOT GREATER ZEROS OR WCOB00-PERCEN(WS-COB00) NOT GREATER ZEROS */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO == 00 || TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG <= 00 || TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR <= 00 || TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN <= 00)
            {

                /*" -3863- MOVE ZEROS TO WCOB00-RAMO(WS-COB00) WCOB00-COBE(WS-COB00) WCOB00-IMPSEG(WS-COB00) WCOB00-PRMTAR(WS-COB00) WCOB00-PERCEN(WS-COB00) */
                _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN);

                /*" -3864- SUBTRACT 1 FROM WS-IND */
                WS_IND.Value = WS_IND - 1;

                /*" -3867- GO TO R1210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3868- IF WS-IND EQUAL 1 */

            if (WS_IND == 1)
            {

                /*" -3870- MOVE WS-VALOR TO WCOB00-PRMTAR(WS-COB00) */
                _.Move(WS_VALOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR);

                /*" -3872- MOVE WS-PERCENT TO WCOB00-PERCEN(WS-COB00) */
                _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN);

                /*" -3875- GO TO R1210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3876- IF WCOB00-RAMO(WS-COB00) NOT EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO != 00)
            {

                /*" -3878- SUBTRACT WCOB00-PRMTAR(WS-COB00) FROM WS-VALOR */
                WS_VALOR.Value = WS_VALOR - TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR;

                /*" -3882- SUBTRACT WCOB00-PERCEN(WS-COB00) FROM WS-PERCENT. */
                WS_PERCENT.Value = WS_PERCENT - TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN;
            }


            /*" -3882- SUBTRACT 1 FROM WS-IND. */
            WS_IND.Value = WS_IND - 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-AJUSTA-COB01-SECTION */
        private void R1220_00_AJUSTA_COB01_SECTION()
        {
            /*" -3893- MOVE '1220' TO WNR-EXEC-SQL. */
            _.Move("1220", W.WABEND.WNR_EXEC_SQL);

            /*" -3896- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3898- SET WS-COB01 TO WS-IND. */
            WS_COB01.Value = WS_IND;

            /*" -3903- IF WCOB01-RAMO(WS-COB01) EQUAL ZEROS OR WCOB01-COBE(WS-COB01) EQUAL ZEROS OR WCOB01-IMPSEG(WS-COB01) NOT GREATER ZEROS OR WCOB01-PRMTAR(WS-COB01) NOT GREATER ZEROS OR WCOB01-PERCEN(WS-COB01) NOT GREATER ZEROS */

            if (TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO == 00 || TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE == 00 || TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG <= 00 || TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR <= 00 || TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN <= 00)
            {

                /*" -3909- MOVE ZEROS TO WCOB01-RAMO(WS-COB01) WCOB01-COBE(WS-COB01) WCOB01-IMPSEG(WS-COB01) WCOB01-PRMTAR(WS-COB01) WCOB01-PERCEN(WS-COB01) */
                _.Move(0, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

                /*" -3910- SUBTRACT 1 FROM WS-IND */
                WS_IND.Value = WS_IND - 1;

                /*" -3913- GO TO R1220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3914- IF WS-IND EQUAL 1 */

            if (WS_IND == 1)
            {

                /*" -3916- MOVE WS-VALOR TO WCOB01-PRMTAR(WS-COB01) */
                _.Move(WS_VALOR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

                /*" -3918- MOVE WS-PERCENT TO WCOB01-PERCEN(WS-COB01) */
                _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

                /*" -3921- GO TO R1220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3922- IF WCOB01-RAMO(WS-COB01) NOT EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO != 00)
            {

                /*" -3924- SUBTRACT WCOB01-PRMTAR(WS-COB01) FROM WS-VALOR */
                WS_VALOR.Value = WS_VALOR - TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR;

                /*" -3928- SUBTRACT WCOB01-PERCEN(WS-COB01) FROM WS-PERCENT. */
                WS_PERCENT.Value = WS_PERCENT - TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN;
            }


            /*" -3928- SUBTRACT 1 FROM WS-IND. */
            WS_IND.Value = WS_IND - 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-COBERTURA-UNICA-SECTION */
        private void R1300_00_COBERTURA_UNICA_SECTION()
        {
            /*" -3939- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", W.WABEND.WNR_EXEC_SQL);

            /*" -3942- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -3947- IF SOR-RAMO EQUAL 82 AND SOR-PREMIO-AP NOT EQUAL ZEROS AND SOR-IMPMORACID NOT EQUAL ZEROS AND SOR-PREMIO-VG EQUAL ZEROS AND SOR-PRMDIT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_RAMO == 82 && REG_SVA0141B.SOR_PREMIO_AP != 00 && REG_SVA0141B.SOR_IMPMORACID != 00 && REG_SVA0141B.SOR_PREMIO_VG == 00 && REG_SVA0141B.SOR_PRMDIT == 00)
            {

                /*" -3948- SET WS-COB00 TO 1 */
                WS_COB00.Value = 1;

                /*" -3950- MOVE 82 TO WCOB00-RAMO(WS-COB00) */
                _.Move(82, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO);

                /*" -3952- MOVE ZEROS TO WCOB00-COBE(WS-COB00) */
                _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

                /*" -3954- MOVE SOR-IMPMORACID TO WCOB00-IMPSEG(WS-COB00) */
                _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);

                /*" -3956- MOVE PARCELAS-PRM-TARIFARIO-IX TO WCOB00-PRMTAR(WS-COB00) */
                _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR);

                /*" -3958- MOVE 100 TO WCOB00-PERCEN(WS-COB00) */
                _.Move(100, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN);

                /*" -3959- SET WS-COB01 TO 1 */
                WS_COB01.Value = 1;

                /*" -3961- MOVE 82 TO WCOB01-RAMO(WS-COB01) */
                _.Move(82, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

                /*" -3963- MOVE 01 TO WCOB01-COBE(WS-COB01) */
                _.Move(01, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

                /*" -3965- MOVE SOR-IMPMORACID TO WCOB01-IMPSEG(WS-COB01) */
                _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                /*" -3967- MOVE PARCELAS-PRM-TARIFARIO-IX TO WCOB01-PRMTAR(WS-COB01) */
                _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

                /*" -3969- MOVE 100 TO WCOB01-PERCEN(WS-COB01) */
                _.Move(100, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

                /*" -3970- ELSE */
            }
            else
            {


                /*" -3975- IF SOR-RAMO EQUAL 93 AND SOR-PREMIO-VG NOT EQUAL ZEROS AND SOR-IMPMORNATU NOT EQUAL ZEROS AND SOR-PREMIO-AP EQUAL ZEROS AND SOR-PRMDIT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_RAMO == 93 && REG_SVA0141B.SOR_PREMIO_VG != 00 && REG_SVA0141B.SOR_IMPMORNATU != 00 && REG_SVA0141B.SOR_PREMIO_AP == 00 && REG_SVA0141B.SOR_PRMDIT == 00)
                {

                    /*" -3976- SET WS-COB00 TO 1 */
                    WS_COB00.Value = 1;

                    /*" -3978- MOVE 93 TO WCOB00-RAMO(WS-COB00) */
                    _.Move(93, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO);

                    /*" -3980- MOVE ZEROS TO WCOB00-COBE(WS-COB00) */
                    _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

                    /*" -3982- MOVE SOR-IMPMORNATU TO WCOB00-IMPSEG(WS-COB00) */
                    _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);

                    /*" -3984- MOVE PARCELAS-PRM-TARIFARIO-IX TO WCOB00-PRMTAR(WS-COB00) */
                    _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR);

                    /*" -3986- MOVE 100 TO WCOB00-PERCEN(WS-COB00) */
                    _.Move(100, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN);

                    /*" -3987- SET WS-COB01 TO 1 */
                    WS_COB01.Value = 1;

                    /*" -3989- MOVE 93 TO WCOB01-RAMO(WS-COB01) */
                    _.Move(93, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

                    /*" -3991- MOVE 11 TO WCOB01-COBE(WS-COB01) */
                    _.Move(11, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

                    /*" -3993- MOVE SOR-IMPMORNATU TO WCOB01-IMPSEG(WS-COB01) */
                    _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                    /*" -3995- MOVE PARCELAS-PRM-TARIFARIO-IX TO WCOB01-PRMTAR(WS-COB01) */
                    _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

                    /*" -3997- MOVE 100 TO WCOB01-PERCEN(WS-COB01) */
                    _.Move(100, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

                    /*" -3998- ELSE */
                }
                else
                {


                    /*" -4000- IF SOR-RAMO EQUAL 97 AND SOR-PRMDIT EQUAL ZEROS */

                    if (REG_SVA0141B.SOR_RAMO == 97 && REG_SVA0141B.SOR_PRMDIT == 00)
                    {

                        /*" -4001- PERFORM R1340-00-TRATA-RAMO97 */

                        R1340_00_TRATA_RAMO97_SECTION();

                        /*" -4002- ELSE */
                    }
                    else
                    {


                        /*" -4003- IF SOR-PRMDIT NOT EQUAL ZEROS */

                        if (REG_SVA0141B.SOR_PRMDIT != 00)
                        {

                            /*" -4004- PERFORM R1380-00-TRATA-PRMDIT */

                            R1380_00_TRATA_PRMDIT_SECTION();

                            /*" -4005- ELSE */
                        }
                        else
                        {


                            /*" -4010- IF SOR-RAMO EQUAL 93 AND SOR-PREMIO-VG NOT EQUAL ZEROS AND SOR-IMPMORNATU NOT EQUAL ZEROS AND SOR-PREMIO-AP NOT EQUAL ZEROS AND SOR-PRMDIT EQUAL ZEROS */

                            if (REG_SVA0141B.SOR_RAMO == 93 && REG_SVA0141B.SOR_PREMIO_VG != 00 && REG_SVA0141B.SOR_IMPMORNATU != 00 && REG_SVA0141B.SOR_PREMIO_AP != 00 && REG_SVA0141B.SOR_PRMDIT == 00)
                            {

                                /*" -4011- PERFORM R1340-00-TRATA-RAMO97 */

                                R1340_00_TRATA_RAMO97_SECTION();

                                /*" -4012- ELSE */
                            }
                            else
                            {


                                /*" -4017- IF SOR-RAMO EQUAL 82 AND SOR-PREMIO-VG NOT EQUAL ZEROS AND SOR-IMPMORACID NOT EQUAL ZEROS AND SOR-PREMIO-AP NOT EQUAL ZEROS AND SOR-PRMDIT EQUAL ZEROS */

                                if (REG_SVA0141B.SOR_RAMO == 82 && REG_SVA0141B.SOR_PREMIO_VG != 00 && REG_SVA0141B.SOR_IMPMORACID != 00 && REG_SVA0141B.SOR_PREMIO_AP != 00 && REG_SVA0141B.SOR_PRMDIT == 00)
                                {

                                    /*" -4018- PERFORM R1340-00-TRATA-RAMO97 */

                                    R1340_00_TRATA_RAMO97_SECTION();

                                    /*" -4019- ELSE */
                                }
                                else
                                {


                                    /*" -4020- MOVE 'R1300-00  FATURA NAO EMITIDA   ' TO LD01-OBSERVA. */
                                    _.Move("R1300-00  FATURA NAO EMITIDA   ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);
                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1340-00-TRATA-RAMO97-SECTION */
        private void R1340_00_TRATA_RAMO97_SECTION()
        {
            /*" -4031- MOVE '1340' TO WNR-EXEC-SQL. */
            _.Move("1340", W.WABEND.WNR_EXEC_SQL);

            /*" -4034- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4036- IF SOR-PREMIO-VG NOT EQUAL ZEROS AND SOR-PREMIO-AP NOT EQUAL ZEROS */

            if (REG_SVA0141B.SOR_PREMIO_VG != 00 && REG_SVA0141B.SOR_PREMIO_AP != 00)
            {

                /*" -4037- PERFORM R1360-00-PRORATA-RAMO97 */

                R1360_00_PRORATA_RAMO97_SECTION();

                /*" -4038- ELSE */
            }
            else
            {


                /*" -4040- IF SOR-PREMIO-VG EQUAL ZEROS AND SOR-IMPMORACID NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_PREMIO_VG == 00 && REG_SVA0141B.SOR_IMPMORACID != 00)
                {

                    /*" -4041- SET WS-COB00 TO 1 */
                    WS_COB00.Value = 1;

                    /*" -4043- MOVE 82 TO WCOB00-RAMO(WS-COB00) */
                    _.Move(82, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO);

                    /*" -4045- MOVE ZEROS TO WCOB00-COBE(WS-COB00) */
                    _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

                    /*" -4047- MOVE SOR-IMPMORACID TO WCOB00-IMPSEG(WS-COB00) */
                    _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);

                    /*" -4049- MOVE PARCELAS-PRM-TARIFARIO-IX TO WCOB00-PRMTAR(WS-COB00) */
                    _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR);

                    /*" -4051- MOVE 100 TO WCOB00-PERCEN(WS-COB00) */
                    _.Move(100, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN);

                    /*" -4052- SET WS-COB01 TO 1 */
                    WS_COB01.Value = 1;

                    /*" -4054- MOVE 82 TO WCOB01-RAMO(WS-COB01) */
                    _.Move(82, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

                    /*" -4056- MOVE 01 TO WCOB01-COBE(WS-COB01) */
                    _.Move(01, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

                    /*" -4058- MOVE SOR-IMPMORACID TO WCOB01-IMPSEG(WS-COB01) */
                    _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                    /*" -4060- MOVE PARCELAS-PRM-TARIFARIO-IX TO WCOB01-PRMTAR(WS-COB01) */
                    _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

                    /*" -4062- MOVE 100 TO WCOB01-PERCEN(WS-COB01) */
                    _.Move(100, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

                    /*" -4063- ELSE */
                }
                else
                {


                    /*" -4065- IF SOR-PREMIO-AP EQUAL ZEROS AND SOR-IMPMORNATU NOT EQUAL ZEROS */

                    if (REG_SVA0141B.SOR_PREMIO_AP == 00 && REG_SVA0141B.SOR_IMPMORNATU != 00)
                    {

                        /*" -4066- SET WS-COB00 TO 1 */
                        WS_COB00.Value = 1;

                        /*" -4068- MOVE 93 TO WCOB00-RAMO(WS-COB00) */
                        _.Move(93, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO);

                        /*" -4070- MOVE ZEROS TO WCOB00-COBE(WS-COB00) */
                        _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

                        /*" -4072- MOVE SOR-IMPMORNATU TO WCOB00-IMPSEG(WS-COB00) */
                        _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);

                        /*" -4074- MOVE PARCELAS-PRM-TARIFARIO-IX TO WCOB00-PRMTAR(WS-COB00) */
                        _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR);

                        /*" -4076- MOVE 100 TO WCOB00-PERCEN(WS-COB00) */
                        _.Move(100, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN);

                        /*" -4077- SET WS-COB01 TO 1 */
                        WS_COB01.Value = 1;

                        /*" -4079- MOVE 93 TO WCOB01-RAMO(WS-COB01) */
                        _.Move(93, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

                        /*" -4081- MOVE 11 TO WCOB01-COBE(WS-COB01) */
                        _.Move(11, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

                        /*" -4083- MOVE SOR-IMPMORNATU TO WCOB01-IMPSEG(WS-COB01) */
                        _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                        /*" -4085- MOVE PARCELAS-PRM-TARIFARIO-IX TO WCOB01-PRMTAR(WS-COB01) */
                        _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

                        /*" -4087- MOVE 100 TO WCOB01-PERCEN(WS-COB01) */
                        _.Move(100, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

                        /*" -4088- ELSE */
                    }
                    else
                    {


                        /*" -4089- MOVE 'R1340-00  FATURA NAO EMITIDA   ' TO LD01-OBSERVA. */
                        _.Move("R1340-00  FATURA NAO EMITIDA   ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1340_99_SAIDA*/

        [StopWatch]
        /*" R1360-00-PRORATA-RAMO97-SECTION */
        private void R1360_00_PRORATA_RAMO97_SECTION()
        {
            /*" -4100- MOVE '1360' TO WNR-EXEC-SQL. */
            _.Move("1360", W.WABEND.WNR_EXEC_SQL);

            /*" -4103- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4106- IF SOR-IMPMORACID NOT EQUAL ZEROS AND SOR-IMPMORNATU NOT EQUAL ZEROS NEXT SENTENCE */

            if (REG_SVA0141B.SOR_IMPMORACID != 00 && REG_SVA0141B.SOR_IMPMORNATU != 00)
            {

                /*" -4107- ELSE */
            }
            else
            {


                /*" -4109- IF SOR-IMPMORACID EQUAL ZEROS AND SOR-IMPMORNATU EQUAL ZEROS */

                if (REG_SVA0141B.SOR_IMPMORACID == 00 && REG_SVA0141B.SOR_IMPMORNATU == 00)
                {

                    /*" -4112- MOVE 10000 TO SOR-IMPMORACID SOR-IMPMORNATU */
                    _.Move(10000, REG_SVA0141B.SOR_IMPMORACID, REG_SVA0141B.SOR_IMPMORNATU);

                    /*" -4113- ELSE */
                }
                else
                {


                    /*" -4114- IF SOR-IMPMORACID EQUAL ZEROS */

                    if (REG_SVA0141B.SOR_IMPMORACID == 00)
                    {

                        /*" -4116- MOVE SOR-IMPMORNATU TO SOR-IMPMORACID */
                        _.Move(REG_SVA0141B.SOR_IMPMORNATU, REG_SVA0141B.SOR_IMPMORACID);

                        /*" -4117- ELSE */
                    }
                    else
                    {


                        /*" -4118- IF SOR-IMPMORNATU EQUAL ZEROS */

                        if (REG_SVA0141B.SOR_IMPMORNATU == 00)
                        {

                            /*" -4122- MOVE SOR-IMPMORACID TO SOR-IMPMORNATU. */
                            _.Move(REG_SVA0141B.SOR_IMPMORACID, REG_SVA0141B.SOR_IMPMORNATU);
                        }

                    }

                }

            }


            /*" -4125- MOVE ZEROS TO WS-PERCENT WS-VALOR. */
            _.Move(0, WS_PERCENT, WS_VALOR);

            /*" -4128- COMPUTE WS-PERCENT EQUAL (SOR-PREMIO-AP * 100 / WS-PRMBASE). */
            WS_PERCENT.Value = (REG_SVA0141B.SOR_PREMIO_AP * 100 / WS_PRMBASE);

            /*" -4133- COMPUTE WS-VALOR EQUAL (PARCELAS-PRM-TARIFARIO-IX * WS-PERCENT / 100). */
            WS_VALOR.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX * WS_PERCENT / 100f);

            /*" -4134- SET WS-COB00 TO 1. */
            WS_COB00.Value = 1;

            /*" -4136- MOVE 82 TO WCOB00-RAMO(WS-COB00). */
            _.Move(82, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO);

            /*" -4138- MOVE ZEROS TO WCOB00-COBE(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

            /*" -4140- MOVE SOR-IMPMORACID TO WCOB00-IMPSEG(WS-COB00). */
            _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);

            /*" -4142- MOVE WS-VALOR TO WCOB00-PRMTAR(WS-COB00). */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR);

            /*" -4145- MOVE WS-PERCENT TO WCOB00-PERCEN(WS-COB00). */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN);

            /*" -4146- SET WS-COB01 TO 1 */
            WS_COB01.Value = 1;

            /*" -4148- MOVE 82 TO WCOB01-RAMO(WS-COB01) */
            _.Move(82, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

            /*" -4150- MOVE 01 TO WCOB01-COBE(WS-COB01) */
            _.Move(01, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

            /*" -4152- MOVE SOR-IMPMORACID TO WCOB01-IMPSEG(WS-COB01) */
            _.Move(REG_SVA0141B.SOR_IMPMORACID, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

            /*" -4154- MOVE WS-VALOR TO WCOB01-PRMTAR(WS-COB01) */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -4158- MOVE WS-PERCENT TO WCOB01-PERCEN(WS-COB01) */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

            /*" -4160- COMPUTE WS-PERCENT EQUAL (100 - WS-PERCENT). */
            WS_PERCENT.Value = (100 - WS_PERCENT);

            /*" -4164- COMPUTE WS-VALOR EQUAL (PARCELAS-PRM-TARIFARIO-IX - WS-VALOR). */
            WS_VALOR.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX - WS_VALOR);

            /*" -4165- SET WS-COB00 TO 2. */
            WS_COB00.Value = 2;

            /*" -4167- MOVE 93 TO WCOB00-RAMO(WS-COB00). */
            _.Move(93, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO);

            /*" -4169- MOVE ZEROS TO WCOB00-COBE(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

            /*" -4171- MOVE SOR-IMPMORNATU TO WCOB00-IMPSEG(WS-COB00). */
            _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);

            /*" -4173- MOVE WS-VALOR TO WCOB00-PRMTAR(WS-COB00). */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR);

            /*" -4176- MOVE WS-PERCENT TO WCOB00-PERCEN(WS-COB00). */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN);

            /*" -4177- SET WS-COB01 TO 2. */
            WS_COB01.Value = 2;

            /*" -4179- MOVE 93 TO WCOB01-RAMO(WS-COB01). */
            _.Move(93, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

            /*" -4181- MOVE 11 TO WCOB01-COBE(WS-COB01). */
            _.Move(11, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

            /*" -4183- MOVE SOR-IMPMORNATU TO WCOB01-IMPSEG(WS-COB01). */
            _.Move(REG_SVA0141B.SOR_IMPMORNATU, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

            /*" -4185- MOVE WS-VALOR TO WCOB01-PRMTAR(WS-COB01). */
            _.Move(WS_VALOR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -4186- MOVE WS-PERCENT TO WCOB01-PERCEN(WS-COB01). */
            _.Move(WS_PERCENT, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1360_99_SAIDA*/

        [StopWatch]
        /*" R1380-00-TRATA-PRMDIT-SECTION */
        private void R1380_00_TRATA_PRMDIT_SECTION()
        {
            /*" -4197- MOVE '1380' TO WNR-EXEC-SQL. */
            _.Move("1380", W.WABEND.WNR_EXEC_SQL);

            /*" -4200- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4201- IF SOR-RAMO EQUAL 97 */

            if (REG_SVA0141B.SOR_RAMO == 97)
            {

                /*" -4203- IF SOR-PREMIO-VG NOT EQUAL ZEROS AND SOR-PREMIO-AP NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_PREMIO_VG != 00 && REG_SVA0141B.SOR_PREMIO_AP != 00)
                {

                    /*" -4204- PERFORM R1400-00-TRATA-PRMDIT97 */

                    R1400_00_TRATA_PRMDIT97_SECTION();

                    /*" -4205- ELSE */
                }
                else
                {


                    /*" -4206- IF SOR-PREMIO-VG NOT EQUAL ZEROS */

                    if (REG_SVA0141B.SOR_PREMIO_VG != 00)
                    {

                        /*" -4207- PERFORM R1420-00-TRATA-PRMDIT93 */

                        R1420_00_TRATA_PRMDIT93_SECTION();

                        /*" -4208- ELSE */
                    }
                    else
                    {


                        /*" -4209- IF SOR-PREMIO-AP NOT EQUAL ZEROS */

                        if (REG_SVA0141B.SOR_PREMIO_AP != 00)
                        {

                            /*" -4210- PERFORM R1440-00-TRATA-PRMDIT82 */

                            R1440_00_TRATA_PRMDIT82_SECTION();

                            /*" -4211- ELSE */
                        }
                        else
                        {


                            /*" -4213- MOVE 'R1380-00  FATURA NAO EMITIDA RAMO 97  ' TO LD01-OBSERVA */
                            _.Move("R1380-00  FATURA NAO EMITIDA RAMO 97  ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                            /*" -4214- ELSE */
                        }

                    }

                }

            }
            else
            {


                /*" -4215- IF SOR-RAMO EQUAL 93 */

                if (REG_SVA0141B.SOR_RAMO == 93)
                {

                    /*" -4216- IF SOR-PREMIO-VG NOT EQUAL ZEROS */

                    if (REG_SVA0141B.SOR_PREMIO_VG != 00)
                    {

                        /*" -4217- PERFORM R1420-00-TRATA-PRMDIT93 */

                        R1420_00_TRATA_PRMDIT93_SECTION();

                        /*" -4218- ELSE */
                    }
                    else
                    {


                        /*" -4220- MOVE 'R1380-00  FATURA NAO EMITIDA RAMO 93  ' TO LD01-OBSERVA */
                        _.Move("R1380-00  FATURA NAO EMITIDA RAMO 93  ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                        /*" -4221- ELSE */
                    }

                }
                else
                {


                    /*" -4222- IF SOR-RAMO EQUAL 82 */

                    if (REG_SVA0141B.SOR_RAMO == 82)
                    {

                        /*" -4223- IF SOR-PREMIO-AP NOT EQUAL ZEROS */

                        if (REG_SVA0141B.SOR_PREMIO_AP != 00)
                        {

                            /*" -4224- PERFORM R1440-00-TRATA-PRMDIT82 */

                            R1440_00_TRATA_PRMDIT82_SECTION();

                            /*" -4225- ELSE */
                        }
                        else
                        {


                            /*" -4227- MOVE 'R1380-00  FATURA NAO EMITIDA RAMO 82  ' TO LD01-OBSERVA */
                            _.Move("R1380-00  FATURA NAO EMITIDA RAMO 82  ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                            /*" -4228- ELSE */
                        }

                    }
                    else
                    {


                        /*" -4229- MOVE 'R1380-00  FATURA NAO EMITIDA OUTROS RAMOS' TO LD01-OBSERVA. */
                        _.Move("R1380-00  FATURA NAO EMITIDA OUTROS RAMOS", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1380_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-TRATA-PRMDIT97-SECTION */
        private void R1400_00_TRATA_PRMDIT97_SECTION()
        {
            /*" -4240- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", W.WABEND.WNR_EXEC_SQL);

            /*" -4243- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4245- IF SOR-IMPMORACID EQUAL ZEROS OR SOR-IMPMORNATU EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IMPMORACID == 00 || REG_SVA0141B.SOR_IMPMORNATU == 00)
            {

                /*" -4247- MOVE 'R1400-00  FATURA NAO EMITIDA IMPSEG   ' TO LD01-OBSERVA */
                _.Move("R1400-00  FATURA NAO EMITIDA IMPSEG   ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -4250- GO TO R1400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4252- IF SOR-PREMIO-VG GREATER SOR-PREMIO-AP AND SOR-PREMIO-VG GREATER SOR-PRMDIT */

            if (REG_SVA0141B.SOR_PREMIO_VG > REG_SVA0141B.SOR_PREMIO_AP && REG_SVA0141B.SOR_PREMIO_VG > REG_SVA0141B.SOR_PRMDIT)
            {

                /*" -4254- COMPUTE SOR-PREMIO-VG EQUAL (SOR-PREMIO-VG - SOR-PRMDIT) */
                REG_SVA0141B.SOR_PREMIO_VG.Value = (REG_SVA0141B.SOR_PREMIO_VG - REG_SVA0141B.SOR_PRMDIT);

                /*" -4255- ELSE */
            }
            else
            {


                /*" -4256- IF SOR-PREMIO-AP GREATER SOR-PRMDIT */

                if (REG_SVA0141B.SOR_PREMIO_AP > REG_SVA0141B.SOR_PRMDIT)
                {

                    /*" -4258- COMPUTE SOR-PREMIO-AP EQUAL (SOR-PREMIO-AP - SOR-PRMDIT) */
                    REG_SVA0141B.SOR_PREMIO_AP.Value = (REG_SVA0141B.SOR_PREMIO_AP - REG_SVA0141B.SOR_PRMDIT);

                    /*" -4259- ELSE */
                }
                else
                {


                    /*" -4260- IF SOR-PRMDIT NOT EQUAL ZEROS */

                    if (REG_SVA0141B.SOR_PRMDIT != 00)
                    {

                        /*" -4264- MOVE ZEROS TO SOR-PRMDIT SOR-IMPDIT. */
                        _.Move(0, REG_SVA0141B.SOR_PRMDIT, REG_SVA0141B.SOR_IMPDIT);
                    }

                }

            }


            /*" -4265- IF SOR-PREMIO-VG GREATER ZEROS */

            if (REG_SVA0141B.SOR_PREMIO_VG > 00)
            {

                /*" -4267- MOVE 93 TO VG082-RAMO-EMISSOR */
                _.Move(93, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);

                /*" -4269- MOVE SOR-PREMIO-VG TO VG082-VLR-PREMIO-RAMO */
                _.Move(REG_SVA0141B.SOR_PREMIO_VG, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);

                /*" -4272- PERFORM R1193-00-DIFERE-RAMO93. */

                R1193_00_DIFERE_RAMO93_SECTION();
            }


            /*" -4273- IF SOR-PREMIO-AP GREATER ZEROS */

            if (REG_SVA0141B.SOR_PREMIO_AP > 00)
            {

                /*" -4275- MOVE 82 TO VG082-RAMO-EMISSOR */
                _.Move(82, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);

                /*" -4277- MOVE SOR-PREMIO-AP TO VG082-VLR-PREMIO-RAMO */
                _.Move(REG_SVA0141B.SOR_PREMIO_AP, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);

                /*" -4280- PERFORM R1182-00-DIFERE-RAMO82. */

                R1182_00_DIFERE_RAMO82_SECTION();
            }


            /*" -4281- IF SOR-PRMDIT GREATER ZEROS */

            if (REG_SVA0141B.SOR_PRMDIT > 00)
            {

                /*" -4283- MOVE 90 TO VG082-RAMO-EMISSOR */
                _.Move(90, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);

                /*" -4285- MOVE SOR-PRMDIT TO VG082-VLR-PREMIO-RAMO */
                _.Move(REG_SVA0141B.SOR_PRMDIT, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);

                /*" -4288- PERFORM R0940-00-DIFERE-DIT. */

                R0940_00_DIFERE_DIT_SECTION();
            }


            /*" -4288- PERFORM R1200-00-AJUSTA-COBERTURA. */

            R1200_00_AJUSTA_COBERTURA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1420-00-TRATA-PRMDIT93-SECTION */
        private void R1420_00_TRATA_PRMDIT93_SECTION()
        {
            /*" -4299- MOVE '1420' TO WNR-EXEC-SQL. */
            _.Move("1420", W.WABEND.WNR_EXEC_SQL);

            /*" -4302- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4303- IF SOR-IMPMORNATU EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IMPMORNATU == 00)
            {

                /*" -4305- MOVE 'R1420-00  FATURA NAO EMITIDA IMPSEG   ' TO LD01-OBSERVA */
                _.Move("R1420-00  FATURA NAO EMITIDA IMPSEG   ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -4308- GO TO R1420-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1420_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4309- IF SOR-PREMIO-VG GREATER SOR-PRMDIT */

            if (REG_SVA0141B.SOR_PREMIO_VG > REG_SVA0141B.SOR_PRMDIT)
            {

                /*" -4311- COMPUTE SOR-PREMIO-VG EQUAL (SOR-PREMIO-VG - SOR-PRMDIT) */
                REG_SVA0141B.SOR_PREMIO_VG.Value = (REG_SVA0141B.SOR_PREMIO_VG - REG_SVA0141B.SOR_PRMDIT);

                /*" -4312- ELSE */
            }
            else
            {


                /*" -4313- IF SOR-PRMDIT NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_PRMDIT != 00)
                {

                    /*" -4317- MOVE ZEROS TO SOR-PRMDIT SOR-IMPDIT. */
                    _.Move(0, REG_SVA0141B.SOR_PRMDIT, REG_SVA0141B.SOR_IMPDIT);
                }

            }


            /*" -4318- IF SOR-PREMIO-VG GREATER ZEROS */

            if (REG_SVA0141B.SOR_PREMIO_VG > 00)
            {

                /*" -4320- MOVE 93 TO VG082-RAMO-EMISSOR */
                _.Move(93, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);

                /*" -4322- MOVE SOR-PREMIO-VG TO VG082-VLR-PREMIO-RAMO */
                _.Move(REG_SVA0141B.SOR_PREMIO_VG, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);

                /*" -4325- PERFORM R1193-00-DIFERE-RAMO93. */

                R1193_00_DIFERE_RAMO93_SECTION();
            }


            /*" -4326- IF SOR-PRMDIT GREATER ZEROS */

            if (REG_SVA0141B.SOR_PRMDIT > 00)
            {

                /*" -4328- MOVE 90 TO VG082-RAMO-EMISSOR */
                _.Move(90, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);

                /*" -4330- MOVE SOR-PRMDIT TO VG082-VLR-PREMIO-RAMO */
                _.Move(REG_SVA0141B.SOR_PRMDIT, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);

                /*" -4333- PERFORM R0940-00-DIFERE-DIT. */

                R0940_00_DIFERE_DIT_SECTION();
            }


            /*" -4333- PERFORM R1200-00-AJUSTA-COBERTURA. */

            R1200_00_AJUSTA_COBERTURA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1420_99_SAIDA*/

        [StopWatch]
        /*" R1440-00-TRATA-PRMDIT82-SECTION */
        private void R1440_00_TRATA_PRMDIT82_SECTION()
        {
            /*" -4344- MOVE '1440' TO WNR-EXEC-SQL. */
            _.Move("1440", W.WABEND.WNR_EXEC_SQL);

            /*" -4347- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4348- IF SOR-IMPMORACID EQUAL ZEROS */

            if (REG_SVA0141B.SOR_IMPMORACID == 00)
            {

                /*" -4350- MOVE 'R1440-00  FATURA NAO EMITIDA IMPSEG   ' TO LD01-OBSERVA */
                _.Move("R1440-00  FATURA NAO EMITIDA IMPSEG   ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -4353- GO TO R1440-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1440_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4354- IF SOR-PREMIO-AP GREATER SOR-PRMDIT */

            if (REG_SVA0141B.SOR_PREMIO_AP > REG_SVA0141B.SOR_PRMDIT)
            {

                /*" -4356- COMPUTE SOR-PREMIO-AP EQUAL (SOR-PREMIO-AP - SOR-PRMDIT) */
                REG_SVA0141B.SOR_PREMIO_AP.Value = (REG_SVA0141B.SOR_PREMIO_AP - REG_SVA0141B.SOR_PRMDIT);

                /*" -4357- ELSE */
            }
            else
            {


                /*" -4358- IF SOR-PRMDIT NOT EQUAL ZEROS */

                if (REG_SVA0141B.SOR_PRMDIT != 00)
                {

                    /*" -4362- MOVE ZEROS TO SOR-PRMDIT SOR-IMPDIT. */
                    _.Move(0, REG_SVA0141B.SOR_PRMDIT, REG_SVA0141B.SOR_IMPDIT);
                }

            }


            /*" -4363- IF SOR-PREMIO-AP GREATER ZEROS */

            if (REG_SVA0141B.SOR_PREMIO_AP > 00)
            {

                /*" -4365- MOVE 82 TO VG082-RAMO-EMISSOR */
                _.Move(82, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);

                /*" -4367- MOVE SOR-PREMIO-AP TO VG082-VLR-PREMIO-RAMO */
                _.Move(REG_SVA0141B.SOR_PREMIO_AP, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);

                /*" -4370- PERFORM R1182-00-DIFERE-RAMO82. */

                R1182_00_DIFERE_RAMO82_SECTION();
            }


            /*" -4371- IF SOR-PRMDIT GREATER ZEROS */

            if (REG_SVA0141B.SOR_PRMDIT > 00)
            {

                /*" -4373- MOVE 90 TO VG082-RAMO-EMISSOR */
                _.Move(90, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);

                /*" -4375- MOVE SOR-PRMDIT TO VG082-VLR-PREMIO-RAMO */
                _.Move(REG_SVA0141B.SOR_PRMDIT, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);

                /*" -4378- PERFORM R0940-00-DIFERE-DIT. */

                R0940_00_DIFERE_DIT_SECTION();
            }


            /*" -4378- PERFORM R1200-00-AJUSTA-COBERTURA. */

            R1200_00_AJUSTA_COBERTURA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1440_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-VER-COBERTURAS-SECTION */
        private void R1500_00_VER_COBERTURAS_SECTION()
        {
            /*" -4389- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", W.WABEND.WNR_EXEC_SQL);

            /*" -4391- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4394- MOVE ZEROS TO WS-PREMIO-LIQ WS-PERCENT. */
            _.Move(0, WS_PREMIO_LIQ, WS_PERCENT);

            /*" -4396- SET WS-COB00 TO 1. */
            WS_COB00.Value = 1;

            /*" -4398- PERFORM R1510-00-VER-COB00 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R1510_00_VER_COB00_SECTION();

            }

            /*" -4400- IF WS-PERCENT NOT EQUAL 100 OR PARCELAS-PRM-TARIFARIO-IX NOT EQUAL WS-PREMIO-LIQ */

            if (WS_PERCENT != 100 || PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX != WS_PREMIO_LIQ)
            {

                /*" -4402- MOVE 'COBERTURA 00 DIFERENTE   ' TO WS01-OBSERVA */
                _.Move("COBERTURA 00 DIFERENTE   ", ARQUIVOS_SAIDA.WS01.WS01_OBSERVA);

                /*" -4403- MOVE WS-PERCENT TO WS01-PERCENT */
                _.Move(WS_PERCENT, ARQUIVOS_SAIDA.WS01.WS01_PERCENT);

                /*" -4404- MOVE WS-PREMIO-LIQ TO WS01-VALOR */
                _.Move(WS_PREMIO_LIQ, ARQUIVOS_SAIDA.WS01.WS01_VALOR);

                /*" -4406- MOVE PARCELAS-PRM-TARIFARIO-IX TO WS01-LIQUIDO */
                _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, ARQUIVOS_SAIDA.WS01.WS01_LIQUIDO);

                /*" -4409- MOVE WS01 TO LD01-OBSERVA. */
                _.Move(ARQUIVOS_SAIDA.WS01, ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);
            }


            /*" -4412- MOVE ZEROS TO WS-PREMIO-LIQ WS-PERCENT. */
            _.Move(0, WS_PREMIO_LIQ, WS_PERCENT);

            /*" -4414- SET WS-COB01 TO 1. */
            WS_COB01.Value = 1;

            /*" -4416- PERFORM R1520-00-VER-COB01 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R1520_00_VER_COB01_SECTION();

            }

            /*" -4418- IF WS-PERCENT NOT EQUAL 100 OR PARCELAS-PRM-TARIFARIO-IX NOT EQUAL WS-PREMIO-LIQ */

            if (WS_PERCENT != 100 || PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX != WS_PREMIO_LIQ)
            {

                /*" -4420- MOVE 'COBERTURA 01 DIFERENTE   ' TO WS01-OBSERVA */
                _.Move("COBERTURA 01 DIFERENTE   ", ARQUIVOS_SAIDA.WS01.WS01_OBSERVA);

                /*" -4421- MOVE WS-PERCENT TO WS01-PERCENT */
                _.Move(WS_PERCENT, ARQUIVOS_SAIDA.WS01.WS01_PERCENT);

                /*" -4422- MOVE WS-PREMIO-LIQ TO WS01-VALOR */
                _.Move(WS_PREMIO_LIQ, ARQUIVOS_SAIDA.WS01.WS01_VALOR);

                /*" -4424- MOVE PARCELAS-PRM-TARIFARIO-IX TO WS01-LIQUIDO */
                _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, ARQUIVOS_SAIDA.WS01.WS01_LIQUIDO);

                /*" -4424- MOVE WS01 TO LD01-OBSERVA. */
                _.Move(ARQUIVOS_SAIDA.WS01, ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-VER-COB00-SECTION */
        private void R1510_00_VER_COB00_SECTION()
        {
            /*" -4435- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", W.WABEND.WNR_EXEC_SQL);

            /*" -4438- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4439- IF WCOB00-RAMO(WS-COB00) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO == 00)
            {

                /*" -4440- SET WS-COB00 UP BY 1 */
                WS_COB00.Value += 1;

                /*" -4443- GO TO R1510-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4444- IF WCOB00-PRMTAR(WS-COB00) NOT GREATER ZEROS */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR <= 00)
            {

                /*" -4447- MOVE 'WCOB00-PRMTAR NAO MAIOR         ' TO LD01-OBSERVA. */
                _.Move("WCOB00-PRMTAR NAO MAIOR         ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);
            }


            /*" -4448- IF WCOB00-PERCEN(WS-COB00) NOT GREATER ZEROS */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN <= 00)
            {

                /*" -4451- MOVE 'WCOB00-PERCEN NAO MAIOR         ' TO LD01-OBSERVA. */
                _.Move("WCOB00-PERCEN NAO MAIOR         ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);
            }


            /*" -4453- ADD WCOB00-PRMTAR(WS-COB00) TO WS-PREMIO-LIQ. */
            WS_PREMIO_LIQ.Value = WS_PREMIO_LIQ + TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR;

            /*" -4457- ADD WCOB00-PERCEN(WS-COB00) TO WS-PERCENT. */
            WS_PERCENT.Value = WS_PERCENT + TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN;

            /*" -4457- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1520-00-VER-COB01-SECTION */
        private void R1520_00_VER_COB01_SECTION()
        {
            /*" -4468- MOVE '1520' TO WNR-EXEC-SQL. */
            _.Move("1520", W.WABEND.WNR_EXEC_SQL);

            /*" -4471- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4472- IF WCOB01-RAMO(WS-COB01) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO == 00)
            {

                /*" -4473- SET WS-COB01 UP BY 1 */
                WS_COB01.Value += 1;

                /*" -4476- GO TO R1520-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1520_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4477- IF WCOB01-PRMTAR(WS-COB01) NOT GREATER ZEROS */

            if (TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR <= 00)
            {

                /*" -4480- MOVE 'WCOB01-PRMTAR NAO MAIOR         ' TO LD01-OBSERVA. */
                _.Move("WCOB01-PRMTAR NAO MAIOR         ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);
            }


            /*" -4481- IF WCOB01-PERCEN(WS-COB01) NOT GREATER ZEROS */

            if (TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN <= 00)
            {

                /*" -4484- MOVE 'WCOB01-PERCEN NAO MAIOR         ' TO LD01-OBSERVA. */
                _.Move("WCOB01-PERCEN NAO MAIOR         ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);
            }


            /*" -4486- ADD WCOB01-PRMTAR(WS-COB01) TO WS-PREMIO-LIQ. */
            WS_PREMIO_LIQ.Value = WS_PREMIO_LIQ + TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR;

            /*" -4490- ADD WCOB01-PERCEN(WS-COB01) TO WS-PERCENT. */
            WS_PERCENT.Value = WS_PERCENT + TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN;

            /*" -4490- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1520_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-ATUALIZA-TABELAS-SECTION */
        private void R2000_00_ATUALIZA_TABELAS_SECTION()
        {
            /*" -4501- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", W.WABEND.WNR_EXEC_SQL);

            /*" -4507- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4513- PERFORM R2350-00-UPDATE-NUMERAES. */

            R2350_00_UPDATE_NUMERAES_SECTION();

            /*" -4517- PERFORM R2450-00-UPDATE-FONTES. */

            R2450_00_UPDATE_FONTES_SECTION();

            /*" -4520- IF SOR-ORIG-PRODU EQUAL 'ESPEC' AND SOR-PERI-PAGAMENTO EQUAL 1 AND SOR-NUM-PARCELA GREATER 1 */

            if (REG_SVA0141B.SOR_ORIG_PRODU == "ESPEC" && REG_SVA0141B.SOR_PERI_PAGAMENTO == 1 && REG_SVA0141B.SOR_NUM_PARCELA > 1)
            {

                /*" -4525- DISPLAY 'A ' ENDOSSOS-NUM-APOLICE ' ' ENDOSSOS-NUM-ENDOSSO ' ' ENDOSSOS-DATA-INIVIGENCIA ' ' ENDOSSOS-DATA-TERVIGENCIA */

                $"A {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA}"
                .Display();

                /*" -4526- PERFORM R2500-00-TRATA-VIGENCIA */

                R2500_00_TRATA_VIGENCIA_SECTION();

                /*" -4531- DISPLAY 'D ' ENDOSSOS-NUM-APOLICE ' ' ENDOSSOS-NUM-ENDOSSO ' ' ENDOSSOS-DATA-INIVIGENCIA ' ' ENDOSSOS-DATA-TERVIGENCIA */

                $"D {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA} {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA}"
                .Display();

                /*" -4532- END-IF */
            }


            /*" -4537- . */

            /*" -4543- PERFORM R2520-00-INSERT-ENDOSSOS. */

            R2520_00_INSERT_ENDOSSOS_SECTION();

            /*" -4549- PERFORM R2530-00-INSERT-PARCELAS. */

            R2530_00_INSERT_PARCELAS_SECTION();

            /*" -4555- PERFORM R2550-00-INSERT-PARCEHIS. */

            R2550_00_INSERT_PARCEHIS_SECTION();

            /*" -4556- IF SOR-TIPO-ENDOSSO EQUAL '3' */

            if (REG_SVA0141B.SOR_TIPO_ENDOSSO == "3")
            {

                /*" -4557- ADD 1 TO TT-BAIXA */
                W.TT_BAIXA.Value = W.TT_BAIXA + 1;

                /*" -4559- MOVE 290 TO PARCEHIS-COD-OPERACAO */
                _.Move(290, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

                /*" -4561- MOVE 2 TO PARCEHIS-OCORR-HISTORICO */
                _.Move(2, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

                /*" -4563- MOVE SOR-VALVGAP TO PARCEHIS-VAL-OPERACAO */
                _.Move(REG_SVA0141B.SOR_VALVGAP, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

                /*" -4565- MOVE 104 TO PARCEHIS-BCO-COBRANCA */
                _.Move(104, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

                /*" -4567- MOVE ZEROS TO PARCEHIS-AGE-COBRANCA */
                _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

                /*" -4569- MOVE ZEROS TO PARCEHIS-NUM-AVISO-CREDITO */
                _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

                /*" -4571- MOVE SOR-DATA-MOVIMENTO TO PARCEHIS-DATA-QUITACAO */
                _.Move(REG_SVA0141B.SOR_DATA_MOVIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

                /*" -4572- MOVE ZEROS TO VIND-DTQITBCO */
                _.Move(0, VIND_DTQITBCO);

                /*" -4573- PERFORM R2550-00-INSERT-PARCEHIS */

                R2550_00_INSERT_PARCEHIS_SECTION();

                /*" -4574- ELSE */
            }
            else
            {


                /*" -4575- IF PARCELAS-SIT-REGISTRO EQUAL '1' */

                if (PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO == "1")
                {

                    /*" -4576- IF SOR-RCAPS EQUAL 'SIM' */

                    if (REG_SVA0141B.SOR_RCAPS == "SIM")
                    {

                        /*" -4577- ADD 1 TO TT-BAIXA */
                        W.TT_BAIXA.Value = W.TT_BAIXA + 1;

                        /*" -4579- MOVE 201 TO PARCEHIS-COD-OPERACAO */
                        _.Move(201, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

                        /*" -4581- MOVE 2 TO PARCEHIS-OCORR-HISTORICO */
                        _.Move(2, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

                        /*" -4583- MOVE SOR-VALVGAP TO PARCEHIS-VAL-OPERACAO */
                        _.Move(REG_SVA0141B.SOR_VALVGAP, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

                        /*" -4585- MOVE SOR-BCOAVISO TO PARCEHIS-BCO-COBRANCA */
                        _.Move(REG_SVA0141B.SOR_BCOAVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

                        /*" -4587- MOVE SOR-AGEAVISO TO PARCEHIS-AGE-COBRANCA */
                        _.Move(REG_SVA0141B.SOR_AGEAVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

                        /*" -4589- MOVE SOR-NRAVISO TO PARCEHIS-NUM-AVISO-CREDITO */
                        _.Move(REG_SVA0141B.SOR_NRAVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

                        /*" -4591- MOVE SOR-DATA-MOVIMENTO TO PARCEHIS-DATA-QUITACAO */
                        _.Move(REG_SVA0141B.SOR_DATA_MOVIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

                        /*" -4592- MOVE ZEROS TO VIND-DTQITBCO */
                        _.Move(0, VIND_DTQITBCO);

                        /*" -4593- PERFORM R2550-00-INSERT-PARCEHIS */

                        R2550_00_INSERT_PARCEHIS_SECTION();

                        /*" -4594- ELSE */
                    }
                    else
                    {


                        /*" -4595- ADD 1 TO TT-BAIXA */
                        W.TT_BAIXA.Value = W.TT_BAIXA + 1;

                        /*" -4597- MOVE 221 TO PARCEHIS-COD-OPERACAO */
                        _.Move(221, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

                        /*" -4599- MOVE 2 TO PARCEHIS-OCORR-HISTORICO */
                        _.Move(2, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

                        /*" -4601- MOVE SOR-VALVGAP TO PARCEHIS-VAL-OPERACAO */
                        _.Move(REG_SVA0141B.SOR_VALVGAP, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

                        /*" -4603- MOVE SOR-BCOAVISO TO PARCEHIS-BCO-COBRANCA */
                        _.Move(REG_SVA0141B.SOR_BCOAVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

                        /*" -4605- MOVE SOR-AGEAVISO TO PARCEHIS-AGE-COBRANCA */
                        _.Move(REG_SVA0141B.SOR_AGEAVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

                        /*" -4607- MOVE SOR-NRAVISO TO PARCEHIS-NUM-AVISO-CREDITO */
                        _.Move(REG_SVA0141B.SOR_NRAVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

                        /*" -4609- MOVE SOR-DATA-MOVIMENTO TO PARCEHIS-DATA-QUITACAO */
                        _.Move(REG_SVA0141B.SOR_DATA_MOVIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

                        /*" -4610- MOVE ZEROS TO VIND-DTQITBCO */
                        _.Move(0, VIND_DTQITBCO);

                        /*" -4616- PERFORM R2550-00-INSERT-PARCEHIS. */

                        R2550_00_INSERT_PARCEHIS_SECTION();
                    }

                }

            }


            /*" -4622- PERFORM R2700-00-TRATA-COSSEGURO. */

            R2700_00_TRATA_COSSEGURO_SECTION();

            /*" -4628- PERFORM R3000-00-INSERT-COBERTURAS. */

            R3000_00_INSERT_COBERTURAS_SECTION();

            /*" -4634- PERFORM R4000-00-UPDATE-HISCONPA. */

            R4000_00_UPDATE_HISCONPA_SECTION();

            /*" -4636- IF SOR-TIPO-ENDOSSO EQUAL '1' AND SOR-RCAPS EQUAL 'SIM' */

            if (REG_SVA0141B.SOR_TIPO_ENDOSSO == "1" && REG_SVA0141B.SOR_RCAPS == "SIM")
            {

                /*" -4636- PERFORM R4100-00-UPDATE-V0RCAPS. */

                R4100_00_UPDATE_V0RCAPS_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2350-00-UPDATE-NUMERAES-SECTION */
        private void R2350_00_UPDATE_NUMERAES_SECTION()
        {
            /*" -4647- MOVE '2350' TO WNR-EXEC-SQL. */
            _.Move("2350", W.WABEND.WNR_EXEC_SQL);

            /*" -4650- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4656- PERFORM R2350_00_UPDATE_NUMERAES_DB_UPDATE_1 */

            R2350_00_UPDATE_NUMERAES_DB_UPDATE_1();

            /*" -4659- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4660- DISPLAY 'R2350-00 - PROBLEMAS UPDATE (NUMERAES)  ' */
                _.Display($"R2350-00 - PROBLEMAS UPDATE (NUMERAES)  ");

                /*" -4661- DISPLAY ' ORGAO        =  ' NUMERAES-ORGAO-EMISSOR */
                _.Display($" ORGAO        =  {NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR}");

                /*" -4662- DISPLAY ' RAMO         =  ' NUMERAES-RAMO-EMISSOR */
                _.Display($" RAMO         =  {NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR}");

                /*" -4663- DISPLAY ' COBRANCA     =  ' NUMERAES-ENDOS-COBRANCA */
                _.Display($" COBRANCA     =  {NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_COBRANCA}");

                /*" -4664- DISPLAY ' RESTITUICAO  =  ' NUMERAES-ENDOS-RESTITUICAO */
                _.Display($" RESTITUICAO  =  {NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_RESTITUICAO}");

                /*" -4665- DISPLAY ' TIPO         =  ' SOR-TIPO-ENDOSSO */
                _.Display($" TIPO         =  {REG_SVA0141B.SOR_TIPO_ENDOSSO}");

                /*" -4665- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2350-00-UPDATE-NUMERAES-DB-UPDATE-1 */
        public void R2350_00_UPDATE_NUMERAES_DB_UPDATE_1()
        {
            /*" -4656- EXEC SQL UPDATE SEGUROS.NUMERO_AES SET ENDOS_COBRANCA = :NUMERAES-ENDOS-COBRANCA ,ENDOS_RESTITUICAO = :NUMERAES-ENDOS-RESTITUICAO WHERE ORGAO_EMISSOR = :NUMERAES-ORGAO-EMISSOR AND RAMO_EMISSOR = :NUMERAES-RAMO-EMISSOR END-EXEC. */

            var r2350_00_UPDATE_NUMERAES_DB_UPDATE_1_Update1 = new R2350_00_UPDATE_NUMERAES_DB_UPDATE_1_Update1()
            {
                NUMERAES_ENDOS_RESTITUICAO = NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_RESTITUICAO.ToString(),
                NUMERAES_ENDOS_COBRANCA = NUMERAES.DCLNUMERO_AES.NUMERAES_ENDOS_COBRANCA.ToString(),
                NUMERAES_ORGAO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR.ToString(),
                NUMERAES_RAMO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR.ToString(),
            };

            R2350_00_UPDATE_NUMERAES_DB_UPDATE_1_Update1.Execute(r2350_00_UPDATE_NUMERAES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/

        [StopWatch]
        /*" R2450-00-UPDATE-FONTES-SECTION */
        private void R2450_00_UPDATE_FONTES_SECTION()
        {
            /*" -4676- MOVE '2450' TO WNR-EXEC-SQL. */
            _.Move("2450", W.WABEND.WNR_EXEC_SQL);

            /*" -4679- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4685- PERFORM R2450_00_UPDATE_FONTES_DB_UPDATE_1 */

            R2450_00_UPDATE_FONTES_DB_UPDATE_1();

            /*" -4688- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4689- DISPLAY 'R2450-00 - PROBLEMAS UPDATE (FONTES)      ' */
                _.Display($"R2450-00 - PROBLEMAS UPDATE (FONTES)      ");

                /*" -4690- DISPLAY 'COD-FONTE        = ' FONTES-COD-FONTE */
                _.Display($"COD-FONTE        = {FONTES.DCLFONTES.FONTES_COD_FONTE}");

                /*" -4691- DISPLAY 'NUM_PROPOSTA     = ' FONTES-ULT-PROP-AUTOMAT */
                _.Display($"NUM_PROPOSTA     = {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}");

                /*" -4691- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2450-00-UPDATE-FONTES-DB-UPDATE-1 */
        public void R2450_00_UPDATE_FONTES_DB_UPDATE_1()
        {
            /*" -4685- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :FONTES-ULT-PROP-AUTOMAT WHERE COD_FONTE = :FONTES-COD-FONTE END-EXEC. */

            var r2450_00_UPDATE_FONTES_DB_UPDATE_1_Update1 = new R2450_00_UPDATE_FONTES_DB_UPDATE_1_Update1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
            };

            R2450_00_UPDATE_FONTES_DB_UPDATE_1_Update1.Execute(r2450_00_UPDATE_FONTES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-TRATA-VIGENCIA-SECTION */
        private void R2500_00_TRATA_VIGENCIA_SECTION()
        {
            /*" -4701- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", W.WABEND.WNR_EXEC_SQL);

            /*" -4703- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4704- PERFORM R2510-00-SELECT-PARCEVID */

            R2510_00_SELECT_PARCEVID_SECTION();

            /*" -4705- IF SOR-NUM-PARCELA EQUAL 1 */

            if (REG_SVA0141B.SOR_NUM_PARCELA == 1)
            {

                /*" -4706- DISPLAY 'D0001 ' */
                _.Display($"D0001 ");

                /*" -4708- MOVE PARCEVID-DATA-VENCIMENTO TO WHOST-DATA-VENCIMENTO */
                _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO, WHOST_DATA_VENCIMENTO);

                /*" -4709- PERFORM R2515-00-TRATA-VIGENCIA */

                R2515_00_TRATA_VIGENCIA_SECTION();

                /*" -4710- ELSE */
            }
            else
            {


                /*" -4712- MOVE PARCEVID-DATA-VENCIMENTO-1M TO WHOST-DATA-VENCIMENTO */
                _.Move(PARCEVID_DATA_VENCIMENTO_1M, WHOST_DATA_VENCIMENTO);

                /*" -4713- PERFORM R2515-00-TRATA-VIGENCIA */

                R2515_00_TRATA_VIGENCIA_SECTION();

                /*" -4715- MOVE ENDOSSOS-DATA-TERVIGENCIA TO PARCEVID-DATA-VENCIMENTO-1M */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, PARCEVID_DATA_VENCIMENTO_1M);

                /*" -4720- DISPLAY 'D0002 ' PARCEVID-NUM-CERTIFICADO ' ' PARCEVID-NUM-PARCELA ' ' WHOST-DATA-VENCIMENTO ' ' PARCEVID-DATA-VENCIMENTO ' ' PARCEVID-DATA-VENCIMENTO-1M */

                $"D0002 {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO} {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA} {WHOST_DATA_VENCIMENTO} {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO} {PARCEVID_DATA_VENCIMENTO_1M}"
                .Display();

                /*" -4721- PERFORM R2513-00-SELECT-ENDOSSOS */

                R2513_00_SELECT_ENDOSSOS_SECTION();

                /*" -4722- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -4723- DISPLAY 'D0003 ' */
                    _.Display($"D0003 ");

                    /*" -4725- MOVE PARCEVID-DATA-VENCIMENTO TO WHOST-DATA-VENCIMENTO */
                    _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO, WHOST_DATA_VENCIMENTO);

                    /*" -4726- PERFORM R2515-00-TRATA-VIGENCIA */

                    R2515_00_TRATA_VIGENCIA_SECTION();

                    /*" -4727- ELSE */
                }
                else
                {


                    /*" -4728- PERFORM R2514-00-SELECT-ENDOSSOS */

                    R2514_00_SELECT_ENDOSSOS_SECTION();

                    /*" -4729- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -4730- DISPLAY 'D0004 ' */
                        _.Display($"D0004 ");

                        /*" -4731- PERFORM R2516-00-TRATA-VIGENCIA */

                        R2516_00_TRATA_VIGENCIA_SECTION();

                        /*" -4732- ELSE */
                    }
                    else
                    {


                        /*" -4733- DISPLAY 'D0005 ' */
                        _.Display($"D0005 ");

                        /*" -4735- MOVE PARCEVID-DATA-VENCIMENTO TO WHOST-DATA-VENCIMENTO */
                        _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO, WHOST_DATA_VENCIMENTO);

                        /*" -4736- PERFORM R2515-00-TRATA-VIGENCIA */

                        R2515_00_TRATA_VIGENCIA_SECTION();

                        /*" -4737- END-IF */
                    }


                    /*" -4738- END-IF */
                }


                /*" -4739- END-IF */
            }


            /*" -4739- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2510-00-SELECT-PARCEVID-SECTION */
        private void R2510_00_SELECT_PARCEVID_SECTION()
        {
            /*" -4748- MOVE '2510' TO WNR-EXEC-SQL. */
            _.Move("2510", W.WABEND.WNR_EXEC_SQL);

            /*" -4750- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4761- PERFORM R2510_00_SELECT_PARCEVID_DB_SELECT_1 */

            R2510_00_SELECT_PARCEVID_DB_SELECT_1();

            /*" -4764- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4765- DISPLAY 'R2510-00 - PROBLEMAS SELECT (PARCEVID)    ' */
                _.Display($"R2510-00 - PROBLEMAS SELECT (PARCEVID)    ");

                /*" -4766- DISPLAY 'NUM-APOLICE      = ' PARCEVID-NUM-CERTIFICADO */
                _.Display($"NUM-APOLICE      = {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO}");

                /*" -4767- DISPLAY 'COD_SUBGRUPO     = ' PARCEVID-NUM-PARCELA */
                _.Display($"COD_SUBGRUPO     = {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA}");

                /*" -4767- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2510-00-SELECT-PARCEVID-DB-SELECT-1 */
        public void R2510_00_SELECT_PARCEVID_DB_SELECT_1()
        {
            /*" -4761- EXEC SQL SELECT DATA_VENCIMENTO ,DATA_VENCIMENTO - 1 MONTH INTO :PARCEVID-DATA-VENCIMENTO ,:PARCEVID-DATA-VENCIMENTO-1M FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PARCEVID-NUM-CERTIFICADO AND NUM_PARCELA = :PARCEVID-NUM-PARCELA WITH UR END-EXEC. */

            var r2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1 = new R2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1()
            {
                PARCEVID_NUM_CERTIFICADO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO.ToString(),
                PARCEVID_NUM_PARCELA = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA.ToString(),
            };

            var executed_1 = R2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1.Execute(r2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEVID_DATA_VENCIMENTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO);
                _.Move(executed_1.PARCEVID_DATA_VENCIMENTO_1M, PARCEVID_DATA_VENCIMENTO_1M);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2510_99_SAIDA*/

        [StopWatch]
        /*" R2513-00-SELECT-ENDOSSOS-SECTION */
        private void R2513_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -4777- MOVE '2513' TO WNR-EXEC-SQL. */
            _.Move("2513", W.WABEND.WNR_EXEC_SQL);

            /*" -4780- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4795- PERFORM R2513_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R2513_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -4798- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4799- DISPLAY 'R2513-00 - PROBLEMAS SELECT (ENDOSSOS)    ' */
                _.Display($"R2513-00 - PROBLEMAS SELECT (ENDOSSOS)    ");

                /*" -4800- DISPLAY 'CERTIFICADO      = ' PARCEVID-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO      = {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO}");

                /*" -4801- DISPLAY 'PARCELA          = ' PARCEVID-NUM-PARCELA */
                _.Display($"PARCELA          = {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA}");

                /*" -4801- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2513-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R2513_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -4795- EXEC SQL SELECT NUM_ENDOSSO INTO :WHOST-NUM-ENDOSSO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND COD_SUBGRUPO = :ENDOSSOS-COD-SUBGRUPO AND DATA_INIVIGENCIA <= :PARCEVID-DATA-VENCIMENTO-1M AND DATA_TERVIGENCIA >= :PARCEVID-DATA-VENCIMENTO-1M AND NUM_ENDOSSO <> 0 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                PARCEVID_DATA_VENCIMENTO_1M = PARCEVID_DATA_VENCIMENTO_1M.ToString(),
                ENDOSSOS_COD_SUBGRUPO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO.ToString(),
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r2513_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NUM_ENDOSSO, WHOST_NUM_ENDOSSO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2513_99_SAIDA*/

        [StopWatch]
        /*" R2514-00-SELECT-ENDOSSOS-SECTION */
        private void R2514_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -4811- MOVE '2514' TO WNR-EXEC-SQL. */
            _.Move("2514", W.WABEND.WNR_EXEC_SQL);

            /*" -4814- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4828- PERFORM R2514_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R2514_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -4831- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4832- DISPLAY 'R2514-00 - PROBLEMAS SELECT (ENDOSSOS)    ' */
                _.Display($"R2514-00 - PROBLEMAS SELECT (ENDOSSOS)    ");

                /*" -4833- DISPLAY 'CERTIFICADO      = ' PARCEVID-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO      = {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO}");

                /*" -4834- DISPLAY 'PARCELA          = ' PARCEVID-NUM-PARCELA */
                _.Display($"PARCELA          = {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA}");

                /*" -4834- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2514-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R2514_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -4828- EXEC SQL SELECT DATA_TERVIGENCIA + 1 DAY INTO :ENDOSSOS-DATA-INIVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND COD_SUBGRUPO = :ENDOSSOS-COD-SUBGRUPO AND TIPO_ENDOSSO = '1' AND DATA_TERVIGENCIA < :PARCEVID-DATA-VENCIMENTO-1M ORDER BY DATA_TERVIGENCIA DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r2514_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R2514_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                PARCEVID_DATA_VENCIMENTO_1M = PARCEVID_DATA_VENCIMENTO_1M.ToString(),
                ENDOSSOS_COD_SUBGRUPO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO.ToString(),
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2514_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r2514_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2514_99_SAIDA*/

        [StopWatch]
        /*" R2515-00-TRATA-VIGENCIA-SECTION */
        private void R2515_00_TRATA_VIGENCIA_SECTION()
        {
            /*" -4844- MOVE '2515' TO WNR-EXEC-SQL. */
            _.Move("2515", W.WABEND.WNR_EXEC_SQL);

            /*" -4846- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4850- MOVE WHOST-DATA-VENCIMENTO TO ENDOSSOS-DATA-INIVIGENCIA ENDOSSOS-DATA-TERVIGENCIA */
            _.Move(WHOST_DATA_VENCIMENTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

            /*" -4853- MOVE 01 TO ENDOSSOS-DATA-INIVIGENCIA(9:2) */
            _.MoveAtPosition(01, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, 9, 2);

            /*" -4860- IF ENDOSSOS-DATA-TERVIGENCIA(6:2) = 01 OR = 03 OR = 05 OR = 07 OR = 08 OR = 10 OR = 12 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Substring(6, 2).In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -4862- MOVE 31 TO ENDOSSOS-DATA-TERVIGENCIA(9:2) */
                _.MoveAtPosition(31, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, 9, 2);

                /*" -4863- ELSE */
            }
            else
            {


                /*" -4867- IF ENDOSSOS-DATA-TERVIGENCIA(6:2) = 04 OR = 06 OR = 09 OR = 11 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Substring(6, 2).In("04", "06", "09", "11"))
                {

                    /*" -4869- MOVE 30 TO ENDOSSOS-DATA-TERVIGENCIA(9:2) */
                    _.MoveAtPosition(30, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, 9, 2);

                    /*" -4870- ELSE */
                }
                else
                {


                    /*" -4872- MOVE ENDOSSOS-DATA-TERVIGENCIA(1:4) TO WS-ANO */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Substring(1, 4), WS_ANO);

                    /*" -4874- DIVIDE WS-ANO BY 4 GIVING WS-RESULTADO REMAINDER WS-RESTO */
                    _.Divide(WS_ANO, 4, WS_RESULTADO, WS_RESTO);

                    /*" -4875- IF WS-RESTO EQUAL ZEROS */

                    if (WS_RESTO == 00)
                    {

                        /*" -4877- MOVE 29 TO ENDOSSOS-DATA-TERVIGENCIA(9:2) */
                        _.MoveAtPosition(29, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, 9, 2);

                        /*" -4878- ELSE */
                    }
                    else
                    {


                        /*" -4880- MOVE 28 TO ENDOSSOS-DATA-TERVIGENCIA(9:2) */
                        _.MoveAtPosition(28, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, 9, 2);

                        /*" -4881- END-IF */
                    }


                    /*" -4882- END-IF */
                }


                /*" -4883- END-IF */
            }


            /*" -4883- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2515_99_SAIDA*/

        [StopWatch]
        /*" R2516-00-TRATA-VIGENCIA-SECTION */
        private void R2516_00_TRATA_VIGENCIA_SECTION()
        {
            /*" -4892- MOVE '2516' TO WNR-EXEC-SQL. */
            _.Move("2516", W.WABEND.WNR_EXEC_SQL);

            /*" -4894- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4897- MOVE PARCEVID-DATA-VENCIMENTO TO ENDOSSOS-DATA-TERVIGENCIA */
            _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

            /*" -4904- IF ENDOSSOS-DATA-TERVIGENCIA(6:2) = 01 OR = 03 OR = 05 OR = 07 OR = 08 OR = 10 OR = 12 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Substring(6, 2).In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -4906- MOVE 31 TO ENDOSSOS-DATA-TERVIGENCIA(9:2) */
                _.MoveAtPosition(31, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, 9, 2);

                /*" -4907- ELSE */
            }
            else
            {


                /*" -4911- IF ENDOSSOS-DATA-TERVIGENCIA(6:2) = 04 OR = 06 OR = 09 OR = 11 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Substring(6, 2).In("04", "06", "09", "11"))
                {

                    /*" -4913- MOVE 30 TO ENDOSSOS-DATA-TERVIGENCIA(9:2) */
                    _.MoveAtPosition(30, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, 9, 2);

                    /*" -4914- ELSE */
                }
                else
                {


                    /*" -4916- MOVE ENDOSSOS-DATA-TERVIGENCIA(1:4) TO WS-ANO */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Substring(1, 4), WS_ANO);

                    /*" -4918- DIVIDE WS-ANO BY 4 GIVING WS-RESULTADO REMAINDER WS-RESTO */
                    _.Divide(WS_ANO, 4, WS_RESULTADO, WS_RESTO);

                    /*" -4919- IF WS-RESTO EQUAL ZEROS */

                    if (WS_RESTO == 00)
                    {

                        /*" -4921- MOVE 29 TO ENDOSSOS-DATA-TERVIGENCIA(9:2) */
                        _.MoveAtPosition(29, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, 9, 2);

                        /*" -4922- ELSE */
                    }
                    else
                    {


                        /*" -4924- MOVE 28 TO ENDOSSOS-DATA-TERVIGENCIA(9:2) */
                        _.MoveAtPosition(28, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, 9, 2);

                        /*" -4925- END-IF */
                    }


                    /*" -4926- END-IF */
                }


                /*" -4928- END-IF */
            }


            /*" -4930- IF ENDOSSOS-DATA-INIVIGENCIA EQUAL ENDOSSOS-DATA-TERVIGENCIA */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA == ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA)
            {

                /*" -4931- MOVE 01 TO ENDOSSOS-DATA-INIVIGENCIA(9:2) */
                _.MoveAtPosition(01, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, 9, 2);

                /*" -4932- END-IF */
            }


            /*" -4932- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2516_99_SAIDA*/

        [StopWatch]
        /*" R2520-00-INSERT-ENDOSSOS-SECTION */
        private void R2520_00_INSERT_ENDOSSOS_SECTION()
        {
            /*" -4941- MOVE '2520' TO WNR-EXEC-SQL. */
            _.Move("2520", W.WABEND.WNR_EXEC_SQL);

            /*" -4944- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -4947- ADD 1 TO IN-ENDOSSOS. */
            W.IN_ENDOSSOS.Value = W.IN_ENDOSSOS + 1;

            /*" -5038- PERFORM R2520_00_INSERT_ENDOSSOS_DB_INSERT_1 */

            R2520_00_INSERT_ENDOSSOS_DB_INSERT_1();

            /*" -5042- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5043- DISPLAY 'R2520-00 - PROBLEMAS NO INSERT(ENDOSSOS)   ' */
                _.Display($"R2520-00 - PROBLEMAS NO INSERT(ENDOSSOS)   ");

                /*" -5044- DISPLAY ' APOLICE    = ' ENDOSSOS-NUM-APOLICE */
                _.Display($" APOLICE    = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -5045- DISPLAY ' ENDOSSO    = ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -5045- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2520-00-INSERT-ENDOSSOS-DB-INSERT-1 */
        public void R2520_00_INSERT_ENDOSSOS_DB_INSERT_1()
        {
            /*" -5038- EXEC SQL INSERT INTO SEGUROS.ENDOSSOS (NUM_APOLICE ,NUM_ENDOSSO ,RAMO_EMISSOR ,COD_PRODUTO ,COD_SUBGRUPO ,COD_FONTE ,NUM_PROPOSTA ,DATA_PROPOSTA ,DATA_LIBERACAO ,DATA_EMISSAO ,NUM_RCAP ,VAL_RCAP ,BCO_RCAP ,AGE_RCAP ,DAC_RCAP ,TIPO_RCAP ,BCO_COBRANCA ,AGE_COBRANCA ,DAC_COBRANCA ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,PLANO_SEGURO ,PCT_ENTRADA ,PCT_ADIC_FRACIO ,QTD_DIAS_PRIMEIRA ,QTD_PARCELAS ,QTD_PRESTACOES ,QTD_ITENS ,COD_TEXTO_PADRAO ,COD_ACEITACAO ,COD_MOEDA_IMP ,COD_MOEDA_PRM ,TIPO_ENDOSSO ,COD_USUARIO ,OCORR_ENDERECO ,SIT_REGISTRO ,DATA_RCAP ,COD_EMPRESA ,TIPO_CORRECAO ,ISENTA_CUSTO ,TIMESTAMP ,DATA_VENCIMENTO ,COEF_PREFIX ,VAL_CUSTO_EMISSAO) VALUES (:ENDOSSOS-NUM-APOLICE ,:ENDOSSOS-NUM-ENDOSSO ,:ENDOSSOS-RAMO-EMISSOR ,:ENDOSSOS-COD-PRODUTO ,:ENDOSSOS-COD-SUBGRUPO ,:ENDOSSOS-COD-FONTE ,:ENDOSSOS-NUM-PROPOSTA ,:ENDOSSOS-DATA-PROPOSTA ,:ENDOSSOS-DATA-LIBERACAO ,:ENDOSSOS-DATA-EMISSAO ,:ENDOSSOS-NUM-RCAP ,:ENDOSSOS-VAL-RCAP ,:ENDOSSOS-BCO-RCAP ,:ENDOSSOS-AGE-RCAP ,:ENDOSSOS-DAC-RCAP ,:ENDOSSOS-TIPO-RCAP ,:ENDOSSOS-BCO-COBRANCA ,:ENDOSSOS-AGE-COBRANCA ,:ENDOSSOS-DAC-COBRANCA ,:ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA ,:ENDOSSOS-PLANO-SEGURO ,:ENDOSSOS-PCT-ENTRADA ,:ENDOSSOS-PCT-ADIC-FRACIO ,:ENDOSSOS-QTD-DIAS-PRIMEIRA ,:ENDOSSOS-QTD-PARCELAS ,:ENDOSSOS-QTD-PRESTACOES ,:ENDOSSOS-QTD-ITENS ,:ENDOSSOS-COD-TEXTO-PADRAO ,:ENDOSSOS-COD-ACEITACAO ,:ENDOSSOS-COD-MOEDA-IMP ,:ENDOSSOS-COD-MOEDA-PRM ,:ENDOSSOS-TIPO-ENDOSSO ,:ENDOSSOS-COD-USUARIO ,:ENDOSSOS-OCORR-ENDERECO ,:ENDOSSOS-SIT-REGISTRO ,:ENDOSSOS-DATA-RCAP:VIND-DATARCAP ,:ENDOSSOS-COD-EMPRESA:VIND-COD-EMPRESA ,:ENDOSSOS-TIPO-CORRECAO:VIND-TIPO-CORRECAO ,:ENDOSSOS-ISENTA-CUSTO:VIND-ISENTA-CUSTO , CURRENT TIMESTAMP ,:ENDOSSOS-DATA-VENCIMENTO:VIND-DTVENCTO ,:ENDOSSOS-COEF-PREFIX:VIND-CFPREFIX ,:ENDOSSOS-VAL-CUSTO-EMISSAO:VIND-VLCUSEMI) END-EXEC. */

            var r2520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1 = new R2520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
                ENDOSSOS_RAMO_EMISSOR = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR.ToString(),
                ENDOSSOS_COD_PRODUTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.ToString(),
                ENDOSSOS_COD_SUBGRUPO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO.ToString(),
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
                ENDOSSOS_NUM_PROPOSTA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA.ToString(),
                ENDOSSOS_DATA_PROPOSTA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA.ToString(),
                ENDOSSOS_DATA_LIBERACAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO.ToString(),
                ENDOSSOS_DATA_EMISSAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO.ToString(),
                ENDOSSOS_NUM_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP.ToString(),
                ENDOSSOS_VAL_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP.ToString(),
                ENDOSSOS_BCO_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP.ToString(),
                ENDOSSOS_AGE_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP.ToString(),
                ENDOSSOS_DAC_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP.ToString(),
                ENDOSSOS_TIPO_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP.ToString(),
                ENDOSSOS_BCO_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA.ToString(),
                ENDOSSOS_AGE_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA.ToString(),
                ENDOSSOS_DAC_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA.ToString(),
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                ENDOSSOS_DATA_TERVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.ToString(),
                ENDOSSOS_PLANO_SEGURO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO.ToString(),
                ENDOSSOS_PCT_ENTRADA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA.ToString(),
                ENDOSSOS_PCT_ADIC_FRACIO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO.ToString(),
                ENDOSSOS_QTD_DIAS_PRIMEIRA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA.ToString(),
                ENDOSSOS_QTD_PARCELAS = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS.ToString(),
                ENDOSSOS_QTD_PRESTACOES = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES.ToString(),
                ENDOSSOS_QTD_ITENS = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS.ToString(),
                ENDOSSOS_COD_TEXTO_PADRAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO.ToString(),
                ENDOSSOS_COD_ACEITACAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO.ToString(),
                ENDOSSOS_COD_MOEDA_IMP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP.ToString(),
                ENDOSSOS_COD_MOEDA_PRM = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM.ToString(),
                ENDOSSOS_TIPO_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO.ToString(),
                ENDOSSOS_COD_USUARIO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO.ToString(),
                ENDOSSOS_OCORR_ENDERECO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO.ToString(),
                ENDOSSOS_SIT_REGISTRO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO.ToString(),
                ENDOSSOS_DATA_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP.ToString(),
                VIND_DATARCAP = VIND_DATARCAP.ToString(),
                ENDOSSOS_COD_EMPRESA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA.ToString(),
                VIND_COD_EMPRESA = VIND_COD_EMPRESA.ToString(),
                ENDOSSOS_TIPO_CORRECAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO.ToString(),
                VIND_TIPO_CORRECAO = VIND_TIPO_CORRECAO.ToString(),
                ENDOSSOS_ISENTA_CUSTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO.ToString(),
                VIND_ISENTA_CUSTO = VIND_ISENTA_CUSTO.ToString(),
                ENDOSSOS_DATA_VENCIMENTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO.ToString(),
                VIND_DTVENCTO = VIND_DTVENCTO.ToString(),
                ENDOSSOS_COEF_PREFIX = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COEF_PREFIX.ToString(),
                VIND_CFPREFIX = VIND_CFPREFIX.ToString(),
                ENDOSSOS_VAL_CUSTO_EMISSAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_CUSTO_EMISSAO.ToString(),
                VIND_VLCUSEMI = VIND_VLCUSEMI.ToString(),
            };

            R2520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1.Execute(r2520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2520_99_SAIDA*/

        [StopWatch]
        /*" R2530-00-INSERT-PARCELAS-SECTION */
        private void R2530_00_INSERT_PARCELAS_SECTION()
        {
            /*" -5056- MOVE '2530' TO WNR-EXEC-SQL. */
            _.Move("2530", W.WABEND.WNR_EXEC_SQL);

            /*" -5059- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5062- ADD 1 TO IN-PARCELAS. */
            W.IN_PARCELAS.Value = W.IN_PARCELAS + 1;

            /*" -5103- PERFORM R2530_00_INSERT_PARCELAS_DB_INSERT_1 */

            R2530_00_INSERT_PARCELAS_DB_INSERT_1();

            /*" -5107- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5108- DISPLAY 'R2530-00 - PROBLEMAS NO INSERT(PARCELAS)   ' */
                _.Display($"R2530-00 - PROBLEMAS NO INSERT(PARCELAS)   ");

                /*" -5109- DISPLAY ' APOLICE    = ' PARCELAS-NUM-APOLICE */
                _.Display($" APOLICE    = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -5110- DISPLAY ' ENDOSSO    = ' PARCELAS-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -5110- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2530-00-INSERT-PARCELAS-DB-INSERT-1 */
        public void R2530_00_INSERT_PARCELAS_DB_INSERT_1()
        {
            /*" -5103- EXEC SQL INSERT INTO SEGUROS.PARCELAS (NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DAC_PARCELA ,COD_FONTE ,NUM_TITULO ,PRM_TARIFARIO_IX ,VAL_DESCONTO_IX ,PRM_LIQUIDO_IX ,ADICIONAL_FRAC_IX ,VAL_CUSTO_EMIS_IX ,VAL_IOCC_IX ,PRM_TOTAL_IX ,OCORR_HISTORICO ,QTD_DOCUMENTOS ,SIT_REGISTRO ,COD_EMPRESA ,TIMESTAMP ,SITUACAO_COBRANCA) VALUES (:PARCELAS-NUM-APOLICE ,:PARCELAS-NUM-ENDOSSO ,:PARCELAS-NUM-PARCELA ,:PARCELAS-DAC-PARCELA ,:PARCELAS-COD-FONTE ,:PARCELAS-NUM-TITULO ,:PARCELAS-PRM-TARIFARIO-IX ,:PARCELAS-VAL-DESCONTO-IX ,:PARCELAS-PRM-LIQUIDO-IX ,:PARCELAS-ADICIONAL-FRAC-IX ,:PARCELAS-VAL-CUSTO-EMIS-IX ,:PARCELAS-VAL-IOCC-IX ,:PARCELAS-PRM-TOTAL-IX ,:PARCELAS-OCORR-HISTORICO ,:PARCELAS-QTD-DOCUMENTOS ,:PARCELAS-SIT-REGISTRO ,:PARCELAS-COD-EMPRESA:VIND-COD-EMPRESA , CURRENT TIMESTAMP ,:PARCELAS-SITUACAO-COBRANCA:VIND-SITCOB) END-EXEC. */

            var r2530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1 = new R2530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
                PARCELAS_NUM_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.ToString(),
                PARCELAS_DAC_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA.ToString(),
                PARCELAS_COD_FONTE = PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE.ToString(),
                PARCELAS_NUM_TITULO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO.ToString(),
                PARCELAS_PRM_TARIFARIO_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX.ToString(),
                PARCELAS_VAL_DESCONTO_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX.ToString(),
                PARCELAS_PRM_LIQUIDO_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX.ToString(),
                PARCELAS_ADICIONAL_FRAC_IX = PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX.ToString(),
                PARCELAS_VAL_CUSTO_EMIS_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX.ToString(),
                PARCELAS_VAL_IOCC_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX.ToString(),
                PARCELAS_PRM_TOTAL_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX.ToString(),
                PARCELAS_OCORR_HISTORICO = PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO.ToString(),
                PARCELAS_QTD_DOCUMENTOS = PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS.ToString(),
                PARCELAS_SIT_REGISTRO = PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO.ToString(),
                PARCELAS_COD_EMPRESA = PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA.ToString(),
                VIND_COD_EMPRESA = VIND_COD_EMPRESA.ToString(),
                PARCELAS_SITUACAO_COBRANCA = PARCELAS.DCLPARCELAS.PARCELAS_SITUACAO_COBRANCA.ToString(),
                VIND_SITCOB = VIND_SITCOB.ToString(),
            };

            R2530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1.Execute(r2530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2530_99_SAIDA*/

        [StopWatch]
        /*" R2550-00-INSERT-PARCEHIS-SECTION */
        private void R2550_00_INSERT_PARCEHIS_SECTION()
        {
            /*" -5121- MOVE '2550' TO WNR-EXEC-SQL. */
            _.Move("2550", W.WABEND.WNR_EXEC_SQL);

            /*" -5124- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5127- ADD 1 TO IN-PARCEHIS. */
            W.IN_PARCEHIS.Value = W.IN_PARCEHIS + 1;

            /*" -5184- PERFORM R2550_00_INSERT_PARCEHIS_DB_INSERT_1 */

            R2550_00_INSERT_PARCEHIS_DB_INSERT_1();

            /*" -5188- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5189- DISPLAY 'R2550-00 - PROBLEMAS NO INSERT(PARCEHIS)   ' */
                _.Display($"R2550-00 - PROBLEMAS NO INSERT(PARCEHIS)   ");

                /*" -5190- DISPLAY ' APOLICE    = ' PARCEHIS-NUM-APOLICE */
                _.Display($" APOLICE    = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -5191- DISPLAY ' ENDOSSO    = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -5191- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2550-00-INSERT-PARCEHIS-DB-INSERT-1 */
        public void R2550_00_INSERT_PARCEHIS_DB_INSERT_1()
        {
            /*" -5184- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO (NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DAC_PARCELA ,DATA_MOVIMENTO ,COD_OPERACAO ,HORA_OPERACAO ,OCORR_HISTORICO ,PRM_TARIFARIO ,VAL_DESCONTO ,PRM_LIQUIDO ,ADICIONAL_FRACIO ,VAL_CUSTO_EMISSAO ,VAL_IOCC ,PRM_TOTAL ,VAL_OPERACAO ,DATA_VENCIMENTO ,BCO_COBRANCA ,AGE_COBRANCA ,NUM_AVISO_CREDITO ,ENDOS_CANCELA ,SIT_CONTABIL ,COD_USUARIO ,RENUM_DOCUMENTO ,DATA_QUITACAO ,COD_EMPRESA ,TIMESTAMP) VALUES (:PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA ,:PARCEHIS-DAC-PARCELA ,:PARCEHIS-DATA-MOVIMENTO ,:PARCEHIS-COD-OPERACAO , CURRENT TIME ,:PARCEHIS-OCORR-HISTORICO ,:PARCEHIS-PRM-TARIFARIO ,:PARCEHIS-VAL-DESCONTO ,:PARCEHIS-PRM-LIQUIDO ,:PARCEHIS-ADICIONAL-FRACIO ,:PARCEHIS-VAL-CUSTO-EMISSAO ,:PARCEHIS-VAL-IOCC ,:PARCEHIS-PRM-TOTAL ,:PARCEHIS-VAL-OPERACAO ,:PARCEHIS-DATA-VENCIMENTO ,:PARCEHIS-BCO-COBRANCA ,:PARCEHIS-AGE-COBRANCA ,:PARCEHIS-NUM-AVISO-CREDITO ,:PARCEHIS-ENDOS-CANCELA ,:PARCEHIS-SIT-CONTABIL ,:PARCEHIS-COD-USUARIO ,:PARCEHIS-RENUM-DOCUMENTO ,:PARCEHIS-DATA-QUITACAO:VIND-DTQITBCO ,:PARCEHIS-COD-EMPRESA:VIND-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r2550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1 = new R2550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                PARCEHIS_DAC_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.ToString(),
                PARCEHIS_DATA_MOVIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.ToString(),
                PARCEHIS_COD_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_PRM_TARIFARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO.ToString(),
                PARCEHIS_VAL_DESCONTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO.ToString(),
                PARCEHIS_PRM_LIQUIDO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO.ToString(),
                PARCEHIS_ADICIONAL_FRACIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO.ToString(),
                PARCEHIS_VAL_CUSTO_EMISSAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO.ToString(),
                PARCEHIS_VAL_IOCC = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC.ToString(),
                PARCEHIS_PRM_TOTAL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL.ToString(),
                PARCEHIS_VAL_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.ToString(),
                PARCEHIS_DATA_VENCIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_SIT_CONTABIL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.ToString(),
                PARCEHIS_COD_USUARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.ToString(),
                PARCEHIS_RENUM_DOCUMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.ToString(),
                PARCEHIS_DATA_QUITACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                PARCEHIS_COD_EMPRESA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.ToString(),
                VIND_COD_EMPRESA = VIND_COD_EMPRESA.ToString(),
            };

            R2550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1.Execute(r2550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2550_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-TRATA-COSSEGURO-SECTION */
        private void R2700_00_TRATA_COSSEGURO_SECTION()
        {
            /*" -5202- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", W.WABEND.WNR_EXEC_SQL);

            /*" -5205- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5206- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -5208- PERFORM R2710-00-DECLARE-APOLCOSS. */

            R2710_00_DECLARE_APOLCOSS_SECTION();

            /*" -5210- PERFORM R2720-00-FETCH-APOLCOSS. */

            R2720_00_FETCH_APOLCOSS_SECTION();

            /*" -5211- PERFORM R2730-00-PROCESSA-APOLCOSS UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R2730_00_PROCESSA_APOLCOSS_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2710-00-DECLARE-APOLCOSS-SECTION */
        private void R2710_00_DECLARE_APOLCOSS_SECTION()
        {
            /*" -5222- MOVE '2710' TO WNR-EXEC-SQL. */
            _.Move("2710", W.WABEND.WNR_EXEC_SQL);

            /*" -5225- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5234- PERFORM R2710_00_DECLARE_APOLCOSS_DB_DECLARE_1 */

            R2710_00_DECLARE_APOLCOSS_DB_DECLARE_1();

            /*" -5236- PERFORM R2710_00_DECLARE_APOLCOSS_DB_OPEN_1 */

            R2710_00_DECLARE_APOLCOSS_DB_OPEN_1();

            /*" -5240- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5241- DISPLAY 'R2710-00 - PROBLEMAS DECLARE (APOLCOSS)  ' */
                _.Display($"R2710-00 - PROBLEMAS DECLARE (APOLCOSS)  ");

                /*" -5241- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2710-00-DECLARE-APOLCOSS-DB-OPEN-1 */
        public void R2710_00_DECLARE_APOLCOSS_DB_OPEN_1()
        {
            /*" -5236- EXEC SQL OPEN V0APOLCOSS END-EXEC. */

            V0APOLCOSS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/

        [StopWatch]
        /*" R2720-00-FETCH-APOLCOSS-SECTION */
        private void R2720_00_FETCH_APOLCOSS_SECTION()
        {
            /*" -5252- MOVE '2720' TO WNR-EXEC-SQL. */
            _.Move("2720", W.WABEND.WNR_EXEC_SQL);

            /*" -5255- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5258- PERFORM R2720_00_FETCH_APOLCOSS_DB_FETCH_1 */

            R2720_00_FETCH_APOLCOSS_DB_FETCH_1();

            /*" -5262- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5262- PERFORM R2720_00_FETCH_APOLCOSS_DB_CLOSE_1 */

                R2720_00_FETCH_APOLCOSS_DB_CLOSE_1();

                /*" -5264- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -5266- GO TO R2720-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2720_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5267- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5268- DISPLAY 'R2720-00 - PROBLEMAS FETCH   (APOLCOSS)  ' */
                _.Display($"R2720-00 - PROBLEMAS FETCH   (APOLCOSS)  ");

                /*" -5268- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2720-00-FETCH-APOLCOSS-DB-FETCH-1 */
        public void R2720_00_FETCH_APOLCOSS_DB_FETCH_1()
        {
            /*" -5258- EXEC SQL FETCH V0APOLCOSS INTO :APOLCOSS-COD-COSSEGURADORA END-EXEC. */

            if (V0APOLCOSS.Fetch())
            {
                _.Move(V0APOLCOSS.APOLCOSS_COD_COSSEGURADORA, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA);
            }

        }

        [StopWatch]
        /*" R2720-00-FETCH-APOLCOSS-DB-CLOSE-1 */
        public void R2720_00_FETCH_APOLCOSS_DB_CLOSE_1()
        {
            /*" -5262- EXEC SQL CLOSE V0APOLCOSS END-EXEC */

            V0APOLCOSS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2720_99_SAIDA*/

        [StopWatch]
        /*" R2730-00-PROCESSA-APOLCOSS-SECTION */
        private void R2730_00_PROCESSA_APOLCOSS_SECTION()
        {
            /*" -5279- MOVE '2730' TO WNR-EXEC-SQL. */
            _.Move("2730", W.WABEND.WNR_EXEC_SQL);

            /*" -5282- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5285- PERFORM R2740-00-SELECT-NUMERCOS. */

            R2740_00_SELECT_NUMERCOS_SECTION();

            /*" -5288- PERFORM R2750-00-INSERT-ORDEMCOS. */

            R2750_00_INSERT_ORDEMCOS_SECTION();

            /*" -5291- PERFORM R2760-00-UPDATE-NUMERCOS. */

            R2760_00_UPDATE_NUMERCOS_SECTION();

            /*" -5293- MOVE 'EM0103B1' TO EMISSDIA-COD-RELATORIO. */
            _.Move("EM0103B1", EMISSDIA.DCLEMISSAO_DIARIA.EMISSDIA_COD_RELATORIO);

            /*" -5295- MOVE ZEROS TO EMISSDIA-ORGAO-EMISSOR. */
            _.Move(0, EMISSDIA.DCLEMISSAO_DIARIA.EMISSDIA_ORGAO_EMISSOR);

            /*" -5297- MOVE ZEROS TO EMISSDIA-COD-FONTE. */
            _.Move(0, EMISSDIA.DCLEMISSAO_DIARIA.EMISSDIA_COD_FONTE);

            /*" -5299- MOVE ZEROS TO EMISSDIA-COD-CORRETOR. */
            _.Move(0, EMISSDIA.DCLEMISSAO_DIARIA.EMISSDIA_COD_CORRETOR);

            /*" -5303- MOVE '0' TO EMISSDIA-SIT-REGISTRO. */
            _.Move("0", EMISSDIA.DCLEMISSAO_DIARIA.EMISSDIA_SIT_REGISTRO);

            /*" -5306- PERFORM R2800-00-INSERT-EMISSDIA. */

            R2800_00_INSERT_EMISSDIA_SECTION();

            /*" -5308- MOVE 'EM0105B1' TO EMISSDIA-COD-RELATORIO. */
            _.Move("EM0105B1", EMISSDIA.DCLEMISSAO_DIARIA.EMISSDIA_COD_RELATORIO);

            /*" -5312- MOVE ENDOSSOS-COD-FONTE TO EMISSDIA-COD-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, EMISSDIA.DCLEMISSAO_DIARIA.EMISSDIA_COD_FONTE);

            /*" -5312- PERFORM R2800-00-INSERT-EMISSDIA. */

            R2800_00_INSERT_EMISSDIA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R2730_90_LEITURA */

            R2730_90_LEITURA();

        }

        [StopWatch]
        /*" R2730-90-LEITURA */
        private void R2730_90_LEITURA(bool isPerform = false)
        {
            /*" -5317- PERFORM R2720-00-FETCH-APOLCOSS. */

            R2720_00_FETCH_APOLCOSS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2730_99_SAIDA*/

        [StopWatch]
        /*" R2740-00-SELECT-NUMERCOS-SECTION */
        private void R2740_00_SELECT_NUMERCOS_SECTION()
        {
            /*" -5327- MOVE '2740' TO WNR-EXEC-SQL. */
            _.Move("2740", W.WABEND.WNR_EXEC_SQL);

            /*" -5330- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5337- PERFORM R2740_00_SELECT_NUMERCOS_DB_SELECT_1 */

            R2740_00_SELECT_NUMERCOS_DB_SELECT_1();

            /*" -5341- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5342- DISPLAY 'R2740-00 - PROBLEMAS NO SELECT(NUMERCOS)' */
                _.Display($"R2740-00 - PROBLEMAS NO SELECT(NUMERCOS)");

                /*" -5345- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5346- COMPUTE NUMERCOS-SEQ-ORD-CEDIDO EQUAL (NUMERCOS-SEQ-ORD-CEDIDO + 1). */
            NUMERCOS.DCLNUMERO_COSSEGURO.NUMERCOS_SEQ_ORD_CEDIDO.Value = (NUMERCOS.DCLNUMERO_COSSEGURO.NUMERCOS_SEQ_ORD_CEDIDO + 1);

        }

        [StopWatch]
        /*" R2740-00-SELECT-NUMERCOS-DB-SELECT-1 */
        public void R2740_00_SELECT_NUMERCOS_DB_SELECT_1()
        {
            /*" -5337- EXEC SQL SELECT SEQ_ORD_CEDIDO INTO :NUMERCOS-SEQ-ORD-CEDIDO FROM SEGUROS.NUMERO_COSSEGURO WHERE ORGAO_EMISSOR = :NUMERAES-ORGAO-EMISSOR AND COD_CONGENERE = :APOLCOSS-COD-COSSEGURADORA WITH UR END-EXEC. */

            var r2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1 = new R2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1()
            {
                APOLCOSS_COD_COSSEGURADORA = APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA.ToString(),
                NUMERAES_ORGAO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR.ToString(),
            };

            var executed_1 = R2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1.Execute(r2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMERCOS_SEQ_ORD_CEDIDO, NUMERCOS.DCLNUMERO_COSSEGURO.NUMERCOS_SEQ_ORD_CEDIDO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2740_99_SAIDA*/

        [StopWatch]
        /*" R2750-00-INSERT-ORDEMCOS-SECTION */
        private void R2750_00_INSERT_ORDEMCOS_SECTION()
        {
            /*" -5357- MOVE '2750' TO WNR-EXEC-SQL. */
            _.Move("2750", W.WABEND.WNR_EXEC_SQL);

            /*" -5360- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5363- ADD 1 TO IN-ORDEMCOS. */
            W.IN_ORDEMCOS.Value = W.IN_ORDEMCOS + 1;

            /*" -5378- PERFORM R2750_00_INSERT_ORDEMCOS_DB_INSERT_1 */

            R2750_00_INSERT_ORDEMCOS_DB_INSERT_1();

            /*" -5382- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5383- DISPLAY 'R2750-00 - PROBLEMAS NO INSERT(PARCEHIS)   ' */
                _.Display($"R2750-00 - PROBLEMAS NO INSERT(PARCEHIS)   ");

                /*" -5384- DISPLAY ' APOLICE    = ' PARCEHIS-NUM-APOLICE */
                _.Display($" APOLICE    = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -5385- DISPLAY ' ENDOSSO    = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -5385- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2750-00-INSERT-ORDEMCOS-DB-INSERT-1 */
        public void R2750_00_INSERT_ORDEMCOS_DB_INSERT_1()
        {
            /*" -5378- EXEC SQL INSERT INTO SEGUROS.ORDEM_COSSEGCED (NUM_APOLICE ,NUM_ENDOSSO ,COD_COSSEGURADORA ,ORDEM_CEDIDO ,COD_EMPRESA ,TIMESTAMP) VALUES (:PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:APOLCOSS-COD-COSSEGURADORA ,:NUMERCOS-SEQ-ORD-CEDIDO ,:PARCEHIS-COD-EMPRESA:VIND-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r2750_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1 = new R2750_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                APOLCOSS_COD_COSSEGURADORA = APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA.ToString(),
                NUMERCOS_SEQ_ORD_CEDIDO = NUMERCOS.DCLNUMERO_COSSEGURO.NUMERCOS_SEQ_ORD_CEDIDO.ToString(),
                PARCEHIS_COD_EMPRESA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.ToString(),
                VIND_COD_EMPRESA = VIND_COD_EMPRESA.ToString(),
            };

            R2750_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1.Execute(r2750_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2750_99_SAIDA*/

        [StopWatch]
        /*" R2760-00-UPDATE-NUMERCOS-SECTION */
        private void R2760_00_UPDATE_NUMERCOS_SECTION()
        {
            /*" -5396- MOVE '2760' TO WNR-EXEC-SQL. */
            _.Move("2760", W.WABEND.WNR_EXEC_SQL);

            /*" -5399- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5405- PERFORM R2760_00_UPDATE_NUMERCOS_DB_UPDATE_1 */

            R2760_00_UPDATE_NUMERCOS_DB_UPDATE_1();

            /*" -5409- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5410- DISPLAY 'R2760-00 - PROBLEMAS UPDATE (NUMERCOS)' */
                _.Display($"R2760-00 - PROBLEMAS UPDATE (NUMERCOS)");

                /*" -5410- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2760-00-UPDATE-NUMERCOS-DB-UPDATE-1 */
        public void R2760_00_UPDATE_NUMERCOS_DB_UPDATE_1()
        {
            /*" -5405- EXEC SQL UPDATE SEGUROS.NUMERO_COSSEGURO SET SEQ_ORD_CEDIDO = :NUMERCOS-SEQ-ORD-CEDIDO WHERE ORGAO_EMISSOR = :NUMERAES-ORGAO-EMISSOR AND COD_CONGENERE = :APOLCOSS-COD-COSSEGURADORA END-EXEC. */

            var r2760_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1 = new R2760_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1()
            {
                NUMERCOS_SEQ_ORD_CEDIDO = NUMERCOS.DCLNUMERO_COSSEGURO.NUMERCOS_SEQ_ORD_CEDIDO.ToString(),
                APOLCOSS_COD_COSSEGURADORA = APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA.ToString(),
                NUMERAES_ORGAO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR.ToString(),
            };

            R2760_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1.Execute(r2760_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2760_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-INSERT-EMISSDIA-SECTION */
        private void R2800_00_INSERT_EMISSDIA_SECTION()
        {
            /*" -5421- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", W.WABEND.WNR_EXEC_SQL);

            /*" -5424- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5427- ADD 1 TO IN-EMISSDIA. */
            W.IN_EMISSDIA.Value = W.IN_EMISSDIA + 1;

            /*" -5456- PERFORM R2800_00_INSERT_EMISSDIA_DB_INSERT_1 */

            R2800_00_INSERT_EMISSDIA_DB_INSERT_1();

            /*" -5460- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5461- DISPLAY 'R2800-00 - PROBLEMAS NO INSERT(EMISSDIA)   ' */
                _.Display($"R2800-00 - PROBLEMAS NO INSERT(EMISSDIA)   ");

                /*" -5462- DISPLAY ' RELATORIO  = ' EMISSDIA-COD-RELATORIO */
                _.Display($" RELATORIO  = {EMISSDIA.DCLEMISSAO_DIARIA.EMISSDIA_COD_RELATORIO}");

                /*" -5463- DISPLAY ' APOLICE    = ' PARCEHIS-NUM-APOLICE */
                _.Display($" APOLICE    = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -5464- DISPLAY ' ENDOSSO    = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -5464- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2800-00-INSERT-EMISSDIA-DB-INSERT-1 */
        public void R2800_00_INSERT_EMISSDIA_DB_INSERT_1()
        {
            /*" -5456- EXEC SQL INSERT INTO SEGUROS.EMISSAO_DIARIA (COD_RELATORIO ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DATA_MOVIMENTO ,ORGAO_EMISSOR ,RAMO_EMISSOR ,COD_FONTE ,COD_CONGENERE ,COD_CORRETOR ,SIT_REGISTRO ,COD_EMPRESA ,TIMESTAMP) VALUES (:EMISSDIA-COD-RELATORIO ,:PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA ,:PARCEHIS-DATA-MOVIMENTO ,:EMISSDIA-ORGAO-EMISSOR ,:ENDOSSOS-RAMO-EMISSOR ,:EMISSDIA-COD-FONTE ,:APOLCOSS-COD-COSSEGURADORA ,:EMISSDIA-COD-CORRETOR ,:EMISSDIA-SIT-REGISTRO ,:PARCEHIS-COD-EMPRESA:VIND-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r2800_00_INSERT_EMISSDIA_DB_INSERT_1_Insert1 = new R2800_00_INSERT_EMISSDIA_DB_INSERT_1_Insert1()
            {
                EMISSDIA_COD_RELATORIO = EMISSDIA.DCLEMISSAO_DIARIA.EMISSDIA_COD_RELATORIO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                PARCEHIS_DATA_MOVIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.ToString(),
                EMISSDIA_ORGAO_EMISSOR = EMISSDIA.DCLEMISSAO_DIARIA.EMISSDIA_ORGAO_EMISSOR.ToString(),
                ENDOSSOS_RAMO_EMISSOR = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR.ToString(),
                EMISSDIA_COD_FONTE = EMISSDIA.DCLEMISSAO_DIARIA.EMISSDIA_COD_FONTE.ToString(),
                APOLCOSS_COD_COSSEGURADORA = APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA.ToString(),
                EMISSDIA_COD_CORRETOR = EMISSDIA.DCLEMISSAO_DIARIA.EMISSDIA_COD_CORRETOR.ToString(),
                EMISSDIA_SIT_REGISTRO = EMISSDIA.DCLEMISSAO_DIARIA.EMISSDIA_SIT_REGISTRO.ToString(),
                PARCEHIS_COD_EMPRESA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.ToString(),
                VIND_COD_EMPRESA = VIND_COD_EMPRESA.ToString(),
            };

            R2800_00_INSERT_EMISSDIA_DB_INSERT_1_Insert1.Execute(r2800_00_INSERT_EMISSDIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-INSERT-COBERTURAS-SECTION */
        private void R3000_00_INSERT_COBERTURAS_SECTION()
        {
            /*" -5475- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", W.WABEND.WNR_EXEC_SQL);

            /*" -5478- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5480- SET WS-COB00 TO 1. */
            WS_COB00.Value = 1;

            /*" -5483- PERFORM R3010-00-INSERT-COB00 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R3010_00_INSERT_COB00_SECTION();

            }

            /*" -5485- SET WS-COB01 TO 1. */
            WS_COB01.Value = 1;

            /*" -5485- PERFORM R3020-00-INSERT-COB01 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R3020_00_INSERT_COB01_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-INSERT-COB00-SECTION */
        private void R3010_00_INSERT_COB00_SECTION()
        {
            /*" -5496- MOVE '3010' TO WNR-EXEC-SQL. */
            _.Move("3010", W.WABEND.WNR_EXEC_SQL);

            /*" -5499- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5500- IF WCOB00-RAMO(WS-COB00) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO == 00)
            {

                /*" -5501- SET WS-COB00 UP BY 1 */
                WS_COB00.Value += 1;

                /*" -5504- GO TO R3010-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5506- MOVE ENDOSSOS-NUM-APOLICE TO APOLICOB-NUM-APOLICE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);

            /*" -5508- MOVE ENDOSSOS-NUM-ENDOSSO TO APOLICOB-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);

            /*" -5510- MOVE ZEROS TO APOLICOB-NUM-ITEM. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);

            /*" -5512- MOVE 1 TO APOLICOB-OCORR-HISTORICO. */
            _.Move(1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO);

            /*" -5514- MOVE SOR-MODALIDA TO APOLICOB-MODALI-COBERTURA. */
            _.Move(REG_SVA0141B.SOR_MODALIDA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA);

            /*" -5516- MOVE 1 TO APOLICOB-FATOR-MULTIPLICA. */
            _.Move(1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

            /*" -5518- MOVE ENDOSSOS-DATA-INIVIGENCIA TO APOLICOB-DATA-INIVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);

            /*" -5520- MOVE ENDOSSOS-DATA-TERVIGENCIA TO APOLICOB-DATA-TERVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);

            /*" -5522- MOVE ZEROS TO APOLICOB-COD-EMPRESA. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA);

            /*" -5524- MOVE '0' TO APOLICOB-SIT-REGISTRO. */
            _.Move("0", APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO);

            /*" -5527- MOVE ZEROS TO VIND-NULL01 VIND-NULL02. */
            _.Move(0, VIND_NULL01, VIND_NULL02);

            /*" -5529- MOVE WCOB00-RAMO(WS-COB00) TO APOLICOB-RAMO-COBERTURA. */
            _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

            /*" -5531- MOVE WCOB00-COBE(WS-COB00) TO APOLICOB-COD-COBERTURA. */
            _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

            /*" -5534- MOVE WCOB00-IMPSEG(WS-COB00) TO APOLICOB-IMP-SEGURADA-IX APOLICOB-IMP-SEGURADA-VAR. */
            _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);

            /*" -5537- MOVE WCOB00-PRMTAR(WS-COB00) TO APOLICOB-PRM-TARIFARIO-IX APOLICOB-PRM-TARIFARIO-VAR. */
            _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);

            /*" -5541- MOVE WCOB00-PERCEN(WS-COB00) TO APOLICOB-PCT-COBERTURA. */
            _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);

            /*" -5544- PERFORM R3100-00-INSERT-APOLICOB. */

            R3100_00_INSERT_APOLICOB_SECTION();

            /*" -5544- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R3020-00-INSERT-COB01-SECTION */
        private void R3020_00_INSERT_COB01_SECTION()
        {
            /*" -5555- MOVE '3020' TO WNR-EXEC-SQL. */
            _.Move("3020", W.WABEND.WNR_EXEC_SQL);

            /*" -5558- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5559- IF WCOB01-RAMO(WS-COB01) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO == 00)
            {

                /*" -5560- SET WS-COB01 UP BY 1 */
                WS_COB01.Value += 1;

                /*" -5563- GO TO R3020-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5565- MOVE ENDOSSOS-NUM-APOLICE TO APOLICOB-NUM-APOLICE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);

            /*" -5567- MOVE ENDOSSOS-NUM-ENDOSSO TO APOLICOB-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);

            /*" -5569- MOVE ZEROS TO APOLICOB-NUM-ITEM. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);

            /*" -5571- MOVE 1 TO APOLICOB-OCORR-HISTORICO. */
            _.Move(1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO);

            /*" -5573- MOVE SOR-MODALIDA TO APOLICOB-MODALI-COBERTURA. */
            _.Move(REG_SVA0141B.SOR_MODALIDA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA);

            /*" -5575- MOVE 1 TO APOLICOB-FATOR-MULTIPLICA. */
            _.Move(1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

            /*" -5577- MOVE ENDOSSOS-DATA-INIVIGENCIA TO APOLICOB-DATA-INIVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);

            /*" -5579- MOVE ENDOSSOS-DATA-TERVIGENCIA TO APOLICOB-DATA-TERVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);

            /*" -5581- MOVE ZEROS TO APOLICOB-COD-EMPRESA. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA);

            /*" -5583- MOVE '0' TO APOLICOB-SIT-REGISTRO. */
            _.Move("0", APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO);

            /*" -5586- MOVE ZEROS TO VIND-NULL01 VIND-NULL02. */
            _.Move(0, VIND_NULL01, VIND_NULL02);

            /*" -5588- MOVE WCOB01-RAMO(WS-COB01) TO APOLICOB-RAMO-COBERTURA. */
            _.Move(TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

            /*" -5590- MOVE WCOB01-COBE(WS-COB01) TO APOLICOB-COD-COBERTURA. */
            _.Move(TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

            /*" -5593- MOVE WCOB01-IMPSEG(WS-COB01) TO APOLICOB-IMP-SEGURADA-IX APOLICOB-IMP-SEGURADA-VAR. */
            _.Move(TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);

            /*" -5596- MOVE WCOB01-PRMTAR(WS-COB01) TO APOLICOB-PRM-TARIFARIO-IX APOLICOB-PRM-TARIFARIO-VAR. */
            _.Move(TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);

            /*" -5600- MOVE WCOB01-PERCEN(WS-COB01) TO APOLICOB-PCT-COBERTURA. */
            _.Move(TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);

            /*" -5603- PERFORM R3100-00-INSERT-APOLICOB. */

            R3100_00_INSERT_APOLICOB_SECTION();

            /*" -5603- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-APOLICOB-SECTION */
        private void R3100_00_INSERT_APOLICOB_SECTION()
        {
            /*" -5614- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", W.WABEND.WNR_EXEC_SQL);

            /*" -5617- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5620- ADD 1 TO IN-APOLICOB. */
            W.IN_APOLICOB.Value = W.IN_APOLICOB + 1;

            /*" -5659- PERFORM R3100_00_INSERT_APOLICOB_DB_INSERT_1 */

            R3100_00_INSERT_APOLICOB_DB_INSERT_1();

            /*" -5663- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5664- DISPLAY 'R3100-00 - PROBLEMAS NO INSERT(APOLICOB)   ' */
                _.Display($"R3100-00 - PROBLEMAS NO INSERT(APOLICOB)   ");

                /*" -5665- DISPLAY ' APOLICE    = ' APOLICOB-NUM-APOLICE */
                _.Display($" APOLICE    = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}");

                /*" -5666- DISPLAY ' ENDOSSO    = ' APOLICOB-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}");

                /*" -5667- DISPLAY ' RAMO       = ' APOLICOB-RAMO-COBERTURA */
                _.Display($" RAMO       = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}");

                /*" -5668- DISPLAY ' COBERTURA  = ' APOLICOB-COD-COBERTURA */
                _.Display($" COBERTURA  = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA}");

                /*" -5668- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-INSERT-APOLICOB-DB-INSERT-1 */
        public void R3100_00_INSERT_APOLICOB_DB_INSERT_1()
        {
            /*" -5659- EXEC SQL INSERT INTO SEGUROS.APOLICE_COBERTURAS (NUM_APOLICE ,NUM_ENDOSSO ,NUM_ITEM ,OCORR_HISTORICO ,RAMO_COBERTURA ,MODALI_COBERTURA ,COD_COBERTURA ,IMP_SEGURADA_IX ,PRM_TARIFARIO_IX ,IMP_SEGURADA_VAR ,PRM_TARIFARIO_VAR ,PCT_COBERTURA ,FATOR_MULTIPLICA ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,COD_EMPRESA ,TIMESTAMP ,SIT_REGISTRO) VALUES (:APOLICOB-NUM-APOLICE ,:APOLICOB-NUM-ENDOSSO ,:APOLICOB-NUM-ITEM ,:APOLICOB-OCORR-HISTORICO ,:APOLICOB-RAMO-COBERTURA ,:APOLICOB-MODALI-COBERTURA ,:APOLICOB-COD-COBERTURA ,:APOLICOB-IMP-SEGURADA-IX ,:APOLICOB-PRM-TARIFARIO-IX ,:APOLICOB-IMP-SEGURADA-VAR ,:APOLICOB-PRM-TARIFARIO-VAR ,:APOLICOB-PCT-COBERTURA ,:APOLICOB-FATOR-MULTIPLICA ,:APOLICOB-DATA-INIVIGENCIA ,:APOLICOB-DATA-TERVIGENCIA ,:APOLICOB-COD-EMPRESA:VIND-NULL01 , CURRENT TIMESTAMP ,:APOLICOB-SIT-REGISTRO:VIND-NULL02) END-EXEC. */

            var r3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 = new R3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1()
            {
                APOLICOB_NUM_APOLICE = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.ToString(),
                APOLICOB_NUM_ENDOSSO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.ToString(),
                APOLICOB_NUM_ITEM = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM.ToString(),
                APOLICOB_OCORR_HISTORICO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO.ToString(),
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                APOLICOB_MODALI_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                APOLICOB_IMP_SEGURADA_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.ToString(),
                APOLICOB_PRM_TARIFARIO_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX.ToString(),
                APOLICOB_IMP_SEGURADA_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR.ToString(),
                APOLICOB_PRM_TARIFARIO_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR.ToString(),
                APOLICOB_PCT_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA.ToString(),
                APOLICOB_FATOR_MULTIPLICA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA.ToString(),
                APOLICOB_DATA_INIVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.ToString(),
                APOLICOB_DATA_TERVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.ToString(),
                APOLICOB_COD_EMPRESA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                APOLICOB_SIT_REGISTRO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
            };

            R3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1.Execute(r3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-UPDATE-HISCONPA-SECTION */
        private void R4000_00_UPDATE_HISCONPA_SECTION()
        {
            /*" -5679- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", W.WABEND.WNR_EXEC_SQL);

            /*" -5682- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5684- MOVE SOR-NUM-CERTIFICADO TO HISCONPA-NUM-CERTIFICADO. */
            _.Move(REG_SVA0141B.SOR_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -5686- MOVE SOR-NUM-PARCELA TO HISCONPA-NUM-PARCELA. */
            _.Move(REG_SVA0141B.SOR_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -5688- MOVE SOR-NUM-TITULO TO HISCONPA-NUM-TITULO. */
            _.Move(REG_SVA0141B.SOR_NUM_TITULO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO);

            /*" -5691- MOVE SOR-OCORR-HISTORICO TO HISCONPA-OCORR-HISTORICO. */
            _.Move(REG_SVA0141B.SOR_OCORR_HISTORICO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);

            /*" -5693- MOVE SOR-SUBGRUPO TO HISCONPA-COD-SUBGRUPO. */
            _.Move(REG_SVA0141B.SOR_SUBGRUPO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO);

            /*" -5695- MOVE ENDOSSOS-NUM-ENDOSSO TO HISCONPA-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);

            /*" -5697- MOVE '1' TO HISCONPA-SIT-REGISTRO. */
            _.Move("1", HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO);

            /*" -5699- MOVE ENDOSSOS-DATA-EMISSAO TO HISCONPA-DTFATUR. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR);

            /*" -5702- MOVE ZEROS TO VIND-NULL01. */
            _.Move(0, VIND_NULL01);

            /*" -5713- PERFORM R4000_00_UPDATE_HISCONPA_DB_UPDATE_1 */

            R4000_00_UPDATE_HISCONPA_DB_UPDATE_1();

            /*" -5718- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -5719- DISPLAY 'R4000-00 - PROBLEMAS UPDATE (HISCONPA)' */
                _.Display($"R4000-00 - PROBLEMAS UPDATE (HISCONPA)");

                /*" -5720- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5721- ELSE */
            }
            else
            {


                /*" -5722- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -5722- ADD 1 TO UP-HISCONPA. */
                    W.UP_HISCONPA.Value = W.UP_HISCONPA + 1;
                }

            }


        }

        [StopWatch]
        /*" R4000-00-UPDATE-HISCONPA-DB-UPDATE-1 */
        public void R4000_00_UPDATE_HISCONPA_DB_UPDATE_1()
        {
            /*" -5713- EXEC SQL UPDATE SEGUROS.HIST_CONT_PARCELVA SET COD_SUBGRUPO = :HISCONPA-COD-SUBGRUPO ,NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO ,SIT_REGISTRO = :HISCONPA-SIT-REGISTRO ,DTFATUR = :HISCONPA-DTFATUR:VIND-NULL01 WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND NUM_PARCELA = :HISCONPA-NUM-PARCELA AND NUM_TITULO = :HISCONPA-NUM-TITULO AND OCORR_HISTORICO = :HISCONPA-OCORR-HISTORICO END-EXEC. */

            var r4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1 = new R4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1()
            {
                HISCONPA_DTFATUR = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                HISCONPA_COD_SUBGRUPO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO.ToString(),
                HISCONPA_SIT_REGISTRO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO.ToString(),
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
                HISCONPA_NUM_CERTIFICADO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.ToString(),
                HISCONPA_OCORR_HISTORICO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
                HISCONPA_NUM_TITULO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO.ToString(),
            };

            R4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1.Execute(r4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-UPDATE-V0RCAPS-SECTION */
        private void R4100_00_UPDATE_V0RCAPS_SECTION()
        {
            /*" -5733- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", W.WABEND.WNR_EXEC_SQL);

            /*" -5736- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5740- MOVE SOR-NUM-TITULO TO RCAPS-NUM-TITULO. */
            _.Move(REG_SVA0141B.SOR_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -5750- PERFORM R4100_00_UPDATE_V0RCAPS_DB_UPDATE_1 */

            R4100_00_UPDATE_V0RCAPS_DB_UPDATE_1();

            /*" -5755- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -5756- DISPLAY 'R4100-00 - PROBLEMAS UPDATE (RCAPS)     ' */
                _.Display($"R4100-00 - PROBLEMAS UPDATE (RCAPS)     ");

                /*" -5757- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5758- ELSE */
            }
            else
            {


                /*" -5759- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -5759- ADD 1 TO UP-RCAPS. */
                    W.UP_RCAPS.Value = W.UP_RCAPS + 1;
                }

            }


        }

        [StopWatch]
        /*" R4100-00-UPDATE-V0RCAPS-DB-UPDATE-1 */
        public void R4100_00_UPDATE_V0RCAPS_DB_UPDATE_1()
        {
            /*" -5750- EXEC SQL UPDATE SEGUROS.RCAPS SET NUM_APOLICE = :PARCEHIS-NUM-APOLICE ,NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO ,NUM_PARCELA = :PARCEHIS-NUM-PARCELA ,CODIGO_PRODUTO = :ENDOSSOS-COD-PRODUTO WHERE NUM_TITULO = :RCAPS-NUM-TITULO END-EXEC. */

            var r4100_00_UPDATE_V0RCAPS_DB_UPDATE_1_Update1 = new R4100_00_UPDATE_V0RCAPS_DB_UPDATE_1_Update1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                ENDOSSOS_COD_PRODUTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.ToString(),
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            R4100_00_UPDATE_V0RCAPS_DB_UPDATE_1_Update1.Execute(r4100_00_UPDATE_V0RCAPS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-INSERT-RELATORI-SECTION */
        private void R9000_00_INSERT_RELATORI_SECTION()
        {
            /*" -5770- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", W.WABEND.WNR_EXEC_SQL);

            /*" -5773- DISPLAY WNR-EXEC-SQL */
            _.Display(W.WABEND.WNR_EXEC_SQL);

            /*" -5775- MOVE 'VA0139B' TO RELATORI-COD-USUARIO. */
            _.Move("VA0139B", RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);

            /*" -5777- MOVE SISTEMAS-DATA-MOV-ABERTO TO RELATORI-DATA-SOLICITACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);

            /*" -5779- MOVE 'VA' TO RELATORI-IDE-SISTEMA. */
            _.Move("VA", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -5781- MOVE 'VA0417B' TO RELATORI-COD-RELATORIO. */
            _.Move("VA0417B", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -5783- MOVE ZEROS TO RELATORI-NUM-COPIAS. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

            /*" -5785- MOVE ZEROS TO RELATORI-QUANTIDADE. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE);

            /*" -5787- MOVE SISTEMAS-DATA-MOV-ABERTO TO RELATORI-PERI-INICIAL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);

            /*" -5789- MOVE SISTEMAS-DATA-MOV-ABERTO TO RELATORI-PERI-FINAL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);

            /*" -5791- MOVE SISTEMAS-DATA-MOV-ABERTO TO RELATORI-DATA-REFERENCIA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

            /*" -5793- MOVE ZEROS TO RELATORI-MES-REFERENCIA. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA);

            /*" -5795- MOVE ZEROS TO RELATORI-ANO-REFERENCIA. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA);

            /*" -5797- MOVE ZEROS TO RELATORI-ORGAO-EMISSOR. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR);

            /*" -5799- MOVE ZEROS TO RELATORI-COD-FONTE. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE);

            /*" -5801- MOVE ZEROS TO RELATORI-COD-PRODUTOR. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR);

            /*" -5803- MOVE ZEROS TO RELATORI-RAMO-EMISSOR. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);

            /*" -5805- MOVE ZEROS TO RELATORI-COD-MODALIDADE. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_COD_MODALIDADE);

            /*" -5807- MOVE ZEROS TO RELATORI-COD-CONGENERE. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE);

            /*" -5809- MOVE ZEROS TO RELATORI-NUM-APOLICE. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);

            /*" -5811- MOVE ZEROS TO RELATORI-NUM-ENDOSSO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO);

            /*" -5813- MOVE ZEROS TO RELATORI-NUM-PARCELA. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);

            /*" -5815- MOVE ZEROS TO RELATORI-NUM-CERTIFICADO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);

            /*" -5817- MOVE ZEROS TO RELATORI-NUM-TITULO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);

            /*" -5819- MOVE ZEROS TO RELATORI-COD-SUBGRUPO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);

            /*" -5821- MOVE ZEROS TO RELATORI-COD-OPERACAO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);

            /*" -5823- MOVE ZEROS TO RELATORI-COD-PLANO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO);

            /*" -5825- MOVE ZEROS TO RELATORI-OCORR-HISTORICO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_OCORR_HISTORICO);

            /*" -5827- MOVE SPACES TO RELATORI-NUM-APOL-LIDER. */
            _.Move("", RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER);

            /*" -5829- MOVE SPACES TO RELATORI-ENDOS-LIDER. */
            _.Move("", RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER);

            /*" -5831- MOVE ZEROS TO RELATORI-NUM-PARC-LIDER. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARC_LIDER);

            /*" -5833- MOVE ZEROS TO RELATORI-NUM-SINISTRO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO);

            /*" -5835- MOVE SPACES TO RELATORI-NUM-SINI-LIDER. */
            _.Move("", RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER);

            /*" -5837- MOVE ZEROS TO RELATORI-NUM-ORDEM. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM);

            /*" -5839- MOVE ZEROS TO RELATORI-COD-MOEDA. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA);

            /*" -5841- MOVE SPACES TO RELATORI-TIPO-CORRECAO. */
            _.Move("", RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO);

            /*" -5843- MOVE SPACES TO RELATORI-IND-PREV-DEFINIT. */
            _.Move("", RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);

            /*" -5845- MOVE '0' TO RELATORI-SIT-REGISTRO. */
            _.Move("0", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -5847- MOVE SPACES TO RELATORI-IND-ANAL-RESUMO. */
            _.Move("", RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);

            /*" -5849- MOVE ZEROS TO RELATORI-COD-EMPRESA. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA);

            /*" -5851- MOVE ZEROS TO RELATORI-PERI-RENOVACAO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_PERI_RENOVACAO);

            /*" -5853- MOVE ZEROS TO RELATORI-PCT-AUMENTO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_PCT_AUMENTO);

            /*" -5859- MOVE ZEROS TO VIND-NULL01 VIND-NULL02 VIND-NULL03. */
            _.Move(0, VIND_NULL01, VIND_NULL02, VIND_NULL03);

            /*" -5944- PERFORM R9000_00_INSERT_RELATORI_DB_INSERT_1 */

            R9000_00_INSERT_RELATORI_DB_INSERT_1();

            /*" -5949- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -5950- DISPLAY 'R9000-00 - REGISTRO DUPLICADO(RELATORI)   ' */
                _.Display($"R9000-00 - REGISTRO DUPLICADO(RELATORI)   ");

                /*" -5951- ELSE */
            }
            else
            {


                /*" -5952- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5953- DISPLAY 'R9000-00 - PROBLEMAS NO INSERT(RELATORI)   ' */
                    _.Display($"R9000-00 - PROBLEMAS NO INSERT(RELATORI)   ");

                    /*" -5954- DISPLAY ' APOLICE    = ' PARCEHIS-NUM-APOLICE */
                    _.Display($" APOLICE    = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                    /*" -5955- DISPLAY ' ENDOSSO    = ' PARCEHIS-NUM-ENDOSSO */
                    _.Display($" ENDOSSO    = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                    /*" -5955- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R9000-00-INSERT-RELATORI-DB-INSERT-1 */
        public void R9000_00_INSERT_RELATORI_DB_INSERT_1()
        {
            /*" -5944- EXEC SQL INSERT INTO SEGUROS.RELATORIOS (COD_USUARIO ,DATA_SOLICITACAO ,IDE_SISTEMA ,COD_RELATORIO ,NUM_COPIAS ,QUANTIDADE ,PERI_INICIAL ,PERI_FINAL ,DATA_REFERENCIA ,MES_REFERENCIA ,ANO_REFERENCIA ,ORGAO_EMISSOR ,COD_FONTE ,COD_PRODUTOR ,RAMO_EMISSOR ,COD_MODALIDADE ,COD_CONGENERE ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,NUM_CERTIFICADO ,NUM_TITULO ,COD_SUBGRUPO ,COD_OPERACAO ,COD_PLANO ,OCORR_HISTORICO ,NUM_APOL_LIDER ,ENDOS_LIDER ,NUM_PARC_LIDER ,NUM_SINISTRO ,NUM_SINI_LIDER ,NUM_ORDEM ,COD_MOEDA ,TIPO_CORRECAO ,SIT_REGISTRO ,IND_PREV_DEFINIT ,IND_ANAL_RESUMO ,COD_EMPRESA ,PERI_RENOVACAO ,PCT_AUMENTO ,TIMESTAMP) VALUES (:RELATORI-COD-USUARIO ,:RELATORI-DATA-SOLICITACAO ,:RELATORI-IDE-SISTEMA ,:RELATORI-COD-RELATORIO ,:RELATORI-NUM-COPIAS ,:RELATORI-QUANTIDADE ,:RELATORI-PERI-INICIAL ,:RELATORI-PERI-FINAL ,:RELATORI-DATA-REFERENCIA ,:RELATORI-MES-REFERENCIA ,:RELATORI-ANO-REFERENCIA ,:RELATORI-ORGAO-EMISSOR ,:RELATORI-COD-FONTE ,:RELATORI-COD-PRODUTOR ,:RELATORI-RAMO-EMISSOR ,:RELATORI-COD-MODALIDADE ,:RELATORI-COD-CONGENERE ,:RELATORI-NUM-APOLICE ,:RELATORI-NUM-ENDOSSO ,:RELATORI-NUM-PARCELA ,:RELATORI-NUM-CERTIFICADO ,:RELATORI-NUM-TITULO ,:RELATORI-COD-SUBGRUPO ,:RELATORI-COD-OPERACAO ,:RELATORI-COD-PLANO ,:RELATORI-OCORR-HISTORICO ,:RELATORI-NUM-APOL-LIDER ,:RELATORI-ENDOS-LIDER ,:RELATORI-NUM-PARC-LIDER ,:RELATORI-NUM-SINISTRO ,:RELATORI-NUM-SINI-LIDER ,:RELATORI-NUM-ORDEM ,:RELATORI-COD-MOEDA ,:RELATORI-TIPO-CORRECAO ,:RELATORI-SIT-REGISTRO ,:RELATORI-IND-PREV-DEFINIT ,:RELATORI-IND-ANAL-RESUMO ,:RELATORI-COD-EMPRESA:VIND-NULL01 ,:RELATORI-PERI-RENOVACAO:VIND-NULL02 ,:RELATORI-PCT-AUMENTO:VIND-NULL03 , CURRENT TIMESTAMP) END-EXEC. */

            var r9000_00_INSERT_RELATORI_DB_INSERT_1_Insert1 = new R9000_00_INSERT_RELATORI_DB_INSERT_1_Insert1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_NUM_COPIAS = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.ToString(),
                RELATORI_QUANTIDADE = RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE.ToString(),
                RELATORI_PERI_INICIAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.ToString(),
                RELATORI_PERI_FINAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.ToString(),
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
                RELATORI_MES_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA.ToString(),
                RELATORI_ANO_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA.ToString(),
                RELATORI_ORGAO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR.ToString(),
                RELATORI_COD_FONTE = RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE.ToString(),
                RELATORI_COD_PRODUTOR = RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR.ToString(),
                RELATORI_RAMO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR.ToString(),
                RELATORI_COD_MODALIDADE = RELATORI.DCLRELATORIOS.RELATORI_COD_MODALIDADE.ToString(),
                RELATORI_COD_CONGENERE = RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
                RELATORI_COD_PLANO = RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO.ToString(),
                RELATORI_OCORR_HISTORICO = RELATORI.DCLRELATORIOS.RELATORI_OCORR_HISTORICO.ToString(),
                RELATORI_NUM_APOL_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.ToString(),
                RELATORI_ENDOS_LIDER = RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER.ToString(),
                RELATORI_NUM_PARC_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARC_LIDER.ToString(),
                RELATORI_NUM_SINISTRO = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO.ToString(),
                RELATORI_NUM_SINI_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER.ToString(),
                RELATORI_NUM_ORDEM = RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM.ToString(),
                RELATORI_COD_MOEDA = RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA.ToString(),
                RELATORI_TIPO_CORRECAO = RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO.ToString(),
                RELATORI_SIT_REGISTRO = RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO.ToString(),
                RELATORI_IND_PREV_DEFINIT = RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT.ToString(),
                RELATORI_IND_ANAL_RESUMO = RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO.ToString(),
                RELATORI_COD_EMPRESA = RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                RELATORI_PERI_RENOVACAO = RELATORI.DCLRELATORIOS.RELATORI_PERI_RENOVACAO.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
                RELATORI_PCT_AUMENTO = RELATORI.DCLRELATORIOS.RELATORI_PCT_AUMENTO.ToString(),
                VIND_NULL03 = VIND_NULL03.ToString(),
            };

            R9000_00_INSERT_RELATORI_DB_INSERT_1_Insert1.Execute(r9000_00_INSERT_RELATORI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5966- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -5967- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -5968- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -5969- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, W.WABEND.WSQLERRMC);

            /*" -5971- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -5974- CLOSE ENTRADA1 SAIDA01. */
            ENTRADA1.Close();
            SAIDA01.Close();

            /*" -5974- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5978- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -5978- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}