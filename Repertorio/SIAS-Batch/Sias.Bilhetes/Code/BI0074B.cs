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
using Sias.Bilhetes.DB2.BI0074B;

namespace Code
{
    public class BI0074B
    {
        public bool IsCall { get; set; }

        public BI0074B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  BI0074B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  05/07/2008                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CONVENIO DE ARRECADACAO - SICAP    *      */
        /*"      *                             CAIXA SEGURADORA - 1028370056      *      */
        /*"      *                                                                *      */
        /*"      *              8114 - AP VIDA TRANQUILA PREMIADO EDUCACIONAL     *      */
        /*"      *              8115 - AP VIDA TRANQUILA PREMIADO SAF             *      */
        /*"      *              8116 - AP VIDA TRANQUILA PREMIADO CHECK LAR       *      */
        /*"      *              8117 - AP VIDA TRANQUILA PREMIADO HELP DESK       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  GILSON PINTO DA SILVA - 24/01/2024 *      */
        /*"      *   VERSAO 14               - INCLUIR A COLUNA STA_DEPOSITO_TER  *      */
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
        /*"      *                           - PROCURAR POR V.14                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - CAD 201.012                                      *      */
        /*"      *               - CORRECAO DO PROCESSO DE EMISSAO DE SEGUROS.    *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/02/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD 52.124                                       *      */
        /*"      *               - REVISAO DA OPERACAO.                           *      */
        /*"      *               - AJUSTE NA RECUPERACAO DA MOVIMENTO COBRANCA    *      */
        /*"      *                 PARA CONTORNAR O PROBLEMA DO FLUXO DE COBRANCA *      */
        /*"      *                 (150) CHEGAR ANTES DO DE PROPOSTA(300).        *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/01/2011 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  EDIVALDO GOMES (FAST COMPUTER)     *      */
        /*"      *                             CAD-49.559      28/10/2010 V.10    *      */
        /*"      *                             AJUSTE PARA NAO GRAVAR RCAP E      *      */
        /*"      *                             RCAP COMPLEMENTAR.                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  TERCIO FREITAS (FAST COMPUTER)     *      */
        /*"      *                             CAD-49.161      20/10/2010 V.09    *      */
        /*"      *                             AJUSTE NA DATA DE CREDITO          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  MARCO PAIVA (FAST COMPUTER)        *      */
        /*"      *                             CAD-45.765      18/08/2010 V.08    *      */
        /*"      *                             PROCESSA A PARCELA DE ADESAO DO    *      */
        /*"      *                             SICAP                              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  MARCO PAIVA (FAST COMPUTER)        *      */
        /*"      *                             CAD-37.277      15/03/2010 V.05    *      */
        /*"      *                             RECALCULAR PERCENTUAL DE CORRETAGEM*      */
        /*"      *                             PARA INCLUSAO DA COMISSAO DO ATEN -*      */
        /*"      *                             DENTE.                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  EDSON MARQUES   24/12/2009 V.04    *      */
        /*"      *                             CADMUS 34687.                      *      */
        /*"      *                             INCLUSA DE DISPLAY PARA A CONDICAO *      */
        /*"      *                             EM CASO DE ABEND DO PARAGRAFO      *      */
        /*"      *                             R1210-00-SELECT-ENDOSSOS.          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  FAST   22/06/2009           V.03   *      */
        /*"      *                             CADMUS 25495.                      *      */
        /*"      *                             EMITE BILHETES A PARTIR DA TABELA  *      */
        /*"      *                             SEGUROS.RCAPS CADASTRADOS NO SIAS  *      */
        /*"      *                             ONLINE.                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  CLOVIS 13/11/2008           V.02   *      */
        /*"      *                             CADMUS 17209.                      *      */
        /*"      *                             TRATA DUPLICIDADE DE AVISOS.       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  CLOVIS 06/11/2008           V.01   *      */
        /*"      *                             CADMUS 17026.                      *      */
        /*"      *                             PROPOSTAS COM NOSSO NUMERO         *      */
        /*"      *                             EM DUPLICIDADE. PROBLEMAS NO       *      */
        /*"      *                             INSERT RCAP. 95353385782.          *      */
        /*"      *                             SQLCODE = -803.                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _BI0074B1 { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis BI0074B1
        {
            get
            {
                _.Move(REG_BI0074B, _BI0074B1); VarBasis.RedefinePassValue(REG_BI0074B, _BI0074B1, REG_BI0074B); return _BI0074B1;
            }
        }
        public SortBasis<BI0074B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<BI0074B_REG_ARQSORT>(new BI0074B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public BI0074B_REG_ARQSORT REG_ARQSORT { get; set; } = new BI0074B_REG_ARQSORT();
        public class BI0074B_REG_ARQSORT : VarBasis
        {
            /*"  05      SOR-COD-EMPRESA           PIC 9(009).*/
            public IntBasis SOR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SOR-COD-MOVIMENTO         PIC 9(004).*/
            public IntBasis SOR_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-COD-FONTE             PIC 9(004).*/
            public IntBasis SOR_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-RAMO                  PIC 9(004).*/
            public IntBasis SOR_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-COD-PRODUTO           PIC 9(004).*/
            public IntBasis SOR_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-AGE-COBRANCA          PIC 9(004).*/
            public IntBasis SOR_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
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
            /*"  05      SOR-DATA-INIVIGENCIA      PIC X(010).*/
            public StringBasis SOR_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SOR-DATA-TERVIGENCIA      PIC X(010).*/
            public StringBasis SOR_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SOR-NUM-TITULO            PIC 9(013).*/
            public IntBasis SOR_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05      SOR-NUM-APOLICE           PIC 9(013).*/
            public IntBasis SOR_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05      SOR-NUM-ENDOSSO           PIC 9(009).*/
            public IntBasis SOR_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SOR-NUM-PARCELA           PIC 9(004).*/
            public IntBasis SOR_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-COD-CLIENTE           PIC 9(009).*/
            public IntBasis SOR_COD_CLIENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SOR-OCORR-ENDERECO        PIC 9(004).*/
            public IntBasis SOR_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-OPC-COBERTURA         PIC 9(004).*/
            public IntBasis SOR_OPC_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-VAL-TITULO            PIC 9(013)V99.*/
            public DoubleBasis SOR_VAL_TITULO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SOR-VAL-CREDITO           PIC 9(013)V99.*/
            public DoubleBasis SOR_VAL_CREDITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SOR-NUM-NOSSO-TITULO      PIC 9(016).*/
            public IntBasis SOR_NUM_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      SOR-SIT-REGISTRO          PIC X(001).*/
            public StringBasis SOR_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SOR-NOME-SEGURADO         PIC X(040).*/
            public StringBasis SOR_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05      SOR-TEM-PROPOSTA          PIC X(001).*/
            public StringBasis SOR_TEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SOR-NUM-CONTA             PIC 9(012).*/
            public IntBasis SOR_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"  05      SOR-NUM-OPE-CTA           PIC 9(004).*/
            public IntBasis SOR_NUM_OPE_CTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01        REG-BI0074B                 PIC  X(200).*/
        }
        public StringBasis REG_BI0074B { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    WSHOST-NUMSIV01           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NUMSIV01 { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WSHOST-NUMSIV02           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NUMSIV02 { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WSHOST-COUNT              PIC S9(004)     COMP.*/
        public IntBasis WSHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77    WSHOST-DATA-INIVIGENCIA   PIC  X(010).*/
        public StringBasis WSHOST_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSHOST-DATA-TERVIGENCIA   PIC  X(010).*/
        public StringBasis WSHOST_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSHOST-SALDO-ATUAL        PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_SALDO_ATUAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-NUM-TITULO         PIC S9(013)     COMP-3.*/
        public IntBasis WSHOST_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    WSHOST-NUM-NOSSO-TITULO   PIC S9(016)     COMP-3.*/
        public IntBasis WSHOST_NUM_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(016)"));
        /*"77    WSHOST-COD-ATENDENTE      PIC S9(9) COMP.*/
        public IntBasis WSHOST_COD_ATENDENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77    HOST-COUNT                PIC S9(004)    COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W.*/
        public BI0074B_W W { get; set; } = new BI0074B_W();
        public class BI0074B_W : VarBasis
        {
            /*"  03    WS-NRTIT             PIC  9(014)    VALUE  ZEROS.*/
            public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03    FILLER               REDEFINES      WS-NRTIT.*/
            private _REDEF_BI0074B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI0074B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI0074B_FILLER_0(); _.Move(WS_NRTIT, _filler_0); VarBasis.RedefinePassValue(WS_NRTIT, _filler_0, WS_NRTIT); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_NRTIT); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_NRTIT); }
            }  //Redefines
            public class _REDEF_BI0074B_FILLER_0 : VarBasis
            {
                /*"        10 WS-NUMTIT         PIC  9(013).*/
                public IntBasis WS_NUMTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        10 WS-DIGTIT-13      PIC  9(001).*/
                public IntBasis WS_DIGTIT_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03     WWORK-MIN-NRTIT   PIC  9(011)    VALUE  ZEROS.*/

                public _REDEF_BI0074B_FILLER_0()
                {
                    WS_NUMTIT.ValueChanged += OnValueChanged;
                    WS_DIGTIT_13.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_MIN_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03     FILLER            REDEFINES      WWORK-MIN-NRTIT.*/
            private _REDEF_BI0074B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI0074B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI0074B_FILLER_1(); _.Move(WWORK_MIN_NRTIT, _filler_1); VarBasis.RedefinePassValue(WWORK_MIN_NRTIT, _filler_1, WWORK_MIN_NRTIT); _filler_1.ValueChanged += () => { _.Move(_filler_1, WWORK_MIN_NRTIT); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WWORK_MIN_NRTIT); }
            }  //Redefines
            public class _REDEF_BI0074B_FILLER_1 : VarBasis
            {
                /*"        10   WWORK-MINNRO      PIC  9(010).*/
                public IntBasis WWORK_MINNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"        10   WWORK-MINDIG      PIC  9(001).*/
                public IntBasis WWORK_MINDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03     WWORK-MAX-NRTIT   PIC  9(011)    VALUE  ZEROS.*/

                public _REDEF_BI0074B_FILLER_1()
                {
                    WWORK_MINNRO.ValueChanged += OnValueChanged;
                    WWORK_MINDIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_MAX_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03     FILLER            REDEFINES      WWORK-MAX-NRTIT.*/
            private _REDEF_BI0074B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_BI0074B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_BI0074B_FILLER_2(); _.Move(WWORK_MAX_NRTIT, _filler_2); VarBasis.RedefinePassValue(WWORK_MAX_NRTIT, _filler_2, WWORK_MAX_NRTIT); _filler_2.ValueChanged += () => { _.Move(_filler_2, WWORK_MAX_NRTIT); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WWORK_MAX_NRTIT); }
            }  //Redefines
            public class _REDEF_BI0074B_FILLER_2 : VarBasis
            {
                /*"        10   WWORK-MAXNRO      PIC  9(010).*/
                public IntBasis WWORK_MAXNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"        10   WWORK-MAXDIG      PIC  9(001).*/
                public IntBasis WWORK_MAXDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/

                public _REDEF_BI0074B_FILLER_2()
                {
                    WWORK_MAXNRO.ValueChanged += OnValueChanged;
                    WWORK_MAXDIG.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-SORT                 PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-COBERTURA            PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-RCAP                 PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WS-ALTERA                 PIC  X(001)         VALUE SPACES*/
            public StringBasis WS_ALTERA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-MOVIMCOB               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_MOVIMCOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-SORT                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  NT-BILHETE                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis NT_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  NT-BILHECOB               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis NT_BILHECOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-PROPOSTA               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis UP_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TE-RCAP                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis TE_RCAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TE-FOLLOWUP               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis TE_FOLLOWUP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-FOLLOWUP               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_FOLLOWUP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-CONTROLE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-EMITE                  PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_EMITE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-DUPLICA                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_DUPLICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SORT                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SAIDA                  PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_SAIDA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AUX-VALOR                 PIC S9(013)V99      COMP-3.*/
            public DoubleBasis AUX_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  AUX-VALBAS                PIC S9(013)V99      COMP-3.*/
            public DoubleBasis AUX_VALBAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  AUX-PERCENT               PIC S9(003)V9999    COMP-3.*/
            public DoubleBasis AUX_PERCENT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999"), 4);
            /*"  03  AUX-VLCOMIS               PIC S9(013)V99      COMP-3.*/
            public DoubleBasis AUX_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WTEM-AVISO                PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_AVISO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-PROPOSTA               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
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
            /*"  03         WS-CHAVE-ATU.*/
            public BI0074B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new BI0074B_WS_CHAVE_ATU();
            public class BI0074B_WS_CHAVE_ATU : VarBasis
            {
                /*"    05       ATU-COD-BANCO       PIC  9(004).*/
                public IntBasis ATU_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ATU-COD-AGENCIA     PIC  9(004).*/
                public IntBasis ATU_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ATU-NUM-AVISO       PIC  9(009).*/
                public IntBasis ATU_NUM_AVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"  03         WS-CHAVE-ANT.*/
            }
            public BI0074B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new BI0074B_WS_CHAVE_ANT();
            public class BI0074B_WS_CHAVE_ANT : VarBasis
            {
                /*"    05       ANT-COD-BANCO       PIC  9(004).*/
                public IntBasis ANT_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ANT-COD-AGENCIA     PIC  9(004).*/
                public IntBasis ANT_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       ANT-NUM-AVISO       PIC  9(009).*/
                public IntBasis ANT_NUM_AVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"  03         AUX-NRAVISO       PIC  9(009)    VALUE ZEROS.*/
            }
            public IntBasis AUX_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER            REDEFINES      AUX-NRAVISO.*/
            private _REDEF_BI0074B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_BI0074B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_BI0074B_FILLER_3(); _.Move(AUX_NRAVISO, _filler_3); VarBasis.RedefinePassValue(AUX_NRAVISO, _filler_3, AUX_NRAVISO); _filler_3.ValueChanged += () => { _.Move(_filler_3, AUX_NRAVISO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, AUX_NRAVISO); }
            }  //Redefines
            public class _REDEF_BI0074B_FILLER_3 : VarBasis
            {
                /*"    10       AUX-PRENRO        PIC  9(001).*/
                public IntBasis AUX_PRENRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       AUX-AVISO         PIC  9(008).*/
                public IntBasis AUX_AVISO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03         WS-TITULO         PIC  9(011)    VALUE ZEROS.*/

                public _REDEF_BI0074B_FILLER_3()
                {
                    AUX_PRENRO.ValueChanged += OnValueChanged;
                    AUX_AVISO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_TITULO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER            REDEFINES      WS-TITULO.*/
            private _REDEF_BI0074B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_BI0074B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_BI0074B_FILLER_4(); _.Move(WS_TITULO, _filler_4); VarBasis.RedefinePassValue(WS_TITULO, _filler_4, WS_TITULO); _filler_4.ValueChanged += () => { _.Move(_filler_4, WS_TITULO); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WS_TITULO); }
            }  //Redefines
            public class _REDEF_BI0074B_FILLER_4 : VarBasis
            {
                /*"    10       WS-PRETIT         PIC  9(001).*/
                public IntBasis WS_PRETIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WS-NRRCAP         PIC  9(009).*/
                public IntBasis WS_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       WS-DIGTIT         PIC  9(001).*/
                public IntBasis WS_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WS-TITULO-14      PIC  9(014)    VALUE ZEROS.*/

                public _REDEF_BI0074B_FILLER_4()
                {
                    WS_PRETIT.ValueChanged += OnValueChanged;
                    WS_NRRCAP.ValueChanged += OnValueChanged;
                    WS_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_TITULO_14 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI0074B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_BI0074B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_BI0074B_FILLER_5(); _.Move(WDATA_REL, _filler_5); VarBasis.RedefinePassValue(WDATA_REL, _filler_5, WDATA_REL); _filler_5.ValueChanged += () => { _.Move(_filler_5, WDATA_REL); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI0074B_FILLER_5 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-CABEC.*/

                public _REDEF_BI0074B_FILLER_5()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public BI0074B_WDATA_CABEC WDATA_CABEC { get; set; } = new BI0074B_WDATA_CABEC();
            public class BI0074B_WDATA_CABEC : VarBasis
            {
                /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WHORA-CABEC.*/
            }
            public BI0074B_WHORA_CABEC WHORA_CABEC { get; set; } = new BI0074B_WHORA_CABEC();
            public class BI0074B_WHORA_CABEC : VarBasis
            {
                /*"    05       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE ':'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE ':'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_BI0074B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_BI0074B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_BI0074B_FILLER_12(); _.Move(WTIME_DAY, _filler_12); VarBasis.RedefinePassValue(WTIME_DAY, _filler_12, WTIME_DAY); _filler_12.ValueChanged += () => { _.Move(_filler_12, WTIME_DAY); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_BI0074B_FILLER_12 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public BI0074B_WTIME_DAYR WTIME_DAYR { get; set; } = new BI0074B_WTIME_DAYR();
                public class BI0074B_WTIME_DAYR : VarBasis
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

                    public BI0074B_WTIME_DAYR()
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

                public _REDEF_BI0074B_FILLER_12()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public BI0074B_WS_TIME WS_TIME { get; set; } = new BI0074B_WS_TIME();
            public class BI0074B_WS_TIME : VarBasis
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
        public BI0074B_AUX_RELATORIO AUX_RELATORIO { get; set; } = new BI0074B_AUX_RELATORIO();
        public class BI0074B_AUX_RELATORIO : VarBasis
        {
            /*"  03          LC00.*/
            public BI0074B_LC00 LC00 { get; set; } = new BI0074B_LC00();
            public class BI0074B_LC00 : VarBasis
            {
                /*"    10        FILLER              PIC  X(008)  VALUE             'CONVENIO'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CONVENIO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(016)  VALUE             'PROPOSTA'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"PROPOSTA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(011)  VALUE             'BILHETE'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"BILHETE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'PAGAMENTO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PAGAMENTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'CREDITO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CREDITO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'NSA RET.'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"NSA RET.");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             '         VALOR'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"         VALOR");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PRODUTO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(013)  VALUE             'APOLICE'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'ENDOSSO'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"ENDOSSO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PARCELA'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PARCELA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(040)  VALUE             'MENSAGEM'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"MENSAGEM");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"  03          LD01.*/
            }
            public BI0074B_LD01 LD01 { get; set; } = new BI0074B_LD01();
            public class BI0074B_LD01 : VarBasis
            {
                /*"    10        LD01-CONVENIO       PIC  ZZZZZZZZZ9.*/
                public IntBasis LD01_CONVENIO { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZZZZ9."));
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
                /*"    10        LD01-MENSAGEM       PIC  X(040).*/
                public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10        FILLER              PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"  03        WABEND.*/
            }
            public BI0074B_WABEND WABEND { get; set; } = new BI0074B_WABEND();
            public class BI0074B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' BI0074B  '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0074B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LD99-ABEND.*/
            }
        }
        public BI0074B_LD99_ABEND LD99_ABEND { get; set; } = new BI0074B_LD99_ABEND();
        public class BI0074B_LD99_ABEND : VarBasis
        {
            /*"      10    FILLER              PIC  X(050) VALUE           ' REINICIAR JOB NO PROXIMO STEP               '.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" REINICIAR JOB NO PROXIMO STEP               ");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.FOLLOUP FOLLOUP { get; set; } = new Dclgens.FOLLOUP();
        public Dclgens.BILHECOB BILHECOB { get; set; } = new Dclgens.BILHECOB();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.APOLICOR APOLICOR { get; set; } = new Dclgens.APOLICOR();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.AVISOCRE AVISOCRE { get; set; } = new Dclgens.AVISOCRE();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
        public Dclgens.CONDESCE CONDESCE { get; set; } = new Dclgens.CONDESCE();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public BI0074B_V0MOVIMCOB V0MOVIMCOB { get; set; } = new BI0074B_V0MOVIMCOB();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P, string BI0074B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);
                BI0074B1.SetFile(BI0074B1_FILE_NAME_P);

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
            /*" -463- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -464- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -466- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -468- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -472- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -473- DISPLAY 'PROGRAMA EM EXECUCAO BI0074B  ' . */
            _.Display($"PROGRAMA EM EXECUCAO BI0074B  ");

            /*" -474- DISPLAY '                              ' . */
            _.Display($"                              ");

            /*" -479- DISPLAY 'VERSAO V.13 NSGD    03/10/2014' . */
            _.Display($"VERSAO V.13 NSGD    03/10/2014");

            /*" -480- DISPLAY '                              ' . */
            _.Display($"                              ");

            /*" -482- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -485- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -496- SORT ARQSORT ON ASCENDING KEY SOR-COD-BANCO SOR-COD-AGENCIA SOR-NUM-AVISO SOR-COD-PRODUTO INPUT PROCEDURE R0200-00-INPUT-SORT THRU R0200-99-SAIDA OUTPUT PROCEDURE R0450-00-OUTPUT-SORT THRU R0450-99-SAIDA. */
            ARQSORT.Sort("SOR-COD-BANCO,SOR-COD-AGENCIA,SOR-NUM-AVISO,SOR-COD-PRODUTO", () => R0200_00_INPUT_SORT_SECTION(), () => R0450_00_OUTPUT_SORT_SECTION());

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -501- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -505- CLOSE BI0074B1. */
            BI0074B1.Close();

            /*" -507- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -508- DISPLAY ' ' */
            _.Display($" ");

            /*" -509- DISPLAY 'BI0074B - FIM NORMAL' . */
            _.Display($"BI0074B - FIM NORMAL");

            /*" -512- DISPLAY ' ' . */
            _.Display($" ");

            /*" -512- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -526- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -529- OPEN OUTPUT BI0074B1. */
            BI0074B1.Open(REG_BI0074B);

            /*" -532- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -534- DISPLAY ' DATA DO PROCESSAMENTO ...............  ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($" DATA DO PROCESSAMENTO ...............  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -535- DISPLAY ' ' . */
            _.Display($" ");

            /*" -535- DISPLAY ' CONVENIO 1028370056(CIELO)        - MOVIMCOB  ' . */
            _.Display($" CONVENIO 1028370056(CIELO)        - MOVIMCOB  ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -548- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -554- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -557- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -558- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -561- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -562- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -554- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

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
            /*" -576- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -577- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -579- PERFORM R0300-00-DECLARE-MOVIMCOB. */

            R0300_00_DECLARE_MOVIMCOB_SECTION();

            /*" -581- PERFORM R0310-00-FETCH-MOVIMCOB. */

            R0310_00_FETCH_MOVIMCOB_SECTION();

            /*" -585- PERFORM R0350-00-PROCESSA-MOVIMCOB UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_MOVIMCOB_SECTION();
            }

            /*" -586- DISPLAY ' ' . */
            _.Display($" ");

            /*" -587- DISPLAY 'LIDOS MOVIMCOB ............. ' LD-MOVIMCOB. */
            _.Display($"LIDOS MOVIMCOB ............. {W.LD_MOVIMCOB}");

            /*" -588- DISPLAY 'SEM   PROPOSTA ............. ' NT-BILHETE. */
            _.Display($"SEM   PROPOSTA ............. {W.NT_BILHETE}");

            /*" -589- DISPLAY 'ALTERA PROPOSTA ............ ' UP-PROPOSTA. */
            _.Display($"ALTERA PROPOSTA ............ {W.UP_PROPOSTA}");

            /*" -590- DISPLAY 'GRAVADOS SORT .............. ' GV-SORT. */
            _.Display($"GRAVADOS SORT .............. {W.GV_SORT}");

            /*" -590- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-SECTION */
        private void R0300_00_DECLARE_MOVIMCOB_SECTION()
        {
            /*" -607- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -631- PERFORM R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1 */

            R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1();

            /*" -633- PERFORM R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1 */

            R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1();

            /*" -637- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -638- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (MOVIMCOB)   ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (MOVIMCOB)   ");

                /*" -638- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-DB-DECLARE-1 */
        public void R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1()
        {
            /*" -631- EXEC SQL DECLARE V0MOVIMCOB CURSOR FOR SELECT COD_EMPRESA , COD_MOVIMENTO , COD_BANCO , COD_AGENCIA , NUM_AVISO , NUM_FITA , DATA_MOVIMENTO , DATA_QUITACAO , (DATA_QUITACAO + 001 DAYS) , (DATA_QUITACAO + 366 DAYS) , NUM_TITULO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , VAL_TITULO , VAL_CREDITO , SIT_REGISTRO , NOME_SEGURADO , NUM_NOSSO_TITULO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE SIT_REGISTRO IN ( ' ' , '2' ) AND TIPO_MOVIMENTO = 'T' AND DATA_MOVIMENTO <= :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */
            V0MOVIMCOB = new BI0074B_V0MOVIMCOB(true);
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
							(DATA_QUITACAO + 001 DAYS)
							, 
							(DATA_QUITACAO + 366 DAYS)
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
							FROM SEGUROS.MOVIMENTO_COBRANCA 
							WHERE SIT_REGISTRO IN ( ' '
							, '2' ) 
							AND TIPO_MOVIMENTO = 'T' 
							AND DATA_MOVIMENTO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}'";

                return query;
            }
            V0MOVIMCOB.GetQueryEvent += GetQuery_V0MOVIMCOB;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-DB-OPEN-1 */
        public void R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1()
        {
            /*" -633- EXEC SQL OPEN V0MOVIMCOB END-EXEC. */

            V0MOVIMCOB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-SECTION */
        private void R0310_00_FETCH_MOVIMCOB_SECTION()
        {
            /*" -652- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -672- PERFORM R0310_00_FETCH_MOVIMCOB_DB_FETCH_1 */

            R0310_00_FETCH_MOVIMCOB_DB_FETCH_1();

            /*" -676- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -676- PERFORM R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1 */

                R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1();

                /*" -678- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -680- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -681- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -682- DISPLAY 'R0310-00 - PROBLEMAS FETCH   (MOVIMCOB)   ' */
                _.Display($"R0310-00 - PROBLEMAS FETCH   (MOVIMCOB)   ");

                /*" -684- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -684- ADD 1 TO LD-MOVIMCOB. */
            W.LD_MOVIMCOB.Value = W.LD_MOVIMCOB + 1;

        }

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-DB-FETCH-1 */
        public void R0310_00_FETCH_MOVIMCOB_DB_FETCH_1()
        {
            /*" -672- EXEC SQL FETCH V0MOVIMCOB INTO :MOVIMCOB-COD-EMPRESA , :MOVIMCOB-COD-MOVIMENTO , :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-NUM-FITA , :MOVIMCOB-DATA-MOVIMENTO , :MOVIMCOB-DATA-QUITACAO , :WSHOST-DATA-INIVIGENCIA , :WSHOST-DATA-TERVIGENCIA , :MOVIMCOB-NUM-TITULO , :MOVIMCOB-NUM-APOLICE , :MOVIMCOB-NUM-ENDOSSO , :MOVIMCOB-NUM-PARCELA , :MOVIMCOB-VAL-TITULO , :MOVIMCOB-VAL-CREDITO , :MOVIMCOB-SIT-REGISTRO , :MOVIMCOB-NOME-SEGURADO , :MOVIMCOB-NUM-NOSSO-TITULO END-EXEC. */

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
                _.Move(V0MOVIMCOB.WSHOST_DATA_INIVIGENCIA, WSHOST_DATA_INIVIGENCIA);
                _.Move(V0MOVIMCOB.WSHOST_DATA_TERVIGENCIA, WSHOST_DATA_TERVIGENCIA);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);
                _.Move(V0MOVIMCOB.MOVIMCOB_VAL_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);
                _.Move(V0MOVIMCOB.MOVIMCOB_VAL_CREDITO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);
                _.Move(V0MOVIMCOB.MOVIMCOB_SIT_REGISTRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NOME_SEGURADO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_NOSSO_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-DB-CLOSE-1 */
        public void R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1()
        {
            /*" -676- EXEC SQL CLOSE V0MOVIMCOB END-EXEC */

            V0MOVIMCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-MOVIMCOB-SECTION */
        private void R0350_00_PROCESSA_MOVIMCOB_SECTION()
        {
            /*" -698- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -700- PERFORM R0360-00-SELECT-MOVCOB */

            R0360_00_SELECT_MOVCOB_SECTION();

            /*" -701- IF HOST-COUNT GREATER ZEROS */

            if (HOST_COUNT > 00)
            {

                /*" -702- GO TO R0350-90-LEITURA */

                R0350_90_LEITURA(); //GOTO
                return;

                /*" -704- END-IF. */
            }


            /*" -706- MOVE SPACES TO WS-ALTERA. */
            _.Move("", W.WS_ALTERA);

            /*" -708- PERFORM R0351-00-SELECT-PROPOFID */

            R0351_00_SELECT_PROPOFID_SECTION();

            /*" -710- MOVE MOVIMCOB-COD-EMPRESA TO SOR-COD-EMPRESA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA, REG_ARQSORT.SOR_COD_EMPRESA);

            /*" -712- MOVE MOVIMCOB-COD-MOVIMENTO TO SOR-COD-MOVIMENTO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO, REG_ARQSORT.SOR_COD_MOVIMENTO);

            /*" -714- MOVE MALHACEF-COD-FONTE TO SOR-COD-FONTE. */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, REG_ARQSORT.SOR_COD_FONTE);

            /*" -716- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO WS-TITULO-14 */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, W.WS_TITULO_14);

            /*" -718- MOVE WS-TITULO-14(2:4) TO SOR-COD-PRODUTO. */
            _.Move(W.WS_TITULO_14.Substring(2, 4), REG_ARQSORT.SOR_COD_PRODUTO);

            /*" -720- MOVE PROPOFID-AGECOBR TO SOR-AGE-COBRANCA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR, REG_ARQSORT.SOR_AGE_COBRANCA);

            /*" -722- MOVE MOVIMCOB-COD-BANCO TO SOR-COD-BANCO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO, REG_ARQSORT.SOR_COD_BANCO);

            /*" -724- MOVE MOVIMCOB-COD-AGENCIA TO SOR-COD-AGENCIA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA, REG_ARQSORT.SOR_COD_AGENCIA);

            /*" -726- MOVE MOVIMCOB-NUM-AVISO TO SOR-NUM-AVISO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, REG_ARQSORT.SOR_NUM_AVISO);

            /*" -728- MOVE MOVIMCOB-NUM-FITA TO SOR-NUM-FITA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA, REG_ARQSORT.SOR_NUM_FITA);

            /*" -732- MOVE MOVIMCOB-DATA-MOVIMENTO TO SOR-DATA-MOVIMENTO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO, REG_ARQSORT.SOR_DATA_MOVIMENTO);

            /*" -734- MOVE PROPOFID-DATA-PROPOSTA TO SOR-DATA-QUITACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, REG_ARQSORT.SOR_DATA_QUITACAO);

            /*" -736- MOVE WSHOST-DATA-INIVIGENCIA TO SOR-DATA-INIVIGENCIA. */
            _.Move(WSHOST_DATA_INIVIGENCIA, REG_ARQSORT.SOR_DATA_INIVIGENCIA);

            /*" -738- MOVE WSHOST-DATA-TERVIGENCIA TO SOR-DATA-TERVIGENCIA. */
            _.Move(WSHOST_DATA_TERVIGENCIA, REG_ARQSORT.SOR_DATA_TERVIGENCIA);

            /*" -741- MOVE MOVIMCOB-NUM-TITULO TO SOR-NUM-TITULO WSHOST-NUM-TITULO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, REG_ARQSORT.SOR_NUM_TITULO, WSHOST_NUM_TITULO);

            /*" -743- MOVE MOVIMCOB-NUM-APOLICE TO SOR-NUM-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, REG_ARQSORT.SOR_NUM_APOLICE);

            /*" -745- MOVE MOVIMCOB-NUM-ENDOSSO TO SOR-NUM-ENDOSSO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, REG_ARQSORT.SOR_NUM_ENDOSSO);

            /*" -747- MOVE MOVIMCOB-NUM-PARCELA TO SOR-NUM-PARCELA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, REG_ARQSORT.SOR_NUM_PARCELA);

            /*" -749- MOVE ZEROS TO SOR-COD-CLIENTE. */
            _.Move(0, REG_ARQSORT.SOR_COD_CLIENTE);

            /*" -751- MOVE ZEROS TO SOR-OCORR-ENDERECO. */
            _.Move(0, REG_ARQSORT.SOR_OCORR_ENDERECO);

            /*" -753- MOVE MOVIMCOB-VAL-TITULO TO SOR-VAL-TITULO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, REG_ARQSORT.SOR_VAL_TITULO);

            /*" -755- MOVE MOVIMCOB-VAL-CREDITO TO SOR-VAL-CREDITO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO, REG_ARQSORT.SOR_VAL_CREDITO);

            /*" -758- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO SOR-NUM-NOSSO-TITULO WSHOST-NUM-NOSSO-TITULO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, REG_ARQSORT.SOR_NUM_NOSSO_TITULO, WSHOST_NUM_NOSSO_TITULO);

            /*" -760- MOVE MOVIMCOB-SIT-REGISTRO TO SOR-SIT-REGISTRO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO, REG_ARQSORT.SOR_SIT_REGISTRO);

            /*" -762- MOVE MOVIMCOB-NOME-SEGURADO TO SOR-NOME-SEGURADO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO, REG_ARQSORT.SOR_NOME_SEGURADO);

            /*" -765- MOVE 'S' TO SOR-TEM-PROPOSTA. */
            _.Move("S", REG_ARQSORT.SOR_TEM_PROPOSTA);

            /*" -766- IF WS-ALTERA EQUAL 'S' */

            if (W.WS_ALTERA == "S")
            {

                /*" -769- PERFORM R0400-00-UPDATE-V0MOVICOB. */

                R0400_00_UPDATE_V0MOVICOB_SECTION();
            }


            /*" -770- RELEASE REG-ARQSORT. */
            ARQSORT.Release(REG_ARQSORT);

            /*" -770- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -775- PERFORM R0310-00-FETCH-MOVIMCOB. */

            R0310_00_FETCH_MOVIMCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0351-00-SELECT-PROPOFID-SECTION */
        private void R0351_00_SELECT_PROPOFID_SECTION()
        {
            /*" -787- MOVE '0351' TO WNR-EXEC-SQL. */
            _.Move("0351", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -806- PERFORM R0351_00_SELECT_PROPOFID_DB_SELECT_1 */

            R0351_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -809- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -810- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -811- MOVE ZEROS TO MALHACEF-COD-FONTE */
                    _.Move(0, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);

                    /*" -812- ELSE */
                }
                else
                {


                    /*" -813- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -814- END-IF */
                }


                /*" -814- END-IF. */
            }


        }

        [StopWatch]
        /*" R0351-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R0351_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -806- EXEC SQL SELECT A.AGECOBR, A.DATA_PROPOSTA, C.COD_FONTE INTO :PROPOFID-AGECOBR , :PROPOFID-DATA-PROPOSTA, :MALHACEF-COD-FONTE FROM SEGUROS.PROPOSTA_FIDELIZ A, SEGUROS.AGENCIAS_CEF B, SEGUROS.MALHA_CEF C WHERE A.NUM_PROPOSTA_SIVPF = :MOVIMCOB-NUM-NOSSO-TITULO AND B.COD_AGENCIA = A.AGECOBR AND C.COD_SUREG = B.COD_SUREG WITH UR END-EXEC. */

            var r0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
            };

            var executed_1 = R0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);
                _.Move(executed_1.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(executed_1.MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0351_99_SAIDA*/

        [StopWatch]
        /*" R0360-00-SELECT-MOVCOB-SECTION */
        private void R0360_00_SELECT_MOVCOB_SECTION()
        {
            /*" -824- MOVE ZEROS TO WS-NRTIT. */
            _.Move(0, W.WS_NRTIT);

            /*" -828- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO WS-NRTIT. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, W.WS_NRTIT);

            /*" -829- MOVE ZEROS TO WS-DIGTIT-13. */
            _.Move(0, W.FILLER_0.WS_DIGTIT_13);

            /*" -831- MOVE WS-NRTIT TO WSHOST-NUMSIV01. */
            _.Move(W.WS_NRTIT, WSHOST_NUMSIV01);

            /*" -832- MOVE 9 TO WS-DIGTIT-13. */
            _.Move(9, W.FILLER_0.WS_DIGTIT_13);

            /*" -834- MOVE WS-NRTIT TO WSHOST-NUMSIV02. */
            _.Move(W.WS_NRTIT, WSHOST_NUMSIV02);

            /*" -837- MOVE '0360' TO WNR-EXEC-SQL. */
            _.Move("0360", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -844- PERFORM R0360_00_SELECT_MOVCOB_DB_SELECT_1 */

            R0360_00_SELECT_MOVCOB_DB_SELECT_1();

        }

        [StopWatch]
        /*" R0360-00-SELECT-MOVCOB-DB-SELECT-1 */
        public void R0360_00_SELECT_MOVCOB_DB_SELECT_1()
        {
            /*" -844- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.MOVIMENTO_COBRANCA WHERE NUM_NOSSO_TITULO >= :WSHOST-NUMSIV01 AND NUM_NOSSO_TITULO <= :WSHOST-NUMSIV02 AND SIT_REGISTRO = '1' END-EXEC. */

            var r0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1 = new R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1()
            {
                WSHOST_NUMSIV01 = WSHOST_NUMSIV01.ToString(),
                WSHOST_NUMSIV02 = WSHOST_NUMSIV02.ToString(),
            };

            var executed_1 = R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1.Execute(r0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/

        [StopWatch]
        /*" R0370-00-SELECT-AVISOCRED-SECTION */
        private void R0370_00_SELECT_AVISOCRED_SECTION()
        {
            /*" -857- MOVE '0370' TO WNR-EXEC-SQL. */
            _.Move("0370", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -859- MOVE SOR-COD-BANCO TO AVISOCRE-BCO-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_BANCO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO);

            /*" -861- MOVE SOR-COD-AGENCIA TO AVISOCRE-AGE-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO);

            /*" -865- MOVE SOR-NUM-AVISO TO AVISOCRE-NUM-AVISO-CREDITO AUX-NRAVISO. */
            _.Move(REG_ARQSORT.SOR_NUM_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, W.AUX_NRAVISO);

            /*" -878- PERFORM R0370_00_SELECT_AVISOCRED_DB_SELECT_1 */

            R0370_00_SELECT_AVISOCRED_DB_SELECT_1();

            /*" -882- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -883- GO TO R0370-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/ //GOTO
                return;

                /*" -884- ELSE */
            }
            else
            {


                /*" -885- MOVE 'S' TO WS-ALTERA */
                _.Move("S", W.WS_ALTERA);

                /*" -887- MOVE 8 TO AUX-PRENRO. */
                _.Move(8, W.FILLER_3.AUX_PRENRO);
            }


            /*" -892- MOVE '0371' TO WNR-EXEC-SQL. */
            _.Move("0371", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -895- MOVE AUX-NRAVISO TO AVISOCRE-NUM-AVISO-CREDITO. */
            _.Move(W.AUX_NRAVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);

            /*" -908- PERFORM R0370_00_SELECT_AVISOCRED_DB_SELECT_2 */

            R0370_00_SELECT_AVISOCRED_DB_SELECT_2();

            /*" -912- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -915- MOVE AUX-NRAVISO TO MOVIMCOB-NUM-AVISO SOR-NUM-AVISO */
                _.Move(W.AUX_NRAVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, REG_ARQSORT.SOR_NUM_AVISO);

                /*" -916- GO TO R0370-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/ //GOTO
                return;

                /*" -917- ELSE */
            }
            else
            {


                /*" -919- MOVE 7 TO AUX-PRENRO. */
                _.Move(7, W.FILLER_3.AUX_PRENRO);
            }


            /*" -923- MOVE '0372' TO WNR-EXEC-SQL. */
            _.Move("0372", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -926- MOVE AUX-NRAVISO TO AVISOCRE-NUM-AVISO-CREDITO. */
            _.Move(W.AUX_NRAVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);

            /*" -939- PERFORM R0370_00_SELECT_AVISOCRED_DB_SELECT_3 */

            R0370_00_SELECT_AVISOCRED_DB_SELECT_3();

            /*" -943- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -946- MOVE AUX-NRAVISO TO MOVIMCOB-NUM-AVISO SOR-NUM-AVISO */
                _.Move(W.AUX_NRAVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, REG_ARQSORT.SOR_NUM_AVISO);

                /*" -947- GO TO R0370-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/ //GOTO
                return;

                /*" -948- ELSE */
            }
            else
            {


                /*" -950- MOVE 6 TO AUX-PRENRO. */
                _.Move(6, W.FILLER_3.AUX_PRENRO);
            }


            /*" -954- MOVE '0373' TO WNR-EXEC-SQL. */
            _.Move("0373", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -957- MOVE AUX-NRAVISO TO AVISOCRE-NUM-AVISO-CREDITO. */
            _.Move(W.AUX_NRAVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);

            /*" -970- PERFORM R0370_00_SELECT_AVISOCRED_DB_SELECT_4 */

            R0370_00_SELECT_AVISOCRED_DB_SELECT_4();

            /*" -974- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -975- DISPLAY 'R0370-00 - AVISO CREDITO JA CADASTRADO    ' */
                _.Display($"R0370-00 - AVISO CREDITO JA CADASTRADO    ");

                /*" -976- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -977- ELSE */
            }
            else
            {


                /*" -978- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -981- MOVE AUX-NRAVISO TO MOVIMCOB-NUM-AVISO SOR-NUM-AVISO */
                    _.Move(W.AUX_NRAVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, REG_ARQSORT.SOR_NUM_AVISO);

                    /*" -982- GO TO R0370-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/ //GOTO
                    return;

                    /*" -983- ELSE */
                }
                else
                {


                    /*" -984- DISPLAY 'R0370-00 - PROBLEMAS SELECT (AVISOCRE)   ' */
                    _.Display($"R0370-00 - PROBLEMAS SELECT (AVISOCRE)   ");

                    /*" -986- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0370-00-SELECT-AVISOCRED-DB-SELECT-1 */
        public void R0370_00_SELECT_AVISOCRED_DB_SELECT_1()
        {
            /*" -878- EXEC SQL SELECT NUM_AVISO_CREDITO INTO :AVISOCRE-NUM-AVISO-CREDITO FROM SEGUROS.AVISO_CREDITO WHERE BCO_AVISO = :AVISOCRE-BCO-AVISO AND AGE_AVISO = :AVISOCRE-AGE-AVISO AND NUM_AVISO_CREDITO = :AVISOCRE-NUM-AVISO-CREDITO WITH UR END-EXEC. */

            var r0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1 = new R0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1()
            {
                AVISOCRE_NUM_AVISO_CREDITO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.ToString(),
                AVISOCRE_BCO_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO.ToString(),
                AVISOCRE_AGE_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO.ToString(),
            };

            var executed_1 = R0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1.Execute(r0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_99_SAIDA*/

        [StopWatch]
        /*" R0370-00-SELECT-AVISOCRED-DB-SELECT-2 */
        public void R0370_00_SELECT_AVISOCRED_DB_SELECT_2()
        {
            /*" -908- EXEC SQL SELECT NUM_AVISO_CREDITO INTO :AVISOCRE-NUM-AVISO-CREDITO FROM SEGUROS.AVISO_CREDITO WHERE BCO_AVISO = :AVISOCRE-BCO-AVISO AND AGE_AVISO = :AVISOCRE-AGE-AVISO AND NUM_AVISO_CREDITO = :AVISOCRE-NUM-AVISO-CREDITO WITH UR END-EXEC. */

            var r0370_00_SELECT_AVISOCRED_DB_SELECT_2_Query1 = new R0370_00_SELECT_AVISOCRED_DB_SELECT_2_Query1()
            {
                AVISOCRE_NUM_AVISO_CREDITO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.ToString(),
                AVISOCRE_BCO_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO.ToString(),
                AVISOCRE_AGE_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO.ToString(),
            };

            var executed_1 = R0370_00_SELECT_AVISOCRED_DB_SELECT_2_Query1.Execute(r0370_00_SELECT_AVISOCRED_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
            }


        }

        [StopWatch]
        /*" R0400-00-UPDATE-V0MOVICOB-SECTION */
        private void R0400_00_UPDATE_V0MOVICOB_SECTION()
        {
            /*" -998- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1012- PERFORM R0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1 */

            R0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1();

            /*" -1015- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1016- DISPLAY 'R0400-00 - PROBLEMAS UPDATE (V0MOVICOB)   ' */
                _.Display($"R0400-00 - PROBLEMAS UPDATE (V0MOVICOB)   ");

                /*" -1019- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1019- ADD 1 TO UP-PROPOSTA. */
            W.UP_PROPOSTA.Value = W.UP_PROPOSTA + 1;

        }

        [StopWatch]
        /*" R0400-00-UPDATE-V0MOVICOB-DB-UPDATE-1 */
        public void R0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1()
        {
            /*" -1012- EXEC SQL UPDATE SEGUROS.MOVIMENTO_COBRANCA SET NUM_TITULO = :MOVIMCOB-NUM-TITULO , NUM_APOLICE = :MOVIMCOB-NUM-APOLICE , NUM_AVISO = :MOVIMCOB-NUM-AVISO WHERE NUM_NOSSO_TITULO = :WSHOST-NUM-NOSSO-TITULO AND TIPO_MOVIMENTO = 'T' AND DATA_MOVIMENTO <= :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */

            var r0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 = new R0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1()
            {
                MOVIMCOB_NUM_APOLICE = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE.ToString(),
                MOVIMCOB_NUM_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WSHOST_NUM_NOSSO_TITULO = WSHOST_NUM_NOSSO_TITULO.ToString(),
            };

            R0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1.Execute(r0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0370-00-SELECT-AVISOCRED-DB-SELECT-3 */
        public void R0370_00_SELECT_AVISOCRED_DB_SELECT_3()
        {
            /*" -939- EXEC SQL SELECT NUM_AVISO_CREDITO INTO :AVISOCRE-NUM-AVISO-CREDITO FROM SEGUROS.AVISO_CREDITO WHERE BCO_AVISO = :AVISOCRE-BCO-AVISO AND AGE_AVISO = :AVISOCRE-AGE-AVISO AND NUM_AVISO_CREDITO = :AVISOCRE-NUM-AVISO-CREDITO WITH UR END-EXEC. */

            var r0370_00_SELECT_AVISOCRED_DB_SELECT_3_Query1 = new R0370_00_SELECT_AVISOCRED_DB_SELECT_3_Query1()
            {
                AVISOCRE_NUM_AVISO_CREDITO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.ToString(),
                AVISOCRE_BCO_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO.ToString(),
                AVISOCRE_AGE_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO.ToString(),
            };

            var executed_1 = R0370_00_SELECT_AVISOCRED_DB_SELECT_3_Query1.Execute(r0370_00_SELECT_AVISOCRED_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0370-00-SELECT-AVISOCRED-DB-SELECT-4 */
        public void R0370_00_SELECT_AVISOCRED_DB_SELECT_4()
        {
            /*" -970- EXEC SQL SELECT NUM_AVISO_CREDITO INTO :AVISOCRE-NUM-AVISO-CREDITO FROM SEGUROS.AVISO_CREDITO WHERE BCO_AVISO = :AVISOCRE-BCO-AVISO AND AGE_AVISO = :AVISOCRE-AGE-AVISO AND NUM_AVISO_CREDITO = :AVISOCRE-NUM-AVISO-CREDITO WITH UR END-EXEC. */

            var r0370_00_SELECT_AVISOCRED_DB_SELECT_4_Query1 = new R0370_00_SELECT_AVISOCRED_DB_SELECT_4_Query1()
            {
                AVISOCRE_NUM_AVISO_CREDITO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.ToString(),
                AVISOCRE_BCO_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO.ToString(),
                AVISOCRE_AGE_AVISO = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO.ToString(),
            };

            var executed_1 = R0370_00_SELECT_AVISOCRED_DB_SELECT_4_Query1.Execute(r0370_00_SELECT_AVISOCRED_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
            }


        }

        [StopWatch]
        /*" R0450-00-OUTPUT-SORT-SECTION */
        private void R0450_00_OUTPUT_SORT_SECTION()
        {
            /*" -1033- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1034- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -1037- PERFORM R0500-00-LE-ARQSORT. */

            R0500_00_LE_ARQSORT_SECTION();

            /*" -1038- IF WFIM-SORT NOT EQUAL SPACES */

            if (!W.WFIM_SORT.IsEmpty())
            {

                /*" -1041- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1044- WRITE REG-BI0074B FROM LC00. */
            _.Move(AUX_RELATORIO.LC00.GetMoveValues(), REG_BI0074B);

            BI0074B1.Write(REG_BI0074B.GetMoveValues().ToString());

            /*" -1048- PERFORM R0510-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R0510_00_PROCESSA_SORT_SECTION();
            }

            /*" -1049- DISPLAY ' ' */
            _.Display($" ");

            /*" -1050- DISPLAY 'LIDOS SORT ............ ' LD-SORT */
            _.Display($"LIDOS SORT ............ {W.LD_SORT}");

            /*" -1051- DISPLAY 'REGISTRO EM FOLLOUP ... ' TE-FOLLOWUP */
            _.Display($"REGISTRO EM FOLLOUP ... {W.TE_FOLLOWUP}");

            /*" -1052- DISPLAY 'INCLUIDOS FOLLOUP ..... ' AC-FOLLOWUP */
            _.Display($"INCLUIDOS FOLLOUP ..... {W.AC_FOLLOWUP}");

            /*" -1053- DISPLAY 'SEM COBERTURA ......... ' NT-BILHECOB */
            _.Display($"SEM COBERTURA ......... {W.NT_BILHECOB}");

            /*" -1054- DISPLAY 'DUPLICIDADE ........... ' TE-RCAP */
            _.Display($"DUPLICIDADE ........... {W.TE_RCAP}");

            /*" -1055- DISPLAY 'GRAVADOS ARQUIVO ...... ' GV-SAIDA */
            _.Display($"GRAVADOS ARQUIVO ...... {W.GV_SAIDA}");

            /*" -1056- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1057- DISPLAY 'INCLUIDOS AVISOCRE .... ' AC-AVISOCRE. */
            _.Display($"INCLUIDOS AVISOCRE .... {W.AC_AVISOCRE}");

            /*" -1058- DISPLAY 'INCLUIDOS AVISOSAL .... ' AC-AVISOSAL. */
            _.Display($"INCLUIDOS AVISOSAL .... {W.AC_AVISOSAL}");

            /*" -1059- DISPLAY 'INCLUIDOS CONDESCE .... ' AC-CONDESCE. */
            _.Display($"INCLUIDOS CONDESCE .... {W.AC_CONDESCE}");

            /*" -1060- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1061- DISPLAY 'PAGAMENTOS PROCESSADOS. ' AC-EMITE. */
            _.Display($"PAGAMENTOS PROCESSADOS. {W.AC_EMITE}");

            /*" -1061- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-LE-ARQSORT-SECTION */
        private void R0500_00_LE_ARQSORT_SECTION()
        {
            /*" -1075- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1077- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -1078- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -1083- MOVE ZEROS TO ATU-COD-BANCO ATU-COD-AGENCIA ATU-NUM-AVISO ATU-COD-PRODUTO */
                    _.Move(0, W.WS_CHAVE_ATU.ATU_COD_BANCO, W.WS_CHAVE_ATU.ATU_COD_AGENCIA, W.WS_CHAVE_ATU.ATU_NUM_AVISO, W.ATU_COD_PRODUTO);

                    /*" -1086- GO TO R0500-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1088- MOVE SOR-COD-BANCO TO ATU-COD-BANCO. */
            _.Move(REG_ARQSORT.SOR_COD_BANCO, W.WS_CHAVE_ATU.ATU_COD_BANCO);

            /*" -1090- MOVE SOR-COD-AGENCIA TO ATU-COD-AGENCIA. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, W.WS_CHAVE_ATU.ATU_COD_AGENCIA);

            /*" -1092- MOVE SOR-NUM-AVISO TO ATU-NUM-AVISO. */
            _.Move(REG_ARQSORT.SOR_NUM_AVISO, W.WS_CHAVE_ATU.ATU_NUM_AVISO);

            /*" -1096- MOVE SOR-COD-PRODUTO TO ATU-COD-PRODUTO. */
            _.Move(REG_ARQSORT.SOR_COD_PRODUTO, W.ATU_COD_PRODUTO);

            /*" -1096- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-PROCESSA-SORT-SECTION */
        private void R0510_00_PROCESSA_SORT_SECTION()
        {
            /*" -1110- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1113- PERFORM R0520-00-MONTA-AVISOCRE. */

            R0520_00_MONTA_AVISOCRE_SECTION();

            /*" -1115- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT. */
            _.Move(W.WS_CHAVE_ATU, W.WS_CHAVE_ANT);

            /*" -1120- PERFORM R0550-00-PROCESSA-AVISO UNTIL WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.WS_CHAVE_ATU != W.WS_CHAVE_ANT || !W.WFIM_SORT.IsEmpty()))
            {

                R0550_00_PROCESSA_AVISO_SECTION();
            }

            /*" -1121- IF AVISOCRE-PRM-TOTAL NOT EQUAL ZEROS */

            if (AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL != 00)
            {

                /*" -1122- PERFORM R5100-00-INSERT-AVISOCRE */

                R5100_00_INSERT_AVISOCRE_SECTION();

                /*" -1122- PERFORM R5200-00-INSERT-AVISOSAL. */

                R5200_00_INSERT_AVISOSAL_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-MONTA-AVISOCRE-SECTION */
        private void R0520_00_MONTA_AVISOCRE_SECTION()
        {
            /*" -1140- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1142- MOVE SOR-COD-BANCO TO AVISOCRE-BCO-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_BANCO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO);

            /*" -1144- MOVE SOR-COD-AGENCIA TO AVISOCRE-AGE-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO);

            /*" -1146- MOVE SOR-NUM-AVISO TO AVISOCRE-NUM-AVISO-CREDITO. */
            _.Move(REG_ARQSORT.SOR_NUM_AVISO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);

            /*" -1148- MOVE 1 TO AVISOCRE-NUM-SEQUENCIA. */
            _.Move(1, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_SEQUENCIA);

            /*" -1150- MOVE SISTEMAS-DATA-MOV-ABERTO TO AVISOCRE-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO);

            /*" -1152- MOVE 100 TO AVISOCRE-COD-OPERACAO. */
            _.Move(100, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_OPERACAO);

            /*" -1154- MOVE 'R' TO AVISOCRE-TIPO-AVISO. */
            _.Move("R", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_TIPO_AVISO);

            /*" -1156- MOVE SOR-DATA-MOVIMENTO TO AVISOCRE-DATA-AVISO. */
            _.Move(REG_ARQSORT.SOR_DATA_MOVIMENTO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO);

            /*" -1163- MOVE ZEROS TO AVISOCRE-VAL-IOCC AVISOCRE-VAL-DESPESA AVISOCRE-PRM-COSSEGURO-CED AVISOCRE-PRM-LIQUIDO AVISOCRE-PRM-TOTAL AVISOCRE-VAL-ADIANTAMENTO. */
            _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_IOCC, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_COSSEGURO_CED, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_ADIANTAMENTO);

            /*" -1165- MOVE '0' TO AVISOCRE-SIT-CONTABIL. */
            _.Move("0", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_SIT_CONTABIL);

            /*" -1167- MOVE ZEROS TO AVISOCRE-COD-EMPRESA. */
            _.Move(0, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA);

            /*" -1170- MOVE 1 TO AVISOCRE-ORIGEM-AVISO. */
            _.Move(1, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_ORIGEM_AVISO);

            /*" -1175- MOVE 'P' TO AVISOCRE-STA-DEPOSITO-TER. */
            _.Move("P", AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_STA_DEPOSITO_TER);

            /*" -1177- MOVE AVISOCRE-COD-EMPRESA TO AVISOSAL-COD-EMPRESA. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_COD_EMPRESA);

            /*" -1179- MOVE AVISOCRE-BCO-AVISO TO AVISOSAL-BCO-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO);

            /*" -1181- MOVE AVISOCRE-AGE-AVISO TO AVISOSAL-AGE-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO);

            /*" -1183- MOVE '1' TO AVISOSAL-TIPO-SEGURO. */
            _.Move("1", AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_TIPO_SEGURO);

            /*" -1185- MOVE AVISOCRE-NUM-AVISO-CREDITO TO AVISOSAL-NUM-AVISO-CREDITO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO);

            /*" -1187- MOVE AVISOCRE-DATA-AVISO TO AVISOSAL-DATA-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_AVISO);

            /*" -1189- MOVE SISTEMAS-DATA-MOV-ABERTO TO AVISOSAL-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO);

            /*" -1191- MOVE ZEROS TO AVISOSAL-SALDO-ATUAL. */
            _.Move(0, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);

            /*" -1192- MOVE '0' TO AVISOSAL-SIT-REGISTRO. */
            _.Move("0", AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SIT_REGISTRO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-PROCESSA-AVISO-SECTION */
        private void R0550_00_PROCESSA_AVISO_SECTION()
        {
            /*" -1206- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1208- PERFORM R0560-00-MONTA-CONDESCE. */

            R0560_00_MONTA_CONDESCE_SECTION();

            /*" -1210- MOVE ATU-COD-PRODUTO TO ANT-COD-PRODUTO. */
            _.Move(W.ATU_COD_PRODUTO, W.ANT_COD_PRODUTO);

            /*" -1216- PERFORM R0600-00-PROCESSA-REGISTRO UNTIL ATU-COD-PRODUTO NOT EQUAL ANT-COD-PRODUTO OR WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.ATU_COD_PRODUTO != W.ANT_COD_PRODUTO || W.WS_CHAVE_ATU != W.WS_CHAVE_ANT || !W.WFIM_SORT.IsEmpty()))
            {

                R0600_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1217- IF CONDESCE-PRM-TOTAL NOT EQUAL ZEROS */

            if (CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL != 00)
            {

                /*" -1217- PERFORM R5300-00-INSERT-CONDESCE. */

                R5300_00_INSERT_CONDESCE_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0560-00-MONTA-CONDESCE-SECTION */
        private void R0560_00_MONTA_CONDESCE_SECTION()
        {
            /*" -1235- MOVE '0560' TO WNR-EXEC-SQL. */
            _.Move("0560", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1237- MOVE AVISOCRE-COD-EMPRESA TO CONDESCE-COD-EMPRESA. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_COD_EMPRESA, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_EMPRESA);

            /*" -1239- MOVE AVISOCRE-DATA-AVISO TO WDATA-REL. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, W.WDATA_REL);

            /*" -1241- MOVE WDAT-REL-ANO TO CONDESCE-ANO-REFERENCIA. */
            _.Move(W.FILLER_5.WDAT_REL_ANO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_ANO_REFERENCIA);

            /*" -1243- MOVE WDAT-REL-MES TO CONDESCE-MES-REFERENCIA. */
            _.Move(W.FILLER_5.WDAT_REL_MES, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_MES_REFERENCIA);

            /*" -1245- MOVE AVISOCRE-BCO-AVISO TO CONDESCE-BCO-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO);

            /*" -1247- MOVE AVISOCRE-AGE-AVISO TO CONDESCE-AGE-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO);

            /*" -1249- MOVE AVISOCRE-NUM-AVISO-CREDITO TO CONDESCE-NUM-AVISO-CREDITO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO);

            /*" -1251- MOVE ATU-COD-PRODUTO TO CONDESCE-COD-PRODUTO. */
            _.Move(W.ATU_COD_PRODUTO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO);

            /*" -1253- MOVE 'A' TO CONDESCE-TIPO-REGISTRO. */
            _.Move("A", CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_REGISTRO);

            /*" -1255- MOVE '0' TO CONDESCE-SITUACAO. */
            _.Move("0", CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_SITUACAO);

            /*" -1257- MOVE '0' TO CONDESCE-TIPO-COBRANCA. */
            _.Move("0", CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_TIPO_COBRANCA);

            /*" -1259- MOVE SISTEMAS-DATA-MOV-ABERTO TO CONDESCE-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_MOVIMENTO);

            /*" -1261- MOVE AVISOCRE-DATA-AVISO TO CONDESCE-DATA-AVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_AVISO);

            /*" -1270- MOVE ZEROS TO CONDESCE-QTD-REGISTROS CONDESCE-PRM-TOTAL CONDESCE-PRM-LIQUIDO CONDESCE-VAL-TARIFA CONDESCE-VAL-BALCAO CONDESCE-VAL-IOCC CONDESCE-VAL-DESCONTO CONDESCE-VAL-JUROS CONDESCE-VAL-MULTA. */
            _.Move(0, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_BALCAO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_IOCC, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_DESCONTO, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_JUROS, CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_MULTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-PROCESSA-REGISTRO-SECTION */
        private void R0600_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1290- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1302- MOVE ZEROS TO AUX-VALOR */
            _.Move(0, W.AUX_VALOR);

            /*" -1303- IF SOR-TEM-PROPOSTA EQUAL 'N' */

            if (REG_ARQSORT.SOR_TEM_PROPOSTA == "N")
            {

                /*" -1304- IF SOR-SIT-REGISTRO EQUAL '2' */

                if (REG_ARQSORT.SOR_SIT_REGISTRO == "2")
                {

                    /*" -1306- MOVE 'SEM PROPOSTA - EM FOLLOWUP              ' TO LD01-MENSAGEM */
                    _.Move("SEM PROPOSTA - EM FOLLOWUP              ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                    /*" -1307- ADD 1 TO TE-FOLLOWUP */
                    W.TE_FOLLOWUP.Value = W.TE_FOLLOWUP + 1;

                    /*" -1308- PERFORM R1000-00-GRAVA-ARQUIVO */

                    R1000_00_GRAVA_ARQUIVO_SECTION();

                    /*" -1309- GO TO R0600-90-LEITURA */

                    R0600_90_LEITURA(); //GOTO
                    return;

                    /*" -1310- ELSE */
                }
                else
                {


                    /*" -1312- MOVE 'SEM PROPOSTA - INCLUIDO FOLLOWUP        ' TO LD01-MENSAGEM */
                    _.Move("SEM PROPOSTA - INCLUIDO FOLLOWUP        ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                    /*" -1313- PERFORM R4000-00-TRATA-FOLLOWUP */

                    R4000_00_TRATA_FOLLOWUP_SECTION();

                    /*" -1314- PERFORM R1000-00-GRAVA-ARQUIVO */

                    R1000_00_GRAVA_ARQUIVO_SECTION();

                    /*" -1320- GO TO R0600-90-LEITURA. */

                    R0600_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -1326- MOVE 'S' TO WTEM-COBERTURA. */
            _.Move("S", W.WTEM_COBERTURA);

            /*" -1352- MOVE 'N' TO WTEM-RCAP. */
            _.Move("N", W.WTEM_RCAP);

            /*" -1353- IF SOR-SIT-REGISTRO EQUAL '2' */

            if (REG_ARQSORT.SOR_SIT_REGISTRO == "2")
            {

                /*" -1354- PERFORM R4500-00-UPDATE-AVISOSAL */

                R4500_00_UPDATE_AVISOSAL_SECTION();

                /*" -1355- ELSE */
            }
            else
            {


                /*" -1356- IF SOR-SIT-REGISTRO EQUAL SPACES */

                if (REG_ARQSORT.SOR_SIT_REGISTRO.IsEmpty())
                {

                    /*" -1358- ADD 1 TO CONDESCE-QTD-REGISTROS */
                    CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS + 1;

                    /*" -1361- ADD AUX-VALOR TO AVISOCRE-VAL-DESPESA CONDESCE-VAL-TARIFA */
                    AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA + W.AUX_VALOR;
                    CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA + W.AUX_VALOR;

                    /*" -1365- ADD SOR-VAL-TITULO TO AVISOCRE-PRM-TOTAL CONDESCE-PRM-TOTAL. */
                    AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL + REG_ARQSORT.SOR_VAL_TITULO;
                    CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL + REG_ARQSORT.SOR_VAL_TITULO;
                }

            }


            /*" -1368- MOVE '1' TO MOVIMCOB-SIT-REGISTRO */
            _.Move("1", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -1371- MOVE SOR-NUM-NOSSO-TITULO TO MOVIMCOB-NUM-NOSSO-TITULO. */
            _.Move(REG_ARQSORT.SOR_NUM_NOSSO_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

            /*" -1377- PERFORM R4200-00-UPDATE-V0MOVICOB. */

            R4200_00_UPDATE_V0MOVICOB_SECTION();

            /*" -1377- ADD 1 TO AC-EMITE. */
            W.AC_EMITE.Value = W.AC_EMITE + 1;

            /*" -0- FLUXCONTROL_PERFORM R0600_90_LEITURA */

            R0600_90_LEITURA();

        }

        [StopWatch]
        /*" R0600-90-LEITURA */
        private void R0600_90_LEITURA(bool isPerform = false)
        {
            /*" -1382- PERFORM R0500-00-LE-ARQSORT. */

            R0500_00_LE_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-GRAVA-ARQUIVO-SECTION */
        private void R1000_00_GRAVA_ARQUIVO_SECTION()
        {
            /*" -1463- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1465- MOVE 1028370056 TO LD01-CONVENIO. */
            _.Move(1028370056, AUX_RELATORIO.LD01.LD01_CONVENIO);

            /*" -1467- MOVE SOR-NUM-NOSSO-TITULO TO LD01-PROPOSTA. */
            _.Move(REG_ARQSORT.SOR_NUM_NOSSO_TITULO, AUX_RELATORIO.LD01.LD01_PROPOSTA);

            /*" -1469- MOVE SOR-NUM-TITULO TO LD01-BILHETE. */
            _.Move(REG_ARQSORT.SOR_NUM_TITULO, AUX_RELATORIO.LD01.LD01_BILHETE);

            /*" -1471- MOVE SOR-NUM-FITA TO LD01-NSAS. */
            _.Move(REG_ARQSORT.SOR_NUM_FITA, AUX_RELATORIO.LD01.LD01_NSAS);

            /*" -1473- MOVE SOR-VAL-TITULO TO LD01-VALOR. */
            _.Move(REG_ARQSORT.SOR_VAL_TITULO, AUX_RELATORIO.LD01.LD01_VALOR);

            /*" -1475- MOVE SOR-COD-PRODUTO TO LD01-CODPRODU. */
            _.Move(REG_ARQSORT.SOR_COD_PRODUTO, AUX_RELATORIO.LD01.LD01_CODPRODU);

            /*" -1477- MOVE SOR-NUM-APOLICE TO LD01-APOLICE. */
            _.Move(REG_ARQSORT.SOR_NUM_APOLICE, AUX_RELATORIO.LD01.LD01_APOLICE);

            /*" -1479- MOVE SOR-NUM-ENDOSSO TO LD01-ENDOSSO. */
            _.Move(REG_ARQSORT.SOR_NUM_ENDOSSO, AUX_RELATORIO.LD01.LD01_ENDOSSO);

            /*" -1483- MOVE SOR-NUM-PARCELA TO LD01-PARCELA. */
            _.Move(REG_ARQSORT.SOR_NUM_PARCELA, AUX_RELATORIO.LD01.LD01_PARCELA);

            /*" -1485- MOVE SOR-DATA-MOVIMENTO TO WDATA-REL */
            _.Move(REG_ARQSORT.SOR_DATA_MOVIMENTO, W.WDATA_REL);

            /*" -1486- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_5.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1487- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_5.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1488- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_5.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1490- MOVE WDATA-CABEC TO LD01-DTPAGTO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTPAGTO);

            /*" -1493- MOVE SOR-DATA-QUITACAO TO WDATA-REL */
            _.Move(REG_ARQSORT.SOR_DATA_QUITACAO, W.WDATA_REL);

            /*" -1494- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_5.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1495- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_5.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1496- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_5.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1499- MOVE WDATA-CABEC TO LD01-DTCREDITO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTCREDITO);

            /*" -1500- WRITE REG-BI0074B FROM LD01. */
            _.Move(AUX_RELATORIO.LD01.GetMoveValues(), REG_BI0074B);

            BI0074B1.Write(REG_BI0074B.GetMoveValues().ToString());

            /*" -1500- ADD 1 TO GV-SAIDA. */
            W.GV_SAIDA.Value = W.GV_SAIDA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-FONTES-SECTION */
        private void R1200_00_SELECT_FONTES_SECTION()
        {
            /*" -1514- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1518- MOVE SOR-COD-FONTE TO FONTES-COD-FONTE. */
            _.Move(REG_ARQSORT.SOR_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);

            /*" -1527- PERFORM R1200_00_SELECT_FONTES_DB_SELECT_1 */

            R1200_00_SELECT_FONTES_DB_SELECT_1();

            /*" -1531- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1532- DISPLAY 'R1200-00 - PROBLEMAS NO SELECT(FONTES)  ' */
                _.Display($"R1200-00 - PROBLEMAS NO SELECT(FONTES)  ");

                /*" -1535- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1538- COMPUTE FONTES-ULT-PROP-AUTOMAT EQUAL (FONTES-ULT-PROP-AUTOMAT + 1). */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = (FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1);

            /*" -1540- MOVE ZEROS TO AC-CONTROLE. */
            _.Move(0, W.AC_CONTROLE);

            /*" -1540- PERFORM R1250-00-UPDATE-FONTES. */

            R1250_00_UPDATE_FONTES_SECTION();

        }

        [StopWatch]
        /*" R1200-00-SELECT-FONTES-DB-SELECT-1 */
        public void R1200_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -1527- EXEC SQL SELECT ULT_PROP_AUTOMAT INTO :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :FONTES-COD-FONTE WITH UR END-EXEC. */

            var r1200_00_SELECT_FONTES_DB_SELECT_1_Query1 = new R1200_00_SELECT_FONTES_DB_SELECT_1_Query1()
            {
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-UPDATE-FONTES-SECTION */
        private void R1250_00_UPDATE_FONTES_SECTION()
        {
            /*" -1553- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1561- PERFORM R1250_00_UPDATE_FONTES_DB_UPDATE_1 */

            R1250_00_UPDATE_FONTES_DB_UPDATE_1();

            /*" -1564- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1565- DISPLAY 'R1250-00 - PROBLEMAS UPDATE (FONTES)      ' */
                _.Display($"R1250-00 - PROBLEMAS UPDATE (FONTES)      ");

                /*" -1565- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1250-00-UPDATE-FONTES-DB-UPDATE-1 */
        public void R1250_00_UPDATE_FONTES_DB_UPDATE_1()
        {
            /*" -1561- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :FONTES-ULT-PROP-AUTOMAT WHERE COD_FONTE = :FONTES-COD-FONTE END-EXEC. */

            var r1250_00_UPDATE_FONTES_DB_UPDATE_1_Update1 = new R1250_00_UPDATE_FONTES_DB_UPDATE_1_Update1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
            };

            R1250_00_UPDATE_FONTES_DB_UPDATE_1_Update1.Execute(r1250_00_UPDATE_FONTES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TRATA-FOLLOWUP-SECTION */
        private void R4000_00_TRATA_FOLLOWUP_SECTION()
        {
            /*" -1843- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1846- ADD 1 TO AC-FOLLOWUP. */
            W.AC_FOLLOWUP.Value = W.AC_FOLLOWUP + 1;

            /*" -1848- ADD 1 TO CONDESCE-QTD-REGISTROS. */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_QTD_REGISTROS + 1;

            /*" -1851- ADD AUX-VALOR TO AVISOCRE-VAL-DESPESA CONDESCE-VAL-TARIFA. */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA + W.AUX_VALOR;
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA + W.AUX_VALOR;

            /*" -1857- ADD SOR-VAL-TITULO TO AVISOCRE-PRM-TOTAL CONDESCE-PRM-TOTAL AVISOSAL-SALDO-ATUAL. */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL + REG_ARQSORT.SOR_VAL_TITULO;
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL.Value = CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL + REG_ARQSORT.SOR_VAL_TITULO;
            AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL.Value = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL + REG_ARQSORT.SOR_VAL_TITULO;

            /*" -1859- MOVE SOR-NUM-APOLICE TO FOLLOUP-NUM-APOLICE. */
            _.Move(REG_ARQSORT.SOR_NUM_APOLICE, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE);

            /*" -1861- MOVE SOR-NUM-ENDOSSO TO FOLLOUP-NUM-ENDOSSO. */
            _.Move(REG_ARQSORT.SOR_NUM_ENDOSSO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO);

            /*" -1863- MOVE SOR-NUM-PARCELA TO FOLLOUP-NUM-PARCELA. */
            _.Move(REG_ARQSORT.SOR_NUM_PARCELA, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA);

            /*" -1865- MOVE SPACES TO FOLLOUP-DAC-PARCELA. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DAC_PARCELA);

            /*" -1867- MOVE SISTEMAS-DATA-MOV-ABERTO TO FOLLOUP-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO);

            /*" -1869- MOVE SOR-VAL-TITULO TO FOLLOUP-VAL-OPERACAO. */
            _.Move(REG_ARQSORT.SOR_VAL_TITULO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);

            /*" -1871- MOVE SOR-COD-BANCO TO FOLLOUP-BCO-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_BANCO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO);

            /*" -1873- MOVE SOR-COD-AGENCIA TO FOLLOUP-AGE-AVISO. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO);

            /*" -1875- MOVE SOR-NUM-AVISO TO FOLLOUP-NUM-AVISO-CREDITO. */
            _.Move(REG_ARQSORT.SOR_NUM_AVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO);

            /*" -1877- MOVE 30 TO FOLLOUP-COD-BAIXA-PARCELA. */
            _.Move(30, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_BAIXA_PARCELA);

            /*" -1879- MOVE '1' TO FOLLOUP-COD-ERRO01. */
            _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO01);

            /*" -1885- MOVE SPACES TO FOLLOUP-COD-ERRO02 FOLLOUP-COD-ERRO03 FOLLOUP-COD-ERRO04 FOLLOUP-COD-ERRO05 FOLLOUP-COD-ERRO06. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO02, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO03, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO04, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO05, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO06);

            /*" -1887- MOVE '0' TO FOLLOUP-SIT-REGISTRO. */
            _.Move("0", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_REGISTRO);

            /*" -1889- MOVE SPACES TO FOLLOUP-SIT-CONTABIL. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_CONTABIL);

            /*" -1891- MOVE 103 TO FOLLOUP-COD-OPERACAO. */
            _.Move(103, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_OPERACAO);

            /*" -1893- MOVE SPACES TO FOLLOUP-DATA-LIBERACAO. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_LIBERACAO);

            /*" -1895- MOVE SOR-DATA-QUITACAO TO FOLLOUP-DATA-QUITACAO. */
            _.Move(REG_ARQSORT.SOR_DATA_QUITACAO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_QUITACAO);

            /*" -1897- MOVE SOR-COD-EMPRESA TO FOLLOUP-COD-EMPRESA. */
            _.Move(REG_ARQSORT.SOR_COD_EMPRESA, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_EMPRESA);

            /*" -1899- MOVE ZEROS TO FOLLOUP-ORDEM-LIDER. */
            _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ORDEM_LIDER);

            /*" -1901- MOVE '1' TO FOLLOUP-TIPO-SEGURO. */
            _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_TIPO_SEGURO);

            /*" -1904- MOVE SPACES TO FOLLOUP-NUM-APOL-LIDER FOLLOUP-ENDOS-LIDER. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOL_LIDER, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ENDOS_LIDER);

            /*" -1908- MOVE ZEROS TO FOLLOUP-COD-LIDER FOLLOUP-COD-FONTE FOLLOUP-NUM-RCAP. */
            _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_LIDER, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_FONTE, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_RCAP);

            /*" -1912- MOVE SOR-NUM-NOSSO-TITULO TO FOLLOUP-NUM-NOSSO-TITULO. */
            _.Move(REG_ARQSORT.SOR_NUM_NOSSO_TITULO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_NOSSO_TITULO);

            /*" -1916- MOVE ZEROS TO VIND-NULL02 VIND-NULL03 VIND-NULL05. */
            _.Move(0, VIND_NULL02, VIND_NULL03, VIND_NULL05);

            /*" -1925- MOVE -1 TO VIND-NULL01 VIND-NULL04 VIND-NULL06 VIND-NULL07 VIND-NULL08 VIND-NULL09 VIND-NULL10. */
            _.Move(-1, VIND_NULL01, VIND_NULL04, VIND_NULL06, VIND_NULL07, VIND_NULL08, VIND_NULL09, VIND_NULL10);

            /*" -1926- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -1927- MOVE WS-HH-TIME TO WTIME-HORA. */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_12.WTIME_DAYR.WTIME_HORA);

            /*" -1928- MOVE '.' TO WTIME-2PT1. */
            _.Move(".", W.FILLER_12.WTIME_DAYR.WTIME_2PT1);

            /*" -1929- MOVE WS-MM-TIME TO WTIME-MINU. */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_12.WTIME_DAYR.WTIME_MINU);

            /*" -1930- MOVE '.' TO WTIME-2PT2. */
            _.Move(".", W.FILLER_12.WTIME_DAYR.WTIME_2PT2);

            /*" -1931- MOVE WS-SS-TIME TO WTIME-SEGU. */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_12.WTIME_DAYR.WTIME_SEGU);

            /*" -1934- MOVE WTIME-DAYR TO FOLLOUP-HORA-OPERACAO. */
            _.Move(W.FILLER_12.WTIME_DAYR, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO);

            /*" -1936- MOVE ZEROS TO AC-DUPLICA. */
            _.Move(0, W.AC_DUPLICA);

            /*" -1939- PERFORM R4100-00-INSERT-FOLLOWUP. */

            R4100_00_INSERT_FOLLOWUP_SECTION();

            /*" -1941- MOVE '2' TO MOVIMCOB-SIT-REGISTRO. */
            _.Move("2", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -1943- MOVE SOR-COD-BANCO TO MOVIMCOB-COD-BANCO. */
            _.Move(REG_ARQSORT.SOR_COD_BANCO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);

            /*" -1945- MOVE SOR-COD-AGENCIA TO MOVIMCOB-COD-AGENCIA. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);

            /*" -1947- MOVE SOR-NUM-AVISO TO MOVIMCOB-NUM-AVISO. */
            _.Move(REG_ARQSORT.SOR_NUM_AVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);

            /*" -1949- MOVE SOR-NUM-TITULO TO MOVIMCOB-NUM-TITULO. */
            _.Move(REG_ARQSORT.SOR_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);

            /*" -1951- MOVE SOR-NUM-NOSSO-TITULO TO MOVIMCOB-NUM-NOSSO-TITULO. */
            _.Move(REG_ARQSORT.SOR_NUM_NOSSO_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

            /*" -1953- MOVE SOR-COD-MOVIMENTO TO MOVIMCOB-COD-MOVIMENTO. */
            _.Move(REG_ARQSORT.SOR_COD_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);

            /*" -1956- MOVE SOR-NOME-SEGURADO TO MOVIMCOB-NOME-SEGURADO. */
            _.Move(REG_ARQSORT.SOR_NOME_SEGURADO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);

            /*" -1957- IF SOR-SIT-REGISTRO NOT EQUAL '0' */

            if (REG_ARQSORT.SOR_SIT_REGISTRO != "0")
            {

                /*" -1957- PERFORM R4200-00-UPDATE-V0MOVICOB. */

                R4200_00_UPDATE_V0MOVICOB_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-INSERT-FOLLOWUP-SECTION */
        private void R4100_00_INSERT_FOLLOWUP_SECTION()
        {
            /*" -1970- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2038- PERFORM R4100_00_INSERT_FOLLOWUP_DB_INSERT_1 */

            R4100_00_INSERT_FOLLOWUP_DB_INSERT_1();

            /*" -2043- IF SQLCODE EQUAL -803 AND AC-DUPLICA LESS 10 */

            if (DB.SQLCODE == -803 && W.AC_DUPLICA < 10)
            {

                /*" -2044- ADD 1 TO AC-DUPLICA */
                W.AC_DUPLICA.Value = W.AC_DUPLICA + 1;

                /*" -2045- PERFORM R4110-00-ADICIONA-TIME */

                R4110_00_ADICIONA_TIME_SECTION();

                /*" -2046- GO TO R4100-00-INSERT-FOLLOWUP */
                new Task(() => R4100_00_INSERT_FOLLOWUP_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2047- ELSE */
            }
            else
            {


                /*" -2048- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2050- DISPLAY 'R4100-00 - PROBLEMAS NO INSERT(FOLLOUP)    ' '   ' FOLLOUP-NUM-NOSSO-TITULO */

                    $"R4100-00 - PROBLEMAS NO INSERT(FOLLOUP)       {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_NOSSO_TITULO}"
                    .Display();

                    /*" -2050- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R4100-00-INSERT-FOLLOWUP-DB-INSERT-1 */
        public void R4100_00_INSERT_FOLLOWUP_DB_INSERT_1()
        {
            /*" -2038- EXEC SQL INSERT INTO SEGUROS.FOLLOW_UP (NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DAC_PARCELA , DATA_MOVIMENTO , HORA_OPERACAO , VAL_OPERACAO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , COD_BAIXA_PARCELA , COD_ERRO01 , COD_ERRO02 , COD_ERRO03 , COD_ERRO04 , COD_ERRO05 , COD_ERRO06 , SIT_REGISTRO , SIT_CONTABIL , COD_OPERACAO , DATA_LIBERACAO , DATA_QUITACAO , COD_EMPRESA , TIMESTAMP , ORDEM_LIDER , TIPO_SEGURO , NUM_APOL_LIDER , ENDOS_LIDER , COD_LIDER , COD_FONTE , NUM_RCAP , NUM_NOSSO_TITULO) VALUES (:FOLLOUP-NUM-APOLICE , :FOLLOUP-NUM-ENDOSSO , :FOLLOUP-NUM-PARCELA , :FOLLOUP-DAC-PARCELA , :FOLLOUP-DATA-MOVIMENTO , :FOLLOUP-HORA-OPERACAO , :FOLLOUP-VAL-OPERACAO , :FOLLOUP-BCO-AVISO , :FOLLOUP-AGE-AVISO , :FOLLOUP-NUM-AVISO-CREDITO , :FOLLOUP-COD-BAIXA-PARCELA , :FOLLOUP-COD-ERRO01 , :FOLLOUP-COD-ERRO02 , :FOLLOUP-COD-ERRO03 , :FOLLOUP-COD-ERRO04 , :FOLLOUP-COD-ERRO05 , :FOLLOUP-COD-ERRO06 , :FOLLOUP-SIT-REGISTRO , :FOLLOUP-SIT-CONTABIL , :FOLLOUP-COD-OPERACAO , :FOLLOUP-DATA-LIBERACAO:VIND-NULL01 , :FOLLOUP-DATA-QUITACAO:VIND-NULL02 , :FOLLOUP-COD-EMPRESA:VIND-NULL03 , CURRENT TIMESTAMP , :FOLLOUP-ORDEM-LIDER:VIND-NULL04 , :FOLLOUP-TIPO-SEGURO:VIND-NULL05 , :FOLLOUP-NUM-APOL-LIDER:VIND-NULL06 , :FOLLOUP-ENDOS-LIDER:VIND-NULL07 , :FOLLOUP-COD-LIDER:VIND-NULL08 , :FOLLOUP-COD-FONTE:VIND-NULL09 , :FOLLOUP-NUM-RCAP:VIND-NULL10 , :FOLLOUP-NUM-NOSSO-TITULO) END-EXEC. */

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
            /*" -2064- MOVE '4110' TO WNR-EXEC-SQL. */
            _.Move("4110", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2066- IF WTIME-SEGU GREATER ZEROS AND WTIME-SEGU LESS 59 */

            if (W.FILLER_12.WTIME_DAYR.WTIME_SEGU > 00 && W.FILLER_12.WTIME_DAYR.WTIME_SEGU < 59)
            {

                /*" -2067- ADD 1 TO WTIME-SEGU */
                W.FILLER_12.WTIME_DAYR.WTIME_SEGU.Value = W.FILLER_12.WTIME_DAYR.WTIME_SEGU + 1;

                /*" -2068- ELSE */
            }
            else
            {


                /*" -2070- IF WTIME-MINU GREATER ZEROS AND WTIME-MINU LESS 59 */

                if (W.FILLER_12.WTIME_DAYR.WTIME_MINU > 00 && W.FILLER_12.WTIME_DAYR.WTIME_MINU < 59)
                {

                    /*" -2071- ADD 1 TO WTIME-MINU */
                    W.FILLER_12.WTIME_DAYR.WTIME_MINU.Value = W.FILLER_12.WTIME_DAYR.WTIME_MINU + 1;

                    /*" -2072- MOVE 1 TO WTIME-SEGU */
                    _.Move(1, W.FILLER_12.WTIME_DAYR.WTIME_SEGU);

                    /*" -2073- ELSE */
                }
                else
                {


                    /*" -2075- IF WTIME-HORA GREATER ZEROS AND WTIME-HORA LESS 23 */

                    if (W.FILLER_12.WTIME_DAYR.WTIME_HORA > 00 && W.FILLER_12.WTIME_DAYR.WTIME_HORA < 23)
                    {

                        /*" -2076- ADD 1 TO WTIME-HORA */
                        W.FILLER_12.WTIME_DAYR.WTIME_HORA.Value = W.FILLER_12.WTIME_DAYR.WTIME_HORA + 1;

                        /*" -2077- MOVE 1 TO WTIME-MINU */
                        _.Move(1, W.FILLER_12.WTIME_DAYR.WTIME_MINU);

                        /*" -2078- MOVE 1 TO WTIME-SEGU */
                        _.Move(1, W.FILLER_12.WTIME_DAYR.WTIME_SEGU);

                        /*" -2079- ELSE */
                    }
                    else
                    {


                        /*" -2080- MOVE 1 TO WTIME-HORA */
                        _.Move(1, W.FILLER_12.WTIME_DAYR.WTIME_HORA);

                        /*" -2081- MOVE 1 TO WTIME-MINU */
                        _.Move(1, W.FILLER_12.WTIME_DAYR.WTIME_MINU);

                        /*" -2084- MOVE 1 TO WTIME-SEGU. */
                        _.Move(1, W.FILLER_12.WTIME_DAYR.WTIME_SEGU);
                    }

                }

            }


            /*" -2087- MOVE WTIME-DAYR TO FOLLOUP-HORA-OPERACAO. */
            _.Move(W.FILLER_12.WTIME_DAYR, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4110_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-UPDATE-V0MOVICOB-SECTION */
        private void R4200_00_UPDATE_V0MOVICOB_SECTION()
        {
            /*" -2099- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2108- PERFORM R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1 */

            R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1();

            /*" -2111- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2112- DISPLAY 'R4200-00 - PROBLEMAS UPDATE (V0MOVICOB)   ' */
                _.Display($"R4200-00 - PROBLEMAS UPDATE (V0MOVICOB)   ");

                /*" -2112- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4200-00-UPDATE-V0MOVICOB-DB-UPDATE-1 */
        public void R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1()
        {
            /*" -2108- EXEC SQL UPDATE SEGUROS.MOVIMENTO_COBRANCA SET SIT_REGISTRO = :MOVIMCOB-SIT-REGISTRO WHERE NUM_NOSSO_TITULO = :MOVIMCOB-NUM-NOSSO-TITULO AND TIPO_MOVIMENTO = 'T' AND DATA_MOVIMENTO <= :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */

            var r4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 = new R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1()
            {
                MOVIMCOB_SIT_REGISTRO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO.ToString(),
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1.Execute(r4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-UPDATE-V0BILHETE-SECTION */
        private void R4300_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -2126- MOVE '4300' TO WNR-EXEC-SQL. */
            _.Move("4300", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2132- PERFORM R4300_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R4300_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -2135- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2136- DISPLAY 'R4300-00 - PROBLEMAS UPDATE (V0BILHETE)   ' */
                _.Display($"R4300-00 - PROBLEMAS UPDATE (V0BILHETE)   ");

                /*" -2136- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4300-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R4300_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -2132- EXEC SQL UPDATE SEGUROS.BILHETE SET SITUACAO = :BILHETE-SITUACAO WHERE NUM_BILHETE = :BILHETE-NUM-BILHETE END-EXEC. */

            var r4300_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R4300_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                BILHETE_SITUACAO = BILHETE.DCLBILHETE.BILHETE_SITUACAO.ToString(),
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            R4300_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r4300_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-UPDATE-AVISOSAL-SECTION */
        private void R4500_00_UPDATE_AVISOSAL_SECTION()
        {
            /*" -2150- MOVE '4500' TO WNR-EXEC-SQL. */
            _.Move("4500", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2152- MOVE SOR-VAL-TITULO TO WSHOST-SALDO-ATUAL. */
            _.Move(REG_ARQSORT.SOR_VAL_TITULO, WSHOST_SALDO_ATUAL);

            /*" -2162- PERFORM R4500_00_UPDATE_AVISOSAL_DB_UPDATE_1 */

            R4500_00_UPDATE_AVISOSAL_DB_UPDATE_1();

            /*" -2165- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2166- DISPLAY 'R4500-00 - PROBLEMAS UPDATE (AVISOSAL)    ' */
                _.Display($"R4500-00 - PROBLEMAS UPDATE (AVISOSAL)    ");

                /*" -2166- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4500-00-UPDATE-AVISOSAL-DB-UPDATE-1 */
        public void R4500_00_UPDATE_AVISOSAL_DB_UPDATE_1()
        {
            /*" -2162- EXEC SQL UPDATE SEGUROS.AVISOS_SALDOS SET SALDO_ATUAL = (SALDO_ATUAL - :WSHOST-SALDO-ATUAL) WHERE BCO_AVISO = :AVISOSAL-BCO-AVISO AND AGE_AVISO = :AVISOSAL-AGE-AVISO AND NUM_AVISO_CREDITO = :AVISOSAL-NUM-AVISO-CREDITO END-EXEC. */

            var r4500_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1 = new R4500_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1()
            {
                WSHOST_SALDO_ATUAL = WSHOST_SALDO_ATUAL.ToString(),
                AVISOSAL_NUM_AVISO_CREDITO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO.ToString(),
                AVISOSAL_BCO_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO.ToString(),
                AVISOSAL_AGE_AVISO = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO.ToString(),
            };

            R4500_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1.Execute(r4500_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R5100-00-INSERT-AVISOCRE-SECTION */
        private void R5100_00_INSERT_AVISOCRE_SECTION()
        {
            /*" -2179- MOVE '5100' TO WNR-EXEC-SQL. */
            _.Move("5100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2184- COMPUTE AVISOCRE-PRM-LIQUIDO EQUAL (AVISOCRE-PRM-TOTAL - AVISOCRE-VAL-DESPESA). */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_LIQUIDO.Value = (AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_PRM_TOTAL - AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_VAL_DESPESA);

            /*" -2225- PERFORM R5100_00_INSERT_AVISOCRE_DB_INSERT_1 */

            R5100_00_INSERT_AVISOCRE_DB_INSERT_1();

            /*" -2228- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -2232- DISPLAY 'R5100-00 - PROBLEMAS NO INSERT(AVISOCRE)   ' '  ' AVISOCRE-BCO-AVISO '  ' AVISOCRE-AGE-AVISO '  ' AVISOCRE-NUM-AVISO-CREDITO */

                $"R5100-00 - PROBLEMAS NO INSERT(AVISOCRE)     {AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_BCO_AVISO}  {AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_AGE_AVISO}  {AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO}"
                .Display();

                /*" -2234- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2234- ADD 1 TO AC-AVISOCRE. */
            W.AC_AVISOCRE.Value = W.AC_AVISOCRE + 1;

        }

        [StopWatch]
        /*" R5100-00-INSERT-AVISOCRE-DB-INSERT-1 */
        public void R5100_00_INSERT_AVISOCRE_DB_INSERT_1()
        {
            /*" -2225- EXEC SQL INSERT INTO SEGUROS.AVISO_CREDITO (BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , NUM_SEQUENCIA , DATA_MOVIMENTO , COD_OPERACAO , TIPO_AVISO , DATA_AVISO , VAL_IOCC , VAL_DESPESA , PRM_COSSEGURO_CED , PRM_LIQUIDO , PRM_TOTAL , SIT_CONTABIL , COD_EMPRESA , TIMESTAMP , ORIGEM_AVISO , VAL_ADIANTAMENTO , STA_DEPOSITO_TER) VALUES (:AVISOCRE-BCO-AVISO , :AVISOCRE-AGE-AVISO , :AVISOCRE-NUM-AVISO-CREDITO , :AVISOCRE-NUM-SEQUENCIA , :AVISOCRE-DATA-MOVIMENTO , :AVISOCRE-COD-OPERACAO , :AVISOCRE-TIPO-AVISO , :AVISOCRE-DATA-AVISO , :AVISOCRE-VAL-IOCC , :AVISOCRE-VAL-DESPESA , :AVISOCRE-PRM-COSSEGURO-CED , :AVISOCRE-PRM-LIQUIDO , :AVISOCRE-PRM-TOTAL , :AVISOCRE-SIT-CONTABIL , :AVISOCRE-COD-EMPRESA , CURRENT TIMESTAMP , :AVISOCRE-ORIGEM-AVISO , :AVISOCRE-VAL-ADIANTAMENTO , :AVISOCRE-STA-DEPOSITO-TER) END-EXEC. */

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
            /*" -2247- MOVE '5200' TO WNR-EXEC-SQL. */
            _.Move("5200", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2270- PERFORM R5200_00_INSERT_AVISOSAL_DB_INSERT_1 */

            R5200_00_INSERT_AVISOSAL_DB_INSERT_1();

            /*" -2273- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -2277- DISPLAY 'R5200-00 - PROBLEMAS NO INSERT(AVISOSAL)   ' '  ' AVISOSAL-BCO-AVISO '  ' AVISOSAL-AGE-AVISO '  ' AVISOSAL-NUM-AVISO-CREDITO */

                $"R5200-00 - PROBLEMAS NO INSERT(AVISOSAL)     {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_BCO_AVISO}  {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_AGE_AVISO}  {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_NUM_AVISO_CREDITO}"
                .Display();

                /*" -2279- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2279- ADD 1 TO AC-AVISOSAL. */
            W.AC_AVISOSAL.Value = W.AC_AVISOSAL + 1;

        }

        [StopWatch]
        /*" R5200-00-INSERT-AVISOSAL-DB-INSERT-1 */
        public void R5200_00_INSERT_AVISOSAL_DB_INSERT_1()
        {
            /*" -2270- EXEC SQL INSERT INTO SEGUROS.AVISOS_SALDOS (COD_EMPRESA , BCO_AVISO , AGE_AVISO , TIPO_SEGURO , NUM_AVISO_CREDITO , DATA_AVISO , DATA_MOVIMENTO , SALDO_ATUAL , SIT_REGISTRO , TIMESTAMP) VALUES (:AVISOSAL-COD-EMPRESA , :AVISOSAL-BCO-AVISO , :AVISOSAL-AGE-AVISO , :AVISOSAL-TIPO-SEGURO , :AVISOSAL-NUM-AVISO-CREDITO , :AVISOSAL-DATA-AVISO , :AVISOSAL-DATA-MOVIMENTO , :AVISOSAL-SALDO-ATUAL , :AVISOSAL-SIT-REGISTRO , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -2292- MOVE '5300' TO WNR-EXEC-SQL. */
            _.Move("5300", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2297- COMPUTE CONDESCE-PRM-LIQUIDO EQUAL (CONDESCE-PRM-TOTAL - CONDESCE-VAL-TARIFA). */
            CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_LIQUIDO.Value = (CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_PRM_TOTAL - CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_VAL_TARIFA);

            /*" -2344- PERFORM R5300_00_INSERT_CONDESCE_DB_INSERT_1 */

            R5300_00_INSERT_CONDESCE_DB_INSERT_1();

            /*" -2348- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -2353- DISPLAY 'R5300-00 - PROBLEMAS NO INSERT(CONDESCE)   ' '  ' CONDESCE-BCO-AVISO '  ' CONDESCE-AGE-AVISO '  ' CONDESCE-NUM-AVISO-CREDITO '  ' CONDESCE-COD-PRODUTO */

                $"R5300-00 - PROBLEMAS NO INSERT(CONDESCE)     {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_BCO_AVISO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_AGE_AVISO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_NUM_AVISO_CREDITO}  {CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_COD_PRODUTO}"
                .Display();

                /*" -2356- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2356- ADD 1 TO AC-CONDESCE. */
            W.AC_CONDESCE.Value = W.AC_CONDESCE + 1;

        }

        [StopWatch]
        /*" R5300-00-INSERT-CONDESCE-DB-INSERT-1 */
        public void R5300_00_INSERT_CONDESCE_DB_INSERT_1()
        {
            /*" -2344- EXEC SQL INSERT INTO SEGUROS.CONTROL_DESPES_CEF (COD_EMPRESA , ANO_REFERENCIA , MES_REFERENCIA , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , COD_PRODUTO , TIPO_REGISTRO , SITUACAO , TIPO_COBRANCA , DATA_MOVIMENTO , DATA_AVISO , QTD_REGISTROS , PRM_TOTAL , PRM_LIQUIDO , VAL_TARIFA , VAL_BALCAO , VAL_IOCC , VAL_DESCONTO , VAL_JUROS , VAL_MULTA , TIMESTAMP) VALUES (:CONDESCE-COD-EMPRESA , :CONDESCE-ANO-REFERENCIA , :CONDESCE-MES-REFERENCIA , :CONDESCE-BCO-AVISO , :CONDESCE-AGE-AVISO , :CONDESCE-NUM-AVISO-CREDITO , :CONDESCE-COD-PRODUTO , :CONDESCE-TIPO-REGISTRO , :CONDESCE-SITUACAO , :CONDESCE-TIPO-COBRANCA , :CONDESCE-DATA-MOVIMENTO , :CONDESCE-DATA-AVISO , :CONDESCE-QTD-REGISTROS , :CONDESCE-PRM-TOTAL , :CONDESCE-PRM-LIQUIDO , :CONDESCE-VAL-TARIFA , :CONDESCE-VAL-BALCAO , :CONDESCE-VAL-IOCC , :CONDESCE-VAL-DESCONTO , :CONDESCE-VAL-JUROS , :CONDESCE-VAL-MULTA , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -2367- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, AUX_RELATORIO.WABEND.WSQLCODE);

            /*" -2368- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], AUX_RELATORIO.WABEND.WSQLERRD1);

            /*" -2369- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], AUX_RELATORIO.WABEND.WSQLERRD2);

            /*" -2371- DISPLAY WABEND. */
            _.Display(AUX_RELATORIO.WABEND);

            /*" -2373- DISPLAY LD99-ABEND. */
            _.Display(LD99_ABEND);

            /*" -2373- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2377- CLOSE BI0074B1. */
            BI0074B1.Close();

            /*" -2380- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2380- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}