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
using Sias.Sinistro.DB2.SI0864B;

namespace Code
{
    public class SI0864B
    {
        public bool IsCall { get; set; }

        public SI0864B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI0864B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  LUIS RICARDO                       *      */
        /*"      *   CRIACAO ................  05/04/2002.                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ..... GERAR ARQUIVO SEQUENCIAL COM INFORMACOES DO     *      */
        /*"      *    LOTERICO SOLICITADO PELO USUARIO A PARTIR DA  TRANSACAO     *      */
        /*"      *    ON LINE 13-12-35 (APLICA  O SI1FA)                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - RICARDO - 10/01/2003 - RETIRADO NUMERO DA APOLICE  *      */
        /*"      *             QUE ESTAVA FIXO NO CABECALHO DO ARQUIVO E INCLUIDO *      */
        /*"      *             INFORMACAO DA APOLICE SOLICITADA ATRAVES DA APLI-  *      */
        /*"      *             CAO ON LINE E REGISTRADA NA TABELA RELATORIOS.     *      */
        /*"      *             PROCURAR LR001.                                    *      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO - ALEXIS  - 03/06/2003 - INCLUIR O PONTO DE VENDA E  *      */
        /*"      *             A DATA DE CANCELAMENTO.                            *      */
        /*"      *             PROCURAR LR001.                                    *      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO - PRODEXTER - 14/04/2005                             *      */
        /*"      * (1) SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA TABELA      *      */
        /*"      *     GE_OPERACAO                                                *      */
        /*"      * (2) SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A   *      */
        /*"      *     SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQ_SAIDA { get; set; } = new FileBasis(new PIC("X", "650", "X(650)"));

        public FileBasis ARQ_SAIDA
        {
            get
            {
                _.Move(REG_ARQ_SAIDA, _ARQ_SAIDA); VarBasis.RedefinePassValue(REG_ARQ_SAIDA, _ARQ_SAIDA, REG_ARQ_SAIDA); return _ARQ_SAIDA;
            }
        }
        /*"01  REG-ARQ-SAIDA                  PIC X(650).*/
        public StringBasis REG_ARQ_SAIDA { get; set; } = new StringBasis(new PIC("X", "650", "X(650)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-AVISADO                PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-PENDENTE               PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-PAGO                   PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  AREA-DE-WORK.*/
        public SI0864B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0864B_AREA_DE_WORK();
        public class SI0864B_AREA_DE_WORK : VarBasis
        {
            /*"   05 WSL-SQLCODE                    PIC  9(009) VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"01  W-INICIO-WORK.*/
        }
        public SI0864B_W_INICIO_WORK W_INICIO_WORK { get; set; } = new SI0864B_W_INICIO_WORK();
        public class SI0864B_W_INICIO_WORK : VarBasis
        {
            /*"    03 W-FIM-RELATORIO                PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_RELATORIO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-FIM-MESTRE                   PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_MESTRE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-FIM-BONUS                    PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_BONUS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-CNT-BONUS                    PIC 9(03)  VALUE 0.*/
            public IntBasis W_CNT_BONUS { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    03 W-CHAVE-ARQ-SAIDA-JA-ABERTO    PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_CHAVE_ARQ_SAIDA_JA_ABERTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-IND                          PIC 9(03)  VALUE ZEROS.*/
            public IntBasis W_IND { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    03 W-IND-CAB                      PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_IND_CAB { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-CONTADOR-USUARIO             PIC 9(13)  VALUE ZEROS.*/
            public IntBasis W_CONTADOR_USUARIO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03 W-CONTADOR-GERAL               PIC 9(13)  VALUE ZEROS.*/
            public IntBasis W_CONTADOR_GERAL { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03  WGD-CEP                       PIC 9(08)  VALUE 0.*/
            public IntBasis WGD_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    03  FILLER REDEFINES WGD-CEP.*/
            private _REDEF_SI0864B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_SI0864B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_SI0864B_FILLER_0(); _.Move(WGD_CEP, _filler_0); VarBasis.RedefinePassValue(WGD_CEP, _filler_0, WGD_CEP); _filler_0.ValueChanged += () => { _.Move(_filler_0, WGD_CEP); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WGD_CEP); }
            }  //Redefines
            public class _REDEF_SI0864B_FILLER_0 : VarBasis
            {
                /*"        05  WGD-CEP-PRINC             PIC 9(05).*/
                public IntBasis WGD_CEP_PRINC { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"        05  WGD-CEP-EXTENS            PIC 9(03).*/
                public IntBasis WGD_CEP_EXTENS { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"01  FILLER.*/

                public _REDEF_SI0864B_FILLER_0()
                {
                    WGD_CEP_PRINC.ValueChanged += OnValueChanged;
                    WGD_CEP_EXTENS.ValueChanged += OnValueChanged;
                }

            }
        }
        public SI0864B_FILLER_1 FILLER_1 { get; set; } = new SI0864B_FILLER_1();
        public class SI0864B_FILLER_1 : VarBasis
        {
            /*"    05 WABEND.*/
            public SI0864B_WABEND WABEND { get; set; } = new SI0864B_WABEND();
            public class SI0864B_WABEND : VarBasis
            {
                /*"       10 FILLER                     PIC  X(009) VALUE          'SI0864B '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0864B ");
                /*"       10 FILLER                     PIC  X(035) VALUE          ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
                /*"       10 WNR-EXEC-SQL               PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"       10 FILLER                     PIC  X(013) VALUE          ' *** SQLCODE '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"       10 WSQLCODE                   PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01  FILLER01.*/
            }
        }
        public SI0864B_FILLER01 FILLER01 { get; set; } = new SI0864B_FILLER01();
        public class SI0864B_FILLER01 : VarBasis
        {
            /*"  02 LD01.*/
            public SI0864B_LD01 LD01 { get; set; } = new SI0864B_LD01();
            public class SI0864B_LD01 : VarBasis
            {
                /*"    03 C01-SOLICITANTE           PIC  X(40) VALUE SPACES.*/
                public StringBasis C01_SOLICITANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-DATA-SOLIC            PIC  X(10) VALUE SPACES.*/
                public StringBasis C01_DATA_SOLIC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-DATA-PAGAMENTO        PIC  X(10) VALUE SPACES.*/
                public StringBasis C01_DATA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-SIT-SINISTRO          PIC  X(09) VALUE SPACES.*/
                public StringBasis C01_SIT_SINISTRO { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-NOME-LOTERICO         PIC  X(40) VALUE SPACES.*/
                public StringBasis C01_NOME_LOTERICO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-ESCRIT-NEGOC          PIC  9(04) VALUE 0.*/
                public IntBasis C01_ESCRIT_NEGOC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-AGENCIA-VINC          PIC  9(04) VALUE ZEROS.*/
                public IntBasis C01_AGENCIA_VINC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-DATA-PROC             PIC  X(10) VALUE SPACES.*/
                public StringBasis C01_DATA_PROC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-APOLICE               PIC  9(13) VALUE 0.*/
                public IntBasis C01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-SINISTRO              PIC  9(13) VALUE 0.*/
                public IntBasis C01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-CAUSA-SINISTRO        PIC  X(40) VALUE SPACES.*/
                public StringBasis C01_CAUSA_SINISTRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-DATA-OCORRENCIA       PIC  X(10) VALUE SPACES.*/
                public StringBasis C01_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-NUM-LOTERICO          PIC  9(09) VALUE 0.*/
                public IntBasis C01_NUM_LOTERICO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-NOME-FANT             PIC  X(40) VALUE SPACES.*/
                public StringBasis C01_NOME_FANT { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-ENDERECO              PIC  X(40) VALUE SPACES.*/
                public StringBasis C01_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-BAIRRO                PIC  X(40) VALUE SPACES.*/
                public StringBasis C01_BAIRRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-CEP                   PIC  9(05) VALUE 0.*/
                public IntBasis C01_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
                /*"    03 FILLER                    PIC  X(01) VALUE '-'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    03 C01-COMPL-CEP             PIC  9(03) VALUE 0.*/
                public IntBasis C01_COMPL_CEP { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-CIDADE                PIC  X(40) VALUE SPACES.*/
                public StringBasis C01_CIDADE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-UF                    PIC  X(02) VALUE SPACES.*/
                public StringBasis C01_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-DDD                   PIC  9(03) VALUE 0.*/
                public IntBasis C01_DDD { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-TELEFONE              PIC  9(10) VALUE 0.*/
                public IntBasis C01_TELEFONE { get; set; } = new IntBasis(new PIC("9", "10", "9(10)"));
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-AVISADO               PIC  ------------9,99.*/
                public DoubleBasis C01_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-PAGO                  PIC  ------------9,99.*/
                public DoubleBasis C01_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-PENDENTE              PIC  ------------9,99.*/
                public DoubleBasis C01_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-IMP-SEGURADA          PIC  ------------9,99.*/
                public DoubleBasis C01_IMP_SEGURADA { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-BONUS OCCURS 4 TIMES.*/
                public ListBasis<SI0864B_C01_BONUS> C01_BONUS { get; set; } = new ListBasis<SI0864B_C01_BONUS>(4);
                public class SI0864B_C01_BONUS : VarBasis
                {
                    /*"       05  C01-DESCR-BONUS       PIC  X(29).*/
                    public StringBasis C01_DESCR_BONUS { get; set; } = new StringBasis(new PIC("X", "29", "X(29)."), @"");
                    /*"       05  C01-SEPARADOR         PIC  X(01).*/
                    public StringBasis C01_SEPARADOR { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"  02 LC01.*/
                }
            }
            public SI0864B_LC01 LC01 { get; set; } = new SI0864B_LC01();
            public class SI0864B_LC01 : VarBasis
            {
                /*"    03  FILLER                   PIC  X(15) VALUE        'NOME DO USUARIO'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NOME DO USUARIO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(19) VALUE        'DATA DA SOLICITACAO'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA DA SOLICITACAO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(17) VALUE        'DATA DO PAGAMENTO'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"DATA DO PAGAMENTO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(20) VALUE        'SITUACAO DO SINISTRO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"SITUACAO DO SINISTRO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(16) VALUE        'NOME DO LOTERICO'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"NOME DO LOTERICO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(21) VALUE        'ESCRITORIO DE NEGOCIO'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"ESCRITORIO DE NEGOCIO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(21) VALUE        'AGENCIA VINCULADA    '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"AGENCIA VINCULADA    ");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(21) VALUE        'DATA DO PROCESSAMENTO'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"DATA DO PROCESSAMENTO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(17) VALUE        'NUMERO DA APOLICE'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"NUMERO DA APOLICE");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(18) VALUE        'NUMERO DO SINISTRO'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"NUMERO DO SINISTRO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(17) VALUE        'CAUSA DO SINISTRO'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"CAUSA DO SINISTRO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(18) VALUE        'DATA DA OCORRENCIA'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"DATA DA OCORRENCIA");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(15) VALUE        'NUMERO LOTERICO'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NUMERO LOTERICO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(13) VALUE        'NOME FANTASIA'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"NOME FANTASIA");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(08) VALUE        'ENDERECO'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"ENDERECO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(06) VALUE        'BAIRRO'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"BAIRRO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(03) VALUE        'CEP'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CEP");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(06) VALUE        'CIDADE'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"CIDADE");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(02) VALUE        'UF'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"UF");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(03) VALUE        'DDD'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DDD");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(08) VALUE        'TELEFONE'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"TELEFONE");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(07) VALUE        'AVISADO'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AVISADO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(04) VALUE        'PAGO'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"PAGO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(08) VALUE        'PENDENTE'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"PENDENTE");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(20) VALUE        'IMPORTANCIA SEGURADA'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"IMPORTANCIA SEGURADA");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(07) VALUE        'BONUS 1'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"BONUS 1");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(07) VALUE        'BONUS 2'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"BONUS 2");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(07) VALUE        'BONUS 3'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"BONUS 3");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(07) VALUE        'BONUS 4'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"BONUS 4");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(240) VALUE SPACES.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "240", "X(240)"), @"");
                /*"  02  LC02.*/
            }
            public SI0864B_LC02 LC02 { get; set; } = new SI0864B_LC02();
            public class SI0864B_LC02 : VarBasis
            {
                /*"    03  C02-IDENTIFICADOR        PIC  X(600) VALUE        'PROGRAMA GERADOR >>> SI0864B;'.*/
                public StringBasis C02_IDENTIFICADOR { get; set; } = new StringBasis(new PIC("X", "600", "X(600)"), @"PROGRAMA GERADOR >>> SI0864B;");
                /*"  02  LC03.*/
            }
            public SI0864B_LC03 LC03 { get; set; } = new SI0864B_LC03();
            public class SI0864B_LC03 : VarBasis
            {
                /*"    03  C03-FUNCAO               PIC  X(036) VALUE        'INFORMACOES DE LOTERICOS DA APOLICE '.*/
                public StringBasis C03_FUNCAO { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"INFORMACOES DE LOTERICOS DA APOLICE ");
                /*"    03  C03-NUM-APOLICE          PIC  9(013) VALUE 0.*/
                public IntBasis C03_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    03  C03-FILLER               PIC  X(005) VALUE ' ATE '.*/
                public StringBasis C03_FILLER { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ATE ");
                /*"    03  C03-DATA                 PIC  X(010) VALUE SPACES.*/
                public StringBasis C03_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    03  FILLER                   PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"01  FILLER REDEFINES FILLER01.*/
            }
        }
        private _REDEF_SI0864B_FILLER_91 _filler_91 { get; set; }
        public _REDEF_SI0864B_FILLER_91 FILLER_91
        {
            get { _filler_91 = new _REDEF_SI0864B_FILLER_91(); _.Move(FILLER01, _filler_91); VarBasis.RedefinePassValue(FILLER01, _filler_91, FILLER01); _filler_91.ValueChanged += () => { _.Move(_filler_91, FILLER01); }; return _filler_91; }
            set { VarBasis.RedefinePassValue(value, _filler_91, FILLER01); }
        }  //Redefines
        public class _REDEF_SI0864B_FILLER_91 : VarBasis
        {
            /*"    03  C01-FILLER               PIC  X(600).*/
            public StringBasis C01_FILLER { get; set; } = new StringBasis(new PIC("X", "600", "X(600)."), @"");

            public _REDEF_SI0864B_FILLER_91()
            {
                C01_FILLER.ValueChanged += OnValueChanged;
            }

        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.LOTISG01 LOTISG01 { get; set; } = new Dclgens.LOTISG01();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SINILT01 SINILT01 { get; set; } = new Dclgens.SINILT01();
        public Dclgens.LOTERI01 LOTERI01 { get; set; } = new Dclgens.LOTERI01();
        public Dclgens.LTLOTBON LTLOTBON { get; set; } = new Dclgens.LTLOTBON();
        public Dclgens.LOTBONUS LOTBONUS { get; set; } = new Dclgens.LOTBONUS();
        public Dclgens.LTTIPBON LTTIPBON { get; set; } = new Dclgens.LTTIPBON();
        public SI0864B_RELATORIOS RELATORIOS { get; set; } = new SI0864B_RELATORIOS();
        public SI0864B_MESTRE MESTRE { get; set; } = new SI0864B_MESTRE();
        public SI0864B_BONUS BONUS { get; set; } = new SI0864B_BONUS();
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

                /*" -328- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -329- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -330- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -334- OPEN OUTPUT ARQ-SAIDA. */
                ARQ_SAIDA.Open(REG_ARQ_SAIDA);

                /*" -336- PERFORM R010-SELECT-SISTEMA THRU R010-EXIT. */

                R010_SELECT_SISTEMA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -337- PERFORM R020-DECLARE-RELATORIO THRU R020-EXIT. */

                R020_DECLARE_RELATORIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -339- MOVE 'NAO' TO W-FIM-RELATORIO. */
                _.Move("NAO", W_INICIO_WORK.W_FIM_RELATORIO);

                /*" -341- PERFORM R021-FETCH-RELATORIO THRU R021-EXIT. */

                R021_FETCH_RELATORIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


                /*" -342- IF W-FIM-RELATORIO EQUAL 'SIM' */

                if (W_INICIO_WORK.W_FIM_RELATORIO == "SIM")
                {

                    /*" -343- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -344- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -345- DISPLAY '       NADA SELECIONADO NA DATA DE HOJE         ' */
                    _.Display($"       NADA SELECIONADO NA DATA DE HOJE         ");

                    /*" -346- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -347- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -348- MOVE 'NAO HOUVE SOLICITACAO NA DATA DE HOJE' TO C01-FILLER */
                    _.Move("NAO HOUVE SOLICITACAO NA DATA DE HOJE", FILLER_91.C01_FILLER);

                    /*" -349- WRITE REG-ARQ-SAIDA FROM LC02 */
                    _.Move(FILLER01.LC02.GetMoveValues(), REG_ARQ_SAIDA);

                    ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                    /*" -350- WRITE REG-ARQ-SAIDA FROM LD01 */
                    _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

                    ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                    /*" -352- GO TO 000-TERMINA. */

                    M_000_TERMINA(); //GOTO
                    return Result;
                }


                /*" -355- PERFORM R030-PROCESSA-RELATORIO THRU R030-EXIT UNTIL (W-FIM-RELATORIO EQUAL 'SIM' ). */

                while (!((W_INICIO_WORK.W_FIM_RELATORIO == "SIM")))
                {

                    R030_PROCESSA_RELATORIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

                }

                /*" -357- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", FILLER_1.WABEND.WNR_EXEC_SQL);

                /*" -362- PERFORM Execute_DB_UPDATE_1 */

                Execute_DB_UPDATE_1();

                /*" -365- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -366- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -367- DISPLAY 'ERRO NO UPDATE RELATORIOS.......' */
                    _.Display($"ERRO NO UPDATE RELATORIOS.......");

                    /*" -368- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -368- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -368- FLUXCONTROL_PERFORM Execute-DB-UPDATE-1 */

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
            /*" -362- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE IDE_SISTEMA = 'SI' AND COD_RELATORIO = 'SI0864B' AND SIT_REGISTRO = '0' END-EXEC. */

            var execute_DB_UPDATE_1_Update1 = new Execute_DB_UPDATE_1_Update1()
            {
            };

            Execute_DB_UPDATE_1_Update1.Execute(execute_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-000-TERMINA */
        private void M_000_TERMINA(bool isPerform = false)
        {
            /*" -373- DISPLAY '************************************' */
            _.Display($"************************************");

            /*" -374- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -375- DISPLAY '*   TERMINO NORMAL DO PROGRAMA     *' */
            _.Display($"*   TERMINO NORMAL DO PROGRAMA     *");

            /*" -376- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -377- DISPLAY '*            SI0864B               *' */
            _.Display($"*            SI0864B               *");

            /*" -378- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -378- DISPLAY '************************************' . */
            _.Display($"************************************");

        }

        [StopWatch]
        /*" M-000-FIM-PROGRAMA */
        private void M_000_FIM_PROGRAMA(bool isPerform = false)
        {
            /*" -383- CLOSE ARQ-SAIDA */
            ARQ_SAIDA.Close();

            /*" -384- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -384- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R010-SELECT-SISTEMA */
        private void R010_SELECT_SISTEMA(bool isPerform = false)
        {
            /*" -390- MOVE '002' TO WNR-EXEC-SQL */
            _.Move("002", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -395- PERFORM R010_SELECT_SISTEMA_DB_SELECT_1 */

            R010_SELECT_SISTEMA_DB_SELECT_1();

            /*" -398- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -399- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -400- DISPLAY 'ERRO NO ACESSO - SISTEMA .......' */
                _.Display($"ERRO NO ACESSO - SISTEMA .......");

                /*" -401- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -402- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -403- ELSE */
            }
            else
            {


                /*" -405- MOVE SISTEMAS-DATA-MOV-ABERTO(09:02) TO C01-DATA-PROC(01:02) */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), FILLER01.LD01.C01_DATA_PROC, 1, 2);

                /*" -406- MOVE '/' TO C01-DATA-PROC(03:01) */
                _.MoveAtPosition("/", FILLER01.LD01.C01_DATA_PROC, 3, 1);

                /*" -408- MOVE SISTEMAS-DATA-MOV-ABERTO(06:02) TO C01-DATA-PROC(04:02) */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), FILLER01.LD01.C01_DATA_PROC, 4, 2);

                /*" -409- MOVE '/' TO C01-DATA-PROC(06:01) */
                _.MoveAtPosition("/", FILLER01.LD01.C01_DATA_PROC, 6, 1);

                /*" -411- MOVE SISTEMAS-DATA-MOV-ABERTO(01:04) TO C01-DATA-PROC(07:04) */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), FILLER01.LD01.C01_DATA_PROC, 7, 4);

                /*" -411- END-IF. */
            }


        }

        [StopWatch]
        /*" R010-SELECT-SISTEMA-DB-SELECT-1 */
        public void R010_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -395- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC */

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
            /*" -420- MOVE '003' TO WNR-EXEC-SQL */
            _.Move("003", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -429- PERFORM R020_DECLARE_RELATORIO_DB_DECLARE_1 */

            R020_DECLARE_RELATORIO_DB_DECLARE_1();

            /*" -431- PERFORM R020_DECLARE_RELATORIO_DB_OPEN_1 */

            R020_DECLARE_RELATORIO_DB_OPEN_1();

        }

        [StopWatch]
        /*" R020-DECLARE-RELATORIO-DB-DECLARE-1 */
        public void R020_DECLARE_RELATORIO_DB_DECLARE_1()
        {
            /*" -429- EXEC SQL DECLARE RELATORIOS CURSOR FOR SELECT COD_USUARIO, DATA_SOLICITACAO, PERI_FINAL, NUM_APOLICE FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'SI' AND COD_RELATORIO = 'SI0864B' AND SIT_REGISTRO = '0' END-EXEC */
            RELATORIOS = new SI0864B_RELATORIOS(false);
            string GetQuery_RELATORIOS()
            {
                var query = @$"SELECT COD_USUARIO
							, 
							DATA_SOLICITACAO
							, 
							PERI_FINAL
							, 
							NUM_APOLICE 
							FROM SEGUROS.RELATORIOS 
							WHERE IDE_SISTEMA = 'SI' 
							AND COD_RELATORIO = 'SI0864B' 
							AND SIT_REGISTRO = '0'";

                return query;
            }
            RELATORIOS.GetQueryEvent += GetQuery_RELATORIOS;

        }

        [StopWatch]
        /*" R020-DECLARE-RELATORIO-DB-OPEN-1 */
        public void R020_DECLARE_RELATORIO_DB_OPEN_1()
        {
            /*" -431- EXEC SQL OPEN RELATORIOS END-EXEC. */

            RELATORIOS.Open();

        }

        [StopWatch]
        /*" R040-DECLARE-MESTRE-DB-DECLARE-1 */
        public void R040_DECLARE_MESTRE_DB_DECLARE_1()
        {
            /*" -574- EXEC SQL DECLARE MESTRE CURSOR FOR SELECT M.NUM_APOL_SINISTRO, M.NUM_APOLICE, M.COD_CAUSA, M.RAMO, M.SIT_REGISTRO, M.DATA_OCORRENCIA, SC.DESCR_CAUSA, SL.COD_LOT_CEF, SL.NUM_APOLICE, SL.COD_LOT_FENAL, SL.DTINIVIG, SL.COD_COBERTURA, C.NOME_RAZAO FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO O, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.CLIENTES C, SEGUROS.SINISTRO_CAUSA SC WHERE M.NUM_APOLICE = :RELATORI-NUM-APOLICE AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.DATA_MOVIMENTO <= :RELATORI-PERI-FINAL AND H.COD_OPERACAO = O.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.IND_TIPO_FUNCAO IN ( 'AV' , 'IN' ) AND SC.RAMO_EMISSOR = M.RAMO AND SC.COD_CAUSA = M.COD_CAUSA AND SL.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND C.COD_CLIENTE = SL.COD_CLIENTE AND M.NUM_APOL_SINISTRO NOT IN ( 107100007424, 107100011192, 107100011193, 107100011223, 107100011225, 107100011396, 107100013821, 107100011241) GROUP BY M.NUM_APOL_SINISTRO, M.NUM_APOLICE, M.COD_CAUSA, M.RAMO, M.SIT_REGISTRO, M.DATA_OCORRENCIA, SC.DESCR_CAUSA, SL.COD_LOT_CEF, SL.NUM_APOLICE, SL.COD_LOT_FENAL, SL.DTINIVIG, SL.COD_COBERTURA, C.NOME_RAZAO ORDER BY M.NUM_APOL_SINISTRO END-EXEC. */
            MESTRE = new SI0864B_MESTRE(true);
            string GetQuery_MESTRE()
            {
                var query = @$"SELECT M.NUM_APOL_SINISTRO
							, 
							M.NUM_APOLICE
							, 
							M.COD_CAUSA
							, 
							M.RAMO
							, 
							M.SIT_REGISTRO
							, 
							M.DATA_OCORRENCIA
							, 
							SC.DESCR_CAUSA
							, 
							SL.COD_LOT_CEF
							, 
							SL.NUM_APOLICE
							, 
							SL.COD_LOT_FENAL
							, 
							SL.DTINIVIG
							, 
							SL.COD_COBERTURA
							, 
							C.NOME_RAZAO 
							FROM SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.GE_OPERACAO O
							, 
							SEGUROS.SINI_LOTERICO01 SL
							, 
							SEGUROS.CLIENTES C
							, 
							SEGUROS.SINISTRO_CAUSA SC 
							WHERE M.NUM_APOLICE = '{RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}' 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND H.DATA_MOVIMENTO <= '{RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}' 
							AND H.COD_OPERACAO = O.COD_OPERACAO 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.IND_TIPO_FUNCAO IN ( 'AV'
							, 'IN' ) 
							AND SC.RAMO_EMISSOR = M.RAMO 
							AND SC.COD_CAUSA = M.COD_CAUSA 
							AND SL.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND C.COD_CLIENTE = SL.COD_CLIENTE 
							AND M.NUM_APOL_SINISTRO NOT IN ( 
							107100007424
							, 107100011192
							, 107100011193
							, 107100011223
							, 
							107100011225
							, 107100011396
							, 107100013821
							, 107100011241) 
							GROUP BY M.NUM_APOL_SINISTRO
							, 
							M.NUM_APOLICE
							, 
							M.COD_CAUSA
							, 
							M.RAMO
							, 
							M.SIT_REGISTRO
							, 
							M.DATA_OCORRENCIA
							, 
							SC.DESCR_CAUSA
							, 
							SL.COD_LOT_CEF
							, 
							SL.NUM_APOLICE
							, 
							SL.COD_LOT_FENAL
							, 
							SL.DTINIVIG
							, 
							SL.COD_COBERTURA
							, 
							C.NOME_RAZAO 
							ORDER BY M.NUM_APOL_SINISTRO";

                return query;
            }
            MESTRE.GetQueryEvent += GetQuery_MESTRE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R021-FETCH-RELATORIO */
        private void R021_FETCH_RELATORIO(bool isPerform = false)
        {
            /*" -440- MOVE '004' TO WNR-EXEC-SQL */
            _.Move("004", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -445- PERFORM R021_FETCH_RELATORIO_DB_FETCH_1 */

            R021_FETCH_RELATORIO_DB_FETCH_1();

            /*" -448- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -449- MOVE 'SIM' TO W-FIM-RELATORIO */
                _.Move("SIM", W_INICIO_WORK.W_FIM_RELATORIO);

                /*" -449- PERFORM R021_FETCH_RELATORIO_DB_CLOSE_1 */

                R021_FETCH_RELATORIO_DB_CLOSE_1();

                /*" -452- GO TO R021-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/ //GOTO
                return;
            }


            /*" -453- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -454- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -455- DISPLAY 'ERRO FETCH NA RELATORIOS...........' */
                _.Display($"ERRO FETCH NA RELATORIOS...........");

                /*" -456- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -458- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -460- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -465- PERFORM R021_FETCH_RELATORIO_DB_SELECT_1 */

            R021_FETCH_RELATORIO_DB_SELECT_1();

            /*" -469- MOVE USUARIOS-NOME-USUARIO TO C01-SOLICITANTE. */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, FILLER01.LD01.C01_SOLICITANTE);

            /*" -471- MOVE RELATORI-DATA-SOLICITACAO(09:02) TO C01-DATA-SOLIC(01:02) */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(9, 2), FILLER01.LD01.C01_DATA_SOLIC, 1, 2);

            /*" -472- MOVE '/' TO C01-DATA-SOLIC(03:01) */
            _.MoveAtPosition("/", FILLER01.LD01.C01_DATA_SOLIC, 3, 1);

            /*" -474- MOVE RELATORI-DATA-SOLICITACAO(06:02) TO C01-DATA-SOLIC(04:02) */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(6, 2), FILLER01.LD01.C01_DATA_SOLIC, 4, 2);

            /*" -475- MOVE '/' TO C01-DATA-SOLIC(06:01) */
            _.MoveAtPosition("/", FILLER01.LD01.C01_DATA_SOLIC, 6, 1);

            /*" -478- MOVE RELATORI-DATA-SOLICITACAO(01:04) TO C01-DATA-SOLIC(07:04). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(1, 4), FILLER01.LD01.C01_DATA_SOLIC, 7, 4);

            /*" -480- MOVE RELATORI-NUM-APOLICE TO C03-NUM-APOLICE. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, FILLER01.LC03.C03_NUM_APOLICE);

            /*" -482- MOVE RELATORI-PERI-FINAL(09:02) TO C03-DATA(01:02) */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Substring(9, 2), FILLER01.LC03.C03_DATA, 1, 2);

            /*" -483- MOVE '/' TO C03-DATA(03:01) */
            _.MoveAtPosition("/", FILLER01.LC03.C03_DATA, 3, 1);

            /*" -485- MOVE RELATORI-PERI-FINAL(06:02) TO C03-DATA(04:02) */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Substring(6, 2), FILLER01.LC03.C03_DATA, 4, 2);

            /*" -486- MOVE '/' TO C03-DATA(06:01) */
            _.MoveAtPosition("/", FILLER01.LC03.C03_DATA, 6, 1);

            /*" -487- MOVE RELATORI-PERI-FINAL(01:04) TO C03-DATA(07:04). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Substring(1, 4), FILLER01.LC03.C03_DATA, 7, 4);

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-FETCH-1 */
        public void R021_FETCH_RELATORIO_DB_FETCH_1()
        {
            /*" -445- EXEC SQL FETCH RELATORIOS INTO :RELATORI-COD-USUARIO, :RELATORI-DATA-SOLICITACAO, :RELATORI-PERI-FINAL, :RELATORI-NUM-APOLICE END-EXEC. */

            if (RELATORIOS.Fetch())
            {
                _.Move(RELATORIOS.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(RELATORIOS.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(RELATORIOS.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
                _.Move(RELATORIOS.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
            }

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-CLOSE-1 */
        public void R021_FETCH_RELATORIO_DB_CLOSE_1()
        {
            /*" -449- EXEC SQL CLOSE RELATORIOS END-EXEC */

            RELATORIOS.Close();

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-SELECT-1 */
        public void R021_FETCH_RELATORIO_DB_SELECT_1()
        {
            /*" -465- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :RELATORI-COD-USUARIO END-EXEC. */

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
            /*" -495- WRITE REG-ARQ-SAIDA FROM LC03. */
            _.Move(FILLER01.LC03.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

            /*" -496- WRITE REG-ARQ-SAIDA FROM LC02. */
            _.Move(FILLER01.LC02.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

            /*" -498- WRITE REG-ARQ-SAIDA FROM LC01. */
            _.Move(FILLER01.LC01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

            /*" -500- PERFORM R040-DECLARE-MESTRE THRU R040-EXIT. */

            R040_DECLARE_MESTRE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/


            /*" -502- MOVE 'NAO' TO W-FIM-MESTRE */
            _.Move("NAO", W_INICIO_WORK.W_FIM_MESTRE);

            /*" -504- PERFORM R050-FETCH-MESTRE THRU R050-EXIT. */

            R050_FETCH_MESTRE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/


            /*" -505- IF W-FIM-MESTRE EQUAL 'SIM' */

            if (W_INICIO_WORK.W_FIM_MESTRE == "SIM")
            {

                /*" -506- MOVE 'NAO HOUVE SOLICITACAO NA DATA DE HOJE' TO C01-FILLER */
                _.Move("NAO HOUVE SOLICITACAO NA DATA DE HOJE", FILLER_91.C01_FILLER);

                /*" -508- WRITE REG-ARQ-SAIDA FROM LD01. */
                _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());
            }


            /*" -511- PERFORM R060-PROCESSA-MESTRE THRU R060-EXIT UNTIL W-FIM-MESTRE EQUAL 'SIM' . */

            while (!(W_INICIO_WORK.W_FIM_MESTRE == "SIM"))
            {

                R060_PROCESSA_MESTRE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R060_EXIT*/

            }

            /*" -511- PERFORM R021-FETCH-RELATORIO THRU R021-EXIT. */

            R021_FETCH_RELATORIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R040-DECLARE-MESTRE */
        private void R040_DECLARE_MESTRE(bool isPerform = false)
        {
            /*" -520- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -574- PERFORM R040_DECLARE_MESTRE_DB_DECLARE_1 */

            R040_DECLARE_MESTRE_DB_DECLARE_1();

            /*" -576- PERFORM R040_DECLARE_MESTRE_DB_OPEN_1 */

            R040_DECLARE_MESTRE_DB_OPEN_1();

        }

        [StopWatch]
        /*" R040-DECLARE-MESTRE-DB-OPEN-1 */
        public void R040_DECLARE_MESTRE_DB_OPEN_1()
        {
            /*" -576- EXEC SQL OPEN MESTRE END-EXEC. */

            MESTRE.Open();

        }

        [StopWatch]
        /*" R110-DECLARE-BONUS-DB-DECLARE-1 */
        public void R110_DECLARE_BONUS_DB_DECLARE_1()
        {
            /*" -774- EXEC SQL DECLARE BONUS CURSOR FOR SELECT TIPO_BONUS FROM SEGUROS.LOTBONUS01 WHERE COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL AND NUM_APOLICE = :SINILT01-NUM-APOLICE AND DTINIVIG <= :SINILT01-DTINIVIG AND DTTERVIG >= :SINILT01-DTINIVIG END-EXEC. */
            BONUS = new SI0864B_BONUS(true);
            string GetQuery_BONUS()
            {
                var query = @$"SELECT TIPO_BONUS 
							FROM SEGUROS.LOTBONUS01 
							WHERE COD_LOT_FENAL = '{SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL}' 
							AND NUM_APOLICE = '{SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOLICE}' 
							AND DTINIVIG <= '{SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG}' 
							AND DTTERVIG >= '{SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG}'";

                return query;
            }
            BONUS.GetQueryEvent += GetQuery_BONUS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

        [StopWatch]
        /*" R050-FETCH-MESTRE */
        private void R050_FETCH_MESTRE(bool isPerform = false)
        {
            /*" -584- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -598- PERFORM R050_FETCH_MESTRE_DB_FETCH_1 */

            R050_FETCH_MESTRE_DB_FETCH_1();

            /*" -601- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -602- MOVE 'SIM' TO W-FIM-MESTRE */
                _.Move("SIM", W_INICIO_WORK.W_FIM_MESTRE);

                /*" -602- PERFORM R050_FETCH_MESTRE_DB_CLOSE_1 */

                R050_FETCH_MESTRE_DB_CLOSE_1();

                /*" -604- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -605- DISPLAY 'ERRO DE CLOSE DO CURSOR MESTRE' */
                    _.Display($"ERRO DE CLOSE DO CURSOR MESTRE");

                    /*" -607- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -608- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -609- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -610- DISPLAY 'ERRO LEITURA CURSOR SINISTRO MESTRE.......' */
                _.Display($"ERRO LEITURA CURSOR SINISTRO MESTRE.......");

                /*" -611- DISPLAY 'NUM APOLICE : ' RELATORI-NUM-APOLICE */
                _.Display($"NUM APOLICE : {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                /*" -612- DISPLAY 'NUM SINISTRO: ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"NUM SINISTRO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -613- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -613- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R050-FETCH-MESTRE-DB-FETCH-1 */
        public void R050_FETCH_MESTRE_DB_FETCH_1()
        {
            /*" -598- EXEC SQL FETCH MESTRE INTO :SINISMES-NUM-APOL-SINISTRO, :SINISMES-NUM-APOLICE, :SINISMES-COD-CAUSA, :SINISMES-RAMO, :SINISMES-SIT-REGISTRO, :SINISMES-DATA-OCORRENCIA, :SINISCAU-DESCR-CAUSA, :SINILT01-COD-LOT-CEF, :SINILT01-NUM-APOLICE, :SINILT01-COD-LOT-FENAL, :SINILT01-DTINIVIG, :SINILT01-COD-COBERTURA, :CLIENTES-NOME-RAZAO END-EXEC. */

            if (MESTRE.Fetch())
            {
                _.Move(MESTRE.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(MESTRE.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(MESTRE.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(MESTRE.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(MESTRE.SINISMES_SIT_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);
                _.Move(MESTRE.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(MESTRE.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
                _.Move(MESTRE.SINILT01_COD_LOT_CEF, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF);
                _.Move(MESTRE.SINILT01_NUM_APOLICE, SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOLICE);
                _.Move(MESTRE.SINILT01_COD_LOT_FENAL, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL);
                _.Move(MESTRE.SINILT01_DTINIVIG, SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG);
                _.Move(MESTRE.SINILT01_COD_COBERTURA, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA);
                _.Move(MESTRE.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }

        }

        [StopWatch]
        /*" R050-FETCH-MESTRE-DB-CLOSE-1 */
        public void R050_FETCH_MESTRE_DB_CLOSE_1()
        {
            /*" -602- EXEC SQL CLOSE MESTRE END-EXEC */

            MESTRE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/

        [StopWatch]
        /*" R060-PROCESSA-MESTRE */
        private void R060_PROCESSA_MESTRE(bool isPerform = false)
        {
            /*" -623- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -624- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -626- MOVE RELATORI-PERI-FINAL TO SI1001S-DATA-FIM */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -628- CALL 'SI1017S' USING SI1001S-PARAMETROS */
            _.Call("SI1017S", LBSI1001.SI1001S_PARAMETROS);

            /*" -629- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -633- DISPLAY 'PROBLEMA CALL SI1017S' ' ' RELATORI-NUM-APOLICE ' ' SINISMES-NUM-APOL-SINISTRO ' ' RELATORI-PERI-FINAL */

                $"PROBLEMA CALL SI1017S {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO} {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}"
                .Display();

                /*" -634- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -635- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -636- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -637- ELSE */
            }
            else
            {


                /*" -641- MOVE SI1001S-VALOR-CALCULADO TO HOST-PENDENTE. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_PENDENTE);
            }


            /*" -643- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -644- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -646- MOVE RELATORI-PERI-FINAL TO SI1001S-DATA-FIM */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -648- CALL 'SI1018S' USING SI1001S-PARAMETROS */
            _.Call("SI1018S", LBSI1001.SI1001S_PARAMETROS);

            /*" -649- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -653- DISPLAY 'PROBLEMA CALL SI1018S ' ' ' RELATORI-NUM-APOLICE ' ' SINISMES-NUM-APOL-SINISTRO ' ' RELATORI-PERI-FINAL */

                $"PROBLEMA CALL SI1018S  {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO} {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}"
                .Display();

                /*" -654- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -655- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -656- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -657- ELSE */
            }
            else
            {


                /*" -661- MOVE SI1001S-VALOR-CALCULADO TO HOST-PAGO. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_PAGO);
            }


            /*" -663- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -664- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -666- MOVE RELATORI-PERI-FINAL TO SI1001S-DATA-FIM */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -668- CALL 'SI1019S' USING SI1001S-PARAMETROS */
            _.Call("SI1019S", LBSI1001.SI1001S_PARAMETROS);

            /*" -669- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -673- DISPLAY 'PROBLEMA CALL SI1019S ' ' ' RELATORI-NUM-APOLICE ' ' SINISMES-NUM-APOL-SINISTRO ' ' RELATORI-PERI-FINAL */

                $"PROBLEMA CALL SI1019S  {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO} {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}"
                .Display();

                /*" -674- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -675- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -676- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -677- ELSE */
            }
            else
            {


                /*" -679- MOVE SI1001S-VALOR-CALCULADO TO HOST-AVISADO. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_AVISADO);
            }


            /*" -681- PERFORM R100-BUSCAR-INFO-LOTERICO01 THRU R100-EXIT. */

            R100_BUSCAR_INFO_LOTERICO01(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/


            /*" -682- PERFORM R110-DECLARE-BONUS THRU R110-EXIT. */

            R110_DECLARE_BONUS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


            /*" -683- MOVE 'NAO' TO W-FIM-BONUS. */
            _.Move("NAO", W_INICIO_WORK.W_FIM_BONUS);

            /*" -684- PERFORM R120-FETCH-BONUS. */

            R120_FETCH_BONUS(true);

            /*" -685- MOVE 0 TO W-CNT-BONUS. */
            _.Move(0, W_INICIO_WORK.W_CNT_BONUS);

            /*" -689- MOVE SPACES TO C01-DESCR-BONUS(1) C01-DESCR-BONUS(2) C01-DESCR-BONUS(3) C01-DESCR-BONUS(4). */
            _.Move("", FILLER01.LD01.C01_BONUS[1].C01_DESCR_BONUS, FILLER01.LD01.C01_BONUS[2].C01_DESCR_BONUS, FILLER01.LD01.C01_BONUS[3].C01_DESCR_BONUS, FILLER01.LD01.C01_BONUS[4].C01_DESCR_BONUS);

            /*" -694- MOVE SPACES TO C01-SEPARADOR(1) C01-SEPARADOR(2) C01-SEPARADOR(3) C01-SEPARADOR(4). */
            _.Move("", FILLER01.LD01.C01_BONUS[1].C01_SEPARADOR, FILLER01.LD01.C01_BONUS[2].C01_SEPARADOR, FILLER01.LD01.C01_BONUS[3].C01_SEPARADOR, FILLER01.LD01.C01_BONUS[4].C01_SEPARADOR);

            /*" -695- IF W-FIM-BONUS EQUAL 'SIM' */

            if (W_INICIO_WORK.W_FIM_BONUS == "SIM")
            {

                /*" -699- MOVE 'NAO TEM         ' TO C01-DESCR-BONUS(1) C01-DESCR-BONUS(2) C01-DESCR-BONUS(3) C01-DESCR-BONUS(4) */
                _.Move("NAO TEM         ", FILLER01.LD01.C01_BONUS[1].C01_DESCR_BONUS, FILLER01.LD01.C01_BONUS[2].C01_DESCR_BONUS, FILLER01.LD01.C01_BONUS[3].C01_DESCR_BONUS, FILLER01.LD01.C01_BONUS[4].C01_DESCR_BONUS);

                /*" -703- MOVE ';' TO C01-SEPARADOR(1) C01-SEPARADOR(2) C01-SEPARADOR(3) C01-SEPARADOR(4) */
                _.Move(";", FILLER01.LD01.C01_BONUS[1].C01_SEPARADOR, FILLER01.LD01.C01_BONUS[2].C01_SEPARADOR, FILLER01.LD01.C01_BONUS[3].C01_SEPARADOR, FILLER01.LD01.C01_BONUS[4].C01_SEPARADOR);

                /*" -705- END-IF. */
            }


            /*" -708- PERFORM R130-PROCESSAR-BONUS UNTIL W-FIM-BONUS EQUAL 'SIM' . */

            while (!(W_INICIO_WORK.W_FIM_BONUS == "SIM"))
            {

                R130_PROCESSAR_BONUS(true);
            }

            /*" -710- PERFORM R150-BUSCAR-IMP-SEGURADA THRU R150-EXIT. */

            R150_BUSCAR_IMP_SEGURADA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R150_EXIT*/


            /*" -711- IF SINISMES-SIT-REGISTRO = '2' */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO == "2")
            {

                /*" -712- PERFORM R160-BUSCA-DATA-CANCELAMENTO THRU R160-EXIT */

                R160_BUSCA_DATA_CANCELAMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/


                /*" -713- ELSE */
            }
            else
            {


                /*" -714- PERFORM R170-BUSCAR-DATA-PAGAMENTO THRU R170-EXIT */

                R170_BUSCAR_DATA_PAGAMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/


                /*" -716- END-IF. */
            }


            /*" -718- PERFORM R200-GRAVAR-ARQ-SAIDA THRU R200-EXIT. */

            R200_GRAVAR_ARQ_SAIDA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/


            /*" -718- PERFORM R050-FETCH-MESTRE THRU R050-EXIT. */

            R050_FETCH_MESTRE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R060_EXIT*/

        [StopWatch]
        /*" R100-BUSCAR-INFO-LOTERICO01 */
        private void R100_BUSCAR_INFO_LOTERICO01(bool isPerform = false)
        {
            /*" -726- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -746- PERFORM R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1 */

            R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1();

            /*" -749- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -750- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -751- DISPLAY 'ERRO LEITURA LOTERICO01............' */
                _.Display($"ERRO LEITURA LOTERICO01............");

                /*" -752- DISPLAY 'COD LOT FENAL: ' SINILT01-COD-LOT-FENAL */
                _.Display($"COD LOT FENAL: {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL}");

                /*" -753- DISPLAY 'COD LOT CEF  : ' SINILT01-COD-LOT-CEF */
                _.Display($"COD LOT CEF  : {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF}");

                /*" -754- DISPLAY 'DATA INI.VIG.: ' SINILT01-DTINIVIG */
                _.Display($"DATA INI.VIG.: {SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG}");

                /*" -755- DISPLAY 'NUM APOLICE  : ' SINILT01-NUM-APOLICE */
                _.Display($"NUM APOLICE  : {SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOLICE}");

                /*" -756- DISPLAY 'SINISTRO     : ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO     : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -757- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -757- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R100-BUSCAR-INFO-LOTERICO01-DB-SELECT-1 */
        public void R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1()
        {
            /*" -746- EXEC SQL SELECT NOME_FANTASIA, NUM_ENCEF, NUM_PVCEF, ENDERECO, COMPL_ENDERECO, BAIRRO, CEP, CIDADE, SIGLA_UF, DDD, NUM_FONE INTO :LOTERI01-NOME-FANTASIA, :LOTERI01-NUM-ENCEF, :LOTERI01-NUM-PVCEF, :LOTERI01-ENDERECO, :LOTERI01-COMPL-ENDERECO, :LOTERI01-BAIRRO, :LOTERI01-CEP, :LOTERI01-CIDADE, :LOTERI01-SIGLA-UF, :LOTERI01-DDD, :LOTERI01-NUM-FONE FROM SEGUROS.LOTERICO01 WHERE COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL AND NUM_APOLICE = :SINILT01-NUM-APOLICE AND DTINIVIG = :SINILT01-DTINIVIG END-EXEC. */

            var r100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1 = new R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1()
            {
                SINILT01_COD_LOT_FENAL = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL.ToString(),
                SINILT01_NUM_APOLICE = SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOLICE.ToString(),
                SINILT01_DTINIVIG = SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG.ToString(),
            };

            var executed_1 = R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1.Execute(r100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTERI01_NOME_FANTASIA, LOTERI01.DCLLOTERICO01.LOTERI01_NOME_FANTASIA);
                _.Move(executed_1.LOTERI01_NUM_ENCEF, LOTERI01.DCLLOTERICO01.LOTERI01_NUM_ENCEF);
                _.Move(executed_1.LOTERI01_NUM_PVCEF, LOTERI01.DCLLOTERICO01.LOTERI01_NUM_PVCEF);
                _.Move(executed_1.LOTERI01_ENDERECO, LOTERI01.DCLLOTERICO01.LOTERI01_ENDERECO);
                _.Move(executed_1.LOTERI01_COMPL_ENDERECO, LOTERI01.DCLLOTERICO01.LOTERI01_COMPL_ENDERECO);
                _.Move(executed_1.LOTERI01_BAIRRO, LOTERI01.DCLLOTERICO01.LOTERI01_BAIRRO);
                _.Move(executed_1.LOTERI01_CEP, LOTERI01.DCLLOTERICO01.LOTERI01_CEP);
                _.Move(executed_1.LOTERI01_CIDADE, LOTERI01.DCLLOTERICO01.LOTERI01_CIDADE);
                _.Move(executed_1.LOTERI01_SIGLA_UF, LOTERI01.DCLLOTERICO01.LOTERI01_SIGLA_UF);
                _.Move(executed_1.LOTERI01_DDD, LOTERI01.DCLLOTERICO01.LOTERI01_DDD);
                _.Move(executed_1.LOTERI01_NUM_FONE, LOTERI01.DCLLOTERICO01.LOTERI01_NUM_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R110-DECLARE-BONUS */
        private void R110_DECLARE_BONUS(bool isPerform = false)
        {
            /*" -766- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -774- PERFORM R110_DECLARE_BONUS_DB_DECLARE_1 */

            R110_DECLARE_BONUS_DB_DECLARE_1();

            /*" -777- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -778- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -779- DISPLAY 'ERRO DECLARACAO CURSOR LOTBONUS01....' */
                _.Display($"ERRO DECLARACAO CURSOR LOTBONUS01....");

                /*" -780- DISPLAY 'NUM LOTERICO: ' SINILT01-COD-LOT-FENAL */
                _.Display($"NUM LOTERICO: {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL}");

                /*" -781- DISPLAY 'NUM APOLICE : ' SINILT01-NUM-APOLICE */
                _.Display($"NUM APOLICE : {SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOLICE}");

                /*" -782- DISPLAY 'DATA        : ' SINILT01-DTINIVIG */
                _.Display($"DATA        : {SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG}");

                /*" -783- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -785- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -785- PERFORM R110_DECLARE_BONUS_DB_OPEN_1 */

            R110_DECLARE_BONUS_DB_OPEN_1();

        }

        [StopWatch]
        /*" R110-DECLARE-BONUS-DB-OPEN-1 */
        public void R110_DECLARE_BONUS_DB_OPEN_1()
        {
            /*" -785- EXEC SQL OPEN BONUS END-EXEC. */

            BONUS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R120-FETCH-BONUS */
        private void R120_FETCH_BONUS(bool isPerform = false)
        {
            /*" -794- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -797- PERFORM R120_FETCH_BONUS_DB_FETCH_1 */

            R120_FETCH_BONUS_DB_FETCH_1();

            /*" -800- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -801- MOVE 'SIM' TO W-FIM-BONUS */
                _.Move("SIM", W_INICIO_WORK.W_FIM_BONUS);

                /*" -801- PERFORM R120_FETCH_BONUS_DB_CLOSE_1 */

                R120_FETCH_BONUS_DB_CLOSE_1();

                /*" -803- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -804- DISPLAY 'ERRO DE CLOSE DO CURSOR MESTRE' */
                    _.Display($"ERRO DE CLOSE DO CURSOR MESTRE");

                    /*" -806- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -807- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -808- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -809- DISPLAY 'ERRO LEITURA CURSOR BONUS.......' */
                _.Display($"ERRO LEITURA CURSOR BONUS.......");

                /*" -810- DISPLAY 'NUM LOTERICO: ' SINILT01-COD-LOT-FENAL */
                _.Display($"NUM LOTERICO: {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL}");

                /*" -811- DISPLAY 'NUM APOLICE : ' SINILT01-NUM-APOLICE */
                _.Display($"NUM APOLICE : {SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOLICE}");

                /*" -812- DISPLAY 'DATA        : ' SINILT01-DTINIVIG */
                _.Display($"DATA        : {SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG}");

                /*" -813- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -813- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R120-FETCH-BONUS-DB-FETCH-1 */
        public void R120_FETCH_BONUS_DB_FETCH_1()
        {
            /*" -797- EXEC SQL FETCH BONUS INTO :LOTBONUS-TIPO-BONUS END-EXEC. */

            if (BONUS.Fetch())
            {
                _.Move(BONUS.LOTBONUS_TIPO_BONUS, LOTBONUS.DCLLOTBONUS01.LOTBONUS_TIPO_BONUS);
            }

        }

        [StopWatch]
        /*" R120-FETCH-BONUS-DB-CLOSE-1 */
        public void R120_FETCH_BONUS_DB_CLOSE_1()
        {
            /*" -801- EXEC SQL CLOSE BONUS END-EXEC */

            BONUS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R130-PROCESSAR-BONUS */
        private void R130_PROCESSAR_BONUS(bool isPerform = false)
        {
            /*" -822- PERFORM R140-BUSCA-DESCR-BONUS. */

            R140_BUSCA_DESCR_BONUS(true);

            /*" -822- PERFORM R120-FETCH-BONUS. */

            R120_FETCH_BONUS(true);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/

        [StopWatch]
        /*" R140-BUSCA-DESCR-BONUS */
        private void R140_BUSCA_DESCR_BONUS(bool isPerform = false)
        {
            /*" -836- PERFORM R140_BUSCA_DESCR_BONUS_DB_SELECT_1 */

            R140_BUSCA_DESCR_BONUS_DB_SELECT_1();

            /*" -839- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -840- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -841- DISPLAY 'ERRO DECLARACAO CURSOR BONUS....' */
                _.Display($"ERRO DECLARACAO CURSOR BONUS....");

                /*" -842- DISPLAY 'COD-BONUS : ' LOTBONUS-TIPO-BONUS */
                _.Display($"COD-BONUS : {LOTBONUS.DCLLOTBONUS01.LOTBONUS_TIPO_BONUS}");

                /*" -843- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -845- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -847- ADD 1 TO W-CNT-BONUS. */
            W_INICIO_WORK.W_CNT_BONUS.Value = W_INICIO_WORK.W_CNT_BONUS + 1;

            /*" -848- MOVE LTTIPBON-DESCR-BONUS TO C01-DESCR-BONUS(W-CNT-BONUS). */
            _.Move(LTTIPBON.DCLLT_TIPO_BONUS.LTTIPBON_DESCR_BONUS, FILLER01.LD01.C01_BONUS[W_INICIO_WORK.W_CNT_BONUS].C01_DESCR_BONUS);

            /*" -848- MOVE ';' TO C01-SEPARADOR(W-CNT-BONUS). */
            _.Move(";", FILLER01.LD01.C01_BONUS[W_INICIO_WORK.W_CNT_BONUS].C01_SEPARADOR);

        }

        [StopWatch]
        /*" R140-BUSCA-DESCR-BONUS-DB-SELECT-1 */
        public void R140_BUSCA_DESCR_BONUS_DB_SELECT_1()
        {
            /*" -836- EXEC SQL SELECT DESCR_BONUS INTO :LTTIPBON-DESCR-BONUS FROM SEGUROS.LT_TIPO_BONUS WHERE COD_BONUS = :LOTBONUS-TIPO-BONUS END-EXEC. */

            var r140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1 = new R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1()
            {
                LOTBONUS_TIPO_BONUS = LOTBONUS.DCLLOTBONUS01.LOTBONUS_TIPO_BONUS.ToString(),
            };

            var executed_1 = R140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1.Execute(r140_BUSCA_DESCR_BONUS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTTIPBON_DESCR_BONUS, LTTIPBON.DCLLT_TIPO_BONUS.LTTIPBON_DESCR_BONUS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R140_EXIT*/

        [StopWatch]
        /*" R150-BUSCAR-IMP-SEGURADA */
        private void R150_BUSCAR_IMP_SEGURADA(bool isPerform = false)
        {
            /*" -857- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -866- PERFORM R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1 */

            R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1();

            /*" -869- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -870- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -871- DISPLAY 'ERRO LEITURA TABELA IMPORTANCIA SEGURADA' */
                _.Display($"ERRO LEITURA TABELA IMPORTANCIA SEGURADA");

                /*" -872- DISPLAY 'NUM LOTERICO: ' SINILT01-COD-LOT-FENAL */
                _.Display($"NUM LOTERICO: {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL}");

                /*" -873- DISPLAY 'APOLICE     : ' SINILT01-NUM-APOLICE */
                _.Display($"APOLICE     : {SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOLICE}");

                /*" -874- DISPLAY 'COBERTURA   : ' SINILT01-COD-COBERTURA */
                _.Display($"COBERTURA   : {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA}");

                /*" -875- DISPLAY 'DTINIVIG    : ' SINILT01-DTINIVIG */
                _.Display($"DTINIVIG    : {SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG}");

                /*" -876- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -876- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R150-BUSCAR-IMP-SEGURADA-DB-SELECT-1 */
        public void R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1()
        {
            /*" -866- EXEC SQL SELECT IMP_SEG INTO :LOTISG01-IMP-SEG FROM SEGUROS.LOTIMPSEG01 WHERE COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL AND NUM_APOLICE = :SINILT01-NUM-APOLICE AND COD_COBERTURA = :SINILT01-COD-COBERTURA AND DTINIVIG <= :SINILT01-DTINIVIG AND DTTERVIG >= :SINILT01-DTINIVIG END-EXEC. */

            var r150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1 = new R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1()
            {
                SINILT01_COD_LOT_FENAL = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL.ToString(),
                SINILT01_COD_COBERTURA = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA.ToString(),
                SINILT01_NUM_APOLICE = SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOLICE.ToString(),
                SINILT01_DTINIVIG = SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG.ToString(),
            };

            var executed_1 = R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1.Execute(r150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTISG01_IMP_SEG, LOTISG01.DCLLOTIMPSEG01.LOTISG01_IMP_SEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R150_EXIT*/

        [StopWatch]
        /*" R160-BUSCA-DATA-CANCELAMENTO */
        private void R160_BUSCA_DATA_CANCELAMENTO(bool isPerform = false)
        {
            /*" -885- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -891- PERFORM R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1 */

            R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1();

            /*" -894- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -895- MOVE 'SEM CANCEL' TO C01-DATA-PAGAMENTO */
                _.Move("SEM CANCEL", FILLER01.LD01.C01_DATA_PAGAMENTO);

                /*" -896- ELSE */
            }
            else
            {


                /*" -897- IF SQLCODE NOT EQUAL 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -898- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -899- DISPLAY 'ERRO LEITURA TABELA SINISTRO HISTORICO' */
                    _.Display($"ERRO LEITURA TABELA SINISTRO HISTORICO");

                    /*" -900- DISPLAY 'SINISTRO : ' SINISMES-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                    /*" -901- DISPLAY 'OPERACAO : 107,108,117,118' */
                    _.Display($"OPERACAO : 107,108,117,118");

                    /*" -902- DISPLAY 'DATA MOV : ' SINISHIS-DATA-MOVIMENTO */
                    _.Display($"DATA MOV : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO}");

                    /*" -903- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -904- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -905- ELSE */
                }
                else
                {


                    /*" -906- MOVE SINISHIS-DATA-MOVIMENTO TO C01-DATA-PAGAMENTO */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, FILLER01.LD01.C01_DATA_PAGAMENTO);

                    /*" -907- END-IF */
                }


                /*" -907- END-IF. */
            }


        }

        [StopWatch]
        /*" R160-BUSCA-DATA-CANCELAMENTO-DB-SELECT-1 */
        public void R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1()
        {
            /*" -891- EXEC SQL SELECT MAX (DATA_MOVIMENTO) INTO :SINISHIS-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND COD_OPERACAO IN (107,108,117,118) END-EXEC. */

            var r160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1 = new R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1.Execute(r160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/

        [StopWatch]
        /*" R170-BUSCAR-DATA-PAGAMENTO */
        private void R170_BUSCAR_DATA_PAGAMENTO(bool isPerform = false)
        {
            /*" -916- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -923- PERFORM R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1 */

            R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1();

            /*" -926- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -927- MOVE 'SEM PAGAM.' TO C01-DATA-PAGAMENTO */
                _.Move("SEM PAGAM.", FILLER01.LD01.C01_DATA_PAGAMENTO);

                /*" -928- ELSE */
            }
            else
            {


                /*" -929- IF SQLCODE NOT EQUAL 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -930- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -931- DISPLAY 'ERRO LEITURA TABELA SINISTRO HISTORICO' */
                    _.Display($"ERRO LEITURA TABELA SINISTRO HISTORICO");

                    /*" -932- DISPLAY 'SINISTRO : ' SINISMES-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                    /*" -933- DISPLAY 'OPERACAO : 1003' */
                    _.Display($"OPERACAO : 1003");

                    /*" -934- DISPLAY 'DATA MOV : ' SINISHIS-DATA-MOVIMENTO */
                    _.Display($"DATA MOV : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO}");

                    /*" -935- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -936- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -937- ELSE */
                }
                else
                {


                    /*" -938- MOVE SINISHIS-DATA-MOVIMENTO TO C01-DATA-PAGAMENTO */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, FILLER01.LD01.C01_DATA_PAGAMENTO);

                    /*" -939- END-IF */
                }


                /*" -939- END-IF. */
            }


        }

        [StopWatch]
        /*" R170-BUSCAR-DATA-PAGAMENTO-DB-SELECT-1 */
        public void R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1()
        {
            /*" -923- EXEC SQL SELECT DATA_MOVIMENTO INTO :SINISHIS-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND COD_OPERACAO = 1003 AND SIT_REGISTRO <> '2' END-EXEC. */

            var r170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1 = new R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1.Execute(r170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/

        [StopWatch]
        /*" R200-GRAVAR-ARQ-SAIDA */
        private void R200_GRAVAR_ARQ_SAIDA(bool isPerform = false)
        {
            /*" -948- MOVE CLIENTES-NOME-RAZAO TO C01-NOME-LOTERICO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, FILLER01.LD01.C01_NOME_LOTERICO);

            /*" -949- MOVE LOTERI01-NUM-ENCEF TO C01-ESCRIT-NEGOC. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUM_ENCEF, FILLER01.LD01.C01_ESCRIT_NEGOC);

            /*" -950- MOVE LOTERI01-NUM-PVCEF TO C01-AGENCIA-VINC. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUM_PVCEF, FILLER01.LD01.C01_AGENCIA_VINC);

            /*" -951- MOVE RELATORI-DATA-SOLICITACAO TO C01-DATA-SOLIC. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO, FILLER01.LD01.C01_DATA_SOLIC);

            /*" -952- MOVE SISTEMAS-DATA-MOV-ABERTO TO C01-DATA-PROC. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FILLER01.LD01.C01_DATA_PROC);

            /*" -953- IF SINISMES-SIT-REGISTRO = '2' */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO == "2")
            {

                /*" -954- MOVE 'CANCELADO' TO C01-SIT-SINISTRO */
                _.Move("CANCELADO", FILLER01.LD01.C01_SIT_SINISTRO);

                /*" -955- ELSE */
            }
            else
            {


                /*" -956- MOVE SPACES TO C01-SIT-SINISTRO */
                _.Move("", FILLER01.LD01.C01_SIT_SINISTRO);

                /*" -957- END-IF. */
            }


            /*" -958- MOVE SINISMES-NUM-APOLICE TO C01-APOLICE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, FILLER01.LD01.C01_APOLICE);

            /*" -959- MOVE SINISMES-NUM-APOL-SINISTRO TO C01-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, FILLER01.LD01.C01_SINISTRO);

            /*" -960- MOVE SINISCAU-DESCR-CAUSA TO C01-CAUSA-SINISTRO. */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, FILLER01.LD01.C01_CAUSA_SINISTRO);

            /*" -961- MOVE SINISMES-DATA-OCORRENCIA TO C01-DATA-OCORRENCIA. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, FILLER01.LD01.C01_DATA_OCORRENCIA);

            /*" -962- MOVE SINILT01-COD-LOT-FENAL TO C01-NUM-LOTERICO. */
            _.Move(SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL, FILLER01.LD01.C01_NUM_LOTERICO);

            /*" -963- MOVE LOTERI01-NOME-FANTASIA TO C01-NOME-FANT. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NOME_FANTASIA, FILLER01.LD01.C01_NOME_FANT);

            /*" -964- MOVE LOTERI01-ENDERECO TO C01-ENDERECO. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_ENDERECO, FILLER01.LD01.C01_ENDERECO);

            /*" -965- MOVE LOTERI01-BAIRRO TO C01-BAIRRO. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_BAIRRO, FILLER01.LD01.C01_BAIRRO);

            /*" -966- MOVE LOTERI01-CEP TO WGD-CEP. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_CEP, W_INICIO_WORK.WGD_CEP);

            /*" -967- MOVE WGD-CEP-PRINC TO C01-CEP. */
            _.Move(W_INICIO_WORK.FILLER_0.WGD_CEP_PRINC, FILLER01.LD01.C01_CEP);

            /*" -968- MOVE WGD-CEP-EXTENS TO C01-COMPL-CEP. */
            _.Move(W_INICIO_WORK.FILLER_0.WGD_CEP_EXTENS, FILLER01.LD01.C01_COMPL_CEP);

            /*" -969- MOVE LOTERI01-CIDADE TO C01-CIDADE. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_CIDADE, FILLER01.LD01.C01_CIDADE);

            /*" -970- MOVE LOTERI01-SIGLA-UF TO C01-UF. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_SIGLA_UF, FILLER01.LD01.C01_UF);

            /*" -971- MOVE LOTERI01-DDD TO C01-DDD. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_DDD, FILLER01.LD01.C01_DDD);

            /*" -972- MOVE LOTERI01-NUM-FONE TO C01-TELEFONE. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUM_FONE, FILLER01.LD01.C01_TELEFONE);

            /*" -973- MOVE HOST-AVISADO TO C01-AVISADO. */
            _.Move(HOST_AVISADO, FILLER01.LD01.C01_AVISADO);

            /*" -974- MOVE HOST-PAGO TO C01-PAGO. */
            _.Move(HOST_PAGO, FILLER01.LD01.C01_PAGO);

            /*" -975- MOVE HOST-PENDENTE TO C01-PENDENTE. */
            _.Move(HOST_PENDENTE, FILLER01.LD01.C01_PENDENTE);

            /*" -977- MOVE LOTISG01-IMP-SEG TO C01-IMP-SEGURADA. */
            _.Move(LOTISG01.DCLLOTIMPSEG01.LOTISG01_IMP_SEG, FILLER01.LD01.C01_IMP_SEGURADA);

            /*" -977- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -989- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, FILLER_1.WABEND.WSQLCODE);

            /*" -991- CLOSE ARQ-SAIDA. */
            ARQ_SAIDA.Close();

            /*" -993- DISPLAY WABEND */
            _.Display(FILLER_1.WABEND);

            /*" -993- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC */

            /*" -995- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -999- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -999- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}