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
using Sias.PessoaFisica.DB2.PF0709B;

namespace Code
{
    public class PF0709B
    {
        public bool IsCall { get; set; }

        public PF0709B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------*                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISE/PROGRAMACAO.....  LUIZ CARLOS.                       *      */
        /*"      *   PROGRAMA ...............  PF0709B                            *      */
        /*"      *   DATA ...................  23/11/2001.                        *      */
        /*"      *   DATA ...................  23/11/2001.                        *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA A CEF STATUS DE PARCELA EM    *      */
        /*"      *                             ATRASO DOS PRODUTOS DE VIDA.       *      */
        /*"      *                             ESTE PROGRAMA NAO PODE ENVIAR      *      */
        /*"      *                             STATUS EMT NO REG-TIPO-4           *      */
        /*"      *                                                                *      */
        /*"      *   OBS.: TENDO MAIS DE UMA PARCELA EM ATRASO, SER  INFORMADA A  *      */
        /*"      *         MAIS RECENTE. EX. MESES JANEIRO E FEVEREIRO, EM ATRASO *      */
        /*"      *         SER  INFORMADA A PARCELA DE FEVEREIRO.                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 06             AJUSTE PARA ENVIO DA SITUACAO DA COBRANCA*      */
        /*"      * ATENDE JAZZ  459621   POIS ESTAVA ENVIANDO A SITUACAO DA       *      */
        /*"      *                       PROPOSTA NO CAMPO ERRADO                 *      */
        /*"      * PROCURE V.06          THIAGO BLAIER / REGINALDO SILVA          *      */
        /*"      *                       05/07/2023                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 05             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA                          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 04                                                      *      */
        /*"      * ATENDE CADMUS 32886                                            *      */
        /*"      *                                                                *      */
        /*"      * PROCURE POR EC1811    EDILANA CERQUEIRA                        *      */
        /*"      *                       18/11/2009                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 03             INIBIR O COMANDO DISPLAY                 *      */
        /*"      *                                                                *      */
        /*"      * PROCURE POR WV0908    WELLINGTON VERAS                         *      */
        /*"      *                       26/09/2008                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 02             DESPREZAR COD_PRODUTO_SIVPF IGUAL A 48.  *      */
        /*"      *                       TRATA-SE DA INTERNALIZACAO  DE APOLICES  *      */
        /*"      *                       ESPECIFICAS DE VIDA.                     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE POR V.02      MAURICIO LINKE                           *      */
        /*"      *                       27/11/2007                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 01 - DATA      PASSOU A INFORMAR D+1 AO SIGPF A         *      */
        /*"      *                       INADIMPLENCIA DE VIDA.                   *      */
        /*"      *                                                                *      */
        /*"      * PROCURE POR V.01      LUIZ CARLOS                              *      */
        /*"      *                       23/09/2003                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
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
        /*"01  WHOST-DT-INI-ATR                  PIC  X(010).*/
        public StringBasis WHOST_DT_INI_ATR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WORK-AREA.*/
        public PF0709B_WORK_AREA WORK_AREA { get; set; } = new PF0709B_WORK_AREA();
        public class PF0709B_WORK_AREA : VarBasis
        {
            /*"    05 WS-NUM-CERTIFICADO            PIC 9(015)   VALUE ZEROS.*/
            public IntBasis WS_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05 W-PGTO-PARCELA                PIC 9(001)   VALUE ZEROS.*/

            public SelectorBasis W_PGTO_PARCELA { get; set; } = new SelectorBasis("001", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PARCELA-EM-ATRASO                       VALUE 1. */
							new SelectorItemBasis("PARCELA_EM_ATRASO", "1")
                }
            };

            /*"    05 W-PGTO-POSTERIOR              PIC 9(001)   VALUE ZEROS.*/

            public SelectorBasis W_PGTO_POSTERIOR { get; set; } = new SelectorBasis("001", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HOUVE-PGTO-POSTERIOR                    VALUE 1. */
							new SelectorItemBasis("HOUVE_PGTO_POSTERIOR", "1")
                }
            };

            /*"    05 W-STATUS-PROPOSTA             PIC 9(001)   VALUE ZEROS.*/

            public SelectorBasis W_STATUS_PROPOSTA { get; set; } = new SelectorBasis("001", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 STATUS-JA-ENVIADO                       VALUE 1. */
							new SelectorItemBasis("STATUS_JA_ENVIADO", "1")
                }
            };

            /*"    05 W-SITUACAO-CERTIFICADO        PIC 9(001)   VALUE ZEROS.*/

            public SelectorBasis W_SITUACAO_CERTIFICADO { get; set; } = new SelectorBasis("001", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CERTIFICADO-ATIVO                       VALUE 1. */
							new SelectorItemBasis("CERTIFICADO_ATIVO", "1"),
							/*" 88 CERTIFICADO-INATIVO                     VALUE 2. */
							new SelectorItemBasis("CERTIFICADO_INATIVO", "2")
                }
            };

            /*"    05 W-PERIODICIDADE-PGTO          PIC 9(002)   VALUE ZEROS.*/

            public SelectorBasis W_PERIODICIDADE_PGTO { get; set; } = new SelectorBasis("002", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PAGAMENTO-MENSAL                        VALUE 1. */
							new SelectorItemBasis("PAGAMENTO_MENSAL", "1"),
							/*" 88 PAGAMENTO-BIMESTRAL                     VALUE 2. */
							new SelectorItemBasis("PAGAMENTO_BIMESTRAL", "2"),
							/*" 88 PAGAMENTO-TRIMESTRAL                    VALUE 3. */
							new SelectorItemBasis("PAGAMENTO_TRIMESTRAL", "3"),
							/*" 88 PAGAMENTO-SEMESTRAL                     VALUE 4. */
							new SelectorItemBasis("PAGAMENTO_SEMESTRAL", "4"),
							/*" 88 PAGAMENTO-ANUAL                         VALUE 12. */
							new SelectorItemBasis("PAGAMENTO_ANUAL", "12")
                }
            };

            /*"    05  W-NUM-PROPOSTA-NOVA           PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FILLER REDEFINES W-NUM-PROPOSTA-NOVA.*/
            private _REDEF_PF0709B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0709B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0709B_FILLER_0(); _.Move(W_NUM_PROPOSTA_NOVA, _filler_0); VarBasis.RedefinePassValue(W_NUM_PROPOSTA_NOVA, _filler_0, W_NUM_PROPOSTA_NOVA); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_NUM_PROPOSTA_NOVA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_NUM_PROPOSTA_NOVA); }
            }  //Redefines
            public class _REDEF_PF0709B_FILLER_0 : VarBasis
            {
                /*"        07  W-NUM-PROPOSTA-ATUAL      PIC 9(013).*/
                public IntBasis W_NUM_PROPOSTA_ATUAL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        07  W-DV-PROPOSTA-NOVA        PIC 9(001).*/
                public IntBasis W_DV_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05 WS-EOR                        PIC  9(001)  VALUE ZEROS.*/

                public _REDEF_PF0709B_FILLER_0()
                {
                    W_NUM_PROPOSTA_ATUAL.ValueChanged += OnValueChanged;
                    W_DV_PROPOSTA_NOVA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_EOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 AC-CONTROLE                   PIC  9(006)  VALUE ZEROS.*/
            public IntBasis AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-L-MOVIMENTO                PIC  9(006)  VALUE ZEROS.*/
            public IntBasis AC_L_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 W-QTD-LD-TIPO-4               PIC  9(006)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 DATA-SQL1                     PIC  X(010).*/
            public StringBasis DATA_SQL1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 DATA-SQL  REDEFINES DATA-SQL1.*/
            private _REDEF_PF0709B_DATA_SQL _data_sql { get; set; }
            public _REDEF_PF0709B_DATA_SQL DATA_SQL
            {
                get { _data_sql = new _REDEF_PF0709B_DATA_SQL(); _.Move(DATA_SQL1, _data_sql); VarBasis.RedefinePassValue(DATA_SQL1, _data_sql, DATA_SQL1); _data_sql.ValueChanged += () => { _.Move(_data_sql, DATA_SQL1); }; return _data_sql; }
                set { VarBasis.RedefinePassValue(value, _data_sql, DATA_SQL1); }
            }  //Redefines
            public class _REDEF_PF0709B_DATA_SQL : VarBasis
            {
                /*"       10 ANO-SQL                    PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 MES-SQL                    PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 DIA-SQL                    PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_PF0709B_DATA_SQL()
                {
                    ANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    MES_SQL.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0709B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0709B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0709B_FILLER_3(); _.Move(W_DATA_TRABALHO, _filler_3); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_3, W_DATA_TRABALHO); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_DATA_TRABALHO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0709B_FILLER_3 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0709B_FILLER_3()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0709B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0709B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0709B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0709B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0709B_W_DTMOVABE1()
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
            private _REDEF_PF0709B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0709B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0709B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0709B_W_DTMOVABE_I1 : VarBasis
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
                /*"01  WS-TIME.*/

                public _REDEF_PF0709B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0709B_WS_TIME WS_TIME { get; set; } = new PF0709B_WS_TIME();
        public class PF0709B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01             W01DIGCERT.*/
        public PF0709B_W01DIGCERT W01DIGCERT { get; set; } = new PF0709B_W01DIGCERT();
        public class PF0709B_W01DIGCERT : VarBasis
        {
            /*"    05         WCERTIFICADO    PIC  9(015)        VALUE  0.*/
            public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05         WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
            public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
            /*"    05         WDIG            PIC  X(001)  VALUE SPACES.*/
            public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  AREA-ABEND.*/
        }
        public PF0709B_AREA_ABEND AREA_ABEND { get; set; } = new PF0709B_AREA_ABEND();
        public class PF0709B_AREA_ABEND : VarBasis
        {
            /*"    05   WABEND.*/
            public PF0709B_WABEND WABEND { get; set; } = new PF0709B_WABEND();
            public class PF0709B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0709B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0709B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public PF0709B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0709B_LOCALIZA_ABEND_1();
            public class PF0709B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0709B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0709B_LOCALIZA_ABEND_2();
            public class PF0709B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"    05      WSQLERRO.*/
            }
            public PF0709B_WSQLERRO WSQLERRO { get; set; } = new PF0709B_WSQLERRO();
            public class PF0709B_WSQLERRO : VarBasis
            {
                /*"      10    FILLER                   PIC X(014)  VALUE            ' *** SQLERRMC '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"      10    WSQLERRMC                PIC X(070)  VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            }
        }


        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.CBHSTZUL CBHSTZUL { get; set; } = new Dclgens.CBHSTZUL();
        public Dclgens.PARVDZUL PARVDZUL { get; set; } = new Dclgens.PARVDZUL();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PROPVA PROPVA { get; set; } = new Dclgens.PROPVA();
        public PF0709B_CPROPOSTA CPROPOSTA { get; set; } = new PF0709B_CPROPOSTA();
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
            /*" -262- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -263- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -264- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -267- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -268- DISPLAY '*               PROGRAMA PF0709B               *' . */
            _.Display($"*               PROGRAMA PF0709B               *");

            /*" -269- DISPLAY '* GERA STATUS DE PARC EM ATRASO DOS PROD VIDA  *' . */
            _.Display($"* GERA STATUS DE PARC EM ATRASO DOS PROD VIDA  *");

            /*" -270- DISPLAY '*           VERSAO:  06 - 05/07/2023           *' . */
            _.Display($"*           VERSAO:  06 - 05/07/2023           *");

            /*" -271- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -280- DISPLAY '*  PF0709B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0709B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -282- PERFORM R0100-00-INICIALIZA. */

            R0100_00_INICIALIZA_SECTION();

            /*" -283- PERFORM R0900-00-DECLARE-PROPOSTA. */

            R0900_00_DECLARE_PROPOSTA_SECTION();

            /*" -285- PERFORM R0950-00-FETCH-PROPOSTA. */

            R0950_00_FETCH_PROPOSTA_SECTION();

            /*" -286- IF WS-EOR = 1 */

            if (WORK_AREA.WS_EOR == 1)
            {

                /*" -287- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -288- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -289- DISPLAY '*           PF0709B - TERMINO NORMAL           *' */
                _.Display($"*           PF0709B - TERMINO NORMAL           *");

                /*" -290- DISPLAY '*             NAO HOUVE  MOVIMENTO             *' */
                _.Display($"*             NAO HOUVE  MOVIMENTO             *");

                /*" -291- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -292- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -294- GO TO R0000-00-FINALIZA. */

                R0000_00_FINALIZA(); //GOTO
                return;
            }


            /*" -295- PERFORM R0150-00-ABRIR-ARQUIVOS. */

            R0150_00_ABRIR_ARQUIVOS_SECTION();

            /*" -296- PERFORM R0200-00-OBTER-MAX-NSAS. */

            R0200_00_OBTER_MAX_NSAS_SECTION();

            /*" -298- PERFORM R0250-00-GERAR-HEADER */

            R0250_00_GERAR_HEADER_SECTION();

            /*" -301- PERFORM R0300-00-PROCESSA-REGISTRO UNTIL WS-EOR = 1. */

            while (!(WORK_AREA.WS_EOR == 1))
            {

                R0300_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -302- PERFORM R0800-00-GERAR-TRAILLER. */

            R0800_00_GERAR_TRAILLER_SECTION();

            /*" -304- PERFORM R0850-00-CONTROLAR-ARQ-ENVIADO */

            R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -305- PERFORM R1000-00-IMPRIMIR-TOTAIS. */

            R1000_00_IMPRIMIR_TOTAIS_SECTION();

            /*" -305- PERFORM R1100-00-FECHAR-ARQUIVOS. */

            R1100_00_FECHAR_ARQUIVOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_00_FINALIZA */

            R0000_00_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-FINALIZA */
        private void R0000_00_FINALIZA(bool isPerform = false)
        {
            /*" -314- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -317- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -317- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-SECTION */
        private void R0100_00_INICIALIZA_SECTION()
        {
            /*" -325- MOVE '0000-PRINCIPAL               ' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL               ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -327- MOVE 'R0100-00-SELECT-SISTEMAS     ' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-SISTEMAS     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -329- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -338- PERFORM R0100_00_INICIALIZA_DB_SELECT_1 */

            R0100_00_INICIALIZA_DB_SELECT_1();

            /*" -341- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -342- DISPLAY 'PF0707B - FIM ANORMAL' */
                _.Display($"PF0707B - FIM ANORMAL");

                /*" -343- DISPLAY '          ERRO ACESSO TABELA SISTEMAS  ' */
                _.Display($"          ERRO ACESSO TABELA SISTEMAS  ");

                /*" -345- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -347- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -349- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.W_DTMOVABE);

            /*" -351- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_DIA_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -353- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_MES_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -356- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_ANO_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -361- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WORK_AREA.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WORK_AREA.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -371- INITIALIZE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA RT-QTDE-TIPO-2 OF REG-TRAILLER-STA RT-QTDE-TIPO-3 OF REG-TRAILLER-STA RT-QTDE-TIPO-4 OF REG-TRAILLER-STA RT-QTDE-TIPO-5 OF REG-TRAILLER-STA RT-QTDE-TIPO-6 OF REG-TRAILLER-STA RT-QTDE-TIPO-7 OF REG-TRAILLER-STA RT-QTDE-TIPO-8 OF REG-TRAILLER-STA RT-QTDE-TIPO-9 OF REG-TRAILLER-STA WS-NUM-CERTIFICADO. */
            _.Initialize(
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1
                , LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2
                , LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3
                , LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4
                , LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5
                , LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6
                , LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7
                , LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8
                , LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9
                , WORK_AREA.WS_NUM_CERTIFICADO
            );

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-DB-SELECT-1 */
        public void R0100_00_INICIALIZA_DB_SELECT_1()
        {
            /*" -338- EXEC SQL SELECT DATA_MOV_ABERTO , DATA_MOV_ABERTO - 1 DAY INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO , :WHOST-DT-INI-ATR FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0100_00_INICIALIZA_DB_SELECT_1_Query1 = new R0100_00_INICIALIZA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0100_00_INICIALIZA_DB_SELECT_1_Query1.Execute(r0100_00_INICIALIZA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DT_INI_ATR, WHOST_DT_INI_ATR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-ABRIR-ARQUIVOS-SECTION */
        private void R0150_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -383- MOVE 'R0150-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0150-00-ABRIR-ARQUIVOS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -385- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -385- OPEN OUTPUT MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0200-00-OBTER-MAX-NSAS-SECTION */
        private void R0200_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -395- MOVE 'R0200-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0200-00-OBTER-MAX-NSAS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -397- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -400- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -403- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -412- PERFORM R0200_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0200_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -415- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -416- DISPLAY 'PF0709B - FIM ANORMAL' */
                _.Display($"PF0709B - FIM ANORMAL");

                /*" -417- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -419- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -420- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -422- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -422- ADD 1 TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.Value = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF + 1;

        }

        [StopWatch]
        /*" R0200-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0200_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -412- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

            var r0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 = new R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1.Execute(r0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0250-00-GERAR-HEADER-SECTION */
        private void R0250_00_GERAR_HEADER_SECTION()
        {
            /*" -432- MOVE 'R0250-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0250-00-GERAR-HEADER", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -434- MOVE 'WRITE REG-HEADER-STA' TO COMANDO. */
            _.Move("WRITE REG-HEADER-STA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -436- MOVE SPACES TO REG-HEADER-STA. */
            _.Move("", LBFCT011.REG_HEADER_STA);

            /*" -439- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -442- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -444- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.W_DTMOVABE);

            /*" -445- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_DIA_MOVABE, WORK_AREA.FILLER_3.W_DIA_TRABALHO);

            /*" -446- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_MES_MOVABE, WORK_AREA.FILLER_3.W_MES_TRABALHO);

            /*" -448- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_ANO_MOVABE, WORK_AREA.FILLER_3.W_ANO_TRABALHO);

            /*" -451- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Move(WORK_AREA.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -454- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -457- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -460- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER-STA */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_HEADER_STA.RH_NSAS);

            /*" -460- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0300-00-PROCESSA-REGISTRO-SECTION */
        private void R0300_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -471- MOVE 1 TO W-PGTO-PARCELA. */
            _.Move(1, WORK_AREA.W_PGTO_PARCELA);

            /*" -473- PERFORM R0330-00-SELECT-OPCAOPAGVA. */

            R0330_00_SELECT_OPCAOPAGVA_SECTION();

            /*" -474- IF PARCELA-EM-ATRASO */

            if (WORK_AREA.W_PGTO_PARCELA["PARCELA_EM_ATRASO"])
            {

                /*" -476- PERFORM R0340-00-VERIFICAR-PGTO */

                R0340_00_VERIFICAR_PGTO_SECTION();

                /*" -477- IF NOT HOUVE-PGTO-POSTERIOR */

                if (!WORK_AREA.W_PGTO_POSTERIOR["HOUVE_PGTO_POSTERIOR"])
                {

                    /*" -478- PERFORM R0350-00-SELECT-PARCELA */

                    R0350_00_SELECT_PARCELA_SECTION();

                    /*" -480- PERFORM R0400-00-SELECT-HISTORICO */

                    R0400_00_SELECT_HISTORICO_SECTION();

                    /*" -481- IF NOT STATUS-JA-ENVIADO */

                    if (!WORK_AREA.W_STATUS_PROPOSTA["STATUS_JA_ENVIADO"])
                    {

                        /*" -483- PERFORM R0430-00-LER-PROPOSTA */

                        R0430_00_LER_PROPOSTA_SECTION();

                        /*" -484- IF CERTIFICADO-ATIVO */

                        if (WORK_AREA.W_SITUACAO_CERTIFICADO["CERTIFICADO_ATIVO"])
                        {

                            /*" -485- PERFORM R0440-00-TRATA-CERTIFICADO */

                            R0440_00_TRATA_CERTIFICADO_SECTION();

                            /*" -486- PERFORM R0500-00-INCLUIR-HISTORICO */

                            R0500_00_INCLUIR_HISTORICO_SECTION();

                            /*" -489- PERFORM R0450-00-GERAR-REGISTRO-PGTO */

                            R0450_00_GERAR_REGISTRO_PGTO_SECTION();

                            /*" -491- PERFORM R0550-00-UPDATE-PROPFID. */

                            R0550_00_UPDATE_PROPFID_SECTION();
                        }

                    }

                }

            }


            /*" -494- MOVE NUM-CERTIFICADO OF DCLCOBER-HIST-VIDAZUL TO WS-NUM-CERTIFICADO. */
            _.Move(CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_CERTIFICADO, WORK_AREA.WS_NUM_CERTIFICADO);

            /*" -497- PERFORM R0950-00-FETCH-PROPOSTA UNTIL WS-EOR = 1 OR NUM-CERTIFICADO OF DCLCOBER-HIST-VIDAZUL NOT EQUAL WS-NUM-CERTIFICADO. */

            while (!(WORK_AREA.WS_EOR == 1 || CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_CERTIFICADO != WORK_AREA.WS_NUM_CERTIFICADO))
            {

                R0950_00_FETCH_PROPOSTA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-SELECT-OPCAOPAGVA-SECTION */
        private void R0330_00_SELECT_OPCAOPAGVA_SECTION()
        {
            /*" -509- MOVE '0330-00-SELECT-OPCAOPAGVA' TO PARAGRAFO. */
            _.Move("0330-00-SELECT-OPCAOPAGVA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -511- MOVE 'SELECT SEGUROS.OPCAO-PAG-VIDAZUL' TO COMANDO. */
            _.Move("SELECT SEGUROS.OPCAO-PAG-VIDAZUL", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -514- MOVE NUM-CERTIFICADO OF DCLCOBER-HIST-VIDAZUL TO OPCPAGVI-NUM-CERTIFICADO. */
            _.Move(CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_CERTIFICADO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

            /*" -517- MOVE '9999-12-31' TO OPCPAGVI-DATA-TERVIGENCIA. */
            _.Move("9999-12-31", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA);

            /*" -524- PERFORM R0330_00_SELECT_OPCAOPAGVA_DB_SELECT_1 */

            R0330_00_SELECT_OPCAOPAGVA_DB_SELECT_1();

            /*" -527- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -528- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -529- MOVE 2 TO W-PGTO-PARCELA */
                    _.Move(2, WORK_AREA.W_PGTO_PARCELA);

                    /*" -530- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -531- DISPLAY 'PF0709B - CERTIFICADO NAO EXISTE NA OPCAOPAGVA' */
                    _.Display($"PF0709B - CERTIFICADO NAO EXISTE NA OPCAOPAGVA");

                    /*" -533- DISPLAY '          NUM CERTIFICADO.............. ' OPCPAGVI-NUM-CERTIFICADO */
                    _.Display($"          NUM CERTIFICADO.............. {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                    /*" -534- GO TO R0330-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/ //GOTO
                    return;

                    /*" -535- ELSE */
                }
                else
                {


                    /*" -536- DISPLAY 'PF0709B - FIM ANORMAL' */
                    _.Display($"PF0709B - FIM ANORMAL");

                    /*" -537- DISPLAY '          ERRO SELECT OPCAO-PAG-VIDAZUL ' */
                    _.Display($"          ERRO SELECT OPCAO-PAG-VIDAZUL ");

                    /*" -539- DISPLAY '          NUM CERTIFICADO.............. ' OPCPAGVI-NUM-CERTIFICADO */
                    _.Display($"          NUM CERTIFICADO.............. {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                    /*" -541- DISPLAY '          SQLCODE...................... ' SQLCODE */
                    _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                    /*" -542- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -544- PERFORM R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION();
                }

            }


            /*" -551- MOVE OPCPAGVI-PERI-PAGAMENTO TO W-PERIODICIDADE-PGTO */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO, WORK_AREA.W_PERIODICIDADE_PGTO);

            /*" -552- IF PAGAMENTO-ANUAL */

            if (WORK_AREA.W_PERIODICIDADE_PGTO["PAGAMENTO_ANUAL"])
            {

                /*" -552- MOVE 2 TO W-PGTO-PARCELA. */
                _.Move(2, WORK_AREA.W_PGTO_PARCELA);
            }


        }

        [StopWatch]
        /*" R0330-00-SELECT-OPCAOPAGVA-DB-SELECT-1 */
        public void R0330_00_SELECT_OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -524- EXEC SQL SELECT PERI_PAGAMENTO INTO :OPCPAGVI-PERI-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO =:OPCPAGVI-NUM-CERTIFICADO AND DATA_TERVIGENCIA =:OPCPAGVI-DATA-TERVIGENCIA WITH UR END-EXEC. */

            var r0330_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1 = new R0330_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1()
            {
                OPCPAGVI_DATA_TERVIGENCIA = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA.ToString(),
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0330_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1.Execute(r0330_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0340-00-VERIFICAR-PGTO-SECTION */
        private void R0340_00_VERIFICAR_PGTO_SECTION()
        {
            /*" -564- MOVE '0340-00-VERIFICAR-PGTO' TO PARAGRAFO. */
            _.Move("0340-00-VERIFICAR-PGTO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -566- MOVE 'SELECT SEGUROS.PARCELAS_VIDAZUL' TO COMANDO. */
            _.Move("SELECT SEGUROS.PARCELAS_VIDAZUL", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -569- MOVE NUM-CERTIFICADO OF DCLCOBER-HIST-VIDAZUL TO NUM-CERTIFICADO OF DCLPARCELAS-VIDAZUL. */
            _.Move(CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_CERTIFICADO, PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_CERTIFICADO);

            /*" -572- MOVE NUM-PARCELA OF DCLCOBER-HIST-VIDAZUL TO NUM-PARCELA OF DCLPARCELAS-VIDAZUL. */
            _.Move(CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_PARCELA, PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA);

            /*" -575- MOVE '1' TO SIT-REGISTRO OF DCLPARCELAS-VIDAZUL. */
            _.Move("1", PARVDZUL.DCLPARCELAS_VIDAZUL.SIT_REGISTRO);

            /*" -586- PERFORM R0340_00_VERIFICAR_PGTO_DB_SELECT_1 */

            R0340_00_VERIFICAR_PGTO_DB_SELECT_1();

            /*" -589- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -590- MOVE 1 TO W-PGTO-POSTERIOR */
                _.Move(1, WORK_AREA.W_PGTO_POSTERIOR);

                /*" -591- ELSE */
            }
            else
            {


                /*" -592- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -593- MOVE 2 TO W-PGTO-POSTERIOR */
                    _.Move(2, WORK_AREA.W_PGTO_POSTERIOR);

                    /*" -594- ELSE */
                }
                else
                {


                    /*" -595- DISPLAY 'PF0709B - FIM ANORMAL' */
                    _.Display($"PF0709B - FIM ANORMAL");

                    /*" -596- DISPLAY '          ERRO SELECT PARCELAS VIDAZUL  ' */
                    _.Display($"          ERRO SELECT PARCELAS VIDAZUL  ");

                    /*" -598- DISPLAY '          NUM PROPOSTA................. ' NUM-CERTIFICADO OF DCLPARCELAS-VIDAZUL */
                    _.Display($"          NUM PROPOSTA................. {PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_CERTIFICADO}");

                    /*" -600- DISPLAY '          NUM PARCELA.................. ' NUM-PARCELA OF DCLPARCELAS-VIDAZUL */
                    _.Display($"          NUM PARCELA.................. {PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA}");

                    /*" -602- DISPLAY '          SQLCODE...................... ' SQLCODE */
                    _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                    /*" -603- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -603- PERFORM R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0340-00-VERIFICAR-PGTO-DB-SELECT-1 */
        public void R0340_00_VERIFICAR_PGTO_DB_SELECT_1()
        {
            /*" -586- EXEC SQL SELECT NUM_PARCELA INTO :DCLPARCELAS-VIDAZUL.NUM-PARCELA FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :DCLPARCELAS-VIDAZUL.NUM-CERTIFICADO AND NUM_PARCELA >= :DCLPARCELAS-VIDAZUL.NUM-PARCELA AND SIT_REGISTRO = :DCLPARCELAS-VIDAZUL.SIT-REGISTRO WITH UR END-EXEC. */

            var r0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1 = new R0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_CERTIFICADO.ToString(),
                SIT_REGISTRO = PARVDZUL.DCLPARCELAS_VIDAZUL.SIT_REGISTRO.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
            };

            var executed_1 = R0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1.Execute(r0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_PARCELA, PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-SELECT-PARCELA-SECTION */
        private void R0350_00_SELECT_PARCELA_SECTION()
        {
            /*" -616- MOVE '0350-00-SELECT-PARCELA' TO PARAGRAFO. */
            _.Move("0350-00-SELECT-PARCELA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -618- MOVE 'SELECT SEGUROS.PARCELAS_VIDAZUL' TO COMANDO. */
            _.Move("SELECT SEGUROS.PARCELAS_VIDAZUL", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -621- MOVE NUM-CERTIFICADO OF DCLCOBER-HIST-VIDAZUL TO NUM-CERTIFICADO OF DCLPARCELAS-VIDAZUL. */
            _.Move(CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_CERTIFICADO, PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_CERTIFICADO);

            /*" -624- MOVE NUM-PARCELA OF DCLCOBER-HIST-VIDAZUL TO NUM-PARCELA OF DCLPARCELAS-VIDAZUL. */
            _.Move(CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_PARCELA, PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA);

            /*" -633- PERFORM R0350_00_SELECT_PARCELA_DB_SELECT_1 */

            R0350_00_SELECT_PARCELA_DB_SELECT_1();

            /*" -636- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -637- DISPLAY 'PF0709B - FIM ANORMAL' */
                _.Display($"PF0709B - FIM ANORMAL");

                /*" -638- DISPLAY '          ERRO SELECT PARCELAS VIDAZUL  ' */
                _.Display($"          ERRO SELECT PARCELAS VIDAZUL  ");

                /*" -640- DISPLAY '          NUM PROPOSTA................. ' NUM-CERTIFICADO OF DCLPARCELAS-VIDAZUL */
                _.Display($"          NUM PROPOSTA................. {PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_CERTIFICADO}");

                /*" -642- DISPLAY '          NUM PARCELA.................. ' NUM-PARCELA OF DCLPARCELAS-VIDAZUL */
                _.Display($"          NUM PARCELA.................. {PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA}");

                /*" -644- DISPLAY '          SQLCODE...................... ' SQLCODE */
                _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                /*" -645- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -645- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R0350-00-SELECT-PARCELA-DB-SELECT-1 */
        public void R0350_00_SELECT_PARCELA_DB_SELECT_1()
        {
            /*" -633- EXEC SQL SELECT DATA_VENCIMENTO INTO :DCLPARCELAS-VIDAZUL.DATA-VENCIMENTO FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :DCLPARCELAS-VIDAZUL.NUM-CERTIFICADO AND NUM_PARCELA = :DCLPARCELAS-VIDAZUL.NUM-PARCELA WITH UR END-EXEC. */

            var r0350_00_SELECT_PARCELA_DB_SELECT_1_Query1 = new R0350_00_SELECT_PARCELA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_CERTIFICADO.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
            };

            var executed_1 = R0350_00_SELECT_PARCELA_DB_SELECT_1_Query1.Execute(r0350_00_SELECT_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DATA_VENCIMENTO, PARVDZUL.DCLPARCELAS_VIDAZUL.DATA_VENCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-SELECT-HISTORICO-SECTION */
        private void R0400_00_SELECT_HISTORICO_SECTION()
        {
            /*" -658- MOVE 'R0400-00-SELECT-HISTORICO' TO PARAGRAFO. */
            _.Move("R0400-00-SELECT-HISTORICO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -660- MOVE 'SELECT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("SELECT HIST-PROP-FIDELIZ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -663- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -665- MOVE 'ATR' TO PROPFIDH-SIT-COBRANCA-SIVPF */
            _.Move("ATR", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -668- MOVE DATA-VENCIMENTO OF DCLPARCELAS-VIDAZUL TO PROPFIDH-DATA-SITUACAO */
            _.Move(PARVDZUL.DCLPARCELAS_VIDAZUL.DATA_VENCIMENTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -679- PERFORM R0400_00_SELECT_HISTORICO_DB_SELECT_1 */

            R0400_00_SELECT_HISTORICO_DB_SELECT_1();

            /*" -682- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -683- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -684- MOVE 2 TO W-STATUS-PROPOSTA */
                    _.Move(2, WORK_AREA.W_STATUS_PROPOSTA);

                    /*" -685- ELSE */
                }
                else
                {


                    /*" -686- DISPLAY 'PF0709B - FIM ANORMAL' */
                    _.Display($"PF0709B - FIM ANORMAL");

                    /*" -687- DISPLAY '          ERRO ACESSO HIST-PROP-FIDELIZ' */
                    _.Display($"          ERRO ACESSO HIST-PROP-FIDELIZ");

                    /*" -689- DISPLAY '          NUMERO IDENTIFICACAO ' PROPFIDH-NUM-IDENTIFICACAO */
                    _.Display($"          NUMERO IDENTIFICACAO {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}");

                    /*" -691- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -692- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -693- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -694- ELSE */
                }

            }
            else
            {


                /*" -694- MOVE 1 TO W-STATUS-PROPOSTA. */
                _.Move(1, WORK_AREA.W_STATUS_PROPOSTA);
            }


        }

        [StopWatch]
        /*" R0400-00-SELECT-HISTORICO-DB-SELECT-1 */
        public void R0400_00_SELECT_HISTORICO_DB_SELECT_1()
        {
            /*" -679- EXEC SQL SELECT NUM_IDENTIFICACAO INTO :PROPFIDH-NUM-IDENTIFICACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPFIDH-NUM-IDENTIFICACAO AND DATA_SITUACAO = :PROPFIDH-DATA-SITUACAO AND SIT_COBRANCA_SIVPF = :PROPFIDH-SIT-COBRANCA-SIVPF WITH UR END-EXEC. */

            var r0400_00_SELECT_HISTORICO_DB_SELECT_1_Query1 = new R0400_00_SELECT_HISTORICO_DB_SELECT_1_Query1()
            {
                PROPFIDH_SIT_COBRANCA_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF.ToString(),
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_DATA_SITUACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.ToString(),
            };

            var executed_1 = R0400_00_SELECT_HISTORICO_DB_SELECT_1_Query1.Execute(r0400_00_SELECT_HISTORICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0430-00-LER-PROPOSTA-SECTION */
        private void R0430_00_LER_PROPOSTA_SECTION()
        {
            /*" -705- MOVE 'R0430-00-LER-PROPOSTA' TO PARAGRAFO. */
            _.Move("R0430-00-LER-PROPOSTA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -707- MOVE 'SELECT PROPOSTA VA' TO COMANDO. */
            _.Move("SELECT PROPOSTA VA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -714- PERFORM R0430_00_LER_PROPOSTA_DB_SELECT_1 */

            R0430_00_LER_PROPOSTA_DB_SELECT_1();

            /*" -717- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -718- DISPLAY 'PF0709B - FIM ANORMAL' */
                _.Display($"PF0709B - FIM ANORMAL");

                /*" -719- DISPLAY '          ERRO ACESSO PROPOSTA VA' */
                _.Display($"          ERRO ACESSO PROPOSTA VA");

                /*" -721- DISPLAY '          NUMERO CERTIFIACADO    ' NUM-CERTIFICADO OF DCLPARCELAS-VIDAZUL */
                _.Display($"          NUMERO CERTIFIACADO    {PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_CERTIFICADO}");

                /*" -723- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -724- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -725- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -726- ELSE */
            }
            else
            {


                /*" -727- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '3' OR '6' */

                if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO.In("3", "6"))
                {

                    /*" -728- MOVE 1 TO W-SITUACAO-CERTIFICADO */
                    _.Move(1, WORK_AREA.W_SITUACAO_CERTIFICADO);

                    /*" -729- ELSE */
                }
                else
                {


                    /*" -729- MOVE 2 TO W-SITUACAO-CERTIFICADO. */
                    _.Move(2, WORK_AREA.W_SITUACAO_CERTIFICADO);
                }

            }


        }

        [StopWatch]
        /*" R0430-00-LER-PROPOSTA-DB-SELECT-1 */
        public void R0430_00_LER_PROPOSTA_DB_SELECT_1()
        {
            /*" -714- EXEC SQL SELECT SIT_REGISTRO INTO :DCLPROPOSTAS-VA.SIT-REGISTRO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :DCLPARCELAS-VIDAZUL.NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0430_00_LER_PROPOSTA_DB_SELECT_1_Query1 = new R0430_00_LER_PROPOSTA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0430_00_LER_PROPOSTA_DB_SELECT_1_Query1.Execute(r0430_00_LER_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIT_REGISTRO, PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_99_SAIDA*/

        [StopWatch]
        /*" R0440-00-TRATA-CERTIFICADO-SECTION */
        private void R0440_00_TRATA_CERTIFICADO_SECTION()
        {
            /*" -741- MOVE 'R0440-00-TRATA-CERTIFICADO' TO PARAGRAFO. */
            _.Move("R0440-00-TRATA-CERTIFICADO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -743- MOVE ' ' TO COMANDO. */
            _.Move(" ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -747- IF NUM-CERTIFICADO OF DCLCOBER-HIST-VIDAZUL NOT LESS 10000000000 AND NUM-CERTIFICADO OF DCLCOBER-HIST-VIDAZUL NOT GREATER 19999999999 */

            if (CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_CERTIFICADO >= 10000000000 && CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_CERTIFICADO <= 19999999999)
            {

                /*" -751- MOVE NUM-CERTIFICADO OF DCLCOBER-HIST-VIDAZUL TO WCERTIFICADO W-NUM-PROPOSTA-ATUAL */
                _.Move(CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_CERTIFICADO, W01DIGCERT.WCERTIFICADO, WORK_AREA.FILLER_0.W_NUM_PROPOSTA_ATUAL);

                /*" -753- MOVE 'CALL PROM1101' TO COMANDO */
                _.Move("CALL PROM1101", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -755- CALL 'PROM1101' USING W01DIGCERT */
                _.Call("PROM1101", W01DIGCERT);

                /*" -756- MOVE WDIG TO W-DV-PROPOSTA-NOVA */
                _.Move(W01DIGCERT.WDIG, WORK_AREA.FILLER_0.W_DV_PROPOSTA_NOVA);

                /*" -757- ELSE */
            }
            else
            {


                /*" -758- MOVE NUM-CERTIFICADO OF DCLCOBER-HIST-VIDAZUL TO W-NUM-PROPOSTA-NOVA. */
                _.Move(CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_CERTIFICADO, WORK_AREA.W_NUM_PROPOSTA_NOVA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0440_SAIDA*/

        [StopWatch]
        /*" R0450-00-GERAR-REGISTRO-PGTO-SECTION */
        private void R0450_00_GERAR_REGISTRO_PGTO_SECTION()
        {
            /*" -768- MOVE 'R0450-00-GERAR-REGISTRO-PGTO' TO PARAGRAFO. */
            _.Move("R0450-00-GERAR-REGISTRO-PGTO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -770- MOVE 'WRITE REG-STA-PROPOSTA' TO COMANDO. */
            _.Move("WRITE REG-STA-PROPOSTA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -772- MOVE SPACES TO REG-PGTO-SASSE. */
            _.Move("", LBFCT016.REG_PGTO_SASSE);

            /*" -775- MOVE '4' TO R4-TIPO-REG OF REG-PGTO-SASSE. */
            _.Move("4", LBFCT016.REG_PGTO_SASSE.R4_TIPO_REG);

            /*" -782- MOVE W-NUM-PROPOSTA-NOVA TO R4-NUM-PROPOSTA OF REG-PGTO-SASSE. */
            _.Move(WORK_AREA.W_NUM_PROPOSTA_NOVA, LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA);

            /*" -785- MOVE PROPFIDH-SIT-COBRANCA-SIVPF TO R4-SIT-COBRANCA OF REG-PGTO-SASSE. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA);

            /*" -788- MOVE PROPFIDH-DATA-SITUACAO TO DATA-SQL1. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, WORK_AREA.DATA_SQL1);

            /*" -789- MOVE DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WORK_AREA.DATA_SQL.DIA_SQL, WORK_AREA.FILLER_3.W_DIA_TRABALHO);

            /*" -790- MOVE MES-SQL TO W-MES-TRABALHO. */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.FILLER_3.W_MES_TRABALHO);

            /*" -792- MOVE ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.FILLER_3.W_ANO_TRABALHO);

            /*" -795- MOVE W-DATA-TRABALHO TO R4-DATA-SITUACAO OF REG-PGTO-SASSE. */
            _.Move(WORK_AREA.W_DATA_TRABALHO, LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO);

            /*" -799- MOVE ZEROS TO R4-PARCELAS-PAGAS OF REG-PGTO-SASSE R4-TOTAL-PARCELAS OF REG-PGTO-SASSE */
            _.Move(0, LBFCT016.REG_PGTO_SASSE.R4_PARCELAS_PAGAS, LBFCT016.REG_PGTO_SASSE.R4_TOTAL_PARCELAS);

            /*" -801- WRITE REG-STA-SASSE FROM REG-PGTO-SASSE. */
            _.Move(LBFCT016.REG_PGTO_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -801- ADD 1 TO W-QTD-LD-TIPO-4. */
            WORK_AREA.W_QTD_LD_TIPO_4.Value = WORK_AREA.W_QTD_LD_TIPO_4 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_SAIDA*/

        [StopWatch]
        /*" R0500-00-INCLUIR-HISTORICO-SECTION */
        private void R0500_00_INCLUIR_HISTORICO_SECTION()
        {
            /*" -811- MOVE 'R0500-INCLUIR-HISTORICO' TO PARAGRAFO */
            _.Move("R0500-INCLUIR-HISTORICO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -813- MOVE 'INSERT HIST PROP FIDELIZ' TO COMANDO */
            _.Move("INSERT HIST PROP FIDELIZ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -816- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -819- MOVE DATA-VENCIMENTO OF DCLPARCELAS-VIDAZUL TO PROPFIDH-DATA-SITUACAO. */
            _.Move(PARVDZUL.DCLPARCELAS_VIDAZUL.DATA_VENCIMENTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -822- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO PROPFIDH-NSAS-SIVPF. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -825- MOVE W-QTD-LD-TIPO-4 TO PROPFIDH-NSL. */
            _.Move(WORK_AREA.W_QTD_LD_TIPO_4, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -828- MOVE 'EMT' TO PROPFIDH-SIT-PROPOSTA. */
            _.Move("EMT", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -831- MOVE 'ATR' TO PROPFIDH-SIT-COBRANCA-SIVPF. */
            _.Move("ATR", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -834- MOVE 100 TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(100, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -837- MOVE PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -840- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -851- PERFORM R0500_00_INCLUIR_HISTORICO_DB_INSERT_1 */

            R0500_00_INCLUIR_HISTORICO_DB_INSERT_1();

            /*" -854- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -855- DISPLAY 'PF0709B - FIM ANORMAL' */
                _.Display($"PF0709B - FIM ANORMAL");

                /*" -856- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -858- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-CERTIFICADO OF DCLPARCELAS-VIDAZUL */
                _.Display($"          NUMERO PROPOSTA...............  {PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_CERTIFICADO}");

                /*" -860- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPFIDH-NUM-IDENTIFICACAO */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}");

                /*" -862- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -863- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -863- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R0500-00-INCLUIR-HISTORICO-DB-INSERT-1 */
        public void R0500_00_INCLUIR_HISTORICO_DB_INSERT_1()
        {
            /*" -851- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF , :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

            var r0500_00_INCLUIR_HISTORICO_DB_INSERT_1_Insert1 = new R0500_00_INCLUIR_HISTORICO_DB_INSERT_1_Insert1()
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

            R0500_00_INCLUIR_HISTORICO_DB_INSERT_1_Insert1.Execute(r0500_00_INCLUIR_HISTORICO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-UPDATE-PROPFID-SECTION */
        private void R0550_00_UPDATE_PROPFID_SECTION()
        {
            /*" -873- MOVE 'R0550-00-UPDATE-PROPFID' TO PARAGRAFO. */
            _.Move("R0550-00-UPDATE-PROPFID", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -875- MOVE 'UPDATE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA-FIDELIZ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -877- MOVE 'PF0709B' TO PROPOFID-COD-USUARIO. */
            _.Move("PF0709B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -885- PERFORM R0550_00_UPDATE_PROPFID_DB_UPDATE_1 */

            R0550_00_UPDATE_PROPFID_DB_UPDATE_1();

            /*" -888- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -889- DISPLAY 'PF0709B - FIM ANORMAL' */
                _.Display($"PF0709B - FIM ANORMAL");

                /*" -890- DISPLAY '          ERRO UPDATE PROPOSTA FIDELIZ  ' */
                _.Display($"          ERRO UPDATE PROPOSTA FIDELIZ  ");

                /*" -892- DISPLAY '          NUM PROPOSTA................. ' NUM-CERTIFICADO OF DCLPARCELAS-VIDAZUL */
                _.Display($"          NUM PROPOSTA................. {PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_CERTIFICADO}");

                /*" -894- DISPLAY '          SQLCODE...................... ' SQLCODE */
                _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                /*" -895- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -896- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -896- END-IF. */
            }


        }

        [StopWatch]
        /*" R0550-00-UPDATE-PROPFID-DB-UPDATE-1 */
        public void R0550_00_UPDATE_PROPFID_DB_UPDATE_1()
        {
            /*" -885- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET NSAS_SIVPF = :PROPFIDH-NSAS-SIVPF, NSL = :PROPFIDH-NSL , COD_USUARIO = :PROPOFID-COD-USUARIO , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_PROPOSTA_SIVPF = :DCLPARCELAS-VIDAZUL.NUM-CERTIFICADO END-EXEC. */

            var r0550_00_UPDATE_PROPFID_DB_UPDATE_1_Update1 = new R0550_00_UPDATE_PROPFID_DB_UPDATE_1_Update1()
            {
                PROPOFID_COD_USUARIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO.ToString(),
                PROPFIDH_NSAS_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF.ToString(),
                PROPFIDH_NSL = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL.ToString(),
                NUM_CERTIFICADO = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_CERTIFICADO.ToString(),
            };

            R0550_00_UPDATE_PROPFID_DB_UPDATE_1_Update1.Execute(r0550_00_UPDATE_PROPFID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-GERAR-TRAILLER-SECTION */
        private void R0800_00_GERAR_TRAILLER_SECTION()
        {
            /*" -906- MOVE 'R0800-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R0800-00-GERAR-TRAILLER", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -908- MOVE 'WRITE REG-TRAILLER-STA' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER-STA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -910- MOVE SPACES TO REG-TRAILLER-STA. */
            _.Move("", LBFCT011.REG_TRAILLER_STA);

            /*" -913- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -916- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -919- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA */
            _.Move(WORK_AREA.W_QTD_LD_TIPO_4, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4);

            /*" -930- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -939- MOVE ZEROS TO RT-QTDE-TIPO-1 RT-QTDE-TIPO-2 RT-QTDE-TIPO-3 RT-QTDE-TIPO-5 RT-QTDE-TIPO-6 RT-QTDE-TIPO-7 RT-QTDE-TIPO-8 RT-QTDE-TIPO-9. */
            _.Move(0, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9);

            /*" -939- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -952- MOVE 'R0850-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R0850-00-CONTROLAR-ARQ-ENVIADO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -954- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -957- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -960- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -964- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -967- MOVE RT-QTDE-TIPO-4 OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -975- PERFORM R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -979- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -980- DISPLAY 'PF0709B - FIM ANORMAL' */
                _.Display($"PF0709B - FIM ANORMAL");

                /*" -981- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -983- DISPLAY '          SIGLA DO ARQUIVO... ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQUIVO... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -985- DISPLAY '          SISTEMA DE ORIGEM.. ' ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF */
                _.Display($"          SISTEMA DE ORIGEM.. {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM}");

                /*" -987- DISPLAY '          NSAS SIVPF......... ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF......... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -989- DISPLAY '          SQLCODE............ ' SQLCODE */
                _.Display($"          SQLCODE............ {DB.SQLCODE}");

                /*" -990- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -990- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -975- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
        /*" R0900-00-DECLARE-PROPOSTA-SECTION */
        private void R0900_00_DECLARE_PROPOSTA_SECTION()
        {
            /*" -1000- MOVE 'R0900-00-DECLARE-PROPOSTA   ' TO PARAGRAFO. */
            _.Move("R0900-00-DECLARE-PROPOSTA   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1002- MOVE 'DECLARE CPROPOSTA           ' TO COMANDO. */
            _.Move("DECLARE CPROPOSTA           ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1022- PERFORM R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1();

            /*" -1026- MOVE 'OPEN CPROPOSTA                     ' TO COMANDO. */
            _.Move("OPEN CPROPOSTA                     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1026- PERFORM R0900_00_DECLARE_PROPOSTA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOSTA_DB_OPEN_1();

            /*" -1029- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1030- DISPLAY 'PF0709B - FIM ANORMAL' */
                _.Display($"PF0709B - FIM ANORMAL");

                /*" -1031- DISPLAY '          ERRO OPEN CURSOR CPROPOSTA   ' */
                _.Display($"          ERRO OPEN CURSOR CPROPOSTA   ");

                /*" -1033- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -1033- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1()
        {
            /*" -1022- EXEC SQL DECLARE CPROPOSTA CURSOR FOR SELECT B.NUM_CERTIFICADO , A.NUM_IDENTIFICACAO, A.COD_EMPRESA_SIVPF, A.COD_PRODUTO_SIVPF, B.NUM_PARCELA , B.DATA_VENCIMENTO , B.OPCAO_PAGAMENTO , B.SIT_REGISTRO FROM SEGUROS.PROPOSTA_FIDELIZ A, SEGUROS.COBER_HIST_VIDAZUL B WHERE A.NUM_PROPOSTA_SIVPF = B.NUM_CERTIFICADO AND A.SIT_PROPOSTA IN ( 'EMT' , 'MAN' ) AND B.SIT_REGISTRO IN ( ' ' , '0' ) AND B.DATA_VENCIMENTO <= :WHOST-DT-INI-ATR AND A.COD_PRODUTO_SIVPF NOT IN (48, 7708, 9341, 9350, 9348) ORDER BY B.NUM_CERTIFICADO, B.NUM_PARCELA DESC WITH UR END-EXEC. */
            CPROPOSTA = new PF0709B_CPROPOSTA(true);
            string GetQuery_CPROPOSTA()
            {
                var query = @$"SELECT B.NUM_CERTIFICADO
							, 
							A.NUM_IDENTIFICACAO
							, 
							A.COD_EMPRESA_SIVPF
							, 
							A.COD_PRODUTO_SIVPF
							, 
							B.NUM_PARCELA
							, 
							B.DATA_VENCIMENTO
							, 
							B.OPCAO_PAGAMENTO
							, 
							B.SIT_REGISTRO 
							FROM SEGUROS.PROPOSTA_FIDELIZ A
							, 
							SEGUROS.COBER_HIST_VIDAZUL B 
							WHERE A.NUM_PROPOSTA_SIVPF = B.NUM_CERTIFICADO 
							AND A.SIT_PROPOSTA IN ( 'EMT'
							, 'MAN' ) 
							AND B.SIT_REGISTRO IN ( ' '
							, '0' ) 
							AND B.DATA_VENCIMENTO <= '{WHOST_DT_INI_ATR}' 
							AND A.COD_PRODUTO_SIVPF NOT IN 
							(48
							, 7708
							, 9341
							, 9350
							, 9348) 
							ORDER BY B.NUM_CERTIFICADO
							, B.NUM_PARCELA DESC";

                return query;
            }
            CPROPOSTA.GetQueryEvent += GetQuery_CPROPOSTA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_OPEN_1()
        {
            /*" -1026- EXEC SQL OPEN CPROPOSTA END-EXEC. */

            CPROPOSTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-SECTION */
        private void R0950_00_FETCH_PROPOSTA_SECTION()
        {
            /*" -1044- MOVE 'R0950-00-FETCH-PROPOSTA     ' TO PARAGRAFO. */
            _.Move("R0950-00-FETCH-PROPOSTA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1046- MOVE 'FETCH CPROPOSTA             ' TO COMANDO. */
            _.Move("FETCH CPROPOSTA             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1056- PERFORM R0950_00_FETCH_PROPOSTA_DB_FETCH_1 */

            R0950_00_FETCH_PROPOSTA_DB_FETCH_1();

            /*" -1059- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1059- PERFORM R0950_00_FETCH_PROPOSTA_DB_CLOSE_1 */

                R0950_00_FETCH_PROPOSTA_DB_CLOSE_1();

                /*" -1061- MOVE 1 TO WS-EOR */
                _.Move(1, WORK_AREA.WS_EOR);

                /*" -1062- ELSE */
            }
            else
            {


                /*" -1064- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

                if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
                {

                    /*" -1065- DISPLAY 'PF0709B - FIM ANORMAL' */
                    _.Display($"PF0709B - FIM ANORMAL");

                    /*" -1066- DISPLAY '          ERRO FETCH CURSOR CPROPOSTA   ' */
                    _.Display($"          ERRO FETCH CURSOR CPROPOSTA   ");

                    /*" -1068- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -1069- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1070- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -1071- ELSE */
                }
                else
                {


                    /*" -1074- ADD 1 TO AC-L-MOVIMENTO, AC-CONTROLE */
                    WORK_AREA.AC_L_MOVIMENTO.Value = WORK_AREA.AC_L_MOVIMENTO + 1;
                    WORK_AREA.AC_CONTROLE.Value = WORK_AREA.AC_CONTROLE + 1;

                    /*" -1075- IF AC-CONTROLE GREATER 999 */

                    if (WORK_AREA.AC_CONTROLE > 999)
                    {

                        /*" -1076- ACCEPT WS-TIME FROM TIME */
                        _.Move(_.AcceptDate("TIME"), WS_TIME);

                        /*" -1077- MOVE WS-TIME-N TO WS-TIME-EDIT */
                        _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

                        /*" -1080- DISPLAY '*  PF0709B - TOTAL LIDOS... ' AC-L-MOVIMENTO '  HORAS  ' WS-TIME-EDIT */

                        $"*  PF0709B - TOTAL LIDOS... {WORK_AREA.AC_L_MOVIMENTO}  HORAS  {WS_TIME_EDIT}"
                        .Display();

                        /*" -1080- MOVE ZEROS TO AC-CONTROLE. */
                        _.Move(0, WORK_AREA.AC_CONTROLE);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-DB-FETCH-1 */
        public void R0950_00_FETCH_PROPOSTA_DB_FETCH_1()
        {
            /*" -1056- EXEC SQL FETCH CPROPOSTA INTO :DCLCOBER-HIST-VIDAZUL.NUM-CERTIFICADO , :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-COD-EMPRESA-SIVPF , :PROPOFID-COD-PRODUTO-SIVPF , :DCLCOBER-HIST-VIDAZUL.NUM-PARCELA , :DCLCOBER-HIST-VIDAZUL.DATA-VENCIMENTO , :DCLCOBER-HIST-VIDAZUL.OPCAO-PAGAMENTO , :DCLCOBER-HIST-VIDAZUL.SIT-REGISTRO END-EXEC. */

            if (CPROPOSTA.Fetch())
            {
                _.Move(CPROPOSTA.DCLCOBER_HIST_VIDAZUL_NUM_CERTIFICADO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_CERTIFICADO);
                _.Move(CPROPOSTA.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(CPROPOSTA.PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(CPROPOSTA.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(CPROPOSTA.DCLCOBER_HIST_VIDAZUL_NUM_PARCELA, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_PARCELA);
                _.Move(CPROPOSTA.DCLCOBER_HIST_VIDAZUL_DATA_VENCIMENTO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.DATA_VENCIMENTO);
                _.Move(CPROPOSTA.DCLCOBER_HIST_VIDAZUL_OPCAO_PAGAMENTO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OPCAO_PAGAMENTO);
                _.Move(CPROPOSTA.DCLCOBER_HIST_VIDAZUL_SIT_REGISTRO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.SIT_REGISTRO);
            }

        }

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-DB-CLOSE-1 */
        public void R0950_00_FETCH_PROPOSTA_DB_CLOSE_1()
        {
            /*" -1059- EXEC SQL CLOSE CPROPOSTA END-EXEC */

            CPROPOSTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-IMPRIMIR-TOTAIS-SECTION */
        private void R1000_00_IMPRIMIR_TOTAIS_SECTION()
        {
            /*" -1090- MOVE 'R0870-00-GERAR-TOTAIS' TO PARAGRAFO. */
            _.Move("R0870-00-GERAR-TOTAIS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1092- MOVE ' ' TO COMANDO. */
            _.Move(" ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1093- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1094- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -1095- DISPLAY '*                                              *' . */
            _.Display($"*                                              *");

            /*" -1096- DISPLAY '*           PF0709B - TERMINO NORMAL           *' . */
            _.Display($"*           PF0709B - TERMINO NORMAL           *");

            /*" -1097- DISPLAY '*                                              *' . */
            _.Display($"*                                              *");

            /*" -1099- DISPLAY '*    TOTAL REGISTROS LIDOS........ ' AC-L-MOVIMENTO '      *' . */

            $"*    TOTAL REGISTROS LIDOS........ {WORK_AREA.AC_L_MOVIMENTO}      *"
            .Display();

            /*" -1100- DISPLAY '*                                              *' . */
            _.Display($"*                                              *");

            /*" -1102- DISPLAY '*    TOTAL GERADO ARQ. STATUS..... ' W-QTD-LD-TIPO-4 '      *' . */

            $"*    TOTAL GERADO ARQ. STATUS..... {WORK_AREA.W_QTD_LD_TIPO_4}      *"
            .Display();

            /*" -1103- DISPLAY '*                                              *' . */
            _.Display($"*                                              *");

            /*" -1103- DISPLAY '************************************************' . */
            _.Display($"************************************************");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_00_SAIDA*/

        [StopWatch]
        /*" R1100-00-FECHAR-ARQUIVOS-SECTION */
        private void R1100_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -1112- CLOSE MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1122- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

            /*" -1123- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_ABEND.WSQLERRO.WSQLERRMC);

            /*" -1124- MOVE SQLCODE TO RETURN-CODE. */
            _.Move(DB.SQLCODE, RETURN_CODE);

            /*" -1125- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], AREA_ABEND.WABEND.WSQLERRD1);

            /*" -1126- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], AREA_ABEND.WABEND.WSQLERRD2);

            /*" -1127- DISPLAY '* ' WABEND. */
            _.Display($"* {AREA_ABEND.WABEND}");

            /*" -1128- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1);

            /*" -1129- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_2);

            /*" -1131- DISPLAY WSQLERRO. */
            _.Display(AREA_ABEND.WSQLERRO);

            /*" -1131- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1132- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1134- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -1135- DISPLAY '*                                              *' . */
            _.Display($"*                                              *");

            /*" -1136- DISPLAY '*          PF0709B - TERMINO  ANORMAL          *' . */
            _.Display($"*          PF0709B - TERMINO  ANORMAL          *");

            /*" -1137- DISPLAY '*                                              *' . */
            _.Display($"*                                              *");

            /*" -1139- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -1140- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1140- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}