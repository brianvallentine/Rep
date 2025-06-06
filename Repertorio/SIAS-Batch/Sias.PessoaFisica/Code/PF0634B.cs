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
using Sias.PessoaFisica.DB2.PF0634B;

namespace Code
{
    public class PF0634B
    {
        public bool IsCall { get; set; }

        public PF0634B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ...............  PROCESSAR REABILITACAO DE BILHETE.   *      */
        /*"      *   ANALISE/PROGRAMACAO...  LUIZ CARLOS.                         *      */
        /*"      *   PROGRAMA .............  PF0634B                              *      */
        /*"      *   DATA .................  16/10/2002.                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 05             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA                          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 04             INCLUIR A CONDICAO DE ORIGEM <> 1001     *      */
        /*"      * ATENDE CADMUS 49336                                            *      */
        /*"      *                                                                *      */
        /*"      * PROCURE C49336        REGINALDO SILVA                          *      */
        /*"      *                       26/10/2010                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 03                                                      *      */
        /*"      *   ATUALIZACOES - TRATAR O  ATRIBUTO PCT-IOCC  DA               *      */
        /*"      *   ------------   DCLBILHETE-COBERTURA  QUANDO NAO NUMERICO     *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/04/2006: LUCIA VIEIRA               PROCURE POR V.02   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 02                                                      *      */
        /*"      *   ATUALIZACOES - GRAVAR NUM-ARQUIVO NA SEGUROS.ARQUIVOS_SIVPF  *      */
        /*"      *   ------------   E ATUALIZAR NO FINAL DO PROCESSAMENTO A QTDE  *      */
        /*"      *                  DE REGISTROS PROCESSADOS.                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/07/2006: LUCIA VIEIRA              PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 01                                                      *      */
        /*"      *   ATUALIZACOES - TRATAR O MOVIMENTO DE RETORNO DO FACIL        *      */
        /*"      *   ------------   AP COMERCIALIZADO NO CANAL ATM DA CAIXA.      *      */
        /*"      *                                                                *      */
        /*"      *   SOLICITACAO VIA:CADMUS 39258                                 *      */
        /*"      *   EM 17/03/2010  :EDSON MARQUES             PROCURE POR V.04   *      */
        /*"      *   OBSERVACAO.........DEVIDO A PROBLEMAS DE DCLEGENS ENTRE OS   *      */
        /*"      *                      AMBIENTES,TIVEMOS QUE MUDAR ALGUMAS ESTRU-*      */
        /*"      *                      TURAS DE ACESSO AS TABELAS  PARA ESSAS    *      */
        /*"      *                      ALTERACOES PROCURAR POR            V.99   *      */
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
        /*"01   REG-STA-SASSE                      PIC X(100).*/
        public StringBasis REG_STA_SASSE { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WAREA-AUXILIAR.*/
        public PF0634B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0634B_WAREA_AUXILIAR();
        public class PF0634B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-MOVTO-FIDELIZ           PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-BILHETE-COB             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_BILHETE_COB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-ERROS-VDZ               PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_ERROS_VDZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-BILHETE-ERROS           PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_BILHETE_ERROS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-IND-IOF                     PIC S9(01)V9(4) COMP-3.*/
            public DoubleBasis W_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(01)V9(4)"), 4);
            /*"    05  W-TIME                        PIC  9(08).*/
            public IntBasis W_TIME { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    05  W-TIME-EDIT                   PIC  99.99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"    05  W-CONTROLE                    PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-REG-BIL-AP                  PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_REG_BIL_AP { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-PRM-LIQ                     PIC  9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_PRM_LIQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
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
            /*"    05  W-ABEND-CTR                   PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_ABEND_CTR { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-LIDO-VIDA                   PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_LIDO_VIDA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-LIDO-BIL-AP                 PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_LIDO_BIL_AP { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-LIDO-BIL-RD                 PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_LIDO_BIL_RD { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-TOT-GERADO-STA              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_TOT_GERADO_STA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-BILHETE-LIDO                PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_BILHETE_LIDO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-COD-COBERTURA               PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER REDEFINES W-COD-COBERTURA.*/
            private _REDEF_PF0634B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0634B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0634B_FILLER_0(); _.Move(W_COD_COBERTURA, _filler_0); VarBasis.RedefinePassValue(W_COD_COBERTURA, _filler_0, W_COD_COBERTURA); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_COD_COBERTURA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_COD_COBERTURA); }
            }  //Redefines
            public class _REDEF_PF0634B_FILLER_0 : VarBasis
            {
                /*"        10  W-SUBPRODUTO              PIC 9(003).*/
                public IntBasis W_SUBPRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        10  W-COBERTURA               PIC 9(001).*/
                public IntBasis W_COBERTURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-NSAS                        PIC 9(006).*/

                public _REDEF_PF0634B_FILLER_0()
                {
                    W_SUBPRODUTO.ValueChanged += OnValueChanged;
                    W_COBERTURA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSL                         PIC 9(006).*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-DATA-SITUACAO               PIC  X(010).*/
            public StringBasis W_DATA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0634B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0634B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0634B_FILLER_1(); _.Move(W_DATA_TRABALHO, _filler_1); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_1, W_DATA_TRABALHO); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_DATA_TRABALHO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0634B_FILLER_1 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0634B_FILLER_1()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0634B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0634B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0634B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0634B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0634B_W_DTMOVABE1()
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
            private _REDEF_PF0634B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0634B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0634B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0634B_W_DTMOVABE_I1 : VarBasis
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
                /*"    05  W-TIMESTAMP                   PIC X(026)  VALUE SPACES.*/

                public _REDEF_PF0634B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
            /*"    05  FILLER REDEFINES W-TIMESTAMP.*/
            private _REDEF_PF0634B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0634B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0634B_FILLER_2(); _.Move(W_TIMESTAMP, _filler_2); VarBasis.RedefinePassValue(W_TIMESTAMP, _filler_2, W_TIMESTAMP); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_TIMESTAMP); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_TIMESTAMP); }
            }  //Redefines
            public class _REDEF_PF0634B_FILLER_2 : VarBasis
            {
                /*"        07  W-DT-TIMESTAMP            PIC X(010).*/
                public StringBasis W_DT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"        07  W-HH-TIMESTAMP            PIC X(016).*/
                public StringBasis W_HH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
                /*"    05  W-DATA-SQL                    PIC X(010).*/

                public _REDEF_PF0634B_FILLER_2()
                {
                    W_DT_TIMESTAMP.ValueChanged += OnValueChanged;
                    W_HH_TIMESTAMP.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_PF0634B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0634B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0634B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0634B_W_DATA_SQL1 : VarBasis
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
                /*"    05 W-PRODUTO                      PIC  9(002) VALUE ZEROS.*/

                public _REDEF_PF0634B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_PRODUTO { get; set; } = new SelectorBasis("002", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 MULTIPREMIADO                           VALUE 01. */
							new SelectorItemBasis("MULTIPREMIADO", "01"),
							/*" 88 FEDPREV                                 VALUE 02. */
							new SelectorItemBasis("FEDPREV", "02"),
							/*" 88 FEDECAP                                 VALUE 03. */
							new SelectorItemBasis("FEDECAP", "03"),
							/*" 88 EXECUTIVO                               VALUE 04. */
							new SelectorItemBasis("EXECUTIVO", "04"),
							/*" 88 FEDPREV-CRESCER                         VALUE 05. */
							new SelectorItemBasis("FEDPREV_CRESCER", "05"),
							/*" 88 FEDPREV-PGTO-UNICO                      VALUE 06. */
							new SelectorItemBasis("FEDPREV_PGTO_UNICO", "06"),
							/*" 88 SENIOR                                  VALUE 07. */
							new SelectorItemBasis("SENIOR", "07"),
							/*" 88 FEDPREV-ECONOMIARIO                     VALUE 08. */
							new SelectorItemBasis("FEDPREV_ECONOMIARIO", "08"),
							/*" 88 BILHETE-AP                              VALUE 09. */
							new SelectorItemBasis("BILHETE_AP", "09"),
							/*" 88 BILHETE-RD                              VALUE 10. */
							new SelectorItemBasis("BILHETE_RD", "10"),
							/*" 88 FEDERALCAP-CX-TRAB                      VALUE 11. */
							new SelectorItemBasis("FEDERALCAP_CX_TRAB", "11"),
							/*" 88 MULTIPREMIADO-SUPER                     VALUE 13. */
							new SelectorItemBasis("MULTIPREMIADO_SUPER", "13")
                }
            };

            /*"01  W-VINDICADORAS.*/
        }
        public PF0634B_W_VINDICADORAS W_VINDICADORAS { get; set; } = new PF0634B_W_VINDICADORAS();
        public class PF0634B_W_VINDICADORAS : VarBasis
        {
            /*"    05 VIND-DT-RCAP                   PIC S9(004) COMP  VALUE +0*/
            public IntBasis VIND_DT_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  WABEND*/
        }
        public PF0634B_WABEND WABEND { get; set; } = new PF0634B_WABEND();
        public class PF0634B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0634B_FILLER_3 FILLER_3 { get; set; } = new PF0634B_FILLER_3();
            public class PF0634B_FILLER_3 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0634B  '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0634B  ");
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
            public PF0634B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0634B_LOCALIZA_ABEND_1();
            public class PF0634B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0634B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0634B_LOCALIZA_ABEND_2();
            public class PF0634B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.BILCOBER BILCOBER { get; set; } = new Dclgens.BILCOBER();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.PROPSSBI PROPSSBI { get; set; } = new Dclgens.PROPSSBI();
        public Dclgens.PROPFID PROPFID { get; set; } = new Dclgens.PROPFID();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public PF0634B_PROPOSTA_FIDELIZ PROPOSTA_FIDELIZ { get; set; } = new PF0634B_PROPOSTA_FIDELIZ();
        public PF0634B_BILHETE_COBERTURA BILHETE_COBERTURA { get; set; } = new PF0634B_BILHETE_COBERTURA();
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
            /*" -287- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -288- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -289- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -292- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -293- DISPLAY '*               PROGRAMA PF0634B               *' . */
            _.Display($"*               PROGRAMA PF0634B               *");

            /*" -294- DISPLAY '*       PROCESSAR REABILITACAO DE BILHETE      *' . */
            _.Display($"*       PROCESSAR REABILITACAO DE BILHETE      *");

            /*" -295- DISPLAY '*           VERSAO:  05 - 29/11/2013           *' . */
            _.Display($"*           VERSAO:  05 - 29/11/2013           *");

            /*" -296- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -305- DISPLAY '*  PF0634B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0634B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -306- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -309- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -311- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -313- PERFORM R0007-00-OBTER-DT-PROCE. */

            R0007_00_OBTER_DT_PROCE_SECTION();

            /*" -315- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -317- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -319- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -321- PERFORM R0070-00-LER-MOVTO */

            R0070_00_LER_MOVTO_SECTION();

            /*" -322- IF W-FIM-MOVTO-FIDELIZ EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM")
            {

                /*" -323- DISPLAY '*----------------------------------*' */
                _.Display($"*----------------------------------*");

                /*" -324- DISPLAY '*  NAO HOUVE MOVIMENTO NESTA DATA  *' */
                _.Display($"*  NAO HOUVE MOVIMENTO NESTA DATA  *");

                /*" -325- DISPLAY '*----------------------------------*' */
                _.Display($"*----------------------------------*");

                /*" -326- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -328- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -330- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -333- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-FIDELIZ EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -335- PERFORM R0800-00-GERAR-TRAILLER. */

            R0800_00_GERAR_TRAILLER_SECTION();

            /*" -337- PERFORM R0850-00-CONTROLAR-ARQ-ENVIADO */

            R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -339- PERFORM R0870-00-GERAR-TOTAIS. */

            R0870_00_GERAR_TOTAIS_SECTION();

            /*" -341- PERFORM R1110-00-UPDATE-RELATORIOS. */

            R1110_00_UPDATE_RELATORIOS_SECTION();

            /*" -343- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -344- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -346- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -349- DISPLAY '** PF0634B ** FIM    PROCESSAMENTO - HORA....  ' W-TIME-EDIT. */
            _.Display($"** PF0634B ** FIM    PROCESSAMENTO - HORA....  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -349- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -357- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -362- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -364- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -370- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -375- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -377- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -379- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -382- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -384- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -370- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
        /*" R0007-00-OBTER-DT-PROCE-SECTION */
        private void R0007_00_OBTER_DT_PROCE_SECTION()
        {
            /*" -394- MOVE 'R0007-00-OBTER-DT-PROCE' TO PARAGRAFO. */
            _.Move("R0007-00-OBTER-DT-PROCE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -399- MOVE 'SELECT SEGUROS.RELATORIOS' TO COMANDO. */
            _.Move("SELECT SEGUROS.RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -406- PERFORM R0007_00_OBTER_DT_PROCE_DB_SELECT_1 */

            R0007_00_OBTER_DT_PROCE_DB_SELECT_1();

            /*" -409- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -410- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -411- DISPLAY '          ERRO SELECT RELATORIOS' */
                _.Display($"          ERRO SELECT RELATORIOS");

                /*" -413- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -415- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -418- MOVE RELATORI-DATA-REFERENCIA OF DCLRELATORIOS TO W-DT-TIMESTAMP. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA, WAREA_AUXILIAR.FILLER_2.W_DT_TIMESTAMP);

            /*" -420- MOVE '-00.00.00.000000' TO W-HH-TIMESTAMP. */
            _.Move("-00.00.00.000000", WAREA_AUXILIAR.FILLER_2.W_HH_TIMESTAMP);

            /*" -423- MOVE W-TIMESTAMP TO RELATORI-TIMESTAMP OF DCLRELATORIOS. */
            _.Move(WAREA_AUXILIAR.W_TIMESTAMP, RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP);

            /*" -424- DISPLAY '*  PF0634B - DATA REF PROCESSAMENTO ' RELATORI-DATA-REFERENCIA OF DCLRELATORIOS. */
            _.Display($"*  PF0634B - DATA REF PROCESSAMENTO {RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}");

        }

        [StopWatch]
        /*" R0007-00-OBTER-DT-PROCE-DB-SELECT-1 */
        public void R0007_00_OBTER_DT_PROCE_DB_SELECT_1()
        {
            /*" -406- EXEC SQL SELECT DATA_REFERENCIA INTO :DCLRELATORIOS.RELATORI-DATA-REFERENCIA FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0634B' WITH UR END-EXEC. */

            var r0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 = new R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1.Execute(r0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0007_SAIDA*/

        [StopWatch]
        /*" R0010-00-ABRIR-ARQUIVOS-SECTION */
        private void R0010_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -434- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -436- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -436- OPEN OUTPUT MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -446- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -448- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -451- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -454- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -463- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -466- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -467- DISPLAY 'PF0634B - FIM ANORMAL' */
                _.Display($"PF0634B - FIM ANORMAL");

                /*" -468- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -470- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -471- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -473- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -476- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -477- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -479- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -482- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -485- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -489- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -498- PERFORM R0020_00_OBTER_MAX_NSAS_DB_INSERT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_INSERT_1();

            /*" -501- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -502- DISPLAY 'PF0634B - FIM ANORMAL' */
                _.Display($"PF0634B - FIM ANORMAL");

                /*" -503- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -505- DISPLAY '          SIGLA DO ARQUIVO..............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQUIVO..............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -507- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -509- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -512- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -514- MOVE SPACES TO W-FIM-MOVTO-FIDELIZ */
                _.Move("", WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ);

                /*" -515- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -516- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -516- END-IF. */
            }


        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -463- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

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

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-INSERT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_INSERT_1()
        {
            /*" -498- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO , :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF , :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO , 0 , :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r0020_00_OBTER_MAX_NSAS_DB_INSERT_1_Insert1 = new R0020_00_OBTER_MAX_NSAS_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R0020_00_OBTER_MAX_NSAS_DB_INSERT_1_Insert1.Execute(r0020_00_OBTER_MAX_NSAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_SAIDA*/

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-SECTION */
        private void R0050_00_SELECIONA_MOVTO_SECTION()
        {
            /*" -527- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -529- MOVE 'DECLER PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("DECLER PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -532- MOVE 1 TO COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(1, PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF);

            /*" -536- MOVE 'CAN' TO SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move("CAN", PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);

            /*" -539- MOVE 'R' TO SITUACAO-ENVIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("R", PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);

            /*" -542- MOVE '9' TO BILHETE-SITUACAO OF DCLBILHETE. */
            _.Move("9", BILHETE.DCLBILHETE.BILHETE_SITUACAO);

            /*" -583- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -585- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -588- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -589- DISPLAY 'PF0634B - FIM ANORMAL' */
                _.Display($"PF0634B - FIM ANORMAL");

                /*" -590- DISPLAY '          ERRO OPEN CURSOR PROPOSTA-FIDELIZ' */
                _.Display($"          ERRO OPEN CURSOR PROPOSTA-FIDELIZ");

                /*" -592- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -593- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -593- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -583- EXEC SQL DECLARE PROPOSTA-FIDELIZ CURSOR FOR SELECT A.NUM_PROPOSTA_SIVPF , A.NUM_IDENTIFICACAO , A.NUM_SICOB , A.COD_PRODUTO_SIVPF , A.VAL_PAGO , A.VAL_IOF , A.SIT_PROPOSTA , A.COD_USUARIO , A.CANAL_PROPOSTA , A.NSAS_SIVPF , A.ORIGEM_PROPOSTA , A.NSL , A.NSAC_SIVPF , A.SITUACAO_ENVIO , B.NUM_BILHETE , B.NUM_APOLICE , B.NUM_APOL_ANTERIOR , B.OPC_COBERTURA , B.DATA_QUITACAO , B.VAL_RCAP , B.RAMO , B.SITUACAO , DATE(B.TIMESTAMP) FROM SEGUROS.PROPOSTA_FIDELIZ A, SEGUROS.BILHETE B WHERE A.COD_EMPRESA_SIVPF = :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF AND A.SITUACAO_ENVIO = :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO AND A.SIT_PROPOSTA = :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA AND A.COD_PRODUTO_SIVPF IN (9, 10) AND B.NUM_BILHETE = A.NUM_SICOB AND B.SITUACAO = :DCLBILHETE.BILHETE-SITUACAO AND B.TIMESTAMP >= :DCLRELATORIOS.RELATORI-TIMESTAMP AND A.ORIGEM_PROPOSTA <> 1001 WITH UR END-EXEC. */
            PROPOSTA_FIDELIZ = new PF0634B_PROPOSTA_FIDELIZ(true);
            string GetQuery_PROPOSTA_FIDELIZ()
            {
                var query = @$"SELECT A.NUM_PROPOSTA_SIVPF
							, 
							A.NUM_IDENTIFICACAO
							, 
							A.NUM_SICOB
							, 
							A.COD_PRODUTO_SIVPF
							, 
							A.VAL_PAGO
							, 
							A.VAL_IOF
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
							B.NUM_BILHETE
							, 
							B.NUM_APOLICE
							, 
							B.NUM_APOL_ANTERIOR
							, 
							B.OPC_COBERTURA
							, 
							B.DATA_QUITACAO
							, 
							B.VAL_RCAP
							, 
							B.RAMO
							, 
							B.SITUACAO
							, 
							DATE(B.TIMESTAMP) 
							FROM SEGUROS.PROPOSTA_FIDELIZ A
							, 
							SEGUROS.BILHETE B 
							WHERE A.COD_EMPRESA_SIVPF = 
							'{PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF}' 
							AND A.SITUACAO_ENVIO = 
							'{PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO}' 
							AND A.SIT_PROPOSTA = 
							'{PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA}' 
							AND A.COD_PRODUTO_SIVPF IN (9
							, 10) 
							AND B.NUM_BILHETE = A.NUM_SICOB 
							AND B.SITUACAO = 
							'{BILHETE.DCLBILHETE.BILHETE_SITUACAO}' 
							AND B.TIMESTAMP >= 
							'{RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP}' 
							AND A.ORIGEM_PROPOSTA <> 1001";

                return query;
            }
            PROPOSTA_FIDELIZ.GetQueryEvent += GetQuery_PROPOSTA_FIDELIZ;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -585- EXEC SQL OPEN PROPOSTA-FIDELIZ END-EXEC. */

            PROPOSTA_FIDELIZ.Open();

        }

        [StopWatch]
        /*" R0240-00-SELECIONA-BIL-COB-DB-DECLARE-1 */
        public void R0240_00_SELECIONA_BIL_COB_DB_DECLARE_1()
        {
            /*" -1011- EXEC SQL DECLARE BILHETE-COBERTURA CURSOR FOR SELECT COD_PRODUTO, RAMO_COBERTURA, MODALI_COBERTURA, COD_OPCAO_PLANO, COD_COBERTURA, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IDE_COBERTURA, VAL_COBERTURA_IX, PRM_TOTAL, PCT_IOCC FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA = :DCLBILHETE-COBERTURA.BILCOBER-COD-EMPRESA AND RAMO_COBERTURA = :DCLBILHETE-COBERTURA.BILCOBER-RAMO-COBERTURA AND MODALI_COBERTURA = :DCLBILHETE-COBERTURA.BILCOBER-MODALI-COBERTURA AND COD_OPCAO_PLANO = :DCLBILHETE-COBERTURA.BILCOBER-COD-OPCAO-PLANO AND PRM_TOTAL = :DCLBILHETE-COBERTURA.BILCOBER-PRM-TOTAL ORDER BY COD_COBERTURA WITH UR END-EXEC. */
            BILHETE_COBERTURA = new PF0634B_BILHETE_COBERTURA(true);
            string GetQuery_BILHETE_COBERTURA()
            {
                var query = @$"SELECT COD_PRODUTO
							, 
							RAMO_COBERTURA
							, 
							MODALI_COBERTURA
							, 
							COD_OPCAO_PLANO
							, 
							COD_COBERTURA
							, 
							DATA_INIVIGENCIA
							, 
							DATA_TERVIGENCIA
							, 
							IDE_COBERTURA
							, 
							VAL_COBERTURA_IX
							, 
							PRM_TOTAL
							, 
							PCT_IOCC 
							FROM SEGUROS.BILHETE_COBERTURA 
							WHERE COD_EMPRESA = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_EMPRESA}' 
							AND RAMO_COBERTURA = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA}' 
							AND MODALI_COBERTURA = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_MODALI_COBERTURA}' 
							AND COD_OPCAO_PLANO = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO}' 
							AND PRM_TOTAL = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL}' 
							ORDER BY COD_COBERTURA";

                return query;
            }
            BILHETE_COBERTURA.GetQueryEvent += GetQuery_BILHETE_COBERTURA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -600- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -602- MOVE 'FETCH PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("FETCH PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -627- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -630- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -631- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -632- MOVE 'FIM' TO W-FIM-MOVTO-FIDELIZ */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ);

                    /*" -632- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -634- ELSE */
                }
                else
                {


                    /*" -635- DISPLAY 'PF0634B - FIM ANORMAL' */
                    _.Display($"PF0634B - FIM ANORMAL");

                    /*" -636- DISPLAY '          ERRO FETCH CURSOR PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO FETCH CURSOR PROPOSTA-FIDELIZ");

                    /*" -638- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -639- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -640- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -642- ELSE */
                }

            }
            else
            {


                /*" -645- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -646- IF W-CONTROLE > 99 */

                if (WAREA_AUXILIAR.W_CONTROLE > 99)
                {

                    /*" -647- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -648- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -649- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -650- DISPLAY '*  PF0634B - TOTAL LIDOS...' W-NSL ' ' W-TIME-EDIT. */

                    $"*  PF0634B - TOTAL LIDOS...{WAREA_AUXILIAR.W_NSL} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();
                }

            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -627- EXEC SQL FETCH PROPOSTA-FIDELIZ INTO :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO , :DCLPROPOSTA-FIDELIZ.NUM-SICOB , :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF , :DCLPROPOSTA-FIDELIZ.VAL-PAGO , :DCLPROPOSTA-FIDELIZ.VAL-IOF , :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA , :DCLPROPOSTA-FIDELIZ.COD-USUARIO , :DCLPROPOSTA-FIDELIZ.CANAL-PROPOSTA , :DCLPROPOSTA-FIDELIZ.NSAS-SIVPF , :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA , :DCLPROPOSTA-FIDELIZ.NSL , :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF , :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO , :DCLBILHETE.BILHETE-NUM-BILHETE , :DCLBILHETE.BILHETE-NUM-APOLICE , :DCLBILHETE.BILHETE-NUM-APOL-ANTERIOR , :DCLBILHETE.BILHETE-OPC-COBERTURA , :DCLBILHETE.BILHETE-DATA-QUITACAO , :DCLBILHETE.BILHETE-VAL-RCAP , :DCLBILHETE.BILHETE-RAMO , :DCLBILHETE.BILHETE-SITUACAO , :W-DATA-SITUACAO END-EXEC. */

            if (PROPOSTA_FIDELIZ.Fetch())
            {
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_VAL_PAGO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_VAL_IOF, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_COD_USUARIO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NSAS_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NSL, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NSAC_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_SITUACAO_ENVIO, PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);
                _.Move(PROPOSTA_FIDELIZ.DCLBILHETE_BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(PROPOSTA_FIDELIZ.DCLBILHETE_BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(PROPOSTA_FIDELIZ.DCLBILHETE_BILHETE_NUM_APOL_ANTERIOR, BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR);
                _.Move(PROPOSTA_FIDELIZ.DCLBILHETE_BILHETE_OPC_COBERTURA, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);
                _.Move(PROPOSTA_FIDELIZ.DCLBILHETE_BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(PROPOSTA_FIDELIZ.DCLBILHETE_BILHETE_VAL_RCAP, BILHETE.DCLBILHETE.BILHETE_VAL_RCAP);
                _.Move(PROPOSTA_FIDELIZ.DCLBILHETE_BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(PROPOSTA_FIDELIZ.DCLBILHETE_BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
                _.Move(PROPOSTA_FIDELIZ.W_DATA_SITUACAO, WAREA_AUXILIAR.W_DATA_SITUACAO);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -632- EXEC SQL CLOSE PROPOSTA-FIDELIZ END-EXEC */

            PROPOSTA_FIDELIZ.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -661- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -663- MOVE 'WRITE REG-HEADER-STA' TO COMANDO. */
            _.Move("WRITE REG-HEADER-STA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -665- MOVE SPACES TO REG-HEADER-STA. */
            _.Move("", LBFCT011.REG_HEADER_STA);

            /*" -668- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA. */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -671- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA. */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -672- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -673- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -675- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -678- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -681- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA. */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -684- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA. */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -687- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER-STA. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_HEADER_STA.RH_NSAS);

            /*" -687- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -698- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -700- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -703- MOVE COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-PRODUTO. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF, WAREA_AUXILIAR.W_PRODUTO);

            /*" -705- PERFORM R0230-00-LER-ENDOSSO. */

            R0230_00_LER_ENDOSSO_SECTION();

            /*" -708- MOVE W-DATA-SITUACAO TO PROPFIDH-DATA-SITUACAO OF DCLHIST-PROP-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SITUACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -710- PERFORM R0180-00-GERA-H-PROP-FIDEL. */

            R0180_00_GERA_H_PROP_FIDEL_SECTION();

            /*" -712- PERFORM R0190-00-GERAR-REGISTRO-TP1. */

            R0190_00_GERAR_REGISTRO_TP1_SECTION();

            /*" -714- PERFORM R0200-00-PROCESSAR-BILHETE. */

            R0200_00_PROCESSAR_BILHETE_SECTION();

            /*" -716- PERFORM R0600-00-GERAR-REGISTRO-TP4. */

            R0600_00_GERAR_REGISTRO_TP4_SECTION();

            /*" -719- MOVE R2-VAL-IOF OF REG-APOL-SASSE TO VAL-IOF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFCT016.REG_APOL_SASSE.R2_VAL_IOF, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF);

            /*" -722- MOVE 'PF0634B' TO COD-USUARIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("PF0634B", PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);

            /*" -738- PERFORM R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1 */

            R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1();

            /*" -0- FLUXCONTROL_PERFORM R0150_LER */

            R0150_LER();

        }

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-DB-UPDATE-1 */
        public void R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1()
        {
            /*" -738- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SITUACAO_ENVIO = 'R' , NSAS_SIVPF = :DCLPROPOSTA-FIDELIZ.NSAS-SIVPF , NSL = :DCLPROPOSTA-FIDELIZ.NSL , SIT_PROPOSTA = :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, VAL_IOF = :DCLPROPOSTA-FIDELIZ.VAL-IOF , COD_USUARIO = :DCLPROPOSTA-FIDELIZ.COD-USUARIO , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1 = new R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1()
            {
                SIT_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA.ToString(),
                COD_USUARIO = PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO.ToString(),
                NSAS_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF.ToString(),
                VAL_IOF = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF.ToString(),
                NSL = PROPFID.DCLPROPOSTA_FIDELIZ.NSL.ToString(),
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1.Execute(r0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0150-LER */
        private void R0150_LER(bool isPerform = false)
        {
            /*" -742- PERFORM R0070-00-LER-MOVTO. */

            R0070_00_LER_MOVTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0180-00-GERA-H-PROP-FIDEL-SECTION */
        private void R0180_00_GERA_H_PROP_FIDEL_SECTION()
        {
            /*" -752- MOVE 'R0180-GERA-H-PROP-FIDEL' TO PARAGRAFO. */
            _.Move("R0180-GERA-H-PROP-FIDEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -754- MOVE 'INSERT HIST PROP FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST PROP FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -757- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NUM-IDENTIFICACAO OF DCLHIST-PROP-FIDELIZ. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -760- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO PROPFIDH-NSAS-SIVPF OF DCLHIST-PROP-FIDELIZ. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -763- MOVE 'EMT' TO PROPFIDH-SIT-PROPOSTA OF DCLHIST-PROP-FIDELIZ. */
            _.Move("EMT", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -764- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 6 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA == 6)
            {

                /*" -765- MOVE 'MAN' TO SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Move("MAN", PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);

                /*" -766- ELSE */
            }
            else
            {


                /*" -767- MOVE 'EMT' TO SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Move("EMT", PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);

                /*" -769- END-IF */
            }


            /*" -772- MOVE 'PAG' TO PROPFIDH-SIT-COBRANCA-SIVPF OF DCLHIST-PROP-FIDELIZ. */
            _.Move("PAG", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -775- MOVE 675 TO PROPFIDH-SIT-MOTIVO-SIVPF OF DCLHIST-PROP-FIDELIZ. */
            _.Move(675, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -777- ADD 1 TO PROPFIDH-NSL OF DCLHIST-PROP-FIDELIZ. */
            PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL.Value = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL + 1;

            /*" -778- IF CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ = 4 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA == 4)
            {

                /*" -779- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ = 9 OR 10 */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF.In("9", "10"))
                {

                    /*" -780- MOVE 'EMT' TO SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                    _.Move("EMT", PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);

                    /*" -781- END-IF */
                }


                /*" -783- END-IF */
            }


            /*" -786- MOVE COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -789- MOVE COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -800- PERFORM R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1 */

            R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1();

            /*" -803- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -804- DISPLAY 'PF0634B - FIM ANORMAL' */
                _.Display($"PF0634B - FIM ANORMAL");

                /*" -805- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -807- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -809- DISPLAY '          NUMERO IDENTIFICACAO..........  ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                /*" -811- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -812- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -813- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -813- END-IF. */
            }


        }

        [StopWatch]
        /*" R0180-00-GERA-H-PROP-FIDEL-DB-INSERT-1 */
        public void R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1()
        {
            /*" -800- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:DCLHIST-PROP-FIDELIZ.PROPFIDH-NUM-IDENTIFICACAO , :DCLHIST-PROP-FIDELIZ.PROPFIDH-DATA-SITUACAO , :DCLHIST-PROP-FIDELIZ.PROPFIDH-NSAS-SIVPF , :DCLHIST-PROP-FIDELIZ.PROPFIDH-NSL , :DCLHIST-PROP-FIDELIZ.PROPFIDH-SIT-PROPOSTA , :DCLHIST-PROP-FIDELIZ.PROPFIDH-SIT-COBRANCA-SIVPF, :DCLHIST-PROP-FIDELIZ.PROPFIDH-SIT-MOTIVO-SIVPF , :DCLHIST-PROP-FIDELIZ.PROPFIDH-COD-EMPRESA-SIVPF , :DCLHIST-PROP-FIDELIZ.PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

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
            /*" -824- MOVE 'R0190-00-GERAR-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0190-00-GERAR-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -829- MOVE 'WRITE REG-STA-PROPOSTA' TO COMANDO. */
            _.Move("WRITE REG-STA-PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -831- MOVE SPACES TO REG-STA-PROPOSTA. */
            _.Move("", LBFCT011.REG_STA_PROPOSTA);

            /*" -834- MOVE '1' TO R1-TIPO-REG OF REG-STA-PROPOSTA. */
            _.Move("1", LBFCT011.REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -837- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -840- MOVE PROPFIDH-SIT-PROPOSTA OF DCLHIST-PROP-FIDELIZ TO R1-SIT-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA, LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

            /*" -843- MOVE PROPFIDH-SIT-MOTIVO-SIVPF OF DCLHIST-PROP-FIDELIZ TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);

            /*" -846- MOVE PROPFIDH-DATA-SITUACAO OF DCLHIST-PROP-FIDELIZ TO W-DATA-SQL. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -847- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -848- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -850- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -853- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -856- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO R1-NSAS OF REG-STA-PROPOSTA. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NSAS);

            /*" -858- ADD 1 TO W-QTD-LD-TIPO-1, W-ABEND-CTR. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;
            WAREA_AUXILIAR.W_ABEND_CTR.Value = WAREA_AUXILIAR.W_ABEND_CTR + 1;

            /*" -861- MOVE W-QTD-LD-TIPO-1 TO R1-NSL OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFCT011.REG_STA_PROPOSTA.R1_NSL);

            /*" -861- WRITE REG-STA-SASSE FROM REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0190_SAIDA*/

        [StopWatch]
        /*" R0200-00-PROCESSAR-BILHETE-SECTION */
        private void R0200_00_PROCESSAR_BILHETE_SECTION()
        {
            /*" -871- MOVE 'R0200-00-PROCESSAR-BILHETE' TO PARAGRAFO. */
            _.Move("R0200-00-PROCESSAR-BILHETE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -876- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -878- MOVE 'NAO' TO W-FIM-BILHETE-COB. */
            _.Move("NAO", WAREA_AUXILIAR.W_FIM_BILHETE_COB);

            /*" -880- MOVE 1 TO W-BILHETE-LIDO. */
            _.Move(1, WAREA_AUXILIAR.W_BILHETE_LIDO);

            /*" -882- PERFORM R0240-00-SELECIONA-BIL-COB. */

            R0240_00_SELECIONA_BIL_COB_SECTION();

            /*" -884- PERFORM R0245-00-LER-BILHETE-COBER. */

            R0245_00_LER_BILHETE_COBER_SECTION();

            /*" -885- PERFORM R0250-00-GERAR-REGISTROS UNTIL W-FIM-BILHETE-COB EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_BILHETE_COB == "FIM"))
            {

                R0250_00_GERAR_REGISTROS_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0230-00-LER-ENDOSSO-SECTION */
        private void R0230_00_LER_ENDOSSO_SECTION()
        {
            /*" -895- MOVE 'R0230-00-LER-ENDOSSO' TO PARAGRAFO. */
            _.Move("R0230-00-LER-ENDOSSO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -900- MOVE 'SELECT BILHETE' TO COMANDO. */
            _.Move("SELECT BILHETE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -903- MOVE BILHETE-NUM-APOLICE OF DCLBILHETE TO ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -906- MOVE ZEROS TO ENDOSSOS-NUM-ENDOSSO OF DCLENDOSSOS. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -927- PERFORM R0230_00_LER_ENDOSSO_DB_SELECT_1 */

            R0230_00_LER_ENDOSSO_DB_SELECT_1();

            /*" -930- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -931- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -939- MOVE ZEROS TO ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS ENDOSSOS-NUM-ENDOSSO OF DCLENDOSSOS ENDOSSOS-NUM-PROPOSTA OF DCLENDOSSOS ENDOSSOS-DATA-PROPOSTA OF DCLENDOSSOS ENDOSSOS-NUM-RCAP OF DCLENDOSSOS ENDOSSOS-VAL-RCAP OF DCLENDOSSOS ENDOSSOS-DATA-INIVIGENCIA OF DCLENDOSSOS ENDOSSOS-DATA-TERVIGENCIA OF DCLENDOSSOS */
                    _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                    /*" -940- ELSE */
                }
                else
                {


                    /*" -941- DISPLAY 'PF0634B - FIM ANORMAL' */
                    _.Display($"PF0634B - FIM ANORMAL");

                    /*" -942- DISPLAY '          ERRO SELECT TAB. ENDOSSO' */
                    _.Display($"          ERRO SELECT TAB. ENDOSSO");

                    /*" -944- DISPLAY '          NUMERO APOLICE.......... ' ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS */
                    _.Display($"          NUMERO APOLICE.......... {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                    /*" -946- DISPLAY '          NUM BILHETE......... ' BILHETE-NUM-BILHETE OF DCLBILHETE */
                    _.Display($"          NUM BILHETE......... {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -948- DISPLAY '          SQLCODE................. ' SQLCODE */
                    _.Display($"          SQLCODE................. {DB.SQLCODE}");

                    /*" -949- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -949- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0230-00-LER-ENDOSSO-DB-SELECT-1 */
        public void R0230_00_LER_ENDOSSO_DB_SELECT_1()
        {
            /*" -927- EXEC SQL SELECT NUM_APOLICE, NUM_ENDOSSO, NUM_PROPOSTA, DATA_PROPOSTA, NUM_RCAP, VAL_RCAP, DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE, :DCLENDOSSOS.ENDOSSOS-NUM-ENDOSSO, :DCLENDOSSOS.ENDOSSOS-NUM-PROPOSTA, :DCLENDOSSOS.ENDOSSOS-DATA-PROPOSTA, :DCLENDOSSOS.ENDOSSOS-NUM-RCAP, :DCLENDOSSOS.ENDOSSOS-VAL-RCAP, :DCLENDOSSOS.ENDOSSOS-DATA-INIVIGENCIA, :DCLENDOSSOS.ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :DCLENDOSSOS.ENDOSSOS-NUM-ENDOSSO WITH UR END-EXEC. */

            var r0230_00_LER_ENDOSSO_DB_SELECT_1_Query1 = new R0230_00_LER_ENDOSSO_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0230_00_LER_ENDOSSO_DB_SELECT_1_Query1.Execute(r0230_00_LER_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(executed_1.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_DATA_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_NUM_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP);
                _.Move(executed_1.ENDOSSOS_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_SAIDA*/

        [StopWatch]
        /*" R0240-00-SELECIONA-BIL-COB-SECTION */
        private void R0240_00_SELECIONA_BIL_COB_SECTION()
        {
            /*" -959- MOVE 'R0240-00-SELECIONA-BIL-COBE' TO PARAGRAFO. */
            _.Move("R0240-00-SELECIONA-BIL-COBE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -964- MOVE 'DECLARE BILHETE-COBER' TO COMANDO. */
            _.Move("DECLARE BILHETE-COBER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -968- MOVE ZEROS TO BILCOBER-COD-EMPRESA OF DCLBILHETE-COBERTURA BILCOBER-MODALI-COBERTURA OF DCLBILHETE-COBERTURA. */
            _.Move(0, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_EMPRESA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_MODALI_COBERTURA);

            /*" -971- MOVE BILHETE-RAMO OF DCLBILHETE TO BILCOBER-RAMO-COBERTURA OF DCLBILHETE-COBERTURA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_RAMO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA);

            /*" -974- MOVE BILHETE-OPC-COBERTURA OF DCLBILHETE TO BILCOBER-COD-OPCAO-PLANO OF DCLBILHETE-COBERTURA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO);

            /*" -977- MOVE BILHETE-VAL-RCAP OF DCLBILHETE TO BILCOBER-PRM-TOTAL OF DCLBILHETE-COBERTURA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_VAL_RCAP, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL);

            /*" -980- MOVE ENDOSSOS-DATA-INIVIGENCIA OF DCLENDOSSOS TO BILCOBER-DATA-INIVIGENCIA OF DCLBILHETE-COBERTURA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA);

            /*" -983- MOVE ENDOSSOS-DATA-TERVIGENCIA OF DCLENDOSSOS TO BILCOBER-DATA-TERVIGENCIA OF DCLBILHETE-COBERTURA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_TERVIGENCIA);

            /*" -1011- PERFORM R0240_00_SELECIONA_BIL_COB_DB_DECLARE_1 */

            R0240_00_SELECIONA_BIL_COB_DB_DECLARE_1();

            /*" -1013- PERFORM R0240_00_SELECIONA_BIL_COB_DB_OPEN_1 */

            R0240_00_SELECIONA_BIL_COB_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0240-00-SELECIONA-BIL-COB-DB-OPEN-1 */
        public void R0240_00_SELECIONA_BIL_COB_DB_OPEN_1()
        {
            /*" -1013- EXEC SQL OPEN BILHETE-COBERTURA END-EXEC. */

            BILHETE_COBERTURA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_SAIDA*/

        [StopWatch]
        /*" R0245-00-LER-BILHETE-COBER-SECTION */
        private void R0245_00_LER_BILHETE_COBER_SECTION()
        {
            /*" -1022- MOVE 'R0245-00-LER-BILHETE-COBER' TO PARAGRAFO. */
            _.Move("R0245-00-LER-BILHETE-COBER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1028- MOVE 'FETCH BILHETE-COBERTURA' TO COMANDO. */
            _.Move("FETCH BILHETE-COBERTURA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1042- PERFORM R0245_00_LER_BILHETE_COBER_DB_FETCH_1 */

            R0245_00_LER_BILHETE_COBER_DB_FETCH_1();

            /*" -1045- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1046- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1047- MOVE 'FIM' TO W-FIM-BILHETE-COB */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_BILHETE_COB);

                    /*" -1047- PERFORM R0245_00_LER_BILHETE_COBER_DB_CLOSE_1 */

                    R0245_00_LER_BILHETE_COBER_DB_CLOSE_1();

                    /*" -1049- ELSE */
                }
                else
                {


                    /*" -1050- DISPLAY 'PF0634B - FIM ANORMAL' */
                    _.Display($"PF0634B - FIM ANORMAL");

                    /*" -1051- DISPLAY '          ERRO FETCH CURSOR BILHETE-COBERTURA' */
                    _.Display($"          ERRO FETCH CURSOR BILHETE-COBERTURA");

                    /*" -1053- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -1054- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1056- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -1057- IF BILCOBER-PCT-IOCC OF DCLBILHETE-COBERTURA IS NOT NUMERIC */

            if (!BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PCT_IOCC.IsNumeric())
            {

                /*" -1058- MOVE ZEROS TO BILCOBER-PCT-IOCC OF DCLBILHETE-COBERTURA */
                _.Move(0, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PCT_IOCC);

                /*" -1060- END-IF. */
            }


            /*" -1061- COMPUTE W-IND-IOF =(BILCOBER-PCT-IOCC OF DCLBILHETE-COBERTURA / 100) + 1. */
            WAREA_AUXILIAR.W_IND_IOF.Value = (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PCT_IOCC / 100f) + 1;

        }

        [StopWatch]
        /*" R0245-00-LER-BILHETE-COBER-DB-FETCH-1 */
        public void R0245_00_LER_BILHETE_COBER_DB_FETCH_1()
        {
            /*" -1042- EXEC SQL FETCH BILHETE-COBERTURA INTO :DCLBILHETE-COBERTURA.BILCOBER-COD-PRODUTO , :DCLBILHETE-COBERTURA.BILCOBER-RAMO-COBERTURA , :DCLBILHETE-COBERTURA.BILCOBER-MODALI-COBERTURA , :DCLBILHETE-COBERTURA.BILCOBER-COD-OPCAO-PLANO , :DCLBILHETE-COBERTURA.BILCOBER-COD-COBERTURA , :DCLBILHETE-COBERTURA.BILCOBER-DATA-INIVIGENCIA , :DCLBILHETE-COBERTURA.BILCOBER-DATA-TERVIGENCIA , :DCLBILHETE-COBERTURA.BILCOBER-IDE-COBERTURA , :DCLBILHETE-COBERTURA.BILCOBER-VAL-COBERTURA-IX , :DCLBILHETE-COBERTURA.BILCOBER-PRM-TOTAL , :DCLBILHETE-COBERTURA.BILCOBER-PCT-IOCC END-EXEC. */

            if (BILHETE_COBERTURA.Fetch())
            {
                _.Move(BILHETE_COBERTURA.DCLBILHETE_COBERTURA_BILCOBER_COD_PRODUTO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO);
                _.Move(BILHETE_COBERTURA.DCLBILHETE_COBERTURA_BILCOBER_RAMO_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA);
                _.Move(BILHETE_COBERTURA.DCLBILHETE_COBERTURA_BILCOBER_MODALI_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_MODALI_COBERTURA);
                _.Move(BILHETE_COBERTURA.DCLBILHETE_COBERTURA_BILCOBER_COD_OPCAO_PLANO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO);
                _.Move(BILHETE_COBERTURA.DCLBILHETE_COBERTURA_BILCOBER_COD_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_COBERTURA);
                _.Move(BILHETE_COBERTURA.DCLBILHETE_COBERTURA_BILCOBER_DATA_INIVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA);
                _.Move(BILHETE_COBERTURA.DCLBILHETE_COBERTURA_BILCOBER_DATA_TERVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_TERVIGENCIA);
                _.Move(BILHETE_COBERTURA.DCLBILHETE_COBERTURA_BILCOBER_IDE_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_IDE_COBERTURA);
                _.Move(BILHETE_COBERTURA.DCLBILHETE_COBERTURA_BILCOBER_VAL_COBERTURA_IX, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_COBERTURA_IX);
                _.Move(BILHETE_COBERTURA.DCLBILHETE_COBERTURA_BILCOBER_PRM_TOTAL, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL);
                _.Move(BILHETE_COBERTURA.DCLBILHETE_COBERTURA_BILCOBER_PCT_IOCC, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PCT_IOCC);
            }

        }

        [StopWatch]
        /*" R0245-00-LER-BILHETE-COBER-DB-CLOSE-1 */
        public void R0245_00_LER_BILHETE_COBER_DB_CLOSE_1()
        {
            /*" -1047- EXEC SQL CLOSE BILHETE-COBERTURA END-EXEC */

            BILHETE_COBERTURA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0245_SAIDA*/

        [StopWatch]
        /*" R0250-00-GERAR-REGISTROS-SECTION */
        private void R0250_00_GERAR_REGISTROS_SECTION()
        {
            /*" -1071- MOVE 'R0250-00-GERAR-REGISTROS' TO PARAGRAFO. */
            _.Move("R0250-00-GERAR-REGISTROS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1076- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1077- IF W-BILHETE-LIDO EQUAL 1 */

            if (WAREA_AUXILIAR.W_BILHETE_LIDO == 1)
            {

                /*" -1079- PERFORM R0270-00-GERAR-REG-TP2-BIL. */

                R0270_00_GERAR_REG_TP2_BIL_SECTION();
            }


            /*" -1081- MOVE 1 TO W-REG-BIL-AP. */
            _.Move(1, WAREA_AUXILIAR.W_REG_BIL_AP);

            /*" -1082- IF BILHETE-AP */

            if (WAREA_AUXILIAR.W_PRODUTO["BILHETE_AP"])
            {

                /*" -1083- ADD 1 TO W-LIDO-BIL-AP */
                WAREA_AUXILIAR.W_LIDO_BIL_AP.Value = WAREA_AUXILIAR.W_LIDO_BIL_AP + 1;

                /*" -1084- MOVE 09 TO W-SUBPRODUTO */
                _.Move(09, WAREA_AUXILIAR.FILLER_0.W_SUBPRODUTO);

                /*" -1086- PERFORM R0300-00-GERAR-REG-TP3-AP 2 TIMES */

                for (int i = 0; i < 2; i++)
                {

                    R0300_00_GERAR_REG_TP3_AP_SECTION();

                }

                /*" -1087- ELSE */
            }
            else
            {


                /*" -1088- ADD 1 TO W-LIDO-BIL-RD */
                WAREA_AUXILIAR.W_LIDO_BIL_RD.Value = WAREA_AUXILIAR.W_LIDO_BIL_RD + 1;

                /*" -1089- MOVE 10 TO W-SUBPRODUTO */
                _.Move(10, WAREA_AUXILIAR.FILLER_0.W_SUBPRODUTO);

                /*" -1091- PERFORM R0350-00-GERAR-REG-TP3-RD. */

                R0350_00_GERAR_REG_TP3_RD_SECTION();
            }


            /*" -1093- PERFORM R0245-00-LER-BILHETE-COBER. */

            R0245_00_LER_BILHETE_COBER_SECTION();

            /*" -1093- ADD 1 TO W-BILHETE-LIDO. */
            WAREA_AUXILIAR.W_BILHETE_LIDO.Value = WAREA_AUXILIAR.W_BILHETE_LIDO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0270-00-GERAR-REG-TP2-BIL-SECTION */
        private void R0270_00_GERAR_REG_TP2_BIL_SECTION()
        {
            /*" -1103- MOVE 'R0270-00-GERAR-REG-TP2-BIL' TO PARAGRAFO. */
            _.Move("R0270-00-GERAR-REG-TP2-BIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1108- MOVE 'WRITE REG-APOL-SASSE' TO COMANDO. */
            _.Move("WRITE REG-APOL-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1110- MOVE SPACES TO REG-APOL-SASSE. */
            _.Move("", LBFCT016.REG_APOL_SASSE);

            /*" -1113- MOVE '2' TO R2-TIPO-REG OF REG-APOL-SASSE. */
            _.Move("2", LBFCT016.REG_APOL_SASSE.R2_TIPO_REG);

            /*" -1116- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R2-NUM-PROPOSTA OF REG-APOL-SASSE, */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_APOL_SASSE.R2_NUM_PROPOSTA);

            /*" -1119- MOVE BILHETE-NUM-APOLICE OF DCLBILHETE TO R2-NRCERTIF OF REG-APOL-SASSE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, LBFCT016.REG_APOL_SASSE.R2_NRCERTIF);

            /*" -1121- MOVE ENDOSSOS-DATA-INIVIGENCIA OF DCLENDOSSOS TO W-DATA-SQL. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1123- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1125- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1127- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1130- MOVE W-DATA-TRABALHO TO R2-DTINIVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTINIVIG);

            /*" -1132- MOVE ENDOSSOS-DATA-TERVIGENCIA OF DCLENDOSSOS TO W-DATA-SQL. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1134- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1136- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1139- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1142- MOVE W-DATA-TRABALHO TO R2-DTTERVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTTERVIG);

            /*" -1144- IF BILCOBER-PRM-TOTAL OF DCLBILHETE-COBERTURA > 0 */

            if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL > 0)
            {

                /*" -1149- MOVE BILCOBER-PRM-TOTAL OF DCLBILHETE-COBERTURA TO R2-VAL-PREMIO OF REG-APOL-SASSE */
                _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL, LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO);

                /*" -1150- ELSE */
            }
            else
            {


                /*" -1153- MOVE BILHETE-VAL-RCAP OF DCLBILHETE TO R2-VAL-PREMIO OF REG-APOL-SASSE. */
                _.Move(BILHETE.DCLBILHETE.BILHETE_VAL_RCAP, LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO);
            }


            /*" -1156- COMPUTE W-PRM-LIQ = R2-VAL-PREMIO OF REG-APOL-SASSE / W-IND-IOF. */
            WAREA_AUXILIAR.W_PRM_LIQ.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO / WAREA_AUXILIAR.W_IND_IOF;

            /*" -1160- COMPUTE R2-VAL-IOF OF REG-APOL-SASSE = R2-VAL-PREMIO OF REG-APOL-SASSE - W-PRM-LIQ. */
            LBFCT016.REG_APOL_SASSE.R2_VAL_IOF.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO - WAREA_AUXILIAR.W_PRM_LIQ;

            /*" -1164- COMPUTE R2-VAL-PREMIO OF REG-APOL-SASSE = R2-VAL-PREMIO OF REG-APOL-SASSE - R2-VAL-IOF OF REG-APOL-SASSE. */
            LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO - LBFCT016.REG_APOL_SASSE.R2_VAL_IOF;

            /*" -1166- WRITE REG-STA-SASSE FROM REG-APOL-SASSE. */
            _.Move(LBFCT016.REG_APOL_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1166- ADD 1 TO W-QTD-LD-TIPO-2. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_SAIDA*/

        [StopWatch]
        /*" R0300-00-GERAR-REG-TP3-AP-SECTION */
        private void R0300_00_GERAR_REG_TP3_AP_SECTION()
        {
            /*" -1176- MOVE 'R0300-00-GERAR-REG-TP3-AP' TO PARAGRAFO. */
            _.Move("R0300-00-GERAR-REG-TP3-AP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1181- MOVE 'WRITE REG-COBER-SASSE' TO COMANDO. */
            _.Move("WRITE REG-COBER-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1183- MOVE SPACES TO REG-COBER-SASSE. */
            _.Move("", LBFCT016.REG_COBER_SASSE);

            /*" -1186- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -1189- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -1196- MOVE BILCOBER-VAL-COBERTURA-IX OF DCLBILHETE-COBERTURA TO R3-VAL-COBERTURA OF REG-COBER-SASSE. */
            _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_COBERTURA_IX, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

            /*" -1197- IF W-REG-BIL-AP EQUAL 1 */

            if (WAREA_AUXILIAR.W_REG_BIL_AP == 1)
            {

                /*" -1198- MOVE 1 TO W-COBERTURA */
                _.Move(1, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -1199- ELSE */
            }
            else
            {


                /*" -1201- MOVE 2 TO W-COBERTURA. */
                _.Move(2, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);
            }


            /*" -1204- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE. */
            _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

            /*" -1207- ADD 1 TO W-QTD-LD-TIPO-3, W-REG-BIL-AP. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;
            WAREA_AUXILIAR.W_REG_BIL_AP.Value = WAREA_AUXILIAR.W_REG_BIL_AP + 1;

            /*" -1207- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
            _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0350-00-GERAR-REG-TP3-RD-SECTION */
        private void R0350_00_GERAR_REG_TP3_RD_SECTION()
        {
            /*" -1217- MOVE 'R0350-00-GERAR-REG-TP3-RD' TO PARAGRAFO. */
            _.Move("R0350-00-GERAR-REG-TP3-RD", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1222- MOVE 'WRITE REG-COBER-SASSE' TO COMANDO. */
            _.Move("WRITE REG-COBER-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1224- MOVE SPACES TO REG-COBER-SASSE. */
            _.Move("", LBFCT016.REG_COBER_SASSE);

            /*" -1227- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -1230- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -1234- MOVE BILCOBER-VAL-COBERTURA-IX OF DCLBILHETE-COBERTURA TO R3-VAL-COBERTURA OF REG-COBER-SASSE. */
            _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_COBERTURA_IX, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

            /*" -1235- IF BILCOBER-COD-COBERTURA OF DCLBILHETE-COBERTURA EQUAL 2000 */

            if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_COBERTURA == 2000)
            {

                /*" -1238- MOVE 1 TO W-COBERTURA. */
                _.Move(1, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);
            }


            /*" -1239- IF BILCOBER-COD-COBERTURA OF DCLBILHETE-COBERTURA EQUAL 2200 */

            if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_COBERTURA == 2200)
            {

                /*" -1242- MOVE 2 TO W-COBERTURA. */
                _.Move(2, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);
            }


            /*" -1243- IF BILCOBER-COD-COBERTURA OF DCLBILHETE-COBERTURA EQUAL 2100 */

            if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_COBERTURA == 2100)
            {

                /*" -1245- MOVE 3 TO W-COBERTURA. */
                _.Move(3, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);
            }


            /*" -1248- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE. */
            _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

            /*" -1250- ADD 1 TO W-QTD-LD-TIPO-3 */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

            /*" -1250- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
            _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R0600-00-GERAR-REGISTRO-TP4-SECTION */
        private void R0600_00_GERAR_REGISTRO_TP4_SECTION()
        {
            /*" -1261- MOVE 'R0600-00-GERAR-REGISTRO-TP4' TO PARAGRAFO. */
            _.Move("R0600-00-GERAR-REGISTRO-TP4", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1266- MOVE 'WRITE REG-STA-PROPOSTA' TO COMANDO. */
            _.Move("WRITE REG-STA-PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1268- MOVE SPACES TO REG-PGTO-SASSE. */
            _.Move("", LBFCT016.REG_PGTO_SASSE);

            /*" -1271- MOVE '4' TO R4-TIPO-REG OF REG-PGTO-SASSE. */
            _.Move("4", LBFCT016.REG_PGTO_SASSE.R4_TIPO_REG);

            /*" -1274- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R4-NUM-PROPOSTA OF REG-PGTO-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA);

            /*" -1277- MOVE PROPFIDH-SIT-COBRANCA-SIVPF OF DCLHIST-PROP-FIDELIZ TO R4-SIT-COBRANCA OF REG-PGTO-SASSE. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA);

            /*" -1280- MOVE BILHETE-DATA-QUITACAO OF DCLBILHETE TO W-DATA-SQL. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1281- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1282- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1284- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1287- MOVE W-DATA-TRABALHO TO R4-DATA-SITUACAO OF REG-PGTO-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO);

            /*" -1291- MOVE 1 TO R4-PARCELAS-PAGAS OF REG-PGTO-SASSE R4-TOTAL-PARCELAS OF REG-PGTO-SASSE */
            _.Move(1, LBFCT016.REG_PGTO_SASSE.R4_PARCELAS_PAGAS, LBFCT016.REG_PGTO_SASSE.R4_TOTAL_PARCELAS);

            /*" -1293- WRITE REG-STA-SASSE FROM REG-PGTO-SASSE. */
            _.Move(LBFCT016.REG_PGTO_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1293- ADD 1 TO W-QTD-LD-TIPO-4. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_4.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_SAIDA*/

        [StopWatch]
        /*" R0800-00-GERAR-TRAILLER-SECTION */
        private void R0800_00_GERAR_TRAILLER_SECTION()
        {
            /*" -1303- MOVE 'R0800-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R0800-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1308- MOVE 'WRITE REG-TRAILLER-STA' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER-STA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1310- MOVE SPACES TO REG-TRAILLER-STA. */
            _.Move("", LBFCT011.REG_TRAILLER_STA);

            /*" -1313- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -1316- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -1319- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1);

            /*" -1322- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2);

            /*" -1325- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3);

            /*" -1328- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4);

            /*" -1331- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_5, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5);

            /*" -1334- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_6, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6);

            /*" -1337- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_7, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7);

            /*" -1340- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8);

            /*" -1343- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_9, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9);

            /*" -1354- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -1354- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -1364- MOVE 'R0850-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R0850-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1369- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1372- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -1379- PERFORM R0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1 */

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1();

            /*" -1382- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1383- DISPLAY 'PF0634B - FIM ANORMAL - SQLCODE = ' SQLCODE */
                _.Display($"PF0634B - FIM ANORMAL - SQLCODE = {DB.SQLCODE}");

                /*" -1384- DISPLAY 'ERRO UPDATE TABELA ARQUIVOS-SIVPF' */
                _.Display($"ERRO UPDATE TABELA ARQUIVOS-SIVPF");

                /*" -1385- DISPLAY 'SIGLA DO ARQUIVO...... ' 'STASASSE' */
                _.Display($"SIGLA DO ARQUIVO...... STASASSE");

                /*" -1386- DISPLAY 'NSAS SIVPF............ ' ARQSIVPF-NSAS-SIVPF */
                _.Display($"NSAS SIVPF............ {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -1387- DISPLAY 'DATA GERACAO.......... ' ARQSIVPF-DATA-GERACAO */
                _.Display($"DATA GERACAO.......... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -1389- DISPLAY 'QTDE. REGISTROS....... ' ARQSIVPF-QTDE-REG-GER */
                _.Display($"QTDE. REGISTROS....... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -1390- MOVE SPACES TO W-FIM-MOVTO-FIDELIZ */
                _.Move("", WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ);

                /*" -1391- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1392- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1392- END-IF. */
            }


        }

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-DB-UPDATE-1 */
        public void R0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1()
        {
            /*" -1379- EXEC SQL UPDATE SEGUROS.ARQUIVOS_SIVPF SET QTDE_REG_GER = :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER WHERE SIGLA_ARQUIVO = 'STASASSE' AND SISTEMA_ORIGEM = 4 AND NSAS_SIVPF = :ARQSIVPF-NSAS-SIVPF END-EXEC. */

            var r0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1 = new R0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1()
            {
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
            };

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1.Execute(r0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R0870-00-GERAR-TOTAIS-SECTION */
        private void R0870_00_GERAR_TOTAIS_SECTION()
        {
            /*" -1403- MOVE 'R0870-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R0870-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1408- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1418- COMPUTE W-TOT-GERADO-STA = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9. */
            WAREA_AUXILIAR.W_TOT_GERADO_STA.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9;

            /*" -1419- DISPLAY 'PF0634B - TOTAIS DO PROCESSAMENTO' */
            _.Display($"PF0634B - TOTAIS DO PROCESSAMENTO");

            /*" -1420- DISPLAY '          TOTAL  REGISTROS LIDOS... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS... {WAREA_AUXILIAR.W_NSL}");

            /*" -1421- DISPLAY '          TOTAL  BILHETE   AP...... ' W-LIDO-BIL-AP */
            _.Display($"          TOTAL  BILHETE   AP...... {WAREA_AUXILIAR.W_LIDO_BIL_AP}");

            /*" -1422- DISPLAY '          TOTAL  BILHETE   RD...... ' W-LIDO-BIL-RD */
            _.Display($"          TOTAL  BILHETE   RD...... {WAREA_AUXILIAR.W_LIDO_BIL_RD}");

            /*" -1423- DISPLAY ' ' */
            _.Display($" ");

            /*" -1424- DISPLAY '          TOTAL  GERADO ARQ. STATUS ' */
            _.Display($"          TOTAL  GERADO ARQ. STATUS ");

            /*" -1426- DISPLAY '          TOTAL  REGISTROS TP-1.... ' W-QTD-LD-TIPO-1 */
            _.Display($"          TOTAL  REGISTROS TP-1.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -1428- DISPLAY '          TOTAL  REGISTROS TP-2.... ' W-QTD-LD-TIPO-2 */
            _.Display($"          TOTAL  REGISTROS TP-2.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_2}");

            /*" -1430- DISPLAY '          TOTAL  REGISTROS TP-3.... ' W-QTD-LD-TIPO-3 */
            _.Display($"          TOTAL  REGISTROS TP-3.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_3}");

            /*" -1432- DISPLAY '          TOTAL  REGISTROS TP-4.... ' W-QTD-LD-TIPO-4 */
            _.Display($"          TOTAL  REGISTROS TP-4.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_4}");

            /*" -1433- DISPLAY '          TOTAL  REGISTROS GERADOS. ' W-TOT-GERADO-STA. */
            _.Display($"          TOTAL  REGISTROS GERADOS. {WAREA_AUXILIAR.W_TOT_GERADO_STA}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0870_SAIDA*/

        [StopWatch]
        /*" R1110-00-UPDATE-RELATORIOS-SECTION */
        private void R1110_00_UPDATE_RELATORIOS_SECTION()
        {
            /*" -1442- MOVE 'R1110-00-UPDATE-RELATORIOS' TO PARAGRAFO. */
            _.Move("R1110-00-UPDATE-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1444- MOVE 'UPDATE RELATORIOS' TO COMANDO. */
            _.Move("UPDATE RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1447- MOVE SISTEMAS-DATA-MOV-ABERTO TO RELATORI-DATA-REFERENCIA OF DCLRELATORIOS. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

            /*" -1454- PERFORM R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1 */

            R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1();

            /*" -1457- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1458- DISPLAY 'PF0634B - FIM ANORMAL' */
                _.Display($"PF0634B - FIM ANORMAL");

                /*" -1459- DISPLAY '          ERRO UPDATE RELATORIOS' */
                _.Display($"          ERRO UPDATE RELATORIOS");

                /*" -1461- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -1462- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1462- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1110-00-UPDATE-RELATORIOS-DB-UPDATE-1 */
        public void R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1()
        {
            /*" -1454- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_REFERENCIA = :DCLRELATORIOS.RELATORI-DATA-REFERENCIA, TIMESTAMP = CURRENT TIMESTAMP WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0634B' END-EXEC. */

            var r1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 = new R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1()
            {
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
            };

            R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1.Execute(r1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -1471- CLOSE MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -1484- MOVE 'R9999-00-FINALIZAR ' TO PARAGRAFO. */
            _.Move("R9999-00-FINALIZAR ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1485- IF W-FIM-MOVTO-FIDELIZ = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM")
            {

                /*" -1486- DISPLAY 'PF0634B - FIM NORMAL' */
                _.Display($"PF0634B - FIM NORMAL");

                /*" -1488- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1490- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1490- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1493- ELSE */
            }
            else
            {


                /*" -1494- DISPLAY LOCALIZA-ABEND-1 */
                _.Display(WABEND.LOCALIZA_ABEND_1);

                /*" -1496- DISPLAY LOCALIZA-ABEND-2 */
                _.Display(WABEND.LOCALIZA_ABEND_2);

                /*" -1497- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_3.WSQLCODE);

                /*" -1498- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_3.WSQLERRD1);

                /*" -1499- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_3.WSQLERRD2);

                /*" -1500- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -1502- DISPLAY '*** PF0634B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0634B *** ROLLBACK EM ANDAMENTO ...");

                /*" -1504- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1504- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -1508- MOVE 99 TO RETURN-CODE. */
                _.Move(99, RETURN_CODE);
            }


            /*" -1508- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}