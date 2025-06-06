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
using Sias.PessoaFisica.DB2.PF4001B;

namespace Code
{
    public class PF4001B
    {
        public bool IsCall { get; set; }

        public PF4001B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA.................  SISTEMA PROPOSTAS VIDA             *      */
        /*"      *   MODULO..................  SIAS                               *      */
        /*"      *   OBJETIVO................  LEITURA DE ARQUIVO DE PROPOSTAS    *      */
        /*"      *                             REJEITADAS DA CAIXA E GRAVACAO NA  *      */
        /*"      *                             TABELA HIST_PROP_FIDELIZ           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISE/PROGRAMACAO.....  THIAGO BLAIER                      *      */
        /*"      *   PROGRAMA ...............  PF4001B                            *      */
        /*"      *   DATA ...................  28/10/2024.                  .     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * VERSAO 02     - DEMANDA 595918   ABEND OPTI-4261               *      */
        /*"      *                 SQLCODE:  803- NA HIST_PROP_FICELLIZ           *      */
        /*"      *                                                                *      */
        /*"      * EM 07/01/2025 - SERGIO LORETO                                  *      */
        /*"      *                                         PROCURE POR V.02       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _CVPRJPRP { get; set; } = new FileBasis(new PIC("X", "330", "X(330)"));

        public FileBasis CVPRJPRP
        {
            get
            {
                _.Move(REG_CVPRJPRP, _CVPRJPRP); VarBasis.RedefinePassValue(REG_CVPRJPRP, _CVPRJPRP, REG_CVPRJPRP); return _CVPRJPRP;
            }
        }
        /*"01   REG-CVPRJPRP                 PIC X(330).*/
        public StringBasis REG_CVPRJPRP { get; set; } = new StringBasis(new PIC("X", "330", "X(330)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  AREA-DE-WORK.*/
        public PF4001B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new PF4001B_AREA_DE_WORK();
        public class PF4001B_AREA_DE_WORK : VarBasis
        {
            /*"    05  WS-PROGRAMA               PIC X(008)  VALUE SPACES.*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05  WS-IND-TP-ACAO            PIC X(001) VALUE SPACES.*/
            public StringBasis WS_IND_TP_ACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05  WS-EDIT .*/
            public PF4001B_WS_EDIT WS_EDIT { get; set; } = new PF4001B_WS_EDIT();
            public class PF4001B_WS_EDIT : VarBasis
            {
                /*"       10 WS-SMALLINT             PIC ZZ.ZZ9- OCCURS 20 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 20);
                /*"       10 WS-INTEGER              PIC Z.ZZZ.ZZZ.ZZ9-                                              OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
                /*"       10 WS-BIGINT               PIC 99999999999999                                              OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
                /*"       10 WS-DECIMAL              PIC ZZZZZZZZZZ9,999999                                            OCCURS 10 TIMES.*/
                public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 10);
                /*"    05 WS-NUM-PROPOSTA-ANT        PIC 9(014) VALUE ZEROS.*/
            }
            public IntBasis WS_NUM_PROPOSTA_ANT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  WS-NUM-PROPOSTA-DESLOC    PIC 9(014).*/
            public IntBasis WS_NUM_PROPOSTA_DESLOC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  WS-NUM-PROPOSTA-R             REDEFINES        WS-NUM-PROPOSTA-DESLOC.*/
            private _REDEF_PF4001B_WS_NUM_PROPOSTA_R _ws_num_proposta_r { get; set; }
            public _REDEF_PF4001B_WS_NUM_PROPOSTA_R WS_NUM_PROPOSTA_R
            {
                get { _ws_num_proposta_r = new _REDEF_PF4001B_WS_NUM_PROPOSTA_R(); _.Move(WS_NUM_PROPOSTA_DESLOC, _ws_num_proposta_r); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA_DESLOC, _ws_num_proposta_r, WS_NUM_PROPOSTA_DESLOC); _ws_num_proposta_r.ValueChanged += () => { _.Move(_ws_num_proposta_r, WS_NUM_PROPOSTA_DESLOC); }; return _ws_num_proposta_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_r, WS_NUM_PROPOSTA_DESLOC); }
            }  //Redefines
            public class _REDEF_PF4001B_WS_NUM_PROPOSTA_R : VarBasis
            {
                /*"        10  WS-NUM-PROPOSTA-DESLOC-13 PIC 9(013).*/
                public IntBasis WS_NUM_PROPOSTA_DESLOC_13 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        10  WS-NUM-PROPOSTA-DESLOC-01 PIC 9(001).*/
                public IntBasis WS_NUM_PROPOSTA_DESLOC_01 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01  WS-REG-ENTRADA.*/

                public _REDEF_PF4001B_WS_NUM_PROPOSTA_R()
                {
                    WS_NUM_PROPOSTA_DESLOC_13.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_DESLOC_01.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF4001B_WS_REG_ENTRADA WS_REG_ENTRADA { get; set; } = new PF4001B_WS_REG_ENTRADA();
        public class PF4001B_WS_REG_ENTRADA : VarBasis
        {
            /*"    02  REG-TIPO-REGISTRO.*/
            public PF4001B_REG_TIPO_REGISTRO REG_TIPO_REGISTRO { get; set; } = new PF4001B_REG_TIPO_REGISTRO();
            public class PF4001B_REG_TIPO_REGISTRO : VarBasis
            {
                /*"        03  REG-TIPOREG               PIC X(001).*/
                public StringBasis REG_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        03  REG-NUM-PROPOSTA          PIC 9(014).*/
                public IntBasis REG_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"        03  FILLER    REDEFINES     REG-NUM-PROPOSTA.*/
                private _REDEF_PF4001B_FILLER_0 _filler_0 { get; set; }
                public _REDEF_PF4001B_FILLER_0 FILLER_0
                {
                    get { _filler_0 = new _REDEF_PF4001B_FILLER_0(); _.Move(REG_NUM_PROPOSTA, _filler_0); VarBasis.RedefinePassValue(REG_NUM_PROPOSTA, _filler_0, REG_NUM_PROPOSTA); _filler_0.ValueChanged += () => { _.Move(_filler_0, REG_NUM_PROPOSTA); }; return _filler_0; }
                    set { VarBasis.RedefinePassValue(value, _filler_0, REG_NUM_PROPOSTA); }
                }  //Redefines
                public class _REDEF_PF4001B_FILLER_0 : VarBasis
                {
                    /*"            05  REG-NUM-PROPOSTA-A    PIC X(014).*/
                    public StringBasis REG_NUM_PROPOSTA_A { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
                    /*"        03  FILLER    REDEFINES     REG-NUM-PROPOSTA.*/

                    public _REDEF_PF4001B_FILLER_0()
                    {
                        REG_NUM_PROPOSTA_A.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_PF4001B_FILLER_1 _filler_1 { get; set; }
                public _REDEF_PF4001B_FILLER_1 FILLER_1
                {
                    get { _filler_1 = new _REDEF_PF4001B_FILLER_1(); _.Move(REG_NUM_PROPOSTA, _filler_1); VarBasis.RedefinePassValue(REG_NUM_PROPOSTA, _filler_1, REG_NUM_PROPOSTA); _filler_1.ValueChanged += () => { _.Move(_filler_1, REG_NUM_PROPOSTA); }; return _filler_1; }
                    set { VarBasis.RedefinePassValue(value, _filler_1, REG_NUM_PROPOSTA); }
                }  //Redefines
                public class _REDEF_PF4001B_FILLER_1 : VarBasis
                {
                    /*"            05  REG-NOME-HT           PIC X(008).*/
                    public StringBasis REG_NOME_HT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"            05  FILLER   REDEFINES   REG-NOME-HT.*/
                    private _REDEF_PF4001B_FILLER_2 _filler_2 { get; set; }
                    public _REDEF_PF4001B_FILLER_2 FILLER_2
                    {
                        get { _filler_2 = new _REDEF_PF4001B_FILLER_2(); _.Move(REG_NOME_HT, _filler_2); VarBasis.RedefinePassValue(REG_NOME_HT, _filler_2, REG_NOME_HT); _filler_2.ValueChanged += () => { _.Move(_filler_2, REG_NOME_HT); }; return _filler_2; }
                        set { VarBasis.RedefinePassValue(value, _filler_2, REG_NOME_HT); }
                    }  //Redefines
                    public class _REDEF_PF4001B_FILLER_2 : VarBasis
                    {
                        /*"                07  FILLER            PIC X(005).*/
                        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                        /*"                07  COD-PROD-POS67    PIC 9(002).*/
                        public IntBasis COD_PROD_POS67 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"                07  FILLER            PIC X(001).*/
                        public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"            05  REG-RESTO             PIC X(006).*/

                        public _REDEF_PF4001B_FILLER_2()
                        {
                            FILLER_3.ValueChanged += OnValueChanged;
                            COD_PROD_POS67.ValueChanged += OnValueChanged;
                            FILLER_4.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis REG_RESTO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                    /*"        03  REG-COD-PRODUTO-SIVPF     PIC 9(004).*/

                    public _REDEF_PF4001B_FILLER_1()
                    {
                        REG_NOME_HT.ValueChanged += OnValueChanged;
                        FILLER_2.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis REG_COD_PRODUTO_SIVPF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        03  REG-COD-AGENCIA           PIC 9(004).*/
                public IntBasis REG_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        03  REG-DATA-PROPOSTA         PIC 9(008).*/
                public IntBasis REG_DATA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"        03  FILLER                    PIC X(245).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "245", "X(245)."), @"");
                /*"        03  REG-ORIGEM-PROPOSTA       PIC 9(002).*/
                public IntBasis REG_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        03  FILLER                    PIC X(022).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
                /*"        03  REG-COD-RETORNO-SIGPF     PIC 9(003).*/
                public IntBasis REG_COD_RETORNO_SIGPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        03  REG-DESC-RETORNO-SIGPF    PIC X(027).*/
                public StringBasis REG_DESC_RETORNO_SIGPF { get; set; } = new StringBasis(new PIC("X", "27", "X(027)."), @"");
                /*"    02  FILLER   REDEFINES  REG-TIPO-REGISTRO.*/
            }
            private _REDEF_PF4001B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_PF4001B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_PF4001B_FILLER_7(); _.Move(REG_TIPO_REGISTRO, _filler_7); VarBasis.RedefinePassValue(REG_TIPO_REGISTRO, _filler_7, REG_TIPO_REGISTRO); _filler_7.ValueChanged += () => { _.Move(_filler_7, REG_TIPO_REGISTRO); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, REG_TIPO_REGISTRO); }
            }  //Redefines
            public class _REDEF_PF4001B_FILLER_7 : VarBasis
            {
                /*"        04  RS3-TIPO-SASSE.*/
                public PF4001B_RS3_TIPO_SASSE RS3_TIPO_SASSE { get; set; } = new PF4001B_RS3_TIPO_SASSE();
                public class PF4001B_RS3_TIPO_SASSE : VarBasis
                {
                    /*"            05  RS3-TIPOREG           PIC X(001).*/
                    public StringBasis RS3_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  RS3-NUM-PROPOSTA      PIC 9(014).*/
                    public IntBasis RS3_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"            05  RS3-COD-PRODUTO       PIC 9(004).*/
                    public IntBasis RS3_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RS3-COD-AGENCIA       PIC 9(004).*/
                    public IntBasis RS3_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RS3-DATA-PROPOSTA     PIC 9(008).*/
                    public IntBasis RS3_DATA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05   FILLER REDEFINES    RS3-DATA-PROPOSTA.*/
                    private _REDEF_PF4001B_FILLER_8 _filler_8 { get; set; }
                    public _REDEF_PF4001B_FILLER_8 FILLER_8
                    {
                        get { _filler_8 = new _REDEF_PF4001B_FILLER_8(); _.Move(RS3_DATA_PROPOSTA, _filler_8); VarBasis.RedefinePassValue(RS3_DATA_PROPOSTA, _filler_8, RS3_DATA_PROPOSTA); _filler_8.ValueChanged += () => { _.Move(_filler_8, RS3_DATA_PROPOSTA); }; return _filler_8; }
                        set { VarBasis.RedefinePassValue(value, _filler_8, RS3_DATA_PROPOSTA); }
                    }  //Redefines
                    public class _REDEF_PF4001B_FILLER_8 : VarBasis
                    {
                        /*"                06 RS3-DIA-PROP       PIC 9(002).*/
                        public IntBasis RS3_DIA_PROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"                06 RS3-MES-PROP       PIC 9(002).*/
                        public IntBasis RS3_MES_PROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"                06 RS3-ANO-PROP       PIC 9(004).*/
                        public IntBasis RS3_ANO_PROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"            05  RS3-TIPO-PAGTO        PIC 9(001).*/

                        public _REDEF_PF4001B_FILLER_8()
                        {
                            RS3_DIA_PROP.ValueChanged += OnValueChanged;
                            RS3_MES_PROP.ValueChanged += OnValueChanged;
                            RS3_ANO_PROP.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis RS3_TIPO_PAGTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05  RS3-AGENCIA           PIC 9(004).*/
                    public IntBasis RS3_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RS3-OPERACAO          PIC 9(004).*/
                    public IntBasis RS3_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RS3-CONTA             PIC 9(012).*/
                    public IntBasis RS3_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                    /*"            05  RS3-DV                PIC 9(001).*/
                    public IntBasis RS3_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05  RS3-DEC-PESS-TIT      PIC X(007).*/
                    public StringBasis RS3_DEC_PESS_TIT { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"            05  RS3-DEC-PESS-CONJ     PIC X(007).*/
                    public StringBasis RS3_DEC_PESS_CONJ { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"            05  RS3-MATRIC-VENDEDOR   PIC 9(008).*/
                    public IntBasis RS3_MATRIC_VENDEDOR { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RS3-VAL-PREMIO-LIQ    PIC 9(016).*/
                    public IntBasis RS3_VAL_PREMIO_LIQ { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                    /*"            05  RS3-APOS-INVALIDEZ    PIC X(001).*/
                    public StringBasis RS3_APOS_INVALIDEZ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  RS3-RENOV-AUTOMATICA  PIC X(001).*/
                    public StringBasis RS3_RENOV_AUTOMATICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  RS3-DIA-VENC          PIC 9(002).*/
                    public IntBasis RS3_DIA_VENC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"            05  RS3-PERC-DESCONTO     PIC 9(005).*/
                    public IntBasis RS3_PERC_DESCONTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"            05  RS3-EMP-CONVEN        PIC X(040).*/
                    public StringBasis RS3_EMP_CONVEN { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                    /*"            05  RS3-CNPJ-EMP-CONVEN   PIC 9(014).*/
                    public IntBasis RS3_CNPJ_EMP_CONVEN { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"            05  FILLER                PIC X(003).*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"            05  RS3-SIT-PROPOSTA      PIC X(003).*/
                    public StringBasis RS3_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"            05  RS3-SIT-COBRANCA      PIC X(003).*/
                    public StringBasis RS3_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"            05  RS3-MOTIVO-SITUACAO   PIC 9(003).*/
                    public IntBasis RS3_MOTIVO_SITUACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"            05  RS3-OPCAO-COBERTURA   PIC X(001).*/
                    public StringBasis RS3_OPCAO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  RS3-COD-PLANO         PIC 9(004).*/
                    public IntBasis RS3_COD_PLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RS3-DT-QUIT-BCO       PIC 9(008).*/
                    public IntBasis RS3_DT_QUIT_BCO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RS3-VAL-PAGO-SICOB    PIC 9(015).*/
                    public IntBasis RS3_VAL_PAGO_SICOB { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"            05  RS3-COD-AGENC-PAGTO   PIC 9(004).*/
                    public IntBasis RS3_COD_AGENC_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"            05  RS3-TARIFA-COBRANCA   PIC 9(015).*/
                    public IntBasis RS3_TARIFA_COBRANCA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"            05  RS3-DT-CREDITO-SEG    PIC 9(008).*/
                    public IntBasis RS3_DT_CREDITO_SEG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RS3-VAL-COMISSAO      PIC 9(015).*/
                    public IntBasis RS3_VAL_COMISSAO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"            05  RS3-PERIODIC-PAGTO    PIC 9(002).*/
                    public IntBasis RS3_PERIODIC_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"            05  RS3-OPCAO-CONJUGE     PIC X(001).*/
                    public StringBasis RS3_OPCAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  RS3-TIPO-RESIDENCIA   PIC 9(001).*/
                    public IntBasis RS3_TIPO_RESIDENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05  RS3-VAL-IOF           PIC 9(008).*/
                    public IntBasis RS3_VAL_IOF { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RS3-CUSTO-APOLICE     PIC 9(008).*/
                    public IntBasis RS3_CUSTO_APOLICE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  FILLER                PIC X(005).*/
                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                    /*"            05  RS3-NUM-SICOB         PIC 9(013).*/
                    public IntBasis RS3_NUM_SICOB { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                    /*"            05  RS3-ORIGEM-PROPOSTA   PIC X(004).*/
                    public StringBasis RS3_ORIGEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"            05   FILLER REDEFINES    RS3-ORIGEM-PROPOSTA.*/
                    private _REDEF_PF4001B_FILLER_11 _filler_11 { get; set; }
                    public _REDEF_PF4001B_FILLER_11 FILLER_11
                    {
                        get { _filler_11 = new _REDEF_PF4001B_FILLER_11(); _.Move(RS3_ORIGEM_PROPOSTA, _filler_11); VarBasis.RedefinePassValue(RS3_ORIGEM_PROPOSTA, _filler_11, RS3_ORIGEM_PROPOSTA); _filler_11.ValueChanged += () => { _.Move(_filler_11, RS3_ORIGEM_PROPOSTA); }; return _filler_11; }
                        set { VarBasis.RedefinePassValue(value, _filler_11, RS3_ORIGEM_PROPOSTA); }
                    }  //Redefines
                    public class _REDEF_PF4001B_FILLER_11 : VarBasis
                    {
                        /*"                06 RS3-ORIGEM-1A2     PIC X(002).*/
                        public StringBasis RS3_ORIGEM_1A2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                        /*"                06 RS3-ORIGEM-AIC     PIC 9(002).*/
                        public IntBasis RS3_ORIGEM_AIC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"            05  RS3-NSAS              PIC 9(006).*/

                        public _REDEF_PF4001B_FILLER_11()
                        {
                            RS3_ORIGEM_1A2.ValueChanged += OnValueChanged;
                            RS3_ORIGEM_AIC.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis RS3_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"            05  RS3-NSL               PIC 9(006).*/
                    public IntBasis RS3_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"            05  RS3-PRAZO-VIGENCIA    PIC 9(002).*/
                    public IntBasis RS3_PRAZO_VIGENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"            05  RS3-USO-RESERVADO     PIC 9(008).*/
                    public IntBasis RS3_USO_RESERVADO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RS3-COD-RET-SIGPF     PIC 9(003).*/
                    public IntBasis RS3_COD_RET_SIGPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"            05  RS3-DESC-RET-SIGPF    PIC X(027).*/
                    public StringBasis RS3_DESC_RET_SIGPF { get; set; } = new StringBasis(new PIC("X", "27", "X(027)."), @"");
                    /*"    02  FILLER   REDEFINES  REG-TIPO-REGISTRO.*/

                    public PF4001B_RS3_TIPO_SASSE()
                    {
                        RS3_TIPOREG.ValueChanged += OnValueChanged;
                        RS3_NUM_PROPOSTA.ValueChanged += OnValueChanged;
                        RS3_COD_PRODUTO.ValueChanged += OnValueChanged;
                        RS3_COD_AGENCIA.ValueChanged += OnValueChanged;
                        RS3_DATA_PROPOSTA.ValueChanged += OnValueChanged;
                        FILLER_8.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_PF4001B_FILLER_7()
                {
                    RS3_TIPO_SASSE.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF4001B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_PF4001B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_PF4001B_FILLER_12(); _.Move(REG_TIPO_REGISTRO, _filler_12); VarBasis.RedefinePassValue(REG_TIPO_REGISTRO, _filler_12, REG_TIPO_REGISTRO); _filler_12.ValueChanged += () => { _.Move(_filler_12, REG_TIPO_REGISTRO); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, REG_TIPO_REGISTRO); }
            }  //Redefines
            public class _REDEF_PF4001B_FILLER_12 : VarBasis
            {
                /*"        04  RSH-TIPO-SASSE.*/
                public PF4001B_RSH_TIPO_SASSE RSH_TIPO_SASSE { get; set; } = new PF4001B_RSH_TIPO_SASSE();
                public class PF4001B_RSH_TIPO_SASSE : VarBasis
                {
                    /*"            05  RSH-TIPOREG           PIC X(001).*/
                    public StringBasis RSH_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  RSH-ARQUIVO           PIC X(008).*/
                    public StringBasis RSH_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"            05  RSH-DATA-PROPOSTA     PIC 9(008).*/
                    public IntBasis RSH_DATA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  RSH-COD-SIST          PIC 9(001).*/
                    public IntBasis RSH_COD_SIST { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05  RSH-COD-SIST-DEST     PIC 9(001).*/
                    public IntBasis RSH_COD_SIST_DEST { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05  RSH-SEQ-ARQ           PIC 9(007).*/
                    public IntBasis RSH_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                    /*"01  WS-RSH-SEQ-ARQ                    PIC 9(007).*/

                    public PF4001B_RSH_TIPO_SASSE()
                    {
                        RSH_TIPOREG.ValueChanged += OnValueChanged;
                        RSH_ARQUIVO.ValueChanged += OnValueChanged;
                        RSH_DATA_PROPOSTA.ValueChanged += OnValueChanged;
                        RSH_COD_SIST.ValueChanged += OnValueChanged;
                        RSH_COD_SIST_DEST.ValueChanged += OnValueChanged;
                        RSH_SEQ_ARQ.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_PF4001B_FILLER_12()
                {
                    RSH_TIPO_SASSE.ValueChanged += OnValueChanged;
                }

            }
        }
        public IntBasis WS_RSH_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
        /*"01  WORK-AREA.*/
        public PF4001B_WORK_AREA WORK_AREA { get; set; } = new PF4001B_WORK_AREA();
        public class PF4001B_WORK_AREA : VarBasis
        {
            /*"            05  WS-NSL                PIC 9(006).*/
            public IntBasis WS_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"            05  WS-NUM-PROPOSTA       PIC 9(014).*/
            public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"            05  WS-NUM-PROPOSTA-R     REDEFINES                WS-NUM-PROPOSTA.*/
            private _REDEF_PF4001B_WS_NUM_PROPOSTA_R_0 _ws_num_proposta_r_0 { get; set; }
            public _REDEF_PF4001B_WS_NUM_PROPOSTA_R_0 WS_NUM_PROPOSTA_R_0
            {
                get { _ws_num_proposta_r_0 = new _REDEF_PF4001B_WS_NUM_PROPOSTA_R_0(); _.Move(WS_NUM_PROPOSTA, _ws_num_proposta_r_0); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA, _ws_num_proposta_r_0, WS_NUM_PROPOSTA); _ws_num_proposta_r_0.ValueChanged += () => { _.Move(_ws_num_proposta_r_0, WS_NUM_PROPOSTA); }; return _ws_num_proposta_r_0; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_r_0, WS_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF4001B_WS_NUM_PROPOSTA_R_0 : VarBasis
            {
                /*"                10  WS-NUM-PROPOSTA-9 PIC 9(013).*/
                public IntBasis WS_NUM_PROPOSTA_9 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"                10  WS-NUM-PROPOSTA-0 PIC 9(001).*/
                public IntBasis WS_NUM_PROPOSTA_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"            05        DATA-ARQ.*/

                public _REDEF_PF4001B_WS_NUM_PROPOSTA_R_0()
                {
                    WS_NUM_PROPOSTA_9.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_0.ValueChanged += OnValueChanged;
                }

            }
            public PF4001B_DATA_ARQ DATA_ARQ { get; set; } = new PF4001B_DATA_ARQ();
            public class PF4001B_DATA_ARQ : VarBasis
            {
                /*"              10      DIA-ARQ         PIC  9(002).*/
                public IntBasis DIA_ARQ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"              10      MES-ARQ         PIC  9(002).*/
                public IntBasis MES_ARQ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"              10      ANO-ARQ         PIC  9(004).*/
                public IntBasis ANO_ARQ { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"            05        DATA-SQL.*/
            }
            public PF4001B_DATA_SQL DATA_SQL { get; set; } = new PF4001B_DATA_SQL();
            public class PF4001B_DATA_SQL : VarBasis
            {
                /*"              10      ANO-SQL         PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"              10      FILLER          PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"              10      MES-SQL         PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"              10      FILLER          PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"              10      DIA-SQL         PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"             05 WS-DATA-HEADER         PIC  X(010) VALUE SPACES.*/
                public StringBasis WS_DATA_HEADER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05        WFIM-V1SISTEMA      PIC   X(01)  VALUE  ' '.*/
                public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    05        WFIM-MOV4001E       PIC   X(01)  VALUE  ' '.*/
                public StringBasis WFIM_MOV4001E { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
                public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    05        AC-PROCESSADOS      PIC  9(006) VALUE ZEROS.*/
                public IntBasis AC_PROCESSADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    05        AC-GRAVADOS         PIC  9(006) VALUE ZEROS.*/
                public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    05        WABEND.*/
                public PF4001B_WABEND WABEND { get; set; } = new PF4001B_WABEND();
                public class PF4001B_WABEND : VarBasis
                {
                    /*"      10      FILLER              PIC  X(010) VALUE             ' PF4001B '.*/
                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" PF4001B ");
                    /*"      10      FILLER              PIC  X(026) VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                    public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                    /*"      10      WNR-EXEC-SQL        PIC  X(006) VALUE '000000'.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"000000");
                    /*"      10      FILLER              PIC  X(013) VALUE             ' *** SQLCODE '.*/
                    public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                    /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                    /*"      10      FILLER              PIC  X(014) VALUE             ' *** SQLERRMC '.*/
                    public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                    /*"      10      WSQLERRMC           PIC  X(070)    VALUE SPACES.*/
                    public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                }
            }
        }


        public Copies.PF0005W PF0005W { get; set; } = new Copies.PF0005W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string CVPRJPRP_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                CVPRJPRP.SetFile(CVPRJPRP_FILE_NAME_P);

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
            /*" -237- MOVE 'R0000' TO WNR-EXEC-SQL. */
            _.Move("R0000", WORK_AREA.DATA_SQL.WABEND.WNR_EXEC_SQL);

            /*" -238- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -241- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -244- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -247- DISPLAY '-----------------------------------' */
            _.Display($"-----------------------------------");

            /*" -248- DISPLAY 'PROGRAMA EM EXECUCAO    PF4001B    ' */
            _.Display($"PROGRAMA EM EXECUCAO    PF4001B    ");

            /*" -250- DISPLAY 'VERSAO V.02             07/01/2025 ' */
            _.Display($"VERSAO V.02             07/01/2025 ");

            /*" -252- DISPLAY '-----------------------------------' . */
            _.Display($"-----------------------------------");

            /*" -254- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -255- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!WORK_AREA.DATA_SQL.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -256- DISPLAY '*** PROBLEMAS NA SISTEMAS' */
                _.Display($"*** PROBLEMAS NA SISTEMAS");

                /*" -257- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -259- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -261- OPEN INPUT CVPRJPRP. */
            CVPRJPRP.Open(REG_CVPRJPRP);

            /*" -262- PERFORM R0110-00-LER-MOV4001E. */

            R0110_00_LER_MOV4001E_SECTION();

            /*" -263- IF WFIM-MOV4001E NOT EQUAL SPACES */

            if (!WORK_AREA.DATA_SQL.WFIM_MOV4001E.IsEmpty())
            {

                /*" -264- DISPLAY 'PF4001B - MOV4001E VAZIO' */
                _.Display($"PF4001B - MOV4001E VAZIO");

                /*" -266- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -267- PERFORM R1000-00-PROCESSA UNTIL WFIM-MOV4001E EQUAL 'S' . */

            while (!(WORK_AREA.DATA_SQL.WFIM_MOV4001E == "S"))
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
            /*" -273- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -274- DISPLAY '*** PF4001B ***' */
            _.Display($"*** PF4001B ***");

            /*" -275- DISPLAY 'LIDOS MOV2646E            ' AC-LIDOS */
            _.Display($"LIDOS MOV2646E            {WORK_AREA.DATA_SQL.AC_LIDOS}");

            /*" -276- DISPLAY 'PROCESSADOS VIDA          ' AC-PROCESSADOS */
            _.Display($"PROCESSADOS VIDA          {WORK_AREA.DATA_SQL.AC_PROCESSADOS}");

            /*" -277- DISPLAY 'GRAVADOS HIS_PROP_FIDELIZ ' AC-GRAVADOS */
            _.Display($"GRAVADOS HIS_PROP_FIDELIZ {WORK_AREA.DATA_SQL.AC_GRAVADOS}");

            /*" -278- DISPLAY '*** PF4001B - TERMINO NORMAL ***' */
            _.Display($"*** PF4001B - TERMINO NORMAL ***");

            /*" -279- CLOSE CVPRJPRP. */
            CVPRJPRP.Close();

            /*" -279- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -290- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", WORK_AREA.DATA_SQL.WABEND.WNR_EXEC_SQL);

            /*" -295- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -298- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -299- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -300- DISPLAY 'PF4001B - ERRO ACESSO SISTEMAS VG' */
                    _.Display($"PF4001B - ERRO ACESSO SISTEMAS VG");

                    /*" -301- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", WORK_AREA.DATA_SQL.WFIM_V1SISTEMA);

                    /*" -302- ELSE */
                }
                else
                {


                    /*" -303- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA.DATA_SQL.WABEND.WSQLCODE);

                    /*" -304- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -305- END-IF */
                }


                /*" -305- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -295- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

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
        /*" R0110-00-LER-MOV4001E-SECTION */
        private void R0110_00_LER_MOV4001E_SECTION()
        {
            /*" -316- READ CVPRJPRP INTO WS-REG-ENTRADA AT END */
            try
            {
                CVPRJPRP.Read(() =>
                {

                    /*" -318- MOVE 'S' TO WFIM-MOV4001E */
                    _.Move("S", WORK_AREA.DATA_SQL.WFIM_MOV4001E);

                    /*" -319- GO TO R0110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/ //GOTO
                    return;

                    /*" -320- NOT AT END */
                }, () =>
                {

                    /*" -321- ADD 1 TO AC-LIDOS */
                    WORK_AREA.DATA_SQL.AC_LIDOS.Value = WORK_AREA.DATA_SQL.AC_LIDOS + 1;

                    /*" -321- END-READ. */
                });

                _.Move(CVPRJPRP.Value, WS_REG_ENTRADA); _.Move(CVPRJPRP.Value, REG_CVPRJPRP);

            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -332- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", WORK_AREA.DATA_SQL.WABEND.WNR_EXEC_SQL);

            /*" -334- INITIALIZE DCLPROPOSTA-FIDELIZ */
            _.Initialize(
                PROPOFID.DCLPROPOSTA_FIDELIZ
            );

            /*" -335- IF RSH-TIPOREG EQUAL 'H' */

            if (WS_REG_ENTRADA.FILLER_12.RSH_TIPO_SASSE.RSH_TIPOREG == "H")
            {

                /*" -336- MOVE RSH-SEQ-ARQ TO WS-RSH-SEQ-ARQ */
                _.Move(WS_REG_ENTRADA.FILLER_12.RSH_TIPO_SASSE.RSH_SEQ_ARQ, WS_RSH_SEQ_ARQ);

                /*" -337- DISPLAY 'RSH-DATA-PROPOSTA ' RSH-DATA-PROPOSTA */
                _.Display($"RSH-DATA-PROPOSTA {WS_REG_ENTRADA.FILLER_12.RSH_TIPO_SASSE.RSH_DATA_PROPOSTA}");

                /*" -338- MOVE RSH-DATA-PROPOSTA TO DATA-ARQ */
                _.Move(WS_REG_ENTRADA.FILLER_12.RSH_TIPO_SASSE.RSH_DATA_PROPOSTA, WORK_AREA.DATA_ARQ);

                /*" -339- MOVE DIA-ARQ TO DIA-SQL */
                _.Move(WORK_AREA.DATA_ARQ.DIA_ARQ, WORK_AREA.DATA_SQL.DIA_SQL);

                /*" -340- MOVE MES-ARQ TO MES-SQL */
                _.Move(WORK_AREA.DATA_ARQ.MES_ARQ, WORK_AREA.DATA_SQL.MES_SQL);

                /*" -341- MOVE ANO-ARQ TO ANO-SQL */
                _.Move(WORK_AREA.DATA_ARQ.ANO_ARQ, WORK_AREA.DATA_SQL.ANO_SQL);

                /*" -342- MOVE DATA-SQL TO WS-DATA-HEADER */
                _.Move(WORK_AREA.DATA_SQL, WORK_AREA.DATA_SQL.WS_DATA_HEADER);

                /*" -343- GO TO R1000-90-CONTINUA */

                R1000_90_CONTINUA(); //GOTO
                return;

                /*" -345- END-IF */
            }


            /*" -346- IF REG-TIPOREG EQUAL '3' */

            if (WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_TIPOREG == "3")
            {

                /*" -355- IF REG-COD-PRODUTO-SIVPF EQUAL 06 OR 07 OR 09 OR 11 OR 13 OR 16 OR 29 OR 30 OR 37 OR 46 OR 48 OR 54 OR 56 OR 93 */

                if (WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_COD_PRODUTO_SIVPF.In("06", "07", "09", "11", "13", "16", "29", "30", "37", "46", "48", "54", "56", "93"))
                {

                    /*" -356- MOVE RS3-NSL TO WS-NSL */
                    _.Move(WS_REG_ENTRADA.FILLER_7.RS3_TIPO_SASSE.RS3_NSL, WORK_AREA.WS_NSL);

                    /*" -357- ADD 1 TO AC-PROCESSADOS */
                    WORK_AREA.DATA_SQL.AC_PROCESSADOS.Value = WORK_AREA.DATA_SQL.AC_PROCESSADOS + 1;

                    /*" -358- PERFORM R1900-00-SELECT-PROPOFID */

                    R1900_00_SELECT_PROPOFID_SECTION();

                    /*" -359- PERFORM R1010-PREPARAR-HISTORICO */

                    R1010_PREPARAR_HISTORICO_SECTION();

                    /*" -360- END-IF */
                }


                /*" -360- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_CONTINUA */

            R1000_90_CONTINUA();

        }

        [StopWatch]
        /*" R1000-90-CONTINUA */
        private void R1000_90_CONTINUA(bool isPerform = false)
        {
            /*" -362- PERFORM R0110-00-LER-MOV4001E. */

            R0110_00_LER_MOV4001E_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-PREPARAR-HISTORICO-SECTION */
        private void R1010_PREPARAR_HISTORICO_SECTION()
        {
            /*" -371- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R1010_00_START */

            R1010_00_START();

        }

        [StopWatch]
        /*" R1010-00-START */
        private void R1010_00_START(bool isPerform = false)
        {
            /*" -375- MOVE 'R1010' TO WNR-EXEC-SQL. */
            _.Move("R1010", WORK_AREA.DATA_SQL.WABEND.WNR_EXEC_SQL);

            /*" -375- PERFORM R1010-05-INICIO. */

            R1010_05_INICIO(true);

        }

        [StopWatch]
        /*" R1010-05-INICIO */
        private void R1010_05_INICIO(bool isPerform = false)
        {
            /*" -381- MOVE PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO LK-PF005-E-NUM-IDENTIFICACAO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PF0005W.LK_PF005_E_NUM_IDENTIFICACAO);

            /*" -382- MOVE WS-DATA-HEADER TO LK-PF005-E-DATA-SITUACAO */
            _.Move(WORK_AREA.DATA_SQL.WS_DATA_HEADER, PF0005W.LK_PF005_E_DATA_SITUACAO);

            /*" -383- MOVE WS-RSH-SEQ-ARQ TO LK-PF005-E-NSAS-SIVPF */
            _.Move(WS_RSH_SEQ_ARQ, PF0005W.LK_PF005_E_NSAS_SIVPF);

            /*" -386- MOVE WS-NSL TO LK-PF005-E-NSL */
            _.Move(WORK_AREA.WS_NSL, PF0005W.LK_PF005_E_NSL);

            /*" -388- MOVE PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO LK-PF005-E-SIT-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA, PF0005W.LK_PF005_E_SIT_PROPOSTA);

            /*" -390- MOVE SPACES TO LK-PF005-E-SIT-COBRANCA-SIVPF */
            _.Move("", PF0005W.LK_PF005_E_SIT_COBRANCA_SIVPF);

            /*" -392- MOVE 0 TO LK-PF005-E-SIT-MOTIVO-SIVPF */
            _.Move(0, PF0005W.LK_PF005_E_SIT_MOTIVO_SIVPF);

            /*" -394- MOVE PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-PF005-E-COD-EMPRESA-SIVPF */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PF0005W.LK_PF005_E_COD_EMPRESA_SIVPF);

            /*" -396- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-PF005-E-COD-PRODUTO-SIVPF */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PF0005W.LK_PF005_E_COD_PRODUTO_SIVPF);

            /*" -397- MOVE 'R' TO LK-PF005-E-IND-TP-ACAO */
            _.Move("R", PF0005W.LK_PF005_E_IND_TP_ACAO);

            /*" -399- MOVE 'P' TO LK-PF005-E-IND-TP-SENSIBILIZA */
            _.Move("P", PF0005W.LK_PF005_E_IND_TP_SENSIBILIZA);

            /*" -401- MOVE '0001-01-01' TO LK-PF005-E-DTA-INI-VIGENCIA LK-PF005-E-DTA-FIM-VIGENCIA */
            _.Move("0001-01-01", PF0005W.LK_PF005_E_DTA_INI_VIGENCIA, PF0005W.LK_PF005_E_DTA_FIM_VIGENCIA);

            /*" -403- MOVE DATA-SQL TO LK-PF005-E-DTA-PROCESSA-CEF */
            _.Move(WORK_AREA.DATA_SQL, PF0005W.LK_PF005_E_DTA_PROCESSA_CEF);

            /*" -404- MOVE 0 TO LK-PF005-E-NUM-PARCELA */
            _.Move(0, PF0005W.LK_PF005_E_NUM_PARCELA);

            /*" -406- MOVE 0 TO LK-PF005-E-COD-TP-LANCAMENTO */
            _.Move(0, PF0005W.LK_PF005_E_COD_TP_LANCAMENTO);

            /*" -408- MOVE PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ TO LK-PF005-E-VLR-PREMIO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, PF0005W.LK_PF005_E_VLR_PREMIO);

            /*" -410- MOVE RS3-COD-RET-SIGPF TO LK-PF005-E-COD-ERRO */
            _.Move(WS_REG_ENTRADA.FILLER_7.RS3_TIPO_SASSE.RS3_COD_RET_SIGPF, PF0005W.LK_PF005_E_COD_ERRO);

            /*" -411- PERFORM R1020-GRAVA-HISTORICO */

            R1020_GRAVA_HISTORICO_SECTION();

            /*" -411- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_EXIT*/

        [StopWatch]
        /*" R1020-GRAVA-HISTORICO-SECTION */
        private void R1020_GRAVA_HISTORICO_SECTION()
        {
            /*" -421- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R1020_00_START */

            R1020_00_START();

        }

        [StopWatch]
        /*" R1020-00-START */
        private void R1020_00_START(bool isPerform = false)
        {
            /*" -426- MOVE 'R1020' TO WNR-EXEC-SQL. */
            _.Move("R1020", WORK_AREA.DATA_SQL.WABEND.WNR_EXEC_SQL);

            /*" -427- MOVE 'N' TO LK-PF005-E-TRACE */
            _.Move("N", PF0005W.LK_PF005_E_TRACE);

            /*" -428- MOVE 01 TO LK-PF005-E-ACAO */
            _.Move(01, PF0005W.LK_PF005_E_ACAO);

            /*" -429- MOVE 'BATCH' TO LK-PF005-E-COD-USUARIO */
            _.Move("BATCH", PF0005W.LK_PF005_E_COD_USUARIO);

            /*" -431- MOVE 'PF4001B' TO LK-PF005-E-NOM-PROGRAMA. */
            _.Move("PF4001B", PF0005W.LK_PF005_E_NOM_PROGRAMA);

            /*" -431- PERFORM R1020-05-INICIO. */

            R1020_05_INICIO(true);

        }

        [StopWatch]
        /*" R1020-05-INICIO */
        private void R1020_05_INICIO(bool isPerform = false)
        {
            /*" -435- MOVE 'PF0005S' TO WS-PROGRAMA */
            _.Move("PF0005S", AREA_DE_WORK.WS_PROGRAMA);

            /*" -464- CALL WS-PROGRAMA USING LK-PF005-E-TRACE LK-PF005-E-ACAO LK-PF005-E-NUM-IDENTIFICACAO LK-PF005-E-DATA-SITUACAO LK-PF005-E-NSAS-SIVPF LK-PF005-E-NSL LK-PF005-E-SIT-PROPOSTA LK-PF005-E-SIT-COBRANCA-SIVPF LK-PF005-E-SIT-MOTIVO-SIVPF LK-PF005-E-COD-EMPRESA-SIVPF LK-PF005-E-COD-PRODUTO-SIVPF LK-PF005-E-IND-TP-ACAO LK-PF005-E-IND-TP-SENSIBILIZA LK-PF005-E-DTA-INI-VIGENCIA LK-PF005-E-DTA-FIM-VIGENCIA LK-PF005-E-NUM-PARCELA LK-PF005-E-COD-TP-LANCAMENTO LK-PF005-E-VLR-PREMIO LK-PF005-E-COD-ERRO LK-PF005-E-DTA-PROCESSA-CEF LK-PF005-E-COD-USUARIO LK-PF005-E-NOM-PROGRAMA LK-PF005-IND-ERRO LK-PF005-MENSAGEM LK-PF005-NOM-TABELA LK-PF005-SQLCODE LK-PF005-SQLERRMC LK-PF005-SQLSTATE. */
            _.Call(AREA_DE_WORK.WS_PROGRAMA, PF0005W);

            /*" -465- IF LK-PF005-IND-ERRO NOT = 0 */

            if (PF0005W.LK_PF005_IND_ERRO != 0)
            {

                /*" -466- DISPLAY '**    PF4001 - ERRO - SECTION R1020  ***' */
                _.Display($"**    PF4001 - ERRO - SECTION R1020  ***");

                /*" -467- MOVE LK-PF005-IND-ERRO TO WS-SMALLINT(01) */
                _.Move(PF0005W.LK_PF005_IND_ERRO, AREA_DE_WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -468- DISPLAY '** IND-ERRO.....: ' LK-PF005-SQLCODE */
                _.Display($"** IND-ERRO.....: {PF0005W.LK_PF005_SQLCODE}");

                /*" -469- DISPLAY '** MENSAGEM.....: ' LK-PF005-MENSAGEM */
                _.Display($"** MENSAGEM.....: {PF0005W.LK_PF005_MENSAGEM}");

                /*" -470- DISPLAY '** NOM-TABELA...: ' LK-PF005-NOM-TABELA */
                _.Display($"** NOM-TABELA...: {PF0005W.LK_PF005_NOM_TABELA}");

                /*" -471- MOVE LK-PF005-SQLCODE TO WS-SMALLINT(01) */
                _.Move(PF0005W.LK_PF005_SQLCODE, AREA_DE_WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -472- DISPLAY '** SQLCODE......: ' LK-PF005-SQLCODE */
                _.Display($"** SQLCODE......: {PF0005W.LK_PF005_SQLCODE}");

                /*" -473- DISPLAY '** SQLERRMC.....: ' LK-PF005-SQLERRMC */
                _.Display($"** SQLERRMC.....: {PF0005W.LK_PF005_SQLERRMC}");

                /*" -474- DISPLAY '** SQLSTATE.....: ' LK-PF005-SQLSTATE */
                _.Display($"** SQLSTATE.....: {PF0005W.LK_PF005_SQLSTATE}");

                /*" -475- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -477- END-IF */
            }


            /*" -478- ADD 1 TO AC-GRAVADOS */
            WORK_AREA.DATA_SQL.AC_GRAVADOS.Value = WORK_AREA.DATA_SQL.AC_GRAVADOS + 1;

            /*" -478- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_EXIT*/

        [StopWatch]
        /*" R1900-00-SELECT-PROPOFID-SECTION */
        private void R1900_00_SELECT_PROPOFID_SECTION()
        {
            /*" -490- MOVE 'R1900' TO WNR-EXEC-SQL. */
            _.Move("R1900", WORK_AREA.DATA_SQL.WABEND.WNR_EXEC_SQL);

            /*" -495- MOVE REG-NUM-PROPOSTA TO PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Move(WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -496- IF REG-NUM-PROPOSTA (1:3) EQUAL 001 */

            if (WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_NUM_PROPOSTA.Substring(1, 3) == 001)
            {

                /*" -498- MOVE REG-NUM-PROPOSTA TO WS-NUM-PROPOSTA-DESLOC */
                _.Move(WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_NUM_PROPOSTA, AREA_DE_WORK.WS_NUM_PROPOSTA_DESLOC);

                /*" -500- MOVE WS-NUM-PROPOSTA-DESLOC-13 TO PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Move(AREA_DE_WORK.WS_NUM_PROPOSTA_R.WS_NUM_PROPOSTA_DESLOC_13, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

                /*" -502- END-IF */
            }


            /*" -528- PERFORM R1900_00_SELECT_PROPOFID_DB_SELECT_1 */

            R1900_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -531- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -532- DISPLAY 'NUMERO PROPOSTA ENTRADA = ' REG-NUM-PROPOSTA */
                _.Display($"NUMERO PROPOSTA ENTRADA = {WS_REG_ENTRADA.REG_TIPO_REGISTRO.REG_NUM_PROPOSTA}");

                /*" -533- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.DATA_SQL.WABEND.WSQLCODE);

                /*" -534- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -534- END-IF. */
            }


        }

        [StopWatch]
        /*" R1900-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R1900_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -528- EXEC SQL SELECT NUM_IDENTIFICACAO , SIT_PROPOSTA , CANAL_PROPOSTA , ORIGEM_PROPOSTA , SITUACAO_ENVIO , COD_PRODUTO_SIVPF , SITUACAO_ENVIO , DATA_PROPOSTA , NUM_PROPOSTA_SIVPF, VAL_PAGO INTO :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-SIT-PROPOSTA , :PROPOFID-CANAL-PROPOSTA , :PROPOFID-ORIGEM-PROPOSTA , :PROPOFID-SITUACAO-ENVIO , :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-SITUACAO-ENVIO , :PROPOFID-DATA-PROPOSTA , :PROPOFID-NUM-PROPOSTA-SIVPF, :PROPOFID-VAL-PAGO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R1900_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
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
                _.Move(executed_1.PROPOFID_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -544- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.DATA_SQL.WABEND.WSQLCODE);

            /*" -546- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, WORK_AREA.DATA_SQL.WABEND.WSQLERRMC);

            /*" -548- DISPLAY WABEND */
            _.Display(WORK_AREA.DATA_SQL.WABEND);

            /*" -548- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -550- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -554- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -554- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}