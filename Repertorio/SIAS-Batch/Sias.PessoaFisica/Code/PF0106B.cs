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
using Sias.PessoaFisica.DB2.PF0106B;

namespace Code
{
    public class PF0106B
    {
        public bool IsCall { get; set; }

        public PF0106B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------*                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA TABELAS COM DADOS DE PAGAMENTO*      */
        /*"      *                             AVULSO E CONTRIBUICAO ADICIONAL    *      */
        /*"      *   ANALISE/PROGRAMACAO.....  LUIZ CARLOS.                       *      */
        /*"      *   PROGRAMA ...............  PF0106B                            *      */
        /*"      *   ANALISE E AJUSTES.......  REGINALDO DA SILVA                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     *--------------------*                                                  */
        #endregion


        #region VARIABLES

        public FileBasis _MOV_SIGAT { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis MOV_SIGAT
        {
            get
            {
                _.Move(REG_SIGAT, _MOV_SIGAT); VarBasis.RedefinePassValue(REG_SIGAT, _MOV_SIGAT, REG_SIGAT); return _MOV_SIGAT;
            }
        }
        /*"01   REG-SIGAT.*/
        public PF0106B_REG_SIGAT REG_SIGAT { get; set; } = new PF0106B_REG_SIGAT();
        public class PF0106B_REG_SIGAT : VarBasis
        {
            /*"     10  REG-TIPO-SIGAT                  PIC X(001).*/
            public StringBasis REG_TIPO_SIGAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  REG-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis REG_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  FILLER REDEFINES REG-NUM-PROPOSTA.*/
            private _REDEF_PF0106B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0106B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0106B_FILLER_0(); _.Move(REG_NUM_PROPOSTA, _filler_0); VarBasis.RedefinePassValue(REG_NUM_PROPOSTA, _filler_0, REG_NUM_PROPOSTA); _filler_0.ValueChanged += () => { _.Move(_filler_0, REG_NUM_PROPOSTA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, REG_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0106B_FILLER_0 : VarBasis
            {
                /*"         15  REG-NOME-ARQUIVO            PIC X(008).*/
                public StringBasis REG_NOME_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"         15  FILLER                      PIC X(006).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"     10  FILLER                          PIC X(004).*/

                public _REDEF_PF0106B_FILLER_0()
                {
                    REG_NOME_ARQUIVO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"     10  REG-NUM-SICOB                   PIC 9(012).*/
            public IntBasis REG_NUM_SICOB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"     10  FILLER REDEFINES REG-NUM-SICOB.*/
            private _REDEF_PF0106B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0106B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0106B_FILLER_3(); _.Move(REG_NUM_SICOB, _filler_3); VarBasis.RedefinePassValue(REG_NUM_SICOB, _filler_3, REG_NUM_SICOB); _filler_3.ValueChanged += () => { _.Move(_filler_3, REG_NUM_SICOB); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, REG_NUM_SICOB); }
            }  //Redefines
            public class _REDEF_PF0106B_FILLER_3 : VarBasis
            {
                /*"         15  FILLER                      PIC 9(005).*/
                public IntBasis FILLER_4 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"         15  REG-COD-PRODUTO             PIC 9(002).*/
                public IntBasis REG_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"         15  FILLER                      PIC 9(005).*/
                public IntBasis FILLER_5 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"     10  FILLER                          PIC X(243).*/

                public _REDEF_PF0106B_FILLER_3()
                {
                    FILLER_4.ValueChanged += OnValueChanged;
                    REG_COD_PRODUTO.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "243", "X(243)."), @"");
            /*"     10  REG-ORIGEM                      PIC 9(002).*/
            public IntBasis REG_ORIGEM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10  FILLER                          PIC X(022).*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WAREA-AUXILIAR.*/
        public PF0106B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0106B_WAREA_AUXILIAR();
        public class PF0106B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-MOVTO-SIGAT             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_SIGAT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-LIDO-MOVTO-SIGAT            PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_LIDO_MOVTO_SIGAT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-PROCESSADO-SIGAT            PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_PROCESSADO_SIGAT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-AC-CONTROLE                 PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0106B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_PF0106B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_PF0106B_FILLER_8(); _.Move(W_DATA_TRABALHO, _filler_8); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_8, W_DATA_TRABALHO); _filler_8.ValueChanged += () => { _.Move(_filler_8, W_DATA_TRABALHO); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0106B_FILLER_8 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0106B_FILLER_8()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0106B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0106B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0106B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0106B_W_DTMOVABE1 : VarBasis
            {
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-DTMOVABE-I                  PIC X(010).*/

                public _REDEF_PF0106B_W_DTMOVABE1()
                {
                    W_ANO_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_MOVABE.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
            private _REDEF_PF0106B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0106B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0106B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0106B_W_DTMOVABE_I1 : VarBasis
            {
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-SQL                    PIC X(010).*/

                public _REDEF_PF0106B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_PF0106B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0106B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0106B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0106B_W_DATA_SQL1 : VarBasis
            {
                /*"        07  W-ANO-SQL                 PIC 9(004).*/
                public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-SQL                 PIC 9(002).*/
                public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-SQL                 PIC 9(002).*/
                public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-DATA-SITUACAO               PIC X(010).*/

                public _REDEF_PF0106B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SIT-RD REDEFINES W-DATA-SITUACAO.*/
            private _REDEF_PF0106B_W_DATA_SIT_RD _w_data_sit_rd { get; set; }
            public _REDEF_PF0106B_W_DATA_SIT_RD W_DATA_SIT_RD
            {
                get { _w_data_sit_rd = new _REDEF_PF0106B_W_DATA_SIT_RD(); _.Move(W_DATA_SITUACAO, _w_data_sit_rd); VarBasis.RedefinePassValue(W_DATA_SITUACAO, _w_data_sit_rd, W_DATA_SITUACAO); _w_data_sit_rd.ValueChanged += () => { _.Move(_w_data_sit_rd, W_DATA_SITUACAO); }; return _w_data_sit_rd; }
                set { VarBasis.RedefinePassValue(value, _w_data_sit_rd, W_DATA_SITUACAO); }
            }  //Redefines
            public class _REDEF_PF0106B_W_DATA_SIT_RD : VarBasis
            {
                /*"        07  W-DIA-SITUACAO            PIC 9(002).*/
                public IntBasis W_DIA_SITUACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-SITUACAO            PIC 9(002).*/
                public IntBasis W_MES_SITUACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-ANO-SITUACAO            PIC 9(004).*/
                public IntBasis W_ANO_SITUACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01  WS-TIME.*/

                public _REDEF_PF0106B_W_DATA_SIT_RD()
                {
                    W_DIA_SITUACAO.ValueChanged += OnValueChanged;
                    W_BARRA1_2.ValueChanged += OnValueChanged;
                    W_MES_SITUACAO.ValueChanged += OnValueChanged;
                    W_BARRA2_2.ValueChanged += OnValueChanged;
                    W_ANO_SITUACAO.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0106B_WS_TIME WS_TIME { get; set; } = new PF0106B_WS_TIME();
        public class PF0106B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01  WABEND.*/
        public PF0106B_WABEND WABEND { get; set; } = new PF0106B_WABEND();
        public class PF0106B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'PF0106B  '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0106B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      05      LOCALIZA-ABEND-1.*/
            public PF0106B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0106B_LOCALIZA_ABEND_1();
            public class PF0106B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        10    FILLER                   PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        10    PARAGRAFO                PIC  X(040)   VALUE SPACES      05      LOCALIZA-ABEND-2.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"        10    FILLER                   PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        10    COMANDO                  PIC  X(060)   VALUE SPACES01    WREA88.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"SPACES01");
                /*"      05  W-PAGADOR-SIVPF            PIC 9(001).*/
            }

            public SelectorBasis W_PAGADOR_SIVPF { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PAGADOR-ENCONTRADO                    VALUE 1. */
							new SelectorItemBasis("PAGADOR_ENCONTRADO", "1"),
							/*" 88 PAGADOR-NAO-ENCONTRADO                VALUE 2. */
							new SelectorItemBasis("PAGADOR_NAO_ENCONTRADO", "2")
                }
            };

        }


        public Copies.LBFPF000 LBFPF000 { get; set; } = new Copies.LBFPF000();
        public Copies.LXFPF990 LXFPF990 { get; set; } = new Copies.LXFPF990();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PF038 PF038 { get; set; } = new Dclgens.PF038();
        public Dclgens.PF039 PF039 { get; set; } = new Dclgens.PF039();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV_SIGAT_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV_SIGAT.SetFile(MOV_SIGAT_FILE_NAME_P);

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
            /*" -200- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -201- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -202- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -205- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -206- DISPLAY '*               PROGRAMA PF0106B               *' . */
            _.Display($"*               PROGRAMA PF0106B               *");

            /*" -207- DISPLAY '* GERA TAB COM DADOS PAGTO AVULSO E CONTR SIND *' . */
            _.Display($"* GERA TAB COM DADOS PAGTO AVULSO E CONTR SIND *");

            /*" -208- DISPLAY '*           VERSAO:  01 - 17/07/2015           *' . */
            _.Display($"*           VERSAO:  01 - 17/07/2015           *");

            /*" -209- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -218- DISPLAY '*  PF0106B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0106B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -220- PERFORM R0000-00-INICIALIZAR. */

            R0000_00_INICIALIZAR_SECTION();

            /*" -222- PERFORM R0050-00-LER-MOV-SIGAT. */

            R0050_00_LER_MOV_SIGAT_SECTION();

            /*" -225- PERFORM R0200-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-SIGAT EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT == "FIM"))
            {

                R0200_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -227- PERFORM R2000-00-IMPRIMIR-TOTAIS. */

            R2000_00_IMPRIMIR_TOTAIS_SECTION();

            /*" -229- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -229- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0000-00-INICIALIZAR-SECTION */
        private void R0000_00_INICIALIZAR_SECTION()
        {
            /*" -237- MOVE 'R0000-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0000-00-INICIALIZAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -239- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -241- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -241- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -251- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -253- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -255- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -261- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -266- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -268- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -270- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -273- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -275- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -261- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 = new R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1.Execute(r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_SAIDA*/

        [StopWatch]
        /*" R0010-00-ABRIR-ARQUIVOS-SECTION */
        private void R0010_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -285- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -287- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -287- OPEN INPUT MOV-SIGAT. */
            MOV_SIGAT.Open(REG_SIGAT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0050-00-LER-MOV-SIGAT-SECTION */
        private void R0050_00_LER_MOV_SIGAT_SECTION()
        {
            /*" -297- MOVE 'R0050-00-LER-MOV-SIGAT' TO PARAGRAFO. */
            _.Move("R0050-00-LER-MOV-SIGAT", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -299- MOVE 'READ' TO COMANDO. */
            _.Move("READ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -300- READ MOV-SIGAT AT END */
            try
            {
                MOV_SIGAT.Read(() =>
                {

                    /*" -303- MOVE 'FIM' TO W-FIM-MOVTO-SIGAT. */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT);
                });

                _.Move(MOV_SIGAT.Value, REG_SIGAT);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -305- IF W-FIM-MOVTO-SIGAT NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT != "FIM")
            {

                /*" -308- ADD 1 TO W-LIDO-MOVTO-SIGAT, W-AC-CONTROLE */
                WAREA_AUXILIAR.W_LIDO_MOVTO_SIGAT.Value = WAREA_AUXILIAR.W_LIDO_MOVTO_SIGAT + 1;
                WAREA_AUXILIAR.W_AC_CONTROLE.Value = WAREA_AUXILIAR.W_AC_CONTROLE + 1;

                /*" -309- IF W-AC-CONTROLE GREATER 4999 */

                if (WAREA_AUXILIAR.W_AC_CONTROLE > 4999)
                {

                    /*" -310- ACCEPT WS-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WS_TIME);

                    /*" -311- MOVE WS-TIME-N TO WS-TIME-EDIT */
                    _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

                    /*" -312- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -315- DISPLAY 'PF0106B - TOTAL LIDO ' W-LIDO-MOVTO-SIGAT '  HORAS  ' WS-TIME-EDIT */

                    $"PF0106B - TOTAL LIDO {WAREA_AUXILIAR.W_LIDO_MOVTO_SIGAT}  HORAS  {WS_TIME_EDIT}"
                    .Display();

                    /*" -316- MOVE ZEROS TO W-AC-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_AC_CONTROLE);

                    /*" -318- END-IF */
                }


                /*" -319- IF REG-TIPO-SIGAT EQUAL 'H' */

                if (REG_SIGAT.REG_TIPO_SIGAT == "H")
                {

                    /*" -320- MOVE REG-SIGAT TO REG-HEADER */
                    _.Move(MOV_SIGAT?.Value, LXFPF990.REG_HEADER);

                    /*" -324- DISPLAY 'PF0106B-ARQUIVO LIDO => ' RH-NOME ' => ' RH-DATA-GERACAO ' => ' RH-NSAS */

                    $"PF0106B-ARQUIVO LIDO => {LXFPF990.REG_HEADER.RH_NOME} => {LXFPF990.REG_HEADER.RH_DATA_GERACAO} => {LXFPF990.REG_HEADER.RH_NSAS}"
                    .Display();

                    /*" -326- END-IF */
                }


                /*" -327- IF RH-TIPO-ARQUIVO OF REG-HEADER NOT EQUAL 1 */

                if (LXFPF990.REG_HEADER.RH_TIPO_ARQUIVO != 1)
                {

                    /*" -328- GO TO R0050-00-LER-MOV-SIGAT */
                    new Task(() => R0050_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -330- END-IF */
                }


                /*" -331- IF REG-TIPO-SIGAT NOT EQUAL '0' */

                if (REG_SIGAT.REG_TIPO_SIGAT != "0")
                {

                    /*" -332- GO TO R0050-00-LER-MOV-SIGAT */
                    new Task(() => R0050_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -334- END-IF */
                }


                /*" -335- IF REG-COD-PRODUTO NOT EQUAL 99 */

                if (REG_SIGAT.FILLER_3.REG_COD_PRODUTO != 99)
                {

                    /*" -337- DISPLAY 'PF0106B-TITULO DESPREZADO, PRODUTO <> 99 ' REG-NUM-SICOB */
                    _.Display($"PF0106B-TITULO DESPREZADO, PRODUTO <> 99 {REG_SIGAT.REG_NUM_SICOB}");

                    /*" -338- GO TO R0050-00-LER-MOV-SIGAT */
                    new Task(() => R0050_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -340- END-IF */
                }


                /*" -341- IF REG-NUM-SICOB EQUAL 10002990001270 */

                if (REG_SIGAT.REG_NUM_SICOB == 10002990001270)
                {

                    /*" -343- DISPLAY 'PF0106B-TITULO DESPREZADO, INTEGRIDADE  ' REG-NUM-SICOB */
                    _.Display($"PF0106B-TITULO DESPREZADO, INTEGRIDADE  {REG_SIGAT.REG_NUM_SICOB}");

                    /*" -344- GO TO R0050-00-LER-MOV-SIGAT */
                    new Task(() => R0050_00_LER_MOV_SIGAT_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -346- END-IF */
                }


                /*" -346- ADD 1 TO W-PROCESSADO-SIGAT. */
                WAREA_AUXILIAR.W_PROCESSADO_SIGAT.Value = WAREA_AUXILIAR.W_PROCESSADO_SIGAT + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0200-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0200_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -356- MOVE 'R0200-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0200-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -358- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -359- PERFORM R0250-00-TRATA-PGTO UNTIL W-FIM-MOVTO-SIGAT EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT == "FIM"))
            {

                R0250_00_TRATA_PGTO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0250-00-TRATA-PGTO-SECTION */
        private void R0250_00_TRATA_PGTO_SECTION()
        {
            /*" -369- MOVE 'R0250-00-TRATA-PGTO' TO PARAGRAFO. */
            _.Move("R0250-00-TRATA-PGTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -371- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -373- MOVE REG-SIGAT TO REG-PAG-AVULSO. */
            _.Move(MOV_SIGAT?.Value, LBFPF000.REG_PAG_AVULSO);

            /*" -375- PERFORM R0260-LER-DADOS-PAGADOR */

            R0260_LER_DADOS_PAGADOR_SECTION();

            /*" -376- IF PAGADOR-ENCONTRADO */

            if (WABEND.W_PAGADOR_SIVPF["PAGADOR_ENCONTRADO"])
            {

                /*" -377- PERFORM R0270-ATUALIZA-DADOS-PAGADOR */

                R0270_ATUALIZA_DADOS_PAGADOR_SECTION();

                /*" -378- ELSE */
            }
            else
            {


                /*" -380- PERFORM R0280-INSERIR-DADOS-PAGADOR. */

                R0280_INSERIR_DADOS_PAGADOR_SECTION();
            }


            /*" -382- PERFORM R0290-GERAR-TAB-PAGAMENTO */

            R0290_GERAR_TAB_PAGAMENTO_SECTION();

            /*" -382- PERFORM R0050-00-LER-MOV-SIGAT. */

            R0050_00_LER_MOV_SIGAT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0260-LER-DADOS-PAGADOR-SECTION */
        private void R0260_LER_DADOS_PAGADOR_SECTION()
        {
            /*" -392- MOVE 'R0260-LER-DADOS-PAGADOR' TO PARAGRAFO. */
            _.Move("R0260-LER-DADOS-PAGADOR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -394- MOVE 'SELECT PF_PAGADOR_SIVPF' TO COMANDO. */
            _.Move("SELECT PF_PAGADOR_SIVPF", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -396- MOVE R0-CPFCGC TO PF039-NUM-CGC-CPF */
            _.Move(LBFPF000.REG_PAG_AVULSO.R0_CPFCGC, PF039.DCLPF_PAGADOR_SIVPF.PF039_NUM_CGC_CPF);

            /*" -408- PERFORM R0260_LER_DADOS_PAGADOR_DB_SELECT_1 */

            R0260_LER_DADOS_PAGADOR_DB_SELECT_1();

            /*" -411- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -412- MOVE 1 TO W-PAGADOR-SIVPF */
                _.Move(1, WABEND.W_PAGADOR_SIVPF);

                /*" -413- ELSE */
            }
            else
            {


                /*" -414- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -415- MOVE 2 TO W-PAGADOR-SIVPF */
                    _.Move(2, WABEND.W_PAGADOR_SIVPF);

                    /*" -416- ELSE */
                }
                else
                {


                    /*" -417- DISPLAY 'PF0106B - FIM ANORMAL' */
                    _.Display($"PF0106B - FIM ANORMAL");

                    /*" -418- DISPLAY '          ERRO SELECT TAB PF_PAGADOR_SIVPF' */
                    _.Display($"          ERRO SELECT TAB PF_PAGADOR_SIVPF");

                    /*" -420- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -422- DISPLAY '          NUMERO DO CPF.................  ' PF038-NUM-CGC-CPF */
                    _.Display($"          NUMERO DO CPF.................  {PF038.DCLPF_PGTO_SIVPF.PF038_NUM_CGC_CPF}");

                    /*" -423- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -423- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0260-LER-DADOS-PAGADOR-DB-SELECT-1 */
        public void R0260_LER_DADOS_PAGADOR_DB_SELECT_1()
        {
            /*" -408- EXEC SQL SELECT NUM_CGC_CPF , NOM_PAGADOR , DTH_NASCIMENTO, NUM_TELEFONE INTO :PF039-NUM-CGC-CPF , :PF039-NOM-PAGADOR , :PF039-DTH-NASCIMENTO, :PF039-NUM-TELEFONE FROM SEGUROS.PF_PAGADOR_SIVPF WHERE NUM_CGC_CPF = :PF039-NUM-CGC-CPF WITH UR END-EXEC. */

            var r0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1 = new R0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1()
            {
                PF039_NUM_CGC_CPF = PF039.DCLPF_PAGADOR_SIVPF.PF039_NUM_CGC_CPF.ToString(),
            };

            var executed_1 = R0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1.Execute(r0260_LER_DADOS_PAGADOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PF039_NUM_CGC_CPF, PF039.DCLPF_PAGADOR_SIVPF.PF039_NUM_CGC_CPF);
                _.Move(executed_1.PF039_NOM_PAGADOR, PF039.DCLPF_PAGADOR_SIVPF.PF039_NOM_PAGADOR);
                _.Move(executed_1.PF039_DTH_NASCIMENTO, PF039.DCLPF_PAGADOR_SIVPF.PF039_DTH_NASCIMENTO);
                _.Move(executed_1.PF039_NUM_TELEFONE, PF039.DCLPF_PAGADOR_SIVPF.PF039_NUM_TELEFONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_SAIDA*/

        [StopWatch]
        /*" R0270-ATUALIZA-DADOS-PAGADOR-SECTION */
        private void R0270_ATUALIZA_DADOS_PAGADOR_SECTION()
        {
            /*" -433- MOVE 'R0250-GERAR-TAB-PAGAMENTO' TO PARAGRAFO. */
            _.Move("R0250-GERAR-TAB-PAGAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -435- MOVE 'UPDATE PF_PAGADOR_SIVPF' TO COMANDO. */
            _.Move("UPDATE PF_PAGADOR_SIVPF", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -436- IF R0-NOME-PAGADOR NOT EQUAL SPACES */

            if (!LBFPF000.REG_PAG_AVULSO.R0_NOME_PAGADOR.IsEmpty())
            {

                /*" -438- MOVE R0-NOME-PAGADOR TO PF039-NOM-PAGADOR. */
                _.Move(LBFPF000.REG_PAG_AVULSO.R0_NOME_PAGADOR, PF039.DCLPF_PAGADOR_SIVPF.PF039_NOM_PAGADOR);
            }


            /*" -439- IF R0-TELEFONE-PGTO NOT EQUAL SPACES */

            if (!LBFPF000.REG_PAG_AVULSO.R0_TELEFONE_PGTO.IsEmpty())
            {

                /*" -441- MOVE R0-TELEFONE-PGTO TO PF039-NUM-TELEFONE. */
                _.Move(LBFPF000.REG_PAG_AVULSO.R0_TELEFONE_PGTO, PF039.DCLPF_PAGADOR_SIVPF.PF039_NUM_TELEFONE);
            }


            /*" -443- IF R0-DATA-NASCIMENTO NUMERIC AND R0-DATA-NASCIMENTO GREATER ZEROS */

            if (LBFPF000.REG_PAG_AVULSO.R0_DATA_NASCIMENTO.IsNumeric() && LBFPF000.REG_PAG_AVULSO.R0_DATA_NASCIMENTO > 00)
            {

                /*" -444- MOVE R0-DATA-NASCIMENTO TO W-DATA-TRABALHO */
                _.Move(LBFPF000.REG_PAG_AVULSO.R0_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_TRABALHO);

                /*" -445- MOVE W-DIA-TRABALHO TO W-DIA-SQL */
                _.Move(WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                /*" -446- MOVE W-MES-TRABALHO TO W-MES-SQL */
                _.Move(WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                /*" -447- MOVE W-ANO-TRABALHO TO W-ANO-SQL */
                _.Move(WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                /*" -449- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1 W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                /*" -451- MOVE W-DATA-SQL TO PF039-DTH-NASCIMENTO. */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL, PF039.DCLPF_PAGADOR_SIVPF.PF039_DTH_NASCIMENTO);
            }


            /*" -457- PERFORM R0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1 */

            R0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1();

            /*" -460- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -461- DISPLAY 'PF0106B - FIM ANORMAL' */
                _.Display($"PF0106B - FIM ANORMAL");

                /*" -462- DISPLAY '          ERRO UPDATE TAB PF_PAGADOR_SIVPF' */
                _.Display($"          ERRO UPDATE TAB PF_PAGADOR_SIVPF");

                /*" -464- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -466- DISPLAY '          NUMERO DO CPF.................  ' PF038-NUM-CGC-CPF */
                _.Display($"          NUMERO DO CPF.................  {PF038.DCLPF_PGTO_SIVPF.PF038_NUM_CGC_CPF}");

                /*" -467- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -467- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0270-ATUALIZA-DADOS-PAGADOR-DB-UPDATE-1 */
        public void R0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1()
        {
            /*" -457- EXEC SQL UPDATE SEGUROS.PF_PAGADOR_SIVPF SET NOM_PAGADOR = :PF039-NOM-PAGADOR , DTH_NASCIMENTO = :PF039-DTH-NASCIMENTO, NUM_TELEFONE = :PF039-NUM-TELEFONE WHERE NUM_CGC_CPF = :PF039-NUM-CGC-CPF END-EXEC. */

            var r0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1_Update1 = new R0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1_Update1()
            {
                PF039_DTH_NASCIMENTO = PF039.DCLPF_PAGADOR_SIVPF.PF039_DTH_NASCIMENTO.ToString(),
                PF039_NUM_TELEFONE = PF039.DCLPF_PAGADOR_SIVPF.PF039_NUM_TELEFONE.ToString(),
                PF039_NOM_PAGADOR = PF039.DCLPF_PAGADOR_SIVPF.PF039_NOM_PAGADOR.ToString(),
                PF039_NUM_CGC_CPF = PF039.DCLPF_PAGADOR_SIVPF.PF039_NUM_CGC_CPF.ToString(),
            };

            R0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1_Update1.Execute(r0270_ATUALIZA_DADOS_PAGADOR_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_SAIDA*/

        [StopWatch]
        /*" R0280-INSERIR-DADOS-PAGADOR-SECTION */
        private void R0280_INSERIR_DADOS_PAGADOR_SECTION()
        {
            /*" -477- MOVE 'R0280-INSERIR-DADOS-PAGADOR' TO PARAGRAFO. */
            _.Move("R0280-INSERIR-DADOS-PAGADOR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -479- MOVE 'INSERT PF_PAGADOR_SIVPF' TO COMANDO. */
            _.Move("INSERT PF_PAGADOR_SIVPF", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -481- MOVE R0-CPFCGC TO PF039-NUM-CGC-CPF */
            _.Move(LBFPF000.REG_PAG_AVULSO.R0_CPFCGC, PF039.DCLPF_PAGADOR_SIVPF.PF039_NUM_CGC_CPF);

            /*" -483- MOVE R0-NOME-PAGADOR TO PF039-NOM-PAGADOR. */
            _.Move(LBFPF000.REG_PAG_AVULSO.R0_NOME_PAGADOR, PF039.DCLPF_PAGADOR_SIVPF.PF039_NOM_PAGADOR);

            /*" -484- IF R0-TELEFONE-PGTO NOT EQUAL SPACES */

            if (!LBFPF000.REG_PAG_AVULSO.R0_TELEFONE_PGTO.IsEmpty())
            {

                /*" -485- MOVE R0-TELEFONE-PGTO TO PF039-NUM-TELEFONE */
                _.Move(LBFPF000.REG_PAG_AVULSO.R0_TELEFONE_PGTO, PF039.DCLPF_PAGADOR_SIVPF.PF039_NUM_TELEFONE);

                /*" -486- ELSE */
            }
            else
            {


                /*" -488- MOVE ZEROS TO PF039-NUM-TELEFONE. */
                _.Move(0, PF039.DCLPF_PAGADOR_SIVPF.PF039_NUM_TELEFONE);
            }


            /*" -490- IF R0-DATA-NASCIMENTO NUMERIC AND R0-DATA-NASCIMENTO GREATER ZEROS */

            if (LBFPF000.REG_PAG_AVULSO.R0_DATA_NASCIMENTO.IsNumeric() && LBFPF000.REG_PAG_AVULSO.R0_DATA_NASCIMENTO > 00)
            {

                /*" -491- MOVE R0-DATA-NASCIMENTO TO W-DATA-TRABALHO */
                _.Move(LBFPF000.REG_PAG_AVULSO.R0_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_TRABALHO);

                /*" -492- MOVE W-DIA-TRABALHO TO W-DIA-SQL */
                _.Move(WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                /*" -493- MOVE W-MES-TRABALHO TO W-MES-SQL */
                _.Move(WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                /*" -494- MOVE W-ANO-TRABALHO TO W-ANO-SQL */
                _.Move(WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                /*" -496- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1 W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                /*" -497- MOVE W-DATA-SQL TO PF039-DTH-NASCIMENTO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL, PF039.DCLPF_PAGADOR_SIVPF.PF039_DTH_NASCIMENTO);

                /*" -498- ELSE */
            }
            else
            {


                /*" -500- MOVE '0001-01-01' TO PF039-DTH-NASCIMENTO. */
                _.Move("0001-01-01", PF039.DCLPF_PAGADOR_SIVPF.PF039_DTH_NASCIMENTO);
            }


            /*" -506- PERFORM R0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1 */

            R0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1();

            /*" -509- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -510- DISPLAY 'PF0106B - FIM ANORMAL' */
                _.Display($"PF0106B - FIM ANORMAL");

                /*" -511- DISPLAY '          ERRO INSERT TAB PF_PAGADOR_SIVPF' */
                _.Display($"          ERRO INSERT TAB PF_PAGADOR_SIVPF");

                /*" -513- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -515- DISPLAY '          NUMERO DO CPF.................  ' PF038-NUM-CGC-CPF */
                _.Display($"          NUMERO DO CPF.................  {PF038.DCLPF_PGTO_SIVPF.PF038_NUM_CGC_CPF}");

                /*" -516- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -516- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0280-INSERIR-DADOS-PAGADOR-DB-INSERT-1 */
        public void R0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1()
        {
            /*" -506- EXEC SQL INSERT INTO SEGUROS.PF_PAGADOR_SIVPF VALUES (:PF039-NUM-CGC-CPF , :PF039-NOM-PAGADOR , :PF039-DTH-NASCIMENTO, :PF039-NUM-TELEFONE) END-EXEC. */

            var r0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1_Insert1 = new R0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1_Insert1()
            {
                PF039_NUM_CGC_CPF = PF039.DCLPF_PAGADOR_SIVPF.PF039_NUM_CGC_CPF.ToString(),
                PF039_NOM_PAGADOR = PF039.DCLPF_PAGADOR_SIVPF.PF039_NOM_PAGADOR.ToString(),
                PF039_DTH_NASCIMENTO = PF039.DCLPF_PAGADOR_SIVPF.PF039_DTH_NASCIMENTO.ToString(),
                PF039_NUM_TELEFONE = PF039.DCLPF_PAGADOR_SIVPF.PF039_NUM_TELEFONE.ToString(),
            };

            R0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1_Insert1.Execute(r0280_INSERIR_DADOS_PAGADOR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0280_SAIDA*/

        [StopWatch]
        /*" R0290-GERAR-TAB-PAGAMENTO-SECTION */
        private void R0290_GERAR_TAB_PAGAMENTO_SECTION()
        {
            /*" -526- MOVE 'R0290-GERAR-TAB-PAGAMENTO' TO PARAGRAFO. */
            _.Move("R0290-GERAR-TAB-PAGAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -528- MOVE 'INSERT PF_PGTO_SIVPF' TO COMANDO. */
            _.Move("INSERT PF_PGTO_SIVPF", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -529- MOVE R0-NUM-SICOB TO PF038-NUM-TITULO-SIVPF */
            _.Move(LBFPF000.REG_PAG_AVULSO.R0_NUM_SICOB, PF038.DCLPF_PGTO_SIVPF.PF038_NUM_TITULO_SIVPF);

            /*" -531- MOVE R0-COD-PRODUTO-PAGO TO PF038-COD-PRODUTO-SIVPF */
            _.Move(LBFPF000.REG_PAG_AVULSO.R0_COD_PRODUTO_PAGO, PF038.DCLPF_PGTO_SIVPF.PF038_COD_PRODUTO_SIVPF);

            /*" -532- IF R0-AGENCIA-RECEBEDORA EQUAL ZEROS */

            if (LBFPF000.REG_PAG_AVULSO.R0_AGENCIA_RECEBEDORA == 00)
            {

                /*" -533- MOVE 9999 TO PF038-COD-AGENCIA */
                _.Move(9999, PF038.DCLPF_PGTO_SIVPF.PF038_COD_AGENCIA);

                /*" -534- ELSE */
            }
            else
            {


                /*" -536- MOVE R0-AGENCIA-RECEBEDORA TO PF038-COD-AGENCIA. */
                _.Move(LBFPF000.REG_PAG_AVULSO.R0_AGENCIA_RECEBEDORA, PF038.DCLPF_PGTO_SIVPF.PF038_COD_AGENCIA);
            }


            /*" -537- MOVE R0-IDENTIFICA-PAGO TO PF038-IND-PAGAMENTO */
            _.Move(LBFPF000.REG_PAG_AVULSO.R0_IDENTIFICA_PAGO, PF038.DCLPF_PGTO_SIVPF.PF038_IND_PAGAMENTO);

            /*" -538- MOVE R0-CPFCGC TO PF038-NUM-CGC-CPF */
            _.Move(LBFPF000.REG_PAG_AVULSO.R0_CPFCGC, PF038.DCLPF_PGTO_SIVPF.PF038_NUM_CGC_CPF);

            /*" -539- MOVE R0-NUM-PROPOSTA TO PF038-NUM-PROPOSTA */
            _.Move(LBFPF000.REG_PAG_AVULSO.R0_NUM_PROPOSTA, PF038.DCLPF_PGTO_SIVPF.PF038_NUM_PROPOSTA);

            /*" -540- MOVE R0-NRCERTIF TO PF038-NUM-CERTIFICADO */
            _.Move(LBFPF000.REG_PAG_AVULSO.R0_NRCERTIF, PF038.DCLPF_PGTO_SIVPF.PF038_NUM_CERTIFICADO);

            /*" -542- MOVE R0-NUM-PARCELA TO PF038-NUM-PARCELA-PAGA. */
            _.Move(LBFPF000.REG_PAG_AVULSO.R0_NUM_PARCELA, PF038.DCLPF_PGTO_SIVPF.PF038_NUM_PARCELA_PAGA);

            /*" -543- MOVE R0-DATA-QUITACAO TO W-DATA-TRABALHO */
            _.Move(LBFPF000.REG_PAG_AVULSO.R0_DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -544- MOVE W-DIA-TRABALHO TO W-DIA-SQL */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -545- MOVE W-MES-TRABALHO TO W-MES-SQL */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -546- MOVE W-ANO-TRABALHO TO W-ANO-SQL */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -548- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1 W-BARRA2 OF W-DATA-SQL1 */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -550- MOVE W-DATA-SQL TO PF038-DTH-QUITACAO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PF038.DCLPF_PGTO_SIVPF.PF038_DTH_QUITACAO);

            /*" -552- MOVE R0-VAL-PAGO TO PF038-VLR-PAGO */
            _.Move(LBFPF000.REG_PAG_AVULSO.R0_VAL_PAGO, PF038.DCLPF_PGTO_SIVPF.PF038_VLR_PAGO);

            /*" -553- MOVE RH-NOME TO PF038-SIGLA-ARQUIVO */
            _.Move(LXFPF990.REG_HEADER.RH_NOME, PF038.DCLPF_PGTO_SIVPF.PF038_SIGLA_ARQUIVO);

            /*" -554- MOVE RH-SIST-ORIGEM TO PF038-SISTEMA-ORIGEM */
            _.Move(LXFPF990.REG_HEADER.RH_SIST_ORIGEM, PF038.DCLPF_PGTO_SIVPF.PF038_SISTEMA_ORIGEM);

            /*" -556- MOVE RH-NSAS TO PF038-NSAS-SIVPF. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PF038.DCLPF_PGTO_SIVPF.PF038_NSAS_SIVPF);

            /*" -571- PERFORM R0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1 */

            R0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1();

            /*" -574- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -575- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -580- DISPLAY 'PF0106B-TITULO DUPLICADO => ' PF038-NUM-TITULO-SIVPF ' => ' RH-NOME ' => ' RH-DATA-GERACAO ' => ' RH-NSAS */

                    $"PF0106B-TITULO DUPLICADO => {PF038.DCLPF_PGTO_SIVPF.PF038_NUM_TITULO_SIVPF} => {LXFPF990.REG_HEADER.RH_NOME} => {LXFPF990.REG_HEADER.RH_DATA_GERACAO} => {LXFPF990.REG_HEADER.RH_NSAS}"
                    .Display();

                    /*" -581- ELSE */
                }
                else
                {


                    /*" -582- DISPLAY 'PF0106B - FIM ANORMAL' */
                    _.Display($"PF0106B - FIM ANORMAL");

                    /*" -583- DISPLAY '          ERRO INSERT TABELA PF_PGTO_SIVPF' */
                    _.Display($"          ERRO INSERT TABELA PF_PGTO_SIVPF");

                    /*" -585- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -587- DISPLAY '          NUMERO DO TITULO..............  ' PF038-NUM-TITULO-SIVPF */
                    _.Display($"          NUMERO DO TITULO..............  {PF038.DCLPF_PGTO_SIVPF.PF038_NUM_TITULO_SIVPF}");

                    /*" -588- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -588- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0290-GERAR-TAB-PAGAMENTO-DB-INSERT-1 */
        public void R0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1()
        {
            /*" -571- EXEC SQL INSERT INTO SEGUROS.PF_PGTO_SIVPF VALUES (:PF038-NUM-TITULO-SIVPF , :PF038-COD-PRODUTO-SIVPF, :PF038-COD-AGENCIA , :PF038-IND-PAGAMENTO , :PF038-NUM-CGC-CPF , :PF038-NUM-PROPOSTA , :PF038-NUM-CERTIFICADO , :PF038-NUM-PARCELA-PAGA , :PF038-DTH-QUITACAO , :PF038-VLR-PAGO , :PF038-SIGLA-ARQUIVO , :PF038-SISTEMA-ORIGEM , :PF038-NSAS-SIVPF) END-EXEC. */

            var r0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1_Insert1 = new R0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1_Insert1()
            {
                PF038_NUM_TITULO_SIVPF = PF038.DCLPF_PGTO_SIVPF.PF038_NUM_TITULO_SIVPF.ToString(),
                PF038_COD_PRODUTO_SIVPF = PF038.DCLPF_PGTO_SIVPF.PF038_COD_PRODUTO_SIVPF.ToString(),
                PF038_COD_AGENCIA = PF038.DCLPF_PGTO_SIVPF.PF038_COD_AGENCIA.ToString(),
                PF038_IND_PAGAMENTO = PF038.DCLPF_PGTO_SIVPF.PF038_IND_PAGAMENTO.ToString(),
                PF038_NUM_CGC_CPF = PF038.DCLPF_PGTO_SIVPF.PF038_NUM_CGC_CPF.ToString(),
                PF038_NUM_PROPOSTA = PF038.DCLPF_PGTO_SIVPF.PF038_NUM_PROPOSTA.ToString(),
                PF038_NUM_CERTIFICADO = PF038.DCLPF_PGTO_SIVPF.PF038_NUM_CERTIFICADO.ToString(),
                PF038_NUM_PARCELA_PAGA = PF038.DCLPF_PGTO_SIVPF.PF038_NUM_PARCELA_PAGA.ToString(),
                PF038_DTH_QUITACAO = PF038.DCLPF_PGTO_SIVPF.PF038_DTH_QUITACAO.ToString(),
                PF038_VLR_PAGO = PF038.DCLPF_PGTO_SIVPF.PF038_VLR_PAGO.ToString(),
                PF038_SIGLA_ARQUIVO = PF038.DCLPF_PGTO_SIVPF.PF038_SIGLA_ARQUIVO.ToString(),
                PF038_SISTEMA_ORIGEM = PF038.DCLPF_PGTO_SIVPF.PF038_SISTEMA_ORIGEM.ToString(),
                PF038_NSAS_SIVPF = PF038.DCLPF_PGTO_SIVPF.PF038_NSAS_SIVPF.ToString(),
            };

            R0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1_Insert1.Execute(r0290_GERAR_TAB_PAGAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_SAIDA*/

        [StopWatch]
        /*" R2000-00-IMPRIMIR-TOTAIS-SECTION */
        private void R2000_00_IMPRIMIR_TOTAIS_SECTION()
        {
            /*" -597- DISPLAY ' ' */
            _.Display($" ");

            /*" -598- DISPLAY ' PF0106B - FIM NORMAL' */
            _.Display($" PF0106B - FIM NORMAL");

            /*" -600- DISPLAY '           TOTAL LIDOS........ ' W-LIDO-MOVTO-SIGAT */
            _.Display($"           TOTAL LIDOS........ {WAREA_AUXILIAR.W_LIDO_MOVTO_SIGAT}");

            /*" -601- DISPLAY '           TOTAL PROCESSADO... ' W-PROCESSADO-SIGAT. */
            _.Display($"           TOTAL PROCESSADO... {WAREA_AUXILIAR.W_PROCESSADO_SIGAT}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -612- CLOSE MOV-SIGAT. */
            MOV_SIGAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -628- DISPLAY ' ' */
            _.Display($" ");

            /*" -629- IF W-FIM-MOVTO-SIGAT = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT == "FIM")
            {

                /*" -630- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_1.COMANDO);

                /*" -630- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -632- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -633- ELSE */
            }
            else
            {


                /*" -634- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -635- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

                /*" -636- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

                /*" -637- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -638- DISPLAY '*---------------------------------------*' */
                _.Display($"*---------------------------------------*");

                /*" -639- DISPLAY '*   PF0106B *** ROLLBACK EM ANDAMENTO   *' */
                _.Display($"*   PF0106B *** ROLLBACK EM ANDAMENTO   *");

                /*" -640- DISPLAY '*---------------------------------------*' */
                _.Display($"*---------------------------------------*");

                /*" -641- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_1.COMANDO);

                /*" -641- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -644- MOVE 99 TO RETURN-CODE. */
                _.Move(99, RETURN_CODE);
            }


            /*" -645- DISPLAY '*' . */
            _.Display($"*");

            /*" -653- DISPLAY 'PF0106B - TERMINO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"PF0106B - TERMINO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -655- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -655- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}