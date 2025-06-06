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
using Sias.PessoaFisica.DB2.PF0720B;

namespace Code
{
    public class PF0720B
    {
        public bool IsCall { get; set; }

        public PF0720B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------*                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA A CEF STATUS DE PAGAMENTO DAS *      */
        /*"      *                             DEMAIS PARCELAS DE VIDA.           *      */
        /*"      *   ANALISE/PROGRAMACAO.....  LUIZ CARLOS.                       *      */
        /*"      *   REVISAO ................  REGINALDO SILVA                    *      */
        /*"      *   PROGRAMA ...............  PF0720B                            *      */
        /*"      *   DATA ...................  23/01/2007.                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 17 -  ADAILTON DIAS                                     *      */
        /*"      *               - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1    *      */
        /*"      *   EM 30/01/2019 - ATOS BR                                      *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 16             COLOCAR O TRATAMENTO PARA O PRODUTO      *      */
        /*"      * ATENDE HIST 169350    VIDA EXCLUSIVO QUE ESTAVA SENDO FEITO NO *      */
        /*"      *                       VA2721B.                                 *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.16          CLAUDETE RADEL                           *      */
        /*"      *                       28/08/2018                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 15             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       02/06/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 14             DB2.V10  SELECTS                         *      */
        /*"      * ATENDE CADMUS 84811                                            *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.14          REGINALDO SILVA                          *      */
        /*"      *                       05/09/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 13             AJUSTE ROTINA RETUN_CODE + REVISAO       *      */
        /*"      * ATENDE CADMUS 80536                                            *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.13          REGINALDO SILVA                          *      */
        /*"      *                       05/09/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - ATENDE CADMUS 69862                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/05/2011 - MARCUS ANDRE DIAS        PROCURE POR V.12    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - ATENDE CADMUS 69621                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/05/2011 - MARCUS ANDRE DIAS        PROCURE POR V.11    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - ATENDE CADMUS 68192                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/05/2011 - MARCUS ANDRE DIAS        PROCURE POR V.10    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - ATENDE CADMUS32886                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/11/2009 - EDILANA CERQUEIRA        PROCURE POR V.09    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - INLCUI SIT-REGISTRO = 1 OU 0 NO CURSOR           *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/08/2009 - LUIZ CARLOS/ EDILANA     PROCURE POR V.08    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - INLCUI SIT-REGISTRO = 1 NO CURSOR                *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/07/2009 - LUIZ CARLOS/ EDILANA     PROCURE POR V.07    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CURSOR MODIFICADO PARA BUSCAR CASOS DE NUM-CERT. *      */
        /*"      *               IGUAL AO NUM-SICOB E DIFERENTE NUM-PROPOSTA-SIVPF*      */
        /*"      *   EM 22/06/2009 - LUIZ CARLOS/ EDILANA     PROCURE POR V.06    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CURSOR MODIFICADO PARA IGNORAR VENDAS NA GITEL.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/06/2009 - LUIZ CARLOS/ EDILANA     PROCURE POR V.05    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - INCLUI CRÍTICAS PARA PRODUTO PRESTAMISTA         *      */
        /*"      *               E TRATA CURSOR PARA TRAZER PRESTAMISTA GITEL     *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/05/2009 - EDILANA E. CERQUEIRA     PROCURE POR V.04    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - PASSA A DESPREZAR PRODUTOS VIDA DA GENTE (11)    *      */
        /*"      *               COMERCIALIZADOS NA GITEL                         *      */
        /*"      *   EM 05/06/2008 - LUCIA VIEIRA             PROCURE POR V.03    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - PASSA A TRABALHAR A CONVERSAO SICOB              *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/06/2007 - LUIZ CARLOS CONCEICAO    PROCURE POR V.01    *      */
        /*"      *                                                                *      */
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
        /*"01  WHOST-DATA-PGTO                  PIC X(10).*/
        public StringBasis WHOST_DATA_PGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-DATA-CREDITO               PIC X(10).*/
        public StringBasis WHOST_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WORK-AREA.*/
        public PF0720B_WORK_AREA WORK_AREA { get; set; } = new PF0720B_WORK_AREA();
        public class PF0720B_WORK_AREA : VarBasis
        {
            /*"    05  W-NUM-PROPOSTA-NOVA           PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FILLER REDEFINES W-NUM-PROPOSTA-NOVA.*/
            private _REDEF_PF0720B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0720B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0720B_FILLER_0(); _.Move(W_NUM_PROPOSTA_NOVA, _filler_0); VarBasis.RedefinePassValue(W_NUM_PROPOSTA_NOVA, _filler_0, W_NUM_PROPOSTA_NOVA); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_NUM_PROPOSTA_NOVA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_NUM_PROPOSTA_NOVA); }
            }  //Redefines
            public class _REDEF_PF0720B_FILLER_0 : VarBasis
            {
                /*"        07  W-NUM-PROPOSTA-ATUAL      PIC 9(013).*/
                public IntBasis W_NUM_PROPOSTA_ATUAL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        07  W-DV-PROPOSTA-NOVA        PIC 9(001).*/
                public IntBasis W_DV_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  WS-NUM-PROPOSTA-1             PIC 9(014).*/

                public _REDEF_PF0720B_FILLER_0()
                {
                    W_NUM_PROPOSTA_ATUAL.ValueChanged += OnValueChanged;
                    W_DV_PROPOSTA_NOVA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUM_PROPOSTA_1 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  WS-NUM-PROPOSTA-R             REDEFINES        WS-NUM-PROPOSTA-1.*/
            private _REDEF_PF0720B_WS_NUM_PROPOSTA_R _ws_num_proposta_r { get; set; }
            public _REDEF_PF0720B_WS_NUM_PROPOSTA_R WS_NUM_PROPOSTA_R
            {
                get { _ws_num_proposta_r = new _REDEF_PF0720B_WS_NUM_PROPOSTA_R(); _.Move(WS_NUM_PROPOSTA_1, _ws_num_proposta_r); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA_1, _ws_num_proposta_r, WS_NUM_PROPOSTA_1); _ws_num_proposta_r.ValueChanged += () => { _.Move(_ws_num_proposta_r, WS_NUM_PROPOSTA_1); }; return _ws_num_proposta_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_r, WS_NUM_PROPOSTA_1); }
            }  //Redefines
            public class _REDEF_PF0720B_WS_NUM_PROPOSTA_R : VarBasis
            {
                /*"        10  WS-NUM-PROPOSTA-2         PIC 9(002).*/
                public IntBasis WS_NUM_PROPOSTA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        10  WS-NUM-PROPOSTA-11        PIC 9(011).*/
                public IntBasis WS_NUM_PROPOSTA_11 { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"        10  WS-NUM-PROPOSTA-01        PIC 9(001).*/
                public IntBasis WS_NUM_PROPOSTA_01 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05 W-LER-PARCELA                 PIC 9(001)   VALUE ZEROS.*/

                public _REDEF_PF0720B_WS_NUM_PROPOSTA_R()
                {
                    WS_NUM_PROPOSTA_2.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_11.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_01.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_LER_PARCELA { get; set; } = new SelectorBasis("001", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PARCELA-ENCONTRADA                      VALUE 1. */
							new SelectorItemBasis("PARCELA_ENCONTRADA", "1")
                }
            };

            /*"    05 W-PROPOSTA-CADASTRADA         PIC 9(001)   VALUE ZEROS.*/

            public SelectorBasis W_PROPOSTA_CADASTRADA { get; set; } = new SelectorBasis("001", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTA-CADASTRADA                     VALUE 1. */
							new SelectorItemBasis("PROPOSTA_CADASTRADA", "1")
                }
            };

            /*"    05 WS-EOR                        PIC  9(001)  VALUE ZEROS.*/
            public IntBasis WS_EOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 AC-CONTROLE                   PIC  9(006)  VALUE ZEROS.*/
            public IntBasis AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-L-MOVIMENTO                PIC  9(006)  VALUE ZEROS.*/
            public IntBasis AC_L_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 W-QTD-LD-TIPO-8               PIC  9(006)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 DATA-SQL1                     PIC  X(010).*/
            public StringBasis DATA_SQL1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 DATA-SQL  REDEFINES DATA-SQL1.*/
            private _REDEF_PF0720B_DATA_SQL _data_sql { get; set; }
            public _REDEF_PF0720B_DATA_SQL DATA_SQL
            {
                get { _data_sql = new _REDEF_PF0720B_DATA_SQL(); _.Move(DATA_SQL1, _data_sql); VarBasis.RedefinePassValue(DATA_SQL1, _data_sql, DATA_SQL1); _data_sql.ValueChanged += () => { _.Move(_data_sql, DATA_SQL1); }; return _data_sql; }
                set { VarBasis.RedefinePassValue(value, _data_sql, DATA_SQL1); }
            }  //Redefines
            public class _REDEF_PF0720B_DATA_SQL : VarBasis
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

                public _REDEF_PF0720B_DATA_SQL()
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
            private _REDEF_PF0720B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0720B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0720B_FILLER_3(); _.Move(W_DATA_TRABALHO, _filler_3); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_3, W_DATA_TRABALHO); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_DATA_TRABALHO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0720B_FILLER_3 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0720B_FILLER_3()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0720B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0720B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0720B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0720B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0720B_W_DTMOVABE1()
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
            private _REDEF_PF0720B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0720B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0720B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0720B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0720B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0720B_WS_TIME WS_TIME { get; set; } = new PF0720B_WS_TIME();
        public class PF0720B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01             W01DIGCERT.*/
        public PF0720B_W01DIGCERT W01DIGCERT { get; set; } = new PF0720B_W01DIGCERT();
        public class PF0720B_W01DIGCERT : VarBasis
        {
            /*"    05         WCERTIFICADO    PIC  9(015)        VALUE  0.*/
            public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05         WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
            public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
            /*"    05         WDIG            PIC  X(001)  VALUE SPACES.*/
            public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  AREA-ABEND.*/
        }
        public PF0720B_AREA_ABEND AREA_ABEND { get; set; } = new PF0720B_AREA_ABEND();
        public class PF0720B_AREA_ABEND : VarBasis
        {
            /*"    05   WABEND.*/
            public PF0720B_WABEND WABEND { get; set; } = new PF0720B_WABEND();
            public class PF0720B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0720B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0720B  ");
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
            public PF0720B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0720B_LOCALIZA_ABEND_1();
            public class PF0720B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0720B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0720B_LOCALIZA_ABEND_2();
            public class PF0720B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Copies.LBFPF025 LBFPF025 { get; set; } = new Copies.LBFPF025();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.IDERELAC IDERELAC { get; set; } = new Dclgens.IDERELAC();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public PF0720B_CPAGAMENTOS CPAGAMENTOS { get; set; } = new PF0720B_CPAGAMENTOS();
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
            /*" -298- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -299- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -300- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -303- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -304- DISPLAY '*               PROGRAMA PF0720B               *' . */
            _.Display($"*               PROGRAMA PF0720B               *");

            /*" -305- DISPLAY '*   STATUS DE PAGAMENTO  DAS DEMAIS PARCELAS   *' . */
            _.Display($"*   STATUS DE PAGAMENTO  DAS DEMAIS PARCELAS   *");

            /*" -307- DISPLAY '*           VERSAO:  16 - 28/08/2018           *' . */
            _.Display($"*           VERSAO:  16 - 28/08/2018           *");

            /*" -308- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -317- DISPLAY '*  PF0720B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0720B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -319- PERFORM R0100-00-INICIALIZA. */

            R0100_00_INICIALIZA_SECTION();

            /*" -320- PERFORM R0900-00-DECLARE-PAGAMENTOS. */

            R0900_00_DECLARE_PAGAMENTOS_SECTION();

            /*" -322- PERFORM R0950-00-FETCH-PROPOSTA. */

            R0950_00_FETCH_PROPOSTA_SECTION();

            /*" -323- IF WS-EOR = 1 */

            if (WORK_AREA.WS_EOR == 1)
            {

                /*" -324- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -325- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -326- DISPLAY '*           PF0720B - TERMINO NORMAL           *' */
                _.Display($"*           PF0720B - TERMINO NORMAL           *");

                /*" -327- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -328- DISPLAY '*     ---- NAO HOUVE PAGAMENTO NO DIA ----     *' */
                _.Display($"*     ---- NAO HOUVE PAGAMENTO NO DIA ----     *");

                /*" -329- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -330- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -332- GO TO R0000-00-FINALIZA. */

                R0000_00_FINALIZA(); //GOTO
                return;
            }


            /*" -334- PERFORM R0150-00-ABRIR-ARQUIVOS. */

            R0150_00_ABRIR_ARQUIVOS_SECTION();

            /*" -336- PERFORM R0200-00-OBTER-MAX-NSAS. */

            R0200_00_OBTER_MAX_NSAS_SECTION();

            /*" -338- PERFORM R0250-00-GERAR-HEADER */

            R0250_00_GERAR_HEADER_SECTION();

            /*" -341- PERFORM R0300-00-PROCESSA-REGISTRO UNTIL WS-EOR = 1. */

            while (!(WORK_AREA.WS_EOR == 1))
            {

                R0300_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -343- PERFORM R0800-00-GERAR-TRAILLER. */

            R0800_00_GERAR_TRAILLER_SECTION();

            /*" -345- PERFORM R0850-00-CONTROLAR-ARQ-ENVIADO */

            R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -347- PERFORM R1000-00-IMPRIMIR-TOTAIS. */

            R1000_00_IMPRIMIR_TOTAIS_SECTION();

            /*" -347- PERFORM R1100-00-FECHAR-ARQUIVOS. */

            R1100_00_FECHAR_ARQUIVOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_00_FINALIZA */

            R0000_00_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-FINALIZA */
        private void R0000_00_FINALIZA(bool isPerform = false)
        {
            /*" -354- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -358- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -358- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-SECTION */
        private void R0100_00_INICIALIZA_SECTION()
        {
            /*" -366- MOVE '0000-PRINCIPAL               ' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL               ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -368- MOVE 'R0100-00-SELECT-SISTEMAS     ' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-SISTEMAS     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -370- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -376- PERFORM R0100_00_INICIALIZA_DB_SELECT_1 */

            R0100_00_INICIALIZA_DB_SELECT_1();

            /*" -379- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -380- DISPLAY 'PF0720B - FIM ANORMAL' */
                _.Display($"PF0720B - FIM ANORMAL");

                /*" -381- DISPLAY '          ERRO ACESSO TABELA SISTEMAS  ' */
                _.Display($"          ERRO ACESSO TABELA SISTEMAS  ");

                /*" -383- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -385- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -386- DISPLAY ' ' */
            _.Display($" ");

            /*" -388- DISPLAY 'DATA DO PROCESSAMENTO: ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA DO PROCESSAMENTO: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -390- DISPLAY ' ' */
            _.Display($" ");

            /*" -392- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.W_DTMOVABE);

            /*" -394- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_DIA_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -396- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_MES_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -399- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_ANO_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -403- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WORK_AREA.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WORK_AREA.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -411- INITIALIZE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA RT-QTDE-TIPO-2 OF REG-TRAILLER-STA RT-QTDE-TIPO-3 OF REG-TRAILLER-STA RT-QTDE-TIPO-4 OF REG-TRAILLER-STA RT-QTDE-TIPO-5 OF REG-TRAILLER-STA RT-QTDE-TIPO-6 OF REG-TRAILLER-STA RT-QTDE-TIPO-7 OF REG-TRAILLER-STA RT-QTDE-TIPO-8 OF REG-TRAILLER-STA RT-QTDE-TIPO-9 OF REG-TRAILLER-STA. */
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
            );

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-DB-SELECT-1 */
        public void R0100_00_INICIALIZA_DB_SELECT_1()
        {
            /*" -376- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0100_00_INICIALIZA_DB_SELECT_1_Query1 = new R0100_00_INICIALIZA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0100_00_INICIALIZA_DB_SELECT_1_Query1.Execute(r0100_00_INICIALIZA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-ABRIR-ARQUIVOS-SECTION */
        private void R0150_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -423- MOVE 'R0150-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0150-00-ABRIR-ARQUIVOS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -425- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -425- OPEN OUTPUT MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0200-00-OBTER-MAX-NSAS-SECTION */
        private void R0200_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -435- MOVE 'R0200-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0200-00-OBTER-MAX-NSAS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -437- MOVE 'SELECT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -440- MOVE 'STAPF720' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STAPF720", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -443- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -447- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -460- PERFORM R0200_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0200_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -463- IF SQLCODE EQUAL 00 OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -464- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -465- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -466- DISPLAY '*           PF0720B - TERMINO ANORMAL          *' */
                _.Display($"*           PF0720B - TERMINO ANORMAL          *");

                /*" -467- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -468- DISPLAY '*    ---- DATA PROCESSADA ANTERIORMENTE ----   *' */
                _.Display($"*    ---- DATA PROCESSADA ANTERIORMENTE ----   *");

                /*" -469- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -474- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -475- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -476- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -477- ELSE */
            }
            else
            {


                /*" -478- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -479- DISPLAY 'PF0720B - FIM ANORMAL' */
                    _.Display($"PF0720B - FIM ANORMAL");

                    /*" -480- DISPLAY '          ERRO SELECT ARQUIVOS-SIVPF' */
                    _.Display($"          ERRO SELECT ARQUIVOS-SIVPF");

                    /*" -482- DISPLAY '          SQLCODE....................... ' SQLCODE */
                    _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                    /*" -483- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -485- PERFORM R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION();
                }

            }


            /*" -487- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -496- PERFORM R0200_00_OBTER_MAX_NSAS_DB_SELECT_2 */

            R0200_00_OBTER_MAX_NSAS_DB_SELECT_2();

            /*" -499- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -500- DISPLAY 'PF0720B - FIM ANORMAL' */
                _.Display($"PF0720B - FIM ANORMAL");

                /*" -501- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -503- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -504- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -506- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -506- ADD 1 TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.Value = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF + 1;

        }

        [StopWatch]
        /*" R0200-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0200_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -460- EXEC SQL SELECT NSAS_SIVPF INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM AND DATA_PROCESSAMENTO = :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO AND DATA_GERACAO = :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO WITH UR END-EXEC. */

            var r0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 = new R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1()
            {
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
            };

            var executed_1 = R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1.Execute(r0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0200-00-OBTER-MAX-NSAS-DB-SELECT-2 */
        public void R0200_00_OBTER_MAX_NSAS_DB_SELECT_2()
        {
            /*" -496- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

            var r0200_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1 = new R0200_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0200_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1.Execute(r0200_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }

        [StopWatch]
        /*" R0250-00-GERAR-HEADER-SECTION */
        private void R0250_00_GERAR_HEADER_SECTION()
        {
            /*" -516- MOVE 'R0250-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0250-00-GERAR-HEADER", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -518- MOVE 'WRITE REG-HEADER-STA' TO COMANDO. */
            _.Move("WRITE REG-HEADER-STA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -520- MOVE SPACES TO REG-HEADER-STA. */
            _.Move("", LBFCT011.REG_HEADER_STA);

            /*" -523- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -526- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -528- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.W_DTMOVABE);

            /*" -529- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_DIA_MOVABE, WORK_AREA.FILLER_3.W_DIA_TRABALHO);

            /*" -530- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_MES_MOVABE, WORK_AREA.FILLER_3.W_MES_TRABALHO);

            /*" -532- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_ANO_MOVABE, WORK_AREA.FILLER_3.W_ANO_TRABALHO);

            /*" -535- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Move(WORK_AREA.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -538- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -541- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -544- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER-STA */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_HEADER_STA.RH_NSAS);

            /*" -544- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0300-00-PROCESSA-REGISTRO-SECTION */
        private void R0300_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -555- MOVE ZERO TO W-PROPOSTA-CADASTRADA */
            _.Move(0, WORK_AREA.W_PROPOSTA_CADASTRADA);

            /*" -559- INITIALIZE R8-PONTUACAO-SIDEM. */
            _.Initialize(
                LBFPF025.R8_PONTUACAO_SIDEM
            );

            /*" -561- PERFORM R0330-00-LER-PRP-FIDELIZ */

            R0330_00_LER_PRP_FIDELIZ_SECTION();

            /*" -570- IF PROPOSTA-CADASTRADA */

            if (WORK_AREA.W_PROPOSTA_CADASTRADA["PROPOSTA_CADASTRADA"])
            {

                /*" -572- PERFORM R0340-00-OBTER-PARCELA */

                R0340_00_OBTER_PARCELA_SECTION();

                /*" -573- IF PARCELA-ENCONTRADA */

                if (WORK_AREA.W_LER_PARCELA["PARCELA_ENCONTRADA"])
                {

                    /*" -574- PERFORM R0320-00-TRATA-CERTIFICADO */

                    R0320_00_TRATA_CERTIFICADO_SECTION();

                    /*" -574- PERFORM R0350-00-GERAR-REGISTRO-PGTO. */

                    R0350_00_GERAR_REGISTRO_PGTO_SECTION();
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0300_10_LE_OUTRO */

            R0300_10_LE_OUTRO();

        }

        [StopWatch]
        /*" R0300-10-LE-OUTRO */
        private void R0300_10_LE_OUTRO(bool isPerform = false)
        {
            /*" -577- PERFORM R0950-00-FETCH-PROPOSTA. */

            R0950_00_FETCH_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-TRATA-CERTIFICADO-SECTION */
        private void R0320_00_TRATA_CERTIFICADO_SECTION()
        {
            /*" -587- MOVE 'R0320-00-TRATA-CERTIFICADO' TO PARAGRAFO. */
            _.Move("R0320-00-TRATA-CERTIFICADO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -589- MOVE ' ' TO COMANDO. */
            _.Move(" ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -592- IF HISCONPA-NUM-CERTIFICADO NOT LESS 10000000000 AND HISCONPA-NUM-CERTIFICADO NOT GREATER 19999999999 */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO >= 10000000000 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO <= 19999999999)
            {

                /*" -593- PERFORM R0360-00-LER-PROP-VA */

                R0360_00_LER_PROP_VA_SECTION();

                /*" -594- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPRD9310 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
                {

                    /*" -595- MOVE 60 TO WS-NUM-PROPOSTA-2 */
                    _.Move(60, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_2);

                    /*" -596- MOVE HISCONPA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA-11 */
                    _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_11);

                    /*" -597- MOVE ZEROS TO W-DV-PROPOSTA-NOVA */
                    _.Move(0, WORK_AREA.FILLER_0.W_DV_PROPOSTA_NOVA);

                    /*" -598- MOVE WS-NUM-PROPOSTA-1 TO W-NUM-PROPOSTA-NOVA */
                    _.Move(WORK_AREA.WS_NUM_PROPOSTA_1, WORK_AREA.W_NUM_PROPOSTA_NOVA);

                    /*" -599- ELSE */
                }
                else
                {


                    /*" -601- MOVE HISCONPA-NUM-CERTIFICADO TO WCERTIFICADO W-NUM-PROPOSTA-ATUAL */
                    _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, W01DIGCERT.WCERTIFICADO, WORK_AREA.FILLER_0.W_NUM_PROPOSTA_ATUAL);

                    /*" -602- MOVE 'CALL PROM1101' TO COMANDO */
                    _.Move("CALL PROM1101", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -603- CALL 'PROM1101' USING W01DIGCERT */
                    _.Call("PROM1101", W01DIGCERT);

                    /*" -604- MOVE WDIG TO W-DV-PROPOSTA-NOVA */
                    _.Move(W01DIGCERT.WDIG, WORK_AREA.FILLER_0.W_DV_PROPOSTA_NOVA);

                    /*" -606- END-IF */
                }


                /*" -608- ELSE */
            }
            else
            {


                /*" -610- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO W-NUM-PROPOSTA-NOVA */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WORK_AREA.W_NUM_PROPOSTA_NOVA);

                /*" -610- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_SAIDA*/

        [StopWatch]
        /*" R0330-00-LER-PRP-FIDELIZ-SECTION */
        private void R0330_00_LER_PRP_FIDELIZ_SECTION()
        {
            /*" -620- MOVE 'R0330-00-LER-PRP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0330-00-LER-PRP-FIDELIZ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -623- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -625- MOVE HISCONPA-NUM-CERTIFICADO TO PROPOFID-NUM-PROPOSTA-SIVPF. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -641- PERFORM R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1 */

            R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1();

            /*" -644- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -645- MOVE 1 TO W-PROPOSTA-CADASTRADA */
                _.Move(1, WORK_AREA.W_PROPOSTA_CADASTRADA);

                /*" -646- ELSE */
            }
            else
            {


                /*" -647- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -649- MOVE 'SELECT PROPOSTA-FIDELIZ 1' TO COMANDO */
                    _.Move("SELECT PROPOSTA-FIDELIZ 1", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -666- PERFORM R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2 */

                    R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2();

                    /*" -668- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -669- MOVE 1 TO W-PROPOSTA-CADASTRADA */
                        _.Move(1, WORK_AREA.W_PROPOSTA_CADASTRADA);

                        /*" -670- ELSE */
                    }
                    else
                    {


                        /*" -671- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -672- MOVE 0 TO W-PROPOSTA-CADASTRADA */
                            _.Move(0, WORK_AREA.W_PROPOSTA_CADASTRADA);

                            /*" -674- DISPLAY 'PROPOSTA NAO CADASTRADA PROP.FIDELIZ ' PROPOFID-NUM-PROPOSTA-SIVPF */
                            _.Display($"PROPOSTA NAO CADASTRADA PROP.FIDELIZ {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                            /*" -675- ELSE */
                        }
                        else
                        {


                            /*" -676- DISPLAY 'PF0720B - FIM ANORMAL' */
                            _.Display($"PF0720B - FIM ANORMAL");

                            /*" -677- DISPLAY '          ERRO SELECT PROPOSTA FIDELIZ ' */
                            _.Display($"          ERRO SELECT PROPOSTA FIDELIZ ");

                            /*" -679- DISPLAY '          NUM PROPOSTA................ ' PROPOFID-NUM-PROPOSTA-SIVPF */
                            _.Display($"          NUM PROPOSTA................ {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                            /*" -681- DISPLAY '          SQLCODE..................... ' SQLCODE */
                            _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                            /*" -682- PERFORM R1100-00-FECHAR-ARQUIVOS */

                            R1100_00_FECHAR_ARQUIVOS_SECTION();

                            /*" -684- PERFORM R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION();

                            /*" -685- ELSE */
                        }

                    }

                }
                else
                {


                    /*" -686- DISPLAY 'PF0720B - FIM ANORMAL' */
                    _.Display($"PF0720B - FIM ANORMAL");

                    /*" -687- DISPLAY '          ERRO SELECT PROPOSTA FIDELIZ ' */
                    _.Display($"          ERRO SELECT PROPOSTA FIDELIZ ");

                    /*" -689- DISPLAY '          NUM PROPOSTA................ ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUM PROPOSTA................ {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -691- DISPLAY '          SQLCODE..................... ' SQLCODE */
                    _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                    /*" -692- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -692- PERFORM R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0330-00-LER-PRP-FIDELIZ-DB-SELECT-1 */
        public void R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1()
        {
            /*" -641- EXEC SQL SELECT A.NUM_PROPOSTA_SIVPF, A.COD_PRODUTO_SIVPF , A.CANAL_PROPOSTA , A.NUM_IDENTIFICACAO INTO :PROPOFID-NUM-PROPOSTA-SIVPF, :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-CANAL-PROPOSTA , :PROPOFID-NUM-IDENTIFICACAO FROM SEGUROS.PROPOSTA_FIDELIZ A, SEGUROS.IDENTIFICA_RELAC B WHERE A.NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF AND B.NUM_IDENTIFICACAO = A.NUM_IDENTIFICACAO AND A.COD_PRODUTO_SIVPF <> 48 AND B.COD_RELAC IN (1 , 8) WITH UR END-EXEC. */

            var r0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1 = new R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-LER-PRP-FIDELIZ-DB-SELECT-2 */
        public void R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2()
        {
            /*" -666- EXEC SQL SELECT A.NUM_PROPOSTA_SIVPF, A.COD_PRODUTO_SIVPF , A.CANAL_PROPOSTA , A.NUM_IDENTIFICACAO INTO :PROPOFID-NUM-PROPOSTA-SIVPF, :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-CANAL-PROPOSTA , :PROPOFID-NUM-IDENTIFICACAO FROM SEGUROS.PROPOSTA_FIDELIZ A, SEGUROS.IDENTIFICA_RELAC B WHERE A.NUM_SICOB = :PROPOFID-NUM-PROPOSTA-SIVPF AND B.NUM_IDENTIFICACAO = A.NUM_IDENTIFICACAO AND A.COD_PRODUTO_SIVPF <> 48 AND B.COD_RELAC IN (1, 8) WITH UR END-EXEC */

            var r0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1 = new R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1.Execute(r0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
            }


        }

        [StopWatch]
        /*" R0340-00-OBTER-PARCELA-SECTION */
        private void R0340_00_OBTER_PARCELA_SECTION()
        {
            /*" -705- MOVE '0360-00-OBTER-PARCELA ' TO PARAGRAFO. */
            _.Move("0360-00-OBTER-PARCELA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -707- MOVE 'SELECT PARCELAS_VIDAZUL' TO COMANDO. */
            _.Move("SELECT PARCELAS_VIDAZUL", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -710- MOVE HISCONPA-NUM-CERTIFICADO TO PARCEVID-NUM-CERTIFICADO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO);

            /*" -713- MOVE HISCONPA-NUM-PARCELA TO PARCEVID-NUM-PARCELA. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);

            /*" -716- MOVE HISCONPA-OCORR-HISTORICO TO PARCEVID-OCORR-HISTORICO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO);

            /*" -725- PERFORM R0340_00_OBTER_PARCELA_DB_SELECT_1 */

            R0340_00_OBTER_PARCELA_DB_SELECT_1();

            /*" -728- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -729- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -730- MOVE 0 TO W-LER-PARCELA */
                    _.Move(0, WORK_AREA.W_LER_PARCELA);

                    /*" -732- DISPLAY 'PROPOSTA NAO CADASTRADA NA PARCELA  ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"PROPOSTA NAO CADASTRADA NA PARCELA  {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -733- ELSE */
                }
                else
                {


                    /*" -734- DISPLAY 'PF0720B - FIM ANORMAL' */
                    _.Display($"PF0720B - FIM ANORMAL");

                    /*" -735- DISPLAY '          ERRO ACESSO PARCELAS-VIDAZUL' */
                    _.Display($"          ERRO ACESSO PARCELAS-VIDAZUL");

                    /*" -737- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICADO.......... {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -739- DISPLAY '          NUMERO DA PARCELA........... ' HISCONPA-NUM-PARCELA */
                    _.Display($"          NUMERO DA PARCELA........... {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                    /*" -741- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -742- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -743- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -744- ELSE */
                }

            }
            else
            {


                /*" -744- MOVE 1 TO W-LER-PARCELA. */
                _.Move(1, WORK_AREA.W_LER_PARCELA);
            }


        }

        [StopWatch]
        /*" R0340-00-OBTER-PARCELA-DB-SELECT-1 */
        public void R0340_00_OBTER_PARCELA_DB_SELECT_1()
        {
            /*" -725- EXEC SQL SELECT PREMIO_VG, PREMIO_AP INTO :PARCEVID-PREMIO-VG, :PARCEVID-PREMIO-AP FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PARCEVID-NUM-CERTIFICADO AND NUM_PARCELA = :PARCEVID-NUM-PARCELA WITH UR END-EXEC. */

            var r0340_00_OBTER_PARCELA_DB_SELECT_1_Query1 = new R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1()
            {
                PARCEVID_NUM_CERTIFICADO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO.ToString(),
                PARCEVID_NUM_PARCELA = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1.Execute(r0340_00_OBTER_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEVID_PREMIO_VG, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG);
                _.Move(executed_1.PARCEVID_PREMIO_AP, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-GERAR-REGISTRO-PGTO-SECTION */
        private void R0350_00_GERAR_REGISTRO_PGTO_SECTION()
        {
            /*" -757- MOVE 'R0350-00-GERAR-REGISTRO-PGTO' TO PARAGRAFO. */
            _.Move("R0350-00-GERAR-REGISTRO-PGTO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -759- MOVE 'WRITE REGISTRO SIDEM' TO COMANDO. */
            _.Move("WRITE REGISTRO SIDEM", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -761- MOVE SPACES TO REG-STA-SASSE. */
            _.Move("", REG_STA_SASSE);

            /*" -764- MOVE 8 TO R8-IDENTIFICACAO */
            _.Move(8, LBFPF025.R8_PONTUACAO_SIDEM.R8_IDENTIFICACAO);

            /*" -766- MOVE W-NUM-PROPOSTA-NOVA TO R8-NUM-PROPOSTA. */
            _.Move(WORK_AREA.W_NUM_PROPOSTA_NOVA, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PROPOSTA);

            /*" -768- MOVE ZEROS TO R8-VLR-ESTOQUE. */
            _.Move(0, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_ESTOQUE);

            /*" -771- COMPUTE R8-VLR-LANCAMENTO = PARCEVID-PREMIO-VG + PARCEVID-PREMIO-AP */
            LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO.Value = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG + PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP;

            /*" -773- MOVE HISCONPA-NUM-PARCELA TO R8-NUM-PARCELA */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PARCELA);

            /*" -775- MOVE 235 TO R8-TP-LANCAMENTO. */
            _.Move(235, LBFPF025.R8_PONTUACAO_SIDEM.R8_TP_LANCAMENTO);

            /*" -777- WRITE REG-STA-SASSE FROM R8-PONTUACAO-SIDEM. */
            _.Move(LBFPF025.R8_PONTUACAO_SIDEM.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -777- ADD 1 TO W-QTD-LD-TIPO-8. */
            WORK_AREA.W_QTD_LD_TIPO_8.Value = WORK_AREA.W_QTD_LD_TIPO_8 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R0360-00-LER-PROP-VA-SECTION */
        private void R0360_00_LER_PROP_VA_SECTION()
        {
            /*" -786- MOVE 'R0360-00-LER-PROP-VA' TO PARAGRAFO. */
            _.Move("R0360-00-LER-PROP-VA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -788- MOVE 'SELECT PROP-VA' TO COMANDO. */
            _.Move("SELECT PROP-VA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -791- MOVE HISCONPA-NUM-CERTIFICADO TO PROPOVA-NUM-CERTIFICADO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -797- PERFORM R0360_00_LER_PROP_VA_DB_SELECT_1 */

            R0360_00_LER_PROP_VA_DB_SELECT_1();

            /*" -800- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -801- DISPLAY 'PF0720B - FIM ANORMAL' */
                _.Display($"PF0720B - FIM ANORMAL");

                /*" -802- DISPLAY '          ERRO SELECT PROPOSTAS_VA ' */
                _.Display($"          ERRO SELECT PROPOSTAS_VA ");

                /*" -804- DISPLAY '          NUM CERTIFICADO............. ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          NUM CERTIFICADO............. {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -806- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -807- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -808- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -808- END-IF. */
            }


        }

        [StopWatch]
        /*" R0360-00-LER-PROP-VA-DB-SELECT-1 */
        public void R0360_00_LER_PROP_VA_DB_SELECT_1()
        {
            /*" -797- EXEC SQL SELECT P.COD_PRODUTO INTO :PROPOVA-COD-PRODUTO FROM SEGUROS.PROPOSTAS_VA P WHERE P.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0360_00_LER_PROP_VA_DB_SELECT_1_Query1 = new R0360_00_LER_PROP_VA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0360_00_LER_PROP_VA_DB_SELECT_1_Query1.Execute(r0360_00_LER_PROP_VA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-GERAR-TRAILLER-SECTION */
        private void R0800_00_GERAR_TRAILLER_SECTION()
        {
            /*" -821- MOVE 'R0800-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R0800-00-GERAR-TRAILLER", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -823- MOVE 'WRITE REG-TRAILLER-STA' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER-STA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -825- MOVE SPACES TO REG-TRAILLER-STA. */
            _.Move("", LBFCT011.REG_TRAILLER_STA);

            /*" -828- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -831- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -834- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER-STA */
            _.Move(WORK_AREA.W_QTD_LD_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8);

            /*" -845- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -854- MOVE ZEROS TO RT-QTDE-TIPO-1 RT-QTDE-TIPO-2 RT-QTDE-TIPO-3 RT-QTDE-TIPO-5 RT-QTDE-TIPO-6 RT-QTDE-TIPO-7 RT-QTDE-TIPO-8 RT-QTDE-TIPO-9. */
            _.Move(0, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9);

            /*" -854- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -863- MOVE 'R0850-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R0850-00-CONTROLAR-ARQ-ENVIADO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -865- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -868- MOVE 'STAPF720' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STAPF720", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -871- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -875- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -878- MOVE RT-QTDE-TIPO-8 OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -886- PERFORM R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -889- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -890- DISPLAY 'PF0720B - FIM ANORMAL' */
                _.Display($"PF0720B - FIM ANORMAL");

                /*" -891- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -893- DISPLAY '          SIGLA DO ARQUIVO..............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQUIVO..............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -895- DISPLAY '          SISTEMA DE ORIGEM.............  ' ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF */
                _.Display($"          SISTEMA DE ORIGEM.............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM}");

                /*" -897- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -899- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -901- DISPLAY '          QTDE DE REGISTROS.............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE DE REGISTROS.............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -902- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -902- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -886- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
        /*" R0900-00-DECLARE-PAGAMENTOS-SECTION */
        private void R0900_00_DECLARE_PAGAMENTOS_SECTION()
        {
            /*" -912- MOVE 'R0900-00-DECLARE-PAGAMENTOS ' TO PARAGRAFO. */
            _.Move("R0900-00-DECLARE-PAGAMENTOS ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -914- MOVE 'DECLARE CPAGAMENTOS         ' TO COMANDO. */
            _.Move("DECLARE CPAGAMENTOS         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -969- PERFORM R0900_00_DECLARE_PAGAMENTOS_DB_DECLARE_1 */

            R0900_00_DECLARE_PAGAMENTOS_DB_DECLARE_1();

            /*" -973- MOVE 'OPEN CPAGAMENTOS                     ' TO COMANDO. */
            _.Move("OPEN CPAGAMENTOS                     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -973- PERFORM R0900_00_DECLARE_PAGAMENTOS_DB_OPEN_1 */

            R0900_00_DECLARE_PAGAMENTOS_DB_OPEN_1();

            /*" -976- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -977- DISPLAY 'PF0720B - FIM ANORMAL' */
                _.Display($"PF0720B - FIM ANORMAL");

                /*" -978- DISPLAY '          ERRO OPEN CURSOR CPAGAMENTOS   ' */
                _.Display($"          ERRO OPEN CURSOR CPAGAMENTOS   ");

                /*" -980- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -980- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PAGAMENTOS-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PAGAMENTOS_DB_DECLARE_1()
        {
            /*" -969- EXEC SQL DECLARE CPAGAMENTOS CURSOR FOR SELECT A.NUM_APOLICE , A.COD_SUBGRUPO , A.NUM_CERTIFICADO, A.NUM_PARCELA , A.OCORR_HISTORICO, A.COD_OPERACAO FROM SEGUROS.HIST_CONT_PARCELVA A, SEGUROS.PROPOSTA_FIDELIZ B WHERE A.NUM_CERTIFICADO = B.NUM_PROPOSTA_SIVPF AND B.COD_EMPRESA_SIVPF = 1 AND B.COD_PRODUTO_SIVPF NOT IN (7708, 9341, 9350, 9348, 48, 9, 10) AND B.CANAL_PROPOSTA <> 5 AND A.NUM_PARCELA > 1 AND A.COD_OPERACAO >= 200 AND A.COD_OPERACAO <= 299 AND A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.SIT_REGISTRO IN ( '1' , '0' ) UNION SELECT A.NUM_APOLICE , A.COD_SUBGRUPO , A.NUM_CERTIFICADO, A.NUM_PARCELA , A.OCORR_HISTORICO, A.COD_OPERACAO FROM SEGUROS.HIST_CONT_PARCELVA A, SEGUROS.PROPOSTA_FIDELIZ B WHERE A.NUM_CERTIFICADO = B.NUM_SICOB AND B.COD_EMPRESA_SIVPF = 1 AND B.COD_PRODUTO_SIVPF NOT IN (7708, 9341, 9350, 9348, 48, 9, 10) AND B.CANAL_PROPOSTA <> 5 AND A.NUM_PARCELA > 1 AND A.COD_OPERACAO >= 200 AND A.COD_OPERACAO <= 299 AND A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.SIT_REGISTRO IN ( '1' , '0' ) GROUP BY A.NUM_APOLICE , A.COD_SUBGRUPO , A.NUM_CERTIFICADO, A.NUM_PARCELA , A.OCORR_HISTORICO, A.COD_OPERACAO ORDER BY 1, 2, 3, 4, 5 WITH UR END-EXEC. */
            CPAGAMENTOS = new PF0720B_CPAGAMENTOS(true);
            string GetQuery_CPAGAMENTOS()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.NUM_CERTIFICADO
							, 
							A.NUM_PARCELA
							, 
							A.OCORR_HISTORICO
							, 
							A.COD_OPERACAO 
							FROM SEGUROS.HIST_CONT_PARCELVA A
							, 
							SEGUROS.PROPOSTA_FIDELIZ B 
							WHERE A.NUM_CERTIFICADO = B.NUM_PROPOSTA_SIVPF 
							AND B.COD_EMPRESA_SIVPF = 1 
							AND B.COD_PRODUTO_SIVPF NOT IN 
							(7708
							, 9341
							, 9350
							, 9348
							, 48
							, 9
							, 10) 
							AND B.CANAL_PROPOSTA <> 5 
							AND A.NUM_PARCELA > 1 
							AND A.COD_OPERACAO >= 200 
							AND A.COD_OPERACAO <= 299 
							AND A.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.SIT_REGISTRO IN ( '1'
							, '0' ) 
							UNION 
							SELECT A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.NUM_CERTIFICADO
							, 
							A.NUM_PARCELA
							, 
							A.OCORR_HISTORICO
							, 
							A.COD_OPERACAO 
							FROM SEGUROS.HIST_CONT_PARCELVA A
							, 
							SEGUROS.PROPOSTA_FIDELIZ B 
							WHERE A.NUM_CERTIFICADO = B.NUM_SICOB 
							AND B.COD_EMPRESA_SIVPF = 1 
							AND B.COD_PRODUTO_SIVPF NOT IN 
							(7708
							, 9341
							, 9350
							, 9348
							, 48
							, 9
							, 10) 
							AND B.CANAL_PROPOSTA <> 5 
							AND A.NUM_PARCELA > 1 
							AND A.COD_OPERACAO >= 200 
							AND A.COD_OPERACAO <= 299 
							AND A.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.SIT_REGISTRO IN ( '1'
							, '0' ) 
							GROUP BY A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.NUM_CERTIFICADO
							, 
							A.NUM_PARCELA
							, 
							A.OCORR_HISTORICO
							, 
							A.COD_OPERACAO 
							ORDER BY 1
							, 2
							, 3
							, 4
							, 5";

                return query;
            }
            CPAGAMENTOS.GetQueryEvent += GetQuery_CPAGAMENTOS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PAGAMENTOS-DB-OPEN-1 */
        public void R0900_00_DECLARE_PAGAMENTOS_DB_OPEN_1()
        {
            /*" -973- EXEC SQL OPEN CPAGAMENTOS END-EXEC. */

            CPAGAMENTOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-SECTION */
        private void R0950_00_FETCH_PROPOSTA_SECTION()
        {
            /*" -991- MOVE 'R0950-00-FETCH-PROPOSTA     ' TO PARAGRAFO. */
            _.Move("R0950-00-FETCH-PROPOSTA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -993- MOVE 'FETCH CPAGAMENTOS           ' TO COMANDO. */
            _.Move("FETCH CPAGAMENTOS           ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1001- PERFORM R0950_00_FETCH_PROPOSTA_DB_FETCH_1 */

            R0950_00_FETCH_PROPOSTA_DB_FETCH_1();

            /*" -1004- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1004- PERFORM R0950_00_FETCH_PROPOSTA_DB_CLOSE_1 */

                R0950_00_FETCH_PROPOSTA_DB_CLOSE_1();

                /*" -1006- MOVE 1 TO WS-EOR */
                _.Move(1, WORK_AREA.WS_EOR);

                /*" -1007- GO TO R0950-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/ //GOTO
                return;

                /*" -1008- ELSE */
            }
            else
            {


                /*" -1010- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

                if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
                {

                    /*" -1011- DISPLAY 'PF0720B - FIM ANORMAL' */
                    _.Display($"PF0720B - FIM ANORMAL");

                    /*" -1012- DISPLAY '          ERRO FETCH CURSOR CPAGAMENTOS   ' */
                    _.Display($"          ERRO FETCH CURSOR CPAGAMENTOS   ");

                    /*" -1014- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -1015- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1016- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -1017- ELSE */
                }
                else
                {


                    /*" -1020- ADD 1 TO AC-L-MOVIMENTO, AC-CONTROLE */
                    WORK_AREA.AC_L_MOVIMENTO.Value = WORK_AREA.AC_L_MOVIMENTO + 1;
                    WORK_AREA.AC_CONTROLE.Value = WORK_AREA.AC_CONTROLE + 1;

                    /*" -1021- IF AC-CONTROLE GREATER 999 */

                    if (WORK_AREA.AC_CONTROLE > 999)
                    {

                        /*" -1022- ACCEPT WS-TIME FROM TIME */
                        _.Move(_.AcceptDate("TIME"), WS_TIME);

                        /*" -1023- MOVE WS-TIME-N TO WS-TIME-EDIT */
                        _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

                        /*" -1025- DISPLAY 'PF0720B - TOTAL LIDO ' AC-L-MOVIMENTO '  HORAS  ' WS-TIME-EDIT */

                        $"PF0720B - TOTAL LIDO {WORK_AREA.AC_L_MOVIMENTO}  HORAS  {WS_TIME_EDIT}"
                        .Display();

                        /*" -1025- MOVE ZEROS TO AC-CONTROLE. */
                        _.Move(0, WORK_AREA.AC_CONTROLE);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-DB-FETCH-1 */
        public void R0950_00_FETCH_PROPOSTA_DB_FETCH_1()
        {
            /*" -1001- EXEC SQL FETCH CPAGAMENTOS INTO :HISCONPA-NUM-APOLICE , :HISCONPA-COD-SUBGRUPO , :HISCONPA-NUM-CERTIFICADO, :HISCONPA-NUM-PARCELA , :HISCONPA-OCORR-HISTORICO, :HISCONPA-COD-OPERACAO END-EXEC. */

            if (CPAGAMENTOS.Fetch())
            {
                _.Move(CPAGAMENTOS.HISCONPA_NUM_APOLICE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE);
                _.Move(CPAGAMENTOS.HISCONPA_COD_SUBGRUPO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO);
                _.Move(CPAGAMENTOS.HISCONPA_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);
                _.Move(CPAGAMENTOS.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(CPAGAMENTOS.HISCONPA_OCORR_HISTORICO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);
                _.Move(CPAGAMENTOS.HISCONPA_COD_OPERACAO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);
            }

        }

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-DB-CLOSE-1 */
        public void R0950_00_FETCH_PROPOSTA_DB_CLOSE_1()
        {
            /*" -1004- EXEC SQL CLOSE CPAGAMENTOS END-EXEC */

            CPAGAMENTOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-IMPRIMIR-TOTAIS-SECTION */
        private void R1000_00_IMPRIMIR_TOTAIS_SECTION()
        {
            /*" -1035- MOVE 'R0870-00-GERAR-TOTAIS' TO PARAGRAFO. */
            _.Move("R0870-00-GERAR-TOTAIS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1037- MOVE ' ' TO COMANDO. */
            _.Move(" ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1038- DISPLAY ' ' */
            _.Display($" ");

            /*" -1039- DISPLAY '************************************************' */
            _.Display($"************************************************");

            /*" -1040- DISPLAY '*                                              *' */
            _.Display($"*                                              *");

            /*" -1041- DISPLAY '*           PF0720B - TERMINO NORMAL           *' */
            _.Display($"*           PF0720B - TERMINO NORMAL           *");

            /*" -1042- DISPLAY '*                                              *' */
            _.Display($"*                                              *");

            /*" -1044- DISPLAY '*    TOTAL REG LIDOS.............. ' AC-L-MOVIMENTO '      *' */

            $"*    TOTAL REG LIDOS.............. {WORK_AREA.AC_L_MOVIMENTO}      *"
            .Display();

            /*" -1046- DISPLAY '*    TOTAL REG GERADOS STATUS..... ' W-QTD-LD-TIPO-8 '      *' */

            $"*    TOTAL REG GERADOS STATUS..... {WORK_AREA.W_QTD_LD_TIPO_8}      *"
            .Display();

            /*" -1047- DISPLAY '*                                              *' */
            _.Display($"*                                              *");

            /*" -1047- DISPLAY '************************************************' . */
            _.Display($"************************************************");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1100-00-FECHAR-ARQUIVOS-SECTION */
        private void R1100_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -1056- CLOSE MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1066- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

            /*" -1067- MOVE SQLCODE TO RETURN-CODE. */
            _.Move(DB.SQLCODE, RETURN_CODE);

            /*" -1068- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], AREA_ABEND.WABEND.WSQLERRD1);

            /*" -1069- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], AREA_ABEND.WABEND.WSQLERRD2);

            /*" -1070- DISPLAY WABEND. */
            _.Display(AREA_ABEND.WABEND);

            /*" -1071- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1);

            /*" -1073- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_2);

            /*" -1073- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1074- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1076- DISPLAY ' ' */
            _.Display($" ");

            /*" -1077- DISPLAY '************************************************' */
            _.Display($"************************************************");

            /*" -1078- DISPLAY '*                                              *' */
            _.Display($"*                                              *");

            /*" -1079- DISPLAY '*     PF0720B - TERMINO NORMAL - VERIFIQUE     *' */
            _.Display($"*     PF0720B - TERMINO NORMAL - VERIFIQUE     *");

            /*" -1080- DISPLAY '*                                              *' */
            _.Display($"*                                              *");

            /*" -1081- DISPLAY '*              ROLLBACK EXECUTADO              *' */
            _.Display($"*              ROLLBACK EXECUTADO              *");

            /*" -1082- DISPLAY '*                                              *' */
            _.Display($"*                                              *");

            /*" -1084- DISPLAY '************************************************' */
            _.Display($"************************************************");

            /*" -1085- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1085- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}