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
using Sias.Geral.DB2.GE0540S;

namespace Code
{
    public class GE0540S
    {
        public bool IsCall { get; set; }

        public GE0540S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EMISSAO                            *      */
        /*"      *   PROGRAMA ...............  GE0540S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST COMPUTER                      *      */
        /*"      *   PROGRAMADOR ............  FAST COMPUTER                      *      */
        /*"      *   DATA CODIFICACAO .......  12/03/2008                         *      */
        /*"      *   VERSAO .................  18/03/2008                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  PROJETO REDUCAO DE CHEQUES         *      */
        /*"      *                             SUBROTINA CHAMADA PELO PGM         *      */
        /*"      *                             EM0202B.                           *      */
        /*"      *                             VERIFICA SE CONTA PARA APOLICE /   *      */
        /*"      *                             ENDOSSO ESTA VALIDA, GERANDO       *      */
        /*"      *                             CREDITO EM CONTA CORRENTE POR MEIO *      */
        /*"      *                             DO CONVENIO 900662 E INIBINDO A    *      */
        /*"      *                             EMISSAO DE CHEQUE.                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  * EM 02/05/2024 - JAZZ 576989                                    *      */
        /*"      *               - CORRIGIR MOVIMENTO DO CEP PARA ODS.            *      */
        /*"      *                 DE INTEGER  PARA  CHAR.                        *      */
        /*"      *               - HERVAL SOUZA - ACT                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  *   VERSAO 04 - CADMUS 163382 - TRATAMENTO DE ERRO               *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/05/2018 - LISIANE BRAGANCA SOARES                      *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  *   VERSAO 03 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * 08/11/2013  CADMUS: CAD74582 - COREON                          *      */
        /*"      *             ALTERACAO:  INCLUSAO DO TIPO DE CONTA NA CONDICAO  *      */
        /*"      *                         DO ACESSO DA TABELA GE_CLI_DADOS_FINANC*      */
        /*"      *                         P/ BUSCAR APENAS AS CONTAS DE CREDITO. *      */
        /*"      *                                                                *      */
        /*"      *                                                      VER: V.02 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * 25/03/2013 - CADMUS 73736 - CHEQUE ZERO - COREON               *      */
        /*"      *                                                                *      */
        /*"      * - PARA PRODUTOS AUTO, RECUPERAR :                              *      */
        /*"      *   . O CODIGO DO CLIENTE NA TABELA APOLICE_AUTO.                *      */
        /*"      *   . DADOS DA CONTA DE CREDITO NA TABELA GE_CLI_DADOS_FINANC.   *      */
        /*"      *                                                                *      */
        /*"      *                                                      VER: V.01 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 06/07/2011 - ALEXANDRE CHICON                                  *      */
        /*"      * PARA O NOVO CONVENIO SULAMERICA BUSCAR A CONTA DE CREDITO NA   *      */
        /*"      * TABELA GE_CLI_DADOS_FINANC PARA EFETUAR CREDITO EM CONTA       *      */
        /*"      * CORRENTE POR MEIO DO CONVENIO 921286 (BANCO DO BRASIL)         *      */
        /*"      * BUSCAR POR AC0607                                              *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL03               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL03 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL04               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL04 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COD-AGENCIA-DV       PIC S9(004)     COMP.*/
        public IntBasis VIND_COD_AGENCIA_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COD-OPERACAO         PIC S9(004)     COMP.*/
        public IntBasis VIND_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W.*/
        public GE0540S_W W { get; set; } = new GE0540S_W();
        public class GE0540S_W : VarBasis
        {
            /*"  03        WPARM15-AUX         PIC S9(009)  VALUE ZEROS COMP.*/
            public IntBasis WPARM15_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03        WQUOCIENTE          PIC S9(004)  VALUE ZEROS COMP.*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        WRESTO              PIC S9(004)  VALUE ZEROS COMP.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        WS-DIGCONTA         PIC  9(001)  VALUE ZEROS.*/
            public IntBasis WS_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03        WS-NUMERO           PIC  9(015)  VALUE   ZEROS.*/
            public IntBasis WS_NUMERO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  03        FILLER              REDEFINES    WS-NUMERO.*/
            private _REDEF_GE0540S_FILLER_0 _filler_0 { get; set; }
            public _REDEF_GE0540S_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_GE0540S_FILLER_0(); _.Move(WS_NUMERO, _filler_0); VarBasis.RedefinePassValue(WS_NUMERO, _filler_0, WS_NUMERO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_NUMERO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_NUMERO); }
            }  //Redefines
            public class _REDEF_GE0540S_FILLER_0 : VarBasis
            {
                /*"    10      WS-AGENCIA          PIC  9(004).*/
                public IntBasis WS_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WS-OPERACAO         PIC  9(003).*/
                public IntBasis WS_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      WS-NUMCONTA         PIC  9(008).*/
                public IntBasis WS_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03        LPARM15X.*/

                public _REDEF_GE0540S_FILLER_0()
                {
                    WS_AGENCIA.ValueChanged += OnValueChanged;
                    WS_OPERACAO.ValueChanged += OnValueChanged;
                    WS_NUMCONTA.ValueChanged += OnValueChanged;
                }

            }
            public GE0540S_LPARM15X LPARM15X { get; set; } = new GE0540S_LPARM15X();
            public class GE0540S_LPARM15X : VarBasis
            {
                /*"    10      LPARM15             PIC  9(015).*/
                public IntBasis LPARM15 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10      FILLER              REDEFINES   LPARM15.*/
                private _REDEF_GE0540S_FILLER_1 _filler_1 { get; set; }
                public _REDEF_GE0540S_FILLER_1 FILLER_1
                {
                    get { _filler_1 = new _REDEF_GE0540S_FILLER_1(); _.Move(LPARM15, _filler_1); VarBasis.RedefinePassValue(LPARM15, _filler_1, LPARM15); _filler_1.ValueChanged += () => { _.Move(_filler_1, LPARM15); }; return _filler_1; }
                    set { VarBasis.RedefinePassValue(value, _filler_1, LPARM15); }
                }  //Redefines
                public class _REDEF_GE0540S_FILLER_1 : VarBasis
                {
                    /*"      15    LPARM15-1           PIC  9(001).*/
                    public IntBasis LPARM15_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-2           PIC  9(001).*/
                    public IntBasis LPARM15_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-3           PIC  9(001).*/
                    public IntBasis LPARM15_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-4           PIC  9(001).*/
                    public IntBasis LPARM15_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-5           PIC  9(001).*/
                    public IntBasis LPARM15_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-6           PIC  9(001).*/
                    public IntBasis LPARM15_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-7           PIC  9(001).*/
                    public IntBasis LPARM15_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-8           PIC  9(001).*/
                    public IntBasis LPARM15_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-9           PIC  9(001).*/
                    public IntBasis LPARM15_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-10          PIC  9(001).*/
                    public IntBasis LPARM15_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-11          PIC  9(001).*/
                    public IntBasis LPARM15_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-12          PIC  9(001).*/
                    public IntBasis LPARM15_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-13          PIC  9(001).*/
                    public IntBasis LPARM15_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-14          PIC  9(001).*/
                    public IntBasis LPARM15_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-15          PIC  9(001).*/
                    public IntBasis LPARM15_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    10      LPARM15-D1          PIC  9(001).*/

                    public _REDEF_GE0540S_FILLER_1()
                    {
                        LPARM15_1.ValueChanged += OnValueChanged;
                        LPARM15_2.ValueChanged += OnValueChanged;
                        LPARM15_3.ValueChanged += OnValueChanged;
                        LPARM15_4.ValueChanged += OnValueChanged;
                        LPARM15_5.ValueChanged += OnValueChanged;
                        LPARM15_6.ValueChanged += OnValueChanged;
                        LPARM15_7.ValueChanged += OnValueChanged;
                        LPARM15_8.ValueChanged += OnValueChanged;
                        LPARM15_9.ValueChanged += OnValueChanged;
                        LPARM15_10.ValueChanged += OnValueChanged;
                        LPARM15_11.ValueChanged += OnValueChanged;
                        LPARM15_12.ValueChanged += OnValueChanged;
                        LPARM15_13.ValueChanged += OnValueChanged;
                        LPARM15_14.ValueChanged += OnValueChanged;
                        LPARM15_15.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LPARM15_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03        W-NUM-CGC-INTEIRO-A PIC 9(14)    VALUE   ZEROS.*/
            }
            public IntBasis W_NUM_CGC_INTEIRO_A { get; set; } = new IntBasis(new PIC("9", "14", "9(14)"));
            /*"  03        W-NUM-CGC-INTEIRO  REDEFINES  W-NUM-CGC-INTEIRO-A.*/
            private _REDEF_GE0540S_W_NUM_CGC_INTEIRO _w_num_cgc_inteiro { get; set; }
            public _REDEF_GE0540S_W_NUM_CGC_INTEIRO W_NUM_CGC_INTEIRO
            {
                get { _w_num_cgc_inteiro = new _REDEF_GE0540S_W_NUM_CGC_INTEIRO(); _.Move(W_NUM_CGC_INTEIRO_A, _w_num_cgc_inteiro); VarBasis.RedefinePassValue(W_NUM_CGC_INTEIRO_A, _w_num_cgc_inteiro, W_NUM_CGC_INTEIRO_A); _w_num_cgc_inteiro.ValueChanged += () => { _.Move(_w_num_cgc_inteiro, W_NUM_CGC_INTEIRO_A); }; return _w_num_cgc_inteiro; }
                set { VarBasis.RedefinePassValue(value, _w_num_cgc_inteiro, W_NUM_CGC_INTEIRO_A); }
            }  //Redefines
            public class _REDEF_GE0540S_W_NUM_CGC_INTEIRO : VarBasis
            {
                /*"    10      W-NUM-CGC-INTEIRO-NUM         PIC  9(008).*/
                public IntBasis W_NUM_CGC_INTEIRO_NUM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10      W-NUM-CGC-INTEIRO-FILIAL      PIC  9(004).*/
                public IntBasis W_NUM_CGC_INTEIRO_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      W-NUM-CGC-INTEIRO-DV          PIC  9(002).*/
                public IntBasis W_NUM_CGC_INTEIRO_DV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        W-NUM-CPF-INTEIRO-A  PIC 9(011)  VALUE   ZEROS.*/

                public _REDEF_GE0540S_W_NUM_CGC_INTEIRO()
                {
                    W_NUM_CGC_INTEIRO_NUM.ValueChanged += OnValueChanged;
                    W_NUM_CGC_INTEIRO_FILIAL.ValueChanged += OnValueChanged;
                    W_NUM_CGC_INTEIRO_DV.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_CPF_INTEIRO_A { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03        W-NUM-CPF-INTEIRO  REDEFINES  W-NUM-CPF-INTEIRO-A.*/
            private _REDEF_GE0540S_W_NUM_CPF_INTEIRO _w_num_cpf_inteiro { get; set; }
            public _REDEF_GE0540S_W_NUM_CPF_INTEIRO W_NUM_CPF_INTEIRO
            {
                get { _w_num_cpf_inteiro = new _REDEF_GE0540S_W_NUM_CPF_INTEIRO(); _.Move(W_NUM_CPF_INTEIRO_A, _w_num_cpf_inteiro); VarBasis.RedefinePassValue(W_NUM_CPF_INTEIRO_A, _w_num_cpf_inteiro, W_NUM_CPF_INTEIRO_A); _w_num_cpf_inteiro.ValueChanged += () => { _.Move(_w_num_cpf_inteiro, W_NUM_CPF_INTEIRO_A); }; return _w_num_cpf_inteiro; }
                set { VarBasis.RedefinePassValue(value, _w_num_cpf_inteiro, W_NUM_CPF_INTEIRO_A); }
            }  //Redefines
            public class _REDEF_GE0540S_W_NUM_CPF_INTEIRO : VarBasis
            {
                /*"    10      W-NUM-CPF-INTEIRO-NUM         PIC  9(009).*/
                public IntBasis W_NUM_CPF_INTEIRO_NUM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10      W-NUM-CPF-INTEIRO-DV          PIC  9(002).*/
                public IntBasis W_NUM_CPF_INTEIRO_DV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WS-NUM-CTA-CORRENTE  PIC  9(017) VALUE   ZEROS.*/

                public _REDEF_GE0540S_W_NUM_CPF_INTEIRO()
                {
                    W_NUM_CPF_INTEIRO_NUM.ValueChanged += OnValueChanged;
                    W_NUM_CPF_INTEIRO_DV.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("9", "17", "9(017)"));
            /*"  03        FILLER             REDEFINES  WS-NUM-CTA-CORRENTE.*/
            private _REDEF_GE0540S_FILLER_2 _filler_2 { get; set; }
            public _REDEF_GE0540S_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_GE0540S_FILLER_2(); _.Move(WS_NUM_CTA_CORRENTE, _filler_2); VarBasis.RedefinePassValue(WS_NUM_CTA_CORRENTE, _filler_2, WS_NUM_CTA_CORRENTE); _filler_2.ValueChanged += () => { _.Move(_filler_2, WS_NUM_CTA_CORRENTE); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WS_NUM_CTA_CORRENTE); }
            }  //Redefines
            public class _REDEF_GE0540S_FILLER_2 : VarBasis
            {
                /*"    10      WS-OPERACAO-CONTA    PIC  9(004).*/
                public IntBasis WS_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WS-COD-CONTA         PIC  9(012).*/
                public IntBasis WS_COD_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10      WS-DV-CONTA          PIC  9(001).*/
                public IntBasis WS_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03        AUX-DV-CONTA         PIC  X(002)  VALUE  SPACES.*/

                public _REDEF_GE0540S_FILLER_2()
                {
                    WS_OPERACAO_CONTA.ValueChanged += OnValueChanged;
                    WS_COD_CONTA.ValueChanged += OnValueChanged;
                    WS_DV_CONTA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis AUX_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  03        FILLER             REDEFINES  AUX-DV-CONTA.*/
            private _REDEF_GE0540S_FILLER_3 _filler_3 { get; set; }
            public _REDEF_GE0540S_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_GE0540S_FILLER_3(); _.Move(AUX_DV_CONTA, _filler_3); VarBasis.RedefinePassValue(AUX_DV_CONTA, _filler_3, AUX_DV_CONTA); _filler_3.ValueChanged += () => { _.Move(_filler_3, AUX_DV_CONTA); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, AUX_DV_CONTA); }
            }  //Redefines
            public class _REDEF_GE0540S_FILLER_3 : VarBasis
            {
                /*"    10      AUX-DV-CONTA-NUM     PIC  9(001).*/
                public IntBasis AUX_DV_CONTA_NUM { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10      FILLER               PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  03        WS-IND1                PIC S9(9)  COMP  VALUE ZEROS.*/

                public _REDEF_GE0540S_FILLER_3()
                {
                    AUX_DV_CONTA_NUM.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"  03        WS-IND2                PIC S9(9)  COMP  VALUE ZEROS.*/
            public IntBasis WS_IND2 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"  03        WS-AGENC01.*/
            public GE0540S_WS_AGENC01 WS_AGENC01 { get; set; } = new GE0540S_WS_AGENC01();
            public class GE0540S_WS_AGENC01 : VarBasis
            {
                /*"    05      WS-AGENC-AG            PIC  X(4)  VALUE  SPACES.*/
                public StringBasis WS_AGENC_AG { get; set; } = new StringBasis(new PIC("X", "4", "X(4)"), @"");
                /*"  03        WS-AGENC10             PIC  X(4)  VALUE  SPACES.*/
            }
            public StringBasis WS_AGENC10 { get; set; } = new StringBasis(new PIC("X", "4", "X(4)"), @"");
            /*"  03        FILLER  REDEFINES WS-AGENC10.*/
            private _REDEF_GE0540S_FILLER_5 _filler_5 { get; set; }
            public _REDEF_GE0540S_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_GE0540S_FILLER_5(); _.Move(WS_AGENC10, _filler_5); VarBasis.RedefinePassValue(WS_AGENC10, _filler_5, WS_AGENC10); _filler_5.ValueChanged += () => { _.Move(_filler_5, WS_AGENC10); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WS_AGENC10); }
            }  //Redefines
            public class _REDEF_GE0540S_FILLER_5 : VarBasis
            {
                /*"    05      CHAR10 OCCURS 5 TIMES  PIC  X(1).*/
                public ListBasis<StringBasis, string> CHAR10 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(1)."), 5);
                /*"  03        WS-AGENC20             PIC  9(4).*/

                public _REDEF_GE0540S_FILLER_5()
                {
                    CHAR10.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_AGENC20 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
            /*"  03        FILLER  REDEFINES WS-AGENC20.*/
            private _REDEF_GE0540S_FILLER_6 _filler_6 { get; set; }
            public _REDEF_GE0540S_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_GE0540S_FILLER_6(); _.Move(WS_AGENC20, _filler_6); VarBasis.RedefinePassValue(WS_AGENC20, _filler_6, WS_AGENC20); _filler_6.ValueChanged += () => { _.Move(_filler_6, WS_AGENC20); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WS_AGENC20); }
            }  //Redefines
            public class _REDEF_GE0540S_FILLER_6 : VarBasis
            {
                /*"    05      CHAR20 OCCURS 5 TIMES  PIC  X(1).*/
                public ListBasis<StringBasis, string> CHAR20 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(1)."), 5);
                /*"   03 WABEND.*/
                public GE0540S_WABEND WABEND { get; set; } = new GE0540S_WABEND();
                public class GE0540S_WABEND : VarBasis
                {
                    /*"      05 FILLER                   PIC X(10) VALUE         ' GE0540S  '.*/
                    public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" GE0540S  ");
                    /*"      05 FILLER                   PIC X(28) VALUE         ' *** ERRO  EXEC SQL  NUMERO '.*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @" *** ERRO  EXEC SQL  NUMERO ");
                    /*"      05 WNR-EXEC-SQL             PIC X(04) VALUE SPACES.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                    /*"      05 FILLER                   PIC X(14) VALUE         '    SQLCODE = '.*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE = ");
                    /*"      05 WSQLCODE                 PIC ZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                    /*"      05 FILLER                   PIC X(14) VALUE         '   SQLERRD1 = '.*/
                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"   SQLERRD1 = ");
                    /*"      05 WSQLERRD1                PIC ZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                    /*"      05 FILLER                   PIC X(14) VALUE         '   SQLERRD2 = '.*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"   SQLERRD2 = ");
                    /*"      05 WSQLERRD2                PIC ZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                    /*"   03 WSQLERR.*/

                    public GE0540S_WABEND()
                    {
                        FILLER_7.ValueChanged += OnValueChanged;
                        FILLER_8.ValueChanged += OnValueChanged;
                        WNR_EXEC_SQL.ValueChanged += OnValueChanged;
                        FILLER_9.ValueChanged += OnValueChanged;
                        WSQLCODE.ValueChanged += OnValueChanged;
                        FILLER_10.ValueChanged += OnValueChanged;
                        WSQLERRD1.ValueChanged += OnValueChanged;
                        FILLER_11.ValueChanged += OnValueChanged;
                        WSQLERRD2.ValueChanged += OnValueChanged;
                    }

                }
                public GE0540S_WSQLERR WSQLERR { get; set; } = new GE0540S_WSQLERR();
                public class GE0540S_WSQLERR : VarBasis
                {
                    /*"      05 FILLER                   PIC X(14) VALUE         ' *** SQLERRMC '.*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @" *** SQLERRMC ");
                    /*"      05 WSQLERRMC                PIC X(70) VALUE SPACES.*/
                    public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(70)"), @"");
                    /*"01 LK-PF-PARAMETRO.*/

                    public GE0540S_WSQLERR()
                    {
                        FILLER_12.ValueChanged += OnValueChanged;
                        WSQLERRMC.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_GE0540S_FILLER_6()
                {
                    CHAR20.ValueChanged += OnValueChanged;
                    WABEND.ValueChanged += OnValueChanged;
                    WSQLERR.ValueChanged += OnValueChanged;
                }

            }
        }
        public GE0540S_LK_PF_PARAMETRO LK_PF_PARAMETRO { get; set; } = new GE0540S_LK_PF_PARAMETRO();
        public class GE0540S_LK_PF_PARAMETRO : VarBasis
        {
            /*"   05 LK-PF-TIPO-UTILIZACAO         PIC  9(001).*/
            public IntBasis LK_PF_TIPO_UTILIZACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   05 LK-PF-PESSOA-ESPECIAL         PIC  X(001).*/
            public StringBasis LK_PF_PESSOA_ESPECIAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PF-PROGRAMA-CHAMADOR       PIC  X(008).*/
            public StringBasis LK_PF_PROGRAMA_CHAMADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-PF-NOME-USUARIO            PIC  X(008).*/
            public StringBasis LK_PF_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-PF-NUM-PESSOA              PIC S9(009)     COMP.*/
            public IntBasis LK_PF_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PF-DTH-CADASTRAMENTO       PIC  X(026).*/
            public StringBasis LK_PF_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"   05 LK-PF-NUM-DV-PESSOA           PIC S9(004)     COMP.*/
            public IntBasis LK_PF_NUM_DV_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PF-IND-PESSOA              PIC  X(001).*/
            public StringBasis LK_PF_IND_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PF-STA-INF-INTEGRA         PIC  X(001).*/
            public StringBasis LK_PF_STA_INF_INTEGRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PF-NUM-CPF                 PIC S9(009)     COMP.*/
            public IntBasis LK_PF_NUM_CPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PF-NUM-DV-CPF              PIC S9(004)     COMP.*/
            public IntBasis LK_PF_NUM_DV_CPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PF-NOM-PESSOA              PIC  X(200).*/
            public StringBasis LK_PF_NOM_PESSOA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"   05 LK-PF-DTH-NASCIMENTO          PIC  X(010).*/
            public StringBasis LK_PF_DTH_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05 LK-PF-STA-SEXO                PIC  X(001).*/
            public StringBasis LK_PF_STA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PF-IND-ESTADO-CIVIL        PIC  X(001).*/
            public StringBasis LK_PF_IND_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PF-STA-PESSOA              PIC  X(001).*/
            public StringBasis LK_PF_STA_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PF-NOM-TRATAMENTO          PIC  X(015).*/
            public StringBasis LK_PF_NOM_TRATAMENTO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"   05 LK-PF-COD-UF                  PIC  X(002).*/
            public StringBasis LK_PF_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05 LK-PF-NUM-MUNICIPIO           PIC S9(009)     COMP.*/
            public IntBasis LK_PF_NUM_MUNICIPIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PF-NUM-INSC-SOCIAL         PIC S9(010)     COMP-3.*/
            public IntBasis LK_PF_NUM_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "10", "S9(010)"));
            /*"   05 LK-PF-NUM-DV-INSC-SOCIAL      PIC S9(004)     COMP.*/
            public IntBasis LK_PF_NUM_DV_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PF-NUM-GRAU-INSTRUCAO      PIC S9(004)     COMP.*/
            public IntBasis LK_PF_NUM_GRAU_INSTRUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PF-NOM-REDUZIDO            PIC  X(025).*/
            public StringBasis LK_PF_NOM_REDUZIDO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05 LK-PF-COD-CBO                 PIC  X(010).*/
            public StringBasis LK_PF_COD_CBO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05 LK-PF-NOM-PRIMEIRO            PIC  X(025).*/
            public StringBasis LK_PF_NOM_PRIMEIRO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05 LK-PF-NOM-ULTIMO              PIC  X(025).*/
            public StringBasis LK_PF_NOM_ULTIMO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05 LK-PF-PARAMETROS-SAIDA.*/
            public GE0540S_LK_PF_PARAMETROS_SAIDA LK_PF_PARAMETROS_SAIDA { get; set; } = new GE0540S_LK_PF_PARAMETROS_SAIDA();
            public class GE0540S_LK_PF_PARAMETROS_SAIDA : VarBasis
            {
                /*"      10 LK-PF-MSG-ADICIONAL      PIC  X(080).*/
                public StringBasis LK_PF_MSG_ADICIONAL { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-PF-IND-ERRO           PIC  X(003).*/
                public StringBasis LK_PF_IND_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10 LK-PF-MSG-ERRO           PIC  X(080).*/
                public StringBasis LK_PF_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-PF-SQLCODE            PIC S9(004)     COMP.*/
                public IntBasis LK_PF_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 LK-PF-NOME-TABELA        PIC  X(030).*/
                public StringBasis LK_PF_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"01 LK-PJ-PARAMETRO.*/
            }
        }
        public GE0540S_LK_PJ_PARAMETRO LK_PJ_PARAMETRO { get; set; } = new GE0540S_LK_PJ_PARAMETRO();
        public class GE0540S_LK_PJ_PARAMETRO : VarBasis
        {
            /*"   05 LK-PJ-TIPO-UTILIZACAO         PIC  9(001).*/
            public IntBasis LK_PJ_TIPO_UTILIZACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   05 LK-PJ-PESSOA-ESPECIAL         PIC  X(001).*/
            public StringBasis LK_PJ_PESSOA_ESPECIAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PJ-PROGRAMA-CHAMADOR       PIC  X(008).*/
            public StringBasis LK_PJ_PROGRAMA_CHAMADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-PJ-NOME-USUARIO            PIC  X(008).*/
            public StringBasis LK_PJ_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-PJ-NUM-PESSOA              PIC S9(009)     COMP.*/
            public IntBasis LK_PJ_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PJ-DTH-CADASTRAMENTO       PIC  X(026).*/
            public StringBasis LK_PJ_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"   05 LK-PJ-NUM-DV-PESSOA           PIC S9(004)     COMP.*/
            public IntBasis LK_PJ_NUM_DV_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PJ-IND-PESSOA              PIC  X(001).*/
            public StringBasis LK_PJ_IND_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PJ-STA-INF-INTEGRA         PIC  X(001).*/
            public StringBasis LK_PJ_STA_INF_INTEGRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PJ-NUM-CNPJ                PIC S9(009)     COMP.*/
            public IntBasis LK_PJ_NUM_CNPJ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PJ-NUM-FILIAL              PIC S9(004)     COMP.*/
            public IntBasis LK_PJ_NUM_FILIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PJ-NUM-DV-CNPJ             PIC S9(004)     COMP.*/
            public IntBasis LK_PJ_NUM_DV_CNPJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PJ-NOM-RAZAO-SOCIAL        PIC  X(200).*/
            public StringBasis LK_PJ_NOM_RAZAO_SOCIAL { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"   05 LK-PJ-STA-PESSOA              PIC  X(001).*/
            public StringBasis LK_PJ_STA_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PJ-NUM-RAMO-ATIVIDADE      PIC S9(009)     COMP.*/
            public IntBasis LK_PJ_NUM_RAMO_ATIVIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PJ-DTH-FUNDACAO            PIC  X(010).*/
            public StringBasis LK_PJ_DTH_FUNDACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05 LK-PJ-NOM-FANTASIA            PIC  X(100).*/
            public StringBasis LK_PJ_NOM_FANTASIA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
            /*"   05 LK-PJ-NOM-SIGLA-PESSOA        PIC  X(040).*/
            public StringBasis LK_PJ_NOM_SIGLA_PESSOA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"   05 LK-PJ-NUM-INSC-ESTADUAL       PIC S9(014)     COMP-3.*/
            public IntBasis LK_PJ_NUM_INSC_ESTADUAL { get; set; } = new IntBasis(new PIC("S9", "14", "S9(014)"));
            /*"   05 LK-PJ-NUM-INSC-MUNICIPAL      PIC S9(014)     COMP-3.*/
            public IntBasis LK_PJ_NUM_INSC_MUNICIPAL { get; set; } = new IntBasis(new PIC("S9", "14", "S9(014)"));
            /*"   05 LK-PJ-COD-UF                  PIC  X(002).*/
            public StringBasis LK_PJ_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05 LK-PJ-NUM-MUNICIPIO           PIC S9(009)     COMP.*/
            public IntBasis LK_PJ_NUM_MUNICIPIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PJ-COD-CNAE                PIC  X(020).*/
            public StringBasis LK_PJ_COD_CNAE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"   05 LK-PJ-NUM-SOCIOS              PIC S9(004)     COMP.*/
            public IntBasis LK_PJ_NUM_SOCIOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PJ-STA-FRANQUIA            PIC  X(001).*/
            public StringBasis LK_PJ_STA_FRANQUIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PJ-IND-FINALIDADE          PIC  X(001).*/
            public StringBasis LK_PJ_IND_FINALIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PJ-PARAMETROS-SAIDA.*/
            public GE0540S_LK_PJ_PARAMETROS_SAIDA LK_PJ_PARAMETROS_SAIDA { get; set; } = new GE0540S_LK_PJ_PARAMETROS_SAIDA();
            public class GE0540S_LK_PJ_PARAMETROS_SAIDA : VarBasis
            {
                /*"      10 LK-PJ-MSG-ADICIONAL      PIC  X(080).*/
                public StringBasis LK_PJ_MSG_ADICIONAL { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-PJ-IND-ERRO           PIC  X(003).*/
                public StringBasis LK_PJ_IND_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10 LK-PJ-MSG-ERRO           PIC  X(080).*/
                public StringBasis LK_PJ_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-PJ-SQLCODE            PIC S9(004)     COMP.*/
                public IntBasis LK_PJ_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 LK-PJ-NOME-TABELA        PIC  X(030).*/
                public StringBasis LK_PJ_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"01 LK-EN-PARAMETRO.*/
            }
        }
        public GE0540S_LK_EN_PARAMETRO LK_EN_PARAMETRO { get; set; } = new GE0540S_LK_EN_PARAMETRO();
        public class GE0540S_LK_EN_PARAMETRO : VarBasis
        {
            /*"   05 LK-EN-TIPO-UTILIZACAO         PIC  9(001).*/
            public IntBasis LK_EN_TIPO_UTILIZACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   05 LK-EN-PROGRAMA-CHAMADOR       PIC  X(008).*/
            public StringBasis LK_EN_PROGRAMA_CHAMADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-EN-NOME-USUARIO            PIC  X(008).*/
            public StringBasis LK_EN_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-EN-NUM-PESSOA              PIC S9(009)     COMP.*/
            public IntBasis LK_EN_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-EN-DTH-CADASTRAMENTO       PIC  X(026).*/
            public StringBasis LK_EN_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"   05 LK-EN-NUM-DV-PESSOA           PIC S9(004)     COMP.*/
            public IntBasis LK_EN_NUM_DV_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-EN-IND-PESSOA              PIC  X(001).*/
            public StringBasis LK_EN_IND_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-EN-STA-INF-INTEGRA         PIC  X(001).*/
            public StringBasis LK_EN_STA_INF_INTEGRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-EN-SEQ-ENDERECO            PIC S9(004)     COMP.*/
            public IntBasis LK_EN_SEQ_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-EN-DTH-CADASTRAMENTO-END   PIC  X(026).*/
            public StringBasis LK_EN_DTH_CADASTRAMENTO_END { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"   05 LK-EN-IND-ENDERECO            PIC  X(001).*/
            public StringBasis LK_EN_IND_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-EN-STA-ENDERECO            PIC  X(001).*/
            public StringBasis LK_EN_STA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-EN-NOM-LOGRADOURO          PIC  X(072).*/
            public StringBasis LK_EN_NOM_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05 LK-EN-DES-NUM-IMOVEL          PIC  X(010).*/
            public StringBasis LK_EN_DES_NUM_IMOVEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05 LK-EN-DES-COMPL-ENDERECO      PIC  X(072).*/
            public StringBasis LK_EN_DES_COMPL_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05 LK-EN-NOM-BAIRRO              PIC  X(072).*/
            public StringBasis LK_EN_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05 LK-EN-NOM-CIDADE              PIC  X(072).*/
            public StringBasis LK_EN_NOM_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05 LK-EN-COD-CEP                 PIC  9(008).*/
            public IntBasis LK_EN_COD_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   05 LK-EN-COD-UF                  PIC  X(002).*/
            public StringBasis LK_EN_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05 LK-EN-STA-CORRESPONDER        PIC  X(001).*/
            public StringBasis LK_EN_STA_CORRESPONDER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-EN-STA-PROPAGANDA          PIC  X(001).*/
            public StringBasis LK_EN_STA_PROPAGANDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-EN-PARAMETROS-SAIDA.*/
            public GE0540S_LK_EN_PARAMETROS_SAIDA LK_EN_PARAMETROS_SAIDA { get; set; } = new GE0540S_LK_EN_PARAMETROS_SAIDA();
            public class GE0540S_LK_EN_PARAMETROS_SAIDA : VarBasis
            {
                /*"      10 LK-EN-MSG-ADICIONAL      PIC  X(080).*/
                public StringBasis LK_EN_MSG_ADICIONAL { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-EN-IND-ERRO           PIC  X(003).*/
                public StringBasis LK_EN_IND_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10 LK-EN-MSG-ERRO           PIC  X(080).*/
                public StringBasis LK_EN_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-EN-SQLCODE            PIC S9(004)     COMP.*/
                public IntBasis LK_EN_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 LK-EN-NOME-TABELA        PIC  X(030).*/
                public StringBasis LK_EN_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"01 LK-BC-PARAMETRO.*/
            }
        }
        public GE0540S_LK_BC_PARAMETRO LK_BC_PARAMETRO { get; set; } = new GE0540S_LK_BC_PARAMETRO();
        public class GE0540S_LK_BC_PARAMETRO : VarBasis
        {
            /*"   05 LK-BC-TIPO-UTILIZACAO         PIC  9(001).*/
            public IntBasis LK_BC_TIPO_UTILIZACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   05 LK-BC-PROGRAMA-CHAMADOR       PIC  X(008).*/
            public StringBasis LK_BC_PROGRAMA_CHAMADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-BC-NOME-USUARIO            PIC  X(008).*/
            public StringBasis LK_BC_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-BC-NUM-PESSOA              PIC S9(009)     COMP.*/
            public IntBasis LK_BC_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-BC-DTH-CADASTRAMENTO       PIC  X(026).*/
            public StringBasis LK_BC_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"   05 LK-BC-NUM-DV-PESSOA           PIC S9(004)     COMP.*/
            public IntBasis LK_BC_NUM_DV_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-BC-IND-PESSOA              PIC  X(001).*/
            public StringBasis LK_BC_IND_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-BC-STA-INF-INTEGRA         PIC  X(001).*/
            public StringBasis LK_BC_STA_INF_INTEGRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-BC-SEQ-CONTA-BANCARIA      PIC S9(004)     COMP.*/
            public IntBasis LK_BC_SEQ_CONTA_BANCARIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-BC-STA-CONTA               PIC  X(001).*/
            public StringBasis LK_BC_STA_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-BC-COD-BANCO               PIC S9(004)     COMP.*/
            public IntBasis LK_BC_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-BC-COD-AGENCIA             PIC S9(004)     COMP.*/
            public IntBasis LK_BC_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-BC-IND-CONTA-BANCARIA      PIC S9(004)     COMP.*/
            public IntBasis LK_BC_IND_CONTA_BANCARIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-BC-NUM-CONTA               PIC S9(013)     COMP-3.*/
            public IntBasis LK_BC_NUM_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"   05 LK-BC-NUM-DV-CONTA            PIC  X(002).*/
            public StringBasis LK_BC_NUM_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05 LK-BC-NUM-OPERACAO-CONTA      PIC S9(004)     COMP.*/
            public IntBasis LK_BC_NUM_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-BC-PARAMETROS-SAIDA.*/
            public GE0540S_LK_BC_PARAMETROS_SAIDA LK_BC_PARAMETROS_SAIDA { get; set; } = new GE0540S_LK_BC_PARAMETROS_SAIDA();
            public class GE0540S_LK_BC_PARAMETROS_SAIDA : VarBasis
            {
                /*"      10 LK-BC-MSG-ADICIONAL      PIC  X(080).*/
                public StringBasis LK_BC_MSG_ADICIONAL { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-BC-IND-ERRO           PIC  X(003).*/
                public StringBasis LK_BC_IND_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10 LK-BC-MSG-ERRO           PIC  X(080).*/
                public StringBasis LK_BC_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-BC-SQLCODE            PIC S9(004)     COMP.*/
                public IntBasis LK_BC_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 LK-BC-NOME-TABELA        PIC  X(030).*/
                public StringBasis LK_BC_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"01 LK-LEGADO-PARAMETRO.*/
            }
        }
        public GE0540S_LK_LEGADO_PARAMETRO LK_LEGADO_PARAMETRO { get; set; } = new GE0540S_LK_LEGADO_PARAMETRO();
        public class GE0540S_LK_LEGADO_PARAMETRO : VarBasis
        {
            /*"   05 LK-COD-OPERACAO               PIC S9(004)     COMP.*/
            public IntBasis LK_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-NUM-APOLICE                PIC S9(013)     COMP-3.*/
            public IntBasis LK_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"   05 LK-NUM-ENDOSSO                PIC S9(009)     COMP.*/
            public IntBasis LK_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-NUM-PARCELA                PIC S9(004)     COMP.*/
            public IntBasis LK_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-OCORR-HISTORICO            PIC S9(004)     COMP.*/
            public IntBasis LK_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-NUM-PESSOA                 PIC S9(009)     COMP.*/
            public IntBasis LK_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-NUM-OCORR-MOVTO            PIC S9(009)     COMP.*/
            public IntBasis LK_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-TABELA-PONTEIRO OCCURS 30 TIMES.*/
            public ListBasis<GE0540S_LK_TABELA_PONTEIRO> LK_TABELA_PONTEIRO { get; set; } = new ListBasis<GE0540S_LK_TABELA_PONTEIRO>(30);
            public class GE0540S_LK_TABELA_PONTEIRO : VarBasis
            {
                /*"      10 LK-IND-ENTIDADE-PEDIDA     PIC S9(004)     COMP.*/
                public IntBasis LK_IND_ENTIDADE_PEDIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 LK-IND-INFORMACAO-PEDIDA   PIC  X(001).*/
                public StringBasis LK_IND_INFORMACAO_PEDIDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10 LK-SEQ-ENTIDADE            PIC S9(004)     COMP.*/
                public IntBasis LK_SEQ_ENTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"   05 LK-COD-EVENTO                 PIC S9(004)     COMP.*/
            }
            public IntBasis LK_COD_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-IDE-SISTEMA                PIC  X(002).*/
            public StringBasis LK_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05 LK-DTH-MOVIMENTO              PIC  X(010).*/
            public StringBasis LK_DTH_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05 LK-IND-ESTRUTURA              PIC S9(004)     COMP.*/
            public IntBasis LK_IND_ESTRUTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-IND-ORIGEM-FUNC            PIC S9(004)     COMP.*/
            public IntBasis LK_IND_ORIGEM_FUNC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-IND-EVENTO                 PIC S9(004)     COMP.*/
            public IntBasis LK_IND_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-NOM-PROGRAMA               PIC  X(008).*/
            public StringBasis LK_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-COD-USUARIO                PIC  X(008).*/
            public StringBasis LK_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-IND-RELACIONAMENTO         PIC S9(004)     COMP.*/
            public IntBasis LK_IND_RELACIONAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-HORA-OPERACAO              PIC  X(008).*/
            public StringBasis LK_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-COD-FONTE                  PIC S9(004)     COMP.*/
            public IntBasis LK_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-NUM-RCAP                   PIC S9(009)     COMP.*/
            public IntBasis LK_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-NUM-APOL-SINISTRO          PIC S9(013)     COMP-3.*/
            public IntBasis LK_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"   05 LK-COD-OPERACAO-SI            PIC S9(004)     COMP.*/
            public IntBasis LK_COD_OPERACAO_SI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-NUM-CERTIFICADO            PIC S9(015)     COMP-3.*/
            public IntBasis LK_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"   05 LK-NUM-TITULO                 PIC S9(013)     COMP-3.*/
            public IntBasis LK_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"   05 LK-LEGADO-SAIDA.*/
            public GE0540S_LK_LEGADO_SAIDA LK_LEGADO_SAIDA { get; set; } = new GE0540S_LK_LEGADO_SAIDA();
            public class GE0540S_LK_LEGADO_SAIDA : VarBasis
            {
                /*"      10 H-OUT-COD-RETORNO          PIC S9(004)     COMP.*/
                public IntBasis H_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 H-OUT-COD-RETORNO-SQL      PIC S9(004)     COMP.*/
                public IntBasis H_OUT_COD_RETORNO_SQL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 H-OUT-MENSAGEM             PIC  X(070).*/
                public StringBasis H_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
                /*"      10 H-OUT-SQLERRMC             PIC  X(070).*/
                public StringBasis H_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
                /*"      10 H-OUT-SQLSTATE             PIC  X(005).*/
                public StringBasis H_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"01 WPARAMETROS.*/
            }
        }
        public GE0540S_WPARAMETROS WPARAMETROS { get; set; } = new GE0540S_WPARAMETROS();
        public class GE0540S_WPARAMETROS : VarBasis
        {
            /*"   05 WPARM-PROGRAMA              PIC  X(08).*/
            public StringBasis WPARM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"   05 WPARM-NUMAPOL               PIC S9(13) COMP-3.*/
            public IntBasis WPARM_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"   05 WPARM-NRENDOS               PIC S9(09) COMP.*/
            public IntBasis WPARM_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"   05 WPARM-NRPARCEL              PIC S9(04) COMP.*/
            public IntBasis WPARM_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 WPARM-OCORHIST              PIC S9(04) COMP.*/
            public IntBasis WPARM_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 WPARM-TEMCONTA              PIC  X(01).*/
            public StringBasis WPARM_TEMCONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WPARM-ERRO01                PIC  9(02).*/
            public IntBasis WPARM_ERRO01 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO02                PIC  9(02).*/
            public IntBasis WPARM_ERRO02 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO03                PIC  9(02).*/
            public IntBasis WPARM_ERRO03 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO04                PIC  9(02).*/
            public IntBasis WPARM_ERRO04 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO05                PIC  9(02).*/
            public IntBasis WPARM_ERRO05 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO06                PIC  9(02).*/
            public IntBasis WPARM_ERRO06 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO07                PIC  9(02).*/
            public IntBasis WPARM_ERRO07 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO08                PIC  9(02).*/
            public IntBasis WPARM_ERRO08 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO09                PIC  9(02).*/
            public IntBasis WPARM_ERRO09 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO10                PIC  9(02).*/
            public IntBasis WPARM_ERRO10 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO11                PIC  9(02).*/
            public IntBasis WPARM_ERRO11 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-MSG-ERRO              PIC  X(80).*/
            public StringBasis WPARM_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
            /*"   05 WPARM-SQLCODE               PIC S9(04) COMP.*/
            public IntBasis WPARM_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.APOLCOBR APOLCOBR { get; set; } = new Dclgens.APOLCOBR();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.UNIDACEF UNIDACEF { get; set; } = new Dclgens.UNIDACEF();
        public Dclgens.AGENCIAS AGENCIAS { get; set; } = new Dclgens.AGENCIAS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.APOLIAUT APOLIAUT { get; set; } = new Dclgens.APOLIAUT();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.BILHEEND BILHEEND { get; set; } = new Dclgens.BILHEEND();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.GE381 GE381 { get; set; } = new Dclgens.GE381();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0540S_WPARAMETROS GE0540S_WPARAMETROS_P) //PROCEDURE DIVISION USING 
        /*WPARAMETROS*/
        {
            try
            {
                this.WPARAMETROS = GE0540S_WPARAMETROS_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { WPARAMETROS };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -412- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -412- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -414- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -416- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -425- MOVE 'S' TO WPARM-TEMCONTA. */
            _.Move("S", WPARAMETROS.WPARM_TEMCONTA);

            /*" -427- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -429- PERFORM R0200-00-VERIFICA-REGISTRO. */

            R0200_00_VERIFICA_REGISTRO_SECTION();

            /*" -429- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -440- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -442- MOVE SPACES TO SISTEMAS-DATA-MOV-ABERTO */
            _.Move("", SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

            /*" -448- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -451- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -452- MOVE 01 TO WPARM-ERRO01 */
                _.Move(01, WPARAMETROS.WPARM_ERRO01);

                /*" -454- MOVE 'N' TO WPARM-TEMCONTA. */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);
            }


            /*" -454- DISPLAY 'DATA MOVIMENTO CB: ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA MOVIMENTO CB: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -448- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-VERIFICA-REGISTRO-SECTION */
        private void R0200_00_VERIFICA_REGISTRO_SECTION()
        {
            /*" -465- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -467- MOVE WPARM-NUMAPOL TO APOLICES-NUM-APOLICE. */
            _.Move(WPARAMETROS.WPARM_NUMAPOL, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -469- PERFORM R0310-00-SELECT-APOLICES. */

            R0310_00_SELECT_APOLICES_SECTION();

            /*" -470- MOVE WPARM-NUMAPOL TO ENDOSSOS-NUM-APOLICE. */
            _.Move(WPARAMETROS.WPARM_NUMAPOL, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -472- MOVE WPARM-NRENDOS TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(WPARAMETROS.WPARM_NRENDOS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -474- PERFORM R0320-00-SELECT-ENDOSSOS. */

            R0320_00_SELECT_ENDOSSOS_SECTION();

            /*" -475- IF WPARM-TEMCONTA EQUAL 'N' */

            if (WPARAMETROS.WPARM_TEMCONTA == "N")
            {

                /*" -479- GO TO R0200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -485- IF ( ( APOLICES-ORGAO-EMISSOR EQUAL 110 ) OR ( APOLICES-ORGAO-EMISSOR EQUAL 10 AND ENDOSSOS-RAMO-EMISSOR EQUAL 53 AND ENDOSSOS-COD-PRODUTO EQUAL 5302 OR 5303 OR 5304 ) ) */

            if (((APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR == 110) || (APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR == 10 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 53 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("5302", "5303", "5304"))))
            {

                /*" -486- MOVE APOLICES-NUM-APOLICE TO APOLIAUT-NUM-APOLICE */
                _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_APOLICE);

                /*" -488- MOVE ENDOSSOS-NUM-ENDOSSO TO APOLIAUT-NUM-ENDOSSO */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ENDOSSO);

                /*" -490- PERFORM R0315-00-SELECT-APOLIAUT */

                R0315_00_SELECT_APOLIAUT_SECTION();

                /*" -495- MOVE APOLIAUT-COD-CLIENTE TO GE381-COD-CLIENTE APOLICES-COD-CLIENTE CLIENTES-COD-CLIENTE ENDERECO-COD-CLIENTE */
                _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_CLIENTE, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

                /*" -496- PERFORM R0216-00-SELECT-GE381 */

                R0216_00_SELECT_GE381_SECTION();

                /*" -497- ELSE */
            }
            else
            {


                /*" -498- MOVE WPARM-NUMAPOL TO APOLCOBR-NUM-APOLICE */
                _.Move(WPARAMETROS.WPARM_NUMAPOL, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_APOLICE);

                /*" -499- MOVE WPARM-NRENDOS TO APOLCOBR-NUM-ENDOSSO */
                _.Move(WPARAMETROS.WPARM_NRENDOS, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_ENDOSSO);

                /*" -502- MOVE APOLICES-COD-CLIENTE TO CLIENTES-COD-CLIENTE ENDERECO-COD-CLIENTE */
                _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

                /*" -509- PERFORM R0210-00-SELECT-APOLCOBR. */

                R0210_00_SELECT_APOLCOBR_SECTION();
            }


            /*" -511- PERFORM R0330-00-SELECT-CLIENTES. */

            R0330_00_SELECT_CLIENTES_SECTION();

            /*" -512- IF WPARM-TEMCONTA EQUAL 'N' */

            if (WPARAMETROS.WPARM_TEMCONTA == "N")
            {

                /*" -514- GO TO R0200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -514- PERFORM R1000-00-GRAVA-EVENTO. */

            R1000_00_GRAVA_EVENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-SELECT-APOLCOBR-SECTION */
        private void R0210_00_SELECT_APOLCOBR_SECTION()
        {
            /*" -525- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -538- PERFORM R0210_00_SELECT_APOLCOBR_DB_SELECT_1 */

            R0210_00_SELECT_APOLCOBR_DB_SELECT_1();

            /*" -541- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -542- PERFORM R0212-00-SELECT-APOLCOBR */

                R0212_00_SELECT_APOLCOBR_SECTION();

                /*" -544- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -545- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -546- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -548- MOVE 'GE0540S-R0210-PROBLEMA LEITURA .APOLICE_COBRANCA' TO WPARM-MSG-ERRO */
                _.Move("GE0540S-R0210-PROBLEMA LEITURA .APOLICE_COBRANCA", WPARAMETROS.WPARM_MSG_ERRO);

                /*" -549- MOVE SQLCODE TO WPARM-SQLCODE */
                _.Move(DB.SQLCODE, WPARAMETROS.WPARM_SQLCODE);

                /*" -551- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -555- IF VIND-NULL01 LESS ZEROS OR VIND-NULL02 LESS ZEROS OR VIND-NULL03 LESS ZEROS OR VIND-NULL04 LESS ZEROS */

            if (VIND_NULL01 < 00 || VIND_NULL02 < 00 || VIND_NULL03 < 00 || VIND_NULL04 < 00)
            {

                /*" -556- PERFORM R0212-00-SELECT-APOLCOBR */

                R0212_00_SELECT_APOLCOBR_SECTION();

                /*" -558- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -561- IF APOLCOBR-COD-AGENCIA-DEB EQUAL ZEROS OR APOLCOBR-OPER-CONTA-DEB EQUAL ZEROS OR APOLCOBR-NUM-CONTA-DEB EQUAL ZEROS */

            if (APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB == 00 || APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB == 00 || APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB == 00)
            {

                /*" -562- PERFORM R0212-00-SELECT-APOLCOBR */

                R0212_00_SELECT_APOLCOBR_SECTION();

                /*" -564- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -566- PERFORM R0220-00-SELECT-AGENCCEF. */

            R0220_00_SELECT_AGENCCEF_SECTION();

            /*" -567- IF WPARM-TEMCONTA EQUAL 'N' */

            if (WPARAMETROS.WPARM_TEMCONTA == "N")
            {

                /*" -569- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -569- PERFORM R0230-00-VERIFICA-CONTA. */

            R0230_00_VERIFICA_CONTA_SECTION();

        }

        [StopWatch]
        /*" R0210-00-SELECT-APOLCOBR-DB-SELECT-1 */
        public void R0210_00_SELECT_APOLCOBR_DB_SELECT_1()
        {
            /*" -538- EXEC SQL SELECT COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB INTO :APOLCOBR-COD-AGENCIA-DEB:VIND-NULL01 , :APOLCOBR-OPER-CONTA-DEB:VIND-NULL02 , :APOLCOBR-NUM-CONTA-DEB:VIND-NULL03 , :APOLCOBR-DIG-CONTA-DEB:VIND-NULL04 FROM SEGUROS.APOLICE_COBRANCA WHERE NUM_APOLICE = :APOLCOBR-NUM-APOLICE AND NUM_ENDOSSO = :APOLCOBR-NUM-ENDOSSO WITH UR END-EXEC. */

            var r0210_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 = new R0210_00_SELECT_APOLCOBR_DB_SELECT_1_Query1()
            {
                APOLCOBR_NUM_APOLICE = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_APOLICE.ToString(),
                APOLCOBR_NUM_ENDOSSO = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0210_00_SELECT_APOLCOBR_DB_SELECT_1_Query1.Execute(r0210_00_SELECT_APOLCOBR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLCOBR_COD_AGENCIA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.APOLCOBR_OPER_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
                _.Move(executed_1.APOLCOBR_NUM_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB);
                _.Move(executed_1.VIND_NULL03, VIND_NULL03);
                _.Move(executed_1.APOLCOBR_DIG_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB);
                _.Move(executed_1.VIND_NULL04, VIND_NULL04);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0212-00-SELECT-APOLCOBR-SECTION */
        private void R0212_00_SELECT_APOLCOBR_SECTION()
        {
            /*" -580- MOVE '0212' TO WNR-EXEC-SQL. */
            _.Move("0212", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -593- PERFORM R0212_00_SELECT_APOLCOBR_DB_SELECT_1 */

            R0212_00_SELECT_APOLCOBR_DB_SELECT_1();

            /*" -596- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -597- PERFORM R0215-00-SELECT-BILHETE */

                R0215_00_SELECT_BILHETE_SECTION();

                /*" -599- GO TO R0212-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0212_99_SAIDA*/ //GOTO
                return;
            }


            /*" -600- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -601- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -603- MOVE 'GE0540S-R0212-PROBLEMA LEITURA .APOLICE_COBRANCA' TO WPARM-MSG-ERRO */
                _.Move("GE0540S-R0212-PROBLEMA LEITURA .APOLICE_COBRANCA", WPARAMETROS.WPARM_MSG_ERRO);

                /*" -604- MOVE SQLCODE TO WPARM-SQLCODE */
                _.Move(DB.SQLCODE, WPARAMETROS.WPARM_SQLCODE);

                /*" -606- GO TO R0212-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0212_99_SAIDA*/ //GOTO
                return;
            }


            /*" -610- IF VIND-NULL01 LESS ZEROS OR VIND-NULL02 LESS ZEROS OR VIND-NULL03 LESS ZEROS OR VIND-NULL04 LESS ZEROS */

            if (VIND_NULL01 < 00 || VIND_NULL02 < 00 || VIND_NULL03 < 00 || VIND_NULL04 < 00)
            {

                /*" -611- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -613- GO TO R0212-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0212_99_SAIDA*/ //GOTO
                return;
            }


            /*" -616- IF APOLCOBR-COD-AGENCIA-DEB EQUAL ZEROS OR APOLCOBR-OPER-CONTA-DEB EQUAL ZEROS OR APOLCOBR-NUM-CONTA-DEB EQUAL ZEROS */

            if (APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB == 00 || APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB == 00 || APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB == 00)
            {

                /*" -617- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -619- GO TO R0212-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0212_99_SAIDA*/ //GOTO
                return;
            }


            /*" -621- PERFORM R0220-00-SELECT-AGENCCEF. */

            R0220_00_SELECT_AGENCCEF_SECTION();

            /*" -622- IF WPARM-TEMCONTA EQUAL 'N' */

            if (WPARAMETROS.WPARM_TEMCONTA == "N")
            {

                /*" -624- GO TO R0212-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0212_99_SAIDA*/ //GOTO
                return;
            }


            /*" -624- PERFORM R0230-00-VERIFICA-CONTA. */

            R0230_00_VERIFICA_CONTA_SECTION();

        }

        [StopWatch]
        /*" R0212-00-SELECT-APOLCOBR-DB-SELECT-1 */
        public void R0212_00_SELECT_APOLCOBR_DB_SELECT_1()
        {
            /*" -593- EXEC SQL SELECT COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB INTO :APOLCOBR-COD-AGENCIA-DEB:VIND-NULL01 , :APOLCOBR-OPER-CONTA-DEB:VIND-NULL02 , :APOLCOBR-NUM-CONTA-DEB:VIND-NULL03 , :APOLCOBR-DIG-CONTA-DEB:VIND-NULL04 FROM SEGUROS.APOLICE_COBRANCA WHERE NUM_APOLICE = :APOLCOBR-NUM-APOLICE AND NUM_ENDOSSO = 0 WITH UR END-EXEC. */

            var r0212_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 = new R0212_00_SELECT_APOLCOBR_DB_SELECT_1_Query1()
            {
                APOLCOBR_NUM_APOLICE = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0212_00_SELECT_APOLCOBR_DB_SELECT_1_Query1.Execute(r0212_00_SELECT_APOLCOBR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLCOBR_COD_AGENCIA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.APOLCOBR_OPER_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
                _.Move(executed_1.APOLCOBR_NUM_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB);
                _.Move(executed_1.VIND_NULL03, VIND_NULL03);
                _.Move(executed_1.APOLCOBR_DIG_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB);
                _.Move(executed_1.VIND_NULL04, VIND_NULL04);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0212_99_SAIDA*/

        [StopWatch]
        /*" R0215-00-SELECT-BILHETE-SECTION */
        private void R0215_00_SELECT_BILHETE_SECTION()
        {
            /*" -635- MOVE '0215' TO WNR-EXEC-SQL. */
            _.Move("0215", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -650- PERFORM R0215_00_SELECT_BILHETE_DB_SELECT_1 */

            R0215_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -653- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -654- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -656- MOVE 'GE0540S-PROBLEMA LEITURA .BILHETE_ENDOSSO' TO WPARM-MSG-ERRO */
                _.Move("GE0540S-PROBLEMA LEITURA .BILHETE_ENDOSSO", WPARAMETROS.WPARM_MSG_ERRO);

                /*" -657- MOVE SQLCODE TO WPARM-SQLCODE */
                _.Move(DB.SQLCODE, WPARAMETROS.WPARM_SQLCODE);

                /*" -659- GO TO R0215-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0215_99_SAIDA*/ //GOTO
                return;
            }


            /*" -660- MOVE BILHETE-COD-AGENCIA-DEB TO APOLCOBR-COD-AGENCIA-DEB. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB);

            /*" -662- MOVE BILHETE-OPERACAO-CONTA-DEB TO APOLCOBR-OPER-CONTA-DEB. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB);

            /*" -663- MOVE BILHETE-NUM-CONTA-DEB TO APOLCOBR-NUM-CONTA-DEB. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB);

            /*" -665- MOVE BILHETE-DIG-CONTA-DEB TO APOLCOBR-DIG-CONTA-DEB. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DIG_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB);

            /*" -668- IF APOLCOBR-COD-AGENCIA-DEB EQUAL ZEROS OR APOLCOBR-OPER-CONTA-DEB EQUAL ZEROS OR APOLCOBR-NUM-CONTA-DEB EQUAL ZEROS */

            if (APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB == 00 || APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB == 00 || APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB == 00)
            {

                /*" -669- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -671- GO TO R0215-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0215_99_SAIDA*/ //GOTO
                return;
            }


            /*" -673- PERFORM R0220-00-SELECT-AGENCCEF. */

            R0220_00_SELECT_AGENCCEF_SECTION();

            /*" -674- IF WPARM-TEMCONTA EQUAL 'N' */

            if (WPARAMETROS.WPARM_TEMCONTA == "N")
            {

                /*" -676- GO TO R0215-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0215_99_SAIDA*/ //GOTO
                return;
            }


            /*" -676- PERFORM R0230-00-VERIFICA-CONTA. */

            R0230_00_VERIFICA_CONTA_SECTION();

        }

        [StopWatch]
        /*" R0215-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R0215_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -650- EXEC SQL SELECT B.COD_AGENCIA_DEB , B.OPERACAO_CONTA_DEB , B.NUM_CONTA_DEB , B.DIG_CONTA_DEB INTO :BILHETE-COD-AGENCIA-DEB , :BILHETE-OPERACAO-CONTA-DEB , :BILHETE-NUM-CONTA-DEB , :BILHETE-DIG-CONTA-DEB FROM SEGUROS.BILHETE_ENDOSSO A, SEGUROS.BILHETE B WHERE A.NUM_APOLICE = :APOLCOBR-NUM-APOLICE AND A.NUM_ENDOSSO = :APOLCOBR-NUM-ENDOSSO AND A.NUM_BILHETE = B.NUM_BILHETE WITH UR END-EXEC. */

            var r0215_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R0215_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                APOLCOBR_NUM_APOLICE = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_APOLICE.ToString(),
                APOLCOBR_NUM_ENDOSSO = APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0215_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r0215_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_COD_AGENCIA_DEB, BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA_DEB);
                _.Move(executed_1.BILHETE_OPERACAO_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA_DEB);
                _.Move(executed_1.BILHETE_NUM_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_NUM_CONTA_DEB);
                _.Move(executed_1.BILHETE_DIG_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_DIG_CONTA_DEB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0215_99_SAIDA*/

        [StopWatch]
        /*" R0216-00-SELECT-GE381-SECTION */
        private void R0216_00_SELECT_GE381_SECTION()
        {
            /*" -687- MOVE '0216' TO WNR-EXEC-SQL. */
            _.Move("0216", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -705- PERFORM R0216_00_SELECT_GE381_DB_SELECT_1 */

            R0216_00_SELECT_GE381_DB_SELECT_1();

            /*" -708- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -709- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -711- MOVE 'GE0540S-PROBLEMA LEITURA .GE_CLI_DADOS_FINANC' TO WPARM-MSG-ERRO */
                _.Move("GE0540S-PROBLEMA LEITURA .GE_CLI_DADOS_FINANC", WPARAMETROS.WPARM_MSG_ERRO);

                /*" -712- MOVE SQLCODE TO WPARM-SQLCODE */
                _.Move(DB.SQLCODE, WPARAMETROS.WPARM_SQLCODE);

                /*" -714- GO TO R0216-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0216_99_SAIDA*/ //GOTO
                return;
            }


            /*" -715- IF VIND-COD-AGENCIA-DV LESS ZEROS */

            if (VIND_COD_AGENCIA_DV < 00)
            {

                /*" -717- MOVE ZEROS TO GE381-COD-AGENCIA-DV. */
                _.Move(0, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA_DV);
            }


            /*" -718- IF VIND-COD-OPERACAO LESS ZEROS */

            if (VIND_COD_OPERACAO < 00)
            {

                /*" -720- MOVE ZEROS TO GE381-COD-OPERACAO. */
                _.Move(0, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_OPERACAO);
            }


            /*" -723- IF GE381-COD-BCO EQUAL ZEROS OR GE381-COD-AGENCIA EQUAL ZEROS OR GE381-NUM-CONTA EQUAL ZEROS */

            if (GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_BCO == 00 || GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA == 00 || GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA == 00)
            {

                /*" -723- MOVE 'N' TO WPARM-TEMCONTA. */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);
            }


        }

        [StopWatch]
        /*" R0216-00-SELECT-GE381-DB-SELECT-1 */
        public void R0216_00_SELECT_GE381_DB_SELECT_1()
        {
            /*" -705- EXEC SQL SELECT COD_BCO ,COD_AGENCIA ,COD_AGENCIA_DV ,COD_OPERACAO ,NUM_CONTA ,NUM_CONTA_DV1 INTO :GE381-COD-BCO ,:GE381-COD-AGENCIA ,:GE381-COD-AGENCIA-DV :VIND-COD-AGENCIA-DV ,:GE381-COD-OPERACAO :VIND-COD-OPERACAO ,:GE381-NUM-CONTA ,:GE381-NUM-CONTA-DV1 FROM SEGUROS.GE_CLI_DADOS_FINANC WHERE COD_CLIENTE = :GE381-COD-CLIENTE AND COD_TIPO_CONTA = ' ' WITH UR END-EXEC. */

            var r0216_00_SELECT_GE381_DB_SELECT_1_Query1 = new R0216_00_SELECT_GE381_DB_SELECT_1_Query1()
            {
                GE381_COD_CLIENTE = GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0216_00_SELECT_GE381_DB_SELECT_1_Query1.Execute(r0216_00_SELECT_GE381_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE381_COD_BCO, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_BCO);
                _.Move(executed_1.GE381_COD_AGENCIA, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA);
                _.Move(executed_1.GE381_COD_AGENCIA_DV, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA_DV);
                _.Move(executed_1.VIND_COD_AGENCIA_DV, VIND_COD_AGENCIA_DV);
                _.Move(executed_1.GE381_COD_OPERACAO, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_OPERACAO);
                _.Move(executed_1.VIND_COD_OPERACAO, VIND_COD_OPERACAO);
                _.Move(executed_1.GE381_NUM_CONTA, GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA);
                _.Move(executed_1.GE381_NUM_CONTA_DV1, GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA_DV1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0216_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-SELECT-AGENCCEF-SECTION */
        private void R0220_00_SELECT_AGENCCEF_SECTION()
        {
            /*" -734- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -736- MOVE APOLCOBR-COD-AGENCIA-DEB TO AGENCCEF-COD-AGENCIA. */
            _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);

            /*" -757- PERFORM R0220_00_SELECT_AGENCCEF_DB_SELECT_1 */

            R0220_00_SELECT_AGENCCEF_DB_SELECT_1();

            /*" -760- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -761- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -763- MOVE 'GE0540S-PROBLEMA LEITURA .AGENCIAS_CEF' TO WPARM-MSG-ERRO */
                _.Move("GE0540S-PROBLEMA LEITURA .AGENCIAS_CEF", WPARAMETROS.WPARM_MSG_ERRO);

                /*" -764- MOVE SQLCODE TO WPARM-SQLCODE */
                _.Move(DB.SQLCODE, WPARAMETROS.WPARM_SQLCODE);

                /*" -766- GO TO R0220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -767- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -769- MOVE SPACES TO UNIDACEF-ENDERECO. */
                _.Move("", UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_ENDERECO);
            }


            /*" -770- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -772- MOVE SPACES TO UNIDACEF-BAIRRO. */
                _.Move("", UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_BAIRRO);
            }


            /*" -773- IF VIND-NULL03 LESS ZEROS */

            if (VIND_NULL03 < 00)
            {

                /*" -775- MOVE SPACES TO UNIDACEF-CIDADE. */
                _.Move("", UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_CIDADE);
            }


            /*" -776- IF VIND-NULL04 LESS ZEROS */

            if (VIND_NULL04 < 00)
            {

                /*" -776- MOVE SPACES TO UNIDACEF-UF. */
                _.Move("", UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_UF);
            }


        }

        [StopWatch]
        /*" R0220-00-SELECT-AGENCCEF-DB-SELECT-1 */
        public void R0220_00_SELECT_AGENCCEF_DB_SELECT_1()
        {
            /*" -757- EXEC SQL SELECT A.COD_AGENCIA , A.NOME_AGENCIA , A.COD_SUREG , B.ENDERECO , B.BAIRRO , B.CIDADE , B.UF INTO :AGENCCEF-COD-AGENCIA , :AGENCCEF-NOME-AGENCIA , :AGENCCEF-COD-SUREG , :UNIDACEF-ENDERECO:VIND-NULL01 , :UNIDACEF-BAIRRO:VIND-NULL02 , :UNIDACEF-CIDADE:VIND-NULL03 , :UNIDACEF-UF:VIND-NULL04 FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.UNIDADE_CEF B WHERE A.COD_AGENCIA = :AGENCCEF-COD-AGENCIA AND A.COD_AGENCIA = B.COD_UNIDADE AND A.COD_SUREG = B.COD_SUREG WITH UR END-EXEC. */

            var r0220_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 = new R0220_00_SELECT_AGENCCEF_DB_SELECT_1_Query1()
            {
                AGENCCEF_COD_AGENCIA = AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA.ToString(),
            };

            var executed_1 = R0220_00_SELECT_AGENCCEF_DB_SELECT_1_Query1.Execute(r0220_00_SELECT_AGENCCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCCEF_COD_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);
                _.Move(executed_1.AGENCCEF_NOME_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA);
                _.Move(executed_1.AGENCCEF_COD_SUREG, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_SUREG);
                _.Move(executed_1.UNIDACEF_ENDERECO, UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_ENDERECO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.UNIDACEF_BAIRRO, UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_BAIRRO);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
                _.Move(executed_1.UNIDACEF_CIDADE, UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_CIDADE);
                _.Move(executed_1.VIND_NULL03, VIND_NULL03);
                _.Move(executed_1.UNIDACEF_UF, UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_UF);
                _.Move(executed_1.VIND_NULL04, VIND_NULL04);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0230-00-VERIFICA-CONTA-SECTION */
        private void R0230_00_VERIFICA_CONTA_SECTION()
        {
            /*" -787- MOVE '0230' TO WNR-EXEC-SQL. */
            _.Move("0230", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -789- INITIALIZE WS-NUMERO. */
            _.Initialize(
                W.WS_NUMERO
            );

            /*" -790- IF APOLCOBR-NUM-CONTA-DEB >= 400000000 */

            if (APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB >= 400000000)
            {

                /*" -791- MOVE APOLCOBR-NUM-CONTA-DEB TO WS-NUMERO */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB, W.WS_NUMERO);

                /*" -792- ELSE */
            }
            else
            {


                /*" -793- MOVE APOLCOBR-COD-AGENCIA-DEB TO WS-AGENCIA */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB, W.FILLER_0.WS_AGENCIA);

                /*" -794- MOVE APOLCOBR-OPER-CONTA-DEB TO WS-OPERACAO */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB, W.FILLER_0.WS_OPERACAO);

                /*" -795- MOVE APOLCOBR-NUM-CONTA-DEB TO WS-NUMCONTA */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB, W.FILLER_0.WS_NUMCONTA);

                /*" -797- END-IF. */
            }


            /*" -798- MOVE APOLCOBR-DIG-CONTA-DEB TO WS-DIGCONTA. */
            _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB, W.WS_DIGCONTA);

            /*" -800- MOVE WS-NUMERO TO LPARM15. */
            _.Move(W.WS_NUMERO, W.LPARM15X.LPARM15);

            /*" -816- COMPUTE WPARM15-AUX = LPARM15-1 * 8 + LPARM15-2 * 7 + LPARM15-3 * 6 + LPARM15-4 * 5 + LPARM15-5 * 4 + LPARM15-6 * 3 + LPARM15-7 * 2 + LPARM15-8 * 9 + LPARM15-9 * 8 + LPARM15-10 * 7 + LPARM15-11 * 6 + LPARM15-12 * 5 + LPARM15-13 * 4 + LPARM15-14 * 3 + LPARM15-15 * 2 */
            W.WPARM15_AUX.Value = W.LPARM15X.FILLER_1.LPARM15_1 * 8 + W.LPARM15X.FILLER_1.LPARM15_2 * 7 + W.LPARM15X.FILLER_1.LPARM15_3 * 6 + W.LPARM15X.FILLER_1.LPARM15_4 * 5 + W.LPARM15X.FILLER_1.LPARM15_5 * 4 + W.LPARM15X.FILLER_1.LPARM15_6 * 3 + W.LPARM15X.FILLER_1.LPARM15_7 * 2 + W.LPARM15X.FILLER_1.LPARM15_8 * 9 + W.LPARM15X.FILLER_1.LPARM15_9 * 8 + W.LPARM15X.FILLER_1.LPARM15_10 * 7 + W.LPARM15X.FILLER_1.LPARM15_11 * 6 + W.LPARM15X.FILLER_1.LPARM15_12 * 5 + W.LPARM15X.FILLER_1.LPARM15_13 * 4 + W.LPARM15X.FILLER_1.LPARM15_14 * 3 + W.LPARM15X.FILLER_1.LPARM15_15 * 2;

            /*" -819- DIVIDE WPARM15-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO. */
            _.Divide(W.WPARM15_AUX, 11, W.WQUOCIENTE, W.WRESTO);

            /*" -820- IF WRESTO EQUAL ZEROS */

            if (W.WRESTO == 00)
            {

                /*" -821- MOVE 0 TO LPARM15-D1 */
                _.Move(0, W.LPARM15X.LPARM15_D1);

                /*" -822- ELSE */
            }
            else
            {


                /*" -826- SUBTRACT WRESTO FROM 11 GIVING LPARM15-D1. */
                W.LPARM15X.LPARM15_D1.Value = 11 - W.WRESTO;
            }


            /*" -827- IF WS-DIGCONTA NOT EQUAL LPARM15-D1 */

            if (W.WS_DIGCONTA != W.LPARM15X.LPARM15_D1)
            {

                /*" -828- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -830- GO TO R0230-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/ //GOTO
                return;
            }


            /*" -830- PERFORM R0250-00-SELECT-AGENCIAS. */

            R0250_00_SELECT_AGENCIAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-SELECT-AGENCIAS-SECTION */
        private void R0250_00_SELECT_AGENCIAS_SECTION()
        {
            /*" -841- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -842- MOVE 104 TO AGENCIAS-COD-BANCO. */
            _.Move(104, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_BANCO);

            /*" -844- MOVE AGENCCEF-COD-AGENCIA TO AGENCIAS-COD-AGENCIA. */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA);

            /*" -853- PERFORM R0250_00_SELECT_AGENCIAS_DB_SELECT_1 */

            R0250_00_SELECT_AGENCIAS_DB_SELECT_1();

            /*" -856- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -857- PERFORM R0270-00-INSERT-AGENCIAS */

                R0270_00_INSERT_AGENCIAS_SECTION();

                /*" -858- ELSE */
            }
            else
            {


                /*" -859- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -861- MOVE 'GE0540S-PROBLEMA LEITURA .AGENCIAS' TO WPARM-MSG-ERRO */
                    _.Move("GE0540S-PROBLEMA LEITURA .AGENCIAS", WPARAMETROS.WPARM_MSG_ERRO);

                    /*" -862- MOVE SQLCODE TO WPARM-SQLCODE */
                    _.Move(DB.SQLCODE, WPARAMETROS.WPARM_SQLCODE);

                    /*" -862- MOVE 'N' TO WPARM-TEMCONTA. */
                    _.Move("N", WPARAMETROS.WPARM_TEMCONTA);
                }

            }


        }

        [StopWatch]
        /*" R0250-00-SELECT-AGENCIAS-DB-SELECT-1 */
        public void R0250_00_SELECT_AGENCIAS_DB_SELECT_1()
        {
            /*" -853- EXEC SQL SELECT COD_BANCO , COD_AGENCIA INTO :AGENCIAS-COD-BANCO , :AGENCIAS-COD-AGENCIA FROM SEGUROS.AGENCIAS WHERE COD_BANCO = :AGENCIAS-COD-BANCO AND COD_AGENCIA = :AGENCIAS-COD-AGENCIA WITH UR END-EXEC. */

            var r0250_00_SELECT_AGENCIAS_DB_SELECT_1_Query1 = new R0250_00_SELECT_AGENCIAS_DB_SELECT_1_Query1()
            {
                AGENCIAS_COD_AGENCIA = AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA.ToString(),
                AGENCIAS_COD_BANCO = AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_BANCO.ToString(),
            };

            var executed_1 = R0250_00_SELECT_AGENCIAS_DB_SELECT_1_Query1.Execute(r0250_00_SELECT_AGENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCIAS_COD_BANCO, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_BANCO);
                _.Move(executed_1.AGENCIAS_COD_AGENCIA, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0270-00-INSERT-AGENCIAS-SECTION */
        private void R0270_00_INSERT_AGENCIAS_SECTION()
        {
            /*" -873- MOVE '0270' TO WNR-EXEC-SQL. */
            _.Move("0270", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -874- MOVE 104 TO AGENCIAS-COD-BANCO. */
            _.Move(104, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_BANCO);

            /*" -875- MOVE AGENCCEF-COD-AGENCIA TO AGENCIAS-COD-AGENCIA. */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA);

            /*" -876- MOVE SPACES TO AGENCIAS-DAC-AGENCIA. */
            _.Move("", AGENCIAS.DCLAGENCIAS.AGENCIAS_DAC_AGENCIA);

            /*" -877- MOVE AGENCCEF-NOME-AGENCIA TO AGENCIAS-NOME-AGENCIA. */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA, AGENCIAS.DCLAGENCIAS.AGENCIAS_NOME_AGENCIA);

            /*" -878- MOVE UNIDACEF-CIDADE TO AGENCIAS-CIDADE. */
            _.Move(UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_CIDADE, AGENCIAS.DCLAGENCIAS.AGENCIAS_CIDADE);

            /*" -879- MOVE UNIDACEF-UF TO AGENCIAS-SIGLA-UF. */
            _.Move(UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_UF, AGENCIAS.DCLAGENCIAS.AGENCIAS_SIGLA_UF);

            /*" -880- MOVE UNIDACEF-ENDERECO TO AGENCIAS-ENDERECO. */
            _.Move(UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_ENDERECO, AGENCIAS.DCLAGENCIAS.AGENCIAS_ENDERECO);

            /*" -881- MOVE ZEROS TO AGENCIAS-TELEFONE. */
            _.Move(0, AGENCIAS.DCLAGENCIAS.AGENCIAS_TELEFONE);

            /*" -882- MOVE ZEROS TO AGENCIAS-DDD. */
            _.Move(0, AGENCIAS.DCLAGENCIAS.AGENCIAS_DDD);

            /*" -883- MOVE ZEROS TO AGENCIAS-FAX. */
            _.Move(0, AGENCIAS.DCLAGENCIAS.AGENCIAS_FAX);

            /*" -884- MOVE ZEROS TO AGENCIAS-TELEX. */
            _.Move(0, AGENCIAS.DCLAGENCIAS.AGENCIAS_TELEX);

            /*" -885- MOVE ZEROS TO AGENCIAS-CEP. */
            _.Move(0, AGENCIAS.DCLAGENCIAS.AGENCIAS_CEP);

            /*" -886- MOVE SPACES TO AGENCIAS-TIPO-CONTA. */
            _.Move("", AGENCIAS.DCLAGENCIAS.AGENCIAS_TIPO_CONTA);

            /*" -887- MOVE ZEROS TO AGENCIAS-NUM-CTA-CORRENTE. */
            _.Move(0, AGENCIAS.DCLAGENCIAS.AGENCIAS_NUM_CTA_CORRENTE);

            /*" -888- MOVE SPACES TO AGENCIAS-DAC-CTA-CORRENTE. */
            _.Move("", AGENCIAS.DCLAGENCIAS.AGENCIAS_DAC_CTA_CORRENTE);

            /*" -889- MOVE '0' TO AGENCIAS-SIT-REGISTRO. */
            _.Move("0", AGENCIAS.DCLAGENCIAS.AGENCIAS_SIT_REGISTRO);

            /*" -892- MOVE ZEROS TO AGENCIAS-COD-EMPRESA. */
            _.Move(0, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_EMPRESA);

            /*" -895- MOVE ZEROS TO VIND-NULL01 VIND-NULL02. */
            _.Move(0, VIND_NULL01, VIND_NULL02);

            /*" -934- PERFORM R0270_00_INSERT_AGENCIAS_DB_INSERT_1 */

            R0270_00_INSERT_AGENCIAS_DB_INSERT_1();

            /*" -937- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -939- MOVE 'GE0540S-PROBLEMA INSERT .AGENCIAS' TO WPARM-MSG-ERRO */
                _.Move("GE0540S-PROBLEMA INSERT .AGENCIAS", WPARAMETROS.WPARM_MSG_ERRO);

                /*" -940- MOVE SQLCODE TO WPARM-SQLCODE */
                _.Move(DB.SQLCODE, WPARAMETROS.WPARM_SQLCODE);

                /*" -940- MOVE 'N' TO WPARM-TEMCONTA. */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);
            }


        }

        [StopWatch]
        /*" R0270-00-INSERT-AGENCIAS-DB-INSERT-1 */
        public void R0270_00_INSERT_AGENCIAS_DB_INSERT_1()
        {
            /*" -934- EXEC SQL INSERT INTO SEGUROS.AGENCIAS (COD_BANCO , COD_AGENCIA , DAC_AGENCIA , NOME_AGENCIA , CIDADE , SIGLA_UF , ENDERECO , TELEFONE , DDD , FAX , TELEX , CEP , TIPO_CONTA , NUM_CTA_CORRENTE , DAC_CTA_CORRENTE , SIT_REGISTRO , COD_EMPRESA ) VALUES (:AGENCIAS-COD-BANCO , :AGENCIAS-COD-AGENCIA , :AGENCIAS-DAC-AGENCIA , :AGENCIAS-NOME-AGENCIA , :AGENCIAS-CIDADE , :AGENCIAS-SIGLA-UF , :AGENCIAS-ENDERECO , :AGENCIAS-TELEFONE , :AGENCIAS-DDD , :AGENCIAS-FAX , :AGENCIAS-TELEX , :AGENCIAS-CEP , :AGENCIAS-TIPO-CONTA , :AGENCIAS-NUM-CTA-CORRENTE , :AGENCIAS-DAC-CTA-CORRENTE , :AGENCIAS-SIT-REGISTRO , :AGENCIAS-COD-EMPRESA:VIND-NULL01) END-EXEC. */

            var r0270_00_INSERT_AGENCIAS_DB_INSERT_1_Insert1 = new R0270_00_INSERT_AGENCIAS_DB_INSERT_1_Insert1()
            {
                AGENCIAS_COD_BANCO = AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_BANCO.ToString(),
                AGENCIAS_COD_AGENCIA = AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA.ToString(),
                AGENCIAS_DAC_AGENCIA = AGENCIAS.DCLAGENCIAS.AGENCIAS_DAC_AGENCIA.ToString(),
                AGENCIAS_NOME_AGENCIA = AGENCIAS.DCLAGENCIAS.AGENCIAS_NOME_AGENCIA.ToString(),
                AGENCIAS_CIDADE = AGENCIAS.DCLAGENCIAS.AGENCIAS_CIDADE.ToString(),
                AGENCIAS_SIGLA_UF = AGENCIAS.DCLAGENCIAS.AGENCIAS_SIGLA_UF.ToString(),
                AGENCIAS_ENDERECO = AGENCIAS.DCLAGENCIAS.AGENCIAS_ENDERECO.ToString(),
                AGENCIAS_TELEFONE = AGENCIAS.DCLAGENCIAS.AGENCIAS_TELEFONE.ToString(),
                AGENCIAS_DDD = AGENCIAS.DCLAGENCIAS.AGENCIAS_DDD.ToString(),
                AGENCIAS_FAX = AGENCIAS.DCLAGENCIAS.AGENCIAS_FAX.ToString(),
                AGENCIAS_TELEX = AGENCIAS.DCLAGENCIAS.AGENCIAS_TELEX.ToString(),
                AGENCIAS_CEP = AGENCIAS.DCLAGENCIAS.AGENCIAS_CEP.ToString(),
                AGENCIAS_TIPO_CONTA = AGENCIAS.DCLAGENCIAS.AGENCIAS_TIPO_CONTA.ToString(),
                AGENCIAS_NUM_CTA_CORRENTE = AGENCIAS.DCLAGENCIAS.AGENCIAS_NUM_CTA_CORRENTE.ToString(),
                AGENCIAS_DAC_CTA_CORRENTE = AGENCIAS.DCLAGENCIAS.AGENCIAS_DAC_CTA_CORRENTE.ToString(),
                AGENCIAS_SIT_REGISTRO = AGENCIAS.DCLAGENCIAS.AGENCIAS_SIT_REGISTRO.ToString(),
                AGENCIAS_COD_EMPRESA = AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
            };

            R0270_00_INSERT_AGENCIAS_DB_INSERT_1_Insert1.Execute(r0270_00_INSERT_AGENCIAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-SELECT-APOLICES-SECTION */
        private void R0310_00_SELECT_APOLICES_SECTION()
        {
            /*" -951- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -959- PERFORM R0310_00_SELECT_APOLICES_DB_SELECT_1 */

            R0310_00_SELECT_APOLICES_DB_SELECT_1();

            /*" -962- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -963- MOVE 01 TO WPARM-ERRO03 */
                _.Move(01, WPARAMETROS.WPARM_ERRO03);

                /*" -964- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -964- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0310-00-SELECT-APOLICES-DB-SELECT-1 */
        public void R0310_00_SELECT_APOLICES_DB_SELECT_1()
        {
            /*" -959- EXEC SQL SELECT COD_CLIENTE , ORGAO_EMISSOR INTO :APOLICES-COD-CLIENTE , :APOLICES-ORGAO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE WITH UR END-EXEC. */

            var r0310_00_SELECT_APOLICES_DB_SELECT_1_Query1 = new R0310_00_SELECT_APOLICES_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0310_00_SELECT_APOLICES_DB_SELECT_1_Query1.Execute(r0310_00_SELECT_APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);
                _.Move(executed_1.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0315-00-SELECT-APOLIAUT-SECTION */
        private void R0315_00_SELECT_APOLIAUT_SECTION()
        {
            /*" -982- MOVE '0315' TO WNR-EXEC-SQL. */
            _.Move("0315", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -994- PERFORM R0315_00_SELECT_APOLIAUT_DB_SELECT_1 */

            R0315_00_SELECT_APOLIAUT_DB_SELECT_1();

            /*" -997- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -998- MOVE 01 TO WPARM-ERRO03 */
                _.Move(01, WPARAMETROS.WPARM_ERRO03);

                /*" -999- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -999- GO TO R0315-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0315_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0315-00-SELECT-APOLIAUT-DB-SELECT-1 */
        public void R0315_00_SELECT_APOLIAUT_DB_SELECT_1()
        {
            /*" -994- EXEC SQL SELECT A.COD_CLIENTE INTO :APOLIAUT-COD-CLIENTE FROM SEGUROS.APOLICE_AUTO A WHERE A.NUM_APOLICE = :APOLIAUT-NUM-APOLICE AND A.NUM_ENDOSSO = :APOLIAUT-NUM-ENDOSSO AND A.NUM_ITEM = ( SELECT MAX(B.NUM_ITEM) FROM SEGUROS.APOLICE_AUTO B WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO ) WITH UR END-EXEC. */

            var r0315_00_SELECT_APOLIAUT_DB_SELECT_1_Query1 = new R0315_00_SELECT_APOLIAUT_DB_SELECT_1_Query1()
            {
                APOLIAUT_NUM_APOLICE = APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_APOLICE.ToString(),
                APOLIAUT_NUM_ENDOSSO = APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0315_00_SELECT_APOLIAUT_DB_SELECT_1_Query1.Execute(r0315_00_SELECT_APOLIAUT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLIAUT_COD_CLIENTE, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0315_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-SELECT-ENDOSSOS-SECTION */
        private void R0320_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -1010- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -1021- PERFORM R0320_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0320_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -1024- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1025- MOVE 01 TO WPARM-ERRO04 */
                _.Move(01, WPARAMETROS.WPARM_ERRO04);

                /*" -1026- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -1026- GO TO R0320-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0320-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0320_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -1021- EXEC SQL SELECT OCORR_ENDERECO , RAMO_EMISSOR , COD_PRODUTO INTO :ENDOSSOS-OCORR-ENDERECO , :ENDOSSOS-RAMO-EMISSOR , :ENDOSSOS-COD-PRODUTO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO WITH UR END-EXEC. */

            var r0320_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R0320_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0320_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0320_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_OCORR_ENDERECO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);
                _.Move(executed_1.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-SELECT-CLIENTES-SECTION */
        private void R0330_00_SELECT_CLIENTES_SECTION()
        {
            /*" -1042- MOVE '0330' TO WNR-EXEC-SQL. */
            _.Move("0330", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -1054- PERFORM R0330_00_SELECT_CLIENTES_DB_SELECT_1 */

            R0330_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -1057- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1058- MOVE 01 TO WPARM-ERRO05 */
                _.Move(01, WPARAMETROS.WPARM_ERRO05);

                /*" -1059- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -1061- GO TO R0330-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1061- PERFORM R0340-00-SELECT-ENDERECO. */

            R0340_00_SELECT_ENDERECO_SECTION();

        }

        [StopWatch]
        /*" R0330-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R0330_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -1054- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF INTO :CLIENTES-COD-CLIENTE , :CLIENTES-NOME-RAZAO , :CLIENTES-TIPO-PESSOA , :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE WITH UR END-EXEC. */

            var r0330_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R0330_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0330_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r0330_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0340-00-SELECT-ENDERECO-SECTION */
        private void R0340_00_SELECT_ENDERECO_SECTION()
        {
            /*" -1075- MOVE '0340' TO WNR-EXEC-SQL. */
            _.Move("0340", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -1078- MOVE ENDOSSOS-OCORR-ENDERECO TO ENDERECO-OCORR-ENDERECO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);

            /*" -1108- PERFORM R0340_00_SELECT_ENDERECO_DB_SELECT_1 */

            R0340_00_SELECT_ENDERECO_DB_SELECT_1();

            /*" -1111- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1112- MOVE 01 TO WPARM-ERRO06 */
                _.Move(01, WPARAMETROS.WPARM_ERRO06);

                /*" -1114- MOVE 'N' TO WPARM-TEMCONTA. */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);
            }


            /*" -1115- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -1116- MOVE SPACES TO ENDERECO-DES-COMPLEMENTO. */
                _.Move("", ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);
            }


        }

        [StopWatch]
        /*" R0340-00-SELECT-ENDERECO-DB-SELECT-1 */
        public void R0340_00_SELECT_ENDERECO_DB_SELECT_1()
        {
            /*" -1108- EXEC SQL SELECT A.COD_CLIENTE , A.COD_ENDERECO , A.ENDERECO , A.BAIRRO , A.CIDADE , A.SIGLA_UF , A.CEP , A.DDD , A.TELEFONE , A.DES_COMPLEMENTO INTO :ENDERECO-COD-CLIENTE , :ENDERECO-COD-ENDERECO , :ENDERECO-ENDERECO , :ENDERECO-BAIRRO , :ENDERECO-CIDADE , :ENDERECO-SIGLA-UF , :ENDERECO-CEP , :ENDERECO-DDD , :ENDERECO-TELEFONE , :ENDERECO-DES-COMPLEMENTO:VIND-NULL01 FROM SEGUROS.ENDERECOS A WHERE A.COD_CLIENTE = :ENDERECO-COD-CLIENTE AND A.OCORR_ENDERECO = ( SELECT MAX(B.OCORR_ENDERECO) FROM SEGUROS.ENDERECOS B WHERE A.COD_CLIENTE = B.COD_CLIENTE ) WITH UR END-EXEC. */

            var r0340_00_SELECT_ENDERECO_DB_SELECT_1_Query1 = new R0340_00_SELECT_ENDERECO_DB_SELECT_1_Query1()
            {
                ENDERECO_COD_CLIENTE = ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0340_00_SELECT_ENDERECO_DB_SELECT_1_Query1.Execute(r0340_00_SELECT_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);
                _.Move(executed_1.ENDERECO_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(executed_1.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(executed_1.ENDERECO_DES_COMPLEMENTO, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-GRAVA-EVENTO-SECTION */
        private void R1000_00_GRAVA_EVENTO_SECTION()
        {
            /*" -1127- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -1128- IF CLIENTES-TIPO-PESSOA EQUAL 'F' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
            {

                /*" -1129- PERFORM R1010-GRAVA-PESSOA-FISICA */

                R1010_GRAVA_PESSOA_FISICA_SECTION();

                /*" -1130- ELSE */
            }
            else
            {


                /*" -1132- PERFORM R1020-GRAVA-PESSOA-JURIDICA. */

                R1020_GRAVA_PESSOA_JURIDICA_SECTION();
            }


            /*" -1133- IF WPARM-TEMCONTA EQUAL 'N' */

            if (WPARAMETROS.WPARM_TEMCONTA == "N")
            {

                /*" -1135- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1137- PERFORM R1030-GRAVA-ENDERECO. */

            R1030_GRAVA_ENDERECO_SECTION();

            /*" -1138- IF WPARM-TEMCONTA EQUAL 'N' */

            if (WPARAMETROS.WPARM_TEMCONTA == "N")
            {

                /*" -1140- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1142- PERFORM R1040-GRAVA-BANCO. */

            R1040_GRAVA_BANCO_SECTION();

            /*" -1143- IF WPARM-TEMCONTA EQUAL 'N' */

            if (WPARAMETROS.WPARM_TEMCONTA == "N")
            {

                /*" -1145- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1145- PERFORM R1100-GRAVA-PESSOA-LEGADO. */

            R1100_GRAVA_PESSOA_LEGADO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-GRAVA-PESSOA-FISICA-SECTION */
        private void R1010_GRAVA_PESSOA_FISICA_SECTION()
        {
            /*" -1156- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -1158- INITIALIZE LK-PF-PARAMETRO. */
            _.Initialize(
                LK_PF_PARAMETRO
            );

            /*" -1159- MOVE '1' TO LK-PF-TIPO-UTILIZACAO. */
            _.Move("1", LK_PF_PARAMETRO.LK_PF_TIPO_UTILIZACAO);

            /*" -1160- MOVE 'N' TO LK-PF-PESSOA-ESPECIAL. */
            _.Move("N", LK_PF_PARAMETRO.LK_PF_PESSOA_ESPECIAL);

            /*" -1161- MOVE WPARM-PROGRAMA TO LK-PF-PROGRAMA-CHAMADOR. */
            _.Move(WPARAMETROS.WPARM_PROGRAMA, LK_PF_PARAMETRO.LK_PF_PROGRAMA_CHAMADOR);

            /*" -1162- MOVE WPARM-PROGRAMA TO LK-PF-NOME-USUARIO. */
            _.Move(WPARAMETROS.WPARM_PROGRAMA, LK_PF_PARAMETRO.LK_PF_NOME_USUARIO);

            /*" -1163- MOVE SISTEMAS-DATA-MOV-ABERTO TO LK-PF-DTH-CADASTRAMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LK_PF_PARAMETRO.LK_PF_DTH_CADASTRAMENTO);

            /*" -1164- MOVE CLIENTES-TIPO-PESSOA TO LK-PF-IND-PESSOA. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA, LK_PF_PARAMETRO.LK_PF_IND_PESSOA);

            /*" -1165- MOVE 'S' TO LK-PF-STA-INF-INTEGRA. */
            _.Move("S", LK_PF_PARAMETRO.LK_PF_STA_INF_INTEGRA);

            /*" -1166- MOVE CLIENTES-CGCCPF TO W-NUM-CPF-INTEIRO-A. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, W.W_NUM_CPF_INTEIRO_A);

            /*" -1167- MOVE W-NUM-CPF-INTEIRO-NUM TO LK-PF-NUM-CPF. */
            _.Move(W.W_NUM_CPF_INTEIRO.W_NUM_CPF_INTEIRO_NUM, LK_PF_PARAMETRO.LK_PF_NUM_CPF);

            /*" -1168- MOVE W-NUM-CPF-INTEIRO-DV TO LK-PF-NUM-DV-CPF. */
            _.Move(W.W_NUM_CPF_INTEIRO.W_NUM_CPF_INTEIRO_DV, LK_PF_PARAMETRO.LK_PF_NUM_DV_CPF);

            /*" -1169- MOVE CLIENTES-NOME-RAZAO TO LK-PF-NOM-PESSOA. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LK_PF_PARAMETRO.LK_PF_NOM_PESSOA);

            /*" -1170- MOVE SPACES TO LK-PF-DTH-NASCIMENTO. */
            _.Move("", LK_PF_PARAMETRO.LK_PF_DTH_NASCIMENTO);

            /*" -1171- MOVE SPACES TO LK-PF-STA-SEXO. */
            _.Move("", LK_PF_PARAMETRO.LK_PF_STA_SEXO);

            /*" -1172- MOVE 'O' TO LK-PF-IND-ESTADO-CIVIL. */
            _.Move("O", LK_PF_PARAMETRO.LK_PF_IND_ESTADO_CIVIL);

            /*" -1173- MOVE 'A' TO LK-PF-STA-PESSOA. */
            _.Move("A", LK_PF_PARAMETRO.LK_PF_STA_PESSOA);

            /*" -1174- MOVE SPACES TO LK-PF-NOM-TRATAMENTO. */
            _.Move("", LK_PF_PARAMETRO.LK_PF_NOM_TRATAMENTO);

            /*" -1175- MOVE SPACES TO LK-PF-COD-UF. */
            _.Move("", LK_PF_PARAMETRO.LK_PF_COD_UF);

            /*" -1176- MOVE ZEROS TO LK-PF-NUM-MUNICIPIO. */
            _.Move(0, LK_PF_PARAMETRO.LK_PF_NUM_MUNICIPIO);

            /*" -1177- MOVE ZEROS TO LK-PF-NUM-INSC-SOCIAL. */
            _.Move(0, LK_PF_PARAMETRO.LK_PF_NUM_INSC_SOCIAL);

            /*" -1178- MOVE ZEROS TO LK-PF-NUM-DV-INSC-SOCIAL. */
            _.Move(0, LK_PF_PARAMETRO.LK_PF_NUM_DV_INSC_SOCIAL);

            /*" -1179- MOVE ZEROS TO LK-PF-NUM-GRAU-INSTRUCAO. */
            _.Move(0, LK_PF_PARAMETRO.LK_PF_NUM_GRAU_INSTRUCAO);

            /*" -1180- MOVE SPACES TO LK-PF-NOM-REDUZIDO. */
            _.Move("", LK_PF_PARAMETRO.LK_PF_NOM_REDUZIDO);

            /*" -1181- MOVE SPACES TO LK-PF-COD-CBO. */
            _.Move("", LK_PF_PARAMETRO.LK_PF_COD_CBO);

            /*" -1182- MOVE SPACES TO LK-PF-NOM-PRIMEIRO. */
            _.Move("", LK_PF_PARAMETRO.LK_PF_NOM_PRIMEIRO);

            /*" -1212- MOVE SPACES TO LK-PF-NOM-ULTIMO. */
            _.Move("", LK_PF_PARAMETRO.LK_PF_NOM_ULTIMO);

            /*" -1214- DISPLAY '--- CHAMANDO ... GE0500B' */
            _.Display($"--- CHAMANDO ... GE0500B");

            /*" -1216- CALL 'GE0500B' USING LK-PF-PARAMETRO. */
            _.Call("GE0500B", LK_PF_PARAMETRO);

            /*" -1217- MOVE LK-PF-MSG-ERRO TO WPARM-MSG-ERRO */
            _.Move(LK_PF_PARAMETRO.LK_PF_PARAMETROS_SAIDA.LK_PF_MSG_ERRO, WPARAMETROS.WPARM_MSG_ERRO);

            /*" -1219- MOVE LK-PF-SQLCODE TO WPARM-SQLCODE */
            _.Move(LK_PF_PARAMETRO.LK_PF_PARAMETROS_SAIDA.LK_PF_SQLCODE, WPARAMETROS.WPARM_SQLCODE);

            /*" -1220- IF LK-PF-NUM-PESSOA EQUAL ZEROS */

            if (LK_PF_PARAMETRO.LK_PF_NUM_PESSOA == 00)
            {

                /*" -1221- MOVE 01 TO WPARM-ERRO07 */
                _.Move(01, WPARAMETROS.WPARM_ERRO07);

                /*" -1222- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -1223- ELSE */
            }
            else
            {


                /*" -1224- IF LK-PF-IND-ERRO EQUAL 'SIM' */

                if (LK_PF_PARAMETRO.LK_PF_PARAMETROS_SAIDA.LK_PF_IND_ERRO == "SIM")
                {

                    /*" -1225- MOVE 01 TO WPARM-ERRO07 */
                    _.Move(01, WPARAMETROS.WPARM_ERRO07);

                    /*" -1227- MOVE 'N' TO WPARM-TEMCONTA. */
                    _.Move("N", WPARAMETROS.WPARM_TEMCONTA);
                }

            }


            /*" -1228- DISPLAY '--- RETORNO .... GE0500B' */
            _.Display($"--- RETORNO .... GE0500B");

            /*" -1229- DISPLAY 'MENSAGEM ' WPARM-MSG-ERRO */
            _.Display($"MENSAGEM {WPARAMETROS.WPARM_MSG_ERRO}");

            /*" -1230- DISPLAY 'SQLCODE  ' WPARM-SQLCODE */
            _.Display($"SQLCODE  {WPARAMETROS.WPARM_SQLCODE}");

            /*" -1230- DISPLAY '----------------------------------' . */
            _.Display($"----------------------------------");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-GRAVA-PESSOA-JURIDICA-SECTION */
        private void R1020_GRAVA_PESSOA_JURIDICA_SECTION()
        {
            /*" -1241- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -1243- INITIALIZE LK-PJ-PARAMETRO. */
            _.Initialize(
                LK_PJ_PARAMETRO
            );

            /*" -1244- MOVE '1' TO LK-PJ-TIPO-UTILIZACAO. */
            _.Move("1", LK_PJ_PARAMETRO.LK_PJ_TIPO_UTILIZACAO);

            /*" -1245- MOVE 'N' TO LK-PJ-PESSOA-ESPECIAL. */
            _.Move("N", LK_PJ_PARAMETRO.LK_PJ_PESSOA_ESPECIAL);

            /*" -1246- MOVE WPARM-PROGRAMA TO LK-PJ-PROGRAMA-CHAMADOR. */
            _.Move(WPARAMETROS.WPARM_PROGRAMA, LK_PJ_PARAMETRO.LK_PJ_PROGRAMA_CHAMADOR);

            /*" -1247- MOVE WPARM-PROGRAMA TO LK-PJ-NOME-USUARIO. */
            _.Move(WPARAMETROS.WPARM_PROGRAMA, LK_PJ_PARAMETRO.LK_PJ_NOME_USUARIO);

            /*" -1248- MOVE SISTEMAS-DATA-MOV-ABERTO TO LK-PJ-DTH-CADASTRAMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LK_PJ_PARAMETRO.LK_PJ_DTH_CADASTRAMENTO);

            /*" -1249- MOVE CLIENTES-TIPO-PESSOA TO LK-PJ-IND-PESSOA. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA, LK_PJ_PARAMETRO.LK_PJ_IND_PESSOA);

            /*" -1250- MOVE 'S' TO LK-PJ-STA-INF-INTEGRA. */
            _.Move("S", LK_PJ_PARAMETRO.LK_PJ_STA_INF_INTEGRA);

            /*" -1251- MOVE CLIENTES-CGCCPF TO W-NUM-CGC-INTEIRO-A. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, W.W_NUM_CGC_INTEIRO_A);

            /*" -1252- MOVE W-NUM-CGC-INTEIRO-NUM TO LK-PJ-NUM-CNPJ. */
            _.Move(W.W_NUM_CGC_INTEIRO.W_NUM_CGC_INTEIRO_NUM, LK_PJ_PARAMETRO.LK_PJ_NUM_CNPJ);

            /*" -1253- MOVE W-NUM-CGC-INTEIRO-FILIAL TO LK-PJ-NUM-FILIAL. */
            _.Move(W.W_NUM_CGC_INTEIRO.W_NUM_CGC_INTEIRO_FILIAL, LK_PJ_PARAMETRO.LK_PJ_NUM_FILIAL);

            /*" -1254- MOVE W-NUM-CGC-INTEIRO-DV TO LK-PJ-NUM-DV-CNPJ. */
            _.Move(W.W_NUM_CGC_INTEIRO.W_NUM_CGC_INTEIRO_DV, LK_PJ_PARAMETRO.LK_PJ_NUM_DV_CNPJ);

            /*" -1255- MOVE CLIENTES-NOME-RAZAO TO LK-PJ-NOM-RAZAO-SOCIAL. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LK_PJ_PARAMETRO.LK_PJ_NOM_RAZAO_SOCIAL);

            /*" -1256- MOVE CLIENTES-NOME-RAZAO TO LK-PJ-NOM-FANTASIA. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LK_PJ_PARAMETRO.LK_PJ_NOM_FANTASIA);

            /*" -1257- MOVE ZEROS TO LK-PJ-NUM-RAMO-ATIVIDADE. */
            _.Move(0, LK_PJ_PARAMETRO.LK_PJ_NUM_RAMO_ATIVIDADE);

            /*" -1258- MOVE SPACES TO LK-PJ-NOM-SIGLA-PESSOA. */
            _.Move("", LK_PJ_PARAMETRO.LK_PJ_NOM_SIGLA_PESSOA);

            /*" -1259- MOVE SPACES TO LK-PJ-COD-CNAE. */
            _.Move("", LK_PJ_PARAMETRO.LK_PJ_COD_CNAE);

            /*" -1260- MOVE ZEROS TO LK-PJ-NUM-SOCIOS. */
            _.Move(0, LK_PJ_PARAMETRO.LK_PJ_NUM_SOCIOS);

            /*" -1261- MOVE 'N' TO LK-PJ-STA-FRANQUIA. */
            _.Move("N", LK_PJ_PARAMETRO.LK_PJ_STA_FRANQUIA);

            /*" -1262- MOVE 'N' TO LK-PJ-IND-FINALIDADE. */
            _.Move("N", LK_PJ_PARAMETRO.LK_PJ_IND_FINALIDADE);

            /*" -1263- MOVE SPACES TO LK-PJ-DTH-FUNDACAO. */
            _.Move("", LK_PJ_PARAMETRO.LK_PJ_DTH_FUNDACAO);

            /*" -1264- MOVE 'A' TO LK-PJ-STA-PESSOA. */
            _.Move("A", LK_PJ_PARAMETRO.LK_PJ_STA_PESSOA);

            /*" -1265- MOVE SPACES TO LK-PJ-COD-UF. */
            _.Move("", LK_PJ_PARAMETRO.LK_PJ_COD_UF);

            /*" -1266- MOVE ZEROS TO LK-PJ-NUM-MUNICIPIO. */
            _.Move(0, LK_PJ_PARAMETRO.LK_PJ_NUM_MUNICIPIO);

            /*" -1267- MOVE ZEROS TO LK-PJ-NUM-INSC-ESTADUAL. */
            _.Move(0, LK_PJ_PARAMETRO.LK_PJ_NUM_INSC_ESTADUAL);

            /*" -1297- MOVE ZEROS TO LK-PJ-NUM-INSC-MUNICIPAL. */
            _.Move(0, LK_PJ_PARAMETRO.LK_PJ_NUM_INSC_MUNICIPAL);

            /*" -1299- DISPLAY '--- CHAMANDO ... GE0501B' */
            _.Display($"--- CHAMANDO ... GE0501B");

            /*" -1301- CALL 'GE0501B' USING LK-PJ-PARAMETRO. */
            _.Call("GE0501B", LK_PJ_PARAMETRO);

            /*" -1302- MOVE LK-PJ-MSG-ERRO TO WPARM-MSG-ERRO */
            _.Move(LK_PJ_PARAMETRO.LK_PJ_PARAMETROS_SAIDA.LK_PJ_MSG_ERRO, WPARAMETROS.WPARM_MSG_ERRO);

            /*" -1304- MOVE LK-PJ-SQLCODE TO WPARM-SQLCODE */
            _.Move(LK_PJ_PARAMETRO.LK_PJ_PARAMETROS_SAIDA.LK_PJ_SQLCODE, WPARAMETROS.WPARM_SQLCODE);

            /*" -1305- IF LK-PJ-NUM-PESSOA EQUAL ZEROS */

            if (LK_PJ_PARAMETRO.LK_PJ_NUM_PESSOA == 00)
            {

                /*" -1306- MOVE 01 TO WPARM-ERRO08 */
                _.Move(01, WPARAMETROS.WPARM_ERRO08);

                /*" -1307- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -1308- ELSE */
            }
            else
            {


                /*" -1309- IF LK-PJ-IND-ERRO EQUAL 'SIM' */

                if (LK_PJ_PARAMETRO.LK_PJ_PARAMETROS_SAIDA.LK_PJ_IND_ERRO == "SIM")
                {

                    /*" -1310- MOVE 01 TO WPARM-ERRO08 */
                    _.Move(01, WPARAMETROS.WPARM_ERRO08);

                    /*" -1312- MOVE 'N' TO WPARM-TEMCONTA. */
                    _.Move("N", WPARAMETROS.WPARM_TEMCONTA);
                }

            }


            /*" -1313- DISPLAY '--- RETORNO .... GE0501B' */
            _.Display($"--- RETORNO .... GE0501B");

            /*" -1314- DISPLAY 'MENSAGEM ' WPARM-MSG-ERRO */
            _.Display($"MENSAGEM {WPARAMETROS.WPARM_MSG_ERRO}");

            /*" -1315- DISPLAY 'SQLCODE  ' WPARM-SQLCODE */
            _.Display($"SQLCODE  {WPARAMETROS.WPARM_SQLCODE}");

            /*" -1315- DISPLAY '----------------------------------' . */
            _.Display($"----------------------------------");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1030-GRAVA-ENDERECO-SECTION */
        private void R1030_GRAVA_ENDERECO_SECTION()
        {
            /*" -1326- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -1328- INITIALIZE LK-EN-PARAMETRO. */
            _.Initialize(
                LK_EN_PARAMETRO
            );

            /*" -1329- MOVE '1' TO LK-EN-TIPO-UTILIZACAO. */
            _.Move("1", LK_EN_PARAMETRO.LK_EN_TIPO_UTILIZACAO);

            /*" -1330- MOVE WPARM-PROGRAMA TO LK-EN-PROGRAMA-CHAMADOR. */
            _.Move(WPARAMETROS.WPARM_PROGRAMA, LK_EN_PARAMETRO.LK_EN_PROGRAMA_CHAMADOR);

            /*" -1332- MOVE WPARM-PROGRAMA TO LK-EN-NOME-USUARIO. */
            _.Move(WPARAMETROS.WPARM_PROGRAMA, LK_EN_PARAMETRO.LK_EN_NOME_USUARIO);

            /*" -1333- IF CLIENTES-TIPO-PESSOA EQUAL 'F' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
            {

                /*" -1334- MOVE LK-PF-NUM-PESSOA TO LK-EN-NUM-PESSOA */
                _.Move(LK_PF_PARAMETRO.LK_PF_NUM_PESSOA, LK_EN_PARAMETRO.LK_EN_NUM_PESSOA);

                /*" -1335- MOVE LK-PF-NUM-DV-PESSOA TO LK-EN-NUM-DV-PESSOA */
                _.Move(LK_PF_PARAMETRO.LK_PF_NUM_DV_PESSOA, LK_EN_PARAMETRO.LK_EN_NUM_DV_PESSOA);

                /*" -1336- ELSE */
            }
            else
            {


                /*" -1337- MOVE LK-PJ-NUM-PESSOA TO LK-EN-NUM-PESSOA */
                _.Move(LK_PJ_PARAMETRO.LK_PJ_NUM_PESSOA, LK_EN_PARAMETRO.LK_EN_NUM_PESSOA);

                /*" -1339- MOVE LK-PJ-NUM-DV-PESSOA TO LK-EN-NUM-DV-PESSOA. */
                _.Move(LK_PJ_PARAMETRO.LK_PJ_NUM_DV_PESSOA, LK_EN_PARAMETRO.LK_EN_NUM_DV_PESSOA);
            }


            /*" -1340- MOVE SISTEMAS-DATA-MOV-ABERTO TO LK-EN-DTH-CADASTRAMENTO-END. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LK_EN_PARAMETRO.LK_EN_DTH_CADASTRAMENTO_END);

            /*" -1341- MOVE CLIENTES-TIPO-PESSOA TO LK-EN-IND-PESSOA. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA, LK_EN_PARAMETRO.LK_EN_IND_PESSOA);

            /*" -1342- MOVE 'S' TO LK-EN-STA-INF-INTEGRA. */
            _.Move("S", LK_EN_PARAMETRO.LK_EN_STA_INF_INTEGRA);

            /*" -1343- MOVE 'S' TO LK-EN-STA-PROPAGANDA. */
            _.Move("S", LK_EN_PARAMETRO.LK_EN_STA_PROPAGANDA);

            /*" -1344- MOVE ENDERECO-ENDERECO TO LK-EN-NOM-LOGRADOURO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, LK_EN_PARAMETRO.LK_EN_NOM_LOGRADOURO);

            /*" -1345- MOVE 'R' TO LK-EN-IND-ENDERECO. */
            _.Move("R", LK_EN_PARAMETRO.LK_EN_IND_ENDERECO);

            /*" -1346- MOVE 'A' TO LK-EN-STA-ENDERECO. */
            _.Move("A", LK_EN_PARAMETRO.LK_EN_STA_ENDERECO);

            /*" -1347- MOVE SPACES TO LK-EN-DES-NUM-IMOVEL. */
            _.Move("", LK_EN_PARAMETRO.LK_EN_DES_NUM_IMOVEL);

            /*" -1348- MOVE ENDERECO-DES-COMPLEMENTO TO LK-EN-DES-COMPL-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO, LK_EN_PARAMETRO.LK_EN_DES_COMPL_ENDERECO);

            /*" -1349- MOVE ENDERECO-BAIRRO TO LK-EN-NOM-BAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, LK_EN_PARAMETRO.LK_EN_NOM_BAIRRO);

            /*" -1350- MOVE ENDERECO-CIDADE TO LK-EN-NOM-CIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, LK_EN_PARAMETRO.LK_EN_NOM_CIDADE);

            /*" -1351- MOVE ENDERECO-CEP TO LK-EN-COD-CEP. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, LK_EN_PARAMETRO.LK_EN_COD_CEP);

            /*" -1352- MOVE ENDERECO-SIGLA-UF TO LK-EN-COD-UF. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, LK_EN_PARAMETRO.LK_EN_COD_UF);

            /*" -1374- MOVE 'S' TO LK-EN-STA-CORRESPONDER. */
            _.Move("S", LK_EN_PARAMETRO.LK_EN_STA_CORRESPONDER);

            /*" -1376- DISPLAY '--- CHAMANDO ... GE0502B' */
            _.Display($"--- CHAMANDO ... GE0502B");

            /*" -1378- CALL 'GE0502B' USING LK-EN-PARAMETRO. */
            _.Call("GE0502B", LK_EN_PARAMETRO);

            /*" -1379- MOVE LK-EN-MSG-ERRO TO WPARM-MSG-ERRO */
            _.Move(LK_EN_PARAMETRO.LK_EN_PARAMETROS_SAIDA.LK_EN_MSG_ERRO, WPARAMETROS.WPARM_MSG_ERRO);

            /*" -1381- MOVE LK-EN-SQLCODE TO WPARM-SQLCODE */
            _.Move(LK_EN_PARAMETRO.LK_EN_PARAMETROS_SAIDA.LK_EN_SQLCODE, WPARAMETROS.WPARM_SQLCODE);

            /*" -1382- IF LK-EN-SEQ-ENDERECO EQUAL ZEROS */

            if (LK_EN_PARAMETRO.LK_EN_SEQ_ENDERECO == 00)
            {

                /*" -1383- MOVE 01 TO WPARM-ERRO09 */
                _.Move(01, WPARAMETROS.WPARM_ERRO09);

                /*" -1384- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -1385- ELSE */
            }
            else
            {


                /*" -1386- IF LK-EN-IND-ERRO EQUAL 'SIM' */

                if (LK_EN_PARAMETRO.LK_EN_PARAMETROS_SAIDA.LK_EN_IND_ERRO == "SIM")
                {

                    /*" -1387- MOVE 01 TO WPARM-ERRO09 */
                    _.Move(01, WPARAMETROS.WPARM_ERRO09);

                    /*" -1389- MOVE 'N' TO WPARM-TEMCONTA. */
                    _.Move("N", WPARAMETROS.WPARM_TEMCONTA);
                }

            }


            /*" -1390- DISPLAY '--- RETORNO .... GE0502B' */
            _.Display($"--- RETORNO .... GE0502B");

            /*" -1391- DISPLAY 'MENSAGEM ' WPARM-MSG-ERRO */
            _.Display($"MENSAGEM {WPARAMETROS.WPARM_MSG_ERRO}");

            /*" -1392- DISPLAY 'SQLCODE  ' WPARM-SQLCODE */
            _.Display($"SQLCODE  {WPARAMETROS.WPARM_SQLCODE}");

            /*" -1392- DISPLAY '----------------------------------' . */
            _.Display($"----------------------------------");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1040-GRAVA-BANCO-SECTION */
        private void R1040_GRAVA_BANCO_SECTION()
        {
            /*" -1403- MOVE '1040' TO WNR-EXEC-SQL. */
            _.Move("1040", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -1405- INITIALIZE LK-BC-PARAMETRO. */
            _.Initialize(
                LK_BC_PARAMETRO
            );

            /*" -1406- MOVE '1' TO LK-BC-TIPO-UTILIZACAO. */
            _.Move("1", LK_BC_PARAMETRO.LK_BC_TIPO_UTILIZACAO);

            /*" -1407- MOVE WPARM-PROGRAMA TO LK-BC-PROGRAMA-CHAMADOR. */
            _.Move(WPARAMETROS.WPARM_PROGRAMA, LK_BC_PARAMETRO.LK_BC_PROGRAMA_CHAMADOR);

            /*" -1409- MOVE WPARM-PROGRAMA TO LK-BC-NOME-USUARIO. */
            _.Move(WPARAMETROS.WPARM_PROGRAMA, LK_BC_PARAMETRO.LK_BC_NOME_USUARIO);

            /*" -1410- IF CLIENTES-TIPO-PESSOA EQUAL 'F' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
            {

                /*" -1411- MOVE 1 TO LK-BC-IND-CONTA-BANCARIA */
                _.Move(1, LK_BC_PARAMETRO.LK_BC_IND_CONTA_BANCARIA);

                /*" -1412- MOVE LK-PF-NUM-PESSOA TO LK-BC-NUM-PESSOA */
                _.Move(LK_PF_PARAMETRO.LK_PF_NUM_PESSOA, LK_BC_PARAMETRO.LK_BC_NUM_PESSOA);

                /*" -1413- MOVE LK-PF-NUM-DV-PESSOA TO LK-BC-NUM-DV-PESSOA */
                _.Move(LK_PF_PARAMETRO.LK_PF_NUM_DV_PESSOA, LK_BC_PARAMETRO.LK_BC_NUM_DV_PESSOA);

                /*" -1414- ELSE */
            }
            else
            {


                /*" -1415- MOVE 2 TO LK-BC-IND-CONTA-BANCARIA */
                _.Move(2, LK_BC_PARAMETRO.LK_BC_IND_CONTA_BANCARIA);

                /*" -1416- MOVE LK-PJ-NUM-PESSOA TO LK-BC-NUM-PESSOA */
                _.Move(LK_PJ_PARAMETRO.LK_PJ_NUM_PESSOA, LK_BC_PARAMETRO.LK_BC_NUM_PESSOA);

                /*" -1418- MOVE LK-PJ-NUM-DV-PESSOA TO LK-BC-NUM-DV-PESSOA. */
                _.Move(LK_PJ_PARAMETRO.LK_PJ_NUM_DV_PESSOA, LK_BC_PARAMETRO.LK_BC_NUM_DV_PESSOA);
            }


            /*" -1419- MOVE SISTEMAS-DATA-MOV-ABERTO TO LK-BC-DTH-CADASTRAMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LK_BC_PARAMETRO.LK_BC_DTH_CADASTRAMENTO);

            /*" -1420- MOVE CLIENTES-TIPO-PESSOA TO LK-BC-IND-PESSOA. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA, LK_BC_PARAMETRO.LK_BC_IND_PESSOA);

            /*" -1421- MOVE 'S' TO LK-BC-STA-INF-INTEGRA. */
            _.Move("S", LK_BC_PARAMETRO.LK_BC_STA_INF_INTEGRA);

            /*" -1422- MOVE ZEROS TO LK-BC-SEQ-CONTA-BANCARIA. */
            _.Move(0, LK_BC_PARAMETRO.LK_BC_SEQ_CONTA_BANCARIA);

            /*" -1424- MOVE 'A' TO LK-BC-STA-CONTA. */
            _.Move("A", LK_BC_PARAMETRO.LK_BC_STA_CONTA);

            /*" -1430- IF ( ( APOLICES-ORGAO-EMISSOR EQUAL 110 ) OR ( APOLICES-ORGAO-EMISSOR EQUAL 10 AND ENDOSSOS-RAMO-EMISSOR EQUAL 53 AND ENDOSSOS-COD-PRODUTO EQUAL 5302 OR 5303 OR 5304 ) ) */

            if (((APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR == 110) || (APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR == 10 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 53 && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("5302", "5303", "5304"))))
            {

                /*" -1431- MOVE GE381-COD-BCO TO LK-BC-COD-BANCO */
                _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_BCO, LK_BC_PARAMETRO.LK_BC_COD_BANCO);

                /*" -1432- MOVE GE381-COD-AGENCIA TO WS-AGENC-AG */
                _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA, W.WS_AGENC01.WS_AGENC_AG);

                /*" -1433- MOVE WS-AGENC01 TO WS-AGENC10 */
                _.Move(W.WS_AGENC01, W.WS_AGENC10);

                /*" -1435- MOVE 5 TO WS-IND1 WS-IND2 */
                _.Move(5, W.WS_IND1, W.WS_IND2);

                /*" -1437- MOVE ZEROS TO WS-AGENC20 */
                _.Move(0, W.WS_AGENC20);

                /*" -1438- PERFORM 5 TIMES */

                for (int i = 0; i < 5; i++)
                {

                    /*" -1439- SUBTRACT 1 FROM WS-IND1 */
                    W.WS_IND1.Value = W.WS_IND1 - 1;

                    /*" -1440- IF CHAR10(WS-IND1) IS NUMERIC */

                    if (W.FILLER_5.CHAR10[W.WS_IND1].IsNumeric())
                    {

                        /*" -1441- SUBTRACT 1 FROM WS-IND2 */
                        W.WS_IND2.Value = W.WS_IND2 - 1;

                        /*" -1442- MOVE CHAR10(WS-IND1) TO CHAR20(WS-IND2) */
                        _.Move(W.FILLER_5.CHAR10[W.WS_IND1], W.FILLER_6.CHAR20[W.WS_IND2]);

                        /*" -1443- END-IF */
                    }


                    /*" -1445- END-PERFORM */
                }

                /*" -1446- MOVE WS-AGENC20 TO LK-BC-COD-AGENCIA */
                _.Move(W.WS_AGENC20, LK_BC_PARAMETRO.LK_BC_COD_AGENCIA);

                /*" -1447- MOVE GE381-COD-OPERACAO TO LK-BC-NUM-OPERACAO-CONTA */
                _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_OPERACAO, LK_BC_PARAMETRO.LK_BC_NUM_OPERACAO_CONTA);

                /*" -1448- MOVE GE381-NUM-CONTA TO LK-BC-NUM-CONTA */
                _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA, LK_BC_PARAMETRO.LK_BC_NUM_CONTA);

                /*" -1449- MOVE SPACES TO AUX-DV-CONTA */
                _.Move("", W.AUX_DV_CONTA);

                /*" -1450- MOVE GE381-NUM-CONTA-DV1 TO AUX-DV-CONTA-NUM */
                _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA_DV1, W.FILLER_3.AUX_DV_CONTA_NUM);

                /*" -1451- MOVE AUX-DV-CONTA TO LK-BC-NUM-DV-CONTA */
                _.Move(W.AUX_DV_CONTA, LK_BC_PARAMETRO.LK_BC_NUM_DV_CONTA);

                /*" -1452- ELSE */
            }
            else
            {


                /*" -1453- MOVE 104 TO LK-BC-COD-BANCO */
                _.Move(104, LK_BC_PARAMETRO.LK_BC_COD_BANCO);

                /*" -1454- MOVE APOLCOBR-COD-AGENCIA-DEB TO LK-BC-COD-AGENCIA */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB, LK_BC_PARAMETRO.LK_BC_COD_AGENCIA);

                /*" -1455- MOVE APOLCOBR-OPER-CONTA-DEB TO LK-BC-NUM-OPERACAO-CONTA */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB, LK_BC_PARAMETRO.LK_BC_NUM_OPERACAO_CONTA);

                /*" -1456- MOVE APOLCOBR-NUM-CONTA-DEB TO LK-BC-NUM-CONTA */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB, LK_BC_PARAMETRO.LK_BC_NUM_CONTA);

                /*" -1457- MOVE SPACES TO AUX-DV-CONTA */
                _.Move("", W.AUX_DV_CONTA);

                /*" -1458- MOVE APOLCOBR-DIG-CONTA-DEB TO AUX-DV-CONTA-NUM */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB, W.FILLER_3.AUX_DV_CONTA_NUM);

                /*" -1475- MOVE AUX-DV-CONTA TO LK-BC-NUM-DV-CONTA. */
                _.Move(W.AUX_DV_CONTA, LK_BC_PARAMETRO.LK_BC_NUM_DV_CONTA);
            }


            /*" -1477- DISPLAY '--- CHAMANDO ... GE0503B' */
            _.Display($"--- CHAMANDO ... GE0503B");

            /*" -1479- CALL 'GE0503B' USING LK-BC-PARAMETRO. */
            _.Call("GE0503B", LK_BC_PARAMETRO);

            /*" -1480- MOVE LK-BC-MSG-ERRO TO WPARM-MSG-ERRO */
            _.Move(LK_BC_PARAMETRO.LK_BC_PARAMETROS_SAIDA.LK_BC_MSG_ERRO, WPARAMETROS.WPARM_MSG_ERRO);

            /*" -1482- MOVE LK-BC-SQLCODE TO WPARM-SQLCODE */
            _.Move(LK_BC_PARAMETRO.LK_BC_PARAMETROS_SAIDA.LK_BC_SQLCODE, WPARAMETROS.WPARM_SQLCODE);

            /*" -1483- IF LK-BC-SEQ-CONTA-BANCARIA EQUAL ZEROS */

            if (LK_BC_PARAMETRO.LK_BC_SEQ_CONTA_BANCARIA == 00)
            {

                /*" -1484- MOVE 01 TO WPARM-ERRO10 */
                _.Move(01, WPARAMETROS.WPARM_ERRO10);

                /*" -1485- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -1486- ELSE */
            }
            else
            {


                /*" -1487- IF LK-BC-IND-ERRO EQUAL 'SIM' */

                if (LK_BC_PARAMETRO.LK_BC_PARAMETROS_SAIDA.LK_BC_IND_ERRO == "SIM")
                {

                    /*" -1488- MOVE 01 TO WPARM-ERRO10 */
                    _.Move(01, WPARAMETROS.WPARM_ERRO10);

                    /*" -1490- MOVE 'N' TO WPARM-TEMCONTA. */
                    _.Move("N", WPARAMETROS.WPARM_TEMCONTA);
                }

            }


            /*" -1491- DISPLAY '--- RETORNO .... GE0503B' */
            _.Display($"--- RETORNO .... GE0503B");

            /*" -1492- DISPLAY 'MENSAGEM ' WPARM-MSG-ERRO */
            _.Display($"MENSAGEM {WPARAMETROS.WPARM_MSG_ERRO}");

            /*" -1493- DISPLAY 'SQLCODE  ' WPARM-SQLCODE */
            _.Display($"SQLCODE  {WPARAMETROS.WPARM_SQLCODE}");

            /*" -1493- DISPLAY '----------------------------------' . */
            _.Display($"----------------------------------");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_99_SAIDA*/

        [StopWatch]
        /*" R1100-GRAVA-PESSOA-LEGADO-SECTION */
        private void R1100_GRAVA_PESSOA_LEGADO_SECTION()
        {
            /*" -1504- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", W.FILLER_6.WABEND.WNR_EXEC_SQL);

            /*" -1508- INITIALIZE LK-LEGADO-PARAMETRO. */
            _.Initialize(
                LK_LEGADO_PARAMETRO
            );

            /*" -1509- MOVE 3 TO LK-COD-OPERACAO. */
            _.Move(3, LK_LEGADO_PARAMETRO.LK_COD_OPERACAO);

            /*" -1510- MOVE WPARM-NUMAPOL TO LK-NUM-APOLICE. */
            _.Move(WPARAMETROS.WPARM_NUMAPOL, LK_LEGADO_PARAMETRO.LK_NUM_APOLICE);

            /*" -1511- MOVE WPARM-NRENDOS TO LK-NUM-ENDOSSO. */
            _.Move(WPARAMETROS.WPARM_NRENDOS, LK_LEGADO_PARAMETRO.LK_NUM_ENDOSSO);

            /*" -1512- MOVE WPARM-NRPARCEL TO LK-NUM-PARCELA. */
            _.Move(WPARAMETROS.WPARM_NRPARCEL, LK_LEGADO_PARAMETRO.LK_NUM_PARCELA);

            /*" -1513- MOVE WPARM-OCORHIST TO LK-OCORR-HISTORICO. */
            _.Move(WPARAMETROS.WPARM_OCORHIST, LK_LEGADO_PARAMETRO.LK_OCORR_HISTORICO);

            /*" -1514- MOVE LK-EN-NUM-PESSOA TO LK-NUM-PESSOA. */
            _.Move(LK_EN_PARAMETRO.LK_EN_NUM_PESSOA, LK_LEGADO_PARAMETRO.LK_NUM_PESSOA);

            /*" -1521- MOVE ZEROS TO LK-NUM-OCORR-MOVTO. */
            _.Move(0, LK_LEGADO_PARAMETRO.LK_NUM_OCORR_MOVTO);

            /*" -1522- MOVE 'S' TO LK-IND-INFORMACAO-PEDIDA(1). */
            _.Move("S", LK_LEGADO_PARAMETRO.LK_TABELA_PONTEIRO[1].LK_IND_INFORMACAO_PEDIDA);

            /*" -1523- MOVE 1 TO LK-IND-ENTIDADE-PEDIDA(1). */
            _.Move(1, LK_LEGADO_PARAMETRO.LK_TABELA_PONTEIRO[1].LK_IND_ENTIDADE_PEDIDA);

            /*" -1527- MOVE LK-EN-SEQ-ENDERECO TO LK-SEQ-ENTIDADE(1). */
            _.Move(LK_EN_PARAMETRO.LK_EN_SEQ_ENDERECO, LK_LEGADO_PARAMETRO.LK_TABELA_PONTEIRO[1].LK_SEQ_ENTIDADE);

            /*" -1528- MOVE 'S' TO LK-IND-INFORMACAO-PEDIDA(3). */
            _.Move("S", LK_LEGADO_PARAMETRO.LK_TABELA_PONTEIRO[3].LK_IND_INFORMACAO_PEDIDA);

            /*" -1529- MOVE 3 TO LK-IND-ENTIDADE-PEDIDA(3). */
            _.Move(3, LK_LEGADO_PARAMETRO.LK_TABELA_PONTEIRO[3].LK_IND_ENTIDADE_PEDIDA);

            /*" -1533- MOVE LK-BC-SEQ-CONTA-BANCARIA TO LK-SEQ-ENTIDADE(3). */
            _.Move(LK_BC_PARAMETRO.LK_BC_SEQ_CONTA_BANCARIA, LK_LEGADO_PARAMETRO.LK_TABELA_PONTEIRO[3].LK_SEQ_ENTIDADE);

            /*" -1534- MOVE 3 TO LK-COD-EVENTO. */
            _.Move(3, LK_LEGADO_PARAMETRO.LK_COD_EVENTO);

            /*" -1535- MOVE 'CB' TO LK-IDE-SISTEMA. */
            _.Move("CB", LK_LEGADO_PARAMETRO.LK_IDE_SISTEMA);

            /*" -1539- MOVE SISTEMAS-DATA-MOV-ABERTO TO LK-DTH-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LK_LEGADO_PARAMETRO.LK_DTH_MOVIMENTO);

            /*" -1543- MOVE 3 TO LK-IND-ESTRUTURA. */
            _.Move(3, LK_LEGADO_PARAMETRO.LK_IND_ESTRUTURA);

            /*" -1547- MOVE 7 TO LK-IND-ORIGEM-FUNC. */
            _.Move(7, LK_LEGADO_PARAMETRO.LK_IND_ORIGEM_FUNC);

            /*" -1548- MOVE 1 TO LK-IND-EVENTO. */
            _.Move(1, LK_LEGADO_PARAMETRO.LK_IND_EVENTO);

            /*" -1549- MOVE WPARM-PROGRAMA TO LK-NOM-PROGRAMA. */
            _.Move(WPARAMETROS.WPARM_PROGRAMA, LK_LEGADO_PARAMETRO.LK_NOM_PROGRAMA);

            /*" -1553- MOVE WPARM-PROGRAMA TO LK-COD-USUARIO. */
            _.Move(WPARAMETROS.WPARM_PROGRAMA, LK_LEGADO_PARAMETRO.LK_COD_USUARIO);

            /*" -1554- MOVE 1 TO LK-IND-RELACIONAMENTO. */
            _.Move(1, LK_LEGADO_PARAMETRO.LK_IND_RELACIONAMENTO);

            /*" -1555- MOVE SPACES TO LK-HORA-OPERACAO. */
            _.Move("", LK_LEGADO_PARAMETRO.LK_HORA_OPERACAO);

            /*" -1556- MOVE ZEROS TO LK-COD-FONTE. */
            _.Move(0, LK_LEGADO_PARAMETRO.LK_COD_FONTE);

            /*" -1557- MOVE ZEROS TO LK-NUM-RCAP. */
            _.Move(0, LK_LEGADO_PARAMETRO.LK_NUM_RCAP);

            /*" -1558- MOVE ZEROS TO LK-NUM-APOL-SINISTRO. */
            _.Move(0, LK_LEGADO_PARAMETRO.LK_NUM_APOL_SINISTRO);

            /*" -1559- MOVE ZEROS TO LK-COD-OPERACAO-SI. */
            _.Move(0, LK_LEGADO_PARAMETRO.LK_COD_OPERACAO_SI);

            /*" -1560- MOVE ZEROS TO LK-NUM-CERTIFICADO. */
            _.Move(0, LK_LEGADO_PARAMETRO.LK_NUM_CERTIFICADO);

            /*" -1566- MOVE ZEROS TO LK-NUM-TITULO. */
            _.Move(0, LK_LEGADO_PARAMETRO.LK_NUM_TITULO);

            /*" -1568- DISPLAY '--- CHAMANDO ... GE0550B' */
            _.Display($"--- CHAMANDO ... GE0550B");

            /*" -1570- CALL 'GE0550B' USING LK-LEGADO-PARAMETRO. */
            _.Call("GE0550B", LK_LEGADO_PARAMETRO);

            /*" -1571- MOVE H-OUT-MENSAGEM TO WPARM-MSG-ERRO */
            _.Move(LK_LEGADO_PARAMETRO.LK_LEGADO_SAIDA.H_OUT_MENSAGEM, WPARAMETROS.WPARM_MSG_ERRO);

            /*" -1573- MOVE H-OUT-COD-RETORNO-SQL TO WPARM-SQLCODE */
            _.Move(LK_LEGADO_PARAMETRO.LK_LEGADO_SAIDA.H_OUT_COD_RETORNO_SQL, WPARAMETROS.WPARM_SQLCODE);

            /*" -1574- IF LK-NUM-OCORR-MOVTO EQUAL ZEROS */

            if (LK_LEGADO_PARAMETRO.LK_NUM_OCORR_MOVTO == 00)
            {

                /*" -1575- MOVE 01 TO WPARM-ERRO11 */
                _.Move(01, WPARAMETROS.WPARM_ERRO11);

                /*" -1576- MOVE 'N' TO WPARM-TEMCONTA */
                _.Move("N", WPARAMETROS.WPARM_TEMCONTA);

                /*" -1577- ELSE */
            }
            else
            {


                /*" -1578- IF H-OUT-COD-RETORNO EQUAL 1 */

                if (LK_LEGADO_PARAMETRO.LK_LEGADO_SAIDA.H_OUT_COD_RETORNO == 1)
                {

                    /*" -1579- MOVE 01 TO WPARM-ERRO11 */
                    _.Move(01, WPARAMETROS.WPARM_ERRO11);

                    /*" -1581- MOVE 'N' TO WPARM-TEMCONTA. */
                    _.Move("N", WPARAMETROS.WPARM_TEMCONTA);
                }

            }


            /*" -1582- DISPLAY '--- RETORNO .... GE0550B' */
            _.Display($"--- RETORNO .... GE0550B");

            /*" -1583- DISPLAY 'MENSAGEM ' WPARM-MSG-ERRO */
            _.Display($"MENSAGEM {WPARAMETROS.WPARM_MSG_ERRO}");

            /*" -1584- DISPLAY 'SQLCODE  ' WPARM-SQLCODE */
            _.Display($"SQLCODE  {WPARAMETROS.WPARM_SQLCODE}");

            /*" -1584- DISPLAY '----------------------------------' . */
            _.Display($"----------------------------------");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/
    }
}