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
using Sias.Bilhetes.DB2.BI6253B;

namespace Code
{
    public class BI6253B
    {
        public bool IsCall { get; set; }

        public BI6253B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  BILHETES                           *      */
        /*"      *   PROGRAMA ...............  BI6253B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA /PROGRAMADOR...  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  05/02/2013                         *      */
        /*"      *   CADMUS   ORIGEM ........  60449                              *      */
        /*"      *   VERSAO .................  V.00                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CONVENIO DE ARRECADACAO - SICAP    *      */
        /*"      *                             PRODUTOS EXTRA REDE.               *      */
        /*"      *                             CONVENIO DE ARRECADACAO - SUPERPAY *      */
        /*"      *                             CONVENIO - 021000 - ORIGEM - 1006  *      */
        /*"      *                                                                *      */
        /*"      *   A PARTIR DA LEITURA DA TABELA MOVIMENTO_COBRANCA COM         *      */
        /*"      *   TIPO_MOVIMENTO IGUAL 'Y' E SIT_REGISTRO IGUAL '0','*','4'.   *      */
        /*"      *                                                                *      */
        /*"      *   1 - BAIXA PARCELAS E GERA AVISO DE CREDITO                   *      */
        /*"      *       QUANDO SIT_REGISTRO IGUAL '0'.                           *      */
        /*"      *                                                                *      */
        /*"      *   2 - GERA ARQUIVO DE INCONSISTENCIA PARA CREDITOS REJEITADOS  *      */
        /*"      *       QUANDO SIT_REGISTRO IGUAL '*'.                           *      */
        /*"      *                                                                *      */
        /*"      *   3 - GRAVA FOLLOWUP E GERA AVISO DE CREDITO                   *      */
        /*"      *       QUANDO SIT_REGISTRO IGUAL '4'.                           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 16/04/2013    CLOVIS                             *      */
        /*"      *                             AJUSTA PROGRAMA CONFORME           *      */
        /*"      *                             SAP KIT 2.8.1                      *      */
        /*"      *                             CONVENIO - 023000 - BILHETE AUTO   *      */
        /*"      *                                                                *      */
        /*"V.02  *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 31/03/2014    COREON                             *      */
        /*"      *                             AJUSTE PARA TRATAR DEBITO EM CONTA *      */
        /*"      *                             (3) - OUTROS BANCOS                *      */
        /*"      *                             CONVENIO - 012000 - BACKSEG        *      */
        /*"      *                             PROCURE: V.02                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERADO EM 26/09/2014  DAIRO LOPES                          *      */
        /*"      *                           INCLUIR '()' PARA CONDICAO OR E AND  *      */
        /*"      *                           PROCURE: V.03                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  GILSON PINTO DA SILVA - 25/01/2024 *      */
        /*"      *   VERSAO 04               - INCLUIR A COLUNA STA_DEPOSITO_TER  *      */
        /*"      *                             NA TABELA AVISO_CREDITO PARA FAZER *      */
        /*"      *                             A CONCILIACAO DOS AVISOS DE CREDITO*      */
        /*"      *                             MANUAL COM O DEPOSITO DE TERCEIRO  *      */
        /*"      *                             (DT) NO MCP-ZE.                    *      */
        /*"      *                           - ESTA COLUNA ASSUME COMO DEFAULT O  *      */
        /*"      *                             DOMINIO 'P' (CREDITO NAO CONSUMIDO)*      */
        /*"      *                             E SOMENTE OS PROGRAMAS DO SISTEMA  *      */
        /*"      *                             "ZE" EH QUE ATUALIZARAO A MESMA.   *      */
        /*"      *                           - JAZZ - DEMANDA - 569880            *      */
        /*"      *                                    TAREFA  - 569478            *      */
        /*"      *                           - PROCURAR POR V.04                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _BI6253B1 { get; set; } = new FileBasis(new PIC("X", "350", "X(350)"));

        public FileBasis BI6253B1
        {
            get
            {
                _.Move(REG_BI6253B, _BI6253B1); VarBasis.RedefinePassValue(REG_BI6253B, _BI6253B1, REG_BI6253B); return _BI6253B1;
            }
        }
        public SortBasis<BI6253B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<BI6253B_REG_ARQSORT>(new BI6253B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public BI6253B_REG_ARQSORT REG_ARQSORT { get; set; } = new BI6253B_REG_ARQSORT();
        public class BI6253B_REG_ARQSORT : VarBasis
        {
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
            /*"  05      SOR-OCORR-HISTORICO       PIC 9(006).*/
            public IntBasis SOR_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      SOR-VAL-TITULO            PIC 9(013)V99.*/
            public DoubleBasis SOR_VAL_TITULO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SOR-VAL-CREDITO           PIC 9(013)V99.*/
            public DoubleBasis SOR_VAL_CREDITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SOR-NUM-NOSSO-TITULO      PIC 9(016).*/
            public IntBasis SOR_NUM_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      SOR-COD-PRODUTO           PIC 9(004).*/
            public IntBasis SOR_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-SIT-REGISTRO          PIC X(001).*/
            public StringBasis SOR_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SOR-IDLG.*/
            public BI6253B_SOR_IDLG SOR_IDLG { get; set; } = new BI6253B_SOR_IDLG();
            public class BI6253B_SOR_IDLG : VarBasis
            {
                /*"    10    SOR-IDLG-CONV             PIC 9(006).*/
                public IntBasis SOR_IDLG_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10    SOR-IDLG-NSA              PIC 9(006).*/
                public IntBasis SOR_IDLG_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10    SOR-IDLG-NUMAPOL          PIC 9(013).*/
                public IntBasis SOR_IDLG_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10    SOR-IDLG-NUMENDO          PIC 9(010).*/
                public IntBasis SOR_IDLG_NUMENDO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10    SOR-IDLG-NUMPARC          PIC 9(002).*/
                public IntBasis SOR_IDLG_NUMPARC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    SOR-COD-ERRO              PIC X(004).*/
                public StringBasis SOR_COD_ERRO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"01        REG-BI6253B                 PIC  X(350).*/
            }
        }
        public StringBasis REG_BI6253B { get; set; } = new StringBasis(new PIC("X", "350", "X(350)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_VEN { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_ERR { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77    VIND-NRAVISO              PIC S9(004)     COMP.*/
        public IntBasis VIND_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COUNT                PIC S9(004)     COMP.*/
        public IntBasis VIND_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTRETORNO            PIC S9(004)     COMP.*/
        public IntBasis VIND_DTRETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODRET               PIC S9(004)     COMP.*/
        public IntBasis VIND_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-USUARIO              PIC S9(004)     COMP.*/
        public IntBasis VIND_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTCREDITO            PIC S9(004)     COMP.*/
        public IntBasis VIND_DTCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VLRCREDITO           PIC S9(004)     COMP.*/
        public IntBasis VIND_VLRCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTLIBER              PIC S9(004)     COMP.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTQITBCO             PIC S9(004)     COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODEMP               PIC S9(004)     COMP.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ORDLIDER             PIC S9(004)     COMP.*/
        public IntBasis VIND_ORDLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TIPSGU               PIC S9(004)     COMP.*/
        public IntBasis VIND_TIPSGU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-APOLIDER             PIC S9(004)     COMP.*/
        public IntBasis VIND_APOLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ENDOSLID             PIC S9(004)     COMP.*/
        public IntBasis VIND_ENDOSLID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODLIDER             PIC S9(004)     COMP.*/
        public IntBasis VIND_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-FONTE                PIC S9(004)     COMP.*/
        public IntBasis VIND_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRRCAP               PIC S9(004)     COMP.*/
        public IntBasis VIND_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W.*/
        public BI6253B_W W { get; set; } = new BI6253B_W();
        public class BI6253B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-SORT                 PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-MOVIMCOB               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_MOVIMCOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-CONVENIO               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_CONVENIO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-REGISTRO               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_REGISTRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DATA                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_DATA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-REJEITA                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_REJEITA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-DUPLICA                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_DUPLICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  NT-BILHETE                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis NT_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  NT-PARCELA                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis NT_PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SORT                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SAIDA                  PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_SAIDA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WTEM-PROPOSTA             PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  UP-PROPOSTA               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis UP_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-MOVDEBCE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis UP_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-SORT                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  ATU-COD-PRODUTO           PIC  9(004)         VALUE ZEROS.*/
            public IntBasis ATU_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  ANT-COD-PRODUTO           PIC  9(004)         VALUE ZEROS.*/
            public IntBasis ANT_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  AUX-VALOR                 PIC S9(013)V99      COMP-3.*/
            public DoubleBasis AUX_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  AC-AVISOCRE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_AVISOCRE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-AVISOSAL               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_AVISOSAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-CONDESCE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_CONDESCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-EMITE                  PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_EMITE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-FOLLOWUP               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_FOLLOWUP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         WS-CHAVE-ATU.*/
            public BI6253B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new BI6253B_WS_CHAVE_ATU();
            public class BI6253B_WS_CHAVE_ATU : VarBasis
            {
                /*"    05       ATU-COD-BANCO       PIC  9(004).*/
                public IntBasis ATU_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ATU-COD-AGENCIA     PIC  9(004).*/
                public IntBasis ATU_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ATU-DTQITBCO        PIC  X(010).*/
                public StringBasis ATU_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  03         WS-CHAVE-ANT.*/
            }
            public BI6253B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new BI6253B_WS_CHAVE_ANT();
            public class BI6253B_WS_CHAVE_ANT : VarBasis
            {
                /*"    05       ANT-COD-BANCO       PIC  9(004).*/
                public IntBasis ANT_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ANT-COD-AGENCIA     PIC  9(004).*/
                public IntBasis ANT_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ANT-DTQITBCO        PIC  X(010).*/
                public StringBasis ANT_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI6253B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI6253B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI6253B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI6253B_FILLER_0 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-CABEC.*/

                public _REDEF_BI6253B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public BI6253B_WDATA_CABEC WDATA_CABEC { get; set; } = new BI6253B_WDATA_CABEC();
            public class BI6253B_WDATA_CABEC : VarBasis
            {
                /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WS-SEGURADO.*/
            }
            public BI6253B_WS_SEGURADO WS_SEGURADO { get; set; } = new BI6253B_WS_SEGURADO();
            public class BI6253B_WS_SEGURADO : VarBasis
            {
                /*"    10       WS-IDLG-CONV      PIC  9(006).*/
                public IntBasis WS_IDLG_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       WS-IDLG-NSA       PIC  9(005).*/
                public IntBasis WS_IDLG_NSA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10       WS-IDLG-NUMAPOL   PIC  9(013).*/
                public IntBasis WS_IDLG_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       WS-IDLG-NUMENDO   PIC  9(010).*/
                public IntBasis WS_IDLG_NUMENDO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       WS-IDLG-NUMPARC   PIC  9(002).*/
                public IntBasis WS_IDLG_NUMPARC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS-IDLG-ERRO      PIC  X(004).*/
                public StringBasis WS_IDLG_ERRO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  03         WS-STATUS.*/
            }
            public BI6253B_WS_STATUS WS_STATUS { get; set; } = new BI6253B_WS_STATUS();
            public class BI6253B_WS_STATUS : VarBasis
            {
                /*"    10       WS-STA-VENDA      PIC  9(002).*/
                public IntBasis WS_STA_VENDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS-TRACO          PIC  X(003).*/
                public StringBasis WS_TRACO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10       WS-COD-ERRO       PIC  X(004).*/
                public StringBasis WS_COD_ERRO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_BI6253B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_BI6253B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_BI6253B_FILLER_6(); _.Move(WTIME_DAY, _filler_6); VarBasis.RedefinePassValue(WTIME_DAY, _filler_6, WTIME_DAY); _filler_6.ValueChanged += () => { _.Move(_filler_6, WTIME_DAY); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_BI6253B_FILLER_6 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public BI6253B_WTIME_DAYR WTIME_DAYR { get; set; } = new BI6253B_WTIME_DAYR();
                public class BI6253B_WTIME_DAYR : VarBasis
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

                    public BI6253B_WTIME_DAYR()
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

                public _REDEF_BI6253B_FILLER_6()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public BI6253B_WS_TIME WS_TIME { get; set; } = new BI6253B_WS_TIME();
            public class BI6253B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01            AUX-RELATORIO.*/
            }
        }
        public BI6253B_AUX_RELATORIO AUX_RELATORIO { get; set; } = new BI6253B_AUX_RELATORIO();
        public class BI6253B_AUX_RELATORIO : VarBasis
        {
            /*"  03          LC00.*/
            public BI6253B_LC00 LC00 { get; set; } = new BI6253B_LC00();
            public class BI6253B_LC00 : VarBasis
            {
                /*"    10        FILLER              PIC  X(008)  VALUE             'CONVENIO'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CONVENIO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(016)  VALUE             'PROPOSTA'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"PROPOSTA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(011)  VALUE             'BILHETE'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"BILHETE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'PAGAMENTO'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PAGAMENTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'CREDITO'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CREDITO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'NSA RET.'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"NSA RET.");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             '         VALOR'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"         VALOR");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PRODUTO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(013)  VALUE             'APOLICE'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'ENDOSSO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"ENDOSSO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PARCELA'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PARCELA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(041)  VALUE             'IDLG    '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"IDLG    ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'STATUS'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"STATUS");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(060)  VALUE             'MENSAGEM1'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"MENSAGEM1");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(060)  VALUE             'MENSAGEM2'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"MENSAGEM2");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"  03          LD01.*/
            }
            public BI6253B_LD01 LD01 { get; set; } = new BI6253B_LD01();
            public class BI6253B_LD01 : VarBasis
            {
                /*"    10        LD01-CONVENIO       PIC  ZZZZZZZ9.*/
                public IntBasis LD01_CONVENIO { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PROPOSTA       PIC  ZZZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "ZZZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-BILHETE        PIC  ZZZZZZZZZZ9.*/
                public IntBasis LD01_BILHETE { get; set; } = new IntBasis(new PIC("9", "11", "ZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTPAGTO        PIC  X(010).*/
                public StringBasis LD01_DTPAGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTCREDITO      PIC  X(010).*/
                public StringBasis LD01_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NSAS           PIC  ZZZZZZZ9.*/
                public IntBasis LD01_NSAS { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VALOR          PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-CODPRODU       PIC  ZZZZZZ9.*/
                public IntBasis LD01_CODPRODU { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-APOLICE        PIC  ZZZZZZZZZZZZ9.*/
                public IntBasis LD01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ENDOSSO        PIC  ZZZZZZZZ9.*/
                public IntBasis LD01_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PARCELA        PIC  ZZZZZZ9.*/
                public IntBasis LD01_PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IDLG           PIC  X(041).*/
                public StringBasis LD01_IDLG { get; set; } = new StringBasis(new PIC("X", "41", "X(041)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-STATUS         PIC  X(010).*/
                public StringBasis LD01_STATUS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-MENSAGEM1      PIC  X(060).*/
                public StringBasis LD01_MENSAGEM1 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-MENSAGEM2      PIC  X(060).*/
                public StringBasis LD01_MENSAGEM2 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"  03        WABEND.*/
            }
            public BI6253B_WABEND WABEND { get; set; } = new BI6253B_WABEND();
            public class BI6253B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' BI6253B  '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI6253B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      WSQLERRO.*/
                public BI6253B_WSQLERRO WSQLERRO { get; set; } = new BI6253B_WSQLERRO();
                public class BI6253B_WSQLERRO : VarBasis
                {
                    /*"      10    FILLER               PIC  X(014) VALUE            ' *** SQLERRMC '.*/
                    public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                    /*"      10    WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                    public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                    /*"01          LD99-ABEND.*/
                }
            }
        }
        public BI6253B_LD99_ABEND LD99_ABEND { get; set; } = new BI6253B_LD99_ABEND();
        public class BI6253B_LD99_ABEND : VarBasis
        {
            /*"      10    FILLER              PIC  X(050) VALUE           ' REINICIAR JOB NO PROXIMO STEP               '.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" REINICIAR JOB NO PROXIMO STEP               ");
            /*"01  TABELA-VENDAS-ERNET.*/
        }
        public BI6253B_TABELA_VENDAS_ERNET TABELA_VENDAS_ERNET { get; set; } = new BI6253B_TABELA_VENDAS_ERNET();
        public class BI6253B_TABELA_VENDAS_ERNET : VarBasis
        {
            /*"  03         TB-RET-VENDAS.*/
            public BI6253B_TB_RET_VENDAS TB_RET_VENDAS { get; set; } = new BI6253B_TB_RET_VENDAS();
            public class BI6253B_TB_RET_VENDAS : VarBasis
            {
                /*"    05       FILLER            PIC  X(060)    VALUE     '00 TRANSACAO OK (TRANSACAO ACEITA)                      '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"00 TRANSACAO OK (TRANSACAO ACEITA)                      ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '01 ERRO NO ARQUIVO                                      '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"01 ERRO NO ARQUIVO                                      ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '02 CODIGO DE AUTORIZACAO INVALIDO                       '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"02 CODIGO DE AUTORIZACAO INVALIDO                       ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '03 ESTABELECIMENTO INVALIDO                             '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"03 ESTABELECIMENTO INVALIDO                             ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '04 LOTE MISTURADO                                       '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"04 LOTE MISTURADO                                       ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '05 NUMERO DE PARCELAS INVALIDO                          '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"05 NUMERO DE PARCELAS INVALIDO                          ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '06 DIFERENCA DE VALOR NO RO                             '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"06 DIFERENCA DE VALOR NO RO                             ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '07 NUMERO DO RO INVALIDO (REGISTRO BH)                  '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"07 NUMERO DO RO INVALIDO (REGISTRO BH)                  ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '08 VALOR DE ENTRADA INVALIDO                            '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"08 VALOR DE ENTRADA INVALIDO                            ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '09 VALOR DA TAXA DE EMBARQUE INVALIDO                   '.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"09 VALOR DA TAXA DE EMBARQUE INVALIDO                   ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '10 VALOR DA PARCELA INVALIDO                            '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"10 VALOR DA PARCELA INVALIDO                            ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '11 CODIGO DE TRANSACAO INVALIDO                         '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"11 CODIGO DE TRANSACAO INVALIDO                         ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '12 TRANSACAO INVALIDA                                   '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"12 TRANSACAO INVALIDA                                   ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '13 VALOR INVALIDO                                       '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"13 VALOR INVALIDO                                       ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '14 NUMERO DO CARTAO INVALIDO                            '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"14 NUMERO DO CARTAO INVALIDO                            ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '15 VALOR DO CANCELAMENTO INVALIDO                       '.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"15 VALOR DO CANCELAMENTO INVALIDO                       ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '16 TRANSACAO ORIGINAL NAO LOCALIZADA PARA CANCELAMENTO  '.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"16 TRANSACAO ORIGINAL NAO LOCALIZADA PARA CANCELAMENTO  ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '17 ITENS INFORMADOS NO RO NAO COMPATIVEL COM OS CVS     '.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"17 ITENS INFORMADOS NO RO NAO COMPATIVEL COM OS CVS     ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '18 NUMERO DE REFERENCIA INVALIDO                        '.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"18 NUMERO DE REFERENCIA INVALIDO                        ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '20 CANCELAMENTO PARA PARCELADO DE TRANSACAO JA CANCELADA'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"20 CANCELAMENTO PARA PARCELADO DE TRANSACAO JA CANCELADA");
                /*"    05       FILLER            PIC  X(060)    VALUE     '21 VALOR DO CANCELAMENTO MAIOR QUE O VALOR DA VENDA     '.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"21 VALOR DO CANCELAMENTO MAIOR QUE O VALOR DA VENDA     ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '22 VALOR DO CANCELAMENTO MAIOR QUE O PERMITIDO (ALCADA) '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"22 VALOR DO CANCELAMENTO MAIOR QUE O PERMITIDO (ALCADA) ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '23 NUMERO DO RO ORIGINAL INVALIDO (REGISTRO I2)         '.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"23 NUMERO DO RO ORIGINAL INVALIDO (REGISTRO I2)         ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '42 CARTAO EM BOLETIM                                    '.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"42 CARTAO EM BOLETIM                                    ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '54 NAO PERMITIDO CANCELAMENTO PARCIAL DE PLANO PARCELADO'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"54 NAO PERMITIDO CANCELAMENTO PARCIAL DE PLANO PARCELADO");
                /*"    05       FILLER            PIC  X(060)    VALUE     '55 DEBITO EFETUADO, CONFORME CONTESTACAO DO PORTADOR    '.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"55 DEBITO EFETUADO, CONFORME CONTESTACAO DO PORTADOR    ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '56 TIPO DE PLANO DE CARTAO INVALIDO                     '.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"56 TIPO DE PLANO DE CARTAO INVALIDO                     ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '59 TIPO CARTAO INVALIDO                                 '.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"59 TIPO CARTAO INVALIDO                                 ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '60 DATA INVALIDA                                        '.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"60 DATA INVALIDA                                        ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '71 TRANSACAO REJEITADA PELO BANCO EMISSOR               '.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"71 TRANSACAO REJEITADA PELO BANCO EMISSOR               ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '72 TRANSACAO REJEITADA PELO BANCO EMISSOR               '.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"72 TRANSACAO REJEITADA PELO BANCO EMISSOR               ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '73 CARTAO COM PROBLEMA - RETER O CARTAO                 '.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"73 CARTAO COM PROBLEMA - RETER O CARTAO                 ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '74 AUTORIZACAO NEGADA                                   '.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"74 AUTORIZACAO NEGADA                                   ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '75 ERRO (POS)                                           '.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"75 ERRO (POS)                                           ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '76 RETER O CARTAO - CONDICAO ESPECIAL                   '.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"76 RETER O CARTAO - CONDICAO ESPECIAL                   ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '77 ERRO DE SINTAXE - REFACA A TRANSACAO                 '.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"77 ERRO DE SINTAXE - REFACA A TRANSACAO                 ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '78 NAO FOI ENCONTRADA AUTORIZACAO NO EMISSOR            '.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"78 NAO FOI ENCONTRADA AUTORIZACAO NO EMISSOR            ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '79 CARTAO PERDIDO - RETER O CARTAO                      '.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"79 CARTAO PERDIDO - RETER O CARTAO                      ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '80 CARTAO ROUBADO - RETER O CARTAO                      '.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"80 CARTAO ROUBADO - RETER O CARTAO                      ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '81 FUNDOS INSUFICIENTES                                 '.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"81 FUNDOS INSUFICIENTES                                 ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '82 CARTAO VENCIDO OU DATA DO VENCIMENTO ERRADA          '.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"82 CARTAO VENCIDO OU DATA DO VENCIMENTO ERRADA          ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '83 SENHA INCORRETA                                      '.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"83 SENHA INCORRETA                                      ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '86 EXCEDEU O NUMERO DE SAQUES NO PERIODO                '.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"86 EXCEDEU O NUMERO DE SAQUES NO PERIODO                ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '87 CARTAO RESTRITO                                      '.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"87 CARTAO RESTRITO                                      ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '88 EXCEDEU O NUMERO DE TRANSACOES NO PERIODO            '.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"88 EXCEDEU O NUMERO DE TRANSACOES NO PERIODO            ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '89 MENSAGEM DIFERE DA MENSAGEM ORIGINAL                 '.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"89 MENSAGEM DIFERE DA MENSAGEM ORIGINAL                 ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '90 CVV INVALIDO                                         '.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"90 CVV INVALIDO                                         ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '91 IMPOSSIVEL VERIFICAR SENHA                           '.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"91 IMPOSSIVEL VERIFICAR SENHA                           ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '92 BANCO EMISSOR SEM COMUNICACAO                        '.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"92 BANCO EMISSOR SEM COMUNICACAO                        ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '93 CANCELAMENTO COM MAIS DE 300 DIAS                    '.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"93 CANCELAMENTO COM MAIS DE 300 DIAS                    ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '94 DUPLICIDADE DE LINHAS AEREAS                         '.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"94 DUPLICIDADE DE LINHAS AEREAS                         ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '95 SEM SALDO EM ABERTO                                  '.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"95 SEM SALDO EM ABERTO                                  ");
                /*"    05       FILLER            PIC  X(060)    VALUE     '99 OUTROS MOTIVOS                                       '.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"99 OUTROS MOTIVOS                                       ");
                /*"  03         FILLER            REDEFINES      TB-RET-VENDAS.*/
            }
            private _REDEF_BI6253B_FILLER_112 _filler_112 { get; set; }
            public _REDEF_BI6253B_FILLER_112 FILLER_112
            {
                get { _filler_112 = new _REDEF_BI6253B_FILLER_112(); _.Move(TB_RET_VENDAS, _filler_112); VarBasis.RedefinePassValue(TB_RET_VENDAS, _filler_112, TB_RET_VENDAS); _filler_112.ValueChanged += () => { _.Move(_filler_112, TB_RET_VENDAS); }; return _filler_112; }
                set { VarBasis.RedefinePassValue(value, _filler_112, TB_RET_VENDAS); }
            }  //Redefines
            public class _REDEF_BI6253B_FILLER_112 : VarBasis
            {
                /*"    05       TB-OCORREVEN      OCCURS         53 TIMES                               INDEXED  BY    WS-VEN.*/
                public ListBasis<BI6253B_TB_OCORREVEN> TB_OCORREVEN { get; set; } = new ListBasis<BI6253B_TB_OCORREVEN>(53);
                public class BI6253B_TB_OCORREVEN : VarBasis
                {
                    /*"      10     VEN-CODIGO        PIC            9(002).*/
                    public IntBasis VEN_CODIGO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      10     FILLER            PIC            X(001).*/
                    public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     VEN-DESCRICAO     PIC            X(057).*/
                    public StringBasis VEN_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "57", "X(057)."), @"");
                    /*"01  TABELA-ERRO-ERNET.*/

                    public BI6253B_TB_OCORREVEN()
                    {
                        VEN_CODIGO.ValueChanged += OnValueChanged;
                        FILLER_113.ValueChanged += OnValueChanged;
                        VEN_DESCRICAO.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_BI6253B_FILLER_112()
                {
                    TB_OCORREVEN.ValueChanged += OnValueChanged;
                }

            }
        }
        public BI6253B_TABELA_ERRO_ERNET TABELA_ERRO_ERNET { get; set; } = new BI6253B_TABELA_ERRO_ERNET();
        public class BI6253B_TABELA_ERRO_ERNET : VarBasis
        {
            /*"  03         TB-RET-ERRO.*/
            public BI6253B_TB_RET_ERRO TB_RET_ERRO { get; set; } = new BI6253B_TB_RET_ERRO();
            public class BI6253B_TB_RET_ERRO : VarBasis
            {
                /*"    05       FILLER            PIC  X(060)    VALUE     'E900 TIPO DE REGISTRO INVALIDO                          '.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E900 TIPO DE REGISTRO INVALIDO                          ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E901 DATA DO DEPOSITO DO HEADER INVALIDA                '.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E901 DATA DO DEPOSITO DO HEADER INVALIDA                ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E902 NUMERO DO RESUMO DE OPERACOES DO HEADER INVALIDO   '.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E902 NUMERO DO RESUMO DE OPERACOES DO HEADER INVALIDO   ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E903 NUMERO DO ESTABELECIMENTO DO HEADER INVALIDO       '.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E903 NUMERO DO ESTABELECIMENTO DO HEADER INVALIDO       ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E904 MOEDA DO HEADER INVALIDA                           '.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E904 MOEDA DO HEADER INVALIDA                           ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E905 INDICADOR DE TESTE DO HEADER INVALIDO              '.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E905 INDICADOR DE TESTE DO HEADER INVALIDO              ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E906 INDICADOR DE VENDA DO HEADER INVALIDO              '.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E906 INDICADOR DE VENDA DO HEADER INVALIDO              ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E911 NUMERO DO COMPROVANTE DE VENDA (CV) INVALIDO       '.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E911 NUMERO DO COMPROVANTE DE VENDA (CV) INVALIDO       ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E912 DATA DA VENDA INVALIDA                             '.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E912 DATA DA VENDA INVALIDA                             ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E913 OPCAO DA VENDA INVALIDA                            '.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E913 OPCAO DA VENDA INVALIDA                            ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E914 NUMERO DO CARTAO INVALIDO                          '.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E914 NUMERO DO CARTAO INVALIDO                          ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E915 VALOR DA VENDA INVALIDO                            '.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E915 VALOR DA VENDA INVALIDO                            ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E916 QUANTIDADE DE PARCELAS INVALIDA                    '.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E916 QUANTIDADE DE PARCELAS INVALIDA                    ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E917 VALOR FINANCIADO INVALIDO                          '.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E917 VALOR FINANCIADO INVALIDO                          ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E918 VALOR DA ENTRADA INVALIDO                          '.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E918 VALOR DA ENTRADA INVALIDO                          ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E919 VALOR DA TAXA EMBARQUE INVALIDO                    '.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E919 VALOR DA TAXA EMBARQUE INVALIDO                    ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E920 VALOR DA PARCELA INVALIDO                          '.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E920 VALOR DA PARCELA INVALIDO                          ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E921 NUMERO DO RESUMO DE OPERACOES INVALIDO             '.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E921 NUMERO DO RESUMO DE OPERACOES INVALIDO             ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E922 NUMERO DO ESTABELECIMENTO INVALIDO                 '.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E922 NUMERO DO ESTABELECIMENTO INVALIDO                 ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E923 VALIDADE DO CARTAO INVALIDO                        '.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E923 VALIDADE DO CARTAO INVALIDO                        ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E924 NUMERO DO CARTAO DE OPERACOES ORIGINAL INVALIDO    '.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E924 NUMERO DO CARTAO DE OPERACOES ORIGINAL INVALIDO    ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E925 VALOR DO REEMBOLSO INVALIDO                        '.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E925 VALOR DO REEMBOLSO INVALIDO                        ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E926 NUMERO DE REFERENCIA INVALIDO                      '.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E926 NUMERO DE REFERENCIA INVALIDO                      ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E930 QUANTIDADE DE REGISTROS DO TRAILER NAO CONFERE     '.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E930 QUANTIDADE DE REGISTROS DO TRAILER NAO CONFERE     ");
                /*"    05       FILLER            PIC  X(060)    VALUE     'E931 VALOR TOTAL BRUTO NAO CONFERE                      '.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"E931 VALOR TOTAL BRUTO NAO CONFERE                      ");
                /*"  03         FILLER            REDEFINES      TB-RET-ERRO.*/
            }
            private _REDEF_BI6253B_FILLER_139 _filler_139 { get; set; }
            public _REDEF_BI6253B_FILLER_139 FILLER_139
            {
                get { _filler_139 = new _REDEF_BI6253B_FILLER_139(); _.Move(TB_RET_ERRO, _filler_139); VarBasis.RedefinePassValue(TB_RET_ERRO, _filler_139, TB_RET_ERRO); _filler_139.ValueChanged += () => { _.Move(_filler_139, TB_RET_ERRO); }; return _filler_139; }
                set { VarBasis.RedefinePassValue(value, _filler_139, TB_RET_ERRO); }
            }  //Redefines
            public class _REDEF_BI6253B_FILLER_139 : VarBasis
            {
                /*"    05       TB-OCORRECOD      OCCURS         25 TIMES                               INDEXED  BY    WS-ERR.*/
                public ListBasis<BI6253B_TB_OCORRECOD> TB_OCORRECOD { get; set; } = new ListBasis<BI6253B_TB_OCORRECOD>(25);
                public class BI6253B_TB_OCORRECOD : VarBasis
                {
                    /*"      10     ERR-CODIGO        PIC            X(004).*/
                    public StringBasis ERR_CODIGO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"      10     FILLER            PIC            X(001).*/
                    public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     ERR-DESCRICAO     PIC            X(055).*/
                    public StringBasis ERR_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "55", "X(055)."), @"");

                    public BI6253B_TB_OCORRECOD()
                    {
                        ERR_CODIGO.ValueChanged += OnValueChanged;
                        FILLER_140.ValueChanged += OnValueChanged;
                        ERR_DESCRICAO.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_BI6253B_FILLER_139()
                {
                    TB_OCORRECOD.ValueChanged += OnValueChanged;
                }

            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.AVISOCRE AVISOCRE { get; set; } = new Dclgens.AVISOCRE();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
        public Dclgens.CONDESCE CONDESCE { get; set; } = new Dclgens.CONDESCE();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.FOLLOUP FOLLOUP { get; set; } = new Dclgens.FOLLOUP();
        public Dclgens.PROPOSTA PROPOSTA { get; set; } = new Dclgens.PROPOSTA();
        public BI6253B_V0MOVIMCOB V0MOVIMCOB { get; set; } = new BI6253B_V0MOVIMCOB();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P, string BI6253B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);
                BI6253B1.SetFile(BI6253B1_FILE_NAME_P);

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
            /*" -558- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -559- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -561- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -563- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -566- DISPLAY '--------------------------------' . */
            _.Display($"--------------------------------");

            /*" -567- DISPLAY ' PROGRAMA EM EXECUCAO BI6253B   ' . */
            _.Display($" PROGRAMA EM EXECUCAO BI6253B   ");

            /*" -568- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -569- DISPLAY ' VERSAO V.00         08/08/2013 ' . */
            _.Display($" VERSAO V.00         08/08/2013 ");

            /*" -572- DISPLAY '--------------------------------' . */
            _.Display($"--------------------------------");

            /*" -575- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -586- SORT ARQSORT ON ASCENDING KEY SOR-COD-BANCO SOR-COD-AGENCIA SOR-DATA-QUITACAO SOR-COD-PRODUTO INPUT PROCEDURE R0200-00-INPUT-SORT THRU R0200-99-SAIDA OUTPUT PROCEDURE R0450-00-OUTPUT-SORT THRU R0450-99-SAIDA. */
            ARQSORT.Sort("SOR-COD-BANCO,SOR-COD-AGENCIA,SOR-DATA-QUITACAO,SOR-COD-PRODUTO", () => R0200_00_INPUT_SORT_SECTION(), () => R0450_00_OUTPUT_SORT_SECTION());

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -591- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -595- CLOSE BI6253B1. */
            BI6253B1.Close();

            /*" -597- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -598- DISPLAY ' ' */
            _.Display($" ");

            /*" -599- DISPLAY 'BI6253B - FIM NORMAL' . */
            _.Display($"BI6253B - FIM NORMAL");

            /*" -602- DISPLAY ' ' . */
            _.Display($" ");

            /*" -602- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -615- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -617- OPEN OUTPUT BI6253B1. */
            BI6253B1.Open(REG_BI6253B);

            /*" -619- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -621- DISPLAY ' DATA DO PROCESSAMENTO ...............  ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($" DATA DO PROCESSAMENTO ...............  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -624- DISPLAY ' ' . */
            _.Display($" ");

            /*" -624- WRITE REG-BI6253B FROM LC00. */
            _.Move(AUX_RELATORIO.LC00.GetMoveValues(), REG_BI6253B);

            BI6253B1.Write(REG_BI6253B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -637- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -643- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -646- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -647- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -650- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -651- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -643- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

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
            /*" -663- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -664- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -666- PERFORM R0300-00-DECLARE-MOVIMCOB. */

            R0300_00_DECLARE_MOVIMCOB_SECTION();

            /*" -668- PERFORM R0310-00-FETCH-MOVIMCOB. */

            R0310_00_FETCH_MOVIMCOB_SECTION();

            /*" -672- PERFORM R0350-00-PROCESSA-MOVIMCOB UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_MOVIMCOB_SECTION();
            }

            /*" -673- DISPLAY ' ' . */
            _.Display($" ");

            /*" -674- DISPLAY 'LIDOS MOVIMCOB ............. ' LD-MOVIMCOB. */
            _.Display($"LIDOS MOVIMCOB ............. {W.LD_MOVIMCOB}");

            /*" -675- DISPLAY 'DESPREZA CONVENIO .......... ' DP-CONVENIO. */
            _.Display($"DESPREZA CONVENIO .......... {W.DP_CONVENIO}");

            /*" -676- DISPLAY 'DESPREZA REGISTRO .......... ' DP-REGISTRO. */
            _.Display($"DESPREZA REGISTRO .......... {W.DP_REGISTRO}");

            /*" -677- DISPLAY 'TRATA REJEITADOS ........... ' AC-REJEITA. */
            _.Display($"TRATA REJEITADOS ........... {W.AC_REJEITA}");

            /*" -678- DISPLAY 'DESPREZA DATA .............. ' DP-DATA. */
            _.Display($"DESPREZA DATA .............. {W.DP_DATA}");

            /*" -679- DISPLAY 'SEM   PROPOSTA ............. ' NT-BILHETE. */
            _.Display($"SEM   PROPOSTA ............. {W.NT_BILHETE}");

            /*" -680- DISPLAY 'PARCELA NAO CADASTRADA ..... ' NT-PARCELA. */
            _.Display($"PARCELA NAO CADASTRADA ..... {W.NT_PARCELA}");

            /*" -681- DISPLAY 'GRAVADOS SORT .............. ' GV-SORT. */
            _.Display($"GRAVADOS SORT .............. {W.GV_SORT}");

            /*" -681- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-SECTION */
        private void R0300_00_DECLARE_MOVIMCOB_SECTION()
        {
            /*" -694- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -719- PERFORM R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1 */

            R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1();

            /*" -721- PERFORM R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1 */

            R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1();

            /*" -725- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -726- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (MOVIMCOB)   ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (MOVIMCOB)   ");

                /*" -726- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-DB-DECLARE-1 */
        public void R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1()
        {
            /*" -719- EXEC SQL DECLARE V0MOVIMCOB CURSOR WITH HOLD FOR SELECT COD_EMPRESA , COD_MOVIMENTO , COD_BANCO , COD_AGENCIA , NUM_AVISO , NUM_FITA , DATA_MOVIMENTO , DATA_QUITACAO , NUM_TITULO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , VAL_TITULO , VAL_CREDITO , SIT_REGISTRO , NOME_SEGURADO , NUM_NOSSO_TITULO , TIPO_MOVIMENTO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE SIT_REGISTRO IN ( '0' , '*' , '4' ) AND TIPO_MOVIMENTO = 'Y' FOR UPDATE OF SIT_REGISTRO END-EXEC. */
            V0MOVIMCOB = new BI6253B_V0MOVIMCOB(false);
            string GetQuery_V0MOVIMCOB()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							COD_MOVIMENTO
							, 
							COD_BANCO
							, 
							COD_AGENCIA
							, 
							NUM_AVISO
							, 
							NUM_FITA
							, 
							DATA_MOVIMENTO
							, 
							DATA_QUITACAO
							, 
							NUM_TITULO
							, 
							NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							NUM_PARCELA
							, 
							VAL_TITULO
							, 
							VAL_CREDITO
							, 
							SIT_REGISTRO
							, 
							NOME_SEGURADO
							, 
							NUM_NOSSO_TITULO
							, 
							TIPO_MOVIMENTO 
							FROM SEGUROS.MOVIMENTO_COBRANCA 
							WHERE SIT_REGISTRO IN ( '0'
							, '*'
							, '4' ) 
							AND TIPO_MOVIMENTO = 'Y'";

                return query;
            }
            V0MOVIMCOB.GetQueryEvent += GetQuery_V0MOVIMCOB;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-DB-OPEN-1 */
        public void R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1()
        {
            /*" -721- EXEC SQL OPEN V0MOVIMCOB END-EXEC. */

            V0MOVIMCOB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-SECTION */
        private void R0310_00_FETCH_MOVIMCOB_SECTION()
        {
            /*" -739- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -758- PERFORM R0310_00_FETCH_MOVIMCOB_DB_FETCH_1 */

            R0310_00_FETCH_MOVIMCOB_DB_FETCH_1();

            /*" -762- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -762- PERFORM R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1 */

                R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1();

                /*" -764- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -766- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -767- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -768- DISPLAY 'R0310-00 - PROBLEMAS FETCH   (MOVIMCOB)   ' */
                _.Display($"R0310-00 - PROBLEMAS FETCH   (MOVIMCOB)   ");

                /*" -769- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -770- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -771- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -772- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -773- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -774- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -775- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -776- DISPLAY 'NUM_APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM_APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -777- DISPLAY 'NUM_ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -780- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -780- ADD 1 TO LD-MOVIMCOB. */
            W.LD_MOVIMCOB.Value = W.LD_MOVIMCOB + 1;

        }

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-DB-FETCH-1 */
        public void R0310_00_FETCH_MOVIMCOB_DB_FETCH_1()
        {
            /*" -758- EXEC SQL FETCH V0MOVIMCOB INTO :MOVIMCOB-COD-EMPRESA , :MOVIMCOB-COD-MOVIMENTO , :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-NUM-FITA , :MOVIMCOB-DATA-MOVIMENTO , :MOVIMCOB-DATA-QUITACAO , :MOVIMCOB-NUM-TITULO , :MOVIMCOB-NUM-APOLICE , :MOVIMCOB-NUM-ENDOSSO , :MOVIMCOB-NUM-PARCELA , :MOVIMCOB-VAL-TITULO , :MOVIMCOB-VAL-CREDITO , :MOVIMCOB-SIT-REGISTRO , :MOVIMCOB-NOME-SEGURADO , :MOVIMCOB-NUM-NOSSO-TITULO , :MOVIMCOB-TIPO-MOVIMENTO END-EXEC. */

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
                _.Move(V0MOVIMCOB.MOVIMCOB_VAL_CREDITO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);
                _.Move(V0MOVIMCOB.MOVIMCOB_SIT_REGISTRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NOME_SEGURADO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_NOSSO_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);
                _.Move(V0MOVIMCOB.MOVIMCOB_TIPO_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-DB-CLOSE-1 */
        public void R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1()
        {
            /*" -762- EXEC SQL CLOSE V0MOVIMCOB END-EXEC */

            V0MOVIMCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-MOVIMCOB-SECTION */
        private void R0350_00_PROCESSA_MOVIMCOB_SECTION()
        {
            /*" -797- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -799- IF MOVIMCOB-COD-BANCO EQUAL ZEROS OR MOVIMCOB-COD-AGENCIA EQUAL ZEROS */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO == 00 || MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA == 00)
            {

                /*" -800- ADD 1 TO DP-REGISTRO */
                W.DP_REGISTRO.Value = W.DP_REGISTRO + 1;

                /*" -802- MOVE 'REGISTRO NAO PREVISTO ' TO LD01-MENSAGEM1 */
                _.Move("REGISTRO NAO PREVISTO ", AUX_RELATORIO.LD01.LD01_MENSAGEM1);

                /*" -803- PERFORM R1400-00-NAO-PREVISTO */

                R1400_00_NAO_PREVISTO_SECTION();

                /*" -806- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -808- IF MOVIMCOB-SIT-REGISTRO EQUAL '0' AND MOVIMCOB-COD-MOVIMENTO NOT EQUAL ZEROS */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO == "0" && MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO != 00)
            {

                /*" -809- ADD 1 TO DP-REGISTRO */
                W.DP_REGISTRO.Value = W.DP_REGISTRO + 1;

                /*" -811- MOVE 'REGISTRO NAO PREVISTO ' TO LD01-MENSAGEM1 */
                _.Move("REGISTRO NAO PREVISTO ", AUX_RELATORIO.LD01.LD01_MENSAGEM1);

                /*" -812- PERFORM R1400-00-NAO-PREVISTO */

                R1400_00_NAO_PREVISTO_SECTION();

                /*" -815- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -817- IF (MOVIMCOB-NUM-AVISO EQUAL 23000 OR 12000) AND MOVIMCOB-NOME-SEGURADO EQUAL SPACES */

            if ((MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.In("23000", "12000")) && MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO.IsEmpty())
            {

                /*" -818- ADD 1 TO DP-REGISTRO */
                W.DP_REGISTRO.Value = W.DP_REGISTRO + 1;

                /*" -820- MOVE 'REGISTRO NAO PREVISTO ' TO LD01-MENSAGEM1 */
                _.Move("REGISTRO NAO PREVISTO ", AUX_RELATORIO.LD01.LD01_MENSAGEM1);

                /*" -821- PERFORM R1400-00-NAO-PREVISTO */

                R1400_00_NAO_PREVISTO_SECTION();

                /*" -831- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -832- IF MOVIMCOB-NUM-AVISO EQUAL 21000 */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO == 21000)
            {

                /*" -834- MOVE SPACES TO SOR-IDLG WS-SEGURADO */
                _.Move("", REG_ARQSORT.SOR_IDLG, W.WS_SEGURADO);

                /*" -835- ELSE */
            }
            else
            {


                /*" -836- IF MOVIMCOB-NUM-AVISO EQUAL 23000 OR 12000 */

                if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.In("23000", "12000"))
                {

                    /*" -838- MOVE MOVIMCOB-NOME-SEGURADO TO WS-SEGURADO */
                    _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO, W.WS_SEGURADO);

                    /*" -839- MOVE WS-IDLG-CONV TO SOR-IDLG-CONV */
                    _.Move(W.WS_SEGURADO.WS_IDLG_CONV, REG_ARQSORT.SOR_IDLG.SOR_IDLG_CONV);

                    /*" -840- MOVE WS-IDLG-NSA TO SOR-IDLG-NSA */
                    _.Move(W.WS_SEGURADO.WS_IDLG_NSA, REG_ARQSORT.SOR_IDLG.SOR_IDLG_NSA);

                    /*" -841- MOVE WS-IDLG-NUMAPOL TO SOR-IDLG-NUMAPOL */
                    _.Move(W.WS_SEGURADO.WS_IDLG_NUMAPOL, REG_ARQSORT.SOR_IDLG.SOR_IDLG_NUMAPOL);

                    /*" -842- MOVE WS-IDLG-NUMENDO TO SOR-IDLG-NUMENDO */
                    _.Move(W.WS_SEGURADO.WS_IDLG_NUMENDO, REG_ARQSORT.SOR_IDLG.SOR_IDLG_NUMENDO);

                    /*" -843- MOVE WS-IDLG-NUMPARC TO SOR-IDLG-NUMPARC */
                    _.Move(W.WS_SEGURADO.WS_IDLG_NUMPARC, REG_ARQSORT.SOR_IDLG.SOR_IDLG_NUMPARC);

                    /*" -844- MOVE WS-IDLG-ERRO TO SOR-COD-ERRO */
                    _.Move(W.WS_SEGURADO.WS_IDLG_ERRO, REG_ARQSORT.SOR_IDLG.SOR_COD_ERRO);

                    /*" -845- ELSE */
                }
                else
                {


                    /*" -846- ADD 1 TO DP-CONVENIO */
                    W.DP_CONVENIO.Value = W.DP_CONVENIO + 1;

                    /*" -848- MOVE 'CONVENIO NAO PREVISTO ' TO LD01-MENSAGEM1 */
                    _.Move("CONVENIO NAO PREVISTO ", AUX_RELATORIO.LD01.LD01_MENSAGEM1);

                    /*" -849- PERFORM R1400-00-NAO-PREVISTO */

                    R1400_00_NAO_PREVISTO_SECTION();

                    /*" -852- GO TO R0350-90-LEITURA. */

                    R0350_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -854- MOVE MOVIMCOB-COD-BANCO TO SOR-COD-BANCO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO, REG_ARQSORT.SOR_COD_BANCO);

            /*" -856- MOVE MOVIMCOB-COD-AGENCIA TO SOR-COD-AGENCIA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA, REG_ARQSORT.SOR_COD_AGENCIA);

            /*" -858- MOVE MOVIMCOB-NUM-AVISO TO SOR-NUM-AVISO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, REG_ARQSORT.SOR_NUM_AVISO);

            /*" -860- MOVE MOVIMCOB-NUM-FITA TO SOR-NUM-FITA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA, REG_ARQSORT.SOR_NUM_FITA);

            /*" -862- MOVE MOVIMCOB-DATA-MOVIMENTO TO SOR-DATA-MOVIMENTO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO, REG_ARQSORT.SOR_DATA_MOVIMENTO);

            /*" -864- MOVE MOVIMCOB-DATA-QUITACAO TO SOR-DATA-QUITACAO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, REG_ARQSORT.SOR_DATA_QUITACAO);

            /*" -866- MOVE MOVIMCOB-NUM-TITULO TO SOR-NUM-TITULO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, REG_ARQSORT.SOR_NUM_TITULO);

            /*" -868- MOVE MOVIMCOB-NUM-APOLICE TO SOR-NUM-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, REG_ARQSORT.SOR_NUM_APOLICE);

            /*" -870- MOVE MOVIMCOB-NUM-ENDOSSO TO SOR-NUM-ENDOSSO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, REG_ARQSORT.SOR_NUM_ENDOSSO);

            /*" -872- MOVE MOVIMCOB-NUM-PARCELA TO SOR-NUM-PARCELA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, REG_ARQSORT.SOR_NUM_PARCELA);

            /*" -874- MOVE ZEROS TO SOR-OCORR-HISTORICO. */
            _.Move(0, REG_ARQSORT.SOR_OCORR_HISTORICO);

            /*" -876- MOVE MOVIMCOB-VAL-TITULO TO SOR-VAL-TITULO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, REG_ARQSORT.SOR_VAL_TITULO);

            /*" -878- MOVE MOVIMCOB-VAL-CREDITO TO SOR-VAL-CREDITO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO, REG_ARQSORT.SOR_VAL_CREDITO);

            /*" -880- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO SOR-NUM-NOSSO-TITULO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, REG_ARQSORT.SOR_NUM_NOSSO_TITULO);

            /*" -882- MOVE ZEROS TO SOR-COD-PRODUTO. */
            _.Move(0, REG_ARQSORT.SOR_COD_PRODUTO);

            /*" -890- MOVE SPACES TO SOR-SIT-REGISTRO. */
            _.Move("", REG_ARQSORT.SOR_SIT_REGISTRO);

            /*" -891- IF MOVIMCOB-SIT-REGISTRO EQUAL '*' */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO == "*")
            {

                /*" -892- ADD 1 TO AC-REJEITA */
                W.AC_REJEITA.Value = W.AC_REJEITA + 1;

                /*" -893- PERFORM R1500-00-TRATA-REJEITADOS */

                R1500_00_TRATA_REJEITADOS_SECTION();

                /*" -899- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -901- IF MOVIMCOB-DATA-QUITACAO GREATER SISTEMAS-DATA-MOV-ABERTO */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO > SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
            {

                /*" -902- ADD 1 TO DP-DATA */
                W.DP_DATA.Value = W.DP_DATA + 1;

                /*" -921- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -922- MOVE 'S' TO WTEM-PROPOSTA. */
            _.Move("S", W.WTEM_PROPOSTA);

            /*" -926- MOVE ZEROS TO ENDOSSOS-COD-PRODUTO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);

            /*" -927- IF MOVIMCOB-NUM-AVISO EQUAL 21000 */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO == 21000)
            {

                /*" -928- PERFORM R0360-00-SELECT-BILHETE */

                R0360_00_SELECT_BILHETE_SECTION();

                /*" -929- ELSE */
            }
            else
            {


                /*" -930- IF MOVIMCOB-NUM-AVISO NOT EQUAL 23000 AND 12000 */

                if (!MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.In("23000", "12000"))
                {

                    /*" -931- ADD 1 TO DP-CONVENIO */
                    W.DP_CONVENIO.Value = W.DP_CONVENIO + 1;

                    /*" -934- GO TO R0350-90-LEITURA. */

                    R0350_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -935- IF WTEM-PROPOSTA NOT EQUAL 'S' */

            if (W.WTEM_PROPOSTA != "S")
            {

                /*" -936- PERFORM R6000-00-GRAVA-ARQUIVO */

                R6000_00_GRAVA_ARQUIVO_SECTION();

                /*" -944- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -946- MOVE 'S' TO WTEM-PROPOSTA. */
            _.Move("S", W.WTEM_PROPOSTA);

            /*" -947- IF MOVIMCOB-SIT-REGISTRO EQUAL '4' */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO == "4")
            {

                /*" -948- MOVE SPACES TO SOR-IDLG */
                _.Move("", REG_ARQSORT.SOR_IDLG);

                /*" -950- MOVE '2' TO PARCELAS-SIT-REGISTRO */
                _.Move("2", PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);

                /*" -952- MOVE ZEROS TO PARCELAS-OCORR-HISTORICO */
                _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);

                /*" -953- ELSE */
            }
            else
            {


                /*" -955- PERFORM R0370-00-SELECT-PARCELAS. */

                R0370_00_SELECT_PARCELAS_SECTION();
            }


            /*" -956- IF WTEM-PROPOSTA NOT EQUAL 'S' */

            if (W.WTEM_PROPOSTA != "S")
            {

                /*" -957- PERFORM R6000-00-GRAVA-ARQUIVO */

                R6000_00_GRAVA_ARQUIVO_SECTION();

                /*" -963- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -965- MOVE ENDOSSOS-COD-PRODUTO TO SOR-COD-PRODUTO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, REG_ARQSORT.SOR_COD_PRODUTO);

            /*" -967- MOVE PARCELAS-OCORR-HISTORICO TO SOR-OCORR-HISTORICO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO, REG_ARQSORT.SOR_OCORR_HISTORICO);

            /*" -976- MOVE PARCELAS-SIT-REGISTRO TO SOR-SIT-REGISTRO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO, REG_ARQSORT.SOR_SIT_REGISTRO);

            /*" -977- IF PARCELAS-SIT-REGISTRO NOT EQUAL '0' */

            if (PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO != "0")
            {

                /*" -979- MOVE '2' TO MOVIMCOB-SIT-REGISTRO */
                _.Move("2", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

                /*" -980- ELSE */
            }
            else
            {


                /*" -984- MOVE '1' TO MOVIMCOB-SIT-REGISTRO. */
                _.Move("1", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
            }


            /*" -987- PERFORM R8900-00-UPDATE-V0MOVICOB. */

            R8900_00_UPDATE_V0MOVICOB_SECTION();

            /*" -988- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -988- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -993- PERFORM R0310-00-FETCH-MOVIMCOB. */

            R0310_00_FETCH_MOVIMCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0360-00-SELECT-BILHETE-SECTION */
        private void R0360_00_SELECT_BILHETE_SECTION()
        {
            /*" -1005- MOVE '0360' TO WNR-EXEC-SQL. */
            _.Move("0360", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1008- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO CONVERSI-NUM-PROPOSTA-SIVPF. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);

            /*" -1064- PERFORM R0360_00_SELECT_BILHETE_DB_SELECT_1 */

            R0360_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -1067- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1071- MOVE ZEROS TO CONVERSI-COD-PRODUTO-SIVPF ENDOSSOS-COD-PRODUTO BILHETE-OPC-COBERTURA */
                _.Move(0, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                /*" -1073- MOVE 'REGISTRO SEM PROPOSTA                   ' TO LD01-MENSAGEM1 */
                _.Move("REGISTRO SEM PROPOSTA                   ", AUX_RELATORIO.LD01.LD01_MENSAGEM1);

                /*" -1074- MOVE 'N' TO WTEM-PROPOSTA */
                _.Move("N", W.WTEM_PROPOSTA);

                /*" -1075- ADD 1 TO NT-BILHETE */
                W.NT_BILHETE.Value = W.NT_BILHETE + 1;

                /*" -1078- GO TO R0360-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1079- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1080- DISPLAY 'R0360-00 - PROBLEMAS SELECT  (BILHETE )   ' */
                _.Display($"R0360-00 - PROBLEMAS SELECT  (BILHETE )   ");

                /*" -1081- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1082- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1083- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1084- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1085- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1086- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1087- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1088- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1089- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1090- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1091- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1094- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1095- MOVE CONVERSI-COD-PRODUTO-SIVPF TO ENDOSSOS-COD-PRODUTO. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);

        }

        [StopWatch]
        /*" R0360-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R0360_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -1064- EXEC SQL SELECT A.NUM_PROPOSTA_SIVPF , A.COD_PRODUTO_SIVPF , B.NUM_BILHETE , B.NUM_APOLICE , B.FONTE , B.AGE_COBRANCA , B.NUM_MATRICULA , B.COD_AGENCIA , B.OPERACAO_CONTA , B.NUM_CONTA , B.DIG_CONTA , B.COD_CLIENTE , B.OCORR_ENDERECO , B.COD_AGENCIA_DEB , B.OPERACAO_CONTA_DEB , B.NUM_CONTA_DEB , B.DIG_CONTA_DEB , B.OPC_COBERTURA , B.DATA_QUITACAO , B.VAL_RCAP , B.RAMO , B.DATA_VENDA , B.SITUACAO INTO :CONVERSI-NUM-PROPOSTA-SIVPF , :CONVERSI-COD-PRODUTO-SIVPF , :BILHETE-NUM-BILHETE , :BILHETE-NUM-APOLICE , :BILHETE-FONTE , :BILHETE-AGE-COBRANCA , :BILHETE-NUM-MATRICULA , :BILHETE-COD-AGENCIA , :BILHETE-OPERACAO-CONTA , :BILHETE-NUM-CONTA , :BILHETE-DIG-CONTA , :BILHETE-COD-CLIENTE , :BILHETE-OCORR-ENDERECO , :BILHETE-COD-AGENCIA-DEB , :BILHETE-OPERACAO-CONTA-DEB , :BILHETE-NUM-CONTA-DEB , :BILHETE-DIG-CONTA-DEB , :BILHETE-OPC-COBERTURA , :BILHETE-DATA-QUITACAO , :BILHETE-VAL-RCAP , :BILHETE-RAMO , :BILHETE-DATA-VENDA , :BILHETE-SITUACAO FROM SEGUROS.CONVERSAO_SICOB A , SEGUROS.BILHETE B WHERE A.NUM_PROPOSTA_SIVPF = :CONVERSI-NUM-PROPOSTA-SIVPF AND A.NUM_SICOB = B.NUM_BILHETE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0360_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                CONVERSI_NUM_PROPOSTA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r0360_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_PROPOSTA_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.CONVERSI_COD_PRODUTO_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF);
                _.Move(executed_1.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(executed_1.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(executed_1.BILHETE_FONTE, BILHETE.DCLBILHETE.BILHETE_FONTE);
                _.Move(executed_1.BILHETE_AGE_COBRANCA, BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA);
                _.Move(executed_1.BILHETE_NUM_MATRICULA, BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA);
                _.Move(executed_1.BILHETE_COD_AGENCIA, BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA);
                _.Move(executed_1.BILHETE_OPERACAO_CONTA, BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA);
                _.Move(executed_1.BILHETE_NUM_CONTA, BILHETE.DCLBILHETE.BILHETE_NUM_CONTA);
                _.Move(executed_1.BILHETE_DIG_CONTA, BILHETE.DCLBILHETE.BILHETE_DIG_CONTA);
                _.Move(executed_1.BILHETE_COD_CLIENTE, BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE);
                _.Move(executed_1.BILHETE_OCORR_ENDERECO, BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO);
                _.Move(executed_1.BILHETE_COD_AGENCIA_DEB, BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA_DEB);
                _.Move(executed_1.BILHETE_OPERACAO_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA_DEB);
                _.Move(executed_1.BILHETE_NUM_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_NUM_CONTA_DEB);
                _.Move(executed_1.BILHETE_DIG_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_DIG_CONTA_DEB);
                _.Move(executed_1.BILHETE_OPC_COBERTURA, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);
                _.Move(executed_1.BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(executed_1.BILHETE_VAL_RCAP, BILHETE.DCLBILHETE.BILHETE_VAL_RCAP);
                _.Move(executed_1.BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(executed_1.BILHETE_DATA_VENDA, BILHETE.DCLBILHETE.BILHETE_DATA_VENDA);
                _.Move(executed_1.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/

        [StopWatch]
        /*" R0370-00-SELECT-PARCELAS-SECTION */
        private void R0370_00_SELECT_PARCELAS_SECTION()
        {
            /*" -1108- MOVE '0370' TO WNR-EXEC-SQL. */
            _.Move("0370", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1110- MOVE MOVIMCOB-NUM-APOLICE TO PARCELAS-NUM-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

            /*" -1112- MOVE MOVIMCOB-NUM-ENDOSSO TO PARCELAS-NUM-ENDOSSO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

            /*" -1115- MOVE MOVIMCOB-NUM-PARCELA TO PARCELAS-NUM-PARCELA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);

            /*" -1131- PERFORM R0370_00_SELECT_PARCELAS_DB_SELECT_1 */

            R0370_00_SELECT_PARCELAS_DB_SELECT_1();

            /*" -1134- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1136- MOVE ZEROS TO ENDOSSOS-COD-PRODUTO */
                _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);

                /*" -1138- MOVE 'PARCELA NAO CADASTRADA                  ' TO LD01-MENSAGEM1 */
                _.Move("PARCELA NAO CADASTRADA                  ", AUX_RELATORIO.LD01.LD01_MENSAGEM1);

                /*" -1139- MOVE 'N' TO WTEM-PROPOSTA */
                _.Move("N", W.WTEM_PROPOSTA);

                /*" -1140- ADD 1 TO NT-PARCELA */
                W.NT_PARCELA.Value = W.NT_PARCELA + 1;

                /*" -1143- GO TO R0370-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1144- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1145- DISPLAY 'R0370-00 - PROBLEMAS SELECT  (PARCELAS)   ' */
                _.Display($"R0370-00 - PROBLEMAS SELECT  (PARCELAS)   ");

                /*" -1146- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1147- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1148- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1149- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1150- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1151- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1152- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1153- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1154- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1155- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1156- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1156- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0370-00-SELECT-PARCELAS-DB-SELECT-1 */
        public void R0370_00_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -1131- EXEC SQL SELECT A.SIT_REGISTRO , A.OCORR_HISTORICO , B.COD_PRODUTO INTO :PARCELAS-SIT-REGISTRO , :PARCELAS-OCORR-HISTORICO , :ENDOSSOS-COD-PRODUTO FROM SEGUROS.PARCELAS A, SEGUROS.ENDOSSOS B WHERE A.NUM_APOLICE = :PARCELAS-NUM-APOLICE AND A.NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO AND A.NUM_PARCELA = :PARCELAS-NUM-PARCELA AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO WITH UR END-EXEC. */

            var r0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
                PARCELAS_NUM_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCELAS_SIT_REGISTRO, PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);
                _.Move(executed_1.PARCELAS_OCORR_HISTORICO, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-OUTPUT-SORT-SECTION */
        private void R0450_00_OUTPUT_SORT_SECTION()
        {
            /*" -1168- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1170- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -1172- PERFORM R0500-00-LE-ARQSORT. */

            R0500_00_LE_ARQSORT_SECTION();

            /*" -1175- PERFORM R0510-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R0510_00_PROCESSA_SORT_SECTION();
            }

            /*" -1176- DISPLAY ' ' */
            _.Display($" ");

            /*" -1177- DISPLAY 'LIDOS SORT ............ ' LD-SORT */
            _.Display($"LIDOS SORT ............ {W.LD_SORT}");

            /*" -1178- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1179- DISPLAY 'INCLUIDOS AVISOCRE .... ' AC-AVISOCRE. */
            _.Display($"INCLUIDOS AVISOCRE .... {W.AC_AVISOCRE}");

            /*" -1180- DISPLAY 'INCLUIDOS AVISOSAL .... ' AC-AVISOSAL. */
            _.Display($"INCLUIDOS AVISOSAL .... {W.AC_AVISOSAL}");

            /*" -1181- DISPLAY 'INCLUIDOS CONDESCE .... ' AC-CONDESCE. */
            _.Display($"INCLUIDOS CONDESCE .... {W.AC_CONDESCE}");

            /*" -1182- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1183- DISPLAY 'PARCELAS BAIXADAS ..... ' AC-EMITE. */
            _.Display($"PARCELAS BAIXADAS ..... {W.AC_EMITE}");

            /*" -1184- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1185- DISPLAY 'ALTERA MOVDEBCE ............ ' UP-MOVDEBCE. */
            _.Display($"ALTERA MOVDEBCE ............ {W.UP_MOVDEBCE}");

            /*" -1186- DISPLAY 'ALTERA MOVIMCOB ............ ' UP-PROPOSTA. */
            _.Display($"ALTERA MOVIMCOB ............ {W.UP_PROPOSTA}");

            /*" -1187- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1188- DISPLAY 'INCLUIDOS FOLLOUP ..... ' AC-FOLLOWUP */
            _.Display($"INCLUIDOS FOLLOUP ..... {W.AC_FOLLOWUP}");

            /*" -1189- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1190- DISPLAY 'GRAVADOS ERRO ......... ' GV-SAIDA. */
            _.Display($"GRAVADOS ERRO ......... {W.GV_SAIDA}");

            /*" -1190- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-LE-ARQSORT-SECTION */
        private void R0500_00_LE_ARQSORT_SECTION()
        {
            /*" -1202- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1204- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -1205- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -1209- MOVE ZEROS TO ATU-COD-BANCO ATU-COD-AGENCIA ATU-COD-PRODUTO */
                    _.Move(0, W.WS_CHAVE_ATU.ATU_COD_BANCO, W.WS_CHAVE_ATU.ATU_COD_AGENCIA, W.ATU_COD_PRODUTO);

                    /*" -1211- MOVE SPACES TO ATU-DTQITBCO */
                    _.Move("", W.WS_CHAVE_ATU.ATU_DTQITBCO);

                    /*" -1214- GO TO R0500-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1216- MOVE SOR-COD-BANCO TO ATU-COD-BANCO. */
            _.Move(REG_ARQSORT.SOR_COD_BANCO, W.WS_CHAVE_ATU.ATU_COD_BANCO);

            /*" -1218- MOVE SOR-COD-AGENCIA TO ATU-COD-AGENCIA. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, W.WS_CHAVE_ATU.ATU_COD_AGENCIA);

            /*" -1220- MOVE SOR-DATA-QUITACAO TO ATU-DTQITBCO. */
            _.Move(REG_ARQSORT.SOR_DATA_QUITACAO, W.WS_CHAVE_ATU.ATU_DTQITBCO);

            /*" -1224- MOVE SOR-COD-PRODUTO TO ATU-COD-PRODUTO. */
            _.Move(REG_ARQSORT.SOR_COD_PRODUTO, W.ATU_COD_PRODUTO);

            /*" -1224- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-PROCESSA-SORT-SECTION */
        private void R0510_00_PROCESSA_SORT_SECTION()
        {
            /*" -1236- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1238- PERFORM R0520-00-MONTA-AVISOCRE. */

            R0520_00_MONTA_AVISOCRE_SECTION();

            /*" -1240- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT. */
            _.Move(W.WS_CHAVE_ATU, W.WS_CHAVE_ANT);

            /*" -1244- PERFORM R0550-00-PROCESSA-AVISO UNTIL WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.WS_CHAVE_ATU != W.WS_CHAVE_ANT || !W.WFIM_SORT.IsEmpty()))
            {

                R0550_00_PROCESSA_AVISO_SECTION();
            }

            /*" -1245- IF AVISOCRE-PRM-TOTAL NOT EQUAL ZEROS */

            if (AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL != 00)
            {

                /*" -1246- PERFORM R5100-00-INSERT-AVISOCRE */

                R5100_00_INSERT_AVISOCRE_SECTION();

                /*" -1246- PERFORM R5200-00-INSERT-AVISOSAL. */

                R5200_00_INSERT_AVISOSAL_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-MONTA-AVISOCRE-SECTION */
        private void R0520_00_MONTA_AVISOCRE_SECTION()
        {
            /*" -1261- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1263- MOVE SOR-COD-BANCO TO AVISOCRE-BCO-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_BANCO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO);

            /*" -1266- MOVE SOR-COD-AGENCIA TO AVISOCRE-AGE-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO);

            /*" -1268- PERFORM R0530-00-SELECT-AVISOCRE. */

            R0530_00_SELECT_AVISOCRE_SECTION();

            /*" -1270- MOVE 1 TO AVISOCRE-NUM-SEQUENCIA. */
            _.Move(1, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA);

            /*" -1272- MOVE SISTEMAS-DATA-MOV-ABERTO TO AVISOCRE-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO);

            /*" -1274- MOVE 100 TO AVISOCRE-COD-OPERACAO. */
            _.Move(100, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_OPERACAO);

            /*" -1276- MOVE 'C' TO AVISOCRE-TIPO-AVISO. */
            _.Move("C", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO);

            /*" -1278- MOVE SOR-DATA-QUITACAO TO AVISOCRE-DATA-AVISO. */
            _.Move(REG_ARQSORT.SOR_DATA_QUITACAO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO);

            /*" -1285- MOVE ZEROS TO AVISOCRE-VAL-IOCC AVISOCRE-VAL-DESPESA AVISOCRE-PRM-COSSEGURO-CED AVISOCRE-PRM-LIQUIDO AVISOCRE-PRM-TOTAL AVISOCRE-VAL-ADIANTAMENTO. */
            _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_IOCC, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_COSSEGURO_CED, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_ADIANTAMENTO);

            /*" -1287- MOVE '0' TO AVISOCRE-SIT-CONTABIL. */
            _.Move("0", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_SIT_CONTABIL);

            /*" -1289- MOVE ZEROS TO AVISOCRE-COD-EMPRESA. */
            _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA);

            /*" -1292- MOVE 2 TO AVISOCRE-ORIGEM-AVISO. */
            _.Move(2, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO);

            /*" -1297- MOVE 'P' TO AVISOCRE-STA-DEPOSITO-TER. */
            _.Move("P", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_STA_DEPOSITO_TER);

            /*" -1299- MOVE AVISOCRE-COD-EMPRESA TO AVISOSAL-COD-EMPRESA. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_COD_EMPRESA);

            /*" -1301- MOVE AVISOCRE-BCO-AVISO TO AVISOSAL-BCO-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO);

            /*" -1303- MOVE AVISOCRE-AGE-AVISO TO AVISOSAL-AGE-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO);

            /*" -1305- MOVE '1' TO AVISOSAL-TIPO-SEGURO. */
            _.Move("1", AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_TIPO_SEGURO);

            /*" -1307- MOVE AVISOCRE-NUM-AVISO-CREDITO TO AVISOSAL-NUM-AVISO-CREDITO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO);

            /*" -1309- MOVE AVISOCRE-DATA-AVISO TO AVISOSAL-DATA-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_AVISO);

            /*" -1311- MOVE SISTEMAS-DATA-MOV-ABERTO TO AVISOSAL-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO);

            /*" -1313- MOVE ZEROS TO AVISOSAL-SALDO-ATUAL. */
            _.Move(0, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);

            /*" -1314- MOVE '0' TO AVISOSAL-SIT-REGISTRO. */
            _.Move("0", AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0530-00-SELECT-AVISOCRE-SECTION */
        private void R0530_00_SELECT_AVISOCRE_SECTION()
        {
            /*" -1326- MOVE '0530' TO WNR-EXEC-SQL. */
            _.Move("0530", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1339- PERFORM R0530_00_SELECT_AVISOCRE_DB_SELECT_1 */

            R0530_00_SELECT_AVISOCRE_DB_SELECT_1();

            /*" -1343- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1345- MOVE 802100001 TO AVISOCRE-NUM-AVISO-CREDITO */
                _.Move(802100001, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);

                /*" -1346- ELSE */
            }
            else
            {


                /*" -1347- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1348- DISPLAY 'R0530-00 - AVISO CREDITO ERRO SELECT      ' */
                    _.Display($"R0530-00 - AVISO CREDITO ERRO SELECT      ");

                    /*" -1349- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1350- ELSE */
                }
                else
                {


                    /*" -1351- IF VIND-NRAVISO LESS ZEROS */

                    if (VIND_NRAVISO < 00)
                    {

                        /*" -1353- MOVE 802100001 TO AVISOCRE-NUM-AVISO-CREDITO */
                        _.Move(802100001, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);

                        /*" -1354- ELSE */
                    }
                    else
                    {


                        /*" -1355- IF AVISOCRE-NUM-AVISO-CREDITO EQUAL 802199999 */

                        if (AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO == 802199999)
                        {

                            /*" -1356- DISPLAY 'R0530-00 - AVISO CREDITO FORA FAIXA       ' */
                            _.Display($"R0530-00 - AVISO CREDITO FORA FAIXA       ");

                            /*" -1357- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1358- ELSE */
                        }
                        else
                        {


                            /*" -1359- ADD 1 TO AVISOCRE-NUM-AVISO-CREDITO. */
                            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO + 1;
                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" R0530-00-SELECT-AVISOCRE-DB-SELECT-1 */
        public void R0530_00_SELECT_AVISOCRE_DB_SELECT_1()
        {
            /*" -1339- EXEC SQL SELECT MAX(NUM_AVISO_CREDITO) INTO :AVISOCRE-NUM-AVISO-CREDITO:VIND-NRAVISO FROM SEGUROS.AVISO_CREDITO WHERE BCO_AVISO = :AVISOCRE-BCO-AVISO AND AGE_AVISO = :AVISOCRE-AGE-AVISO AND NUM_AVISO_CREDITO >= 802100000 AND NUM_AVISO_CREDITO <= 802199999 WITH UR END-EXEC. */

            var r0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 = new R0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1()
            {
                AVISOCRE_BCO_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO.ToString(),
                AVISOCRE_AGE_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO.ToString(),
            };

            var executed_1 = R0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1.Execute(r0530_00_SELECT_AVISOCRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
                _.Move(executed_1.VIND_NRAVISO, VIND_NRAVISO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-PROCESSA-AVISO-SECTION */
        private void R0550_00_PROCESSA_AVISO_SECTION()
        {
            /*" -1372- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1375- PERFORM R0560-00-MONTA-CONDESCE. */

            R0560_00_MONTA_CONDESCE_SECTION();

            /*" -1377- MOVE ATU-COD-PRODUTO TO ANT-COD-PRODUTO. */
            _.Move(W.ATU_COD_PRODUTO, W.ANT_COD_PRODUTO);

            /*" -1383- PERFORM R0600-00-PROCESSA-REGISTRO UNTIL ATU-COD-PRODUTO NOT EQUAL ANT-COD-PRODUTO OR WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.ATU_COD_PRODUTO != W.ANT_COD_PRODUTO || W.WS_CHAVE_ATU != W.WS_CHAVE_ANT || !W.WFIM_SORT.IsEmpty()))
            {

                R0600_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1384- IF CONDESCE-PRM-TOTAL NOT EQUAL ZEROS */

            if (CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL != 00)
            {

                /*" -1384- PERFORM R5300-00-INSERT-CONDESCE. */

                R5300_00_INSERT_CONDESCE_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0560-00-MONTA-CONDESCE-SECTION */
        private void R0560_00_MONTA_CONDESCE_SECTION()
        {
            /*" -1401- MOVE '0560' TO WNR-EXEC-SQL. */
            _.Move("0560", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1403- MOVE AVISOCRE-COD-EMPRESA TO CONDESCE-COD-EMPRESA. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_EMPRESA);

            /*" -1405- MOVE AVISOCRE-DATA-AVISO TO WDATA-REL. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, W.WDATA_REL);

            /*" -1407- MOVE WDAT-REL-ANO TO CONDESCE-ANO-REFERENCIA. */
            _.Move(W.FILLER_0.WDAT_REL_ANO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_ANO_REFERENCIA);

            /*" -1409- MOVE WDAT-REL-MES TO CONDESCE-MES-REFERENCIA. */
            _.Move(W.FILLER_0.WDAT_REL_MES, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_MES_REFERENCIA);

            /*" -1411- MOVE AVISOCRE-BCO-AVISO TO CONDESCE-BCO-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO);

            /*" -1413- MOVE AVISOCRE-AGE-AVISO TO CONDESCE-AGE-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO);

            /*" -1415- MOVE AVISOCRE-NUM-AVISO-CREDITO TO CONDESCE-NUM-AVISO-CREDITO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO);

            /*" -1417- MOVE ATU-COD-PRODUTO TO CONDESCE-COD-PRODUTO. */
            _.Move(W.ATU_COD_PRODUTO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO);

            /*" -1419- MOVE 'D' TO CONDESCE-TIPO-REGISTRO. */
            _.Move("D", CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_REGISTRO);

            /*" -1421- MOVE '0' TO CONDESCE-SITUACAO. */
            _.Move("0", CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_SITUACAO);

            /*" -1423- MOVE '2' TO CONDESCE-TIPO-COBRANCA. */
            _.Move("2", CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_COBRANCA);

            /*" -1425- MOVE SISTEMAS-DATA-MOV-ABERTO TO CONDESCE-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_MOVIMENTO);

            /*" -1427- MOVE AVISOCRE-DATA-AVISO TO CONDESCE-DATA-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_AVISO);

            /*" -1436- MOVE ZEROS TO CONDESCE-QTD-REGISTROS CONDESCE-PRM-TOTAL CONDESCE-PRM-LIQUIDO CONDESCE-VAL-TARIFA CONDESCE-VAL-BALCAO CONDESCE-VAL-IOCC CONDESCE-VAL-DESCONTO CONDESCE-VAL-JUROS CONDESCE-VAL-MULTA. */
            _.Move(0, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_IOCC, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_DESCONTO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_JUROS, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_MULTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-PROCESSA-REGISTRO-SECTION */
        private void R0600_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1453- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1456- COMPUTE AUX-VALOR EQUAL (SOR-VAL-TITULO - SOR-VAL-CREDITO). */
            W.AUX_VALOR.Value = (REG_ARQSORT.SOR_VAL_TITULO - REG_ARQSORT.SOR_VAL_CREDITO);

            /*" -1459- ADD 1 TO CONDESCE-QTD-REGISTROS. */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS + 1;

            /*" -1463- ADD AUX-VALOR TO AVISOCRE-VAL-DESPESA CONDESCE-VAL-TARIFA. */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA + W.AUX_VALOR;
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA + W.AUX_VALOR;

            /*" -1468- ADD SOR-VAL-TITULO TO AVISOCRE-PRM-TOTAL CONDESCE-PRM-TOTAL. */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL + REG_ARQSORT.SOR_VAL_TITULO;
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL + REG_ARQSORT.SOR_VAL_TITULO;

            /*" -1469- IF SOR-SIT-REGISTRO EQUAL '0' */

            if (REG_ARQSORT.SOR_SIT_REGISTRO == "0")
            {

                /*" -1470- PERFORM R1100-00-BAIXA-PARCELA */

                R1100_00_BAIXA_PARCELA_SECTION();

                /*" -1471- ELSE */
            }
            else
            {


                /*" -1477- PERFORM R2000-00-TRATA-FOLLOWUP. */

                R2000_00_TRATA_FOLLOWUP_SECTION();
            }


            /*" -1478- IF SOR-IDLG EQUAL SPACES */

            if (REG_ARQSORT.SOR_IDLG.IsEmpty())
            {

                /*" -1484- GO TO R0600-90-LEITURA. */

                R0600_90_LEITURA(); //GOTO
                return;
            }


            /*" -1486- MOVE SOR-IDLG-CONV TO MOVDEBCE-COD-CONVENIO. */
            _.Move(REG_ARQSORT.SOR_IDLG.SOR_IDLG_CONV, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -1488- MOVE SOR-IDLG-NSA TO MOVDEBCE-NSAS. */
            _.Move(REG_ARQSORT.SOR_IDLG.SOR_IDLG_NSA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -1490- MOVE SOR-IDLG-NUMAPOL TO MOVDEBCE-NUM-APOLICE. */
            _.Move(REG_ARQSORT.SOR_IDLG.SOR_IDLG_NUMAPOL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -1492- MOVE SOR-IDLG-NUMENDO TO MOVDEBCE-NUM-ENDOSSO. */
            _.Move(REG_ARQSORT.SOR_IDLG.SOR_IDLG_NUMENDO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -1495- MOVE SOR-IDLG-NUMPARC TO MOVDEBCE-NUM-PARCELA. */
            _.Move(REG_ARQSORT.SOR_IDLG.SOR_IDLG_NUMPARC, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -1502- MOVE ZEROS TO VIND-DTRETORNO VIND-CODRET VIND-USUARIO VIND-DTCREDITO VIND-VLRCREDITO. */
            _.Move(0, VIND_DTRETORNO, VIND_CODRET, VIND_USUARIO, VIND_DTCREDITO, VIND_VLRCREDITO);

            /*" -1504- MOVE '2' TO MOVDEBCE-SITUACAO-COBRANCA. */
            _.Move("2", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -1506- MOVE ZEROS TO MOVDEBCE-COD-RETORNO-CEF. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

            /*" -1508- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-RETORNO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO);

            /*" -1510- MOVE 'BI6253B' TO MOVDEBCE-COD-USUARIO. */
            _.Move("BI6253B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -1512- MOVE SOR-DATA-QUITACAO TO MOVDEBCE-DTCREDITO. */
            _.Move(REG_ARQSORT.SOR_DATA_QUITACAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO);

            /*" -1515- MOVE SOR-VAL-TITULO TO MOVDEBCE-VLR-CREDITO. */
            _.Move(REG_ARQSORT.SOR_VAL_TITULO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);

            /*" -1515- PERFORM R9000-00-UPDATE-V0MOVDEBCE. */

            R9000_00_UPDATE_V0MOVDEBCE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0600_90_LEITURA */

            R0600_90_LEITURA();

        }

        [StopWatch]
        /*" R0600-90-LEITURA */
        private void R0600_90_LEITURA(bool isPerform = false)
        {
            /*" -1520- PERFORM R0500-00-LE-ARQSORT. */

            R0500_00_LE_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-BAIXA-PARCELA-SECTION */
        private void R1100_00_BAIXA_PARCELA_SECTION()
        {
            /*" -1535- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1537- MOVE SOR-NUM-APOLICE TO PARCELAS-NUM-APOLICE. */
            _.Move(REG_ARQSORT.SOR_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

            /*" -1539- MOVE SOR-NUM-ENDOSSO TO PARCELAS-NUM-ENDOSSO. */
            _.Move(REG_ARQSORT.SOR_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

            /*" -1541- MOVE SOR-NUM-PARCELA TO PARCELAS-NUM-PARCELA. */
            _.Move(REG_ARQSORT.SOR_NUM_PARCELA, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);

            /*" -1543- MOVE SOR-OCORR-HISTORICO TO PARCELAS-OCORR-HISTORICO. */
            _.Move(REG_ARQSORT.SOR_OCORR_HISTORICO, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);

            /*" -1545- ADD 1 TO PARCELAS-OCORR-HISTORICO. */
            PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO.Value = PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO + 1;

            /*" -1548- MOVE '1' TO PARCELAS-SIT-REGISTRO. */
            _.Move("1", PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);

            /*" -1554- PERFORM R1150-00-UPDATE-PARCELAS. */

            R1150_00_UPDATE_PARCELAS_SECTION();

            /*" -1556- MOVE SOR-NUM-APOLICE TO PARCEHIS-NUM-APOLICE. */
            _.Move(REG_ARQSORT.SOR_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -1558- MOVE SOR-NUM-ENDOSSO TO PARCEHIS-NUM-ENDOSSO. */
            _.Move(REG_ARQSORT.SOR_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -1560- MOVE SOR-NUM-PARCELA TO PARCEHIS-NUM-PARCELA. */
            _.Move(REG_ARQSORT.SOR_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

            /*" -1564- MOVE SOR-OCORR-HISTORICO TO PARCEHIS-OCORR-HISTORICO. */
            _.Move(REG_ARQSORT.SOR_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -1567- PERFORM R1200-00-SELECT-PARCEHIS. */

            R1200_00_SELECT_PARCEHIS_SECTION();

            /*" -1569- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -1571- MOVE 231 TO PARCEHIS-COD-OPERACAO. */
            _.Move(231, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -1573- MOVE PARCELAS-OCORR-HISTORICO TO PARCEHIS-OCORR-HISTORICO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -1575- MOVE SOR-VAL-TITULO TO PARCEHIS-VAL-OPERACAO. */
            _.Move(REG_ARQSORT.SOR_VAL_TITULO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

            /*" -1577- MOVE AVISOCRE-BCO-AVISO TO PARCEHIS-BCO-COBRANCA. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -1579- MOVE AVISOCRE-AGE-AVISO TO PARCEHIS-AGE-COBRANCA. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -1581- MOVE AVISOCRE-NUM-AVISO-CREDITO TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -1583- MOVE ZEROS TO PARCEHIS-ENDOS-CANCELA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -1585- MOVE '0' TO PARCEHIS-SIT-CONTABIL. */
            _.Move("0", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

            /*" -1587- MOVE 'BI6253B' TO PARCEHIS-COD-USUARIO. */
            _.Move("BI6253B", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -1589- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

            /*" -1591- MOVE SOR-DATA-QUITACAO TO PARCEHIS-DATA-QUITACAO. */
            _.Move(REG_ARQSORT.SOR_DATA_QUITACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -1593- MOVE ZEROS TO VIND-DTQITBCO. */
            _.Move(0, VIND_DTQITBCO);

            /*" -1595- MOVE ZEROS TO PARCEHIS-COD-EMPRESA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);

            /*" -1599- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -1605- PERFORM R1250-00-INSERT-PARCEHIS. */

            R1250_00_INSERT_PARCEHIS_SECTION();

            /*" -1605- PERFORM R1300-00-SELECT-PARCELAS. */

            R1300_00_SELECT_PARCELAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-UPDATE-PARCELAS-SECTION */
        private void R1150_00_UPDATE_PARCELAS_SECTION()
        {
            /*" -1618- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1626- PERFORM R1150_00_UPDATE_PARCELAS_DB_UPDATE_1 */

            R1150_00_UPDATE_PARCELAS_DB_UPDATE_1();

            /*" -1629- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1630- DISPLAY 'R1150-00 - PROBLEMAS UPDATE (PARCELAS)   ' */
                _.Display($"R1150-00 - PROBLEMAS UPDATE (PARCELAS)   ");

                /*" -1631- DISPLAY 'NUM-APOLICE     = ' PARCELAS-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -1632- DISPLAY 'NUM-ENDOSSO     = ' PARCELAS-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -1633- DISPLAY 'NUM-PARCELA     = ' PARCELAS-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}");

                /*" -1633- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1150-00-UPDATE-PARCELAS-DB-UPDATE-1 */
        public void R1150_00_UPDATE_PARCELAS_DB_UPDATE_1()
        {
            /*" -1626- EXEC SQL UPDATE SEGUROS.PARCELAS SET SIT_REGISTRO = :PARCELAS-SIT-REGISTRO, OCORR_HISTORICO = :PARCELAS-OCORR-HISTORICO WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO AND NUM_PARCELA = :PARCELAS-NUM-PARCELA END-EXEC. */

            var r1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 = new R1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1()
            {
                PARCELAS_OCORR_HISTORICO = PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO.ToString(),
                PARCELAS_SIT_REGISTRO = PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO.ToString(),
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
                PARCELAS_NUM_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.ToString(),
            };

            R1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1.Execute(r1150_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-PARCEHIS-SECTION */
        private void R1200_00_SELECT_PARCEHIS_SECTION()
        {
            /*" -1646- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1680- PERFORM R1200_00_SELECT_PARCEHIS_DB_SELECT_1 */

            R1200_00_SELECT_PARCEHIS_DB_SELECT_1();

            /*" -1683- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1684- DISPLAY 'R1200-00 - PROBLEMAS SELECT  (PARCEHIS)   ' */
                _.Display($"R1200-00 - PROBLEMAS SELECT  (PARCEHIS)   ");

                /*" -1685- DISPLAY 'NUM-APOLICE     = ' PARCEHIS-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1686- DISPLAY 'NUM-ENDOSSO     = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1687- DISPLAY 'NUM-PARCELA     = ' PARCEHIS-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -1688- DISPLAY 'HISTORICO       = ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"HISTORICO       = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -1688- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-PARCEHIS-DB-SELECT-1 */
        public void R1200_00_SELECT_PARCEHIS_DB_SELECT_1()
        {
            /*" -1680- EXEC SQL SELECT NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DAC_PARCELA ,OCORR_HISTORICO ,PRM_TARIFARIO ,VAL_DESCONTO ,PRM_LIQUIDO ,ADICIONAL_FRACIO ,VAL_CUSTO_EMISSAO ,VAL_IOCC ,PRM_TOTAL ,DATA_VENCIMENTO INTO :PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA ,:PARCEHIS-DAC-PARCELA ,:PARCEHIS-OCORR-HISTORICO ,:PARCEHIS-PRM-TARIFARIO ,:PARCEHIS-VAL-DESCONTO ,:PARCEHIS-PRM-LIQUIDO ,:PARCEHIS-ADICIONAL-FRACIO ,:PARCEHIS-VAL-CUSTO-EMISSAO ,:PARCEHIS-VAL-IOCC ,:PARCEHIS-PRM-TOTAL ,:PARCEHIS-DATA-VENCIMENTO FROM SEGUROS.PARCELA_HISTORICO WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA AND OCORR_HISTORICO = :PARCEHIS-OCORR-HISTORICO WITH UR END-EXEC. */

            var r1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 = new R1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1()
            {
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_PARCEHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(executed_1.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(executed_1.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(executed_1.PARCEHIS_DAC_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);
                _.Move(executed_1.PARCEHIS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);
                _.Move(executed_1.PARCEHIS_PRM_TARIFARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO);
                _.Move(executed_1.PARCEHIS_VAL_DESCONTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO);
                _.Move(executed_1.PARCEHIS_PRM_LIQUIDO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO);
                _.Move(executed_1.PARCEHIS_ADICIONAL_FRACIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);
                _.Move(executed_1.PARCEHIS_VAL_CUSTO_EMISSAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO);
                _.Move(executed_1.PARCEHIS_VAL_IOCC, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC);
                _.Move(executed_1.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);
                _.Move(executed_1.PARCEHIS_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-INSERT-PARCEHIS-SECTION */
        private void R1250_00_INSERT_PARCEHIS_SECTION()
        {
            /*" -1701- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1758- PERFORM R1250_00_INSERT_PARCEHIS_DB_INSERT_1 */

            R1250_00_INSERT_PARCEHIS_DB_INSERT_1();

            /*" -1761- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1762- DISPLAY 'R1250-00 - PROBLEMAS NO INSERT(PARCEHIS)   ' */
                _.Display($"R1250-00 - PROBLEMAS NO INSERT(PARCEHIS)   ");

                /*" -1763- DISPLAY 'NUM-APOLICE     = ' PARCEHIS-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1764- DISPLAY 'NUM-ENDOSSO     = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1767- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1767- ADD 1 TO AC-EMITE. */
            W.AC_EMITE.Value = W.AC_EMITE + 1;

        }

        [StopWatch]
        /*" R1250-00-INSERT-PARCEHIS-DB-INSERT-1 */
        public void R1250_00_INSERT_PARCEHIS_DB_INSERT_1()
        {
            /*" -1758- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO (NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DAC_PARCELA , DATA_MOVIMENTO , COD_OPERACAO , HORA_OPERACAO , OCORR_HISTORICO , PRM_TARIFARIO , VAL_DESCONTO , PRM_LIQUIDO , ADICIONAL_FRACIO , VAL_CUSTO_EMISSAO , VAL_IOCC , PRM_TOTAL , VAL_OPERACAO , DATA_VENCIMENTO , BCO_COBRANCA , AGE_COBRANCA , NUM_AVISO_CREDITO , ENDOS_CANCELA , SIT_CONTABIL , COD_USUARIO , RENUM_DOCUMENTO , DATA_QUITACAO , COD_EMPRESA , TIMESTAMP) VALUES (:PARCEHIS-NUM-APOLICE , :PARCEHIS-NUM-ENDOSSO , :PARCEHIS-NUM-PARCELA , :PARCEHIS-DAC-PARCELA , :PARCEHIS-DATA-MOVIMENTO , :PARCEHIS-COD-OPERACAO , CURRENT TIME , :PARCEHIS-OCORR-HISTORICO , :PARCEHIS-PRM-TARIFARIO , :PARCEHIS-VAL-DESCONTO , :PARCEHIS-PRM-LIQUIDO , :PARCEHIS-ADICIONAL-FRACIO , :PARCEHIS-VAL-CUSTO-EMISSAO , :PARCEHIS-VAL-IOCC , :PARCEHIS-PRM-TOTAL , :PARCEHIS-VAL-OPERACAO , :PARCEHIS-DATA-VENCIMENTO , :PARCEHIS-BCO-COBRANCA , :PARCEHIS-AGE-COBRANCA , :PARCEHIS-NUM-AVISO-CREDITO , :PARCEHIS-ENDOS-CANCELA , :PARCEHIS-SIT-CONTABIL , :PARCEHIS-COD-USUARIO , :PARCEHIS-RENUM-DOCUMENTO , :PARCEHIS-DATA-QUITACAO:VIND-DTQITBCO, :PARCEHIS-COD-EMPRESA:VIND-CODEMP , CURRENT TIMESTAMP) END-EXEC. */

            var r1250_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1 = new R1250_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                PARCEHIS_DAC_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.ToString(),
                PARCEHIS_DATA_MOVIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.ToString(),
                PARCEHIS_COD_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_PRM_TARIFARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO.ToString(),
                PARCEHIS_VAL_DESCONTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO.ToString(),
                PARCEHIS_PRM_LIQUIDO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO.ToString(),
                PARCEHIS_ADICIONAL_FRACIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO.ToString(),
                PARCEHIS_VAL_CUSTO_EMISSAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO.ToString(),
                PARCEHIS_VAL_IOCC = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC.ToString(),
                PARCEHIS_PRM_TOTAL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL.ToString(),
                PARCEHIS_VAL_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.ToString(),
                PARCEHIS_DATA_VENCIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_SIT_CONTABIL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.ToString(),
                PARCEHIS_COD_USUARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.ToString(),
                PARCEHIS_RENUM_DOCUMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.ToString(),
                PARCEHIS_DATA_QUITACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                PARCEHIS_COD_EMPRESA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
            };

            R1250_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1.Execute(r1250_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-PARCELAS-SECTION */
        private void R1300_00_SELECT_PARCELAS_SECTION()
        {
            /*" -1780- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1789- PERFORM R1300_00_SELECT_PARCELAS_DB_SELECT_1 */

            R1300_00_SELECT_PARCELAS_DB_SELECT_1();

            /*" -1792- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1794- MOVE ZEROS TO PARCELAS-NUM-PARCELA */
                _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);

                /*" -1795- ELSE */
            }
            else
            {


                /*" -1796- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1797- DISPLAY 'R1300-00 - PROBLEMAS SELECT  (PARCELAS)   ' */
                    _.Display($"R1300-00 - PROBLEMAS SELECT  (PARCELAS)   ");

                    /*" -1798- DISPLAY 'NUM-APOLICE     = ' PARCELAS-NUM-APOLICE */
                    _.Display($"NUM-APOLICE     = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                    /*" -1799- DISPLAY 'NUM-ENDOSSO     = ' PARCELAS-NUM-ENDOSSO */
                    _.Display($"NUM-ENDOSSO     = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                    /*" -1800- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1801- ELSE */
                }
                else
                {


                    /*" -1802- IF VIND-COUNT LESS ZEROS */

                    if (VIND_COUNT < 00)
                    {

                        /*" -1806- MOVE ZEROS TO PARCELAS-NUM-PARCELA. */
                        _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);
                    }

                }

            }


            /*" -1807- IF PARCELAS-NUM-PARCELA EQUAL ZEROS */

            if (PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA == 00)
            {

                /*" -1807- PERFORM R1350-00-UPDATE-ENDOSSOS. */

                R1350_00_UPDATE_ENDOSSOS_SECTION();
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-PARCELAS-DB-SELECT-1 */
        public void R1300_00_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -1789- EXEC SQL SELECT COUNT(*) INTO :PARCELAS-NUM-PARCELA:VIND-COUNT FROM SEGUROS.PARCELAS WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var r1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCELAS_NUM_PARCELA, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);
                _.Move(executed_1.VIND_COUNT, VIND_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1350-00-UPDATE-ENDOSSOS-SECTION */
        private void R1350_00_UPDATE_ENDOSSOS_SECTION()
        {
            /*" -1820- MOVE '1350' TO WNR-EXEC-SQL. */
            _.Move("1350", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1824- MOVE '1' TO ENDOSSOS-SIT-REGISTRO. */
            _.Move("1", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);

            /*" -1830- PERFORM R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1 */

            R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1();

            /*" -1833- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1834- DISPLAY 'R1350-00 - PROBLEMAS UPDATE (ENDOSSOS)   ' */
                _.Display($"R1350-00 - PROBLEMAS UPDATE (ENDOSSOS)   ");

                /*" -1835- DISPLAY 'NUM-APOLICE     = ' PARCELAS-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -1836- DISPLAY 'NUM-ENDOSSO     = ' PARCELAS-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -1836- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1350-00-UPDATE-ENDOSSOS-DB-UPDATE-1 */
        public void R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1()
        {
            /*" -1830- EXEC SQL UPDATE SEGUROS.ENDOSSOS SET SIT_REGISTRO = :ENDOSSOS-SIT-REGISTRO WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO END-EXEC. */

            var r1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1 = new R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1()
            {
                ENDOSSOS_SIT_REGISTRO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO.ToString(),
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
            };

            R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1.Execute(r1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-NAO-PREVISTO-SECTION */
        private void R1400_00_NAO_PREVISTO_SECTION()
        {
            /*" -1849- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1852- PERFORM R1520-00-SELECT-ENDOSSOS. */

            R1520_00_SELECT_ENDOSSOS_SECTION();

            /*" -1854- MOVE MOVIMCOB-NUM-AVISO TO LD01-CONVENIO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, AUX_RELATORIO.LD01.LD01_CONVENIO);

            /*" -1856- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO LD01-PROPOSTA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, AUX_RELATORIO.LD01.LD01_PROPOSTA);

            /*" -1858- MOVE MOVIMCOB-NUM-TITULO TO LD01-BILHETE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, AUX_RELATORIO.LD01.LD01_BILHETE);

            /*" -1860- MOVE MOVIMCOB-NUM-FITA TO LD01-NSAS. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA, AUX_RELATORIO.LD01.LD01_NSAS);

            /*" -1862- MOVE MOVIMCOB-VAL-TITULO TO LD01-VALOR. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, AUX_RELATORIO.LD01.LD01_VALOR);

            /*" -1864- MOVE MOVIMCOB-NUM-APOLICE TO LD01-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, AUX_RELATORIO.LD01.LD01_APOLICE);

            /*" -1866- MOVE MOVIMCOB-NUM-ENDOSSO TO LD01-ENDOSSO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, AUX_RELATORIO.LD01.LD01_ENDOSSO);

            /*" -1868- MOVE MOVIMCOB-NUM-PARCELA TO LD01-PARCELA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, AUX_RELATORIO.LD01.LD01_PARCELA);

            /*" -1870- MOVE ENDOSSOS-COD-PRODUTO TO LD01-CODPRODU. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, AUX_RELATORIO.LD01.LD01_CODPRODU);

            /*" -1873- MOVE MOVIMCOB-NOME-SEGURADO TO LD01-IDLG. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO, AUX_RELATORIO.LD01.LD01_IDLG);

            /*" -1875- MOVE MOVIMCOB-DATA-MOVIMENTO TO WDATA-REL */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO, W.WDATA_REL);

            /*" -1876- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1877- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1878- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1880- MOVE WDATA-CABEC TO LD01-DTPAGTO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTPAGTO);

            /*" -1882- MOVE MOVIMCOB-DATA-QUITACAO TO WDATA-REL */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, W.WDATA_REL);

            /*" -1883- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1884- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1885- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1887- MOVE WDATA-CABEC TO LD01-DTCREDITO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTCREDITO);

            /*" -1888- MOVE SPACES TO WS-STATUS. */
            _.Move("", W.WS_STATUS);

            /*" -1889- MOVE WS-STATUS TO LD01-STATUS. */
            _.Move(W.WS_STATUS, AUX_RELATORIO.LD01.LD01_STATUS);

            /*" -1893- MOVE SPACES TO LD01-MENSAGEM2. */
            _.Move("", AUX_RELATORIO.LD01.LD01_MENSAGEM2);

            /*" -1894- WRITE REG-BI6253B FROM LD01. */
            _.Move(AUX_RELATORIO.LD01.GetMoveValues(), REG_BI6253B);

            BI6253B1.Write(REG_BI6253B.GetMoveValues().ToString());

            /*" -1894- ADD 1 TO GV-SAIDA. */
            W.GV_SAIDA.Value = W.GV_SAIDA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-TRATA-REJEITADOS-SECTION */
        private void R1500_00_TRATA_REJEITADOS_SECTION()
        {
            /*" -1907- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1910- PERFORM R1520-00-SELECT-ENDOSSOS. */

            R1520_00_SELECT_ENDOSSOS_SECTION();

            /*" -1912- MOVE MOVIMCOB-NUM-AVISO TO LD01-CONVENIO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, AUX_RELATORIO.LD01.LD01_CONVENIO);

            /*" -1914- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO LD01-PROPOSTA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, AUX_RELATORIO.LD01.LD01_PROPOSTA);

            /*" -1916- MOVE MOVIMCOB-NUM-TITULO TO LD01-BILHETE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, AUX_RELATORIO.LD01.LD01_BILHETE);

            /*" -1918- MOVE MOVIMCOB-NUM-FITA TO LD01-NSAS. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA, AUX_RELATORIO.LD01.LD01_NSAS);

            /*" -1920- MOVE MOVIMCOB-VAL-TITULO TO LD01-VALOR. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, AUX_RELATORIO.LD01.LD01_VALOR);

            /*" -1922- MOVE MOVIMCOB-NUM-APOLICE TO LD01-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, AUX_RELATORIO.LD01.LD01_APOLICE);

            /*" -1924- MOVE MOVIMCOB-NUM-ENDOSSO TO LD01-ENDOSSO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, AUX_RELATORIO.LD01.LD01_ENDOSSO);

            /*" -1926- MOVE MOVIMCOB-NUM-PARCELA TO LD01-PARCELA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, AUX_RELATORIO.LD01.LD01_PARCELA);

            /*" -1928- MOVE ENDOSSOS-COD-PRODUTO TO LD01-CODPRODU. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, AUX_RELATORIO.LD01.LD01_CODPRODU);

            /*" -1931- MOVE SOR-IDLG TO LD01-IDLG. */
            _.Move(REG_ARQSORT.SOR_IDLG, AUX_RELATORIO.LD01.LD01_IDLG);

            /*" -1933- MOVE MOVIMCOB-DATA-MOVIMENTO TO WDATA-REL */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO, W.WDATA_REL);

            /*" -1934- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1935- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1936- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1938- MOVE WDATA-CABEC TO LD01-DTPAGTO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTPAGTO);

            /*" -1940- MOVE MOVIMCOB-DATA-QUITACAO TO WDATA-REL */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, W.WDATA_REL);

            /*" -1941- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1942- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1943- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1945- MOVE WDATA-CABEC TO LD01-DTCREDITO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTCREDITO);

            /*" -1946- MOVE SPACES TO WS-STATUS. */
            _.Move("", W.WS_STATUS);

            /*" -1948- MOVE MOVIMCOB-COD-MOVIMENTO TO WS-STA-VENDA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO, W.WS_STATUS.WS_STA_VENDA);

            /*" -1949- MOVE ' - ' TO WS-TRACO. */
            _.Move(" - ", W.WS_STATUS.WS_TRACO);

            /*" -1951- MOVE SOR-COD-ERRO TO WS-COD-ERRO. */
            _.Move(REG_ARQSORT.SOR_IDLG.SOR_COD_ERRO, W.WS_STATUS.WS_COD_ERRO);

            /*" -1954- MOVE WS-STATUS TO LD01-STATUS. */
            _.Move(W.WS_STATUS, AUX_RELATORIO.LD01.LD01_STATUS);

            /*" -1957- MOVE 'STATUS NAO CADASTRADO ' TO LD01-MENSAGEM1. */
            _.Move("STATUS NAO CADASTRADO ", AUX_RELATORIO.LD01.LD01_MENSAGEM1);

            /*" -1958- SET WS-VEN TO 1. */
            WS_VEN.Value = 1;

            /*" -1959- SEARCH TB-OCORREVEN */
            for (; WS_VEN < TABELA_VENDAS_ERNET.FILLER_112.TB_OCORREVEN.Items.Count; WS_VEN.Value++)
            {

                /*" -1961- WHEN WS-STA-VENDA EQUAL VEN-CODIGO(WS-VEN) */

                if (W.WS_STATUS.WS_STA_VENDA == TABELA_VENDAS_ERNET.FILLER_112.TB_OCORREVEN[WS_VEN].VEN_CODIGO)
                {


                    /*" -1962- MOVE VEN-DESCRICAO(WS-VEN) TO LD01-MENSAGEM1  END-SEARCH. */
                    break;
                }
            }


            /*" -1968- MOVE 'ERRO   NAO CADASTRADO ' TO LD01-MENSAGEM2. */
            _.Move("ERRO   NAO CADASTRADO ", AUX_RELATORIO.LD01.LD01_MENSAGEM2);

            /*" -1969- SET WS-ERR TO 1. */
            WS_ERR.Value = 1;

            /*" -1970- SEARCH TB-OCORRECOD */
            for (; WS_ERR < TABELA_ERRO_ERNET.FILLER_139.TB_OCORRECOD.Items.Count; WS_ERR.Value++)
            {

                /*" -1972- WHEN WS-COD-ERRO EQUAL ERR-CODIGO(WS-ERR) */

                if (W.WS_STATUS.WS_COD_ERRO == TABELA_ERRO_ERNET.FILLER_139.TB_OCORRECOD[WS_ERR].ERR_CODIGO)
                {


                    /*" -1973- MOVE ERR-DESCRICAO(WS-ERR) TO LD01-MENSAGEM2  END-SEARCH. */
                    break;
                }
            }


            /*" -1977- WRITE REG-BI6253B FROM LD01. */
            _.Move(AUX_RELATORIO.LD01.GetMoveValues(), REG_BI6253B);

            BI6253B1.Write(REG_BI6253B.GetMoveValues().ToString());

            /*" -1984- ADD 1 TO GV-SAIDA. */
            W.GV_SAIDA.Value = W.GV_SAIDA + 1;

            /*" -1987- MOVE '3' TO MOVIMCOB-SIT-REGISTRO. */
            _.Move("3", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -1993- PERFORM R8900-00-UPDATE-V0MOVICOB. */

            R8900_00_UPDATE_V0MOVICOB_SECTION();

            /*" -1995- MOVE SOR-IDLG-CONV TO MOVDEBCE-COD-CONVENIO. */
            _.Move(REG_ARQSORT.SOR_IDLG.SOR_IDLG_CONV, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -1997- MOVE SOR-IDLG-NSA TO MOVDEBCE-NSAS. */
            _.Move(REG_ARQSORT.SOR_IDLG.SOR_IDLG_NSA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -1999- MOVE SOR-IDLG-NUMAPOL TO MOVDEBCE-NUM-APOLICE. */
            _.Move(REG_ARQSORT.SOR_IDLG.SOR_IDLG_NUMAPOL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -2001- MOVE SOR-IDLG-NUMENDO TO MOVDEBCE-NUM-ENDOSSO. */
            _.Move(REG_ARQSORT.SOR_IDLG.SOR_IDLG_NUMENDO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -2004- MOVE SOR-IDLG-NUMPARC TO MOVDEBCE-NUM-PARCELA. */
            _.Move(REG_ARQSORT.SOR_IDLG.SOR_IDLG_NUMPARC, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -2008- MOVE ZEROS TO VIND-DTRETORNO VIND-CODRET VIND-USUARIO. */
            _.Move(0, VIND_DTRETORNO, VIND_CODRET, VIND_USUARIO);

            /*" -2012- MOVE -1 TO VIND-DTCREDITO VIND-VLRCREDITO. */
            _.Move(-1, VIND_DTCREDITO, VIND_VLRCREDITO);

            /*" -2014- MOVE '3' TO MOVDEBCE-SITUACAO-COBRANCA. */
            _.Move("3", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -2016- MOVE MOVIMCOB-COD-MOVIMENTO TO MOVDEBCE-COD-RETORNO-CEF. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

            /*" -2018- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-RETORNO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO);

            /*" -2020- MOVE 'BI6253B' TO MOVDEBCE-COD-USUARIO. */
            _.Move("BI6253B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -2022- MOVE SPACES TO MOVDEBCE-DTCREDITO. */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO);

            /*" -2025- MOVE ZEROS TO MOVDEBCE-VLR-CREDITO. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);

            /*" -2025- PERFORM R9000-00-UPDATE-V0MOVDEBCE. */

            R9000_00_UPDATE_V0MOVDEBCE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1520-00-SELECT-ENDOSSOS-SECTION */
        private void R1520_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -2038- MOVE '1520' TO WNR-EXEC-SQL. */
            _.Move("1520", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2040- MOVE MOVIMCOB-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -2044- MOVE MOVIMCOB-NUM-ENDOSSO TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -2053- PERFORM R1520_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R1520_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -2057- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2058- PERFORM R1530-00-SELECT-PROPOSTA */

                R1530_00_SELECT_PROPOSTA_SECTION();

                /*" -2059- ELSE */
            }
            else
            {


                /*" -2060- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2061- DISPLAY 'R1520-00 - PROBLEMAS SELECT  (ENDOSSOS)' */
                    _.Display($"R1520-00 - PROBLEMAS SELECT  (ENDOSSOS)");

                    /*" -2061- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1520-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R1520_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -2053- EXEC SQL SELECT COD_PRODUTO INTO :ENDOSSOS-COD-PRODUTO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R1520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r1520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1520_99_SAIDA*/

        [StopWatch]
        /*" R1530-00-SELECT-PROPOSTA-SECTION */
        private void R1530_00_SELECT_PROPOSTA_SECTION()
        {
            /*" -2074- MOVE '1530' TO WNR-EXEC-SQL. */
            _.Move("1530", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2076- MOVE MOVIMCOB-NUM-APOLICE TO PROPOSTA-COD-FONTE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE);

            /*" -2079- MOVE MOVIMCOB-NUM-ENDOSSO TO PROPOSTA-NUM-PROPOSTA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA);

            /*" -2088- PERFORM R1530_00_SELECT_PROPOSTA_DB_SELECT_1 */

            R1530_00_SELECT_PROPOSTA_DB_SELECT_1();

            /*" -2092- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2094- MOVE ZEROS TO ENDOSSOS-COD-PRODUTO */
                _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);

                /*" -2095- ELSE */
            }
            else
            {


                /*" -2096- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2097- DISPLAY 'R1530-00 - PROBLEMAS SELECT (PROPOSTAS)' */
                    _.Display($"R1530-00 - PROBLEMAS SELECT (PROPOSTAS)");

                    /*" -2097- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1530-00-SELECT-PROPOSTA-DB-SELECT-1 */
        public void R1530_00_SELECT_PROPOSTA_DB_SELECT_1()
        {
            /*" -2088- EXEC SQL SELECT COD_PRODUTO INTO :ENDOSSOS-COD-PRODUTO FROM SEGUROS.PROPOSTAS WHERE COD_FONTE = :PROPOSTA-COD-FONTE AND NUM_PROPOSTA = :PROPOSTA-NUM-PROPOSTA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 = new R1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPOSTA_NUM_PROPOSTA = PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA.ToString(),
                PROPOSTA_COD_FONTE = PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE.ToString(),
            };

            var executed_1 = R1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1.Execute(r1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1530_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-TRATA-FOLLOWUP-SECTION */
        private void R2000_00_TRATA_FOLLOWUP_SECTION()
        {
            /*" -2111- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2114- ADD SOR-VAL-TITULO TO AVISOSAL-SALDO-ATUAL. */
            AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL.Value = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL + REG_ARQSORT.SOR_VAL_TITULO;

            /*" -2116- MOVE SOR-NUM-AVISO TO LD01-CONVENIO. */
            _.Move(REG_ARQSORT.SOR_NUM_AVISO, AUX_RELATORIO.LD01.LD01_CONVENIO);

            /*" -2118- MOVE SOR-NUM-NOSSO-TITULO TO LD01-PROPOSTA. */
            _.Move(REG_ARQSORT.SOR_NUM_NOSSO_TITULO, AUX_RELATORIO.LD01.LD01_PROPOSTA);

            /*" -2120- MOVE SOR-NUM-TITULO TO LD01-BILHETE. */
            _.Move(REG_ARQSORT.SOR_NUM_TITULO, AUX_RELATORIO.LD01.LD01_BILHETE);

            /*" -2122- MOVE SOR-NUM-FITA TO LD01-NSAS. */
            _.Move(REG_ARQSORT.SOR_NUM_FITA, AUX_RELATORIO.LD01.LD01_NSAS);

            /*" -2124- MOVE SOR-VAL-TITULO TO LD01-VALOR. */
            _.Move(REG_ARQSORT.SOR_VAL_TITULO, AUX_RELATORIO.LD01.LD01_VALOR);

            /*" -2126- MOVE SOR-NUM-APOLICE TO LD01-APOLICE. */
            _.Move(REG_ARQSORT.SOR_NUM_APOLICE, AUX_RELATORIO.LD01.LD01_APOLICE);

            /*" -2128- MOVE SOR-NUM-ENDOSSO TO LD01-ENDOSSO. */
            _.Move(REG_ARQSORT.SOR_NUM_ENDOSSO, AUX_RELATORIO.LD01.LD01_ENDOSSO);

            /*" -2130- MOVE SOR-NUM-PARCELA TO LD01-PARCELA. */
            _.Move(REG_ARQSORT.SOR_NUM_PARCELA, AUX_RELATORIO.LD01.LD01_PARCELA);

            /*" -2132- MOVE SOR-COD-PRODUTO TO LD01-CODPRODU. */
            _.Move(REG_ARQSORT.SOR_COD_PRODUTO, AUX_RELATORIO.LD01.LD01_CODPRODU);

            /*" -2135- MOVE SOR-IDLG TO LD01-IDLG. */
            _.Move(REG_ARQSORT.SOR_IDLG, AUX_RELATORIO.LD01.LD01_IDLG);

            /*" -2137- MOVE SOR-DATA-MOVIMENTO TO WDATA-REL */
            _.Move(REG_ARQSORT.SOR_DATA_MOVIMENTO, W.WDATA_REL);

            /*" -2138- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -2139- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -2140- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -2142- MOVE WDATA-CABEC TO LD01-DTPAGTO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTPAGTO);

            /*" -2144- MOVE SOR-DATA-QUITACAO TO WDATA-REL */
            _.Move(REG_ARQSORT.SOR_DATA_QUITACAO, W.WDATA_REL);

            /*" -2145- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -2146- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -2147- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -2149- MOVE WDATA-CABEC TO LD01-DTCREDITO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTCREDITO);

            /*" -2151- MOVE SPACES TO LD01-STATUS LD01-MENSAGEM1. */
            _.Move("", AUX_RELATORIO.LD01.LD01_STATUS, AUX_RELATORIO.LD01.LD01_MENSAGEM1);

            /*" -2154- MOVE 'REGISTRO PENDENTE EM FOLLOW_UP          ' TO LD01-MENSAGEM2. */
            _.Move("REGISTRO PENDENTE EM FOLLOW_UP          ", AUX_RELATORIO.LD01.LD01_MENSAGEM2);

            /*" -2162- MOVE SPACES TO FOLLOUP-COD-ERRO01 FOLLOUP-COD-ERRO02 FOLLOUP-COD-ERRO03 FOLLOUP-COD-ERRO04 FOLLOUP-COD-ERRO05 FOLLOUP-COD-ERRO06. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO01, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO02, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO03, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO04, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO05, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO06);

            /*" -2163- IF SOR-SIT-REGISTRO EQUAL '1' */

            if (REG_ARQSORT.SOR_SIT_REGISTRO == "1")
            {

                /*" -2165- MOVE '1' TO FOLLOUP-COD-ERRO03 */
                _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO03);

                /*" -2167- MOVE 'PARCELA PAGA                            ' TO LD01-MENSAGEM1 */
                _.Move("PARCELA PAGA                            ", AUX_RELATORIO.LD01.LD01_MENSAGEM1);

                /*" -2168- ELSE */
            }
            else
            {


                /*" -2169- IF SOR-SIT-REGISTRO EQUAL '2' */

                if (REG_ARQSORT.SOR_SIT_REGISTRO == "2")
                {

                    /*" -2171- MOVE '1' TO FOLLOUP-COD-ERRO04 */
                    _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO04);

                    /*" -2173- MOVE 'PARCELA CANCELADA                       ' TO LD01-MENSAGEM1 */
                    _.Move("PARCELA CANCELADA                       ", AUX_RELATORIO.LD01.LD01_MENSAGEM1);

                    /*" -2174- ELSE */
                }
                else
                {


                    /*" -2175- IF SOR-SIT-REGISTRO NOT EQUAL '0' */

                    if (REG_ARQSORT.SOR_SIT_REGISTRO != "0")
                    {

                        /*" -2177- MOVE '1' TO FOLLOUP-COD-ERRO02 */
                        _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO02);

                        /*" -2181- MOVE 'PARCELA NAO PENDENTE                    ' TO LD01-MENSAGEM1. */
                        _.Move("PARCELA NAO PENDENTE                    ", AUX_RELATORIO.LD01.LD01_MENSAGEM1);
                    }

                }

            }


            /*" -2182- WRITE REG-BI6253B FROM LD01. */
            _.Move(AUX_RELATORIO.LD01.GetMoveValues(), REG_BI6253B);

            BI6253B1.Write(REG_BI6253B.GetMoveValues().ToString());

            /*" -2187- ADD 1 TO GV-SAIDA. */
            W.GV_SAIDA.Value = W.GV_SAIDA + 1;

            /*" -2189- MOVE SOR-NUM-APOLICE TO FOLLOUP-NUM-APOLICE. */
            _.Move(REG_ARQSORT.SOR_NUM_APOLICE, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE);

            /*" -2191- MOVE SOR-NUM-ENDOSSO TO FOLLOUP-NUM-ENDOSSO. */
            _.Move(REG_ARQSORT.SOR_NUM_ENDOSSO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO);

            /*" -2193- MOVE SOR-NUM-PARCELA TO FOLLOUP-NUM-PARCELA. */
            _.Move(REG_ARQSORT.SOR_NUM_PARCELA, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA);

            /*" -2195- MOVE SPACES TO FOLLOUP-DAC-PARCELA. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DAC_PARCELA);

            /*" -2197- MOVE SISTEMAS-DATA-MOV-ABERTO TO FOLLOUP-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO);

            /*" -2199- MOVE SOR-VAL-TITULO TO FOLLOUP-VAL-OPERACAO. */
            _.Move(REG_ARQSORT.SOR_VAL_TITULO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);

            /*" -2201- MOVE AVISOCRE-BCO-AVISO TO FOLLOUP-BCO-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO);

            /*" -2203- MOVE AVISOCRE-AGE-AVISO TO FOLLOUP-AGE-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO);

            /*" -2205- MOVE AVISOCRE-NUM-AVISO-CREDITO TO FOLLOUP-NUM-AVISO-CREDITO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO);

            /*" -2207- MOVE 30 TO FOLLOUP-COD-BAIXA-PARCELA. */
            _.Move(30, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_BAIXA_PARCELA);

            /*" -2209- MOVE '0' TO FOLLOUP-SIT-REGISTRO. */
            _.Move("0", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_REGISTRO);

            /*" -2211- MOVE '0' TO FOLLOUP-SIT-CONTABIL. */
            _.Move("0", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_CONTABIL);

            /*" -2213- MOVE 103 TO FOLLOUP-COD-OPERACAO. */
            _.Move(103, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_OPERACAO);

            /*" -2215- MOVE SPACES TO FOLLOUP-DATA-LIBERACAO. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_LIBERACAO);

            /*" -2217- MOVE SOR-DATA-QUITACAO TO FOLLOUP-DATA-QUITACAO. */
            _.Move(REG_ARQSORT.SOR_DATA_QUITACAO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_QUITACAO);

            /*" -2219- MOVE '1' TO FOLLOUP-TIPO-SEGURO */
            _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_TIPO_SEGURO);

            /*" -2222- MOVE SOR-NUM-NOSSO-TITULO TO FOLLOUP-NUM-NOSSO-TITULO. */
            _.Move(REG_ARQSORT.SOR_NUM_NOSSO_TITULO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_NOSSO_TITULO);

            /*" -2229- MOVE ZEROS TO FOLLOUP-COD-EMPRESA FOLLOUP-ORDEM-LIDER FOLLOUP-COD-LIDER FOLLOUP-COD-FONTE FOLLOUP-NUM-RCAP. */
            _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_EMPRESA, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ORDEM_LIDER, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_LIDER, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_FONTE, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_RCAP);

            /*" -2234- MOVE SPACES TO FOLLOUP-NUM-APOL-LIDER FOLLOUP-ENDOS-LIDER. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOL_LIDER, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ENDOS_LIDER);

            /*" -2238- MOVE ZEROS TO VIND-DTQITBCO VIND-CODEMP VIND-TIPSGU. */
            _.Move(0, VIND_DTQITBCO, VIND_CODEMP, VIND_TIPSGU);

            /*" -2247- MOVE -1 TO VIND-DTLIBER VIND-ORDLIDER VIND-APOLIDER VIND-ENDOSLID VIND-CODLIDER VIND-FONTE VIND-NRRCAP. */
            _.Move(-1, VIND_DTLIBER, VIND_ORDLIDER, VIND_APOLIDER, VIND_ENDOSLID, VIND_CODLIDER, VIND_FONTE, VIND_NRRCAP);

            /*" -2248- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -2249- MOVE WS-HH-TIME TO WTIME-HORA. */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_6.WTIME_DAYR.WTIME_HORA);

            /*" -2250- MOVE '.' TO WTIME-2PT1. */
            _.Move(".", W.FILLER_6.WTIME_DAYR.WTIME_2PT1);

            /*" -2251- MOVE WS-MM-TIME TO WTIME-MINU. */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_6.WTIME_DAYR.WTIME_MINU);

            /*" -2252- MOVE '.' TO WTIME-2PT2. */
            _.Move(".", W.FILLER_6.WTIME_DAYR.WTIME_2PT2);

            /*" -2253- MOVE WS-SS-TIME TO WTIME-SEGU. */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_6.WTIME_DAYR.WTIME_SEGU);

            /*" -2256- MOVE WTIME-DAYR TO FOLLOUP-HORA-OPERACAO. */
            _.Move(W.FILLER_6.WTIME_DAYR, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO);

            /*" -2258- MOVE ZEROS TO AC-DUPLICA. */
            _.Move(0, W.AC_DUPLICA);

            /*" -2258- PERFORM R2100-00-INSERT-FOLLOWUP. */

            R2100_00_INSERT_FOLLOWUP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-INSERT-FOLLOWUP-SECTION */
        private void R2100_00_INSERT_FOLLOWUP_SECTION()
        {
            /*" -2271- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2338- PERFORM R2100_00_INSERT_FOLLOWUP_DB_INSERT_1 */

            R2100_00_INSERT_FOLLOWUP_DB_INSERT_1();

            /*" -2343- IF SQLCODE EQUAL -803 AND AC-DUPLICA LESS 10 */

            if (DB.SQLCODE == -803 && W.AC_DUPLICA < 10)
            {

                /*" -2344- ADD 1 TO AC-DUPLICA */
                W.AC_DUPLICA.Value = W.AC_DUPLICA + 1;

                /*" -2345- PERFORM R2110-00-ADICIONA-TIME */

                R2110_00_ADICIONA_TIME_SECTION();

                /*" -2346- GO TO R2100-00-INSERT-FOLLOWUP */
                new Task(() => R2100_00_INSERT_FOLLOWUP_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2347- ELSE */
            }
            else
            {


                /*" -2348- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2349- DISPLAY 'R2100-00 - PROBLEMAS NO INSERT(FOLLOUP)    ' */
                    _.Display($"R2100-00 - PROBLEMAS NO INSERT(FOLLOUP)    ");

                    /*" -2350- DISPLAY 'NUM-NOSSO-TITULO=' FOLLOUP-NUM-NOSSO-TITULO */
                    _.Display($"NUM-NOSSO-TITULO={FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_NOSSO_TITULO}");

                    /*" -2353- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2353- ADD 1 TO AC-FOLLOWUP. */
            W.AC_FOLLOWUP.Value = W.AC_FOLLOWUP + 1;

        }

        [StopWatch]
        /*" R2100-00-INSERT-FOLLOWUP-DB-INSERT-1 */
        public void R2100_00_INSERT_FOLLOWUP_DB_INSERT_1()
        {
            /*" -2338- EXEC SQL INSERT INTO SEGUROS.FOLLOW_UP (NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DAC_PARCELA , DATA_MOVIMENTO , HORA_OPERACAO , VAL_OPERACAO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , COD_BAIXA_PARCELA , COD_ERRO01 , COD_ERRO02 , COD_ERRO03 , COD_ERRO04 , COD_ERRO05 , COD_ERRO06 , SIT_REGISTRO , SIT_CONTABIL , COD_OPERACAO , DATA_LIBERACAO , DATA_QUITACAO , COD_EMPRESA , TIMESTAMP , ORDEM_LIDER , TIPO_SEGURO , NUM_APOL_LIDER , ENDOS_LIDER , COD_LIDER , COD_FONTE , NUM_RCAP , NUM_NOSSO_TITULO) VALUES (:FOLLOUP-NUM-APOLICE , :FOLLOUP-NUM-ENDOSSO , :FOLLOUP-NUM-PARCELA , :FOLLOUP-DAC-PARCELA , :FOLLOUP-DATA-MOVIMENTO , :FOLLOUP-HORA-OPERACAO , :FOLLOUP-VAL-OPERACAO , :FOLLOUP-BCO-AVISO , :FOLLOUP-AGE-AVISO , :FOLLOUP-NUM-AVISO-CREDITO , :FOLLOUP-COD-BAIXA-PARCELA , :FOLLOUP-COD-ERRO01 , :FOLLOUP-COD-ERRO02 , :FOLLOUP-COD-ERRO03 , :FOLLOUP-COD-ERRO04 , :FOLLOUP-COD-ERRO05 , :FOLLOUP-COD-ERRO06 , :FOLLOUP-SIT-REGISTRO , :FOLLOUP-SIT-CONTABIL , :FOLLOUP-COD-OPERACAO , :FOLLOUP-DATA-LIBERACAO:VIND-DTLIBER , :FOLLOUP-DATA-QUITACAO:VIND-DTQITBCO , :FOLLOUP-COD-EMPRESA:VIND-CODEMP , CURRENT TIMESTAMP , :FOLLOUP-ORDEM-LIDER:VIND-ORDLIDER , :FOLLOUP-TIPO-SEGURO:VIND-TIPSGU , :FOLLOUP-NUM-APOL-LIDER:VIND-APOLIDER, :FOLLOUP-ENDOS-LIDER:VIND-ENDOSLID , :FOLLOUP-COD-LIDER:VIND-CODLIDER , :FOLLOUP-COD-FONTE:VIND-FONTE , :FOLLOUP-NUM-RCAP:VIND-NRRCAP , :FOLLOUP-NUM-NOSSO-TITULO) END-EXEC. */

            var r2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1 = new R2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1()
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
                VIND_DTLIBER = VIND_DTLIBER.ToString(),
                FOLLOUP_DATA_QUITACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_QUITACAO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                FOLLOUP_COD_EMPRESA = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_EMPRESA.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                FOLLOUP_ORDEM_LIDER = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ORDEM_LIDER.ToString(),
                VIND_ORDLIDER = VIND_ORDLIDER.ToString(),
                FOLLOUP_TIPO_SEGURO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_TIPO_SEGURO.ToString(),
                VIND_TIPSGU = VIND_TIPSGU.ToString(),
                FOLLOUP_NUM_APOL_LIDER = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOL_LIDER.ToString(),
                VIND_APOLIDER = VIND_APOLIDER.ToString(),
                FOLLOUP_ENDOS_LIDER = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ENDOS_LIDER.ToString(),
                VIND_ENDOSLID = VIND_ENDOSLID.ToString(),
                FOLLOUP_COD_LIDER = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_LIDER.ToString(),
                VIND_CODLIDER = VIND_CODLIDER.ToString(),
                FOLLOUP_COD_FONTE = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_FONTE.ToString(),
                VIND_FONTE = VIND_FONTE.ToString(),
                FOLLOUP_NUM_RCAP = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_RCAP.ToString(),
                VIND_NRRCAP = VIND_NRRCAP.ToString(),
                FOLLOUP_NUM_NOSSO_TITULO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_NOSSO_TITULO.ToString(),
            };

            R2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1.Execute(r2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2110-00-ADICIONA-TIME-SECTION */
        private void R2110_00_ADICIONA_TIME_SECTION()
        {
            /*" -2366- MOVE '2110' TO WNR-EXEC-SQL. */
            _.Move("2110", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2368- IF WTIME-SEGU GREATER ZEROS AND WTIME-SEGU LESS 59 */

            if (W.FILLER_6.WTIME_DAYR.WTIME_SEGU > 00 && W.FILLER_6.WTIME_DAYR.WTIME_SEGU < 59)
            {

                /*" -2369- ADD 1 TO WTIME-SEGU */
                W.FILLER_6.WTIME_DAYR.WTIME_SEGU.Value = W.FILLER_6.WTIME_DAYR.WTIME_SEGU + 1;

                /*" -2370- ELSE */
            }
            else
            {


                /*" -2372- IF WTIME-MINU GREATER ZEROS AND WTIME-MINU LESS 59 */

                if (W.FILLER_6.WTIME_DAYR.WTIME_MINU > 00 && W.FILLER_6.WTIME_DAYR.WTIME_MINU < 59)
                {

                    /*" -2373- ADD 1 TO WTIME-MINU */
                    W.FILLER_6.WTIME_DAYR.WTIME_MINU.Value = W.FILLER_6.WTIME_DAYR.WTIME_MINU + 1;

                    /*" -2374- MOVE 1 TO WTIME-SEGU */
                    _.Move(1, W.FILLER_6.WTIME_DAYR.WTIME_SEGU);

                    /*" -2375- ELSE */
                }
                else
                {


                    /*" -2377- IF WTIME-HORA GREATER ZEROS AND WTIME-HORA LESS 23 */

                    if (W.FILLER_6.WTIME_DAYR.WTIME_HORA > 00 && W.FILLER_6.WTIME_DAYR.WTIME_HORA < 23)
                    {

                        /*" -2378- ADD 1 TO WTIME-HORA */
                        W.FILLER_6.WTIME_DAYR.WTIME_HORA.Value = W.FILLER_6.WTIME_DAYR.WTIME_HORA + 1;

                        /*" -2379- MOVE 1 TO WTIME-MINU */
                        _.Move(1, W.FILLER_6.WTIME_DAYR.WTIME_MINU);

                        /*" -2380- MOVE 1 TO WTIME-SEGU */
                        _.Move(1, W.FILLER_6.WTIME_DAYR.WTIME_SEGU);

                        /*" -2381- ELSE */
                    }
                    else
                    {


                        /*" -2382- MOVE 1 TO WTIME-HORA */
                        _.Move(1, W.FILLER_6.WTIME_DAYR.WTIME_HORA);

                        /*" -2383- MOVE 1 TO WTIME-MINU */
                        _.Move(1, W.FILLER_6.WTIME_DAYR.WTIME_MINU);

                        /*" -2386- MOVE 1 TO WTIME-SEGU. */
                        _.Move(1, W.FILLER_6.WTIME_DAYR.WTIME_SEGU);
                    }

                }

            }


            /*" -2387- MOVE WTIME-DAYR TO FOLLOUP-HORA-OPERACAO. */
            _.Move(W.FILLER_6.WTIME_DAYR, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/

        [StopWatch]
        /*" R5100-00-INSERT-AVISOCRE-SECTION */
        private void R5100_00_INSERT_AVISOCRE_SECTION()
        {
            /*" -2399- MOVE '5100' TO WNR-EXEC-SQL. */
            _.Move("5100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2403- COMPUTE AVISOCRE-PRM-LIQUIDO EQUAL (AVISOCRE-PRM-TOTAL - AVISOCRE-VAL-DESPESA). */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO.Value = (AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL - AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA);

            /*" -2444- PERFORM R5100_00_INSERT_AVISOCRE_DB_INSERT_1 */

            R5100_00_INSERT_AVISOCRE_DB_INSERT_1();

            /*" -2447- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2451- DISPLAY 'R5100-00 - PROBLEMAS NO INSERT(AVISOCRE)   ' '  ' AVISOCRE-BCO-AVISO '  ' AVISOCRE-AGE-AVISO '  ' AVISOCRE-NUM-AVISO-CREDITO */

                $"R5100-00 - PROBLEMAS NO INSERT(AVISOCRE)     {AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO}  {AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO}  {AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO}"
                .Display();

                /*" -2453- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2453- ADD 1 TO AC-AVISOCRE. */
            W.AC_AVISOCRE.Value = W.AC_AVISOCRE + 1;

        }

        [StopWatch]
        /*" R5100-00-INSERT-AVISOCRE-DB-INSERT-1 */
        public void R5100_00_INSERT_AVISOCRE_DB_INSERT_1()
        {
            /*" -2444- EXEC SQL INSERT INTO SEGUROS.AVISO_CREDITO (BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , NUM_SEQUENCIA , DATA_MOVIMENTO , COD_OPERACAO , TIPO_AVISO , DATA_AVISO , VAL_IOCC , VAL_DESPESA , PRM_COSSEGURO_CED , PRM_LIQUIDO , PRM_TOTAL , SIT_CONTABIL , COD_EMPRESA , TIMESTAMP , ORIGEM_AVISO , VAL_ADIANTAMENTO , STA_DEPOSITO_TER) VALUES (:AVISOCRE-BCO-AVISO , :AVISOCRE-AGE-AVISO , :AVISOCRE-NUM-AVISO-CREDITO , :AVISOCRE-NUM-SEQUENCIA , :AVISOCRE-DATA-MOVIMENTO , :AVISOCRE-COD-OPERACAO , :AVISOCRE-TIPO-AVISO , :AVISOCRE-DATA-AVISO , :AVISOCRE-VAL-IOCC , :AVISOCRE-VAL-DESPESA , :AVISOCRE-PRM-COSSEGURO-CED , :AVISOCRE-PRM-LIQUIDO , :AVISOCRE-PRM-TOTAL , :AVISOCRE-SIT-CONTABIL , :AVISOCRE-COD-EMPRESA , CURRENT TIMESTAMP , :AVISOCRE-ORIGEM-AVISO , :AVISOCRE-VAL-ADIANTAMENTO , :AVISOCRE-STA-DEPOSITO-TER) END-EXEC. */

            var r5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1 = new R5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1()
            {
                AVISOCRE_BCO_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO.ToString(),
                AVISOCRE_AGE_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO.ToString(),
                AVISOCRE_NUM_AVISO_CREDITO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.ToString(),
                AVISOCRE_NUM_SEQUENCIA = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA.ToString(),
                AVISOCRE_DATA_MOVIMENTO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO.ToString(),
                AVISOCRE_COD_OPERACAO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_OPERACAO.ToString(),
                AVISOCRE_TIPO_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO.ToString(),
                AVISOCRE_DATA_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO.ToString(),
                AVISOCRE_VAL_IOCC = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_IOCC.ToString(),
                AVISOCRE_VAL_DESPESA = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA.ToString(),
                AVISOCRE_PRM_COSSEGURO_CED = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_COSSEGURO_CED.ToString(),
                AVISOCRE_PRM_LIQUIDO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO.ToString(),
                AVISOCRE_PRM_TOTAL = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL.ToString(),
                AVISOCRE_SIT_CONTABIL = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_SIT_CONTABIL.ToString(),
                AVISOCRE_COD_EMPRESA = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA.ToString(),
                AVISOCRE_ORIGEM_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO.ToString(),
                AVISOCRE_VAL_ADIANTAMENTO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_ADIANTAMENTO.ToString(),
                AVISOCRE_STA_DEPOSITO_TER = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_STA_DEPOSITO_TER.ToString(),
            };

            R5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1.Execute(r5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/

        [StopWatch]
        /*" R5200-00-INSERT-AVISOSAL-SECTION */
        private void R5200_00_INSERT_AVISOSAL_SECTION()
        {
            /*" -2464- MOVE '5200' TO WNR-EXEC-SQL. */
            _.Move("5200", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2487- PERFORM R5200_00_INSERT_AVISOSAL_DB_INSERT_1 */

            R5200_00_INSERT_AVISOSAL_DB_INSERT_1();

            /*" -2490- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2494- DISPLAY 'R5200-00 - PROBLEMAS NO INSERT(AVISOSAL)   ' '  ' AVISOSAL-BCO-AVISO '  ' AVISOSAL-AGE-AVISO '  ' AVISOSAL-NUM-AVISO-CREDITO */

                $"R5200-00 - PROBLEMAS NO INSERT(AVISOSAL)     {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO}  {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO}  {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO}"
                .Display();

                /*" -2496- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2496- ADD 1 TO AC-AVISOSAL. */
            W.AC_AVISOSAL.Value = W.AC_AVISOSAL + 1;

        }

        [StopWatch]
        /*" R5200-00-INSERT-AVISOSAL-DB-INSERT-1 */
        public void R5200_00_INSERT_AVISOSAL_DB_INSERT_1()
        {
            /*" -2487- EXEC SQL INSERT INTO SEGUROS.AVISOS_SALDOS (COD_EMPRESA , BCO_AVISO , AGE_AVISO , TIPO_SEGURO , NUM_AVISO_CREDITO , DATA_AVISO , DATA_MOVIMENTO , SALDO_ATUAL , SIT_REGISTRO , TIMESTAMP) VALUES (:AVISOSAL-COD-EMPRESA , :AVISOSAL-BCO-AVISO , :AVISOSAL-AGE-AVISO , :AVISOSAL-TIPO-SEGURO , :AVISOSAL-NUM-AVISO-CREDITO , :AVISOSAL-DATA-AVISO , :AVISOSAL-DATA-MOVIMENTO , :AVISOSAL-SALDO-ATUAL , :AVISOSAL-SIT-REGISTRO , CURRENT TIMESTAMP) END-EXEC. */

            var r5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1 = new R5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1()
            {
                AVISOSAL_COD_EMPRESA = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_COD_EMPRESA.ToString(),
                AVISOSAL_BCO_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO.ToString(),
                AVISOSAL_AGE_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO.ToString(),
                AVISOSAL_TIPO_SEGURO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_TIPO_SEGURO.ToString(),
                AVISOSAL_NUM_AVISO_CREDITO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO.ToString(),
                AVISOSAL_DATA_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_AVISO.ToString(),
                AVISOSAL_DATA_MOVIMENTO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO.ToString(),
                AVISOSAL_SALDO_ATUAL = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL.ToString(),
                AVISOSAL_SIT_REGISTRO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO.ToString(),
            };

            R5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1.Execute(r5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5200_99_SAIDA*/

        [StopWatch]
        /*" R5300-00-INSERT-CONDESCE-SECTION */
        private void R5300_00_INSERT_CONDESCE_SECTION()
        {
            /*" -2508- MOVE '5300' TO WNR-EXEC-SQL. */
            _.Move("5300", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2513- COMPUTE CONDESCE-PRM-LIQUIDO EQUAL (CONDESCE-PRM-TOTAL - CONDESCE-VAL-TARIFA). */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO.Value = (CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA);

            /*" -2560- PERFORM R5300_00_INSERT_CONDESCE_DB_INSERT_1 */

            R5300_00_INSERT_CONDESCE_DB_INSERT_1();

            /*" -2563- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2568- DISPLAY 'R5300-00 - PROBLEMAS NO INSERT(CONDESCE)   ' '  ' CONDESCE-BCO-AVISO '  ' CONDESCE-AGE-AVISO '  ' CONDESCE-NUM-AVISO-CREDITO '  ' CONDESCE-COD-PRODUTO */

                $"R5300-00 - PROBLEMAS NO INSERT(CONDESCE)     {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO}"
                .Display();

                /*" -2571- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2571- ADD 1 TO AC-CONDESCE. */
            W.AC_CONDESCE.Value = W.AC_CONDESCE + 1;

        }

        [StopWatch]
        /*" R5300-00-INSERT-CONDESCE-DB-INSERT-1 */
        public void R5300_00_INSERT_CONDESCE_DB_INSERT_1()
        {
            /*" -2560- EXEC SQL INSERT INTO SEGUROS.CONTROL_DESPES_CEF (COD_EMPRESA , ANO_REFERENCIA , MES_REFERENCIA , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , COD_PRODUTO , TIPO_REGISTRO , SITUACAO , TIPO_COBRANCA , DATA_MOVIMENTO , DATA_AVISO , QTD_REGISTROS , PRM_TOTAL , PRM_LIQUIDO , VAL_TARIFA , VAL_BALCAO , VAL_IOCC , VAL_DESCONTO , VAL_JUROS , VAL_MULTA , TIMESTAMP) VALUES (:CONDESCE-COD-EMPRESA , :CONDESCE-ANO-REFERENCIA , :CONDESCE-MES-REFERENCIA , :CONDESCE-BCO-AVISO , :CONDESCE-AGE-AVISO , :CONDESCE-NUM-AVISO-CREDITO , :CONDESCE-COD-PRODUTO , :CONDESCE-TIPO-REGISTRO , :CONDESCE-SITUACAO , :CONDESCE-TIPO-COBRANCA , :CONDESCE-DATA-MOVIMENTO , :CONDESCE-DATA-AVISO , :CONDESCE-QTD-REGISTROS , :CONDESCE-PRM-TOTAL , :CONDESCE-PRM-LIQUIDO , :CONDESCE-VAL-TARIFA , :CONDESCE-VAL-BALCAO , :CONDESCE-VAL-IOCC , :CONDESCE-VAL-DESCONTO , :CONDESCE-VAL-JUROS , :CONDESCE-VAL-MULTA , CURRENT TIMESTAMP) END-EXEC. */

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
        /*" R6000-00-GRAVA-ARQUIVO-SECTION */
        private void R6000_00_GRAVA_ARQUIVO_SECTION()
        {
            /*" -2584- MOVE '6000' TO WNR-EXEC-SQL. */
            _.Move("6000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2586- MOVE MOVIMCOB-NUM-AVISO TO LD01-CONVENIO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, AUX_RELATORIO.LD01.LD01_CONVENIO);

            /*" -2588- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO LD01-PROPOSTA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, AUX_RELATORIO.LD01.LD01_PROPOSTA);

            /*" -2590- MOVE MOVIMCOB-NUM-TITULO TO LD01-BILHETE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, AUX_RELATORIO.LD01.LD01_BILHETE);

            /*" -2592- MOVE MOVIMCOB-NUM-FITA TO LD01-NSAS. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA, AUX_RELATORIO.LD01.LD01_NSAS);

            /*" -2594- MOVE MOVIMCOB-VAL-TITULO TO LD01-VALOR. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, AUX_RELATORIO.LD01.LD01_VALOR);

            /*" -2596- MOVE MOVIMCOB-NUM-APOLICE TO LD01-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, AUX_RELATORIO.LD01.LD01_APOLICE);

            /*" -2598- MOVE MOVIMCOB-NUM-ENDOSSO TO LD01-ENDOSSO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, AUX_RELATORIO.LD01.LD01_ENDOSSO);

            /*" -2600- MOVE MOVIMCOB-NUM-PARCELA TO LD01-PARCELA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, AUX_RELATORIO.LD01.LD01_PARCELA);

            /*" -2602- MOVE ENDOSSOS-COD-PRODUTO TO LD01-CODPRODU. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, AUX_RELATORIO.LD01.LD01_CODPRODU);

            /*" -2605- MOVE SOR-IDLG TO LD01-IDLG. */
            _.Move(REG_ARQSORT.SOR_IDLG, AUX_RELATORIO.LD01.LD01_IDLG);

            /*" -2607- MOVE MOVIMCOB-DATA-MOVIMENTO TO WDATA-REL */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO, W.WDATA_REL);

            /*" -2608- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -2609- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -2610- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -2612- MOVE WDATA-CABEC TO LD01-DTPAGTO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTPAGTO);

            /*" -2614- MOVE MOVIMCOB-DATA-QUITACAO TO WDATA-REL */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, W.WDATA_REL);

            /*" -2615- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -2616- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -2617- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -2619- MOVE WDATA-CABEC TO LD01-DTCREDITO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTCREDITO);

            /*" -2623- MOVE SPACES TO LD01-MENSAGEM2 LD01-STATUS. */
            _.Move("", AUX_RELATORIO.LD01.LD01_MENSAGEM2, AUX_RELATORIO.LD01.LD01_STATUS);

            /*" -2624- WRITE REG-BI6253B FROM LD01. */
            _.Move(AUX_RELATORIO.LD01.GetMoveValues(), REG_BI6253B);

            BI6253B1.Write(REG_BI6253B.GetMoveValues().ToString());

            /*" -2624- ADD 1 TO GV-SAIDA. */
            W.GV_SAIDA.Value = W.GV_SAIDA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R8900-00-UPDATE-V0MOVICOB-SECTION */
        private void R8900_00_UPDATE_V0MOVICOB_SECTION()
        {
            /*" -2637- MOVE '8900' TO WNR-EXEC-SQL. */
            _.Move("8900", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2642- PERFORM R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1 */

            R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1();

            /*" -2645- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2646- DISPLAY 'R8900-00 - PROBLEMAS UPDATE (V0MOVICOB)   ' */
                _.Display($"R8900-00 - PROBLEMAS UPDATE (V0MOVICOB)   ");

                /*" -2647- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -2648- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -2649- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -2650- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -2651- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -2652- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2653- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -2654- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -2655- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -2656- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -2657- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -2659- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2659- ADD 1 TO UP-PROPOSTA. */
            W.UP_PROPOSTA.Value = W.UP_PROPOSTA + 1;

        }

        [StopWatch]
        /*" R8900-00-UPDATE-V0MOVICOB-DB-UPDATE-1 */
        public void R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1()
        {
            /*" -2642- EXEC SQL UPDATE SEGUROS.MOVIMENTO_COBRANCA SET SIT_REGISTRO = :MOVIMCOB-SIT-REGISTRO WHERE CURRENT OF V0MOVIMCOB END-EXEC. */

            var r8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 = new R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1(V0MOVIMCOB)
            {
                MOVIMCOB_SIT_REGISTRO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO.ToString(),
            };

            R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1.Execute(r8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-UPDATE-V0MOVDEBCE-SECTION */
        private void R9000_00_UPDATE_V0MOVDEBCE_SECTION()
        {
            /*" -2672- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2692- PERFORM R9000_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1 */

            R9000_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1();

            /*" -2695- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2696- DISPLAY 'R9000-00 - PROBLEMAS UPDATE (MOVDEBCE)   ' */
                _.Display($"R9000-00 - PROBLEMAS UPDATE (MOVDEBCE)   ");

                /*" -2697- DISPLAY 'COD-CONVENIO    = ' MOVDEBCE-COD-CONVENIO */
                _.Display($"COD-CONVENIO    = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -2698- DISPLAY 'NSAS            = ' MOVDEBCE-NSAS */
                _.Display($"NSAS            = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

                /*" -2699- DISPLAY 'NUM-APOLICE     = ' MOVDEBCE-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -2700- DISPLAY 'NUM-ENDOSSO     = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -2701- DISPLAY 'NUM-PARCELA     = ' MOVDEBCE-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -2703- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2703- ADD 1 TO UP-MOVDEBCE. */
            W.UP_MOVDEBCE.Value = W.UP_MOVDEBCE + 1;

        }

        [StopWatch]
        /*" R9000-00-UPDATE-V0MOVDEBCE-DB-UPDATE-1 */
        public void R9000_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1()
        {
            /*" -2692- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA, DATA_RETORNO = :MOVDEBCE-DATA-RETORNO:VIND-DTRETORNO, COD_RETORNO_CEF = :MOVDEBCE-COD-RETORNO-CEF:VIND-CODRET, COD_USUARIO = :MOVDEBCE-COD-USUARIO:VIND-USUARIO, DTCREDITO = :MOVDEBCE-DTCREDITO:VIND-DTCREDITO, VLR_CREDITO = :MOVDEBCE-VLR-CREDITO:VIND-VLRCREDITO WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS END-EXEC. */

            var r9000_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 = new R9000_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1()
            {
                MOVDEBCE_DATA_RETORNO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.ToString(),
                VIND_DTRETORNO = VIND_DTRETORNO.ToString(),
                MOVDEBCE_COD_RETORNO_CEF = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.ToString(),
                VIND_CODRET = VIND_CODRET.ToString(),
                MOVDEBCE_VLR_CREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO.ToString(),
                VIND_VLRCREDITO = VIND_VLRCREDITO.ToString(),
                MOVDEBCE_COD_USUARIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.ToString(),
                VIND_USUARIO = VIND_USUARIO.ToString(),
                MOVDEBCE_DTCREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.ToString(),
                VIND_DTCREDITO = VIND_DTCREDITO.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            R9000_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1.Execute(r9000_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2714- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, AUX_RELATORIO.WABEND.WSQLCODE);

            /*" -2715- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], AUX_RELATORIO.WABEND.WSQLERRD1);

            /*" -2716- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], AUX_RELATORIO.WABEND.WSQLERRD2);

            /*" -2717- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, AUX_RELATORIO.WABEND.WSQLERRO.WSQLERRMC);

            /*" -2719- DISPLAY WABEND. */
            _.Display(AUX_RELATORIO.WABEND);

            /*" -2721- DISPLAY LD99-ABEND. */
            _.Display(LD99_ABEND);

            /*" -2721- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2725- CLOSE BI6253B1. */
            BI6253B1.Close();

            /*" -2728- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2728- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}