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
using Sias.PessoaFisica.DB2.PF0725B;

namespace Code
{
    public class PF0725B
    {
        public bool IsCall { get; set; }

        public PF0725B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------*                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA A CEF STATUS DE PAGAMENTO  /  *      */
        /*"      *                             DEVOLUCOES DO BILHETE FACIL VIDA   *      */
        /*"      *                             TRANQUILA - VENDIDOS PELA MARSH    *      */
        /*"V.02  *                             E CAIXA FACIL ATM.                 *      */
        /*"      *   ANALISE/PROGRAMACAO.....  LUIZ CARLOS / LUCIA VIEIRA         *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PF0725B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  01/04/2008.                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * MOTIVO  : RETIRAR DO ARQUIVO A PARCELA DE ADESAO               *      */
        /*"      * CADMUS  : 155.675                                              *      */
        /*"      * NOME    : THIAGO BLAIER                                        *      */
        /*"      * MARCADOR: V.02                                                 *      */
        /*"      * DATA    : 04-12-2017                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * MOTIVO  : INCLUIR NA GERAçãO DO ARQUIVO BILHETES DOS PRODUTOS  *      */
        /*"      *           8144, 8145, 8146, 8147, 8148, 8149, 8150             *      */
        /*"      * CADMUS  : 155.675                                              *      */
        /*"      * NOME    : THIAGO BLAIER                                        *      */
        /*"      * MARCADOR: V.03                                                 *      */
        /*"      * DATA    : 07-12-2017                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.01 *   VERSAO 04 - PROJETO JOINT VENTURE (JV)                       *      */
        /*"=     *             - AVALIAR IMPACTO PRODUTO, APOLICE, ORGAO, ETC.    *      */
        /*"=     *             - Historia: 188284.                                *      */
        /*"=     *    EM 14/02/2019 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR JV.01       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  *   VERSAO 05 - INCIDENTE 508008                                 *      */
        /*"      *             - DISPLAY PARA IDENTIFICACAO DA ULT APOLICE LIDA   *      */
        /*"      *                                                                *      */
        /*"      *    EM 22/06/2023 - CANETTA             PROCURE POR V.05        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  *   VERSAO 06 - DEMANDA                                          *      */
        /*"      *             - ENVIO DE PARCELAS DE BILHETE PARA RAMO 81 E 37   *      */
        /*"      *                                                                *      */
        /*"      *    EM 09/11/2023 - THIAGO BLAIER       PROCURE POR V.06        *      */
        /*"|V.01 *----------------------------------------------------------------*      */
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
        /*"01  WORK-JV1.*/
        public PF0725B_WORK_JV1 WORK_JV1 { get; set; } = new PF0725B_WORK_JV1();
        public class PF0725B_WORK_JV1 : VarBasis
        {
            /*" 05 WS-JV1-PROGRAMA                  PIC  X(008)    VALUE SPACES*/
            public StringBasis WS_JV1_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*" 05 WH-JV1-COD-ORGAO                 PIC S9(004) COMP-5 VALUE +0*/
            public IntBasis WH_JV1_COD_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*" 05 WH-JV1-FONTE                     PIC S9(004) COMP-5 VALUE +0*/
            public IntBasis WH_JV1_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  WORK-AREA.*/
        }
        public PF0725B_WORK_AREA WORK_AREA { get; set; } = new PF0725B_WORK_AREA();
        public class PF0725B_WORK_AREA : VarBasis
        {
            /*"    05  W-NUM-PROPOSTA-NOVA           PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FILLER REDEFINES W-NUM-PROPOSTA-NOVA.*/
            private _REDEF_PF0725B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0725B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0725B_FILLER_0(); _.Move(W_NUM_PROPOSTA_NOVA, _filler_0); VarBasis.RedefinePassValue(W_NUM_PROPOSTA_NOVA, _filler_0, W_NUM_PROPOSTA_NOVA); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_NUM_PROPOSTA_NOVA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_NUM_PROPOSTA_NOVA); }
            }  //Redefines
            public class _REDEF_PF0725B_FILLER_0 : VarBasis
            {
                /*"        07  W-NUM-PROPOSTA-ATUAL      PIC 9(013).*/
                public IntBasis W_NUM_PROPOSTA_ATUAL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        07  W-DV-PROPOSTA-NOVA        PIC 9(001).*/
                public IntBasis W_DV_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05 W-ULT-APO-LID                 PIC  9(015)  VALUE ZEROS.*/

                public _REDEF_PF0725B_FILLER_0()
                {
                    W_NUM_PROPOSTA_ATUAL.ValueChanged += OnValueChanged;
                    W_DV_PROPOSTA_NOVA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_ULT_APO_LID { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05 W-PARC-ENDO                   PIC S9(009)  USAGE COMP.*/
            public IntBasis W_PARC_ENDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
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
            private _REDEF_PF0725B_DATA_SQL _data_sql { get; set; }
            public _REDEF_PF0725B_DATA_SQL DATA_SQL
            {
                get { _data_sql = new _REDEF_PF0725B_DATA_SQL(); _.Move(DATA_SQL1, _data_sql); VarBasis.RedefinePassValue(DATA_SQL1, _data_sql, DATA_SQL1); _data_sql.ValueChanged += () => { _.Move(_data_sql, DATA_SQL1); }; return _data_sql; }
                set { VarBasis.RedefinePassValue(value, _data_sql, DATA_SQL1); }
            }  //Redefines
            public class _REDEF_PF0725B_DATA_SQL : VarBasis
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

                public _REDEF_PF0725B_DATA_SQL()
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
            private _REDEF_PF0725B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0725B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0725B_FILLER_3(); _.Move(W_DATA_TRABALHO, _filler_3); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_3, W_DATA_TRABALHO); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_DATA_TRABALHO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0725B_FILLER_3 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0725B_FILLER_3()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0725B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0725B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0725B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0725B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0725B_W_DTMOVABE1()
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
            private _REDEF_PF0725B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0725B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0725B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0725B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0725B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0725B_WS_TIME WS_TIME { get; set; } = new PF0725B_WS_TIME();
        public class PF0725B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01             W01DIGCERT.*/
        public PF0725B_W01DIGCERT W01DIGCERT { get; set; } = new PF0725B_W01DIGCERT();
        public class PF0725B_W01DIGCERT : VarBasis
        {
            /*"    05         WCERTIFICADO    PIC  9(015)        VALUE  0.*/
            public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05         WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
            public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
            /*"    05         WDIG            PIC  X(001)  VALUE SPACES.*/
            public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  AREA-ABEND.*/
        }
        public PF0725B_AREA_ABEND AREA_ABEND { get; set; } = new PF0725B_AREA_ABEND();
        public class PF0725B_AREA_ABEND : VarBasis
        {
            /*"    05   WABEND.*/
            public PF0725B_WABEND WABEND { get; set; } = new PF0725B_WABEND();
            public class PF0725B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0725B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0725B  ");
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
            public PF0725B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0725B_LOCALIZA_ABEND_1();
            public class PF0725B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0725B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0725B_LOCALIZA_ABEND_2();
            public class PF0725B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01           WS-PARAMETRO.*/
            }
        }
        public PF0725B_WS_PARAMETRO WS_PARAMETRO { get; set; } = new PF0725B_WS_PARAMETRO();
        public class PF0725B_WS_PARAMETRO : VarBasis
        {
            /*"  03         FILLER             PIC  X(002).*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  03         WS-PARAM-DAT       PIC  X(010)    VALUE ZEROS.*/
            public StringBasis WS_PARAM_DAT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             PIC  X(068)    VALUE SPACES.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "68", "X(068)"), @"");
        }


        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Copies.LBFPF025 LBFPF025 { get; set; } = new Copies.LBFPF025();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.IDERELAC IDERELAC { get; set; } = new Dclgens.IDERELAC();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public PF0725B_CPAGAMENTOS CPAGAMENTOS { get; set; } = new PF0725B_CPAGAMENTOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PF0725B_WS_PARAMETRO PF0725B_WS_PARAMETRO_P, string MOVTO_STA_SASSE_FILE_NAME_P) //PROCEDURE DIVISION USING 
        /*WS_PARAMETRO*/
        {
            try
            {
                this.WS_PARAMETRO = PF0725B_WS_PARAMETRO_P;
                MOVTO_STA_SASSE.SetFile(MOVTO_STA_SASSE_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { WS_PARAMETRO, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -242- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -245- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -248- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -252- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -253- DISPLAY '*  GERA P/ CEF STATUS PGTO DEVOLUCOES BILHETE  *' . */
            _.Display($"*  GERA P/ CEF STATUS PGTO DEVOLUCOES BILHETE  *");

            /*" -254- DISPLAY '*  FACIL VIDA TRANQUILA - VENDIDOS PELA MARSH  *' */
            _.Display($"*  FACIL VIDA TRANQUILA - VENDIDOS PELA MARSH  *");

            /*" -257- DISPLAY '*           VERSAO:  05 - 22/06/2023           *' . */
            _.Display($"*           VERSAO:  05 - 22/06/2023           *");

            /*" -258- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -268- DISPLAY '*  PF0725B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0725B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -270- PERFORM R0100-00-INICIALIZA. */

            R0100_00_INICIALIZA_SECTION();

            /*" -271- PERFORM R0900-00-DECLARE-PAGAMENTOS. */

            R0900_00_DECLARE_PAGAMENTOS_SECTION();

            /*" -273- PERFORM R0950-00-FETCH-PROPOSTA. */

            R0950_00_FETCH_PROPOSTA_SECTION();

            /*" -274- IF WS-EOR = 1 */

            if (WORK_AREA.WS_EOR == 1)
            {

                /*" -275- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -276- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -277- DISPLAY '//           PROGRAMA  =>  PF0725B            //' */
                _.Display($"//           PROGRAMA  =>  PF0725B            //");

                /*" -278- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -279- DISPLAY '//             TERMINO - NORMAL               //' */
                _.Display($"//             TERMINO - NORMAL               //");

                /*" -280- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -281- DISPLAY '//   ==>  NAO HOUVE PAGAMENTO NO DIA  <==     //' */
                _.Display($"//   ==>  NAO HOUVE PAGAMENTO NO DIA  <==     //");

                /*" -282- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -283- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -285- GO TO R0000-00-FINALIZA. */

                R0000_00_FINALIZA(); //GOTO
                return;
            }


            /*" -287- PERFORM R0150-00-ABRIR-ARQUIVOS. */

            R0150_00_ABRIR_ARQUIVOS_SECTION();

            /*" -289- PERFORM R0200-00-OBTER-MAX-NSAS. */

            R0200_00_OBTER_MAX_NSAS_SECTION();

            /*" -291- PERFORM R0250-00-GERAR-HEADER */

            R0250_00_GERAR_HEADER_SECTION();

            /*" -294- PERFORM R0300-00-PROCESSA-REGISTRO UNTIL WS-EOR = 1. */

            while (!(WORK_AREA.WS_EOR == 1))
            {

                R0300_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -296- PERFORM R0800-00-GERAR-TRAILLER. */

            R0800_00_GERAR_TRAILLER_SECTION();

            /*" -298- PERFORM R0850-00-CONTROLAR-ARQ-ENVIADO */

            R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -300- PERFORM R1000-00-IMPRIMIR-TOTAIS. */

            R1000_00_IMPRIMIR_TOTAIS_SECTION();

            /*" -300- PERFORM R1100-00-FECHAR-ARQUIVOS. */

            R1100_00_FECHAR_ARQUIVOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_00_FINALIZA */

            R0000_00_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-FINALIZA */
        private void R0000_00_FINALIZA(bool isPerform = false)
        {
            /*" -307- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -311- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -311- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-SECTION */
        private void R0100_00_INICIALIZA_SECTION()
        {
            /*" -319- MOVE '0000-PRINCIPAL               ' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL               ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -321- MOVE 'R0100-00-SELECT-SISTEMAS     ' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-SISTEMAS     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -323- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -329- PERFORM R0100_00_INICIALIZA_DB_SELECT_1 */

            R0100_00_INICIALIZA_DB_SELECT_1();

            /*" -332- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -333- DISPLAY 'PF0725B - FIM ANORMAL' */
                _.Display($"PF0725B - FIM ANORMAL");

                /*" -334- DISPLAY '          ERRO ACESSO TABELA SISTEMAS  ' */
                _.Display($"          ERRO ACESSO TABELA SISTEMAS  ");

                /*" -336- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -338- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -339- IF WS-PARAM-DAT NOT EQUAL '0000-00-00' */

            if (WS_PARAMETRO.WS_PARAM_DAT != "0000-00-00")
            {

                /*" -340- MOVE WS-PARAM-DAT TO SISTEMAS-DATA-MOV-ABERTO */
                _.Move(WS_PARAMETRO.WS_PARAM_DAT, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

                /*" -342- END-IF */
            }


            /*" -343- DISPLAY ' ' */
            _.Display($" ");

            /*" -345- DISPLAY 'DATA DO PARAMETRO .. : ' WS-PARAM-DAT */
            _.Display($"DATA DO PARAMETRO .. : {WS_PARAMETRO.WS_PARAM_DAT}");

            /*" -347- DISPLAY 'DATA DO PROCESSAMENTO: ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA DO PROCESSAMENTO: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -349- DISPLAY ' ' . */
            _.Display($" ");

            /*" -351- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.W_DTMOVABE);

            /*" -353- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_DIA_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -355- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_MES_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -358- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_ANO_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -362- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WORK_AREA.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WORK_AREA.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -370- INITIALIZE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA RT-QTDE-TIPO-2 OF REG-TRAILLER-STA RT-QTDE-TIPO-3 OF REG-TRAILLER-STA RT-QTDE-TIPO-4 OF REG-TRAILLER-STA RT-QTDE-TIPO-5 OF REG-TRAILLER-STA RT-QTDE-TIPO-6 OF REG-TRAILLER-STA RT-QTDE-TIPO-7 OF REG-TRAILLER-STA RT-QTDE-TIPO-8 OF REG-TRAILLER-STA RT-QTDE-TIPO-9 OF REG-TRAILLER-STA. */
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
            /*" -329- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
            /*" -382- MOVE 'R0150-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0150-00-ABRIR-ARQUIVOS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -384- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -384- OPEN OUTPUT MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0200-00-OBTER-MAX-NSAS-SECTION */
        private void R0200_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -394- MOVE 'R0200-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0200-00-OBTER-MAX-NSAS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -396- MOVE 'SELECT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -399- MOVE 'STAPF725' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STAPF725", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -402- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -406- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -419- PERFORM R0200_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0200_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -422- IF SQLCODE EQUAL 00 OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -423- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -424- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -425- DISPLAY '//           PROGRAMA  =>  PF0725B            //' */
                _.Display($"//           PROGRAMA  =>  PF0725B            //");

                /*" -426- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -427- DISPLAY '//             TERMINO - ANORMAL              //' */
                _.Display($"//             TERMINO - ANORMAL              //");

                /*" -428- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -429- DISPLAY '//   ==>  DATA PROCESSADA ANTERIORMENTE <==   //' */
                _.Display($"//   ==>  DATA PROCESSADA ANTERIORMENTE <==   //");

                /*" -430- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -435- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -436- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -437- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -438- ELSE */
            }
            else
            {


                /*" -439- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -440- DISPLAY 'PF0725B - FIM ANORMAL' */
                    _.Display($"PF0725B - FIM ANORMAL");

                    /*" -441- DISPLAY '          ERRO SELECT ARQUIVOS-SIVPF' */
                    _.Display($"          ERRO SELECT ARQUIVOS-SIVPF");

                    /*" -443- DISPLAY '          SQLCODE....................... ' SQLCODE */
                    _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                    /*" -444- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -446- PERFORM R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION();
                }

            }


            /*" -448- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -457- PERFORM R0200_00_OBTER_MAX_NSAS_DB_SELECT_2 */

            R0200_00_OBTER_MAX_NSAS_DB_SELECT_2();

            /*" -460- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -461- DISPLAY 'PF0725B - FIM ANORMAL' */
                _.Display($"PF0725B - FIM ANORMAL");

                /*" -462- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -464- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -465- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -467- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -467- ADD 1 TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.Value = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF + 1;

        }

        [StopWatch]
        /*" R0200-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0200_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -419- EXEC SQL SELECT NSAS_SIVPF INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM AND DATA_PROCESSAMENTO = :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO AND DATA_GERACAO = :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO WITH UR END-EXEC. */

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
            /*" -457- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

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
            /*" -477- MOVE 'R0250-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0250-00-GERAR-HEADER", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -479- MOVE 'WRITE REG-HEADER-STA' TO COMANDO. */
            _.Move("WRITE REG-HEADER-STA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -481- MOVE SPACES TO REG-HEADER-STA. */
            _.Move("", LBFCT011.REG_HEADER_STA);

            /*" -484- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -487- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -489- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.W_DTMOVABE);

            /*" -490- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_DIA_MOVABE, WORK_AREA.FILLER_3.W_DIA_TRABALHO);

            /*" -491- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_MES_MOVABE, WORK_AREA.FILLER_3.W_MES_TRABALHO);

            /*" -493- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_ANO_MOVABE, WORK_AREA.FILLER_3.W_ANO_TRABALHO);

            /*" -496- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Move(WORK_AREA.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -499- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -502- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -505- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER-STA */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_HEADER_STA.RH_NSAS);

            /*" -505- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0300-00-PROCESSA-REGISTRO-SECTION */
        private void R0300_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -516- MOVE ZERO TO W-PROPOSTA-CADASTRADA */
            _.Move(0, WORK_AREA.W_PROPOSTA_CADASTRADA);

            /*" -519- INITIALIZE R8-PONTUACAO-SIDEM. */
            _.Initialize(
                LBFPF025.R8_PONTUACAO_SIDEM
            );

            /*" -520- IF BILHETE-RAMO EQUAL 81 OR 37 */

            if (BILHETE.DCLBILHETE.BILHETE_RAMO.In("81", "37"))
            {

                /*" -521- PERFORM R0340-00-LER-PRP-FIDELIZ */

                R0340_00_LER_PRP_FIDELIZ_SECTION();

                /*" -522- ELSE */
            }
            else
            {


                /*" -523- PERFORM R0330-00-LER-PRP-FIDELIZ */

                R0330_00_LER_PRP_FIDELIZ_SECTION();

                /*" -525- END-IF */
            }


            /*" -526- IF PROPOSTA-CADASTRADA */

            if (WORK_AREA.W_PROPOSTA_CADASTRADA["PROPOSTA_CADASTRADA"])
            {

                /*" -527- PERFORM R0350-00-GERAR-REGISTRO-PGTO */

                R0350_00_GERAR_REGISTRO_PGTO_SECTION();

                /*" -529- END-IF */
            }


            /*" -529- PERFORM R0950-00-FETCH-PROPOSTA. */

            R0950_00_FETCH_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-LER-PRP-FIDELIZ-SECTION */
        private void R0330_00_LER_PRP_FIDELIZ_SECTION()
        {
            /*" -541- MOVE 'R0330-00-LER-PRP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0330-00-LER-PRP-FIDELIZ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -543- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -545- MOVE BILHETE-NUM-BILHETE TO PROPOFID-NUM-SICOB. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

            /*" -556- PERFORM R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1 */

            R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1();

            /*" -558- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -559- MOVE 1 TO W-PROPOSTA-CADASTRADA */
                _.Move(1, WORK_AREA.W_PROPOSTA_CADASTRADA);

                /*" -560- ELSE */
            }
            else
            {


                /*" -561- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -570- PERFORM R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2 */

                    R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2();

                    /*" -573- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -574- MOVE 1 TO W-PROPOSTA-CADASTRADA */
                        _.Move(1, WORK_AREA.W_PROPOSTA_CADASTRADA);

                        /*" -576- DISPLAY 'SEGUNDO SELECT          ' W-PROPOSTA-CADASTRADA */
                        _.Display($"SEGUNDO SELECT          {WORK_AREA.W_PROPOSTA_CADASTRADA}");

                        /*" -577- ELSE */
                    }
                    else
                    {


                        /*" -578- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -579- MOVE 0 TO W-PROPOSTA-CADASTRADA */
                            _.Move(0, WORK_AREA.W_PROPOSTA_CADASTRADA);

                            /*" -581- DISPLAY 'PROPOSTA NAO CADASTRADA PROP.FIDELIZ ' PROPOFID-NUM-PROPOSTA-SIVPF */
                            _.Display($"PROPOSTA NAO CADASTRADA PROP.FIDELIZ {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                            /*" -582- ELSE */
                        }
                        else
                        {


                            /*" -583- DISPLAY 'PF0725B - FIM ANORMAL' */
                            _.Display($"PF0725B - FIM ANORMAL");

                            /*" -584- DISPLAY '          ERRO SELECT PROPOSTA FIDELIZ ' */
                            _.Display($"          ERRO SELECT PROPOSTA FIDELIZ ");

                            /*" -586- DISPLAY '          NUM BILHETE................. ' PROPOFID-NUM-SICOB */
                            _.Display($"          NUM BILHETE................. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB}");

                            /*" -588- DISPLAY '          SQLCODE..................... ' SQLCODE */
                            _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                            /*" -589- PERFORM R1100-00-FECHAR-ARQUIVOS */

                            R1100_00_FECHAR_ARQUIVOS_SECTION();

                            /*" -590- PERFORM R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION();

                            /*" -591- ELSE */
                        }

                    }

                }
                else
                {


                    /*" -592- DISPLAY 'PF0725B - FIM ANORMAL' */
                    _.Display($"PF0725B - FIM ANORMAL");

                    /*" -593- DISPLAY '          ERRO SELECT PROPOSTA FIDELIZ ' */
                    _.Display($"          ERRO SELECT PROPOSTA FIDELIZ ");

                    /*" -595- DISPLAY '          NUM BILHETE................. ' PROPOFID-NUM-SICOB */
                    _.Display($"          NUM BILHETE................. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB}");

                    /*" -597- DISPLAY '          SQLCODE..................... ' SQLCODE */
                    _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                    /*" -598- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -598- PERFORM R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0330-00-LER-PRP-FIDELIZ-DB-SELECT-1 */
        public void R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1()
        {
            /*" -556- EXEC SQL SELECT NUM_PROPOSTA_SIVPF , NUM_IDENTIFICACAO INTO :PROPOFID-NUM-PROPOSTA-SIVPF , :PROPOFID-NUM-IDENTIFICACAO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :PROPOFID-NUM-SICOB AND COD_PRODUTO_SIVPF = 9 AND CANAL_PROPOSTA = 1 AND ORIGEM_PROPOSTA = 12 WITH UR END-EXEC. */

            var r0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1 = new R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
            };

            var executed_1 = R0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0330_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-LER-PRP-FIDELIZ-DB-SELECT-2 */
        public void R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2()
        {
            /*" -570- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :PROPOFID-NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-SICOB AND COD_PRODUTO_SIVPF = 9 AND CANAL_PROPOSTA = 4 AND ORIGEM_PROPOSTA IN (19,18) WITH UR END-EXEC */

            var r0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1 = new R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1()
            {
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
            };

            var executed_1 = R0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1.Execute(r0330_00_LER_PRP_FIDELIZ_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }


        }

        [StopWatch]
        /*" R0340-00-LER-PRP-FIDELIZ-SECTION */
        private void R0340_00_LER_PRP_FIDELIZ_SECTION()
        {
            /*" -612- MOVE 'R0340-00-LER-PRP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0340-00-LER-PRP-FIDELIZ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -614- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -615- DISPLAY 'BILHETE-NUM-BILHETE = ' BILHETE-NUM-BILHETE */
            _.Display($"BILHETE-NUM-BILHETE = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

            /*" -618- MOVE BILHETE-NUM-BILHETE TO PROPOFID-NUM-SICOB. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

            /*" -626- PERFORM R0340_00_LER_PRP_FIDELIZ_DB_SELECT_1 */

            R0340_00_LER_PRP_FIDELIZ_DB_SELECT_1();

            /*" -629- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -630- MOVE 1 TO W-PROPOSTA-CADASTRADA */
                _.Move(1, WORK_AREA.W_PROPOSTA_CADASTRADA);

                /*" -632- ELSE */
            }
            else
            {


                /*" -633- DISPLAY 'PF0725B - FIM ANORMAL' */
                _.Display($"PF0725B - FIM ANORMAL");

                /*" -634- DISPLAY '          ERRO SELECT PROPOSTA FIDELIZ ' */
                _.Display($"          ERRO SELECT PROPOSTA FIDELIZ ");

                /*" -636- DISPLAY '          NUM BILHETE................. ' PROPOFID-NUM-SICOB */
                _.Display($"          NUM BILHETE................. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB}");

                /*" -638- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -639- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -640- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -640- END-IF. */
            }


        }

        [StopWatch]
        /*" R0340-00-LER-PRP-FIDELIZ-DB-SELECT-1 */
        public void R0340_00_LER_PRP_FIDELIZ_DB_SELECT_1()
        {
            /*" -626- EXEC SQL SELECT NUM_PROPOSTA_SIVPF , NUM_IDENTIFICACAO INTO :PROPOFID-NUM-PROPOSTA-SIVPF , :PROPOFID-NUM-IDENTIFICACAO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :PROPOFID-NUM-SICOB WITH UR END-EXEC. */

            var r0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1 = new R0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
            };

            var executed_1 = R0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-GERAR-REGISTRO-PGTO-SECTION */
        private void R0350_00_GERAR_REGISTRO_PGTO_SECTION()
        {
            /*" -652- MOVE 'R0350-00-GERAR-REGISTRO-PGTO' TO PARAGRAFO. */
            _.Move("R0350-00-GERAR-REGISTRO-PGTO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -654- MOVE 'WRITE REGISTRO SIDEM' TO COMANDO. */
            _.Move("WRITE REGISTRO SIDEM", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -656- MOVE SPACES TO REG-STA-SASSE. */
            _.Move("", REG_STA_SASSE);

            /*" -658- MOVE 8 TO R8-IDENTIFICACAO */
            _.Move(8, LBFPF025.R8_PONTUACAO_SIDEM.R8_IDENTIFICACAO);

            /*" -660- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R8-NUM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PROPOSTA);

            /*" -662- MOVE ZEROS TO R8-VLR-ESTOQUE. */
            _.Move(0, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_ESTOQUE);

            /*" -665- MOVE PARCEHIS-PRM-TOTAL TO R8-VLR-LANCAMENTO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO);

            /*" -667- MOVE W-PARC-ENDO TO R8-NUM-PARCELA. */
            _.Move(WORK_AREA.W_PARC_ENDO, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PARCELA);

            /*" -669- IF PARCEHIS-COD-OPERACAO GREATER 199 AND PARCEHIS-COD-OPERACAO LESS 300 */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO > 199 && PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO < 300)
            {

                /*" -670- MOVE 235 TO R8-TP-LANCAMENTO */
                _.Move(235, LBFPF025.R8_PONTUACAO_SIDEM.R8_TP_LANCAMENTO);

                /*" -671- ELSE */
            }
            else
            {


                /*" -672- MOVE 242 TO R8-TP-LANCAMENTO */
                _.Move(242, LBFPF025.R8_PONTUACAO_SIDEM.R8_TP_LANCAMENTO);

                /*" -674- END-IF. */
            }


            /*" -676- WRITE REG-STA-SASSE FROM R8-PONTUACAO-SIDEM. */
            _.Move(LBFPF025.R8_PONTUACAO_SIDEM.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -676- ADD 1 TO W-QTD-LD-TIPO-8. */
            WORK_AREA.W_QTD_LD_TIPO_8.Value = WORK_AREA.W_QTD_LD_TIPO_8 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R0800-00-GERAR-TRAILLER-SECTION */
        private void R0800_00_GERAR_TRAILLER_SECTION()
        {
            /*" -686- MOVE 'R0800-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R0800-00-GERAR-TRAILLER", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -688- MOVE 'WRITE REG-TRAILLER-STA' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER-STA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -690- MOVE SPACES TO REG-TRAILLER-STA. */
            _.Move("", LBFCT011.REG_TRAILLER_STA);

            /*" -693- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -695- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -705- MOVE ZEROS TO RT-QTDE-TIPO-1 RT-QTDE-TIPO-2 RT-QTDE-TIPO-3 RT-QTDE-TIPO-4 RT-QTDE-TIPO-5 RT-QTDE-TIPO-6 RT-QTDE-TIPO-7 RT-QTDE-TIPO-8 RT-QTDE-TIPO-9. */
            _.Move(0, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9);

            /*" -708- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER-STA */
            _.Move(WORK_AREA.W_QTD_LD_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8);

            /*" -720- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -720- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -729- MOVE 'R0850-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R0850-00-CONTROLAR-ARQ-ENVIADO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -731- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -734- MOVE 'STAPF725' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STAPF725", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -737- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -741- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -744- MOVE RT-QTDE-TIPO-8 OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -752- PERFORM R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -755- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -756- DISPLAY 'PF0725B - FIM ANORMAL' */
                _.Display($"PF0725B - FIM ANORMAL");

                /*" -757- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -759- DISPLAY '          SIGLA DO ARQUIVO..............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQUIVO..............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -761- DISPLAY '          SISTEMA DE ORIGEM.............  ' ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF */
                _.Display($"          SISTEMA DE ORIGEM.............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM}");

                /*" -763- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -765- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -767- DISPLAY '          QTDE DE REGISTROS.............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE DE REGISTROS.............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -768- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -768- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -752- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
            /*" -778- MOVE 'R0900-00-DECLARE-PAGAMENTOS ' TO PARAGRAFO. */
            _.Move("R0900-00-DECLARE-PAGAMENTOS ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -780- MOVE 'DECLARE CPAGAMENTOS         ' TO COMANDO. */
            _.Move("DECLARE CPAGAMENTOS         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -783- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO PARCEHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -874- PERFORM R0900_00_DECLARE_PAGAMENTOS_DB_DECLARE_1 */

            R0900_00_DECLARE_PAGAMENTOS_DB_DECLARE_1();

            /*" -878- MOVE 'OPEN CPAGAMENTOS                     ' TO COMANDO. */
            _.Move("OPEN CPAGAMENTOS                     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -878- PERFORM R0900_00_DECLARE_PAGAMENTOS_DB_OPEN_1 */

            R0900_00_DECLARE_PAGAMENTOS_DB_OPEN_1();

            /*" -881- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -882- DISPLAY 'PF0725B - FIM ANORMAL' */
                _.Display($"PF0725B - FIM ANORMAL");

                /*" -883- DISPLAY '          ERRO OPEN CURSOR CPAGAMENTOS   ' */
                _.Display($"          ERRO OPEN CURSOR CPAGAMENTOS   ");

                /*" -885- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -885- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PAGAMENTOS-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PAGAMENTOS_DB_DECLARE_1()
        {
            /*" -874- EXEC SQL DECLARE CPAGAMENTOS CURSOR FOR SELECT A.NUM_APOLICE , A.NUM_PARCELA , A.DATA_MOVIMENTO , A.COD_OPERACAO , A.PRM_TOTAL , B.NUM_BILHETE , B.RAMO FROM SEGUROS.PARCELA_HISTORICO A , SEGUROS.BILHETE B WHERE A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.NUM_PARCELA > 0 AND A.COD_OPERACAO >= 200 AND A.COD_OPERACAO <= 299 AND A.OCORR_HISTORICO > 1 AND A.NUM_AVISO_CREDITO > 0 AND A.DATA_QUITACAO IS NOT NULL AND B.NUM_APOLICE = A.NUM_APOLICE UNION SELECT A.NUM_APOLICE , A.NUM_PARCELA , A.DATA_MOVIMENTO , A.COD_OPERACAO , A.PRM_TOTAL , B.NUM_BILHETE , B.RAMO FROM SEGUROS.PARCELA_HISTORICO A , SEGUROS.BILHETE B WHERE A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.NUM_PARCELA > 0 AND A.COD_OPERACAO >= 500 AND A.COD_OPERACAO <= 599 AND A.OCORR_HISTORICO > 1 AND A.NUM_AVISO_CREDITO > 0 AND A.DATA_QUITACAO IS NOT NULL AND B.NUM_APOLICE = A.NUM_APOLICE UNION SELECT A.NUM_APOLICE , A.NUM_ENDOSSO , A.DATA_MOVIMENTO , A.COD_OPERACAO , A.VAL_OPERACAO , B.NUM_BILHETE , B.RAMO FROM SEGUROS.PARCELA_HISTORICO A , SEGUROS.BILHETE B , SEGUROS.PROPOSTA_FIDELIZ C WHERE A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.COD_OPERACAO >= 200 AND A.COD_OPERACAO <= 299 AND A.NUM_AVISO_CREDITO > 0 AND A.NUM_ENDOSSO > 1 AND A.DATA_QUITACAO IS NOT NULL AND B.RAMO IN (37,81) AND C.NUM_SICOB = B.NUM_BILHETE AND C.SIT_PROPOSTA = 'EMT' AND B.NUM_APOLICE = A.NUM_APOLICE UNION SELECT A.NUM_APOLICE , A.NUM_ENDOSSO , A.DATA_MOVIMENTO , A.COD_OPERACAO , A.VAL_OPERACAO , B.NUM_BILHETE , B.RAMO FROM SEGUROS.PARCELA_HISTORICO A , SEGUROS.BILHETE B , SEGUROS.PROPOSTA_FIDELIZ C WHERE A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.COD_OPERACAO >= 500 AND A.COD_OPERACAO <= 599 AND A.NUM_AVISO_CREDITO > 0 AND A.NUM_ENDOSSO > 1 AND A.DATA_QUITACAO IS NOT NULL AND B.RAMO IN (37,81) AND C.NUM_SICOB = B.NUM_BILHETE AND C.SIT_PROPOSTA = 'EMT' AND B.NUM_APOLICE = A.NUM_APOLICE ORDER BY 1 , 6 , 2 , 4 WITH UR END-EXEC. */
            CPAGAMENTOS = new PF0725B_CPAGAMENTOS(true);
            string GetQuery_CPAGAMENTOS()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NUM_PARCELA
							, 
							A.DATA_MOVIMENTO
							, 
							A.COD_OPERACAO
							, 
							A.PRM_TOTAL
							, 
							B.NUM_BILHETE
							, 
							B.RAMO 
							FROM SEGUROS.PARCELA_HISTORICO A
							, 
							SEGUROS.BILHETE B 
							WHERE A.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.NUM_PARCELA > 0 
							AND A.COD_OPERACAO >= 200 
							AND A.COD_OPERACAO <= 299 
							AND A.OCORR_HISTORICO > 1 
							AND A.NUM_AVISO_CREDITO > 0 
							AND A.DATA_QUITACAO IS NOT NULL 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							UNION 
							SELECT A.NUM_APOLICE
							, 
							A.NUM_PARCELA
							, 
							A.DATA_MOVIMENTO
							, 
							A.COD_OPERACAO
							, 
							A.PRM_TOTAL
							, 
							B.NUM_BILHETE
							, 
							B.RAMO 
							FROM SEGUROS.PARCELA_HISTORICO A
							, 
							SEGUROS.BILHETE B 
							WHERE A.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.NUM_PARCELA > 0 
							AND A.COD_OPERACAO >= 500 
							AND A.COD_OPERACAO <= 599 
							AND A.OCORR_HISTORICO > 1 
							AND A.NUM_AVISO_CREDITO > 0 
							AND A.DATA_QUITACAO IS NOT NULL 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							UNION 
							SELECT A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.DATA_MOVIMENTO
							, 
							A.COD_OPERACAO
							, 
							A.VAL_OPERACAO
							, 
							B.NUM_BILHETE
							, 
							B.RAMO 
							FROM SEGUROS.PARCELA_HISTORICO A
							, 
							SEGUROS.BILHETE B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C 
							WHERE A.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.COD_OPERACAO >= 200 
							AND A.COD_OPERACAO <= 299 
							AND A.NUM_AVISO_CREDITO > 0 
							AND A.NUM_ENDOSSO > 1 
							AND A.DATA_QUITACAO IS NOT NULL 
							AND B.RAMO IN (37
							,81) 
							AND C.NUM_SICOB = B.NUM_BILHETE 
							AND C.SIT_PROPOSTA = 'EMT' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							UNION 
							SELECT A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.DATA_MOVIMENTO
							, 
							A.COD_OPERACAO
							, 
							A.VAL_OPERACAO
							, 
							B.NUM_BILHETE
							, 
							B.RAMO 
							FROM SEGUROS.PARCELA_HISTORICO A
							, 
							SEGUROS.BILHETE B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C 
							WHERE A.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.COD_OPERACAO >= 500 
							AND A.COD_OPERACAO <= 599 
							AND A.NUM_AVISO_CREDITO > 0 
							AND A.NUM_ENDOSSO > 1 
							AND A.DATA_QUITACAO IS NOT NULL 
							AND B.RAMO IN (37
							,81) 
							AND C.NUM_SICOB = B.NUM_BILHETE 
							AND C.SIT_PROPOSTA = 'EMT' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							ORDER BY 1
							, 6
							, 2
							, 4";

                return query;
            }
            CPAGAMENTOS.GetQueryEvent += GetQuery_CPAGAMENTOS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PAGAMENTOS-DB-OPEN-1 */
        public void R0900_00_DECLARE_PAGAMENTOS_DB_OPEN_1()
        {
            /*" -878- EXEC SQL OPEN CPAGAMENTOS END-EXEC. */

            CPAGAMENTOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-SECTION */
        private void R0950_00_FETCH_PROPOSTA_SECTION()
        {
            /*" -896- MOVE 'R0950-00-FETCH-PROPOSTA     ' TO PARAGRAFO. */
            _.Move("R0950-00-FETCH-PROPOSTA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -898- MOVE 'FETCH CPAGAMENTOS           ' TO COMANDO. */
            _.Move("FETCH CPAGAMENTOS           ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -907- PERFORM R0950_00_FETCH_PROPOSTA_DB_FETCH_1 */

            R0950_00_FETCH_PROPOSTA_DB_FETCH_1();

            /*" -910- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -910- PERFORM R0950_00_FETCH_PROPOSTA_DB_CLOSE_1 */

                R0950_00_FETCH_PROPOSTA_DB_CLOSE_1();

                /*" -912- MOVE 1 TO WS-EOR */
                _.Move(1, WORK_AREA.WS_EOR);

                /*" -913- GO TO R0950-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/ //GOTO
                return;

                /*" -914- ELSE */
            }
            else
            {


                /*" -916- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

                if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
                {

                    /*" -917- DISPLAY 'PF0725B - FIM ANORMAL' */
                    _.Display($"PF0725B - FIM ANORMAL");

                    /*" -918- DISPLAY '          ERRO FETCH CURSOR CPAGAMENTOS   ' */
                    _.Display($"          ERRO FETCH CURSOR CPAGAMENTOS   ");

                    /*" -920- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -921- DISPLAY 'ULT APOLICE LIDA FETCH: ' W-ULT-APO-LID */
                    _.Display($"ULT APOLICE LIDA FETCH: {WORK_AREA.W_ULT_APO_LID}");

                    /*" -922- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -923- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -924- ELSE */
                }
                else
                {


                    /*" -925- MOVE PARCEHIS-NUM-APOLICE TO W-ULT-APO-LID */
                    _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, WORK_AREA.W_ULT_APO_LID);

                    /*" -928- ADD 1 TO AC-L-MOVIMENTO, AC-CONTROLE */
                    WORK_AREA.AC_L_MOVIMENTO.Value = WORK_AREA.AC_L_MOVIMENTO + 1;
                    WORK_AREA.AC_CONTROLE.Value = WORK_AREA.AC_CONTROLE + 1;

                    /*" -929- IF AC-CONTROLE GREATER 999 */

                    if (WORK_AREA.AC_CONTROLE > 999)
                    {

                        /*" -930- ACCEPT WS-TIME FROM TIME */
                        _.Move(_.AcceptDate("TIME"), WS_TIME);

                        /*" -931- MOVE WS-TIME-N TO WS-TIME-EDIT */
                        _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

                        /*" -932- DISPLAY ' ' */
                        _.Display($" ");

                        /*" -935- DISPLAY 'PF0725B - TOTAL LIDO ' AC-L-MOVIMENTO '  HORAS  ' WS-TIME-EDIT */

                        $"PF0725B - TOTAL LIDO {WORK_AREA.AC_L_MOVIMENTO}  HORAS  {WS_TIME_EDIT}"
                        .Display();

                        /*" -935- MOVE ZEROS TO AC-CONTROLE. */
                        _.Move(0, WORK_AREA.AC_CONTROLE);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-DB-FETCH-1 */
        public void R0950_00_FETCH_PROPOSTA_DB_FETCH_1()
        {
            /*" -907- EXEC SQL FETCH CPAGAMENTOS INTO :PARCEHIS-NUM-APOLICE , :W-PARC-ENDO , :PARCEHIS-DATA-MOVIMENTO , :PARCEHIS-COD-OPERACAO , :PARCEHIS-PRM-TOTAL , :BILHETE-NUM-BILHETE , :BILHETE-RAMO END-EXEC. */

            if (CPAGAMENTOS.Fetch())
            {
                _.Move(CPAGAMENTOS.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(CPAGAMENTOS.W_PARC_ENDO, WORK_AREA.W_PARC_ENDO);
                _.Move(CPAGAMENTOS.PARCEHIS_DATA_MOVIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);
                _.Move(CPAGAMENTOS.PARCEHIS_COD_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);
                _.Move(CPAGAMENTOS.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);
                _.Move(CPAGAMENTOS.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(CPAGAMENTOS.BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
            }

        }

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-DB-CLOSE-1 */
        public void R0950_00_FETCH_PROPOSTA_DB_CLOSE_1()
        {
            /*" -910- EXEC SQL CLOSE CPAGAMENTOS END-EXEC */

            CPAGAMENTOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-IMPRIMIR-TOTAIS-SECTION */
        private void R1000_00_IMPRIMIR_TOTAIS_SECTION()
        {
            /*" -945- MOVE 'R0870-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R0870-00-GERAR-TOTIAS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -947- MOVE ' ' TO COMANDO. */
            _.Move(" ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -948- DISPLAY ' ' */
            _.Display($" ");

            /*" -949- DISPLAY '////////////////////////////////////////////////' */
            _.Display($"////////////////////////////////////////////////");

            /*" -950- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -951- DISPLAY '//           PROGRAMA  =>  PF0725B            //' */
            _.Display($"//           PROGRAMA  =>  PF0725B            //");

            /*" -952- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -953- DISPLAY '//             TERMINO - NORMAL               //' */
            _.Display($"//             TERMINO - NORMAL               //");

            /*" -954- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -956- DISPLAY '//   TOTAL REGISTROS LIDOS........ ' AC-L-MOVIMENTO '     //' */

            $"//   TOTAL REGISTROS LIDOS........ {WORK_AREA.AC_L_MOVIMENTO}     //"
            .Display();

            /*" -958- DISPLAY '//   TOTAL GERADO ARQ. STATUS..... ' W-QTD-LD-TIPO-8 '     //' */

            $"//   TOTAL GERADO ARQ. STATUS..... {WORK_AREA.W_QTD_LD_TIPO_8}     //"
            .Display();

            /*" -959- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -959- DISPLAY '////////////////////////////////////////////////' . */
            _.Display($"////////////////////////////////////////////////");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1100-00-FECHAR-ARQUIVOS-SECTION */
        private void R1100_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -968- CLOSE MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -978- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

            /*" -979- MOVE SQLCODE TO RETURN-CODE. */
            _.Move(DB.SQLCODE, RETURN_CODE);

            /*" -980- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], AREA_ABEND.WABEND.WSQLERRD1);

            /*" -981- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], AREA_ABEND.WABEND.WSQLERRD2);

            /*" -982- DISPLAY WABEND. */
            _.Display(AREA_ABEND.WABEND);

            /*" -983- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1);

            /*" -985- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_2);

            /*" -985- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -987- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -991- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -991- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}