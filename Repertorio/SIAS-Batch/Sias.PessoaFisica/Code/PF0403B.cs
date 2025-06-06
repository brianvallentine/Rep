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
using Sias.PessoaFisica.DB2.PF0403B;

namespace Code
{
    public class PF0403B
    {
        public bool IsCall { get; set; }

        public PF0403B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * EMITIR RELATORIO COM MOVIMENTO DIARIA DE PAGAMENTO AVULSO E    *      */
        /*"      * CONTRIBUICAO ADICIONAL CEDIDO DA CEF.                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     05     * 06/05/2002 * LUIZ CARLOS  * PASSOU A NAO LISTAR   *      */
        /*"      *            *            *              * DOC DA CAPITALIZACAO A*      */
        /*"      *            *            *              * PEDIDO DO SR.         *      */
        /*"      *            *            *              * CLIFF ROBERTSON              */
        /*"      *            *            *              * PROCURE POR 020506.   *      */
        /*"      *            *            *              *                       *      */
        /*"      *     04     * 16/04/2002 * LUIZ CARLOS  * VALTOU A LISTAR OS DOC*      */
        /*"      *            *            *              * DA CAPITALIZACAO, A PE*      */
        /*"      *            *            *              * DIDO DA SRA.          *      */
        /*"      *            *            *              * KEDNA A. GUGELMIN     *      */
        /*"      *            *            *              * PROCURE POR 020416.   *      */
        /*"      *            *            *              *                       *      */
        /*"      *     03     * 09/01/2001 * LUIZ CARLOS  * PASSOU A NAO LISTAR   *      */
        /*"      *            *            *              * OS DOCUMENTOS DA CAIXA*      */
        /*"      *            *            *              * CAPITALIZACAO, CONFOR-*      */
        /*"      *            *            *              * ME SOLICITACAO DO SR. *      */
        /*"      *            *            *              * CLIFF ROBERT ALENCAR. *      */
        /*"      *            *            *              * PROCURE POR 020109.   *      */
        /*"      *            *            *              *                       *      */
        /*"      *     02     * 11/12/2001 * LUIZ CARLOS  * PASSOU A NAO LISTAR   *      */
        /*"      *            *            *              * OS RCAP BAIXADO (SOH  *      */
        /*"      *            *            *              * CAIXA SEGUROS).       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     * 10/12/2001 * LUIZ CARLOS  * PASSOU A LISTAR EM SE *      */
        /*"      *            *            *              * PARADO PGTO AVULSO E  *      */
        /*"      *            *            *              * CONTRIBUICAO ADICIONAL*      */
        /*"      ******************************************************************      */
        /*"      * ALTERACAO NO ACESSO A TABELA PRODUTOS_SIVPF EM FUNCAO DE       *      */
        /*"      * HAVER MAIS DE UMA LINHA PARA O MESMO COD_PRODUTO_SIVPF         *      */
        /*"      * (VIDA DA GENTE E MULTIPREMIADO SUPER)                          *      */
        /*"      * (PROCURAR POR 240703) - CHICON (PRODEXTER)            JUL/2003 *      */
        /*"      ******************************************************************      */
        /*"1     *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVSIGAT { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis MOVSIGAT
        {
            get
            {
                _.Move(REG_SIGAT, _MOVSIGAT); VarBasis.RedefinePassValue(REG_SIGAT, _MOVSIGAT, REG_SIGAT); return _MOVSIGAT;
            }
        }
        public FileBasis _RPF0403B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RPF0403B
        {
            get
            {
                _.Move(REG_IMPRESSAO, _RPF0403B); VarBasis.RedefinePassValue(REG_IMPRESSAO, _RPF0403B, REG_IMPRESSAO); return _RPF0403B;
            }
        }
        public SortBasis<PF0403B_REG_SPF0403B> SPF0403B { get; set; } = new SortBasis<PF0403B_REG_SPF0403B>(new PF0403B_REG_SPF0403B());
        /*"01   REG-SIGAT.*/
        public PF0403B_REG_SIGAT REG_SIGAT { get; set; } = new PF0403B_REG_SIGAT();
        public class PF0403B_REG_SIGAT : VarBasis
        {
            /*"     05       IDENTIFICACAO                        PIC  X(01).*/
            public StringBasis IDENTIFICACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"     05       NUMERO-DA-PROPOSTA                   PIC  9(14).*/
            public IntBasis NUMERO_DA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"     05       NM-ARQUIVO REDEFINES NUMERO-DA-PROPOSTA.*/
            private _REDEF_PF0403B_NM_ARQUIVO _nm_arquivo { get; set; }
            public _REDEF_PF0403B_NM_ARQUIVO NM_ARQUIVO
            {
                get { _nm_arquivo = new _REDEF_PF0403B_NM_ARQUIVO(); _.Move(NUMERO_DA_PROPOSTA, _nm_arquivo); VarBasis.RedefinePassValue(NUMERO_DA_PROPOSTA, _nm_arquivo, NUMERO_DA_PROPOSTA); _nm_arquivo.ValueChanged += () => { _.Move(_nm_arquivo, NUMERO_DA_PROPOSTA); }; return _nm_arquivo; }
                set { VarBasis.RedefinePassValue(value, _nm_arquivo, NUMERO_DA_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0403B_NM_ARQUIVO : VarBasis
            {
                /*"        10    NOME-ARQUIVO                         PIC  X(08).*/
                public StringBasis NOME_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"        10    FILLER                               PIC  X(06).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
                /*"     05       NUMERO-PARCELA                       PIC  9(04).*/

                public _REDEF_PF0403B_NM_ARQUIVO()
                {
                    NOME_ARQUIVO.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis NUMERO_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"     05       NUMERO-SICOB                         PIC  9(14).*/
            public IntBasis NUMERO_SICOB { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"     05       VALOR-PAGO                           PIC  9(13)V99*/
            public DoubleBasis VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"     05       DATA-QUITACAO                        PIC  9(08).*/
            public IntBasis DATA_QUITACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"     05       NUMERO-CERTIFICADO                   PIC  9(15).*/
            public IntBasis NUMERO_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"     05       CPF-CGC-PAGADOR                      PIC  9(14).*/
            public IntBasis CPF_CGC_PAGADOR { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"     05       DATA-NASCIMENTO                      PIC  9(008).*/
            public IntBasis DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     05       NOME-PAGADOR                         PIC  X(040).*/
            public StringBasis NOME_PAGADOR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"     05       CODIGO-PRODUTO                       PIC  9(003).*/
            public IntBasis CODIGO_PRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     05       NUMERO-TELEFONE                      PIC  X(011).*/
            public StringBasis NUMERO_TELEFONE { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
            /*"     05       IDENTIFICADOR-PAGTO                  PIC  X(001).*/
            public StringBasis IDENTIFICADOR_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     05       AGENCIA-RECEBEDORA                   PIC  9(004).*/
            public IntBasis AGENCIA_RECEBEDORA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     05       FILLER                               PIC  X(148).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "148", "X(148)."), @"");
            /*"01            REG-IMPRESSAO.*/
        }
        public PF0403B_REG_IMPRESSAO REG_IMPRESSAO { get; set; } = new PF0403B_REG_IMPRESSAO();
        public class PF0403B_REG_IMPRESSAO : VarBasis
        {
            /*"    05        REG-ASACODE         PIC X(001).*/
            public StringBasis REG_ASACODE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        REG-DETALHE         PIC X(132).*/
            public StringBasis REG_DETALHE { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
            /*"01            REG-SPF0403B.*/
        }
        public PF0403B_REG_SPF0403B REG_SPF0403B { get; set; } = new PF0403B_REG_SPF0403B();
        public class PF0403B_REG_SPF0403B : VarBasis
        {
            /*"     05       SPF-EMPRESA                          PIC  9(01).*/
            public IntBasis SPF_EMPRESA { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"     05       SPF-NUMERO-DA-PROPOSTA               PIC  9(14).*/
            public IntBasis SPF_NUMERO_DA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"     05       SPF-NUMERO-PARCELA                   PIC  9(04).*/
            public IntBasis SPF_NUMERO_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"     05       SPF-NUMERO-SICOB                     PIC  9(14).*/
            public IntBasis SPF_NUMERO_SICOB { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"     05       SPF-VALOR-PAGO                       PIC  9(13)V99*/
            public DoubleBasis SPF_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"     05       SPF-DATA-QUITACAO                    PIC  9(08).*/
            public IntBasis SPF_DATA_QUITACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"     05       SPF-NUMERO-CERTIFICADO               PIC  9(15).*/
            public IntBasis SPF_NUMERO_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"     05       SPF-CPF-CGC-PAGADOR                  PIC  9(14).*/
            public IntBasis SPF_CPF_CGC_PAGADOR { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"     05       SPF-DATA-NASCIMENTO                  PIC  9(008).*/
            public IntBasis SPF_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     05       SPF-NOME-PAGADOR                     PIC  X(040).*/
            public StringBasis SPF_NOME_PAGADOR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"     05       SPF-CODIGO-PRODUTO                   PIC  9(003).*/
            public IntBasis SPF_CODIGO_PRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     05       SPF-NUMERO-TELEFONE                  PIC  X(011).*/
            public StringBasis SPF_NUMERO_TELEFONE { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
            /*"     05       SPF-IDENTIFICADOR-PAGTO              PIC  X(001).*/
            public StringBasis SPF_IDENTIFICADOR_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     05       SPF-AGENCIA-RECEBEDORA               PIC  9(004).*/
            public IntBasis SPF_AGENCIA_RECEBEDORA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77            WHOST-AGENCIA       PIC S9(04) COMP.*/
        public IntBasis WHOST_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V1SIST-DTMOVABE     PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTHOJE       PIC  X(10).*/
        public StringBasis V1SIST_DTHOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-QTDIAS       PIC S9(09)   COMP.*/
        public IntBasis V1SIST_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0ESCN-NOMEESC      PIC  X(40).*/
        public StringBasis V0ESCN_NOMEESC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0AGEN-NOMEAGE      PIC  X(40).*/
        public StringBasis V0AGEN_NOMEAGE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  VIND-RCAPS-NUM-PARCELA           PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_RCAPS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WORK-AREA.*/
        public PF0403B_WORK_AREA WORK_AREA { get; set; } = new PF0403B_WORK_AREA();
        public class PF0403B_WORK_AREA : VarBasis
        {
            /*"    05        DATA-SQL.*/
            public PF0403B_DATA_SQL DATA_SQL { get; set; } = new PF0403B_DATA_SQL();
            public class PF0403B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-TIME             PIC  X(008).*/
            }
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-TIME-R           REDEFINES WS-TIME.*/
            private _REDEF_PF0403B_WS_TIME_R _ws_time_r { get; set; }
            public _REDEF_PF0403B_WS_TIME_R WS_TIME_R
            {
                get { _ws_time_r = new _REDEF_PF0403B_WS_TIME_R(); _.Move(WS_TIME, _ws_time_r); VarBasis.RedefinePassValue(WS_TIME, _ws_time_r, WS_TIME); _ws_time_r.ValueChanged += () => { _.Move(_ws_time_r, WS_TIME); }; return _ws_time_r; }
                set { VarBasis.RedefinePassValue(value, _ws_time_r, WS_TIME); }
            }  //Redefines
            public class _REDEF_PF0403B_WS_TIME_R : VarBasis
            {
                /*"      10      WS-HOR              PIC  9(002).*/
                public IntBasis WS_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-MIN              PIC  9(002).*/
                public IntBasis WS_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-SEG              PIC  9(002).*/
                public IntBasis WS_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  9(002).*/
                public IntBasis FILLER_4 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA-SORT.*/

                public _REDEF_PF0403B_WS_TIME_R()
                {
                    WS_HOR.ValueChanged += OnValueChanged;
                    WS_MIN.ValueChanged += OnValueChanged;
                    WS_SEG.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }
            public PF0403B_WS_DATA_SORT WS_DATA_SORT { get; set; } = new PF0403B_WS_DATA_SORT();
            public class PF0403B_WS_DATA_SORT : VarBasis
            {
                /*"      10      WS-DIA-SORT         PIC  9(002).*/
                public IntBasis WS_DIA_SORT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-MES-SORT         PIC  9(002).*/
                public IntBasis WS_MES_SORT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-ANO-SORT         PIC  9(004).*/
                public IntBasis WS_ANO_SORT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-DATA.*/
            }
            public PF0403B_WS_DATA WS_DATA { get; set; } = new PF0403B_WS_DATA();
            public class PF0403B_WS_DATA : VarBasis
            {
                /*"      10      WS-DIA              PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-BAR1             PIC  X(001).*/
                public StringBasis WS_BAR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES              PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-BAR2             PIC  X(001).*/
                public StringBasis WS_BAR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-ANO              PIC  9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-IDE-PGTO-ANT     PIC  X(001).*/
            }
            public StringBasis WS_IDE_PGTO_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        WS-EMPRESA-ANT      PIC  9(001).*/
            public IntBasis WS_EMPRESA_ANT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05        WS-AGENCIA-ANT      PIC  9(004).*/
            public IntBasis WS_AGENCIA_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        WFIM-MOVSIGAT    PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_MOVSIGAT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-SORT           PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-LINHA            PIC  9(006) VALUE 90.*/
            public IntBasis AC_LINHA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"), 90);
            /*"    05        AC-PAGINA           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-QTDE-FONTE       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_QTDE_FONTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-QTDE-ESCNEG      PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_QTDE_ESCNEG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-QTDE-AGENCIA     PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_QTDE_AGENCIA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-QTDE-TOTAL       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_QTDE_TOTAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-VAL-FONTE        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VAL_FONTE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-VAL-ESCNEG       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VAL_ESCNEG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-VAL-AGENCIA      PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VAL_AGENCIA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-VAL-TOTAL        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VAL_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        AC-IMPRESSOS        PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WABEND.*/
            public PF0403B_WABEND WABEND { get; set; } = new PF0403B_WABEND();
            public class PF0403B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             ' PF0403B'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" PF0403B");
                /*"      10      FILLER              PIC  X(026) VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(005) VALUE '00000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"00000");
                /*"      10      FILLER              PIC  X(013) VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05        TRACO.*/
            }
            public PF0403B_TRACO TRACO { get; set; } = new PF0403B_TRACO();
            public class PF0403B_TRACO : VarBasis
            {
                /*"      10      FILLER              PIC  X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"    05        BRANCO.*/
            }
            public PF0403B_BRANCO BRANCO { get; set; } = new PF0403B_BRANCO();
            public class PF0403B_BRANCO : VarBasis
            {
                /*"      10      FILLER              PIC  X(132) VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"    05        LC01.*/
            }
            public PF0403B_LC01 LC01 { get; set; } = new PF0403B_LC01();
            public class PF0403B_LC01 : VarBasis
            {
                /*"      10      FILLER              PIC  X(009) VALUE 'RPF0403B'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"RPF0403B");
                /*"      10      FILLER              PIC  X(049) VALUE  SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"");
                /*"      10      FILLER              PIC  X(028) VALUE       'C A I X A    S E G U R O S '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"C A I X A    S E G U R O S ");
                /*"      10      FILLER              PIC  X(031) VALUE  SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"");
                /*"      10      FILLER              PIC  X(008) VALUE 'PAGINA: '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PAGINA: ");
                /*"      10      LC01-PAGINA         PIC  ZZZZ999.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ999."));
                /*"    05        LC02.*/
            }
            public PF0403B_LC02 LC02 { get; set; } = new PF0403B_LC02();
            public class PF0403B_LC02 : VarBasis
            {
                /*"      10      FILLER              PIC  X(117) VALUE SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"      10      FILLER              PIC  X(005) VALUE 'DATA '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA ");
                /*"      10      LC02-DIA            PIC  9(02).*/
                public IntBasis LC02_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC02-MES            PIC  9(02).*/
                public IntBasis LC02_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC02-ANO            PIC  9(04).*/
                public IntBasis LC02_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05        LC03.*/
            }
            public PF0403B_LC03 LC03 { get; set; } = new PF0403B_LC03();
            public class PF0403B_LC03 : VarBasis
            {
                /*"      10      FILLER              PIC  X(052) VALUE SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"");
                /*"      10      LC03-DESCR-RELA     PIC  X(40).*/
                public StringBasis LC03_DESCR_RELA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      FILLER              PIC  X(025) VALUE SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"      10      FILLER              PIC  X(005) VALUE 'HORA '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"HORA ");
                /*"      10      LC03-HOR            PIC  9(02).*/
                public IntBasis LC03_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"      10      LC03-MIN            PIC  9(02).*/
                public IntBasis LC03_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"      10      LC03-SEG            PIC  9(02).*/
                public IntBasis LC03_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05        LC04.*/
            }
            public PF0403B_LC04 LC04 { get; set; } = new PF0403B_LC04();
            public class PF0403B_LC04 : VarBasis
            {
                /*"      10      FILLER              PIC X(20) VALUE      'EMPRESA PROCESSADA: '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"EMPRESA PROCESSADA: ");
                /*"      10      LC04-NMEMPRESA      PIC X(60).*/
                public StringBasis LC04_NMEMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
                /*"    05        LC05.*/
            }
            public PF0403B_LC05 LC05 { get; set; } = new PF0403B_LC05();
            public class PF0403B_LC05 : VarBasis
            {
                /*"      10      FILLER              PIC X(09) VALUE             'AGENCIA: '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"AGENCIA: ");
                /*"      10      LC05-CDAGENCIA      PIC 9999.*/
                public IntBasis LC05_CDAGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"      10      FILLER              PIC X(03) VALUE ' - '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"      10      LC05-NMAGENCIA      PIC X(60).*/
                public StringBasis LC05_NMAGENCIA { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
                /*"    05        LC06.*/
            }
            public PF0403B_LC06 LC06 { get; set; } = new PF0403B_LC06();
            public class PF0403B_LC06 : VarBasis
            {
                /*"      10      FILLER              PIC X(03) VALUE  SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      FILLER              PIC X(08) VALUE 'PROPOSTA'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"PROPOSTA");
                /*"      10      FILLER              PIC X(04) VALUE  SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"      10      FILLER              PIC X(08) VALUE 'PARCELA'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"PARCELA");
                /*"      10      FILLER              PIC X(03) VALUE  SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      FILLER              PIC X(09) VALUE 'NUM.SICOB'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"NUM.SICOB");
                /*"      10      FILLER              PIC X(08) VALUE  SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"      10      FILLER              PIC X(10) VALUE 'VALOR PAGO'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"VALOR PAGO");
                /*"      10      FILLER              PIC X(03) VALUE  SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      FILLER              PIC X(11) VALUE 'DT.QUITACAO'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"DT.QUITACAO");
                /*"      10      FILLER              PIC X(05) VALUE  SPACE.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"      10      FILLER              PIC X(11) VALUE 'CERTIFICADO'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CERTIFICADO");
                /*"      10      FILLER              PIC X(06) VALUE  SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
                /*"      10      FILLER              PIC X(39) VALUE              'NOME DA PESSOA QUE REALIZOU O PAGAMENTO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "39", "X(39)"), @"NOME DA PESSOA QUE REALIZOU O PAGAMENTO");
                /*"    05        LC07.*/
            }
            public PF0403B_LC07 LC07 { get; set; } = new PF0403B_LC07();
            public class PF0403B_LC07 : VarBasis
            {
                /*"      10      FILLER              PIC X(072) VALUE  SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
                /*"      10      FILLER              PIC X(12)  VALUE              'CPF  /  CGC'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"CPF  /  CGC");
                /*"      10      FILLER              PIC X(03)  VALUE  SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      FILLER              PIC X(24)  VALUE              '  DESCRICAO PRODUTO PAGO'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"  DESCRICAO PRODUTO PAGO");
                /*"    05        LD01.*/
            }
            public PF0403B_LD01 LD01 { get; set; } = new PF0403B_LD01();
            public class PF0403B_LD01 : VarBasis
            {
                /*"      10      LD01-NRPROPOSTA     PIC 9(14).*/
                public IntBasis LD01_NRPROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD01-NRPARCELA      PIC ZZ99.*/
                public IntBasis LD01_NRPARCELA { get; set; } = new IntBasis(new PIC("9", "4", "ZZ99."));
                /*"      10      FILLER              PIC X(05)   VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"      10      LD01-NRSICOB        PIC 9(14).*/
                public IntBasis LD01_NRSICOB { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD01-VLPAGO         PIC ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLPAGO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(03)   VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      LD01-DTQITBCO       PIC X(10).*/
                public StringBasis LD01_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"      10      FILLER              PIC X(04)   VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"      10      LD01-NRCERTIFICADO  PIC 9(15).*/
                public IntBasis LD01_NRCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"      10      FILLER              PIC X(04)   VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"      10      LD01-NOME           PIC X(40).*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    05        LD02.*/
            }
            public PF0403B_LD02 LD02 { get; set; } = new PF0403B_LD02();
            public class PF0403B_LD02 : VarBasis
            {
                /*"      10      FILLER              PIC X(071)   VALUE SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "71", "X(071)"), @"");
                /*"      10      LD02-CGCCPF         PIC 9(14).*/
                public IntBasis LD02_CGCCPF { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
                /*"      10      FILLER              PIC X(04)   VALUE SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"      10      LD02-NMPRODUTO      PIC X(40).*/
                public StringBasis LD02_NMPRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    05        W-RCAPS             PIC 9        VALUE  ZERO.*/
            }

            public SelectorBasis W_RCAPS { get; set; } = new SelectorBasis("9", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88      RCAP-PENDENTE                    VALUE  0. */
							new SelectorItemBasis("RCAP_PENDENTE", "0"),
							/*" 88      RCAP-BAIXADO                     VALUE  1. */
							new SelectorItemBasis("RCAP_BAIXADO", "1"),
							/*" 88      RCAP-CANCELADO                   VALUE  2. */
							new SelectorItemBasis("RCAP_CANCELADO", "2")
                }
            };

        }


        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVSIGAT_FILE_NAME_P, string RPF0403B_FILE_NAME_P, string SPF0403B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVSIGAT.SetFile(MOVSIGAT_FILE_NAME_P);
                RPF0403B.SetFile(RPF0403B_FILE_NAME_P);
                SPF0403B.SetFile(SPF0403B_FILE_NAME_P);

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
            /*" -364- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -364- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -365- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -366- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -369- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -370- DISPLAY '*               PROGRAMA PF0403B               *' . */
            _.Display($"*               PROGRAMA PF0403B               *");

            /*" -371- DISPLAY '* RELAT MOV DIARIA PAGTO AVULSO E CONTR SINDIC *' . */
            _.Display($"* RELAT MOV DIARIA PAGTO AVULSO E CONTR SINDIC *");

            /*" -372- DISPLAY '*           VERSAO:  05 - 21/07/2014           *' . */
            _.Display($"*           VERSAO:  05 - 21/07/2014           *");

            /*" -373- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -382- DISPLAY '*  PF0403B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0403B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -382- PERFORM R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -390- PERFORM R0100-00-INICIALIZA. */

            R0100_00_INICIALIZA_SECTION();

            /*" -391- IF WFIM-MOVSIGAT EQUAL 'S' */

            if (WORK_AREA.WFIM_MOVSIGAT == "S")
            {

                /*" -392- PERFORM R9000-00-CLOSE-ARQUIVOS */

                R9000_00_CLOSE_ARQUIVOS_SECTION();

                /*" -394- PERFORM R9800-00-ENCERRA-SEM-SOLIC. */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();
            }


            /*" -396- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -409- SORT SPF0403B ON ASCENDING KEY SPF-EMPRESA , SPF-IDENTIFICADOR-PAGTO, SPF-AGENCIA-RECEBEDORA, SPF-CPF-CGC-PAGADOR , SPF-NUMERO-PARCELA , SPF-NUMERO-CERTIFICADO INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-IMPRIME THRU R0020-FIM. */
            SORT_RETURN.Value = SPF0403B.Sort("SPF-EMPRESA,,,SPF-IDENTIFICADOR-PAGTO,,SPF-AGENCIA-RECEBEDORA,,SPF-CPF-CGC-PAGADOR,,,SPF-NUMERO-PARCELA,,,SPF-NUMERO-CERTIFICADO", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_IMPRIME_SECTION());

            /*" -412- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -413- DISPLAY '*** PF0403B *** PROBLEMAS NO SORT ' */
                _.Display($"*** PF0403B *** PROBLEMAS NO SORT ");

                /*" -414- DISPLAY '*** PF0403B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** PF0403B *** SORT-RETURN = {SORT_RETURN}");

                /*" -415- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -415- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -421- MOVE 'R0000' TO WNR-EXEC-SQL. */
            _.Move("R0000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -423- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -424- DISPLAY '*** PF0403B - ' */
            _.Display($"*** PF0403B - ");

            /*" -425- DISPLAY 'LIDOS PGTO AVULSO        ' AC-LIDOS. */
            _.Display($"LIDOS PGTO AVULSO        {WORK_AREA.AC_LIDOS}");

            /*" -427- DISPLAY 'IMPRESSOS                ' AC-IMPRESSOS. */
            _.Display($"IMPRESSOS                {WORK_AREA.AC_IMPRESSOS}");

            /*" -428- DISPLAY '*** PF0403B - TERMINO NORMAL ***' */
            _.Display($"*** PF0403B - TERMINO NORMAL ***");

            /*" -428- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -441- MOVE 'R0010' TO WNR-EXEC-SQL. */
            _.Move("R0010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -442- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-MOVSIGAT EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_MOVSIGAT == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-IMPRIME-SECTION */
        private void R0020_00_IMPRIME_SECTION()
        {
            /*" -455- MOVE 'R0020' TO WNR-EXEC-SQL. */
            _.Move("R0020", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -457- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

            /*" -466- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -466- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-INICIALIZA-SECTION */
        private void R0100_00_INICIALIZA_SECTION()
        {
            /*" -479- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -489- PERFORM R0100_00_INICIALIZA_DB_SELECT_1 */

            R0100_00_INICIALIZA_DB_SELECT_1();

            /*" -493- IF SQLCODE EQUAL 00 NEXT SENTENCE */

            if (DB.SQLCODE == 00)
            {

                /*" -494- ELSE */
            }
            else
            {


                /*" -495- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -496- DISPLAY 'PF0403B - SISTEMA PF NAO ESTA CADASTRADO' */
                    _.Display($"PF0403B - SISTEMA PF NAO ESTA CADASTRADO");

                    /*" -497- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -498- ELSE */
                }
                else
                {


                    /*" -499- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -500- DISPLAY 'PF0403B - PROBLEMAS NO ACESSO A TABELA SISTEMAS' */
                        _.Display($"PF0403B - PROBLEMAS NO ACESSO A TABELA SISTEMAS");

                        /*" -502- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -503- MOVE V1SIST-DTHOJE TO DATA-SQL */
            _.Move(V1SIST_DTHOJE, WORK_AREA.DATA_SQL);

            /*" -504- MOVE ANO-SQL TO LC02-ANO */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.LC02.LC02_ANO);

            /*" -505- MOVE MES-SQL TO LC02-MES */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.LC02.LC02_MES);

            /*" -507- MOVE DIA-SQL TO LC02-DIA */
            _.Move(WORK_AREA.DATA_SQL.DIA_SQL, WORK_AREA.LC02.LC02_DIA);

            /*" -508- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

            /*" -509- MOVE WS-HOR TO LC03-HOR */
            _.Move(WORK_AREA.WS_TIME_R.WS_HOR, WORK_AREA.LC03.LC03_HOR);

            /*" -510- MOVE WS-MIN TO LC03-MIN */
            _.Move(WORK_AREA.WS_TIME_R.WS_MIN, WORK_AREA.LC03.LC03_MIN);

            /*" -512- MOVE WS-SEG TO LC03-SEG */
            _.Move(WORK_AREA.WS_TIME_R.WS_SEG, WORK_AREA.LC03.LC03_SEG);

            /*" -513- PERFORM R8000-00-OPEN-ARQUIVOS */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -513- PERFORM R8500-00-LER-MOV-SIGAT. */

            R8500_00_LER_MOV_SIGAT_SECTION();

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-DB-SELECT-1 */
        public void R0100_00_INICIALIZA_DB_SELECT_1()
        {
            /*" -489- EXEC SQL SELECT DTMOVABE, CURRENT DATE, DAYS (CURRENT DATE) INTO :V1SIST-DTMOVABE, :V1SIST-DTHOJE, :V1SIST-QTDIAS FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'PF' WITH UR END-EXEC. */

            var r0100_00_INICIALIZA_DB_SELECT_1_Query1 = new R0100_00_INICIALIZA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_INICIALIZA_DB_SELECT_1_Query1.Execute(r0100_00_INICIALIZA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTHOJE, V1SIST_DTHOJE);
                _.Move(executed_1.V1SIST_QTDIAS, V1SIST_QTDIAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -527- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -528- IF SPF-EMPRESA EQUAL 3 */

            if (REG_SPF0403B.SPF_EMPRESA == 3)
            {

                /*" -534- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -537- MOVE NUMERO-SICOB TO RCAPS-NUM-CERTIFICADO OF DCLRCAPS. */
            _.Move(REG_SIGAT.NUMERO_SICOB, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -539- MOVE ZERO TO W-RCAPS. */
            _.Move(0, WORK_AREA.W_RCAPS);

            /*" -540- IF SPF-EMPRESA EQUAL 1 */

            if (REG_SPF0403B.SPF_EMPRESA == 1)
            {

                /*" -542- PERFORM R1100-00-SELECT-RCAPS */

                R1100_00_SELECT_RCAPS_SECTION();

                /*" -543- IF RCAP-PENDENTE */

                if (WORK_AREA.W_RCAPS["RCAP_PENDENTE"])
                {

                    /*" -546- MOVE NUMERO-DA-PROPOSTA TO RCAPS-NUM-CERTIFICADO OF DCLRCAPS */
                    _.Move(REG_SIGAT.NUMERO_DA_PROPOSTA, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

                    /*" -548- MOVE ZERO TO W-RCAPS */
                    _.Move(0, WORK_AREA.W_RCAPS);

                    /*" -550- PERFORM R1100-00-SELECT-RCAPS */

                    R1100_00_SELECT_RCAPS_SECTION();

                    /*" -551- IF RCAP-BAIXADO */

                    if (WORK_AREA.W_RCAPS["RCAP_BAIXADO"])
                    {

                        /*" -552- IF VIND-RCAPS-NUM-PARCELA LESS ZERO */

                        if (VIND_RCAPS_NUM_PARCELA < 00)
                        {

                            /*" -553- MOVE ZEROS TO RCAPS-NUM-PARCELA OF DCLRCAPS */
                            _.Move(0, RCAPS.DCLRCAPS.RCAPS_NUM_PARCELA);

                            /*" -555- END-IF */
                        }


                        /*" -557- IF RCAPS-NUM-PARCELA OF DCLRCAPS EQUAL NUMERO-PARCELA NEXT SENTENCE */

                        if (RCAPS.DCLRCAPS.RCAPS_NUM_PARCELA == REG_SIGAT.NUMERO_PARCELA)
                        {

                            /*" -558- ELSE */
                        }
                        else
                        {


                            /*" -560- MOVE ZERO TO W-RCAPS. */
                            _.Move(0, WORK_AREA.W_RCAPS);
                        }

                    }

                }

            }


            /*" -561- IF RCAP-PENDENTE */

            if (WORK_AREA.W_RCAPS["RCAP_PENDENTE"])
            {

                /*" -562- MOVE NUMERO-DA-PROPOSTA TO SPF-NUMERO-DA-PROPOSTA */
                _.Move(REG_SIGAT.NUMERO_DA_PROPOSTA, REG_SPF0403B.SPF_NUMERO_DA_PROPOSTA);

                /*" -563- MOVE NUMERO-PARCELA TO SPF-NUMERO-PARCELA */
                _.Move(REG_SIGAT.NUMERO_PARCELA, REG_SPF0403B.SPF_NUMERO_PARCELA);

                /*" -564- MOVE NUMERO-SICOB TO SPF-NUMERO-SICOB */
                _.Move(REG_SIGAT.NUMERO_SICOB, REG_SPF0403B.SPF_NUMERO_SICOB);

                /*" -565- MOVE VALOR-PAGO TO SPF-VALOR-PAGO */
                _.Move(REG_SIGAT.VALOR_PAGO, REG_SPF0403B.SPF_VALOR_PAGO);

                /*" -566- MOVE DATA-QUITACAO TO SPF-DATA-QUITACAO */
                _.Move(REG_SIGAT.DATA_QUITACAO, REG_SPF0403B.SPF_DATA_QUITACAO);

                /*" -567- MOVE NUMERO-CERTIFICADO TO SPF-NUMERO-CERTIFICADO */
                _.Move(REG_SIGAT.NUMERO_CERTIFICADO, REG_SPF0403B.SPF_NUMERO_CERTIFICADO);

                /*" -568- MOVE CPF-CGC-PAGADOR TO SPF-CPF-CGC-PAGADOR */
                _.Move(REG_SIGAT.CPF_CGC_PAGADOR, REG_SPF0403B.SPF_CPF_CGC_PAGADOR);

                /*" -569- MOVE DATA-NASCIMENTO TO SPF-DATA-NASCIMENTO */
                _.Move(REG_SIGAT.DATA_NASCIMENTO, REG_SPF0403B.SPF_DATA_NASCIMENTO);

                /*" -570- MOVE NOME-PAGADOR TO SPF-NOME-PAGADOR */
                _.Move(REG_SIGAT.NOME_PAGADOR, REG_SPF0403B.SPF_NOME_PAGADOR);

                /*" -571- MOVE CODIGO-PRODUTO TO SPF-CODIGO-PRODUTO */
                _.Move(REG_SIGAT.CODIGO_PRODUTO, REG_SPF0403B.SPF_CODIGO_PRODUTO);

                /*" -572- MOVE NUMERO-TELEFONE TO SPF-NUMERO-TELEFONE */
                _.Move(REG_SIGAT.NUMERO_TELEFONE, REG_SPF0403B.SPF_NUMERO_TELEFONE);

                /*" -573- MOVE IDENTIFICADOR-PAGTO TO SPF-IDENTIFICADOR-PAGTO */
                _.Move(REG_SIGAT.IDENTIFICADOR_PAGTO, REG_SPF0403B.SPF_IDENTIFICADOR_PAGTO);

                /*" -575- MOVE AGENCIA-RECEBEDORA TO SPF-AGENCIA-RECEBEDORA */
                _.Move(REG_SIGAT.AGENCIA_RECEBEDORA, REG_SPF0403B.SPF_AGENCIA_RECEBEDORA);

                /*" -575- RELEASE REG-SPF0403B. */
                SPF0403B.Release(REG_SPF0403B);
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -579- PERFORM R8500-00-LER-MOV-SIGAT. */

            R8500_00_LER_MOV_SIGAT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-RCAPS-SECTION */
        private void R1100_00_SELECT_RCAPS_SECTION()
        {
            /*" -591- MOVE 'R1100' TO WNR-EXEC-SQL. */
            _.Move("R1100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -599- PERFORM R1100_00_SELECT_RCAPS_DB_SELECT_1 */

            R1100_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -602- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -604- IF RCAPS-SIT-REGISTRO EQUAL '0' NEXT SENTENCE */

                if (RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO == "0")
                {

                    /*" -605- ELSE */
                }
                else
                {


                    /*" -606- IF RCAPS-SIT-REGISTRO EQUAL '1' */

                    if (RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO == "1")
                    {

                        /*" -607- MOVE 1 TO W-RCAPS */
                        _.Move(1, WORK_AREA.W_RCAPS);

                        /*" -608- ELSE */
                    }
                    else
                    {


                        /*" -609- MOVE 2 TO W-RCAPS */
                        _.Move(2, WORK_AREA.W_RCAPS);

                        /*" -610- ELSE */
                    }

                }

            }
            else
            {


                /*" -612- IF SQLCODE EQUAL 100 OR -811 NEXT SENTENCE */

                if (DB.SQLCODE.In("100", "-811"))
                {

                    /*" -613- ELSE */
                }
                else
                {


                    /*" -613- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R1100_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -599- EXEC SQL SELECT SIT_REGISTRO, NUM_PARCELA INTO :DCLRCAPS.RCAPS-SIT-REGISTRO, :DCLRCAPS.RCAPS-NUM-PARCELA:VIND-RCAPS-NUM-PARCELA FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :DCLRCAPS.RCAPS-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r1100_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R1100_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1100_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_NUM_PARCELA, RCAPS.DCLRCAPS.RCAPS_NUM_PARCELA);
                _.Move(executed_1.VIND_RCAPS_NUM_PARCELA, VIND_RCAPS_NUM_PARCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -628- MOVE 'R2000' TO WNR-EXEC-SQL. */
            _.Move("R2000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -629- IF SPF-IDENTIFICADOR-PAGTO EQUAL '1' */

            if (REG_SPF0403B.SPF_IDENTIFICADOR_PAGTO == "1")
            {

                /*" -631- MOVE 'RELACAO  DE  PAGAMENTO  AVULSO  DO  DIA' TO LC03-DESCR-RELA */
                _.Move("RELACAO  DE  PAGAMENTO  AVULSO  DO  DIA", WORK_AREA.LC03.LC03_DESCR_RELA);

                /*" -632- ELSE */
            }
            else
            {


                /*" -633- IF SPF-IDENTIFICADOR-PAGTO EQUAL '2' */

                if (REG_SPF0403B.SPF_IDENTIFICADOR_PAGTO == "2")
                {

                    /*" -635- MOVE 'RELACAO DE CONTRIBUICAO ADICIONAL DO DIA' TO LC03-DESCR-RELA */
                    _.Move("RELACAO DE CONTRIBUICAO ADICIONAL DO DIA", WORK_AREA.LC03.LC03_DESCR_RELA);

                    /*" -636- ELSE */
                }
                else
                {


                    /*" -638- MOVE ALL '*' TO LC03-DESCR-RELA. */
                    _.MoveAll("*", WORK_AREA.LC03.LC03_DESCR_RELA);
                }

            }


            /*" -640- MOVE SPF-IDENTIFICADOR-PAGTO TO WS-IDE-PGTO-ANT. */
            _.Move(REG_SPF0403B.SPF_IDENTIFICADOR_PAGTO, WORK_AREA.WS_IDE_PGTO_ANT);

            /*" -642- PERFORM R2050-00-PROCESSA-EMPRESA UNTIL SPF-IDENTIFICADOR-PAGTO NOT EQUAL WS-IDE-PGTO-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SPF0403B.SPF_IDENTIFICADOR_PAGTO != WORK_AREA.WS_IDE_PGTO_ANT || WORK_AREA.WFIM_SORT == "S"))
            {

                R2050_00_PROCESSA_EMPRESA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2050-00-PROCESSA-EMPRESA-SECTION */
        private void R2050_00_PROCESSA_EMPRESA_SECTION()
        {
            /*" -654- MOVE 'R2050' TO WNR-EXEC-SQL. */
            _.Move("R2050", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -655- IF SPF-EMPRESA EQUAL 1 */

            if (REG_SPF0403B.SPF_EMPRESA == 1)
            {

                /*" -656- MOVE 'CAIXA SEGUROS' TO LC04-NMEMPRESA */
                _.Move("CAIXA SEGUROS", WORK_AREA.LC04.LC04_NMEMPRESA);

                /*" -657- ELSE */
            }
            else
            {


                /*" -658- IF SPF-EMPRESA EQUAL 2 */

                if (REG_SPF0403B.SPF_EMPRESA == 2)
                {

                    /*" -659- MOVE 'CAIXA VIDA & PREVIDENCIA' TO LC04-NMEMPRESA */
                    _.Move("CAIXA VIDA & PREVIDENCIA", WORK_AREA.LC04.LC04_NMEMPRESA);

                    /*" -660- ELSE */
                }
                else
                {


                    /*" -662- MOVE 'CAIXA CAPITALIZACAO' TO LC04-NMEMPRESA. */
                    _.Move("CAIXA CAPITALIZACAO", WORK_AREA.LC04.LC04_NMEMPRESA);
                }

            }


            /*" -664- MOVE SPF-EMPRESA TO WS-EMPRESA-ANT. */
            _.Move(REG_SPF0403B.SPF_EMPRESA, WORK_AREA.WS_EMPRESA_ANT);

            /*" -673- PERFORM R2100-00-PROCESSA-EMPRESA UNTIL SPF-IDENTIFICADOR-PAGTO NOT EQUAL WS-IDE-PGTO-ANT OR SPF-EMPRESA NOT EQUAL WS-EMPRESA-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SPF0403B.SPF_IDENTIFICADOR_PAGTO != WORK_AREA.WS_IDE_PGTO_ANT || REG_SPF0403B.SPF_EMPRESA != WORK_AREA.WS_EMPRESA_ANT || WORK_AREA.WFIM_SORT == "S"))
            {

                R2100_00_PROCESSA_EMPRESA_SECTION();
            }

            /*" -673- MOVE 90 TO AC-LINHA. */
            _.Move(90, WORK_AREA.AC_LINHA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-EMPRESA-SECTION */
        private void R2100_00_PROCESSA_EMPRESA_SECTION()
        {
            /*" -687- MOVE 'R2100' TO WNR-EXEC-SQL. */
            _.Move("R2100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -691- MOVE SPF-AGENCIA-RECEBEDORA TO WS-AGENCIA-ANT, WHOST-AGENCIA , LC05-CDAGENCIA. */
            _.Move(REG_SPF0403B.SPF_AGENCIA_RECEBEDORA, WORK_AREA.WS_AGENCIA_ANT, WHOST_AGENCIA, WORK_AREA.LC05.LC05_CDAGENCIA);

            /*" -693- PERFORM R2700-00-SELECT-V0AGENCIACEF. */

            R2700_00_SELECT_V0AGENCIACEF_SECTION();

            /*" -695- MOVE V0AGEN-NOMEAGE TO LC05-NMAGENCIA. */
            _.Move(V0AGEN_NOMEAGE, WORK_AREA.LC05.LC05_NMAGENCIA);

            /*" -705- PERFORM R2300-00-PROCESSA-AGENCIA UNTIL SPF-IDENTIFICADOR-PAGTO NOT EQUAL WS-IDE-PGTO-ANT OR SPF-EMPRESA NOT EQUAL WS-EMPRESA-ANT OR SPF-AGENCIA-RECEBEDORA NOT EQUAL WS-AGENCIA-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SPF0403B.SPF_IDENTIFICADOR_PAGTO != WORK_AREA.WS_IDE_PGTO_ANT || REG_SPF0403B.SPF_EMPRESA != WORK_AREA.WS_EMPRESA_ANT || REG_SPF0403B.SPF_AGENCIA_RECEBEDORA != WORK_AREA.WS_AGENCIA_ANT || WORK_AREA.WFIM_SORT == "S"))
            {

                R2300_00_PROCESSA_AGENCIA_SECTION();
            }

            /*" -705- MOVE 90 TO AC-LINHA. */
            _.Move(90, WORK_AREA.AC_LINHA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-PROCESSA-AGENCIA-SECTION */
        private void R2300_00_PROCESSA_AGENCIA_SECTION()
        {
            /*" -719- MOVE 'R2300' TO WNR-EXEC-SQL. */
            _.Move("R2300", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -720- MOVE SPF-NUMERO-DA-PROPOSTA TO LD01-NRPROPOSTA */
            _.Move(REG_SPF0403B.SPF_NUMERO_DA_PROPOSTA, WORK_AREA.LD01.LD01_NRPROPOSTA);

            /*" -721- MOVE SPF-NUMERO-PARCELA TO LD01-NRPARCELA */
            _.Move(REG_SPF0403B.SPF_NUMERO_PARCELA, WORK_AREA.LD01.LD01_NRPARCELA);

            /*" -722- MOVE SPF-NUMERO-SICOB TO LD01-NRSICOB */
            _.Move(REG_SPF0403B.SPF_NUMERO_SICOB, WORK_AREA.LD01.LD01_NRSICOB);

            /*" -724- MOVE SPF-VALOR-PAGO TO LD01-VLPAGO */
            _.Move(REG_SPF0403B.SPF_VALOR_PAGO, WORK_AREA.LD01.LD01_VLPAGO);

            /*" -725- MOVE SPF-DATA-QUITACAO TO WS-DATA-SORT. */
            _.Move(REG_SPF0403B.SPF_DATA_QUITACAO, WORK_AREA.WS_DATA_SORT);

            /*" -726- MOVE WS-DIA-SORT TO WS-DIA */
            _.Move(WORK_AREA.WS_DATA_SORT.WS_DIA_SORT, WORK_AREA.WS_DATA.WS_DIA);

            /*" -727- MOVE WS-MES-SORT TO WS-MES */
            _.Move(WORK_AREA.WS_DATA_SORT.WS_MES_SORT, WORK_AREA.WS_DATA.WS_MES);

            /*" -728- MOVE WS-ANO-SORT TO WS-ANO */
            _.Move(WORK_AREA.WS_DATA_SORT.WS_ANO_SORT, WORK_AREA.WS_DATA.WS_ANO);

            /*" -730- MOVE '/' TO WS-BAR1, WS-BAR2. */
            _.Move("/", WORK_AREA.WS_DATA.WS_BAR1, WORK_AREA.WS_DATA.WS_BAR2);

            /*" -732- MOVE WS-DATA TO LD01-DTQITBCO. */
            _.Move(WORK_AREA.WS_DATA, WORK_AREA.LD01.LD01_DTQITBCO);

            /*" -733- MOVE SPF-NUMERO-CERTIFICADO TO LD01-NRCERTIFICADO */
            _.Move(REG_SPF0403B.SPF_NUMERO_CERTIFICADO, WORK_AREA.LD01.LD01_NRCERTIFICADO);

            /*" -734- MOVE SPF-NOME-PAGADOR TO LD01-NOME */
            _.Move(REG_SPF0403B.SPF_NOME_PAGADOR, WORK_AREA.LD01.LD01_NOME);

            /*" -736- MOVE SPF-CPF-CGC-PAGADOR TO LD02-CGCCPF */
            _.Move(REG_SPF0403B.SPF_CPF_CGC_PAGADOR, WORK_AREA.LD02.LD02_CGCCPF);

            /*" -738- PERFORM R2800-00-SELECT-PRODUTOS-SIVPF. */

            R2800_00_SELECT_PRODUTOS_SIVPF_SECTION();

            /*" -740- MOVE PRDSIVPF-NOME-PRODUTO TO LD02-NMPRODUTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_NOME_PRODUTO, WORK_AREA.LD02.LD02_NMPRODUTO);

            /*" -741- IF AC-LINHA > 55 */

            if (WORK_AREA.AC_LINHA > 55)
            {

                /*" -743- PERFORM R5000-00-CABECALHOS. */

                R5000_00_CABECALHOS_SECTION();
            }


            /*" -744- WRITE REG-IMPRESSAO FROM LD01 AFTER 2. */
            _.Move(WORK_AREA.LD01.GetMoveValues(), REG_IMPRESSAO);

            RPF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -746- WRITE REG-IMPRESSAO FROM LD02 AFTER 1. */
            _.Move(WORK_AREA.LD02.GetMoveValues(), REG_IMPRESSAO);

            RPF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -753- ADD 3 TO AC-LINHA */
            WORK_AREA.AC_LINHA.Value = WORK_AREA.AC_LINHA + 3;

            /*" -760- ADD 1 TO AC-IMPRESSOS. */
            WORK_AREA.AC_IMPRESSOS.Value = WORK_AREA.AC_IMPRESSOS + 1;

            /*" -760- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-LE-SORT-SECTION */
        private void R2400_00_LE_SORT_SECTION()
        {
            /*" -773- MOVE 'R2400' TO WNR-EXEC-SQL. */
            _.Move("R2400", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -775- RETURN SPF0403B AT END */
            try
            {
                SPF0403B.Return(REG_SPF0403B, () =>
                {

                    /*" -777- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WORK_AREA.WFIM_SORT);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -778- IF WFIM-SORT NOT EQUAL 'S' */

            if (WORK_AREA.WFIM_SORT != "S")
            {

                /*" -778- ADD 1 TO AC-LIDOS. */
                WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-SELECT-V0AGENCIACEF-SECTION */
        private void R2700_00_SELECT_V0AGENCIACEF_SECTION()
        {
            /*" -789- MOVE 'R2700' TO WNR-EXEC-SQL. */
            _.Move("R2700", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -795- PERFORM R2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1 */

            R2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1();

            /*" -798- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -799- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -800- MOVE 'AGENCIA INEXISTENTE' TO V0AGEN-NOMEAGE */
                    _.Move("AGENCIA INEXISTENTE", V0AGEN_NOMEAGE);

                    /*" -801- ELSE */
                }
                else
                {


                    /*" -801- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2700-00-SELECT-V0AGENCIACEF-DB-SELECT-1 */
        public void R2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1()
        {
            /*" -795- EXEC SQL SELECT NOME_AGENCIA INTO :V0AGEN-NOMEAGE FROM SEGUROS.V0AGENCIACEF WHERE COD_AGENCIA = :WHOST-AGENCIA WITH UR END-EXEC. */

            var r2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 = new R2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1()
            {
                WHOST_AGENCIA = WHOST_AGENCIA.ToString(),
            };

            var executed_1 = R2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1.Execute(r2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0AGEN_NOMEAGE, V0AGEN_NOMEAGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-SELECT-PRODUTOS-SIVPF-SECTION */
        private void R2800_00_SELECT_PRODUTOS_SIVPF_SECTION()
        {
            /*" -814- MOVE 'R2800' TO WNR-EXEC-SQL. */
            _.Move("R2800", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -817- MOVE SPF-EMPRESA TO PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(REG_SPF0403B.SPF_EMPRESA, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);

            /*" -820- MOVE SPF-CODIGO-PRODUTO TO PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(REG_SPF0403B.SPF_CODIGO_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

            /*" -834- PERFORM R2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1 */

            R2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1();

            /*" -837- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -838- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -839- MOVE ALL '*' TO PRDSIVPF-NOME-PRODUTO */
                    _.MoveAll("*", PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_NOME_PRODUTO);

                    /*" -840- ELSE */
                }
                else
                {


                    /*" -840- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2800-00-SELECT-PRODUTOS-SIVPF-DB-SELECT-1 */
        public void R2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1()
        {
            /*" -834- EXEC SQL SELECT A.NOME_PRODUTO INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-NOME-PRODUTO FROM SEGUROS.PRODUTOS_SIVPF A WHERE A.COD_EMPRESA_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF AND A.COD_PRODUTO_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF AND A.COD_PRODUTO = (SELECT MIN(B.COD_PRODUTO) FROM SEGUROS.PRODUTOS_SIVPF B WHERE B.COD_EMPRESA_SIVPF = A.COD_EMPRESA_SIVPF AND B.COD_PRODUTO_SIVPF = A.COD_PRODUTO_SIVPF) WITH UR END-EXEC. */

            var r2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1 = new R2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_EMPRESA_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF.ToString(),
                PRDSIVPF_COD_PRODUTO_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF.ToString(),
            };

            var executed_1 = R2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1.Execute(r2800_00_SELECT_PRODUTOS_SIVPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_NOME_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_NOME_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-CABECALHOS-SECTION */
        private void R5000_00_CABECALHOS_SECTION()
        {
            /*" -852- MOVE 'R5000' TO WNR-EXEC-SQL. */
            _.Move("R5000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -853- ADD 1 TO AC-PAGINA. */
            WORK_AREA.AC_PAGINA.Value = WORK_AREA.AC_PAGINA + 1;

            /*" -854- MOVE AC-PAGINA TO LC01-PAGINA. */
            _.Move(WORK_AREA.AC_PAGINA, WORK_AREA.LC01.LC01_PAGINA);

            /*" -855- WRITE REG-IMPRESSAO FROM LC01 AFTER PAGE. */
            _.Move(WORK_AREA.LC01.GetMoveValues(), REG_IMPRESSAO);

            RPF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -856- WRITE REG-IMPRESSAO FROM LC02. */
            _.Move(WORK_AREA.LC02.GetMoveValues(), REG_IMPRESSAO);

            RPF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -857- WRITE REG-IMPRESSAO FROM LC03. */
            _.Move(WORK_AREA.LC03.GetMoveValues(), REG_IMPRESSAO);

            RPF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -858- WRITE REG-IMPRESSAO FROM TRACO. */
            _.Move(WORK_AREA.TRACO.GetMoveValues(), REG_IMPRESSAO);

            RPF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -859- WRITE REG-IMPRESSAO FROM LC04. */
            _.Move(WORK_AREA.LC04.GetMoveValues(), REG_IMPRESSAO);

            RPF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -860- WRITE REG-IMPRESSAO FROM TRACO. */
            _.Move(WORK_AREA.TRACO.GetMoveValues(), REG_IMPRESSAO);

            RPF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -861- WRITE REG-IMPRESSAO FROM LC05. */
            _.Move(WORK_AREA.LC05.GetMoveValues(), REG_IMPRESSAO);

            RPF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -862- WRITE REG-IMPRESSAO FROM BRANCO */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RPF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -863- WRITE REG-IMPRESSAO FROM LC06. */
            _.Move(WORK_AREA.LC06.GetMoveValues(), REG_IMPRESSAO);

            RPF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -864- WRITE REG-IMPRESSAO FROM LC07. */
            _.Move(WORK_AREA.LC07.GetMoveValues(), REG_IMPRESSAO);

            RPF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -866- WRITE REG-IMPRESSAO FROM TRACO. */
            _.Move(WORK_AREA.TRACO.GetMoveValues(), REG_IMPRESSAO);

            RPF0403B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -866- MOVE 11 TO AC-LINHA. */
            _.Move(11, WORK_AREA.AC_LINHA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -879- MOVE 'R8000' TO WNR-EXEC-SQL. */
            _.Move("R8000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -881- OPEN INPUT MOVSIGAT. */
            MOVSIGAT.Open(REG_SIGAT);

            /*" -881- OPEN OUTPUT RPF0403B. */
            RPF0403B.Open(REG_IMPRESSAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8500-00-LER-MOV-SIGAT-SECTION */
        private void R8500_00_LER_MOV_SIGAT_SECTION()
        {
            /*" -893- MOVE 'R8500' TO WNR-EXEC-SQL. */
            _.Move("R8500", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -894- READ MOVSIGAT AT END */
            try
            {
                MOVSIGAT.Read(() =>
                {

                    /*" -897- MOVE 'S' TO WFIM-MOVSIGAT. */
                    _.Move("S", WORK_AREA.WFIM_MOVSIGAT);
                });

                _.Move(MOVSIGAT.Value, REG_SIGAT);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -898- IF WFIM-MOVSIGAT NOT EQUAL 'S' */

            if (WORK_AREA.WFIM_MOVSIGAT != "S")
            {

                /*" -899- IF IDENTIFICACAO EQUAL 'H' */

                if (REG_SIGAT.IDENTIFICACAO == "H")
                {

                    /*" -900- IF NOME-ARQUIVO EQUAL 'PRPSASSE' */

                    if (REG_SIGAT.NM_ARQUIVO.NOME_ARQUIVO == "PRPSASSE")
                    {

                        /*" -901- MOVE 1 TO SPF-EMPRESA */
                        _.Move(1, REG_SPF0403B.SPF_EMPRESA);

                        /*" -902- GO TO R8500-00-LER-MOV-SIGAT */
                        new Task(() => R8500_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -903- ELSE */
                    }
                    else
                    {


                        /*" -904- IF NOME-ARQUIVO EQUAL 'PRPFPREV' */

                        if (REG_SIGAT.NM_ARQUIVO.NOME_ARQUIVO == "PRPFPREV")
                        {

                            /*" -905- MOVE 2 TO SPF-EMPRESA */
                            _.Move(2, REG_SPF0403B.SPF_EMPRESA);

                            /*" -906- GO TO R8500-00-LER-MOV-SIGAT */
                            new Task(() => R8500_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                            return;//Recursividade detectada, cuidado...

                            /*" -907- ELSE */
                        }
                        else
                        {


                            /*" -908- MOVE 3 TO SPF-EMPRESA */
                            _.Move(3, REG_SPF0403B.SPF_EMPRESA);

                            /*" -909- GO TO R8500-00-LER-MOV-SIGAT */
                            new Task(() => R8500_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                            return;//Recursividade detectada, cuidado...

                            /*" -910- ELSE */
                        }

                    }

                }
                else
                {


                    /*" -912- IF IDENTIFICACAO EQUAL '0' NEXT SENTENCE */

                    if (REG_SIGAT.IDENTIFICACAO == "0")
                    {

                        /*" -913- ELSE */
                    }
                    else
                    {


                        /*" -913- GO TO R8500-00-LER-MOV-SIGAT. */
                        new Task(() => R8500_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -925- MOVE 'R9000' TO WNR-EXEC-SQL. */
            _.Move("R9000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -926- CLOSE RPF0403B, MOVSIGAT. */
            RPF0403B.Close();
            MOVSIGAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -941- MOVE 'R9800' TO WNR-EXEC-SQL. */
            _.Move("R9800", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -942- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -943- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -944- DISPLAY '*   PF0403B - GERA RELATORIO PGTO AVULSO   *' */
            _.Display($"*   PF0403B - GERA RELATORIO PGTO AVULSO   *");

            /*" -945- DISPLAY '*   -------   -------------- -----------   *' */
            _.Display($"*   -------   -------------- -----------   *");

            /*" -946- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -947- DISPLAY '*      NAO HOUVE MOVIMENTO NESTA DATA      *' */
            _.Display($"*      NAO HOUVE MOVIMENTO NESTA DATA      *");

            /*" -948- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -949- DISPLAY '*   ===> T E R M I N O  N O R M A L <===   *' */
            _.Display($"*   ===> T E R M I N O  N O R M A L <===   *");

            /*" -950- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -952- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -954- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -954- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -968- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -970- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -970- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -972- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -976- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -976- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}