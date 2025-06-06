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
using Sias.VidaAzul.DB2.VA2721B;

namespace Code
{
    public class VA2721B
    {
        public bool IsCall { get; set; }

        public VA2721B()
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
        /*"      *   PROGRAMA ............... VA2721B                             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   CADMUS ................. 50.774                              *      */
        /*"      *   PROGRAMADOR ............ FAST COMPUTER - EDIVALDO GOMES      *      */
        /*"      *   DATA CODIFICACAO ....... MARCO / 2011                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO: GERA PROPOSTAS DE APOLICES ESPECIFICAS PARA O SIGPF  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11 - DEMANDA  425398                                  *      */
        /*"      *               AJUSTES PARA ENVIAR PROPOSTAS APOLICE ESPECIFICA *      */
        /*"      *               CAAAAPPNNNNNND                                   *      */
        /*"      *               C      = Canal (pode Ser: 1, 2, 3, 6, 7, 8 e 9)  *      */
        /*"      *               AAAA   = Agencia de venda da proposta            *      */
        /*"      *               PP     = Código Produto                          *      */
        /*"      *               NNNNNN = Número Sequencial da venda do produto   *      */
        /*"      *               D      = Digito Verificador calculo pelo Mod. 10 *      */
        /*"      *   EM SET/2022 - THIAGO BLAIER                                  *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 -  RETIRAR A V.08 E A V.07, POIS ESSAS INFORMACOES *      */
        /*"      *                SAO ENVIADAS PELO PF0720B.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/08/2018 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *   HISTORIA 169350                     PROCURE POR V.10         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 -  AJUSTE NO CURSOR PRA NAO BUSCAR POR COD_USUARIO *      */
        /*"      *                POIS PODEM HAVER REGISTROS EM QUE O COD_USUARIO *      */
        /*"      *                E DIFERENTE.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/08/2018 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *   HISTORIA 165916                     PROCURE POR V.09         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 -  ACERTO NO CURSOR PARA ENVIAR PAGAMENTO PAGO NA  *      */
        /*"      *                DIARIA                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/02/2018 - THIAGO BLAIER                                *      */
        /*"      *                                                                *      */
        /*"      *   HISTORIA 12506                      PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 -   ENVIAR PARA SIGPF PROPOSTAS COM CODIGO PRODUTO *      */
        /*"      *                 9310. PRODUTO SIGPF 06                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/12/2017 - THIAGO BLAIER                                *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 156890                       PROCURE POR V.07         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD  67.126                                      *      */
        /*"      *                                                                *      */
        /*"      *               - CORRECAO NO CURSOR QUE ESTA PERDENDO REGISTRO  *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/03/2012 - TERCIO CARVALHO (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD   60.298                                     *      */
        /*"      *                                                                *      */
        /*"      *                 ALTERA  O PROGRAMA PARA SENSIBILIZAR           *      */
        /*"      *                 DEMAIS PARCELAS.                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/08/2011 - BRUNO RIBEIRO  (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD  201.124                                     *      */
        /*"      *                                                                *      */
        /*"      *                 PASSA A GRAVAR REGISTRO TIPO 1 COM             *      */
        /*"      *                 O CODIGO 228 - ADESAO                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/07/2011 - LOPES          (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD  58.906                                      *      */
        /*"      *                                                                *      */
        /*"      *                 CODIGO DE MOVIMENTO:                           *      */
        /*"      *               - 251 ENDOSSO A DEBITO PARA 228 - ADESAO         *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/07/2011 - LOPES          (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD  57.276                                      *      */
        /*"      *                                                                *      */
        /*"      *               - CORRECAO NO CURSOR PRINCIPAL.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/06/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CAD 201.091                                      *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTE NO REGISTRO TRAILLER.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/06/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _AVA2721B { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis AVA2721B
        {
            get
            {
                _.Move(REG_AVA2721B, _AVA2721B); VarBasis.RedefinePassValue(REG_AVA2721B, _AVA2721B, REG_AVA2721B); return _AVA2721B;
            }
        }
        /*"01            REG-AVA2721B        PIC X(100).*/
        public StringBasis REG_AVA2721B { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    WHOST-OPERACAO            PIC  X(030)   VALUE SPACES.*/
        public StringBasis WHOST_OPERACAO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
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
        /*"77    WHOST-SITUACAO            PIC  X(01).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77    WS-SEQ                    PIC  9(006)   VALUE ZEROS.*/
        public IntBasis WS_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77    WS-QTD-REG1-PRP           PIC  9(006)   VALUE ZEROS.*/
        public IntBasis WS_QTD_REG1_PRP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77    WS-QTD-REG2-PRP           PIC  9(006)   VALUE ZEROS.*/
        public IntBasis WS_QTD_REG2_PRP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77    WS-QTD-REG3-PRP           PIC  9(006)   VALUE ZEROS.*/
        public IntBasis WS_QTD_REG3_PRP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"01     VA2721B1O-REG.*/
        public VA2721B_VA2721B1O_REG VA2721B1O_REG { get; set; } = new VA2721B_VA2721B1O_REG();
        public class VA2721B_VA2721B1O_REG : VarBasis
        {
            /*"    05   VA2721B1O-IDENTIFICA         PIC  X(0001).*/
            public StringBasis VA2721B1O_IDENTIFICA { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
            /*"    05   VA2721B1O-REG-H.*/
            public VA2721B_VA2721B1O_REG_H VA2721B1O_REG_H { get; set; } = new VA2721B_VA2721B1O_REG_H();
            public class VA2721B_VA2721B1O_REG_H : VarBasis
            {
                /*"      10 VA2721B1O-NOME-ARQ           PIC  X(0008).*/
                public StringBasis VA2721B1O_NOME_ARQ { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2721B1O-DATA-GER           PIC  X(0008).*/
                public StringBasis VA2721B1O_DATA_GER { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2721B1O-COD-SIST           PIC  9(0001).*/
                public IntBasis VA2721B1O_COD_SIST { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2721B1O-COD-SIST-DEST      PIC  9(0001).*/
                public IntBasis VA2721B1O_COD_SIST_DEST { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2721B1O-SEQ-ARQ            PIC  9(0006).*/
                public IntBasis VA2721B1O_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(0006)."));
                /*"      10 VA2721B1O-ESPACOS            PIC  X(0075).*/
                public StringBasis VA2721B1O_ESPACOS { get; set; } = new StringBasis(new PIC("X", "75", "X(0075)."), @"");
                /*"    05   VA2721B1O-REG-0   REDEFINES VA2721B1O-REG-H.*/
            }
            private _REDEF_VA2721B_VA2721B1O_REG_0 _va2721b1o_reg_0 { get; set; }
            public _REDEF_VA2721B_VA2721B1O_REG_0 VA2721B1O_REG_0
            {
                get { _va2721b1o_reg_0 = new _REDEF_VA2721B_VA2721B1O_REG_0(); _.Move(VA2721B1O_REG_H, _va2721b1o_reg_0); VarBasis.RedefinePassValue(VA2721B1O_REG_H, _va2721b1o_reg_0, VA2721B1O_REG_H); _va2721b1o_reg_0.ValueChanged += () => { _.Move(_va2721b1o_reg_0, VA2721B1O_REG_H); }; return _va2721b1o_reg_0; }
                set { VarBasis.RedefinePassValue(value, _va2721b1o_reg_0, VA2721B1O_REG_H); }
            }  //Redefines
            public class _REDEF_VA2721B_VA2721B1O_REG_0 : VarBasis
            {
                /*"      10 VA2721B1O-NUM-PROPOSTA-0     PIC  9(0014).*/
                public IntBasis VA2721B1O_NUM_PROPOSTA_0 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2721B1O-VALOR-ENDOSSO      PIC  9(0015)V99.*/
                public DoubleBasis VA2721B1O_VALOR_ENDOSSO { get; set; } = new DoubleBasis(new PIC("9", "15", "9(0015)V99."), 2);
                /*"      10 VA2721B1O-SINAL              PIC  X(0001).*/
                public StringBasis VA2721B1O_SINAL { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
                /*"      10 VA2721B1O-DATA-EMISSAO       PIC  9(0008).*/
                public IntBasis VA2721B1O_DATA_EMISSAO { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 FILLER                       PIC  X(0059).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "59", "X(0059)."), @"");
                /*"    05   VA2721B1O-REG-1   REDEFINES VA2721B1O-REG-0.*/

                public _REDEF_VA2721B_VA2721B1O_REG_0()
                {
                    VA2721B1O_NUM_PROPOSTA_0.ValueChanged += OnValueChanged;
                    VA2721B1O_VALOR_ENDOSSO.ValueChanged += OnValueChanged;
                    VA2721B1O_SINAL.ValueChanged += OnValueChanged;
                    VA2721B1O_DATA_EMISSAO.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2721B_VA2721B1O_REG_1 _va2721b1o_reg_1 { get; set; }
            public _REDEF_VA2721B_VA2721B1O_REG_1 VA2721B1O_REG_1
            {
                get { _va2721b1o_reg_1 = new _REDEF_VA2721B_VA2721B1O_REG_1(); _.Move(VA2721B1O_REG_0, _va2721b1o_reg_1); VarBasis.RedefinePassValue(VA2721B1O_REG_0, _va2721b1o_reg_1, VA2721B1O_REG_0); _va2721b1o_reg_1.ValueChanged += () => { _.Move(_va2721b1o_reg_1, VA2721B1O_REG_0); }; return _va2721b1o_reg_1; }
                set { VarBasis.RedefinePassValue(value, _va2721b1o_reg_1, VA2721B1O_REG_0); }
            }  //Redefines
            public class _REDEF_VA2721B_VA2721B1O_REG_1 : VarBasis
            {
                /*"      10 VA2721B1O-NUM-PROPOSTA-1     PIC  9(0014).*/
                public IntBasis VA2721B1O_NUM_PROPOSTA_1 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2721B1O-SIT-PROPOSTA       PIC  X(0003).*/
                public StringBasis VA2721B1O_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"      10 VA2721B1O-BRANCOS-0          PIC  X(0003).*/
                public StringBasis VA2721B1O_BRANCOS_0 { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"      10 VA2721B1O-TIPO-MOTIVO        PIC  9(0003).*/
                public IntBasis VA2721B1O_TIPO_MOTIVO { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 VA2721B1O-DATA-INICIO-SIT    PIC  9(0008).*/
                public IntBasis VA2721B1O_DATA_INICIO_SIT { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2721B1O-BRANCOS-1          PIC  X(0046).*/
                public StringBasis VA2721B1O_BRANCOS_1 { get; set; } = new StringBasis(new PIC("X", "46", "X(0046)."), @"");
                /*"      10 VA2721B1O-NUM-SEQ-ARQ        PIC  9(0006).*/
                public IntBasis VA2721B1O_NUM_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(0006)."));
                /*"      10 VA2721B1O-NUM-SEQ-REG        PIC  9(0006).*/
                public IntBasis VA2721B1O_NUM_SEQ_REG { get; set; } = new IntBasis(new PIC("9", "6", "9(0006)."));
                /*"      10 FILLER                       PIC  X(0010).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(0010)."), @"");
                /*"    05   VA2721B1O-REG-2   REDEFINES VA2721B1O-REG-1.*/

                public _REDEF_VA2721B_VA2721B1O_REG_1()
                {
                    VA2721B1O_NUM_PROPOSTA_1.ValueChanged += OnValueChanged;
                    VA2721B1O_SIT_PROPOSTA.ValueChanged += OnValueChanged;
                    VA2721B1O_BRANCOS_0.ValueChanged += OnValueChanged;
                    VA2721B1O_TIPO_MOTIVO.ValueChanged += OnValueChanged;
                    VA2721B1O_DATA_INICIO_SIT.ValueChanged += OnValueChanged;
                    VA2721B1O_BRANCOS_1.ValueChanged += OnValueChanged;
                    VA2721B1O_NUM_SEQ_ARQ.ValueChanged += OnValueChanged;
                    VA2721B1O_NUM_SEQ_REG.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2721B_VA2721B1O_REG_2 _va2721b1o_reg_2 { get; set; }
            public _REDEF_VA2721B_VA2721B1O_REG_2 VA2721B1O_REG_2
            {
                get { _va2721b1o_reg_2 = new _REDEF_VA2721B_VA2721B1O_REG_2(); _.Move(VA2721B1O_REG_1, _va2721b1o_reg_2); VarBasis.RedefinePassValue(VA2721B1O_REG_1, _va2721b1o_reg_2, VA2721B1O_REG_1); _va2721b1o_reg_2.ValueChanged += () => { _.Move(_va2721b1o_reg_2, VA2721B1O_REG_1); }; return _va2721b1o_reg_2; }
                set { VarBasis.RedefinePassValue(value, _va2721b1o_reg_2, VA2721B1O_REG_1); }
            }  //Redefines
            public class _REDEF_VA2721B_VA2721B1O_REG_2 : VarBasis
            {
                /*"      10 VA2721B1O-NUM-PROPOSTA-2     PIC  9(0014).*/
                public IntBasis VA2721B1O_NUM_PROPOSTA_2 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2721B1O-NUM-CERTIFICADO    PIC  9(0015).*/
                public IntBasis VA2721B1O_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(0015)."));
                /*"      10 VA2721B1O-DATA-INICIO-VIG    PIC  9(0008).*/
                public IntBasis VA2721B1O_DATA_INICIO_VIG { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2721B1O-DATA-FINAL-VIG     PIC  9(0008).*/
                public IntBasis VA2721B1O_DATA_FINAL_VIG { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2721B1O-VALOR-PREMIO       PIC  9(0013)V99.*/
                public DoubleBasis VA2721B1O_VALOR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(0013)V99."), 2);
                /*"      10 VA2721B1O-VALOR-IOF          PIC  9(0013)V99.*/
                public DoubleBasis VA2721B1O_VALOR_IOF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(0013)V99."), 2);
                /*"      10 FILLER                       PIC  X(0024).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "24", "X(0024)."), @"");
                /*"    05   VA2721B1O-REG-3   REDEFINES VA2721B1O-REG-2.*/

                public _REDEF_VA2721B_VA2721B1O_REG_2()
                {
                    VA2721B1O_NUM_PROPOSTA_2.ValueChanged += OnValueChanged;
                    VA2721B1O_NUM_CERTIFICADO.ValueChanged += OnValueChanged;
                    VA2721B1O_DATA_INICIO_VIG.ValueChanged += OnValueChanged;
                    VA2721B1O_DATA_FINAL_VIG.ValueChanged += OnValueChanged;
                    VA2721B1O_VALOR_PREMIO.ValueChanged += OnValueChanged;
                    VA2721B1O_VALOR_IOF.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2721B_VA2721B1O_REG_3 _va2721b1o_reg_3 { get; set; }
            public _REDEF_VA2721B_VA2721B1O_REG_3 VA2721B1O_REG_3
            {
                get { _va2721b1o_reg_3 = new _REDEF_VA2721B_VA2721B1O_REG_3(); _.Move(VA2721B1O_REG_2, _va2721b1o_reg_3); VarBasis.RedefinePassValue(VA2721B1O_REG_2, _va2721b1o_reg_3, VA2721B1O_REG_2); _va2721b1o_reg_3.ValueChanged += () => { _.Move(_va2721b1o_reg_3, VA2721B1O_REG_2); }; return _va2721b1o_reg_3; }
                set { VarBasis.RedefinePassValue(value, _va2721b1o_reg_3, VA2721B1O_REG_2); }
            }  //Redefines
            public class _REDEF_VA2721B_VA2721B1O_REG_3 : VarBasis
            {
                /*"      10 VA2721B1O-NUM-PROPOSTA-3     PIC  9(0014).*/
                public IntBasis VA2721B1O_NUM_PROPOSTA_3 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2721B1O-COD-COBERTURA      PIC  9(0004).*/
                public IntBasis VA2721B1O_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(0004)."));
                /*"      10 VA2721B1O-VALOR-COBERTURA    PIC  9(0013)V99.*/
                public DoubleBasis VA2721B1O_VALOR_COBERTURA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(0013)V99."), 2);
                /*"      10 FILLER                       PIC  X(0066).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "66", "X(0066)."), @"");
                /*"    05   VA2721B1O-REG-4   REDEFINES VA2721B1O-REG-3.*/

                public _REDEF_VA2721B_VA2721B1O_REG_3()
                {
                    VA2721B1O_NUM_PROPOSTA_3.ValueChanged += OnValueChanged;
                    VA2721B1O_COD_COBERTURA.ValueChanged += OnValueChanged;
                    VA2721B1O_VALOR_COBERTURA.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2721B_VA2721B1O_REG_4 _va2721b1o_reg_4 { get; set; }
            public _REDEF_VA2721B_VA2721B1O_REG_4 VA2721B1O_REG_4
            {
                get { _va2721b1o_reg_4 = new _REDEF_VA2721B_VA2721B1O_REG_4(); _.Move(VA2721B1O_REG_3, _va2721b1o_reg_4); VarBasis.RedefinePassValue(VA2721B1O_REG_3, _va2721b1o_reg_4, VA2721B1O_REG_3); _va2721b1o_reg_4.ValueChanged += () => { _.Move(_va2721b1o_reg_4, VA2721B1O_REG_3); }; return _va2721b1o_reg_4; }
                set { VarBasis.RedefinePassValue(value, _va2721b1o_reg_4, VA2721B1O_REG_3); }
            }  //Redefines
            public class _REDEF_VA2721B_VA2721B1O_REG_4 : VarBasis
            {
                /*"      10 VA2721B1O-NUM-PROPOSTA-4     PIC  9(0014).*/
                public IntBasis VA2721B1O_NUM_PROPOSTA_4 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2721B1O-SIT-COBRANCA       PIC  X(0003).*/
                public StringBasis VA2721B1O_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"      10 VA2721B1O-DT-INI-SITUACAO    PIC  X(0008).*/
                public StringBasis VA2721B1O_DT_INI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2721B1O-PARCELAS-PAGAS     PIC  9(0003).*/
                public IntBasis VA2721B1O_PARCELAS_PAGAS { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 VA2721B1O-TOTAL-PARCELAS     PIC  9(0003).*/
                public IntBasis VA2721B1O_TOTAL_PARCELAS { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 FILLER                       PIC  X(0068).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "68", "X(0068)."), @"");
                /*"    05   VA2721B1O-REG-T   REDEFINES VA2721B1O-REG-4.*/

                public _REDEF_VA2721B_VA2721B1O_REG_4()
                {
                    VA2721B1O_NUM_PROPOSTA_4.ValueChanged += OnValueChanged;
                    VA2721B1O_SIT_COBRANCA.ValueChanged += OnValueChanged;
                    VA2721B1O_DT_INI_SITUACAO.ValueChanged += OnValueChanged;
                    VA2721B1O_PARCELAS_PAGAS.ValueChanged += OnValueChanged;
                    VA2721B1O_TOTAL_PARCELAS.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2721B_VA2721B1O_REG_T _va2721b1o_reg_t { get; set; }
            public _REDEF_VA2721B_VA2721B1O_REG_T VA2721B1O_REG_T
            {
                get { _va2721b1o_reg_t = new _REDEF_VA2721B_VA2721B1O_REG_T(); _.Move(VA2721B1O_REG_4, _va2721b1o_reg_t); VarBasis.RedefinePassValue(VA2721B1O_REG_4, _va2721b1o_reg_t, VA2721B1O_REG_4); _va2721b1o_reg_t.ValueChanged += () => { _.Move(_va2721b1o_reg_t, VA2721B1O_REG_4); }; return _va2721b1o_reg_t; }
                set { VarBasis.RedefinePassValue(value, _va2721b1o_reg_t, VA2721B1O_REG_4); }
            }  //Redefines
            public class _REDEF_VA2721B_VA2721B1O_REG_T : VarBasis
            {
                /*"      10 VA2721B1O-NOME-ARQ-T         PIC  X(0008).*/
                public StringBasis VA2721B1O_NOME_ARQ_T { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2721B1O-QTDE-REG-1         PIC  9(0008).*/
                public IntBasis VA2721B1O_QTDE_REG_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2721B1O-QTDE-REG-2         PIC  9(0008).*/
                public IntBasis VA2721B1O_QTDE_REG_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2721B1O-QTDE-REG-3         PIC  9(0008).*/
                public IntBasis VA2721B1O_QTDE_REG_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2721B1O-QTDE-REG-4         PIC  9(0008).*/
                public IntBasis VA2721B1O_QTDE_REG_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2721B1O-QTDE-REG-5         PIC  9(0008).*/
                public IntBasis VA2721B1O_QTDE_REG_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2721B1O-QTDE-REG-6         PIC  9(0008).*/
                public IntBasis VA2721B1O_QTDE_REG_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2721B1O-QTDE-REG-7         PIC  9(0008).*/
                public IntBasis VA2721B1O_QTDE_REG_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2721B1O-QTDE-REG-8         PIC  9(0008).*/
                public IntBasis VA2721B1O_QTDE_REG_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2721B1O-QTDE-REG-9         PIC  9(0008).*/
                public IntBasis VA2721B1O_QTDE_REG_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 FILLER                       PIC  X(0008).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2721B1O-QTDE-REG-TOTAL     PIC  9(0008).*/
                public IntBasis VA2721B1O_QTDE_REG_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 FILLER                       PIC  X(0003).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"01  WORK-AREA.*/

                public _REDEF_VA2721B_VA2721B1O_REG_T()
                {
                    VA2721B1O_NOME_ARQ_T.ValueChanged += OnValueChanged;
                    VA2721B1O_QTDE_REG_1.ValueChanged += OnValueChanged;
                    VA2721B1O_QTDE_REG_2.ValueChanged += OnValueChanged;
                    VA2721B1O_QTDE_REG_3.ValueChanged += OnValueChanged;
                    VA2721B1O_QTDE_REG_4.ValueChanged += OnValueChanged;
                    VA2721B1O_QTDE_REG_5.ValueChanged += OnValueChanged;
                    VA2721B1O_QTDE_REG_6.ValueChanged += OnValueChanged;
                    VA2721B1O_QTDE_REG_7.ValueChanged += OnValueChanged;
                    VA2721B1O_QTDE_REG_8.ValueChanged += OnValueChanged;
                    VA2721B1O_QTDE_REG_9.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    VA2721B1O_QTDE_REG_TOTAL.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA2721B_WORK_AREA WORK_AREA { get; set; } = new VA2721B_WORK_AREA();
        public class VA2721B_WORK_AREA : VarBasis
        {
            /*"    05 WS-NUM-PROPOSTA          PIC 9(014).*/
            public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  WS-NUM-PROPOSTA-R         REDEFINES        WS-NUM-PROPOSTA.*/
            private _REDEF_VA2721B_WS_NUM_PROPOSTA_R _ws_num_proposta_r { get; set; }
            public _REDEF_VA2721B_WS_NUM_PROPOSTA_R WS_NUM_PROPOSTA_R
            {
                get { _ws_num_proposta_r = new _REDEF_VA2721B_WS_NUM_PROPOSTA_R(); _.Move(WS_NUM_PROPOSTA, _ws_num_proposta_r); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA, _ws_num_proposta_r, WS_NUM_PROPOSTA); _ws_num_proposta_r.ValueChanged += () => { _.Move(_ws_num_proposta_r, WS_NUM_PROPOSTA); }; return _ws_num_proposta_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_r, WS_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA2721B_WS_NUM_PROPOSTA_R : VarBasis
            {
                /*"        10  WS-NUM-PROPOSTA-9     PIC 9(013).*/
                public IntBasis WS_NUM_PROPOSTA_9 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        10  WS-NUM-PROPOSTA-0     PIC 9(001).*/
                public IntBasis WS_NUM_PROPOSTA_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  TAB-OPC-PGTO.*/

                public _REDEF_VA2721B_WS_NUM_PROPOSTA_R()
                {
                    WS_NUM_PROPOSTA_9.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_0.ValueChanged += OnValueChanged;
                }

            }
            public VA2721B_TAB_OPC_PGTO TAB_OPC_PGTO { get; set; } = new VA2721B_TAB_OPC_PGTO();
            public class VA2721B_TAB_OPC_PGTO : VarBasis
            {
                /*"        10  FILLER                PIC X(011) VALUE '1-DEB CONTA'*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"1-DEB CONTA");
                /*"        10  FILLER                PIC X(011) VALUE '2-POUPANCA '*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"2-POUPANCA ");
                /*"        10  FILLER                PIC X(011) VALUE '3-BOLETO   '*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"3-BOLETO   ");
                /*"        10  FILLER                PIC X(011) VALUE '4-AVERBACAO'*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"4-AVERBACAO");
                /*"        10  FILLER                PIC X(011) VALUE '5-CARTAO   '*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"5-CARTAO   ");
                /*"    05  TAB-OPC-PGTO-RED  REDEFINES  TAB-OPC-PGTO.*/
            }
            private _REDEF_VA2721B_TAB_OPC_PGTO_RED _tab_opc_pgto_red { get; set; }
            public _REDEF_VA2721B_TAB_OPC_PGTO_RED TAB_OPC_PGTO_RED
            {
                get { _tab_opc_pgto_red = new _REDEF_VA2721B_TAB_OPC_PGTO_RED(); _.Move(TAB_OPC_PGTO, _tab_opc_pgto_red); VarBasis.RedefinePassValue(TAB_OPC_PGTO, _tab_opc_pgto_red, TAB_OPC_PGTO); _tab_opc_pgto_red.ValueChanged += () => { _.Move(_tab_opc_pgto_red, TAB_OPC_PGTO); }; return _tab_opc_pgto_red; }
                set { VarBasis.RedefinePassValue(value, _tab_opc_pgto_red, TAB_OPC_PGTO); }
            }  //Redefines
            public class _REDEF_VA2721B_TAB_OPC_PGTO_RED : VarBasis
            {
                /*"      10  TB-OPC-PAGTO            PIC X(011)  OCCURS 5 TIMES.*/
                public ListBasis<StringBasis, string> TB_OPC_PAGTO { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "11", "X(011)"), 5);
                /*"    05        DATA-SQL.*/

                public _REDEF_VA2721B_TAB_OPC_PGTO_RED()
                {
                    TB_OPC_PAGTO.ValueChanged += OnValueChanged;
                }

            }
            public VA2721B_DATA_SQL DATA_SQL { get; set; } = new VA2721B_DATA_SQL();
            public class VA2721B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        DATA-CONV.*/
            }
            public VA2721B_DATA_CONV DATA_CONV { get; set; } = new VA2721B_DATA_CONV();
            public class VA2721B_DATA_CONV : VarBasis
            {
                /*"      10      DIA-CONV            PIC  9(002).*/
                public IntBasis DIA_CONV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-CONV            PIC  9(002).*/
                public IntBasis MES_CONV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
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
            /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-GRAVADOS         PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
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
            /*"    05        W-QTD-LD-TIPO-1     PIC  9(006) VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        W-QTD-LD-TIPO-8     PIC  9(006) VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WABEND.*/
            public VA2721B_WABEND WABEND { get; set; } = new VA2721B_WABEND();
            public class VA2721B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             ' VA2721B'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA2721B");
                /*"      10      FILLER              PIC  X(026) VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(006) VALUE '000000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"000000");
                /*"      10      FILLER              PIC  X(013) VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"      10      FILLER              PIC  X(014) VALUE             ' *** SQLERRMC '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"      10      WSQLERRMC           PIC  X(070)    VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01            WZEROS              PIC S9(005) VALUE +0 COMP-3.*/
            }
        }
        public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));


        public Copies.LBFPF025 LBFPF025 { get; set; } = new Copies.LBFPF025();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
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
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public VA2721B_TPROPOVA TPROPOVA { get; set; } = new VA2721B_TPROPOVA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string AVA2721B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                AVA2721B.SetFile(AVA2721B_FILE_NAME_P);

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
            /*" -413- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -416- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -419- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -421- PERFORM R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -429- MOVE 'R0000' TO WNR-EXEC-SQL. */
            _.Move("R0000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -430- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -431- DISPLAY 'PROGRAMA EM EXECUCAO VA2721B   ' */
            _.Display($"PROGRAMA EM EXECUCAO VA2721B   ");

            /*" -432- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -443- DISPLAY 'VERSAO V.10 169.350 28/08/2018 ' */
            _.Display($"VERSAO V.10 169.350 28/08/2018 ");

            /*" -444- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -446- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -448- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -450- OPEN OUTPUT AVA2721B. */
            AVA2721B.Open(REG_AVA2721B);

            /*" -452- PERFORM R0200-00-GRAVA-HEADER. */

            R0200_00_GRAVA_HEADER_SECTION();

            /*" -453- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -454- DISPLAY '*** PROBLEMAS NA SISTEMAS' */
                _.Display($"*** PROBLEMAS NA SISTEMAS");

                /*" -455- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -457- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -459- PERFORM R0900-00-DECLARE-PROPOVA. */

            R0900_00_DECLARE_PROPOVA_SECTION();

            /*" -461- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

            /*" -462- PERFORM R1000-00-PROCESSA UNTIL WFIM-PROPOVA EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_PROPOVA == "S"))
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
            /*" -468- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -470- PERFORM R8000-00-UPDATE-RELATORI */

            R8000_00_UPDATE_RELATORI_SECTION();

            /*" -472- PERFORM R8100-00-GRAVA-TRAILLER */

            R8100_00_GRAVA_TRAILLER_SECTION();

            /*" -472- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -477- DISPLAY '*** VA2721B - ' */
            _.Display($"*** VA2721B - ");

            /*" -478- DISPLAY 'LIDOS PROPOSTAS_VA       ' AC-LIDOS. */
            _.Display($"LIDOS PROPOSTAS_VA       {WORK_AREA.AC_LIDOS}");

            /*" -479- DISPLAY 'DESPREZADOS PRODUVG      ' AC-DESP-1 */
            _.Display($"DESPREZADOS PRODUVG      {WORK_AREA.AC_DESP_1}");

            /*" -480- DISPLAY 'DESPREZADOS CLIENTES     ' AC-DESP-2 */
            _.Display($"DESPREZADOS CLIENTES     {WORK_AREA.AC_DESP_2}");

            /*" -481- DISPLAY 'DESPREZADOS ENDERECO     ' AC-DESP-3 */
            _.Display($"DESPREZADOS ENDERECO     {WORK_AREA.AC_DESP_3}");

            /*" -482- DISPLAY 'DESPREZADOS OPCPAGVI     ' AC-DESP-4 */
            _.Display($"DESPREZADOS OPCPAGVI     {WORK_AREA.AC_DESP_4}");

            /*" -483- DISPLAY 'DESPREZADOS HISCOBPR     ' AC-DESP-5 */
            _.Display($"DESPREZADOS HISCOBPR     {WORK_AREA.AC_DESP_5}");

            /*" -484- DISPLAY 'DESPREZADOS PARCEVID-MEN ' AC-DESP-6 */
            _.Display($"DESPREZADOS PARCEVID-MEN {WORK_AREA.AC_DESP_6}");

            /*" -485- DISPLAY 'DESPREZADOS PARCEVID-ANU ' AC-DESP-7 */
            _.Display($"DESPREZADOS PARCEVID-ANU {WORK_AREA.AC_DESP_7}");

            /*" -486- DISPLAY 'DESPREZADOS PROPOFID     ' AC-DESP-8 */
            _.Display($"DESPREZADOS PROPOFID     {WORK_AREA.AC_DESP_8}");

            /*" -488- DISPLAY 'STATUS GERADOS           ' AC-GRAVADOS. */
            _.Display($"STATUS GERADOS           {WORK_AREA.AC_GRAVADOS}");

            /*" -490- DISPLAY '*** VA2721B - TERMINO NORMAL ***' */
            _.Display($"*** VA2721B - TERMINO NORMAL ***");

            /*" -490- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -504- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -509- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -512- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -513- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -514- DISPLAY 'VA2721B - TAB SISTEMAS = VA NAO ESTA CADASTRADO' */
                    _.Display($"VA2721B - TAB SISTEMAS = VA NAO ESTA CADASTRADO");

                    /*" -515- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", WORK_AREA.WFIM_V1SISTEMA);

                    /*" -516- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -517- ELSE */
                }
                else
                {


                    /*" -518- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                    /*" -519- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -520- END-IF */
                }


                /*" -522- END-IF. */
            }


            /*" -524- MOVE 'R0110' TO WNR-EXEC-SQL. */
            _.Move("R0110", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -530- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_2 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_2();

            /*" -533- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -534- DISPLAY 'VA2721B - PROBLEMAS NO ACESSO A TAB RELATORIOS' */
                _.Display($"VA2721B - PROBLEMAS NO ACESSO A TAB RELATORIOS");

                /*" -535- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                /*" -536- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -538- END-IF. */
            }


            /*" -539- DISPLAY ' ' */
            _.Display($" ");

            /*" -542- DISPLAY 'PERIODO DE ' RELATORI-DATA-SOLICITACAO ' ATE ' SISTEMAS-DATA-MOV-ABERTO. */

            $"PERIODO DE {RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO} ATE {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

            /*" -542- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -509- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-2 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_2()
        {
            /*" -530- EXEC SQL SELECT DATA_SOLICITACAO + 1 DAY INTO :RELATORI-DATA-SOLICITACAO FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'VA' AND COD_USUARIO = 'VA2721B' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
            }


        }

        [StopWatch]
        /*" R0200-00-GRAVA-HEADER-SECTION */
        private void R0200_00_GRAVA_HEADER_SECTION()
        {
            /*" -557- MOVE 'R0200' TO WNR-EXEC-SQL. */
            _.Move("R0200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -559- MOVE SPACES TO VA2721B1O-REG */
            _.Move("", VA2721B1O_REG);

            /*" -560- MOVE 'H' TO VA2721B1O-IDENTIFICA. */
            _.Move("H", VA2721B1O_REG.VA2721B1O_IDENTIFICA);

            /*" -562- MOVE 'STASASSE' TO VA2721B1O-NOME-ARQ. */
            _.Move("STASASSE", VA2721B1O_REG.VA2721B1O_REG_H.VA2721B1O_NOME_ARQ);

            /*" -564- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO VA2721B1O-DATA-GER (5:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), VA2721B1O_REG.VA2721B1O_REG_H.VA2721B1O_DATA_GER, 5, 4);

            /*" -566- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO VA2721B1O-DATA-GER (3:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), VA2721B1O_REG.VA2721B1O_REG_H.VA2721B1O_DATA_GER, 3, 2);

            /*" -569- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO VA2721B1O-DATA-GER (1:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), VA2721B1O_REG.VA2721B1O_REG_H.VA2721B1O_DATA_GER, 1, 2);

            /*" -570- MOVE 4 TO VA2721B1O-COD-SIST. */
            _.Move(4, VA2721B1O_REG.VA2721B1O_REG_H.VA2721B1O_COD_SIST);

            /*" -571- MOVE 1 TO VA2721B1O-COD-SIST-DEST. */
            _.Move(1, VA2721B1O_REG.VA2721B1O_REG_H.VA2721B1O_COD_SIST_DEST);

            /*" -573- MOVE ZEROS TO VA2721B1O-SEQ-ARQ. */
            _.Move(0, VA2721B1O_REG.VA2721B1O_REG_H.VA2721B1O_SEQ_ARQ);

            /*" -574- WRITE REG-AVA2721B FROM VA2721B1O-REG. */
            _.Move(VA2721B1O_REG.GetMoveValues(), REG_AVA2721B);

            AVA2721B.Write(REG_AVA2721B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-SECTION */
        private void R0900_00_DECLARE_PROPOVA_SECTION()
        {
            /*" -588- MOVE 'R0900' TO WNR-EXEC-SQL. */
            _.Move("R0900", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -656- PERFORM R0900_00_DECLARE_PROPOVA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOVA_DB_DECLARE_1();

            /*" -658- PERFORM R0900_00_DECLARE_PROPOVA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOVA_DB_OPEN_1();

            /*" -661- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -662- DISPLAY 'VA2721B - PROBLEMAS NO OPEN TPROPOVA' */
                _.Display($"VA2721B - PROBLEMAS NO OPEN TPROPOVA");

                /*" -663- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                /*" -664- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -664- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOVA_DB_DECLARE_1()
        {
            /*" -656- EXEC SQL DECLARE TPROPOVA CURSOR FOR SELECT A.NUM_APOLICE , A.COD_SUBGRUPO , A.NUM_CERTIFICADO , A.COD_PRODUTO , A.DATA_MOVIMENTO , C.PREMIO_VG + C.PREMIO_AP, C.NUM_PARCELA , C.SIT_REGISTRO, C.DATA_MOVIMENTO, C.NUM_PARCELA, C.COD_OPERACAO FROM SEGUROS.SUBGRUPOS_VGAP S, SEGUROS.PROPOSTAS_VA A, SEGUROS.PRODUTOS_VG B, SEGUROS.HIST_CONT_PARCELVA C WHERE S.SIT_REGISTRO = '0' AND A.NUM_APOLICE = S.NUM_APOLICE AND A.COD_SUBGRUPO = S.COD_SUBGRUPO AND A.DTPROXVEN <> '9999-12-31' AND B.NUM_APOLICE = S.NUM_APOLICE AND B.COD_SUBGRUPO = S.COD_SUBGRUPO AND B.ORIG_PRODU = 'ESPEC' AND C.SIT_REGISTRO IN ( '0' , '1' ) AND C.DATA_MOVIMENTO BETWEEN :RELATORI-DATA-SOLICITACAO AND :SISTEMAS-DATA-MOV-ABERTO AND C.COD_OPERACAO BETWEEN 200 AND 299 AND C.NUM_PARCELA > 1 AND C.NUM_CERTIFICADO = A.NUM_CERTIFICADO END-EXEC. */
            TPROPOVA = new VA2721B_TPROPOVA(true);
            string GetQuery_TPROPOVA()
            {
                var query = @$"SELECT 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.NUM_CERTIFICADO
							, 
							A.COD_PRODUTO
							, 
							A.DATA_MOVIMENTO
							, 
							C.PREMIO_VG + C.PREMIO_AP
							, 
							C.NUM_PARCELA
							, 
							C.SIT_REGISTRO
							, 
							C.DATA_MOVIMENTO
							, 
							C.NUM_PARCELA
							, 
							C.COD_OPERACAO 
							FROM 
							SEGUROS.SUBGRUPOS_VGAP S
							, 
							SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.PRODUTOS_VG B
							, 
							SEGUROS.HIST_CONT_PARCELVA C 
							WHERE S.SIT_REGISTRO = '0' 
							AND A.NUM_APOLICE = S.NUM_APOLICE 
							AND A.COD_SUBGRUPO = S.COD_SUBGRUPO 
							AND A.DTPROXVEN <> '9999-12-31' 
							AND B.NUM_APOLICE = S.NUM_APOLICE 
							AND B.COD_SUBGRUPO = S.COD_SUBGRUPO 
							AND B.ORIG_PRODU = 'ESPEC' 
							AND C.SIT_REGISTRO IN ( '0'
							, '1' ) 
							AND C.DATA_MOVIMENTO 
							BETWEEN '{RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO}' 
							AND '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND C.COD_OPERACAO BETWEEN 200 AND 299 
							AND C.NUM_PARCELA > 1 
							AND C.NUM_CERTIFICADO = A.NUM_CERTIFICADO";

                return query;
            }
            TPROPOVA.GetQueryEvent += GetQuery_TPROPOVA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOVA_DB_OPEN_1()
        {
            /*" -658- EXEC SQL OPEN TPROPOVA END-EXEC. */

            TPROPOVA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-SECTION */
        private void R0910_00_FETCH_PROPOVA_SECTION()
        {
            /*" -678- MOVE 'R0910' TO WNR-EXEC-SQL. */
            _.Move("R0910", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -692- PERFORM R0910_00_FETCH_PROPOVA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOVA_DB_FETCH_1();

            /*" -695- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -696- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -697- MOVE 'S' TO WFIM-PROPOVA */
                    _.Move("S", WORK_AREA.WFIM_PROPOVA);

                    /*" -697- PERFORM R0910_00_FETCH_PROPOVA_DB_CLOSE_1 */

                    R0910_00_FETCH_PROPOVA_DB_CLOSE_1();

                    /*" -699- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -700- ELSE */
                }
                else
                {


                    /*" -701- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                    /*" -702- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -703- END-IF */
                }


                /*" -705- END-IF. */
            }


            /*" -707- IF HISCONPA-SIT-REGISTRO EQUAL '0' OR '1' NEXT SENTENCE */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO.In("0", "1"))
            {

                /*" -708- ELSE */
            }
            else
            {


                /*" -709- GO TO R0910-00-FETCH-PROPOVA */
                new Task(() => R0910_00_FETCH_PROPOVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -711- END-IF. */
            }


            /*" -716- IF HISCONPA-DATA-MOVIMENTO NOT LESS RELATORI-DATA-SOLICITACAO AND HISCONPA-DATA-MOVIMENTO NOT GREATER SISTEMAS-DATA-MOV-ABERTO NEXT SENTENCE */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO >= RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO <= SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
            {

                /*" -717- ELSE */
            }
            else
            {


                /*" -718- GO TO R0910-00-FETCH-PROPOVA */
                new Task(() => R0910_00_FETCH_PROPOVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -720- END-IF. */
            }


            /*" -722- IF HISCONPA-NUM-PARCELA GREATER 1 NEXT SENTENCE */

            if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA > 1)
            {

                /*" -723- ELSE */
            }
            else
            {


                /*" -724- GO TO R0910-00-FETCH-PROPOVA */
                new Task(() => R0910_00_FETCH_PROPOVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -725- END-IF. */
            }


            /*" -725- ADD 1 TO AC-LIDOS. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -692- EXEC SQL FETCH TPROPOVA INTO :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO , :PROPOVA-NUM-CERTIFICADO , :PROPOVA-COD-PRODUTO , :PROPOVA-DATA-MOVIMENTO , :WHOST-VLPREMIO , :PROPOVA-NUM-PARCELA , :HISCONPA-SIT-REGISTRO , :HISCONPA-DATA-MOVIMENTO , :HISCONPA-NUM-PARCELA , :HISCONPA-COD-OPERACAO END-EXEC. */

            if (TPROPOVA.Fetch())
            {
                _.Move(TPROPOVA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(TPROPOVA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(TPROPOVA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(TPROPOVA.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(TPROPOVA.PROPOVA_DATA_MOVIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO);
                _.Move(TPROPOVA.WHOST_VLPREMIO, WHOST_VLPREMIO);
                _.Move(TPROPOVA.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(TPROPOVA.HISCONPA_SIT_REGISTRO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO);
                _.Move(TPROPOVA.HISCONPA_DATA_MOVIMENTO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO);
                _.Move(TPROPOVA.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(TPROPOVA.HISCONPA_COD_OPERACAO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -697- EXEC SQL CLOSE TPROPOVA END-EXEC */

            TPROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -739- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -741- PERFORM R1400-00-SELECT-PROPOFID */

            R1400_00_SELECT_PROPOFID_SECTION();

            /*" -742- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -743- ADD 1 TO AC-DESP-8 */
                WORK_AREA.AC_DESP_8.Value = WORK_AREA.AC_DESP_8 + 1;

                /*" -744- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -746- END-IF. */
            }


            /*" -748- PERFORM R1600-00-SELECT-PARCEVID */

            R1600_00_SELECT_PARCEVID_SECTION();

            /*" -749- IF WHOST-COUNT GREATER ZEROS */

            if (WHOST_COUNT > 00)
            {

                /*" -750- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 1 */

                if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 1)
                {

                    /*" -751- IF WHOST-COUNT GREATER 2 */

                    if (WHOST_COUNT > 2)
                    {

                        /*" -752- ADD 1 TO AC-DESP-6 */
                        WORK_AREA.AC_DESP_6.Value = WORK_AREA.AC_DESP_6 + 1;

                        /*" -753- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -754- ELSE */
                    }
                    else
                    {


                        /*" -755- ADD 1 TO AC-DESP-7 */
                        WORK_AREA.AC_DESP_7.Value = WORK_AREA.AC_DESP_7 + 1;

                        /*" -756- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -757- END-IF */
                    }


                    /*" -758- END-IF */
                }


                /*" -760- END-IF. */
            }


            /*" -761- IF WHOST-OPERACAO EQUAL 'EMISSAO' */

            if (WHOST_OPERACAO == "EMISSAO")
            {

                /*" -762- PERFORM R1500-00-SELECT-HISCOBPR */

                R1500_00_SELECT_HISCOBPR_SECTION();

                /*" -763- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -764- ADD 1 TO AC-DESP-1 */
                    WORK_AREA.AC_DESP_1.Value = WORK_AREA.AC_DESP_1 + 1;

                    /*" -765- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -766- END-IF */
                }


                /*" -768- MOVE HISCOBPR-VLPREMIO TO WHOST-VLPREMIO */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, WHOST_VLPREMIO);

                /*" -769- PERFORM R1200-00-GRAVA-TIPO-8 */

                R1200_00_GRAVA_TIPO_8_SECTION();

                /*" -770- ELSE */
            }
            else
            {


                /*" -771- PERFORM R1200-00-GRAVA-TIPO-8 */

                R1200_00_GRAVA_TIPO_8_SECTION();

                /*" -771- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -775- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GRAVA-TIPO-8-SECTION */
        private void R1200_00_GRAVA_TIPO_8_SECTION()
        {
            /*" -790- MOVE 'R1200' TO WNR-EXEC-SQL. */
            _.Move("R1200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -792- MOVE SPACES TO R8-PONTUACAO-SIDEM */
            _.Move("", LBFPF025.R8_PONTUACAO_SIDEM);

            /*" -797- MOVE 8 TO R8-IDENTIFICACAO */
            _.Move(8, LBFPF025.R8_PONTUACAO_SIDEM.R8_IDENTIFICACAO);

            /*" -800- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO WS-NUM-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WORK_AREA.WS_NUM_PROPOSTA);

            /*" -801- IF WS-NUM-PROPOSTA(1:1) NOT EQUAL ZEROS */

            if (WORK_AREA.WS_NUM_PROPOSTA.Substring(1, 1) != 00)
            {

                /*" -803- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R8-NUM-PROPOSTA */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PROPOSTA);

                /*" -804- ELSE */
            }
            else
            {


                /*" -806- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA-9 */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_9);

                /*" -808- MOVE 0 TO WS-NUM-PROPOSTA-0 */
                _.Move(0, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_0);

                /*" -810- MOVE WS-NUM-PROPOSTA TO R8-NUM-PROPOSTA */
                _.Move(WORK_AREA.WS_NUM_PROPOSTA, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PROPOSTA);

                /*" -829- END-IF. */
            }


            /*" -831- MOVE ZEROS TO R8-VLR-ESTOQUE. */
            _.Move(0, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_ESTOQUE);

            /*" -833- MOVE WHOST-VLPREMIO TO R8-VLR-LANCAMENTO */
            _.Move(WHOST_VLPREMIO, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO);

            /*" -835- MOVE PROPOVA-NUM-PARCELA TO R8-NUM-PARCELA */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PARCELA);

            /*" -837- IF WHOST-OPERACAO EQUAL 'EMISSAO' */

            if (WHOST_OPERACAO == "EMISSAO")
            {

                /*" -838- MOVE 228 TO R8-TP-LANCAMENTO */
                _.Move(228, LBFPF025.R8_PONTUACAO_SIDEM.R8_TP_LANCAMENTO);

                /*" -839- MOVE R8-NUM-PROPOSTA TO VA2721B1O-NUM-PROPOSTA-1 */
                _.Move(LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PROPOSTA, VA2721B1O_REG.VA2721B1O_REG_1.VA2721B1O_NUM_PROPOSTA_1);

                /*" -840- MOVE 'EMT' TO VA2721B1O-SIT-PROPOSTA */
                _.Move("EMT", VA2721B1O_REG.VA2721B1O_REG_1.VA2721B1O_SIT_PROPOSTA);

                /*" -841- MOVE SPACES TO VA2721B1O-BRANCOS-0 */
                _.Move("", VA2721B1O_REG.VA2721B1O_REG_1.VA2721B1O_BRANCOS_0);

                /*" -842- MOVE 228 TO VA2721B1O-TIPO-MOTIVO */
                _.Move(228, VA2721B1O_REG.VA2721B1O_REG_1.VA2721B1O_TIPO_MOTIVO);

                /*" -844- MOVE PROPOVA-DATA-MOVIMENTO (1:4) TO VA2721B1O-DATA-INICIO-SIT(5:4) */
                _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.Substring(1, 4), VA2721B1O_REG.VA2721B1O_REG_1.VA2721B1O_DATA_INICIO_SIT, 5, 4);

                /*" -846- MOVE PROPOVA-DATA-MOVIMENTO (6:2) TO VA2721B1O-DATA-INICIO-SIT(3:2) */
                _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.Substring(6, 2), VA2721B1O_REG.VA2721B1O_REG_1.VA2721B1O_DATA_INICIO_SIT, 3, 2);

                /*" -848- MOVE PROPOVA-DATA-MOVIMENTO (9:2) TO VA2721B1O-DATA-INICIO-SIT(1:2) */
                _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.Substring(9, 2), VA2721B1O_REG.VA2721B1O_REG_1.VA2721B1O_DATA_INICIO_SIT, 1, 2);

                /*" -849- MOVE SPACES TO VA2721B1O-BRANCOS-1 */
                _.Move("", VA2721B1O_REG.VA2721B1O_REG_1.VA2721B1O_BRANCOS_1);

                /*" -850- MOVE ZEROS TO VA2721B1O-NUM-SEQ-ARQ */
                _.Move(0, VA2721B1O_REG.VA2721B1O_REG_1.VA2721B1O_NUM_SEQ_ARQ);

                /*" -851- ADD 1 TO WS-SEQ */
                WS_SEQ.Value = WS_SEQ + 1;

                /*" -852- MOVE WS-SEQ TO VA2721B1O-NUM-SEQ-REG */
                _.Move(WS_SEQ, VA2721B1O_REG.VA2721B1O_REG_1.VA2721B1O_NUM_SEQ_REG);

                /*" -853- MOVE 1 TO VA2721B1O-IDENTIFICA */
                _.Move(1, VA2721B1O_REG.VA2721B1O_IDENTIFICA);

                /*" -856- WRITE REG-AVA2721B FROM VA2721B1O-REG */
                _.Move(VA2721B1O_REG.GetMoveValues(), REG_AVA2721B);

                AVA2721B.Write(REG_AVA2721B.GetMoveValues().ToString());

                /*" -859- ADD 1 TO W-QTD-LD-TIPO-1 AC-GRAVADOS */
                WORK_AREA.W_QTD_LD_TIPO_1.Value = WORK_AREA.W_QTD_LD_TIPO_1 + 1;
                WORK_AREA.AC_GRAVADOS.Value = WORK_AREA.AC_GRAVADOS + 1;

                /*" -861- ELSE */
            }
            else
            {


                /*" -863- IF HISCONPA-COD-OPERACAO NOT LESS 500 AND HISCONPA-COD-OPERACAO NOT GREATER 599 */

                if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO >= 500 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO <= 599)
                {

                    /*" -864- MOVE 242 TO R8-TP-LANCAMENTO */
                    _.Move(242, LBFPF025.R8_PONTUACAO_SIDEM.R8_TP_LANCAMENTO);

                    /*" -865- ELSE */
                }
                else
                {


                    /*" -867- IF HISCONPA-COD-OPERACAO NOT LESS 200 AND HISCONPA-COD-OPERACAO NOT GREATER 299 */

                    if (HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO >= 200 && HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO <= 299)
                    {

                        /*" -868- MOVE 235 TO R8-TP-LANCAMENTO */
                        _.Move(235, LBFPF025.R8_PONTUACAO_SIDEM.R8_TP_LANCAMENTO);

                        /*" -869- ELSE */
                    }
                    else
                    {


                        /*" -870- GO TO R1200-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                        return;

                        /*" -871- END-IF */
                    }


                    /*" -873- END-IF */
                }


                /*" -876- WRITE REG-AVA2721B FROM R8-PONTUACAO-SIDEM */
                _.Move(LBFPF025.R8_PONTUACAO_SIDEM.GetMoveValues(), REG_AVA2721B);

                AVA2721B.Write(REG_AVA2721B.GetMoveValues().ToString());

                /*" -878- ADD 1 TO W-QTD-LD-TIPO-8 AC-GRAVADOS. */
                WORK_AREA.W_QTD_LD_TIPO_8.Value = WORK_AREA.W_QTD_LD_TIPO_8 + 1;
                WORK_AREA.AC_GRAVADOS.Value = WORK_AREA.AC_GRAVADOS + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-PROPOFID-SECTION */
        private void R1400_00_SELECT_PROPOFID_SECTION()
        {
            /*" -892- MOVE 'R1400' TO WNR-EXEC-SQL. */
            _.Move("R1400", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -904- PERFORM R1400_00_SELECT_PROPOFID_DB_SELECT_1 */

            R1400_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -908- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -909- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -910- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                /*" -911- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -911- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R1400_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -904- EXEC SQL SELECT SIT_PROPOSTA, NUM_PROPOSTA_SIVPF INTO :PROPOFID-SIT-PROPOSTA, :PROPOFID-NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-HISCOBPR-SECTION */
        private void R1500_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -925- MOVE 'R1500' TO WNR-EXEC-SQL. */
            _.Move("R1500", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -933- PERFORM R1500_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1500_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -937- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -938- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -939- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                /*" -940- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -940- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1500_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -933- EXEC SQL SELECT VLPREMIO INTO :HISCOBPR-VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = 1 END-EXEC. */

            var r1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-PARCEVID-SECTION */
        private void R1600_00_SELECT_PARCEVID_SECTION()
        {
            /*" -955- MOVE 'R1600' TO WNR-EXEC-SQL. */
            _.Move("R1600", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -958- MOVE ZEROS TO WHOST-COUNT */
            _.Move(0, WHOST_COUNT);

            /*" -965- PERFORM R1600_00_SELECT_PARCEVID_DB_SELECT_1 */

            R1600_00_SELECT_PARCEVID_DB_SELECT_1();

            /*" -969- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -970- DISPLAY ' CERTIFICADO     = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($" CERTIFICADO     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -971- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -971- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-PARCEVID-DB-SELECT-1 */
        public void R1600_00_SELECT_PARCEVID_DB_SELECT_1()
        {
            /*" -965- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND SIT_REGISTRO IN ( ' ' , '0' ) AND DATA_VENCIMENTO < :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */

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
        /*" R8000-00-UPDATE-RELATORI-SECTION */
        private void R8000_00_UPDATE_RELATORI_SECTION()
        {
            /*" -985- MOVE 'R8000' TO WNR-EXEC-SQL. */
            _.Move("R8000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -990- PERFORM R8000_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R8000_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -993- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -994- DISPLAY 'IDE_SISTEMA   =  VA' */
                _.Display($"IDE_SISTEMA   =  VA");

                /*" -995- DISPLAY 'COD_USUARIO   =  VA2721B' */
                _.Display($"COD_USUARIO   =  VA2721B");

                /*" -996- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                /*" -997- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -997- END-IF. */
            }


        }

        [StopWatch]
        /*" R8000-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R8000_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -990- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO WHERE IDE_SISTEMA = 'VA' AND COD_USUARIO = 'VA2721B' END-EXEC. */

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
            /*" -1011- MOVE 'R8100' TO WNR-EXEC-SQL. */
            _.Move("R8100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1012- MOVE SPACES TO VA2721B1O-REG-T. */
            _.Move("", VA2721B1O_REG.VA2721B1O_REG_T);

            /*" -1022- MOVE ZEROS TO VA2721B1O-QTDE-REG-1 VA2721B1O-QTDE-REG-2 VA2721B1O-QTDE-REG-3 VA2721B1O-QTDE-REG-4 VA2721B1O-QTDE-REG-5 VA2721B1O-QTDE-REG-6 VA2721B1O-QTDE-REG-7 VA2721B1O-QTDE-REG-8 VA2721B1O-QTDE-REG-9 */
            _.Move(0, VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_1);
            _.Move(0, VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_2);
            _.Move(0, VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_3);
            _.Move(0, VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_4);
            _.Move(0, VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_5);
            _.Move(0, VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_6);
            _.Move(0, VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_7);
            _.Move(0, VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_8);
            _.Move(0, VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_9);


            /*" -1025- MOVE 'T' TO VA2721B1O-IDENTIFICA */
            _.Move("T", VA2721B1O_REG.VA2721B1O_IDENTIFICA);

            /*" -1028- MOVE 'STASASSE' TO VA2721B1O-NOME-ARQ-T */
            _.Move("STASASSE", VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_NOME_ARQ_T);

            /*" -1031- MOVE W-QTD-LD-TIPO-1 TO VA2721B1O-QTDE-REG-1 */
            _.Move(WORK_AREA.W_QTD_LD_TIPO_1, VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_1);

            /*" -1034- MOVE W-QTD-LD-TIPO-8 TO VA2721B1O-QTDE-REG-8 */
            _.Move(WORK_AREA.W_QTD_LD_TIPO_8, VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_8);

            /*" -1037- COMPUTE VA2721B1O-QTDE-REG-TOTAL = VA2721B1O-QTDE-REG-1 + VA2721B1O-QTDE-REG-8. */
            VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_TOTAL.Value = VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_1 + VA2721B1O_REG.VA2721B1O_REG_T.VA2721B1O_QTDE_REG_8;

            /*" -1038- WRITE REG-AVA2721B FROM VA2721B1O-REG. */
            _.Move(VA2721B1O_REG.GetMoveValues(), REG_AVA2721B);

            AVA2721B.Write(REG_AVA2721B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -1056- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1057- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1058- DISPLAY '*   VA2721B - GERA RELATORIO MULTPREMIADO  *' */
            _.Display($"*   VA2721B - GERA RELATORIO MULTPREMIADO  *");

            /*" -1059- DISPLAY '*   -------   -------------- ------------  *' */
            _.Display($"*   -------   -------------- ------------  *");

            /*" -1060- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1061- DISPLAY '*             NAO EXISTE PRODUCAO PARA     *' */
            _.Display($"*             NAO EXISTE PRODUCAO PARA     *");

            /*" -1062- DISPLAY '*             O PERIODO PEDIDO.            *' */
            _.Display($"*             O PERIODO PEDIDO.            *");

            /*" -1063- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1063- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1076- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -1078- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, WORK_AREA.WABEND.WSQLERRMC);

            /*" -1080- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -1080- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1081- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1085- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1085- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}