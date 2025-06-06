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
using Sias.PessoaFisica.DB2.PF0623B;

namespace Code
{
    public class PF0623B
    {
        public bool IsCall { get; set; }

        public PF0623B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *************************                                               */
        /*"      ******************************************************************      */
        /*"      *   FUNCAO ...............  GERA ESTOQUE DO VIDA EMPRESARIAL AO  *      */
        /*"      *                           SIGPF.                               *      */
        /*"      *   ANALISTA RESPONSAVEL..  LUIZ CARLOS.                         *      */
        /*"      *   REVISAO PROGRAMACAO...  REGINALDO SILVA                      *      */
        /*"      *   PROGRAMA .............  PF0623B                              *      */
        /*"      *   DATA .................  20/12/2001.                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 08             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      *                       IND_TP_CONTA NA TABELA PROPOSTA_FIDELIZ. *      */
        /*"      * ATENDE DEMANDA 175.167                                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.08          MARCUS VALERIO                           *      */
        /*"      *                       05/02/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 07             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      * ATENDE CADMUS 140.553 IND_TP_PROPOSTA NA TABELA                *      */
        /*"      *                       PROPOSTA_FIDELIZ.                        *      */
        /*"      * PROCURE V.07          FRANK CARVALHO                           *      */
        /*"      *                       08/08/2016                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 06             AJUSTAR SELECT NA TAB DE PRODUTOS_SIVPF  *      */
        /*"      * ATENDE CADMUS 109986  ACRESCENTANDO O COD_EMPRESA              *      */
        /*"      *                                                                *      */
        /*"      * PROCURE DIRSA         REGINALDO SILVA                          *      */
        /*"      *                       28/07/2015                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 05             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       24/10/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 04             AJUSTE NA ROTINA R6000                   *      */
        /*"      * ATENDE CADMUS 112140                                           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.04          REGINALDO SILVA                          *      */
        /*"      *                       10/03/2015                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 03             AJUSTE PERIODICIDADE DE PAGAMENTO        *      */
        /*"      * ATENDE CADMUS 93600   PERI-PAGAMENTO E R3-PERIPGTO             *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.03          REGINALDO SILVA                          *      */
        /*"      *                       10/04/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 02             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA / SERGIO LORETO          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 01             AJUSTE NOS SELECTS V10                   *      */
        /*"      * ATENDE CADMUS 84809   DB2.V10  SELECTS                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE DB2           REGINALDO SILVA                          *      */
        /*"      *                       10/09/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     ******************************************************************      */
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
        public FileBasis _MOVTO_STA_SASSE { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOVTO_STA_SASSE
        {
            get
            {
                _.Move(REG_STA_SASSE, _MOVTO_STA_SASSE); VarBasis.RedefinePassValue(REG_STA_SASSE, _MOVTO_STA_SASSE, REG_STA_SASSE); return _MOVTO_STA_SASSE;
            }
        }
        /*"01   REG-PRP-SASSE                      PIC X(300).*/
        public StringBasis REG_PRP_SASSE { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01   REG-STA-SASSE                      PIC X(100).*/
        public StringBasis REG_STA_SASSE { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WHOST-DATA-REFERENCIA            PIC X(010).*/
        public StringBasis WHOST_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-NUM-TERMO                  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis WHOST_NUM_TERMO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01  VIND-RCAP                         PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASCI                      PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DTNASCI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-VAL-IOCC                     PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_VAL_IOCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-VAL-RCAP                     PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_VAL_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DATA-RCAP                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DATA_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-AGE-COBRANCA                 PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-AGECTADEB                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-OPRCTADEB                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUMCTADEB                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DIGCTADEB                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-VAL-PREMIO                   PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_VAL_PREMIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-FAIXA-RENDA-IND              PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-FAIXA-RENDA-FAM              PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASC-ESPOSA                PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DTNASC_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  TAB-FILIAIS.*/
        public PF0623B_TAB_FILIAIS TAB_FILIAIS { get; set; } = new PF0623B_TAB_FILIAIS();
        public class PF0623B_TAB_FILIAIS : VarBasis
        {
            /*"   05      TAB-FILIAL.*/
            public PF0623B_TAB_FILIAL TAB_FILIAL { get; set; } = new PF0623B_TAB_FILIAL();
            public class PF0623B_TAB_FILIAL : VarBasis
            {
                /*"     10    FILLER    OCCURS    9999   TIMES.*/
                public ListBasis<PF0623B_FILLER_0> FILLER_0 { get; set; } = new ListBasis<PF0623B_FILLER_0>(9999);
                public class PF0623B_FILLER_0 : VarBasis
                {
                    /*"       15  TAB-AGENCIA              PIC  9(4).*/
                    public IntBasis TAB_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"       15  TAB-FONTE                PIC  9(4).*/
                    public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"01  WAREA-AUXILIAR.*/
                }
            }
        }
        public PF0623B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0623B_WAREA_AUXILIAR();
        public class PF0623B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-MOVTO-TERMO             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_TERMO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-EMAIL            PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-ENDERECO         PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  WFIM-AGENCEF                  PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05  W-TOT-PROCESSADO              PIC 9(006)  VALUE ZEROS.*/
            public IntBasis W_TOT_PROCESSADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-AC-CONTROLE                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
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
            /*"    05  W-TOT-GERADO-PRP              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_TOT_GERADO_PRP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-SEQ-FONE                    PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_FONE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-SEQ-EMAIL                   PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_EMAIL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-COD-PESSOA                  PIC 9(009)  VALUE ZEROS.*/
            public IntBasis W_COD_PESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05  W-COD-RELACION                PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_COD_RELACION { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-ACHOU-EMAIL                 PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-TELEFONE              PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_TELEFONE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-ENDERECO              PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-RELACIONAMENTO        PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_RELACIONAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-OCORR-ENDERECO              PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-OBTER-MAX-RELAC             PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_OBTER_MAX_RELAC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-OBTER-MAX-PESSOA            PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_OBTER_MAX_PESSOA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-NUM-IDENTIF                 PIC 9(015)  VALUE ZEROS.*/
            public IntBasis W_NUM_IDENTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05  W-NSAS                        PIC 9(006).*/
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSL                         PIC 9(008).*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  W-CONTROLE                    PIC 9(006).*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-CONTROLE-TP-0               PIC 9(001)  VALUE ZERO.*/
            public IntBasis W_CONTROLE_TP_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0623B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0623B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0623B_FILLER_1(); _.Move(W_DATA_TRABALHO, _filler_1); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_1, W_DATA_TRABALHO); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_DATA_TRABALHO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0623B_FILLER_1 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-NASCIMENTO             PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_PF0623B_FILLER_1()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-NASCIMENTO.*/
            private _REDEF_PF0623B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0623B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0623B_FILLER_2(); _.Move(W_DATA_NASCIMENTO, _filler_2); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _filler_2, W_DATA_NASCIMENTO); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_DATA_NASCIMENTO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_DATA_NASCIMENTO); }
            }  //Redefines
            public class _REDEF_PF0623B_FILLER_2 : VarBasis
            {
                /*"        07  W-DIA-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-NASCIMENTO          PIC 9(004).*/
                public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-COD-COBERTURA               PIC 9(004)  VALUE ZEROS.*/

                public _REDEF_PF0623B_FILLER_2()
                {
                    W_DIA_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_MES_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_ANO_NASCIMENTO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER REDEFINES W-COD-COBERTURA.*/
            private _REDEF_PF0623B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0623B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0623B_FILLER_3(); _.Move(W_COD_COBERTURA, _filler_3); VarBasis.RedefinePassValue(W_COD_COBERTURA, _filler_3, W_COD_COBERTURA); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_COD_COBERTURA); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_COD_COBERTURA); }
            }  //Redefines
            public class _REDEF_PF0623B_FILLER_3 : VarBasis
            {
                /*"        10  W-SUBPRODUTO              PIC 9(003).*/
                public IntBasis W_SUBPRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        10  W-COBERTURA               PIC 9(001).*/
                public IntBasis W_COBERTURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0623B_FILLER_3()
                {
                    W_SUBPRODUTO.ValueChanged += OnValueChanged;
                    W_COBERTURA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0623B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0623B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0623B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0623B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0623B_W_DTMOVABE1()
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
            private _REDEF_PF0623B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0623B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0623B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0623B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0623B_W_DTMOVABE_I1()
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
            private _REDEF_PF0623B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0623B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0623B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0623B_W_DATA_SQL1 : VarBasis
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

                public _REDEF_PF0623B_W_DATA_SQL1()
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
            private _REDEF_PF0623B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PF0623B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PF0623B_FILLER_4(); _.Move(W_NR_SICOB, _filler_4); VarBasis.RedefinePassValue(W_NR_SICOB, _filler_4, W_NR_SICOB); _filler_4.ValueChanged += () => { _.Move(_filler_4, W_NR_SICOB); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, W_NR_SICOB); }
            }  //Redefines
            public class _REDEF_PF0623B_FILLER_4 : VarBasis
            {
                /*"        07  W-NR-PROD-SICOB           PIC 9(003).*/
                public IntBasis W_NR_PROD_SICOB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  W-NR-NSAC-SICOB           PIC 9(006).*/
                public IntBasis W_NR_NSAC_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        07  W-NR-NSL-SICOB            PIC 9(006).*/
                public IntBasis W_NR_NSL_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/

                public _REDEF_PF0623B_FILLER_4()
                {
                    W_NR_PROD_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSAC_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSL_SICOB.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_PF0623B_CANAL _canal { get; set; }
            public _REDEF_PF0623B_CANAL CANAL
            {
                get { _canal = new _REDEF_PF0623B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0623B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                  VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                    VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL                 VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR                     VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO                      VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-GITEL                        VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET                     VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7"),
							/*" 88 CANAL-INTRANET                     VALUE 8. */
							new SelectorItemBasis("CANAL_INTRANET", "8")
                }
                };

                /*"        07  FILLER                    PIC X(013).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05  FAIXAS  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_PF0623B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF0623B_FAIXAS _faixas { get; set; }
            public _REDEF_PF0623B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_PF0623B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0623B_FAIXAS : VarBasis
            {
                /*"        07  FILLER                    PIC 9(003).*/
                public IntBasis FILLER_6 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  FAIXA-NUMERACAO           PIC 9(003).*/

                public SelectorBasis FAIXA_NUMERACAO { get; set; } = new SelectorBasis("003")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 FAIXA-NUMERACAO-MULT-SUPER VALUE               845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT_SUPER", "845,846"),
							/*" 88 FAIXA-NUMERACAO-MULT       VALUE               848, 850. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT", "848,850"),
							/*" 88 FAIXA-NUMERACAO-BILHETE    VALUE               823, 824, 826, 827, 829, 837, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_BILHETE", "823,824,826,827,829,837,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-SENIOR     VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_SENIOR", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-EXECUTIVO  VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_EXECUTIVO", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-AUTO       VALUE               828, 837, 847, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_AUTO", "828,837,847,845,846")
                }
                };

                /*"        07  FILLER                    PIC 9(008).*/
                public IntBasis FILLER_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05 W-LER-CLIENTE                  PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0623B_FAIXAS()
                {
                    FILLER_6.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_LER_CLIENTE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-CLIENTE                          VALUE 1. */
							new SelectorItemBasis("EXISTE_CLIENTE", "1")
                }
            };

            /*"    05 W-COD-EMPRESA                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_COD_EMPRESA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SASSE                                   VALUE 1. */
							new SelectorItemBasis("SASSE", "1"),
							/*" 88 FEDERALPREV                             VALUE 2. */
							new SelectorItemBasis("FEDERALPREV", "2"),
							/*" 88 FEDERALCAP                              VALUE 3. */
							new SelectorItemBasis("FEDERALCAP", "3")
                }
            };

            /*"    05 W-RELACIONAMENTO               PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_RELACIONAMENTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SEGURO-VIDA                             VALUE 1. */
							new SelectorItemBasis("SEGURO_VIDA", "1"),
							/*" 88 CAPITALIZACAO                           VALUE 2. */
							new SelectorItemBasis("CAPITALIZACAO", "2"),
							/*" 88 PREVIDENCIA                             VALUE 3. */
							new SelectorItemBasis("PREVIDENCIA", "3"),
							/*" 88 BILHETE                                 VALUE 4. */
							new SelectorItemBasis("BILHETE", "4")
                }
            };

            /*"    05 W-CURSOR                       PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CURSOR { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CURSOR-MONTADO                          VALUE 1. */
							new SelectorItemBasis("CURSOR_MONTADO", "1"),
							/*" 88 CURSOR-N-MONTADO                        VALUE 2. */
							new SelectorItemBasis("CURSOR_N_MONTADO", "2")
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

            /*"    05 W-RCAPCOMP                     PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_RCAPCOMP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAPCOMP-CADASTRADO                     VALUE 1. */
							new SelectorItemBasis("RCAPCOMP_CADASTRADO", "1"),
							/*" 88 RCAPCOMP-N-CADASTRADO                   VALUE 2. */
							new SelectorItemBasis("RCAPCOMP_N_CADASTRADO", "2")
                }
            };

            /*"    05 W-CLIENTE                      PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CLIENTE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CLIENTE-CADASTRADO                      VALUE 1. */
							new SelectorItemBasis("CLIENTE_CADASTRADO", "1"),
							/*" 88 CLIENTE-NAO-CADASTRADO                  VALUE 2. */
							new SelectorItemBasis("CLIENTE_NAO_CADASTRADO", "2")
                }
            };

            /*"    05 W-ENDERECO                     PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_ENDERECO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ENDERECO-CADASTRADO                      VALUE 1. */
							new SelectorItemBasis("ENDERECO_CADASTRADO", "1"),
							/*" 88 ENDERECO-NAO-CADASTRADO                  VALUE 2. */
							new SelectorItemBasis("ENDERECO_NAO_CADASTRADO", "2")
                }
            };

            /*"    05 W-SUBGRUPO                     PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_SUBGRUPO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SUBGRUPO-CADASTRADO                      VALUE 1. */
							new SelectorItemBasis("SUBGRUPO_CADASTRADO", "1"),
							/*" 88 SUBGRUPO-NAO-CADASTRADO                  VALUE 2. */
							new SelectorItemBasis("SUBGRUPO_NAO_CADASTRADO", "2")
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

            /*"    05 W-OPCAOPAG                     PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_OPCAOPAG { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 OPCAO-PAG-CADASTRADA                    VALUE 1. */
							new SelectorItemBasis("OPCAO_PAG_CADASTRADA", "1"),
							/*" 88 OPCAO-PAG-NAO-CADASTRADA                VALUE 2. */
							new SelectorItemBasis("OPCAO_PAG_NAO_CADASTRADA", "2")
                }
            };

            /*"01  WABEND*/
        }
        public PF0623B_WABEND WABEND { get; set; } = new PF0623B_WABEND();
        public class PF0623B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0623B_FILLER_8 FILLER_8 { get; set; } = new PF0623B_FILLER_8();
            public class PF0623B_FILLER_8 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0623B  '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0623B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public PF0623B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0623B_LOCALIZA_ABEND_1();
            public class PF0623B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0623B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0623B_LOCALIZA_ABEND_2();
            public class PF0623B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Copies.LXFPF990 LXFPF990 { get; set; } = new Copies.LXFPF990();
        public Copies.LBFPF011 LBFPF011 { get; set; } = new Copies.LBFPF011();
        public Copies.LBFPF012 LBFPF012 { get; set; } = new Copies.LBFPF012();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.LXFPF004 LXFPF004 { get; set; } = new Copies.LXFPF004();
        public Copies.LBFPF100 LBFPF100 { get; set; } = new Copies.LBFPF100();
        public Copies.LBFPF991 LBFPF991 { get; set; } = new Copies.LBFPF991();
        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Copies.LBFPF200 LBFPF200 { get; set; } = new Copies.LBFPF200();
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.FDCOMVA FDCOMVA { get; set; } = new Dclgens.FDCOMVA();
        public Dclgens.TERMOADE TERMOADE { get; set; } = new Dclgens.TERMOADE();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PESJUR PESJUR { get; set; } = new Dclgens.PESJUR();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.TPENDER TPENDER { get; set; } = new Dclgens.TPENDER();
        public Dclgens.PESENDER PESENDER { get; set; } = new Dclgens.PESENDER();
        public Dclgens.RTPRELAC RTPRELAC { get; set; } = new Dclgens.RTPRELAC();
        public Dclgens.IDERELAC IDERELAC { get; set; } = new Dclgens.IDERELAC();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public Dclgens.COVSIVPF COVSIVPF { get; set; } = new Dclgens.COVSIVPF();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.CLIENTE CLIENTE { get; set; } = new Dclgens.CLIENTE();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public PF0623B_TERMO_ADESAO TERMO_ADESAO { get; set; } = new PF0623B_TERMO_ADESAO();
        public PF0623B_C01_RCAPCOMP C01_RCAPCOMP { get; set; } = new PF0623B_C01_RCAPCOMP();
        public PF0623B_COBERTURAS COBERTURAS { get; set; } = new PF0623B_COBERTURAS();
        public PF0623B_FUNDOCOMISVA FUNDOCOMISVA { get; set; } = new PF0623B_FUNDOCOMISVA();
        public PF0623B_EMAIL EMAIL { get; set; } = new PF0623B_EMAIL();
        public PF0623B_ENDERECOS ENDERECOS { get; set; } = new PF0623B_ENDERECOS();
        public PF0623B_C01_AGENCEF C01_AGENCEF { get; set; } = new PF0623B_C01_AGENCEF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_PRP_SASSE_FILE_NAME_P, string MOVTO_STA_SASSE_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO_PRP_SASSE.SetFile(MOVTO_PRP_SASSE_FILE_NAME_P);
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
            /*" -534- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -535- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -536- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -539- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -540- DISPLAY '*               PROGRAMA PF0623B               *' . */
            _.Display($"*               PROGRAMA PF0623B               *");

            /*" -541- DISPLAY '* GERA ARQUIVO ESTOQUE DO VIDA EMPRES AO SIGPF *' . */
            _.Display($"* GERA ARQUIVO ESTOQUE DO VIDA EMPRES AO SIGPF *");

            /*" -542- DISPLAY '*           VERSAO:  08 - 05/02/2019           *' . */
            _.Display($"*           VERSAO:  08 - 05/02/2019           *");

            /*" -543- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -552- DISPLAY '*  PF0623B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0623B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -554- PERFORM R0001-00-INICIALIZAR. */

            R0001_00_INICIALIZAR_SECTION();

            /*" -556- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -558- PERFORM R0007-00-OBTER-DT-PROCE. */

            R0007_00_OBTER_DT_PROCE_SECTION();

            /*" -560- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -562- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -564- MOVE 1 TO W-CURSOR. */
            _.Move(1, WAREA_AUXILIAR.W_CURSOR);

            /*" -566- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -568- PERFORM R0070-00-LER-MOVTO */

            R0070_00_LER_MOVTO_SECTION();

            /*" -570- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -572- PERFORM R0085-00-LER-PRODUTOS-SIVPF. */

            R0085_00_LER_PRODUTOS_SIVPF_SECTION();

            /*" -575- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-TERMO EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -577- PERFORM R1000-00-GERAR-TRAILLER. */

            R1000_00_GERAR_TRAILLER_SECTION();

            /*" -579- PERFORM R1050-00-CONTROLAR-ARQ-ENVIADO */

            R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -581- PERFORM R1100-00-GERAR-TOTAIS. */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -583- PERFORM R1110-00-UPDATE-RELATORIOS. */

            R1110_00_UPDATE_RELATORIOS_SECTION();

            /*" -585- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -585- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0001-00-INICIALIZAR-SECTION */
        private void R0001_00_INICIALIZAR_SECTION()
        {
            /*" -593- MOVE 'R0001-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0001-00-INICIALIZAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -595- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -597- INITIALIZE REG-TRAILLER, REG-TRAILLER-STA. */
            _.Initialize(
                LBFPF991.REG_TRAILLER
                , LBFCT011.REG_TRAILLER_STA
            );

            /*" -599- MOVE ZEROS TO TAB-FILIAIS. */
            _.Move(0, TAB_FILIAIS);

            /*" -601- PERFORM R6000-00-DECLARE-AGENCEF. */

            R6000_00_DECLARE_AGENCEF_SECTION();

            /*" -603- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

            /*" -604- IF WFIM-AGENCEF NOT EQUAL SPACES */

            if (!WAREA_AUXILIAR.WFIM_AGENCEF.IsEmpty())
            {

                /*" -605- DISPLAY '0000 - PROBLEMA NO FETCH DA AGENCIACEF' */
                _.Display($"0000 - PROBLEMA NO FETCH DA AGENCIACEF");

                /*" -607- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -608- PERFORM R6020-00-CARREGA-FILIAL UNTIL WFIM-AGENCEF EQUAL 'S' . */

            while (!(WAREA_AUXILIAR.WFIM_AGENCEF == "S"))
            {

                R6020_00_CARREGA_FILIAL_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_SAIDA*/

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -618- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -620- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -622- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -630- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -635- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -637- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -639- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -642- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -644- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -630- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :WHOST-DATA-REFERENCIA FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
        /*" R0007-00-OBTER-DT-PROCE-SECTION */
        private void R0007_00_OBTER_DT_PROCE_SECTION()
        {
            /*" -654- MOVE 'R0007-00-OBTER-DT-PROCE' TO PARAGRAFO. */
            _.Move("R0007-00-OBTER-DT-PROCE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -656- MOVE 'SELECT SEGUROS.RELATORIOS' TO COMANDO. */
            _.Move("SELECT SEGUROS.RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -663- PERFORM R0007_00_OBTER_DT_PROCE_DB_SELECT_1 */

            R0007_00_OBTER_DT_PROCE_DB_SELECT_1();

            /*" -666- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -667- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -668- DISPLAY '          ERRO SELECT RELATORIOS' */
                _.Display($"          ERRO SELECT RELATORIOS");

                /*" -670- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -670- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0007-00-OBTER-DT-PROCE-DB-SELECT-1 */
        public void R0007_00_OBTER_DT_PROCE_DB_SELECT_1()
        {
            /*" -663- EXEC SQL SELECT DATA_REFERENCIA INTO :DCLRELATORIOS.RELATORI-DATA-REFERENCIA FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0623B' WITH UR END-EXEC. */

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
            /*" -683- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -685- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -686- OPEN OUTPUT MOVTO-PRP-SASSE, MOVTO-STA-SASSE. */
            MOVTO_PRP_SASSE.Open(REG_PRP_SASSE);
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -696- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -698- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -700- MOVE SPACES TO REG-HEADER, REG-HEADER-STA. */
            _.Move("", LXFPF990.REG_HEADER, LBFCT011.REG_HEADER_STA);

            /*" -703- MOVE 'PRPSASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("PRPSASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -706- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -715- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -718- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -719- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -720- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -722- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -723- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -725- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -728- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -730- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -735- MOVE W-NSAS TO RH-NSAS OF REG-HEADER. */
            _.Move(WAREA_AUXILIAR.W_NSAS, LXFPF990.REG_HEADER.RH_NSAS);

            /*" -738- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -742- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -751- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_2 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_2();

            /*" -754- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -755- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -756- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -758- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -759- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -761- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -764- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -766- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -766- MOVE W-NSAS TO RH-NSAS OF REG-HEADER-STA. */
            _.Move(WAREA_AUXILIAR.W_NSAS, LBFCT011.REG_HEADER_STA.RH_NSAS);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -715- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

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
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-2 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_2()
        {
            /*" -751- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

            var r0020_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1 = new R0020_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0020_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1.Execute(r0020_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-SECTION */
        private void R0050_00_SELECIONA_MOVTO_SECTION()
        {
            /*" -776- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -778- MOVE 'DECLER MOVIMENTO' TO COMANDO. */
            _.Move("DECLER MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -779- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -781- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -784- DISPLAY '** PF0623B ** INICIO DECLARE V0MOVIMENTO...  ' W-TIME-EDIT. */
            _.Display($"** PF0623B ** INICIO DECLARE V0MOVIMENTO...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -786- MOVE 97010000889 TO TERMOADE-NUM-APOLICE */
            _.Move(97010000889, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE);

            /*" -858- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -860- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -864- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -867- MOVE 2 TO W-CURSOR. */
                _.Move(2, WAREA_AUXILIAR.W_CURSOR);
            }


            /*" -868- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -870- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -872- DISPLAY '** PF0623B ** FIM    DECLARE V0MOVIMENTO...  ' W-TIME-EDIT */
            _.Display($"** PF0623B ** FIM    DECLARE V0MOVIMENTO...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -872- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -858- EXEC SQL DECLARE TERMO-ADESAO CURSOR FOR SELECT A.NUM_TERMO , A.COD_SUBGRUPO , A.DATA_ADESAO , A.COD_AGENCIA_OP , A.NUM_MATRICULA_VEN , A.CODPDTVEN , A.PCCOMVEN , A.PCADIANTVEN , A.COD_AGENCIA_VEN , A.OPERACAO_CONTA_VEN , A.NUM_CONTA_VEN , A.DIG_CONTA_VEN , A.NUM_MATRICULA_GER , A.CODPDTGER , A.PCCOMGER , A.COD_AGENCIA_GER , A.OPERACAO_CONTA_GER , A.NUM_CONTA_GER , A.DIG_CONTA_GER , A.NUM_MATRICULA_SUR , A.CODPDTSUR , A.PCCOMSUR , A.NUM_MATRICULA_GCO , A.CODPDTGCO , A.PCCOMGCO , A.MODALIDADE_CAPITAL , A.TIPO_PLANO , A.IND_PLANO_ASSOCIAD , A.COD_PLANO_VGAPC , A.COD_PLANO_APC , A.VAL_CONTRATADO , A.VAL_COMISSAO_ADIAN , A.QUANT_VIDAS , A.TIPO_COBERTURA , A.PERI_PAGAMENTO , A.TIPO_CORRECAO , A.PERIODO_CORRECAO , A.COD_MOEDA_IMP , A.COD_MOEDA_PRM , A.COD_CLIENTE , A.OCORR_ENDERECO , A.COD_CORRETOR , A.PCCOMCOR , A.COD_ADMINISTRADOR , A.PCCOMADM , A.COD_USUARIO , A.DATA_INCLUSAO , A.SITUACAO , A.NUM_PROPOSTA , A.NUM_RCAP , A.DATA_RCAP , A.VAL_RCAP , B.NUM_CERTIFICADO , B.FAIXA_RENDA_IND , B.FAIXA_RENDA_FAM FROM SEGUROS.TERMO_ADESAO A, SEGUROS.PROPOSTAS_VA B WHERE A.NUM_APOLICE = :TERMOADE-NUM-APOLICE AND A.SITUACAO = '0' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND A.COD_CLIENTE = B.COD_CLIENTE ORDER BY A.DATA_INCLUSAO WITH UR END-EXEC. */
            TERMO_ADESAO = new PF0623B_TERMO_ADESAO(true);
            string GetQuery_TERMO_ADESAO()
            {
                var query = @$"SELECT A.NUM_TERMO
							, 
							A.COD_SUBGRUPO
							, 
							A.DATA_ADESAO
							, 
							A.COD_AGENCIA_OP
							, 
							A.NUM_MATRICULA_VEN
							, 
							A.CODPDTVEN
							, 
							A.PCCOMVEN
							, 
							A.PCADIANTVEN
							, 
							A.COD_AGENCIA_VEN
							, 
							A.OPERACAO_CONTA_VEN
							, 
							A.NUM_CONTA_VEN
							, 
							A.DIG_CONTA_VEN
							, 
							A.NUM_MATRICULA_GER
							, 
							A.CODPDTGER
							, 
							A.PCCOMGER
							, 
							A.COD_AGENCIA_GER
							, 
							A.OPERACAO_CONTA_GER
							, 
							A.NUM_CONTA_GER
							, 
							A.DIG_CONTA_GER
							, 
							A.NUM_MATRICULA_SUR
							, 
							A.CODPDTSUR
							, 
							A.PCCOMSUR
							, 
							A.NUM_MATRICULA_GCO
							, 
							A.CODPDTGCO
							, 
							A.PCCOMGCO
							, 
							A.MODALIDADE_CAPITAL
							, 
							A.TIPO_PLANO
							, 
							A.IND_PLANO_ASSOCIAD
							, 
							A.COD_PLANO_VGAPC
							, 
							A.COD_PLANO_APC
							, 
							A.VAL_CONTRATADO
							, 
							A.VAL_COMISSAO_ADIAN
							, 
							A.QUANT_VIDAS
							, 
							A.TIPO_COBERTURA
							, 
							A.PERI_PAGAMENTO
							, 
							A.TIPO_CORRECAO
							, 
							A.PERIODO_CORRECAO
							, 
							A.COD_MOEDA_IMP
							, 
							A.COD_MOEDA_PRM
							, 
							A.COD_CLIENTE
							, 
							A.OCORR_ENDERECO
							, 
							A.COD_CORRETOR
							, 
							A.PCCOMCOR
							, 
							A.COD_ADMINISTRADOR
							, 
							A.PCCOMADM
							, 
							A.COD_USUARIO
							, 
							A.DATA_INCLUSAO
							, 
							A.SITUACAO
							, 
							A.NUM_PROPOSTA
							, 
							A.NUM_RCAP
							, 
							A.DATA_RCAP
							, 
							A.VAL_RCAP
							, 
							B.NUM_CERTIFICADO
							, 
							B.FAIXA_RENDA_IND
							, 
							B.FAIXA_RENDA_FAM 
							FROM SEGUROS.TERMO_ADESAO A
							, 
							SEGUROS.PROPOSTAS_VA B 
							WHERE A.NUM_APOLICE = '{TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE}' 
							AND A.SITUACAO = '0' 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND A.COD_CLIENTE = B.COD_CLIENTE 
							ORDER BY A.DATA_INCLUSAO";

                return query;
            }
            TERMO_ADESAO.GetQueryEvent += GetQuery_TERMO_ADESAO;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -860- EXEC SQL OPEN TERMO-ADESAO END-EXEC. */

            TERMO_ADESAO.Open();

        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-DB-DECLARE-1 */
        public void R0205_00_LER_RCAPCOMP_DB_DECLARE_1()
        {
            /*" -1378- EXEC SQL DECLARE C01_RCAPCOMP CURSOR FOR SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP, COD_OPERACAO FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 ORDER BY COD_OPERACAO DESC WITH UR END-EXEC */
            C01_RCAPCOMP = new PF0623B_C01_RCAPCOMP(true);
            string GetQuery_C01_RCAPCOMP()
            {
                var query = @$"SELECT BCO_AVISO
							, 
							AGE_AVISO
							, 
							NUM_AVISO_CREDITO
							, 
							DATA_MOVIMENTO
							, 
							DATA_RCAP
							, 
							COD_OPERACAO 
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
            /*" -882- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -884- MOVE 'FETCH TERMO-ADESAO' TO COMANDO. */
            _.Move("FETCH TERMO-ADESAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -941- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -944- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -945- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -946- MOVE 'FIM' TO W-FIM-MOVTO-TERMO */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_TERMO);

                    /*" -946- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -948- ELSE */
                }
                else
                {


                    /*" -949- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -951- DISPLAY '          ERRO FETCH CURSOR V0MOVIMENTO  ' SQLCODE */
                    _.Display($"          ERRO FETCH CURSOR V0MOVIMENTO  {DB.SQLCODE}");

                    /*" -952- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -953- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -954- END-IF */
                }


                /*" -956- ELSE */
            }
            else
            {


                /*" -957- IF VIND-RCAP LESS 0 */

                if (VIND_RCAP < 0)
                {

                    /*" -958- GO TO R0070-00-LER-MOVTO */
                    new Task(() => R0070_00_LER_MOVTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -960- END-IF */
                }


                /*" -963- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -975- COMPUTE W-TOT-PROCESSADO = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J */
                WAREA_AUXILIAR.W_TOT_PROCESSADO.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9 + WAREA_AUXILIAR.W_QTD_LD_TIPO_A + WAREA_AUXILIAR.W_QTD_LD_TIPO_B + WAREA_AUXILIAR.W_QTD_LD_TIPO_C + WAREA_AUXILIAR.W_QTD_LD_TIPO_D + WAREA_AUXILIAR.W_QTD_LD_TIPO_E + WAREA_AUXILIAR.W_QTD_LD_TIPO_F + WAREA_AUXILIAR.W_QTD_LD_TIPO_G + WAREA_AUXILIAR.W_QTD_LD_TIPO_H + WAREA_AUXILIAR.W_QTD_LD_TIPO_I + WAREA_AUXILIAR.W_QTD_LD_TIPO_J;

                /*" -976- IF W-CONTROLE > 999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 999)
                {

                    /*" -977- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -978- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -979- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -980- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -982- DISPLAY '** PF0623B ** TOTAL LIDO ..  ' W-NSL ' ' W-TIME-EDIT */

                    $"** PF0623B ** TOTAL LIDO ..  {WAREA_AUXILIAR.W_NSL} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -983- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -985- END-IF */
                }


                /*" -986- IF W-TOT-PROCESSADO GREATER 99999 */

                if (WAREA_AUXILIAR.W_TOT_PROCESSADO > 99999)
                {

                    /*" -987- IF W-FIM-MOVTO-TERMO NOT EQUAL 'FIM' */

                    if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO != "FIM")
                    {

                        /*" -988- MOVE 'FIM' TO W-FIM-MOVTO-TERMO */
                        _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_TERMO);

                        /*" -988- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_2 */

                        R0070_00_LER_MOVTO_DB_CLOSE_2();

                        /*" -990- END-IF */
                    }


                    /*" -991- END-IF */
                }


                /*" -991- END-IF. */
            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -941- EXEC SQL FETCH TERMO-ADESAO INTO :TERMOADE-NUM-TERMO , :TERMOADE-COD-SUBGRUPO , :TERMOADE-DATA-ADESAO , :TERMOADE-COD-AGENCIA-OP , :TERMOADE-NUM-MATRICULA-VEN , :TERMOADE-CODPDTVEN , :TERMOADE-PCCOMVEN , :TERMOADE-PCADIANTVEN , :TERMOADE-COD-AGENCIA-VEN , :TERMOADE-OPERACAO-CONTA-VEN , :TERMOADE-NUM-CONTA-VEN , :TERMOADE-DIG-CONTA-VEN , :TERMOADE-NUM-MATRICULA-GER , :TERMOADE-CODPDTGER , :TERMOADE-PCCOMGER , :TERMOADE-COD-AGENCIA-GER , :TERMOADE-OPERACAO-CONTA-GER , :TERMOADE-NUM-CONTA-GER , :TERMOADE-DIG-CONTA-GER , :TERMOADE-NUM-MATRICULA-SUR , :TERMOADE-CODPDTSUR , :TERMOADE-PCCOMSUR , :TERMOADE-NUM-MATRICULA-GCO , :TERMOADE-CODPDTGCO , :TERMOADE-PCCOMGCO , :TERMOADE-MODALIDADE-CAPITAL , :TERMOADE-TIPO-PLANO , :TERMOADE-IND-PLANO-ASSOCIAD , :TERMOADE-COD-PLANO-VGAPC , :TERMOADE-COD-PLANO-APC , :TERMOADE-VAL-CONTRATADO , :TERMOADE-VAL-COMISSAO-ADIAN , :TERMOADE-QUANT-VIDAS , :TERMOADE-TIPO-COBERTURA , :TERMOADE-PERI-PAGAMENTO , :TERMOADE-TIPO-CORRECAO , :TERMOADE-PERIODO-CORRECAO , :TERMOADE-COD-MOEDA-IMP , :TERMOADE-COD-MOEDA-PRM , :TERMOADE-COD-CLIENTE , :TERMOADE-OCORR-ENDERECO , :TERMOADE-COD-CORRETOR , :TERMOADE-PCCOMCOR , :TERMOADE-COD-ADMINISTRADOR , :TERMOADE-PCCOMADM , :TERMOADE-COD-USUARIO , :TERMOADE-DATA-INCLUSAO , :TERMOADE-SITUACAO , :TERMOADE-NUM-PROPOSTA , :TERMOADE-NUM-RCAP:VIND-RCAP , :TERMOADE-DATA-RCAP:VIND-DATA-RCAP , :TERMOADE-VAL-RCAP:VIND-VAL-RCAP , :PROPOVA-NUM-CERTIFICADO , :PROPOVA-FAIXA-RENDA-IND:VIND-FAIXA-RENDA-IND, :PROPOVA-FAIXA-RENDA-FAM:VIND-FAIXA-RENDA-FAM END-EXEC. */

            if (TERMO_ADESAO.Fetch())
            {
                _.Move(TERMO_ADESAO.TERMOADE_NUM_TERMO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO);
                _.Move(TERMO_ADESAO.TERMOADE_COD_SUBGRUPO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO);
                _.Move(TERMO_ADESAO.TERMOADE_DATA_ADESAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO);
                _.Move(TERMO_ADESAO.TERMOADE_COD_AGENCIA_OP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_OP);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN);
                _.Move(TERMO_ADESAO.TERMOADE_CODPDTVEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_CODPDTVEN);
                _.Move(TERMO_ADESAO.TERMOADE_PCCOMVEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMVEN);
                _.Move(TERMO_ADESAO.TERMOADE_PCADIANTVEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCADIANTVEN);
                _.Move(TERMO_ADESAO.TERMOADE_COD_AGENCIA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_VEN);
                _.Move(TERMO_ADESAO.TERMOADE_OPERACAO_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_OPERACAO_CONTA_VEN);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_CONTA_VEN);
                _.Move(TERMO_ADESAO.TERMOADE_DIG_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DIG_CONTA_VEN);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_MATRICULA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_GER);
                _.Move(TERMO_ADESAO.TERMOADE_CODPDTGER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_CODPDTGER);
                _.Move(TERMO_ADESAO.TERMOADE_PCCOMGER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMGER);
                _.Move(TERMO_ADESAO.TERMOADE_COD_AGENCIA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_GER);
                _.Move(TERMO_ADESAO.TERMOADE_OPERACAO_CONTA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_OPERACAO_CONTA_GER);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_CONTA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_CONTA_GER);
                _.Move(TERMO_ADESAO.TERMOADE_DIG_CONTA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DIG_CONTA_GER);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_MATRICULA_SUR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_SUR);
                _.Move(TERMO_ADESAO.TERMOADE_CODPDTSUR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_CODPDTSUR);
                _.Move(TERMO_ADESAO.TERMOADE_PCCOMSUR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMSUR);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_MATRICULA_GCO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_GCO);
                _.Move(TERMO_ADESAO.TERMOADE_CODPDTGCO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_CODPDTGCO);
                _.Move(TERMO_ADESAO.TERMOADE_PCCOMGCO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMGCO);
                _.Move(TERMO_ADESAO.TERMOADE_MODALIDADE_CAPITAL, TERMOADE.DCLTERMO_ADESAO.TERMOADE_MODALIDADE_CAPITAL);
                _.Move(TERMO_ADESAO.TERMOADE_TIPO_PLANO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_PLANO);
                _.Move(TERMO_ADESAO.TERMOADE_IND_PLANO_ASSOCIAD, TERMOADE.DCLTERMO_ADESAO.TERMOADE_IND_PLANO_ASSOCIAD);
                _.Move(TERMO_ADESAO.TERMOADE_COD_PLANO_VGAPC, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_VGAPC);
                _.Move(TERMO_ADESAO.TERMOADE_COD_PLANO_APC, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_APC);
                _.Move(TERMO_ADESAO.TERMOADE_VAL_CONTRATADO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_CONTRATADO);
                _.Move(TERMO_ADESAO.TERMOADE_VAL_COMISSAO_ADIAN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_COMISSAO_ADIAN);
                _.Move(TERMO_ADESAO.TERMOADE_QUANT_VIDAS, TERMOADE.DCLTERMO_ADESAO.TERMOADE_QUANT_VIDAS);
                _.Move(TERMO_ADESAO.TERMOADE_TIPO_COBERTURA, TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_COBERTURA);
                _.Move(TERMO_ADESAO.TERMOADE_PERI_PAGAMENTO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERI_PAGAMENTO);
                _.Move(TERMO_ADESAO.TERMOADE_TIPO_CORRECAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_CORRECAO);
                _.Move(TERMO_ADESAO.TERMOADE_PERIODO_CORRECAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERIODO_CORRECAO);
                _.Move(TERMO_ADESAO.TERMOADE_COD_MOEDA_IMP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_MOEDA_IMP);
                _.Move(TERMO_ADESAO.TERMOADE_COD_MOEDA_PRM, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_MOEDA_PRM);
                _.Move(TERMO_ADESAO.TERMOADE_COD_CLIENTE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE);
                _.Move(TERMO_ADESAO.TERMOADE_OCORR_ENDERECO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_OCORR_ENDERECO);
                _.Move(TERMO_ADESAO.TERMOADE_COD_CORRETOR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CORRETOR);
                _.Move(TERMO_ADESAO.TERMOADE_PCCOMCOR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMCOR);
                _.Move(TERMO_ADESAO.TERMOADE_COD_ADMINISTRADOR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_ADMINISTRADOR);
                _.Move(TERMO_ADESAO.TERMOADE_PCCOMADM, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMADM);
                _.Move(TERMO_ADESAO.TERMOADE_COD_USUARIO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_USUARIO);
                _.Move(TERMO_ADESAO.TERMOADE_DATA_INCLUSAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_INCLUSAO);
                _.Move(TERMO_ADESAO.TERMOADE_SITUACAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_SITUACAO);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_PROPOSTA, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_PROPOSTA);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_RCAP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_RCAP);
                _.Move(TERMO_ADESAO.VIND_RCAP, VIND_RCAP);
                _.Move(TERMO_ADESAO.TERMOADE_DATA_RCAP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_RCAP);
                _.Move(TERMO_ADESAO.VIND_DATA_RCAP, VIND_DATA_RCAP);
                _.Move(TERMO_ADESAO.TERMOADE_VAL_RCAP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_RCAP);
                _.Move(TERMO_ADESAO.VIND_VAL_RCAP, VIND_VAL_RCAP);
                _.Move(TERMO_ADESAO.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(TERMO_ADESAO.PROPOVA_FAIXA_RENDA_IND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND);
                _.Move(TERMO_ADESAO.VIND_FAIXA_RENDA_IND, VIND_FAIXA_RENDA_IND);
                _.Move(TERMO_ADESAO.PROPOVA_FAIXA_RENDA_FAM, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM);
                _.Move(TERMO_ADESAO.VIND_FAIXA_RENDA_FAM, VIND_FAIXA_RENDA_FAM);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -946- EXEC SQL CLOSE TERMO-ADESAO END-EXEC */

            TERMO_ADESAO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-2 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_2()
        {
            /*" -988- EXEC SQL CLOSE TERMO-ADESAO END-EXEC */

            TERMO_ADESAO.Close();

        }

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -1001- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1003- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1006- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER */
            _.Move("H", LXFPF990.REG_HEADER.RH_TIPO_REG);

            /*" -1009- MOVE 'PRPSASSE' TO RH-NOME OF REG-HEADER */
            _.Move("PRPSASSE", LXFPF990.REG_HEADER.RH_NOME);

            /*" -1010- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1011- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1013- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1016- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFPF990.REG_HEADER.RH_DATA_GERACAO);

            /*" -1019- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER */
            _.Move(4, LXFPF990.REG_HEADER.RH_SIST_ORIGEM);

            /*" -1022- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER */
            _.Move(1, LXFPF990.REG_HEADER.RH_SIST_DESTINO);

            /*" -1024- MOVE 1 TO RH-TIPO-ARQUIVO OF REG-HEADER. */
            _.Move(1, LXFPF990.REG_HEADER.RH_TIPO_ARQUIVO);

            /*" -1029- WRITE REG-PRP-SASSE FROM REG-HEADER. */
            _.Move(LXFPF990.REG_HEADER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -1032- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -1035- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -1038- MOVE RH-DATA-GERACAO OF REG-HEADER TO RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Move(LXFPF990.REG_HEADER.RH_DATA_GERACAO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -1041- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -1044- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -1044- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0085-00-LER-PRODUTOS-SIVPF-SECTION */
        private void R0085_00_LER_PRODUTOS_SIVPF_SECTION()
        {
            /*" -1054- MOVE 'R0085-00-LER-PRODUTOS-SIVPF' TO PARAGRAFO. */
            _.Move("R0085-00-LER-PRODUTOS-SIVPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1056- MOVE 'SELECT PRODUTOS-SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1058- MOVE 15 TO PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(15, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

            /*" -1073- PERFORM R0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1 */

            R0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1();

            /*" -1076- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1077- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -1078- DISPLAY '          ERRO SELECT PRODUTOS-SIVPF' */
                _.Display($"          ERRO SELECT PRODUTOS-SIVPF");

                /*" -1080- DISPLAY '          CODIGO PRODUTO SIVPF......' PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF */
                _.Display($"          CODIGO PRODUTO SIVPF......{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}");

                /*" -1082- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -1083- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1083- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0085-00-LER-PRODUTOS-SIVPF-DB-SELECT-1 */
        public void R0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1()
        {
            /*" -1073- EXEC SQL SELECT DISTINCT COD_EMPRESA_SIVPF , COD_RELAC INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF , :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-RELAC FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = 1 AND COD_PRODUTO_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF ORDER BY COD_EMPRESA_SIVPF, COD_RELAC WITH UR END-EXEC. */

            var r0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1 = new R0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_PRODUTO_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF.ToString(),
            };

            var executed_1 = R0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1.Execute(r0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_COD_EMPRESA_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);
                _.Move(executed_1.PRDSIVPF_COD_RELAC, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0085_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -1093- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1095- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1096- IF PROPOVA-NUM-CERTIFICADO GREATER 10000000000 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO > 10000000000)
            {

                /*" -1097- IF PROPOVA-NUM-CERTIFICADO LESS 19999999999 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO < 19999999999)
                {

                    /*" -1098- ADD 1 TO W-DESPREZADO */
                    WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                    /*" -1100- DISPLAY 'PF0623B - TERMO/PROPOSTA DESPREZADA ==>  ' TERMOADE-NUM-TERMO '  ' PROPOVA-NUM-CERTIFICADO */

                    $"PF0623B - TERMO/PROPOSTA DESPREZADA ==>  {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                    .Display();

                    /*" -1102- GO TO R0150-LEITURA. */

                    R0150_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -1104- PERFORM R0200-00-LER-RCAPS */

            R0200_00_LER_RCAPS_SECTION();

            /*" -1105- IF RCAP-N-CADASTRADO */

            if (WAREA_AUXILIAR.W_RCAPS["RCAP_N_CADASTRADO"])
            {

                /*" -1106- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -1108- DISPLAY 'PF0623B - RCAP NAO CADASTRADO - TERMO ==>   ' TERMOADE-NUM-TERMO '  ' PROPOVA-NUM-CERTIFICADO */

                $"PF0623B - RCAP NAO CADASTRADO - TERMO ==>   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();

                /*" -1110- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1112- PERFORM R0205-00-LER-RCAPCOMP. */

            R0205_00_LER_RCAPCOMP_SECTION();

            /*" -1113- IF RCAPCOMP-N-CADASTRADO */

            if (WAREA_AUXILIAR.W_RCAPCOMP["RCAPCOMP_N_CADASTRADO"])
            {

                /*" -1114- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -1116- DISPLAY 'PF0623B - RCAPCOMP NAO CADASTRADO NUM.TERMO => ' TERMOADE-NUM-TERMO */
                _.Display($"PF0623B - RCAPCOMP NAO CADASTRADO NUM.TERMO => {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1118- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1120- PERFORM R0210-00-LER-PRP-FIDELIZ. */

            R0210_00_LER_PRP_FIDELIZ_SECTION();

            /*" -1121- IF PROPOSTA-CADASTRADA */

            if (WAREA_AUXILIAR.W_FIDELIZ["PROPOSTA_CADASTRADA"])
            {

                /*" -1122- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -1124- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1126- PERFORM R0300-00-LER-CLIENTE */

            R0300_00_LER_CLIENTE_SECTION();

            /*" -1127- IF CLIENTE-NAO-CADASTRADO */

            if (WAREA_AUXILIAR.W_CLIENTE["CLIENTE_NAO_CADASTRADO"])
            {

                /*" -1128- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -1130- DISPLAY 'PF0623B - CLIENTE NAO CADASTRADO ============> ' TERMOADE-COD-CLIENTE */
                _.Display($"PF0623B - CLIENTE NAO CADASTRADO ============> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}");

                /*" -1136- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1137- IF CGCCPF OF DCLCLIENTES EQUAL ZEROS */

            if (CLIENTE.DCLCLIENTES.CGCCPF == 00)
            {

                /*" -1138- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -1141- DISPLAY 'PF0623B - CLIENTE COM CGC ZERADO =======> ' TERMOADE-NUM-TERMO '   ' TERMOADE-COD-CLIENTE */

                $"PF0623B - CLIENTE COM CGC ZERADO =======> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}"
                .Display();

                /*" -1143- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1145- PERFORM R0350-00-LER-ENDERECO. */

            R0350_00_LER_ENDERECO_SECTION();

            /*" -1146- IF ENDERECO-NAO-CADASTRADO */

            if (WAREA_AUXILIAR.W_ENDERECO["ENDERECO_NAO_CADASTRADO"])
            {

                /*" -1147- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -1150- DISPLAY 'PF0623B - ENDERECO NAO CADASTRADO ==========> ' TERMOADE-NUM-TERMO '   ' TERMOADE-COD-CLIENTE */

                $"PF0623B - ENDERECO NAO CADASTRADO ==========> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}"
                .Display();

                /*" -1152- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1154- PERFORM R0400-00-LER-SUBGRUPO. */

            R0400_00_LER_SUBGRUPO_SECTION();

            /*" -1155- IF SUBGRUPO-NAO-CADASTRADO */

            if (WAREA_AUXILIAR.W_SUBGRUPO["SUBGRUPO_NAO_CADASTRADO"])
            {

                /*" -1156- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -1159- DISPLAY 'PF0623B - SUBGRUPO NAO CADASTRADO ==========> ' TERMOADE-NUM-TERMO '   ' TERMOADE-COD-SUBGRUPO */

                $"PF0623B - SUBGRUPO NAO CADASTRADO ==========> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO}"
                .Display();

                /*" -1161- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1163- PERFORM R0450-00-OBTER-COBERTURA. */

            R0450_00_OBTER_COBERTURA_SECTION();

            /*" -1164- IF COBERTURA-NAO-CADASTRADA */

            if (WAREA_AUXILIAR.W_COBERTURAS["COBERTURA_NAO_CADASTRADA"])
            {

                /*" -1165- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -1168- DISPLAY 'PF0623B - COBERTURA NAO CADASTRADA ==========> ' TERMOADE-NUM-TERMO '   ' TERMOADE-COD-SUBGRUPO */

                $"PF0623B - COBERTURA NAO CADASTRADA ==========> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO}"
                .Display();

                /*" -1170- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1172- PERFORM R0500-00-OBTER-OPCAOPAG. */

            R0500_00_OBTER_OPCAOPAG_SECTION();

            /*" -1173- IF OPCAO-PAG-NAO-CADASTRADA */

            if (WAREA_AUXILIAR.W_OPCAOPAG["OPCAO_PAG_NAO_CADASTRADA"])
            {

                /*" -1174- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -1177- DISPLAY 'PF0623B - OPCAOPAG NAO CADASTRADA ==========> ' TERMOADE-NUM-TERMO '   /    ' PROPOVA-NUM-CERTIFICADO */

                $"PF0623B - OPCAOPAG NAO CADASTRADA ==========> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}   /    {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();

                /*" -1179- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1180- PERFORM R0570-00-LER-COMISSAO */

            R0570_00_LER_COMISSAO_SECTION();

            /*" -1181- PERFORM R0580-00-OBTER-VAL-TARIFA */

            R0580_00_OBTER_VAL_TARIFA_SECTION();

            /*" -1182- PERFORM R0600-00-PROPOSTA-REGISTRO-TP1 */

            R0600_00_PROPOSTA_REGISTRO_TP1_SECTION();

            /*" -1183- PERFORM R0650-00-PROPOSTA-REGISTRO-TP2 */

            R0650_00_PROPOSTA_REGISTRO_TP2_SECTION();

            /*" -1184- PERFORM R0700-00-PROPOSTA-REGISTRO-TP3 */

            R0700_00_PROPOSTA_REGISTRO_TP3_SECTION();

            /*" -1185- PERFORM R0750-00-PROPOSTA-REGISTRO-TP6 */

            R0750_00_PROPOSTA_REGISTRO_TP6_SECTION();

            /*" -1186- PERFORM R0800-00-STATUS-REGISTRO-TP1 */

            R0800_00_STATUS_REGISTRO_TP1_SECTION();

            /*" -1187- PERFORM R0850-00-STATUS-REGISTRO-TP2 */

            R0850_00_STATUS_REGISTRO_TP2_SECTION();

            /*" -1188- PERFORM R0900-00-STATUS-REGISTRO-TP3 */

            R0900_00_STATUS_REGISTRO_TP3_SECTION();

            /*" -1189- PERFORM R0950-00-STATUS-REGISTRO-TP4 */

            R0950_00_STATUS_REGISTRO_TP4_SECTION();

            /*" -1190- PERFORM R0970-00-STATUS-REGISTRO-TP5 */

            R0970_00_STATUS_REGISTRO_TP5_SECTION();

            /*" -1190- PERFORM R3000-GERAR-TB-CORPORATIVAS. */

            R3000_GERAR_TB_CORPORATIVAS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0150_LEITURA */

            R0150_LEITURA();

        }

        [StopWatch]
        /*" R0150-LEITURA */
        private void R0150_LEITURA(bool isPerform = false)
        {
            /*" -1195- IF W-FIM-MOVTO-TERMO NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO != "FIM")
            {

                /*" -1195- PERFORM R0070-00-LER-MOVTO. */

                R0070_00_LER_MOVTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0200-00-LER-RCAPS-SECTION */
        private void R0200_00_LER_RCAPS_SECTION()
        {
            /*" -1205- MOVE 'R0200-00-LER-RCAPS' TO PARAGRAFO. */
            _.Move("R0200-00-LER-RCAPS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1207- MOVE 'SELECT TABELA RCAPS' TO COMANDO. */
            _.Move("SELECT TABELA RCAPS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1209- MOVE PROPOVA-NUM-CERTIFICADO TO RCAPS-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -1237- PERFORM R0200_00_LER_RCAPS_DB_SELECT_1 */

            R0200_00_LER_RCAPS_DB_SELECT_1();

            /*" -1240- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1241- MOVE 1 TO W-RCAPS */
                _.Move(1, WAREA_AUXILIAR.W_RCAPS);

                /*" -1242- GO TO R0200-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/ //GOTO
                return;

                /*" -1243- ELSE */
            }
            else
            {


                /*" -1244- IF SQLCODE EQUAL 100 OR -811 */

                if (DB.SQLCODE.In("100", "-811"))
                {

                    /*" -1245- MOVE 2 TO W-RCAPS */
                    _.Move(2, WAREA_AUXILIAR.W_RCAPS);

                    /*" -1246- ELSE */
                }
                else
                {


                    /*" -1247- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -1248- DISPLAY '          ERRO SELECT TABELA RCAPS' */
                    _.Display($"          ERRO SELECT TABELA RCAPS");

                    /*" -1250- DISPLAY '          NUMERO CERTIFICDO...... ' RCAPS-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICDO...... {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO}");

                    /*" -1252- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1253- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1256- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -1258- MOVE TERMOADE-NUM-RCAP TO RCAPS-NUM-RCAP. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);

            /*" -1286- PERFORM R0200_00_LER_RCAPS_DB_SELECT_2 */

            R0200_00_LER_RCAPS_DB_SELECT_2();

            /*" -1289- IF VIND-AGE-COBRANCA LESS ZERO */

            if (VIND_AGE_COBRANCA < 00)
            {

                /*" -1291- MOVE ZEROS TO RCAPS-AGE-COBRANCA. */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
            }


            /*" -1292- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1303- MOVE 1 TO W-RCAPS */
                _.Move(1, WAREA_AUXILIAR.W_RCAPS);

                /*" -1304- ELSE */
            }
            else
            {


                /*" -1305- IF SQLCODE EQUAL 100 OR -811 */

                if (DB.SQLCODE.In("100", "-811"))
                {

                    /*" -1306- MOVE 2 TO W-RCAPS */
                    _.Move(2, WAREA_AUXILIAR.W_RCAPS);

                    /*" -1307- ELSE */
                }
                else
                {


                    /*" -1308- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -1309- DISPLAY '          ERRO SELECT TABELA RCAPS' */
                    _.Display($"          ERRO SELECT TABELA RCAPS");

                    /*" -1311- DISPLAY '          NUMERO CERTIFICDO...... ' RCAPS-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICDO...... {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO}");

                    /*" -1313- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1314- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1314- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0200-00-LER-RCAPS-DB-SELECT-1 */
        public void R0200_00_LER_RCAPS_DB_SELECT_1()
        {
            /*" -1237- EXEC SQL SELECT COD_FONTE, NUM_PROPOSTA, VAL_RCAP, VAL_RCAP_PRINCIPAL, DATA_CADASTRAMENTO, DATA_MOVIMENTO, SIT_REGISTRO, COD_OPERACAO, NUM_TITULO, AGE_COBRANCA, NUM_RCAP INTO :RCAPS-COD-FONTE, :RCAPS-NUM-PROPOSTA, :RCAPS-VAL-RCAP, :RCAPS-VAL-RCAP-PRINCIPAL, :RCAPS-DATA-CADASTRAMENTO, :RCAPS-DATA-MOVIMENTO, :RCAPS-SIT-REGISTRO, :RCAPS-COD-OPERACAO, :RCAPS-NUM-TITULO, :RCAPS-AGE-COBRANCA:VIND-AGE-COBRANCA, :RCAPS-NUM-RCAP FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO WITH UR END-EXEC. */

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
            /*" -1286- EXEC SQL SELECT COD_FONTE, NUM_PROPOSTA, VAL_RCAP, VAL_RCAP_PRINCIPAL, DATA_CADASTRAMENTO, DATA_MOVIMENTO, SIT_REGISTRO, COD_OPERACAO, NUM_TITULO, AGE_COBRANCA, NUM_RCAP INTO :RCAPS-COD-FONTE, :RCAPS-NUM-PROPOSTA, :RCAPS-VAL-RCAP, :RCAPS-VAL-RCAP-PRINCIPAL, :RCAPS-DATA-CADASTRAMENTO, :RCAPS-DATA-MOVIMENTO, :RCAPS-SIT-REGISTRO, :RCAPS-COD-OPERACAO, :RCAPS-NUM-TITULO, :RCAPS-AGE-COBRANCA:VIND-AGE-COBRANCA, :RCAPS-NUM-RCAP FROM SEGUROS.RCAPS WHERE NUM_RCAP = :RCAPS-NUM-RCAP WITH UR END-EXEC. */

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
            /*" -1324- MOVE 'R0205-00-LER-RCAPCOMP' TO PARAGRAFO. */
            _.Move("R0205-00-LER-RCAPCOMP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1326- MOVE 'SELECT TABELA RCAPS-COMP' TO COMANDO. */
            _.Move("SELECT TABELA RCAPS-COMP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1328- MOVE 2 TO W-RCAPCOMP. */
            _.Move(2, WAREA_AUXILIAR.W_RCAPCOMP);

            /*" -1345- PERFORM R0205_00_LER_RCAPCOMP_DB_SELECT_1 */

            R0205_00_LER_RCAPCOMP_DB_SELECT_1();

            /*" -1348- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1349- MOVE 1 TO W-RCAPCOMP */
                _.Move(1, WAREA_AUXILIAR.W_RCAPCOMP);

                /*" -1350- ELSE */
            }
            else
            {


                /*" -1351- IF SQLCODE NOT EQUAL 100 AND -811 */

                if (!DB.SQLCODE.In("100", "-811"))
                {

                    /*" -1352- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -1353- DISPLAY '          ERRO SELECT TABELA RCAPSCOMP' */
                    _.Display($"          ERRO SELECT TABELA RCAPSCOMP");

                    /*" -1355- DISPLAY '          NUMERO DO TERMO........ ' TERMOADE-NUM-TERMO */
                    _.Display($"          NUMERO DO TERMO........ {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -1357- DISPLAY '          NUMERO DO RCAPS........ ' RCAPS-NUM-RCAP */
                    _.Display($"          NUMERO DO RCAPS........ {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                    /*" -1359- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1360- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1361- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1362- ELSE */
                }
                else
                {


                    /*" -1378- PERFORM R0205_00_LER_RCAPCOMP_DB_DECLARE_1 */

                    R0205_00_LER_RCAPCOMP_DB_DECLARE_1();

                    /*" -1380- PERFORM R0205_00_LER_RCAPCOMP_DB_OPEN_1 */

                    R0205_00_LER_RCAPCOMP_DB_OPEN_1();

                    /*" -1383- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1384- DISPLAY 'PF0623B - FIM ANORMAL' */
                        _.Display($"PF0623B - FIM ANORMAL");

                        /*" -1385- DISPLAY '          ERRO NO OPEN DO CURSOR RCAPCOMP' */
                        _.Display($"          ERRO NO OPEN DO CURSOR RCAPCOMP");

                        /*" -1387- DISPLAY '          NUMERO DO TERMO........ ' TERMOADE-NUM-TERMO */
                        _.Display($"          NUMERO DO TERMO........ {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                        /*" -1389- DISPLAY '          NUMERO DO RCAPS........ ' RCAPS-NUM-RCAP */
                        _.Display($"          NUMERO DO RCAPS........ {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -1391- DISPLAY '          SQLCODE.................... ' SQLCODE */
                        _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                        /*" -1392- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1393- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -1395- END-IF */
                    }


                    /*" -1406- PERFORM R0205_00_LER_RCAPCOMP_DB_FETCH_1 */

                    R0205_00_LER_RCAPCOMP_DB_FETCH_1();

                    /*" -1409- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1410- DISPLAY 'PF0623B - FIM ANORMAL' */
                        _.Display($"PF0623B - FIM ANORMAL");

                        /*" -1411- DISPLAY '          ERRO NO FETCH DO CURSOR RCAPCOMP' */
                        _.Display($"          ERRO NO FETCH DO CURSOR RCAPCOMP");

                        /*" -1413- DISPLAY '          NUMERO DO TERMO........ ' TERMOADE-NUM-TERMO */
                        _.Display($"          NUMERO DO TERMO........ {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                        /*" -1415- DISPLAY '          NUMERO DO RCAPS........ ' RCAPS-NUM-RCAP */
                        _.Display($"          NUMERO DO RCAPS........ {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -1417- DISPLAY '          SQLCODE.................... ' SQLCODE */
                        _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                        /*" -1418- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1419- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -1420- ELSE */
                    }
                    else
                    {


                        /*" -1421- MOVE 1 TO W-RCAPCOMP */
                        _.Move(1, WAREA_AUXILIAR.W_RCAPCOMP);

                        /*" -1423- END-IF */
                    }


                    /*" -1423- PERFORM R0205_00_LER_RCAPCOMP_DB_CLOSE_1 */

                    R0205_00_LER_RCAPCOMP_DB_CLOSE_1();

                    /*" -1426- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1427- DISPLAY 'PF0623B - FIM ANORMAL' */
                        _.Display($"PF0623B - FIM ANORMAL");

                        /*" -1428- DISPLAY '          ERRO NO CLOSE DO CURSOR RCAPCOMP' */
                        _.Display($"          ERRO NO CLOSE DO CURSOR RCAPCOMP");

                        /*" -1430- DISPLAY '          NUMERO DO TERMO........ ' TERMOADE-NUM-TERMO */
                        _.Display($"          NUMERO DO TERMO........ {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                        /*" -1432- DISPLAY '          NUMERO DO RCAPS........ ' RCAPS-NUM-RCAP */
                        _.Display($"          NUMERO DO RCAPS........ {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -1434- DISPLAY '          SQLCODE.................... ' SQLCODE */
                        _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                        /*" -1435- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1435- PERFORM R9999-00-FINALIZAR. */

                        R9999_00_FINALIZAR_SECTION();
                    }

                }

            }


        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-DB-SELECT-1 */
        public void R0205_00_LER_RCAPCOMP_DB_SELECT_1()
        {
            /*" -1345- EXEC SQL SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

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
            /*" -1380- EXEC SQL OPEN C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-DECLARE-1 */
        public void R0450_00_OBTER_COBERTURA_DB_DECLARE_1()
        {
            /*" -1773- EXEC SQL DECLARE COBERTURAS CURSOR FOR SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMP_MORNATU , IMPMORACID , IMPINVPERM FROM SEGUROS.HIS_COBER_PROPOST WHERE (NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO OR NUM_CERTIFICADO = :WHOST-NUM-TERMO) AND DATA_TERVIGENCIA = :HISCOBPR-DATA-TERVIGENCIA ORDER BY OCORR_HISTORICO WITH UR END-EXEC. */
            COBERTURAS = new PF0623B_COBERTURAS(true);
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
							WHERE (NUM_CERTIFICADO = '{HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}' 
							OR NUM_CERTIFICADO = '{WHOST_NUM_TERMO}') 
							AND DATA_TERVIGENCIA = '{HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA}' 
							ORDER BY OCORR_HISTORICO";

                return query;
            }
            COBERTURAS.GetQueryEvent += GetQuery_COBERTURAS;

        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-DB-FETCH-1 */
        public void R0205_00_LER_RCAPCOMP_DB_FETCH_1()
        {
            /*" -1406- EXEC SQL FETCH C01_RCAPCOMP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-COD-OPERACAO END-EXEC */

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
            /*" -1423- EXEC SQL CLOSE C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0205_SAIDA*/

        [StopWatch]
        /*" R0210-00-LER-PRP-FIDELIZ-SECTION */
        private void R0210_00_LER_PRP_FIDELIZ_SECTION()
        {
            /*" -1445- MOVE 'R0210-00-LER-PRP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0210-00-LER-PRP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1447- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1449- MOVE RCAPS-NUM-CERTIFICADO TO PROPOFID-NUM-PROPOSTA-SIVPF. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -1457- PERFORM R0210_00_LER_PRP_FIDELIZ_DB_SELECT_1 */

            R0210_00_LER_PRP_FIDELIZ_DB_SELECT_1();

            /*" -1460- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1461- MOVE 1 TO W-FIDELIZ */
                _.Move(1, WAREA_AUXILIAR.W_FIDELIZ);

                /*" -1462- ELSE */
            }
            else
            {


                /*" -1463- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1464- MOVE 2 TO W-FIDELIZ */
                    _.Move(2, WAREA_AUXILIAR.W_FIDELIZ);

                    /*" -1465- ELSE */
                }
                else
                {


                    /*" -1466- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -1467- DISPLAY '          ERRO SELECT PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO SELECT PROPOSTA-FIDELIZ");

                    /*" -1469- DISPLAY '          NUMERO PROPOSTA............ ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO PROPOSTA............ {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -1471- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1472- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1472- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0210-00-LER-PRP-FIDELIZ-DB-SELECT-1 */
        public void R0210_00_LER_PRP_FIDELIZ_DB_SELECT_1()
        {
            /*" -1457- EXEC SQL SELECT SIT_PROPOSTA, NUM_PROPOSTA_SIVPF INTO :PROPOFID-SIT-PROPOSTA, :PROPOFID-NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r0210_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1 = new R0210_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0210_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0210_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-SECTION */
        private void R0300_00_LER_CLIENTE_SECTION()
        {
            /*" -1482- MOVE 'R0300-00-LER-CLIENTES' TO PARAGRAFO. */
            _.Move("R0300-00-LER-CLIENTES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1484- MOVE 'SELECT CLIENTES' TO COMANDO. */
            _.Move("SELECT CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1487- MOVE TERMOADE-COD-CLIENTE TO COD-CLIENTE OF DCLCLIENTES. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);

            /*" -1505- PERFORM R0300_00_LER_CLIENTE_DB_SELECT_1 */

            R0300_00_LER_CLIENTE_DB_SELECT_1();

            /*" -1508- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1509- MOVE 1 TO W-CLIENTE */
                _.Move(1, WAREA_AUXILIAR.W_CLIENTE);

                /*" -1510- ELSE */
            }
            else
            {


                /*" -1511- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1512- MOVE 2 TO W-CLIENTE */
                    _.Move(2, WAREA_AUXILIAR.W_CLIENTE);

                    /*" -1513- ELSE */
                }
                else
                {


                    /*" -1514- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -1515- DISPLAY '          ERRO SELECT TABELA CLIENTES' */
                    _.Display($"          ERRO SELECT TABELA CLIENTES");

                    /*" -1517- DISPLAY '          NUMERO DO TERMO............ ' TERMOADE-NUM-TERMO */
                    _.Display($"          NUMERO DO TERMO............ {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -1519- DISPLAY '          CODIGO DO CLIENTE.......... ' TERMOADE-COD-CLIENTE */
                    _.Display($"          CODIGO DO CLIENTE.......... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}");

                    /*" -1521- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1522- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1522- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-DB-SELECT-1 */
        public void R0300_00_LER_CLIENTE_DB_SELECT_1()
        {
            /*" -1505- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO INTO :DCLCLIENTES.COD-CLIENTE , :DCLCLIENTES.NOME-RAZAO , :DCLCLIENTES.TIPO-PESSOA , :DCLCLIENTES.CGCCPF , :DCLCLIENTES.SIT-REGISTRO , :DCLCLIENTES.DATA-NASCIMENTO:VIND-DTNASCI FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE WITH UR END-EXEC. */

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
        /*" R0350-00-LER-ENDERECO-SECTION */
        private void R0350_00_LER_ENDERECO_SECTION()
        {
            /*" -1532- MOVE 'R0350-00-LER-ENDERECO' TO PARAGRAFO. */
            _.Move("R0350-00-LER-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1534- MOVE 'SELECT ENDERECOS' TO COMANDO. */
            _.Move("SELECT ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1537- MOVE TERMOADE-COD-CLIENTE TO ENDERECO-COD-CLIENTE OF DCLENDERECOS. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -1540- MOVE TERMOADE-OCORR-ENDERECO TO ENDERECO-OCORR-ENDERECO OF DCLENDERECOS. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);

            /*" -1575- PERFORM R0350_00_LER_ENDERECO_DB_SELECT_1 */

            R0350_00_LER_ENDERECO_DB_SELECT_1();

            /*" -1578- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1579- MOVE 1 TO W-ENDERECO */
                _.Move(1, WAREA_AUXILIAR.W_ENDERECO);

                /*" -1580- ELSE */
            }
            else
            {


                /*" -1581- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1582- MOVE 2 TO W-ENDERECO */
                    _.Move(2, WAREA_AUXILIAR.W_ENDERECO);

                    /*" -1583- ELSE */
                }
                else
                {


                    /*" -1584- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -1585- DISPLAY '          ERRO SELECT TABELA ENDERECOS' */
                    _.Display($"          ERRO SELECT TABELA ENDERECOS");

                    /*" -1587- DISPLAY '          NUMERO DO TERMO............. ' TERMOADE-NUM-TERMO */
                    _.Display($"          NUMERO DO TERMO............. {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -1589- DISPLAY '          CODIGO DO CLIENTE........... ' ENDERECO-COD-CLIENTE OF DCLENDERECOS */
                    _.Display($"          CODIGO DO CLIENTE........... {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                    /*" -1591- DISPLAY '          SQLCODE..................... ' SQLCODE */
                    _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                    /*" -1592- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1592- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0350-00-LER-ENDERECO-DB-SELECT-1 */
        public void R0350_00_LER_ENDERECO_DB_SELECT_1()
        {
            /*" -1575- EXEC SQL SELECT COD_CLIENTE , COD_ENDERECO , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , TELEX , SIT_REGISTRO INTO :DCLENDERECOS.ENDERECO-COD-CLIENTE , :DCLENDERECOS.ENDERECO-COD-ENDERECO , :DCLENDERECOS.ENDERECO-OCORR-ENDERECO , :DCLENDERECOS.ENDERECO-ENDERECO , :DCLENDERECOS.ENDERECO-BAIRRO , :DCLENDERECOS.ENDERECO-CIDADE , :DCLENDERECOS.ENDERECO-SIGLA-UF , :DCLENDERECOS.ENDERECO-CEP , :DCLENDERECOS.ENDERECO-DDD , :DCLENDERECOS.ENDERECO-TELEFONE , :DCLENDERECOS.ENDERECO-FAX , :DCLENDERECOS.ENDERECO-TELEX , :DCLENDERECOS.ENDERECO-SIT-REGISTRO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLENDERECOS.ENDERECO-COD-CLIENTE AND OCORR_ENDERECO = :DCLENDERECOS.ENDERECO-OCORR-ENDERECO WITH UR END-EXEC. */

            var r0350_00_LER_ENDERECO_DB_SELECT_1_Query1 = new R0350_00_LER_ENDERECO_DB_SELECT_1_Query1()
            {
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                ENDERECO_COD_CLIENTE = ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0350_00_LER_ENDERECO_DB_SELECT_1_Query1.Execute(r0350_00_LER_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);
                _.Move(executed_1.ENDERECO_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);
                _.Move(executed_1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(executed_1.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(executed_1.ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);
                _.Move(executed_1.ENDERECO_TELEX, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);
                _.Move(executed_1.ENDERECO_SIT_REGISTRO, ENDERECO.DCLENDERECOS.ENDERECO_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R0400-00-LER-SUBGRUPO-SECTION */
        private void R0400_00_LER_SUBGRUPO_SECTION()
        {
            /*" -1602- MOVE 'R0400-00-LER-SUBGRUPO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-SUBGRUPO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1604- MOVE 'SELECT SUBGRUPO ' TO COMANDO. */
            _.Move("SELECT SUBGRUPO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1606- MOVE 97010000889 TO SUBGVGAP-NUM-APOLICE. */
            _.Move(97010000889, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -1608- MOVE TERMOADE-COD-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -1669- PERFORM R0400_00_LER_SUBGRUPO_DB_SELECT_1 */

            R0400_00_LER_SUBGRUPO_DB_SELECT_1();

            /*" -1672- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1673- MOVE 1 TO W-SUBGRUPO */
                _.Move(1, WAREA_AUXILIAR.W_SUBGRUPO);

                /*" -1674- ELSE */
            }
            else
            {


                /*" -1675- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1676- MOVE 2 TO W-SUBGRUPO */
                    _.Move(2, WAREA_AUXILIAR.W_SUBGRUPO);

                    /*" -1677- ELSE */
                }
                else
                {


                    /*" -1678- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -1679- DISPLAY '          ERRO SELECT TABELA SUBGRUPOS' */
                    _.Display($"          ERRO SELECT TABELA SUBGRUPOS");

                    /*" -1681- DISPLAY '          CODIGO SUBGRUPO............. ' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"          CODIGO SUBGRUPO............. {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -1683- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                    _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -1685- DISPLAY '          SQLCODE..................... ' SQLCODE */
                    _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                    /*" -1686- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1686- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0400-00-LER-SUBGRUPO-DB-SELECT-1 */
        public void R0400_00_LER_SUBGRUPO_DB_SELECT_1()
        {
            /*" -1669- EXEC SQL SELECT COD_SUBGRUPO , COD_CLIENTE , CLASSE_APOLICE , COD_FONTE , TIPO_FATURAMENTO , FORMA_FATURAMENTO , FORMA_AVERBACAO , TIPO_PLANO , PERI_FATURAMENTO , PERI_RENOVACAO , PERI_RETROATI_INC , PERI_RETROATI_CAN , OCORR_ENDERECO , OCORR_END_COBRAN , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , TIPO_COBRANCA , COD_PAG_ANGARIACAO , PCT_CONJUGE_VG , PCT_CONJUGE_AP , OPCAO_COBERTURA , OPCAO_CORRETAGEM , IND_CONSISTE_MATRI , IND_PLANO_ASSOCIA , SIT_REGISTRO , OPCAO_CONJUGE INTO :SUBGVGAP-COD-SUBGRUPO , :SUBGVGAP-COD-CLIENTE , :SUBGVGAP-CLASSE-APOLICE , :SUBGVGAP-COD-FONTE , :SUBGVGAP-TIPO-FATURAMENTO , :SUBGVGAP-FORMA-FATURAMENTO , :SUBGVGAP-FORMA-AVERBACAO , :SUBGVGAP-TIPO-PLANO , :SUBGVGAP-PERI-FATURAMENTO , :SUBGVGAP-PERI-RENOVACAO , :SUBGVGAP-PERI-RETROATI-INC , :SUBGVGAP-PERI-RETROATI-CAN , :SUBGVGAP-OCORR-ENDERECO , :SUBGVGAP-OCORR-END-COBRAN , :SUBGVGAP-BCO-COBRANCA , :SUBGVGAP-AGE-COBRANCA , :SUBGVGAP-DAC-COBRANCA , :SUBGVGAP-TIPO-COBRANCA , :SUBGVGAP-COD-PAG-ANGARIACAO , :SUBGVGAP-PCT-CONJUGE-VG , :SUBGVGAP-PCT-CONJUGE-AP , :SUBGVGAP-OPCAO-COBERTURA , :SUBGVGAP-OPCAO-CORRETAGEM , :SUBGVGAP-IND-CONSISTE-MATRI , :SUBGVGAP-IND-PLANO-ASSOCIA , :SUBGVGAP-SIT-REGISTRO , :SUBGVGAP-OPCAO-CONJUGE FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO WITH UR END-EXEC. */

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
            /*" -1696- MOVE 'R0500-00-OBTER-OPCAOPAG' TO PARAGRAFO. */
            _.Move("R0500-00-OBTER-OPCAOPAG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1698- MOVE 'SELECT OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT OPCAOPAGVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1699- MOVE PROPOVA-NUM-CERTIFICADO TO OPCPAGVI-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

            /*" -1701- MOVE '9999-12-31' TO OPCPAGVI-DATA-TERVIGENCIA */
            _.Move("9999-12-31", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA);

            /*" -1722- PERFORM R0500_00_OBTER_OPCAOPAG_DB_SELECT_1 */

            R0500_00_OBTER_OPCAOPAG_DB_SELECT_1();

            /*" -1725- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1726- MOVE 1 TO W-OPCAOPAG */
                _.Move(1, WAREA_AUXILIAR.W_OPCAOPAG);

                /*" -1727- ELSE */
            }
            else
            {


                /*" -1728- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1729- MOVE 2 TO W-OPCAOPAG */
                    _.Move(2, WAREA_AUXILIAR.W_OPCAOPAG);

                    /*" -1730- ELSE */
                }
                else
                {


                    /*" -1731- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -1732- DISPLAY '          ERRO SELECT TABELA OPCAOPAGVA' */
                    _.Display($"          ERRO SELECT TABELA OPCAOPAGVA");

                    /*" -1734- DISPLAY '          CERTIFICADO................. ' OPCPAGVI-NUM-CERTIFICADO */
                    _.Display($"          CERTIFICADO................. {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                    /*" -1736- DISPLAY '          SQLCODE..................... ' SQLCODE */
                    _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                    /*" -1737- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1737- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0500-00-OBTER-OPCAOPAG-DB-SELECT-1 */
        public void R0500_00_OBTER_OPCAOPAG_DB_SELECT_1()
        {
            /*" -1722- EXEC SQL SELECT OPCAO_PAGAMENTO , PERI_PAGAMENTO , DIA_DEBITO , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO INTO :OPCPAGVI-OPCAO-PAGAMENTO , :OPCPAGVI-PERI-PAGAMENTO , :OPCPAGVI-DIA-DEBITO , :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGECTADEB, :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPRCTADEB , :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUMCTADEB , :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIGCTADEB FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND DATA_TERVIGENCIA = :OPCPAGVI-DATA-TERVIGENCIA WITH UR END-EXEC. */

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
            /*" -1747- MOVE 'R0450-00-OBTER-COBERTURA' TO PARAGRAFO. */
            _.Move("R0450-00-OBTER-COBERTURA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1749- MOVE 'SELECT COBERPROPVA' TO COMANDO. */
            _.Move("SELECT COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1750- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO HISCOBPR-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);

            /*" -1751- MOVE TERMOADE-NUM-TERMO TO WHOST-NUM-TERMO */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO, WHOST_NUM_TERMO);

            /*" -1754- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA */
            _.Move("9999-12-31", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

            /*" -1756- MOVE 2 TO W-COBERTURAS */
            _.Move(2, WAREA_AUXILIAR.W_COBERTURAS);

            /*" -1773- PERFORM R0450_00_OBTER_COBERTURA_DB_DECLARE_1 */

            R0450_00_OBTER_COBERTURA_DB_DECLARE_1();

            /*" -1775- PERFORM R0450_00_OBTER_COBERTURA_DB_OPEN_1 */

            R0450_00_OBTER_COBERTURA_DB_OPEN_1();

            /*" -1778- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1779- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -1780- DISPLAY '          ERRO OPEN DO CURSOR COBERTURAS' */
                _.Display($"          ERRO OPEN DO CURSOR COBERTURAS");

                /*" -1782- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1784- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -1786- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -1787- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1789- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1798- PERFORM R0450_00_OBTER_COBERTURA_DB_FETCH_1 */

            R0450_00_OBTER_COBERTURA_DB_FETCH_1();

            /*" -1801- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1802- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -1803- DISPLAY '          ERRO FETCH DO CURSOR COBERTURAS' */
                _.Display($"          ERRO FETCH DO CURSOR COBERTURAS");

                /*" -1805- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1807- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -1809- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -1810- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1812- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1812- PERFORM R0450_00_OBTER_COBERTURA_DB_CLOSE_1 */

            R0450_00_OBTER_COBERTURA_DB_CLOSE_1();

            /*" -1815- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1816- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -1817- DISPLAY '          ERRO CLOSE DO CURSOR COBERTURAS' */
                _.Display($"          ERRO CLOSE DO CURSOR COBERTURAS");

                /*" -1819- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -1821- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -1823- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -1824- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1826- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1826- MOVE 1 TO W-COBERTURAS. */
            _.Move(1, WAREA_AUXILIAR.W_COBERTURAS);

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-OPEN-1 */
        public void R0450_00_OBTER_COBERTURA_DB_OPEN_1()
        {
            /*" -1775- EXEC SQL OPEN COBERTURAS END-EXEC. */

            COBERTURAS.Open();

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-DECLARE-1 */
        public void R0570_00_LER_COMISSAO_DB_DECLARE_1()
        {
            /*" -1855- EXEC SQL DECLARE FUNDOCOMISVA CURSOR FOR SELECT NUM_CERTIFICADO , VAL_COMISSAO_VG , VAL_COMISSAO_AP FROM SEGUROS.FUNDO_COMISSAO_VA WHERE NUM_CERTIFICADO = :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO AND COD_OPERACAO = :DCLFUNDO-COMISSAO-VA.COD-OPERACAO WITH UR END-EXEC. */
            FUNDOCOMISVA = new PF0623B_FUNDOCOMISVA(true);
            string GetQuery_FUNDOCOMISVA()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							VAL_COMISSAO_VG
							, 
							VAL_COMISSAO_AP 
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
            /*" -1798- EXEC SQL FETCH COBERTURAS INTO :HISCOBPR-NUM-CERTIFICADO , :HISCOBPR-OCORR-HISTORICO , :HISCOBPR-DATA-INIVIGENCIA , :HISCOBPR-DATA-TERVIGENCIA , :HISCOBPR-IMP-MORNATU , :HISCOBPR-IMPMORACID , :HISCOBPR-IMPINVPERM END-EXEC. */

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
            /*" -1812- EXEC SQL CLOSE COBERTURAS END-EXEC. */

            COBERTURAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_SAIDA*/

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-SECTION */
        private void R0570_00_LER_COMISSAO_SECTION()
        {
            /*" -1836- MOVE 'R0570-00-LER-COMISSAO' TO PARAGRAFO. */
            _.Move("R0570-00-LER-COMISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1838- MOVE 'SELECT FUNDOCOMISVA' TO COMANDO. */
            _.Move("SELECT FUNDOCOMISVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1841- MOVE PROPOVA-NUM-CERTIFICADO TO NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);

            /*" -1844- MOVE 1101 TO COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
            _.Move(1101, FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO);

            /*" -1855- PERFORM R0570_00_LER_COMISSAO_DB_DECLARE_1 */

            R0570_00_LER_COMISSAO_DB_DECLARE_1();

            /*" -1858- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1859- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -1860- DISPLAY '          ERRO DECLARE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO DECLARE CURSOR FUNDOCOMISVA");

                /*" -1862- DISPLAY '          NUMERO CERTIFICADO.............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO.............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -1864- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -1865- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1867- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1867- PERFORM R0570_00_LER_COMISSAO_DB_OPEN_1 */

            R0570_00_LER_COMISSAO_DB_OPEN_1();

            /*" -1870- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1871- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -1872- DISPLAY '          ERRO OPEN CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO OPEN CURSOR FUNDOCOMISVA");

                /*" -1874- DISPLAY '          NUMERO CERTIFICADO........... ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO........... {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -1876- DISPLAY '          SQLCODE...................... ' SQLCODE */
                _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                /*" -1877- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1879- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1885- PERFORM R0570_00_LER_COMISSAO_DB_FETCH_1 */

            R0570_00_LER_COMISSAO_DB_FETCH_1();

            /*" -1888- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1889- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1892- MOVE ZEROS TO VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA, VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);

                    /*" -1893- ELSE */
                }
                else
                {


                    /*" -1894- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -1895- DISPLAY '          ERRO SELECT CURSOR FUNDOCOMISVA' */
                    _.Display($"          ERRO SELECT CURSOR FUNDOCOMISVA");

                    /*" -1897- DISPLAY '          NUMERO CERTIFICADO............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          NUMERO CERTIFICADO............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                    /*" -1899- DISPLAY '          SQLCODE........................ ' SQLCODE */
                    _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                    /*" -1900- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1902- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -1902- PERFORM R0570_00_LER_COMISSAO_DB_CLOSE_1 */

            R0570_00_LER_COMISSAO_DB_CLOSE_1();

            /*" -1905- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1906- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -1907- DISPLAY '          ERRO CLOSE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO CLOSE CURSOR FUNDOCOMISVA");

                /*" -1909- DISPLAY '          NUMERO CERTIFICADO............ ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO............ {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -1911- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -1912- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1912- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-OPEN-1 */
        public void R0570_00_LER_COMISSAO_DB_OPEN_1()
        {
            /*" -1867- EXEC SQL OPEN FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Open();

        }

        [StopWatch]
        /*" R3136-RELACIONA-EMAIL-DB-DECLARE-1 */
        public void R3136_RELACIONA_EMAIL_DB_DECLARE_1()
        {
            /*" -3171- EXEC SQL DECLARE EMAIL CURSOR FOR SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA ORDER BY SEQ_EMAIL WITH UR END-EXEC. */
            EMAIL = new PF0623B_EMAIL(true);
            string GetQuery_EMAIL()
            {
                var query = @$"SELECT COD_PESSOA
							, 
							SEQ_EMAIL
							, 
							EMAIL
							, 
							SITUACAO_EMAIL 
							FROM SEGUROS.PESSOA_EMAIL 
							WHERE COD_PESSOA = '{PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}' 
							ORDER BY SEQ_EMAIL";

                return query;
            }
            EMAIL.GetQueryEvent += GetQuery_EMAIL;

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-FETCH-1 */
        public void R0570_00_LER_COMISSAO_DB_FETCH_1()
        {
            /*" -1885- EXEC SQL FETCH FUNDOCOMISVA INTO :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-VG , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-AP END-EXEC. */

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
            /*" -1902- EXEC SQL CLOSE FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_SAIDA*/

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-SECTION */
        private void R0580_00_OBTER_VAL_TARIFA_SECTION()
        {
            /*" -1922- MOVE 'R0580-00-OBTER-VAL-TARIFA' TO PARAGRAFO. */
            _.Move("R0580-00-OBTER-VAL-TARIFA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1924- MOVE 'SELECT TARIFA-BALCAO-CEF' TO COMANDO. */
            _.Move("SELECT TARIFA-BALCAO-CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1927- MOVE PROPOVA-NUM-CERTIFICADO TO NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO);

            /*" -1939- PERFORM R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1 */

            R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1();

            /*" -1942- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1943- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1944- MOVE ZEROS TO VAL-TARIFA OF DCLTARIFA-BALCAO-CEF */
                    _.Move(0, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);

                    /*" -1945- ELSE */
                }
                else
                {


                    /*" -1946- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -1947- DISPLAY '          ERRO SELECT TAB. TARIFA-BALCAO-CEF' */
                    _.Display($"          ERRO SELECT TAB. TARIFA-BALCAO-CEF");

                    /*" -1949- DISPLAY '          NUMERO CERTIFICADO........ ' NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF */
                    _.Display($"          NUMERO CERTIFICADO........ {TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO}");

                    /*" -1951- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -1952- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1952- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-DB-SELECT-1 */
        public void R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1()
        {
            /*" -1939- EXEC SQL SELECT VAL_TARIFA INTO :DCLTARIFA-BALCAO-CEF.VAL-TARIFA FROM SEGUROS.TARIFA_BALCAO_CEF WHERE COD_EMPRESA = 0 AND NUM_MATRICULA = 9999999 AND TIPO_FUNCIONARIO = '5' AND NUM_CERTIFICADO = :DCLTARIFA-BALCAO-CEF.NUM-CERTIFICADO WITH UR END-EXEC. */

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
        /*" R0600-00-PROPOSTA-REGISTRO-TP1-SECTION */
        private void R0600_00_PROPOSTA_REGISTRO_TP1_SECTION()
        {
            /*" -1963- MOVE 'R0600-00-PROPOSTA-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0600-00-PROPOSTA-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1966- MOVE SPACES TO REG-CLIENTES, REG-PRP-SASSE. */
            _.Move("", LBFPF011.REG_CLIENTES, REG_PRP_SASSE);

            /*" -1968- MOVE '1' TO R1-TIPO-REG OF REG-CLIENTES */
            _.Move("1", LBFPF011.REG_CLIENTES.R1_TIPO_REG);

            /*" -1970- MOVE RCAPS-NUM-CERTIFICADO TO R1-NUM-PROPOSTA OF REG-CLIENTES */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO, LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA);

            /*" -1972- MOVE CGCCPF OF DCLCLIENTES TO R1-CGC-CPF OF REG-CLIENTES */
            _.Move(CLIENTE.DCLCLIENTES.CGCCPF, LBFPF011.REG_CLIENTES.R1_CGC_CPF);

            /*" -1974- MOVE ZEROS TO R1-DATA-NASCIMENTO OF REG-CLIENTES */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);

            /*" -1977- MOVE NOME-RAZAO OF DCLCLIENTES TO R1-NOME-PESSOA OF REG-CLIENTES. */
            _.Move(CLIENTE.DCLCLIENTES.NOME_RAZAO, LBFPF011.REG_CLIENTES.R1_NOME_PESSOA);

            /*" -1979- MOVE 2 TO R1-TIPO-PESSOA OF REG-CLIENTES. */
            _.Move(2, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);

            /*" -1982- MOVE ZEROS TO R1-NUM-IDENTIDADE OF REG-CLIENTES. */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE);

            /*" -1986- MOVE SPACES TO R1-ORGAO-EXPEDIDOR OF REG-CLIENTES, R1-UF-EXPEDIDORA OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR, LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA);

            /*" -1990- MOVE ZEROS TO R1-ESTADO-CIVIL OF REG-CLIENTES R1-IDE-SEXO OF REG-CLIENTES R1-COD-CBO OF REG-CLIENTES. */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL, LBFPF011.REG_CLIENTES.R1_IDE_SEXO, LBFPF011.REG_CLIENTES.R1_COD_CBO);

            /*" -1993- MOVE ENDERECO-DDD OF DCLENDERECOS TO R1-DDD(2), R1-DDD(3). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_DDD);

            /*" -1996- MOVE ENDERECO-TELEFONE OF DCLENDERECOS TO R1-NUM-FONE(2). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_NUM_FONE);

            /*" -1999- MOVE ENDERECO-FAX OF DCLENDERECOS TO R1-NUM-FONE(3). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_FAX, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE);

            /*" -2003- MOVE ZEROS TO R1-DDD(1) */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_DDD);

            /*" -2007- MOVE ZEROS TO R1-NUM-FONE(1) */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_NUM_FONE);

            /*" -2009- MOVE SPACES TO R1-NOME-CONJUGE OF REG-CLIENTES */
            _.Move("", LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);

            /*" -2011- MOVE ZEROS TO R1-DTNASC-CONJUGE OF REG-CLIENTES */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE);

            /*" -2013- MOVE -1 TO VIND-DTNASC-ESPOSA */
            _.Move(-1, VIND_DTNASC_ESPOSA);

            /*" -2015- MOVE ZEROS TO R1-CBO-CONJUGE OF REG-CLIENTES. */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE);

            /*" -2017- MOVE SPACES TO R1-EMAIL OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_EMAIL);

            /*" -2018- IF VIND-FAIXA-RENDA-IND NOT LESS 0 */

            if (VIND_FAIXA_RENDA_IND >= 0)
            {

                /*" -2021- MOVE PROPOVA-FAIXA-RENDA-IND TO R1-RENDA-INDIVIDUAL OF REG-CLIENTES. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND, LBFPF011.REG_CLIENTES.R1_RENDA_INDIVIDUAL);
            }


            /*" -2022- IF VIND-FAIXA-RENDA-FAM NOT LESS 0 */

            if (VIND_FAIXA_RENDA_FAM >= 0)
            {

                /*" -2025- MOVE PROPOVA-FAIXA-RENDA-FAM TO R1-RENDA-FAMILIAR OF REG-CLIENTES. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM, LBFPF011.REG_CLIENTES.R1_RENDA_FAMILIAR);
            }


            /*" -2027- WRITE REG-PRP-SASSE FROM REG-CLIENTES. */
            _.Move(LBFPF011.REG_CLIENTES.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2027- ADD 1 TO W-QTD-LD-TIPO-1. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_SAIDA*/

        [StopWatch]
        /*" R0650-00-PROPOSTA-REGISTRO-TP2-SECTION */
        private void R0650_00_PROPOSTA_REGISTRO_TP2_SECTION()
        {
            /*" -2039- MOVE 'R0650-00-PROPOSTA-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0650-00-PROPOSTA-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2042- MOVE SPACES TO REG-ENDERECO, REG-PRP-SASSE. */
            _.Move("", LBFPF012.REG_ENDERECO, REG_PRP_SASSE);

            /*" -2044- MOVE '2' TO R2-TIPO-REG OF REG-ENDERECO */
            _.Move("2", LBFPF012.REG_ENDERECO.R2_TIPO_REG);

            /*" -2047- MOVE ENDERECO-COD-ENDERECO OF DCLENDERECOS TO R2-TIPO-ENDER OF REG-ENDERECO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO, LBFPF012.REG_ENDERECO.R2_TIPO_ENDER);

            /*" -2049- MOVE RCAPS-NUM-CERTIFICADO TO R2-NUM-PROPOSTA OF REG-ENDERECO */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO, LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA);

            /*" -2052- MOVE ENDERECO-ENDERECO OF DCLENDERECOS TO R2-ENDERECO OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, LBFPF012.REG_ENDERECO.R2_ENDERECO);

            /*" -2055- MOVE ENDERECO-BAIRRO OF DCLENDERECOS TO R2-BAIRRO OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, LBFPF012.REG_ENDERECO.R2_BAIRRO);

            /*" -2058- MOVE ENDERECO-CIDADE OF DCLENDERECOS TO R2-CIDADE OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, LBFPF012.REG_ENDERECO.R2_CIDADE);

            /*" -2061- MOVE ENDERECO-SIGLA-UF OF DCLENDERECOS TO R2-SIGLA-UF OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, LBFPF012.REG_ENDERECO.R2_SIGLA_UF);

            /*" -2064- MOVE ENDERECO-CEP OF DCLENDERECOS TO R2-CEP OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, LBFPF012.REG_ENDERECO.R2_CEP);

            /*" -2066- WRITE REG-PRP-SASSE FROM REG-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2066- ADD 1 TO W-QTD-LD-TIPO-2. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROPOSTA-REGISTRO-TP3-SECTION */
        private void R0700_00_PROPOSTA_REGISTRO_TP3_SECTION()
        {
            /*" -2077- MOVE 'R0700-00-PROPOSTA-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0700-00-PROPOSTA-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2080- MOVE SPACES TO REG-PROPOSTA-SASSE REG-PRP-SASSE. */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE, REG_PRP_SASSE);

            /*" -2083- MOVE '3' TO R3-TIPO-REG OF REG-PROPOSTA-SASSE */
            _.Move("3", LXFCT004.REG_PROPOSTA_SASSE.R3_TIPO_REG);

            /*" -2086- MOVE RCAPS-NUM-CERTIFICADO TO R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA);

            /*" -2089- MOVE PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

            /*" -2092- MOVE TERMOADE-COD-AGENCIA-OP TO R3-AGECOBR OF REG-PROPOSTA-SASSE. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_OP, LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR);

            /*" -2094- MOVE TERMOADE-DATA-ADESAO TO W-DATA-SQL */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2095- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -2096- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -2097- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -2100- MOVE W-DATA-TRABALHO TO R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA);

            /*" -2101- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 1 OR 2 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2"))
            {

                /*" -2103- MOVE 1 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(1, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2104- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 3 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == 3)
            {

                /*" -2106- MOVE 2 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(2, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2107- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 4 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == 4)
            {

                /*" -2109- MOVE 4 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(4, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2110- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 5 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == 5)
            {

                /*" -2112- MOVE 3 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(3, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2113- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE EQUAL 1 OR 4 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG.In("1", "4"))
            {

                /*" -2116- MOVE OPCPAGVI-DIA-DEBITO TO R3-DIA-DEBITO OF REG-PROPOSTA-SASSE */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO);

                /*" -2117- IF VIND-AGECTADEB LESS 0 */

                if (VIND_AGECTADEB < 0)
                {

                    /*" -2118- MOVE ZEROS TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                    /*" -2119- ELSE */
                }
                else
                {


                    /*" -2121- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                    /*" -2123- END-IF */
                }


                /*" -2124- IF VIND-OPRCTADEB LESS 0 */

                if (VIND_OPRCTADEB < 0)
                {

                    /*" -2125- MOVE ZEROS TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);

                    /*" -2126- ELSE */
                }
                else
                {


                    /*" -2128- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);

                    /*" -2130- END-IF */
                }


                /*" -2131- IF VIND-NUMCTADEB LESS 0 */

                if (VIND_NUMCTADEB < 0)
                {

                    /*" -2132- MOVE ZEROS TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);

                    /*" -2133- ELSE */
                }
                else
                {


                    /*" -2135- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);

                    /*" -2137- END-IF */
                }


                /*" -2138- IF VIND-DIGCTADEB LESS 0 */

                if (VIND_DIGCTADEB < 0)
                {

                    /*" -2139- MOVE ZEROS TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);

                    /*" -2140- ELSE */
                }
                else
                {


                    /*" -2142- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);

                    /*" -2143- END-IF */
                }


                /*" -2144- ELSE */
            }
            else
            {


                /*" -2151- MOVE ZEROS TO R3-AGECTADEB OF REG-PROPOSTA-SASSE R3-OPRCTADEB OF REG-PROPOSTA-SASSE R3-NUMCTADEB OF REG-PROPOSTA-SASSE R3-DIGCTADEB OF REG-PROPOSTA-SASSE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE. */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO);
            }


            /*" -2155- MOVE SPACES TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);

            /*" -2170- MOVE TERMOADE-NUM-MATRICULA-VEN TO R3-NRMATRVEN OF REG-PROPOSTA-SASSE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN, LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN);

            /*" -2174- MOVE SPACES TO R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE R3-RENOVACAO-AUTOM OF REG-PROPOSTA-SASSE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ, LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM);

            /*" -2178- MOVE ZEROS TO R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE);

            /*" -2184- MOVE SPACES TO R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE);

            /*" -2187- MOVE 'MAN' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move("MAN", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

            /*" -2190- MOVE 'PAG' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE. */
            _.Move("PAG", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

            /*" -2193- MOVE ZEROS TO R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO);

            /*" -2196- MOVE TERMOADE-TIPO-COBERTURA TO R3-COBERTURA OF REG-PROPOSTA-SASSE. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_COBERTURA, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER_R.R3_COBERTURA);

            /*" -2197- IF TERMOADE-COD-PLANO-VGAPC GREATER ZEROS */

            if (TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_VGAPC > 00)
            {

                /*" -2199- MOVE TERMOADE-COD-PLANO-VGAPC TO R3-COD-PLANO OF REG-PROPOSTA-SASSE */
                _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_VGAPC, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

                /*" -2200- ELSE */
            }
            else
            {


                /*" -2201- IF TERMOADE-COD-PLANO-APC GREATER ZEROS */

                if (TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_APC > 00)
                {

                    /*" -2203- MOVE TERMOADE-COD-PLANO-APC TO R3-COD-PLANO OF REG-PROPOSTA-SASSE */
                    _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_APC, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

                    /*" -2204- ELSE */
                }
                else
                {


                    /*" -2206- MOVE ZEROS TO R3-COD-PLANO OF REG-PROPOSTA-SASSE. */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);
                }

            }


            /*" -2208- MOVE ZEROS TO R3-COD-PLANO OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

            /*" -2211- MOVE RCAPCOMP-DATA-RCAP OF DCLRCAP-COMPLEMENTAR TO W-DATA-SQL */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2212- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -2213- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -2214- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -2217- MOVE W-DATA-TRABALHO TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

            /*" -2221- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE R3-VALOR-PREMIO-TOTAL OF REG-PROPOSTA-SASSE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL);

            /*" -2224- MOVE RCAPS-AGE-COBRANCA OF DCLRCAPS TO R3-AGEPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO);

            /*" -2227- MOVE VAL-TARIFA OF DCLTARIFA-BALCAO-CEF TO R3-VAL-TARIFA OF REG-PROPOSTA-SASSE. */
            _.Move(TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA);

            /*" -2229- MOVE RCAPS-DATA-MOVIMENTO OF DCLRCAPS TO W-DATA-SQL */
            _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2230- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -2231- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -2232- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -2235- MOVE W-DATA-TRABALHO TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

            /*" -2241- COMPUTE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE = VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA + VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA. */
            LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO.Value = FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG + FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP;

            /*" -2246- MOVE OPCPAGVI-PERI-PAGAMENTO TO R3-PERIPGTO OF REG-PROPOSTA-SASSE */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO, LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO);

            /*" -2249- MOVE RH-NSAS OF REG-HEADER TO R3-NSAS OF REG-PROPOSTA-SASSE. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS);

            /*" -2251- MOVE 6 TO R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(6, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC);

            /*" -2253- ADD 1 TO W-QTD-LD-TIPO-3. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

            /*" -2256- MOVE W-QTD-LD-TIPO-3 TO R3-NSL OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LXFCT004.REG_PROPOSTA_SASSE.R3_NSL);

            /*" -2256- WRITE REG-PRP-SASSE FROM REG-PROPOSTA-SASSE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_SAIDA*/

        [StopWatch]
        /*" R0750-00-PROPOSTA-REGISTRO-TP6-SECTION */
        private void R0750_00_PROPOSTA_REGISTRO_TP6_SECTION()
        {
            /*" -2267- MOVE 'R0750-00-GERA-REGISTRO-TP6' TO PARAGRAFO. */
            _.Move("R0750-00-GERA-REGISTRO-TP6", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2270- MOVE SPACES TO REG-DIVERSOS-VE REG-PRP-SASSE. */
            _.Move("", LBFPF100.REG_DIVERSOS_VE, REG_PRP_SASSE);

            /*" -2273- MOVE '6' TO R6-TIPO-REG OF REG-DIVERSOS-VE */
            _.Move("6", LBFPF100.REG_DIVERSOS_VE.R6_TIPO_REG);

            /*" -2276- MOVE RCAPS-NUM-CERTIFICADO TO R6-NUM-PROPOSTA OF REG-DIVERSOS-VE */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO, LBFPF100.REG_DIVERSOS_VE.R6_NUM_PROPOSTA);

            /*" -2277- IF TERMOADE-PERI-PAGAMENTO EQUAL 1 OR 2 OR 3 */

            if (TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERI_PAGAMENTO.In("1", "2", "3"))
            {

                /*" -2280- MOVE TERMOADE-PERI-PAGAMENTO TO R6-PERI-PAGAMENTO OF REG-DIVERSOS-VE. */
                _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERI_PAGAMENTO, LBFPF100.REG_DIVERSOS_VE.R6_PERI_PAGAMENTO);
            }


            /*" -2281- IF TERMOADE-PERI-PAGAMENTO EQUAL 6 */

            if (TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERI_PAGAMENTO == 6)
            {

                /*" -2283- MOVE 4 TO R6-PERI-PAGAMENTO OF REG-DIVERSOS-VE. */
                _.Move(4, LBFPF100.REG_DIVERSOS_VE.R6_PERI_PAGAMENTO);
            }


            /*" -2284- IF TERMOADE-PERI-PAGAMENTO EQUAL 12 */

            if (TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERI_PAGAMENTO == 12)
            {

                /*" -2288- MOVE 5 TO R6-PERI-PAGAMENTO OF REG-DIVERSOS-VE. */
                _.Move(5, LBFPF100.REG_DIVERSOS_VE.R6_PERI_PAGAMENTO);
            }


            /*" -2290- MOVE 1 TO R6-TIPO-CAPITAL OF REG-DIVERSOS-VE */
            _.Move(1, LBFPF100.REG_DIVERSOS_VE.R6_TIPO_CAPITAL);

            /*" -2299- MOVE SPACE TO R6-COBERTURA-AUX-ALIM OF REG-DIVERSOS-VE R6-COBERTURA-AUX-FUN OF REG-DIVERSOS-VE R6-COBERTURA-MORTE-CONJ OF REG-DIVERSOS-VE R6-COBERTURA-DMH OF REG-DIVERSOS-VE R6-COBERTURA-MQC OF REG-DIVERSOS-VE R6-COBERTURA-MA OF REG-DIVERSOS-VE R6-COBERTURA-IPA OF REG-DIVERSOS-VE. */
            _.Move("", LBFPF100.REG_DIVERSOS_VE.R6_COBERTURA_AUX_ALIM, LBFPF100.REG_DIVERSOS_VE.R6_COBERTURA_AUX_FUN, LBFPF100.REG_DIVERSOS_VE.R6_COBERTURA_MORTE_CONJ, LBFPF100.REG_DIVERSOS_VE.R6_COBERTURA_DMH, LBFPF100.REG_DIVERSOS_VE.R6_COBERTURA_MQC, LBFPF100.REG_DIVERSOS_VE.R6_COBERTURA_MA, LBFPF100.REG_DIVERSOS_VE.R6_COBERTURA_IPA);

            /*" -2300- IF HISCOBPR-IMP-MORNATU GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU > 00)
            {

                /*" -2303- MOVE 'X' TO R6-COBERTURA-MQC OF REG-DIVERSOS-VE. */
                _.Move("X", LBFPF100.REG_DIVERSOS_VE.R6_COBERTURA_MQC);
            }


            /*" -2304- IF HISCOBPR-IMPMORACID GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID > 00)
            {

                /*" -2307- MOVE 'X' TO R6-COBERTURA-MA OF REG-DIVERSOS-VE. */
                _.Move("X", LBFPF100.REG_DIVERSOS_VE.R6_COBERTURA_MA);
            }


            /*" -2308- IF HISCOBPR-IMPINVPERM GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM > 00)
            {

                /*" -2311- MOVE 'X' TO R6-COBERTURA-IPA OF REG-DIVERSOS-VE. */
                _.Move("X", LBFPF100.REG_DIVERSOS_VE.R6_COBERTURA_IPA);
            }


            /*" -2314- MOVE TERMOADE-TIPO-CORRECAO TO R6-TIPO-CORRECAO OF REG-DIVERSOS-VE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_CORRECAO, LBFPF100.REG_DIVERSOS_VE.R6_TIPO_CORRECAO);

            /*" -2317- MOVE TERMOADE-PERIODO-CORRECAO TO R6-PERIODO-CORRECAO OF REG-DIVERSOS-VE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERIODO_CORRECAO, LBFPF100.REG_DIVERSOS_VE.R6_PERIODO_CORRECAO);

            /*" -2320- MOVE TERMOADE-COD-MOEDA-IMP TO R6-COD-MOEDA-IMP OF REG-DIVERSOS-VE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_MOEDA_IMP, LBFPF100.REG_DIVERSOS_VE.R6_COD_MOEDA_IMP);

            /*" -2323- MOVE TERMOADE-COD-MOEDA-PRM TO R6-COD-MOEDA-PRM OF REG-DIVERSOS-VE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_MOEDA_PRM, LBFPF100.REG_DIVERSOS_VE.R6_COD_MOEDA_PRM);

            /*" -2326- MOVE TERMOADE-IND-PLANO-ASSOCIAD TO R6-IND-PLANO-ASSOCIADO OF REG-DIVERSOS-VE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_IND_PLANO_ASSOCIAD, LBFPF100.REG_DIVERSOS_VE.R6_IND_PLANO_ASSOCIADO);

            /*" -2329- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO R6-VALOR-PREMIO OF REG-DIVERSOS-VE */
            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, LBFPF100.REG_DIVERSOS_VE.R6_VALOR_PREMIO);

            /*" -2332- MOVE TERMOADE-QUANT-VIDAS TO R6-QTDE-VIDA-MODULO-1 OF REG-DIVERSOS-VE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_QUANT_VIDAS, LBFPF100.REG_DIVERSOS_VE.R6_QTDE_VIDA_MODULO_1);

            /*" -2335- MOVE TERMOADE-VAL-CONTRATADO TO R6-CAPITAL-MODULO-1 OF REG-DIVERSOS-VE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_CONTRATADO, LBFPF100.REG_DIVERSOS_VE.R6_CAPITAL_MODULO_1);

            /*" -2343- MOVE ZEROS TO R6-QTDE-VIDA-MODULO-2 OF REG-DIVERSOS-VE R6-CAPITAL-MODULO-2 OF REG-DIVERSOS-VE R6-QTDE-VIDA-MODULO-3 OF REG-DIVERSOS-VE R6-CAPITAL-MODULO-3 OF REG-DIVERSOS-VE R6-NUMERO-DO-ORCAMENTO OF REG-DIVERSOS-VE R6-CNAE OF REG-DIVERSOS-VE. */
            _.Move(0, LBFPF100.REG_DIVERSOS_VE.R6_QTDE_VIDA_MODULO_2, LBFPF100.REG_DIVERSOS_VE.R6_CAPITAL_MODULO_2, LBFPF100.REG_DIVERSOS_VE.R6_QTDE_VIDA_MODULO_3, LBFPF100.REG_DIVERSOS_VE.R6_CAPITAL_MODULO_3, LBFPF100.REG_DIVERSOS_VE.R6_NUMERO_DO_ORCAMENTO, LBFPF100.REG_DIVERSOS_VE.R6_CNAE);

            /*" -2345- WRITE REG-PRP-SASSE FROM REG-DIVERSOS-VE. */
            _.Move(LBFPF100.REG_DIVERSOS_VE.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2345- ADD 1 TO W-QTD-LD-TIPO-6. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_6.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_SAIDA*/

        [StopWatch]
        /*" R0800-00-STATUS-REGISTRO-TP1-SECTION */
        private void R0800_00_STATUS_REGISTRO_TP1_SECTION()
        {
            /*" -2356- MOVE 'R0800-00-STATUS-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0800-00-STATUS-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2358- MOVE SPACES TO REG-STA-PROPOSTA. */
            _.Move("", LBFCT011.REG_STA_PROPOSTA);

            /*" -2361- MOVE '1' TO R1-TIPO-REG OF REG-STA-PROPOSTA. */
            _.Move("1", LBFCT011.REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -2364- MOVE RCAPS-NUM-CERTIFICADO TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -2367- MOVE 'EMT' TO R1-SIT-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move("EMT", LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

            /*" -2370- MOVE ZEROS TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA. */
            _.Move(0, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);

            /*" -2373- MOVE TERMOADE-DATA-INCLUSAO TO W-DATA-SQL. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_INCLUSAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2374- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -2375- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -2377- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -2380- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -2382- ADD 1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + 1;

            /*" -2385- MOVE RH-NSAS OF REG-HEADER-STA TO R1-NSAS OF REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, LBFCT011.REG_STA_PROPOSTA.R1_NSAS);

            /*" -2388- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO R1-NSL OF REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, LBFCT011.REG_STA_PROPOSTA.R1_NSL);

            /*" -2388- WRITE REG-STA-SASSE FROM REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-STATUS-REGISTRO-TP2-SECTION */
        private void R0850_00_STATUS_REGISTRO_TP2_SECTION()
        {
            /*" -2399- MOVE 'R0850-00-STATUS-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0850-00-STATUS-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2401- MOVE SPACES TO REG-STA-PROPOSTA. */
            _.Move("", LBFCT011.REG_STA_PROPOSTA);

            /*" -2404- MOVE '2' TO R2-TIPO-REG OF REG-APOL-SASSE */
            _.Move("2", LBFCT016.REG_APOL_SASSE.R2_TIPO_REG);

            /*" -2408- MOVE RCAPS-NUM-CERTIFICADO TO R2-NUM-PROPOSTA OF REG-APOL-SASSE R2-NRCERTIF OF REG-APOL-SASSE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO, LBFCT016.REG_APOL_SASSE.R2_NUM_PROPOSTA, LBFCT016.REG_APOL_SASSE.R2_NRCERTIF);

            /*" -2411- MOVE TERMOADE-DATA-ADESAO TO W-DATA-SQL. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2412- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -2413- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -2415- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -2418- MOVE W-DATA-TRABALHO TO R2-DTINIVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTINIVIG);

            /*" -2421- MOVE '31129999' TO R2-DTTERVIG OF REG-APOL-SASSE. */
            _.Move("31129999", LBFCT016.REG_APOL_SASSE.R2_DTTERVIG);

            /*" -2422- PERFORM R0860-LER-APOLICE */

            R0860_LER_APOLICE_SECTION();

            /*" -2424- PERFORM R0870-LER-RAMOIND */

            R0870_LER_RAMOIND_SECTION();

            /*" -2426- COMPUTE W-IND-IOF = (RAMOCOMP-PCT-IOCC-RAMO / 100) + 1 */
            WAREA_AUXILIAR.W_IND_IOF.Value = (RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f) + 1;

            /*" -2429- COMPUTE W-PRM-LIQ = RCAPS-VAL-RCAP OF DCLRCAPS / W-IND-IOF */
            WAREA_AUXILIAR.W_PRM_LIQ.Value = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP / WAREA_AUXILIAR.W_IND_IOF;

            /*" -2433- COMPUTE R2-VAL-IOF OF REG-APOL-SASSE ROUNDED = RCAPS-VAL-RCAP OF DCLRCAPS - W-PRM-LIQ */
            LBFCT016.REG_APOL_SASSE.R2_VAL_IOF.Value = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP - WAREA_AUXILIAR.W_PRM_LIQ;

            /*" -2435- MOVE W-PRM-LIQ TO R2-VAL-PREMIO OF REG-APOL-SASSE */
            _.Move(WAREA_AUXILIAR.W_PRM_LIQ, LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO);

            /*" -2437- ADD 1 TO RT-QTDE-TIPO-2 OF REG-TRAILLER-STA */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + 1;

            /*" -2437- WRITE REG-STA-SASSE FROM REG-APOL-SASSE. */
            _.Move(LBFCT016.REG_APOL_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R0860-LER-APOLICE-SECTION */
        private void R0860_LER_APOLICE_SECTION()
        {
            /*" -2447- MOVE 'R0860-00-LER-APOLICE' TO PARAGRAFO. */
            _.Move("R0860-00-LER-APOLICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2449- MOVE 'SELECT TABELA APOLICE' TO COMANDO. */
            _.Move("SELECT TABELA APOLICE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2451- MOVE 97010000889 TO APOLICES-NUM-APOLICE. */
            _.Move(97010000889, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -2459- PERFORM R0860_LER_APOLICE_DB_SELECT_1 */

            R0860_LER_APOLICE_DB_SELECT_1();

            /*" -2462- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2463- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -2464- DISPLAY '          ERRO SELECT TABELA APOLICE' */
                _.Display($"          ERRO SELECT TABELA APOLICE");

                /*" -2466- DISPLAY '          NUMERO DO TERMO ADESAO.... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO.... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -2468- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -2469- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2469- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0860-LER-APOLICE-DB-SELECT-1 */
        public void R0860_LER_APOLICE_DB_SELECT_1()
        {
            /*" -2459- EXEC SQL SELECT RAMO_EMISSOR INTO :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE WITH UR END-EXEC. */

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
            /*" -2479- MOVE 'R0870-00-LER-RAMOIND' TO PARAGRAFO. */
            _.Move("R0870-00-LER-RAMOIND", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2481- MOVE 'SELECT TABELA RAMOIND' TO COMANDO. */
            _.Move("SELECT TABELA RAMOIND", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2491- PERFORM R0870_LER_RAMOIND_DB_SELECT_1 */

            R0870_LER_RAMOIND_DB_SELECT_1();

            /*" -2494- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2495- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -2496- DISPLAY '          ERRO SELECT TAB. RAMO COMPLEMENTAR' */
                _.Display($"          ERRO SELECT TAB. RAMO COMPLEMENTAR");

                /*" -2498- DISPLAY '          NUMERO DO TERMO ADESAO.... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO.... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -2500- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -2501- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2501- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0870-LER-RAMOIND-DB-SELECT-1 */
        public void R0870_LER_RAMOIND_DB_SELECT_1()
        {
            /*" -2491- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR AND DATA_INIVIGENCIA <= :TERMOADE-DATA-ADESAO AND DATA_TERVIGENCIA >= :TERMOADE-DATA-ADESAO WITH UR END-EXEC. */

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
            /*" -2512- MOVE 'R0900-00-STATUS-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0900-00-STATUS-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2514- MOVE SPACES TO REG-COBER-SASSE. */
            _.Move("", LBFCT016.REG_COBER_SASSE);

            /*" -2517- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -2520- MOVE RCAPS-NUM-CERTIFICADO TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -2522- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO W-SUBPRODUTO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, WAREA_AUXILIAR.FILLER_3.W_SUBPRODUTO);

            /*" -2523- IF HISCOBPR-IMP-MORNATU GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU > 00)
            {

                /*" -2525- MOVE HISCOBPR-IMP-MORNATU TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -2526- MOVE 1 TO W-COBERTURA */
                _.Move(1, WAREA_AUXILIAR.FILLER_3.W_COBERTURA);

                /*" -2528- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -2530- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -2532- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -2533- IF HISCOBPR-IMPMORACID GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID > 00)
            {

                /*" -2535- MOVE HISCOBPR-IMPMORACID TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -2536- MOVE 2 TO W-COBERTURA */
                _.Move(2, WAREA_AUXILIAR.FILLER_3.W_COBERTURA);

                /*" -2538- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -2540- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -2542- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -2543- IF HISCOBPR-IMPINVPERM GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM > 00)
            {

                /*" -2545- MOVE HISCOBPR-IMPINVPERM TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -2546- MOVE 3 TO W-COBERTURA */
                _.Move(3, WAREA_AUXILIAR.FILLER_3.W_COBERTURA);

                /*" -2548- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -2550- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -2550- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_SAIDA*/

        [StopWatch]
        /*" R0950-00-STATUS-REGISTRO-TP4-SECTION */
        private void R0950_00_STATUS_REGISTRO_TP4_SECTION()
        {
            /*" -2561- MOVE 'R0990-00-STATUS-REGISTRO-TP4' TO PARAGRAFO. */
            _.Move("R0990-00-STATUS-REGISTRO-TP4", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2563- MOVE SPACES TO REG-PGTO-SASSE. */
            _.Move("", LBFCT016.REG_PGTO_SASSE);

            /*" -2566- MOVE '4' TO R4-TIPO-REG OF REG-PGTO-SASSE. */
            _.Move("4", LBFCT016.REG_PGTO_SASSE.R4_TIPO_REG);

            /*" -2569- MOVE RCAPS-NUM-CERTIFICADO TO R4-NUM-PROPOSTA OF REG-PGTO-SASSE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO, LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA);

            /*" -2572- MOVE 'PAG' TO R4-SIT-COBRANCA OF REG-PGTO-SASSE. */
            _.Move("PAG", LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA);

            /*" -2575- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO R4-DATA-SITUACAO OF REG-PGTO-SASSE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO);

            /*" -2577- MOVE 1 TO R4-PARCELAS-PAGAS OF REG-PGTO-SASSE */
            _.Move(1, LBFCT016.REG_PGTO_SASSE.R4_PARCELAS_PAGAS);

            /*" -2580- MOVE ZEROS TO R4-TOTAL-PARCELAS OF REG-PGTO-SASSE */
            _.Move(0, LBFCT016.REG_PGTO_SASSE.R4_TOTAL_PARCELAS);

            /*" -2582- WRITE REG-STA-SASSE FROM REG-PGTO-SASSE. */
            _.Move(LBFCT016.REG_PGTO_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -2582- ADD 1 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_SAIDA*/

        [StopWatch]
        /*" R0970-00-STATUS-REGISTRO-TP5-SECTION */
        private void R0970_00_STATUS_REGISTRO_TP5_SECTION()
        {
            /*" -2593- MOVE 'R0970-00-STATUS-REGISTRO-TP5' TO PARAGRAFO. */
            _.Move("R0970-00-STATUS-REGISTRO-TP5", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2595- MOVE SPACES TO R5-REG-QTDE-VIDAS-VE */
            _.Move("", LBFPF200.R5_REG_QTDE_VIDAS_VE);

            /*" -2598- MOVE '5' TO R5-TIPO-REG OF R5-REG-QTDE-VIDAS-VE */
            _.Move("5", LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_TIPO_REG);

            /*" -2601- MOVE RCAPS-NUM-CERTIFICADO TO R5-NUM-PROPOSTA OF R5-REG-QTDE-VIDAS-VE */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_NUM_PROPOSTA);

            /*" -2604- MOVE TERMOADE-QUANT-VIDAS TO R5-QTDE-VIDAS-MODULO-1 OF R5-REG-QTDE-VIDAS-VE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_QUANT_VIDAS, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_ANTIGO.R5_QTDE_VIDAS_MODULO_1);

            /*" -2607- MOVE TERMOADE-VAL-CONTRATADO TO R5-CAPITAL-MODULO-1 OF R5-REG-QTDE-VIDAS-VE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_CONTRATADO, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_ANTIGO.R5_CAPITAL_MODULO_1);

            /*" -2613- MOVE ZEROS TO R5-QTDE-VIDAS-MODULO-2 OF R5-REG-QTDE-VIDAS-VE R5-CAPITAL-MODULO-2 OF R5-REG-QTDE-VIDAS-VE R5-QTDE-VIDAS-MODULO-3 OF R5-REG-QTDE-VIDAS-VE R5-CAPITAL-MODULO-3 OF R5-REG-QTDE-VIDAS-VE. */
            _.Move(0, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_ANTIGO.R5_QTDE_VIDAS_MODULO_2, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_ANTIGO.R5_CAPITAL_MODULO_2, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_ANTIGO.R5_QTDE_VIDAS_MODULO_3, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_ANTIGO.R5_CAPITAL_MODULO_3);

            /*" -2616- MOVE TERMOADE-DATA-ADESAO TO W-DATA-SQL. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2617- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -2618- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -2620- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -2623- MOVE W-DATA-TRABALHO TO R5-DATA-ATUALIZACAO OF R5-REG-QTDE-VIDAS-VE */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_ANTIGO.R5_DATA_ATUALIZACAO);

            /*" -2625- WRITE REG-STA-SASSE FROM R5-REG-QTDE-VIDAS-VE */
            _.Move(LBFPF200.R5_REG_QTDE_VIDAS_VE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -2625- ADD 1 TO RT-QTDE-TIPO-5 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0970_SAIDA*/

        [StopWatch]
        /*" R1000-00-GERAR-TRAILLER-SECTION */
        private void R1000_00_GERAR_TRAILLER_SECTION()
        {
            /*" -2635- MOVE 'R1000-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R1000-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2637- MOVE 'WRITE REG-TRAILLER - PROPOSTA' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER - PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2639- MOVE SPACES TO REG-PRP-SASSE */
            _.Move("", REG_PRP_SASSE);

            /*" -2642- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER. */
            _.Move("T", LBFPF991.REG_TRAILLER.RT_TIPO_REG);

            /*" -2645- MOVE 'PRPSASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER. */
            _.Move("PRPSASSE", LBFPF991.REG_TRAILLER.RT_NOME_EMPRESA);

            /*" -2648- MOVE W-QTD-LD-TIPO-0 TO RT-QTDE-TIPO-0 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_0, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0);

            /*" -2651- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1);

            /*" -2654- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2);

            /*" -2657- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3);

            /*" -2660- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4);

            /*" -2663- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_5, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5);

            /*" -2666- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_6, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6);

            /*" -2669- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_7, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7);

            /*" -2672- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_8, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8);

            /*" -2675- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_9, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9);

            /*" -2678- MOVE W-QTD-LD-TIPO-A TO RT-QTDE-TIPO-A OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_A, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A);

            /*" -2681- MOVE W-QTD-LD-TIPO-B TO RT-QTDE-TIPO-B OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_B, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B);

            /*" -2684- MOVE W-QTD-LD-TIPO-C TO RT-QTDE-TIPO-C OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_C, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C);

            /*" -2687- MOVE W-QTD-LD-TIPO-D TO RT-QTDE-TIPO-D OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_D, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D);

            /*" -2690- MOVE W-QTD-LD-TIPO-E TO RT-QTDE-TIPO-E OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_E, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E);

            /*" -2693- MOVE W-QTD-LD-TIPO-F TO RT-QTDE-TIPO-F OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_F, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F);

            /*" -2696- MOVE W-QTD-LD-TIPO-G TO RT-QTDE-TIPO-G OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_G, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G);

            /*" -2699- MOVE W-QTD-LD-TIPO-H TO RT-QTDE-TIPO-H OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_H, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H);

            /*" -2702- MOVE W-QTD-LD-TIPO-I TO RT-QTDE-TIPO-I OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_I, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I);

            /*" -2705- MOVE W-QTD-LD-TIPO-J TO RT-QTDE-TIPO-J OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_J, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J);

            /*" -2727- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER = RT-QTDE-TIPO-0 OF REG-TRAILLER + RT-QTDE-TIPO-1 OF REG-TRAILLER + RT-QTDE-TIPO-2 OF REG-TRAILLER + RT-QTDE-TIPO-3 OF REG-TRAILLER + RT-QTDE-TIPO-4 OF REG-TRAILLER + RT-QTDE-TIPO-5 OF REG-TRAILLER + RT-QTDE-TIPO-6 OF REG-TRAILLER + RT-QTDE-TIPO-7 OF REG-TRAILLER + RT-QTDE-TIPO-8 OF REG-TRAILLER + RT-QTDE-TIPO-9 OF REG-TRAILLER + RT-QTDE-TIPO-A OF REG-TRAILLER + RT-QTDE-TIPO-B OF REG-TRAILLER + RT-QTDE-TIPO-C OF REG-TRAILLER + RT-QTDE-TIPO-D OF REG-TRAILLER + RT-QTDE-TIPO-E OF REG-TRAILLER + RT-QTDE-TIPO-F OF REG-TRAILLER + RT-QTDE-TIPO-G OF REG-TRAILLER + RT-QTDE-TIPO-H OF REG-TRAILLER + RT-QTDE-TIPO-I OF REG-TRAILLER + RT-QTDE-TIPO-J OF REG-TRAILLER */
            LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL.Value = LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J;

            /*" -2731- WRITE REG-PRP-SASSE FROM REG-TRAILLER. */
            _.Move(LBFPF991.REG_TRAILLER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2733- MOVE 'WRITE REG-TRAILLER - STATUS' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER - STATUS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2735- MOVE SPACES TO REG-STA-SASSE. */
            _.Move("", REG_STA_SASSE);

            /*" -2738- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -2741- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -2752- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 OF REG-TRAILLER-STA + RT-QTDE-TIPO-2 OF REG-TRAILLER-STA + RT-QTDE-TIPO-3 OF REG-TRAILLER-STA + RT-QTDE-TIPO-4 OF REG-TRAILLER-STA + RT-QTDE-TIPO-5 OF REG-TRAILLER-STA + RT-QTDE-TIPO-6 OF REG-TRAILLER-STA + RT-QTDE-TIPO-7 OF REG-TRAILLER-STA + RT-QTDE-TIPO-8 OF REG-TRAILLER-STA + RT-QTDE-TIPO-9 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -2752- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -2762- MOVE 'R1050-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R1050-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2764- MOVE 'INSERT ARQUIVOS-SIVPF - PROPOSTA' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF - PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2767- MOVE 'PRPSASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("PRPSASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -2770- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -2774- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -2777- MOVE RT-QTDE-TOTAL OF REG-TRAILLER TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -2780- MOVE RH-NSAS OF REG-HEADER TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -2788- PERFORM R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -2791- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2792- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -2793- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -2795- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -2797- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -2799- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -2801- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -2803- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -2804- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2808- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2810- MOVE 'INSERT ARQUIVOS-SIVPF - STATUS' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF - STATUS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2813- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -2816- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -2820- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -2823- MOVE RH-NSAS OF REG-HEADER-STA TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -2826- MOVE RT-QTDE-TOTAL OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -2834- PERFORM R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2 */

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2();

            /*" -2837- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2838- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -2839- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -2841- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -2843- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -2845- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -2847- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -2849- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -2850- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2850- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -2788- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-2 */
        public void R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2()
        {
            /*" -2834- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2_Insert1 = new R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2_Insert1.Execute(r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1100-00-GERAR-TOTAIS-SECTION */
        private void R1100_00_GERAR_TOTAIS_SECTION()
        {
            /*" -2861- MOVE 'R1100-00-GERAR-TOTAIS' TO PARAGRAFO. */
            _.Move("R1100-00-GERAR-TOTAIS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2863- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2883- COMPUTE W-TOT-GERADO-PRP = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J. */
            WAREA_AUXILIAR.W_TOT_GERADO_PRP.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9 + WAREA_AUXILIAR.W_QTD_LD_TIPO_A + WAREA_AUXILIAR.W_QTD_LD_TIPO_B + WAREA_AUXILIAR.W_QTD_LD_TIPO_C + WAREA_AUXILIAR.W_QTD_LD_TIPO_D + WAREA_AUXILIAR.W_QTD_LD_TIPO_E + WAREA_AUXILIAR.W_QTD_LD_TIPO_F + WAREA_AUXILIAR.W_QTD_LD_TIPO_G + WAREA_AUXILIAR.W_QTD_LD_TIPO_H + WAREA_AUXILIAR.W_QTD_LD_TIPO_I + WAREA_AUXILIAR.W_QTD_LD_TIPO_J;

            /*" -2884- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2885- DISPLAY 'PF0623B - TOTAIS DO PROCESSAMENTO' . */
            _.Display($"PF0623B - TOTAIS DO PROCESSAMENTO");

            /*" -2887- DISPLAY '          TOTAL  REGISTROS LIDOS........... ' W-NSL. */
            _.Display($"          TOTAL  REGISTROS LIDOS........... {WAREA_AUXILIAR.W_NSL}");

            /*" -2889- DISPLAY '          TOTAL  DESPREZADO................ ' W-DESPREZADO. */
            _.Display($"          TOTAL  DESPREZADO................ {WAREA_AUXILIAR.W_DESPREZADO}");

            /*" -2891- DISPLAY '          TOTAL  GERADO ARQUIVO PROPOSTA... ' RT-QTDE-TIPO-1 OF REG-TRAILLER. */
            _.Display($"          TOTAL  GERADO ARQUIVO PROPOSTA... {LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1}");

            /*" -2892- DISPLAY '          TOTAL  GERADO ARQUIVO STATUS..... ' RT-QTDE-TIPO-1 OF REG-TRAILLER-STA. */
            _.Display($"          TOTAL  GERADO ARQUIVO STATUS..... {LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R1110-00-UPDATE-RELATORIOS-SECTION */
        private void R1110_00_UPDATE_RELATORIOS_SECTION()
        {
            /*" -2901- MOVE 'R1110-00-UPDATE-RELATORIOS' TO PARAGRAFO. */
            _.Move("R1110-00-UPDATE-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2903- MOVE 'UPDATE RELATORIOS' TO COMANDO. */
            _.Move("UPDATE RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2909- PERFORM R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1 */

            R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1();

            /*" -2912- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2913- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -2914- DISPLAY '          ERRO UPDATE RELATORIOS' */
                _.Display($"          ERRO UPDATE RELATORIOS");

                /*" -2916- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -2917- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2917- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1110-00-UPDATE-RELATORIOS-DB-UPDATE-1 */
        public void R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1()
        {
            /*" -2909- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_REFERENCIA = :WHOST-DATA-REFERENCIA, TIMESTAMP = CURRENT TIMESTAMP WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0623B' END-EXEC. */

            var r1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 = new R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1()
            {
                WHOST_DATA_REFERENCIA = WHOST_DATA_REFERENCIA.ToString(),
            };

            R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1.Execute(r1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_SAIDA*/

        [StopWatch]
        /*" R3000-GERAR-TB-CORPORATIVAS-SECTION */
        private void R3000_GERAR_TB_CORPORATIVAS_SECTION()
        {
            /*" -2927- PERFORM R3100-TRATA-CLIENTE. */

            R3100_TRATA_CLIENTE_SECTION();

            /*" -2928- PERFORM R3200-TRATA-END-TEL */

            R3200_TRATA_END_TEL_SECTION();

            /*" -2928- PERFORM R3300-TRATA-PROPOSTA. */

            R3300_TRATA_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_SAIDA*/

        [StopWatch]
        /*" R3100-TRATA-CLIENTE-SECTION */
        private void R3100_TRATA_CLIENTE_SECTION()
        {
            /*" -2938- MOVE 'R3100-TRATA-CLIENTE' TO PARAGRAFO. */
            _.Move("R3100-TRATA-CLIENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2948- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2950- PERFORM R3110-LER-PESSOA-JURIDICA. */

            R3110_LER_PESSOA_JURIDICA_SECTION();

            /*" -2951- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2952- PERFORM R3115-INCLUIR-TAB-CORPORATIVAS */

                R3115_INCLUIR_TAB_CORPORATIVAS_SECTION();

                /*" -2953- ELSE */
            }
            else
            {


                /*" -2954- IF SQLCODE EQUAL 00 */

                if (DB.SQLCODE == 00)
                {

                    /*" -2957- PERFORM R3150-LER-TAB-CORPORATIVAS */

                    R3150_LER_TAB_CORPORATIVAS_SECTION();

                    /*" -2957- PERFORM R3135-INCLUIR-END-EMAIL. */

                    R3135_INCLUIR_END_EMAIL_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_SAIDA*/

        [StopWatch]
        /*" R3110-LER-PESSOA-JURIDICA-SECTION */
        private void R3110_LER_PESSOA_JURIDICA_SECTION()
        {
            /*" -2967- MOVE 'R3110-LER-PESSOA-JURIDICA' TO PARAGRAFO. */
            _.Move("R3110-LER-PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2969- MOVE 'SELECT' TO COMANDO. */
            _.Move("SELECT", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2972- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -2986- PERFORM R3110_LER_PESSOA_JURIDICA_DB_SELECT_1 */

            R3110_LER_PESSOA_JURIDICA_DB_SELECT_1();

            /*" -2989- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2990- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -2991- DISPLAY '          ERRO NO ACESSO A PESSOA-JURIDICA' */
                _.Display($"          ERRO NO ACESSO A PESSOA-JURIDICA");

                /*" -2993- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2995- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2996- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2996- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3110-LER-PESSOA-JURIDICA-DB-SELECT-1 */
        public void R3110_LER_PESSOA_JURIDICA_DB_SELECT_1()
        {
            /*" -2986- EXEC SQL SELECT COD_PESSOA, CGC, NOME_FANTASIA, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, :DCLPESSOA-JURIDICA.TIMESTAMP FROM SEGUROS.PESSOA_JURIDICA WHERE CGC = :DCLPESSOA-JURIDICA.CGC WITH UR END-EXEC. */

            var r3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1 = new R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1()
            {
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
            };

            var executed_1 = R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1.Execute(r3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);
                _.Move(executed_1.CGC, PESJUR.DCLPESSOA_JURIDICA.CGC);
                _.Move(executed_1.NOME_FANTASIA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);
                _.Move(executed_1.COD_USUARIO, PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);
                _.Move(executed_1.TIMESTAMP, PESJUR.DCLPESSOA_JURIDICA.TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_SAIDA*/

        [StopWatch]
        /*" R3115-INCLUIR-TAB-CORPORATIVAS-SECTION */
        private void R3115_INCLUIR_TAB_CORPORATIVAS_SECTION()
        {
            /*" -3005- MOVE 'R3115-INCLUIR-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R3115-INCLUIR-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3007- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3009- PERFORM R3120-INCLUIR-TAB-PESSOA. */

            R3120_INCLUIR_TAB_PESSOA_SECTION();

            /*" -3011- PERFORM R3130-INCLUIR-PESSOA-JURIDICA. */

            R3130_INCLUIR_PESSOA_JURIDICA_SECTION();

            /*" -3011- PERFORM R3135-INCLUIR-END-EMAIL. */

            R3135_INCLUIR_END_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3115_SAIDA*/

        [StopWatch]
        /*" R3120-INCLUIR-TAB-PESSOA-SECTION */
        private void R3120_INCLUIR_TAB_PESSOA_SECTION()
        {
            /*" -3021- MOVE 'R3120-INCLUIR-TAB-PESSOA' TO PARAGRAFO. */
            _.Move("R3120-INCLUIR-TAB-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3023- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3024- IF W-OBTER-MAX-PESSOA EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_OBTER_MAX_PESSOA == "NAO")
            {

                /*" -3025- MOVE 'SIM' TO W-OBTER-MAX-PESSOA */
                _.Move("SIM", WAREA_AUXILIAR.W_OBTER_MAX_PESSOA);

                /*" -3027- PERFORM R3121-OBTER-MAX-COD-PESSOA. */

                R3121_OBTER_MAX_COD_PESSOA_SECTION();
            }


            /*" -3030- COMPUTE W-COD-PESSOA = W-COD-PESSOA + 1 */
            WAREA_AUXILIAR.W_COD_PESSOA.Value = WAREA_AUXILIAR.W_COD_PESSOA + 1;

            /*" -3033- MOVE W-COD-PESSOA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
            _.Move(WAREA_AUXILIAR.W_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

            /*" -3036- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO PESSOA-NOME-PESSOA OF DCLPESSOA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -3039- MOVE ' ' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
            _.Move(" ", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

            /*" -3040- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -3042- MOVE 'F' TO PESSOA-TIPO-PESSOA OF DCLPESSOA */
                _.Move("F", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

                /*" -3043- ELSE */
            }
            else
            {


                /*" -3044- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 2)
                {

                    /*" -3047- MOVE 'J' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
                    _.Move("J", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                }

            }


            /*" -3050- MOVE 'PF0623B' TO PESSOA-COD-USUARIO OF DCLPESSOA. */
            _.Move("PF0623B", PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);

            /*" -3058- PERFORM R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1 */

            R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1();

            /*" -3061- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3062- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3063- DISPLAY '          ERRO INSERT DA TABELA PESSOA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA");

                /*" -3065- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -3067- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -3069- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3071- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3072- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3072- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3120-INCLUIR-TAB-PESSOA-DB-INSERT-1 */
        public void R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1()
        {
            /*" -3058- EXEC SQL INSERT INTO SEGUROS.PESSOA VALUES (:DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, CURRENT TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO, :DCLPESSOA.PESSOA-TIPO-PESSOA, NULL) END-EXEC. */

            var r3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1 = new R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                PESSOA_COD_USUARIO = PESSOA.DCLPESSOA.PESSOA_COD_USUARIO.ToString(),
                PESSOA_TIPO_PESSOA = PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA.ToString(),
            };

            R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1.Execute(r3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_SAIDA*/

        [StopWatch]
        /*" R3121-OBTER-MAX-COD-PESSOA-SECTION */
        private void R3121_OBTER_MAX_COD_PESSOA_SECTION()
        {
            /*" -3082- MOVE 'R3121-OBTER-MAX-COD-PESSOA' TO PARAGRAFO. */
            _.Move("R3121-OBTER-MAX-COD-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3084- MOVE 'MAX SEGUROS.PESSOA' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3089- PERFORM R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1 */

            R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1();

            /*" -3092- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3093- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3094- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA");

                /*" -3096- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3098- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3099- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3101- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3102- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO W-COD-PESSOA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, WAREA_AUXILIAR.W_COD_PESSOA);

        }

        [StopWatch]
        /*" R3121-OBTER-MAX-COD-PESSOA-DB-SELECT-1 */
        public void R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1()
        {
            /*" -3089- EXEC SQL SELECT VALUE(MAX(COD_PESSOA),0) INTO :DCLPESSOA.PESSOA-COD-PESSOA FROM SEGUROS.PESSOA WITH UR END-EXEC. */

            var r3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1 = new R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1.Execute(r3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3121_SAIDA*/

        [StopWatch]
        /*" R3130-INCLUIR-PESSOA-JURIDICA-SECTION */
        private void R3130_INCLUIR_PESSOA_JURIDICA_SECTION()
        {
            /*" -3112- MOVE 'R3130-INCLUIR-PESSOAS-JURIDICA' TO PARAGRAFO. */
            _.Move("R3130-INCLUIR-PESSOAS-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3114- MOVE 'INSERT PESSOA-JURIDICA' TO COMANDO. */
            _.Move("INSERT PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3117- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-JURIDICA */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);

            /*" -3120- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -3123- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO NOME-FANTASIA OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);

            /*" -3127- MOVE 'PF0623B' TO COD-USUARIO OF DCLPESSOA-JURIDICA */
            _.Move("PF0623B", PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);

            /*" -3134- PERFORM R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1 */

            R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1();

            /*" -3137- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3138- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3139- DISPLAY '          ERRO INSERT DA TABELA PESSOA JURIDICA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA JURIDICA");

                /*" -3141- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-JURIDICA */
                _.Display($"          CODIGO PESSOA.................  {PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA}");

                /*" -3143- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3145- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3146- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3146- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3130-INCLUIR-PESSOA-JURIDICA-DB-INSERT-1 */
        public void R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1()
        {
            /*" -3134- EXEC SQL INSERT INTO SEGUROS.PESSOA_JURIDICA VALUES (:DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1 = new R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA.ToString(),
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
                NOME_FANTASIA = PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA.ToString(),
                COD_USUARIO = PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO.ToString(),
            };

            R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1.Execute(r3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3130_SAIDA*/

        [StopWatch]
        /*" R3136-RELACIONA-EMAIL-SECTION */
        private void R3136_RELACIONA_EMAIL_SECTION()
        {
            /*" -3156- MOVE 'R3136-RELACIONA-EMAIL' TO PARAGRAFO. */
            _.Move("R3136-RELACIONA-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3158- MOVE 'DECLARE PESSOA-EMAIL' TO COMANDO. */
            _.Move("DECLARE PESSOA-EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3161- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -3171- PERFORM R3136_RELACIONA_EMAIL_DB_DECLARE_1 */

            R3136_RELACIONA_EMAIL_DB_DECLARE_1();

            /*" -3175- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3176- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3177- DISPLAY '          ERRO DECLARE DA TABELA PESSOA EMAIL' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA EMAIL");

                /*" -3179- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -3181- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3183- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3184- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3184- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3136_SAIDA*/

        [StopWatch]
        /*" R3135-INCLUIR-END-EMAIL-SECTION */
        private void R3135_INCLUIR_END_EMAIL_SECTION()
        {
            /*" -3193- MOVE 'R3135-INCLUIR-END-EMAIL' TO PARAGRAFO. */
            _.Move("R3135-INCLUIR-END-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3195- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3197- PERFORM R3136-RELACIONA-EMAIL. */

            R3136_RELACIONA_EMAIL_SECTION();

            /*" -3199- MOVE 'OPEN CURSOR EMAIL' TO COMANDO. */
            _.Move("OPEN CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3199- PERFORM R3135_INCLUIR_END_EMAIL_DB_OPEN_1 */

            R3135_INCLUIR_END_EMAIL_DB_OPEN_1();

            /*" -3203- MOVE 'NAO' TO W-ACHOU-EMAIL. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_EMAIL);

            /*" -3205- MOVE SPACES TO W-FIM-CURSOR-EMAIL. */
            _.Move("", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

            /*" -3207- PERFORM R3137-FETCH-EMAIL */

            R3137_FETCH_EMAIL_SECTION();

            /*" -3208- IF W-FIM-CURSOR-EMAIL EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM")
            {

                /*" -3209- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

                if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
                {

                    /*" -3211- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                    _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
                }

            }


            /*" -3214- PERFORM R3138-VERIFICA-EXISTE-EMAIL UNTIL W-FIM-CURSOR-EMAIL EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM"))
            {

                R3138_VERIFICA_EXISTE_EMAIL_SECTION();
            }

            /*" -3215- IF W-ACHOU-EMAIL EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_EMAIL == "NAO")
            {

                /*" -3215- PERFORM R3139-INCLUIR-NOVO-EMAIL. */

                R3139_INCLUIR_NOVO_EMAIL_SECTION();
            }


        }

        [StopWatch]
        /*" R3135-INCLUIR-END-EMAIL-DB-OPEN-1 */
        public void R3135_INCLUIR_END_EMAIL_DB_OPEN_1()
        {
            /*" -3199- EXEC SQL OPEN EMAIL END-EXEC. */

            EMAIL.Open();

        }

        [StopWatch]
        /*" R3205-RELACIONA-ENDERECO-DB-DECLARE-1 */
        public void R3205_RELACIONA_ENDERECO_DB_DECLARE_1()
        {
            /*" -3560- EXEC SQL DECLARE ENDERECOS CURSOR FOR SELECT OCORR_ENDERECO, COD_PESSOA, ENDERECO, TIPO_ENDER, BAIRRO, CEP, CIDADE, SIGLA_UF, SITUACAO_ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA-ENDERECO.COD-PESSOA ORDER BY OCORR_ENDERECO WITH UR END-EXEC. */
            ENDERECOS = new PF0623B_ENDERECOS(true);
            string GetQuery_ENDERECOS()
            {
                var query = @$"SELECT OCORR_ENDERECO
							, 
							COD_PESSOA
							, 
							ENDERECO
							, 
							TIPO_ENDER
							, 
							BAIRRO
							, 
							CEP
							, 
							CIDADE
							, 
							SIGLA_UF
							, 
							SITUACAO_ENDERECO 
							FROM SEGUROS.PESSOA_ENDERECO 
							WHERE COD_PESSOA = '{PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}' 
							ORDER BY OCORR_ENDERECO";

                return query;
            }
            ENDERECOS.GetQueryEvent += GetQuery_ENDERECOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3135_SAIDA*/

        [StopWatch]
        /*" R3137-FETCH-EMAIL-SECTION */
        private void R3137_FETCH_EMAIL_SECTION()
        {
            /*" -3225- MOVE 'R3137-FETCH-EMAIL' TO PARAGRAFO. */
            _.Move("R3137-FETCH-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3227- MOVE 'FETCH CURSOR EMAIL' TO COMANDO. */
            _.Move("FETCH CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3233- PERFORM R3137_FETCH_EMAIL_DB_FETCH_1 */

            R3137_FETCH_EMAIL_DB_FETCH_1();

            /*" -3236- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3237- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3238- MOVE 'SIM' TO W-FIM-CURSOR-EMAIL */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

                    /*" -3238- PERFORM R3137_FETCH_EMAIL_DB_CLOSE_1 */

                    R3137_FETCH_EMAIL_DB_CLOSE_1();

                    /*" -3240- ELSE */
                }
                else
                {


                    /*" -3241- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -3242- DISPLAY '          ERRO FETCH CURSOR EMAIL' */
                    _.Display($"          ERRO FETCH CURSOR EMAIL");

                    /*" -3244- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                    _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                    /*" -3246- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -3248- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3249- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3249- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3137-FETCH-EMAIL-DB-FETCH-1 */
        public void R3137_FETCH_EMAIL_DB_FETCH_1()
        {
            /*" -3233- EXEC SQL FETCH EMAIL INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL END-EXEC. */

            if (EMAIL.Fetch())
            {
                _.Move(EMAIL.DCLPESSOA_EMAIL_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);
                _.Move(EMAIL.DCLPESSOA_EMAIL_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
                _.Move(EMAIL.DCLPESSOA_EMAIL_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
                _.Move(EMAIL.DCLPESSOA_EMAIL_SITUACAO_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);
            }

        }

        [StopWatch]
        /*" R3137-FETCH-EMAIL-DB-CLOSE-1 */
        public void R3137_FETCH_EMAIL_DB_CLOSE_1()
        {
            /*" -3238- EXEC SQL CLOSE EMAIL END-EXEC */

            EMAIL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3137_SAIDA*/

        [StopWatch]
        /*" R3138-VERIFICA-EXISTE-EMAIL-SECTION */
        private void R3138_VERIFICA_EXISTE_EMAIL_SECTION()
        {
            /*" -3259- MOVE 'R3138-VERIFICA-EXISTE-EMAIL' TO PARAGRAFO. */
            _.Move("R3138-VERIFICA-EXISTE-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3261- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3263- IF R1-EMAIL OF REG-CLIENTES EQUAL EMAIL OF DCLPESSOA-EMAIL */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL == PESEMAIL.DCLPESSOA_EMAIL.EMAIL)
            {

                /*" -3265- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -3266- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
            {

                /*" -3268- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -3268- PERFORM R3137-FETCH-EMAIL. */

            R3137_FETCH_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3138_SAIDA*/

        [StopWatch]
        /*" R3139-INCLUIR-NOVO-EMAIL-SECTION */
        private void R3139_INCLUIR_NOVO_EMAIL_SECTION()
        {
            /*" -3278- MOVE 'R3139-INCLUIR-NOVO-EMAIL' TO PARAGRAFO. */
            _.Move("R3139-INCLUIR-NOVO-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3287- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3290- MOVE SEQ-EMAIL OF DCLPESSOA-EMAIL TO W-SEQ-EMAIL */
            _.Move(PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL, WAREA_AUXILIAR.W_SEQ_EMAIL);

            /*" -3292- COMPUTE W-SEQ-EMAIL = W-SEQ-EMAIL + 1. */
            WAREA_AUXILIAR.W_SEQ_EMAIL.Value = WAREA_AUXILIAR.W_SEQ_EMAIL + 1;

            /*" -3292- PERFORM R3141-INCLUIR-EMAIL. */

            R3141_INCLUIR_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3139_SAIDA*/

        [StopWatch]
        /*" R3140-OBTER-MAX-EMAIL-SECTION */
        private void R3140_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -3302- MOVE 'R3140-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R3140-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3304- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3307- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -3313- PERFORM R3140_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R3140_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -3316- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3317- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3318- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -3320- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3322- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3323- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3323- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3140-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R3140_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -3313- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

            var r3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 = new R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
            };

            var executed_1 = R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1.Execute(r3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3140_SAIDA*/

        [StopWatch]
        /*" R3141-INCLUIR-EMAIL-SECTION */
        private void R3141_INCLUIR_EMAIL_SECTION()
        {
            /*" -3332- MOVE 'R3141-INCLUI-EMAIL' TO PARAGRAFO. */
            _.Move("R3141-INCLUI-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3334- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3337- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -3340- MOVE W-SEQ-EMAIL TO SEQ-EMAIL OF DCLPESSOA-EMAIL. */
            _.Move(WAREA_AUXILIAR.W_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);

            /*" -3343- MOVE R1-EMAIL OF REG-CLIENTES TO EMAIL OF DCLPESSOA-EMAIL */
            _.Move(LBFPF011.REG_CLIENTES.R1_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);

            /*" -3346- MOVE 'A' TO SITUACAO-EMAIL OF DCLPESSOA-EMAIL */
            _.Move("A", PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);

            /*" -3350- MOVE 'PF0623B' TO COD-USUARIO OF DCLPESSOA-EMAIL. */
            _.Move("PF0623B", PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);

            /*" -3358- PERFORM R3141_INCLUIR_EMAIL_DB_INSERT_1 */

            R3141_INCLUIR_EMAIL_DB_INSERT_1();

            /*" -3361- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3362- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3363- DISPLAY '          ERRO INSERT DA TABELA PESSOA-EMAIL' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA-EMAIL");

                /*" -3365- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -3367- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -3369- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3371- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3372- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3372- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3141-INCLUIR-EMAIL-DB-INSERT-1 */
        public void R3141_INCLUIR_EMAIL_DB_INSERT_1()
        {
            /*" -3358- EXEC SQL INSERT INTO SEGUROS.PESSOA_EMAIL VALUES (:DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1 = new R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
                EMAIL = PESEMAIL.DCLPESSOA_EMAIL.EMAIL.ToString(),
                SITUACAO_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL.ToString(),
                COD_USUARIO = PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO.ToString(),
            };

            R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1.Execute(r3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3141_SAIDA*/

        [StopWatch]
        /*" R3150-LER-TAB-CORPORATIVAS-SECTION */
        private void R3150_LER_TAB_CORPORATIVAS_SECTION()
        {
            /*" -3382- MOVE 'R3150-LER-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R3150-LER-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3384- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3387- MOVE COD-PESSOA OF DCLPESSOA-JURIDICA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
            _.Move(PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

            /*" -3389- PERFORM R3155-LER-TAB-PESSOA. */

            R3155_LER_TAB_PESSOA_SECTION();

            /*" -3389- PERFORM R3160-LER-TAB-EMAIL. */

            R3160_LER_TAB_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_SAIDA*/

        [StopWatch]
        /*" R3155-LER-TAB-PESSOA-SECTION */
        private void R3155_LER_TAB_PESSOA_SECTION()
        {
            /*" -3399- MOVE 'R3150-LER-TAB-PESSOAS' TO PARAGRAFO. */
            _.Move("R3150-LER-TAB-PESSOAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3401- MOVE 'SELECT SEGUROS.PESSOAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3415- PERFORM R3155_LER_TAB_PESSOA_DB_SELECT_1 */

            R3155_LER_TAB_PESSOA_DB_SELECT_1();

            /*" -3418- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3419- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3420- DISPLAY '          ERRO ACESSO TAB. SEGUROS.PESSOA' */
                _.Display($"          ERRO ACESSO TAB. SEGUROS.PESSOA");

                /*" -3422- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -3424- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3425- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3425- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3155-LER-TAB-PESSOA-DB-SELECT-1 */
        public void R3155_LER_TAB_PESSOA_DB_SELECT_1()
        {
            /*" -3415- EXEC SQL SELECT COD_PESSOA, NOME_PESSOA, TIPO_PESSOA, TIMESTAMP, COD_USUARIO INTO :DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, :DCLPESSOA.PESSOA-TIPO-PESSOA, :DCLPESSOA.PESSOA-TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO FROM SEGUROS.PESSOA WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA WITH UR END-EXEC. */

            var r3155_LER_TAB_PESSOA_DB_SELECT_1_Query1 = new R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1.Execute(r3155_LER_TAB_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
                _.Move(executed_1.PESSOA_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);
                _.Move(executed_1.PESSOA_TIPO_PESSOA, PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                _.Move(executed_1.PESSOA_TIMESTAMP, PESSOA.DCLPESSOA.PESSOA_TIMESTAMP);
                _.Move(executed_1.PESSOA_COD_USUARIO, PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3155_SAIDA*/

        [StopWatch]
        /*" R3160-LER-TAB-EMAIL-SECTION */
        private void R3160_LER_TAB_EMAIL_SECTION()
        {
            /*" -3434- MOVE 'R3160-LER-TAB-EMAIL' TO PARAGRAFO. */
            _.Move("R3160-LER-TAB-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3436- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3438- PERFORM R3165-OBTER-MAX-EMAIL. */

            R3165_OBTER_MAX_EMAIL_SECTION();

            /*" -3438- PERFORM R3170-LER-EMAIL-ATUAL. */

            R3170_LER_EMAIL_ATUAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3160_SAIDA*/

        [StopWatch]
        /*" R3165-OBTER-MAX-EMAIL-SECTION */
        private void R3165_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -3448- MOVE 'R3165-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R3165-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3450- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3453- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -3459- PERFORM R3165_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R3165_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -3462- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3463- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3464- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -3466- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -3468- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3469- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3469- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3165-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R3165_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -3459- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

            var r3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 = new R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
            };

            var executed_1 = R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1.Execute(r3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3165_SAIDA*/

        [StopWatch]
        /*" R3170-LER-EMAIL-ATUAL-SECTION */
        private void R3170_LER_EMAIL_ATUAL_SECTION()
        {
            /*" -3479- MOVE 'R3170-LER-EMAIL-ATUAL' TO PARAGRAFO. */
            _.Move("R3170-LER-EMAIL-ATUAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3481- MOVE 'SELECT SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3484- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -3501- PERFORM R3170_LER_EMAIL_ATUAL_DB_SELECT_1 */

            R3170_LER_EMAIL_ATUAL_DB_SELECT_1();

            /*" -3505- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3506- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3507- DISPLAY '          ERRO SELECT TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT TAB. PESSOA-EMAIL");

                /*" -3509- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -3511- DISPLAY '          SEQUENCIAEMAIL................  ' SEQ-EMAIL OF DCLPESSOA-EMAIL */
                _.Display($"          SEQUENCIAEMAIL................  {PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL}");

                /*" -3513- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3514- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3514- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3170-LER-EMAIL-ATUAL-DB-SELECT-1 */
        public void R3170_LER_EMAIL_ATUAL_DB_SELECT_1()
        {
            /*" -3501- EXEC SQL SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, :DCLPESSOA-EMAIL.TIMESTAMP FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA AND SEQ_EMAIL = :DCLPESSOA-EMAIL.SEQ-EMAIL WITH UR END-EXEC. */

            var r3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1 = new R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
            };

            var executed_1 = R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1.Execute(r3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
                _.Move(executed_1.EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
                _.Move(executed_1.SITUACAO_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);
                _.Move(executed_1.COD_USUARIO, PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);
                _.Move(executed_1.TIMESTAMP, PESEMAIL.DCLPESSOA_EMAIL.TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3170_SAIDA*/

        [StopWatch]
        /*" R3200-TRATA-END-TEL-SECTION */
        private void R3200_TRATA_END_TEL_SECTION()
        {
            /*" -3524- MOVE 'R3200-TRATA-END-TEL' TO PARAGRAFO. */
            _.Move("R3200-TRATA-END-TEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3526- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3528- PERFORM R3201-TRATA-ENDERECO. */

            R3201_TRATA_ENDERECO_SECTION();

            /*" -3530- MOVE ZEROS TO W-INDEX. */
            _.Move(0, WAREA_AUXILIAR.W_INDEX);

            /*" -3530- PERFORM R3250-TRATA-TELEFONES 4 TIMES. */

            for (int i = 0; i < 4; i++)
            {

                R3250_TRATA_TELEFONES_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_SAIDA*/

        [StopWatch]
        /*" R3205-RELACIONA-ENDERECO-SECTION */
        private void R3205_RELACIONA_ENDERECO_SECTION()
        {
            /*" -3540- MOVE 'R3205-RELACIONA-ENDERECO' TO PARAGRAFO. */
            _.Move("R3205-RELACIONA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3542- MOVE 'DECLARE PESSOA-ENDERECO' TO COMANDO. */
            _.Move("DECLARE PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3545- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -3560- PERFORM R3205_RELACIONA_ENDERECO_DB_DECLARE_1 */

            R3205_RELACIONA_ENDERECO_DB_DECLARE_1();

            /*" -3564- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3565- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3566- DISPLAY '          ERRO DECLARE DA TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA-ENDERECO");

                /*" -3568- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -3570- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -3572- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3573- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3573- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3205_SAIDA*/

        [StopWatch]
        /*" R3201-TRATA-ENDERECO-SECTION */
        private void R3201_TRATA_ENDERECO_SECTION()
        {
            /*" -3583- MOVE 'R3201-TRATA-ENDERECO' TO PARAGRAFO. */
            _.Move("R3201-TRATA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3585- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3589- MOVE ZEROS TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO, W-OCORR-ENDERECO. */
            _.Move(0, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -3591- PERFORM R3205-RELACIONA-ENDERECO. */

            R3205_RELACIONA_ENDERECO_SECTION();

            /*" -3593- MOVE 'OPEN CURSOR ENDERECOS' TO COMANDO. */
            _.Move("OPEN CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3593- PERFORM R3201_TRATA_ENDERECO_DB_OPEN_1 */

            R3201_TRATA_ENDERECO_DB_OPEN_1();

            /*" -3597- MOVE 'NAO' TO W-ACHOU-ENDERECO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_ENDERECO);

            /*" -3599- MOVE SPACES TO W-FIM-CURSOR-ENDERECO. */
            _.Move("", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

            /*" -3601- PERFORM R3210-FETCH-ENDERECO. */

            R3210_FETCH_ENDERECO_SECTION();

            /*" -3602- IF W-FIM-CURSOR-ENDERECO EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO == "SIM")
            {

                /*" -3606- IF R2-ENDERECO OF REG-ENDERECO EQUAL SPACES AND R2-BAIRRO OF REG-ENDERECO EQUAL SPACES AND R2-CIDADE OF REG-ENDERECO EQUAL SPACES AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SPACES */

                if (LBFPF012.REG_ENDERECO.R2_ENDERECO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_BAIRRO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_CIDADE.IsEmpty() && LBFPF012.REG_ENDERECO.R2_SIGLA_UF.IsEmpty())
                {

                    /*" -3608- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                    _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
                }

            }


            /*" -3611- PERFORM R3215-VERIFICA-EXISTE-ENDERECO UNTIL W-FIM-CURSOR-ENDERECO EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO == "SIM"))
            {

                R3215_VERIFICA_EXISTE_ENDERECO_SECTION();
            }

            /*" -3612- IF W-ACHOU-ENDERECO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_ENDERECO == "NAO")
            {

                /*" -3612- PERFORM R3220-INCLUIR-NOVO-ENDERECO. */

                R3220_INCLUIR_NOVO_ENDERECO_SECTION();
            }


        }

        [StopWatch]
        /*" R3201-TRATA-ENDERECO-DB-OPEN-1 */
        public void R3201_TRATA_ENDERECO_DB_OPEN_1()
        {
            /*" -3593- EXEC SQL OPEN ENDERECOS END-EXEC. */

            ENDERECOS.Open();

        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-DECLARE-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_DECLARE_1()
        {
            /*" -4621- EXEC SQL DECLARE C01_AGENCEF CURSOR FOR SELECT A.COD_AGENCIA, B.COD_FONTE FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG < 9999 AND A.COD_ESCNEG = B.COD_SUREG ORDER BY A.COD_AGENCIA WITH UR END-EXEC. */
            C01_AGENCEF = new PF0623B_C01_AGENCEF(false);
            string GetQuery_C01_AGENCEF()
            {
                var query = @$"SELECT A.COD_AGENCIA
							, 
							B.COD_FONTE 
							FROM SEGUROS.AGENCIAS_CEF A
							, 
							SEGUROS.MALHA_CEF B 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG < 9999 
							AND A.COD_ESCNEG = B.COD_SUREG 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            C01_AGENCEF.GetQueryEvent += GetQuery_C01_AGENCEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3201_SAIDA*/

        [StopWatch]
        /*" R3210-FETCH-ENDERECO-SECTION */
        private void R3210_FETCH_ENDERECO_SECTION()
        {
            /*" -3622- MOVE 'R3210-FETCH-ENDERECO' TO PARAGRAFO. */
            _.Move("R3210-FETCH-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3624- MOVE 'FETCH CURSOR ENDERECOS' TO COMANDO. */
            _.Move("FETCH CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3635- PERFORM R3210_FETCH_ENDERECO_DB_FETCH_1 */

            R3210_FETCH_ENDERECO_DB_FETCH_1();

            /*" -3638- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3639- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3640- MOVE 'SIM' TO W-FIM-CURSOR-ENDERECO */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

                    /*" -3640- PERFORM R3210_FETCH_ENDERECO_DB_CLOSE_1 */

                    R3210_FETCH_ENDERECO_DB_CLOSE_1();

                    /*" -3642- ELSE */
                }
                else
                {


                    /*" -3643- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -3644- DISPLAY '          ERRO FETCH CURSOR ENDERECO' */
                    _.Display($"          ERRO FETCH CURSOR ENDERECO");

                    /*" -3646- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                    _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                    /*" -3648- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -3650- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3651- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3651- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3210-FETCH-ENDERECO-DB-FETCH-1 */
        public void R3210_FETCH_ENDERECO_DB_FETCH_1()
        {
            /*" -3635- EXEC SQL FETCH ENDERECOS INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO END-EXEC. */

            if (ENDERECOS.Fetch())
            {
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_SITUACAO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);
            }

        }

        [StopWatch]
        /*" R3210-FETCH-ENDERECO-DB-CLOSE-1 */
        public void R3210_FETCH_ENDERECO_DB_CLOSE_1()
        {
            /*" -3640- EXEC SQL CLOSE ENDERECOS END-EXEC */

            ENDERECOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_SAIDA*/

        [StopWatch]
        /*" R3215-VERIFICA-EXISTE-ENDERECO-SECTION */
        private void R3215_VERIFICA_EXISTE_ENDERECO_SECTION()
        {
            /*" -3661- MOVE 'R3215-VERIFICA-EXISTE-ENDERECO' TO PARAGRAFO. */
            _.Move("R3215-VERIFICA-EXISTE-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3663- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3675- IF R2-TIPO-ENDER OF REG-ENDERECO EQUAL TIPO-ENDER OF DCLPESSOA-ENDERECO AND R2-ENDERECO OF REG-ENDERECO EQUAL ENDERECO OF DCLPESSOA-ENDERECO AND R2-CIDADE OF REG-ENDERECO EQUAL CIDADE OF DCLPESSOA-ENDERECO AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SIGLA-UF OF DCLPESSOA-ENDERECO AND R2-CEP OF REG-ENDERECO EQUAL CEP OF DCLPESSOA-ENDERECO */

            if (LBFPF012.REG_ENDERECO.R2_TIPO_ENDER == PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER && LBFPF012.REG_ENDERECO.R2_ENDERECO == PESENDER.DCLPESSOA_ENDERECO.ENDERECO && LBFPF012.REG_ENDERECO.R2_CIDADE == PESENDER.DCLPESSOA_ENDERECO.CIDADE && LBFPF012.REG_ENDERECO.R2_SIGLA_UF == PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF && LBFPF012.REG_ENDERECO.R2_CEP == PESENDER.DCLPESSOA_ENDERECO.CEP)
            {

                /*" -3677- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


            /*" -3681- IF R2-ENDERECO OF REG-ENDERECO EQUAL SPACES AND R2-BAIRRO OF REG-ENDERECO EQUAL SPACES AND R2-CIDADE OF REG-ENDERECO EQUAL SPACES AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SPACES */

            if (LBFPF012.REG_ENDERECO.R2_ENDERECO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_BAIRRO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_CIDADE.IsEmpty() && LBFPF012.REG_ENDERECO.R2_SIGLA_UF.IsEmpty())
            {

                /*" -3683- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


            /*" -3683- PERFORM R3210-FETCH-ENDERECO. */

            R3210_FETCH_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3215_SAIDA*/

        [StopWatch]
        /*" R3220-INCLUIR-NOVO-ENDERECO-SECTION */
        private void R3220_INCLUIR_NOVO_ENDERECO_SECTION()
        {
            /*" -3693- MOVE 'R3220-INCLUIR-NOVO-ENDERECO' TO PARAGRAFO. */
            _.Move("R3220-INCLUIR-NOVO-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3702- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3705- MOVE OCORR-ENDERECO OF DCLPESSOA-ENDERECO TO W-OCORR-ENDERECO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -3707- COMPUTE W-OCORR-ENDERECO = W-OCORR-ENDERECO + 1. */
            WAREA_AUXILIAR.W_OCORR_ENDERECO.Value = WAREA_AUXILIAR.W_OCORR_ENDERECO + 1;

            /*" -3707- PERFORM R3230-INCLUIR-ENDERECO. */

            R3230_INCLUIR_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3220_SAIDA*/

        [StopWatch]
        /*" R3225-OBTER-MAX-ENDERECO-SECTION */
        private void R3225_OBTER_MAX_ENDERECO_SECTION()
        {
            /*" -3717- MOVE 'R3225-OBTER-MAX-ENDERECO' TO PARAGRAFO. */
            _.Move("R3225-OBTER-MAX-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3719- MOVE 'MAX SEGUROS.PESSOA_ENDERECO' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3722- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -3728- PERFORM R3225_OBTER_MAX_ENDERECO_DB_SELECT_1 */

            R3225_OBTER_MAX_ENDERECO_DB_SELECT_1();

            /*" -3731- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3732- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3733- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-ENDERECO' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-ENDERECO");

                /*" -3735- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -3737- DISPLAY '          NUMERO DA PROPOSTA............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -3739- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3740- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3740- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3225-OBTER-MAX-ENDERECO-DB-SELECT-1 */
        public void R3225_OBTER_MAX_ENDERECO_DB_SELECT_1()
        {
            /*" -3728- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA-ENDERECO.COD-PESSOA WITH UR END-EXEC. */

            var r3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1 = new R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA.ToString(),
            };

            var executed_1 = R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1.Execute(r3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3225_SAIDA*/

        [StopWatch]
        /*" R3230-INCLUIR-ENDERECO-SECTION */
        private void R3230_INCLUIR_ENDERECO_SECTION()
        {
            /*" -3750- MOVE 'R3230-INCLUI-ENDERECO' TO PARAGRAFO. */
            _.Move("R3230-INCLUI-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3752- MOVE 'INSERT PESSOA-ENDERECO' TO COMANDO. */
            _.Move("INSERT PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3755- MOVE W-OCORR-ENDERECO TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);

            /*" -3758- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -3761- MOVE R2-ENDERECO OF REG-ENDERECO TO ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);

            /*" -3764- MOVE R2-TIPO-ENDER OF REG-ENDERECO TO TIPO-ENDER OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);

            /*" -3767- MOVE R2-BAIRRO OF REG-ENDERECO TO BAIRRO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);

            /*" -3770- MOVE R2-CEP OF REG-ENDERECO TO CEP OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);

            /*" -3773- MOVE R2-CIDADE OF REG-ENDERECO TO CIDADE OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);

            /*" -3776- MOVE R2-SIGLA-UF OF REG-ENDERECO TO SIGLA-UF OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);

            /*" -3779- MOVE 'A' TO SITUACAO-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move("A", PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);

            /*" -3782- MOVE 'PF0623B' TO COD-USUARIO OF DCLPESSOA-ENDERECO. */
            _.Move("PF0623B", PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO);

            /*" -3796- PERFORM R3230_INCLUIR_ENDERECO_DB_INSERT_1 */

            R3230_INCLUIR_ENDERECO_DB_INSERT_1();

            /*" -3799- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3800- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3801- DISPLAY '          ERRO INSERT TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO INSERT TABELA PESSOA-ENDERECO");

                /*" -3803- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -3805- DISPLAY '          NUMERO DA PROPOSTA............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -3807- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3808- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3808- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3230-INCLUIR-ENDERECO-DB-INSERT-1 */
        public void R3230_INCLUIR_ENDERECO_DB_INSERT_1()
        {
            /*" -3796- EXEC SQL INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES (:DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, NULL, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO, :DCLPESSOA-ENDERECO.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1 = new R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA.ToString(),
                OCORR_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO.ToString(),
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                TIPO_ENDER = PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                SITUACAO_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO.ToString(),
                COD_USUARIO = PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO.ToString(),
            };

            R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1.Execute(r3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3230_SAIDA*/

        [StopWatch]
        /*" R3250-TRATA-TELEFONES-SECTION */
        private void R3250_TRATA_TELEFONES_SECTION()
        {
            /*" -3818- MOVE 'R3250-TRATA-TELEFONE' TO PARAGRAFO. */
            _.Move("R3250-TRATA-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3820- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3822- ADD 1 TO W-INDEX. */
            WAREA_AUXILIAR.W_INDEX.Value = WAREA_AUXILIAR.W_INDEX + 1;

            /*" -3824- MOVE 'NAO' TO W-ACHOU-TELEFONE. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

            /*" -3825- IF R1-NUM-FONE (W-INDEX) GREATER ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE > 00)
            {

                /*" -3826- PERFORM R3255-LER-TELEFONE */

                R3255_LER_TELEFONE_SECTION();

                /*" -3827- IF W-ACHOU-TELEFONE EQUAL 'NAO' */

                if (WAREA_AUXILIAR.W_ACHOU_TELEFONE == "NAO")
                {

                    /*" -3827- PERFORM R3260-INCLUIR-NOVO-TELEFONE. */

                    R3260_INCLUIR_NOVO_TELEFONE_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_SAIDA*/

        [StopWatch]
        /*" R3255-LER-TELEFONE-SECTION */
        private void R3255_LER_TELEFONE_SECTION()
        {
            /*" -3837- MOVE 'R3255-LER-TELEFONE' TO PARAGRAFO. */
            _.Move("R3255-LER-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3839- MOVE 'SELECT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("SELECT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3845- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -3851- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -3859- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -3862- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -3871- PERFORM R3255_LER_TELEFONE_DB_SELECT_1 */

            R3255_LER_TELEFONE_DB_SELECT_1();

            /*" -3874- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -3875- MOVE 'SIM' TO W-ACHOU-TELEFONE */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                /*" -3876- ELSE */
            }
            else
            {


                /*" -3877- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3878- MOVE 'NAO' TO W-ACHOU-TELEFONE */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                    /*" -3879- ELSE */
                }
                else
                {


                    /*" -3880- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -3881- DISPLAY '          ERRO SELECT TABELA PESSOA-TELEFONE' */
                    _.Display($"          ERRO SELECT TABELA PESSOA-TELEFONE");

                    /*" -3883- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                    _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                    /*" -3885- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -3887- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3888- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3888- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3255-LER-TELEFONE-DB-SELECT-1 */
        public void R3255_LER_TELEFONE_DB_SELECT_1()
        {
            /*" -3871- EXEC SQL SELECT SITUACAO_FONE INTO :DCLPESSOA-TELEFONE.SITUACAO-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA AND TIPO_FONE = :DCLPESSOA-TELEFONE.TIPO-FONE AND NUM_FONE = :DCLPESSOA-TELEFONE.NUM-FONE AND DDD = :DCLPESSOA-TELEFONE.DDD WITH UR END-EXEC. */

            var r3255_LER_TELEFONE_DB_SELECT_1_Query1 = new R3255_LER_TELEFONE_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
            };

            var executed_1 = R3255_LER_TELEFONE_DB_SELECT_1_Query1.Execute(r3255_LER_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SITUACAO_FONE, PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3255_SAIDA*/

        [StopWatch]
        /*" R3260-INCLUIR-NOVO-TELEFONE-SECTION */
        private void R3260_INCLUIR_NOVO_TELEFONE_SECTION()
        {
            /*" -3898- MOVE 'R3260-INCLUIR-NOVO-TELEFONE' TO PARAGRAFO. */
            _.Move("R3260-INCLUIR-NOVO-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3900- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3902- PERFORM R3265-OBTER-MAX-TELEFONE. */

            R3265_OBTER_MAX_TELEFONE_SECTION();

            /*" -3905- MOVE SEQ-FONE OF DCLPESSOA-TELEFONE TO W-SEQ-FONE */
            _.Move(PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE, WAREA_AUXILIAR.W_SEQ_FONE);

            /*" -3907- COMPUTE W-SEQ-FONE = W-SEQ-FONE + 1. */
            WAREA_AUXILIAR.W_SEQ_FONE.Value = WAREA_AUXILIAR.W_SEQ_FONE + 1;

            /*" -3907- PERFORM R3270-INCLUIR-TELEFONE. */

            R3270_INCLUIR_TELEFONE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3260_SAIDA*/

        [StopWatch]
        /*" R3265-OBTER-MAX-TELEFONE-SECTION */
        private void R3265_OBTER_MAX_TELEFONE_SECTION()
        {
            /*" -3917- MOVE 'R3265-OBTER-MAX-TELEFONE' TO PARAGRAFO. */
            _.Move("R3265-OBTER-MAX-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3919- MOVE 'MAX SEGUROS.PESSOA_TELEFONE' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3925- PERFORM R3265_OBTER_MAX_TELEFONE_DB_SELECT_1 */

            R3265_OBTER_MAX_TELEFONE_DB_SELECT_1();

            /*" -3928- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3929- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3930- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-TELEFONE' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-TELEFONE");

                /*" -3932- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -3934- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3936- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3937- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3937- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3265-OBTER-MAX-TELEFONE-DB-SELECT-1 */
        public void R3265_OBTER_MAX_TELEFONE_DB_SELECT_1()
        {
            /*" -3925- EXEC SQL SELECT VALUE(MAX(SEQ_FONE),0) INTO :DCLPESSOA-TELEFONE.SEQ-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA WITH UR END-EXEC. */

            var r3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1 = new R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
            };

            var executed_1 = R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1.Execute(r3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3265_SAIDA*/

        [StopWatch]
        /*" R3270-INCLUIR-TELEFONE-SECTION */
        private void R3270_INCLUIR_TELEFONE_SECTION()
        {
            /*" -3947- MOVE 'R3270-INCLUI-TELEFONE' TO PARAGRAFO. */
            _.Move("R3270-INCLUI-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3949- MOVE 'INSERT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("INSERT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3953- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -3956- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -3959- MOVE W-SEQ-FONE TO SEQ-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);

            /*" -3962- MOVE 55 TO DDI OF DCLPESSOA-TELEFONE. */
            _.Move(55, PESFONE.DCLPESSOA_TELEFONE.DDI);

            /*" -3965- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -3968- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -3971- MOVE 'A' TO SITUACAO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move("A", PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);

            /*" -3974- MOVE 'PF0623B' TO COD-USUARIO OF DCLPESSOA-TELEFONE. */
            _.Move("PF0623B", PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO);

            /*" -3985- PERFORM R3270_INCLUIR_TELEFONE_DB_INSERT_1 */

            R3270_INCLUIR_TELEFONE_DB_INSERT_1();

            /*" -3988- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3989- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -3990- DISPLAY '          ERRO INSERT TABELA PESSOA-TELEFONE' */
                _.Display($"          ERRO INSERT TABELA PESSOA-TELEFONE");

                /*" -3992- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -3994- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3996- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3997- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3997- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3270-INCLUIR-TELEFONE-DB-INSERT-1 */
        public void R3270_INCLUIR_TELEFONE_DB_INSERT_1()
        {
            /*" -3985- EXEC SQL INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES (:DCLPESSOA-TELEFONE.COD-PESSOA, :DCLPESSOA-TELEFONE.TIPO-FONE, :DCLPESSOA-TELEFONE.SEQ-FONE, :DCLPESSOA-TELEFONE.DDI, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE, :DCLPESSOA-TELEFONE.SITUACAO-FONE, :DCLPESSOA-TELEFONE.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1 = new R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                SEQ_FONE = PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE.ToString(),
                DDI = PESFONE.DCLPESSOA_TELEFONE.DDI.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                SITUACAO_FONE = PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE.ToString(),
                COD_USUARIO = PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO.ToString(),
            };

            R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1.Execute(r3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3270_SAIDA*/

        [StopWatch]
        /*" R3300-TRATA-PROPOSTA-SECTION */
        private void R3300_TRATA_PROPOSTA_SECTION()
        {
            /*" -4007- MOVE 'R3300-TRATA-PROPOSTA' TO PARAGRAFO. */
            _.Move("R3300-TRATA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4009- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4011- PERFORM R3310-TRATA-TAB-RELACIONAMENTO. */

            R3310_TRATA_TAB_RELACIONAMENTO_SECTION();

            /*" -4013- PERFORM R3350-TRATA-TAB-IDE-RELACIONAM. */

            R3350_TRATA_TAB_IDE_RELACIONAM_SECTION();

            /*" -4015- PERFORM R3360-TRATA-PROP-FIDELIZACAO. */

            R3360_TRATA_PROP_FIDELIZACAO_SECTION();

            /*" -4015- PERFORM R3390-GERA-HIST-FIDELIZACAO. */

            R3390_GERA_HIST_FIDELIZACAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_SAIDA*/

        [StopWatch]
        /*" R3310-TRATA-TAB-RELACIONAMENTO-SECTION */
        private void R3310_TRATA_TAB_RELACIONAMENTO_SECTION()
        {
            /*" -4025- MOVE 'R3310-TRATA-TAB-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3310-TRATA-TAB-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4027- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4029- PERFORM R3315-DETERMINA-RELACIONAMENTO */

            R3315_DETERMINA_RELACIONAMENTO_SECTION();

            /*" -4031- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

            /*" -4033- PERFORM R3320-VERIFICA-EXISTE-RELACION. */

            R3320_VERIFICA_EXISTE_RELACION_SECTION();

            /*" -4034- IF W-ACHOU-RELACIONAMENTO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO == "NAO")
            {

                /*" -4034- PERFORM R3330-GERA-RELACIONAMENTO. */

                R3330_GERA_RELACIONAMENTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3310_SAIDA*/

        [StopWatch]
        /*" R3315-DETERMINA-RELACIONAMENTO-SECTION */
        private void R3315_DETERMINA_RELACIONAMENTO_SECTION()
        {
            /*" -4044- MOVE 'R3315-DETERMINA-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3315-DETERMINA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4052- MOVE 'SELECT PRODUTOS_SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS_SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4083- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO W-COD-EMPRESA. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, WAREA_AUXILIAR.W_COD_EMPRESA);

            /*" -4085- MOVE PRDSIVPF-COD-RELAC OF DCLPRODUTOS-SIVPF TO W-COD-RELACION, W-RELACIONAMENTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC, WAREA_AUXILIAR.W_COD_RELACION, WAREA_AUXILIAR.W_RELACIONAMENTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3315_SAIDA*/

        [StopWatch]
        /*" R3320-VERIFICA-EXISTE-RELACION-SECTION */
        private void R3320_VERIFICA_EXISTE_RELACION_SECTION()
        {
            /*" -4095- MOVE 'R3320-VERIFICA-EXISTE-RELACION' TO PARAGRAFO. */
            _.Move("R3320-VERIFICA-EXISTE-RELACION", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4097- MOVE 'SELECT PESSOAS_TIPORELAC' TO COMANDO. */
            _.Move("SELECT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4100- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -4103- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -4112- PERFORM R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1 */

            R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1();

            /*" -4115- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4116- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4117- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

                    /*" -4118- ELSE */
                }
                else
                {


                    /*" -4119- DISPLAY 'PF0623B - FIM ANORMAL' */
                    _.Display($"PF0623B - FIM ANORMAL");

                    /*" -4120- DISPLAY '          ERRO SELECT TAB. PESSOA-TIPORELAC' */
                    _.Display($"          ERRO SELECT TAB. PESSOA-TIPORELAC");

                    /*" -4122- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                    /*" -4124- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                    /*" -4126- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4127- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4128- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -4129- ELSE */
                }

            }
            else
            {


                /*" -4129- MOVE 'SIM' TO W-ACHOU-RELACIONAMENTO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);
            }


        }

        [StopWatch]
        /*" R3320-VERIFICA-EXISTE-RELACION-DB-SELECT-1 */
        public void R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1()
        {
            /*" -4112- EXEC SQL SELECT COD_PESSOA, COD_RELAC INTO :DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC FROM SEGUROS.R_PESSOA_TIPORELAC WHERE COD_PESSOA = :DCLR-PESSOA-TIPORELAC.COD-PESSOA AND COD_RELAC = :DCLR-PESSOA-TIPORELAC.COD-RELAC WITH UR END-EXEC. */

            var r3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1 = new R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            var executed_1 = R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1.Execute(r3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);
                _.Move(executed_1.COD_RELAC, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3320_SAIDA*/

        [StopWatch]
        /*" R3330-GERA-RELACIONAMENTO-SECTION */
        private void R3330_GERA_RELACIONAMENTO_SECTION()
        {
            /*" -4139- MOVE 'R3330-GERA-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3330-GERA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4141- MOVE 'INSERT PESSOAS_TIPORELAC' TO COMANDO. */
            _.Move("INSERT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4144- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -4147- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -4151- PERFORM R3330_GERA_RELACIONAMENTO_DB_INSERT_1 */

            R3330_GERA_RELACIONAMENTO_DB_INSERT_1();

            /*" -4154- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4155- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -4156- DISPLAY '          ERRO INSERT TAB. PESSOA-TIPORELAC' */
                _.Display($"          ERRO INSERT TAB. PESSOA-TIPORELAC");

                /*" -4158- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                /*" -4160- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                /*" -4162- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4163- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4163- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3330-GERA-RELACIONAMENTO-DB-INSERT-1 */
        public void R3330_GERA_RELACIONAMENTO_DB_INSERT_1()
        {
            /*" -4151- EXEC SQL INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES (:DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC) END-EXEC. */

            var r3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1 = new R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1.Execute(r3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3330_SAIDA*/

        [StopWatch]
        /*" R3350-TRATA-TAB-IDE-RELACIONAM-SECTION */
        private void R3350_TRATA_TAB_IDE_RELACIONAM_SECTION()
        {
            /*" -4173- IF W-OBTER-MAX-RELAC EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_OBTER_MAX_RELAC == "NAO")
            {

                /*" -4174- MOVE 'SIM' TO W-OBTER-MAX-RELAC */
                _.Move("SIM", WAREA_AUXILIAR.W_OBTER_MAX_RELAC);

                /*" -4176- PERFORM R3355-OBTER-MAX-ID-RELACIONAM. */

                R3355_OBTER_MAX_ID_RELACIONAM_SECTION();
            }


            /*" -4177- MOVE 'R3350-TRATA-TAB-RELACIONAM' TO PARAGRAFO. */
            _.Move("R3350-TRATA-TAB-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4179- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4182- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO W-NUM-IDENTIF. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, WAREA_AUXILIAR.W_NUM_IDENTIF);

            /*" -4185- COMPUTE W-NUM-IDENTIF = W-NUM-IDENTIF + 1. */
            WAREA_AUXILIAR.W_NUM_IDENTIF.Value = WAREA_AUXILIAR.W_NUM_IDENTIF + 1;

            /*" -4188- MOVE W-NUM-IDENTIF TO NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC. */
            _.Move(WAREA_AUXILIAR.W_NUM_IDENTIF, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);

            /*" -4191- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -4194- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -4198- MOVE 'PF0623B' TO COD-USUARIO OF DCLIDENTIFICA-RELAC. */
            _.Move("PF0623B", IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO);

            /*" -4205- PERFORM R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1 */

            R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1();

            /*" -4208- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4209- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -4210- DISPLAY '          ERRO INSERT TABELA IDENTIFICA-RELAC.' */
                _.Display($"          ERRO INSERT TABELA IDENTIFICA-RELAC.");

                /*" -4212- DISPLAY '          NUM IDENTIFICACAO.............  ' NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC */
                _.Display($"          NUM IDENTIFICACAO.............  {IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO}");

                /*" -4214- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -4216- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -4218- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -4220- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4221- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4221- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3350-TRATA-TAB-IDE-RELACIONAM-DB-INSERT-1 */
        public void R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1()
        {
            /*" -4205- EXEC SQL INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES (:DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO, :DCLIDENTIFICA-RELAC.COD-PESSOA, :DCLIDENTIFICA-RELAC.COD-RELAC, :DCLIDENTIFICA-RELAC.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1 = new R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1()
            {
                NUM_IDENTIFICACAO = IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO.ToString(),
                COD_PESSOA = IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA.ToString(),
                COD_RELAC = IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC.ToString(),
                COD_USUARIO = IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO.ToString(),
            };

            R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1.Execute(r3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3350_SAIDA*/

        [StopWatch]
        /*" R3355-OBTER-MAX-ID-RELACIONAM-SECTION */
        private void R3355_OBTER_MAX_ID_RELACIONAM_SECTION()
        {
            /*" -4231- MOVE 'R3355-OBTER-MAX-ID-RELACIONAM' TO PARAGRAFO. */
            _.Move("R3355-OBTER-MAX-ID-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4233- MOVE 'MAX IDENTIFICA_RELAC' TO COMANDO. */
            _.Move("MAX IDENTIFICA_RELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4236- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -4239- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -4246- PERFORM R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1 */

            R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1();

            /*" -4249- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4250- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -4251- DISPLAY '          ERRO SELECT MAX TAB. IDENTIFICA-RELAC' */
                _.Display($"          ERRO SELECT MAX TAB. IDENTIFICA-RELAC");

                /*" -4253- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -4255- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -4257- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4258- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4258- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3355-OBTER-MAX-ID-RELACIONAM-DB-SELECT-1 */
        public void R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1()
        {
            /*" -4246- EXEC SQL SELECT VALUE(MAX(NUM_IDENTIFICACAO),0) INTO :DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO FROM SEGUROS.IDENTIFICA_RELAC WITH UR END-EXEC. */

            var r3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1 = new R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1.Execute(r3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_IDENTIFICACAO, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3355_SAIDA*/

        [StopWatch]
        /*" R3360-TRATA-PROP-FIDELIZACAO-SECTION */
        private void R3360_TRATA_PROP_FIDELIZACAO_SECTION()
        {
            /*" -4268- MOVE 'R3360-TRATA-PROP-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3360-TRATA-PROP-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4270- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4274- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-NUM-PROPOSTA-SIVPF W-NUM-PROPOSTA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WAREA_AUXILIAR.W_NUM_PROPOSTA);

            /*" -4276- MOVE RCAPS-NUM-TITULO TO PROPOFID-NUM-SICOB. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_TITULO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

            /*" -4279- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO PROPOFID-NUM-IDENTIFICACAO */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);

            /*" -4282- MOVE R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -4284- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -4286- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -4289- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -4293- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -4296- MOVE W-DATA-SQL TO PROPOFID-DATA-PROPOSTA */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);

            /*" -4299- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PROPOFID-COD-PRODUTO-SIVPF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);

            /*" -4302- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO PROPOFID-COD-EMPRESA-SIVPF */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);

            /*" -4305- MOVE R3-AGECOBR OF REG-PROPOSTA-SASSE TO PROPOFID-AGECOBR */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);

            /*" -4308- MOVE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE TO PROPOFID-DIA-DEBITO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);

            /*" -4311- MOVE R3-OPCAOPAG OF REG-PROPOSTA-SASSE TO PROPOFID-OPCAOPAG */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);

            /*" -4314- MOVE R3-AGECTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-AGECTADEB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);

            /*" -4317- MOVE R3-OPRCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-OPRCTADEB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);

            /*" -4320- MOVE R3-NUMCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-NUMCTADEB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);

            /*" -4323- MOVE R3-DIGCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-DIGCTADEB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);

            /*" -4326- MOVE R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE TO PROPOFID-PERC-DESCONTO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);

            /*" -4329- MOVE R3-NRMATRVEN OF REG-PROPOSTA-SASSE TO PROPOFID-NRMATRVEN */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);

            /*" -4332- MOVE TERMOADE-COD-AGENCIA-VEN TO PROPOFID-AGECTAVEN */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_VEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN);

            /*" -4335- MOVE TERMOADE-OPERACAO-CONTA-VEN TO PROPOFID-OPRCTAVEN */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_OPERACAO_CONTA_VEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN);

            /*" -4338- MOVE TERMOADE-NUM-CONTA-VEN TO PROPOFID-NUMCTAVEN */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_CONTA_VEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN);

            /*" -4347- MOVE TERMOADE-DIG-CONTA-VEN TO PROPOFID-DIGCTAVEN */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DIG_CONTA_VEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);

            /*" -4350- MOVE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE TO PROPOFID-CGC-CONVENENTE */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);

            /*" -4355- MOVE R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE TO PROPOFID-NOME-CONVENENTE */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);

            /*" -4358- MOVE ZEROS TO PROPOFID-NRMATRCON */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);

            /*" -4361- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -4363- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -4365- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -4368- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -4372- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -4375- MOVE W-DATA-SQL TO PROPOFID-DTQITBCO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

            /*" -4378- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO PROPOFID-VAL-PAGO */
            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

            /*" -4381- MOVE RCAPS-AGE-COBRANCA OF DCLRCAPS TO PROPOFID-AGEPGTO */
            _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);

            /*" -4384- MOVE R3-VAL-TARIFA OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-TARIFA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA);

            /*" -4387- MOVE R2-VAL-IOF OF REG-APOL-SASSE TO PROPOFID-VAL-IOF */
            _.Move(LBFCT016.REG_APOL_SASSE.R2_VAL_IOF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF);

            /*" -4390- MOVE R3-DATA-CREDITO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -4392- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -4394- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -4397- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -4401- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -4404- MOVE W-DATA-SQL TO PROPOFID-DATA-CREDITO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);

            /*" -4407- MOVE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-COMISSAO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO);

            /*" -4410- MOVE R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-SIT-PROPOSTA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -4413- MOVE 'PF0623B' TO PROPOFID-COD-USUARIO */
            _.Move("PF0623B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -4416- MOVE RH-NSAS OF REG-HEADER-STA TO PROPOFID-NSAS-SIVPF */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);

            /*" -4419- MOVE RH-NSAS OF REG-HEADER TO PROPOFID-NSAC-SIVPF */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);

            /*" -4422- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO PROPOFID-NSL */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);

            /*" -4423- IF CANAL-VENDA-PAPEL */

            if (WAREA_AUXILIAR.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
            {

                /*" -4425- MOVE 2 TO PROPOFID-CANAL-PROPOSTA */
                _.Move(2, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);

                /*" -4426- ELSE */
            }
            else
            {


                /*" -4429- MOVE W-CANAL-PROPOSTA TO PROPOFID-CANAL-PROPOSTA. */
                _.Move(WAREA_AUXILIAR.CANAL.W_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
            }


            /*" -4432- MOVE 6 TO PROPOFID-ORIGEM-PROPOSTA */
            _.Move(6, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

            /*" -4435- MOVE 'R' TO PROPOFID-SITUACAO-ENVIO */
            _.Move("R", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -4438- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO PROPOFID-COD-PESSOA */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);

            /*" -4441- MOVE R3-OPCAO-COBER OF REG-PROPOSTA-SASSE TO PROPOFID-OPCAO-COBER */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);

            /*" -4444- MOVE R3-COD-PLANO OF REG-PROPOSTA-SASSE TO PROPOFID-COD-PLANO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);

            /*" -4447- MOVE R1-NOME-CONJUGE OF REG-CLIENTES TO PROPOFID-NOME-CONJUGE */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE);

            /*" -4450- MOVE R1-DTNASC-CONJUGE OF REG-CLIENTES TO W-DATA-TRABALHO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -4452- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -4454- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -4457- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -4461- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -4464- MOVE W-DATA-SQL TO PROPOFID-DATA-NASC-CONJUGE */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE);

            /*" -4467- MOVE R1-CBO-CONJUGE OF REG-CLIENTES TO PROPOFID-PROFISSAO-CONJUGE */
            _.Move(LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE);

            /*" -4468- MOVE PROPOVA-FAIXA-RENDA-IND TO PROPOFID-FAIXA-RENDA-IND */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);

            /*" -4470- MOVE PROPOVA-FAIXA-RENDA-FAM TO PROPOFID-FAIXA-RENDA-FAM. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);

            /*" -4472- MOVE 'N' TO PROPOFID-IND-TIPO-CONTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move("N", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);

            /*" -4522- PERFORM R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1 */

            R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1();

            /*" -4525- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4526- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -4527- DISPLAY '          ERRO INSERT TABELA PROPOSTA FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA PROPOSTA FIDELIZ");

                /*" -4529- DISPLAY '          CODIGO PESSOA.................  ' PROPOFID-COD-PESSOA */
                _.Display($"          CODIGO PESSOA.................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                /*" -4531- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -4533- DISPLAY '          COD-EMPRESA...................  ' PROPOFID-COD-EMPRESA-SIVPF */
                _.Display($"          COD-EMPRESA...................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF}");

                /*" -4535- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4536- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4536- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3360-TRATA-PROP-FIDELIZACAO-DB-INSERT-1 */
        public void R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -4522- EXEC SQL INSERT INTO SEGUROS.PROPOSTA_FIDELIZ VALUES (:PROPOFID-NUM-PROPOSTA-SIVPF, :PROPOFID-NUM-IDENTIFICACAO, :PROPOFID-COD-EMPRESA-SIVPF, :PROPOFID-COD-PESSOA, :PROPOFID-NUM-SICOB, :PROPOFID-DATA-PROPOSTA, :PROPOFID-COD-PRODUTO-SIVPF, :PROPOFID-AGECOBR, :PROPOFID-DIA-DEBITO, :PROPOFID-OPCAOPAG, :PROPOFID-AGECTADEB, :PROPOFID-OPRCTADEB, :PROPOFID-NUMCTADEB, :PROPOFID-DIGCTADEB, :PROPOFID-PERC-DESCONTO, :PROPOFID-NRMATRVEN, :PROPOFID-AGECTAVEN, :PROPOFID-OPRCTAVEN, :PROPOFID-NUMCTAVEN, :PROPOFID-DIGCTAVEN, :PROPOFID-CGC-CONVENENTE, :PROPOFID-NOME-CONVENENTE, :PROPOFID-NRMATRCON, :PROPOFID-DTQITBCO, :PROPOFID-VAL-PAGO, :PROPOFID-AGEPGTO, :PROPOFID-VAL-TARIFA, :PROPOFID-VAL-IOF, :PROPOFID-DATA-CREDITO, :PROPOFID-VAL-COMISSAO, :PROPOFID-SIT-PROPOSTA, :PROPOFID-COD-USUARIO, :PROPOFID-CANAL-PROPOSTA, :PROPOFID-NSAS-SIVPF, :PROPOFID-ORIGEM-PROPOSTA, CURRENT TIMESTAMP, :PROPOFID-NSL, :PROPOFID-NSAC-SIVPF, :PROPOFID-SITUACAO-ENVIO, :PROPOFID-OPCAO-COBER, :PROPOFID-COD-PLANO, :PROPOFID-NOME-CONJUGE, :PROPOFID-DATA-NASC-CONJUGE:VIND-DTNASC-ESPOSA, :PROPOFID-PROFISSAO-CONJUGE, :PROPOFID-FAIXA-RENDA-IND:VIND-FAIXA-RENDA-IND, :PROPOFID-FAIXA-RENDA-FAM:VIND-FAIXA-RENDA-FAM, NULL, :PROPOFID-IND-TIPO-CONTA) END-EXEC. */

            var r3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1 = new R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                PROPOFID_COD_EMPRESA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF.ToString(),
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
                PROPOFID_DATA_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.ToString(),
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                PROPOFID_DIA_DEBITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO.ToString(),
                PROPOFID_OPCAOPAG = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG.ToString(),
                PROPOFID_AGECTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.ToString(),
                PROPOFID_OPRCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.ToString(),
                PROPOFID_NUMCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.ToString(),
                PROPOFID_DIGCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.ToString(),
                PROPOFID_PERC_DESCONTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                PROPOFID_DIGCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.ToString(),
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
                PROPOFID_NOME_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE.ToString(),
                PROPOFID_NRMATRCON = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                PROPOFID_AGEPGTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO.ToString(),
                PROPOFID_VAL_TARIFA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA.ToString(),
                PROPOFID_VAL_IOF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF.ToString(),
                PROPOFID_DATA_CREDITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.ToString(),
                PROPOFID_VAL_COMISSAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO.ToString(),
                PROPOFID_SIT_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.ToString(),
                PROPOFID_COD_USUARIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO.ToString(),
                PROPOFID_CANAL_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA.ToString(),
                PROPOFID_NSAS_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF.ToString(),
                PROPOFID_ORIGEM_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.ToString(),
                PROPOFID_NSL = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL.ToString(),
                PROPOFID_NSAC_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF.ToString(),
                PROPOFID_SITUACAO_ENVIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_NOME_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.ToString(),
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                VIND_DTNASC_ESPOSA = VIND_DTNASC_ESPOSA.ToString(),
                PROPOFID_PROFISSAO_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE.ToString(),
                PROPOFID_FAIXA_RENDA_IND = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.ToString(),
                VIND_FAIXA_RENDA_IND = VIND_FAIXA_RENDA_IND.ToString(),
                PROPOFID_FAIXA_RENDA_FAM = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.ToString(),
                VIND_FAIXA_RENDA_FAM = VIND_FAIXA_RENDA_FAM.ToString(),
                PROPOFID_IND_TIPO_CONTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA.ToString(),
            };

            R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3360_SAIDA*/

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-SECTION */
        private void R3390_GERA_HIST_FIDELIZACAO_SECTION()
        {
            /*" -4546- MOVE 'R3390-GERA-HIST-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3390-GERA-HIST-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4548- MOVE 'INSERT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4551- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -4554- MOVE TERMOADE-DATA-ADESAO TO PROPFIDH-DATA-SITUACAO. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -4557- MOVE RH-NSAS OF REG-HEADER-STA TO PROPFIDH-NSAS-SIVPF. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -4560- MOVE RT-QTDE-TIPO-3 OF REG-TRAILLER-STA TO PROPFIDH-NSL. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -4563- MOVE 'EMT' TO PROPFIDH-SIT-PROPOSTA. */
            _.Move("EMT", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -4566- MOVE R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-COBRANCA-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -4569- MOVE R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -4572- MOVE PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -4575- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -4586- PERFORM R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1 */

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1();

            /*" -4589- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4590- DISPLAY 'PF0623B - FIM ANORMAL' */
                _.Display($"PF0623B - FIM ANORMAL");

                /*" -4591- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -4593- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -4595- DISPLAY '          NUMERO PROPOSTA...............  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Display($"          NUMERO PROPOSTA...............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -4597- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPFIDH-NUM-IDENTIFICACAO */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}");

                /*" -4599- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4600- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4600- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-DB-INSERT-1 */
        public void R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -4586- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

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
        /*" R6000-00-DECLARE-AGENCEF-SECTION */
        private void R6000_00_DECLARE_AGENCEF_SECTION()
        {
            /*" -4609- MOVE 'R6000-DECLA-AGENCEF   ' TO PARAGRAFO. */
            _.Move("R6000-DECLA-AGENCEF   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4611- MOVE 'DECLARE AGENCIACEF   ' TO COMANDO. */
            _.Move("DECLARE AGENCIACEF   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4621- PERFORM R6000_00_DECLARE_AGENCEF_DB_DECLARE_1 */

            R6000_00_DECLARE_AGENCEF_DB_DECLARE_1();

            /*" -4623- PERFORM R6000_00_DECLARE_AGENCEF_DB_OPEN_1 */

            R6000_00_DECLARE_AGENCEF_DB_OPEN_1();

            /*" -4626- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4627- DISPLAY 'R6000 - PROBLEMAS DECLARE (AGENCEF) ..' */
                _.Display($"R6000 - PROBLEMAS DECLARE (AGENCEF) ..");

                /*" -4628- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -4628- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-OPEN-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_OPEN_1()
        {
            /*" -4623- EXEC SQL OPEN C01_AGENCEF END-EXEC. */

            C01_AGENCEF.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-SECTION */
        private void R6010_00_FETCH_AGENCEF_SECTION()
        {
            /*" -4638- MOVE 'R6010-FETCH-AGENCEF   ' TO PARAGRAFO. */
            _.Move("R6010-FETCH-AGENCEF   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4640- MOVE 'FETCH   AGENCIACEF   ' TO COMANDO. */
            _.Move("FETCH   AGENCIACEF   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4643- PERFORM R6010_00_FETCH_AGENCEF_DB_FETCH_1 */

            R6010_00_FETCH_AGENCEF_DB_FETCH_1();

            /*" -4646- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4647- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4648- MOVE 'S' TO WFIM-AGENCEF */
                    _.Move("S", WAREA_AUXILIAR.WFIM_AGENCEF);

                    /*" -4648- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_1 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_1();

                    /*" -4650- ELSE */
                }
                else
                {


                    /*" -4650- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_2 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_2();

                    /*" -4652- DISPLAY '3100 - (PROBLEMAS NO FETCH AGENCEF) ..' */
                    _.Display($"3100 - (PROBLEMAS NO FETCH AGENCEF) ..");

                    /*" -4653- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -4653- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-FETCH-1 */
        public void R6010_00_FETCH_AGENCEF_DB_FETCH_1()
        {
            /*" -4643- EXEC SQL FETCH C01_AGENCEF INTO :DCLAGENCIAS-CEF.COD-AGENCIA, :DCLMALHA-CEF.MALHACEF-COD-FONTE END-EXEC. */

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
            /*" -4648- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-CLOSE-2 */
        public void R6010_00_FETCH_AGENCEF_DB_CLOSE_2()
        {
            /*" -4650- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }

        [StopWatch]
        /*" R6020-00-CARREGA-FILIAL-SECTION */
        private void R6020_00_CARREGA_FILIAL_SECTION()
        {
            /*" -4663- MOVE 'R6020-CARREGA-FILIAL    ' TO PARAGRAFO. */
            _.Move("R6020-CARREGA-FILIAL    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4665- MOVE 'CARREGA FILIAL         ' TO COMANDO. */
            _.Move("CARREGA FILIAL         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4667- MOVE COD-AGENCIA OF DCLAGENCIAS-CEF TO TAB-AGENCIA (COD-AGENCIA OF DCLAGENCIAS-CEF) */
            _.Move(AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA, TAB_FILIAIS.TAB_FILIAL.FILLER_0[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_AGENCIA);

            /*" -4670- MOVE MALHACEF-COD-FONTE OF DCLMALHA-CEF TO TAB-FONTE (COD-AGENCIA OF DCLAGENCIAS-CEF) */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TAB_FILIAIS.TAB_FILIAL.FILLER_0[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_FONTE);

            /*" -4670- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6020_99_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -4681- CLOSE MOVTO-PRP-SASSE, MOVTO-STA-SASSE. */
            MOVTO_PRP_SASSE.Close();
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -4692- DISPLAY ' ' */
            _.Display($" ");

            /*" -4693- IF W-FIM-MOVTO-TERMO = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM")
            {

                /*" -4694- DISPLAY 'PF0623B - FIM NORMAL' */
                _.Display($"PF0623B - FIM NORMAL");

                /*" -4697- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -4698- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -4698- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -4700- ELSE */
            }
            else
            {


                /*" -4701- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_8.WSQLCODE);

                /*" -4702- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_8.WSQLERRD1);

                /*" -4703- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_8.WSQLERRD2);

                /*" -4704- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -4705- DISPLAY '*** PF0623B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0623B *** ROLLBACK EM ANDAMENTO ...");

                /*" -4706- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -4706- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -4709- MOVE 99 TO RETURN-CODE. */
                _.Move(99, RETURN_CODE);
            }


            /*" -4709- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}