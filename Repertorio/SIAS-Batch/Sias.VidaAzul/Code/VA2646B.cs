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
using Sias.VidaAzul.DB2.VA2646B;

namespace Code
{
    public class VA2646B
    {
        public bool IsCall { get; set; }

        public VA2646B()
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
        /*"      *   PROGRAMA ............... VA2646B                             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO: GERA PROPOSTAS DE APOLICES ESPECIFICAS E VIDA        *      */
        /*"      *           EXCLUSIVO PARA O SIGPF                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 23 - DEMANDA  597719                                  *      */
        /*"      *               NOVA REGRA PARA SENSIBILIZA��O DE RENOVA��O DE   *      */
        /*"      *               APOLICE ESPECIFICA APOS INCLUS�O DE NOVO PLANO   *      */
        /*"      *               COM TIPO MOVIMENTO = 1 NAS APLICA�OES:           *      */
        /*"      *               VGICA - INCLUSAO PLANO CAPITAL UNICO             *      */
        /*"      *               VGIDA - INCLUSAO PLANO CAPITAL DIFERENCIADO      *      */
        /*"      *               VGIEA - INCLUSAO PLANO CAPITAL MULTIPLO SALARIAL *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/09/2024 - BRICE HO                                     *      */
        /*"      *                                       PROCURE POR V.23         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22 - DEMANDA  597719                                  *      */
        /*"      *               CORRECAO AJUSTE PROPOFID-SITUACAO-ENVIO PARA     *      */
        /*"      *               APOLICE ESPECIFICA.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/09/2024 - BRICE HO                                     *      */
        /*"      *                                       PROCURE POR V.22         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 21 - DEMANDA  597719                                  *      */
        /*"      *               AJUSTE PROPOFID-SITUACAO-ENVIO PARA APOLICE      *      */
        /*"      *               ESPECIFICA.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/08/2024 - BRICE HO                                     *      */
        /*"      *                                       PROCURE POR V.21         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 20 - DEMANDA  597049                                  *      */
        /*"      *               AJUSTAR REGRA PARA CONSIDERAR A CONVERSAO_SICOB. *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/07/2024 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.20         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19 - DEMANDA  578795                                  *      */
        /*"      *               AJUSTES PARA ENVIAR PROPOSTAS APOLICE ESPECIFICA,*      */
        /*"      *               PARA SUBGRUPOS MAIORES QUE 1                     *      */
        /*"      *   EM 04/2024 - THIAGO BLAIER                                   *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 18 - DEMANDA  578795                                  *      */
        /*"      *               AJUSTES PARA ENVIAR PROPOSTAS APOLICE ESPECIFICA,*      */
        /*"      *               O PROGRAMA ESTAVA GERANDO UMA NOVA PROPOSTA      *      */
        /*"      *               PARA ALGUNS CERTIFICADOS                         *      */
        /*"      *   EM 03/2024 - THIAGO BLAIER                                   *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 17 - DEMANDA  425398                                  *      */
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
        /*"      *   DEMAIS HISTORICOS DE MANUTENCAO - VIDE FINAL DO PROGRAMA     *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _AVA2646B { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis AVA2646B
        {
            get
            {
                _.Move(REG_AVA2646B, _AVA2646B); VarBasis.RedefinePassValue(REG_AVA2646B, _AVA2646B, REG_AVA2646B); return _AVA2646B;
            }
        }
        public FileBasis _RVA2646B { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis RVA2646B
        {
            get
            {
                _.Move(REG_RVA2646B, _RVA2646B); VarBasis.RedefinePassValue(REG_RVA2646B, _RVA2646B, REG_RVA2646B); return _RVA2646B;
            }
        }
        /*"01            REG-AVA2646B        PIC X(300).*/
        public StringBasis REG_AVA2646B { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01            REG-RVA2646B        PIC X(100).*/
        public StringBasis REG_RVA2646B { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WS-NUM-PROPOSTA-FIDELIZ       PIC 9(014).*/
        public IntBasis WS_NUM_PROPOSTA_FIDELIZ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
        /*"01    AREA-PROP.*/
        public VA2646B_AREA_PROP AREA_PROP { get; set; } = new VA2646B_AREA_PROP();
        public class VA2646B_AREA_PROP : VarBasis
        {
            /*"    05 WS-NUM-PROPOSTA-SIVPF    PIC  9(0014).*/
            public IntBasis WS_NUM_PROPOSTA_SIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
            /*"    05 WS-NUM-PROPOSTA-SIVPF-R REDEFINES        WS-NUM-PROPOSTA-SIVPF.*/
            private _REDEF_VA2646B_WS_NUM_PROPOSTA_SIVPF_R _ws_num_proposta_sivpf_r { get; set; }
            public _REDEF_VA2646B_WS_NUM_PROPOSTA_SIVPF_R WS_NUM_PROPOSTA_SIVPF_R
            {
                get { _ws_num_proposta_sivpf_r = new _REDEF_VA2646B_WS_NUM_PROPOSTA_SIVPF_R(); _.Move(WS_NUM_PROPOSTA_SIVPF, _ws_num_proposta_sivpf_r); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA_SIVPF, _ws_num_proposta_sivpf_r, WS_NUM_PROPOSTA_SIVPF); _ws_num_proposta_sivpf_r.ValueChanged += () => { _.Move(_ws_num_proposta_sivpf_r, WS_NUM_PROPOSTA_SIVPF); }; return _ws_num_proposta_sivpf_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_sivpf_r, WS_NUM_PROPOSTA_SIVPF); }
            }  //Redefines
            public class _REDEF_VA2646B_WS_NUM_PROPOSTA_SIVPF_R : VarBasis
            {
                /*"       10 WS-NUM-PROPOSTA-AXU1 PIC  9(0001).*/
                public IntBasis WS_NUM_PROPOSTA_AXU1 { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"       10 FILLER               PIC  9(0013).*/
                public IntBasis FILLER_0 { get; set; } = new IntBasis(new PIC("9", "13", "9(0013)."));
                /*"01  WORK-AREA.*/

                public _REDEF_VA2646B_WS_NUM_PROPOSTA_SIVPF_R()
                {
                    WS_NUM_PROPOSTA_AXU1.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA2646B_WORK_AREA WORK_AREA { get; set; } = new VA2646B_WORK_AREA();
        public class VA2646B_WORK_AREA : VarBasis
        {
            /*"    05  WS-NUM-PROPOSTA-SAI          PIC 9(014).*/
            public IntBasis WS_NUM_PROPOSTA_SAI { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  WS-NUM-PROPOSTA-SAI-R        REDEFINES        WS-NUM-PROPOSTA-SAI.*/
            private _REDEF_VA2646B_WS_NUM_PROPOSTA_SAI_R _ws_num_proposta_sai_r { get; set; }
            public _REDEF_VA2646B_WS_NUM_PROPOSTA_SAI_R WS_NUM_PROPOSTA_SAI_R
            {
                get { _ws_num_proposta_sai_r = new _REDEF_VA2646B_WS_NUM_PROPOSTA_SAI_R(); _.Move(WS_NUM_PROPOSTA_SAI, _ws_num_proposta_sai_r); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA_SAI, _ws_num_proposta_sai_r, WS_NUM_PROPOSTA_SAI); _ws_num_proposta_sai_r.ValueChanged += () => { _.Move(_ws_num_proposta_sai_r, WS_NUM_PROPOSTA_SAI); }; return _ws_num_proposta_sai_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_sai_r, WS_NUM_PROPOSTA_SAI); }
            }  //Redefines
            public class _REDEF_VA2646B_WS_NUM_PROPOSTA_SAI_R : VarBasis
            {
                /*"        10 WS-NUM-CANAL-01-SAI       PIC  9(001).*/
                public IntBasis WS_NUM_CANAL_01_SAI { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10 WS-NUM-AGENCIA-04-SAI     PIC  9(004).*/
                public IntBasis WS_NUM_AGENCIA_04_SAI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        10 WS-NUM-PRODUTO-02-SAI     PIC  9(002).*/
                public IntBasis WS_NUM_PRODUTO_02_SAI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        10 WS-NUM-SEQUENCIAL-06-SAI  PIC  9(006).*/
                public IntBasis WS_NUM_SEQUENCIAL_06_SAI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        10 WS-NUM-DIGITO-01-SAI      PIC  9(001).*/
                public IntBasis WS_NUM_DIGITO_01_SAI { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01  WS-NUM-PROPOSTA-COMP        PIC S9(014) COMP.*/

                public _REDEF_VA2646B_WS_NUM_PROPOSTA_SAI_R()
                {
                    WS_NUM_CANAL_01_SAI.ValueChanged += OnValueChanged;
                    WS_NUM_AGENCIA_04_SAI.ValueChanged += OnValueChanged;
                    WS_NUM_PRODUTO_02_SAI.ValueChanged += OnValueChanged;
                    WS_NUM_SEQUENCIAL_06_SAI.ValueChanged += OnValueChanged;
                    WS_NUM_DIGITO_01_SAI.ValueChanged += OnValueChanged;
                }

            }
        }
        public IntBasis WS_NUM_PROPOSTA_COMP { get; set; } = new IntBasis(new PIC("S9", "14", "S9(014)"));
        /*"01   AREA-MONTA.*/
        public VA2646B_AREA_MONTA AREA_MONTA { get; set; } = new VA2646B_AREA_MONTA();
        public class VA2646B_AREA_MONTA : VarBasis
        {
            /*"    05 WS-NUM-PROPOST-MONTA     PIC  9(0015).*/
            public IntBasis WS_NUM_PROPOST_MONTA { get; set; } = new IntBasis(new PIC("9", "15", "9(0015)."));
            /*"    05 WS-NUM-PROPOST-MONTA-R  REDEFINES         WS-NUM-PROPOST-MONTA.*/
            private _REDEF_VA2646B_WS_NUM_PROPOST_MONTA_R _ws_num_propost_monta_r { get; set; }
            public _REDEF_VA2646B_WS_NUM_PROPOST_MONTA_R WS_NUM_PROPOST_MONTA_R
            {
                get { _ws_num_propost_monta_r = new _REDEF_VA2646B_WS_NUM_PROPOST_MONTA_R(); _.Move(WS_NUM_PROPOST_MONTA, _ws_num_propost_monta_r); VarBasis.RedefinePassValue(WS_NUM_PROPOST_MONTA, _ws_num_propost_monta_r, WS_NUM_PROPOST_MONTA); _ws_num_propost_monta_r.ValueChanged += () => { _.Move(_ws_num_propost_monta_r, WS_NUM_PROPOST_MONTA); }; return _ws_num_propost_monta_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_propost_monta_r, WS_NUM_PROPOST_MONTA); }
            }  //Redefines
            public class _REDEF_VA2646B_WS_NUM_PROPOST_MONTA_R : VarBasis
            {
                /*"        10 WS-NUM-CANAL-01          PIC  9(001).*/
                public IntBasis WS_NUM_CANAL_01 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10 WS-NUM-AGENCIA-04        PIC  9(004).*/
                public IntBasis WS_NUM_AGENCIA_04 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        10 WS-NUM-PRODUTO-02        PIC  9(002).*/
                public IntBasis WS_NUM_PRODUTO_02 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        10 WS-NUM-SEQUENCIAL-06     PIC  9(006).*/
                public IntBasis WS_NUM_SEQUENCIAL_06 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        10 WS-NUM-DIGITO-01         PIC  9(002).*/
                public IntBasis WS_NUM_DIGITO_01 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01                  LPARM01X.*/

                public _REDEF_VA2646B_WS_NUM_PROPOST_MONTA_R()
                {
                    WS_NUM_CANAL_01.ValueChanged += OnValueChanged;
                    WS_NUM_AGENCIA_04.ValueChanged += OnValueChanged;
                    WS_NUM_PRODUTO_02.ValueChanged += OnValueChanged;
                    WS_NUM_SEQUENCIAL_06.ValueChanged += OnValueChanged;
                    WS_NUM_DIGITO_01.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA2646B_LPARM01X LPARM01X { get; set; } = new VA2646B_LPARM01X();
        public class VA2646B_LPARM01X : VarBasis
        {
            /*"    05              LPARM01         PIC  X(015).*/
            public StringBasis LPARM01 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"    05              LPARM01-R       REDEFINES   LPARM01.*/
            private _REDEF_VA2646B_LPARM01_R _lparm01_r { get; set; }
            public _REDEF_VA2646B_LPARM01_R LPARM01_R
            {
                get { _lparm01_r = new _REDEF_VA2646B_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
                set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
            }  //Redefines
            public class _REDEF_VA2646B_LPARM01_R : VarBasis
            {
                /*"        10          LPARM01-1       PIC  9(001).*/
                public IntBasis LPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-2       PIC  9(001).*/
                public IntBasis LPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-3       PIC  9(001).*/
                public IntBasis LPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-4       PIC  9(001).*/
                public IntBasis LPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-5       PIC  9(001).*/
                public IntBasis LPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-6       PIC  9(001).*/
                public IntBasis LPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-7       PIC  9(001).*/
                public IntBasis LPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-8       PIC  9(001).*/
                public IntBasis LPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-9       PIC  9(001).*/
                public IntBasis LPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-10      PIC  9(001).*/
                public IntBasis LPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-11      PIC  9(001).*/
                public IntBasis LPARM01_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-12      PIC  9(001).*/
                public IntBasis LPARM01_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-13      PIC  9(001).*/
                public IntBasis LPARM01_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-14      PIC  9(001).*/
                public IntBasis LPARM01_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10          LPARM01-15      PIC  9(001).*/
                public IntBasis LPARM01_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05              CPARM02         PIC S9(004) COMP.*/

                public _REDEF_VA2646B_LPARM01_R()
                {
                    LPARM01_1.ValueChanged += OnValueChanged;
                    LPARM01_2.ValueChanged += OnValueChanged;
                    LPARM01_3.ValueChanged += OnValueChanged;
                    LPARM01_4.ValueChanged += OnValueChanged;
                    LPARM01_5.ValueChanged += OnValueChanged;
                    LPARM01_6.ValueChanged += OnValueChanged;
                    LPARM01_7.ValueChanged += OnValueChanged;
                    LPARM01_8.ValueChanged += OnValueChanged;
                    LPARM01_9.ValueChanged += OnValueChanged;
                    LPARM01_10.ValueChanged += OnValueChanged;
                    LPARM01_11.ValueChanged += OnValueChanged;
                    LPARM01_12.ValueChanged += OnValueChanged;
                    LPARM01_13.ValueChanged += OnValueChanged;
                    LPARM01_14.ValueChanged += OnValueChanged;
                    LPARM01_15.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis CPARM02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05              LPARM03         PIC  9(001).*/
            public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05              LPARM03-R       REDEFINES   LPARM03                           PIC  X(001).*/
            private _REDEF_StringBasis _lparm03_r { get; set; }
            public _REDEF_StringBasis LPARM03_R
            {
                get { _lparm03_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM03, _lparm03_r); VarBasis.RedefinePassValue(LPARM03, _lparm03_r, LPARM03); _lparm03_r.ValueChanged += () => { _.Move(_lparm03_r, LPARM03); }; return _lparm03_r; }
                set { VarBasis.RedefinePassValue(value, _lparm03_r, LPARM03); }
            }  //Redefines
            /*"01  AREA-DE-WORK.*/
        }
        public VA2646B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA2646B_AREA_DE_WORK();
        public class VA2646B_AREA_DE_WORK : VarBasis
        {
            /*"    05  WS-DATA-ACCEPT.*/
            public VA2646B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new VA2646B_WS_DATA_ACCEPT();
            public class VA2646B_WS_DATA_ACCEPT : VarBasis
            {
                /*"        10  WS-ANO-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-MES-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-DIA-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05  WS-HORA-ACCEPT.*/
            }
            public VA2646B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new VA2646B_WS_HORA_ACCEPT();
            public class VA2646B_WS_HORA_ACCEPT : VarBasis
            {
                /*"        10  WS-HOR-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-MIN-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-SEG-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05  WS-DATA-CURR.*/
            }
            public VA2646B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new VA2646B_WS_DATA_CURR();
            public class VA2646B_WS_DATA_CURR : VarBasis
            {
                /*"        10  WS-DIA-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)    VALUE  '/'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"        10  WS-MES-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)    VALUE  '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"        10  WS-ANO-CURR         PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05  WS-HORA-CURR.*/
            }
            public VA2646B_WS_HORA_CURR WS_HORA_CURR { get; set; } = new VA2646B_WS_HORA_CURR();
            public class VA2646B_WS_HORA_CURR : VarBasis
            {
                /*"        10  WS-HOR-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)    VALUE  ':'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"        10  WS-MIN-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)    VALUE  ':'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"        10  WS-SEG-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05  W-ANO-MOV-ABERTO              PIC X(004).*/
            }
            public StringBasis W_ANO_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"    05  W-DATA-SQL                    PIC X(010).*/
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_VA2646B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_VA2646B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_VA2646B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_VA2646B_W_DATA_SQL1 : VarBasis
            {
                /*"        07  W-ANO-SQL                 PIC 9(004).*/
                public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-SQL                 PIC 9(002).*/
                public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-SQL                 PIC 9(002).*/
                public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_VA2646B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_VA2646B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VA2646B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VA2646B_FILLER_5(); _.Move(W_DATA_TRABALHO, _filler_5); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_5, W_DATA_TRABALHO); _filler_5.ValueChanged += () => { _.Move(_filler_5, W_DATA_TRABALHO); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_VA2646B_FILLER_5 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"77    PROM1102                  PIC  X(008)   VALUE 'PROM1102'.*/

                public _REDEF_VA2646B_FILLER_5()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
        }
        public StringBasis PROM1102 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PROM1102");
        /*"77    WS-TEM-AGENCCEF           PIC  X(001)   VALUE  SPACES.*/
        public StringBasis WS_TEM_AGENCCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77    WS-LIDOS-ERRO             PIC  9(006)   VALUE  ZEROS.*/
        public IntBasis WS_LIDOS_ERRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77    SISTEMAS-DATA-MOV-ABERTO-30 PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77    VIND-DTNASC               PIC S9(004)   COMP  VALUE +0.*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ESTCIV               PIC S9(004)   COMP  VALUE +0.*/
        public IntBasis VIND_ESTCIV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-IDE-SEXO             PIC S9(004)   COMP  VALUE +0.*/
        public IntBasis VIND_IDE_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL                 PIC S9(004)   COMP  VALUE -1.*/
        public IntBasis VIND_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77    VIND-NULL-2               PIC S9(004)   COMP  VALUE -1.*/
        public IntBasis VIND_NULL_2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77    VIND-NULL-3               PIC S9(004)   COMP  VALUE -1.*/
        public IntBasis VIND_NULL_3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77    VIND-SEQ-NUM              PIC S9(004)   COMP  VALUE +0.*/
        public IntBasis VIND_SEQ_NUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-SITUACAO            PIC  X(01).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77    WS-QTD-REG1-PRP           PIC  9(006)   VALUE ZEROS.*/
        public IntBasis WS_QTD_REG1_PRP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77    WS-QTD-REG2-PRP           PIC  9(006)   VALUE ZEROS.*/
        public IntBasis WS_QTD_REG2_PRP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77    WS-QTD-REG3-PRP           PIC  9(006)   VALUE ZEROS.*/
        public IntBasis WS_QTD_REG3_PRP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77    WS-QTD-REG4-PRP           PIC  9(006)   VALUE ZEROS.*/
        public IntBasis WS_QTD_REG4_PRP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"01  LINHA-TRACO          PIC  X(080)   VALUE   SPACES.*/
        public StringBasis LINHA_TRACO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
        /*"01  REG-CAB1.*/
        public VA2646B_REG_CAB1 REG_CAB1 { get; set; } = new VA2646B_REG_CAB1();
        public class VA2646B_REG_CAB1 : VarBasis
        {
            /*"    05  FILLER           PIC  X(008)   VALUE   'RVA2646B'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"RVA2646B");
            /*"    05  FILLER           PIC  X(022)   VALUE   SPACES.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
            /*"    05  FILLER           PIC  X(013)   VALUE   'CAIXA SEGUROS'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"CAIXA SEGUROS");
            /*"    05  FILLER           PIC  X(022)   VALUE   SPACES.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
            /*"    05  FILLER           PIC  X(005)   VALUE   'DATA:'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA:");
            /*"    05  CAB1-DATA        PIC  X(010)   VALUE   SPACES.*/
            public StringBasis CAB1_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  FILLER           PIC  X(020)   VALUE   SPACES.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"01  REG-CAB2.*/
        }
        public VA2646B_REG_CAB2 REG_CAB2 { get; set; } = new VA2646B_REG_CAB2();
        public class VA2646B_REG_CAB2 : VarBasis
        {
            /*"    05  FILLER           PIC  X(065)   VALUE   SPACES.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "65", "X(065)"), @"");
            /*"    05  FILLER           PIC  X(005)   VALUE   'HORA:'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"HORA:");
            /*"    05  CAB2-HORA        PIC  X(008)   VALUE   SPACES.*/
            public StringBasis CAB2_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05  FILLER           PIC  X(022)   VALUE   SPACES.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
            /*"01  REG-CAB3.*/
        }
        public VA2646B_REG_CAB3 REG_CAB3 { get; set; } = new VA2646B_REG_CAB3();
        public class VA2646B_REG_CAB3 : VarBasis
        {
            /*"    05  FILLER           PIC  X(005)   VALUE   SPACES.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    05  FILLER           PIC  X(043)          VALUE  'RELATORIO DO MOVIMENTO APOLICE ESPECIFICAS '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"RELATORIO DO MOVIMENTO APOLICE ESPECIFICAS ");
            /*"    05  FILLER           PIC  X(021)          VALUE  'NAO ENVIADAS AO SIGPF'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"NAO ENVIADAS AO SIGPF");
            /*"    05  FILLER           PIC  X(032)   VALUE   SPACES.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
            /*"01  REG-CAB4.*/
        }
        public VA2646B_REG_CAB4 REG_CAB4 { get; set; } = new VA2646B_REG_CAB4();
        public class VA2646B_REG_CAB4 : VarBasis
        {
            /*"    05  FILLER           PIC  X(015)   VALUE   'PROPOSTA'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PROPOSTA");
            /*"    05  FILLER           PIC  X(001)   VALUE   ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  FILLER           PIC  X(013)   VALUE   'AGENCIA VENDA'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"AGENCIA VENDA");
            /*"    05  FILLER           PIC  X(001)   VALUE   ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  FILLER           PIC  X(017)   VALUE   'PREMIO'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"PREMIO");
            /*"    05  FILLER           PIC  X(001)   VALUE   ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  FILLER           PIC  X(040)   VALUE   'DESCRICAO ERRO'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"DESCRICAO ERRO");
            /*"    05  FILLER           PIC  X(012)   VALUE   SPACES.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"01  REG-DETALHE.*/
        }
        public VA2646B_REG_DETALHE REG_DETALHE { get; set; } = new VA2646B_REG_DETALHE();
        public class VA2646B_REG_DETALHE : VarBasis
        {
            /*"    05  DET-PROPOSTA     PIC  9(015)   VALUE  ZEROS.*/
            public IntBasis DET_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05  DET-SEP1         PIC  X(001)   VALUE  ';'.*/
            public StringBasis DET_SEP1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  FILLER           PIC  X(009)   VALUE SPACES.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"    05  DET-AGENCIA      PIC  9(004)   VALUE  ZEROS.*/
            public IntBasis DET_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  DET-SEP2         PIC  X(001)   VALUE  ';'.*/
            public StringBasis DET_SEP2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  DET-PREMIO       PIC  ZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis DET_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"    05  DET-SEP3         PIC  X(001)   VALUE  ';'.*/
            public StringBasis DET_SEP3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  DET-DESC-ERRO    PIC  X(040)   VALUE  SPACES.*/
            public StringBasis DET_DESC_ERRO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"    05  FILLER           PIC  X(012)   VALUE  SPACES.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"01     VA2646B1O-REG.*/
        }
        public VA2646B_VA2646B1O_REG VA2646B1O_REG { get; set; } = new VA2646B_VA2646B1O_REG();
        public class VA2646B_VA2646B1O_REG : VarBasis
        {
            /*"    05   VA2646B1O-IDENTIFICA         PIC  X(0001).*/
            public StringBasis VA2646B1O_IDENTIFICA { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
            /*"    05   VA2646B1O-REG-H.*/
            public VA2646B_VA2646B1O_REG_H VA2646B1O_REG_H { get; set; } = new VA2646B_VA2646B1O_REG_H();
            public class VA2646B_VA2646B1O_REG_H : VarBasis
            {
                /*"      10 VA2646B1O-NOME-ARQ           PIC  X(0008).*/
                public StringBasis VA2646B1O_NOME_ARQ { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2646B1O-DATA-GER           PIC  X(0008).*/
                public StringBasis VA2646B1O_DATA_GER { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2646B1O-COD-SIST           PIC  9(0001).*/
                public IntBasis VA2646B1O_COD_SIST { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2646B1O-COD-SIST-DEST      PIC  9(0001).*/
                public IntBasis VA2646B1O_COD_SIST_DEST { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2646B1O-SEQ-ARQ            PIC  9(0006).*/
                public IntBasis VA2646B1O_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(0006)."));
                /*"      10 VA2646B1O-TIP-ARQ            PIC  9(0001).*/
                public IntBasis VA2646B1O_TIP_ARQ { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2646B1O-ESPACOS            PIC  X(0274).*/
                public StringBasis VA2646B1O_ESPACOS { get; set; } = new StringBasis(new PIC("X", "274", "X(0274)."), @"");
                /*"    05   VA2646B1O-REG-1   REDEFINES VA2646B1O-REG-H.*/
            }
            private _REDEF_VA2646B_VA2646B1O_REG_1 _va2646b1o_reg_1 { get; set; }
            public _REDEF_VA2646B_VA2646B1O_REG_1 VA2646B1O_REG_1
            {
                get { _va2646b1o_reg_1 = new _REDEF_VA2646B_VA2646B1O_REG_1(); _.Move(VA2646B1O_REG_H, _va2646b1o_reg_1); VarBasis.RedefinePassValue(VA2646B1O_REG_H, _va2646b1o_reg_1, VA2646B1O_REG_H); _va2646b1o_reg_1.ValueChanged += () => { _.Move(_va2646b1o_reg_1, VA2646B1O_REG_H); }; return _va2646b1o_reg_1; }
                set { VarBasis.RedefinePassValue(value, _va2646b1o_reg_1, VA2646B1O_REG_H); }
            }  //Redefines
            public class _REDEF_VA2646B_VA2646B1O_REG_1 : VarBasis
            {
                /*"      10 VA2646B1O-NUM-PROPOSTA-1     PIC  9(0014).*/
                public IntBasis VA2646B1O_NUM_PROPOSTA_1 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2646B1O-NUM-CPFCGC         PIC  9(0014).*/
                public IntBasis VA2646B1O_NUM_CPFCGC { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2646B1O-DATA-NASCTO        PIC  9(0008).*/
                public IntBasis VA2646B1O_DATA_NASCTO { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-NOME               PIC  X(0040).*/
                public StringBasis VA2646B1O_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(0040)."), @"");
                /*"      10 VA2646B1O-TIPO-PESSOA        PIC  9(0001).*/
                public IntBasis VA2646B1O_TIPO_PESSOA { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2646B1O-NUM-RG             PIC  9(0015).*/
                public IntBasis VA2646B1O_NUM_RG { get; set; } = new IntBasis(new PIC("9", "15", "9(0015)."));
                /*"      10 VA2646B1O-ORGAO-EXPED        PIC  X(0005).*/
                public StringBasis VA2646B1O_ORGAO_EXPED { get; set; } = new StringBasis(new PIC("X", "5", "X(0005)."), @"");
                /*"      10 VA2646B1O-UF-ORGAO           PIC  X(0002).*/
                public StringBasis VA2646B1O_UF_ORGAO { get; set; } = new StringBasis(new PIC("X", "2", "X(0002)."), @"");
                /*"      10 VA2646B1O-ESTADO-CIVIL       PIC  9(0001).*/
                public IntBasis VA2646B1O_ESTADO_CIVIL { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2646B1O-SEXO               PIC  9(0001).*/
                public IntBasis VA2646B1O_SEXO { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2646B1O-PROFISSAO          PIC  9(0003).*/
                public IntBasis VA2646B1O_PROFISSAO { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 VA2646B1O-DDD-RESIDENCIA     PIC  9(0003).*/
                public IntBasis VA2646B1O_DDD_RESIDENCIA { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 VA2646B1O-TEL-RESIDENCIA     PIC  9(0009).*/
                public IntBasis VA2646B1O_TEL_RESIDENCIA { get; set; } = new IntBasis(new PIC("9", "9", "9(0009)."));
                /*"      10 VA2646B1O-DDD-COMERCIAL      PIC  9(0003).*/
                public IntBasis VA2646B1O_DDD_COMERCIAL { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 VA2646B1O-TEL-COMERCIAL      PIC  9(0009).*/
                public IntBasis VA2646B1O_TEL_COMERCIAL { get; set; } = new IntBasis(new PIC("9", "9", "9(0009)."));
                /*"      10 VA2646B1O-DDD-FAX            PIC  9(0003).*/
                public IntBasis VA2646B1O_DDD_FAX { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 VA2646B1O-TEL-FAX            PIC  9(0009).*/
                public IntBasis VA2646B1O_TEL_FAX { get; set; } = new IntBasis(new PIC("9", "9", "9(0009)."));
                /*"      10 VA2646B1O-DATA-EXPEDICAO     PIC  9(0008).*/
                public IntBasis VA2646B1O_DATA_EXPEDICAO { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-CODIGO-SEGMENTO    PIC  X(0004).*/
                public StringBasis VA2646B1O_CODIGO_SEGMENTO { get; set; } = new StringBasis(new PIC("X", "4", "X(0004)."), @"");
                /*"      10 VA2646B1O-NOME-CONJUGE       PIC  X(0040).*/
                public StringBasis VA2646B1O_NOME_CONJUGE { get; set; } = new StringBasis(new PIC("X", "40", "X(0040)."), @"");
                /*"      10 VA2646B1O-DATA-NASCTO-CONJ   PIC  9(0008).*/
                public IntBasis VA2646B1O_DATA_NASCTO_CONJ { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-PROFISSAO-CONJ     PIC  9(0003).*/
                public IntBasis VA2646B1O_PROFISSAO_CONJ { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 VA2646B1O-EMAIL              PIC  X(0050).*/
                public StringBasis VA2646B1O_EMAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(0050)."), @"");
                /*"      10 VA2646B1O-DESCR-PROFISSAO    PIC  X(0040).*/
                public StringBasis VA2646B1O_DESCR_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "40", "X(0040)."), @"");
                /*"      10 FILLER                       PIC  X(0006).*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "6", "X(0006)."), @"");
                /*"    05   VA2646B1O-REG-2   REDEFINES VA2646B1O-REG-1.*/

                public _REDEF_VA2646B_VA2646B1O_REG_1()
                {
                    VA2646B1O_NUM_PROPOSTA_1.ValueChanged += OnValueChanged;
                    VA2646B1O_NUM_CPFCGC.ValueChanged += OnValueChanged;
                    VA2646B1O_DATA_NASCTO.ValueChanged += OnValueChanged;
                    VA2646B1O_NOME.ValueChanged += OnValueChanged;
                    VA2646B1O_TIPO_PESSOA.ValueChanged += OnValueChanged;
                    VA2646B1O_NUM_RG.ValueChanged += OnValueChanged;
                    VA2646B1O_ORGAO_EXPED.ValueChanged += OnValueChanged;
                    VA2646B1O_UF_ORGAO.ValueChanged += OnValueChanged;
                    VA2646B1O_ESTADO_CIVIL.ValueChanged += OnValueChanged;
                    VA2646B1O_SEXO.ValueChanged += OnValueChanged;
                    VA2646B1O_PROFISSAO.ValueChanged += OnValueChanged;
                    VA2646B1O_DDD_RESIDENCIA.ValueChanged += OnValueChanged;
                    VA2646B1O_TEL_RESIDENCIA.ValueChanged += OnValueChanged;
                    VA2646B1O_DDD_COMERCIAL.ValueChanged += OnValueChanged;
                    VA2646B1O_TEL_COMERCIAL.ValueChanged += OnValueChanged;
                    VA2646B1O_DDD_FAX.ValueChanged += OnValueChanged;
                    VA2646B1O_TEL_FAX.ValueChanged += OnValueChanged;
                    VA2646B1O_DATA_EXPEDICAO.ValueChanged += OnValueChanged;
                    VA2646B1O_CODIGO_SEGMENTO.ValueChanged += OnValueChanged;
                    VA2646B1O_NOME_CONJUGE.ValueChanged += OnValueChanged;
                    VA2646B1O_DATA_NASCTO_CONJ.ValueChanged += OnValueChanged;
                    VA2646B1O_PROFISSAO_CONJ.ValueChanged += OnValueChanged;
                    VA2646B1O_EMAIL.ValueChanged += OnValueChanged;
                    VA2646B1O_DESCR_PROFISSAO.ValueChanged += OnValueChanged;
                    FILLER_29.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2646B_VA2646B1O_REG_2 _va2646b1o_reg_2 { get; set; }
            public _REDEF_VA2646B_VA2646B1O_REG_2 VA2646B1O_REG_2
            {
                get { _va2646b1o_reg_2 = new _REDEF_VA2646B_VA2646B1O_REG_2(); _.Move(VA2646B1O_REG_1, _va2646b1o_reg_2); VarBasis.RedefinePassValue(VA2646B1O_REG_1, _va2646b1o_reg_2, VA2646B1O_REG_1); _va2646b1o_reg_2.ValueChanged += () => { _.Move(_va2646b1o_reg_2, VA2646B1O_REG_1); }; return _va2646b1o_reg_2; }
                set { VarBasis.RedefinePassValue(value, _va2646b1o_reg_2, VA2646B1O_REG_1); }
            }  //Redefines
            public class _REDEF_VA2646B_VA2646B1O_REG_2 : VarBasis
            {
                /*"      10 VA2646B1O-NUM-PROPOSTA-2     PIC  9(0014).*/
                public IntBasis VA2646B1O_NUM_PROPOSTA_2 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2646B1O-TIPO-ENDERECO      PIC  9(0001).*/
                public IntBasis VA2646B1O_TIPO_ENDERECO { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2646B1O-ENDERECO           PIC  X(0050).*/
                public StringBasis VA2646B1O_ENDERECO { get; set; } = new StringBasis(new PIC("X", "50", "X(0050)."), @"");
                /*"      10 VA2646B1O-BAIRRO             PIC  X(0030).*/
                public StringBasis VA2646B1O_BAIRRO { get; set; } = new StringBasis(new PIC("X", "30", "X(0030)."), @"");
                /*"      10 VA2646B1O-CIDADE             PIC  X(0035).*/
                public StringBasis VA2646B1O_CIDADE { get; set; } = new StringBasis(new PIC("X", "35", "X(0035)."), @"");
                /*"      10 VA2646B1O-UF                 PIC  X(0002).*/
                public StringBasis VA2646B1O_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(0002)."), @"");
                /*"      10 VA2646B1O-CEP                PIC  9(0008).*/
                public IntBasis VA2646B1O_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 FILLER                       PIC  X(0159).*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "159", "X(0159)."), @"");
                /*"    05   VA2646B1O-REG-3   REDEFINES VA2646B1O-REG-2.*/

                public _REDEF_VA2646B_VA2646B1O_REG_2()
                {
                    VA2646B1O_NUM_PROPOSTA_2.ValueChanged += OnValueChanged;
                    VA2646B1O_TIPO_ENDERECO.ValueChanged += OnValueChanged;
                    VA2646B1O_ENDERECO.ValueChanged += OnValueChanged;
                    VA2646B1O_BAIRRO.ValueChanged += OnValueChanged;
                    VA2646B1O_CIDADE.ValueChanged += OnValueChanged;
                    VA2646B1O_UF.ValueChanged += OnValueChanged;
                    VA2646B1O_CEP.ValueChanged += OnValueChanged;
                    FILLER_30.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2646B_VA2646B1O_REG_3 _va2646b1o_reg_3 { get; set; }
            public _REDEF_VA2646B_VA2646B1O_REG_3 VA2646B1O_REG_3
            {
                get { _va2646b1o_reg_3 = new _REDEF_VA2646B_VA2646B1O_REG_3(); _.Move(VA2646B1O_REG_2, _va2646b1o_reg_3); VarBasis.RedefinePassValue(VA2646B1O_REG_2, _va2646b1o_reg_3, VA2646B1O_REG_2); _va2646b1o_reg_3.ValueChanged += () => { _.Move(_va2646b1o_reg_3, VA2646B1O_REG_2); }; return _va2646b1o_reg_3; }
                set { VarBasis.RedefinePassValue(value, _va2646b1o_reg_3, VA2646B1O_REG_2); }
            }  //Redefines
            public class _REDEF_VA2646B_VA2646B1O_REG_3 : VarBasis
            {
                /*"      10 VA2646B1O-NUM-PROPOSTA-3     PIC  9(0014).*/
                public IntBasis VA2646B1O_NUM_PROPOSTA_3 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2646B1O-NUM-PRODUTO        PIC  9(0004).*/
                public IntBasis VA2646B1O_NUM_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(0004)."));
                /*"      10 VA2646B1O-AGENCIA-VENDA      PIC  9(0004).*/
                public IntBasis VA2646B1O_AGENCIA_VENDA { get; set; } = new IntBasis(new PIC("9", "4", "9(0004)."));
                /*"      10 VA2646B1O-DATA-PROPOSTA      PIC  9(0008).*/
                public IntBasis VA2646B1O_DATA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-TIPO-PAGTO         PIC  9(0001).*/
                public IntBasis VA2646B1O_TIPO_PAGTO { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                /*"      10 VA2646B1O-CONTA.*/
                public VA2646B_VA2646B1O_CONTA VA2646B1O_CONTA { get; set; } = new VA2646B_VA2646B1O_CONTA();
                public class VA2646B_VA2646B1O_CONTA : VarBasis
                {
                    /*"         15 VA2646B1O-AGENCIA-DEBITO  PIC  9(0004).*/
                    public IntBasis VA2646B1O_AGENCIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(0004)."));
                    /*"         15 VA2646B1O-OPERACAO        PIC  9(0004).*/
                    public IntBasis VA2646B1O_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(0004)."));
                    /*"         15 VA2646B1O-NUM-CONTA       PIC  9(0012).*/
                    public IntBasis VA2646B1O_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(0012)."));
                    /*"         15 VA2646B1O-DIG-CONTA       PIC  9(0001).*/
                    public IntBasis VA2646B1O_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                    /*"      10 VA2646B1O-CARTAO REDEFINES VA2646B1O-CONTA.*/

                    public VA2646B_VA2646B1O_CONTA()
                    {
                        VA2646B1O_AGENCIA_DEBITO.ValueChanged += OnValueChanged;
                        VA2646B1O_OPERACAO.ValueChanged += OnValueChanged;
                        VA2646B1O_NUM_CONTA.ValueChanged += OnValueChanged;
                        VA2646B1O_DIG_CONTA.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_VA2646B_VA2646B1O_CARTAO _va2646b1o_cartao { get; set; }
                public _REDEF_VA2646B_VA2646B1O_CARTAO VA2646B1O_CARTAO
                {
                    get { _va2646b1o_cartao = new _REDEF_VA2646B_VA2646B1O_CARTAO(); _.Move(VA2646B1O_CONTA, _va2646b1o_cartao); VarBasis.RedefinePassValue(VA2646B1O_CONTA, _va2646b1o_cartao, VA2646B1O_CONTA); _va2646b1o_cartao.ValueChanged += () => { _.Move(_va2646b1o_cartao, VA2646B1O_CONTA); }; return _va2646b1o_cartao; }
                    set { VarBasis.RedefinePassValue(value, _va2646b1o_cartao, VA2646B1O_CONTA); }
                }  //Redefines
                public class _REDEF_VA2646B_VA2646B1O_CARTAO : VarBasis
                {
                    /*"         15 VA2646B1O-FILLER          PIC  X(0005).*/
                    public StringBasis VA2646B1O_FILLER { get; set; } = new StringBasis(new PIC("X", "5", "X(0005)."), @"");
                    /*"         15 VA2646B1O-NUM-CARTAO      PIC  X(0016).*/
                    public StringBasis VA2646B1O_NUM_CARTAO { get; set; } = new StringBasis(new PIC("X", "16", "X(0016)."), @"");
                    /*"      10 VA2646B1O-SAUDE-TITULAR      PIC  X(0007).*/

                    public _REDEF_VA2646B_VA2646B1O_CARTAO()
                    {
                        VA2646B1O_FILLER.ValueChanged += OnValueChanged;
                        VA2646B1O_NUM_CARTAO.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis VA2646B1O_SAUDE_TITULAR { get; set; } = new StringBasis(new PIC("X", "7", "X(0007)."), @"");
                /*"      10 VA2646B1O-SAUDE-CONJUGE      PIC  X(0007).*/
                public StringBasis VA2646B1O_SAUDE_CONJUGE { get; set; } = new StringBasis(new PIC("X", "7", "X(0007)."), @"");
                /*"      10 VA2646B1O-NUM-MATR-VENDEDOR  PIC  9(0008).*/
                public IntBasis VA2646B1O_NUM_MATR_VENDEDOR { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-VAL-PREMIO-TOTAL   PIC  9(0014)V99.*/
                public DoubleBasis VA2646B1O_VAL_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "14", "9(0014)V99."), 2);
                /*"      10 VA2646B1O-SIT-APOSENT-INVAL  PIC  X(0001).*/
                public StringBasis VA2646B1O_SIT_APOSENT_INVAL { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
                /*"      10 VA2646B1O-SIT-RENOVACAO-AUT  PIC  X(0001).*/
                public StringBasis VA2646B1O_SIT_RENOVACAO_AUT { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
                /*"      10 VA2646B1O-DIA-VENCIMENTO     PIC  9(0002).*/
                public IntBasis VA2646B1O_DIA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(0002)."));
                /*"      10 VA2646B1O-PERC-DESCONTO      PIC  9(0003)V99.*/
                public DoubleBasis VA2646B1O_PERC_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(0003)V99."), 2);
                /*"      10 VA2646B1O-EMPRESA-CONVEN     PIC  X(0040).*/
                public StringBasis VA2646B1O_EMPRESA_CONVEN { get; set; } = new StringBasis(new PIC("X", "40", "X(0040)."), @"");
                /*"      10 VA2646B1O-CNPJ-EMPRESA-CONV  PIC  9(0014).*/
                public IntBasis VA2646B1O_CNPJ_EMPRESA_CONV { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
                /*"      10 VA2646B1O-FILLER             PIC  X(0003).*/
                public StringBasis VA2646B1O_FILLER_0 { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"      10 VA2646B1O-SIT-PROPOSTA       PIC  X(0003).*/
                public StringBasis VA2646B1O_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"      10 VA2646B1O-SIT-COBRANCA       PIC  X(0003).*/
                public StringBasis VA2646B1O_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"      10 VA2646B1O-MOT-SITUACAO       PIC  9(0003).*/
                public IntBasis VA2646B1O_MOT_SITUACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(0003)."));
                /*"      10 VA2646B1O-OPCAO-COBERTURA    PIC  X(0001).*/
                public StringBasis VA2646B1O_OPCAO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
                /*"      10 VA2646B1O-COD-PLANO          PIC  9(0004).*/
                public IntBasis VA2646B1O_COD_PLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(0004)."));
                /*"      10 VA2646B1O-BRANCO             PIC  X(0129).*/
                public StringBasis VA2646B1O_BRANCO { get; set; } = new StringBasis(new PIC("X", "129", "X(0129)."), @"");
                /*"      10 VA2646B1O-FILLER REDEFINES   VA2646B1O-BRANCO.*/
                private _REDEF_VA2646B_VA2646B1O_FILLER_1 _va2646b1o_filler_1 { get; set; }
                public _REDEF_VA2646B_VA2646B1O_FILLER_1 VA2646B1O_FILLER_1
                {
                    get { _va2646b1o_filler_1 = new _REDEF_VA2646B_VA2646B1O_FILLER_1(); _.Move(VA2646B1O_BRANCO, _va2646b1o_filler_1); VarBasis.RedefinePassValue(VA2646B1O_BRANCO, _va2646b1o_filler_1, VA2646B1O_BRANCO); _va2646b1o_filler_1.ValueChanged += () => { _.Move(_va2646b1o_filler_1, VA2646B1O_BRANCO); }; return _va2646b1o_filler_1; }
                    set { VarBasis.RedefinePassValue(value, _va2646b1o_filler_1, VA2646B1O_BRANCO); }
                }  //Redefines
                public class _REDEF_VA2646B_VA2646B1O_FILLER_1 : VarBasis
                {
                    /*"         15 VA2646B1O-DATA-AUTENT     PIC  X(0008).*/
                    public StringBasis VA2646B1O_DATA_AUTENT { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                    /*"         15 VA2646B1O-VR-PAGO-SICOB   PIC  9(0013)V99.*/
                    public DoubleBasis VA2646B1O_VR_PAGO_SICOB { get; set; } = new DoubleBasis(new PIC("9", "13", "9(0013)V99."), 2);
                    /*"         15 VA2646B1O-AGENCIA-PAGTO   PIC  9(0004).*/
                    public IntBasis VA2646B1O_AGENCIA_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(0004)."));
                    /*"         15 VA2646B1O-TARIFA-COBRANCA PIC  9(0013)V99.*/
                    public DoubleBasis VA2646B1O_TARIFA_COBRANCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(0013)V99."), 2);
                    /*"         15 VA2646B1O-DATA-CRD-SASSE  PIC  9(0008).*/
                    public IntBasis VA2646B1O_DATA_CRD_SASSE { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                    /*"         15 VA2646B1O-VALOR-COMISSAO  PIC  9(0013)V99.*/
                    public DoubleBasis VA2646B1O_VALOR_COMISSAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(0013)V99."), 2);
                    /*"         15 VA2646B1O-PERIPGTO        PIC  9(0002).*/
                    public IntBasis VA2646B1O_PERIPGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(0002)."));
                    /*"         15 VA2646B1O-OPCAO-CONJUGE   PIC  X(0001).*/
                    public StringBasis VA2646B1O_OPCAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
                    /*"         15 VA2646B1O-TIPO-RESIDENCIA PIC  9(0001).*/
                    public IntBasis VA2646B1O_TIPO_RESIDENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(0001)."));
                    /*"         15 VA2646B1O-VALOR-IOF       PIC  9(0006)V99.*/
                    public DoubleBasis VA2646B1O_VALOR_IOF { get; set; } = new DoubleBasis(new PIC("9", "6", "9(0006)V99."), 2);
                    /*"         15 VA2646B1O-CUSTO-APOLICE   PIC  9(0006)V99.*/
                    public DoubleBasis VA2646B1O_CUSTO_APOLICE { get; set; } = new DoubleBasis(new PIC("9", "6", "9(0006)V99."), 2);
                    /*"         15 VA2646B1O-SPACES          PIC  X(0005).*/
                    public StringBasis VA2646B1O_SPACES { get; set; } = new StringBasis(new PIC("X", "5", "X(0005)."), @"");
                    /*"         15 VA2646B1O-NUM-SICOB       PIC  9(0015).*/
                    public IntBasis VA2646B1O_NUM_SICOB { get; set; } = new IntBasis(new PIC("9", "15", "9(0015)."));
                    /*"         15 VA2646B1O-ORIGEM-PROP     PIC  9(0002).*/
                    public IntBasis VA2646B1O_ORIGEM_PROP { get; set; } = new IntBasis(new PIC("9", "2", "9(0002)."));
                    /*"         15 VA2646B1O-SEQ-ARQUIVO     PIC  9(0006).*/
                    public IntBasis VA2646B1O_SEQ_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "6", "9(0006)."));
                    /*"         15 VA2646B1O-SEQ-REGISTRO    PIC  9(0006).*/
                    public IntBasis VA2646B1O_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(0006)."));
                    /*"         15 FILLER                    PIC  X(0010).*/
                    public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "10", "X(0010)."), @"");
                    /*"    05   REG-BENEFIC   REDEFINES VA2646B1O-REG-3.*/

                    public _REDEF_VA2646B_VA2646B1O_FILLER_1()
                    {
                        VA2646B1O_DATA_AUTENT.ValueChanged += OnValueChanged;
                        VA2646B1O_VR_PAGO_SICOB.ValueChanged += OnValueChanged;
                        VA2646B1O_AGENCIA_PAGTO.ValueChanged += OnValueChanged;
                        VA2646B1O_TARIFA_COBRANCA.ValueChanged += OnValueChanged;
                        VA2646B1O_DATA_CRD_SASSE.ValueChanged += OnValueChanged;
                        VA2646B1O_VALOR_COMISSAO.ValueChanged += OnValueChanged;
                        VA2646B1O_PERIPGTO.ValueChanged += OnValueChanged;
                        VA2646B1O_OPCAO_CONJUGE.ValueChanged += OnValueChanged;
                        VA2646B1O_TIPO_RESIDENCIA.ValueChanged += OnValueChanged;
                        VA2646B1O_VALOR_IOF.ValueChanged += OnValueChanged;
                        VA2646B1O_CUSTO_APOLICE.ValueChanged += OnValueChanged;
                        VA2646B1O_SPACES.ValueChanged += OnValueChanged;
                        VA2646B1O_NUM_SICOB.ValueChanged += OnValueChanged;
                        VA2646B1O_ORIGEM_PROP.ValueChanged += OnValueChanged;
                        VA2646B1O_SEQ_ARQUIVO.ValueChanged += OnValueChanged;
                        VA2646B1O_SEQ_REGISTRO.ValueChanged += OnValueChanged;
                        FILLER_31.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VA2646B_VA2646B1O_REG_3()
                {
                    VA2646B1O_NUM_PROPOSTA_3.ValueChanged += OnValueChanged;
                    VA2646B1O_NUM_PRODUTO.ValueChanged += OnValueChanged;
                    VA2646B1O_AGENCIA_VENDA.ValueChanged += OnValueChanged;
                    VA2646B1O_DATA_PROPOSTA.ValueChanged += OnValueChanged;
                    VA2646B1O_TIPO_PAGTO.ValueChanged += OnValueChanged;
                    VA2646B1O_CONTA.ValueChanged += OnValueChanged;
                    VA2646B1O_CARTAO.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2646B_REG_BENEFIC _reg_benefic { get; set; }
            public _REDEF_VA2646B_REG_BENEFIC REG_BENEFIC
            {
                get { _reg_benefic = new _REDEF_VA2646B_REG_BENEFIC(); _.Move(VA2646B1O_REG_3, _reg_benefic); VarBasis.RedefinePassValue(VA2646B1O_REG_3, _reg_benefic, VA2646B1O_REG_3); _reg_benefic.ValueChanged += () => { _.Move(_reg_benefic, VA2646B1O_REG_3); }; return _reg_benefic; }
                set { VarBasis.RedefinePassValue(value, _reg_benefic, VA2646B1O_REG_3); }
            }  //Redefines
            public class _REDEF_VA2646B_REG_BENEFIC : VarBasis
            {
                /*"       10  R4-NUM-PROPOSTA             PIC  9(014).*/
                public IntBasis R4_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"       10  R4-NOME                     PIC  X(040).*/
                public StringBasis R4_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10  R4-DATA-NASCIMENTO          PIC  9(008).*/
                public IntBasis R4_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10  R4-CGC-CPF                  PIC  9(014).*/
                public IntBasis R4_CGC_CPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"       10  R4-SEXO                     PIC  9(001).*/
                public IntBasis R4_SEXO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10  R4-ESTADO-CIVIL             PIC  9(001).*/
                public IntBasis R4_ESTADO_CIVIL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10  R4-GRAU-PARENTESCO          PIC  9(001).*/
                public IntBasis R4_GRAU_PARENTESCO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10  R4-PCT-FGB                  PIC  9(003)V99.*/
                public DoubleBasis R4_PCT_FGB { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"       10  R4-PCT-PECULIO              PIC  9(003)V99.*/
                public DoubleBasis R4_PCT_PECULIO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"       10  R4-PCT-PENSAO               PIC  9(003)V99.*/
                public DoubleBasis R4_PCT_PENSAO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"       10  R4-PCT-PARTICIP             PIC  9(003)V99.*/
                public DoubleBasis R4_PCT_PARTICIP { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"       10  R4-QTDE-TITULOS             PIC  9(003).*/
                public IntBasis R4_QTDE_TITULOS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  R4-DESCR-PARENTESCO         PIC  X(030).*/
                public StringBasis R4_DESCR_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"       10  R4-NOM-MAE                  PIC  X(040).*/
                public StringBasis R4_NOM_MAE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10  R4-NUM-CART                 PIC  9(015).*/
                public IntBasis R4_NUM_CART { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10  FILLER                      PIC  X(112).*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "112", "X(112)."), @"");
                /*"    05   VA2646B1O-REG-T   REDEFINES VA2646B1O-REG-3.*/

                public _REDEF_VA2646B_REG_BENEFIC()
                {
                    R4_NUM_PROPOSTA.ValueChanged += OnValueChanged;
                    R4_NOME.ValueChanged += OnValueChanged;
                    R4_DATA_NASCIMENTO.ValueChanged += OnValueChanged;
                    R4_CGC_CPF.ValueChanged += OnValueChanged;
                    R4_SEXO.ValueChanged += OnValueChanged;
                    R4_ESTADO_CIVIL.ValueChanged += OnValueChanged;
                    R4_GRAU_PARENTESCO.ValueChanged += OnValueChanged;
                    R4_PCT_FGB.ValueChanged += OnValueChanged;
                    R4_PCT_PECULIO.ValueChanged += OnValueChanged;
                    R4_PCT_PENSAO.ValueChanged += OnValueChanged;
                    R4_PCT_PARTICIP.ValueChanged += OnValueChanged;
                    R4_QTDE_TITULOS.ValueChanged += OnValueChanged;
                    R4_DESCR_PARENTESCO.ValueChanged += OnValueChanged;
                    R4_NOM_MAE.ValueChanged += OnValueChanged;
                    R4_NUM_CART.ValueChanged += OnValueChanged;
                    FILLER_32.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA2646B_VA2646B1O_REG_T _va2646b1o_reg_t { get; set; }
            public _REDEF_VA2646B_VA2646B1O_REG_T VA2646B1O_REG_T
            {
                get { _va2646b1o_reg_t = new _REDEF_VA2646B_VA2646B1O_REG_T(); _.Move(VA2646B1O_REG_3, _va2646b1o_reg_t); VarBasis.RedefinePassValue(VA2646B1O_REG_3, _va2646b1o_reg_t, VA2646B1O_REG_3); _va2646b1o_reg_t.ValueChanged += () => { _.Move(_va2646b1o_reg_t, VA2646B1O_REG_3); }; return _va2646b1o_reg_t; }
                set { VarBasis.RedefinePassValue(value, _va2646b1o_reg_t, VA2646B1O_REG_3); }
            }  //Redefines
            public class _REDEF_VA2646B_VA2646B1O_REG_T : VarBasis
            {
                /*"      10 VA2646B1O-NOME-ARQ-T         PIC  X(0008).*/
                public StringBasis VA2646B1O_NOME_ARQ_T { get; set; } = new StringBasis(new PIC("X", "8", "X(0008)."), @"");
                /*"      10 VA2646B1O-QTDE-REG-0         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-1         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-2         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-3         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-4         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-5         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-6         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-7         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-8         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-9         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-A         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_A { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-B         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_B { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-C         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_C { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-D         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_D { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-E         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_E { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-F         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_F { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-G         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_G { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-H         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_H { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-I         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_I { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 VA2646B1O-QTDE-REG-J         PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_J { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 FILLER                       PIC  X(0081).*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "81", "X(0081)."), @"");
                /*"      10 VA2646B1O-QTDE-REG-TOTAL     PIC  9(0008).*/
                public IntBasis VA2646B1O_QTDE_REG_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(0008)."));
                /*"      10 FILLER                       PIC  X(0042).*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "42", "X(0042)."), @"");
                /*"01  WORK-AREA.*/

                public _REDEF_VA2646B_VA2646B1O_REG_T()
                {
                    VA2646B1O_NOME_ARQ_T.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_0.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_1.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_2.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_3.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_4.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_5.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_6.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_7.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_8.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_9.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_A.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_B.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_C.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_D.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_E.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_F.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_G.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_H.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_I.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_J.ValueChanged += OnValueChanged;
                    FILLER_33.ValueChanged += OnValueChanged;
                    VA2646B1O_QTDE_REG_TOTAL.ValueChanged += OnValueChanged;
                    FILLER_34.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA2646B_WORK_AREA_0 WORK_AREA_0 { get; set; } = new VA2646B_WORK_AREA_0();
        public class VA2646B_WORK_AREA_0 : VarBasis
        {
            /*"    05  WS-NUM-PROPOSTA-EXC         PIC 9(014).*/
            public IntBasis WS_NUM_PROPOSTA_EXC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  WS-NUM-PROPOSTA-R         REDEFINES        WS-NUM-PROPOSTA-EXC.*/
            private _REDEF_VA2646B_WS_NUM_PROPOSTA_R _ws_num_proposta_r { get; set; }
            public _REDEF_VA2646B_WS_NUM_PROPOSTA_R WS_NUM_PROPOSTA_R
            {
                get { _ws_num_proposta_r = new _REDEF_VA2646B_WS_NUM_PROPOSTA_R(); _.Move(WS_NUM_PROPOSTA_EXC, _ws_num_proposta_r); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA_EXC, _ws_num_proposta_r, WS_NUM_PROPOSTA_EXC); _ws_num_proposta_r.ValueChanged += () => { _.Move(_ws_num_proposta_r, WS_NUM_PROPOSTA_EXC); }; return _ws_num_proposta_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_r, WS_NUM_PROPOSTA_EXC); }
            }  //Redefines
            public class _REDEF_VA2646B_WS_NUM_PROPOSTA_R : VarBasis
            {
                /*"        10  WS-NUM-PROPOSTA-02    PIC 9(002).*/
                public IntBasis WS_NUM_PROPOSTA_02 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        10  WS-NUM-PROPOSTA-11    PIC 9(011).*/
                public IntBasis WS_NUM_PROPOSTA_11 { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"        10  WS-NUM-PROPOSTA-01    PIC 9(001).*/
                public IntBasis WS_NUM_PROPOSTA_01 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  WS-NUM-PROPOSTA-DESLOC        PIC 9(014).*/

                public _REDEF_VA2646B_WS_NUM_PROPOSTA_R()
                {
                    WS_NUM_PROPOSTA_02.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_11.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_01.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUM_PROPOSTA_DESLOC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  WS-NUM-PROPOSTA-R             REDEFINES        WS-NUM-PROPOSTA-DESLOC.*/
            private _REDEF_VA2646B_WS_NUM_PROPOSTA_R_0 _ws_num_proposta_r_0 { get; set; }
            public _REDEF_VA2646B_WS_NUM_PROPOSTA_R_0 WS_NUM_PROPOSTA_R_0
            {
                get { _ws_num_proposta_r_0 = new _REDEF_VA2646B_WS_NUM_PROPOSTA_R_0(); _.Move(WS_NUM_PROPOSTA_DESLOC, _ws_num_proposta_r_0); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA_DESLOC, _ws_num_proposta_r_0, WS_NUM_PROPOSTA_DESLOC); _ws_num_proposta_r_0.ValueChanged += () => { _.Move(_ws_num_proposta_r_0, WS_NUM_PROPOSTA_DESLOC); }; return _ws_num_proposta_r_0; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_r_0, WS_NUM_PROPOSTA_DESLOC); }
            }  //Redefines
            public class _REDEF_VA2646B_WS_NUM_PROPOSTA_R_0 : VarBasis
            {
                /*"        10  WS-NUM-PROPOSTA-DESLOC-13 PIC 9(013).*/
                public IntBasis WS_NUM_PROPOSTA_DESLOC_13 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        10  WS-NUM-PROPOSTA-DESLOC-01 PIC 9(001).*/
                public IntBasis WS_NUM_PROPOSTA_DESLOC_01 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  WS-NUM-PROPOSTA           PIC 9(014).*/

                public _REDEF_VA2646B_WS_NUM_PROPOSTA_R_0()
                {
                    WS_NUM_PROPOSTA_DESLOC_13.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_DESLOC_01.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  WS-NUM-PROPOSTA-R         REDEFINES        WS-NUM-PROPOSTA.*/
            private _REDEF_VA2646B_WS_NUM_PROPOSTA_R_1 _ws_num_proposta_r_1 { get; set; }
            public _REDEF_VA2646B_WS_NUM_PROPOSTA_R_1 WS_NUM_PROPOSTA_R_1
            {
                get { _ws_num_proposta_r_1 = new _REDEF_VA2646B_WS_NUM_PROPOSTA_R_1(); _.Move(WS_NUM_PROPOSTA, _ws_num_proposta_r_1); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA, _ws_num_proposta_r_1, WS_NUM_PROPOSTA); _ws_num_proposta_r_1.ValueChanged += () => { _.Move(_ws_num_proposta_r_1, WS_NUM_PROPOSTA); }; return _ws_num_proposta_r_1; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_r_1, WS_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA2646B_WS_NUM_PROPOSTA_R_1 : VarBasis
            {
                /*"        10  WS-NUM-PROPOSTA-9     PIC 9(013).*/
                public IntBasis WS_NUM_PROPOSTA_9 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        10  WS-NUM-PROPOSTA-0     PIC 9(001).*/
                public IntBasis WS_NUM_PROPOSTA_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  WS-NUM-PROPOSTA-CONVERSAO PIC 9(014).*/

                public _REDEF_VA2646B_WS_NUM_PROPOSTA_R_1()
                {
                    WS_NUM_PROPOSTA_9.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_0.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUM_PROPOSTA_CONVERSAO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  WS-NUM-PROPOSTA-CONVERSAO-R REDEFINES        WS-NUM-PROPOSTA-CONVERSAO.*/
            private _REDEF_VA2646B_WS_NUM_PROPOSTA_CONVERSAO_R _ws_num_proposta_conversao_r { get; set; }
            public _REDEF_VA2646B_WS_NUM_PROPOSTA_CONVERSAO_R WS_NUM_PROPOSTA_CONVERSAO_R
            {
                get { _ws_num_proposta_conversao_r = new _REDEF_VA2646B_WS_NUM_PROPOSTA_CONVERSAO_R(); _.Move(WS_NUM_PROPOSTA_CONVERSAO, _ws_num_proposta_conversao_r); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA_CONVERSAO, _ws_num_proposta_conversao_r, WS_NUM_PROPOSTA_CONVERSAO); _ws_num_proposta_conversao_r.ValueChanged += () => { _.Move(_ws_num_proposta_conversao_r, WS_NUM_PROPOSTA_CONVERSAO); }; return _ws_num_proposta_conversao_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_conversao_r, WS_NUM_PROPOSTA_CONVERSAO); }
            }  //Redefines
            public class _REDEF_VA2646B_WS_NUM_PROPOSTA_CONVERSAO_R : VarBasis
            {
                /*"        10  WS-NUM-PROPOSTA-1     PIC 9(001).*/
                public IntBasis WS_NUM_PROPOSTA_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10  WS-NUM-PROPOSTA-13    PIC 9(013).*/
                public IntBasis WS_NUM_PROPOSTA_13 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05  WS-NUM-CERTIFICADO-PROPVA PIC 9(014).*/

                public _REDEF_VA2646B_WS_NUM_PROPOSTA_CONVERSAO_R()
                {
                    WS_NUM_PROPOSTA_1.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_13.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUM_CERTIFICADO_PROPVA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  TAB-OPC-PGTO.*/
            public VA2646B_TAB_OPC_PGTO TAB_OPC_PGTO { get; set; } = new VA2646B_TAB_OPC_PGTO();
            public class VA2646B_TAB_OPC_PGTO : VarBasis
            {
                /*"        10  FILLER                PIC X(011) VALUE '1-DEB CONTA'*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"1-DEB CONTA");
                /*"        10  FILLER                PIC X(011) VALUE '2-POUPANCA '*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"2-POUPANCA ");
                /*"        10  FILLER                PIC X(011) VALUE '3-BOLETO   '*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"3-BOLETO   ");
                /*"        10  FILLER                PIC X(011) VALUE '4-AVERBACAO'*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"4-AVERBACAO");
                /*"        10  FILLER                PIC X(011) VALUE '5-CARTAO   '*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"5-CARTAO   ");
                /*"    05  TAB-OPC-PGTO-RED  REDEFINES  TAB-OPC-PGTO.*/
            }
            private _REDEF_VA2646B_TAB_OPC_PGTO_RED _tab_opc_pgto_red { get; set; }
            public _REDEF_VA2646B_TAB_OPC_PGTO_RED TAB_OPC_PGTO_RED
            {
                get { _tab_opc_pgto_red = new _REDEF_VA2646B_TAB_OPC_PGTO_RED(); _.Move(TAB_OPC_PGTO, _tab_opc_pgto_red); VarBasis.RedefinePassValue(TAB_OPC_PGTO, _tab_opc_pgto_red, TAB_OPC_PGTO); _tab_opc_pgto_red.ValueChanged += () => { _.Move(_tab_opc_pgto_red, TAB_OPC_PGTO); }; return _tab_opc_pgto_red; }
                set { VarBasis.RedefinePassValue(value, _tab_opc_pgto_red, TAB_OPC_PGTO); }
            }  //Redefines
            public class _REDEF_VA2646B_TAB_OPC_PGTO_RED : VarBasis
            {
                /*"      10  TB-OPC-PAGTO            PIC X(011)  OCCURS 5 TIMES.*/
                public ListBasis<StringBasis, string> TB_OPC_PAGTO { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "11", "X(011)"), 5);
                /*"    05        DATA-SQL.*/

                public _REDEF_VA2646B_TAB_OPC_PGTO_RED()
                {
                    TB_OPC_PAGTO.ValueChanged += OnValueChanged;
                }

            }
            public VA2646B_DATA_SQL DATA_SQL { get; set; } = new VA2646B_DATA_SQL();
            public class VA2646B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        DATA-CONV.*/
            }
            public VA2646B_DATA_CONV DATA_CONV { get; set; } = new VA2646B_DATA_CONV();
            public class VA2646B_DATA_CONV : VarBasis
            {
                /*"      10      DIA-CONV            PIC  9(002).*/
                public IntBasis DIA_CONV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-CONV            PIC  9(002).*/
                public IntBasis MES_CONV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
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
            /*"    05        W-FIM-BENEFICIARIOS PIC   X(003) VALUE SPACES.*/
            public StringBasis W_FIM_BENEFICIARIOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05        TEM-CONVERSAO       PIC   X(01)  VALUE  ' '.*/
            public StringBasis TEM_CONVERSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        TEM-PROP-FIDELIZ    PIC   X(01)  VALUE  ' '.*/
            public StringBasis TEM_PROP_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        TEM-RENOVACAO       PIC   X(01)  VALUE  SPACES.*/
            public StringBasis TEM_RENOVACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05        WS-ERRO-RENOV       PIC   X(01)  VALUE  SPACES.*/
            public StringBasis WS_ERRO_RENOV { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
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
            /*"    05        AC-DESP-10          PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_10 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-11          PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_11 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-12          PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_12 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-DESP-13          PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_DESP_13 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WABEND.*/
            public VA2646B_WABEND WABEND { get; set; } = new VA2646B_WABEND();
            public class VA2646B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             ' VA2646B'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA2646B");
                /*"      10      FILLER              PIC  X(026) VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(006) VALUE '000000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"000000");
                /*"      10      FILLER              PIC  X(013) VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"      10      FILLER              PIC  X(014) VALUE             ' *** SQLERRMC '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"      10      WSQLERRMC           PIC  X(070)    VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01            WZEROS              PIC S9(005) VALUE +0 COMP-3.*/
            }
        }
        public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));


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
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PESSOFIS PESSOFIS { get; set; } = new Dclgens.PESSOFIS();
        public Dclgens.PESSOJUR PESSOJUR { get; set; } = new Dclgens.PESSOJUR();
        public Dclgens.IDENTREL IDENTREL { get; set; } = new Dclgens.IDENTREL();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.MOVVGAP MOVVGAP { get; set; } = new Dclgens.MOVVGAP();
        public Dclgens.BENEFICI BENEFICI { get; set; } = new Dclgens.BENEFICI();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.RTPRELAC RTPRELAC { get; set; } = new Dclgens.RTPRELAC();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA2646B_TPROPOVA TPROPOVA { get; set; } = new VA2646B_TPROPOVA();
        public VA2646B_BENEFICIARIOS BENEFICIARIOS { get; set; } = new VA2646B_BENEFICIARIOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string AVA2646B_FILE_NAME_P, string RVA2646B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                AVA2646B.SetFile(AVA2646B_FILE_NAME_P);
                RVA2646B.SetFile(RVA2646B_FILE_NAME_P);

                /*" -625- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -628- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -631- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -631- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -639- MOVE 'R0000' TO WNR-EXEC-SQL. */
            _.Move("R0000", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -640- DISPLAY ' ' */
            _.Display($" ");

            /*" -642- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -650- DISPLAY 'PROGRAMA EM EXECUCAO VA2646B-' 'VERSAO V.23 - DEMANDA 597.719- ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VA2646B-VERSAO V.23 - DEMANDA 597.719- FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -652- DISPLAY 'GERAR ARQ. DE PROPOSTAS PRODUTOS ' 'APOLICE ESPECIFICA E VIDA EXCLUSIVO PARA SIGPF' */
            _.Display($"GERAR ARQ. DE PROPOSTAS PRODUTOS APOLICE ESPECIFICA E VIDA EXCLUSIVO PARA SIGPF");

            /*" -654- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -657- DISPLAY ' ' */
            _.Display($" ");

            /*" -659- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -662- OPEN OUTPUT AVA2646B RVA2646B. */
            AVA2646B.Open(REG_AVA2646B);
            RVA2646B.Open(REG_RVA2646B);

            /*" -664- PERFORM R0200-00-GRAVA-HEADER. */

            R0200_00_GRAVA_HEADER_SECTION();

            /*" -665- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!WORK_AREA_0.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -666- DISPLAY '*** PROBLEMAS NA SISTEMAS' */
                _.Display($"*** PROBLEMAS NA SISTEMAS");

                /*" -667- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -669- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -671- PERFORM R0900-00-DECLARE-PROPOVA. */

            R0900_00_DECLARE_PROPOVA_SECTION();

            /*" -673- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

            /*" -676- PERFORM R1000-00-PROCESSA UNTIL WFIM-PROPOVA EQUAL 'S' . */

            while (!(WORK_AREA_0.WFIM_PROPOVA == "S"))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -678- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -680- PERFORM R8000-00-UPDATE-RELATORI */

            R8000_00_UPDATE_RELATORI_SECTION();

            /*" -682- PERFORM R8100-00-GRAVA-TRAILLER */

            R8100_00_GRAVA_TRAILLER_SECTION();

            /*" -682- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -689- DISPLAY '=============================================' */
            _.Display($"=============================================");

            /*" -690- DISPLAY '------------------ VA2646B ----------------- ' */
            _.Display($"------------------ VA2646B ----------------- ");

            /*" -691- DISPLAY '=============================================' */
            _.Display($"=============================================");

            /*" -692- DISPLAY 'LIDOS PROPOSTAS_VA.............: ' AC-LIDOS. */
            _.Display($"LIDOS PROPOSTAS_VA.............: {WORK_AREA_0.AC_LIDOS}");

            /*" -693- DISPLAY '-------------------------------------------- ' */
            _.Display($"-------------------------------------------- ");

            /*" -694- DISPLAY 'DESPREZADOS PROPOFID...........: ' AC-DESP-0 */
            _.Display($"DESPREZADOS PROPOFID...........: {WORK_AREA_0.AC_DESP_0}");

            /*" -695- DISPLAY 'DESPREZADOS PRODUVG............: ' AC-DESP-1 */
            _.Display($"DESPREZADOS PRODUVG............: {WORK_AREA_0.AC_DESP_1}");

            /*" -696- DISPLAY 'DESPREZADOS CLIENTES...........: ' AC-DESP-2 */
            _.Display($"DESPREZADOS CLIENTES...........: {WORK_AREA_0.AC_DESP_2}");

            /*" -697- DISPLAY 'DESPREZADOS ENDERECO...........: ' AC-DESP-3 */
            _.Display($"DESPREZADOS ENDERECO...........: {WORK_AREA_0.AC_DESP_3}");

            /*" -698- DISPLAY 'DESPREZADOS OPCPAGVI...........: ' AC-DESP-4 */
            _.Display($"DESPREZADOS OPCPAGVI...........: {WORK_AREA_0.AC_DESP_4}");

            /*" -699- DISPLAY 'DESPREZADOS HISCOBPR...........: ' AC-DESP-5 */
            _.Display($"DESPREZADOS HISCOBPR...........: {WORK_AREA_0.AC_DESP_5}");

            /*" -700- DISPLAY 'DESPREZADOS PARCEVID-MEN.......: ' AC-DESP-6 */
            _.Display($"DESPREZADOS PARCEVID-MEN.......: {WORK_AREA_0.AC_DESP_6}");

            /*" -701- DISPLAY 'DESPREZADOS PARCEVID-ANU.......: ' AC-DESP-7 */
            _.Display($"DESPREZADOS PARCEVID-ANU.......: {WORK_AREA_0.AC_DESP_7}");

            /*" -702- DISPLAY 'DESPREZADOS ENDOSSOS...........: ' AC-DESP-8 */
            _.Display($"DESPREZADOS ENDOSSOS...........: {WORK_AREA_0.AC_DESP_8}");

            /*" -703- DISPLAY 'DESPREZADOS AGENCCEF...........: ' AC-DESP-9 */
            _.Display($"DESPREZADOS AGENCCEF...........: {WORK_AREA_0.AC_DESP_9}");

            /*" -704- DISPLAY 'DESPREZADOS VIDAEXCLUSIVO......: ' AC-DESP-10 */
            _.Display($"DESPREZADOS VIDAEXCLUSIVO......: {WORK_AREA_0.AC_DESP_10}");

            /*" -705- DISPLAY 'DESPREZADOS VIDAEXCLUSIVO DUPL.: ' AC-DESP-11 */
            _.Display($"DESPREZADOS VIDAEXCLUSIVO DUPL.: {WORK_AREA_0.AC_DESP_11}");

            /*" -706- DISPLAY 'DESPREZADOS APOL ESPECIF. DUPL.: ' AC-DESP-12 */
            _.Display($"DESPREZADOS APOL ESPECIF. DUPL.: {WORK_AREA_0.AC_DESP_12}");

            /*" -707- DISPLAY 'DESPREZADOS PORTAL FORA PADRAO.: ' AC-DESP-13 */
            _.Display($"DESPREZADOS PORTAL FORA PADRAO.: {WORK_AREA_0.AC_DESP_13}");

            /*" -708- DISPLAY '-------------------------------------------- ' */
            _.Display($"-------------------------------------------- ");

            /*" -709- DISPLAY 'PROPOSTAS GERADAS..............: ' AC-GRAVADOS */
            _.Display($"PROPOSTAS GERADAS..............: {WORK_AREA_0.AC_GRAVADOS}");

            /*" -711- DISPLAY '=============================================' */
            _.Display($"=============================================");

            /*" -713- DISPLAY '*** VA2646B - TERMINO NORMAL ***' */
            _.Display($"*** VA2646B - TERMINO NORMAL ***");

            /*" -713- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -727- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -736- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -739- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -740- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -741- DISPLAY 'SISTEMAS VA NAO ESTA CADASTRADO' */
                    _.Display($"SISTEMAS VA NAO ESTA CADASTRADO");

                    /*" -742- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", WORK_AREA_0.WFIM_V1SISTEMA);

                    /*" -743- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -744- ELSE */
                }
                else
                {


                    /*" -745- DISPLAY 'VA2646B - SISTEMAS VA NAO ESTA CADASTRADO' */
                    _.Display($"VA2646B - SISTEMAS VA NAO ESTA CADASTRADO");

                    /*" -746- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                    /*" -747- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -748- END-IF */
                }


                /*" -750- END-IF. */
            }


            /*" -752- MOVE 'R0110' TO WNR-EXEC-SQL. */
            _.Move("R0110", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -758- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_2 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_2();

            /*" -761- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -762- DISPLAY 'VA2646B - ERRO ACESSO RELATORIOS' */
                _.Display($"VA2646B - ERRO ACESSO RELATORIOS");

                /*" -763- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -764- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -766- END-IF. */
            }


            /*" -767- DISPLAY ' ' */
            _.Display($" ");

            /*" -770- DISPLAY 'PERIODO DE ' RELATORI-DATA-SOLICITACAO ' ATE ' SISTEMAS-DATA-MOV-ABERTO. */

            $"PERIODO DE {RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO} ATE {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

            /*" -770- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -736- EXEC SQL SELECT DATA_MOV_ABERTO , YEAR(DATA_MOV_ABERTO) , DATA_MOV_ABERTO - 30 DAYS INTO :SISTEMAS-DATA-MOV-ABERTO , :W-ANO-MOV-ABERTO , :SISTEMAS-DATA-MOV-ABERTO-30 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.W_ANO_MOV_ABERTO, AREA_DE_WORK.W_ANO_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_30, SISTEMAS_DATA_MOV_ABERTO_30);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-2 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_2()
        {
            /*" -758- EXEC SQL SELECT DATA_SOLICITACAO + 1 DAY INTO :RELATORI-DATA-SOLICITACAO FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'VA' AND COD_USUARIO = 'VA2646B' END-EXEC. */

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
            /*" -784- MOVE 'R0200' TO WNR-EXEC-SQL. */
            _.Move("R0200", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -785- MOVE SPACES TO VA2646B1O-REG-H. */
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_H);

            /*" -786- MOVE 'H' TO VA2646B1O-IDENTIFICA. */
            _.Move("H", VA2646B1O_REG.VA2646B1O_IDENTIFICA);

            /*" -788- MOVE 'PRPSASSE' TO VA2646B1O-NOME-ARQ. */
            _.Move("PRPSASSE", VA2646B1O_REG.VA2646B1O_REG_H.VA2646B1O_NOME_ARQ);

            /*" -790- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO VA2646B1O-DATA-GER (5:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), VA2646B1O_REG.VA2646B1O_REG_H.VA2646B1O_DATA_GER, 5, 4);

            /*" -792- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO VA2646B1O-DATA-GER (3:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), VA2646B1O_REG.VA2646B1O_REG_H.VA2646B1O_DATA_GER, 3, 2);

            /*" -795- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO VA2646B1O-DATA-GER (1:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), VA2646B1O_REG.VA2646B1O_REG_H.VA2646B1O_DATA_GER, 1, 2);

            /*" -796- MOVE 4 TO VA2646B1O-COD-SIST. */
            _.Move(4, VA2646B1O_REG.VA2646B1O_REG_H.VA2646B1O_COD_SIST);

            /*" -797- MOVE 1 TO VA2646B1O-COD-SIST-DEST. */
            _.Move(1, VA2646B1O_REG.VA2646B1O_REG_H.VA2646B1O_COD_SIST_DEST);

            /*" -798- MOVE ZEROS TO VA2646B1O-SEQ-ARQ. */
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_H.VA2646B1O_SEQ_ARQ);

            /*" -799- MOVE 1 TO VA2646B1O-TIP-ARQ. */
            _.Move(1, VA2646B1O_REG.VA2646B1O_REG_H.VA2646B1O_TIP_ARQ);

            /*" -801- MOVE SPACES TO VA2646B1O-ESPACOS. */
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_H.VA2646B1O_ESPACOS);

            /*" -803- WRITE REG-AVA2646B FROM VA2646B1O-REG. */
            _.Move(VA2646B1O_REG.GetMoveValues(), REG_AVA2646B);

            AVA2646B.Write(REG_AVA2646B.GetMoveValues().ToString());

            /*" -803- PERFORM R0300-00-GRAVA-CAB-ERRO. */

            R0300_00_GRAVA_CAB_ERRO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-GRAVA-CAB-ERRO-SECTION */
        private void R0300_00_GRAVA_CAB_ERRO_SECTION()
        {
            /*" -814- MOVE 'R0300' TO WNR-EXEC-SQL. */
            _.Move("R0300", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -815- MOVE '00/00/0000' TO WS-DATA-CURR */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_CURR);

            /*" -816- ACCEPT WS-DATA-ACCEPT FROM DATE */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WS_DATA_ACCEPT);

            /*" -817- MOVE WS-DIA-ACCEPT TO WS-DIA-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_DIA_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_DIA_CURR);

            /*" -818- MOVE WS-MES-ACCEPT TO WS-MES-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_MES_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_MES_CURR);

            /*" -819- MOVE WS-ANO-ACCEPT TO WS-ANO-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_ANO_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR);

            /*" -820- ADD 2000 TO WS-ANO-CURR */
            AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR.Value = AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR + 2000;

            /*" -821- MOVE WS-DATA-CURR TO CAB1-DATA. */
            _.Move(AREA_DE_WORK.WS_DATA_CURR, REG_CAB1.CAB1_DATA);

            /*" -823- WRITE REG-RVA2646B FROM REG-CAB1. */
            _.Move(REG_CAB1.GetMoveValues(), REG_RVA2646B);

            RVA2646B.Write(REG_RVA2646B.GetMoveValues().ToString());

            /*" -824- MOVE '00:00:00' TO WS-HORA-CURR */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_CURR);

            /*" -825- ACCEPT WS-HORA-ACCEPT FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -826- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_HOR_CURR);

            /*" -827- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_MIN_CURR);

            /*" -828- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_SEG_CURR);

            /*" -829- MOVE WS-HORA-CURR TO CAB2-HORA */
            _.Move(AREA_DE_WORK.WS_HORA_CURR, REG_CAB2.CAB2_HORA);

            /*" -831- WRITE REG-RVA2646B FROM REG-CAB2. */
            _.Move(REG_CAB2.GetMoveValues(), REG_RVA2646B);

            RVA2646B.Write(REG_RVA2646B.GetMoveValues().ToString());

            /*" -833- WRITE REG-RVA2646B FROM REG-CAB3. */
            _.Move(REG_CAB3.GetMoveValues(), REG_RVA2646B);

            RVA2646B.Write(REG_RVA2646B.GetMoveValues().ToString());

            /*" -835- MOVE ALL '-' TO LINHA-TRACO. */
            _.MoveAll("-", LINHA_TRACO);

            /*" -837- WRITE REG-RVA2646B FROM LINHA-TRACO. */
            _.Move(LINHA_TRACO.GetMoveValues(), REG_RVA2646B);

            RVA2646B.Write(REG_RVA2646B.GetMoveValues().ToString());

            /*" -837- WRITE REG-RVA2646B FROM REG-CAB4. */
            _.Move(REG_CAB4.GetMoveValues(), REG_RVA2646B);

            RVA2646B.Write(REG_RVA2646B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-SECTION */
        private void R0900_00_DECLARE_PROPOVA_SECTION()
        {
            /*" -851- MOVE 'R0900' TO WNR-EXEC-SQL. */
            _.Move("R0900", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -926- PERFORM R0900_00_DECLARE_PROPOVA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOVA_DB_DECLARE_1();

            /*" -928- PERFORM R0900_00_DECLARE_PROPOVA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOVA_DB_OPEN_1();

            /*" -931- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -932- DISPLAY 'VA2646B - PROBLEMAS NO OPEN TPROPOVA' */
                _.Display($"VA2646B - PROBLEMAS NO OPEN TPROPOVA");

                /*" -933- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -934- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -934- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOVA_DB_DECLARE_1()
        {
            /*" -926- EXEC SQL DECLARE TPROPOVA CURSOR FOR SELECT C.NUM_APOLICE , C.COD_SUBGRUPO , C.NUM_CERTIFICADO , C.COD_CLIENTE , C.OCOREND , C.AGE_COBRANCA , C.DATA_QUITACAO , C.SIT_REGISTRO , C.COD_PRODUTO , C.DTNASC_ESPOSA , 0 , 0 , 0 , 0 , 0 , B.ORIG_PRODU , C.DTINCLUS FROM SEGUROS.SUBGRUPOS_VGAP A, SEGUROS.PRODUTOS_VG B, SEGUROS.PROPOSTAS_VA C WHERE A.SIT_REGISTRO = '0' AND B.ORIG_PRODU IN ( 'ESPEC' , 'ESPE1' ) AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.COD_PRODUTO NOT BETWEEN 7700 AND 7799 AND C.NUM_APOLICE = A.NUM_APOLICE AND C.COD_SUBGRUPO = A.COD_SUBGRUPO AND C.DTPROXVEN <> '9999-12-31' UNION SELECT C.NUM_APOLICE , C.COD_SUBGRUPO , C.NUM_CERTIFICADO , C.COD_CLIENTE , C.OCOREND , C.AGE_COBRANCA , C.DATA_QUITACAO , C.SIT_REGISTRO , C.COD_PRODUTO , C.DTNASC_ESPOSA , C.NRCERTIFANT , D.NUM_APOLICE , D.COD_SUBGRUPO , D.COD_FONTE , D.NUM_PROPOSTA , ' ' , C.DTINCLUS FROM SEGUROS.SUBGRUPOS_VGAP A, SEGUROS.PRODUTOS_VG B, SEGUROS.PROPOSTAS_VA C, SEGUROS.MOVIMENTO_VGAP D WHERE A.SIT_REGISTRO = '0' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.COD_PRODUTO NOT BETWEEN 7700 AND 779 AND B.NUM_APOLICE = C.NUM_APOLICE AND B.COD_SUBGRUPO = C.COD_SUBGRUPO AND C.NUM_APOLICE = A.NUM_APOLICE AND C.COD_SUBGRUPO = A.COD_SUBGRUPO AND C.DTPROXVEN <> '9999-12-31' AND C.COD_PRODUTO IN ( 9310, :JVPRD9310 ) AND C.NUM_APOLICE = D.NUM_APOLICE AND C.COD_SUBGRUPO = D.COD_SUBGRUPO AND C.NUM_CERTIFICADO = D.NUM_CERTIFICADO AND D.COD_OPERACAO BETWEEN 100 AND 299 AND D.DATA_INCLUSAO >= :DCLRELATORIOS.RELATORI-DATA-SOLICITACAO AND D.DATA_INCLUSAO <= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO END-EXEC. */
            TPROPOVA = new VA2646B_TPROPOVA(true);
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
							C.DATA_QUITACAO
							, 
							C.SIT_REGISTRO
							, 
							C.COD_PRODUTO
							, 
							C.DTNASC_ESPOSA
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
							B.ORIG_PRODU
							, 
							C.DTINCLUS 
							FROM 
							SEGUROS.SUBGRUPOS_VGAP A
							, 
							SEGUROS.PRODUTOS_VG B
							, 
							SEGUROS.PROPOSTAS_VA C 
							WHERE 
							A.SIT_REGISTRO = '0' 
							AND B.ORIG_PRODU IN ( 'ESPEC'
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
							C.DATA_QUITACAO
							, 
							C.SIT_REGISTRO
							, 
							C.COD_PRODUTO
							, 
							C.DTNASC_ESPOSA
							, 
							C.NRCERTIFANT
							, 
							D.NUM_APOLICE
							, 
							D.COD_SUBGRUPO
							, 
							D.COD_FONTE
							, 
							D.NUM_PROPOSTA
							, 
							' '
							, 
							C.DTINCLUS 
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
							AND B.COD_PRODUTO NOT BETWEEN 7700 AND 779 
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
							AND D.COD_OPERACAO BETWEEN 100 AND 299 
							AND D.DATA_INCLUSAO >= 
							'{RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO}' 
							AND D.DATA_INCLUSAO <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}'";

                return query;
            }
            TPROPOVA.GetQueryEvent += GetQuery_TPROPOVA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOVA_DB_OPEN_1()
        {
            /*" -928- EXEC SQL OPEN TPROPOVA END-EXEC. */

            TPROPOVA.Open();

        }

        [StopWatch]
        /*" R1011-00-CURSOR-BENEFICIARIOS-DB-DECLARE-1 */
        public void R1011_00_CURSOR_BENEFICIARIOS_DB_DECLARE_1()
        {
            /*" -1743- EXEC SQL DECLARE BENEFICIARIOS CURSOR FOR SELECT NUM_BENEFICIARIO , NOME_BENEFICIARIO , GRAU_PARENTESCO , PCT_PART_BENEFICIA FROM SEGUROS.BENEFICIARIOS WHERE NUM_CERTIFICADO = :BENEFICI-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */
            BENEFICIARIOS = new VA2646B_BENEFICIARIOS(true);
            string GetQuery_BENEFICIARIOS()
            {
                var query = @$"SELECT NUM_BENEFICIARIO
							, 
							NOME_BENEFICIARIO
							, 
							GRAU_PARENTESCO
							, 
							PCT_PART_BENEFICIA 
							FROM SEGUROS.BENEFICIARIOS 
							WHERE NUM_CERTIFICADO = 
							'{BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO}' 
							AND DATA_TERVIGENCIA = '9999-12-31'";

                return query;
            }
            BENEFICIARIOS.GetQueryEvent += GetQuery_BENEFICIARIOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-SECTION */
        private void R0910_00_FETCH_PROPOVA_SECTION()
        {
            /*" -948- MOVE 'R0910' TO WNR-EXEC-SQL. */
            _.Move("R0910", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -967- PERFORM R0910_00_FETCH_PROPOVA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOVA_DB_FETCH_1();

            /*" -970- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -971- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -972- MOVE 'S' TO WFIM-PROPOVA */
                    _.Move("S", WORK_AREA_0.WFIM_PROPOVA);

                    /*" -972- PERFORM R0910_00_FETCH_PROPOVA_DB_CLOSE_1 */

                    R0910_00_FETCH_PROPOVA_DB_CLOSE_1();

                    /*" -974- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -975- ELSE */
                }
                else
                {


                    /*" -976- DISPLAY 'VA2646B - ERRO FETCH TPROPOVA' */
                    _.Display($"VA2646B - ERRO FETCH TPROPOVA");

                    /*" -977- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                    /*" -978- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -979- END-IF */
                }


                /*" -981- END-IF. */
            }


            /*" -982- IF PROPOVA-SIT-REGISTRO NOT EQUAL '3' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO != "3")
            {

                /*" -983- GO TO R0910-00-FETCH-PROPOVA */
                new Task(() => R0910_00_FETCH_PROPOVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -985- END-IF. */
            }


            /*" -985- ADD 1 TO AC-LIDOS. */
            WORK_AREA_0.AC_LIDOS.Value = WORK_AREA_0.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -967- EXEC SQL FETCH TPROPOVA INTO :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO , :PROPOVA-NUM-CERTIFICADO , :PROPOVA-COD-CLIENTE , :PROPOVA-OCOREND , :PROPOVA-AGE-COBRANCA , :PROPOVA-DATA-QUITACAO , :PROPOVA-SIT-REGISTRO , :PROPOVA-COD-PRODUTO , :PROPOVA-DTNASC-ESPOSA :VIND-NULL, :PROPOVA-NRCERTIFANT :VIND-NULL-2, :MOVVGAP-NUM-APOLICE , :MOVVGAP-COD-SUBGRUPO , :MOVVGAP-COD-FONTE , :MOVVGAP-NUM-PROPOSTA , :PRODUVG-ORIG-PRODU , :PROPOVA-DTINCLUS END-EXEC. */

            if (TPROPOVA.Fetch())
            {
                _.Move(TPROPOVA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(TPROPOVA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(TPROPOVA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(TPROPOVA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(TPROPOVA.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
                _.Move(TPROPOVA.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
                _.Move(TPROPOVA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(TPROPOVA.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(TPROPOVA.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(TPROPOVA.PROPOVA_DTNASC_ESPOSA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTNASC_ESPOSA);
                _.Move(TPROPOVA.VIND_NULL, VIND_NULL);
                _.Move(TPROPOVA.PROPOVA_NRCERTIFANT, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NRCERTIFANT);
                _.Move(TPROPOVA.VIND_NULL_2, VIND_NULL_2);
                _.Move(TPROPOVA.MOVVGAP_NUM_APOLICE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_APOLICE);
                _.Move(TPROPOVA.MOVVGAP_COD_SUBGRUPO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO);
                _.Move(TPROPOVA.MOVVGAP_COD_FONTE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_FONTE);
                _.Move(TPROPOVA.MOVVGAP_NUM_PROPOSTA, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_PROPOSTA);
                _.Move(TPROPOVA.PRODUVG_ORIG_PRODU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);
                _.Move(TPROPOVA.PROPOVA_DTINCLUS, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -972- EXEC SQL CLOSE TPROPOVA END-EXEC */

            TPROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -999- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -1001- INITIALIZE DCLPROPOSTA-FIDELIZ */
            _.Initialize(
                PROPOFID.DCLPROPOSTA_FIDELIZ
            );

            /*" -1003- MOVE SPACES TO TEM-CONVERSAO TEM-PROP-FIDELIZ */
            _.Move("", WORK_AREA_0.TEM_CONVERSAO, WORK_AREA_0.TEM_PROP_FIDELIZ);

            /*" -1005- MOVE ZEROS TO WS-NUM-PROPOSTA-EXC */
            _.Move(0, WORK_AREA_0.WS_NUM_PROPOSTA_EXC);

            /*" -1006- PERFORM R1900-00-SELECT-PROPOFID */

            R1900_00_SELECT_PROPOFID_SECTION();

            /*" -1007- IF TEM-PROP-FIDELIZ EQUAL 'N' */

            if (WORK_AREA_0.TEM_PROP_FIDELIZ == "N")
            {

                /*" -1009- MOVE 'CERTIFICADO SEM PROPOFID' TO DET-DESC-ERRO */
                _.Move("CERTIFICADO SEM PROPOFID", REG_DETALHE.DET_DESC_ERRO);

                /*" -1010- PERFORM R1560-00-GRAVA-ERRO */

                R1560_00_GRAVA_ERRO_SECTION();

                /*" -1011- GO TO R1000-05-CONTINUA */

                R1000_05_CONTINUA(); //GOTO
                return;

                /*" -1013- END-IF. */
            }


            /*" -1016- IF PROPOFID-CANAL-PROPOSTA NOT EQUAL 2 AND PROPOFID-ORIGEM-PROPOSTA NOT EQUAL 10 AND NOT ( PROPOVA-COD-PRODUTO = 9310 OR JVPRD9310 ) */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA != 2 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA != 10 && !(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString())))
            {

                /*" -1017- ADD 1 TO AC-DESP-0 */
                WORK_AREA_0.AC_DESP_0.Value = WORK_AREA_0.AC_DESP_0 + 1;

                /*" -1019- MOVE 'CERTIFICADO DESPRESADO PROPOFID' TO DET-DESC-ERRO */
                _.Move("CERTIFICADO DESPRESADO PROPOFID", REG_DETALHE.DET_DESC_ERRO);

                /*" -1020- PERFORM R1560-00-GRAVA-ERRO */

                R1560_00_GRAVA_ERRO_SECTION();

                /*" -1021- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1023- END-IF. */
            }


            /*" -1025- IF ( PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPRD9310 ) AND PROPOFID-SITUACAO-ENVIO EQUAL 'R' */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString())) && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO == "R")
            {

                /*" -1027- ADD 1 TO AC-DESP-10 */
                WORK_AREA_0.AC_DESP_10.Value = WORK_AREA_0.AC_DESP_10 + 1;

                /*" -1028- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1030- END-IF. */
            }


            /*" -1033- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 06 AND PROPOFID-ORIGEM-PROPOSTA EQUAL 08 AND PROPOFID-CANAL-PROPOSTA EQUAL 08 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 06 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 08 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA == 08)
            {

                /*" -1034- ADD 1 TO AC-DESP-11 */
                WORK_AREA_0.AC_DESP_11.Value = WORK_AREA_0.AC_DESP_11 + 1;

                /*" -1036- MOVE 'CERTIFICADO DESPRESADO AC-DESP-11' TO DET-DESC-ERRO */
                _.Move("CERTIFICADO DESPRESADO AC-DESP-11", REG_DETALHE.DET_DESC_ERRO);

                /*" -1037- PERFORM R1560-00-GRAVA-ERRO */

                R1560_00_GRAVA_ERRO_SECTION();

                /*" -1038- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1040- END-IF. */
            }


            /*" -1041- IF PRODUVG-ORIG-PRODU EQUAL 'ESPEC' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "ESPEC")
            {

                /*" -1042- PERFORM R1015-SELECT-RELATORIOS */

                R1015_SELECT_RELATORIOS_SECTION();

                /*" -1043- IF TEM-RENOVACAO EQUAL 'S' */

                if (WORK_AREA_0.TEM_RENOVACAO == "S")
                {

                    /*" -1044- PERFORM R1016-SELECT-PARCELA */

                    R1016_SELECT_PARCELA_SECTION();

                    /*" -1046- IF PARCEVID-SIT-REGISTRO NOT EQUAL '1' */

                    if (PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO != "1")
                    {

                        /*" -1047- MOVE SPACES TO TEM-RENOVACAO */
                        _.Move("", WORK_AREA_0.TEM_RENOVACAO);

                        /*" -1049- MOVE 'PARCELA RENOVACAO NAO PAGA' TO DET-DESC-ERRO */
                        _.Move("PARCELA RENOVACAO NAO PAGA", REG_DETALHE.DET_DESC_ERRO);

                        /*" -1050- PERFORM R1560-00-GRAVA-ERRO */

                        R1560_00_GRAVA_ERRO_SECTION();

                        /*" -1051- ADD 1 TO AC-DESP-6 */
                        WORK_AREA_0.AC_DESP_6.Value = WORK_AREA_0.AC_DESP_6 + 1;

                        /*" -1052- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -1054- END-IF */
                    }


                    /*" -1055- MOVE 731 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                    _.Move(731, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                    /*" -1056- PERFORM R1030-00-SELECT-PROPFIDH */

                    R1030_00_SELECT_PROPFIDH_SECTION();

                    /*" -1057- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1058- CONTINUE */

                        /*" -1060- ELSE */
                    }
                    else
                    {


                        /*" -1061- MOVE PROPFIDH-DATA-SITUACAO TO W-DATA-SQL */
                        _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, AREA_DE_WORK.W_DATA_SQL);

                        /*" -1062- IF W-ANO-SQL EQUAL W-ANO-MOV-ABERTO */

                        if (AREA_DE_WORK.W_DATA_SQL1.W_ANO_SQL == AREA_DE_WORK.W_ANO_MOV_ABERTO)
                        {

                            /*" -1063- MOVE SPACES TO TEM-RENOVACAO */
                            _.Move("", WORK_AREA_0.TEM_RENOVACAO);

                            /*" -1065- MOVE 'CERTIFICADO JA RENOVADO' TO DET-DESC-ERRO */
                            _.Move("CERTIFICADO JA RENOVADO", REG_DETALHE.DET_DESC_ERRO);

                            /*" -1066- PERFORM R1560-00-GRAVA-ERRO */

                            R1560_00_GRAVA_ERRO_SECTION();

                            /*" -1067- ADD 1 TO AC-DESP-6 */
                            WORK_AREA_0.AC_DESP_6.Value = WORK_AREA_0.AC_DESP_6 + 1;

                            /*" -1068- MOVE 'S' TO WS-ERRO-RENOV */
                            _.Move("S", WORK_AREA_0.WS_ERRO_RENOV);

                            /*" -1069- GO TO R1000-10-NEXT */

                            R1000_10_NEXT(); //GOTO
                            return;

                            /*" -1070- END-IF */
                        }


                        /*" -1071- ELSE */
                    }

                }
                else
                {


                    /*" -1073- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 48 AND PROPOFID-SITUACAO-ENVIO EQUAL 'S' */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 48 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO == "S")
                    {

                        /*" -1075- ADD 1 TO AC-DESP-12 */
                        WORK_AREA_0.AC_DESP_12.Value = WORK_AREA_0.AC_DESP_12 + 1;

                        /*" -1076- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -1077- END-IF */
                    }


                    /*" -1077- END-IF. */
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1000_05_CONTINUA */

            R1000_05_CONTINUA();

        }

        [StopWatch]
        /*" R1000-05-CONTINUA */
        private void R1000_05_CONTINUA(bool isPerform = false)
        {
            /*" -1082- PERFORM R1010-00-SELECT-PRODUVG */

            R1010_00_SELECT_PRODUVG_SECTION();

            /*" -1083- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1084- ADD 1 TO AC-DESP-1 */
                WORK_AREA_0.AC_DESP_1.Value = WORK_AREA_0.AC_DESP_1 + 1;

                /*" -1086- MOVE 'CERTIFICADO DESPRESADO PRODUVG' TO DET-DESC-ERRO */
                _.Move("CERTIFICADO DESPRESADO PRODUVG", REG_DETALHE.DET_DESC_ERRO);

                /*" -1087- PERFORM R1560-00-GRAVA-ERRO */

                R1560_00_GRAVA_ERRO_SECTION();

                /*" -1088- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1090- END-IF. */
            }


            /*" -1091- PERFORM R1020-00-SELECT-ENDOSSOS */

            R1020_00_SELECT_ENDOSSOS_SECTION();

            /*" -1092- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1093- ADD 1 TO AC-DESP-8 */
                WORK_AREA_0.AC_DESP_8.Value = WORK_AREA_0.AC_DESP_8 + 1;

                /*" -1095- MOVE 'CERTIFICADO DESPRESADO ENDOSSOS' TO DET-DESC-ERRO */
                _.Move("CERTIFICADO DESPRESADO ENDOSSOS", REG_DETALHE.DET_DESC_ERRO);

                /*" -1096- PERFORM R1560-00-GRAVA-ERRO */

                R1560_00_GRAVA_ERRO_SECTION();

                /*" -1097- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1099- END-IF. */
            }


            /*" -1100- PERFORM R1100-00-SELECT-CLIENTES */

            R1100_00_SELECT_CLIENTES_SECTION();

            /*" -1101- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1102- ADD 1 TO AC-DESP-2 */
                WORK_AREA_0.AC_DESP_2.Value = WORK_AREA_0.AC_DESP_2 + 1;

                /*" -1104- MOVE 'CLIENTE NAO CADASTRADO ' TO DET-DESC-ERRO */
                _.Move("CLIENTE NAO CADASTRADO ", REG_DETALHE.DET_DESC_ERRO);

                /*" -1105- PERFORM R1560-00-GRAVA-ERRO */

                R1560_00_GRAVA_ERRO_SECTION();

                /*" -1106- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1108- END-IF. */
            }


            /*" -1109- PERFORM R1200-00-SELECT-ENDERECO */

            R1200_00_SELECT_ENDERECO_SECTION();

            /*" -1110- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1111- ADD 1 TO AC-DESP-3 */
                WORK_AREA_0.AC_DESP_3.Value = WORK_AREA_0.AC_DESP_3 + 1;

                /*" -1113- MOVE 'CLIENTE SEM ENDERECO ' TO DET-DESC-ERRO */
                _.Move("CLIENTE SEM ENDERECO ", REG_DETALHE.DET_DESC_ERRO);

                /*" -1114- PERFORM R1560-00-GRAVA-ERRO */

                R1560_00_GRAVA_ERRO_SECTION();

                /*" -1115- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1117- END-IF. */
            }


            /*" -1118- PERFORM R1300-00-SELECT-OPCPAGVI */

            R1300_00_SELECT_OPCPAGVI_SECTION();

            /*" -1119- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1120- ADD 1 TO AC-DESP-4 */
                WORK_AREA_0.AC_DESP_4.Value = WORK_AREA_0.AC_DESP_4 + 1;

                /*" -1122- MOVE 'CERTIFICADO SEM OPCAOPAG VIGENTE' TO DET-DESC-ERRO */
                _.Move("CERTIFICADO SEM OPCAOPAG VIGENTE", REG_DETALHE.DET_DESC_ERRO);

                /*" -1123- PERFORM R1560-00-GRAVA-ERRO */

                R1560_00_GRAVA_ERRO_SECTION();

                /*" -1124- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1126- END-IF. */
            }


            /*" -1128- PERFORM R1400-00-SELECT-CLIENEMA */

            R1400_00_SELECT_CLIENEMA_SECTION();

            /*" -1129- PERFORM R1500-00-SELECT-HISCOBPR */

            R1500_00_SELECT_HISCOBPR_SECTION();

            /*" -1130- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1131- ADD 1 TO AC-DESP-5 */
                WORK_AREA_0.AC_DESP_5.Value = WORK_AREA_0.AC_DESP_5 + 1;

                /*" -1133- MOVE 'CERTIFICADO SEM HIS_COBER_PROPOST' TO DET-DESC-ERRO */
                _.Move("CERTIFICADO SEM HIS_COBER_PROPOST", REG_DETALHE.DET_DESC_ERRO);

                /*" -1134- PERFORM R1560-00-GRAVA-ERRO */

                R1560_00_GRAVA_ERRO_SECTION();

                /*" -1135- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1137- END-IF. */
            }


            /*" -1138- PERFORM R1550-00-SELECT-AGENCCEF. */

            R1550_00_SELECT_AGENCCEF_SECTION();

            /*" -1140- IF (WS-TEM-AGENCCEF EQUAL 'N' ) AND NOT (PROPOVA-COD-PRODUTO = 9310 OR JVPRD9310 ) */

            if ((WS_TEM_AGENCCEF == "N") && !(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString())))
            {

                /*" -1141- MOVE 'AGENCIA NAO CADASTRADA' TO DET-DESC-ERRO */
                _.Move("AGENCIA NAO CADASTRADA", REG_DETALHE.DET_DESC_ERRO);

                /*" -1142- PERFORM R1560-00-GRAVA-ERRO */

                R1560_00_GRAVA_ERRO_SECTION();

                /*" -1143- ADD 1 TO AC-DESP-9 */
                WORK_AREA_0.AC_DESP_9.Value = WORK_AREA_0.AC_DESP_9 + 1;

                /*" -1144- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1146- END-IF. */
            }


            /*" -1148- IF (AGENCCEF-SITUACAO NOT EQUAL '0' ) AND NOT (PROPOVA-COD-PRODUTO = 9310 OR JVPRD9310 ) */

            if ((AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_SITUACAO != "0") && !(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString())))
            {

                /*" -1149- MOVE 'AGENCIA NAO ATIVA' TO DET-DESC-ERRO */
                _.Move("AGENCIA NAO ATIVA", REG_DETALHE.DET_DESC_ERRO);

                /*" -1150- PERFORM R1560-00-GRAVA-ERRO */

                R1560_00_GRAVA_ERRO_SECTION();

                /*" -1151- ADD 1 TO AC-DESP-9 */
                WORK_AREA_0.AC_DESP_9.Value = WORK_AREA_0.AC_DESP_9 + 1;

                /*" -1152- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1154- END-IF. */
            }


            /*" -1156- PERFORM R1700-00-SELECT-PLANOAGE */

            R1700_00_SELECT_PLANOAGE_SECTION();

            /*" -1157- PERFORM R1912-00-SELECT-CONVERS-SICOB */

            R1912_00_SELECT_CONVERS_SICOB_SECTION();

            /*" -1158- IF TEM-CONVERSAO EQUAL 'S' */

            if (WORK_AREA_0.TEM_CONVERSAO == "S")
            {

                /*" -1159- IF WS-NUM-PROPOSTA-CONVERSAO (1:1) EQUAL 1 */

                if (WORK_AREA_0.WS_NUM_PROPOSTA_CONVERSAO.Substring(1, 1) == 1)
                {

                    /*" -1161- MOVE 'TEM CONVERSAO C/PROPOSTA 13...' TO DET-DESC-ERRO */
                    _.Move("TEM CONVERSAO C/PROPOSTA 13...", REG_DETALHE.DET_DESC_ERRO);

                    /*" -1162- PERFORM R1560-00-GRAVA-ERRO */

                    R1560_00_GRAVA_ERRO_SECTION();

                    /*" -1163- ADD 1 TO AC-DESP-13 */
                    WORK_AREA_0.AC_DESP_13.Value = WORK_AREA_0.AC_DESP_13 + 1;

                    /*" -1164- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1165- END-IF */
                }


                /*" -1167- END-IF. */
            }


            /*" -1171- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-CERTIFICADO_PROPVA WS-NUM-PROPOSTA-DESLOC-13 */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA_0.WS_NUM_CERTIFICADO_PROPVA, WORK_AREA_0.WS_NUM_PROPOSTA_R_0.WS_NUM_PROPOSTA_DESLOC_13);

            /*" -1173- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPRD9310 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -1174- CONTINUE */

                /*" -1176- ELSE */
            }
            else
            {


                /*" -1179- IF WS-NUM-CERTIFICADO_PROPVA (1:2) EQUAL ZEROS AND TEM-CONVERSAO EQUAL ' ' AND PROPOVA-DTINCLUS > '2022-07-14' */

                if (WORK_AREA_0.WS_NUM_CERTIFICADO_PROPVA.Substring(1, 2) == 00 && WORK_AREA_0.TEM_CONVERSAO == " " && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS > "2022-07-14")
                {

                    /*" -1180- PERFORM R1706-00-MONTA-PROP-VIDA */

                    R1706_00_MONTA_PROP_VIDA_SECTION();

                    /*" -1181- ELSE */
                }
                else
                {


                    /*" -1182- IF TEM-CONVERSAO EQUAL ' ' */

                    if (WORK_AREA_0.TEM_CONVERSAO == " ")
                    {

                        /*" -1184- MOVE ZEROS TO WS-NUM-PROPOSTA-DESLOC-01 */
                        _.Move(0, WORK_AREA_0.WS_NUM_PROPOSTA_R_0.WS_NUM_PROPOSTA_DESLOC_01);

                        /*" -1186- MOVE WS-NUM-PROPOSTA-DESLOC TO WS-NUM-PROPOSTA-SIVPF */
                        _.Move(WORK_AREA_0.WS_NUM_PROPOSTA_DESLOC, AREA_PROP.WS_NUM_PROPOSTA_SIVPF);

                        /*" -1187- END-IF */
                    }


                    /*" -1188- END-IF */
                }


                /*" -1194- END-IF. */
            }


            /*" -1196- MOVE SPACES TO VA2646B1O-REG-1 */
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_1);

            /*" -1198- MOVE '1' TO VA2646B1O-IDENTIFICA */
            _.Move("1", VA2646B1O_REG.VA2646B1O_IDENTIFICA);

            /*" -1213- MOVE WS-NUM-PROPOSTA-SIVPF TO VA2646B1O-NUM-PROPOSTA-1. */
            _.Move(AREA_PROP.WS_NUM_PROPOSTA_SIVPF, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_NUM_PROPOSTA_1);

            /*" -1214- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPRD9310 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -1215- IF WS-NUM-CERTIFICADO_PROPVA(1:1) NOT EQUAL ZEROS */

                if (WORK_AREA_0.WS_NUM_CERTIFICADO_PROPVA.Substring(1, 1) != 00)
                {

                    /*" -1217- MOVE PROPOVA-NUM-CERTIFICADO TO VA2646B1O-NUM-PROPOSTA-1 */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_NUM_PROPOSTA_1);

                    /*" -1218- ELSE */
                }
                else
                {


                    /*" -1220- MOVE 60 TO WS-NUM-PROPOSTA-02 */
                    _.Move(60, WORK_AREA_0.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_02);

                    /*" -1222- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA-11 */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA_0.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_11);

                    /*" -1224- MOVE ZEROS TO WS-NUM-PROPOSTA-01 */
                    _.Move(0, WORK_AREA_0.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_01);

                    /*" -1226- MOVE WS-NUM-PROPOSTA-EXC TO VA2646B1O-NUM-PROPOSTA-1 */
                    _.Move(WORK_AREA_0.WS_NUM_PROPOSTA_EXC, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_NUM_PROPOSTA_1);

                    /*" -1227- END-IF */
                }


                /*" -1229- END-IF. */
            }


            /*" -1232- MOVE CLIENTES-CGCCPF TO VA2646B1O-NUM-CPFCGC */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_NUM_CPFCGC);

            /*" -1233- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPRD9310 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -1235- MOVE CLIENTES-DATA-NASCIMENTO TO W-DATA-SQL */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, AREA_DE_WORK.W_DATA_SQL);

                /*" -1236- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(AREA_DE_WORK.W_DATA_SQL1.W_DIA_SQL, AREA_DE_WORK.FILLER_5.W_DIA_TRABALHO);

                /*" -1237- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(AREA_DE_WORK.W_DATA_SQL1.W_MES_SQL, AREA_DE_WORK.FILLER_5.W_MES_TRABALHO);

                /*" -1238- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(AREA_DE_WORK.W_DATA_SQL1.W_ANO_SQL, AREA_DE_WORK.FILLER_5.W_ANO_TRABALHO);

                /*" -1240- MOVE W-DATA-TRABALHO TO VA2646B1O-DATA-NASCTO */
                _.Move(AREA_DE_WORK.W_DATA_TRABALHO, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_DATA_NASCTO);

                /*" -1241- ELSE */
            }
            else
            {


                /*" -1242- MOVE 01010001 TO VA2646B1O-DATA-NASCTO */
                _.Move(01010001, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_DATA_NASCTO);

                /*" -1244- END-IF */
            }


            /*" -1247- MOVE CLIENTES-NOME-RAZAO TO VA2646B1O-NOME */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_NOME);

            /*" -1248- IF CLIENTES-TIPO-PESSOA EQUAL 'F' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
            {

                /*" -1249- PERFORM R1800-00-SELECT-PESSOFIS */

                R1800_00_SELECT_PESSOFIS_SECTION();

                /*" -1250- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1251- PERFORM R1820-00-INSERT-PESSOA */

                    R1820_00_INSERT_PESSOA_SECTION();

                    /*" -1252- PERFORM R1830-00-INSERT-PESSOFIS */

                    R1830_00_INSERT_PESSOFIS_SECTION();

                    /*" -1253- END-IF */
                }


                /*" -1254- ELSE */
            }
            else
            {


                /*" -1255- PERFORM R1810-00-SELECT-PESSOJUR */

                R1810_00_SELECT_PESSOJUR_SECTION();

                /*" -1256- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1257- PERFORM R1820-00-INSERT-PESSOA */

                    R1820_00_INSERT_PESSOA_SECTION();

                    /*" -1258- PERFORM R1840-00-INSERT-PESSOJUR */

                    R1840_00_INSERT_PESSOJUR_SECTION();

                    /*" -1259- END-IF */
                }


                /*" -1261- END-IF. */
            }


            /*" -1262- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPRD9310 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -1264- MOVE 1 TO VA2646B1O-TIPO-PESSOA */
                _.Move(1, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_TIPO_PESSOA);

                /*" -1265- ELSE */
            }
            else
            {


                /*" -1267- MOVE 2 TO VA2646B1O-TIPO-PESSOA */
                _.Move(2, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_TIPO_PESSOA);

                /*" -1269- END-IF */
            }


            /*" -1273- MOVE ZEROS TO VA2646B1O-NUM-RG VA2646B1O-PROFISSAO-CONJ */
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_NUM_RG);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_PROFISSAO_CONJ);


            /*" -1279- MOVE SPACES TO VA2646B1O-ORGAO-EXPED VA2646B1O-UF-ORGAO VA2646B1O-CODIGO-SEGMENTO VA2646B1O-DESCR-PROFISSAO */
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_ORGAO_EXPED);
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_UF_ORGAO);
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_CODIGO_SEGMENTO);
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_DESCR_PROFISSAO);


            /*" -1286- MOVE ZEROS TO VA2646B1O-ESTADO-CIVIL VA2646B1O-SEXO VA2646B1O-PROFISSAO VA2646B1O-DDD-RESIDENCIA VA2646B1O-TEL-RESIDENCIA */
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_ESTADO_CIVIL);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_SEXO);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_PROFISSAO);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_DDD_RESIDENCIA);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_TEL_RESIDENCIA);


            /*" -1289- MOVE ENDERECO-DDD TO VA2646B1O-DDD-COMERCIAL */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_DDD_COMERCIAL);

            /*" -1292- MOVE ENDERECO-TELEFONE TO VA2646B1O-TEL-COMERCIAL */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_TEL_COMERCIAL);

            /*" -1295- MOVE ENDERECO-DDD TO VA2646B1O-DDD-FAX */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_DDD_FAX);

            /*" -1298- MOVE ENDERECO-FAX TO VA2646B1O-TEL-FAX */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_FAX, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_TEL_FAX);

            /*" -1299- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPRD9310 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -1300- MOVE PROPOVA-DTNASC-ESPOSA TO W-DATA-SQL */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTNASC_ESPOSA, AREA_DE_WORK.W_DATA_SQL);

                /*" -1301- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(AREA_DE_WORK.W_DATA_SQL1.W_DIA_SQL, AREA_DE_WORK.FILLER_5.W_DIA_TRABALHO);

                /*" -1302- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(AREA_DE_WORK.W_DATA_SQL1.W_MES_SQL, AREA_DE_WORK.FILLER_5.W_MES_TRABALHO);

                /*" -1303- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(AREA_DE_WORK.W_DATA_SQL1.W_ANO_SQL, AREA_DE_WORK.FILLER_5.W_ANO_TRABALHO);

                /*" -1306- MOVE W-DATA-TRABALHO TO VA2646B1O-DATA-EXPEDICAO VA2646B1O-DATA-NASCTO-CONJ */
                _.Move(AREA_DE_WORK.W_DATA_TRABALHO, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_DATA_EXPEDICAO);
                _.Move(AREA_DE_WORK.W_DATA_TRABALHO, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_DATA_NASCTO_CONJ);


                /*" -1307- ELSE */
            }
            else
            {


                /*" -1310- MOVE 01010001 TO VA2646B1O-DATA-EXPEDICAO VA2646B1O-DATA-NASCTO-CONJ */
                _.Move(01010001, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_DATA_EXPEDICAO);
                _.Move(01010001, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_DATA_NASCTO_CONJ);


                /*" -1312- END-IF */
            }


            /*" -1315- MOVE '0000' TO VA2646B1O-CODIGO-SEGMENTO */
            _.Move("0000", VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_CODIGO_SEGMENTO);

            /*" -1320- MOVE CLIENEMA-EMAIL TO VA2646B1O-EMAIL */
            _.Move(CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL, VA2646B1O_REG.VA2646B1O_REG_1.VA2646B1O_EMAIL);

            /*" -1324- ADD 1 TO WS-QTD-REG1-PRP AC-GRAVADOS. */
            WS_QTD_REG1_PRP.Value = WS_QTD_REG1_PRP + 1;
            WORK_AREA_0.AC_GRAVADOS.Value = WORK_AREA_0.AC_GRAVADOS + 1;

            /*" -1331- WRITE REG-AVA2646B FROM VA2646B1O-REG. */
            _.Move(VA2646B1O_REG.GetMoveValues(), REG_AVA2646B);

            AVA2646B.Write(REG_AVA2646B.GetMoveValues().ToString());

            /*" -1334- MOVE SPACES TO VA2646B1O-REG-2 */
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_2);

            /*" -1336- MOVE '2' TO VA2646B1O-IDENTIFICA. */
            _.Move("2", VA2646B1O_REG.VA2646B1O_IDENTIFICA);

            /*" -1351- MOVE WS-NUM-PROPOSTA-SIVPF TO VA2646B1O-NUM-PROPOSTA-2 */
            _.Move(AREA_PROP.WS_NUM_PROPOSTA_SIVPF, VA2646B1O_REG.VA2646B1O_REG_2.VA2646B1O_NUM_PROPOSTA_2);

            /*" -1352- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPRD9310 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -1353- IF WS-NUM-CERTIFICADO_PROPVA(1:1) NOT EQUAL ZEROS */

                if (WORK_AREA_0.WS_NUM_CERTIFICADO_PROPVA.Substring(1, 1) != 00)
                {

                    /*" -1355- MOVE PROPOVA-NUM-CERTIFICADO TO VA2646B1O-NUM-PROPOSTA-2 */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VA2646B1O_REG.VA2646B1O_REG_2.VA2646B1O_NUM_PROPOSTA_2);

                    /*" -1356- ELSE */
                }
                else
                {


                    /*" -1358- MOVE 60 TO WS-NUM-PROPOSTA-02 */
                    _.Move(60, WORK_AREA_0.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_02);

                    /*" -1360- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA-11 */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA_0.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_11);

                    /*" -1362- MOVE ZEROS TO WS-NUM-PROPOSTA-01 */
                    _.Move(0, WORK_AREA_0.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_01);

                    /*" -1364- MOVE WS-NUM-PROPOSTA-EXC TO VA2646B1O-NUM-PROPOSTA-2 */
                    _.Move(WORK_AREA_0.WS_NUM_PROPOSTA_EXC, VA2646B1O_REG.VA2646B1O_REG_2.VA2646B1O_NUM_PROPOSTA_2);

                    /*" -1365- END-IF */
                }


                /*" -1367- END-IF */
            }


            /*" -1370- MOVE 1 TO VA2646B1O-TIPO-ENDERECO */
            _.Move(1, VA2646B1O_REG.VA2646B1O_REG_2.VA2646B1O_TIPO_ENDERECO);

            /*" -1373- MOVE ENDERECO-ENDERECO TO VA2646B1O-ENDERECO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, VA2646B1O_REG.VA2646B1O_REG_2.VA2646B1O_ENDERECO);

            /*" -1376- MOVE ENDERECO-BAIRRO TO VA2646B1O-BAIRRO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, VA2646B1O_REG.VA2646B1O_REG_2.VA2646B1O_BAIRRO);

            /*" -1379- MOVE ENDERECO-CIDADE TO VA2646B1O-CIDADE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, VA2646B1O_REG.VA2646B1O_REG_2.VA2646B1O_CIDADE);

            /*" -1382- MOVE ENDERECO-SIGLA-UF TO VA2646B1O-UF */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, VA2646B1O_REG.VA2646B1O_REG_2.VA2646B1O_UF);

            /*" -1387- MOVE ENDERECO-CEP TO VA2646B1O-CEP */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, VA2646B1O_REG.VA2646B1O_REG_2.VA2646B1O_CEP);

            /*" -1390- ADD 1 TO WS-QTD-REG2-PRP */
            WS_QTD_REG2_PRP.Value = WS_QTD_REG2_PRP + 1;

            /*" -1393- WRITE REG-AVA2646B FROM VA2646B1O-REG. */
            _.Move(VA2646B1O_REG.GetMoveValues(), REG_AVA2646B);

            AVA2646B.Write(REG_AVA2646B.GetMoveValues().ToString());

            /*" -1396- MOVE 2 TO VA2646B1O-TIPO-ENDERECO */
            _.Move(2, VA2646B1O_REG.VA2646B1O_REG_2.VA2646B1O_TIPO_ENDERECO);

            /*" -1399- ADD 1 TO WS-QTD-REG2-PRP */
            WS_QTD_REG2_PRP.Value = WS_QTD_REG2_PRP + 1;

            /*" -1406- WRITE REG-AVA2646B FROM VA2646B1O-REG. */
            _.Move(VA2646B1O_REG.GetMoveValues(), REG_AVA2646B);

            AVA2646B.Write(REG_AVA2646B.GetMoveValues().ToString());

            /*" -1409- MOVE SPACES TO VA2646B1O-REG-3 */
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_3);

            /*" -1412- MOVE '3' TO VA2646B1O-IDENTIFICA. */
            _.Move("3", VA2646B1O_REG.VA2646B1O_IDENTIFICA);

            /*" -1414- MOVE PROPOVA-NUM-CERTIFICADO TO VA2646B1O-NUM-SICOB */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_NUM_SICOB);

            /*" -1429- MOVE WS-NUM-PROPOSTA-SIVPF TO VA2646B1O-NUM-PROPOSTA-3 */
            _.Move(AREA_PROP.WS_NUM_PROPOSTA_SIVPF, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_NUM_PROPOSTA_3);

            /*" -1430- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPRD9310 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -1431- IF WS-NUM-CERTIFICADO_PROPVA(1:1) NOT EQUAL ZEROS */

                if (WORK_AREA_0.WS_NUM_CERTIFICADO_PROPVA.Substring(1, 1) != 00)
                {

                    /*" -1433- MOVE PROPOVA-NUM-CERTIFICADO TO VA2646B1O-NUM-PROPOSTA-3 */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_NUM_PROPOSTA_3);

                    /*" -1434- ELSE */
                }
                else
                {


                    /*" -1436- MOVE 60 TO WS-NUM-PROPOSTA-02 */
                    _.Move(60, WORK_AREA_0.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_02);

                    /*" -1438- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA-11 */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA_0.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_11);

                    /*" -1440- MOVE ZEROS TO WS-NUM-PROPOSTA-01 */
                    _.Move(0, WORK_AREA_0.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_01);

                    /*" -1442- MOVE WS-NUM-PROPOSTA-EXC TO VA2646B1O-NUM-PROPOSTA-3 */
                    _.Move(WORK_AREA_0.WS_NUM_PROPOSTA_EXC, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_NUM_PROPOSTA_3);

                    /*" -1443- END-IF */
                }


                /*" -1445- END-IF. */
            }


            /*" -1446- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPRD9310 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -1447- PERFORM R1005-00-SELECT-AGE-EXCLUSIVO */

                R1005_00_SELECT_AGE_EXCLUSIVO_SECTION();

                /*" -1449- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO VA2646B1O-AGENCIA-VENDA */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_AGENCIA_VENDA);

                /*" -1452- MOVE 06 TO VA2646B1O-NUM-PRODUTO PROPOFID-COD-PRODUTO-SIVPF */
                _.Move(06, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_NUM_PRODUTO);
                _.Move(06, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);


                /*" -1453- ELSE */
            }
            else
            {


                /*" -1456- MOVE ENDOSSOS-AGE-RCAP TO VA2646B1O-AGENCIA-VENDA PROPOFID-AGECOBR */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_AGENCIA_VENDA);
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);


                /*" -1459- MOVE 48 TO VA2646B1O-NUM-PRODUTO PROPOFID-COD-PRODUTO-SIVPF */
                _.Move(48, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_NUM_PRODUTO);
                _.Move(48, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);


                /*" -1461- END-IF. */
            }


            /*" -1465- MOVE PROPOVA-AGE-COBRANCA TO VA2646B1O-AGENCIA-PAGTO PROPOFID-AGEPGTO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_AGENCIA_PAGTO);
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);


            /*" -1469- MOVE PROPOVA-DATA-QUITACAO (1:4) TO VA2646B1O-DATA-AUTENT(5:4) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(1, 4), VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_DATA_AUTENT, 5, 4);

            /*" -1469- MOVE PROPOVA-DATA-QUITACAO (1:4) TO VA2646B1O-DATA-PROPOSTA(5:4) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(1, 4), VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_DATA_PROPOSTA, 5, 4);

            /*" -1473- MOVE PROPOVA-DATA-QUITACAO (6:2) TO VA2646B1O-DATA-AUTENT(3:2) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(6, 2), VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_DATA_AUTENT, 3, 2);

            /*" -1473- MOVE PROPOVA-DATA-QUITACAO (6:2) TO VA2646B1O-DATA-PROPOSTA(3:2) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(6, 2), VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_DATA_PROPOSTA, 3, 2);

            /*" -1477- MOVE PROPOVA-DATA-QUITACAO (9:2) TO VA2646B1O-DATA-AUTENT(1:2) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(9, 2), VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_DATA_AUTENT, 1, 2);

            /*" -1477- MOVE PROPOVA-DATA-QUITACAO (9:2) TO VA2646B1O-DATA-PROPOSTA(1:2) */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(9, 2), VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_DATA_PROPOSTA, 1, 2);

            /*" -1478- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '1' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "1")
            {

                /*" -1479- MOVE 1 TO VA2646B1O-TIPO-PAGTO */
                _.Move(1, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_TIPO_PAGTO);

                /*" -1480- ELSE */
            }
            else
            {


                /*" -1481- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '2' */

                if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "2")
                {

                    /*" -1482- MOVE 1 TO VA2646B1O-TIPO-PAGTO */
                    _.Move(1, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_TIPO_PAGTO);

                    /*" -1483- ELSE */
                }
                else
                {


                    /*" -1484- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '3' */

                    if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "3")
                    {

                        /*" -1485- MOVE 2 TO VA2646B1O-TIPO-PAGTO */
                        _.Move(2, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_TIPO_PAGTO);

                        /*" -1486- ELSE */
                    }
                    else
                    {


                        /*" -1487- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '4' */

                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "4")
                        {

                            /*" -1488- MOVE 4 TO VA2646B1O-TIPO-PAGTO */
                            _.Move(4, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_TIPO_PAGTO);

                            /*" -1489- ELSE */
                        }
                        else
                        {


                            /*" -1490- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '5' */

                            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "5")
                            {

                                /*" -1492- MOVE 3 TO VA2646B1O-TIPO-PAGTO. */
                                _.Move(3, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_TIPO_PAGTO);
                            }

                        }

                    }

                }

            }


            /*" -1495- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO VA2646B1O-AGENCIA-DEBITO */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_CONTA.VA2646B1O_AGENCIA_DEBITO);

            /*" -1498- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO VA2646B1O-OPERACAO */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_CONTA.VA2646B1O_OPERACAO);

            /*" -1501- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO VA2646B1O-NUM-CONTA */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_CONTA.VA2646B1O_NUM_CONTA);

            /*" -1504- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO VA2646B1O-DIG-CONTA */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_CONTA.VA2646B1O_DIG_CONTA);

            /*" -1505- IF OPCPAGVI-NUM-CARTAO-CREDITO NOT EQUAL ZEROS */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO != 00)
            {

                /*" -1507- MOVE OPCPAGVI-NUM-CARTAO-CREDITO TO VA2646B1O-NUM-CARTAO */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_CARTAO.VA2646B1O_NUM_CARTAO);

                /*" -1509- END-IF. */
            }


            /*" -1513- MOVE SPACES TO VA2646B1O-SAUDE-TITULAR VA2646B1O-SAUDE-CONJUGE */
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_SAUDE_TITULAR);
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_SAUDE_CONJUGE);


            /*" -1514- IF TEM-RENOVACAO EQUAL 'S' */

            if (WORK_AREA_0.TEM_RENOVACAO == "S")
            {

                /*" -1517- COMPUTE VA2646B1O-VAL-PREMIO-TOTAL = PARCEVID-PREMIO-VG + PARCEVID-PREMIO-AP */
                VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_VAL_PREMIO_TOTAL.Value = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG + PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP;

                /*" -1519- MOVE VA2646B1O-VAL-PREMIO-TOTAL TO VA2646B1O-VR-PAGO-SICOB */
                _.Move(VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_VAL_PREMIO_TOTAL, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_VR_PAGO_SICOB);

                /*" -1520- ELSE */
            }
            else
            {


                /*" -1524- MOVE HISCOBPR-VLPREMIO TO VA2646B1O-VAL-PREMIO-TOTAL VA2646B1O-VR-PAGO-SICOB PROPOFID-VAL-PAGO */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_VAL_PREMIO_TOTAL);
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_VR_PAGO_SICOB);
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);


                /*" -1526- END-IF. */
            }


            /*" -1534- MOVE SPACES TO VA2646B1O-SIT-APOSENT-INVAL VA2646B1O-SIT-RENOVACAO-AUT VA2646B1O-EMPRESA-CONVEN VA2646B1O-OPCAO-COBERTURA VA2646B1O-OPCAO-CONJUGE VA2646B1O-SPACES */
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_SIT_APOSENT_INVAL);
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_SIT_RENOVACAO_AUT);
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_EMPRESA_CONVEN);
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_OPCAO_COBERTURA);
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_OPCAO_CONJUGE);
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_SPACES);


            /*" -1538- MOVE OPCPAGVI-DIA-DEBITO TO VA2646B1O-DIA-VENCIMENTO PROPOFID-DIA-DEBITO */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_DIA_VENCIMENTO);
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);


            /*" -1550- MOVE ZEROS TO VA2646B1O-PERC-DESCONTO VA2646B1O-CNPJ-EMPRESA-CONV VA2646B1O-MOT-SITUACAO VA2646B1O-MOT-SITUACAO VA2646B1O-COD-PLANO VA2646B1O-TARIFA-COBRANCA VA2646B1O-VALOR-COMISSAO VA2646B1O-SEQ-ARQUIVO VA2646B1O-SEQ-REGISTRO VA2646B1O-ORIGEM-PROP */
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_PERC_DESCONTO);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_CNPJ_EMPRESA_CONV);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_MOT_SITUACAO);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_MOT_SITUACAO);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_COD_PLANO);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_TARIFA_COBRANCA);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_VALOR_COMISSAO);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_SEQ_ARQUIVO);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_SEQ_REGISTRO);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_ORIGEM_PROP);


            /*" -1551- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPRD9310 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -1553- MOVE 02 TO VA2646B1O-ORIGEM-PROP */
                _.Move(02, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_ORIGEM_PROP);

                /*" -1555- END-IF */
            }


            /*" -1558- MOVE 'MAN' TO VA2646B1O-SIT-PROPOSTA */
            _.Move("MAN", VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_SIT_PROPOSTA);

            /*" -1561- MOVE 'PAG' TO VA2646B1O-SIT-COBRANCA */
            _.Move("PAG", VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_SIT_COBRANCA);

            /*" -1564- MOVE OPCPAGVI-PERI-PAGAMENTO TO VA2646B1O-PERIPGTO. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_FILLER_1.VA2646B1O_PERIPGTO);

            /*" -1568- MOVE PLANOAGE-MATRIC-INDICADOR TO VA2646B1O-NUM-MATR-VENDEDOR PROPOFID-NRMATRVEN */
            _.Move(PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_MATRIC_INDICADOR, VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_NUM_MATR_VENDEDOR);
            _.Move(PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_MATRIC_INDICADOR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);


            /*" -1571- MOVE 'EMT' TO PROPOFID-SIT-PROPOSTA */
            _.Move("EMT", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -1578- MOVE 'VA2646B' TO PROPOFID-COD-USUARIO IDENTREL-COD-USUARIO PESSOFIS-COD-USUARIO PESSOJUR-COD-USUARIO PESSOA-COD-USUARIO */
            _.Move("VA2646B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO, IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_USUARIO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_USUARIO, PESSOJUR.DCLPESSOA_JURIDICA.PESSOJUR_COD_USUARIO, PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);

            /*" -1580- PERFORM R1600-00-SELECT-PARCEVID */

            R1600_00_SELECT_PARCEVID_SECTION();

            /*" -1582- IF WHOST-COUNT GREATER ZEROS */

            if (WHOST_COUNT > 00)
            {

                /*" -1584- IF OPCPAGVI-PERI-PAGAMENTO EQUAL 1 */

                if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 1)
                {

                    /*" -1585- IF WHOST-COUNT GREATER 2 */

                    if (WHOST_COUNT > 2)
                    {

                        /*" -1586- ADD 1 TO AC-DESP-6 */
                        WORK_AREA_0.AC_DESP_6.Value = WORK_AREA_0.AC_DESP_6 + 1;

                        /*" -1588- MOVE 'CERTIF. MENSAL C/MAIS DE 2 PARC PENDENTES' TO DET-DESC-ERRO */
                        _.Move("CERTIF. MENSAL C/MAIS DE 2 PARC PENDENTES", REG_DETALHE.DET_DESC_ERRO);

                        /*" -1589- PERFORM R1560-00-GRAVA-ERRO */

                        R1560_00_GRAVA_ERRO_SECTION();

                        /*" -1591- MOVE 'CAN' TO PROPOFID-SIT-PROPOSTA */
                        _.Move("CAN", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

                        /*" -1592- END-IF */
                    }


                    /*" -1593- ELSE */
                }
                else
                {


                    /*" -1594- ADD 1 TO AC-DESP-7 */
                    WORK_AREA_0.AC_DESP_7.Value = WORK_AREA_0.AC_DESP_7 + 1;

                    /*" -1596- MOVE 'CERTIF. ANUAL COM PARC PENDENTE' TO DET-DESC-ERRO */
                    _.Move("CERTIF. ANUAL COM PARC PENDENTE", REG_DETALHE.DET_DESC_ERRO);

                    /*" -1597- PERFORM R1560-00-GRAVA-ERRO */

                    R1560_00_GRAVA_ERRO_SECTION();

                    /*" -1599- MOVE 'CAN' TO PROPOFID-SIT-PROPOSTA */
                    _.Move("CAN", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

                    /*" -1600- END-IF */
                }


                /*" -1602- END-IF. */
            }


            /*" -1607- ADD 1 TO WS-QTD-REG3-PRP. */
            WS_QTD_REG3_PRP.Value = WS_QTD_REG3_PRP + 1;

            /*" -1614- WRITE REG-AVA2646B FROM VA2646B1O-REG. */
            _.Move(VA2646B1O_REG.GetMoveValues(), REG_AVA2646B);

            AVA2646B.Write(REG_AVA2646B.GetMoveValues().ToString());

            /*" -1615- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPRD9310 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -1616- PERFORM R1014-PROCESSAR-BENEFICIARIOS */

                R1014_PROCESSAR_BENEFICIARIOS_SECTION();

                /*" -1624- END-IF. */
            }


            /*" -1626- IF PROPOVA-COD-PRODUTO EQUAL 9310 OR JVPRD9310 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -1627- IF TEM-PROP-FIDELIZ EQUAL 'N' */

                if (WORK_AREA_0.TEM_PROP_FIDELIZ == "N")
                {

                    /*" -1628- PERFORM R1915-00-SELECT-MAX-RELAC */

                    R1915_00_SELECT_MAX_RELAC_SECTION();

                    /*" -1629- PERFORM R1921-00-INSERT-PROPOFID */

                    R1921_00_INSERT_PROPOFID_SECTION();

                    /*" -1630- ELSE */
                }
                else
                {


                    /*" -1631- PERFORM R1911-00-UPDATE-PROPOFID */

                    R1911_00_UPDATE_PROPOFID_SECTION();

                    /*" -1632- END-IF */
                }


                /*" -1634- ELSE */
            }
            else
            {


                /*" -1635- IF TEM-PROP-FIDELIZ EQUAL 'N' */

                if (WORK_AREA_0.TEM_PROP_FIDELIZ == "N")
                {

                    /*" -1636- PERFORM R1915-00-SELECT-MAX-RELAC */

                    R1915_00_SELECT_MAX_RELAC_SECTION();

                    /*" -1637- PERFORM R1920-00-INSERT-PROPOFID */

                    R1920_00_INSERT_PROPOFID_SECTION();

                    /*" -1639- ELSE */
                }
                else
                {


                    /*" -1640- MOVE 'S' TO PROPOFID-SITUACAO-ENVIO */
                    _.Move("S", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

                    /*" -1641- PERFORM R1910-00-UPDATE-PROPOFID */

                    R1910_00_UPDATE_PROPOFID_SECTION();

                    /*" -1642- END-IF */
                }


                /*" -1642- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1650- IF WS-ERRO-RENOV EQUAL 'S' */

            if (WORK_AREA_0.WS_ERRO_RENOV == "S")
            {

                /*" -1651- PERFORM R1050-ATUALIZA-RELATORIO */

                R1050_ATUALIZA_RELATORIO_SECTION();

                /*" -1652- MOVE SPACES TO WS-ERRO-RENOV */
                _.Move("", WORK_AREA_0.WS_ERRO_RENOV);

                /*" -1654- END-IF. */
            }


            /*" -1654- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1005-00-SELECT-AGE-EXCLUSIVO-SECTION */
        private void R1005_00_SELECT_AGE_EXCLUSIVO_SECTION()
        {
            /*" -1668- MOVE 'R1005' TO WNR-EXEC-SQL. */
            _.Move("R1005", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -1679- PERFORM R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1 */

            R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1();

            /*" -1683- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1684- DISPLAY 'VA2646B - ERRO ACESSO OPCAO_PAG_VIDAZUL' */
                _.Display($"VA2646B - ERRO ACESSO OPCAO_PAG_VIDAZUL");

                /*" -1685- DISPLAY 'NUM CERTIFICADO : ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM CERTIFICADO : {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1686- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -1687- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1687- END-IF. */
            }


        }

        [StopWatch]
        /*" R1005-00-SELECT-AGE-EXCLUSIVO-DB-SELECT-1 */
        public void R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1()
        {
            /*" -1679- EXEC SQL SELECT A.COD_AGENCIA_DEBITO INTO :OPCPAGVI-COD-AGENCIA-DEBITO FROM SEGUROS.OPCAO_PAG_VIDAZUL A WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND A.OPCAO_PAGAMENTO = '1' AND A.DATA_TERVIGENCIA = (SELECT MAX(X.DATA_TERVIGENCIA) FROM SEGUROS.OPCAO_PAG_VIDAZUL X WHERE X.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND X.OPCAO_PAGAMENTO = A.OPCAO_PAGAMENTO) END-EXEC. */

            var r1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1 = new R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1.Execute(r1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1005_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SELECT-PRODUVG-SECTION */
        private void R1010_00_SELECT_PRODUVG_SECTION()
        {
            /*" -1700- MOVE 'R1010' TO WNR-EXEC-SQL. */
            _.Move("R1010", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -1710- PERFORM R1010_00_SELECT_PRODUVG_DB_SELECT_1 */

            R1010_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -1714- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1715- DISPLAY 'VA2646B - ERRO ACESSO PRODUTOS_VG' */
                _.Display($"VA2646B - ERRO ACESSO PRODUTOS_VG");

                /*" -1716- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -1717- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1717- END-IF. */
            }


        }

        [StopWatch]
        /*" R1010-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R1010_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -1710- EXEC SQL SELECT COD_PRODUTO_AZUL INTO :PRODUVG-COD-PRODUTO-AZUL FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO AND ORIG_PRODU IN ( 'ESPEC' , 'CEF DEB CC' ) END-EXEC. */

            var r1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_COD_PRODUTO_AZUL, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_AZUL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1011-00-CURSOR-BENEFICIARIOS-SECTION */
        private void R1011_00_CURSOR_BENEFICIARIOS_SECTION()
        {
            /*" -1732- MOVE PROPOVA-NUM-CERTIFICADO TO BENEFICI-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO);

            /*" -1743- PERFORM R1011_00_CURSOR_BENEFICIARIOS_DB_DECLARE_1 */

            R1011_00_CURSOR_BENEFICIARIOS_DB_DECLARE_1();

            /*" -1745- PERFORM R1011_00_CURSOR_BENEFICIARIOS_DB_OPEN_1 */

            R1011_00_CURSOR_BENEFICIARIOS_DB_OPEN_1();

            /*" -1747- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1748- DISPLAY 'ERRO OPEN BENEFICIARIOS ' */
                _.Display($"ERRO OPEN BENEFICIARIOS ");

                /*" -1749- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -1749- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1011-00-CURSOR-BENEFICIARIOS-DB-OPEN-1 */
        public void R1011_00_CURSOR_BENEFICIARIOS_DB_OPEN_1()
        {
            /*" -1745- EXEC SQL OPEN BENEFICIARIOS END-EXEC. */

            BENEFICIARIOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1011_SAIDA*/

        [StopWatch]
        /*" R1012-00-LER-BENEFICIARIOS-SECTION */
        private void R1012_00_LER_BENEFICIARIOS_SECTION()
        {
            /*" -1766- PERFORM R1012_00_LER_BENEFICIARIOS_DB_FETCH_1 */

            R1012_00_LER_BENEFICIARIOS_DB_FETCH_1();

            /*" -1769- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1770- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1771- MOVE 'FIM' TO W-FIM-BENEFICIARIOS */
                    _.Move("FIM", WORK_AREA_0.W_FIM_BENEFICIARIOS);

                    /*" -1771- PERFORM R1012_00_LER_BENEFICIARIOS_DB_CLOSE_1 */

                    R1012_00_LER_BENEFICIARIOS_DB_CLOSE_1();

                    /*" -1773- ELSE */
                }
                else
                {


                    /*" -1774- DISPLAY 'VA2646B - ERRO FETCH BENEFICIARIOS ' */
                    _.Display($"VA2646B - ERRO FETCH BENEFICIARIOS ");

                    /*" -1775- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                    /*" -1776- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1012-00-LER-BENEFICIARIOS-DB-FETCH-1 */
        public void R1012_00_LER_BENEFICIARIOS_DB_FETCH_1()
        {
            /*" -1766- EXEC SQL FETCH BENEFICIARIOS INTO :BENEFICI-NUM-BENEFICIARIO , :BENEFICI-NOME-BENEFICIARIO , :BENEFICI-GRAU-PARENTESCO , :BENEFICI-PCT-PART-BENEFICIA END-EXEC. */

            if (BENEFICIARIOS.Fetch())
            {
                _.Move(BENEFICIARIOS.BENEFICI_NUM_BENEFICIARIO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_BENEFICIARIO);
                _.Move(BENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO);
                _.Move(BENEFICIARIOS.BENEFICI_GRAU_PARENTESCO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO);
                _.Move(BENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA, BENEFICI.DCLBENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA);
            }

        }

        [StopWatch]
        /*" R1012-00-LER-BENEFICIARIOS-DB-CLOSE-1 */
        public void R1012_00_LER_BENEFICIARIOS_DB_CLOSE_1()
        {
            /*" -1771- EXEC SQL CLOSE BENEFICIARIOS END-EXEC */

            BENEFICIARIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1012_SAIDA*/

        [StopWatch]
        /*" R1013-00-GERAR-REGISTRO-TP4-SECTION */
        private void R1013_00_GERAR_REGISTRO_TP4_SECTION()
        {
            /*" -1789- MOVE BENEFICI-NOME-BENEFICIARIO TO R4-NOME OF REG-BENEFIC. */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO, VA2646B1O_REG.REG_BENEFIC.R4_NOME);

            /*" -1792- IF BENEFICI-GRAU-PARENTESCO EQUAL 'CONJUGE' OR 'MARIDO' OR 'MULHER' OR 'ESPOSA' OR 'ESPOSO' */

            if (BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO.In("CONJUGE", "MARIDO", "MULHER", "ESPOSA", "ESPOSO"))
            {

                /*" -1794- MOVE 1 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                _.Move(1, VA2646B1O_REG.REG_BENEFIC.R4_GRAU_PARENTESCO);

                /*" -1797- ELSE */
            }
            else
            {


                /*" -1799- IF BENEFICI-GRAU-PARENTESCO (1:7) EQUAL 'COMPANH' */

                if (BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO.Substring(1, 7) == "COMPANH")
                {

                    /*" -1801- MOVE 2 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                    _.Move(2, VA2646B1O_REG.REG_BENEFIC.R4_GRAU_PARENTESCO);

                    /*" -1802- ELSE */
                }
                else
                {


                    /*" -1804- IF BENEFICI-GRAU-PARENTESCO EQUAL 'FILHOS' OR 'FILHO' OR 'FILHA' */

                    if (BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO.In("FILHOS", "FILHO", "FILHA"))
                    {

                        /*" -1806- MOVE 3 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                        _.Move(3, VA2646B1O_REG.REG_BENEFIC.R4_GRAU_PARENTESCO);

                        /*" -1807- ELSE */
                    }
                    else
                    {


                        /*" -1809- IF BENEFICI-GRAU-PARENTESCO EQUAL 'PAIS' OR 'PAI' OR 'MAE' */

                        if (BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO.In("PAIS", "PAI", "MAE"))
                        {

                            /*" -1811- MOVE 4 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                            _.Move(4, VA2646B1O_REG.REG_BENEFIC.R4_GRAU_PARENTESCO);

                            /*" -1812- ELSE */
                        }
                        else
                        {


                            /*" -1814- IF BENEFICI-GRAU-PARENTESCO EQUAL 'IRMAOS' OR 'IRMAO' OR 'IRMA' */

                            if (BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO.In("IRMAOS", "IRMAO", "IRMA"))
                            {

                                /*" -1816- MOVE 5 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                                _.Move(5, VA2646B1O_REG.REG_BENEFIC.R4_GRAU_PARENTESCO);

                                /*" -1817- ELSE */
                            }
                            else
                            {


                                /*" -1820- MOVE 6 TO R4-GRAU-PARENTESCO OF REG-BENEFIC. */
                                _.Move(6, VA2646B1O_REG.REG_BENEFIC.R4_GRAU_PARENTESCO);
                            }

                        }

                    }

                }

            }


            /*" -1823- MOVE BENEFICI-PCT-PART-BENEFICIA TO R4-PCT-PARTICIP OF REG-BENEFIC. */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA, VA2646B1O_REG.REG_BENEFIC.R4_PCT_PARTICIP);

            /*" -1826- ADD 1 TO WS-QTD-REG4-PRP. */
            WS_QTD_REG4_PRP.Value = WS_QTD_REG4_PRP + 1;

            /*" -1829- WRITE REG-AVA2646B FROM VA2646B1O-REG. */
            _.Move(VA2646B1O_REG.GetMoveValues(), REG_AVA2646B);

            AVA2646B.Write(REG_AVA2646B.GetMoveValues().ToString());

            /*" -1830- PERFORM R1012-00-LER-BENEFICIARIOS. */

            R1012_00_LER_BENEFICIARIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1013_SAIDA*/

        [StopWatch]
        /*" R1014-PROCESSAR-BENEFICIARIOS-SECTION */
        private void R1014_PROCESSAR_BENEFICIARIOS_SECTION()
        {
            /*" -1840- MOVE SPACES TO REG-BENEFIC. */
            _.Move("", VA2646B1O_REG.REG_BENEFIC);

            /*" -1843- MOVE '4' TO VA2646B1O-IDENTIFICA. */
            _.Move("4", VA2646B1O_REG.VA2646B1O_IDENTIFICA);

            /*" -1844- IF WS-NUM-PROPOSTA(1:1) NOT EQUAL ZEROS */

            if (WORK_AREA_0.WS_NUM_PROPOSTA.Substring(1, 1) != 00)
            {

                /*" -1846- MOVE PROPOVA-NUM-CERTIFICADO TO R4-NUM-PROPOSTA */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VA2646B1O_REG.REG_BENEFIC.R4_NUM_PROPOSTA);

                /*" -1847- ELSE */
            }
            else
            {


                /*" -1849- MOVE 60 TO WS-NUM-PROPOSTA-02 */
                _.Move(60, WORK_AREA_0.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_02);

                /*" -1851- MOVE PROPOVA-NUM-CERTIFICADO TO WS-NUM-PROPOSTA-11 */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WORK_AREA_0.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_11);

                /*" -1853- MOVE ZEROS TO WS-NUM-PROPOSTA-01 */
                _.Move(0, WORK_AREA_0.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_01);

                /*" -1855- MOVE WS-NUM-PROPOSTA-EXC TO R4-NUM-PROPOSTA */
                _.Move(WORK_AREA_0.WS_NUM_PROPOSTA_EXC, VA2646B1O_REG.REG_BENEFIC.R4_NUM_PROPOSTA);

                /*" -1857- END-IF. */
            }


            /*" -1867- MOVE ZEROS TO R4-DATA-NASCIMENTO OF REG-BENEFIC, R4-CGC-CPF OF REG-BENEFIC, R4-SEXO OF REG-BENEFIC, R4-ESTADO-CIVIL OF REG-BENEFIC, R4-PCT-FGB OF REG-BENEFIC, R4-PCT-PECULIO OF REG-BENEFIC, R4-PCT-PENSAO OF REG-BENEFIC, R4-QTDE-TITULOS OF REG-BENEFIC. */
            _.Move(0, VA2646B1O_REG.REG_BENEFIC.R4_DATA_NASCIMENTO);
            _.Move(0, VA2646B1O_REG.REG_BENEFIC.R4_CGC_CPF);
            _.Move(0, VA2646B1O_REG.REG_BENEFIC.R4_SEXO);
            _.Move(0, VA2646B1O_REG.REG_BENEFIC.R4_ESTADO_CIVIL);
            _.Move(0, VA2646B1O_REG.REG_BENEFIC.R4_PCT_FGB);
            _.Move(0, VA2646B1O_REG.REG_BENEFIC.R4_PCT_PECULIO);
            _.Move(0, VA2646B1O_REG.REG_BENEFIC.R4_PCT_PENSAO);
            _.Move(0, VA2646B1O_REG.REG_BENEFIC.R4_QTDE_TITULOS);


            /*" -1870- MOVE SPACES TO W-FIM-BENEFICIARIOS. */
            _.Move("", WORK_AREA_0.W_FIM_BENEFICIARIOS);

            /*" -1872- PERFORM R1011-00-CURSOR-BENEFICIARIOS. */

            R1011_00_CURSOR_BENEFICIARIOS_SECTION();

            /*" -1874- PERFORM R1012-00-LER-BENEFICIARIOS. */

            R1012_00_LER_BENEFICIARIOS_SECTION();

            /*" -1875- PERFORM R1013-00-GERAR-REGISTRO-TP4 UNTIL W-FIM-BENEFICIARIOS EQUAL 'FIM' . */

            while (!(WORK_AREA_0.W_FIM_BENEFICIARIOS == "FIM"))
            {

                R1013_00_GERAR_REGISTRO_TP4_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1014_SAIDA*/

        [StopWatch]
        /*" R1015-SELECT-RELATORIOS-SECTION */
        private void R1015_SELECT_RELATORIOS_SECTION()
        {
            /*" -1896- MOVE 'R1020' TO WNR-EXEC-SQL. */
            _.Move("R1020", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -1920- PERFORM R1015_SELECT_RELATORIOS_DB_SELECT_1 */

            R1015_SELECT_RELATORIOS_DB_SELECT_1();

            /*" -1923- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1924- DISPLAY 'VA2646B - ERRO ACESSO RELATORIOS' */
                _.Display($"VA2646B - ERRO ACESSO RELATORIOS");

                /*" -1925- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1926- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -1927- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1929- END-IF. */
            }


            /*" -1930- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1931- MOVE 'S' TO TEM-RENOVACAO */
                _.Move("S", WORK_AREA_0.TEM_RENOVACAO);

                /*" -1932- ELSE */
            }
            else
            {


                /*" -1933- MOVE SPACES TO TEM-RENOVACAO */
                _.Move("", WORK_AREA_0.TEM_RENOVACAO);

                /*" -1933- END-IF. */
            }


        }

        [StopWatch]
        /*" R1015-SELECT-RELATORIOS-DB-SELECT-1 */
        public void R1015_SELECT_RELATORIOS_DB_SELECT_1()
        {
            /*" -1920- EXEC SQL SELECT DATA_SOLICITACAO , COD_RELATORIO , NUM_CERTIFICADO , NUM_PARCELA , COD_PLANO , TIMESTAMP INTO :RELATORI-DATA-SOLICITACAO ,:RELATORI-COD-RELATORIO ,:RELATORI-NUM-CERTIFICADO ,:RELATORI-NUM-PARCELA ,:RELATORI-COD-PLANO ,:RELATORI-TIMESTAMP FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO IN ( 'VGICA' , 'VGIDA' , 'VGIEA' ) AND SIT_REGISTRO = '0' AND NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA > 0 AND COD_PLANO > 0 ORDER BY COD_RELATORIO , NUM_CERTIFICADO , NUM_PARCELA , TIMESTAMP DESC FETCH FIRST 1 ROWS ONLY END-EXEC. */

            var r1015_SELECT_RELATORIOS_DB_SELECT_1_Query1 = new R1015_SELECT_RELATORIOS_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1015_SELECT_RELATORIOS_DB_SELECT_1_Query1.Execute(r1015_SELECT_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(executed_1.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
                _.Move(executed_1.RELATORI_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);
                _.Move(executed_1.RELATORI_NUM_PARCELA, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);
                _.Move(executed_1.RELATORI_COD_PLANO, RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO);
                _.Move(executed_1.RELATORI_TIMESTAMP, RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1015_SAIDA*/

        [StopWatch]
        /*" R1016-SELECT-PARCELA-SECTION */
        private void R1016_SELECT_PARCELA_SECTION()
        {
            /*" -1948- MOVE 'R1016' TO WNR-EXEC-SQL. */
            _.Move("R1016", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -1958- PERFORM R1016_SELECT_PARCELA_DB_SELECT_1 */

            R1016_SELECT_PARCELA_DB_SELECT_1();

            /*" -1961- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1962- DISPLAY 'VA2646B - ERRO ACESSO PARCELAS_VIDAZUL' */
                _.Display($"VA2646B - ERRO ACESSO PARCELAS_VIDAZUL");

                /*" -1963- DISPLAY 'CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -1964- DISPLAY 'NUM-PARCELA = ' RELATORI-NUM-PARCELA */
                _.Display($"NUM-PARCELA = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                /*" -1965- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -1966- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1968- END-IF. */
            }


            /*" -1969- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1970- DISPLAY 'VA2646B - PARCELA RENOVACAO NAO CADASTRADA' */
                _.Display($"VA2646B - PARCELA RENOVACAO NAO CADASTRADA");

                /*" -1971- DISPLAY 'CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -1972- DISPLAY 'NUM-PARCELA = ' RELATORI-NUM-PARCELA */
                _.Display($"NUM-PARCELA = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                /*" -1973- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -1974- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1975- END-IF. */
            }


        }

        [StopWatch]
        /*" R1016-SELECT-PARCELA-DB-SELECT-1 */
        public void R1016_SELECT_PARCELA_DB_SELECT_1()
        {
            /*" -1958- EXEC SQL SELECT PREMIO_VG , PREMIO_AP , SIT_REGISTRO INTO :PARCEVID-PREMIO-VG ,:PARCEVID-PREMIO-AP ,:PARCEVID-SIT-REGISTRO FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA END-EXEC. */

            var r1016_SELECT_PARCELA_DB_SELECT_1_Query1 = new R1016_SELECT_PARCELA_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1016_SELECT_PARCELA_DB_SELECT_1_Query1.Execute(r1016_SELECT_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEVID_PREMIO_VG, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG);
                _.Move(executed_1.PARCEVID_PREMIO_AP, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP);
                _.Move(executed_1.PARCEVID_SIT_REGISTRO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1016_SAIDA*/

        [StopWatch]
        /*" R1020-00-SELECT-ENDOSSOS-SECTION */
        private void R1020_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -1987- MOVE 'R1020' TO WNR-EXEC-SQL. */
            _.Move("R1020", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -1999- PERFORM R1020_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R1020_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -2003- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2004- DISPLAY 'VA2646B - ERRO ACESSO ENDOSSOS' */
                _.Display($"VA2646B - ERRO ACESSO ENDOSSOS");

                /*" -2005- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2006- DISPLAY 'NUM-APOLICE = ' PROPOVA-NUM-APOLICE */
                _.Display($"NUM-APOLICE = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -2007- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2008- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2008- END-IF. */
            }


        }

        [StopWatch]
        /*" R1020-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R1020_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -1999- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_TERVIGENCIA, AGE_RCAP INTO :ENDOSSOS-DATA-INIVIGENCIA, :ENDOSSOS-DATA-TERVIGENCIA, :ENDOSSOS-AGE-RCAP FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC. */

            var r1020_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R1020_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1020_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r1020_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(executed_1.ENDOSSOS_AGE_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-SELECT-PROPFIDH-SECTION */
        private void R1030_00_SELECT_PROPFIDH_SECTION()
        {
            /*" -2022- MOVE 'R1030' TO WNR-EXEC-SQL. */
            _.Move("R1030", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2034- PERFORM R1030_00_SELECT_PROPFIDH_DB_SELECT_1 */

            R1030_00_SELECT_PROPFIDH_DB_SELECT_1();

            /*" -2037- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2038- DISPLAY 'VA2646B - ERRO ACESSO HIST_PROP_FIDELIZ' */
                _.Display($"VA2646B - ERRO ACESSO HIST_PROP_FIDELIZ");

                /*" -2039- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2040- DISPLAY 'PROPOSTA    = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"PROPOSTA    = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -2041- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2042- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2043- END-IF. */
            }


        }

        [StopWatch]
        /*" R1030-00-SELECT-PROPFIDH-DB-SELECT-1 */
        public void R1030_00_SELECT_PROPFIDH_DB_SELECT_1()
        {
            /*" -2034- EXEC SQL SELECT SIT_PROPOSTA , DATA_SITUACAO INTO :PROPFIDH-SIT-PROPOSTA ,:PROPFIDH-DATA-SITUACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPOFID-NUM-IDENTIFICACAO AND SIT_MOTIVO_SIVPF = :PROPFIDH-SIT-MOTIVO-SIVPF ORDER BY DATA_SITUACAO DESC FETCH FIRST 1 ROWS ONLY END-EXEC. */

            var r1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1 = new R1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_SIT_MOTIVO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.ToString(),
            };

            var executed_1 = R1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1.Execute(r1030_00_SELECT_PROPFIDH_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);
                _.Move(executed_1.PROPFIDH_DATA_SITUACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1050-ATUALIZA-RELATORIO-SECTION */
        private void R1050_ATUALIZA_RELATORIO_SECTION()
        {
            /*" -2056- MOVE 'R1050' TO WNR-EXEC-SQL. */
            _.Move("R1050", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2064- PERFORM R1050_ATUALIZA_RELATORIO_DB_UPDATE_1 */

            R1050_ATUALIZA_RELATORIO_DB_UPDATE_1();

            /*" -2067- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2068- DISPLAY 'R1050-ERRO UPDATE RELATORIOS' */
                _.Display($"R1050-ERRO UPDATE RELATORIOS");

                /*" -2069- DISPLAY 'DATA_SOLICITACAO = ' RELATORI-COD-RELATORIO */
                _.Display($"DATA_SOLICITACAO = {RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}");

                /*" -2070- DISPLAY 'COD-RELATORIO    = ' RELATORI-COD-RELATORIO */
                _.Display($"COD-RELATORIO    = {RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}");

                /*" -2071- DISPLAY 'CERTIFICADO      = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO      = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2072- DISPLAY 'PARCELA          = ' RELATORI-NUM-PARCELA */
                _.Display($"PARCELA          = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                /*" -2073- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2074- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1050-ATUALIZA-RELATORIO-DB-UPDATE-1 */
        public void R1050_ATUALIZA_RELATORIO_DB_UPDATE_1()
        {
            /*" -2064- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE DATA_SOLICITACAO = :RELATORI-DATA-SOLICITACAO AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA END-EXEC. */

            var r1050_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1 = new R1050_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1()
            {
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            R1050_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1.Execute(r1050_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-CLIENTES-SECTION */
        private void R1100_00_SELECT_CLIENTES_SECTION()
        {
            /*" -2086- MOVE 'R1100' TO WNR-EXEC-SQL. */
            _.Move("R1100", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2103- PERFORM R1100_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1100_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -2107- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2108- DISPLAY 'VA2646B - ERRO ACESSO CLIENTES' */
                _.Display($"VA2646B - ERRO ACESSO CLIENTES");

                /*" -2109- DISPLAY 'NUM-CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2110- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2111- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2113- END-IF. */
            }


            /*" -2114- IF VIND-DTNASC LESS +0 */

            if (VIND_DTNASC < +0)
            {

                /*" -2116- MOVE '0001-01-01' TO CLIENTES-DATA-NASCIMENTO */
                _.Move("0001-01-01", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

                /*" -2118- END-IF. */
            }


            /*" -2119- IF VIND-IDE-SEXO LESS +0 */

            if (VIND_IDE_SEXO < +0)
            {

                /*" -2121- MOVE 'M' TO CLIENTES-IDE-SEXO */
                _.Move("M", CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);

                /*" -2123- END-IF. */
            }


            /*" -2124- IF VIND-ESTCIV LESS +0 */

            if (VIND_ESTCIV < +0)
            {

                /*" -2126- MOVE 'O' TO CLIENTES-ESTADO-CIVIL */
                _.Move("O", CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL);

                /*" -2126- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1100_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -2103- EXEC SQL SELECT CGCCPF , NOME_RAZAO , TIPO_PESSOA , DATA_NASCIMENTO, IDE_SEXO, ESTADO_CIVIL INTO :CLIENTES-CGCCPF , :CLIENTES-NOME-RAZAO, :CLIENTES-TIPO-PESSOA, :CLIENTES-DATA-NASCIMENTO :VIND-DTNASC , :CLIENTES-IDE-SEXO :VIND-IDE-SEXO, :CLIENTES-ESTADO-CIVIL :VIND-ESTCIV FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

            var r1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASC, VIND_DTNASC);
                _.Move(executed_1.CLIENTES_IDE_SEXO, CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
                _.Move(executed_1.VIND_IDE_SEXO, VIND_IDE_SEXO);
                _.Move(executed_1.CLIENTES_ESTADO_CIVIL, CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL);
                _.Move(executed_1.VIND_ESTCIV, VIND_ESTCIV);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-ENDERECO-SECTION */
        private void R1200_00_SELECT_ENDERECO_SECTION()
        {
            /*" -2140- MOVE 'R1200' TO WNR-EXEC-SQL. */
            _.Move("R1200", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2162- PERFORM R1200_00_SELECT_ENDERECO_DB_SELECT_1 */

            R1200_00_SELECT_ENDERECO_DB_SELECT_1();

            /*" -2166- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2167- DISPLAY 'VA2646B - ERRO ACESSO ENDERECOS' */
                _.Display($"VA2646B - ERRO ACESSO ENDERECOS");

                /*" -2168- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2169- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2170- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2170- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-ENDERECO-DB-SELECT-1 */
        public void R1200_00_SELECT_ENDERECO_DB_SELECT_1()
        {
            /*" -2162- EXEC SQL SELECT ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX INTO :ENDERECO-ENDERECO , :ENDERECO-BAIRRO , :ENDERECO-CIDADE , :ENDERECO-SIGLA-UF , :ENDERECO-CEP , :ENDERECO-DDD , :ENDERECO-TELEFONE , :ENDERECO-FAX FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :PROPOVA-OCOREND END-EXEC. */

            var r1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1 = new R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
            };

            var executed_1 = R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(executed_1.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(executed_1.ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-OPCPAGVI-SECTION */
        private void R1300_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -2184- MOVE 'R1300' TO WNR-EXEC-SQL. */
            _.Move("R1300", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2206- PERFORM R1300_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R1300_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -2210- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2211- DISPLAY 'VA2646B - ERRO ACESSO OPCAO_PAG_VIDAZUL' */
                _.Display($"VA2646B - ERRO ACESSO OPCAO_PAG_VIDAZUL");

                /*" -2212- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2213- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2214- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2216- END-IF. */
            }


            /*" -2217- IF VIND-AGENCIA LESS +0 */

            if (VIND_AGENCIA < +0)
            {

                /*" -2222- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                /*" -2224- END-IF. */
            }


            /*" -2225- IF VIND-CARTAO LESS +0 */

            if (VIND_CARTAO < +0)
            {

                /*" -2227- MOVE ZEROS TO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -2227- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R1300_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -2206- EXEC SQL SELECT OPCAO_PAGAMENTO , PERI_PAGAMENTO , DIA_DEBITO , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO , NUM_CARTAO_CREDITO INTO :OPCPAGVI-OPCAO-PAGAMENTO , :OPCPAGVI-PERI-PAGAMENTO , :OPCPAGVI-DIA-DEBITO , :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGENCIA , :OPCPAGVI-OPE-CONTA-DEBITO :VIND-OPERACAO , :OPCPAGVI-NUM-CONTA-DEBITO :VIND-CONTA , :OPCPAGVI-DIG-CONTA-DEBITO :VIND-DIG-CONTA , :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-CARTAO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_AGENCIA, VIND_AGENCIA);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPERACAO, VIND_OPERACAO);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_CONTA, VIND_CONTA);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIG_CONTA, VIND_DIG_CONTA);
                _.Move(executed_1.OPCPAGVI_NUM_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
                _.Move(executed_1.VIND_CARTAO, VIND_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-CLIENEMA-SECTION */
        private void R1400_00_SELECT_CLIENEMA_SECTION()
        {
            /*" -2241- MOVE 'R1400' TO WNR-EXEC-SQL. */
            _.Move("R1400", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2248- PERFORM R1400_00_SELECT_CLIENEMA_DB_SELECT_1 */

            R1400_00_SELECT_CLIENEMA_DB_SELECT_1();

            /*" -2251- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2252- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2253- MOVE SPACES TO CLIENEMA-EMAIL */
                    _.Move("", CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);

                    /*" -2254- ELSE */
                }
                else
                {


                    /*" -2255- DISPLAY 'VA2646B - ERRO ACESSO CLIENTE_EMAIL' */
                    _.Display($"VA2646B - ERRO ACESSO CLIENTE_EMAIL");

                    /*" -2256- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2257- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                    /*" -2258- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2258- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-CLIENEMA-DB-SELECT-1 */
        public void R1400_00_SELECT_CLIENEMA_DB_SELECT_1()
        {
            /*" -2248- EXEC SQL SELECT EMAIL INTO :CLIENEMA-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

            var r1400_00_SELECT_CLIENEMA_DB_SELECT_1_Query1 = new R1400_00_SELECT_CLIENEMA_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_CLIENEMA_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_CLIENEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-HISCOBPR-SECTION */
        private void R1500_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -2272- MOVE 'R1500' TO WNR-EXEC-SQL. */
            _.Move("R1500", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2280- PERFORM R1500_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1500_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -2284- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2285- DISPLAY 'VA2646B - ERRO ACESSO HIS_COBER_PROPOST' */
                _.Display($"VA2646B - ERRO ACESSO HIS_COBER_PROPOST");

                /*" -2286- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2287- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2288- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2288- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1500_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -2280- EXEC SQL SELECT VLPREMIO INTO :HISCOBPR-VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = 1 END-EXEC. */

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
        /*" R1550-00-SELECT-AGENCCEF-SECTION */
        private void R1550_00_SELECT_AGENCCEF_SECTION()
        {
            /*" -2302- MOVE 'R1550' TO WNR-EXEC-SQL. */
            _.Move("R1550", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2304- INITIALIZE DCLAGENCIAS-CEF. */
            _.Initialize(
                AGENCCEF.DCLAGENCIAS_CEF
            );

            /*" -2306- MOVE 'S' TO WS-TEM-AGENCCEF. */
            _.Move("S", WS_TEM_AGENCCEF);

            /*" -2313- PERFORM R1550_00_SELECT_AGENCCEF_DB_SELECT_1 */

            R1550_00_SELECT_AGENCCEF_DB_SELECT_1();

            /*" -2316- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2317- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2318- MOVE 'N' TO WS-TEM-AGENCCEF */
                    _.Move("N", WS_TEM_AGENCCEF);

                    /*" -2319- ELSE */
                }
                else
                {


                    /*" -2320- DISPLAY 'VA2646B - ERRO ACESSO AGENCIAS_CEF' */
                    _.Display($"VA2646B - ERRO ACESSO AGENCIAS_CEF");

                    /*" -2321- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2322- DISPLAY 'AGENCIA     = ' ENDOSSOS-AGE-RCAP */
                    _.Display($"AGENCIA     = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP}");

                    /*" -2323- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                    /*" -2324- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2325- END-IF */
                }


                /*" -2325- END-IF. */
            }


        }

        [StopWatch]
        /*" R1550-00-SELECT-AGENCCEF-DB-SELECT-1 */
        public void R1550_00_SELECT_AGENCCEF_DB_SELECT_1()
        {
            /*" -2313- EXEC SQL SELECT COD_AGENCIA, SITUACAO INTO :AGENCCEF-COD-AGENCIA, :AGENCCEF-SITUACAO FROM SEGUROS.AGENCIAS_CEF WHERE COD_AGENCIA = :ENDOSSOS-AGE-RCAP END-EXEC. */

            var r1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 = new R1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1()
            {
                ENDOSSOS_AGE_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP.ToString(),
            };

            var executed_1 = R1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1.Execute(r1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCCEF_COD_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);
                _.Move(executed_1.AGENCCEF_SITUACAO, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_99_SAIDA*/

        [StopWatch]
        /*" R1560-00-GRAVA-ERRO-SECTION */
        private void R1560_00_GRAVA_ERRO_SECTION()
        {
            /*" -2339- MOVE 'R1560' TO WNR-EXEC-SQL. */
            _.Move("R1560", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2343- MOVE ';' TO DET-SEP1 DET-SEP2 DET-SEP3. */
            _.Move(";", REG_DETALHE.DET_SEP1, REG_DETALHE.DET_SEP2, REG_DETALHE.DET_SEP3);

            /*" -2344- MOVE PROPOVA-NUM-CERTIFICADO TO DET-PROPOSTA. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, REG_DETALHE.DET_PROPOSTA);

            /*" -2345- MOVE ENDOSSOS-AGE-RCAP TO DET-AGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP, REG_DETALHE.DET_AGENCIA);

            /*" -2347- MOVE HISCOBPR-VLPREMIO TO DET-PREMIO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, REG_DETALHE.DET_PREMIO);

            /*" -2349- WRITE REG-RVA2646B FROM REG-DETALHE. */
            _.Move(REG_DETALHE.GetMoveValues(), REG_RVA2646B);

            RVA2646B.Write(REG_RVA2646B.GetMoveValues().ToString());

            /*" -2354- INITIALIZE DET-PROPOSTA DET-AGENCIA DET-PREMIO DET-DESC-ERRO. */
            _.Initialize(
                REG_DETALHE.DET_PROPOSTA
                , REG_DETALHE.DET_AGENCIA
                , REG_DETALHE.DET_PREMIO
                , REG_DETALHE.DET_DESC_ERRO
            );

            /*" -2354- ADD 1 TO WS-LIDOS-ERRO. */
            WS_LIDOS_ERRO.Value = WS_LIDOS_ERRO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1560_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-PARCEVID-SECTION */
        private void R1600_00_SELECT_PARCEVID_SECTION()
        {
            /*" -2368- MOVE 'R1600' TO WNR-EXEC-SQL. */
            _.Move("R1600", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2371- MOVE ZEROS TO WHOST-COUNT */
            _.Move(0, WHOST_COUNT);

            /*" -2378- PERFORM R1600_00_SELECT_PARCEVID_DB_SELECT_1 */

            R1600_00_SELECT_PARCEVID_DB_SELECT_1();

            /*" -2382- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2383- DISPLAY 'VA2646B - ERRO ACESSO PARCELAS_VIDAZUL' */
                _.Display($"VA2646B - ERRO ACESSO PARCELAS_VIDAZUL");

                /*" -2384- DISPLAY 'CERTIFICADO     = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2385- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2385- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-PARCEVID-DB-SELECT-1 */
        public void R1600_00_SELECT_PARCEVID_DB_SELECT_1()
        {
            /*" -2378- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND SIT_REGISTRO IN ( ' ' , '0' ) AND DATA_VENCIMENTO < :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */

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
        /*" R1700-00-SELECT-PLANOAGE-SECTION */
        private void R1700_00_SELECT_PLANOAGE_SECTION()
        {
            /*" -2399- MOVE 'R1700' TO WNR-EXEC-SQL. */
            _.Move("R1700", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2407- PERFORM R1700_00_SELECT_PLANOAGE_DB_SELECT_1 */

            R1700_00_SELECT_PLANOAGE_DB_SELECT_1();

            /*" -2412- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 AND SQLCODE NOT EQUAL -811 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100 && DB.SQLCODE != -811)
            {

                /*" -2413- DISPLAY 'VA2646B - ERRO ACESSO PLANO_AGENCIAMENTO' */
                _.Display($"VA2646B - ERRO ACESSO PLANO_AGENCIAMENTO");

                /*" -2414- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2415- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2416- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2418- END-IF. */
            }


            /*" -2420- IF SQLCODE EQUAL 100 OR VIND-MATRIC LESS +0 */

            if (DB.SQLCODE == 100 || VIND_MATRIC < +0)
            {

                /*" -2422- MOVE ZEROS TO PLANOAGE-MATRIC-INDICADOR */
                _.Move(0, PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_MATRIC_INDICADOR);

                /*" -2422- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-PLANOAGE-DB-SELECT-1 */
        public void R1700_00_SELECT_PLANOAGE_DB_SELECT_1()
        {
            /*" -2407- EXEC SQL SELECT MATRIC_INDICADOR INTO :PLANOAGE-MATRIC-INDICADOR:VIND-MATRIC FROM SEGUROS.PLANO_AGENCIAMENTO WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC. */

            var r1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1 = new R1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1.Execute(r1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLANOAGE_MATRIC_INDICADOR, PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_MATRIC_INDICADOR);
                _.Move(executed_1.VIND_MATRIC, VIND_MATRIC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1706-00-MONTA-PROP-VIDA-SECTION */
        private void R1706_00_MONTA_PROP_VIDA_SECTION()
        {
            /*" -2435- MOVE 'R1706' TO WNR-EXEC-SQL. */
            _.Move("R1706", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2437- MOVE 48 TO PROPOFID-COD-PRODUTO-SIVPF */
            _.Move(48, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);

            /*" -2439- PERFORM R1710-BUSCA0-SEQUENC-PROPOSTA */

            R1710_BUSCA0_SEQUENC_PROPOSTA_SECTION();

            /*" -2441- MOVE ZEROS TO WS-NUM-DIGITO-01. */
            _.Move(0, AREA_MONTA.WS_NUM_PROPOST_MONTA_R.WS_NUM_DIGITO_01);

            /*" -2443- MOVE 6 TO WS-NUM-CANAL-01 WS-NUM-CANAL-01-SAI */
            _.Move(6, AREA_MONTA.WS_NUM_PROPOST_MONTA_R.WS_NUM_CANAL_01);
            _.Move(6, WORK_AREA.WS_NUM_PROPOSTA_SAI_R.WS_NUM_CANAL_01_SAI);


            /*" -2444- IF ENDOSSOS-AGE-RCAP EQUAL 9999 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP == 9999)
            {

                /*" -2446- MOVE PROPOVA-AGE-COBRANCA TO WS-NUM-AGENCIA-04 WS-NUM-AGENCIA-04-SAI */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA, AREA_MONTA.WS_NUM_PROPOST_MONTA_R.WS_NUM_AGENCIA_04);
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA, WORK_AREA.WS_NUM_PROPOSTA_SAI_R.WS_NUM_AGENCIA_04_SAI);


                /*" -2447- ELSE */
            }
            else
            {


                /*" -2449- MOVE ENDOSSOS-AGE-RCAP TO WS-NUM-AGENCIA-04 WS-NUM-AGENCIA-04-SAI */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP, AREA_MONTA.WS_NUM_PROPOST_MONTA_R.WS_NUM_AGENCIA_04);
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP, WORK_AREA.WS_NUM_PROPOSTA_SAI_R.WS_NUM_AGENCIA_04_SAI);


                /*" -2450- END-IF */
            }


            /*" -2452- MOVE PROPOFID-COD-PRODUTO-SIVPF TO WS-NUM-PRODUTO-02 WS-NUM-PRODUTO-02-SAI */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, AREA_MONTA.WS_NUM_PROPOST_MONTA_R.WS_NUM_PRODUTO_02);
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, WORK_AREA.WS_NUM_PROPOSTA_SAI_R.WS_NUM_PRODUTO_02_SAI);


            /*" -2453- MOVE PRDSIVPF-SEQ-PRD-PROPOSTA TO WS-NUM-SEQUENCIAL-06-SAI */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_SEQ_PRD_PROPOSTA, WORK_AREA.WS_NUM_PROPOSTA_SAI_R.WS_NUM_SEQUENCIAL_06_SAI);

            /*" -2454- MOVE WS-NUM-PROPOST-MONTA TO LPARM01X */
            _.Move(AREA_MONTA.WS_NUM_PROPOST_MONTA, LPARM01X);

            /*" -2456- CALL PROM1102 USING LPARM01X. */
            _.Call(PROM1102, LPARM01X);

            /*" -2457- IF WS-NUM-DIGITO-01 NOT EQUAL LPARM03 */

            if (AREA_MONTA.WS_NUM_PROPOST_MONTA_R.WS_NUM_DIGITO_01 != LPARM01X.LPARM03)
            {

                /*" -2458- MOVE LPARM03 TO WS-NUM-DIGITO-01-SAI */
                _.Move(LPARM01X.LPARM03, WORK_AREA.WS_NUM_PROPOSTA_SAI_R.WS_NUM_DIGITO_01_SAI);

                /*" -2459- ELSE */
            }
            else
            {


                /*" -2460- MOVE WS-NUM-DIGITO-01 TO WS-NUM-DIGITO-01-SAI */
                _.Move(AREA_MONTA.WS_NUM_PROPOST_MONTA_R.WS_NUM_DIGITO_01, WORK_AREA.WS_NUM_PROPOSTA_SAI_R.WS_NUM_DIGITO_01_SAI);

                /*" -2462- END-IF */
            }


            /*" -2464- MOVE WS-NUM-PROPOSTA-SAI TO WS-NUM-PROPOSTA-SIVPF */
            _.Move(WORK_AREA.WS_NUM_PROPOSTA_SAI, AREA_PROP.WS_NUM_PROPOSTA_SIVPF);

            /*" -2465- MOVE 6 TO PROPOFID-CANAL-PROPOSTA */
            _.Move(6, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);

            /*" -2467- MOVE 11 TO PROPOFID-ORIGEM-PROPOSTA. */
            _.Move(11, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

            /*" -2468- IF TEM-PROP-FIDELIZ EQUAL 'S' */

            if (WORK_AREA_0.TEM_PROP_FIDELIZ == "S")
            {

                /*" -2469- PERFORM R1913-00-UPDATE-PROPOFID */

                R1913_00_UPDATE_PROPOFID_SECTION();

                /*" -2470- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1706_99_SAIDA*/

        [StopWatch]
        /*" R1710-BUSCA0-SEQUENC-PROPOSTA-SECTION */
        private void R1710_BUSCA0_SEQUENC_PROPOSTA_SECTION()
        {
            /*" -2483- MOVE 'R1710' TO WNR-EXEC-SQL. */
            _.Move("R1710", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2491- PERFORM R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1 */

            R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1();

            /*" -2495- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2496- DISPLAY 'VA2646B - ERRO ACESSO PRODUTOS_SIVPF' */
                _.Display($"VA2646B - ERRO ACESSO PRODUTOS_SIVPF");

                /*" -2497- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2498- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2499- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2501- END-IF */
            }


            /*" -2502- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2504- COMPUTE PRDSIVPF-SEQ-PRD-PROPOSTA = PRDSIVPF-SEQ-PRD-PROPOSTA + 1 */
                PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_SEQ_PRD_PROPOSTA.Value = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_SEQ_PRD_PROPOSTA + 1;

                /*" -2505- PERFORM R1711-00-UPDATE-PRODU-SIVPF */

                R1711_00_UPDATE_PRODU_SIVPF_SECTION();

                /*" -2505- END-IF. */
            }


        }

        [StopWatch]
        /*" R1710-BUSCA0-SEQUENC-PROPOSTA-DB-SELECT-1 */
        public void R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1()
        {
            /*" -2491- EXEC SQL SELECT SEQ_PRD_PROPOSTA INTO :PRDSIVPF-SEQ-PRD-PROPOSTA:VIND-SEQ-NUM FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_PRODUTO_SIVPF = :PROPOFID-COD-PRODUTO-SIVPF AND COD_PRODUTO = :PROPOVA-COD-PRODUTO END-EXEC. */

            var r1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1 = new R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
                PROPOVA_COD_PRODUTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.ToString(),
            };

            var executed_1 = R1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1.Execute(r1710_BUSCA0_SEQUENC_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_SEQ_PRD_PROPOSTA, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_SEQ_PRD_PROPOSTA);
                _.Move(executed_1.VIND_SEQ_NUM, VIND_SEQ_NUM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1710_99_SAIDA*/

        [StopWatch]
        /*" R1711-00-UPDATE-PRODU-SIVPF-SECTION */
        private void R1711_00_UPDATE_PRODU_SIVPF_SECTION()
        {
            /*" -2519- MOVE 'R1711' TO WNR-EXEC-SQL. */
            _.Move("R1711", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2524- PERFORM R1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1 */

            R1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1();

            /*" -2528- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2529- DISPLAY 'VA2646B - ERRO ACESSO PRODUTOS_SIVPF' */
                _.Display($"VA2646B - ERRO ACESSO PRODUTOS_SIVPF");

                /*" -2530- DISPLAY 'NUM_CERTIFICADO = ' PRDSIVPF-SEQ-PRD-PROPOSTA */
                _.Display($"NUM_CERTIFICADO = {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_SEQ_PRD_PROPOSTA}");

                /*" -2531- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2532- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2532- END-IF. */
            }


        }

        [StopWatch]
        /*" R1711-00-UPDATE-PRODU-SIVPF-DB-UPDATE-1 */
        public void R1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1()
        {
            /*" -2524- EXEC SQL UPDATE SEGUROS.PRODUTOS_SIVPF SET SEQ_PRD_PROPOSTA = :PRDSIVPF-SEQ-PRD-PROPOSTA WHERE COD_PRODUTO_SIVPF = :PROPOFID-COD-PRODUTO-SIVPF AND COD_PRODUTO = :PROPOVA-COD-PRODUTO END-EXEC. */

            var r1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1_Update1 = new R1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1_Update1()
            {
                PRDSIVPF_SEQ_PRD_PROPOSTA = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_SEQ_PRD_PROPOSTA.ToString(),
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
                PROPOVA_COD_PRODUTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.ToString(),
            };

            R1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1_Update1.Execute(r1711_00_UPDATE_PRODU_SIVPF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1711_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-PESSOFIS-SECTION */
        private void R1800_00_SELECT_PESSOFIS_SECTION()
        {
            /*" -2546- MOVE 'R1800' TO WNR-EXEC-SQL */
            _.Move("R1800", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2551- MOVE CLIENTES-CGCCPF TO PESSOFIS-CPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_CPF);

            /*" -2559- PERFORM R1800_00_SELECT_PESSOFIS_DB_SELECT_1 */

            R1800_00_SELECT_PESSOFIS_DB_SELECT_1();

            /*" -2562-  EVALUATE SQLCODE  */

            /*" -2563-  WHEN ZEROS  */

            /*" -2564-  WHEN +100  */

            /*" -2564- IF   SQLCODE EQUALS ZEROS OR  +100 */

            if (DB.SQLCODE.In("00", "+100"))
            {

                /*" -2565- CONTINUE */

                /*" -2566-  WHEN OTHER  */

                /*" -2566- ELSE */
            }
            else
            {


                /*" -2567- DISPLAY 'VA2646B - ERRO ACESSO PESSOA_FISICA' */
                _.Display($"VA2646B - ERRO ACESSO PESSOA_FISICA");

                /*" -2568- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2569- DISPLAY 'PESSOFIS-CPF    = ' PESSOFIS-CPF */
                _.Display($"PESSOFIS-CPF    = {PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_CPF}");

                /*" -2570- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2571- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2573-  END-EVALUATE  */

                /*" -2573- END-IF */
            }


            /*" -2573- . */

        }

        [StopWatch]
        /*" R1800-00-SELECT-PESSOFIS-DB-SELECT-1 */
        public void R1800_00_SELECT_PESSOFIS_DB_SELECT_1()
        {
            /*" -2559- EXEC SQL SELECT COD_PESSOA INTO :PESSOA-COD-PESSOA FROM SEGUROS.PESSOA_FISICA WHERE CPF = :PESSOFIS-CPF ORDER BY COD_PESSOA DESC FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1 = new R1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1()
            {
                PESSOFIS_CPF = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_CPF.ToString(),
            };

            var executed_1 = R1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1810-00-SELECT-PESSOJUR-SECTION */
        private void R1810_00_SELECT_PESSOJUR_SECTION()
        {
            /*" -2587- MOVE 'R1810' TO WNR-EXEC-SQL. */
            _.Move("R1810", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2594- PERFORM R1810_00_SELECT_PESSOJUR_DB_SELECT_1 */

            R1810_00_SELECT_PESSOJUR_DB_SELECT_1();

            /*" -2598- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2599- DISPLAY 'VA2646B - ERRO ACESSO PESSOA_JURIDICA' */
                _.Display($"VA2646B - ERRO ACESSO PESSOA_JURIDICA");

                /*" -2600- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2601- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2602- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2602- END-IF. */
            }


        }

        [StopWatch]
        /*" R1810-00-SELECT-PESSOJUR-DB-SELECT-1 */
        public void R1810_00_SELECT_PESSOJUR_DB_SELECT_1()
        {
            /*" -2594- EXEC SQL SELECT COD_PESSOA INTO :PESSOA-COD-PESSOA FROM SEGUROS.PESSOA_JURIDICA WHERE CGC =:CLIENTES-CGCCPF END-EXEC. */

            var r1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1 = new R1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1()
            {
                CLIENTES_CGCCPF = CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.ToString(),
            };

            var executed_1 = R1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1.Execute(r1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1810_99_SAIDA*/

        [StopWatch]
        /*" R1820-00-INSERT-PESSOA-SECTION */
        private void R1820_00_INSERT_PESSOA_SECTION()
        {
            /*" -2616- MOVE 'R1820' TO WNR-EXEC-SQL. */
            _.Move("R1820", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2621- PERFORM R1820_00_INSERT_PESSOA_DB_SELECT_1 */

            R1820_00_INSERT_PESSOA_DB_SELECT_1();

            /*" -2625- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2626- DISPLAY 'VA2646B - ERRO ACESSO PESSOA' */
                _.Display($"VA2646B - ERRO ACESSO PESSOA");

                /*" -2627- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2628- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2629- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2631- END-IF. */
            }


            /*" -2634- ADD 1 TO PESSOA-COD-PESSOA. */
            PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.Value = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA + 1;

            /*" -2635- IF CLIENTES-TIPO-PESSOA NOT EQUAL 'F' AND 'J' */

            if (!CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA.In("F", "J"))
            {

                /*" -2637- MOVE 'J' TO CLIENTES-TIPO-PESSOA */
                _.Move("J", CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);

                /*" -2639- END-IF. */
            }


            /*" -2642- MOVE 'R1821' TO WNR-EXEC-SQL. */
            _.Move("R1821", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2650- PERFORM R1820_00_INSERT_PESSOA_DB_INSERT_1 */

            R1820_00_INSERT_PESSOA_DB_INSERT_1();

            /*" -2654- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2655- DISPLAY 'VA2646B - ERRO INSERT PESSOA' */
                _.Display($"VA2646B - ERRO INSERT PESSOA");

                /*" -2656- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2657- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2658- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2658- END-IF. */
            }


        }

        [StopWatch]
        /*" R1820-00-INSERT-PESSOA-DB-SELECT-1 */
        public void R1820_00_INSERT_PESSOA_DB_SELECT_1()
        {
            /*" -2621- EXEC SQL SELECT MAX(COD_PESSOA) INTO :PESSOA-COD-PESSOA FROM SEGUROS.PESSOA END-EXEC. */

            var r1820_00_INSERT_PESSOA_DB_SELECT_1_Query1 = new R1820_00_INSERT_PESSOA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1820_00_INSERT_PESSOA_DB_SELECT_1_Query1.Execute(r1820_00_INSERT_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


        }

        [StopWatch]
        /*" R1820-00-INSERT-PESSOA-DB-INSERT-1 */
        public void R1820_00_INSERT_PESSOA_DB_INSERT_1()
        {
            /*" -2650- EXEC SQL INSERT INTO SEGUROS.PESSOA VALUES (:PESSOA-COD-PESSOA, :CLIENTES-NOME-RAZAO, CURRENT TIMESTAMP, :PESSOA-COD-USUARIO, :CLIENTES-TIPO-PESSOA, NULL) END-EXEC. */

            var r1820_00_INSERT_PESSOA_DB_INSERT_1_Insert1 = new R1820_00_INSERT_PESSOA_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                CLIENTES_NOME_RAZAO = CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO.ToString(),
                PESSOA_COD_USUARIO = PESSOA.DCLPESSOA.PESSOA_COD_USUARIO.ToString(),
                CLIENTES_TIPO_PESSOA = CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA.ToString(),
            };

            R1820_00_INSERT_PESSOA_DB_INSERT_1_Insert1.Execute(r1820_00_INSERT_PESSOA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1820_99_SAIDA*/

        [StopWatch]
        /*" R1830-00-INSERT-PESSOFIS-SECTION */
        private void R1830_00_INSERT_PESSOFIS_SECTION()
        {
            /*" -2672- MOVE 'R1830' TO WNR-EXEC-SQL. */
            _.Move("R1830", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2675- MOVE CLIENTES-CGCCPF TO PESSOFIS-CPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_CPF);

            /*" -2707- PERFORM R1830_00_INSERT_PESSOFIS_DB_INSERT_1 */

            R1830_00_INSERT_PESSOFIS_DB_INSERT_1();

            /*" -2710- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2711- DISPLAY 'VA2646B - ERRO INSERT PESSOA_FISICA' */
                _.Display($"VA2646B - ERRO INSERT PESSOA_FISICA");

                /*" -2712- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2713- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2714- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2714- END-IF. */
            }


        }

        [StopWatch]
        /*" R1830-00-INSERT-PESSOFIS-DB-INSERT-1 */
        public void R1830_00_INSERT_PESSOFIS_DB_INSERT_1()
        {
            /*" -2707- EXEC SQL INSERT INTO SEGUROS.PESSOA_FISICA ( COD_PESSOA , CPF , DATA_NASCIMENTO , SEXO , COD_USUARIO , ESTADO_CIVIL , TIMESTAMP , NUM_IDENTIDADE , ORGAO_EXPEDIDOR , UF_EXPEDIDORA , DATA_EXPEDICAO , COD_CBO , TIPO_IDENT_SIVPF ) VALUES ( :PESSOA-COD-PESSOA , :PESSOFIS-CPF , :CLIENTES-DATA-NASCIMENTO , :PESSOFIS-SEXO , :PESSOFIS-COD-USUARIO , :CLIENTES-ESTADO-CIVIL , CURRENT TIMESTAMP , :PESSOFIS-NUM-IDENTIDADE :VIND-NULL, :PESSOFIS-ORGAO-EXPEDIDOR:VIND-NULL, :PESSOFIS-UF-EXPEDIDORA :VIND-NULL, :PESSOFIS-DATA-EXPEDICAO :VIND-NULL, :PESSOFIS-COD-CBO :VIND-NULL, :PESSOFIS-TIPO-IDENT-SIVPF :VIND-NULL ) END-EXEC. */

            var r1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1 = new R1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                PESSOFIS_CPF = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_CPF.ToString(),
                CLIENTES_DATA_NASCIMENTO = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.ToString(),
                PESSOFIS_SEXO = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_SEXO.ToString(),
                PESSOFIS_COD_USUARIO = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_USUARIO.ToString(),
                CLIENTES_ESTADO_CIVIL = CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL.ToString(),
                PESSOFIS_NUM_IDENTIDADE = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_NUM_IDENTIDADE.ToString(),
                VIND_NULL = VIND_NULL.ToString(),
                PESSOFIS_ORGAO_EXPEDIDOR = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_ORGAO_EXPEDIDOR.ToString(),
                PESSOFIS_UF_EXPEDIDORA = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_UF_EXPEDIDORA.ToString(),
                PESSOFIS_DATA_EXPEDICAO = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_DATA_EXPEDICAO.ToString(),
                PESSOFIS_COD_CBO = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO.ToString(),
                PESSOFIS_TIPO_IDENT_SIVPF = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_TIPO_IDENT_SIVPF.ToString(),
            };

            R1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1.Execute(r1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1830_99_SAIDA*/

        [StopWatch]
        /*" R1840-00-INSERT-PESSOJUR-SECTION */
        private void R1840_00_INSERT_PESSOJUR_SECTION()
        {
            /*" -2728- MOVE 'R1840' TO WNR-EXEC-SQL. */
            _.Move("R1840", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2744- PERFORM R1840_00_INSERT_PESSOJUR_DB_INSERT_1 */

            R1840_00_INSERT_PESSOJUR_DB_INSERT_1();

            /*" -2747- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2748- DISPLAY 'VA2646B - ERRO INSERT PESSOA_JURIDICA' */
                _.Display($"VA2646B - ERRO INSERT PESSOA_JURIDICA");

                /*" -2749- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2750- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2751- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2751- END-IF. */
            }


        }

        [StopWatch]
        /*" R1840-00-INSERT-PESSOJUR-DB-INSERT-1 */
        public void R1840_00_INSERT_PESSOJUR_DB_INSERT_1()
        {
            /*" -2744- EXEC SQL INSERT INTO SEGUROS.PESSOA_JURIDICA ( COD_PESSOA , CGC , NOME_FANTASIA , COD_USUARIO , TIMESTAMP ) VALUES ( :PESSOA-COD-PESSOA , :CLIENTES-CGCCPF, :CLIENTES-NOME-RAZAO, :PESSOJUR-COD-USUARIO , CURRENT TIMESTAMP ) END-EXEC. */

            var r1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1 = new R1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                CLIENTES_CGCCPF = CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.ToString(),
                CLIENTES_NOME_RAZAO = CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO.ToString(),
                PESSOJUR_COD_USUARIO = PESSOJUR.DCLPESSOA_JURIDICA.PESSOJUR_COD_USUARIO.ToString(),
            };

            R1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1.Execute(r1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1840_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-SELECT-PROPOFID-SECTION */
        private void R1900_00_SELECT_PROPOFID_SECTION()
        {
            /*" -2765- MOVE 'R1900' TO WNR-EXEC-SQL. */
            _.Move("R1900", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2787- PERFORM R1900_00_SELECT_PROPOFID_DB_SELECT_1 */

            R1900_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -2790- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2791- DISPLAY 'VA2646B - ERRO ACESSO PROPOSTA_FIDELIZ' */
                _.Display($"VA2646B - ERRO ACESSO PROPOSTA_FIDELIZ");

                /*" -2792- DISPLAY 'NUM-CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2794- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2795- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2797- END-IF. */
            }


            /*" -2798- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2800- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO WS-NUM-PROPOSTA-FIDELIZ */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WS_NUM_PROPOSTA_FIDELIZ);

                /*" -2802- MOVE 'S' TO TEM-PROP-FIDELIZ */
                _.Move("S", WORK_AREA_0.TEM_PROP_FIDELIZ);

                /*" -2803- ELSE */
            }
            else
            {


                /*" -2805- MOVE 'N' TO TEM-PROP-FIDELIZ */
                _.Move("N", WORK_AREA_0.TEM_PROP_FIDELIZ);

                /*" -2805- END-IF. */
            }


        }

        [StopWatch]
        /*" R1900-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R1900_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -2787- EXEC SQL SELECT NUM_IDENTIFICACAO , SIT_PROPOSTA , CANAL_PROPOSTA , ORIGEM_PROPOSTA , SITUACAO_ENVIO , COD_PRODUTO_SIVPF , DATA_PROPOSTA , NUM_PROPOSTA_SIVPF INTO :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-SIT-PROPOSTA , :PROPOFID-CANAL-PROPOSTA , :PROPOFID-ORIGEM-PROPOSTA , :PROPOFID-SITUACAO-ENVIO , :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-DATA-PROPOSTA , :PROPOFID-NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB =:PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(executed_1.PROPOFID_SITUACAO_ENVIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1910-00-UPDATE-PROPOFID-SECTION */
        private void R1910_00_UPDATE_PROPOFID_SECTION()
        {
            /*" -2819- MOVE 'R1910' TO WNR-EXEC-SQL. */
            _.Move("R1910", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2826- PERFORM R1910_00_UPDATE_PROPOFID_DB_UPDATE_1 */

            R1910_00_UPDATE_PROPOFID_DB_UPDATE_1();

            /*" -2830- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2831- DISPLAY 'VA2646B - ERRO UPDATE PROPOSTA_FIDELIZ' */
                _.Display($"VA2646B - ERRO UPDATE PROPOSTA_FIDELIZ");

                /*" -2832- DISPLAY 'NUM-CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2833- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2834- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2834- END-IF. */
            }


        }

        [StopWatch]
        /*" R1910-00-UPDATE-PROPOFID-DB-UPDATE-1 */
        public void R1910_00_UPDATE_PROPOFID_DB_UPDATE_1()
        {
            /*" -2826- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :PROPOFID-SIT-PROPOSTA, COD_USUARIO = :PROPOFID-COD-USUARIO, SITUACAO_ENVIO = :PROPOFID-SITUACAO-ENVIO WHERE NUM_SICOB = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1910_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1 = new R1910_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1()
            {
                PROPOFID_SITUACAO_ENVIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO.ToString(),
                PROPOFID_SIT_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.ToString(),
                PROPOFID_COD_USUARIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1910_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1.Execute(r1910_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/

        [StopWatch]
        /*" R1911-00-UPDATE-PROPOFID-SECTION */
        private void R1911_00_UPDATE_PROPOFID_SECTION()
        {
            /*" -2848- MOVE 'R1911' TO WNR-EXEC-SQL. */
            _.Move("R1911", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2851- MOVE WS-NUM-PROPOSTA-EXC TO PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Move(WORK_AREA_0.WS_NUM_PROPOSTA_EXC, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -2860- PERFORM R1911_00_UPDATE_PROPOFID_DB_UPDATE_1 */

            R1911_00_UPDATE_PROPOFID_DB_UPDATE_1();

            /*" -2864- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2865- DISPLAY 'VA2646B - ERRO UPDATE PROPOSTA_FIDELIZ' */
                _.Display($"VA2646B - ERRO UPDATE PROPOSTA_FIDELIZ");

                /*" -2866- DISPLAY 'NUM-CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2867- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2868- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2868- END-IF. */
            }


        }

        [StopWatch]
        /*" R1911-00-UPDATE-PROPOFID-DB-UPDATE-1 */
        public void R1911_00_UPDATE_PROPOFID_DB_UPDATE_1()
        {
            /*" -2860- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SITUACAO_ENVIO = 'R' , COD_USUARIO = :PROPOFID-COD-USUARIO, NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF WHERE NUM_SICOB = :PROPOVA-NUM-CERTIFICADO AND SITUACAO_ENVIO = 'S' END-EXEC. */

            var r1911_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1 = new R1911_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_COD_USUARIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1911_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1.Execute(r1911_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1911_99_SAIDA*/

        [StopWatch]
        /*" R1912-00-SELECT-CONVERS-SICOB-SECTION */
        private void R1912_00_SELECT_CONVERS_SICOB_SECTION()
        {
            /*" -2882- MOVE 'R1912' TO WNR-EXEC-SQL. */
            _.Move("R1912", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2884- MOVE ZEROS TO WS-NUM-PROPOSTA-CONVERSAO */
            _.Move(0, WORK_AREA_0.WS_NUM_PROPOSTA_CONVERSAO);

            /*" -2892- PERFORM R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1 */

            R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1();

            /*" -2896- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2897- DISPLAY 'VA2646B - ERRO ACESSO CONVERSAO_SICOB' */
                _.Display($"VA2646B - ERRO ACESSO CONVERSAO_SICOB");

                /*" -2898- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2899- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2900- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2901- ELSE */
            }
            else
            {


                /*" -2902- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -2903- MOVE 'S' TO TEM-CONVERSAO */
                    _.Move("S", WORK_AREA_0.TEM_CONVERSAO);

                    /*" -2905- MOVE CONVERSI-NUM-PROPOSTA-SIVPF TO WS-NUM-PROPOSTA-SIVPF WS-NUM-PROPOSTA-CONVERSAO */
                    _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF, AREA_PROP.WS_NUM_PROPOSTA_SIVPF, WORK_AREA_0.WS_NUM_PROPOSTA_CONVERSAO);

                    /*" -2906- MOVE 7 TO PROPOFID-CANAL-PROPOSTA */
                    _.Move(7, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);

                    /*" -2907- MOVE 11 TO PROPOFID-ORIGEM-PROPOSTA */
                    _.Move(11, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

                    /*" -2908- END-IF */
                }


                /*" -2908- END-IF. */
            }


        }

        [StopWatch]
        /*" R1912-00-SELECT-CONVERS-SICOB-DB-SELECT-1 */
        public void R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1()
        {
            /*" -2892- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :CONVERSI-NUM-PROPOSTA-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :PROPOVA-NUM-APOLICE END-EXEC. */

            var r1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1 = new R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1.Execute(r1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_PROPOSTA_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1912_99_SAIDA*/

        [StopWatch]
        /*" R1913-00-UPDATE-PROPOFID-SECTION */
        private void R1913_00_UPDATE_PROPOFID_SECTION()
        {
            /*" -2922- MOVE 'R1913' TO WNR-EXEC-SQL. */
            _.Move("R1913", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2924- MOVE WS-NUM-PROPOSTA-SAI TO PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Move(WORK_AREA.WS_NUM_PROPOSTA_SAI, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -2931- PERFORM R1913_00_UPDATE_PROPOFID_DB_UPDATE_1 */

            R1913_00_UPDATE_PROPOFID_DB_UPDATE_1();

            /*" -2935- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2936- DISPLAY 'VA2646B - ERRO UPDATE PROPOSTA_FIDELIZ' */
                _.Display($"VA2646B - ERRO UPDATE PROPOSTA_FIDELIZ");

                /*" -2937- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2938- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2939- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2939- END-IF. */
            }


        }

        [StopWatch]
        /*" R1913-00-UPDATE-PROPOFID-DB-UPDATE-1 */
        public void R1913_00_UPDATE_PROPOFID_DB_UPDATE_1()
        {
            /*" -2931- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF, SITUACAO_ENVIO = 'S' WHERE NUM_SICOB = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1 = new R1913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1.Execute(r1913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1913_99_SAIDA*/

        [StopWatch]
        /*" R1915-00-SELECT-MAX-RELAC-SECTION */
        private void R1915_00_SELECT_MAX_RELAC_SECTION()
        {
            /*" -2953- MOVE 'R1915' TO WNR-EXEC-SQL. */
            _.Move("R1915", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2957- PERFORM R1915_00_SELECT_MAX_RELAC_DB_SELECT_1 */

            R1915_00_SELECT_MAX_RELAC_DB_SELECT_1();

            /*" -2960- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2961- DISPLAY 'VA2646B - ERRO ACESSO IDENTIFICA_RELAC ' */
                _.Display($"VA2646B - ERRO ACESSO IDENTIFICA_RELAC ");

                /*" -2962- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2963- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2964- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2966- END-IF. */
            }


            /*" -2969- ADD 1 TO PROPOFID-NUM-IDENTIFICACAO */
            PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.Value = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO + 1;

            /*" -2973- MOVE 1 TO IDENTREL-COD-RELAC */
            _.Move(1, IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC);

            /*" -2976- MOVE 'R1916' TO WNR-EXEC-SQL. */
            _.Move("R1916", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -2982- PERFORM R1915_00_SELECT_MAX_RELAC_DB_INSERT_1 */

            R1915_00_SELECT_MAX_RELAC_DB_INSERT_1();

            /*" -2986- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -2987- DISPLAY 'VA2646B - ERRO INSERT R_PESSOA_TIPORELAC' */
                _.Display($"VA2646B - ERRO INSERT R_PESSOA_TIPORELAC");

                /*" -2988- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2989- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -2990- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2993- END-IF. */
            }


            /*" -2995- MOVE 'R1917' TO WNR-EXEC-SQL. */
            _.Move("R1917", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -3002- PERFORM R1915_00_SELECT_MAX_RELAC_DB_INSERT_2 */

            R1915_00_SELECT_MAX_RELAC_DB_INSERT_2();

            /*" -3005- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3006- DISPLAY 'VA2646B - ERRO INSERT IDENTIFICA_RELAC' */
                _.Display($"VA2646B - ERRO INSERT IDENTIFICA_RELAC");

                /*" -3007- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -3008- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -3009- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3009- END-IF. */
            }


        }

        [StopWatch]
        /*" R1915-00-SELECT-MAX-RELAC-DB-SELECT-1 */
        public void R1915_00_SELECT_MAX_RELAC_DB_SELECT_1()
        {
            /*" -2957- EXEC SQL SELECT VALUE(MAX(NUM_IDENTIFICACAO),0) INTO :PROPOFID-NUM-IDENTIFICACAO FROM SEGUROS.IDENTIFICA_RELAC END-EXEC. */

            var r1915_00_SELECT_MAX_RELAC_DB_SELECT_1_Query1 = new R1915_00_SELECT_MAX_RELAC_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1915_00_SELECT_MAX_RELAC_DB_SELECT_1_Query1.Execute(r1915_00_SELECT_MAX_RELAC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
            }


        }

        [StopWatch]
        /*" R1915-00-SELECT-MAX-RELAC-DB-INSERT-1 */
        public void R1915_00_SELECT_MAX_RELAC_DB_INSERT_1()
        {
            /*" -2982- EXEC SQL INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES ( :PESSOA-COD-PESSOA, :IDENTREL-COD-RELAC ) END-EXEC. */

            var r1915_00_SELECT_MAX_RELAC_DB_INSERT_1_Insert1 = new R1915_00_SELECT_MAX_RELAC_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                IDENTREL_COD_RELAC = IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC.ToString(),
            };

            R1915_00_SELECT_MAX_RELAC_DB_INSERT_1_Insert1.Execute(r1915_00_SELECT_MAX_RELAC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1915_99_SAIDA*/

        [StopWatch]
        /*" R1915-00-SELECT-MAX-RELAC-DB-INSERT-2 */
        public void R1915_00_SELECT_MAX_RELAC_DB_INSERT_2()
        {
            /*" -3002- EXEC SQL INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES (:PROPOFID-NUM-IDENTIFICACAO, :PESSOA-COD-PESSOA, :IDENTREL-COD-RELAC, :IDENTREL-COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r1915_00_SELECT_MAX_RELAC_DB_INSERT_2_Insert1 = new R1915_00_SELECT_MAX_RELAC_DB_INSERT_2_Insert1()
            {
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                IDENTREL_COD_RELAC = IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC.ToString(),
                IDENTREL_COD_USUARIO = IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_USUARIO.ToString(),
            };

            R1915_00_SELECT_MAX_RELAC_DB_INSERT_2_Insert1.Execute(r1915_00_SELECT_MAX_RELAC_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1920-00-INSERT-PROPOFID-SECTION */
        private void R1920_00_INSERT_PROPOFID_SECTION()
        {
            /*" -3023- MOVE 'R1920' TO WNR-EXEC-SQL. */
            _.Move("R1920", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -3025- MOVE PROPOVA-NUM-CERTIFICADO TO PROPOFID-NUM-SICOB */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

            /*" -3028- MOVE WS-NUM-PROPOSTA-SIVPF TO PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Move(AREA_PROP.WS_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -3031- MOVE 1 TO PROPOFID-COD-EMPRESA-SIVPF */
            _.Move(1, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);

            /*" -3035- MOVE PROPOVA-DATA-QUITACAO TO PROPOFID-DATA-PROPOSTA PROPOFID-DTQITBCO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

            /*" -3038- MOVE VA2646B1O-TIPO-PAGTO TO PROPOFID-OPCAOPAG */
            _.Move(VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_TIPO_PAGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);

            /*" -3041- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO PROPOFID-AGECTADEB */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);

            /*" -3044- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO PROPOFID-OPRCTADEB */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);

            /*" -3047- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO PROPOFID-NUMCTADEB */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);

            /*" -3051- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO PROPOFID-DIGCTADEB */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);

            /*" -3060- MOVE '0001-01-01' TO PROPOFID-DATA-CREDITO */
            _.Move("0001-01-01", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);

            /*" -3063- MOVE 'S' TO PROPOFID-SITUACAO-ENVIO */
            _.Move("S", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -3066- MOVE 'N' TO PROPOFID-IND-TIPO-CONTA */
            _.Move("N", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);

            /*" -3166- PERFORM R1920_00_INSERT_PROPOFID_DB_INSERT_1 */

            R1920_00_INSERT_PROPOFID_DB_INSERT_1();

            /*" -3169- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3171- IF SQLCODE EQUAL -803 NEXT SENTENCE */

                if (DB.SQLCODE == -803)
                {

                    /*" -3172- ELSE */
                }
                else
                {


                    /*" -3173- DISPLAY 'VA2646B - ERRO INSERT PROPOSTA_FIDELIZ' */
                    _.Display($"VA2646B - ERRO INSERT PROPOSTA_FIDELIZ");

                    /*" -3174- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -3175- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                    /*" -3176- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3177- END-IF */
                }


                /*" -3177- END-IF. */
            }


        }

        [StopWatch]
        /*" R1920-00-INSERT-PROPOFID-DB-INSERT-1 */
        public void R1920_00_INSERT_PROPOFID_DB_INSERT_1()
        {
            /*" -3166- EXEC SQL INSERT INTO SEGUROS.PROPOSTA_FIDELIZ ( NUM_PROPOSTA_SIVPF , NUM_IDENTIFICACAO , COD_EMPRESA_SIVPF , COD_PESSOA , NUM_SICOB , DATA_PROPOSTA , COD_PRODUTO_SIVPF , AGECOBR , DIA_DEBITO , OPCAOPAG , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , PERC_DESCONTO , NRMATRVEN , AGECTAVEN , OPRCTAVEN , NUMCTAVEN , DIGCTAVEN , CGC_CONVENENTE , NOME_CONVENENTE , NRMATRCON , DTQITBCO , VAL_PAGO , AGEPGTO , VAL_TARIFA , VAL_IOF , DATA_CREDITO , VAL_COMISSAO , SIT_PROPOSTA , COD_USUARIO , CANAL_PROPOSTA , NSAS_SIVPF , ORIGEM_PROPOSTA , TIMESTAMP , NSL , NSAC_SIVPF , SITUACAO_ENVIO , OPCAO_COBER , COD_PLANO , NOME_CONJUGE , DATA_NASC_CONJUGE , PROFISSAO_CONJUGE , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , IND_TIPO_CONTA ) VALUES ( :PROPOFID-NUM-PROPOSTA-SIVPF , :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-COD-EMPRESA-SIVPF , :PESSOA-COD-PESSOA , :PROPOFID-NUM-SICOB , :PROPOFID-DATA-PROPOSTA , :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-AGECOBR , :PROPOFID-DIA-DEBITO , :PROPOFID-OPCAOPAG , :PROPOFID-AGECTADEB , :PROPOFID-OPRCTADEB , :PROPOFID-NUMCTADEB , :PROPOFID-DIGCTADEB , :PROPOFID-PERC-DESCONTO , :PROPOFID-NRMATRVEN , :PROPOFID-AGECTAVEN , :PROPOFID-OPRCTAVEN , :PROPOFID-NUMCTAVEN , :PROPOFID-DIGCTAVEN , :PROPOFID-CGC-CONVENENTE , :PROPOFID-NOME-CONVENENTE , :PROPOFID-NRMATRCON , :PROPOFID-DTQITBCO , :PROPOFID-VAL-PAGO , :PROPOFID-AGEPGTO , :PROPOFID-VAL-TARIFA , :PROPOFID-VAL-IOF , :PROPOFID-DATA-CREDITO , :PROPOFID-VAL-COMISSAO , :PROPOFID-SIT-PROPOSTA , :PROPOFID-COD-USUARIO , :PROPOFID-CANAL-PROPOSTA , :PROPOFID-NSAS-SIVPF , :PROPOFID-ORIGEM-PROPOSTA , CURRENT TIMESTAMP , :PROPOFID-NSL , :PROPOFID-NSAC-SIVPF , :PROPOFID-SITUACAO-ENVIO , :PROPOFID-OPCAO-COBER , :PROPOFID-COD-PLANO , :PROPOFID-NOME-CONJUGE :VIND-NULL, :PROPOFID-DATA-NASC-CONJUGE :VIND-NULL, :PROPOFID-PROFISSAO-CONJUGE :VIND-NULL, :PROPOFID-FAIXA-RENDA-IND :VIND-NULL, :PROPOFID-FAIXA-RENDA-FAM :VIND-NULL, :PROPOFID-IND-TIPO-CONTA ) END-EXEC. */

            var r1920_00_INSERT_PROPOFID_DB_INSERT_1_Insert1 = new R1920_00_INSERT_PROPOFID_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                PROPOFID_COD_EMPRESA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF.ToString(),
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
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
                VIND_NULL = VIND_NULL.ToString(),
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                PROPOFID_PROFISSAO_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE.ToString(),
                PROPOFID_FAIXA_RENDA_IND = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.ToString(),
                PROPOFID_FAIXA_RENDA_FAM = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.ToString(),
                PROPOFID_IND_TIPO_CONTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA.ToString(),
            };

            R1920_00_INSERT_PROPOFID_DB_INSERT_1_Insert1.Execute(r1920_00_INSERT_PROPOFID_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1920_99_SAIDA*/

        [StopWatch]
        /*" R1921-00-INSERT-PROPOFID-SECTION */
        private void R1921_00_INSERT_PROPOFID_SECTION()
        {
            /*" -3190- MOVE 'R1921' TO WNR-EXEC-SQL. */
            _.Move("R1921", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -3194- MOVE PROPOVA-NUM-CERTIFICADO TO PROPOFID-NUM-PROPOSTA-SIVPF PROPOFID-NUM-SICOB */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

            /*" -3197- MOVE 1 TO PROPOFID-COD-EMPRESA-SIVPF */
            _.Move(1, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);

            /*" -3201- MOVE PROPOVA-DATA-QUITACAO TO PROPOFID-DATA-PROPOSTA PROPOFID-DTQITBCO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

            /*" -3204- MOVE VA2646B1O-TIPO-PAGTO TO PROPOFID-OPCAOPAG */
            _.Move(VA2646B1O_REG.VA2646B1O_REG_3.VA2646B1O_TIPO_PAGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);

            /*" -3207- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO PROPOFID-AGECTADEB */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);

            /*" -3210- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO PROPOFID-OPRCTADEB */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);

            /*" -3213- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO PROPOFID-NUMCTADEB */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);

            /*" -3217- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO PROPOFID-DIGCTADEB */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);

            /*" -3220- MOVE '0001-01-01' TO PROPOFID-DATA-CREDITO */
            _.Move("0001-01-01", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);

            /*" -3223- MOVE 2 TO PROPOFID-CANAL-PROPOSTA */
            _.Move(2, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);

            /*" -3226- MOVE 06 TO PROPOFID-ORIGEM-PROPOSTA */
            _.Move(06, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

            /*" -3229- MOVE 'R' TO PROPOFID-SITUACAO-ENVIO */
            _.Move("R", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -3230- IF PROPOFID-DATA-NASC-CONJUGE EQUAL SPACES */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.IsEmpty())
            {

                /*" -3231- MOVE -1 TO VIND-NULL-3 */
                _.Move(-1, VIND_NULL_3);

                /*" -3233- END-IF */
            }


            /*" -3331- PERFORM R1921_00_INSERT_PROPOFID_DB_INSERT_1 */

            R1921_00_INSERT_PROPOFID_DB_INSERT_1();

            /*" -3334- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3336- IF SQLCODE EQUAL -803 NEXT SENTENCE */

                if (DB.SQLCODE == -803)
                {

                    /*" -3337- ELSE */
                }
                else
                {


                    /*" -3338- DISPLAY 'VA2646B - ERRO INSERT PROPOSTA_FIDELIZ' */
                    _.Display($"VA2646B - ERRO INSERT PROPOSTA_FIDELIZ");

                    /*" -3339- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -3340- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                    /*" -3341- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3342- END-IF */
                }


                /*" -3342- END-IF. */
            }


        }

        [StopWatch]
        /*" R1921-00-INSERT-PROPOFID-DB-INSERT-1 */
        public void R1921_00_INSERT_PROPOFID_DB_INSERT_1()
        {
            /*" -3331- EXEC SQL INSERT INTO SEGUROS.PROPOSTA_FIDELIZ ( NUM_PROPOSTA_SIVPF , NUM_IDENTIFICACAO , COD_EMPRESA_SIVPF , COD_PESSOA , NUM_SICOB , DATA_PROPOSTA , COD_PRODUTO_SIVPF , AGECOBR , DIA_DEBITO , OPCAOPAG , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , PERC_DESCONTO , NRMATRVEN , AGECTAVEN , OPRCTAVEN , NUMCTAVEN , DIGCTAVEN , CGC_CONVENENTE , NOME_CONVENENTE , NRMATRCON , DTQITBCO , VAL_PAGO , AGEPGTO , VAL_TARIFA , VAL_IOF , DATA_CREDITO , VAL_COMISSAO , SIT_PROPOSTA , COD_USUARIO , CANAL_PROPOSTA , NSAS_SIVPF , ORIGEM_PROPOSTA , TIMESTAMP , NSL , NSAC_SIVPF , SITUACAO_ENVIO , OPCAO_COBER , COD_PLANO , NOME_CONJUGE , DATA_NASC_CONJUGE , PROFISSAO_CONJUGE , FAIXA_RENDA_IND , FAIXA_RENDA_FAM ) VALUES ( :PROPOFID-NUM-PROPOSTA-SIVPF , :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-COD-EMPRESA-SIVPF , :PESSOA-COD-PESSOA , :PROPOFID-NUM-SICOB , :PROPOFID-DATA-PROPOSTA , :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-AGECOBR , :PROPOFID-DIA-DEBITO , :PROPOFID-OPCAOPAG , :PROPOFID-AGECTADEB , :PROPOFID-OPRCTADEB , :PROPOFID-NUMCTADEB , :PROPOFID-DIGCTADEB , :PROPOFID-PERC-DESCONTO , :PROPOFID-NRMATRVEN , :PROPOFID-AGECTAVEN , :PROPOFID-OPRCTAVEN , :PROPOFID-NUMCTAVEN , :PROPOFID-DIGCTAVEN , :PROPOFID-CGC-CONVENENTE , :PROPOFID-NOME-CONVENENTE , :PROPOFID-NRMATRCON , :PROPOFID-DTQITBCO , :PROPOFID-VAL-PAGO , :PROPOFID-AGEPGTO , :PROPOFID-VAL-TARIFA , :PROPOFID-VAL-IOF , :PROPOFID-DATA-CREDITO , :PROPOFID-VAL-COMISSAO , :PROPOFID-SIT-PROPOSTA , :PROPOFID-COD-USUARIO , :PROPOFID-CANAL-PROPOSTA , :PROPOFID-NSAS-SIVPF , :PROPOFID-ORIGEM-PROPOSTA , CURRENT TIMESTAMP , :PROPOFID-NSL , :PROPOFID-NSAC-SIVPF , :PROPOFID-SITUACAO-ENVIO , :PROPOFID-OPCAO-COBER , :PROPOFID-COD-PLANO , :PROPOFID-NOME-CONJUGE :VIND-NULL, :PROPOFID-DATA-NASC-CONJUGE :VIND-NULL-3, :PROPOFID-PROFISSAO-CONJUGE :VIND-NULL, :PROPOFID-FAIXA-RENDA-IND :VIND-NULL, :PROPOFID-FAIXA-RENDA-FAM :VIND-NULL ) END-EXEC. */

            var r1921_00_INSERT_PROPOFID_DB_INSERT_1_Insert1 = new R1921_00_INSERT_PROPOFID_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                PROPOFID_COD_EMPRESA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF.ToString(),
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
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
                VIND_NULL = VIND_NULL.ToString(),
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                VIND_NULL_3 = VIND_NULL_3.ToString(),
                PROPOFID_PROFISSAO_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE.ToString(),
                PROPOFID_FAIXA_RENDA_IND = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.ToString(),
                PROPOFID_FAIXA_RENDA_FAM = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.ToString(),
            };

            R1921_00_INSERT_PROPOFID_DB_INSERT_1_Insert1.Execute(r1921_00_INSERT_PROPOFID_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1921_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-UPDATE-RELATORI-SECTION */
        private void R8000_00_UPDATE_RELATORI_SECTION()
        {
            /*" -3356- MOVE 'R8000' TO WNR-EXEC-SQL. */
            _.Move("R8000", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -3361- PERFORM R8000_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R8000_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -3364- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3365- DISPLAY 'VA2646B - ERRO UPDATE RELATORIOS' */
                _.Display($"VA2646B - ERRO UPDATE RELATORIOS");

                /*" -3366- DISPLAY 'IDE_SISTEMA   =  VA' */
                _.Display($"IDE_SISTEMA   =  VA");

                /*" -3367- DISPLAY 'COD_USUARIO   =  VA2646B' */
                _.Display($"COD_USUARIO   =  VA2646B");

                /*" -3368- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

                /*" -3369- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3369- END-IF. */
            }


        }

        [StopWatch]
        /*" R8000-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R8000_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -3361- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO-30 WHERE IDE_SISTEMA = 'VA' AND COD_USUARIO = 'VA2646B' END-EXEC. */

            var r8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 = new R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO_30 = SISTEMAS_DATA_MOV_ABERTO_30.ToString(),
            };

            R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1.Execute(r8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8100-00-GRAVA-TRAILLER-SECTION */
        private void R8100_00_GRAVA_TRAILLER_SECTION()
        {
            /*" -3383- MOVE 'R8100' TO WNR-EXEC-SQL. */
            _.Move("R8100", WORK_AREA_0.WABEND.WNR_EXEC_SQL);

            /*" -3384- MOVE SPACES TO VA2646B1O-REG-T. */
            _.Move("", VA2646B1O_REG.VA2646B1O_REG_T);

            /*" -3385- MOVE 'T' TO VA2646B1O-IDENTIFICA. */
            _.Move("T", VA2646B1O_REG.VA2646B1O_IDENTIFICA);

            /*" -3386- MOVE 'PRPSASSE' TO VA2646B1O-NOME-ARQ-T. */
            _.Move("PRPSASSE", VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_NOME_ARQ_T);

            /*" -3387- MOVE ZEROS TO VA2646B1O-QTDE-REG-0. */
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_0);

            /*" -3388- MOVE WS-QTD-REG1-PRP TO VA2646B1O-QTDE-REG-1. */
            _.Move(WS_QTD_REG1_PRP, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_1);

            /*" -3389- MOVE WS-QTD-REG2-PRP TO VA2646B1O-QTDE-REG-2. */
            _.Move(WS_QTD_REG2_PRP, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_2);

            /*" -3390- MOVE WS-QTD-REG3-PRP TO VA2646B1O-QTDE-REG-3. */
            _.Move(WS_QTD_REG3_PRP, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_3);

            /*" -3407- MOVE ZEROS TO VA2646B1O-QTDE-REG-4, VA2646B1O-QTDE-REG-5, VA2646B1O-QTDE-REG-6, VA2646B1O-QTDE-REG-7, VA2646B1O-QTDE-REG-8, VA2646B1O-QTDE-REG-9, VA2646B1O-QTDE-REG-A, VA2646B1O-QTDE-REG-B, VA2646B1O-QTDE-REG-C, VA2646B1O-QTDE-REG-D, VA2646B1O-QTDE-REG-E, VA2646B1O-QTDE-REG-F, VA2646B1O-QTDE-REG-G, VA2646B1O-QTDE-REG-H, VA2646B1O-QTDE-REG-I, VA2646B1O-QTDE-REG-J. */
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_4);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_5);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_6);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_7);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_8);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_9);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_A);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_B);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_C);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_D);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_E);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_F);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_G);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_H);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_I);
            _.Move(0, VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_J);


            /*" -3411- COMPUTE VA2646B1O-QTDE-REG-TOTAL = VA2646B1O-QTDE-REG-1 + VA2646B1O-QTDE-REG-2 + VA2646B1O-QTDE-REG-3. */
            VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_TOTAL.Value = VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_1 + VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_2 + VA2646B1O_REG.VA2646B1O_REG_T.VA2646B1O_QTDE_REG_3;

            /*" -3412- WRITE REG-AVA2646B FROM VA2646B1O-REG. */
            _.Move(VA2646B1O_REG.GetMoveValues(), REG_AVA2646B);

            AVA2646B.Write(REG_AVA2646B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -3426- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -3427- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3428- DISPLAY '*   VA2646B - GERA RELATORIO MULTPREMIADO  *' */
            _.Display($"*   VA2646B - GERA RELATORIO MULTPREMIADO  *");

            /*" -3429- DISPLAY '*   -------   -------------- ------------  *' */
            _.Display($"*   -------   -------------- ------------  *");

            /*" -3430- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3431- DISPLAY '*             NAO EXISTE PRODUCAO PARA     *' */
            _.Display($"*             NAO EXISTE PRODUCAO PARA     *");

            /*" -3432- DISPLAY '*             O PERIODO PEDIDO.            *' */
            _.Display($"*             O PERIODO PEDIDO.            *");

            /*" -3433- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3433- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3445- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA_0.WABEND.WSQLCODE);

            /*" -3447- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, WORK_AREA_0.WABEND.WSQLERRMC);

            /*" -3449- DISPLAY WABEND */
            _.Display(WORK_AREA_0.WABEND);

            /*" -3449- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -3451- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3455- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -3455- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}