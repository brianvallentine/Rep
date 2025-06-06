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
using Sias.VidaAzul.DB2.VA0970B;

namespace Code
{
    public class VA0970B
    {
        public bool IsCall { get; set; }

        public VA0970B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      * FUNCAO...................: ACOMPANHAMENTOS DE SINISTROS        *      */
        /*"      *                            E RESULTADOS FINANCEIROS            *      */
        /*"      *                                                                *      */
        /*"      * ANALISE/PROGRAMACAO.....   FAST COMPUTER / EDIVALDO GOMES      *      */
        /*"      *                                                                *      */
        /*"      * PROGRAMA ...............   VA0970B                             *      */
        /*"      *                                                                *      */
        /*"      * DATA ...................   23/11/2009                          *      */
        /*"      *                                                                *      */
        /*"      * CADMUS .................   32824                               *      */
        /*"      *                            VERSAO GERADA A PARTIR DO VA0965B   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                        ALTERACOES                              *      */
        /*"JV111#*----------------------------------------------------------------*      */
        /*"JV111#*VERSAO 11: JV1 DEMANDA 262179 - KINKAS 23/10/2020               *      */
        /*"JV111#*           EXCLUI APOLICES/PRODUTOS JV1 - FASE 2                *      */
        /*"JV111#*           - PROCURAR POR JV111                                 *      */
        /*"JV110 *----------------------------------------------------------------*      */
        /*"JV110 *VERSAO 10: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV110 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV110 *           - PROCURAR POR JV110                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09 - HIST 181.582                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.08    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 46.026                                       *      */
        /*"      *                                                                *      */
        /*"      *               - PASSA A BUSCAR O VALORES DE ATUALIZACAO E JUROS*      */
        /*"      *                 DO PRE-LIBERADOS, NA TABELA SINISTRO_HISTORICO *      */
        /*"      *                 UTILIZANDO OS CODIGOS 1201 E 1202.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/08/2010 - FAST COMPUTER - MARCO PAIVA                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD 45.091                                       *      */
        /*"      *                                                                *      */
        /*"      *               - PASSA A BUSCAR O VALOR DA OPERACAO DO CODIGO   *      */
        /*"      *                 DA OPERACAO 1184, AMBOS DA TABELA              *      */
        /*"      *                 SINISTRO_HISTORICO.                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/07/2010 - FAST COMPUTER - TERCIO FREITAS               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD 42.945                                       *      */
        /*"      *                                                                *      */
        /*"      *               - PASSA A TRATAR O PRODUTO 8105                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/05/2010 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD 42.019                                       *      */
        /*"      *                                                                *      */
        /*"      *               - PASSA A TRATAR PRE-LIBERACOES COM PAGAMENTO    *      */
        /*"      *                 EM CHEQUE, AJUSTA PAGAMENTOS COMPLEMENTARES    *      */
        /*"      *                 E CANCELAMENTOS.                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/05/2010 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD 39.158                                       *      */
        /*"      *                                                                *      */
        /*"      *               - PASSA A TRATAR BILHETE AP  PRODUTO 8201.       *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/03/2010 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD 36.765                                       *      */
        /*"      *                                                                *      */
        /*"      *               - TRATA O AJUSTES E FORMATACAO DE VALORES,       *      */
        /*"      *                 INCLUSAO DE PRODUTOS E AGENCIAS E DESLOCAMENTO *      */
        /*"      *                 DE COLUNAS.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/02/2010 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CAD 35.672                                       *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTE PARA NO CAMPO CNPJ/CPF DO BENEFICIARIO. *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/01/2010 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQSAIDA { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis ARQSAIDA
        {
            get
            {
                _.Move(REG_SAIDA, _ARQSAIDA); VarBasis.RedefinePassValue(REG_SAIDA, _ARQSAIDA, REG_SAIDA); return _ARQSAIDA;
            }
        }
        /*"01          REG-SAIDA       PIC X(400).*/
        public StringBasis REG_SAIDA { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WHOST-MAX-OCORR             PIC  S9(4)    USAGE   COMP.*/
        public IntBasis WHOST_MAX_OCORR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  WHOST-NUM-OCORR-MOVTO       PIC  S9(9)    USAGE   COMP.*/
        public IntBasis WHOST_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77  WHOST-DTFINAL               PIC  X(010)   VALUE   SPACES.*/
        public StringBasis WHOST_DTFINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  WHOST-DT-CORRENTE           PIC  X(010)   VALUE   SPACES.*/
        public StringBasis WHOST_DT_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  WHOST-NUM-APOL-SIN-ANT      PIC  X(013)   VALUE   SPACES.*/
        public StringBasis WHOST_NUM_APOL_SIN_ANT { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
        /*"77  WHOST-VAL-TOT-PRE-LIB-ANT   PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_TOT_PRE_LIB_ANT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-AVISADO-ANT       PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_AVISADO_ANT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-ATU-MON-SUB       PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_ATU_MON_SUB { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-JUROS-SUB         PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_JUROS_SUB { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-PAG-COMP-SUB      PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_PAG_COMP_SUB { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-OPER-SUB          PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_OPER_SUB { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-ATU-MON-TOT       PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_ATU_MON_TOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-JUROS-TOT         PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_JUROS_TOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-PAG-COMP-TOT      PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_PAG_COMP_TOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-OPER-TOT          PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_OPER_TOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-AVISADO-TOT       PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_AVISADO_TOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-PRE-LIB-TOT       PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_PRE_LIB_TOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-OPER              PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_OPER { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-ATU-MON           PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_ATU_MON { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-JUROS             PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_JUROS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-PAG-COMP          PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_PAG_COMP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-VAL-PRE-LIB           PIC  9(13)V9(2) VALUE ZEROS.*/
        public DoubleBasis WHOST_VAL_PRE_LIB { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(2)"), 2);
        /*"77  WHOST-CURRENT-DATE          PIC  X(10)    VALUE   SPACES.*/
        public StringBasis WHOST_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  WHOST-VAL-DIFERENCA         PIC S9(13)V99 COMP    VALUE +0.*/
        public DoubleBasis WHOST_VAL_DIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WHOST-VAL-IN-TOTAL          PIC S9(13)V99 COMP    VALUE +0.*/
        public DoubleBasis WHOST_VAL_IN_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WHOST-VAL-AVISADO           PIC S9(13)V99 COMP    VALUE +0.*/
        public DoubleBasis WHOST_VAL_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  DESPREZADOS-SINISMES        PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_SINISMES { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-SEGURVGA        PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_SEGURVGA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-BILHETE         PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_BILHETE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-CLIENTES        PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_CLIENTES { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-AVISADO         PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_AVISADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-SINISTRO        PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_SINISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-PESS-SINIS      PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_PESS_SINIS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-PESS-EVENTO     PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_PESS_EVENTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-PESS-CONTA      PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_PESS_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-PRODUVG         PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_PRODUVG { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"01  AREA-DE-WORK.*/
        public VA0970B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA0970B_AREA_DE_WORK();
        public class VA0970B_AREA_DE_WORK : VarBasis
        {
            /*"   05       SIST-DT-MOV-ABERTO  PIC  X(10)     VALUE  SPACES.*/
            public StringBasis SIST_DT_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"   05       WFIM-SINISHIS       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WFIM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05       WFIM-SINISHIS1      PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WFIM_SINISHIS1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05       WTEM-VARIAVEL       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_VARIAVEL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05       WTEM-SINISMES       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_SINISMES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05       WTEM-SINISHIS       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05       WTEM-SINISTRO       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05       WTEM-CLIENTES       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_CLIENTES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05       WTEM-SEGURVGA       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05       WTEM-BILHETE        PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05       WTEM-SISTEMAS       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_SISTEMAS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05       WTEM-FONTES         PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_FONTES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05       WTEM-PRODUVG        PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_PRODUVG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05       AUX-TIME            PIC  X(08)     VALUE  SPACES.*/
            public StringBasis AUX_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"   05       AC-LIDOS            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-CONTA            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-GRAVADOS         PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05 AUX-RESULTADO              PIC  9(09)   VALUE   ZEROS.*/
            public IntBasis AUX_RESULTADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05 AUX-RESTO                  PIC  9(09)   VALUE   ZEROS.*/
            public IntBasis AUX_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05 WS-ERRO-DATA               PIC  X(003)  VALUE   SPACES.*/
            public StringBasis WS_ERRO_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"   05 WS-DTH-CRITICA             PIC  9(008).*/
            public IntBasis WS_DTH_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   05 WS-DTH-CRITICA-R           REDEFINES    WS-DTH-CRITICA.*/
            private _REDEF_VA0970B_WS_DTH_CRITICA_R _ws_dth_critica_r { get; set; }
            public _REDEF_VA0970B_WS_DTH_CRITICA_R WS_DTH_CRITICA_R
            {
                get { _ws_dth_critica_r = new _REDEF_VA0970B_WS_DTH_CRITICA_R(); _.Move(WS_DTH_CRITICA, _ws_dth_critica_r); VarBasis.RedefinePassValue(WS_DTH_CRITICA, _ws_dth_critica_r, WS_DTH_CRITICA); _ws_dth_critica_r.ValueChanged += () => { _.Move(_ws_dth_critica_r, WS_DTH_CRITICA); }; return _ws_dth_critica_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_critica_r, WS_DTH_CRITICA); }
            }  //Redefines
            public class _REDEF_VA0970B_WS_DTH_CRITICA_R : VarBasis
            {
                /*"    10     WS-CRITICA-ANO       PIC  9(004).*/
                public IntBasis WS_CRITICA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10     WS-CRITICA-MES       PIC  9(002).*/
                public IntBasis WS_CRITICA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10     WS-CRITICA-DIA       PIC  9(002).*/
                public IntBasis WS_CRITICA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05  WS-LIDOS                PIC 9(008)   VALUE   ZEROS.*/

                public _REDEF_VA0970B_WS_DTH_CRITICA_R()
                {
                    WS_CRITICA_ANO.ValueChanged += OnValueChanged;
                    WS_CRITICA_MES.ValueChanged += OnValueChanged;
                    WS_CRITICA_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_LIDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   05  WS-GRAVA-ARQ1           PIC 9(008)   VALUE   ZEROS.*/
            public IntBasis WS_GRAVA_ARQ1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   05  WS-GRAVA-DES            PIC 9(008)   VALUE   ZEROS.*/
            public IntBasis WS_GRAVA_DES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   05  WS-DATA-ACCEPT.*/
            public VA0970B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new VA0970B_WS_DATA_ACCEPT();
            public class VA0970B_WS_DATA_ACCEPT : VarBasis
            {
                /*"        10  WS-ANO-ACCEPT       PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-MES-ACCEPT       PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-DIA-ACCEPT       PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05  WS-HORA-ACCEPT.*/
            }
            public VA0970B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new VA0970B_WS_HORA_ACCEPT();
            public class VA0970B_WS_HORA_ACCEPT : VarBasis
            {
                /*"        10  WS-HOR-ACCEPT       PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-MIN-ACCEPT       PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-SEG-ACCEPT       PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05  WS-DATA-CURR.*/
            }
            public VA0970B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new VA0970B_WS_DATA_CURR();
            public class VA0970B_WS_DATA_CURR : VarBasis
            {
                /*"        10  WS-DIA-CURR         PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_DIA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)  VALUE   '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"        10  WS-MES-CURR         PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MES_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)  VALUE   '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"        10  WS-ANO-CURR         PIC  9(004)  VALUE   ZEROS.*/
                public IntBasis WS_ANO_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   05  WS-HORA-CURR.*/
            }
            public VA0970B_WS_HORA_CURR WS_HORA_CURR { get; set; } = new VA0970B_WS_HORA_CURR();
            public class VA0970B_WS_HORA_CURR : VarBasis
            {
                /*"        10  WS-HOR-CURR         PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_HOR_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)  VALUE   ':'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"        10  WS-MIN-CURR         PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MIN_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)  VALUE   ':'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"        10  WS-SEG-CURR         PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_SEG_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05  WHOST-DATA-REF          PIC  X(010)  VALUE   SPACES.*/
            }
            public StringBasis WHOST_DATA_REF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"   05  WHOST-COD-PRODUTO       PIC S9(004)  VALUE +0 COMP.*/
            public IntBasis WHOST_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05  WHOST-DTH-INI           PIC  X(010).*/
            public StringBasis WHOST_DTH_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05  WHOST-DTH-FIM           PIC  X(010).*/
            public StringBasis WHOST_DTH_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05  WHOST-DTCURRENT         PIC  X(010)  VALUE SPACES.*/
            public StringBasis WHOST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"   05        DATA-SQL.*/
            public VA0970B_DATA_SQL DATA_SQL { get; set; } = new VA0970B_DATA_SQL();
            public class VA0970B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05       WPAR-PARAMETROS     PIC  X(17).*/
            }
            public StringBasis WPAR_PARAMETROS { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
            /*"   05        FILLER REDEFINES    WPAR-PARAMETROS.*/
            private _REDEF_VA0970B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_VA0970B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_VA0970B_FILLER_7(); _.Move(WPAR_PARAMETROS, _filler_7); VarBasis.RedefinePassValue(WPAR_PARAMETROS, _filler_7, WPAR_PARAMETROS); _filler_7.ValueChanged += () => { _.Move(_filler_7, WPAR_PARAMETROS); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WPAR_PARAMETROS); }
            }  //Redefines
            public class _REDEF_VA0970B_FILLER_7 : VarBasis
            {
                /*"     10     WPAR-ROTINA         PIC  X(01).*/
                public StringBasis WPAR_ROTINA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WPAR-INICIO         PIC  X(08).*/
                public StringBasis WPAR_INICIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"     10     WPAR-FIM            PIC  X(08).*/
                public StringBasis WPAR_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"01         LD00.*/

                public _REDEF_VA0970B_FILLER_7()
                {
                    WPAR_ROTINA.ValueChanged += OnValueChanged;
                    WPAR_INICIO.ValueChanged += OnValueChanged;
                    WPAR_FIM.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA0970B_LD00 LD00 { get; set; } = new VA0970B_LD00();
        public class VA0970B_LD00 : VarBasis
        {
            /*"   05    FILLER     PIC  X(11) VALUE 'RELATORIO A'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"RELATORIO A");
            /*"   05    FILLER     PIC  X(03) VALUE ' - '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
            /*"   05    FILLER     PIC  X(47) VALUE          'ACOMPANHAMENTO SINISTRO E RESULTADO FINANCEIRO'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "47", "X(47)"), @"ACOMPANHAMENTO SINISTRO E RESULTADO FINANCEIRO");
            /*"01         LD01.*/
        }
        public VA0970B_LD01 LD01 { get; set; } = new VA0970B_LD01();
        public class VA0970B_LD01 : VarBasis
        {
            /*"   05    FILLER                PIC  X(12)           VALUE 'NUM SINISTRO'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NUM SINISTRO");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(11)           VALUE 'COD PRODUTO'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"COD PRODUTO");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(12)           VALUE 'NOME PRODUTO'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NOME PRODUTO");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(08)           VALUE 'SEGURADO'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SEGURADO");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(11)           VALUE 'CGCCPF/CNPJ'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CGCCPF/CNPJ");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(10)           VALUE 'VL AVISADO'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"VL AVISADO");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(16)           VALUE 'VL TOTAL PRE LIB'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"VL TOTAL PRE LIB");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(30)           VALUE 'VALOR DE ATUALIZACAO MONETARIA'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"VALOR DE ATUALIZACAO MONETARIA");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(14)           VALUE 'VALOR DE JUROS'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"VALOR DE JUROS");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(22)           VALUE 'PAGAMENTO COMPLEMENTAR'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"PAGAMENTO COMPLEMENTAR");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(15)           VALUE 'NM BENEFICIARIO'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NM BENEFICIARIO");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(16)           VALUE 'CPF BENEFICIARIO'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"CPF BENEFICIARIO");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(11)           VALUE 'VL OPERACAO'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"VL OPERACAO");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(05)           VALUE 'BANCO'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"BANCO");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(07)           VALUE 'AGENCIA'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AGENCIA");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(05)           VALUE 'CONTA'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"CONTA");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    FILLER                PIC  X(08)           VALUE 'OPERACAO'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"OPERACAO");
            /*"   05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01         LD02.*/
        }
        public VA0970B_LD02 LD02 { get; set; } = new VA0970B_LD02();
        public class VA0970B_LD02 : VarBasis
        {
            /*"   05    LD02-NUM-APOL-SINISTRO PIC  X(13).*/
            public StringBasis LD02_NUM_APOL_SINISTRO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-COD-PRODUTO       PIC  X(04).*/
            public StringBasis LD02_COD_PRODUTO { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-NOME-PRODUTO      PIC  X(30).*/
            public StringBasis LD02_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-NOME-RAZAO        PIC  X(40).*/
            public StringBasis LD02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-CGCCPF-CNPJ       PIC  X(15).*/
            public StringBasis LD02_CGCCPF_CNPJ { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-VAL-AVISADO       PIC  9999999999999,99.*/
            public DoubleBasis LD02_VAL_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-VAL-TOT-PRE-LIB   PIC  9999999999999,99.*/
            public DoubleBasis LD02_VAL_TOT_PRE_LIB { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-VAL-ATU-MON       PIC  9999999999999,99.*/
            public DoubleBasis LD02_VAL_ATU_MON { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-VAL-JUROS         PIC  9999999999999,99.*/
            public DoubleBasis LD02_VAL_JUROS { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-VAL-PAG-COMP      PIC  9999999999999,99.*/
            public DoubleBasis LD02_VAL_PAG_COMP { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-NOME-BENEFICIARIO PIC  X(40).*/
            public StringBasis LD02_NOME_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-CPF1-BENEFICIARIO PIC  9(12).*/
            public IntBasis LD02_CPF1_BENEFICIARIO { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"   05    LD02-CPF2-BENEFICIARIO PIC  9(02).*/
            public IntBasis LD02_CPF2_BENEFICIARIO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-VAL-OPER          PIC  9999999999999,99.*/
            public DoubleBasis LD02_VAL_OPER { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-BANCO             PIC  9(04).*/
            public IntBasis LD02_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-AGENCIA           PIC  9(04).*/
            public IntBasis LD02_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-CONTA             PIC  X(12).*/
            public StringBasis LD02_CONTA { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD02-OPERACAO          PIC  X(04).*/
            public StringBasis LD02_OPERACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01         LD03.*/
        }
        public VA0970B_LD03 LD03 { get; set; } = new VA0970B_LD03();
        public class VA0970B_LD03 : VarBasis
        {
            /*"   05    FILLER                 PIC  X(46)  VALUE SPACES.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "46", "X(46)"), @"");
            /*"   05    FILLER                 PIC  X(04)  VALUE ';;;;'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @";;;;");
            /*"   05    LD03-TIPO-TOTAL        PIC  X(56)  VALUE SPACES.*/
            public StringBasis LD03_TIPO_TOTAL { get; set; } = new StringBasis(new PIC("X", "56", "X(56)"), @"");
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD03-VAL-AVISADO       PIC  9999999999999,99.*/
            public DoubleBasis LD03_VAL_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD03-VAL-TOT-PRE-LIB   PIC  9999999999999,99.*/
            public DoubleBasis LD03_VAL_TOT_PRE_LIB { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD03-VAL-ATU-MON       PIC  9999999999999,99.*/
            public DoubleBasis LD03_VAL_ATU_MON { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD03-VAL-JUROS         PIC  9999999999999,99.*/
            public DoubleBasis LD03_VAL_JUROS { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   05    LD03-VAL-PAG-COMP      PIC  9999999999999,99.*/
            public DoubleBasis LD03_VAL_PAG_COMP { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"   05    FILLER                 PIC  X(56)  VALUE SPACES.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "56", "X(56)"), @"");
            /*"   05    FILLER                 PIC  X(03)  VALUE ';;;'.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @";;;");
            /*"   05    LD03-VAL-OPER          PIC  9999999999999,99.*/
            public DoubleBasis LD03_VAL_OPER { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"   05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01         LD04.*/
        }
        public VA0970B_LD04 LD04 { get; set; } = new VA0970B_LD04();
        public class VA0970B_LD04 : VarBasis
        {
            /*"   05    FILLER                 PIC  X(264) VALUE SPACES.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "264", "X(264)"), @"");
            /*"01         WABEND.*/
        }
        public VA0970B_WABEND WABEND { get; set; } = new VA0970B_WABEND();
        public class VA0970B_WABEND : VarBasis
        {
            /*"     10     FILLER              PIC  X(010)    VALUE             'VA0970B'.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0970B");
            /*"     10     FILLER              PIC  X(026)    VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"     10     WNR-EXEC-SQL        PIC  X(004)    VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"     10     FILLER              PIC  X(013)    VALUE             ' *** SQLCODE '.*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"     10     WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.OD002 OD002 { get; set; } = new Dclgens.OD002();
        public Dclgens.OD009 OD009 { get; set; } = new Dclgens.OD009();
        public Dclgens.GE368 GE368 { get; set; } = new Dclgens.GE368();
        public Dclgens.GE369 GE369 { get; set; } = new Dclgens.GE369();
        public Dclgens.SI155 SI155 { get; set; } = new Dclgens.SI155();
        public Dclgens.SI175 SI175 { get; set; } = new Dclgens.SI175();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA0970B_C01_SINISHIS C01_SINISHIS { get; set; } = new VA0970B_C01_SINISHIS();
        public VA0970B_SINISHIS1 SINISHIS1 { get; set; } = new VA0970B_SINISHIS1();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VA0970B_AREA_DE_WORK AREA_DE_WORK_P, string ARQSAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                this.AREA_DE_WORK = AREA_DE_WORK_P;
                ARQSAIDA.SetFile(ARQSAIDA_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { AREA_DE_WORK, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -502- DISPLAY ' ' */
            _.Display($" ");

            /*" -504- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -511- DISPLAY 'PROGRAMA VA0970B - VERSAO V.11#- DEMANDA 262179 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA VA0970B - VERSAO V.11#- DEMANDA 262179 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -513- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -525- DISPLAY ' ' */
            _.Display($" ");

            /*" -527- ACCEPT WPAR-PARAMETROS FROM SYSIN. */
            /*-Accept convertido para parametro de entrada...*/

            /*" -530- MOVE 'NAO' TO WS-ERRO-DATA. */
            _.Move("NAO", AREA_DE_WORK.WS_ERRO_DATA);

            /*" -531- IF WPAR-ROTINA EQUAL 'M' */

            if (AREA_DE_WORK.FILLER_7.WPAR_ROTINA == "M")
            {

                /*" -533- IF WPAR-INICIO EQUAL '00000000' AND WPAR-FIM EQUAL '00000000' */

                if (AREA_DE_WORK.FILLER_7.WPAR_INICIO == "00000000" && AREA_DE_WORK.FILLER_7.WPAR_FIM == "00000000")
                {

                    /*" -535- DISPLAY '*** NAO HOUVE SOLICITACAO  ' WPAR-PARAMETROS */
                    _.Display($"*** NAO HOUVE SOLICITACAO  {AREA_DE_WORK.WPAR_PARAMETROS}");

                    /*" -536- STOP RUN */

                    throw new GoBack();   // => STOP RUN.

                    /*" -537- END-IF */
                }


                /*" -539- END-IF. */
            }


            /*" -542- MOVE WPAR-INICIO TO WS-DTH-CRITICA-R. */
            _.Move(AREA_DE_WORK.FILLER_7.WPAR_INICIO, AREA_DE_WORK.WS_DTH_CRITICA_R);

            /*" -543- IF WS-ERRO-DATA EQUAL 'NAO' */

            if (AREA_DE_WORK.WS_ERRO_DATA == "NAO")
            {

                /*" -545- MOVE WPAR-FIM TO WS-DTH-CRITICA-R */
                _.Move(AREA_DE_WORK.FILLER_7.WPAR_FIM, AREA_DE_WORK.WS_DTH_CRITICA_R);

                /*" -547- END-IF. */
            }


            /*" -549- PERFORM R0100-00-SELECT-SISTEMA. */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -550- IF WPAR-ROTINA EQUAL 'M' */

            if (AREA_DE_WORK.FILLER_7.WPAR_ROTINA == "M")
            {

                /*" -551- PERFORM R0160-00-CONSISTE-DATA */

                R0160_00_CONSISTE_DATA_SECTION();

                /*" -552- PERFORM R0150-00-MONTA-PARAMETROS */

                R0150_00_MONTA_PARAMETROS_SECTION();

                /*" -553- ELSE */
            }
            else
            {


                /*" -555- PERFORM R0100-00-SELECT-SISTEMA */

                R0100_00_SELECT_SISTEMA_SECTION();

                /*" -556- DISPLAY '***     PARAMETROS  ***' */
                _.Display($"***     PARAMETROS  ***");

                /*" -557- DISPLAY '*** TIPO DE ROTINA   ' WPAR-ROTINA */
                _.Display($"*** TIPO DE ROTINA   {AREA_DE_WORK.FILLER_7.WPAR_ROTINA}");

                /*" -558- DISPLAY '*** DATA DE INICIO   ' WHOST-DTH-INI */
                _.Display($"*** DATA DE INICIO   {AREA_DE_WORK.WHOST_DTH_INI}");

                /*" -560- DISPLAY '*** DATA DE FIM      ' WHOST-DTH-FIM */
                _.Display($"*** DATA DE FIM      {AREA_DE_WORK.WHOST_DTH_FIM}");

                /*" -562- END-IF. */
            }


            /*" -565- IF WPAR-ROTINA EQUAL ( 'M' OR 'D' ) AND WS-ERRO-DATA EQUAL 'NAO' NEXT SENTENCE */

            if (AREA_DE_WORK.FILLER_7.WPAR_ROTINA.In("M", "D") && AREA_DE_WORK.WS_ERRO_DATA == "NAO")
            {

                /*" -566- ELSE */
            }
            else
            {


                /*" -568- DISPLAY '*** PROBLEMAS NOS PARAMETROS INFORMADOS ' '(' WPAR-PARAMETROS ') ***' */

                $"*** PROBLEMAS NOS PARAMETROS INFORMADOS ({AREA_DE_WORK.WPAR_PARAMETROS}) ***"
                .Display();

                /*" -569- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -571- END-IF. */
            }


            /*" -573- OPEN OUTPUT ARQSAIDA. */
            ARQSAIDA.Open(REG_SAIDA);

            /*" -575- WRITE REG-SAIDA FROM LD00. */
            _.Move(LD00.GetMoveValues(), REG_SAIDA);

            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -577- WRITE REG-SAIDA FROM LD01. */
            _.Move(LD01.GetMoveValues(), REG_SAIDA);

            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -579- PERFORM R0900-00-DECLARE-CURSOR. */

            R0900_00_DECLARE_CURSOR_SECTION();

            /*" -581- PERFORM R0910-00-FETCH-CURSOR. */

            R0910_00_FETCH_CURSOR_SECTION();

            /*" -583- IF WFIM-SINISHIS EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SINISHIS == "S")
            {

                /*" -585- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -587- DISPLAY '** NAO HA MOVIMENTO PARA O PERIODO **' */
                _.Display($"** NAO HA MOVIMENTO PARA O PERIODO **");

                /*" -590- MOVE '** NAO HA MOVIMENTO PARA ESTE DIA  **' TO LD01 */
                _.Move("** NAO HA MOVIMENTO PARA ESTE DIA  **", LD01);

                /*" -592- WRITE REG-SAIDA FROM LD01 */
                _.Move(LD01.GetMoveValues(), REG_SAIDA);

                ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                /*" -594- PERFORM R0000-90-FINALIZA */

                R0000_90_FINALIZA_SECTION();

                /*" -596- END-IF. */
            }


            /*" -599- PERFORM R1000-00-PROCESSA-SINISHIS UNTIL WFIM-SINISHIS EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SINISHIS == "S"))
            {

                R1000_00_PROCESSA_SINISHIS_SECTION();
            }

            /*" -599- PERFORM R2400-00-PROCESSA-TOTAIS. */

            R2400_00_PROCESSA_TOTAIS_SECTION();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA-SECTION */
        private void R0000_90_FINALIZA_SECTION()
        {
            /*" -607- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -607- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -611- DISPLAY ' ' . */
            _.Display($" ");

            /*" -613- DISPLAY '* TOTAL LIDOS         :' AC-LIDOS. */
            _.Display($"* TOTAL LIDOS         :{AREA_DE_WORK.AC_LIDOS}");

            /*" -615- DISPLAY '* TOTAL DE GRAVADOS   :' AC-GRAVADOS. */
            _.Display($"* TOTAL DE GRAVADOS   :{AREA_DE_WORK.AC_GRAVADOS}");

            /*" -617- DISPLAY '* DESPREZ SINISMES    :' DESPREZADOS-SINISMES. */
            _.Display($"* DESPREZ SINISMES    :{DESPREZADOS_SINISMES}");

            /*" -619- DISPLAY '* DESPREZ SEGURVGA    :' DESPREZADOS-SEGURVGA. */
            _.Display($"* DESPREZ SEGURVGA    :{DESPREZADOS_SEGURVGA}");

            /*" -621- DISPLAY '* DESPREZ BILHETE     :' DESPREZADOS-BILHETE. */
            _.Display($"* DESPREZ BILHETE     :{DESPREZADOS_BILHETE}");

            /*" -623- DISPLAY '* DESPREZ CLIENTES    :' DESPREZADOS-CLIENTES. */
            _.Display($"* DESPREZ CLIENTES    :{DESPREZADOS_CLIENTES}");

            /*" -625- DISPLAY '* DESPREZ AVISADO     :' DESPREZADOS-AVISADO. */
            _.Display($"* DESPREZ AVISADO     :{DESPREZADOS_AVISADO}");

            /*" -627- DISPLAY '* DESPREZ PESS SINIS  :' DESPREZADOS-PESS-SINIS. */
            _.Display($"* DESPREZ PESS SINIS  :{DESPREZADOS_PESS_SINIS}");

            /*" -629- DISPLAY '* DESPREZ PESS EVENTO :' DESPREZADOS-PESS-EVENTO. */
            _.Display($"* DESPREZ PESS EVENTO :{DESPREZADOS_PESS_EVENTO}");

            /*" -631- DISPLAY '* DESPREZ PESS CONTA  :' DESPREZADOS-PESS-CONTA. */
            _.Display($"* DESPREZ PESS CONTA  :{DESPREZADOS_PESS_CONTA}");

            /*" -633- DISPLAY '* DESPREZ PRODUTOS VG :' DESPREZADOS-PRODUVG. */
            _.Display($"* DESPREZ PRODUTOS VG :{DESPREZADOS_PRODUVG}");

            /*" -635- DISPLAY ' ' . */
            _.Display($" ");

            /*" -637- CLOSE ARQSAIDA. */
            ARQSAIDA.Close();

            /*" -639- DISPLAY '* VA0970B - TERMINO NORMAL       ' . */
            _.Display($"* VA0970B - TERMINO NORMAL       ");

            /*" -639- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -661- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -664- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -665- DISPLAY ' PROBLEMAS NO ACESSO A SISTEMAS' */
                _.Display($" PROBLEMAS NO ACESSO A SISTEMAS");

                /*" -666- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -668- END-IF. */
            }


            /*" -669- MOVE SISTEMAS-DATA-MOV-ABERTO TO WHOST-DTH-INI WHOST-DTH-FIM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WHOST_DTH_INI, AREA_DE_WORK.WHOST_DTH_FIM);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -661- EXEC SQL SELECT DATA_MOV_ABERTO , CURRENT_DATE INTO :SISTEMAS-DATA-MOV-ABERTO , :WHOST-CURRENT-DATE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_CURRENT_DATE, WHOST_CURRENT_DATE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-MONTA-PARAMETROS-SECTION */
        private void R0150_00_MONTA_PARAMETROS_SECTION()
        {
            /*" -683- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", WABEND.WNR_EXEC_SQL);

            /*" -686- MOVE WPAR-INICIO (1:4) TO WHOST-DTH-INI (1:4) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_7.WPAR_INICIO.Substring(1, 4), AREA_DE_WORK.WHOST_DTH_INI, 1, 4);

            /*" -689- MOVE WPAR-INICIO (5:2) TO WHOST-DTH-INI (6:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_7.WPAR_INICIO.Substring(5, 2), AREA_DE_WORK.WHOST_DTH_INI, 6, 2);

            /*" -692- MOVE WPAR-INICIO (7:2) TO WHOST-DTH-INI (9:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_7.WPAR_INICIO.Substring(7, 2), AREA_DE_WORK.WHOST_DTH_INI, 9, 2);

            /*" -695- MOVE WPAR-FIM (1:4) TO WHOST-DTH-FIM (1:4) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_7.WPAR_FIM.Substring(1, 4), AREA_DE_WORK.WHOST_DTH_FIM, 1, 4);

            /*" -698- MOVE WPAR-FIM (5:2) TO WHOST-DTH-FIM (6:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_7.WPAR_FIM.Substring(5, 2), AREA_DE_WORK.WHOST_DTH_FIM, 6, 2);

            /*" -701- MOVE WPAR-FIM (7:2) TO WHOST-DTH-FIM (9:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_7.WPAR_FIM.Substring(7, 2), AREA_DE_WORK.WHOST_DTH_FIM, 9, 2);

            /*" -707- MOVE '-' TO WHOST-DTH-FIM(8:1). */
            _.MoveAtPosition("-", AREA_DE_WORK.WHOST_DTH_FIM, 8, 1);

            /*" -707- MOVE '-' TO WHOST-DTH-FIM(5:1) */
            _.MoveAtPosition("-", AREA_DE_WORK.WHOST_DTH_FIM, 5, 1);

            /*" -707- MOVE '-' TO WHOST-DTH-INI(8:1) */
            _.MoveAtPosition("-", AREA_DE_WORK.WHOST_DTH_INI, 8, 1);

            /*" -707- MOVE '-' TO WHOST-DTH-INI(5:1) */
            _.MoveAtPosition("-", AREA_DE_WORK.WHOST_DTH_INI, 5, 1);

            /*" -708- DISPLAY '***     PARAMETROS  ***' */
            _.Display($"***     PARAMETROS  ***");

            /*" -709- DISPLAY '*** TIPO DE ROTINA   ' WPAR-ROTINA. */
            _.Display($"*** TIPO DE ROTINA   {AREA_DE_WORK.FILLER_7.WPAR_ROTINA}");

            /*" -710- DISPLAY '*** DATA DE INICIO   ' WHOST-DTH-INI. */
            _.Display($"*** DATA DE INICIO   {AREA_DE_WORK.WHOST_DTH_INI}");

            /*" -710- DISPLAY '*** DATA DE FIM      ' WHOST-DTH-FIM. */
            _.Display($"*** DATA DE FIM      {AREA_DE_WORK.WHOST_DTH_FIM}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-CONSISTE-DATA-SECTION */
        private void R0160_00_CONSISTE_DATA_SECTION()
        {
            /*" -723- MOVE '0160' TO WNR-EXEC-SQL. */
            _.Move("0160", WABEND.WNR_EXEC_SQL);

            /*" -725- MOVE 'NAO' TO WS-ERRO-DATA */
            _.Move("NAO", AREA_DE_WORK.WS_ERRO_DATA);

            /*" -727- IF WS-CRITICA-ANO LESS 1900 OR WS-CRITICA-ANO IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO < 1900 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO.IsNumeric())
            {

                /*" -728- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -729- GO TO R0160-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                return;

                /*" -731- END-IF. */
            }


            /*" -734- IF WS-CRITICA-MES EQUAL ZEROS OR WS-CRITICA-MES GREATER 12 OR WS-CRITICA-MES IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES == 00 || AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES > 12 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -735- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -736- GO TO R0160-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                return;

                /*" -738- END-IF */
            }


            /*" -740- IF WS-CRITICA-DIA EQUAL ZEROS OR WS-CRITICA-MES IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA == 00 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -741- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -742- GO TO R0160-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                return;

                /*" -744- END-IF. */
            }


            /*" -747- IF WS-CRITICA-MES EQUAL 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -748- IF WS-CRITICA-DIA GREATER 31 */

                if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 31)
                {

                    /*" -749- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                    /*" -750- GO TO R0160-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                    return;

                    /*" -752- END-IF. */
                }

            }


            /*" -753- IF WS-CRITICA-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("04", "06", "09", "11"))
            {

                /*" -754- IF WS-CRITICA-DIA GREATER 30 */

                if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 30)
                {

                    /*" -755- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                    /*" -756- GO TO R0160-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                    return;

                    /*" -757- END-IF */
                }


                /*" -759- END-IF. */
            }


            /*" -760- IF WS-CRITICA-MES EQUAL 02 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES == 02)
            {

                /*" -764- DIVIDE WS-CRITICA-ANO BY 4 GIVING AUX-RESULTADO REMAINDER AUX-RESTO */
                _.Divide(AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO, 4, AREA_DE_WORK.AUX_RESULTADO, AREA_DE_WORK.AUX_RESTO);

                /*" -765- IF AUX-RESTO EQUAL ZEROS */

                if (AREA_DE_WORK.AUX_RESTO == 00)
                {

                    /*" -766- IF WS-CRITICA-DIA GREATER 29 */

                    if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 29)
                    {

                        /*" -767- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                        /*" -768- GO TO R0160-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                        return;

                        /*" -769- END-IF */
                    }


                    /*" -770- ELSE */
                }
                else
                {


                    /*" -771- IF WS-CRITICA-DIA GREATER 28 */

                    if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 28)
                    {

                        /*" -772- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                        /*" -773- GO TO R0160-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                        return;

                        /*" -774- END-IF */
                    }


                    /*" -775- END-IF */
                }


                /*" -775- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-SECTION */
        private void R0900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -788- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -834- PERFORM R0900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R0900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -836- PERFORM R0900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R0900_00_DECLARE_CURSOR_DB_OPEN_1();

            /*" -839- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -840- DISPLAY 'PROBLEMA NO CURSOR SINISHIS.' */
                _.Display($"PROBLEMA NO CURSOR SINISHIS.");

                /*" -841- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -841- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R0900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -834- EXEC SQL DECLARE C01_SINISHIS CURSOR FOR SELECT DISTINCT NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO WHERE DATA_MOVIMENTO BETWEEN :WHOST-DTH-INI AND :WHOST-DTH-FIM AND COD_OPERACAO IN (1181, 1182, 1183, 1184) AND COD_PRODUTO IN (914, 8299, 9324, 9348, 917, 9300, 9325, 9349, 8101, 9301, 9326, 9350, 8102, 9304, 9327, 9399, 8103, 9305, 9328, 9701, 8104, 9307, 9329, 9702, 8107, 9309, 9330, 9703, 8108, 9310, 9331, 9704, 8109, 9311, 9332, 9705, 8110, 9312, 9333, 9706, 8199, 9314, 9334, 9707, 8201, 9315, 9337, 9708, 8202, 9316, 9338, 9710, 8203, 9317, 9339, 9711, 8205, 9318, 9340, 9712, 8206, 9319, 9341, 9713, 8207, 9320, 9342, 9714, 8208, 9321, 9343, 9715, 8209, 9322, 9344, 9799, 8212, 9323, 9347, 8105, :JVPRD8203, :JVPRD8205, :JVPRD8206, :JVPRD8209, :JVPRD9310, :JVPRD9311, :JVPRD9314, :JVPRD9320, :JVPRD9321, :JVPRD9327, :JVPRD9328, :JVPRD9329, :JVPRD9330, :JVPRD9332, :JVPRD9334, :JVPRD9343) ORDER BY NUM_APOL_SINISTRO END-EXEC. */
            C01_SINISHIS = new VA0970B_C01_SINISHIS(true);
            string GetQuery_C01_SINISHIS()
            {
                var query = @$"SELECT DISTINCT 
							NUM_APOL_SINISTRO 
							FROM 
							SEGUROS.SINISTRO_HISTORICO 
							WHERE 
							DATA_MOVIMENTO BETWEEN '{AREA_DE_WORK.WHOST_DTH_INI}' 
							AND '{AREA_DE_WORK.WHOST_DTH_FIM}' 
							AND COD_OPERACAO IN (1181
							, 1182
							, 1183
							, 1184) 
							AND COD_PRODUTO IN 
							(914
							, 8299
							, 9324
							, 9348
							, 
							917
							, 9300
							, 9325
							, 9349
							, 
							8101
							, 9301
							, 9326
							, 9350
							, 
							8102
							, 9304
							, 9327
							, 9399
							, 
							8103
							, 9305
							, 9328
							, 9701
							, 
							8104
							, 9307
							, 9329
							, 9702
							, 
							8107
							, 9309
							, 9330
							, 9703
							, 
							8108
							, 9310
							, 9331
							, 9704
							, 
							8109
							, 9311
							, 9332
							, 9705
							, 
							8110
							, 9312
							, 9333
							, 9706
							, 
							8199
							, 9314
							, 9334
							, 9707
							, 
							8201
							, 9315
							, 9337
							, 9708
							, 
							8202
							, 9316
							, 9338
							, 9710
							, 
							8203
							, 9317
							, 9339
							, 9711
							, 
							8205
							, 9318
							, 9340
							, 9712
							, 
							8206
							, 9319
							, 9341
							, 9713
							, 
							8207
							, 9320
							, 9342
							, 9714
							, 
							8208
							, 9321
							, 9343
							, 9715
							, 
							8209
							, 9322
							, 9344
							, 9799
							, 
							8212
							, 9323
							, 9347
							, 
							8105
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD8203}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD8205}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8206}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD8209}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9310}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD9311}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9314}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD9320}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9321}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD9327}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9328}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD9329}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9330}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD9332}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9334}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD9343}') 
							ORDER BY NUM_APOL_SINISTRO";

                return query;
            }
            C01_SINISHIS.GetQueryEvent += GetQuery_C01_SINISHIS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-OPEN-1 */
        public void R0900_00_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -836- EXEC SQL OPEN C01_SINISHIS END-EXEC. */

            C01_SINISHIS.Open();

        }

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R1900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -1451- EXEC SQL DECLARE SINISHIS1 CURSOR FOR SELECT A.COD_OPERACAO, A.VAL_OPERACAO , A.NOME_FAVORECIDO , A.OCORR_HISTORICO FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND A.COD_OPERACAO IN (1181, 1182, 1183, 1184) AND NOT EXISTS ( SELECT NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO B WHERE B.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO AND B.COD_OPERACAO = A.COD_OPERACAO + 10 AND B.OCORR_HISTORICO = A.OCORR_HISTORICO) END-EXEC. */
            SINISHIS1 = new VA0970B_SINISHIS1(true);
            string GetQuery_SINISHIS1()
            {
                var query = @$"SELECT 
							A.COD_OPERACAO
							, 
							A.VAL_OPERACAO
							, 
							A.NOME_FAVORECIDO
							, 
							A.OCORR_HISTORICO 
							FROM 
							SEGUROS.SINISTRO_HISTORICO A 
							WHERE 
							A.NUM_APOL_SINISTRO = '{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}' 
							AND A.COD_OPERACAO IN (1181
							, 1182
							, 1183
							, 1184) 
							AND NOT EXISTS ( 
							SELECT NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_HISTORICO B 
							WHERE B.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO 
							AND B.COD_OPERACAO = A.COD_OPERACAO + 10 
							AND B.OCORR_HISTORICO = A.OCORR_HISTORICO)";

                return query;
            }
            SINISHIS1.GetQueryEvent += GetQuery_SINISHIS1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-SECTION */
        private void R0910_00_FETCH_CURSOR_SECTION()
        {
            /*" -855- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -858- PERFORM R0910_00_FETCH_CURSOR_DB_FETCH_1 */

            R0910_00_FETCH_CURSOR_DB_FETCH_1();

            /*" -861- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -862- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -862- PERFORM R0910_00_FETCH_CURSOR_DB_CLOSE_1 */

                    R0910_00_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -864- MOVE 'S' TO WFIM-SINISHIS */
                    _.Move("S", AREA_DE_WORK.WFIM_SINISHIS);

                    /*" -865- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -866- ELSE */
                }
                else
                {


                    /*" -867- DISPLAY ' PROBLEMAS NO FETCH DA SINISHIS' */
                    _.Display($" PROBLEMAS NO FETCH DA SINISHIS");

                    /*" -869- DISPLAY ' APOLICE SINISTRO ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($" APOLICE SINISTRO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -870- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -871- END-IF */
                }


                /*" -873- END-IF. */
            }


            /*" -875- ADD 1 TO AC-CONTA. */
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -876- IF AC-CONTA GREATER 9999 */

            if (AREA_DE_WORK.AC_CONTA > 9999)
            {

                /*" -877- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -878- ACCEPT AUX-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.AUX_TIME);

                /*" -882- DISPLAY 'LIDOS SINISHIS ....: ' AC-LIDOS AUX-TIME SINISHIS-NUM-APOL-SINISTRO */

                $"LIDOS SINISHIS ....: {AREA_DE_WORK.AC_LIDOS}{AREA_DE_WORK.AUX_TIME}{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}"
                .Display();

                /*" -882- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-FETCH-1 */
        public void R0910_00_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -858- EXEC SQL FETCH C01_SINISHIS INTO :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            if (C01_SINISHIS.Fetch())
            {
                _.Move(C01_SINISHIS.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-CLOSE-1 */
        public void R0910_00_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -862- EXEC SQL CLOSE C01_SINISHIS END-EXEC */

            C01_SINISHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SINISHIS-SECTION */
        private void R1000_00_PROCESSA_SINISHIS_SECTION()
        {
            /*" -896- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -898- PERFORM R1100-00-SELECT-SINISMES. */

            R1100_00_SELECT_SINISMES_SECTION();

            /*" -899- IF WTEM-SINISMES NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_SINISMES != "S")
            {

                /*" -900- ADD 1 TO DESPREZADOS-SINISMES */
                DESPREZADOS_SINISMES.Value = DESPREZADOS_SINISMES + 1;

                /*" -901- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -903- END-IF. */
            }


            /*" -904- IF SINISMES-NUM-CERTIFICADO GREATER ZEROS */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO > 00)
            {

                /*" -905- PERFORM R1200-00-SELECT-SEGURVGA */

                R1200_00_SELECT_SEGURVGA_SECTION();

                /*" -906- IF WTEM-SEGURVGA NOT EQUAL 'S' */

                if (AREA_DE_WORK.WTEM_SEGURVGA != "S")
                {

                    /*" -907- ADD 1 TO DESPREZADOS-SEGURVGA */
                    DESPREZADOS_SEGURVGA.Value = DESPREZADOS_SEGURVGA + 1;

                    /*" -908- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -909- END-IF */
                }


                /*" -910- MOVE SEGURVGA-COD-CLIENTE TO CLIENTES-COD-CLIENTE */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

                /*" -911- ELSE */
            }
            else
            {


                /*" -912- IF SINISMES-NUM-APOLICE GREATER ZEROS */

                if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE > 00)
                {

                    /*" -913- PERFORM R1250-00-SELECT-BILHETE */

                    R1250_00_SELECT_BILHETE_SECTION();

                    /*" -914- IF WTEM-BILHETE NOT EQUAL 'S' */

                    if (AREA_DE_WORK.WTEM_BILHETE != "S")
                    {

                        /*" -915- ADD 1 TO DESPREZADOS-BILHETE */
                        DESPREZADOS_BILHETE.Value = DESPREZADOS_BILHETE + 1;

                        /*" -916- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -917- END-IF */
                    }


                    /*" -918- MOVE BILHETE-COD-CLIENTE TO CLIENTES-COD-CLIENTE */
                    _.Move(BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

                    /*" -919- MOVE SINISMES-NUM-APOLICE TO SEGURVGA-NUM-APOLICE */
                    _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);

                    /*" -920- ELSE */
                }
                else
                {


                    /*" -921- ADD 1 TO DESPREZADOS-SINISMES */
                    DESPREZADOS_SINISMES.Value = DESPREZADOS_SINISMES + 1;

                    /*" -922- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -923- END-IF */
                }


                /*" -925- END-IF. */
            }


            /*" -927- PERFORM R1300-00-SELECT-CLIENTES. */

            R1300_00_SELECT_CLIENTES_SECTION();

            /*" -928- IF WTEM-CLIENTES NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_CLIENTES != "S")
            {

                /*" -929- ADD 1 TO DESPREZADOS-CLIENTES */
                DESPREZADOS_CLIENTES.Value = DESPREZADOS_CLIENTES + 1;

                /*" -930- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -932- END-IF. */
            }


            /*" -934- PERFORM R1400-00-SELECT-SINISHIS. */

            R1400_00_SELECT_SINISHIS_SECTION();

            /*" -935- IF WTEM-SINISHIS NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_SINISHIS != "S")
            {

                /*" -936- ADD 1 TO DESPREZADOS-AVISADO */
                DESPREZADOS_AVISADO.Value = DESPREZADOS_AVISADO + 1;

                /*" -937- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -939- END-IF. */
            }


            /*" -941- PERFORM R1500-00-SELECT-MAX-OCORR. */

            R1500_00_SELECT_MAX_OCORR_SECTION();

            /*" -948- PERFORM R1600-00-SELECT-SI175. */

            R1600_00_SELECT_SI175_SECTION();

            /*" -955- PERFORM R1700-00-SELECT-GE368. */

            R1700_00_SELECT_GE368_SECTION();

            /*" -962- PERFORM R1800-00-SELECT-OD009. */

            R1800_00_SELECT_OD009_SECTION();

            /*" -964- PERFORM R1850-00-SELECT-PRODUVG. */

            R1850_00_SELECT_PRODUVG_SECTION();

            /*" -965- IF WTEM-PRODUVG NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_PRODUVG != "S")
            {

                /*" -966- ADD 1 TO DESPREZADOS-PRODUVG */
                DESPREZADOS_PRODUVG.Value = DESPREZADOS_PRODUVG + 1;

                /*" -967- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -969- END-IF. */
            }


            /*" -972- MOVE OD009-COD-BANCO TO LD02-BANCO. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO, LD02.LD02_BANCO);

            /*" -975- MOVE OD009-COD-AGENCIA TO LD02-AGENCIA. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA, LD02.LD02_AGENCIA);

            /*" -978- MOVE OD009-NUM-OPERACAO-CONTA TO LD02-OPERACAO. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA, LD02.LD02_OPERACAO);

            /*" -981- MOVE OD009-NUM-CONTA TO LD02-CONTA. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA, LD02.LD02_CONTA);

            /*" -984- MOVE SINISHIS-NUM-APOL-SINISTRO TO LD02-NUM-APOL-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, LD02.LD02_NUM_APOL_SINISTRO);

            /*" -987- MOVE CLIENTES-NOME-RAZAO TO LD02-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LD02.LD02_NOME_RAZAO);

            /*" -990- MOVE CLIENTES-CGCCPF TO LD02-CGCCPF-CNPJ. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, LD02.LD02_CGCCPF_CNPJ);

            /*" -994- MOVE SINISHIS-VAL-OPERACAO TO LD02-VAL-AVISADO WHOST-VAL-AVISADO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD02.LD02_VAL_AVISADO, WHOST_VAL_AVISADO);

            /*" -997- MOVE PRODUVG-COD-PRODUTO TO LD02-COD-PRODUTO. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, LD02.LD02_COD_PRODUTO);

            /*" -1000- MOVE PRODUVG-NOME-PRODUTO TO LD02-NOME-PRODUTO. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, LD02.LD02_NOME_PRODUTO);

            /*" -1003- MOVE 'N' TO WFIM-SINISHIS1. */
            _.Move("N", AREA_DE_WORK.WFIM_SINISHIS1);

            /*" -1005- PERFORM R1900-00-DECLARE-CURSOR. */

            R1900_00_DECLARE_CURSOR_SECTION();

            /*" -1007- PERFORM R1910-00-FETCH-CURSOR. */

            R1910_00_FETCH_CURSOR_SECTION();

            /*" -1008- IF WFIM-SINISHIS1 EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SINISHIS1 == "S")
            {

                /*" -1009- ADD 1 TO DESPREZADOS-SINISMES */
                DESPREZADOS_SINISMES.Value = DESPREZADOS_SINISMES + 1;

                /*" -1011- END-IF. */
            }


            /*" -1012- PERFORM R2000-00-PROCESSA-SINISHIS UNTIL WFIM-SINISHIS1 EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SINISHIS1 == "S"))
            {

                R2000_00_PROCESSA_SINISHIS_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1016- PERFORM R0910-00-FETCH-CURSOR. */

            R0910_00_FETCH_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-SINISMES-SECTION */
        private void R1100_00_SELECT_SINISMES_SECTION()
        {
            /*" -1030- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -1032- MOVE 'S' TO WTEM-SINISMES. */
            _.Move("S", AREA_DE_WORK.WTEM_SINISMES);

            /*" -1045- PERFORM R1100_00_SELECT_SINISMES_DB_SELECT_1 */

            R1100_00_SELECT_SINISMES_DB_SELECT_1();

            /*" -1048- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1049- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1050- MOVE 'N' TO WTEM-SINISMES */
                    _.Move("N", AREA_DE_WORK.WTEM_SINISMES);

                    /*" -1051- ELSE */
                }
                else
                {


                    /*" -1052- DISPLAY 'PROBLEMAS NA R1100-00-SELECT-SINISMES' */
                    _.Display($"PROBLEMAS NA R1100-00-SELECT-SINISMES");

                    /*" -1053- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1054- END-IF */
                }


                /*" -1054- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-SINISMES-DB-SELECT-1 */
        public void R1100_00_SELECT_SINISMES_DB_SELECT_1()
        {
            /*" -1045- EXEC SQL SELECT NUM_CERTIFICADO, NUM_APOLICE INTO :SINISMES-NUM-CERTIFICADO, :SINISMES-NUM-APOLICE FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r1100_00_SELECT_SINISMES_DB_SELECT_1_Query1 = new R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
                _.Move(executed_1.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-SEGURVGA-SECTION */
        private void R1200_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -1067- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -1069- MOVE 'S' TO WTEM-SEGURVGA. */
            _.Move("S", AREA_DE_WORK.WTEM_SEGURVGA);

            /*" -1086- PERFORM R1200_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R1200_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -1089- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1090- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1091- MOVE 'N' TO WTEM-SEGURVGA */
                    _.Move("N", AREA_DE_WORK.WTEM_SEGURVGA);

                    /*" -1092- ELSE */
                }
                else
                {


                    /*" -1093- DISPLAY 'PROBLEMAS NA R1200-00-SELECT-SEGURVGA' */
                    _.Display($"PROBLEMAS NA R1200-00-SELECT-SEGURVGA");

                    /*" -1094- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1095- END-IF */
                }


                /*" -1095- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R1200_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -1086- EXEC SQL SELECT NUM_CERTIFICADO, NUM_APOLICE , COD_CLIENTE , COD_SUBGRUPO INTO :SEGURVGA-NUM-CERTIFICADO, :SEGURVGA-NUM-APOLICE , :SEGURVGA-COD-CLIENTE , :SEGURVGA-COD-SUBGRUPO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 = new R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_CERTIFICADO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(executed_1.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-SELECT-BILHETE-SECTION */
        private void R1250_00_SELECT_BILHETE_SECTION()
        {
            /*" -1108- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", WABEND.WNR_EXEC_SQL);

            /*" -1110- MOVE 'S' TO WTEM-BILHETE. */
            _.Move("S", AREA_DE_WORK.WTEM_BILHETE);

            /*" -1120- PERFORM R1250_00_SELECT_BILHETE_DB_SELECT_1 */

            R1250_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -1123- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1124- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1125- MOVE 'N' TO WTEM-BILHETE */
                    _.Move("N", AREA_DE_WORK.WTEM_BILHETE);

                    /*" -1126- ELSE */
                }
                else
                {


                    /*" -1127- DISPLAY 'PROBLEMAS NA R1250-00-SELECT-BILHETE' */
                    _.Display($"PROBLEMAS NA R1250-00-SELECT-BILHETE");

                    /*" -1128- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1129- END-IF */
                }


                /*" -1129- END-IF. */
            }


        }

        [StopWatch]
        /*" R1250-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R1250_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -1120- EXEC SQL SELECT COD_CLIENTE INTO :BILHETE-COD-CLIENTE FROM SEGUROS.BILHETE WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE END-EXEC. */

            var r1250_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R1250_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOLICE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1250_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r1250_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_COD_CLIENTE, BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-CLIENTES-SECTION */
        private void R1300_00_SELECT_CLIENTES_SECTION()
        {
            /*" -1143- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -1145- MOVE 'S' TO WTEM-CLIENTES. */
            _.Move("S", AREA_DE_WORK.WTEM_CLIENTES);

            /*" -1158- PERFORM R1300_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1300_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -1161- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1162- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1163- MOVE 'N' TO WTEM-CLIENTES */
                    _.Move("N", AREA_DE_WORK.WTEM_CLIENTES);

                    /*" -1164- ELSE */
                }
                else
                {


                    /*" -1165- DISPLAY 'PROBLEMAS NA R1300-00-SELECT-CLIENTES' */
                    _.Display($"PROBLEMAS NA R1300-00-SELECT-CLIENTES");

                    /*" -1166- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1167- END-IF */
                }


                /*" -1167- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1300_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -1158- EXEC SQL SELECT NOME_RAZAO , CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE END-EXEC. */

            var r1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-SINISHIS-SECTION */
        private void R1400_00_SELECT_SINISHIS_SECTION()
        {
            /*" -1181- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -1183- MOVE 'S' TO WTEM-SINISHIS */
            _.Move("S", AREA_DE_WORK.WTEM_SINISHIS);

            /*" -1193- PERFORM R1400_00_SELECT_SINISHIS_DB_SELECT_1 */

            R1400_00_SELECT_SINISHIS_DB_SELECT_1();

            /*" -1196- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1197- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1198- MOVE 'N' TO WTEM-SINISHIS */
                    _.Move("N", AREA_DE_WORK.WTEM_SINISHIS);

                    /*" -1199- ELSE */
                }
                else
                {


                    /*" -1200- DISPLAY 'PROBLEMAS NA R1400-00-SELECT-SINIHIS' */
                    _.Display($"PROBLEMAS NA R1400-00-SELECT-SINIHIS");

                    /*" -1201- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1202- END-IF */
                }


                /*" -1202- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-SINISHIS-DB-SELECT-1 */
        public void R1400_00_SELECT_SINISHIS_DB_SELECT_1()
        {
            /*" -1193- EXEC SQL SELECT VAL_OPERACAO AS VAL_AVISADO INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO = 101 END-EXEC. */

            var r1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1 = new R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-MAX-OCORR-SECTION */
        private void R1500_00_SELECT_MAX_OCORR_SECTION()
        {
            /*" -1216- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -1218- MOVE 'S' TO WTEM-SINISTRO. */
            _.Move("S", AREA_DE_WORK.WTEM_SINISTRO);

            /*" -1224- PERFORM R1500_00_SELECT_MAX_OCORR_DB_SELECT_1 */

            R1500_00_SELECT_MAX_OCORR_DB_SELECT_1();

            /*" -1227- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1228- DISPLAY 'PROBLEMAS NA R1500-00-SELECT-MAX-OCORR' */
                _.Display($"PROBLEMAS NA R1500-00-SELECT-MAX-OCORR");

                /*" -1229- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1231- END-IF. */
            }


            /*" -1232- MOVE WHOST-MAX-OCORR TO SINISHIS-OCORR-HISTORICO. */
            _.Move(WHOST_MAX_OCORR, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

        }

        [StopWatch]
        /*" R1500-00-SELECT-MAX-OCORR-DB-SELECT-1 */
        public void R1500_00_SELECT_MAX_OCORR_DB_SELECT_1()
        {
            /*" -1224- EXEC SQL SELECT MAX(OCORR_HISTORICO) INTO :WHOST-MAX-OCORR FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1 = new R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_MAX_OCORR, WHOST_MAX_OCORR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-SI175-SECTION */
        private void R1600_00_SELECT_SI175_SECTION()
        {
            /*" -1246- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -1248- MOVE 'S' TO WTEM-VARIAVEL. */
            _.Move("S", AREA_DE_WORK.WTEM_VARIAVEL);

            /*" -1268- PERFORM R1600_00_SELECT_SI175_DB_SELECT_1 */

            R1600_00_SELECT_SI175_DB_SELECT_1();

            /*" -1271- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1272- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1273- MOVE 'N' TO WTEM-VARIAVEL */
                    _.Move("N", AREA_DE_WORK.WTEM_VARIAVEL);

                    /*" -1274- MOVE ZEROS TO SI175-NUM-OCORR-MOVTO */
                    _.Move(0, SI175.DCLSI_PESS_SINISTRO.SI175_NUM_OCORR_MOVTO);

                    /*" -1275- ELSE */
                }
                else
                {


                    /*" -1276- DISPLAY 'PROBLEMAS NA R1600-00-SELECT-SI175' */
                    _.Display($"PROBLEMAS NA R1600-00-SELECT-SI175");

                    /*" -1277- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1278- END-IF */
                }


                /*" -1280- END-IF. */
            }


            /*" -1281- MOVE SI175-NUM-OCORR-MOVTO TO WHOST-NUM-OCORR-MOVTO. */
            _.Move(SI175.DCLSI_PESS_SINISTRO.SI175_NUM_OCORR_MOVTO, WHOST_NUM_OCORR_MOVTO);

        }

        [StopWatch]
        /*" R1600-00-SELECT-SI175-DB-SELECT-1 */
        public void R1600_00_SELECT_SI175_DB_SELECT_1()
        {
            /*" -1268- EXEC SQL SELECT NUM_APOL_SINISTRO , OCORR_HISTORICO , COD_OPERACAO , NUM_OCORR_MOVTO INTO :SI175-NUM-APOL-SINISTRO , :SI175-OCORR-HISTORICO , :SI175-COD-OPERACAO , :SI175-NUM-OCORR-MOVTO FROM SEGUROS.SI_PESS_SINISTRO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO IN (1181,1182,1183,1184,1004,1001,1002) END-EXEC. */

            var r1600_00_SELECT_SI175_DB_SELECT_1_Query1 = new R1600_00_SELECT_SI175_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R1600_00_SELECT_SI175_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_SI175_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SI175_NUM_APOL_SINISTRO, SI175.DCLSI_PESS_SINISTRO.SI175_NUM_APOL_SINISTRO);
                _.Move(executed_1.SI175_OCORR_HISTORICO, SI175.DCLSI_PESS_SINISTRO.SI175_OCORR_HISTORICO);
                _.Move(executed_1.SI175_COD_OPERACAO, SI175.DCLSI_PESS_SINISTRO.SI175_COD_OPERACAO);
                _.Move(executed_1.SI175_NUM_OCORR_MOVTO, SI175.DCLSI_PESS_SINISTRO.SI175_NUM_OCORR_MOVTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-SELECT-GE368-SECTION */
        private void R1700_00_SELECT_GE368_SECTION()
        {
            /*" -1295- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", WABEND.WNR_EXEC_SQL);

            /*" -1297- MOVE 'S' TO WTEM-VARIAVEL. */
            _.Move("S", AREA_DE_WORK.WTEM_VARIAVEL);

            /*" -1307- PERFORM R1700_00_SELECT_GE368_DB_SELECT_1 */

            R1700_00_SELECT_GE368_DB_SELECT_1();

            /*" -1310- IF SQLCODE NOT EQUAL ZEROS AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -1311- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1312- MOVE 'N' TO WTEM-VARIAVEL */
                    _.Move("N", AREA_DE_WORK.WTEM_VARIAVEL);

                    /*" -1314- MOVE ZEROS TO GE368-NUM-PESSOA GE368-SEQ-ENTIDADE */
                    _.Move(0, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA, GE368.DCLGE_LEG_PESS_EVENTO.GE368_SEQ_ENTIDADE);

                    /*" -1315- ELSE */
                }
                else
                {


                    /*" -1316- DISPLAY 'PROBLEMAS NA R1700-00-SELECT-GE368' */
                    _.Display($"PROBLEMAS NA R1700-00-SELECT-GE368");

                    /*" -1317- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1317- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-GE368-DB-SELECT-1 */
        public void R1700_00_SELECT_GE368_DB_SELECT_1()
        {
            /*" -1307- EXEC SQL SELECT IND_ENTIDADE , NUM_PESSOA , SEQ_ENTIDADE INTO :GE368-IND-ENTIDADE , :GE368-NUM-PESSOA , :GE368-SEQ-ENTIDADE FROM SEGUROS.GE_LEG_PESS_EVENTO WHERE NUM_OCORR_MOVTO = :WHOST-NUM-OCORR-MOVTO END-EXEC. */

            var r1700_00_SELECT_GE368_DB_SELECT_1_Query1 = new R1700_00_SELECT_GE368_DB_SELECT_1_Query1()
            {
                WHOST_NUM_OCORR_MOVTO = WHOST_NUM_OCORR_MOVTO.ToString(),
            };

            var executed_1 = R1700_00_SELECT_GE368_DB_SELECT_1_Query1.Execute(r1700_00_SELECT_GE368_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE368_IND_ENTIDADE, GE368.DCLGE_LEG_PESS_EVENTO.GE368_IND_ENTIDADE);
                _.Move(executed_1.GE368_NUM_PESSOA, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA);
                _.Move(executed_1.GE368_SEQ_ENTIDADE, GE368.DCLGE_LEG_PESS_EVENTO.GE368_SEQ_ENTIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-OD009-SECTION */
        private void R1800_00_SELECT_OD009_SECTION()
        {
            /*" -1331- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", WABEND.WNR_EXEC_SQL);

            /*" -1333- MOVE 'S' TO WTEM-VARIAVEL. */
            _.Move("S", AREA_DE_WORK.WTEM_VARIAVEL);

            /*" -1346- PERFORM R1800_00_SELECT_OD009_DB_SELECT_1 */

            R1800_00_SELECT_OD009_DB_SELECT_1();

            /*" -1349- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1350- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1354- MOVE ZEROS TO OD009-COD-BANCO OD009-COD-AGENCIA OD009-NUM-OPERACAO-CONTA OD009-NUM-CONTA */
                    _.Move(0, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA);

                    /*" -1355- MOVE 'N' TO WTEM-VARIAVEL */
                    _.Move("N", AREA_DE_WORK.WTEM_VARIAVEL);

                    /*" -1356- ELSE */
                }
                else
                {


                    /*" -1357- DISPLAY 'PROBLEMAS NA R1800-00-SELECT-OD009' */
                    _.Display($"PROBLEMAS NA R1800-00-SELECT-OD009");

                    /*" -1358- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1359- END-IF */
                }


                /*" -1359- END-IF. */
            }


        }

        [StopWatch]
        /*" R1800-00-SELECT-OD009-DB-SELECT-1 */
        public void R1800_00_SELECT_OD009_DB_SELECT_1()
        {
            /*" -1346- EXEC SQL SELECT COD_BANCO , COD_AGENCIA , NUM_OPERACAO_CONTA , NUM_CONTA INTO :OD009-COD-BANCO , :OD009-COD-AGENCIA , :OD009-NUM-OPERACAO-CONTA, :OD009-NUM-CONTA FROM ODS.OD_PESS_CONTA_BANC WHERE NUM_PESSOA = :GE368-NUM-PESSOA AND SEQ_CONTA_BANCARIA = :GE368-SEQ-ENTIDADE END-EXEC. */

            var r1800_00_SELECT_OD009_DB_SELECT_1_Query1 = new R1800_00_SELECT_OD009_DB_SELECT_1_Query1()
            {
                GE368_SEQ_ENTIDADE = GE368.DCLGE_LEG_PESS_EVENTO.GE368_SEQ_ENTIDADE.ToString(),
                GE368_NUM_PESSOA = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA.ToString(),
            };

            var executed_1 = R1800_00_SELECT_OD009_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_OD009_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD009_COD_BANCO, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO);
                _.Move(executed_1.OD009_COD_AGENCIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA);
                _.Move(executed_1.OD009_NUM_OPERACAO_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA);
                _.Move(executed_1.OD009_NUM_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1850-00-SELECT-PRODUVG-SECTION */
        private void R1850_00_SELECT_PRODUVG_SECTION()
        {
            /*" -1373- MOVE '1850' TO WNR-EXEC-SQL. */
            _.Move("1850", WABEND.WNR_EXEC_SQL);

            /*" -1375- MOVE 'S' TO WTEM-PRODUVG. */
            _.Move("S", AREA_DE_WORK.WTEM_PRODUVG);

            /*" -1388- PERFORM R1850_00_SELECT_PRODUVG_DB_SELECT_1 */

            R1850_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -1391- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1392- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1405- PERFORM R1850_00_SELECT_PRODUVG_DB_SELECT_2 */

                    R1850_00_SELECT_PRODUVG_DB_SELECT_2();

                    /*" -1408- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1409- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -1410- MOVE 'N' TO WTEM-PRODUVG */
                            _.Move("N", AREA_DE_WORK.WTEM_PRODUVG);

                            /*" -1411- ELSE */
                        }
                        else
                        {


                            /*" -1412- DISPLAY 'PROBLEMAS NA R1850-00-SELECT-PRODUTO' */
                            _.Display($"PROBLEMAS NA R1850-00-SELECT-PRODUTO");

                            /*" -1413- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1414- END-IF */
                        }


                        /*" -1416- END-IF */
                    }


                    /*" -1417- ELSE */
                }
                else
                {


                    /*" -1418- DISPLAY 'PROBLEMAS NA R1850-00-SELECT-PRODUTO' */
                    _.Display($"PROBLEMAS NA R1850-00-SELECT-PRODUTO");

                    /*" -1419- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1420- END-IF */
                }


                /*" -1420- END-IF. */
            }


        }

        [StopWatch]
        /*" R1850-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R1850_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -1388- EXEC SQL SELECT COD_PRODUTO , NOME_PRODUTO INTO :PRODUVG-COD-PRODUTO, :PRODUVG-NOME-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

            var r1850_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R1850_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1850_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r1850_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1850_99_SAIDA*/

        [StopWatch]
        /*" R1850-00-SELECT-PRODUVG-DB-SELECT-2 */
        public void R1850_00_SELECT_PRODUVG_DB_SELECT_2()
        {
            /*" -1405- EXEC SQL SELECT T2.COD_PRODUTO, T2.DESCR_PRODUTO INTO :PRODUVG-COD-PRODUTO, :PRODUVG-NOME-PRODUTO FROM SEGUROS.APOLICES T1, SEGUROS.PRODUTO T2 WHERE T1.NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND T1.COD_PRODUTO = T2.COD_PRODUTO END-EXEC */

            var r1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1 = new R1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1.Execute(r1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
            }


        }

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-SECTION */
        private void R1900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -1434- MOVE '1900' TO WNR-EXEC-SQL. */
            _.Move("1900", WABEND.WNR_EXEC_SQL);

            /*" -1451- PERFORM R1900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R1900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -1453- PERFORM R1900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R1900_00_DECLARE_CURSOR_DB_OPEN_1();

            /*" -1456- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1457- DISPLAY 'PROBLEMA NO CURSOR SINISHIS1 ' */
                _.Display($"PROBLEMA NO CURSOR SINISHIS1 ");

                /*" -1458- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1458- END-IF. */
            }


        }

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-DB-OPEN-1 */
        public void R1900_00_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -1453- EXEC SQL OPEN SINISHIS1 END-EXEC. */

            SINISHIS1.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-SECTION */
        private void R1910_00_FETCH_CURSOR_SECTION()
        {
            /*" -1472- MOVE '1910' TO WNR-EXEC-SQL. */
            _.Move("1910", WABEND.WNR_EXEC_SQL);

            /*" -1478- PERFORM R1910_00_FETCH_CURSOR_DB_FETCH_1 */

            R1910_00_FETCH_CURSOR_DB_FETCH_1();

            /*" -1481- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1482- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1482- PERFORM R1910_00_FETCH_CURSOR_DB_CLOSE_1 */

                    R1910_00_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -1484- MOVE 'S' TO WFIM-SINISHIS1 */
                    _.Move("S", AREA_DE_WORK.WFIM_SINISHIS1);

                    /*" -1485- GO TO R1910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1486- ELSE */
                }
                else
                {


                    /*" -1487- DISPLAY ' PROBLEMAS NO FETCH DA SINISHIS1' */
                    _.Display($" PROBLEMAS NO FETCH DA SINISHIS1");

                    /*" -1488- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1489- END-IF */
                }


                /*" -1491- END-IF. */
            }


            /*" -1491- ADD 1 TO AC-LIDOS. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-DB-FETCH-1 */
        public void R1910_00_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -1478- EXEC SQL FETCH SINISHIS1 INTO :SINISHIS-COD-OPERACAO , :SINISHIS-VAL-OPERACAO , :SINISHIS-NOME-FAVORECIDO , :SINISHIS-OCORR-HISTORICO END-EXEC. */

            if (SINISHIS1.Fetch())
            {
                _.Move(SINISHIS1.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(SINISHIS1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(SINISHIS1.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(SINISHIS1.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
            }

        }

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-DB-CLOSE-1 */
        public void R1910_00_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -1482- EXEC SQL CLOSE SINISHIS1 END-EXEC */

            SINISHIS1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-SINISHIS-SECTION */
        private void R2000_00_PROCESSA_SINISHIS_SECTION()
        {
            /*" -1505- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -1509- MOVE SINISHIS-VAL-OPERACAO TO LD02-VAL-OPER WHOST-VAL-OPER. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD02.LD02_VAL_OPER, WHOST_VAL_OPER);

            /*" -1512- MOVE SINISHIS-NOME-FAVORECIDO TO LD02-NOME-BENEFICIARIO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, LD02.LD02_NOME_BENEFICIARIO);

            /*" -1514- PERFORM R2050-00-SELECT-OD002 */

            R2050_00_SELECT_OD002_SECTION();

            /*" -1516- MOVE OD002-NUM-CPF TO LD02-CPF1-BENEFICIARIO. */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF, LD02.LD02_CPF1_BENEFICIARIO);

            /*" -1519- MOVE OD002-NUM-DV-CPF TO LD02-CPF2-BENEFICIARIO. */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF, LD02.LD02_CPF2_BENEFICIARIO);

            /*" -1521- PERFORM R2100-00-SELECT-SINISHIS. */

            R2100_00_SELECT_SINISHIS_SECTION();

            /*" -1525- MOVE SINISHIS-VAL-OPERACAO TO LD02-VAL-TOT-PRE-LIB WHOST-VAL-PRE-LIB. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD02.LD02_VAL_TOT_PRE_LIB, WHOST_VAL_PRE_LIB);

            /*" -1528- MOVE ZEROS TO SINISHIS-VAL-OPERACAO. */
            _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

            /*" -1530- PERFORM R2200-00-SELECT-SINISHIS. */

            R2200_00_SELECT_SINISHIS_SECTION();

            /*" -1534- MOVE SINISHIS-VAL-OPERACAO TO LD02-VAL-ATU-MON WHOST-VAL-ATU-MON. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD02.LD02_VAL_ATU_MON, WHOST_VAL_ATU_MON);

            /*" -1536- PERFORM R2300-00-SELECT-SINISHIS. */

            R2300_00_SELECT_SINISHIS_SECTION();

            /*" -1540- MOVE SINISHIS-VAL-OPERACAO TO LD02-VAL-JUROS WHOST-VAL-JUROS. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD02.LD02_VAL_JUROS, WHOST_VAL_JUROS);

            /*" -1544- MOVE ZEROS TO LD02-VAL-PAG-COMP WHOST-VAL-PAG-COMP. */
            _.Move(0, LD02.LD02_VAL_PAG_COMP, WHOST_VAL_PAG_COMP);

            /*" -1545- IF SINISHIS-COD-OPERACAO EQUAL 1184 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 1184)
            {

                /*" -1547- PERFORM R2500-00-SELECT-SINISHIS. */

                R2500_00_SELECT_SINISHIS_SECTION();
            }


            /*" -1552- MOVE SINISHIS-VAL-OPERACAO TO LD02-VAL-PAG-COMP WHOST-VAL-PAG-COMP. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD02.LD02_VAL_PAG_COMP, WHOST_VAL_PAG_COMP);

            /*" -1554- PERFORM R2600-00-SELECT-GE369. */

            R2600_00_SELECT_GE369_SECTION();

            /*" -1556- MOVE OD009-COD-BANCO TO LD02-BANCO */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO, LD02.LD02_BANCO);

            /*" -1558- MOVE OD009-COD-AGENCIA TO LD02-AGENCIA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA, LD02.LD02_AGENCIA);

            /*" -1560- MOVE OD009-NUM-CONTA TO LD02-CONTA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA, LD02.LD02_CONTA);

            /*" -1563- MOVE OD009-NUM-OPERACAO-CONTA TO LD02-OPERACAO */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA, LD02.LD02_OPERACAO);

            /*" -1565- PERFORM R2400-00-PROCESSA-TOTAIS. */

            R2400_00_PROCESSA_TOTAIS_SECTION();

            /*" -1567- WRITE REG-SAIDA FROM LD02. */
            _.Move(LD02.GetMoveValues(), REG_SAIDA);

            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -1570- MOVE SINISHIS-NUM-APOL-SINISTRO TO LD02-NUM-APOL-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, LD02.LD02_NUM_APOL_SINISTRO);

            /*" -1570- ADD 1 TO AC-GRAVADOS. */
            AREA_DE_WORK.AC_GRAVADOS.Value = AREA_DE_WORK.AC_GRAVADOS + 1;

            /*" -0- FLUXCONTROL_PERFORM R2000_10_NEXT */

            R2000_10_NEXT();

        }

        [StopWatch]
        /*" R2000-10-NEXT */
        private void R2000_10_NEXT(bool isPerform = false)
        {
            /*" -1574- PERFORM R1910-00-FETCH-CURSOR. */

            R1910_00_FETCH_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2050-00-SELECT-OD002-SECTION */
        private void R2050_00_SELECT_OD002_SECTION()
        {
            /*" -1588- MOVE '2050' TO WNR-EXEC-SQL. */
            _.Move("2050", WABEND.WNR_EXEC_SQL);

            /*" -1602- PERFORM R2050_00_SELECT_OD002_DB_SELECT_1 */

            R2050_00_SELECT_OD002_DB_SELECT_1();

            /*" -1605- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1606- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1607- MOVE ZEROS TO OD002-NUM-CPF */
                    _.Move(0, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF);

                    /*" -1608- MOVE ZEROS TO OD002-NUM-DV-CPF */
                    _.Move(0, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF);

                    /*" -1609- ELSE */
                }
                else
                {


                    /*" -1610- DISPLAY 'PROBLEMAS NO ACESSO A OD-PESSOA_FISICA - 2050' */
                    _.Display($"PROBLEMAS NO ACESSO A OD-PESSOA_FISICA - 2050");

                    /*" -1611- DISPLAY 'APOLICE:' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"APOLICE:{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -1612- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1613- END-IF */
                }


                /*" -1613- END-IF. */
            }


        }

        [StopWatch]
        /*" R2050-00-SELECT-OD002-DB-SELECT-1 */
        public void R2050_00_SELECT_OD002_DB_SELECT_1()
        {
            /*" -1602- EXEC SQL SELECT A.NUM_CPF, A.NUM_DV_CPF INTO :OD002-NUM-CPF :OD002-NUM-DV-CPF FROM ODS.OD_PESSOA_FISICA A, SEGUROS.SI_PESS_SINISTRO B, SEGUROS.GE_LEG_PESS_EVENTO C WHERE B.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND B.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND B.NUM_OCORR_MOVTO = C.NUM_OCORR_MOVTO AND C.NUM_PESSOA = A.NUM_PESSOA FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r2050_00_SELECT_OD002_DB_SELECT_1_Query1 = new R2050_00_SELECT_OD002_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R2050_00_SELECT_OD002_DB_SELECT_1_Query1.Execute(r2050_00_SELECT_OD002_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD002_NUM_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF);
                _.Move(executed_1.OD002_NUM_DV_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-SINISHIS-SECTION */
        private void R2100_00_SELECT_SINISHIS_SECTION()
        {
            /*" -1627- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -1643- PERFORM R2100_00_SELECT_SINISHIS_DB_SELECT_1 */

            R2100_00_SELECT_SINISHIS_DB_SELECT_1();

            /*" -1646- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1647- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1647- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-SINISHIS-DB-SELECT-1 */
        public void R2100_00_SELECT_SINISHIS_DB_SELECT_1()
        {
            /*" -1643- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) AS VAL_TOT_PRE_LIB INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND A.COD_OPERACAO IN (1181, 1182, 1183, 1184) AND NOT EXISTS ( SELECT NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO B WHERE B.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO AND B.COD_OPERACAO = A.COD_OPERACAO + 10 AND B.OCORR_HISTORICO = A.OCORR_HISTORICO) END-EXEC. */

            var r2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1 = new R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-SINISHIS-SECTION */
        private void R2200_00_SELECT_SINISHIS_SECTION()
        {
            /*" -1661- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -1680- PERFORM R2200_00_SELECT_SINISHIS_DB_SELECT_1 */

            R2200_00_SELECT_SINISHIS_DB_SELECT_1();

            /*" -1683- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1684- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1685- MOVE ZEROS TO SINISHIS-VAL-OPERACAO */
                    _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                    /*" -1686- ELSE */
                }
                else
                {


                    /*" -1687- DISPLAY 'PROBLEMAS NO ACESSO A SINISHIS - 2200' */
                    _.Display($"PROBLEMAS NO ACESSO A SINISHIS - 2200");

                    /*" -1688- DISPLAY 'APOLICE:' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"APOLICE:{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -1689- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1690- END-IF */
                }


                /*" -1690- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-SINISHIS-DB-SELECT-1 */
        public void R2200_00_SELECT_SINISHIS_DB_SELECT_1()
        {
            /*" -1680- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) AS VAL_ATU_MONET INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO A WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO = 1201 AND NOME_FAVORECIDO = :SINISHIS-NOME-FAVORECIDO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND NOT EXISTS ( SELECT NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO B WHERE B.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO AND B.COD_OPERACAO = A.COD_OPERACAO + 10 AND B.OCORR_HISTORICO = A.OCORR_HISTORICO) END-EXEC. */

            var r2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1 = new R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_NOME_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-SINISHIS-SECTION */
        private void R2300_00_SELECT_SINISHIS_SECTION()
        {
            /*" -1704- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -1723- PERFORM R2300_00_SELECT_SINISHIS_DB_SELECT_1 */

            R2300_00_SELECT_SINISHIS_DB_SELECT_1();

            /*" -1726- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1727- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1728- MOVE ZEROS TO SINISHIS-VAL-OPERACAO */
                    _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                    /*" -1729- ELSE */
                }
                else
                {


                    /*" -1730- DISPLAY 'PROBLEMAS NO ACESSO A SINISHIS - 2300' */
                    _.Display($"PROBLEMAS NO ACESSO A SINISHIS - 2300");

                    /*" -1731- DISPLAY 'APOLICE:' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"APOLICE:{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -1732- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1733- END-IF */
                }


                /*" -1733- END-IF. */
            }


        }

        [StopWatch]
        /*" R2300-00-SELECT-SINISHIS-DB-SELECT-1 */
        public void R2300_00_SELECT_SINISHIS_DB_SELECT_1()
        {
            /*" -1723- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) AS VAL_JUROS INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO A WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO = 1202 AND NOME_FAVORECIDO = :SINISHIS-NOME-FAVORECIDO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND NOT EXISTS ( SELECT NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO B WHERE B.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO AND B.COD_OPERACAO = A.COD_OPERACAO + 10 AND B.OCORR_HISTORICO = A.OCORR_HISTORICO) END-EXEC. */

            var r2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1 = new R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_NOME_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1.Execute(r2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-PROCESSA-TOTAIS-SECTION */
        private void R2400_00_PROCESSA_TOTAIS_SECTION()
        {
            /*" -1747- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WABEND.WNR_EXEC_SQL);

            /*" -1751- IF WHOST-NUM-APOL-SIN-ANT NOT EQUAL SPACES AND WHOST-NUM-APOL-SIN-ANT EQUAL LD02-NUM-APOL-SINISTRO AND WFIM-SINISHIS NOT EQUAL 'S' */

            if (!WHOST_NUM_APOL_SIN_ANT.IsEmpty() && WHOST_NUM_APOL_SIN_ANT == LD02.LD02_NUM_APOL_SINISTRO && AREA_DE_WORK.WFIM_SINISHIS != "S")
            {

                /*" -1757- MOVE SPACES TO LD02-NUM-APOL-SINISTRO LD02-NOME-RAZAO LD02-CGCCPF-CNPJ LD02-COD-PRODUTO LD02-NOME-PRODUTO */
                _.Move("", LD02.LD02_NUM_APOL_SINISTRO, LD02.LD02_NOME_RAZAO, LD02.LD02_CGCCPF_CNPJ, LD02.LD02_COD_PRODUTO, LD02.LD02_NOME_PRODUTO);

                /*" -1762- MOVE ZEROS TO WHOST-VAL-PRE-LIB WHOST-VAL-AVISADO LD02-VAL-AVISADO LD02-VAL-TOT-PRE-LIB */
                _.Move(0, WHOST_VAL_PRE_LIB, WHOST_VAL_AVISADO, LD02.LD02_VAL_AVISADO, LD02.LD02_VAL_TOT_PRE_LIB);

                /*" -1763- ELSE */
            }
            else
            {


                /*" -1765- IF WHOST-NUM-APOL-SIN-ANT NOT EQUAL SPACES */

                if (!WHOST_NUM_APOL_SIN_ANT.IsEmpty())
                {

                    /*" -1767- MOVE 'SUB-TOTAL' TO LD03-TIPO-TOTAL */
                    _.Move("SUB-TOTAL", LD03.LD03_TIPO_TOTAL);

                    /*" -1769- MOVE WHOST-VAL-OPER-SUB TO LD03-VAL-OPER */
                    _.Move(WHOST_VAL_OPER_SUB, LD03.LD03_VAL_OPER);

                    /*" -1771- MOVE WHOST-VAL-ATU-MON-SUB TO LD03-VAL-ATU-MON */
                    _.Move(WHOST_VAL_ATU_MON_SUB, LD03.LD03_VAL_ATU_MON);

                    /*" -1773- MOVE WHOST-VAL-JUROS-SUB TO LD03-VAL-JUROS */
                    _.Move(WHOST_VAL_JUROS_SUB, LD03.LD03_VAL_JUROS);

                    /*" -1775- MOVE WHOST-VAL-PAG-COMP-SUB TO LD03-VAL-PAG-COMP */
                    _.Move(WHOST_VAL_PAG_COMP_SUB, LD03.LD03_VAL_PAG_COMP);

                    /*" -1777- MOVE WHOST-VAL-TOT-PRE-LIB-ANT TO LD03-VAL-TOT-PRE-LIB */
                    _.Move(WHOST_VAL_TOT_PRE_LIB_ANT, LD03.LD03_VAL_TOT_PRE_LIB);

                    /*" -1780- MOVE WHOST-VAL-AVISADO-ANT TO LD03-VAL-AVISADO */
                    _.Move(WHOST_VAL_AVISADO_ANT, LD03.LD03_VAL_AVISADO);

                    /*" -1781- WRITE REG-SAIDA FROM LD03 */
                    _.Move(LD03.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -1783- WRITE REG-SAIDA FROM LD04 */
                    _.Move(LD04.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -1791- MOVE ZEROS TO WHOST-VAL-OPER-SUB WHOST-VAL-ATU-MON-SUB WHOST-VAL-JUROS-SUB WHOST-VAL-PAG-COMP-SUB WHOST-VAL-TOT-PRE-LIB-ANT WHOST-VAL-AVISADO-ANT */
                    _.Move(0, WHOST_VAL_OPER_SUB, WHOST_VAL_ATU_MON_SUB, WHOST_VAL_JUROS_SUB, WHOST_VAL_PAG_COMP_SUB, WHOST_VAL_TOT_PRE_LIB_ANT, WHOST_VAL_AVISADO_ANT);

                    /*" -1793- END-IF */
                }


                /*" -1795- MOVE LD02-NUM-APOL-SINISTRO TO WHOST-NUM-APOL-SIN-ANT */
                _.Move(LD02.LD02_NUM_APOL_SINISTRO, WHOST_NUM_APOL_SIN_ANT);

                /*" -1797- MOVE LD02-VAL-TOT-PRE-LIB TO WHOST-VAL-TOT-PRE-LIB-ANT */
                _.Move(LD02.LD02_VAL_TOT_PRE_LIB, WHOST_VAL_TOT_PRE_LIB_ANT);

                /*" -1799- MOVE LD02-VAL-AVISADO TO WHOST-VAL-AVISADO-ANT */
                _.Move(LD02.LD02_VAL_AVISADO, WHOST_VAL_AVISADO_ANT);

                /*" -1801- END-IF. */
            }


            /*" -1802- IF WFIM-SINISHIS EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SINISHIS == "S")
            {

                /*" -1804- MOVE 'TOTAIS' TO LD03-TIPO-TOTAL */
                _.Move("TOTAIS", LD03.LD03_TIPO_TOTAL);

                /*" -1806- MOVE WHOST-VAL-OPER-TOT TO LD03-VAL-OPER */
                _.Move(WHOST_VAL_OPER_TOT, LD03.LD03_VAL_OPER);

                /*" -1808- MOVE WHOST-VAL-ATU-MON-TOT TO LD03-VAL-ATU-MON */
                _.Move(WHOST_VAL_ATU_MON_TOT, LD03.LD03_VAL_ATU_MON);

                /*" -1810- MOVE WHOST-VAL-JUROS-TOT TO LD03-VAL-JUROS */
                _.Move(WHOST_VAL_JUROS_TOT, LD03.LD03_VAL_JUROS);

                /*" -1812- MOVE WHOST-VAL-PAG-COMP-TOT TO LD03-VAL-PAG-COMP */
                _.Move(WHOST_VAL_PAG_COMP_TOT, LD03.LD03_VAL_PAG_COMP);

                /*" -1814- MOVE WHOST-VAL-PRE-LIB-TOT TO LD03-VAL-TOT-PRE-LIB */
                _.Move(WHOST_VAL_PRE_LIB_TOT, LD03.LD03_VAL_TOT_PRE_LIB);

                /*" -1817- MOVE WHOST-VAL-AVISADO-TOT TO LD03-VAL-AVISADO */
                _.Move(WHOST_VAL_AVISADO_TOT, LD03.LD03_VAL_AVISADO);

                /*" -1818- WRITE REG-SAIDA FROM LD03 */
                _.Move(LD03.GetMoveValues(), REG_SAIDA);

                ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                /*" -1819- ELSE */
            }
            else
            {


                /*" -1822- COMPUTE WHOST-VAL-AVISADO-TOT = WHOST-VAL-AVISADO-TOT + WHOST-VAL-AVISADO */
                WHOST_VAL_AVISADO_TOT.Value = WHOST_VAL_AVISADO_TOT + WHOST_VAL_AVISADO;

                /*" -1825- COMPUTE WHOST-VAL-PRE-LIB-TOT = WHOST-VAL-PRE-LIB-TOT + WHOST-VAL-PRE-LIB */
                WHOST_VAL_PRE_LIB_TOT.Value = WHOST_VAL_PRE_LIB_TOT + WHOST_VAL_PRE_LIB;

                /*" -1828- COMPUTE WHOST-VAL-OPER-SUB = WHOST-VAL-OPER-SUB + WHOST-VAL-OPER */
                WHOST_VAL_OPER_SUB.Value = WHOST_VAL_OPER_SUB + WHOST_VAL_OPER;

                /*" -1831- COMPUTE WHOST-VAL-OPER-TOT = WHOST-VAL-OPER-TOT + WHOST-VAL-OPER */
                WHOST_VAL_OPER_TOT.Value = WHOST_VAL_OPER_TOT + WHOST_VAL_OPER;

                /*" -1834- COMPUTE WHOST-VAL-ATU-MON-SUB = WHOST-VAL-ATU-MON-SUB + WHOST-VAL-ATU-MON */
                WHOST_VAL_ATU_MON_SUB.Value = WHOST_VAL_ATU_MON_SUB + WHOST_VAL_ATU_MON;

                /*" -1837- COMPUTE WHOST-VAL-ATU-MON-TOT = WHOST-VAL-ATU-MON-TOT + WHOST-VAL-ATU-MON */
                WHOST_VAL_ATU_MON_TOT.Value = WHOST_VAL_ATU_MON_TOT + WHOST_VAL_ATU_MON;

                /*" -1840- COMPUTE WHOST-VAL-JUROS-SUB = WHOST-VAL-JUROS-SUB + WHOST-VAL-JUROS */
                WHOST_VAL_JUROS_SUB.Value = WHOST_VAL_JUROS_SUB + WHOST_VAL_JUROS;

                /*" -1843- COMPUTE WHOST-VAL-JUROS-TOT = WHOST-VAL-JUROS-TOT + WHOST-VAL-JUROS */
                WHOST_VAL_JUROS_TOT.Value = WHOST_VAL_JUROS_TOT + WHOST_VAL_JUROS;

                /*" -1846- COMPUTE WHOST-VAL-PAG-COMP-SUB = WHOST-VAL-PAG-COMP-SUB + WHOST-VAL-PAG-COMP */
                WHOST_VAL_PAG_COMP_SUB.Value = WHOST_VAL_PAG_COMP_SUB + WHOST_VAL_PAG_COMP;

                /*" -1848- COMPUTE WHOST-VAL-PAG-COMP-TOT = WHOST-VAL-PAG-COMP-TOT + WHOST-VAL-PAG-COMP */
                WHOST_VAL_PAG_COMP_TOT.Value = WHOST_VAL_PAG_COMP_TOT + WHOST_VAL_PAG_COMP;

                /*" -1848- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-SELECT-SINISHIS-SECTION */
        private void R2500_00_SELECT_SINISHIS_SECTION()
        {
            /*" -1863- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -1876- PERFORM R2500_00_SELECT_SINISHIS_DB_SELECT_1 */

            R2500_00_SELECT_SINISHIS_DB_SELECT_1();

            /*" -1879- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1880- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1881- MOVE ZEROS TO SINISHIS-VAL-OPERACAO */
                    _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                    /*" -1882- ELSE */
                }
                else
                {


                    /*" -1883- DISPLAY 'PROBLEMAS NO ACESSO A SINISHIS - 2500' */
                    _.Display($"PROBLEMAS NO ACESSO A SINISHIS - 2500");

                    /*" -1884- DISPLAY 'APOLICE:' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"APOLICE:{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -1885- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1886- END-IF */
                }


                /*" -1886- END-IF. */
            }


        }

        [StopWatch]
        /*" R2500-00-SELECT-SINISHIS-DB-SELECT-1 */
        public void R2500_00_SELECT_SINISHIS_DB_SELECT_1()
        {
            /*" -1876- EXEC SQL SELECT VALUE(SUM(VAL_OPERACAO),0) AS VAL_JUROS INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO = 1184 AND NOME_FAVORECIDO = :SINISHIS-NOME-FAVORECIDO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO END-EXEC. */

            var r2500_00_SELECT_SINISHIS_DB_SELECT_1_Query1 = new R2500_00_SELECT_SINISHIS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_NOME_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R2500_00_SELECT_SINISHIS_DB_SELECT_1_Query1.Execute(r2500_00_SELECT_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-SELECT-GE369-SECTION */
        private void R2600_00_SELECT_GE369_SECTION()
        {
            /*" -1900- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", WABEND.WNR_EXEC_SQL);

            /*" -1917- PERFORM R2600_00_SELECT_GE369_DB_SELECT_1 */

            R2600_00_SELECT_GE369_DB_SELECT_1();

            /*" -1921- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1922- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1926- MOVE ZEROS TO OD009-COD-BANCO OD009-COD-AGENCIA OD009-NUM-OPERACAO-CONTA OD009-NUM-CONTA */
                    _.Move(0, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA);

                    /*" -1927- ELSE */
                }
                else
                {


                    /*" -1928- DISPLAY 'PROBLEMAS ACESSO A OD_PESS_CONTA_BANC 2600' */
                    _.Display($"PROBLEMAS ACESSO A OD_PESS_CONTA_BANC 2600");

                    /*" -1929- DISPLAY 'APOLICE:' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"APOLICE:{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -1930- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1930- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R2600-00-SELECT-GE369-DB-SELECT-1 */
        public void R2600_00_SELECT_GE369_DB_SELECT_1()
        {
            /*" -1917- EXEC SQL SELECT A.COD_BANCO , A.COD_AGENCIA , A.NUM_OPERACAO_CONTA , A.NUM_CONTA INTO :OD009-COD-BANCO , :OD009-COD-AGENCIA , :OD009-NUM-OPERACAO-CONTA, :OD009-NUM-CONTA FROM ODS.OD_PESS_CONTA_BANC A, SEGUROS.SI_PESS_SINISTRO B, SEGUROS.GE_LEG_PESS_EVENTO C WHERE B.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND B.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND B.NUM_OCORR_MOVTO = C.NUM_OCORR_MOVTO AND C.NUM_PESSOA = A.NUM_PESSOA FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r2600_00_SELECT_GE369_DB_SELECT_1_Query1 = new R2600_00_SELECT_GE369_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R2600_00_SELECT_GE369_DB_SELECT_1_Query1.Execute(r2600_00_SELECT_GE369_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD009_COD_BANCO, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO);
                _.Move(executed_1.OD009_COD_AGENCIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA);
                _.Move(executed_1.OD009_NUM_OPERACAO_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA);
                _.Move(executed_1.OD009_NUM_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1944- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1946- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1946- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1948- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1952- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1952- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}