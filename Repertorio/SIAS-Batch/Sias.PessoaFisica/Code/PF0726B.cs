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
using Sias.PessoaFisica.DB2.PF0726B;

namespace Code
{
    public class PF0726B
    {
        public bool IsCall { get; set; }

        public PF0726B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------*                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA A CEF STATUS DE PAGAMENTO  /  *      */
        /*"      *                             DEVOLUCOES VIDA DA GENTE VENDIDOS  *      */
        /*"      *                             PELA GITEL(CANAL DE VENDA = 5)     *      */
        /*"      *   ANALISE/PROGRAMACAO.....  LUIZ CARLOS / LUCIA VIEIRA         *      */
        /*"      *   PROGRAMA ...............  PF0726B                            *      */
        /*"      *   DATA ...................  28/05/2008.                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.06                       DB2.V10  SELECTS                    *      */
        /*"      * ATENDE CADMUS 84809                                            *      */
        /*"      *                            REGINALDO DA SILVA                  *      */
        /*"      *                            16/09/2013                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.05 ATENDE SSI 24744                                          *      */
        /*"      *                                                                *      */
        /*"      * CORRIGE CURSOR SIT-REGISTRO = 1 OU 0                           *      */
        /*"      * EM 06/08/2009 - EDILANA C.  / LUIZ CARLOS  PROCURE POR V.05    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.04 ATENDE SSI 24744                                          *      */
        /*"      *                                                                *      */
        /*"      * CORRIGE CURSOR PARA TRATAR TAMBEM NUM-CERTIFICADO = NUM-SICOB  *      */
        /*"      *               E INCLUI SIT-REGISTRO = 1                        *      */
        /*"      * EM 27/07/2009 - EDILANA C.  / LUIZ CARLOS  PROCURE POR V.04    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.03 ATENDE SSI 24921                                          *      */
        /*"      *                                                                *      */
        /*"      * TRATAR, TAMBEM, PRODUTO PRESTAMISTA VENDIDO NA GITEL.          *      */
        /*"      * CODIGO DO PRODUTO 7707 E APOLICE 107700000013.                 *      */
        /*"      * EM 03/06/2009 - MAURICIO LINKE / LUIZ CARLOS  PROCURE POR V.03 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.02 ATENDE SSI 22210                                          *      */
        /*"      *                                                                *      */
        /*"      *         -  PASSA A BUSCAR VALOR DO PREMIO QDO FOR DEVOLUCAO    *      */
        /*"      *             NA PARAGRAFO R0350-00-GERAR-REGISTRO-PGTO          *      */
        /*"      * EM 09/06/2008 - LUCIA VIEIRA             PROCURE POR V.02      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - PASSA A BUSCAR VALOR DO PREMIO QDO FOR DEVOLUCAO *      */
        /*"      *               NA HIST_CONT_PARCELVA                            *      */
        /*"      *   EM 05/06/2008 - LUCIA VIEIRA             PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    PROJETO FGV  (POLITEC)  WELLINGTON VERAS  -  TE39902        *      */
        /*"      *                                                                *      */
        /*"      * 31/10/2008   INCLUIR WITH UR NO COMANDO SELECT      - WV1008   *      */
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
        public PF0726B_WORK_AREA WORK_AREA { get; set; } = new PF0726B_WORK_AREA();
        public class PF0726B_WORK_AREA : VarBasis
        {
            /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FILLER REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_PF0726B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0726B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0726B_FILLER_0(); _.Move(W_NUM_PROPOSTA, _filler_0); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _filler_0, W_NUM_PROPOSTA); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_NUM_PROPOSTA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0726B_FILLER_0 : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/
                public IntBasis W_CANAL_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        07  W-NUM-PROPOSTA-ATUAL      PIC 9(012).*/
                public IntBasis W_NUM_PROPOSTA_ATUAL { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"        07  W-DV-PROPOSTA             PIC 9(001).*/
                public IntBasis W_DV_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05 W-LER-PARCELA                 PIC 9(001)   VALUE ZEROS.*/

                public _REDEF_PF0726B_FILLER_0()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    W_NUM_PROPOSTA_ATUAL.ValueChanged += OnValueChanged;
                    W_DV_PROPOSTA.ValueChanged += OnValueChanged;
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
            /*"    05 AC-DESPREZADA                 PIC  9(006)  VALUE ZEROS.*/
            public IntBasis AC_DESPREZADA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 W-QTD-LD-TIPO-8               PIC  9(006)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 DATA-SQL1                     PIC  X(010).*/
            public StringBasis DATA_SQL1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 DATA-SQL  REDEFINES DATA-SQL1.*/
            private _REDEF_PF0726B_DATA_SQL _data_sql { get; set; }
            public _REDEF_PF0726B_DATA_SQL DATA_SQL
            {
                get { _data_sql = new _REDEF_PF0726B_DATA_SQL(); _.Move(DATA_SQL1, _data_sql); VarBasis.RedefinePassValue(DATA_SQL1, _data_sql, DATA_SQL1); _data_sql.ValueChanged += () => { _.Move(_data_sql, DATA_SQL1); }; return _data_sql; }
                set { VarBasis.RedefinePassValue(value, _data_sql, DATA_SQL1); }
            }  //Redefines
            public class _REDEF_PF0726B_DATA_SQL : VarBasis
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

                public _REDEF_PF0726B_DATA_SQL()
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
            private _REDEF_PF0726B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0726B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0726B_FILLER_3(); _.Move(W_DATA_TRABALHO, _filler_3); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_3, W_DATA_TRABALHO); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_DATA_TRABALHO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0726B_FILLER_3 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0726B_FILLER_3()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0726B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0726B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0726B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0726B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0726B_W_DTMOVABE1()
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
            private _REDEF_PF0726B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0726B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0726B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0726B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0726B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0726B_WS_TIME WS_TIME { get; set; } = new PF0726B_WS_TIME();
        public class PF0726B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01             W01DIGCERT.*/
        public PF0726B_W01DIGCERT W01DIGCERT { get; set; } = new PF0726B_W01DIGCERT();
        public class PF0726B_W01DIGCERT : VarBasis
        {
            /*"    05         WCERTIFICADO    PIC  9(015)        VALUE  0.*/
            public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05         WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
            public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
            /*"    05         WDIG            PIC  X(001)  VALUE SPACES.*/
            public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  AREA-ABEND.*/
        }
        public PF0726B_AREA_ABEND AREA_ABEND { get; set; } = new PF0726B_AREA_ABEND();
        public class PF0726B_AREA_ABEND : VarBasis
        {
            /*"    05   WABEND.*/
            public PF0726B_WABEND WABEND { get; set; } = new PF0726B_WABEND();
            public class PF0726B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0726B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0726B  ");
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
            public PF0726B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0726B_LOCALIZA_ABEND_1();
            public class PF0726B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0726B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0726B_LOCALIZA_ABEND_2();
            public class PF0726B_LOCALIZA_ABEND_2 : VarBasis
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
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.IDERELAC IDERELAC { get; set; } = new Dclgens.IDERELAC();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public PF0726B_CPAGAMENTOS CPAGAMENTOS { get; set; } = new PF0726B_CPAGAMENTOS();
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
            /*" -232- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -234- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -236- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -239- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -240- DISPLAY '*               PROGRAMA PF0726B               *' . */
            _.Display($"*               PROGRAMA PF0726B               *");

            /*" -241- DISPLAY '*        GERA A CEF STATUS DE PAGAMENTO        *' . */
            _.Display($"*        GERA A CEF STATUS DE PAGAMENTO        *");

            /*" -242- DISPLAY '*           VERSAO:  07 - 02/06/2014           *' . */
            _.Display($"*           VERSAO:  07 - 02/06/2014           *");

            /*" -243- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -252- DISPLAY '*  PF0726B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0726B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -254- PERFORM R0100-00-INICIALIZA. */

            R0100_00_INICIALIZA_SECTION();

            /*" -255- PERFORM R0900-00-DECLARE-PAGAMENTOS. */

            R0900_00_DECLARE_PAGAMENTOS_SECTION();

            /*" -257- PERFORM R0950-00-FETCH-PROPOSTA. */

            R0950_00_FETCH_PROPOSTA_SECTION();

            /*" -258- IF WS-EOR = 1 */

            if (WORK_AREA.WS_EOR == 1)
            {

                /*" -259- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -260- DISPLAY '*                                            *' */
                _.Display($"*                                            *");

                /*" -261- DISPLAY '*                  PF0726B                   *' */
                _.Display($"*                  PF0726B                   *");

                /*" -262- DISPLAY '*              TERMINO  NORMAL               *' */
                _.Display($"*              TERMINO  NORMAL               *");

                /*" -263- DISPLAY '*        NAO HOUVE PAGAMENTO NO DIA          *' */
                _.Display($"*        NAO HOUVE PAGAMENTO NO DIA          *");

                /*" -264- DISPLAY '*                                            *' */
                _.Display($"*                                            *");

                /*" -265- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -267- GO TO R0000-00-FINALIZA. */

                R0000_00_FINALIZA(); //GOTO
                return;
            }


            /*" -269- PERFORM R0150-00-ABRIR-ARQUIVOS. */

            R0150_00_ABRIR_ARQUIVOS_SECTION();

            /*" -271- PERFORM R0200-00-OBTER-MAX-NSAS. */

            R0200_00_OBTER_MAX_NSAS_SECTION();

            /*" -273- PERFORM R0250-00-GERAR-HEADER */

            R0250_00_GERAR_HEADER_SECTION();

            /*" -276- PERFORM R0300-00-PROCESSA-REGISTRO UNTIL WS-EOR = 1. */

            while (!(WORK_AREA.WS_EOR == 1))
            {

                R0300_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -278- PERFORM R0800-00-GERAR-TRAILLER. */

            R0800_00_GERAR_TRAILLER_SECTION();

            /*" -280- PERFORM R0850-00-CONTROLAR-ARQ-ENVIADO */

            R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -282- PERFORM R1000-00-IMPRIMIR-TOTAIS. */

            R1000_00_IMPRIMIR_TOTAIS_SECTION();

            /*" -282- PERFORM R1100-00-FECHAR-ARQUIVOS. */

            R1100_00_FECHAR_ARQUIVOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_00_FINALIZA */

            R0000_00_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-FINALIZA */
        private void R0000_00_FINALIZA(bool isPerform = false)
        {
            /*" -289- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -293- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -293- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-SECTION */
        private void R0100_00_INICIALIZA_SECTION()
        {
            /*" -301- MOVE '0000-PRINCIPAL               ' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL               ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -303- MOVE 'R0100-00-SELECT-SISTEMAS     ' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-SISTEMAS     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -305- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -311- PERFORM R0100_00_INICIALIZA_DB_SELECT_1 */

            R0100_00_INICIALIZA_DB_SELECT_1();

            /*" -314- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -315- DISPLAY 'PF0726B - FIM ANORMAL' */
                _.Display($"PF0726B - FIM ANORMAL");

                /*" -316- DISPLAY '          ERRO ACESSO TABELA SISTEMAS  ' */
                _.Display($"          ERRO ACESSO TABELA SISTEMAS  ");

                /*" -318- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -320- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -321- DISPLAY ' ' */
            _.Display($" ");

            /*" -323- DISPLAY 'DATA DO PROCESSAMENTO: ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA DO PROCESSAMENTO: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -325- DISPLAY ' ' . */
            _.Display($" ");

            /*" -327- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.W_DTMOVABE);

            /*" -329- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_DIA_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -331- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_MES_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -334- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_ANO_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -338- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WORK_AREA.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WORK_AREA.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -346- INITIALIZE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA RT-QTDE-TIPO-2 OF REG-TRAILLER-STA RT-QTDE-TIPO-3 OF REG-TRAILLER-STA RT-QTDE-TIPO-4 OF REG-TRAILLER-STA RT-QTDE-TIPO-5 OF REG-TRAILLER-STA RT-QTDE-TIPO-6 OF REG-TRAILLER-STA RT-QTDE-TIPO-7 OF REG-TRAILLER-STA RT-QTDE-TIPO-8 OF REG-TRAILLER-STA RT-QTDE-TIPO-9 OF REG-TRAILLER-STA. */
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
            /*" -311- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
            /*" -358- MOVE 'R0150-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0150-00-ABRIR-ARQUIVOS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -360- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -360- OPEN OUTPUT MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0200-00-OBTER-MAX-NSAS-SECTION */
        private void R0200_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -370- MOVE 'R0200-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0200-00-OBTER-MAX-NSAS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -372- MOVE 'SELECT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -375- MOVE 'STAPF726' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STAPF726", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -378- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -382- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -395- PERFORM R0200_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0200_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -398- IF SQLCODE EQUAL 00 OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -399- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -400- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -401- DISPLAY '//           PROGRAMA  =>  PF0726B            //' */
                _.Display($"//           PROGRAMA  =>  PF0726B            //");

                /*" -402- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -403- DISPLAY '//             TERMINO - ANORMAL              //' */
                _.Display($"//             TERMINO - ANORMAL              //");

                /*" -404- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -405- DISPLAY '//   ==>  DATA PROCESSADA ANTERIORMENTE <==   //' */
                _.Display($"//   ==>  DATA PROCESSADA ANTERIORMENTE <==   //");

                /*" -406- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -411- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -412- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -413- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -414- ELSE */
            }
            else
            {


                /*" -415- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -416- DISPLAY 'PF0726B - FIM ANORMAL' */
                    _.Display($"PF0726B - FIM ANORMAL");

                    /*" -417- DISPLAY '          ERRO SELECT ARQUIVOS-SIVPF' */
                    _.Display($"          ERRO SELECT ARQUIVOS-SIVPF");

                    /*" -419- DISPLAY '          SQLCODE....................... ' SQLCODE */
                    _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                    /*" -420- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -422- PERFORM R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION();
                }

            }


            /*" -424- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -433- PERFORM R0200_00_OBTER_MAX_NSAS_DB_SELECT_2 */

            R0200_00_OBTER_MAX_NSAS_DB_SELECT_2();

            /*" -436- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -437- DISPLAY 'PF0726B - FIM ANORMAL' */
                _.Display($"PF0726B - FIM ANORMAL");

                /*" -438- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -440- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -441- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -443- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -443- ADD 1 TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.Value = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF + 1;

        }

        [StopWatch]
        /*" R0200-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0200_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -395- EXEC SQL SELECT NSAS_SIVPF INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM AND DATA_PROCESSAMENTO = :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO AND DATA_GERACAO = :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO WITH UR END-EXEC. */

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
            /*" -433- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

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
            /*" -453- MOVE 'R0250-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0250-00-GERAR-HEADER", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -455- MOVE 'WRITE REG-HEADER-STA' TO COMANDO. */
            _.Move("WRITE REG-HEADER-STA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -457- MOVE SPACES TO REG-HEADER-STA. */
            _.Move("", LBFCT011.REG_HEADER_STA);

            /*" -460- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -463- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -465- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.W_DTMOVABE);

            /*" -466- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_DIA_MOVABE, WORK_AREA.FILLER_3.W_DIA_TRABALHO);

            /*" -467- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_MES_MOVABE, WORK_AREA.FILLER_3.W_MES_TRABALHO);

            /*" -469- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_ANO_MOVABE, WORK_AREA.FILLER_3.W_ANO_TRABALHO);

            /*" -472- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Move(WORK_AREA.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -475- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -478- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -481- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER-STA */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_HEADER_STA.RH_NSAS);

            /*" -481- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0300-00-PROCESSA-REGISTRO-SECTION */
        private void R0300_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -492- MOVE HISCONPA-NUM-CERTIFICADO TO W-NUM-PROPOSTA. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, WORK_AREA.W_NUM_PROPOSTA);

            /*" -494- INITIALIZE R8-PONTUACAO-SIDEM. */
            _.Initialize(
                LBFPF025.R8_PONTUACAO_SIDEM
            );

            /*" -494- PERFORM R0350-00-GERAR-REGISTRO-PGTO. */

            R0350_00_GERAR_REGISTRO_PGTO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0300_10_LE_OUTRA_PROPOSTA */

            R0300_10_LE_OUTRA_PROPOSTA();

        }

        [StopWatch]
        /*" R0300-10-LE-OUTRA-PROPOSTA */
        private void R0300_10_LE_OUTRA_PROPOSTA(bool isPerform = false)
        {
            /*" -498- PERFORM R0950-00-FETCH-PROPOSTA. */

            R0950_00_FETCH_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0340-00-OBTER-PARCELA-SECTION */
        private void R0340_00_OBTER_PARCELA_SECTION()
        {
            /*" -511- MOVE '0340-00-OBTER-PARCELA ' TO PARAGRAFO. */
            _.Move("0340-00-OBTER-PARCELA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -513- MOVE 'SELECT PARCELAS_VIDAZUL' TO COMANDO. */
            _.Move("SELECT PARCELAS_VIDAZUL", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -516- MOVE HISCONPA-NUM-CERTIFICADO TO PARCEVID-NUM-CERTIFICADO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_CERTIFICADO);

            /*" -519- MOVE HISCONPA-NUM-PARCELA TO PARCEVID-NUM-PARCELA. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);

            /*" -522- MOVE HISCONPA-OCORR-HISTORICO TO PARCEVID-OCORR-HISTORICO. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO);

            /*" -531- PERFORM R0340_00_OBTER_PARCELA_DB_SELECT_1 */

            R0340_00_OBTER_PARCELA_DB_SELECT_1();

            /*" -534- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -535- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -536- MOVE 0 TO W-LER-PARCELA */
                    _.Move(0, WORK_AREA.W_LER_PARCELA);

                    /*" -538- DISPLAY 'PROPOSTA NAO CADASTRADA NA PARCELA  ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"PROPOSTA NAO CADASTRADA NA PARCELA  {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -539- ELSE */
                }
                else
                {


                    /*" -540- DISPLAY 'PF0726B - FIM ANORMAL' */
                    _.Display($"PF0726B - FIM ANORMAL");

                    /*" -541- DISPLAY '          ERRO ACESSO PARCELAS-VIDAZUL' */
                    _.Display($"          ERRO ACESSO PARCELAS-VIDAZUL");

                    /*" -543- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICADO.......... {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -545- DISPLAY '          NUMERO DA PARCELA........... ' HISCONPA-NUM-PARCELA */
                    _.Display($"          NUMERO DA PARCELA........... {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA}");

                    /*" -547- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -548- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -549- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -550- ELSE */
                }

            }
            else
            {


                /*" -550- MOVE 1 TO W-LER-PARCELA. */
                _.Move(1, WORK_AREA.W_LER_PARCELA);
            }


        }

        [StopWatch]
        /*" R0340-00-OBTER-PARCELA-DB-SELECT-1 */
        public void R0340_00_OBTER_PARCELA_DB_SELECT_1()
        {
            /*" -531- EXEC SQL SELECT PREMIO_VG, PREMIO_AP INTO :PARCEVID-PREMIO-VG, :PARCEVID-PREMIO-AP FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PARCEVID-NUM-CERTIFICADO AND NUM_PARCELA = :PARCEVID-NUM-PARCELA WITH UR END-EXEC. */

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
            /*" -564- MOVE 'R0350-00-GERAR-REGISTRO-PGTO' TO PARAGRAFO. */
            _.Move("R0350-00-GERAR-REGISTRO-PGTO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -566- MOVE 'WRITE REGISTRO SIDEM' TO COMANDO. */
            _.Move("WRITE REGISTRO SIDEM", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -568- MOVE SPACES TO REG-STA-SASSE. */
            _.Move("", REG_STA_SASSE);

            /*" -570- MOVE 8 TO R8-IDENTIFICACAO */
            _.Move(8, LBFPF025.R8_PONTUACAO_SIDEM.R8_IDENTIFICACAO);

            /*" -572- MOVE HISCONPA-NUM-CERTIFICADO TO R8-NUM-PROPOSTA. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PROPOSTA);

            /*" -574- MOVE ZEROS TO R8-VLR-ESTOQUE. */
            _.Move(0, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_ESTOQUE);

            /*" -576- MOVE HISCONPA-NUM-PARCELA TO R8-NUM-PARCELA. */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PARCELA);

            /*" -578- IF HISCONPA-COD-OPERACAO GREATER 199 AND HISCONPA-COD-OPERACAO LESS 300 */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO > 199 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO < 300)
            {

                /*" -579- MOVE 235 TO R8-TP-LANCAMENTO */
                _.Move(235, LBFPF025.R8_PONTUACAO_SIDEM.R8_TP_LANCAMENTO);

                /*" -580- PERFORM R0340-00-OBTER-PARCELA */

                R0340_00_OBTER_PARCELA_SECTION();

                /*" -581- IF PARCELA-ENCONTRADA */

                if (WORK_AREA.W_LER_PARCELA["PARCELA_ENCONTRADA"])
                {

                    /*" -582- MOVE PARCEVID-PREMIO-VG TO HISCONPA-PREMIO-VG */
                    _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);

                    /*" -583- MOVE PARCEVID-PREMIO-AP TO HISCONPA-PREMIO-AP */
                    _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

                    /*" -584- END-IF */
                }


                /*" -585- ELSE */
            }
            else
            {


                /*" -586- MOVE 242 TO R8-TP-LANCAMENTO */
                _.Move(242, LBFPF025.R8_PONTUACAO_SIDEM.R8_TP_LANCAMENTO);

                /*" -588- END-IF. */
            }


            /*" -591- COMPUTE R8-VLR-LANCAMENTO = HISCONPA-PREMIO-VG + HISCONPA-PREMIO-AP. */
            LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO.Value = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG + HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP;

            /*" -593- WRITE REG-STA-SASSE FROM R8-PONTUACAO-SIDEM. */
            _.Move(LBFPF025.R8_PONTUACAO_SIDEM.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -593- ADD 1 TO W-QTD-LD-TIPO-8. */
            WORK_AREA.W_QTD_LD_TIPO_8.Value = WORK_AREA.W_QTD_LD_TIPO_8 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R0800-00-GERAR-TRAILLER-SECTION */
        private void R0800_00_GERAR_TRAILLER_SECTION()
        {
            /*" -603- MOVE 'R0800-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R0800-00-GERAR-TRAILLER", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -605- MOVE 'WRITE REG-TRAILLER-STA' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER-STA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -607- MOVE SPACES TO REG-TRAILLER-STA. */
            _.Move("", LBFCT011.REG_TRAILLER_STA);

            /*" -610- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -613- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -616- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER-STA */
            _.Move(WORK_AREA.W_QTD_LD_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8);

            /*" -627- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -627- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -636- MOVE 'R0850-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R0850-00-CONTROLAR-ARQ-ENVIADO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -638- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -641- MOVE 'STAPF726' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STAPF726", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -644- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -648- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -651- MOVE RT-QTDE-TIPO-8 OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -659- PERFORM R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -662- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -663- DISPLAY 'PF0726B - FIM ANORMAL' */
                _.Display($"PF0726B - FIM ANORMAL");

                /*" -664- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -666- DISPLAY '          SIGLA DO ARQUIVO..............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQUIVO..............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -668- DISPLAY '          SISTEMA DE ORIGEM.............  ' ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF */
                _.Display($"          SISTEMA DE ORIGEM.............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM}");

                /*" -670- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -672- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -674- DISPLAY '          QTDE DE REGISTROS.............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE DE REGISTROS.............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -675- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -675- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -659- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
            /*" -685- MOVE 'R0900-00-DECLARE-PAGAMENTOS ' TO PARAGRAFO. */
            _.Move("R0900-00-DECLARE-PAGAMENTOS ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -687- MOVE 'DECLARE CPAGAMENTOS         ' TO COMANDO. */
            _.Move("DECLARE CPAGAMENTOS         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -690- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO HISCONPA-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO);

            /*" -781- PERFORM R0900_00_DECLARE_PAGAMENTOS_DB_DECLARE_1 */

            R0900_00_DECLARE_PAGAMENTOS_DB_DECLARE_1();

            /*" -786- MOVE 'OPEN CPAGAMENTOS                     ' TO COMANDO. */
            _.Move("OPEN CPAGAMENTOS                     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -786- PERFORM R0900_00_DECLARE_PAGAMENTOS_DB_OPEN_1 */

            R0900_00_DECLARE_PAGAMENTOS_DB_OPEN_1();

            /*" -789- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -790- DISPLAY 'PF0726B - FIM ANORMAL' */
                _.Display($"PF0726B - FIM ANORMAL");

                /*" -791- DISPLAY '          ERRO OPEN CURSOR CPAGAMENTOS   ' */
                _.Display($"          ERRO OPEN CURSOR CPAGAMENTOS   ");

                /*" -793- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -793- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PAGAMENTOS-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PAGAMENTOS_DB_DECLARE_1()
        {
            /*" -781- EXEC SQL DECLARE CPAGAMENTOS CURSOR FOR SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.NUM_CERTIFICADO, B.NUM_PARCELA , B.PREMIO_VG , B.PREMIO_AP , B.OCORR_HISTORICO, B.COD_OPERACAO FROM SEGUROS.HIST_CONT_PARCELVA B, SEGUROS.PROPOSTA_FIDELIZ C WHERE B.NUM_CERTIFICADO = C.NUM_PROPOSTA_SIVPF AND C.COD_EMPRESA_SIVPF = 1 AND C.CANAL_PROPOSTA = 5 AND B.NUM_PARCELA > 1 AND B.COD_OPERACAO >= 200 AND B.COD_OPERACAO <= 299 AND B.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND B.SIT_REGISTRO IN ( '1' , '0' ) UNION SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.NUM_CERTIFICADO, B.NUM_PARCELA , B.PREMIO_VG , B.PREMIO_AP , B.OCORR_HISTORICO, B.COD_OPERACAO FROM SEGUROS.HIST_CONT_PARCELVA B, SEGUROS.PROPOSTA_FIDELIZ C WHERE B.NUM_CERTIFICADO = C.NUM_SICOB AND C.COD_EMPRESA_SIVPF = 1 AND C.CANAL_PROPOSTA = 5 AND B.NUM_PARCELA > 1 AND B.COD_OPERACAO >= 200 AND B.COD_OPERACAO <= 299 AND B.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND B.SIT_REGISTRO IN ( '1' , '0' ) UNION SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.NUM_CERTIFICADO, B.NUM_PARCELA , B.PREMIO_VG , B.PREMIO_AP , B.OCORR_HISTORICO, B.COD_OPERACAO FROM SEGUROS.HIST_CONT_PARCELVA B, SEGUROS.PROPOSTA_FIDELIZ C WHERE B.NUM_CERTIFICADO = C.NUM_PROPOSTA_SIVPF AND C.COD_EMPRESA_SIVPF = 1 AND C.CANAL_PROPOSTA = 5 AND B.COD_OPERACAO >= 500 AND B.COD_OPERACAO <= 599 AND B.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND B.SIT_REGISTRO IN ( '1' , '0' ) UNION SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.NUM_CERTIFICADO, B.NUM_PARCELA , B.PREMIO_VG , B.PREMIO_AP , B.OCORR_HISTORICO, B.COD_OPERACAO FROM SEGUROS.HIST_CONT_PARCELVA B, SEGUROS.PROPOSTA_FIDELIZ C WHERE B.NUM_CERTIFICADO = C.NUM_SICOB AND C.COD_EMPRESA_SIVPF = 1 AND C.CANAL_PROPOSTA = 5 AND B.COD_OPERACAO >= 500 AND B.COD_OPERACAO <= 599 AND B.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND B.SIT_REGISTRO IN ( '1' , '0' ) GROUP BY B.NUM_APOLICE , B.COD_SUBGRUPO , B.NUM_CERTIFICADO, B.NUM_PARCELA , B.PREMIO_VG , B.PREMIO_AP , B.OCORR_HISTORICO, B.COD_OPERACAO ORDER BY 1, 2, 3, 4, 5, 6, 7, 8 WITH UR END-EXEC. */
            CPAGAMENTOS = new PF0726B_CPAGAMENTOS(true);
            string GetQuery_CPAGAMENTOS()
            {
                var query = @$"SELECT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_CERTIFICADO
							, 
							B.NUM_PARCELA
							, 
							B.PREMIO_VG
							, 
							B.PREMIO_AP
							, 
							B.OCORR_HISTORICO
							, 
							B.COD_OPERACAO 
							FROM SEGUROS.HIST_CONT_PARCELVA B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C 
							WHERE B.NUM_CERTIFICADO = C.NUM_PROPOSTA_SIVPF 
							AND C.COD_EMPRESA_SIVPF = 1 
							AND C.CANAL_PROPOSTA = 5 
							AND B.NUM_PARCELA > 1 
							AND B.COD_OPERACAO >= 200 
							AND B.COD_OPERACAO <= 299 
							AND B.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.SIT_REGISTRO IN ( '1'
							, '0' ) 
							UNION 
							SELECT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_CERTIFICADO
							, 
							B.NUM_PARCELA
							, 
							B.PREMIO_VG
							, 
							B.PREMIO_AP
							, 
							B.OCORR_HISTORICO
							, 
							B.COD_OPERACAO 
							FROM SEGUROS.HIST_CONT_PARCELVA B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C 
							WHERE B.NUM_CERTIFICADO = C.NUM_SICOB 
							AND C.COD_EMPRESA_SIVPF = 1 
							AND C.CANAL_PROPOSTA = 5 
							AND B.NUM_PARCELA > 1 
							AND B.COD_OPERACAO >= 200 
							AND B.COD_OPERACAO <= 299 
							AND B.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.SIT_REGISTRO IN ( '1'
							, '0' ) 
							UNION 
							SELECT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_CERTIFICADO
							, 
							B.NUM_PARCELA
							, 
							B.PREMIO_VG
							, 
							B.PREMIO_AP
							, 
							B.OCORR_HISTORICO
							, 
							B.COD_OPERACAO 
							FROM SEGUROS.HIST_CONT_PARCELVA B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C 
							WHERE B.NUM_CERTIFICADO = C.NUM_PROPOSTA_SIVPF 
							AND C.COD_EMPRESA_SIVPF = 1 
							AND C.CANAL_PROPOSTA = 5 
							AND B.COD_OPERACAO >= 500 
							AND B.COD_OPERACAO <= 599 
							AND B.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.SIT_REGISTRO IN ( '1'
							, '0' ) 
							UNION 
							SELECT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_CERTIFICADO
							, 
							B.NUM_PARCELA
							, 
							B.PREMIO_VG
							, 
							B.PREMIO_AP
							, 
							B.OCORR_HISTORICO
							, 
							B.COD_OPERACAO 
							FROM SEGUROS.HIST_CONT_PARCELVA B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C 
							WHERE B.NUM_CERTIFICADO = C.NUM_SICOB 
							AND C.COD_EMPRESA_SIVPF = 1 
							AND C.CANAL_PROPOSTA = 5 
							AND B.COD_OPERACAO >= 500 
							AND B.COD_OPERACAO <= 599 
							AND B.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.SIT_REGISTRO IN ( '1'
							, '0' ) 
							GROUP BY B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_CERTIFICADO
							, 
							B.NUM_PARCELA
							, 
							B.PREMIO_VG
							, 
							B.PREMIO_AP
							, 
							B.OCORR_HISTORICO
							, 
							B.COD_OPERACAO 
							ORDER BY 1
							, 2
							, 3
							, 4
							, 5
							, 6
							, 7
							, 8";

                return query;
            }
            CPAGAMENTOS.GetQueryEvent += GetQuery_CPAGAMENTOS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PAGAMENTOS-DB-OPEN-1 */
        public void R0900_00_DECLARE_PAGAMENTOS_DB_OPEN_1()
        {
            /*" -786- EXEC SQL OPEN CPAGAMENTOS END-EXEC. */

            CPAGAMENTOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-SECTION */
        private void R0950_00_FETCH_PROPOSTA_SECTION()
        {
            /*" -804- MOVE 'R0950-00-FETCH-PROPOSTA     ' TO PARAGRAFO. */
            _.Move("R0950-00-FETCH-PROPOSTA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -806- MOVE 'FETCH CPAGAMENTOS           ' TO COMANDO. */
            _.Move("FETCH CPAGAMENTOS           ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -816- PERFORM R0950_00_FETCH_PROPOSTA_DB_FETCH_1 */

            R0950_00_FETCH_PROPOSTA_DB_FETCH_1();

            /*" -819- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -819- PERFORM R0950_00_FETCH_PROPOSTA_DB_CLOSE_1 */

                R0950_00_FETCH_PROPOSTA_DB_CLOSE_1();

                /*" -821- MOVE 1 TO WS-EOR */
                _.Move(1, WORK_AREA.WS_EOR);

                /*" -822- GO TO R0950-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/ //GOTO
                return;

                /*" -823- ELSE */
            }
            else
            {


                /*" -825- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

                if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
                {

                    /*" -826- DISPLAY 'PF0726B - FIM ANORMAL' */
                    _.Display($"PF0726B - FIM ANORMAL");

                    /*" -827- DISPLAY '          ERRO FETCH CURSOR CPAGAMENTOS   ' */
                    _.Display($"          ERRO FETCH CURSOR CPAGAMENTOS   ");

                    /*" -829- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -830- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -831- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -832- ELSE */
                }
                else
                {


                    /*" -835- ADD 1 TO AC-L-MOVIMENTO, AC-CONTROLE */
                    WORK_AREA.AC_L_MOVIMENTO.Value = WORK_AREA.AC_L_MOVIMENTO + 1;
                    WORK_AREA.AC_CONTROLE.Value = WORK_AREA.AC_CONTROLE + 1;

                    /*" -836- IF AC-CONTROLE GREATER 999 */

                    if (WORK_AREA.AC_CONTROLE > 999)
                    {

                        /*" -837- ACCEPT WS-TIME FROM TIME */
                        _.Move(_.AcceptDate("TIME"), WS_TIME);

                        /*" -838- MOVE WS-TIME-N TO WS-TIME-EDIT */
                        _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

                        /*" -839- DISPLAY ' ' */
                        _.Display($" ");

                        /*" -842- DISPLAY 'PF0726B - TOTAL LIDO ' AC-L-MOVIMENTO '  HORAS  ' WS-TIME-EDIT */

                        $"PF0726B - TOTAL LIDO {WORK_AREA.AC_L_MOVIMENTO}  HORAS  {WS_TIME_EDIT}"
                        .Display();

                        /*" -842- MOVE ZEROS TO AC-CONTROLE. */
                        _.Move(0, WORK_AREA.AC_CONTROLE);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-DB-FETCH-1 */
        public void R0950_00_FETCH_PROPOSTA_DB_FETCH_1()
        {
            /*" -816- EXEC SQL FETCH CPAGAMENTOS INTO :HISCONPA-NUM-APOLICE , :HISCONPA-COD-SUBGRUPO , :HISCONPA-NUM-CERTIFICADO, :HISCONPA-NUM-PARCELA , :HISCONPA-PREMIO-VG , :HISCONPA-PREMIO-AP , :HISCONPA-OCORR-HISTORICO, :HISCONPA-COD-OPERACAO END-EXEC. */

            if (CPAGAMENTOS.Fetch())
            {
                _.Move(CPAGAMENTOS.HISCONPA_NUM_APOLICE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE);
                _.Move(CPAGAMENTOS.HISCONPA_COD_SUBGRUPO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO);
                _.Move(CPAGAMENTOS.HISCONPA_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);
                _.Move(CPAGAMENTOS.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(CPAGAMENTOS.HISCONPA_PREMIO_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);
                _.Move(CPAGAMENTOS.HISCONPA_PREMIO_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);
                _.Move(CPAGAMENTOS.HISCONPA_OCORR_HISTORICO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);
                _.Move(CPAGAMENTOS.HISCONPA_COD_OPERACAO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);
            }

        }

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-DB-CLOSE-1 */
        public void R0950_00_FETCH_PROPOSTA_DB_CLOSE_1()
        {
            /*" -819- EXEC SQL CLOSE CPAGAMENTOS END-EXEC */

            CPAGAMENTOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-IMPRIMIR-TOTAIS-SECTION */
        private void R1000_00_IMPRIMIR_TOTAIS_SECTION()
        {
            /*" -852- MOVE 'R0870-00-GERAR-TOTAIS' TO PARAGRAFO. */
            _.Move("R0870-00-GERAR-TOTAIS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -854- MOVE ' ' TO COMANDO. */
            _.Move(" ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -855- DISPLAY ' ' */
            _.Display($" ");

            /*" -856- DISPLAY '////////////////////////////////////////////////' */
            _.Display($"////////////////////////////////////////////////");

            /*" -857- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -858- DISPLAY '//           PROGRAMA  =>  PF0726B            //' */
            _.Display($"//           PROGRAMA  =>  PF0726B            //");

            /*" -859- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -860- DISPLAY '//             TERMINO - NORMAL               //' */
            _.Display($"//             TERMINO - NORMAL               //");

            /*" -861- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -863- DISPLAY '//   TOTAL REGISTROS LIDOS........ ' AC-L-MOVIMENTO '     //' */

            $"//   TOTAL REGISTROS LIDOS........ {WORK_AREA.AC_L_MOVIMENTO}     //"
            .Display();

            /*" -865- DISPLAY '//   TOTAL REGISTROS DESPREZADOS.. ' AC-DESPREZADA '     //' */

            $"//   TOTAL REGISTROS DESPREZADOS.. {WORK_AREA.AC_DESPREZADA}     //"
            .Display();

            /*" -867- DISPLAY '//   TOTAL GERADO ARQ. STATUS..... ' W-QTD-LD-TIPO-8 '     //' */

            $"//   TOTAL GERADO ARQ. STATUS..... {WORK_AREA.W_QTD_LD_TIPO_8}     //"
            .Display();

            /*" -868- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -868- DISPLAY '////////////////////////////////////////////////' . */
            _.Display($"////////////////////////////////////////////////");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1100-00-FECHAR-ARQUIVOS-SECTION */
        private void R1100_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -877- CLOSE MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -887- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

            /*" -888- MOVE SQLCODE TO RETURN-CODE. */
            _.Move(DB.SQLCODE, RETURN_CODE);

            /*" -889- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], AREA_ABEND.WABEND.WSQLERRD1);

            /*" -890- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], AREA_ABEND.WABEND.WSQLERRD2);

            /*" -891- DISPLAY WABEND. */
            _.Display(AREA_ABEND.WABEND);

            /*" -892- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1);

            /*" -894- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_2);

            /*" -894- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -896- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -900- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -900- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}