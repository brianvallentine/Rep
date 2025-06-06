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
using Sias.PessoaFisica.DB2.PF0715B;

namespace Code
{
    public class PF0715B
    {
        public bool IsCall { get; set; }

        public PF0715B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ...............  GERA MOVIMENTACAO DE 'RTV'  E  'REJ' *      */
        /*"      *                           DAS PROPOSTAS EMPRESARIAL  AO  SIGPG *      */
        /*"      *                           ANTES DA LIBERACAO DO TERMO - VIDA.  *      */
        /*"      *   ANALISE/PROGRAMACAO...  LUIZ CARLOS.                         *      */
        /*"      *   PROGRAMA .............  PF0715B                              *      */
        /*"      *   DATA (EM PRODUTO).....  29/07/2004.                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 04             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA                          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 03                                                      *      */
        /*"      *            COLOCAR CLAUSULA WITH UR NOS COMANDOS SELECT DO DB2.*      */
        /*"      *            CADMUS 54479                                        *      */
        /*"      *                                                                *      */
        /*"      * 25/07/2011 PROCURE POR V.03 - SERGIO LORETO                    *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 02                                                      *      */
        /*"      *            DESPREZAR COD_PRODUTO_SIVPF IGUAL A 48. TRATA-SE DA *      */
        /*"      *            INTERNALIZACAO DE APOLICE ESPECIFICA DE VIDA.       *      */
        /*"      *                                                                *      */
        /*"      * 27/11/2007 PROCURE POR V.02 - MAURICIO LINKE.                  *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 01                                                      *      */
        /*"      *          (V.01) EM 10/1/2007                                   *      */
        /*"      * PASSOU A GERAR O REGISTRO TP '8' EM FUNCAO DO BLOCO 33 SIDEM.  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"1     **********************                                                  */
        #endregion


        #region VARIABLES

        public FileBasis _MOVTO_STA_SASSE { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOVTO_STA_SASSE
        {
            get
            {
                _.Move(REG_STA_SASSE, _MOVTO_STA_SASSE); VarBasis.RedefinePassValue(REG_STA_SASSE, _MOVTO_STA_SASSE, REG_STA_SASSE); return _MOVTO_STA_SASSE;
            }
        }
        /*"01   REG-STA-SASSE                      PIC X(100).*/
        public StringBasis REG_STA_SASSE { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WHOST-DATA-REFERENCIA            PIC X(010).*/
        public StringBasis WHOST_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  VIND-RCAP                         PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-VAL-RCAP                     PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_VAL_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DATA-RCAP                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DATA_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WAREA-AUXILIAR.*/
        public PF0715B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0715B_WAREA_AUXILIAR();
        public class PF0715B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-TERNIV                  PIC X(001)  VALUE SPACES.*/
            public StringBasis W_FIM_TERNIV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05  W-FIM-MOVTO-TERMO             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_TERMO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-AC-CONTROLE                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-IND-NIVEL                   PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_IND_NIVEL { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-IND-IOF                     PIC S9(01)V9(4) COMP-3.*/
            public DoubleBasis W_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(01)V9(4)"), 4);
            /*"    05  W-PRM-LIQ                     PIC  9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_PRM_LIQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05  W-TIME                        PIC X(08).*/
            public StringBasis W_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05  W-TIME-EDIT                   PIC 99.99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"    05  W-DESPREZADO                  PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-NSAS                        PIC 9(006).*/
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSL                         PIC 9(008).*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  W-CONTROLE                    PIC 9(006).*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-CONTROLE-TP-0               PIC 9(001)  VALUE ZERO.*/
            public IntBasis W_CONTROLE_TP_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0715B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0715B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0715B_FILLER_0(); _.Move(W_DATA_TRABALHO, _filler_0); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_0, W_DATA_TRABALHO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_DATA_TRABALHO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0715B_FILLER_0 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-COD-COBERTURA               PIC 9(004)  VALUE ZEROS.*/

                public _REDEF_PF0715B_FILLER_0()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER REDEFINES W-COD-COBERTURA.*/
            private _REDEF_PF0715B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0715B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0715B_FILLER_1(); _.Move(W_COD_COBERTURA, _filler_1); VarBasis.RedefinePassValue(W_COD_COBERTURA, _filler_1, W_COD_COBERTURA); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_COD_COBERTURA); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_COD_COBERTURA); }
            }  //Redefines
            public class _REDEF_PF0715B_FILLER_1 : VarBasis
            {
                /*"        10  W-SUBPRODUTO              PIC 9(003).*/
                public IntBasis W_SUBPRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        10  W-COBERTURA               PIC 9(001).*/
                public IntBasis W_COBERTURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0715B_FILLER_1()
                {
                    W_SUBPRODUTO.ValueChanged += OnValueChanged;
                    W_COBERTURA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0715B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0715B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0715B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0715B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0715B_W_DTMOVABE1()
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
            private _REDEF_PF0715B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0715B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0715B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0715B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0715B_W_DTMOVABE_I1()
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
            private _REDEF_PF0715B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0715B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0715B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0715B_W_DATA_SQL1 : VarBasis
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
                /*"    05  W-NR-SICOB                    PIC 9(015).*/

                public _REDEF_PF0715B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NR_SICOB { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  FILLER REDEFINES W-NR-SICOB.*/
            private _REDEF_PF0715B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0715B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0715B_FILLER_2(); _.Move(W_NR_SICOB, _filler_2); VarBasis.RedefinePassValue(W_NR_SICOB, _filler_2, W_NR_SICOB); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_NR_SICOB); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_NR_SICOB); }
            }  //Redefines
            public class _REDEF_PF0715B_FILLER_2 : VarBasis
            {
                /*"        07  W-NR-PROD-SICOB           PIC 9(003).*/
                public IntBasis W_NR_PROD_SICOB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  W-NR-NSAC-SICOB           PIC 9(006).*/
                public IntBasis W_NR_NSAC_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        07  W-NR-NSL-SICOB            PIC 9(006).*/
                public IntBasis W_NR_NSL_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05 W-HISTORICO                    PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0715B_FILLER_2()
                {
                    W_NR_PROD_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSAC_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSL_SICOB.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_HISTORICO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HISTORICO-CADASTRADO                    VALUE 1. */
							new SelectorItemBasis("HISTORICO_CADASTRADO", "1"),
							/*" 88 HISTORICO-NAO-CADASTRADO                VALUE 2. */
							new SelectorItemBasis("HISTORICO_NAO_CADASTRADO", "2")
                }
            };

            /*"    05 W-REGISTROS                    PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_REGISTROS { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 REGISTROS-1-E-4                         VALUE 1. */
							new SelectorItemBasis("REGISTROS_1_E_4", "1"),
							/*" 88 REGISTROS-1-A-5                         VALUE 2. */
							new SelectorItemBasis("REGISTROS_1_A_5", "2")
                }
            };

            /*"    05 W-PROPOSTAVA                   PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_PROPOSTAVA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTAVA-CADASTRADA                    VALUE 1. */
							new SelectorItemBasis("PROPOSTAVA_CADASTRADA", "1"),
							/*" 88 PROPOSTAVA-NAO-CADASTRADA                VALUE 2. */
							new SelectorItemBasis("PROPOSTAVA_NAO_CADASTRADA", "2")
                }
            };

            /*"    05 W-FIDELIZ                      PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_FIDELIZ { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTA-CADASTRADA                     VALUE 1. */
							new SelectorItemBasis("PROPOSTA_CADASTRADA", "1"),
							/*" 88 PROPOSTA-NAO-CADASTRADA                 VALUE 2. */
							new SelectorItemBasis("PROPOSTA_NAO_CADASTRADA", "2")
                }
            };

            /*"    05 W-COBERTURAS                   PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_COBERTURAS { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 COBERTURA-CADASTRADA                    VALUE 1. */
							new SelectorItemBasis("COBERTURA_CADASTRADA", "1"),
							/*" 88 COBERTURA-NAO-CADASTRADA                VALUE 2. */
							new SelectorItemBasis("COBERTURA_NAO_CADASTRADA", "2")
                }
            };

            /*"    05 W-TEM-HISTORICO                PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TEM_HISTORICO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88     TEM-HISTORICO                       VALUE 1. */
							new SelectorItemBasis("TEM_HISTORICO", "1"),
							/*" 88 NAO-TEM-HISTORICO                       VALUE 2. */
							new SelectorItemBasis("NAO_TEM_HISTORICO", "2")
                }
            };

            /*"01  WABEND*/
        }
        public PF0715B_WABEND WABEND { get; set; } = new PF0715B_WABEND();
        public class PF0715B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0715B_FILLER_3 FILLER_3 { get; set; } = new PF0715B_FILLER_3();
            public class PF0715B_FILLER_3 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0715B  '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0715B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public PF0715B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0715B_LOCALIZA_ABEND_1();
            public class PF0715B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0715B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0715B_LOCALIZA_ABEND_2();
            public class PF0715B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Copies.LBFPF200 LBFPF200 { get; set; } = new Copies.LBFPF200();
        public Copies.LBFPF025 LBFPF025 { get; set; } = new Copies.LBFPF025();
        public Dclgens.VGACOTER VGACOTER { get; set; } = new Dclgens.VGACOTER();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.PF037 PF037 { get; set; } = new Dclgens.PF037();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.TERMOADE TERMOADE { get; set; } = new Dclgens.TERMOADE();
        public Dclgens.VGTERNIV VGTERNIV { get; set; } = new Dclgens.VGTERNIV();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public PF0715B_TERMO_ADESAO TERMO_ADESAO { get; set; } = new PF0715B_TERMO_ADESAO();
        public PF0715B_COBERTURAS COBERTURAS { get; set; } = new PF0715B_COBERTURAS();
        public PF0715B_TER_NIVEL TER_NIVEL { get; set; } = new PF0715B_TER_NIVEL();
        public PF0715B_PAGAMENTO PAGAMENTO { get; set; } = new PF0715B_PAGAMENTO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_STA_SASSE_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO_STA_SASSE.SetFile(MOVTO_STA_SASSE_FILE_NAME_P);

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
            /*" -283- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -284- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -285- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -288- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -289- DISPLAY '*               PROGRAMA PF0715B               *' . */
            _.Display($"*               PROGRAMA PF0715B               *");

            /*" -290- DISPLAY '*   GERA MOV RTV E REJ DAS PROP EMPRESARIAIS   *' . */
            _.Display($"*   GERA MOV RTV E REJ DAS PROP EMPRESARIAIS   *");

            /*" -291- DISPLAY '*           VERSAO:  04 - 29/11/2013           *' . */
            _.Display($"*           VERSAO:  04 - 29/11/2013           *");

            /*" -292- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -301- DISPLAY '*  PF0715B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0715B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -303- PERFORM R0005-00-INICIALIZAR. */

            R0005_00_INICIALIZAR_SECTION();

            /*" -305- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -307- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -309- PERFORM R0070-00-LER-MOVTO. */

            R0070_00_LER_MOVTO_SECTION();

            /*" -310- IF W-FIM-MOVTO-TERMO EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM")
            {

                /*" -311- DISPLAY '*----------------------------------------*' */
                _.Display($"*----------------------------------------*");

                /*" -312- DISPLAY '* PF0715B - TERMINO NORMAL, NAO HOUVE    *' */
                _.Display($"* PF0715B - TERMINO NORMAL, NAO HOUVE    *");

                /*" -313- DISPLAY '*           MOVIMENTO NA DATA SOLICITADA *' */
                _.Display($"*           MOVIMENTO NA DATA SOLICITADA *");

                /*" -314- DISPLAY '*----------------------------------------*' */
                _.Display($"*----------------------------------------*");

                /*" -315- PERFORM R1100-00-GERAR-TOTAIS */

                R1100_00_GERAR_TOTAIS_SECTION();

                /*" -316- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -318- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -320- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -323- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-TERMO EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -325- PERFORM R1000-00-GERAR-TRAILLER. */

            R1000_00_GERAR_TRAILLER_SECTION();

            /*" -327- PERFORM R1050-00-CONTROLAR-ARQ-ENVIADO */

            R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -329- PERFORM R1100-00-GERAR-TOTAIS. */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -331- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -331- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0005-00-INICIALIZAR-SECTION */
        private void R0005_00_INICIALIZAR_SECTION()
        {
            /*" -339- MOVE 'R0005-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0005-00-INICIALIZAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -341- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -343- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -351- PERFORM R0005_00_INICIALIZAR_DB_SELECT_1 */

            R0005_00_INICIALIZAR_DB_SELECT_1();

            /*" -356- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -358- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -360- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -363- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -367- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -370- DISPLAY '*  PF0715B - DATA PROCESSAMENTO...' W-DTMOVABE-I1. */
            _.Display($"*  PF0715B - DATA PROCESSAMENTO...{WAREA_AUXILIAR.W_DTMOVABE_I1}");

            /*" -372- INITIALIZE REG-TRAILLER-STA. */
            _.Initialize(
                LBFCT011.REG_TRAILLER_STA
            );

            /*" -372- OPEN OUTPUT MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }

        [StopWatch]
        /*" R0005-00-INICIALIZAR-DB-SELECT-1 */
        public void R0005_00_INICIALIZAR_DB_SELECT_1()
        {
            /*" -351- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :WHOST-DATA-REFERENCIA FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0005_00_INICIALIZAR_DB_SELECT_1_Query1 = new R0005_00_INICIALIZAR_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0005_00_INICIALIZAR_DB_SELECT_1_Query1.Execute(r0005_00_INICIALIZAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA_REFERENCIA, WHOST_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -382- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -384- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -387- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -391- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -400- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -403- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -404- DISPLAY 'PF0715B - FIM ANORMAL' */
                _.Display($"PF0715B - FIM ANORMAL");

                /*" -405- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -407- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -408- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -410- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -413- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -415- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -415- MOVE W-NSAS TO RH-NSAS OF REG-HEADER-STA. */
            _.Move(WAREA_AUXILIAR.W_NSAS, LBFCT011.REG_HEADER_STA.RH_NSAS);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -400- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

            var r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 = new R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1.Execute(r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_SAIDA*/

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-SECTION */
        private void R0050_00_SELECIONA_MOVTO_SECTION()
        {
            /*" -425- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -427- MOVE 'DECLER MOVIMENTO' TO COMANDO. */
            _.Move("DECLER MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -428- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -430- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -433- DISPLAY '** PF0715B ** INICIO DECLARE V0MOVIMENTO...  ' W-TIME-EDIT. */
            _.Display($"** PF0715B ** INICIO DECLARE V0MOVIMENTO...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -434- MOVE 15 TO PROPOFID-COD-PRODUTO-SIVPF */
            _.Move(15, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);

            /*" -436- MOVE ' ' TO TERMOADE-SITUACAO */
            _.Move(" ", TERMOADE.DCLTERMO_ADESAO.TERMOADE_SITUACAO);

            /*" -464- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -466- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -469- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -471- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -473- DISPLAY '** PF0715B ** FIM    DECLARE V0MOVIMENTO...  ' W-TIME-EDIT */
            _.Display($"** PF0715B ** FIM    DECLARE V0MOVIMENTO...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -473- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -464- EXEC SQL DECLARE TERMO-ADESAO CURSOR FOR SELECT A.NUM_TERMO , A.NUM_APOLICE , B.NUM_CERTIFICADO , B.OCORR_HISTORICO , B.COD_DEVOLUCAO , B.COD_OPERACAO , B.DATA_MOVIMENTO , C.SIT_PROPOSTA , C.NUM_PROPOSTA_SIVPF , C.NUM_IDENTIFICACAO , C.COD_EMPRESA_SIVPF , C.COD_PRODUTO_SIVPF FROM SEGUROS.TERMO_ADESAO A, SEGUROS.VG_ACOMP_TERMO B, SEGUROS.PROPOSTA_FIDELIZ C WHERE A.SITUACAO <> :TERMOADE-SITUACAO AND A.NUM_TERMO = B.NUM_TERMO AND B.COD_OPERACAO > 199 AND B.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND C.NUM_PROPOSTA_SIVPF = B.NUM_CERTIFICADO AND C.COD_PRODUTO_SIVPF <> :PROPOFID-COD-PRODUTO-SIVPF AND C.COD_PRODUTO_SIVPF <> 48 ORDER BY A.NUM_TERMO, B.OCORR_HISTORICO, B.DATA_MOVIMENTO, B.COD_OPERACAO WITH UR END-EXEC. */
            TERMO_ADESAO = new PF0715B_TERMO_ADESAO(true);
            string GetQuery_TERMO_ADESAO()
            {
                var query = @$"SELECT A.NUM_TERMO
							, 
							A.NUM_APOLICE
							, 
							B.NUM_CERTIFICADO
							, 
							B.OCORR_HISTORICO
							, 
							B.COD_DEVOLUCAO
							, 
							B.COD_OPERACAO
							, 
							B.DATA_MOVIMENTO
							, 
							C.SIT_PROPOSTA
							, 
							C.NUM_PROPOSTA_SIVPF
							, 
							C.NUM_IDENTIFICACAO
							, 
							C.COD_EMPRESA_SIVPF
							, 
							C.COD_PRODUTO_SIVPF 
							FROM SEGUROS.TERMO_ADESAO A
							, 
							SEGUROS.VG_ACOMP_TERMO B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C 
							WHERE A.SITUACAO <> '{TERMOADE.DCLTERMO_ADESAO.TERMOADE_SITUACAO}' 
							AND A.NUM_TERMO = B.NUM_TERMO 
							AND B.COD_OPERACAO > 199 
							AND B.DATA_MOVIMENTO = 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND C.NUM_PROPOSTA_SIVPF = B.NUM_CERTIFICADO 
							AND C.COD_PRODUTO_SIVPF <> '{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}' 
							AND C.COD_PRODUTO_SIVPF <> 48 
							ORDER BY A.NUM_TERMO
							, B.OCORR_HISTORICO
							, 
							B.DATA_MOVIMENTO
							, B.COD_OPERACAO";

                return query;
            }
            TERMO_ADESAO.GetQueryEvent += GetQuery_TERMO_ADESAO;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -466- EXEC SQL OPEN TERMO-ADESAO END-EXEC. */

            TERMO_ADESAO.Open();

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-DECLARE-1 */
        public void R0450_00_OBTER_COBERTURA_DB_DECLARE_1()
        {
            /*" -808- EXEC SQL DECLARE COBERTURAS CURSOR FOR SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMP_MORNATU , IMPMORACID , IMPINVPERM , VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO AND DATA_TERVIGENCIA = :HISCOBPR-DATA-TERVIGENCIA WITH UR END-EXEC. */
            COBERTURAS = new PF0715B_COBERTURAS(true);
            string GetQuery_COBERTURAS()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							OCORR_HISTORICO
							, 
							DATA_INIVIGENCIA
							, 
							DATA_TERVIGENCIA
							, 
							IMP_MORNATU
							, 
							IMPMORACID
							, 
							IMPINVPERM
							, 
							VLPREMIO 
							FROM SEGUROS.HIS_COBER_PROPOST 
							WHERE NUM_CERTIFICADO = '{HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}' 
							AND DATA_TERVIGENCIA = '{HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA}'";

                return query;
            }
            COBERTURAS.GetQueryEvent += GetQuery_COBERTURAS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -483- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -485- MOVE 'FETCH TERMO-ADESAO' TO COMANDO. */
            _.Move("FETCH TERMO-ADESAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -499- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -502- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -503- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -504- MOVE 'FIM' TO W-FIM-MOVTO-TERMO */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_TERMO);

                    /*" -504- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -506- ELSE */
                }
                else
                {


                    /*" -507- DISPLAY 'PF0715B - FIM ANORMAL' */
                    _.Display($"PF0715B - FIM ANORMAL");

                    /*" -509- DISPLAY '          ERRO FETCH CURSOR V0MOVIMENTO  ' SQLCODE */
                    _.Display($"          ERRO FETCH CURSOR V0MOVIMENTO  {DB.SQLCODE}");

                    /*" -510- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -511- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -513- ELSE */
                }

            }
            else
            {


                /*" -514- IF VIND-RCAP LESS 0 */

                if (VIND_RCAP < 0)
                {

                    /*" -515- GO TO R0070-00-LER-MOVTO */
                    new Task(() => R0070_00_LER_MOVTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -517- END-IF */
                }


                /*" -520- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -521- IF W-CONTROLE > 999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 999)
                {

                    /*" -522- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -523- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -524- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -525- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -527- DISPLAY '** PF0715B ** TOTAL LIDO ..  ' W-NSL ' ' W-TIME-EDIT */

                    $"** PF0715B ** TOTAL LIDO ..  {WAREA_AUXILIAR.W_NSL} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -527- DISPLAY ' ' . */
                    _.Display($" ");
                }

            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -499- EXEC SQL FETCH TERMO-ADESAO INTO :TERMOADE-NUM-TERMO , :TERMOADE-NUM-APOLICE , :VGACOTER-NUM-CERTIFICADO , :VGACOTER-OCORR-HISTORICO , :VGACOTER-COD-DEVOLUCAO , :VGACOTER-COD-OPERACAO , :VGACOTER-DATA-MOVIMENTO , :PROPOFID-SIT-PROPOSTA , :PROPOFID-NUM-PROPOSTA-SIVPF , :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-COD-EMPRESA-SIVPF , :PROPOFID-COD-PRODUTO-SIVPF END-EXEC. */

            if (TERMO_ADESAO.Fetch())
            {
                _.Move(TERMO_ADESAO.TERMOADE_NUM_TERMO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_APOLICE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE);
                _.Move(TERMO_ADESAO.VGACOTER_NUM_CERTIFICADO, VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO);
                _.Move(TERMO_ADESAO.VGACOTER_OCORR_HISTORICO, VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_OCORR_HISTORICO);
                _.Move(TERMO_ADESAO.VGACOTER_COD_DEVOLUCAO, VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_COD_DEVOLUCAO);
                _.Move(TERMO_ADESAO.VGACOTER_COD_OPERACAO, VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_COD_OPERACAO);
                _.Move(TERMO_ADESAO.VGACOTER_DATA_MOVIMENTO, VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_DATA_MOVIMENTO);
                _.Move(TERMO_ADESAO.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(TERMO_ADESAO.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(TERMO_ADESAO.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(TERMO_ADESAO.PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(TERMO_ADESAO.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -504- EXEC SQL CLOSE TERMO-ADESAO END-EXEC */

            TERMO_ADESAO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -537- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -539- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -542- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -545- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -548- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-SQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -549- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -550- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -551- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -554- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -557- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -560- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -560- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -570- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -572- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -573- IF VGACOTER-NUM-CERTIFICADO GREATER 10000000000 */

            if (VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO > 10000000000)
            {

                /*" -574- IF VGACOTER-NUM-CERTIFICADO LESS 19999999999 */

                if (VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO < 19999999999)
                {

                    /*" -575- DISPLAY 'PF0715B - TERMINO ANORMAL / FAIXA 10000000000' */
                    _.Display($"PF0715B - TERMINO ANORMAL / FAIXA 10000000000");

                    /*" -577- DISPLAY '          TERMO/PROPOSTA DESPREZADA ==>  ' TERMOADE-NUM-TERMO '  ' VGACOTER-NUM-CERTIFICADO */

                    $"          TERMO/PROPOSTA DESPREZADA ==>  {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  {VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO}"
                    .Display();

                    /*" -578- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -580- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -582- PERFORM R0230-00-LER-PROPOSTAVA. */

            R0230_00_LER_PROPOSTAVA_SECTION();

            /*" -583- IF PROPOSTAVA-NAO-CADASTRADA */

            if (WAREA_AUXILIAR.W_PROPOSTAVA["PROPOSTAVA_NAO_CADASTRADA"])
            {

                /*" -584- DISPLAY 'PF0715B - PROPOSTAVA NAO CADASTRADA' */
                _.Display($"PF0715B - PROPOSTAVA NAO CADASTRADA");

                /*" -586- DISPLAY '          TERMO/PROPOSTA DESPREZADA ==>  ' TERMOADE-NUM-TERMO '  ' VGACOTER-NUM-CERTIFICADO */

                $"          TERMO/PROPOSTA DESPREZADA ==>  {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  {VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO}"
                .Display();

                /*" -587- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -589- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -595- INITIALIZE REG-STA-PROPOSTA REG-APOL-SASSE REG-COBER-SASSE REG-PGTO-SASSE R5-REG-QTDE-VIDAS-VE. */
            _.Initialize(
                LBFCT011.REG_STA_PROPOSTA
                , LBFCT016.REG_APOL_SASSE
                , LBFCT016.REG_COBER_SASSE
                , LBFCT016.REG_PGTO_SASSE
                , LBFPF200.R5_REG_QTDE_VIDAS_VE
            );

            /*" -597- PERFORM R0290-00-DEFINIR-SIT-MOTIVO */

            R0290_00_DEFINIR_SIT_MOTIVO_SECTION();

            /*" -599- PERFORM R0580-00-LER-HIST-FIDELIZ */

            R0580_00_LER_HIST_FIDELIZ_SECTION();

            /*" -600- IF HISTORICO-CADASTRADO */

            if (WAREA_AUXILIAR.W_HISTORICO["HISTORICO_CADASTRADO"])
            {

                /*" -601- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -604- DISPLAY 'PF0715B - MOVIMENTO GERADO ANTERIORMENTE ====> ' TERMOADE-NUM-TERMO '  ' VGACOTER-NUM-CERTIFICADO '  ' VGACOTER-COD-OPERACAO */

                $"PF0715B - MOVIMENTO GERADO ANTERIORMENTE ====> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  {VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO}  {VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_COD_OPERACAO}"
                .Display();

                /*" -606- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -612- MOVE 1 TO W-IND-NIVEL. */
            _.Move(1, WAREA_AUXILIAR.W_IND_NIVEL);

            /*" -616- PERFORM R0800-00-STATUS-REGISTRO-TP1 */

            R0800_00_STATUS_REGISTRO_TP1_SECTION();

            /*" -617- IF R1-SIT-PROPOSTA OF REG-STA-PROPOSTA EQUAL 'REJ' */

            if (LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA == "REJ")
            {

                /*" -622- MOVE ZERO TO W-TEM-HISTORICO */
                _.Move(0, WAREA_AUXILIAR.W_TEM_HISTORICO);

                /*" -623- PERFORM R0980-00-LER-H-PROP-FIDEL */

                R0980_00_LER_H_PROP_FIDEL_SECTION();

                /*" -624- IF TEM-HISTORICO */

                if (WAREA_AUXILIAR.W_TEM_HISTORICO["TEM_HISTORICO"])
                {

                    /*" -625- GO TO R0150-05 */

                    R0150_05(); //GOTO
                    return;

                    /*" -627- END-IF */
                }


                /*" -632- MOVE ZERO TO W-TEM-HISTORICO */
                _.Move(0, WAREA_AUXILIAR.W_TEM_HISTORICO);

                /*" -633- PERFORM R0985-00-LER-H-PROP-FIDEL */

                R0985_00_LER_H_PROP_FIDEL_SECTION();

                /*" -634- IF NAO-TEM-HISTORICO */

                if (WAREA_AUXILIAR.W_TEM_HISTORICO["NAO_TEM_HISTORICO"])
                {

                    /*" -635- GO TO R0150-05 */

                    R0150_05(); //GOTO
                    return;

                    /*" -637- END-IF */
                }


                /*" -639- INITIALIZE R8-PONTUACAO-SIDEM */
                _.Initialize(
                    LBFPF025.R8_PONTUACAO_SIDEM
                );

                /*" -641- PERFORM R0990-00-OBTER-PRM-PAGO */

                R0990_00_OBTER_PRM_PAGO_SECTION();

                /*" -642- IF R8-VLR-LANCAMENTO EQUAL ZEROS */

                if (LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO == 00)
                {

                    /*" -643- PERFORM R0992-00-OBTER-PRM-PAGO */

                    R0992_00_OBTER_PRM_PAGO_SECTION();

                    /*" -645- END-IF */
                }


                /*" -645- PERFORM R0995-00-GERAR-REGISTRO-TP8. */

                R0995_00_GERAR_REGISTRO_TP8_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0150_05 */

            R0150_05();

        }

        [StopWatch]
        /*" R0150-05 */
        private void R0150_05(bool isPerform = false)
        {
            /*" -650- PERFORM R3390-GERA-HIST-FIDELIZACAO */

            R3390_GERA_HIST_FIDELIZACAO_SECTION();

            /*" -650- PERFORM R3400-00-ATUALIZA-PROPOSTA. */

            R3400_00_ATUALIZA_PROPOSTA_SECTION();

        }

        [StopWatch]
        /*" R0150-LEITURA */
        private void R0150_LEITURA(bool isPerform = false)
        {
            /*" -679- IF W-FIM-MOVTO-TERMO NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO != "FIM")
            {

                /*" -679- PERFORM R0070-00-LER-MOVTO. */

                R0070_00_LER_MOVTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0230-00-LER-PROPOSTAVA-SECTION */
        private void R0230_00_LER_PROPOSTAVA_SECTION()
        {
            /*" -689- MOVE 'R0210-00-LER-PROPOSTAVA' TO PARAGRAFO. */
            _.Move("R0210-00-LER-PROPOSTAVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -691- MOVE 'SELECT PROPOSTAS-VA' TO COMANDO. */
            _.Move("SELECT PROPOSTAS-VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -693- MOVE VGACOTER-NUM-CERTIFICADO TO PROPOVA-NUM-CERTIFICADO. */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -703- PERFORM R0230_00_LER_PROPOSTAVA_DB_SELECT_1 */

            R0230_00_LER_PROPOSTAVA_DB_SELECT_1();

            /*" -706- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -707- MOVE 1 TO W-PROPOSTAVA */
                _.Move(1, WAREA_AUXILIAR.W_PROPOSTAVA);

                /*" -708- ELSE */
            }
            else
            {


                /*" -709- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -710- MOVE 2 TO W-PROPOSTAVA */
                    _.Move(2, WAREA_AUXILIAR.W_PROPOSTAVA);

                    /*" -711- ELSE */
                }
                else
                {


                    /*" -712- DISPLAY 'PF0715B - FIM ANORMAL' */
                    _.Display($"PF0715B - FIM ANORMAL");

                    /*" -713- DISPLAY '          ERRO SELECT PROPOSTAS_VA' */
                    _.Display($"          ERRO SELECT PROPOSTAS_VA");

                    /*" -716- DISPLAY '          NUMERO PROPOSTA........ ' PROPOVA-NUM-CERTIFICADO '  ' SQLCODE */

                    $"          NUMERO PROPOSTA........ {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}  {DB.SQLCODE}"
                    .Display();

                    /*" -717- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -717- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0230-00-LER-PROPOSTAVA-DB-SELECT-1 */
        public void R0230_00_LER_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -703- EXEC SQL SELECT DATA_QUITACAO, NUM_PARCELA, SIT_REGISTRO INTO :PROPOVA-DATA-QUITACAO, :PROPOVA-NUM-PARCELA, :PROPOVA-SIT-REGISTRO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0230_00_LER_PROPOSTAVA_DB_SELECT_1_Query1 = new R0230_00_LER_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0230_00_LER_PROPOSTAVA_DB_SELECT_1_Query1.Execute(r0230_00_LER_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(executed_1.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_SAIDA*/

        [StopWatch]
        /*" R0290-00-DEFINIR-SIT-MOTIVO-SECTION */
        private void R0290_00_DEFINIR_SIT_MOTIVO_SECTION()
        {
            /*" -726- MOVE 'R0290-00-DEFINIR-SIT-MOTIVO' TO PARAGRAFO. */
            _.Move("R0290-00-DEFINIR-SIT-MOTIVO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -728- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -730- IF VGACOTER-COD-OPERACAO LESS 400 OR VGACOTER-COD-OPERACAO GREATER 599 */

            if (VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_COD_OPERACAO < 400 || VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_COD_OPERACAO > 599)
            {

                /*" -731- DISPLAY 'PF0715B - FIM ANORMAL' */
                _.Display($"PF0715B - FIM ANORMAL");

                /*" -732- DISPLAY '          OPERACAO NAO ESPERADA' */
                _.Display($"          OPERACAO NAO ESPERADA");

                /*" -735- DISPLAY '          CERTIFICADO / TEMO .. ' VGACOTER-NUM-CERTIFICADO '  ' TERMOADE-NUM-TERMO */

                $"          CERTIFICADO / TEMO .. {VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO}  {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}"
                .Display();

                /*" -736- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -738- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -739- IF VGACOTER-COD-OPERACAO GREATER 499 AND LESS 600 */

            if (VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_COD_OPERACAO > 499 && VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_COD_OPERACAO < 600)
            {

                /*" -741- MOVE 'RTV' TO R1-SIT-PROPOSTA OF REG-STA-PROPOSTA */
                _.Move("RTV", LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

                /*" -744- MOVE 675 TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA */
                _.Move(675, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);

                /*" -747- GO TO R0290-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_SAIDA*/ //GOTO
                return;
            }


            /*" -748- IF VGACOTER-COD-OPERACAO GREATER 399 AND LESS 499 */

            if (VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_COD_OPERACAO > 399 && VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_COD_OPERACAO < 499)
            {

                /*" -751- MOVE 'REJ' TO R1-SIT-PROPOSTA OF REG-STA-PROPOSTA */
                _.Move("REJ", LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

                /*" -753- PERFORM R0300-00-OBTER-MOTIVO-VD */

                R0300_00_OBTER_MOTIVO_VD_SECTION();

                /*" -754- MOVE PF037-SIT-MOTIVO-SIVPF TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA. */
                _.Move(PF037.DCLPF_ERRO_DEVOLUCAO.PF037_SIT_MOTIVO_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_SAIDA*/

        [StopWatch]
        /*" R0300-00-OBTER-MOTIVO-VD-SECTION */
        private void R0300_00_OBTER_MOTIVO_VD_SECTION()
        {
            /*" -764- MOVE 'R0300-00-OBTER-MOTIVO-VD' TO PARAGRAFO. */
            _.Move("R0300-00-OBTER-MOTIVO-VD", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -766- MOVE 'SELECT PF_ERRO_DEVOLUCAO' TO COMANDO. */
            _.Move("SELECT PF_ERRO_DEVOLUCAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -768- MOVE VGACOTER-COD-DEVOLUCAO TO PF037-COD-DEVOLUCAO */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_COD_DEVOLUCAO, PF037.DCLPF_ERRO_DEVOLUCAO.PF037_COD_DEVOLUCAO);

            /*" -774- PERFORM R0300_00_OBTER_MOTIVO_VD_DB_SELECT_1 */

            R0300_00_OBTER_MOTIVO_VD_DB_SELECT_1();

            /*" -777- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -777- MOVE 209 TO PF037-SIT-MOTIVO-SIVPF. */
                _.Move(209, PF037.DCLPF_ERRO_DEVOLUCAO.PF037_SIT_MOTIVO_SIVPF);
            }


        }

        [StopWatch]
        /*" R0300-00-OBTER-MOTIVO-VD-DB-SELECT-1 */
        public void R0300_00_OBTER_MOTIVO_VD_DB_SELECT_1()
        {
            /*" -774- EXEC SQL SELECT SIT_MOTIVO_SIVPF INTO :PF037-SIT-MOTIVO-SIVPF FROM SEGUROS.PF_ERRO_DEVOLUCAO WHERE COD_DEVOLUCAO = :PF037-COD-DEVOLUCAO WITH UR END-EXEC. */

            var r0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1 = new R0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1()
            {
                PF037_COD_DEVOLUCAO = PF037.DCLPF_ERRO_DEVOLUCAO.PF037_COD_DEVOLUCAO.ToString(),
            };

            var executed_1 = R0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1.Execute(r0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PF037_SIT_MOTIVO_SIVPF, PF037.DCLPF_ERRO_DEVOLUCAO.PF037_SIT_MOTIVO_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-SECTION */
        private void R0450_00_OBTER_COBERTURA_SECTION()
        {
            /*" -787- MOVE 'R0450-00-OBTER-COBERTURA' TO PARAGRAFO. */
            _.Move("R0450-00-OBTER-COBERTURA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -789- MOVE 'SELECT COBERPROPVA' TO COMANDO. */
            _.Move("SELECT COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -790- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO HISCOBPR-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);

            /*" -792- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA */
            _.Move("9999-12-31", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

            /*" -794- MOVE 2 TO W-COBERTURAS */
            _.Move(2, WAREA_AUXILIAR.W_COBERTURAS);

            /*" -808- PERFORM R0450_00_OBTER_COBERTURA_DB_DECLARE_1 */

            R0450_00_OBTER_COBERTURA_DB_DECLARE_1();

            /*" -810- PERFORM R0450_00_OBTER_COBERTURA_DB_OPEN_1 */

            R0450_00_OBTER_COBERTURA_DB_OPEN_1();

            /*" -813- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -814- DISPLAY 'PF0715B - FIM ANORMAL' */
                _.Display($"PF0715B - FIM ANORMAL");

                /*" -815- DISPLAY '          ERRO OPEN DO CURSOR COBERTURAS' */
                _.Display($"          ERRO OPEN DO CURSOR COBERTURAS");

                /*" -817- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -819- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -821- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -822- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -824- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -834- PERFORM R0450_00_OBTER_COBERTURA_DB_FETCH_1 */

            R0450_00_OBTER_COBERTURA_DB_FETCH_1();

            /*" -837- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -838- DISPLAY 'PF0715B - FIM ANORMAL' */
                _.Display($"PF0715B - FIM ANORMAL");

                /*" -839- DISPLAY '          ERRO FETCH DO CURSOR COBERTURAS' */
                _.Display($"          ERRO FETCH DO CURSOR COBERTURAS");

                /*" -841- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -843- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -845- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -846- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -848- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -848- PERFORM R0450_00_OBTER_COBERTURA_DB_CLOSE_1 */

            R0450_00_OBTER_COBERTURA_DB_CLOSE_1();

            /*" -851- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -852- DISPLAY 'PF0715B - FIM ANORMAL' */
                _.Display($"PF0715B - FIM ANORMAL");

                /*" -853- DISPLAY '          ERRO CLOSE DO CURSOR COBERTURAS' */
                _.Display($"          ERRO CLOSE DO CURSOR COBERTURAS");

                /*" -855- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -857- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -859- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -860- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -862- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -862- MOVE 1 TO W-COBERTURAS. */
            _.Move(1, WAREA_AUXILIAR.W_COBERTURAS);

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-OPEN-1 */
        public void R0450_00_OBTER_COBERTURA_DB_OPEN_1()
        {
            /*" -810- EXEC SQL OPEN COBERTURAS END-EXEC. */

            COBERTURAS.Open();

        }

        [StopWatch]
        /*" R0710-OBTER-NIVEL-EMPRESA-DB-DECLARE-1 */
        public void R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1()
        {
            /*" -945- EXEC SQL DECLARE TER-NIVEL CURSOR FOR SELECT NUM_PROPOSTA_SIVPF, DTH_INI_VIGENCIA , NUM_NIVEL_CARGO , DTH_FIM_VIGENCIA , IMP_SEGURADA , VLR_PRM_INDIVIDUAL, QTD_VIDAS FROM SEGUROS.VG_TERMO_NIVEL WHERE NUM_PROPOSTA_SIVPF = :VGTERNIV-NUM-PROPOSTA-SIVPF AND DTH_FIM_VIGENCIA = :VGTERNIV-DTH-FIM-VIGENCIA ORDER BY NUM_NIVEL_CARGO WITH UR END-EXEC. */
            TER_NIVEL = new PF0715B_TER_NIVEL(true);
            string GetQuery_TER_NIVEL()
            {
                var query = @$"SELECT 
							NUM_PROPOSTA_SIVPF
							, 
							DTH_INI_VIGENCIA
							, 
							NUM_NIVEL_CARGO
							, 
							DTH_FIM_VIGENCIA
							, 
							IMP_SEGURADA
							, 
							VLR_PRM_INDIVIDUAL
							, 
							QTD_VIDAS 
							FROM 
							SEGUROS.VG_TERMO_NIVEL 
							WHERE 
							NUM_PROPOSTA_SIVPF = '{VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}' 
							AND DTH_FIM_VIGENCIA = '{VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA}' 
							ORDER BY NUM_NIVEL_CARGO";

                return query;
            }
            TER_NIVEL.GetQueryEvent += GetQuery_TER_NIVEL;

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-FETCH-1 */
        public void R0450_00_OBTER_COBERTURA_DB_FETCH_1()
        {
            /*" -834- EXEC SQL FETCH COBERTURAS INTO :HISCOBPR-NUM-CERTIFICADO , :HISCOBPR-OCORR-HISTORICO , :HISCOBPR-DATA-INIVIGENCIA , :HISCOBPR-DATA-TERVIGENCIA , :HISCOBPR-IMP-MORNATU , :HISCOBPR-IMPMORACID , :HISCOBPR-IMPINVPERM , :HISCOBPR-VLPREMIO END-EXEC. */

            if (COBERTURAS.Fetch())
            {
                _.Move(COBERTURAS.HISCOBPR_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);
                _.Move(COBERTURAS.HISCOBPR_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);
                _.Move(COBERTURAS.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(COBERTURAS.HISCOBPR_DATA_TERVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);
                _.Move(COBERTURAS.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(COBERTURAS.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
                _.Move(COBERTURAS.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);
                _.Move(COBERTURAS.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
            }

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-CLOSE-1 */
        public void R0450_00_OBTER_COBERTURA_DB_CLOSE_1()
        {
            /*" -848- EXEC SQL CLOSE COBERTURAS END-EXEC. */

            COBERTURAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_SAIDA*/

        [StopWatch]
        /*" R0580-00-LER-HIST-FIDELIZ-SECTION */
        private void R0580_00_LER_HIST_FIDELIZ_SECTION()
        {
            /*" -872- MOVE 'R0580-00-LER-HIST-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0580-00-LER-HIST-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -874- MOVE 'SELECT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("SELECT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -877- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO OF DCLHIST-PROP-FIDELIZ. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -880- MOVE R1-SIT-PROPOSTA OF REG-STA-PROPOSTA TO PROPFIDH-SIT-PROPOSTA OF DCLHIST-PROP-FIDELIZ */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -883- MOVE R1-SIT-MOTIVO OF REG-STA-PROPOSTA TO PROPFIDH-SIT-MOTIVO-SIVPF OF DCLHIST-PROP-FIDELIZ */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -886- MOVE VGACOTER-DATA-MOVIMENTO TO PROPFIDH-DATA-SITUACAO OF DCLHIST-PROP-FIDELIZ */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_DATA_MOVIMENTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -899- PERFORM R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1 */

            R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1();

            /*" -902- IF SQLCODE NOT EQUAL 00 AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -903- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -904- MOVE 2 TO W-HISTORICO */
                    _.Move(2, WAREA_AUXILIAR.W_HISTORICO);

                    /*" -905- ELSE */
                }
                else
                {


                    /*" -906- DISPLAY 'PF0715B - FIM ANORMAL' */
                    _.Display($"PF0715B - FIM ANORMAL");

                    /*" -907- DISPLAY '          ERRO ACESSO HIST-PROP-FIDELIZ' */
                    _.Display($"          ERRO ACESSO HIST-PROP-FIDELIZ");

                    /*" -909- DISPLAY '          NUMERO DA PROPOSTA.. ' VGACOTER-NUM-CERTIFICADO */
                    _.Display($"          NUMERO DA PROPOSTA.. {VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO}");

                    /*" -911- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -912- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -913- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -914- ELSE */
                }

            }
            else
            {


                /*" -914- MOVE 1 TO W-HISTORICO. */
                _.Move(1, WAREA_AUXILIAR.W_HISTORICO);
            }


        }

        [StopWatch]
        /*" R0580-00-LER-HIST-FIDELIZ-DB-SELECT-1 */
        public void R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1()
        {
            /*" -899- EXEC SQL SELECT NUM_IDENTIFICACAO INTO :DCLHIST-PROP-FIDELIZ.PROPFIDH-NUM-IDENTIFICACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :DCLHIST-PROP-FIDELIZ.PROPFIDH-NUM-IDENTIFICACAO AND DATA_SITUACAO = :DCLHIST-PROP-FIDELIZ.PROPFIDH-DATA-SITUACAO AND SIT_PROPOSTA = :DCLHIST-PROP-FIDELIZ.PROPFIDH-SIT-PROPOSTA AND SIT_MOTIVO_SIVPF = :DCLHIST-PROP-FIDELIZ.PROPFIDH-SIT-MOTIVO-SIVPF WITH UR END-EXEC. */

            var r0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1 = new R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_SIT_MOTIVO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.ToString(),
                PROPFIDH_DATA_SITUACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
            };

            var executed_1 = R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1.Execute(r0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0580_SAIDA*/

        [StopWatch]
        /*" R0710-OBTER-NIVEL-EMPRESA-SECTION */
        private void R0710_OBTER_NIVEL_EMPRESA_SECTION()
        {
            /*" -921- MOVE 'R0710-OBTER-NIVEL-EMPRESA  ' TO PARAGRAFO. */
            _.Move("R0710-OBTER-NIVEL-EMPRESA  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -923- MOVE 'DECLARE CURSOR TER-NIVEL' TO COMANDO. */
            _.Move("DECLARE CURSOR TER-NIVEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -924- MOVE VGACOTER-NUM-CERTIFICADO TO VGTERNIV-NUM-PROPOSTA-SIVPF */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF);

            /*" -925- MOVE '9999-12-31' TO VGTERNIV-DTH-FIM-VIGENCIA. */
            _.Move("9999-12-31", VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA);

            /*" -927- MOVE 'N' TO W-FIM-TERNIV. */
            _.Move("N", WAREA_AUXILIAR.W_FIM_TERNIV);

            /*" -945- PERFORM R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1 */

            R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1();

            /*" -949- MOVE 'OPEN CURSOR TER-NIVEL' TO COMANDO. */
            _.Move("OPEN CURSOR TER-NIVEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -949- PERFORM R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1 */

            R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1();

            /*" -952- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -955- DISPLAY 'PF0642E - ERRO NO OPEN DO CURSOR TER-NIVEL ' SQLCODE '  ' VGTERNIV-NUM-PROPOSTA-SIVPF '  ' VGTERNIV-DTH-FIM-VIGENCIA */

                $"PF0642E - ERRO NO OPEN DO CURSOR TER-NIVEL {DB.SQLCODE}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA}"
                .Display();

                /*" -956- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -956- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0710-OBTER-NIVEL-EMPRESA-DB-OPEN-1 */
        public void R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1()
        {
            /*" -949- EXEC SQL OPEN TER-NIVEL END-EXEC. */

            TER_NIVEL.Open();

        }

        [StopWatch]
        /*" R0990-00-OBTER-PRM-PAGO-DB-DECLARE-1 */
        public void R0990_00_OBTER_PRM_PAGO_DB_DECLARE_1()
        {
            /*" -1381- EXEC SQL DECLARE PAGAMENTO CURSOR FOR SELECT NUM_CERTIFICADO, NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO, NUM_APOLICE , COD_SUBGRUPO , PREMIO_VG , PREMIO_AP , COD_OPERACAO FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND COD_OPERACAO > 199 AND COD_OPERACAO < 300 WITH UR END-EXEC. */
            PAGAMENTO = new PF0715B_PAGAMENTO(true);
            string GetQuery_PAGAMENTO()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							NUM_PARCELA
							, 
							NUM_TITULO
							, 
							OCORR_HISTORICO
							, 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							PREMIO_VG
							, 
							PREMIO_AP
							, 
							COD_OPERACAO 
							FROM SEGUROS.HIST_CONT_PARCELVA 
							WHERE NUM_CERTIFICADO = 
							'{HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}' 
							AND COD_OPERACAO > 199 
							AND COD_OPERACAO < 300";

                return query;
            }
            PAGAMENTO.GetQueryEvent += GetQuery_PAGAMENTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_SAIDA*/

        [StopWatch]
        /*" R0715-FETCH-NIVEL-EMPRESA-SECTION */
        private void R0715_FETCH_NIVEL_EMPRESA_SECTION()
        {
            /*" -963- MOVE 'R0715-FETCH-NIVEL-EMPRESA' TO PARAGRAFO. */
            _.Move("R0715-FETCH-NIVEL-EMPRESA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -965- MOVE 'FETCH CURSOR TER-NIVEL' TO COMANDO. */
            _.Move("FETCH CURSOR TER-NIVEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -975- PERFORM R0715_FETCH_NIVEL_EMPRESA_DB_FETCH_1 */

            R0715_FETCH_NIVEL_EMPRESA_DB_FETCH_1();

            /*" -978- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -979- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -980- IF W-IND-NIVEL EQUAL 1 */

                    if (WAREA_AUXILIAR.W_IND_NIVEL == 1)
                    {

                        /*" -982- DISPLAY 'PF0642E - FIM ANORMAL - NIVEL NAO CADASTRADO ' VGACOTER-NUM-CERTIFICADO */
                        _.Display($"PF0642E - FIM ANORMAL - NIVEL NAO CADASTRADO {VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO}");

                        /*" -983- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -984- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -985- ELSE */
                    }
                    else
                    {


                        /*" -986- MOVE 'S' TO W-FIM-TERNIV */
                        _.Move("S", WAREA_AUXILIAR.W_FIM_TERNIV);

                        /*" -986- PERFORM R0715_FETCH_NIVEL_EMPRESA_DB_CLOSE_1 */

                        R0715_FETCH_NIVEL_EMPRESA_DB_CLOSE_1();

                        /*" -988- IF SQLCODE NOT EQUAL ZEROS */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -991- DISPLAY 'PF0642E - ERRO CLOSE DO CURSOR TER-NIVEL ' SQLCODE '  ' VGTERNIV-NUM-PROPOSTA-SIVPF '  ' VGTERNIV-DTH-FIM-VIGENCIA */

                            $"PF0642E - ERRO CLOSE DO CURSOR TER-NIVEL {DB.SQLCODE}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA}"
                            .Display();

                            /*" -992- PERFORM R9988-00-FECHAR-ARQUIVOS */

                            R9988_00_FECHAR_ARQUIVOS_SECTION();

                            /*" -993- PERFORM R9999-00-FINALIZAR */

                            R9999_00_FINALIZAR_SECTION();

                            /*" -995- ELSE NEXT SENTENCE */
                        }
                        else
                        {


                            /*" -996- ELSE */
                        }

                    }

                }
                else
                {


                    /*" -999- DISPLAY 'PF0642E - ERRO NO FETCH DO CURSOR TER-NIVEL ' SQLCODE '  ' VGTERNIV-NUM-PROPOSTA-SIVPF '  ' VGTERNIV-DTH-FIM-VIGENCIA */

                    $"PF0642E - ERRO NO FETCH DO CURSOR TER-NIVEL {DB.SQLCODE}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA}"
                    .Display();

                    /*" -1000- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1000- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0715-FETCH-NIVEL-EMPRESA-DB-FETCH-1 */
        public void R0715_FETCH_NIVEL_EMPRESA_DB_FETCH_1()
        {
            /*" -975- EXEC SQL FETCH TER-NIVEL INTO :VGTERNIV-NUM-PROPOSTA-SIVPF, :VGTERNIV-DTH-INI-VIGENCIA , :VGTERNIV-NUM-NIVEL-CARGO , :VGTERNIV-DTH-FIM-VIGENCIA , :VGTERNIV-IMP-SEGURADA , :VGTERNIV-VLR-PRM-INDIVIDUAL, :VGTERNIV-QTD-VIDAS END-EXEC. */

            if (TER_NIVEL.Fetch())
            {
                _.Move(TER_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF);
                _.Move(TER_NIVEL.VGTERNIV_DTH_INI_VIGENCIA, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA);
                _.Move(TER_NIVEL.VGTERNIV_NUM_NIVEL_CARGO, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_NIVEL_CARGO);
                _.Move(TER_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA);
                _.Move(TER_NIVEL.VGTERNIV_IMP_SEGURADA, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_IMP_SEGURADA);
                _.Move(TER_NIVEL.VGTERNIV_VLR_PRM_INDIVIDUAL, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_VLR_PRM_INDIVIDUAL);
                _.Move(TER_NIVEL.VGTERNIV_QTD_VIDAS, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_QTD_VIDAS);
            }

        }

        [StopWatch]
        /*" R0715-FETCH-NIVEL-EMPRESA-DB-CLOSE-1 */
        public void R0715_FETCH_NIVEL_EMPRESA_DB_CLOSE_1()
        {
            /*" -986- EXEC SQL CLOSE TER-NIVEL END-EXEC */

            TER_NIVEL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0715_SAIDA*/

        [StopWatch]
        /*" R0720-MONTA-NIVEL-CARGO-SECTION */
        private void R0720_MONTA_NIVEL_CARGO_SECTION()
        {
            /*" -1007- MOVE 'R0720-MONTA-NIVEL-CARGO' TO PARAGRAFO. */
            _.Move("R0720-MONTA-NIVEL-CARGO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1009- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1010- IF W-IND-NIVEL LESS 5 */

            if (WAREA_AUXILIAR.W_IND_NIVEL < 5)
            {

                /*" -1013- MOVE VGTERNIV-NUM-NIVEL-CARGO TO R5-NUM-NIVEL-CARGO (W-IND-NIVEL) */
                _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_NIVEL_CARGO, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_NOVO.R5_DADOS_NIVEL[WAREA_AUXILIAR.W_IND_NIVEL].R5_NUM_NIVEL_CARGO);

                /*" -1016- MOVE VGTERNIV-IMP-SEGURADA TO R5-IMP-SEGURADA (W-IND-NIVEL) */
                _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_IMP_SEGURADA, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_NOVO.R5_DADOS_NIVEL[WAREA_AUXILIAR.W_IND_NIVEL].R5_IMP_SEGURADA);

                /*" -1019- MOVE VGTERNIV-QTD-VIDAS TO R5-QUANTIDADE-VIDAS (W-IND-NIVEL). */
                _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_QTD_VIDAS, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_NOVO.R5_DADOS_NIVEL[WAREA_AUXILIAR.W_IND_NIVEL].R5_QUANTIDADE_VIDAS);
            }


            /*" -1020- IF W-IND-NIVEL GREATER 5 */

            if (WAREA_AUXILIAR.W_IND_NIVEL > 5)
            {

                /*" -1022- DISPLAY 'PF0642E - FIM ANORMAL, ESTOURO DE NIVEIS  ' SQLCODE '  ' VGTERNIV-NUM-PROPOSTA-SIVPF */

                $"PF0642E - FIM ANORMAL, ESTOURO DE NIVEIS  {DB.SQLCODE}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}"
                .Display();

                /*" -1023- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1025- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1025- ADD 1 TO W-IND-NIVEL. */
            WAREA_AUXILIAR.W_IND_NIVEL.Value = WAREA_AUXILIAR.W_IND_NIVEL + 1;

            /*" -0- FLUXCONTROL_PERFORM R0720_NEXT */

            R0720_NEXT();

        }

        [StopWatch]
        /*" R0720-NEXT */
        private void R0720_NEXT(bool isPerform = false)
        {
            /*" -1029- PERFORM R0715-FETCH-NIVEL-EMPRESA. */

            R0715_FETCH_NIVEL_EMPRESA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0720_SAIDA*/

        [StopWatch]
        /*" R0800-00-STATUS-REGISTRO-TP1-SECTION */
        private void R0800_00_STATUS_REGISTRO_TP1_SECTION()
        {
            /*" -1041- MOVE 'R0800-00-STATUS-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0800-00-STATUS-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1044- MOVE '1' TO R1-TIPO-REG OF REG-STA-PROPOSTA. */
            _.Move("1", LBFCT011.REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -1047- MOVE VGACOTER-NUM-CERTIFICADO TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -1050- MOVE VGACOTER-DATA-MOVIMENTO TO W-DATA-SQL. */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1051- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -1052- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -1054- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -1057- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -1059- ADD 1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + 1;

            /*" -1062- MOVE RH-NSAS OF REG-HEADER-STA TO R1-NSAS OF REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, LBFCT011.REG_STA_PROPOSTA.R1_NSAS);

            /*" -1065- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO R1-NSL OF REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, LBFCT011.REG_STA_PROPOSTA.R1_NSL);

            /*" -1065- WRITE REG-STA-SASSE FROM REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-STATUS-REGISTRO-TP2-SECTION */
        private void R0850_00_STATUS_REGISTRO_TP2_SECTION()
        {
            /*" -1076- MOVE 'R0850-00-STATUS-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0850-00-STATUS-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1079- MOVE '2' TO R2-TIPO-REG OF REG-APOL-SASSE */
            _.Move("2", LBFCT016.REG_APOL_SASSE.R2_TIPO_REG);

            /*" -1083- MOVE VGACOTER-NUM-CERTIFICADO TO R2-NUM-PROPOSTA OF REG-APOL-SASSE R2-NRCERTIF OF REG-APOL-SASSE. */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO, LBFCT016.REG_APOL_SASSE.R2_NUM_PROPOSTA, LBFCT016.REG_APOL_SASSE.R2_NRCERTIF);

            /*" -1086- MOVE VGTERNIV-DTH-INI-VIGENCIA TO W-DATA-SQL. */
            _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1087- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -1088- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -1090- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -1093- MOVE W-DATA-TRABALHO TO R2-DTINIVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTINIVIG);

            /*" -1096- MOVE VGTERNIV-DTH-FIM-VIGENCIA TO W-DATA-SQL. */
            _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1097- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -1098- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -1100- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -1103- MOVE W-DATA-TRABALHO TO R2-DTTERVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTTERVIG);

            /*" -1104- PERFORM R0860-LER-APOLICE */

            R0860_LER_APOLICE_SECTION();

            /*" -1106- PERFORM R0870-LER-RAMOIND */

            R0870_LER_RAMOIND_SECTION();

            /*" -1108- COMPUTE W-IND-IOF = (RAMOCOMP-PCT-IOCC-RAMO / 100) + 1 */
            WAREA_AUXILIAR.W_IND_IOF.Value = (RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f) + 1;

            /*" -1110- COMPUTE W-PRM-LIQ = HISCOBPR-VLPREMIO / W-IND-IOF */
            WAREA_AUXILIAR.W_PRM_LIQ.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO / WAREA_AUXILIAR.W_IND_IOF;

            /*" -1113- COMPUTE R2-VAL-IOF OF REG-APOL-SASSE ROUNDED = HISCOBPR-VLPREMIO - W-PRM-LIQ */
            LBFCT016.REG_APOL_SASSE.R2_VAL_IOF.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO - WAREA_AUXILIAR.W_PRM_LIQ;

            /*" -1115- MOVE W-PRM-LIQ TO R2-VAL-PREMIO OF REG-APOL-SASSE */
            _.Move(WAREA_AUXILIAR.W_PRM_LIQ, LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO);

            /*" -1117- ADD 1 TO RT-QTDE-TIPO-2 OF REG-TRAILLER-STA */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + 1;

            /*" -1117- WRITE REG-STA-SASSE FROM REG-APOL-SASSE. */
            _.Move(LBFCT016.REG_APOL_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R0860-LER-APOLICE-SECTION */
        private void R0860_LER_APOLICE_SECTION()
        {
            /*" -1127- MOVE 'R0860-00-LER-APOLICE' TO PARAGRAFO. */
            _.Move("R0860-00-LER-APOLICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1129- MOVE 'SELECT TABELA APOLICE' TO COMANDO. */
            _.Move("SELECT TABELA APOLICE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1131- MOVE TERMOADE-NUM-APOLICE TO APOLICES-NUM-APOLICE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -1139- PERFORM R0860_LER_APOLICE_DB_SELECT_1 */

            R0860_LER_APOLICE_DB_SELECT_1();

            /*" -1142- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1143- DISPLAY 'PF0715B - FIM ANORMAL' */
                _.Display($"PF0715B - FIM ANORMAL");

                /*" -1144- DISPLAY '          ERRO SELECT TABELA APOLICE' */
                _.Display($"          ERRO SELECT TABELA APOLICE");

                /*" -1146- DISPLAY '          NUMERO DO TERMO ADESAO.... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO.... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1148- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -1149- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1149- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0860-LER-APOLICE-DB-SELECT-1 */
        public void R0860_LER_APOLICE_DB_SELECT_1()
        {
            /*" -1139- EXEC SQL SELECT RAMO_EMISSOR INTO :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE WITH UR END-EXEC. */

            var r0860_LER_APOLICE_DB_SELECT_1_Query1 = new R0860_LER_APOLICE_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0860_LER_APOLICE_DB_SELECT_1_Query1.Execute(r0860_LER_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0860_SAIDA*/

        [StopWatch]
        /*" R0870-LER-RAMOIND-SECTION */
        private void R0870_LER_RAMOIND_SECTION()
        {
            /*" -1159- MOVE 'R0870-00-LER-RAMOIND' TO PARAGRAFO. */
            _.Move("R0870-00-LER-RAMOIND", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1161- MOVE 'SELECT TABELA RAMOIND' TO COMANDO. */
            _.Move("SELECT TABELA RAMOIND", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1171- PERFORM R0870_LER_RAMOIND_DB_SELECT_1 */

            R0870_LER_RAMOIND_DB_SELECT_1();

            /*" -1174- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1175- DISPLAY 'PF0715B - FIM ANORMAL' */
                _.Display($"PF0715B - FIM ANORMAL");

                /*" -1176- DISPLAY '          ERRO SELECT TAB. RAMO COMPLEMENTAR' */
                _.Display($"          ERRO SELECT TAB. RAMO COMPLEMENTAR");

                /*" -1178- DISPLAY '          NUMERO DO TERMO ADESAO.... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO.... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1180- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -1181- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1181- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0870-LER-RAMOIND-DB-SELECT-1 */
        public void R0870_LER_RAMOIND_DB_SELECT_1()
        {
            /*" -1171- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR AND DATA_INIVIGENCIA <= :VGTERNIV-DTH-INI-VIGENCIA AND DATA_TERVIGENCIA >= :VGTERNIV-DTH-INI-VIGENCIA WITH UR END-EXEC. */

            var r0870_LER_RAMOIND_DB_SELECT_1_Query1 = new R0870_LER_RAMOIND_DB_SELECT_1_Query1()
            {
                VGTERNIV_DTH_INI_VIGENCIA = VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R0870_LER_RAMOIND_DB_SELECT_1_Query1.Execute(r0870_LER_RAMOIND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0870_SAIDA*/

        [StopWatch]
        /*" R0900-00-STATUS-REGISTRO-TP3-SECTION */
        private void R0900_00_STATUS_REGISTRO_TP3_SECTION()
        {
            /*" -1192- MOVE 'R0900-00-STATUS-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0900-00-STATUS-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1195- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -1198- MOVE VGACOTER-NUM-CERTIFICADO TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -1200- MOVE PROPOFID-COD-PRODUTO-SIVPF TO W-SUBPRODUTO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, WAREA_AUXILIAR.FILLER_1.W_SUBPRODUTO);

            /*" -1201- IF HISCOBPR-IMP-MORNATU GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU > 00)
            {

                /*" -1203- MOVE HISCOBPR-IMP-MORNATU TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -1204- MOVE 1 TO W-COBERTURA */
                _.Move(1, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                /*" -1206- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -1208- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -1210- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -1211- IF HISCOBPR-IMPMORACID GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID > 00)
            {

                /*" -1213- MOVE HISCOBPR-IMPMORACID TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -1214- MOVE 2 TO W-COBERTURA */
                _.Move(2, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                /*" -1216- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -1218- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -1220- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -1221- IF HISCOBPR-IMPINVPERM GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM > 00)
            {

                /*" -1223- MOVE HISCOBPR-IMPINVPERM TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -1224- MOVE 3 TO W-COBERTURA */
                _.Move(3, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                /*" -1226- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -1228- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -1228- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_SAIDA*/

        [StopWatch]
        /*" R0950-00-STATUS-REGISTRO-TP4-SECTION */
        private void R0950_00_STATUS_REGISTRO_TP4_SECTION()
        {
            /*" -1239- MOVE 'R0990-00-STATUS-REGISTRO-TP4' TO PARAGRAFO. */
            _.Move("R0990-00-STATUS-REGISTRO-TP4", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1242- MOVE '4' TO R4-TIPO-REG OF REG-PGTO-SASSE. */
            _.Move("4", LBFCT016.REG_PGTO_SASSE.R4_TIPO_REG);

            /*" -1245- MOVE VGACOTER-NUM-CERTIFICADO TO R4-NUM-PROPOSTA OF REG-PGTO-SASSE. */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO, LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA);

            /*" -1246- IF VGACOTER-COD-OPERACAO GREATER 399 AND LESS 500 */

            if (VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_COD_OPERACAO > 399 && VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_COD_OPERACAO < 500)
            {

                /*" -1248- MOVE VGACOTER-DATA-MOVIMENTO TO W-DATA-SQL */
                _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -1249- ELSE */
            }
            else
            {


                /*" -1252- MOVE PROPOVA-DATA-QUITACAO TO W-DATA-SQL. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);
            }


            /*" -1253- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -1254- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -1256- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -1259- MOVE W-DATA-TRABALHO TO R4-DATA-SITUACAO OF REG-PGTO-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO);

            /*" -1262- MOVE PROPOVA-NUM-PARCELA TO R4-PARCELAS-PAGAS OF REG-PGTO-SASSE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA, LBFCT016.REG_PGTO_SASSE.R4_PARCELAS_PAGAS);

            /*" -1265- MOVE 999999 TO R4-TOTAL-PARCELAS OF REG-PGTO-SASSE */
            _.Move(999999, LBFCT016.REG_PGTO_SASSE.R4_TOTAL_PARCELAS);

            /*" -1267- WRITE REG-STA-SASSE FROM REG-PGTO-SASSE. */
            _.Move(LBFCT016.REG_PGTO_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1267- ADD 1 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_SAIDA*/

        [StopWatch]
        /*" R0980-00-LER-H-PROP-FIDEL-SECTION */
        private void R0980_00_LER_H_PROP_FIDEL_SECTION()
        {
            /*" -1274- MOVE 'R0980-LER-H-PROP-FIDEL' TO PARAGRAFO. */
            _.Move("R0980-LER-H-PROP-FIDEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1276- MOVE 'SELECT HIST PROP FIDELIZ' TO COMANDO. */
            _.Move("SELECT HIST PROP FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1279- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO OF DCLHIST-PROP-FIDELIZ */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1282- MOVE 'REJ' TO PROPFIDH-SIT-PROPOSTA OF DCLHIST-PROP-FIDELIZ. */
            _.Move("REJ", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1291- PERFORM R0980_00_LER_H_PROP_FIDEL_DB_SELECT_1 */

            R0980_00_LER_H_PROP_FIDEL_DB_SELECT_1();

            /*" -1294- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1295- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1296- MOVE 2 TO W-TEM-HISTORICO */
                    _.Move(2, WAREA_AUXILIAR.W_TEM_HISTORICO);

                    /*" -1297- ELSE */
                }
                else
                {


                    /*" -1298- DISPLAY 'PF0715B - FIM ANORMAL' */
                    _.Display($"PF0715B - FIM ANORMAL");

                    /*" -1299- DISPLAY '          ERRO SELECT HIST-PROP-FIDELIZ' */
                    _.Display($"          ERRO SELECT HIST-PROP-FIDELIZ");

                    /*" -1301- DISPLAY '          NUMERO PROPOSTA............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO PROPOSTA............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -1303- DISPLAY '          NUMERO IDENTIFICACAO.......  ' PROPOFID-NUM-IDENTIFICACAO */
                    _.Display($"          NUMERO IDENTIFICACAO.......  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -1305- DISPLAY '          SQLCODE....................  ' SQLCODE */
                    _.Display($"          SQLCODE....................  {DB.SQLCODE}");

                    /*" -1306- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1307- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1308- ELSE */
                }

            }
            else
            {


                /*" -1308- MOVE 1 TO W-TEM-HISTORICO. */
                _.Move(1, WAREA_AUXILIAR.W_TEM_HISTORICO);
            }


        }

        [StopWatch]
        /*" R0980-00-LER-H-PROP-FIDEL-DB-SELECT-1 */
        public void R0980_00_LER_H_PROP_FIDEL_DB_SELECT_1()
        {
            /*" -1291- EXEC SQL SELECT NUM_IDENTIFICACAO INTO :DCLHIST-PROP-FIDELIZ.PROPFIDH-NUM-IDENTIFICACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :DCLHIST-PROP-FIDELIZ.PROPFIDH-NUM-IDENTIFICACAO AND SIT_PROPOSTA = :DCLHIST-PROP-FIDELIZ.PROPFIDH-SIT-PROPOSTA WITH UR END-EXEC. */

            var r0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1 = new R0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
            };

            var executed_1 = R0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1.Execute(r0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0980_SAIDA*/

        [StopWatch]
        /*" R0985-00-LER-H-PROP-FIDEL-SECTION */
        private void R0985_00_LER_H_PROP_FIDEL_SECTION()
        {
            /*" -1318- MOVE 'R0985-LER-H-PROP-FIDEL' TO PARAGRAFO. */
            _.Move("R0985-LER-H-PROP-FIDEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1320- MOVE 'SELECT HIST PROP FIDELIZ' TO COMANDO. */
            _.Move("SELECT HIST PROP FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1323- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO OF DCLHIST-PROP-FIDELIZ */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1326- MOVE 'ENV' TO PROPFIDH-SIT-PROPOSTA OF DCLHIST-PROP-FIDELIZ. */
            _.Move("ENV", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1335- PERFORM R0985_00_LER_H_PROP_FIDEL_DB_SELECT_1 */

            R0985_00_LER_H_PROP_FIDEL_DB_SELECT_1();

            /*" -1338- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1339- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1340- MOVE 2 TO W-TEM-HISTORICO */
                    _.Move(2, WAREA_AUXILIAR.W_TEM_HISTORICO);

                    /*" -1341- ELSE */
                }
                else
                {


                    /*" -1342- DISPLAY 'PF0715B - FIM ANORMAL' */
                    _.Display($"PF0715B - FIM ANORMAL");

                    /*" -1343- DISPLAY '          ERRO SELECT HIST-PROP-FIDELIZ' */
                    _.Display($"          ERRO SELECT HIST-PROP-FIDELIZ");

                    /*" -1345- DISPLAY '          NUMERO PROPOSTA............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO PROPOSTA............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -1347- DISPLAY '          NUMERO IDENTIFICACAO.......  ' PROPOFID-NUM-IDENTIFICACAO */
                    _.Display($"          NUMERO IDENTIFICACAO.......  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -1349- DISPLAY '          SQLCODE....................  ' SQLCODE */
                    _.Display($"          SQLCODE....................  {DB.SQLCODE}");

                    /*" -1350- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1351- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1352- ELSE */
                }

            }
            else
            {


                /*" -1352- MOVE 1 TO W-TEM-HISTORICO. */
                _.Move(1, WAREA_AUXILIAR.W_TEM_HISTORICO);
            }


        }

        [StopWatch]
        /*" R0985-00-LER-H-PROP-FIDEL-DB-SELECT-1 */
        public void R0985_00_LER_H_PROP_FIDEL_DB_SELECT_1()
        {
            /*" -1335- EXEC SQL SELECT NUM_IDENTIFICACAO INTO :DCLHIST-PROP-FIDELIZ.PROPFIDH-NUM-IDENTIFICACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :DCLHIST-PROP-FIDELIZ.PROPFIDH-NUM-IDENTIFICACAO AND SIT_PROPOSTA = :DCLHIST-PROP-FIDELIZ.PROPFIDH-SIT-PROPOSTA WITH UR END-EXEC. */

            var r0985_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1 = new R0985_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
            };

            var executed_1 = R0985_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1.Execute(r0985_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0985_SAIDA*/

        [StopWatch]
        /*" R0990-00-OBTER-PRM-PAGO-SECTION */
        private void R0990_00_OBTER_PRM_PAGO_SECTION()
        {
            /*" -1359- MOVE 'R0990-00-OBTER-PRM-PAGO' TO PARAGRAFO. */
            _.Move("R0990-00-OBTER-PRM-PAGO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1361- MOVE 'DECLER' TO COMANDO. */
            _.Move("DECLER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1364- MOVE VGACOTER-NUM-CERTIFICADO TO HISCONPA-NUM-CERTIFICADO */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -1381- PERFORM R0990_00_OBTER_PRM_PAGO_DB_DECLARE_1 */

            R0990_00_OBTER_PRM_PAGO_DB_DECLARE_1();

            /*" -1385- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1385- PERFORM R0990_00_OBTER_PRM_PAGO_DB_OPEN_1 */

            R0990_00_OBTER_PRM_PAGO_DB_OPEN_1();

            /*" -1388- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1389- DISPLAY 'PF0715B - FIM ANORMAL' */
                _.Display($"PF0715B - FIM ANORMAL");

                /*" -1390- DISPLAY '          ERRO OPEN CURSOR PAGAMENTO' */
                _.Display($"          ERRO OPEN CURSOR PAGAMENTO");

                /*" -1392- DISPLAY '          SQLCODE.................. ' SQLCODE */
                _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                /*" -1394- DISPLAY '          PROPOSTA................. ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"          PROPOSTA................. {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -1395- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1397- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1399- MOVE 'FETCH' TO COMANDO. */
            _.Move("FETCH", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1410- PERFORM R0990_00_OBTER_PRM_PAGO_DB_FETCH_1 */

            R0990_00_OBTER_PRM_PAGO_DB_FETCH_1();

            /*" -1413- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1414- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1416- MOVE HISCOBPR-VLPREMIO TO R8-VLR-LANCAMENTO */
                    _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO);

                    /*" -1417- ELSE */
                }
                else
                {


                    /*" -1418- DISPLAY 'PF0715B - FIM ANORMAL' */
                    _.Display($"PF0715B - FIM ANORMAL");

                    /*" -1419- DISPLAY '          ERRO FETCH CURSOR PAGAMENTO' */
                    _.Display($"          ERRO FETCH CURSOR PAGAMENTO");

                    /*" -1421- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -1423- DISPLAY '          PROPOSTA.................. ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"          PROPOSTA.................. {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -1424- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1425- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1426- ELSE */
                }

            }
            else
            {


                /*" -1429- COMPUTE R8-VLR-LANCAMENTO = HISCONPA-PREMIO-VG + HISCONPA-PREMIO-AP. */
                LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO.Value = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG + HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP;
            }


            /*" -1431- MOVE 'CLOSE' TO COMANDO. */
            _.Move("CLOSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1431- PERFORM R0990_00_OBTER_PRM_PAGO_DB_CLOSE_1 */

            R0990_00_OBTER_PRM_PAGO_DB_CLOSE_1();

            /*" -1434- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1435- DISPLAY 'PF0715B - FIM ANORMAL' */
                _.Display($"PF0715B - FIM ANORMAL");

                /*" -1436- DISPLAY '          ERRO CLOSE CURSOR PAGAMENTO' */
                _.Display($"          ERRO CLOSE CURSOR PAGAMENTO");

                /*" -1438- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -1440- DISPLAY '          PROPOSTA.................. ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"          PROPOSTA.................. {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -1441- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1441- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0990-00-OBTER-PRM-PAGO-DB-OPEN-1 */
        public void R0990_00_OBTER_PRM_PAGO_DB_OPEN_1()
        {
            /*" -1385- EXEC SQL OPEN PAGAMENTO END-EXEC. */

            PAGAMENTO.Open();

        }

        [StopWatch]
        /*" R0990-00-OBTER-PRM-PAGO-DB-FETCH-1 */
        public void R0990_00_OBTER_PRM_PAGO_DB_FETCH_1()
        {
            /*" -1410- EXEC SQL FETCH PAGAMENTO INTO :HISCONPA-NUM-CERTIFICADO, :HISCONPA-NUM-PARCELA , :HISCONPA-NUM-TITULO , :HISCONPA-OCORR-HISTORICO, :HISCONPA-NUM-APOLICE , :HISCONPA-COD-SUBGRUPO , :HISCONPA-PREMIO-VG , :HISCONPA-PREMIO-AP , :HISCONPA-COD-OPERACAO END-EXEC. */

            if (PAGAMENTO.Fetch())
            {
                _.Move(PAGAMENTO.HISCONPA_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);
                _.Move(PAGAMENTO.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(PAGAMENTO.HISCONPA_NUM_TITULO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO);
                _.Move(PAGAMENTO.HISCONPA_OCORR_HISTORICO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);
                _.Move(PAGAMENTO.HISCONPA_NUM_APOLICE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE);
                _.Move(PAGAMENTO.HISCONPA_COD_SUBGRUPO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO);
                _.Move(PAGAMENTO.HISCONPA_PREMIO_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);
                _.Move(PAGAMENTO.HISCONPA_PREMIO_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);
                _.Move(PAGAMENTO.HISCONPA_COD_OPERACAO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);
            }

        }

        [StopWatch]
        /*" R0990-00-OBTER-PRM-PAGO-DB-CLOSE-1 */
        public void R0990_00_OBTER_PRM_PAGO_DB_CLOSE_1()
        {
            /*" -1431- EXEC SQL CLOSE PAGAMENTO END-EXEC. */

            PAGAMENTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0990_SAIDA*/

        [StopWatch]
        /*" R0992-00-OBTER-PRM-PAGO-SECTION */
        private void R0992_00_OBTER_PRM_PAGO_SECTION()
        {
            /*" -1450- MOVE 'R0992-00-OBTER-PRM-PAGO' TO PARAGRAFO. */
            _.Move("R0992-00-OBTER-PRM-PAGO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1452- MOVE 'SELECT RCAP' TO COMANDO. */
            _.Move("SELECT RCAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1455- MOVE VGACOTER-NUM-CERTIFICADO TO RCAPS-NUM-CERTIFICADO OF DCLRCAPS. */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -1466- PERFORM R0992_00_OBTER_PRM_PAGO_DB_SELECT_1 */

            R0992_00_OBTER_PRM_PAGO_DB_SELECT_1();

            /*" -1469- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1471- DISPLAY 'NAO FOI POSSIVEL ABTER PREMIO PG DA PROPOSTA ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"NAO FOI POSSIVEL ABTER PREMIO PG DA PROPOSTA {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -1473- DISPLAY '          SQLCODE............... ' SQLCODE */
                _.Display($"          SQLCODE............... {DB.SQLCODE}");

                /*" -1474- ELSE */
            }
            else
            {


                /*" -1474- MOVE RCAPS-VAL-RCAP TO R8-VLR-LANCAMENTO. */
                _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO);
            }


        }

        [StopWatch]
        /*" R0992-00-OBTER-PRM-PAGO-DB-SELECT-1 */
        public void R0992_00_OBTER_PRM_PAGO_DB_SELECT_1()
        {
            /*" -1466- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO =:DCLRCAPS.RCAPS-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1 = new R0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1.Execute(r0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0992_SAIDA*/

        [StopWatch]
        /*" R0995-00-GERAR-REGISTRO-TP8-SECTION */
        private void R0995_00_GERAR_REGISTRO_TP8_SECTION()
        {
            /*" -1481- MOVE 'R0995-00-GERAR-REGISTRO-TP8' TO PARAGRAFO. */
            _.Move("R0995-00-GERAR-REGISTRO-TP8", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1483- MOVE 'WRITE REGISTRO SIDEM' TO COMANDO. */
            _.Move("WRITE REGISTRO SIDEM", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1485- MOVE 8 TO R8-IDENTIFICACAO */
            _.Move(8, LBFPF025.R8_PONTUACAO_SIDEM.R8_IDENTIFICACAO);

            /*" -1488- MOVE VGACOTER-NUM-CERTIFICADO TO R8-NUM-PROPOSTA. */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PROPOSTA);

            /*" -1490- MOVE ZEROS TO R8-NUM-PARCELA, R8-VLR-ESTOQUE. */
            _.Move(0, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PARCELA, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_ESTOQUE);

            /*" -1492- MOVE 237 TO R8-TP-LANCAMENTO. */
            _.Move(237, LBFPF025.R8_PONTUACAO_SIDEM.R8_TP_LANCAMENTO);

            /*" -1494- WRITE REG-STA-SASSE FROM R8-PONTUACAO-SIDEM. */
            _.Move(LBFPF025.R8_PONTUACAO_SIDEM.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1494- ADD 1 TO RT-QTDE-TIPO-8 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0995_SAIDA*/

        [StopWatch]
        /*" R0970-00-STATUS-REGISTRO-TP5-SECTION */
        private void R0970_00_STATUS_REGISTRO_TP5_SECTION()
        {
            /*" -1506- MOVE 'R0970-00-STATUS-REGISTRO-TP5' TO PARAGRAFO. */
            _.Move("R0970-00-STATUS-REGISTRO-TP5", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1507- MOVE 5 TO R5-TIPO-REG. */
            _.Move(5, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_TIPO_REG);

            /*" -1513- MOVE VGACOTER-NUM-CERTIFICADO TO R5-NUM-PROPOSTA. */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_NUM_PROPOSTA);

            /*" -1515- WRITE REG-STA-SASSE FROM R5-REG-QTDE-VIDAS-VE */
            _.Move(LBFPF200.R5_REG_QTDE_VIDAS_VE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1515- ADD 1 TO RT-QTDE-TIPO-5 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0970_SAIDA*/

        [StopWatch]
        /*" R1000-00-GERAR-TRAILLER-SECTION */
        private void R1000_00_GERAR_TRAILLER_SECTION()
        {
            /*" -1525- MOVE 'R1000-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R1000-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1527- MOVE 'WRITE REG-TRAILLER - STATUS' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER - STATUS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1529- MOVE SPACES TO REG-STA-SASSE. */
            _.Move("", REG_STA_SASSE);

            /*" -1532- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -1535- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -1546- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 OF REG-TRAILLER-STA + RT-QTDE-TIPO-2 OF REG-TRAILLER-STA + RT-QTDE-TIPO-3 OF REG-TRAILLER-STA + RT-QTDE-TIPO-4 OF REG-TRAILLER-STA + RT-QTDE-TIPO-5 OF REG-TRAILLER-STA + RT-QTDE-TIPO-6 OF REG-TRAILLER-STA + RT-QTDE-TIPO-7 OF REG-TRAILLER-STA + RT-QTDE-TIPO-8 OF REG-TRAILLER-STA + RT-QTDE-TIPO-9 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -1546- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -1556- MOVE 'R1050-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R1050-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1558- MOVE 'INSERT ARQUIVOS-SIVPF - STATUS' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF - STATUS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1561- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -1564- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -1568- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -1571- MOVE RH-NSAS OF REG-HEADER-STA TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -1574- MOVE RT-QTDE-TOTAL OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -1582- PERFORM R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -1585- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1586- DISPLAY 'PF0715B - FIM ANORMAL' */
                _.Display($"PF0715B - FIM ANORMAL");

                /*" -1587- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -1589- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -1591- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -1593- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -1595- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -1597- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -1598- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1598- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -1582- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 = new R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1.Execute(r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_SAIDA*/

        [StopWatch]
        /*" R1100-00-GERAR-TOTAIS-SECTION */
        private void R1100_00_GERAR_TOTAIS_SECTION()
        {
            /*" -1609- MOVE 'R1100-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R1100-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1611- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1612- DISPLAY 'PF0715B - TOTAIS DO PROCESSAMENTO' */
            _.Display($"PF0715B - TOTAIS DO PROCESSAMENTO");

            /*" -1613- DISPLAY '          TOTAL  REGISTROS LIDOS........... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS........... {WAREA_AUXILIAR.W_NSL}");

            /*" -1615- DISPLAY '          TOTAL  DESPREZADO................ ' W-DESPREZADO */
            _.Display($"          TOTAL  DESPREZADO................ {WAREA_AUXILIAR.W_DESPREZADO}");

            /*" -1616- DISPLAY '          TOTAL  GERADO ARQUIVO STATUS..... ' RT-QTDE-TIPO-1 OF REG-TRAILLER-STA. */
            _.Display($"          TOTAL  GERADO ARQUIVO STATUS..... {LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-SECTION */
        private void R3390_GERA_HIST_FIDELIZACAO_SECTION()
        {
            /*" -1625- MOVE 'R3390-GERA-HIST-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3390-GERA-HIST-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1627- MOVE 'INSERT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1630- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1633- MOVE VGACOTER-DATA-MOVIMENTO TO PROPFIDH-DATA-SITUACAO. */
            _.Move(VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_DATA_MOVIMENTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -1636- MOVE RH-NSAS OF REG-HEADER-STA TO PROPFIDH-NSAS-SIVPF. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -1639- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO PROPFIDH-NSL. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -1642- MOVE R1-SIT-PROPOSTA OF REG-STA-PROPOSTA TO PROPFIDH-SIT-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1645- MOVE R4-SIT-COBRANCA OF REG-PGTO-SASSE TO PROPFIDH-SIT-COBRANCA-SIVPF. */
            _.Move(LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -1649- MOVE R1-SIT-MOTIVO OF REG-STA-PROPOSTA TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -1652- MOVE PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -1655- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -1666- PERFORM R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1 */

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1();

            /*" -1669- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1670- DISPLAY 'PF0715B - FIM ANORMAL' */
                _.Display($"PF0715B - FIM ANORMAL");

                /*" -1671- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -1674- DISPLAY '          PROPOSTA / IDENTIFICACAO ' VGACOTER-NUM-CERTIFICADO '  ' PROPFIDH-NUM-IDENTIFICACAO OF DCLHIST-PROP-FIDELIZ */

                $"          PROPOSTA / IDENTIFICACAO {VGACOTER.DCLVG_ACOMP_TERMO.VGACOTER_NUM_CERTIFICADO}  {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}"
                .Display();

                /*" -1676- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1677- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1677- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-DB-INSERT-1 */
        public void R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -1666- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES ( :PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

            var r3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1 = new R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_DATA_SITUACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.ToString(),
                PROPFIDH_NSAS_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF.ToString(),
                PROPFIDH_NSL = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
                PROPFIDH_SIT_COBRANCA_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF.ToString(),
                PROPFIDH_SIT_MOTIVO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.ToString(),
                PROPFIDH_COD_EMPRESA_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF.ToString(),
                PROPFIDH_COD_PRODUTO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF.ToString(),
            };

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3390_SAIDA*/

        [StopWatch]
        /*" R3400-00-ATUALIZA-PROPOSTA-SECTION */
        private void R3400_00_ATUALIZA_PROPOSTA_SECTION()
        {
            /*" -1687- MOVE 'R3400-00-ATUALIZA-PROPOSTA' TO PARAGRAFO. */
            _.Move("R3400-00-ATUALIZA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1689- MOVE 'UPDATE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1690- MOVE 'PF0715B' TO PROPOFID-COD-USUARIO */
            _.Move("PF0715B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -1692- MOVE 'R' TO PROPOFID-SITUACAO-ENVIO */
            _.Move("R", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -1695- MOVE PROPFIDH-NSL OF DCLHIST-PROP-FIDELIZ TO PROPOFID-NSL. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);

            /*" -1698- MOVE PROPFIDH-NSAS-SIVPF OF DCLHIST-PROP-FIDELIZ TO PROPOFID-NSAS-SIVPF. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);

            /*" -1701- MOVE PROPFIDH-SIT-PROPOSTA OF DCLHIST-PROP-FIDELIZ TO PROPOFID-SIT-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -1710- PERFORM R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1 */

            R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1();

            /*" -1713- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1714- DISPLAY 'PF0715B - FIM ANORMAL' */
                _.Display($"PF0715B - FIM ANORMAL");

                /*" -1715- DISPLAY '          ERRO UPDATE PROPOSTA-FIDELIZ' */
                _.Display($"          ERRO UPDATE PROPOSTA-FIDELIZ");

                /*" -1717- DISPLAY '          PROPOSTA................... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          PROPOSTA................... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1719- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1720- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1720- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3400-00-ATUALIZA-PROPOSTA-DB-UPDATE-1 */
        public void R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1()
        {
            /*" -1710- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET NSAS_SIVPF = :PROPOFID-NSAS-SIVPF, NSL = :PROPOFID-NSL, SIT_PROPOSTA = :PROPOFID-SIT-PROPOSTA, COD_USUARIO = :PROPOFID-COD-USUARIO, SITUACAO_ENVIO = :PROPOFID-SITUACAO-ENVIO WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1 = new R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1()
            {
                PROPOFID_SITUACAO_ENVIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO.ToString(),
                PROPOFID_SIT_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.ToString(),
                PROPOFID_COD_USUARIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO.ToString(),
                PROPOFID_NSAS_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF.ToString(),
                PROPOFID_NSL = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1.Execute(r3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -1729- CLOSE MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -1740- DISPLAY ' ' */
            _.Display($" ");

            /*" -1741- IF W-FIM-MOVTO-TERMO = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM")
            {

                /*" -1742- DISPLAY 'PF0715B - FIM NORMAL' */
                _.Display($"PF0715B - FIM NORMAL");

                /*" -1743- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1744- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1744- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1746- ELSE */
            }
            else
            {


                /*" -1747- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_3.WSQLCODE);

                /*" -1748- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_3.WSQLERRD1);

                /*" -1749- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_3.WSQLERRD2);

                /*" -1750- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -1751- DISPLAY '*** PF0715B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0715B *** ROLLBACK EM ANDAMENTO ...");

                /*" -1752- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1752- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -1755- MOVE 09 TO RETURN-CODE. */
                _.Move(09, RETURN_CODE);
            }


            /*" -1755- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}