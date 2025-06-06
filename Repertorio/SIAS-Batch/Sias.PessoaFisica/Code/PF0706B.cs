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
using Sias.PessoaFisica.DB2.PF0706B;

namespace Code
{
    public class PF0706B
    {
        public bool IsCall { get; set; }

        public PF0706B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SISTEMA...............  PRODUTOS DE FIDELIZACAO              *      */
        /*"      *   FUNCAO ...............  GERA ARQUIVO STATUS DE BILHETES      *      */
        /*"      *                           CANCELADOS                           *      */
        /*"      *   ANALISTA/PROGRAMADOR..  LUIZ CARLOS / REGINALDO              *      */
        /*"      *   PROGRAMA .............  PF0706B                              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 14             ENVIAR 100 NO CAMPO                      *      */
        /*"      *                       PROPFIDH-SIT-MOTIVO-SIVPF                *      */
        /*"      *                       PARA CANCELAMENTO DE BILHETE TIPO 3      *      */
        /*"      * ATENDE DEMANDA 512676 PARA O SIGPF REDE.                       *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.14          THIAGO BLAIER                            *      */
        /*"      *                       13/07/2023                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 13             ENVIAR TODOS OS BILHETES CANCELADOS      *      */
        /*"      * ATENDE CADMUS 153555  PARA O SIGPF REDE.                       *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.13          THIAGO BLAIER                            *      */
        /*"      *                       04/09/2017                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 12             AJUSTE NO CANCELAMENTO DE BILHETES       *      */
        /*"      * ATENDE CADMUS 128146  TIPOS CANCELAMENTO 3 E 4                 *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.12          REGINALDO SILVA                          *      */
        /*"      *                       29/03/2016                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 11             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA                          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSOES V.10          AJUSTES ROTINA RETURN-CODE E DISPLAYS    *      */
        /*"      * ATENDE CADMUS 80536                                            *      */
        /*"      *                       REGINALDO SILVA                          *      */
        /*"      *                       21/03/2013                               *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES V.09    EM  13/05/2012                               *      */
        /*"      *       ATENDE CADMUS 69738                                      *      */
        /*"      *   PROCURAR POR V.09                MARCO PAIVA                 *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES V.08    EM  12/11/2010                               *      */
        /*"      *       ATENDE CADMUS 50171                                      *      */
        /*"      *   PROCURAR POR ED1110              EDILANA CERQUEIRA           *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES V.07    EM  26/10/2010                               *      */
        /*"      *       ATENDE CADMUS 49336: NAO PROCESSA COD_ORIGEM = 1001      *      */
        /*"      *   PROCURAR POR C49336              SERGIO LORETO               *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES V.06    EM  24/03/2010                               *      */
        /*"      *       ATENDE CADMUS 39418 - TRATAR O CANCELAMENTO DO FACIL CO- *      */
        /*"      *                             MERCIALIZADO NO CANAL ATM DA CEF.  *      */
        /*"      *   PROCURAR POR V.06                   EDSON MARQUES            *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES V.05    EM  04/02/2010                               *      */
        /*"      *       ATENDE CADMUS 36876 - ALTERA DATA CURSOR                 *      */
        /*"      *   PROCURAR POR V.05                   EDILANA CERQUEIRA        *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES V.04    EM  16/06/2009                               *      */
        /*"      *       COLOCACAO DE DISPLAY PARA ACOMPANHAMENTO DE ERRO SQL=100 *      */
        /*"      *       ATENDE SSI 25127                                         *      */
        /*"      *   PROCURAR POR V.04                   EDILANA CERQUEIRA        *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES V.03    EM  25/07/2008                               *      */
        /*"      *       LIBERAR GERAпїЅпїЅO DO REGISTRO TP 1 NO REGISTRO DE STATUS      */
        /*"      *       ATENDE SSI 22839                                         *      */
        /*"      *   PROCURAR POR V.03                   LUCIA VIEIRA             *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES V.02    EM  15/01/2007                               *      */
        /*"      *   PASSOU A GERAR O REGISTRO TIPO '8', PARA O  NOVO  MODELO  DE *      */
        /*"      *   MENSURACAO DE METAS - BLOCO 33.                              *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO  V.01    EM  22/10/2002                               *      */
        /*"      *   POR ORIENTACAO DO SR. MARCELO DA RESIT/SP, NO CASO DE CANCE- *      */
        /*"      *   LAMENTO PASSAREMOS A GERAR APENAS OS REGISTROS DE TIPO 1 E 4 *      */
        /*"      *   (4 - NO CASO DE CANELAMENTO POR SOLICITACAO DO USUARIO).     *      */
        /*"      *                                                                *      */
        /*"      *   OBS.: OS PROCESSOS PARA GERACAO DOS REGISTROS 2 E 3, ESTARAO *      */
        /*"      *         INIBIDOS NO PROGRAMA - PROCURE POR LC1022.             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVTO_STA_BILHETE { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOVTO_STA_BILHETE
        {
            get
            {
                _.Move(REG_STA_BILHETE, _MOVTO_STA_BILHETE); VarBasis.RedefinePassValue(REG_STA_BILHETE, _MOVTO_STA_BILHETE, REG_STA_BILHETE); return _MOVTO_STA_BILHETE;
            }
        }
        /*"01   REG-STA-BILHETE                    PIC X(100).*/
        public StringBasis REG_STA_BILHETE { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WAREA-AUXILIAR.*/
        public PF0706B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0706B_WAREA_AUXILIAR();
        public class PF0706B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-BILHETE-COB             PIC X(003)    VALUE SPACES*/
            public StringBasis W_FIM_BILHETE_COB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-MOVTO-BILH              PIC X(003)    VALUE SPACES*/
            public StringBasis W_FIM_MOVTO_BILH { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-FIDELIZ              PIC X(003)    VALUE SPACES*/
            public StringBasis W_EXISTE_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-BILHETE              PIC X(003)    VALUE SPACES*/
            public StringBasis W_EXISTE_BILHETE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-HISTORICO            PIC X(003)    VALUE SPACES*/
            public StringBasis W_EXISTE_HISTORICO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-HEADER-GERADO               PIC X(003)    VALUE 'NAO'.*/
            public StringBasis W_HEADER_GERADO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-BILHETE-LIDO                PIC  9(01)    VALUE ZERO.*/
            public IntBasis W_BILHETE_LIDO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-IND-IOF                     PIC S9(01)V9(04) COMP-3.*/
            public DoubleBasis W_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(01)V9(04)"), 4);
            /*"    05  W-PRM-LIQ                     PIC S9(13)V99    COMP-3.*/
            public DoubleBasis W_PRM_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05  W-TIME                        PIC X(08).*/
            public StringBasis W_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05  W-TIME-EDIT                   PIC 99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
            /*"    05  W-REG-BIL-AP                  PIC  9(01)    VALUE ZERO.*/
            public IntBasis W_REG_BIL_AP { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-REG-BIL-RD                  PIC  9(01)    VALUE ZERO.*/
            public IntBasis W_REG_BIL_RD { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-QTD-LD-TIPO-1               PIC  9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-2               PIC  9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-3               PIC  9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-4               PIC  9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-5               PIC  9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-6               PIC  9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-7               PIC  9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-8               PIC  9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-9               PIC  9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-LIDO-BIL-AP                 PIC  9(06)    VALUE ZEROS.*/
            public IntBasis W_LIDO_BIL_AP { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-LIDO-BIL-RD                 PIC  9(06)    VALUE ZEROS.*/
            public IntBasis W_LIDO_BIL_RD { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-TOT-GERADO-STA              PIC  9(08)    VALUE ZEROS.*/
            public IntBasis W_TOT_GERADO_STA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-TOT-PROCESSADO              PIC 9(006)    VALUE ZEROS.*/
            public IntBasis W_TOT_PROCESSADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-TOT-DESPREZADO              PIC 9(006)    VALUE ZEROS.*/
            public IntBasis W_TOT_DESPREZADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-NSAS                        PIC 9(006)    VALUE ZEROS.*/
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-NSL                         PIC 9(006)    VALUE ZEROS.*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-CONTROLE                    PIC 9(006)    VALUE ZEROS.*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-COD-COBERTURA               PIC 9(004)    VALUE ZEROS.*/
            public IntBasis W_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER REDEFINES W-COD-COBERTURA.*/
            private _REDEF_PF0706B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0706B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0706B_FILLER_0(); _.Move(W_COD_COBERTURA, _filler_0); VarBasis.RedefinePassValue(W_COD_COBERTURA, _filler_0, W_COD_COBERTURA); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_COD_COBERTURA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_COD_COBERTURA); }
            }  //Redefines
            public class _REDEF_PF0706B_FILLER_0 : VarBasis
            {
                /*"        10  W-SUBPRODUTO              PIC 9(003).*/
                public IntBasis W_SUBPRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        10  W-COBERTURA               PIC 9(001).*/
                public IntBasis W_COBERTURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-DATA-TRABALHO               PIC 9(008)    VALUE ZEROS.*/

                public _REDEF_PF0706B_FILLER_0()
                {
                    W_SUBPRODUTO.ValueChanged += OnValueChanged;
                    W_COBERTURA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0706B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0706B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0706B_FILLER_1(); _.Move(W_DATA_TRABALHO, _filler_1); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_1, W_DATA_TRABALHO); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_DATA_TRABALHO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0706B_FILLER_1 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-NASCIMENTO             PIC 9(008)    VALUE ZEROS.*/

                public _REDEF_PF0706B_FILLER_1()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-NASCIMENTO.*/
            private _REDEF_PF0706B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0706B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0706B_FILLER_2(); _.Move(W_DATA_NASCIMENTO, _filler_2); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _filler_2, W_DATA_NASCIMENTO); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_DATA_NASCIMENTO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_DATA_NASCIMENTO); }
            }  //Redefines
            public class _REDEF_PF0706B_FILLER_2 : VarBasis
            {
                /*"        07  W-DIA-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-NASCIMENTO          PIC 9(004).*/
                public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-HOST-DATA-REFERENCIA        PIC X(010)    VALUE ZEROS.*/

                public _REDEF_PF0706B_FILLER_2()
                {
                    W_DIA_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_MES_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_ANO_NASCIMENTO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_HOST_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  W-TIMESTAMP                   PIC X(026)  VALUE SPACES.*/
            public StringBasis W_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
            /*"    05  FILLER REDEFINES W-TIMESTAMP.*/
            private _REDEF_PF0706B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0706B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0706B_FILLER_3(); _.Move(W_TIMESTAMP, _filler_3); VarBasis.RedefinePassValue(W_TIMESTAMP, _filler_3, W_TIMESTAMP); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_TIMESTAMP); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_TIMESTAMP); }
            }  //Redefines
            public class _REDEF_PF0706B_FILLER_3 : VarBasis
            {
                /*"        07  W-DT-TIMESTAMP            PIC X(010).*/
                public StringBasis W_DT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"        07  W-HH-TIMESTAMP            PIC X(016).*/
                public StringBasis W_HH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
                /*"    05  W-DTMOVABE                    PIC X(010)    VALUE ZEROS.*/

                public _REDEF_PF0706B_FILLER_3()
                {
                    W_DT_TIMESTAMP.ValueChanged += OnValueChanged;
                    W_HH_TIMESTAMP.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0706B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0706B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0706B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0706B_W_DTMOVABE1 : VarBasis
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
                /*"    05  W-DTMOVABE-I                  PIC X(010)    VALUE ZEROS.*/

                public _REDEF_PF0706B_W_DTMOVABE1()
                {
                    W_ANO_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_MOVABE.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
            private _REDEF_PF0706B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0706B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0706B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0706B_W_DTMOVABE_I1 : VarBasis
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
                /*"    05  WHOST-DATA-REF-CURSOR         PIC X(010)    VALUE ZEROS.*/

                public _REDEF_PF0706B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WHOST_DATA_REF_CURSOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  WHOST-DATA-REFERENCIA         PIC X(010)    VALUE ZEROS.*/
            public StringBasis WHOST_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  W-DATA-SQL                    PIC X(010)    VALUE ZEROS.*/
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_PF0706B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0706B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0706B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0706B_W_DATA_SQL1 : VarBasis
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
                /*"    05  W-PRODUTO                     PIC  9(002) VALUE ZEROS.*/

                public _REDEF_PF0706B_W_DATA_SQL1()
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
                            /*" 88 BILHETE-AP                             VALUE 09. */
							new SelectorItemBasis("BILHETE_AP", "09"),
							/*" 88 BILHETE-RD                             VALUE 10. */
							new SelectorItemBasis("BILHETE_RD", "10")
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

            /*"01  VIND-DT-REFERENCIA                PIC S9(4)  COMP VALUE +0.*/
        }
        public IntBasis VIND_DT_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DT-CANCELAMENTO              PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DT_CANCELAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WABEND*/
        public PF0706B_WABEND WABEND { get; set; } = new PF0706B_WABEND();
        public class PF0706B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0706B_FILLER_4 FILLER_4 { get; set; } = new PF0706B_FILLER_4();
            public class PF0706B_FILLER_4 : VarBasis
            {
                /*"      10   FILLER                   PIC  X(010) VALUE            'PF0706B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0706B  ");
                /*"      10   FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10   FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10   WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10   FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10   WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10   FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10   WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10   FILLER                   PIC  X(014)   VALUE              '   SQLERRD2 = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public PF0706B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0706B_LOCALIZA_ABEND_1();
            public class PF0706B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0706B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0706B_LOCALIZA_ABEND_2();
            public class PF0706B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01    WS-HORAS.*/
            }
        }
        public PF0706B_WS_HORAS WS_HORAS { get; set; } = new PF0706B_WS_HORAS();
        public class PF0706B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_PF0706B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_PF0706B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_PF0706B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_PF0706B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_PF0706B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_PF0706B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_PF0706B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_PF0706B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_PF0706B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3.*/

                public _REDEF_PF0706B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public PF0706B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new PF0706B_TOTAIS_ROT();
        public class PF0706B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 65 TIMES.*/
            public ListBasis<PF0706B_FILLER_13> FILLER_13 { get; set; } = new ListBasis<PF0706B_FILLER_13>(65);
            public class PF0706B_FILLER_13 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Copies.LBFPF025 LBFPF025 { get; set; } = new Copies.LBFPF025();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.CBCONDEV CBCONDEV { get; set; } = new Dclgens.CBCONDEV();
        public Dclgens.BILCOBER BILCOBER { get; set; } = new Dclgens.BILCOBER();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public PF0706B_C01_BILHETE C01_BILHETE { get; set; } = new PF0706B_C01_BILHETE();
        public PF0706B_BILHETE_COBERTURA BILHETE_COBERTURA { get; set; } = new PF0706B_BILHETE_COBERTURA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_STA_BILHETE_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO_STA_BILHETE.SetFile(MOVTO_STA_BILHETE_FILE_NAME_P);

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
            /*" -356- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -357- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -358- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -361- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -362- DISPLAY '*               PROGRAMA PF0706B               *' . */
            _.Display($"*               PROGRAMA PF0706B               *");

            /*" -363- DISPLAY '*  GERA ARQUIVO STATUS DE BILHETES CANCELADOS  *' . */
            _.Display($"*  GERA ARQUIVO STATUS DE BILHETES CANCELADOS  *");

            /*" -364- DISPLAY '*           VERSAO:  14 - 13/07/2023           *' . */
            _.Display($"*           VERSAO:  14 - 13/07/2023           *");

            /*" -365- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -374- DISPLAY '*  PF0706B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0706B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -375- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -377- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -379- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -381- PERFORM R0010-00-OBTER-DATA-DIA. */

            R0010_00_OBTER_DATA_DIA_SECTION();

            /*" -383- PERFORM R0015-00-OBTER-DT-PROCE. */

            R0015_00_OBTER_DT_PROCE_SECTION();

            /*" -385- DISPLAY 'DATA  REFERENCIA DO PROCESSAMENTO  ' WHOST-DATA-REF-CURSOR. */
            _.Display($"DATA  REFERENCIA DO PROCESSAMENTO  {WAREA_AUXILIAR.WHOST_DATA_REF_CURSOR}");

            /*" -387- DISPLAY ' ' . */
            _.Display($" ");

            /*" -389- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -391- PERFORM R0025-00-SELECIONA-MOVTO */

            R0025_00_SELECIONA_MOVTO_SECTION();

            /*" -393- PERFORM R0030-00-LER-MOVTO */

            R0030_00_LER_MOVTO_SECTION();

            /*" -394- IF W-FIM-MOVTO-BILH EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_BILH == "FIM")
            {

                /*" -395- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -396- DISPLAY '* PF0706B - FIM NORMAL, NAO HOUVE MOVIMENTO *' */
                _.Display($"* PF0706B - FIM NORMAL, NAO HOUVE MOVIMENTO *");

                /*" -397- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -398- MOVE 00 TO RETURN-CODE */
                _.Move(00, RETURN_CODE);

                /*" -400- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -402- PERFORM R0035-00-ABRIR-ARQUIVOS. */

            R0035_00_ABRIR_ARQUIVOS_SECTION();

            /*" -403- PERFORM R0040-00-GERAR-HEADER */

            R0040_00_GERAR_HEADER_SECTION();

            /*" -405- PERFORM R0045-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-BILH EQUAL 'FIM' */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_BILH == "FIM"))
            {

                R0045_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -406- PERFORM R0200-00-GERAR-TRAILLER */

            R0200_00_GERAR_TRAILLER_SECTION();

            /*" -409- PERFORM R0250-00-CONTROLAR-ARQ-ENVIADO. */

            R0250_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -418- PERFORM R0300-00-GERAR-TOTAIS. */

            R0300_00_GERAR_TOTAIS_SECTION();

            /*" -421- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO RELATORI-DATA-REFERENCIA OF DCLRELATORIOS. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

            /*" -431- PERFORM R0350-00-UPDATE-RELATORIOS. */

            R0350_00_UPDATE_RELATORIOS_SECTION();

            /*" -435- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -436- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -438- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -441- DISPLAY '*  PF0706B - FIM PROCESSAMENTO - HORA ' W-TIME-EDIT. */
            _.Display($"*  PF0706B - FIM PROCESSAMENTO - HORA {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -441- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0010-00-OBTER-DATA-DIA-SECTION */
        private void R0010_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -449- MOVE 'R0010-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0010-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -451- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -453- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -459- PERFORM R0010_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0010_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -462- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -463- DISPLAY 'PF0706B - FIM ANORMAL' */
                _.Display($"PF0706B - FIM ANORMAL");

                /*" -464- DISPLAY '          ERRO SELECT SISTEMAS' */
                _.Display($"          ERRO SELECT SISTEMAS");

                /*" -466- DISPLAY '          IDSISTEM........... ' SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS */
                _.Display($"          IDSISTEM........... {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA}");

                /*" -468- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -470- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -473- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -475- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -477- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -480- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -482- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0010-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0010_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -459- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0010_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 = new R0010_00_OBTER_DATA_DIA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0010_00_OBTER_DATA_DIA_DB_SELECT_1_Query1.Execute(r0010_00_OBTER_DATA_DIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0015-00-OBTER-DT-PROCE-SECTION */
        private void R0015_00_OBTER_DT_PROCE_SECTION()
        {
            /*" -491- MOVE 'R0015-00-OBTER-DT-PROCE' TO PARAGRAFO. */
            _.Move("R0015-00-OBTER-DT-PROCE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -493- MOVE 'SELECT SEGUROS.RELATORIOS' TO COMANDO. */
            _.Move("SELECT SEGUROS.RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -502- PERFORM R0015_00_OBTER_DT_PROCE_DB_SELECT_1 */

            R0015_00_OBTER_DT_PROCE_DB_SELECT_1();

            /*" -505- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -506- DISPLAY 'PF0706B - FIM ANORMAL' */
                _.Display($"PF0706B - FIM ANORMAL");

                /*" -507- DISPLAY '          ERRO SELECT RELATORIOS' */
                _.Display($"          ERRO SELECT RELATORIOS");

                /*" -509- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -511- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -513- MOVE WHOST-DATA-REF-CURSOR TO W-DT-TIMESTAMP. */
            _.Move(WAREA_AUXILIAR.WHOST_DATA_REF_CURSOR, WAREA_AUXILIAR.FILLER_3.W_DT_TIMESTAMP);

            /*" -515- MOVE '-00.00.00.000000' TO W-HH-TIMESTAMP. */
            _.Move("-00.00.00.000000", WAREA_AUXILIAR.FILLER_3.W_HH_TIMESTAMP);

            /*" -516- MOVE W-TIMESTAMP TO RELATORI-TIMESTAMP OF DCLRELATORIOS. */
            _.Move(WAREA_AUXILIAR.W_TIMESTAMP, RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP);

        }

        [StopWatch]
        /*" R0015-00-OBTER-DT-PROCE-DB-SELECT-1 */
        public void R0015_00_OBTER_DT_PROCE_DB_SELECT_1()
        {
            /*" -502- EXEC SQL SELECT DATA_REFERENCIA, DATA_REFERENCIA - 10 DAYS INTO :DCLRELATORIOS.RELATORI-DATA-REFERENCIA, :WHOST-DATA-REF-CURSOR FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0706B' WITH UR END-EXEC. */

            var r0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 = new R0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1.Execute(r0015_00_OBTER_DT_PROCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
                _.Move(executed_1.WHOST_DATA_REF_CURSOR, WAREA_AUXILIAR.WHOST_DATA_REF_CURSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -526- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -528- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -535- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -538- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -539- DISPLAY 'PF0706B - FIM ANORMAL' */
                _.Display($"PF0706B - FIM ANORMAL");

                /*" -540- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -542- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -544- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -547- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -549- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -550- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -535- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = 'STASASSE' AND SISTEMA_ORIGEM = 4 WITH UR END-EXEC. */

            var r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 = new R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1.Execute(r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_SAIDA*/

        [StopWatch]
        /*" R0025-00-SELECIONA-MOVTO-SECTION */
        private void R0025_00_SELECIONA_MOVTO_SECTION()
        {
            /*" -560- MOVE 'R0025-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0025-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -562- MOVE 'DECLER MOVIMENTO' TO COMANDO. */
            _.Move("DECLER MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -605- PERFORM R0025_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0025_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -613- PERFORM R0025_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0025_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -616- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -619- DISPLAY 'PF0706B - FIM ANORMAL, ERRO OPEN CURSOR BILHETE  ' SQLCODE */
                _.Display($"PF0706B - FIM ANORMAL, ERRO OPEN CURSOR BILHETE  {DB.SQLCODE}");

                /*" -619- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0025-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0025_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -605- EXEC SQL DECLARE C01_BILHETE CURSOR FOR SELECT NUM_BILHETE , NUM_APOLICE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_CLIENTE , PROFISSAO , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB, NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_QUITACAO , VAL_RCAP , RAMO , DATA_VENDA , DATA_MOVIMENTO , NUM_APOL_ANTERIOR , SITUACAO , TIP_CANCELAMENTO , SIT_SINISTRO , COD_USUARIO , DATE(TIMESTAMP) , DATA_CANCELAMENTO FROM SEGUROS.BILHETE WHERE DATA_CANCELAMENTO IS NOT NULL AND DATA_CANCELAMENTO >= :WHOST-DATA-REF-CURSOR AND DATA_CANCELAMENTO <= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND SITUACAO = '8' ORDER BY NUM_BILHETE WITH UR END-EXEC. */
            C01_BILHETE = new PF0706B_C01_BILHETE(true);
            string GetQuery_C01_BILHETE()
            {
                var query = @$"SELECT NUM_BILHETE
							, 
							NUM_APOLICE
							, 
							FONTE
							, 
							AGE_COBRANCA
							, 
							NUM_MATRICULA
							, 
							COD_AGENCIA
							, 
							OPERACAO_CONTA
							, 
							NUM_CONTA
							, 
							DIG_CONTA
							, 
							COD_CLIENTE
							, 
							PROFISSAO
							, 
							IDE_SEXO
							, 
							ESTADO_CIVIL
							, 
							OCORR_ENDERECO
							, 
							COD_AGENCIA_DEB
							, 
							OPERACAO_CONTA_DEB
							, 
							NUM_CONTA_DEB
							, 
							DIG_CONTA_DEB
							, 
							OPC_COBERTURA
							, 
							DATA_QUITACAO
							, 
							VAL_RCAP
							, 
							RAMO
							, 
							DATA_VENDA
							, 
							DATA_MOVIMENTO
							, 
							NUM_APOL_ANTERIOR
							, 
							SITUACAO
							, 
							TIP_CANCELAMENTO
							, 
							SIT_SINISTRO
							, 
							COD_USUARIO
							, 
							DATE(TIMESTAMP)
							, 
							DATA_CANCELAMENTO 
							FROM SEGUROS.BILHETE 
							WHERE DATA_CANCELAMENTO IS NOT NULL 
							AND DATA_CANCELAMENTO >= 
							'{WAREA_AUXILIAR.WHOST_DATA_REF_CURSOR}' 
							AND DATA_CANCELAMENTO <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND SITUACAO = '8' 
							ORDER BY NUM_BILHETE";

                return query;
            }
            C01_BILHETE.GetQueryEvent += GetQuery_C01_BILHETE;

        }

        [StopWatch]
        /*" R0025-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0025_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -613- EXEC SQL OPEN C01_BILHETE END-EXEC. */

            C01_BILHETE.Open();

        }

        [StopWatch]
        /*" R0080-00-SELECIONA-BIL-COB-DB-DECLARE-1 */
        public void R0080_00_SELECIONA_BIL_COB_DB_DECLARE_1()
        {
            /*" -1349- EXEC SQL DECLARE BILHETE-COBERTURA CURSOR FOR SELECT COD_PRODUTO, RAMO_COBERTURA, MODALI_COBERTURA, COD_OPCAO_PLANO, COD_COBERTURA, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IDE_COBERTURA, VAL_COBERTURA_IX, PRM_TOTAL, PCT_IOCC FROM SEGUROS.BILHETE_COBERTURA WHERE RAMO_COBERTURA = :BILCOBER-RAMO-COBERTURA AND MODALI_COBERTURA = 0 AND COD_OPCAO_PLANO = :BILCOBER-COD-OPCAO-PLANO AND DATA_INIVIGENCIA <= :BILCOBER-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :BILCOBER-DATA-TERVIGENCIA ORDER BY COD_COBERTURA WITH UR END-EXEC. */
            BILHETE_COBERTURA = new PF0706B_BILHETE_COBERTURA(true);
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
							WHERE RAMO_COBERTURA = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA}' 
							AND MODALI_COBERTURA = 0 
							AND COD_OPCAO_PLANO = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO}' 
							AND DATA_INIVIGENCIA <= 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA}' 
							AND DATA_TERVIGENCIA >= 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_TERVIGENCIA}' 
							ORDER BY COD_COBERTURA";

                return query;
            }
            BILHETE_COBERTURA.GetQueryEvent += GetQuery_BILHETE_COBERTURA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0025_SAIDA*/

        [StopWatch]
        /*" R0030-00-LER-MOVTO-SECTION */
        private void R0030_00_LER_MOVTO_SECTION()
        {
            /*" -629- MOVE 'R0030-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0030-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -631- MOVE 'FETCH BILHETE' TO COMANDO. */
            _.Move("FETCH BILHETE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -665- PERFORM R0030_00_LER_MOVTO_DB_FETCH_1 */

            R0030_00_LER_MOVTO_DB_FETCH_1();

            /*" -668- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -669- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -670- MOVE 'FIM' TO W-FIM-MOVTO-BILH */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_BILH);

                    /*" -670- PERFORM R0030_00_LER_MOVTO_DB_CLOSE_1 */

                    R0030_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -672- ELSE */
                }
                else
                {


                    /*" -673- DISPLAY 'PF0706B - FIM ANORMAL' */
                    _.Display($"PF0706B - FIM ANORMAL");

                    /*" -675- DISPLAY '          ERRO FETCH CURSOR BILHETE  ' SQLCODE */
                    _.Display($"          ERRO FETCH CURSOR BILHETE  {DB.SQLCODE}");

                    /*" -676- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -677- ELSE */
                }

            }
            else
            {


                /*" -680- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -681- IF W-CONTROLE > 999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 999)
                {

                    /*" -682- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -683- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -684- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -686- DISPLAY '*  PF0706B - TOTAL LIDOS...' W-NSL ' HORA ' W-TIME-EDIT */

                    $"*  PF0706B - TOTAL LIDOS...{WAREA_AUXILIAR.W_NSL} HORA {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -688- END-IF */
                }


                /*" -689- IF VIND-DT-REFERENCIA LESS ZERO */

                if (VIND_DT_REFERENCIA < 00)
                {

                    /*" -690- MOVE '0001-01-01' TO WHOST-DATA-REFERENCIA */
                    _.Move("0001-01-01", WAREA_AUXILIAR.WHOST_DATA_REFERENCIA);

                    /*" -692- END-IF */
                }


                /*" -693- IF VIND-DT-CANCELAMENTO LESS ZERO */

                if (VIND_DT_CANCELAMENTO < 00)
                {

                    /*" -694- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -696- DISPLAY 'BILHETE NAO PROCESSADO, DT.CANCELAMENTO NULA ' BILHETE-NUM-BILHETE */
                    _.Display($"BILHETE NAO PROCESSADO, DT.CANCELAMENTO NULA {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -696- GO TO R0030-00-LER-MOVTO. */
                    new Task(() => R0030_00_LER_MOVTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


        }

        [StopWatch]
        /*" R0030-00-LER-MOVTO-DB-FETCH-1 */
        public void R0030_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -665- EXEC SQL FETCH C01_BILHETE INTO :DCLBILHETE.BILHETE-NUM-BILHETE , :DCLBILHETE.BILHETE-NUM-APOLICE , :DCLBILHETE.BILHETE-FONTE , :DCLBILHETE.BILHETE-AGE-COBRANCA , :DCLBILHETE.BILHETE-NUM-MATRICULA , :DCLBILHETE.BILHETE-COD-AGENCIA , :DCLBILHETE.BILHETE-OPERACAO-CONTA , :DCLBILHETE.BILHETE-NUM-CONTA , :DCLBILHETE.BILHETE-DIG-CONTA , :DCLBILHETE.BILHETE-COD-CLIENTE , :DCLBILHETE.BILHETE-PROFISSAO , :DCLBILHETE.BILHETE-IDE-SEXO , :DCLBILHETE.BILHETE-ESTADO-CIVIL , :DCLBILHETE.BILHETE-OCORR-ENDERECO , :DCLBILHETE.BILHETE-COD-AGENCIA-DEB , :DCLBILHETE.BILHETE-OPERACAO-CONTA-DEB , :DCLBILHETE.BILHETE-NUM-CONTA-DEB , :DCLBILHETE.BILHETE-DIG-CONTA-DEB , :DCLBILHETE.BILHETE-OPC-COBERTURA , :DCLBILHETE.BILHETE-DATA-QUITACAO , :DCLBILHETE.BILHETE-VAL-RCAP , :DCLBILHETE.BILHETE-RAMO , :DCLBILHETE.BILHETE-DATA-VENDA , :DCLBILHETE.BILHETE-DATA-MOVIMENTO , :DCLBILHETE.BILHETE-NUM-APOL-ANTERIOR , :DCLBILHETE.BILHETE-SITUACAO , :DCLBILHETE.BILHETE-TIP-CANCELAMENTO , :DCLBILHETE.BILHETE-SIT-SINISTRO , :DCLBILHETE.BILHETE-COD-USUARIO , :WHOST-DATA-REFERENCIA:VIND-DT-REFERENCIA, :DCLBILHETE.BILHETE-DATA-CANCELAMENTO :VIND-DT-CANCELAMENTO END-EXEC. */

            if (C01_BILHETE.Fetch())
            {
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_FONTE, BILHETE.DCLBILHETE.BILHETE_FONTE);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_AGE_COBRANCA, BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_NUM_MATRICULA, BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_COD_AGENCIA, BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_OPERACAO_CONTA, BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_NUM_CONTA, BILHETE.DCLBILHETE.BILHETE_NUM_CONTA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_DIG_CONTA, BILHETE.DCLBILHETE.BILHETE_DIG_CONTA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_COD_CLIENTE, BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_PROFISSAO, BILHETE.DCLBILHETE.BILHETE_PROFISSAO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_IDE_SEXO, BILHETE.DCLBILHETE.BILHETE_IDE_SEXO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_ESTADO_CIVIL, BILHETE.DCLBILHETE.BILHETE_ESTADO_CIVIL);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_OCORR_ENDERECO, BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_COD_AGENCIA_DEB, BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA_DEB);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_OPERACAO_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA_DEB);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_NUM_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_NUM_CONTA_DEB);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_DIG_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_DIG_CONTA_DEB);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_OPC_COBERTURA, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_VAL_RCAP, BILHETE.DCLBILHETE.BILHETE_VAL_RCAP);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_DATA_VENDA, BILHETE.DCLBILHETE.BILHETE_DATA_VENDA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_DATA_MOVIMENTO, BILHETE.DCLBILHETE.BILHETE_DATA_MOVIMENTO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_NUM_APOL_ANTERIOR, BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_TIP_CANCELAMENTO, BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_SIT_SINISTRO, BILHETE.DCLBILHETE.BILHETE_SIT_SINISTRO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_COD_USUARIO, BILHETE.DCLBILHETE.BILHETE_COD_USUARIO);
                _.Move(C01_BILHETE.WHOST_DATA_REFERENCIA, WAREA_AUXILIAR.WHOST_DATA_REFERENCIA);
                _.Move(C01_BILHETE.VIND_DT_REFERENCIA, VIND_DT_REFERENCIA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_DATA_CANCELAMENTO, BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO);
                _.Move(C01_BILHETE.VIND_DT_CANCELAMENTO, VIND_DT_CANCELAMENTO);
            }

        }

        [StopWatch]
        /*" R0030-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0030_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -670- EXEC SQL CLOSE C01_BILHETE END-EXEC */

            C01_BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_SAIDA*/

        [StopWatch]
        /*" R0035-00-ABRIR-ARQUIVOS-SECTION */
        private void R0035_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -726- MOVE 'R0035-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0035-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -728- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -728- OPEN OUTPUT MOVTO-STA-BILHETE. */
            MOVTO_STA_BILHETE.Open(REG_STA_BILHETE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0035_SAIDA*/

        [StopWatch]
        /*" R0040-00-GERAR-HEADER-SECTION */
        private void R0040_00_GERAR_HEADER_SECTION()
        {
            /*" -738- MOVE 'R0040-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0040-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -740- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -742- MOVE SPACES TO REG-HEADER-STA. */
            _.Move("", LBFCT011.REG_HEADER_STA);

            /*" -745- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -748- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -749- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -750- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -752- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -755- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -758- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -761- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -764- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER-STA */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_HEADER_STA.RH_NSAS);

            /*" -764- WRITE REG-STA-BILHETE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_BILHETE);

            MOVTO_STA_BILHETE.Write(REG_STA_BILHETE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0040_SAIDA*/

        [StopWatch]
        /*" R0045-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0045_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -771- MOVE 'R0045-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0045-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -773- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -777- MOVE 'NAO' TO W-EXISTE-FIDELIZ, W-EXISTE-BILHETE, W-EXISTE-HISTORICO. */
            _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ, WAREA_AUXILIAR.W_EXISTE_BILHETE, WAREA_AUXILIAR.W_EXISTE_HISTORICO);

            /*" -779- PERFORM R0050-00-LER-PROP-FIDELIZ. */

            R0050_00_LER_PROP_FIDELIZ_SECTION();

            /*" -780- IF W-EXISTE-FIDELIZ EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_EXISTE_FIDELIZ == "NAO")
            {

                /*" -781- ADD 1 TO W-TOT-DESPREZADO */
                WAREA_AUXILIAR.W_TOT_DESPREZADO.Value = WAREA_AUXILIAR.W_TOT_DESPREZADO + 1;

                /*" -783- GO TO R0045-LEITURA. */

                R0045_LEITURA(); //GOTO
                return;
            }


            /*" -784- IF PROPOFID-SIT-PROPOSTA EQUAL 'CAN' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "CAN")
            {

                /*" -785- ADD 1 TO W-TOT-DESPREZADO */
                WAREA_AUXILIAR.W_TOT_DESPREZADO.Value = WAREA_AUXILIAR.W_TOT_DESPREZADO + 1;

                /*" -799- GO TO R0045-LEITURA. */

                R0045_LEITURA(); //GOTO
                return;
            }


            /*" -801- PERFORM R0060-00-LER-HISTORICO */

            R0060_00_LER_HISTORICO_SECTION();

            /*" -802- IF W-EXISTE-HISTORICO EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_HISTORICO == "SIM")
            {

                /*" -803- ADD 1 TO W-TOT-DESPREZADO */
                WAREA_AUXILIAR.W_TOT_DESPREZADO.Value = WAREA_AUXILIAR.W_TOT_DESPREZADO + 1;

                /*" -810- GO TO R0045-LEITURA. */

                R0045_LEITURA(); //GOTO
                return;
            }


            /*" -814- PERFORM R0065-00-GERA-H-PROP-FIDEL */

            R0065_00_GERA_H_PROP_FIDEL_SECTION();

            /*" -816- PERFORM R0070-00-GERAR-REGISTRO-TP1 */

            R0070_00_GERAR_REGISTRO_TP1_SECTION();

            /*" -818- PERFORM R0075-00-ATUALIZA-PRP-FIDELIZ */

            R0075_00_ATUALIZA_PRP_FIDELIZ_SECTION();

            /*" -820- MOVE 'NAO' TO W-FIM-BILHETE-COB */
            _.Move("NAO", WAREA_AUXILIAR.W_FIM_BILHETE_COB);

            /*" -822- MOVE 1 TO W-BILHETE-LIDO */
            _.Move(1, WAREA_AUXILIAR.W_BILHETE_LIDO);

            /*" -832- MOVE PROPOFID-COD-PRODUTO-SIVPF TO W-PRODUTO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, WAREA_AUXILIAR.W_PRODUTO);

            /*" -833- IF PROPFIDH-SIT-MOTIVO-SIVPF EQUAL 101 */

            if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF == 101)
            {

                /*" -835- PERFORM R0120-00-GERAR-REG-TP4. */

                R0120_00_GERAR_REG_TP4_SECTION();
            }


            /*" -841- MOVE ZERO TO W-TEM-HISTORICO */
            _.Move(0, WAREA_AUXILIAR.W_TEM_HISTORICO);

            /*" -842- PERFORM R0125-00-LER-H-PROP-FIDEL */

            R0125_00_LER_H_PROP_FIDEL_SECTION();

            /*" -843- IF NAO-TEM-HISTORICO */

            if (WAREA_AUXILIAR.W_TEM_HISTORICO["NAO_TEM_HISTORICO"])
            {

                /*" -845- GO TO R0045-LEITURA. */

                R0045_LEITURA(); //GOTO
                return;
            }


            /*" -847- INITIALIZE R8-PONTUACAO-SIDEM. */
            _.Initialize(
                LBFPF025.R8_PONTUACAO_SIDEM
            );

            /*" -853- PERFORM R0130-00-OBTER-PRM-DEV */

            R0130_00_OBTER_PRM_DEV_SECTION();

            /*" -854- IF R8-VLR-LANCAMENTO GREATER ZEROS */

            if (LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO > 00)
            {

                /*" -854- PERFORM R0135-00-GERAR-REGISTRO-TP8. */

                R0135_00_GERAR_REGISTRO_TP8_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0045_LEITURA */

            R0045_LEITURA();

        }

        [StopWatch]
        /*" R0045-LEITURA */
        private void R0045_LEITURA(bool isPerform = false)
        {
            /*" -858- PERFORM R0030-00-LER-MOVTO. */

            R0030_00_LER_MOVTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0045_SAIDA*/

        [StopWatch]
        /*" R0050-00-LER-PROP-FIDELIZ-SECTION */
        private void R0050_00_LER_PROP_FIDELIZ_SECTION()
        {
            /*" -868- MOVE 'R0050-00-LER-PROP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0050-00-LER-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -870- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -873- MOVE BILHETE-NUM-BILHETE OF DCLBILHETE TO PROPOFID-NUM-SICOB. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

            /*" -956- PERFORM R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1 */

            R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1();

            /*" -959- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -960- MOVE 'SIM' TO W-EXISTE-FIDELIZ */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                /*" -961- ELSE */
            }
            else
            {


                /*" -962- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -963- MOVE 'NAO' TO W-EXISTE-FIDELIZ */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                    /*" -964- ELSE */
                }
                else
                {


                    /*" -965- DISPLAY 'PF0706B - FIM ANORMAL' */
                    _.Display($"PF0706B - FIM ANORMAL");

                    /*" -966- DISPLAY '          ERRO SELECT PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO SELECT PROPOSTA-FIDELIZ");

                    /*" -968- DISPLAY '          NUMERO DA PROPOSTA......... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO DA PROPOSTA......... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -970- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -971- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -971- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0050-00-LER-PROP-FIDELIZ-DB-SELECT-1 */
        public void R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1()
        {
            /*" -956- EXEC SQL SELECT NUM_PROPOSTA_SIVPF, NUM_IDENTIFICACAO, COD_EMPRESA_SIVPF, COD_PESSOA, NUM_SICOB, DATA_PROPOSTA, COD_PRODUTO_SIVPF, AGECOBR, DIA_DEBITO, OPCAOPAG, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, PERC_DESCONTO, NRMATRVEN, AGECTAVEN, OPRCTAVEN, NUMCTAVEN, DIGCTAVEN, CGC_CONVENENTE, NOME_CONVENENTE, NRMATRCON, DTQITBCO, VAL_PAGO, AGEPGTO, VAL_TARIFA, VAL_IOF, DATA_CREDITO, VAL_COMISSAO, SIT_PROPOSTA, COD_USUARIO, CANAL_PROPOSTA, NSAS_SIVPF, ORIGEM_PROPOSTA, NSL, NSAC_SIVPF, SITUACAO_ENVIO INTO :PROPOFID-NUM-PROPOSTA-SIVPF, :PROPOFID-NUM-IDENTIFICACAO, :PROPOFID-COD-EMPRESA-SIVPF, :PROPOFID-COD-PESSOA, :PROPOFID-NUM-SICOB, :PROPOFID-DATA-PROPOSTA, :PROPOFID-COD-PRODUTO-SIVPF, :PROPOFID-AGECOBR, :PROPOFID-DIA-DEBITO, :PROPOFID-OPCAOPAG, :PROPOFID-AGECTADEB, :PROPOFID-OPRCTADEB, :PROPOFID-NUMCTADEB, :PROPOFID-DIGCTADEB, :PROPOFID-PERC-DESCONTO, :PROPOFID-NRMATRVEN, :PROPOFID-AGECTAVEN, :PROPOFID-OPRCTAVEN, :PROPOFID-NUMCTAVEN, :PROPOFID-DIGCTAVEN, :PROPOFID-CGC-CONVENENTE, :PROPOFID-NOME-CONVENENTE, :PROPOFID-NRMATRCON, :PROPOFID-DTQITBCO, :PROPOFID-VAL-PAGO, :PROPOFID-AGEPGTO, :PROPOFID-VAL-TARIFA, :PROPOFID-VAL-IOF, :PROPOFID-DATA-CREDITO, :PROPOFID-VAL-COMISSAO, :PROPOFID-SIT-PROPOSTA, :PROPOFID-COD-USUARIO, :PROPOFID-CANAL-PROPOSTA, :PROPOFID-NSAS-SIVPF, :PROPOFID-ORIGEM-PROPOSTA, :PROPOFID-NSL, :PROPOFID-NSAC-SIVPF, :PROPOFID-SITUACAO-ENVIO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :PROPOFID-NUM-SICOB WITH UR END-EXEC. */

            var r0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 = new R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
            };

            var executed_1 = R0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0050_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(executed_1.PROPOFID_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);
                _.Move(executed_1.PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
                _.Move(executed_1.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);
                _.Move(executed_1.PROPOFID_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);
                _.Move(executed_1.PROPOFID_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);
                _.Move(executed_1.PROPOFID_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);
                _.Move(executed_1.PROPOFID_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);
                _.Move(executed_1.PROPOFID_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);
                _.Move(executed_1.PROPOFID_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);
                _.Move(executed_1.PROPOFID_PERC_DESCONTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);
                _.Move(executed_1.PROPOFID_NRMATRVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);
                _.Move(executed_1.PROPOFID_AGECTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN);
                _.Move(executed_1.PROPOFID_OPRCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN);
                _.Move(executed_1.PROPOFID_NUMCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN);
                _.Move(executed_1.PROPOFID_DIGCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);
                _.Move(executed_1.PROPOFID_CGC_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);
                _.Move(executed_1.PROPOFID_NOME_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);
                _.Move(executed_1.PROPOFID_NRMATRCON, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);
                _.Move(executed_1.PROPOFID_DTQITBCO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
                _.Move(executed_1.PROPOFID_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
                _.Move(executed_1.PROPOFID_AGEPGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);
                _.Move(executed_1.PROPOFID_VAL_TARIFA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA);
                _.Move(executed_1.PROPOFID_VAL_IOF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF);
                _.Move(executed_1.PROPOFID_DATA_CREDITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);
                _.Move(executed_1.PROPOFID_VAL_COMISSAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO);
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_COD_USUARIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);
                _.Move(executed_1.PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(executed_1.PROPOFID_NSAS_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(executed_1.PROPOFID_NSL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);
                _.Move(executed_1.PROPOFID_NSAC_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);
                _.Move(executed_1.PROPOFID_SITUACAO_ENVIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0055-00-LER-ENDOSSO-SECTION */
        private void R0055_00_LER_ENDOSSO_SECTION()
        {
            /*" -980- MOVE 'R0055-00-LER-ENDOSSO' TO PARAGRAFO. */
            _.Move("R0055-00-LER-ENDOSSO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -982- MOVE 'SELECT ENDOSSO' TO COMANDO. */
            _.Move("SELECT ENDOSSO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -985- MOVE BILHETE-NUM-APOLICE OF DCLBILHETE TO ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -1009- PERFORM R0055_00_LER_ENDOSSO_DB_SELECT_1 */

            R0055_00_LER_ENDOSSO_DB_SELECT_1();

            /*" -1012- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1013- MOVE 'SIM' TO W-EXISTE-BILHETE */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_BILHETE);

                /*" -1014- ELSE */
            }
            else
            {


                /*" -1015- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1016- MOVE 'NAO' TO W-EXISTE-BILHETE */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_BILHETE);

                    /*" -1017- ELSE */
                }
                else
                {


                    /*" -1018- DISPLAY 'PF0706B - FIM ANORMAL' */
                    _.Display($"PF0706B - FIM ANORMAL");

                    /*" -1019- DISPLAY '          ERRO SELECT TAB. ENDOSSOS ' SQLCODE */
                    _.Display($"          ERRO SELECT TAB. ENDOSSOS {DB.SQLCODE}");

                    /*" -1021- DISPLAY '          NUMERO APOLICE........... ' ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS */
                    _.Display($"          NUMERO APOLICE........... {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                    /*" -1022- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1022- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0055-00-LER-ENDOSSO-DB-SELECT-1 */
        public void R0055_00_LER_ENDOSSO_DB_SELECT_1()
        {
            /*" -1009- EXEC SQL SELECT NUM_APOLICE, NUM_ENDOSSO, NUM_PROPOSTA, DATA_PROPOSTA, DATA_EMISSAO, NUM_RCAP, VAL_RCAP, DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE, :DCLENDOSSOS.ENDOSSOS-NUM-ENDOSSO, :DCLENDOSSOS.ENDOSSOS-NUM-PROPOSTA, :DCLENDOSSOS.ENDOSSOS-DATA-PROPOSTA, :DCLENDOSSOS.ENDOSSOS-DATA-EMISSAO, :DCLENDOSSOS.ENDOSSOS-NUM-RCAP, :DCLENDOSSOS.ENDOSSOS-VAL-RCAP, :DCLENDOSSOS.ENDOSSOS-DATA-INIVIGENCIA, :DCLENDOSSOS.ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE AND TIPO_ENDOSSO IN ( '2' , '5' ) AND SIT_REGISTRO NOT IN ( '2' ) WITH UR END-EXEC. */

            var r0055_00_LER_ENDOSSO_DB_SELECT_1_Query1 = new R0055_00_LER_ENDOSSO_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0055_00_LER_ENDOSSO_DB_SELECT_1_Query1.Execute(r0055_00_LER_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(executed_1.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_DATA_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_DATA_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);
                _.Move(executed_1.ENDOSSOS_NUM_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP);
                _.Move(executed_1.ENDOSSOS_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0055_SAIDA*/

        [StopWatch]
        /*" R0056-00-LER-ENDOSSO-SECTION */
        private void R0056_00_LER_ENDOSSO_SECTION()
        {
            /*" -1031- MOVE 'R0056-00-LER-ENDOSSO' TO PARAGRAFO. */
            _.Move("R0056-00-LER-ENDOSSO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1033- MOVE 'SELECT ENDOSSO' TO COMANDO. */
            _.Move("SELECT ENDOSSO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1036- MOVE BILHETE-NUM-APOLICE OF DCLBILHETE TO ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -1058- PERFORM R0056_00_LER_ENDOSSO_DB_SELECT_1 */

            R0056_00_LER_ENDOSSO_DB_SELECT_1();

            /*" -1061- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1062- MOVE 'SIM' TO W-EXISTE-BILHETE */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_BILHETE);

                /*" -1063- ELSE */
            }
            else
            {


                /*" -1064- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1065- MOVE 'NAO' TO W-EXISTE-BILHETE */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_BILHETE);

                    /*" -1066- ELSE */
                }
                else
                {


                    /*" -1067- DISPLAY 'PF0706B - FIM ANORMAL' */
                    _.Display($"PF0706B - FIM ANORMAL");

                    /*" -1068- DISPLAY '          ERRO SELECT TAB. ENDOSSOS ' SQLCODE */
                    _.Display($"          ERRO SELECT TAB. ENDOSSOS {DB.SQLCODE}");

                    /*" -1070- DISPLAY '          NUMERO APOLICE........... ' ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS */
                    _.Display($"          NUMERO APOLICE........... {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                    /*" -1071- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1071- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0056-00-LER-ENDOSSO-DB-SELECT-1 */
        public void R0056_00_LER_ENDOSSO_DB_SELECT_1()
        {
            /*" -1058- EXEC SQL SELECT NUM_APOLICE, NUM_ENDOSSO, NUM_PROPOSTA, DATA_PROPOSTA, DATA_EMISSAO, NUM_RCAP, VAL_RCAP, DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE, :DCLENDOSSOS.ENDOSSOS-NUM-ENDOSSO, :DCLENDOSSOS.ENDOSSOS-NUM-PROPOSTA, :DCLENDOSSOS.ENDOSSOS-DATA-PROPOSTA, :DCLENDOSSOS.ENDOSSOS-DATA-EMISSAO, :DCLENDOSSOS.ENDOSSOS-NUM-RCAP, :DCLENDOSSOS.ENDOSSOS-VAL-RCAP, :DCLENDOSSOS.ENDOSSOS-DATA-INIVIGENCIA, :DCLENDOSSOS.ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE WITH UR END-EXEC. */

            var r0056_00_LER_ENDOSSO_DB_SELECT_1_Query1 = new R0056_00_LER_ENDOSSO_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0056_00_LER_ENDOSSO_DB_SELECT_1_Query1.Execute(r0056_00_LER_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(executed_1.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_DATA_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_DATA_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);
                _.Move(executed_1.ENDOSSOS_NUM_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP);
                _.Move(executed_1.ENDOSSOS_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0056_SAIDA*/

        [StopWatch]
        /*" R0060-00-LER-HISTORICO-SECTION */
        private void R0060_00_LER_HISTORICO_SECTION()
        {
            /*" -1080- MOVE 'R0060-00-LER-HISTORICO' TO PARAGRAFO. */
            _.Move("R0060-00-LER-HISTORICO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1082- MOVE 'SELECT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("SELECT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1087- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1090- MOVE BILHETE-DATA-CANCELAMENTO OF DCLBILHETE TO PROPFIDH-DATA-SITUACAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -1093- MOVE 'CAN' TO PROPFIDH-SIT-PROPOSTA. */
            _.Move("CAN", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1104- PERFORM R0060_00_LER_HISTORICO_DB_SELECT_1 */

            R0060_00_LER_HISTORICO_DB_SELECT_1();

            /*" -1107- IF SQLCODE EQUAL 00 OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -1108- MOVE 'SIM' TO W-EXISTE-HISTORICO */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_HISTORICO);

                /*" -1109- ELSE */
            }
            else
            {


                /*" -1110- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1111- MOVE 'NAO' TO W-EXISTE-HISTORICO */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_HISTORICO);

                    /*" -1112- ELSE */
                }
                else
                {


                    /*" -1113- DISPLAY 'PF0706B - FIM ANORMAL' */
                    _.Display($"PF0706B - FIM ANORMAL");

                    /*" -1115- DISPLAY '          ERRO SELECT TAB. HIS-PROP-FIDELIZ  ' SQLCODE */
                    _.Display($"          ERRO SELECT TAB. HIS-PROP-FIDELIZ  {DB.SQLCODE}");

                    /*" -1117- DISPLAY '          NUM-IDENTIFICACAO................. ' PROPFIDH-NUM-IDENTIFICACAO */
                    _.Display($"          NUM-IDENTIFICACAO................. {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}");

                    /*" -1118- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1118- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0060-00-LER-HISTORICO-DB-SELECT-1 */
        public void R0060_00_LER_HISTORICO_DB_SELECT_1()
        {
            /*" -1104- EXEC SQL SELECT NSAS_SIVPF INTO :PROPFIDH-NSAS-SIVPF FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPFIDH-NUM-IDENTIFICACAO AND DATA_SITUACAO = :PROPFIDH-DATA-SITUACAO AND SIT_PROPOSTA = :PROPFIDH-SIT-PROPOSTA WITH UR END-EXEC. */

            var r0060_00_LER_HISTORICO_DB_SELECT_1_Query1 = new R0060_00_LER_HISTORICO_DB_SELECT_1_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_DATA_SITUACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
            };

            var executed_1 = R0060_00_LER_HISTORICO_DB_SELECT_1_Query1.Execute(r0060_00_LER_HISTORICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_SAIDA*/

        [StopWatch]
        /*" R0065-00-GERA-H-PROP-FIDEL-SECTION */
        private void R0065_00_GERA_H_PROP_FIDEL_SECTION()
        {
            /*" -1128- MOVE 'R0065-GERA-H-PROP-FIDEL' TO PARAGRAFO. */
            _.Move("R0065-GERA-H-PROP-FIDEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1130- MOVE 'INSERT HIST PROP FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST PROP FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1133- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1136- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO PROPFIDH-NSAS-SIVPF. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -1138- ADD 1 TO W-QTD-LD-TIPO-1. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;

            /*" -1141- MOVE W-QTD-LD-TIPO-1 TO PROPFIDH-NSL. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -1144- MOVE 'CAN' TO PROPFIDH-SIT-PROPOSTA. */
            _.Move("CAN", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1145- IF BILHETE-TIP-CANCELAMENTO OF DCLBILHETE EQUAL 1 */

            if (BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO == 1)
            {

                /*" -1146- MOVE 101 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                _.Move(101, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                /*" -1147- MOVE 'SUS' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                _.Move("SUS", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                /*" -1148- ELSE */
            }
            else
            {


                /*" -1149- IF BILHETE-TIP-CANCELAMENTO OF DCLBILHETE EQUAL 2 */

                if (BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO == 2)
                {

                    /*" -1150- MOVE 102 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                    _.Move(102, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                    /*" -1151- MOVE 'PAG' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                    _.Move("PAG", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                    /*" -1152- ELSE */
                }
                else
                {


                    /*" -1154- IF BILHETE-TIP-CANCELAMENTO OF DCLBILHETE EQUAL 3 */

                    if (BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO == 3)
                    {

                        /*" -1155- MOVE 100 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                        _.Move(100, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                        /*" -1156- MOVE 'CAN' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                        _.Move("CAN", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                        /*" -1157- ELSE */
                    }
                    else
                    {


                        /*" -1158- IF BILHETE-TIP-CANCELAMENTO OF DCLBILHETE EQUAL 4 */

                        if (BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO == 4)
                        {

                            /*" -1159- MOVE 106 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                            _.Move(106, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                            /*" -1160- MOVE 'CAN' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                            _.Move("CAN", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                            /*" -1161- ELSE */
                        }
                        else
                        {


                            /*" -1162- DISPLAY '*--------------------------------------*' */
                            _.Display($"*--------------------------------------*");

                            /*" -1164- DISPLAY '*  PF0706 - TIPO CANCELAMENTO INVALIDO * ' BILHETE-TIP-CANCELAMENTO */
                            _.Display($"*  PF0706 - TIPO CANCELAMENTO INVALIDO * {BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO}");

                            /*" -1166- DISPLAY '*           NUMERO DO BILHETE          * ' BILHETE-NUM-BILHETE */
                            _.Display($"*           NUMERO DO BILHETE          * {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                            /*" -1167- DISPLAY '*--------------------------------------*' */
                            _.Display($"*--------------------------------------*");

                            /*" -1168- PERFORM R9988-00-FECHAR-ARQUIVOS */

                            R9988_00_FECHAR_ARQUIVOS_SECTION();

                            /*" -1173- PERFORM R9999-00-FINALIZAR. */

                            R9999_00_FINALIZAR_SECTION();
                        }

                    }

                }

            }


            /*" -1176- MOVE BILHETE-DATA-CANCELAMENTO OF DCLBILHETE TO PROPFIDH-DATA-SITUACAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -1179- MOVE PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -1182- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -1193- PERFORM R0065_00_GERA_H_PROP_FIDEL_DB_INSERT_1 */

            R0065_00_GERA_H_PROP_FIDEL_DB_INSERT_1();

            /*" -1196- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1197- DISPLAY 'PF0706B - FIM ANORMAL' */
                _.Display($"PF0706B - FIM ANORMAL");

                /*" -1198- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -1200- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1202- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                /*" -1204- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1205- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1205- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0065-00-GERA-H-PROP-FIDEL-DB-INSERT-1 */
        public void R0065_00_GERA_H_PROP_FIDEL_DB_INSERT_1()
        {
            /*" -1193- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

            var r0065_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1 = new R0065_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1()
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

            R0065_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1.Execute(r0065_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0065_SAIDA*/

        [StopWatch]
        /*" R0070-00-GERAR-REGISTRO-TP1-SECTION */
        private void R0070_00_GERAR_REGISTRO_TP1_SECTION()
        {
            /*" -1216- MOVE 'R0070-00-GERAR-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0070-00-GERAR-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1218- MOVE 'WRITE REG-STA-PROPOSTA' TO COMANDO. */
            _.Move("WRITE REG-STA-PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1220- MOVE SPACES TO REG-STA-PROPOSTA. */
            _.Move("", LBFCT011.REG_STA_PROPOSTA);

            /*" -1223- MOVE '1' TO R1-TIPO-REG OF REG-STA-PROPOSTA. */
            _.Move("1", LBFCT011.REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -1226- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -1229- MOVE PROPFIDH-SIT-PROPOSTA TO R1-SIT-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA, LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

            /*" -1232- MOVE PROPFIDH-SIT-MOTIVO-SIVPF TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);

            /*" -1235- MOVE PROPFIDH-DATA-SITUACAO TO W-DATA-SQL. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1236- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1237- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1239- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1242- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -1245- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO R1-NSAS OF REG-STA-PROPOSTA. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NSAS);

            /*" -1248- MOVE PROPFIDH-NSL TO R1-NSL OF REG-STA-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL, LBFCT011.REG_STA_PROPOSTA.R1_NSL);

            /*" -1248- WRITE REG-STA-BILHETE FROM REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_BILHETE);

            MOVTO_STA_BILHETE.Write(REG_STA_BILHETE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0075-00-ATUALIZA-PRP-FIDELIZ-SECTION */
        private void R0075_00_ATUALIZA_PRP_FIDELIZ_SECTION()
        {
            /*" -1255- MOVE 'R0075-00-ATUALIZA-PRP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0075-00-ATUALIZA-PRP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1257- MOVE 'UPDATE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1272- PERFORM R0075_00_ATUALIZA_PRP_FIDELIZ_DB_UPDATE_1 */

            R0075_00_ATUALIZA_PRP_FIDELIZ_DB_UPDATE_1();

            /*" -1275- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1276- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1277- DISPLAY '  NAO ENCONTROU NA PROPOSTA-FIDELIZ' */
                    _.Display($"  NAO ENCONTROU NA PROPOSTA-FIDELIZ");

                    /*" -1279- DISPLAY '          NUMERO PROPOSTA...........  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO PROPOSTA...........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -1281- DISPLAY '          NUMERO IDENTIFICACAO......  ' PROPOFID-NUM-IDENTIFICACAO */
                    _.Display($"          NUMERO IDENTIFICACAO......  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -1283- DISPLAY '          TIMESTAMP RELATORIOS .....  ' RELATORI-TIMESTAMP OF DCLRELATORIOS */
                    _.Display($"          TIMESTAMP RELATORIOS .....  {RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP}");

                    /*" -1285- DISPLAY '          SQLCODE...................  ' SQLCODE */
                    _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                    /*" -1286- ELSE */
                }
                else
                {


                    /*" -1287- DISPLAY 'PF0706B - FIM ANORMAL' */
                    _.Display($"PF0706B - FIM ANORMAL");

                    /*" -1288- DISPLAY '          ERRO UPDATE PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO UPDATE PROPOSTA-FIDELIZ");

                    /*" -1290- DISPLAY '          NUMERO PROPOSTA...........  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO PROPOSTA...........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -1292- DISPLAY '          NUMERO IDENTIFICACAO......  ' PROPOFID-NUM-IDENTIFICACAO */
                    _.Display($"          NUMERO IDENTIFICACAO......  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -1294- DISPLAY '          SQLCODE...................  ' SQLCODE */
                    _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                    /*" -1295- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1296- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1297- END-IF */
                }


                /*" -1297- END-IF. */
            }


        }

        [StopWatch]
        /*" R0075-00-ATUALIZA-PRP-FIDELIZ-DB-UPDATE-1 */
        public void R0075_00_ATUALIZA_PRP_FIDELIZ_DB_UPDATE_1()
        {
            /*" -1272- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :PROPFIDH-SIT-PROPOSTA, SITUACAO_ENVIO = 'R' , NSAS_SIVPF = :PROPOFID-NSAS-SIVPF , NSL = :PROPOFID-NSL , COD_USUARIO = 'PF0706B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF AND SITUACAO_ENVIO <> 'S' END-EXEC. */

            var r0075_00_ATUALIZA_PRP_FIDELIZ_DB_UPDATE_1_Update1 = new R0075_00_ATUALIZA_PRP_FIDELIZ_DB_UPDATE_1_Update1()
            {
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
                PROPOFID_NSAS_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF.ToString(),
                PROPOFID_NSL = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0075_00_ATUALIZA_PRP_FIDELIZ_DB_UPDATE_1_Update1.Execute(r0075_00_ATUALIZA_PRP_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0075_SAIDA*/

        [StopWatch]
        /*" R0080-00-SELECIONA-BIL-COB-SECTION */
        private void R0080_00_SELECIONA_BIL_COB_SECTION()
        {
            /*" -1307- MOVE 'R0080-00-SELECIONA-BIL-COBE' TO PARAGRAFO. */
            _.Move("R0080-00-SELECIONA-BIL-COBE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1309- MOVE 'DECLARE BILHETE-COBER' TO COMANDO. */
            _.Move("DECLARE BILHETE-COBER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1312- MOVE BILHETE-RAMO OF DCLBILHETE TO BILCOBER-RAMO-COBERTURA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_RAMO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA);

            /*" -1315- MOVE BILHETE-OPC-COBERTURA OF DCLBILHETE TO BILCOBER-COD-OPCAO-PLANO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO);

            /*" -1318- MOVE ENDOSSOS-DATA-INIVIGENCIA OF DCLENDOSSOS TO BILCOBER-DATA-INIVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA);

            /*" -1322- MOVE ENDOSSOS-DATA-TERVIGENCIA OF DCLENDOSSOS TO BILCOBER-DATA-TERVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_TERVIGENCIA);

            /*" -1349- PERFORM R0080_00_SELECIONA_BIL_COB_DB_DECLARE_1 */

            R0080_00_SELECIONA_BIL_COB_DB_DECLARE_1();

            /*" -1359- PERFORM R0080_00_SELECIONA_BIL_COB_DB_OPEN_1 */

            R0080_00_SELECIONA_BIL_COB_DB_OPEN_1();

            /*" -1362- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1363- DISPLAY 'PF0706B - FIM ANORMAL' */
                _.Display($"PF0706B - FIM ANORMAL");

                /*" -1365- DISPLAY '          ERRO OPEN CURSOR BILHETE-COBERTURA  ' SQLCODE */
                _.Display($"          ERRO OPEN CURSOR BILHETE-COBERTURA  {DB.SQLCODE}");

                /*" -1366- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1366- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0080-00-SELECIONA-BIL-COB-DB-OPEN-1 */
        public void R0080_00_SELECIONA_BIL_COB_DB_OPEN_1()
        {
            /*" -1359- EXEC SQL OPEN BILHETE-COBERTURA END-EXEC. */

            BILHETE_COBERTURA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0085-00-LER-BILHETE-COBER-SECTION */
        private void R0085_00_LER_BILHETE_COBER_SECTION()
        {
            /*" -1375- MOVE 'R0085-00-LER-BILHETE-COBER' TO PARAGRAFO. */
            _.Move("R0085-00-LER-BILHETE-COBER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1377- MOVE 'FETCH BILHETE-COBERTURA' TO COMANDO. */
            _.Move("FETCH BILHETE-COBERTURA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1390- PERFORM R0085_00_LER_BILHETE_COBER_DB_FETCH_1 */

            R0085_00_LER_BILHETE_COBER_DB_FETCH_1();

            /*" -1393- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1394- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1395- MOVE 'FIM' TO W-FIM-BILHETE-COB */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_BILHETE_COB);

                    /*" -1395- PERFORM R0085_00_LER_BILHETE_COBER_DB_CLOSE_1 */

                    R0085_00_LER_BILHETE_COBER_DB_CLOSE_1();

                    /*" -1397- ELSE */
                }
                else
                {


                    /*" -1398- DISPLAY 'PF0706B - FIM ANORMAL' */
                    _.Display($"PF0706B - FIM ANORMAL");

                    /*" -1399- DISPLAY '          ERRO FETCH CURSOR BILHETE-COBERTURA' */
                    _.Display($"          ERRO FETCH CURSOR BILHETE-COBERTURA");

                    /*" -1401- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -1402- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1404- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -1405- COMPUTE W-IND-IOF = (BILCOBER-PCT-IOCC / 100) + 1. */
            WAREA_AUXILIAR.W_IND_IOF.Value = (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PCT_IOCC / 100f) + 1;

        }

        [StopWatch]
        /*" R0085-00-LER-BILHETE-COBER-DB-FETCH-1 */
        public void R0085_00_LER_BILHETE_COBER_DB_FETCH_1()
        {
            /*" -1390- EXEC SQL FETCH BILHETE-COBERTURA INTO :BILCOBER-COD-PRODUTO, :BILCOBER-RAMO-COBERTURA, :BILCOBER-MODALI-COBERTURA, :BILCOBER-COD-OPCAO-PLANO, :BILCOBER-COD-COBERTURA, :BILCOBER-DATA-INIVIGENCIA, :BILCOBER-DATA-TERVIGENCIA, :BILCOBER-IDE-COBERTURA, :BILCOBER-VAL-COBERTURA-IX, :BILCOBER-PRM-TOTAL, :BILCOBER-PCT-IOCC END-EXEC. */

            if (BILHETE_COBERTURA.Fetch())
            {
                _.Move(BILHETE_COBERTURA.BILCOBER_COD_PRODUTO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO);
                _.Move(BILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA);
                _.Move(BILHETE_COBERTURA.BILCOBER_MODALI_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_MODALI_COBERTURA);
                _.Move(BILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO);
                _.Move(BILHETE_COBERTURA.BILCOBER_COD_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_COBERTURA);
                _.Move(BILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA);
                _.Move(BILHETE_COBERTURA.BILCOBER_DATA_TERVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_TERVIGENCIA);
                _.Move(BILHETE_COBERTURA.BILCOBER_IDE_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_IDE_COBERTURA);
                _.Move(BILHETE_COBERTURA.BILCOBER_VAL_COBERTURA_IX, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_COBERTURA_IX);
                _.Move(BILHETE_COBERTURA.BILCOBER_PRM_TOTAL, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL);
                _.Move(BILHETE_COBERTURA.BILCOBER_PCT_IOCC, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PCT_IOCC);
            }

        }

        [StopWatch]
        /*" R0085-00-LER-BILHETE-COBER-DB-CLOSE-1 */
        public void R0085_00_LER_BILHETE_COBER_DB_CLOSE_1()
        {
            /*" -1395- EXEC SQL CLOSE BILHETE-COBERTURA END-EXEC */

            BILHETE_COBERTURA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0085_SAIDA*/

        [StopWatch]
        /*" R0090-00-GERAR-REGISTROS-SECTION */
        private void R0090_00_GERAR_REGISTROS_SECTION()
        {
            /*" -1415- MOVE 'R0090-00-GERAR-REGISTROS' TO PARAGRAFO. */
            _.Move("R0090-00-GERAR-REGISTROS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1417- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1418- IF W-BILHETE-LIDO EQUAL 1 */

            if (WAREA_AUXILIAR.W_BILHETE_LIDO == 1)
            {

                /*" -1420- PERFORM R0100-00-GERAR-REG-TP2-BIL. */

                R0100_00_GERAR_REG_TP2_BIL_SECTION();
            }


            /*" -1422- MOVE 1 TO W-REG-BIL-AP. */
            _.Move(1, WAREA_AUXILIAR.W_REG_BIL_AP);

            /*" -1423- IF BILHETE-AP */

            if (WAREA_AUXILIAR.W_PRODUTO["BILHETE_AP"])
            {

                /*" -1424- ADD 1 TO W-LIDO-BIL-AP */
                WAREA_AUXILIAR.W_LIDO_BIL_AP.Value = WAREA_AUXILIAR.W_LIDO_BIL_AP + 1;

                /*" -1425- MOVE 09 TO W-SUBPRODUTO */
                _.Move(09, WAREA_AUXILIAR.FILLER_0.W_SUBPRODUTO);

                /*" -1427- PERFORM R0105-00-GERAR-REG-TP3-AP 2 TIMES */

                for (int i = 0; i < 2; i++)
                {

                    R0105_00_GERAR_REG_TP3_AP_SECTION();

                }

                /*" -1428- ELSE */
            }
            else
            {


                /*" -1429- ADD 1 TO W-LIDO-BIL-RD */
                WAREA_AUXILIAR.W_LIDO_BIL_RD.Value = WAREA_AUXILIAR.W_LIDO_BIL_RD + 1;

                /*" -1430- MOVE 10 TO W-SUBPRODUTO */
                _.Move(10, WAREA_AUXILIAR.FILLER_0.W_SUBPRODUTO);

                /*" -1432- PERFORM R0110-00-GERAR-REG-TP3-RD. */

                R0110_00_GERAR_REG_TP3_RD_SECTION();
            }


            /*" -1434- PERFORM R0085-00-LER-BILHETE-COBER. */

            R0085_00_LER_BILHETE_COBER_SECTION();

            /*" -1434- ADD 1 TO W-BILHETE-LIDO. */
            WAREA_AUXILIAR.W_BILHETE_LIDO.Value = WAREA_AUXILIAR.W_BILHETE_LIDO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0090_SAIDA*/

        [StopWatch]
        /*" R0100-00-GERAR-REG-TP2-BIL-SECTION */
        private void R0100_00_GERAR_REG_TP2_BIL_SECTION()
        {
            /*" -1444- MOVE 'R0100-00-GERAR-REG-TP2-BIL' TO PARAGRAFO. */
            _.Move("R0100-00-GERAR-REG-TP2-BIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1446- MOVE 'WRITE REG-APOL-SASSE' TO COMANDO. */
            _.Move("WRITE REG-APOL-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1448- MOVE SPACES TO REG-APOL-SASSE. */
            _.Move("", LBFCT016.REG_APOL_SASSE);

            /*" -1451- MOVE '2' TO R2-TIPO-REG OF REG-APOL-SASSE. */
            _.Move("2", LBFCT016.REG_APOL_SASSE.R2_TIPO_REG);

            /*" -1467- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R2-NUM-PROPOSTA OF REG-APOL-SASSE, R2-NRCERTIF OF REG-APOL-SASSE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT016.REG_APOL_SASSE.R2_NUM_PROPOSTA, LBFCT016.REG_APOL_SASSE.R2_NRCERTIF);

            /*" -1469- MOVE ENDOSSOS-DATA-INIVIGENCIA OF DCLENDOSSOS TO W-DATA-SQL. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1471- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1473- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1476- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1484- MOVE W-DATA-TRABALHO TO R2-DTTERVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTTERVIG);

            /*" -1486- PERFORM R0101-00-LER-ENDOSSO. */

            R0101_00_LER_ENDOSSO_SECTION();

            /*" -1488- MOVE ENDOSSOS-DATA-INIVIGENCIA OF DCLENDOSSOS TO W-DATA-SQL. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1490- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1492- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1494- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1497- MOVE W-DATA-TRABALHO TO R2-DTINIVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTINIVIG);

            /*" -1498- IF BILCOBER-PRM-TOTAL GREATER ZEROS */

            if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL > 00)
            {

                /*" -1500- MOVE BILCOBER-PRM-TOTAL TO R2-VAL-PREMIO OF REG-APOL-SASSE */
                _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL, LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO);

                /*" -1501- ELSE */
            }
            else
            {


                /*" -1504- MOVE BILHETE-VAL-RCAP OF DCLBILHETE TO R2-VAL-PREMIO OF REG-APOL-SASSE. */
                _.Move(BILHETE.DCLBILHETE.BILHETE_VAL_RCAP, LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO);
            }


            /*" -1507- COMPUTE W-PRM-LIQ = R2-VAL-PREMIO OF REG-APOL-SASSE / W-IND-IOF. */
            WAREA_AUXILIAR.W_PRM_LIQ.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO / WAREA_AUXILIAR.W_IND_IOF;

            /*" -1511- COMPUTE R2-VAL-IOF OF REG-APOL-SASSE = R2-VAL-PREMIO OF REG-APOL-SASSE - W-PRM-LIQ. */
            LBFCT016.REG_APOL_SASSE.R2_VAL_IOF.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO - WAREA_AUXILIAR.W_PRM_LIQ;

            /*" -1513- WRITE REG-STA-BILHETE FROM REG-APOL-SASSE. */
            _.Move(LBFCT016.REG_APOL_SASSE.GetMoveValues(), REG_STA_BILHETE);

            MOVTO_STA_BILHETE.Write(REG_STA_BILHETE.GetMoveValues().ToString());

            /*" -1513- ADD 1 TO W-QTD-LD-TIPO-2. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_SAIDA*/

        [StopWatch]
        /*" R0101-00-LER-ENDOSSO-SECTION */
        private void R0101_00_LER_ENDOSSO_SECTION()
        {
            /*" -1523- MOVE 'R0101-00-LER-ENDOSSO' TO PARAGRAFO. */
            _.Move("R0101-00-LER-ENDOSSO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1525- MOVE 'SELECT ENDOSSO' TO COMANDO. */
            _.Move("SELECT ENDOSSO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1528- MOVE BILHETE-NUM-APOLICE OF DCLBILHETE TO ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -1531- MOVE ZEROS TO ENDOSSOS-NUM-ENDOSSO OF DCLENDOSSOS. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -1538- PERFORM R0101_00_LER_ENDOSSO_DB_SELECT_1 */

            R0101_00_LER_ENDOSSO_DB_SELECT_1();

            /*" -1541- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1542- DISPLAY 'PF0706B - FIM ANORMAL' */
                _.Display($"PF0706B - FIM ANORMAL");

                /*" -1543- DISPLAY '          ERRO SELECT TAB. ENDOSSOS ' */
                _.Display($"          ERRO SELECT TAB. ENDOSSOS ");

                /*" -1545- DISPLAY '          NUMERO APOLICE........... ' ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS */
                _.Display($"          NUMERO APOLICE........... {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -1546- DISPLAY '          SQLCODE.................. ' SQLCODE */
                _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                /*" -1547- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1547- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0101-00-LER-ENDOSSO-DB-SELECT-1 */
        public void R0101_00_LER_ENDOSSO_DB_SELECT_1()
        {
            /*" -1538- EXEC SQL SELECT DATA_INIVIGENCIA INTO :DCLENDOSSOS.ENDOSSOS-DATA-INIVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :DCLENDOSSOS.ENDOSSOS-NUM-ENDOSSO WITH UR END-EXEC. */

            var r0101_00_LER_ENDOSSO_DB_SELECT_1_Query1 = new R0101_00_LER_ENDOSSO_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0101_00_LER_ENDOSSO_DB_SELECT_1_Query1.Execute(r0101_00_LER_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_SAIDA*/

        [StopWatch]
        /*" R0105-00-GERAR-REG-TP3-AP-SECTION */
        private void R0105_00_GERAR_REG_TP3_AP_SECTION()
        {
            /*" -1557- MOVE 'R0105-00-GERAR-REG-TP3-AP' TO PARAGRAFO. */
            _.Move("R0105-00-GERAR-REG-TP3-AP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1559- MOVE 'WRITE REG-COBER-SASSE' TO COMANDO. */
            _.Move("WRITE REG-COBER-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1561- MOVE SPACES TO REG-COBER-SASSE. */
            _.Move("", LBFCT016.REG_COBER_SASSE);

            /*" -1564- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -1567- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -1574- MOVE BILCOBER-VAL-COBERTURA-IX TO R3-VAL-COBERTURA OF REG-COBER-SASSE. */
            _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_COBERTURA_IX, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

            /*" -1575- IF W-REG-BIL-AP EQUAL 1 */

            if (WAREA_AUXILIAR.W_REG_BIL_AP == 1)
            {

                /*" -1576- MOVE 1 TO W-COBERTURA */
                _.Move(1, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -1577- ELSE */
            }
            else
            {


                /*" -1579- MOVE 2 TO W-COBERTURA. */
                _.Move(2, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);
            }


            /*" -1582- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE. */
            _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

            /*" -1585- ADD 1 TO W-QTD-LD-TIPO-3, W-REG-BIL-AP. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;
            WAREA_AUXILIAR.W_REG_BIL_AP.Value = WAREA_AUXILIAR.W_REG_BIL_AP + 1;

            /*" -1585- WRITE REG-STA-BILHETE FROM REG-COBER-SASSE. */
            _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_BILHETE);

            MOVTO_STA_BILHETE.Write(REG_STA_BILHETE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0105_SAIDA*/

        [StopWatch]
        /*" R0110-00-GERAR-REG-TP3-RD-SECTION */
        private void R0110_00_GERAR_REG_TP3_RD_SECTION()
        {
            /*" -1595- MOVE 'R0110-00-GERAR-REG-TP3-RD' TO PARAGRAFO. */
            _.Move("R0110-00-GERAR-REG-TP3-RD", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1597- MOVE 'WRITE REG-COBER-SASSE' TO COMANDO. */
            _.Move("WRITE REG-COBER-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1599- MOVE SPACES TO REG-COBER-SASSE. */
            _.Move("", LBFCT016.REG_COBER_SASSE);

            /*" -1602- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -1605- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -1609- MOVE BILCOBER-VAL-COBERTURA-IX TO R3-VAL-COBERTURA OF REG-COBER-SASSE. */
            _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_COBERTURA_IX, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

            /*" -1610- IF BILCOBER-COD-COBERTURA EQUAL 2000 */

            if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_COBERTURA == 2000)
            {

                /*" -1613- MOVE 1 TO W-COBERTURA. */
                _.Move(1, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);
            }


            /*" -1614- IF BILCOBER-COD-COBERTURA EQUAL 2200 */

            if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_COBERTURA == 2200)
            {

                /*" -1617- MOVE 2 TO W-COBERTURA. */
                _.Move(2, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);
            }


            /*" -1618- IF BILCOBER-COD-COBERTURA EQUAL 2100 */

            if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_COBERTURA == 2100)
            {

                /*" -1620- MOVE 3 TO W-COBERTURA. */
                _.Move(3, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);
            }


            /*" -1623- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE. */
            _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

            /*" -1625- ADD 1 TO W-QTD-LD-TIPO-3 */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

            /*" -1625- WRITE REG-STA-BILHETE FROM REG-COBER-SASSE. */
            _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_BILHETE);

            MOVTO_STA_BILHETE.Write(REG_STA_BILHETE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_SAIDA*/

        [StopWatch]
        /*" R0120-00-GERAR-REG-TP4-SECTION */
        private void R0120_00_GERAR_REG_TP4_SECTION()
        {
            /*" -1635- MOVE 'R0100-00-GERAR-REG-TP2-BIL' TO PARAGRAFO. */
            _.Move("R0100-00-GERAR-REG-TP2-BIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1637- MOVE 'WRITE REG-APOL-SASSE' TO COMANDO. */
            _.Move("WRITE REG-APOL-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1639- MOVE SPACES TO REG-PGTO-SASSE. */
            _.Move("", LBFCT016.REG_PGTO_SASSE);

            /*" -1642- MOVE '4' TO R4-TIPO-REG OF REG-PGTO-SASSE. */
            _.Move("4", LBFCT016.REG_PGTO_SASSE.R4_TIPO_REG);

            /*" -1645- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R4-NUM-PROPOSTA OF REG-PGTO-SASSE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA);

            /*" -1650- MOVE PROPFIDH-SIT-COBRANCA-SIVPF TO R4-SIT-COBRANCA OF REG-PGTO-SASSE. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA);

            /*" -1653- MOVE PROPFIDH-DATA-SITUACAO TO W-DATA-SQL. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1655- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1657- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1660- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1663- MOVE W-DATA-TRABALHO TO R4-DATA-SITUACAO OF REG-PGTO-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO);

            /*" -1667- MOVE 1 TO R4-PARCELAS-PAGAS OF REG-PGTO-SASSE R4-TOTAL-PARCELAS OF REG-PGTO-SASSE. */
            _.Move(1, LBFCT016.REG_PGTO_SASSE.R4_PARCELAS_PAGAS, LBFCT016.REG_PGTO_SASSE.R4_TOTAL_PARCELAS);

            /*" -1669- WRITE REG-STA-BILHETE FROM REG-PGTO-SASSE. */
            _.Move(LBFCT016.REG_PGTO_SASSE.GetMoveValues(), REG_STA_BILHETE);

            MOVTO_STA_BILHETE.Write(REG_STA_BILHETE.GetMoveValues().ToString());

            /*" -1669- ADD 1 TO W-QTD-LD-TIPO-4. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_4.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_SAIDA*/

        [StopWatch]
        /*" R0125-00-LER-H-PROP-FIDEL-SECTION */
        private void R0125_00_LER_H_PROP_FIDEL_SECTION()
        {
            /*" -1679- MOVE 'R0125-LER-H-PROP-FIDEL' TO PARAGRAFO. */
            _.Move("R0125-LER-H-PROP-FIDEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1681- MOVE 'SELECT HIST PROP FIDELIZ - ENV' TO COMANDO. */
            _.Move("SELECT HIST PROP FIDELIZ - ENV", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1684- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1687- MOVE 'ENV' TO PROPFIDH-SIT-PROPOSTA. */
            _.Move("ENV", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1696- PERFORM R0125_00_LER_H_PROP_FIDEL_DB_SELECT_1 */

            R0125_00_LER_H_PROP_FIDEL_DB_SELECT_1();

            /*" -1699- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1700- MOVE 1 TO W-TEM-HISTORICO */
                _.Move(1, WAREA_AUXILIAR.W_TEM_HISTORICO);

                /*" -1701- ELSE */
            }
            else
            {


                /*" -1702- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1703- DISPLAY 'PF0706B - FIM ANORMAL' */
                    _.Display($"PF0706B - FIM ANORMAL");

                    /*" -1704- DISPLAY '          ERRO SELECT HIST-PROP-FIDELIZ' */
                    _.Display($"          ERRO SELECT HIST-PROP-FIDELIZ");

                    /*" -1706- DISPLAY '          NUMERO PROPOSTA............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO PROPOSTA............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -1708- DISPLAY '          NUMERO IDENTIFICACAO.......  ' PROPOFID-NUM-IDENTIFICACAO */
                    _.Display($"          NUMERO IDENTIFICACAO.......  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -1710- DISPLAY '          SQLCODE....................  ' SQLCODE */
                    _.Display($"          SQLCODE....................  {DB.SQLCODE}");

                    /*" -1711- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1712- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1714- ELSE */
                }
                else
                {


                    /*" -1716- MOVE 'SELECT HIST PROP FIDELIZ - 228/731' TO COMANDO */
                    _.Move("SELECT HIST PROP FIDELIZ - 228/731", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1724- PERFORM R0125_00_LER_H_PROP_FIDEL_DB_SELECT_2 */

                    R0125_00_LER_H_PROP_FIDEL_DB_SELECT_2();

                    /*" -1727- IF SQLCODE NOT EQUAL 00 */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1728- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -1729- MOVE 2 TO W-TEM-HISTORICO */
                            _.Move(2, WAREA_AUXILIAR.W_TEM_HISTORICO);

                            /*" -1730- ELSE */
                        }
                        else
                        {


                            /*" -1731- IF SQLCODE EQUAL -811 */

                            if (DB.SQLCODE == -811)
                            {

                                /*" -1732- MOVE 1 TO W-TEM-HISTORICO */
                                _.Move(1, WAREA_AUXILIAR.W_TEM_HISTORICO);

                                /*" -1733- ELSE */
                            }
                            else
                            {


                                /*" -1734- DISPLAY 'PF0706B - FIM ANORMAL' */
                                _.Display($"PF0706B - FIM ANORMAL");

                                /*" -1735- DISPLAY '         ERRO SELECT HIST-PROP-FIDELIZ' */
                                _.Display($"         ERRO SELECT HIST-PROP-FIDELIZ");

                                /*" -1737- DISPLAY '         NUMERO PROPOSTA............. ' PROPOFID-NUM-PROPOSTA-SIVPF */
                                _.Display($"         NUMERO PROPOSTA............. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                                /*" -1739- DISPLAY '         NUMERO IDENTIFICACAO........ ' PROPOFID-NUM-IDENTIFICACAO */
                                _.Display($"         NUMERO IDENTIFICACAO........ {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                                /*" -1741- DISPLAY '         SQLCODE..................... ' SQLCODE */
                                _.Display($"         SQLCODE..................... {DB.SQLCODE}");

                                /*" -1742- PERFORM R9988-00-FECHAR-ARQUIVOS */

                                R9988_00_FECHAR_ARQUIVOS_SECTION();

                                /*" -1743- PERFORM R9999-00-FINALIZAR */

                                R9999_00_FINALIZAR_SECTION();

                                /*" -1744- ELSE */
                            }

                        }

                    }
                    else
                    {


                        /*" -1744- MOVE 1 TO W-TEM-HISTORICO. */
                        _.Move(1, WAREA_AUXILIAR.W_TEM_HISTORICO);
                    }

                }

            }


        }

        [StopWatch]
        /*" R0125-00-LER-H-PROP-FIDEL-DB-SELECT-1 */
        public void R0125_00_LER_H_PROP_FIDEL_DB_SELECT_1()
        {
            /*" -1696- EXEC SQL SELECT NUM_IDENTIFICACAO INTO :PROPFIDH-NUM-IDENTIFICACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPFIDH-NUM-IDENTIFICACAO AND SIT_PROPOSTA = :PROPFIDH-SIT-PROPOSTA WITH UR END-EXEC. */

            var r0125_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1 = new R0125_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
            };

            var executed_1 = R0125_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1.Execute(r0125_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0125_SAIDA*/

        [StopWatch]
        /*" R0125-00-LER-H-PROP-FIDEL-DB-SELECT-2 */
        public void R0125_00_LER_H_PROP_FIDEL_DB_SELECT_2()
        {
            /*" -1724- EXEC SQL SELECT NUM_IDENTIFICACAO INTO :PROPFIDH-NUM-IDENTIFICACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPFIDH-NUM-IDENTIFICACAO AND SIT_MOTIVO_SIVPF IN (228, 731) WITH UR END-EXEC */

            var r0125_00_LER_H_PROP_FIDEL_DB_SELECT_2_Query1 = new R0125_00_LER_H_PROP_FIDEL_DB_SELECT_2_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
            };

            var executed_1 = R0125_00_LER_H_PROP_FIDEL_DB_SELECT_2_Query1.Execute(r0125_00_LER_H_PROP_FIDEL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);
            }


        }

        [StopWatch]
        /*" R0130-00-OBTER-PRM-DEV-SECTION */
        private void R0130_00_OBTER_PRM_DEV_SECTION()
        {
            /*" -1754- MOVE 'R0130-00-OBTER-PRM-DEV' TO PARAGRAFO. */
            _.Move("R0130-00-OBTER-PRM-DEV", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1756- MOVE 'SELECT RCAP' TO COMANDO. */
            _.Move("SELECT RCAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1758- MOVE '8' TO CBCONDEV-TIPO-MOVIMENTO. */
            _.Move("8", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO);

            /*" -1761- MOVE BILHETE-NUM-BILHETE TO CBCONDEV-NUM-TITULO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO);

            /*" -1764- MOVE BILHETE-DATA-CANCELAMENTO TO CBCONDEV-DATA-MOVIMENTO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO);

            /*" -1772- PERFORM R0130_00_OBTER_PRM_DEV_DB_SELECT_1 */

            R0130_00_OBTER_PRM_DEV_DB_SELECT_1();

            /*" -1775- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1776- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1777- MOVE ZEROS TO R8-VLR-LANCAMENTO */
                    _.Move(0, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO);

                    /*" -1778- ELSE */
                }
                else
                {


                    /*" -1779- DISPLAY 'PF0706B - FIM ANORMAL' */
                    _.Display($"PF0706B - FIM ANORMAL");

                    /*" -1780- DISPLAY '          ERRO SELECT RCAPS' */
                    _.Display($"          ERRO SELECT RCAPS");

                    /*" -1782- DISPLAY '          NUMERO PROPOSTA. ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO PROPOSTA. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -1784- DISPLAY '          SQLCODE......... ' SQLCODE */
                    _.Display($"          SQLCODE......... {DB.SQLCODE}");

                    /*" -1785- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1786- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1787- ELSE */
                }

            }
            else
            {


                /*" -1787- MOVE CBCONDEV-VAL-OPERACAO TO R8-VLR-LANCAMENTO. */
                _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_OPERACAO, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO);
            }


        }

        [StopWatch]
        /*" R0130-00-OBTER-PRM-DEV-DB-SELECT-1 */
        public void R0130_00_OBTER_PRM_DEV_DB_SELECT_1()
        {
            /*" -1772- EXEC SQL SELECT VAL_OPERACAO INTO :CBCONDEV-VAL-OPERACAO FROM SEGUROS.CB_CONTR_DEVPREMIO WHERE TIPO_MOVIMENTO = :CBCONDEV-TIPO-MOVIMENTO AND NUM_TITULO = :CBCONDEV-NUM-TITULO AND DATA_MOVIMENTO = :CBCONDEV-DATA-MOVIMENTO WITH UR END-EXEC. */

            var r0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1 = new R0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1()
            {
                CBCONDEV_TIPO_MOVIMENTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO.ToString(),
                CBCONDEV_DATA_MOVIMENTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO.ToString(),
                CBCONDEV_NUM_TITULO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO.ToString(),
            };

            var executed_1 = R0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1.Execute(r0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBCONDEV_VAL_OPERACAO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_SAIDA*/

        [StopWatch]
        /*" R0135-00-GERAR-REGISTRO-TP8-SECTION */
        private void R0135_00_GERAR_REGISTRO_TP8_SECTION()
        {
            /*" -1797- MOVE 'R0135-00-GERAR-REGISTRO-TP8' TO PARAGRAFO. */
            _.Move("R0135-00-GERAR-REGISTRO-TP8", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1799- MOVE 'WRITE REGISTRO SIDEM' TO COMANDO. */
            _.Move("WRITE REGISTRO SIDEM", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1801- MOVE 8 TO R8-IDENTIFICACAO */
            _.Move(8, LBFPF025.R8_PONTUACAO_SIDEM.R8_IDENTIFICACAO);

            /*" -1804- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R8-NUM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PROPOSTA);

            /*" -1806- MOVE ZEROS TO R8-NUM-PARCELA, R8-VLR-ESTOQUE. */
            _.Move(0, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PARCELA, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_ESTOQUE);

            /*" -1808- MOVE 237 TO R8-TP-LANCAMENTO. */
            _.Move(237, LBFPF025.R8_PONTUACAO_SIDEM.R8_TP_LANCAMENTO);

            /*" -1810- WRITE REG-STA-BILHETE FROM R8-PONTUACAO-SIDEM. */
            _.Move(LBFPF025.R8_PONTUACAO_SIDEM.GetMoveValues(), REG_STA_BILHETE);

            MOVTO_STA_BILHETE.Write(REG_STA_BILHETE.GetMoveValues().ToString());

            /*" -1810- ADD 1 TO W-QTD-LD-TIPO-8. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_8.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0135_SAIDA*/

        [StopWatch]
        /*" R0200-00-GERAR-TRAILLER-SECTION */
        private void R0200_00_GERAR_TRAILLER_SECTION()
        {
            /*" -1820- MOVE 'R0200-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R0200-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1822- MOVE 'WRITE REG-TRAILLER' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1825- MOVE SPACES TO REG-TRAILLER-STA, REG-STA-BILHETE */
            _.Move("", LBFCT011.REG_TRAILLER_STA, REG_STA_BILHETE);

            /*" -1828- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA. */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -1831- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA. */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -1834- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1);

            /*" -1837- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2);

            /*" -1840- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3);

            /*" -1843- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4);

            /*" -1846- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_5, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5);

            /*" -1849- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_6, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6);

            /*" -1852- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_7, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7);

            /*" -1855- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8);

            /*" -1858- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_9, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9);

            /*" -1869- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -1869- WRITE REG-STA-BILHETE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_BILHETE);

            MOVTO_STA_BILHETE.Write(REG_STA_BILHETE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0250-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R0250_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -1883- MOVE 'R0250-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R0250-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1885- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1888- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -1890- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -1894- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -1897- MOVE RT-QTDE-TIPO-3 OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -1905- PERFORM R0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -1908- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1909- DISPLAY 'PF0706B - FIM ANORMAL' */
                _.Display($"PF0706B - FIM ANORMAL");

                /*" -1910- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -1912- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -1914- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -1916- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -1918- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -1920- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -1921- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1921- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0250-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -1905- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 = new R0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1.Execute(r0250_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0300-00-GERAR-TOTAIS-SECTION */
        private void R0300_00_GERAR_TOTAIS_SECTION()
        {
            /*" -1932- MOVE 'R0300-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R0300-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1934- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1944- COMPUTE W-TOT-GERADO-STA = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9. */
            WAREA_AUXILIAR.W_TOT_GERADO_STA.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9;

            /*" -1945- DISPLAY ' ' */
            _.Display($" ");

            /*" -1946- DISPLAY 'PF0706B - TOTAIS DO PROCESSAMENTO' */
            _.Display($"PF0706B - TOTAIS DO PROCESSAMENTO");

            /*" -1947- DISPLAY '          TOTAL  REGISTROS LIDOS........... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS........... {WAREA_AUXILIAR.W_NSL}");

            /*" -1949- DISPLAY '          TOTAL  PROPOSTAS DESPREZADAS..... ' W-TOT-DESPREZADO */
            _.Display($"          TOTAL  PROPOSTAS DESPREZADAS..... {WAREA_AUXILIAR.W_TOT_DESPREZADO}");

            /*" -1950- DISPLAY '          TOTAL  REGISTROS GERADOS STASASSE' */
            _.Display($"          TOTAL  REGISTROS GERADOS STASASSE");

            /*" -1952- DISPLAY '          TOTAL  REGISTROS TP-1............ ' W-QTD-LD-TIPO-1 */
            _.Display($"          TOTAL  REGISTROS TP-1............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -1954- DISPLAY '          TOTAL  REGISTROS TP-2............ ' W-QTD-LD-TIPO-2 */
            _.Display($"          TOTAL  REGISTROS TP-2............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_2}");

            /*" -1956- DISPLAY '          TOTAL  REGISTROS TP-3............ ' W-QTD-LD-TIPO-3 */
            _.Display($"          TOTAL  REGISTROS TP-3............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_3}");

            /*" -1958- DISPLAY '          TOTAL  REGISTROS TP-4............ ' W-QTD-LD-TIPO-4 */
            _.Display($"          TOTAL  REGISTROS TP-4............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_4}");

            /*" -1960- DISPLAY '          TOTAL  REGISTROS TP-8............ ' W-QTD-LD-TIPO-8 */
            _.Display($"          TOTAL  REGISTROS TP-8............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_8}");

            /*" -1961- DISPLAY '          TOTAL  GERAL..................... ' W-TOT-GERADO-STA. */
            _.Display($"          TOTAL  GERAL..................... {WAREA_AUXILIAR.W_TOT_GERADO_STA}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0350-00-UPDATE-RELATORIOS-SECTION */
        private void R0350_00_UPDATE_RELATORIOS_SECTION()
        {
            /*" -1970- MOVE 'R0350-00-UPDATE-RELATORIOS' TO PARAGRAFO. */
            _.Move("R0350-00-UPDATE-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1972- MOVE 'UPDATE RELATORIOS' TO COMANDO. */
            _.Move("UPDATE RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1979- PERFORM R0350_00_UPDATE_RELATORIOS_DB_UPDATE_1 */

            R0350_00_UPDATE_RELATORIOS_DB_UPDATE_1();

            /*" -1982- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1983- DISPLAY 'PF0706B - FIM ANORMAL' */
                _.Display($"PF0706B - FIM ANORMAL");

                /*" -1984- DISPLAY '          ERRO UPDATE RELATORIOS' */
                _.Display($"          ERRO UPDATE RELATORIOS");

                /*" -1986- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -1987- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1987- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0350-00-UPDATE-RELATORIOS-DB-UPDATE-1 */
        public void R0350_00_UPDATE_RELATORIOS_DB_UPDATE_1()
        {
            /*" -1979- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_REFERENCIA = :DCLRELATORIOS.RELATORI-DATA-REFERENCIA, TIMESTAMP = CURRENT TIMESTAMP WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0706B' END-EXEC. */

            var r0350_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 = new R0350_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1()
            {
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
            };

            R0350_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1.Execute(r0350_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -1996- CLOSE MOVTO-STA-BILHETE. */
            MOVTO_STA_BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9998-00-MONITOR-SECTION */
        private void R9998_00_MONITOR_SECTION()
        {
            /*" -2003- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2003- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM M_1100_MOSTRA_TOTAIS */

            M_1100_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" M-1100-MOSTRA-TOTAIS */
        private void M_1100_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -2006- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -2007- IF SII < 17 */

            if (WS_HORAS.SII < 17)
            {

                /*" -2008- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_13[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -2010- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_13[WS_HORAS.SII]}"
                .Display();

                /*" -2011- GO TO M-1100-MOSTRA-TOTAIS. */
                new Task(() => M_1100_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2011- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9998_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -2023- DISPLAY ' ' */
            _.Display($" ");

            /*" -2024- IF W-FIM-MOVTO-BILH = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_BILH == "FIM")
            {

                /*" -2025- DISPLAY 'PF0706B - FIM NORMAL' */
                _.Display($"PF0706B - FIM NORMAL");

                /*" -2026- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2026- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -2028- ELSE */
            }
            else
            {


                /*" -2029- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_4.WSQLCODE);

                /*" -2030- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_4.WSQLERRD1);

                /*" -2031- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_4.WSQLERRD2);

                /*" -2032- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -2033- DISPLAY '*** PF0706B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0706B *** ROLLBACK EM ANDAMENTO ...");

                /*" -2034- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2034- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -2038- MOVE 99 TO RETURN-CODE. */
                _.Move(99, RETURN_CODE);
            }


            /*" -2038- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}