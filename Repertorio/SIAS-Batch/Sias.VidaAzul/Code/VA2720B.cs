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
using Sias.VidaAzul.DB2.VA2720B;

namespace Code
{
    public class VA2720B
    {
        public bool IsCall { get; set; }

        public VA2720B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SISTEMA ................ VA                                  *      */
        /*"      *   PROGRAMA ............... VA2720B                             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO: GERA ARQUIVO COM REGISTROS DE STATUS DE PROPOSTA     *      */
        /*"      *           VIDA EXCLUSIVO E APOLICE ESPECIFICA.                 *      */
        /*"      *                                                                *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      *   VERSAO 26 - DEMANDA 597719                                   *      */
        /*"      *               NOVA REGRA PARA SENSIBILIZACAO DE RENOVACAO      *      */
        /*"      *               APOLICE ESPECIFICA (MOTIVO=731) APOS INCLUSAO    *      */
        /*"      *               DE NOVO PLANO COM TIPO MOVIMENTO = 1 NAS         *      */
        /*"      *               APLICACOES:                                      *      */
        /*"      *               VGICA - INCLUSAO PLANO CAPITAL UNICO             *      */
        /*"      *               VGIDA - INCLUSAO PLANO CAPITAL DIFERENCIADO      *      */
        /*"      *               VGIEA - INCLUSAO PLANO CAPITAL MULTIPLO SALA     *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/09/2024 - BRICE HO                                     *      */
        /*"      *                                       PROCURE POR V.26         *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      *   VERSAO 25 - DEMANDA 597719                                   *      */
        /*"      *               AJUSTE CURSOR PROPOVA PARA CERTIFICADOS VIDA     *      */
        /*"      *               EXCLUSIVO - SELECIONAR SOMENTE EMISS�O OU        *      */
        /*"      *               CANCELAMENTO.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/08/2024 - BRICE HO                                     *      */
        /*"      *                                       PROCURE POR V.25         *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"V.24  *    ALTERACAO PARA LIMPAR UMA VARIAVEL QUE ESTA CANCELANDO      *      */
        /*"      *    PROPOSTAS VIDA EXCLUSIVO INDEVIDAMENTE NO SIGPF             *      */
        /*"      *                                                                *      */
        /*"      *    EM 29/02/2024 THIAGO BLAIER        PROCURE POR V.24         *      */
        /*"      *                                                                *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"V.23  *    23 - ABEND  530554                                          *      */
        /*"      *                                                                *      */
        /*"      *    EM 14/09/2023 RAUL ROTTA           PROCURE POR V.23         *      */
        /*"      *                                                                *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"V.22  *    22 - ABEND  515878                                          *      */
        /*"      *                                                                *      */
        /*"      *    EM SET/2023 - CANETTA              PROCURE POR V.22         *      */
        /*"      *                                                                *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      *    21 - ABEND  515878                                          *      */
        /*"      *               ACERTO PARA ENVIO DE STATUS VIDA EXCLUSIVO,      *      */
        /*"      *               ROTINA CANCELADA                                 *      */
        /*"      *   EM JULHO/2023 - THIAGO BLAIER                                *      */
        /*"      *                                       PROCURE POR V.21         *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      *    20 - DEMANDA  499072                                        *      */
        /*"      *               ACERTO PARA ENVIO DE STATUS VIDA EXCLUSIVO       *      */
        /*"      *   EM JUN/2023 - THIAGO BLAIER                                  *      */
        /*"      *                                       PROCURE POR V.20         *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      *    19 - DEMANDA  477323                                        *      */
        /*"      *               14/03/2023 - 02:43 - JPVAD12 - E0032720-VA2720B  *      */
        /*"      *              -SQLCODE 811                                      *      */
        /*"      *               APOLICE ESPECIFICA COM CODIGO 731(RENOVACAO)     *      */
        /*"      *   EM MAR/2023 - THIAGO BLAIER                                  *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      *    18 - DEMANDA  459468                                  *            */
        /*"      *               NOVA REGRA, AJUSTE PARA ENVIO DE PROPOSTAS       *      */
        /*"      *               APOLICE ESPECIFICA COM CODIGO 731(RENOVACAO)     *      */
        /*"      *   EM FEV/2023 - THIAGO BLAIER                                  *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    17 - DEMANDA  425398                                  *            */
        /*"      *               AJUSTES PARA ENVIAR PROPOSTAS APOLICE ESPECIFICA *      */
        /*"      *               CAAAAPPNNNNNND                                   *      */
        /*"      *               C      = Canal (pode Ser: 1, 2, 3, 6, 7, 8 e 9)  *      */
        /*"      *               AAAA   = Agencia de venda da proposta            *      */
        /*"      *               PP     = C�digo Produto                          *      */
        /*"      *               NNNNNN = N�mero Sequencial da venda do produto   *      */
        /*"      *               D      = Digito Verificador calculo pelo Mod. 10 *      */
        /*"      *   EM SET/2022 - THIAGO BLAIER                                  *      */
        /*"      *                                       PROCURE POR V.17         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    16 - DEMANDA 353118                                   *            */
        /*"      *               AJUSTES DUPLICIDADE NO SIGPF VIDA, JAH QUE ESTA  *      */
        /*"      *               ENVIANDO CODIGO 228 PARA PAGAMENTO IDENTIFICADO  *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/01/2022 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.16         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   DEMAIS HISTORICOS DE MANUTENCAO - VIDE FINAL DO PROGRAMA     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _AVA2720B { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis AVA2720B
        {
            get
            {
                _.Move(REG_AVA2720B, _AVA2720B); VarBasis.RedefinePassValue(REG_AVA2720B, _AVA2720B, REG_AVA2720B); return _AVA2720B;
            }
        }
        /*"01            REG-AVA2720B        PIC X(100).*/
        public StringBasis REG_AVA2720B { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    SISTEMAS-DATA-MOV-ABERTO-1  PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    SISTEMAS-DATA-MOV-ABERTO-30 PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WHOST-OPERACAO            PIC  X(030).*/
        public StringBasis WHOST_OPERACAO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77    WHOST-VLPREMIO            PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WHOST-COUNT               PIC S9(004)   COMP  VALUE +0.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-OCORR-HISTORICO-ANT PIC S9(004)   COMP  VALUE +0.*/
        public IntBasis WHOST_OCORR_HISTORICO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-IMP-SEGURADA         PIC S9(004)   COMP  VALUE +0.*/
        public IntBasis VIND_IMP_SEGURADA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-AGENCIA              PIC S9(004)   COMP  VALUE +0.*/
        public IntBasis VIND_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-OPERACAO             PIC S9(004)   COMP  VALUE +0.*/
        public IntBasis VIND_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CONTA                PIC S9(004)   COMP  VALUE +0.*/
        public IntBasis VIND_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DIG-CONTA            PIC S9(004)   COMP  VALUE +0.*/
        public IntBasis VIND_DIG_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CARTAO               PIC S9(004)   COMP  VALUE +0.*/
        public IntBasis VIND_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-MATRIC               PIC S9(004)   COMP  VALUE +0.*/
        public IntBasis VIND_MATRIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DATA-MOVIMENTO       PIC S9(04)    COMP  VALUE +0.*/
        public IntBasis VIND_DATA_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77    VIND-NRCERTIFANT          PIC S9(04)    COMP  VALUE +0.*/
        public IntBasis VIND_NRCERTIFANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77    VIND-DATA-OPERACAO        PIC S9(04)    COMP  VALUE +0.*/
        public IntBasis VIND_DATA_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77    VIND-DATA-QUITACAO        PIC S9(04)    COMP  VALUE +0.*/
        public IntBasis VIND_DATA_QUITACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77    WHOST-SITUACAO            PIC  X(01).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77    WS-QTD-REG1-PRP           PIC  9(06)   VALUE ZEROS.*/
        public IntBasis WS_QTD_REG1_PRP { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"77    WS-QTD-REG2-PRP           PIC  9(06)   VALUE ZEROS.*/
        public IntBasis WS_QTD_REG2_PRP { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"77    WS-QTD-REG3-PRP           PIC  9(06)   VALUE ZEROS.*/
        public IntBasis WS_QTD_REG3_PRP { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"77    WS-PERIODO-DE             PIC  X(10)   VALUE SPACES.*/
        public StringBasis WS_PERIODO_DE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01     VA2720B1O-REG.*/
        public VA2720B_VA2720B1O_REG VA2720B1O_REG { get; set; } = new VA2720B_VA2720B1O_REG();
        public class VA2720B_VA2720B1O_REG : VarBasis
        {
            /*"    05   VA2720B1O-IDENTIFICA         PIC  X(0001).*/
            public StringBasis VA2720B1O_IDENTIFICA { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
            /*"    05   VA2720B1O-REG-H.*/
            public VA2720B_VA2720B1O_REG_H VA2720B1O_REG_H { get; set; } = new VA2720B_VA2720B1O_REG_H();
            public class VA2720B_VA2720B1O_REG_H : VarBasis
            {
                /*"      10 VA2720B1O-NOME-ARQ           PIC  X(0008).*/
                public StringBasis VA2720B1O_NOME_ARQ { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2720B1O-DATA-GER           PIC  X(0008).*/
                public StringBasis VA2720B1O_DATA_GER { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2720B1O-COD-SIST           PIC  9(0001).*/
                public IntBasis VA2720B1O_COD_SIST { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2720B1O-COD-SIST-DEST      PIC  9(0001).*/
                public IntBasis VA2720B1O_COD_SIST_DEST { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2720B1O-SEQ-ARQ            PIC  9(0006).*/
                public IntBasis VA2720B1O_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(0006)."));
                /*"      10 VA2720B1O-ESPACOS            PIC  X(0075).*/
                public StringBasis VA2720B1O_ESPACOS { get; set; } = new StringBasis(new PIC("X", "75", "X(0075)."), @"");
                /*"    05   VA2720B1O-REG-0   REDEFINES VA2720B1O-REG-H.*/
            }
            private _REDEF_VA2720B_VA2720B1O_REG_0 _va2720b1o_reg_0 { get; set; }
            public _REDEF_VA2720B_VA2720B1O_REG_0 VA2720B1O_REG_0
            {
                get { _va2720b1o_reg_0 = new _REDEF_VA2720B_VA2720B1O_REG_0(); _.Move(VA2720B1O_REG_H, _va2720b1o_reg_0); VarBasis.RedefinePassValue(VA2720B1O_REG_H, _va2720b1o_reg_0, VA2720B1O_REG_H); _va2720b1o_reg_0.ValueChanged += () => { _.Move(_va2720b1o_reg_0, VA2720B1O_REG_H); }; return _va2720b1o_reg_0; }
                set { VarBasis.RedefinePassValue(value, _va2720b1o_reg_0, VA2720B1O_REG_H); }
            }  //Redefines
            public class _REDEF_VA2720B_VA2720B1O_REG_0 : VarBasis
            {
                /*"      10 VA2720B1O-NUM-PROPOSTA-0     PIC  9(0014).*/
                public IntBasis VA2720B1O_NUM_PROPOSTA_0 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2720B1O-VALOR-ENDOSSO      PIC  9(0015)V99.*/
                public DoubleBasis VA2720B1O_VALOR_ENDOSSO { get; set; } = new DoubleBasis(new PIC("9", "15", "9(0015)V99."), 2);
                /*"      10 VA2720B1O-SINAL              PIC  X(0001).*/
                public StringBasis VA2720B1O_SINAL { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
                /*"      10 VA2720B1O-DATA-EMISSAO       PIC  9(0008).*/
                public IntBasis VA2720B1O_DATA_EMISSAO { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 FILLER                       PIC  X(0059).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "59", "X(0059)."), @"");
                /*"    05   VA2720B1O-REG-1   REDEFINES VA2720B1O-REG-0.*/

                public _REDEF_VA2720B_VA2720B1O_REG_0()
                {
                    VA2720B1O_NUM_PROPOSTA_0.ValueChanged += OnValueChanged;
                    VA2720B1O_VALOR_ENDOSSO.ValueChanged += OnValueChanged;
                    VA2720B1O_SINAL.ValueChanged += OnValueChanged;
                    VA2720B1O_DATA_EMISSAO.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2720B_VA2720B1O_REG_1 _va2720b1o_reg_1 { get; set; }
            public _REDEF_VA2720B_VA2720B1O_REG_1 VA2720B1O_REG_1
            {
                get { _va2720b1o_reg_1 = new _REDEF_VA2720B_VA2720B1O_REG_1(); _.Move(VA2720B1O_REG_0, _va2720b1o_reg_1); VarBasis.RedefinePassValue(VA2720B1O_REG_0, _va2720b1o_reg_1, VA2720B1O_REG_0); _va2720b1o_reg_1.ValueChanged += () => { _.Move(_va2720b1o_reg_1, VA2720B1O_REG_0); }; return _va2720b1o_reg_1; }
                set { VarBasis.RedefinePassValue(value, _va2720b1o_reg_1, VA2720B1O_REG_0); }
            }  //Redefines
            public class _REDEF_VA2720B_VA2720B1O_REG_1 : VarBasis
            {
                /*"      10 VA2720B1O-NUM-PROPOSTA-1     PIC  9(0014).*/
                public IntBasis VA2720B1O_NUM_PROPOSTA_1 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2720B1O-SIT-PROPOSTA       PIC  X(0003).*/
                public StringBasis VA2720B1O_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"      10 VA2720B1O-BRANCOS-0          PIC  X(0003).*/
                public StringBasis VA2720B1O_BRANCOS_0 { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"      10 VA2720B1O-TIPO-MOTIVO        PIC  9(0003).*/
                public IntBasis VA2720B1O_TIPO_MOTIVO { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 VA2720B1O-DATA-INICIO-SIT    PIC  9(0008).*/
                public IntBasis VA2720B1O_DATA_INICIO_SIT { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2720B1O-BRANCOS-1          PIC  X(0046).*/
                public StringBasis VA2720B1O_BRANCOS_1 { get; set; } = new StringBasis(new PIC("X", "46", "X(0046)."), @"");
                /*"      10 VA2720B1O-NUM-SEQ-ARQ        PIC  9(0006).*/
                public IntBasis VA2720B1O_NUM_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(0006)."));
                /*"      10 VA2720B1O-NUM-SEQ-REG        PIC  9(0006).*/
                public IntBasis VA2720B1O_NUM_SEQ_REG { get; set; } = new IntBasis(new PIC("9", "6", "9(0006)."));
                /*"      10 FILLER                       PIC  X(0010).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(0010)."), @"");
                /*"    05   VA2720B1O-REG-2   REDEFINES VA2720B1O-REG-1.*/

                public _REDEF_VA2720B_VA2720B1O_REG_1()
                {
                    VA2720B1O_NUM_PROPOSTA_1.ValueChanged += OnValueChanged;
                    VA2720B1O_SIT_PROPOSTA.ValueChanged += OnValueChanged;
                    VA2720B1O_BRANCOS_0.ValueChanged += OnValueChanged;
                    VA2720B1O_TIPO_MOTIVO.ValueChanged += OnValueChanged;
                    VA2720B1O_DATA_INICIO_SIT.ValueChanged += OnValueChanged;
                    VA2720B1O_BRANCOS_1.ValueChanged += OnValueChanged;
                    VA2720B1O_NUM_SEQ_ARQ.ValueChanged += OnValueChanged;
                    VA2720B1O_NUM_SEQ_REG.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2720B_VA2720B1O_REG_2 _va2720b1o_reg_2 { get; set; }
            public _REDEF_VA2720B_VA2720B1O_REG_2 VA2720B1O_REG_2
            {
                get { _va2720b1o_reg_2 = new _REDEF_VA2720B_VA2720B1O_REG_2(); _.Move(VA2720B1O_REG_1, _va2720b1o_reg_2); VarBasis.RedefinePassValue(VA2720B1O_REG_1, _va2720b1o_reg_2, VA2720B1O_REG_1); _va2720b1o_reg_2.ValueChanged += () => { _.Move(_va2720b1o_reg_2, VA2720B1O_REG_1); }; return _va2720b1o_reg_2; }
                set { VarBasis.RedefinePassValue(value, _va2720b1o_reg_2, VA2720B1O_REG_1); }
            }  //Redefines
            public class _REDEF_VA2720B_VA2720B1O_REG_2 : VarBasis
            {
                /*"      10 VA2720B1O-NUM-PROPOSTA-2     PIC  9(0014).*/
                public IntBasis VA2720B1O_NUM_PROPOSTA_2 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2720B1O-NUM-CERTIFICADO    PIC  9(0015).*/
                public IntBasis VA2720B1O_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(0015)."));
                /*"      10 VA2720B1O-DATA-INICIO-VIG    PIC  9(0008).*/
                public IntBasis VA2720B1O_DATA_INICIO_VIG { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2720B1O-DATA-FINAL-VIG     PIC  9(0008).*/
                public IntBasis VA2720B1O_DATA_FINAL_VIG { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2720B1O-VALOR-PREMIO       PIC  9(0013)V99.*/
                public DoubleBasis VA2720B1O_VALOR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(0013)V99."), 2);
                /*"      10 VA2720B1O-VALOR-IOF          PIC  9(0013)V99.*/
                public DoubleBasis VA2720B1O_VALOR_IOF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(0013)V99."), 2);
                /*"      10 FILLER                       PIC  X(0024).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "24", "X(0024)."), @"");
                /*"    05   VA2720B1O-REG-3   REDEFINES VA2720B1O-REG-2.*/

                public _REDEF_VA2720B_VA2720B1O_REG_2()
                {
                    VA2720B1O_NUM_PROPOSTA_2.ValueChanged += OnValueChanged;
                    VA2720B1O_NUM_CERTIFICADO.ValueChanged += OnValueChanged;
                    VA2720B1O_DATA_INICIO_VIG.ValueChanged += OnValueChanged;
                    VA2720B1O_DATA_FINAL_VIG.ValueChanged += OnValueChanged;
                    VA2720B1O_VALOR_PREMIO.ValueChanged += OnValueChanged;
                    VA2720B1O_VALOR_IOF.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2720B_VA2720B1O_REG_3 _va2720b1o_reg_3 { get; set; }
            public _REDEF_VA2720B_VA2720B1O_REG_3 VA2720B1O_REG_3
            {
                get { _va2720b1o_reg_3 = new _REDEF_VA2720B_VA2720B1O_REG_3(); _.Move(VA2720B1O_REG_2, _va2720b1o_reg_3); VarBasis.RedefinePassValue(VA2720B1O_REG_2, _va2720b1o_reg_3, VA2720B1O_REG_2); _va2720b1o_reg_3.ValueChanged += () => { _.Move(_va2720b1o_reg_3, VA2720B1O_REG_2); }; return _va2720b1o_reg_3; }
                set { VarBasis.RedefinePassValue(value, _va2720b1o_reg_3, VA2720B1O_REG_2); }
            }  //Redefines
            public class _REDEF_VA2720B_VA2720B1O_REG_3 : VarBasis
            {
                /*"      10 VA2720B1O-NUM-PROPOSTA-3     PIC  9(0014).*/
                public IntBasis VA2720B1O_NUM_PROPOSTA_3 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2720B1O-COD-COBERTURA      PIC  9(0004).*/
                public IntBasis VA2720B1O_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(0004)."));
                /*"      10 VA2720B1O-VALOR-COBERTURA    PIC  9(0013)V99.*/
                public DoubleBasis VA2720B1O_VALOR_COBERTURA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(0013)V99."), 2);
                /*"      10 FILLER                       PIC  X(0066).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "66", "X(0066)."), @"");
                /*"    05   VA2720B1O-REG-4   REDEFINES VA2720B1O-REG-3.*/

                public _REDEF_VA2720B_VA2720B1O_REG_3()
                {
                    VA2720B1O_NUM_PROPOSTA_3.ValueChanged += OnValueChanged;
                    VA2720B1O_COD_COBERTURA.ValueChanged += OnValueChanged;
                    VA2720B1O_VALOR_COBERTURA.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2720B_VA2720B1O_REG_4 _va2720b1o_reg_4 { get; set; }
            public _REDEF_VA2720B_VA2720B1O_REG_4 VA2720B1O_REG_4
            {
                get { _va2720b1o_reg_4 = new _REDEF_VA2720B_VA2720B1O_REG_4(); _.Move(VA2720B1O_REG_3, _va2720b1o_reg_4); VarBasis.RedefinePassValue(VA2720B1O_REG_3, _va2720b1o_reg_4, VA2720B1O_REG_3); _va2720b1o_reg_4.ValueChanged += () => { _.Move(_va2720b1o_reg_4, VA2720B1O_REG_3); }; return _va2720b1o_reg_4; }
                set { VarBasis.RedefinePassValue(value, _va2720b1o_reg_4, VA2720B1O_REG_3); }
            }  //Redefines
            public class _REDEF_VA2720B_VA2720B1O_REG_4 : VarBasis
            {
                /*"      10 VA2720B1O-NUM-PROPOSTA-4     PIC  9(0014).*/
                public IntBasis VA2720B1O_NUM_PROPOSTA_4 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2720B1O-SIT-COBRANCA       PIC  X(0003).*/
                public StringBasis VA2720B1O_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"      10 VA2720B1O-DT-INI-SITUACAO    PIC  X(0008).*/
                public StringBasis VA2720B1O_DT_INI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2720B1O-PARCELAS-PAGAS     PIC  9(0003).*/
                public IntBasis VA2720B1O_PARCELAS_PAGAS { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 VA2720B1O-TOTAL-PARCELAS     PIC  9(0003).*/
                public IntBasis VA2720B1O_TOTAL_PARCELAS { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 FILLER                       PIC  X(0068).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "68", "X(0068)."), @"");
                /*"    05   VA2720B1O-REG-T   REDEFINES VA2720B1O-REG-4.*/

                public _REDEF_VA2720B_VA2720B1O_REG_4()
                {
                    VA2720B1O_NUM_PROPOSTA_4.ValueChanged += OnValueChanged;
                    VA2720B1O_SIT_COBRANCA.ValueChanged += OnValueChanged;
                    VA2720B1O_DT_INI_SITUACAO.ValueChanged += OnValueChanged;
                    VA2720B1O_PARCELAS_PAGAS.ValueChanged += OnValueChanged;
                    VA2720B1O_TOTAL_PARCELAS.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2720B_VA2720B1O_REG_T _va2720b1o_reg_t { get; set; }
            public _REDEF_VA2720B_VA2720B1O_REG_T VA2720B1O_REG_T
            {
                get { _va2720b1o_reg_t = new _REDEF_VA2720B_VA2720B1O_REG_T(); _.Move(VA2720B1O_REG_4, _va2720b1o_reg_t); VarBasis.RedefinePassValue(VA2720B1O_REG_4, _va2720b1o_reg_t, VA2720B1O_REG_4); _va2720b1o_reg_t.ValueChanged += () => { _.Move(_va2720b1o_reg_t, VA2720B1O_REG_4); }; return _va2720b1o_reg_t; }
                set { VarBasis.RedefinePassValue(value, _va2720b1o_reg_t, VA2720B1O_REG_4); }
            }  //Redefines
            public class _REDEF_VA2720B_VA2720B1O_REG_T : VarBasis
            {
                /*"      10 VA2720B1O-NOME-ARQ-T         PIC  X(0008).*/
                public StringBasis VA2720B1O_NOME_ARQ_T { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2720B1O-QTDE-REG-1         PIC  9(0008).*/
                public IntBasis VA2720B1O_QTDE_REG_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2720B1O-QTDE-REG-2         PIC  9(0008).*/
                public IntBasis VA2720B1O_QTDE_REG_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2720B1O-QTDE-REG-3         PIC  9(0008).*/
                public IntBasis VA2720B1O_QTDE_REG_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2720B1O-QTDE-REG-4         PIC  9(0008).*/
                public IntBasis VA2720B1O_QTDE_REG_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2720B1O-QTDE-REG-5         PIC  9(0008).*/
                public IntBasis VA2720B1O_QTDE_REG_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2720B1O-QTDE-REG-6         PIC  9(0008).*/
                public IntBasis VA2720B1O_QTDE_REG_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2720B1O-QTDE-REG-7         PIC  9(0008).*/
                public IntBasis VA2720B1O_QTDE_REG_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2720B1O-QTDE-REG-8         PIC  9(0008).*/
                public IntBasis VA2720B1O_QTDE_REG_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2720B1O-QTDE-REG-9         PIC  9(0008).*/
                public IntBasis VA2720B1O_QTDE_REG_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 FILLER                       PIC  X(0008).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2720B1O-QTDE-REG-TOTAL     PIC  9(0008).*/
                public IntBasis VA2720B1O_QTDE_REG_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 FILLER                       PIC  X(0003).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"01  WORK-AREA.*/

                public _REDEF_VA2720B_VA2720B1O_REG_T()
                {
                    VA2720B1O_NOME_ARQ_T.ValueChanged += OnValueChanged;
                    VA2720B1O_QTDE_REG_1.ValueChanged += OnValueChanged;
                    VA2720B1O_QTDE_REG_2.ValueChanged += OnValueChanged;
                    VA2720B1O_QTDE_REG_3.ValueChanged += OnValueChanged;
                    VA2720B1O_QTDE_REG_4.ValueChanged += OnValueChanged;
                    VA2720B1O_QTDE_REG_5.ValueChanged += OnValueChanged;
                    VA2720B1O_QTDE_REG_6.ValueChanged += OnValueChanged;
                    VA2720B1O_QTDE_REG_7.ValueChanged += OnValueChanged;
                    VA2720B1O_QTDE_REG_8.ValueChanged += OnValueChanged;
                    VA2720B1O_QTDE_REG_9.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    VA2720B1O_QTDE_REG_TOTAL.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA2720B_WORK_AREA WORK_AREA { get; set; } = new VA2720B_WORK_AREA();
        public class VA2720B_WORK_AREA : VarBasis
        {
            /*"    05  W-NSAS                        PIC 9(006)  VALUE ZEROS.*/
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-NSL                         PIC 9(006)  VALUE ZEROS.*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  WS-RESULT                 PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis WS_RESULT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  WS-RESTO                  PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  WS-NUM-PROPOSTA           PIC 9(014).*/
            public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  WS-NUM-PROPOSTA-R         REDEFINES        WS-NUM-PROPOSTA.*/
            private _REDEF_VA2720B_WS_NUM_PROPOSTA_R _ws_num_proposta_r { get; set; }
            public _REDEF_VA2720B_WS_NUM_PROPOSTA_R WS_NUM_PROPOSTA_R
            {
                get { _ws_num_proposta_r = new _REDEF_VA2720B_WS_NUM_PROPOSTA_R(); _.Move(WS_NUM_PROPOSTA, _ws_num_proposta_r); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA, _ws_num_proposta_r, WS_NUM_PROPOSTA); _ws_num_proposta_r.ValueChanged += () => { _.Move(_ws_num_proposta_r, WS_NUM_PROPOSTA); }; return _ws_num_proposta_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_r, WS_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA2720B_WS_NUM_PROPOSTA_R : VarBasis
            {
                /*"        10  WS-NUM-PROPOSTA-9     PIC 9(013).*/
                public IntBasis WS_NUM_PROPOSTA_9 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        10  WS-NUM-PROPOSTA-0     PIC 9(001).*/
                public IntBasis WS_NUM_PROPOSTA_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  WS-NUM-PROPOSTA-1         PIC 9(014).*/

                public _REDEF_VA2720B_WS_NUM_PROPOSTA_R()
                {
                    WS_NUM_PROPOSTA_9.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_0.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUM_PROPOSTA_1 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  WS-NUM-PROPOSTA-R         REDEFINES        WS-NUM-PROPOSTA-1.*/
            private _REDEF_VA2720B_WS_NUM_PROPOSTA_R_0 _ws_num_proposta_r_0 { get; set; }
            public _REDEF_VA2720B_WS_NUM_PROPOSTA_R_0 WS_NUM_PROPOSTA_R_0
            {
                get { _ws_num_proposta_r_0 = new _REDEF_VA2720B_WS_NUM_PROPOSTA_R_0(); _.Move(WS_NUM_PROPOSTA_1, _ws_num_proposta_r_0); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA_1, _ws_num_proposta_r_0, WS_NUM_PROPOSTA_1); _ws_num_proposta_r_0.ValueChanged += () => { _.Move(_ws_num_proposta_r_0, WS_NUM_PROPOSTA_1); }; return _ws_num_proposta_r_0; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_r_0, WS_NUM_PROPOSTA_1); }
            }  //Redefines
            public class _REDEF_VA2720B_WS_NUM_PROPOSTA_R_0 : VarBasis
            {
                /*"        10  WS-NUM-PROPOSTA-11    PIC 9(011).*/
                public IntBasis WS_NUM_PROPOSTA_11 { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"        10  WS-NUM-PROPOSTA-01    PIC 9(001).*/
                public IntBasis WS_NUM_PROPOSTA_01 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10  FILLER                PIC X(002).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05  TAB-OPC-PGTO.*/

                public _REDEF_VA2720B_WS_NUM_PROPOSTA_R_0()
                {
                    WS_NUM_PROPOSTA_11.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_01.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }
            public VA2720B_TAB_OPC_PGTO TAB_OPC_PGTO { get; set; } = new VA2720B_TAB_OPC_PGTO();
            public class VA2720B_TAB_OPC_PGTO : VarBasis
            {
                /*"        10  FILLER                PIC X(011) VALUE '1-DEB CONTA'*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"1-DEB CONTA");
                /*"        10  FILLER                PIC X(011) VALUE '2-POUPANCA '*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"2-POUPANCA ");
                /*"        10  FILLER                PIC X(011) VALUE '3-BOLETO   '*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"3-BOLETO   ");
                /*"        10  FILLER                PIC X(011) VALUE '4-AVERBACAO'*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"4-AVERBACAO");
                /*"        10  FILLER                PIC X(011) VALUE '5-CARTAO   '*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"5-CARTAO   ");
                /*"    05  TAB-OPC-PGTO-RED  REDEFINES  TAB-OPC-PGTO.*/
            }
            private _REDEF_VA2720B_TAB_OPC_PGTO_RED _tab_opc_pgto_red { get; set; }
            public _REDEF_VA2720B_TAB_OPC_PGTO_RED TAB_OPC_PGTO_RED
            {
                get { _tab_opc_pgto_red = new _REDEF_VA2720B_TAB_OPC_PGTO_RED(); _.Move(TAB_OPC_PGTO, _tab_opc_pgto_red); VarBasis.RedefinePassValue(TAB_OPC_PGTO, _tab_opc_pgto_red, TAB_OPC_PGTO); _tab_opc_pgto_red.ValueChanged += () => { _.Move(_tab_opc_pgto_red, TAB_OPC_PGTO); }; return _tab_opc_pgto_red; }
                set { VarBasis.RedefinePassValue(value, _tab_opc_pgto_red, TAB_OPC_PGTO); }
            }  //Redefines
            public class _REDEF_VA2720B_TAB_OPC_PGTO_RED : VarBasis
            {
                /*"      10  TB-OPC-PAGTO            PIC X(011)  OCCURS 5 TIMES.*/
                public ListBasis<StringBasis, string> TB_OPC_PAGTO { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "11", "X(011)"), 5);
                /*"    05        DATA-SQL.*/

                public _REDEF_VA2720B_TAB_OPC_PGTO_RED()
                {
                    TB_OPC_PAGTO.ValueChanged += OnValueChanged;
                }

            }
            public VA2720B_DATA_SQL DATA_SQL { get; set; } = new VA2720B_DATA_SQL();
            public class VA2720B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        DATA-SQL-HIST.*/
            }
            public VA2720B_DATA_SQL_HIST DATA_SQL_HIST { get; set; } = new VA2720B_DATA_SQL_HIST();
            public class VA2720B_DATA_SQL_HIST : VarBasis
            {
                /*"      10      ANO-SQL-HIST        PIC  9(004).*/
                public IntBasis ANO_SQL_HIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL-HIST        PIC  9(002).*/
                public IntBasis MES_SQL_HIST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL-HIST        PIC  9(002).*/
                public IntBasis DIA_SQL_HIST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        DATA-CONV.*/
            }
            public VA2720B_DATA_CONV DATA_CONV { get; set; } = new VA2720B_DATA_CONV();
            public class VA2720B_DATA_CONV : VarBasis
            {
                /*"      10      DIA-CONV            PIC  9(002).*/
                public IntBasis DIA_CONV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-CONV            PIC  9(002).*/
                public IntBasis MES_CONV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      ANO-CONV            PIC  9(004).*/
                public IntBasis ANO_CONV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        IND                 PIC  9(005) VALUE ZEROS.*/
            }
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        WS-ESCNEG           PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_ESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-FONTE-ANT        PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_FONTE_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-COD-ESCNEG-ANT   PIC  9(004) VALUE 9999.*/
            public IntBasis WS_COD_ESCNEG_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"), 9999);
            /*"    05        WS-APOLICE-ANT      PIC  9(013) VALUE ZEROS.*/
            public IntBasis WS_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05        WS-CODSUBES-ANT     PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-ESCNEG-ANT       PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_ESCNEG_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"01  PARAMETROS.*/
        }
        public VA2720B_PARAMETROS PARAMETROS { get; set; } = new VA2720B_PARAMETROS();
        public class VA2720B_PARAMETROS : VarBasis
        {
            /*"    05 LK-APOLICE                    PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05 LK-SUBGRUPO                   PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-IDADE                      PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-NASCIMENTO.*/
            public VA2720B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VA2720B_LK_NASCIMENTO();
            public class VA2720B_LK_NASCIMENTO : VarBasis
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
            /*"    05        WFIM-PROPOVA     PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_PROPOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-V0ERROSPROP    PIC   X(03)  VALUE  ' '.*/
            public StringBasis WFIM_V0ERROSPROP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"    05        WFIM-V1SISTEMA      PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-SORT           PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-SORT1          PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_SORT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-FONTES         PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_FONTES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-ESCNEG         PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_ESCNEG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        TEM-CAN-EXCLUSIVO   PIC   X(01)  VALUE  ' '.*/
            public StringBasis TEM_CAN_EXCLUSIVO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        TEM-RENOVACAO       PIC   X(01)  VALUE  ' '.*/
            public StringBasis TEM_RENOVACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-GRAVADOS         PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-0           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_0 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-1           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-2           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-3           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_3 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-4           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_4 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-5           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_5 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-6           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_6 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-7           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_7 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-8           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_8 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-9           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_9 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-11           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_11 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-10          PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_10 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        W-QTD-LD-TIPO-1     PIC  9(006) VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        W-QTD-LD-TIPO-2     PIC  9(006) VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        W-QTD-LD-TIPO-3     PIC  9(006) VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        W-QTD-LD-TIPO-4     PIC  9(006) VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        W-QTD-LD-TIPO-5     PIC  9(006) VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        W-QTD-LD-TIPO-6     PIC  9(006) VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        W-QTD-LD-TIPO-7     PIC  9(006) VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        W-QTD-LD-TIPO-8     PIC  9(006) VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        W-QTD-LD-TIPO-9     PIC  9(006) VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WABEND.*/
            public VA2720B_WABEND WABEND { get; set; } = new VA2720B_WABEND();
            public class VA2720B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             ' VA2720B'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA2720B");
                /*"      10      FILLER              PIC  X(026) VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(006) VALUE '000000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"000000");
                /*"      10      FILLER              PIC  X(013) VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"      10      FILLER              PIC  X(014) VALUE             ' *** SQLERRMC '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"      10      WSQLERRMC           PIC  X(070)    VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01            WZEROS              PIC S9(005) VALUE +0 COMP-3.*/
            }
        }
        public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));


        public Copies.LBFPF025 LBFPF025 { get; set; } = new Copies.LBFPF025();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.PLANOAGE PLANOAGE { get; set; } = new Dclgens.PLANOAGE();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.MOVVGAP MOVVGAP { get; set; } = new Dclgens.MOVVGAP();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA2720B_TPROPOVA TPROPOVA { get; set; } = new VA2720B_TPROPOVA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string AVA2720B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                AVA2720B.SetFile(AVA2720B_FILE_NAME_P);

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
            /*" -484- MOVE 'R0000' TO WNR-EXEC-SQL. */
            _.Move("R0000", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -485- DISPLAY ' ' */
            _.Display($" ");

            /*" -487- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -495- DISPLAY 'PROGRAMA EM EXECUCAO VA2720B-' 'VERSAO V.26 - DEMANDA 597719 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VA2720B-VERSAO V.26 - DEMANDA 597719 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -497- DISPLAY 'GERAR ARQ. DE STATUS DE PROPOSTAS PRODUTOS VIDA' ' EXCLUSIVO E APOLICE ESPECIFICA PARA O SIGPF' */
            _.Display($"GERAR ARQ. DE STATUS DE PROPOSTAS PRODUTOS VIDA EXCLUSIVO E APOLICE ESPECIFICA PARA O SIGPF");

            /*" -499- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -501- DISPLAY ' ' */
            _.Display($" ");

            /*" -502- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -505- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -508- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -512- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -514- OPEN OUTPUT AVA2720B. */
            AVA2720B.Open(REG_AVA2720B);

            /*" -516- PERFORM R0020-00-OBTER-MAX-NSAS */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -518- PERFORM R0200-00-GRAVA-HEADER. */

            R0200_00_GRAVA_HEADER_SECTION();

            /*" -519- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!PARAMETROS.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -520- DISPLAY '*** PROBLEMAS NA SISTEMAS' */
                _.Display($"*** PROBLEMAS NA SISTEMAS");

                /*" -521- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -522- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -532- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -534- PERFORM R0900-00-DECLARE-PROPOVA. */

            R0900_00_DECLARE_PROPOVA_SECTION();

            /*" -536- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

            /*" -537- PERFORM R1000-00-PROCESSA UNTIL WFIM-PROPOVA EQUAL 'S' . */

            while (!(PARAMETROS.WFIM_PROPOVA == "S"))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -543- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -545- PERFORM R8000-00-UPDATE-RELATORI */

            R8000_00_UPDATE_RELATORI_SECTION();

            /*" -547- PERFORM R8100-00-GRAVA-TRAILLER */

            R8100_00_GRAVA_TRAILLER_SECTION();

            /*" -549- PERFORM R9989-00-CONTROLAR-ARQ-ENVIADO */

            R9989_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -549- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -555- DISPLAY '========================================' */
            _.Display($"========================================");

            /*" -556- DISPLAY '--------------- VA2720B --------------- ' */
            _.Display($"--------------- VA2720B --------------- ");

            /*" -557- DISPLAY '========================================' */
            _.Display($"========================================");

            /*" -558- DISPLAY 'LIDOS PROPOSTAS_VA         ' AC-LIDOS */
            _.Display($"LIDOS PROPOSTAS_VA         {PARAMETROS.AC_LIDOS}");

            /*" -559- DISPLAY '--------------------------------------- ' */
            _.Display($"--------------------------------------- ");

            /*" -560- DISPLAY 'DESPREZADOS PROPFIDH        ' AC-DESP-0 */
            _.Display($"DESPREZADOS PROPFIDH        {PARAMETROS.AC_DESP_0}");

            /*" -561- DISPLAY 'DESPREZADOS PRODUVG         ' AC-DESP-1 */
            _.Display($"DESPREZADOS PRODUVG         {PARAMETROS.AC_DESP_1}");

            /*" -562- DISPLAY 'DESPREZADOS CLIENTES        ' AC-DESP-2 */
            _.Display($"DESPREZADOS CLIENTES        {PARAMETROS.AC_DESP_2}");

            /*" -563- DISPLAY 'DESPREZADOS ENDERECO        ' AC-DESP-3 */
            _.Display($"DESPREZADOS ENDERECO        {PARAMETROS.AC_DESP_3}");

            /*" -564- DISPLAY 'DESPREZADOS OPCPAGVI        ' AC-DESP-4 */
            _.Display($"DESPREZADOS OPCPAGVI        {PARAMETROS.AC_DESP_4}");

            /*" -565- DISPLAY 'DESPREZADOS HISCOBPR        ' AC-DESP-5 */
            _.Display($"DESPREZADOS HISCOBPR        {PARAMETROS.AC_DESP_5}");

            /*" -566- DISPLAY 'DESPREZADOS PARCEVID-MEN    ' AC-DESP-6 */
            _.Display($"DESPREZADOS PARCEVID-MEN    {PARAMETROS.AC_DESP_6}");

            /*" -567- DISPLAY 'DESPREZADOS PARCEVID-ANU    ' AC-DESP-7 */
            _.Display($"DESPREZADOS PARCEVID-ANU    {PARAMETROS.AC_DESP_7}");

            /*" -568- DISPLAY 'DESPREZADOS PROPOFID        ' AC-DESP-8 */
            _.Display($"DESPREZADOS PROPOFID        {PARAMETROS.AC_DESP_8}");

            /*" -569- DISPLAY 'DESPREZADOS ENDOSSOS        ' AC-DESP-9 */
            _.Display($"DESPREZADOS ENDOSSOS        {PARAMETROS.AC_DESP_9}");

            /*" -570- DISPLAY 'DESPREZADOS PARCELA SEM PGTO' AC-DESP-11 */
            _.Display($"DESPREZADOS PARCELA SEM PGTO{PARAMETROS.AC_DESP_11}");

            /*" -571- DISPLAY '--------------------------------------- ' */
            _.Display($"--------------------------------------- ");

            /*" -572- DISPLAY 'STATUS 000  VIDA EXCLUSIVO  ' AC-DESP-10 */
            _.Display($"STATUS 000  VIDA EXCLUSIVO  {PARAMETROS.AC_DESP_10}");

            /*" -573- DISPLAY 'STATUS GERADOS              ' AC-GRAVADOS. */
            _.Display($"STATUS GERADOS              {PARAMETROS.AC_GRAVADOS}");

            /*" -575- DISPLAY '========================================' */
            _.Display($"========================================");

            /*" -577- DISPLAY '*** VA2720B - TERMINO NORMAL ***' */
            _.Display($"*** VA2720B - TERMINO NORMAL ***");

            /*" -579- PERFORM R9988-00-FECHAR-ARQUIVOS */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -579- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -593- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -596- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -599- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -605- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -608- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -609- DISPLAY 'R0020-ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"R0020-ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -610- DISPLAY 'SIGLA  = ' ARQSIVPF-SIGLA-ARQUIVO */
                _.Display($"SIGLA  = {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -611- DISPLAY 'ORIGEM = ' ARQSIVPF-SISTEMA-ORIGEM */
                _.Display($"ORIGEM = {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM}");

                /*" -612- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -613- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -615- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -618- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WORK_AREA.W_NSAS);

            /*" -620- ADD 1 TO W-NSAS. */
            WORK_AREA.W_NSAS.Value = WORK_AREA.W_NSAS + 1;

            /*" -623- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF */
            _.Move(WORK_AREA.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -623- PERFORM R0021-00-INSERT-ARQ-ENVIADO. */

            R0021_00_INSERT_ARQ_ENVIADO_SECTION();

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -605- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM END-EXEC. */

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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0021-00-INSERT-ARQ-ENVIADO-SECTION */
        private void R0021_00_INSERT_ARQ_ENVIADO_SECTION()
        {
            /*" -638- MOVE 'R0021' TO WNR-EXEC-SQL. */
            _.Move("R0021", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -641- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -644- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -648- MOVE SISTEMAS-DATA-MOV-ABERTO TO ARQSIVPF-DATA-PROCESSAMENTO ARQSIVPF-DATA-GERACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -651- MOVE 0 TO ARQSIVPF-QTDE-REG-GER */
            _.Move(0, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -659- PERFORM R0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1 */

            R0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1();

            /*" -662- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -663- DISPLAY 'R0021-ERRO INSERT ARQUIVOS-SIVPF' */
                _.Display($"R0021-ERRO INSERT ARQUIVOS-SIVPF");

                /*" -665- DISPLAY 'SIGLA DO ARQIVO = ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"SIGLA DO ARQIVO = {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -667- DISPLAY 'NSAS SIVPF      = ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"NSAS SIVPF      = {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -669- DISPLAY 'DATA GERACAO    = ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"DATA GERACAO    = {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -670- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -671- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -671- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0021-00-INSERT-ARQ-ENVIADO-DB-INSERT-1 */
        public void R0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -659- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:ARQSIVPF-SIGLA-ARQUIVO, :ARQSIVPF-SISTEMA-ORIGEM, :ARQSIVPF-NSAS-SIVPF, :ARQSIVPF-DATA-GERACAO, :ARQSIVPF-QTDE-REG-GER, :ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1_Insert1 = new R0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1_Insert1.Execute(r0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0021_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -685- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -692- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -695- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -696- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -697- DISPLAY 'R0100-SISTEMA VG NAO CADASTRADO' */
                    _.Display($"R0100-SISTEMA VG NAO CADASTRADO");

                    /*" -698- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", PARAMETROS.WFIM_V1SISTEMA);

                    /*" -699- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -700- ELSE */
                }
                else
                {


                    /*" -701- DISPLAY 'R0100-ERRO ACESSO SISTEMAS' */
                    _.Display($"R0100-ERRO ACESSO SISTEMAS");

                    /*" -702- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                    /*" -703- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -704- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -705- END-IF */
                }


                /*" -707- END-IF. */
            }


            /*" -709- MOVE 'R0110' TO WNR-EXEC-SQL. */
            _.Move("R0110", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -715- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_2 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_2();

            /*" -718- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -719- DISPLAY 'R0100-ERRO ACESSO RELATORIOS' */
                _.Display($"R0100-ERRO ACESSO RELATORIOS");

                /*" -720- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -721- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -722- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -724- END-IF. */
            }


            /*" -725- MOVE SISTEMAS-DATA-MOV-ABERTO TO DATA-SQL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.DATA_SQL);

            /*" -726- DISPLAY ' ' */
            _.Display($" ");

            /*" -729- DISPLAY 'PERIODO DE ' WS-PERIODO-DE ' ATE ' SISTEMAS-DATA-MOV-ABERTO. */

            $"PERIODO DE {WS_PERIODO_DE} ATE {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

            /*" -729- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -692- EXEC SQL SELECT DATA_MOV_ABERTO , DATA_MOV_ABERTO - 30 DAYS INTO :SISTEMAS-DATA-MOV-ABERTO , :SISTEMAS-DATA-MOV-ABERTO-30 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_30, SISTEMAS_DATA_MOV_ABERTO_30);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-2 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_2()
        {
            /*" -715- EXEC SQL SELECT DATA_SOLICITACAO + 1 DAY INTO :WS-PERIODO-DE FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'VA' AND COD_USUARIO = 'VA2720B' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_PERIODO_DE, WS_PERIODO_DE);
            }


        }

        [StopWatch]
        /*" R0200-00-GRAVA-HEADER-SECTION */
        private void R0200_00_GRAVA_HEADER_SECTION()
        {
            /*" -744- MOVE 'R0200' TO WNR-EXEC-SQL. */
            _.Move("R0200", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -746- MOVE SPACES TO VA2720B1O-REG */
            _.Move("", VA2720B1O_REG);

            /*" -747- MOVE 'H' TO VA2720B1O-IDENTIFICA. */
            _.Move("H", VA2720B1O_REG.VA2720B1O_IDENTIFICA);

            /*" -749- MOVE 'STASASSE' TO VA2720B1O-NOME-ARQ. */
            _.Move("STASASSE", VA2720B1O_REG.VA2720B1O_REG_H.VA2720B1O_NOME_ARQ);

            /*" -751- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO VA2720B1O-DATA-GER (5:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), VA2720B1O_REG.VA2720B1O_REG_H.VA2720B1O_DATA_GER, 5, 4);

            /*" -753- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO VA2720B1O-DATA-GER (3:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), VA2720B1O_REG.VA2720B1O_REG_H.VA2720B1O_DATA_GER, 3, 2);

            /*" -756- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO VA2720B1O-DATA-GER (1:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), VA2720B1O_REG.VA2720B1O_REG_H.VA2720B1O_DATA_GER, 1, 2);

            /*" -757- MOVE 4 TO VA2720B1O-COD-SIST. */
            _.Move(4, VA2720B1O_REG.VA2720B1O_REG_H.VA2720B1O_COD_SIST);

            /*" -758- MOVE 1 TO VA2720B1O-COD-SIST-DEST. */
            _.Move(1, VA2720B1O_REG.VA2720B1O_REG_H.VA2720B1O_COD_SIST_DEST);

            /*" -760- MOVE ARQSIVPF-NSAS-SIVPF TO VA2720B1O-SEQ-ARQ. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, VA2720B1O_REG.VA2720B1O_REG_H.VA2720B1O_SEQ_ARQ);

            /*" -761- WRITE REG-AVA2720B FROM VA2720B1O-REG. */
            _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

            AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-SECTION */
        private void R0900_00_DECLARE_PROPOVA_SECTION()
        {
            /*" -775- MOVE 'R0900' TO WNR-EXEC-SQL. */
            _.Move("R0900", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -866- PERFORM R0900_00_DECLARE_PROPOVA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOVA_DB_DECLARE_1();

            /*" -868- PERFORM R0900_00_DECLARE_PROPOVA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOVA_DB_OPEN_1();

            /*" -871- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -872- DISPLAY 'R0900-ERRO OPEN TPROPOVA' */
                _.Display($"R0900-ERRO OPEN TPROPOVA");

                /*" -873- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -874- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -875- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -875- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOVA_DB_DECLARE_1()
        {
            /*" -866- EXEC SQL DECLARE TPROPOVA CURSOR FOR SELECT C.NUM_APOLICE , C.COD_SUBGRUPO , C.NUM_CERTIFICADO , C.COD_CLIENTE , C.OCOREND , C.AGE_COBRANCA , C.DATA_MOVIMENTO , C.SIT_REGISTRO , C.COD_PRODUTO , C.NRCERTIFANT , '0001-01-01' , 0 , 0 , 0 , 0 , 0 , 0 , 0 , '0001-01-01' , C.OCORR_HISTORICO , C.DATA_QUITACAO , C.NUM_PARCELA , B.ORIG_PRODU FROM SEGUROS.SUBGRUPOS_VGAP A, SEGUROS.PRODUTOS_VG B, SEGUROS.PROPOSTAS_VA C WHERE B.ORIG_PRODU IN ( 'ESPEC' , 'ESPE1' ) AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.COD_PRODUTO NOT BETWEEN 7700 AND 7799 AND C.NUM_APOLICE = A.NUM_APOLICE AND C.COD_SUBGRUPO = A.COD_SUBGRUPO AND C.DTPROXVEN <> '9999-12-31' UNION SELECT C.NUM_APOLICE , C.COD_SUBGRUPO , C.NUM_CERTIFICADO , C.COD_CLIENTE , C.OCOREND , C.AGE_COBRANCA , C.DATA_MOVIMENTO , C.SIT_REGISTRO , C.COD_PRODUTO , C.NRCERTIFANT , D.DATA_MOVIMENTO , D.IMP_MORNATU_ATU , D.IMP_MORACID_ATU , D.IMP_INVPERM_ATU , D.IMP_AMDS_ATU , D.IMP_DH_ATU , D.IMP_DIT_ATU , D.COD_OPERACAO , D.DATA_OPERACAO , C.OCORR_HISTORICO , C.DATA_QUITACAO , C.NUM_PARCELA , B.ORIG_PRODU FROM SEGUROS.SUBGRUPOS_VGAP A, SEGUROS.PRODUTOS_VG B, SEGUROS.PROPOSTAS_VA C, SEGUROS.MOVIMENTO_VGAP D WHERE A.SIT_REGISTRO = '0' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.COD_PRODUTO NOT BETWEEN 7700 AND 7799 AND B.NUM_APOLICE = C.NUM_APOLICE AND B.COD_SUBGRUPO = C.COD_SUBGRUPO AND C.NUM_APOLICE = A.NUM_APOLICE AND C.COD_SUBGRUPO = A.COD_SUBGRUPO AND C.DTPROXVEN <> '9999-12-31' AND C.COD_PRODUTO IN ( 9310, :JVPRD9310 ) AND C.NUM_APOLICE = D.NUM_APOLICE AND C.COD_SUBGRUPO = D.COD_SUBGRUPO AND C.NUM_CERTIFICADO = D.NUM_CERTIFICADO AND ((D.COD_OPERACAO BETWEEN 100 AND 199) OR (D.COD_OPERACAO BETWEEN 400 AND 499)) AND D.DATA_INCLUSAO IS NOT NULL AND (D.DATA_INCLUSAO BETWEEN :WS-PERIODO-DE AND :SISTEMAS-DATA-MOV-ABERTO) END-EXEC. */
            TPROPOVA = new VA2720B_TPROPOVA(true);
            string GetQuery_TPROPOVA()
            {
                var query = @$"SELECT 
							C.NUM_APOLICE
							, 
							C.COD_SUBGRUPO
							, 
							C.NUM_CERTIFICADO
							, 
							C.COD_CLIENTE
							, 
							C.OCOREND
							, 
							C.AGE_COBRANCA
							, 
							C.DATA_MOVIMENTO
							, 
							C.SIT_REGISTRO
							, 
							C.COD_PRODUTO
							, 
							C.NRCERTIFANT
							, 
							'0001-01-01'
							, 
							0
							, 
							0
							, 
							0
							, 
							0
							, 
							0
							, 
							0
							, 
							0
							, 
							'0001-01-01'
							, 
							C.OCORR_HISTORICO
							, 
							C.DATA_QUITACAO
							, 
							C.NUM_PARCELA
							, 
							B.ORIG_PRODU 
							FROM 
							SEGUROS.SUBGRUPOS_VGAP A
							, 
							SEGUROS.PRODUTOS_VG B
							, 
							SEGUROS.PROPOSTAS_VA C 
							WHERE 
							B.ORIG_PRODU IN ( 'ESPEC'
							, 'ESPE1' ) 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.COD_PRODUTO NOT BETWEEN 7700 AND 7799 
							AND C.NUM_APOLICE = A.NUM_APOLICE 
							AND C.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND C.DTPROXVEN <> '9999-12-31' 
							UNION 
							SELECT 
							C.NUM_APOLICE
							, 
							C.COD_SUBGRUPO
							, 
							C.NUM_CERTIFICADO
							, 
							C.COD_CLIENTE
							, 
							C.OCOREND
							, 
							C.AGE_COBRANCA
							, 
							C.DATA_MOVIMENTO
							, 
							C.SIT_REGISTRO
							, 
							C.COD_PRODUTO
							, 
							C.NRCERTIFANT
							, 
							D.DATA_MOVIMENTO
							, 
							D.IMP_MORNATU_ATU
							, 
							D.IMP_MORACID_ATU
							, 
							D.IMP_INVPERM_ATU
							, 
							D.IMP_AMDS_ATU
							, 
							D.IMP_DH_ATU
							, 
							D.IMP_DIT_ATU
							, 
							D.COD_OPERACAO
							, 
							D.DATA_OPERACAO
							, 
							C.OCORR_HISTORICO
							, 
							C.DATA_QUITACAO
							, 
							C.NUM_PARCELA
							, 
							B.ORIG_PRODU 
							FROM 
							SEGUROS.SUBGRUPOS_VGAP A
							, 
							SEGUROS.PRODUTOS_VG B
							, 
							SEGUROS.PROPOSTAS_VA C
							, 
							SEGUROS.MOVIMENTO_VGAP D 
							WHERE A.SIT_REGISTRO = '0' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.COD_PRODUTO NOT BETWEEN 7700 AND 7799 
							AND B.NUM_APOLICE = C.NUM_APOLICE 
							AND B.COD_SUBGRUPO = C.COD_SUBGRUPO 
							AND C.NUM_APOLICE = A.NUM_APOLICE 
							AND C.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND C.DTPROXVEN <> '9999-12-31' 
							AND C.COD_PRODUTO IN ( 9310
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9310}' ) 
							AND C.NUM_APOLICE = D.NUM_APOLICE 
							AND C.COD_SUBGRUPO = D.COD_SUBGRUPO 
							AND C.NUM_CERTIFICADO = D.NUM_CERTIFICADO 
							AND ((D.COD_OPERACAO BETWEEN 100 AND 199) OR 
							(D.COD_OPERACAO BETWEEN 400 AND 499)) 
							AND D.DATA_INCLUSAO IS NOT NULL 
							AND (D.DATA_INCLUSAO BETWEEN '{WS_PERIODO_DE}' 
							AND '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}')";

                return query;
            }
            TPROPOVA.GetQueryEvent += GetQuery_TPROPOVA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOVA_DB_OPEN_1()
        {
            /*" -868- EXEC SQL OPEN TPROPOVA END-EXEC. */

            TPROPOVA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-SECTION */
        private void R0910_00_FETCH_PROPOVA_SECTION()
        {
            /*" -889- MOVE 'R0910' TO WNR-EXEC-SQL. */
            _.Move("R0910", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -918- PERFORM R0910_00_FETCH_PROPOVA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOVA_DB_FETCH_1();

            /*" -921- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -922- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -923- MOVE 'S' TO WFIM-PROPOVA */
                    _.Move("S", PARAMETROS.WFIM_PROPOVA);

                    /*" -923- PERFORM R0910_00_FETCH_PROPOVA_DB_CLOSE_1 */

                    R0910_00_FETCH_PROPOVA_DB_CLOSE_1();

                    /*" -925- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -926- ELSE */
                }
                else
                {


                    /*" -927- DISPLAY 'R0910-ERRO FETCH TPROPOVA' */
                    _.Display($"R0910-ERRO FETCH TPROPOVA");

                    /*" -928- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                    /*" -929- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -930- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -931- END-IF */
                }


                /*" -954- END-IF. */
            }


            /*" -956- MOVE SPACES TO TEM-CAN-EXCLUSIVO */
            _.Move("", PARAMETROS.TEM_CAN_EXCLUSIVO);

            /*" -958- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPROD(9310) */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.FILLER.JVPROD[9310].ToString()))
            {

                /*" -959- IF PROPOVA-SIT-REGISTRO NOT EQUAL '3' AND '2' AND '4' */

                if (!PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.In("3", "2", "4"))
                {

                    /*" -960- GO TO R0910-00-FETCH-PROPOVA */
                    new Task(() => R0910_00_FETCH_PROPOVA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -961- END-IF */
                }


                /*" -962- IF (MOVVGAP-COD-OPERACAO GREATER 399 AND LESS 500) */

                if ((MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_OPERACAO > 399 && MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_OPERACAO < 500))
                {

                    /*" -963- MOVE 'S' TO TEM-CAN-EXCLUSIVO */
                    _.Move("S", PARAMETROS.TEM_CAN_EXCLUSIVO);

                    /*" -964- END-IF */
                }


                /*" -966- ELSE */
            }
            else
            {


                /*" -967- IF PROPOVA-SIT-REGISTRO NOT EQUAL '3' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO != "3")
                {

                    /*" -968- GO TO R0910-00-FETCH-PROPOVA */
                    new Task(() => R0910_00_FETCH_PROPOVA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -969- END-IF */
                }


                /*" -971- END-IF. */
            }


            /*" -973- IF PROPOVA-DATA-MOVIMENTO GREATER SISTEMAS-DATA-MOV-ABERTO */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO > SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
            {

                /*" -974- GO TO R0910-00-FETCH-PROPOVA */
                new Task(() => R0910_00_FETCH_PROPOVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -976- END-IF. */
            }


            /*" -976- ADD 1 TO AC-LIDOS. */
            PARAMETROS.AC_LIDOS.Value = PARAMETROS.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -918- EXEC SQL FETCH TPROPOVA INTO :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO , :PROPOVA-NUM-CERTIFICADO , :PROPOVA-COD-CLIENTE , :PROPOVA-OCOREND , :PROPOVA-AGE-COBRANCA , :PROPOVA-DATA-MOVIMENTO , :PROPOVA-SIT-REGISTRO , :PROPOVA-COD-PRODUTO , :PROPOVA-NRCERTIFANT INDICATOR :VIND-NRCERTIFANT, :MOVVGAP-DATA-MOVIMENTO INDICATOR :VIND-DATA-MOVIMENTO, :MOVVGAP-IMP-MORNATU-ATU , :MOVVGAP-IMP-MORACID-ATU , :MOVVGAP-IMP-INVPERM-ATU , :MOVVGAP-IMP-AMDS-ATU , :MOVVGAP-IMP-DH-ATU , :MOVVGAP-IMP-DIT-ATU , :MOVVGAP-COD-OPERACAO INDICATOR :VIND-DATA-OPERACAO, :MOVVGAP-DATA-OPERACAO , :PROPOVA-OCORR-HISTORICO , :PROPOVA-DATA-QUITACAO INDICATOR :VIND-DATA-QUITACAO, :PROPOVA-NUM-PARCELA , :PRODUVG-ORIG-PRODU END-EXEC. */

            if (TPROPOVA.Fetch())
            {
                _.Move(TPROPOVA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(TPROPOVA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(TPROPOVA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(TPROPOVA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(TPROPOVA.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
                _.Move(TPROPOVA.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
                _.Move(TPROPOVA.PROPOVA_DATA_MOVIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO);
                _.Move(TPROPOVA.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(TPROPOVA.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(TPROPOVA.MOVVGAP_IMP_MORNATU_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORNATU_ATU);
                _.Move(TPROPOVA.MOVVGAP_IMP_MORACID_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORACID_ATU);
                _.Move(TPROPOVA.MOVVGAP_IMP_INVPERM_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_INVPERM_ATU);
                _.Move(TPROPOVA.MOVVGAP_IMP_AMDS_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_AMDS_ATU);
                _.Move(TPROPOVA.MOVVGAP_IMP_DH_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DH_ATU);
                _.Move(TPROPOVA.MOVVGAP_IMP_DIT_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DIT_ATU);
                _.Move(TPROPOVA.MOVVGAP_DATA_OPERACAO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_OPERACAO);
                _.Move(TPROPOVA.PROPOVA_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);
                _.Move(TPROPOVA.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(TPROPOVA.PRODUVG_ORIG_PRODU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -923- EXEC SQL CLOSE TPROPOVA END-EXEC */

            TPROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -990- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -992- MOVE SPACES TO TEM-RENOVACAO */
            _.Move("", PARAMETROS.TEM_RENOVACAO);

            /*" -993- PERFORM R1300-00-SELECT-PROPOFID */

            R1300_00_SELECT_PROPOFID_SECTION();

            /*" -994- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -995- ADD 1 TO AC-DESP-8 */
                PARAMETROS.AC_DESP_8.Value = PARAMETROS.AC_DESP_8 + 1;

                /*" -997- DISPLAY 'CERTIFICADO SEM PROPOFID ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO SEM PROPOFID {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -998- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1000- END-IF. */
            }


            /*" -1001- IF TEM-CAN-EXCLUSIVO EQUAL 'S' */

            if (PARAMETROS.TEM_CAN_EXCLUSIVO == "S")
            {

                /*" -1002- MOVE 'CAN' TO VA2720B1O-SIT-PROPOSTA */
                _.Move("CAN", VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_SIT_PROPOSTA);

                /*" -1003- MOVE 101 TO VA2720B1O-TIPO-MOTIVO */
                _.Move(101, VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_TIPO_MOTIVO);

                /*" -1004- MOVE 101 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                _.Move(101, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                /*" -1005- PERFORM R1100-00-GRAVA-TIPO-1 */

                R1100_00_GRAVA_TIPO_1_SECTION();

                /*" -1006- PERFORM R1120-00-GRAVA-HISPROFI */

                R1120_00_GRAVA_HISPROFI_SECTION();

                /*" -1007- PERFORM R1200-00-GRAVA-TIPO-2 */

                R1200_00_GRAVA_TIPO_2_SECTION();

                /*" -1009- MOVE ' ' TO TEM-CAN-EXCLUSIVO */
                _.Move(" ", PARAMETROS.TEM_CAN_EXCLUSIVO);

                /*" -1010- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1012- END-IF. */
            }


            /*" -1014- MOVE SPACES TO VA2720B1O-REG-1 */
            _.Move("", VA2720B1O_REG.VA2720B1O_REG_1);

            /*" -1015- IF PROPOVA-SIT-REGISTRO EQUAL '3' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3")
            {

                /*" -1016- MOVE 'EMT' TO VA2720B1O-SIT-PROPOSTA */
                _.Move("EMT", VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_SIT_PROPOSTA);

                /*" -1018- IF PROPOVA-COD-PRODUTO NOT EQUAL 9310 AND JVPROD(9310) */

                if (!PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.FILLER.JVPROD[9310].ToString()))
                {

                    /*" -1019- PERFORM R1150-SELECT-RELATORIOS */

                    R1150_SELECT_RELATORIOS_SECTION();

                    /*" -1020- IF TEM-RENOVACAO EQUAL 'S' */

                    if (PARAMETROS.TEM_RENOVACAO == "S")
                    {

                        /*" -1021- PERFORM R1401-00-SELECT-HISTCON */

                        R1401_00_SELECT_HISTCON_SECTION();

                        /*" -1022- IF SQLCODE NOT EQUAL ZEROS AND -811 */

                        if (!DB.SQLCODE.In("00", "-811"))
                        {

                            /*" -1025- DISPLAY 'PARCELA RENOVACAO NAO PAGA: ' PROPOVA-NUM-CERTIFICADO '/' PROPOVA-NUM-PARCELA */

                            $"PARCELA RENOVACAO NAO PAGA: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA}"
                            .Display();

                            /*" -1026- ADD 1 TO AC-DESP-11 */
                            PARAMETROS.AC_DESP_11.Value = PARAMETROS.AC_DESP_11 + 1;

                            /*" -1027- GO TO R1000-10-NEXT */

                            R1000_10_NEXT(); //GOTO
                            return;

                            /*" -1028- END-IF */
                        }


                        /*" -1030- MOVE 731 TO VA2720B1O-TIPO-MOTIVO PROPFIDH-SIT-MOTIVO-SIVPF */
                        _.Move(731, VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_TIPO_MOTIVO);
                        _.Move(731, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);


                        /*" -1031- ELSE */
                    }
                    else
                    {


                        /*" -1032- IF PROPOVA-DATA-MOVIMENTO GREATER '2011-12-31' */

                        if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO > "2011-12-31")
                        {

                            /*" -1034- MOVE 228 TO VA2720B1O-TIPO-MOTIVO PROPFIDH-SIT-MOTIVO-SIVPF */
                            _.Move(228, VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_TIPO_MOTIVO);
                            _.Move(228, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);


                            /*" -1035- ELSE */
                        }
                        else
                        {


                            /*" -1037- MOVE 000 TO VA2720B1O-TIPO-MOTIVO PROPFIDH-SIT-MOTIVO-SIVPF */
                            _.Move(000, VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_TIPO_MOTIVO);
                            _.Move(000, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);


                            /*" -1038- END-IF */
                        }


                        /*" -1039- END-IF */
                    }


                    /*" -1041- ELSE */
                }
                else
                {


                    /*" -1044- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 06 AND PROPOFID-ORIGEM-PROPOSTA EQUAL 08 AND PROPOFID-CANAL-PROPOSTA EQUAL 08 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 06 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 08 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA == 08)
                    {

                        /*" -1045- MOVE 000 TO VA2720B1O-TIPO-MOTIVO */
                        _.Move(000, VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_TIPO_MOTIVO);

                        /*" -1046- MOVE 000 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                        _.Move(000, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                        /*" -1047- END-IF */
                    }


                    /*" -1048- END-IF */
                }


                /*" -1050- ELSE */
            }
            else
            {


                /*" -1051- MOVE 'CAN' TO VA2720B1O-SIT-PROPOSTA */
                _.Move("CAN", VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_SIT_PROPOSTA);

                /*" -1052- MOVE 101 TO VA2720B1O-TIPO-MOTIVO */
                _.Move(101, VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_TIPO_MOTIVO);

                /*" -1053- MOVE 101 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                _.Move(101, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                /*" -1073- END-IF. */
            }


            /*" -1074- PERFORM R1400-00-SELECT-ENDOSSOS */

            R1400_00_SELECT_ENDOSSOS_SECTION();

            /*" -1075- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1076- ADD 1 TO AC-DESP-9 */
                PARAMETROS.AC_DESP_9.Value = PARAMETROS.AC_DESP_9 + 1;

                /*" -1078- DISPLAY 'CERTIFICADO SEM ENDOSSO ZERO ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO SEM ENDOSSO ZERO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1079- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1081- END-IF. */
            }


            /*" -1083- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPROD(9310) */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.FILLER.JVPROD[9310].ToString()))
            {

                /*" -1084- PERFORM R1405-00-OBTER-DADOS-SEGURADO */

                R1405_00_OBTER_DADOS_SEGURADO_SECTION();

                /*" -1085- PERFORM R1410-00-OBTER-VIGENCIA */

                R1410_00_OBTER_VIGENCIA_SECTION();

                /*" -1086- PERFORM R1415-00-OBTER-COBERTURAS */

                R1415_00_OBTER_COBERTURAS_SECTION();

                /*" -1090- ELSE */
            }
            else
            {


                /*" -1091- PERFORM R1110-00-SELECT-HISPROFI */

                R1110_00_SELECT_HISPROFI_SECTION();

                /*" -1092- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1093- CONTINUE */

                    /*" -1094- ELSE */
                }
                else
                {


                    /*" -1095- MOVE PROPFIDH-DATA-SITUACAO TO DATA-SQL-HIST */
                    _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, WORK_AREA.DATA_SQL_HIST);

                    /*" -1096- IF TEM-RENOVACAO NOT EQUAL 'S' */

                    if (PARAMETROS.TEM_RENOVACAO != "S")
                    {

                        /*" -1097- CONTINUE */

                        /*" -1098- ELSE */
                    }
                    else
                    {


                        /*" -1099- IF ANO-SQL EQUAL ANO-SQL-HIST */

                        if (WORK_AREA.DATA_SQL.ANO_SQL == WORK_AREA.DATA_SQL_HIST.ANO_SQL_HIST)
                        {

                            /*" -1100- ADD 1 TO AC-DESP-0 */
                            PARAMETROS.AC_DESP_0.Value = PARAMETROS.AC_DESP_0 + 1;

                            /*" -1102- DISPLAY 'CERTIFICADO JA FOI RENOVADO ' PROPOVA-NUM-CERTIFICADO */
                            _.Display($"CERTIFICADO JA FOI RENOVADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                            /*" -1103- PERFORM R1160-UPDATE-RELATORIOS */

                            R1160_UPDATE_RELATORIOS_SECTION();

                            /*" -1104- ADD 1 TO AC-DESP-0 */
                            PARAMETROS.AC_DESP_0.Value = PARAMETROS.AC_DESP_0 + 1;

                            /*" -1105- GO TO R1000-10-NEXT */

                            R1000_10_NEXT(); //GOTO
                            return;

                            /*" -1106- END-IF */
                        }


                        /*" -1107- END-IF */
                    }


                    /*" -1108- END-IF */
                }


                /*" -1110- END-IF. */
            }


            /*" -1111- PERFORM R1500-00-SELECT-HISCOBPR */

            R1500_00_SELECT_HISCOBPR_SECTION();

            /*" -1112- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1113- ADD 1 TO AC-DESP-5 */
                PARAMETROS.AC_DESP_5.Value = PARAMETROS.AC_DESP_5 + 1;

                /*" -1115- DISPLAY 'CERTIFICADO SEM HIS_COBER_PROPOST ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO SEM HIS_COBER_PROPOST {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1116- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1118- END-IF. */
            }


            /*" -1119- PERFORM R1510-00-SELECT-HISCOBPR */

            R1510_00_SELECT_HISCOBPR_SECTION();

            /*" -1120- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1121- ADD 1 TO AC-DESP-5 */
                PARAMETROS.AC_DESP_5.Value = PARAMETROS.AC_DESP_5 + 1;

                /*" -1123- DISPLAY 'CERTIFICADO SEM HIS_COBER_PROPOST VIGENTE ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO SEM HIS_COBER_PROPOST VIGENTE {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1124- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1126- END-IF. */
            }


            /*" -1127- PERFORM R1700-00-SELECT-RAMOCOMP */

            R1700_00_SELECT_RAMOCOMP_SECTION();

            /*" -1128- PERFORM R1100-00-GRAVA-TIPO-1 */

            R1100_00_GRAVA_TIPO_1_SECTION();

            /*" -1129- PERFORM R1120-00-GRAVA-HISPROFI */

            R1120_00_GRAVA_HISPROFI_SECTION();

            /*" -1130- PERFORM R1200-00-GRAVA-TIPO-2 */

            R1200_00_GRAVA_TIPO_2_SECTION();

            /*" -1134- PERFORM R1210-00-GRAVA-TIPO-3. */

            R1210_00_GRAVA_TIPO_3_SECTION();

            /*" -1135- IF TEM-RENOVACAO EQUAL 'S' */

            if (PARAMETROS.TEM_RENOVACAO == "S")
            {

                /*" -1136- PERFORM R1160-UPDATE-RELATORIOS */

                R1160_UPDATE_RELATORIOS_SECTION();

                /*" -1136- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1140- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-GRAVA-TIPO-1-SECTION */
        private void R1100_00_GRAVA_TIPO_1_SECTION()
        {
            /*" -1154- MOVE 'R1100' TO WNR-EXEC-SQL. */
            _.Move("R1100", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1155- MOVE '1' TO VA2720B1O-IDENTIFICA. */
            _.Move("1", VA2720B1O_REG.VA2720B1O_IDENTIFICA);

            /*" -1158- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO WS-NUM-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WORK_AREA.WS_NUM_PROPOSTA);

            /*" -1159- IF WS-NUM-PROPOSTA(1:1) NOT EQUAL ZEROS */

            if (WORK_AREA.WS_NUM_PROPOSTA.Substring(1, 1) != 00)
            {

                /*" -1161- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO VA2720B1O-NUM-PROPOSTA-1 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_NUM_PROPOSTA_1);

                /*" -1162- ELSE */
            }
            else
            {


                /*" -1164- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA-9 */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_9);

                /*" -1166- MOVE 0 TO WS-NUM-PROPOSTA-0 */
                _.Move(0, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_0);

                /*" -1168- MOVE WS-NUM-PROPOSTA TO VA2720B1O-NUM-PROPOSTA-1 */
                _.Move(WORK_AREA.WS_NUM_PROPOSTA, VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_NUM_PROPOSTA_1);

                /*" -1170- END-IF. */
            }


            /*" -1171- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPROD(9310) */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.FILLER.JVPROD[9310].ToString()))
            {

                /*" -1173- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO VA2720B1O-NUM-PROPOSTA-1 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_NUM_PROPOSTA_1);

                /*" -1175- END-IF */
            }


            /*" -1177- MOVE PROPOVA-DATA-MOVIMENTO (1:4) TO VA2720B1O-DATA-INICIO-SIT (5:4) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.Substring(1, 4), VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_DATA_INICIO_SIT, 5, 4);

            /*" -1179- MOVE PROPOVA-DATA-MOVIMENTO (6:2) TO VA2720B1O-DATA-INICIO-SIT (3:2) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.Substring(6, 2), VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_DATA_INICIO_SIT, 3, 2);

            /*" -1182- MOVE PROPOVA-DATA-MOVIMENTO (9:2) TO VA2720B1O-DATA-INICIO-SIT (1:2) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.Substring(9, 2), VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_DATA_INICIO_SIT, 1, 2);

            /*" -1185- MOVE SPACES TO VA2720B1O-BRANCOS-0 VA2720B1O-BRANCOS-1. */
            _.Move("", VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_BRANCOS_0);
            _.Move("", VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_BRANCOS_1);


            /*" -1187- ADD 1 TO W-NSL */
            WORK_AREA.W_NSL.Value = WORK_AREA.W_NSL + 1;

            /*" -1188- MOVE ARQSIVPF-NSAS-SIVPF TO VA2720B1O-NUM-SEQ-ARQ. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_NUM_SEQ_ARQ);

            /*" -1190- MOVE W-NSL TO VA2720B1O-NUM-SEQ-REG. */
            _.Move(WORK_AREA.W_NSL, VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_NUM_SEQ_REG);

            /*" -1193- WRITE REG-AVA2720B FROM VA2720B1O-REG. */
            _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

            AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

            /*" -1194- ADD 1 TO W-QTD-LD-TIPO-1 AC-GRAVADOS. */
            PARAMETROS.W_QTD_LD_TIPO_1.Value = PARAMETROS.W_QTD_LD_TIPO_1 + 1;
            PARAMETROS.AC_GRAVADOS.Value = PARAMETROS.AC_GRAVADOS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-SELECT-HISPROFI-SECTION */
        private void R1110_00_SELECT_HISPROFI_SECTION()
        {
            /*" -1208- MOVE 'R1110' TO WNR-EXEC-SQL. */
            _.Move("R1110", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1220- PERFORM R1110_00_SELECT_HISPROFI_DB_SELECT_1 */

            R1110_00_SELECT_HISPROFI_DB_SELECT_1();

            /*" -1223- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1224- DISPLAY 'R1110-ERRO ACESSO HIST_PROP_FIDELIZ' */
                _.Display($"R1110-ERRO ACESSO HIST_PROP_FIDELIZ");

                /*" -1226- DISPLAY 'NUM_CERTIFICADO   = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO   = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1228- DISPLAY 'NUM-IDENTIFICACAO = ' PROPOFID-NUM-IDENTIFICACAO */
                _.Display($"NUM-IDENTIFICACAO = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                /*" -1230- DISPLAY 'SIT-MOTIVO-SIVPF  = ' PROPFIDH-SIT-MOTIVO-SIVPF */
                _.Display($"SIT-MOTIVO-SIVPF  = {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF}");

                /*" -1231- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -1232- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1233- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1233- END-IF. */
            }


        }

        [StopWatch]
        /*" R1110-00-SELECT-HISPROFI-DB-SELECT-1 */
        public void R1110_00_SELECT_HISPROFI_DB_SELECT_1()
        {
            /*" -1220- EXEC SQL SELECT SIT_PROPOSTA, DATA_SITUACAO INTO :PROPFIDH-SIT-PROPOSTA, :PROPFIDH-DATA-SITUACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPOFID-NUM-IDENTIFICACAO AND SIT_MOTIVO_SIVPF = :PROPFIDH-SIT-MOTIVO-SIVPF ORDER BY DATA_SITUACAO DESC FETCH FIRST 1 ROWS ONLY END-EXEC. */

            var r1110_00_SELECT_HISPROFI_DB_SELECT_1_Query1 = new R1110_00_SELECT_HISPROFI_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_SIT_MOTIVO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.ToString(),
            };

            var executed_1 = R1110_00_SELECT_HISPROFI_DB_SELECT_1_Query1.Execute(r1110_00_SELECT_HISPROFI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);
                _.Move(executed_1.PROPFIDH_DATA_SITUACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1120-00-GRAVA-HISPROFI-SECTION */
        private void R1120_00_GRAVA_HISPROFI_SECTION()
        {
            /*" -1247- MOVE 'R1120' TO WNR-EXEC-SQL. */
            _.Move("R1120", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1250- MOVE PROPOVA-DATA-MOVIMENTO (1:4) TO VA2720B1O-DATA-INICIO-SIT (5:4) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.Substring(1, 4), VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_DATA_INICIO_SIT, 5, 4);

            /*" -1253- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1256- MOVE SISTEMAS-DATA-MOV-ABERTO TO PROPFIDH-DATA-SITUACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -1259- MOVE ARQSIVPF-NSAS-SIVPF TO PROPFIDH-NSAS-SIVPF */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -1262- MOVE W-NSL TO PROPFIDH-NSL. */
            _.Move(WORK_AREA.W_NSL, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -1265- MOVE VA2720B1O-SIT-PROPOSTA TO PROPFIDH-SIT-PROPOSTA. */
            _.Move(VA2720B1O_REG.VA2720B1O_REG_1.VA2720B1O_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1269- MOVE 'PAG' TO PROPFIDH-SIT-COBRANCA-SIVPF */
            _.Move("PAG", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -1272- MOVE PROPOFID-COD-EMPRESA-SIVPF TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -1275- MOVE PROPOFID-COD-PRODUTO-SIVPF TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -1296- PERFORM R1120_00_GRAVA_HISPROFI_DB_INSERT_1 */

            R1120_00_GRAVA_HISPROFI_DB_INSERT_1();

            /*" -1299- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1300- DISPLAY 'R1120-ERRO INSERT HIST-PROP-FIDELIZ' */
                _.Display($"R1120-ERRO INSERT HIST-PROP-FIDELIZ");

                /*" -1302- DISPLAY 'NUMERO PROPOSTA      = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUMERO PROPOSTA      = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1304- DISPLAY 'NUMERO IDENTIFICACAO = ' PROPFIDH-NUM-IDENTIFICACAO */
                _.Display($"NUMERO IDENTIFICACAO = {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}");

                /*" -1305- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -1306- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1306- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1120-00-GRAVA-HISPROFI-DB-INSERT-1 */
        public void R1120_00_GRAVA_HISPROFI_DB_INSERT_1()
        {
            /*" -1296- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ ( NUM_IDENTIFICACAO , DATA_SITUACAO , NSAS_SIVPF , NSL , SIT_PROPOSTA , SIT_COBRANCA_SIVPF , SIT_MOTIVO_SIVPF , COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF ) VALUES (:PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF , :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

            var r1120_00_GRAVA_HISPROFI_DB_INSERT_1_Insert1 = new R1120_00_GRAVA_HISPROFI_DB_INSERT_1_Insert1()
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

            R1120_00_GRAVA_HISPROFI_DB_INSERT_1_Insert1.Execute(r1120_00_GRAVA_HISPROFI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1150-SELECT-RELATORIOS-SECTION */
        private void R1150_SELECT_RELATORIOS_SECTION()
        {
            /*" -1328- MOVE 'R1150' TO WNR-EXEC-SQL. */
            _.Move("R1150", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1347- PERFORM R1150_SELECT_RELATORIOS_DB_SELECT_1 */

            R1150_SELECT_RELATORIOS_DB_SELECT_1();

            /*" -1350- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1351- DISPLAY 'R1150-ERRO ACESSO RELATORIOS' */
                _.Display($"R1150-ERRO ACESSO RELATORIOS");

                /*" -1352- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1353- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -1354- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1356- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1357- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1358- MOVE 'S' TO TEM-RENOVACAO */
                _.Move("S", PARAMETROS.TEM_RENOVACAO);

                /*" -1359- ELSE */
            }
            else
            {


                /*" -1360- MOVE SPACES TO TEM-RENOVACAO */
                _.Move("", PARAMETROS.TEM_RENOVACAO);

                /*" -1361- END-IF. */
            }


        }

        [StopWatch]
        /*" R1150-SELECT-RELATORIOS-DB-SELECT-1 */
        public void R1150_SELECT_RELATORIOS_DB_SELECT_1()
        {
            /*" -1347- EXEC SQL SELECT DATA_SOLICITACAO , COD_RELATORIO , NUM_CERTIFICADO , NUM_PARCELA , COD_PLANO INTO :RELATORI-DATA-SOLICITACAO ,:RELATORI-COD-RELATORIO ,:RELATORI-NUM-CERTIFICADO ,:RELATORI-NUM-PARCELA ,:RELATORI-COD-PLANO FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO IN ( 'VGICA' , 'VGIDA' , 'VGIEA' ) AND SIT_REGISTRO = '0' AND NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA > 0 AND COD_PLANO > 0 ORDER BY TIMESTAMP DESC FETCH FIRST 1 ROWS ONLY END-EXEC. */

            var r1150_SELECT_RELATORIOS_DB_SELECT_1_Query1 = new R1150_SELECT_RELATORIOS_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1150_SELECT_RELATORIOS_DB_SELECT_1_Query1.Execute(r1150_SELECT_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(executed_1.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
                _.Move(executed_1.RELATORI_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);
                _.Move(executed_1.RELATORI_NUM_PARCELA, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);
                _.Move(executed_1.RELATORI_COD_PLANO, RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1160-UPDATE-RELATORIOS-SECTION */
        private void R1160_UPDATE_RELATORIOS_SECTION()
        {
            /*" -1374- MOVE 'R1160' TO WNR-EXEC-SQL. */
            _.Move("R1160", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1382- PERFORM R1160_UPDATE_RELATORIOS_DB_UPDATE_1 */

            R1160_UPDATE_RELATORIOS_DB_UPDATE_1();

            /*" -1385- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1386- DISPLAY 'R1160-ERRO UPDATE RELATORIOS' */
                _.Display($"R1160-ERRO UPDATE RELATORIOS");

                /*" -1387- DISPLAY 'DATA_SOLICITACAO = ' RELATORI-COD-RELATORIO */
                _.Display($"DATA_SOLICITACAO = {RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}");

                /*" -1388- DISPLAY 'COD-RELATORIO    = ' RELATORI-COD-RELATORIO */
                _.Display($"COD-RELATORIO    = {RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}");

                /*" -1389- DISPLAY 'CERTIFICADO      = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO      = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -1390- DISPLAY 'PARCELA          = ' RELATORI-NUM-PARCELA */
                _.Display($"PARCELA          = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                /*" -1391- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -1392- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1393- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1394- END-IF. */
            }


        }

        [StopWatch]
        /*" R1160-UPDATE-RELATORIOS-DB-UPDATE-1 */
        public void R1160_UPDATE_RELATORIOS_DB_UPDATE_1()
        {
            /*" -1382- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE DATA_SOLICITACAO = :RELATORI-DATA-SOLICITACAO AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA END-EXEC. */

            var r1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 = new R1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1()
            {
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            R1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1.Execute(r1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1160_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GRAVA-TIPO-2-SECTION */
        private void R1200_00_GRAVA_TIPO_2_SECTION()
        {
            /*" -1407- MOVE 'R1200' TO WNR-EXEC-SQL. */
            _.Move("R1200", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1412- INITIALIZE VA2720B1O-REG-2 REPLACING ALPHANUMERIC BY SPACES NUMERIC BY ZEROES. */
            _.Initialize(
                VA2720B1O_REG.VA2720B1O_REG_2
            );

            /*" -1416- MOVE '2' TO VA2720B1O-IDENTIFICA. */
            _.Move("2", VA2720B1O_REG.VA2720B1O_IDENTIFICA);

            /*" -1419- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO WS-NUM-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WORK_AREA.WS_NUM_PROPOSTA);

            /*" -1420- IF WS-NUM-PROPOSTA(1:1) NOT EQUAL ZEROS */

            if (WORK_AREA.WS_NUM_PROPOSTA.Substring(1, 1) != 00)
            {

                /*" -1422- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO VA2720B1O-NUM-PROPOSTA-2 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_NUM_PROPOSTA_2);

                /*" -1424- MOVE PROPOVA-NUM-CERTIFICADO TO VA2720B1O-NUM-CERTIFICADO */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_NUM_CERTIFICADO);

                /*" -1425- ELSE */
            }
            else
            {


                /*" -1427- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA-9 */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_9);

                /*" -1429- MOVE 0 TO WS-NUM-PROPOSTA-0 */
                _.Move(0, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_0);

                /*" -1432- MOVE WS-NUM-PROPOSTA TO VA2720B1O-NUM-PROPOSTA-2 VA2720B1O-NUM-CERTIFICADO */
                _.Move(WORK_AREA.WS_NUM_PROPOSTA, VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_NUM_PROPOSTA_2);
                _.Move(WORK_AREA.WS_NUM_PROPOSTA, VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_NUM_CERTIFICADO);


                /*" -1434- END-IF. */
            }


            /*" -1435- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPROD(9310) */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.FILLER.JVPROD[9310].ToString()))
            {

                /*" -1437- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO VA2720B1O-NUM-PROPOSTA-2 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_NUM_PROPOSTA_2);

                /*" -1450- END-IF */
            }


            /*" -1452- MOVE ENDOSSOS-DATA-INIVIGENCIA (1:4) TO VA2720B1O-DATA-INICIO-VIG (5:4) */
            _.MoveAtPosition(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Substring(1, 4), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_INICIO_VIG, 5, 4);

            /*" -1454- MOVE ENDOSSOS-DATA-INIVIGENCIA (6:2) TO VA2720B1O-DATA-INICIO-VIG (3:2) */
            _.MoveAtPosition(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Substring(6, 2), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_INICIO_VIG, 3, 2);

            /*" -1457- MOVE ENDOSSOS-DATA-INIVIGENCIA (9:2) TO VA2720B1O-DATA-INICIO-VIG (1:2) */
            _.MoveAtPosition(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Substring(9, 2), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_INICIO_VIG, 1, 2);

            /*" -1459- MOVE ENDOSSOS-DATA-TERVIGENCIA (1:4) TO VA2720B1O-DATA-FINAL-VIG (5:4) */
            _.MoveAtPosition(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Substring(1, 4), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_FINAL_VIG, 5, 4);

            /*" -1461- MOVE ENDOSSOS-DATA-TERVIGENCIA (6:2) TO VA2720B1O-DATA-FINAL-VIG (3:2) */
            _.MoveAtPosition(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Substring(6, 2), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_FINAL_VIG, 3, 2);

            /*" -1464- MOVE ENDOSSOS-DATA-TERVIGENCIA (9:2) TO VA2720B1O-DATA-FINAL-VIG (1:2) */
            _.MoveAtPosition(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Substring(9, 2), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_FINAL_VIG, 1, 2);

            /*" -1465- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPROD(9310) */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.FILLER.JVPROD[9310].ToString()))
            {

                /*" -1467- MOVE PROPOVA-DATA-QUITACAO (1:4) TO VA2720B1O-DATA-INICIO-VIG (5:4) */
                _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(1, 4), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_INICIO_VIG, 5, 4);

                /*" -1469- MOVE PROPOVA-DATA-QUITACAO (6:2) TO VA2720B1O-DATA-INICIO-VIG (3:2) */
                _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(6, 2), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_INICIO_VIG, 3, 2);

                /*" -1472- MOVE PROPOVA-DATA-QUITACAO (9:2) TO VA2720B1O-DATA-INICIO-VIG (1:2) */
                _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(9, 2), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_INICIO_VIG, 1, 2);

                /*" -1473- IF TEM-CAN-EXCLUSIVO EQUAL 'S' */

                if (PARAMETROS.TEM_CAN_EXCLUSIVO == "S")
                {

                    /*" -1475- MOVE APOLICOB-DATA-TERVIGENCIA (1:4) TO VA2720B1O-DATA-FINAL-VIG (5:4) */
                    _.MoveAtPosition(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.Substring(1, 4), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_FINAL_VIG, 5, 4);

                    /*" -1477- MOVE APOLICOB-DATA-TERVIGENCIA (6:2) TO VA2720B1O-DATA-FINAL-VIG (3:2) */
                    _.MoveAtPosition(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.Substring(6, 2), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_FINAL_VIG, 3, 2);

                    /*" -1479- MOVE APOLICOB-DATA-TERVIGENCIA (9:2) TO VA2720B1O-DATA-FINAL-VIG (1:2) */
                    _.MoveAtPosition(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.Substring(9, 2), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_FINAL_VIG, 1, 2);

                    /*" -1480- END-IF */
                }


                /*" -1482- END-IF. */
            }


            /*" -1485- IF TEM-RENOVACAO EQUAL 'S' */

            if (PARAMETROS.TEM_RENOVACAO == "S")
            {

                /*" -1488- COMPUTE HISCOBPR-VLPREMIO = HISCONPA-PREMIO-VG + HISCONPA-PREMIO-AP */
                HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO.Value = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG + HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP;

                /*" -1490- END-IF. */
            }


            /*" -1493- MOVE HISCOBPR-VLPREMIO TO VA2720B1O-VALOR-PREMIO */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_VALOR_PREMIO);

            /*" -1494- IF MOVVGAP-COD-OPERACAO GREATER 399 AND LESS 500 */

            if (MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_OPERACAO > 399 && MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_OPERACAO < 500)
            {

                /*" -1496- MOVE MOVVGAP-DATA-OPERACAO (1:4) TO VA2720B1O-DATA-FINAL-VIG (5:4) */
                _.MoveAtPosition(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_OPERACAO.Substring(1, 4), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_FINAL_VIG, 5, 4);

                /*" -1498- MOVE MOVVGAP-DATA-OPERACAO (6:2) TO VA2720B1O-DATA-FINAL-VIG (3:2) */
                _.MoveAtPosition(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_OPERACAO.Substring(6, 2), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_FINAL_VIG, 3, 2);

                /*" -1500- MOVE MOVVGAP-DATA-OPERACAO (9:2) TO VA2720B1O-DATA-FINAL-VIG (1:2) */
                _.MoveAtPosition(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_OPERACAO.Substring(9, 2), VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_DATA_FINAL_VIG, 1, 2);

                /*" -1503- MOVE ZEROS TO VA2720B1O-VALOR-IOF VA2720B1O-VALOR-PREMIO */
                _.Move(0, VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_VALOR_IOF);
                _.Move(0, VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_VALOR_PREMIO);


                /*" -1504- ELSE */
            }
            else
            {


                /*" -1507- COMPUTE VA2720B1O-VALOR-IOF = HISCOBPR-VLPREMIO * RAMOCOMP-PCT-IOCC-RAMO / 100 */
                VA2720B1O_REG.VA2720B1O_REG_2.VA2720B1O_VALOR_IOF.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO * RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f;

                /*" -1509- END-IF. */
            }


            /*" -1512- WRITE REG-AVA2720B FROM VA2720B1O-REG. */
            _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

            AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

            /*" -1515- ADD 1 TO W-QTD-LD-TIPO-2 AC-GRAVADOS. */
            PARAMETROS.W_QTD_LD_TIPO_2.Value = PARAMETROS.W_QTD_LD_TIPO_2 + 1;
            PARAMETROS.AC_GRAVADOS.Value = PARAMETROS.AC_GRAVADOS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-GRAVA-TIPO-3-SECTION */
        private void R1210_00_GRAVA_TIPO_3_SECTION()
        {
            /*" -1530- MOVE 'R1210' TO WNR-EXEC-SQL. */
            _.Move("R1210", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1535- INITIALIZE VA2720B1O-REG-3 REPLACING ALPHANUMERIC BY SPACES NUMERIC BY ZEROES. */
            _.Initialize(
                VA2720B1O_REG.VA2720B1O_REG_3
            );

            /*" -1538- MOVE '3' TO VA2720B1O-IDENTIFICA. */
            _.Move("3", VA2720B1O_REG.VA2720B1O_IDENTIFICA);

            /*" -1541- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO WS-NUM-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WORK_AREA.WS_NUM_PROPOSTA);

            /*" -1542- IF WS-NUM-PROPOSTA(1:1) NOT EQUAL ZEROS */

            if (WORK_AREA.WS_NUM_PROPOSTA.Substring(1, 1) != 00)
            {

                /*" -1544- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO VA2720B1O-NUM-PROPOSTA-3 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_NUM_PROPOSTA_3);

                /*" -1545- ELSE */
            }
            else
            {


                /*" -1547- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA-9 */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_9);

                /*" -1549- MOVE 0 TO WS-NUM-PROPOSTA-0 */
                _.Move(0, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_0);

                /*" -1551- MOVE WS-NUM-PROPOSTA TO VA2720B1O-NUM-PROPOSTA-3 */
                _.Move(WORK_AREA.WS_NUM_PROPOSTA, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_NUM_PROPOSTA_3);

                /*" -1553- END-IF. */
            }


            /*" -1554- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPROD(9310) */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.FILLER.JVPROD[9310].ToString()))
            {

                /*" -1556- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO VA2720B1O-NUM-PROPOSTA-3 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_NUM_PROPOSTA_3);

                /*" -1558- END-IF */
            }


            /*" -1560- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPROD(9310) */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.FILLER.JVPROD[9310].ToString()))
            {

                /*" -1561- IF LK-COBT-MORTE-NATURAL GREATER ZEROS */

                if (PARAMETROS.LK_COBT_MORTE_NATURAL > 00)
                {

                    /*" -1562- MOVE LK-COBT-MORTE-NATURAL TO VA2720B1O-VALOR-COBERTURA */
                    _.Move(PARAMETROS.LK_COBT_MORTE_NATURAL, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_VALOR_COBERTURA);

                    /*" -1563- MOVE 661 TO VA2720B1O-COD-COBERTURA */
                    _.Move(661, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_COD_COBERTURA);

                    /*" -1564- WRITE REG-AVA2720B FROM VA2720B1O-REG */
                    _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

                    AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

                    /*" -1566- ADD 1 TO W-QTD-LD-TIPO-3 AC-GRAVADOS */
                    PARAMETROS.W_QTD_LD_TIPO_3.Value = PARAMETROS.W_QTD_LD_TIPO_3 + 1;
                    PARAMETROS.AC_GRAVADOS.Value = PARAMETROS.AC_GRAVADOS + 1;

                    /*" -1568- END-IF */
                }


                /*" -1569- MOVE APOLICOB-IMP-SEGURADA-IX TO VA2720B1O-VALOR-COBERTURA */
                _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_VALOR_COBERTURA);

                /*" -1570- MOVE 662 TO VA2720B1O-COD-COBERTURA */
                _.Move(662, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_COD_COBERTURA);

                /*" -1571- WRITE REG-AVA2720B FROM VA2720B1O-REG */
                _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

                AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

                /*" -1574- ADD 1 TO W-QTD-LD-TIPO-3 AC-GRAVADOS */
                PARAMETROS.W_QTD_LD_TIPO_3.Value = PARAMETROS.W_QTD_LD_TIPO_3 + 1;
                PARAMETROS.AC_GRAVADOS.Value = PARAMETROS.AC_GRAVADOS + 1;

                /*" -1575- IF LK-COBT-INV-PERMANENTE GREATER ZEROS */

                if (PARAMETROS.LK_COBT_INV_PERMANENTE > 00)
                {

                    /*" -1577- MOVE LK-COBT-INV-PERMANENTE TO VA2720B1O-VALOR-COBERTURA */
                    _.Move(PARAMETROS.LK_COBT_INV_PERMANENTE, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_VALOR_COBERTURA);

                    /*" -1578- MOVE 663 TO VA2720B1O-COD-COBERTURA */
                    _.Move(663, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_COD_COBERTURA);

                    /*" -1579- WRITE REG-AVA2720B FROM VA2720B1O-REG */
                    _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

                    AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

                    /*" -1581- ADD 1 TO W-QTD-LD-TIPO-3 AC-GRAVADOS */
                    PARAMETROS.W_QTD_LD_TIPO_3.Value = PARAMETROS.W_QTD_LD_TIPO_3 + 1;
                    PARAMETROS.AC_GRAVADOS.Value = PARAMETROS.AC_GRAVADOS + 1;

                    /*" -1583- END-IF */
                }


                /*" -1584- IF LK-COBT-INV-POR-ACIDENTE GREATER ZEROS */

                if (PARAMETROS.LK_COBT_INV_POR_ACIDENTE > 00)
                {

                    /*" -1586- MOVE LK-COBT-INV-POR-ACIDENTE TO VA2720B1O-VALOR-COBERTURA */
                    _.Move(PARAMETROS.LK_COBT_INV_POR_ACIDENTE, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_VALOR_COBERTURA);

                    /*" -1587- MOVE 664 TO VA2720B1O-COD-COBERTURA */
                    _.Move(664, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_COD_COBERTURA);

                    /*" -1588- WRITE REG-AVA2720B FROM VA2720B1O-REG */
                    _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

                    AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

                    /*" -1590- ADD 1 TO W-QTD-LD-TIPO-3 AC-GRAVADOS */
                    PARAMETROS.W_QTD_LD_TIPO_3.Value = PARAMETROS.W_QTD_LD_TIPO_3 + 1;
                    PARAMETROS.AC_GRAVADOS.Value = PARAMETROS.AC_GRAVADOS + 1;

                    /*" -1591- END-IF */
                }


                /*" -1593- ELSE */
            }
            else
            {


                /*" -1594- IF HISCOBPR-IMP-MORNATU GREATER ZEROS */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU > 00)
                {

                    /*" -1595- MOVE 12 TO VA2720B1O-COD-COBERTURA */
                    _.Move(12, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_COD_COBERTURA);

                    /*" -1596- MOVE HISCOBPR-IMP-MORNATU TO VA2720B1O-VALOR-COBERTURA */
                    _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_VALOR_COBERTURA);

                    /*" -1597- WRITE REG-AVA2720B FROM VA2720B1O-REG */
                    _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

                    AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

                    /*" -1599- ADD 1 TO W-QTD-LD-TIPO-3 AC-GRAVADOS */
                    PARAMETROS.W_QTD_LD_TIPO_3.Value = PARAMETROS.W_QTD_LD_TIPO_3 + 1;
                    PARAMETROS.AC_GRAVADOS.Value = PARAMETROS.AC_GRAVADOS + 1;

                    /*" -1601- END-IF */
                }


                /*" -1602- IF HISCOBPR-IMPMORACID GREATER ZEROS */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID > 00)
                {

                    /*" -1603- MOVE 13 TO VA2720B1O-COD-COBERTURA */
                    _.Move(13, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_COD_COBERTURA);

                    /*" -1604- MOVE HISCOBPR-IMPMORACID TO VA2720B1O-VALOR-COBERTURA */
                    _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_VALOR_COBERTURA);

                    /*" -1605- WRITE REG-AVA2720B FROM VA2720B1O-REG */
                    _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

                    AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

                    /*" -1607- ADD 1 TO W-QTD-LD-TIPO-3 AC-GRAVADOS */
                    PARAMETROS.W_QTD_LD_TIPO_3.Value = PARAMETROS.W_QTD_LD_TIPO_3 + 1;
                    PARAMETROS.AC_GRAVADOS.Value = PARAMETROS.AC_GRAVADOS + 1;

                    /*" -1609- END-IF */
                }


                /*" -1610- IF HISCOBPR-IMPINVPERM GREATER ZEROS */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM > 00)
                {

                    /*" -1611- MOVE 663 TO VA2720B1O-COD-COBERTURA */
                    _.Move(663, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_COD_COBERTURA);

                    /*" -1612- MOVE HISCOBPR-IMPINVPERM TO VA2720B1O-VALOR-COBERTURA */
                    _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_VALOR_COBERTURA);

                    /*" -1613- WRITE REG-AVA2720B FROM VA2720B1O-REG */
                    _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

                    AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

                    /*" -1615- ADD 1 TO W-QTD-LD-TIPO-3 AC-GRAVADOS */
                    PARAMETROS.W_QTD_LD_TIPO_3.Value = PARAMETROS.W_QTD_LD_TIPO_3 + 1;
                    PARAMETROS.AC_GRAVADOS.Value = PARAMETROS.AC_GRAVADOS + 1;

                    /*" -1617- END-IF */
                }


                /*" -1618- IF HISCOBPR-IMPAMDS GREATER ZEROS */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS > 00)
                {

                    /*" -1619- MOVE 11 TO VA2720B1O-COD-COBERTURA */
                    _.Move(11, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_COD_COBERTURA);

                    /*" -1620- MOVE HISCOBPR-IMPAMDS TO VA2720B1O-VALOR-COBERTURA */
                    _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_VALOR_COBERTURA);

                    /*" -1621- WRITE REG-AVA2720B FROM VA2720B1O-REG */
                    _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

                    AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

                    /*" -1623- ADD 1 TO W-QTD-LD-TIPO-3 AC-GRAVADOS */
                    PARAMETROS.W_QTD_LD_TIPO_3.Value = PARAMETROS.W_QTD_LD_TIPO_3 + 1;
                    PARAMETROS.AC_GRAVADOS.Value = PARAMETROS.AC_GRAVADOS + 1;

                    /*" -1625- END-IF */
                }


                /*" -1626- IF HISCOBPR-IMPDH GREATER ZEROS */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH > 00)
                {

                    /*" -1627- MOVE 591 TO VA2720B1O-COD-COBERTURA */
                    _.Move(591, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_COD_COBERTURA);

                    /*" -1628- MOVE HISCOBPR-IMPDH TO VA2720B1O-VALOR-COBERTURA */
                    _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_VALOR_COBERTURA);

                    /*" -1629- WRITE REG-AVA2720B FROM VA2720B1O-REG */
                    _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

                    AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

                    /*" -1631- ADD 1 TO W-QTD-LD-TIPO-1 AC-GRAVADOS */
                    PARAMETROS.W_QTD_LD_TIPO_1.Value = PARAMETROS.W_QTD_LD_TIPO_1 + 1;
                    PARAMETROS.AC_GRAVADOS.Value = PARAMETROS.AC_GRAVADOS + 1;

                    /*" -1633- END-IF */
                }


                /*" -1634- IF HISCOBPR-IMPDIT NOT EQUAL ZEROS */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT != 00)
                {

                    /*" -1635- MOVE 592 TO VA2720B1O-COD-COBERTURA */
                    _.Move(592, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_COD_COBERTURA);

                    /*" -1636- MOVE HISCOBPR-IMPDIT TO VA2720B1O-VALOR-COBERTURA */
                    _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT, VA2720B1O_REG.VA2720B1O_REG_3.VA2720B1O_VALOR_COBERTURA);

                    /*" -1637- WRITE REG-AVA2720B FROM VA2720B1O-REG */
                    _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

                    AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

                    /*" -1639- ADD 1 TO W-QTD-LD-TIPO-3 AC-GRAVADOS */
                    PARAMETROS.W_QTD_LD_TIPO_3.Value = PARAMETROS.W_QTD_LD_TIPO_3 + 1;
                    PARAMETROS.AC_GRAVADOS.Value = PARAMETROS.AC_GRAVADOS + 1;

                    /*" -1640- END-IF */
                }


                /*" -1640- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-PROPOFID-SECTION */
        private void R1300_00_SELECT_PROPOFID_SECTION()
        {
            /*" -1654- MOVE 'R1300' TO WNR-EXEC-SQL. */
            _.Move("R1300", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1679- PERFORM R1300_00_SELECT_PROPOFID_DB_SELECT_1 */

            R1300_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -1682- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1683- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1684- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPROD(9310) */

                    if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.FILLER.JVPROD[9310].ToString()))
                    {

                        /*" -1685- PERFORM R1310-00-SELECT-PROPOFID */

                        R1310_00_SELECT_PROPOFID_SECTION();

                        /*" -1686- END-IF */
                    }


                    /*" -1687- ELSE */
                }
                else
                {


                    /*" -1688- DISPLAY 'R1300-ERRO ACESSO PROPOSTA_FIDELIZ' */
                    _.Display($"R1300-ERRO ACESSO PROPOSTA_FIDELIZ");

                    /*" -1689- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1690- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                    /*" -1691- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1692- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1693- END-IF */
                }


                /*" -1693- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R1300_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -1679- EXEC SQL SELECT SIT_PROPOSTA, DATA_PROPOSTA, NUM_IDENTIFICACAO, COD_EMPRESA_SIVPF, COD_PRODUTO_SIVPF, CANAL_PROPOSTA , ORIGEM_PROPOSTA , SITUACAO_ENVIO , NUM_PROPOSTA_SIVPF INTO :PROPOFID-SIT-PROPOSTA, :PROPOFID-DATA-PROPOSTA, :PROPOFID-NUM-IDENTIFICACAO, :PROPOFID-COD-EMPRESA-SIVPF, :PROPOFID-COD-PRODUTO-SIVPF, :PROPOFID-CANAL-PROPOSTA , :PROPOFID-ORIGEM-PROPOSTA , :PROPOFID-SITUACAO-ENVIO , :PROPOFID-NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(executed_1.PROPOFID_SITUACAO_ENVIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1310-00-SELECT-PROPOFID-SECTION */
        private void R1310_00_SELECT_PROPOFID_SECTION()
        {
            /*" -1707- MOVE 'R1310' TO WNR-EXEC-SQL. */
            _.Move("R1310", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1731- PERFORM R1310_00_SELECT_PROPOFID_DB_SELECT_1 */

            R1310_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -1734- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1735- DISPLAY 'R1310-ERRO ACESSO PROPOSTA_FIDELIZ' */
                _.Display($"R1310-ERRO ACESSO PROPOSTA_FIDELIZ");

                /*" -1737- DISPLAY 'NUM_PROPOSTA_SIVPF = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_PROPOSTA_SIVPF = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1738- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -1739- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1740- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1742- END-IF. */
            }


            /*" -1743- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1744- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPROD(9310) */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.FILLER.JVPROD[9310].ToString()))
                {

                    /*" -1745- PERFORM R1315-00-SELECT-PROPOFID-ORIG */

                    R1315_00_SELECT_PROPOFID_ORIG_SECTION();

                    /*" -1746- END-IF */
                }


                /*" -1746- END-IF. */
            }


        }

        [StopWatch]
        /*" R1310-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R1310_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -1731- EXEC SQL SELECT SIT_PROPOSTA, DATA_PROPOSTA, NUM_IDENTIFICACAO, COD_EMPRESA_SIVPF, COD_PRODUTO_SIVPF, CANAL_PROPOSTA , ORIGEM_PROPOSTA , SITUACAO_ENVIO , NUM_PROPOSTA_SIVPF INTO :PROPOFID-SIT-PROPOSTA, :PROPOFID-DATA-PROPOSTA, :PROPOFID-NUM-IDENTIFICACAO, :PROPOFID-COD-EMPRESA-SIVPF, :PROPOFID-COD-PRODUTO-SIVPF, :PROPOFID-CANAL-PROPOSTA , :PROPOFID-ORIGEM-PROPOSTA , :PROPOFID-SITUACAO-ENVIO , :PROPOFID-NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r1310_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R1310_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1310_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r1310_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(executed_1.PROPOFID_SITUACAO_ENVIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1310_99_SAIDA*/

        [StopWatch]
        /*" R1315-00-SELECT-PROPOFID-ORIG-SECTION */
        private void R1315_00_SELECT_PROPOFID_ORIG_SECTION()
        {
            /*" -1760- MOVE 'R1315' TO WNR-EXEC-SQL. */
            _.Move("R1315", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1784- PERFORM R1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1 */

            R1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1();

            /*" -1787- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1788- DISPLAY 'R1315-ERRO ACESSO PROPOSTA_FIDELIZ' */
                _.Display($"R1315-ERRO ACESSO PROPOSTA_FIDELIZ");

                /*" -1789- DISPLAY 'NUM_PROPOSTA_SIVPF = ' PROPOVA-NRCERTIFANT */
                _.Display($"NUM_PROPOSTA_SIVPF = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NRCERTIFANT}");

                /*" -1791- DISPLAY 'NUM_CERTIFICADO    = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO    = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1792- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -1793- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1794- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1796- END-IF. */
            }


            /*" -1797- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1798- DISPLAY 'R1315-CERTIFICADO SEM PROPOSTA_FIDELIZ' */
                _.Display($"R1315-CERTIFICADO SEM PROPOSTA_FIDELIZ");

                /*" -1800- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1802- DISPLAY 'NRCERTIFANT = ' PROPOVA-NRCERTIFANT */
                _.Display($"NRCERTIFANT = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NRCERTIFANT}");

                /*" -1803- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -1804- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1805- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1805- END-IF. */
            }


        }

        [StopWatch]
        /*" R1315-00-SELECT-PROPOFID-ORIG-DB-SELECT-1 */
        public void R1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1()
        {
            /*" -1784- EXEC SQL SELECT SIT_PROPOSTA, DATA_PROPOSTA, NUM_IDENTIFICACAO, COD_EMPRESA_SIVPF, COD_PRODUTO_SIVPF, CANAL_PROPOSTA , ORIGEM_PROPOSTA , SITUACAO_ENVIO , NUM_PROPOSTA_SIVPF INTO :PROPOFID-SIT-PROPOSTA, :PROPOFID-DATA-PROPOSTA, :PROPOFID-NUM-IDENTIFICACAO, :PROPOFID-COD-EMPRESA-SIVPF, :PROPOFID-COD-PRODUTO-SIVPF, :PROPOFID-CANAL-PROPOSTA , :PROPOFID-ORIGEM-PROPOSTA , :PROPOFID-SITUACAO-ENVIO , :PROPOFID-NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NRCERTIFANT WITH UR END-EXEC. */

            var r1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1 = new R1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1()
            {
                PROPOVA_NRCERTIFANT = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NRCERTIFANT.ToString(),
            };

            var executed_1 = R1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1.Execute(r1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(executed_1.PROPOFID_SITUACAO_ENVIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1315_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-ENDOSSOS-SECTION */
        private void R1400_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -1819- MOVE 'R1400' TO WNR-EXEC-SQL. */
            _.Move("R1400", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1829- PERFORM R1400_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R1400_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -1833- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1834- DISPLAY 'R1400-ERRO ACESSO ENDOSSOS' */
                _.Display($"R1400-ERRO ACESSO ENDOSSOS");

                /*" -1835- DISPLAY 'NUM_CERTIFICADO: ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1836- DISPLAY 'NUM-APOLICE    : ' PROPOVA-NUM-APOLICE */
                _.Display($"NUM-APOLICE    : {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1837- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -1838- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1839- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1839- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R1400_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -1829- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :ENDOSSOS-DATA-INIVIGENCIA, :ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC. */

            var r1400_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R1400_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1401-00-SELECT-HISTCON-SECTION */
        private void R1401_00_SELECT_HISTCON_SECTION()
        {
            /*" -1853- MOVE 'R1401' TO WNR-EXEC-SQL. */
            _.Move("R1401", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1867- PERFORM R1401_00_SELECT_HISTCON_DB_SELECT_1 */

            R1401_00_SELECT_HISTCON_DB_SELECT_1();

            /*" -1872- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 AND SQLCODE NOT EQUAL -811 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100 && DB.SQLCODE != -811)
            {

                /*" -1873- DISPLAY 'R1401-ERRO ACESSO HIST_CONT_PARCELVA' */
                _.Display($"R1401-ERRO ACESSO HIST_CONT_PARCELVA");

                /*" -1874- DISPLAY 'CERTIFICADO: ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1875- DISPLAY 'PARCELA    : ' RELATORI-NUM-PARCELA */
                _.Display($"PARCELA    : {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                /*" -1876- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -1877- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1878- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1878- END-IF. */
            }


        }

        [StopWatch]
        /*" R1401-00-SELECT-HISTCON-DB-SELECT-1 */
        public void R1401_00_SELECT_HISTCON_DB_SELECT_1()
        {
            /*" -1867- EXEC SQL SELECT SIT_REGISTRO , PREMIO_VG , PREMIO_AP INTO :HISCONPA-SIT-REGISTRO ,:HISCONPA-PREMIO-VG ,:HISCONPA-PREMIO-AP FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA AND SIT_REGISTRO = '1' END-EXEC. */

            var r1401_00_SELECT_HISTCON_DB_SELECT_1_Query1 = new R1401_00_SELECT_HISTCON_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1401_00_SELECT_HISTCON_DB_SELECT_1_Query1.Execute(r1401_00_SELECT_HISTCON_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCONPA_SIT_REGISTRO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO);
                _.Move(executed_1.HISCONPA_PREMIO_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);
                _.Move(executed_1.HISCONPA_PREMIO_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1401_99_SAIDA*/

        [StopWatch]
        /*" R1405-00-OBTER-DADOS-SEGURADO-SECTION */
        private void R1405_00_OBTER_DADOS_SEGURADO_SECTION()
        {
            /*" -1891- MOVE 'R1405' TO WNR-EXEC-SQL. */
            _.Move("R1405", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1894- MOVE PROPOVA-NUM-CERTIFICADO TO SEGURVGA-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);

            /*" -1897- MOVE '1' TO SEGURVGA-TIPO-SEGURADO. */
            _.Move("1", SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO);

            /*" -1912- PERFORM R1405_00_OBTER_DADOS_SEGURADO_DB_SELECT_1 */

            R1405_00_OBTER_DADOS_SEGURADO_DB_SELECT_1();

            /*" -1916- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1917- DISPLAY 'R1405-ERRO ACESSO SEGURADOS_VGAP' */
                _.Display($"R1405-ERRO ACESSO SEGURADOS_VGAP");

                /*" -1918- DISPLAY 'CERTIFICADO   = ' SEGURVGA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO   = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO}");

                /*" -1919- DISPLAY 'TIPO SEGURADO = ' SEGURVGA-TIPO-SEGURADO */
                _.Display($"TIPO SEGURADO = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO}");

                /*" -1920- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -1921- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1922- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1922- END-IF. */
            }


        }

        [StopWatch]
        /*" R1405-00-OBTER-DADOS-SEGURADO-DB-SELECT-1 */
        public void R1405_00_OBTER_DADOS_SEGURADO_DB_SELECT_1()
        {
            /*" -1912- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_ITEM, OCORR_HISTORICO INTO :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO AND TIPO_SEGURADO = :SEGURVGA-TIPO-SEGURADO WITH UR END-EXEC. */

            var r1405_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1 = new R1405_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
                SEGURVGA_TIPO_SEGURADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO.ToString(),
            };

            var executed_1 = R1405_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1.Execute(r1405_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1405_SAIDA*/

        [StopWatch]
        /*" R1410-00-OBTER-VIGENCIA-SECTION */
        private void R1410_00_OBTER_VIGENCIA_SECTION()
        {
            /*" -1937- MOVE 'R1410' TO WNR-EXEC-SQL. */
            _.Move("R1410", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -1965- PERFORM R1410_00_OBTER_VIGENCIA_DB_SELECT_1 */

            R1410_00_OBTER_VIGENCIA_DB_SELECT_1();

            /*" -1968- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1969- DISPLAY 'R1410-ERRO ACESSO APOLICE_COBERTURAS' */
                _.Display($"R1410-ERRO ACESSO APOLICE_COBERTURAS");

                /*" -1970- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1971- DISPLAY 'APOLICE     = ' SEGURVGA-NUM-APOLICE */
                _.Display($"APOLICE     = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE}");

                /*" -1972- DISPLAY 'ITEM        = ' SEGURVGA-NUM-ITEM */
                _.Display($"ITEM        = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                /*" -1973- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -1974- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1975- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1975- END-IF. */
            }


        }

        [StopWatch]
        /*" R1410-00-OBTER-VIGENCIA-DB-SELECT-1 */
        public void R1410_00_OBTER_VIGENCIA_DB_SELECT_1()
        {
            /*" -1965- EXEC SQL SELECT NUM_APOLICE, NUM_ITEM, NUM_ENDOSSO, RAMO_COBERTURA, COD_COBERTURA, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IMP_SEGURADA_IX INTO :APOLICOB-NUM-APOLICE, :APOLICOB-NUM-ITEM, :APOLICOB-NUM-ENDOSSO, :APOLICOB-RAMO-COBERTURA, :APOLICOB-COD-COBERTURA, :APOLICOB-DATA-INIVIGENCIA, :APOLICOB-DATA-TERVIGENCIA, :APOLICOB-IMP-SEGURADA-IX FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = (SELECT MAX(OCORR_HISTORICO) FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM) FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1 = new R1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1.Execute(r1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_SAIDA*/

        [StopWatch]
        /*" R1415-00-OBTER-COBERTURAS-SECTION */
        private void R1415_00_OBTER_COBERTURAS_SECTION()
        {
            /*" -2034- MOVE 'R1415' TO WNR-EXEC-SQL. */
            _.Move("R1415", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -2035- MOVE PROPOVA-NUM-APOLICE TO LK-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, PARAMETROS.LK_APOLICE);

            /*" -2037- MOVE PROPOVA-COD-SUBGRUPO TO LK-SUBGRUPO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, PARAMETROS.LK_SUBGRUPO);

            /*" -2059- MOVE ZEROS TO LK-IDADE LK-DATA-NASCIMENTO LK-SALARIO LK-PURO-MORTE-NATURAL LK-PURO-MORTE-ACIDENTAL LK-PURO-INV-PERMANENTE LK-PURO-ASS-MEDICA LK-PURO-DIARIA-HOSPITALAR LK-PURO-DIARIA-INTERNACAO LK-COBT-MORTE-NATURAL LK-COBT-MORTE-ACIDENTAL LK-COBT-INV-PERMANENTE LK-COBT-INV-POR-ACIDENTE LK-COBT-ASS-MEDICA LK-COBT-DIARIA-HOSPITALAR LK-COBT-DIARIA-INTERNACAO LK-PREM-MORTE-NATURAL LK-PREM-ACIDENTES-PESSOAIS LK-PREM-TOTAL LK-RETURN-CODE LK-MENSAGEM. */
            _.Move(0, PARAMETROS.LK_IDADE, PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO, PARAMETROS.LK_SALARIO, PARAMETROS.LK_PURO_MORTE_NATURAL, PARAMETROS.LK_PURO_MORTE_ACIDENTAL, PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_PURO_ASS_MEDICA, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR, PARAMETROS.LK_PURO_DIARIA_INTERNACAO, PARAMETROS.LK_COBT_MORTE_NATURAL, PARAMETROS.LK_COBT_MORTE_ACIDENTAL, PARAMETROS.LK_COBT_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_POR_ACIDENTE, PARAMETROS.LK_COBT_ASS_MEDICA, PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, PARAMETROS.LK_COBT_DIARIA_INTERNACAO, PARAMETROS.LK_PREM_MORTE_NATURAL, PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS, PARAMETROS.LK_PREM_TOTAL, PARAMETROS.LK_RETURN_CODE, PARAMETROS.LK_MENSAGEM);

            /*" -2062- MOVE MOVVGAP-IMP-MORNATU-ATU TO LK-PURO-MORTE-NATURAL */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORNATU_ATU, PARAMETROS.LK_PURO_MORTE_NATURAL);

            /*" -2065- MOVE MOVVGAP-IMP-MORACID-ATU TO LK-PURO-MORTE-ACIDENTAL */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORACID_ATU, PARAMETROS.LK_PURO_MORTE_ACIDENTAL);

            /*" -2068- MOVE MOVVGAP-IMP-INVPERM-ATU TO LK-PURO-INV-PERMANENTE */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_INVPERM_ATU, PARAMETROS.LK_PURO_INV_PERMANENTE);

            /*" -2071- MOVE MOVVGAP-IMP-AMDS-ATU TO LK-PURO-ASS-MEDICA */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_AMDS_ATU, PARAMETROS.LK_PURO_ASS_MEDICA);

            /*" -2074- MOVE MOVVGAP-IMP-DH-ATU TO LK-PURO-DIARIA-HOSPITALAR */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DH_ATU, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR);

            /*" -2077- MOVE MOVVGAP-IMP-DIT-ATU TO LK-PURO-DIARIA-INTERNACAO. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DIT_ATU, PARAMETROS.LK_PURO_DIARIA_INTERNACAO);

            /*" -2078- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
            {

                /*" -2079- GO TO R1415-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1415_SAIDA*/ //GOTO
                return;

                /*" -2084- END-IF. */
            }


            /*" -2086- IF LK-PURO-MORTE-NATURAL EQUAL 0 AND LK-PURO-MORTE-ACIDENTAL EQUAL 0 */

            if (PARAMETROS.LK_PURO_MORTE_NATURAL == 0 && PARAMETROS.LK_PURO_MORTE_ACIDENTAL == 0)
            {

                /*" -2087- DISPLAY '----- VA2720B - CAPITAIS IGUAIS A ZERO -----' */
                _.Display($"----- VA2720B - CAPITAIS IGUAIS A ZERO -----");

                /*" -2095- DISPLAY '- EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"- EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -2096- DISPLAY '-  PROPOSTA : ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"-  PROPOSTA : {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2097- DISPLAY '--------------------------------------------' */
                _.Display($"--------------------------------------------");

                /*" -2098- GO TO R1415-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1415_SAIDA*/ //GOTO
                return;

                /*" -2100- END-IF. */
            }


            /*" -2102- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -2103- IF LK-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS.LK_RETURN_CODE != 00)
            {

                /*" -2104- DISPLAY 'R1415-ERRO ACESSO SUBROTINA VG0710S' */
                _.Display($"R1415-ERRO ACESSO SUBROTINA VG0710S");

                /*" -2105- DISPLAY 'MENSAGEM = ' LK-MENSAGEM */
                _.Display($"MENSAGEM = {PARAMETROS.LK_MENSAGEM}");

                /*" -2106- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2107- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1415_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-HISCOBPR-SECTION */
        private void R1500_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -2119- MOVE 'R1500' TO WNR-EXEC-SQL. */
            _.Move("R1500", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -2127- PERFORM R1500_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1500_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -2131- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2132- DISPLAY 'R1500-ERRO ACESSO HIS_COBER_PROPOST' */
                _.Display($"R1500-ERRO ACESSO HIS_COBER_PROPOST");

                /*" -2133- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2134- DISPLAY 'OCORRENCIA  = ' PROPOVA-OCORR-HISTORICO */
                _.Display($"OCORRENCIA  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}");

                /*" -2135- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -2136- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2137- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2137- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1500_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -2127- EXEC SQL SELECT VLPREMIO INTO :HISCOBPR-VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO END-EXEC. */

            var r1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-SELECT-HISCOBPR-SECTION */
        private void R1510_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -2151- MOVE 'R1510' TO WNR-EXEC-SQL. */
            _.Move("R1510", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -2169- PERFORM R1510_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1510_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -2173- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2174- DISPLAY 'R1510-ERRO ACESSO HIS_COBER_PROPOST' */
                _.Display($"R1510-ERRO ACESSO HIS_COBER_PROPOST");

                /*" -2175- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2176- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -2177- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2178- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2178- END-IF. */
            }


        }

        [StopWatch]
        /*" R1510-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1510_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -2169- EXEC SQL SELECT IMP_MORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT INTO :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPMORACID, :HISCOBPR-IMPINVPERM, :HISCOBPR-IMPAMDS, :HISCOBPR-IMPDH, :HISCOBPR-IMPDIT FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
                _.Move(executed_1.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);
                _.Move(executed_1.HISCOBPR_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);
                _.Move(executed_1.HISCOBPR_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);
                _.Move(executed_1.HISCOBPR_IMPDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-PARCEVID-SECTION */
        private void R1600_00_SELECT_PARCEVID_SECTION()
        {
            /*" -2192- MOVE 'R1600' TO WNR-EXEC-SQL. */
            _.Move("R1600", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -2195- MOVE ZEROS TO WHOST-COUNT */
            _.Move(0, WHOST_COUNT);

            /*" -2202- PERFORM R1600_00_SELECT_PARCEVID_DB_SELECT_1 */

            R1600_00_SELECT_PARCEVID_DB_SELECT_1();

            /*" -2206- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2207- DISPLAY 'R1600-ERRO ACESSO PARCELAS_VIDAZUL' */
                _.Display($"R1600-ERRO ACESSO PARCELAS_VIDAZUL");

                /*" -2208- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2209- DISPLAY 'VENCIMENTO  = ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"VENCIMENTO  = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -2210- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2211- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2211- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-PARCEVID-DB-SELECT-1 */
        public void R1600_00_SELECT_PARCEVID_DB_SELECT_1()
        {
            /*" -2202- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND SIT_REGISTRO IN ( ' ' , '0' ) AND DATA_VENCIMENTO < :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */

            var r1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1 = new R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-SELECT-RAMOCOMP-SECTION */
        private void R1700_00_SELECT_RAMOCOMP_SECTION()
        {
            /*" -2225- MOVE 'R1700' TO WNR-EXEC-SQL. */
            _.Move("R1700", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -2228- MOVE ZEROS TO WHOST-COUNT */
            _.Move(0, WHOST_COUNT);

            /*" -2235- PERFORM R1700_00_SELECT_RAMOCOMP_DB_SELECT_1 */

            R1700_00_SELECT_RAMOCOMP_DB_SELECT_1();

            /*" -2238- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2239- DISPLAY 'R1700-ERRO ACESSO RAMO_COMPLEMENTAR' */
                _.Display($"R1700-ERRO ACESSO RAMO_COMPLEMENTAR");

                /*" -2240- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2241- DISPLAY 'DT.VIGENCIA = ' PROPOFID-DATA-PROPOSTA */
                _.Display($"DT.VIGENCIA = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA}");

                /*" -2242- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2243- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2243- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-RAMOCOMP-DB-SELECT-1 */
        public void R1700_00_SELECT_RAMOCOMP_DB_SELECT_1()
        {
            /*" -2235- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = 93 AND DATA_INIVIGENCIA <= :PROPOFID-DATA-PROPOSTA AND DATA_TERVIGENCIA >= :PROPOFID-DATA-PROPOSTA END-EXEC. */

            var r1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1 = new R1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1()
            {
                PROPOFID_DATA_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.ToString(),
            };

            var executed_1 = R1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1.Execute(r1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-UPDATE-RELATORI-SECTION */
        private void R8000_00_UPDATE_RELATORI_SECTION()
        {
            /*" -2257- MOVE 'R8000' TO WNR-EXEC-SQL. */
            _.Move("R8000", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -2263- PERFORM R8000_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R8000_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -2266- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2267- DISPLAY 'R8000-ERRO UPDATE RELATORIOS' */
                _.Display($"R8000-ERRO UPDATE RELATORIOS");

                /*" -2268- DISPLAY 'IDE_SISTEMA = VA' */
                _.Display($"IDE_SISTEMA = VA");

                /*" -2269- DISPLAY 'COD_USUARIO = VA2720B' */
                _.Display($"COD_USUARIO = VA2720B");

                /*" -2270- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -2271- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2272- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2272- END-IF. */
            }


        }

        [StopWatch]
        /*" R8000-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R8000_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -2263- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO WHERE IDE_SISTEMA = 'VA' AND COD_USUARIO = 'VA2720B' END-EXEC. */

            var r8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 = new R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1.Execute(r8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8100-00-GRAVA-TRAILLER-SECTION */
        private void R8100_00_GRAVA_TRAILLER_SECTION()
        {
            /*" -2286- MOVE 'R8100' TO WNR-EXEC-SQL. */
            _.Move("R8100", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -2287- MOVE SPACES TO VA2720B1O-REG-T. */
            _.Move("", VA2720B1O_REG.VA2720B1O_REG_T);

            /*" -2297- MOVE ZEROS TO VA2720B1O-QTDE-REG-1 VA2720B1O-QTDE-REG-2 VA2720B1O-QTDE-REG-3 VA2720B1O-QTDE-REG-4 VA2720B1O-QTDE-REG-5 VA2720B1O-QTDE-REG-6 VA2720B1O-QTDE-REG-7 VA2720B1O-QTDE-REG-8 VA2720B1O-QTDE-REG-9 */
            _.Move(0, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_1);
            _.Move(0, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_2);
            _.Move(0, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_3);
            _.Move(0, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_4);
            _.Move(0, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_5);
            _.Move(0, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_6);
            _.Move(0, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_7);
            _.Move(0, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_8);
            _.Move(0, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_9);


            /*" -2300- MOVE 'T' TO VA2720B1O-IDENTIFICA */
            _.Move("T", VA2720B1O_REG.VA2720B1O_IDENTIFICA);

            /*" -2303- MOVE 'STASASSE' TO VA2720B1O-NOME-ARQ-T */
            _.Move("STASASSE", VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_NOME_ARQ_T);

            /*" -2306- MOVE W-QTD-LD-TIPO-1 TO VA2720B1O-QTDE-REG-1 */
            _.Move(PARAMETROS.W_QTD_LD_TIPO_1, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_1);

            /*" -2309- MOVE W-QTD-LD-TIPO-2 TO VA2720B1O-QTDE-REG-2 */
            _.Move(PARAMETROS.W_QTD_LD_TIPO_2, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_2);

            /*" -2312- MOVE W-QTD-LD-TIPO-3 TO VA2720B1O-QTDE-REG-3 */
            _.Move(PARAMETROS.W_QTD_LD_TIPO_3, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_3);

            /*" -2315- MOVE W-QTD-LD-TIPO-4 TO VA2720B1O-QTDE-REG-4 */
            _.Move(PARAMETROS.W_QTD_LD_TIPO_4, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_4);

            /*" -2318- MOVE W-QTD-LD-TIPO-5 TO VA2720B1O-QTDE-REG-5 */
            _.Move(PARAMETROS.W_QTD_LD_TIPO_5, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_5);

            /*" -2321- MOVE W-QTD-LD-TIPO-6 TO VA2720B1O-QTDE-REG-6 */
            _.Move(PARAMETROS.W_QTD_LD_TIPO_6, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_6);

            /*" -2324- MOVE W-QTD-LD-TIPO-7 TO VA2720B1O-QTDE-REG-7 */
            _.Move(PARAMETROS.W_QTD_LD_TIPO_7, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_7);

            /*" -2327- MOVE W-QTD-LD-TIPO-8 TO VA2720B1O-QTDE-REG-8 */
            _.Move(PARAMETROS.W_QTD_LD_TIPO_8, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_8);

            /*" -2330- MOVE W-QTD-LD-TIPO-9 TO VA2720B1O-QTDE-REG-9 */
            _.Move(PARAMETROS.W_QTD_LD_TIPO_9, VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_9);

            /*" -2340- COMPUTE VA2720B1O-QTDE-REG-TOTAL = VA2720B1O-QTDE-REG-1 + VA2720B1O-QTDE-REG-2 + VA2720B1O-QTDE-REG-3 + VA2720B1O-QTDE-REG-4 + VA2720B1O-QTDE-REG-5 + VA2720B1O-QTDE-REG-6 + VA2720B1O-QTDE-REG-7 + VA2720B1O-QTDE-REG-8 + VA2720B1O-QTDE-REG-9. */
            VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_TOTAL.Value = VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_1 + VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_2 + VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_3 + VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_4 + VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_5 + VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_6 + VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_7 + VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_8 + VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_9;

            /*" -2341- WRITE REG-AVA2720B FROM VA2720B1O-REG. */
            _.Move(VA2720B1O_REG.GetMoveValues(), REG_AVA2720B);

            AVA2720B.Write(REG_AVA2720B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -2355- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -2356- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2357- DISPLAY '*   VA2720B - GERA RELATORIO MULTPREMIADO  *' */
            _.Display($"*   VA2720B - GERA RELATORIO MULTPREMIADO  *");

            /*" -2358- DISPLAY '*   -------   -------------- ------------  *' */
            _.Display($"*   -------   -------------- ------------  *");

            /*" -2359- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2360- DISPLAY '*             NAO EXISTE PRODUCAO PARA     *' */
            _.Display($"*             NAO EXISTE PRODUCAO PARA     *");

            /*" -2361- DISPLAY '*             O PERIODO PEDIDO.            *' */
            _.Display($"*             O PERIODO PEDIDO.            *");

            /*" -2362- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2362- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -2373- CLOSE AVA2720B. */
            AVA2720B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_99_SAIDA*/

        [StopWatch]
        /*" R9989-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R9989_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -2399- MOVE 'R8100' TO WNR-EXEC-SQL. */
            _.Move("R8100", PARAMETROS.WABEND.WNR_EXEC_SQL);

            /*" -2402- MOVE VA2720B1O-QTDE-REG-TOTAL TO ARQSIVPF-QTDE-REG-GER */
            _.Move(VA2720B1O_REG.VA2720B1O_REG_T.VA2720B1O_QTDE_REG_TOTAL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -2406- PERFORM R9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1 */

            R9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1();

            /*" -2409- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2410- DISPLAY 'R9989-ERRO UPDATE ARQUIVOS_SIVPF' */
                _.Display($"R9989-ERRO UPDATE ARQUIVOS_SIVPF");

                /*" -2412- DISPLAY 'NSAS SIVPF = ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"NSAS SIVPF = {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -2413- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

                /*" -2414- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2414- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9989-00-CONTROLAR-ARQ-ENVIADO-DB-UPDATE-1 */
        public void R9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1()
        {
            /*" -2406- EXEC SQL UPDATE SEGUROS.ARQUIVOS_SIVPF SET QTDE_REG_GER = :ARQSIVPF-QTDE-REG-GER WHERE NSAS_SIVPF = :ARQSIVPF-NSAS-SIVPF END-EXEC. */

            var r9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1 = new R9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1()
            {
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
            };

            R9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1.Execute(r9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9989_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2429- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, PARAMETROS.WABEND.WSQLCODE);

            /*" -2431- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, PARAMETROS.WABEND.WSQLERRMC);

            /*" -2433- DISPLAY WABEND */
            _.Display(PARAMETROS.WABEND);

            /*" -2433- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -2434- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2438- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2438- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}