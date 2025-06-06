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
using Sias.Cobranca.DB2.CB6259B;

namespace Code
{
    public class CB6259B
    {
        public bool IsCall { get; set; }

        public CB6259B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB6259B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  RILDO                              *      */
        /*"      *   PROGRAMADOR ............  RILDO                              *      */
        /*"      *   DATA CODIFICACAO .......  09/11/2018                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CONVENIO DE REPASSE FINANCEIRO     *      */
        /*"      *                             CAIXA SEGURADORA - ATM (912014)    *      */
        /*"V.03  *                             CAIXA EXECUTIVO - PRODUTO 8114.    *      */
        /*"V.03  *                             GRAVA RCAP E RCAP COMPLEMENTAR     *      */
        /*"      *                             A PARTIR DA LEITURA DA TABELA      *      */
        /*"      *                             MOVIMENTO COBRANCA COM REGISTROS   *      */
        /*"      *                             GRAVADOS PELO PGM CB6249B PARA OS  *      */
        /*"V.03  *                             PAGAMENTOS QUE TENHAM PROPOSTAS.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - HISTORIA 234486                                  *      */
        /*"      *               AJUSTES ATUALIZACAO CONTROLE DESPESAS CEF.       *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/03/2020 - BRICE HO                                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - HISTORIA 234486                                  *      */
        /*"      *             - DESABILITAR GRAVACAO SEGUROS.AVISO_CREDITO E     *      */
        /*"      *               SEGUROS.AVISOS_SALDOS QUE PASSOU A SER FEITO     *      */
        /*"      *               PELO CB6249B.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/03/2020 - BRICE HO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  CLOVIS 21/03/2019           V.02   *      */
        /*"      *                                                                *      */
        /*"      * OCORR�NCIA DE FALHA N� 173704                                  *      */
        /*"      * R0530-00 - AVISO CREDITO JA CADASTRADO!                        *      */
        /*"      * BCO_AVISO         = 00104                                      *      */
        /*"      * AGE_AVISO         = 08010                                      *      */
        /*"      * NUM_AVISO_CREDITO = 0901403440                                 *      */
        /*"      * CB6259B   *** ERRO  EXEC SQL  NUMERO 0530    SQLCODE = 000     *      */
        /*"      *                 SQLERRD1 =      000    SQLERRD2 =      000     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 00                                                    *      */
        /*"      *             - DEMANDA 169178                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/11/2018 - RILDO                                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public SortBasis<CB6259B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<CB6259B_REG_ARQSORT>(new CB6259B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public CB6259B_REG_ARQSORT REG_ARQSORT { get; set; } = new CB6259B_REG_ARQSORT();
        public class CB6259B_REG_ARQSORT : VarBasis
        {
            /*"  05      SOR-COD-EMPRESA           PIC 9(009).*/
            public IntBasis SOR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SOR-COD-MOVIMENTO         PIC 9(005).*/
            public IntBasis SOR_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05      SOR-COD-PRODUTO           PIC 9(004).*/
            public IntBasis SOR_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-COD-BANCO             PIC 9(004).*/
            public IntBasis SOR_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-COD-AGENCIA           PIC 9(004).*/
            public IntBasis SOR_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-NUM-AVISO             PIC 9(009).*/
            public IntBasis SOR_NUM_AVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SOR-NUM-FITA              PIC 9(009).*/
            public IntBasis SOR_NUM_FITA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SOR-DATA-MOVIMENTO        PIC X(010).*/
            public StringBasis SOR_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SOR-DATA-QUITACAO         PIC X(010).*/
            public StringBasis SOR_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SOR-NUM-TITULO            PIC 9(013).*/
            public IntBasis SOR_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05      SOR-NUM-APOLICE           PIC 9(013).*/
            public IntBasis SOR_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05      SOR-NUM-ENDOSSO           PIC 9(009).*/
            public IntBasis SOR_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SOR-NUM-PARCELA           PIC 9(004).*/
            public IntBasis SOR_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-VAL-TITULO            PIC 9(013)V99.*/
            public DoubleBasis SOR_VAL_TITULO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SOR-VAL-TARIFA            PIC 9(013)V99.*/
            public DoubleBasis SOR_VAL_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SOR-VAL-BALCAO            PIC 9(013)V99.*/
            public DoubleBasis SOR_VAL_BALCAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SOR-VAL-LIQUIDO           PIC 9(013)V99.*/
            public DoubleBasis SOR_VAL_LIQUIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SOR-NUM-NOSSO-TITULO      PIC 9(016).*/
            public IntBasis SOR_NUM_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      SOR-NOME-SEGURADO         PIC X(040).*/
            public StringBasis SOR_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NRAVISO              PIC S9(004)     COMP.*/
        public IntBasis VIND_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL03               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL03 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL04               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL04 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL05               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL05 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL06               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL06 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL07               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL07 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL08               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL08 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL09               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL09 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL10               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL10 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-NRAVISO1           PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis WSHOST_NRAVISO1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WSHOST-NRAVISO2           PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis WSHOST_NRAVISO2 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    WS-CONDESCE-QTD-REGISTROS PIC S9(009)     COMP.*/
        public IntBasis WS_CONDESCE_QTD_REGISTROS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    WS-CONDESCE-PRM-TOTAL     PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WS_CONDESCE_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WS-CONDESCE-PRM-LIQUIDO   PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WS_CONDESCE_PRM_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WS-CONDESCE-VAL-TARIFA    PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WS_CONDESCE_VAL_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WS-CONDESCE-VAL-BALCAO    PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WS_CONDESCE_VAL_BALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WS-CONDESCE-VAL-IOCC      PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WS_CONDESCE_VAL_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WS-CONDESCE-VAL-DESCONTO  PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WS_CONDESCE_VAL_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WS-CONDESCE-VAL-JUROS     PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WS_CONDESCE_VAL_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WS-CONDESCE-VAL-MULTA     PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WS_CONDESCE_VAL_MULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  W.*/
        public CB6259B_W W { get; set; } = new CB6259B_W();
        public class CB6259B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-SORT                 PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-MOVIMCOB               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_MOVIMCOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-SORT                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SORT                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-RCAP                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_RCAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AUX-VALOR                 PIC S9(013)V99      COMP-3.*/
            public DoubleBasis AUX_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  AC-AVISOCRE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_AVISOCRE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-AVISOSAL               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_AVISOSAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-CONDESCE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_CONDESCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  ATU-COD-PRODUTO           PIC  9(004)         VALUE ZEROS.*/
            public IntBasis ATU_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  ANT-COD-PRODUTO           PIC  9(004)         VALUE ZEROS.*/
            public IntBasis ANT_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  AC-DUPLICA                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_DUPLICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-FOLLOWUP               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_FOLLOWUP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         WS-CHAVE-ATU.*/
            public CB6259B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new CB6259B_WS_CHAVE_ATU();
            public class CB6259B_WS_CHAVE_ATU : VarBasis
            {
                /*"    05       ATU-COD-BANCO       PIC  9(004).*/
                public IntBasis ATU_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ATU-COD-AGENCIA     PIC  9(004).*/
                public IntBasis ATU_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ATU-DATA-MOVIMENTO  PIC  X(010).*/
                public StringBasis ATU_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  03         WS-CHAVE-ANT.*/
            }
            public CB6259B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new CB6259B_WS_CHAVE_ANT();
            public class CB6259B_WS_CHAVE_ANT : VarBasis
            {
                /*"    05       ANT-COD-BANCO       PIC  9(004).*/
                public IntBasis ANT_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ANT-COD-AGENCIA     PIC  9(004).*/
                public IntBasis ANT_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ANT-DATA-MOVIMENTO  PIC  X(010).*/
                public StringBasis ANT_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  03         WS-TITULO         PIC  9(011)    VALUE ZEROS.*/
            }
            public IntBasis WS_TITULO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER            REDEFINES      WS-TITULO.*/
            private _REDEF_CB6259B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_CB6259B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_CB6259B_FILLER_0(); _.Move(WS_TITULO, _filler_0); VarBasis.RedefinePassValue(WS_TITULO, _filler_0, WS_TITULO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_TITULO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_TITULO); }
            }  //Redefines
            public class _REDEF_CB6259B_FILLER_0 : VarBasis
            {
                /*"    10       WS-PRETIT         PIC  9(001).*/
                public IntBasis WS_PRETIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WS-NRRCAP         PIC  9(009).*/
                public IntBasis WS_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       WS-DIGTIT         PIC  9(001).*/
                public IntBasis WS_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         AUX-TITULO        PIC  9(014)    VALUE ZEROS.*/

                public _REDEF_CB6259B_FILLER_0()
                {
                    WS_PRETIT.ValueChanged += OnValueChanged;
                    WS_NRRCAP.ValueChanged += OnValueChanged;
                    WS_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AUX_TITULO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER            REDEFINES      AUX-TITULO.*/
            private _REDEF_CB6259B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_CB6259B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_CB6259B_FILLER_1(); _.Move(AUX_TITULO, _filler_1); VarBasis.RedefinePassValue(AUX_TITULO, _filler_1, AUX_TITULO); _filler_1.ValueChanged += () => { _.Move(_filler_1, AUX_TITULO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, AUX_TITULO); }
            }  //Redefines
            public class _REDEF_CB6259B_FILLER_1 : VarBasis
            {
                /*"    10       AUX-CANAL         PIC  9(001).*/
                public IntBasis AUX_CANAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       AUX-AGENCIA       PIC  9(004).*/
                public IntBasis AUX_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       AUX-PRODUTO       PIC  9(002).*/
                public IntBasis AUX_PRODUTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-NRTIT         PIC  9(007).*/
                public IntBasis AUX_NRTIT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_CB6259B_FILLER_1()
                {
                    AUX_CANAL.ValueChanged += OnValueChanged;
                    AUX_AGENCIA.ValueChanged += OnValueChanged;
                    AUX_PRODUTO.ValueChanged += OnValueChanged;
                    AUX_NRTIT.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_CB6259B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_CB6259B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_CB6259B_FILLER_2(); _.Move(WDATA_REL, _filler_2); VarBasis.RedefinePassValue(WDATA_REL, _filler_2, WDATA_REL); _filler_2.ValueChanged += () => { _.Move(_filler_2, WDATA_REL); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB6259B_FILLER_2 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_CB6259B_FILLER_2()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_CB6259B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_CB6259B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_CB6259B_FILLER_5(); _.Move(WTIME_DAY, _filler_5); VarBasis.RedefinePassValue(WTIME_DAY, _filler_5, WTIME_DAY); _filler_5.ValueChanged += () => { _.Move(_filler_5, WTIME_DAY); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_CB6259B_FILLER_5 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public CB6259B_WTIME_DAYR WTIME_DAYR { get; set; } = new CB6259B_WTIME_DAYR();
                public class CB6259B_WTIME_DAYR : VarBasis
                {
                    /*"      10     WTIME-HORA         PIC  9(002).*/
                    public IntBasis WTIME_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      10     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     WTIME-MINU         PIC  9(002).*/
                    public IntBasis WTIME_MINU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      10     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     WTIME-SEGU         PIC  9(002).*/
                    public IntBasis WTIME_SEGU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WTIME-2PT3         PIC  X(001).*/

                    public CB6259B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WTIME-CCSE         PIC  9(002).*/
                public IntBasis WTIME_CCSE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-TIME.*/

                public _REDEF_CB6259B_FILLER_5()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public CB6259B_WS_TIME WS_TIME { get; set; } = new CB6259B_WS_TIME();
            public class CB6259B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WABEND.*/
            }
            public CB6259B_WABEND WABEND { get; set; } = new CB6259B_WABEND();
            public class CB6259B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' CB6259B  '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CB6259B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LD99-ABEND.*/
            }
        }
        public CB6259B_LD99_ABEND LD99_ABEND { get; set; } = new CB6259B_LD99_ABEND();
        public class CB6259B_LD99_ABEND : VarBasis
        {
            /*"      10    FILLER              PIC  X(050) VALUE           ' REINICIAR JOB NO PROXIMO STEP               '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" REINICIAR JOB NO PROXIMO STEP               ");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.FOLLOUP FOLLOUP { get; set; } = new Dclgens.FOLLOUP();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.AVISOCRE AVISOCRE { get; set; } = new Dclgens.AVISOCRE();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
        public Dclgens.CONDESCE CONDESCE { get; set; } = new Dclgens.CONDESCE();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.BILHECOB BILHECOB { get; set; } = new Dclgens.BILHECOB();
        public CB6259B_V0MOVIMCOB V0MOVIMCOB { get; set; } = new CB6259B_V0MOVIMCOB();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);

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
            /*" -254- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -255- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -257- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -259- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -262- DISPLAY '--------------------------------------' */
            _.Display($"--------------------------------------");

            /*" -263- DISPLAY 'PROGRAMA EM EXECUCAO CB6259B          ' */
            _.Display($"PROGRAMA EM EXECUCAO CB6259B          ");

            /*" -264- DISPLAY '                                      ' */
            _.Display($"                                      ");

            /*" -265- DISPLAY 'COMPILADO EM : ' FUNCTION WHEN-COMPILED */

            $"COMPILADO EM : FUNCTION{_.WhenCompiled()}"
            .Display();

            /*" -266- DISPLAY '                                      ' */
            _.Display($"                                      ");

            /*" -269- DISPLAY 'VERSAO V.04 - HIST 234486 - 27/03/2020' */
            _.Display($"VERSAO V.04 - HIST 234486 - 27/03/2020");

            /*" -271- DISPLAY '--------------------------------------' */
            _.Display($"--------------------------------------");

            /*" -274- PERFORM R0050-00-INICIO */

            R0050_00_INICIO_SECTION();

            /*" -286- SORT ARQSORT ON ASCENDING KEY SOR-COD-BANCO SOR-COD-AGENCIA SOR-DATA-MOVIMENTO SOR-COD-PRODUTO INPUT PROCEDURE R0200-00-INPUT-SORT THRU R0200-99-SAIDA OUTPUT PROCEDURE R0450-00-OUTPUT-SORT THRU R0450-99-SAIDA . */
            ARQSORT.Sort("SOR-COD-BANCO,SOR-COD-AGENCIA,SOR-DATA-MOVIMENTO,SOR-COD-PRODUTO", () => R0200_00_INPUT_SORT_SECTION(), () => R0450_00_OUTPUT_SORT_SECTION());

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -290- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -294- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -296- DISPLAY 'CB6259B - FIM NORMAL' */
            _.Display($"CB6259B - FIM NORMAL");

            /*" -296- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -309- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", W.WABEND.WNR_EXEC_SQL);

            /*" -312- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -314- DISPLAY 'DATA DO PROCESSAMENTO ...............  ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DO PROCESSAMENTO ...............  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -315- DISPLAY ' ' . */
            _.Display($" ");

            /*" -316- DISPLAY 'CONVENIO FINANCEIRO ATM 912014 - MOVIMCOB' */
            _.Display($"CONVENIO FINANCEIRO ATM 912014 - MOVIMCOB");

            /*" -319- DISPLAY ' ' . */
            _.Display($" ");

            /*" -319- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -332- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -338- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -341- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -342- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -345- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -346- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -338- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-INPUT-SORT-SECTION */
        private void R0200_00_INPUT_SORT_SECTION()
        {
            /*" -359- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", W.WABEND.WNR_EXEC_SQL);

            /*" -360- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -362- PERFORM R0300-00-DECLARE-MOVIMCOB. */

            R0300_00_DECLARE_MOVIMCOB_SECTION();

            /*" -364- PERFORM R0310-00-FETCH-MOVIMCOB. */

            R0310_00_FETCH_MOVIMCOB_SECTION();

            /*" -368- PERFORM R0350-00-PROCESSA-MOVIMCOB UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_MOVIMCOB_SECTION();
            }

            /*" -369- DISPLAY ' ' . */
            _.Display($" ");

            /*" -370- DISPLAY 'LIDOS MOVIMCOB ............. ' LD-MOVIMCOB. */
            _.Display($"LIDOS MOVIMCOB ............. {W.LD_MOVIMCOB}");

            /*" -373- DISPLAY 'GRAVADOS SORT .............. ' GV-SORT. */
            _.Display($"GRAVADOS SORT .............. {W.GV_SORT}");

            /*" -373- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-SECTION */
        private void R0300_00_DECLARE_MOVIMCOB_SECTION()
        {
            /*" -386- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -412- PERFORM R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1 */

            R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1();

            /*" -414- PERFORM R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1 */

            R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1();

            /*" -418- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -419- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (MOVIMCOB)   ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (MOVIMCOB)   ");

                /*" -419- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-DB-DECLARE-1 */
        public void R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1()
        {
            /*" -412- EXEC SQL DECLARE V0MOVIMCOB CURSOR WITH HOLD FOR SELECT MC.COD_EMPRESA , MC.COD_MOVIMENTO , MC.COD_BANCO , MC.COD_AGENCIA , MC.NUM_AVISO , MC.NUM_FITA , MC.DATA_MOVIMENTO , MC.DATA_QUITACAO , MC.NUM_TITULO , MC.NUM_APOLICE , MC.NUM_ENDOSSO , MC.NUM_PARCELA , MC.VAL_TITULO , MC.VAL_IOCC , MC.VAL_CREDITO , MC.NOME_SEGURADO , MC.NUM_NOSSO_TITULO , CS.NUM_SICOB FROM SEGUROS.MOVIMENTO_COBRANCA MC JOIN SEGUROS.CONVERSAO_SICOB CS ON CS.NUM_PROPOSTA_SIVPF = MC.NUM_NOSSO_TITULO WHERE MC.SIT_REGISTRO = ' ' AND MC.TIPO_MOVIMENTO = 'G' AND MC.DATA_MOVIMENTO <= :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */
            V0MOVIMCOB = new CB6259B_V0MOVIMCOB(true);
            string GetQuery_V0MOVIMCOB()
            {
                var query = @$"SELECT MC.COD_EMPRESA 
							, MC.COD_MOVIMENTO 
							, MC.COD_BANCO 
							, MC.COD_AGENCIA 
							, MC.NUM_AVISO 
							, MC.NUM_FITA 
							, MC.DATA_MOVIMENTO 
							, MC.DATA_QUITACAO 
							, MC.NUM_TITULO 
							, MC.NUM_APOLICE 
							, MC.NUM_ENDOSSO 
							, MC.NUM_PARCELA 
							, MC.VAL_TITULO 
							, MC.VAL_IOCC 
							, MC.VAL_CREDITO 
							, MC.NOME_SEGURADO 
							, MC.NUM_NOSSO_TITULO 
							, CS.NUM_SICOB 
							FROM SEGUROS.MOVIMENTO_COBRANCA MC 
							JOIN SEGUROS.CONVERSAO_SICOB CS 
							ON CS.NUM_PROPOSTA_SIVPF = MC.NUM_NOSSO_TITULO 
							WHERE MC.SIT_REGISTRO = ' ' 
							AND MC.TIPO_MOVIMENTO = 'G' 
							AND MC.DATA_MOVIMENTO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}'";

                return query;
            }
            V0MOVIMCOB.GetQueryEvent += GetQuery_V0MOVIMCOB;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-DB-OPEN-1 */
        public void R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1()
        {
            /*" -414- EXEC SQL OPEN V0MOVIMCOB END-EXEC. */

            V0MOVIMCOB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-SECTION */
        private void R0310_00_FETCH_MOVIMCOB_SECTION()
        {
            /*" -432- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.WABEND.WNR_EXEC_SQL);

            /*" -451- PERFORM R0310_00_FETCH_MOVIMCOB_DB_FETCH_1 */

            R0310_00_FETCH_MOVIMCOB_DB_FETCH_1();

            /*" -455- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -455- PERFORM R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1 */

                R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1();

                /*" -457- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -459- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -460- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -461- DISPLAY 'R0310-00 - PROBLEMAS FETCH   (MOVIMCOB)   ' */
                _.Display($"R0310-00 - PROBLEMAS FETCH   (MOVIMCOB)   ");

                /*" -464- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -464- ADD 1 TO LD-MOVIMCOB. */
            W.LD_MOVIMCOB.Value = W.LD_MOVIMCOB + 1;

        }

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-DB-FETCH-1 */
        public void R0310_00_FETCH_MOVIMCOB_DB_FETCH_1()
        {
            /*" -451- EXEC SQL FETCH V0MOVIMCOB INTO :MOVIMCOB-COD-EMPRESA , :MOVIMCOB-COD-MOVIMENTO , :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-NUM-FITA , :MOVIMCOB-DATA-MOVIMENTO , :MOVIMCOB-DATA-QUITACAO , :MOVIMCOB-NUM-TITULO , :MOVIMCOB-NUM-APOLICE , :MOVIMCOB-NUM-ENDOSSO , :MOVIMCOB-NUM-PARCELA , :MOVIMCOB-VAL-TITULO , :MOVIMCOB-VAL-IOCC , :MOVIMCOB-VAL-CREDITO , :MOVIMCOB-NOME-SEGURADO , :MOVIMCOB-NUM-NOSSO-TITULO , :CONVERSI-NUM-SICOB END-EXEC. */

            if (V0MOVIMCOB.Fetch())
            {
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_EMPRESA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA);
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_BANCO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_AGENCIA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_AVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_FITA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA);
                _.Move(V0MOVIMCOB.MOVIMCOB_DATA_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);
                _.Move(V0MOVIMCOB.MOVIMCOB_DATA_QUITACAO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);
                _.Move(V0MOVIMCOB.MOVIMCOB_VAL_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);
                _.Move(V0MOVIMCOB.MOVIMCOB_VAL_IOCC, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC);
                _.Move(V0MOVIMCOB.MOVIMCOB_VAL_CREDITO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NOME_SEGURADO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_NOSSO_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);
                _.Move(V0MOVIMCOB.CONVERSI_NUM_SICOB, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-DB-CLOSE-1 */
        public void R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1()
        {
            /*" -455- EXEC SQL CLOSE V0MOVIMCOB END-EXEC */

            V0MOVIMCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-MOVIMCOB-SECTION */
        private void R0350_00_PROCESSA_MOVIMCOB_SECTION()
        {
            /*" -477- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", W.WABEND.WNR_EXEC_SQL);

            /*" -479- MOVE MOVIMCOB-COD-EMPRESA TO SOR-COD-EMPRESA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA, REG_ARQSORT.SOR_COD_EMPRESA);

            /*" -481- MOVE MOVIMCOB-COD-MOVIMENTO TO SOR-COD-MOVIMENTO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO, REG_ARQSORT.SOR_COD_MOVIMENTO);

            /*" -483- MOVE MOVIMCOB-COD-BANCO TO SOR-COD-BANCO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO, REG_ARQSORT.SOR_COD_BANCO);

            /*" -485- MOVE MOVIMCOB-COD-AGENCIA TO SOR-COD-AGENCIA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA, REG_ARQSORT.SOR_COD_AGENCIA);

            /*" -487- MOVE MOVIMCOB-NUM-AVISO TO SOR-NUM-AVISO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, REG_ARQSORT.SOR_NUM_AVISO);

            /*" -489- MOVE MOVIMCOB-NUM-FITA TO SOR-NUM-FITA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA, REG_ARQSORT.SOR_NUM_FITA);

            /*" -491- MOVE MOVIMCOB-DATA-MOVIMENTO TO SOR-DATA-MOVIMENTO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO, REG_ARQSORT.SOR_DATA_MOVIMENTO);

            /*" -493- MOVE MOVIMCOB-DATA-QUITACAO TO SOR-DATA-QUITACAO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, REG_ARQSORT.SOR_DATA_QUITACAO);

            /*" -496- MOVE CONVERSI-NUM-SICOB TO SOR-NUM-TITULO. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB, REG_ARQSORT.SOR_NUM_TITULO);

            /*" -498- MOVE MOVIMCOB-NUM-APOLICE TO SOR-NUM-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, REG_ARQSORT.SOR_NUM_APOLICE);

            /*" -500- MOVE MOVIMCOB-NUM-ENDOSSO TO SOR-NUM-ENDOSSO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, REG_ARQSORT.SOR_NUM_ENDOSSO);

            /*" -502- MOVE MOVIMCOB-NUM-PARCELA TO SOR-NUM-PARCELA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, REG_ARQSORT.SOR_NUM_PARCELA);

            /*" -504- MOVE MOVIMCOB-VAL-TITULO TO SOR-VAL-TITULO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, REG_ARQSORT.SOR_VAL_TITULO);

            /*" -506- MOVE MOVIMCOB-VAL-IOCC TO SOR-VAL-BALCAO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC, REG_ARQSORT.SOR_VAL_BALCAO);

            /*" -508- MOVE MOVIMCOB-VAL-CREDITO TO SOR-VAL-LIQUIDO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO, REG_ARQSORT.SOR_VAL_LIQUIDO);

            /*" -510- MOVE MOVIMCOB-NOME-SEGURADO TO SOR-NOME-SEGURADO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO, REG_ARQSORT.SOR_NOME_SEGURADO);

            /*" -513- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO SOR-NUM-NOSSO-TITULO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, REG_ARQSORT.SOR_NUM_NOSSO_TITULO);

            /*" -516- COMPUTE AUX-VALOR EQUAL (SOR-VAL-TITULO - SOR-VAL-LIQUIDO - SOR-VAL-BALCAO). */
            W.AUX_VALOR.Value = (REG_ARQSORT.SOR_VAL_TITULO - REG_ARQSORT.SOR_VAL_LIQUIDO - REG_ARQSORT.SOR_VAL_BALCAO);

            /*" -520- MOVE AUX-VALOR TO SOR-VAL-TARIFA. */
            _.Move(W.AUX_VALOR, REG_ARQSORT.SOR_VAL_TARIFA);

            /*" -522- PERFORM R0360-00-SELECT-V0BILHETE. */

            R0360_00_SELECT_V0BILHETE_SECTION();

            /*" -526- MOVE BILHECOB-COD-PRODUTO TO SOR-COD-PRODUTO. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO, REG_ARQSORT.SOR_COD_PRODUTO);

            /*" -527- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -527- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -532- PERFORM R0310-00-FETCH-MOVIMCOB. */

            R0310_00_FETCH_MOVIMCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0360-00-SELECT-V0BILHETE-SECTION */
        private void R0360_00_SELECT_V0BILHETE_SECTION()
        {
            /*" -544- MOVE '0360' TO WNR-EXEC-SQL. */
            _.Move("0360", W.WABEND.WNR_EXEC_SQL);

            /*" -555- PERFORM R0360_00_SELECT_V0BILHETE_DB_SELECT_1 */

            R0360_00_SELECT_V0BILHETE_DB_SELECT_1();

            /*" -558- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -560- MOVE ZEROS TO BILHECOB-COD-PRODUTO */
                _.Move(0, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

                /*" -561- ELSE */
            }
            else
            {


                /*" -562- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -563- DISPLAY 'R0360-00 - PROBLEMAS NO SELECT(BILHETE)' */
                    _.Display($"R0360-00 - PROBLEMAS NO SELECT(BILHETE)");

                    /*" -563- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0360-00-SELECT-V0BILHETE-DB-SELECT-1 */
        public void R0360_00_SELECT_V0BILHETE_DB_SELECT_1()
        {
            /*" -555- EXEC SQL SELECT B.COD_PRODUTO INTO :BILHECOB-COD-PRODUTO FROM SEGUROS.BILHETE A ,SEGUROS.BILHETE_PLANCOBER B WHERE A.NUM_BILHETE = :CONVERSI-NUM-SICOB AND B.COD_EMPRESA = 0 AND B.RAMO_COBERTURA = A.RAMO AND B.COD_OPCAO_PLANO = A.OPC_COBERTURA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1 = new R0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1()
            {
                CONVERSI_NUM_SICOB = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB.ToString(),
            };

            var executed_1 = R0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1.Execute(r0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHECOB_COD_PRODUTO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-OUTPUT-SORT-SECTION */
        private void R0450_00_OUTPUT_SORT_SECTION()
        {
            /*" -576- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", W.WABEND.WNR_EXEC_SQL);

            /*" -577- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -579- PERFORM R0500-00-LE-ARQSORT. */

            R0500_00_LE_ARQSORT_SECTION();

            /*" -580- IF WFIM-SORT NOT EQUAL SPACES */

            if (!W.WFIM_SORT.IsEmpty())
            {

                /*" -581- CONTINUE */

                /*" -582- ELSE */
            }
            else
            {


                /*" -586- PERFORM R0510-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

                while (!(!W.WFIM_SORT.IsEmpty()))
                {

                    R0510_00_PROCESSA_SORT_SECTION();
                }
            }


            /*" -587- DISPLAY ' ' */
            _.Display($" ");

            /*" -588- DISPLAY 'LIDOS SORT ................. ' LD-SORT */
            _.Display($"LIDOS SORT ................. {W.LD_SORT}");

            /*" -589- DISPLAY 'GRAVADOS  RCAP ............. ' GV-RCAP */
            _.Display($"GRAVADOS  RCAP ............. {W.GV_RCAP}");

            /*" -590- DISPLAY 'INCLUIDOS CONDESCE ......... ' AC-CONDESCE */
            _.Display($"INCLUIDOS CONDESCE ......... {W.AC_CONDESCE}");

            /*" -591- DISPLAY 'INCLUIDOS FOLLOW-UP......... ' AC-FOLLOWUP */
            _.Display($"INCLUIDOS FOLLOW-UP......... {W.AC_FOLLOWUP}");

            /*" -591- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-LE-ARQSORT-SECTION */
        private void R0500_00_LE_ARQSORT_SECTION()
        {
            /*" -604- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", W.WABEND.WNR_EXEC_SQL);

            /*" -606- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -607- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -612- MOVE ZEROS TO ATU-COD-BANCO ATU-COD-AGENCIA ATU-DATA-MOVIMENTO ATU-COD-PRODUTO */
                    _.Move(0, W.WS_CHAVE_ATU.ATU_COD_BANCO, W.WS_CHAVE_ATU.ATU_COD_AGENCIA, W.WS_CHAVE_ATU.ATU_DATA_MOVIMENTO, W.ATU_COD_PRODUTO);

                    /*" -615- GO TO R0500-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -617- MOVE SOR-COD-BANCO TO ATU-COD-BANCO. */
            _.Move(REG_ARQSORT.SOR_COD_BANCO, W.WS_CHAVE_ATU.ATU_COD_BANCO);

            /*" -619- MOVE SOR-COD-AGENCIA TO ATU-COD-AGENCIA. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, W.WS_CHAVE_ATU.ATU_COD_AGENCIA);

            /*" -621- MOVE SOR-DATA-MOVIMENTO TO ATU-DATA-MOVIMENTO. */
            _.Move(REG_ARQSORT.SOR_DATA_MOVIMENTO, W.WS_CHAVE_ATU.ATU_DATA_MOVIMENTO);

            /*" -625- MOVE SOR-COD-PRODUTO TO ATU-COD-PRODUTO. */
            _.Move(REG_ARQSORT.SOR_COD_PRODUTO, W.ATU_COD_PRODUTO);

            /*" -625- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-PROCESSA-SORT-SECTION */
        private void R0510_00_PROCESSA_SORT_SECTION()
        {
            /*" -637- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", W.WABEND.WNR_EXEC_SQL);

            /*" -639- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT. */
            _.Move(W.WS_CHAVE_ATU, W.WS_CHAVE_ANT);

            /*" -641- PERFORM R0550-00-PROCESSA-CONDESCE UNTIL WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.WS_CHAVE_ATU != W.WS_CHAVE_ANT || !W.WFIM_SORT.IsEmpty()))
            {

                R0550_00_PROCESSA_CONDESCE_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-PROCESSA-CONDESCE-SECTION */
        private void R0550_00_PROCESSA_CONDESCE_SECTION()
        {
            /*" -652- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", W.WABEND.WNR_EXEC_SQL);

            /*" -654- PERFORM R0560-00-MONTA-CONDESCE. */

            R0560_00_MONTA_CONDESCE_SECTION();

            /*" -656- MOVE ATU-COD-PRODUTO TO ANT-COD-PRODUTO. */
            _.Move(W.ATU_COD_PRODUTO, W.ANT_COD_PRODUTO);

            /*" -661- PERFORM R0600-00-PROCESSA-REGISTRO UNTIL ATU-COD-PRODUTO NOT EQUAL ANT-COD-PRODUTO OR WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.ATU_COD_PRODUTO != W.ANT_COD_PRODUTO || W.WS_CHAVE_ATU != W.WS_CHAVE_ANT || !W.WFIM_SORT.IsEmpty()))
            {

                R0600_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -662- IF WS-CONDESCE-PRM-TOTAL GREATER ZEROS */

            if (WS_CONDESCE_PRM_TOTAL > 00)
            {

                /*" -662- PERFORM R5000-00-TRATAR-CONDESCE. */

                R5000_00_TRATAR_CONDESCE_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0560-00-MONTA-CONDESCE-SECTION */
        private void R0560_00_MONTA_CONDESCE_SECTION()
        {
            /*" -678- MOVE '0560' TO WNR-EXEC-SQL. */
            _.Move("0560", W.WABEND.WNR_EXEC_SQL);

            /*" -681- MOVE ZEROS TO CONDESCE-COD-EMPRESA. */
            _.Move(0, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_EMPRESA);

            /*" -684- MOVE SOR-DATA-MOVIMENTO TO WDATA-REL. */
            _.Move(REG_ARQSORT.SOR_DATA_MOVIMENTO, W.WDATA_REL);

            /*" -686- MOVE WDAT-REL-ANO TO CONDESCE-ANO-REFERENCIA. */
            _.Move(W.FILLER_2.WDAT_REL_ANO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_ANO_REFERENCIA);

            /*" -689- MOVE WDAT-REL-MES TO CONDESCE-MES-REFERENCIA. */
            _.Move(W.FILLER_2.WDAT_REL_MES, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_MES_REFERENCIA);

            /*" -692- MOVE SOR-COD-BANCO TO CONDESCE-BCO-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_BANCO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO);

            /*" -695- MOVE SOR-COD-AGENCIA TO CONDESCE-AGE-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO);

            /*" -698- MOVE SOR-NUM-AVISO TO CONDESCE-NUM-AVISO-CREDITO. */
            _.Move(REG_ARQSORT.SOR_NUM_AVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO);

            /*" -700- MOVE ATU-COD-PRODUTO TO CONDESCE-COD-PRODUTO. */
            _.Move(W.ATU_COD_PRODUTO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO);

            /*" -702- MOVE 'A' TO CONDESCE-TIPO-REGISTRO. */
            _.Move("A", CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_REGISTRO);

            /*" -704- MOVE '0' TO CONDESCE-SITUACAO. */
            _.Move("0", CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_SITUACAO);

            /*" -706- MOVE '0' TO CONDESCE-TIPO-COBRANCA. */
            _.Move("0", CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_COBRANCA);

            /*" -709- MOVE SISTEMAS-DATA-MOV-ABERTO TO CONDESCE-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_MOVIMENTO);

            /*" -712- MOVE SOR-DATA-MOVIMENTO TO CONDESCE-DATA-AVISO. */
            _.Move(REG_ARQSORT.SOR_DATA_MOVIMENTO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_AVISO);

            /*" -721- MOVE ZEROS TO WS-CONDESCE-QTD-REGISTROS WS-CONDESCE-PRM-TOTAL WS-CONDESCE-PRM-LIQUIDO WS-CONDESCE-VAL-TARIFA WS-CONDESCE-VAL-BALCAO WS-CONDESCE-VAL-IOCC WS-CONDESCE-VAL-DESCONTO WS-CONDESCE-VAL-JUROS WS-CONDESCE-VAL-MULTA. */
            _.Move(0, WS_CONDESCE_QTD_REGISTROS, WS_CONDESCE_PRM_TOTAL, WS_CONDESCE_PRM_LIQUIDO, WS_CONDESCE_VAL_TARIFA, WS_CONDESCE_VAL_BALCAO, WS_CONDESCE_VAL_IOCC, WS_CONDESCE_VAL_DESCONTO, WS_CONDESCE_VAL_JUROS, WS_CONDESCE_VAL_MULTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-PROCESSA-REGISTRO-SECTION */
        private void R0600_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -732- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", W.WABEND.WNR_EXEC_SQL);

            /*" -734- ADD 1 TO WS-CONDESCE-QTD-REGISTROS */
            WS_CONDESCE_QTD_REGISTROS.Value = WS_CONDESCE_QTD_REGISTROS + 1;

            /*" -736- ADD SOR-VAL-TITULO TO WS-CONDESCE-PRM-TOTAL. */
            WS_CONDESCE_PRM_TOTAL.Value = WS_CONDESCE_PRM_TOTAL + REG_ARQSORT.SOR_VAL_TITULO;

            /*" -738- ADD SOR-VAL-TARIFA TO WS-CONDESCE-VAL-TARIFA. */
            WS_CONDESCE_VAL_TARIFA.Value = WS_CONDESCE_VAL_TARIFA + REG_ARQSORT.SOR_VAL_TARIFA;

            /*" -740- ADD SOR-VAL-BALCAO TO WS-CONDESCE-VAL-BALCAO. */
            WS_CONDESCE_VAL_BALCAO.Value = WS_CONDESCE_VAL_BALCAO + REG_ARQSORT.SOR_VAL_BALCAO;

            /*" -743- ADD SOR-VAL-LIQUIDO TO WS-CONDESCE-PRM-LIQUIDO. */
            WS_CONDESCE_PRM_LIQUIDO.Value = WS_CONDESCE_PRM_LIQUIDO + REG_ARQSORT.SOR_VAL_LIQUIDO;

            /*" -745- PERFORM R0700-00-SELECT-V0RCAP. */

            R0700_00_SELECT_V0RCAP_SECTION();

            /*" -746- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -747- PERFORM R4000-00-TRATA-FOLLOWUP */

                R4000_00_TRATA_FOLLOWUP_SECTION();

                /*" -749- MOVE '2' TO MOVIMCOB-SIT-REGISTRO */
                _.Move("2", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

                /*" -751- MOVE 'TITULO DUPLICADO RCAP' TO MOVIMCOB-NOME-SEGURADO */
                _.Move("TITULO DUPLICADO RCAP", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);

                /*" -752- ELSE */
            }
            else
            {


                /*" -753- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -754- PERFORM R1000-00-MONTA-RCAP */

                    R1000_00_MONTA_RCAP_SECTION();

                    /*" -756- MOVE '1' TO MOVIMCOB-SIT-REGISTRO */
                    _.Move("1", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

                    /*" -757- ELSE */
                }
                else
                {


                    /*" -759- DISPLAY 'R0700-00 - PROBLEMAS NO SELECT(RCAPS)   ' SOR-NUM-TITULO */
                    _.Display($"R0700-00 - PROBLEMAS NO SELECT(RCAPS)   {REG_ARQSORT.SOR_NUM_TITULO}");

                    /*" -761- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -763- MOVE SOR-COD-BANCO TO MOVIMCOB-COD-BANCO. */
            _.Move(REG_ARQSORT.SOR_COD_BANCO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);

            /*" -766- MOVE SOR-COD-AGENCIA TO MOVIMCOB-COD-AGENCIA. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);

            /*" -769- MOVE SOR-NUM-AVISO TO MOVIMCOB-NUM-AVISO. */
            _.Move(REG_ARQSORT.SOR_NUM_AVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);

            /*" -771- MOVE SOR-NUM-FITA TO MOVIMCOB-NUM-FITA. */
            _.Move(REG_ARQSORT.SOR_NUM_FITA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA);

            /*" -773- MOVE SOR-NUM-TITULO TO MOVIMCOB-NUM-TITULO. */
            _.Move(REG_ARQSORT.SOR_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);

            /*" -775- MOVE SOR-NUM-NOSSO-TITULO TO MOVIMCOB-NUM-NOSSO-TITULO. */
            _.Move(REG_ARQSORT.SOR_NUM_NOSSO_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

            /*" -778- MOVE SOR-COD-MOVIMENTO TO MOVIMCOB-COD-MOVIMENTO. */
            _.Move(REG_ARQSORT.SOR_COD_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);

            /*" -778- PERFORM R4200-00-UPDATE-V0MOVICOB. */

            R4200_00_UPDATE_V0MOVICOB_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0600_90_LEITURA */

            R0600_90_LEITURA();

        }

        [StopWatch]
        /*" R0600-90-LEITURA */
        private void R0600_90_LEITURA(bool isPerform = false)
        {
            /*" -783- PERFORM R0500-00-LE-ARQSORT. */

            R0500_00_LE_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-SELECT-V0RCAP-SECTION */
        private void R0700_00_SELECT_V0RCAP_SECTION()
        {
            /*" -794- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", W.WABEND.WNR_EXEC_SQL);

            /*" -797- MOVE SOR-NUM-NOSSO-TITULO TO RCAPS-NUM-CERTIFICADO. */
            _.Move(REG_ARQSORT.SOR_NUM_NOSSO_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -804- PERFORM R0700_00_SELECT_V0RCAP_DB_SELECT_1 */

            R0700_00_SELECT_V0RCAP_DB_SELECT_1();

        }

        [StopWatch]
        /*" R0700-00-SELECT-V0RCAP-DB-SELECT-1 */
        public void R0700_00_SELECT_V0RCAP_DB_SELECT_1()
        {
            /*" -804- EXEC SQL SELECT NUM_RCAP INTO :RCAPS-NUM-RCAP FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0700_00_SELECT_V0RCAP_DB_SELECT_1_Query1 = new R0700_00_SELECT_V0RCAP_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0700_00_SELECT_V0RCAP_DB_SELECT_1_Query1.Execute(r0700_00_SELECT_V0RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-MONTA-RCAP-SECTION */
        private void R1000_00_MONTA_RCAP_SECTION()
        {
            /*" -821- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", W.WABEND.WNR_EXEC_SQL);

            /*" -825- MOVE SOR-NUM-NOSSO-TITULO TO RCAPS-NUM-CERTIFICADO AUX-TITULO. */
            _.Move(REG_ARQSORT.SOR_NUM_NOSSO_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO, W.AUX_TITULO);

            /*" -829- MOVE SOR-NUM-TITULO TO RCAPS-NUM-TITULO WS-TITULO. */
            _.Move(REG_ARQSORT.SOR_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO, W.WS_TITULO);

            /*" -831- MOVE AUX-AGENCIA TO AGENCCEF-COD-AGENCIA. */
            _.Move(W.FILLER_1.AUX_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);

            /*" -833- PERFORM R1100-00-SELECT-AGENCIAS. */

            R1100_00_SELECT_AGENCIAS_SECTION();

            /*" -835- MOVE MALHACEF-COD-FONTE TO RCAPS-COD-FONTE. */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);

            /*" -837- MOVE WS-NRRCAP TO RCAPS-NUM-RCAP. */
            _.Move(W.FILLER_0.WS_NRRCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);

            /*" -839- MOVE ZEROS TO RCAPS-NUM-PROPOSTA. */
            _.Move(0, RCAPS.DCLRCAPS.RCAPS_NUM_PROPOSTA);

            /*" -841- MOVE SPACES TO RCAPS-NOME-SEGURADO. */
            _.Move("", RCAPS.DCLRCAPS.RCAPS_NOME_SEGURADO);

            /*" -843- MOVE SOR-VAL-TITULO TO RCAPS-VAL-RCAP. */
            _.Move(REG_ARQSORT.SOR_VAL_TITULO, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);

            /*" -845- MOVE SOR-VAL-TITULO TO RCAPS-VAL-RCAP-PRINCIPAL. */
            _.Move(REG_ARQSORT.SOR_VAL_TITULO, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL);

            /*" -847- MOVE SOR-DATA-MOVIMENTO TO RCAPS-DATA-CADASTRAMENTO. */
            _.Move(REG_ARQSORT.SOR_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);

            /*" -849- MOVE SISTEMAS-DATA-MOV-ABERTO TO RCAPS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);

            /*" -851- MOVE '0' TO RCAPS-SIT-REGISTRO. */
            _.Move("0", RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);

            /*" -853- MOVE 110 TO RCAPS-COD-OPERACAO. */
            _.Move(110, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);

            /*" -858- MOVE ZEROS TO RCAPS-COD-EMPRESA RCAPS-NUM-APOLICE RCAPS-NUM-ENDOSSO RCAPS-NUM-PARCELA. */
            _.Move(0, RCAPS.DCLRCAPS.RCAPS_COD_EMPRESA, RCAPS.DCLRCAPS.RCAPS_NUM_APOLICE, RCAPS.DCLRCAPS.RCAPS_NUM_ENDOSSO, RCAPS.DCLRCAPS.RCAPS_NUM_PARCELA);

            /*" -860- MOVE SOR-COD-PRODUTO TO RCAPS-CODIGO-PRODUTO. */
            _.Move(REG_ARQSORT.SOR_COD_PRODUTO, RCAPS.DCLRCAPS.RCAPS_CODIGO_PRODUTO);

            /*" -862- MOVE AUX-AGENCIA TO RCAPS-AGE-COBRANCA. */
            _.Move(W.FILLER_1.AUX_AGENCIA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);

            /*" -864- MOVE SPACES TO RCAPS-RECUPERA. */
            _.Move("", RCAPS.DCLRCAPS.RCAPS_RECUPERA);

            /*" -868- MOVE ZEROS TO RCAPS-VLACRESCIMO. */
            _.Move(0, RCAPS.DCLRCAPS.RCAPS_VLACRESCIMO);

            /*" -879- MOVE ZEROS TO VIND-NULL01 VIND-NULL02 VIND-NULL03 VIND-NULL04 VIND-NULL05 VIND-NULL06 VIND-NULL07 VIND-NULL08 VIND-NULL09 VIND-NULL10. */
            _.Move(0, VIND_NULL01, VIND_NULL02, VIND_NULL03, VIND_NULL04, VIND_NULL05, VIND_NULL06, VIND_NULL07, VIND_NULL08, VIND_NULL09, VIND_NULL10);

            /*" -885- PERFORM R1310-00-INSERT-RCAPS. */

            R1310_00_INSERT_RCAPS_SECTION();

            /*" -887- MOVE RCAPS-COD-FONTE TO RCAPCOMP-COD-FONTE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_COD_FONTE, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE);

            /*" -889- MOVE RCAPS-NUM-RCAP TO RCAPCOMP-NUM-RCAP. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);

            /*" -891- MOVE ZEROS TO RCAPCOMP-NUM-RCAP-COMPLEMEN. */
            _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN);

            /*" -893- MOVE SISTEMAS-DATA-MOV-ABERTO TO RCAPCOMP-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);

            /*" -895- MOVE SOR-COD-BANCO TO RCAPCOMP-BCO-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_BANCO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);

            /*" -898- MOVE SOR-COD-AGENCIA TO RCAPCOMP-AGE-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);

            /*" -901- MOVE SOR-NUM-AVISO TO RCAPCOMP-NUM-AVISO-CREDITO. */
            _.Move(REG_ARQSORT.SOR_NUM_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);

            /*" -903- MOVE RCAPS-VAL-RCAP TO RCAPCOMP-VAL-RCAP. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);

            /*" -905- MOVE SOR-DATA-QUITACAO TO RCAPCOMP-DATA-RCAP. */
            _.Move(REG_ARQSORT.SOR_DATA_QUITACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);

            /*" -907- MOVE RCAPS-DATA-CADASTRAMENTO TO RCAPCOMP-DATA-CADASTRAMENTO. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO);

            /*" -909- MOVE '0' TO RCAPCOMP-SIT-CONTABIL. */
            _.Move("0", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL);

            /*" -912- MOVE RCAPS-COD-EMPRESA TO RCAPCOMP-COD-EMPRESA. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_COD_EMPRESA, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);

            /*" -914- MOVE ZEROS TO VIND-NULL01. */
            _.Move(0, VIND_NULL01);

            /*" -916- MOVE 110 TO RCAPCOMP-COD-OPERACAO. */
            _.Move(110, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);

            /*" -919- MOVE '0' TO RCAPCOMP-SIT-REGISTRO. */
            _.Move("0", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO);

            /*" -922- PERFORM R1320-00-INSERT-RCAPCOMP. */

            R1320_00_INSERT_RCAPCOMP_SECTION();

            /*" -922- ADD 1 TO GV-RCAP. */
            W.GV_RCAP.Value = W.GV_RCAP + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-AGENCIAS-SECTION */
        private void R1100_00_SELECT_AGENCIAS_SECTION()
        {
            /*" -935- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", W.WABEND.WNR_EXEC_SQL);

            /*" -945- PERFORM R1100_00_SELECT_AGENCIAS_DB_SELECT_1 */

            R1100_00_SELECT_AGENCIAS_DB_SELECT_1();

            /*" -949- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -950- MOVE 10 TO MALHACEF-COD-FONTE. */
                _.Move(10, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-AGENCIAS-DB-SELECT-1 */
        public void R1100_00_SELECT_AGENCIAS_DB_SELECT_1()
        {
            /*" -945- EXEC SQL SELECT B.COD_FONTE INTO :MALHACEF-COD-FONTE FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B WHERE A.COD_AGENCIA = :AGENCCEF-COD-AGENCIA AND A.COD_SUREG = B.COD_SUREG WITH UR END-EXEC. */

            var r1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1 = new R1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1()
            {
                AGENCCEF_COD_AGENCIA = AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA.ToString(),
            };

            var executed_1 = R1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1310-00-INSERT-RCAPS-SECTION */
        private void R1310_00_INSERT_RCAPS_SECTION()
        {
            /*" -963- MOVE '1310' TO WNR-EXEC-SQL. */
            _.Move("1310", W.WABEND.WNR_EXEC_SQL);

            /*" -1008- PERFORM R1310_00_INSERT_RCAPS_DB_INSERT_1 */

            R1310_00_INSERT_RCAPS_DB_INSERT_1();

            /*" -1012- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1014- DISPLAY 'R1310-00 - PROBLEMAS NO INSERT(RCAPS)      ' '   ' RCAPS-NUM-TITULO */

                $"R1310-00 - PROBLEMAS NO INSERT(RCAPS)         {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}"
                .Display();

                /*" -1014- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1310-00-INSERT-RCAPS-DB-INSERT-1 */
        public void R1310_00_INSERT_RCAPS_DB_INSERT_1()
        {
            /*" -1008- EXEC SQL INSERT INTO SEGUROS.RCAPS (COD_FONTE , NUM_RCAP , NUM_PROPOSTA , NOME_SEGURADO , VAL_RCAP , VAL_RCAP_PRINCIPAL , DATA_CADASTRAMENTO , DATA_MOVIMENTO , SIT_REGISTRO , COD_OPERACAO , COD_EMPRESA , TIMESTAMP , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_TITULO , CODIGO_PRODUTO , AGE_COBRANCA , RECUPERA , VLACRESCIMO , NUM_CERTIFICADO) VALUES (:RCAPS-COD-FONTE , :RCAPS-NUM-RCAP , :RCAPS-NUM-PROPOSTA , :RCAPS-NOME-SEGURADO , :RCAPS-VAL-RCAP , :RCAPS-VAL-RCAP-PRINCIPAL , :RCAPS-DATA-CADASTRAMENTO , :RCAPS-DATA-MOVIMENTO , :RCAPS-SIT-REGISTRO , :RCAPS-COD-OPERACAO , :RCAPS-COD-EMPRESA:VIND-NULL01 , CURRENT TIMESTAMP , :RCAPS-NUM-APOLICE:VIND-NULL02 , :RCAPS-NUM-ENDOSSO:VIND-NULL03 , :RCAPS-NUM-PARCELA:VIND-NULL04 , :RCAPS-NUM-TITULO:VIND-NULL05 , :RCAPS-CODIGO-PRODUTO:VIND-NULL06 , :RCAPS-AGE-COBRANCA:VIND-NULL07 , :RCAPS-RECUPERA:VIND-NULL08 , :RCAPS-VLACRESCIMO:VIND-NULL09 , :RCAPS-NUM-CERTIFICADO:VIND-NULL10) END-EXEC. */

            var r1310_00_INSERT_RCAPS_DB_INSERT_1_Insert1 = new R1310_00_INSERT_RCAPS_DB_INSERT_1_Insert1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
                RCAPS_NUM_PROPOSTA = RCAPS.DCLRCAPS.RCAPS_NUM_PROPOSTA.ToString(),
                RCAPS_NOME_SEGURADO = RCAPS.DCLRCAPS.RCAPS_NOME_SEGURADO.ToString(),
                RCAPS_VAL_RCAP = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.ToString(),
                RCAPS_VAL_RCAP_PRINCIPAL = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL.ToString(),
                RCAPS_DATA_CADASTRAMENTO = RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO.ToString(),
                RCAPS_DATA_MOVIMENTO = RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO.ToString(),
                RCAPS_SIT_REGISTRO = RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO.ToString(),
                RCAPS_COD_OPERACAO = RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO.ToString(),
                RCAPS_COD_EMPRESA = RCAPS.DCLRCAPS.RCAPS_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                RCAPS_NUM_APOLICE = RCAPS.DCLRCAPS.RCAPS_NUM_APOLICE.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
                RCAPS_NUM_ENDOSSO = RCAPS.DCLRCAPS.RCAPS_NUM_ENDOSSO.ToString(),
                VIND_NULL03 = VIND_NULL03.ToString(),
                RCAPS_NUM_PARCELA = RCAPS.DCLRCAPS.RCAPS_NUM_PARCELA.ToString(),
                VIND_NULL04 = VIND_NULL04.ToString(),
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
                VIND_NULL05 = VIND_NULL05.ToString(),
                RCAPS_CODIGO_PRODUTO = RCAPS.DCLRCAPS.RCAPS_CODIGO_PRODUTO.ToString(),
                VIND_NULL06 = VIND_NULL06.ToString(),
                RCAPS_AGE_COBRANCA = RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA.ToString(),
                VIND_NULL07 = VIND_NULL07.ToString(),
                RCAPS_RECUPERA = RCAPS.DCLRCAPS.RCAPS_RECUPERA.ToString(),
                VIND_NULL08 = VIND_NULL08.ToString(),
                RCAPS_VLACRESCIMO = RCAPS.DCLRCAPS.RCAPS_VLACRESCIMO.ToString(),
                VIND_NULL09 = VIND_NULL09.ToString(),
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
                VIND_NULL10 = VIND_NULL10.ToString(),
            };

            R1310_00_INSERT_RCAPS_DB_INSERT_1_Insert1.Execute(r1310_00_INSERT_RCAPS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1310_99_SAIDA*/

        [StopWatch]
        /*" R1320-00-INSERT-RCAPCOMP-SECTION */
        private void R1320_00_INSERT_RCAPCOMP_SECTION()
        {
            /*" -1027- MOVE '1320' TO WNR-EXEC-SQL. */
            _.Move("1320", W.WABEND.WNR_EXEC_SQL);

            /*" -1062- PERFORM R1320_00_INSERT_RCAPCOMP_DB_INSERT_1 */

            R1320_00_INSERT_RCAPCOMP_DB_INSERT_1();

            /*" -1066- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1068- DISPLAY 'R1320-00 - PROBLEMAS NO INSERT(RCAPCOMP)   ' '   ' RCAPCOMP-NUM-RCAP */

                $"R1320-00 - PROBLEMAS NO INSERT(RCAPCOMP)      {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP}"
                .Display();

                /*" -1068- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1320-00-INSERT-RCAPCOMP-DB-INSERT-1 */
        public void R1320_00_INSERT_RCAPCOMP_DB_INSERT_1()
        {
            /*" -1062- EXEC SQL INSERT INTO SEGUROS.RCAP_COMPLEMENTAR (COD_FONTE , NUM_RCAP , NUM_RCAP_COMPLEMEN , COD_OPERACAO , DATA_MOVIMENTO , HORA_OPERACAO , SIT_REGISTRO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , VAL_RCAP , DATA_RCAP , DATA_CADASTRAMENTO , SIT_CONTABIL , COD_EMPRESA , TIMESTAMP) VALUES (:RCAPCOMP-COD-FONTE , :RCAPCOMP-NUM-RCAP , :RCAPCOMP-NUM-RCAP-COMPLEMEN , :RCAPCOMP-COD-OPERACAO , :RCAPCOMP-DATA-MOVIMENTO , CURRENT TIME , :RCAPCOMP-SIT-REGISTRO , :RCAPCOMP-BCO-AVISO , :RCAPCOMP-AGE-AVISO , :RCAPCOMP-NUM-AVISO-CREDITO , :RCAPCOMP-VAL-RCAP , :RCAPCOMP-DATA-RCAP , :RCAPCOMP-DATA-CADASTRAMENTO , :RCAPCOMP-SIT-CONTABIL , :RCAPCOMP-COD-EMPRESA:VIND-NULL01 , CURRENT TIMESTAMP) END-EXEC. */

            var r1320_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1 = new R1320_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1()
            {
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
                RCAPCOMP_NUM_RCAP_COMPLEMEN = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN.ToString(),
                RCAPCOMP_COD_OPERACAO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO.ToString(),
                RCAPCOMP_DATA_MOVIMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.ToString(),
                RCAPCOMP_SIT_REGISTRO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_VAL_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP.ToString(),
                RCAPCOMP_DATA_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.ToString(),
                RCAPCOMP_DATA_CADASTRAMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO.ToString(),
                RCAPCOMP_SIT_CONTABIL = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL.ToString(),
                RCAPCOMP_COD_EMPRESA = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
            };

            R1320_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1.Execute(r1320_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1320_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TRATA-FOLLOWUP-SECTION */
        private void R4000_00_TRATA_FOLLOWUP_SECTION()
        {
            /*" -1081- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", W.WABEND.WNR_EXEC_SQL);

            /*" -1083- ADD 1 TO AC-FOLLOWUP. */
            W.AC_FOLLOWUP.Value = W.AC_FOLLOWUP + 1;

            /*" -1085- MOVE SOR-NUM-TITULO TO FOLLOUP-NUM-APOLICE. */
            _.Move(REG_ARQSORT.SOR_NUM_TITULO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE);

            /*" -1087- MOVE ZEROS TO FOLLOUP-NUM-ENDOSSO. */
            _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO);

            /*" -1089- MOVE ZEROS TO FOLLOUP-NUM-PARCELA. */
            _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA);

            /*" -1091- MOVE SPACES TO FOLLOUP-DAC-PARCELA. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DAC_PARCELA);

            /*" -1093- MOVE SISTEMAS-DATA-MOV-ABERTO TO FOLLOUP-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO);

            /*" -1096- MOVE SOR-VAL-TITULO TO FOLLOUP-VAL-OPERACAO. */
            _.Move(REG_ARQSORT.SOR_VAL_TITULO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);

            /*" -1099- MOVE SOR-COD-BANCO TO FOLLOUP-BCO-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_BANCO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO);

            /*" -1102- MOVE SOR-COD-AGENCIA TO FOLLOUP-AGE-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO);

            /*" -1105- MOVE SOR-NUM-AVISO TO FOLLOUP-NUM-AVISO-CREDITO. */
            _.Move(REG_ARQSORT.SOR_NUM_AVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO);

            /*" -1107- MOVE 30 TO FOLLOUP-COD-BAIXA-PARCELA. */
            _.Move(30, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_BAIXA_PARCELA);

            /*" -1109- MOVE '1' TO FOLLOUP-COD-ERRO02. */
            _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO02);

            /*" -1115- MOVE SPACES TO FOLLOUP-COD-ERRO01 FOLLOUP-COD-ERRO03 FOLLOUP-COD-ERRO04 FOLLOUP-COD-ERRO05 FOLLOUP-COD-ERRO06. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO01, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO03, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO04, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO05, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO06);

            /*" -1117- MOVE '0' TO FOLLOUP-SIT-REGISTRO. */
            _.Move("0", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_REGISTRO);

            /*" -1119- MOVE SPACES TO FOLLOUP-SIT-CONTABIL. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_CONTABIL);

            /*" -1121- MOVE 103 TO FOLLOUP-COD-OPERACAO. */
            _.Move(103, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_OPERACAO);

            /*" -1123- MOVE SPACES TO FOLLOUP-DATA-LIBERACAO. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_LIBERACAO);

            /*" -1125- MOVE SOR-DATA-QUITACAO TO FOLLOUP-DATA-QUITACAO. */
            _.Move(REG_ARQSORT.SOR_DATA_QUITACAO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_QUITACAO);

            /*" -1127- MOVE ZEROS TO FOLLOUP-COD-EMPRESA. */
            _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_EMPRESA);

            /*" -1129- MOVE ZEROS TO FOLLOUP-ORDEM-LIDER. */
            _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ORDEM_LIDER);

            /*" -1131- MOVE '1' TO FOLLOUP-TIPO-SEGURO. */
            _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_TIPO_SEGURO);

            /*" -1134- MOVE SPACES TO FOLLOUP-NUM-APOL-LIDER FOLLOUP-ENDOS-LIDER. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOL_LIDER, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ENDOS_LIDER);

            /*" -1138- MOVE ZEROS TO FOLLOUP-COD-LIDER FOLLOUP-COD-FONTE FOLLOUP-NUM-RCAP. */
            _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_LIDER, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_FONTE, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_RCAP);

            /*" -1141- MOVE SOR-NUM-NOSSO-TITULO TO FOLLOUP-NUM-NOSSO-TITULO. */
            _.Move(REG_ARQSORT.SOR_NUM_NOSSO_TITULO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_NOSSO_TITULO);

            /*" -1145- MOVE ZEROS TO VIND-NULL02 VIND-NULL03 VIND-NULL05. */
            _.Move(0, VIND_NULL02, VIND_NULL03, VIND_NULL05);

            /*" -1153- MOVE -1 TO VIND-NULL01 VIND-NULL04 VIND-NULL06 VIND-NULL07 VIND-NULL08 VIND-NULL09 VIND-NULL10. */
            _.Move(-1, VIND_NULL01, VIND_NULL04, VIND_NULL06, VIND_NULL07, VIND_NULL08, VIND_NULL09, VIND_NULL10);

            /*" -1154- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -1155- MOVE WS-HH-TIME TO WTIME-HORA. */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_5.WTIME_DAYR.WTIME_HORA);

            /*" -1156- MOVE '.' TO WTIME-2PT1. */
            _.Move(".", W.FILLER_5.WTIME_DAYR.WTIME_2PT1);

            /*" -1157- MOVE WS-MM-TIME TO WTIME-MINU. */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_5.WTIME_DAYR.WTIME_MINU);

            /*" -1158- MOVE '.' TO WTIME-2PT2. */
            _.Move(".", W.FILLER_5.WTIME_DAYR.WTIME_2PT2);

            /*" -1159- MOVE WS-SS-TIME TO WTIME-SEGU. */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_5.WTIME_DAYR.WTIME_SEGU);

            /*" -1162- MOVE WTIME-DAYR TO FOLLOUP-HORA-OPERACAO. */
            _.Move(W.FILLER_5.WTIME_DAYR, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO);

            /*" -1164- MOVE ZEROS TO AC-DUPLICA. */
            _.Move(0, W.AC_DUPLICA);

            /*" -1164- PERFORM R4100-00-INSERT-FOLLOWUP. */

            R4100_00_INSERT_FOLLOWUP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-INSERT-FOLLOWUP-SECTION */
        private void R4100_00_INSERT_FOLLOWUP_SECTION()
        {
            /*" -1176- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", W.WABEND.WNR_EXEC_SQL);

            /*" -1243- PERFORM R4100_00_INSERT_FOLLOWUP_DB_INSERT_1 */

            R4100_00_INSERT_FOLLOWUP_DB_INSERT_1();

            /*" -1248- IF SQLCODE EQUAL -803 AND AC-DUPLICA LESS 10 */

            if (DB.SQLCODE == -803 && W.AC_DUPLICA < 10)
            {

                /*" -1249- ADD 1 TO AC-DUPLICA */
                W.AC_DUPLICA.Value = W.AC_DUPLICA + 1;

                /*" -1250- PERFORM R4110-00-ADICIONA-TIME */

                R4110_00_ADICIONA_TIME_SECTION();

                /*" -1251- GO TO R4100-00-INSERT-FOLLOWUP */
                new Task(() => R4100_00_INSERT_FOLLOWUP_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1252- ELSE */
            }
            else
            {


                /*" -1253- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1254- DISPLAY 'R4100-00 - PROBLEMAS NO INSERT(FOLLOUP)    ' */
                    _.Display($"R4100-00 - PROBLEMAS NO INSERT(FOLLOUP)    ");

                    /*" -1255- DISPLAY 'NUM-NOSSO-TITULO=' FOLLOUP-NUM-NOSSO-TITULO */
                    _.Display($"NUM-NOSSO-TITULO={FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_NOSSO_TITULO}");

                    /*" -1255- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R4100-00-INSERT-FOLLOWUP-DB-INSERT-1 */
        public void R4100_00_INSERT_FOLLOWUP_DB_INSERT_1()
        {
            /*" -1243- EXEC SQL INSERT INTO SEGUROS.FOLLOW_UP (NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DAC_PARCELA , DATA_MOVIMENTO , HORA_OPERACAO , VAL_OPERACAO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , COD_BAIXA_PARCELA , COD_ERRO01 , COD_ERRO02 , COD_ERRO03 , COD_ERRO04 , COD_ERRO05 , COD_ERRO06 , SIT_REGISTRO , SIT_CONTABIL , COD_OPERACAO , DATA_LIBERACAO , DATA_QUITACAO , COD_EMPRESA , TIMESTAMP , ORDEM_LIDER , TIPO_SEGURO , NUM_APOL_LIDER , ENDOS_LIDER , COD_LIDER , COD_FONTE , NUM_RCAP , NUM_NOSSO_TITULO) VALUES (:FOLLOUP-NUM-APOLICE , :FOLLOUP-NUM-ENDOSSO , :FOLLOUP-NUM-PARCELA , :FOLLOUP-DAC-PARCELA , :FOLLOUP-DATA-MOVIMENTO , :FOLLOUP-HORA-OPERACAO , :FOLLOUP-VAL-OPERACAO , :FOLLOUP-BCO-AVISO , :FOLLOUP-AGE-AVISO , :FOLLOUP-NUM-AVISO-CREDITO , :FOLLOUP-COD-BAIXA-PARCELA , :FOLLOUP-COD-ERRO01 , :FOLLOUP-COD-ERRO02 , :FOLLOUP-COD-ERRO03 , :FOLLOUP-COD-ERRO04 , :FOLLOUP-COD-ERRO05 , :FOLLOUP-COD-ERRO06 , :FOLLOUP-SIT-REGISTRO , :FOLLOUP-SIT-CONTABIL , :FOLLOUP-COD-OPERACAO , :FOLLOUP-DATA-LIBERACAO:VIND-NULL01 , :FOLLOUP-DATA-QUITACAO:VIND-NULL02 , :FOLLOUP-COD-EMPRESA:VIND-NULL03 , CURRENT TIMESTAMP , :FOLLOUP-ORDEM-LIDER:VIND-NULL04 , :FOLLOUP-TIPO-SEGURO:VIND-NULL05 , :FOLLOUP-NUM-APOL-LIDER:VIND-NULL06 , :FOLLOUP-ENDOS-LIDER:VIND-NULL07 , :FOLLOUP-COD-LIDER:VIND-NULL08 , :FOLLOUP-COD-FONTE:VIND-NULL09 , :FOLLOUP-NUM-RCAP:VIND-NULL10 , :FOLLOUP-NUM-NOSSO-TITULO) END-EXEC. */

            var r4100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1 = new R4100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1()
            {
                FOLLOUP_NUM_APOLICE = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE.ToString(),
                FOLLOUP_NUM_ENDOSSO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO.ToString(),
                FOLLOUP_NUM_PARCELA = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA.ToString(),
                FOLLOUP_DAC_PARCELA = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DAC_PARCELA.ToString(),
                FOLLOUP_DATA_MOVIMENTO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO.ToString(),
                FOLLOUP_HORA_OPERACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO.ToString(),
                FOLLOUP_VAL_OPERACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO.ToString(),
                FOLLOUP_BCO_AVISO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO.ToString(),
                FOLLOUP_AGE_AVISO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO.ToString(),
                FOLLOUP_NUM_AVISO_CREDITO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO.ToString(),
                FOLLOUP_COD_BAIXA_PARCELA = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_BAIXA_PARCELA.ToString(),
                FOLLOUP_COD_ERRO01 = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO01.ToString(),
                FOLLOUP_COD_ERRO02 = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO02.ToString(),
                FOLLOUP_COD_ERRO03 = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO03.ToString(),
                FOLLOUP_COD_ERRO04 = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO04.ToString(),
                FOLLOUP_COD_ERRO05 = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO05.ToString(),
                FOLLOUP_COD_ERRO06 = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO06.ToString(),
                FOLLOUP_SIT_REGISTRO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_REGISTRO.ToString(),
                FOLLOUP_SIT_CONTABIL = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_CONTABIL.ToString(),
                FOLLOUP_COD_OPERACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_OPERACAO.ToString(),
                FOLLOUP_DATA_LIBERACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_LIBERACAO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                FOLLOUP_DATA_QUITACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_QUITACAO.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
                FOLLOUP_COD_EMPRESA = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_EMPRESA.ToString(),
                VIND_NULL03 = VIND_NULL03.ToString(),
                FOLLOUP_ORDEM_LIDER = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ORDEM_LIDER.ToString(),
                VIND_NULL04 = VIND_NULL04.ToString(),
                FOLLOUP_TIPO_SEGURO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_TIPO_SEGURO.ToString(),
                VIND_NULL05 = VIND_NULL05.ToString(),
                FOLLOUP_NUM_APOL_LIDER = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOL_LIDER.ToString(),
                VIND_NULL06 = VIND_NULL06.ToString(),
                FOLLOUP_ENDOS_LIDER = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ENDOS_LIDER.ToString(),
                VIND_NULL07 = VIND_NULL07.ToString(),
                FOLLOUP_COD_LIDER = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_LIDER.ToString(),
                VIND_NULL08 = VIND_NULL08.ToString(),
                FOLLOUP_COD_FONTE = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_FONTE.ToString(),
                VIND_NULL09 = VIND_NULL09.ToString(),
                FOLLOUP_NUM_RCAP = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_RCAP.ToString(),
                VIND_NULL10 = VIND_NULL10.ToString(),
                FOLLOUP_NUM_NOSSO_TITULO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_NOSSO_TITULO.ToString(),
            };

            R4100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1.Execute(r4100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4110-00-ADICIONA-TIME-SECTION */
        private void R4110_00_ADICIONA_TIME_SECTION()
        {
            /*" -1268- MOVE '4110' TO WNR-EXEC-SQL. */
            _.Move("4110", W.WABEND.WNR_EXEC_SQL);

            /*" -1270- IF WTIME-SEGU GREATER ZEROS AND WTIME-SEGU LESS 59 */

            if (W.FILLER_5.WTIME_DAYR.WTIME_SEGU > 00 && W.FILLER_5.WTIME_DAYR.WTIME_SEGU < 59)
            {

                /*" -1271- ADD 1 TO WTIME-SEGU */
                W.FILLER_5.WTIME_DAYR.WTIME_SEGU.Value = W.FILLER_5.WTIME_DAYR.WTIME_SEGU + 1;

                /*" -1272- ELSE */
            }
            else
            {


                /*" -1274- IF WTIME-MINU GREATER ZEROS AND WTIME-MINU LESS 59 */

                if (W.FILLER_5.WTIME_DAYR.WTIME_MINU > 00 && W.FILLER_5.WTIME_DAYR.WTIME_MINU < 59)
                {

                    /*" -1275- ADD 1 TO WTIME-MINU */
                    W.FILLER_5.WTIME_DAYR.WTIME_MINU.Value = W.FILLER_5.WTIME_DAYR.WTIME_MINU + 1;

                    /*" -1276- MOVE 1 TO WTIME-SEGU */
                    _.Move(1, W.FILLER_5.WTIME_DAYR.WTIME_SEGU);

                    /*" -1277- ELSE */
                }
                else
                {


                    /*" -1279- IF WTIME-HORA GREATER ZEROS AND WTIME-HORA LESS 23 */

                    if (W.FILLER_5.WTIME_DAYR.WTIME_HORA > 00 && W.FILLER_5.WTIME_DAYR.WTIME_HORA < 23)
                    {

                        /*" -1280- ADD 1 TO WTIME-HORA */
                        W.FILLER_5.WTIME_DAYR.WTIME_HORA.Value = W.FILLER_5.WTIME_DAYR.WTIME_HORA + 1;

                        /*" -1281- MOVE 1 TO WTIME-MINU */
                        _.Move(1, W.FILLER_5.WTIME_DAYR.WTIME_MINU);

                        /*" -1282- MOVE 1 TO WTIME-SEGU */
                        _.Move(1, W.FILLER_5.WTIME_DAYR.WTIME_SEGU);

                        /*" -1283- ELSE */
                    }
                    else
                    {


                        /*" -1284- MOVE 1 TO WTIME-HORA */
                        _.Move(1, W.FILLER_5.WTIME_DAYR.WTIME_HORA);

                        /*" -1285- MOVE 1 TO WTIME-MINU */
                        _.Move(1, W.FILLER_5.WTIME_DAYR.WTIME_MINU);

                        /*" -1288- MOVE 1 TO WTIME-SEGU. */
                        _.Move(1, W.FILLER_5.WTIME_DAYR.WTIME_SEGU);
                    }

                }

            }


            /*" -1289- MOVE WTIME-DAYR TO FOLLOUP-HORA-OPERACAO. */
            _.Move(W.FILLER_5.WTIME_DAYR, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4110_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-UPDATE-V0MOVICOB-SECTION */
        private void R4200_00_UPDATE_V0MOVICOB_SECTION()
        {
            /*" -1300- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", W.WABEND.WNR_EXEC_SQL);

            /*" -1310- PERFORM R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1 */

            R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1();

            /*" -1313- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1314- DISPLAY 'R4200-00 - PROBLEMAS UPDATE (V0MOVICOB)   ' */
                _.Display($"R4200-00 - PROBLEMAS UPDATE (V0MOVICOB)   ");

                /*" -1315- DISPLAY 'COD_BANCO         = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD_BANCO         = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1316- DISPLAY 'COD_AGENCIA       = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD_AGENCIA       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1317- DISPLAY 'NUM_FITA          = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM_FITA          = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1318- DISPLAY 'NUM_TITULO        = ' MOVIMCOB-NUM-TITULO */
                _.Display($"NUM_TITULO        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO}");

                /*" -1319- DISPLAY 'NUM_NOSSO_TITULO  = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM_NOSSO_TITULO  = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1320- DISPLAY 'NUM_AVISO         = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM_AVISO         = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1321- DISPLAY 'COD_MOVIMENTO     = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD_MOVIMENTO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1321- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4200-00-UPDATE-V0MOVICOB-DB-UPDATE-1 */
        public void R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1()
        {
            /*" -1310- EXEC SQL UPDATE SEGUROS.MOVIMENTO_COBRANCA SET COD_BANCO = :MOVIMCOB-COD-BANCO ,COD_AGENCIA = :MOVIMCOB-COD-AGENCIA ,NUM_AVISO = :MOVIMCOB-NUM-AVISO ,NUM_TITULO = :MOVIMCOB-NUM-TITULO ,SIT_REGISTRO = :MOVIMCOB-SIT-REGISTRO WHERE NUM_NOSSO_TITULO = :MOVIMCOB-NUM-NOSSO-TITULO AND SIT_REGISTRO = ' ' AND TIPO_MOVIMENTO = 'G' END-EXEC */

            var r4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 = new R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1()
            {
                MOVIMCOB_SIT_REGISTRO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO.ToString(),
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_NUM_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
            };

            R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1.Execute(r4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4210-00-UPDATE-V0MOVICOB-TIT-SECTION */
        private void R4210_00_UPDATE_V0MOVICOB_TIT_SECTION()
        {
            /*" -1333- MOVE '4210' TO WNR-EXEC-SQL. */
            _.Move("4210", W.WABEND.WNR_EXEC_SQL);

            /*" -1343- PERFORM R4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1 */

            R4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1();

            /*" -1346- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1347- DISPLAY 'R4210-00 - PROBLEMAS UPDATE (V0MOVICOB)   ' */
                _.Display($"R4210-00 - PROBLEMAS UPDATE (V0MOVICOB)   ");

                /*" -1348- DISPLAY 'COD_BANCO         = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD_BANCO         = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1349- DISPLAY 'COD_AGENCIA       = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD_AGENCIA       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1350- DISPLAY 'NUM_FITA          = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM_FITA          = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1351- DISPLAY 'NUM_TITULO        = ' MOVIMCOB-NUM-TITULO */
                _.Display($"NUM_TITULO        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO}");

                /*" -1352- DISPLAY 'NUM_NOSSO_TITULO  = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM_NOSSO_TITULO  = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1353- DISPLAY 'NUM_AVISO         = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM_AVISO         = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1354- DISPLAY 'COD_MOVIMENTO     = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD_MOVIMENTO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1354- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4210-00-UPDATE-V0MOVICOB-TIT-DB-UPDATE-1 */
        public void R4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1()
        {
            /*" -1343- EXEC SQL UPDATE SEGUROS.MOVIMENTO_COBRANCA SET NUM_TITULO = :MOVIMCOB-NUM-TITULO WHERE COD_BANCO = :MOVIMCOB-COD-BANCO AND COD_AGENCIA = :MOVIMCOB-COD-AGENCIA AND NUM_FITA = :MOVIMCOB-NUM-FITA AND NUM_TITULO = 0 AND NUM_NOSSO_TITULO = :MOVIMCOB-NUM-NOSSO-TITULO AND NUM_AVISO = :MOVIMCOB-NUM-AVISO AND COD_MOVIMENTO = :MOVIMCOB-COD-MOVIMENTO END-EXEC */

            var r4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1_Update1 = new R4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1_Update1()
            {
                MOVIMCOB_NUM_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO.ToString(),
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
                MOVIMCOB_COD_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO.ToString(),
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
                MOVIMCOB_NUM_FITA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA.ToString(),
            };

            R4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1_Update1.Execute(r4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4210_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-TRATAR-CONDESCE-SECTION */
        private void R5000_00_TRATAR_CONDESCE_SECTION()
        {
            /*" -1366- PERFORM R5100-00-SELECT-CONDESCE. */

            R5100_00_SELECT_CONDESCE_SECTION();

            /*" -1367- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1368- PERFORM R5200-00-UPDATE-CONDESCE */

                R5200_00_UPDATE_CONDESCE_SECTION();

                /*" -1369- ELSE */
            }
            else
            {


                /*" -1369- PERFORM R5300-00-INSERT-CONDESCE. */

                R5300_00_INSERT_CONDESCE_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5100-00-SELECT-CONDESCE-SECTION */
        private void R5100_00_SELECT_CONDESCE_SECTION()
        {
            /*" -1380- MOVE '5100' TO WNR-EXEC-SQL. */
            _.Move("5100", W.WABEND.WNR_EXEC_SQL);

            /*" -1414- PERFORM R5100_00_SELECT_CONDESCE_DB_SELECT_1 */

            R5100_00_SELECT_CONDESCE_DB_SELECT_1();

            /*" -1417- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1418- DISPLAY 'R5100-00 - PROBLEMAS NO SELECT(CONDESCE)' */
                _.Display($"R5100-00 - PROBLEMAS NO SELECT(CONDESCE)");

                /*" -1420- DISPLAY 'ANO_REFERENCIA     = ' CONDESCE-ANO-REFERENCIA */
                _.Display($"ANO_REFERENCIA     = {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_ANO_REFERENCIA}");

                /*" -1422- DISPLAY 'MES_REFERENCIA     = ' CONDESCE-MES-REFERENCIA */
                _.Display($"MES_REFERENCIA     = {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_MES_REFERENCIA}");

                /*" -1424- DISPLAY 'BCO_AVISO          = ' CONDESCE-BCO-AVISO */
                _.Display($"BCO_AVISO          = {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO}");

                /*" -1426- DISPLAY 'AGE_AVISO          = ' CONDESCE-AGE-AVISO */
                _.Display($"AGE_AVISO          = {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO}");

                /*" -1428- DISPLAY 'NUM_AVISO_CREDITO  = ' CONDESCE-NUM-AVISO-CREDITO */
                _.Display($"NUM_AVISO_CREDITO  = {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO}");

                /*" -1430- DISPLAY 'COD_PRODUTO        = ' CONDESCE-COD-PRODUTO */
                _.Display($"COD_PRODUTO        = {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO}");

                /*" -1430- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5100-00-SELECT-CONDESCE-DB-SELECT-1 */
        public void R5100_00_SELECT_CONDESCE_DB_SELECT_1()
        {
            /*" -1414- EXEC SQL SELECT QTD_REGISTROS , PRM_TOTAL , PRM_LIQUIDO , VAL_TARIFA , VAL_BALCAO , VAL_IOCC , VAL_DESCONTO , VAL_JUROS , VAL_MULTA INTO :CONDESCE-QTD-REGISTROS , :CONDESCE-PRM-TOTAL , :CONDESCE-PRM-LIQUIDO , :CONDESCE-VAL-TARIFA , :CONDESCE-VAL-BALCAO , :CONDESCE-VAL-IOCC , :CONDESCE-VAL-DESCONTO , :CONDESCE-VAL-JUROS , :CONDESCE-VAL-MULTA FROM SEGUROS.CONTROL_DESPES_CEF WHERE COD_EMPRESA = :CONDESCE-COD-EMPRESA AND ANO_REFERENCIA = :CONDESCE-ANO-REFERENCIA AND MES_REFERENCIA = :CONDESCE-MES-REFERENCIA AND BCO_AVISO = :CONDESCE-BCO-AVISO AND AGE_AVISO = :CONDESCE-AGE-AVISO AND NUM_AVISO_CREDITO = :CONDESCE-NUM-AVISO-CREDITO AND COD_PRODUTO = :CONDESCE-COD-PRODUTO END-EXEC. */

            var r5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1 = new R5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1()
            {
                CONDESCE_NUM_AVISO_CREDITO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO.ToString(),
                CONDESCE_ANO_REFERENCIA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_ANO_REFERENCIA.ToString(),
                CONDESCE_MES_REFERENCIA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_MES_REFERENCIA.ToString(),
                CONDESCE_COD_EMPRESA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_EMPRESA.ToString(),
                CONDESCE_COD_PRODUTO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO.ToString(),
                CONDESCE_BCO_AVISO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO.ToString(),
                CONDESCE_AGE_AVISO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO.ToString(),
            };

            var executed_1 = R5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1.Execute(r5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDESCE_QTD_REGISTROS, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS);
                _.Move(executed_1.CONDESCE_PRM_TOTAL, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL);
                _.Move(executed_1.CONDESCE_PRM_LIQUIDO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO);
                _.Move(executed_1.CONDESCE_VAL_TARIFA, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA);
                _.Move(executed_1.CONDESCE_VAL_BALCAO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO);
                _.Move(executed_1.CONDESCE_VAL_IOCC, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_IOCC);
                _.Move(executed_1.CONDESCE_VAL_DESCONTO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_DESCONTO);
                _.Move(executed_1.CONDESCE_VAL_JUROS, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_JUROS);
                _.Move(executed_1.CONDESCE_VAL_MULTA, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_MULTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/

        [StopWatch]
        /*" R5200-00-UPDATE-CONDESCE-SECTION */
        private void R5200_00_UPDATE_CONDESCE_SECTION()
        {
            /*" -1441- MOVE '5200' TO WNR-EXEC-SQL. */
            _.Move("5200", W.WABEND.WNR_EXEC_SQL);

            /*" -1443- ADD WS-CONDESCE-QTD-REGISTROS TO CONDESCE-QTD-REGISTROS */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS + WS_CONDESCE_QTD_REGISTROS;

            /*" -1445- ADD WS-CONDESCE-PRM-TOTAL TO CONDESCE-PRM-TOTAL */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL + WS_CONDESCE_PRM_TOTAL;

            /*" -1447- ADD WS-CONDESCE-PRM-LIQUIDO TO CONDESCE-PRM-LIQUIDO */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO + WS_CONDESCE_PRM_LIQUIDO;

            /*" -1449- ADD WS-CONDESCE-VAL-TARIFA TO CONDESCE-VAL-TARIFA */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA + WS_CONDESCE_VAL_TARIFA;

            /*" -1451- ADD WS-CONDESCE-VAL-BALCAO TO CONDESCE-VAL-BALCAO */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO + WS_CONDESCE_VAL_BALCAO;

            /*" -1453- ADD WS-CONDESCE-VAL-IOCC TO CONDESCE-VAL-IOCC */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_IOCC.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_IOCC + WS_CONDESCE_VAL_IOCC;

            /*" -1455- ADD WS-CONDESCE-VAL-DESCONTO TO CONDESCE-VAL-DESCONTO */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_DESCONTO.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_DESCONTO + WS_CONDESCE_VAL_DESCONTO;

            /*" -1457- ADD WS-CONDESCE-VAL-JUROS TO CONDESCE-VAL-JUROS */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_JUROS.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_JUROS + WS_CONDESCE_VAL_JUROS;

            /*" -1460- ADD WS-CONDESCE-VAL-MULTA TO CONDESCE-VAL-MULTA. */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_MULTA.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_MULTA + WS_CONDESCE_VAL_MULTA;

            /*" -1494- PERFORM R5200_00_UPDATE_CONDESCE_DB_UPDATE_1 */

            R5200_00_UPDATE_CONDESCE_DB_UPDATE_1();

            /*" -1497- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1502- DISPLAY 'R5200-00 - PROBLEMAS NO UPDATE(CONDESCE)   ' '  ' CONDESCE-BCO-AVISO '  ' CONDESCE-AGE-AVISO '  ' CONDESCE-NUM-AVISO-CREDITO '  ' CONDESCE-COD-PRODUTO */

                $"R5200-00 - PROBLEMAS NO UPDATE(CONDESCE)     {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO}"
                .Display();

                /*" -1502- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5200-00-UPDATE-CONDESCE-DB-UPDATE-1 */
        public void R5200_00_UPDATE_CONDESCE_DB_UPDATE_1()
        {
            /*" -1494- EXEC SQL UPDATE SEGUROS.CONTROL_DESPES_CEF SET QTD_REGISTROS = :CONDESCE-QTD-REGISTROS , PRM_TOTAL = :CONDESCE-PRM-TOTAL , PRM_LIQUIDO = :CONDESCE-PRM-LIQUIDO , VAL_TARIFA = :CONDESCE-VAL-TARIFA , VAL_BALCAO = :CONDESCE-VAL-BALCAO , VAL_IOCC = :CONDESCE-VAL-IOCC , VAL_DESCONTO = :CONDESCE-VAL-DESCONTO , VAL_JUROS = :CONDESCE-VAL-JUROS , VAL_MULTA = :CONDESCE-VAL-MULTA WHERE COD_EMPRESA = :CONDESCE-COD-EMPRESA AND ANO_REFERENCIA = :CONDESCE-ANO-REFERENCIA AND MES_REFERENCIA = :CONDESCE-MES-REFERENCIA AND BCO_AVISO = :CONDESCE-BCO-AVISO AND AGE_AVISO = :CONDESCE-AGE-AVISO AND NUM_AVISO_CREDITO = :CONDESCE-NUM-AVISO-CREDITO AND COD_PRODUTO = :CONDESCE-COD-PRODUTO END-EXEC. */

            var r5200_00_UPDATE_CONDESCE_DB_UPDATE_1_Update1 = new R5200_00_UPDATE_CONDESCE_DB_UPDATE_1_Update1()
            {
                CONDESCE_QTD_REGISTROS = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS.ToString(),
                CONDESCE_VAL_DESCONTO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_DESCONTO.ToString(),
                CONDESCE_PRM_LIQUIDO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO.ToString(),
                CONDESCE_VAL_TARIFA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA.ToString(),
                CONDESCE_VAL_BALCAO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO.ToString(),
                CONDESCE_PRM_TOTAL = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL.ToString(),
                CONDESCE_VAL_JUROS = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_JUROS.ToString(),
                CONDESCE_VAL_MULTA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_MULTA.ToString(),
                CONDESCE_VAL_IOCC = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_IOCC.ToString(),
                CONDESCE_NUM_AVISO_CREDITO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO.ToString(),
                CONDESCE_ANO_REFERENCIA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_ANO_REFERENCIA.ToString(),
                CONDESCE_MES_REFERENCIA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_MES_REFERENCIA.ToString(),
                CONDESCE_COD_EMPRESA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_EMPRESA.ToString(),
                CONDESCE_COD_PRODUTO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO.ToString(),
                CONDESCE_BCO_AVISO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO.ToString(),
                CONDESCE_AGE_AVISO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO.ToString(),
            };

            R5200_00_UPDATE_CONDESCE_DB_UPDATE_1_Update1.Execute(r5200_00_UPDATE_CONDESCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5200_99_SAIDA*/

        [StopWatch]
        /*" R5300-00-INSERT-CONDESCE-SECTION */
        private void R5300_00_INSERT_CONDESCE_SECTION()
        {
            /*" -1513- MOVE '5300' TO WNR-EXEC-SQL. */
            _.Move("5300", W.WABEND.WNR_EXEC_SQL);

            /*" -1515- MOVE WS-CONDESCE-QTD-REGISTROS TO CONDESCE-QTD-REGISTROS */
            _.Move(WS_CONDESCE_QTD_REGISTROS, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS);

            /*" -1517- MOVE WS-CONDESCE-PRM-TOTAL TO CONDESCE-PRM-TOTAL */
            _.Move(WS_CONDESCE_PRM_TOTAL, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL);

            /*" -1519- MOVE WS-CONDESCE-PRM-LIQUIDO TO CONDESCE-PRM-LIQUIDO */
            _.Move(WS_CONDESCE_PRM_LIQUIDO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO);

            /*" -1521- MOVE WS-CONDESCE-VAL-TARIFA TO CONDESCE-VAL-TARIFA */
            _.Move(WS_CONDESCE_VAL_TARIFA, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA);

            /*" -1523- MOVE WS-CONDESCE-VAL-BALCAO TO CONDESCE-VAL-BALCAO */
            _.Move(WS_CONDESCE_VAL_BALCAO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO);

            /*" -1525- MOVE WS-CONDESCE-VAL-IOCC TO CONDESCE-VAL-IOCC */
            _.Move(WS_CONDESCE_VAL_IOCC, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_IOCC);

            /*" -1527- MOVE WS-CONDESCE-VAL-DESCONTO TO CONDESCE-VAL-DESCONTO */
            _.Move(WS_CONDESCE_VAL_DESCONTO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_DESCONTO);

            /*" -1529- MOVE WS-CONDESCE-VAL-JUROS TO CONDESCE-VAL-JUROS */
            _.Move(WS_CONDESCE_VAL_JUROS, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_JUROS);

            /*" -1532- MOVE WS-CONDESCE-VAL-MULTA TO CONDESCE-VAL-MULTA. */
            _.Move(WS_CONDESCE_VAL_MULTA, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_MULTA);

            /*" -1579- PERFORM R5300_00_INSERT_CONDESCE_DB_INSERT_1 */

            R5300_00_INSERT_CONDESCE_DB_INSERT_1();

            /*" -1582- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1587- DISPLAY 'R5300-00 - PROBLEMAS NO INSERT(CONDESCE)   ' '  ' CONDESCE-BCO-AVISO '  ' CONDESCE-AGE-AVISO '  ' CONDESCE-NUM-AVISO-CREDITO '  ' CONDESCE-COD-PRODUTO */

                $"R5300-00 - PROBLEMAS NO INSERT(CONDESCE)     {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO}"
                .Display();

                /*" -1590- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1590- ADD 1 TO AC-CONDESCE. */
            W.AC_CONDESCE.Value = W.AC_CONDESCE + 1;

        }

        [StopWatch]
        /*" R5300-00-INSERT-CONDESCE-DB-INSERT-1 */
        public void R5300_00_INSERT_CONDESCE_DB_INSERT_1()
        {
            /*" -1579- EXEC SQL INSERT INTO SEGUROS.CONTROL_DESPES_CEF (COD_EMPRESA , ANO_REFERENCIA , MES_REFERENCIA , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , COD_PRODUTO , TIPO_REGISTRO , SITUACAO , TIPO_COBRANCA , DATA_MOVIMENTO , DATA_AVISO , QTD_REGISTROS , PRM_TOTAL , PRM_LIQUIDO , VAL_TARIFA , VAL_BALCAO , VAL_IOCC , VAL_DESCONTO , VAL_JUROS , VAL_MULTA , TIMESTAMP) VALUES (:CONDESCE-COD-EMPRESA , :CONDESCE-ANO-REFERENCIA , :CONDESCE-MES-REFERENCIA , :CONDESCE-BCO-AVISO , :CONDESCE-AGE-AVISO , :CONDESCE-NUM-AVISO-CREDITO , :CONDESCE-COD-PRODUTO , :CONDESCE-TIPO-REGISTRO , :CONDESCE-SITUACAO , :CONDESCE-TIPO-COBRANCA , :CONDESCE-DATA-MOVIMENTO , :CONDESCE-DATA-AVISO , :CONDESCE-QTD-REGISTROS , :CONDESCE-PRM-TOTAL , :CONDESCE-PRM-LIQUIDO , :CONDESCE-VAL-TARIFA , :CONDESCE-VAL-BALCAO , :CONDESCE-VAL-IOCC , :CONDESCE-VAL-DESCONTO , :CONDESCE-VAL-JUROS , :CONDESCE-VAL-MULTA , CURRENT TIMESTAMP) END-EXEC. */

            var r5300_00_INSERT_CONDESCE_DB_INSERT_1_Insert1 = new R5300_00_INSERT_CONDESCE_DB_INSERT_1_Insert1()
            {
                CONDESCE_COD_EMPRESA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_EMPRESA.ToString(),
                CONDESCE_ANO_REFERENCIA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_ANO_REFERENCIA.ToString(),
                CONDESCE_MES_REFERENCIA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_MES_REFERENCIA.ToString(),
                CONDESCE_BCO_AVISO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO.ToString(),
                CONDESCE_AGE_AVISO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO.ToString(),
                CONDESCE_NUM_AVISO_CREDITO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO.ToString(),
                CONDESCE_COD_PRODUTO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO.ToString(),
                CONDESCE_TIPO_REGISTRO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_REGISTRO.ToString(),
                CONDESCE_SITUACAO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_SITUACAO.ToString(),
                CONDESCE_TIPO_COBRANCA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_COBRANCA.ToString(),
                CONDESCE_DATA_MOVIMENTO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_MOVIMENTO.ToString(),
                CONDESCE_DATA_AVISO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_AVISO.ToString(),
                CONDESCE_QTD_REGISTROS = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS.ToString(),
                CONDESCE_PRM_TOTAL = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL.ToString(),
                CONDESCE_PRM_LIQUIDO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO.ToString(),
                CONDESCE_VAL_TARIFA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA.ToString(),
                CONDESCE_VAL_BALCAO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO.ToString(),
                CONDESCE_VAL_IOCC = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_IOCC.ToString(),
                CONDESCE_VAL_DESCONTO = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_DESCONTO.ToString(),
                CONDESCE_VAL_JUROS = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_JUROS.ToString(),
                CONDESCE_VAL_MULTA = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_MULTA.ToString(),
            };

            R5300_00_INSERT_CONDESCE_DB_INSERT_1_Insert1.Execute(r5300_00_INSERT_CONDESCE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5300_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1601- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -1602- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -1603- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -1605- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1607- DISPLAY LD99-ABEND. */
            _.Display(LD99_ABEND);

            /*" -1607- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1612- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1613- DISPLAY ' ' */
            _.Display($" ");

            /*" -1614- DISPLAY 'CB6259B - FIM ANORMAL' . */
            _.Display($"CB6259B - FIM ANORMAL");

            /*" -1616- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1616- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}