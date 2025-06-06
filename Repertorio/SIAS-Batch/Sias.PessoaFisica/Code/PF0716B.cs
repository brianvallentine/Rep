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
using Sias.PessoaFisica.DB2.PF0716B;

namespace Code
{
    public class PF0716B
    {
        public bool IsCall { get; set; }

        public PF0716B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ...............  GERA MOVIMENTACAO DA PROPOSTA EMPRE- *      */
        /*"      *                           SARIAL AO SIGPF, APOS A LIBERACAO DO *      */
        /*"      *                           TERMO. (EXCETO CANCELAMENTO) VIDA.   *      */
        /*"      *                                                                *      */
        /*"      *   ANALISE/PROGRAMACAO...  LUIZ CARLOS.                         *      */
        /*"      *   PROGRAMA .............  PF0716B                              *      */
        /*"      *   DATA .................  29/07/2004.                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 03             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA                          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 02                                                      *      */
        /*"      * ATENDE CADMUS 84809        DB2.V10  SELECTS           SET/2013 *      */
        /*"      *                            REGINALDO DA SILVA                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 01                                                      *      */
        /*"      *            DESPREZAR COD_PRODUTO_SIVPF IGUAL A 48. TRATA-SE DA *      */
        /*"      *            INTERNALIZACAO DE APOLICE ESPECIFICA DE VIDA.       *      */
        /*"      *                                                                *      */
        /*"      * 27/11/2007 PROCURE POR V.01 - MAURICIO LINKE.                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     ******************************************************************      */
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
        public PF0716B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0716B_WAREA_AUXILIAR();
        public class PF0716B_WAREA_AUXILIAR : VarBasis
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
            private _REDEF_PF0716B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0716B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0716B_FILLER_0(); _.Move(W_DATA_TRABALHO, _filler_0); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_0, W_DATA_TRABALHO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_DATA_TRABALHO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0716B_FILLER_0 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-COD-COBERTURA               PIC 9(004)  VALUE ZEROS.*/

                public _REDEF_PF0716B_FILLER_0()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER REDEFINES W-COD-COBERTURA.*/
            private _REDEF_PF0716B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0716B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0716B_FILLER_1(); _.Move(W_COD_COBERTURA, _filler_1); VarBasis.RedefinePassValue(W_COD_COBERTURA, _filler_1, W_COD_COBERTURA); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_COD_COBERTURA); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_COD_COBERTURA); }
            }  //Redefines
            public class _REDEF_PF0716B_FILLER_1 : VarBasis
            {
                /*"        10  W-SUBPRODUTO              PIC 9(003).*/
                public IntBasis W_SUBPRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        10  W-COBERTURA               PIC 9(001).*/
                public IntBasis W_COBERTURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0716B_FILLER_1()
                {
                    W_SUBPRODUTO.ValueChanged += OnValueChanged;
                    W_COBERTURA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0716B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0716B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0716B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0716B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0716B_W_DTMOVABE1()
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
            private _REDEF_PF0716B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0716B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0716B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0716B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0716B_W_DTMOVABE_I1()
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
            private _REDEF_PF0716B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0716B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0716B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0716B_W_DATA_SQL1 : VarBasis
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

                public _REDEF_PF0716B_W_DATA_SQL1()
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
            private _REDEF_PF0716B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0716B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0716B_FILLER_2(); _.Move(W_NR_SICOB, _filler_2); VarBasis.RedefinePassValue(W_NR_SICOB, _filler_2, W_NR_SICOB); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_NR_SICOB); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_NR_SICOB); }
            }  //Redefines
            public class _REDEF_PF0716B_FILLER_2 : VarBasis
            {
                /*"        07  W-NR-PROD-SICOB           PIC 9(003).*/
                public IntBasis W_NR_PROD_SICOB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  W-NR-NSAC-SICOB           PIC 9(006).*/
                public IntBasis W_NR_NSAC_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        07  W-NR-NSL-SICOB            PIC 9(006).*/
                public IntBasis W_NR_NSL_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05 W-HISTORICO                    PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0716B_FILLER_2()
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

            /*"01  WABEND*/
        }
        public PF0716B_WABEND WABEND { get; set; } = new PF0716B_WABEND();
        public class PF0716B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0716B_FILLER_3 FILLER_3 { get; set; } = new PF0716B_FILLER_3();
            public class PF0716B_FILLER_3 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0716B  '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0716B  ");
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
            public PF0716B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0716B_LOCALIZA_ABEND_1();
            public class PF0716B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0716B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0716B_LOCALIZA_ABEND_2();
            public class PF0716B_LOCALIZA_ABEND_2 : VarBasis
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
        public Dclgens.VGACOTER VGACOTER { get; set; } = new Dclgens.VGACOTER();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
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
        public PF0716B_TERMO_ADESAO TERMO_ADESAO { get; set; } = new PF0716B_TERMO_ADESAO();
        public PF0716B_COBERTURAS COBERTURAS { get; set; } = new PF0716B_COBERTURAS();
        public PF0716B_TER_NIVEL TER_NIVEL { get; set; } = new PF0716B_TER_NIVEL();
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
            /*" -262- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -263- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -264- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -267- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -268- DISPLAY '*               PROGRAMA PF0716B               *' . */
            _.Display($"*               PROGRAMA PF0716B               *");

            /*" -269- DISPLAY '*   GERA MOVIMENTACAO DA PROPOSTA EMPRESARIAL  *' . */
            _.Display($"*   GERA MOVIMENTACAO DA PROPOSTA EMPRESARIAL  *");

            /*" -270- DISPLAY '*           VERSAO:  03 - 29/11/2013           *' . */
            _.Display($"*           VERSAO:  03 - 29/11/2013           *");

            /*" -271- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -280- DISPLAY '*  PF0716B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0716B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -282- PERFORM R0005-00-INICIALIZAR. */

            R0005_00_INICIALIZAR_SECTION();

            /*" -284- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -286- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -288- PERFORM R0070-00-LER-MOVTO. */

            R0070_00_LER_MOVTO_SECTION();

            /*" -289- IF W-FIM-MOVTO-TERMO EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM")
            {

                /*" -290- DISPLAY '*----------------------------------------*' */
                _.Display($"*----------------------------------------*");

                /*" -291- DISPLAY '* PF0716B - TERMINO NORMAL, NAO HOUVE    *' */
                _.Display($"* PF0716B - TERMINO NORMAL, NAO HOUVE    *");

                /*" -292- DISPLAY '*           MOVIMENTO NA DATA SOLICITADA *' */
                _.Display($"*           MOVIMENTO NA DATA SOLICITADA *");

                /*" -293- DISPLAY '*----------------------------------------*' */
                _.Display($"*----------------------------------------*");

                /*" -294- PERFORM R1100-00-GERAR-TOTAIS */

                R1100_00_GERAR_TOTAIS_SECTION();

                /*" -295- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -298- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -299- DISPLAY '*-----------------------------------------*' */
            _.Display($"*-----------------------------------------*");

            /*" -300- DISPLAY '* PF0716B - TEM MOVIMENTO A PROCESSAR     *' */
            _.Display($"* PF0716B - TEM MOVIMENTO A PROCESSAR     *");

            /*" -301- DISPLAY '*           EXECUTAR EM TESTE E ACOMPANHAR*' */
            _.Display($"*           EXECUTAR EM TESTE E ACOMPANHAR*");

            /*" -302- DISPLAY '*-----------------------------------------*' */
            _.Display($"*-----------------------------------------*");

            /*" -303- PERFORM R1100-00-GERAR-TOTAIS */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -304- PERFORM R9988-00-FECHAR-ARQUIVOS */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -306- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

            /*" -308- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -311- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-TERMO EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -313- PERFORM R1000-00-GERAR-TRAILLER. */

            R1000_00_GERAR_TRAILLER_SECTION();

            /*" -315- PERFORM R1050-00-CONTROLAR-ARQ-ENVIADO */

            R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -317- PERFORM R1100-00-GERAR-TOTAIS. */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -319- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -319- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0005-00-INICIALIZAR-SECTION */
        private void R0005_00_INICIALIZAR_SECTION()
        {
            /*" -327- MOVE 'R0005-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0005-00-INICIALIZAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -329- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -331- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -339- PERFORM R0005_00_INICIALIZAR_DB_SELECT_1 */

            R0005_00_INICIALIZAR_DB_SELECT_1();

            /*" -344- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -346- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -348- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -351- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -355- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -358- DISPLAY '*  PF0716B - DATA PROCESSAMENTO...' W-DTMOVABE-I1. */
            _.Display($"*  PF0716B - DATA PROCESSAMENTO...{WAREA_AUXILIAR.W_DTMOVABE_I1}");

            /*" -360- INITIALIZE REG-TRAILLER-STA. */
            _.Initialize(
                LBFCT011.REG_TRAILLER_STA
            );

            /*" -360- OPEN OUTPUT MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }

        [StopWatch]
        /*" R0005-00-INICIALIZAR-DB-SELECT-1 */
        public void R0005_00_INICIALIZAR_DB_SELECT_1()
        {
            /*" -339- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :WHOST-DATA-REFERENCIA FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
            /*" -370- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -372- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -375- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -379- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -388- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -391- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -392- DISPLAY 'PF0716B - FIM ANORMAL' */
                _.Display($"PF0716B - FIM ANORMAL");

                /*" -393- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -395- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -396- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -398- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -401- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -403- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -403- MOVE W-NSAS TO RH-NSAS OF REG-HEADER-STA. */
            _.Move(WAREA_AUXILIAR.W_NSAS, LBFCT011.REG_HEADER_STA.RH_NSAS);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -388- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

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
            /*" -413- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -415- MOVE 'DECLER MOVIMENTO' TO COMANDO. */
            _.Move("DECLER MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -416- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -418- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -421- DISPLAY '*  PF0716B * INICIO DECLARE V0MOVIMENTO...' W-TIME-EDIT. */
            _.Display($"*  PF0716B * INICIO DECLARE V0MOVIMENTO...{WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -422- MOVE 109300000672 TO TERMOADE-NUM-APOLICE */
            _.Move(109300000672, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE);

            /*" -424- MOVE ' ' TO TERMOADE-SITUACAO */
            _.Move(" ", TERMOADE.DCLTERMO_ADESAO.TERMOADE_SITUACAO);

            /*" -462- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -464- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -467- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -469- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -471- DISPLAY '** PF0716B * FIM    DECLARE V0MOVIMENTO...' W-TIME-EDIT */
            _.Display($"** PF0716B * FIM    DECLARE V0MOVIMENTO...{WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -471- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -462- EXEC SQL DECLARE TERMO-ADESAO CURSOR FOR SELECT A.NUM_TERMO , A.NUM_APOLICE , A.COD_SUBGRUPO , B.DATA_MOVIMENTO , B.DATA_OPERACAO , B.COD_OPERACAO , B.SIT_REGISTRO , C.SIT_PROPOSTA , C.NUM_PROPOSTA_SIVPF , C.NUM_IDENTIFICACAO , C.COD_EMPRESA_SIVPF , C.COD_PRODUTO_SIVPF FROM SEGUROS.TERMO_ADESAO A, SEGUROS.MOVIMENTO_VGAP B, SEGUROS.PROPOSTA_FIDELIZ C WHERE A.NUM_APOLICE = :TERMOADE-NUM-APOLICE AND A.COD_SUBGRUPO > 0 AND A.SITUACAO <> :TERMOADE-SITUACAO AND C.NUM_SICOB = A.NUM_TERMO AND B.NUM_CERTIFICADO = C.NUM_PROPOSTA_SIVPF AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.COD_OPERACAO > 199 AND B.DATA_MOVIMENTO >= :SISTEMAS-DATA-MOV-ABERTO AND C.NUM_PROPOSTA_SIVPF = B.NUM_CERTIFICADO AND C.COD_PRODUTO_SIVPF <> 48 ORDER BY A.NUM_TERMO , A.NUM_APOLICE , A.COD_SUBGRUPO , B.DATA_MOVIMENTO , B.DATA_OPERACAO , B.COD_OPERACAO WITH UR END-EXEC. */
            TERMO_ADESAO = new PF0716B_TERMO_ADESAO(true);
            string GetQuery_TERMO_ADESAO()
            {
                var query = @$"SELECT A.NUM_TERMO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							B.DATA_MOVIMENTO
							, 
							B.DATA_OPERACAO
							, 
							B.COD_OPERACAO
							, 
							B.SIT_REGISTRO
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
							SEGUROS.MOVIMENTO_VGAP B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C 
							WHERE A.NUM_APOLICE = '{TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE}' 
							AND A.COD_SUBGRUPO > 0 
							AND A.SITUACAO <> '{TERMOADE.DCLTERMO_ADESAO.TERMOADE_SITUACAO}' 
							AND C.NUM_SICOB = A.NUM_TERMO 
							AND B.NUM_CERTIFICADO = C.NUM_PROPOSTA_SIVPF 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.COD_OPERACAO > 199 
							AND B.DATA_MOVIMENTO >= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND C.NUM_PROPOSTA_SIVPF = B.NUM_CERTIFICADO 
							AND C.COD_PRODUTO_SIVPF <> 48 
							ORDER BY 
							A.NUM_TERMO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							B.DATA_MOVIMENTO
							, 
							B.DATA_OPERACAO
							, 
							B.COD_OPERACAO";

                return query;
            }
            TERMO_ADESAO.GetQueryEvent += GetQuery_TERMO_ADESAO;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -464- EXEC SQL OPEN TERMO-ADESAO END-EXEC. */

            TERMO_ADESAO.Open();

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-DECLARE-1 */
        public void R0450_00_OBTER_COBERTURA_DB_DECLARE_1()
        {
            /*" -749- EXEC SQL DECLARE COBERTURAS CURSOR FOR SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMP_MORNATU , IMPMORACID , IMPINVPERM , VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO AND DATA_INIVIGENCIA <= :MOVIMVGA-DATA-MOVIMENTO AND DATA_TERVIGENCIA >= :MOVIMVGA-DATA-MOVIMENTO WITH UR END-EXEC. */
            COBERTURAS = new PF0716B_COBERTURAS(true);
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
							AND DATA_INIVIGENCIA <= '{MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO}' 
							AND DATA_TERVIGENCIA >= '{MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO}'";

                return query;
            }
            COBERTURAS.GetQueryEvent += GetQuery_COBERTURAS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -481- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -483- MOVE 'FETCH TERMO-ADESAO' TO COMANDO. */
            _.Move("FETCH TERMO-ADESAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -497- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -500- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -501- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -502- MOVE 'FIM' TO W-FIM-MOVTO-TERMO */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_TERMO);

                    /*" -502- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -504- ELSE */
                }
                else
                {


                    /*" -505- DISPLAY 'PF0716B - FIM ANORMAL' */
                    _.Display($"PF0716B - FIM ANORMAL");

                    /*" -507- DISPLAY '          ERRO FETCH CURSOR V0MOVIMENTO  ' SQLCODE */
                    _.Display($"          ERRO FETCH CURSOR V0MOVIMENTO  {DB.SQLCODE}");

                    /*" -508- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -509- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -510- ELSE */
                }

            }
            else
            {


                /*" -513- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -514- IF W-CONTROLE > 999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 999)
                {

                    /*" -515- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -516- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -517- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -518- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -520- DISPLAY '** PF0716B ** TOTAL LIDO ..  ' W-NSL ' ' W-TIME-EDIT */

                    $"** PF0716B ** TOTAL LIDO ..  {WAREA_AUXILIAR.W_NSL} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -521- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -523- END-IF */
                }


                /*" -524- IF VIND-RCAP LESS 0 */

                if (VIND_RCAP < 0)
                {

                    /*" -527- DISPLAY 'TERMO REJEITADO, RCAP NULO  ' TERMOADE-NUM-TERMO '  PROPOSTA  ' PROPOFID-NUM-PROPOSTA-SIVPF */

                    $"TERMO REJEITADO, RCAP NULO  {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  PROPOSTA  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}"
                    .Display();

                    /*" -528- GO TO R0070-00-LER-MOVTO */
                    new Task(() => R0070_00_LER_MOVTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -528- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -497- EXEC SQL FETCH TERMO-ADESAO INTO :TERMOADE-NUM-TERMO , :TERMOADE-NUM-APOLICE , :TERMOADE-COD-SUBGRUPO , :MOVIMVGA-DATA-MOVIMENTO , :MOVIMVGA-DATA-OPERACAO , :MOVIMVGA-COD-OPERACAO , :MOVIMVGA-SIT-REGISTRO , :PROPOFID-SIT-PROPOSTA , :PROPOFID-NUM-PROPOSTA-SIVPF , :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-COD-EMPRESA-SIVPF , :PROPOFID-COD-PRODUTO-SIVPF END-EXEC. */

            if (TERMO_ADESAO.Fetch())
            {
                _.Move(TERMO_ADESAO.TERMOADE_NUM_TERMO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_APOLICE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE);
                _.Move(TERMO_ADESAO.TERMOADE_COD_SUBGRUPO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO);
                _.Move(TERMO_ADESAO.MOVIMVGA_DATA_MOVIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO);
                _.Move(TERMO_ADESAO.MOVIMVGA_DATA_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);
                _.Move(TERMO_ADESAO.MOVIMVGA_COD_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);
                _.Move(TERMO_ADESAO.MOVIMVGA_SIT_REGISTRO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO);
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
            /*" -502- EXEC SQL CLOSE TERMO-ADESAO END-EXEC */

            TERMO_ADESAO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -538- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -540- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -543- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -546- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -549- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-SQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -550- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -551- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -552- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -555- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -558- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -561- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -561- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -571- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -575- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -576- IF MOVIMVGA-COD-OPERACAO GREATER 399 AND LESS 500 */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 399 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 500)
            {

                /*" -579- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -580- IF PROPOFID-NUM-PROPOSTA-SIVPF GREATER 10000000000 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF > 10000000000)
            {

                /*" -581- IF PROPOFID-NUM-PROPOSTA-SIVPF LESS 19999999999 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF < 19999999999)
                {

                    /*" -582- DISPLAY 'PF0716B - TERMINO ANORMAL / FAIXA 10000000000' */
                    _.Display($"PF0716B - TERMINO ANORMAL / FAIXA 10000000000");

                    /*" -584- DISPLAY '          TERMO/PROPOSTA DESPREZADA ==>  ' TERMOADE-NUM-TERMO '  ' PROPOFID-NUM-PROPOSTA-SIVPF */

                    $"          TERMO/PROPOSTA DESPREZADA ==>  {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}"
                    .Display();

                    /*" -585- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -587- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -589- PERFORM R0230-00-LER-PROPOSTAVA. */

            R0230_00_LER_PROPOSTAVA_SECTION();

            /*" -590- IF PROPOSTAVA-NAO-CADASTRADA */

            if (WAREA_AUXILIAR.W_PROPOSTAVA["PROPOSTAVA_NAO_CADASTRADA"])
            {

                /*" -591- DISPLAY 'PF0716B - PROPOSTAVA NAO CADASTRADA' */
                _.Display($"PF0716B - PROPOSTAVA NAO CADASTRADA");

                /*" -593- DISPLAY '          TERMO/PROPOSTA DESPREZADA ==>  ' TERMOADE-NUM-TERMO '  ' PROPOFID-NUM-PROPOSTA-SIVPF */

                $"          TERMO/PROPOSTA DESPREZADA ==>  {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}"
                .Display();

                /*" -594- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -596- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -602- INITIALIZE REG-STA-PROPOSTA REG-APOL-SASSE REG-COBER-SASSE REG-PGTO-SASSE R5-REG-QTDE-VIDAS-VE. */
            _.Initialize(
                LBFCT011.REG_STA_PROPOSTA
                , LBFCT016.REG_APOL_SASSE
                , LBFCT016.REG_COBER_SASSE
                , LBFCT016.REG_PGTO_SASSE
                , LBFPF200.R5_REG_QTDE_VIDAS_VE
            );

            /*" -604- PERFORM R0290-00-DEFINIR-SIT-MOTIVO */

            R0290_00_DEFINIR_SIT_MOTIVO_SECTION();

            /*" -606- PERFORM R0580-00-LER-HIST-FIDELIZ */

            R0580_00_LER_HIST_FIDELIZ_SECTION();

            /*" -607- IF HISTORICO-CADASTRADO */

            if (WAREA_AUXILIAR.W_HISTORICO["HISTORICO_CADASTRADO"])
            {

                /*" -608- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -611- DISPLAY 'PF0716B - MOVIMENTO GERADO ANTERIORMENTE ====> ' TERMOADE-NUM-TERMO '  ' PROPOFID-NUM-PROPOSTA-SIVPF '  ' MOVIMVGA-COD-OPERACAO */

                $"PF0716B - MOVIMENTO GERADO ANTERIORMENTE ====> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}  {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO}"
                .Display();

                /*" -613- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -615- MOVE 1 TO W-IND-NIVEL. */
            _.Move(1, WAREA_AUXILIAR.W_IND_NIVEL);

            /*" -616- IF REGISTROS-1-E-4 */

            if (WAREA_AUXILIAR.W_REGISTROS["REGISTROS_1_E_4"])
            {

                /*" -617- PERFORM R0800-00-STATUS-REGISTRO-TP1 */

                R0800_00_STATUS_REGISTRO_TP1_SECTION();

                /*" -618- PERFORM R0950-00-STATUS-REGISTRO-TP4 */

                R0950_00_STATUS_REGISTRO_TP4_SECTION();

                /*" -619- PERFORM R3390-GERA-HIST-FIDELIZACAO */

                R3390_GERA_HIST_FIDELIZACAO_SECTION();

                /*" -620- PERFORM R3400-00-ATUALIZA-PROPOSTA */

                R3400_00_ATUALIZA_PROPOSTA_SECTION();

                /*" -622- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -624- PERFORM R0450-00-OBTER-COBERTURA. */

            R0450_00_OBTER_COBERTURA_SECTION();

            /*" -625- IF COBERTURA-NAO-CADASTRADA */

            if (WAREA_AUXILIAR.W_COBERTURAS["COBERTURA_NAO_CADASTRADA"])
            {

                /*" -626- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -628- DISPLAY 'PF0716B - COBERTURA NAO CADASTRADA ==========> ' TERMOADE-NUM-TERMO '  ' PROPOFID-NUM-PROPOSTA-SIVPF */

                $"PF0716B - COBERTURA NAO CADASTRADA ==========> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}"
                .Display();

                /*" -630- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -632- PERFORM R0710-OBTER-NIVEL-EMPRESA */

            R0710_OBTER_NIVEL_EMPRESA_SECTION();

            /*" -634- PERFORM R0715-FETCH-NIVEL-EMPRESA. */

            R0715_FETCH_NIVEL_EMPRESA_SECTION();

            /*" -637- PERFORM R0720-MONTA-NIVEL-CARGO UNTIL W-FIM-TERNIV = 'S' . */

            while (!(WAREA_AUXILIAR.W_FIM_TERNIV == "S"))
            {

                R0720_MONTA_NIVEL_CARGO_SECTION();
            }

            /*" -638- PERFORM R0800-00-STATUS-REGISTRO-TP1 */

            R0800_00_STATUS_REGISTRO_TP1_SECTION();

            /*" -639- PERFORM R0850-00-STATUS-REGISTRO-TP2 */

            R0850_00_STATUS_REGISTRO_TP2_SECTION();

            /*" -640- PERFORM R0900-00-STATUS-REGISTRO-TP3 */

            R0900_00_STATUS_REGISTRO_TP3_SECTION();

            /*" -641- PERFORM R0950-00-STATUS-REGISTRO-TP4 */

            R0950_00_STATUS_REGISTRO_TP4_SECTION();

            /*" -642- PERFORM R0970-00-STATUS-REGISTRO-TP5. */

            R0970_00_STATUS_REGISTRO_TP5_SECTION();

            /*" -643- PERFORM R3390-GERA-HIST-FIDELIZACAO. */

            R3390_GERA_HIST_FIDELIZACAO_SECTION();

            /*" -643- PERFORM R3400-00-ATUALIZA-PROPOSTA. */

            R3400_00_ATUALIZA_PROPOSTA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0150_LEITURA */

            R0150_LEITURA();

        }

        [StopWatch]
        /*" R0150-LEITURA */
        private void R0150_LEITURA(bool isPerform = false)
        {
            /*" -648- IF W-FIM-MOVTO-TERMO NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO != "FIM")
            {

                /*" -648- PERFORM R0070-00-LER-MOVTO. */

                R0070_00_LER_MOVTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0230-00-LER-PROPOSTAVA-SECTION */
        private void R0230_00_LER_PROPOSTAVA_SECTION()
        {
            /*" -658- MOVE 'R0210-00-LER-PROPOSTAVA' TO PARAGRAFO. */
            _.Move("R0210-00-LER-PROPOSTAVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -660- MOVE 'SELECT PROPOSTAS-VA' TO COMANDO. */
            _.Move("SELECT PROPOSTAS-VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -662- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO PROPOVA-NUM-CERTIFICADO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -670- PERFORM R0230_00_LER_PROPOSTAVA_DB_SELECT_1 */

            R0230_00_LER_PROPOSTAVA_DB_SELECT_1();

            /*" -673- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -674- MOVE 1 TO W-PROPOSTAVA */
                _.Move(1, WAREA_AUXILIAR.W_PROPOSTAVA);

                /*" -675- ELSE */
            }
            else
            {


                /*" -676- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -677- MOVE 2 TO W-PROPOSTAVA */
                    _.Move(2, WAREA_AUXILIAR.W_PROPOSTAVA);

                    /*" -678- ELSE */
                }
                else
                {


                    /*" -679- DISPLAY 'PF0716B - FIM ANORMAL' */
                    _.Display($"PF0716B - FIM ANORMAL");

                    /*" -680- DISPLAY '          ERRO SELECT PROPOSTAS_VA' */
                    _.Display($"          ERRO SELECT PROPOSTAS_VA");

                    /*" -683- DISPLAY '          NUMERO PROPOSTA........ ' PROPOVA-NUM-CERTIFICADO '  ' SQLCODE */

                    $"          NUMERO PROPOSTA........ {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}  {DB.SQLCODE}"
                    .Display();

                    /*" -684- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -684- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0230-00-LER-PROPOSTAVA-DB-SELECT-1 */
        public void R0230_00_LER_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -670- EXEC SQL SELECT DATA_QUITACAO, NUM_PARCELA INTO :PROPOVA-DATA-QUITACAO, :PROPOVA-NUM-PARCELA FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0230_00_LER_PROPOSTAVA_DB_SELECT_1_Query1 = new R0230_00_LER_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0230_00_LER_PROPOSTAVA_DB_SELECT_1_Query1.Execute(r0230_00_LER_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(executed_1.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_SAIDA*/

        [StopWatch]
        /*" R0290-00-DEFINIR-SIT-MOTIVO-SECTION */
        private void R0290_00_DEFINIR_SIT_MOTIVO_SECTION()
        {
            /*" -693- MOVE 'R0290-00-DEFINIR-SIT-MOTIVO' TO PARAGRAFO. */
            _.Move("R0290-00-DEFINIR-SIT-MOTIVO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -695- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -697- MOVE 'EMT' TO R1-SIT-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move("EMT", LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

            /*" -699- MOVE 'PAG' TO R4-SIT-COBRANCA OF REG-PGTO-SASSE. */
            _.Move("PAG", LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA);

            /*" -700- IF MOVIMVGA-COD-OPERACAO GREATER 199 AND LESS 300 */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 199 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 300)
            {

                /*" -701- MOVE 2 TO W-REGISTROS */
                _.Move(2, WAREA_AUXILIAR.W_REGISTROS);

                /*" -703- MOVE 726 TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA. */
                _.Move(726, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);
            }


            /*" -704- IF MOVIMVGA-COD-OPERACAO GREATER 499 AND LESS 600 */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 499 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 600)
            {

                /*" -705- MOVE 2 TO W-REGISTROS */
                _.Move(2, WAREA_AUXILIAR.W_REGISTROS);

                /*" -707- MOVE 675 TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA. */
                _.Move(675, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);
            }


            /*" -708- IF MOVIMVGA-COD-OPERACAO GREATER 699 AND LESS 900 */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 699 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 900)
            {

                /*" -709- MOVE 2 TO W-REGISTROS */
                _.Move(2, WAREA_AUXILIAR.W_REGISTROS);

                /*" -711- MOVE 103 TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA. */
                _.Move(103, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);
            }


            /*" -712- IF MOVIMVGA-COD-OPERACAO GREATER 899 */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 899)
            {

                /*" -713- DISPLAY 'PF0716B - FIM ANORMAL' */
                _.Display($"PF0716B - FIM ANORMAL");

                /*" -714- DISPLAY '          OPERACAO NAO ESPERADA' */
                _.Display($"          OPERACAO NAO ESPERADA");

                /*" -717- DISPLAY '          CERTIFICADO / TERMO.. ' PROPOFID-NUM-PROPOSTA-SIVPF '  ' TERMOADE-NUM-TERMO */

                $"          CERTIFICADO / TERMO.. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}  {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}"
                .Display();

                /*" -718- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -718- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_SAIDA*/

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-SECTION */
        private void R0450_00_OBTER_COBERTURA_SECTION()
        {
            /*" -728- MOVE 'R0450-00-OBTER-COBERTURA' TO PARAGRAFO. */
            _.Move("R0450-00-OBTER-COBERTURA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -730- MOVE 'SELECT COBERPROPVA' TO COMANDO. */
            _.Move("SELECT COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -732- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO HISCOBPR-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);

            /*" -734- MOVE 2 TO W-COBERTURAS */
            _.Move(2, WAREA_AUXILIAR.W_COBERTURAS);

            /*" -749- PERFORM R0450_00_OBTER_COBERTURA_DB_DECLARE_1 */

            R0450_00_OBTER_COBERTURA_DB_DECLARE_1();

            /*" -751- PERFORM R0450_00_OBTER_COBERTURA_DB_OPEN_1 */

            R0450_00_OBTER_COBERTURA_DB_OPEN_1();

            /*" -754- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -755- DISPLAY 'PF0716B - FIM ANORMAL' */
                _.Display($"PF0716B - FIM ANORMAL");

                /*" -756- DISPLAY '          ERRO OPEN DO CURSOR COBERTURAS' */
                _.Display($"          ERRO OPEN DO CURSOR COBERTURAS");

                /*" -758- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -760- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -762- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -763- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -765- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -775- PERFORM R0450_00_OBTER_COBERTURA_DB_FETCH_1 */

            R0450_00_OBTER_COBERTURA_DB_FETCH_1();

            /*" -778- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -779- DISPLAY 'PF0716B - FIM ANORMAL' */
                _.Display($"PF0716B - FIM ANORMAL");

                /*" -780- DISPLAY '          ERRO FETCH DO CURSOR COBERTURAS' */
                _.Display($"          ERRO FETCH DO CURSOR COBERTURAS");

                /*" -782- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -784- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -786- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -787- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -789- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -789- PERFORM R0450_00_OBTER_COBERTURA_DB_CLOSE_1 */

            R0450_00_OBTER_COBERTURA_DB_CLOSE_1();

            /*" -792- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -793- DISPLAY 'PF0716B - FIM ANORMAL' */
                _.Display($"PF0716B - FIM ANORMAL");

                /*" -794- DISPLAY '          ERRO CLOSE DO CURSOR COBERTURAS' */
                _.Display($"          ERRO CLOSE DO CURSOR COBERTURAS");

                /*" -796- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -798- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -800- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -801- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -803- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -803- MOVE 1 TO W-COBERTURAS. */
            _.Move(1, WAREA_AUXILIAR.W_COBERTURAS);

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-OPEN-1 */
        public void R0450_00_OBTER_COBERTURA_DB_OPEN_1()
        {
            /*" -751- EXEC SQL OPEN COBERTURAS END-EXEC. */

            COBERTURAS.Open();

        }

        [StopWatch]
        /*" R0710-OBTER-NIVEL-EMPRESA-DB-DECLARE-1 */
        public void R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1()
        {
            /*" -883- EXEC SQL DECLARE TER-NIVEL CURSOR FOR SELECT NUM_PROPOSTA_SIVPF, DTH_INI_VIGENCIA , NUM_NIVEL_CARGO , DTH_FIM_VIGENCIA , IMP_SEGURADA , VLR_PRM_INDIVIDUAL, QTD_VIDAS FROM SEGUROS.VG_TERMO_NIVEL WHERE NUM_PROPOSTA_SIVPF = :VGTERNIV-NUM-PROPOSTA-SIVPF AND DTH_INI_VIGENCIA <= :MOVIMVGA-DATA-MOVIMENTO AND DTH_FIM_VIGENCIA >= :MOVIMVGA-DATA-MOVIMENTO ORDER BY NUM_NIVEL_CARGO WITH UR END-EXEC. */
            TER_NIVEL = new PF0716B_TER_NIVEL(true);
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
							AND DTH_INI_VIGENCIA <= '{MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO}' 
							AND DTH_FIM_VIGENCIA >= '{MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO}' 
							ORDER BY NUM_NIVEL_CARGO";

                return query;
            }
            TER_NIVEL.GetQueryEvent += GetQuery_TER_NIVEL;

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-FETCH-1 */
        public void R0450_00_OBTER_COBERTURA_DB_FETCH_1()
        {
            /*" -775- EXEC SQL FETCH COBERTURAS INTO :HISCOBPR-NUM-CERTIFICADO , :HISCOBPR-OCORR-HISTORICO , :HISCOBPR-DATA-INIVIGENCIA , :HISCOBPR-DATA-TERVIGENCIA , :HISCOBPR-IMP-MORNATU , :HISCOBPR-IMPMORACID , :HISCOBPR-IMPINVPERM , :HISCOBPR-VLPREMIO END-EXEC. */

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
            /*" -789- EXEC SQL CLOSE COBERTURAS END-EXEC. */

            COBERTURAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_SAIDA*/

        [StopWatch]
        /*" R0580-00-LER-HIST-FIDELIZ-SECTION */
        private void R0580_00_LER_HIST_FIDELIZ_SECTION()
        {
            /*" -813- MOVE 'R0580-00-LER-HIST-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0580-00-LER-HIST-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -815- MOVE 'SELECT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("SELECT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -818- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -821- MOVE R1-SIT-PROPOSTA OF REG-STA-PROPOSTA TO PROPFIDH-SIT-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -824- MOVE R1-SIT-MOTIVO OF REG-STA-PROPOSTA TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -827- MOVE MOVIMVGA-DATA-MOVIMENTO TO PROPFIDH-DATA-SITUACAO. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -836- PERFORM R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1 */

            R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1();

            /*" -839- IF SQLCODE NOT EQUAL 00 AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -840- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -841- MOVE 2 TO W-HISTORICO */
                    _.Move(2, WAREA_AUXILIAR.W_HISTORICO);

                    /*" -842- ELSE */
                }
                else
                {


                    /*" -843- DISPLAY 'PF0716B - FIM ANORMAL' */
                    _.Display($"PF0716B - FIM ANORMAL");

                    /*" -844- DISPLAY '          ERRO ACESSO HIST-PROP-FIDELIZ' */
                    _.Display($"          ERRO ACESSO HIST-PROP-FIDELIZ");

                    /*" -846- DISPLAY '          NUMERO DA PROPOSTA.. ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO DA PROPOSTA.. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -848- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -849- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -850- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -851- ELSE */
                }

            }
            else
            {


                /*" -851- MOVE 1 TO W-HISTORICO. */
                _.Move(1, WAREA_AUXILIAR.W_HISTORICO);
            }


        }

        [StopWatch]
        /*" R0580-00-LER-HIST-FIDELIZ-DB-SELECT-1 */
        public void R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1()
        {
            /*" -836- EXEC SQL SELECT NUM_IDENTIFICACAO INTO :PROPFIDH-NUM-IDENTIFICACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPFIDH-NUM-IDENTIFICACAO AND DATA_SITUACAO = :PROPFIDH-DATA-SITUACAO AND SIT_PROPOSTA = :PROPFIDH-SIT-PROPOSTA AND SIT_MOTIVO_SIVPF = :PROPFIDH-SIT-MOTIVO-SIVPF WITH UR END-EXEC. */

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
            /*" -858- MOVE 'R0710-OBTER-NIVEL-EMPRESA  ' TO PARAGRAFO. */
            _.Move("R0710-OBTER-NIVEL-EMPRESA  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -860- MOVE 'DECLARE CURSOR TER-NIVEL' TO COMANDO. */
            _.Move("DECLARE CURSOR TER-NIVEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -862- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO VGTERNIV-NUM-PROPOSTA-SIVPF */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF);

            /*" -864- MOVE 'N' TO W-FIM-TERNIV. */
            _.Move("N", WAREA_AUXILIAR.W_FIM_TERNIV);

            /*" -883- PERFORM R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1 */

            R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1();

            /*" -887- MOVE 'OPEN CURSOR TER-NIVEL' TO COMANDO. */
            _.Move("OPEN CURSOR TER-NIVEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -887- PERFORM R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1 */

            R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1();

            /*" -890- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -893- DISPLAY 'PF0642E - ERRO NO OPEN DO CURSOR TER-NIVEL ' SQLCODE '  ' VGTERNIV-NUM-PROPOSTA-SIVPF '  ' VGTERNIV-DTH-FIM-VIGENCIA */

                $"PF0642E - ERRO NO OPEN DO CURSOR TER-NIVEL {DB.SQLCODE}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA}"
                .Display();

                /*" -894- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -894- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0710-OBTER-NIVEL-EMPRESA-DB-OPEN-1 */
        public void R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1()
        {
            /*" -887- EXEC SQL OPEN TER-NIVEL END-EXEC. */

            TER_NIVEL.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_SAIDA*/

        [StopWatch]
        /*" R0715-FETCH-NIVEL-EMPRESA-SECTION */
        private void R0715_FETCH_NIVEL_EMPRESA_SECTION()
        {
            /*" -901- MOVE 'R0715-FETCH-NIVEL-EMPRESA' TO PARAGRAFO. */
            _.Move("R0715-FETCH-NIVEL-EMPRESA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -903- MOVE 'FETCH CURSOR TER-NIVEL' TO COMANDO. */
            _.Move("FETCH CURSOR TER-NIVEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -913- PERFORM R0715_FETCH_NIVEL_EMPRESA_DB_FETCH_1 */

            R0715_FETCH_NIVEL_EMPRESA_DB_FETCH_1();

            /*" -916- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -917- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -918- IF W-IND-NIVEL EQUAL 1 */

                    if (WAREA_AUXILIAR.W_IND_NIVEL == 1)
                    {

                        /*" -920- DISPLAY 'PF0642E - FIM ANORMAL - NIVEL NAO CADASTRADO ' PROPOFID-NUM-PROPOSTA-SIVPF */
                        _.Display($"PF0642E - FIM ANORMAL - NIVEL NAO CADASTRADO {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                        /*" -921- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -922- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -923- ELSE */
                    }
                    else
                    {


                        /*" -924- MOVE 'S' TO W-FIM-TERNIV */
                        _.Move("S", WAREA_AUXILIAR.W_FIM_TERNIV);

                        /*" -924- PERFORM R0715_FETCH_NIVEL_EMPRESA_DB_CLOSE_1 */

                        R0715_FETCH_NIVEL_EMPRESA_DB_CLOSE_1();

                        /*" -926- IF SQLCODE NOT EQUAL ZEROS */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -929- DISPLAY 'PF0642E - ERRO CLOSE DO CURSOR TER-NIVEL ' SQLCODE '  ' VGTERNIV-NUM-PROPOSTA-SIVPF '  ' VGTERNIV-DTH-FIM-VIGENCIA */

                            $"PF0642E - ERRO CLOSE DO CURSOR TER-NIVEL {DB.SQLCODE}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA}"
                            .Display();

                            /*" -930- PERFORM R9988-00-FECHAR-ARQUIVOS */

                            R9988_00_FECHAR_ARQUIVOS_SECTION();

                            /*" -931- PERFORM R9999-00-FINALIZAR */

                            R9999_00_FINALIZAR_SECTION();

                            /*" -933- ELSE NEXT SENTENCE */
                        }
                        else
                        {


                            /*" -934- ELSE */
                        }

                    }

                }
                else
                {


                    /*" -937- DISPLAY 'PF0642E - ERRO NO FETCH DO CURSOR TER-NIVEL ' SQLCODE '  ' VGTERNIV-NUM-PROPOSTA-SIVPF '  ' VGTERNIV-DTH-FIM-VIGENCIA */

                    $"PF0642E - ERRO NO FETCH DO CURSOR TER-NIVEL {DB.SQLCODE}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA}"
                    .Display();

                    /*" -938- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -938- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0715-FETCH-NIVEL-EMPRESA-DB-FETCH-1 */
        public void R0715_FETCH_NIVEL_EMPRESA_DB_FETCH_1()
        {
            /*" -913- EXEC SQL FETCH TER-NIVEL INTO :VGTERNIV-NUM-PROPOSTA-SIVPF, :VGTERNIV-DTH-INI-VIGENCIA , :VGTERNIV-NUM-NIVEL-CARGO , :VGTERNIV-DTH-FIM-VIGENCIA , :VGTERNIV-IMP-SEGURADA , :VGTERNIV-VLR-PRM-INDIVIDUAL, :VGTERNIV-QTD-VIDAS END-EXEC. */

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
            /*" -924- EXEC SQL CLOSE TER-NIVEL END-EXEC */

            TER_NIVEL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0715_SAIDA*/

        [StopWatch]
        /*" R0720-MONTA-NIVEL-CARGO-SECTION */
        private void R0720_MONTA_NIVEL_CARGO_SECTION()
        {
            /*" -945- MOVE 'R0720-MONTA-NIVEL-CARGO' TO PARAGRAFO. */
            _.Move("R0720-MONTA-NIVEL-CARGO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -947- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -948- IF W-IND-NIVEL LESS 5 */

            if (WAREA_AUXILIAR.W_IND_NIVEL < 5)
            {

                /*" -951- MOVE VGTERNIV-NUM-NIVEL-CARGO TO R5-NUM-NIVEL-CARGO (W-IND-NIVEL) */
                _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_NIVEL_CARGO, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_NOVO.R5_DADOS_NIVEL[WAREA_AUXILIAR.W_IND_NIVEL].R5_NUM_NIVEL_CARGO);

                /*" -954- MOVE VGTERNIV-IMP-SEGURADA TO R5-IMP-SEGURADA (W-IND-NIVEL) */
                _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_IMP_SEGURADA, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_NOVO.R5_DADOS_NIVEL[WAREA_AUXILIAR.W_IND_NIVEL].R5_IMP_SEGURADA);

                /*" -957- MOVE VGTERNIV-QTD-VIDAS TO R5-QUANTIDADE-VIDAS (W-IND-NIVEL). */
                _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_QTD_VIDAS, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_NOVO.R5_DADOS_NIVEL[WAREA_AUXILIAR.W_IND_NIVEL].R5_QUANTIDADE_VIDAS);
            }


            /*" -958- IF W-IND-NIVEL GREATER 5 */

            if (WAREA_AUXILIAR.W_IND_NIVEL > 5)
            {

                /*" -960- DISPLAY 'PF0642E - FIM ANORMAL, ESTOURO DE NIVEIS  ' SQLCODE '  ' VGTERNIV-NUM-PROPOSTA-SIVPF */

                $"PF0642E - FIM ANORMAL, ESTOURO DE NIVEIS  {DB.SQLCODE}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}"
                .Display();

                /*" -961- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -963- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -963- ADD 1 TO W-IND-NIVEL. */
            WAREA_AUXILIAR.W_IND_NIVEL.Value = WAREA_AUXILIAR.W_IND_NIVEL + 1;

            /*" -0- FLUXCONTROL_PERFORM R0720_NEXT */

            R0720_NEXT();

        }

        [StopWatch]
        /*" R0720-NEXT */
        private void R0720_NEXT(bool isPerform = false)
        {
            /*" -967- PERFORM R0715-FETCH-NIVEL-EMPRESA. */

            R0715_FETCH_NIVEL_EMPRESA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0720_SAIDA*/

        [StopWatch]
        /*" R0800-00-STATUS-REGISTRO-TP1-SECTION */
        private void R0800_00_STATUS_REGISTRO_TP1_SECTION()
        {
            /*" -979- MOVE 'R0800-00-STATUS-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0800-00-STATUS-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -982- MOVE '1' TO R1-TIPO-REG OF REG-STA-PROPOSTA. */
            _.Move("1", LBFCT011.REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -985- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -988- MOVE MOVIMVGA-DATA-MOVIMENTO TO W-DATA-SQL. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -989- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -990- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -992- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -995- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -997- ADD 1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + 1;

            /*" -1000- MOVE RH-NSAS OF REG-HEADER-STA TO R1-NSAS OF REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, LBFCT011.REG_STA_PROPOSTA.R1_NSAS);

            /*" -1003- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO R1-NSL OF REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, LBFCT011.REG_STA_PROPOSTA.R1_NSL);

            /*" -1003- WRITE REG-STA-SASSE FROM REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-STATUS-REGISTRO-TP2-SECTION */
        private void R0850_00_STATUS_REGISTRO_TP2_SECTION()
        {
            /*" -1014- MOVE 'R0850-00-STATUS-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0850-00-STATUS-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1017- MOVE '2' TO R2-TIPO-REG OF REG-APOL-SASSE */
            _.Move("2", LBFCT016.REG_APOL_SASSE.R2_TIPO_REG);

            /*" -1021- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R2-NUM-PROPOSTA OF REG-APOL-SASSE R2-NRCERTIF OF REG-APOL-SASSE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT016.REG_APOL_SASSE.R2_NUM_PROPOSTA, LBFCT016.REG_APOL_SASSE.R2_NRCERTIF);

            /*" -1024- MOVE VGTERNIV-DTH-INI-VIGENCIA TO W-DATA-SQL. */
            _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1025- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -1026- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -1028- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -1031- MOVE W-DATA-TRABALHO TO R2-DTINIVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTINIVIG);

            /*" -1034- MOVE VGTERNIV-DTH-FIM-VIGENCIA TO W-DATA-SQL. */
            _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1035- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -1036- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -1039- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -1042- MOVE 31129999 TO R2-DTTERVIG OF REG-APOL-SASSE. */
            _.Move(31129999, LBFCT016.REG_APOL_SASSE.R2_DTTERVIG);

            /*" -1043- PERFORM R0860-LER-APOLICE */

            R0860_LER_APOLICE_SECTION();

            /*" -1045- PERFORM R0870-LER-RAMOIND */

            R0870_LER_RAMOIND_SECTION();

            /*" -1047- COMPUTE W-IND-IOF = (RAMOCOMP-PCT-IOCC-RAMO / 100) + 1 */
            WAREA_AUXILIAR.W_IND_IOF.Value = (RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f) + 1;

            /*" -1049- COMPUTE W-PRM-LIQ = HISCOBPR-VLPREMIO / W-IND-IOF */
            WAREA_AUXILIAR.W_PRM_LIQ.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO / WAREA_AUXILIAR.W_IND_IOF;

            /*" -1052- COMPUTE R2-VAL-IOF OF REG-APOL-SASSE ROUNDED = HISCOBPR-VLPREMIO - W-PRM-LIQ */
            LBFCT016.REG_APOL_SASSE.R2_VAL_IOF.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO - WAREA_AUXILIAR.W_PRM_LIQ;

            /*" -1054- MOVE W-PRM-LIQ TO R2-VAL-PREMIO OF REG-APOL-SASSE */
            _.Move(WAREA_AUXILIAR.W_PRM_LIQ, LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO);

            /*" -1056- ADD 1 TO RT-QTDE-TIPO-2 OF REG-TRAILLER-STA */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + 1;

            /*" -1056- WRITE REG-STA-SASSE FROM REG-APOL-SASSE. */
            _.Move(LBFCT016.REG_APOL_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R0860-LER-APOLICE-SECTION */
        private void R0860_LER_APOLICE_SECTION()
        {
            /*" -1066- MOVE 'R0860-00-LER-APOLICE' TO PARAGRAFO. */
            _.Move("R0860-00-LER-APOLICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1068- MOVE 'SELECT TABELA APOLICE' TO COMANDO. */
            _.Move("SELECT TABELA APOLICE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1070- MOVE TERMOADE-NUM-APOLICE TO APOLICES-NUM-APOLICE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -1078- PERFORM R0860_LER_APOLICE_DB_SELECT_1 */

            R0860_LER_APOLICE_DB_SELECT_1();

            /*" -1081- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1082- DISPLAY 'PF0716B - FIM ANORMAL' */
                _.Display($"PF0716B - FIM ANORMAL");

                /*" -1083- DISPLAY '          ERRO SELECT TABELA APOLICE' */
                _.Display($"          ERRO SELECT TABELA APOLICE");

                /*" -1085- DISPLAY '          NUMERO DO TERMO ADESAO.... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO.... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1087- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -1088- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1088- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0860-LER-APOLICE-DB-SELECT-1 */
        public void R0860_LER_APOLICE_DB_SELECT_1()
        {
            /*" -1078- EXEC SQL SELECT RAMO_EMISSOR INTO :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE WITH UR END-EXEC. */

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
            /*" -1098- MOVE 'R0870-00-LER-RAMOIND' TO PARAGRAFO. */
            _.Move("R0870-00-LER-RAMOIND", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1100- MOVE 'SELECT TABELA RAMOIND' TO COMANDO. */
            _.Move("SELECT TABELA RAMOIND", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1110- PERFORM R0870_LER_RAMOIND_DB_SELECT_1 */

            R0870_LER_RAMOIND_DB_SELECT_1();

            /*" -1113- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1114- DISPLAY 'PF0716B - FIM ANORMAL' */
                _.Display($"PF0716B - FIM ANORMAL");

                /*" -1115- DISPLAY '          ERRO SELECT TAB. RAMO COMPLEMENTAR' */
                _.Display($"          ERRO SELECT TAB. RAMO COMPLEMENTAR");

                /*" -1117- DISPLAY '          NUMERO DO TERMO ADESAO.... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO.... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1119- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -1120- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1120- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0870-LER-RAMOIND-DB-SELECT-1 */
        public void R0870_LER_RAMOIND_DB_SELECT_1()
        {
            /*" -1110- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR AND DATA_INIVIGENCIA <= :VGTERNIV-DTH-INI-VIGENCIA AND DATA_TERVIGENCIA >= :VGTERNIV-DTH-INI-VIGENCIA WITH UR END-EXEC. */

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
            /*" -1131- MOVE 'R0900-00-STATUS-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0900-00-STATUS-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1134- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -1137- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -1139- MOVE PROPOFID-COD-PRODUTO-SIVPF TO W-SUBPRODUTO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, WAREA_AUXILIAR.FILLER_1.W_SUBPRODUTO);

            /*" -1140- IF HISCOBPR-IMP-MORNATU GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU > 00)
            {

                /*" -1142- MOVE HISCOBPR-IMP-MORNATU TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -1143- MOVE 1 TO W-COBERTURA */
                _.Move(1, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                /*" -1145- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -1147- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -1149- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -1150- IF HISCOBPR-IMPMORACID GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID > 00)
            {

                /*" -1152- MOVE HISCOBPR-IMPMORACID TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -1153- MOVE 2 TO W-COBERTURA */
                _.Move(2, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                /*" -1155- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -1157- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -1159- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -1160- IF HISCOBPR-IMPINVPERM GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM > 00)
            {

                /*" -1162- MOVE HISCOBPR-IMPINVPERM TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -1163- MOVE 3 TO W-COBERTURA */
                _.Move(3, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                /*" -1165- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -1167- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -1167- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_SAIDA*/

        [StopWatch]
        /*" R0950-00-STATUS-REGISTRO-TP4-SECTION */
        private void R0950_00_STATUS_REGISTRO_TP4_SECTION()
        {
            /*" -1178- MOVE 'R0990-00-STATUS-REGISTRO-TP4' TO PARAGRAFO. */
            _.Move("R0990-00-STATUS-REGISTRO-TP4", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1181- MOVE '4' TO R4-TIPO-REG OF REG-PGTO-SASSE. */
            _.Move("4", LBFCT016.REG_PGTO_SASSE.R4_TIPO_REG);

            /*" -1184- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R4-NUM-PROPOSTA OF REG-PGTO-SASSE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA);

            /*" -1185- IF MOVIMVGA-COD-OPERACAO GREATER 399 AND LESS 500 */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 399 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 500)
            {

                /*" -1187- MOVE MOVIMVGA-DATA-MOVIMENTO TO W-DATA-SQL */
                _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -1188- ELSE */
            }
            else
            {


                /*" -1191- MOVE PROPOVA-DATA-QUITACAO TO W-DATA-SQL. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);
            }


            /*" -1192- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -1193- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -1195- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -1198- MOVE W-DATA-TRABALHO TO R4-DATA-SITUACAO OF REG-PGTO-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO);

            /*" -1201- MOVE PROPOVA-NUM-PARCELA TO R4-PARCELAS-PAGAS OF REG-PGTO-SASSE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA, LBFCT016.REG_PGTO_SASSE.R4_PARCELAS_PAGAS);

            /*" -1204- MOVE 999999 TO R4-TOTAL-PARCELAS OF REG-PGTO-SASSE */
            _.Move(999999, LBFCT016.REG_PGTO_SASSE.R4_TOTAL_PARCELAS);

            /*" -1206- WRITE REG-STA-SASSE FROM REG-PGTO-SASSE. */
            _.Move(LBFCT016.REG_PGTO_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1206- ADD 1 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_SAIDA*/

        [StopWatch]
        /*" R0970-00-STATUS-REGISTRO-TP5-SECTION */
        private void R0970_00_STATUS_REGISTRO_TP5_SECTION()
        {
            /*" -1217- MOVE 'R0970-00-STATUS-REGISTRO-TP5' TO PARAGRAFO. */
            _.Move("R0970-00-STATUS-REGISTRO-TP5", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1218- MOVE 5 TO R5-TIPO-REG. */
            _.Move(5, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_TIPO_REG);

            /*" -1224- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R5-NUM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_NUM_PROPOSTA);

            /*" -1226- WRITE REG-STA-SASSE FROM R5-REG-QTDE-VIDAS-VE */
            _.Move(LBFPF200.R5_REG_QTDE_VIDAS_VE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1226- ADD 1 TO RT-QTDE-TIPO-5 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0970_SAIDA*/

        [StopWatch]
        /*" R1000-00-GERAR-TRAILLER-SECTION */
        private void R1000_00_GERAR_TRAILLER_SECTION()
        {
            /*" -1236- MOVE 'R1000-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R1000-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1238- MOVE 'WRITE REG-TRAILLER - STATUS' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER - STATUS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1240- MOVE SPACES TO REG-STA-SASSE. */
            _.Move("", REG_STA_SASSE);

            /*" -1243- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -1246- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -1257- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 OF REG-TRAILLER-STA + RT-QTDE-TIPO-2 OF REG-TRAILLER-STA + RT-QTDE-TIPO-3 OF REG-TRAILLER-STA + RT-QTDE-TIPO-4 OF REG-TRAILLER-STA + RT-QTDE-TIPO-5 OF REG-TRAILLER-STA + RT-QTDE-TIPO-6 OF REG-TRAILLER-STA + RT-QTDE-TIPO-7 OF REG-TRAILLER-STA + RT-QTDE-TIPO-8 OF REG-TRAILLER-STA + RT-QTDE-TIPO-9 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -1257- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -1267- MOVE 'R1050-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R1050-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1269- MOVE 'INSERT ARQUIVOS-SIVPF - STATUS' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF - STATUS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1272- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -1275- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -1279- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -1282- MOVE RH-NSAS OF REG-HEADER-STA TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -1285- MOVE RT-QTDE-TOTAL OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -1293- PERFORM R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -1296- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1297- DISPLAY 'PF0716B - FIM ANORMAL' */
                _.Display($"PF0716B - FIM ANORMAL");

                /*" -1298- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -1300- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -1302- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -1304- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -1306- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -1308- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -1309- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1309- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -1293- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
            /*" -1320- MOVE 'R1100-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R1100-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1322- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1323- DISPLAY 'PF0716B - TOTAIS DO PROCESSAMENTO' */
            _.Display($"PF0716B - TOTAIS DO PROCESSAMENTO");

            /*" -1324- DISPLAY '          TOTAL  REGISTROS LIDOS........... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS........... {WAREA_AUXILIAR.W_NSL}");

            /*" -1326- DISPLAY '          TOTAL  DESPREZADO................ ' W-DESPREZADO */
            _.Display($"          TOTAL  DESPREZADO................ {WAREA_AUXILIAR.W_DESPREZADO}");

            /*" -1327- DISPLAY '          TOTAL  GERADO ARQUIVO STATUS..... ' RT-QTDE-TIPO-1 OF REG-TRAILLER-STA. */
            _.Display($"          TOTAL  GERADO ARQUIVO STATUS..... {LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-SECTION */
        private void R3390_GERA_HIST_FIDELIZACAO_SECTION()
        {
            /*" -1336- MOVE 'R3390-GERA-HIST-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3390-GERA-HIST-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1338- MOVE 'INSERT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1341- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1344- MOVE MOVIMVGA-DATA-MOVIMENTO TO PROPFIDH-DATA-SITUACAO. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -1347- MOVE RH-NSAS OF REG-HEADER-STA TO PROPFIDH-NSAS-SIVPF. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -1350- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO PROPFIDH-NSL. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -1353- MOVE R1-SIT-PROPOSTA OF REG-STA-PROPOSTA TO PROPFIDH-SIT-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1356- MOVE R4-SIT-COBRANCA OF REG-PGTO-SASSE TO PROPFIDH-SIT-COBRANCA-SIVPF. */
            _.Move(LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -1359- MOVE R1-SIT-MOTIVO OF REG-STA-PROPOSTA TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -1362- MOVE PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -1366- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -1377- PERFORM R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1 */

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1();

            /*" -1380- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1381- DISPLAY 'PF0716B - FIM ANORMAL' */
                _.Display($"PF0716B - FIM ANORMAL");

                /*" -1382- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -1385- DISPLAY '          PROPOSTA / IDENTIFICACAO ' PROPOFID-NUM-PROPOSTA-SIVPF '  ' PROPOFID-NUM-IDENTIFICACAO */

                $"          PROPOSTA / IDENTIFICACAO {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}"
                .Display();

                /*" -1387- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1388- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1388- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-DB-INSERT-1 */
        public void R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -1377- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

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
            /*" -1398- MOVE 'R3400-00-ATUALIZA-PROPOSTA' TO PARAGRAFO. */
            _.Move("R3400-00-ATUALIZA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1400- MOVE 'UPDATE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1401- MOVE 'PF0716B' TO PROPOFID-COD-USUARIO. */
            _.Move("PF0716B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -1403- MOVE 'R' TO PROPOFID-SITUACAO-ENVIO. */
            _.Move("R", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -1405- MOVE PROPFIDH-NSL TO PROPOFID-NSL. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);

            /*" -1407- MOVE PROPFIDH-NSAS-SIVPF TO PROPOFID-NSAS-SIVPF. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);

            /*" -1409- MOVE PROPFIDH-SIT-PROPOSTA TO PROPOFID-SIT-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -1417- PERFORM R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1 */

            R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1();

            /*" -1420- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1421- DISPLAY 'PF0716B - FIM ANORMAL' */
                _.Display($"PF0716B - FIM ANORMAL");

                /*" -1422- DISPLAY '          ERRO UPDATE PROPOSTA-FIDELIZ' */
                _.Display($"          ERRO UPDATE PROPOSTA-FIDELIZ");

                /*" -1424- DISPLAY '          PROPOSTA................... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          PROPOSTA................... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1426- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1427- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1427- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3400-00-ATUALIZA-PROPOSTA-DB-UPDATE-1 */
        public void R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1()
        {
            /*" -1417- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET NSAS_SIVPF = :PROPOFID-NSAS-SIVPF, NSL = :PROPOFID-NSL, SIT_PROPOSTA = :PROPOFID-SIT-PROPOSTA, COD_USUARIO = :PROPOFID-COD-USUARIO, SITUACAO_ENVIO = :PROPOFID-SITUACAO-ENVIO WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

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
            /*" -1436- CLOSE MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -1447- DISPLAY ' ' */
            _.Display($" ");

            /*" -1448- IF W-FIM-MOVTO-TERMO = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM")
            {

                /*" -1449- DISPLAY 'PF0716B - FIM NORMAL' */
                _.Display($"PF0716B - FIM NORMAL");

                /*" -1450- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1451- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1451- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1453- ELSE */
            }
            else
            {


                /*" -1454- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_3.WSQLCODE);

                /*" -1455- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_3.WSQLERRD1);

                /*" -1456- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_3.WSQLERRD2);

                /*" -1457- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -1458- DISPLAY '*** PF0716B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0716B *** ROLLBACK EM ANDAMENTO ...");

                /*" -1459- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1459- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -1462- MOVE 09 TO RETURN-CODE. */
                _.Move(09, RETURN_CODE);
            }


            /*" -1462- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}