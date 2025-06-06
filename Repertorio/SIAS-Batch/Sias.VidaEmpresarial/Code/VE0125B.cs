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
using Sias.VidaEmpresarial.DB2.VE0125B;

namespace Code
{
    public class VE0125B
    {
        public bool IsCall { get; set; }

        public VE0125B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *=================================================================      */
        /*"      *                                                                       */
        /*"      * FUNCAO .....: SENSIBILIZACAO SIGPF DOS CERTIFICADOS EMPRESARIAL       */
        /*"      *               GLOBAL ANTECIPADOS QUE MIGRARAM P/MENSAL AFINS DE       */
        /*"      *               ALTERAR A PERIODICIDADE DE PAGAMENTO.                   */
        /*"      *                                                                       */
        /*"      *               O PROGRAMA GERA ARQUIVOS DE PROPOSTAS COM               */
        /*"      *               REGISTROS 1 E 3.                                        */
        /*"      *               CONTROLE DE EXECUCAO VIA TABELA RELATORIOS.             */
        /*"      *                                                                       */
        /*"      * DATA .......: 21/07/2014.                                             */
        /*"      * CADMUS .....: 100.458                                                 */
        /*"      *                                                                       */
        /*"      *=================================================================      */
        /*"      *   VERSAO 02 -  ADAILTON DIAS                                          */
        /*"      *               - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1    *      */
        /*"      *   EM 23/01/2019 - ATOS BR                                      *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      *=================================================================      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVTO_PRP_SASSE { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOVTO_PRP_SASSE
        {
            get
            {
                _.Move(REG_PRP_SASSE, _MOVTO_PRP_SASSE); VarBasis.RedefinePassValue(REG_PRP_SASSE, _MOVTO_PRP_SASSE, REG_PRP_SASSE); return _MOVTO_PRP_SASSE;
            }
        }
        /*"01   REG-PRP-SASSE              PIC X(300).*/
        public StringBasis REG_PRP_SASSE { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WHOST-DATA-REFERENCIA       PIC  X(10).*/
        public StringBasis WHOST_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-NUM-TERMO             PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis WHOST_NUM_TERMO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01  VIND-RCAP                   PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DTNASCI                PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_DTNASCI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-VAL-RCAP               PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_VAL_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DATA-RCAP              PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_DATA_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-AGE-COBRANCA           PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-AGECTADEB              PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-OPRCTADEB              PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-NUMCTADEB              PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DIGCTADEB              PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-FAIXA-RENDA-IND        PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-FAIXA-RENDA-FAM        PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-STA-ANTECIPACAO        PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_STA_ANTECIPACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-STA-MUDANCA            PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_STA_MUDANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  TAB-FILIAIS.*/
        public VE0125B_TAB_FILIAIS TAB_FILIAIS { get; set; } = new VE0125B_TAB_FILIAIS();
        public class VE0125B_TAB_FILIAIS : VarBasis
        {
            /*"    05  FILLER   OCCURS   9999  TIMES.*/
            public ListBasis<VE0125B_FILLER_0> FILLER_0 { get; set; } = new ListBasis<VE0125B_FILLER_0>(9999);
            public class VE0125B_FILLER_0 : VarBasis
            {
                /*"        15  TAB-AGENCIA         PIC  9(04).*/
                public IntBasis TAB_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"        15  TAB-FONTE           PIC  9(04).*/
                public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"01  W-FIM-MOVIMENTO             PIC  X(03)  VALUE SPACES.*/
            }
        }
        public StringBasis W_FIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"01  WFIM-AGENCEF                PIC  X(01)  VALUE ' '.*/
        public StringBasis WFIM_AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"01  WFIM-ENDERECOS              PIC  X(01)  VALUE ' '.*/
        public StringBasis WFIM_ENDERECOS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"01  W-TOT-PROCESSADO            PIC  9(06)  VALUE ZEROS.*/
        public IntBasis W_TOT_PROCESSADO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01  W-TIME                      PIC  X(08).*/
        public StringBasis W_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"01  W-TIME-EDIT                 PIC  99.99.99.99.*/
        public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
        /*"01  W-DESPREZADO                PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_DESPREZADO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-PROCESSADO                PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_PROCESSADO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-DATA-ULT-VE0125B          PIC  X(10).*/
        public StringBasis W_DATA_ULT_VE0125B { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  W-QTD-LD-TIPO-0             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-1             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-2             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-3             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-4             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-5             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-6             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-7             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-8             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-9             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-A             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-B             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-C             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_C { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-D             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_D { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-E             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_E { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-F             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_F { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-G             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_G { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-H             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_H { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-I             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_I { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-J             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_J { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-TOT-GERADO-PRP            PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_TOT_GERADO_PRP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-LIDOS                     PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-CONTROLE                  PIC 9(006).*/
        public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
        /*"01  W-DATA-TRABALHO             PIC 9(008)  VALUE ZEROS.*/
        public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"01  FILLER REDEFINES W-DATA-TRABALHO.*/
        private _REDEF_VE0125B_FILLER_1 _filler_1 { get; set; }
        public _REDEF_VE0125B_FILLER_1 FILLER_1
        {
            get { _filler_1 = new _REDEF_VE0125B_FILLER_1(); _.Move(W_DATA_TRABALHO, _filler_1); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_1, W_DATA_TRABALHO); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_DATA_TRABALHO); }; return _filler_1; }
            set { VarBasis.RedefinePassValue(value, _filler_1, W_DATA_TRABALHO); }
        }  //Redefines
        public class _REDEF_VE0125B_FILLER_1 : VarBasis
        {
            /*"    03  W-DIA-TRABALHO          PIC 9(002).*/
            public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    03  W-MES-TRABALHO          PIC 9(002).*/
            public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    03  W-ANO-TRABALHO          PIC 9(004).*/
            public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01  W-DTMOVABE                  PIC X(010).*/

            public _REDEF_VE0125B_FILLER_1()
            {
                W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                W_MES_TRABALHO.ValueChanged += OnValueChanged;
                W_ANO_TRABALHO.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
        private _REDEF_VE0125B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
        public _REDEF_VE0125B_W_DTMOVABE1 W_DTMOVABE1
        {
            get { _w_dtmovabe1 = new _REDEF_VE0125B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
            set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
        }  //Redefines
        public class _REDEF_VE0125B_W_DTMOVABE1 : VarBasis
        {
            /*"    03  W-ANO-MOVABE            PIC 9(004).*/
            public IntBasis W_ANO_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03  W-BARRA1                PIC X(001).*/
            public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  W-MES-MOVABE            PIC 9(002).*/
            public IntBasis W_MES_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    03  W-BARRA2                PIC X(001).*/
            public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  W-DIA-MOVABE            PIC 9(002).*/
            public IntBasis W_DIA_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  W-DTMOVABE-I                PIC X(010).*/

            public _REDEF_VE0125B_W_DTMOVABE1()
            {
                W_ANO_MOVABE.ValueChanged += OnValueChanged;
                W_BARRA1.ValueChanged += OnValueChanged;
                W_MES_MOVABE.ValueChanged += OnValueChanged;
                W_BARRA2.ValueChanged += OnValueChanged;
                W_DIA_MOVABE.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
        private _REDEF_VE0125B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
        public _REDEF_VE0125B_W_DTMOVABE_I1 W_DTMOVABE_I1
        {
            get { _w_dtmovabe_i1 = new _REDEF_VE0125B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
            set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
        }  //Redefines
        public class _REDEF_VE0125B_W_DTMOVABE_I1 : VarBasis
        {
            /*"    03  W-DIA-MOVABE            PIC 9(002).*/
            public IntBasis W_DIA_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    03  W-BARRA1                PIC X(001).*/
            public StringBasis W_BARRA1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  W-MES-MOVABE            PIC 9(002).*/
            public IntBasis W_MES_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    03  W-BARRA2                PIC X(001).*/
            public StringBasis W_BARRA2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  W-ANO-MOVABE            PIC 9(004).*/
            public IntBasis W_ANO_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01  W-DATA-SQL                  PIC X(010).*/

            public _REDEF_VE0125B_W_DTMOVABE_I1()
            {
                W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                W_BARRA1_0.ValueChanged += OnValueChanged;
                W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                W_BARRA2_0.ValueChanged += OnValueChanged;
                W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
        private _REDEF_VE0125B_W_DATA_SQL1 _w_data_sql1 { get; set; }
        public _REDEF_VE0125B_W_DATA_SQL1 W_DATA_SQL1
        {
            get { _w_data_sql1 = new _REDEF_VE0125B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
            set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
        }  //Redefines
        public class _REDEF_VE0125B_W_DATA_SQL1 : VarBasis
        {
            /*"    03  W-ANO-SQL               PIC 9(004).*/
            public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03  W-BARRA1                PIC X(001).*/
            public StringBasis W_BARRA1_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  W-MES-SQL               PIC 9(002).*/
            public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    03  W-BARRA2                PIC X(001).*/
            public StringBasis W_BARRA2_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  W-DIA-SQL               PIC 9(002).*/
            public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  W-NUM-PROPOSTA              PIC 9(014).*/

            public _REDEF_VE0125B_W_DATA_SQL1()
            {
                W_ANO_SQL.ValueChanged += OnValueChanged;
                W_BARRA1_1.ValueChanged += OnValueChanged;
                W_MES_SQL.ValueChanged += OnValueChanged;
                W_BARRA2_1.ValueChanged += OnValueChanged;
                W_DIA_SQL.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
        /*"01  CANAL  REDEFINES  W-NUM-PROPOSTA.*/
        private _REDEF_VE0125B_CANAL _canal { get; set; }
        public _REDEF_VE0125B_CANAL CANAL
        {
            get { _canal = new _REDEF_VE0125B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
            set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
        }  //Redefines
        public class _REDEF_VE0125B_CANAL : VarBasis
        {
            /*"    03  W-CANAL-PROPOSTA        PIC 9(001).*/

            public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL        VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF          VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL       VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR           VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO            VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-GITEL              VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET           VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7"),
							/*" 88 CANAL-INTRANET           VALUE 8. */
							new SelectorItemBasis("CANAL_INTRANET", "8")
                }
            };

            /*"    03  FILLER                  PIC X(013).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
            /*"01  W-RCAPS                     PIC 9(001) VALUE ZERO.*/

            public _REDEF_VE0125B_CANAL()
            {
                W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                FILLER_2.ValueChanged += OnValueChanged;
            }

        }

        public SelectorBasis W_RCAPS { get; set; } = new SelectorBasis("001", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-CADASTRADO                     VALUE 1. */
							new SelectorItemBasis("RCAP_CADASTRADO", "1"),
							/*" 88 RCAP-N-CADASTRADO                   VALUE 2. */
							new SelectorItemBasis("RCAP_N_CADASTRADO", "2")
                }
        };

        /*"01  W-RCAPCOMP                  PIC 9(001) VALUE ZERO.*/

        public SelectorBasis W_RCAPCOMP { get; set; } = new SelectorBasis("001", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 RCAPCOMP-CADASTRADO                 VALUE 1. */
							new SelectorItemBasis("RCAPCOMP_CADASTRADO", "1"),
							/*" 88 RCAPCOMP-N-CADASTRADO               VALUE 2. */
							new SelectorItemBasis("RCAPCOMP_N_CADASTRADO", "2")
                }
        };

        /*"01  W-CLIENTE                   PIC 9(001) VALUE ZERO.*/

        public SelectorBasis W_CLIENTE { get; set; } = new SelectorBasis("001", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 CLIENTE-CADASTRADO                  VALUE 1. */
							new SelectorItemBasis("CLIENTE_CADASTRADO", "1"),
							/*" 88 CLIENTE-NAO-CADASTRADO              VALUE 2. */
							new SelectorItemBasis("CLIENTE_NAO_CADASTRADO", "2")
                }
        };

        /*"01  W-PESJUR                    PIC 9(001) VALUE ZERO.*/

        public SelectorBasis W_PESJUR { get; set; } = new SelectorBasis("001", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 PESJUR-CADASTRADO                   VALUE 1. */
							new SelectorItemBasis("PESJUR_CADASTRADO", "1"),
							/*" 88 PESJUR-NAO-CADASTRADO               VALUE 2. */
							new SelectorItemBasis("PESJUR_NAO_CADASTRADO", "2")
                }
        };

        /*"01  W-PESEMAIL                  PIC 9(001) VALUE ZERO.*/

        public SelectorBasis W_PESEMAIL { get; set; } = new SelectorBasis("001", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 PESEMAIL-CADASTRADO                 VALUE 1. */
							new SelectorItemBasis("PESEMAIL_CADASTRADO", "1"),
							/*" 88 PESEMAIL-NAO-CADASTRADO             VALUE 2. */
							new SelectorItemBasis("PESEMAIL_NAO_CADASTRADO", "2")
                }
        };

        /*"01  W-ENDERECO                  PIC 9(001) VALUE ZERO.*/

        public SelectorBasis W_ENDERECO { get; set; } = new SelectorBasis("001", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 ENDERECO-CADASTRADO                 VALUE 1. */
							new SelectorItemBasis("ENDERECO_CADASTRADO", "1"),
							/*" 88 ENDERECO-NAO-CADASTRADO             VALUE 2. */
							new SelectorItemBasis("ENDERECO_NAO_CADASTRADO", "2")
                }
        };

        /*"01  W-SUBGRUPO                  PIC 9(001) VALUE ZERO.*/

        public SelectorBasis W_SUBGRUPO { get; set; } = new SelectorBasis("001", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 SUBGRUPO-CADASTRADO                 VALUE 1. */
							new SelectorItemBasis("SUBGRUPO_CADASTRADO", "1"),
							/*" 88 SUBGRUPO-NAO-CADASTRADO             VALUE 2. */
							new SelectorItemBasis("SUBGRUPO_NAO_CADASTRADO", "2")
                }
        };

        /*"01  W-COBERTURAS                PIC 9(001) VALUE ZERO.*/

        public SelectorBasis W_COBERTURAS { get; set; } = new SelectorBasis("001", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 COBERTURA-CADASTRADA                VALUE 1. */
							new SelectorItemBasis("COBERTURA_CADASTRADA", "1"),
							/*" 88 COBERTURA-NAO-CADASTRADA            VALUE 2. */
							new SelectorItemBasis("COBERTURA_NAO_CADASTRADA", "2")
                }
        };

        /*"01  W-OPCAOPAG                  PIC 9(001) VALUE ZERO.*/

        public SelectorBasis W_OPCAOPAG { get; set; } = new SelectorBasis("001", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 OPCAO-PAG-CADASTRADA                VALUE 1. */
							new SelectorItemBasis("OPCAO_PAG_CADASTRADA", "1"),
							/*" 88 OPCAO-PAG-NAO-CADASTRADA            VALUE 2. */
							new SelectorItemBasis("OPCAO_PAG_NAO_CADASTRADA", "2")
                }
        };

        /*"01  WABEND1.*/
        public VE0125B_WABEND1 WABEND1 { get; set; } = new VE0125B_WABEND1();
        public class VE0125B_WABEND1 : VarBasis
        {
            /*"    03  FILLER                  PIC X(010)    VALUE        'VE0125B  '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VE0125B  ");
            /*"    03  FILLER                  PIC X(028)    VALUE        ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"    03  FILLER                  PIC X(014)    VALUE        '    SQLCODE = '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    03  WSQLCODE                PIC ZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    03  FILLER                  PIC X(014)    VALUE        '   SQLERRD1 = '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"    03  WSQLERRD1               PIC ZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    03  FILLER                  PIC X(014)    VALUE        '   SQLERRD2 = '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    03  WSQLERRD2               PIC ZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"01  WABEND2.*/
        }
        public VE0125B_WABEND2 WABEND2 { get; set; } = new VE0125B_WABEND2();
        public class VE0125B_WABEND2 : VarBasis
        {
            /*"    03  FILLER                  PIC X(010)    VALUE SPACES.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03  FILLER                  PIC X(012)    VALUE        'PARAGRAFO = '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
            /*"    03  PARAGRAFO               PIC X(040)    VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"    03  FILLER                  PIC X(012)    VALUE        'COMANDO   = '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
            /*"    03  COMANDO                 PIC X(060)    VALUE SPACES.*/
            public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
        }


        public Copies.LBFPF990 LBFPF990 { get; set; } = new Copies.LBFPF990();
        public Copies.LBFPF011 LBFPF011 { get; set; } = new Copies.LBFPF011();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.LBFPF991 LBFPF991 { get; set; } = new Copies.LBFPF991();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.FDCOMVA FDCOMVA { get; set; } = new Dclgens.FDCOMVA();
        public Dclgens.TERMOADE TERMOADE { get; set; } = new Dclgens.TERMOADE();
        public Dclgens.VGCOMTRO VGCOMTRO { get; set; } = new Dclgens.VGCOMTRO();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.CLIENTE CLIENTE { get; set; } = new Dclgens.CLIENTE();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.PESJUR PESJUR { get; set; } = new Dclgens.PESJUR();
        public Dclgens.PESSOEMA PESSOEMA { get; set; } = new Dclgens.PESSOEMA();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VE0125B_CUR_MOVTO CUR_MOVTO { get; set; } = new VE0125B_CUR_MOVTO();
        public VE0125B_C01_RCAPCOMP C01_RCAPCOMP { get; set; } = new VE0125B_C01_RCAPCOMP();
        public VE0125B_C01_ENDERECO C01_ENDERECO { get; set; } = new VE0125B_C01_ENDERECO();
        public VE0125B_COBERTURAS COBERTURAS { get; set; } = new VE0125B_COBERTURAS();
        public VE0125B_FUNDOCOMISVA FUNDOCOMISVA { get; set; } = new VE0125B_FUNDOCOMISVA();
        public VE0125B_C01_AGENCEF C01_AGENCEF { get; set; } = new VE0125B_C01_AGENCEF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_PRP_SASSE_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO_PRP_SASSE.SetFile(MOVTO_PRP_SASSE_FILE_NAME_P);

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
            /*" -302- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -303- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -304- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -307- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -308- DISPLAY 'PROGRAMA EM EXECUCAO VE0125B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VE0125B  ");

            /*" -309- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -311- DISPLAY 'VERSAO V.01 NSGD    06/11/2014' */
            _.Display($"VERSAO V.01 NSGD    06/11/2014");

            /*" -313- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -321- DISPLAY 'VE0125B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"VE0125B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -323- DISPLAY ' ' . */
            _.Display($" ");

            /*" -324- PERFORM R0001-00-INICIALIZAR */

            R0001_00_INICIALIZAR_SECTION();

            /*" -325- PERFORM R0005-00-OBTER-DATA-DIA */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -326- PERFORM R0010-00-BUSCA-ULT-VE0125B */

            R0010_00_BUSCA_ULT_VE0125B_SECTION();

            /*" -328- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -330- PERFORM R0070-00-LER-MOVTO. */

            R0070_00_LER_MOVTO_SECTION();

            /*" -331- IF W-FIM-MOVIMENTO EQUAL 'FIM' */

            if (W_FIM_MOVIMENTO == "FIM")
            {

                /*" -332- DISPLAY 'VE0125B - NAO HOUVE MOVIMENTO' */
                _.Display($"VE0125B - NAO HOUVE MOVIMENTO");

                /*" -333- ELSE */
            }
            else
            {


                /*" -334- OPEN OUTPUT MOVTO-PRP-SASSE */
                MOVTO_PRP_SASSE.Open(REG_PRP_SASSE);

                /*" -335- INITIALIZE REG-TRAILLER */
                _.Initialize(
                    LBFPF991.REG_TRAILLER
                );

                /*" -336- MOVE ZEROS TO RT-QTDE-TOTAL OF REG-TRAILLER */
                _.Move(0, LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL);

                /*" -338- PERFORM R0080-00-GERAR-HEADER */

                R0080_00_GERAR_HEADER_SECTION();

                /*" -341- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVIMENTO EQUAL 'FIM' */

                while (!(W_FIM_MOVIMENTO == "FIM"))
                {

                    R0150_00_PROCESSAR_MOVIMENTO_SECTION();
                }

                /*" -342- PERFORM R1000-00-GERAR-TRAILLER */

                R1000_00_GERAR_TRAILLER_SECTION();

                /*" -343- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -345- END-IF. */
            }


            /*" -346- PERFORM R1100-00-GERAR-TOTAIS. */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -347- PERFORM R1200-00-GRAVA-RELATORIO. */

            R1200_00_GRAVA_RELATORIO_SECTION();

            /*" -347- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0001-00-INICIALIZAR-SECTION */
        private void R0001_00_INICIALIZAR_SECTION()
        {
            /*" -357- MOVE ZEROS TO TAB-FILIAIS. */
            _.Move(0, TAB_FILIAIS);

            /*" -358- PERFORM R6000-00-DECLARE-AGENCEF. */

            R6000_00_DECLARE_AGENCEF_SECTION();

            /*" -360- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

            /*" -361- PERFORM R6020-00-CARREGA-FILIAL UNTIL WFIM-AGENCEF EQUAL 'S' . */

            while (!(WFIM_AGENCEF == "S"))
            {

                R6020_00_CARREGA_FILIAL_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_SAIDA*/

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -371- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND2.PARAGRAFO);

            /*" -373- MOVE 'SELECT SISTEMAS' TO COMANDO. */
            _.Move("SELECT SISTEMAS", WABEND2.COMANDO);

            /*" -375- MOVE 'VE' TO SISTEMAS-IDE-SISTEMA */
            _.Move("VE", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -383- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -386- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -387- DISPLAY 'VE0125B - ERRO SELECT SISTEMAS' */
                _.Display($"VE0125B - ERRO SELECT SISTEMAS");

                /*" -388- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -390- END-IF. */
            }


            /*" -393- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W_DTMOVABE);

            /*" -396- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(W_DTMOVABE1.W_DIA_MOVABE, W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -399- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(W_DTMOVABE1.W_MES_MOVABE, W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -402- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(W_DTMOVABE1.W_ANO_MOVABE, W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -404- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1 W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -383- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO ,:WHOST-DATA-REFERENCIA FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 = new R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1.Execute(r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA_REFERENCIA, WHOST_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_SAIDA*/

        [StopWatch]
        /*" R0010-00-BUSCA-ULT-VE0125B-SECTION */
        private void R0010_00_BUSCA_ULT_VE0125B_SECTION()
        {
            /*" -414- MOVE 'R0010-00-BUSCA-ULT-VE0125B' TO PARAGRAFO. */
            _.Move("R0010-00-BUSCA-ULT-VE0125B", WABEND2.PARAGRAFO);

            /*" -416- MOVE 'SELECT RELATORIO' TO COMANDO. */
            _.Move("SELECT RELATORIO", WABEND2.COMANDO);

            /*" -417- MOVE 'VE0125B' TO RELATORI-COD-USUARIO */
            _.Move("VE0125B", RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);

            /*" -419- MOVE 'VE' TO RELATORI-IDE-SISTEMA */
            _.Move("VE", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -426- PERFORM R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1 */

            R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1();

            /*" -429- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -431- MOVE RELATORI-DATA-SOLICITACAO TO W-DATA-ULT-VE0125B */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO, W_DATA_ULT_VE0125B);

                /*" -432- ELSE */
            }
            else
            {


                /*" -433- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -435- MOVE '0001-01-01' TO W-DATA-ULT-VE0125B */
                    _.Move("0001-01-01", W_DATA_ULT_VE0125B);

                    /*" -436- ELSE */
                }
                else
                {


                    /*" -437- DISPLAY 'VE0125B - ERRO SELECT RELATORIOS' */
                    _.Display($"VE0125B - ERRO SELECT RELATORIOS");

                    /*" -439- DISPLAY '          COD-USUARIO = ' RELATORI-COD-USUARIO */
                    _.Display($"          COD-USUARIO = {RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO}");

                    /*" -440- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -441- END-IF */
                }


                /*" -441- END-IF. */
            }


        }

        [StopWatch]
        /*" R0010-00-BUSCA-ULT-VE0125B-DB-SELECT-1 */
        public void R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1()
        {
            /*" -426- EXEC SQL SELECT DATA_SOLICITACAO INTO :RELATORI-DATA-SOLICITACAO FROM SEGUROS.RELATORIOS WHERE COD_USUARIO = :RELATORI-COD-USUARIO AND IDE_SISTEMA = :RELATORI-IDE-SISTEMA WITH UR END-EXEC. */

            var r0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1 = new R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1.Execute(r0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-SECTION */
        private void R0050_00_SELECIONA_MOVTO_SECTION()
        {
            /*" -450- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND2.PARAGRAFO);

            /*" -455- MOVE 'DECLARE CUR-MOVTO' TO COMANDO. */
            _.Move("DECLARE CUR-MOVTO", WABEND2.COMANDO);

            /*" -456- MOVE 'VE0123B' TO RELATORI-COD-USUARIO */
            _.Move("VE0123B", RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);

            /*" -457- MOVE 'VE' TO RELATORI-IDE-SISTEMA */
            _.Move("VE", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -459- MOVE 'VLNXA' TO RELATORI-COD-RELATORIO. */
            _.Move("VLNXA", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -509- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -512- MOVE 'OPEN CUR-MOVTO' TO COMANDO. */
            _.Move("OPEN CUR-MOVTO", WABEND2.COMANDO);

            /*" -512- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -515- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -516- DISPLAY 'VE0125B - ERRO OPEN CURSOR CUR-MOVTO' */
                _.Display($"VE0125B - ERRO OPEN CURSOR CUR-MOVTO");

                /*" -517- MOVE 'OPEN CUR-MOVTO' TO COMANDO */
                _.Move("OPEN CUR-MOVTO", WABEND2.COMANDO);

                /*" -518- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -518- END-IF. */
            }


        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -509- EXEC SQL DECLARE CUR-MOVTO CURSOR FOR SELECT COD_USUARIO ,DATA_SOLICITACAO ,IDE_SISTEMA ,COD_RELATORIO ,NUM_COPIAS ,QUANTIDADE ,PERI_INICIAL ,PERI_FINAL ,DATA_REFERENCIA ,MES_REFERENCIA ,ANO_REFERENCIA ,ORGAO_EMISSOR ,COD_FONTE ,COD_PRODUTOR ,RAMO_EMISSOR ,COD_MODALIDADE ,COD_CONGENERE ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,NUM_CERTIFICADO ,NUM_TITULO ,COD_SUBGRUPO ,COD_OPERACAO ,COD_PLANO ,OCORR_HISTORICO ,NUM_APOL_LIDER ,ENDOS_LIDER ,NUM_PARC_LIDER ,NUM_SINISTRO ,NUM_SINI_LIDER ,NUM_ORDEM ,COD_MOEDA ,TIPO_CORRECAO ,SIT_REGISTRO ,IND_PREV_DEFINIT ,IND_ANAL_RESUMO ,COD_EMPRESA ,PERI_RENOVACAO ,PCT_AUMENTO ,TIMESTAMP FROM SEGUROS.RELATORIOS WHERE COD_USUARIO = :RELATORI-COD-USUARIO AND IDE_SISTEMA = :RELATORI-IDE-SISTEMA AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND DATA_SOLICITACAO BETWEEN :W-DATA-ULT-VE0125B AND :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC. */
            CUR_MOVTO = new VE0125B_CUR_MOVTO(true);
            string GetQuery_CUR_MOVTO()
            {
                var query = @$"SELECT COD_USUARIO 
							,DATA_SOLICITACAO 
							,IDE_SISTEMA 
							,COD_RELATORIO 
							,NUM_COPIAS 
							,QUANTIDADE 
							,PERI_INICIAL 
							,PERI_FINAL 
							,DATA_REFERENCIA 
							,MES_REFERENCIA 
							,ANO_REFERENCIA 
							,ORGAO_EMISSOR 
							,COD_FONTE 
							,COD_PRODUTOR 
							,RAMO_EMISSOR 
							,COD_MODALIDADE 
							,COD_CONGENERE 
							,NUM_APOLICE 
							,NUM_ENDOSSO 
							,NUM_PARCELA 
							,NUM_CERTIFICADO 
							,NUM_TITULO 
							,COD_SUBGRUPO 
							,COD_OPERACAO 
							,COD_PLANO 
							,OCORR_HISTORICO 
							,NUM_APOL_LIDER 
							,ENDOS_LIDER 
							,NUM_PARC_LIDER 
							,NUM_SINISTRO 
							,NUM_SINI_LIDER 
							,NUM_ORDEM 
							,COD_MOEDA 
							,TIPO_CORRECAO 
							,SIT_REGISTRO 
							,IND_PREV_DEFINIT 
							,IND_ANAL_RESUMO 
							,COD_EMPRESA 
							,PERI_RENOVACAO 
							,PCT_AUMENTO 
							,TIMESTAMP 
							FROM SEGUROS.RELATORIOS 
							WHERE COD_USUARIO = '{RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO}' 
							AND IDE_SISTEMA = '{RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA}' 
							AND COD_RELATORIO = '{RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}' 
							AND DATA_SOLICITACAO 
							BETWEEN '{W_DATA_ULT_VE0125B}' 
							AND '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}'";

                return query;
            }
            CUR_MOVTO.GetQueryEvent += GetQuery_CUR_MOVTO;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -512- EXEC SQL OPEN CUR-MOVTO END-EXEC. */

            CUR_MOVTO.Open();

        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-DB-DECLARE-1 */
        public void R0205_00_LER_RCAPCOMP_DB_DECLARE_1()
        {
            /*" -1111- EXEC SQL DECLARE C01_RCAPCOMP CURSOR FOR SELECT BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , DATA_MOVIMENTO , DATA_RCAP , COD_OPERACAO FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :RCAPS-COD-FONTE AND NUM_RCAP = :RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 ORDER BY COD_OPERACAO DESC WITH UR END-EXEC. */
            C01_RCAPCOMP = new VE0125B_C01_RCAPCOMP(true);
            string GetQuery_C01_RCAPCOMP()
            {
                var query = @$"SELECT BCO_AVISO 
							, AGE_AVISO 
							, NUM_AVISO_CREDITO 
							, DATA_MOVIMENTO 
							, DATA_RCAP 
							, COD_OPERACAO 
							FROM SEGUROS.RCAP_COMPLEMENTAR 
							WHERE COD_FONTE = '{RCAPS.DCLRCAPS.RCAPS_COD_FONTE}' 
							AND NUM_RCAP = '{RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}' 
							AND NUM_RCAP_COMPLEMEN = 0 
							ORDER BY COD_OPERACAO DESC";

                return query;
            }
            C01_RCAPCOMP.GetQueryEvent += GetQuery_C01_RCAPCOMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -527- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND2.PARAGRAFO);

            /*" -529- MOVE 'FETCH CUR-MOVTO   ' TO COMANDO. */
            _.Move("FETCH CUR-MOVTO   ", WABEND2.COMANDO);

            /*" -573- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -576- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -577- ADD 1 TO W-LIDOS W-CONTROLE */
                W_LIDOS.Value = W_LIDOS + 1;
                W_CONTROLE.Value = W_CONTROLE + 1;

                /*" -578- ELSE */
            }
            else
            {


                /*" -579- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -580- MOVE 'FIM' TO W-FIM-MOVIMENTO */
                    _.Move("FIM", W_FIM_MOVIMENTO);

                    /*" -580- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -582- ELSE */
                }
                else
                {


                    /*" -583- DISPLAY 'VE0125B - ERRO FETCH CURSOR CUR-MOVTO' */
                    _.Display($"VE0125B - ERRO FETCH CURSOR CUR-MOVTO");

                    /*" -584- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -585- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -586- END-IF */
                }


                /*" -588- END-IF. */
            }


            /*" -589- IF W-CONTROLE > 999 */

            if (W_CONTROLE > 999)
            {

                /*" -590- ACCEPT W-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W_TIME);

                /*" -591- MOVE W-TIME TO W-TIME-EDIT */
                _.Move(W_TIME, W_TIME_EDIT);

                /*" -592- MOVE ZEROS TO W-CONTROLE */
                _.Move(0, W_CONTROLE);

                /*" -594- DISPLAY 'VE0125B - REGISTROS LIDOS = ' W-LIDOS ' ' W-TIME-EDIT */

                $"VE0125B - REGISTROS LIDOS = {W_LIDOS} {W_TIME_EDIT}"
                .Display();

                /*" -594- END-IF. */
            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -573- EXEC SQL FETCH CUR-MOVTO INTO :RELATORI-COD-USUARIO ,:RELATORI-DATA-SOLICITACAO ,:RELATORI-IDE-SISTEMA ,:RELATORI-COD-RELATORIO ,:RELATORI-NUM-COPIAS ,:RELATORI-QUANTIDADE ,:RELATORI-PERI-INICIAL ,:RELATORI-PERI-FINAL ,:RELATORI-DATA-REFERENCIA ,:RELATORI-MES-REFERENCIA ,:RELATORI-ANO-REFERENCIA ,:RELATORI-ORGAO-EMISSOR ,:RELATORI-COD-FONTE ,:RELATORI-COD-PRODUTOR ,:RELATORI-RAMO-EMISSOR ,:RELATORI-COD-MODALIDADE ,:RELATORI-COD-CONGENERE ,:RELATORI-NUM-APOLICE ,:RELATORI-NUM-ENDOSSO ,:RELATORI-NUM-PARCELA ,:RELATORI-NUM-CERTIFICADO ,:RELATORI-NUM-TITULO ,:RELATORI-COD-SUBGRUPO ,:RELATORI-COD-OPERACAO ,:RELATORI-COD-PLANO ,:RELATORI-OCORR-HISTORICO ,:RELATORI-NUM-APOL-LIDER ,:RELATORI-ENDOS-LIDER ,:RELATORI-NUM-PARC-LIDER ,:RELATORI-NUM-SINISTRO ,:RELATORI-NUM-SINI-LIDER ,:RELATORI-NUM-ORDEM ,:RELATORI-COD-MOEDA ,:RELATORI-TIPO-CORRECAO ,:RELATORI-SIT-REGISTRO ,:RELATORI-IND-PREV-DEFINIT ,:RELATORI-IND-ANAL-RESUMO ,:RELATORI-COD-EMPRESA ,:RELATORI-PERI-RENOVACAO ,:RELATORI-PCT-AUMENTO ,:RELATORI-TIMESTAMP END-EXEC. */

            if (CUR_MOVTO.Fetch())
            {
                _.Move(CUR_MOVTO.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(CUR_MOVTO.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(CUR_MOVTO.RELATORI_IDE_SISTEMA, RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);
                _.Move(CUR_MOVTO.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
                _.Move(CUR_MOVTO.RELATORI_NUM_COPIAS, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
                _.Move(CUR_MOVTO.RELATORI_QUANTIDADE, RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE);
                _.Move(CUR_MOVTO.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
                _.Move(CUR_MOVTO.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
                _.Move(CUR_MOVTO.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
                _.Move(CUR_MOVTO.RELATORI_MES_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA);
                _.Move(CUR_MOVTO.RELATORI_ANO_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA);
                _.Move(CUR_MOVTO.RELATORI_ORGAO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR);
                _.Move(CUR_MOVTO.RELATORI_COD_FONTE, RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE);
                _.Move(CUR_MOVTO.RELATORI_COD_PRODUTOR, RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR);
                _.Move(CUR_MOVTO.RELATORI_RAMO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);
                _.Move(CUR_MOVTO.RELATORI_COD_MODALIDADE, RELATORI.DCLRELATORIOS.RELATORI_COD_MODALIDADE);
                _.Move(CUR_MOVTO.RELATORI_COD_CONGENERE, RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE);
                _.Move(CUR_MOVTO.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(CUR_MOVTO.RELATORI_NUM_ENDOSSO, RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO);
                _.Move(CUR_MOVTO.RELATORI_NUM_PARCELA, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);
                _.Move(CUR_MOVTO.RELATORI_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);
                _.Move(CUR_MOVTO.RELATORI_NUM_TITULO, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);
                _.Move(CUR_MOVTO.RELATORI_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);
                _.Move(CUR_MOVTO.RELATORI_COD_OPERACAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);
                _.Move(CUR_MOVTO.RELATORI_COD_PLANO, RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO);
                _.Move(CUR_MOVTO.RELATORI_OCORR_HISTORICO, RELATORI.DCLRELATORIOS.RELATORI_OCORR_HISTORICO);
                _.Move(CUR_MOVTO.RELATORI_NUM_APOL_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER);
                _.Move(CUR_MOVTO.RELATORI_ENDOS_LIDER, RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER);
                _.Move(CUR_MOVTO.RELATORI_NUM_PARC_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARC_LIDER);
                _.Move(CUR_MOVTO.RELATORI_NUM_SINISTRO, RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO);
                _.Move(CUR_MOVTO.RELATORI_NUM_SINI_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER);
                _.Move(CUR_MOVTO.RELATORI_NUM_ORDEM, RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM);
                _.Move(CUR_MOVTO.RELATORI_COD_MOEDA, RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA);
                _.Move(CUR_MOVTO.RELATORI_TIPO_CORRECAO, RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO);
                _.Move(CUR_MOVTO.RELATORI_SIT_REGISTRO, RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);
                _.Move(CUR_MOVTO.RELATORI_IND_PREV_DEFINIT, RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);
                _.Move(CUR_MOVTO.RELATORI_IND_ANAL_RESUMO, RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);
                _.Move(CUR_MOVTO.RELATORI_COD_EMPRESA, RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA);
                _.Move(CUR_MOVTO.RELATORI_PERI_RENOVACAO, RELATORI.DCLRELATORIOS.RELATORI_PERI_RENOVACAO);
                _.Move(CUR_MOVTO.RELATORI_PCT_AUMENTO, RELATORI.DCLRELATORIOS.RELATORI_PCT_AUMENTO);
                _.Move(CUR_MOVTO.RELATORI_TIMESTAMP, RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -580- EXEC SQL CLOSE CUR-MOVTO END-EXEC */

            CUR_MOVTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -603- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND2.PARAGRAFO);

            /*" -607- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND2.COMANDO);

            /*" -610- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER */
            _.Move("H", LBFPF990.REG_HEADER.RH_TIPO_REG);

            /*" -613- MOVE 'PRPSASSE' TO RH-NOME OF REG-HEADER */
            _.Move("PRPSASSE", LBFPF990.REG_HEADER.RH_NOME);

            /*" -616- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO. */
            _.Move(W_DTMOVABE1.W_DIA_MOVABE, FILLER_1.W_DIA_TRABALHO);

            /*" -619- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO. */
            _.Move(W_DTMOVABE1.W_MES_MOVABE, FILLER_1.W_MES_TRABALHO);

            /*" -622- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO. */
            _.Move(W_DTMOVABE1.W_ANO_MOVABE, FILLER_1.W_ANO_TRABALHO);

            /*" -625- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER. */
            _.Move(W_DATA_TRABALHO, LBFPF990.REG_HEADER.RH_DATA_GERACAO);

            /*" -628- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER. */
            _.Move(4, LBFPF990.REG_HEADER.RH_SIST_ORIGEM);

            /*" -631- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER. */
            _.Move(1, LBFPF990.REG_HEADER.RH_SIST_DESTINO);

            /*" -634- MOVE 000001 TO RH-NSAS OF REG-HEADER. */
            _.Move(000001, LBFPF990.REG_HEADER.RH_NSAS);

            /*" -637- MOVE 1 TO RH-TIPO-ARQUIVO OF REG-HEADER. */
            _.Move(1, LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO);

            /*" -637- WRITE REG-PRP-SASSE FROM REG-HEADER. */
            _.Move(LBFPF990.REG_HEADER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -646- MOVE 'R0150-00-PROCESSAR-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSAR-MOVIMENTO", WABEND2.PARAGRAFO);

            /*" -648- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND2.COMANDO);

            /*" -650- MOVE 'N' TO WFIM-ENDERECOS. */
            _.Move("N", WFIM_ENDERECOS);

            /*" -655- PERFORM R0170-00-LER-CERTIFICADO */

            R0170_00_LER_CERTIFICADO_SECTION();

            /*" -657- IF PROPOVA-COD-PRODUTO NOT EQUAL 9329 AND 8205 AND JVPRD9329 AND JVPRD8205 */

            if (!PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9329", "8205", JVBKINCL.JV_PRODUTOS.JVPRD9329.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8205.ToString()))
            {

                /*" -658- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -660- DISPLAY 'VE0125B - CERTIFICADO NAO EH MENSAL = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"VE0125B - CERTIFICADO NAO EH MENSAL = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -662- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -663- IF PROPOVA-SIT-REGISTRO NOT EQUAL '3' AND '6' */

            if (!PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.In("3", "6"))
            {

                /*" -666- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -668- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -670- PERFORM R0590-00-LER-COMPL-TERMO */

            R0590_00_LER_COMPL_TERMO_SECTION();

            /*" -672- PERFORM R0200-00-LER-RCAPS */

            R0200_00_LER_RCAPS_SECTION();

            /*" -673- IF RCAP-N-CADASTRADO */

            if (W_RCAPS["RCAP_N_CADASTRADO"])
            {

                /*" -674- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -676- DISPLAY 'VE0125B - CERTIFICADO SEM RCAP = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"VE0125B - CERTIFICADO SEM RCAP = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -678- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -679- IF VIND-AGE-COBRANCA LESS ZERO */

            if (VIND_AGE_COBRANCA < 00)
            {

                /*" -681- MOVE ZEROS TO RCAPS-AGE-COBRANCA. */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
            }


            /*" -683- PERFORM R0205-00-LER-RCAPCOMP. */

            R0205_00_LER_RCAPCOMP_SECTION();

            /*" -684- IF RCAPCOMP-N-CADASTRADO */

            if (W_RCAPCOMP["RCAPCOMP_N_CADASTRADO"])
            {

                /*" -685- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -686- DISPLAY 'VE0125B - RCAP SEM RCAPCOMP' */
                _.Display($"VE0125B - RCAP SEM RCAPCOMP");

                /*" -688- DISPLAY '          COD. FONTE  = ' RCAPS-COD-FONTE */
                _.Display($"          COD. FONTE  = {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                /*" -690- DISPLAY '          NUM RCAP    = ' RCAPS-NUM-RCAP */
                _.Display($"          NUM RCAP    = {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                /*" -692- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -694- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -696- PERFORM R0300-00-LER-CLIENTE */

            R0300_00_LER_CLIENTE_SECTION();

            /*" -697- IF CLIENTE-NAO-CADASTRADO */

            if (W_CLIENTE["CLIENTE_NAO_CADASTRADO"])
            {

                /*" -698- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -699- DISPLAY 'VE0125B - CLIENTE NAO CADASTRADO' */
                _.Display($"VE0125B - CLIENTE NAO CADASTRADO");

                /*" -701- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -703- DISPLAY '          CLIENTE     = ' TERMOADE-COD-CLIENTE */
                _.Display($"          CLIENTE     = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}");

                /*" -705- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -706- IF CGCCPF OF DCLCLIENTES EQUAL ZEROS */

            if (CLIENTE.DCLCLIENTES.CGCCPF == 00)
            {

                /*" -707- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -708- DISPLAY 'VE0125B - CLIENTE SEM CNPJ' */
                _.Display($"VE0125B - CLIENTE SEM CNPJ");

                /*" -710- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -712- DISPLAY '          CLIENTE     = ' TERMOADE-COD-CLIENTE */
                _.Display($"          CLIENTE     = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}");

                /*" -714- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -715- PERFORM R0310-00-LER-PESSOA-JURIDICA */

            R0310_00_LER_PESSOA_JURIDICA_SECTION();

            /*" -716- IF PESJUR-CADASTRADO */

            if (W_PESJUR["PESJUR_CADASTRADO"])
            {

                /*" -717- PERFORM R0320-00-LER-PESSOA-EMAIL */

                R0320_00_LER_PESSOA_EMAIL_SECTION();

                /*" -718- ELSE */
            }
            else
            {


                /*" -719- MOVE 2 TO W-PESEMAIL */
                _.Move(2, W_PESEMAIL);

                /*" -722- END-IF. */
            }


            /*" -723- PERFORM R0350-00-DECLARE-ENDERECO. */

            R0350_00_DECLARE_ENDERECO_SECTION();

            /*" -725- PERFORM R0370-00-LER-ENDERECO. */

            R0370_00_LER_ENDERECO_SECTION();

            /*" -726- IF ENDERECO-NAO-CADASTRADO */

            if (W_ENDERECO["ENDERECO_NAO_CADASTRADO"])
            {

                /*" -727- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -728- DISPLAY 'VE0125B - ENDERECO NAO CADASTRADO ' */
                _.Display($"VE0125B - ENDERECO NAO CADASTRADO ");

                /*" -730- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -732- DISPLAY '          CLIENTE     = ' TERMOADE-COD-CLIENTE */
                _.Display($"          CLIENTE     = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}");

                /*" -734- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -736- PERFORM R0400-00-LER-SUBGRUPO. */

            R0400_00_LER_SUBGRUPO_SECTION();

            /*" -737- IF SUBGRUPO-NAO-CADASTRADO */

            if (W_SUBGRUPO["SUBGRUPO_NAO_CADASTRADO"])
            {

                /*" -738- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -739- DISPLAY 'VE0125B - SUBGRUPO NAO CADASTRADO ' */
                _.Display($"VE0125B - SUBGRUPO NAO CADASTRADO ");

                /*" -741- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -743- DISPLAY '          APOLICE     = ' TERMOADE-NUM-APOLICE */
                _.Display($"          APOLICE     = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE}");

                /*" -745- DISPLAY '          SUBGRUPO    = ' TERMOADE-COD-SUBGRUPO */
                _.Display($"          SUBGRUPO    = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO}");

                /*" -747- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -749- PERFORM R0450-00-OBTER-COBERTURA. */

            R0450_00_OBTER_COBERTURA_SECTION();

            /*" -750- IF COBERTURA-NAO-CADASTRADA */

            if (W_COBERTURAS["COBERTURA_NAO_CADASTRADA"])
            {

                /*" -751- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -752- DISPLAY 'VE0125B - COBERTURA NAO CADASTRADA ' */
                _.Display($"VE0125B - COBERTURA NAO CADASTRADA ");

                /*" -754- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -756- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -758- PERFORM R0500-00-OBTER-OPCAOPAG. */

            R0500_00_OBTER_OPCAOPAG_SECTION();

            /*" -759- IF OPCAO-PAG-NAO-CADASTRADA */

            if (W_OPCAOPAG["OPCAO_PAG_NAO_CADASTRADA"])
            {

                /*" -760- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -761- DISPLAY 'VE0125B - OPCAOPAG NAO CADASTRADA' */
                _.Display($"VE0125B - OPCAOPAG NAO CADASTRADA");

                /*" -763- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -765- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -766- PERFORM R0570-00-LER-COMISSAO */

            R0570_00_LER_COMISSAO_SECTION();

            /*" -770- PERFORM R0580-00-OBTER-VAL-TARIFA. */

            R0580_00_OBTER_VAL_TARIFA_SECTION();

            /*" -771- PERFORM R0600-00-PROPOSTA-REGISTRO-TP1 */

            R0600_00_PROPOSTA_REGISTRO_TP1_SECTION();

            /*" -771- PERFORM R0700-00-PROPOSTA-REGISTRO-TP3. */

            R0700_00_PROPOSTA_REGISTRO_TP3_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0150_LEITURA */

            R0150_LEITURA();

        }

        [StopWatch]
        /*" R0150-LEITURA */
        private void R0150_LEITURA(bool isPerform = false)
        {
            /*" -775- PERFORM R0070-00-LER-MOVTO. */

            R0070_00_LER_MOVTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0170-00-LER-CERTIFICADO-SECTION */
        private void R0170_00_LER_CERTIFICADO_SECTION()
        {
            /*" -785- MOVE 'R0170-00-LER-CERTIFICADO' TO PARAGRAFO. */
            _.Move("R0170-00-LER-CERTIFICADO", WABEND2.PARAGRAFO);

            /*" -787- MOVE 'SELECT TERMO' TO COMANDO. */
            _.Move("SELECT TERMO", WABEND2.COMANDO);

            /*" -897- PERFORM R0170_00_LER_CERTIFICADO_DB_SELECT_1 */

            R0170_00_LER_CERTIFICADO_DB_SELECT_1();

            /*" -900- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -901- DISPLAY 'VE0125B - CERTIFICADO SEM TERMO ADESAO' */
                _.Display($"VE0125B - CERTIFICADO SEM TERMO ADESAO");

                /*" -903- DISPLAY '          CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -904- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -905- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -907- END-IF. */
            }


            /*" -909- MOVE 'SELECT PROPOSTA' TO COMANDO. */
            _.Move("SELECT PROPOSTA", WABEND2.COMANDO);

            /*" -926- PERFORM R0170_00_LER_CERTIFICADO_DB_SELECT_2 */

            R0170_00_LER_CERTIFICADO_DB_SELECT_2();

            /*" -929- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -930- DISPLAY 'VE0125B - CERTIFICADO SEM PROPOSTA_VA' */
                _.Display($"VE0125B - CERTIFICADO SEM PROPOSTA_VA");

                /*" -932- DISPLAY '          CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -933- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -934- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -934- END-IF. */
            }


        }

        [StopWatch]
        /*" R0170-00-LER-CERTIFICADO-DB-SELECT-1 */
        public void R0170_00_LER_CERTIFICADO_DB_SELECT_1()
        {
            /*" -897- EXEC SQL SELECT NUM_TERMO , COD_SUBGRUPO , DATA_ADESAO , COD_AGENCIA_OP , NUM_MATRICULA_VEN , CODPDTVEN , PCCOMVEN , PCADIANTVEN , COD_AGENCIA_VEN , OPERACAO_CONTA_VEN , NUM_CONTA_VEN , DIG_CONTA_VEN , NUM_MATRICULA_GER , CODPDTGER , PCCOMGER , COD_AGENCIA_GER , OPERACAO_CONTA_GER , NUM_CONTA_GER , DIG_CONTA_GER , NUM_MATRICULA_SUR , CODPDTSUR , PCCOMSUR , NUM_MATRICULA_GCO , CODPDTGCO , PCCOMGCO , MODALIDADE_CAPITAL , TIPO_PLANO , IND_PLANO_ASSOCIAD , COD_PLANO_VGAPC , COD_PLANO_APC , VAL_CONTRATADO , VAL_COMISSAO_ADIAN , QUANT_VIDAS , TIPO_COBERTURA , PERI_PAGAMENTO , TIPO_CORRECAO , PERIODO_CORRECAO , COD_MOEDA_IMP , COD_MOEDA_PRM , COD_CLIENTE , OCORR_ENDERECO , COD_CORRETOR , PCCOMCOR , COD_ADMINISTRADOR , PCCOMADM , COD_USUARIO , DATA_INCLUSAO , SITUACAO , NUM_PROPOSTA , NUM_RCAP , DATA_RCAP , VAL_RCAP , NUM_APOLICE INTO :TERMOADE-NUM-TERMO ,:TERMOADE-COD-SUBGRUPO ,:TERMOADE-DATA-ADESAO ,:TERMOADE-COD-AGENCIA-OP ,:TERMOADE-NUM-MATRICULA-VEN ,:TERMOADE-CODPDTVEN ,:TERMOADE-PCCOMVEN ,:TERMOADE-PCADIANTVEN ,:TERMOADE-COD-AGENCIA-VEN ,:TERMOADE-OPERACAO-CONTA-VEN ,:TERMOADE-NUM-CONTA-VEN ,:TERMOADE-DIG-CONTA-VEN ,:TERMOADE-NUM-MATRICULA-GER ,:TERMOADE-CODPDTGER ,:TERMOADE-PCCOMGER ,:TERMOADE-COD-AGENCIA-GER ,:TERMOADE-OPERACAO-CONTA-GER ,:TERMOADE-NUM-CONTA-GER ,:TERMOADE-DIG-CONTA-GER ,:TERMOADE-NUM-MATRICULA-SUR ,:TERMOADE-CODPDTSUR ,:TERMOADE-PCCOMSUR ,:TERMOADE-NUM-MATRICULA-GCO ,:TERMOADE-CODPDTGCO ,:TERMOADE-PCCOMGCO ,:TERMOADE-MODALIDADE-CAPITAL ,:TERMOADE-TIPO-PLANO ,:TERMOADE-IND-PLANO-ASSOCIAD ,:TERMOADE-COD-PLANO-VGAPC ,:TERMOADE-COD-PLANO-APC ,:TERMOADE-VAL-CONTRATADO ,:TERMOADE-VAL-COMISSAO-ADIAN ,:TERMOADE-QUANT-VIDAS ,:TERMOADE-TIPO-COBERTURA ,:TERMOADE-PERI-PAGAMENTO ,:TERMOADE-TIPO-CORRECAO ,:TERMOADE-PERIODO-CORRECAO ,:TERMOADE-COD-MOEDA-IMP ,:TERMOADE-COD-MOEDA-PRM ,:TERMOADE-COD-CLIENTE ,:TERMOADE-OCORR-ENDERECO ,:TERMOADE-COD-CORRETOR ,:TERMOADE-PCCOMCOR ,:TERMOADE-COD-ADMINISTRADOR ,:TERMOADE-PCCOMADM ,:TERMOADE-COD-USUARIO ,:TERMOADE-DATA-INCLUSAO ,:TERMOADE-SITUACAO ,:TERMOADE-NUM-PROPOSTA ,:TERMOADE-NUM-RCAP:VIND-RCAP ,:TERMOADE-DATA-RCAP:VIND-DATA-RCAP ,:TERMOADE-VAL-RCAP:VIND-VAL-RCAP ,:TERMOADE-NUM-APOLICE FROM SEGUROS.TERMO_ADESAO WHERE NUM_TERMO = :RELATORI-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1 = new R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1.Execute(r0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TERMOADE_NUM_TERMO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO);
                _.Move(executed_1.TERMOADE_COD_SUBGRUPO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO);
                _.Move(executed_1.TERMOADE_DATA_ADESAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO);
                _.Move(executed_1.TERMOADE_COD_AGENCIA_OP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_OP);
                _.Move(executed_1.TERMOADE_NUM_MATRICULA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN);
                _.Move(executed_1.TERMOADE_CODPDTVEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_CODPDTVEN);
                _.Move(executed_1.TERMOADE_PCCOMVEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMVEN);
                _.Move(executed_1.TERMOADE_PCADIANTVEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCADIANTVEN);
                _.Move(executed_1.TERMOADE_COD_AGENCIA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_VEN);
                _.Move(executed_1.TERMOADE_OPERACAO_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_OPERACAO_CONTA_VEN);
                _.Move(executed_1.TERMOADE_NUM_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_CONTA_VEN);
                _.Move(executed_1.TERMOADE_DIG_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DIG_CONTA_VEN);
                _.Move(executed_1.TERMOADE_NUM_MATRICULA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_GER);
                _.Move(executed_1.TERMOADE_CODPDTGER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_CODPDTGER);
                _.Move(executed_1.TERMOADE_PCCOMGER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMGER);
                _.Move(executed_1.TERMOADE_COD_AGENCIA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_GER);
                _.Move(executed_1.TERMOADE_OPERACAO_CONTA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_OPERACAO_CONTA_GER);
                _.Move(executed_1.TERMOADE_NUM_CONTA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_CONTA_GER);
                _.Move(executed_1.TERMOADE_DIG_CONTA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DIG_CONTA_GER);
                _.Move(executed_1.TERMOADE_NUM_MATRICULA_SUR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_SUR);
                _.Move(executed_1.TERMOADE_CODPDTSUR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_CODPDTSUR);
                _.Move(executed_1.TERMOADE_PCCOMSUR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMSUR);
                _.Move(executed_1.TERMOADE_NUM_MATRICULA_GCO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_GCO);
                _.Move(executed_1.TERMOADE_CODPDTGCO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_CODPDTGCO);
                _.Move(executed_1.TERMOADE_PCCOMGCO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMGCO);
                _.Move(executed_1.TERMOADE_MODALIDADE_CAPITAL, TERMOADE.DCLTERMO_ADESAO.TERMOADE_MODALIDADE_CAPITAL);
                _.Move(executed_1.TERMOADE_TIPO_PLANO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_PLANO);
                _.Move(executed_1.TERMOADE_IND_PLANO_ASSOCIAD, TERMOADE.DCLTERMO_ADESAO.TERMOADE_IND_PLANO_ASSOCIAD);
                _.Move(executed_1.TERMOADE_COD_PLANO_VGAPC, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_VGAPC);
                _.Move(executed_1.TERMOADE_COD_PLANO_APC, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_APC);
                _.Move(executed_1.TERMOADE_VAL_CONTRATADO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_CONTRATADO);
                _.Move(executed_1.TERMOADE_VAL_COMISSAO_ADIAN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_COMISSAO_ADIAN);
                _.Move(executed_1.TERMOADE_QUANT_VIDAS, TERMOADE.DCLTERMO_ADESAO.TERMOADE_QUANT_VIDAS);
                _.Move(executed_1.TERMOADE_TIPO_COBERTURA, TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_COBERTURA);
                _.Move(executed_1.TERMOADE_PERI_PAGAMENTO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERI_PAGAMENTO);
                _.Move(executed_1.TERMOADE_TIPO_CORRECAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_CORRECAO);
                _.Move(executed_1.TERMOADE_PERIODO_CORRECAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERIODO_CORRECAO);
                _.Move(executed_1.TERMOADE_COD_MOEDA_IMP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_MOEDA_IMP);
                _.Move(executed_1.TERMOADE_COD_MOEDA_PRM, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_MOEDA_PRM);
                _.Move(executed_1.TERMOADE_COD_CLIENTE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE);
                _.Move(executed_1.TERMOADE_OCORR_ENDERECO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_OCORR_ENDERECO);
                _.Move(executed_1.TERMOADE_COD_CORRETOR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CORRETOR);
                _.Move(executed_1.TERMOADE_PCCOMCOR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMCOR);
                _.Move(executed_1.TERMOADE_COD_ADMINISTRADOR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_ADMINISTRADOR);
                _.Move(executed_1.TERMOADE_PCCOMADM, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMADM);
                _.Move(executed_1.TERMOADE_COD_USUARIO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_USUARIO);
                _.Move(executed_1.TERMOADE_DATA_INCLUSAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_INCLUSAO);
                _.Move(executed_1.TERMOADE_SITUACAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_SITUACAO);
                _.Move(executed_1.TERMOADE_NUM_PROPOSTA, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_PROPOSTA);
                _.Move(executed_1.TERMOADE_NUM_RCAP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_RCAP);
                _.Move(executed_1.VIND_RCAP, VIND_RCAP);
                _.Move(executed_1.TERMOADE_DATA_RCAP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_RCAP);
                _.Move(executed_1.VIND_DATA_RCAP, VIND_DATA_RCAP);
                _.Move(executed_1.TERMOADE_VAL_RCAP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_RCAP);
                _.Move(executed_1.VIND_VAL_RCAP, VIND_VAL_RCAP);
                _.Move(executed_1.TERMOADE_NUM_APOLICE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_SAIDA*/

        [StopWatch]
        /*" R0170-00-LER-CERTIFICADO-DB-SELECT-2 */
        public void R0170_00_LER_CERTIFICADO_DB_SELECT_2()
        {
            /*" -926- EXEC SQL SELECT NUM_CERTIFICADO , COD_PRODUTO , SIT_REGISTRO , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , STA_ANTECIPACAO , STA_MUDANCA_PLANO INTO :PROPOVA-NUM-CERTIFICADO ,:PROPOVA-COD-PRODUTO ,:PROPOVA-SIT-REGISTRO ,:PROPOVA-FAIXA-RENDA-IND:VIND-FAIXA-RENDA-IND ,:PROPOVA-FAIXA-RENDA-FAM:VIND-FAIXA-RENDA-FAM ,:PROPOVA-STA-ANTECIPACAO:VIND-STA-ANTECIPACAO ,:PROPOVA-STA-MUDANCA-PLANO:VIND-STA-MUDANCA FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO END-EXEC. */

            var r0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1 = new R0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1.Execute(r0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(executed_1.PROPOVA_FAIXA_RENDA_IND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND);
                _.Move(executed_1.VIND_FAIXA_RENDA_IND, VIND_FAIXA_RENDA_IND);
                _.Move(executed_1.PROPOVA_FAIXA_RENDA_FAM, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM);
                _.Move(executed_1.VIND_FAIXA_RENDA_FAM, VIND_FAIXA_RENDA_FAM);
                _.Move(executed_1.PROPOVA_STA_ANTECIPACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_STA_ANTECIPACAO);
                _.Move(executed_1.VIND_STA_ANTECIPACAO, VIND_STA_ANTECIPACAO);
                _.Move(executed_1.PROPOVA_STA_MUDANCA_PLANO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_STA_MUDANCA_PLANO);
                _.Move(executed_1.VIND_STA_MUDANCA, VIND_STA_MUDANCA);
            }


        }

        [StopWatch]
        /*" R0200-00-LER-RCAPS-SECTION */
        private void R0200_00_LER_RCAPS_SECTION()
        {
            /*" -943- MOVE 'R0200-00-LER-RCAPS' TO PARAGRAFO. */
            _.Move("R0200-00-LER-RCAPS", WABEND2.PARAGRAFO);

            /*" -950- MOVE 'SELECT RCAPS' TO COMANDO. */
            _.Move("SELECT RCAPS", WABEND2.COMANDO);

            /*" -953- MOVE VGCOMTRO-NUM-PROPOSTA-SIVPF TO RCAPS-NUM-CERTIFICADO. */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -982- PERFORM R0200_00_LER_RCAPS_DB_SELECT_1 */

            R0200_00_LER_RCAPS_DB_SELECT_1();

            /*" -985- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -986- MOVE 1 TO W-RCAPS */
                _.Move(1, W_RCAPS);

                /*" -987- GO TO R0200-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/ //GOTO
                return;

                /*" -989- END-IF. */
            }


            /*" -990- IF SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 100)
            {

                /*" -991- DISPLAY 'VE0125B - ERRO SELECT RCAPS P/PROPOSTA' */
                _.Display($"VE0125B - ERRO SELECT RCAPS P/PROPOSTA");

                /*" -993- DISPLAY '          CERTIFICADO = ' RCAPS-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO}");

                /*" -994- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -995- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -999- END-IF. */
            }


            /*" -1001- MOVE TERMOADE-NUM-RCAP TO RCAPS-NUM-RCAP. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);

            /*" -1029- PERFORM R0200_00_LER_RCAPS_DB_SELECT_2 */

            R0200_00_LER_RCAPS_DB_SELECT_2();

            /*" -1032- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1033- MOVE 1 TO W-RCAPS */
                _.Move(1, W_RCAPS);

                /*" -1034- ELSE */
            }
            else
            {


                /*" -1035- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1036- MOVE 2 TO W-RCAPS */
                    _.Move(2, W_RCAPS);

                    /*" -1037- ELSE */
                }
                else
                {


                    /*" -1038- DISPLAY 'VE0125B - ERRO SELECT RCAPS P/CERTIFICADO' */
                    _.Display($"VE0125B - ERRO SELECT RCAPS P/CERTIFICADO");

                    /*" -1040- DISPLAY '          CERTIFICADO = ' RCAPS-NUM-CERTIFICADO */
                    _.Display($"          CERTIFICADO = {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO}");

                    /*" -1041- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1042- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1043- END-IF */
                }


                /*" -1043- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-LER-RCAPS-DB-SELECT-1 */
        public void R0200_00_LER_RCAPS_DB_SELECT_1()
        {
            /*" -982- EXEC SQL SELECT COD_FONTE , NUM_PROPOSTA , VAL_RCAP , VAL_RCAP_PRINCIPAL , DATA_CADASTRAMENTO , DATA_MOVIMENTO , SIT_REGISTRO , COD_OPERACAO , NUM_TITULO , AGE_COBRANCA , NUM_RCAP INTO :RCAPS-COD-FONTE ,:RCAPS-NUM-PROPOSTA ,:RCAPS-VAL-RCAP ,:RCAPS-VAL-RCAP-PRINCIPAL ,:RCAPS-DATA-CADASTRAMENTO ,:RCAPS-DATA-MOVIMENTO ,:RCAPS-SIT-REGISTRO ,:RCAPS-COD-OPERACAO ,:RCAPS-NUM-TITULO ,:RCAPS-AGE-COBRANCA:VIND-AGE-COBRANCA ,:RCAPS-NUM-RCAP FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO AND NUM_PARCELA = 0 WITH UR END-EXEC. */

            var r0200_00_LER_RCAPS_DB_SELECT_1_Query1 = new R0200_00_LER_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0200_00_LER_RCAPS_DB_SELECT_1_Query1.Execute(r0200_00_LER_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_PROPOSTA, RCAPS.DCLRCAPS.RCAPS_NUM_PROPOSTA);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP_PRINCIPAL, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL);
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPS_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPS_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
                _.Move(executed_1.VIND_AGE_COBRANCA, VIND_AGE_COBRANCA);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0200-00-LER-RCAPS-DB-SELECT-2 */
        public void R0200_00_LER_RCAPS_DB_SELECT_2()
        {
            /*" -1029- EXEC SQL SELECT COD_FONTE , NUM_PROPOSTA , VAL_RCAP , VAL_RCAP_PRINCIPAL , DATA_CADASTRAMENTO , DATA_MOVIMENTO , SIT_REGISTRO , COD_OPERACAO , NUM_TITULO , AGE_COBRANCA , NUM_RCAP INTO :RCAPS-COD-FONTE ,:RCAPS-NUM-PROPOSTA ,:RCAPS-VAL-RCAP ,:RCAPS-VAL-RCAP-PRINCIPAL ,:RCAPS-DATA-CADASTRAMENTO ,:RCAPS-DATA-MOVIMENTO ,:RCAPS-SIT-REGISTRO ,:RCAPS-COD-OPERACAO ,:RCAPS-NUM-TITULO ,:RCAPS-AGE-COBRANCA:VIND-AGE-COBRANCA ,:RCAPS-NUM-RCAP FROM SEGUROS.RCAPS WHERE NUM_RCAP = :RCAPS-NUM-RCAP WITH UR END-EXEC. */

            var r0200_00_LER_RCAPS_DB_SELECT_2_Query1 = new R0200_00_LER_RCAPS_DB_SELECT_2_Query1()
            {
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = R0200_00_LER_RCAPS_DB_SELECT_2_Query1.Execute(r0200_00_LER_RCAPS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_PROPOSTA, RCAPS.DCLRCAPS.RCAPS_NUM_PROPOSTA);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP_PRINCIPAL, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL);
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPS_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPS_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
                _.Move(executed_1.VIND_AGE_COBRANCA, VIND_AGE_COBRANCA);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
            }


        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-SECTION */
        private void R0205_00_LER_RCAPCOMP_SECTION()
        {
            /*" -1052- MOVE 'R0205-00-LER-RCAPCOMP' TO PARAGRAFO. */
            _.Move("R0205-00-LER-RCAPCOMP", WABEND2.PARAGRAFO);

            /*" -1054- MOVE 'SELECT RCAP-COMPLEMENTAR' TO COMANDO. */
            _.Move("SELECT RCAP-COMPLEMENTAR", WABEND2.COMANDO);

            /*" -1072- PERFORM R0205_00_LER_RCAPCOMP_DB_SELECT_1 */

            R0205_00_LER_RCAPCOMP_DB_SELECT_1();

            /*" -1075- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1076- MOVE 1 TO W-RCAPCOMP */
                _.Move(1, W_RCAPCOMP);

                /*" -1078- GO TO R0205-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0205_SAIDA*/ //GOTO
                return;
            }


            /*" -1079- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1080- MOVE 2 TO W-RCAPCOMP */
                _.Move(2, W_RCAPCOMP);

                /*" -1082- GO TO R0205-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0205_SAIDA*/ //GOTO
                return;
            }


            /*" -1083- IF SQLCODE NOT EQUAL -811 */

            if (DB.SQLCODE != -811)
            {

                /*" -1084- DISPLAY 'VE0125B - ERRO SELECT RCAP_COMPLEMENTAR' */
                _.Display($"VE0125B - ERRO SELECT RCAP_COMPLEMENTAR");

                /*" -1086- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1088- DISPLAY '          NUMERO RCAPS= ' RCAPS-NUM-RCAP */
                _.Display($"          NUMERO RCAPS= {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                /*" -1090- DISPLAY '          COD. FONTE  = ' RCAPS-COD-FONTE */
                _.Display($"          COD. FONTE  = {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                /*" -1091- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1092- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1096- END-IF. */
            }


            /*" -1098- MOVE 'DECLARE RCAP-COMPLEMENTAR' TO COMANDO. */
            _.Move("DECLARE RCAP-COMPLEMENTAR", WABEND2.COMANDO);

            /*" -1111- PERFORM R0205_00_LER_RCAPCOMP_DB_DECLARE_1 */

            R0205_00_LER_RCAPCOMP_DB_DECLARE_1();

            /*" -1114- MOVE 'OPEN RCAP-COMPLEMENTAR' TO COMANDO. */
            _.Move("OPEN RCAP-COMPLEMENTAR", WABEND2.COMANDO);

            /*" -1114- PERFORM R0205_00_LER_RCAPCOMP_DB_OPEN_1 */

            R0205_00_LER_RCAPCOMP_DB_OPEN_1();

            /*" -1117- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1118- DISPLAY 'VE0125B - ERRO OPEN CURSOR RCAPCOMP' */
                _.Display($"VE0125B - ERRO OPEN CURSOR RCAPCOMP");

                /*" -1120- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1122- DISPLAY '          NUMERO RCAP = ' RCAPS-NUM-RCAP */
                _.Display($"          NUMERO RCAP = {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                /*" -1124- DISPLAY '          COD. FONTE  = ' RCAPS-COD-FONTE */
                _.Display($"          COD. FONTE  = {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                /*" -1125- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1126- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1128- END-IF. */
            }


            /*" -1137- PERFORM R0205_00_LER_RCAPCOMP_DB_FETCH_1 */

            R0205_00_LER_RCAPCOMP_DB_FETCH_1();

            /*" -1140- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1141- MOVE 1 TO W-RCAPCOMP */
                _.Move(1, W_RCAPCOMP);

                /*" -1142- ELSE */
            }
            else
            {


                /*" -1143- DISPLAY 'VE0125B - ERRO FETCH RCAPCOMP' */
                _.Display($"VE0125B - ERRO FETCH RCAPCOMP");

                /*" -1145- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1147- DISPLAY '          NUMERO RCAP = ' RCAPS-NUM-RCAP */
                _.Display($"          NUMERO RCAP = {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                /*" -1148- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1149- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1151- END-IF. */
            }


            /*" -1151- PERFORM R0205_00_LER_RCAPCOMP_DB_CLOSE_1 */

            R0205_00_LER_RCAPCOMP_DB_CLOSE_1();

            /*" -1154- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1155- DISPLAY 'VE0125B - ERRO CLOSE RCAPCOMP' */
                _.Display($"VE0125B - ERRO CLOSE RCAPCOMP");

                /*" -1157- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1159- DISPLAY '          NUMERO RCAP = ' RCAPS-NUM-RCAP */
                _.Display($"          NUMERO RCAP = {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                /*" -1160- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1161- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1161- END-IF. */
            }


        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-DB-SELECT-1 */
        public void R0205_00_LER_RCAPCOMP_DB_SELECT_1()
        {
            /*" -1072- EXEC SQL SELECT BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , DATA_MOVIMENTO , DATA_RCAP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO ,:DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO ,:DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO ,:DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO ,:DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :RCAPS-COD-FONTE AND NUM_RCAP = :RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r0205_00_LER_RCAPCOMP_DB_SELECT_1_Query1 = new R0205_00_LER_RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = R0205_00_LER_RCAPCOMP_DB_SELECT_1_Query1.Execute(r0205_00_LER_RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
            }


        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-DB-OPEN-1 */
        public void R0205_00_LER_RCAPCOMP_DB_OPEN_1()
        {
            /*" -1114- EXEC SQL OPEN C01_RCAPCOMP END-EXEC. */

            C01_RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R0350-00-DECLARE-ENDERECO-DB-DECLARE-1 */
        public void R0350_00_DECLARE_ENDERECO_DB_DECLARE_1()
        {
            /*" -1336- EXEC SQL DECLARE C01_ENDERECO CURSOR FOR SELECT COD_CLIENTE , COD_ENDERECO , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , TELEX , SIT_REGISTRO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLENDERECOS.ENDERECO-COD-CLIENTE AND SIT_REGISTRO = '0' ORDER BY COD_ENDERECO END-EXEC. */
            C01_ENDERECO = new VE0125B_C01_ENDERECO(true);
            string GetQuery_C01_ENDERECO()
            {
                var query = @$"SELECT 
							COD_CLIENTE 
							, COD_ENDERECO 
							, OCORR_ENDERECO 
							, ENDERECO 
							, BAIRRO 
							, CIDADE 
							, SIGLA_UF 
							, CEP 
							, DDD 
							, TELEFONE 
							, FAX 
							, TELEX 
							, SIT_REGISTRO 
							FROM SEGUROS.ENDERECOS 
							WHERE COD_CLIENTE = 
							'{ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}' 
							AND SIT_REGISTRO = '0' 
							ORDER BY COD_ENDERECO";

                return query;
            }
            C01_ENDERECO.GetQueryEvent += GetQuery_C01_ENDERECO;

        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-DB-FETCH-1 */
        public void R0205_00_LER_RCAPCOMP_DB_FETCH_1()
        {
            /*" -1137- EXEC SQL FETCH C01_RCAPCOMP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO ,:DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO ,:DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO ,:DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO ,:DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP ,:DCLRCAP-COMPLEMENTAR.RCAPCOMP-COD-OPERACAO END-EXEC. */

            if (C01_RCAPCOMP.Fetch())
            {
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);
            }

        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-DB-CLOSE-1 */
        public void R0205_00_LER_RCAPCOMP_DB_CLOSE_1()
        {
            /*" -1151- EXEC SQL CLOSE C01_RCAPCOMP END-EXEC. */

            C01_RCAPCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0205_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-SECTION */
        private void R0300_00_LER_CLIENTE_SECTION()
        {
            /*" -1170- MOVE 'R0300-00-LER-CLIENTES' TO PARAGRAFO. */
            _.Move("R0300-00-LER-CLIENTES", WABEND2.PARAGRAFO);

            /*" -1172- MOVE 'SELECT CLIENTES' TO COMANDO. */
            _.Move("SELECT CLIENTES", WABEND2.COMANDO);

            /*" -1175- MOVE TERMOADE-COD-CLIENTE TO COD-CLIENTE OF DCLCLIENTES. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);

            /*" -1193- PERFORM R0300_00_LER_CLIENTE_DB_SELECT_1 */

            R0300_00_LER_CLIENTE_DB_SELECT_1();

            /*" -1196- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1197- MOVE 1 TO W-CLIENTE */
                _.Move(1, W_CLIENTE);

                /*" -1198- ELSE */
            }
            else
            {


                /*" -1199- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1200- MOVE 2 TO W-CLIENTE */
                    _.Move(2, W_CLIENTE);

                    /*" -1201- ELSE */
                }
                else
                {


                    /*" -1202- DISPLAY 'VE0125B - ERRO SELECT CLIENTES ' */
                    _.Display($"VE0125B - ERRO SELECT CLIENTES ");

                    /*" -1204- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                    _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -1206- DISPLAY '          COD CLIENTE = ' TERMOADE-COD-CLIENTE */
                    _.Display($"          COD CLIENTE = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}");

                    /*" -1207- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1207- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-DB-SELECT-1 */
        public void R0300_00_LER_CLIENTE_DB_SELECT_1()
        {
            /*" -1193- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO INTO :DCLCLIENTES.COD-CLIENTE ,:DCLCLIENTES.NOME-RAZAO ,:DCLCLIENTES.TIPO-PESSOA ,:DCLCLIENTES.CGCCPF ,:DCLCLIENTES.SIT-REGISTRO ,:DCLCLIENTES.DATA-NASCIMENTO:VIND-DTNASCI FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE WITH UR END-EXEC. */

            var r0300_00_LER_CLIENTE_DB_SELECT_1_Query1 = new R0300_00_LER_CLIENTE_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R0300_00_LER_CLIENTE_DB_SELECT_1_Query1.Execute(r0300_00_LER_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);
                _.Move(executed_1.NOME_RAZAO, CLIENTE.DCLCLIENTES.NOME_RAZAO);
                _.Move(executed_1.TIPO_PESSOA, CLIENTE.DCLCLIENTES.TIPO_PESSOA);
                _.Move(executed_1.CGCCPF, CLIENTE.DCLCLIENTES.CGCCPF);
                _.Move(executed_1.SIT_REGISTRO, CLIENTE.DCLCLIENTES.SIT_REGISTRO);
                _.Move(executed_1.DATA_NASCIMENTO, CLIENTE.DCLCLIENTES.DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASCI, VIND_DTNASCI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0310-00-LER-PESSOA-JURIDICA-SECTION */
        private void R0310_00_LER_PESSOA_JURIDICA_SECTION()
        {
            /*" -1216- MOVE 'R0310-00-LER-PESSOA-JURIDICA' TO PARAGRAFO. */
            _.Move("R0310-00-LER-PESSOA-JURIDICA", WABEND2.PARAGRAFO);

            /*" -1218- MOVE 'SELECT PESJUR' TO COMANDO. */
            _.Move("SELECT PESJUR", WABEND2.COMANDO);

            /*" -1223- PERFORM R0310_00_LER_PESSOA_JURIDICA_DB_SELECT_1 */

            R0310_00_LER_PESSOA_JURIDICA_DB_SELECT_1();

            /*" -1226- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1227- MOVE 1 TO W-PESJUR */
                _.Move(1, W_PESJUR);

                /*" -1228- ELSE */
            }
            else
            {


                /*" -1229- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1230- MOVE 2 TO W-PESJUR */
                    _.Move(2, W_PESJUR);

                    /*" -1231- ELSE */
                }
                else
                {


                    /*" -1232- DISPLAY 'VE0125B - ERRO SELECT PESSOA JURIDICA' */
                    _.Display($"VE0125B - ERRO SELECT PESSOA JURIDICA");

                    /*" -1234- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                    _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -1236- DISPLAY '          COD CLIENTE = ' TERMOADE-COD-CLIENTE */
                    _.Display($"          COD CLIENTE = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}");

                    /*" -1238- DISPLAY '          CNPJ        = ' CGCCPF OF DCLCLIENTES */
                    _.Display($"          CNPJ        = {CLIENTE.DCLCLIENTES.CGCCPF}");

                    /*" -1239- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1239- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0310-00-LER-PESSOA-JURIDICA-DB-SELECT-1 */
        public void R0310_00_LER_PESSOA_JURIDICA_DB_SELECT_1()
        {
            /*" -1223- EXEC SQL SELECT COD_PESSOA INTO :DCLPESSOA-JURIDICA.COD-PESSOA FROM SEGUROS.PESSOA_JURIDICA WHERE CGC = :DCLCLIENTES.CGCCPF END-EXEC */

            var r0310_00_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1 = new R0310_00_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1()
            {
                CGCCPF = CLIENTE.DCLCLIENTES.CGCCPF.ToString(),
            };

            var executed_1 = R0310_00_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1.Execute(r0310_00_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_SAIDA*/

        [StopWatch]
        /*" R0320-00-LER-PESSOA-EMAIL-SECTION */
        private void R0320_00_LER_PESSOA_EMAIL_SECTION()
        {
            /*" -1248- MOVE 'R0320-00-LER-PESSOA-EMAIL' TO PARAGRAFO. */
            _.Move("R0320-00-LER-PESSOA-EMAIL", WABEND2.PARAGRAFO);

            /*" -1250- MOVE 'SELECT MAX SEQ MAIL' TO COMANDO. */
            _.Move("SELECT MAX SEQ MAIL", WABEND2.COMANDO);

            /*" -1257- PERFORM R0320_00_LER_PESSOA_EMAIL_DB_SELECT_1 */

            R0320_00_LER_PESSOA_EMAIL_DB_SELECT_1();

            /*" -1260- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1261- DISPLAY 'VE0125B - ERRO SELECT MAX SEQ-EMAIL' */
                _.Display($"VE0125B - ERRO SELECT MAX SEQ-EMAIL");

                /*" -1263- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1265- DISPLAY '          COD PESSOA  = ' COD-PESSOA OF DCLPESSOA-JURIDICA */
                _.Display($"          COD PESSOA  = {PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA}");

                /*" -1266- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1267- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1269- END-IF. */
            }


            /*" -1271- IF PESSOEMA-SEQ-EMAIL EQUAL ZEROS */

            if (PESSOEMA.DCLPESSOA_EMAIL.PESSOEMA_SEQ_EMAIL == 00)
            {

                /*" -1272- MOVE 2 TO W-PESEMAIL */
                _.Move(2, W_PESEMAIL);

                /*" -1273- GO TO R0320-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_SAIDA*/ //GOTO
                return;

                /*" -1275- END-IF. */
            }


            /*" -1277- MOVE 'SELECT PESSOA EMAIL' TO COMANDO. */
            _.Move("SELECT PESSOA EMAIL", WABEND2.COMANDO);

            /*" -1284- PERFORM R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2 */

            R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2();

            /*" -1287- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1288- MOVE 1 TO W-PESEMAIL */
                _.Move(1, W_PESEMAIL);

                /*" -1289- ELSE */
            }
            else
            {


                /*" -1290- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1291- MOVE 2 TO W-PESEMAIL */
                    _.Move(2, W_PESEMAIL);

                    /*" -1292- ELSE */
                }
                else
                {


                    /*" -1293- DISPLAY 'VE0125B - ERRO SELECT PESSOA EMAIL' */
                    _.Display($"VE0125B - ERRO SELECT PESSOA EMAIL");

                    /*" -1295- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                    _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -1297- DISPLAY '          COD CLIENTE = ' TERMOADE-COD-CLIENTE */
                    _.Display($"          COD CLIENTE = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}");

                    /*" -1299- DISPLAY '          CNPJ        = ' CGCCPF OF DCLCLIENTES */
                    _.Display($"          CNPJ        = {CLIENTE.DCLCLIENTES.CGCCPF}");

                    /*" -1301- DISPLAY '          COD PESSOA  = ' COD-PESSOA OF DCLPESSOA-JURIDICA */
                    _.Display($"          COD PESSOA  = {PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA}");

                    /*" -1302- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1302- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0320-00-LER-PESSOA-EMAIL-DB-SELECT-1 */
        public void R0320_00_LER_PESSOA_EMAIL_DB_SELECT_1()
        {
            /*" -1257- EXEC SQL SELECT COALESCE(MAX(SEQ_EMAIL),0) INTO :PESSOEMA-SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-JURIDICA.COD-PESSOA AND SITUACAO_EMAIL = 'A' WITH UR END-EXEC */

            var r0320_00_LER_PESSOA_EMAIL_DB_SELECT_1_Query1 = new R0320_00_LER_PESSOA_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA.ToString(),
            };

            var executed_1 = R0320_00_LER_PESSOA_EMAIL_DB_SELECT_1_Query1.Execute(r0320_00_LER_PESSOA_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOEMA_SEQ_EMAIL, PESSOEMA.DCLPESSOA_EMAIL.PESSOEMA_SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_SAIDA*/

        [StopWatch]
        /*" R0320-00-LER-PESSOA-EMAIL-DB-SELECT-2 */
        public void R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2()
        {
            /*" -1284- EXEC SQL SELECT EMAIL INTO :PESSOEMA-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-JURIDICA.COD-PESSOA AND SITUACAO_EMAIL = 'A' AND SEQ_EMAIL = :PESSOEMA-SEQ-EMAIL END-EXEC */

            var r0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1 = new R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1()
            {
                COD_PESSOA = PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA.ToString(),
                PESSOEMA_SEQ_EMAIL = PESSOEMA.DCLPESSOA_EMAIL.PESSOEMA_SEQ_EMAIL.ToString(),
            };

            var executed_1 = R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1.Execute(r0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOEMA_EMAIL, PESSOEMA.DCLPESSOA_EMAIL.PESSOEMA_EMAIL);
            }


        }

        [StopWatch]
        /*" R0350-00-DECLARE-ENDERECO-SECTION */
        private void R0350_00_DECLARE_ENDERECO_SECTION()
        {
            /*" -1311- MOVE 'R0350-00-DECLARE-ENDERECO' TO PARAGRAFO. */
            _.Move("R0350-00-DECLARE-ENDERECO", WABEND2.PARAGRAFO);

            /*" -1313- MOVE 'DECLARE ENDERECO ' TO COMANDO. */
            _.Move("DECLARE ENDERECO ", WABEND2.COMANDO);

            /*" -1316- MOVE TERMOADE-COD-CLIENTE TO ENDERECO-COD-CLIENTE OF DCLENDERECOS. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -1336- PERFORM R0350_00_DECLARE_ENDERECO_DB_DECLARE_1 */

            R0350_00_DECLARE_ENDERECO_DB_DECLARE_1();

            /*" -1339- MOVE 'OPEN C01_ENDERECO ' TO COMANDO. */
            _.Move("OPEN C01_ENDERECO ", WABEND2.COMANDO);

            /*" -1339- PERFORM R0350_00_DECLARE_ENDERECO_DB_OPEN_1 */

            R0350_00_DECLARE_ENDERECO_DB_OPEN_1();

            /*" -1342- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1343- DISPLAY 'VE0125B - ERRO OPEN CURSOR ENDERECO ' */
                _.Display($"VE0125B - ERRO OPEN CURSOR ENDERECO ");

                /*" -1345- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1346- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1346- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0350-00-DECLARE-ENDERECO-DB-OPEN-1 */
        public void R0350_00_DECLARE_ENDERECO_DB_OPEN_1()
        {
            /*" -1339- EXEC SQL OPEN C01_ENDERECO END-EXEC. */

            C01_ENDERECO.Open();

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-DECLARE-1 */
        public void R0450_00_OBTER_COBERTURA_DB_DECLARE_1()
        {
            /*" -1567- EXEC SQL DECLARE COBERTURAS CURSOR FOR SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMP_MORNATU , IMPMORACID , IMPINVPERM FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO AND DATA_TERVIGENCIA = :HISCOBPR-DATA-TERVIGENCIA ORDER BY OCORR_HISTORICO WITH UR END-EXEC. */
            COBERTURAS = new VE0125B_COBERTURAS(true);
            string GetQuery_COBERTURAS()
            {
                var query = @$"SELECT NUM_CERTIFICADO 
							, OCORR_HISTORICO 
							, DATA_INIVIGENCIA 
							, DATA_TERVIGENCIA 
							, IMP_MORNATU 
							, IMPMORACID 
							, IMPINVPERM 
							FROM SEGUROS.HIS_COBER_PROPOST 
							WHERE NUM_CERTIFICADO = '{HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}' 
							AND DATA_TERVIGENCIA = '{HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA}' 
							ORDER BY OCORR_HISTORICO";

                return query;
            }
            COBERTURAS.GetQueryEvent += GetQuery_COBERTURAS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R0370-00-LER-ENDERECO-SECTION */
        private void R0370_00_LER_ENDERECO_SECTION()
        {
            /*" -1355- MOVE 'R0370-00-LER-ENDERECO' TO PARAGRAFO. */
            _.Move("R0370-00-LER-ENDERECO", WABEND2.PARAGRAFO);

            /*" -1357- MOVE 'FETCH ENDERECOS' TO COMANDO. */
            _.Move("FETCH ENDERECOS", WABEND2.COMANDO);

            /*" -1373- PERFORM R0370_00_LER_ENDERECO_DB_FETCH_1 */

            R0370_00_LER_ENDERECO_DB_FETCH_1();

            /*" -1376- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1377- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1378- MOVE 2 TO W-ENDERECO */
                    _.Move(2, W_ENDERECO);

                    /*" -1379- ELSE */
                }
                else
                {


                    /*" -1380- DISPLAY 'VE0125B - ERRO FETCH CURSOR ENDERECO' */
                    _.Display($"VE0125B - ERRO FETCH CURSOR ENDERECO");

                    /*" -1382- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                    _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -1384- DISPLAY '          CLIENTE     = ' ENDERECO-COD-CLIENTE OF DCLENDERECOS */
                    _.Display($"          CLIENTE     = {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                    /*" -1385- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1386- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1387- END-IF */
                }


                /*" -1388- ELSE */
            }
            else
            {


                /*" -1389- MOVE 1 TO W-ENDERECO */
                _.Move(1, W_ENDERECO);

                /*" -1391- END-IF. */
            }


            /*" -1392- MOVE 'S' TO WFIM-ENDERECOS */
            _.Move("S", WFIM_ENDERECOS);

            /*" -1392- PERFORM R0370_00_LER_ENDERECO_DB_CLOSE_1 */

            R0370_00_LER_ENDERECO_DB_CLOSE_1();

            /*" -1394- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1395- DISPLAY 'VE0125B - ERRO CLOSE CURSOR ENDERECO ' */
                _.Display($"VE0125B - ERRO CLOSE CURSOR ENDERECO ");

                /*" -1397- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1399- DISPLAY '          CLIENTE     = ' ENDERECO-COD-CLIENTE OF DCLENDERECOS */
                _.Display($"          CLIENTE     = {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                /*" -1400- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1401- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1401- END-IF. */
            }


        }

        [StopWatch]
        /*" R0370-00-LER-ENDERECO-DB-FETCH-1 */
        public void R0370_00_LER_ENDERECO_DB_FETCH_1()
        {
            /*" -1373- EXEC SQL FETCH C01_ENDERECO INTO :DCLENDERECOS.ENDERECO-COD-CLIENTE ,:DCLENDERECOS.ENDERECO-COD-ENDERECO ,:DCLENDERECOS.ENDERECO-OCORR-ENDERECO ,:DCLENDERECOS.ENDERECO-ENDERECO ,:DCLENDERECOS.ENDERECO-BAIRRO ,:DCLENDERECOS.ENDERECO-CIDADE ,:DCLENDERECOS.ENDERECO-SIGLA-UF ,:DCLENDERECOS.ENDERECO-CEP ,:DCLENDERECOS.ENDERECO-DDD ,:DCLENDERECOS.ENDERECO-TELEFONE ,:DCLENDERECOS.ENDERECO-FAX ,:DCLENDERECOS.ENDERECO-TELEX ,:DCLENDERECOS.ENDERECO-SIT-REGISTRO END-EXEC. */

            if (C01_ENDERECO.Fetch())
            {
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_TELEX, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_SIT_REGISTRO, ENDERECO.DCLENDERECOS.ENDERECO_SIT_REGISTRO);
            }

        }

        [StopWatch]
        /*" R0370-00-LER-ENDERECO-DB-CLOSE-1 */
        public void R0370_00_LER_ENDERECO_DB_CLOSE_1()
        {
            /*" -1392- EXEC SQL CLOSE C01_ENDERECO END-EXEC. */

            C01_ENDERECO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_SAIDA*/

        [StopWatch]
        /*" R0400-00-LER-SUBGRUPO-SECTION */
        private void R0400_00_LER_SUBGRUPO_SECTION()
        {
            /*" -1410- MOVE 'R0400-00-LER-SUBGRUPO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-SUBGRUPO", WABEND2.PARAGRAFO);

            /*" -1412- MOVE 'SELECT SUBGRUPO ' TO COMANDO. */
            _.Move("SELECT SUBGRUPO ", WABEND2.COMANDO);

            /*" -1413- MOVE TERMOADE-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -1415- MOVE TERMOADE-COD-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -1476- PERFORM R0400_00_LER_SUBGRUPO_DB_SELECT_1 */

            R0400_00_LER_SUBGRUPO_DB_SELECT_1();

            /*" -1479- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1480- MOVE 1 TO W-SUBGRUPO */
                _.Move(1, W_SUBGRUPO);

                /*" -1481- ELSE */
            }
            else
            {


                /*" -1482- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1483- MOVE 2 TO W-SUBGRUPO */
                    _.Move(2, W_SUBGRUPO);

                    /*" -1484- ELSE */
                }
                else
                {


                    /*" -1485- DISPLAY 'VE0125B - ERRO SELECT SUBGRUPOS ' */
                    _.Display($"VE0125B - ERRO SELECT SUBGRUPOS ");

                    /*" -1487- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                    _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -1489- DISPLAY '          SUBGRUPO    = ' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"          SUBGRUPO    = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -1490- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1490- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0400-00-LER-SUBGRUPO-DB-SELECT-1 */
        public void R0400_00_LER_SUBGRUPO_DB_SELECT_1()
        {
            /*" -1476- EXEC SQL SELECT COD_SUBGRUPO , COD_CLIENTE , CLASSE_APOLICE , COD_FONTE , TIPO_FATURAMENTO , FORMA_FATURAMENTO , FORMA_AVERBACAO , TIPO_PLANO , PERI_FATURAMENTO , PERI_RENOVACAO , PERI_RETROATI_INC , PERI_RETROATI_CAN , OCORR_ENDERECO , OCORR_END_COBRAN , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , TIPO_COBRANCA , COD_PAG_ANGARIACAO , PCT_CONJUGE_VG , PCT_CONJUGE_AP , OPCAO_COBERTURA , OPCAO_CORRETAGEM , IND_CONSISTE_MATRI , IND_PLANO_ASSOCIA , SIT_REGISTRO , OPCAO_CONJUGE INTO :SUBGVGAP-COD-SUBGRUPO ,:SUBGVGAP-COD-CLIENTE ,:SUBGVGAP-CLASSE-APOLICE ,:SUBGVGAP-COD-FONTE ,:SUBGVGAP-TIPO-FATURAMENTO ,:SUBGVGAP-FORMA-FATURAMENTO ,:SUBGVGAP-FORMA-AVERBACAO ,:SUBGVGAP-TIPO-PLANO ,:SUBGVGAP-PERI-FATURAMENTO ,:SUBGVGAP-PERI-RENOVACAO ,:SUBGVGAP-PERI-RETROATI-INC ,:SUBGVGAP-PERI-RETROATI-CAN ,:SUBGVGAP-OCORR-ENDERECO ,:SUBGVGAP-OCORR-END-COBRAN ,:SUBGVGAP-BCO-COBRANCA ,:SUBGVGAP-AGE-COBRANCA ,:SUBGVGAP-DAC-COBRANCA ,:SUBGVGAP-TIPO-COBRANCA ,:SUBGVGAP-COD-PAG-ANGARIACAO ,:SUBGVGAP-PCT-CONJUGE-VG ,:SUBGVGAP-PCT-CONJUGE-AP ,:SUBGVGAP-OPCAO-COBERTURA ,:SUBGVGAP-OPCAO-CORRETAGEM ,:SUBGVGAP-IND-CONSISTE-MATRI ,:SUBGVGAP-IND-PLANO-ASSOCIA ,:SUBGVGAP-SIT-REGISTRO ,:SUBGVGAP-OPCAO-CONJUGE FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO WITH UR END-EXEC. */

            var r0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1 = new R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1.Execute(r0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);
                _.Move(executed_1.SUBGVGAP_COD_CLIENTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE);
                _.Move(executed_1.SUBGVGAP_CLASSE_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_CLASSE_APOLICE);
                _.Move(executed_1.SUBGVGAP_COD_FONTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE);
                _.Move(executed_1.SUBGVGAP_TIPO_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_FORMA_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_FORMA_AVERBACAO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_AVERBACAO);
                _.Move(executed_1.SUBGVGAP_TIPO_PLANO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO);
                _.Move(executed_1.SUBGVGAP_PERI_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_PERI_RENOVACAO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RENOVACAO);
                _.Move(executed_1.SUBGVGAP_PERI_RETROATI_INC, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RETROATI_INC);
                _.Move(executed_1.SUBGVGAP_PERI_RETROATI_CAN, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RETROATI_CAN);
                _.Move(executed_1.SUBGVGAP_OCORR_ENDERECO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO);
                _.Move(executed_1.SUBGVGAP_OCORR_END_COBRAN, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_END_COBRAN);
                _.Move(executed_1.SUBGVGAP_BCO_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_BCO_COBRANCA);
                _.Move(executed_1.SUBGVGAP_AGE_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_AGE_COBRANCA);
                _.Move(executed_1.SUBGVGAP_DAC_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DAC_COBRANCA);
                _.Move(executed_1.SUBGVGAP_TIPO_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_COBRANCA);
                _.Move(executed_1.SUBGVGAP_COD_PAG_ANGARIACAO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_PAG_ANGARIACAO);
                _.Move(executed_1.SUBGVGAP_PCT_CONJUGE_VG, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_VG);
                _.Move(executed_1.SUBGVGAP_PCT_CONJUGE_AP, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_AP);
                _.Move(executed_1.SUBGVGAP_OPCAO_COBERTURA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_COBERTURA);
                _.Move(executed_1.SUBGVGAP_OPCAO_CORRETAGEM, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CORRETAGEM);
                _.Move(executed_1.SUBGVGAP_IND_CONSISTE_MATRI, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_CONSISTE_MATRI);
                _.Move(executed_1.SUBGVGAP_IND_PLANO_ASSOCIA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_PLANO_ASSOCIA);
                _.Move(executed_1.SUBGVGAP_SIT_REGISTRO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_SIT_REGISTRO);
                _.Move(executed_1.SUBGVGAP_OPCAO_CONJUGE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_SAIDA*/

        [StopWatch]
        /*" R0500-00-OBTER-OPCAOPAG-SECTION */
        private void R0500_00_OBTER_OPCAOPAG_SECTION()
        {
            /*" -1499- MOVE 'R0500-00-OBTER-OPCAOPAG' TO PARAGRAFO. */
            _.Move("R0500-00-OBTER-OPCAOPAG", WABEND2.PARAGRAFO);

            /*" -1501- MOVE 'SELECT OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT OPCAOPAGVA", WABEND2.COMANDO);

            /*" -1502- MOVE PROPOVA-NUM-CERTIFICADO TO OPCPAGVI-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

            /*" -1504- MOVE '9999-12-31' TO OPCPAGVI-DATA-TERVIGENCIA */
            _.Move("9999-12-31", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA);

            /*" -1525- PERFORM R0500_00_OBTER_OPCAOPAG_DB_SELECT_1 */

            R0500_00_OBTER_OPCAOPAG_DB_SELECT_1();

            /*" -1528- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1529- MOVE 1 TO W-OPCAOPAG */
                _.Move(1, W_OPCAOPAG);

                /*" -1530- ELSE */
            }
            else
            {


                /*" -1531- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1532- MOVE 2 TO W-OPCAOPAG */
                    _.Move(2, W_OPCAOPAG);

                    /*" -1533- ELSE */
                }
                else
                {


                    /*" -1534- DISPLAY 'VE0125B - ERRO SELECT OPCAOPAGVA ' */
                    _.Display($"VE0125B - ERRO SELECT OPCAOPAGVA ");

                    /*" -1536- DISPLAY '          CERTIFICADO = ' OPCPAGVI-NUM-CERTIFICADO */
                    _.Display($"          CERTIFICADO = {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                    /*" -1538- DISPLAY '          TERVIGENCIA = ' OPCPAGVI-DATA-TERVIGENCIA */
                    _.Display($"          TERVIGENCIA = {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA}");

                    /*" -1539- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1539- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0500-00-OBTER-OPCAOPAG-DB-SELECT-1 */
        public void R0500_00_OBTER_OPCAOPAG_DB_SELECT_1()
        {
            /*" -1525- EXEC SQL SELECT OPCAO_PAGAMENTO , PERI_PAGAMENTO , DIA_DEBITO , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO INTO :OPCPAGVI-OPCAO-PAGAMENTO , :OPCPAGVI-PERI-PAGAMENTO , :OPCPAGVI-DIA-DEBITO , :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGECTADEB , :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPRCTADEB , :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUMCTADEB , :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIGCTADEB FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND DATA_TERVIGENCIA = :OPCPAGVI-DATA-TERVIGENCIA WITH UR END-EXEC. */

            var r0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1 = new R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1()
            {
                OPCPAGVI_DATA_TERVIGENCIA = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA.ToString(),
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1.Execute(r0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_AGECTADEB, VIND_AGECTADEB);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPRCTADEB, VIND_OPRCTADEB);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_NUMCTADEB, VIND_NUMCTADEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIGCTADEB, VIND_DIGCTADEB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_SAIDA*/

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-SECTION */
        private void R0450_00_OBTER_COBERTURA_SECTION()
        {
            /*" -1548- MOVE 'R0450-00-OBTER-COBERTURA' TO PARAGRAFO. */
            _.Move("R0450-00-OBTER-COBERTURA", WABEND2.PARAGRAFO);

            /*" -1550- MOVE 'DECLARE COBERPROPVA' TO COMANDO. */
            _.Move("DECLARE COBERPROPVA", WABEND2.COMANDO);

            /*" -1551- MOVE TERMOADE-NUM-TERMO TO HISCOBPR-NUM-CERTIFICADO */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);

            /*" -1552- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA */
            _.Move("9999-12-31", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

            /*" -1554- MOVE 2 TO W-COBERTURAS */
            _.Move(2, W_COBERTURAS);

            /*" -1567- PERFORM R0450_00_OBTER_COBERTURA_DB_DECLARE_1 */

            R0450_00_OBTER_COBERTURA_DB_DECLARE_1();

            /*" -1570- MOVE 'OPEN COBERPROPVA' TO COMANDO. */
            _.Move("OPEN COBERPROPVA", WABEND2.COMANDO);

            /*" -1570- PERFORM R0450_00_OBTER_COBERTURA_DB_OPEN_1 */

            R0450_00_OBTER_COBERTURA_DB_OPEN_1();

            /*" -1573- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1574- DISPLAY 'VE0125B - ERRO OPEN COBERTURAS      ' */
                _.Display($"VE0125B - ERRO OPEN COBERTURAS      ");

                /*" -1576- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1578- DISPLAY '          TERVIGENCIA = ' HISCOBPR-DATA-TERVIGENCIA */
                _.Display($"          TERVIGENCIA = {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA}");

                /*" -1579- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1581- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1591- PERFORM R0450_00_OBTER_COBERTURA_DB_FETCH_1 */

            R0450_00_OBTER_COBERTURA_DB_FETCH_1();

            /*" -1594- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1595- DISPLAY 'VE0125B - ERRO FETCH COBERTURAS  ' */
                _.Display($"VE0125B - ERRO FETCH COBERTURAS  ");

                /*" -1597- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1598- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1600- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1600- PERFORM R0450_00_OBTER_COBERTURA_DB_CLOSE_1 */

            R0450_00_OBTER_COBERTURA_DB_CLOSE_1();

            /*" -1603- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1604- MOVE 1 TO W-COBERTURAS */
                _.Move(1, W_COBERTURAS);

                /*" -1605- ELSE */
            }
            else
            {


                /*" -1606- DISPLAY 'VE0125B - ERRO CLOSE CURSOR COBERTURAS ' */
                _.Display($"VE0125B - ERRO CLOSE CURSOR COBERTURAS ");

                /*" -1608- DISPLAY '          CERTIFICADO = ' TERMOADE-NUM-TERMO */
                _.Display($"          CERTIFICADO = {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1609- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1609- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-OPEN-1 */
        public void R0450_00_OBTER_COBERTURA_DB_OPEN_1()
        {
            /*" -1570- EXEC SQL OPEN COBERTURAS END-EXEC. */

            COBERTURAS.Open();

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-DECLARE-1 */
        public void R0570_00_LER_COMISSAO_DB_DECLARE_1()
        {
            /*" -1636- EXEC SQL DECLARE FUNDOCOMISVA CURSOR FOR SELECT NUM_CERTIFICADO , VAL_COMISSAO_VG , VAL_COMISSAO_AP FROM SEGUROS.FUNDO_COMISSAO_VA WHERE NUM_CERTIFICADO = :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO AND COD_OPERACAO = :DCLFUNDO-COMISSAO-VA.COD-OPERACAO WITH UR END-EXEC. */
            FUNDOCOMISVA = new VE0125B_FUNDOCOMISVA(true);
            string GetQuery_FUNDOCOMISVA()
            {
                var query = @$"SELECT NUM_CERTIFICADO 
							, VAL_COMISSAO_VG 
							, VAL_COMISSAO_AP 
							FROM SEGUROS.FUNDO_COMISSAO_VA 
							WHERE NUM_CERTIFICADO = 
							'{FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}' 
							AND COD_OPERACAO = 
							'{FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO}'";

                return query;
            }
            FUNDOCOMISVA.GetQueryEvent += GetQuery_FUNDOCOMISVA;

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-FETCH-1 */
        public void R0450_00_OBTER_COBERTURA_DB_FETCH_1()
        {
            /*" -1591- EXEC SQL FETCH COBERTURAS INTO :HISCOBPR-NUM-CERTIFICADO ,:HISCOBPR-OCORR-HISTORICO ,:HISCOBPR-DATA-INIVIGENCIA ,:HISCOBPR-DATA-TERVIGENCIA ,:HISCOBPR-IMP-MORNATU ,:HISCOBPR-IMPMORACID ,:HISCOBPR-IMPINVPERM END-EXEC. */

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
            /*" -1600- EXEC SQL CLOSE COBERTURAS END-EXEC. */

            COBERTURAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_SAIDA*/

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-SECTION */
        private void R0570_00_LER_COMISSAO_SECTION()
        {
            /*" -1618- MOVE 'R0570-00-LER-COMISSAO' TO PARAGRAFO. */
            _.Move("R0570-00-LER-COMISSAO", WABEND2.PARAGRAFO);

            /*" -1620- MOVE 'DECLARE FUNDOCOMISVA' TO COMANDO. */
            _.Move("DECLARE FUNDOCOMISVA", WABEND2.COMANDO);

            /*" -1623- MOVE PROPOVA-NUM-CERTIFICADO TO NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);

            /*" -1626- MOVE 1101 TO COD-OPERACAO OF DCLFUNDO-COMISSAO-VA. */
            _.Move(1101, FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO);

            /*" -1636- PERFORM R0570_00_LER_COMISSAO_DB_DECLARE_1 */

            R0570_00_LER_COMISSAO_DB_DECLARE_1();

            /*" -1639- MOVE 'OPEN FUNDOCOMISVA' TO COMANDO. */
            _.Move("OPEN FUNDOCOMISVA", WABEND2.COMANDO);

            /*" -1639- PERFORM R0570_00_LER_COMISSAO_DB_OPEN_1 */

            R0570_00_LER_COMISSAO_DB_OPEN_1();

            /*" -1642- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1643- DISPLAY 'VE0125B - ERRO OPEN CURSOR FUNDOCOMISVA' */
                _.Display($"VE0125B - ERRO OPEN CURSOR FUNDOCOMISVA");

                /*" -1645- DISPLAY '          CERTIFICADO = ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          CERTIFICADO = {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -1647- DISPLAY '          OPERACAO    = ' COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          OPERACAO    = {FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO}");

                /*" -1648- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1650- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1656- PERFORM R0570_00_LER_COMISSAO_DB_FETCH_1 */

            R0570_00_LER_COMISSAO_DB_FETCH_1();

            /*" -1659- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1660- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1662- MOVE ZEROS TO VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG);

                    /*" -1664- MOVE ZEROS TO VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);

                    /*" -1665- ELSE */
                }
                else
                {


                    /*" -1666- DISPLAY 'VE0125B - ERRO SELECT CURSOR FUNDOCOMISVA' */
                    _.Display($"VE0125B - ERRO SELECT CURSOR FUNDOCOMISVA");

                    /*" -1668- DISPLAY '          CERTIFICADO = ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          CERTIFICADO = {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                    /*" -1670- DISPLAY '          OPERACAO    = ' COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          OPERACAO    = {FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO}");

                    /*" -1671- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1673- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -1673- PERFORM R0570_00_LER_COMISSAO_DB_CLOSE_1 */

            R0570_00_LER_COMISSAO_DB_CLOSE_1();

            /*" -1676- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1677- DISPLAY 'VE0125B - ERRO CLOSE CURSOR FUNDOCOMISVA ' */
                _.Display($"VE0125B - ERRO CLOSE CURSOR FUNDOCOMISVA ");

                /*" -1679- DISPLAY '          CERTIFICADO = ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          CERTIFICADO = {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -1681- DISPLAY '          OPERACAO    = ' COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          OPERACAO    = {FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO}");

                /*" -1682- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1682- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-OPEN-1 */
        public void R0570_00_LER_COMISSAO_DB_OPEN_1()
        {
            /*" -1639- EXEC SQL OPEN FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Open();

        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-DECLARE-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_DECLARE_1()
        {
            /*" -2298- EXEC SQL DECLARE C01_AGENCEF CURSOR FOR SELECT A.COD_AGENCIA ,B.COD_FONTE FROM SEGUROS.AGENCIAS_CEF A ,SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG < 1000 AND A.COD_ESCNEG = B.COD_SUREG ORDER BY A.COD_AGENCIA WITH UR END-EXEC. */
            C01_AGENCEF = new VE0125B_C01_AGENCEF(false);
            string GetQuery_C01_AGENCEF()
            {
                var query = @$"SELECT A.COD_AGENCIA 
							,B.COD_FONTE 
							FROM SEGUROS.AGENCIAS_CEF A 
							,SEGUROS.MALHA_CEF B 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG < 1000 
							AND A.COD_ESCNEG = B.COD_SUREG 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            C01_AGENCEF.GetQueryEvent += GetQuery_C01_AGENCEF;

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-FETCH-1 */
        public void R0570_00_LER_COMISSAO_DB_FETCH_1()
        {
            /*" -1656- EXEC SQL FETCH FUNDOCOMISVA INTO :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO ,:DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-VG ,:DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-AP END-EXEC. */

            if (FUNDOCOMISVA.Fetch())
            {
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG);
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);
            }

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-CLOSE-1 */
        public void R0570_00_LER_COMISSAO_DB_CLOSE_1()
        {
            /*" -1673- EXEC SQL CLOSE FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_SAIDA*/

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-SECTION */
        private void R0580_00_OBTER_VAL_TARIFA_SECTION()
        {
            /*" -1691- MOVE 'R0580-00-OBTER-VAL-TARIFA' TO PARAGRAFO. */
            _.Move("R0580-00-OBTER-VAL-TARIFA", WABEND2.PARAGRAFO);

            /*" -1693- MOVE 'SELECT TARIFA-BALCAO-CEF' TO COMANDO. */
            _.Move("SELECT TARIFA-BALCAO-CEF", WABEND2.COMANDO);

            /*" -1696- MOVE PROPOVA-NUM-CERTIFICADO TO NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO);

            /*" -1706- PERFORM R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1 */

            R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1();

            /*" -1709- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1710- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1712- MOVE ZEROS TO VAL-TARIFA OF DCLTARIFA-BALCAO-CEF */
                    _.Move(0, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);

                    /*" -1713- ELSE */
                }
                else
                {


                    /*" -1714- DISPLAY 'VE0125B - ERRO SELECT TARIFA-BALCAO-CEF' */
                    _.Display($"VE0125B - ERRO SELECT TARIFA-BALCAO-CEF");

                    /*" -1716- DISPLAY '          CERTIFICADO = ' NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF */
                    _.Display($"          CERTIFICADO = {TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO}");

                    /*" -1717- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1717- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-DB-SELECT-1 */
        public void R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1()
        {
            /*" -1706- EXEC SQL SELECT VAL_TARIFA INTO :DCLTARIFA-BALCAO-CEF.VAL-TARIFA FROM SEGUROS.TARIFA_BALCAO_CEF WHERE COD_EMPRESA = 0 AND NUM_MATRICULA = 9999999 AND TIPO_FUNCIONARIO = '5' AND NUM_CERTIFICADO = :DCLTARIFA-BALCAO-CEF.NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1 = new R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1.Execute(r0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VAL_TARIFA, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0580_SAIDA*/

        [StopWatch]
        /*" R0590-00-LER-COMPL-TERMO-SECTION */
        private void R0590_00_LER_COMPL_TERMO_SECTION()
        {
            /*" -1726- MOVE 'R0590-00-LER-COMPL-TERMO' TO PARAGRAFO. */
            _.Move("R0590-00-LER-COMPL-TERMO", WABEND2.PARAGRAFO);

            /*" -1728- MOVE 'SELECT VG_COMPL_TERMO' TO COMANDO. */
            _.Move("SELECT VG_COMPL_TERMO", WABEND2.COMANDO);

            /*" -1730- MOVE PROPOVA-NUM-CERTIFICADO TO VGCOMTRO-NUM-TERMO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_TERMO);

            /*" -1735- PERFORM R0590_00_LER_COMPL_TERMO_DB_SELECT_1 */

            R0590_00_LER_COMPL_TERMO_DB_SELECT_1();

            /*" -1738- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1739- DISPLAY 'VE0125B - ERRO SELECT VG_COMPL_TERMO' */
                _.Display($"VE0125B - ERRO SELECT VG_COMPL_TERMO");

                /*" -1741- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1742- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1743- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1743- END-IF. */
            }


        }

        [StopWatch]
        /*" R0590-00-LER-COMPL-TERMO-DB-SELECT-1 */
        public void R0590_00_LER_COMPL_TERMO_DB_SELECT_1()
        {
            /*" -1735- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :VGCOMTRO-NUM-PROPOSTA-SIVPF FROM SEGUROS.VG_COMPL_TERMO WHERE NUM_TERMO = :VGCOMTRO-NUM-TERMO END-EXEC. */

            var r0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1 = new R0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1()
            {
                VGCOMTRO_NUM_TERMO = VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_TERMO.ToString(),
            };

            var executed_1 = R0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1.Execute(r0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGCOMTRO_NUM_PROPOSTA_SIVPF, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0590_SAIDA*/

        [StopWatch]
        /*" R0600-00-PROPOSTA-REGISTRO-TP1-SECTION */
        private void R0600_00_PROPOSTA_REGISTRO_TP1_SECTION()
        {
            /*" -1755- MOVE SPACES TO REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES);

            /*" -1758- MOVE '1' TO R1-TIPO-REG OF REG-CLIENTES. */
            _.Move("1", LBFPF011.REG_CLIENTES.R1_TIPO_REG);

            /*" -1761- MOVE VGCOMTRO-NUM-PROPOSTA-SIVPF TO R1-NUM-PROPOSTA OF REG-CLIENTES. */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF, LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA);

            /*" -1764- MOVE CGCCPF OF DCLCLIENTES TO R1-CGC-CPF OF REG-CLIENTES. */
            _.Move(CLIENTE.DCLCLIENTES.CGCCPF, LBFPF011.REG_CLIENTES.R1_CGC_CPF);

            /*" -1767- MOVE NOME-RAZAO OF DCLCLIENTES TO R1-NOME-PESSOA OF REG-CLIENTES. */
            _.Move(CLIENTE.DCLCLIENTES.NOME_RAZAO, LBFPF011.REG_CLIENTES.R1_NOME_PESSOA);

            /*" -1770- MOVE 2 TO R1-TIPO-PESSOA OF REG-CLIENTES. */
            _.Move(2, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);

            /*" -1781- MOVE ZEROS TO R1-DATA-NASCIMENTO OF REG-CLIENTES R1-NUM-IDENTIDADE OF REG-CLIENTES R1-ESTADO-CIVIL OF REG-CLIENTES R1-IDE-SEXO OF REG-CLIENTES R1-COD-CBO OF REG-CLIENTES R1-CBO-CONJUGE OF REG-CLIENTES R1-DTNASC-CONJUGE OF REG-CLIENTES R1-DDD(1) R1-DDD(2) R1-DDD(3) R1-NUM-FONE(1) R1-NUM-FONE(2) R1-NUM-FONE(3). */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL, LBFPF011.REG_CLIENTES.R1_IDE_SEXO, LBFPF011.REG_CLIENTES.R1_COD_CBO, LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_NUM_FONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_NUM_FONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE);

            /*" -1786- MOVE SPACES TO R1-ORGAO-EXPEDIDOR OF REG-CLIENTES R1-UF-EXPEDIDORA OF REG-CLIENTES R1-NOME-CONJUGE OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR, LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);

            /*" -1789- MOVE ENDERECO-DDD OF DCLENDERECOS TO R1-DDD(2) R1-DDD(3). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_DDD);

            /*" -1792- MOVE ENDERECO-TELEFONE OF DCLENDERECOS TO R1-NUM-FONE(2). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_NUM_FONE);

            /*" -1795- MOVE ENDERECO-FAX OF DCLENDERECOS TO R1-NUM-FONE(3). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_FAX, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE);

            /*" -1796- IF PESEMAIL-CADASTRADO */

            if (W_PESEMAIL["PESEMAIL_CADASTRADO"])
            {

                /*" -1798- MOVE PESSOEMA-EMAIL TO R1-EMAIL OF REG-CLIENTES */
                _.Move(PESSOEMA.DCLPESSOA_EMAIL.PESSOEMA_EMAIL, LBFPF011.REG_CLIENTES.R1_EMAIL);

                /*" -1799- ELSE */
            }
            else
            {


                /*" -1802- MOVE SPACES TO R1-EMAIL OF REG-CLIENTES. */
                _.Move("", LBFPF011.REG_CLIENTES.R1_EMAIL);
            }


            /*" -1803- IF VIND-FAIXA-RENDA-IND NOT LESS ZEROS */

            if (VIND_FAIXA_RENDA_IND >= 00)
            {

                /*" -1806- MOVE PROPOVA-FAIXA-RENDA-IND TO R1-RENDA-INDIVIDUAL OF REG-CLIENTES. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND, LBFPF011.REG_CLIENTES.R1_RENDA_INDIVIDUAL);
            }


            /*" -1807- IF VIND-FAIXA-RENDA-FAM NOT LESS ZEROS */

            if (VIND_FAIXA_RENDA_FAM >= 00)
            {

                /*" -1810- MOVE PROPOVA-FAIXA-RENDA-FAM TO R1-RENDA-FAMILIAR OF REG-CLIENTES. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM, LBFPF011.REG_CLIENTES.R1_RENDA_FAMILIAR);
            }


            /*" -1811- WRITE REG-PRP-SASSE FROM REG-CLIENTES. */
            _.Move(LBFPF011.REG_CLIENTES.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -1811- ADD 1 TO W-QTD-LD-TIPO-1. */
            W_QTD_LD_TIPO_1.Value = W_QTD_LD_TIPO_1 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROPOSTA-REGISTRO-TP3-SECTION */
        private void R0700_00_PROPOSTA_REGISTRO_TP3_SECTION()
        {
            /*" -1823- MOVE SPACES TO REG-PROPOSTA-SASSE. */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE);

            /*" -1826- MOVE '3' TO R3-TIPO-REG OF REG-PROPOSTA-SASSE. */
            _.Move("3", LXFCT004.REG_PROPOSTA_SASSE.R3_TIPO_REG);

            /*" -1829- MOVE VGCOMTRO-NUM-PROPOSTA-SIVPF TO R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA);

            /*" -1832- MOVE 16 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE. */
            _.Move(16, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

            /*" -1835- MOVE TERMOADE-COD-AGENCIA-OP TO R3-AGECOBR OF REG-PROPOSTA-SASSE. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_OP, LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR);

            /*" -1836- MOVE TERMOADE-DATA-ADESAO TO W-DATA-SQL */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO, W_DATA_SQL);

            /*" -1837- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(W_DATA_SQL1.W_DIA_SQL, FILLER_1.W_DIA_TRABALHO);

            /*" -1838- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(W_DATA_SQL1.W_MES_SQL, FILLER_1.W_MES_TRABALHO);

            /*" -1840- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(W_DATA_SQL1.W_ANO_SQL, FILLER_1.W_ANO_TRABALHO);

            /*" -1845- MOVE W-DATA-TRABALHO TO R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA);

            /*" -1848- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 1 OR 2 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2"))
            {

                /*" -1850- MOVE 1 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(1, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -1852- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 3 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == 3)
            {

                /*" -1854- MOVE 2 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(2, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -1856- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 4 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == 4)
            {

                /*" -1858- MOVE 4 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(4, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -1860- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 5 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == 5)
            {

                /*" -1862- MOVE 3 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(3, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -1863- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE EQUAL 1 OR 4 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG.In("1", "4"))
            {

                /*" -1866- MOVE OPCPAGVI-DIA-DEBITO TO R3-DIA-DEBITO OF REG-PROPOSTA-SASSE. */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO);
            }


            /*" -1867- IF VIND-AGECTADEB LESS ZEROS */

            if (VIND_AGECTADEB < 00)
            {

                /*" -1869- MOVE ZEROS TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                /*" -1870- ELSE */
            }
            else
            {


                /*" -1872- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                /*" -1874- END-IF. */
            }


            /*" -1875- IF VIND-OPRCTADEB LESS ZEROS */

            if (VIND_OPRCTADEB < 00)
            {

                /*" -1877- MOVE ZEROS TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);

                /*" -1878- ELSE */
            }
            else
            {


                /*" -1880- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);

                /*" -1882- END-IF. */
            }


            /*" -1883- IF VIND-NUMCTADEB LESS ZEROS */

            if (VIND_NUMCTADEB < 00)
            {

                /*" -1885- MOVE ZEROS TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);

                /*" -1886- ELSE */
            }
            else
            {


                /*" -1888- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);

                /*" -1890- END-IF. */
            }


            /*" -1891- IF VIND-DIGCTADEB LESS ZEROS */

            if (VIND_DIGCTADEB < 00)
            {

                /*" -1893- MOVE ZEROS TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);

                /*" -1894- ELSE */
            }
            else
            {


                /*" -1896- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);

                /*" -1898- END-IF. */
            }


            /*" -1901- MOVE TERMOADE-NUM-MATRICULA-VEN TO R3-NRMATRVEN OF REG-PROPOSTA-SASSE. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN, LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN);

            /*" -1908- MOVE SPACES TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE R3-RENOVACAO-AUTOM OF REG-PROPOSTA-SASSE R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE. */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE, LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ, LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM, LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE);

            /*" -1914- MOVE ZEROS TO R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO);

            /*" -1917- MOVE 'MAN' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move("MAN", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

            /*" -1920- MOVE 'PAG' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE. */
            _.Move("PAG", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

            /*" -1923- MOVE TERMOADE-TIPO-COBERTURA TO R3-COBERTURA OF REG-PROPOSTA-SASSE. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_COBERTURA, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER_R.R3_COBERTURA);

            /*" -1924- IF TERMOADE-COD-PLANO-VGAPC GREATER ZEROS */

            if (TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_VGAPC > 00)
            {

                /*" -1926- MOVE TERMOADE-COD-PLANO-VGAPC TO R3-COD-PLANO OF REG-PROPOSTA-SASSE */
                _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_VGAPC, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

                /*" -1927- ELSE */
            }
            else
            {


                /*" -1928- IF TERMOADE-COD-PLANO-APC GREATER ZEROS */

                if (TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_APC > 00)
                {

                    /*" -1930- MOVE TERMOADE-COD-PLANO-APC TO R3-COD-PLANO OF REG-PROPOSTA-SASSE */
                    _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_APC, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

                    /*" -1931- ELSE */
                }
                else
                {


                    /*" -1934- MOVE ZEROS TO R3-COD-PLANO OF REG-PROPOSTA-SASSE. */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);
                }

            }


            /*" -1937- MOVE RCAPCOMP-DATA-RCAP OF DCLRCAP-COMPLEMENTAR TO W-DATA-SQL. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, W_DATA_SQL);

            /*" -1938- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(W_DATA_SQL1.W_DIA_SQL, FILLER_1.W_DIA_TRABALHO);

            /*" -1939- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(W_DATA_SQL1.W_MES_SQL, FILLER_1.W_MES_TRABALHO);

            /*" -1940- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(W_DATA_SQL1.W_ANO_SQL, FILLER_1.W_ANO_TRABALHO);

            /*" -1943- MOVE W-DATA-TRABALHO TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
            _.Move(W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

            /*" -1947- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE R3-VALOR-PREMIO-TOTAL OF REG-PROPOSTA-SASSE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL);

            /*" -1950- MOVE RCAPS-AGE-COBRANCA OF DCLRCAPS TO R3-AGEPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO);

            /*" -1953- MOVE VAL-TARIFA OF DCLTARIFA-BALCAO-CEF TO R3-VAL-TARIFA OF REG-PROPOSTA-SASSE. */
            _.Move(TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA);

            /*" -1956- MOVE RCAPS-DATA-MOVIMENTO OF DCLRCAPS TO W-DATA-SQL. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO, W_DATA_SQL);

            /*" -1957- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(W_DATA_SQL1.W_DIA_SQL, FILLER_1.W_DIA_TRABALHO);

            /*" -1958- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(W_DATA_SQL1.W_MES_SQL, FILLER_1.W_MES_TRABALHO);

            /*" -1959- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(W_DATA_SQL1.W_ANO_SQL, FILLER_1.W_ANO_TRABALHO);

            /*" -1962- MOVE W-DATA-TRABALHO TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE. */
            _.Move(W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

            /*" -1966- COMPUTE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE = VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA + VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA. */
            LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO.Value = FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG + FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP;

            /*" -1969- MOVE OPCPAGVI-PERI-PAGAMENTO TO R3-PERIPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO, LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO);

            /*" -1972- MOVE RH-NSAS OF REG-HEADER TO R3-NSAS OF REG-PROPOSTA-SASSE. */
            _.Move(LBFPF990.REG_HEADER.RH_NSAS, LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS);

            /*" -1976- MOVE 6 TO R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(6, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC);

            /*" -1977- ADD 1 TO W-QTD-LD-TIPO-3. */
            W_QTD_LD_TIPO_3.Value = W_QTD_LD_TIPO_3 + 1;

            /*" -1980- MOVE W-QTD-LD-TIPO-3 TO R3-NSL OF REG-PROPOSTA-SASSE. */
            _.Move(W_QTD_LD_TIPO_3, LXFCT004.REG_PROPOSTA_SASSE.R3_NSL);

            /*" -1980- WRITE REG-PRP-SASSE FROM REG-PROPOSTA-SASSE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_SAIDA*/

        [StopWatch]
        /*" R1000-00-GERAR-TRAILLER-SECTION */
        private void R1000_00_GERAR_TRAILLER_SECTION()
        {
            /*" -1993- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER. */
            _.Move("T", LBFPF991.REG_TRAILLER.RT_TIPO_REG);

            /*" -1996- MOVE 'PRPSASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER. */
            _.Move("PRPSASSE", LBFPF991.REG_TRAILLER.RT_NOME_EMPRESA);

            /*" -1999- MOVE W-QTD-LD-TIPO-0 TO RT-QTDE-TIPO-0 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_0, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0);

            /*" -2002- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_1, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1);

            /*" -2005- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_2, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2);

            /*" -2008- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_3, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3);

            /*" -2011- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_4, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4);

            /*" -2014- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_5, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5);

            /*" -2017- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_6, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6);

            /*" -2020- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_7, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7);

            /*" -2023- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_8, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8);

            /*" -2026- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_9, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9);

            /*" -2029- MOVE W-QTD-LD-TIPO-A TO RT-QTDE-TIPO-A OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_A, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A);

            /*" -2032- MOVE W-QTD-LD-TIPO-B TO RT-QTDE-TIPO-B OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_B, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B);

            /*" -2035- MOVE W-QTD-LD-TIPO-C TO RT-QTDE-TIPO-C OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_C, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C);

            /*" -2038- MOVE W-QTD-LD-TIPO-D TO RT-QTDE-TIPO-D OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_D, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D);

            /*" -2041- MOVE W-QTD-LD-TIPO-E TO RT-QTDE-TIPO-E OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_E, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E);

            /*" -2044- MOVE W-QTD-LD-TIPO-F TO RT-QTDE-TIPO-F OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_F, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F);

            /*" -2047- MOVE W-QTD-LD-TIPO-G TO RT-QTDE-TIPO-G OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_G, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G);

            /*" -2050- MOVE W-QTD-LD-TIPO-H TO RT-QTDE-TIPO-H OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_H, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H);

            /*" -2053- MOVE W-QTD-LD-TIPO-I TO RT-QTDE-TIPO-I OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_I, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I);

            /*" -2056- MOVE W-QTD-LD-TIPO-J TO RT-QTDE-TIPO-J OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_J, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J);

            /*" -2078- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER EQUAL RT-QTDE-TIPO-0 OF REG-TRAILLER + RT-QTDE-TIPO-1 OF REG-TRAILLER + RT-QTDE-TIPO-2 OF REG-TRAILLER + RT-QTDE-TIPO-3 OF REG-TRAILLER + RT-QTDE-TIPO-4 OF REG-TRAILLER + RT-QTDE-TIPO-5 OF REG-TRAILLER + RT-QTDE-TIPO-6 OF REG-TRAILLER + RT-QTDE-TIPO-7 OF REG-TRAILLER + RT-QTDE-TIPO-8 OF REG-TRAILLER + RT-QTDE-TIPO-9 OF REG-TRAILLER + RT-QTDE-TIPO-A OF REG-TRAILLER + RT-QTDE-TIPO-B OF REG-TRAILLER + RT-QTDE-TIPO-C OF REG-TRAILLER + RT-QTDE-TIPO-D OF REG-TRAILLER + RT-QTDE-TIPO-E OF REG-TRAILLER + RT-QTDE-TIPO-F OF REG-TRAILLER + RT-QTDE-TIPO-G OF REG-TRAILLER + RT-QTDE-TIPO-H OF REG-TRAILLER + RT-QTDE-TIPO-I OF REG-TRAILLER + RT-QTDE-TIPO-J OF REG-TRAILLER. */
            LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL.Value = LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J;

            /*" -2078- WRITE REG-PRP-SASSE FROM REG-TRAILLER. */
            _.Move(LBFPF991.REG_TRAILLER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1100-00-GERAR-TOTAIS-SECTION */
        private void R1100_00_GERAR_TOTAIS_SECTION()
        {
            /*" -2106- COMPUTE W-TOT-GERADO-PRP = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J. */
            W_TOT_GERADO_PRP.Value = W_QTD_LD_TIPO_1 + W_QTD_LD_TIPO_2 + W_QTD_LD_TIPO_3 + W_QTD_LD_TIPO_4 + W_QTD_LD_TIPO_5 + W_QTD_LD_TIPO_6 + W_QTD_LD_TIPO_7 + W_QTD_LD_TIPO_8 + W_QTD_LD_TIPO_9 + W_QTD_LD_TIPO_A + W_QTD_LD_TIPO_B + W_QTD_LD_TIPO_C + W_QTD_LD_TIPO_D + W_QTD_LD_TIPO_E + W_QTD_LD_TIPO_F + W_QTD_LD_TIPO_G + W_QTD_LD_TIPO_H + W_QTD_LD_TIPO_I + W_QTD_LD_TIPO_J;

            /*" -2107- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2108- DISPLAY 'VE0125B - TOTAIS DO PROCESSAMENTO' . */
            _.Display($"VE0125B - TOTAIS DO PROCESSAMENTO");

            /*" -2110- DISPLAY '          DATA ULT VE0125B................. ' W-DATA-ULT-VE0125B */
            _.Display($"          DATA ULT VE0125B................. {W_DATA_ULT_VE0125B}");

            /*" -2112- DISPLAY '          DATA MOV ABERTO.................. ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"          DATA MOV ABERTO.................. {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -2114- DISPLAY '          TOTAL CERTIFICADOS LIDOS......... ' W-LIDOS. */
            _.Display($"          TOTAL CERTIFICADOS LIDOS......... {W_LIDOS}");

            /*" -2116- DISPLAY '          TOTAL CERTIFICADOS DESPREZADOS... ' W-DESPREZADO. */
            _.Display($"          TOTAL CERTIFICADOS DESPREZADOS... {W_DESPREZADO}");

            /*" -2117- COMPUTE W-PROCESSADO = W-LIDOS - W-DESPREZADO */
            W_PROCESSADO.Value = W_LIDOS - W_DESPREZADO;

            /*" -2119- DISPLAY '          TOTAL CERTIFICADOS PROCESSADOS....' W-PROCESSADO. */
            _.Display($"          TOTAL CERTIFICADOS PROCESSADOS....{W_PROCESSADO}");

            /*" -2120- DISPLAY '          TOTAL REGISTROS ARQUIVO PROPOSTA. ' RT-QTDE-TOTAL OF REG-TRAILLER. */
            _.Display($"          TOTAL REGISTROS ARQUIVO PROPOSTA. {LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R1200-00-GRAVA-RELATORIO-SECTION */
        private void R1200_00_GRAVA_RELATORIO_SECTION()
        {
            /*" -2131- IF W-DATA-ULT-VE0125B EQUAL '0001-01-01' */

            if (W_DATA_ULT_VE0125B == "0001-01-01")
            {

                /*" -2132- PERFORM R1300-00-INSERT-RELATORIO */

                R1300_00_INSERT_RELATORIO_SECTION();

                /*" -2133- ELSE */
            }
            else
            {


                /*" -2134- PERFORM R1350-00-UPDATE-RELATORIO */

                R1350_00_UPDATE_RELATORIO_SECTION();

                /*" -2134- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_SAIDA*/

        [StopWatch]
        /*" R1300-00-INSERT-RELATORIO-SECTION */
        private void R1300_00_INSERT_RELATORIO_SECTION()
        {
            /*" -2143- MOVE 'R1300-00-INSERT-RELATORIO' TO PARAGRAFO. */
            _.Move("R1300-00-INSERT-RELATORIO", WABEND2.PARAGRAFO);

            /*" -2145- MOVE 'INSERT RELATORIO' TO COMANDO. */
            _.Move("INSERT RELATORIO", WABEND2.COMANDO);

            /*" -2146- INITIALIZE DCLRELATORIOS */
            _.Initialize(
                RELATORI.DCLRELATORIOS
            );

            /*" -2147- MOVE 'VE0125B' TO RELATORI-COD-USUARIO. */
            _.Move("VE0125B", RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);

            /*" -2151- MOVE SISTEMAS-DATA-MOV-ABERTO TO RELATORI-DATA-SOLICITACAO RELATORI-DATA-REFERENCIA RELATORI-PERI-INICIAL RELATORI-PERI-FINAL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);

            /*" -2152- MOVE 'VE' TO RELATORI-IDE-SISTEMA. */
            _.Move("VE", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -2153- MOVE 'VE0125B' TO RELATORI-COD-RELATORIO. */
            _.Move("VE0125B", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -2154- MOVE 0 TO RELATORI-NUM-COPIAS */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

            /*" -2156- MOVE '1' TO RELATORI-SIT-REGISTRO. */
            _.Move("1", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -2244- PERFORM R1300_00_INSERT_RELATORIO_DB_INSERT_1 */

            R1300_00_INSERT_RELATORIO_DB_INSERT_1();

            /*" -2247- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2248- DISPLAY 'VE0125B - ERRO INSERT RELATORIOS' */
                _.Display($"VE0125B - ERRO INSERT RELATORIOS");

                /*" -2249- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2249- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-INSERT-RELATORIO-DB-INSERT-1 */
        public void R1300_00_INSERT_RELATORIO_DB_INSERT_1()
        {
            /*" -2244- EXEC SQL INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO_EMISSOR , COD_FONTE , COD_PRODUTOR , RAMO_EMISSOR , COD_MODALIDADE , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_CERTIFICADO , NUM_TITULO , COD_SUBGRUPO , COD_OPERACAO , COD_PLANO , OCORR_HISTORICO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , COD_MOEDA , TIPO_CORRECAO , SIT_REGISTRO , IND_PREV_DEFINIT , IND_ANAL_RESUMO , COD_EMPRESA , PERI_RENOVACAO , PCT_AUMENTO , TIMESTAMP ) VALUES ( :RELATORI-COD-USUARIO ,:RELATORI-DATA-SOLICITACAO ,:RELATORI-IDE-SISTEMA ,:RELATORI-COD-RELATORIO ,:RELATORI-NUM-COPIAS ,:RELATORI-QUANTIDADE ,:RELATORI-PERI-INICIAL ,:RELATORI-PERI-FINAL ,:RELATORI-DATA-REFERENCIA ,:RELATORI-MES-REFERENCIA ,:RELATORI-ANO-REFERENCIA ,:RELATORI-ORGAO-EMISSOR ,:RELATORI-COD-FONTE ,:RELATORI-COD-PRODUTOR ,:RELATORI-RAMO-EMISSOR ,:RELATORI-COD-MODALIDADE ,:RELATORI-COD-CONGENERE ,:RELATORI-NUM-APOLICE ,:RELATORI-NUM-ENDOSSO ,:RELATORI-NUM-PARCELA ,:RELATORI-NUM-CERTIFICADO ,:RELATORI-NUM-TITULO ,:RELATORI-COD-SUBGRUPO ,:RELATORI-COD-OPERACAO ,:RELATORI-COD-PLANO ,:RELATORI-OCORR-HISTORICO ,:RELATORI-NUM-APOL-LIDER ,:RELATORI-ENDOS-LIDER ,:RELATORI-NUM-PARC-LIDER ,:RELATORI-NUM-SINISTRO ,:RELATORI-NUM-SINI-LIDER ,:RELATORI-NUM-ORDEM ,:RELATORI-COD-MOEDA ,:RELATORI-TIPO-CORRECAO ,:RELATORI-SIT-REGISTRO ,:RELATORI-IND-PREV-DEFINIT ,:RELATORI-IND-ANAL-RESUMO ,:RELATORI-COD-EMPRESA ,:RELATORI-PERI-RENOVACAO ,:RELATORI-PCT-AUMENTO , CURRENT TIMESTAMP ) END-EXEC. */

            var r1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1 = new R1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_NUM_COPIAS = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.ToString(),
                RELATORI_QUANTIDADE = RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE.ToString(),
                RELATORI_PERI_INICIAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.ToString(),
                RELATORI_PERI_FINAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.ToString(),
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
                RELATORI_MES_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA.ToString(),
                RELATORI_ANO_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA.ToString(),
                RELATORI_ORGAO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR.ToString(),
                RELATORI_COD_FONTE = RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE.ToString(),
                RELATORI_COD_PRODUTOR = RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR.ToString(),
                RELATORI_RAMO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR.ToString(),
                RELATORI_COD_MODALIDADE = RELATORI.DCLRELATORIOS.RELATORI_COD_MODALIDADE.ToString(),
                RELATORI_COD_CONGENERE = RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
                RELATORI_COD_PLANO = RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO.ToString(),
                RELATORI_OCORR_HISTORICO = RELATORI.DCLRELATORIOS.RELATORI_OCORR_HISTORICO.ToString(),
                RELATORI_NUM_APOL_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.ToString(),
                RELATORI_ENDOS_LIDER = RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER.ToString(),
                RELATORI_NUM_PARC_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARC_LIDER.ToString(),
                RELATORI_NUM_SINISTRO = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO.ToString(),
                RELATORI_NUM_SINI_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER.ToString(),
                RELATORI_NUM_ORDEM = RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM.ToString(),
                RELATORI_COD_MOEDA = RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA.ToString(),
                RELATORI_TIPO_CORRECAO = RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO.ToString(),
                RELATORI_SIT_REGISTRO = RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO.ToString(),
                RELATORI_IND_PREV_DEFINIT = RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT.ToString(),
                RELATORI_IND_ANAL_RESUMO = RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO.ToString(),
                RELATORI_COD_EMPRESA = RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA.ToString(),
                RELATORI_PERI_RENOVACAO = RELATORI.DCLRELATORIOS.RELATORI_PERI_RENOVACAO.ToString(),
                RELATORI_PCT_AUMENTO = RELATORI.DCLRELATORIOS.RELATORI_PCT_AUMENTO.ToString(),
            };

            R1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1.Execute(r1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_SAIDA*/

        [StopWatch]
        /*" R1350-00-UPDATE-RELATORIO-SECTION */
        private void R1350_00_UPDATE_RELATORIO_SECTION()
        {
            /*" -2258- MOVE 'R1350-00-UPDATE-RELATORIO' TO PARAGRAFO. */
            _.Move("R1350-00-UPDATE-RELATORIO", WABEND2.PARAGRAFO);

            /*" -2260- MOVE 'UPDATE RELATORIO' TO COMANDO. */
            _.Move("UPDATE RELATORIO", WABEND2.COMANDO);

            /*" -2262- PERFORM R0010-00-BUSCA-ULT-VE0125B */

            R0010_00_BUSCA_ULT_VE0125B_SECTION();

            /*" -2271- PERFORM R1350_00_UPDATE_RELATORIO_DB_UPDATE_1 */

            R1350_00_UPDATE_RELATORIO_DB_UPDATE_1();

            /*" -2274- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2275- DISPLAY 'VE0125B - ERRO UPDATE RELATORIOS' */
                _.Display($"VE0125B - ERRO UPDATE RELATORIOS");

                /*" -2276- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2277- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2277- END-IF. */
            }


        }

        [StopWatch]
        /*" R1350-00-UPDATE-RELATORIO-DB-UPDATE-1 */
        public void R1350_00_UPDATE_RELATORIO_DB_UPDATE_1()
        {
            /*" -2271- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO ,DATA_REFERENCIA = :SISTEMAS-DATA-MOV-ABERTO ,PERI_INICIAL = :SISTEMAS-DATA-MOV-ABERTO ,PERI_FINAL = :SISTEMAS-DATA-MOV-ABERTO ,TIMESTAMP = CURRENT TIMESTAMP WHERE COD_USUARIO = :RELATORI-COD-USUARIO AND IDE_SISTEMA = :RELATORI-IDE-SISTEMA END-EXEC. */

            var r1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1 = new R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
            };

            R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1.Execute(r1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_SAIDA*/

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-SECTION */
        private void R6000_00_DECLARE_AGENCEF_SECTION()
        {
            /*" -2286- MOVE 'R6000-DECLA-AGENCEF' TO PARAGRAFO. */
            _.Move("R6000-DECLA-AGENCEF", WABEND2.PARAGRAFO);

            /*" -2288- MOVE 'DECLARE AGENCIACEF ' TO COMANDO. */
            _.Move("DECLARE AGENCIACEF ", WABEND2.COMANDO);

            /*" -2298- PERFORM R6000_00_DECLARE_AGENCEF_DB_DECLARE_1 */

            R6000_00_DECLARE_AGENCEF_DB_DECLARE_1();

            /*" -2301- MOVE 'OPEN AGENCIACEF ' TO COMANDO. */
            _.Move("OPEN AGENCIACEF ", WABEND2.COMANDO);

            /*" -2301- PERFORM R6000_00_DECLARE_AGENCEF_DB_OPEN_1 */

            R6000_00_DECLARE_AGENCEF_DB_OPEN_1();

            /*" -2304- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2305- DISPLAY 'VE0125B - ERRO OPEN CURSOR AGENCEF' */
                _.Display($"VE0125B - ERRO OPEN CURSOR AGENCEF");

                /*" -2306- MOVE 'OPEN CURSOR AGENCEF' TO COMANDO */
                _.Move("OPEN CURSOR AGENCEF", WABEND2.COMANDO);

                /*" -2306- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-OPEN-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_OPEN_1()
        {
            /*" -2301- EXEC SQL OPEN C01_AGENCEF END-EXEC. */

            C01_AGENCEF.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-SECTION */
        private void R6010_00_FETCH_AGENCEF_SECTION()
        {
            /*" -2315- MOVE 'R6010-FETCH-AGENCEF' TO PARAGRAFO. */
            _.Move("R6010-FETCH-AGENCEF", WABEND2.PARAGRAFO);

            /*" -2317- MOVE 'FETCH   AGENCIACEF ' TO COMANDO. */
            _.Move("FETCH   AGENCIACEF ", WABEND2.COMANDO);

            /*" -2321- PERFORM R6010_00_FETCH_AGENCEF_DB_FETCH_1 */

            R6010_00_FETCH_AGENCEF_DB_FETCH_1();

            /*" -2324- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2325- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2326- MOVE 'S' TO WFIM-AGENCEF */
                    _.Move("S", WFIM_AGENCEF);

                    /*" -2326- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_1 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_1();

                    /*" -2328- ELSE */
                }
                else
                {


                    /*" -2329- DISPLAY 'VE0125B - ERRO FETCH AGENCEF' */
                    _.Display($"VE0125B - ERRO FETCH AGENCEF");

                    /*" -2330- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -2331- END-IF */
                }


                /*" -2331- END-IF. */
            }


        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-FETCH-1 */
        public void R6010_00_FETCH_AGENCEF_DB_FETCH_1()
        {
            /*" -2321- EXEC SQL FETCH C01_AGENCEF INTO :DCLAGENCIAS-CEF.COD-AGENCIA ,:DCLMALHA-CEF.MALHACEF-COD-FONTE END-EXEC. */

            if (C01_AGENCEF.Fetch())
            {
                _.Move(C01_AGENCEF.DCLAGENCIAS_CEF_COD_AGENCIA, AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA);
                _.Move(C01_AGENCEF.DCLMALHA_CEF_MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }

        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-CLOSE-1 */
        public void R6010_00_FETCH_AGENCEF_DB_CLOSE_1()
        {
            /*" -2326- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_SAIDA*/

        [StopWatch]
        /*" R6020-00-CARREGA-FILIAL-SECTION */
        private void R6020_00_CARREGA_FILIAL_SECTION()
        {
            /*" -2342- MOVE COD-AGENCIA OF DCLAGENCIAS-CEF TO TAB-AGENCIA (COD-AGENCIA OF DCLAGENCIAS-CEF) */
            _.Move(AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA, TAB_FILIAIS.FILLER_0[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_AGENCIA);

            /*" -2345- MOVE MALHACEF-COD-FONTE OF DCLMALHA-CEF TO TAB-FONTE (COD-AGENCIA OF DCLAGENCIAS-CEF) */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TAB_FILIAIS.FILLER_0[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_FONTE);

            /*" -2345- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6020_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -2353- CLOSE MOVTO-PRP-SASSE. */
            MOVTO_PRP_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -2362- IF W-FIM-MOVIMENTO EQUAL 'FIM' */

            if (W_FIM_MOVIMENTO == "FIM")
            {

                /*" -2363- DISPLAY 'VE0125B - FIM NORMAL' */
                _.Display($"VE0125B - FIM NORMAL");

                /*" -2364- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -2364- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -2366- ELSE */
            }
            else
            {


                /*" -2367- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND1.WSQLCODE);

                /*" -2368- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND1.WSQLERRD1);

                /*" -2369- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND1.WSQLERRD2);

                /*" -2370- DISPLAY WABEND1 */
                _.Display(WABEND1);

                /*" -2371- DISPLAY WABEND2 */
                _.Display(WABEND2);

                /*" -2372- DISPLAY 'VE0125B - ROLLBACK EM ANDAMENTO' */
                _.Display($"VE0125B - ROLLBACK EM ANDAMENTO");

                /*" -2372- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -2374- DISPLAY ' ' */
                _.Display($" ");

                /*" -2375- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -2377- END-IF. */
            }


            /*" -2385- DISPLAY 'VE0125B - TERMINO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"VE0125B - TERMINO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -2385- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}