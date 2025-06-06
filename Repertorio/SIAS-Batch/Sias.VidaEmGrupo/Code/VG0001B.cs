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
using Sias.VidaEmGrupo.DB2.VG0001B;

namespace Code
{
    public class VG0001B
    {
        public bool IsCall { get; set; }

        public VG0001B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"V.10  *   FUNCAO .................  INTEGRA AS APOLICES ESPECIFICAS NA *      */
        /*"V.10  *                             ESTRUTURA DO MULTIPREMIADO.        *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  FREDERICO FONSECA                  *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG0001B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  07/12/2001                         *      */
        /*"      ******************************************************************      */
        /*"      *                   A L T E R A C O E S                          *      */
        /*"      ******************************************************************      */
        /*"V.27  *   VERSAO 27 - INCIDENTE 523.902  TAREFA 524.068                *      */
        /*"      *             - ABEND -803 NO INSERT DA COBER_HIST_VIDAZUL       *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/08/2023 - TERCIO CARVALHO                              *      */
        /*"      *                                        PROCURE POR V.27        *      */
        /*"      ******************************************************************      */
        /*"V.26  *   VERSAO 26 - INCIDENTE 523.902  TAREFA 524.068                *      */
        /*"      *             - ABEND -803 NO INSERT DA COBER_HIST_VIDAZUL       *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/08/2023 - TERCIO CARVALHO                              *      */
        /*"      *                                        PROCURE POR V.26        *      */
        /*"      ******************************************************************      */
        /*"V.25  *   VERSAO 25 - INCIDENTE 471.940  TAREFA 472.389                *      */
        /*"      *             - ABEND NA SUBROTINA SPVG001 PELO SEQUENCIAL DO    *      */
        /*"      *               ERRO ESTAR COM ZEROS.                            *      */
        /*"      *             - DEVE SER PEGAR O SEQ-CRITICA RETORNADO NA        *      */
        /*"      *               CONSULTA E PASSAR PARA REALIZAR A EXCLUSAO LOGICA*      */
        /*"      *                                                                *      */
        /*"      *   EM 27/02/2023 - HUSNI ALI HUSNI                              *      */
        /*"      *                                        PROCURE POR V.25        *      */
        /*"      ******************************************************************      */
        /*"V.24  *   VERSAO 24 - INCIDENTE 471.582                                *      */
        /*"      *             - ABEND NA SUBROTINA SPVG001 PELO SEQUENCIAL DO    *      */
        /*"      *               ERRO ESTAR COM ZEROS.                            *      */
        /*"      *             - PASSA A SER INFORMADO O SEQUENCIAL DE ERRO       *      */
        /*"      *               01-EMISSAO DE APOL. ESPEC. SEM CLASSIFICACAO     *      */
        /*"      *                  DE RISCO.                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/02/2023 - TERCIO CARVALHO                              *      */
        /*"      *                                        PROCURE POR V.24        *      */
        /*"      ******************************************************************      */
        /*"V.23  *   VERSAO 23 - DEMANDA 402.982                                  *      */
        /*"      *             - RETIRAR GRAVACAO DE ERROS DA PROPOSTA DA TABELA  *      */
        /*"      *               ERROS_PROP_VIDAZUL                               *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.23        *      */
        /*"      ******************************************************************      */
        /*"V.22  *   VERSAO 22 - PLD Circular 612 - Fase 2 -  Demanda 379166      *      */
        /*"      *             - ABEND EM APOL. ESPEC. GERADA MANUALMENTE POR     *      */
        /*"      *               ATALHO DO SIAS. LIBERADA EMISSAO SEM CLASSIF. DE *      */
        /*"      *               RISCO.                                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/10/2022 - ELIERMES OLIVEIRA   PROCURE POR V.22         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"V.21  *   VERSAO 21 - PLD Circular 612 - Fase 2 -  Demanda 379166      *      */
        /*"      *             - INCLUIDO ROTINA SPBVG001 PARA CONSULTA DE RISCO  *      */
        /*"      *               DE APOL. ESPEC. CASO EXISTA RISCO CRITICO NAO    *      */
        /*"      *               SOLUCIONADO AGUARDA CONCLUSAO DO TRATAMENTO      *      */
        /*"      *               PELO GESTOR, CASO NAO ENCONTRE RISCO CADASTRADO, *      */
        /*"      *               VERIFICA SE MOTOR GEROU CLASSIFICACAO, SE GEROU  *      */
        /*"      *               INSERE CLASSIFICACAO, SE NAO GEROU INFORMA QUE A *      */
        /*"      *               APOLICE SERAH EMITIDA SEM ANALISE DE RISCO       *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/10/2022 - ELIERMES OLIVEIRA   PROCURE POR V.21         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 20 - HIST 379.469                                     *      */
        /*"      *             - RETIRAR CONDICAO DE -803 NO INSERT DA            *      */
        /*"      *               COBER_HIST_VIDAZUL PARA SINALIZAR DUPLICIDADE DE *      */
        /*"      *               NUM_TITULO.                                      *      */
        /*"      *   EM 11/04/2022 - BRICE HO                                     *      */
        /*"      *                                       PROCURE POR V.20         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19 - HIST 325.732                                     *      */
        /*"      *             - AJUSTE DATA DE INICIO DE VIGENCIA DA APOLICE, DOS*      */
        /*"      *               CERTIFICADOS (SEGURADOS) E ENDOSSOS COM BASE NA  *      */
        /*"      *               DATA DA BAIXA PARA PROPOSTAS ORIUNDAS DO PORTAL. *      */
        /*"      *             - ELIMINACAO ERROS PRECOMPILADOR DB2.              *      */
        /*"      *   EM 18/10/2021 - BRICE HO                                     *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   DEMAIS HISTORICOS DE MANUTENCAO - VIDE FINAL DO PROGRAMA     *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  VGFUNCOB-QTD-VIDAS               PIC S9(04)    COMP VALUE +0*/
        public IntBasis VGFUNCOB_QTD_VIDAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-DTQITBCO                    PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-AGECTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-OPRCTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-NUMCTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-DIGCTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-INDRCAP                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_INDRCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-TEM-CDG                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-TEM-SAF                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-ROT-SAF                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_ROT_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-COD-PROD-EA                 PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_COD_PROD_EA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-IND                         PIC S9(04)    COMP VALUE +0*/
        public IntBasis HOST_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  CLIENTES-DATA-NASCIMENTO-I       PIC S9(04)    COMP.*/
        public IntBasis CLIENTES_DATA_NASCIMENTO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HISCONPA-DTFATUR-I               PIC S9(04)    COMP.*/
        public IntBasis HISCONPA_DTFATUR_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  SISTEMAS-DATA-ANTERIOR           PIC  X(10).*/
        public StringBasis SISTEMAS_DATA_ANTERIOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  SISTEMAS-DATA-MOV-6MONTH         PIC  X(10).*/
        public StringBasis SISTEMAS_DATA_MOV_6MONTH { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  H-NUM-CERTIFICADO                PIC S9(015)   COMP-3.*/
        public IntBasis H_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  H-DAC-CERTIFICADO                PIC  X(001).*/
        public StringBasis H_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WHOST-PCT-IOCC-RAMO              PIC S9(003)V9(05).*/
        public DoubleBasis WHOST_PCT_IOCC_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(05)."), 5);
        /*"77  VGSOLFAT-PRM-TOTAL               PIC S9(013)V9(02) COMP-3.*/
        public DoubleBasis VGSOLFAT_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77  CONT-SOLICT-RJTA                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis CONT_SOLICT_RJTA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"77  WHOST-FAIXA-RENDA                PIC  X(001).*/
        public StringBasis WHOST_FAIXA_RENDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WS-DTVENC-1PARC                  PIC X(010) VALUE SPACES.*/
        public StringBasis WS_DTVENC_1PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  WS-TEM-RCAP                      PIC X(001) VALUE SPACES.*/
        public StringBasis WS_TEM_RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77  WS-ULT-DIA-MES                   PIC S9(004) COMP.*/
        public IntBasis WS_ULT_DIA_MES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-COD-ERRO                      PIC S9(004) COMP.*/
        public IntBasis WS_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-CNT-SEGURADOS                 PIC S9(004) COMP.*/
        public IntBasis WS_CNT_SEGURADOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-PROGRAMA                      PIC X(008) VALUE SPACES.*/
        public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77  WS-QT-RISCO-CRITICO              PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_RISCO_CRITICO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77  WS-QT-EM-CRITICA                 PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_EM_CRITICA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77  WS-QT-EMISSAO-S-RISCO            PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_EMISSAO_S_RISCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77  WS-QT-MANUAL-S-RISCO             PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_MANUAL_S_RISCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77  WS-QT-EMISSAO-C-RISCO            PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_EMISSAO_C_RISCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77  WS-QT-LIBERADO-EMISSAO           PIC 9(006) VALUE 0.*/
        public IntBasis WS_QT_LIBERADO_EMISSAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77  WS-ERRO-VG009                    PIC 9(001) VALUE 0.*/
        public IntBasis WS_ERRO_VG009 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"77  WS-NUM-PROPOSTA-SIVPF            PIC S9(15)  COMP-3.*/
        public IntBasis WS_NUM_PROPOSTA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  WS-FLAG-PROP-MANUAL              PIC 9(001) VALUE 0.*/
        public IntBasis WS_FLAG_PROP_MANUAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01  WS-COD-CRITICA              PIC  9(005) VALUE 0.*/
        public IntBasis WS_COD_CRITICA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  WS-I-ERRO                   PIC  9(003) VALUE ZEROS.*/
        public IntBasis WS_I_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"01  WS-FLAG-TEM-ERRO            PIC  X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WORK-TAB-ERROS-CERT.*/
        public VG0001B_WORK_TAB_ERROS_CERT WORK_TAB_ERROS_CERT { get; set; } = new VG0001B_WORK_TAB_ERROS_CERT();
        public class VG0001B_WORK_TAB_ERROS_CERT : VarBasis
        {
            /*"    05  WS-TAB-ERROS-CERT   OCCURS 100 TIMES.*/
            public ListBasis<VG0001B_WS_TAB_ERROS_CERT> WS_TAB_ERROS_CERT { get; set; } = new ListBasis<VG0001B_WS_TAB_ERROS_CERT>(100);
            public class VG0001B_WS_TAB_ERROS_CERT : VarBasis
            {
                /*"      10  TB-ERRO-CERT          PIC S9(004) COMP.*/
                public IntBasis TB_ERRO_CERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"01  PARAMETROS.*/
            }
        }
        public VG0001B_PARAMETROS PARAMETROS { get; set; } = new VG0001B_PARAMETROS();
        public class VG0001B_PARAMETROS : VarBasis
        {
            /*"    05 LK-APOLICE                    PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05 LK-SUBGRUPO                   PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-IDADE                      PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-NASCIMENTO.*/
            public VG0001B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VG0001B_LK_NASCIMENTO();
            public class VG0001B_LK_NASCIMENTO : VarBasis
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
            /*"01  W-NUM-CTA-CORRENTE          PIC  9(017)   VALUE ZEROS.*/
        }
        public IntBasis W_NUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("9", "17", "9(017)"));
        /*"01  FILLER                      REDEFINES    W-NUM-CTA-CORRENTE.*/
        private _REDEF_VG0001B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_VG0001B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_VG0001B_FILLER_0(); _.Move(W_NUM_CTA_CORRENTE, _filler_0); VarBasis.RedefinePassValue(W_NUM_CTA_CORRENTE, _filler_0, W_NUM_CTA_CORRENTE); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_NUM_CTA_CORRENTE); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, W_NUM_CTA_CORRENTE); }
        }  //Redefines
        public class _REDEF_VG0001B_FILLER_0 : VarBasis
        {
            /*"  05    WZEROS                  PIC  9(001).*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05    WOPRCTADEB              PIC  9(004).*/
            public IntBasis WOPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05    WNUMCTADEB              PIC  9(012).*/
            public IntBasis WNUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"01  WDIGCTADEB                  PIC  9(001).*/

            public _REDEF_VG0001B_FILLER_0()
            {
                WZEROS.ValueChanged += OnValueChanged;
                WOPRCTADEB.ValueChanged += OnValueChanged;
                WNUMCTADEB.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WDIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
        /*"01  FILLER                      REDEFINES    WDIGCTADEB.*/
        private _REDEF_VG0001B_FILLER_1 _filler_1 { get; set; }
        public _REDEF_VG0001B_FILLER_1 FILLER_1
        {
            get { _filler_1 = new _REDEF_VG0001B_FILLER_1(); _.Move(WDIGCTADEB, _filler_1); VarBasis.RedefinePassValue(WDIGCTADEB, _filler_1, WDIGCTADEB); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDIGCTADEB); }; return _filler_1; }
            set { VarBasis.RedefinePassValue(value, _filler_1, WDIGCTADEB); }
        }  //Redefines
        public class _REDEF_VG0001B_FILLER_1 : VarBasis
        {
            /*"  05    W-DAC-CTA-CORRENTE      PIC  X(001).*/
            public StringBasis W_DAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01  WS-WORK-AREAS.*/

            public _REDEF_VG0001B_FILLER_1()
            {
                W_DAC_CTA_CORRENTE.ValueChanged += OnValueChanged;
            }

        }
        public VG0001B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VG0001B_WS_WORK_AREAS();
        public class VG0001B_WS_WORK_AREAS : VarBasis
        {
            /*"    03 WDATA-VIGENCIA1.*/
            public VG0001B_WDATA_VIGENCIA1 WDATA_VIGENCIA1 { get; set; } = new VG0001B_WDATA_VIGENCIA1();
            public class VG0001B_WDATA_VIGENCIA1 : VarBasis
            {
                /*"       05  WDATA-VIG-ANO1    PIC  9(004).*/
                public IntBasis WDATA_VIG_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WDATA-VIG-MES1    PIC  9(002).*/
                public IntBasis WDATA_VIG_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WDATA-VIG-DIA1    PIC  9(002).*/
                public IntBasis WDATA_VIG_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-ORIG-PRODU                 PIC  X(010) VALUE SPACES.*/
            }
            public StringBasis WS_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03 WANO                          PIC  9(002) VALUE ZEROES.*/
            public IntBasis WANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    03 WS-PRODU                      PIC  9(004) VALUE ZEROES.*/
            public IntBasis WS_PRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    03 WS-PERIPGTO                   PIC  9(002) VALUE ZEROES.*/
            public IntBasis WS_PERIPGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    03 WS-TEM-ERRO                   PIC  X(001) VALUE 'N'.*/
            public StringBasis WS_TEM_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"    03 WS-PCT-VG                     PIC S9(013)V99  COMP-3.*/
            public DoubleBasis WS_PCT_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03 WS-PCT-AP                     PIC S9(013)V99  COMP-3.*/
            public DoubleBasis WS_PCT_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03 WS-DATA-BASE.*/
            public VG0001B_WS_DATA_BASE WS_DATA_BASE { get; set; } = new VG0001B_WS_DATA_BASE();
            public class VG0001B_WS_DATA_BASE : VarBasis
            {
                /*"       05 WS-ANO-BASE                PIC  9(004).*/
                public IntBasis WS_ANO_BASE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-MES-BASE                PIC  9(002).*/
                public IntBasis WS_MES_BASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-DIA-BASE                PIC  9(002).*/
                public IntBasis WS_DIA_BASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-ACHEI-PROPOVA              PIC  X(001)   VALUE SPACES.*/
            }
            public StringBasis WS_ACHEI_PROPOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03 WCERTIFICADO                  PIC  9(015)   VALUE ZEROS.*/
            public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    03 FILLER                        REDEFINES     WCERTIFICADO.*/
            private _REDEF_VG0001B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_VG0001B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_VG0001B_FILLER_6(); _.Move(WCERTIFICADO, _filler_6); VarBasis.RedefinePassValue(WCERTIFICADO, _filler_6, WCERTIFICADO); _filler_6.ValueChanged += () => { _.Move(_filler_6, WCERTIFICADO); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WCERTIFICADO); }
            }  //Redefines
            public class _REDEF_VG0001B_FILLER_6 : VarBasis
            {
                /*"       05 WNRCERTIF                  PIC  9(014).*/
                public IntBasis WNRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"       05 WDVCERTIF                  PIC  9(001).*/
                public IntBasis WDVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    03 WFIM-V1RCAP                   PIC X VALUE SPACES.*/

                public _REDEF_VG0001B_FILLER_6()
                {
                    WNRCERTIF.ValueChanged += OnValueChanged;
                    WDVCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WFIM_V1RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03 WFIM-SEGURAVG                 PIC X VALUE SPACES.*/
            public StringBasis WFIM_SEGURAVG { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03 WFIM-PROPOVA-CRTCA            PIC X VALUE SPACES.*/
            public StringBasis WFIM_PROPOVA_CRTCA { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03 WTEM-COBERTURA                PIC X VALUE SPACES.*/
            public StringBasis WTEM_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03 AC-L-SOLICITA                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_SOLICITA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-L-PROP-CRT                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_PROP_CRT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 WS-CONT-INTEGRADO             PIC  9(006) VALUE  0.*/
            public IntBasis WS_CONT_INTEGRADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 WS-CONT-TEMERRO               PIC  9(006) VALUE  0.*/
            public IntBasis WS_CONT_TEMERRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-L-COMMIT                   PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_COMMIT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-L-PARCELASVG               PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_PARCELASVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-PROPOSTAVA               PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-COBERPROPVA              PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_COBERPROPVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-OPCAOPAGVA               PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_OPCAOPAGVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-PARCELVA                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_PARCELVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-HISTCOBVA                PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_HISTCOBVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-HISTCTAVA                PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_HISTCTAVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-HISTCTABI                PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_HISTCTABI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-CONVEVG                  PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_CONVEVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-PRODUVG                  PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_PRODUVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-PORTALPJ                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_PORTALPJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-W-CONTA                    PIC  9(006) VALUE  0.*/
            public IntBasis AC_W_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-ACEITOS                    PIC  9(006) VALUE  0.*/
            public IntBasis AC_ACEITOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 WS-TIME                       PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    03 WS-DATA-AUX                   PIC  X(010) VALUE ' '.*/
            public StringBasis WS_DATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" ");
            /*"    03 WDIFERENCA                    PIC S9(13)V99 COMP VALUE +0*/
            public DoubleBasis WDIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03 WDATA-INIVIG.*/
            public VG0001B_WDATA_INIVIG WDATA_INIVIG { get; set; } = new VG0001B_WDATA_INIVIG();
            public class VG0001B_WDATA_INIVIG : VarBasis
            {
                /*"       05 ANO-INIVIG                 PIC 9(04).*/
                public IntBasis ANO_INIVIG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 MES-INIVIG                 PIC 9(02).*/
                public IntBasis MES_INIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 DIA-INIVIG                 PIC 9(02).*/
                public IntBasis DIA_INIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-NASC.*/
            }
            public VG0001B_WDATA_NASC WDATA_NASC { get; set; } = new VG0001B_WDATA_NASC();
            public class VG0001B_WDATA_NASC : VarBasis
            {
                /*"       05 ANO-NASC                   PIC 9(04).*/
                public IntBasis ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 MES-NASC                   PIC 9(02).*/
                public IntBasis MES_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 DIA-NASC                   PIC 9(02).*/
                public IntBasis DIA_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WS-DATA-SQL.*/
            }
            public VG0001B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VG0001B_WS_DATA_SQL();
            public class VG0001B_WS_DATA_SQL : VarBasis
            {
                /*"       05 WS-ANO-SQL                 PIC 9(04).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WS-MES-SQL                 PIC 9(02).*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WS-DIA-SQL                 PIC 9(02).*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-PARC-ATU.*/
            }
            public VG0001B_WDATA_PARC_ATU WDATA_PARC_ATU { get; set; } = new VG0001B_WDATA_PARC_ATU();
            public class VG0001B_WDATA_PARC_ATU : VarBasis
            {
                /*"       05 WDATA-PAR-ANO              PIC 9(04).*/
                public IntBasis WDATA_PAR_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PAR-MES              PIC 9(02).*/
                public IntBasis WDATA_PAR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PAR-DIA              PIC 9(02).*/
                public IntBasis WDATA_PAR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-PARC-PRX.*/
            }
            public VG0001B_WDATA_PARC_PRX WDATA_PARC_PRX { get; set; } = new VG0001B_WDATA_PARC_PRX();
            public class VG0001B_WDATA_PARC_PRX : VarBasis
            {
                /*"       05 WDATA-PRX-ANO              PIC 9(04).*/
                public IntBasis WDATA_PRX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PRX-MES              PIC 9(02).*/
                public IntBasis WDATA_PRX_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PRX-DIA              PIC 9(02).*/
                public IntBasis WDATA_PRX_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-INIVIGENCIA.*/
            }
            public VG0001B_WDATA_INIVIGENCIA WDATA_INIVIGENCIA { get; set; } = new VG0001B_WDATA_INIVIGENCIA();
            public class VG0001B_WDATA_INIVIGENCIA : VarBasis
            {
                /*"       05 WDATA-INI-ANO              PIC 9(04).*/
                public IntBasis WDATA_INI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-INI-MES              PIC 9(02).*/
                public IntBasis WDATA_INI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-INI-DIA              PIC 9(02).*/
                public IntBasis WDATA_INI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03  W-NUMR-TITULO                PIC  9(013)   VALUE ZEROS.*/
            }
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    03  FILLER                       REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_VG0001B_FILLER_19 _filler_19 { get; set; }
            public _REDEF_VG0001B_FILLER_19 FILLER_19
            {
                get { _filler_19 = new _REDEF_VG0001B_FILLER_19(); _.Move(W_NUMR_TITULO, _filler_19); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_19, W_NUMR_TITULO); _filler_19.ValueChanged += () => { _.Move(_filler_19, W_NUMR_TITULO); }; return _filler_19; }
                set { VarBasis.RedefinePassValue(value, _filler_19, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VG0001B_FILLER_19 : VarBasis
            {
                /*"      05    WTITL-ZEROS              PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05    WTITL-SEQUENCIA          PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05    WTITL-DIGITO             PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    03              DPARM01X.*/

                public _REDEF_VG0001B_FILLER_19()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VG0001B_DPARM01X DPARM01X { get; set; } = new VG0001B_DPARM01X();
            public class VG0001B_DPARM01X : VarBasis
            {
                /*"      05            DPARM01          PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05            DPARM01-R        REDEFINES   DPARM01.*/
                private _REDEF_VG0001B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VG0001B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VG0001B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VG0001B_DPARM01_R : VarBasis
                {
                    /*"        10          DPARM01-1        PIC  9(001).*/
                    public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-2        PIC  9(001).*/
                    public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-3        PIC  9(001).*/
                    public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-4        PIC  9(001).*/
                    public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-5        PIC  9(001).*/
                    public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-6        PIC  9(001).*/
                    public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-7        PIC  9(001).*/
                    public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-8        PIC  9(001).*/
                    public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-9        PIC  9(001).*/
                    public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-10       PIC  9(001).*/
                    public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      05            DPARM01-D1       PIC  9(001).*/

                    public _REDEF_VG0001B_DPARM01_R()
                    {
                        DPARM01_1.ValueChanged += OnValueChanged;
                        DPARM01_2.ValueChanged += OnValueChanged;
                        DPARM01_3.ValueChanged += OnValueChanged;
                        DPARM01_4.ValueChanged += OnValueChanged;
                        DPARM01_5.ValueChanged += OnValueChanged;
                        DPARM01_6.ValueChanged += OnValueChanged;
                        DPARM01_7.ValueChanged += OnValueChanged;
                        DPARM01_8.ValueChanged += OnValueChanged;
                        DPARM01_9.ValueChanged += OnValueChanged;
                        DPARM01_10.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis DPARM01_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05            DPARM01-RC       PIC S9(004) COMP VALUE +0.*/
                public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    03          W01DIGCERT.*/
            }
            public VG0001B_W01DIGCERT W01DIGCERT { get; set; } = new VG0001B_W01DIGCERT();
            public class VG0001B_W01DIGCERT : VarBasis
            {
                /*"      05        WCERTIFICADO    PIC  9(015)        VALUE  0.*/
                public IntBasis WCERTIFICADO_0 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"      05        WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
                public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
                /*"      05        WDIG            PIC  X(001)  VALUE SPACES.*/
                public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"01  TABELA-ULTIMOS-DIAS.*/
            }
        }
        public VG0001B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VG0001B_TABELA_ULTIMOS_DIAS();
        public class VG0001B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"    05 FILLER                      PIC  X(024)  VALUE                                  '312831303130313130313031'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01  TAB-ULTIMOS-DIAS               REDEFINES                                   TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VG0001B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
        public _REDEF_VG0001B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
        {
            get { _tab_ultimos_dias = new _REDEF_VG0001B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VG0001B_TAB_ULTIMOS_DIAS : VarBasis
        {
            /*"    05 TAB-DIA-MESES               OCCURS 12.*/
            public ListBasis<VG0001B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VG0001B_TAB_DIA_MESES>(12);
            public class VG0001B_TAB_DIA_MESES : VarBasis
            {
                /*"      07 TAB-DIA-MES               PIC  9(002).*/
                public IntBasis TAB_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01  TABELA-PRODUTOS.*/

                public VG0001B_TAB_DIA_MESES()
                {
                    TAB_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG0001B_TAB_ULTIMOS_DIAS()
            {
                TAB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public VG0001B_TABELA_PRODUTOS TABELA_PRODUTOS { get; set; } = new VG0001B_TABELA_PRODUTOS();
        public class VG0001B_TABELA_PRODUTOS : VarBasis
        {
            /*"    05 FILLER                      PIC  X(010)  VALUE                                  '9706019712'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"9706019712");
            /*"    05 FILLER                      PIC  X(010)  VALUE                                  '9706039713'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"9706039713");
            /*"    05 FILLER                      PIC  X(010)  VALUE                                  '9706069714'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"9706069714");
            /*"    05 FILLER                      PIC  X(010)  VALUE                                  '9706129715'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"9706129715");
            /*"01  TAB-PRODUTOS-NOVOS             REDEFINES                                   TABELA-PRODUTOS.*/
        }
        private _REDEF_VG0001B_TAB_PRODUTOS_NOVOS _tab_produtos_novos { get; set; }
        public _REDEF_VG0001B_TAB_PRODUTOS_NOVOS TAB_PRODUTOS_NOVOS
        {
            get { _tab_produtos_novos = new _REDEF_VG0001B_TAB_PRODUTOS_NOVOS(); _.Move(TABELA_PRODUTOS, _tab_produtos_novos); VarBasis.RedefinePassValue(TABELA_PRODUTOS, _tab_produtos_novos, TABELA_PRODUTOS); _tab_produtos_novos.ValueChanged += () => { _.Move(_tab_produtos_novos, TABELA_PRODUTOS); }; return _tab_produtos_novos; }
            set { VarBasis.RedefinePassValue(value, _tab_produtos_novos, TABELA_PRODUTOS); }
        }  //Redefines
        public class _REDEF_VG0001B_TAB_PRODUTOS_NOVOS : VarBasis
        {
            /*"    05 TAB-NOVOS-PRODUTOS          OCCURS 04 TIMES         ASCENDING TAB-PROD-ANT TAB-PERIPGTO         INDEXED BY IDX-PROD.*/
            public ListBasis<VG0001B_TAB_NOVOS_PRODUTOS> TAB_NOVOS_PRODUTOS { get; set; } = new ListBasis<VG0001B_TAB_NOVOS_PRODUTOS>(04);
            public class VG0001B_TAB_NOVOS_PRODUTOS : VarBasis
            {
                /*"      07 TAB-PROD-ANT              PIC  9(004).*/
                public IntBasis TAB_PROD_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      07 TAB-PERIPGTO              PIC  9(002).*/
                public IntBasis TAB_PERIPGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      07 TAB-PROD-NEW              PIC  9(004).*/
                public IntBasis TAB_PROD_NEW { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01  WS-INIVIGENCIA              PIC X(10).*/

                public VG0001B_TAB_NOVOS_PRODUTOS()
                {
                    TAB_PROD_ANT.ValueChanged += OnValueChanged;
                    TAB_PERIPGTO.ValueChanged += OnValueChanged;
                    TAB_PROD_NEW.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG0001B_TAB_PRODUTOS_NOVOS()
            {
                TAB_NOVOS_PRODUTOS.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  FILLER REDEFINES WS-INIVIGENCIA.*/
        private _REDEF_VG0001B_FILLER_25 _filler_25 { get; set; }
        public _REDEF_VG0001B_FILLER_25 FILLER_25
        {
            get { _filler_25 = new _REDEF_VG0001B_FILLER_25(); _.Move(WS_INIVIGENCIA, _filler_25); VarBasis.RedefinePassValue(WS_INIVIGENCIA, _filler_25, WS_INIVIGENCIA); _filler_25.ValueChanged += () => { _.Move(_filler_25, WS_INIVIGENCIA); }; return _filler_25; }
            set { VarBasis.RedefinePassValue(value, _filler_25, WS_INIVIGENCIA); }
        }  //Redefines
        public class _REDEF_VG0001B_FILLER_25 : VarBasis
        {
            /*"    03  FILLER                  PIC X(08).*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    03  WS-DIAVIGENCIA          PIC 9(02).*/
            public IntBasis WS_DIAVIGENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  WS-TERVIGENCIA              PIC X(10).*/

            public _REDEF_VG0001B_FILLER_25()
            {
                FILLER_26.ValueChanged += OnValueChanged;
                WS_DIAVIGENCIA.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WS-CARTAO-CREDITO.*/
        public VG0001B_WS_CARTAO_CREDITO WS_CARTAO_CREDITO { get; set; } = new VG0001B_WS_CARTAO_CREDITO();
        public class VG0001B_WS_CARTAO_CREDITO : VarBasis
        {
            /*"    03  WS-CARTAO-CREDITO-N     PIC 9(16).*/
            public IntBasis WS_CARTAO_CREDITO_N { get; set; } = new IntBasis(new PIC("9", "16", "9(16)."));
            /*"01  WABEND.*/
        }
        public VG0001B_WABEND WABEND { get; set; } = new VG0001B_WABEND();
        public class VG0001B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(016) VALUE            '*** VG0001B *** '.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"*** VG0001B *** ");
            /*"      10    FILLER                   PIC  X(013) VALUE            'ERRO SQL *** '.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"ERRO SQL *** ");
            /*"      10    FILLER                   PIC  X(010) VALUE            'SQLCODE = '.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD1 = '.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD2 = '.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10      LOCALIZA-ABEND-1.*/
            public VG0001B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VG0001B_LOCALIZA_ABEND_1();
            public class VG0001B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        15    FILLER                   PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        15    PARAGRAFO              PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10      LOCALIZA-ABEND-2.*/
            }
            public VG0001B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VG0001B_LOCALIZA_ABEND_2();
            public class VG0001B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        15    FILLER                   PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        15    COMANDO                PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Copies.SPVG009W SPVG009W { get; set; } = new Copies.SPVG009W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.BANCOS BANCOS { get; set; } = new Dclgens.BANCOS();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.NUMEROUT NUMEROUT { get; set; } = new Dclgens.NUMEROUT();
        public Dclgens.VGSOLFAT VGSOLFAT { get; set; } = new Dclgens.VGSOLFAT();
        public Dclgens.MOEDACOT MOEDACOT { get; set; } = new Dclgens.MOEDACOT();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.FATURAS FATURAS { get; set; } = new Dclgens.FATURAS();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.CONVEVG CONVEVG { get; set; } = new Dclgens.CONVEVG();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.VGPROSIA VGPROSIA { get; set; } = new Dclgens.VGPROSIA();
        public Dclgens.VGCOMTRO VGCOMTRO { get; set; } = new Dclgens.VGCOMTRO();
        public Dclgens.TERMOADE TERMOADE { get; set; } = new Dclgens.TERMOADE();
        public Dclgens.VGFUNCOB VGFUNCOB { get; set; } = new Dclgens.VGFUNCOB();
        public Dclgens.VGMOVFUN VGMOVFUN { get; set; } = new Dclgens.VGMOVFUN();
        public Dclgens.VGCOBTER VGCOBTER { get; set; } = new Dclgens.VGCOBTER();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.SEGVGAP SEGVGAP { get; set; } = new Dclgens.SEGVGAP();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.VG078 VG078 { get; set; } = new Dclgens.VG078();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VG0001B_CSOLICITA CSOLICITA { get; set; } = new VG0001B_CSOLICITA();
        public VG0001B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new VG0001B_V1RCAPCOMP();
        public VG0001B_CPROPOVACRT CPROPOVACRT { get; set; } = new VG0001B_CPROPOVACRT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL-SECTION */

                M_0000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-SECTION */
        private void M_0000_PRINCIPAL_SECTION()
        {
            /*" -485- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -486- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -487- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -490- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -491- DISPLAY '          PROGRAMA EM EXECUCAO VG0001B          ' */
            _.Display($"          PROGRAMA EM EXECUCAO VG0001B          ");

            /*" -492- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -493- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -500- DISPLAY 'VERSAO V.27 523.902 22/08/2023 DE ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"VERSAO V.27 523.902 22/08/2023 DE FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -501- DISPLAY ' ' */
            _.Display($" ");

            /*" -508- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -509- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -511- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -513- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -515- PERFORM 0889-SELECT-SISTEMAS. */

            M_0889_SELECT_SISTEMAS_SECTION();

            /*" -517- PERFORM 0900-DECLA-VGSOLFAT */

            M_0900_DECLA_VGSOLFAT_SECTION();

            /*" -519- PERFORM 0910-FETCH-VGSOLFAT */

            M_0910_FETCH_VGSOLFAT_SECTION();

            /*" -520- IF (WFIM-SEGURAVG NOT EQUAL SPACES) */

            if ((!WS_WORK_AREAS.WFIM_SEGURAVG.IsEmpty()))
            {

                /*" -521- DISPLAY '*** SEM MOVIMENTO NA VG_SOLICITA_FATURA' */
                _.Display($"*** SEM MOVIMENTO NA VG_SOLICITA_FATURA");

                /*" -522- GO TO 0000-FIM-VGSOLFAT */

                M_0000_FIM_VGSOLFAT(); //GOTO
                return;

                /*" -524- END-IF. */
            }


            /*" -526- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -528- DISPLAY '** VG0001B - PROCESSANDO ...' WS-TIME. */
            _.Display($"** VG0001B - PROCESSANDO ...{WS_WORK_AREAS.WS_TIME}");

            /*" -529- PERFORM 1000-PROCESSA-VGSOLFAT UNTIL WFIM-SEGURAVG EQUAL 'S' . */

            while (!(WS_WORK_AREAS.WFIM_SEGURAVG == "S"))
            {

                M_1000_PROCESSA_VGSOLFAT_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM M_0000_FIM_VGSOLFAT */

            M_0000_FIM_VGSOLFAT();

        }

        [StopWatch]
        /*" M-0000-FIM-VGSOLFAT */
        private void M_0000_FIM_VGSOLFAT(bool isPerform = false)
        {
            /*" -535- MOVE 'COMMIT WORK VGSOLFAT ' TO COMANDO. */
            _.Move("COMMIT WORK VGSOLFAT ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -535- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -538- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -539- DISPLAY '   ESTATISTICA DE PROCESSAMENTO SOLITA FATURA   ' . */
            _.Display($"   ESTATISTICA DE PROCESSAMENTO SOLITA FATURA   ");

            /*" -540- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -542- DISPLAY 'LIDOS SOLICITA...................... ' AC-L-SOLICITA */
            _.Display($"LIDOS SOLICITA...................... {WS_WORK_AREAS.AC_L_SOLICITA}");

            /*" -544- DISPLAY 'REJEITADOS.......................... ' CONT-SOLICT-RJTA */
            _.Display($"REJEITADOS.......................... {CONT_SOLICT_RJTA}");

            /*" -545- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -547- DISPLAY 'QUANT. DE RISCO CRITICO............. ' WS-QT-RISCO-CRITICO */
            _.Display($"QUANT. DE RISCO CRITICO............. {WS_QT_RISCO_CRITICO}");

            /*" -549- DISPLAY 'QUANT. EM ANALISE RISCO............. ' WS-QT-EM-CRITICA */
            _.Display($"QUANT. EM ANALISE RISCO............. {WS_QT_EM_CRITICA}");

            /*" -551- DISPLAY 'QUANT. EMISSOES C/ AVAL. DE RISCO... ' WS-QT-EMISSAO-C-RISCO */
            _.Display($"QUANT. EMISSOES C/ AVAL. DE RISCO... {WS_QT_EMISSAO_C_RISCO}");

            /*" -553- DISPLAY 'QUANT. EMISSOES S/ AVAL. DE RISCO... ' WS-QT-EMISSAO-S-RISCO */
            _.Display($"QUANT. EMISSOES S/ AVAL. DE RISCO... {WS_QT_EMISSAO_S_RISCO}");

            /*" -555- DISPLAY 'QUANT. EMITIDAS APOS ANALISE RISCO.. ' WS-QT-LIBERADO-EMISSAO */
            _.Display($"QUANT. EMITIDAS APOS ANALISE RISCO.. {WS_QT_LIBERADO_EMISSAO}");

            /*" -557- DISPLAY 'QUANT. AE MANUAL SEM CLASSIF. RISCO. ' WS-QT-MANUAL-S-RISCO */
            _.Display($"QUANT. AE MANUAL SEM CLASSIF. RISCO. {WS_QT_MANUAL_S_RISCO}");

            /*" -558- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -560- DISPLAY 'INCL. PROPOSTAVA.................... ' AC-I-PROPOSTAVA */
            _.Display($"INCL. PROPOSTAVA.................... {WS_WORK_AREAS.AC_I_PROPOSTAVA}");

            /*" -562- DISPLAY 'INCL. COBERPROPVA................... ' AC-I-COBERPROPVA */
            _.Display($"INCL. COBERPROPVA................... {WS_WORK_AREAS.AC_I_COBERPROPVA}");

            /*" -564- DISPLAY 'INCL. OPCAOPAGVA.................... ' AC-I-OPCAOPAGVA */
            _.Display($"INCL. OPCAOPAGVA.................... {WS_WORK_AREAS.AC_I_OPCAOPAGVA}");

            /*" -566- DISPLAY 'INCL. PARCELVA...................... ' AC-I-PARCELVA. */
            _.Display($"INCL. PARCELVA...................... {WS_WORK_AREAS.AC_I_PARCELVA}");

            /*" -568- DISPLAY 'INCL. HISTCOBVA..................... ' AC-I-HISTCOBVA. */
            _.Display($"INCL. HISTCOBVA..................... {WS_WORK_AREAS.AC_I_HISTCOBVA}");

            /*" -570- DISPLAY 'INCL. HISTCTAVA..................... ' AC-I-HISTCTAVA. */
            _.Display($"INCL. HISTCTAVA..................... {WS_WORK_AREAS.AC_I_HISTCTAVA}");

            /*" -572- DISPLAY 'INCL. HISTCTABIL.................... ' AC-I-HISTCTABI. */
            _.Display($"INCL. HISTCTABIL.................... {WS_WORK_AREAS.AC_I_HISTCTABI}");

            /*" -574- DISPLAY 'INCL. CONVENIOSVG................... ' AC-I-CONVEVG. */
            _.Display($"INCL. CONVENIOSVG................... {WS_WORK_AREAS.AC_I_CONVEVG}");

            /*" -576- DISPLAY 'INCL. PRODUTOSVG.................... ' AC-I-PRODUVG. */
            _.Display($"INCL. PRODUTOSVG.................... {WS_WORK_AREAS.AC_I_PRODUVG}");

            /*" -578- DISPLAY 'INCL. PORTALPJ...................... ' AC-I-PORTALPJ. */
            _.Display($"INCL. PORTALPJ...................... {WS_WORK_AREAS.AC_I_PORTALPJ}");

            /*" -578- PERFORM 0000-INI-PROCESSA-PROPOVA. */

            M_0000_INI_PROCESSA_PROPOVA(true);

        }

        [StopWatch]
        /*" M-0000-INI-PROCESSA-PROPOVA */
        private void M_0000_INI_PROCESSA_PROPOVA(bool isPerform = false)
        {
            /*" -582- DISPLAY '   ' */
            _.Display($"   ");

            /*" -583- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -584- DISPLAY 'VERIFICAR PAGAMENTO RCAP P/ ALTERAR SIT APOLICE ' */
            _.Display($"VERIFICAR PAGAMENTO RCAP P/ ALTERAR SIT APOLICE ");

            /*" -585- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -586- DISPLAY '   ' */
            _.Display($"   ");

            /*" -587- DISPLAY '   ' */
            _.Display($"   ");

            /*" -588- DISPLAY '   ' */
            _.Display($"   ");

            /*" -590- PERFORM 5000-DECLARA-PROPOVA-CRTCA */

            M_5000_DECLARA_PROPOVA_CRTCA_SECTION();

            /*" -592- PERFORM 5100-FETCH-PROPOVA-CRTCA */

            M_5100_FETCH_PROPOVA_CRTCA_SECTION();

            /*" -593- IF (WFIM-PROPOVA-CRTCA NOT EQUAL SPACES) */

            if ((!WS_WORK_AREAS.WFIM_PROPOVA_CRTCA.IsEmpty()))
            {

                /*" -594- DISPLAY '*** SEM MOVIMENTO PROPOSTAS EM CRITICA' */
                _.Display($"*** SEM MOVIMENTO PROPOSTAS EM CRITICA");

                /*" -596- END-IF. */
            }


            /*" -598- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -600- DISPLAY '**PROCESSA PROPOSTAS EM CRITICA... ' WS-TIME. */
            _.Display($"**PROCESSA PROPOSTAS EM CRITICA... {WS_WORK_AREAS.WS_TIME}");

            /*" -603- PERFORM 5500-PROCESSA-PROPOVA-CRTCA UNTIL WFIM-PROPOVA-CRTCA EQUAL 'S' . */

            while (!(WS_WORK_AREAS.WFIM_PROPOVA_CRTCA == "S"))
            {

                M_5500_PROCESSA_PROPOVA_CRTCA_SECTION();
            }

            /*" -605- MOVE 'COMMIT WORK PROP EM CRITICA' TO COMANDO. */
            _.Move("COMMIT WORK PROP EM CRITICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -605- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -608- DISPLAY '   ' */
            _.Display($"   ");

            /*" -609- DISPLAY '   ' */
            _.Display($"   ");

            /*" -610- DISPLAY '   ' */
            _.Display($"   ");

            /*" -611- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -612- DISPLAY '  ESTATISTICA DE VERIFICACAO DE PAGAMENTO RCAP  ' . */
            _.Display($"  ESTATISTICA DE VERIFICACAO DE PAGAMENTO RCAP  ");

            /*" -613- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -615- DISPLAY 'LIDOS PENDENTE PGMTO................ ' AC-L-PROP-CRT */
            _.Display($"LIDOS PENDENTE PGMTO................ {WS_WORK_AREAS.AC_L_PROP_CRT}");

            /*" -617- DISPLAY 'INTEGRADOS APOS PGMTO............... ' WS-CONT-INTEGRADO */
            _.Display($"INTEGRADOS APOS PGMTO............... {WS_WORK_AREAS.WS_CONT_INTEGRADO}");

            /*" -619- DISPLAY 'CONTINUA SEM PAGAMENTO.............. ' WS-CONT-TEMERRO */
            _.Display($"CONTINUA SEM PAGAMENTO.............. {WS_WORK_AREAS.WS_CONT_TEMERRO}");

            /*" -620- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -621- DISPLAY '                TERMINO NORMAL                  ' . */
            _.Display($"                TERMINO NORMAL                  ");

            /*" -623- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -625- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -625- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_FIM*/

        [StopWatch]
        /*" M-0889-SELECT-SISTEMAS-SECTION */
        private void M_0889_SELECT_SISTEMAS_SECTION()
        {
            /*" -635- MOVE '0889' TO PARAGRAFO. */
            _.Move("0889", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -637- MOVE 'SELECT SISTEMAS' TO COMANDO. */
            _.Move("SELECT SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -647- PERFORM M_0889_SELECT_SISTEMAS_DB_SELECT_1 */

            M_0889_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -650- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -651- DISPLAY '0889 - PROBLEMAS SELECT SISTEMAS - VG ..' */
                _.Display($"0889 - PROBLEMAS SELECT SISTEMAS - VG ..");

                /*" -652- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -652- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0889-SELECT-SISTEMAS-DB-SELECT-1 */
        public void M_0889_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -647- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO - 1 MONTH, DATA_MOV_ABERTO - 6 MONTH INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-ANTERIOR, :SISTEMAS-DATA-MOV-6MONTH FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

            var m_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(m_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATA_ANTERIOR, SISTEMAS_DATA_ANTERIOR);
                _.Move(executed_1.SISTEMAS_DATA_MOV_6MONTH, SISTEMAS_DATA_MOV_6MONTH);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0889_FIM*/

        [StopWatch]
        /*" M-0900-DECLA-VGSOLFAT-SECTION */
        private void M_0900_DECLA_VGSOLFAT_SECTION()
        {
            /*" -661- MOVE '0900' TO PARAGRAFO. */
            _.Move("0900", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -663- MOVE 'DECLARE CSOLICITA' TO COMANDO. */
            _.Move("DECLARE CSOLICITA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -665- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -667- DISPLAY 'INICIO DECLARE CSOLICITA.. ' WS-TIME. */
            _.Display($"INICIO DECLARE CSOLICITA.. {WS_WORK_AREAS.WS_TIME}");

            /*" -700- PERFORM M_0900_DECLA_VGSOLFAT_DB_DECLARE_1 */

            M_0900_DECLA_VGSOLFAT_DB_DECLARE_1();

            /*" -705- PERFORM M_0900_DECLA_VGSOLFAT_DB_OPEN_1 */

            M_0900_DECLA_VGSOLFAT_DB_OPEN_1();

            /*" -708- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -709- DISPLAY '0900 - PROBLEMAS DECLARE VG_SOLICITA_FATURA' */
                _.Display($"0900 - PROBLEMAS DECLARE VG_SOLICITA_FATURA");

                /*" -710- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -711- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -713- END-IF. */
            }


            /*" -715- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -715- DISPLAY 'FINAL DECLARE CSOLICITA.. ' WS-TIME. */
            _.Display($"FINAL DECLARE CSOLICITA.. {WS_WORK_AREAS.WS_TIME}");

        }

        [StopWatch]
        /*" M-0900-DECLA-VGSOLFAT-DB-DECLARE-1 */
        public void M_0900_DECLA_VGSOLFAT_DB_DECLARE_1()
        {
            /*" -700- EXEC SQL DECLARE CSOLICITA CURSOR WITH HOLD FOR SELECT NUM_APOLICE, COD_SUBGRUPO, DATA_SOLICITACAO, DIA_DEBITO, OPCAOPAG, QUANT_VIDAS, CAP_BAS_SEGURADO, PRM_VG, PRM_AP, PRM_VG + PRM_AP, DTVENCTO_FATURA, COD_FONTE, NUM_TITULO, DT_QUITBCO_TITULO, VALOR_TITULO, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, VALUE(COD_USUARIO, '  ' ) FROM SEGUROS.VG_SOLICITA_FATURA WHERE SIT_SOLICITA = '0' AND DATA_SOLICITACAO > :SISTEMAS-DATA-MOV-6MONTH AND NUM_APOLICE NOT IN (SELECT DISTINCT NUM_APOLICE FROM SEGUROS.VG_PRODUTO_SIAS WHERE COD_PRODUTO IN (9329, 9343, 8205, 8209, :JVPRD8205, :JVPRD8209, :JVPRD9329, :JVPRD9343 ) ) FOR UPDATE OF SIT_SOLICITA END-EXEC. */
            CSOLICITA = new VG0001B_CSOLICITA(true);
            string GetQuery_CSOLICITA()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							DATA_SOLICITACAO
							, 
							DIA_DEBITO
							, 
							OPCAOPAG
							, 
							QUANT_VIDAS
							, 
							CAP_BAS_SEGURADO
							, 
							PRM_VG
							, 
							PRM_AP
							, 
							PRM_VG + PRM_AP
							, 
							DTVENCTO_FATURA
							, 
							COD_FONTE
							, 
							NUM_TITULO
							, 
							DT_QUITBCO_TITULO
							, 
							VALOR_TITULO
							, 
							AGECTADEB
							, 
							OPRCTADEB
							, 
							NUMCTADEB
							, 
							DIGCTADEB
							, 
							VALUE(COD_USUARIO
							, ' ' ) 
							FROM SEGUROS.VG_SOLICITA_FATURA 
							WHERE SIT_SOLICITA = '0' 
							AND DATA_SOLICITACAO > '{SISTEMAS_DATA_MOV_6MONTH}' 
							AND NUM_APOLICE NOT IN 
							(SELECT DISTINCT NUM_APOLICE 
							FROM SEGUROS.VG_PRODUTO_SIAS 
							WHERE COD_PRODUTO IN (9329
							, 9343
							, 8205
							, 8209
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD8205}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8209}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD9329}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9343}' 
							) )";

                return query;
            }
            CSOLICITA.GetQueryEvent += GetQuery_CSOLICITA;

        }

        [StopWatch]
        /*" M-0900-DECLA-VGSOLFAT-DB-OPEN-1 */
        public void M_0900_DECLA_VGSOLFAT_DB_OPEN_1()
        {
            /*" -705- EXEC SQL OPEN CSOLICITA END-EXEC. */

            CSOLICITA.Open();

        }

        [StopWatch]
        /*" M-1120-BAIXA-RCAP-DB-DECLARE-1 */
        public void M_1120_BAIXA_RCAP_DB_DECLARE_1()
        {
            /*" -1613- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT COD_FONTE , NUM_RCAP , NUM_RCAP_COMPLEMEN, COD_OPERACAO , DATA_MOVIMENTO , HORA_OPERACAO , SIT_REGISTRO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , VAL_RCAP , DATA_RCAP , DATA_CADASTRAMENTO, SIT_CONTABIL FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :RCAPS-COD-FONTE AND NUM_RCAP = :RCAPS-NUM-RCAP AND (COD_OPERACAO BETWEEN 100 AND 199 OR COD_OPERACAO BETWEEN 300 AND 399) AND SIT_REGISTRO = '0' WITH UR END-EXEC. */
            V1RCAPCOMP = new VG0001B_V1RCAPCOMP(true);
            string GetQuery_V1RCAPCOMP()
            {
                var query = @$"SELECT COD_FONTE
							, 
							NUM_RCAP
							, 
							NUM_RCAP_COMPLEMEN
							, 
							COD_OPERACAO
							, 
							DATA_MOVIMENTO
							, 
							HORA_OPERACAO
							, 
							SIT_REGISTRO
							, 
							BCO_AVISO
							, 
							AGE_AVISO
							, 
							NUM_AVISO_CREDITO
							, 
							VAL_RCAP
							, 
							DATA_RCAP
							, 
							DATA_CADASTRAMENTO
							, 
							SIT_CONTABIL 
							FROM SEGUROS.RCAP_COMPLEMENTAR 
							WHERE COD_FONTE = '{RCAPS.DCLRCAPS.RCAPS_COD_FONTE}' 
							AND NUM_RCAP = '{RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}' 
							AND (COD_OPERACAO BETWEEN 100 AND 199 
							OR COD_OPERACAO BETWEEN 300 AND 399) 
							AND SIT_REGISTRO = '0'";

                return query;
            }
            V1RCAPCOMP.GetQueryEvent += GetQuery_V1RCAPCOMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0900_FIM*/

        [StopWatch]
        /*" M-0910-FETCH-VGSOLFAT-SECTION */
        private void M_0910_FETCH_VGSOLFAT_SECTION()
        {
            /*" -725- MOVE '0910' TO PARAGRAFO. */
            _.Move("0910", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -727- MOVE 'FETCH CSOLICITA' TO COMANDO. */
            _.Move("FETCH CSOLICITA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -749- PERFORM M_0910_FETCH_VGSOLFAT_DB_FETCH_1 */

            M_0910_FETCH_VGSOLFAT_DB_FETCH_1();

            /*" -752- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -753- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -754- MOVE 'S' TO WFIM-SEGURAVG */
                    _.Move("S", WS_WORK_AREAS.WFIM_SEGURAVG);

                    /*" -754- PERFORM M_0910_FETCH_VGSOLFAT_DB_CLOSE_1 */

                    M_0910_FETCH_VGSOLFAT_DB_CLOSE_1();

                    /*" -756- GO TO 0910-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0910_FIM*/ //GOTO
                    return;

                    /*" -757- ELSE */
                }
                else
                {


                    /*" -757- PERFORM M_0910_FETCH_VGSOLFAT_DB_CLOSE_2 */

                    M_0910_FETCH_VGSOLFAT_DB_CLOSE_2();

                    /*" -759- DISPLAY '0900 - PROBLEMAS NO FETCH VG_SOLICITA_FATURA' */
                    _.Display($"0900 - PROBLEMAS NO FETCH VG_SOLICITA_FATURA");

                    /*" -760- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -761- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -762- END-IF */
                }


                /*" -763- ELSE */
            }
            else
            {


                /*" -765- ADD 1 TO AC-L-SOLICITA AC-W-CONTA */
                WS_WORK_AREAS.AC_L_SOLICITA.Value = WS_WORK_AREAS.AC_L_SOLICITA + 1;
                WS_WORK_AREAS.AC_W_CONTA.Value = WS_WORK_AREAS.AC_W_CONTA + 1;

                /*" -766- ADD 1 TO AC-L-COMMIT */
                WS_WORK_AREAS.AC_L_COMMIT.Value = WS_WORK_AREAS.AC_L_COMMIT + 1;

                /*" -768- END-IF. */
            }


            /*" -769- IF (AC-W-CONTA > 999) */

            if ((WS_WORK_AREAS.AC_W_CONTA > 999))
            {

                /*" -770- MOVE ZEROS TO AC-W-CONTA */
                _.Move(0, WS_WORK_AREAS.AC_W_CONTA);

                /*" -771- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

                /*" -772- DISPLAY 'LIDOS VG_SOLICITA ' AC-L-SOLICITA ' ' WS-TIME */

                $"LIDOS VG_SOLICITA {WS_WORK_AREAS.AC_L_SOLICITA} {WS_WORK_AREAS.WS_TIME}"
                .Display();

                /*" -774- END-IF. */
            }


            /*" -776- IF (VGSOLFAT-CAP-BAS-SEGURADO EQUAL ZEROS) OR (VGSOLFAT-QUANT-VIDAS EQUAL ZEROS) */

            if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO == 00) || (VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_QUANT_VIDAS == 00))
            {

                /*" -777- DISPLAY 'SOLICITACAO NAO EFETUADA - PENDENTE ' */
                _.Display($"SOLICITACAO NAO EFETUADA - PENDENTE ");

                /*" -778- DISPLAY 'NUM_APOLICE  ' VGSOLFAT-NUM-APOLICE */
                _.Display($"NUM_APOLICE  {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE}");

                /*" -779- DISPLAY 'COD_SUBGRUPO ' VGSOLFAT-COD-SUBGRUPO */
                _.Display($"COD_SUBGRUPO {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}");

                /*" -780- GO TO 0910-FETCH-VGSOLFAT */
                new Task(() => M_0910_FETCH_VGSOLFAT_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -782- END-IF. */
            }


            /*" -783- INITIALIZE WORK-TAB-ERROS-CERT */
            _.Initialize(
                WORK_TAB_ERROS_CERT
            );

            /*" -785- MOVE ZEROS TO WS-I-ERRO */
            _.Move(0, WS_I_ERRO);

            /*" -787- IF (VGSOLFAT-PRM-VG EQUAL ZEROS) AND (VGSOLFAT-PRM-AP EQUAL ZEROS) */

            if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG == 00) && (VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_AP == 00))
            {

                /*" -788- DISPLAY 'SOLICITACAO NAO EFETUADA - PENDENTE ' */
                _.Display($"SOLICITACAO NAO EFETUADA - PENDENTE ");

                /*" -789- DISPLAY 'NUM_APOLICE  ' VGSOLFAT-NUM-APOLICE */
                _.Display($"NUM_APOLICE  {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE}");

                /*" -790- DISPLAY 'COD_SUBGRUPO ' VGSOLFAT-COD-SUBGRUPO */
                _.Display($"COD_SUBGRUPO {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}");

                /*" -791- GO TO 0910-FETCH-VGSOLFAT */
                new Task(() => M_0910_FETCH_VGSOLFAT_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -791- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0910-FETCH-VGSOLFAT-DB-FETCH-1 */
        public void M_0910_FETCH_VGSOLFAT_DB_FETCH_1()
        {
            /*" -749- EXEC SQL FETCH CSOLICITA INTO :VGSOLFAT-NUM-APOLICE, :VGSOLFAT-COD-SUBGRUPO, :VGSOLFAT-DATA-SOLICITACAO, :VGSOLFAT-DIA-DEBITO, :VGSOLFAT-OPCAOPAG, :VGSOLFAT-QUANT-VIDAS, :VGSOLFAT-CAP-BAS-SEGURADO, :VGSOLFAT-PRM-VG, :VGSOLFAT-PRM-AP, :VGSOLFAT-PRM-TOTAL, :VGSOLFAT-DTVENCTO-FATURA, :VGSOLFAT-COD-FONTE, :VGSOLFAT-NUM-TITULO, :VGSOLFAT-DT-QUITBCO-TITULO:VIND-DTQITBCO, :VGSOLFAT-VALOR-TITULO, :VGSOLFAT-AGECTADEB:VIND-AGECTADEB, :VGSOLFAT-OPRCTADEB:VIND-OPRCTADEB, :VGSOLFAT-NUMCTADEB:VIND-NUMCTADEB, :VGSOLFAT-DIGCTADEB:VIND-DIGCTADEB, :VGSOLFAT-COD-USUARIO END-EXEC. */

            if (CSOLICITA.Fetch())
            {
                _.Move(CSOLICITA.VGSOLFAT_NUM_APOLICE, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE);
                _.Move(CSOLICITA.VGSOLFAT_COD_SUBGRUPO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO);
                _.Move(CSOLICITA.VGSOLFAT_DATA_SOLICITACAO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DATA_SOLICITACAO);
                _.Move(CSOLICITA.VGSOLFAT_DIA_DEBITO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DIA_DEBITO);
                _.Move(CSOLICITA.VGSOLFAT_OPCAOPAG, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_OPCAOPAG);
                _.Move(CSOLICITA.VGSOLFAT_QUANT_VIDAS, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_QUANT_VIDAS);
                _.Move(CSOLICITA.VGSOLFAT_CAP_BAS_SEGURADO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO);
                _.Move(CSOLICITA.VGSOLFAT_PRM_VG, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG);
                _.Move(CSOLICITA.VGSOLFAT_PRM_AP, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_AP);
                _.Move(CSOLICITA.VGSOLFAT_PRM_TOTAL, VGSOLFAT_PRM_TOTAL);
                _.Move(CSOLICITA.VGSOLFAT_DTVENCTO_FATURA, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA);
                _.Move(CSOLICITA.VGSOLFAT_COD_FONTE, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_FONTE);
                _.Move(CSOLICITA.VGSOLFAT_NUM_TITULO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO);
                _.Move(CSOLICITA.VGSOLFAT_DT_QUITBCO_TITULO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DT_QUITBCO_TITULO);
                _.Move(CSOLICITA.VIND_DTQITBCO, VIND_DTQITBCO);
                _.Move(CSOLICITA.VGSOLFAT_VALOR_TITULO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_VALOR_TITULO);
                _.Move(CSOLICITA.VGSOLFAT_AGECTADEB, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_AGECTADEB);
                _.Move(CSOLICITA.VIND_AGECTADEB, VIND_AGECTADEB);
                _.Move(CSOLICITA.VGSOLFAT_OPRCTADEB, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_OPRCTADEB);
                _.Move(CSOLICITA.VIND_OPRCTADEB, VIND_OPRCTADEB);
                _.Move(CSOLICITA.VGSOLFAT_NUMCTADEB, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUMCTADEB);
                _.Move(CSOLICITA.VIND_NUMCTADEB, VIND_NUMCTADEB);
                _.Move(CSOLICITA.VGSOLFAT_DIGCTADEB, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DIGCTADEB);
                _.Move(CSOLICITA.VIND_DIGCTADEB, VIND_DIGCTADEB);
                _.Move(CSOLICITA.VGSOLFAT_COD_USUARIO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_USUARIO);
            }

        }

        [StopWatch]
        /*" M-0910-FETCH-VGSOLFAT-DB-CLOSE-1 */
        public void M_0910_FETCH_VGSOLFAT_DB_CLOSE_1()
        {
            /*" -754- EXEC SQL CLOSE CSOLICITA END-EXEC */

            CSOLICITA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0910_FIM*/

        [StopWatch]
        /*" M-0910-FETCH-VGSOLFAT-DB-CLOSE-2 */
        public void M_0910_FETCH_VGSOLFAT_DB_CLOSE_2()
        {
            /*" -757- EXEC SQL CLOSE CSOLICITA END-EXEC */

            CSOLICITA.Close();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-VGSOLFAT-SECTION */
        private void M_1000_PROCESSA_VGSOLFAT_SECTION()
        {
            /*" -800- MOVE '1000' TO PARAGRAFO. */
            _.Move("1000", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -802- MOVE 'SELECT SUBGRUPOS_VGAP' TO COMANDO. */
            _.Move("SELECT SUBGRUPOS_VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -803- MOVE ZEROS TO VGCOMTRO-NUM-PROPOSTA-SIVPF. */
            _.Move(0, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF);

            /*" -807- MOVE ZEROS TO VGCOMTRO-NUM-CARTAO-CREDITO. */
            _.Move(0, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_CARTAO_CREDITO);

            /*" -833- PERFORM M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1 */

            M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1();

            /*" -836- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -837- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -839- DISPLAY 'SUBGRUPO NAO ESTA ATIVO ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO */

                    $"SUBGRUPO NAO ESTA ATIVO {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}"
                    .Display();

                    /*" -840- GO TO 1000-NEXT */

                    M_1000_NEXT(); //GOTO
                    return;

                    /*" -841- ELSE */
                }
                else
                {


                    /*" -843- DISPLAY 'PROBLEMAS NA LEITURA DO SUBGRUPO ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO */

                    $"PROBLEMAS NA LEITURA DO SUBGRUPO {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}"
                    .Display();

                    /*" -844- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -845- END-IF */
                }


                /*" -848- END-IF. */
            }


            /*" -850- MOVE VGSOLFAT-DTVENCTO-FATURA TO WS-DTVENC-1PARC */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA, WS_DTVENC_1PARC);

            /*" -851- IF (VGSOLFAT-NUM-APOLICE EQUAL 109300002554) */

            if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE == 109300002554))
            {

                /*" -853- MOVE SUBGVGAP-DATA-INIVIGENCIA(1:7) TO VGSOLFAT-DTVENCTO-FATURA (1:7) */
                _.MoveAtPosition(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA.Substring(1, 7), VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA, 1, 7);

                /*" -857- END-IF. */
            }


            /*" -859- MOVE 'SELECT ENDOSSOS' TO COMANDO. */
            _.Move("SELECT ENDOSSOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -876- PERFORM M_1000_PROCESSA_VGSOLFAT_DB_SELECT_2 */

            M_1000_PROCESSA_VGSOLFAT_DB_SELECT_2();

            /*" -879- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -880- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -882- DISPLAY '1000 - APOLICE NAO CADASTRADA ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO */

                    $"1000 - APOLICE NAO CADASTRADA {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}"
                    .Display();

                    /*" -883- GO TO 1000-NEXT */

                    M_1000_NEXT(); //GOTO
                    return;

                    /*" -884- ELSE */
                }
                else
                {


                    /*" -886- DISPLAY '1000 - PROBLEMAS NA LEITURA DA ENDOSSOS  ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO */

                    $"1000 - PROBLEMAS NA LEITURA DA ENDOSSOS  {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}"
                    .Display();

                    /*" -887- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -888- END-IF */
                }


                /*" -892- END-IF. */
            }


            /*" -894- MOVE 'SELECT PROPOSTAS_VA' TO COMANDO. */
            _.Move("SELECT PROPOSTAS_VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -902- PERFORM M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3 */

            M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3();

            /*" -905- IF (SQLCODE EQUAL ZEROES) */

            if ((DB.SQLCODE == 00))
            {

                /*" -907- DISPLAY 'APOLICE/SUBGRUPO JA MIGRADO ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO */

                $"APOLICE/SUBGRUPO JA MIGRADO {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}"
                .Display();

                /*" -908- GO TO 1000-NEXT */

                M_1000_NEXT(); //GOTO
                return;

                /*" -909- ELSE */
            }
            else
            {


                /*" -910- IF (SQLCODE NOT EQUAL +100) */

                if ((DB.SQLCODE != +100))
                {

                    /*" -912- DISPLAY 'PROBLEMAS NA LEITURA DA PROPOSTAS_VA ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO */

                    $"PROBLEMAS NA LEITURA DA PROPOSTAS_VA {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}"
                    .Display();

                    /*" -913- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -914- END-IF */
                }


                /*" -918- END-IF. */
            }


            /*" -920- MOVE 'SELECT CLIENTES ' TO COMANDO. */
            _.Move("SELECT CLIENTES ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -928- PERFORM M_1000_PROCESSA_VGSOLFAT_DB_SELECT_4 */

            M_1000_PROCESSA_VGSOLFAT_DB_SELECT_4();

            /*" -931- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -933- DISPLAY 'CLIENTE NAO CADASTRADO  ' SUBGVGAP-COD-CLIENTE */
                _.Display($"CLIENTE NAO CADASTRADO  {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE}");

                /*" -934- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -935- ELSE */
            }
            else
            {


                /*" -936- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

                if ((!DB.SQLCODE.In("00", "+100")))
                {

                    /*" -938- DISPLAY 'PROBLEMAS NA LEITURA DA CLIENTES ' SUBGVGAP-COD-CLIENTE */
                    _.Display($"PROBLEMAS NA LEITURA DA CLIENTES {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE}");

                    /*" -939- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -940- END-IF */
                }


                /*" -944- END-IF. */
            }


            /*" -945- MOVE 'SELECT VG_PRODUTO_SIAS' TO COMANDO. */
            _.Move("SELECT VG_PRODUTO_SIAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -952- PERFORM M_1000_PROCESSA_VGSOLFAT_DB_SELECT_5 */

            M_1000_PROCESSA_VGSOLFAT_DB_SELECT_5();

            /*" -955- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -956- MOVE 'EMPRE ' TO WS-ORIG-PRODU */
                _.Move("EMPRE ", WS_WORK_AREAS.WS_ORIG_PRODU);

                /*" -957- ELSE */
            }
            else
            {


                /*" -958- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -959- IF (VGSOLFAT-NUM-APOLICE = 109300000799) */

                    if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE == 109300000799))
                    {

                        /*" -960- MOVE 'ESPE1 ' TO WS-ORIG-PRODU */
                        _.Move("ESPE1 ", WS_WORK_AREAS.WS_ORIG_PRODU);

                        /*" -961- ELSE */
                    }
                    else
                    {


                        /*" -962- MOVE 'ESPEC ' TO WS-ORIG-PRODU */
                        _.Move("ESPEC ", WS_WORK_AREAS.WS_ORIG_PRODU);

                        /*" -963- END-IF */
                    }


                    /*" -964- MOVE ZEROS TO VGPROSIA-COD-PRODUTO-EMP */
                    _.Move(0, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP);

                    /*" -965- ELSE */
                }
                else
                {


                    /*" -966- IF (SQLCODE NOT EQUAL ZEROS) */

                    if ((DB.SQLCODE != 00))
                    {

                        /*" -967- DISPLAY '0889 - PROBLEMAS SELECT VG_PRODUTO_SIAS...' */
                        _.Display($"0889 - PROBLEMAS SELECT VG_PRODUTO_SIAS...");

                        /*" -968- DISPLAY '0889 - SELECT COD_PRODUTO_EMP ............' */
                        _.Display($"0889 - SELECT COD_PRODUTO_EMP ............");

                        /*" -969- DISPLAY 'SQLCODE - ' SQLCODE */
                        _.Display($"SQLCODE - {DB.SQLCODE}");

                        /*" -970- DISPLAY 'APOLICE - ' VGSOLFAT-NUM-APOLICE */
                        _.Display($"APOLICE - {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE}");

                        /*" -971- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -972- END-IF */
                    }


                    /*" -973- END-IF */
                }


                /*" -977- END-IF. */
            }


            /*" -979- MOVE 'SELECT TERMO_ADESAO ' TO COMANDO. */
            _.Move("SELECT TERMO_ADESAO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -996- PERFORM M_1000_PROCESSA_VGSOLFAT_DB_SELECT_6 */

            M_1000_PROCESSA_VGSOLFAT_DB_SELECT_6();

            /*" -999- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1000- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1001- IF (VGPROSIA-COD-PRODUTO-EMP > ZEROS) */

                    if ((VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP > 00))
                    {

                        /*" -1002- DISPLAY '*---------------------------------------*' */
                        _.Display($"*---------------------------------------*");

                        /*" -1003- DISPLAY 'TEM PRODUTO NA VG_PRODUTO_SIAS  MAS' */
                        _.Display($"TEM PRODUTO NA VG_PRODUTO_SIAS  MAS");

                        /*" -1005- DISPLAY 'TERMO DE ADESAO NAO CADASTRADO  ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO */

                        $"TERMO DE ADESAO NAO CADASTRADO  {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}"
                        .Display();

                        /*" -1006- DISPLAY 'PRODUTO.... = ' VGPROSIA-COD-PRODUTO-EMP */
                        _.Display($"PRODUTO.... = {VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP}");

                        /*" -1008- DISPLAY '*--------------------------------------*' */
                        _.Display($"*--------------------------------------*");

                        /*" -1009- DISPLAY '*** SOLICITACAO REJEITADA ***' */
                        _.Display($"*** SOLICITACAO REJEITADA ***");

                        /*" -1010- ADD 1 TO CONT-SOLICT-RJTA */
                        CONT_SOLICT_RJTA.Value = CONT_SOLICT_RJTA + 1;

                        /*" -1011- GO TO 1000-NEXT */

                        M_1000_NEXT(); //GOTO
                        return;

                        /*" -1012- ELSE */
                    }
                    else
                    {


                        /*" -1018- MOVE ZEROS TO TERMOADE-NUM-TERMO TERMOADE-COD-AGENCIA-VEN TERMOADE-OPERACAO-CONTA-VEN TERMOADE-NUM-CONTA-VEN TERMOADE-DIG-CONTA-VEN TERMOADE-NUM-MATRICULA-VEN */
                        _.Move(0, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_OPERACAO_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DIG_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN);

                        /*" -1019- END-IF */
                    }


                    /*" -1020- ELSE */
                }
                else
                {


                    /*" -1022- DISPLAY 'PROBLEMAS NA LEITURA DA TERMO ADESAO' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO */

                    $"PROBLEMAS NA LEITURA DA TERMO ADESAO{VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}"
                    .Display();

                    /*" -1023- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1024- END-IF */
                }


                /*" -1028- END-IF. */
            }


            /*" -1031- MOVE ZEROS TO RCAPS-VAL-RCAP WS-FLAG-PROP-MANUAL */
            _.Move(0, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, WS_FLAG_PROP_MANUAL);

            /*" -1032- IF (VGSOLFAT-COD-USUARIO(1:7) EQUAL 'VG2600B' ) */

            if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_USUARIO.Substring(1, 7) == "VG2600B"))
            {

                /*" -1033- DISPLAY 'EH PROPOSTA DO PORTAL PJ ' */
                _.Display($"EH PROPOSTA DO PORTAL PJ ");

                /*" -1034- MOVE ZEROS TO RCAPS-AGE-COBRANCA */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);

                /*" -1035- PERFORM 1100-SELECT-NUMEROS */

                M_1100_SELECT_NUMEROS_SECTION();

                /*" -1037- MOVE H-NUM-CERTIFICADO TO NUMEROUT-NUM-CERT-VGAP */
                _.Move(H_NUM_CERTIFICADO, NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP);

                /*" -1038- ADD 1 TO AC-I-PORTALPJ */
                WS_WORK_AREAS.AC_I_PORTALPJ.Value = WS_WORK_AREAS.AC_I_PORTALPJ + 1;

                /*" -1039- MOVE '1' TO PROPOVA-SIT-REGISTRO */
                _.Move("1", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                /*" -1040- MOVE 'N' TO WS-TEM-RCAP */
                _.Move("N", WS_TEM_RCAP);

                /*" -1041- MOVE ZEROS TO RCAPS-NUM-RCAP */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);

                /*" -1042- ELSE */
            }
            else
            {


                /*" -1043- IF (VGSOLFAT-NUM-TITULO > ZEROS) */

                if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO > 00))
                {

                    /*" -1044- PERFORM 1200-SELECT-RCAP-TITULO */

                    M_1200_SELECT_RCAP_TITULO_SECTION();

                    /*" -1045- ELSE */
                }
                else
                {


                    /*" -1046- MOVE 'N' TO WS-TEM-RCAP */
                    _.Move("N", WS_TEM_RCAP);

                    /*" -1048- END-IF */
                }


                /*" -1049- MOVE '3' TO PROPOVA-SIT-REGISTRO */
                _.Move("3", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                /*" -1050- IF (WS-TEM-RCAP EQUAL 'N' ) */

                if ((WS_TEM_RCAP == "N"))
                {

                    /*" -1051- MOVE ZEROS TO RCAPS-AGE-COBRANCA */
                    _.Move(0, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);

                    /*" -1052- PERFORM 1100-SELECT-NUMEROS */

                    M_1100_SELECT_NUMEROS_SECTION();

                    /*" -1053- MOVE H-NUM-CERTIFICADO TO NUMEROUT-NUM-CERT-VGAP */
                    _.Move(H_NUM_CERTIFICADO, NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP);

                    /*" -1054- ELSE */
                }
                else
                {


                    /*" -1055- MOVE VGSOLFAT-NUM-TITULO TO NUMEROUT-NUM-CERT-VGAP */
                    _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO, NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP);

                    /*" -1057- END-IF */
                }


                /*" -1059- DISPLAY 'EH PROPOSTA MANUAL >> ' NUMEROUT-NUM-CERT-VGAP ' >> ' WS-TEM-RCAP ' >> ' VGSOLFAT-NUM-TITULO */

                $"EH PROPOSTA MANUAL >> {NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP} >> {WS_TEM_RCAP} >> {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO}"
                .Display();

                /*" -1060- MOVE 1 TO WS-FLAG-PROP-MANUAL */
                _.Move(1, WS_FLAG_PROP_MANUAL);

                /*" -1063- END-IF. */
            }


            /*" -1065- MOVE 'SELECT VG_COMPL_TERMO' TO COMANDO. */
            _.Move("SELECT VG_COMPL_TERMO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1073- PERFORM M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7 */

            M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7();

            /*" -1076- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1077- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1078- MOVE ZEROS TO VGCOMTRO-NUM-PROPOSTA-SIVPF */
                    _.Move(0, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF);

                    /*" -1079- MOVE ZEROS TO VGCOMTRO-NUM-CARTAO-CREDITO */
                    _.Move(0, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_CARTAO_CREDITO);

                    /*" -1080- ELSE */
                }
                else
                {


                    /*" -1083- DISPLAY 'PROBLEMAS NA LEITURA COMPL_TERMO    ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO ' ' TERMOADE-NUM-TERMO */

                    $"PROBLEMAS NA LEITURA COMPL_TERMO    {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO} {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}"
                    .Display();

                    /*" -1084- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1085- END-IF */
                }


                /*" -1087- END-IF. */
            }


            /*" -1090- MOVE VGCOMTRO-NUM-PROPOSTA-SIVPF TO PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -1091- IF (PROPOFID-NUM-PROPOSTA-SIVPF > ZEROS) */

            if ((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF > 00))
            {

                /*" -1092- MOVE 'SELECT CONVERSAO_SICOB' TO COMANDO */
                _.Move("SELECT CONVERSAO_SICOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1098- PERFORM M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8 */

                M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8();

                /*" -1101- IF (SQLCODE EQUAL ZEROS) */

                if ((DB.SQLCODE == 00))
                {

                    /*" -1102- MOVE PROPOFID-NUM-SICOB TO NUMEROUT-NUM-CERT-VGAP */
                    _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP);

                    /*" -1103- ELSE */
                }
                else
                {


                    /*" -1104- IF (SQLCODE NOT EQUAL +100) */

                    if ((DB.SQLCODE != +100))
                    {

                        /*" -1107- DISPLAY 'PROBLEMAS NA LEITURA CONVERSAO_SICOB ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO ' ' TERMOADE-NUM-TERMO ' ' PROPOFID-NUM-PROPOSTA-SIVPF */

                        $"PROBLEMAS NA LEITURA CONVERSAO_SICOB {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO} {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}"
                        .Display();

                        /*" -1108- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1109- END-IF */
                    }


                    /*" -1110- END-IF */
                }


                /*" -1114- END-IF. */
            }


            /*" -1115- IF VGPROSIA-COD-PRODUTO-EMP EQUAL 16 */

            if (VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP == 16)
            {

                /*" -1117- MOVE 'SELECT VG_FUNC_COBERTURA' TO COMANDO */
                _.Move("SELECT VG_FUNC_COBERTURA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1135- PERFORM M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9 */

                M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9();

                /*" -1138- IF (VGFUNCOB-VLR-PREMIO EQUAL ZEROES) */

                if ((VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_VLR_PREMIO == 00))
                {

                    /*" -1139- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1143- DISPLAY 'FUNCIONARIOS NAO LIBERADOS...' VGCOMTRO-NUM-PROPOSTA-SIVPF ' ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO */

                    $"FUNCIONARIOS NAO LIBERADOS...{VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}"
                    .Display();

                    /*" -1144- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1145- GO TO 1000-NEXT */

                    M_1000_NEXT(); //GOTO
                    return;

                    /*" -1146- END-IF */
                }


                /*" -1150- END-IF. */
            }


            /*" -1151- IF (VGSOLFAT-OPCAOPAG EQUAL '1' OR '2' ) */

            if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_OPCAOPAG.In("1", "2")))
            {

                /*" -1152- MOVE ZEROS TO HOST-IND */
                _.Move(0, HOST_IND);

                /*" -1153- MOVE VGSOLFAT-OPCAOPAG TO OPCPAGVI-OPCAO-PAGAMENTO */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_OPCAOPAG, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                /*" -1154- MOVE VGSOLFAT-AGECTADEB TO OPCPAGVI-COD-AGENCIA-DEBITO */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_AGECTADEB, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);

                /*" -1155- MOVE VGSOLFAT-OPRCTADEB TO OPCPAGVI-OPE-CONTA-DEBITO */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_OPRCTADEB, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);

                /*" -1156- MOVE VGSOLFAT-NUMCTADEB TO OPCPAGVI-NUM-CONTA-DEBITO */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUMCTADEB, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);

                /*" -1157- MOVE VGSOLFAT-DIGCTADEB TO OPCPAGVI-DIG-CONTA-DEBITO */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DIGCTADEB, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                /*" -1158- ELSE */
            }
            else
            {


                /*" -1159- IF (VGSOLFAT-OPCAOPAG EQUAL '3' ) */

                if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_OPCAOPAG == "3"))
                {

                    /*" -1160- MOVE VGSOLFAT-OPCAOPAG TO OPCPAGVI-OPCAO-PAGAMENTO */
                    _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_OPCAOPAG, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                    /*" -1161- MOVE -1 TO HOST-IND */
                    _.Move(-1, HOST_IND);

                    /*" -1165- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO */
                    _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                    /*" -1166- END-IF */
                }


                /*" -1170- END-IF. */
            }


            /*" -1172- MOVE VGSOLFAT-NUM-APOLICE TO LK-APOLICE. */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE, PARAMETROS.LK_APOLICE);

            /*" -1174- MOVE VGSOLFAT-COD-SUBGRUPO TO LK-SUBGRUPO. */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO, PARAMETROS.LK_SUBGRUPO);

            /*" -1179- MOVE ZEROES TO HISCOBPR-IMP-MORNATU HISCOBPR-PRMVG HISCOBPR-IMPMORACID HISCOBPR-PRMAP. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

            /*" -1201- MOVE ZEROES TO LK-IDADE LK-DATA-NASCIMENTO LK-SALARIO LK-PURO-MORTE-NATURAL LK-PURO-MORTE-ACIDENTAL LK-PURO-INV-PERMANENTE LK-PURO-ASS-MEDICA LK-PURO-DIARIA-HOSPITALAR LK-PURO-DIARIA-INTERNACAO LK-COBT-MORTE-NATURAL LK-COBT-MORTE-ACIDENTAL LK-COBT-INV-PERMANENTE LK-COBT-INV-POR-ACIDENTE LK-COBT-ASS-MEDICA LK-COBT-DIARIA-HOSPITALAR LK-COBT-DIARIA-INTERNACAO LK-PREM-MORTE-NATURAL LK-PREM-ACIDENTES-PESSOAIS LK-PREM-TOTAL LK-RETURN-CODE LK-MENSAGEM. */
            _.Move(0, PARAMETROS.LK_IDADE, PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO, PARAMETROS.LK_SALARIO, PARAMETROS.LK_PURO_MORTE_NATURAL, PARAMETROS.LK_PURO_MORTE_ACIDENTAL, PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_PURO_ASS_MEDICA, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR, PARAMETROS.LK_PURO_DIARIA_INTERNACAO, PARAMETROS.LK_COBT_MORTE_NATURAL, PARAMETROS.LK_COBT_MORTE_ACIDENTAL, PARAMETROS.LK_COBT_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_POR_ACIDENTE, PARAMETROS.LK_COBT_ASS_MEDICA, PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, PARAMETROS.LK_COBT_DIARIA_INTERNACAO, PARAMETROS.LK_PREM_MORTE_NATURAL, PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS, PARAMETROS.LK_PREM_TOTAL, PARAMETROS.LK_RETURN_CODE, PARAMETROS.LK_MENSAGEM);

            /*" -1203- MOVE 'SELECT MOEDAS_COTACAO' TO COMANDO. */
            _.Move("SELECT MOEDAS_COTACAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1211- PERFORM M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10 */

            M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10();

            /*" -1214- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1217- DISPLAY '1000 - PROBLEMA NA LEITURA DA MOEDA_COTACAO ' SQLCODE ' ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-DTVENCTO-FATURA */

                $"1000 - PROBLEMA NA LEITURA DA MOEDA_COTACAO {DB.SQLCODE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA}"
                .Display();

                /*" -1218- GO TO 1000-NEXT */

                M_1000_NEXT(); //GOTO
                return;

                /*" -1220- END-IF. */
            }


            /*" -1221- IF (VGSOLFAT-PRM-VG > ZEROES) */

            if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG > 00))
            {

                /*" -1223- MOVE VGSOLFAT-CAP-BAS-SEGURADO TO HISCOBPR-IMP-MORNATU */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

                /*" -1226- COMPUTE HISCOBPR-IMP-MORNATU = HISCOBPR-IMP-MORNATU * MOEDACOT-VAL-COMPRA * 1 */
                HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * 1;

                /*" -1228- MOVE VGSOLFAT-PRM-VG TO HISCOBPR-PRMVG */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);

                /*" -1230- COMPUTE HISCOBPR-PRMVG = HISCOBPR-PRMVG * MOEDACOT-VAL-COMPRA * 1 */
                HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * 1;

                /*" -1232- END-IF. */
            }


            /*" -1233- IF (VGSOLFAT-PRM-AP > ZEROES) */

            if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_AP > 00))
            {

                /*" -1235- MOVE VGSOLFAT-CAP-BAS-SEGURADO TO HISCOBPR-IMPMORACID */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);

                /*" -1237- COMPUTE HISCOBPR-IMPMORACID = HISCOBPR-IMPMORACID * MOEDACOT-VAL-COMPRA * 1 */
                HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * 1;

                /*" -1238- MOVE VGSOLFAT-PRM-AP TO HISCOBPR-PRMAP */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_AP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

                /*" -1240- COMPUTE HISCOBPR-PRMAP = HISCOBPR-PRMAP * MOEDACOT-VAL-COMPRA * 1 */
                HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * 1;

                /*" -1242- END-IF. */
            }


            /*" -1243- MOVE HISCOBPR-IMP-MORNATU TO LK-PURO-MORTE-NATURAL */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, PARAMETROS.LK_PURO_MORTE_NATURAL);

            /*" -1244- MOVE HISCOBPR-IMPMORACID TO LK-PURO-MORTE-ACIDENTAL. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, PARAMETROS.LK_PURO_MORTE_ACIDENTAL);

            /*" -1245- MOVE HISCOBPR-IMPMORACID TO LK-PURO-INV-PERMANENTE. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, PARAMETROS.LK_PURO_INV_PERMANENTE);

            /*" -1246- MOVE LK-PURO-MORTE-NATURAL TO LK-COBT-MORTE-NATURAL */
            _.Move(PARAMETROS.LK_PURO_MORTE_NATURAL, PARAMETROS.LK_COBT_MORTE_NATURAL);

            /*" -1247- MOVE LK-PURO-MORTE-ACIDENTAL TO LK-COBT-MORTE-ACIDENTAL */
            _.Move(PARAMETROS.LK_PURO_MORTE_ACIDENTAL, PARAMETROS.LK_COBT_MORTE_ACIDENTAL);

            /*" -1248- MOVE LK-PURO-INV-PERMANENTE TO LK-COBT-INV-PERMANENTE */
            _.Move(PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_PERMANENTE);

            /*" -1250- MOVE LK-PURO-INV-PERMANENTE TO LK-COBT-INV-POR-ACIDENTE */
            _.Move(PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_POR_ACIDENTE);

            /*" -1251- MOVE LK-COBT-MORTE-NATURAL TO HISCOBPR-IMP-MORNATU */
            _.Move(PARAMETROS.LK_COBT_MORTE_NATURAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

            /*" -1253- MOVE LK-COBT-MORTE-ACIDENTAL TO HISCOBPR-IMPMORACID */
            _.Move(PARAMETROS.LK_COBT_MORTE_ACIDENTAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);

            /*" -1254- IF (LK-COBT-INV-PERMANENTE NOT EQUAL ZEROS) */

            if ((PARAMETROS.LK_COBT_INV_PERMANENTE != 00))
            {

                /*" -1255- MOVE LK-COBT-INV-PERMANENTE TO HISCOBPR-IMPINVPERM */
                _.Move(PARAMETROS.LK_COBT_INV_PERMANENTE, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);

                /*" -1256- ELSE */
            }
            else
            {


                /*" -1257- MOVE LK-COBT-INV-POR-ACIDENTE TO HISCOBPR-IMPINVPERM */
                _.Move(PARAMETROS.LK_COBT_INV_POR_ACIDENTE, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);

                /*" -1259- END-IF. */
            }


            /*" -1260- MOVE LK-COBT-ASS-MEDICA TO HISCOBPR-IMPAMDS */
            _.Move(PARAMETROS.LK_COBT_ASS_MEDICA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);

            /*" -1261- MOVE LK-COBT-DIARIA-HOSPITALAR TO HISCOBPR-IMPDH */
            _.Move(PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);

            /*" -1263- MOVE LK-COBT-DIARIA-INTERNACAO TO HISCOBPR-IMPDIT. */
            _.Move(PARAMETROS.LK_COBT_DIARIA_INTERNACAO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);

            /*" -1267- MOVE ZEROS TO HISCOBPR-QTDE-TIT-CAPITALIZ HISCOBPR-VAL-TIT-CAPITALIZ HISCOBPR-VAL-CUSTO-CAPITALI. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI);

            /*" -1271- COMPUTE HISCOBPR-VLPREMIO = HISCOBPR-PRMVG + HISCOBPR-PRMAP. */
            HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP;

            /*" -1276- MOVE VGSOLFAT-DIA-DEBITO TO OPCPAGVI-DIA-DEBITO. */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);

            /*" -1277- IF (WS-TEM-RCAP EQUAL 'S' ) */

            if ((WS_TEM_RCAP == "S"))
            {

                /*" -1278- MOVE RCAPCOMP-DATA-RCAP TO VGSOLFAT-DTVENCTO-FATURA */
                _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA);

                /*" -1280- END-IF. */
            }


            /*" -1284- MOVE VGSOLFAT-DTVENCTO-FATURA TO PROPOVA-DATA-VENCIMENTO WDATA-INIVIGENCIA WDATA-PARC-PRX */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO, WS_WORK_AREAS.WDATA_INIVIGENCIA, WS_WORK_AREAS.WDATA_PARC_PRX);

            /*" -1285- MOVE 01 TO WDATA-INI-DIA. */
            _.Move(01, WS_WORK_AREAS.WDATA_INIVIGENCIA.WDATA_INI_DIA);

            /*" -1287- MOVE WDATA-INIVIGENCIA TO HISCOBPR-DATA-INIVIGENCIA */
            _.Move(WS_WORK_AREAS.WDATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);

            /*" -1289- ADD SUBGVGAP-PERI-FATURAMENTO TO WDATA-PRX-MES. */
            WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES.Value = WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES + SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO;

            /*" -1290- IF (WDATA-PRX-MES > 12) */

            if ((WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES > 12))
            {

                /*" -1291- COMPUTE WDATA-PRX-MES = WDATA-PRX-MES - 12 */
                WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES.Value = WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES - 12;

                /*" -1292- ADD 1 TO WDATA-PRX-ANO */
                WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_ANO.Value = WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_ANO + 1;

                /*" -1294- END-IF. */
            }


            /*" -1295- MOVE WDATA-PARC-PRX TO WDATA-VIGENCIA1. */
            _.Move(WS_WORK_AREAS.WDATA_PARC_PRX, WS_WORK_AREAS.WDATA_VIGENCIA1);

            /*" -1297- MOVE VGSOLFAT-DIA-DEBITO TO WDATA-VIG-DIA1. */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DIA_DEBITO, WS_WORK_AREAS.WDATA_VIGENCIA1.WDATA_VIG_DIA1);

            /*" -1298- IF (WDATA-VIGENCIA1 < WDATA-PARC-PRX) */

            if ((WS_WORK_AREAS.WDATA_VIGENCIA1 < WS_WORK_AREAS.WDATA_PARC_PRX))
            {

                /*" -1299- ADD 1 TO WDATA-PRX-MES */
                WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES.Value = WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES + 1;

                /*" -1300- IF (WDATA-PRX-MES > 12) */

                if ((WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES > 12))
                {

                    /*" -1301- MOVE 1 TO WDATA-PRX-MES */
                    _.Move(1, WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES);

                    /*" -1302- ADD 1 TO WDATA-PRX-ANO */
                    WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_ANO.Value = WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_ANO + 1;

                    /*" -1303- END-IF */
                }


                /*" -1305- END-IF. */
            }


            /*" -1307- MOVE VGSOLFAT-DIA-DEBITO TO WDATA-PRX-DIA. */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DIA_DEBITO, WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_DIA);

            /*" -1309- IF ((WDATA-PRX-MES = 02) AND (WDATA-PRX-DIA >= 28)) OR (WDATA-PRX-DIA > 30) OR (WDATA-PRX-DIA < 01) */

            if (((WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_MES == 02) && (WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_DIA >= 28)) || (WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_DIA > 30) || (WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_DIA < 01))
            {

                /*" -1312- DISPLAY 'CALCULAR ULTIMO DIA ' VGSOLFAT-NUM-APOLICE ' - ' VGSOLFAT-COD-SUBGRUPO ' - ' WDATA-PARC-PRX */

                $"CALCULAR ULTIMO DIA {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} - {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO} - {WS_WORK_AREAS.WDATA_PARC_PRX}"
                .Display();

                /*" -1313- MOVE 01 TO WDATA-PRX-DIA */
                _.Move(01, WS_WORK_AREAS.WDATA_PARC_PRX.WDATA_PRX_DIA);

                /*" -1314- MOVE WDATA-PARC-PRX TO WS-DATA-AUX */
                _.Move(WS_WORK_AREAS.WDATA_PARC_PRX, WS_WORK_AREAS.WS_DATA_AUX);

                /*" -1315- PERFORM 1050-ULTIMO-DIA-DO-MES */

                M_1050_ULTIMO_DIA_DO_MES_SECTION();

                /*" -1316- MOVE WS-DATA-AUX TO WDATA-PARC-PRX */
                _.Move(WS_WORK_AREAS.WS_DATA_AUX, WS_WORK_AREAS.WDATA_PARC_PRX);

                /*" -1318- END-IF. */
            }


            /*" -1322- MOVE WDATA-PARC-PRX TO PROPOVA-DTPROXVEN. */
            _.Move(WS_WORK_AREAS.WDATA_PARC_PRX, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);

            /*" -1324- MOVE 'SELECT FATURAS ' TO COMANDO. */
            _.Move("SELECT FATURAS ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1333- PERFORM M_1000_PROCESSA_VGSOLFAT_DB_SELECT_11 */

            M_1000_PROCESSA_VGSOLFAT_DB_SELECT_11();

            /*" -1336- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1338- DISPLAY '1000 - PROBLEMAS NA LEITURA DA FATURAS   ' VGSOLFAT-NUM-APOLICE */
                _.Display($"1000 - PROBLEMAS NA LEITURA DA FATURAS   {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE}");

                /*" -1339- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1341- END-IF. */
            }


            /*" -1344- COMPUTE PROPOVA-NUM-PARCELA = FATURAS-NUM-FATURA + 1. */
            PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.Value = FATURAS.DCLFATURAS.FATURAS_NUM_FATURA + 1;

            /*" -1345- IF (WS-TEM-RCAP EQUAL 'S' ) */

            if ((WS_TEM_RCAP == "S"))
            {

                /*" -1347- MOVE RCAPCOMP-DATA-RCAP TO VGSOLFAT-DT-QUITBCO-TITULO VGSOLFAT-DTVENCTO-FATURA */
                _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DT_QUITBCO_TITULO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA);

                /*" -1348- MOVE 1 TO PROPOVA-NUM-PARCELA */
                _.Move(1, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);

                /*" -1349- MOVE 1 TO FATURAS-NUM-FATURA */
                _.Move(1, FATURAS.DCLFATURAS.FATURAS_NUM_FATURA);

                /*" -1351- END-IF. */
            }


            /*" -1353- PERFORM 2000-INSERT-PROPOSTAVA. */

            M_2000_INSERT_PROPOSTAVA_SECTION();

            /*" -1354- IF (WS-TEM-ERRO EQUAL 'S' ) */

            if ((WS_WORK_AREAS.WS_TEM_ERRO == "S"))
            {

                /*" -1355- MOVE '0' TO VGSOLFAT-SIT-SOLICITA */
                _.Move("0", VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_SIT_SOLICITA);

                /*" -1356- GO TO 1000-UPDATE */

                M_1000_UPDATE(); //GOTO
                return;

                /*" -1357- ELSE */
            }
            else
            {


                /*" -1358- MOVE '1' TO VGSOLFAT-SIT-SOLICITA */
                _.Move("1", VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_SIT_SOLICITA);

                /*" -1360- END-IF. */
            }


            /*" -1362- PERFORM 2100-INSERT-COBERPROPVA. */

            M_2100_INSERT_COBERPROPVA_SECTION();

            /*" -1364- PERFORM 2400-INSERT-OPCAOPAGVA. */

            M_2400_INSERT_OPCAOPAGVA_SECTION();

            /*" -1366- PERFORM 2500-INSERT-PARCELVA. */

            M_2500_INSERT_PARCELVA_SECTION();

            /*" -1368- PERFORM 2600-INSERT-HISTCOBVA. */

            M_2600_INSERT_HISTCOBVA_SECTION();

            /*" -1370- PERFORM 2800-INSERT-HISTCONTAVA. */

            M_2800_INSERT_HISTCONTAVA_SECTION();

            /*" -1372- PERFORM 2900-INSERT-HISTCONTABILVA. */

            M_2900_INSERT_HISTCONTABILVA_SECTION();

            /*" -1374- PERFORM 3000-INSERT-CONVENIOSVG. */

            M_3000_INSERT_CONVENIOSVG_SECTION();

            /*" -1376- PERFORM 3100-INSERT-PRODUTOSVG. */

            M_3100_INSERT_PRODUTOSVG_SECTION();

            /*" -1377- IF WS-FLAG-PROP-MANUAL EQUAL ZEROS */

            if (WS_FLAG_PROP_MANUAL == 00)
            {

                /*" -1378- MOVE 1 TO WS-COD-CRITICA */
                _.Move(1, WS_COD_CRITICA);

                /*" -1380- PERFORM 7100-00-CONS-COD-CRITICA */

                M_7100_00_CONS_COD_CRITICA_SECTION();

                /*" -1381- IF VG001-IND-EXISTE EQUAL 'N' */

                if (SPVG001V.VG001_IND_EXISTE == "N")
                {

                    /*" -1382- PERFORM 7000-00-PROCURA-RISCO-PROP */

                    M_7000_00_PROCURA_RISCO_PROP_SECTION();

                    /*" -1384- ELSE */
                }
                else
                {


                    /*" -1385- IF LK-VG001-S-STA-CRITICA NOT EQUAL '6' */

                    if (SPVG001W.LK_VG001_S_STA_CRITICA != "6")
                    {

                        /*" -1387- DISPLAY 'APOLICE EM ANALISE DE CRITICA.......: ' NUMEROUT-NUM-CERT-VGAP */
                        _.Display($"APOLICE EM ANALISE DE CRITICA.......: {NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP}");

                        /*" -1389- ADD 1 TO WS-QT-EM-CRITICA */
                        WS_QT_EM_CRITICA.Value = WS_QT_EM_CRITICA + 1;

                        /*" -1390- MOVE '1' TO PROPOVA-SIT-REGISTRO */
                        _.Move("1", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                        /*" -1392- MOVE NUMEROUT-NUM-CERT-VGAP TO PROPOVA-NUM-CERTIFICADO */
                        _.Move(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

                        /*" -1394- PERFORM 6000-UPDATE-SIT-PROPOSTA */

                        M_6000_UPDATE_SIT_PROPOSTA_SECTION();

                        /*" -1395- MOVE '3' TO VGSOLFAT-SIT-SOLICITA */
                        _.Move("3", VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_SIT_SOLICITA);

                        /*" -1396- GO TO 1000-UPDATE */

                        M_1000_UPDATE(); //GOTO
                        return;

                        /*" -1397- ELSE */
                    }
                    else
                    {


                        /*" -1399- DISPLAY 'LIBERADO PARA EMISSAO APOS ANALISE..: ' NUMEROUT-NUM-CERT-VGAP */
                        _.Display($"LIBERADO PARA EMISSAO APOS ANALISE..: {NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP}");

                        /*" -1400- ADD 1 TO WS-QT-LIBERADO-EMISSAO */
                        WS_QT_LIBERADO_EMISSAO.Value = WS_QT_LIBERADO_EMISSAO + 1;

                        /*" -1401- END-IF */
                    }


                    /*" -1402- END-IF */
                }


                /*" -1403- ELSE */
            }
            else
            {


                /*" -1407- DISPLAY 'APOL. ESPEC. MANUAL SEM TRATAMENTO DO MOTOR >>> ' VGSOLFAT-NUM-APOLICE '/' VGSOLFAT-COD-SUBGRUPO '/' NUMEROUT-NUM-CERT-VGAP '/' VGSOLFAT-COD-USUARIO '/' WS-TEM-RCAP '/' VGSOLFAT-NUM-TITULO */

                $"APOL. ESPEC. MANUAL SEM TRATAMENTO DO MOTOR >>> {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE}/{VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}/{NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP}/{VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_USUARIO}/{WS_TEM_RCAP}/{VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO}"
                .Display();

                /*" -1408- ADD 1 TO WS-QT-MANUAL-S-RISCO */
                WS_QT_MANUAL_S_RISCO.Value = WS_QT_MANUAL_S_RISCO + 1;

                /*" -1411- END-IF. */
            }


            /*" -1412- IF (WS-TEM-RCAP EQUAL 'S' ) */

            if ((WS_TEM_RCAP == "S"))
            {

                /*" -1413- PERFORM 1110-VERIFICA-RCAP */

                M_1110_VERIFICA_RCAP_SECTION();

                /*" -1413- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM M_1000_UPDATE */

            M_1000_UPDATE();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-VGSOLFAT-DB-SELECT-1 */
        public void M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1()
        {
            /*" -833- EXEC SQL SELECT COD_FONTE, COD_CLIENTE, OCORR_ENDERECO, PERI_FATURAMENTO, TIPO_FATURAMENTO, AGE_COBRANCA, OPCAO_COBERTURA, DATA_INIVIGENCIA, TIPO_SUBGRUPO, VALUE(IND_IOF, 'S' ) INTO :SUBGVGAP-COD-FONTE, :SUBGVGAP-COD-CLIENTE, :SUBGVGAP-OCORR-ENDERECO, :SUBGVGAP-PERI-FATURAMENTO, :SUBGVGAP-TIPO-FATURAMENTO, :SUBGVGAP-AGE-COBRANCA, :SUBGVGAP-OPCAO-COBERTURA, :SUBGVGAP-DATA-INIVIGENCIA, :SUBGVGAP-TIPO-SUBGRUPO, :SUBGVGAP-IND-IOF FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE AND COD_SUBGRUPO = :VGSOLFAT-COD-SUBGRUPO AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var m_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1 = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1()
            {
                VGSOLFAT_COD_SUBGRUPO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO.ToString(),
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1.Execute(m_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_COD_FONTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE);
                _.Move(executed_1.SUBGVGAP_COD_CLIENTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE);
                _.Move(executed_1.SUBGVGAP_OCORR_ENDERECO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO);
                _.Move(executed_1.SUBGVGAP_PERI_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_TIPO_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_AGE_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_AGE_COBRANCA);
                _.Move(executed_1.SUBGVGAP_OPCAO_COBERTURA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_COBERTURA);
                _.Move(executed_1.SUBGVGAP_DATA_INIVIGENCIA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA);
                _.Move(executed_1.SUBGVGAP_TIPO_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_SUBGRUPO);
                _.Move(executed_1.SUBGVGAP_IND_IOF, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_IOF);
            }


        }

        [StopWatch]
        /*" M-1000-UPDATE */
        private void M_1000_UPDATE(bool isPerform = false)
        {
            /*" -1417- MOVE '1000' TO PARAGRAFO. */
            _.Move("1000", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1419- MOVE 'UPDATE VG_SOLICITA_FATURA' TO COMANDO. */
            _.Move("UPDATE VG_SOLICITA_FATURA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1423- PERFORM M_1000_UPDATE_DB_UPDATE_1 */

            M_1000_UPDATE_DB_UPDATE_1();

            /*" -1426- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1427- DISPLAY 'ERRO NO UPDATE DA VG_SOLICITA_FATURA' */
                _.Display($"ERRO NO UPDATE DA VG_SOLICITA_FATURA");

                /*" -1428- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1430- END-IF. */
            }


            /*" -1432- MOVE 'COMMIT WORK ' TO COMANDO. */
            _.Move("COMMIT WORK ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1432- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1435- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1436- DISPLAY 'ERRO NO COMMIT WORK' */
                _.Display($"ERRO NO COMMIT WORK");

                /*" -1437- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1437- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1000-UPDATE-DB-UPDATE-1 */
        public void M_1000_UPDATE_DB_UPDATE_1()
        {
            /*" -1423- EXEC SQL UPDATE SEGUROS.VG_SOLICITA_FATURA SET SIT_SOLICITA = :VGSOLFAT-SIT-SOLICITA WHERE CURRENT OF CSOLICITA END-EXEC. */

            var m_1000_UPDATE_DB_UPDATE_1_Update1 = new M_1000_UPDATE_DB_UPDATE_1_Update1(CSOLICITA)
            {
                VGSOLFAT_SIT_SOLICITA = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_SIT_SOLICITA.ToString(),
                SISTEMAS_DATA_MOV_6MONTH = SISTEMAS_DATA_MOV_6MONTH.ToString(),
                JVPRD8205 = JVBKINCL.JV_PRODUTOS.JVPRD8205.ToString(),
                JVPRD8209 = JVBKINCL.JV_PRODUTOS.JVPRD8209.ToString(),
                JVPRD9329 = JVBKINCL.JV_PRODUTOS.JVPRD9329.ToString(),
                JVPRD9343 = JVBKINCL.JV_PRODUTOS.JVPRD9343.ToString(),
            };

            M_1000_UPDATE_DB_UPDATE_1_Update1.Execute(m_1000_UPDATE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1000-PROCESSA-VGSOLFAT-DB-SELECT-2 */
        public void M_1000_PROCESSA_VGSOLFAT_DB_SELECT_2()
        {
            /*" -876- EXEC SQL SELECT COD_PRODUTO, 01, OCORR_ENDERECO, NUM_PROPOSTA, AGE_COBRANCA, RAMO_EMISSOR INTO :ENDOSSOS-COD-PRODUTO, :ENDOSSOS-COD-MOEDA-PRM, :ENDOSSOS-OCORR-ENDERECO, :ENDOSSOS-NUM-PROPOSTA, :ENDOSSOS-AGE-COBRANCA, :ENDOSSOS-RAMO-EMISSOR FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE AND NUM_ENDOSSO = 0 WITH UR END-EXEC. */

            var m_1000_PROCESSA_VGSOLFAT_DB_SELECT_2_Query1 = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_2_Query1()
            {
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_VGSOLFAT_DB_SELECT_2_Query1.Execute(m_1000_PROCESSA_VGSOLFAT_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_COD_MOEDA_PRM, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);
                _.Move(executed_1.ENDOSSOS_OCORR_ENDERECO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);
                _.Move(executed_1.ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_AGE_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA);
                _.Move(executed_1.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
            }


        }

        [StopWatch]
        /*" M-1000-NEXT */
        private void M_1000_NEXT(bool isPerform = false)
        {
            /*" -1442- IF WS-I-ERRO > ZEROS */

            if (WS_I_ERRO > 00)
            {

                /*" -1443- MOVE 'S' TO WS-FLAG-TEM-ERRO */
                _.Move("S", WS_FLAG_TEM_ERRO);

                /*" -1445- MOVE 1 TO WS-I-ERRO */
                _.Move(1, WS_I_ERRO);

                /*" -1447- PERFORM 4050-00-INSERT-VGCRITICA UNTIL WS-FLAG-TEM-ERRO EQUAL 'N' */

                while (!(WS_FLAG_TEM_ERRO == "N"))
                {

                    M_4050_00_INSERT_VGCRITICA_SECTION();
                }

                /*" -1448- END-IF */
            }


            /*" -1450- . */

            /*" -1450- PERFORM 0910-FETCH-VGSOLFAT. */

            M_0910_FETCH_VGSOLFAT_SECTION();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-VGSOLFAT-DB-SELECT-3 */
        public void M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3()
        {
            /*" -902- EXEC SQL SELECT NUM_CERTIFICADO INTO :PROPOVA-NUM-CERTIFICADO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE AND COD_SUBGRUPO = :VGSOLFAT-COD-SUBGRUPO AND COD_CLIENTE = :SUBGVGAP-COD-CLIENTE WITH UR END-EXEC. */

            var m_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1 = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1()
            {
                VGSOLFAT_COD_SUBGRUPO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO.ToString(),
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
                SUBGVGAP_COD_CLIENTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1.Execute(m_1000_PROCESSA_VGSOLFAT_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1000-PROCESSA-VGSOLFAT-DB-SELECT-4 */
        public void M_1000_PROCESSA_VGSOLFAT_DB_SELECT_4()
        {
            /*" -928- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SUBGVGAP-COD-CLIENTE WITH UR END-EXEC. */

            var m_1000_PROCESSA_VGSOLFAT_DB_SELECT_4_Query1 = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_4_Query1()
            {
                SUBGVGAP_COD_CLIENTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_VGSOLFAT_DB_SELECT_4_Query1.Execute(m_1000_PROCESSA_VGSOLFAT_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }

        [StopWatch]
        /*" M-1050-ULTIMO-DIA-DO-MES-SECTION */
        private void M_1050_ULTIMO_DIA_DO_MES_SECTION()
        {
            /*" -1459- MOVE '1050' TO PARAGRAFO. */
            _.Move("1050", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1461- MOVE 'SELECT SISTEMAS' TO COMANDO. */
            _.Move("SELECT SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1467- PERFORM M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1 */

            M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1();

            /*" -1470- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1472- DISPLAY '1050-ULTIMO DIA DO MES COM ERRO ' SQLCODE ' - ' WS-DATA-AUX */

                $"1050-ULTIMO DIA DO MES COM ERRO {DB.SQLCODE} - {WS_WORK_AREAS.WS_DATA_AUX}"
                .Display();

                /*" -1473- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1473- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1050-ULTIMO-DIA-DO-MES-DB-SELECT-1 */
        public void M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1()
        {
            /*" -1467- EXEC SQL SELECT LAST_DAY(DATE(:WS-DATA-AUX)) INTO :WS-DATA-AUX FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

            var m_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1 = new M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1()
            {
                WS_DATA_AUX = WS_WORK_AREAS.WS_DATA_AUX.ToString(),
            };

            var executed_1 = M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1.Execute(m_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DATA_AUX, WS_WORK_AREAS.WS_DATA_AUX);
            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-VGSOLFAT-DB-SELECT-5 */
        public void M_1000_PROCESSA_VGSOLFAT_DB_SELECT_5()
        {
            /*" -952- EXEC SQL SELECT COD_PRODUTO_EMP INTO :VGPROSIA-COD-PRODUTO-EMP FROM SEGUROS.VG_PRODUTO_SIAS WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE AND NUM_PERIODO_PAG = 01 WITH UR END-EXEC. */

            var m_1000_PROCESSA_VGSOLFAT_DB_SELECT_5_Query1 = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_5_Query1()
            {
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_VGSOLFAT_DB_SELECT_5_Query1.Execute(m_1000_PROCESSA_VGSOLFAT_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGPROSIA_COD_PRODUTO_EMP, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1050_FIM*/

        [StopWatch]
        /*" M-1000-PROCESSA-VGSOLFAT-DB-SELECT-6 */
        public void M_1000_PROCESSA_VGSOLFAT_DB_SELECT_6()
        {
            /*" -996- EXEC SQL SELECT NUM_TERMO, NUM_MATRICULA_VEN, COD_AGENCIA_VEN , OPERACAO_CONTA_VEN, NUM_CONTA_VEN , DIG_CONTA_VEN INTO :TERMOADE-NUM-TERMO, :TERMOADE-NUM-MATRICULA-VEN, :TERMOADE-COD-AGENCIA-VEN , :TERMOADE-OPERACAO-CONTA-VEN, :TERMOADE-NUM-CONTA-VEN , :TERMOADE-DIG-CONTA-VEN FROM SEGUROS.TERMO_ADESAO WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE AND COD_SUBGRUPO = :VGSOLFAT-COD-SUBGRUPO WITH UR END-EXEC. */

            var m_1000_PROCESSA_VGSOLFAT_DB_SELECT_6_Query1 = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_6_Query1()
            {
                VGSOLFAT_COD_SUBGRUPO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO.ToString(),
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_VGSOLFAT_DB_SELECT_6_Query1.Execute(m_1000_PROCESSA_VGSOLFAT_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TERMOADE_NUM_TERMO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO);
                _.Move(executed_1.TERMOADE_NUM_MATRICULA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN);
                _.Move(executed_1.TERMOADE_COD_AGENCIA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_VEN);
                _.Move(executed_1.TERMOADE_OPERACAO_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_OPERACAO_CONTA_VEN);
                _.Move(executed_1.TERMOADE_NUM_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_CONTA_VEN);
                _.Move(executed_1.TERMOADE_DIG_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DIG_CONTA_VEN);
            }


        }

        [StopWatch]
        /*" M-1100-SELECT-NUMEROS-SECTION */
        private void M_1100_SELECT_NUMEROS_SECTION()
        {
            /*" -1482- MOVE '1100' TO PARAGRAFO. */
            _.Move("1100", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1484- MOVE 'SELECT NUMERO_OUTROS' TO COMANDO. */
            _.Move("SELECT NUMERO_OUTROS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1489- PERFORM M_1100_SELECT_NUMEROS_DB_SELECT_1 */

            M_1100_SELECT_NUMEROS_DB_SELECT_1();

            /*" -1492- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1493- DISPLAY '1100 - ERRO NO ACESSO NUMEROS-OUTROS ' SQLCODE */
                _.Display($"1100 - ERRO NO ACESSO NUMEROS-OUTROS {DB.SQLCODE}");

                /*" -1494- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1496- END-IF. */
            }


            /*" -1498- MOVE NUMEROUT-NUM-CERT-VGAP TO H-NUM-CERTIFICADO. */
            _.Move(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP, H_NUM_CERTIFICADO);

            /*" -1498- PERFORM 1300-UPDATE-NUMERO-OUTROS. */

            M_1300_UPDATE_NUMERO_OUTROS_SECTION();

        }

        [StopWatch]
        /*" M-1100-SELECT-NUMEROS-DB-SELECT-1 */
        public void M_1100_SELECT_NUMEROS_DB_SELECT_1()
        {
            /*" -1489- EXEC SQL SELECT NUM_CERT_VGAP + 1 INTO :NUMEROUT-NUM-CERT-VGAP FROM SEGUROS.NUMERO_OUTROS WITH UR END-EXEC. */

            var m_1100_SELECT_NUMEROS_DB_SELECT_1_Query1 = new M_1100_SELECT_NUMEROS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_1100_SELECT_NUMEROS_DB_SELECT_1_Query1.Execute(m_1100_SELECT_NUMEROS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMEROUT_NUM_CERT_VGAP, NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP);
            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-VGSOLFAT-DB-SELECT-7 */
        public void M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7()
        {
            /*" -1073- EXEC SQL SELECT NUM_PROPOSTA_SIVPF, NUM_CARTAO_CREDITO INTO :VGCOMTRO-NUM-PROPOSTA-SIVPF, :VGCOMTRO-NUM-CARTAO-CREDITO FROM SEGUROS.VG_COMPL_TERMO WHERE NUM_TERMO = :TERMOADE-NUM-TERMO WITH UR END-EXEC. */

            var m_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1 = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1()
            {
                TERMOADE_NUM_TERMO = TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1.Execute(m_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGCOMTRO_NUM_PROPOSTA_SIVPF, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.VGCOMTRO_NUM_CARTAO_CREDITO, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_CARTAO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

        [StopWatch]
        /*" M-1000-PROCESSA-VGSOLFAT-DB-SELECT-8 */
        public void M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8()
        {
            /*" -1098- EXEC SQL SELECT NUM_SICOB INTO :PROPOFID-NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF WITH UR END-EXEC */

            var m_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1 = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1.Execute(m_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
            }


        }

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP-SECTION */
        private void M_1110_VERIFICA_RCAP_SECTION()
        {
            /*" -1507- MOVE '1110' TO PARAGRAFO. */
            _.Move("1110", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1509- MOVE 'SELECT RCAPS        ' TO COMANDO. */
            _.Move("SELECT RCAPS        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1510- MOVE SPACES TO WFIM-V1RCAP. */
            _.Move("", WS_WORK_AREAS.WFIM_V1RCAP);

            /*" -1512- MOVE VGSOLFAT-NUM-TITULO TO RCAPS-NUM-TITULO. */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -1523- PERFORM M_1110_VERIFICA_RCAP_DB_SELECT_1 */

            M_1110_VERIFICA_RCAP_DB_SELECT_1();

            /*" -1526- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1527- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1528- MOVE 'N' TO WS-TEM-RCAP */
                    _.Move("N", WS_TEM_RCAP);

                    /*" -1529- GO TO 1110-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1110_FIM*/ //GOTO
                    return;

                    /*" -1530- ELSE */
                }
                else
                {


                    /*" -1531- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1532- END-IF */
                }


                /*" -1533- ELSE */
            }
            else
            {


                /*" -1534- MOVE 'S' TO WS-TEM-RCAP */
                _.Move("S", WS_TEM_RCAP);

                /*" -1536- END-IF. */
            }


            /*" -1538- MOVE 'SELECT RCAP_COMPLEMENTAR' TO COMANDO. */
            _.Move("SELECT RCAP_COMPLEMENTAR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1555- PERFORM M_1110_VERIFICA_RCAP_DB_SELECT_2 */

            M_1110_VERIFICA_RCAP_DB_SELECT_2();

            /*" -1558- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1559- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1561- END-IF. */
            }


            /*" -1563- PERFORM 1120-BAIXA-RCAP. */

            M_1120_BAIXA_RCAP_SECTION();

            /*" -1565- MOVE 'UPDATE RCAPS         ' TO COMANDO. */
            _.Move("UPDATE RCAPS         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1576- PERFORM M_1110_VERIFICA_RCAP_DB_UPDATE_1 */

            M_1110_VERIFICA_RCAP_DB_UPDATE_1();

            /*" -1579- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1580- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1580- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP-DB-SELECT-1 */
        public void M_1110_VERIFICA_RCAP_DB_SELECT_1()
        {
            /*" -1523- EXEC SQL SELECT COD_FONTE, NUM_RCAP INTO :RCAPS-COD-FONTE, :RCAPS-NUM-RCAP FROM SEGUROS.RCAPS WHERE NUM_TITULO = :RCAPS-NUM-TITULO AND (COD_OPERACAO BETWEEN 100 AND 199 OR COD_OPERACAO BETWEEN 300 AND 399) AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var m_1110_VERIFICA_RCAP_DB_SELECT_1_Query1 = new M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1.Execute(m_1110_VERIFICA_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-VGSOLFAT-DB-SELECT-9 */
        public void M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9()
        {
            /*" -1135- EXEC SQL SELECT VALUE(SUM(B.VLR_PREMIO),0), VALUE(SUM(B.IMP_SEGURADA),0), VALUE(COUNT(*),0) INTO :VGFUNCOB-VLR-PREMIO, :VGFUNCOB-IMP-SEGURADA, :VGFUNCOB-QTD-VIDAS FROM SEGUROS.VG_MOV_FUNCIONARIO A, SEGUROS.VG_FUNC_COBERTURA B WHERE A.NUM_PROPOSTA_SIVPF = :VGCOMTRO-NUM-PROPOSTA-SIVPF AND A.STA_FUNCIONARIO IN ( 'L' , 'E' ) AND A.DTH_FIM_VIGENCIA = '9999-12-31' AND B.NUM_PROPOSTA_SIVPF = A.NUM_PROPOSTA_SIVPF AND B.NUM_CPF = A.NUM_CPF AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA AND B.COD_GARANTIA = 17 WITH UR END-EXEC */

            var m_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1 = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1()
            {
                VGCOMTRO_NUM_PROPOSTA_SIVPF = VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1.Execute(m_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGFUNCOB_VLR_PREMIO, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_VLR_PREMIO);
                _.Move(executed_1.VGFUNCOB_IMP_SEGURADA, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_IMP_SEGURADA);
                _.Move(executed_1.VGFUNCOB_QTD_VIDAS, VGFUNCOB_QTD_VIDAS);
            }


        }

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP-DB-UPDATE-1 */
        public void M_1110_VERIFICA_RCAP_DB_UPDATE_1()
        {
            /*" -1576- EXEC SQL UPDATE SEGUROS.RCAPS SET SIT_REGISTRO = '1' , COD_OPERACAO = 220 , NUM_APOLICE = :VGSOLFAT-NUM-APOLICE, NUM_ENDOSSO = 0, NUM_PARCELA = 0, TIMESTAMP = CURRENT TIMESTAMP, CODIGO_PRODUTO = :PROPOVA-COD-PRODUTO WHERE COD_FONTE = :RCAPS-COD-FONTE AND NUM_RCAP = :RCAPS-NUM-RCAP END-EXEC. */

            var m_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1 = new M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1()
            {
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
                PROPOVA_COD_PRODUTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.ToString(),
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1.Execute(m_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP-DB-SELECT-2 */
        public void M_1110_VERIFICA_RCAP_DB_SELECT_2()
        {
            /*" -1555- EXEC SQL SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_RCAP INTO :RCAPCOMP-BCO-AVISO, :RCAPCOMP-AGE-AVISO, :RCAPCOMP-NUM-AVISO-CREDITO, :RCAPCOMP-DATA-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :RCAPS-COD-FONTE AND NUM_RCAP = :RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND (COD_OPERACAO BETWEEN 100 AND 199 OR COD_OPERACAO BETWEEN 300 AND 399) AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var m_1110_VERIFICA_RCAP_DB_SELECT_2_Query1 = new M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1.Execute(m_1110_VERIFICA_RCAP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1110_FIM*/

        [StopWatch]
        /*" M-1000-PROCESSA-VGSOLFAT-DB-SELECT-10 */
        public void M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10()
        {
            /*" -1211- EXEC SQL SELECT VAL_COMPRA INTO :MOEDACOT-VAL-COMPRA FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = :ENDOSSOS-COD-MOEDA-PRM AND DATA_INIVIGENCIA <= :VGSOLFAT-DTVENCTO-FATURA AND DATA_TERVIGENCIA >= :VGSOLFAT-DTVENCTO-FATURA WITH UR END-EXEC. */

            var m_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1 = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1()
            {
                VGSOLFAT_DTVENCTO_FATURA = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA.ToString(),
                ENDOSSOS_COD_MOEDA_PRM = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1.Execute(m_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOEDACOT_VAL_COMPRA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA);
            }


        }

        [StopWatch]
        /*" M-1120-BAIXA-RCAP-SECTION */
        private void M_1120_BAIXA_RCAP_SECTION()
        {
            /*" -1589- MOVE '1120' TO PARAGRAFO. */
            _.Move("1120", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1591- MOVE 'DECLARE V1RCAPCOMP' TO COMANDO. */
            _.Move("DECLARE V1RCAPCOMP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1613- PERFORM M_1120_BAIXA_RCAP_DB_DECLARE_1 */

            M_1120_BAIXA_RCAP_DB_DECLARE_1();

            /*" -1615- PERFORM M_1120_BAIXA_RCAP_DB_OPEN_1 */

            M_1120_BAIXA_RCAP_DB_OPEN_1();

            /*" -1618- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1619- MOVE 'OPEN V1RCAPCOMP' TO COMANDO */
                _.Move("OPEN V1RCAPCOMP", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1620- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1620- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM M_1120_FETCH_V0RCAPCOMP */

            M_1120_FETCH_V0RCAPCOMP();

        }

        [StopWatch]
        /*" M-1120-BAIXA-RCAP-DB-OPEN-1 */
        public void M_1120_BAIXA_RCAP_DB_OPEN_1()
        {
            /*" -1615- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" M-5000-DECLARA-PROPOVA-CRTCA-DB-DECLARE-1 */
        public void M_5000_DECLARA_PROPOVA_CRTCA_DB_DECLARE_1()
        {
            /*" -3386- EXEC SQL DECLARE CPROPOVACRT CURSOR WITH HOLD FOR SELECT A.NUM_APOLICE, A.COD_SUBGRUPO, A.NUM_TITULO, B.NUM_CERTIFICADO, D.NUM_PROPOSTA_SIVPF, A.PRM_VG, A.PRM_AP, A.PRM_VG + A.PRM_AP FROM SEGUROS.VG_SOLICITA_FATURA A, SEGUROS.PROPOSTAS_VA B, SEGUROS.PRODUTOS_VG C, SEGUROS.CONVERSAO_SICOB D WHERE A.SIT_SOLICITA = '1' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND B.SIT_REGISTRO = '1' AND A.NUM_APOLICE = C.NUM_APOLICE AND A.COD_SUBGRUPO = C.COD_SUBGRUPO AND C.ORIG_PRODU IN ( 'ESPE1 ' , 'ESPEC' ) AND A.NUM_APOLICE = D.NUM_SICOB END-EXEC. */
            CPROPOVACRT = new VG0001B_CPROPOVACRT(false);
            string GetQuery_CPROPOVACRT()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.NUM_TITULO
							, 
							B.NUM_CERTIFICADO
							, 
							D.NUM_PROPOSTA_SIVPF
							, 
							A.PRM_VG
							, 
							A.PRM_AP
							, 
							A.PRM_VG + A.PRM_AP 
							FROM SEGUROS.VG_SOLICITA_FATURA A
							, 
							SEGUROS.PROPOSTAS_VA B
							, 
							SEGUROS.PRODUTOS_VG C
							, 
							SEGUROS.CONVERSAO_SICOB D 
							WHERE A.SIT_SOLICITA = '1' 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND B.SIT_REGISTRO = '1' 
							AND A.NUM_APOLICE = C.NUM_APOLICE 
							AND A.COD_SUBGRUPO = C.COD_SUBGRUPO 
							AND C.ORIG_PRODU IN ( 'ESPE1 '
							, 'ESPEC' ) 
							AND A.NUM_APOLICE = D.NUM_SICOB";

                return query;
            }
            CPROPOVACRT.GetQueryEvent += GetQuery_CPROPOVACRT;

        }

        [StopWatch]
        /*" M-1000-PROCESSA-VGSOLFAT-DB-SELECT-11 */
        public void M_1000_PROCESSA_VGSOLFAT_DB_SELECT_11()
        {
            /*" -1333- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :FATURAS-NUM-FATURA FROM SEGUROS.FATURAS WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE AND COD_SUBGRUPO = :VGSOLFAT-COD-SUBGRUPO AND COD_OPERACAO IN (200, 300) AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var m_1000_PROCESSA_VGSOLFAT_DB_SELECT_11_Query1 = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_11_Query1()
            {
                VGSOLFAT_COD_SUBGRUPO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO.ToString(),
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_VGSOLFAT_DB_SELECT_11_Query1.Execute(m_1000_PROCESSA_VGSOLFAT_DB_SELECT_11_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURAS_NUM_FATURA, FATURAS.DCLFATURAS.FATURAS_NUM_FATURA);
            }


        }

        [StopWatch]
        /*" M-1120-FETCH-V0RCAPCOMP */
        private void M_1120_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -1626- MOVE 'FETCH V1RCAPCOMP     ' TO COMANDO. */
            _.Move("FETCH V1RCAPCOMP     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1641- PERFORM M_1120_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            M_1120_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -1644- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1645- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1645- PERFORM M_1120_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                    M_1120_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                    /*" -1647- GO TO 1120-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1120_FIM*/ //GOTO
                    return;

                    /*" -1648- ELSE */
                }
                else
                {


                    /*" -1649- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1650- END-IF */
                }


                /*" -1651- END-IF. */
            }


            /*" -1651- PERFORM 1120-UPDATE-V0RCAPCOMP. */

            M_1120_UPDATE_V0RCAPCOMP(true);

        }

        [StopWatch]
        /*" M-1120-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void M_1120_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -1641- EXEC SQL FETCH V1RCAPCOMP INTO :RCAPCOMP-COD-FONTE , :RCAPCOMP-NUM-RCAP , :RCAPCOMP-NUM-RCAP-COMPLEMEN, :RCAPCOMP-COD-OPERACAO , :RCAPCOMP-DATA-MOVIMENTO , :RCAPCOMP-HORA-OPERACAO , :RCAPCOMP-SIT-REGISTRO , :RCAPCOMP-BCO-AVISO , :RCAPCOMP-AGE-AVISO , :RCAPCOMP-NUM-AVISO-CREDITO , :RCAPCOMP-VAL-RCAP , :RCAPCOMP-DATA-RCAP , :RCAPCOMP-DATA-CADASTRAMENTO, :RCAPCOMP-SIT-CONTABIL END-EXEC. */

            if (V1RCAPCOMP.Fetch())
            {
                _.Move(V1RCAPCOMP.RCAPCOMP_COD_FONTE, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE);
                _.Move(V1RCAPCOMP.RCAPCOMP_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);
                _.Move(V1RCAPCOMP.RCAPCOMP_NUM_RCAP_COMPLEMEN, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN);
                _.Move(V1RCAPCOMP.RCAPCOMP_COD_OPERACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);
                _.Move(V1RCAPCOMP.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(V1RCAPCOMP.RCAPCOMP_HORA_OPERACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_HORA_OPERACAO);
                _.Move(V1RCAPCOMP.RCAPCOMP_SIT_REGISTRO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO);
                _.Move(V1RCAPCOMP.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(V1RCAPCOMP.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(V1RCAPCOMP.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(V1RCAPCOMP.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(V1RCAPCOMP.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(V1RCAPCOMP.RCAPCOMP_DATA_CADASTRAMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO);
                _.Move(V1RCAPCOMP.RCAPCOMP_SIT_CONTABIL, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL);
            }

        }

        [StopWatch]
        /*" M-1120-FETCH-V0RCAPCOMP-DB-CLOSE-1 */
        public void M_1120_FETCH_V0RCAPCOMP_DB_CLOSE_1()
        {
            /*" -1645- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" M-1120-UPDATE-V0RCAPCOMP */
        private void M_1120_UPDATE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -1656- MOVE 'UPDATE RCAP_COMPLEMENTAR' TO COMANDO. */
            _.Move("UPDATE RCAP_COMPLEMENTAR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1666- PERFORM M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

            /*" -1669- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1670- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1671- END-IF. */
            }


            /*" -1671- PERFORM 1120-INSERT-V0RCAPCOMP. */

            M_1120_INSERT_V0RCAPCOMP(true);

        }

        [StopWatch]
        /*" M-1120-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -1666- EXEC SQL UPDATE SEGUROS.RCAP_COMPLEMENTAR SET SIT_REGISTRO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_FONTE = :RCAPCOMP-COD-FONTE AND NUM_RCAP = :RCAPCOMP-NUM-RCAP AND NUM_RCAP_COMPLEMEN = :RCAPCOMP-NUM-RCAP-COMPLEMEN AND COD_OPERACAO = :RCAPCOMP-COD-OPERACAO AND DATA_MOVIMENTO = :RCAPCOMP-DATA-MOVIMENTO AND HORA_OPERACAO = :RCAPCOMP-HORA-OPERACAO END-EXEC. */

            var m_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 = new M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1()
            {
                RCAPCOMP_NUM_RCAP_COMPLEMEN = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN.ToString(),
                RCAPCOMP_DATA_MOVIMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.ToString(),
                RCAPCOMP_HORA_OPERACAO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_HORA_OPERACAO.ToString(),
                RCAPCOMP_COD_OPERACAO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO.ToString(),
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
            };

            M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1.Execute(m_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1120-INSERT-V0RCAPCOMP */
        private void M_1120_INSERT_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -1676- MOVE 'INSERT RCAP_COMPLEMENTAR' TO COMANDO. */
            _.Move("INSERT RCAP_COMPLEMENTAR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1677- MOVE '0' TO RCAPCOMP-SIT-CONTABIL */
            _.Move("0", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL);

            /*" -1678- MOVE '0' TO RCAPCOMP-SIT-REGISTRO. */
            _.Move("0", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO);

            /*" -1679- MOVE 0 TO RCAPCOMP-COD-EMPRESA. */
            _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);

            /*" -1681- MOVE 220 TO RCAPCOMP-COD-OPERACAO. */
            _.Move(220, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);

            /*" -1715- PERFORM M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -1718- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -1719- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1720- END-IF. */
            }


            /*" -1720- PERFORM 1120-UPDATE-V0AVISOSALDO. */

            M_1120_UPDATE_V0AVISOSALDO(true);

        }

        [StopWatch]
        /*" M-1120-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -1715- EXEC SQL INSERT INTO SEGUROS.RCAP_COMPLEMENTAR (COD_FONTE , NUM_RCAP , NUM_RCAP_COMPLEMEN , COD_OPERACAO , DATA_MOVIMENTO , HORA_OPERACAO , SIT_REGISTRO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , VAL_RCAP , DATA_RCAP , DATA_CADASTRAMENTO , SIT_CONTABIL , COD_EMPRESA , TIMESTAMP ) VALUES (:RCAPCOMP-COD-FONTE , :RCAPCOMP-NUM-RCAP , :RCAPCOMP-NUM-RCAP-COMPLEMEN, :RCAPCOMP-COD-OPERACAO , :SISTEMAS-DATA-MOV-ABERTO , CURRENT TIME , :RCAPCOMP-SIT-REGISTRO , :RCAPCOMP-BCO-AVISO , :RCAPCOMP-AGE-AVISO , :RCAPCOMP-NUM-AVISO-CREDITO , :RCAPCOMP-VAL-RCAP , :RCAPCOMP-DATA-RCAP , :RCAPCOMP-DATA-CADASTRAMENTO, :RCAPCOMP-SIT-CONTABIL , :RCAPCOMP-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var m_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 = new M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1()
            {
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
                RCAPCOMP_NUM_RCAP_COMPLEMEN = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN.ToString(),
                RCAPCOMP_COD_OPERACAO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                RCAPCOMP_SIT_REGISTRO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_VAL_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP.ToString(),
                RCAPCOMP_DATA_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.ToString(),
                RCAPCOMP_DATA_CADASTRAMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO.ToString(),
                RCAPCOMP_SIT_CONTABIL = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL.ToString(),
                RCAPCOMP_COD_EMPRESA = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA.ToString(),
            };

            M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(m_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-1120-UPDATE-V0AVISOSALDO */
        private void M_1120_UPDATE_V0AVISOSALDO(bool isPerform = false)
        {
            /*" -1725- MOVE 'UPDATE AVISOS_SALDOS ' TO COMANDO. */
            _.Move("UPDATE AVISOS_SALDOS ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1732- PERFORM M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1 */

            M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1();

            /*" -1735- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1736- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1738- END-IF. */
            }


            /*" -1738- GO TO 1120-FETCH-V0RCAPCOMP. */

            M_1120_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" M-1120-UPDATE-V0AVISOSALDO-DB-UPDATE-1 */
        public void M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1()
        {
            /*" -1732- EXEC SQL UPDATE SEGUROS.AVISOS_SALDOS SET SALDO_ATUAL = (SALDO_ATUAL - :RCAPCOMP-VAL-RCAP) WHERE BCO_AVISO = :RCAPCOMP-BCO-AVISO AND AGE_AVISO = :RCAPCOMP-AGE-AVISO AND NUM_AVISO_CREDITO = :RCAPCOMP-NUM-AVISO-CREDITO END-EXEC. */

            var m_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 = new M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1()
            {
                RCAPCOMP_VAL_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP.ToString(),
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
            };

            M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1.Execute(m_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1120_FIM*/

        [StopWatch]
        /*" M-1200-SELECT-RCAP-TITULO-SECTION */
        private void M_1200_SELECT_RCAP_TITULO_SECTION()
        {
            /*" -1747- MOVE '1200' TO PARAGRAFO. */
            _.Move("1200", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1749- MOVE 'SELECT-RCAPS ' TO COMANDO. */
            _.Move("SELECT-RCAPS ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1750- MOVE 'S' TO WS-TEM-RCAP. */
            _.Move("S", WS_TEM_RCAP);

            /*" -1751- MOVE VGSOLFAT-NUM-TITULO TO RCAPS-NUM-TITULO. */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -1753- MOVE ZEROS TO RCAPS-NUM-RCAP. */
            _.Move(0, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);

            /*" -1768- PERFORM M_1200_SELECT_RCAP_TITULO_DB_SELECT_1 */

            M_1200_SELECT_RCAP_TITULO_DB_SELECT_1();

            /*" -1771- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1772- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1774- DISPLAY '1200 - NAO EXISTE RCAP - NUMERO TITULO ' RCAPS-NUM-TITULO */
                    _.Display($"1200 - NAO EXISTE RCAP - NUMERO TITULO {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                    /*" -1775- MOVE 'N' TO WS-TEM-RCAP */
                    _.Move("N", WS_TEM_RCAP);

                    /*" -1776- GO TO 1200-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/ //GOTO
                    return;

                    /*" -1777- ELSE */
                }
                else
                {


                    /*" -1778- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1779- END-IF */
                }


                /*" -1781- END-IF. */
            }


            /*" -1783- MOVE 'SELECT RCAP_COMPLEMENTAR' TO COMANDO. */
            _.Move("SELECT RCAP_COMPLEMENTAR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1798- PERFORM M_1200_SELECT_RCAP_TITULO_DB_SELECT_2 */

            M_1200_SELECT_RCAP_TITULO_DB_SELECT_2();

            /*" -1801- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1802- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1804- DISPLAY '1200 - NAO EXISTE RCAP - NUMERO TITULO ' RCAPS-NUM-TITULO */
                    _.Display($"1200 - NAO EXISTE RCAP - NUMERO TITULO {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                    /*" -1805- MOVE 'N' TO WS-TEM-RCAP */
                    _.Move("N", WS_TEM_RCAP);

                    /*" -1806- GO TO 1200-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/ //GOTO
                    return;

                    /*" -1807- ELSE */
                }
                else
                {


                    /*" -1808- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1809- END-IF */
                }


                /*" -1809- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1200-SELECT-RCAP-TITULO-DB-SELECT-1 */
        public void M_1200_SELECT_RCAP_TITULO_DB_SELECT_1()
        {
            /*" -1768- EXEC SQL SELECT COD_FONTE , NUM_RCAP , VAL_RCAP , DATA_MOVIMENTO , VALUE(AGE_COBRANCA, 0) INTO :RCAPS-COD-FONTE , :RCAPS-NUM-RCAP , :RCAPS-VAL-RCAP , :RCAPS-DATA-MOVIMENTO, :RCAPS-AGE-COBRANCA FROM SEGUROS.RCAPS WHERE NUM_TITULO = :RCAPS-NUM-TITULO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var m_1200_SELECT_RCAP_TITULO_DB_SELECT_1_Query1 = new M_1200_SELECT_RCAP_TITULO_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = M_1200_SELECT_RCAP_TITULO_DB_SELECT_1_Query1.Execute(m_1200_SELECT_RCAP_TITULO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/

        [StopWatch]
        /*" M-1200-SELECT-RCAP-TITULO-DB-SELECT-2 */
        public void M_1200_SELECT_RCAP_TITULO_DB_SELECT_2()
        {
            /*" -1798- EXEC SQL SELECT BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , DATA_RCAP INTO :RCAPCOMP-BCO-AVISO , :RCAPCOMP-AGE-AVISO , :RCAPCOMP-NUM-AVISO-CREDITO, :RCAPCOMP-DATA-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :RCAPS-COD-FONTE AND NUM_RCAP = :RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var m_1200_SELECT_RCAP_TITULO_DB_SELECT_2_Query1 = new M_1200_SELECT_RCAP_TITULO_DB_SELECT_2_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = M_1200_SELECT_RCAP_TITULO_DB_SELECT_2_Query1.Execute(m_1200_SELECT_RCAP_TITULO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
            }


        }

        [StopWatch]
        /*" M-1250-SELECT-RCAP-NRCERTIF-SECTION */
        private void M_1250_SELECT_RCAP_NRCERTIF_SECTION()
        {
            /*" -1819- MOVE '1250' TO PARAGRAFO. */
            _.Move("1250", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1826- MOVE 'SELECT RCAPS ' TO COMANDO. */
            _.Move("SELECT RCAPS ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1841- PERFORM M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1 */

            M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1();

            /*" -1844- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1847- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1850- DISPLAY 'APOLICE ' VGSOLFAT-NUM-APOLICE ' NUM_PROPOSTA_SIVPF ' RCAPS-NUM-CERTIFICADO ' AGUARDANDO RCAP P/INTEGRAR' */

                    $"APOLICE {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} NUM_PROPOSTA_SIVPF {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO} AGUARDANDO RCAP P/INTEGRAR"
                    .Display();

                    /*" -1851- MOVE 'N' TO WS-TEM-RCAP */
                    _.Move("N", WS_TEM_RCAP);

                    /*" -1852- GO TO 1250-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1250_FIM*/ //GOTO
                    return;

                    /*" -1853- ELSE */
                }
                else
                {


                    /*" -1854- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1855- END-IF */
                }


                /*" -1858- ELSE */
            }
            else
            {


                /*" -1861- DISPLAY 'APOLICE ' VGSOLFAT-NUM-APOLICE ' NUM_PROPOSTA_SIVPF ' RCAPS-NUM-CERTIFICADO ' TEM RCAP ' RCAPS-NUM-RCAP */

                $"APOLICE {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} NUM_PROPOSTA_SIVPF {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO} TEM RCAP {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}"
                .Display();

                /*" -1863- END-IF. */
            }


            /*" -1865- MOVE 'SELECT RCAP_COMPLEMENTAR' TO COMANDO. */
            _.Move("SELECT RCAP_COMPLEMENTAR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1880- PERFORM M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_2 */

            M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_2();

            /*" -1894- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1898- DISPLAY 'APOLICE ' VGSOLFAT-NUM-APOLICE ' PROPOSTA_SIVPF ' RCAPS-NUM-CERTIFICADO ' RCAP ' RCAPS-NUM-RCAP ' SEM RCAP_COMPLEMENTAR' */

                $"APOLICE {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} PROPOSTA_SIVPF {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO} RCAP {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP} SEM RCAP_COMPLEMENTAR"
                .Display();

                /*" -1899- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1903- END-IF. */
            }


            /*" -1905- PERFORM 1120-BAIXA-RCAP. */

            M_1120_BAIXA_RCAP_SECTION();

            /*" -1907- MOVE 'UPDATE RCAPS ' TO COMANDO. */
            _.Move("UPDATE RCAPS ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1918- PERFORM M_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1 */

            M_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1();

            /*" -1921- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1922- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1922- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1250-SELECT-RCAP-NRCERTIF-DB-SELECT-1 */
        public void M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1()
        {
            /*" -1841- EXEC SQL SELECT COD_FONTE , NUM_RCAP , VAL_RCAP , DATA_MOVIMENTO , VALUE(AGE_COBRANCA, 0) INTO :RCAPS-COD-FONTE , :RCAPS-NUM-RCAP , :RCAPS-VAL-RCAP , :RCAPS-DATA-MOVIMENTO, :RCAPS-AGE-COBRANCA FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var m_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1 = new M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1.Execute(m_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1250_FIM*/

        [StopWatch]
        /*" M-1250-SELECT-RCAP-NRCERTIF-DB-UPDATE-1 */
        public void M_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1()
        {
            /*" -1918- EXEC SQL UPDATE SEGUROS.RCAPS SET SIT_REGISTRO = '1' , COD_OPERACAO = 220 , NUM_APOLICE = :VGSOLFAT-NUM-APOLICE, NUM_ENDOSSO = 0, NUM_PARCELA = 0, TIMESTAMP = CURRENT TIMESTAMP, CODIGO_PRODUTO = :PROPOVA-COD-PRODUTO WHERE COD_FONTE = :RCAPS-COD-FONTE AND NUM_RCAP = :RCAPS-NUM-RCAP END-EXEC. */

            var m_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1_Update1 = new M_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1_Update1()
            {
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
                PROPOVA_COD_PRODUTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.ToString(),
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            M_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1_Update1.Execute(m_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1250-SELECT-RCAP-NRCERTIF-DB-SELECT-2 */
        public void M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_2()
        {
            /*" -1880- EXEC SQL SELECT BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , DATA_RCAP INTO :RCAPCOMP-BCO-AVISO , :RCAPCOMP-AGE-AVISO , :RCAPCOMP-NUM-AVISO-CREDITO, :RCAPCOMP-DATA-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :RCAPS-COD-FONTE AND NUM_RCAP = :RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var m_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_2_Query1 = new M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_2_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_2_Query1.Execute(m_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
            }


        }

        [StopWatch]
        /*" M-1300-UPDATE-NUMERO-OUTROS-SECTION */
        private void M_1300_UPDATE_NUMERO_OUTROS_SECTION()
        {
            /*" -1931- MOVE '1300' TO PARAGRAFO. */
            _.Move("1300", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1933- MOVE 'UPDATE NUMERO_OUTROS' TO COMANDO. */
            _.Move("UPDATE NUMERO_OUTROS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1937- PERFORM M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1 */

            M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1();

            /*" -1940- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1942- DISPLAY '1300 - PROBLEMAS ATUALIZACAO NUMERO-OUTROS ' NUMEROUT-NUM-CERT-VGAP */
                _.Display($"1300 - PROBLEMAS ATUALIZACAO NUMERO-OUTROS {NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP}");

                /*" -1943- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1943- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1300-UPDATE-NUMERO-OUTROS-DB-UPDATE-1 */
        public void M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1()
        {
            /*" -1937- EXEC SQL UPDATE SEGUROS.NUMERO_OUTROS SET NUM_CERT_VGAP = :H-NUM-CERTIFICADO WHERE NUM_CERT_VGAP = :NUMEROUT-NUM-CERT-VGAP - 1 END-EXEC. */

            var m_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1 = new M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1()
            {
                H_NUM_CERTIFICADO = H_NUM_CERTIFICADO.ToString(),
                NUMEROUT_NUM_CERT_VGAP = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP.ToString(),
            };

            M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1.Execute(m_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/

        [StopWatch]
        /*" M-2000-INSERT-PROPOSTAVA-SECTION */
        private void M_2000_INSERT_PROPOSTAVA_SECTION()
        {
            /*" -1953- MOVE '2000' TO PARAGRAFO. */
            _.Move("2000", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1958- MOVE 'N' TO WS-TEM-ERRO. */
            _.Move("N", WS_WORK_AREAS.WS_TEM_ERRO);

            /*" -1959- IF VGSOLFAT-CAP-BAS-SEGURADO <= 36000 */

            if (VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO <= 36000)
            {

                /*" -1960- MOVE '1' TO WHOST-FAIXA-RENDA */
                _.Move("1", WHOST_FAIXA_RENDA);

                /*" -1961- ELSE */
            }
            else
            {


                /*" -1963- IF VGSOLFAT-CAP-BAS-SEGURADO > 36000 AND VGSOLFAT-CAP-BAS-SEGURADO <= 108000 */

                if (VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO > 36000 && VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO <= 108000)
                {

                    /*" -1964- MOVE '2' TO WHOST-FAIXA-RENDA */
                    _.Move("2", WHOST_FAIXA_RENDA);

                    /*" -1965- ELSE */
                }
                else
                {


                    /*" -1967- IF VGSOLFAT-CAP-BAS-SEGURADO > 108000 AND VGSOLFAT-CAP-BAS-SEGURADO <= 180000 */

                    if (VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO > 108000 && VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO <= 180000)
                    {

                        /*" -1968- MOVE '3' TO WHOST-FAIXA-RENDA */
                        _.Move("3", WHOST_FAIXA_RENDA);

                        /*" -1969- ELSE */
                    }
                    else
                    {


                        /*" -1971- IF VGSOLFAT-CAP-BAS-SEGURADO > 180000 AND VGSOLFAT-CAP-BAS-SEGURADO <= 300000 */

                        if (VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO > 180000 && VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO <= 300000)
                        {

                            /*" -1972- MOVE '4' TO WHOST-FAIXA-RENDA */
                            _.Move("4", WHOST_FAIXA_RENDA);

                            /*" -1973- ELSE */
                        }
                        else
                        {


                            /*" -1975- IF VGSOLFAT-CAP-BAS-SEGURADO > 300000 AND VGSOLFAT-CAP-BAS-SEGURADO <= 600000 */

                            if (VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO > 300000 && VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO <= 600000)
                            {

                                /*" -1976- MOVE '5' TO WHOST-FAIXA-RENDA */
                                _.Move("5", WHOST_FAIXA_RENDA);

                                /*" -1977- ELSE */
                            }
                            else
                            {


                                /*" -1978- MOVE '5' TO WHOST-FAIXA-RENDA */
                                _.Move("5", WHOST_FAIXA_RENDA);

                                /*" -1979- END-IF */
                            }


                            /*" -1980- END-IF */
                        }


                        /*" -1981- END-IF */
                    }


                    /*" -1982- END-IF */
                }


                /*" -1986- END-IF */
            }


            /*" -1987- IF (VGSOLFAT-NUM-TITULO > ZEROES) */

            if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO > 00))
            {

                /*" -1988- MOVE VGSOLFAT-DT-QUITBCO-TITULO TO PROPOVA-DATA-QUITACAO */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DT_QUITBCO_TITULO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);

                /*" -1989- ELSE */
            }
            else
            {


                /*" -1990- MOVE SUBGVGAP-DATA-INIVIGENCIA TO PROPOVA-DATA-QUITACAO */
                _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);

                /*" -1993- END-IF. */
            }


            /*" -1994- IF (WS-TEM-RCAP EQUAL 'S' ) */

            if ((WS_TEM_RCAP == "S"))
            {

                /*" -1995- IF (RCAPS-AGE-COBRANCA > ZEROS) */

                if ((RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA > 00))
                {

                    /*" -1996- MOVE RCAPS-AGE-COBRANCA TO PROPOVA-AGE-COBRANCA */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);

                    /*" -1997- ELSE */
                }
                else
                {


                    /*" -1998- IF (VGSOLFAT-AGECTADEB > ZEROS) */

                    if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_AGECTADEB > 00))
                    {

                        /*" -1999- MOVE VGSOLFAT-AGECTADEB TO PROPOVA-AGE-COBRANCA */
                        _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_AGECTADEB, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);

                        /*" -2000- ELSE */
                    }
                    else
                    {


                        /*" -2001- MOVE SUBGVGAP-AGE-COBRANCA TO PROPOVA-AGE-COBRANCA */
                        _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);

                        /*" -2002- END-IF */
                    }


                    /*" -2003- END-IF */
                }


                /*" -2004- ELSE */
            }
            else
            {


                /*" -2005- IF (VGSOLFAT-AGECTADEB > ZEROS) */

                if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_AGECTADEB > 00))
                {

                    /*" -2006- MOVE VGSOLFAT-AGECTADEB TO PROPOVA-AGE-COBRANCA */
                    _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_AGECTADEB, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);

                    /*" -2007- ELSE */
                }
                else
                {


                    /*" -2008- MOVE SUBGVGAP-AGE-COBRANCA TO PROPOVA-AGE-COBRANCA */
                    _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);

                    /*" -2009- END-IF */
                }


                /*" -2011- END-IF. */
            }


            /*" -2013- MOVE 'SELECT VG_PRODUTO_SIAS' TO COMANDO. */
            _.Move("SELECT VG_PRODUTO_SIAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2022- PERFORM M_2000_INSERT_PROPOSTAVA_DB_SELECT_1 */

            M_2000_INSERT_PROPOSTAVA_DB_SELECT_1();

            /*" -2025- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -2026- MOVE VGPROSIA-COD-PRODUTO TO PROPOVA-COD-PRODUTO */
                _.Move(VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);

                /*" -2027- ELSE */
            }
            else
            {


                /*" -2028- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -2029- MOVE ENDOSSOS-COD-PRODUTO TO PROPOVA-COD-PRODUTO */
                    _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);

                    /*" -2030- MOVE ZEROES TO VGPROSIA-COD-PRODUTO */
                    _.Move(0, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO);

                    /*" -2031- MOVE ZEROES TO VGPROSIA-COD-PRODUTO-EMP */
                    _.Move(0, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP);

                    /*" -2032- ELSE */
                }
                else
                {


                    /*" -2033- IF (SQLCODE NOT EQUAL ZEROS) */

                    if ((DB.SQLCODE != 00))
                    {

                        /*" -2034- DISPLAY '0889 - PROBLEMAS SELECT VG_PRODUTO_SIAS.' */
                        _.Display($"0889 - PROBLEMAS SELECT VG_PRODUTO_SIAS.");

                        /*" -2035- DISPLAY 'SQLCODE - ' SQLCODE */
                        _.Display($"SQLCODE - {DB.SQLCODE}");

                        /*" -2036- DISPLAY 'APOLICE - ' VGSOLFAT-NUM-APOLICE */
                        _.Display($"APOLICE - {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE}");

                        /*" -2037- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2038- END-IF */
                    }


                    /*" -2039- END-IF */
                }


                /*" -2039- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM M_2000_INSERT */

            M_2000_INSERT();

        }

        [StopWatch]
        /*" M-2000-INSERT-PROPOSTAVA-DB-SELECT-1 */
        public void M_2000_INSERT_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -2022- EXEC SQL SELECT COD_PRODUTO, COD_PRODUTO_EMP INTO :VGPROSIA-COD-PRODUTO, :VGPROSIA-COD-PRODUTO-EMP FROM SEGUROS.VG_PRODUTO_SIAS WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE AND NUM_PERIODO_PAG = :SUBGVGAP-PERI-FATURAMENTO WITH UR END-EXEC. */

            var m_2000_INSERT_PROPOSTAVA_DB_SELECT_1_Query1 = new M_2000_INSERT_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                SUBGVGAP_PERI_FATURAMENTO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO.ToString(),
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_2000_INSERT_PROPOSTAVA_DB_SELECT_1_Query1.Execute(m_2000_INSERT_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGPROSIA_COD_PRODUTO, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO);
                _.Move(executed_1.VGPROSIA_COD_PRODUTO_EMP, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP);
            }


        }

        [StopWatch]
        /*" M-2000-INSERT */
        private void M_2000_INSERT(bool isPerform = false)
        {
            /*" -2050- DISPLAY 'GRAVA PROPOSTA-VA ' ' APOL ' VGSOLFAT-NUM-APOLICE ' CERT ' NUMEROUT-NUM-CERT-VGAP ' USUARIO ' VGSOLFAT-COD-USUARIO(1:7) ' TEM-RCAP ' WS-TEM-RCAP ' SITUACAO ' PROPOVA-SIT-REGISTRO. */

            $"GRAVA PROPOSTA-VA  APOL {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} CERT {NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP} USUARIO {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_USUARIO.Substring(1, 7)} TEM-RCAP {WS_TEM_RCAP} SITUACAO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO}"
            .Display();

            /*" -2052- MOVE 'INSERT PROPOSTAS_VA' TO COMANDO. */
            _.Move("INSERT PROPOSTAS_VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2167- PERFORM M_2000_INSERT_DB_INSERT_1 */

            M_2000_INSERT_DB_INSERT_1();

            /*" -2170- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -2171- IF (PROPOVA-SIT-REGISTRO EQUAL '1' ) */

                if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "1"))
                {

                    /*" -2172- MOVE 1501 TO WS-COD-ERRO */
                    _.Move(1501, WS_COD_ERRO);

                    /*" -2174- PERFORM 4000-00-GRAVA-TAB-ERRO */

                    M_4000_00_GRAVA_TAB_ERRO_SECTION();

                    /*" -2175- END-IF */
                }


                /*" -2176- ELSE */
            }
            else
            {


                /*" -2177- IF (SQLCODE EQUAL -180) */

                if ((DB.SQLCODE == -180))
                {

                    /*" -2178- DISPLAY '2000 - DATA INVALIDA INSERT DA PROPOSTAVA' */
                    _.Display($"2000 - DATA INVALIDA INSERT DA PROPOSTAVA");

                    /*" -2179- DISPLAY 'CERTIF ' NUMEROUT-NUM-CERT-VGAP */
                    _.Display($"CERTIF {NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP}");

                    /*" -2180- DISPLAY 'DTINIV ' PROPOVA-DATA-QUITACAO */
                    _.Display($"DTINIV {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO}");

                    /*" -2181- DISPLAY 'PROX   ' PROPOVA-DTPROXVEN */
                    _.Display($"PROX   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN}");

                    /*" -2182- DISPLAY 'VENCTO ' PROPOVA-DATA-VENCIMENTO */
                    _.Display($"VENCTO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO}");

                    /*" -2183- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2184- ELSE */
                }
                else
                {


                    /*" -2185- IF (SQLCODE NOT EQUAL -803) */

                    if ((DB.SQLCODE != -803))
                    {

                        /*" -2187- DISPLAY '2000 - PROBLEMA INSERT DA PROPOSTAS_VA ' NUMEROUT-NUM-CERT-VGAP ' ' SQLCODE */

                        $"2000 - PROBLEMA INSERT DA PROPOSTAS_VA {NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP} {DB.SQLCODE}"
                        .Display();

                        /*" -2188- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2189- END-IF */
                    }


                    /*" -2190- END-IF */
                }


                /*" -2192- END-IF. */
            }


            /*" -2192- ADD 1 TO AC-I-PROPOSTAVA. */
            WS_WORK_AREAS.AC_I_PROPOSTAVA.Value = WS_WORK_AREAS.AC_I_PROPOSTAVA + 1;

        }

        [StopWatch]
        /*" M-2000-INSERT-DB-INSERT-1 */
        public void M_2000_INSERT_DB_INSERT_1()
        {
            /*" -2167- EXEC SQL INSERT INTO SEGUROS.PROPOSTAS_VA (NUM_CERTIFICADO , COD_PRODUTO , COD_CLIENTE , OCOREND , COD_FONTE , AGE_COBRANCA , OPCAO_COBERTURA , DATA_QUITACAO , COD_AGE_VENDEDOR , OPE_CONTA_VENDEDOR, NUM_CONTA_VENDEDOR, DIG_CONTA_VENDEDOR, NUM_MATRI_VENDEDOR, COD_OPERACAO , PROFISSAO , DTINCLUS , DATA_MOVIMENTO , SIT_REGISTRO , NUM_APOLICE , COD_SUBGRUPO , OCORR_HISTORICO , NRPRIPARATZ , QTDPARATZ , DTPROXVEN , NUM_PARCELA , DATA_VENCIMENTO , SIT_INTERFACE , DTFENAE , COD_USUARIO , TIMESTAMP , IDADE , IDE_SEXO , ESTADO_CIVIL , OPCAO_MARCADA , SIGLA_CRM , COD_CRM , APOS_INVALIDEZ , ASSINATURA , ACATAMENTO , NOME_ESPOSA , DTNASC_ESPOSA , PROFIS_ESPOSA , DPS_TITULAR , DPS_ESPOSA , NUM_MATRICULA , GRAU_PARENTESCO , DATA_ADMISSAO , NUM_PROPOSTA , EM_ATIVIDADE , LOC_ATIVIDADE , INFO_COMPLEMENTAR , NRMALADIR , NRCERTIFANT , COD_CCT , FAIXA_RENDA_IND , FAIXA_RENDA_FAM ) VALUES (:NUMEROUT-NUM-CERT-VGAP , :PROPOVA-COD-PRODUTO , :SUBGVGAP-COD-CLIENTE , :SUBGVGAP-OCORR-ENDERECO , :SUBGVGAP-COD-FONTE , :PROPOVA-AGE-COBRANCA , ' ' , :PROPOVA-DATA-QUITACAO , :TERMOADE-COD-AGENCIA-VEN , :TERMOADE-OPERACAO-CONTA-VEN, :TERMOADE-NUM-CONTA-VEN , :TERMOADE-DIG-CONTA-VEN , :TERMOADE-NUM-MATRICULA-VEN , 101 , ' ' , :SISTEMAS-DATA-MOV-ABERTO , :PROPOVA-DATA-QUITACAO , :PROPOVA-SIT-REGISTRO , :VGSOLFAT-NUM-APOLICE , :VGSOLFAT-COD-SUBGRUPO , 1 , 0 , 0 , :PROPOVA-DTPROXVEN , :PROPOVA-NUM-PARCELA , :PROPOVA-DATA-VENCIMENTO , ' ' , '9999-12-31' , 'VG0001B' , CURRENT TIMESTAMP , 0 , ' ' , ' ' , ' ' , NULL , NULL , NULL , NULL , NULL , NULL , NULL , NULL , NULL , NULL , 0 , NULL , NULL , :ENDOSSOS-NUM-PROPOSTA , NULL , NULL , NULL , NULL , NULL , NULL , :WHOST-FAIXA-RENDA , :WHOST-FAIXA-RENDA ) END-EXEC. */

            var m_2000_INSERT_DB_INSERT_1_Insert1 = new M_2000_INSERT_DB_INSERT_1_Insert1()
            {
                NUMEROUT_NUM_CERT_VGAP = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP.ToString(),
                PROPOVA_COD_PRODUTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.ToString(),
                SUBGVGAP_COD_CLIENTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE.ToString(),
                SUBGVGAP_OCORR_ENDERECO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO.ToString(),
                SUBGVGAP_COD_FONTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE.ToString(),
                PROPOVA_AGE_COBRANCA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA.ToString(),
                PROPOVA_DATA_QUITACAO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.ToString(),
                TERMOADE_COD_AGENCIA_VEN = TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_VEN.ToString(),
                TERMOADE_OPERACAO_CONTA_VEN = TERMOADE.DCLTERMO_ADESAO.TERMOADE_OPERACAO_CONTA_VEN.ToString(),
                TERMOADE_NUM_CONTA_VEN = TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_CONTA_VEN.ToString(),
                TERMOADE_DIG_CONTA_VEN = TERMOADE.DCLTERMO_ADESAO.TERMOADE_DIG_CONTA_VEN.ToString(),
                TERMOADE_NUM_MATRICULA_VEN = TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PROPOVA_SIT_REGISTRO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.ToString(),
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
                VGSOLFAT_COD_SUBGRUPO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO.ToString(),
                PROPOVA_DTPROXVEN = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
                PROPOVA_DATA_VENCIMENTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO.ToString(),
                ENDOSSOS_NUM_PROPOSTA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA.ToString(),
                WHOST_FAIXA_RENDA = WHOST_FAIXA_RENDA.ToString(),
            };

            M_2000_INSERT_DB_INSERT_1_Insert1.Execute(m_2000_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

        [StopWatch]
        /*" M-2100-INSERT-COBERPROPVA-SECTION */
        private void M_2100_INSERT_COBERPROPVA_SECTION()
        {
            /*" -2203- MOVE '2100' TO PARAGRAFO. */
            _.Move("2100", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2204- IF (HISCOBPR-IMP-MORNATU = ZEROS) */

            if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU == 00))
            {

                /*" -2206- MOVE HISCOBPR-IMPMORACID TO HISCOBPR-IMPSEGIND HISCOBPR-IMPSEGUR */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);

                /*" -2207- ELSE */
            }
            else
            {


                /*" -2209- MOVE HISCOBPR-IMP-MORNATU TO HISCOBPR-IMPSEGIND HISCOBPR-IMPSEGUR */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);

                /*" -2211- END-IF. */
            }


            /*" -2226- MOVE ZEROS TO HISCOBPR-IMPSEGCDG HISCOBPR-VLCUSTCDG. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG);

            /*" -2227- IF (VGPROSIA-COD-PRODUTO-EMP EQUAL 16) */

            if ((VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP == 16))
            {

                /*" -2228- MOVE VGFUNCOB-QTD-VIDAS TO VGSOLFAT-QUANT-VIDAS */
                _.Move(VGFUNCOB_QTD_VIDAS, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_QUANT_VIDAS);

                /*" -2232- MOVE VGFUNCOB-IMP-SEGURADA TO HISCOBPR-IMPSEGUR HISCOBPR-IMPSEGIND HISCOBPR-IMP-MORNATU HISCOBPR-IMPMORACID */
                _.Move(VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_IMP_SEGURADA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);

                /*" -2236- MOVE ZEROES TO HISCOBPR-IMPINVPERM HISCOBPR-IMPAMDS HISCOBPR-IMPDH HISCOBPR-IMPDIT */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);

                /*" -2238- MOVE VGFUNCOB-VLR-PREMIO TO HISCOBPR-PRMVG HISCOBPR-VLPREMIO */
                _.Move(VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_VLR_PREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);

                /*" -2239- MOVE ZEROES TO HISCOBPR-PRMAP */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

                /*" -2241- END-IF. */
            }


            /*" -2243- MOVE 'INSERT HIS_COBER_PROPOST' TO COMANDO. */
            _.Move("INSERT HIS_COBER_PROPOST", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2304- PERFORM M_2100_INSERT_COBERPROPVA_DB_INSERT_1 */

            M_2100_INSERT_COBERPROPVA_DB_INSERT_1();

            /*" -2307- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -2309- DISPLAY '2100 - PROBLEMA INSERT V0COBERPROPVA   ..' NUMEROUT-NUM-CERT-VGAP ' ' SQLCODE */

                $"2100 - PROBLEMA INSERT V0COBERPROPVA   ..{NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP} {DB.SQLCODE}"
                .Display();

                /*" -2310- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2312- END-IF. */
            }


            /*" -2312- ADD 1 TO AC-I-COBERPROPVA. */
            WS_WORK_AREAS.AC_I_COBERPROPVA.Value = WS_WORK_AREAS.AC_I_COBERPROPVA + 1;

        }

        [StopWatch]
        /*" M-2100-INSERT-COBERPROPVA-DB-INSERT-1 */
        public void M_2100_INSERT_COBERPROPVA_DB_INSERT_1()
        {
            /*" -2304- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT ) VALUES (:NUMEROUT-NUM-CERT-VGAP, 1, :HISCOBPR-DATA-INIVIGENCIA, '9999-12-31' , :HISCOBPR-IMPSEGUR, :VGSOLFAT-QUANT-VIDAS, :HISCOBPR-IMPSEGIND, 101, ' ' , :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPMORACID, :HISCOBPR-IMPINVPERM, :HISCOBPR-IMPAMDS, :HISCOBPR-IMPDH, :HISCOBPR-IMPDIT, :HISCOBPR-VLPREMIO, :HISCOBPR-PRMVG, :HISCOBPR-PRMAP, :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VAL-CUSTO-CAPITALI, :HISCOBPR-IMPSEGCDG, :HISCOBPR-VLCUSTCDG, 'VG0001B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL) END-EXEC. */

            var m_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 = new M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1()
            {
                NUMEROUT_NUM_CERT_VGAP = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP.ToString(),
                HISCOBPR_DATA_INIVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.ToString(),
                HISCOBPR_IMPSEGUR = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR.ToString(),
                VGSOLFAT_QUANT_VIDAS = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_QUANT_VIDAS.ToString(),
                HISCOBPR_IMPSEGIND = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND.ToString(),
                HISCOBPR_IMP_MORNATU = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU.ToString(),
                HISCOBPR_IMPMORACID = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID.ToString(),
                HISCOBPR_IMPINVPERM = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM.ToString(),
                HISCOBPR_IMPAMDS = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS.ToString(),
                HISCOBPR_IMPDH = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH.ToString(),
                HISCOBPR_IMPDIT = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT.ToString(),
                HISCOBPR_VLPREMIO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO.ToString(),
                HISCOBPR_PRMVG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG.ToString(),
                HISCOBPR_PRMAP = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP.ToString(),
                HISCOBPR_QTDE_TIT_CAPITALIZ = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_TIT_CAPITALIZ = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_CUSTO_CAPITALI = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI.ToString(),
                HISCOBPR_IMPSEGCDG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG.ToString(),
                HISCOBPR_VLCUSTCDG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG.ToString(),
            };

            M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1.Execute(m_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2100_FIM*/

        [StopWatch]
        /*" M-2400-INSERT-OPCAOPAGVA-SECTION */
        private void M_2400_INSERT_OPCAOPAGVA_SECTION()
        {
            /*" -2321- MOVE '2400' TO PARAGRAFO. */
            _.Move("2400", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2323- MOVE 'INSERT OPCAO_PAG_VIDAZUL' TO COMANDO. */
            _.Move("INSERT OPCAO_PAG_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2324- IF (VGCOMTRO-NUM-CARTAO-CREDITO > ZEROS) */

            if ((VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_CARTAO_CREDITO > 00))
            {

                /*" -2325- MOVE '5' TO OPCPAGVI-OPCAO-PAGAMENTO */
                _.Move("5", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                /*" -2327- END-IF. */
            }


            /*" -2329- MOVE VGCOMTRO-NUM-CARTAO-CREDITO TO WS-CARTAO-CREDITO-N */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_CARTAO_CREDITO, WS_CARTAO_CREDITO.WS_CARTAO_CREDITO_N);

            /*" -2332- MOVE WS-CARTAO-CREDITO TO OPCPAGVI-NUM-CARTAO-CREDITO. */
            _.Move(WS_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

            /*" -2361- PERFORM M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1 */

            M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1();

            /*" -2364- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -2367- DISPLAY '2400 - PROBLEMA INSERT DA OPCAOPAGVA ..' NUMEROUT-NUM-CERT-VGAP ' ' SQLCODE ' ' SQLERRMC */

                $"2400 - PROBLEMA INSERT DA OPCAOPAGVA ..{NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP} {DB.SQLCODE} {DB.SQLERRMC}"
                .Display();

                /*" -2368- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2370- END-IF. */
            }


            /*" -2371- IF (VGCOMTRO-NUM-CARTAO-CREDITO > ZEROS) */

            if ((VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_CARTAO_CREDITO > 00))
            {

                /*" -2372- MOVE '3' TO OPCPAGVI-OPCAO-PAGAMENTO */
                _.Move("3", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                /*" -2374- END-IF. */
            }


            /*" -2374- ADD 1 TO AC-I-OPCAOPAGVA. */
            WS_WORK_AREAS.AC_I_OPCAOPAGVA.Value = WS_WORK_AREAS.AC_I_OPCAOPAGVA + 1;

        }

        [StopWatch]
        /*" M-2400-INSERT-OPCAOPAGVA-DB-INSERT-1 */
        public void M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1()
        {
            /*" -2361- EXEC SQL INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL (NUM_CERTIFICADO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, OPCAO_PAGAMENTO, PERI_PAGAMENTO, DIA_DEBITO, COD_USUARIO, TIMESTAMP, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, NUM_CARTAO_CREDITO) VALUES (:NUMEROUT-NUM-CERT-VGAP, :PROPOVA-DATA-QUITACAO, '9999-12-31' , :OPCPAGVI-OPCAO-PAGAMENTO, :SUBGVGAP-PERI-FATURAMENTO, :OPCPAGVI-DIA-DEBITO, 'VG0001B' , CURRENT TIMESTAMP, :OPCPAGVI-COD-AGENCIA-DEBITO:HOST-IND, :OPCPAGVI-OPE-CONTA-DEBITO:HOST-IND, :OPCPAGVI-NUM-CONTA-DEBITO:HOST-IND, :OPCPAGVI-DIG-CONTA-DEBITO:HOST-IND, :OPCPAGVI-NUM-CARTAO-CREDITO) END-EXEC. */

            var m_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 = new M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1()
            {
                NUMEROUT_NUM_CERT_VGAP = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP.ToString(),
                PROPOVA_DATA_QUITACAO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.ToString(),
                OPCPAGVI_OPCAO_PAGAMENTO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.ToString(),
                SUBGVGAP_PERI_FATURAMENTO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO.ToString(),
                OPCPAGVI_DIA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO.ToString(),
                OPCPAGVI_COD_AGENCIA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO.ToString(),
                HOST_IND = HOST_IND.ToString(),
                OPCPAGVI_OPE_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO.ToString(),
                OPCPAGVI_NUM_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO.ToString(),
                OPCPAGVI_DIG_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO.ToString(),
                OPCPAGVI_NUM_CARTAO_CREDITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO.ToString(),
            };

            M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1.Execute(m_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2400_FIM*/

        [StopWatch]
        /*" M-2500-INSERT-PARCELVA-SECTION */
        private void M_2500_INSERT_PARCELVA_SECTION()
        {
            /*" -2383- MOVE '2500' TO PARAGRAFO. */
            _.Move("2500", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2386- MOVE 'INSERT PARCELAS_VIDAZUL' TO COMANDO. */
            _.Move("INSERT PARCELAS_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2387- IF (WS-TEM-RCAP EQUAL 'S' ) */

            if ((WS_TEM_RCAP == "S"))
            {

                /*" -2388- MOVE '1' TO PARCEVID-SIT-REGISTRO */
                _.Move("1", PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO);

                /*" -2389- MOVE '3' TO PARCEVID-OPCAO-PAGAMENTO */
                _.Move("3", PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OPCAO_PAGAMENTO);

                /*" -2390- ELSE */
            }
            else
            {


                /*" -2391- MOVE ' ' TO PARCEVID-SIT-REGISTRO */
                _.Move(" ", PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO);

                /*" -2392- MOVE OPCPAGVI-OPCAO-PAGAMENTO TO PARCEVID-OPCAO-PAGAMENTO */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OPCAO_PAGAMENTO);

                /*" -2394- END-IF. */
            }


            /*" -2395- IF (PARCEVID-OPCAO-PAGAMENTO EQUAL '1' OR '2' ) */

            if ((PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OPCAO_PAGAMENTO.In("1", "2")))
            {

                /*" -2396- MOVE 01 TO PARCEVID-OCORR-HISTORICO */
                _.Move(01, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO);

                /*" -2397- ELSE */
            }
            else
            {


                /*" -2398- MOVE ZEROS TO PARCEVID-OCORR-HISTORICO */
                _.Move(0, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO);

                /*" -2400- END-IF. */
            }


            /*" -2425- PERFORM M_2500_INSERT_PARCELVA_DB_INSERT_1 */

            M_2500_INSERT_PARCELVA_DB_INSERT_1();

            /*" -2428- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -2430- DISPLAY '2500 - PROBLEMA INSERT DA PARCELVA ...' NUMEROUT-NUM-CERT-VGAP ' ' SQLCODE */

                $"2500 - PROBLEMA INSERT DA PARCELVA ...{NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP} {DB.SQLCODE}"
                .Display();

                /*" -2431- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2433- END-IF. */
            }


            /*" -2433- ADD 1 TO AC-I-PARCELVA. */
            WS_WORK_AREAS.AC_I_PARCELVA.Value = WS_WORK_AREAS.AC_I_PARCELVA + 1;

        }

        [StopWatch]
        /*" M-2500-INSERT-PARCELVA-DB-INSERT-1 */
        public void M_2500_INSERT_PARCELVA_DB_INSERT_1()
        {
            /*" -2425- EXEC SQL INSERT INTO SEGUROS.PARCELAS_VIDAZUL (NUM_CERTIFICADO , NUM_PARCELA , DATA_VENCIMENTO , PREMIO_VG , PREMIO_AP , VLMULTA , OPCAO_PAGAMENTO , SIT_REGISTRO , OCORR_HISTORICO , TIMESTAMP) VALUES (:NUMEROUT-NUM-CERT-VGAP, :PROPOVA-NUM-PARCELA, :PROPOVA-DATA-VENCIMENTO, :HISCOBPR-PRMVG, :HISCOBPR-PRMAP, 0.0, :PARCEVID-OPCAO-PAGAMENTO, :PARCEVID-SIT-REGISTRO, :PARCEVID-OCORR-HISTORICO, CURRENT TIMESTAMP) END-EXEC. */

            var m_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1 = new M_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1()
            {
                NUMEROUT_NUM_CERT_VGAP = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
                PROPOVA_DATA_VENCIMENTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO.ToString(),
                HISCOBPR_PRMVG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG.ToString(),
                HISCOBPR_PRMAP = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP.ToString(),
                PARCEVID_OPCAO_PAGAMENTO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OPCAO_PAGAMENTO.ToString(),
                PARCEVID_SIT_REGISTRO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO.ToString(),
                PARCEVID_OCORR_HISTORICO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO.ToString(),
            };

            M_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1.Execute(m_2500_INSERT_PARCELVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2500_FIM*/

        [StopWatch]
        /*" M-2600-INSERT-HISTCOBVA-SECTION */
        private void M_2600_INSERT_HISTCOBVA_SECTION()
        {
            /*" -2442- MOVE '2600' TO PARAGRAFO. */
            _.Move("2600", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2444- MOVE 'INSERT COBER_HIST_VIDAZUL' TO COMANDO. */
            _.Move("INSERT COBER_HIST_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2445- IF (VGPROSIA-COD-PRODUTO-EMP EQUAL 16) */

            if ((VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP == 16))
            {

                /*" -2446- MOVE VGFUNCOB-VLR-PREMIO TO COBHISVI-PRM-TOTAL */
                _.Move(VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_VLR_PREMIO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL);

                /*" -2447- ELSE */
            }
            else
            {


                /*" -2449- COMPUTE COBHISVI-PRM-TOTAL = VGSOLFAT-PRM-VG + VGSOLFAT-PRM-AP */
                COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL.Value = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG + VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_AP;

                /*" -2452- END-IF. */
            }


            /*" -2453- IF (WS-TEM-RCAP EQUAL 'S' ) */

            if ((WS_TEM_RCAP == "S"))
            {

                /*" -2454- MOVE VGSOLFAT-NUM-TITULO TO COBHISVI-NUM-TITULO */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);

                /*" -2455- MOVE '1' TO COBHISVI-SIT-REGISTRO */
                _.Move("1", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

                /*" -2456- MOVE 1 TO COBHISVI-OCORR-HISTORICO */
                _.Move(1, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO);

                /*" -2457- MOVE RCAPCOMP-BCO-AVISO TO COBHISVI-BCO-AVISO */
                _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_BCO_AVISO);

                /*" -2458- MOVE RCAPCOMP-AGE-AVISO TO COBHISVI-AGE-AVISO */
                _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_AGE_AVISO);

                /*" -2460- MOVE RCAPCOMP-NUM-AVISO-CREDITO TO COBHISVI-NUM-AVISO-CREDITO */
                _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_AVISO_CREDITO);

                /*" -2461- ELSE */
            }
            else
            {


                /*" -2462- MOVE '5' TO COBHISVI-SIT-REGISTRO */
                _.Move("5", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

                /*" -2463- MOVE 0 TO COBHISVI-OCORR-HISTORICO */
                _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO);

                /*" -2464- MOVE ZEROS TO COBHISVI-BCO-AVISO */
                _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_BCO_AVISO);

                /*" -2465- MOVE ZEROS TO COBHISVI-AGE-AVISO */
                _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_AGE_AVISO);

                /*" -2466- MOVE ZEROS TO COBHISVI-NUM-AVISO-CREDITO */
                _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_AVISO_CREDITO);

                /*" -2467- PERFORM 2700-NUM-TITULO */

                M_2700_NUM_TITULO_SECTION();

                /*" -2468- MOVE BANCOS-NUM-TITULO TO COBHISVI-NUM-TITULO */
                _.Move(BANCOS.DCLBANCOS.BANCOS_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);

                /*" -2470- END-IF. */
            }


            /*" -2502- PERFORM M_2600_INSERT_HISTCOBVA_DB_INSERT_1 */

            M_2600_INSERT_HISTCOBVA_DB_INSERT_1();

            /*" -2506- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2507- DISPLAY '2600 - PROBLEMA INSERT COBER_HIST_VIDAZUL' */
                _.Display($"2600 - PROBLEMA INSERT COBER_HIST_VIDAZUL");

                /*" -2508- DISPLAY 'CERTIFICADO = ' NUMEROUT-NUM-CERT-VGAP */
                _.Display($"CERTIFICADO = {NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP}");

                /*" -2509- DISPLAY 'PARCELA     = ' PROPOVA-NUM-PARCELA */
                _.Display($"PARCELA     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA}");

                /*" -2510- DISPLAY 'TITULO      = ' COBHISVI-NUM-TITULO */
                _.Display($"TITULO      = {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO}");

                /*" -2511- DISPLAY 'SQLCODE     = ' SQLCODE */
                _.Display($"SQLCODE     = {DB.SQLCODE}");

                /*" -2512- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2514- END-IF. */
            }


            /*" -2514- ADD 1 TO AC-I-HISTCOBVA. */
            WS_WORK_AREAS.AC_I_HISTCOBVA.Value = WS_WORK_AREAS.AC_I_HISTCOBVA + 1;

        }

        [StopWatch]
        /*" M-2600-INSERT-HISTCOBVA-DB-INSERT-1 */
        public void M_2600_INSERT_HISTCOBVA_DB_INSERT_1()
        {
            /*" -2502- EXEC SQL INSERT INTO SEGUROS.COBER_HIST_VIDAZUL (NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , DATA_VENCIMENTO , PRM_TOTAL , OPCAO_PAGAMENTO , SIT_REGISTRO , COD_OPERACAO , OCORR_HISTORICO , COD_DEVOLUCAO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , NUM_TITULO_COMP) VALUES (:NUMEROUT-NUM-CERT-VGAP, :PROPOVA-NUM-PARCELA, :COBHISVI-NUM-TITULO, :WS-DTVENC-1PARC, :COBHISVI-PRM-TOTAL, :PARCEVID-OPCAO-PAGAMENTO, :COBHISVI-SIT-REGISTRO, 0, :COBHISVI-OCORR-HISTORICO, 0, :COBHISVI-BCO-AVISO , :COBHISVI-AGE-AVISO , :COBHISVI-NUM-AVISO-CREDITO, 0) END-EXEC. */

            var m_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 = new M_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1()
            {
                NUMEROUT_NUM_CERT_VGAP = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
                COBHISVI_NUM_TITULO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO.ToString(),
                WS_DTVENC_1PARC = WS_DTVENC_1PARC.ToString(),
                COBHISVI_PRM_TOTAL = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL.ToString(),
                PARCEVID_OPCAO_PAGAMENTO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OPCAO_PAGAMENTO.ToString(),
                COBHISVI_SIT_REGISTRO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO.ToString(),
                COBHISVI_OCORR_HISTORICO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO.ToString(),
                COBHISVI_BCO_AVISO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_BCO_AVISO.ToString(),
                COBHISVI_AGE_AVISO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_AGE_AVISO.ToString(),
                COBHISVI_NUM_AVISO_CREDITO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_AVISO_CREDITO.ToString(),
            };

            M_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1.Execute(m_2600_INSERT_HISTCOBVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2600_FIM*/

        [StopWatch]
        /*" M-2700-NUM-TITULO-SECTION */
        private void M_2700_NUM_TITULO_SECTION()
        {
            /*" -2523- MOVE '2700' TO PARAGRAFO. */
            _.Move("2700", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2525- MOVE 'SELECT BANCOS ' TO COMANDO. */
            _.Move("SELECT BANCOS ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2531- PERFORM M_2700_NUM_TITULO_DB_SELECT_1 */

            M_2700_NUM_TITULO_DB_SELECT_1();

            /*" -2534- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2535- DISPLAY '2700 - PROBLEMA SELECT BANCOS - 104 ...' */
                _.Display($"2700 - PROBLEMA SELECT BANCOS - 104 ...");

                /*" -2536- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2538- END-IF. */
            }


            /*" -2538- MOVE BANCOS-NUM-TITULO TO W-NUMR-TITULO. */
            _.Move(BANCOS.DCLBANCOS.BANCOS_NUM_TITULO, WS_WORK_AREAS.W_NUMR_TITULO);

            /*" -0- FLUXCONTROL_PERFORM M_2700_NUM_TITULO_SOMA */

            M_2700_NUM_TITULO_SOMA();

        }

        [StopWatch]
        /*" M-2700-NUM-TITULO-DB-SELECT-1 */
        public void M_2700_NUM_TITULO_DB_SELECT_1()
        {
            /*" -2531- EXEC SQL SELECT NUM_TITULO INTO :BANCOS-NUM-TITULO FROM SEGUROS.BANCOS WHERE COD_BANCO = 104 WITH UR END-EXEC. */

            var m_2700_NUM_TITULO_DB_SELECT_1_Query1 = new M_2700_NUM_TITULO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_2700_NUM_TITULO_DB_SELECT_1_Query1.Execute(m_2700_NUM_TITULO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BANCOS_NUM_TITULO, BANCOS.DCLBANCOS.BANCOS_NUM_TITULO);
            }


        }

        [StopWatch]
        /*" M-2700-NUM-TITULO-SOMA */
        private void M_2700_NUM_TITULO_SOMA(bool isPerform = false)
        {
            /*" -2543- ADD 1 TO WTITL-SEQUENCIA. */
            WS_WORK_AREAS.FILLER_19.WTITL_SEQUENCIA.Value = WS_WORK_AREAS.FILLER_19.WTITL_SEQUENCIA + 1;

            /*" -2545- MOVE WTITL-SEQUENCIA TO DPARM01. */
            _.Move(WS_WORK_AREAS.FILLER_19.WTITL_SEQUENCIA, WS_WORK_AREAS.DPARM01X.DPARM01);

            /*" -2547- CALL 'PROTIT01' USING DPARM01X. */
            _.Call("PROTIT01", WS_WORK_AREAS.DPARM01X);

            /*" -2548- IF (DPARM01-RC NOT EQUAL ZEROS) */

            if ((WS_WORK_AREAS.DPARM01X.DPARM01_RC != 00))
            {

                /*" -2549- DISPLAY 'ERRO CHAMADA PROTIT01 ' W-NUMR-TITULO */
                _.Display($"ERRO CHAMADA PROTIT01 {WS_WORK_AREAS.W_NUMR_TITULO}");

                /*" -2550- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2552- END-IF. */
            }


            /*" -2554- MOVE DPARM01-D1 TO WTITL-DIGITO. */
            _.Move(WS_WORK_AREAS.DPARM01X.DPARM01_D1, WS_WORK_AREAS.FILLER_19.WTITL_DIGITO);

            /*" -2557- MOVE W-NUMR-TITULO TO BANCOS-NUM-TITULO. */
            _.Move(WS_WORK_AREAS.W_NUMR_TITULO, BANCOS.DCLBANCOS.BANCOS_NUM_TITULO);

            /*" -2559- MOVE 'UPDATE BANCOS' TO COMANDO. */
            _.Move("UPDATE BANCOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2564- PERFORM M_2700_NUM_TITULO_SOMA_DB_UPDATE_1 */

            M_2700_NUM_TITULO_SOMA_DB_UPDATE_1();

            /*" -2568- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -2569- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2571- END-IF. */
            }


            /*" -2572- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2573- GO TO 2700-NUM-TITULO-SOMA */
                new Task(() => M_2700_NUM_TITULO_SOMA()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2574- END-IF */
            }


            /*" -2574- . */

        }

        [StopWatch]
        /*" M-2700-NUM-TITULO-SOMA-DB-UPDATE-1 */
        public void M_2700_NUM_TITULO_SOMA_DB_UPDATE_1()
        {
            /*" -2564- EXEC SQL UPDATE SEGUROS.BANCOS SET NUM_TITULO = :BANCOS-NUM-TITULO, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_BANCO = 104 END-EXEC. */

            var m_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1 = new M_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1()
            {
                BANCOS_NUM_TITULO = BANCOS.DCLBANCOS.BANCOS_NUM_TITULO.ToString(),
            };

            M_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1.Execute(m_2700_NUM_TITULO_SOMA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2700_FIM*/

        [StopWatch]
        /*" M-2800-INSERT-HISTCONTAVA-SECTION */
        private void M_2800_INSERT_HISTCONTAVA_SECTION()
        {
            /*" -2583- MOVE '2800' TO PARAGRAFO. */
            _.Move("2800", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2588- MOVE 'INSERT HIST_LANC_CTA ' TO COMANDO. */
            _.Move("INSERT HIST_LANC_CTA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2589- IF (VGSOLFAT-NUM-TITULO > ZEROES) */

            if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO > 00))
            {

                /*" -2590- GO TO 2800-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2800_FIM*/ //GOTO
                return;

                /*" -2592- END-IF. */
            }


            /*" -2593- IF (OPCPAGVI-OPCAO-PAGAMENTO NOT EQUAL '1' AND '2' ) */

            if ((!OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2")))
            {

                /*" -2594- GO TO 2800-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2800_FIM*/ //GOTO
                return;

                /*" -2596- END-IF. */
            }


            /*" -2597- MOVE '0' TO HISLANCT-SIT-REGISTRO */
            _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

            /*" -2598- MOVE '1' TO HISLANCT-TIPLANC */
            _.Move("1", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);

            /*" -2599- MOVE 1 TO HISLANCT-OCORR-HISTORICO */
            _.Move(1, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICO);

            /*" -2600- MOVE 6088 TO HISLANCT-CODCONV */
            _.Move(6088, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV);

            /*" -2602- MOVE 'VG0001B' TO HISLANCT-COD-USUARIO. */
            _.Move("VG0001B", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_USUARIO);

            /*" -2643- PERFORM M_2800_INSERT_HISTCONTAVA_DB_INSERT_1 */

            M_2800_INSERT_HISTCONTAVA_DB_INSERT_1();

            /*" -2646- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -2648- DISPLAY '2800 - PROBLEMA INSERT DA HISTCONTAVA ...' NUMEROUT-NUM-CERT-VGAP ' ' SQLCODE */

                $"2800 - PROBLEMA INSERT DA HISTCONTAVA ...{NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP} {DB.SQLCODE}"
                .Display();

                /*" -2649- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2651- END-IF. */
            }


            /*" -2651- ADD 1 TO AC-I-HISTCTAVA. */
            WS_WORK_AREAS.AC_I_HISTCTAVA.Value = WS_WORK_AREAS.AC_I_HISTCTAVA + 1;

        }

        [StopWatch]
        /*" M-2800-INSERT-HISTCONTAVA-DB-INSERT-1 */
        public void M_2800_INSERT_HISTCONTAVA_DB_INSERT_1()
        {
            /*" -2643- EXEC SQL INSERT INTO SEGUROS.HIST_LANC_CTA (NUM_CERTIFICADO , NUM_PARCELA , OCORR_HISTORICOCTA , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO , DATA_VENCIMENTO , PRM_TOTAL , SIT_REGISTRO , TIPLANC , TIMESTAMP , OCORR_HISTORICO , CODCONV , NSAS , NSL , NSAC , CODRET , COD_USUARIO) VALUES (:NUMEROUT-NUM-CERT-VGAP, :PROPOVA-NUM-PARCELA, 1, :OPCPAGVI-COD-AGENCIA-DEBITO, :OPCPAGVI-OPE-CONTA-DEBITO, :OPCPAGVI-NUM-CONTA-DEBITO, :OPCPAGVI-DIG-CONTA-DEBITO, :PROPOVA-DATA-VENCIMENTO, :COBHISVI-PRM-TOTAL, :HISLANCT-SIT-REGISTRO, :HISLANCT-TIPLANC, CURRENT TIMESTAMP, :HISLANCT-OCORR-HISTORICO, :HISLANCT-CODCONV, NULL, NULL, NULL, NULL, :HISLANCT-COD-USUARIO) END-EXEC. */

            var m_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1 = new M_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1()
            {
                NUMEROUT_NUM_CERT_VGAP = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
                OPCPAGVI_COD_AGENCIA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO.ToString(),
                OPCPAGVI_OPE_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO.ToString(),
                OPCPAGVI_NUM_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO.ToString(),
                OPCPAGVI_DIG_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO.ToString(),
                PROPOVA_DATA_VENCIMENTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO.ToString(),
                COBHISVI_PRM_TOTAL = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL.ToString(),
                HISLANCT_SIT_REGISTRO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO.ToString(),
                HISLANCT_TIPLANC = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC.ToString(),
                HISLANCT_OCORR_HISTORICO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICO.ToString(),
                HISLANCT_CODCONV = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV.ToString(),
                HISLANCT_COD_USUARIO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_USUARIO.ToString(),
            };

            M_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1.Execute(m_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2800_FIM*/

        [StopWatch]
        /*" M-2900-INSERT-HISTCONTABILVA-SECTION */
        private void M_2900_INSERT_HISTCONTABILVA_SECTION()
        {
            /*" -2664- MOVE '2900' TO PARAGRAFO. */
            _.Move("2900", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2665- IF (VGSOLFAT-NUM-TITULO EQUAL ZEROES) */

            if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO == 00))
            {

                /*" -2666- GO TO 2900-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2900_FIM*/ //GOTO
                return;

                /*" -2668- END-IF. */
            }


            /*" -2670- MOVE 'SELECT FATURAS ' TO COMANDO. */
            _.Move("SELECT FATURAS ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2681- PERFORM M_2900_INSERT_HISTCONTABILVA_DB_SELECT_1 */

            M_2900_INSERT_HISTCONTABILVA_DB_SELECT_1();

            /*" -2684- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2686- DISPLAY '2900 - PROBLEMAS NA LEITURA DA FATURAS   ' VGSOLFAT-NUM-APOLICE */
                _.Display($"2900 - PROBLEMAS NA LEITURA DA FATURAS   {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE}");

                /*" -2687- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2689- END-IF. */
            }


            /*" -2690- IF (FATURAS-NUM-FATURA EQUAL ZEROS) */

            if ((FATURAS.DCLFATURAS.FATURAS_NUM_FATURA == 00))
            {

                /*" -2691- MOVE '0' TO HISCONPA-SIT-REGISTRO */
                _.Move("0", HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO);

                /*" -2692- MOVE -1 TO HISCONPA-DTFATUR-I */
                _.Move(-1, HISCONPA_DTFATUR_I);

                /*" -2693- MOVE SPACES TO HISCONPA-DTFATUR */
                _.Move("", HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR);

                /*" -2694- MOVE ZEROS TO HISCONPA-NUM-ENDOSSO */
                _.Move(0, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);

                /*" -2695- ELSE */
            }
            else
            {


                /*" -2697- MOVE 'SELECT FATURAS 2 ' TO COMANDO */
                _.Move("SELECT FATURAS 2 ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2707- PERFORM M_2900_INSERT_HISTCONTABILVA_DB_SELECT_2 */

                M_2900_INSERT_HISTCONTABILVA_DB_SELECT_2();

                /*" -2710- IF (SQLCODE NOT EQUAL ZEROES) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -2714- DISPLAY '2900 - PROBLEMAS NA LEITURA DA FATURAS 2 ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO ' ' FATURAS-NUM-FATURA */

                    $"2900 - PROBLEMAS NA LEITURA DA FATURAS 2 {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO} {FATURAS.DCLFATURAS.FATURAS_NUM_FATURA}"
                    .Display();

                    /*" -2715- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2717- END-IF */
                }


                /*" -2718- MOVE FATURAS-NUM-ENDOSSO TO HISCONPA-NUM-ENDOSSO */
                _.Move(FATURAS.DCLFATURAS.FATURAS_NUM_ENDOSSO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);

                /*" -2719- MOVE FATURAS-DATA-FATURA TO HISCONPA-DTFATUR */
                _.Move(FATURAS.DCLFATURAS.FATURAS_DATA_FATURA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR);

                /*" -2720- MOVE ZEROS TO HISCONPA-DTFATUR-I */
                _.Move(0, HISCONPA_DTFATUR_I);

                /*" -2721- MOVE '1' TO HISCONPA-SIT-REGISTRO */
                _.Move("1", HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO);

                /*" -2723- END-IF. */
            }


            /*" -2725- MOVE ZEROES TO HISCONPA-PREMIO-AP. */
            _.Move(0, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

            /*" -2730- COMPUTE WS-PCT-VG ROUNDED = VGSOLFAT-PRM-VG / VGSOLFAT-PRM-TOTAL. */
            WS_WORK_AREAS.WS_PCT_VG.Value = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG / VGSOLFAT_PRM_TOTAL;

            /*" -2731- IF (SUBGVGAP-OPCAO-COBERTURA NOT EQUAL '2' ) */

            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_COBERTURA != "2"))
            {

                /*" -2732- COMPUTE WS-PCT-AP = 1 - WS-PCT-VG */
                WS_WORK_AREAS.WS_PCT_AP.Value = 1 - WS_WORK_AREAS.WS_PCT_VG;

                /*" -2734- END-IF. */
            }


            /*" -2737- COMPUTE HISCONPA-PREMIO-VG ROUNDED = RCAPS-VAL-RCAP * WS-PCT-VG */
            HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG.Value = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP * WS_WORK_AREAS.WS_PCT_VG;

            /*" -2738- IF (SUBGVGAP-OPCAO-COBERTURA NOT EQUAL '2' ) */

            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_COBERTURA != "2"))
            {

                /*" -2740- COMPUTE HISCONPA-PREMIO-AP = RCAPS-VAL-RCAP - HISCONPA-PREMIO-VG */
                HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP.Value = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP - HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG;

                /*" -2742- END-IF. */
            }


            /*" -2743- MOVE VGSOLFAT-NUM-TITULO TO HISCONPA-NUM-TITULO */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO);

            /*" -2745- MOVE 1 TO HISCONPA-OCORR-HISTORICO */
            _.Move(1, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);

            /*" -2746- IF (VGPROSIA-COD-PRODUTO-EMP EQUAL 16) */

            if ((VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP == 16))
            {

                /*" -2747- MOVE VGFUNCOB-VLR-PREMIO TO VGSOLFAT-PRM-TOTAL */
                _.Move(VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_VLR_PREMIO, VGSOLFAT_PRM_TOTAL);

                /*" -2749- END-IF. */
            }


            /*" -2750- IF (RCAPS-VAL-RCAP EQUAL VGSOLFAT-PRM-TOTAL) */

            if ((RCAPS.DCLRCAPS.RCAPS_VAL_RCAP == VGSOLFAT_PRM_TOTAL))
            {

                /*" -2751- MOVE VGSOLFAT-PRM-VG TO HISCONPA-PREMIO-VG */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);

                /*" -2752- MOVE VGSOLFAT-PRM-AP TO HISCONPA-PREMIO-AP */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

                /*" -2753- MOVE 201 TO HISCONPA-COD-OPERACAO */
                _.Move(201, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

                /*" -2754- ELSE */
            }
            else
            {


                /*" -2755- IF (RCAPS-VAL-RCAP > VGSOLFAT-PRM-TOTAL) */

                if ((RCAPS.DCLRCAPS.RCAPS_VAL_RCAP > VGSOLFAT_PRM_TOTAL))
                {

                    /*" -2756- MOVE 207 TO HISCONPA-COD-OPERACAO */
                    _.Move(207, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

                    /*" -2757- ELSE */
                }
                else
                {


                    /*" -2758- IF (RCAPS-VAL-RCAP < VGSOLFAT-PRM-TOTAL) */

                    if ((RCAPS.DCLRCAPS.RCAPS_VAL_RCAP < VGSOLFAT_PRM_TOTAL))
                    {

                        /*" -2759- MOVE 206 TO HISCONPA-COD-OPERACAO */
                        _.Move(206, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

                        /*" -2760- ELSE */
                    }
                    else
                    {


                        /*" -2761- MOVE VGSOLFAT-PRM-VG TO HISCONPA-PREMIO-VG */
                        _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);

                        /*" -2762- MOVE VGSOLFAT-PRM-AP TO HISCONPA-PREMIO-AP */
                        _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

                        /*" -2763- MOVE 201 TO HISCONPA-COD-OPERACAO */
                        _.Move(201, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

                        /*" -2764- END-IF */
                    }


                    /*" -2765- END-IF */
                }


                /*" -2767- END-IF. */
            }


            /*" -2769- MOVE 'INSERT HIST_CONT_PARCELVA' TO COMANDO. */
            _.Move("INSERT HIST_CONT_PARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2802- PERFORM M_2900_INSERT_HISTCONTABILVA_DB_INSERT_1 */

            M_2900_INSERT_HISTCONTABILVA_DB_INSERT_1();

            /*" -2805- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -2807- DISPLAY '2900 - PROBLEMA INSERT DA HISTCONTABILVA ..' NUMEROUT-NUM-CERT-VGAP ' ' SQLCODE */

                $"2900 - PROBLEMA INSERT DA HISTCONTABILVA ..{NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP} {DB.SQLCODE}"
                .Display();

                /*" -2808- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2810- END-IF. */
            }


            /*" -2810- ADD 1 TO AC-I-HISTCTABI. */
            WS_WORK_AREAS.AC_I_HISTCTABI.Value = WS_WORK_AREAS.AC_I_HISTCTABI + 1;

        }

        [StopWatch]
        /*" M-2900-INSERT-HISTCONTABILVA-DB-SELECT-1 */
        public void M_2900_INSERT_HISTCONTABILVA_DB_SELECT_1()
        {
            /*" -2681- EXEC SQL SELECT VALUE(MIN(NUM_FATURA),0) INTO :FATURAS-NUM-FATURA FROM SEGUROS.FATURAS WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE AND COD_SUBGRUPO = :VGSOLFAT-COD-SUBGRUPO AND COD_OPERACAO IN (200, 300) AND NUM_ENDOSSO > 0 AND NUM_RCAP = :RCAPS-NUM-RCAP AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var m_2900_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1 = new M_2900_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1()
            {
                VGSOLFAT_COD_SUBGRUPO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO.ToString(),
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = M_2900_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1.Execute(m_2900_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURAS_NUM_FATURA, FATURAS.DCLFATURAS.FATURAS_NUM_FATURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2900_FIM*/

        [StopWatch]
        /*" M-2900-INSERT-HISTCONTABILVA-DB-INSERT-1 */
        public void M_2900_INSERT_HISTCONTABILVA_DB_INSERT_1()
        {
            /*" -2802- EXEC SQL INSERT INTO SEGUROS.HIST_CONT_PARCELVA (NUM_CERTIFICADO, NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO, NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_ENDOSSO , PREMIO_VG , PREMIO_AP , DATA_MOVIMENTO , SIT_REGISTRO , COD_OPERACAO , TIMESTAMP , DTFATUR) VALUES (:NUMEROUT-NUM-CERT-VGAP, :PROPOVA-NUM-PARCELA, :HISCONPA-NUM-TITULO, :HISCONPA-OCORR-HISTORICO, :VGSOLFAT-NUM-APOLICE, :VGSOLFAT-COD-SUBGRUPO, :SUBGVGAP-COD-FONTE, :HISCONPA-NUM-ENDOSSO, :HISCONPA-PREMIO-VG, :HISCONPA-PREMIO-AP, :SISTEMAS-DATA-MOV-ABERTO, :HISCONPA-SIT-REGISTRO, :HISCONPA-COD-OPERACAO, CURRENT TIMESTAMP, :HISCONPA-DTFATUR:HISCONPA-DTFATUR-I) END-EXEC. */

            var m_2900_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1 = new M_2900_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1()
            {
                NUMEROUT_NUM_CERT_VGAP = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
                HISCONPA_NUM_TITULO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO.ToString(),
                HISCONPA_OCORR_HISTORICO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO.ToString(),
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
                VGSOLFAT_COD_SUBGRUPO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO.ToString(),
                SUBGVGAP_COD_FONTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE.ToString(),
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
                HISCONPA_PREMIO_VG = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG.ToString(),
                HISCONPA_PREMIO_AP = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                HISCONPA_SIT_REGISTRO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO.ToString(),
                HISCONPA_COD_OPERACAO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO.ToString(),
                HISCONPA_DTFATUR = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR.ToString(),
                HISCONPA_DTFATUR_I = HISCONPA_DTFATUR_I.ToString(),
            };

            M_2900_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1.Execute(m_2900_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-2900-INSERT-HISTCONTABILVA-DB-SELECT-2 */
        public void M_2900_INSERT_HISTCONTABILVA_DB_SELECT_2()
        {
            /*" -2707- EXEC SQL SELECT NUM_ENDOSSO, DATA_FATURA INTO :FATURAS-NUM-ENDOSSO, :FATURAS-DATA-FATURA FROM SEGUROS.FATURAS WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE AND COD_SUBGRUPO = :VGSOLFAT-COD-SUBGRUPO AND NUM_FATURA = :FATURAS-NUM-FATURA WITH UR END-EXEC */

            var m_2900_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1 = new M_2900_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1()
            {
                VGSOLFAT_COD_SUBGRUPO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO.ToString(),
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
                FATURAS_NUM_FATURA = FATURAS.DCLFATURAS.FATURAS_NUM_FATURA.ToString(),
            };

            var executed_1 = M_2900_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1.Execute(m_2900_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURAS_NUM_ENDOSSO, FATURAS.DCLFATURAS.FATURAS_NUM_ENDOSSO);
                _.Move(executed_1.FATURAS_DATA_FATURA, FATURAS.DCLFATURAS.FATURAS_DATA_FATURA);
            }


        }

        [StopWatch]
        /*" M-3000-INSERT-CONVENIOSVG-SECTION */
        private void M_3000_INSERT_CONVENIOSVG_SECTION()
        {
            /*" -2819- MOVE '3000' TO PARAGRAFO. */
            _.Move("3000", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2822- MOVE 'INSERT CONVENIOS_VG ' TO COMANDO. */
            _.Move("INSERT CONVENIOS_VG ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2823- MOVE VGSOLFAT-NUM-APOLICE TO CONVEVG-NUM-APOLICE */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE, CONVEVG.DCLCONVENIOS_VG.CONVEVG_NUM_APOLICE);

            /*" -2824- MOVE VGSOLFAT-COD-SUBGRUPO TO CONVEVG-CODSUBES */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO, CONVEVG.DCLCONVENIOS_VG.CONVEVG_CODSUBES);

            /*" -2827- MOVE 6088 TO CONVEVG-COD-SEGURO CONVEVG-COD-AJUSTE CONVEVG-COD-COMISSAO */
            _.Move(6088, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_SEGURO, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_AJUSTE, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_COMISSAO);

            /*" -2828- MOVE 6090 TO CONVEVG-COD-NAOACEITE */
            _.Move(6090, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);

            /*" -2830- MOVE 'VG0001B' TO CONVEVG-CODUSU */
            _.Move("VG0001B", CONVEVG.DCLCONVENIOS_VG.CONVEVG_CODUSU);

            /*" -2849- PERFORM M_3000_INSERT_CONVENIOSVG_DB_INSERT_1 */

            M_3000_INSERT_CONVENIOSVG_DB_INSERT_1();

            /*" -2852- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -2854- DISPLAY '3000 - PROBLEMA INSERT DA CONVENIOSVG ..' NUMEROUT-NUM-CERT-VGAP ' ' SQLCODE */

                $"3000 - PROBLEMA INSERT DA CONVENIOSVG ..{NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP} {DB.SQLCODE}"
                .Display();

                /*" -2855- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2857- END-IF. */
            }


            /*" -2857- ADD 1 TO AC-I-CONVEVG. */
            WS_WORK_AREAS.AC_I_CONVEVG.Value = WS_WORK_AREAS.AC_I_CONVEVG + 1;

        }

        [StopWatch]
        /*" M-3000-INSERT-CONVENIOSVG-DB-INSERT-1 */
        public void M_3000_INSERT_CONVENIOSVG_DB_INSERT_1()
        {
            /*" -2849- EXEC SQL INSERT INTO SEGUROS.CONVENIOS_VG (NUM_APOLICE , CODSUBES , COD_SEGURO , COD_AJUSTE , COD_COMISSAO , COD_NAOACEITE , CODUSU , TIMESTAMP) VALUES (:CONVEVG-NUM-APOLICE, :CONVEVG-CODSUBES , :CONVEVG-COD-SEGURO , :CONVEVG-COD-AJUSTE , :CONVEVG-COD-COMISSAO, :CONVEVG-COD-NAOACEITE, :CONVEVG-CODUSU, CURRENT TIMESTAMP) END-EXEC. */

            var m_3000_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1 = new M_3000_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1()
            {
                CONVEVG_NUM_APOLICE = CONVEVG.DCLCONVENIOS_VG.CONVEVG_NUM_APOLICE.ToString(),
                CONVEVG_CODSUBES = CONVEVG.DCLCONVENIOS_VG.CONVEVG_CODSUBES.ToString(),
                CONVEVG_COD_SEGURO = CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_SEGURO.ToString(),
                CONVEVG_COD_AJUSTE = CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_AJUSTE.ToString(),
                CONVEVG_COD_COMISSAO = CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_COMISSAO.ToString(),
                CONVEVG_COD_NAOACEITE = CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE.ToString(),
                CONVEVG_CODUSU = CONVEVG.DCLCONVENIOS_VG.CONVEVG_CODUSU.ToString(),
            };

            M_3000_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1.Execute(m_3000_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/

        [StopWatch]
        /*" M-3100-INSERT-PRODUTOSVG-SECTION */
        private void M_3100_INSERT_PRODUTOSVG_SECTION()
        {
            /*" -2867- MOVE '3100' TO PARAGRAFO. */
            _.Move("3100", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2868- MOVE VGSOLFAT-NUM-APOLICE TO PRODUVG-NUM-APOLICE */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE);

            /*" -2873- MOVE VGSOLFAT-COD-SUBGRUPO TO PRODUVG-COD-SUBGRUPO */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO);

            /*" -2874- IF (VGPROSIA-COD-PRODUTO-EMP EQUAL 1) */

            if ((VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP == 1))
            {

                /*" -2875- MOVE 'VE' TO PRODUVG-ID-SISTEMA */
                _.Move("VE", PRODUVG.DCLPRODUTOS_VG.PRODUVG_ID_SISTEMA);

                /*" -2876- MOVE 'EMP' TO PRODUVG-COD-PRODUTO-AZUL */
                _.Move("EMP", PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_AZUL);

                /*" -2877- MOVE PROPOVA-COD-PRODUTO TO PRODUVG-COD-PRODUTO */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);

                /*" -2878- MOVE 'EMPRE' TO PRODUVG-ORIG-PRODU */
                _.Move("EMPRE", PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);

                /*" -2879- MOVE '5' TO PRODUVG-OPCAO-PAGAMENTO */
                _.Move("5", PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO);

                /*" -2880- ELSE */
            }
            else
            {


                /*" -2881- IF (VGPROSIA-COD-PRODUTO-EMP EQUAL 16) */

                if ((VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP == 16))
                {

                    /*" -2882- MOVE 'VE' TO PRODUVG-ID-SISTEMA */
                    _.Move("VE", PRODUVG.DCLPRODUTOS_VG.PRODUVG_ID_SISTEMA);

                    /*" -2883- MOVE 'EMP' TO PRODUVG-COD-PRODUTO-AZUL */
                    _.Move("EMP", PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_AZUL);

                    /*" -2884- MOVE PROPOVA-COD-PRODUTO TO PRODUVG-COD-PRODUTO */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);

                    /*" -2885- MOVE 'EMPRE' TO PRODUVG-ORIG-PRODU */
                    _.Move("EMPRE", PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);

                    /*" -2886- MOVE '3' TO PRODUVG-OPCAO-PAGAMENTO */
                    _.Move("3", PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO);

                    /*" -2887- END-IF */
                }


                /*" -2889- END-IF. */
            }


            /*" -2890- IF (VGPROSIA-COD-PRODUTO-EMP EQUAL ZEROS) */

            if ((VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO_EMP == 00))
            {

                /*" -2891- MOVE 'VG' TO PRODUVG-ID-SISTEMA */
                _.Move("VG", PRODUVG.DCLPRODUTOS_VG.PRODUVG_ID_SISTEMA);

                /*" -2893- MOVE 'ESP' TO PRODUVG-COD-PRODUTO-AZUL */
                _.Move("ESP", PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_AZUL);

                /*" -2894- IF (VGSOLFAT-NUM-APOLICE = 109300000799) */

                if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE == 109300000799))
                {

                    /*" -2895- MOVE 'ESPE1 ' TO PRODUVG-ORIG-PRODU */
                    _.Move("ESPE1 ", PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);

                    /*" -2896- ELSE */
                }
                else
                {


                    /*" -2897- MOVE 'ESPEC' TO PRODUVG-ORIG-PRODU */
                    _.Move("ESPEC", PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);

                    /*" -2899- END-IF */
                }


                /*" -2901- MOVE ENDOSSOS-COD-PRODUTO TO PRODUVG-COD-PRODUTO */
                _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);

                /*" -2902- MOVE '7' TO PRODUVG-OPCAO-PAGAMENTO */
                _.Move("7", PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO);

                /*" -2904- END-IF. */
            }


            /*" -2906- MOVE 'SELECT  PRODUTO' TO COMANDO. */
            _.Move("SELECT  PRODUTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2912- PERFORM M_3100_INSERT_PRODUTOSVG_DB_SELECT_1 */

            M_3100_INSERT_PRODUTOSVG_DB_SELECT_1();

            /*" -2915- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2919- DISPLAY 'PROBLEMAS NA LEITURA DA PRODUTO ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO ' ' PRODUVG-COD-PRODUTO */

                $"PROBLEMAS NA LEITURA DA PRODUTO {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO} {PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO}"
                .Display();

                /*" -2920- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -2922- END-IF. */
            }


            /*" -2923- MOVE PRODUTO-DESCR-PRODUTO TO PRODUVG-NOME-PRODUTO */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);

            /*" -2924- MOVE SUBGVGAP-PERI-FATURAMENTO TO PRODUVG-PERI-PAGAMENTO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);

            /*" -2926- MOVE 1 TO PRODUVG-DIAS-INICIO-VIGENC */
            _.Move(1, PRODUVG.DCLPRODUTOS_VG.PRODUVG_DIAS_INICIO_VIGENC);

            /*" -2927- MOVE HISCOBPR-DATA-INIVIGENCIA TO PRODUVG-DATA-MINVIGENCIA */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA, PRODUVG.DCLPRODUTOS_VG.PRODUVG_DATA_MINVIGENCIA);

            /*" -2928- MOVE '9999-12-31' TO PRODUVG-DATA-MAXVIGENCIA */
            _.Move("9999-12-31", PRODUVG.DCLPRODUTOS_VG.PRODUVG_DATA_MAXVIGENCIA);

            /*" -2931- MOVE '0' TO PRODUVG-SIT-PLANO-CEF */
            _.Move("0", PRODUVG.DCLPRODUTOS_VG.PRODUVG_SIT_PLANO_CEF);

            /*" -2932- MOVE 27 TO PRODUVG-COD-CEDENTE */
            _.Move(27, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_CEDENTE);

            /*" -2933- MOVE 'N' TO PRODUVG-OPC-AGENCTO-SUREG */
            _.Move("N", PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPC_AGENCTO_SUREG);

            /*" -2934- MOVE 0 TO PRODUVG-OPCAO-CAPITALIZ */
            _.Move(0, PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_CAPITALIZ);

            /*" -2935- MOVE ' ' TO PRODUVG-COD-SERIE */
            _.Move(" ", PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SERIE);

            /*" -2937- MOVE 0 TO PRODUVG-NUM-SEQ-TITULO PRODUVG-NUM-MALA-DIRETA */
            _.Move(0, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_SEQ_TITULO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_MALA_DIRETA);

            /*" -2938- MOVE ENDOSSOS-RAMO-EMISSOR TO PRODUVG-RAMO */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR, PRODUVG.DCLPRODUTOS_VG.PRODUVG_RAMO);

            /*" -2940- MOVE 'N' TO PRODUVG-CANCELA-ANTIGO */
            _.Move("N", PRODUVG.DCLPRODUTOS_VG.PRODUVG_CANCELA_ANTIGO);

            /*" -2941- IF (VGSOLFAT-NUM-APOLICE EQUAL 109300000799) */

            if ((VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE == 109300000799))
            {

                /*" -2942- MOVE 99 TO PRODUVG-DIA-FATURA */
                _.Move(99, PRODUVG.DCLPRODUTOS_VG.PRODUVG_DIA_FATURA);

                /*" -2943- ELSE */
            }
            else
            {


                /*" -2944- MOVE 31 TO PRODUVG-DIA-FATURA */
                _.Move(31, PRODUVG.DCLPRODUTOS_VG.PRODUVG_DIA_FATURA);

                /*" -2946- END-IF */
            }


            /*" -2947- MOVE 'MULT' TO PRODUVG-ESTR-COBR */
            _.Move("MULT", PRODUVG.DCLPRODUTOS_VG.PRODUVG_ESTR_COBR);

            /*" -2948- MOVE PRODUVG-ORIG-PRODU TO PRODUVG-ESTR-EMISS */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ESTR_EMISS);

            /*" -2949- MOVE 'VG0420B' TO PRODUVG-CODRELAT */
            _.Move("VG0420B", PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT);

            /*" -2951- MOVE 'S' TO PRODUVG-COBERADIC-PREMIO PRODUVG-CUSTOCAP-TOTAL */
            _.Move("S", PRODUVG.DCLPRODUTOS_VG.PRODUVG_COBERADIC_PREMIO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_CUSTOCAP_TOTAL);

            /*" -2953- MOVE 0,00 TO PRODUVG-DESCONTO-ADESAO. */
            _.Move(0.00, PRODUVG.DCLPRODUTOS_VG.PRODUVG_DESCONTO_ADESAO);

            /*" -2955- MOVE 'SELECT VG_COBER_TERMO G15' TO COMANDO. */
            _.Move("SELECT VG_COBER_TERMO G15", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2963- PERFORM M_3100_INSERT_PRODUTOSVG_DB_SELECT_2 */

            M_3100_INSERT_PRODUTOSVG_DB_SELECT_2();

            /*" -2966- IF (SQLCODE EQUAL ZEROES) */

            if ((DB.SQLCODE == 00))
            {

                /*" -2967- MOVE 'S' TO PRODUVG-TEM-CDG */
                _.Move("S", PRODUVG.DCLPRODUTOS_VG.PRODUVG_TEM_CDG);

                /*" -2968- MOVE ZEROS TO VIND-TEM-CDG */
                _.Move(0, VIND_TEM_CDG);

                /*" -2969- ELSE */
            }
            else
            {


                /*" -2970- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -2971- MOVE 'N' TO PRODUVG-TEM-CDG */
                    _.Move("N", PRODUVG.DCLPRODUTOS_VG.PRODUVG_TEM_CDG);

                    /*" -2972- MOVE ZEROS TO VIND-TEM-CDG */
                    _.Move(0, VIND_TEM_CDG);

                    /*" -2973- ELSE */
                }
                else
                {


                    /*" -2975- DISPLAY 'PROBLEMAS NA LEITURA DA VG_COBER_TERMO' VGCOMTRO-NUM-PROPOSTA-SIVPF */
                    _.Display($"PROBLEMAS NA LEITURA DA VG_COBER_TERMO{VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF}");

                    /*" -2976- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2977- END-IF */
                }


                /*" -2979- END-IF. */
            }


            /*" -2981- MOVE 'SELECT VG_COBER_TERMO G6' TO COMANDO. */
            _.Move("SELECT VG_COBER_TERMO G6", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2989- PERFORM M_3100_INSERT_PRODUTOSVG_DB_SELECT_3 */

            M_3100_INSERT_PRODUTOSVG_DB_SELECT_3();

            /*" -2992- IF (SQLCODE EQUAL ZEROES) */

            if ((DB.SQLCODE == 00))
            {

                /*" -2993- MOVE 'S' TO PRODUVG-TEM-SAF */
                _.Move("S", PRODUVG.DCLPRODUTOS_VG.PRODUVG_TEM_SAF);

                /*" -2994- MOVE ZEROS TO VIND-TEM-SAF */
                _.Move(0, VIND_TEM_SAF);

                /*" -2995- MOVE 'MULTI' TO PRODUVG-ROT-SAF */
                _.Move("MULTI", PRODUVG.DCLPRODUTOS_VG.PRODUVG_ROT_SAF);

                /*" -2996- MOVE 'SS' TO PRODUVG-COD-PRODUTO-EA */
                _.Move("SS", PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_EA);

                /*" -2997- ELSE */
            }
            else
            {


                /*" -2998- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -3001- MOVE SPACES TO PRODUVG-TEM-SAF PRODUVG-ROT-SAF PRODUVG-COD-PRODUTO-EA */
                    _.Move("", PRODUVG.DCLPRODUTOS_VG.PRODUVG_TEM_SAF, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ROT_SAF, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_EA);

                    /*" -3004- MOVE -1 TO VIND-TEM-SAF VIND-ROT-SAF VIND-COD-PROD-EA */
                    _.Move(-1, VIND_TEM_SAF, VIND_ROT_SAF, VIND_COD_PROD_EA);

                    /*" -3005- ELSE */
                }
                else
                {


                    /*" -3007- DISPLAY 'PROBLEMAS NA LEITURA DA VG_COBER_TERMO' VGCOMTRO-NUM-PROPOSTA-SIVPF */
                    _.Display($"PROBLEMAS NA LEITURA DA VG_COBER_TERMO{VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF}");

                    /*" -3008- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3009- END-IF */
                }


                /*" -3011- END-IF. */
            }


            /*" -3013- MOVE 'INSERT PRODUTOSVG     ' TO COMANDO. */
            _.Move("INSERT PRODUTOSVG     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3126- PERFORM M_3100_INSERT_PRODUTOSVG_DB_INSERT_1 */

            M_3100_INSERT_PRODUTOSVG_DB_INSERT_1();

            /*" -3129- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -3132- DISPLAY '3100 - PROBLEMA INSERT DA PRODUTOSVG ..' PRODUVG-NUM-APOLICE ' ' PRODUVG-COD-SUBGRUPO ' ' SQLCODE */

                $"3100 - PROBLEMA INSERT DA PRODUTOSVG ..{PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE} {PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO} {DB.SQLCODE}"
                .Display();

                /*" -3133- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3135- END-IF. */
            }


            /*" -3135- ADD 1 TO AC-I-PRODUVG. */
            WS_WORK_AREAS.AC_I_PRODUVG.Value = WS_WORK_AREAS.AC_I_PRODUVG + 1;

        }

        [StopWatch]
        /*" M-3100-INSERT-PRODUTOSVG-DB-SELECT-1 */
        public void M_3100_INSERT_PRODUTOSVG_DB_SELECT_1()
        {
            /*" -2912- EXEC SQL SELECT DESCR_PRODUTO INTO :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :PRODUVG-COD-PRODUTO WITH UR END-EXEC. */

            var m_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1 = new M_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1()
            {
                PRODUVG_COD_PRODUTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.ToString(),
            };

            var executed_1 = M_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1.Execute(m_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3100_FIM*/

        [StopWatch]
        /*" M-3100-INSERT-PRODUTOSVG-DB-SELECT-2 */
        public void M_3100_INSERT_PRODUTOSVG_DB_SELECT_2()
        {
            /*" -2963- EXEC SQL SELECT COD_GARANTIA INTO :VGCOBTER-COD-GARANTIA FROM SEGUROS.VG_COBER_TERMO WHERE NUM_PROPOSTA_SIVPF = :VGCOMTRO-NUM-PROPOSTA-SIVPF AND COD_GARANTIA = 15 AND DTH_FIM_VIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var m_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1 = new M_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1()
            {
                VGCOMTRO_NUM_PROPOSTA_SIVPF = VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = M_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1.Execute(m_3100_INSERT_PRODUTOSVG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGCOBTER_COD_GARANTIA, VGCOBTER.DCLVG_COBER_TERMO.VGCOBTER_COD_GARANTIA);
            }


        }

        [StopWatch]
        /*" M-3100-INSERT-PRODUTOSVG-DB-INSERT-1 */
        public void M_3100_INSERT_PRODUTOSVG_DB_INSERT_1()
        {
            /*" -3126- EXEC SQL INSERT INTO SEGUROS.PRODUTOS_VG ( NUM_APOLICE , COD_SUBGRUPO , ID_SISTEMA , COD_PRODUTO_AZUL , COD_PRODUTO , NOME_PRODUTO , PERI_PAGAMENTO , DIAS_INICIO_VIGENC , DATA_MINVIGENCIA , DATA_MAXVIGENCIA , SIT_PLANO_CEF , OPCAO_PAGAMENTO , COD_CEDENTE , OPC_AGENCTO_SUREG , OPCAO_CAPITALIZ , COD_SERIE , NUM_SEQ_TITULO , NUM_MALA_DIRETA , RAMO , CANCELA_ANTIGO , IND_RCAP , NRMSCAP , NRMFDCAP , DTMVFDCAP , NRNSAF , NLMSAF , TEM_CDG , PRI_CDG , TEM_SAF , PRI_SAF , CODEMPRSA , NRMATRSA , DTAVERB , COD_RUBRICA , COD_CCT , TRANSF_SUBGRUPO , DIA_FATURA , ARQ_FDCAP , ESTR_COBR , ESTR_EMISS , ORIG_PRODU , COD_AGENCIADOR , MOV_INTERFACE , CONSISTE_MATRIC , RISCO , COD_SEGURADORA , COD_SEGU_SAF , CODRELAT , TEM_FAIXAETA , TEM_IGPM , ROT_SAF , COD_PRODUTO_EA , COBERADIC_PREMIO , CUSTOCAP_TOTAL , DESCONTO_ADESAO) VALUES (:PRODUVG-NUM-APOLICE , :PRODUVG-COD-SUBGRUPO , :PRODUVG-ID-SISTEMA , :PRODUVG-COD-PRODUTO-AZUL , :PRODUVG-COD-PRODUTO , :PRODUVG-NOME-PRODUTO , :PRODUVG-PERI-PAGAMENTO , :PRODUVG-DIAS-INICIO-VIGENC , :PRODUVG-DATA-MINVIGENCIA , :PRODUVG-DATA-MAXVIGENCIA , :PRODUVG-SIT-PLANO-CEF , :PRODUVG-OPCAO-PAGAMENTO , :PRODUVG-COD-CEDENTE , :PRODUVG-OPC-AGENCTO-SUREG , :PRODUVG-OPCAO-CAPITALIZ , :PRODUVG-COD-SERIE , :PRODUVG-NUM-SEQ-TITULO , :PRODUVG-NUM-MALA-DIRETA , :PRODUVG-RAMO , :PRODUVG-CANCELA-ANTIGO , NULL , NULL , NULL , NULL , NULL , NULL , :PRODUVG-TEM-CDG:VIND-TEM-CDG , NULL , :PRODUVG-TEM-SAF:VIND-TEM-SAF , NULL , NULL , NULL , NULL , NULL , NULL , NULL , :PRODUVG-DIA-FATURA , NULL , :PRODUVG-ESTR-COBR , :PRODUVG-ESTR-EMISS , :PRODUVG-ORIG-PRODU , NULL , NULL , NULL , NULL , NULL , NULL , :PRODUVG-CODRELAT , NULL , NULL , :PRODUVG-ROT-SAF:VIND-ROT-SAF , :PRODUVG-COD-PRODUTO-EA :VIND-COD-PROD-EA, :PRODUVG-COBERADIC-PREMIO , :PRODUVG-CUSTOCAP-TOTAL , :PRODUVG-DESCONTO-ADESAO ) END-EXEC. */

            var m_3100_INSERT_PRODUTOSVG_DB_INSERT_1_Insert1 = new M_3100_INSERT_PRODUTOSVG_DB_INSERT_1_Insert1()
            {
                PRODUVG_NUM_APOLICE = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE.ToString(),
                PRODUVG_COD_SUBGRUPO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO.ToString(),
                PRODUVG_ID_SISTEMA = PRODUVG.DCLPRODUTOS_VG.PRODUVG_ID_SISTEMA.ToString(),
                PRODUVG_COD_PRODUTO_AZUL = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_AZUL.ToString(),
                PRODUVG_COD_PRODUTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.ToString(),
                PRODUVG_NOME_PRODUTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO.ToString(),
                PRODUVG_PERI_PAGAMENTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.ToString(),
                PRODUVG_DIAS_INICIO_VIGENC = PRODUVG.DCLPRODUTOS_VG.PRODUVG_DIAS_INICIO_VIGENC.ToString(),
                PRODUVG_DATA_MINVIGENCIA = PRODUVG.DCLPRODUTOS_VG.PRODUVG_DATA_MINVIGENCIA.ToString(),
                PRODUVG_DATA_MAXVIGENCIA = PRODUVG.DCLPRODUTOS_VG.PRODUVG_DATA_MAXVIGENCIA.ToString(),
                PRODUVG_SIT_PLANO_CEF = PRODUVG.DCLPRODUTOS_VG.PRODUVG_SIT_PLANO_CEF.ToString(),
                PRODUVG_OPCAO_PAGAMENTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO.ToString(),
                PRODUVG_COD_CEDENTE = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_CEDENTE.ToString(),
                PRODUVG_OPC_AGENCTO_SUREG = PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPC_AGENCTO_SUREG.ToString(),
                PRODUVG_OPCAO_CAPITALIZ = PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_CAPITALIZ.ToString(),
                PRODUVG_COD_SERIE = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SERIE.ToString(),
                PRODUVG_NUM_SEQ_TITULO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_SEQ_TITULO.ToString(),
                PRODUVG_NUM_MALA_DIRETA = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_MALA_DIRETA.ToString(),
                PRODUVG_RAMO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_RAMO.ToString(),
                PRODUVG_CANCELA_ANTIGO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_CANCELA_ANTIGO.ToString(),
                PRODUVG_TEM_CDG = PRODUVG.DCLPRODUTOS_VG.PRODUVG_TEM_CDG.ToString(),
                VIND_TEM_CDG = VIND_TEM_CDG.ToString(),
                PRODUVG_TEM_SAF = PRODUVG.DCLPRODUTOS_VG.PRODUVG_TEM_SAF.ToString(),
                VIND_TEM_SAF = VIND_TEM_SAF.ToString(),
                PRODUVG_DIA_FATURA = PRODUVG.DCLPRODUTOS_VG.PRODUVG_DIA_FATURA.ToString(),
                PRODUVG_ESTR_COBR = PRODUVG.DCLPRODUTOS_VG.PRODUVG_ESTR_COBR.ToString(),
                PRODUVG_ESTR_EMISS = PRODUVG.DCLPRODUTOS_VG.PRODUVG_ESTR_EMISS.ToString(),
                PRODUVG_ORIG_PRODU = PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.ToString(),
                PRODUVG_CODRELAT = PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT.ToString(),
                PRODUVG_ROT_SAF = PRODUVG.DCLPRODUTOS_VG.PRODUVG_ROT_SAF.ToString(),
                VIND_ROT_SAF = VIND_ROT_SAF.ToString(),
                PRODUVG_COD_PRODUTO_EA = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_EA.ToString(),
                VIND_COD_PROD_EA = VIND_COD_PROD_EA.ToString(),
                PRODUVG_COBERADIC_PREMIO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COBERADIC_PREMIO.ToString(),
                PRODUVG_CUSTOCAP_TOTAL = PRODUVG.DCLPRODUTOS_VG.PRODUVG_CUSTOCAP_TOTAL.ToString(),
                PRODUVG_DESCONTO_ADESAO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_DESCONTO_ADESAO.ToString(),
            };

            M_3100_INSERT_PRODUTOSVG_DB_INSERT_1_Insert1.Execute(m_3100_INSERT_PRODUTOSVG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-4000-00-GRAVA-TAB-ERRO-SECTION */
        private void M_4000_00_GRAVA_TAB_ERRO_SECTION()
        {
            /*" -3145- MOVE 'R1100-00-GRAVA-TAB-ERRO' TO PARAGRAFO. */
            _.Move("R1100-00-GRAVA-TAB-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3147- MOVE 'GRAVA TABELA INTERNA DE ERRO' TO COMANDO. */
            _.Move("GRAVA TABELA INTERNA DE ERRO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3149- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -3150- MOVE WS-COD-ERRO TO TB-ERRO-CERT(WS-I-ERRO) */
            _.Move(WS_COD_ERRO, WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT);

            /*" -3150- . */

        }

        [StopWatch]
        /*" M-3100-INSERT-PRODUTOSVG-DB-SELECT-3 */
        public void M_3100_INSERT_PRODUTOSVG_DB_SELECT_3()
        {
            /*" -2989- EXEC SQL SELECT COD_GARANTIA INTO :VGCOBTER-COD-GARANTIA FROM SEGUROS.VG_COBER_TERMO WHERE NUM_PROPOSTA_SIVPF = :VGCOMTRO-NUM-PROPOSTA-SIVPF AND COD_GARANTIA = 6 AND DTH_FIM_VIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var m_3100_INSERT_PRODUTOSVG_DB_SELECT_3_Query1 = new M_3100_INSERT_PRODUTOSVG_DB_SELECT_3_Query1()
            {
                VGCOMTRO_NUM_PROPOSTA_SIVPF = VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = M_3100_INSERT_PRODUTOSVG_DB_SELECT_3_Query1.Execute(m_3100_INSERT_PRODUTOSVG_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGCOBTER_COD_GARANTIA, VGCOBTER.DCLVG_COBER_TERMO.VGCOBTER_COD_GARANTIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" M-4050-00-INSERT-VGCRITICA-SECTION */
        private void M_4050_00_INSERT_VGCRITICA_SECTION()
        {
            /*" -3163- MOVE '4050' TO PARAGRAFO. */
            _.Move("4050", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3165- MOVE '4050-00-INSERT-VGCRITICA' TO COMANDO. */
            _.Move("4050-00-INSERT-VGCRITICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3167- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -3168- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -3169- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -3170- MOVE NUMEROUT-NUM-CERT-VGAP TO LK-VG001-NUM-CERTIFICADO */
            _.Move(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -3171- MOVE TB-ERRO-CERT(WS-I-ERRO) TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -3172- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -3173- MOVE 'PJ' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PJ", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -3174- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -3175- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -3176- MOVE 'VG0001B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VG0001B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -3177- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -3178- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -3179- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -3182- MOVE 'ERRO DE PROPOSTA INSERIDO NA EMISSAO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("ERRO DE PROPOSTA INSERIDO NA EMISSAO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -3184- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -3185- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -3186- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -3190- DISPLAY 'ERRO JAH GRAVADO 4050 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 4050 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -3191- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -3192- ELSE */
                }
                else
                {


                    /*" -3193- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -3194- DISPLAY '* 4050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 4050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -3195- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -3196- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -3197- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -3198- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -3199- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -3200- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -3201- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -3203- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -3204- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -3205- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3206- END-IF */
                }


                /*" -3207- END-IF */
            }


            /*" -3209- . */

            /*" -3211- ADD 1 TO WS-I-ERRO */
            WS_I_ERRO.Value = WS_I_ERRO + 1;

            /*" -3212- IF TB-ERRO-CERT(WS-I-ERRO) EQUAL ZEROS */

            if (WORK_TAB_ERROS_CERT.WS_TAB_ERROS_CERT[WS_I_ERRO].TB_ERRO_CERT == 00)
            {

                /*" -3213- MOVE 'N' TO WS-FLAG-TEM-ERRO */
                _.Move("N", WS_FLAG_TEM_ERRO);

                /*" -3214- END-IF */
            }


            /*" -3214- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4050_99_SAIDA*/

        [StopWatch]
        /*" M-4100-00-CONSULTA-VGCRITICA-SECTION */
        private void M_4100_00_CONSULTA_VGCRITICA_SECTION()
        {
            /*" -3226- MOVE '4100' TO PARAGRAFO. */
            _.Move("4100", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3228- MOVE '4100-00-CONSULTA-VGCRITICA' TO COMANDO. */
            _.Move("4100-00-CONSULTA-VGCRITICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3230- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -3231- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -3232- MOVE 07 TO LK-VG001-TIPO-ACAO */
            _.Move(07, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -3233- MOVE NUMEROUT-NUM-CERT-VGAP TO LK-VG001-NUM-CERTIFICADO */
            _.Move(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -3234- MOVE WS-COD-ERRO TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WS_COD_ERRO, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -3235- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -3236- MOVE 'PJ' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PJ", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -3237- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -3238- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -3239- MOVE 'VG0001B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VG0001B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -3240- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -3242- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -3244- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -3245- IF LK-VG001-IND-ERRO = 0 */

            if (SPVG001W.LK_VG001_IND_ERRO == 0)
            {

                /*" -3246- IF LK-VG001-S-NUM-CERTIFICADO > 0 */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 0)
                {

                    /*" -3247- PERFORM 4150-00-DELETE-VGCRITICA */

                    M_4150_00_DELETE_VGCRITICA_SECTION();

                    /*" -3248- END-IF */
                }


                /*" -3249- ELSE */
            }
            else
            {


                /*" -3250- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -3251- DISPLAY '* 4100  -  PROBLEMAS CALL SUBROTINA SPBVG001  *' */
                _.Display($"* 4100  -  PROBLEMAS CALL SUBROTINA SPBVG001  *");

                /*" -3252- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -3253- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -3254- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -3255- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -3256- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -3257- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -3258- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -3260- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -3261- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3262- END-IF */
            }


            /*" -3262- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4100_99_SAIDA*/

        [StopWatch]
        /*" M-4150-00-DELETE-VGCRITICA-SECTION */
        private void M_4150_00_DELETE_VGCRITICA_SECTION()
        {
            /*" -3273- MOVE '4150' TO PARAGRAFO. */
            _.Move("4150", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3275- MOVE '4150-00-DELETE-VGCRITICA' TO COMANDO. */
            _.Move("4150-00-DELETE-VGCRITICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3276- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -3278- MOVE 03 TO LK-VG001-TIPO-ACAO */
            _.Move(03, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -3279- MOVE LK-VG001-S-SEQ-CRITICA TO LK-VG001-SEQ-CRITICA */
            _.Move(SPVG001W.LK_VG001_S_SEQ_CRITICA, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -3280- MOVE 'PJ' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PJ", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -3281- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -3282- MOVE 'VG0001B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VG0001B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -3283- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -3284- MOVE 'B' TO LK-VG001-STA-CRITICA */
            _.Move("B", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -3285- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -3288- MOVE 'EXCLUSAO LOGICA DE ERRO DA PROPOSTA ' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("EXCLUSAO LOGICA DE ERRO DA PROPOSTA ", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -3290- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -3291- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -3292- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -3293- DISPLAY '* 4150  -  PROBLEMAS CALL SUBROTINA SPBVG001  *' */
                _.Display($"* 4150  -  PROBLEMAS CALL SUBROTINA SPBVG001  *");

                /*" -3294- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -3295- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -3296- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -3297- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -3298- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -3299- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -3300- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -3302- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -3303- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3304- END-IF */
            }


            /*" -3304- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4150_99_SAIDA*/

        [StopWatch]
        /*" M-5000-DECLARA-PROPOVA-CRTCA-SECTION */
        private void M_5000_DECLARA_PROPOVA_CRTCA_SECTION()
        {
            /*" -3358- MOVE '5000' TO PARAGRAFO. */
            _.Move("5000", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3360- MOVE 'DECLARE CPROPOVACRT  ' TO COMANDO. */
            _.Move("DECLARE CPROPOVACRT  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3362- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -3364- DISPLAY 'INICIO DECLARE PROPOVA CRITICA.. ' WS-TIME. */
            _.Display($"INICIO DECLARE PROPOVA CRITICA.. {WS_WORK_AREAS.WS_TIME}");

            /*" -3386- PERFORM M_5000_DECLARA_PROPOVA_CRTCA_DB_DECLARE_1 */

            M_5000_DECLARA_PROPOVA_CRTCA_DB_DECLARE_1();

            /*" -3389- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3390- DISPLAY '5000 - PROBLEMAS DECLARE CPROPOVACRT' */
                _.Display($"5000 - PROBLEMAS DECLARE CPROPOVACRT");

                /*" -3391- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -3392- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3394- END-IF. */
            }


            /*" -3394- PERFORM M_5000_DECLARA_PROPOVA_CRTCA_DB_OPEN_1 */

            M_5000_DECLARA_PROPOVA_CRTCA_DB_OPEN_1();

            /*" -3398- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -3399- DISPLAY 'FINAL DECLARE PROPOVA CRITICA.. ' WS-TIME. */
            _.Display($"FINAL DECLARE PROPOVA CRITICA.. {WS_WORK_AREAS.WS_TIME}");

        }

        [StopWatch]
        /*" M-5000-DECLARA-PROPOVA-CRTCA-DB-OPEN-1 */
        public void M_5000_DECLARA_PROPOVA_CRTCA_DB_OPEN_1()
        {
            /*" -3394- EXEC SQL OPEN CPROPOVACRT END-EXEC. */

            CPROPOVACRT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

        [StopWatch]
        /*" M-5100-FETCH-PROPOVA-CRTCA-SECTION */
        private void M_5100_FETCH_PROPOVA_CRTCA_SECTION()
        {
            /*" -3407- MOVE '5100' TO PARAGRAFO. */
            _.Move("5100", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3409- MOVE 'FETCH CPROPOVACRT  ' TO COMANDO. */
            _.Move("FETCH CPROPOVACRT  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3419- PERFORM M_5100_FETCH_PROPOVA_CRTCA_DB_FETCH_1 */

            M_5100_FETCH_PROPOVA_CRTCA_DB_FETCH_1();

            /*" -3422- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3423- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -3424- MOVE 'S' TO WFIM-PROPOVA-CRTCA */
                    _.Move("S", WS_WORK_AREAS.WFIM_PROPOVA_CRTCA);

                    /*" -3424- PERFORM M_5100_FETCH_PROPOVA_CRTCA_DB_CLOSE_1 */

                    M_5100_FETCH_PROPOVA_CRTCA_DB_CLOSE_1();

                    /*" -3426- GO TO 5100-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5100_FIM*/ //GOTO
                    return;

                    /*" -3427- ELSE */
                }
                else
                {


                    /*" -3427- PERFORM M_5100_FETCH_PROPOVA_CRTCA_DB_CLOSE_2 */

                    M_5100_FETCH_PROPOVA_CRTCA_DB_CLOSE_2();

                    /*" -3429- DISPLAY '5100 - PROBLEMAS NO CLOSE CPROPOVACRT' */
                    _.Display($"5100 - PROBLEMAS NO CLOSE CPROPOVACRT");

                    /*" -3430- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -3431- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3432- END-IF */
                }


                /*" -3433- ELSE */
            }
            else
            {


                /*" -3434- ADD 1 TO AC-L-PROP-CRT */
                WS_WORK_AREAS.AC_L_PROP_CRT.Value = WS_WORK_AREAS.AC_L_PROP_CRT + 1;

                /*" -3435- END-IF. */
            }


        }

        [StopWatch]
        /*" M-5100-FETCH-PROPOVA-CRTCA-DB-FETCH-1 */
        public void M_5100_FETCH_PROPOVA_CRTCA_DB_FETCH_1()
        {
            /*" -3419- EXEC SQL FETCH CPROPOVACRT INTO :VGSOLFAT-NUM-APOLICE , :VGSOLFAT-COD-SUBGRUPO , :VGSOLFAT-NUM-TITULO , :PROPOVA-NUM-CERTIFICADO , :CONVERSI-NUM-PROPOSTA-SIVPF , :VGSOLFAT-PRM-VG , :VGSOLFAT-PRM-AP , :VGSOLFAT-PRM-TOTAL END-EXEC. */

            if (CPROPOVACRT.Fetch())
            {
                _.Move(CPROPOVACRT.VGSOLFAT_NUM_APOLICE, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE);
                _.Move(CPROPOVACRT.VGSOLFAT_COD_SUBGRUPO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO);
                _.Move(CPROPOVACRT.VGSOLFAT_NUM_TITULO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO);
                _.Move(CPROPOVACRT.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CPROPOVACRT.CONVERSI_NUM_PROPOSTA_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);
                _.Move(CPROPOVACRT.VGSOLFAT_PRM_VG, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG);
                _.Move(CPROPOVACRT.VGSOLFAT_PRM_AP, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_AP);
                _.Move(CPROPOVACRT.VGSOLFAT_PRM_TOTAL, VGSOLFAT_PRM_TOTAL);
            }

        }

        [StopWatch]
        /*" M-5100-FETCH-PROPOVA-CRTCA-DB-CLOSE-1 */
        public void M_5100_FETCH_PROPOVA_CRTCA_DB_CLOSE_1()
        {
            /*" -3424- EXEC SQL CLOSE CPROPOVACRT END-EXEC */

            CPROPOVACRT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5100_FIM*/

        [StopWatch]
        /*" M-5100-FETCH-PROPOVA-CRTCA-DB-CLOSE-2 */
        public void M_5100_FETCH_PROPOVA_CRTCA_DB_CLOSE_2()
        {
            /*" -3427- EXEC SQL CLOSE CPROPOVACRT END-EXEC */

            CPROPOVACRT.Close();

        }

        [StopWatch]
        /*" M-5500-PROCESSA-PROPOVA-CRTCA-SECTION */
        private void M_5500_PROCESSA_PROPOVA_CRTCA_SECTION()
        {
            /*" -3444- MOVE '5500' TO PARAGRAFO. */
            _.Move("5500", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3445- MOVE 'S' TO WS-TEM-RCAP. */
            _.Move("S", WS_TEM_RCAP);

            /*" -3446- MOVE CONVERSI-NUM-PROPOSTA-SIVPF TO RCAPS-NUM-CERTIFICADO. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -3447- MOVE ZEROS TO RCAPS-NUM-RCAP. */
            _.Move(0, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);

            /*" -3449- MOVE PROPOVA-NUM-CERTIFICADO TO NUMEROUT-NUM-CERT-VGAP */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP);

            /*" -3451- PERFORM 1250-SELECT-RCAP-NRCERTIF */

            M_1250_SELECT_RCAP_NRCERTIF_SECTION();

            /*" -3453- IF (WS-TEM-RCAP EQUAL 'S' ) */

            if ((WS_TEM_RCAP == "S"))
            {

                /*" -3454- MOVE 1501 TO WS-COD-ERRO */
                _.Move(1501, WS_COD_ERRO);

                /*" -3455- PERFORM 4100-00-CONSULTA-VGCRITICA */

                M_4100_00_CONSULTA_VGCRITICA_SECTION();

                /*" -3456- PERFORM 5520-UPDATE-SIT-PARCELA */

                M_5520_UPDATE_SIT_PARCELA_SECTION();

                /*" -3457- PERFORM 5530-UPDATE-HISTCONTABILVA */

                M_5530_UPDATE_HISTCONTABILVA_SECTION();

                /*" -3458- PERFORM 5900-AJUSTA-INIVIGENCIA */

                M_5900_AJUSTA_INIVIGENCIA_SECTION();

                /*" -3459- MOVE '3' TO PROPOVA-SIT-REGISTRO */
                _.Move("3", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                /*" -3460- PERFORM 6000-UPDATE-SIT-PROPOSTA */

                M_6000_UPDATE_SIT_PROPOSTA_SECTION();

                /*" -3461- ADD 1 TO WS-CONT-INTEGRADO */
                WS_WORK_AREAS.WS_CONT_INTEGRADO.Value = WS_WORK_AREAS.WS_CONT_INTEGRADO + 1;

                /*" -3462- ELSE */
            }
            else
            {


                /*" -3463- MOVE 1501 TO WS-COD-ERRO */
                _.Move(1501, WS_COD_ERRO);

                /*" -3465- PERFORM 4000-00-GRAVA-TAB-ERRO */

                M_4000_00_GRAVA_TAB_ERRO_SECTION();

                /*" -3466- ADD 1 TO WS-CONT-TEMERRO */
                WS_WORK_AREAS.WS_CONT_TEMERRO.Value = WS_WORK_AREAS.WS_CONT_TEMERRO + 1;

                /*" -3467- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM M_5500_FETCH_PROPOVA */

            M_5500_FETCH_PROPOVA();

        }

        [StopWatch]
        /*" M-5500-FETCH-PROPOVA */
        private void M_5500_FETCH_PROPOVA(bool isPerform = false)
        {
            /*" -3471- PERFORM 5100-FETCH-PROPOVA-CRTCA. */

            M_5100_FETCH_PROPOVA_CRTCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5500_FIM*/

        [StopWatch]
        /*" M-5520-UPDATE-SIT-PARCELA-SECTION */
        private void M_5520_UPDATE_SIT_PARCELA_SECTION()
        {
            /*" -3479- MOVE '5520' TO PARAGRAFO. */
            _.Move("5520", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3481- MOVE 'UPDATE PARCELAS_VIDAZUL' TO COMANDO. */
            _.Move("UPDATE PARCELAS_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3487- PERFORM M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1 */

            M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1();

            /*" -3490- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3492- DISPLAY 'PROBLEMAS NO UPDATE PARCELAS_VIDAZUL' NUMEROUT-NUM-CERT-VGAP */
                _.Display($"PROBLEMAS NO UPDATE PARCELAS_VIDAZUL{NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP}");

                /*" -3493- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3495- END-IF. */
            }


            /*" -3496- MOVE 'UPDATE COBER_HIST_VIDAZUL' TO COMANDO. */
            _.Move("UPDATE COBER_HIST_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3504- PERFORM M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2 */

            M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2();

            /*" -3507- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3509- DISPLAY 'PROBLEMAS NO UPDATE A COBER_HIST_VIDAZUL' NUMEROUT-NUM-CERT-VGAP */
                _.Display($"PROBLEMAS NO UPDATE A COBER_HIST_VIDAZUL{NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP}");

                /*" -3510- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3511- END-IF. */
            }


        }

        [StopWatch]
        /*" M-5520-UPDATE-SIT-PARCELA-DB-UPDATE-1 */
        public void M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1()
        {
            /*" -3487- EXEC SQL UPDATE SEGUROS.PARCELAS_VIDAZUL SET SIT_REGISTRO = '1' , TIMESTAMP = CURRENT_TIMESTAMP WHERE NUM_CERTIFICADO = :NUMEROUT-NUM-CERT-VGAP AND NUM_PARCELA = 1 END-EXEC. */

            var m_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1 = new M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1()
            {
                NUMEROUT_NUM_CERT_VGAP = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP.ToString(),
            };

            M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1.Execute(m_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5520_SAIDA*/

        [StopWatch]
        /*" M-5520-UPDATE-SIT-PARCELA-DB-UPDATE-2 */
        public void M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2()
        {
            /*" -3504- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET SIT_REGISTRO = '1' , BCO_AVISO = :RCAPCOMP-BCO-AVISO , AGE_AVISO = :RCAPCOMP-AGE-AVISO , NUM_AVISO_CREDITO = :RCAPCOMP-NUM-AVISO-CREDITO WHERE NUM_CERTIFICADO = :NUMEROUT-NUM-CERT-VGAP AND NUM_PARCELA = 1 END-EXEC. */

            var m_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2_Update1 = new M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2_Update1()
            {
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
                NUMEROUT_NUM_CERT_VGAP = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP.ToString(),
            };

            M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2_Update1.Execute(m_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-5530-UPDATE-HISTCONTABILVA-SECTION */
        private void M_5530_UPDATE_HISTCONTABILVA_SECTION()
        {
            /*" -3519- MOVE '5530' TO PARAGRAFO */
            _.Move("5530", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3521- MOVE 'SELECT SUBGRUPOS_VGAP' TO COMANDO. */
            _.Move("SELECT SUBGRUPOS_VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3529- PERFORM M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1 */

            M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1();

            /*" -3532- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3534- DISPLAY 'PROBLEMAS NA LEITURA DO SUBGRUPO ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO */

                $"PROBLEMAS NA LEITURA DO SUBGRUPO {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}"
                .Display();

                /*" -3535- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3537- END-IF */
            }


            /*" -3539- MOVE ZEROES TO HISCONPA-PREMIO-AP */
            _.Move(0, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

            /*" -3542- COMPUTE WS-PCT-VG ROUNDED = VGSOLFAT-PRM-VG / VGSOLFAT-PRM-TOTAL */
            WS_WORK_AREAS.WS_PCT_VG.Value = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG / VGSOLFAT_PRM_TOTAL;

            /*" -3545- COMPUTE HISCONPA-PREMIO-VG ROUNDED = RCAPS-VAL-RCAP * WS-PCT-VG */
            HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG.Value = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP * WS_WORK_AREAS.WS_PCT_VG;

            /*" -3546- IF (SUBGVGAP-OPCAO-COBERTURA NOT EQUAL '2' ) */

            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_COBERTURA != "2"))
            {

                /*" -3548- COMPUTE HISCONPA-PREMIO-AP = RCAPS-VAL-RCAP - HISCONPA-PREMIO-VG */
                HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP.Value = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP - HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG;

                /*" -3550- END-IF */
            }


            /*" -3551- IF (RCAPS-VAL-RCAP EQUAL VGSOLFAT-PRM-TOTAL) */

            if ((RCAPS.DCLRCAPS.RCAPS_VAL_RCAP == VGSOLFAT_PRM_TOTAL))
            {

                /*" -3552- MOVE VGSOLFAT-PRM-VG TO HISCONPA-PREMIO-VG */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);

                /*" -3553- MOVE VGSOLFAT-PRM-AP TO HISCONPA-PREMIO-AP */
                _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

                /*" -3554- MOVE 201 TO HISCONPA-COD-OPERACAO */
                _.Move(201, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

                /*" -3555- ELSE */
            }
            else
            {


                /*" -3556- IF (RCAPS-VAL-RCAP > VGSOLFAT-PRM-TOTAL) */

                if ((RCAPS.DCLRCAPS.RCAPS_VAL_RCAP > VGSOLFAT_PRM_TOTAL))
                {

                    /*" -3557- MOVE 207 TO HISCONPA-COD-OPERACAO */
                    _.Move(207, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

                    /*" -3558- ELSE */
                }
                else
                {


                    /*" -3559- IF (RCAPS-VAL-RCAP < VGSOLFAT-PRM-TOTAL) */

                    if ((RCAPS.DCLRCAPS.RCAPS_VAL_RCAP < VGSOLFAT_PRM_TOTAL))
                    {

                        /*" -3560- MOVE 206 TO HISCONPA-COD-OPERACAO */
                        _.Move(206, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

                        /*" -3561- ELSE */
                    }
                    else
                    {


                        /*" -3562- MOVE VGSOLFAT-PRM-VG TO HISCONPA-PREMIO-VG */
                        _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);

                        /*" -3563- MOVE VGSOLFAT-PRM-AP TO HISCONPA-PREMIO-AP */
                        _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

                        /*" -3564- MOVE 201 TO HISCONPA-COD-OPERACAO */
                        _.Move(201, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

                        /*" -3565- END-IF */
                    }


                    /*" -3566- END-IF */
                }


                /*" -3568- END-IF */
            }


            /*" -3570- MOVE 'UPDATE HIST_CONT_PARCELVA' TO COMANDO */
            _.Move("UPDATE HIST_CONT_PARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3578- PERFORM M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1 */

            M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1();

            /*" -3581- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3583- DISPLAY 'PROBLEMAS NO UPDATE A HIST_CONT_PARCELVA ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"PROBLEMAS NO UPDATE A HIST_CONT_PARCELVA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -3584- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3586- END-IF */
            }


            /*" -3586- . */

        }

        [StopWatch]
        /*" M-5530-UPDATE-HISTCONTABILVA-DB-SELECT-1 */
        public void M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1()
        {
            /*" -3529- EXEC SQL SELECT OPCAO_COBERTURA INTO :SUBGVGAP-OPCAO-COBERTURA FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE AND COD_SUBGRUPO = :VGSOLFAT-COD-SUBGRUPO AND SIT_REGISTRO = '0' WITH UR END-EXEC */

            var m_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1 = new M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1()
            {
                VGSOLFAT_COD_SUBGRUPO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO.ToString(),
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1.Execute(m_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_OPCAO_COBERTURA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_COBERTURA);
            }


        }

        [StopWatch]
        /*" M-5530-UPDATE-HISTCONTABILVA-DB-UPDATE-1 */
        public void M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1()
        {
            /*" -3578- EXEC SQL UPDATE SEGUROS.HIST_CONT_PARCELVA SET SIT_REGISTRO = '0' , PREMIO_VG = :HISCONPA-PREMIO-VG , PREMIO_AP = :HISCONPA-PREMIO-AP , COD_OPERACAO = :HISCONPA-COD-OPERACAO WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = 1 END-EXEC */

            var m_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1 = new M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1()
            {
                HISCONPA_COD_OPERACAO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO.ToString(),
                HISCONPA_PREMIO_VG = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG.ToString(),
                HISCONPA_PREMIO_AP = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1.Execute(m_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5530_SAIDA*/

        [StopWatch]
        /*" M-5900-AJUSTA-INIVIGENCIA-SECTION */
        private void M_5900_AJUSTA_INIVIGENCIA_SECTION()
        {
            /*" -3599- MOVE '5900' TO PARAGRAFO. */
            _.Move("5900", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3600- MOVE RCAPS-DATA-MOVIMENTO TO WS-INIVIGENCIA */
            _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO, WS_INIVIGENCIA);

            /*" -3602- MOVE 01 TO WS-DIAVIGENCIA */
            _.Move(01, FILLER_25.WS_DIAVIGENCIA);

            /*" -3604- MOVE 'SET ' TO COMANDO. */
            _.Move("SET ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3608- PERFORM M_5900_AJUSTA_INIVIGENCIA_DB_SET_1 */

            M_5900_AJUSTA_INIVIGENCIA_DB_SET_1();

            /*" -3611- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3612- DISPLAY 'ERRO SQL SET WS-TERVIGENCIA' */
                _.Display($"ERRO SQL SET WS-TERVIGENCIA");

                /*" -3613- DISPLAY 'WS-INIVIGENCIA = ' WS-INIVIGENCIA */
                _.Display($"WS-INIVIGENCIA = {WS_INIVIGENCIA}");

                /*" -3615- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3616- MOVE VGSOLFAT-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -3618- MOVE VGSOLFAT-COD-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -3620- MOVE 'SELECT SUBGRUPOS_VGAP' TO COMANDO. */
            _.Move("SELECT SUBGRUPOS_VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3628- PERFORM M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1 */

            M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1();

            /*" -3631- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3632- DISPLAY 'ERRO SELECT SUBGRUPOS_VGAP' */
                _.Display($"ERRO SELECT SUBGRUPOS_VGAP");

                /*" -3633- DISPLAY 'APOLICE  = ' SUBGVGAP-NUM-APOLICE */
                _.Display($"APOLICE  = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                /*" -3634- DISPLAY 'SUBGRUPO = ' SUBGVGAP-COD-SUBGRUPO */
                _.Display($"SUBGRUPO = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                /*" -3636- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3637- IF SUBGVGAP-DATA-INIVIGENCIA NOT EQUAL WS-INIVIGENCIA */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA != WS_INIVIGENCIA)
            {

                /*" -3639- MOVE 'UPDATE SUBGRUPOS_VGAP' TO COMANDO */
                _.Move("UPDATE SUBGRUPOS_VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -3644- PERFORM M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1 */

                M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1();

                /*" -3647- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3648- DISPLAY 'ERRO UPDATE VIGENCIA DA SUBGRUPOS_VGAP' */
                    _.Display($"ERRO UPDATE VIGENCIA DA SUBGRUPOS_VGAP");

                    /*" -3649- DISPLAY 'APOLICE  = ' SUBGVGAP-NUM-APOLICE */
                    _.Display($"APOLICE  = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                    /*" -3650- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3653- END-IF */
                }


                /*" -3654- MOVE 'UPDATE ENDOSSOS' TO COMANDO */
                _.Move("UPDATE ENDOSSOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -3660- PERFORM M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2 */

                M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2();

                /*" -3663- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3664- DISPLAY 'ERRO UPDATE VIGENCIA DA ENDOSSOS' */
                    _.Display($"ERRO UPDATE VIGENCIA DA ENDOSSOS");

                    /*" -3665- DISPLAY 'APOLICE  = ' SUBGVGAP-NUM-APOLICE */
                    _.Display($"APOLICE  = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                    /*" -3666- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3667- END-IF */
                }


                /*" -3669- END-IF. */
            }


            /*" -3670- MOVE VGSOLFAT-NUM-APOLICE TO SEGVGAP-NUM-APOLICE */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_APOLICE);

            /*" -3675- MOVE ZEROS TO WS-CNT-SEGURADOS. */
            _.Move(0, WS_CNT_SEGURADOS);

            /*" -3677- MOVE 'SELECT SEGURADOS_VGAP' TO COMANDO. */
            _.Move("SELECT SEGURADOS_VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3683- PERFORM M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2 */

            M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2();

            /*" -3686- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3687- DISPLAY 'ERRO SELECT COUNT SEGURADOS_VGAP' */
                _.Display($"ERRO SELECT COUNT SEGURADOS_VGAP");

                /*" -3688- DISPLAY 'APOLICE  = ' SEGVGAP-NUM-APOLICE */
                _.Display($"APOLICE  = {SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_APOLICE}");

                /*" -3690- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3696- IF WS-CNT-SEGURADOS GREATER ZEROS */

            if (WS_CNT_SEGURADOS > 00)
            {

                /*" -3697- MOVE 'UPDATE SEGURADOS_VGAP' TO COMANDO */
                _.Move("UPDATE SEGURADOS_VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -3702- PERFORM M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_3 */

                M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_3();

                /*" -3705- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3706- DISPLAY 'ERRO UPDATE VIGENCIA DA SEGURADOS_VGAP' */
                    _.Display($"ERRO UPDATE VIGENCIA DA SEGURADOS_VGAP");

                    /*" -3707- DISPLAY 'APOLICE  = ' SEGVGAP-NUM-APOLICE */
                    _.Display($"APOLICE  = {SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_APOLICE}");

                    /*" -3708- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3709- END-IF */
                }


                /*" -3710- DISPLAY '* VIGENCIA CERTIFICADOS - ATUALIZADOS' */
                _.Display($"* VIGENCIA CERTIFICADOS - ATUALIZADOS");

                /*" -3711- ELSE */
            }
            else
            {


                /*" -3712- DISPLAY '* VIGENCIA CERTIFICADOS - OK' */
                _.Display($"* VIGENCIA CERTIFICADOS - OK");

                /*" -3712- END-IF. */
            }


        }

        [StopWatch]
        /*" M-5900-AJUSTA-INIVIGENCIA-DB-SET-1 */
        public void M_5900_AJUSTA_INIVIGENCIA_DB_SET_1()
        {
            /*" -3608- EXEC SQL SET :WS-TERVIGENCIA = DATE(:WS-INIVIGENCIA) + 1 YEAR - 1 DAY END-EXEC. */
            _.Move(WS_INIVIGENCIA, WS_TERVIGENCIA);
            _.Move(WS_TERVIGENCIA.ToDateTime().AddYears(+1).AddDays(-1), WS_INIVIGENCIA);

        }

        [StopWatch]
        /*" M-5900-AJUSTA-INIVIGENCIA-DB-SELECT-1 */
        public void M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1()
        {
            /*" -3628- EXEC SQL SELECT DATA_INIVIGENCIA , DATA_TERVIGENCIA INTO :SUBGVGAP-DATA-INIVIGENCIA ,:SUBGVGAP-DATA-TERVIGENCIA FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO END-EXEC. */

            var m_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1 = new M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1.Execute(m_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_DATA_INIVIGENCIA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA);
                _.Move(executed_1.SUBGVGAP_DATA_TERVIGENCIA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_TERVIGENCIA);
            }


        }

        [StopWatch]
        /*" M-5900-AJUSTA-INIVIGENCIA-DB-UPDATE-1 */
        public void M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1()
        {
            /*" -3644- EXEC SQL UPDATE SEGUROS.SUBGRUPOS_VGAP SET DATA_INIVIGENCIA = :WS-INIVIGENCIA , DATA_TERVIGENCIA = :WS-TERVIGENCIA WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE END-EXEC */

            var m_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1_Update1 = new M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1_Update1()
            {
                WS_INIVIGENCIA = WS_INIVIGENCIA.ToString(),
                WS_TERVIGENCIA = WS_TERVIGENCIA.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1_Update1.Execute(m_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5900_SAIDA*/

        [StopWatch]
        /*" M-5900-AJUSTA-INIVIGENCIA-DB-UPDATE-2 */
        public void M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2()
        {
            /*" -3660- EXEC SQL UPDATE SEGUROS.ENDOSSOS SET DATA_INIVIGENCIA = :WS-INIVIGENCIA , DATA_TERVIGENCIA = :WS-TERVIGENCIA WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC */

            var m_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1 = new M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1()
            {
                WS_INIVIGENCIA = WS_INIVIGENCIA.ToString(),
                WS_TERVIGENCIA = WS_TERVIGENCIA.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1.Execute(m_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-5900-AJUSTA-INIVIGENCIA-DB-SELECT-2 */
        public void M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2()
        {
            /*" -3683- EXEC SQL SELECT IFNULL(COUNT(*),0) INTO :WS-CNT-SEGURADOS FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_APOLICE = :SEGVGAP-NUM-APOLICE AND DATA_INIVIGENCIA <> :WS-INIVIGENCIA END-EXEC. */

            var m_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1 = new M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1()
            {
                SEGVGAP_NUM_APOLICE = SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_APOLICE.ToString(),
                WS_INIVIGENCIA = WS_INIVIGENCIA.ToString(),
            };

            var executed_1 = M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1.Execute(m_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CNT_SEGURADOS, WS_CNT_SEGURADOS);
            }


        }

        [StopWatch]
        /*" M-6000-UPDATE-SIT-PROPOSTA-SECTION */
        private void M_6000_UPDATE_SIT_PROPOSTA_SECTION()
        {
            /*" -3721- MOVE '6000' TO PARAGRAFO. */
            _.Move("6000", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3723- MOVE 'UPDATE PROPOSTAS_VA' TO COMANDO. */
            _.Move("UPDATE PROPOSTAS_VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3728- PERFORM M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1 */

            M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1();

            /*" -3731- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3733- DISPLAY 'PROBLEMAS NO UPDATE A PROPOSTAS_VA ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"PROBLEMAS NO UPDATE A PROPOSTAS_VA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -3734- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3735- END-IF. */
            }


        }

        [StopWatch]
        /*" M-6000-UPDATE-SIT-PROPOSTA-DB-UPDATE-1 */
        public void M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1()
        {
            /*" -3728- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = :PROPOVA-SIT-REGISTRO WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var m_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1 = new M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1()
            {
                PROPOVA_SIT_REGISTRO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1.Execute(m_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-5900-AJUSTA-INIVIGENCIA-DB-UPDATE-3 */
        public void M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_3()
        {
            /*" -3702- EXEC SQL UPDATE SEGUROS.SEGURADOS_VGAP SET DATA_INIVIGENCIA = :WS-INIVIGENCIA , DATA_ADMISSAO = :WS-TERVIGENCIA WHERE NUM_APOLICE = :SEGVGAP-NUM-APOLICE END-EXEC */

            var m_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_3_Update1 = new M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_3_Update1()
            {
                WS_INIVIGENCIA = WS_INIVIGENCIA.ToString(),
                WS_TERVIGENCIA = WS_TERVIGENCIA.ToString(),
                SEGVGAP_NUM_APOLICE = SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_APOLICE.ToString(),
            };

            M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_3_Update1.Execute(m_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_3_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_6000_SAIDA*/

        [StopWatch]
        /*" M-7000-00-PROCURA-RISCO-PROP-SECTION */
        private void M_7000_00_PROCURA_RISCO_PROP_SECTION()
        {
            /*" -3746- MOVE '7000' TO PARAGRAFO. */
            _.Move("7000", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3748- MOVE 'PROCURA RISCO PROPOSTA' TO COMANDO. */
            _.Move("PROCURA RISCO PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3750- MOVE ZEROS TO WS-NUM-PROPOSTA-SIVPF */
            _.Move(0, WS_NUM_PROPOSTA_SIVPF);

            /*" -3756- PERFORM M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1 */

            M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1();

            /*" -3759- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3762- DISPLAY '7000 - ERRO NA LEITURA CONVERSAO_SICOB ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO ' ' TERMOADE-NUM-TERMO ' ' PROPOFID-NUM-PROPOSTA-SIVPF */

                $"7000 - ERRO NA LEITURA CONVERSAO_SICOB {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO} {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}"
                .Display();

                /*" -3763- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3765- END-IF */
            }


            /*" -3766- MOVE 'N' TO LK-VG009-E-TRACE */
            _.Move("N", SPVG009W.LK_VG009_E_TRACE);

            /*" -3768- MOVE 'VG0001B' TO LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA */
            _.Move("VG0001B", SPVG009W.LK_VG009_E_COD_USUARIO, SPVG009W.LK_VG009_E_NOM_PROGRAMA);

            /*" -3769- MOVE 01 TO LK-VG009-E-TIPO-ACAO */
            _.Move(01, SPVG009W.LK_VG009_E_TIPO_ACAO);

            /*" -3771- MOVE WS-NUM-PROPOSTA-SIVPF TO LK-VG009-E-NUM-PROPOSTA */
            _.Move(WS_NUM_PROPOSTA_SIVPF, SPVG009W.LK_VG009_E_NUM_PROPOSTA);

            /*" -3772- MOVE 0 TO LK-VG009-IND-ERRO */
            _.Move(0, SPVG009W.LK_VG009_IND_ERRO);

            /*" -3774- MOVE SPACES TO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA */
            _.Move("", SPVG009W.LK_VG009_MSG_ERRO, SPVG009W.LK_VG009_NOM_TABELA);

            /*" -3775- MOVE 0 TO LK-VG009-SQLCODE */
            _.Move(0, SPVG009W.LK_VG009_SQLCODE);

            /*" -3777- MOVE SPACES TO LK-VG009-SQLERRMC */
            _.Move("", SPVG009W.LK_VG009_SQLERRMC);

            /*" -3779- MOVE 'SPBVG009' TO WS-PROGRAMA */
            _.Move("SPBVG009", WS_PROGRAMA);

            /*" -3800- CALL WS-PROGRAMA USING LK-VG009-E-TRACE LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA LK-VG009-E-TIPO-ACAO LK-VG009-E-NUM-PROPOSTA LK-VG009-S-COD-PESSOA LK-VG009-S-SEQ-PESSOA-HIST LK-VG009-S-COD-CLASSIF-RISCO LK-VG009-S-NUM-SCORE-RISCO LK-VG009-S-DTA-CLASSIF-RISCO LK-VG009-S-IND-PEND-APROVACAO LK-VG009-S-IND-DECL-AUTOMATICO LK-VG009-S-IND-ATLZ-FXA-RISCO LK-VG009-IND-ERRO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA LK-VG009-SQLCODE LK-VG009-SQLERRMC */
            _.Call(WS_PROGRAMA, SPVG009W);

            /*" -3801- IF LK-VG009-IND-ERRO NOT EQUAL ZEROS AND 001 */

            if (!SPVG009W.LK_VG009_IND_ERRO.In("00", "001"))
            {

                /*" -3802- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -3803- DISPLAY '* 7000 - PROBLEMAS CALL SUBROTINA SPBVG009    *' */
                _.Display($"* 7000 - PROBLEMAS CALL SUBROTINA SPBVG009    *");

                /*" -3804- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -3805- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -3806- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -3807- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -3808- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -3809- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -3810- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -3811- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -3813- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -3814- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -3815- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3817- END-IF */
            }


            /*" -3818-  EVALUATE TRUE  */

            /*" -3819-  WHEN LK-VG009-IND-ERRO = 00  */

            /*" -3819- IF LK-VG009-IND-ERRO = 00 */

            if (SPVG009W.LK_VG009_IND_ERRO == 00)
            {

                /*" -3822- PERFORM 7050-00-GRAVA-CLASSIF-RISCO */

                M_7050_00_GRAVA_CLASSIF_RISCO_SECTION();

                /*" -3823- IF LK-VG009-S-COD-CLASSIF-RISCO EQUAL 04 */

                if (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO == 04)
                {

                    /*" -3825- DISPLAY 'DESPREZADO RISCO CRITICO.: ' NUMEROUT-NUM-CERT-VGAP */
                    _.Display($"DESPREZADO RISCO CRITICO.: {NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP}");

                    /*" -3827- ADD 1 TO WS-QT-RISCO-CRITICO */
                    WS_QT_RISCO_CRITICO.Value = WS_QT_RISCO_CRITICO + 1;

                    /*" -3828- MOVE '1' TO PROPOVA-SIT-REGISTRO */
                    _.Move("1", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                    /*" -3830- MOVE NUMEROUT-NUM-CERT-VGAP TO PROPOVA-NUM-CERTIFICADO */
                    _.Move(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

                    /*" -3832- PERFORM 6000-UPDATE-SIT-PROPOSTA */

                    M_6000_UPDATE_SIT_PROPOSTA_SECTION();

                    /*" -3833- MOVE '3' TO VGSOLFAT-SIT-SOLICITA */
                    _.Move("3", VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_SIT_SOLICITA);

                    /*" -3834- GO TO 1000-UPDATE */

                    M_1000_UPDATE(); //GOTO
                    return;

                    /*" -3835- END-IF */
                }


                /*" -3836-  WHEN LK-VG009-IND-ERRO = 01  */

                /*" -3836- ELSE IF LK-VG009-IND-ERRO = 01 */
            }
            else

            if (SPVG009W.LK_VG009_IND_ERRO == 01)
            {

                /*" -3837- IF LK-VG009-SQLCODE = +100 */

                if (SPVG009W.LK_VG009_SQLCODE == +100)
                {

                    /*" -3838- PERFORM 7060-00-GRAVA-EMITE-SEM-RISCO */

                    M_7060_00_GRAVA_EMITE_SEM_RISCO_SECTION();

                    /*" -3839- ELSE */
                }
                else
                {


                    /*" -3840- MOVE 1 TO WS-ERRO-VG009 */
                    _.Move(1, WS_ERRO_VG009);

                    /*" -3841- END-IF */
                }


                /*" -3842-  WHEN OTHER  */

                /*" -3842- ELSE */
            }
            else
            {


                /*" -3843- MOVE 1 TO WS-ERRO-VG009 */
                _.Move(1, WS_ERRO_VG009);

                /*" -3845-  END-EVALUATE  */

                /*" -3845- END-IF */
            }


            /*" -3846- IF WS-ERRO-VG009 NOT EQUAL ZEROS */

            if (WS_ERRO_VG009 != 00)
            {

                /*" -3847- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -3848- DISPLAY '* 70001 - PROBLEMAS CALL SUBROTINA SPBVG009   *' */
                _.Display($"* 70001 - PROBLEMAS CALL SUBROTINA SPBVG009   *");

                /*" -3849- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -3850- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -3851- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -3852- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -3853- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -3854- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -3855- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -3856- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -3858- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -3859- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -3860- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -3861- END-IF */
            }


            /*" -3861- . */

        }

        [StopWatch]
        /*" M-7000-00-PROCURA-RISCO-PROP-DB-SELECT-1 */
        public void M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1()
        {
            /*" -3756- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :WS-NUM-PROPOSTA-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :VGSOLFAT-NUM-APOLICE WITH UR END-EXEC */

            var m_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1 = new M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1()
            {
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1.Execute(m_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_NUM_PROPOSTA_SIVPF, WS_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7000_99_EXIT*/

        [StopWatch]
        /*" M-7050-00-GRAVA-CLASSIF-RISCO-SECTION */
        private void M_7050_00_GRAVA_CLASSIF_RISCO_SECTION()
        {
            /*" -3874- MOVE '7050' TO PARAGRAFO. */
            _.Move("7050", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3876- MOVE 'GRAVA CLASSIFICACAO DE RISCO' TO COMANDO. */
            _.Move("GRAVA CLASSIFICACAO DE RISCO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3877- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -3878- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -3879- MOVE NUMEROUT-NUM-CERT-VGAP TO LK-VG001-NUM-CERTIFICADO */
            _.Move(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -3880- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -3881- MOVE 'PJ' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PJ", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -3882- MOVE CLIENTES-CGCCPF TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -3883- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -3884- MOVE 'VG0001B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VG0001B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -3885- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -3886- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -3887- MOVE 35 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(35, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -3889- MOVE 'CADASTRAMENTO DE AVALIACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("CADASTRAMENTO DE AVALIACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -3891- ADD 1 TO WS-QT-EMISSAO-C-RISCO */
            WS_QT_EMISSAO_C_RISCO.Value = WS_QT_EMISSAO_C_RISCO + 1;

            /*" -3893- EVALUATE LK-VG009-S-COD-CLASSIF-RISCO */
            switch (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO.Value)
            {

                /*" -3894- WHEN 01 */
                case 01:

                    /*" -3896- MOVE 2 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(2, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -3897- WHEN 02 */
                    break;
                case 02:

                    /*" -3899- MOVE 3 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(3, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -3900- WHEN 03 */
                    break;
                case 03:

                    /*" -3902- MOVE 4 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(4, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -3903- WHEN 04 */
                    break;
                case 04:

                    /*" -3905- MOVE 1 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(1, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -3906- WHEN OTHER */
                    break;
                default:

                    /*" -3909- DISPLAY 'VG0001B - ERRO NA CLASSIFICACAO DE RISCO > ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"VG0001B - ERRO NA CLASSIFICACAO DE RISCO > {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -3910- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -3911- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3913- END-EVALUATE */
                    break;
            }


            /*" -3915- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -3916- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -3917- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -3921- DISPLAY 'ERRO JAH GRAVADO 8650 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 8650 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -3922- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -3923- ELSE */
                }
                else
                {


                    /*" -3924- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -3925- DISPLAY '* 7050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 7050 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -3926- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -3927- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -3928- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -3929- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -3930- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -3931- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -3932- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -3934- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -3935- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -3936- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3937- END-IF */
                }


                /*" -3938- END-IF */
            }


            /*" -3938- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7050_99_SAIDA*/

        [StopWatch]
        /*" M-7060-00-GRAVA-EMITE-SEM-RISCO-SECTION */
        private void M_7060_00_GRAVA_EMITE_SEM_RISCO_SECTION()
        {
            /*" -3950- MOVE '7060' TO PARAGRAFO. */
            _.Move("7060", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3952- MOVE 'GRAVA EMISSAO SEM CLASSIF. RISCO' TO COMANDO. */
            _.Move("GRAVA EMISSAO SEM CLASSIF. RISCO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3953- MOVE 5 TO WS-COD-CRITICA */
            _.Move(5, WS_COD_CRITICA);

            /*" -3955- PERFORM 7100-00-CONS-COD-CRITICA */

            M_7100_00_CONS_COD_CRITICA_SECTION();

            /*" -3956- IF VG001-IND-EXISTE EQUAL 'S' */

            if (SPVG001V.VG001_IND_EXISTE == "S")
            {

                /*" -3957- GO TO 7060-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7060_99_SAIDA*/ //GOTO
                return;

                /*" -3960- END-IF */
            }


            /*" -3962- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -3963- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -3964- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -3965- MOVE NUMEROUT-NUM-CERT-VGAP TO LK-VG001-NUM-CERTIFICADO */
            _.Move(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -3966- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -3967- MOVE 'PJ' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PJ", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -3968- MOVE CLIENTES-CGCCPF TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -3969- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -3970- MOVE 'VG0001B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VG0001B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -3971- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -3972- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -3973- MOVE 5 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(5, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -3975- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -3977- MOVE 'EMISSAO DE APOL. ESPEC. SEM CLASSIFICACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("EMISSAO DE APOL. ESPEC. SEM CLASSIFICACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -3979- ADD 1 TO WS-QT-EMISSAO-S-RISCO */
            WS_QT_EMISSAO_S_RISCO.Value = WS_QT_EMISSAO_S_RISCO + 1;

            /*" -3981- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -3982- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -3983- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -3987- DISPLAY 'ERRO JAH GRAVADO 7060 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 7060 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -3988- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -3989- ELSE */
                }
                else
                {


                    /*" -3990- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -3991- DISPLAY '* 7060 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 7060 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -3992- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -3993- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -3994- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -3995- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -3996- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -3997- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -3998- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -4000- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -4001- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -4002- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4003- END-IF */
                }


                /*" -4004- END-IF */
            }


            /*" -4004- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7060_99_SAIDA*/

        [StopWatch]
        /*" M-7100-00-CONS-COD-CRITICA-SECTION */
        private void M_7100_00_CONS_COD_CRITICA_SECTION()
        {
            /*" -4012- MOVE '7100' TO PARAGRAFO. */
            _.Move("7100", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4014- MOVE 'VERIFICA SE TEM RISCO CRITICO   ' TO COMANDO. */
            _.Move("VERIFICA SE TEM RISCO CRITICO   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4015- MOVE 'N' TO VG001-IND-EXISTE */
            _.Move("N", SPVG001V.VG001_IND_EXISTE);

            /*" -4016- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -4017- MOVE 07 TO LK-VG001-TIPO-ACAO */
            _.Move(07, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -4018- MOVE NUMEROUT-NUM-CERT-VGAP TO LK-VG001-NUM-CERTIFICADO */
            _.Move(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -4019- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -4020- MOVE SPACES TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -4021- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -4022- MOVE WS-COD-CRITICA TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WS_COD_CRITICA, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -4023- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -4024- MOVE 'VG0001B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VG0001B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -4025- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -4026- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -4027- MOVE 00 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(00, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -4029- MOVE SPACES TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -4031- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -4032- IF LK-VG001-IND-ERRO = 0 */

            if (SPVG001W.LK_VG001_IND_ERRO == 0)
            {

                /*" -4033- IF LK-VG001-S-NUM-CERTIFICADO > 0 */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 0)
                {

                    /*" -4034- MOVE 'S' TO VG001-IND-EXISTE */
                    _.Move("S", SPVG001V.VG001_IND_EXISTE);

                    /*" -4035- ELSE */
                }
                else
                {


                    /*" -4036- MOVE 'N' TO VG001-IND-EXISTE */
                    _.Move("N", SPVG001V.VG001_IND_EXISTE);

                    /*" -4037- END-IF */
                }


                /*" -4038- ELSE */
            }
            else
            {


                /*" -4039- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4040- DISPLAY '* 7100 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                _.Display($"* 7100 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                /*" -4041- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4042- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -4043- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -4044- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -4045- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -4046- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -4047- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -4049- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4050- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -4051- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -4052- END-IF */
            }


            /*" -4052- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_7100_99_SAIDA*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -4062- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -4063- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -4065- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -4066- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -4070- DISPLAY VGSOLFAT-NUM-TITULO ' ' VGSOLFAT-NUM-APOLICE ' ' VGSOLFAT-COD-SUBGRUPO. */

            $"{VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE} {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}"
            .Display();

            /*" -4072- DISPLAY '*** VG0001B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VG0001B *** ROLLBACK EM ANDAMENTO ...");

            /*" -4072- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -4075- MOVE '9999' TO PARAGRAFO. */
            _.Move("9999", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4076- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4076- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4079- DISPLAY '*** VG0001B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VG0001B *** ERRO DE EXECUCAO");

            /*" -4080- DISPLAY NUMEROUT-NUM-CERT-VGAP */
            _.Display(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP);

            /*" -4081- DISPLAY PROPOVA-COD-PRODUTO */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);

            /*" -4082- DISPLAY SUBGVGAP-COD-CLIENTE */
            _.Display(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE);

            /*" -4083- DISPLAY SUBGVGAP-OCORR-ENDERECO */
            _.Display(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO);

            /*" -4084- DISPLAY SUBGVGAP-COD-FONTE */
            _.Display(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE);

            /*" -4085- DISPLAY PROPOVA-AGE-COBRANCA */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);

            /*" -4086- DISPLAY PROPOVA-DATA-QUITACAO */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);

            /*" -4087- DISPLAY TERMOADE-COD-AGENCIA-VEN */
            _.Display(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_VEN);

            /*" -4088- DISPLAY TERMOADE-OPERACAO-CONTA-VEN */
            _.Display(TERMOADE.DCLTERMO_ADESAO.TERMOADE_OPERACAO_CONTA_VEN);

            /*" -4089- DISPLAY TERMOADE-NUM-CONTA-VEN */
            _.Display(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_CONTA_VEN);

            /*" -4090- DISPLAY TERMOADE-DIG-CONTA-VEN */
            _.Display(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DIG_CONTA_VEN);

            /*" -4091- DISPLAY TERMOADE-NUM-MATRICULA-VEN */
            _.Display(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN);

            /*" -4092- DISPLAY SISTEMAS-DATA-MOV-ABERTO */
            _.Display(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

            /*" -4093- DISPLAY PROPOVA-DATA-QUITACAO */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);

            /*" -4094- DISPLAY PROPOVA-SIT-REGISTRO */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

            /*" -4095- DISPLAY VGSOLFAT-NUM-APOLICE */
            _.Display(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE);

            /*" -4096- DISPLAY VGSOLFAT-COD-SUBGRUPO */
            _.Display(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO);

            /*" -4097- DISPLAY PROPOVA-DTPROXVEN */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);

            /*" -4098- DISPLAY PROPOVA-NUM-PARCELA */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);

            /*" -4099- DISPLAY PROPOVA-DATA-VENCIMENTO */
            _.Display(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO);

            /*" -4100- DISPLAY ENDOSSOS-NUM-PROPOSTA */
            _.Display(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);

            /*" -4102- DISPLAY RCAPS-NUM-TITULO */
            _.Display(RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -4103- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -4103- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}