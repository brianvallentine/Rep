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
using Sias.VidaEmGrupo.DB2.VG0716S;

namespace Code
{
    public class VG0716S
    {
        public bool IsCall { get; set; }

        public VG0716S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ...............  SUBROTINAS                          *      */
        /*"      *   PROGRAMA ..............  VG0716S                             *      */
        /*"      *   ANALISTA ..............  FAST COMPUTER                       *      */
        /*"      *   PROGRAMADOR ...........  FAST COMPUTER                       *      */
        /*"      *   DATA CODIFICACAO ......  MARCO  / 2009                       *      */
        /*"      *   FUNCAO ................  POPULAR AS TABELAS DO SIAS A PARTIR *      */
        /*"      *                            DAS TABELAS DO SIATC PARA CHAMADAS  *      */
        /*"      *                            DE PROGRAMAS BATCH.                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"V.15  *  VERSAO 15  - DEMANDA 564.320                                  *      */
        /*"      *             - SUBSTITUIR A CHAMADA                                    */
        /*"      *                 DA SPBFC012 PELA SPBVG012                             */
        /*"      *             - PORQUE A CAP ESTA DEIXANDO O MAINFRAME.          *      */
        /*"      *                                                                *      */
        /*"      *  EM 22/01/2024 - RAUL BASILI ROTTA                             *      */
        /*"      *                                        PROCURE POR V.15        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14 - ALTERA CONSULTA AOS DADOS DO T�TULO ACOPLADO,    *      */
        /*"      *               INSERINDO CHAMADA DA SPBFC012. CADMUS 179924     *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/03/2020 - ALCIONE ARAUJO (STEFANINI)                   *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13 - HISTORIA 178780                                  *      */
        /*"      *             - MUDANCAS DE PRODUTOS ACOPLADOS - CAP             *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2019 - RIBAMAR MARQUES (ALTRAN)                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *             - CAD 21.756                                       *      */
        /*"      *               MUDANCA NOS PRODUTOS ACOPLADOS COM CAPITALIZACAO *      */
        /*"      *               PARA ATENDER A CIRCULAR SUSEP                    *      */
        /*"      *               CIRCULAR 365 DE 27 DE MAIO DE 2008               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11 - CAD 117.859 - ABEND                              *      */
        /*"      *                                                                *      */
        /*"      *       RECEBE IDENTIFICACAO QUANDO ACIONADO PELO PROG. VE0422B  *      */
        /*"      *       FILTRANDO OS DIPLAYS ENVIADOS PARA NAO ESTOURAR A SYSOUT *      */
        /*"      *       DA PROC JPVAD07.                                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/07/2015 - FRANK CARVALHO          PROCURE POR V.11     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 010                                                  *      */
        /*"      * MOTIVO  : RETIRAR DISPLAY QUE ESTA ESTOURANDO SYSOUT DA JPVPD05*      */
        /*"      * CADMUS  : 100159                                               *      */
        /*"      * DATA    : 09/07/2014                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.10                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09 - CAD 84.270                                       *      */
        /*"      *                                                                *      */
        /*"      *       VERIFICAR SE O NRTITFDCAP JA EXISTE NA TABELA            *      */
        /*"      *       SEGUROS.TITULOS_FED_CAP_VA.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/11/2013 - TERCIO FREITAS          PROCURE POR V.09    *       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CAD 72.656                                       *      */
        /*"      *                                                                *      */
        /*"      *       CORRECAO DA ATIVACAO DE TITULOS NA ESTRUTURA DE VIDA     *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/08/2012 - CLAUDIO FREITAS         PROCURE POR V.08    *       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 71.246                                       *      */
        /*"      *               AJUSTE TAMANHO DO CAMPO WS-NUM-TITULO, PASSA A   *      */
        /*"      *               TRATAR 07 BYTES.                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/06/2012 - TERCIO FREITAS           PROCURE POR V.07    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD 65.882/2011                                  *      */
        /*"      *               INICIALIZACAO DE CAMPOS DAS FC_FITULO            *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/02/2012 - FAST COMPUTER            PROCURE POR V.06    *      */
        /*"      *                   TERCIO CARVALHO                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD 26.727/2009                                  *      */
        /*"      *               AJUSTE PARA ATENDER A COMPRA DE T�TULOS          *      */
        /*"      *               PARA O PRODUTO VIDA EXCLUSIVO.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/08/2009 - FAST COMPUTER            PROCURE POR V.05    *      */
        /*"      *                   EDIVALDO GOMES                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD 27.843/2009                                  *      */
        /*"      *               PROGRAMA ALTERADO PARA GERAR NUMEROS DE SORTEIO  *      */
        /*"      *               REFERENTE AO MES DE DEZEMBRO DO ANO DE 2008 PARA *      */
        /*"      *               COBERTURA SUSPENSA.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/08/2009 - MARCO PAIVA(FAST COMPUTER)                   *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.04    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD 25.347/2009                                  *      */
        /*"      *               PROGRAMA RECOMPILADO EM FUNCAO DOS NOVOS         *      */
        /*"      *               ACOPLADOS GERADOS PELO PROGRAMA FC0105B          *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/06/2009 - FAST COMPUTER            PROCURE POR V.03    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD 24.836/2009                                  *      */
        /*"      *               PASSA A NAO MAIS INSERIR EM DUPLICIDADE NA       *      */
        /*"      *               TABELA SEGUROS.MOVIMEN_FED_CAP_VA                *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/05/2009 - FAST COMPUTER            PROCURE POR V.02    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CAD 24.699/2009  /   CAD 24.701                  *      */
        /*"      *               CORRECAO DO ABEND OCORRIDO (SQLCODE = 100) NA    *      */
        /*"      *               TABELA SEGUROS.TITULOS_FED_CAP_VA                *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/05/2009 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        /*"01           WS-TITFEDCA                PIC  X(001) VALUE 'S'.*/
        public StringBasis WS_TITFEDCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
        /*"01           WTEM-TITFEDCA              PIC  X(003) VALUE 'SIM'.*/
        public StringBasis WTEM_TITFEDCA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIM");
        /*"01           VIND-DTINIVIG                PIC S9(004)    COMP.*/
        public IntBasis VIND_DTINIVIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VIND-DTTERVIG                PIC S9(004)    COMP.*/
        public IntBasis VIND_DTTERVIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           WHOST-IND-DIA-VENCTO         PIC S9(004)    COMP.*/
        public IntBasis WHOST_IND_DIA_VENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           PRODUVG-COD-PRODUTO          PIC S9(004)    COMP.*/
        public IntBasis PRODUVG_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           FONTES-COD-FONTE             PIC S9(004)    COMP.*/
        public IntBasis FONTES_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           SISTEMAS-DATA-MOV-ABERTO-T   PIC  X(026).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_T { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01           SISTEMAS-DATA-MOV-ABERTO-1   PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01           SISTEMAS-DATA-MOV-ABERTO-2   PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01           WIND                         PIC S9(004)    COMP.*/
        public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           WS-SQLCODE                   PIC -999.*/
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-999."));
        /*"01           WS-DIA                       PIC  9(002).*/
        public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"01           WS-MES                       PIC  9(002).*/
        public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"01           WS-ANO                       PIC  9(004).*/
        public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        /*"01           WS-QTD                       PIC  9(004) VALUE 0.*/
        public IntBasis WS_QTD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01           WS-RESULTADO                 PIC S9(004)    COMP.*/
        public IntBasis WS_RESULTADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           WS-RESTO                     PIC S9(004)    COMP.*/
        public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           WS-TIME                      PIC X(08).*/
        public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"01           WS-NUM-PLANO-D               PIC 9(003).*/
        public IntBasis WS_NUM_PLANO_D { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
        /*"01           WS-VLR-PROPOSTA-D            PIC 99999999,99-.*/
        public DoubleBasis WS_VLR_PROPOSTA_D { get; set; } = new DoubleBasis(new PIC("9", "8", "99999999V99-."), 3);
        /*"01           WS-NUM-PROPOSTA-D            PIC 9(15).*/
        public IntBasis WS_NUM_PROPOSTA_D { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
        /*"01           WFIM-FCTITULO                PIC  X(003).*/
        public StringBasis WFIM_FCTITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  LK-NUM-PLANO-FC12              PIC S9(004)  USAGE COMP.*/
        public IntBasis LK_NUM_PLANO_FC12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-NUM-PROPOSTA-FC12           PIC S9(015)V USAGE COMP-3.*/
        public DoubleBasis LK_NUM_PROPOSTA_FC12 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V"), 0);
        /*"01  LK-COD-RAMO-FC12               PIC S9(004)  USAGE COMP.*/
        public IntBasis LK_COD_RAMO_FC12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-TRACE-FC12                  PIC  X(009).*/

        public SelectorBasis LK_TRACE_FC12 { get; set; } = new SelectorBasis("009")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 LK-TRACE-ON-FC12              VALUE 'TRACE ON '. */
							new SelectorItemBasis("LK_TRACE_ON_FC12", "TRACE ON "),
							/*" 88 LK-TRACE-OFF-FC12             VALUE 'TRACE OFF'. */
							new SelectorItemBasis("LK_TRACE_OFF_FC12", "TRACE OFF")
                }
        };

        /*"01  LK-NUM-PLANO-ED-FC12           PIC 9(009).*/
        public IntBasis LK_NUM_PLANO_ED_FC12 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01  LK-NUM-PROPOSTA-ED-FC12        PIC 9(015)V.*/
        public DoubleBasis LK_NUM_PROPOSTA_ED_FC12 { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V."), 0);
        /*"01  LK-COD-RAMO-ED-FC12            PIC 9(009).*/
        public IntBasis LK_COD_RAMO_ED_FC12 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01  LK-OUT-COD-RET-FC12            PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RET_FC12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-OUT-SQLCODE-FC12            PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE_FC12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-OUT-MENSAGEM-FC12           PIC  X(070).*/
        public StringBasis LK_OUT_MENSAGEM_FC12 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01  LK-OUT-SQLERRMC-FC12           PIC  X(070).*/
        public StringBasis LK_OUT_SQLERRMC_FC12 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01  LK-OUT-SQLSTATE-FC12           PIC  X(005).*/
        public StringBasis LK_OUT_SQLSTATE_FC12 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"01  WF-NUM-PLANO                   PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-NUM-SERIE                   PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-NUM-TITULO                  PIC S9(009)            COMP.*/
        public IntBasis WF_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WF-COD-STA-TITULO              PIC  X(003).*/
        public StringBasis WF_COD_STA_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  WF-COD-SUB-STATUS              PIC  X(003).*/
        public StringBasis WF_COD_SUB_STATUS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  WF-DTH-ATIVACAO                PIC  X(026).*/
        public StringBasis WF_DTH_ATIVACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  WF-DTH-CADUCACAO               PIC  X(010).*/
        public StringBasis WF_DTH_CADUCACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-CRIACAO                 PIC  X(026).*/
        public StringBasis WF_DTH_CRIACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  WF-DTH-FIM-VIGENCIA            PIC  X(010).*/
        public StringBasis WF_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-INI-SORTEIO             PIC  X(010).*/
        public StringBasis WF_DTH_INI_SORTEIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-INI-VIGENCIA            PIC  X(010).*/
        public StringBasis WF_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-DTH-SUSPENSAO               PIC  X(010).*/
        public StringBasis WF_DTH_SUSPENSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WF-IND-DV                      PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_IND_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-VLR-MENSALIDADE             PIC S9(008)V9(2) USAGE COMP-3*/
        public DoubleBasis WF_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
        /*"01  WF-NUM-PROPOSTA                PIC S9(015)V     USAGE COMP-3*/
        public DoubleBasis WF_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V"), 0);
        /*"01  WF-NUM-MOD-PLANO               PIC S9(004)      USAGE COMP.*/
        public IntBasis WF_NUM_MOD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WF-DES-COMBINACAO              PIC  X(020).*/
        public StringBasis WF_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  WS-EOF.*/
        public VG0716S_WS_EOF WS_EOF { get; set; } = new VG0716S_WS_EOF();
        public class VG0716S_WS_EOF : VarBasis
        {
            /*"    03  WS-EOF-FD001               PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF_FD001 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    03  WS-EOF-RESULT              PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF_RESULT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"01  WL-LOCATOR     USAGE SQL TYPE IS RESULT-SET-LOCATOR VARYING.*/
        }
        public IntBasis WL_LOCATOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-COD-RETORNO                PIC  9(004) VALUE ZEROS.*/
        public IntBasis WS_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01  WS-COD-RAMO                   PIC  9(004) VALUE ZEROS.*/
        public IntBasis WS_COD_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01  WS-NUM-PROPOSTA               PIC  9(015) VALUE ZEROS.*/
        public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"01  WS-QTD-TIT-CAP                PIC  9(004) VALUE ZEROS.*/
        public IntBasis WS_QTD_TIT_CAP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01     WS-NUM-TITULO-X.*/
        public VG0716S_WS_NUM_TITULO_X WS_NUM_TITULO_X { get; set; } = new VG0716S_WS_NUM_TITULO_X();
        public class VG0716S_WS_NUM_TITULO_X : VarBasis
        {
            /*"   05  WS-NUM-PLANO                  PIC  9(003).*/
            public IntBasis WS_NUM_PLANO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"   05  WS-NUM-SERIE                  PIC  9(003).*/
            public IntBasis WS_NUM_SERIE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"   05  WS-NUM-TITULO                 PIC  9(006).*/
            public IntBasis WS_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01     WS-NUM-TITULO-9               REDEFINES       WS-NUM-TITULO-X               PIC  9(012).*/
        }
        private _REDEF_IntBasis _ws_num_titulo_9 { get; set; }
        public _REDEF_IntBasis WS_NUM_TITULO_9
        {
            get { _ws_num_titulo_9 = new _REDEF_IntBasis(new PIC("9", "012", "9(012).")); ; _.Move(WS_NUM_TITULO_X, _ws_num_titulo_9); VarBasis.RedefinePassValue(WS_NUM_TITULO_X, _ws_num_titulo_9, WS_NUM_TITULO_X); _ws_num_titulo_9.ValueChanged += () => { _.Move(_ws_num_titulo_9, WS_NUM_TITULO_X); }; return _ws_num_titulo_9; }
            set { VarBasis.RedefinePassValue(value, _ws_num_titulo_9, WS_NUM_TITULO_X); }
        }  //Redefines
        /*"01     WS-COMBINACAO                 PIC  X(020).*/
        public StringBasis WS_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01     WS-COMBINACAO-R               REDEFINES       WS-COMBINACAO.*/
        private _REDEF_VG0716S_WS_COMBINACAO_R _ws_combinacao_r { get; set; }
        public _REDEF_VG0716S_WS_COMBINACAO_R WS_COMBINACAO_R
        {
            get { _ws_combinacao_r = new _REDEF_VG0716S_WS_COMBINACAO_R(); _.Move(WS_COMBINACAO, _ws_combinacao_r); VarBasis.RedefinePassValue(WS_COMBINACAO, _ws_combinacao_r, WS_COMBINACAO); _ws_combinacao_r.ValueChanged += () => { _.Move(_ws_combinacao_r, WS_COMBINACAO); }; return _ws_combinacao_r; }
            set { VarBasis.RedefinePassValue(value, _ws_combinacao_r, WS_COMBINACAO); }
        }  //Redefines
        public class _REDEF_VG0716S_WS_COMBINACAO_R : VarBasis
        {
            /*"   05  WS-COMB OCCURS 20 TIMES       PIC  X(001).*/
            public ListBasis<StringBasis, string> WS_COMB { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 20);
            /*"01     WS-COMBINACAO-9               PIC  9(009).*/

            public _REDEF_VG0716S_WS_COMBINACAO_R()
            {
                WS_COMB.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_COMBINACAO_9 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01           VG0716S-COD-FONTE       PIC  S9(004) COMP.*/
        public IntBasis VG0716S_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-COD-PRODUTO     PIC  S9(004) COMP.*/
        public IntBasis VG0716S_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-NUM-PROPOSTA    PIC  S9(015)    COMP-3.*/
        public IntBasis VG0716S_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01           VG0716S-VLR-MENSALIDADE PIC  S9(008)V99 COMP-3.*/
        public DoubleBasis VG0716S_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V99"), 2);
        /*"01           VG0716S-NUM-PLANO       PIC  S9(004) COMP.*/
        public IntBasis VG0716S_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-NUM-SERIE       PIC  S9(004) COMP.*/
        public IntBasis VG0716S_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-NUM-TITULO      PIC  S9(009) COMP.*/
        public IntBasis VG0716S_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01           VG0716S-IND-DV          PIC  S9(004) COMP.*/
        public IntBasis VG0716S_IND_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-DTH-INI-VIGENCIA PIC  X(010).*/
        public StringBasis VG0716S_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01           VG0716S-DTH-FIM-VIGENCIA PIC  X(010).*/
        public StringBasis VG0716S_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01           VG0716S-DES-COMBINACAO  PIC   X(020).*/
        public StringBasis VG0716S_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01           VG0716S-COD-STA-TITULO  PIC   X(003).*/
        public StringBasis VG0716S_COD_STA_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01           VG0716S-SQLCODE         PIC  S9(004) COMP.*/
        public IntBasis VG0716S_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-COD-RETORNO     PIC  S9(004) COMP.*/
        public IntBasis VG0716S_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-DES-MENSAGEM    PIC   X(070).*/
        public StringBasis VG0716S_DES_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.ABEND ABEND { get; set; } = new Dclgens.ABEND();
        public Dclgens.FCTPROPO FCTPROPO { get; set; } = new Dclgens.FCTPROPO();
        public Dclgens.MOVFEDCA MOVFEDCA { get; set; } = new Dclgens.MOVFEDCA();
        public Dclgens.TITFEDCA TITFEDCA { get; set; } = new Dclgens.TITFEDCA();
        public Dclgens.PARFEDCA PARFEDCA { get; set; } = new Dclgens.PARFEDCA();
        public VG0716S_C01_RESULT C01_RESULT { get; set; } = new VG0716S_C01_RESULT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(IntBasis VG0716S_COD_FONTE_P, IntBasis VG0716S_COD_PRODUTO_P, IntBasis VG0716S_NUM_PROPOSTA_P, DoubleBasis VG0716S_VLR_MENSALIDADE_P, IntBasis VG0716S_NUM_PLANO_P, IntBasis VG0716S_NUM_SERIE_P, IntBasis VG0716S_NUM_TITULO_P, IntBasis VG0716S_IND_DV_P, StringBasis VG0716S_DTH_INI_VIGENCIA_P, StringBasis VG0716S_DTH_FIM_VIGENCIA_P, StringBasis VG0716S_DES_COMBINACAO_P, StringBasis VG0716S_COD_STA_TITULO_P, IntBasis VG0716S_SQLCODE_P, IntBasis VG0716S_COD_RETORNO_P, StringBasis VG0716S_DES_MENSAGEM_P) //PROCEDURE DIVISION USING 
        /*PROCEDURE DIVISION
        VG0716S_COD_FONTE
        VG0716S_COD_PRODUTO
        VG0716S_NUM_PROPOSTA
        VG0716S_VLR_MENSALIDADE
        VG0716S_NUM_PLANO
        VG0716S_NUM_SERIE
        VG0716S_NUM_TITULO
        VG0716S_IND_DV
        VG0716S_DTH_INI_VIGENCIA
        VG0716S_DTH_FIM_VIGENCIA
        VG0716S_DES_COMBINACAO
        VG0716S_COD_STA_TITULO
        VG0716S_SQLCODE
        VG0716S_COD_RETORNO
        VG0716S_DES_MENSAGEM*/
        {
            try
            {
                this.VG0716S_COD_FONTE.Value = VG0716S_COD_FONTE_P.Value;
                this.VG0716S_COD_PRODUTO.Value = VG0716S_COD_PRODUTO_P.Value;
                this.VG0716S_NUM_PROPOSTA.Value = VG0716S_NUM_PROPOSTA_P.Value;
                this.VG0716S_VLR_MENSALIDADE.Value = VG0716S_VLR_MENSALIDADE_P.Value;
                this.VG0716S_NUM_PLANO.Value = VG0716S_NUM_PLANO_P.Value;
                this.VG0716S_NUM_SERIE.Value = VG0716S_NUM_SERIE_P.Value;
                this.VG0716S_NUM_TITULO.Value = VG0716S_NUM_TITULO_P.Value;
                this.VG0716S_IND_DV.Value = VG0716S_IND_DV_P.Value;
                this.VG0716S_DTH_INI_VIGENCIA.Value = VG0716S_DTH_INI_VIGENCIA_P.Value;
                this.VG0716S_DTH_FIM_VIGENCIA.Value = VG0716S_DTH_FIM_VIGENCIA_P.Value;
                this.VG0716S_DES_COMBINACAO.Value = VG0716S_DES_COMBINACAO_P.Value;
                this.VG0716S_COD_STA_TITULO.Value = VG0716S_COD_STA_TITULO_P.Value;
                this.VG0716S_SQLCODE.Value = VG0716S_SQLCODE_P.Value;
                this.VG0716S_COD_RETORNO.Value = VG0716S_COD_RETORNO_P.Value;
                this.VG0716S_DES_MENSAGEM.Value = VG0716S_DES_MENSAGEM_P.Value;

                /*" -287- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -288- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -289- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -294- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -308- INITIALIZE VG0716S-SQLCODE VG0716S-NUM-SERIE VG0716S-NUM-TITULO VG0716S-IND-DV VG0716S-DTH-INI-VIGENCIA VG0716S-DTH-FIM-VIGENCIA VG0716S-DES-COMBINACAO VG0716S-SQLCODE VG0716S-COD-RETORNO VG0716S-DES-MENSAGEM WFIM-FCTITULO */
                _.Initialize(
                    VG0716S_SQLCODE
                    , VG0716S_NUM_SERIE
                    , VG0716S_NUM_TITULO
                    , VG0716S_IND_DV
                    , VG0716S_DTH_INI_VIGENCIA
                    , VG0716S_DTH_FIM_VIGENCIA
                    , VG0716S_DES_COMBINACAO
                    , VG0716S_SQLCODE
                    , VG0716S_COD_RETORNO
                    , VG0716S_DES_MENSAGEM
                    , WFIM_FCTITULO
                );

                /*" -311- MOVE 'R0000' TO ABEND-COD-PROCESSO. */
                _.Move("R0000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

                /*" -313- PERFORM R0105-00-SELECT-SISTEMAS. */

                R0105_00_SELECT_SISTEMAS_SECTION();

                /*" -315- PERFORM R0100-00-VERIFICA-PARAMETROS */

                R0100_00_VERIFICA_PARAMETROS_SECTION();

                /*" -316- IF VG0716S-COD-RETORNO EQUAL ZEROS */

                if (VG0716S_COD_RETORNO == 00)
                {

                    /*" -317- PERFORM R0200-00-FORMATA-SAIDA */

                    R0200_00_FORMATA_SAIDA_SECTION();

                    /*" -318- ELSE */
                }
                else
                {


                    /*" -319- PERFORM R0300-00-FORMATA-SAIDA */

                    R0300_00_FORMATA_SAIDA_SECTION();

                    /*" -321- END-IF. */
                }


                /*" -321- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { VG0716S_COD_FONTE, VG0716S_COD_PRODUTO, VG0716S_NUM_PROPOSTA, VG0716S_VLR_MENSALIDADE, VG0716S_NUM_PLANO, VG0716S_NUM_SERIE, VG0716S_NUM_TITULO, VG0716S_IND_DV, VG0716S_DTH_INI_VIGENCIA, VG0716S_DTH_FIM_VIGENCIA, VG0716S_DES_COMBINACAO, VG0716S_COD_STA_TITULO, VG0716S_SQLCODE, VG0716S_COD_RETORNO, VG0716S_DES_MENSAGEM };
            return Result;
        }

        [StopWatch]
        /*" R0100-00-VERIFICA-PARAMETROS-SECTION */
        private void R0100_00_VERIFICA_PARAMETROS_SECTION()
        {
            /*" -334- MOVE 'R0100' TO ABEND-COD-PROCESSO. */
            _.Move("R0100", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -335- IF VG0716S-NUM-PROPOSTA EQUAL ZEROS */

            if (VG0716S_NUM_PROPOSTA == 00)
            {

                /*" -336- MOVE 01 TO VG0716S-COD-RETORNO */
                _.Move(01, VG0716S_COD_RETORNO);

                /*" -338- MOVE 'VG0716S - CERTIFICADO ZERADO   ' TO VG0716S-DES-MENSAGEM */
                _.Move("VG0716S - CERTIFICADO ZERADO   ", VG0716S_DES_MENSAGEM);

                /*" -339- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -371- END-IF. */
            }


            /*" -373- INITIALIZE WS-QTD-TIT-CAP. */
            _.Initialize(
                WS_QTD_TIT_CAP
            );

            /*" -373- PERFORM R0900-00-CHAMA-SPBFC012. */

            R0900_00_CHAMA_SPBFC012_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0105-00-SELECT-SISTEMAS-SECTION */
        private void R0105_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -386- MOVE 'R0105' TO ABEND-COD-PROCESSO. */
            _.Move("R0105", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -391- PERFORM R0105_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0105_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -394- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -395- MOVE 01 TO VG0716S-COD-RETORNO */
                _.Move(01, VG0716S_COD_RETORNO);

                /*" -397- MOVE 'VG0716S - ERRO SELECT    - SISTEMAS' TO VG0716S-DES-MENSAGEM */
                _.Move("VG0716S - ERRO SELECT    - SISTEMAS", VG0716S_DES_MENSAGEM);

                /*" -399- MOVE SQLCODE TO VG0716S-SQLCODE WS-SQLCODE */
                _.Move(DB.SQLCODE, VG0716S_SQLCODE, WS_SQLCODE);

                /*" -400- DISPLAY ' ' */
                _.Display($" ");

                /*" -402- DISPLAY '==> ERRO SELECT SEGUROS.SISTEMAS. SQLCODE <' WS-SQLCODE '>' */

                $"==> ERRO SELECT SEGUROS.SISTEMAS. SQLCODE <{WS_SQLCODE}>"
                .Display();

                /*" -403- DISPLAY ' ' */
                _.Display($" ");

                /*" -404- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -404- END-IF. */
            }


        }

        [StopWatch]
        /*" R0105-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0105_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -391- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

            var r0105_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0105_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0105_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0105_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0105_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-FORMATA-SAIDA-SECTION */
        private void R0200_00_FORMATA_SAIDA_SECTION()
        {
            /*" -416- MOVE 'R0200' TO ABEND-COD-PROCESSO. */
            _.Move("R0200", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -420- MOVE WF-NUM-PLANO TO VG0716S-NUM-PLANO */
            _.Move(WF_NUM_PLANO, VG0716S_NUM_PLANO);

            /*" -424- MOVE WF-NUM-SERIE TO VG0716S-NUM-SERIE */
            _.Move(WF_NUM_SERIE, VG0716S_NUM_SERIE);

            /*" -428- MOVE WF-NUM-TITULO TO VG0716S-NUM-TITULO */
            _.Move(WF_NUM_TITULO, VG0716S_NUM_TITULO);

            /*" -432- MOVE WF-IND-DV TO VG0716S-IND-DV */
            _.Move(WF_IND_DV, VG0716S_IND_DV);

            /*" -436- MOVE WF-DTH-INI-VIGENCIA TO VG0716S-DTH-INI-VIGENCIA */
            _.Move(WF_DTH_INI_VIGENCIA, VG0716S_DTH_INI_VIGENCIA);

            /*" -440- MOVE WF-DTH-FIM-VIGENCIA TO VG0716S-DTH-FIM-VIGENCIA */
            _.Move(WF_DTH_FIM_VIGENCIA, VG0716S_DTH_FIM_VIGENCIA);

            /*" -444- MOVE WF-COD-STA-TITULO TO VG0716S-COD-STA-TITULO. */
            _.Move(WF_COD_STA_TITULO, VG0716S_COD_STA_TITULO);

            /*" -445- MOVE WF-DES-COMBINACAO TO VG0716S-DES-COMBINACAO. */
            _.Move(WF_DES_COMBINACAO, VG0716S_DES_COMBINACAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-FORMATA-SAIDA-SECTION */
        private void R0300_00_FORMATA_SAIDA_SECTION()
        {
            /*" -457- MOVE 'R0300' TO ABEND-COD-PROCESSO. */
            _.Move("R0300", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -457- MOVE SQLCODE TO VG0716S-SQLCODE. */
            _.Move(DB.SQLCODE, VG0716S_SQLCODE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-CHAMA-SPBFC012-SECTION */
        private void R0900_00_CHAMA_SPBFC012_SECTION()
        {
            /*" -571- INITIALIZE WF-NUM-PLANO , WF-NUM-SERIE , WF-NUM-TITULO , WF-COD-STA-TITULO , WF-COD-SUB-STATUS , WF-DTH-ATIVACAO , WF-DTH-CADUCACAO , WF-DTH-CRIACAO , WF-DTH-FIM-VIGENCIA , WF-DTH-INI-SORTEIO , WF-DTH-INI-VIGENCIA , WF-DTH-SUSPENSAO , WF-IND-DV , WF-VLR-MENSALIDADE , WF-NUM-PROPOSTA , WF-NUM-MOD-PLANO , LK-OUT-COD-RET-FC12 , LK-OUT-SQLCODE-FC12 , LK-OUT-MENSAGEM-FC12 , LK-OUT-SQLERRMC-FC12 , LK-OUT-SQLSTATE-FC12 */
            _.Initialize(
                WF_NUM_PLANO
                , WF_NUM_SERIE
                , WF_NUM_TITULO
                , WF_COD_STA_TITULO
                , WF_COD_SUB_STATUS
                , WF_DTH_ATIVACAO
                , WF_DTH_CADUCACAO
                , WF_DTH_CRIACAO
                , WF_DTH_FIM_VIGENCIA
                , WF_DTH_INI_SORTEIO
                , WF_DTH_INI_VIGENCIA
                , WF_DTH_SUSPENSAO
                , WF_IND_DV
                , WF_VLR_MENSALIDADE
                , WF_NUM_PROPOSTA
                , WF_NUM_MOD_PLANO
                , LK_OUT_COD_RET_FC12
                , LK_OUT_SQLCODE_FC12
                , LK_OUT_MENSAGEM_FC12
                , LK_OUT_SQLERRMC_FC12
                , LK_OUT_SQLSTATE_FC12
            );

            /*" -573- MOVE VG0716S-NUM-PLANO TO LK-NUM-PLANO-FC12 WS-NUM-PLANO */
            _.Move(VG0716S_NUM_PLANO, LK_NUM_PLANO_FC12, WS_NUM_TITULO_X.WS_NUM_PLANO);

            /*" -575- MOVE VG0716S-NUM-PROPOSTA TO LK-NUM-PROPOSTA-FC12 WS-NUM-PROPOSTA */
            _.Move(VG0716S_NUM_PROPOSTA, LK_NUM_PROPOSTA_FC12, WS_NUM_PROPOSTA);

            /*" -582- MOVE VG0716S-COD-PRODUTO TO LK-COD-RAMO-FC12 WS-COD-RAMO */
            _.Move(VG0716S_COD_PRODUTO, LK_COD_RAMO_FC12, WS_COD_RAMO);

            /*" -594- PERFORM R0900_00_CHAMA_SPBFC012_DB_CALL_1 */

            R0900_00_CHAMA_SPBFC012_DB_CALL_1();

            /*" -597- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -599- MOVE LK-OUT-COD-RET-FC12 TO WS-COD-RETORNO */
            _.Move(LK_OUT_COD_RET_FC12, WS_COD_RETORNO);

            /*" -600- IF SQLCODE NOT = 000 AND +466 */

            if (!DB.SQLCODE.In("000", "+466"))
            {

                /*" -603- DISPLAY 'ERRO NA CONSULTA - SPBVG012 - ' ' COD-RET <' WS-COD-RETORNO '>' ' SQLCODE <' WS-SQLCODE '>' */

                $"ERRO NA CONSULTA - SPBVG012 -  COD-RET <{WS_COD_RETORNO}> SQLCODE <{WS_SQLCODE}>"
                .Display();

                /*" -608- DISPLAY ' BILHETE <' LK-NUM-PROPOSTA-FC12 '/' LK-OUT-COD-RET-FC12 '/' LK-OUT-MENSAGEM-FC12 '/' LK-OUT-SQLERRMC-FC12 '/' LK-OUT-SQLSTATE-FC12 '>' */

                $" BILHETE <{LK_NUM_PROPOSTA_FC12}/{LK_OUT_COD_RET_FC12}/{LK_OUT_MENSAGEM_FC12}/{LK_OUT_SQLERRMC_FC12}/{LK_OUT_SQLSTATE_FC12}>"
                .Display();

                /*" -609- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -611- END-IF */
            }


            /*" -613- IF LK-OUT-COD-RET-FC12 NOT EQUAL ZEROES AND LK-OUT-SQLCODE-FC12 NOT EQUAL ZEROES AND +100 */

            if (LK_OUT_COD_RET_FC12 != 00 && !LK_OUT_SQLCODE_FC12.In("00", "+100"))
            {

                /*" -614- DISPLAY 'LK-OUT-COD-RETORNO = ' WS-COD-RETORNO */
                _.Display($"LK-OUT-COD-RETORNO = {WS_COD_RETORNO}");

                /*" -617- DISPLAY 'ERRO NA RETORNO DA SPBVG012 - ' ' COD-RET <' WS-COD-RETORNO '>' ' SQLCODE <' WS-SQLCODE '>' */

                $"ERRO NA RETORNO DA SPBVG012 -  COD-RET <{WS_COD_RETORNO}> SQLCODE <{WS_SQLCODE}>"
                .Display();

                /*" -622- DISPLAY ' BILHETE <' LK-NUM-PROPOSTA-FC12 '/' LK-OUT-COD-RET-FC12 '/' LK-OUT-MENSAGEM-FC12 '/' LK-OUT-SQLERRMC-FC12 '/' LK-OUT-SQLSTATE-FC12 '>' */

                $" BILHETE <{LK_NUM_PROPOSTA_FC12}/{LK_OUT_COD_RET_FC12}/{LK_OUT_MENSAGEM_FC12}/{LK_OUT_SQLERRMC_FC12}/{LK_OUT_SQLSTATE_FC12}>"
                .Display();

                /*" -623- MOVE LK-OUT-SQLCODE-FC12 TO VG0716S-SQLCODE */
                _.Move(LK_OUT_SQLCODE_FC12, VG0716S_SQLCODE);

                /*" -624- MOVE LK-OUT-COD-RET-FC12 TO VG0716S-COD-RETORNO */
                _.Move(LK_OUT_COD_RET_FC12, VG0716S_COD_RETORNO);

                /*" -625- MOVE LK-OUT-MENSAGEM-FC12 TO VG0716S-DES-MENSAGEM */
                _.Move(LK_OUT_MENSAGEM_FC12, VG0716S_DES_MENSAGEM);

                /*" -626- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -628- END-IF */
            }


            /*" -629- IF LK-OUT-COD-RET-FC12 EQUAL 000 */

            if (LK_OUT_COD_RET_FC12 == 000)
            {

                /*" -630- MOVE ZEROS TO WS-EOF-RESULT */
                _.Move(0, WS_EOF.WS_EOF_RESULT);

                /*" -631- IF SQLCODE = +466 */

                if (DB.SQLCODE == +466)
                {

                    /*" -632- PERFORM R0910-TRATAR-RESULT */

                    R0910_TRATAR_RESULT_SECTION();

                    /*" -634- PERFORM R0920-LER-RESULT UNTIL WS-EOF-RESULT NOT EQUAL ZEROES */

                    while (!(WS_EOF.WS_EOF_RESULT != 00))
                    {

                        R0920_LER_RESULT_SECTION();
                    }

                    /*" -635- PERFORM R9160-FECHAR-CURSOR */

                    R9160_FECHAR_CURSOR_SECTION();

                    /*" -636- END-IF */
                }


                /*" -637- END-IF */
            }


            /*" -637- . */

        }

        [StopWatch]
        /*" R0900-00-CHAMA-SPBFC012-DB-CALL-1 */
        public void R0900_00_CHAMA_SPBFC012_DB_CALL_1()
        {
            /*" -594- EXEC SQL CALL SEGUROS.SPBVG012 ( :LK-NUM-PLANO-FC12 , :LK-NUM-PROPOSTA-FC12 , :LK-COD-RAMO-FC12 , :LK-TRACE-FC12 , :LK-OUT-COD-RET-FC12 , :LK-OUT-SQLCODE-FC12 , :LK-OUT-MENSAGEM-FC12 , :LK-OUT-SQLERRMC-FC12 , :LK-OUT-SQLSTATE-FC12 ) END-EXEC */

            var sEGUROS_SPBVG012_Call1 = new SEGUROS_SPBVG012_Call1()
            {
                LK_NUM_PLANO_FC12 = LK_NUM_PLANO_FC12.ToString(),
                LK_NUM_PROPOSTA_FC12 = LK_NUM_PROPOSTA_FC12.ToString(),
                LK_COD_RAMO_FC12 = LK_COD_RAMO_FC12.ToString(),
                LK_TRACE_FC12 = LK_TRACE_FC12.ToString(),
                LK_OUT_COD_RET_FC12 = LK_OUT_COD_RET_FC12.ToString(),
                LK_OUT_SQLCODE_FC12 = LK_OUT_SQLCODE_FC12.ToString(),
                LK_OUT_MENSAGEM_FC12 = LK_OUT_MENSAGEM_FC12.ToString(),
                LK_OUT_SQLERRMC_FC12 = LK_OUT_SQLERRMC_FC12.ToString(),
                LK_OUT_SQLSTATE_FC12 = LK_OUT_SQLSTATE_FC12.ToString(),
            };

            var executed_1 = SEGUROS_SPBVG012_Call1.Execute(sEGUROS_SPBVG012_Call1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_NUM_PLANO_FC12, LK_NUM_PLANO_FC12);
                _.Move(executed_1.LK_NUM_PROPOSTA_FC12, LK_NUM_PROPOSTA_FC12);
                _.Move(executed_1.LK_COD_RAMO_FC12, LK_COD_RAMO_FC12);
                _.Move(executed_1.LK_TRACE_FC12, LK_TRACE_FC12);
                _.Move(executed_1.LK_OUT_COD_RET_FC12, LK_OUT_COD_RET_FC12);
                _.Move(executed_1.LK_OUT_SQLCODE_FC12, LK_OUT_SQLCODE_FC12);
                _.Move(executed_1.LK_OUT_MENSAGEM_FC12, LK_OUT_MENSAGEM_FC12);
                _.Move(executed_1.LK_OUT_SQLERRMC_FC12, LK_OUT_SQLERRMC_FC12);
                _.Move(executed_1.LK_OUT_SQLSTATE_FC12, LK_OUT_SQLSTATE_FC12);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-TRATAR-RESULT-SECTION */
        private void R0910_TRATAR_RESULT_SECTION()
        {
            /*" -646- EXEC SQL ASSOCIATE LOCATORS (:WL-LOCATOR) WITH PROCEDURE SEGUROS.SPBVG012 END-EXEC */
            /*-Linha desconsiderada por ser -inútil- no .NET por segurança adicionado SQLCODE = 0*/
            DB.SQLCODE.Value = 0;

            /*" -650- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -651- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -653- DISPLAY 'ERRO NO R0910 - SPBVG012 - ' ' SQLCODE <' WS-SQLCODE '>' */

                $"ERRO NO R0910 - SPBVG012 -  SQLCODE <{WS_SQLCODE}>"
                .Display();

                /*" -654- DISPLAY ' BILHETE <' WS-NUM-PROPOSTA '>' */

                $" BILHETE <{WS_NUM_PROPOSTA}>"
                .Display();

                /*" -655- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -657- END-IF */
            }


            /*" -660- EXEC SQL ALLOCATE C01-RESULT CURSOR FOR RESULT SET :WL-LOCATOR END-EXEC */
            C01_RESULT.Allocate($"SEGUROS.SPBVG012");

            /*" -661- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0920-LER-RESULT-SECTION */
        private void R0920_LER_RESULT_SECTION()
        {
            /*" -686- PERFORM R0920_LER_RESULT_DB_FETCH_1 */

            R0920_LER_RESULT_DB_FETCH_1();

            /*" -690- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -691- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -693- DISPLAY 'ERRO CURSOR <C01-RESULT> SQLCODE <' WS-SQLCODE '>' */

                $"ERRO CURSOR <C01-RESULT> SQLCODE <{WS_SQLCODE}>"
                .Display();

                /*" -694- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -695- ELSE */
            }
            else
            {


                /*" -697- IF SQLCODE EQUAL ZEROES */

                if (DB.SQLCODE == 00)
                {

                    /*" -698- ADD 1 TO WS-QTD-TIT-CAP */
                    WS_QTD_TIT_CAP.Value = WS_QTD_TIT_CAP + 1;

                    /*" -699- MOVE WF-NUM-PLANO TO WS-NUM-PLANO */
                    _.Move(WF_NUM_PLANO, WS_NUM_TITULO_X.WS_NUM_PLANO);

                    /*" -700- MOVE WF-NUM-SERIE TO WS-NUM-SERIE */
                    _.Move(WF_NUM_SERIE, WS_NUM_TITULO_X.WS_NUM_SERIE);

                    /*" -710- MOVE WF-NUM-TITULO TO WS-NUM-TITULO */
                    _.Move(WF_NUM_TITULO, WS_NUM_TITULO_X.WS_NUM_TITULO);

                    /*" -711- PERFORM R1000-00-PROCESSA-REGISTRO */

                    R1000_00_PROCESSA_REGISTRO_SECTION();

                    /*" -712- ELSE */
                }
                else
                {


                    /*" -713- INITIALIZE VG0716S-DES-MENSAGEM */
                    _.Initialize(
                        VG0716S_DES_MENSAGEM
                    );

                    /*" -714- IF WS-QTD-TIT-CAP EQUAL ZEROS */

                    if (WS_QTD_TIT_CAP == 00)
                    {

                        /*" -718- STRING 'NENHUM TITULO ENCONTRADO PARA A PROPOSTA <' WS-NUM-PLANO '/' WS-NUM-PROPOSTA '/' WS-COD-RAMO '>' DELIMITED BY SIZE INTO VG0716S-DES-MENSAGEM END-STRING */
                        #region STRING
                        var spl1 = "NENHUM TITULO ENCONTRADO PARA A PROPOSTA <" + WS_NUM_TITULO_X.WS_NUM_PLANO.GetMoveValues();
                        spl1 += "/";
                        var spl2 = WS_NUM_PROPOSTA.GetMoveValues();
                        spl2 += "/";
                        var spl3 = WS_COD_RAMO.GetMoveValues();
                        spl3 += ">";
                        var results4 = spl1 + spl2 + spl3;
                        _.Move(results4, VG0716S_DES_MENSAGEM);
                        #endregion

                        /*" -720- MOVE +100 TO VG0716S-SQLCODE WS-SQLCODE */
                        _.Move(+100, VG0716S_SQLCODE, WS_SQLCODE);

                        /*" -722- END-IF */
                    }


                    /*" -729- IF WS-QTD-TIT-CAP > ZEROS */

                    if (WS_QTD_TIT_CAP > 00)
                    {

                        /*" -731- MOVE ZEROS TO VG0716S-SQLCODE WS-SQLCODE */
                        _.Move(0, VG0716S_SQLCODE, WS_SQLCODE);

                        /*" -734- END-IF */
                    }


                    /*" -735- MOVE 1 TO WS-EOF-RESULT */
                    _.Move(1, WS_EOF.WS_EOF_RESULT);

                    /*" -736- END-IF */
                }


                /*" -737- END-IF */
            }


            /*" -737- . */

        }

        [StopWatch]
        /*" R0920-LER-RESULT-DB-FETCH-1 */
        public void R0920_LER_RESULT_DB_FETCH_1()
        {
            /*" -686- EXEC SQL FETCH C01-RESULT INTO :WF-NUM-PLANO , :WF-NUM-SERIE , :WF-NUM-TITULO , :WF-COD-STA-TITULO , :WF-COD-SUB-STATUS , :WF-DTH-ATIVACAO , :WF-DTH-CADUCACAO , :WF-DTH-CRIACAO , :WF-DTH-FIM-VIGENCIA , :WF-DTH-INI-SORTEIO , :WF-DTH-INI-VIGENCIA , :WF-DTH-SUSPENSAO , :WF-IND-DV , :WF-VLR-MENSALIDADE , :WF-NUM-PROPOSTA , :WF-NUM-MOD-PLANO , :WF-DES-COMBINACAO END-EXEC */

            if (C01_RESULT.Fetch())
            {
                _.Move(C01_RESULT.WF_NUM_PLANO, WF_NUM_PLANO);
                _.Move(C01_RESULT.WF_NUM_SERIE, WF_NUM_SERIE);
                _.Move(C01_RESULT.WF_NUM_TITULO, WF_NUM_TITULO);
                _.Move(C01_RESULT.WF_COD_STA_TITULO, WF_COD_STA_TITULO);
                _.Move(C01_RESULT.WF_COD_SUB_STATUS, WF_COD_SUB_STATUS);
                _.Move(C01_RESULT.WF_DTH_ATIVACAO, WF_DTH_ATIVACAO);
                _.Move(C01_RESULT.WF_DTH_CADUCACAO, WF_DTH_CADUCACAO);
                _.Move(C01_RESULT.WF_DTH_CRIACAO, WF_DTH_CRIACAO);
                _.Move(C01_RESULT.WF_DTH_FIM_VIGENCIA, WF_DTH_FIM_VIGENCIA);
                _.Move(C01_RESULT.WF_DTH_INI_SORTEIO, WF_DTH_INI_SORTEIO);
                _.Move(C01_RESULT.WF_DTH_INI_VIGENCIA, WF_DTH_INI_VIGENCIA);
                _.Move(C01_RESULT.WF_DTH_SUSPENSAO, WF_DTH_SUSPENSAO);
                _.Move(C01_RESULT.WF_IND_DV, WF_IND_DV);
                _.Move(C01_RESULT.WF_VLR_MENSALIDADE, WF_VLR_MENSALIDADE);
                _.Move(C01_RESULT.WF_NUM_PROPOSTA, WF_NUM_PROPOSTA);
                _.Move(C01_RESULT.WF_NUM_MOD_PLANO, WF_NUM_MOD_PLANO);
                _.Move(C01_RESULT.WF_DES_COMBINACAO, WF_DES_COMBINACAO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/

        [StopWatch]
        /*" R9160-FECHAR-CURSOR-SECTION */
        private void R9160_FECHAR_CURSOR_SECTION()
        {
            /*" -743- PERFORM R9160_FECHAR_CURSOR_DB_CLOSE_1 */

            R9160_FECHAR_CURSOR_DB_CLOSE_1();

            /*" -747- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -748- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -750- DISPLAY 'R9160 - ERRO NO CLOSE DO CURSOR <C01-RESULT> ' 'SQLCODE <' WS-SQLCODE '>' */

                $"R9160 - ERRO NO CLOSE DO CURSOR <C01-RESULT> SQLCODE <{WS_SQLCODE}>"
                .Display();

                /*" -751- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -751- END-IF. */
            }


        }

        [StopWatch]
        /*" R9160-FECHAR-CURSOR-DB-CLOSE-1 */
        public void R9160_FECHAR_CURSOR_DB_CLOSE_1()
        {
            /*" -743- EXEC SQL CLOSE C01-RESULT END-EXEC */

            C01_RESULT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9160_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -765- MOVE 'R1000' TO ABEND-COD-PROCESSO. */
            _.Move("R1000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -768- IF WF-COD-STA-TITULO EQUAL 'ATV' OR (WF-COD-STA-TITULO EQUAL 'EMT' AND WF-COD-SUB-STATUS EQUAL 'RSV' ) */

            if (WF_COD_STA_TITULO == "ATV" || (WF_COD_STA_TITULO == "EMT" && WF_COD_SUB_STATUS == "RSV"))
            {

                /*" -769- PERFORM R1400-00-UPDATE-TITFEDCA THRU R1400-99-SAIDA */

                R1400_00_UPDATE_TITFEDCA_SECTION();

                R1400_10_UPDATE();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/


                /*" -770- IF WS-TITFEDCA EQUAL 'N' */

                if (WS_TITFEDCA == "N")
                {

                    /*" -771- PERFORM R1100-00-INSERT-MOVFEDCA THRU R1100-99-SAIDA */

                    R1100_00_INSERT_MOVFEDCA_SECTION();

                    R1100_10_INSERT();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/


                    /*" -772- PERFORM R1200-00-INSERT-TITFEDCA THRU R1200-99-SAIDA */

                    R1200_00_INSERT_TITFEDCA_SECTION();

                    R1200_10_INSERT();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/


                    /*" -773- PERFORM R1300-00-INSERT-PARFEDCA THRU R1300-99-SAIDA */

                    R1300_00_INSERT_PARFEDCA_SECTION();

                    R1300_10_INSERT();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/


                    /*" -775- END-IF */
                }


                /*" -776- GO TO R1000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;

                /*" -778- END-IF. */
            }


            /*" -780- PERFORM R1010-00-SELECT-TITFEDCA THRU R1010-99-SAIDA. */

            R1010_00_SELECT_TITFEDCA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/


            /*" -782- IF WTEM-TITFEDCA EQUAL 'SIM' */

            if (WTEM_TITFEDCA == "SIM")
            {

                /*" -783- GO TO R1000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;

                /*" -785- END-IF. */
            }


            /*" -787- PERFORM R1100-00-INSERT-MOVFEDCA THRU R1100-99-SAIDA. */

            R1100_00_INSERT_MOVFEDCA_SECTION();

            R1100_10_INSERT();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/


            /*" -789- PERFORM R1200-00-INSERT-TITFEDCA THRU R1200-99-SAIDA. */

            R1200_00_INSERT_TITFEDCA_SECTION();

            R1200_10_INSERT();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/


            /*" -789- PERFORM R1300-00-INSERT-PARFEDCA THRU R1300-99-SAIDA. */

            R1300_00_INSERT_PARFEDCA_SECTION();

            R1300_10_INSERT();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SELECT-TITFEDCA-SECTION */
        private void R1010_00_SELECT_TITFEDCA_SECTION()
        {
            /*" -803- MOVE 'R1010' TO ABEND-COD-PROCESSO. */
            _.Move("R1010", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -804- MOVE 'SIM' TO WTEM-TITFEDCA */
            _.Move("SIM", WTEM_TITFEDCA);

            /*" -805- MOVE WS-NUM-PROPOSTA TO MOVFEDCA-NUM-PROPOSTA */
            _.Move(WS_NUM_PROPOSTA, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NUM_PROPOSTA);

            /*" -812- PERFORM R1010_00_SELECT_TITFEDCA_DB_SELECT_1 */

            R1010_00_SELECT_TITFEDCA_DB_SELECT_1();

            /*" -815- IF SQLCODE NOT EQUAL ZEROS AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -816- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -817- MOVE 'NAO' TO WTEM-TITFEDCA */
                    _.Move("NAO", WTEM_TITFEDCA);

                    /*" -818- ELSE */
                }
                else
                {


                    /*" -820- MOVE 'VG0716S - ERRO INSERT    - TITFEDCA' TO VG0716S-DES-MENSAGEM */
                    _.Move("VG0716S - ERRO INSERT    - TITFEDCA", VG0716S_DES_MENSAGEM);

                    /*" -821- MOVE SQLCODE TO VG0716S-SQLCODE */
                    _.Move(DB.SQLCODE, VG0716S_SQLCODE);

                    /*" -822- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -823- END-IF */
                }


                /*" -824- END-IF. */
            }


        }

        [StopWatch]
        /*" R1010-00-SELECT-TITFEDCA-DB-SELECT-1 */
        public void R1010_00_SELECT_TITFEDCA_DB_SELECT_1()
        {
            /*" -812- EXEC SQL SELECT NRTITFDCAP INTO :MOVFEDCA-NRTITFDCAP FROM SEGUROS.TITULOS_FED_CAP_VA WHERE NUM_CERTIFICADO = :MOVFEDCA-NUM-PROPOSTA AND DATA_INIVIGENCIA = '0001-01-01' END-EXEC. */

            var r1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1 = new R1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1()
            {
                MOVFEDCA_NUM_PROPOSTA = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NUM_PROPOSTA.ToString(),
            };

            var executed_1 = R1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1.Execute(r1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVFEDCA_NRTITFDCAP, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-INSERT-MOVFEDCA-SECTION */
        private void R1100_00_INSERT_MOVFEDCA_SECTION()
        {
            /*" -835- MOVE 'R1100' TO ABEND-COD-PROCESSO. */
            _.Move("R1100", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -839- MOVE WF-NUM-PLANO TO WS-NUM-PLANO */
            _.Move(WF_NUM_PLANO, WS_NUM_TITULO_X.WS_NUM_PLANO);

            /*" -843- MOVE WF-NUM-SERIE TO WS-NUM-SERIE */
            _.Move(WF_NUM_SERIE, WS_NUM_TITULO_X.WS_NUM_SERIE);

            /*" -849- MOVE WF-NUM-TITULO TO WS-NUM-TITULO MOVFEDCA-NUM-SEQUENCIA */
            _.Move(WF_NUM_TITULO, WS_NUM_TITULO_X.WS_NUM_TITULO, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NUM_SEQUENCIA);

            /*" -851- IF WF-NUM-PLANO EQUAL 818 OR 858 */

            if (WF_NUM_PLANO.In("818", "858"))
            {

                /*" -852- IF WF-NUM-TITULO GREATER 999999 */

                if (WF_NUM_TITULO > 999999)
                {

                    /*" -853- MOVE ZEROS TO WS-QTD */
                    _.Move(0, WS_QTD);

                    /*" -855- ADD 100 TO WS-NUM-SERIE WS-QTD */
                    WS_NUM_TITULO_X.WS_NUM_SERIE.Value = WS_NUM_TITULO_X.WS_NUM_SERIE + 100;
                    WS_QTD.Value = WS_QTD + 100;

                    /*" -856- PERFORM R1150-00-SELECT-TITFEDCA */

                    R1150_00_SELECT_TITFEDCA_SECTION();

                    /*" -857- END-IF */
                }


                /*" -859- END-IF. */
            }


            /*" -863- MOVE WS-NUM-TITULO-9 TO MOVFEDCA-NRTITFDCAP. */
            _.Move(WS_NUM_TITULO_9, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP);

            /*" -866- MOVE WF-VLR-MENSALIDADE TO MOVFEDCA-VAL-CUSTO-CAPITALI. */
            _.Move(WF_VLR_MENSALIDADE, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_VAL_CUSTO_CAPITALI);

            /*" -869- MOVE VG0716S-COD-FONTE TO FONTES-COD-FONTE. */
            _.Move(VG0716S_COD_FONTE, FONTES_COD_FONTE);

            /*" -872- MOVE VG0716S-COD-PRODUTO TO PRODUVG-COD-PRODUTO. */
            _.Move(VG0716S_COD_PRODUTO, PRODUVG_COD_PRODUTO);

            /*" -873- MOVE WS-NUM-PROPOSTA TO MOVFEDCA-NUM-CERTIFICADO. */
            _.Move(WS_NUM_PROPOSTA, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NUM_CERTIFICADO);

            /*" -0- FLUXCONTROL_PERFORM R1100_10_INSERT */

            R1100_10_INSERT();

        }

        [StopWatch]
        /*" R1100-10-INSERT */
        private void R1100_10_INSERT(bool isPerform = false)
        {
            /*" -910- PERFORM R1100_10_INSERT_DB_INSERT_1 */

            R1100_10_INSERT_DB_INSERT_1();

            /*" -913- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -915- MOVE 'VG0716S - ERRO INSERT    - MOVFEDCA' TO VG0716S-DES-MENSAGEM */
                _.Move("VG0716S - ERRO INSERT    - MOVFEDCA", VG0716S_DES_MENSAGEM);

                /*" -916- MOVE SQLCODE TO VG0716S-SQLCODE */
                _.Move(DB.SQLCODE, VG0716S_SQLCODE);

                /*" -917- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -917- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-10-INSERT-DB-INSERT-1 */
        public void R1100_10_INSERT_DB_INSERT_1()
        {
            /*" -910- EXEC SQL INSERT INTO SEGUROS.MOVIMEN_FED_CAP_VA ( NUM_CERTIFICADO , COD_OPERACAO , COD_FONTE , NUM_PROPOSTA , DTMVFDCAP , NUM_PARCELA , QUANT_TIT_CAPITALI , VAL_CUSTO_CAPITALI , SITUACAO , NRTITFDCAP , NRMSCAP , NUM_SEQUENCIA , TIMESTAMP , CODPRODU ) VALUES ( :MOVFEDCA-NUM-CERTIFICADO , 1 , :FONTES-COD-FONTE , 0 , :SISTEMAS-DATA-MOV-ABERTO , 0 , 1 , :MOVFEDCA-VAL-CUSTO-CAPITALI , '1' , :MOVFEDCA-NRTITFDCAP , 0 , :MOVFEDCA-NUM-SEQUENCIA , CURRENT TIMESTAMP , :PRODUVG-COD-PRODUTO ) END-EXEC. */

            var r1100_10_INSERT_DB_INSERT_1_Insert1 = new R1100_10_INSERT_DB_INSERT_1_Insert1()
            {
                MOVFEDCA_NUM_CERTIFICADO = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NUM_CERTIFICADO.ToString(),
                FONTES_COD_FONTE = FONTES_COD_FONTE.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                MOVFEDCA_VAL_CUSTO_CAPITALI = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_VAL_CUSTO_CAPITALI.ToString(),
                MOVFEDCA_NRTITFDCAP = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.ToString(),
                MOVFEDCA_NUM_SEQUENCIA = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NUM_SEQUENCIA.ToString(),
                PRODUVG_COD_PRODUTO = PRODUVG_COD_PRODUTO.ToString(),
            };

            R1100_10_INSERT_DB_INSERT_1_Insert1.Execute(r1100_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-SELECT-TITFEDCA-SECTION */
        private void R1150_00_SELECT_TITFEDCA_SECTION()
        {
            /*" -927- MOVE 'R1150' TO ABEND-COD-PROCESSO. */
            _.Move("R1150", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -929- MOVE WS-NUM-TITULO-9 TO TITFEDCA-NRTITFDCAP. */
            _.Move(WS_NUM_TITULO_9, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRTITFDCAP);

            /*" -931- MOVE WS-NUM-PROPOSTA TO WS-NUM-PROPOSTA-D. */
            _.Move(WS_NUM_PROPOSTA, WS_NUM_PROPOSTA_D);

            /*" -938- PERFORM R1150_00_SELECT_TITFEDCA_DB_SELECT_1 */

            R1150_00_SELECT_TITFEDCA_DB_SELECT_1();

            /*" -941- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -944- ADD 100 TO WS-NUM-SERIE WS-QTD */
                WS_NUM_TITULO_X.WS_NUM_SERIE.Value = WS_NUM_TITULO_X.WS_NUM_SERIE + 100;
                WS_QTD.Value = WS_QTD + 100;

                /*" -945- IF WS-QTD > 4999 */

                if (WS_QTD > 4999)
                {

                    /*" -946- PERFORM R1151-00-TRATA-DISPLAY */

                    R1151_00_TRATA_DISPLAY_SECTION();

                    /*" -947- GO TO R1150-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/ //GOTO
                    return;

                    /*" -948- ELSE */
                }
                else
                {


                    /*" -949- GO TO R1150-00-SELECT-TITFEDCA */
                    new Task(() => R1150_00_SELECT_TITFEDCA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -950- END-IF */
                }


                /*" -951- ELSE */
            }
            else
            {


                /*" -953- MOVE ZEROS TO WS-QTD */
                _.Move(0, WS_QTD);

                /*" -954- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -955- GO TO R1150-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/ //GOTO
                    return;

                    /*" -956- ELSE */
                }
                else
                {


                    /*" -958- MOVE 'VG0716S - ERRO SELECT    - TITFEDCA' TO VG0716S-DES-MENSAGEM */
                    _.Move("VG0716S - ERRO SELECT    - TITFEDCA", VG0716S_DES_MENSAGEM);

                    /*" -959- MOVE SQLCODE TO VG0716S-SQLCODE */
                    _.Move(DB.SQLCODE, VG0716S_SQLCODE);

                    /*" -960- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -961- END-IF */
                }


                /*" -962- END-IF. */
            }


        }

        [StopWatch]
        /*" R1150-00-SELECT-TITFEDCA-DB-SELECT-1 */
        public void R1150_00_SELECT_TITFEDCA_DB_SELECT_1()
        {
            /*" -938- EXEC SQL SELECT NUM_CERTIFICADO INTO :TITFEDCA-NUM-CERTIFICADO FROM SEGUROS.TITULOS_FED_CAP_VA WHERE NRTITFDCAP = :TITFEDCA-NRTITFDCAP END-EXEC. */

            var r1150_00_SELECT_TITFEDCA_DB_SELECT_1_Query1 = new R1150_00_SELECT_TITFEDCA_DB_SELECT_1_Query1()
            {
                TITFEDCA_NRTITFDCAP = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRTITFDCAP.ToString(),
            };

            var executed_1 = R1150_00_SELECT_TITFEDCA_DB_SELECT_1_Query1.Execute(r1150_00_SELECT_TITFEDCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TITFEDCA_NUM_CERTIFICADO, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NUM_CERTIFICADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1151-00-TRATA-DISPLAY-SECTION */
        private void R1151_00_TRATA_DISPLAY_SECTION()
        {
            /*" -969- MOVE 'R1151' TO ABEND-COD-PROCESSO. */
            _.Move("R1151", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -975- IF VG0716S-DES-COMBINACAO = 'VP0195B' OR VG0716S-DES-COMBINACAO = 'VE0422B' OR VG0716S-DES-COMBINACAO = 'VA0422B' OR VG0716S-DES-COMBINACAO = 'VA2422B' NEXT SENTENCE */

            if (VG0716S_DES_COMBINACAO == "VP0195B" || VG0716S_DES_COMBINACAO == "VE0422B" || VG0716S_DES_COMBINACAO == "VA0422B" || VG0716S_DES_COMBINACAO == "VA2422B")
            {

                /*" -978- ELSE */
            }
            else
            {


                /*" -983- STRING 'VG0716S-NAO ENC. SERIE P/ALOCAR O TIT.<' WS-NUM-TITULO-9 '> <' WS-NUM-PROPOSTA-D '>' DELIMITED BY SIZE INTO VG0716S-DES-MENSAGEM END-STRING */
                #region STRING
                var spl4 = "VG0716S-NAO ENC. SERIE P/ALOCAR O TIT.<" + WS_NUM_TITULO_9.GetMoveValues();
                spl4 += "> <";
                var spl5 = WS_NUM_PROPOSTA_D.GetMoveValues();
                spl5 += ">";
                var results6 = spl4 + spl5;
                _.Move(results6, VG0716S_DES_MENSAGEM);
                #endregion

                /*" -984- DISPLAY VG0716S-DES-MENSAGEM */
                _.Display(VG0716S_DES_MENSAGEM);

                /*" -984- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1151_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-INSERT-TITFEDCA-SECTION */
        private void R1200_00_INSERT_TITFEDCA_SECTION()
        {
            /*" -996- MOVE 'R1100' TO ABEND-COD-PROCESSO. */
            _.Move("R1100", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1000- MOVE WF-DTH-INI-VIGENCIA TO TITFEDCA-DATA-INIVIGENCIA */
            _.Move(WF_DTH_INI_VIGENCIA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_INIVIGENCIA);

            /*" -1004- MOVE WF-DTH-FIM-VIGENCIA TO TITFEDCA-DATA-TERVIGENCIA */
            _.Move(WF_DTH_FIM_VIGENCIA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_TERVIGENCIA);

            /*" -1007- MOVE WF-DES-COMBINACAO TO WS-COMBINACAO. */
            _.Move(WF_DES_COMBINACAO, WS_COMBINACAO);

            /*" -1010- PERFORM R1210-00-TRATA-COMBINACAO THRU R1210-99-SAIDA. */

            R1210_00_TRATA_COMBINACAO_SECTION();

            R1210_10_LOOP();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/


            /*" -1014- MOVE WS-COMBINACAO-9 TO TITFEDCA-NRSORTEIO. */
            _.Move(WS_COMBINACAO_9, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO);

            /*" -1017- MOVE WF-VLR-MENSALIDADE TO TITFEDCA-VAL-CUSTO-TITULO. */
            _.Move(WF_VLR_MENSALIDADE, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_VAL_CUSTO_TITULO);

            /*" -1018- MOVE WS-NUM-PROPOSTA TO TITFEDCA-NUM-CERTIFICADO. */
            _.Move(WS_NUM_PROPOSTA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NUM_CERTIFICADO);

            /*" -0- FLUXCONTROL_PERFORM R1200_10_INSERT */

            R1200_10_INSERT();

        }

        [StopWatch]
        /*" R1200-10-INSERT */
        private void R1200_10_INSERT(bool isPerform = false)
        {
            /*" -1054- PERFORM R1200_10_INSERT_DB_INSERT_1 */

            R1200_10_INSERT_DB_INSERT_1();

            /*" -1057- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -1059- MOVE 'VG0716S - ERRO INSERT    - TITFEDCA' TO VG0716S-DES-MENSAGEM */
                _.Move("VG0716S - ERRO INSERT    - TITFEDCA", VG0716S_DES_MENSAGEM);

                /*" -1060- MOVE SQLCODE TO VG0716S-SQLCODE */
                _.Move(DB.SQLCODE, VG0716S_SQLCODE);

                /*" -1061- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -1061- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-10-INSERT-DB-INSERT-1 */
        public void R1200_10_INSERT_DB_INSERT_1()
        {
            /*" -1054- EXEC SQL INSERT INTO SEGUROS.TITULOS_FED_CAP_VA ( NRTITFDCAP , NUM_CERTIFICADO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , NRSORTEIO , VAL_CUSTO_TITULO , NRPARCEL , NRMFDCAPF , SITUACAO , SIT_RELAT , DATA_MOVIMENTO , TIMESTAMP , NRMFDCAPR , NRTITREN ) VALUES ( :MOVFEDCA-NRTITFDCAP , :TITFEDCA-NUM-CERTIFICADO , :TITFEDCA-DATA-INIVIGENCIA , :TITFEDCA-DATA-TERVIGENCIA , :TITFEDCA-NRSORTEIO , :TITFEDCA-VAL-CUSTO-TITULO , 0 , 0 , '0' , '1' , :SISTEMAS-DATA-MOV-ABERTO , CURRENT TIMESTAMP , 0 , 0 ) END-EXEC. */

            var r1200_10_INSERT_DB_INSERT_1_Insert1 = new R1200_10_INSERT_DB_INSERT_1_Insert1()
            {
                MOVFEDCA_NRTITFDCAP = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.ToString(),
                TITFEDCA_NUM_CERTIFICADO = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NUM_CERTIFICADO.ToString(),
                TITFEDCA_DATA_INIVIGENCIA = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_INIVIGENCIA.ToString(),
                TITFEDCA_DATA_TERVIGENCIA = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_TERVIGENCIA.ToString(),
                TITFEDCA_NRSORTEIO = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO.ToString(),
                TITFEDCA_VAL_CUSTO_TITULO = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_VAL_CUSTO_TITULO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R1200_10_INSERT_DB_INSERT_1_Insert1.Execute(r1200_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-TRATA-COMBINACAO-SECTION */
        private void R1210_00_TRATA_COMBINACAO_SECTION()
        {
            /*" -1071- MOVE 'R1210' TO ABEND-COD-PROCESSO. */
            _.Move("R1210", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1071- MOVE ZEROS TO WIND. */
            _.Move(0, WIND);

            /*" -0- FLUXCONTROL_PERFORM R1210_10_LOOP */

            R1210_10_LOOP();

        }

        [StopWatch]
        /*" R1210-10-LOOP */
        private void R1210_10_LOOP(bool isPerform = false)
        {
            /*" -1077- ADD 1 TO WIND. */
            WIND.Value = WIND + 1;

            /*" -1078- IF WIND GREATER 20 */

            if (WIND > 20)
            {

                /*" -1080- MOVE 'VG0716S - ERRO TRATA COMBINACAO    ' TO VG0716S-DES-MENSAGEM */
                _.Move("VG0716S - ERRO TRATA COMBINACAO    ", VG0716S_DES_MENSAGEM);

                /*" -1081- MOVE SQLCODE TO VG0716S-SQLCODE */
                _.Move(DB.SQLCODE, VG0716S_SQLCODE);

                /*" -1082- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -1084- END-IF. */
            }


            /*" -1085- IF WS-COMB(WIND) = ' ' */

            if (WS_COMBINACAO_R.WS_COMB[WIND] == " ")
            {

                /*" -1086- SUBTRACT 1 FROM WIND */
                WIND.Value = WIND - 1;

                /*" -1088- MOVE WS-COMBINACAO(1:WIND) TO WS-COMBINACAO-9 */
                _.Move(WS_COMBINACAO.Substring(1, WIND), WS_COMBINACAO_9);

                /*" -1089- ELSE */
            }
            else
            {


                /*" -1089- GO TO R1210-10-LOOP. */
                new Task(() => R1210_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-INSERT-PARFEDCA-SECTION */
        private void R1300_00_INSERT_PARFEDCA_SECTION()
        {
            /*" -1096- MOVE 'R1300' TO ABEND-COD-PROCESSO. */
            _.Move("R1300", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -0- FLUXCONTROL_PERFORM R1300_10_INSERT */

            R1300_10_INSERT();

        }

        [StopWatch]
        /*" R1300-10-INSERT */
        private void R1300_10_INSERT(bool isPerform = false)
        {
            /*" -1105- MOVE WF-VLR-MENSALIDADE TO PARFEDCA-VAL-CUSTO-TITULO. */
            _.Move(WF_VLR_MENSALIDADE, PARFEDCA.DCLPARCEL_FED_CAP_VA.PARFEDCA_VAL_CUSTO_TITULO);

            /*" -1124- PERFORM R1300_10_INSERT_DB_INSERT_1 */

            R1300_10_INSERT_DB_INSERT_1();

            /*" -1127- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -1129- MOVE 'VG0716S - ERRO INSERT    - PARFEDCA' TO VG0716S-DES-MENSAGEM */
                _.Move("VG0716S - ERRO INSERT    - PARFEDCA", VG0716S_DES_MENSAGEM);

                /*" -1130- MOVE SQLCODE TO VG0716S-SQLCODE */
                _.Move(DB.SQLCODE, VG0716S_SQLCODE);

                /*" -1131- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -1131- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-10-INSERT-DB-INSERT-1 */
        public void R1300_10_INSERT_DB_INSERT_1()
        {
            /*" -1124- EXEC SQL INSERT INTO SEGUROS.PARCEL_FED_CAP_VA ( NRTITFDCAP , NUM_PARCELA , VAL_CUSTO_TITULO , DTFATUR , DATA_MOVIMENTO , SITUACAO , NRMFDCAP , TIMESTAMP ) VALUES ( :MOVFEDCA-NRTITFDCAP , 0 , :PARFEDCA-VAL-CUSTO-TITULO , :SISTEMAS-DATA-MOV-ABERTO , :SISTEMAS-DATA-MOV-ABERTO , '1' , 0 , CURRENT TIMESTAMP ) END-EXEC. */

            var r1300_10_INSERT_DB_INSERT_1_Insert1 = new R1300_10_INSERT_DB_INSERT_1_Insert1()
            {
                MOVFEDCA_NRTITFDCAP = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.ToString(),
                PARFEDCA_VAL_CUSTO_TITULO = PARFEDCA.DCLPARCEL_FED_CAP_VA.PARFEDCA_VAL_CUSTO_TITULO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R1300_10_INSERT_DB_INSERT_1_Insert1.Execute(r1300_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-UPDATE-TITFEDCA-SECTION */
        private void R1400_00_UPDATE_TITFEDCA_SECTION()
        {
            /*" -1141- MOVE 'R1400' TO ABEND-COD-PROCESSO. */
            _.Move("R1400", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1144- MOVE 'S' TO WS-TITFEDCA. */
            _.Move("S", WS_TITFEDCA);

            /*" -1148- MOVE WF-NUM-PLANO TO WS-NUM-PLANO */
            _.Move(WF_NUM_PLANO, WS_NUM_TITULO_X.WS_NUM_PLANO);

            /*" -1152- MOVE WF-NUM-SERIE TO WS-NUM-SERIE */
            _.Move(WF_NUM_SERIE, WS_NUM_TITULO_X.WS_NUM_SERIE);

            /*" -1155- MOVE WF-NUM-TITULO TO WS-NUM-TITULO */
            _.Move(WF_NUM_TITULO, WS_NUM_TITULO_X.WS_NUM_TITULO);

            /*" -1159- MOVE WS-NUM-TITULO-9 TO MOVFEDCA-NRTITFDCAP. */
            _.Move(WS_NUM_TITULO_9, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP);

            /*" -1163- MOVE WF-DTH-INI-VIGENCIA TO TITFEDCA-DATA-INIVIGENCIA */
            _.Move(WF_DTH_INI_VIGENCIA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_INIVIGENCIA);

            /*" -1166- MOVE WF-DTH-FIM-VIGENCIA TO TITFEDCA-DATA-TERVIGENCIA. */
            _.Move(WF_DTH_FIM_VIGENCIA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_TERVIGENCIA);

            /*" -1167- MOVE WS-NUM-PROPOSTA TO TITFEDCA-NUM-CERTIFICADO. */
            _.Move(WS_NUM_PROPOSTA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NUM_CERTIFICADO);

            /*" -0- FLUXCONTROL_PERFORM R1400_10_UPDATE */

            R1400_10_UPDATE();

        }

        [StopWatch]
        /*" R1400-10-UPDATE */
        private void R1400_10_UPDATE(bool isPerform = false)
        {
            /*" -1180- PERFORM R1400_10_UPDATE_DB_UPDATE_1 */

            R1400_10_UPDATE_DB_UPDATE_1();

            /*" -1185- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1188- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1190- IF WF-NUM-PLANO EQUAL 858 AND WS-TITFEDCA EQUAL 'S' */

                    if (WF_NUM_PLANO == 858 && WS_TITFEDCA == "S")
                    {

                        /*" -1192- ADD 100 TO WS-NUM-SERIE */
                        WS_NUM_TITULO_X.WS_NUM_SERIE.Value = WS_NUM_TITULO_X.WS_NUM_SERIE + 100;

                        /*" -1193- MOVE WF-NUM-TITULO TO WS-NUM-TITULO */
                        _.Move(WF_NUM_TITULO, WS_NUM_TITULO_X.WS_NUM_TITULO);

                        /*" -1194- MOVE WS-NUM-TITULO-9 TO MOVFEDCA-NRTITFDCAP */
                        _.Move(WS_NUM_TITULO_9, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP);

                        /*" -1195- MOVE 'N' TO WS-TITFEDCA */
                        _.Move("N", WS_TITFEDCA);

                        /*" -1196- GO TO R1400-10-UPDATE */
                        new Task(() => R1400_10_UPDATE()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1197- END-IF */
                    }


                    /*" -1198- MOVE 'N' TO WS-TITFEDCA */
                    _.Move("N", WS_TITFEDCA);

                    /*" -1199- GO TO R1400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/ //GOTO
                    return;

                    /*" -1200- ELSE */
                }
                else
                {


                    /*" -1201- MOVE 01 TO VG0716S-COD-RETORNO */
                    _.Move(01, VG0716S_COD_RETORNO);

                    /*" -1203- MOVE 'VG0716S - ERRO UPDATE    - TITFEDCA' TO VG0716S-DES-MENSAGEM */
                    _.Move("VG0716S - ERRO UPDATE    - TITFEDCA", VG0716S_DES_MENSAGEM);

                    /*" -1204- MOVE SQLCODE TO VG0716S-SQLCODE */
                    _.Move(DB.SQLCODE, VG0716S_SQLCODE);

                    /*" -1205- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -1206- END-IF */
                }


                /*" -1208- END-IF. */
            }


            /*" -1208- MOVE 'S' TO WS-TITFEDCA. */
            _.Move("S", WS_TITFEDCA);

        }

        [StopWatch]
        /*" R1400-10-UPDATE-DB-UPDATE-1 */
        public void R1400_10_UPDATE_DB_UPDATE_1()
        {
            /*" -1180- EXEC SQL UPDATE SEGUROS.TITULOS_FED_CAP_VA SET DATA_INIVIGENCIA = :TITFEDCA-DATA-INIVIGENCIA, DATA_TERVIGENCIA = :TITFEDCA-DATA-TERVIGENCIA WHERE NRTITFDCAP = :MOVFEDCA-NRTITFDCAP AND NUM_CERTIFICADO = :TITFEDCA-NUM-CERTIFICADO AND DATA_INIVIGENCIA = '0001-01-01' END-EXEC. */

            var r1400_10_UPDATE_DB_UPDATE_1_Update1 = new R1400_10_UPDATE_DB_UPDATE_1_Update1()
            {
                TITFEDCA_DATA_INIVIGENCIA = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_INIVIGENCIA.ToString(),
                TITFEDCA_DATA_TERVIGENCIA = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_TERVIGENCIA.ToString(),
                TITFEDCA_NUM_CERTIFICADO = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NUM_CERTIFICADO.ToString(),
                MOVFEDCA_NRTITFDCAP = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.ToString(),
            };

            R1400_10_UPDATE_DB_UPDATE_1_Update1.Execute(r1400_10_UPDATE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1216- MOVE 'R9999' TO ABEND-COD-PROCESSO. */
            _.Move("R9999", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -1226- DISPLAY 'VERSAO V.14 - Cadmus 179924: ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(03:2) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"VERSAO V.14 - Cadmus 179924: FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(3, 2)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1227- DISPLAY 'ABEND-COD-PROCESSO < ' ABEND-COD-PROCESSO '>' */

            $"ABEND-COD-PROCESSO < {ABEND.DCLABEND.ABEND_COD_PROCESSO}>"
            .Display();

            /*" -1228- DISPLAY 'MENSAGEM <' VG0716S-DES-MENSAGEM '>' */

            $"MENSAGEM <{VG0716S_DES_MENSAGEM}>"
            .Display();

            /*" -1229- DISPLAY 'COD-RET  <' VG0716S-COD-RETORNO '>' */

            $"COD-RET  <{VG0716S_COD_RETORNO}>"
            .Display();

            /*" -1230- DISPLAY 'SQLCODE SPBFC012  <' LK-OUT-SQLCODE-FC12 '>' */

            $"SQLCODE SPBFC012  <{LK_OUT_SQLCODE_FC12}>"
            .Display();

            /*" -1231- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -1232- DISPLAY 'SQLCODE  <' WS-SQLCODE '>' */

            $"SQLCODE  <{WS_SQLCODE}>"
            .Display();

            /*" -1233- DISPLAY 'SQLERRMC <' SQLERRMC '>' */

            $"SQLERRMC <{DB.SQLERRMC}>"
            .Display();

            /*" -1233- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1234- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}