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
using Sias.PessoaFisica.DB2.PF0721B;

namespace Code
{
    public class PF0721B
    {
        public bool IsCall { get; set; }

        public PF0721B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------*                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA A CEF STATUS DE DEVOLUCAO DE  *      */
        /*"      *                             PREMIO DE VIDA.                    *      */
        /*"      *   ANALISE/PROGRAMACAO.....  LUIZ CARLOS.                       *      */
        /*"      *   PROGRAMA ...............  PF0721B                            *      */
        /*"      *   DATA ...................  25/01/2007.                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 011                                                  *      */
        /*"      * MOTIVO  : ENVIO DO CODIGO 232 NO REGISTRO TIPO 8. EM VEZ DO 242*      */
        /*"      *           PARA OS PRODUTOS DO RAMO 77                          *      */
        /*"      * JIRA    : 5253                                                 *      */
        /*"      * DATA    : 19/07/2018                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.11                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 10             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 84809        DB2.V10  SELECTS                    *      */
        /*"      *                                                                *      */
        /*"      *                            REGINALDO DA SILVA                  *      */
        /*"      *                            16/09/2013                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - ATENDE CADMUS32886                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/11/2009 - EDILANA CERQUEIRA        PROCURE POR V.09    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CORRIGE CURSOR SIT-REGISTRO = 1 OU 0             *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/08/2009 - LUIZ CARLOS / EDILANA    PROCURE POR V.07    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - ALTERA CURSOR PARA CORRIGIR NUM-PROPOSTA NA      *      */
        /*"      *               GRAVACAO NO ARQUIVO DE STATUS                    *      */
        /*"      *   EM 09/07/2009 - LUIZ CARLOS / EDILANA    PROCURE POR V.07    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - ALTERA CURSOR PARA TRAZER TB CASOS EM QUE O      *      */
        /*"      *               NUM-CERTIFICADO = NUM-SICOB E <> NUM-PROP-SIVPF  *      */
        /*"      *   EM 23/06/2009 - LUIZ CARLOS / EDILANA    PROCURE POR V.06    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - ALTERA CURSOR PARA IGNORAR PRESTAMISTA GITEL     *      */
        /*"      *               (QUE SERA TRATADO SOMENTE NO PF0726B )           *      */
        /*"      *   EM 03/06/2009 - LUIZ CARLOS / EDILANA    PROCURE POR V.05    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - ALTERA SELECT PARA RECUPERAR TAMBEM              *      */
        /*"      *               SEGURO PRESTAMISTA.                              *      */
        /*"      *   EM 07/05/2009 - EDILANA E. CERQUEIRA     PROCURE POR V.04    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - PASSA A DESPREZAR PRODUTOS VIDA DA GENTE (11)    *      */
        /*"      *               COMERCIALIZADOS NA GITEL                         *      */
        /*"      *   EM 05/06/2008 - LUCIA VIEIRA             PROCURE POR V.03    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    PROJETO FGV  (POLITEC)  WELLINGTON VERAS  -  TE39902        *      */
        /*"      *                                                                *      */
        /*"      * 31/10/2008   INCLUIR WITH UR NO COMANDO SELECT      - WV1008   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
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
        /*"01  WS-NUM-APOLICE                   PIC 9(12).*/
        public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
        /*"01  WS-APOLICE.*/
        public PF0721B_WS_APOLICE WS_APOLICE { get; set; } = new PF0721B_WS_APOLICE();
        public class PF0721B_WS_APOLICE : VarBasis
        {
            /*"    03 WS-FONTE-APOL                 PIC 9(02).*/
            public IntBasis WS_FONTE_APOL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03 WS-RAMO-APOL                  PIC 9(02).*/
            public IntBasis WS_RAMO_APOL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03 WS-SEQ-APOL                   PIC 9(08).*/
            public IntBasis WS_SEQ_APOL { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"01  WORK-AREA.*/
        }
        public PF0721B_WORK_AREA WORK_AREA { get; set; } = new PF0721B_WORK_AREA();
        public class PF0721B_WORK_AREA : VarBasis
        {
            /*"    05  W-NUM-PROPOSTA-NOVA           PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FILLER REDEFINES W-NUM-PROPOSTA-NOVA.*/
            private _REDEF_PF0721B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0721B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0721B_FILLER_0(); _.Move(W_NUM_PROPOSTA_NOVA, _filler_0); VarBasis.RedefinePassValue(W_NUM_PROPOSTA_NOVA, _filler_0, W_NUM_PROPOSTA_NOVA); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_NUM_PROPOSTA_NOVA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_NUM_PROPOSTA_NOVA); }
            }  //Redefines
            public class _REDEF_PF0721B_FILLER_0 : VarBasis
            {
                /*"        07  W-NUM-PROPOSTA-ATUAL      PIC 9(013).*/
                public IntBasis W_NUM_PROPOSTA_ATUAL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        07  W-DV-PROPOSTA-NOVA        PIC 9(001).*/
                public IntBasis W_DV_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05 W-LER-PARCELA                 PIC 9(001)   VALUE ZEROS.*/

                public _REDEF_PF0721B_FILLER_0()
                {
                    W_NUM_PROPOSTA_ATUAL.ValueChanged += OnValueChanged;
                    W_DV_PROPOSTA_NOVA.ValueChanged += OnValueChanged;
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
            private _REDEF_PF0721B_DATA_SQL _data_sql { get; set; }
            public _REDEF_PF0721B_DATA_SQL DATA_SQL
            {
                get { _data_sql = new _REDEF_PF0721B_DATA_SQL(); _.Move(DATA_SQL1, _data_sql); VarBasis.RedefinePassValue(DATA_SQL1, _data_sql, DATA_SQL1); _data_sql.ValueChanged += () => { _.Move(_data_sql, DATA_SQL1); }; return _data_sql; }
                set { VarBasis.RedefinePassValue(value, _data_sql, DATA_SQL1); }
            }  //Redefines
            public class _REDEF_PF0721B_DATA_SQL : VarBasis
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

                public _REDEF_PF0721B_DATA_SQL()
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
            private _REDEF_PF0721B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0721B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0721B_FILLER_3(); _.Move(W_DATA_TRABALHO, _filler_3); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_3, W_DATA_TRABALHO); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_DATA_TRABALHO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0721B_FILLER_3 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0721B_FILLER_3()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0721B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0721B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0721B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0721B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0721B_W_DTMOVABE1()
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
            private _REDEF_PF0721B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0721B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0721B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0721B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0721B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0721B_WS_TIME WS_TIME { get; set; } = new PF0721B_WS_TIME();
        public class PF0721B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01             W01DIGCERT.*/
        public PF0721B_W01DIGCERT W01DIGCERT { get; set; } = new PF0721B_W01DIGCERT();
        public class PF0721B_W01DIGCERT : VarBasis
        {
            /*"    05         WCERTIFICADO    PIC  9(015)        VALUE  0.*/
            public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05         WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
            public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
            /*"    05         WDIG            PIC  X(001)  VALUE SPACES.*/
            public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  AREA-ABEND.*/
        }
        public PF0721B_AREA_ABEND AREA_ABEND { get; set; } = new PF0721B_AREA_ABEND();
        public class PF0721B_AREA_ABEND : VarBasis
        {
            /*"    05   WABEND.*/
            public PF0721B_WABEND WABEND { get; set; } = new PF0721B_WABEND();
            public class PF0721B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0721B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0721B  ");
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
            public PF0721B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0721B_LOCALIZA_ABEND_1();
            public class PF0721B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0721B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0721B_LOCALIZA_ABEND_2();
            public class PF0721B_LOCALIZA_ABEND_2 : VarBasis
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
        public PF0721B_CPAGAMENTOS CPAGAMENTOS { get; set; } = new PF0721B_CPAGAMENTOS();
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
            /*" -251- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -253- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -255- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -264- DISPLAY 'PF0721B VERSAO 11 - INICIO PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"PF0721B VERSAO 11 - INICIO PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -265- DISPLAY ' ' */
            _.Display($" ");

            /*" -266- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -267- DISPLAY '*               PROGRAMA PF0721B               *' . */
            _.Display($"*               PROGRAMA PF0721B               *");

            /*" -268- DISPLAY '*  GERA STATUS DE DEVOLUCAO DE PREMIO DE VIDA  *' . */
            _.Display($"*  GERA STATUS DE DEVOLUCAO DE PREMIO DE VIDA  *");

            /*" -270- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -272- PERFORM R0100-00-INICIALIZA. */

            R0100_00_INICIALIZA_SECTION();

            /*" -273- PERFORM R0900-00-DECLARE-PAGAMENTOS. */

            R0900_00_DECLARE_PAGAMENTOS_SECTION();

            /*" -275- PERFORM R0950-00-FETCH-PROPOSTA. */

            R0950_00_FETCH_PROPOSTA_SECTION();

            /*" -276- IF WS-EOR = 1 */

            if (WORK_AREA.WS_EOR == 1)
            {

                /*" -277- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -278- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -279- DISPLAY '*                   PF0721B                    *' */
                _.Display($"*                   PF0721B                    *");

                /*" -280- DISPLAY '*               TERMINO  NORMAL                *' */
                _.Display($"*               TERMINO  NORMAL                *");

                /*" -281- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -282- DISPLAY '*          NAO HOUVE PAGAMENTO NO DIA          *' */
                _.Display($"*          NAO HOUVE PAGAMENTO NO DIA          *");

                /*" -283- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -284- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -286- GO TO R0000-00-FINALIZA. */

                R0000_00_FINALIZA(); //GOTO
                return;
            }


            /*" -288- PERFORM R0150-00-ABRIR-ARQUIVOS. */

            R0150_00_ABRIR_ARQUIVOS_SECTION();

            /*" -290- PERFORM R0200-00-OBTER-MAX-NSAS. */

            R0200_00_OBTER_MAX_NSAS_SECTION();

            /*" -292- PERFORM R0250-00-GERAR-HEADER */

            R0250_00_GERAR_HEADER_SECTION();

            /*" -295- PERFORM R0300-00-PROCESSA-REGISTRO UNTIL WS-EOR = 1. */

            while (!(WORK_AREA.WS_EOR == 1))
            {

                R0300_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -297- PERFORM R0800-00-GERAR-TRAILLER. */

            R0800_00_GERAR_TRAILLER_SECTION();

            /*" -299- PERFORM R0850-00-CONTROLAR-ARQ-ENVIADO */

            R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -301- PERFORM R1000-00-IMPRIMIR-TOTAIS. */

            R1000_00_IMPRIMIR_TOTAIS_SECTION();

            /*" -301- PERFORM R1100-00-FECHAR-ARQUIVOS. */

            R1100_00_FECHAR_ARQUIVOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_00_FINALIZA */

            R0000_00_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-FINALIZA */
        private void R0000_00_FINALIZA(bool isPerform = false)
        {
            /*" -308- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -312- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -312- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-SECTION */
        private void R0100_00_INICIALIZA_SECTION()
        {
            /*" -320- MOVE '0000-PRINCIPAL               ' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL               ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -322- MOVE 'R0100-00-SELECT-SISTEMAS     ' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-SISTEMAS     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -324- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -330- PERFORM R0100_00_INICIALIZA_DB_SELECT_1 */

            R0100_00_INICIALIZA_DB_SELECT_1();

            /*" -333- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -334- DISPLAY 'PF0707B - FIM ANORMAL' */
                _.Display($"PF0707B - FIM ANORMAL");

                /*" -335- DISPLAY '          ERRO ACESSO TABELA SISTEMAS  ' */
                _.Display($"          ERRO ACESSO TABELA SISTEMAS  ");

                /*" -337- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -339- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -340- DISPLAY ' ' */
            _.Display($" ");

            /*" -342- DISPLAY 'DATA DO PROCESSAMENTO: ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA DO PROCESSAMENTO: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -344- DISPLAY ' ' */
            _.Display($" ");

            /*" -346- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.W_DTMOVABE);

            /*" -348- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_DIA_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -350- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_MES_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -353- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WORK_AREA.W_DTMOVABE1.W_ANO_MOVABE, WORK_AREA.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -357- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WORK_AREA.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WORK_AREA.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -365- INITIALIZE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA RT-QTDE-TIPO-2 OF REG-TRAILLER-STA RT-QTDE-TIPO-3 OF REG-TRAILLER-STA RT-QTDE-TIPO-4 OF REG-TRAILLER-STA RT-QTDE-TIPO-5 OF REG-TRAILLER-STA RT-QTDE-TIPO-6 OF REG-TRAILLER-STA RT-QTDE-TIPO-7 OF REG-TRAILLER-STA RT-QTDE-TIPO-8 OF REG-TRAILLER-STA RT-QTDE-TIPO-9 OF REG-TRAILLER-STA. */
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
            /*" -330- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
            /*" -377- MOVE 'R0150-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0150-00-ABRIR-ARQUIVOS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -379- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -379- OPEN OUTPUT MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0200-00-OBTER-MAX-NSAS-SECTION */
        private void R0200_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -389- MOVE 'R0200-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0200-00-OBTER-MAX-NSAS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -391- MOVE 'SELECT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -394- MOVE 'STAPF721' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STAPF721", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -397- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -401- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -414- PERFORM R0200_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0200_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -417- IF SQLCODE EQUAL 00 OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -418- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -419- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -420- DISPLAY '//           PROGRAMA  =>  PF0721B            //' */
                _.Display($"//           PROGRAMA  =>  PF0721B            //");

                /*" -421- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -422- DISPLAY '//             TERMINO - ANORMAL              //' */
                _.Display($"//             TERMINO - ANORMAL              //");

                /*" -423- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -424- DISPLAY '//   ==>  DATA PROCESSADA ANTERIORMENTE <==   //' */
                _.Display($"//   ==>  DATA PROCESSADA ANTERIORMENTE <==   //");

                /*" -425- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -427- DISPLAY '// ARQSIVPF-SIGLA-ARQUIVO      = ' ARQSIVPF-SIGLA-ARQUIVO */
                _.Display($"// ARQSIVPF-SIGLA-ARQUIVO      = {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -429- DISPLAY '// ARQSIVPF-SISTEMA-ORIGEM     = ' ARQSIVPF-SISTEMA-ORIGEM */
                _.Display($"// ARQSIVPF-SISTEMA-ORIGEM     = {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM}");

                /*" -431- DISPLAY '// ARQSIVPF-DATA-PROCESSAMENTO = ' ARQSIVPF-DATA-PROCESSAMENTO */
                _.Display($"// ARQSIVPF-DATA-PROCESSAMENTO = {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO}");

                /*" -433- DISPLAY '// ARQSIVPF-DATA-GERACAO       = ' ARQSIVPF-DATA-GERACAO */
                _.Display($"// ARQSIVPF-DATA-GERACAO       = {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -434- DISPLAY '//' */
                _.Display($"//");

                /*" -439- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -440- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -441- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -442- ELSE */
            }
            else
            {


                /*" -443- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -444- DISPLAY 'PF0721B - FIM ANORMAL' */
                    _.Display($"PF0721B - FIM ANORMAL");

                    /*" -445- DISPLAY '          ERRO SELECT ARQUIVOS-SIVPF' */
                    _.Display($"          ERRO SELECT ARQUIVOS-SIVPF");

                    /*" -447- DISPLAY '          SQLCODE....................... ' SQLCODE */
                    _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                    /*" -448- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -450- PERFORM R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION();
                }

            }


            /*" -452- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -461- PERFORM R0200_00_OBTER_MAX_NSAS_DB_SELECT_2 */

            R0200_00_OBTER_MAX_NSAS_DB_SELECT_2();

            /*" -464- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -465- DISPLAY 'PF0721B - FIM ANORMAL' */
                _.Display($"PF0721B - FIM ANORMAL");

                /*" -466- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -468- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -469- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -471- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -471- ADD 1 TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.Value = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF + 1;

        }

        [StopWatch]
        /*" R0200-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0200_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -414- EXEC SQL SELECT NSAS_SIVPF INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM AND DATA_PROCESSAMENTO = :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO AND DATA_GERACAO = :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO WITH UR END-EXEC. */

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
            /*" -461- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

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
            /*" -481- MOVE 'R0250-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0250-00-GERAR-HEADER", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -483- MOVE 'WRITE REG-HEADER-STA' TO COMANDO. */
            _.Move("WRITE REG-HEADER-STA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -485- MOVE SPACES TO REG-HEADER-STA. */
            _.Move("", LBFCT011.REG_HEADER_STA);

            /*" -488- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -491- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -493- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.W_DTMOVABE);

            /*" -494- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_DIA_MOVABE, WORK_AREA.FILLER_3.W_DIA_TRABALHO);

            /*" -495- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_MES_MOVABE, WORK_AREA.FILLER_3.W_MES_TRABALHO);

            /*" -497- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WORK_AREA.W_DTMOVABE1.W_ANO_MOVABE, WORK_AREA.FILLER_3.W_ANO_TRABALHO);

            /*" -500- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Move(WORK_AREA.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -503- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -506- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -509- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER-STA */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_HEADER_STA.RH_NSAS);

            /*" -509- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0300-00-PROCESSA-REGISTRO-SECTION */
        private void R0300_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -520- MOVE ZERO TO W-PROPOSTA-CADASTRADA */
            _.Move(0, WORK_AREA.W_PROPOSTA_CADASTRADA);

            /*" -522- INITIALIZE R8-PONTUACAO-SIDEM. */
            _.Initialize(
                LBFPF025.R8_PONTUACAO_SIDEM
            );

            /*" -524- PERFORM R0320-00-TRATA-CERTIFICADO */

            R0320_00_TRATA_CERTIFICADO_SECTION();

            /*" -524- PERFORM R0350-00-GERAR-REGISTRO-PGTO. */

            R0350_00_GERAR_REGISTRO_PGTO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0300_10_LE_OUTRO */

            R0300_10_LE_OUTRO();

        }

        [StopWatch]
        /*" R0300-10-LE-OUTRO */
        private void R0300_10_LE_OUTRO(bool isPerform = false)
        {
            /*" -528- PERFORM R0950-00-FETCH-PROPOSTA. */

            R0950_00_FETCH_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-TRATA-CERTIFICADO-SECTION */
        private void R0320_00_TRATA_CERTIFICADO_SECTION()
        {
            /*" -538- MOVE 'R0320-00-TRATA-CERTIFICADO' TO PARAGRAFO. */
            _.Move("R0320-00-TRATA-CERTIFICADO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -540- MOVE ' ' TO COMANDO. */
            _.Move(" ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -542- IF HISCONPA-NUM-CERTIFICADO NOT LESS 10000000000 AND HISCONPA-NUM-CERTIFICADO NOT GREATER 19999999999 */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO >= 10000000000 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO <= 19999999999)
            {

                /*" -546- MOVE HISCONPA-NUM-CERTIFICADO TO WCERTIFICADO W-NUM-PROPOSTA-ATUAL */
                _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, W01DIGCERT.WCERTIFICADO, WORK_AREA.FILLER_0.W_NUM_PROPOSTA_ATUAL);

                /*" -548- MOVE 'CALL PROM1101' TO COMANDO */
                _.Move("CALL PROM1101", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -550- CALL 'PROM1101' USING W01DIGCERT */
                _.Call("PROM1101", W01DIGCERT);

                /*" -551- MOVE WDIG TO W-DV-PROPOSTA-NOVA */
                _.Move(W01DIGCERT.WDIG, WORK_AREA.FILLER_0.W_DV_PROPOSTA_NOVA);

                /*" -552- ELSE */
            }
            else
            {


                /*" -553- MOVE HISCONPA-NUM-CERTIFICADO TO W-NUM-PROPOSTA-NOVA. */
                _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO, WORK_AREA.W_NUM_PROPOSTA_NOVA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_SAIDA*/

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

            /*" -571- MOVE 8 TO R8-IDENTIFICACAO */
            _.Move(8, LBFPF025.R8_PONTUACAO_SIDEM.R8_IDENTIFICACAO);

            /*" -573- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R8-NUM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PROPOSTA);

            /*" -575- MOVE ZEROS TO R8-VLR-ESTOQUE. */
            _.Move(0, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_ESTOQUE);

            /*" -578- COMPUTE R8-VLR-LANCAMENTO = HISCONPA-PREMIO-VG + HISCONPA-PREMIO-AP */
            LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO.Value = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG + HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP;

            /*" -580- MOVE HISCONPA-NUM-PARCELA TO R8-NUM-PARCELA */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PARCELA);

            /*" -582- MOVE 242 TO R8-TP-LANCAMENTO. */
            _.Move(242, LBFPF025.R8_PONTUACAO_SIDEM.R8_TP_LANCAMENTO);

            /*" -583- IF WS-RAMO-APOL = 77 */

            if (WS_APOLICE.WS_RAMO_APOL == 77)
            {

                /*" -584- MOVE 232 TO R8-TP-LANCAMENTO */
                _.Move(232, LBFPF025.R8_PONTUACAO_SIDEM.R8_TP_LANCAMENTO);

                /*" -586- END-IF */
            }


            /*" -588- WRITE REG-STA-SASSE FROM R8-PONTUACAO-SIDEM. */
            _.Move(LBFPF025.R8_PONTUACAO_SIDEM.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -588- ADD 1 TO W-QTD-LD-TIPO-8. */
            WORK_AREA.W_QTD_LD_TIPO_8.Value = WORK_AREA.W_QTD_LD_TIPO_8 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R0800-00-GERAR-TRAILLER-SECTION */
        private void R0800_00_GERAR_TRAILLER_SECTION()
        {
            /*" -598- MOVE 'R0800-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R0800-00-GERAR-TRAILLER", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -600- MOVE 'WRITE REG-TRAILLER-STA' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER-STA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -602- MOVE SPACES TO REG-TRAILLER-STA. */
            _.Move("", LBFCT011.REG_TRAILLER_STA);

            /*" -605- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -608- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -611- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER-STA */
            _.Move(WORK_AREA.W_QTD_LD_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8);

            /*" -622- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -631- MOVE ZEROS TO RT-QTDE-TIPO-1 RT-QTDE-TIPO-2 RT-QTDE-TIPO-3 RT-QTDE-TIPO-5 RT-QTDE-TIPO-6 RT-QTDE-TIPO-7 RT-QTDE-TIPO-8 RT-QTDE-TIPO-9. */
            _.Move(0, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9);

            /*" -631- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -640- MOVE 'R0850-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R0850-00-CONTROLAR-ARQ-ENVIADO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -642- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -645- MOVE 'STAPF721' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STAPF721", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -648- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -652- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -655- MOVE RT-QTDE-TIPO-8 OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -663- PERFORM R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -666- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -667- DISPLAY 'PF0721B - FIM ANORMAL' */
                _.Display($"PF0721B - FIM ANORMAL");

                /*" -668- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -670- DISPLAY '          SIGLA DO ARQUIVO..............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQUIVO..............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -672- DISPLAY '          SISTEMA DE ORIGEM.............  ' ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF */
                _.Display($"          SISTEMA DE ORIGEM.............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM}");

                /*" -674- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -676- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -678- DISPLAY '          QTDE DE REGISTROS.............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE DE REGISTROS.............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -679- PERFORM R1100-00-FECHAR-ARQUIVOS */

                R1100_00_FECHAR_ARQUIVOS_SECTION();

                /*" -679- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -663- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
            /*" -689- MOVE 'R0900-00-DECLARE-PAGAMENTOS ' TO PARAGRAFO. */
            _.Move("R0900-00-DECLARE-PAGAMENTOS ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -691- MOVE 'DECLARE CPAGAMENTOS         ' TO COMANDO. */
            _.Move("DECLARE CPAGAMENTOS         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -757- PERFORM R0900_00_DECLARE_PAGAMENTOS_DB_DECLARE_1 */

            R0900_00_DECLARE_PAGAMENTOS_DB_DECLARE_1();

            /*" -761- MOVE 'OPEN CPAGAMENTOS                     ' TO COMANDO. */
            _.Move("OPEN CPAGAMENTOS                     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -761- PERFORM R0900_00_DECLARE_PAGAMENTOS_DB_OPEN_1 */

            R0900_00_DECLARE_PAGAMENTOS_DB_OPEN_1();

            /*" -764- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -765- DISPLAY 'PF0721B - FIM ANORMAL' */
                _.Display($"PF0721B - FIM ANORMAL");

                /*" -766- DISPLAY '          ERRO OPEN CURSOR CPAGAMENTOS   ' */
                _.Display($"          ERRO OPEN CURSOR CPAGAMENTOS   ");

                /*" -768- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -768- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PAGAMENTOS-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PAGAMENTOS_DB_DECLARE_1()
        {
            /*" -757- EXEC SQL DECLARE CPAGAMENTOS CURSOR FOR SELECT A.NUM_APOLICE , A.COD_SUBGRUPO , A.NUM_CERTIFICADO, A.NUM_PARCELA , A.PREMIO_VG , A.PREMIO_AP , A.OCORR_HISTORICO, A.COD_OPERACAO , B.NUM_PROPOSTA_SIVPF FROM SEGUROS.HIST_CONT_PARCELVA A, SEGUROS.PROPOSTA_FIDELIZ B WHERE A.NUM_APOLICE NOT IN (109300001662, 109300001664, 109300001666, 107700000014) AND A.NUM_CERTIFICADO = B.NUM_PROPOSTA_SIVPF AND B.COD_EMPRESA_SIVPF = 1 AND B.CANAL_PROPOSTA <> 5 AND A.NUM_PARCELA > 0 AND A.COD_OPERACAO >= 500 AND A.COD_OPERACAO <= 599 AND A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.SIT_REGISTRO IN ( '1' , '0' ) UNION SELECT A.NUM_APOLICE , A.COD_SUBGRUPO , A.NUM_CERTIFICADO, A.NUM_PARCELA , A.PREMIO_VG , A.PREMIO_AP , A.OCORR_HISTORICO, A.COD_OPERACAO , B.NUM_PROPOSTA_SIVPF FROM SEGUROS.HIST_CONT_PARCELVA A, SEGUROS.PROPOSTA_FIDELIZ B WHERE A.NUM_APOLICE NOT IN (109300001662, 109300001664, 109300001666, 107700000014) AND A.NUM_CERTIFICADO = B.NUM_SICOB AND B.COD_EMPRESA_SIVPF = 1 AND B.CANAL_PROPOSTA <> 5 AND A.NUM_PARCELA > 0 AND A.COD_OPERACAO >= 500 AND A.COD_OPERACAO <= 599 AND A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.SIT_REGISTRO IN ( '1' , '0' ) GROUP BY A.NUM_APOLICE , A.COD_SUBGRUPO , A.NUM_CERTIFICADO, A.NUM_PARCELA , A.PREMIO_VG , A.PREMIO_AP , A.OCORR_HISTORICO, A.COD_OPERACAO , B.NUM_PROPOSTA_SIVPF ORDER BY 1, 2, 3, 4, 5, 6, 7, 8, 9 WITH UR END-EXEC. */
            CPAGAMENTOS = new PF0721B_CPAGAMENTOS(true);
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
							A.PREMIO_VG
							, 
							A.PREMIO_AP
							, 
							A.OCORR_HISTORICO
							, 
							A.COD_OPERACAO
							, 
							B.NUM_PROPOSTA_SIVPF 
							FROM SEGUROS.HIST_CONT_PARCELVA A
							, 
							SEGUROS.PROPOSTA_FIDELIZ B 
							WHERE A.NUM_APOLICE NOT IN (109300001662
							, 
							109300001664
							, 
							109300001666
							, 
							107700000014) 
							AND A.NUM_CERTIFICADO = B.NUM_PROPOSTA_SIVPF 
							AND B.COD_EMPRESA_SIVPF = 1 
							AND B.CANAL_PROPOSTA <> 5 
							AND A.NUM_PARCELA > 0 
							AND A.COD_OPERACAO >= 500 
							AND A.COD_OPERACAO <= 599 
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
							A.PREMIO_VG
							, 
							A.PREMIO_AP
							, 
							A.OCORR_HISTORICO
							, 
							A.COD_OPERACAO
							, 
							B.NUM_PROPOSTA_SIVPF 
							FROM SEGUROS.HIST_CONT_PARCELVA A
							, 
							SEGUROS.PROPOSTA_FIDELIZ B 
							WHERE A.NUM_APOLICE NOT IN (109300001662
							, 
							109300001664
							, 
							109300001666
							, 
							107700000014) 
							AND A.NUM_CERTIFICADO = B.NUM_SICOB 
							AND B.COD_EMPRESA_SIVPF = 1 
							AND B.CANAL_PROPOSTA <> 5 
							AND A.NUM_PARCELA > 0 
							AND A.COD_OPERACAO >= 500 
							AND A.COD_OPERACAO <= 599 
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
							A.PREMIO_VG
							, 
							A.PREMIO_AP
							, 
							A.OCORR_HISTORICO
							, 
							A.COD_OPERACAO
							, 
							B.NUM_PROPOSTA_SIVPF 
							ORDER BY 1
							, 2
							, 3
							, 4
							, 5
							, 6
							, 7
							, 8
							, 9";

                return query;
            }
            CPAGAMENTOS.GetQueryEvent += GetQuery_CPAGAMENTOS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PAGAMENTOS-DB-OPEN-1 */
        public void R0900_00_DECLARE_PAGAMENTOS_DB_OPEN_1()
        {
            /*" -761- EXEC SQL OPEN CPAGAMENTOS END-EXEC. */

            CPAGAMENTOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-SECTION */
        private void R0950_00_FETCH_PROPOSTA_SECTION()
        {
            /*" -779- MOVE 'R0950-00-FETCH-PROPOSTA     ' TO PARAGRAFO. */
            _.Move("R0950-00-FETCH-PROPOSTA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -781- MOVE 'FETCH CPAGAMENTOS           ' TO COMANDO. */
            _.Move("FETCH CPAGAMENTOS           ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -792- PERFORM R0950_00_FETCH_PROPOSTA_DB_FETCH_1 */

            R0950_00_FETCH_PROPOSTA_DB_FETCH_1();

            /*" -795- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -795- PERFORM R0950_00_FETCH_PROPOSTA_DB_CLOSE_1 */

                R0950_00_FETCH_PROPOSTA_DB_CLOSE_1();

                /*" -797- MOVE 1 TO WS-EOR */
                _.Move(1, WORK_AREA.WS_EOR);

                /*" -798- GO TO R0950-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/ //GOTO
                return;

                /*" -799- ELSE */
            }
            else
            {


                /*" -801- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

                if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
                {

                    /*" -802- DISPLAY 'PF0721B - FIM ANORMAL' */
                    _.Display($"PF0721B - FIM ANORMAL");

                    /*" -803- DISPLAY '          ERRO FETCH CURSOR CPAGAMENTOS   ' */
                    _.Display($"          ERRO FETCH CURSOR CPAGAMENTOS   ");

                    /*" -805- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -806- PERFORM R1100-00-FECHAR-ARQUIVOS */

                    R1100_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -807- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -808- ELSE */
                }
                else
                {


                    /*" -809- ADD 1 TO AC-L-MOVIMENTO AC-CONTROLE */
                    WORK_AREA.AC_L_MOVIMENTO.Value = WORK_AREA.AC_L_MOVIMENTO + 1;
                    WORK_AREA.AC_CONTROLE.Value = WORK_AREA.AC_CONTROLE + 1;

                    /*" -810- MOVE HISCONPA-NUM-APOLICE TO WS-NUM-APOLICE */
                    _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE, WS_NUM_APOLICE);

                    /*" -812- MOVE WS-NUM-APOLICE TO WS-APOLICE */
                    _.Move(WS_NUM_APOLICE, WS_APOLICE);

                    /*" -813- IF AC-CONTROLE GREATER 999 */

                    if (WORK_AREA.AC_CONTROLE > 999)
                    {

                        /*" -814- ACCEPT WS-TIME FROM TIME */
                        _.Move(_.AcceptDate("TIME"), WS_TIME);

                        /*" -815- MOVE WS-TIME-N TO WS-TIME-EDIT */
                        _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

                        /*" -816- DISPLAY ' ' */
                        _.Display($" ");

                        /*" -819- DISPLAY 'PF0721B - TOTAL LIDO ' AC-L-MOVIMENTO '  HORAS  ' WS-TIME-EDIT */

                        $"PF0721B - TOTAL LIDO {WORK_AREA.AC_L_MOVIMENTO}  HORAS  {WS_TIME_EDIT}"
                        .Display();

                        /*" -819- MOVE ZEROS TO AC-CONTROLE. */
                        _.Move(0, WORK_AREA.AC_CONTROLE);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-DB-FETCH-1 */
        public void R0950_00_FETCH_PROPOSTA_DB_FETCH_1()
        {
            /*" -792- EXEC SQL FETCH CPAGAMENTOS INTO :HISCONPA-NUM-APOLICE , :HISCONPA-COD-SUBGRUPO , :HISCONPA-NUM-CERTIFICADO, :HISCONPA-NUM-PARCELA , :HISCONPA-PREMIO-VG , :HISCONPA-PREMIO-AP , :HISCONPA-OCORR-HISTORICO, :HISCONPA-COD-OPERACAO , :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

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
                _.Move(CPAGAMENTOS.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }

        }

        [StopWatch]
        /*" R0950-00-FETCH-PROPOSTA-DB-CLOSE-1 */
        public void R0950_00_FETCH_PROPOSTA_DB_CLOSE_1()
        {
            /*" -795- EXEC SQL CLOSE CPAGAMENTOS END-EXEC */

            CPAGAMENTOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-IMPRIMIR-TOTAIS-SECTION */
        private void R1000_00_IMPRIMIR_TOTAIS_SECTION()
        {
            /*" -829- MOVE 'R0870-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R0870-00-GERAR-TOTIAS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -831- MOVE ' ' TO COMANDO. */
            _.Move(" ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -832- DISPLAY ' ' */
            _.Display($" ");

            /*" -833- DISPLAY '////////////////////////////////////////////////' */
            _.Display($"////////////////////////////////////////////////");

            /*" -834- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -835- DISPLAY '//           PROGRAMA  =>  PF0721B            //' */
            _.Display($"//           PROGRAMA  =>  PF0721B            //");

            /*" -836- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -837- DISPLAY '//             TERMINO - NORMAL               //' */
            _.Display($"//             TERMINO - NORMAL               //");

            /*" -838- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -840- DISPLAY '//   TOTAL REGISTROS LIDOS........ ' AC-L-MOVIMENTO '     //' */

            $"//   TOTAL REGISTROS LIDOS........ {WORK_AREA.AC_L_MOVIMENTO}     //"
            .Display();

            /*" -842- DISPLAY '//   TOTAL GERADO ARQ. STATUS..... ' W-QTD-LD-TIPO-8 '     //' */

            $"//   TOTAL GERADO ARQ. STATUS..... {WORK_AREA.W_QTD_LD_TIPO_8}     //"
            .Display();

            /*" -843- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -843- DISPLAY '////////////////////////////////////////////////' . */
            _.Display($"////////////////////////////////////////////////");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1100-00-FECHAR-ARQUIVOS-SECTION */
        private void R1100_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -852- CLOSE MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -862- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

            /*" -863- MOVE SQLCODE TO RETURN-CODE. */
            _.Move(DB.SQLCODE, RETURN_CODE);

            /*" -864- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], AREA_ABEND.WABEND.WSQLERRD1);

            /*" -865- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], AREA_ABEND.WABEND.WSQLERRD2);

            /*" -866- DISPLAY WABEND. */
            _.Display(AREA_ABEND.WABEND);

            /*" -867- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1);

            /*" -869- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_2);

            /*" -869- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -871- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -875- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -875- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}