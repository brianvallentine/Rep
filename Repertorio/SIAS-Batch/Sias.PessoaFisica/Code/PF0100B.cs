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
using Sias.PessoaFisica.DB2.PF0100B;

namespace Code
{
    public class PF0100B
    {
        public bool IsCall { get; set; }

        public PF0100B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ...............  GERA MOVIMENTO PARA SENSIBILIZACAO   *      */
        /*"      *                           DO SIDEM.                            *      */
        /*"      *   ANALISE/PROGRAMACAO...  LUIZ CARLOS.                         *      */
        /*"      *   PROGRAMA .............  PF0100B                              *      */
        /*"      *   REVISAO ..............  REGINALDO DA SILVA                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ATUALIZACOES.                                                *      */
        /*"      *   ------------                                                 *      */
        /*"      *    O PROGRAMA PASSOU A GERAR ARQUIVOS SEPARADOS DE ACORDO COM  *      */
        /*"      *    A EMPRESA DA PROPOSTA, (SEGUROS, PREV. E CAP.). A NUMERACAO *      */
        /*"      *    DOS ARQUIVOS DA PREV E CAP ESTA SENDO COM BASE NO ULTIMO NU *      */
        /*"      *    MERO DE ARQUIVO DA TABELA ARQUIVOS_SIVPF, POIS ESTA NUMERA- *      */
        /*"      *    CAO    CONTROLADA POR ESSAS EMPRESAS. (PROCURE V01)         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 03             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       12/05/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 02             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA                          *      */
        /*"      *                       10/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     *----------------------------------------------------------------*      */
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
        public FileBasis _MOVTO_STA_PREV { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOVTO_STA_PREV
        {
            get
            {
                _.Move(REG_STA_PREV, _MOVTO_STA_PREV); VarBasis.RedefinePassValue(REG_STA_PREV, _MOVTO_STA_PREV, REG_STA_PREV); return _MOVTO_STA_PREV;
            }
        }
        public FileBasis _MOVTO_STA_CAP { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOVTO_STA_CAP
        {
            get
            {
                _.Move(REG_STA_CAP, _MOVTO_STA_CAP); VarBasis.RedefinePassValue(REG_STA_CAP, _MOVTO_STA_CAP, REG_STA_CAP); return _MOVTO_STA_CAP;
            }
        }
        /*"01   REG-STA-SASSE                      PIC X(100).*/
        public StringBasis REG_STA_SASSE { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"01   REG-STA-PREV                       PIC X(100).*/
        public StringBasis REG_STA_PREV { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"01   REG-STA-CAP                        PIC X(100).*/
        public StringBasis REG_STA_CAP { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  DATA-LIB-STA-PEN                 PIC  X(010).*/
        public StringBasis DATA_LIB_STA_PEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WAREA-AUXILIAR.*/
        public PF0100B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0100B_WAREA_AUXILIAR();
        public class PF0100B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-MOVTO-FIDELIZ           PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-TIME                        PIC  9(08).*/
            public IntBasis W_TIME { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    05  W-TIME-EDIT                   PIC  99.99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"    05  W-CONTROLE                    PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-QTD-LD-TIPO-0               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-1               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-2               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-3               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-4               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-5               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-6               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-7               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-8               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-9               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-LIDO                        PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_LIDO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-TOT-GERADO-STA              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_TOT_GERADO_STA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-NSAS                        PIC 9(006).*/
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSL                         PIC 9(006).*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0100B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0100B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0100B_FILLER_0(); _.Move(W_DATA_TRABALHO, _filler_0); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_0, W_DATA_TRABALHO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_DATA_TRABALHO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0100B_FILLER_0 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0100B_FILLER_0()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0100B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0100B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0100B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0100B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0100B_W_DTMOVABE1()
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
            private _REDEF_PF0100B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0100B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0100B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0100B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0100B_W_DTMOVABE_I1()
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
            private _REDEF_PF0100B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0100B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0100B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0100B_W_DATA_SQL1 : VarBasis
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
                /*"    05 W-COD-EMPRESA-SIVPF            PIC  9(002) VALUE ZERO.*/

                public _REDEF_PF0100B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_COD_EMPRESA_SIVPF { get; set; } = new SelectorBasis("002", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CAIXA-SEGUROS                           VALUE 01. */
							new SelectorItemBasis("CAIXA_SEGUROS", "01"),
							/*" 88 CAIXA-PREVIDENCIA                       VALUE 02. */
							new SelectorItemBasis("CAIXA_PREVIDENCIA", "02"),
							/*" 88 CAIXA-CAPITALIZACAO                     VALUE 03. */
							new SelectorItemBasis("CAIXA_CAPITALIZACAO", "03")
                }
            };

            /*"01  WABEND.*/
        }
        public PF0100B_WABEND WABEND { get; set; } = new PF0100B_WABEND();
        public class PF0100B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'PF0100B  '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0100B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      05      LOCALIZA-ABEND-1.*/
            public PF0100B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0100B_LOCALIZA_ABEND_1();
            public class PF0100B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        10    FILLER                  PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        10    PARAGRAFO               PIC  X(040)   VALUE SPACES*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      05      LOCALIZA-ABEND-2.*/
            }
            public PF0100B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0100B_LOCALIZA_ABEND_2();
            public class PF0100B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        10    FILLER                  PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        10    COMANDO                 PIC  X(060)   VALUE SPACES*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPFID PROPFID { get; set; } = new Dclgens.PROPFID();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public PF0100B_PROPOSTA_FIDELIZ PROPOSTA_FIDELIZ { get; set; } = new PF0100B_PROPOSTA_FIDELIZ();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_STA_SASSE_FILE_NAME_P, string MOVTO_STA_PREV_FILE_NAME_P, string MOVTO_STA_CAP_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO_STA_SASSE.SetFile(MOVTO_STA_SASSE_FILE_NAME_P);
                MOVTO_STA_PREV.SetFile(MOVTO_STA_PREV_FILE_NAME_P);
                MOVTO_STA_CAP.SetFile(MOVTO_STA_CAP_FILE_NAME_P);

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
            /*" -211- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -212- DISPLAY '*               PROGRAMA PF0100B               *' . */
            _.Display($"*               PROGRAMA PF0100B               *");

            /*" -213- DISPLAY '* GERA ARQ STATUS PARA SENSIBILIZACAO NO SIDEM *' . */
            _.Display($"* GERA ARQ STATUS PARA SENSIBILIZACAO NO SIDEM *");

            /*" -214- DISPLAY '*           VERSAO:  03 - 13/05/2014           *' . */
            _.Display($"*           VERSAO:  03 - 13/05/2014           *");

            /*" -215- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -223- DISPLAY '*  PF0100B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0100B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -225- DISPLAY '*' . */
            _.Display($"*");

            /*" -227- PERFORM R0001-00-INICIALIZAR. */

            R0001_00_INICIALIZAR_SECTION();

            /*" -230- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-FIDELIZ EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -232- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -232- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0001-00-INICIALIZAR-SECTION */
        private void R0001_00_INICIALIZAR_SECTION()
        {
            /*" -240- MOVE 'R0001-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0001-00-INICIALIZAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -242- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -243- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -245- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -247- DISPLAY 'PF0100B * INICIO  PROCESSAMENTO AS ==>  ' W-TIME-EDIT. */
            _.Display($"PF0100B * INICIO  PROCESSAMENTO AS ==>  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -250- DISPLAY ' ' . */
            _.Display($" ");

            /*" -251- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -253- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -255- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -260- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -262- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -264- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -267- PERFORM R0070-00-LER-MOVTO */

            R0070_00_LER_MOVTO_SECTION();

            /*" -268- IF W-FIM-MOVTO-FIDELIZ EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM")
            {

                /*" -269- DISPLAY '*-----------------------------*' */
                _.Display($"*-----------------------------*");

                /*" -270- DISPLAY '*---  PF0100B - FIM NORMAL ---*' */
                _.Display($"*---  PF0100B - FIM NORMAL ---*");

                /*" -271- DISPLAY '*---  NAO HOUVE MOVIMENTO  ---*' */
                _.Display($"*---  NAO HOUVE MOVIMENTO  ---*");

                /*" -272- DISPLAY '*-----------------------------*' */
                _.Display($"*-----------------------------*");

                /*" -273- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -273- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_SAIDA*/

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -283- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -285- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -287- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -293- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -298- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -300- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -302- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -305- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -307- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -293- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
            /*" -317- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -319- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -321- OPEN OUTPUT MOVTO-STA-SASSE MOVTO-STA-PREV MOVTO-STA-CAP. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);
            MOVTO_STA_PREV.Open(REG_STA_PREV);
            MOVTO_STA_CAP.Open(REG_STA_CAP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-SECTION */
        private void R0050_00_SELECIONA_MOVTO_SECTION()
        {
            /*" -331- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -333- MOVE 'DECLER PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("DECLER PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -334- MOVE '0' TO RELATORI-SIT-REGISTRO */
            _.Move("0", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -335- MOVE 'PF' TO RELATORI-IDE-SISTEMA */
            _.Move("PF", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -337- MOVE 'PF0100B' TO RELATORI-COD-RELATORIO */
            _.Move("PF0100B", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -389- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -392- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -396- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -397- DISPLAY 'PF0100B - FIM ANORMAL' */
                _.Display($"PF0100B - FIM ANORMAL");

                /*" -398- DISPLAY '          ERRO OPEN CURSOR PROPOSTA-FIDELIZ' */
                _.Display($"          ERRO OPEN CURSOR PROPOSTA-FIDELIZ");

                /*" -400- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -401- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -401- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -389- EXEC SQL DECLARE PROPOSTA-FIDELIZ CURSOR FOR SELECT A.NUM_PROPOSTA_SIVPF, A.NUM_IDENTIFICACAO, A.COD_EMPRESA_SIVPF, A.COD_PESSOA, A.NUM_SICOB, A.DATA_PROPOSTA, A.COD_PRODUTO_SIVPF, A.AGECOBR, A.DIA_DEBITO, A.OPCAOPAG, A.AGECTADEB, A.OPRCTADEB, A.NUMCTADEB, A.DIGCTADEB, A.PERC_DESCONTO, A.NRMATRVEN, A.AGECTAVEN, A.OPRCTAVEN, A.NUMCTAVEN, A.DIGCTAVEN, A.CGC_CONVENENTE, A.NOME_CONVENENTE, A.NRMATRCON, A.DTQITBCO, A.VAL_PAGO, A.AGEPGTO, A.VAL_TARIFA, A.VAL_IOF, A.DATA_CREDITO, A.VAL_COMISSAO, A.SIT_PROPOSTA, A.COD_USUARIO, A.CANAL_PROPOSTA, A.NSAS_SIVPF, A.ORIGEM_PROPOSTA, A.NSL, A.NSAC_SIVPF, A.SITUACAO_ENVIO, B.NUM_ENDOSSO FROM SEGUROS.PROPOSTA_FIDELIZ A, SEGUROS.RELATORIOS B WHERE A.NUM_PROPOSTA_SIVPF = B.NUM_CERTIFICADO AND B.SIT_REGISTRO = :RELATORI-SIT-REGISTRO AND B.IDE_SISTEMA = :RELATORI-IDE-SISTEMA AND B.COD_RELATORIO = :RELATORI-COD-RELATORIO ORDER BY A.COD_EMPRESA_SIVPF, A.NUM_PROPOSTA_SIVPF WITH UR END-EXEC. */
            PROPOSTA_FIDELIZ = new PF0100B_PROPOSTA_FIDELIZ(true);
            string GetQuery_PROPOSTA_FIDELIZ()
            {
                var query = @$"SELECT A.NUM_PROPOSTA_SIVPF
							, 
							A.NUM_IDENTIFICACAO
							, 
							A.COD_EMPRESA_SIVPF
							, 
							A.COD_PESSOA
							, 
							A.NUM_SICOB
							, 
							A.DATA_PROPOSTA
							, 
							A.COD_PRODUTO_SIVPF
							, 
							A.AGECOBR
							, 
							A.DIA_DEBITO
							, 
							A.OPCAOPAG
							, 
							A.AGECTADEB
							, 
							A.OPRCTADEB
							, 
							A.NUMCTADEB
							, 
							A.DIGCTADEB
							, 
							A.PERC_DESCONTO
							, 
							A.NRMATRVEN
							, 
							A.AGECTAVEN
							, 
							A.OPRCTAVEN
							, 
							A.NUMCTAVEN
							, 
							A.DIGCTAVEN
							, 
							A.CGC_CONVENENTE
							, 
							A.NOME_CONVENENTE
							, 
							A.NRMATRCON
							, 
							A.DTQITBCO
							, 
							A.VAL_PAGO
							, 
							A.AGEPGTO
							, 
							A.VAL_TARIFA
							, 
							A.VAL_IOF
							, 
							A.DATA_CREDITO
							, 
							A.VAL_COMISSAO
							, 
							A.SIT_PROPOSTA
							, 
							A.COD_USUARIO
							, 
							A.CANAL_PROPOSTA
							, 
							A.NSAS_SIVPF
							, 
							A.ORIGEM_PROPOSTA
							, 
							A.NSL
							, 
							A.NSAC_SIVPF
							, 
							A.SITUACAO_ENVIO
							, 
							B.NUM_ENDOSSO 
							FROM SEGUROS.PROPOSTA_FIDELIZ A
							, 
							SEGUROS.RELATORIOS B 
							WHERE A.NUM_PROPOSTA_SIVPF = B.NUM_CERTIFICADO 
							AND B.SIT_REGISTRO = '{RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO}' 
							AND B.IDE_SISTEMA = '{RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA}' 
							AND B.COD_RELATORIO = 
							'{RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}' 
							ORDER BY A.COD_EMPRESA_SIVPF
							, 
							A.NUM_PROPOSTA_SIVPF";

                return query;
            }
            PROPOSTA_FIDELIZ.GetQueryEvent += GetQuery_PROPOSTA_FIDELIZ;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -392- EXEC SQL OPEN PROPOSTA-FIDELIZ END-EXEC. */

            PROPOSTA_FIDELIZ.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -408- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -410- MOVE 'FETCH PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("FETCH PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -451- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -454- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -455- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -456- MOVE 'FIM' TO W-FIM-MOVTO-FIDELIZ */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ);

                    /*" -456- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -458- ELSE */
                }
                else
                {


                    /*" -459- DISPLAY 'PF0100B - FIM ANORMAL' */
                    _.Display($"PF0100B - FIM ANORMAL");

                    /*" -460- DISPLAY '          ERRO FETCH CURSOR PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO FETCH CURSOR PROPOSTA-FIDELIZ");

                    /*" -462- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -463- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -464- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -465- ELSE */
                }

            }
            else
            {


                /*" -468- ADD 1 TO W-LIDO, W-CONTROLE */
                WAREA_AUXILIAR.W_LIDO.Value = WAREA_AUXILIAR.W_LIDO + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -469- IF W-CONTROLE > 9999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 9999)
                {

                    /*" -470- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -471- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -472- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -473- DISPLAY '** PF0100B ** TOTAL LIDO ..  ' W-LIDO ' ' W-TIME-EDIT. */

                    $"** PF0100B ** TOTAL LIDO ..  {WAREA_AUXILIAR.W_LIDO} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();
                }

            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -451- EXEC SQL FETCH PROPOSTA-FIDELIZ INTO :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO, :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF, :DCLPROPOSTA-FIDELIZ.COD-PESSOA, :DCLPROPOSTA-FIDELIZ.NUM-SICOB, :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.AGECOBR, :DCLPROPOSTA-FIDELIZ.DIA-DEBITO, :DCLPROPOSTA-FIDELIZ.OPCAOPAG, :DCLPROPOSTA-FIDELIZ.AGECTADEB, :DCLPROPOSTA-FIDELIZ.OPRCTADEB, :DCLPROPOSTA-FIDELIZ.NUMCTADEB, :DCLPROPOSTA-FIDELIZ.DIGCTADEB, :DCLPROPOSTA-FIDELIZ.PERC-DESCONTO, :DCLPROPOSTA-FIDELIZ.NRMATRVEN, :DCLPROPOSTA-FIDELIZ.AGECTAVEN, :DCLPROPOSTA-FIDELIZ.OPRCTAVEN, :DCLPROPOSTA-FIDELIZ.NUMCTAVEN, :DCLPROPOSTA-FIDELIZ.DIGCTAVEN, :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NOME-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NRMATRCON, :DCLPROPOSTA-FIDELIZ.DTQITBCO, :DCLPROPOSTA-FIDELIZ.VAL-PAGO, :DCLPROPOSTA-FIDELIZ.AGEPGTO, :DCLPROPOSTA-FIDELIZ.VAL-TARIFA, :DCLPROPOSTA-FIDELIZ.VAL-IOF, :DCLPROPOSTA-FIDELIZ.DATA-CREDITO, :DCLPROPOSTA-FIDELIZ.VAL-COMISSAO, :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-USUARIO, :DCLPROPOSTA-FIDELIZ.CANAL-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NSAS-SIVPF, :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NSL, :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF, :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO, :RELATORI-NUM-ENDOSSO END-EXEC. */

            if (PROPOSTA_FIDELIZ.Fetch())
            {
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_COD_EMPRESA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_COD_PESSOA, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_DATA_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_AGECOBR, PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_DIA_DEBITO, PROPFID.DCLPROPOSTA_FIDELIZ.DIA_DEBITO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_OPCAOPAG, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAOPAG);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_AGECTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTADEB);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_OPRCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTADEB);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NUMCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTADEB);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_DIGCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTADEB);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_PERC_DESCONTO, PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NRMATRVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRVEN);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_AGECTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTAVEN);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_OPRCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTAVEN);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NUMCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTAVEN);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_DIGCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTAVEN);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_CGC_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NOME_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NRMATRCON, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRCON);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_DTQITBCO, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_VAL_PAGO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_AGEPGTO, PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_VAL_TARIFA, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_TARIFA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_VAL_IOF, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_DATA_CREDITO, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_VAL_COMISSAO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_COMISSAO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_COD_USUARIO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NSAS_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NSL, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NSAC_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_SITUACAO_ENVIO, PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);
                _.Move(PROPOSTA_FIDELIZ.RELATORI_NUM_ENDOSSO, RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -456- EXEC SQL CLOSE PROPOSTA-FIDELIZ END-EXEC */

            PROPOSTA_FIDELIZ.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -483- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -485- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -488- MOVE COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-COD-EMPRESA-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF, WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF);

            /*" -490- MOVE ZEROS TO W-QTD-LD-TIPO-1 */
            _.Move(0, WAREA_AUXILIAR.W_QTD_LD_TIPO_1);

            /*" -491- PERFORM R0151-00-OBTER-MAX-NSAS. */

            R0151_00_OBTER_MAX_NSAS_SECTION();

            /*" -493- PERFORM R0152-00-GERAR-HEADER. */

            R0152_00_GERAR_HEADER_SECTION();

            /*" -498- PERFORM R0160-00-PROCESSAR-EMPRESA UNTIL W-FIM-MOVTO-FIDELIZ EQUAL 'FIM' OR W-COD-EMPRESA-SIVPF NOT EQUAL COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ. */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM" || WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF != PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF))
            {

                R0160_00_PROCESSAR_EMPRESA_SECTION();
            }

            /*" -498- PERFORM R0700-00-TOTAL-EMPRESA. */

            R0700_00_TOTAL_EMPRESA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0151-00-OBTER-MAX-NSAS-SECTION */
        private void R0151_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -507- MOVE 'R0151-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0151-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -509- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -510- IF CAIXA-SEGUROS */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_SEGUROS"])
            {

                /*" -513- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

                /*" -516- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
                _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);
            }


            /*" -517- IF CAIXA-PREVIDENCIA */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_PREVIDENCIA"])
            {

                /*" -520- MOVE 'STAFPREV' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Move("STAFPREV", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

                /*" -523- MOVE 2 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
                _.Move(2, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);
            }


            /*" -524- IF CAIXA-CAPITALIZACAO */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_CAPITALIZACAO"])
            {

                /*" -527- MOVE 'STAFCAP ' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Move("STAFCAP ", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

                /*" -530- MOVE 5 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
                _.Move(5, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);
            }


            /*" -539- PERFORM R0151_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0151_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -542- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -543- DISPLAY 'PF0100B - FIM ANORMAL' */
                _.Display($"PF0100B - FIM ANORMAL");

                /*" -544- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -546- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -547- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -549- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -556- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -557- IF CAIXA-SEGUROS */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_SEGUROS"])
            {

                /*" -559- ADD 1 TO W-NSAS. */
                WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;
            }


            /*" -559- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

        }

        [StopWatch]
        /*" R0151-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0151_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -539- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

            var r0151_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 = new R0151_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0151_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1.Execute(r0151_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0151_SAIDA*/

        [StopWatch]
        /*" R0152-00-GERAR-HEADER-SECTION */
        private void R0152_00_GERAR_HEADER_SECTION()
        {
            /*" -568- MOVE 'R0152-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0152-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -570- MOVE 'WRITE REG-HEADER-STA' TO COMANDO. */
            _.Move("WRITE REG-HEADER-STA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -572- MOVE SPACES TO REG-HEADER-STA. */
            _.Move("", LBFCT011.REG_HEADER_STA);

            /*" -575- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -578- MOVE ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO, LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -579- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -580- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -582- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -585- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -588- MOVE ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -591- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -595- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER-STA */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_HEADER_STA.RH_NSAS);

            /*" -596- IF CAIXA-SEGUROS */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_SEGUROS"])
            {

                /*" -598- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
                _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -599- IF CAIXA-PREVIDENCIA */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_PREVIDENCIA"])
            {

                /*" -601- WRITE REG-STA-PREV FROM REG-HEADER-STA. */
                _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_PREV);

                MOVTO_STA_PREV.Write(REG_STA_PREV.GetMoveValues().ToString());
            }


            /*" -602- IF CAIXA-CAPITALIZACAO */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_CAPITALIZACAO"])
            {

                /*" -602- WRITE REG-STA-CAP FROM REG-HEADER-STA. */
                _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_CAP);

                MOVTO_STA_CAP.Write(REG_STA_CAP.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0152_SAIDA*/

        [StopWatch]
        /*" R0160-00-PROCESSAR-EMPRESA-SECTION */
        private void R0160_00_PROCESSAR_EMPRESA_SECTION()
        {
            /*" -612- MOVE 'R0160-00-PROCESSAR-EMPRESA' TO PARAGRAFO. */
            _.Move("R0160-00-PROCESSAR-EMPRESA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -614- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -615- PERFORM R0180-00-GERA-H-PROP-FIDEL */

            R0180_00_GERA_H_PROP_FIDEL_SECTION();

            /*" -616- PERFORM R0190-00-GERAR-REGISTRO-TP1. */

            R0190_00_GERAR_REGISTRO_TP1_SECTION();

            /*" -617- PERFORM R0200-00-ATUALIZAR-PROPOSTA. */

            R0200_00_ATUALIZAR_PROPOSTA_SECTION();

            /*" -617- PERFORM R0210-00-ATUALIZAR-RELATORIO. */

            R0210_00_ATUALIZAR_RELATORIO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0160_LER */

            R0160_LER();

        }

        [StopWatch]
        /*" R0160-LER */
        private void R0160_LER(bool isPerform = false)
        {
            /*" -621- PERFORM R0070-00-LER-MOVTO. */

            R0070_00_LER_MOVTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_SAIDA*/

        [StopWatch]
        /*" R0180-00-GERA-H-PROP-FIDEL-SECTION */
        private void R0180_00_GERA_H_PROP_FIDEL_SECTION()
        {
            /*" -631- MOVE 'R0180-GERA-H-PROP-FIDEL' TO PARAGRAFO. */
            _.Move("R0180-GERA-H-PROP-FIDEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -633- MOVE 'INSERT HIST PROP FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST PROP FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -636- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NUM-IDENTIFICACAO OF DCLHIST-PROP-FIDELIZ. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -639- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO PROPFIDH-NSAS-SIVPF OF DCLHIST-PROP-FIDELIZ. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -640- IF SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'MAN' */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA == "MAN")
            {

                /*" -642- MOVE 'EMT' TO PROPFIDH-SIT-PROPOSTA OF DCLHIST-PROP-FIDELIZ */
                _.Move("EMT", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

                /*" -643- ELSE */
            }
            else
            {


                /*" -645- MOVE SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-SIT-PROPOSTA OF DCLHIST-PROP-FIDELIZ */
                _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

                /*" -647- END-IF */
            }


            /*" -650- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO PROPFIDH-DATA-SITUACAO OF DCLHIST-PROP-FIDELIZ. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -653- MOVE 'PAG' TO PROPFIDH-SIT-COBRANCA-SIVPF OF DCLHIST-PROP-FIDELIZ. */
            _.Move("PAG", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -656- MOVE RELATORI-NUM-ENDOSSO TO PROPFIDH-SIT-MOTIVO-SIVPF OF DCLHIST-PROP-FIDELIZ. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -659- MOVE COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -663- MOVE COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -664- ADD 1 TO W-QTD-LD-TIPO-1. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;

            /*" -667- MOVE W-QTD-LD-TIPO-1 TO PROPFIDH-NSL OF DCLHIST-PROP-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -678- PERFORM R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1 */

            R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1();

            /*" -681- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -682- DISPLAY 'PF0100B - FIM ANORMAL' */
                _.Display($"PF0100B - FIM ANORMAL");

                /*" -683- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -685- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -687- DISPLAY '          NUMERO IDENTIFICACAO..........  ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                /*" -689- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -690- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -690- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0180-00-GERA-H-PROP-FIDEL-DB-INSERT-1 */
        public void R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1()
        {
            /*" -678- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPFIDH-NUM-IDENTIFICACAO, :PROPFIDH-DATA-SITUACAO, :PROPFIDH-NSAS-SIVPF, :PROPFIDH-NSL, :PROPFIDH-SIT-PROPOSTA, :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF, :PROPFIDH-COD-EMPRESA-SIVPF, :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

            var r0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1 = new R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1()
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

            R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1.Execute(r0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_SAIDA*/

        [StopWatch]
        /*" R0190-00-GERAR-REGISTRO-TP1-SECTION */
        private void R0190_00_GERAR_REGISTRO_TP1_SECTION()
        {
            /*" -701- MOVE 'R0190-00-GERAR-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0190-00-GERAR-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -703- MOVE 'WRITE REG-STA-PROPOSTA' TO COMANDO. */
            _.Move("WRITE REG-STA-PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -705- MOVE SPACES TO REG-STA-PROPOSTA. */
            _.Move("", LBFCT011.REG_STA_PROPOSTA);

            /*" -708- MOVE '1' TO R1-TIPO-REG OF REG-STA-PROPOSTA. */
            _.Move("1", LBFCT011.REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -711- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -714- MOVE PROPFIDH-SIT-PROPOSTA OF DCLHIST-PROP-FIDELIZ TO R1-SIT-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA, LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

            /*" -717- MOVE PROPFIDH-SIT-MOTIVO-SIVPF OF DCLHIST-PROP-FIDELIZ TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);

            /*" -720- MOVE PROPFIDH-DATA-SITUACAO OF DCLHIST-PROP-FIDELIZ TO W-DATA-SQL. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -721- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -722- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -724- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -727- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -729- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO R1-NSAS OF REG-STA-PROPOSTA. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NSAS);

            /*" -732- MOVE W-QTD-LD-TIPO-1 TO R1-NSL OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFCT011.REG_STA_PROPOSTA.R1_NSL);

            /*" -733- IF CAIXA-SEGUROS */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_SEGUROS"])
            {

                /*" -735- WRITE REG-STA-SASSE FROM REG-STA-PROPOSTA. */
                _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -736- IF CAIXA-PREVIDENCIA */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_PREVIDENCIA"])
            {

                /*" -738- WRITE REG-STA-PREV FROM REG-STA-PROPOSTA. */
                _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_PREV);

                MOVTO_STA_PREV.Write(REG_STA_PREV.GetMoveValues().ToString());
            }


            /*" -739- IF CAIXA-CAPITALIZACAO */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_CAPITALIZACAO"])
            {

                /*" -739- WRITE REG-STA-CAP FROM REG-STA-PROPOSTA. */
                _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_CAP);

                MOVTO_STA_CAP.Write(REG_STA_CAP.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0190_SAIDA*/

        [StopWatch]
        /*" R0200-00-ATUALIZAR-PROPOSTA-SECTION */
        private void R0200_00_ATUALIZAR_PROPOSTA_SECTION()
        {
            /*" -749- MOVE 'R0200-ATUALIZAR-PROPOSTA' TO PARAGRAFO. */
            _.Move("R0200-ATUALIZAR-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -751- MOVE 'UPDATE PROPOSTA FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -758- PERFORM R0200_00_ATUALIZAR_PROPOSTA_DB_UPDATE_1 */

            R0200_00_ATUALIZAR_PROPOSTA_DB_UPDATE_1();

            /*" -761- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -762- DISPLAY 'PF0100B - FIM ANORMAL' */
                _.Display($"PF0100B - FIM ANORMAL");

                /*" -763- DISPLAY '          ERRO UPDATE TABELA PROPOSTA FIDELIZ' */
                _.Display($"          ERRO UPDATE TABELA PROPOSTA FIDELIZ");

                /*" -765- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -767- DISPLAY '          NUMERO IDENTIFICACAO..........  ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                /*" -769- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -770- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -770- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0200-00-ATUALIZAR-PROPOSTA-DB-UPDATE-1 */
        public void R0200_00_ATUALIZAR_PROPOSTA_DB_UPDATE_1()
        {
            /*" -758- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET NSAS_SIVPF = :PROPFIDH-NSAS-SIVPF, NSL = :PROPFIDH-NSL, COD_USUARIO = 'PF0100B' WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0200_00_ATUALIZAR_PROPOSTA_DB_UPDATE_1_Update1 = new R0200_00_ATUALIZAR_PROPOSTA_DB_UPDATE_1_Update1()
            {
                PROPFIDH_NSAS_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF.ToString(),
                PROPFIDH_NSL = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL.ToString(),
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0200_00_ATUALIZAR_PROPOSTA_DB_UPDATE_1_Update1.Execute(r0200_00_ATUALIZAR_PROPOSTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0210-00-ATUALIZAR-RELATORIO-SECTION */
        private void R0210_00_ATUALIZAR_RELATORIO_SECTION()
        {
            /*" -780- MOVE 'R0210-ATUALIZAR-RELATORIO' TO PARAGRAFO. */
            _.Move("R0210-ATUALIZAR-RELATORIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -782- MOVE 'UPDATE RELATORIOS' TO COMANDO. */
            _.Move("UPDATE RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -783- MOVE '0' TO RELATORI-SIT-REGISTRO */
            _.Move("0", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -784- MOVE 'PF' TO RELATORI-IDE-SISTEMA */
            _.Move("PF", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -786- MOVE 'PF0100B' TO RELATORI-COD-RELATORIO */
            _.Move("PF0100B", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -795- PERFORM R0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1 */

            R0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1();

            /*" -798- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -799- DISPLAY 'PF0100B - FIM ANORMAL' */
                _.Display($"PF0100B - FIM ANORMAL");

                /*" -800- DISPLAY '          ERRO UPDATE TABELA RELATORIOS' */
                _.Display($"          ERRO UPDATE TABELA RELATORIOS");

                /*" -802- DISPLAY '          NUMERO PROPOSTA............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -804- DISPLAY '          NUMERO IDENTIFICACAO.......  ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO IDENTIFICACAO.......  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                /*" -806- DISPLAY '          SQLCODE....................  ' SQLCODE */
                _.Display($"          SQLCODE....................  {DB.SQLCODE}");

                /*" -807- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -807- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0210-00-ATUALIZAR-RELATORIO-DB-UPDATE-1 */
        public void R0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1()
        {
            /*" -795- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF AND SIT_REGISTRO = :RELATORI-SIT-REGISTRO AND IDE_SISTEMA = :RELATORI-IDE-SISTEMA AND COD_RELATORIO = :RELATORI-COD-RELATORIO END-EXEC. */

            var r0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1 = new R0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1()
            {
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_SIT_REGISTRO = RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
            };

            R0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1.Execute(r0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_SAIDA*/

        [StopWatch]
        /*" R0700-00-TOTAL-EMPRESA-SECTION */
        private void R0700_00_TOTAL_EMPRESA_SECTION()
        {
            /*" -817- MOVE 'R0700-00-TOTAL-EMPRESA' TO PARAGRAFO. */
            _.Move("R0700-00-TOTAL-EMPRESA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -819- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -821- PERFORM R0800-00-GERAR-TRAILLER. */

            R0800_00_GERAR_TRAILLER_SECTION();

            /*" -822- IF CAIXA-SEGUROS */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_SEGUROS"])
            {

                /*" -824- PERFORM R0850-00-CONTROLAR-ARQ-ENVIADO. */

                R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION();
            }


            /*" -824- PERFORM R0870-00-GERAR-TOTAIS. */

            R0870_00_GERAR_TOTAIS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_SAIDA*/

        [StopWatch]
        /*" R0800-00-GERAR-TRAILLER-SECTION */
        private void R0800_00_GERAR_TRAILLER_SECTION()
        {
            /*" -834- MOVE 'R0800-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R0800-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -836- MOVE 'WRITE REG-TRAILLER-STA' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER-STA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -838- MOVE SPACES TO REG-TRAILLER-STA. */
            _.Move("", LBFCT011.REG_TRAILLER_STA);

            /*" -841- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -844- MOVE RH-NOME-EMPRESA OF REG-HEADER-STA TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA, LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -847- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1);

            /*" -850- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2);

            /*" -853- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3);

            /*" -856- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4);

            /*" -859- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_5, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5);

            /*" -862- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_6, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6);

            /*" -865- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_7, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7);

            /*" -868- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8);

            /*" -871- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_9, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9);

            /*" -882- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -883- IF CAIXA-SEGUROS */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_SEGUROS"])
            {

                /*" -885- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
                _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -886- IF CAIXA-PREVIDENCIA */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_PREVIDENCIA"])
            {

                /*" -888- WRITE REG-STA-PREV FROM REG-TRAILLER-STA. */
                _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_PREV);

                MOVTO_STA_PREV.Write(REG_STA_PREV.GetMoveValues().ToString());
            }


            /*" -889- IF CAIXA-CAPITALIZACAO */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_CAPITALIZACAO"])
            {

                /*" -889- WRITE REG-STA-CAP FROM REG-TRAILLER-STA. */
                _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_CAP);

                MOVTO_STA_CAP.Write(REG_STA_CAP.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -902- MOVE 'R0850-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R0850-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -904- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -907- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -910- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -914- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -918- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -926- PERFORM R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -929- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -930- DISPLAY 'PF0100B - FIM ANORMAL' */
                _.Display($"PF0100B - FIM ANORMAL");

                /*" -931- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -933- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -935- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -937- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -939- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -942- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -944- MOVE SPACES TO W-FIM-MOVTO-FIDELIZ */
                _.Move("", WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ);

                /*" -945- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -945- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -926- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 = new R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1.Execute(r0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R0870-00-GERAR-TOTAIS-SECTION */
        private void R0870_00_GERAR_TOTAIS_SECTION()
        {
            /*" -956- MOVE 'R0870-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R0870-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -958- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -968- COMPUTE W-TOT-GERADO-STA = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9. */
            WAREA_AUXILIAR.W_TOT_GERADO_STA.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9;

            /*" -969- IF CAIXA-SEGUROS */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_SEGUROS"])
            {

                /*" -971- DISPLAY '** PF0100B - EMPRESA PROCESSADA CX SEGUROS    **' . */
                _.Display($"** PF0100B - EMPRESA PROCESSADA CX SEGUROS    **");
            }


            /*" -972- IF CAIXA-PREVIDENCIA */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_PREVIDENCIA"])
            {

                /*" -974- DISPLAY '** PF0100B - EMPRESA PROCESSADA PREVIDENCIA   **' . */
                _.Display($"** PF0100B - EMPRESA PROCESSADA PREVIDENCIA   **");
            }


            /*" -975- IF CAIXA-CAPITALIZACAO */

            if (WAREA_AUXILIAR.W_COD_EMPRESA_SIVPF["CAIXA_CAPITALIZACAO"])
            {

                /*" -977- DISPLAY '** PF0100B - EMPRESA PROCESSADA CAPITALIZACAO **' . */
                _.Display($"** PF0100B - EMPRESA PROCESSADA CAPITALIZACAO **");
            }


            /*" -978- DISPLAY ' ' */
            _.Display($" ");

            /*" -979- DISPLAY '** PF0100B -   TOTAIS DO  PROCESSAMENTO         **' */
            _.Display($"** PF0100B -   TOTAIS DO  PROCESSAMENTO         **");

            /*" -980- DISPLAY '               TOTAL  REGISTROS LIDOS... ' W-LIDO */
            _.Display($"               TOTAL  REGISTROS LIDOS... {WAREA_AUXILIAR.W_LIDO}");

            /*" -982- DISPLAY '               TOTAL  REGISTROS GERADOS. ' W-QTD-LD-TIPO-1. */
            _.Display($"               TOTAL  REGISTROS GERADOS. {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -983- DISPLAY ' ' */
            _.Display($" ");

            /*" -985- DISPLAY ' ' */
            _.Display($" ");

            /*" -993- MOVE ZEROS TO W-QTD-LD-TIPO-1 W-QTD-LD-TIPO-2 W-QTD-LD-TIPO-3 W-QTD-LD-TIPO-4 W-QTD-LD-TIPO-5 W-QTD-LD-TIPO-6 W-QTD-LD-TIPO-7 W-QTD-LD-TIPO-8 W-QTD-LD-TIPO-9. */
            _.Move(0, WAREA_AUXILIAR.W_QTD_LD_TIPO_1, WAREA_AUXILIAR.W_QTD_LD_TIPO_2, WAREA_AUXILIAR.W_QTD_LD_TIPO_3, WAREA_AUXILIAR.W_QTD_LD_TIPO_4, WAREA_AUXILIAR.W_QTD_LD_TIPO_5, WAREA_AUXILIAR.W_QTD_LD_TIPO_6, WAREA_AUXILIAR.W_QTD_LD_TIPO_7, WAREA_AUXILIAR.W_QTD_LD_TIPO_8, WAREA_AUXILIAR.W_QTD_LD_TIPO_9);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0870_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -1004- CLOSE MOVTO-STA-SASSE MOVTO-STA-PREV MOVTO-STA-CAP. */
            MOVTO_STA_SASSE.Close();
            MOVTO_STA_PREV.Close();
            MOVTO_STA_CAP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -1014- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -1016- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -1018- DISPLAY ' ' */
            _.Display($" ");

            /*" -1019- IF W-FIM-MOVTO-FIDELIZ = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM")
            {

                /*" -1020- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -1021- DISPLAY '*              PF0100B - FIM NORMAL            *' */
                _.Display($"*              PF0100B - FIM NORMAL            *");

                /*" -1022- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -1023- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1024- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1024- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1026- ELSE */
            }
            else
            {


                /*" -1027- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -1028- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

                /*" -1029- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

                /*" -1030- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -1031- DISPLAY '*---------------------------------------*' */
                _.Display($"*---------------------------------------*");

                /*" -1032- DISPLAY '*   PF0100B *** ROLLBACK EM ANDAMENTO   *' */
                _.Display($"*   PF0100B *** ROLLBACK EM ANDAMENTO   *");

                /*" -1033- DISPLAY '*---------------------------------------*' */
                _.Display($"*---------------------------------------*");

                /*" -1034- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1034- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -1037- MOVE 99 TO RETURN-CODE. */
                _.Move(99, RETURN_CODE);
            }


            /*" -1038- DISPLAY '*' . */
            _.Display($"*");

            /*" -1046- DISPLAY 'PF0100B - TERMINO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"PF0100B - TERMINO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1048- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -1048- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}