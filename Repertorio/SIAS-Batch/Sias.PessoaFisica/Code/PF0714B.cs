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
using Sias.PessoaFisica.DB2.PF0714B;

namespace Code
{
    public class PF0714B
    {
        public bool IsCall { get; set; }

        public PF0714B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ...............  GERA STATUS DE EMISSAO DO NOVO VIDA  *      */
        /*"      *                           EMPRESARIAL A CEF                    *      */
        /*"      *   ANALISE/PROGRAMACAO...  LUIZ CARLOS.                         *      */
        /*"      *   PROGRAMA .............  PF0714B                              *      */
        /*"      *   DATA (EM PRODUTO).....  29/07/2004.                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 07             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       06/10/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 06             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA                          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 05                                                      *      */
        /*"      * ATENDE CADMUS 73384                                            *      */
        /*"      *    ALTERACAO TEMPORARIA PARA VERIFICAR PROPOSTAS QUE NAO       *      */
        /*"      *    SENSIBILIZARAM O SIGPF A PARTIR A PARTIR DE 01/08/2012      *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.05          CLAUDIO FREITAS                          *      */
        /*"      *                       24/08/2012                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 4 - INCLUI ORIGEM_PROPOSTA <> 6                         *      */
        /*"      *            RETIRA APOLICE <> 109300000959 NO CURSOR PRINCIPAL  *      */
        /*"      * 30/01/2008 PROCURE POR V.04 - LUCIA VIEIRA                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 03 - INSERIR TRATAMENTO  APOLICE  109300000959          *      */
        /*"      *                                                                *      */
        /*"      * 21/01/2008 PROCURE POR V.03 - LUCIA VIEIRA                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 02 - DESPREZAR COD_PRODUTO_SIVPF IGUAL A 48. TRATA-SE   *      */
        /*"      *             DA INTERNALIZACAO DE APOLICE ESPECIFICA DE VIDA.   *      */
        /*"      *                                                                *      */
        /*"      * 27/11/2007 PROCURE POR V.02 - MAURICIO LINKE.                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 01          EM 26/09/2007   LUCIA VIEIRA                *      */
        /*"      *   INCLUI NO CURSOR PRINCIPAL  TABELA PRODUTOS_VGAP E UTILIZA   *      */
        /*"      *   ATRIBUTO ORIG_PRODUTO = 'GLOBAL'                             *      */
        /*"      * PROCURAR POR V.01                                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     *                                                                       */
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
        /*"01  WAREA-AUXILIAR.*/
        public PF0714B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0714B_WAREA_AUXILIAR();
        public class PF0714B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-TERNIV                  PIC X(001)  VALUE SPACES.*/
            public StringBasis W_FIM_TERNIV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05  W-FIM-MOVTO-CEF             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_CEF { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-AC-CONTROLE                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-IND-NIVEL                   PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_IND_NIVEL { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-INDEX                       PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_INDEX { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
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
            /*"    05  W-QTD-LD-TIPO-A               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-B               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-C               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_C { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-D               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_D { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-E               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_E { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-F               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_F { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-G               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_G { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-H               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_H { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-I               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_I { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-J               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_J { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-NSAS                        PIC 9(006)  VALUE ZEROS.*/
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-NSL                         PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-CONTROLE                    PIC 9(006)  VALUE ZEROS.*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-CONTROLE-TP-0               PIC 9(001)  VALUE ZERO.*/
            public IntBasis W_CONTROLE_TP_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0714B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0714B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0714B_FILLER_0(); _.Move(W_DATA_TRABALHO, _filler_0); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_0, W_DATA_TRABALHO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_DATA_TRABALHO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0714B_FILLER_0 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-COD-COBERTURA               PIC 9(004)  VALUE ZEROS.*/

                public _REDEF_PF0714B_FILLER_0()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER REDEFINES W-COD-COBERTURA.*/
            private _REDEF_PF0714B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0714B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0714B_FILLER_1(); _.Move(W_COD_COBERTURA, _filler_1); VarBasis.RedefinePassValue(W_COD_COBERTURA, _filler_1, W_COD_COBERTURA); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_COD_COBERTURA); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_COD_COBERTURA); }
            }  //Redefines
            public class _REDEF_PF0714B_FILLER_1 : VarBasis
            {
                /*"        10  W-SUBPRODUTO              PIC 9(003).*/
                public IntBasis W_SUBPRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        10  W-COBERTURA               PIC 9(001).*/
                public IntBasis W_COBERTURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0714B_FILLER_1()
                {
                    W_SUBPRODUTO.ValueChanged += OnValueChanged;
                    W_COBERTURA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0714B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0714B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0714B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0714B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0714B_W_DTMOVABE1()
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
            private _REDEF_PF0714B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0714B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0714B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0714B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0714B_W_DTMOVABE_I1()
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
            private _REDEF_PF0714B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0714B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0714B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0714B_W_DATA_SQL1 : VarBasis
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

                public _REDEF_PF0714B_W_DATA_SQL1()
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
            private _REDEF_PF0714B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0714B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0714B_FILLER_2(); _.Move(W_NR_SICOB, _filler_2); VarBasis.RedefinePassValue(W_NR_SICOB, _filler_2, W_NR_SICOB); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_NR_SICOB); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_NR_SICOB); }
            }  //Redefines
            public class _REDEF_PF0714B_FILLER_2 : VarBasis
            {
                /*"        07  W-NR-PROD-SICOB           PIC 9(003).*/
                public IntBasis W_NR_PROD_SICOB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  W-NR-NSAC-SICOB           PIC 9(006).*/
                public IntBasis W_NR_NSAC_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        07  W-NR-NSL-SICOB            PIC 9(006).*/
                public IntBasis W_NR_NSL_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05 W-CURSOR                       PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0714B_FILLER_2()
                {
                    W_NR_PROD_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSAC_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSL_SICOB.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_CURSOR { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CURSOR-MONTADO                          VALUE 1. */
							new SelectorItemBasis("CURSOR_MONTADO", "1"),
							/*" 88 CURSOR-N-MONTADO                        VALUE 2. */
							new SelectorItemBasis("CURSOR_N_MONTADO", "2")
                }
            };

            /*"    05 W-PROP-SASSE                   PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_PROP_SASSE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTA-SASSE-CADASTRADA               VALUE 1. */
							new SelectorItemBasis("PROPOSTA_SASSE_CADASTRADA", "1"),
							/*" 88 PROPOSTA-SASSE-N-CADASTRADA             VALUE 2. */
							new SelectorItemBasis("PROPOSTA_SASSE_N_CADASTRADA", "2")
                }
            };

            /*"    05 W-RCAPS                        PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_RCAPS { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-CADASTRADO                         VALUE 1. */
							new SelectorItemBasis("RCAP_CADASTRADO", "1"),
							/*" 88 RCAP-N-CADASTRADO                       VALUE 2. */
							new SelectorItemBasis("RCAP_N_CADASTRADO", "2")
                }
            };

            /*"    05 W-NIVEL                        PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_NIVEL { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 NIVEL-CADASTRADO                        VALUE 1. */
							new SelectorItemBasis("NIVEL_CADASTRADO", "1"),
							/*" 88 NIVEL-NAO-CADASTRADO                    VALUE 2. */
							new SelectorItemBasis("NIVEL_NAO_CADASTRADO", "2")
                }
            };

            /*"    05 W-HISTORICO                    PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_HISTORICO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HISTORICO-CADASTRADO                    VALUE 1. */
							new SelectorItemBasis("HISTORICO_CADASTRADO", "1"),
							/*" 88 HISTORICO-NAO-CADASTRADO                VALUE 2. */
							new SelectorItemBasis("HISTORICO_NAO_CADASTRADO", "2")
                }
            };

            /*"    05 W-TERMO                        PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TERMO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TERMO-CADASTRADO                        VALUE 1. */
							new SelectorItemBasis("TERMO_CADASTRADO", "1"),
							/*" 88 TERMO-NAO-CADASTRADO                    VALUE 2. */
							new SelectorItemBasis("TERMO_NAO_CADASTRADO", "2")
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
        public PF0714B_WABEND WABEND { get; set; } = new PF0714B_WABEND();
        public class PF0714B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0714B_FILLER_3 FILLER_3 { get; set; } = new PF0714B_FILLER_3();
            public class PF0714B_FILLER_3 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0714B  '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0714B  ");
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
            public PF0714B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0714B_LOCALIZA_ABEND_1();
            public class PF0714B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0714B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0714B_LOCALIZA_ABEND_2();
            public class PF0714B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Copies.LXFPF990 LXFPF990 { get; set; } = new Copies.LXFPF990();
        public Copies.LBFPF011 LBFPF011 { get; set; } = new Copies.LBFPF011();
        public Copies.LBFPF012 LBFPF012 { get; set; } = new Copies.LBFPF012();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.LXFPF004 LXFPF004 { get; set; } = new Copies.LXFPF004();
        public Copies.LBFPF160 LBFPF160 { get; set; } = new Copies.LBFPF160();
        public Copies.LBFPF991 LBFPF991 { get; set; } = new Copies.LBFPF991();
        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Copies.LBFPF200 LBFPF200 { get; set; } = new Copies.LBFPF200();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.TERMOADE TERMOADE { get; set; } = new Dclgens.TERMOADE();
        public Dclgens.VGCOMTRO VGCOMTRO { get; set; } = new Dclgens.VGCOMTRO();
        public Dclgens.VGTERNIV VGTERNIV { get; set; } = new Dclgens.VGTERNIV();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public PF0714B_MOVTO_CEF MOVTO_CEF { get; set; } = new PF0714B_MOVTO_CEF();
        public PF0714B_COBERTURAS COBERTURAS { get; set; } = new PF0714B_COBERTURAS();
        public PF0714B_TER_NIVEL TER_NIVEL { get; set; } = new PF0714B_TER_NIVEL();
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
            /*" -339- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -340- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -341- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -344- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -345- DISPLAY '*               PROGRAMA PF0714B               *' . */
            _.Display($"*               PROGRAMA PF0714B               *");

            /*" -346- DISPLAY '* GERA STATUS EMISSAO DO NOVO VIDA EMPRESARIAL *' . */
            _.Display($"* GERA STATUS EMISSAO DO NOVO VIDA EMPRESARIAL *");

            /*" -347- DISPLAY '*        VERSAO: 07 - 03/10/2014 - NSGD        *' . */
            _.Display($"*        VERSAO: 07 - 03/10/2014 - NSGD        *");

            /*" -348- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -358- DISPLAY '*  PF0714B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0714B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -360- PERFORM R0001-00-INICIALIZAR. */

            R0001_00_INICIALIZAR_SECTION();

            /*" -362- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -364- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -366- PERFORM R0070-00-LER-MOVTO */

            R0070_00_LER_MOVTO_SECTION();

            /*" -367- IF W-FIM-MOVTO-CEF EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_CEF == "FIM")
            {

                /*" -368- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -369- DISPLAY '*  PF0714B - TEMINO NORMAL, NAO HOUVE      *' */
                _.Display($"*  PF0714B - TEMINO NORMAL, NAO HOUVE      *");

                /*" -370- DISPLAY '*            MOVIMENTO NA DATA SOLICITADA  *' */
                _.Display($"*            MOVIMENTO NA DATA SOLICITADA  *");

                /*" -371- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -372- PERFORM R1100-00-GERAR-TOTAIS */

                R1100_00_GERAR_TOTAIS_SECTION();

                /*" -373- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -375- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -377- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -380- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-CEF EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_CEF == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -382- PERFORM R1000-00-GERAR-TRAILLER. */

            R1000_00_GERAR_TRAILLER_SECTION();

            /*" -384- PERFORM R1050-00-CONTROLAR-ARQ-ENVIADO */

            R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -386- PERFORM R1100-00-GERAR-TOTAIS. */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -388- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -388- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0001-00-INICIALIZAR-SECTION */
        private void R0001_00_INICIALIZAR_SECTION()
        {
            /*" -396- MOVE 'R0001-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0001-00-INICIALIZAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -398- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -400- INITIALIZE REG-TRAILLER, REG-TRAILLER-STA. */
            _.Initialize(
                LBFPF991.REG_TRAILLER
                , LBFCT011.REG_TRAILLER_STA
            );

            /*" -402- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -404- MOVE 'VG' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("VG", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -412- PERFORM R0001_00_INICIALIZAR_DB_SELECT_1 */

            R0001_00_INICIALIZAR_DB_SELECT_1();

            /*" -417- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -419- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -421- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -424- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -428- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -431- DISPLAY '*  PF0714B - DATA PROCESSAMENTO...' W-DTMOVABE-I1. */
            _.Display($"*  PF0714B - DATA PROCESSAMENTO...{WAREA_AUXILIAR.W_DTMOVABE_I1}");

            /*" -433- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -435- OPEN OUTPUT MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

            /*" -435- MOVE 1 TO W-CURSOR. */
            _.Move(1, WAREA_AUXILIAR.W_CURSOR);

        }

        [StopWatch]
        /*" R0001-00-INICIALIZAR-DB-SELECT-1 */
        public void R0001_00_INICIALIZAR_DB_SELECT_1()
        {
            /*" -412- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :WHOST-DATA-REFERENCIA FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0001_00_INICIALIZAR_DB_SELECT_1_Query1 = new R0001_00_INICIALIZAR_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0001_00_INICIALIZAR_DB_SELECT_1_Query1.Execute(r0001_00_INICIALIZAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA_REFERENCIA, WHOST_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -444- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -446- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -449- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -452- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -461- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -464- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -465- DISPLAY 'PF0714B - FIM ANORMAL' */
                _.Display($"PF0714B - FIM ANORMAL");

                /*" -466- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -468- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -469- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -471- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -474- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -476- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -476- MOVE W-NSAS TO RH-NSAS OF REG-HEADER-STA. */
            _.Move(WAREA_AUXILIAR.W_NSAS, LBFCT011.REG_HEADER_STA.RH_NSAS);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -461- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

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
            /*" -486- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -488- MOVE 'DECLER MOVIMENTO' TO COMANDO. */
            _.Move("DECLER MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -489- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -491- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -494- DISPLAY '** PF0714B ** INICIO DECLARE V0MOVIMENTO...  ' W-TIME-EDIT. */
            _.Display($"** PF0714B ** INICIO DECLARE V0MOVIMENTO...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -496- MOVE 16 TO PROPOFID-COD-PRODUTO-SIVPF */
            _.Move(16, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);

            /*" -498- MOVE 'GLOBAL' TO PRODUVG-ORIG-PRODU */
            _.Move("GLOBAL", PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);

            /*" -554- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -556- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -560- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -563- MOVE 2 TO W-CURSOR. */
                _.Move(2, WAREA_AUXILIAR.W_CURSOR);
            }


            /*" -564- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -566- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -568- DISPLAY '** PF0714B ** FIM    DECLARE V0MOVIMENTO...  ' W-TIME-EDIT */
            _.Display($"** PF0714B ** FIM    DECLARE V0MOVIMENTO...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -568- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -554- EXEC SQL DECLARE MOVTO-CEF CURSOR FOR SELECT A.NUM_CERTIFICADO , A.DTINCLUS , A.DATA_QUITACAO , A.NUM_APOLICE , A.COD_SUBGRUPO , B.NUM_TERMO , C.NUM_PROPOSTA_SIVPF , C.NUM_IDENTIFICACAO , C.SIT_PROPOSTA , C.COD_EMPRESA_SIVPF , C.COD_PRODUTO_SIVPF , C.VAL_PAGO FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.VG_COMPL_TERMO B, SEGUROS.PROPOSTA_FIDELIZ C, SEGUROS.PRODUTOS_VG D WHERE D.ORIG_PRODU = :PRODUVG-ORIG-PRODU AND A.NUM_APOLICE = D.NUM_APOLICE AND A.SIT_REGISTRO = '3' AND A.DTINCLUS = :SISTEMAS-DATA-MOV-ABERTO AND C.NUM_PROPOSTA_SIVPF = A.NUM_CERTIFICADO AND C.COD_PRODUTO_SIVPF = :PROPOFID-COD-PRODUTO-SIVPF AND B.NUM_PROPOSTA_SIVPF = C.NUM_PROPOSTA_SIVPF AND C.ORIGEM_PROPOSTA <> 6 UNION SELECT A.NUM_CERTIFICADO , A.DTINCLUS , A.DATA_QUITACAO , A.NUM_APOLICE , A.COD_SUBGRUPO , B.NUM_TERMO , C.NUM_PROPOSTA_SIVPF , C.NUM_IDENTIFICACAO , C.SIT_PROPOSTA , C.COD_EMPRESA_SIVPF , C.COD_PRODUTO_SIVPF , C.VAL_PAGO FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.VG_COMPL_TERMO B, SEGUROS.PROPOSTA_FIDELIZ C, SEGUROS.PRODUTOS_VG D WHERE D.ORIG_PRODU = :PRODUVG-ORIG-PRODU AND A.NUM_APOLICE = D.NUM_APOLICE AND A.SIT_REGISTRO = '3' AND A.DTINCLUS = :SISTEMAS-DATA-MOV-ABERTO AND C.NUM_SICOB = A.NUM_CERTIFICADO AND C.COD_PRODUTO_SIVPF = :PROPOFID-COD-PRODUTO-SIVPF AND B.NUM_PROPOSTA_SIVPF = C.NUM_PROPOSTA_SIVPF AND C.ORIGEM_PROPOSTA <> 6 WITH UR END-EXEC. */
            MOVTO_CEF = new PF0714B_MOVTO_CEF(true);
            string GetQuery_MOVTO_CEF()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.DTINCLUS
							, 
							A.DATA_QUITACAO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							B.NUM_TERMO
							, 
							C.NUM_PROPOSTA_SIVPF
							, 
							C.NUM_IDENTIFICACAO
							, 
							C.SIT_PROPOSTA
							, 
							C.COD_EMPRESA_SIVPF
							, 
							C.COD_PRODUTO_SIVPF
							, 
							C.VAL_PAGO 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.VG_COMPL_TERMO B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C
							, 
							SEGUROS.PRODUTOS_VG D 
							WHERE D.ORIG_PRODU = '{PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU}' 
							AND A.NUM_APOLICE = D.NUM_APOLICE 
							AND A.SIT_REGISTRO = '3' 
							AND A.DTINCLUS = 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND C.NUM_PROPOSTA_SIVPF = A.NUM_CERTIFICADO 
							AND C.COD_PRODUTO_SIVPF = '{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}' 
							AND B.NUM_PROPOSTA_SIVPF = C.NUM_PROPOSTA_SIVPF 
							AND C.ORIGEM_PROPOSTA <> 6 
							UNION 
							SELECT A.NUM_CERTIFICADO
							, 
							A.DTINCLUS
							, 
							A.DATA_QUITACAO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							B.NUM_TERMO
							, 
							C.NUM_PROPOSTA_SIVPF
							, 
							C.NUM_IDENTIFICACAO
							, 
							C.SIT_PROPOSTA
							, 
							C.COD_EMPRESA_SIVPF
							, 
							C.COD_PRODUTO_SIVPF
							, 
							C.VAL_PAGO 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.VG_COMPL_TERMO B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C
							, 
							SEGUROS.PRODUTOS_VG D 
							WHERE D.ORIG_PRODU = '{PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU}' 
							AND A.NUM_APOLICE = D.NUM_APOLICE 
							AND A.SIT_REGISTRO = '3' 
							AND A.DTINCLUS = 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND C.NUM_SICOB = A.NUM_CERTIFICADO 
							AND C.COD_PRODUTO_SIVPF = '{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}' 
							AND B.NUM_PROPOSTA_SIVPF = C.NUM_PROPOSTA_SIVPF 
							AND C.ORIGEM_PROPOSTA <> 6";

                return query;
            }
            MOVTO_CEF.GetQueryEvent += GetQuery_MOVTO_CEF;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -556- EXEC SQL OPEN MOVTO-CEF END-EXEC. */

            MOVTO_CEF.Open();

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-DECLARE-1 */
        public void R0450_00_OBTER_COBERTURA_DB_DECLARE_1()
        {
            /*" -836- EXEC SQL DECLARE COBERTURAS CURSOR FOR SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMP_MORNATU , IMPMORACID , IMPINVPERM FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO ORDER BY OCORR_HISTORICO WITH UR END-EXEC. */
            COBERTURAS = new PF0714B_COBERTURAS(true);
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
							FROM SEGUROS.HIS_COBER_PROPOST 
							WHERE NUM_CERTIFICADO = '{HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}' 
							ORDER BY OCORR_HISTORICO";

                return query;
            }
            COBERTURAS.GetQueryEvent += GetQuery_COBERTURAS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -578- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -580- MOVE 'FETCH MOVTO-CEF' TO COMANDO. */
            _.Move("FETCH MOVTO-CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -594- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -597- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -598- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -599- MOVE 'FIM' TO W-FIM-MOVTO-CEF */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_CEF);

                    /*" -599- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -601- ELSE */
                }
                else
                {


                    /*" -602- DISPLAY 'PF0714B - FIM ANORMAL' */
                    _.Display($"PF0714B - FIM ANORMAL");

                    /*" -604- DISPLAY '          ERRO FETCH CURSOR V0MOVIMENTO  ' SQLCODE */
                    _.Display($"          ERRO FETCH CURSOR V0MOVIMENTO  {DB.SQLCODE}");

                    /*" -605- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -606- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -608- ELSE */
                }

            }
            else
            {


                /*" -611- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -612- IF W-CONTROLE > 999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 999)
                {

                    /*" -613- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -614- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -615- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -616- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -618- DISPLAY '** PF0714B ** TOTAL LIDO ..  ' W-NSL ' ' W-TIME-EDIT */

                    $"** PF0714B ** TOTAL LIDO ..  {WAREA_AUXILIAR.W_NSL} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -618- DISPLAY ' ' . */
                    _.Display($" ");
                }

            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -594- EXEC SQL FETCH MOVTO-CEF INTO :PROPOVA-NUM-CERTIFICADO , :PROPOVA-DTINCLUS , :PROPOVA-DATA-QUITACAO , :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO , :VGCOMTRO-NUM-TERMO , :PROPOFID-NUM-PROPOSTA-SIVPF , :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-SIT-PROPOSTA , :PROPOFID-COD-EMPRESA-SIVPF , :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-VAL-PAGO END-EXEC. */

            if (MOVTO_CEF.Fetch())
            {
                _.Move(MOVTO_CEF.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(MOVTO_CEF.PROPOVA_DTINCLUS, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS);
                _.Move(MOVTO_CEF.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(MOVTO_CEF.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(MOVTO_CEF.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(MOVTO_CEF.VGCOMTRO_NUM_TERMO, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_TERMO);
                _.Move(MOVTO_CEF.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(MOVTO_CEF.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(MOVTO_CEF.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(MOVTO_CEF.PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(MOVTO_CEF.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(MOVTO_CEF.PROPOFID_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -599- EXEC SQL CLOSE MOVTO-CEF END-EXEC */

            MOVTO_CEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -628- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -630- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -633- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -636- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -639- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-SQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -640- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -641- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -643- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -646- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -649- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -652- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -652- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -662- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -664- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -666- PERFORM R0200-00-LER-RCAPS */

            R0200_00_LER_RCAPS_SECTION();

            /*" -667- IF RCAP-N-CADASTRADO */

            if (WAREA_AUXILIAR.W_RCAPS["RCAP_N_CADASTRADO"])
            {

                /*" -669- MOVE PROPOFID-VAL-PAGO TO RCAPS-VAL-RCAP OF DCLRCAPS. */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


            /*" -671- PERFORM R0220-00-LER-TERMO */

            R0220_00_LER_TERMO_SECTION();

            /*" -672- IF TERMO-NAO-CADASTRADO */

            if (WAREA_AUXILIAR.W_TERMO["TERMO_NAO_CADASTRADO"])
            {

                /*" -673- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -676- DISPLAY 'PF0714B - TERMO ADESAO NAO CADASTRADO ==> ' PROPOFID-NUM-PROPOSTA-SIVPF '  ' TERMOADE-NUM-TERMO */

                $"PF0714B - TERMO ADESAO NAO CADASTRADO ==> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}  {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}"
                .Display();

                /*" -678- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -680- PERFORM R0450-00-OBTER-COBERTURA. */

            R0450_00_OBTER_COBERTURA_SECTION();

            /*" -681- IF COBERTURA-NAO-CADASTRADA */

            if (WAREA_AUXILIAR.W_COBERTURAS["COBERTURA_NAO_CADASTRADA"])
            {

                /*" -682- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -685- DISPLAY 'PF0714B - COBERTURA NAO CADASTRADA ==========> ' PROPOVA-NUM-CERTIFICADO '  ' TERMOADE-NUM-TERMO */

                $"PF0714B - COBERTURA NAO CADASTRADA ==========> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}  {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}"
                .Display();

                /*" -687- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -693- INITIALIZE REG-STA-PROPOSTA REG-APOL-SASSE REG-COBER-SASSE REG-PGTO-SASSE R5-REG-QTDE-VIDAS-VE. */
            _.Initialize(
                LBFCT011.REG_STA_PROPOSTA
                , LBFCT016.REG_APOL_SASSE
                , LBFCT016.REG_COBER_SASSE
                , LBFCT016.REG_PGTO_SASSE
                , LBFPF200.R5_REG_QTDE_VIDAS_VE
            );

            /*" -696- MOVE 1 TO W-IND-NIVEL W-NIVEL. */
            _.Move(1, WAREA_AUXILIAR.W_IND_NIVEL, WAREA_AUXILIAR.W_NIVEL);

            /*" -698- PERFORM R0580-00-LER-HIST-FIDELIZ */

            R0580_00_LER_HIST_FIDELIZ_SECTION();

            /*" -699- IF HISTORICO-CADASTRADO */

            if (WAREA_AUXILIAR.W_HISTORICO["HISTORICO_CADASTRADO"])
            {

                /*" -700- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -703- DISPLAY 'PF0714B - MOVIMENTO GERADO ANTERIORMENTE ====> ' PROPOFID-NUM-PROPOSTA-SIVPF '  ' TERMOADE-NUM-TERMO */

                $"PF0714B - MOVIMENTO GERADO ANTERIORMENTE ====> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}  {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}"
                .Display();

                /*" -705- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -707- PERFORM R0710-OBTER-NIVEL-EMPRESA */

            R0710_OBTER_NIVEL_EMPRESA_SECTION();

            /*" -709- PERFORM R0715-FETCH-NIVEL-EMPRESA. */

            R0715_FETCH_NIVEL_EMPRESA_SECTION();

            /*" -712- PERFORM R0720-MONTA-NIVEL-CARGO UNTIL W-FIM-TERNIV = 'S' . */

            while (!(WAREA_AUXILIAR.W_FIM_TERNIV == "S"))
            {

                R0720_MONTA_NIVEL_CARGO_SECTION();
            }

            /*" -713- PERFORM R0800-00-STATUS-REGISTRO-TP1 */

            R0800_00_STATUS_REGISTRO_TP1_SECTION();

            /*" -714- PERFORM R0850-00-STATUS-REGISTRO-TP2 */

            R0850_00_STATUS_REGISTRO_TP2_SECTION();

            /*" -715- PERFORM R0900-00-STATUS-REGISTRO-TP3 */

            R0900_00_STATUS_REGISTRO_TP3_SECTION();

            /*" -716- PERFORM R0950-00-STATUS-REGISTRO-TP4 */

            R0950_00_STATUS_REGISTRO_TP4_SECTION();

            /*" -717- PERFORM R0970-00-STATUS-REGISTRO-TP5 */

            R0970_00_STATUS_REGISTRO_TP5_SECTION();

            /*" -718- PERFORM R3390-GERA-HIST-FIDELIZACAO. */

            R3390_GERA_HIST_FIDELIZACAO_SECTION();

            /*" -719- PERFORM R3400-00-ATUALIZA-PROPOSTA. */

            R3400_00_ATUALIZA_PROPOSTA_SECTION();

            /*" -721- PERFORM R3450-00-LER-PROP-SASSE-VIDA. */

            R3450_00_LER_PROP_SASSE_VIDA_SECTION();

            /*" -722- IF PROPOSTA-SASSE-CADASTRADA */

            if (WAREA_AUXILIAR.W_PROP_SASSE["PROPOSTA_SASSE_CADASTRADA"])
            {

                /*" -722- PERFORM R3500-00-PROP-SASSE-VIDA. */

                R3500_00_PROP_SASSE_VIDA_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0150_LEITURA */

            R0150_LEITURA();

        }

        [StopWatch]
        /*" R0150-LEITURA */
        private void R0150_LEITURA(bool isPerform = false)
        {
            /*" -727- IF W-FIM-MOVTO-CEF NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_CEF != "FIM")
            {

                /*" -727- PERFORM R0070-00-LER-MOVTO. */

                R0070_00_LER_MOVTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0200-00-LER-RCAPS-SECTION */
        private void R0200_00_LER_RCAPS_SECTION()
        {
            /*" -737- MOVE 'R0200-00-LER-RCAPS' TO PARAGRAFO. */
            _.Move("R0200-00-LER-RCAPS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -739- MOVE 'SELECT TABELA RCAPS' TO COMANDO. */
            _.Move("SELECT TABELA RCAPS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -741- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO RCAPS-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -749- PERFORM R0200_00_LER_RCAPS_DB_SELECT_1 */

            R0200_00_LER_RCAPS_DB_SELECT_1();

            /*" -752- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -753- MOVE 1 TO W-RCAPS */
                _.Move(1, WAREA_AUXILIAR.W_RCAPS);

                /*" -754- ELSE */
            }
            else
            {


                /*" -755- IF SQLCODE EQUAL 100 OR -811 */

                if (DB.SQLCODE.In("100", "-811"))
                {

                    /*" -756- MOVE 2 TO W-RCAPS */
                    _.Move(2, WAREA_AUXILIAR.W_RCAPS);

                    /*" -757- ELSE */
                }
                else
                {


                    /*" -758- DISPLAY 'PF0714B - FIM ANORMAL' */
                    _.Display($"PF0714B - FIM ANORMAL");

                    /*" -759- DISPLAY '          ERRO SELECT TABELA RCAPS' */
                    _.Display($"          ERRO SELECT TABELA RCAPS");

                    /*" -761- DISPLAY '          NUMERO CERTIFICDO...... ' RCAPS-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICDO...... {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO}");

                    /*" -763- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -764- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -764- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0200-00-LER-RCAPS-DB-SELECT-1 */
        public void R0200_00_LER_RCAPS_DB_SELECT_1()
        {
            /*" -749- EXEC SQL SELECT VAL_RCAP INTO :RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0200_00_LER_RCAPS_DB_SELECT_1_Query1 = new R0200_00_LER_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0200_00_LER_RCAPS_DB_SELECT_1_Query1.Execute(r0200_00_LER_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0220-00-LER-TERMO-SECTION */
        private void R0220_00_LER_TERMO_SECTION()
        {
            /*" -774- MOVE 'R0220-00-LER-TERMO' TO PARAGRAFO. */
            _.Move("R0220-00-LER-TERMO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -776- MOVE 'SELECT TERMO-ADESAO' TO COMANDO. */
            _.Move("SELECT TERMO-ADESAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -778- MOVE VGCOMTRO-NUM-TERMO TO TERMOADE-NUM-TERMO */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_TERMO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO);

            /*" -788- PERFORM R0220_00_LER_TERMO_DB_SELECT_1 */

            R0220_00_LER_TERMO_DB_SELECT_1();

            /*" -791- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -792- MOVE 1 TO W-TERMO */
                _.Move(1, WAREA_AUXILIAR.W_TERMO);

                /*" -793- ELSE */
            }
            else
            {


                /*" -794- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -795- MOVE 2 TO W-TERMO */
                    _.Move(2, WAREA_AUXILIAR.W_TERMO);

                    /*" -796- ELSE */
                }
                else
                {


                    /*" -797- DISPLAY 'PF0714B - FIM ANORMAL' */
                    _.Display($"PF0714B - FIM ANORMAL");

                    /*" -798- DISPLAY '          ERRO SELECT TERMO ADESAO' */
                    _.Display($"          ERRO SELECT TERMO ADESAO");

                    /*" -800- DISPLAY '          NUMERO PROPOSTA........ ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO PROPOSTA........ {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -802- DISPLAY '          NUMERO DO TERMO........ ' TERMOADE-NUM-TERMO */
                    _.Display($"          NUMERO DO TERMO........ {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -804- DISPLAY '          SQLCODE................ ' SQLCODE */
                    _.Display($"          SQLCODE................ {DB.SQLCODE}");

                    /*" -805- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -805- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0220-00-LER-TERMO-DB-SELECT-1 */
        public void R0220_00_LER_TERMO_DB_SELECT_1()
        {
            /*" -788- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO, DATA_ADESAO INTO :TERMOADE-NUM-APOLICE , :TERMOADE-COD-SUBGRUPO, :TERMOADE-DATA-ADESAO FROM SEGUROS.TERMO_ADESAO WHERE NUM_TERMO = :TERMOADE-NUM-TERMO WITH UR END-EXEC. */

            var r0220_00_LER_TERMO_DB_SELECT_1_Query1 = new R0220_00_LER_TERMO_DB_SELECT_1_Query1()
            {
                TERMOADE_NUM_TERMO = TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO.ToString(),
            };

            var executed_1 = R0220_00_LER_TERMO_DB_SELECT_1_Query1.Execute(r0220_00_LER_TERMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TERMOADE_NUM_APOLICE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE);
                _.Move(executed_1.TERMOADE_COD_SUBGRUPO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO);
                _.Move(executed_1.TERMOADE_DATA_ADESAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_SAIDA*/

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-SECTION */
        private void R0450_00_OBTER_COBERTURA_SECTION()
        {
            /*" -815- MOVE 'R0450-00-OBTER-COBERTURA' TO PARAGRAFO. */
            _.Move("R0450-00-OBTER-COBERTURA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -817- MOVE 'SELECT COBERPROPVA' TO COMANDO. */
            _.Move("SELECT COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -819- MOVE PROPOVA-NUM-CERTIFICADO TO HISCOBPR-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);

            /*" -821- MOVE 2 TO W-COBERTURAS */
            _.Move(2, WAREA_AUXILIAR.W_COBERTURAS);

            /*" -836- PERFORM R0450_00_OBTER_COBERTURA_DB_DECLARE_1 */

            R0450_00_OBTER_COBERTURA_DB_DECLARE_1();

            /*" -838- PERFORM R0450_00_OBTER_COBERTURA_DB_OPEN_1 */

            R0450_00_OBTER_COBERTURA_DB_OPEN_1();

            /*" -841- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -842- DISPLAY 'PF0714B - FIM ANORMAL' */
                _.Display($"PF0714B - FIM ANORMAL");

                /*" -843- DISPLAY '          ERRO OPEN DO CURSOR COBERTURAS' */
                _.Display($"          ERRO OPEN DO CURSOR COBERTURAS");

                /*" -845- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -847- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -849- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -850- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -852- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -861- PERFORM R0450_00_OBTER_COBERTURA_DB_FETCH_1 */

            R0450_00_OBTER_COBERTURA_DB_FETCH_1();

            /*" -864- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -865- DISPLAY 'PF0714B - FIM ANORMAL' */
                _.Display($"PF0714B - FIM ANORMAL");

                /*" -866- DISPLAY '          ERRO FETCH DO CURSOR COBERTURAS' */
                _.Display($"          ERRO FETCH DO CURSOR COBERTURAS");

                /*" -868- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -870- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -872- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -873- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -875- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -875- PERFORM R0450_00_OBTER_COBERTURA_DB_CLOSE_1 */

            R0450_00_OBTER_COBERTURA_DB_CLOSE_1();

            /*" -878- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -879- DISPLAY 'PF0714B - FIM ANORMAL' */
                _.Display($"PF0714B - FIM ANORMAL");

                /*" -880- DISPLAY '          ERRO CLOSE DO CURSOR COBERTURAS' */
                _.Display($"          ERRO CLOSE DO CURSOR COBERTURAS");

                /*" -882- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -884- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -886- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -887- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -889- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -889- MOVE 1 TO W-COBERTURAS. */
            _.Move(1, WAREA_AUXILIAR.W_COBERTURAS);

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-OPEN-1 */
        public void R0450_00_OBTER_COBERTURA_DB_OPEN_1()
        {
            /*" -838- EXEC SQL OPEN COBERTURAS END-EXEC. */

            COBERTURAS.Open();

        }

        [StopWatch]
        /*" R0710-OBTER-NIVEL-EMPRESA-DB-DECLARE-1 */
        public void R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1()
        {
            /*" -969- EXEC SQL DECLARE TER-NIVEL CURSOR FOR SELECT NUM_PROPOSTA_SIVPF, DTH_INI_VIGENCIA , NUM_NIVEL_CARGO , DTH_FIM_VIGENCIA , IMP_SEGURADA , VLR_PRM_INDIVIDUAL, QTD_VIDAS FROM SEGUROS.VG_TERMO_NIVEL WHERE NUM_PROPOSTA_SIVPF = :VGTERNIV-NUM-PROPOSTA-SIVPF AND DTH_INI_VIGENCIA <= :VGTERNIV-DTH-INI-VIGENCIA AND DTH_FIM_VIGENCIA >= :VGTERNIV-DTH-INI-VIGENCIA ORDER BY NUM_NIVEL_CARGO WITH UR END-EXEC. */
            TER_NIVEL = new PF0714B_TER_NIVEL(true);
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
							AND DTH_INI_VIGENCIA <= '{VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA}' 
							AND DTH_FIM_VIGENCIA >= '{VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA}' 
							ORDER BY NUM_NIVEL_CARGO";

                return query;
            }
            TER_NIVEL.GetQueryEvent += GetQuery_TER_NIVEL;

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-FETCH-1 */
        public void R0450_00_OBTER_COBERTURA_DB_FETCH_1()
        {
            /*" -861- EXEC SQL FETCH COBERTURAS INTO :HISCOBPR-NUM-CERTIFICADO , :HISCOBPR-OCORR-HISTORICO , :HISCOBPR-DATA-INIVIGENCIA , :HISCOBPR-DATA-TERVIGENCIA , :HISCOBPR-IMP-MORNATU , :HISCOBPR-IMPMORACID , :HISCOBPR-IMPINVPERM END-EXEC. */

            if (COBERTURAS.Fetch())
            {
                _.Move(COBERTURAS.HISCOBPR_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);
                _.Move(COBERTURAS.HISCOBPR_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);
                _.Move(COBERTURAS.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(COBERTURAS.HISCOBPR_DATA_TERVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);
                _.Move(COBERTURAS.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(COBERTURAS.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
                _.Move(COBERTURAS.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);
            }

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-CLOSE-1 */
        public void R0450_00_OBTER_COBERTURA_DB_CLOSE_1()
        {
            /*" -875- EXEC SQL CLOSE COBERTURAS END-EXEC. */

            COBERTURAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_SAIDA*/

        [StopWatch]
        /*" R0580-00-LER-HIST-FIDELIZ-SECTION */
        private void R0580_00_LER_HIST_FIDELIZ_SECTION()
        {
            /*" -899- MOVE 'R0580-00-LER-HIST-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0580-00-LER-HIST-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -901- MOVE 'SELECT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("SELECT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -904- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -906- MOVE 'EMT' TO PROPFIDH-SIT-PROPOSTA. */
            _.Move("EMT", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -909- MOVE PROPOVA-DTINCLUS TO PROPFIDH-DATA-SITUACAO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -920- PERFORM R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1 */

            R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1();

            /*" -923- IF SQLCODE NOT EQUAL 00 AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -924- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -925- MOVE 2 TO W-HISTORICO */
                    _.Move(2, WAREA_AUXILIAR.W_HISTORICO);

                    /*" -926- ELSE */
                }
                else
                {


                    /*" -927- DISPLAY 'PF0714B - FIM ANORMAL' */
                    _.Display($"PF0714B - FIM ANORMAL");

                    /*" -928- DISPLAY '          ERRO ACESSO HIST-PROP-FIDELIZ' */
                    _.Display($"          ERRO ACESSO HIST-PROP-FIDELIZ");

                    /*" -931- DISPLAY '          NUMERO DA PROPOSTA.. ' PROPOFID-NUM-PROPOSTA-SIVPF '   ' PROPOFID-NUM-IDENTIFICACAO */

                    $"          NUMERO DA PROPOSTA.. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}"
                    .Display();

                    /*" -933- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -934- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -935- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -936- ELSE */
                }

            }
            else
            {


                /*" -936- MOVE 1 TO W-HISTORICO. */
                _.Move(1, WAREA_AUXILIAR.W_HISTORICO);
            }


        }

        [StopWatch]
        /*" R0580-00-LER-HIST-FIDELIZ-DB-SELECT-1 */
        public void R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1()
        {
            /*" -920- EXEC SQL SELECT NUM_IDENTIFICACAO INTO :PROPFIDH-NUM-IDENTIFICACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPFIDH-NUM-IDENTIFICACAO AND SIT_PROPOSTA = :PROPFIDH-SIT-PROPOSTA WITH UR END-EXEC. */

            var r0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1 = new R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
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
            /*" -943- MOVE 'R0710-OBTER-NIVEL-EMPRESA  ' TO PARAGRAFO. */
            _.Move("R0710-OBTER-NIVEL-EMPRESA  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -945- MOVE 'DECLARE CURSOR TER-NIVEL' TO COMANDO. */
            _.Move("DECLARE CURSOR TER-NIVEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -947- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO VGTERNIV-NUM-PROPOSTA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF);

            /*" -948- MOVE TERMOADE-DATA-ADESAO TO VGTERNIV-DTH-INI-VIGENCIA. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA);

            /*" -950- MOVE 'N' TO W-FIM-TERNIV. */
            _.Move("N", WAREA_AUXILIAR.W_FIM_TERNIV);

            /*" -969- PERFORM R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1 */

            R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1();

            /*" -973- MOVE 'OPEN CURSOR TER-NIVEL' TO COMANDO. */
            _.Move("OPEN CURSOR TER-NIVEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -973- PERFORM R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1 */

            R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1();

            /*" -976- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -979- DISPLAY 'PF0714B - ERRO NO OPEN DO CURSOR TER-NIVEL ' SQLCODE '  ' VGTERNIV-NUM-PROPOSTA-SIVPF '  ' VGTERNIV-DTH-INI-VIGENCIA */

                $"PF0714B - ERRO NO OPEN DO CURSOR TER-NIVEL {DB.SQLCODE}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA}"
                .Display();

                /*" -980- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -980- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0710-OBTER-NIVEL-EMPRESA-DB-OPEN-1 */
        public void R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1()
        {
            /*" -973- EXEC SQL OPEN TER-NIVEL END-EXEC. */

            TER_NIVEL.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_SAIDA*/

        [StopWatch]
        /*" R0715-FETCH-NIVEL-EMPRESA-SECTION */
        private void R0715_FETCH_NIVEL_EMPRESA_SECTION()
        {
            /*" -987- MOVE 'R0715-FETCH-NIVEL-EMPRESA' TO PARAGRAFO. */
            _.Move("R0715-FETCH-NIVEL-EMPRESA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -989- MOVE 'FETCH CURSOR TER-NIVEL' TO COMANDO. */
            _.Move("FETCH CURSOR TER-NIVEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -999- PERFORM R0715_FETCH_NIVEL_EMPRESA_DB_FETCH_1 */

            R0715_FETCH_NIVEL_EMPRESA_DB_FETCH_1();

            /*" -1002- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1003- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1004- MOVE 'S' TO W-FIM-TERNIV */
                    _.Move("S", WAREA_AUXILIAR.W_FIM_TERNIV);

                    /*" -1004- PERFORM R0715_FETCH_NIVEL_EMPRESA_DB_CLOSE_1 */

                    R0715_FETCH_NIVEL_EMPRESA_DB_CLOSE_1();

                    /*" -1006- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1009- DISPLAY 'PF0714B - ERRO CLOSE DO CURSOR TER-NIVEL ' SQLCODE '  ' VGTERNIV-NUM-PROPOSTA-SIVPF '  ' VGTERNIV-DTH-INI-VIGENCIA */

                        $"PF0714B - ERRO CLOSE DO CURSOR TER-NIVEL {DB.SQLCODE}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA}"
                        .Display();

                        /*" -1010- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1011- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -1013- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -1014- ELSE */
                    }

                }
                else
                {


                    /*" -1017- DISPLAY 'PF0714B - ERRO NO FETCH DO CURSOR TER-NIVEL ' SQLCODE '  ' VGTERNIV-NUM-PROPOSTA-SIVPF '  ' VGTERNIV-DTH-INI-VIGENCIA */

                    $"PF0714B - ERRO NO FETCH DO CURSOR TER-NIVEL {DB.SQLCODE}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA}"
                    .Display();

                    /*" -1018- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1018- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0715-FETCH-NIVEL-EMPRESA-DB-FETCH-1 */
        public void R0715_FETCH_NIVEL_EMPRESA_DB_FETCH_1()
        {
            /*" -999- EXEC SQL FETCH TER-NIVEL INTO :VGTERNIV-NUM-PROPOSTA-SIVPF, :VGTERNIV-DTH-INI-VIGENCIA , :VGTERNIV-NUM-NIVEL-CARGO , :VGTERNIV-DTH-FIM-VIGENCIA , :VGTERNIV-IMP-SEGURADA , :VGTERNIV-VLR-PRM-INDIVIDUAL, :VGTERNIV-QTD-VIDAS END-EXEC. */

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
            /*" -1004- EXEC SQL CLOSE TER-NIVEL END-EXEC */

            TER_NIVEL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0715_SAIDA*/

        [StopWatch]
        /*" R0720-MONTA-NIVEL-CARGO-SECTION */
        private void R0720_MONTA_NIVEL_CARGO_SECTION()
        {
            /*" -1025- MOVE 'R0720-MONTA-NIVEL-CARGO' TO PARAGRAFO. */
            _.Move("R0720-MONTA-NIVEL-CARGO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1027- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1028- MOVE VGTERNIV-NUM-NIVEL-CARGO TO R6-NIVEL-CARGO (W-IND-NIVEL) */
            _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_NIVEL_CARGO, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_NIVEIS_CARGO[WAREA_AUXILIAR.W_IND_NIVEL].R6_NIVEL_CARGO);

            /*" -1029- MOVE VGTERNIV-IMP-SEGURADA TO R6-IS-CARGO (W-IND-NIVEL) */
            _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_IMP_SEGURADA, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_NIVEIS_CARGO[WAREA_AUXILIAR.W_IND_NIVEL].R6_IS_CARGO);

            /*" -1031- MOVE VGTERNIV-QTD-VIDAS TO R6-VIDAS-CARGO (W-IND-NIVEL) */
            _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_QTD_VIDAS, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_NIVEIS_CARGO[WAREA_AUXILIAR.W_IND_NIVEL].R6_VIDAS_CARGO);

            /*" -1032- IF W-IND-NIVEL LESS 5 */

            if (WAREA_AUXILIAR.W_IND_NIVEL < 5)
            {

                /*" -1035- MOVE VGTERNIV-NUM-NIVEL-CARGO TO R5-NUM-NIVEL-CARGO (W-IND-NIVEL) */
                _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_NIVEL_CARGO, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_NOVO.R5_DADOS_NIVEL[WAREA_AUXILIAR.W_IND_NIVEL].R5_NUM_NIVEL_CARGO);

                /*" -1038- MOVE VGTERNIV-IMP-SEGURADA TO R5-IMP-SEGURADA (W-IND-NIVEL) */
                _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_IMP_SEGURADA, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_NOVO.R5_DADOS_NIVEL[WAREA_AUXILIAR.W_IND_NIVEL].R5_IMP_SEGURADA);

                /*" -1041- MOVE VGTERNIV-QTD-VIDAS TO R5-QUANTIDADE-VIDAS (W-IND-NIVEL). */
                _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_QTD_VIDAS, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_NOVO.R5_DADOS_NIVEL[WAREA_AUXILIAR.W_IND_NIVEL].R5_QUANTIDADE_VIDAS);
            }


            /*" -1042- IF W-IND-NIVEL GREATER 5 */

            if (WAREA_AUXILIAR.W_IND_NIVEL > 5)
            {

                /*" -1044- DISPLAY 'PF0714B - FIM ANORMAL, ESTOURO DE NIVEIS  ' SQLCODE '  ' VGTERNIV-NUM-PROPOSTA-SIVPF */

                $"PF0714B - FIM ANORMAL, ESTOURO DE NIVEIS  {DB.SQLCODE}  {VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}"
                .Display();

                /*" -1045- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1047- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1047- ADD 1 TO W-IND-NIVEL. */
            WAREA_AUXILIAR.W_IND_NIVEL.Value = WAREA_AUXILIAR.W_IND_NIVEL + 1;

            /*" -0- FLUXCONTROL_PERFORM R0720_NEXT */

            R0720_NEXT();

        }

        [StopWatch]
        /*" R0720-NEXT */
        private void R0720_NEXT(bool isPerform = false)
        {
            /*" -1051- PERFORM R0715-FETCH-NIVEL-EMPRESA. */

            R0715_FETCH_NIVEL_EMPRESA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0720_SAIDA*/

        [StopWatch]
        /*" R0800-00-STATUS-REGISTRO-TP1-SECTION */
        private void R0800_00_STATUS_REGISTRO_TP1_SECTION()
        {
            /*" -1063- MOVE 'R0800-00-STATUS-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0800-00-STATUS-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1066- MOVE '1' TO R1-TIPO-REG OF REG-STA-PROPOSTA. */
            _.Move("1", LBFCT011.REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -1069- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -1074- MOVE 'EMT' TO R1-SIT-PROPOSTA OF REG-STA-PROPOSTA PROPOFID-SIT-PROPOSTA PROPFIDH-SIT-PROPOSTA. */
            _.Move("EMT", LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1078- MOVE ZEROS TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(0, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -1081- MOVE PROPOVA-DTINCLUS TO W-DATA-SQL. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1082- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -1083- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -1085- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -1088- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -1090- ADD 1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + 1;

            /*" -1095- MOVE RH-NSAS OF REG-HEADER-STA TO R1-NSAS OF REG-STA-PROPOSTA PROPOFID-NSAS-SIVPF PROPFIDH-NSAS-SIVPF. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, LBFCT011.REG_STA_PROPOSTA.R1_NSAS, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -1100- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO R1-NSL OF REG-STA-PROPOSTA PROPOFID-NSL PROPFIDH-NSL. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, LBFCT011.REG_STA_PROPOSTA.R1_NSL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -1100- WRITE REG-STA-SASSE FROM REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-STATUS-REGISTRO-TP2-SECTION */
        private void R0850_00_STATUS_REGISTRO_TP2_SECTION()
        {
            /*" -1111- MOVE 'R0850-00-STATUS-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0850-00-STATUS-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1114- MOVE '2' TO R2-TIPO-REG OF REG-APOL-SASSE */
            _.Move("2", LBFCT016.REG_APOL_SASSE.R2_TIPO_REG);

            /*" -1116- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R2-NUM-PROPOSTA OF REG-APOL-SASSE */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT016.REG_APOL_SASSE.R2_NUM_PROPOSTA);

            /*" -1119- MOVE PROPOVA-NUM-CERTIFICADO TO R2-NRCERTIF OF REG-APOL-SASSE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, LBFCT016.REG_APOL_SASSE.R2_NRCERTIF);

            /*" -1122- MOVE VGTERNIV-DTH-INI-VIGENCIA TO W-DATA-SQL. */
            _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1123- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -1124- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -1126- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -1129- MOVE W-DATA-TRABALHO TO R2-DTINIVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTINIVIG);

            /*" -1132- MOVE VGTERNIV-DTH-FIM-VIGENCIA TO W-DATA-SQL. */
            _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1133- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -1134- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -1136- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -1139- MOVE W-DATA-TRABALHO TO R2-DTTERVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTTERVIG);

            /*" -1140- PERFORM R0860-LER-APOLICE */

            R0860_LER_APOLICE_SECTION();

            /*" -1142- PERFORM R0870-LER-RAMOIND */

            R0870_LER_RAMOIND_SECTION();

            /*" -1144- COMPUTE W-IND-IOF = (RAMOCOMP-PCT-IOCC-RAMO / 100) + 1 */
            WAREA_AUXILIAR.W_IND_IOF.Value = (RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f) + 1;

            /*" -1147- COMPUTE W-PRM-LIQ = RCAPS-VAL-RCAP OF DCLRCAPS / W-IND-IOF */
            WAREA_AUXILIAR.W_PRM_LIQ.Value = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP / WAREA_AUXILIAR.W_IND_IOF;

            /*" -1151- COMPUTE R2-VAL-IOF OF REG-APOL-SASSE ROUNDED = RCAPS-VAL-RCAP OF DCLRCAPS - W-PRM-LIQ */
            LBFCT016.REG_APOL_SASSE.R2_VAL_IOF.Value = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP - WAREA_AUXILIAR.W_PRM_LIQ;

            /*" -1153- MOVE W-PRM-LIQ TO R2-VAL-PREMIO OF REG-APOL-SASSE */
            _.Move(WAREA_AUXILIAR.W_PRM_LIQ, LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO);

            /*" -1155- ADD 1 TO RT-QTDE-TIPO-2 OF REG-TRAILLER-STA */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + 1;

            /*" -1155- WRITE REG-STA-SASSE FROM REG-APOL-SASSE. */
            _.Move(LBFCT016.REG_APOL_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R0860-LER-APOLICE-SECTION */
        private void R0860_LER_APOLICE_SECTION()
        {
            /*" -1165- MOVE 'R0860-00-LER-APOLICE' TO PARAGRAFO. */
            _.Move("R0860-00-LER-APOLICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1167- MOVE 'SELECT TABELA APOLICE' TO COMANDO. */
            _.Move("SELECT TABELA APOLICE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1169- MOVE PROPOVA-NUM-APOLICE TO APOLICES-NUM-APOLICE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -1177- PERFORM R0860_LER_APOLICE_DB_SELECT_1 */

            R0860_LER_APOLICE_DB_SELECT_1();

            /*" -1180- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1181- DISPLAY 'PF0714B - FIM ANORMAL' */
                _.Display($"PF0714B - FIM ANORMAL");

                /*" -1182- DISPLAY '          ERRO SELECT TABELA APOLICE' */
                _.Display($"          ERRO SELECT TABELA APOLICE");

                /*" -1184- DISPLAY '          NUMERO DA PROPOSTA.... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO DA PROPOSTA.... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1186- DISPLAY '          NUMERO DA APOLICE..... ' PROPOVA-NUM-APOLICE */
                _.Display($"          NUMERO DA APOLICE..... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1188- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -1189- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1189- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0860-LER-APOLICE-DB-SELECT-1 */
        public void R0860_LER_APOLICE_DB_SELECT_1()
        {
            /*" -1177- EXEC SQL SELECT RAMO_EMISSOR INTO :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE WITH UR END-EXEC. */

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
            /*" -1199- MOVE 'R0870-00-LER-RAMOIND' TO PARAGRAFO. */
            _.Move("R0870-00-LER-RAMOIND", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1201- MOVE 'SELECT TABELA RAMOIND' TO COMANDO. */
            _.Move("SELECT TABELA RAMOIND", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1211- PERFORM R0870_LER_RAMOIND_DB_SELECT_1 */

            R0870_LER_RAMOIND_DB_SELECT_1();

            /*" -1214- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1215- DISPLAY 'PF0714B - FIM ANORMAL' */
                _.Display($"PF0714B - FIM ANORMAL");

                /*" -1216- DISPLAY '          ERRO SELECT TAB. RAMO COMPLEMENTAR' */
                _.Display($"          ERRO SELECT TAB. RAMO COMPLEMENTAR");

                /*" -1218- DISPLAY '          NUMERO DO TERMO ADESAO.... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO.... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1220- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -1221- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1221- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0870-LER-RAMOIND-DB-SELECT-1 */
        public void R0870_LER_RAMOIND_DB_SELECT_1()
        {
            /*" -1211- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR AND DATA_INIVIGENCIA <= :TERMOADE-DATA-ADESAO AND DATA_TERVIGENCIA >= :TERMOADE-DATA-ADESAO WITH UR END-EXEC. */

            var r0870_LER_RAMOIND_DB_SELECT_1_Query1 = new R0870_LER_RAMOIND_DB_SELECT_1_Query1()
            {
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                TERMOADE_DATA_ADESAO = TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO.ToString(),
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
            /*" -1232- MOVE 'R0900-00-STATUS-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0900-00-STATUS-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1235- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -1238- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -1240- MOVE PROPOFID-COD-PRODUTO-SIVPF TO W-SUBPRODUTO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, WAREA_AUXILIAR.FILLER_1.W_SUBPRODUTO);

            /*" -1241- IF HISCOBPR-IMP-MORNATU GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU > 00)
            {

                /*" -1243- MOVE HISCOBPR-IMP-MORNATU TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -1244- MOVE 1 TO W-COBERTURA */
                _.Move(1, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                /*" -1246- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -1248- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -1250- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -1251- IF HISCOBPR-IMPMORACID GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID > 00)
            {

                /*" -1253- MOVE HISCOBPR-IMPMORACID TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -1254- MOVE 2 TO W-COBERTURA */
                _.Move(2, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                /*" -1256- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -1258- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -1260- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -1261- IF HISCOBPR-IMPINVPERM GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM > 00)
            {

                /*" -1263- MOVE HISCOBPR-IMPINVPERM TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -1264- MOVE 3 TO W-COBERTURA */
                _.Move(3, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                /*" -1266- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -1268- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -1268- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_SAIDA*/

        [StopWatch]
        /*" R0950-00-STATUS-REGISTRO-TP4-SECTION */
        private void R0950_00_STATUS_REGISTRO_TP4_SECTION()
        {
            /*" -1279- MOVE 'R0990-00-STATUS-REGISTRO-TP4' TO PARAGRAFO. */
            _.Move("R0990-00-STATUS-REGISTRO-TP4", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1282- MOVE '4' TO R4-TIPO-REG OF REG-PGTO-SASSE. */
            _.Move("4", LBFCT016.REG_PGTO_SASSE.R4_TIPO_REG);

            /*" -1285- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R4-NUM-PROPOSTA OF REG-PGTO-SASSE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA);

            /*" -1290- MOVE 'PAG' TO R4-SIT-COBRANCA OF REG-PGTO-SASSE PROPFIDH-SIT-COBRANCA-SIVPF. */
            _.Move("PAG", LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -1293- MOVE PROPOVA-DATA-QUITACAO TO W-DATA-SQL. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1294- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -1295- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -1297- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -1300- MOVE W-DATA-TRABALHO TO R4-DATA-SITUACAO OF REG-PGTO-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO);

            /*" -1302- MOVE 1 TO R4-PARCELAS-PAGAS OF REG-PGTO-SASSE */
            _.Move(1, LBFCT016.REG_PGTO_SASSE.R4_PARCELAS_PAGAS);

            /*" -1305- MOVE ZEROS TO R4-TOTAL-PARCELAS OF REG-PGTO-SASSE */
            _.Move(0, LBFCT016.REG_PGTO_SASSE.R4_TOTAL_PARCELAS);

            /*" -1307- WRITE REG-STA-SASSE FROM REG-PGTO-SASSE. */
            _.Move(LBFCT016.REG_PGTO_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1307- ADD 1 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_SAIDA*/

        [StopWatch]
        /*" R0970-00-STATUS-REGISTRO-TP5-SECTION */
        private void R0970_00_STATUS_REGISTRO_TP5_SECTION()
        {
            /*" -1318- MOVE 'R0970-00-STATUS-REGISTRO-TP5' TO PARAGRAFO. */
            _.Move("R0970-00-STATUS-REGISTRO-TP5", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1320- MOVE SPACES TO REG-STA-SASSE. */
            _.Move("", REG_STA_SASSE);

            /*" -1321- MOVE 5 TO R5-TIPO-REG. */
            _.Move(5, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_TIPO_REG);

            /*" -1327- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R5-NUM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_NUM_PROPOSTA);

            /*" -1329- WRITE REG-STA-SASSE FROM R5-REG-QTDE-VIDAS-VE */
            _.Move(LBFPF200.R5_REG_QTDE_VIDAS_VE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1329- ADD 1 TO RT-QTDE-TIPO-5 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0970_SAIDA*/

        [StopWatch]
        /*" R1000-00-GERAR-TRAILLER-SECTION */
        private void R1000_00_GERAR_TRAILLER_SECTION()
        {
            /*" -1339- MOVE 'R1000-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R1000-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1341- MOVE 'WRITE REG-TRAILLER - PROPOSTA' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER - PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1343- MOVE 'WRITE REG-TRAILLER - STATUS' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER - STATUS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1345- MOVE SPACES TO REG-STA-SASSE. */
            _.Move("", REG_STA_SASSE);

            /*" -1348- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -1351- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -1362- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 OF REG-TRAILLER-STA + RT-QTDE-TIPO-2 OF REG-TRAILLER-STA + RT-QTDE-TIPO-3 OF REG-TRAILLER-STA + RT-QTDE-TIPO-4 OF REG-TRAILLER-STA + RT-QTDE-TIPO-5 OF REG-TRAILLER-STA + RT-QTDE-TIPO-6 OF REG-TRAILLER-STA + RT-QTDE-TIPO-7 OF REG-TRAILLER-STA + RT-QTDE-TIPO-8 OF REG-TRAILLER-STA + RT-QTDE-TIPO-9 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -1362- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -1372- MOVE 'R1050-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R1050-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1374- MOVE 'INSERT ARQUIVOS-SIVPF - STATUS' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF - STATUS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1377- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -1380- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -1384- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -1387- MOVE RH-NSAS OF REG-HEADER-STA TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -1390- MOVE RT-QTDE-TOTAL OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -1398- PERFORM R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -1401- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1402- DISPLAY 'PF0714B - FIM ANORMAL' */
                _.Display($"PF0714B - FIM ANORMAL");

                /*" -1403- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -1405- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -1407- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -1409- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -1411- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -1413- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -1414- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1414- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -1398- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
            /*" -1425- MOVE 'R1100-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R1100-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1427- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1428- DISPLAY 'PF0714B - TOTAIS DO PROCESSAMENTO' */
            _.Display($"PF0714B - TOTAIS DO PROCESSAMENTO");

            /*" -1429- DISPLAY '          TOTAL  REGISTROS LIDOS........... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS........... {WAREA_AUXILIAR.W_NSL}");

            /*" -1431- DISPLAY '          TOTAL  DESPREZADO................ ' W-DESPREZADO */
            _.Display($"          TOTAL  DESPREZADO................ {WAREA_AUXILIAR.W_DESPREZADO}");

            /*" -1433- DISPLAY '          TOTAL  GERADO ARQUIVO PROPOSTA... ' RT-QTDE-TIPO-1 OF REG-TRAILLER */
            _.Display($"          TOTAL  GERADO ARQUIVO PROPOSTA... {LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1}");

            /*" -1434- DISPLAY '          TOTAL  GERADO ARQUIVO STATUS..... ' RT-QTDE-TIPO-1 OF REG-TRAILLER-STA. */
            _.Display($"          TOTAL  GERADO ARQUIVO STATUS..... {LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-SECTION */
        private void R3390_GERA_HIST_FIDELIZACAO_SECTION()
        {
            /*" -1443- MOVE 'R3390-GERA-HIST-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3390-GERA-HIST-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1445- MOVE 'INSERT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1448- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1451- MOVE PROPOVA-DTINCLUS TO PROPFIDH-DATA-SITUACAO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -1454- MOVE PROPOFID-COD-EMPRESA-SIVPF TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -1457- MOVE PROPOFID-COD-PRODUTO-SIVPF TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -1468- PERFORM R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1 */

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1();

            /*" -1471- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1472- DISPLAY 'PF0714B - FIM ANORMAL' */
                _.Display($"PF0714B - FIM ANORMAL");

                /*" -1473- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -1475- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1477- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPFIDH-NUM-IDENTIFICACAO */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}");

                /*" -1479- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1480- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1480- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-DB-INSERT-1 */
        public void R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -1468- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

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
            /*" -1490- MOVE 'R3400-00-ATUALIZA-PROPOSTA' TO PARAGRAFO. */
            _.Move("R3400-00-ATUALIZA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1492- MOVE 'UPDATE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1493- MOVE 'PF0714B' TO PROPOFID-COD-USUARIO */
            _.Move("PF0714B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -1495- MOVE 'R' TO PROPOFID-SITUACAO-ENVIO */
            _.Move("R", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -1504- PERFORM R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1 */

            R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1();

            /*" -1507- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1508- DISPLAY 'PF0714B - FIM ANORMAL' */
                _.Display($"PF0714B - FIM ANORMAL");

                /*" -1509- DISPLAY '          ERRO UPDATE PROPOSTA-FIDELIZ' */
                _.Display($"          ERRO UPDATE PROPOSTA-FIDELIZ");

                /*" -1511- DISPLAY '          PROPOSTA................... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          PROPOSTA................... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1513- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1514- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1514- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3400-00-ATUALIZA-PROPOSTA-DB-UPDATE-1 */
        public void R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1()
        {
            /*" -1504- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET NSAS_SIVPF = :PROPOFID-NSAS-SIVPF, NSL = :PROPOFID-NSL, SIT_PROPOSTA = :PROPOFID-SIT-PROPOSTA, COD_USUARIO = :PROPOFID-COD-USUARIO, SITUACAO_ENVIO = :PROPOFID-SITUACAO-ENVIO WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

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
        /*" R3450-00-LER-PROP-SASSE-VIDA-SECTION */
        private void R3450_00_LER_PROP_SASSE_VIDA_SECTION()
        {
            /*" -1523- MOVE 'R3450-00-LER-PROP-SASSE-VIDA' TO PARAGRAFO. */
            _.Move("R3450-00-LER-PROP-SASSE-VIDA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1525- MOVE 'SELECT PROP-SASSE-VIDA' TO COMANDO. */
            _.Move("SELECT PROP-SASSE-VIDA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1528- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPSSVD-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO);

            /*" -1536- PERFORM R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1 */

            R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1();

            /*" -1539- IF SQLCODE NOT EQUAL 00 AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -1540- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1541- MOVE 2 TO W-PROP-SASSE */
                    _.Move(2, WAREA_AUXILIAR.W_PROP_SASSE);

                    /*" -1542- ELSE */
                }
                else
                {


                    /*" -1543- DISPLAY 'PF0714B - FIM ANORMAL' */
                    _.Display($"PF0714B - FIM ANORMAL");

                    /*" -1544- DISPLAY '          ERRO ACESSO PROP-SASSE-VIDA' */
                    _.Display($"          ERRO ACESSO PROP-SASSE-VIDA");

                    /*" -1547- DISPLAY '          PROPOSTA / IDENTIFICACAO... ' PROPOFID-NUM-PROPOSTA-SIVPF PROPSSVD-NUM-IDENTIFICACAO */

                    $"          PROPOSTA / IDENTIFICACAO... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO}"
                    .Display();

                    /*" -1549- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -1550- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1551- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1552- ELSE */
                }

            }
            else
            {


                /*" -1552- MOVE 1 TO W-PROP-SASSE. */
                _.Move(1, WAREA_AUXILIAR.W_PROP_SASSE);
            }


        }

        [StopWatch]
        /*" R3450-00-LER-PROP-SASSE-VIDA-DB-SELECT-1 */
        public void R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1()
        {
            /*" -1536- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO INTO :PROPSSVD-NUM-APOLICE , :PROPSSVD-COD-SUBGRUPO FROM SEGUROS.PROP_SASSE_VIDA WHERE NUM_IDENTIFICACAO = :PROPSSVD-NUM-IDENTIFICACAO WITH UR END-EXEC. */

            var r3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1 = new R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1()
            {
                PROPSSVD_NUM_IDENTIFICACAO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO.ToString(),
            };

            var executed_1 = R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1.Execute(r3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPSSVD_NUM_APOLICE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE);
                _.Move(executed_1.PROPSSVD_COD_SUBGRUPO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3450_SAIDA*/

        [StopWatch]
        /*" R3500-00-PROP-SASSE-VIDA-SECTION */
        private void R3500_00_PROP_SASSE_VIDA_SECTION()
        {
            /*" -1561- MOVE 'R3500-00-PROP-SASSE-VIDA' TO PARAGRAFO. */
            _.Move("R3500-00-PROP-SASSE-VIDA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1563- MOVE 'UPDATE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1564- MOVE TERMOADE-NUM-APOLICE TO PROPSSVD-NUM-APOLICE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE);

            /*" -1566- MOVE TERMOADE-COD-SUBGRUPO TO PROPSSVD-COD-SUBGRUPO. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO);

            /*" -1571- PERFORM R3500_00_PROP_SASSE_VIDA_DB_UPDATE_1 */

            R3500_00_PROP_SASSE_VIDA_DB_UPDATE_1();

            /*" -1574- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1575- DISPLAY 'PF0714B - FIM ANORMAL' */
                _.Display($"PF0714B - FIM ANORMAL");

                /*" -1576- DISPLAY '          ERRO UPDATE PROP-SASSE-VIDA' */
                _.Display($"          ERRO UPDATE PROP-SASSE-VIDA");

                /*" -1580- DISPLAY '          PROPOSTA / IDENTIFICACAO.. ' PROPOFID-NUM-PROPOSTA-SIVPF '   ' PROPSSVD-NUM-IDENTIFICACAO '   ' SQLCODE */

                $"          PROPOSTA / IDENTIFICACAO.. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO}   {DB.SQLCODE}"
                .Display();

                /*" -1581- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1581- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3500-00-PROP-SASSE-VIDA-DB-UPDATE-1 */
        public void R3500_00_PROP_SASSE_VIDA_DB_UPDATE_1()
        {
            /*" -1571- EXEC SQL UPDATE SEGUROS.PROP_SASSE_VIDA SET NUM_APOLICE = :PROPSSVD-NUM-APOLICE, COD_SUBGRUPO = :PROPSSVD-COD-SUBGRUPO WHERE NUM_IDENTIFICACAO = :PROPSSVD-NUM-IDENTIFICACAO END-EXEC. */

            var r3500_00_PROP_SASSE_VIDA_DB_UPDATE_1_Update1 = new R3500_00_PROP_SASSE_VIDA_DB_UPDATE_1_Update1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_NUM_IDENTIFICACAO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO.ToString(),
            };

            R3500_00_PROP_SASSE_VIDA_DB_UPDATE_1_Update1.Execute(r3500_00_PROP_SASSE_VIDA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -1589- CLOSE MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -1600- DISPLAY ' ' */
            _.Display($" ");

            /*" -1601- IF W-FIM-MOVTO-CEF = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_CEF == "FIM")
            {

                /*" -1602- DISPLAY 'PF0714B - FIM NORMAL' */
                _.Display($"PF0714B - FIM NORMAL");

                /*" -1603- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1604- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1604- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1608- ELSE */
            }
            else
            {


                /*" -1609- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_3.WSQLCODE);

                /*" -1610- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_3.WSQLERRD1);

                /*" -1611- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_3.WSQLERRD2);

                /*" -1612- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -1613- DISPLAY '*** PF0714B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0714B *** ROLLBACK EM ANDAMENTO ...");

                /*" -1614- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1614- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -1617- MOVE 09 TO RETURN-CODE. */
                _.Move(09, RETURN_CODE);
            }


            /*" -1617- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}