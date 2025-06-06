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
using Sias.PessoaFisica.DB2.PF0618B;

namespace Code
{
    public class PF0618B
    {
        public bool IsCall { get; set; }

        public PF0618B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ...............  GERA STATUS DA MOVIMENTACAO DO       *      */
        /*"      *                           SEGURADO A CAIXA                     *      */
        /*"      *   ANALISTA .............. LUIZ CARLOS                          *      */
        /*"      *   PROGRAMA .............. PF0618B                              *      */
        /*"      *   REVISAO ............... 18/07/2013                           *      */
        /*"      *   ANALISTA .............. REGINALDO DA SILVA                   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * DEMANDA 176.726       SENSIBILIZAR A SITUACAO 'OBT' QUANDO CAN-*      */
        /*"      * VERSAO 17             CELAMENTO FOR POR MOTIVO DE SINISTRO E A *      */
        /*"      *                       DATA DE TERMINO DE VIGENCIA SERA A DATA  *      */
        /*"      *                       DA OCORRENCIA DO MESMO.                  *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.17          FRANK CARVALHO                           *      */
        /*"      *                       14/01/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORIA 163543       FALHA NA ROTINA DE SENSIBILIZACAO DE PRO-*      */
        /*"      * VERSAO 16             PROPOSTA REABILITADAS STATUS EMT (MOV228)*      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.16          MARCUS VALERIO                           *      */
        /*"      *                       30/10/2018                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 15             CRIAR UMA NOVA QUERY NA ROTINA R0156 PARA*      */
        /*"      * ATENDE RDM 3087       QUANDO RETORNAR -811.                    *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.15          FRANK CARVALHO E REGINALDO SILVA         *      */
        /*"      *                       26/01/2018                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 14             ALTERAR A QUERY DA ROTINA R0515  ACRES   *      */
        /*"      * ATENDE RDM 2841       CENTANDO A DATA INICIO E TERM VIGENCIA   *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.14          FRANK CARVALHO E REGINALDO SILVA         *      */
        /*"      *                       27/11/2017                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 13             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.13          SERGIO LORETO                            *      */
        /*"      *                       02/06/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 12             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA / SERGIO LORETO          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 11 = ATENDE CADMUS 85572                                *      */
        /*"      *                                                                *      */
        /*"      * 07/08/2013 - PROCURAR V.11  - REGINALDO SILVA                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 10 - ATENDE CADMUS 32886                                *      */
        /*"      *                                                                *      */
        /*"      * 18/11/2009 - PROCURAR V.10  - REGINALDO SILVA                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  9 - RETIRA LIMITACAO DE 50.000 REGISTROS               *      */
        /*"      *                                                                *      */
        /*"      * 21/07/2009                  - EDILANA CERQUEIRA.               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 8 - ALTERA CURSOR PARA TRATAMENTO COD-OPERACAO >= 199.  *      */
        /*"      *                                                                *      */
        /*"      * 15/07/2009 PROCURE POR V.08 - EDILANA CERQUEIRA.               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 7 - INCLUSAO DO PRODUTO 7707 E APOLICE 107700000013.    *      */
        /*"      *            PRESTAMISTA VENDA GITEL.                            *      */
        /*"      * 21/05/2009 PROCURE POR V.07 - MAURICIO LINKE.                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 6 - IGNORA SQLCODE -811                                 *      */
        /*"      *            NA ROTINA  R0160-00-VALIDAR-HPRP-FIDELIZ            *      */
        /*"      * 15/05/2009 PROCURE POR V.06 - EDILANA E. CERQUEIRA.            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 5 - ALTERACAO PARA TRATAMENTO PRODUTO SEGURO PRESTAMISTA*      */
        /*"      *                                                                *      */
        /*"      * 08/05/2009 PROCURE POR V.05 - EDILANA E. CERQUEIRA.            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 4 - DESPREZAR A APOLICE 107700000011 POIS ESTAH CAUSANDO*      */
        /*"      *            ABEND POR NAO ENCONTRAR REGISTRO NA SUBROTINA VG0710S      */
        /*"      *                                                                *      */
        /*"      * 20/02/2009 PROCURE POR V.04 - MAURICIO LINKE.                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 3 - DESPREZAR COD_PRODUTO_SIVPF IGUAL A 48. TRATA-SE DA *      */
        /*"      *            INTERNALIZACAO DE APOLICE ESPECIFICA DE VIDA.       *      */
        /*"      *                                                                *      */
        /*"      * 27/11/2007 PROCURE POR V.03 - MAURICIO LINKE.                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO - 02                                                  *      */
        /*"      *   EM 05-03-2004: PASSOU A TRATAR AS TABELAS DE VIDA NA FAIXA DE*      */
        /*"      *                  NUMERACAO 10000000000 E  19999999999, PASSANDO*      */
        /*"      *                  A INCLUIR O DV PARA ENVIO A CEF.              *      */
        /*"      *                                                                *      */
        /*"      *   PROCURE POR V.03                                                    */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 02 - PASSOU A DESPREZAR O MOVIMENTO PARA O PRODUTO 9313 *      */
        /*"      *             'CAIXA CONS RCIO PRESTAMISTA'.                     *      */
        /*"      *                                                                *      */
        /*"      * 28/03/2003 - PROCURE POR V02 - LUIZ CARLOS.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * POR ESTA GERANDO PROBLEMAS NO SIDEM, PASSAMOS TEMPORARIAMENTE A*      */
        /*"      * INFORMAR A SITUACAO 'VNC', NO CASO DE CANCELAMENTO POR FALTA DE*      */
        /*"      * PAGAMENTO DO EXECUTIVO. PROCURE POR 'TEMP*' - EM 23/04/2002    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * POR SOLICITACAO DA CEF, O PROCEDIMENTO ACIMA POSSOU A SER ADOTA*      */
        /*"      * DO PARA TODO SEGURO DE VIDA COM PAGAMENTO ANUAL, CANCELADO  POR*      */
        /*"      * FALTA DE PAGAMENTO.                                            *      */
        /*"      * PROCURE POR 'TEMP1' - EM 14/10/2005                            *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"1     ******************************************************************      */
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
        /*"01  WHOST-COUNT                      PIC S9(4) COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PARAMETROS.*/
        public PF0618B_PARAMETROS PARAMETROS { get; set; } = new PF0618B_PARAMETROS();
        public class PF0618B_PARAMETROS : VarBasis
        {
            /*"    05 LK-APOLICE                    PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05 LK-SUBGRUPO                   PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-IDADE                      PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-NASCIMENTO.*/
            public PF0618B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new PF0618B_LK_NASCIMENTO();
            public class PF0618B_LK_NASCIMENTO : VarBasis
            {
                /*"       10 LK-DATA-NASCIMENTO         PIC  9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05 LK-SALARIO                    PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-POR-ACIDENTE      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-ACIDENTES-PESSOAIS    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-TOTAL                 PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-RETURN-CODE                PIC S9(03) COMP-3.*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    05 LK-MENSAGEM                   PIC  X(77).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"01  VIND-DATA-REFERENCIA              PIC S9(04) COMP VALUE +0.*/
        }
        public IntBasis VIND_DATA_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DATA-MOVIMENTO               PIC S9(04) COMP VALUE +0.*/
        public IntBasis VIND_DATA_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DATA-INCLUSAO                PIC S9(04) COMP VALUE +0.*/
        public IntBasis VIND_DATA_INCLUSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WAREA-AUXILIAR.*/
        public PF0618B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0618B_WAREA_AUXILIAR();
        public class PF0618B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-MOVTO-VGAP              PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_VGAP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-PRP-FIDELIZ          PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_PRP_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-H-PRP-FIDELIZ        PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_H_PRP_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-SINISTRO             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-IND-IOF                     PIC S9(01)V9(4) COMP-3.*/
            public DoubleBasis W_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(01)V9(4)"), 4);
            /*"    05  W-TIME                        PIC  9(08).*/
            public IntBasis W_TIME { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    05  W-TIME-EDIT                   PIC  99.99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"    05  W-CONTROLE                    PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-TOT-LIDO                    PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_TOT_LIDO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
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
            /*"    05  W-NUM-PROPOSTA-NOVA           PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FILLER REDEFINES W-NUM-PROPOSTA-NOVA.*/
            private _REDEF_PF0618B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0618B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0618B_FILLER_0(); _.Move(W_NUM_PROPOSTA_NOVA, _filler_0); VarBasis.RedefinePassValue(W_NUM_PROPOSTA_NOVA, _filler_0, W_NUM_PROPOSTA_NOVA); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_NUM_PROPOSTA_NOVA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_NUM_PROPOSTA_NOVA); }
            }  //Redefines
            public class _REDEF_PF0618B_FILLER_0 : VarBasis
            {
                /*"        07  W-NUM-PROPOSTA-ATUAL      PIC 9(013).*/
                public IntBasis W_NUM_PROPOSTA_ATUAL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        07  W-DV-PROPOSTA-NOVA        PIC 9(001).*/
                public IntBasis W_DV_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-ABEND-CTR                   PIC  9(06)  VALUE ZEROS.*/

                public _REDEF_PF0618B_FILLER_0()
                {
                    W_NUM_PROPOSTA_ATUAL.ValueChanged += OnValueChanged;
                    W_DV_PROPOSTA_NOVA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_ABEND_CTR { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-LIDO-VIDA                   PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_LIDO_VIDA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-TOT-GERADO-STA              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_TOT_GERADO_STA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-COD-COBERTURA               PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER REDEFINES W-COD-COBERTURA.*/
            private _REDEF_PF0618B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0618B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0618B_FILLER_1(); _.Move(W_COD_COBERTURA, _filler_1); VarBasis.RedefinePassValue(W_COD_COBERTURA, _filler_1, W_COD_COBERTURA); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_COD_COBERTURA); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_COD_COBERTURA); }
            }  //Redefines
            public class _REDEF_PF0618B_FILLER_1 : VarBasis
            {
                /*"        10  W-SUBPRODUTO              PIC 9(003).*/
                public IntBasis W_SUBPRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        10  W-COBERTURA               PIC 9(001).*/
                public IntBasis W_COBERTURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-NSAS                        PIC 9(006).*/

                public _REDEF_PF0618B_FILLER_1()
                {
                    W_SUBPRODUTO.ValueChanged += OnValueChanged;
                    W_COBERTURA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSL                         PIC 9(006).*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0618B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0618B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0618B_FILLER_2(); _.Move(W_DATA_TRABALHO, _filler_2); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_2, W_DATA_TRABALHO); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_DATA_TRABALHO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0618B_FILLER_2 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0618B_FILLER_2()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0618B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0618B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0618B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0618B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0618B_W_DTMOVABE1()
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
            private _REDEF_PF0618B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0618B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0618B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0618B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0618B_W_DTMOVABE_I1()
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
            private _REDEF_PF0618B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0618B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0618B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0618B_W_DATA_SQL1 : VarBasis
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
                /*"    05 W-LEITURA-DB2                  PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0618B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_LEITURA_DB2 { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 LEITURA-DB2-NORMAL                      VALUE 1. */
							new SelectorItemBasis("LEITURA_DB2_NORMAL", "1")
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

            /*"01  WABEND*/
        }
        public PF0618B_WABEND WABEND { get; set; } = new PF0618B_WABEND();
        public class PF0618B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0618B_FILLER_3 FILLER_3 { get; set; } = new PF0618B_FILLER_3();
            public class PF0618B_FILLER_3 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0618B  '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0618B  ");
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
            public PF0618B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0618B_LOCALIZA_ABEND_1();
            public class PF0618B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0618B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0618B_LOCALIZA_ABEND_2();
            public class PF0618B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01    WS-HORAS.*/
            }
        }
        public PF0618B_WS_HORAS WS_HORAS { get; set; } = new PF0618B_WS_HORAS();
        public class PF0618B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_PF0618B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_PF0618B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_PF0618B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_PF0618B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_PF0618B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_PF0618B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_PF0618B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_PF0618B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_PF0618B_WS_HORA_FIM_R : VarBasis
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

                public _REDEF_PF0618B_WS_HORA_FIM_R()
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
        public PF0618B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new PF0618B_TOTAIS_ROT();
        public class PF0618B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<PF0618B_FILLER_12> FILLER_12 { get; set; } = new ListBasis<PF0618B_FILLER_12>(50);
            public class PF0618B_FILLER_12 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"01  WS-SELECT                   PIC  X(001) VALUE SPACES.*/
            }
        }
        public StringBasis WS_SELECT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");


        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.SEGVGAPH SEGVGAPH { get; set; } = new Dclgens.SEGVGAPH();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.COBPRPVA COBPRPVA { get; set; } = new Dclgens.COBPRPVA();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public PF0618B_MOVIMENTO_VGAP MOVIMENTO_VGAP { get; set; } = new PF0618B_MOVIMENTO_VGAP();
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
            /*" -459- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -460- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -461- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -465- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -466- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -467- DISPLAY '*               PROGRAMA PF0618B               *' . */
            _.Display($"*               PROGRAMA PF0618B               *");

            /*" -468- DISPLAY '*  GERA ARQUIVO STATUS DO MOVIM DIARIO A CAIXA *' . */
            _.Display($"*  GERA ARQUIVO STATUS DO MOVIM DIARIO A CAIXA *");

            /*" -469- DISPLAY '*           VERSAO:  17 - 14/01/2019           *' . */
            _.Display($"*           VERSAO:  17 - 14/01/2019           *");

            /*" -470- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -480- DISPLAY '*  PF0618B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0618B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -482- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -484- PERFORM R0007-00-OBTER-DT-PROCE. */

            R0007_00_OBTER_DT_PROCE_SECTION();

            /*" -486- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -488- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -490- MOVE 1 TO W-CURSOR. */
            _.Move(1, WAREA_AUXILIAR.W_CURSOR);

            /*" -492- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -494- PERFORM R0070-00-LER-MOVTO */

            R0070_00_LER_MOVTO_SECTION();

            /*" -496- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -499- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-VGAP EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_VGAP == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -501- PERFORM R0800-00-GERAR-TRAILLER. */

            R0800_00_GERAR_TRAILLER_SECTION();

            /*" -503- PERFORM R0850-00-CONTROLAR-ARQ-ENVIADO */

            R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -505- PERFORM R0870-00-GERAR-TOTAIS. */

            R0870_00_GERAR_TOTAIS_SECTION();

            /*" -507- PERFORM R0880-00-UPDATE-RELATORIOS. */

            R0880_00_UPDATE_RELATORIOS_SECTION();

            /*" -511- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -512- DISPLAY '*' . */
            _.Display($"*");

            /*" -513- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -521- DISPLAY '*  PF0618B - TERMINO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0618B - TERMINO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -522- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -524- DISPLAY '*' . */
            _.Display($"*");

            /*" -524- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -532- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -534- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -537- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -543- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -548- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -550- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -552- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -555- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -557- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -543- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
            /*" -567- MOVE 'R0007-00-OBTER-DT-PROCE' TO PARAGRAFO. */
            _.Move("R0007-00-OBTER-DT-PROCE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -569- MOVE 'SELECT SEGUROS.RELATORIOS' TO COMANDO. */
            _.Move("SELECT SEGUROS.RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -572- MOVE 'PF0618B' TO RELATORI-COD-RELATORIO. */
            _.Move("PF0618B", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -575- MOVE 'PF' TO RELATORI-IDE-SISTEMA. */
            _.Move("PF", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -584- PERFORM R0007_00_OBTER_DT_PROCE_DB_SELECT_1 */

            R0007_00_OBTER_DT_PROCE_DB_SELECT_1();

            /*" -587- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -588- DISPLAY 'PF0618B - FIM ANORMAL' */
                _.Display($"PF0618B - FIM ANORMAL");

                /*" -589- DISPLAY '          ERRO SELECT RELATORIOS' */
                _.Display($"          ERRO SELECT RELATORIOS");

                /*" -591- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -593- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -594- DISPLAY ' ' . */
            _.Display($" ");

            /*" -595- DISPLAY 'DATA REFERENCIA...... ' RELATORI-DATA-REFERENCIA. */
            _.Display($"DATA REFERENCIA...... {RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}");

        }

        [StopWatch]
        /*" R0007-00-OBTER-DT-PROCE-DB-SELECT-1 */
        public void R0007_00_OBTER_DT_PROCE_DB_SELECT_1()
        {
            /*" -584- EXEC SQL SELECT DATA_REFERENCIA INTO :RELATORI-DATA-REFERENCIA FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = :RELATORI-IDE-SISTEMA AND COD_RELATORIO = :RELATORI-COD-RELATORIO WITH UR END-EXEC. */

            var r0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 = new R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1()
            {
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
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
            /*" -605- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -607- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -607- OPEN OUTPUT MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -617- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -619- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -622- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -625- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -634- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -637- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -638- DISPLAY 'PF0618B - FIM ANORMAL' */
                _.Display($"PF0618B - FIM ANORMAL");

                /*" -639- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -641- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -642- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -644- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -647- MOVE ARQSIVPF-NSAS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -649- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -649- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -634- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

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
            /*" -659- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -661- MOVE 'DECLER MOVIMENTO' TO COMANDO. */
            _.Move("DECLER MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -856- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -858- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -862- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -862- MOVE 2 TO W-CURSOR. */
                _.Move(2, WAREA_AUXILIAR.W_CURSOR);
            }


        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -856- EXEC SQL DECLARE MOVIMENTO-VGAP CURSOR FOR SELECT '1' , B.NUM_APOLICE , B.COD_SUBGRUPO , B.COD_FONTE , B.NUM_PROPOSTA , B.TIPO_SEGURADO , B.NUM_CERTIFICADO , B.DAC_CERTIFICADO , B.IDE_SEXO , B.PCT_CONJUGE_VG , B.PCT_CONJUGE_AP , B.QTD_SAL_MORNATU , B.QTD_SAL_MORACID , B.QTD_SAL_INVPERM , B.TAXA_AP_MORACID , B.TAXA_AP_INVPERM , B.TAXA_AP_AMDS , B.TAXA_AP_DH , B.TAXA_AP_DIT , B.TAXA_VG , B.IMP_MORNATU_ANT , B.IMP_MORNATU_ATU , B.IMP_MORACID_ANT , B.IMP_MORACID_ATU , B.IMP_INVPERM_ANT , B.IMP_INVPERM_ATU , B.IMP_AMDS_ANT , B.IMP_AMDS_ATU , B.IMP_DH_ANT , B.IMP_DH_ATU , B.IMP_DIT_ANT , B.IMP_DIT_ATU , B.PRM_VG_ANT , B.PRM_VG_ATU , B.PRM_AP_ANT , B.PRM_AP_ATU , B.COD_OPERACAO , B.DATA_OPERACAO , B.DATA_REFERENCIA , B.DATA_MOVIMENTO , B.DATA_INCLUSAO , B.COD_SUBGRUPO_TRANS , B.SIT_REGISTRO , B.COD_USUARIO , A.COD_PRODUTO , A.PERI_PAGAMENTO FROM SEGUROS.PRODUTOS_VG A, SEGUROS.MOVIMENTO_VGAP B WHERE B.NUM_APOLICE = A.NUM_APOLICE AND A.NUM_APOLICE NOT IN (107700000011 , 107700000013 ) AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND A.COD_PRODUTO NOT IN (9913, 7708, 9341, 9350, 9348) AND A.ESTR_EMISS = 'MULT' AND A.ORIG_PRODU IN ( 'MULT' , 'VIDAZUL' , 'CAMP' ) AND B.DATA_INCLUSAO IS NOT NULL AND B.DATA_INCLUSAO >= :RELATORI-DATA-REFERENCIA AND B.DATA_INCLUSAO <= :SISTEMAS-DATA-MOV-ABERTO AND B.COD_OPERACAO > 199 UNION ALL SELECT '2' , B.NUM_APOLICE , B.COD_SUBGRUPO , B.COD_FONTE , B.NUM_PROPOSTA , B.TIPO_SEGURADO , B.NUM_CERTIFICADO , B.DAC_CERTIFICADO , B.IDE_SEXO , B.PCT_CONJUGE_VG , B.PCT_CONJUGE_AP , B.QTD_SAL_MORNATU , B.QTD_SAL_MORACID , B.QTD_SAL_INVPERM , B.TAXA_AP_MORACID , B.TAXA_AP_INVPERM , B.TAXA_AP_AMDS , B.TAXA_AP_DH , B.TAXA_AP_DIT , B.TAXA_VG , B.IMP_MORNATU_ANT , B.IMP_MORNATU_ATU , B.IMP_MORACID_ANT , B.IMP_MORACID_ATU , B.IMP_INVPERM_ANT , B.IMP_INVPERM_ATU , B.IMP_AMDS_ANT , B.IMP_AMDS_ATU , B.IMP_DH_ANT , B.IMP_DH_ATU , B.IMP_DIT_ANT , B.IMP_DIT_ATU , B.PRM_VG_ANT , B.PRM_VG_ATU , B.PRM_AP_ANT , B.PRM_AP_ATU , B.COD_OPERACAO , B.DATA_OPERACAO , B.DATA_REFERENCIA , B.DATA_MOVIMENTO , B.DATA_INCLUSAO , B.COD_SUBGRUPO_TRANS , B.SIT_REGISTRO , B.COD_USUARIO , A.COD_PRODUTO , A.PERI_PAGAMENTO FROM SEGUROS.PRODUTOS_VG A, SEGUROS.MOVIMENTO_VGAP B WHERE B.NUM_APOLICE = A.NUM_APOLICE AND A.NUM_APOLICE IN (107700000011, 107700000013) AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND A.COD_PRODUTO IN (7705, 7707) AND A.ESTR_EMISS = 'MULT' AND A.ORIG_PRODU IN ( 'MULT' , 'VIDAZUL' , 'CAMP' ) AND B.DATA_INCLUSAO IS NOT NULL AND B.DATA_INCLUSAO >= :RELATORI-DATA-REFERENCIA AND B.DATA_INCLUSAO <= :SISTEMAS-DATA-MOV-ABERTO AND B.COD_OPERACAO > 199 UNION ALL SELECT '3' , B.NUM_APOLICE , B.COD_SUBGRUPO , B.COD_FONTE , B.NUM_PROPOSTA , B.TIPO_SEGURADO , B.NUM_CERTIFICADO , B.DAC_CERTIFICADO , B.IDE_SEXO , B.PCT_CONJUGE_VG , B.PCT_CONJUGE_AP , B.QTD_SAL_MORNATU , B.QTD_SAL_MORACID , B.QTD_SAL_INVPERM , B.TAXA_AP_MORACID , B.TAXA_AP_INVPERM , B.TAXA_AP_AMDS , B.TAXA_AP_DH , B.TAXA_AP_DIT , B.TAXA_VG , B.IMP_MORNATU_ANT , B.IMP_MORNATU_ATU , B.IMP_MORACID_ANT , B.IMP_MORACID_ATU , B.IMP_INVPERM_ANT , B.IMP_INVPERM_ATU , B.IMP_AMDS_ANT , B.IMP_AMDS_ATU , B.IMP_DH_ANT , B.IMP_DH_ATU , B.IMP_DIT_ANT , B.IMP_DIT_ATU , B.PRM_VG_ANT , B.PRM_VG_ATU , B.PRM_AP_ANT , B.PRM_AP_ATU , B.COD_OPERACAO , B.DATA_OPERACAO , B.DATA_REFERENCIA , B.DATA_MOVIMENTO , B.DATA_INCLUSAO , B.COD_SUBGRUPO_TRANS , B.SIT_REGISTRO , B.COD_USUARIO , A.COD_PRODUTO , A.PERI_PAGAMENTO FROM SEGUROS.PRODUTOS_VG A , SEGUROS.MOVIMENTO_VGAP B , SEGUROS.RELATORIOS C WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND B.NUM_APOLICE = C.NUM_APOLICE AND B.COD_SUBGRUPO = C.COD_SUBGRUPO AND B.NUM_CERTIFICADO = C.NUM_CERTIFICADO AND B.DATA_OPERACAO IS NOT NULL AND B.COD_OPERACAO = 101 AND B.DATA_INCLUSAO >= '2018-10-30' AND B.DATA_INCLUSAO <= :SISTEMAS-DATA-MOV-ABERTO AND C.IDE_SISTEMA = 'VA' AND C.COD_RELATORIO = 'VA0412B' AND C.NUM_COPIAS = 2 AND C.SIT_REGISTRO = '0' ORDER BY 40 WITH UR END-EXEC. */
            MOVIMENTO_VGAP = new PF0618B_MOVIMENTO_VGAP(true);
            string GetQuery_MOVIMENTO_VGAP()
            {
                var query = @$"SELECT '1'
							, 
							B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.COD_FONTE
							, 
							B.NUM_PROPOSTA
							, 
							B.TIPO_SEGURADO
							, 
							B.NUM_CERTIFICADO
							, 
							B.DAC_CERTIFICADO
							, 
							B.IDE_SEXO
							, 
							B.PCT_CONJUGE_VG
							, 
							B.PCT_CONJUGE_AP
							, 
							B.QTD_SAL_MORNATU
							, 
							B.QTD_SAL_MORACID
							, 
							B.QTD_SAL_INVPERM
							, 
							B.TAXA_AP_MORACID
							, 
							B.TAXA_AP_INVPERM
							, 
							B.TAXA_AP_AMDS
							, 
							B.TAXA_AP_DH
							, 
							B.TAXA_AP_DIT
							, 
							B.TAXA_VG
							, 
							B.IMP_MORNATU_ANT
							, 
							B.IMP_MORNATU_ATU
							, 
							B.IMP_MORACID_ANT
							, 
							B.IMP_MORACID_ATU
							, 
							B.IMP_INVPERM_ANT
							, 
							B.IMP_INVPERM_ATU
							, 
							B.IMP_AMDS_ANT
							, 
							B.IMP_AMDS_ATU
							, 
							B.IMP_DH_ANT
							, 
							B.IMP_DH_ATU
							, 
							B.IMP_DIT_ANT
							, 
							B.IMP_DIT_ATU
							, 
							B.PRM_VG_ANT
							, 
							B.PRM_VG_ATU
							, 
							B.PRM_AP_ANT
							, 
							B.PRM_AP_ATU
							, 
							B.COD_OPERACAO
							, 
							B.DATA_OPERACAO
							, 
							B.DATA_REFERENCIA
							, 
							B.DATA_MOVIMENTO
							, 
							B.DATA_INCLUSAO
							, 
							B.COD_SUBGRUPO_TRANS
							, 
							B.SIT_REGISTRO
							, 
							B.COD_USUARIO
							, 
							A.COD_PRODUTO
							, 
							A.PERI_PAGAMENTO 
							FROM SEGUROS.PRODUTOS_VG A
							, 
							SEGUROS.MOVIMENTO_VGAP B 
							WHERE B.NUM_APOLICE = A.NUM_APOLICE 
							AND A.NUM_APOLICE NOT IN 
							(107700000011
							, 107700000013 ) 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND A.COD_PRODUTO NOT IN 
							(9913
							, 7708
							, 9341
							, 9350
							, 9348) 
							AND A.ESTR_EMISS = 'MULT' 
							AND A.ORIG_PRODU IN 
							( 'MULT'
							, 'VIDAZUL'
							, 'CAMP' ) 
							AND B.DATA_INCLUSAO IS NOT NULL 
							AND B.DATA_INCLUSAO >= 
							'{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND B.DATA_INCLUSAO <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.COD_OPERACAO > 199 
							UNION ALL 
							SELECT '2'
							, 
							B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.COD_FONTE
							, 
							B.NUM_PROPOSTA
							, 
							B.TIPO_SEGURADO
							, 
							B.NUM_CERTIFICADO
							, 
							B.DAC_CERTIFICADO
							, 
							B.IDE_SEXO
							, 
							B.PCT_CONJUGE_VG
							, 
							B.PCT_CONJUGE_AP
							, 
							B.QTD_SAL_MORNATU
							, 
							B.QTD_SAL_MORACID
							, 
							B.QTD_SAL_INVPERM
							, 
							B.TAXA_AP_MORACID
							, 
							B.TAXA_AP_INVPERM
							, 
							B.TAXA_AP_AMDS
							, 
							B.TAXA_AP_DH
							, 
							B.TAXA_AP_DIT
							, 
							B.TAXA_VG
							, 
							B.IMP_MORNATU_ANT
							, 
							B.IMP_MORNATU_ATU
							, 
							B.IMP_MORACID_ANT
							, 
							B.IMP_MORACID_ATU
							, 
							B.IMP_INVPERM_ANT
							, 
							B.IMP_INVPERM_ATU
							, 
							B.IMP_AMDS_ANT
							, 
							B.IMP_AMDS_ATU
							, 
							B.IMP_DH_ANT
							, 
							B.IMP_DH_ATU
							, 
							B.IMP_DIT_ANT
							, 
							B.IMP_DIT_ATU
							, 
							B.PRM_VG_ANT
							, 
							B.PRM_VG_ATU
							, 
							B.PRM_AP_ANT
							, 
							B.PRM_AP_ATU
							, 
							B.COD_OPERACAO
							, 
							B.DATA_OPERACAO
							, 
							B.DATA_REFERENCIA
							, 
							B.DATA_MOVIMENTO
							, 
							B.DATA_INCLUSAO
							, 
							B.COD_SUBGRUPO_TRANS
							, 
							B.SIT_REGISTRO
							, 
							B.COD_USUARIO
							, 
							A.COD_PRODUTO
							, 
							A.PERI_PAGAMENTO 
							FROM SEGUROS.PRODUTOS_VG A
							, 
							SEGUROS.MOVIMENTO_VGAP B 
							WHERE B.NUM_APOLICE = A.NUM_APOLICE 
							AND A.NUM_APOLICE IN (107700000011
							, 107700000013) 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND A.COD_PRODUTO IN (7705
							, 7707) 
							AND A.ESTR_EMISS = 'MULT' 
							AND A.ORIG_PRODU IN 
							( 'MULT'
							, 'VIDAZUL'
							, 'CAMP' ) 
							AND B.DATA_INCLUSAO IS NOT NULL 
							AND B.DATA_INCLUSAO >= 
							'{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND B.DATA_INCLUSAO <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.COD_OPERACAO > 199 
							UNION ALL 
							SELECT '3' 
							, B.NUM_APOLICE 
							, B.COD_SUBGRUPO 
							, B.COD_FONTE 
							, B.NUM_PROPOSTA 
							, B.TIPO_SEGURADO 
							, B.NUM_CERTIFICADO 
							, B.DAC_CERTIFICADO 
							, B.IDE_SEXO 
							, B.PCT_CONJUGE_VG 
							, B.PCT_CONJUGE_AP 
							, B.QTD_SAL_MORNATU 
							, B.QTD_SAL_MORACID 
							, B.QTD_SAL_INVPERM 
							, B.TAXA_AP_MORACID 
							, B.TAXA_AP_INVPERM 
							, B.TAXA_AP_AMDS 
							, B.TAXA_AP_DH 
							, B.TAXA_AP_DIT 
							, B.TAXA_VG 
							, B.IMP_MORNATU_ANT 
							, B.IMP_MORNATU_ATU 
							, B.IMP_MORACID_ANT 
							, B.IMP_MORACID_ATU 
							, B.IMP_INVPERM_ANT 
							, B.IMP_INVPERM_ATU 
							, B.IMP_AMDS_ANT 
							, B.IMP_AMDS_ATU 
							, B.IMP_DH_ANT 
							, B.IMP_DH_ATU 
							, B.IMP_DIT_ANT 
							, B.IMP_DIT_ATU 
							, B.PRM_VG_ANT 
							, B.PRM_VG_ATU 
							, B.PRM_AP_ANT 
							, B.PRM_AP_ATU 
							, B.COD_OPERACAO 
							, B.DATA_OPERACAO 
							, B.DATA_REFERENCIA 
							, B.DATA_MOVIMENTO 
							, B.DATA_INCLUSAO 
							, B.COD_SUBGRUPO_TRANS 
							, B.SIT_REGISTRO 
							, B.COD_USUARIO 
							, A.COD_PRODUTO 
							, A.PERI_PAGAMENTO 
							FROM SEGUROS.PRODUTOS_VG A 
							, SEGUROS.MOVIMENTO_VGAP B 
							, SEGUROS.RELATORIOS C 
							WHERE A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND B.NUM_APOLICE = C.NUM_APOLICE 
							AND B.COD_SUBGRUPO = C.COD_SUBGRUPO 
							AND B.NUM_CERTIFICADO = C.NUM_CERTIFICADO 
							AND B.DATA_OPERACAO IS NOT NULL 
							AND B.COD_OPERACAO = 101 
							AND B.DATA_INCLUSAO >= '2018-10-30' 
							AND B.DATA_INCLUSAO <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND C.IDE_SISTEMA = 'VA' 
							AND C.COD_RELATORIO = 'VA0412B' 
							AND C.NUM_COPIAS = 2 
							AND C.SIT_REGISTRO = '0' 
							ORDER BY 40";

                return query;
            }
            MOVIMENTO_VGAP.GetQueryEvent += GetQuery_MOVIMENTO_VGAP;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -858- EXEC SQL OPEN MOVIMENTO-VGAP END-EXEC. */

            MOVIMENTO_VGAP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -870- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -872- MOVE 'FETCH MOVIMENTO-VGAP' TO COMANDO. */
            _.Move("FETCH MOVIMENTO-VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -921- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -927- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -929- IF MOVIMVGA-NUM-CERTIFICADO = 84678205702 OR MOVIMVGA-NUM-CERTIFICADO = 13125130003665 */

                if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO == 84678205702 || MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO == 13125130003665)
                {

                    /*" -930- DISPLAY '*' */
                    _.Display($"*");

                    /*" -932- DISPLAY 'PF0618B - PROPOSTA RETIRADA DO MOVIMENTO => ' MOVIMVGA-NUM-CERTIFICADO */
                    _.Display($"PF0618B - PROPOSTA RETIRADA DO MOVIMENTO => {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}");

                    /*" -933- GO TO R0070-00-LER-MOVTO */
                    new Task(() => R0070_00_LER_MOVTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -934- END-IF */
                }


                /*" -938- END-IF */
            }


            /*" -939- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -940- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -941- MOVE 'FIM' TO W-FIM-MOVTO-VGAP */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_VGAP);

                    /*" -941- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -943- ELSE */
                }
                else
                {


                    /*" -944- IF SQLCODE EQUAL -501 */

                    if (DB.SQLCODE == -501)
                    {

                        /*" -945- MOVE 'FIM' TO W-FIM-MOVTO-VGAP */
                        _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_VGAP);

                        /*" -946- ELSE */
                    }
                    else
                    {


                        /*" -947- DISPLAY 'PF0618B - FIM ANORMAL' */
                        _.Display($"PF0618B - FIM ANORMAL");

                        /*" -949- DISPLAY '          ERRO FETCH CURSOR V0MOVIMENTO  ' SQLCODE */
                        _.Display($"          ERRO FETCH CURSOR V0MOVIMENTO  {DB.SQLCODE}");

                        /*" -950- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -951- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -952- ELSE */
                    }

                }

            }
            else
            {


                /*" -955- ADD 1 TO W-CONTROLE W-TOT-LIDO */
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;
                WAREA_AUXILIAR.W_TOT_LIDO.Value = WAREA_AUXILIAR.W_TOT_LIDO + 1;

                /*" -956- IF W-CONTROLE > 999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 999)
                {

                    /*" -957- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -958- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -959- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -961- DISPLAY '*  PF0618B ** TOTAL LIDOS... ' W-TOT-LIDO ' ' W-TIME-EDIT */

                    $"*  PF0618B ** TOTAL LIDOS... {WAREA_AUXILIAR.W_TOT_LIDO} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -966- END-IF */
                }


                /*" -974- COMPUTE W-TOT-GERADO-STA = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9. */
                WAREA_AUXILIAR.W_TOT_GERADO_STA.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9;
            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -921- EXEC SQL FETCH MOVIMENTO-VGAP INTO :WS-SELECT , :MOVIMVGA-NUM-APOLICE , :MOVIMVGA-COD-SUBGRUPO , :MOVIMVGA-COD-FONTE , :MOVIMVGA-NUM-PROPOSTA , :MOVIMVGA-TIPO-SEGURADO , :MOVIMVGA-NUM-CERTIFICADO , :MOVIMVGA-DAC-CERTIFICADO , :MOVIMVGA-IDE-SEXO , :MOVIMVGA-PCT-CONJUGE-VG , :MOVIMVGA-PCT-CONJUGE-AP , :MOVIMVGA-QTD-SAL-MORNATU , :MOVIMVGA-QTD-SAL-MORACID , :MOVIMVGA-QTD-SAL-INVPERM , :MOVIMVGA-TAXA-AP-MORACID , :MOVIMVGA-TAXA-AP-INVPERM , :MOVIMVGA-TAXA-AP-AMDS , :MOVIMVGA-TAXA-AP-DH , :MOVIMVGA-TAXA-AP-DIT , :MOVIMVGA-TAXA-VG , :MOVIMVGA-IMP-MORNATU-ANT , :MOVIMVGA-IMP-MORNATU-ATU , :MOVIMVGA-IMP-MORACID-ANT , :MOVIMVGA-IMP-MORACID-ATU , :MOVIMVGA-IMP-INVPERM-ANT , :MOVIMVGA-IMP-INVPERM-ATU , :MOVIMVGA-IMP-AMDS-ANT , :MOVIMVGA-IMP-AMDS-ATU , :MOVIMVGA-IMP-DH-ANT , :MOVIMVGA-IMP-DH-ATU , :MOVIMVGA-IMP-DIT-ANT , :MOVIMVGA-IMP-DIT-ATU , :MOVIMVGA-PRM-VG-ANT , :MOVIMVGA-PRM-VG-ATU , :MOVIMVGA-PRM-AP-ANT , :MOVIMVGA-PRM-AP-ATU , :MOVIMVGA-COD-OPERACAO , :MOVIMVGA-DATA-OPERACAO , :MOVIMVGA-DATA-REFERENCIA:VIND-DATA-REFERENCIA, :MOVIMVGA-DATA-MOVIMENTO:VIND-DATA-MOVIMENTO, :MOVIMVGA-DATA-INCLUSAO:VIND-DATA-INCLUSAO, :MOVIMVGA-COD-SUBGRUPO-TRANS , :MOVIMVGA-SIT-REGISTRO , :MOVIMVGA-COD-USUARIO , :PRODUVG-COD-PRODUTO , :PRODUVG-PERI-PAGAMENTO END-EXEC. */

            if (MOVIMENTO_VGAP.Fetch())
            {
                _.Move(MOVIMENTO_VGAP.WS_SELECT, WS_SELECT);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_COD_FONTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_TIPO_SEGURADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SEGURADO);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_DAC_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CERTIFICADO);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_VG);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_AP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_AP);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_MORACID);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_INVPERM);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_AMDS, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_AMDS);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DH, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DH);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DIT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DIT);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_TAXA_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA);
                _.Move(MOVIMENTO_VGAP.VIND_DATA_REFERENCIA, VIND_DATA_REFERENCIA);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO);
                _.Move(MOVIMENTO_VGAP.VIND_DATA_MOVIMENTO, VIND_DATA_MOVIMENTO);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO);
                _.Move(MOVIMENTO_VGAP.VIND_DATA_INCLUSAO, VIND_DATA_INCLUSAO);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO_TRANS, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO_TRANS);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO);
                _.Move(MOVIMENTO_VGAP.MOVIMVGA_COD_USUARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_USUARIO);
                _.Move(MOVIMENTO_VGAP.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(MOVIMENTO_VGAP.PRODUVG_PERI_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -941- EXEC SQL CLOSE MOVIMENTO-VGAP END-EXEC */

            MOVIMENTO_VGAP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -990- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -992- MOVE 'WRITE REG-HEADER-STA' TO COMANDO. */
            _.Move("WRITE REG-HEADER-STA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -994- MOVE SPACES TO REG-HEADER-STA. */
            _.Move("", LBFCT011.REG_HEADER_STA);

            /*" -997- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -1000- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -1001- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -1002- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -1004- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -1007- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -1010- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -1013- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -1016- MOVE ARQSIVPF-NSAS-SIVPF TO RH-NSAS OF REG-HEADER-STA */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_HEADER_STA.RH_NSAS);

            /*" -1016- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -1027- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1029- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1030- MOVE 0 TO W-LEITURA-DB2 */
            _.Move(0, WAREA_AUXILIAR.W_LEITURA_DB2);

            /*" -1034- MOVE 'NAO' TO W-EXISTE-SINISTRO */
            _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_SINISTRO);

            /*" -1038- IF MOVIMVGA-NUM-CERTIFICADO NOT LESS 10000000000 AND MOVIMVGA-NUM-CERTIFICADO NOT GREATER 19999999999 */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO >= 10000000000 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO <= 19999999999)
            {

                /*" -1040- MOVE MOVIMVGA-NUM-CERTIFICADO TO W-NUM-PROPOSTA-ATUAL */
                _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO, WAREA_AUXILIAR.FILLER_0.W_NUM_PROPOSTA_ATUAL);

                /*" -1042- MOVE MOVIMVGA-DAC-CERTIFICADO TO W-DV-PROPOSTA-NOVA */
                _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CERTIFICADO, WAREA_AUXILIAR.FILLER_0.W_DV_PROPOSTA_NOVA);

                /*" -1044- ELSE */
            }
            else
            {


                /*" -1048- MOVE MOVIMVGA-NUM-CERTIFICADO TO W-NUM-PROPOSTA-NOVA. */
                _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO, WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA);
            }


            /*" -1050- PERFORM R0155-00-VALIDAR-PROP-FIDELIZ. */

            R0155_00_VALIDAR_PROP_FIDELIZ_SECTION();

            /*" -1051- IF W-EXISTE-PRP-FIDELIZ EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_PRP_FIDELIZ == "SIM")
            {

                /*" -1052- PERFORM R0156-00-OBTER-PERIPGTO */

                R0156_00_OBTER_PERIPGTO_SECTION();

                /*" -1053- PERFORM R0158-00-VALIDAR-SITUACAOES */

                R0158_00_VALIDAR_SITUACAOES_SECTION();

                /*" -1054- PERFORM R0160-00-VALIDAR-HPRP-FIDELIZ */

                R0160_00_VALIDAR_HPRP_FIDELIZ_SECTION();

                /*" -1055- IF W-EXISTE-H-PRP-FIDELIZ EQUAL 'NAO' */

                if (WAREA_AUXILIAR.W_EXISTE_H_PRP_FIDELIZ == "NAO")
                {

                    /*" -1056- PERFORM R0500-00-PROCESSAR-VIDA */

                    R0500_00_PROCESSAR_VIDA_SECTION();

                    /*" -1057- IF LEITURA-DB2-NORMAL */

                    if (WAREA_AUXILIAR.W_LEITURA_DB2["LEITURA_DB2_NORMAL"])
                    {

                        /*" -1059- MOVE MOVIMVGA-DATA-INCLUSAO TO RELATORI-DATA-REFERENCIA */
                        _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

                        /*" -1060- IF WS-SELECT EQUAL '3' */

                        if (WS_SELECT == "3")
                        {

                            /*" -1062- MOVE MOVIMVGA-DATA-OPERACAO TO RELATORI-DATA-REFERENCIA */
                            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

                            /*" -1063- END-IF */
                        }


                        /*" -1064- PERFORM R0180-00-GERA-H-PROP-FIDEL */

                        R0180_00_GERA_H_PROP_FIDEL_SECTION();

                        /*" -1065- PERFORM R0190-00-GERAR-REGISTRO-TP1 */

                        R0190_00_GERAR_REGISTRO_TP1_SECTION();

                        /*" -1066- PERFORM R0570-00-GERAR-REGISTRO-TP2 */

                        R0570_00_GERAR_REGISTRO_TP2_SECTION();

                        /*" -1068- PERFORM R0580-00-GERAR-REGISTRO-TP3 */

                        R0580_00_GERAR_REGISTRO_TP3_SECTION();

                        /*" -1070- IF MOVIMVGA-COD-OPERACAO GREATER 199 AND LESS 600 */

                        if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 199 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 600)
                        {

                            /*" -1071- PERFORM R0585-00-GERAR-REGISTRO-TP4 */

                            R0585_00_GERAR_REGISTRO_TP4_SECTION();

                            /*" -1073- END-IF */
                        }


                        /*" -1074- IF WS-SELECT EQUAL '3' */

                        if (WS_SELECT == "3")
                        {

                            /*" -1075- PERFORM R0585-00-GERAR-REGISTRO-TP4 */

                            R0585_00_GERAR_REGISTRO_TP4_SECTION();

                            /*" -1076- PERFORM R0890-00-UPDATE-RELATORIOS */

                            R0890_00_UPDATE_RELATORIOS_SECTION();

                            /*" -1078- END-IF */
                        }


                        /*" -1080- PERFORM R0590-00-UPDATE-PROP-FIDELIZ. */

                        R0590_00_UPDATE_PROP_FIDELIZ_SECTION();
                    }

                }

            }


            /*" -1081- IF W-FIM-MOVTO-VGAP NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_VGAP != "FIM")
            {

                /*" -1082- PERFORM R0070-00-LER-MOVTO */

                R0070_00_LER_MOVTO_SECTION();

                /*" -1082- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0155-00-VALIDAR-PROP-FIDELIZ-SECTION */
        private void R0155_00_VALIDAR_PROP_FIDELIZ_SECTION()
        {
            /*" -1092- MOVE 'R0155-00-VALIDAR-PROP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0155-00-VALIDAR-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1094- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1097- MOVE MOVIMVGA-NUM-CERTIFICADO TO PROPOFID-NUM-PROPOSTA-SIVPF. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -1109- PERFORM R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1 */

            R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1();

            /*" -1112- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1113- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1114- MOVE 'NAO' TO W-EXISTE-PRP-FIDELIZ */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_PRP_FIDELIZ);

                    /*" -1115- ELSE */
                }
                else
                {


                    /*" -1116- DISPLAY 'PF0618B - FIM ANORMAL' */
                    _.Display($"PF0618B - FIM ANORMAL");

                    /*" -1117- DISPLAY '          ERRO SELECT TAB. PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO SELECT TAB. PROPOSTA-FIDELIZ");

                    /*" -1119- DISPLAY '          NUM PROPOSTA............ ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUM PROPOSTA............ {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -1121- DISPLAY '          SQLCODE................. ' SQLCODE */
                    _.Display($"          SQLCODE................. {DB.SQLCODE}");

                    /*" -1122- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1123- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1124- ELSE */
                }

            }
            else
            {


                /*" -1124- MOVE 'SIM' TO W-EXISTE-PRP-FIDELIZ. */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_PRP_FIDELIZ);
            }


        }

        [StopWatch]
        /*" R0155-00-VALIDAR-PROP-FIDELIZ-DB-SELECT-1 */
        public void R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1()
        {
            /*" -1109- EXEC SQL SELECT NUM_IDENTIFICACAO , COD_PRODUTO_SIVPF , COD_EMPRESA_SIVPF INTO :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-COD-EMPRESA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF AND COD_PRODUTO_SIVPF <> 48 WITH UR END-EXEC. */

            var r0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1 = new R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0155_SAIDA*/

        [StopWatch]
        /*" R0156-00-OBTER-PERIPGTO-SECTION */
        private void R0156_00_OBTER_PERIPGTO_SECTION()
        {
            /*" -1134- MOVE 'R0156-00-OBTER-PERIPGTO' TO PARAGRAFO. */
            _.Move("R0156-00-OBTER-PERIPGTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1136- MOVE 'SELECT OPCAO-PAG-VIDAZUL' TO COMANDO. */
            _.Move("SELECT OPCAO-PAG-VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1139- MOVE MOVIMVGA-NUM-CERTIFICADO TO OPCPAGVI-NUM-CERTIFICADO */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

            /*" -1149- PERFORM R0156_00_OBTER_PERIPGTO_DB_SELECT_1 */

            R0156_00_OBTER_PERIPGTO_DB_SELECT_1();

            /*" -1152-  EVALUATE SQLCODE  */

            /*" -1153-  WHEN ZEROS  */

            /*" -1153- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1154- CONTINUE */

                /*" -1155-  WHEN -811  */

                /*" -1155- ELSE IF   SQLCODE EQUALS  -811 */
            }
            else

            if (DB.SQLCODE == -811)
            {

                /*" -1156- PERFORM R0157-00-OBTER-PERIPGTO */

                R0157_00_OBTER_PERIPGTO_SECTION();

                /*" -1157-  WHEN OTHER  */

                /*" -1157- ELSE */
            }
            else
            {


                /*" -1158- DISPLAY 'PF0618B - FIM ANORMAL' */
                _.Display($"PF0618B - FIM ANORMAL");

                /*" -1159- DISPLAY '          ERRO SELECT TAB. OPCAO-PAG-VIDAZUL' */
                _.Display($"          ERRO SELECT TAB. OPCAO-PAG-VIDAZUL");

                /*" -1161- DISPLAY '          NUM PROPOSTA............ ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUM PROPOSTA............ {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1163- DISPLAY '          SQLCODE................. ' SQLCODE */
                _.Display($"          SQLCODE................. {DB.SQLCODE}");

                /*" -1164- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1165- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1166-  END-EVALUATE  */

                /*" -1166- END-IF */
            }


            /*" -1166- . */

        }

        [StopWatch]
        /*" R0156-00-OBTER-PERIPGTO-DB-SELECT-1 */
        public void R0156_00_OBTER_PERIPGTO_DB_SELECT_1()
        {
            /*" -1149- EXEC SQL SELECT PERI_PAGAMENTO INTO :OPCPAGVI-PERI-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND DATA_INIVIGENCIA <= :MOVIMVGA-DATA-INCLUSAO AND DATA_TERVIGENCIA >= :MOVIMVGA-DATA-INCLUSAO WITH UR END-EXEC */

            var r0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1 = new R0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1()
            {
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
                MOVIMVGA_DATA_INCLUSAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO.ToString(),
            };

            var executed_1 = R0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1.Execute(r0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0156_SAIDA*/

        [StopWatch]
        /*" R0157-00-OBTER-PERIPGTO-SECTION */
        private void R0157_00_OBTER_PERIPGTO_SECTION()
        {
            /*" -1176- MOVE 'R0157-00-OBTER-PERIPGTO' TO PARAGRAFO. */
            _.Move("R0157-00-OBTER-PERIPGTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1178- MOVE 'SELECT OPCAO-PAG-VIDAZUL' TO COMANDO. */
            _.Move("SELECT OPCAO-PAG-VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1185- PERFORM R0157_00_OBTER_PERIPGTO_DB_SELECT_1 */

            R0157_00_OBTER_PERIPGTO_DB_SELECT_1();

            /*" -1188-  EVALUATE SQLCODE  */

            /*" -1189-  WHEN ZEROS  */

            /*" -1189- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1190- CONTINUE */

                /*" -1191-  WHEN OTHER  */

                /*" -1191- ELSE */
            }
            else
            {


                /*" -1192- DISPLAY 'PF0618B - FIM ANORMAL' */
                _.Display($"PF0618B - FIM ANORMAL");

                /*" -1193- DISPLAY '          ERRO SELECT TAB. OPCAO-PAG-VIDAZUL I' */
                _.Display($"          ERRO SELECT TAB. OPCAO-PAG-VIDAZUL I");

                /*" -1195- DISPLAY '          NUM PROPOSTA............ ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUM PROPOSTA............ {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1197- DISPLAY '          SQLCODE................. ' SQLCODE */
                _.Display($"          SQLCODE................. {DB.SQLCODE}");

                /*" -1198- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1199- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1200-  END-EVALUATE  */

                /*" -1200- END-IF */
            }


            /*" -1201- . */

        }

        [StopWatch]
        /*" R0157-00-OBTER-PERIPGTO-DB-SELECT-1 */
        public void R0157_00_OBTER_PERIPGTO_DB_SELECT_1()
        {
            /*" -1185- EXEC SQL SELECT PERI_PAGAMENTO INTO :OPCPAGVI-PERI-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC */

            var r0157_00_OBTER_PERIPGTO_DB_SELECT_1_Query1 = new R0157_00_OBTER_PERIPGTO_DB_SELECT_1_Query1()
            {
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0157_00_OBTER_PERIPGTO_DB_SELECT_1_Query1.Execute(r0157_00_OBTER_PERIPGTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0157_SAIDA*/

        [StopWatch]
        /*" R0158-00-VALIDAR-SITUACAOES-SECTION */
        private void R0158_00_VALIDAR_SITUACAOES_SECTION()
        {
            /*" -1211- MOVE 'R0158-00-VALIDAR-SITUACAOES' TO PARAGRAFO. */
            _.Move("R0158-00-VALIDAR-SITUACAOES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1213- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1215- MOVE 'EMT' TO PROPFIDH-SIT-PROPOSTA */
            _.Move("EMT", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1218- MOVE 'PAG' TO PROPFIDH-SIT-COBRANCA-SIVPF. */
            _.Move("PAG", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -1219- IF WS-SELECT EQUAL '3' */

            if (WS_SELECT == "3")
            {

                /*" -1220- MOVE 228 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                _.Move(228, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                /*" -1222- END-IF. */
            }


            /*" -1224- IF MOVIMVGA-COD-OPERACAO GREATER 199 AND LESS 300 */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 199 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 300)
            {

                /*" -1227- MOVE 726 TO PROPFIDH-SIT-MOTIVO-SIVPF. */
                _.Move(726, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);
            }


            /*" -1229- IF MOVIMVGA-COD-OPERACAO GREATER 399 AND LESS 500 */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 399 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 500)
            {

                /*" -1231- MOVE 'CAN' TO PROPFIDH-SIT-PROPOSTA */
                _.Move("CAN", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

                /*" -1233- MOVE 'SUS' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                _.Move("SUS", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                /*" -1234- IF MOVIMVGA-COD-OPERACAO EQUAL 401 */

                if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 401)
                {

                    /*" -1236- MOVE 101 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                    _.Move(101, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                    /*" -1237- ELSE */
                }
                else
                {


                    /*" -1238- IF MOVIMVGA-COD-OPERACAO EQUAL 402 OR 412 OR 499 */

                    if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO.In("402", "412", "499"))
                    {

                        /*" -1240- MOVE 'SIM' TO W-EXISTE-SINISTRO */
                        _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_SINISTRO);

                        /*" -1242- MOVE 'OBT' TO PROPFIDH-SIT-PROPOSTA */
                        _.Move("OBT", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

                        /*" -1244- MOVE 102 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                        _.Move(102, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                        /*" -1245- ELSE */
                    }
                    else
                    {


                        /*" -1246- IF MOVIMVGA-COD-OPERACAO EQUAL 403 */

                        if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 403)
                        {

                            /*" -1248- MOVE 100 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                            _.Move(100, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                            /*" -1249- ELSE */
                        }
                        else
                        {


                            /*" -1250- IF MOVIMVGA-COD-OPERACAO EQUAL 417 */

                            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO == 417)
                            {

                                /*" -1252- MOVE 104 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                                _.Move(104, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                                /*" -1253- ELSE */
                            }
                            else
                            {


                                /*" -1257- MOVE 209 TO PROPFIDH-SIT-MOTIVO-SIVPF. */
                                _.Move(209, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);
                            }

                        }

                    }

                }

            }


            /*" -1258- IF PROPFIDH-SIT-PROPOSTA = 'CAN' */

            if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "CAN")
            {

                /*" -1260- IF PROPFIDH-SIT-MOTIVO-SIVPF = 100 */

                if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF == 100)
                {

                    /*" -1263- IF MOVIMVGA-NUM-APOLICE = 97010000889 AND MOVIMVGA-COD-SUBGRUPO = 1949 OR 5463 */

                    if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE == 97010000889 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.In("1949", "5463"))
                    {

                        /*" -1265- MOVE 'VNC' TO PROPFIDH-SIT-PROPOSTA */
                        _.Move("VNC", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

                        /*" -1268- MOVE 000 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                        _.Move(000, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                        /*" -1269- ELSE */
                    }
                    else
                    {


                        /*" -1270- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 12 */

                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 12)
                        {

                            /*" -1272- MOVE 'VNC' TO PROPFIDH-SIT-PROPOSTA */
                            _.Move("VNC", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

                            /*" -1276- MOVE 000 TO PROPFIDH-SIT-MOTIVO-SIVPF. */
                            _.Move(000, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);
                        }

                    }

                }

            }


            /*" -1278- IF MOVIMVGA-COD-OPERACAO GREATER 499 AND LESS 600 */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 499 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 600)
            {

                /*" -1281- MOVE 675 TO PROPFIDH-SIT-MOTIVO-SIVPF. */
                _.Move(675, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);
            }


            /*" -1283- IF MOVIMVGA-COD-OPERACAO GREATER 699 AND LESS 900 */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 699 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 900)
            {

                /*" -1286- MOVE 103 TO PROPFIDH-SIT-MOTIVO-SIVPF. */
                _.Move(103, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);
            }


            /*" -1287- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
            {

                /*" -1288- IF MOVIMVGA-COD-OPERACAO GREATER 100 AND LESS 300 */

                if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 100 && MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 300)
                {

                    /*" -1289- IF WS-SELECT NOT EQUAL '3' */

                    if (WS_SELECT != "3")
                    {

                        /*" -1290- MOVE 726 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                        _.Move(726, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                        /*" -1291- END-IF */
                    }


                    /*" -1292- END-IF */
                }


                /*" -1293- ELSE */
            }
            else
            {


                /*" -1294- IF MOVIMVGA-COD-OPERACAO LESS 200 OR GREATER 900 */

                if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO < 200 || MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO > 900)
                {

                    /*" -1295- IF WS-SELECT NOT EQUAL '3' */

                    if (WS_SELECT != "3")
                    {

                        /*" -1296- DISPLAY 'PF0618B - FIM ANORMAL' */
                        _.Display($"PF0618B - FIM ANORMAL");

                        /*" -1297- DISPLAY '          OPERACAO NAO ESPERADA' */
                        _.Display($"          OPERACAO NAO ESPERADA");

                        /*" -1299- DISPLAY '          CERTIFICADO.......... ' MOVIMVGA-NUM-CERTIFICADO */
                        _.Display($"          CERTIFICADO.......... {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}");

                        /*" -1301- DISPLAY '          CODIGO OPERACAO...... ' MOVIMVGA-COD-OPERACAO */
                        _.Display($"          CODIGO OPERACAO...... {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO}");

                        /*" -1302- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1303- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -1304- END-IF */
                    }


                    /*" -1305- END-IF */
                }


                /*" -1305- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0158_SAIDA*/

        [StopWatch]
        /*" R0160-00-VALIDAR-HPRP-FIDELIZ-SECTION */
        private void R0160_00_VALIDAR_HPRP_FIDELIZ_SECTION()
        {
            /*" -1316- MOVE 'R0160-00-VALIDAR-HPRP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0160-00-VALIDAR-HPRP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1318- MOVE 'SELECT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("SELECT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1339- PERFORM R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1 */

            R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1();

            /*" -1342- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1343- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1344- MOVE 'NAO' TO W-EXISTE-H-PRP-FIDELIZ */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_H_PRP_FIDELIZ);

                    /*" -1345- ELSE */
                }
                else
                {


                    /*" -1346- IF SQLCODE NOT EQUAL -811 */

                    if (DB.SQLCODE != -811)
                    {

                        /*" -1347- DISPLAY 'PF0618B - FIM ANORMAL' */
                        _.Display($"PF0618B - FIM ANORMAL");

                        /*" -1348- DISPLAY '          ERRO SELECT TAB. HIST-PROP-DIFELIZ' */
                        _.Display($"          ERRO SELECT TAB. HIST-PROP-DIFELIZ");

                        /*" -1350- DISPLAY '          NUM IDENTIFICACAO....... ' PROPOFID-NUM-IDENTIFICACAO */
                        _.Display($"          NUM IDENTIFICACAO....... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                        /*" -1352- DISPLAY '          SQLCODE................. ' SQLCODE */
                        _.Display($"          SQLCODE................. {DB.SQLCODE}");

                        /*" -1353- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1354- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -1355- END-IF */
                    }


                    /*" -1356- ELSE */
                }

            }
            else
            {


                /*" -1356- MOVE 'SIM' TO W-EXISTE-H-PRP-FIDELIZ. */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_H_PRP_FIDELIZ);
            }


        }

        [StopWatch]
        /*" R0160-00-VALIDAR-HPRP-FIDELIZ-DB-SELECT-1 */
        public void R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1()
        {
            /*" -1339- EXEC SQL SELECT SIT_MOTIVO_SIVPF, NSAS_SIVPF, NUM_IDENTIFICACAO, DATA_SITUACAO, SIT_PROPOSTA INTO :PROPFIDH-SIT-MOTIVO-SIVPF, :PROPFIDH-NSAS-SIVPF, :PROPFIDH-NUM-IDENTIFICACAO, :PROPFIDH-DATA-SITUACAO, :PROPFIDH-SIT-PROPOSTA FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPOFID-NUM-IDENTIFICACAO AND DATA_SITUACAO = :MOVIMVGA-DATA-OPERACAO AND SIT_PROPOSTA = :PROPFIDH-SIT-PROPOSTA AND SIT_MOTIVO_SIVPF = :PROPFIDH-SIT-MOTIVO-SIVPF WITH UR END-EXEC. */

            var r0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1 = new R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_SIT_MOTIVO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.ToString(),
                MOVIMVGA_DATA_OPERACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
            };

            var executed_1 = R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_SIT_MOTIVO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);
                _.Move(executed_1.PROPFIDH_NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);
                _.Move(executed_1.PROPFIDH_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPFIDH_DATA_SITUACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);
                _.Move(executed_1.PROPFIDH_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_SAIDA*/

        [StopWatch]
        /*" R0180-00-GERA-H-PROP-FIDEL-SECTION */
        private void R0180_00_GERA_H_PROP_FIDEL_SECTION()
        {
            /*" -1367- MOVE 'R0180-GERA-H-PROP-FIDEL' TO PARAGRAFO. */
            _.Move("R0180-GERA-H-PROP-FIDEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1369- MOVE 'INSERT HIST PROP FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST PROP FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1372- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1375- MOVE MOVIMVGA-DATA-OPERACAO TO PROPFIDH-DATA-SITUACAO. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -1378- MOVE ARQSIVPF-NSAS-SIVPF TO PROPFIDH-NSAS-SIVPF. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -1380- ADD 1 TO W-NSL. */
            WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;

            /*" -1383- MOVE W-NSL TO PROPFIDH-NSL. */
            _.Move(WAREA_AUXILIAR.W_NSL, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -1386- MOVE PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -1389- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -1400- PERFORM R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1 */

            R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1();

            /*" -1403- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1404- DISPLAY 'PF0618B - FIM ANORMAL' */
                _.Display($"PF0618B - FIM ANORMAL");

                /*" -1405- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -1407- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1409- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                /*" -1411- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1412- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1412- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0180-00-GERA-H-PROP-FIDEL-DB-INSERT-1 */
        public void R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1()
        {
            /*" -1400- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES ( :PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF , :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

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
            /*" -1424- MOVE 'R0190-00-GERAR-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0190-00-GERAR-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1426- MOVE 'WRITE REG-STA-PROPOSTA' TO COMANDO. */
            _.Move("WRITE REG-STA-PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1428- MOVE SPACES TO REG-STA-PROPOSTA. */
            _.Move("", LBFCT011.REG_STA_PROPOSTA);

            /*" -1431- MOVE '1' TO R1-TIPO-REG OF REG-STA-PROPOSTA. */
            _.Move("1", LBFCT011.REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -1434- MOVE W-NUM-PROPOSTA-NOVA TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -1437- MOVE PROPFIDH-SIT-PROPOSTA TO R1-SIT-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA, LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

            /*" -1440- MOVE PROPFIDH-SIT-MOTIVO-SIVPF TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);

            /*" -1443- MOVE PROPFIDH-DATA-SITUACAO TO W-DATA-SQL. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1444- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -1445- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -1447- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -1450- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -1453- MOVE ARQSIVPF-NSAS-SIVPF TO R1-NSAS OF REG-STA-PROPOSTA. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NSAS);

            /*" -1456- MOVE W-NSL TO R1-NSL OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_NSL, LBFCT011.REG_STA_PROPOSTA.R1_NSL);

            /*" -1458- WRITE REG-STA-SASSE FROM REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1459- ADD 1 TO W-QTD-LD-TIPO-1, W-ABEND-CTR. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;
            WAREA_AUXILIAR.W_ABEND_CTR.Value = WAREA_AUXILIAR.W_ABEND_CTR + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0190_SAIDA*/

        [StopWatch]
        /*" R0500-00-PROCESSAR-VIDA-SECTION */
        private void R0500_00_PROCESSAR_VIDA_SECTION()
        {
            /*" -1470- MOVE 'R0500-00-PROCESSAR-VIDA' TO PARAGRAFO. */
            _.Move("R0500-00-PROCESSAR-VIDA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1472- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1475- MOVE PROPOFID-COD-PRODUTO-SIVPF TO W-SUBPRODUTO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, WAREA_AUXILIAR.FILLER_1.W_SUBPRODUTO);

            /*" -1477- ADD 01 TO W-LIDO-VIDA. */
            WAREA_AUXILIAR.W_LIDO_VIDA.Value = WAREA_AUXILIAR.W_LIDO_VIDA + 01;

            /*" -1478- PERFORM R0505-00-OBTER-DADOS-SEGURADO */

            R0505_00_OBTER_DADOS_SEGURADO_SECTION();

            /*" -1479- PERFORM R0510-00-OBTER-COBERTURAS. */

            R0510_00_OBTER_COBERTURAS_SECTION();

            /*" -1480- PERFORM R0515-00-OBTER-VIGENCIA. */

            R0515_00_OBTER_VIGENCIA_SECTION();

            /*" -1481- IF LEITURA-DB2-NORMAL */

            if (WAREA_AUXILIAR.W_LEITURA_DB2["LEITURA_DB2_NORMAL"])
            {

                /*" -1482- PERFORM R0520-00-ACESSA-APOLICE */

                R0520_00_ACESSA_APOLICE_SECTION();

                /*" -1483- IF LEITURA-DB2-NORMAL */

                if (WAREA_AUXILIAR.W_LEITURA_DB2["LEITURA_DB2_NORMAL"])
                {

                    /*" -1484- PERFORM R0525-00-OBTER-PCT-IOF */

                    R0525_00_OBTER_PCT_IOF_SECTION();

                    /*" -1485- IF LEITURA-DB2-NORMAL */

                    if (WAREA_AUXILIAR.W_LEITURA_DB2["LEITURA_DB2_NORMAL"])
                    {

                        /*" -1485- PERFORM R0530-00-ACESSAR-PROPOSTAVA. */

                        R0530_00_ACESSAR_PROPOSTAVA_SECTION();
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_SAIDA*/

        [StopWatch]
        /*" R0505-00-OBTER-DADOS-SEGURADO-SECTION */
        private void R0505_00_OBTER_DADOS_SEGURADO_SECTION()
        {
            /*" -1496- MOVE 'R0505-00-OBTER-DADOS-SEGURADO' TO PARAGRAFO. */
            _.Move("R0505-00-OBTER-DADOS-SEGURADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1498- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1501- MOVE MOVIMVGA-NUM-CERTIFICADO TO SEGURVGA-NUM-CERTIFICADO. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);

            /*" -1504- MOVE '1' TO SEGURVGA-TIPO-SEGURADO. */
            _.Move("1", SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO);

            /*" -1521- PERFORM R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1 */

            R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1();

            /*" -1524- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1525- DISPLAY 'PF0618B - FIM ANORMAL' */
                _.Display($"PF0618B - FIM ANORMAL");

                /*" -1526- DISPLAY '          ERRO SELECT V0SEGURAVG' */
                _.Display($"          ERRO SELECT V0SEGURAVG");

                /*" -1528- DISPLAY '          CERTIFICADO........... ' SEGURVGA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO........... {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO}");

                /*" -1530- DISPLAY '          SQLCODE............... ' SQLCODE */
                _.Display($"          SQLCODE............... {DB.SQLCODE}");

                /*" -1531- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1531- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0505-00-OBTER-DADOS-SEGURADO-DB-SELECT-1 */
        public void R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1()
        {
            /*" -1521- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_ITEM, OCORR_HISTORICO , DATA_INIVIGENCIA INTO :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO , :SEGURVGA-DATA-INIVIGENCIA FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO AND TIPO_SEGURADO = :SEGURVGA-TIPO-SEGURADO WITH UR END-EXEC. */

            var r0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1 = new R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
                SEGURVGA_TIPO_SEGURADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO.ToString(),
            };

            var executed_1 = R0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1.Execute(r0505_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(executed_1.SEGURVGA_DATA_INIVIGENCIA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0505_SAIDA*/

        [StopWatch]
        /*" R0510-00-OBTER-COBERTURAS-SECTION */
        private void R0510_00_OBTER_COBERTURAS_SECTION()
        {
            /*" -1542- MOVE 'R0510-00-OBTER-COBERTURAS' TO PARAGRAFO. */
            _.Move("R0510-00-OBTER-COBERTURAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1544- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1547- MOVE MOVIMVGA-NUM-APOLICE TO LK-APOLICE. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE, PARAMETROS.LK_APOLICE);

            /*" -1550- MOVE MOVIMVGA-COD-SUBGRUPO TO LK-SUBGRUPO. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO, PARAMETROS.LK_SUBGRUPO);

            /*" -1572- MOVE ZEROS TO LK-IDADE LK-DATA-NASCIMENTO LK-SALARIO LK-PURO-MORTE-NATURAL LK-PURO-MORTE-ACIDENTAL LK-PURO-INV-PERMANENTE LK-PURO-ASS-MEDICA LK-PURO-DIARIA-HOSPITALAR LK-PURO-DIARIA-INTERNACAO LK-COBT-MORTE-NATURAL LK-COBT-MORTE-ACIDENTAL LK-COBT-INV-PERMANENTE LK-COBT-INV-POR-ACIDENTE LK-COBT-ASS-MEDICA LK-COBT-DIARIA-HOSPITALAR LK-COBT-DIARIA-INTERNACAO LK-PREM-MORTE-NATURAL LK-PREM-ACIDENTES-PESSOAIS LK-PREM-TOTAL LK-RETURN-CODE LK-MENSAGEM. */
            _.Move(0, PARAMETROS.LK_IDADE, PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO, PARAMETROS.LK_SALARIO, PARAMETROS.LK_PURO_MORTE_NATURAL, PARAMETROS.LK_PURO_MORTE_ACIDENTAL, PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_PURO_ASS_MEDICA, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR, PARAMETROS.LK_PURO_DIARIA_INTERNACAO, PARAMETROS.LK_COBT_MORTE_NATURAL, PARAMETROS.LK_COBT_MORTE_ACIDENTAL, PARAMETROS.LK_COBT_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_POR_ACIDENTE, PARAMETROS.LK_COBT_ASS_MEDICA, PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, PARAMETROS.LK_COBT_DIARIA_INTERNACAO, PARAMETROS.LK_PREM_MORTE_NATURAL, PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS, PARAMETROS.LK_PREM_TOTAL, PARAMETROS.LK_RETURN_CODE, PARAMETROS.LK_MENSAGEM);

            /*" -1575- MOVE MOVIMVGA-IMP-MORNATU-ATU TO LK-PURO-MORTE-NATURAL */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU, PARAMETROS.LK_PURO_MORTE_NATURAL);

            /*" -1578- MOVE MOVIMVGA-IMP-MORACID-ATU TO LK-PURO-MORTE-ACIDENTAL */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU, PARAMETROS.LK_PURO_MORTE_ACIDENTAL);

            /*" -1581- MOVE MOVIMVGA-IMP-INVPERM-ATU TO LK-PURO-INV-PERMANENTE */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU, PARAMETROS.LK_PURO_INV_PERMANENTE);

            /*" -1584- MOVE MOVIMVGA-IMP-AMDS-ATU TO LK-PURO-ASS-MEDICA */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU, PARAMETROS.LK_PURO_ASS_MEDICA);

            /*" -1587- MOVE MOVIMVGA-IMP-DH-ATU TO LK-PURO-DIARIA-HOSPITALAR */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR);

            /*" -1590- MOVE MOVIMVGA-IMP-DIT-ATU TO LK-PURO-DIARIA-INTERNACAO. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU, PARAMETROS.LK_PURO_DIARIA_INTERNACAO);

            /*" -1591- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
            {

                /*" -1592- GO TO R0510-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_SAIDA*/ //GOTO
                return;

                /*" -1597- END-IF. */
            }


            /*" -1599- IF LK-PURO-MORTE-NATURAL EQUAL 0 AND LK-PURO-MORTE-ACIDENTAL EQUAL 0 */

            if (PARAMETROS.LK_PURO_MORTE_NATURAL == 0 && PARAMETROS.LK_PURO_MORTE_ACIDENTAL == 0)
            {

                /*" -1600- DISPLAY '----- PF0618B - CAPITAIS IGUAIS A ZERO -----' */
                _.Display($"----- PF0618B - CAPITAIS IGUAIS A ZERO -----");

                /*" -1608- DISPLAY '- EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"- EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -1609- DISPLAY '-  PROPOSTA : ' MOVIMVGA-NUM-PROPOSTA */
                _.Display($"-  PROPOSTA : {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA}");

                /*" -1610- DISPLAY '--------------------------------------------' */
                _.Display($"--------------------------------------------");

                /*" -1611- GO TO R0510-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_SAIDA*/ //GOTO
                return;

                /*" -1614- END-IF. */
            }


            /*" -1616- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -1617- IF LK-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS.LK_RETURN_CODE != 00)
            {

                /*" -1618- DISPLAY 'PF0618B - FIM ANORMAL' */
                _.Display($"PF0618B - FIM ANORMAL");

                /*" -1619- DISPLAY '          ERRO SUBROTINA VG0710S ' */
                _.Display($"          ERRO SUBROTINA VG0710S ");

                /*" -1620- DISPLAY '          MENSAGEM.............. ' LK-MENSAGEM */
                _.Display($"          MENSAGEM.............. {PARAMETROS.LK_MENSAGEM}");

                /*" -1621- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1621- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_SAIDA*/

        [StopWatch]
        /*" R0515-00-OBTER-VIGENCIA-SECTION */
        private void R0515_00_OBTER_VIGENCIA_SECTION()
        {
            /*" -1631- MOVE 'R0515-OBTER-VIGENCIA' TO PARAGRAFO. */
            _.Move("R0515-OBTER-VIGENCIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1633- MOVE 'SELECT COBERAPOL' TO COMANDO. */
            _.Move("SELECT COBERAPOL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1634- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
            {

                /*" -1636- MOVE 77 TO APOLICOB-RAMO-COBERTURA */
                _.Move(77, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

                /*" -1638- MOVE 11 TO APOLICOB-COD-COBERTURA */
                _.Move(11, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

                /*" -1639- ELSE */
            }
            else
            {


                /*" -1640- IF LK-COBT-MORTE-NATURAL GREATER ZEROS */

                if (PARAMETROS.LK_COBT_MORTE_NATURAL > 00)
                {

                    /*" -1642- MOVE 93 TO APOLICOB-RAMO-COBERTURA */
                    _.Move(93, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

                    /*" -1644- MOVE 11 TO APOLICOB-COD-COBERTURA */
                    _.Move(11, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

                    /*" -1645- ELSE */
                }
                else
                {


                    /*" -1647- MOVE 81 TO APOLICOB-RAMO-COBERTURA */
                    _.Move(81, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

                    /*" -1650- MOVE 01 TO APOLICOB-COD-COBERTURA. */
                    _.Move(01, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);
                }

            }


            /*" -1682- PERFORM R0515_00_OBTER_VIGENCIA_DB_SELECT_1 */

            R0515_00_OBTER_VIGENCIA_DB_SELECT_1();

            /*" -1685- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1686- IF SQLCODE NOT EQUAL 100 AND -811 */

                if (!DB.SQLCODE.In("100", "-811"))
                {

                    /*" -1687- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1688- DISPLAY 'PF0618B - ERRO ACESSO COBERAPOL... ' SQLCODE */
                    _.Display($"PF0618B - ERRO ACESSO COBERAPOL... {DB.SQLCODE}");

                    /*" -1690- DISPLAY '          NUMERO APOLICE.......... ' SEGURVGA-NUM-APOLICE */
                    _.Display($"          NUMERO APOLICE.......... {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE}");

                    /*" -1692- DISPLAY '          ITEM.................... ' SEGURVGA-NUM-ITEM */
                    _.Display($"          ITEM.................... {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                    /*" -1694- DISPLAY '          DT.INIVIGENCIA.......... ' MOVIMVGA-DATA-MOVIMENTO */
                    _.Display($"          DT.INIVIGENCIA.......... {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO}");

                    /*" -1695- MOVE 0 TO W-LEITURA-DB2 */
                    _.Move(0, WAREA_AUXILIAR.W_LEITURA_DB2);

                    /*" -1697- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -1698- END-IF */
                }


                /*" -1699- ELSE */
            }
            else
            {


                /*" -1700- MOVE 1 TO W-LEITURA-DB2 */
                _.Move(1, WAREA_AUXILIAR.W_LEITURA_DB2);

                /*" -1707- END-IF */
            }


            /*" -1708- IF SQLCODE EQUAL 100 OR -811 */

            if (DB.SQLCODE.In("100", "-811"))
            {

                /*" -1709- PERFORM R0516-00-OBTER-DT-VIA-HIST */

                R0516_00_OBTER_DT_VIA_HIST_SECTION();

                /*" -1710- IF SQLCODE EQUAL 00 */

                if (DB.SQLCODE == 00)
                {

                    /*" -1711- PERFORM R0517-00-ACESSAR-COBERAPOL */

                    R0517_00_ACESSAR_COBERAPOL_SECTION();

                    /*" -1712- END-IF */
                }


                /*" -1714- END-IF */
            }


            /*" -1715- IF W-EXISTE-SINISTRO EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_SINISTRO == "SIM")
            {

                /*" -1716- PERFORM R0518-00-ACESSA-DT-OCORRENCIA */

                R0518_00_ACESSA_DT_OCORRENCIA_SECTION();

                /*" -1718- END-IF */
            }


            /*" -1718- . */

        }

        [StopWatch]
        /*" R0515-00-OBTER-VIGENCIA-DB-SELECT-1 */
        public void R0515_00_OBTER_VIGENCIA_DB_SELECT_1()
        {
            /*" -1682- EXEC SQL SELECT NUM_APOLICE, NUM_ITEM, NUM_ENDOSSO, RAMO_COBERTURA, COD_COBERTURA, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IMP_SEGURADA_IX INTO :APOLICOB-NUM-APOLICE, :APOLICOB-NUM-ITEM, :APOLICOB-NUM-ENDOSSO, :APOLICOB-RAMO-COBERTURA, :APOLICOB-COD-COBERTURA, :APOLICOB-DATA-INIVIGENCIA, :APOLICOB-DATA-TERVIGENCIA, :APOLICOB-IMP-SEGURADA-IX FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND RAMO_COBERTURA = :APOLICOB-RAMO-COBERTURA AND COD_COBERTURA = :APOLICOB-COD-COBERTURA AND DATA_INIVIGENCIA <= :MOVIMVGA-DATA-MOVIMENTO AND DATA_TERVIGENCIA >= :MOVIMVGA-DATA-MOVIMENTO WITH UR END-EXEC. */

            var r0515_00_OBTER_VIGENCIA_DB_SELECT_1_Query1 = new R0515_00_OBTER_VIGENCIA_DB_SELECT_1_Query1()
            {
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                MOVIMVGA_DATA_MOVIMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R0515_00_OBTER_VIGENCIA_DB_SELECT_1_Query1.Execute(r0515_00_OBTER_VIGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);
                _.Move(executed_1.APOLICOB_NUM_ITEM, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);
                _.Move(executed_1.APOLICOB_NUM_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);
                _.Move(executed_1.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
                _.Move(executed_1.APOLICOB_COD_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);
                _.Move(executed_1.APOLICOB_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);
                _.Move(executed_1.APOLICOB_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0515_SAIDA*/

        [StopWatch]
        /*" R0516-00-OBTER-DT-VIA-HIST-SECTION */
        private void R0516_00_OBTER_DT_VIA_HIST_SECTION()
        {
            /*" -1729- MOVE 'R0516-ABTER-DT-VIA-HIST' TO PARAGRAFO. */
            _.Move("R0516-ABTER-DT-VIA-HIST", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1731- MOVE 'SELECT V0HISTSEGVG' TO COMANDO. */
            _.Move("SELECT V0HISTSEGVG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1734- MOVE SEGURVGA-NUM-APOLICE TO SEGVGAPH-NUM-APOLICE . */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_APOLICE);

            /*" -1737- MOVE SEGURVGA-COD-SUBGRUPO TO SEGVGAPH-COD-SUBGRUPO . */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_SUBGRUPO);

            /*" -1740- MOVE SEGURVGA-NUM-ITEM TO SEGVGAPH-NUM-ITEM . */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_ITEM);

            /*" -1743- MOVE MOVIMVGA-COD-OPERACAO TO SEGVGAPH-COD-OPERACAO . */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_OPERACAO);

            /*" -1746- MOVE MOVIMVGA-DATA-MOVIMENTO TO SEGVGAPH-DATA-MOVIMENTO. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO);

            /*" -1765- PERFORM R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_1 */

            R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_1();

            /*" -1768- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1769- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -1771- MOVE MOVIMVGA-DATA-INCLUSAO TO SEGVGAPH-DATA-OPERACAO */
                    _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_OPERACAO);

                    /*" -1786- PERFORM R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2 */

                    R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2();

                    /*" -1788- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1789- DISPLAY ' ' */
                        _.Display($" ");

                        /*" -1790- DISPLAY 'PF0618B - ERRO ACESSO 1 HISTSEGVG ' SQLCODE */
                        _.Display($"PF0618B - ERRO ACESSO 1 HISTSEGVG {DB.SQLCODE}");

                        /*" -1792- DISPLAY '          NUMERO APOLICE......... ' SEGURVGA-NUM-APOLICE */
                        _.Display($"          NUMERO APOLICE......... {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE}");

                        /*" -1794- DISPLAY '          ITEM................... ' SEGURVGA-NUM-ITEM */
                        _.Display($"          ITEM................... {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                        /*" -1796- DISPLAY '          DATA OPERACAO.......... ' SEGVGAPH-DATA-OPERACAO */
                        _.Display($"          DATA OPERACAO.......... {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_OPERACAO}");

                        /*" -1797- MOVE 0 TO W-LEITURA-DB2 */
                        _.Move(0, WAREA_AUXILIAR.W_LEITURA_DB2);

                        /*" -1798- ELSE */
                    }
                    else
                    {


                        /*" -1799- MOVE 1 TO W-LEITURA-DB2 */
                        _.Move(1, WAREA_AUXILIAR.W_LEITURA_DB2);

                        /*" -1800- ELSE */
                    }

                }
                else
                {


                    /*" -1801- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1802- DISPLAY 'PF0618B - ERRO ACESSO 2 HISTSEGVG  ' SQLCODE */
                    _.Display($"PF0618B - ERRO ACESSO 2 HISTSEGVG  {DB.SQLCODE}");

                    /*" -1804- DISPLAY '          NUMERO APOLICE.......... ' SEGURVGA-NUM-APOLICE */
                    _.Display($"          NUMERO APOLICE.......... {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE}");

                    /*" -1806- DISPLAY '          ITEM.................... ' SEGURVGA-NUM-ITEM */
                    _.Display($"          ITEM.................... {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                    /*" -1808- DISPLAY '          DATA MOVIMENTO.......... ' SEGVGAPH-DATA-MOVIMENTO */
                    _.Display($"          DATA MOVIMENTO.......... {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO}");

                    /*" -1809- MOVE 0 TO W-LEITURA-DB2 */
                    _.Move(0, WAREA_AUXILIAR.W_LEITURA_DB2);

                    /*" -1810- ELSE */
                }

            }
            else
            {


                /*" -1810- MOVE 1 TO W-LEITURA-DB2. */
                _.Move(1, WAREA_AUXILIAR.W_LEITURA_DB2);
            }


        }

        [StopWatch]
        /*" R0516-00-OBTER-DT-VIA-HIST-DB-SELECT-1 */
        public void R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_1()
        {
            /*" -1765- EXEC SQL SELECT OCORR_HISTORICO INTO :SEGVGAPH-OCORR-HISTORICO FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :SEGVGAPH-NUM-APOLICE AND COD_SUBGRUPO = :SEGVGAPH-COD-SUBGRUPO AND NUM_ITEM = :SEGVGAPH-NUM-ITEM AND COD_OPERACAO = :SEGVGAPH-COD-OPERACAO AND DATA_MOVIMENTO = :SEGVGAPH-DATA-MOVIMENTO WITH UR END-EXEC. */

            var r0516_00_OBTER_DT_VIA_HIST_DB_SELECT_1_Query1 = new R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_1_Query1()
            {
                SEGVGAPH_DATA_MOVIMENTO = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO.ToString(),
                SEGVGAPH_COD_SUBGRUPO = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_SUBGRUPO.ToString(),
                SEGVGAPH_COD_OPERACAO = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_OPERACAO.ToString(),
                SEGVGAPH_NUM_APOLICE = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_APOLICE.ToString(),
                SEGVGAPH_NUM_ITEM = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_ITEM.ToString(),
            };

            var executed_1 = R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_1_Query1.Execute(r0516_00_OBTER_DT_VIA_HIST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGVGAPH_OCORR_HISTORICO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0516_SAIDA*/

        [StopWatch]
        /*" R0516-00-OBTER-DT-VIA-HIST-DB-SELECT-2 */
        public void R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2()
        {
            /*" -1786- EXEC SQL SELECT OCORR_HISTORICO INTO :SEGVGAPH-OCORR-HISTORICO FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :SEGVGAPH-NUM-APOLICE AND COD_SUBGRUPO = :SEGVGAPH-COD-SUBGRUPO AND NUM_ITEM = :SEGVGAPH-NUM-ITEM AND COD_OPERACAO = :SEGVGAPH-COD-OPERACAO AND DATA_OPERACAO = :SEGVGAPH-DATA-OPERACAO WITH UR END-EXEC */

            var r0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1 = new R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1()
            {
                SEGVGAPH_DATA_OPERACAO = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_OPERACAO.ToString(),
                SEGVGAPH_COD_SUBGRUPO = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_SUBGRUPO.ToString(),
                SEGVGAPH_COD_OPERACAO = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_OPERACAO.ToString(),
                SEGVGAPH_NUM_APOLICE = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_APOLICE.ToString(),
                SEGVGAPH_NUM_ITEM = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_ITEM.ToString(),
            };

            var executed_1 = R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1.Execute(r0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGVGAPH_OCORR_HISTORICO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_OCORR_HISTORICO);
            }


        }

        [StopWatch]
        /*" R0517-00-ACESSAR-COBERAPOL-SECTION */
        private void R0517_00_ACESSAR_COBERAPOL_SECTION()
        {
            /*" -1820- MOVE 'R0517-00-ACESSAR-COBERAPOL' TO PARAGRAFO. */
            _.Move("R0517-00-ACESSAR-COBERAPOL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1822- MOVE 'SELECT COBERAPOL' TO COMANDO. */
            _.Move("SELECT COBERAPOL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1850- PERFORM R0517_00_ACESSAR_COBERAPOL_DB_SELECT_1 */

            R0517_00_ACESSAR_COBERAPOL_DB_SELECT_1();

            /*" -1853- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1854- DISPLAY ' ' */
                _.Display($" ");

                /*" -1855- DISPLAY 'PF0618B - ERRO ACESSO COBERAPOL... ' SQLCODE */
                _.Display($"PF0618B - ERRO ACESSO COBERAPOL... {DB.SQLCODE}");

                /*" -1857- DISPLAY '          NUMERO APOLICE.......... ' SEGURVGA-NUM-APOLICE */
                _.Display($"          NUMERO APOLICE.......... {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE}");

                /*" -1859- DISPLAY '          ITEM.................... ' SEGURVGA-NUM-ITEM */
                _.Display($"          ITEM.................... {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                /*" -1861- DISPLAY '          OCORR-HISTORICO......... ' SEGVGAPH-OCORR-HISTORICO */
                _.Display($"          OCORR-HISTORICO......... {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_OCORR_HISTORICO}");

                /*" -1863- DISPLAY '          DT.INIVIGENCIA.......... ' MOVIMVGA-DATA-MOVIMENTO */
                _.Display($"          DT.INIVIGENCIA.......... {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO}");

                /*" -1864- MOVE 0 TO W-LEITURA-DB2 */
                _.Move(0, WAREA_AUXILIAR.W_LEITURA_DB2);

                /*" -1865- ELSE */
            }
            else
            {


                /*" -1865- MOVE 1 TO W-LEITURA-DB2. */
                _.Move(1, WAREA_AUXILIAR.W_LEITURA_DB2);
            }


        }

        [StopWatch]
        /*" R0517-00-ACESSAR-COBERAPOL-DB-SELECT-1 */
        public void R0517_00_ACESSAR_COBERAPOL_DB_SELECT_1()
        {
            /*" -1850- EXEC SQL SELECT NUM_APOLICE, NUM_ITEM, NUM_ENDOSSO, RAMO_COBERTURA, COD_COBERTURA, DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :APOLICOB-NUM-APOLICE, :APOLICOB-NUM-ITEM, :APOLICOB-NUM-ENDOSSO, :APOLICOB-RAMO-COBERTURA, :APOLICOB-COD-COBERTURA, :APOLICOB-DATA-INIVIGENCIA, :APOLICOB-DATA-TERVIGENCIA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND RAMO_COBERTURA = :APOLICOB-RAMO-COBERTURA AND COD_COBERTURA = :APOLICOB-COD-COBERTURA AND OCORR_HISTORICO = :SEGVGAPH-OCORR-HISTORICO WITH UR END-EXEC. */

            var r0517_00_ACESSAR_COBERAPOL_DB_SELECT_1_Query1 = new R0517_00_ACESSAR_COBERAPOL_DB_SELECT_1_Query1()
            {
                SEGVGAPH_OCORR_HISTORICO = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_OCORR_HISTORICO.ToString(),
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R0517_00_ACESSAR_COBERAPOL_DB_SELECT_1_Query1.Execute(r0517_00_ACESSAR_COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);
                _.Move(executed_1.APOLICOB_NUM_ITEM, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);
                _.Move(executed_1.APOLICOB_NUM_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);
                _.Move(executed_1.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
                _.Move(executed_1.APOLICOB_COD_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);
                _.Move(executed_1.APOLICOB_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);
                _.Move(executed_1.APOLICOB_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0517_SAIDA*/

        [StopWatch]
        /*" R0518-00-ACESSA-DT-OCORRENCIA-SECTION */
        private void R0518_00_ACESSA_DT_OCORRENCIA_SECTION()
        {
            /*" -1872- MOVE 'R0518-00-ACESSA-DT-OCORRENCIA' TO PARAGRAFO */
            _.Move("R0518-00-ACESSA-DT-OCORRENCIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1874- MOVE 'SELECT SINISTRO_MESTRE' TO COMANDO */
            _.Move("SELECT SINISTRO_MESTRE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1877- MOVE MOVIMVGA-NUM-CERTIFICADO TO SINISMES-NUM-CERTIFICADO */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);

            /*" -1885- PERFORM R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1 */

            R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1();

            /*" -1888-  EVALUATE SQLCODE  */

            /*" -1889-  WHEN ZEROS  */

            /*" -1889- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1891- MOVE 1 TO W-LEITURA-DB2 */
                _.Move(1, WAREA_AUXILIAR.W_LEITURA_DB2);

                /*" -1892-  WHEN +100  */

                /*" -1892- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -1894- MOVE APOLICOB-DATA-TERVIGENCIA TO SINISMES-DATA-OCORRENCIA */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);

                /*" -1896- MOVE 1 TO W-LEITURA-DB2 */
                _.Move(1, WAREA_AUXILIAR.W_LEITURA_DB2);

                /*" -1897-  WHEN OTHER  */

                /*" -1897- ELSE */
            }
            else
            {


                /*" -1898- DISPLAY ' ' */
                _.Display($" ");

                /*" -1900- DISPLAY 'PF0618B - ERRO SELECT TAB. SINISTRO_MESTRE. ' SQLCODE */
                _.Display($"PF0618B - ERRO SELECT TAB. SINISTRO_MESTRE. {DB.SQLCODE}");

                /*" -1902- DISPLAY '          NUMERO CERTIFICADO............... ' SINISMES-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO............... {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO}");

                /*" -1904- MOVE 0 TO W-LEITURA-DB2 */
                _.Move(0, WAREA_AUXILIAR.W_LEITURA_DB2);

                /*" -1906-  END-EVALUATE  */

                /*" -1906- END-IF */
            }


            /*" -1906- . */

        }

        [StopWatch]
        /*" R0518-00-ACESSA-DT-OCORRENCIA-DB-SELECT-1 */
        public void R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1()
        {
            /*" -1885- EXEC SQL SELECT DATA_OCORRENCIA INTO :SINISMES-DATA-OCORRENCIA FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO ORDER BY DATA_OCORRENCIA DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1 = new R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_CERTIFICADO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1.Execute(r0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0518_SAIDA*/

        [StopWatch]
        /*" R0520-00-ACESSA-APOLICE-SECTION */
        private void R0520_00_ACESSA_APOLICE_SECTION()
        {
            /*" -1917- MOVE 'R0520-ACESSA-APOLICE' TO PARAGRAFO. */
            _.Move("R0520-ACESSA-APOLICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1919- MOVE 'SELECT APOLICES' TO COMANDO. */
            _.Move("SELECT APOLICES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1922- MOVE MOVIMVGA-NUM-APOLICE TO APOLICES-NUM-APOLICE. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -1928- PERFORM R0520_00_ACESSA_APOLICE_DB_SELECT_1 */

            R0520_00_ACESSA_APOLICE_DB_SELECT_1();

            /*" -1931- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1932- DISPLAY ' ' */
                _.Display($" ");

                /*" -1933- DISPLAY 'PF0618B - ERRO SELECT TAB. APOLICE. ' SQLCODE */
                _.Display($"PF0618B - ERRO SELECT TAB. APOLICE. {DB.SQLCODE}");

                /*" -1935- DISPLAY '          NUMERO APOLICE........... ' APOLICES-NUM-APOLICE */
                _.Display($"          NUMERO APOLICE........... {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -1936- MOVE 0 TO W-LEITURA-DB2 */
                _.Move(0, WAREA_AUXILIAR.W_LEITURA_DB2);

                /*" -1937- ELSE */
            }
            else
            {


                /*" -1937- MOVE 1 TO W-LEITURA-DB2. */
                _.Move(1, WAREA_AUXILIAR.W_LEITURA_DB2);
            }


        }

        [StopWatch]
        /*" R0520-00-ACESSA-APOLICE-DB-SELECT-1 */
        public void R0520_00_ACESSA_APOLICE_DB_SELECT_1()
        {
            /*" -1928- EXEC SQL SELECT RAMO_EMISSOR INTO :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE WITH UR END-EXEC. */

            var r0520_00_ACESSA_APOLICE_DB_SELECT_1_Query1 = new R0520_00_ACESSA_APOLICE_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0520_00_ACESSA_APOLICE_DB_SELECT_1_Query1.Execute(r0520_00_ACESSA_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_SAIDA*/

        [StopWatch]
        /*" R0525-00-OBTER-PCT-IOF-SECTION */
        private void R0525_00_OBTER_PCT_IOF_SECTION()
        {
            /*" -1947- MOVE 'R0525-OBTER-PCT-IOF' TO PARAGRAFO. */
            _.Move("R0525-OBTER-PCT-IOF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1949- MOVE 'SELECT RAMOIND' TO COMANDO. */
            _.Move("SELECT RAMOIND", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1952- MOVE APOLICES-RAMO-EMISSOR TO RAMOCOMP-RAMO-EMISSOR. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR);

            /*" -1955- MOVE APOLICOB-DATA-INIVIGENCIA TO RAMOCOMP-DATA-INIVIGENCIA. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA);

            /*" -1966- PERFORM R0525_00_OBTER_PCT_IOF_DB_SELECT_1 */

            R0525_00_OBTER_PCT_IOF_DB_SELECT_1();

            /*" -1969- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1970- DISPLAY ' ' */
                _.Display($" ");

                /*" -1971- DISPLAY 'PF0618B - ERRO SELECT TAB. RAMOIND  ' SQLCODE */
                _.Display($"PF0618B - ERRO SELECT TAB. RAMOIND  {DB.SQLCODE}");

                /*" -1973- DISPLAY '          CODIGO DO RAMO........  ' RAMOCOMP-RAMO-EMISSOR */
                _.Display($"          CODIGO DO RAMO........  {RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR}");

                /*" -1975- DISPLAY '          DATA INICIO VIGENCIA..  ' RAMOCOMP-DATA-INIVIGENCIA */
                _.Display($"          DATA INICIO VIGENCIA..  {RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA}");

                /*" -1977- DISPLAY '          PROPOSTA..............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          PROPOSTA..............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1978- MOVE 0 TO W-LEITURA-DB2 */
                _.Move(0, WAREA_AUXILIAR.W_LEITURA_DB2);

                /*" -1979- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1980- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1981- ELSE */
            }
            else
            {


                /*" -1982- MOVE 1 TO W-LEITURA-DB2 */
                _.Move(1, WAREA_AUXILIAR.W_LEITURA_DB2);

                /*" -1983- COMPUTE W-IND-IOF = (RAMOCOMP-PCT-IOCC-RAMO / 100) + 1. */
                WAREA_AUXILIAR.W_IND_IOF.Value = (RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f) + 1;
            }


        }

        [StopWatch]
        /*" R0525-00-OBTER-PCT-IOF-DB-SELECT-1 */
        public void R0525_00_OBTER_PCT_IOF_DB_SELECT_1()
        {
            /*" -1966- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :RAMOCOMP-RAMO-EMISSOR AND DATA_INIVIGENCIA <= :RAMOCOMP-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :RAMOCOMP-DATA-INIVIGENCIA WITH UR END-EXEC. */

            var r0525_00_OBTER_PCT_IOF_DB_SELECT_1_Query1 = new R0525_00_OBTER_PCT_IOF_DB_SELECT_1_Query1()
            {
                RAMOCOMP_DATA_INIVIGENCIA = RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA.ToString(),
                RAMOCOMP_RAMO_EMISSOR = RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R0525_00_OBTER_PCT_IOF_DB_SELECT_1_Query1.Execute(r0525_00_OBTER_PCT_IOF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0525_SAIDA*/

        [StopWatch]
        /*" R0530-00-ACESSAR-PROPOSTAVA-SECTION */
        private void R0530_00_ACESSAR_PROPOSTAVA_SECTION()
        {
            /*" -1993- MOVE 'R0530-ACESSAR-PROPOSTVA' TO PARAGRAFO. */
            _.Move("R0530-ACESSAR-PROPOSTVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1995- MOVE 'SELECT PROPOSTAVA' TO COMANDO. */
            _.Move("SELECT PROPOSTAVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1998- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO PROPOVA-NUM-CERTIFICADO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -2009- PERFORM R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1 */

            R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1();

            /*" -2012- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2013- DISPLAY ' ' */
                _.Display($" ");

                /*" -2014- DISPLAY 'PF0618B - ERRO SELECT TAB. PROPOSTAVA  ' SQLCODE */
                _.Display($"PF0618B - ERRO SELECT TAB. PROPOSTAVA  {DB.SQLCODE}");

                /*" -2016- DISPLAY '          CERTIFICADO................  ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO................  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2017- MOVE 0 TO W-LEITURA-DB2 */
                _.Move(0, WAREA_AUXILIAR.W_LEITURA_DB2);

                /*" -2018- ELSE */
            }
            else
            {


                /*" -2018- MOVE 1 TO W-LEITURA-DB2. */
                _.Move(1, WAREA_AUXILIAR.W_LEITURA_DB2);
            }


        }

        [StopWatch]
        /*" R0530-00-ACESSAR-PROPOSTAVA-DB-SELECT-1 */
        public void R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -2009- EXEC SQL SELECT COD_PRODUTO, DATA_MOVIMENTO, IDE_SEXO INTO :PROPOVA-COD-PRODUTO, :PROPOVA-DATA-MOVIMENTO, :PROPOVA-IDE-SEXO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1 = new R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1.Execute(r0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(executed_1.PROPOVA_DATA_MOVIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO);
                _.Move(executed_1.PROPOVA_IDE_SEXO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_SAIDA*/

        [StopWatch]
        /*" R0570-00-GERAR-REGISTRO-TP2-SECTION */
        private void R0570_00_GERAR_REGISTRO_TP2_SECTION()
        {
            /*" -2028- MOVE 'R0570-00-GERAR-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0570-00-GERAR-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2030- MOVE 'WRITE REG-APOL-SASSE' TO COMANDO. */
            _.Move("WRITE REG-APOL-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2032- MOVE SPACES TO REG-APOL-SASSE. */
            _.Move("", LBFCT016.REG_APOL_SASSE);

            /*" -2035- MOVE '2' TO R2-TIPO-REG OF REG-APOL-SASSE. */
            _.Move("2", LBFCT016.REG_APOL_SASSE.R2_TIPO_REG);

            /*" -2044- MOVE W-NUM-PROPOSTA-NOVA TO R2-NUM-PROPOSTA OF REG-APOL-SASSE, R2-NRCERTIF OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LBFCT016.REG_APOL_SASSE.R2_NUM_PROPOSTA, LBFCT016.REG_APOL_SASSE.R2_NRCERTIF);

            /*" -2045- IF W-EXISTE-SINISTRO EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_SINISTRO == "SIM")
            {

                /*" -2047- MOVE SEGURVGA-DATA-INIVIGENCIA TO APOLICOB-DATA-INIVIGENCIA */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);

                /*" -2049- MOVE SINISMES-DATA-OCORRENCIA TO APOLICOB-DATA-TERVIGENCIA */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);

                /*" -2051- END-IF */
            }


            /*" -2053- MOVE APOLICOB-DATA-INIVIGENCIA TO W-DATA-SQL. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2055- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -2057- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -2059- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -2062- MOVE W-DATA-TRABALHO TO R2-DTINIVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTINIVIG);

            /*" -2064- MOVE APOLICOB-DATA-TERVIGENCIA TO W-DATA-SQL. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2066- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -2068- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -2071- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -2074- MOVE W-DATA-TRABALHO TO R2-DTTERVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTTERVIG);

            /*" -2078- COMPUTE R2-VAL-PREMIO OF REG-APOL-SASSE = MOVIMVGA-PRM-VG-ATU + MOVIMVGA-PRM-AP-ATU . */
            LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU + MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU;

            /*" -2081- COMPUTE W-PRM-LIQ = R2-VAL-PREMIO OF REG-APOL-SASSE / W-IND-IOF. */
            WAREA_AUXILIAR.W_PRM_LIQ.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO / WAREA_AUXILIAR.W_IND_IOF;

            /*" -2084- COMPUTE R2-VAL-IOF OF REG-APOL-SASSE = R2-VAL-PREMIO OF REG-APOL-SASSE - W-PRM-LIQ. */
            LBFCT016.REG_APOL_SASSE.R2_VAL_IOF.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO - WAREA_AUXILIAR.W_PRM_LIQ;

            /*" -2086- WRITE REG-STA-SASSE FROM REG-APOL-SASSE. */
            _.Move(LBFCT016.REG_APOL_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -2086- ADD 1 TO W-QTD-LD-TIPO-2. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_SAIDA*/

        [StopWatch]
        /*" R0580-00-GERAR-REGISTRO-TP3-SECTION */
        private void R0580_00_GERAR_REGISTRO_TP3_SECTION()
        {
            /*" -2096- MOVE 'R0580-00-GERAR-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0580-00-GERAR-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2098- MOVE 'WRITE REG-COBER-SASSE' TO COMANDO. */
            _.Move("WRITE REG-COBER-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2100- MOVE SPACES TO REG-COBER-SASSE. */
            _.Move("", LBFCT016.REG_COBER_SASSE);

            /*" -2103- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -2106- MOVE W-NUM-PROPOSTA-NOVA TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -2107- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
            {

                /*" -2111- MOVE ZEROS TO LK-COBT-MORTE-NATURAL LK-COBT-MORTE-ACIDENTAL LK-COBT-INV-PERMANENTE LK-COBT-INV-POR-ACIDENTE */
                _.Move(0, PARAMETROS.LK_COBT_MORTE_NATURAL, PARAMETROS.LK_COBT_MORTE_ACIDENTAL, PARAMETROS.LK_COBT_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_POR_ACIDENTE);

                /*" -2113- MOVE APOLICOB-IMP-SEGURADA-IX TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -2114- MOVE 1 TO W-COBERTURA */
                _.Move(1, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                /*" -2116- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -2118- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -2120- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -2122- MOVE APOLICOB-IMP-SEGURADA-IX TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

            /*" -2123- MOVE 2 TO W-COBERTURA */
            _.Move(2, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

            /*" -2125- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
            _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

            /*" -2127- ADD 1 TO W-QTD-LD-TIPO-3 */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

            /*" -2129- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
            _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -2130- IF LK-COBT-MORTE-NATURAL GREATER ZEROS */

            if (PARAMETROS.LK_COBT_MORTE_NATURAL > 00)
            {

                /*" -2132- MOVE LK-COBT-MORTE-NATURAL TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(PARAMETROS.LK_COBT_MORTE_NATURAL, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -2133- MOVE 1 TO W-COBERTURA */
                _.Move(1, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                /*" -2135- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -2137- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -2139- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -2140- IF LK-COBT-MORTE-ACIDENTAL GREATER ZEROS */

            if (PARAMETROS.LK_COBT_MORTE_ACIDENTAL > 00)
            {

                /*" -2142- MOVE LK-COBT-MORTE-ACIDENTAL TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(PARAMETROS.LK_COBT_MORTE_ACIDENTAL, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -2143- MOVE 2 TO W-COBERTURA */
                _.Move(2, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                /*" -2145- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -2147- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -2149- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -2150- IF LK-COBT-INV-PERMANENTE GREATER ZEROS */

            if (PARAMETROS.LK_COBT_INV_PERMANENTE > 00)
            {

                /*" -2151- IF PROPOVA-COD-PRODUTO NOT EQUAL 9703 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO != 9703)
                {

                    /*" -2153- MOVE LK-COBT-INV-PERMANENTE TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                    _.Move(PARAMETROS.LK_COBT_INV_PERMANENTE, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                    /*" -2154- MOVE 3 TO W-COBERTURA */
                    _.Move(3, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                    /*" -2156- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                    _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                    /*" -2158- ADD 1 TO W-QTD-LD-TIPO-3 */
                    WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                    /*" -2160- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                    _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                    MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
                }

            }


            /*" -2161- IF LK-COBT-INV-POR-ACIDENTE GREATER ZEROS */

            if (PARAMETROS.LK_COBT_INV_POR_ACIDENTE > 00)
            {

                /*" -2163- MOVE LK-COBT-INV-POR-ACIDENTE TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(PARAMETROS.LK_COBT_INV_POR_ACIDENTE, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -2164- MOVE 4 TO W-COBERTURA */
                _.Move(4, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                /*" -2166- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -2168- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -2173- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -2174- IF PROPOVA-COD-PRODUTO = 9707 OR 9309 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9707", "9309"))
            {

                /*" -2175- IF PROPOVA-IDE-SEXO = 'M' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO == "M")
                {

                    /*" -2176- IF LK-COBT-MORTE-NATURAL GREATER ZEROS */

                    if (PARAMETROS.LK_COBT_MORTE_NATURAL > 00)
                    {

                        /*" -2178- COMPUTE R3-VAL-COBERTURA OF REG-COBER-SASSE = LK-COBT-MORTE-NATURAL / 2 */
                        LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA.Value = PARAMETROS.LK_COBT_MORTE_NATURAL / 2f;

                        /*" -2179- MOVE 5 TO W-COBERTURA */
                        _.Move(5, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                        /*" -2181- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                        _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                        /*" -2183- ADD 1 TO W-QTD-LD-TIPO-3 */
                        WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                        /*" -2188- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                        _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                        MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
                    }

                }

            }


            /*" -2189- IF PROPOVA-COD-PRODUTO = 9705 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9705)
            {

                /*" -2190- IF LK-COBT-MORTE-NATURAL GREATER ZEROS */

                if (PARAMETROS.LK_COBT_MORTE_NATURAL > 00)
                {

                    /*" -2192- COMPUTE R3-VAL-COBERTURA OF REG-COBER-SASSE = LK-COBT-MORTE-NATURAL / 2 */
                    LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA.Value = PARAMETROS.LK_COBT_MORTE_NATURAL / 2f;

                    /*" -2193- MOVE 5 TO W-COBERTURA */
                    _.Move(5, WAREA_AUXILIAR.FILLER_1.W_COBERTURA);

                    /*" -2195- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                    _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                    /*" -2197- ADD 1 TO W-QTD-LD-TIPO-3 */
                    WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                    /*" -2197- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                    _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                    MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0580_SAIDA*/

        [StopWatch]
        /*" R0585-00-GERAR-REGISTRO-TP4-SECTION */
        private void R0585_00_GERAR_REGISTRO_TP4_SECTION()
        {
            /*" -2209- MOVE 'R0585-00-GERAR-REGISTRO-TP4' TO PARAGRAFO. */
            _.Move("R0585-00-GERAR-REGISTRO-TP4", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2211- MOVE 'WRITE REG-PAGAMENTO' TO COMANDO. */
            _.Move("WRITE REG-PAGAMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2213- MOVE SPACES TO REG-PGTO-SASSE. */
            _.Move("", LBFCT016.REG_PGTO_SASSE);

            /*" -2217- PERFORM R0586-00-OBTER-DT-MOVTO. */

            R0586_00_OBTER_DT_MOVTO_SECTION();

            /*" -2220- MOVE '4' TO R4-TIPO-REG OF REG-PGTO-SASSE */
            _.Move("4", LBFCT016.REG_PGTO_SASSE.R4_TIPO_REG);

            /*" -2223- MOVE W-NUM-PROPOSTA-NOVA TO R4-NUM-PROPOSTA OF REG-PGTO-SASSE. */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA);

            /*" -2226- MOVE PROPFIDH-SIT-COBRANCA-SIVPF TO R4-SIT-COBRANCA OF REG-PGTO-SASSE. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA);

            /*" -2229- MOVE SEGVGAPH-DATA-MOVIMENTO TO W-DATA-SQL. */
            _.Move(SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2230- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -2231- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -2233- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -2239- MOVE W-DATA-TRABALHO TO R4-DATA-SITUACAO OF REG-PGTO-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO);

            /*" -2243- MOVE ZEROS TO R4-PARCELAS-PAGAS OF REG-PGTO-SASSE R4-TOTAL-PARCELAS OF REG-PGTO-SASSE. */
            _.Move(0, LBFCT016.REG_PGTO_SASSE.R4_PARCELAS_PAGAS, LBFCT016.REG_PGTO_SASSE.R4_TOTAL_PARCELAS);

            /*" -2245- WRITE REG-STA-SASSE FROM REG-PGTO-SASSE. */
            _.Move(LBFCT016.REG_PGTO_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -2246- ADD 1 TO W-QTD-LD-TIPO-4, W-ABEND-CTR. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_4.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + 1;
            WAREA_AUXILIAR.W_ABEND_CTR.Value = WAREA_AUXILIAR.W_ABEND_CTR + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0585_SAIDA*/

        [StopWatch]
        /*" R0586-00-OBTER-DT-MOVTO-SECTION */
        private void R0586_00_OBTER_DT_MOVTO_SECTION()
        {
            /*" -2257- MOVE 'R0586-ABTER-DT-MOVTO' TO PARAGRAFO. */
            _.Move("R0586-ABTER-DT-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2259- MOVE 'SELECT SEGURADOSVGAP-HIST' TO COMANDO. */
            _.Move("SELECT SEGURADOSVGAP-HIST", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2262- MOVE SEGURVGA-NUM-APOLICE TO SEGVGAPH-NUM-APOLICE. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_APOLICE);

            /*" -2265- MOVE SEGURVGA-NUM-ITEM TO SEGVGAPH-NUM-ITEM. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_ITEM);

            /*" -2268- MOVE SEGURVGA-OCORR-HISTORICO TO SEGVGAPH-OCORR-HISTORICO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_OCORR_HISTORICO);

            /*" -2279- PERFORM R0586_00_OBTER_DT_MOVTO_DB_SELECT_1 */

            R0586_00_OBTER_DT_MOVTO_DB_SELECT_1();

            /*" -2282- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2283- DISPLAY ' ' */
                _.Display($" ");

                /*" -2284- DISPLAY 'PF0618B - ERRO ACESSO SEGURADOSVGAP-HIST' */
                _.Display($"PF0618B - ERRO ACESSO SEGURADOSVGAP-HIST");

                /*" -2286- DISPLAY '          NUMERO APOLICE................ ' SEGURVGA-NUM-APOLICE */
                _.Display($"          NUMERO APOLICE................ {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE}");

                /*" -2288- DISPLAY '          ITEM.......................... ' SEGURVGA-NUM-ITEM */
                _.Display($"          ITEM.......................... {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                /*" -2290- DISPLAY '          DATA MOVIMENTO................ ' SEGVGAPH-DATA-MOVIMENTO */
                _.Display($"          DATA MOVIMENTO................ {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO}");

                /*" -2292- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -2293- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2293- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0586-00-OBTER-DT-MOVTO-DB-SELECT-1 */
        public void R0586_00_OBTER_DT_MOVTO_DB_SELECT_1()
        {
            /*" -2279- EXEC SQL SELECT DATA_MOVIMENTO INTO :SEGVGAPH-DATA-MOVIMENTO FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :SEGVGAPH-NUM-APOLICE AND NUM_ITEM = :SEGVGAPH-NUM-ITEM AND OCORR_HISTORICO = :SEGVGAPH-OCORR-HISTORICO WITH UR END-EXEC. */

            var r0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1 = new R0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1()
            {
                SEGVGAPH_OCORR_HISTORICO = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_OCORR_HISTORICO.ToString(),
                SEGVGAPH_NUM_APOLICE = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_APOLICE.ToString(),
                SEGVGAPH_NUM_ITEM = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_ITEM.ToString(),
            };

            var executed_1 = R0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1.Execute(r0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGVGAPH_DATA_MOVIMENTO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0586_SAIDA*/

        [StopWatch]
        /*" R0587-00-OBTER-PARCELAS-PAGAS-SECTION */
        private void R0587_00_OBTER_PARCELAS_PAGAS_SECTION()
        {
            /*" -2303- MOVE 'R0587-00-OBTER-PARCELAS-PAGAS' TO PARAGRAFO. */
            _.Move("R0587-00-OBTER-PARCELAS-PAGAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2305- MOVE 'COUNT PARCELAS-VIDAZUL' TO COMANDO. */
            _.Move("COUNT PARCELAS-VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2313- PERFORM R0587_00_OBTER_PARCELAS_PAGAS_DB_SELECT_1 */

            R0587_00_OBTER_PARCELAS_PAGAS_DB_SELECT_1();

            /*" -2316- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2317- DISPLAY ' ' */
                _.Display($" ");

                /*" -2318- DISPLAY 'PF0618B - ERRO COUNT PARCELAS-VIDAZUL' */
                _.Display($"PF0618B - ERRO COUNT PARCELAS-VIDAZUL");

                /*" -2320- DISPLAY '          NUMERO CERTIFICADO.......... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO CERTIFICADO.......... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -2322- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -2323- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2323- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0587-00-OBTER-PARCELAS-PAGAS-DB-SELECT-1 */
        public void R0587_00_OBTER_PARCELAS_PAGAS_DB_SELECT_1()
        {
            /*" -2313- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WHOST-COUNT FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF AND SIT_REGISTRO = '1' WITH UR END-EXEC. */

            var r0587_00_OBTER_PARCELAS_PAGAS_DB_SELECT_1_Query1 = new R0587_00_OBTER_PARCELAS_PAGAS_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0587_00_OBTER_PARCELAS_PAGAS_DB_SELECT_1_Query1.Execute(r0587_00_OBTER_PARCELAS_PAGAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0587_SAIDA*/

        [StopWatch]
        /*" R0590-00-UPDATE-PROP-FIDELIZ-SECTION */
        private void R0590_00_UPDATE_PROP_FIDELIZ_SECTION()
        {
            /*" -2334- MOVE 'R0590-00-UPDATE-PROP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0590-00-UPDATE-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2336- MOVE 'UPDATE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2350- PERFORM R0590_00_UPDATE_PROP_FIDELIZ_DB_UPDATE_1 */

            R0590_00_UPDATE_PROP_FIDELIZ_DB_UPDATE_1();

            /*" -2353- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2354- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2355- DISPLAY 'PF0618B - FIM ANORMAL' */
                    _.Display($"PF0618B - FIM ANORMAL");

                    /*" -2356- DISPLAY '          ERRO UPDATE PROPOSTA FIDELIZ' */
                    _.Display($"          ERRO UPDATE PROPOSTA FIDELIZ");

                    /*" -2358- DISPLAY '          NUM PROPOSTA.......... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUM PROPOSTA.......... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -2360- DISPLAY '          SQLCODE............... ' SQLCODE */
                    _.Display($"          SQLCODE............... {DB.SQLCODE}");

                    /*" -2361- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2361- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0590-00-UPDATE-PROP-FIDELIZ-DB-UPDATE-1 */
        public void R0590_00_UPDATE_PROP_FIDELIZ_DB_UPDATE_1()
        {
            /*" -2350- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SITUACAO_ENVIO = 'R' , COD_USUARIO = 'PF0618B' , SIT_PROPOSTA = :PROPFIDH-SIT-PROPOSTA, NSAS_SIVPF = :PROPFIDH-NSAS-SIVPF, NSL = :PROPFIDH-NSL , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF AND SITUACAO_ENVIO <> 'S' END-EXEC. */

            var r0590_00_UPDATE_PROP_FIDELIZ_DB_UPDATE_1_Update1 = new R0590_00_UPDATE_PROP_FIDELIZ_DB_UPDATE_1_Update1()
            {
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
                PROPFIDH_NSAS_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF.ToString(),
                PROPFIDH_NSL = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0590_00_UPDATE_PROP_FIDELIZ_DB_UPDATE_1_Update1.Execute(r0590_00_UPDATE_PROP_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0590_SAIDA*/

        [StopWatch]
        /*" R0800-00-GERAR-TRAILLER-SECTION */
        private void R0800_00_GERAR_TRAILLER_SECTION()
        {
            /*" -2372- MOVE 'R0800-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R0800-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2374- MOVE 'WRITE REG-TRAILLER-STA' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER-STA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2376- MOVE SPACES TO REG-TRAILLER-STA. */
            _.Move("", LBFCT011.REG_TRAILLER_STA);

            /*" -2379- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -2382- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -2385- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1);

            /*" -2388- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2);

            /*" -2391- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3);

            /*" -2394- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4);

            /*" -2397- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_5, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5);

            /*" -2400- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_6, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6);

            /*" -2403- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_7, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7);

            /*" -2406- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8);

            /*" -2409- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_9, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9);

            /*" -2420- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -2420- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -2434- MOVE 'R0850-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R0850-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2436- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2439- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -2442- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -2446- MOVE SISTEMAS-DATA-MOV-ABERTO TO ARQSIVPF-DATA-PROCESSAMENTO ARQSIVPF-DATA-GERACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -2450- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -2458- PERFORM R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -2461- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2462- DISPLAY 'PF0618B - FIM ANORMAL' */
                _.Display($"PF0618B - FIM ANORMAL");

                /*" -2463- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -2465- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -2467- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -2469- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -2471- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -2473- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2474- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2474- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -2458- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:ARQSIVPF-SIGLA-ARQUIVO, :ARQSIVPF-SISTEMA-ORIGEM, :ARQSIVPF-NSAS-SIVPF, :ARQSIVPF-DATA-GERACAO, :ARQSIVPF-QTDE-REG-GER, :ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
        /*" R0870-00-GERAR-TOTAIS-SECTION */
        private void R0870_00_GERAR_TOTAIS_SECTION()
        {
            /*" -2485- MOVE 'R0870-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R0870-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2487- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2497- COMPUTE W-TOT-GERADO-STA = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9. */
            WAREA_AUXILIAR.W_TOT_GERADO_STA.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9;

            /*" -2498- DISPLAY ' ' */
            _.Display($" ");

            /*" -2499- DISPLAY 'PF0618B - TOTAIS DO PROCESSAMENTO' */
            _.Display($"PF0618B - TOTAIS DO PROCESSAMENTO");

            /*" -2500- DISPLAY '          TOTAL  REGISTROS LIDOS... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS... {WAREA_AUXILIAR.W_NSL}");

            /*" -2501- DISPLAY '          TOTAL  REGISTROS VIDA.... ' W-LIDO-VIDA */
            _.Display($"          TOTAL  REGISTROS VIDA.... {WAREA_AUXILIAR.W_LIDO_VIDA}");

            /*" -2502- DISPLAY ' ' */
            _.Display($" ");

            /*" -2503- DISPLAY '          TOTAL  GERADO ARQ. STATUS ' */
            _.Display($"          TOTAL  GERADO ARQ. STATUS ");

            /*" -2505- DISPLAY '          TOTAL  REGISTROS TP-1.... ' W-QTD-LD-TIPO-1 */
            _.Display($"          TOTAL  REGISTROS TP-1.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -2507- DISPLAY '          TOTAL  REGISTROS TP-2.... ' W-QTD-LD-TIPO-2 */
            _.Display($"          TOTAL  REGISTROS TP-2.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_2}");

            /*" -2509- DISPLAY '          TOTAL  REGISTROS TP-3.... ' W-QTD-LD-TIPO-3 */
            _.Display($"          TOTAL  REGISTROS TP-3.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_3}");

            /*" -2511- DISPLAY '          TOTAL  REGISTROS TP-4.... ' W-QTD-LD-TIPO-4 */
            _.Display($"          TOTAL  REGISTROS TP-4.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_4}");

            /*" -2512- DISPLAY '          TOTAL  REGISTROS GERADOS. ' W-TOT-GERADO-STA. */
            _.Display($"          TOTAL  REGISTROS GERADOS. {WAREA_AUXILIAR.W_TOT_GERADO_STA}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0870_SAIDA*/

        [StopWatch]
        /*" R0880-00-UPDATE-RELATORIOS-SECTION */
        private void R0880_00_UPDATE_RELATORIOS_SECTION()
        {
            /*" -2522- MOVE 'R0880-00-UPDATE-RELATORIOS' TO PARAGRAFO. */
            _.Move("R0880-00-UPDATE-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2524- MOVE 'UPDATE RELATORIOS' TO COMANDO. */
            _.Move("UPDATE RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2531- PERFORM R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1 */

            R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1();

            /*" -2535- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2536- DISPLAY 'PF0618B - FIM ANORMAL' */
                _.Display($"PF0618B - FIM ANORMAL");

                /*" -2537- DISPLAY '          ERRO UPDATE RELATORIOS' */
                _.Display($"          ERRO UPDATE RELATORIOS");

                /*" -2539- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -2540- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2542- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2543- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2543- DISPLAY 'DATA UPDATE RELATORIOS:' RELATORI-DATA-REFERENCIA. */
            _.Display($"DATA UPDATE RELATORIOS:{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}");

        }

        [StopWatch]
        /*" R0880-00-UPDATE-RELATORIOS-DB-UPDATE-1 */
        public void R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1()
        {
            /*" -2531- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_REFERENCIA = :RELATORI-DATA-REFERENCIA, TIMESTAMP = CURRENT TIMESTAMP WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0618B' END-EXEC. */

            var r0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 = new R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1()
            {
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
            };

            R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1.Execute(r0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0880_SAIDA*/

        [StopWatch]
        /*" R0890-00-UPDATE-RELATORIOS-SECTION */
        private void R0890_00_UPDATE_RELATORIOS_SECTION()
        {
            /*" -2553- MOVE 'R0890-00-UPDATE-RELATORIOS' TO PARAGRAFO. */
            _.Move("R0890-00-UPDATE-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2555- MOVE 'UPDATE RELATORIOS' TO COMANDO. */
            _.Move("UPDATE RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2566- PERFORM R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1 */

            R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1();

            /*" -2569- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2570- DISPLAY 'VA0412B - FIM ANORMAL' */
                _.Display($"VA0412B - FIM ANORMAL");

                /*" -2571- DISPLAY '          ERRO UPDATE RELATORIOS' */
                _.Display($"          ERRO UPDATE RELATORIOS");

                /*" -2573- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -2574- DISPLAY 'NUMERO DA APOLICE....: ' MOVIMVGA-NUM-APOLICE */
                _.Display($"NUMERO DA APOLICE....: {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE}");

                /*" -2575- DISPLAY 'CODIGO DO SUBGRUPO...: ' MOVIMVGA-COD-SUBGRUPO */
                _.Display($"CODIGO DO SUBGRUPO...: {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO}");

                /*" -2576- DISPLAY 'NR DO CERTIFICADO....: ' MOVIMVGA-NUM-CERTIFICADO */
                _.Display($"NR DO CERTIFICADO....: {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}");

                /*" -2577- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2578- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2578- END-IF. */
            }


        }

        [StopWatch]
        /*" R0890-00-UPDATE-RELATORIOS-DB-UPDATE-1 */
        public void R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1()
        {
            /*" -2566- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE IDE_SISTEMA = 'VA' AND COD_RELATORIO = 'VA0412B' AND NUM_APOLICE = :MOVIMVGA-NUM-APOLICE AND COD_SUBGRUPO = :MOVIMVGA-COD-SUBGRUPO AND NUM_CERTIFICADO = :MOVIMVGA-NUM-CERTIFICADO AND NUM_COPIAS = 2 AND SIT_REGISTRO = '0' END-EXEC. */

            var r0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 = new R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1()
            {
                MOVIMVGA_NUM_CERTIFICADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO.ToString(),
                MOVIMVGA_COD_SUBGRUPO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.ToString(),
                MOVIMVGA_NUM_APOLICE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE.ToString(),
            };

            R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1.Execute(r0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0890_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -2587- CLOSE MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9998-00-MONITOR-SECTION */
        private void R9998_00_MONITOR_SECTION()
        {
            /*" -2594- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2594- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM M_1100_MOSTRA_TOTAIS */

            M_1100_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" M-1100-MOSTRA-TOTAIS */
        private void M_1100_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -2597- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -2598- IF SII < 22 */

            if (WS_HORAS.SII < 22)
            {

                /*" -2599- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_12[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -2601- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_12[WS_HORAS.SII]}"
                .Display();

                /*" -2602- GO TO M-1100-MOSTRA-TOTAIS. */
                new Task(() => M_1100_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2602- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9998_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -2613- IF W-FIM-MOVTO-VGAP = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_VGAP == "FIM")
            {

                /*" -2618- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -2619- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2619- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -2622- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -2623- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -2624- DISPLAY '*          PF0618B  -  TERMINO  NORMAL         *' */
                _.Display($"*          PF0618B  -  TERMINO  NORMAL         *");

                /*" -2625- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -2627- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -2628- ELSE */
            }
            else
            {


                /*" -2629- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_3.WSQLCODE);

                /*" -2630- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_3.WSQLERRD1);

                /*" -2632- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_3.WSQLERRD2);

                /*" -2633- DISPLAY '*' WABEND */
                _.Display($"*{WABEND}");

                /*" -2634- DISPLAY '*********************************************' */
                _.Display($"*********************************************");

                /*" -2635- DISPLAY '*                                           *' */
                _.Display($"*                                           *");

                /*" -2636- DISPLAY '*        PF0618B - TERMINO ANORMAL          *' */
                _.Display($"*        PF0618B - TERMINO ANORMAL          *");

                /*" -2637- DISPLAY '*          ROLLBACK EM ANDAMENTO            *' */
                _.Display($"*          ROLLBACK EM ANDAMENTO            *");

                /*" -2638- DISPLAY '*                                           *' */
                _.Display($"*                                           *");

                /*" -2640- DISPLAY '*********************************************' */
                _.Display($"*********************************************");

                /*" -2641- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2641- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -2644- MOVE 99 TO RETURN-CODE. */
                _.Move(99, RETURN_CODE);
            }


            /*" -2644- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}