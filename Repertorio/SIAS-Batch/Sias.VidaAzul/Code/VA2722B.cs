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
using Sias.VidaAzul.DB2.VA2722B;

namespace Code
{
    public class VA2722B
    {
        public bool IsCall { get; set; }

        public VA2722B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *   FUNCAO: GERA ARQUIVO DE STATUS DE PROPOSTAS (STASASSE)              */
        /*"      *           APOLICES ESPECIFICAS / VIDA CONSTRUCAO                      */
        /*"      *           PARA OS CERTIFICADOS ENCONTRADOS NA RELATORIOS.             */
        /*"      *           VERSAO DO PROGRAMA VA2720T.                                 */
        /*"      *                                                                       */
        /*"      *   OBS.  : NAO SENSIBILIZA VALOR DE ADESAO                             */
        /*"      *           VA2722B1O-TIPO-MOTIVO = 000                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    HISTORICO DE MANUTENCOES                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 27/09/2023 - INCIDENTE 535669                                  *      */
        /*"      *              ABEND SQLCODE 100                                 *      */
        /*"      *                                                                *      */
        /*"      * RESPONSAVEL: HERVAL SOUZA                     MARCADOR: V.03   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 19/01/2022 - INCIDENTE 356753                                  *      */
        /*"      *              PROGRAMA EM LOOP APOS SELECT COM SQLCODE 100      *      */
        /*"      *                                                                *      */
        /*"      * RESPONSAVEL: ELIERMES OLIVEIRA                MARCADOR: V.02   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 04/03/2015 - CADMUS 111.976                                    *      */
        /*"      *              CORRIGIR ABEND PRODUCAO                           *      */
        /*"      *              PROGRAMA EM LOOP APOS SELECT COM SQLCODE 100      *      */
        /*"      *                                                                *      */
        /*"      * RESPONSAVEL: RIBAMAR MARQUES                  MARCADOR: V.01   *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _AVA2722B { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis AVA2722B
        {
            get
            {
                _.Move(REG_AVA2722B, _AVA2722B); VarBasis.RedefinePassValue(REG_AVA2722B, _AVA2722B, REG_AVA2722B); return _AVA2722B;
            }
        }
        /*"01            REG-AVA2722B        PIC X(100).*/
        public StringBasis REG_AVA2722B { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
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
        /*"77    WHOST-SITUACAO            PIC  X(01).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77    WS-QTD-REG1-PRP           PIC  9(006)   VALUE ZEROS.*/
        public IntBasis WS_QTD_REG1_PRP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77    WS-QTD-REG2-PRP           PIC  9(006)   VALUE ZEROS.*/
        public IntBasis WS_QTD_REG2_PRP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77    WS-QTD-REG3-PRP           PIC  9(006)   VALUE ZEROS.*/
        public IntBasis WS_QTD_REG3_PRP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77    WZEROS                    PIC S9(005)   VALUE +0 COMP-3.*/
        public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"77    WS-ERRO-PROCESSAMENTO     PIC  X(008)   VALUE SPACES.*/
        public StringBasis WS_ERRO_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01     VA2722B1O-REG.*/
        public VA2722B_VA2722B1O_REG VA2722B1O_REG { get; set; } = new VA2722B_VA2722B1O_REG();
        public class VA2722B_VA2722B1O_REG : VarBasis
        {
            /*"    05   VA2722B1O-IDENTIFICA         PIC  X(0001).*/
            public StringBasis VA2722B1O_IDENTIFICA { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
            /*"    05   VA2722B1O-REG-H.*/
            public VA2722B_VA2722B1O_REG_H VA2722B1O_REG_H { get; set; } = new VA2722B_VA2722B1O_REG_H();
            public class VA2722B_VA2722B1O_REG_H : VarBasis
            {
                /*"      10 VA2722B1O-NOME-ARQ           PIC  X(0008).*/
                public StringBasis VA2722B1O_NOME_ARQ { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2722B1O-DATA-GER           PIC  X(0008).*/
                public StringBasis VA2722B1O_DATA_GER { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2722B1O-COD-SIST           PIC  9(0001).*/
                public IntBasis VA2722B1O_COD_SIST { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2722B1O-COD-SIST-DEST      PIC  9(0001).*/
                public IntBasis VA2722B1O_COD_SIST_DEST { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2722B1O-SEQ-ARQ            PIC  9(0006).*/
                public IntBasis VA2722B1O_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(0006)."));
                /*"      10 VA2722B1O-ESPACOS            PIC  X(0075).*/
                public StringBasis VA2722B1O_ESPACOS { get; set; } = new StringBasis(new PIC("X", "75", "X(0075)."), @"");
                /*"    05   VA2722B1O-REG-0   REDEFINES VA2722B1O-REG-H.*/
            }
            private _REDEF_VA2722B_VA2722B1O_REG_0 _va2722b1o_reg_0 { get; set; }
            public _REDEF_VA2722B_VA2722B1O_REG_0 VA2722B1O_REG_0
            {
                get { _va2722b1o_reg_0 = new _REDEF_VA2722B_VA2722B1O_REG_0(); _.Move(VA2722B1O_REG_H, _va2722b1o_reg_0); VarBasis.RedefinePassValue(VA2722B1O_REG_H, _va2722b1o_reg_0, VA2722B1O_REG_H); _va2722b1o_reg_0.ValueChanged += () => { _.Move(_va2722b1o_reg_0, VA2722B1O_REG_H); }; return _va2722b1o_reg_0; }
                set { VarBasis.RedefinePassValue(value, _va2722b1o_reg_0, VA2722B1O_REG_H); }
            }  //Redefines
            public class _REDEF_VA2722B_VA2722B1O_REG_0 : VarBasis
            {
                /*"      10 VA2722B1O-NUM-PROPOSTA-0     PIC  9(0014).*/
                public IntBasis VA2722B1O_NUM_PROPOSTA_0 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2722B1O-VALOR-ENDOSSO      PIC  9(0015)V99.*/
                public DoubleBasis VA2722B1O_VALOR_ENDOSSO { get; set; } = new DoubleBasis(new PIC("9", "15", "9(0015)V99."), 2);
                /*"      10 VA2722B1O-SINAL              PIC  X(0001).*/
                public StringBasis VA2722B1O_SINAL { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
                /*"      10 VA2722B1O-DATA-EMISSAO       PIC  9(0008).*/
                public IntBasis VA2722B1O_DATA_EMISSAO { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 FILLER                       PIC  X(0059).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "59", "X(0059)."), @"");
                /*"    05   VA2722B1O-REG-1   REDEFINES VA2722B1O-REG-0.*/

                public _REDEF_VA2722B_VA2722B1O_REG_0()
                {
                    VA2722B1O_NUM_PROPOSTA_0.ValueChanged += OnValueChanged;
                    VA2722B1O_VALOR_ENDOSSO.ValueChanged += OnValueChanged;
                    VA2722B1O_SINAL.ValueChanged += OnValueChanged;
                    VA2722B1O_DATA_EMISSAO.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2722B_VA2722B1O_REG_1 _va2722b1o_reg_1 { get; set; }
            public _REDEF_VA2722B_VA2722B1O_REG_1 VA2722B1O_REG_1
            {
                get { _va2722b1o_reg_1 = new _REDEF_VA2722B_VA2722B1O_REG_1(); _.Move(VA2722B1O_REG_0, _va2722b1o_reg_1); VarBasis.RedefinePassValue(VA2722B1O_REG_0, _va2722b1o_reg_1, VA2722B1O_REG_0); _va2722b1o_reg_1.ValueChanged += () => { _.Move(_va2722b1o_reg_1, VA2722B1O_REG_0); }; return _va2722b1o_reg_1; }
                set { VarBasis.RedefinePassValue(value, _va2722b1o_reg_1, VA2722B1O_REG_0); }
            }  //Redefines
            public class _REDEF_VA2722B_VA2722B1O_REG_1 : VarBasis
            {
                /*"      10 VA2722B1O-NUM-PROPOSTA-1     PIC  9(0014).*/
                public IntBasis VA2722B1O_NUM_PROPOSTA_1 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2722B1O-SIT-PROPOSTA       PIC  X(0003).*/
                public StringBasis VA2722B1O_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"      10 VA2722B1O-BRANCOS-0          PIC  X(0003).*/
                public StringBasis VA2722B1O_BRANCOS_0 { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"      10 VA2722B1O-TIPO-MOTIVO        PIC  9(0003).*/
                public IntBasis VA2722B1O_TIPO_MOTIVO { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 VA2722B1O-DATA-INICIO-SIT    PIC  9(0008).*/
                public IntBasis VA2722B1O_DATA_INICIO_SIT { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2722B1O-BRANCOS-1          PIC  X(0046).*/
                public StringBasis VA2722B1O_BRANCOS_1 { get; set; } = new StringBasis(new PIC("X", "46", "X(0046)."), @"");
                /*"      10 VA2722B1O-NUM-SEQ-ARQ        PIC  9(0006).*/
                public IntBasis VA2722B1O_NUM_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(0006)."));
                /*"      10 VA2722B1O-NUM-SEQ-REG        PIC  9(0006).*/
                public IntBasis VA2722B1O_NUM_SEQ_REG { get; set; } = new IntBasis(new PIC("9", "6", "9(0006)."));
                /*"      10 FILLER                       PIC  X(0010).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(0010)."), @"");
                /*"    05   VA2722B1O-REG-2   REDEFINES VA2722B1O-REG-1.*/

                public _REDEF_VA2722B_VA2722B1O_REG_1()
                {
                    VA2722B1O_NUM_PROPOSTA_1.ValueChanged += OnValueChanged;
                    VA2722B1O_SIT_PROPOSTA.ValueChanged += OnValueChanged;
                    VA2722B1O_BRANCOS_0.ValueChanged += OnValueChanged;
                    VA2722B1O_TIPO_MOTIVO.ValueChanged += OnValueChanged;
                    VA2722B1O_DATA_INICIO_SIT.ValueChanged += OnValueChanged;
                    VA2722B1O_BRANCOS_1.ValueChanged += OnValueChanged;
                    VA2722B1O_NUM_SEQ_ARQ.ValueChanged += OnValueChanged;
                    VA2722B1O_NUM_SEQ_REG.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2722B_VA2722B1O_REG_2 _va2722b1o_reg_2 { get; set; }
            public _REDEF_VA2722B_VA2722B1O_REG_2 VA2722B1O_REG_2
            {
                get { _va2722b1o_reg_2 = new _REDEF_VA2722B_VA2722B1O_REG_2(); _.Move(VA2722B1O_REG_1, _va2722b1o_reg_2); VarBasis.RedefinePassValue(VA2722B1O_REG_1, _va2722b1o_reg_2, VA2722B1O_REG_1); _va2722b1o_reg_2.ValueChanged += () => { _.Move(_va2722b1o_reg_2, VA2722B1O_REG_1); }; return _va2722b1o_reg_2; }
                set { VarBasis.RedefinePassValue(value, _va2722b1o_reg_2, VA2722B1O_REG_1); }
            }  //Redefines
            public class _REDEF_VA2722B_VA2722B1O_REG_2 : VarBasis
            {
                /*"      10 VA2722B1O-NUM-PROPOSTA-2     PIC  9(0014).*/
                public IntBasis VA2722B1O_NUM_PROPOSTA_2 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2722B1O-NUM-CERTIFICADO    PIC  9(0015).*/
                public IntBasis VA2722B1O_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(0015)."));
                /*"      10 VA2722B1O-DATA-INICIO-VIG    PIC  9(0008).*/
                public IntBasis VA2722B1O_DATA_INICIO_VIG { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2722B1O-DATA-FINAL-VIG     PIC  9(0008).*/
                public IntBasis VA2722B1O_DATA_FINAL_VIG { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2722B1O-VALOR-PREMIO       PIC  9(0013)V99.*/
                public DoubleBasis VA2722B1O_VALOR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(0013)V99."), 2);
                /*"      10 VA2722B1O-VALOR-IOF          PIC  9(0013)V99.*/
                public DoubleBasis VA2722B1O_VALOR_IOF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(0013)V99."), 2);
                /*"      10 FILLER                       PIC  X(0024).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "24", "X(0024)."), @"");
                /*"    05   VA2722B1O-REG-3   REDEFINES VA2722B1O-REG-2.*/

                public _REDEF_VA2722B_VA2722B1O_REG_2()
                {
                    VA2722B1O_NUM_PROPOSTA_2.ValueChanged += OnValueChanged;
                    VA2722B1O_NUM_CERTIFICADO.ValueChanged += OnValueChanged;
                    VA2722B1O_DATA_INICIO_VIG.ValueChanged += OnValueChanged;
                    VA2722B1O_DATA_FINAL_VIG.ValueChanged += OnValueChanged;
                    VA2722B1O_VALOR_PREMIO.ValueChanged += OnValueChanged;
                    VA2722B1O_VALOR_IOF.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2722B_VA2722B1O_REG_3 _va2722b1o_reg_3 { get; set; }
            public _REDEF_VA2722B_VA2722B1O_REG_3 VA2722B1O_REG_3
            {
                get { _va2722b1o_reg_3 = new _REDEF_VA2722B_VA2722B1O_REG_3(); _.Move(VA2722B1O_REG_2, _va2722b1o_reg_3); VarBasis.RedefinePassValue(VA2722B1O_REG_2, _va2722b1o_reg_3, VA2722B1O_REG_2); _va2722b1o_reg_3.ValueChanged += () => { _.Move(_va2722b1o_reg_3, VA2722B1O_REG_2); }; return _va2722b1o_reg_3; }
                set { VarBasis.RedefinePassValue(value, _va2722b1o_reg_3, VA2722B1O_REG_2); }
            }  //Redefines
            public class _REDEF_VA2722B_VA2722B1O_REG_3 : VarBasis
            {
                /*"      10 VA2722B1O-NUM-PROPOSTA-3     PIC  9(0014).*/
                public IntBasis VA2722B1O_NUM_PROPOSTA_3 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2722B1O-COD-COBERTURA      PIC  9(0004).*/
                public IntBasis VA2722B1O_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(0004)."));
                /*"      10 VA2722B1O-VALOR-COBERTURA    PIC  9(0013)V99.*/
                public DoubleBasis VA2722B1O_VALOR_COBERTURA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(0013)V99."), 2);
                /*"      10 FILLER                       PIC  X(0066).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "66", "X(0066)."), @"");
                /*"    05   VA2722B1O-REG-4   REDEFINES VA2722B1O-REG-3.*/

                public _REDEF_VA2722B_VA2722B1O_REG_3()
                {
                    VA2722B1O_NUM_PROPOSTA_3.ValueChanged += OnValueChanged;
                    VA2722B1O_COD_COBERTURA.ValueChanged += OnValueChanged;
                    VA2722B1O_VALOR_COBERTURA.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2722B_VA2722B1O_REG_4 _va2722b1o_reg_4 { get; set; }
            public _REDEF_VA2722B_VA2722B1O_REG_4 VA2722B1O_REG_4
            {
                get { _va2722b1o_reg_4 = new _REDEF_VA2722B_VA2722B1O_REG_4(); _.Move(VA2722B1O_REG_3, _va2722b1o_reg_4); VarBasis.RedefinePassValue(VA2722B1O_REG_3, _va2722b1o_reg_4, VA2722B1O_REG_3); _va2722b1o_reg_4.ValueChanged += () => { _.Move(_va2722b1o_reg_4, VA2722B1O_REG_3); }; return _va2722b1o_reg_4; }
                set { VarBasis.RedefinePassValue(value, _va2722b1o_reg_4, VA2722B1O_REG_3); }
            }  //Redefines
            public class _REDEF_VA2722B_VA2722B1O_REG_4 : VarBasis
            {
                /*"      10 VA2722B1O-NUM-PROPOSTA-4     PIC  9(0014).*/
                public IntBasis VA2722B1O_NUM_PROPOSTA_4 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2722B1O-SIT-COBRANCA       PIC  X(0003).*/
                public StringBasis VA2722B1O_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"      10 VA2722B1O-DT-INI-SITUACAO    PIC  X(0008).*/
                public StringBasis VA2722B1O_DT_INI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2722B1O-PARCELAS-PAGAS     PIC  9(0003).*/
                public IntBasis VA2722B1O_PARCELAS_PAGAS { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 VA2722B1O-TOTAL-PARCELAS     PIC  9(0003).*/
                public IntBasis VA2722B1O_TOTAL_PARCELAS { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 FILLER                       PIC  X(0068).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "68", "X(0068)."), @"");
                /*"    05   VA2722B1O-REG-T   REDEFINES VA2722B1O-REG-4.*/

                public _REDEF_VA2722B_VA2722B1O_REG_4()
                {
                    VA2722B1O_NUM_PROPOSTA_4.ValueChanged += OnValueChanged;
                    VA2722B1O_SIT_COBRANCA.ValueChanged += OnValueChanged;
                    VA2722B1O_DT_INI_SITUACAO.ValueChanged += OnValueChanged;
                    VA2722B1O_PARCELAS_PAGAS.ValueChanged += OnValueChanged;
                    VA2722B1O_TOTAL_PARCELAS.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2722B_VA2722B1O_REG_T _va2722b1o_reg_t { get; set; }
            public _REDEF_VA2722B_VA2722B1O_REG_T VA2722B1O_REG_T
            {
                get { _va2722b1o_reg_t = new _REDEF_VA2722B_VA2722B1O_REG_T(); _.Move(VA2722B1O_REG_4, _va2722b1o_reg_t); VarBasis.RedefinePassValue(VA2722B1O_REG_4, _va2722b1o_reg_t, VA2722B1O_REG_4); _va2722b1o_reg_t.ValueChanged += () => { _.Move(_va2722b1o_reg_t, VA2722B1O_REG_4); }; return _va2722b1o_reg_t; }
                set { VarBasis.RedefinePassValue(value, _va2722b1o_reg_t, VA2722B1O_REG_4); }
            }  //Redefines
            public class _REDEF_VA2722B_VA2722B1O_REG_T : VarBasis
            {
                /*"      10 VA2722B1O-NOME-ARQ-T         PIC  X(0008).*/
                public StringBasis VA2722B1O_NOME_ARQ_T { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2722B1O-QTDE-REG-1         PIC  9(0008).*/
                public IntBasis VA2722B1O_QTDE_REG_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2722B1O-QTDE-REG-2         PIC  9(0008).*/
                public IntBasis VA2722B1O_QTDE_REG_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2722B1O-QTDE-REG-3         PIC  9(0008).*/
                public IntBasis VA2722B1O_QTDE_REG_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2722B1O-QTDE-REG-4         PIC  9(0008).*/
                public IntBasis VA2722B1O_QTDE_REG_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2722B1O-QTDE-REG-5         PIC  9(0008).*/
                public IntBasis VA2722B1O_QTDE_REG_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2722B1O-QTDE-REG-6         PIC  9(0008).*/
                public IntBasis VA2722B1O_QTDE_REG_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2722B1O-QTDE-REG-7         PIC  9(0008).*/
                public IntBasis VA2722B1O_QTDE_REG_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2722B1O-QTDE-REG-8         PIC  9(0008).*/
                public IntBasis VA2722B1O_QTDE_REG_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2722B1O-QTDE-REG-9         PIC  9(0008).*/
                public IntBasis VA2722B1O_QTDE_REG_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 FILLER                       PIC  X(0008).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2722B1O-QTDE-REG-TOTAL     PIC  9(0008).*/
                public IntBasis VA2722B1O_QTDE_REG_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 FILLER                       PIC  X(0003).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"01  WORK-AREA.*/

                public _REDEF_VA2722B_VA2722B1O_REG_T()
                {
                    VA2722B1O_NOME_ARQ_T.ValueChanged += OnValueChanged;
                    VA2722B1O_QTDE_REG_1.ValueChanged += OnValueChanged;
                    VA2722B1O_QTDE_REG_2.ValueChanged += OnValueChanged;
                    VA2722B1O_QTDE_REG_3.ValueChanged += OnValueChanged;
                    VA2722B1O_QTDE_REG_4.ValueChanged += OnValueChanged;
                    VA2722B1O_QTDE_REG_5.ValueChanged += OnValueChanged;
                    VA2722B1O_QTDE_REG_6.ValueChanged += OnValueChanged;
                    VA2722B1O_QTDE_REG_7.ValueChanged += OnValueChanged;
                    VA2722B1O_QTDE_REG_8.ValueChanged += OnValueChanged;
                    VA2722B1O_QTDE_REG_9.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    VA2722B1O_QTDE_REG_TOTAL.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA2722B_WORK_AREA WORK_AREA { get; set; } = new VA2722B_WORK_AREA();
        public class VA2722B_WORK_AREA : VarBasis
        {
            /*"    05  W-NSAS                    PIC 9(006) VALUE ZEROS.*/
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-NSL                     PIC 9(006) VALUE ZEROS.*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  WS-NUM-PROPOSTA           PIC 9(014).*/
            public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  WS-NUM-PROPOSTA-R         REDEFINES        WS-NUM-PROPOSTA.*/
            private _REDEF_VA2722B_WS_NUM_PROPOSTA_R _ws_num_proposta_r { get; set; }
            public _REDEF_VA2722B_WS_NUM_PROPOSTA_R WS_NUM_PROPOSTA_R
            {
                get { _ws_num_proposta_r = new _REDEF_VA2722B_WS_NUM_PROPOSTA_R(); _.Move(WS_NUM_PROPOSTA, _ws_num_proposta_r); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA, _ws_num_proposta_r, WS_NUM_PROPOSTA); _ws_num_proposta_r.ValueChanged += () => { _.Move(_ws_num_proposta_r, WS_NUM_PROPOSTA); }; return _ws_num_proposta_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_r, WS_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA2722B_WS_NUM_PROPOSTA_R : VarBasis
            {
                /*"        10  WS-NUM-PROPOSTA-9     PIC 9(013).*/
                public IntBasis WS_NUM_PROPOSTA_9 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        10  WS-NUM-PROPOSTA-0     PIC 9(001).*/
                public IntBasis WS_NUM_PROPOSTA_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  TAB-OPC-PGTO.*/

                public _REDEF_VA2722B_WS_NUM_PROPOSTA_R()
                {
                    WS_NUM_PROPOSTA_9.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_0.ValueChanged += OnValueChanged;
                }

            }
            public VA2722B_TAB_OPC_PGTO TAB_OPC_PGTO { get; set; } = new VA2722B_TAB_OPC_PGTO();
            public class VA2722B_TAB_OPC_PGTO : VarBasis
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
            private _REDEF_VA2722B_TAB_OPC_PGTO_RED _tab_opc_pgto_red { get; set; }
            public _REDEF_VA2722B_TAB_OPC_PGTO_RED TAB_OPC_PGTO_RED
            {
                get { _tab_opc_pgto_red = new _REDEF_VA2722B_TAB_OPC_PGTO_RED(); _.Move(TAB_OPC_PGTO, _tab_opc_pgto_red); VarBasis.RedefinePassValue(TAB_OPC_PGTO, _tab_opc_pgto_red, TAB_OPC_PGTO); _tab_opc_pgto_red.ValueChanged += () => { _.Move(_tab_opc_pgto_red, TAB_OPC_PGTO); }; return _tab_opc_pgto_red; }
                set { VarBasis.RedefinePassValue(value, _tab_opc_pgto_red, TAB_OPC_PGTO); }
            }  //Redefines
            public class _REDEF_VA2722B_TAB_OPC_PGTO_RED : VarBasis
            {
                /*"      10  TB-OPC-PAGTO            PIC X(011)  OCCURS 5 TIMES.*/
                public ListBasis<StringBasis, string> TB_OPC_PAGTO { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "11", "X(011)"), 5);
                /*"    05        DATA-SQL.*/

                public _REDEF_VA2722B_TAB_OPC_PGTO_RED()
                {
                    TB_OPC_PAGTO.ValueChanged += OnValueChanged;
                }

            }
            public VA2722B_DATA_SQL DATA_SQL { get; set; } = new VA2722B_DATA_SQL();
            public class VA2722B_DATA_SQL : VarBasis
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
            public VA2722B_DATA_CONV DATA_CONV { get; set; } = new VA2722B_DATA_CONV();
            public class VA2722B_DATA_CONV : VarBasis
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
            /*"    05        WFIM-PROPOVA        PIC   X(01)  VALUE  ' '.*/
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
            /*"    05        WS-FIM-CURSOR       PIC   X(01)  VALUE  ' '.*/
            public StringBasis WS_FIM_CURSOR { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WS-HEADER           PIC   X(01)  VALUE  'N'.*/
            public StringBasis WS_HEADER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-LIDOS-PROC       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_PROC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-GRAVADOS         PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-M           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_M { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
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
            /*"    05        W-QTD-LD-TIPO-1     PIC  9(006) VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        W-QTD-LD-TIPO-8     PIC  9(006) VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WABEND.*/
            public VA2722B_WABEND WABEND { get; set; } = new VA2722B_WABEND();
            public class VA2722B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             ' VA2722B'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA2722B");
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
            }
        }


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
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PARVDZUL PARVDZUL { get; set; } = new Dclgens.PARVDZUL();

        public VA2722B_RELAT RELAT { get; set; } = new VA2722B_RELAT(false);
        string GetQuery_RELAT()
        {
            var query = @$"SELECT DATA_SOLICITACAO
							, COD_RELATORIO
							, PERI_INICIAL
							, PERI_FINAL
							, DATA_REFERENCIA
							, NUM_APOLICE
							, NUM_CERTIFICADO
							, SIT_REGISTRO
							FROM SEGUROS.RELATORIOS WHERE SIT_REGISTRO = '0' AND COD_RELATORIO IN ('VGJ1A'
							, 'OR40A')";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string AVA2722B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                AVA2722B.SetFile(AVA2722B_FILE_NAME_P);
                InitializeGetQuery();

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

        public void InitializeGetQuery()
        {
            RELAT.GetQueryEvent += GetQuery_RELAT;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -296- MOVE 'R0000' TO WNR-EXEC-SQL. */
            _.Move("R0000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -297- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -300- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -303- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -307- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -315- DISPLAY 'PROGRAMA EM EXECUCAO VA2722B - ' 'VERSAO V.03- INCIDENTE 535669 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VA2722B - VERSAO V.03- INCIDENTE 535669 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -317- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -319- DISPLAY ' ' */
            _.Display($" ");

            /*" -320- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -321- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -322- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -324- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -325- PERFORM R0010-00-OPEN-CURSOR */

            R0010_00_OPEN_CURSOR_SECTION();

            /*" -327- OPEN OUTPUT AVA2722B */
            AVA2722B.Open(REG_AVA2722B);

            /*" -328- PERFORM R0011-00-LER-CURSOR */

            R0011_00_LER_CURSOR_SECTION();

            /*" -330- IF WS-FIM-CURSOR = 'S' */

            if (WORK_AREA.WS_FIM_CURSOR == "S")
            {

                /*" -332- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -333- PERFORM R1000-00-PROCESSA UNTIL WS-FIM-CURSOR = 'S' . */

            while (!(WORK_AREA.WS_FIM_CURSOR == "S"))
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
            /*" -338- PERFORM R0014-00-CLOSE-CURSOR. */

            R0014_00_CLOSE_CURSOR_SECTION();

            /*" -339- IF WS-HEADER EQUAL 'S' */

            if (WORK_AREA.WS_HEADER == "S")
            {

                /*" -340- PERFORM R8100-00-GRAVA-TRAILLER */

                R8100_00_GRAVA_TRAILLER_SECTION();

                /*" -342- END-IF. */
            }


            /*" -343- DISPLAY '     *** VA2722B ***     ' */
            _.Display($"     *** VA2722B ***     ");

            /*" -344- DISPLAY '-------------------------' */
            _.Display($"-------------------------");

            /*" -345- DISPLAY 'LIDOS RELATORIOS         ' AC-LIDOS. */
            _.Display($"LIDOS RELATORIOS         {WORK_AREA.AC_LIDOS}");

            /*" -346- DISPLAY 'LIDOS APOLICE ESPECIFICA ' AC-LIDOS-PROC. */
            _.Display($"LIDOS APOLICE ESPECIFICA {WORK_AREA.AC_LIDOS_PROC}");

            /*" -347- DISPLAY 'DESPREZADOS MOV2722B     ' AC-DESP-M */
            _.Display($"DESPREZADOS MOV2722B     {WORK_AREA.AC_DESP_M}");

            /*" -348- DISPLAY 'DESPREZADOS PROPFIDH     ' AC-DESP-0 */
            _.Display($"DESPREZADOS PROPFIDH     {WORK_AREA.AC_DESP_0}");

            /*" -349- DISPLAY 'DESPREZADOS PRODUVG      ' AC-DESP-1 */
            _.Display($"DESPREZADOS PRODUVG      {WORK_AREA.AC_DESP_1}");

            /*" -350- DISPLAY 'DESPREZADOS CLIENTES     ' AC-DESP-2 */
            _.Display($"DESPREZADOS CLIENTES     {WORK_AREA.AC_DESP_2}");

            /*" -351- DISPLAY 'DESPREZADOS ENDERECO     ' AC-DESP-3 */
            _.Display($"DESPREZADOS ENDERECO     {WORK_AREA.AC_DESP_3}");

            /*" -352- DISPLAY 'DESPREZADOS OPCPAGVI     ' AC-DESP-4 */
            _.Display($"DESPREZADOS OPCPAGVI     {WORK_AREA.AC_DESP_4}");

            /*" -353- DISPLAY 'DESPREZADOS HISCOBPR     ' AC-DESP-5 */
            _.Display($"DESPREZADOS HISCOBPR     {WORK_AREA.AC_DESP_5}");

            /*" -354- DISPLAY 'DESPREZADOS PARCEVID-MEN ' AC-DESP-6 */
            _.Display($"DESPREZADOS PARCEVID-MEN {WORK_AREA.AC_DESP_6}");

            /*" -355- DISPLAY 'DESPREZADOS PARCEVID-ANU ' AC-DESP-7 */
            _.Display($"DESPREZADOS PARCEVID-ANU {WORK_AREA.AC_DESP_7}");

            /*" -356- DISPLAY 'DESPREZADOS PROPOFID     ' AC-DESP-8 */
            _.Display($"DESPREZADOS PROPOFID     {WORK_AREA.AC_DESP_8}");

            /*" -357- DISPLAY 'DESPREZADOS ENDOSSOS     ' AC-DESP-9 */
            _.Display($"DESPREZADOS ENDOSSOS     {WORK_AREA.AC_DESP_9}");

            /*" -359- DISPLAY 'STATUS GERADOS           ' AC-GRAVADOS. */
            _.Display($"STATUS GERADOS           {WORK_AREA.AC_GRAVADOS}");

            /*" -360- DISPLAY '*** VA2722B - TERMINO NORMAL ***' */
            _.Display($"*** VA2722B - TERMINO NORMAL ***");

            /*" -361- CLOSE AVA2722B . */
            AVA2722B.Close();

            /*" -362- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -362- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-OPEN-CURSOR-SECTION */
        private void R0010_00_OPEN_CURSOR_SECTION()
        {
            /*" -372- MOVE 'R0010' TO WNR-EXEC-SQL. */
            _.Move("R0010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -372- PERFORM R0010_00_OPEN_CURSOR_DB_OPEN_1 */

            R0010_00_OPEN_CURSOR_DB_OPEN_1();

            /*" -374- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -375- DISPLAY 'VA2722B - ERRO OPEN CURSOR RELAT' */
                _.Display($"VA2722B - ERRO OPEN CURSOR RELAT");

                /*" -376- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -376- END-IF. */
            }


        }

        [StopWatch]
        /*" R0010-00-OPEN-CURSOR-DB-OPEN-1 */
        public void R0010_00_OPEN_CURSOR_DB_OPEN_1()
        {
            /*" -372- EXEC SQL OPEN RELAT END-EXEC. */

            RELAT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0011-00-LER-CURSOR-SECTION */
        private void R0011_00_LER_CURSOR_SECTION()
        {
            /*" -385- MOVE 'R0011' TO WNR-EXEC-SQL. */
            _.Move("R0011", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -395- PERFORM R0011_00_LER_CURSOR_DB_FETCH_1 */

            R0011_00_LER_CURSOR_DB_FETCH_1();

            /*" -397- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -398- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -399- MOVE 'S' TO WS-FIM-CURSOR */
                    _.Move("S", WORK_AREA.WS_FIM_CURSOR);

                    /*" -400- ELSE */
                }
                else
                {


                    /*" -401- DISPLAY 'VA2722B - PROBLEMAS NO ACESSO A RELATORIOS' */
                    _.Display($"VA2722B - PROBLEMAS NO ACESSO A RELATORIOS");

                    /*" -402- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -403- END-IF */
                }


                /*" -404- ELSE */
            }
            else
            {


                /*" -405- ADD 1 TO AC-LIDOS */
                WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

                /*" -405- END-IF. */
            }


        }

        [StopWatch]
        /*" R0011-00-LER-CURSOR-DB-FETCH-1 */
        public void R0011_00_LER_CURSOR_DB_FETCH_1()
        {
            /*" -395- EXEC SQL FETCH RELAT INTO :RELATORI-DATA-SOLICITACAO , :RELATORI-COD-RELATORIO , :RELATORI-PERI-INICIAL , :RELATORI-PERI-FINAL , :RELATORI-DATA-REFERENCIA , :RELATORI-NUM-APOLICE , :RELATORI-NUM-CERTIFICADO , :RELATORI-SIT-REGISTRO END-EXEC. */

            if (RELAT.Fetch())
            {
                _.Move(RELAT.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(RELAT.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
                _.Move(RELAT.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
                _.Move(RELAT.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
                _.Move(RELAT.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
                _.Move(RELAT.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(RELAT.RELATORI_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);
                _.Move(RELAT.RELATORI_SIT_REGISTRO, RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0011_99_SAIDA*/

        [StopWatch]
        /*" R0012-00-VER-PRODUVG-SECTION */
        private void R0012_00_VER_PRODUVG_SECTION()
        {
            /*" -414- MOVE 'R0012' TO WNR-EXEC-SQL. */
            _.Move("R0012", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -416- INITIALIZE PRODUVG-ORIG-PRODU. */
            _.Initialize(
                PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU
            );

            /*" -423- PERFORM R0012_00_VER_PRODUVG_DB_SELECT_1 */

            R0012_00_VER_PRODUVG_DB_SELECT_1();

            /*" -426- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -427- DISPLAY 'VA2722B - FIM ANORMAL' */
                _.Display($"VA2722B - FIM ANORMAL");

                /*" -428- DISPLAY '          ERRO SELECT PRODUTOS_VG' */
                _.Display($"          ERRO SELECT PRODUTOS_VG");

                /*" -429- DISPLAY '          SQLCODE = ' SQLCODE */
                _.Display($"          SQLCODE = {DB.SQLCODE}");

                /*" -430- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -430- END-IF. */
            }


        }

        [StopWatch]
        /*" R0012-00-VER-PRODUVG-DB-SELECT-1 */
        public void R0012_00_VER_PRODUVG_DB_SELECT_1()
        {
            /*" -423- EXEC SQL SELECT ORIG_PRODU INTO :PRODUVG-ORIG-PRODU FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0012_00_VER_PRODUVG_DB_SELECT_1_Query1 = new R0012_00_VER_PRODUVG_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0012_00_VER_PRODUVG_DB_SELECT_1_Query1.Execute(r0012_00_VER_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_ORIG_PRODU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0012_99_SAIDA*/

        [StopWatch]
        /*" R0013-00-UPDATE-RELAT-SECTION */
        private void R0013_00_UPDATE_RELAT_SECTION()
        {
            /*" -439- MOVE 'R0013' TO WNR-EXEC-SQL. */
            _.Move("R0013", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -444- PERFORM R0013_00_UPDATE_RELAT_DB_UPDATE_1 */

            R0013_00_UPDATE_RELAT_DB_UPDATE_1();

        }

        [StopWatch]
        /*" R0013-00-UPDATE-RELAT-DB-UPDATE-1 */
        public void R0013_00_UPDATE_RELAT_DB_UPDATE_1()
        {
            /*" -444- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE AND NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO END-EXEC. */

            var r0013_00_UPDATE_RELAT_DB_UPDATE_1_Update1 = new R0013_00_UPDATE_RELAT_DB_UPDATE_1_Update1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
            };

            R0013_00_UPDATE_RELAT_DB_UPDATE_1_Update1.Execute(r0013_00_UPDATE_RELAT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0013_99_SAIDA*/

        [StopWatch]
        /*" R0014-00-CLOSE-CURSOR-SECTION */
        private void R0014_00_CLOSE_CURSOR_SECTION()
        {
            /*" -453- MOVE 'R0014' TO WNR-EXEC-SQL. */
            _.Move("R0014", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -453- PERFORM R0014_00_CLOSE_CURSOR_DB_CLOSE_1 */

            R0014_00_CLOSE_CURSOR_DB_CLOSE_1();

            /*" -456- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -457- DISPLAY 'VA2722B - ERRO CLOSE CURSOR RELAT' */
                _.Display($"VA2722B - ERRO CLOSE CURSOR RELAT");

                /*" -458- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -458- END-IF. */
            }


        }

        [StopWatch]
        /*" R0014-00-CLOSE-CURSOR-DB-CLOSE-1 */
        public void R0014_00_CLOSE_CURSOR_DB_CLOSE_1()
        {
            /*" -453- EXEC SQL CLOSE RELAT END-EXEC. */

            RELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0014_99_SAIDA*/

        [StopWatch]
        /*" R0015-00-UPDATE-COD-RELAT-SECTION */
        private void R0015_00_UPDATE_COD_RELAT_SECTION()
        {
            /*" -466- MOVE 'R0015' TO WNR-EXEC-SQL. */
            _.Move("R0015", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -471- PERFORM R0015_00_UPDATE_COD_RELAT_DB_UPDATE_1 */

            R0015_00_UPDATE_COD_RELAT_DB_UPDATE_1();

            /*" -474- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -475- DISPLAY 'VA2722B - ERRO CLOSE CURSOR RELAT' */
                _.Display($"VA2722B - ERRO CLOSE CURSOR RELAT");

                /*" -476- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -477- END-IF */
            }


            /*" -477- . */

        }

        [StopWatch]
        /*" R0015-00-UPDATE-COD-RELAT-DB-UPDATE-1 */
        public void R0015_00_UPDATE_COD_RELAT_DB_UPDATE_1()
        {
            /*" -471- EXEC SQL UPDATE SEGUROS.RELATORIOS SET COD_RELATORIO = :WS-ERRO-PROCESSAMENTO WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE AND NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO END-EXEC. */

            var r0015_00_UPDATE_COD_RELAT_DB_UPDATE_1_Update1 = new R0015_00_UPDATE_COD_RELAT_DB_UPDATE_1_Update1()
            {
                WS_ERRO_PROCESSAMENTO = WS_ERRO_PROCESSAMENTO.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
            };

            R0015_00_UPDATE_COD_RELAT_DB_UPDATE_1_Update1.Execute(r0015_00_UPDATE_COD_RELAT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -487- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -494- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -497- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -498- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -499- DISPLAY 'VA2722B - ERRO ACESSO SISTEMAS' */
                    _.Display($"VA2722B - ERRO ACESSO SISTEMAS");

                    /*" -500- DISPLAY '          IDE_SISTEMA = VG    ' */
                    _.Display($"          IDE_SISTEMA = VG    ");

                    /*" -501- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", WORK_AREA.WFIM_V1SISTEMA);

                    /*" -502- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -503- ELSE */
                }
                else
                {


                    /*" -504- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                    /*" -505- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -506- END-IF */
                }


                /*" -506- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -494- EXEC SQL SELECT DATA_MOV_ABERTO , DATA_MOV_ABERTO - 30 DAYS INTO :SISTEMAS-DATA-MOV-ABERTO , :SISTEMAS-DATA-MOV-ABERTO-30 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

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
        /*" R0200-00-GRAVA-HEADER-SECTION */
        private void R0200_00_GRAVA_HEADER_SECTION()
        {
            /*" -517- MOVE 'R0200' TO WNR-EXEC-SQL. */
            _.Move("R0200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -518- MOVE SPACES TO VA2722B1O-REG */
            _.Move("", VA2722B1O_REG);

            /*" -519- MOVE 'H' TO VA2722B1O-IDENTIFICA. */
            _.Move("H", VA2722B1O_REG.VA2722B1O_IDENTIFICA);

            /*" -520- MOVE 'STASASSE' TO VA2722B1O-NOME-ARQ. */
            _.Move("STASASSE", VA2722B1O_REG.VA2722B1O_REG_H.VA2722B1O_NOME_ARQ);

            /*" -522- MOVE 1 TO VA2722B1O-SEQ-ARQ. */
            _.Move(1, VA2722B1O_REG.VA2722B1O_REG_H.VA2722B1O_SEQ_ARQ);

            /*" -524- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO VA2722B1O-DATA-GER (5:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), VA2722B1O_REG.VA2722B1O_REG_H.VA2722B1O_DATA_GER, 5, 4);

            /*" -526- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO VA2722B1O-DATA-GER (3:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), VA2722B1O_REG.VA2722B1O_REG_H.VA2722B1O_DATA_GER, 3, 2);

            /*" -529- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO VA2722B1O-DATA-GER (1:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), VA2722B1O_REG.VA2722B1O_REG_H.VA2722B1O_DATA_GER, 1, 2);

            /*" -530- MOVE 4 TO VA2722B1O-COD-SIST. */
            _.Move(4, VA2722B1O_REG.VA2722B1O_REG_H.VA2722B1O_COD_SIST);

            /*" -532- MOVE 1 TO VA2722B1O-COD-SIST-DEST. */
            _.Move(1, VA2722B1O_REG.VA2722B1O_REG_H.VA2722B1O_COD_SIST_DEST);

            /*" -533- WRITE REG-AVA2722B FROM VA2722B1O-REG. */
            _.Move(VA2722B1O_REG.GetMoveValues(), REG_AVA2722B);

            AVA2722B.Write(REG_AVA2722B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -543- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -544- PERFORM R0012-00-VER-PRODUVG */

            R0012_00_VER_PRODUVG_SECTION();

            /*" -548- IF PRODUVG-ORIG-PRODU EQUAL 'ESPEC' OR 'ESPEC1' OR 'ESPEC2' OR 'ESPEC3' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.In("ESPEC", "ESPEC1", "ESPEC2", "ESPEC3"))
            {

                /*" -549- ADD 1 TO AC-LIDOS-PROC */
                WORK_AREA.AC_LIDOS_PROC.Value = WORK_AREA.AC_LIDOS_PROC + 1;

                /*" -550- ELSE */
            }
            else
            {


                /*" -551- GO TO R1000-90-LER-PROXIMO */

                R1000_90_LER_PROXIMO(); //GOTO
                return;

                /*" -553- END-IF. */
            }


            /*" -554- IF WS-HEADER = 'N' */

            if (WORK_AREA.WS_HEADER == "N")
            {

                /*" -555- PERFORM R0200-00-GRAVA-HEADER */

                R0200_00_GRAVA_HEADER_SECTION();

                /*" -556- MOVE 'S' TO WS-HEADER */
                _.Move("S", WORK_AREA.WS_HEADER);

                /*" -558- END-IF. */
            }


            /*" -561- MOVE RELATORI-NUM-CERTIFICADO TO PROPOVA-NUM-CERTIFICADO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -593- PERFORM R1000_00_PROCESSA_DB_SELECT_1 */

            R1000_00_PROCESSA_DB_SELECT_1();

            /*" -598- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -599- MOVE 'VA2722PR' TO WS-ERRO-PROCESSAMENTO */
                _.Move("VA2722PR", WS_ERRO_PROCESSAMENTO);

                /*" -600- PERFORM R0015-00-UPDATE-COD-RELAT */

                R0015_00_UPDATE_COD_RELAT_SECTION();

                /*" -602- ADD 1 TO AC-DESP-M */
                WORK_AREA.AC_DESP_M.Value = WORK_AREA.AC_DESP_M + 1;

                /*" -603- GO TO R1000-90-LER-PROXIMO */

                R1000_90_LER_PROXIMO(); //GOTO
                return;

                /*" -605- END-IF. */
            }


            /*" -608- IF PROPOVA-SIT-REGISTRO NOT EQUAL '3' AND '4' */

            if (!PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.In("3", "4"))
            {

                /*" -609- MOVE 'VA2722CE' TO WS-ERRO-PROCESSAMENTO */
                _.Move("VA2722CE", WS_ERRO_PROCESSAMENTO);

                /*" -610- PERFORM R0015-00-UPDATE-COD-RELAT */

                R0015_00_UPDATE_COD_RELAT_SECTION();

                /*" -612- ADD 1 TO AC-DESP-M */
                WORK_AREA.AC_DESP_M.Value = WORK_AREA.AC_DESP_M + 1;

                /*" -613- GO TO R1000-90-LER-PROXIMO */

                R1000_90_LER_PROXIMO(); //GOTO
                return;

                /*" -615- END-IF. */
            }


            /*" -616- PERFORM R1300-00-SELECT-PROPOFID */

            R1300_00_SELECT_PROPOFID_SECTION();

            /*" -619- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -620- MOVE 'VA2722FI' TO WS-ERRO-PROCESSAMENTO */
                _.Move("VA2722FI", WS_ERRO_PROCESSAMENTO);

                /*" -621- PERFORM R0015-00-UPDATE-COD-RELAT */

                R0015_00_UPDATE_COD_RELAT_SECTION();

                /*" -623- ADD 1 TO AC-DESP-8 */
                WORK_AREA.AC_DESP_8.Value = WORK_AREA.AC_DESP_8 + 1;

                /*" -624- GO TO R1000-90-LER-PROXIMO */

                R1000_90_LER_PROXIMO(); //GOTO
                return;

                /*" -626- END-IF. */
            }


            /*" -628- MOVE SPACES TO VA2722B1O-REG-1. */
            _.Move("", VA2722B1O_REG.VA2722B1O_REG_1);

            /*" -629- IF PROPOVA-SIT-REGISTRO EQUAL '3' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3")
            {

                /*" -635- MOVE 'EMT' TO VA2722B1O-SIT-PROPOSTA */
                _.Move("EMT", VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_SIT_PROPOSTA);

                /*" -636- MOVE 000 TO VA2722B1O-TIPO-MOTIVO */
                _.Move(000, VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_TIPO_MOTIVO);

                /*" -637- ELSE */
            }
            else
            {


                /*" -638- MOVE 'CAN' TO VA2722B1O-SIT-PROPOSTA */
                _.Move("CAN", VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_SIT_PROPOSTA);

                /*" -639- MOVE 101 TO VA2722B1O-TIPO-MOTIVO */
                _.Move(101, VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_TIPO_MOTIVO);

                /*" -641- END-IF. */
            }


            /*" -642- PERFORM R1400-00-SELECT-ENDOSSOS */

            R1400_00_SELECT_ENDOSSOS_SECTION();

            /*" -643- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -645- ADD 1 TO AC-DESP-9 */
                WORK_AREA.AC_DESP_9.Value = WORK_AREA.AC_DESP_9 + 1;

                /*" -646- GO TO R1000-90-LER-PROXIMO */

                R1000_90_LER_PROXIMO(); //GOTO
                return;

                /*" -648- END-IF. */
            }


            /*" -649- PERFORM R1500-00-SELECT-HISCOBPR */

            R1500_00_SELECT_HISCOBPR_SECTION();

            /*" -650- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -652- ADD 1 TO AC-DESP-5 */
                WORK_AREA.AC_DESP_5.Value = WORK_AREA.AC_DESP_5 + 1;

                /*" -653- GO TO R1000-90-LER-PROXIMO */

                R1000_90_LER_PROXIMO(); //GOTO
                return;

                /*" -655- END-IF. */
            }


            /*" -656- PERFORM R1510-00-SELECT-HISCOBPR */

            R1510_00_SELECT_HISCOBPR_SECTION();

            /*" -657- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -659- ADD 1 TO AC-DESP-5 */
                WORK_AREA.AC_DESP_5.Value = WORK_AREA.AC_DESP_5 + 1;

                /*" -660- GO TO R1000-90-LER-PROXIMO */

                R1000_90_LER_PROXIMO(); //GOTO
                return;

                /*" -662- END-IF. */
            }


            /*" -663- PERFORM R1700-00-SELECT-RAMOCOMP. */

            R1700_00_SELECT_RAMOCOMP_SECTION();

            /*" -664- PERFORM R1100-00-GRAVA-TIPO-1. */

            R1100_00_GRAVA_TIPO_1_SECTION();

            /*" -665- PERFORM R1200-00-GRAVA-TIPO-2. */

            R1200_00_GRAVA_TIPO_2_SECTION();

            /*" -666- PERFORM R1210-00-GRAVA-TIPO-3. */

            R1210_00_GRAVA_TIPO_3_SECTION();

            /*" -666- PERFORM R0013-00-UPDATE-RELAT. */

            R0013_00_UPDATE_RELAT_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_90_LER_PROXIMO */

            R1000_90_LER_PROXIMO();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-DB-SELECT-1 */
        public void R1000_00_PROCESSA_DB_SELECT_1()
        {
            /*" -593- EXEC SQL SELECT C.NUM_APOLICE , C.COD_SUBGRUPO , C.NUM_CERTIFICADO , C.COD_CLIENTE , C.OCOREND , C.AGE_COBRANCA , C.DATA_MOVIMENTO , C.SIT_REGISTRO INTO :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO , :PROPOVA-NUM-CERTIFICADO , :PROPOVA-COD-CLIENTE , :PROPOVA-OCOREND , :PROPOVA-AGE-COBRANCA , :PROPOVA-DATA-MOVIMENTO , :PROPOVA-SIT-REGISTRO FROM SEGUROS.SUBGRUPOS_VGAP A, SEGUROS.PRODUTOS_VG B, SEGUROS.PROPOSTAS_VA C WHERE B.ORIG_PRODU = 'ESPEC' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.COD_PRODUTO NOT BETWEEN 7700 AND 7799 AND C.NUM_APOLICE = A.NUM_APOLICE AND C.COD_SUBGRUPO = A.COD_SUBGRUPO AND C.DTPROXVEN <> '9999-12-31' AND C.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1000_00_PROCESSA_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(executed_1.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(executed_1.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(executed_1.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
                _.Move(executed_1.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
                _.Move(executed_1.PROPOVA_DATA_MOVIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO);
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
            }


        }

        [StopWatch]
        /*" R1000-90-LER-PROXIMO */
        private void R1000_90_LER_PROXIMO(bool isPerform = false)
        {
            /*" -669- PERFORM R0011-00-LER-CURSOR. */

            R0011_00_LER_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-GRAVA-TIPO-1-SECTION */
        private void R1100_00_GRAVA_TIPO_1_SECTION()
        {
            /*" -678- MOVE 'R1100' TO WNR-EXEC-SQL. */
            _.Move("R1100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -679- MOVE '1' TO VA2722B1O-IDENTIFICA. */
            _.Move("1", VA2722B1O_REG.VA2722B1O_IDENTIFICA);

            /*" -682- MOVE PROPOVA-NUM-CERTIFICADO TO VA2722B1O-NUM-PROPOSTA-1. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_NUM_PROPOSTA_1);

            /*" -685- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA.WS_NUM_PROPOSTA);

            /*" -686- IF WS-NUM-PROPOSTA(1:1) NOT EQUAL ZEROS */

            if (WORK_AREA.WS_NUM_PROPOSTA.Substring(1, 1) != 00)
            {

                /*" -688- MOVE PROPOVA-NUM-CERTIFICADO TO VA2722B1O-NUM-PROPOSTA-1 */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_NUM_PROPOSTA_1);

                /*" -689- ELSE */
            }
            else
            {


                /*" -691- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA-9 */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_9);

                /*" -693- MOVE 0 TO WS-NUM-PROPOSTA-0 */
                _.Move(0, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_0);

                /*" -695- MOVE WS-NUM-PROPOSTA TO VA2722B1O-NUM-PROPOSTA-1 */
                _.Move(WORK_AREA.WS_NUM_PROPOSTA, VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_NUM_PROPOSTA_1);

                /*" -697- END-IF. */
            }


            /*" -699- MOVE PROPOVA-DATA-MOVIMENTO (1:4) TO VA2722B1O-DATA-INICIO-SIT (5:4) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.Substring(1, 4), VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_DATA_INICIO_SIT, 5, 4);

            /*" -701- MOVE PROPOVA-DATA-MOVIMENTO (6:2) TO VA2722B1O-DATA-INICIO-SIT (3:2) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.Substring(6, 2), VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_DATA_INICIO_SIT, 3, 2);

            /*" -704- MOVE PROPOVA-DATA-MOVIMENTO (9:2) TO VA2722B1O-DATA-INICIO-SIT (1:2) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.Substring(9, 2), VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_DATA_INICIO_SIT, 1, 2);

            /*" -707- MOVE SPACES TO VA2722B1O-BRANCOS-0 VA2722B1O-BRANCOS-1. */
            _.Move("", VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_BRANCOS_0);
            _.Move("", VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_BRANCOS_1);


            /*" -709- ADD 1 TO W-NSL */
            WORK_AREA.W_NSL.Value = WORK_AREA.W_NSL + 1;

            /*" -710- MOVE ARQSIVPF-NSAS-SIVPF TO VA2722B1O-NUM-SEQ-ARQ. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_NUM_SEQ_ARQ);

            /*" -712- MOVE W-NSL TO VA2722B1O-NUM-SEQ-REG. */
            _.Move(WORK_AREA.W_NSL, VA2722B1O_REG.VA2722B1O_REG_1.VA2722B1O_NUM_SEQ_REG);

            /*" -715- WRITE REG-AVA2722B FROM VA2722B1O-REG. */
            _.Move(VA2722B1O_REG.GetMoveValues(), REG_AVA2722B);

            AVA2722B.Write(REG_AVA2722B.GetMoveValues().ToString());

            /*" -717- ADD 1 TO W-QTD-LD-TIPO-1 AC-GRAVADOS. */
            WORK_AREA.W_QTD_LD_TIPO_1.Value = WORK_AREA.W_QTD_LD_TIPO_1 + 1;
            WORK_AREA.AC_GRAVADOS.Value = WORK_AREA.AC_GRAVADOS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GRAVA-TIPO-2-SECTION */
        private void R1200_00_GRAVA_TIPO_2_SECTION()
        {
            /*" -727- MOVE 'R1200' TO WNR-EXEC-SQL. */
            _.Move("R1200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -728- MOVE SPACES TO VA2722B1O-REG-2. */
            _.Move("", VA2722B1O_REG.VA2722B1O_REG_2);

            /*" -730- MOVE '2' TO VA2722B1O-IDENTIFICA. */
            _.Move("2", VA2722B1O_REG.VA2722B1O_IDENTIFICA);

            /*" -733- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA.WS_NUM_PROPOSTA);

            /*" -734- IF WS-NUM-PROPOSTA(1:1) NOT EQUAL ZEROS */

            if (WORK_AREA.WS_NUM_PROPOSTA.Substring(1, 1) != 00)
            {

                /*" -737- MOVE PROPOVA-NUM-CERTIFICADO TO VA2722B1O-NUM-PROPOSTA-2 VA2722B1O-NUM-CERTIFICADO */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VA2722B1O_REG.VA2722B1O_REG_2.VA2722B1O_NUM_PROPOSTA_2);
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VA2722B1O_REG.VA2722B1O_REG_2.VA2722B1O_NUM_CERTIFICADO);


                /*" -738- ELSE */
            }
            else
            {


                /*" -740- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA-9 */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_9);

                /*" -742- MOVE 0 TO WS-NUM-PROPOSTA-0 */
                _.Move(0, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_0);

                /*" -745- MOVE WS-NUM-PROPOSTA TO VA2722B1O-NUM-PROPOSTA-2 VA2722B1O-NUM-CERTIFICADO */
                _.Move(WORK_AREA.WS_NUM_PROPOSTA, VA2722B1O_REG.VA2722B1O_REG_2.VA2722B1O_NUM_PROPOSTA_2);
                _.Move(WORK_AREA.WS_NUM_PROPOSTA, VA2722B1O_REG.VA2722B1O_REG_2.VA2722B1O_NUM_CERTIFICADO);


                /*" -747- END-IF. */
            }


            /*" -749- MOVE ENDOSSOS-DATA-INIVIGENCIA (1:4) TO VA2722B1O-DATA-INICIO-VIG (5:4) */
            _.MoveAtPosition(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Substring(1, 4), VA2722B1O_REG.VA2722B1O_REG_2.VA2722B1O_DATA_INICIO_VIG, 5, 4);

            /*" -751- MOVE ENDOSSOS-DATA-INIVIGENCIA (6:2) TO VA2722B1O-DATA-INICIO-VIG (3:2) */
            _.MoveAtPosition(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Substring(6, 2), VA2722B1O_REG.VA2722B1O_REG_2.VA2722B1O_DATA_INICIO_VIG, 3, 2);

            /*" -754- MOVE ENDOSSOS-DATA-INIVIGENCIA (9:2) TO VA2722B1O-DATA-INICIO-VIG (1:2) */
            _.MoveAtPosition(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Substring(9, 2), VA2722B1O_REG.VA2722B1O_REG_2.VA2722B1O_DATA_INICIO_VIG, 1, 2);

            /*" -756- MOVE ENDOSSOS-DATA-TERVIGENCIA (1:4) TO VA2722B1O-DATA-FINAL-VIG (5:4) */
            _.MoveAtPosition(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Substring(1, 4), VA2722B1O_REG.VA2722B1O_REG_2.VA2722B1O_DATA_FINAL_VIG, 5, 4);

            /*" -758- MOVE ENDOSSOS-DATA-TERVIGENCIA (6:2) TO VA2722B1O-DATA-FINAL-VIG (3:2) */
            _.MoveAtPosition(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Substring(6, 2), VA2722B1O_REG.VA2722B1O_REG_2.VA2722B1O_DATA_FINAL_VIG, 3, 2);

            /*" -761- MOVE ENDOSSOS-DATA-TERVIGENCIA (9:2) TO VA2722B1O-DATA-FINAL-VIG (1:2) */
            _.MoveAtPosition(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Substring(9, 2), VA2722B1O_REG.VA2722B1O_REG_2.VA2722B1O_DATA_FINAL_VIG, 1, 2);

            /*" -764- MOVE HISCOBPR-VLPREMIO TO VA2722B1O-VALOR-PREMIO */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, VA2722B1O_REG.VA2722B1O_REG_2.VA2722B1O_VALOR_PREMIO);

            /*" -768- COMPUTE VA2722B1O-VALOR-IOF = HISCOBPR-VLPREMIO * RAMOCOMP-PCT-IOCC-RAMO / 100 */
            VA2722B1O_REG.VA2722B1O_REG_2.VA2722B1O_VALOR_IOF.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO * RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f;

            /*" -771- WRITE REG-AVA2722B FROM VA2722B1O-REG. */
            _.Move(VA2722B1O_REG.GetMoveValues(), REG_AVA2722B);

            AVA2722B.Write(REG_AVA2722B.GetMoveValues().ToString());

            /*" -773- ADD 1 TO W-QTD-LD-TIPO-1 AC-GRAVADOS. */
            WORK_AREA.W_QTD_LD_TIPO_1.Value = WORK_AREA.W_QTD_LD_TIPO_1 + 1;
            WORK_AREA.AC_GRAVADOS.Value = WORK_AREA.AC_GRAVADOS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-GRAVA-TIPO-3-SECTION */
        private void R1210_00_GRAVA_TIPO_3_SECTION()
        {
            /*" -782- MOVE 'R1210' TO WNR-EXEC-SQL. */
            _.Move("R1210", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -783- MOVE SPACES TO VA2722B1O-REG-3. */
            _.Move("", VA2722B1O_REG.VA2722B1O_REG_3);

            /*" -785- MOVE '3' TO VA2722B1O-IDENTIFICA. */
            _.Move("3", VA2722B1O_REG.VA2722B1O_IDENTIFICA);

            /*" -788- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA.WS_NUM_PROPOSTA);

            /*" -789- IF WS-NUM-PROPOSTA(1:1) NOT EQUAL ZEROS */

            if (WORK_AREA.WS_NUM_PROPOSTA.Substring(1, 1) != 00)
            {

                /*" -791- MOVE PROPOVA-NUM-CERTIFICADO TO VA2722B1O-NUM-PROPOSTA-3 */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_NUM_PROPOSTA_3);

                /*" -792- ELSE */
            }
            else
            {


                /*" -794- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA-9 */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_9);

                /*" -796- MOVE 0 TO WS-NUM-PROPOSTA-0 */
                _.Move(0, WORK_AREA.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_0);

                /*" -798- MOVE WS-NUM-PROPOSTA TO VA2722B1O-NUM-PROPOSTA-3 */
                _.Move(WORK_AREA.WS_NUM_PROPOSTA, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_NUM_PROPOSTA_3);

                /*" -800- END-IF. */
            }


            /*" -801- IF HISCOBPR-IMP-MORNATU NOT EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU != 00)
            {

                /*" -803- MOVE 12 TO VA2722B1O-COD-COBERTURA */
                _.Move(12, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_COD_COBERTURA);

                /*" -805- MOVE HISCOBPR-IMP-MORNATU TO VA2722B1O-VALOR-COBERTURA */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_VALOR_COBERTURA);

                /*" -807- WRITE REG-AVA2722B FROM VA2722B1O-REG */
                _.Move(VA2722B1O_REG.GetMoveValues(), REG_AVA2722B);

                AVA2722B.Write(REG_AVA2722B.GetMoveValues().ToString());

                /*" -810- ADD 1 TO W-QTD-LD-TIPO-1 AC-GRAVADOS */
                WORK_AREA.W_QTD_LD_TIPO_1.Value = WORK_AREA.W_QTD_LD_TIPO_1 + 1;
                WORK_AREA.AC_GRAVADOS.Value = WORK_AREA.AC_GRAVADOS + 1;

                /*" -812- END-IF. */
            }


            /*" -813- IF HISCOBPR-IMPMORACID NOT EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID != 00)
            {

                /*" -815- MOVE 13 TO VA2722B1O-COD-COBERTURA */
                _.Move(13, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_COD_COBERTURA);

                /*" -817- MOVE HISCOBPR-IMPMORACID TO VA2722B1O-VALOR-COBERTURA */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_VALOR_COBERTURA);

                /*" -819- WRITE REG-AVA2722B FROM VA2722B1O-REG */
                _.Move(VA2722B1O_REG.GetMoveValues(), REG_AVA2722B);

                AVA2722B.Write(REG_AVA2722B.GetMoveValues().ToString());

                /*" -822- ADD 1 TO W-QTD-LD-TIPO-1 AC-GRAVADOS */
                WORK_AREA.W_QTD_LD_TIPO_1.Value = WORK_AREA.W_QTD_LD_TIPO_1 + 1;
                WORK_AREA.AC_GRAVADOS.Value = WORK_AREA.AC_GRAVADOS + 1;

                /*" -824- END-IF. */
            }


            /*" -825- IF HISCOBPR-IMPINVPERM NOT EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM != 00)
            {

                /*" -827- MOVE 590 TO VA2722B1O-COD-COBERTURA */
                _.Move(590, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_COD_COBERTURA);

                /*" -829- MOVE HISCOBPR-IMPINVPERM TO VA2722B1O-VALOR-COBERTURA */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_VALOR_COBERTURA);

                /*" -831- WRITE REG-AVA2722B FROM VA2722B1O-REG */
                _.Move(VA2722B1O_REG.GetMoveValues(), REG_AVA2722B);

                AVA2722B.Write(REG_AVA2722B.GetMoveValues().ToString());

                /*" -834- ADD 1 TO W-QTD-LD-TIPO-1 AC-GRAVADOS */
                WORK_AREA.W_QTD_LD_TIPO_1.Value = WORK_AREA.W_QTD_LD_TIPO_1 + 1;
                WORK_AREA.AC_GRAVADOS.Value = WORK_AREA.AC_GRAVADOS + 1;

                /*" -836- END-IF. */
            }


            /*" -837- IF HISCOBPR-IMPAMDS NOT EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS != 00)
            {

                /*" -839- MOVE 11 TO VA2722B1O-COD-COBERTURA */
                _.Move(11, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_COD_COBERTURA);

                /*" -841- MOVE HISCOBPR-IMPAMDS TO VA2722B1O-VALOR-COBERTURA */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_VALOR_COBERTURA);

                /*" -843- WRITE REG-AVA2722B FROM VA2722B1O-REG */
                _.Move(VA2722B1O_REG.GetMoveValues(), REG_AVA2722B);

                AVA2722B.Write(REG_AVA2722B.GetMoveValues().ToString());

                /*" -846- ADD 1 TO W-QTD-LD-TIPO-1 AC-GRAVADOS */
                WORK_AREA.W_QTD_LD_TIPO_1.Value = WORK_AREA.W_QTD_LD_TIPO_1 + 1;
                WORK_AREA.AC_GRAVADOS.Value = WORK_AREA.AC_GRAVADOS + 1;

                /*" -848- END-IF. */
            }


            /*" -849- IF HISCOBPR-IMPDH NOT EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH != 00)
            {

                /*" -851- MOVE 591 TO VA2722B1O-COD-COBERTURA */
                _.Move(591, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_COD_COBERTURA);

                /*" -853- MOVE HISCOBPR-IMPDH TO VA2722B1O-VALOR-COBERTURA */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_VALOR_COBERTURA);

                /*" -855- WRITE REG-AVA2722B FROM VA2722B1O-REG */
                _.Move(VA2722B1O_REG.GetMoveValues(), REG_AVA2722B);

                AVA2722B.Write(REG_AVA2722B.GetMoveValues().ToString());

                /*" -858- ADD 1 TO W-QTD-LD-TIPO-1 AC-GRAVADOS */
                WORK_AREA.W_QTD_LD_TIPO_1.Value = WORK_AREA.W_QTD_LD_TIPO_1 + 1;
                WORK_AREA.AC_GRAVADOS.Value = WORK_AREA.AC_GRAVADOS + 1;

                /*" -860- END-IF. */
            }


            /*" -861- IF HISCOBPR-IMPDIT NOT EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT != 00)
            {

                /*" -863- MOVE 592 TO VA2722B1O-COD-COBERTURA */
                _.Move(592, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_COD_COBERTURA);

                /*" -865- MOVE HISCOBPR-IMPDIT TO VA2722B1O-VALOR-COBERTURA */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT, VA2722B1O_REG.VA2722B1O_REG_3.VA2722B1O_VALOR_COBERTURA);

                /*" -867- WRITE REG-AVA2722B FROM VA2722B1O-REG */
                _.Move(VA2722B1O_REG.GetMoveValues(), REG_AVA2722B);

                AVA2722B.Write(REG_AVA2722B.GetMoveValues().ToString());

                /*" -870- ADD 1 TO W-QTD-LD-TIPO-1 AC-GRAVADOS */
                WORK_AREA.W_QTD_LD_TIPO_1.Value = WORK_AREA.W_QTD_LD_TIPO_1 + 1;
                WORK_AREA.AC_GRAVADOS.Value = WORK_AREA.AC_GRAVADOS + 1;

                /*" -870- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-PROPOFID-SECTION */
        private void R1300_00_SELECT_PROPOFID_SECTION()
        {
            /*" -879- MOVE 'R1300' TO WNR-EXEC-SQL. */
            _.Move("R1300", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -891- PERFORM R1300_00_SELECT_PROPOFID_DB_SELECT_1 */

            R1300_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -895- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -896- DISPLAY 'VA2722B - ERRO ACESSO PROP.FIDELIZ ' */
                _.Display($"VA2722B - ERRO ACESSO PROP.FIDELIZ ");

                /*" -898- DISPLAY '          CERTIFICADO ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -899- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                /*" -900- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -900- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R1300_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -891- EXEC SQL SELECT SIT_PROPOSTA, DATA_PROPOSTA, NUM_IDENTIFICACAO INTO :PROPOFID-SIT-PROPOSTA, :PROPOFID-DATA-PROPOSTA, :PROPOFID-NUM-IDENTIFICACAO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC. */

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
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-ENDOSSOS-SECTION */
        private void R1400_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -909- MOVE 'R1400' TO WNR-EXEC-SQL. */
            _.Move("R1400", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -919- PERFORM R1400_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R1400_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -923- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -924- DISPLAY 'VA2722B - ERRO ACESSO ENDOSSOS' */
                _.Display($"VA2722B - ERRO ACESSO ENDOSSOS");

                /*" -926- DISPLAY '          CERTIFICADO ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -928- DISPLAY '          APOLICE     ' PROPOVA-NUM-APOLICE */
                _.Display($"          APOLICE     {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -929- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                /*" -930- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -930- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R1400_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -919- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :ENDOSSOS-DATA-INIVIGENCIA, :ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC. */

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
        /*" R1500-00-SELECT-HISCOBPR-SECTION */
        private void R1500_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -939- MOVE 'R1500' TO WNR-EXEC-SQL. */
            _.Move("R1500", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -947- PERFORM R1500_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1500_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -951- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -952- DISPLAY 'VA2722B - ERRO ACESSO HIS_COBER_PROPOST 1' */
                _.Display($"VA2722B - ERRO ACESSO HIS_COBER_PROPOST 1");

                /*" -954- DISPLAY '          CERTIFICADO ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -955- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                /*" -956- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -956- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1500_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -947- EXEC SQL SELECT VLPREMIO INTO :HISCOBPR-VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = 1 END-EXEC. */

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
        /*" R1510-00-SELECT-HISCOBPR-SECTION */
        private void R1510_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -965- MOVE 'R1510' TO WNR-EXEC-SQL. */
            _.Move("R1510", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -983- PERFORM R1510_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1510_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -987- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -988- DISPLAY 'VA2722B - ERRO ACESSO HIS_COBER_PROPOST 2' */
                _.Display($"VA2722B - ERRO ACESSO HIS_COBER_PROPOST 2");

                /*" -990- DISPLAY '          CERTIFICADO ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -991- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                /*" -992- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -992- END-IF. */
            }


        }

        [StopWatch]
        /*" R1510-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1510_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -983- EXEC SQL SELECT IMP_MORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT INTO :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPMORACID, :HISCOBPR-IMPINVPERM, :HISCOBPR-IMPAMDS, :HISCOBPR-IMPDH, :HISCOBPR-IMPDIT FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

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
        /*" R1700-00-SELECT-RAMOCOMP-SECTION */
        private void R1700_00_SELECT_RAMOCOMP_SECTION()
        {
            /*" -1001- MOVE 'R1700' TO WNR-EXEC-SQL. */
            _.Move("R1700", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1004- MOVE ZEROS TO WHOST-COUNT */
            _.Move(0, WHOST_COUNT);

            /*" -1011- PERFORM R1700_00_SELECT_RAMOCOMP_DB_SELECT_1 */

            R1700_00_SELECT_RAMOCOMP_DB_SELECT_1();

            /*" -1014- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1015- DISPLAY 'VA2722B - ERRO ACESSO RAMO_COMPLEMENTAR ' */
                _.Display($"VA2722B - ERRO ACESSO RAMO_COMPLEMENTAR ");

                /*" -1017- DISPLAY '          CERTIFICADO ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1018- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1018- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-RAMOCOMP-DB-SELECT-1 */
        public void R1700_00_SELECT_RAMOCOMP_DB_SELECT_1()
        {
            /*" -1011- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = 93 AND DATA_INIVIGENCIA <= :PROPOFID-DATA-PROPOSTA AND DATA_TERVIGENCIA >= :PROPOFID-DATA-PROPOSTA END-EXEC. */

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
        /*" R8100-00-GRAVA-TRAILLER-SECTION */
        private void R8100_00_GRAVA_TRAILLER_SECTION()
        {
            /*" -1027- MOVE 'R8100' TO WNR-EXEC-SQL. */
            _.Move("R8100", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1028- MOVE SPACES TO VA2722B1O-REG-T. */
            _.Move("", VA2722B1O_REG.VA2722B1O_REG_T);

            /*" -1038- MOVE ZEROS TO VA2722B1O-QTDE-REG-1 VA2722B1O-QTDE-REG-2 VA2722B1O-QTDE-REG-3 VA2722B1O-QTDE-REG-4 VA2722B1O-QTDE-REG-5 VA2722B1O-QTDE-REG-6 VA2722B1O-QTDE-REG-7 VA2722B1O-QTDE-REG-8 VA2722B1O-QTDE-REG-9 */
            _.Move(0, VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_1);
            _.Move(0, VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_2);
            _.Move(0, VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_3);
            _.Move(0, VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_4);
            _.Move(0, VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_5);
            _.Move(0, VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_6);
            _.Move(0, VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_7);
            _.Move(0, VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_8);
            _.Move(0, VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_9);


            /*" -1041- MOVE 'T' TO VA2722B1O-IDENTIFICA */
            _.Move("T", VA2722B1O_REG.VA2722B1O_IDENTIFICA);

            /*" -1044- MOVE 'STASASSE' TO VA2722B1O-NOME-ARQ-T */
            _.Move("STASASSE", VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_NOME_ARQ_T);

            /*" -1047- MOVE W-QTD-LD-TIPO-1 TO VA2722B1O-QTDE-REG-1 */
            _.Move(WORK_AREA.W_QTD_LD_TIPO_1, VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_1);

            /*" -1050- MOVE W-QTD-LD-TIPO-8 TO VA2722B1O-QTDE-REG-8 */
            _.Move(WORK_AREA.W_QTD_LD_TIPO_8, VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_8);

            /*" -1053- COMPUTE VA2722B1O-QTDE-REG-TOTAL = VA2722B1O-QTDE-REG-1 + VA2722B1O-QTDE-REG-8. */
            VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_TOTAL.Value = VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_1 + VA2722B1O_REG.VA2722B1O_REG_T.VA2722B1O_QTDE_REG_8;

            /*" -1054- WRITE REG-AVA2722B FROM VA2722B1O-REG. */
            _.Move(VA2722B1O_REG.GetMoveValues(), REG_AVA2722B);

            AVA2722B.Write(REG_AVA2722B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1063- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -1064- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, WORK_AREA.WABEND.WSQLERRMC);

            /*" -1065- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -1065- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1067- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1067- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}