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
using Sias.PessoaFisica.DB2.PF0402B;

namespace Code
{
    public class PF0402B
    {
        public bool IsCall { get; set; }

        public PF0402B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *   FUNCAO .................  GERA RELACAO DA SITUACAO DAS PRO   *      */
        /*"      *                             POSTAS ENCAMINHADAS A CEF  E QUE   *      */
        /*"      *                             RETORNARAM COM PROBLEMAS.          *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  LUIZ CARLOS.                       *      */
        /*"      *   PROGRAMA ...............  PF0402B                            *      */
        /*"      *   DATA ...................  28/11/2000.                        *      */
        /*"      ******************************************************************      */
        /*"      *   REVISAO.................  REGINALDO DA SILVA                 *      */
        /*"      *   DATA....................  21/03/2013                         *      */
        /*"      ******************************************************************      */
        /*"      * ALTERACAO NO ACESSO A TABELA PRODUTOS_SIVPF EM FUNCAO DE       *      */
        /*"      * HAVER MAIS DE UMA LINHA PARA O MESMO COD_PRODUTO_SIVPF         *      */
        /*"      * (VIDA DA GENTE E MULTIPREMIADO SUPER)                          *      */
        /*"      * (PROCURAR POR 240703) - CHICON (PRODEXTER)            JUL/2003 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *-------------------   M A N U T E N C O E S   ------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 02             AJUSTE NOS CODIGOS DE SAIDA NAS PESQUISA *      */
        /*"      *                       DE TABELAS                               *      */
        /*"      * ATENDE JAZZ 327526                                             *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.02          REGINALDO SILVA                          *      */
        /*"      *                       18/10/2021                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RPF0402B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RPF0402B
        {
            get
            {
                _.Move(REG_RPF0402B, _RPF0402B); VarBasis.RedefinePassValue(REG_RPF0402B, _RPF0402B, REG_RPF0402B); return _RPF0402B;
            }
        }
        public FileBasis _DPF0402B { get; set; } = new FileBasis(new PIC("X", "130", "X(130)"));

        public FileBasis DPF0402B
        {
            get
            {
                _.Move(REG_DPF0402B, _DPF0402B); VarBasis.RedefinePassValue(REG_DPF0402B, _DPF0402B, REG_DPF0402B); return _DPF0402B;
            }
        }
        public SortBasis<PF0402B_REG_SPF0402B> SPF0402B { get; set; } = new SortBasis<PF0402B_REG_SPF0402B>(new PF0402B_REG_SPF0402B());
        /*"01   REG-SPF0402B.*/
        public PF0402B_REG_SPF0402B REG_SPF0402B { get; set; } = new PF0402B_REG_SPF0402B();
        public class PF0402B_REG_SPF0402B : VarBasis
        {
            /*"     10   SVA-COD-PRODUTO                PIC 9(04).*/
            public IntBasis SVA_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"     10   SVA-NSAS-SIVPF                 PIC 9(09).*/
            public IntBasis SVA_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"     10   SVA-NUM-PROPOSTA               PIC 9(15).*/
            public IntBasis SVA_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"     10   SVA-COD-PESSOA                 PIC 9(09).*/
            public IntBasis SVA_COD_PESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"     10   SVA-NUM-IDENTIFICACAO          PIC 9(15).*/
            public IntBasis SVA_NUM_IDENTIFICACAO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"     10   SVA-SIT-PROPOSTA               PIC X(03).*/
            public StringBasis SVA_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"01   REG-RPF0402B                     PIC X(132).*/
        }
        public StringBasis REG_RPF0402B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01   REG-DPF0402B.*/
        public PF0402B_REG_DPF0402B REG_DPF0402B { get; set; } = new PF0402B_REG_DPF0402B();
        public class PF0402B_REG_DPF0402B : VarBasis
        {
            /*"     10  REG-TIPO-REG                PIC  9(001).*/
            public IntBasis REG_TIPO_REG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  REG-NUM-PROPOSTA            PIC  9(014).*/
            public IntBasis REG_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  FILLER                      PIC  X(082).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "82", "X(082)."), @"");
            /*"     10  REG-TIPO-ERRO               PIC  9(003).*/
            public IntBasis REG_TIPO_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-CONT-LIDOS                    PIC  9(07) VALUE ZEROS.*/
        public IntBasis WS_CONT_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77  WS-CONT-NAOCAD                   PIC  9(07) VALUE ZEROS.*/
        public IntBasis WS_CONT_NAOCAD { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77  WS-CONT-LIDOS-SORT               PIC  9(07) VALUE ZEROS.*/
        public IntBasis WS_CONT_LIDOS_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"01  WAREA-AUXILIAR.*/
        public PF0402B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0402B_WAREA_AUXILIAR();
        public class PF0402B_WAREA_AUXILIAR : VarBasis
        {
            /*"  05  W-CONT-LINHAS                 PIC 9(002)  VALUE 99.*/
            public IntBasis W_CONT_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 99);
            /*"  05  W-FIM-PROPOSTA                PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  W-FIM-SORT                    PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_SORT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  W-PRODUTO-ANT                 PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_PRODUTO_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05  W-NSAS-ANT                    PIC 9(009)  VALUE ZEROS.*/
            public IntBasis W_NSAS_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05  W-DTMOVABE                    PIC X(010).*/
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0402B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0402B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0402B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0402B_W_DTMOVABE1 : VarBasis
            {
                /*"      07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  W-DTMOVABE-I                  PIC X(010).*/

                public _REDEF_PF0402B_W_DTMOVABE1()
                {
                    W_ANO_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_MOVABE.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05  W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
            private _REDEF_PF0402B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0402B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0402B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0402B_W_DTMOVABE_I1 : VarBasis
            {
                /*"      07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05  W-DT-TRABALHO                 PIC X(010).*/

                public _REDEF_PF0402B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DT_TRABALHO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05  FILLER        REDEFINES W-DT-TRABALHO.*/
            private _REDEF_PF0402B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0402B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0402B_FILLER_1(); _.Move(W_DT_TRABALHO, _filler_1); VarBasis.RedefinePassValue(W_DT_TRABALHO, _filler_1, W_DT_TRABALHO); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_DT_TRABALHO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_DT_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0402B_FILLER_1 : VarBasis
            {
                /*"      07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      07  FILLER                    PIC X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      07  FILLER                    PIC X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  W-DT-SITUACAO                 PIC X(010).*/

                public _REDEF_PF0402B_FILLER_1()
                {
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DT_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05  FILLER        REDEFINES W-DT-SITUACAO.*/
            private _REDEF_PF0402B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PF0402B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PF0402B_FILLER_4(); _.Move(W_DT_SITUACAO, _filler_4); VarBasis.RedefinePassValue(W_DT_SITUACAO, _filler_4, W_DT_SITUACAO); _filler_4.ValueChanged += () => { _.Move(_filler_4, W_DT_SITUACAO); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, W_DT_SITUACAO); }
            }  //Redefines
            public class _REDEF_PF0402B_FILLER_4 : VarBasis
            {
                /*"      07  W-DIA-SITUACAO            PIC 9(002).*/
                public IntBasis W_DIA_SITUACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      07  BARRA1                    PIC X(001).*/
                public StringBasis BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      07  W-MES-SITUACAO            PIC 9(002).*/
                public IntBasis W_MES_SITUACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      07  BARRA2                    PIC X(001).*/
                public StringBasis BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      07  W-ANO-SITUACAO            PIC 9(004).*/
                public IntBasis W_ANO_SITUACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05   W-NUM-PROPOSTA                PIC 9(014).*/

                public _REDEF_PF0402B_FILLER_4()
                {
                    W_DIA_SITUACAO.ValueChanged += OnValueChanged;
                    BARRA1.ValueChanged += OnValueChanged;
                    W_MES_SITUACAO.ValueChanged += OnValueChanged;
                    BARRA2.ValueChanged += OnValueChanged;
                    W_ANO_SITUACAO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  05   FILLER REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_PF0402B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_PF0402B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_PF0402B_FILLER_5(); _.Move(W_NUM_PROPOSTA, _filler_5); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _filler_5, W_NUM_PROPOSTA); _filler_5.ValueChanged += () => { _.Move(_filler_5, W_NUM_PROPOSTA); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0402B_FILLER_5 : VarBasis
            {
                /*"    10 W-CANAL-PROPOSTA          PIC 9(001).*/
                public IntBasis W_CANAL_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10 W-AGENCIA-PROPOSTA        PIC 9(004).*/
                public IntBasis W_AGENCIA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10 W-PRODUTO-PROPOSTA        PIC 9(002).*/
                public IntBasis W_PRODUTO_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10 W-SEGUENC-PROPOSTA        PIC 9(006).*/
                public IntBasis W_SEGUENC_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10 W-DIGITOX-PROPOSTA        PIC 9(001).*/
                public IntBasis W_DIGITOX_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05   W-PRODUTO-AUTO            PIC 9(004).*/

                public _REDEF_PF0402B_FILLER_5()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    W_AGENCIA_PROPOSTA.ValueChanged += OnValueChanged;
                    W_PRODUTO_PROPOSTA.ValueChanged += OnValueChanged;
                    W_SEGUENC_PROPOSTA.ValueChanged += OnValueChanged;
                    W_DIGITOX_PROPOSTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_PRODUTO_AUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05   FILLER REDEFINES W-PRODUTO-AUTO.*/
            private _REDEF_PF0402B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_PF0402B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_PF0402B_FILLER_6(); _.Move(W_PRODUTO_AUTO, _filler_6); VarBasis.RedefinePassValue(W_PRODUTO_AUTO, _filler_6, W_PRODUTO_AUTO); _filler_6.ValueChanged += () => { _.Move(_filler_6, W_PRODUTO_AUTO); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, W_PRODUTO_AUTO); }
            }  //Redefines
            public class _REDEF_PF0402B_FILLER_6 : VarBasis
            {
                /*"    10 W-PRODUTO-AUTO-FIXO       PIC 9(002).*/
                public IntBasis W_PRODUTO_AUTO_FIXO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10 W-PRODUTO-AUTO-VAR        PIC 9(002).*/
                public IntBasis W_PRODUTO_AUTO_VAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05            LC01.*/

                public _REDEF_PF0402B_FILLER_6()
                {
                    W_PRODUTO_AUTO_FIXO.ValueChanged += OnValueChanged;
                    W_PRODUTO_AUTO_VAR.ValueChanged += OnValueChanged;
                }

            }
            public PF0402B_LC01 LC01 { get; set; } = new PF0402B_LC01();
            public class PF0402B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATORIO  PIC  X(007) VALUE 'PF0402B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PF0402B");
                /*"    10          FILLER          PIC  X(050) VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10          FILLER          PIC  X(028) VALUE     'C A I X A    S E G U R O S '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"C A I X A    S E G U R O S ");
                /*"    10          FILLER          PIC  X(024) VALUE  SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"    10          FILLER          PIC  X(012) VALUE '    PAGINA: '*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"    PAGINA: ");
                /*"    10          LC01-PAGINA     PIC  9(04).*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"  05            LC02.*/
            }
            public PF0402B_LC02 LC02 { get; set; } = new PF0402B_LC02();
            public class PF0402B_LC02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(113) VALUE  SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "113", "X(113)"), @"");
                /*"    10          FILLER          PIC  X(008) VALUE 'DATA..: '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"DATA..: ");
                /*"    10          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public PF0402B_LC03 LC03 { get; set; } = new PF0402B_LC03();
            public class PF0402B_LC03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(040) VALUE  SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER          PIC  X(068) VALUE   'SITUACAO DAS PROPOSTAS ENVIADAS A CEF E RETORNADAS COM ERRO'*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "68", "X(068)"), @"SITUACAO DAS PROPOSTAS ENVIADAS A CEF E RETORNADAS COM ERRO");
                /*"    10          FILLER          PIC  X(005) VALUE  SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10          FILLER          PIC  X(008) VALUE 'HORA..: '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"HORA..: ");
                /*"    10          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public PF0402B_LC04 LC04 { get; set; } = new PF0402B_LC04();
            public class PF0402B_LC04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(009) VALUE               'PRODUTO: '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"PRODUTO: ");
                /*"    10          LC04-PRODUTO    PIC  ZZZ9.*/
                public IntBasis LC04_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    10          FILLER          PIC  X(003) VALUE               ' - '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    10          LC04-NM-PRODUTO PIC  X(040).*/
                public StringBasis LC04_NM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10          FILLER          PIC  X(073) VALUE  SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "73", "X(073)"), @"");
                /*"  05            LC05.*/
            }
            public PF0402B_LC05 LC05 { get; set; } = new PF0402B_LC05();
            public class PF0402B_LC05 : VarBasis
            {
                /*"    10          FILLER            PIC  X(009) VALUE               'ARQUIVO: '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"ARQUIVO: ");
                /*"    10          LC05-NSAS-SIVPF   PIC  ZZZ9.*/
                public IntBasis LC05_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    10          FILLER            PIC  X(013) VALUE               ' - GERADO EM '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" - GERADO EM ");
                /*"    10          LC05-DATA-GERACAO PIC  X(010).*/
                public StringBasis LC05_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER            PIC  X(093) VALUE  SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "93", "X(093)"), @"");
                /*"  05            LC06.*/
            }
            public PF0402B_LC06 LC06 { get; set; } = new PF0402B_LC06();
            public class PF0402B_LC06 : VarBasis
            {
                /*"    10          FILLER            PIC  X(013) VALUE               '    PROPOSTA '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"    PROPOSTA ");
                /*"    10          FILLER            PIC  X(018) VALUE SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"    10          FILLER            PIC  X(013) VALUE               ' NOME CLIENTE'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" NOME CLIENTE");
                /*"    10          FILLER            PIC  X(040) VALUE SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER            PIC  X(015) VALUE               ' SITUACAO ATUAL'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @" SITUACAO ATUAL");
                /*"    10          FILLER            PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10          FILLER            PIC  X(013) VALUE               'DATA SITUACAO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"DATA SITUACAO");
                /*"    10          FILLER            PIC  X(017) VALUE SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"  05            LC07.*/
            }
            public PF0402B_LC07 LC07 { get; set; } = new PF0402B_LC07();
            public class PF0402B_LC07 : VarBasis
            {
                /*"    10          FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LC07-NUM-PROPOSTA   PIC  9(014).*/
                public IntBasis LC07_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    10          FILLER              PIC  X(010) VALUE  SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10          LC07-NOME-CLIENTE   PIC  X(050).*/
                public StringBasis LC07_NOME_CLIENTE { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"    10          FILLER              PIC  X(015) VALUE  SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10          LC07-SITUACAO       PIC  X(003).*/
                public StringBasis LC07_SITUACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10          FILLER              PIC  X(010) VALUE  SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10          LC07-DATA-SITUACAO  PIC  X(010).*/
                public StringBasis LC07_DATA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER              PIC  X(017) VALUE  SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"  05            LC08.*/
            }
            public PF0402B_LC08 LC08 { get; set; } = new PF0402B_LC08();
            public class PF0402B_LC08 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"01  WS-TIME.*/
            }
        }
        public PF0402B_WS_TIME WS_TIME { get; set; } = new PF0402B_WS_TIME();
        public class PF0402B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01  WABEND.*/
        public PF0402B_WABEND WABEND { get; set; } = new PF0402B_WABEND();
        public class PF0402B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'PF0402B  '.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0402B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      05      LOCALIZA-ABEND-1.*/
            public PF0402B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0402B_LOCALIZA_ABEND_1();
            public class PF0402B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        10    FILLER                   PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        10    PARAGRAFO                PIC  X(040)   VALUE SPACES      05      LOCALIZA-ABEND-2.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"        10    FILLER                   PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        10    COMANDO                  PIC  X(060)   VALUE SPACES*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Copies.LBWPF400 LBWPF400 { get; set; } = new Copies.LBWPF400();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.ESCRINEG ESCRINEG { get; set; } = new Dclgens.ESCRINEG();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public PF0402B_HIST_PROP_FIDELIZ HIST_PROP_FIDELIZ { get; set; } = new PF0402B_HIST_PROP_FIDELIZ();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RPF0402B_FILE_NAME_P, string DPF0402B_FILE_NAME_P, string SPF0402B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RPF0402B.SetFile(RPF0402B_FILE_NAME_P);
                DPF0402B.SetFile(DPF0402B_FILE_NAME_P);
                SPF0402B.SetFile(SPF0402B_FILE_NAME_P);

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
            /*" -318- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -319- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -320- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -323- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -324- DISPLAY '*               PROGRAMA PF0402B               *' . */
            _.Display($"*               PROGRAMA PF0402B               *");

            /*" -325- DISPLAY '* RELAT SIT DAS PROP ENC A CAIXA QUE RET PROB  *' . */
            _.Display($"* RELAT SIT DAS PROP ENC A CAIXA QUE RET PROB  *");

            /*" -326- DISPLAY '*           VERSAO:  01 - 21/07/2014           *' . */
            _.Display($"*           VERSAO:  01 - 21/07/2014           *");

            /*" -327- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -336- DISPLAY '*  PF0402B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0402B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -338- PERFORM R0001-00-INICIALIZAR. */

            R0001_00_INICIALIZAR_SECTION();

            /*" -343- SORT SPF0402B ON ASCENDING KEY SVA-COD-PRODUTO, SVA-NSAS-SIVPF, SVA-NUM-PROPOSTA INPUT PROCEDURE R0010-00-PROCESSA THRU R0010-99-SAIDA OUTPUT PROCEDURE R0020-00-GERA-ARQ THRU R0020-99-SAIDA. */
            SPF0402B.Sort("SVA-COD-PRODUTO,,SVA-NSAS-SIVPF,,SVA-NUM-PROPOSTA", () => R0010_00_PROCESSA_SECTION(), () => R0020_00_GERA_ARQ_SECTION());

            /*" -345- GO TO R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION(); //GOTO
            return;

        }

        [StopWatch]
        /*" R0001-00-INICIALIZAR-SECTION */
        private void R0001_00_INICIALIZAR_SECTION()
        {
            /*" -355- OPEN INPUT DPF0402B. */
            DPF0402B.Open(REG_DPF0402B);

            /*" -357- PERFORM R0910-00-LER-MOVTO. */

            R0910_00_LER_MOVTO_SECTION();

            /*" -358- IF W-FIM-PROPOSTA EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_PROPOSTA == "FIM")
            {

                /*" -359- DISPLAY '*********************************************' */
                _.Display($"*********************************************");

                /*" -360- DISPLAY '*                                           *' */
                _.Display($"*                                           *");

                /*" -361- DISPLAY '*            PF0402B - FIM NORMAL           *' */
                _.Display($"*            PF0402B - FIM NORMAL           *");

                /*" -362- DISPLAY '*                                           *' */
                _.Display($"*                                           *");

                /*" -363- DISPLAY '*            NAO HOUVE  MOVIMENTO           *' */
                _.Display($"*            NAO HOUVE  MOVIMENTO           *");

                /*" -364- DISPLAY '*                                           *' */
                _.Display($"*                                           *");

                /*" -365- DISPLAY '*********************************************' */
                _.Display($"*********************************************");

                /*" -366- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -368- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -370- PERFORM R9997-00-SELECT-V0SISTEMA. */

            R9997_00_SELECT_V0SISTEMA_SECTION();

            /*" -370- PERFORM R9998-00-FORMATA-CABEC. */

            R9998_00_FORMATA_CABEC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-PROCESSA-SECTION */
        private void R0010_00_PROCESSA_SECTION()
        {
            /*" -381- PERFORM R0100-00-PROCESSA-REGISTRO UNTIL W-FIM-PROPOSTA EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_PROPOSTA == "FIM"))
            {

                R0100_00_PROCESSA_REGISTRO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-GERA-ARQ-SECTION */
        private void R0020_00_GERA_ARQ_SECTION()
        {
            /*" -393- MOVE SPACES TO W-FIM-PROPOSTA. */
            _.Move("", WAREA_AUXILIAR.W_FIM_PROPOSTA);

            /*" -395- OPEN OUTPUT RPF0402B. */
            RPF0402B.Open(REG_RPF0402B);

            /*" -397- PERFORM R1910-00-LE-SORT. */

            R1910_00_LE_SORT_SECTION();

            /*" -400- PERFORM R0200-00-PROCESSA-SORT UNTIL W-FIM-SORT EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_SORT == "FIM"))
            {

                R0200_00_PROCESSA_SORT_SECTION();
            }

            /*" -402- MOVE 'FIM' TO W-FIM-PROPOSTA. */
            _.Move("FIM", WAREA_AUXILIAR.W_FIM_PROPOSTA);

            /*" -402- PERFORM R9000-00-FECHAR-ARQUIVOS. */

            R9000_00_FECHAR_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-PROCESSA-REGISTRO-SECTION */
        private void R0100_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -410- MOVE 'R0100-00-PROCESSA-REGISTRO ' TO PARAGRAFO. */
            _.Move("R0100-00-PROCESSA-REGISTRO ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -412- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -414- MOVE REG-NUM-PROPOSTA TO SVA-NUM-PROPOSTA. */
            _.Move(REG_DPF0402B.REG_NUM_PROPOSTA, REG_SPF0402B.SVA_NUM_PROPOSTA);

            /*" -416- PERFORM R0110-00-SELECT-PROP-FID */

            R0110_00_SELECT_PROP_FID_SECTION();

            /*" -420- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -421- ADD 1 TO WS-CONT-NAOCAD */
                WS_CONT_NAOCAD.Value = WS_CONT_NAOCAD + 1;

                /*" -423- GO TO R0100-99-SAIDA. */

                R0100_99_SAIDA(); //GOTO
                return;
            }


            /*" -426- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO SVA-COD-PRODUTO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, REG_SPF0402B.SVA_COD_PRODUTO);

            /*" -429- MOVE PROPOFID-COD-PESSOA OF DCLPROPOSTA-FIDELIZ TO SVA-COD-PESSOA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA, REG_SPF0402B.SVA_COD_PESSOA);

            /*" -432- MOVE PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO SVA-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, REG_SPF0402B.SVA_NUM_IDENTIFICACAO);

            /*" -435- MOVE PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO SVA-SIT-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA, REG_SPF0402B.SVA_SIT_PROPOSTA);

            /*" -438- MOVE PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ TO SVA-NSAS-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF, REG_SPF0402B.SVA_NSAS_SIVPF);

            /*" -438- RELEASE REG-SPF0402B. */
            SPF0402B.Release(REG_SPF0402B);

            /*" -0- FLUXCONTROL_PERFORM R0100_99_SAIDA */

            R0100_99_SAIDA();

        }

        [StopWatch]
        /*" R0100-99-SAIDA */
        private void R0100_99_SAIDA(bool isPerform = false)
        {
            /*" -442- PERFORM R0910-00-LER-MOVTO. */

            R0910_00_LER_MOVTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_SAIDA*/

        [StopWatch]
        /*" R0110-00-SELECT-PROP-FID-SECTION */
        private void R0110_00_SELECT_PROP_FID_SECTION()
        {
            /*" -450- MOVE 'R0110-00-SELECT-PROP-FID' TO PARAGRAFO. */
            _.Move("R0110-00-SELECT-PROP-FID", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -452- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -455- MOVE REG-NUM-PROPOSTA TO PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(REG_DPF0402B.REG_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -470- PERFORM R0110_00_SELECT_PROP_FID_DB_SELECT_1 */

            R0110_00_SELECT_PROP_FID_DB_SELECT_1();

            /*" -473- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -476- DISPLAY '==> PF0402B - PROBLEMAS NO ACESSO PRP-FIDELIZ ' REG-NUM-PROPOSTA '  ' SQLCODE */

                $"==> PF0402B - PROBLEMAS NO ACESSO PRP-FIDELIZ {REG_DPF0402B.REG_NUM_PROPOSTA}  {DB.SQLCODE}"
                .Display();

                /*" -477- PERFORM R9000-00-FECHAR-ARQUIVOS */

                R9000_00_FECHAR_ARQUIVOS_SECTION();

                /*" -477- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0110-00-SELECT-PROP-FID-DB-SELECT-1 */
        public void R0110_00_SELECT_PROP_FID_DB_SELECT_1()
        {
            /*" -470- EXEC SQL SELECT COD_PRODUTO_SIVPF, COD_PESSOA, NUM_IDENTIFICACAO, SIT_PROPOSTA, NSAS_SIVPF INTO :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-IDENTIFICACAO, :DCLPROPOSTA-FIDELIZ.PROPOFID-SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAS-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1 = new R0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1.Execute(r0110_00_SELECT_PROP_FID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_NSAS_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_SAIDA*/

        [StopWatch]
        /*" R1910-00-LE-SORT-SECTION */
        private void R1910_00_LE_SORT_SECTION()
        {
            /*" -488- MOVE 'R1910-00-LE-SORT' TO PARAGRAFO. */
            _.Move("R1910-00-LE-SORT", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -490- MOVE 'RETURN' TO COMANDO. */
            _.Move("RETURN", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -492- RETURN SPF0402B AT END */
            try
            {
                SPF0402B.Return(REG_SPF0402B, () =>
                {

                    /*" -493- MOVE 'FIM' TO W-FIM-SORT */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_SORT);

                    /*" -495- GO TO R1910-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -495- ADD 1 TO WS-CONT-LIDOS-SORT. */
            WS_CONT_LIDOS_SORT.Value = WS_CONT_LIDOS_SORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-PROCESSA-SORT-SECTION */
        private void R0200_00_PROCESSA_SORT_SECTION()
        {
            /*" -506- MOVE 'R0200-00-PROCESSA-SORT' TO PARAGRAFO. */
            _.Move("R0200-00-PROCESSA-SORT", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -508- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -510- MOVE SVA-NUM-PROPOSTA TO W-NUM-PROPOSTA. */
            _.Move(REG_SPF0402B.SVA_NUM_PROPOSTA, WAREA_AUXILIAR.W_NUM_PROPOSTA);

            /*" -514- MOVE SVA-COD-PRODUTO TO W-PRODUTO-ANT, LC04-PRODUTO, PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(REG_SPF0402B.SVA_COD_PRODUTO, WAREA_AUXILIAR.W_PRODUTO_ANT, WAREA_AUXILIAR.LC04.LC04_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

            /*" -516- MOVE 1 TO PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(1, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);

            /*" -517- IF W-CANAL-PROPOSTA EQUAL 8 */

            if (WAREA_AUXILIAR.FILLER_5.W_CANAL_PROPOSTA == 8)
            {

                /*" -519- IF W-PRODUTO-PROPOSTA GREATER 43 AND W-PRODUTO-PROPOSTA LESS 50 */

                if (WAREA_AUXILIAR.FILLER_5.W_PRODUTO_PROPOSTA > 43 && WAREA_AUXILIAR.FILLER_5.W_PRODUTO_PROPOSTA < 50)
                {

                    /*" -520- MOVE 31 TO W-PRODUTO-AUTO-FIXO */
                    _.Move(31, WAREA_AUXILIAR.FILLER_6.W_PRODUTO_AUTO_FIXO);

                    /*" -521- MOVE W-PRODUTO-PROPOSTA TO W-PRODUTO-AUTO-VAR */
                    _.Move(WAREA_AUXILIAR.FILLER_5.W_PRODUTO_PROPOSTA, WAREA_AUXILIAR.FILLER_6.W_PRODUTO_AUTO_VAR);

                    /*" -523- MOVE W-PRODUTO-AUTO TO PRDSIVPF-COD-PRODUTO OF DCLPRODUTOS-SIVPF */
                    _.Move(WAREA_AUXILIAR.W_PRODUTO_AUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO);

                    /*" -524- PERFORM R0205-00-SELECT-PRODUTO */

                    R0205_00_SELECT_PRODUTO_SECTION();

                    /*" -525- ELSE */
                }
                else
                {


                    /*" -526- PERFORM R0210-00-SELECT-PRODUTO */

                    R0210_00_SELECT_PRODUTO_SECTION();

                    /*" -527- ELSE */
                }

            }
            else
            {


                /*" -529- PERFORM R0210-00-SELECT-PRODUTO. */

                R0210_00_SELECT_PRODUTO_SECTION();
            }


            /*" -531- MOVE PRDSIVPF-NOME-PRODUTO TO LC04-NM-PRODUTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_NOME_PRODUTO, WAREA_AUXILIAR.LC04.LC04_NM_PRODUTO);

            /*" -533- PERFORM R0220-00-PROCESSA-PRODUTO UNTIL W-FIM-SORT EQUAL 'FIM' OR SVA-COD-PRODUTO NOT EQUAL W-PRODUTO-ANT. */

            while (!(WAREA_AUXILIAR.W_FIM_SORT == "FIM" || REG_SPF0402B.SVA_COD_PRODUTO != WAREA_AUXILIAR.W_PRODUTO_ANT))
            {

                R0220_00_PROCESSA_PRODUTO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-PROCESSA-PRODUTO-SECTION */
        private void R0220_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -544- MOVE 'R0220-00-PROCESSA-PRODUTO' TO PARAGRAFO. */
            _.Move("R0220-00-PROCESSA-PRODUTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -546- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -576- MOVE SVA-NSAS-SIVPF TO W-NSAS-ANT, ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF, LC05-NSAS-SIVPF. */
            _.Move(REG_SPF0402B.SVA_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS_ANT, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.LC05.LC05_NSAS_SIVPF);

            /*" -581- PERFORM R0240-00-PROCESSA-PROPOSTA UNTIL W-FIM-SORT EQUAL 'FIM' OR SVA-COD-PRODUTO NOT EQUAL W-PRODUTO-ANT OR SVA-NSAS-SIVPF NOT EQUAL W-NSAS-ANT. */

            while (!(WAREA_AUXILIAR.W_FIM_SORT == "FIM" || REG_SPF0402B.SVA_COD_PRODUTO != WAREA_AUXILIAR.W_PRODUTO_ANT || REG_SPF0402B.SVA_NSAS_SIVPF != WAREA_AUXILIAR.W_NSAS_ANT))
            {

                R0240_00_PROCESSA_PROPOSTA_SECTION();
            }

            /*" -581- MOVE 99 TO W-CONT-LINHAS. */
            _.Move(99, WAREA_AUXILIAR.W_CONT_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0205-00-SELECT-PRODUTO-SECTION */
        private void R0205_00_SELECT_PRODUTO_SECTION()
        {
            /*" -591- MOVE 'R0205-00-SELECT-PRODUTO  ' TO PARAGRAFO. */
            _.Move("R0205-00-SELECT-PRODUTO  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -594- MOVE 'SELECT SEGUROS.PRODUTO ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PRODUTO ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -603- PERFORM R0205_00_SELECT_PRODUTO_DB_SELECT_1 */

            R0205_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -606- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -611- DISPLAY '==> PF0402B - PROBLEMAS NO ACESSO A PRODUTO ' SVA-NUM-PROPOSTA '  ' PRDSIVPF-COD-EMPRESA-SIVPF '  ' PRDSIVPF-COD-PRODUTO-SIVPF '  ' SQLCODE */

                $"==> PF0402B - PROBLEMAS NO ACESSO A PRODUTO {REG_SPF0402B.SVA_NUM_PROPOSTA}  {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF}  {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}  {DB.SQLCODE}"
                .Display();

                /*" -612- PERFORM R9000-00-FECHAR-ARQUIVOS */

                R9000_00_FECHAR_ARQUIVOS_SECTION();

                /*" -612- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0205-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R0205_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -603- EXEC SQL SELECT A.NOME_PRODUTO INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-NOME-PRODUTO FROM SEGUROS.PRODUTOS_SIVPF A WHERE A.COD_EMPRESA_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF AND A.COD_PRODUTO = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO WITH UR END-EXEC. */

            var r0205_00_SELECT_PRODUTO_DB_SELECT_1_Query1 = new R0205_00_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_EMPRESA_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF.ToString(),
                PRDSIVPF_COD_PRODUTO = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO.ToString(),
            };

            var executed_1 = R0205_00_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(r0205_00_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_NOME_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_NOME_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0205_SAIDA*/

        [StopWatch]
        /*" R0210-00-SELECT-PRODUTO-SECTION */
        private void R0210_00_SELECT_PRODUTO_SECTION()
        {
            /*" -622- MOVE 'R0210-00-SELECT-PRODUTO  ' TO PARAGRAFO. */
            _.Move("R0210-00-SELECT-PRODUTO  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -624- MOVE 'SELECT SEGUROS.PRODUTO ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PRODUTO ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -638- PERFORM R0210_00_SELECT_PRODUTO_DB_SELECT_1 */

            R0210_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -642- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -647- DISPLAY '==> PF0402B - PROBLEMAS NO ACESSO A PRODUTO ' SVA-NUM-PROPOSTA '  ' PRDSIVPF-COD-EMPRESA-SIVPF '  ' PRDSIVPF-COD-PRODUTO-SIVPF '  ' SQLCODE */

                $"==> PF0402B - PROBLEMAS NO ACESSO A PRODUTO {REG_SPF0402B.SVA_NUM_PROPOSTA}  {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF}  {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}  {DB.SQLCODE}"
                .Display();

                /*" -648- PERFORM R9000-00-FECHAR-ARQUIVOS */

                R9000_00_FECHAR_ARQUIVOS_SECTION();

                /*" -648- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0210-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R0210_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -638- EXEC SQL SELECT A.NOME_PRODUTO INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-NOME-PRODUTO FROM SEGUROS.PRODUTOS_SIVPF A WHERE A.COD_EMPRESA_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF AND A.COD_PRODUTO_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF AND A.COD_PRODUTO = (SELECT MIN(B.COD_PRODUTO) FROM SEGUROS.PRODUTOS_SIVPF B WHERE B.COD_EMPRESA_SIVPF = A.COD_EMPRESA_SIVPF AND B.COD_PRODUTO_SIVPF = A.COD_PRODUTO_SIVPF) WITH UR END-EXEC. */

            var r0210_00_SELECT_PRODUTO_DB_SELECT_1_Query1 = new R0210_00_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_EMPRESA_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF.ToString(),
                PRDSIVPF_COD_PRODUTO_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF.ToString(),
            };

            var executed_1 = R0210_00_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(r0210_00_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_NOME_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_NOME_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_SAIDA*/

        [StopWatch]
        /*" R0240-00-PROCESSA-PROPOSTA-SECTION */
        private void R0240_00_PROCESSA_PROPOSTA_SECTION()
        {
            /*" -660- PERFORM R0250-00-SELECT-PESSOA. */

            R0250_00_SELECT_PESSOA_SECTION();

            /*" -662- PERFORM R0255-00-LER-HISTORICO. */

            R0255_00_LER_HISTORICO_SECTION();

            /*" -663- MOVE 'R0240-00-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("R0240-00-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -665- MOVE 'WRITE  DFP0402B' TO COMANDO. */
            _.Move("WRITE  DFP0402B", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -667- MOVE SVA-NUM-PROPOSTA TO LC07-NUM-PROPOSTA. */
            _.Move(REG_SPF0402B.SVA_NUM_PROPOSTA, WAREA_AUXILIAR.LC07.LC07_NUM_PROPOSTA);

            /*" -668- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -670- MOVE '   ' TO LC07-SITUACAO LC07-DATA-SITUACAO */
                _.Move("   ", WAREA_AUXILIAR.LC07.LC07_SITUACAO, WAREA_AUXILIAR.LC07.LC07_DATA_SITUACAO);

                /*" -671- ELSE */
            }
            else
            {


                /*" -672- MOVE PROPFIDH-DATA-SITUACAO TO W-DT-TRABALHO */
                _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, WAREA_AUXILIAR.W_DT_TRABALHO);

                /*" -673- MOVE W-DIA-TRABALHO TO W-DIA-SITUACAO */
                _.Move(WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO, WAREA_AUXILIAR.FILLER_4.W_DIA_SITUACAO);

                /*" -674- MOVE W-MES-TRABALHO TO W-MES-SITUACAO */
                _.Move(WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO, WAREA_AUXILIAR.FILLER_4.W_MES_SITUACAO);

                /*" -676- MOVE W-ANO-TRABALHO TO W-ANO-SITUACAO */
                _.Move(WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO, WAREA_AUXILIAR.FILLER_4.W_ANO_SITUACAO);

                /*" -678- MOVE '/' TO BARRA1, BARRA2 */
                _.Move("/", WAREA_AUXILIAR.FILLER_4.BARRA1);
                _.Move("/", WAREA_AUXILIAR.FILLER_4.BARRA2);


                /*" -680- MOVE W-DT-SITUACAO TO LC07-DATA-SITUACAO */
                _.Move(WAREA_AUXILIAR.W_DT_SITUACAO, WAREA_AUXILIAR.LC07.LC07_DATA_SITUACAO);

                /*" -681- IF PROPFIDH-SIT-PROPOSTA EQUAL 'MAN' */

                if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "MAN")
                {

                    /*" -682- MOVE 'EMT' TO LC07-SITUACAO */
                    _.Move("EMT", WAREA_AUXILIAR.LC07.LC07_SITUACAO);

                    /*" -683- ELSE */
                }
                else
                {


                    /*" -686- MOVE PROPFIDH-SIT-PROPOSTA TO LC07-SITUACAO. */
                    _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA, WAREA_AUXILIAR.LC07.LC07_SITUACAO);
                }

            }


            /*" -688- MOVE PESSOA-NOME-PESSOA OF DCLPESSOA TO LC07-NOME-CLIENTE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA, WAREA_AUXILIAR.LC07.LC07_NOME_CLIENTE);

            /*" -689- IF W-CONT-LINHAS GREATER 60 */

            if (WAREA_AUXILIAR.W_CONT_LINHAS > 60)
            {

                /*" -690- PERFORM R0260-00-GRAVA-CABECALHO */

                R0260_00_GRAVA_CABECALHO_SECTION();

                /*" -692- PERFORM R0270-00-GERAR-CABECALHO2. */

                R0270_00_GERAR_CABECALHO2_SECTION();
            }


            /*" -694- WRITE REG-RPF0402B FROM LC07 AFTER 1. */
            _.Move(WAREA_AUXILIAR.LC07.GetMoveValues(), REG_RPF0402B);

            RPF0402B.Write(REG_RPF0402B.GetMoveValues().ToString());

            /*" -696- ADD 1 TO W-CONT-LINHAS. */
            WAREA_AUXILIAR.W_CONT_LINHAS.Value = WAREA_AUXILIAR.W_CONT_LINHAS + 1;

            /*" -696- PERFORM R1910-00-LE-SORT. */

            R1910_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-SELECT-PESSOA-SECTION */
        private void R0250_00_SELECT_PESSOA_SECTION()
        {
            /*" -706- MOVE 'R0250-00-SELECT-PESSOA' TO PARAGRAFO. */
            _.Move("R0250-00-SELECT-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -708- MOVE 'SELECT SEGUROS.AGENCIACEF' TO COMANDO. */
            _.Move("SELECT SEGUROS.AGENCIACEF", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -710- MOVE SVA-COD-PESSOA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
            _.Move(REG_SPF0402B.SVA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

            /*" -716- PERFORM R0250_00_SELECT_PESSOA_DB_SELECT_1 */

            R0250_00_SELECT_PESSOA_DB_SELECT_1();

            /*" -719- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -722- DISPLAY '==> PF0402B - PROBLEMAS NO ACESSO PESSOA  ' SQLCODE '  ' PESSOA-COD-PESSOA OF DCLPESSOA */

                $"==> PF0402B - PROBLEMAS NO ACESSO PESSOA  {DB.SQLCODE}  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}"
                .Display();

                /*" -723- PERFORM R9000-00-FECHAR-ARQUIVOS */

                R9000_00_FECHAR_ARQUIVOS_SECTION();

                /*" -723- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0250-00-SELECT-PESSOA-DB-SELECT-1 */
        public void R0250_00_SELECT_PESSOA_DB_SELECT_1()
        {
            /*" -716- EXEC SQL SELECT NOME_PESSOA INTO :DCLPESSOA.PESSOA-NOME-PESSOA FROM SEGUROS.PESSOA WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA WITH UR END-EXEC. */

            var r0250_00_SELECT_PESSOA_DB_SELECT_1_Query1 = new R0250_00_SELECT_PESSOA_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R0250_00_SELECT_PESSOA_DB_SELECT_1_Query1.Execute(r0250_00_SELECT_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0255-00-LER-HISTORICO-SECTION */
        private void R0255_00_LER_HISTORICO_SECTION()
        {
            /*" -733- MOVE 'R0255-00-LER-HISTORICO' TO PARAGRAFO. */
            _.Move("R0255-00-LER-HISTORICO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -735- MOVE 'DECLER HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("DECLER HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -738- MOVE SVA-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(REG_SPF0402B.SVA_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -748- PERFORM R0255_00_LER_HISTORICO_DB_DECLARE_1 */

            R0255_00_LER_HISTORICO_DB_DECLARE_1();

            /*" -752- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -755- DISPLAY 'PF0402B - PROBLEMAS DECLAR HIST-PROP-FIDELIZ  ' SQLCODE '  ' PROPFIDH-NUM-IDENTIFICACAO */

                $"PF0402B - PROBLEMAS DECLAR HIST-PROP-FIDELIZ  {DB.SQLCODE}  {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}"
                .Display();

                /*" -756- PERFORM R9000-00-FECHAR-ARQUIVOS */

                R9000_00_FECHAR_ARQUIVOS_SECTION();

                /*" -758- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -760- MOVE 'OPEN  CURSOR HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("OPEN  CURSOR HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -760- PERFORM R0255_00_LER_HISTORICO_DB_OPEN_1 */

            R0255_00_LER_HISTORICO_DB_OPEN_1();

            /*" -763- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -766- DISPLAY 'PF0402B - PROBLEMAS OPEN   HIST-PROP-FIDELIZ  ' SQLCODE '  ' PROPFIDH-NUM-IDENTIFICACAO */

                $"PF0402B - PROBLEMAS OPEN   HIST-PROP-FIDELIZ  {DB.SQLCODE}  {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}"
                .Display();

                /*" -767- PERFORM R9000-00-FECHAR-ARQUIVOS */

                R9000_00_FECHAR_ARQUIVOS_SECTION();

                /*" -769- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -771- MOVE 'FETCH CURSOR HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("FETCH CURSOR HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -776- PERFORM R0255_00_LER_HISTORICO_DB_FETCH_1 */

            R0255_00_LER_HISTORICO_DB_FETCH_1();

            /*" -779- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -782- DISPLAY 'PF0402B - PROBLEMAS FETCH  HIST-PROP-FIDELIZ  ' SQLCODE '  ' PROPFIDH-NUM-IDENTIFICACAO */

                $"PF0402B - PROBLEMAS FETCH  HIST-PROP-FIDELIZ  {DB.SQLCODE}  {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}"
                .Display();

                /*" -783- PERFORM R9000-00-FECHAR-ARQUIVOS */

                R9000_00_FECHAR_ARQUIVOS_SECTION();

                /*" -785- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -787- MOVE 'CLOSE CURSOR HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("CLOSE CURSOR HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -787- PERFORM R0255_00_LER_HISTORICO_DB_CLOSE_1 */

            R0255_00_LER_HISTORICO_DB_CLOSE_1();

            /*" -790- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -793- DISPLAY 'PF0402B - PROBLEMAS CLODE  HIST-PROP-FIDELIZ  ' SQLCODE '  ' PROPFIDH-NUM-IDENTIFICACAO */

                $"PF0402B - PROBLEMAS CLODE  HIST-PROP-FIDELIZ  {DB.SQLCODE}  {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}"
                .Display();

                /*" -794- PERFORM R9000-00-FECHAR-ARQUIVOS */

                R9000_00_FECHAR_ARQUIVOS_SECTION();

                /*" -794- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0255-00-LER-HISTORICO-DB-DECLARE-1 */
        public void R0255_00_LER_HISTORICO_DB_DECLARE_1()
        {
            /*" -748- EXEC SQL DECLARE HIST-PROP-FIDELIZ CURSOR FOR SELECT DATA_SITUACAO, SIT_PROPOSTA FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPFIDH-NUM-IDENTIFICACAO ORDER BY DATA_SITUACAO DESC WITH UR END-EXEC. */
            HIST_PROP_FIDELIZ = new PF0402B_HIST_PROP_FIDELIZ(true);
            string GetQuery_HIST_PROP_FIDELIZ()
            {
                var query = @$"SELECT DATA_SITUACAO
							, 
							SIT_PROPOSTA 
							FROM SEGUROS.HIST_PROP_FIDELIZ 
							WHERE NUM_IDENTIFICACAO = 
							'{PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}' 
							ORDER BY DATA_SITUACAO DESC";

                return query;
            }
            HIST_PROP_FIDELIZ.GetQueryEvent += GetQuery_HIST_PROP_FIDELIZ;

        }

        [StopWatch]
        /*" R0255-00-LER-HISTORICO-DB-OPEN-1 */
        public void R0255_00_LER_HISTORICO_DB_OPEN_1()
        {
            /*" -760- EXEC SQL OPEN HIST-PROP-FIDELIZ END-EXEC. */

            HIST_PROP_FIDELIZ.Open();

        }

        [StopWatch]
        /*" R0255-00-LER-HISTORICO-DB-FETCH-1 */
        public void R0255_00_LER_HISTORICO_DB_FETCH_1()
        {
            /*" -776- EXEC SQL FETCH HIST-PROP-FIDELIZ INTO :PROPFIDH-DATA-SITUACAO , :PROPFIDH-SIT-PROPOSTA END-EXEC. */

            if (HIST_PROP_FIDELIZ.Fetch())
            {
                _.Move(HIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);
                _.Move(HIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);
            }

        }

        [StopWatch]
        /*" R0255-00-LER-HISTORICO-DB-CLOSE-1 */
        public void R0255_00_LER_HISTORICO_DB_CLOSE_1()
        {
            /*" -787- EXEC SQL CLOSE HIST-PROP-FIDELIZ END-EXEC */

            HIST_PROP_FIDELIZ.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0255_SAIDA*/

        [StopWatch]
        /*" R0260-00-GRAVA-CABECALHO-SECTION */
        private void R0260_00_GRAVA_CABECALHO_SECTION()
        {
            /*" -805- ADD 1 TO LC01-PAGINA. */
            WAREA_AUXILIAR.LC01.LC01_PAGINA.Value = WAREA_AUXILIAR.LC01.LC01_PAGINA + 1;

            /*" -806- WRITE REG-RPF0402B FROM LC01 AFTER PAGE. */
            _.Move(WAREA_AUXILIAR.LC01.GetMoveValues(), REG_RPF0402B);

            RPF0402B.Write(REG_RPF0402B.GetMoveValues().ToString());

            /*" -807- WRITE REG-RPF0402B FROM LC02. */
            _.Move(WAREA_AUXILIAR.LC02.GetMoveValues(), REG_RPF0402B);

            RPF0402B.Write(REG_RPF0402B.GetMoveValues().ToString());

            /*" -808- WRITE REG-RPF0402B FROM LC03. */
            _.Move(WAREA_AUXILIAR.LC03.GetMoveValues(), REG_RPF0402B);

            RPF0402B.Write(REG_RPF0402B.GetMoveValues().ToString());

            /*" -809- WRITE REG-RPF0402B FROM LC04. */
            _.Move(WAREA_AUXILIAR.LC04.GetMoveValues(), REG_RPF0402B);

            RPF0402B.Write(REG_RPF0402B.GetMoveValues().ToString());

            /*" -811- WRITE REG-RPF0402B FROM LC08. */
            _.Move(WAREA_AUXILIAR.LC08.GetMoveValues(), REG_RPF0402B);

            RPF0402B.Write(REG_RPF0402B.GetMoveValues().ToString());

            /*" -811- MOVE 5 TO W-CONT-LINHAS. */
            _.Move(5, WAREA_AUXILIAR.W_CONT_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_SAIDA*/

        [StopWatch]
        /*" R0230-00-LER-DATA-GERACAO-SECTION */
        private void R0230_00_LER_DATA_GERACAO_SECTION()
        {
            /*" -821- MOVE 'R0230-00-LER-DATA-GERACAO' TO PARAGRAFO. */
            _.Move("R0230-00-LER-DATA-GERACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -823- MOVE 'SELECT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -832- PERFORM R0230_00_LER_DATA_GERACAO_DB_SELECT_1 */

            R0230_00_LER_DATA_GERACAO_DB_SELECT_1();

            /*" -835- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -836- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -837- DISPLAY 'PF0402B - NSAS NAO CADASTRADO NO ARQUIVOS-SIVPF' */
                    _.Display($"PF0402B - NSAS NAO CADASTRADO NO ARQUIVOS-SIVPF");

                    /*" -839- DISPLAY '        - NSAS SIVPF.......................... ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                    _.Display($"        - NSAS SIVPF.......................... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                    /*" -840- ELSE */
                }
                else
                {


                    /*" -842- DISPLAY '==> PF0402B - PROBLEMAS ACESSO ARQUIVOS-SIVPF  ' SQLCODE */
                    _.Display($"==> PF0402B - PROBLEMAS ACESSO ARQUIVOS-SIVPF  {DB.SQLCODE}");

                    /*" -844- DISPLAY '        - NSAS SIVPF.......................... ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                    _.Display($"        - NSAS SIVPF.......................... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                    /*" -845- PERFORM R9000-00-FECHAR-ARQUIVOS */

                    R9000_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -845- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0230-00-LER-DATA-GERACAO-DB-SELECT-1 */
        public void R0230_00_LER_DATA_GERACAO_DB_SELECT_1()
        {
            /*" -832- EXEC SQL SELECT DATA_GERACAO INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = 'PRPSASSE' AND SISTEMA_ORIGEM = 4 AND NSAS_SIVPF = :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF WITH UR END-EXEC. */

            var r0230_00_LER_DATA_GERACAO_DB_SELECT_1_Query1 = new R0230_00_LER_DATA_GERACAO_DB_SELECT_1_Query1()
            {
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
            };

            var executed_1 = R0230_00_LER_DATA_GERACAO_DB_SELECT_1_Query1.Execute(r0230_00_LER_DATA_GERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_DATA_GERACAO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_SAIDA*/

        [StopWatch]
        /*" R0270-00-GERAR-CABECALHO2-SECTION */
        private void R0270_00_GERAR_CABECALHO2_SECTION()
        {
            /*" -855- MOVE 'R0270-00-GERAR-CABECALHO2' TO PARAGRAFO. */
            _.Move("R0270-00-GERAR-CABECALHO2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -859- MOVE 'WRITE REG-DPF0402B' TO COMANDO. */
            _.Move("WRITE REG-DPF0402B", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -861- WRITE REG-RPF0402B FROM LC06 AFTER 2. */
            _.Move(WAREA_AUXILIAR.LC06.GetMoveValues(), REG_RPF0402B);

            RPF0402B.Write(REG_RPF0402B.GetMoveValues().ToString());

            /*" -861- ADD 2 TO W-CONT-LINHAS. */
            WAREA_AUXILIAR.W_CONT_LINHAS.Value = WAREA_AUXILIAR.W_CONT_LINHAS + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_SAIDA*/

        [StopWatch]
        /*" R9000-00-FECHAR-ARQUIVOS-SECTION */
        private void R9000_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -870- CLOSE RPF0402B. */
            RPF0402B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_SAIDA*/

        [StopWatch]
        /*" R9997-00-SELECT-V0SISTEMA-SECTION */
        private void R9997_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -880- MOVE 'R9997-00-SELECT-V0SISTEMA' TO PARAGRAFO. */
            _.Move("R9997-00-SELECT-V0SISTEMA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -882- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -884- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -890- PERFORM R9997_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R9997_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -893- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -894- DISPLAY '==> PF0402B - PROBLEMAS NO ACESSO A SISTEMAS' */
                _.Display($"==> PF0402B - PROBLEMAS NO ACESSO A SISTEMAS");

                /*" -896- GO TO R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;
            }


            /*" -898- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -900- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -902- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -905- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -907- MOVE '/' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R9997-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R9997_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -890- EXEC SQL SELECT CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r9997_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R9997_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R9997_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r9997_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9997_SAIDA*/

        [StopWatch]
        /*" R9998-00-FORMATA-CABEC-SECTION */
        private void R9998_00_FORMATA_CABEC_SECTION()
        {
            /*" -918- MOVE ZEROS TO LC01-PAGINA. */
            _.Move(0, WAREA_AUXILIAR.LC01.LC01_PAGINA);

            /*" -920- MOVE W-DTMOVABE-I TO LC02-DATA. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE_I, WAREA_AUXILIAR.LC02.LC02_DATA);

            /*" -922- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -923- MOVE WS-TIME-N TO WS-TIME-EDIT */
            _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

            /*" -923- MOVE WS-TIME-EDIT TO LC03-HORA. */
            _.Move(WS_TIME_EDIT, WAREA_AUXILIAR.LC03.LC03_HORA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9998_SAIDA*/

        [StopWatch]
        /*" R0910-00-LER-MOVTO-SECTION */
        private void R0910_00_LER_MOVTO_SECTION()
        {
            /*" -932- MOVE 'R0910-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0910-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -934- MOVE 'READ DPF0402B' TO COMANDO. */
            _.Move("READ DPF0402B", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -936- READ DPF0402B AT END */
            try
            {
                DPF0402B.Read(() =>
                {

                    /*" -938- MOVE HIGH-VALUES TO REG-DPF0402B */

                    REG_DPF0402B.IsHighValues = true;

                    /*" -939- CLOSE DPF0402B */
                    DPF0402B.Close();

                    /*" -940- MOVE 'FIM' TO W-FIM-PROPOSTA */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_PROPOSTA);

                    /*" -942- GO TO R0910-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_SAIDA*/ //GOTO
                    return;
                });

                _.Move(DPF0402B.Value, REG_DPF0402B);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -944- ADD 1 TO WS-CONT-LIDOS. */
            WS_CONT_LIDOS.Value = WS_CONT_LIDOS + 1;

            /*" -945- IF W-FIM-PROPOSTA NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_PROPOSTA != "FIM")
            {

                /*" -946- IF REG-TIPO-REG NOT EQUAL 1 */

                if (REG_DPF0402B.REG_TIPO_REG != 1)
                {

                    /*" -946- GO TO R0910-00-LER-MOVTO. */
                    new Task(() => R0910_00_LER_MOVTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -964- DISPLAY ' ' */
            _.Display($" ");

            /*" -965- IF W-FIM-PROPOSTA = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_PROPOSTA == "FIM")
            {

                /*" -966- DISPLAY '*********************************************' */
                _.Display($"*********************************************");

                /*" -967- DISPLAY '*                                           *' */
                _.Display($"*                                           *");

                /*" -968- DISPLAY '*            PF0402B - FIM NORMAL           *' */
                _.Display($"*            PF0402B - FIM NORMAL           *");

                /*" -969- DISPLAY '*                                           *' */
                _.Display($"*                                           *");

                /*" -971- DISPLAY '*          LIDOS ARQ MOV  : ' WS-CONT-LIDOS '         *' */

                $"*          LIDOS ARQ MOV  : {WS_CONT_LIDOS}         *"
                .Display();

                /*" -973- DISPLAY '*          NAO CADASTRADAS: ' WS-CONT-NAOCAD '         *' */

                $"*          NAO CADASTRADAS: {WS_CONT_NAOCAD}         *"
                .Display();

                /*" -975- DISPLAY '*          LIDOS ARQ SORT : ' WS-CONT-LIDOS-SORT '         *' */

                $"*          LIDOS ARQ SORT : {WS_CONT_LIDOS_SORT}         *"
                .Display();

                /*" -976- DISPLAY '*                                           *' */
                _.Display($"*                                           *");

                /*" -977- DISPLAY '*********************************************' */
                _.Display($"*********************************************");

                /*" -978- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -979- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_1.COMANDO);

                /*" -979- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -981- ELSE */
            }
            else
            {


                /*" -982- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -983- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

                /*" -984- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

                /*" -986- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -987- DISPLAY '*********************************************' */
                _.Display($"*********************************************");

                /*" -988- DISPLAY '*                                           *' */
                _.Display($"*                                           *");

                /*" -989- DISPLAY '*          PF0402B - TERMINO ANORMAL        *' */
                _.Display($"*          PF0402B - TERMINO ANORMAL        *");

                /*" -990- DISPLAY '*                                           *' */
                _.Display($"*                                           *");

                /*" -991- DISPLAY '*       PF0402B - ROLLBACK EM ANDAMENTO     *' */
                _.Display($"*       PF0402B - ROLLBACK EM ANDAMENTO     *");

                /*" -992- DISPLAY '*                                           *' */
                _.Display($"*                                           *");

                /*" -993- DISPLAY '*********************************************' */
                _.Display($"*********************************************");

                /*" -994- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_1.COMANDO);

                /*" -994- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -997- MOVE 99 TO RETURN-CODE. */
                _.Move(99, RETURN_CODE);
            }


            /*" -997- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}