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
using Sias.Cosseguro.DB2.AC0816B;

namespace Code
{
    public class AC0816B
    {
        public bool IsCall { get; set; }

        public AC0816B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0816B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CARLOS ALBERTO                     *      */
        /*"      *   PROGRAMADOR ............  CARLOS ALBERTO                     *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO / 1998                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CONFORME SOLICITACAO DE LIBERACAO  *      */
        /*"      *                             DE PAGAMENTO AS CONGENERES PARTI-  *      */
        /*"      *                             CIPANTES DE COSSEGURO, ESTE PROGRA-*      */
        /*"      *                             MA PROCESSA A RECUPERACAO OU DEVO- *      */
        /*"      *                             LUCAO DE SINISTROS PAGOS, RESSARCI-*      */
        /*"      *                             MENTOS E SALVADOS.                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V0SISTEMA         INPUT    *      */
        /*"      * RELATORIOS                          V0RELATORIOS      INPUT    *      */
        /*"      * COTACAO DE MOEDAS                   V0COTACAO         INPUT    *      */
        /*"      * HISTORICO DE COSSEGURO (SINISTRO)   V1COSSEG-HISTSIN  I-O      *      */
        /*"      * SINISTRO MESTRE                     V0MESTSINI        INPUT    *      */
        /*"      * APOLICES                            V0APOLICE         INPUT    *      */
        /*"      * HISTORICO DE SINISTROS              V0HISTSINI        INPUT    *      */
        /*"      * SISTEMAS OPERACOES                  GEOPERAC          INPUT    *      */
        /*"      * SISTEMAS FUNCOES OPERACOES          GESISFUO          INPUT    *      */
        /*"      * SISTEMAS FUNCOES OPERACOES RELAC    GESISORL          INPUT    *      */
        /*"      * CHEQUES DE COSSEGURO CEDIDO         V0COSCED-CHEQUE   OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 21/01/2000 - CARLOS ALBERTO DE A ALVES            *      */
        /*"      * LANCAR A CREDITO O SALDO DOS SINISTROS PAGOS/ESTORNADOS,DAS    *      */
        /*"      * APOLICES: 106600000001 E 66001000001, COMO FORMA DE ESTORNO    *      */
        /*"      * DESTE VALOR, DEVIDO AO ENCONTRO DE CONTAS QUE E' FEITO FORA    *      */
        /*"      * DO SISTEMA.                                                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PRODEXTER - 14/06/2005 - SUBSTITUICAO DA PARAMETR_OPER_SINI    *      */
        /*"      *                          PELA GE_OPERACAO, GE_SIS_FUNCAO_OPER  *      */
        /*"      *                          E GE_SIS_FUN_OPE_REL                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PRODEXTER - 04/07/2005 - ACERTO DA CONDICAO PARA O ACESSO      *      */
        /*"      *                          DA GE_SIS_FUN_OPE_REL (R1200)         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * GILSON    - 06/10/2006 - CALCULO DO VALOR A SER DEBITADO DA    *      */
        /*"      *                          CIA MAPFRE SOBRE OS 100% DOS VALORES  *      */
        /*"      *                          DA VENDA, E ESTORNO DE SALVADOS DO    *      */
        /*"      *                          CONVENIO AUTO VC - RUNON              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  26/08/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *    INCLUSAO DA CLAUSULA WITH UR NO COMANDO SELECT   - WV0808   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM JUN/2011 POR GILSON PINTO DA SILVA - PROCURAR GP0611       *      */
        /*"      *  - ALTERACAO PARA TRATAR O NOVO CONVENIO AUTO SAS - ORGAO 110  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM JAN/2013 POR GILSON PINTO DA SILVA - PROCURAR C78128       *      */
        /*"      *  - ALTERACAO PARA TRATAR O SINISTRO COM RESSARCIMENTO PARA     *      */
        /*"      *    TODOS OS CONVENIOS E CIAS CONGENERES.                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - TRATAR OS SINISTROS COM COSSEGURO CEDIDO NO SIAS  *      */
        /*"      *              PERTENCENTES AS APOLICES/CONTRATOS DO SMART       *      */
        /*"      * 18/10/2018 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 175359 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - ALTERAR O PROGRAMA PARA TRATAR/GERAR A LIBERACAO  *      */
        /*"      *              DE PAGAMENTO POR EMPRESA DO GRUPO CAIXA SEGUROS   *      */
        /*"      * 28/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - ALTERAR O PROGRAMA PARA TRATAR A CIA ALLIANZ 1015 *      */
        /*"      *              IGUAL AO CONVENIO AUTO DA SULAMERICA 5118         *      */
        /*"      * 20/01/2020 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 230909 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77       VIND-SIT-REGT          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_SIT_REGT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-TIP-SEGR          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TIP_SEGR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-SIT-LIBR          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_SIT_LIBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       WHOST-DTMOVTO          PIC  X(010)      VALUE SPACES.*/
        public StringBasis WHOST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77       WHOST-OPER-COR         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_OPER_COR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       WHOST-OP-COR-PEND      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_OP_COR_PEND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       WHOST-VAL-CORR         PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WHOST_VAL_CORR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77       WHOST-VAL-COR-PEND     PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WHOST_VAL_COR_PEND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77       WHOST-VAL-OPER-IX      PIC S9(010)V9(5) VALUE +0 COMP-3*/
        public DoubleBasis WHOST_VAL_OPER_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77       WHOST-OUTRDEBIT        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WHOST_OUTRDEBIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77       WHOST-OUTRCREDT        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis WHOST_OUTRCREDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77       V0SIST-DTMOVABE        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77       V0RELA-COD-USU         PIC  X(008)      VALUE SPACES.*/
        public StringBasis V0RELA_COD_USU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77       V0RELA-DATA-SOL        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0RELA_DATA_SOL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77       V0RELA-IDSISTEM        PIC  X(002)      VALUE SPACES.*/
        public StringBasis V0RELA_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"77       V0RELA-CODRELAT        PIC  X(008)      VALUE SPACES.*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77       V0RELA-PERI-INI        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0RELA_PERI_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77       V0RELA-PERI-FIN        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0RELA_PERI_FIN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77       V0RELA-DATA-REF        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0RELA_DATA_REF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77       V0RELA-CONGENER        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0RELA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       V0RELA-CODUNIMO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0RELA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       V0RELA-CORRECAO        PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0RELA_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77       V0RELA-COD-EMPR        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0RELA_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77       V0COTA-CODUNIMO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COTA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       V0COTA-DTINIVIG        PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0COTA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77       V0COTA-VAL-VENDA       PIC S9(006)V9(9) VALUE +0 COMP-3*/
        public DoubleBasis V0COTA_VAL_VENDA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77       V1CHSI-COD-EMPR        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1CHSI_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77       V1CHSI-CONGENER        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1CHSI_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       V1CHSI-NUM-SINI        PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V1CHSI_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77       V1CHSI-OCORHIST        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1CHSI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       V1CHSI-OPERACAO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1CHSI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       V1CHSI-DTMOVTO         PIC  X(010)      VALUE SPACES.*/
        public StringBasis V1CHSI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77       V1CHSI-VAL-OPER        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V1CHSI_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77       V1CHSI-TIPSGU          PIC  X(001)      VALUE SPACES.*/
        public StringBasis V1CHSI_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77       V1CHSI-SITUACAO        PIC  X(001)      VALUE SPACES.*/
        public StringBasis V1CHSI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77       V1CHSI-SIT-LIBREC      PIC  X(001)      VALUE SPACES.*/
        public StringBasis V1CHSI_SIT_LIBREC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77       V0CHSI-OPERACAO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CHSI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       V0CHSI-VAL-OPER        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0CHSI_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77       V0MSIN-NUM-SINISTRO    PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0MSIN_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77       V0MSIN-MOEDA-SINI      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0MSIN_MOEDA_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       V0MSIN-NUM-APOL        PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0MSIN_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77       V0APOL-NUM-APOL        PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0APOL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77       V0APOL-TIPSGU          PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0APOL_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77       V0APOL-ORGAO           PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       V0APOL-RAMO            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       V0HSIN-NUM-SINI        PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0HSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77       V0HSIN-OCORHIST        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HSIN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       V0HSIN-DTMOVTO         PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HSIN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77       V0HSIN-OPERACAO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HSIN_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       V0HSIN-VAL-OPER        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0HSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77       V0CCHQ-COD-EMPR        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0CCHQ_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77       V0CCHQ-CONGENER        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CCHQ_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       V0CCHQ-VLRSINI         PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0CCHQ_VLRSINI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77       V0CCHQ-VLDESPESA       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0CCHQ_VLDESPESA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77       V0CCHQ-VLRHONOR        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0CCHQ_VLRHONOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77       V0CCHQ-VLRSALVD        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0CCHQ_VLRSALVD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77       V0CCHQ-VLRESSARC       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0CCHQ_VLRESSARC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77       V0CCHQ-OUTRDEBIT       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0CCHQ_OUTRDEBIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77       V0CCHQ-OUTRCREDT       PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0CCHQ_OUTRCREDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01       AREA-DE-WORK.*/
        public AC0816B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0816B_AREA_DE_WORK();
        public class AC0816B_AREA_DE_WORK : VarBasis
        {
            /*"  05     WFIM-V0RELATORIOS      PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05     WFIM-V1COSHISTSIN      PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_V1COSHISTSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05     AC-L-V1COSHISTSIN      PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_V1COSHISTSIN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05     AC-I-V0COSHISTSIN      PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_I_V0COSHISTSIN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05     AC-U-V0COSHISTSIN      PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_U_V0COSHISTSIN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05     WCOD-EMPR-ANT          PIC S9(009)      VALUE +0 COMP.*/
            public IntBasis WCOD_EMPR_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05     WNUM-SINI-ANT          PIC S9(013)      VALUE +0 COMP-3*/
            public IntBasis WNUM_SINI_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05     WS-OP-CM-PEND          PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis WS_OP_CM_PEND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     WS-OP-CM-LIB           PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis WS_OP_CM_LIB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05     WCOTACAO-SOLIC         PIC S9(006)V9(9) VALUE +0 COMP-3*/
            public DoubleBasis WCOTACAO_SOLIC { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
            /*"  05     WCOTACAO-SOL-INDX      PIC S9(006)V9(9) VALUE +0 COMP-3*/
            public DoubleBasis WCOTACAO_SOL_INDX { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
            /*"  05     WCOTACAO-SINI          PIC S9(006)V9(9) VALUE +0 COMP-3*/
            public DoubleBasis WCOTACAO_SINI { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
            /*"  05     AC-VLRSINI             PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis AC_VLRSINI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05     AC-VLDESPESA           PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis AC_VLDESPESA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05     AC-VLRHONOR            PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis AC_VLRHONOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05     AC-VLRSALVD            PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis AC_VLRSALVD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05     AC-VLRESSARC           PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis AC_VLRESSARC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05     AC-SINI-DEBITO         PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis AC_SINI_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05     AC-SINI-CREDITO        PIC S9(013)V99   VALUE +0 COMP-3*/
            public DoubleBasis AC_SINI_CREDITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01       WABEND.*/
        }
        public AC0816B_WABEND WABEND { get; set; } = new AC0816B_WABEND();
        public class AC0816B_WABEND : VarBasis
        {
            /*"  05     FILLER                 PIC  X(010)      VALUE        ' AC0816B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AC0816B");
            /*"  05     FILLER                 PIC  X(026)      VALUE        ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL           PIC  X(004)      VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05     FILLER                 PIC  X(013)      VALUE        ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05     WSQLCODE               PIC  ZZZZZ999-   VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public Dclgens.GESISORL GESISORL { get; set; } = new Dclgens.GESISORL();
        public Dclgens.SX010 SX010 { get; set; } = new Dclgens.SX010();
        public Dclgens.SX011 SX011 { get; set; } = new Dclgens.SX011();
        public Dclgens.SX017 SX017 { get; set; } = new Dclgens.SX017();
        public AC0816B_V0RELATORIOS V0RELATORIOS { get; set; } = new AC0816B_V0RELATORIOS();
        public AC0816B_V1COSHISTSIN V1COSHISTSIN { get; set; } = new AC0816B_V1COSHISTSIN();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -288- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -289- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -292- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -295- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -299- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -301- PERFORM R0200-00-DECLARE-V0RELATORIOS. */

            R0200_00_DECLARE_V0RELATORIOS_SECTION();

            /*" -303- PERFORM R0250-00-FETCH-V0RELATORIOS. */

            R0250_00_FETCH_V0RELATORIOS_SECTION();

            /*" -304- IF WFIM-V0RELATORIOS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0RELATORIOS.IsEmpty())
            {

                /*" -305- PERFORM R9800-00-ENCERRA-SEM-SOLICIT */

                R9800_00_ENCERRA_SEM_SOLICIT_SECTION();

                /*" -306- ELSE */
            }
            else
            {


                /*" -308- PERFORM R0300-00-PROCESSA-LIBERACAO UNTIL WFIM-V0RELATORIOS NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_V0RELATORIOS.IsEmpty()))
                {

                    R0300_00_PROCESSA_LIBERACAO_SECTION();
                }

                /*" -308- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -312- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -316- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -316- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -329- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -335- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -338- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -339- DISPLAY 'R0100 - ERRO NO SELECT DA V0SISTEMA' */
                _.Display($"R0100 - ERRO NO SELECT DA V0SISTEMA");

                /*" -340- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -341- ELSE */
            }
            else
            {


                /*" -342- DISPLAY 'DATA DO MOVIMENTO AC - ' V0SIST-DTMOVABE */
                _.Display($"DATA DO MOVIMENTO AC - {V0SIST_DTMOVABE}");

                /*" -342- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -335- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'AC' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V0RELATORIOS-SECTION */
        private void R0200_00_DECLARE_V0RELATORIOS_SECTION()
        {
            /*" -355- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -375- PERFORM R0200_00_DECLARE_V0RELATORIOS_DB_DECLARE_1 */

            R0200_00_DECLARE_V0RELATORIOS_DB_DECLARE_1();

            /*" -377- PERFORM R0200_00_DECLARE_V0RELATORIOS_DB_OPEN_1 */

            R0200_00_DECLARE_V0RELATORIOS_DB_OPEN_1();

            /*" -380- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -381- DISPLAY 'R0200 - ERRO NO DECLARE DA V0RELATORIOS' */
                _.Display($"R0200 - ERRO NO DECLARE DA V0RELATORIOS");

                /*" -382- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -383- ELSE */
            }
            else
            {


                /*" -384- MOVE SPACES TO WFIM-V0RELATORIOS */
                _.Move("", AREA_DE_WORK.WFIM_V0RELATORIOS);

                /*" -384- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0RELATORIOS-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V0RELATORIOS_DB_DECLARE_1()
        {
            /*" -375- EXEC SQL DECLARE V0RELATORIOS CURSOR FOR SELECT CODUSU , DATA_SOLICITACAO , IDSISTEM , CODRELAT , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , CONGENER , CODUNIMO , CORRECAO , VALUE(COD_EMPRESA,+0) FROM SEGUROS.V0RELATORIOS WHERE DATA_SOLICITACAO = :V0SIST-DTMOVABE AND IDSISTEM = 'AC' AND CODRELAT = 'AC0816B' AND SITUACAO = ' ' ORDER BY COD_EMPRESA, CONGENER END-EXEC. */
            V0RELATORIOS = new AC0816B_V0RELATORIOS(true);
            string GetQuery_V0RELATORIOS()
            {
                var query = @$"SELECT CODUSU
							, 
							DATA_SOLICITACAO
							, 
							IDSISTEM
							, 
							CODRELAT
							, 
							PERI_INICIAL
							, 
							PERI_FINAL
							, 
							DATA_REFERENCIA
							, 
							CONGENER
							, 
							CODUNIMO
							, 
							CORRECAO
							, 
							VALUE(COD_EMPRESA
							,+0) 
							FROM SEGUROS.V0RELATORIOS 
							WHERE DATA_SOLICITACAO = '{V0SIST_DTMOVABE}' 
							AND IDSISTEM = 'AC' 
							AND CODRELAT = 'AC0816B' 
							AND SITUACAO = ' ' 
							ORDER BY 
							COD_EMPRESA
							, 
							CONGENER";

                return query;
            }
            V0RELATORIOS.GetQueryEvent += GetQuery_V0RELATORIOS;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0RELATORIOS-DB-OPEN-1 */
        public void R0200_00_DECLARE_V0RELATORIOS_DB_OPEN_1()
        {
            /*" -377- EXEC SQL OPEN V0RELATORIOS END-EXEC. */

            V0RELATORIOS.Open();

        }

        [StopWatch]
        /*" R0700-00-DECLARE-V1COSHISTSIN-DB-DECLARE-1 */
        public void R0700_00_DECLARE_V1COSHISTSIN_DB_DECLARE_1()
        {
            /*" -663- EXEC SQL DECLARE V1COSHISTSIN CURSOR FOR SELECT A.COD_EMPRESA , A.CONGENER , A.NUM_SINISTRO , A.OCORHIST , A.DTMOVTO , A.OPERACAO , A.VAL_OPERACAO , A.TIPSGU , A.SITUACAO , A.SIT_LIBRECUP , B.FUNCAO_OPERACAO , B.IND_TIPO_FUNCAO , C.IDE_SISTEMA , C.COD_FUNCAO , C.IDE_SISTEMA_OPER , C.NUM_FATOR FROM SEGUROS.V1COSSEG_HISTSIN A, SEGUROS.GE_OPERACAO B, SEGUROS.GE_SIS_FUNCAO_OPER C WHERE A.COD_EMPRESA = :V0RELA-COD-EMPR AND A.CONGENER = :V0RELA-CONGENER AND A.DTMOVTO <= :V0RELA-DATA-REF AND A.TIPSGU = '1' AND A.SIT_LIBRECUP = '0' AND A.SITUACAO = '0' AND B.IDE_SISTEMA = 'SI' AND B.COD_OPERACAO = A.OPERACAO AND C.IDE_SISTEMA = B.IDE_SISTEMA AND C.COD_FUNCAO IN (02,05,06,08,12,15, 16,17,18,20,21,22, 24,25,34) AND C.IDE_SISTEMA_OPER = B.IDE_SISTEMA AND C.COD_OPERACAO = B.COD_OPERACAO UNION ALL SELECT A.COD_EMPRESA , A.CONGENER , A.NUM_SINISTRO , A.OCORHIST , A.DTMOVTO , A.OPERACAO , A.VAL_OPERACAO , A.TIPSGU , A.SITUACAO , A.SIT_LIBRECUP , B.FUNCAO_OPERACAO , B.IND_TIPO_FUNCAO , C.IDE_SISTEMA , C.COD_FUNCAO , C.IDE_SISTEMA_OPER , C.NUM_FATOR FROM SEGUROS.V1COSSEG_HISTSIN A, SEGUROS.GE_OPERACAO B, SEGUROS.GE_SIS_FUNCAO_OPER C WHERE A.COD_EMPRESA = :V0RELA-COD-EMPR AND A.CONGENER = :V0RELA-CONGENER AND A.DTMOVTO <= :V0RELA-DATA-REF AND A.TIPSGU = '1' AND A.SIT_LIBRECUP = '0' AND A.SITUACAO = '0' AND B.IDE_SISTEMA = 'AC' AND B.COD_OPERACAO = A.OPERACAO AND C.IDE_SISTEMA = B.IDE_SISTEMA AND C.COD_FUNCAO = 02 AND C.IDE_SISTEMA_OPER = B.IDE_SISTEMA AND C.COD_OPERACAO = B.COD_OPERACAO ORDER BY CONGENER , NUM_SINISTRO , DTMOVTO , OCORHIST , OPERACAO END-EXEC. */
            V1COSHISTSIN = new AC0816B_V1COSHISTSIN(true);
            string GetQuery_V1COSHISTSIN()
            {
                var query = @$"SELECT A.COD_EMPRESA
							, 
							A.CONGENER
							, 
							A.NUM_SINISTRO
							, 
							A.OCORHIST
							, 
							A.DTMOVTO
							, 
							A.OPERACAO
							, 
							A.VAL_OPERACAO
							, 
							A.TIPSGU
							, 
							A.SITUACAO
							, 
							A.SIT_LIBRECUP
							, 
							B.FUNCAO_OPERACAO
							, 
							B.IND_TIPO_FUNCAO
							, 
							C.IDE_SISTEMA
							, 
							C.COD_FUNCAO
							, 
							C.IDE_SISTEMA_OPER
							, 
							C.NUM_FATOR 
							FROM SEGUROS.V1COSSEG_HISTSIN A
							, 
							SEGUROS.GE_OPERACAO B
							, 
							SEGUROS.GE_SIS_FUNCAO_OPER C 
							WHERE A.COD_EMPRESA = '{V0RELA_COD_EMPR}' 
							AND A.CONGENER = '{V0RELA_CONGENER}' 
							AND A.DTMOVTO <= '{V0RELA_DATA_REF}' 
							AND A.TIPSGU = '1' 
							AND A.SIT_LIBRECUP = '0' 
							AND A.SITUACAO = '0' 
							AND B.IDE_SISTEMA = 'SI' 
							AND B.COD_OPERACAO = A.OPERACAO 
							AND C.IDE_SISTEMA = B.IDE_SISTEMA 
							AND C.COD_FUNCAO IN (02
							,05
							,06
							,08
							,12
							,15
							, 
							16
							,17
							,18
							,20
							,21
							,22
							, 
							24
							,25
							,34) 
							AND C.IDE_SISTEMA_OPER = B.IDE_SISTEMA 
							AND C.COD_OPERACAO = B.COD_OPERACAO 
							UNION ALL 
							SELECT A.COD_EMPRESA
							, 
							A.CONGENER
							, 
							A.NUM_SINISTRO
							, 
							A.OCORHIST
							, 
							A.DTMOVTO
							, 
							A.OPERACAO
							, 
							A.VAL_OPERACAO
							, 
							A.TIPSGU
							, 
							A.SITUACAO
							, 
							A.SIT_LIBRECUP
							, 
							B.FUNCAO_OPERACAO
							, 
							B.IND_TIPO_FUNCAO
							, 
							C.IDE_SISTEMA
							, 
							C.COD_FUNCAO
							, 
							C.IDE_SISTEMA_OPER
							, 
							C.NUM_FATOR 
							FROM SEGUROS.V1COSSEG_HISTSIN A
							, 
							SEGUROS.GE_OPERACAO B
							, 
							SEGUROS.GE_SIS_FUNCAO_OPER C 
							WHERE A.COD_EMPRESA = '{V0RELA_COD_EMPR}' 
							AND A.CONGENER = '{V0RELA_CONGENER}' 
							AND A.DTMOVTO <= '{V0RELA_DATA_REF}' 
							AND A.TIPSGU = '1' 
							AND A.SIT_LIBRECUP = '0' 
							AND A.SITUACAO = '0' 
							AND B.IDE_SISTEMA = 'AC' 
							AND B.COD_OPERACAO = A.OPERACAO 
							AND C.IDE_SISTEMA = B.IDE_SISTEMA 
							AND C.COD_FUNCAO = 02 
							AND C.IDE_SISTEMA_OPER = B.IDE_SISTEMA 
							AND C.COD_OPERACAO = B.COD_OPERACAO 
							ORDER BY 
							CONGENER
							, 
							NUM_SINISTRO
							, 
							DTMOVTO
							, 
							OCORHIST
							, 
							OPERACAO";

                return query;
            }
            V1COSHISTSIN.GetQueryEvent += GetQuery_V1COSHISTSIN;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-FETCH-V0RELATORIOS-SECTION */
        private void R0250_00_FETCH_V0RELATORIOS_SECTION()
        {
            /*" -397- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", WABEND.WNR_EXEC_SQL);

            /*" -409- PERFORM R0250_00_FETCH_V0RELATORIOS_DB_FETCH_1 */

            R0250_00_FETCH_V0RELATORIOS_DB_FETCH_1();

            /*" -412- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -413- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -414- MOVE 'S' TO WFIM-V0RELATORIOS */
                    _.Move("S", AREA_DE_WORK.WFIM_V0RELATORIOS);

                    /*" -414- PERFORM R0250_00_FETCH_V0RELATORIOS_DB_CLOSE_1 */

                    R0250_00_FETCH_V0RELATORIOS_DB_CLOSE_1();

                    /*" -416- ELSE */
                }
                else
                {


                    /*" -417- DISPLAY 'R0250 - ERRO NO FETCH DA V0RELATORIOS' */
                    _.Display($"R0250 - ERRO NO FETCH DA V0RELATORIOS");

                    /*" -418- DISPLAY 'EMPRESA   - ' V0RELA-COD-EMPR */
                    _.Display($"EMPRESA   - {V0RELA_COD_EMPR}");

                    /*" -419- DISPLAY 'PROGRAMA  - ' V0RELA-CODRELAT */
                    _.Display($"PROGRAMA  - {V0RELA_CODRELAT}");

                    /*" -420- DISPLAY 'CONGENERE - ' V0RELA-CONGENER */
                    _.Display($"CONGENERE - {V0RELA_CONGENER}");

                    /*" -421- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -422- END-IF */
                }


                /*" -422- END-IF. */
            }


        }

        [StopWatch]
        /*" R0250-00-FETCH-V0RELATORIOS-DB-FETCH-1 */
        public void R0250_00_FETCH_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -409- EXEC SQL FETCH V0RELATORIOS INTO :V0RELA-COD-USU, :V0RELA-DATA-SOL, :V0RELA-IDSISTEM, :V0RELA-CODRELAT, :V0RELA-PERI-INI, :V0RELA-PERI-FIN, :V0RELA-DATA-REF, :V0RELA-CONGENER, :V0RELA-CODUNIMO, :V0RELA-CORRECAO, :V0RELA-COD-EMPR END-EXEC. */

            if (V0RELATORIOS.Fetch())
            {
                _.Move(V0RELATORIOS.V0RELA_COD_USU, V0RELA_COD_USU);
                _.Move(V0RELATORIOS.V0RELA_DATA_SOL, V0RELA_DATA_SOL);
                _.Move(V0RELATORIOS.V0RELA_IDSISTEM, V0RELA_IDSISTEM);
                _.Move(V0RELATORIOS.V0RELA_CODRELAT, V0RELA_CODRELAT);
                _.Move(V0RELATORIOS.V0RELA_PERI_INI, V0RELA_PERI_INI);
                _.Move(V0RELATORIOS.V0RELA_PERI_FIN, V0RELA_PERI_FIN);
                _.Move(V0RELATORIOS.V0RELA_DATA_REF, V0RELA_DATA_REF);
                _.Move(V0RELATORIOS.V0RELA_CONGENER, V0RELA_CONGENER);
                _.Move(V0RELATORIOS.V0RELA_CODUNIMO, V0RELA_CODUNIMO);
                _.Move(V0RELATORIOS.V0RELA_CORRECAO, V0RELA_CORRECAO);
                _.Move(V0RELATORIOS.V0RELA_COD_EMPR, V0RELA_COD_EMPR);
            }

        }

        [StopWatch]
        /*" R0250-00-FETCH-V0RELATORIOS-DB-CLOSE-1 */
        public void R0250_00_FETCH_V0RELATORIOS_DB_CLOSE_1()
        {
            /*" -414- EXEC SQL CLOSE V0RELATORIOS END-EXEC */

            V0RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-PROCESSA-LIBERACAO-SECTION */
        private void R0300_00_PROCESSA_LIBERACAO_SECTION()
        {
            /*" -435- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -436- DISPLAY '                                  ' . */
            _.Display($"                                  ");

            /*" -438- DISPLAY 'COD. EMPRESA  - ' V0RELA-COD-EMPR. */
            _.Display($"COD. EMPRESA  - {V0RELA_COD_EMPR}");

            /*" -440- MOVE V0RELA-COD-EMPR TO WCOD-EMPR-ANT. */
            _.Move(V0RELA_COD_EMPR, AREA_DE_WORK.WCOD_EMPR_ANT);

            /*" -442- PERFORM R0400-00-PROCESSA-EMPRESAS UNTIL WFIM-V0RELATORIOS NOT EQUAL SPACES OR V0RELA-COD-EMPR NOT EQUAL WCOD-EMPR-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V0RELATORIOS.IsEmpty() || V0RELA_COD_EMPR != AREA_DE_WORK.WCOD_EMPR_ANT))
            {

                R0400_00_PROCESSA_EMPRESAS_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-EMPRESAS-SECTION */
        private void R0400_00_PROCESSA_EMPRESAS_SECTION()
        {
            /*" -455- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -463- MOVE ZEROS TO AC-VLRSINI AC-VLDESPESA AC-VLRHONOR AC-VLRSALVD AC-VLRESSARC AC-SINI-DEBITO AC-SINI-CREDITO. */
            _.Move(0, AREA_DE_WORK.AC_VLRSINI, AREA_DE_WORK.AC_VLDESPESA, AREA_DE_WORK.AC_VLRHONOR, AREA_DE_WORK.AC_VLRSALVD, AREA_DE_WORK.AC_VLRESSARC, AREA_DE_WORK.AC_SINI_DEBITO, AREA_DE_WORK.AC_SINI_CREDITO);

            /*" -464- DISPLAY 'CONGENERE     - ' V0RELA-CONGENER. */
            _.Display($"CONGENERE     - {V0RELA_CONGENER}");

            /*" -466- DISPLAY 'LIBERADO ATE  - ' V0RELA-DATA-REF. */
            _.Display($"LIBERADO ATE  - {V0RELA_DATA_REF}");

            /*" -468- IF V0RELA-CODUNIMO NOT EQUAL ZEROS AND V0RELA-PERI-INI NOT EQUAL '0001-01-01' */

            if (V0RELA_CODUNIMO != 00 && V0RELA_PERI_INI != "0001-01-01")
            {

                /*" -469- MOVE V0RELA-CODUNIMO TO V0COTA-CODUNIMO */
                _.Move(V0RELA_CODUNIMO, V0COTA_CODUNIMO);

                /*" -470- MOVE V0RELA-PERI-INI TO V0COTA-DTINIVIG */
                _.Move(V0RELA_PERI_INI, V0COTA_DTINIVIG);

                /*" -471- PERFORM R0500-00-SELECT-V0COTACAO */

                R0500_00_SELECT_V0COTACAO_SECTION();

                /*" -472- MOVE V0COTA-VAL-VENDA TO WCOTACAO-SOLIC */
                _.Move(V0COTA_VAL_VENDA, AREA_DE_WORK.WCOTACAO_SOLIC);

                /*" -474- END-IF. */
            }


            /*" -476- PERFORM R0700-00-DECLARE-V1COSHISTSIN. */

            R0700_00_DECLARE_V1COSHISTSIN_SECTION();

            /*" -478- PERFORM R0750-00-FETCH-V1COSHISTSIN. */

            R0750_00_FETCH_V1COSHISTSIN_SECTION();

            /*" -479- IF WFIM-V1COSHISTSIN NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1COSHISTSIN.IsEmpty())
            {

                /*" -480- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -481- GO TO R0400-90-PROXIMA-SOLICITACAO */

                R0400_90_PROXIMA_SOLICITACAO(); //GOTO
                return;

                /*" -482- ELSE */
            }
            else
            {


                /*" -483- MOVE ZEROS TO WNUM-SINI-ANT */
                _.Move(0, AREA_DE_WORK.WNUM_SINI_ANT);

                /*" -485- END-IF. */
            }


            /*" -488- PERFORM R0800-00-PROCESSA-REGISTRO UNTIL WFIM-V1COSHISTSIN NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1COSHISTSIN.IsEmpty()))
            {

                R0800_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -489- MOVE AC-VLRSINI TO V0CCHQ-VLRSINI. */
            _.Move(AREA_DE_WORK.AC_VLRSINI, V0CCHQ_VLRSINI);

            /*" -490- MOVE AC-VLDESPESA TO V0CCHQ-VLDESPESA. */
            _.Move(AREA_DE_WORK.AC_VLDESPESA, V0CCHQ_VLDESPESA);

            /*" -491- MOVE AC-VLRHONOR TO V0CCHQ-VLRHONOR. */
            _.Move(AREA_DE_WORK.AC_VLRHONOR, V0CCHQ_VLRHONOR);

            /*" -492- MOVE AC-VLRSALVD TO V0CCHQ-VLRSALVD. */
            _.Move(AREA_DE_WORK.AC_VLRSALVD, V0CCHQ_VLRSALVD);

            /*" -494- MOVE AC-VLRESSARC TO V0CCHQ-VLRESSARC. */
            _.Move(AREA_DE_WORK.AC_VLRESSARC, V0CCHQ_VLRESSARC);

            /*" -497- MOVE ZEROS TO V0CCHQ-OUTRDEBIT V0CCHQ-OUTRCREDT. */
            _.Move(0, V0CCHQ_OUTRDEBIT, V0CCHQ_OUTRCREDT);

            /*" -500- MOVE ZEROS TO WHOST-OUTRDEBIT WHOST-OUTRCREDT. */
            _.Move(0, WHOST_OUTRDEBIT, WHOST_OUTRCREDT);

            /*" -502- PERFORM R1800-00-SELECT-COSCED-CHEQUE. */

            R1800_00_SELECT_COSCED_CHEQUE_SECTION();

            /*" -505- COMPUTE V0CCHQ-OUTRDEBIT = AC-SINI-DEBITO + WHOST-OUTRDEBIT. */
            V0CCHQ_OUTRDEBIT.Value = AREA_DE_WORK.AC_SINI_DEBITO + WHOST_OUTRDEBIT;

            /*" -508- COMPUTE V0CCHQ-OUTRCREDT = AC-SINI-CREDITO + WHOST-OUTRCREDT. */
            V0CCHQ_OUTRCREDT.Value = AREA_DE_WORK.AC_SINI_CREDITO + WHOST_OUTRCREDT;

            /*" -510- PERFORM R2000-00-UPDATE-COSCED-CHEQUE. */

            R2000_00_UPDATE_COSCED_CHEQUE_SECTION();

            /*" -511- DISPLAY 'DOCUMENTOS LIDOS  - ' AC-L-V1COSHISTSIN. */
            _.Display($"DOCUMENTOS LIDOS  - {AREA_DE_WORK.AC_L_V1COSHISTSIN}");

            /*" -512- DISPLAY '       INSERIDOS  - ' AC-I-V0COSHISTSIN. */
            _.Display($"       INSERIDOS  - {AREA_DE_WORK.AC_I_V0COSHISTSIN}");

            /*" -513- DISPLAY '     ATUALIZADOS  - ' AC-U-V0COSHISTSIN. */
            _.Display($"     ATUALIZADOS  - {AREA_DE_WORK.AC_U_V0COSHISTSIN}");

            /*" -514- DISPLAY 'VLR SINISTRO      - ' AC-VLRSINI. */
            _.Display($"VLR SINISTRO      - {AREA_DE_WORK.AC_VLRSINI}");

            /*" -515- DISPLAY 'VLR SALVADO       - ' AC-VLRSALVD. */
            _.Display($"VLR SALVADO       - {AREA_DE_WORK.AC_VLRSALVD}");

            /*" -516- DISPLAY 'VLR RESSARCIMENTO - ' AC-VLRESSARC. */
            _.Display($"VLR RESSARCIMENTO - {AREA_DE_WORK.AC_VLRESSARC}");

            /*" -517- DISPLAY 'VLR SINISTRO DEBT - ' AC-SINI-DEBITO. */
            _.Display($"VLR SINISTRO DEBT - {AREA_DE_WORK.AC_SINI_DEBITO}");

            /*" -518- DISPLAY 'VLR SINISTRO CRED - ' AC-SINI-CREDITO. */
            _.Display($"VLR SINISTRO CRED - {AREA_DE_WORK.AC_SINI_CREDITO}");

            /*" -518- DISPLAY '                    ' . */
            _.Display($"                    ");

            /*" -0- FLUXCONTROL_PERFORM R0400_90_PROXIMA_SOLICITACAO */

            R0400_90_PROXIMA_SOLICITACAO();

        }

        [StopWatch]
        /*" R0400-90-PROXIMA-SOLICITACAO */
        private void R0400_90_PROXIMA_SOLICITACAO(bool isPerform = false)
        {
            /*" -524- PERFORM R2100-00-DELETE-V0RELATORIOS. */

            R2100_00_DELETE_V0RELATORIOS_SECTION();

            /*" -524- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -528- PERFORM R0200-00-DECLARE-V0RELATORIOS. */

            R0200_00_DECLARE_V0RELATORIOS_SECTION();

            /*" -528- PERFORM R0250-00-FETCH-V0RELATORIOS. */

            R0250_00_FETCH_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-SELECT-V0COTACAO-SECTION */
        private void R0500_00_SELECT_V0COTACAO_SECTION()
        {
            /*" -541- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -549- PERFORM R0500_00_SELECT_V0COTACAO_DB_SELECT_1 */

            R0500_00_SELECT_V0COTACAO_DB_SELECT_1();

            /*" -552- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -553- DISPLAY 'R0500 - ERRO NO SELECT DA V0COTACAO' */
                _.Display($"R0500 - ERRO NO SELECT DA V0COTACAO");

                /*" -554- DISPLAY 'MOEDA    - ' V0COTA-CODUNIMO */
                _.Display($"MOEDA    - {V0COTA_CODUNIMO}");

                /*" -555- DISPLAY 'INIC VIG - ' V0COTA-DTINIVIG */
                _.Display($"INIC VIG - {V0COTA_DTINIVIG}");

                /*" -556- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -556- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-00-SELECT-V0COTACAO-DB-SELECT-1 */
        public void R0500_00_SELECT_V0COTACAO_DB_SELECT_1()
        {
            /*" -549- EXEC SQL SELECT VAL_VENDA INTO :V0COTA-VAL-VENDA FROM SEGUROS.V0COTACAO WHERE CODUNIMO = :V0COTA-CODUNIMO AND DTINIVIG <= :V0COTA-DTINIVIG AND DTTERVIG >= :V0COTA-DTINIVIG WITH UR END-EXEC. */

            var r0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 = new R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1()
            {
                V0COTA_CODUNIMO = V0COTA_CODUNIMO.ToString(),
                V0COTA_DTINIVIG = V0COTA_DTINIVIG.ToString(),
            };

            var executed_1 = R0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1.Execute(r0500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COTA_VAL_VENDA, V0COTA_VAL_VENDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-DECLARE-V1COSHISTSIN-SECTION */
        private void R0700_00_DECLARE_V1COSHISTSIN_SECTION()
        {
            /*" -569- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -663- PERFORM R0700_00_DECLARE_V1COSHISTSIN_DB_DECLARE_1 */

            R0700_00_DECLARE_V1COSHISTSIN_DB_DECLARE_1();

            /*" -665- PERFORM R0700_00_DECLARE_V1COSHISTSIN_DB_OPEN_1 */

            R0700_00_DECLARE_V1COSHISTSIN_DB_OPEN_1();

            /*" -668- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -669- DISPLAY 'R0700 - ERRO NO DECLARE DA V1COSSEG-HISTSIN' */
                _.Display($"R0700 - ERRO NO DECLARE DA V1COSSEG-HISTSIN");

                /*" -670- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -671- ELSE */
            }
            else
            {


                /*" -672- MOVE SPACES TO WFIM-V1COSHISTSIN */
                _.Move("", AREA_DE_WORK.WFIM_V1COSHISTSIN);

                /*" -675- MOVE ZEROS TO AC-L-V1COSHISTSIN AC-I-V0COSHISTSIN AC-U-V0COSHISTSIN */
                _.Move(0, AREA_DE_WORK.AC_L_V1COSHISTSIN, AREA_DE_WORK.AC_I_V0COSHISTSIN, AREA_DE_WORK.AC_U_V0COSHISTSIN);

                /*" -675- END-IF. */
            }


        }

        [StopWatch]
        /*" R0700-00-DECLARE-V1COSHISTSIN-DB-OPEN-1 */
        public void R0700_00_DECLARE_V1COSHISTSIN_DB_OPEN_1()
        {
            /*" -665- EXEC SQL OPEN V1COSHISTSIN END-EXEC. */

            V1COSHISTSIN.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0750-00-FETCH-V1COSHISTSIN-SECTION */
        private void R0750_00_FETCH_V1COSHISTSIN_SECTION()
        {
            /*" -688- MOVE '0750' TO WNR-EXEC-SQL. */
            _.Move("0750", WABEND.WNR_EXEC_SQL);

            /*" -705- PERFORM R0750_00_FETCH_V1COSHISTSIN_DB_FETCH_1 */

            R0750_00_FETCH_V1COSHISTSIN_DB_FETCH_1();

            /*" -708- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -709- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -710- MOVE 'S' TO WFIM-V1COSHISTSIN */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COSHISTSIN);

                    /*" -710- PERFORM R0750_00_FETCH_V1COSHISTSIN_DB_CLOSE_1 */

                    R0750_00_FETCH_V1COSHISTSIN_DB_CLOSE_1();

                    /*" -712- ELSE */
                }
                else
                {


                    /*" -713- DISPLAY 'R0750 - ERRO NO FETCH DA V1COSSEG-HISTSIN' */
                    _.Display($"R0750 - ERRO NO FETCH DA V1COSSEG-HISTSIN");

                    /*" -714- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -715- END-IF */
                }


                /*" -716- ELSE */
            }
            else
            {


                /*" -717- ADD 1 TO AC-L-V1COSHISTSIN */
                AREA_DE_WORK.AC_L_V1COSHISTSIN.Value = AREA_DE_WORK.AC_L_V1COSHISTSIN + 1;

                /*" -717- END-IF. */
            }


        }

        [StopWatch]
        /*" R0750-00-FETCH-V1COSHISTSIN-DB-FETCH-1 */
        public void R0750_00_FETCH_V1COSHISTSIN_DB_FETCH_1()
        {
            /*" -705- EXEC SQL FETCH V1COSHISTSIN INTO :V1CHSI-COD-EMPR , :V1CHSI-CONGENER , :V1CHSI-NUM-SINI , :V1CHSI-OCORHIST , :V1CHSI-DTMOVTO , :V1CHSI-OPERACAO , :V1CHSI-VAL-OPER , :V1CHSI-TIPSGU:VIND-TIP-SEGR, :V1CHSI-SITUACAO:VIND-SIT-REGT, :V1CHSI-SIT-LIBREC:VIND-SIT-LIBR, :GEOPERAC-FUNCAO-OPERACAO , :GEOPERAC-IND-TIPO-FUNCAO , :GESISFUO-IDE-SISTEMA , :GESISFUO-COD-FUNCAO , :GESISFUO-IDE-SISTEMA-OPER , :GESISFUO-NUM-FATOR END-EXEC. */

            if (V1COSHISTSIN.Fetch())
            {
                _.Move(V1COSHISTSIN.V1CHSI_COD_EMPR, V1CHSI_COD_EMPR);
                _.Move(V1COSHISTSIN.V1CHSI_CONGENER, V1CHSI_CONGENER);
                _.Move(V1COSHISTSIN.V1CHSI_NUM_SINI, V1CHSI_NUM_SINI);
                _.Move(V1COSHISTSIN.V1CHSI_OCORHIST, V1CHSI_OCORHIST);
                _.Move(V1COSHISTSIN.V1CHSI_DTMOVTO, V1CHSI_DTMOVTO);
                _.Move(V1COSHISTSIN.V1CHSI_OPERACAO, V1CHSI_OPERACAO);
                _.Move(V1COSHISTSIN.V1CHSI_VAL_OPER, V1CHSI_VAL_OPER);
                _.Move(V1COSHISTSIN.V1CHSI_TIPSGU, V1CHSI_TIPSGU);
                _.Move(V1COSHISTSIN.VIND_TIP_SEGR, VIND_TIP_SEGR);
                _.Move(V1COSHISTSIN.V1CHSI_SITUACAO, V1CHSI_SITUACAO);
                _.Move(V1COSHISTSIN.VIND_SIT_REGT, VIND_SIT_REGT);
                _.Move(V1COSHISTSIN.V1CHSI_SIT_LIBREC, V1CHSI_SIT_LIBREC);
                _.Move(V1COSHISTSIN.VIND_SIT_LIBR, VIND_SIT_LIBR);
                _.Move(V1COSHISTSIN.GEOPERAC_FUNCAO_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);
                _.Move(V1COSHISTSIN.GEOPERAC_IND_TIPO_FUNCAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO);
                _.Move(V1COSHISTSIN.GESISFUO_IDE_SISTEMA, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA);
                _.Move(V1COSHISTSIN.GESISFUO_COD_FUNCAO, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO);
                _.Move(V1COSHISTSIN.GESISFUO_IDE_SISTEMA_OPER, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER);
                _.Move(V1COSHISTSIN.GESISFUO_NUM_FATOR, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);
            }

        }

        [StopWatch]
        /*" R0750-00-FETCH-V1COSHISTSIN-DB-CLOSE-1 */
        public void R0750_00_FETCH_V1COSHISTSIN_DB_CLOSE_1()
        {
            /*" -710- EXEC SQL CLOSE V1COSHISTSIN END-EXEC */

            V1COSHISTSIN.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-PROCESSA-REGISTRO-SECTION */
        private void R0800_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -733- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", WABEND.WNR_EXEC_SQL);

            /*" -734- IF GESISFUO-IDE-SISTEMA = 'AC' */

            if (GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA == "AC")
            {

                /*" -735- PERFORM R0900-00-SELECT-GESISORL */

                R0900_00_SELECT_GESISORL_SECTION();

                /*" -736- ELSE */
            }
            else
            {


                /*" -737- MOVE GESISFUO-COD-FUNCAO TO GESISORL-COD-FUNCAO */
                _.Move(GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO, GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_FUNCAO);

                /*" -738- MOVE V1CHSI-OPERACAO TO GESISORL-COD-OPERACAO */
                _.Move(V1CHSI_OPERACAO, GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_OPERACAO);

                /*" -740- END-IF. */
            }


            /*" -744- MOVE GESISORL-COD-OPERACAO TO V0HSIN-OPERACAO. */
            _.Move(GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_OPERACAO, V0HSIN_OPERACAO);

            /*" -746- MOVE 01 TO GESISORL-COD-FUNCAO-ASS. */
            _.Move(01, GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_FUNCAO_ASS);

            /*" -748- PERFORM R0950-00-SELECT-GESISORL. */

            R0950_00_SELECT_GESISORL_SECTION();

            /*" -753- MOVE GESISORL-COD-OPERACAO-ASS TO V0CHSI-OPERACAO. */
            _.Move(GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_OPERACAO_ASS, V0CHSI_OPERACAO);

            /*" -755- MOVE 04 TO GESISORL-COD-FUNCAO-ASS. */
            _.Move(04, GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_FUNCAO_ASS);

            /*" -757- PERFORM R0950-00-SELECT-GESISORL. */

            R0950_00_SELECT_GESISORL_SECTION();

            /*" -762- MOVE GESISORL-COD-OPERACAO-ASS TO WS-OP-CM-PEND. */
            _.Move(GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_OPERACAO_ASS, AREA_DE_WORK.WS_OP_CM_PEND);

            /*" -764- MOVE 05 TO GESISORL-COD-FUNCAO-ASS. */
            _.Move(05, GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_FUNCAO_ASS);

            /*" -766- PERFORM R0950-00-SELECT-GESISORL. */

            R0950_00_SELECT_GESISORL_SECTION();

            /*" -768- MOVE GESISORL-COD-OPERACAO-ASS TO WS-OP-CM-LIB. */
            _.Move(GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_OPERACAO_ASS, AREA_DE_WORK.WS_OP_CM_LIB);

            /*" -769- IF V1CHSI-NUM-SINI NOT = WNUM-SINI-ANT */

            if (V1CHSI_NUM_SINI != AREA_DE_WORK.WNUM_SINI_ANT)
            {

                /*" -770- MOVE V1CHSI-NUM-SINI TO WNUM-SINI-ANT */
                _.Move(V1CHSI_NUM_SINI, AREA_DE_WORK.WNUM_SINI_ANT);

                /*" -771- PERFORM R1000-00-SELECT-V0MESTSINI */

                R1000_00_SELECT_V0MESTSINI_SECTION();

                /*" -772- PERFORM R1050-00-SELECT-V0APOLICE */

                R1050_00_SELECT_V0APOLICE_SECTION();

                /*" -774- END-IF. */
            }


            /*" -776- MOVE ZEROS TO WHOST-VAL-CORR. */
            _.Move(0, WHOST_VAL_CORR);

            /*" -777- IF GEOPERAC-IND-TIPO-FUNCAO = 'IN' OR 'JUR-INDENI' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("IN", "JUR-INDENI"))
            {

                /*" -778- IF V0RELA-PERI-INI NOT = '0001-01-01' */

                if (V0RELA_PERI_INI != "0001-01-01")
                {

                    /*" -779- IF V0MSIN-MOEDA-SINI NOT = ZEROS */

                    if (V0MSIN_MOEDA_SINI != 00)
                    {

                        /*" -780- PERFORM R1150-00-CALC-CORR-INDX */

                        R1150_00_CALC_CORR_INDX_SECTION();

                        /*" -781- ELSE */
                    }
                    else
                    {


                        /*" -782- IF V0RELA-CODUNIMO NOT = ZEROS */

                        if (V0RELA_CODUNIMO != 00)
                        {

                            /*" -783- PERFORM R1300-00-CALC-CORR-NINDX */

                            R1300_00_CALC_CORR_NINDX_SECTION();

                            /*" -784- END-IF */
                        }


                        /*" -785- END-IF */
                    }


                    /*" -786- END-IF */
                }


                /*" -788- END-IF. */
            }


            /*" -789- IF WHOST-VAL-CORR = ZEROS */

            if (WHOST_VAL_CORR == 00)
            {

                /*" -790- MOVE V1CHSI-VAL-OPER TO V0CHSI-VAL-OPER */
                _.Move(V1CHSI_VAL_OPER, V0CHSI_VAL_OPER);

                /*" -791- ELSE */
            }
            else
            {


                /*" -792- PERFORM R1600-00-INSERT-V0COSHISTSIN */

                R1600_00_INSERT_V0COSHISTSIN_SECTION();

                /*" -796- END-IF. */
            }


            /*" -798- IF GEOPERAC-IND-TIPO-FUNCAO EQUAL 'IN' OR 'JUR-INDENI' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("IN", "JUR-INDENI"))
            {

                /*" -801- COMPUTE AC-VLRSINI = AC-VLRSINI + (V0CHSI-VAL-OPER * GESISFUO-NUM-FATOR) */
                AREA_DE_WORK.AC_VLRSINI.Value = AREA_DE_WORK.AC_VLRSINI + (V0CHSI_VAL_OPER * GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);

                /*" -805- ELSE */
            }
            else
            {


                /*" -809- IF GEOPERAC-IND-TIPO-FUNCAO EQUAL 'DE' OR 'DS' OR 'JUR-DESP' OR 'RESSA-DES' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("DE", "DS", "JUR-DESP", "RESSA-DES"))
                {

                    /*" -812- COMPUTE AC-VLDESPESA = AC-VLDESPESA + (V0CHSI-VAL-OPER * GESISFUO-NUM-FATOR) */
                    AREA_DE_WORK.AC_VLDESPESA.Value = AREA_DE_WORK.AC_VLDESPESA + (V0CHSI_VAL_OPER * GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);

                    /*" -816- ELSE */
                }
                else
                {


                    /*" -820- IF GEOPERAC-IND-TIPO-FUNCAO EQUAL 'HO' OR 'HS' OR 'JUR-HON' OR 'RESSA-HON' */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("HO", "HS", "JUR-HON", "RESSA-HON"))
                    {

                        /*" -823- COMPUTE AC-VLRHONOR = AC-VLRHONOR + (V0CHSI-VAL-OPER * GESISFUO-NUM-FATOR) */
                        AREA_DE_WORK.AC_VLRHONOR.Value = AREA_DE_WORK.AC_VLRHONOR + (V0CHSI_VAL_OPER * GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);

                        /*" -827- ELSE */
                    }
                    else
                    {


                        /*" -829- IF GEOPERAC-IND-TIPO-FUNCAO EQUAL 'SA' */

                        if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "SA")
                        {

                            /*" -832- COMPUTE AC-VLRSALVD = AC-VLRSALVD + (V0CHSI-VAL-OPER * GESISFUO-NUM-FATOR) */
                            AREA_DE_WORK.AC_VLRSALVD.Value = AREA_DE_WORK.AC_VLRSALVD + (V0CHSI_VAL_OPER * GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);

                            /*" -839- IF (V0APOL-TIPSGU = '1' AND (V0APOL-RAMO = 31 OR 53) AND (V0APOL-ORGAO = 0100 OR 0110) AND (V1CHSI-CONGENER = 1015 OR 5118 OR V1CHSI-CONGENER = 6238) AND (GEOPERAC-FUNCAO-OPERACAO = 'SVEN' OR 'SEVEN' OR GEOPERAC-FUNCAO-OPERACAO = 'SIMO' OR 'SEIMO' )) */

                            if ((V0APOL_TIPSGU == "1" && (V0APOL_RAMO.In("31", "53")) && (V0APOL_ORGAO.In("0100", "0110")) && (V1CHSI_CONGENER.In("1015", "5118") || V1CHSI_CONGENER == 6238) && (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("SVEN", "SEVEN") || GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("SIMO", "SEIMO"))))
                            {

                                /*" -840- PERFORM R1700-00-SELECT-V0HISTSINI */

                                R1700_00_SELECT_V0HISTSINI_SECTION();

                                /*" -843- COMPUTE AC-SINI-DEBITO = AC-SINI-DEBITO + (V0HSIN-VAL-OPER * GESISFUO-NUM-FATOR) */
                                AREA_DE_WORK.AC_SINI_DEBITO.Value = AREA_DE_WORK.AC_SINI_DEBITO + (V0HSIN_VAL_OPER * GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);

                                /*" -845- ELSE NEXT SENTENCE */
                            }
                            else
                            {


                                /*" -849- ELSE */
                            }

                        }
                        else
                        {


                            /*" -851- IF GEOPERAC-IND-TIPO-FUNCAO EQUAL 'RESSA-RECE' */

                            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "RESSA-RECE")
                            {

                                /*" -854- COMPUTE AC-VLRESSARC = AC-VLRESSARC + (V0CHSI-VAL-OPER * GESISFUO-NUM-FATOR) */
                                AREA_DE_WORK.AC_VLRESSARC.Value = AREA_DE_WORK.AC_VLRESSARC + (V0CHSI_VAL_OPER * GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);

                                /*" -855- ELSE */
                            }
                            else
                            {


                                /*" -857- IF GEOPERAC-IND-TIPO-FUNCAO EQUAL 'RESSA-REP' */

                                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "RESSA-REP")
                                {

                                    /*" -860- COMPUTE AC-VLRESSARC = AC-VLRESSARC - (V0CHSI-VAL-OPER * GESISFUO-NUM-FATOR) */
                                    AREA_DE_WORK.AC_VLRESSARC.Value = AREA_DE_WORK.AC_VLRESSARC - (V0CHSI_VAL_OPER * GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);

                                    /*" -861- ELSE */
                                }
                                else
                                {


                                    /*" -862- DISPLAY 'R0800 - TIPO DE FUNCAO NAO PREVISTO' */
                                    _.Display($"R0800 - TIPO DE FUNCAO NAO PREVISTO");

                                    /*" -863- DISPLAY 'COD EMPR - ' V1CHSI-COD-EMPR */
                                    _.Display($"COD EMPR - {V1CHSI_COD_EMPR}");

                                    /*" -864- DISPLAY 'COD CONG - ' V1CHSI-CONGENER */
                                    _.Display($"COD CONG - {V1CHSI_CONGENER}");

                                    /*" -865- DISPLAY 'SINISTRO - ' V1CHSI-NUM-SINI */
                                    _.Display($"SINISTRO - {V1CHSI_NUM_SINI}");

                                    /*" -866- DISPLAY 'OCR HIST - ' V1CHSI-OCORHIST */
                                    _.Display($"OCR HIST - {V1CHSI_OCORHIST}");

                                    /*" -867- DISPLAY 'OPERACAO - ' V1CHSI-OPERACAO */
                                    _.Display($"OPERACAO - {V1CHSI_OPERACAO}");

                                    /*" -868- DISPLAY 'DT MOVTO - ' V1CHSI-DTMOVTO */
                                    _.Display($"DT MOVTO - {V1CHSI_DTMOVTO}");

                                    /*" -869- DISPLAY 'TIP FUNC - ' GEOPERAC-IND-TIPO-FUNCAO */
                                    _.Display($"TIP FUNC - {GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO}");

                                    /*" -871- GO TO R9999-00-ROT-ERRO. */

                                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                                    return;
                                }

                            }

                        }

                    }

                }

            }


            /*" -873- IF V0MSIN-NUM-APOL = 66001000001 OR 106600000001 */

            if (V0MSIN_NUM_APOL.In("66001000001", "106600000001"))
            {

                /*" -876- IF GEOPERAC-IND-TIPO-FUNCAO EQUAL 'SA' OR 'RESSA-RECE' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("SA", "RESSA-RECE"))
                {

                    /*" -880- COMPUTE AC-SINI-CREDITO = AC-SINI-CREDITO + (V0CHSI-VAL-OPER * GESISFUO-NUM-FATOR * -1) */
                    AREA_DE_WORK.AC_SINI_CREDITO.Value = AREA_DE_WORK.AC_SINI_CREDITO + (V0CHSI_VAL_OPER * GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR * -1);

                    /*" -881- ELSE */
                }
                else
                {


                    /*" -884- COMPUTE AC-SINI-CREDITO = AC-SINI-CREDITO + (V0CHSI-VAL-OPER * GESISFUO-NUM-FATOR) */
                    AREA_DE_WORK.AC_SINI_CREDITO.Value = AREA_DE_WORK.AC_SINI_CREDITO + (V0CHSI_VAL_OPER * GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);

                    /*" -885- END-IF */
                }


                /*" -887- END-IF. */
            }


            /*" -889- PERFORM R1400-00-UPDATE-V0COSHISTSIN. */

            R1400_00_UPDATE_V0COSHISTSIN_SECTION();

            /*" -889- PERFORM R1500-00-INSERT-V0COSHISTSIN. */

            R1500_00_INSERT_V0COSHISTSIN_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0800_90_LER_V1COSHISTSIN */

            R0800_90_LER_V1COSHISTSIN();

        }

        [StopWatch]
        /*" R0800-90-LER-V1COSHISTSIN */
        private void R0800_90_LER_V1COSHISTSIN(bool isPerform = false)
        {
            /*" -893- PERFORM R0750-00-FETCH-V1COSHISTSIN. */

            R0750_00_FETCH_V1COSHISTSIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-SELECT-GESISORL-SECTION */
        private void R0900_00_SELECT_GESISORL_SECTION()
        {
            /*" -906- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -919- PERFORM R0900_00_SELECT_GESISORL_DB_SELECT_1 */

            R0900_00_SELECT_GESISORL_DB_SELECT_1();

            /*" -922- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -923- DISPLAY 'R0900 - ERRO NO SELECT GE-SIS-FUN-OPE-REL' */
                _.Display($"R0900 - ERRO NO SELECT GE-SIS-FUN-OPE-REL");

                /*" -924- DISPLAY 'COD EMPR - ' V1CHSI-COD-EMPR */
                _.Display($"COD EMPR - {V1CHSI_COD_EMPR}");

                /*" -925- DISPLAY 'COD CONG - ' V1CHSI-CONGENER */
                _.Display($"COD CONG - {V1CHSI_CONGENER}");

                /*" -926- DISPLAY 'SINISTRO - ' V1CHSI-NUM-SINI */
                _.Display($"SINISTRO - {V1CHSI_NUM_SINI}");

                /*" -927- DISPLAY 'OC. HIST - ' V1CHSI-OCORHIST */
                _.Display($"OC. HIST - {V1CHSI_OCORHIST}");

                /*" -928- DISPLAY 'OPERACAO - ' V1CHSI-OPERACAO */
                _.Display($"OPERACAO - {V1CHSI_OPERACAO}");

                /*" -929- DISPLAY 'IDE SIST - ' GESISFUO-IDE-SISTEMA */
                _.Display($"IDE SIST - {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA}");

                /*" -930- DISPLAY 'COD FUNC - ' GESISFUO-COD-FUNCAO */
                _.Display($"COD FUNC - {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO}");

                /*" -931- DISPLAY 'IDE SIST - ' GESISFUO-IDE-SISTEMA-OPER */
                _.Display($"IDE SIST - {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER}");

                /*" -932- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -932- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-SELECT-GESISORL-DB-SELECT-1 */
        public void R0900_00_SELECT_GESISORL_DB_SELECT_1()
        {
            /*" -919- EXEC SQL SELECT COD_FUNCAO, COD_OPERACAO INTO :GESISORL-COD-FUNCAO, :GESISORL-COD-OPERACAO FROM SEGUROS.GE_SIS_FUN_OPE_REL WHERE IDE_SISTEMA_FC_ASS = :GESISFUO-IDE-SISTEMA AND COD_FUNCAO_ASS = :GESISFUO-COD-FUNCAO AND IDE_SISTEMA_OP_ASS = :GESISFUO-IDE-SISTEMA-OPER AND COD_OPERACAO_ASS = :V1CHSI-OPERACAO AND IDE_SISTEMA_FUNCAO = 'SI' AND IDE_SISTEMA_OPER = 'SI' WITH UR END-EXEC. */

            var r0900_00_SELECT_GESISORL_DB_SELECT_1_Query1 = new R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1()
            {
                GESISFUO_IDE_SISTEMA_OPER = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER.ToString(),
                GESISFUO_IDE_SISTEMA = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA.ToString(),
                GESISFUO_COD_FUNCAO = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO.ToString(),
                V1CHSI_OPERACAO = V1CHSI_OPERACAO.ToString(),
            };

            var executed_1 = R0900_00_SELECT_GESISORL_DB_SELECT_1_Query1.Execute(r0900_00_SELECT_GESISORL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GESISORL_COD_FUNCAO, GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_FUNCAO);
                _.Move(executed_1.GESISORL_COD_OPERACAO, GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-SELECT-GESISORL-SECTION */
        private void R0950_00_SELECT_GESISORL_SECTION()
        {
            /*" -945- MOVE '0950' TO WNR-EXEC-SQL. */
            _.Move("0950", WABEND.WNR_EXEC_SQL);

            /*" -957- PERFORM R0950_00_SELECT_GESISORL_DB_SELECT_1 */

            R0950_00_SELECT_GESISORL_DB_SELECT_1();

            /*" -960- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -961- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -962- MOVE ZEROS TO GESISORL-COD-OPERACAO-ASS */
                    _.Move(0, GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_OPERACAO_ASS);

                    /*" -963- ELSE */
                }
                else
                {


                    /*" -964- DISPLAY 'R0950 - ERRO NO SELECT GE-SIS-FUN-OPE-REL' */
                    _.Display($"R0950 - ERRO NO SELECT GE-SIS-FUN-OPE-REL");

                    /*" -965- DISPLAY 'COD EMPR - ' V1CHSI-COD-EMPR */
                    _.Display($"COD EMPR - {V1CHSI_COD_EMPR}");

                    /*" -966- DISPLAY 'COD CONG - ' V1CHSI-CONGENER */
                    _.Display($"COD CONG - {V1CHSI_CONGENER}");

                    /*" -967- DISPLAY 'SINISTRO - ' V1CHSI-NUM-SINI */
                    _.Display($"SINISTRO - {V1CHSI_NUM_SINI}");

                    /*" -968- DISPLAY 'OC. HIST - ' V1CHSI-OCORHIST */
                    _.Display($"OC. HIST - {V1CHSI_OCORHIST}");

                    /*" -969- DISPLAY 'OPERACAO - ' V1CHSI-OPERACAO */
                    _.Display($"OPERACAO - {V1CHSI_OPERACAO}");

                    /*" -970- DISPLAY 'COD FUNC - ' GESISORL-COD-FUNCAO */
                    _.Display($"COD FUNC - {GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_FUNCAO}");

                    /*" -971- DISPLAY 'COD OPER - ' GESISORL-COD-OPERACAO */
                    _.Display($"COD OPER - {GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_OPERACAO}");

                    /*" -972- DISPLAY 'FUNC ASS - ' GESISORL-COD-FUNCAO-ASS */
                    _.Display($"FUNC ASS - {GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_FUNCAO_ASS}");

                    /*" -973- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -974- END-IF */
                }


                /*" -974- END-IF. */
            }


        }

        [StopWatch]
        /*" R0950-00-SELECT-GESISORL-DB-SELECT-1 */
        public void R0950_00_SELECT_GESISORL_DB_SELECT_1()
        {
            /*" -957- EXEC SQL SELECT COD_OPERACAO_ASS INTO :GESISORL-COD-OPERACAO-ASS FROM SEGUROS.GE_SIS_FUN_OPE_REL WHERE IDE_SISTEMA_FUNCAO = 'SI' AND COD_FUNCAO = :GESISORL-COD-FUNCAO AND IDE_SISTEMA_OPER = 'SI' AND COD_OPERACAO = :GESISORL-COD-OPERACAO AND IDE_SISTEMA_FC_ASS = 'AC' AND COD_FUNCAO_ASS = :GESISORL-COD-FUNCAO-ASS AND IDE_SISTEMA_OP_ASS = 'AC' WITH UR END-EXEC. */

            var r0950_00_SELECT_GESISORL_DB_SELECT_1_Query1 = new R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1()
            {
                GESISORL_COD_FUNCAO_ASS = GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_FUNCAO_ASS.ToString(),
                GESISORL_COD_OPERACAO = GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_OPERACAO.ToString(),
                GESISORL_COD_FUNCAO = GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_FUNCAO.ToString(),
            };

            var executed_1 = R0950_00_SELECT_GESISORL_DB_SELECT_1_Query1.Execute(r0950_00_SELECT_GESISORL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GESISORL_COD_OPERACAO_ASS, GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_OPERACAO_ASS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-SELECT-V0MESTSINI-SECTION */
        private void R1000_00_SELECT_V0MESTSINI_SECTION()
        {
            /*" -987- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -997- PERFORM R1000_00_SELECT_V0MESTSINI_DB_SELECT_1 */

            R1000_00_SELECT_V0MESTSINI_DB_SELECT_1();

            /*" -1000- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1001- DISPLAY 'R1000 - ERRO NO SELECT DA V0MESTSINI' */
                _.Display($"R1000 - ERRO NO SELECT DA V0MESTSINI");

                /*" -1002- DISPLAY 'COD EMPR - ' V1CHSI-COD-EMPR */
                _.Display($"COD EMPR - {V1CHSI_COD_EMPR}");

                /*" -1003- DISPLAY 'COD CONG - ' V1CHSI-CONGENER */
                _.Display($"COD CONG - {V1CHSI_CONGENER}");

                /*" -1004- DISPLAY 'SINISTRO - ' V1CHSI-NUM-SINI */
                _.Display($"SINISTRO - {V1CHSI_NUM_SINI}");

                /*" -1005- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1005- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-00-SELECT-V0MESTSINI-DB-SELECT-1 */
        public void R1000_00_SELECT_V0MESTSINI_DB_SELECT_1()
        {
            /*" -997- EXEC SQL SELECT NUM_APOL_SINISTRO, COD_MOEDA_SINI, NUM_APOLICE INTO :V0MSIN-NUM-SINISTRO, :V0MSIN-MOEDA-SINI, :V0MSIN-NUM-APOL FROM SEGUROS.V0MESTSINI WHERE NUM_APOL_SINISTRO = :V1CHSI-NUM-SINI WITH UR END-EXEC. */

            var r1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 = new R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1()
            {
                V1CHSI_NUM_SINI = V1CHSI_NUM_SINI.ToString(),
            };

            var executed_1 = R1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1.Execute(r1000_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MSIN_NUM_SINISTRO, V0MSIN_NUM_SINISTRO);
                _.Move(executed_1.V0MSIN_MOEDA_SINI, V0MSIN_MOEDA_SINI);
                _.Move(executed_1.V0MSIN_NUM_APOL, V0MSIN_NUM_APOL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-V0APOLICE-SECTION */
        private void R1050_00_SELECT_V0APOLICE_SECTION()
        {
            /*" -1018- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", WABEND.WNR_EXEC_SQL);

            /*" -1030- PERFORM R1050_00_SELECT_V0APOLICE_DB_SELECT_1 */

            R1050_00_SELECT_V0APOLICE_DB_SELECT_1();

            /*" -1033- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1034- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1035- PERFORM R1100-00-SELECT-SX010 */

                    R1100_00_SELECT_SX010_SECTION();

                    /*" -1036- ELSE */
                }
                else
                {


                    /*" -1037- DISPLAY 'R1050 - ERRO NO SELECT DA V0APOLICE' */
                    _.Display($"R1050 - ERRO NO SELECT DA V0APOLICE");

                    /*" -1038- DISPLAY 'COD EMPR - ' V1CHSI-COD-EMPR */
                    _.Display($"COD EMPR - {V1CHSI_COD_EMPR}");

                    /*" -1039- DISPLAY 'COD CONG - ' V1CHSI-CONGENER */
                    _.Display($"COD CONG - {V1CHSI_CONGENER}");

                    /*" -1040- DISPLAY 'SINISTRO - ' V1CHSI-NUM-SINI */
                    _.Display($"SINISTRO - {V1CHSI_NUM_SINI}");

                    /*" -1041- DISPLAY 'APOLICE  - ' V0MSIN-NUM-APOL */
                    _.Display($"APOLICE  - {V0MSIN_NUM_APOL}");

                    /*" -1042- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1043- END-IF */
                }


                /*" -1043- END-IF. */
            }


        }

        [StopWatch]
        /*" R1050-00-SELECT-V0APOLICE-DB-SELECT-1 */
        public void R1050_00_SELECT_V0APOLICE_DB_SELECT_1()
        {
            /*" -1030- EXEC SQL SELECT NUM_APOLICE, TIPSGU, ORGAO, RAMO INTO :V0APOL-NUM-APOL, :V0APOL-TIPSGU, :V0APOL-ORGAO, :V0APOL-RAMO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V0MSIN-NUM-APOL WITH UR END-EXEC. */

            var r1050_00_SELECT_V0APOLICE_DB_SELECT_1_Query1 = new R1050_00_SELECT_V0APOLICE_DB_SELECT_1_Query1()
            {
                V0MSIN_NUM_APOL = V0MSIN_NUM_APOL.ToString(),
            };

            var executed_1 = R1050_00_SELECT_V0APOLICE_DB_SELECT_1_Query1.Execute(r1050_00_SELECT_V0APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APOL_NUM_APOL, V0APOL_NUM_APOL);
                _.Move(executed_1.V0APOL_TIPSGU, V0APOL_TIPSGU);
                _.Move(executed_1.V0APOL_ORGAO, V0APOL_ORGAO);
                _.Move(executed_1.V0APOL_RAMO, V0APOL_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-SX010-SECTION */
        private void R1100_00_SELECT_SX010_SECTION()
        {
            /*" -1056- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -1077- PERFORM R1100_00_SELECT_SX010_DB_SELECT_1 */

            R1100_00_SELECT_SX010_DB_SELECT_1();

            /*" -1080- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1081- DISPLAY 'R1100 - ERRO NO SELECT DA SX_APOLICE' */
                _.Display($"R1100 - ERRO NO SELECT DA SX_APOLICE");

                /*" -1082- DISPLAY 'COD EMPR - ' V1CHSI-COD-EMPR */
                _.Display($"COD EMPR - {V1CHSI_COD_EMPR}");

                /*" -1083- DISPLAY 'COD CONG - ' V1CHSI-CONGENER */
                _.Display($"COD CONG - {V1CHSI_CONGENER}");

                /*" -1084- DISPLAY 'SINISTRO - ' V1CHSI-NUM-SINI */
                _.Display($"SINISTRO - {V1CHSI_NUM_SINI}");

                /*" -1085- DISPLAY 'APOLICE  - ' V0MSIN-NUM-APOL */
                _.Display($"APOLICE  - {V0MSIN_NUM_APOL}");

                /*" -1086- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1087- ELSE */
            }
            else
            {


                /*" -1088- MOVE SX010-NUM-APOLICE TO V0APOL-NUM-APOL */
                _.Move(SX010.DCLSX_APOLICE.SX010_NUM_APOLICE, V0APOL_NUM_APOL);

                /*" -1089- MOVE SX017-NUM-RAMO TO V0APOL-RAMO */
                _.Move(SX017.DCLSX_PRODUTO.SX017_NUM_RAMO, V0APOL_RAMO);

                /*" -1090- MOVE 010 TO V0APOL-ORGAO */
                _.Move(010, V0APOL_ORGAO);

                /*" -1091- MOVE '1' TO V0APOL-TIPSGU */
                _.Move("1", V0APOL_TIPSGU);

                /*" -1091- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-SX010-DB-SELECT-1 */
        public void R1100_00_SELECT_SX010_DB_SELECT_1()
        {
            /*" -1077- EXEC SQL SELECT DISTINCT VALUE (A.NUM_APOLICE,+0), A.DTA_APOLICE, A.COD_FONTE, C.NUM_RAMO, C.COD_PRODUTO INTO :SX010-NUM-APOLICE, :SX010-DTA-APOLICE, :SX010-COD-FONTE, :SX017-NUM-RAMO, :SX017-COD-PRODUTO FROM SEGUROS.SX_APOLICE A, SEGUROS.SX_ORIGEM_CONTRATO B, SEGUROS.SX_PRODUTO C WHERE A.NUM_APOLICE = :V0MSIN-NUM-APOL AND A.STA_APOLICE = 'A' AND B.SEQ_APOLICE = A.SEQ_PROP_APOL AND B.STA_ORIGEM_CONTRATO = 'A' AND C.COD_PRODUTO = B.COD_PRODUTO WITH UR END-EXEC. */

            var r1100_00_SELECT_SX010_DB_SELECT_1_Query1 = new R1100_00_SELECT_SX010_DB_SELECT_1_Query1()
            {
                V0MSIN_NUM_APOL = V0MSIN_NUM_APOL.ToString(),
            };

            var executed_1 = R1100_00_SELECT_SX010_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_SX010_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SX010_NUM_APOLICE, SX010.DCLSX_APOLICE.SX010_NUM_APOLICE);
                _.Move(executed_1.SX010_DTA_APOLICE, SX010.DCLSX_APOLICE.SX010_DTA_APOLICE);
                _.Move(executed_1.SX010_COD_FONTE, SX010.DCLSX_APOLICE.SX010_COD_FONTE);
                _.Move(executed_1.SX017_NUM_RAMO, SX017.DCLSX_PRODUTO.SX017_NUM_RAMO);
                _.Move(executed_1.SX017_COD_PRODUTO, SX017.DCLSX_PRODUTO.SX017_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-CALC-CORR-INDX-SECTION */
        private void R1150_00_CALC_CORR_INDX_SECTION()
        {
            /*" -1104- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", WABEND.WNR_EXEC_SQL);

            /*" -1106- IF GESISFUO-NUM-FATOR = -1 AND (GEOPERAC-IND-TIPO-FUNCAO = 'IN' OR 'JUR-INDENI' ) */

            if (GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR == -1 && (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("IN", "JUR-INDENI")))
            {

                /*" -1107- PERFORM R1200-00-SELECT-V1COSHISTSIN */

                R1200_00_SELECT_V1COSHISTSIN_SECTION();

                /*" -1108- ELSE */
            }
            else
            {


                /*" -1109- MOVE V1CHSI-DTMOVTO TO WHOST-DTMOVTO */
                _.Move(V1CHSI_DTMOVTO, WHOST_DTMOVTO);

                /*" -1111- END-IF. */
            }


            /*" -1112- MOVE V0MSIN-MOEDA-SINI TO V0COTA-CODUNIMO. */
            _.Move(V0MSIN_MOEDA_SINI, V0COTA_CODUNIMO);

            /*" -1114- MOVE WHOST-DTMOVTO TO V0COTA-DTINIVIG. */
            _.Move(WHOST_DTMOVTO, V0COTA_DTINIVIG);

            /*" -1116- PERFORM R0500-00-SELECT-V0COTACAO. */

            R0500_00_SELECT_V0COTACAO_SECTION();

            /*" -1118- MOVE V0COTA-VAL-VENDA TO WCOTACAO-SINI. */
            _.Move(V0COTA_VAL_VENDA, AREA_DE_WORK.WCOTACAO_SINI);

            /*" -1119- MOVE V0MSIN-MOEDA-SINI TO V0COTA-CODUNIMO. */
            _.Move(V0MSIN_MOEDA_SINI, V0COTA_CODUNIMO);

            /*" -1121- MOVE V0RELA-PERI-INI TO V0COTA-DTINIVIG. */
            _.Move(V0RELA_PERI_INI, V0COTA_DTINIVIG);

            /*" -1123- PERFORM R0500-00-SELECT-V0COTACAO. */

            R0500_00_SELECT_V0COTACAO_SECTION();

            /*" -1125- MOVE V0COTA-VAL-VENDA TO WCOTACAO-SOL-INDX. */
            _.Move(V0COTA_VAL_VENDA, AREA_DE_WORK.WCOTACAO_SOL_INDX);

            /*" -1128- COMPUTE WHOST-VAL-OPER-IX ROUNDED = V1CHSI-VAL-OPER / WCOTACAO-SINI. */
            WHOST_VAL_OPER_IX.Value = V1CHSI_VAL_OPER / AREA_DE_WORK.WCOTACAO_SINI;

            /*" -1131- COMPUTE V0CHSI-VAL-OPER ROUNDED = WHOST-VAL-OPER-IX * WCOTACAO-SOL-INDX. */
            V0CHSI_VAL_OPER.Value = WHOST_VAL_OPER_IX * AREA_DE_WORK.WCOTACAO_SOL_INDX;

            /*" -1133- MOVE WS-OP-CM-LIB TO WHOST-OPER-COR. */
            _.Move(AREA_DE_WORK.WS_OP_CM_LIB, WHOST_OPER_COR);

            /*" -1135- MOVE WS-OP-CM-PEND TO WHOST-OP-COR-PEND. */
            _.Move(AREA_DE_WORK.WS_OP_CM_PEND, WHOST_OP_COR_PEND);

            /*" -1137- PERFORM R1250-00-SELECT-V1COSHISTSIN. */

            R1250_00_SELECT_V1COSHISTSIN_SECTION();

            /*" -1139- COMPUTE WHOST-VAL-CORR = V0CHSI-VAL-OPER - V1CHSI-VAL-OPER - WHOST-VAL-COR-PEND. */
            WHOST_VAL_CORR.Value = V0CHSI_VAL_OPER - V1CHSI_VAL_OPER - WHOST_VAL_COR_PEND;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V1COSHISTSIN-SECTION */
        private void R1200_00_SELECT_V1COSHISTSIN_SECTION()
        {
            /*" -1152- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -1165- PERFORM R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1 */

            R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1();

            /*" -1168- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1169- DISPLAY 'R1200 - ERRO NO SELECT DA V1COSSEG-HISTSIN' */
                _.Display($"R1200 - ERRO NO SELECT DA V1COSSEG-HISTSIN");

                /*" -1170- DISPLAY 'COD EMPR - ' V1CHSI-COD-EMPR */
                _.Display($"COD EMPR - {V1CHSI_COD_EMPR}");

                /*" -1171- DISPLAY 'COD CONG - ' V1CHSI-CONGENER */
                _.Display($"COD CONG - {V1CHSI_CONGENER}");

                /*" -1172- DISPLAY 'SINISTRO - ' V1CHSI-NUM-SINI */
                _.Display($"SINISTRO - {V1CHSI_NUM_SINI}");

                /*" -1173- DISPLAY 'OC. HIST - ' V1CHSI-OCORHIST */
                _.Display($"OC. HIST - {V1CHSI_OCORHIST}");

                /*" -1174- DISPLAY 'IDE SIST - ' GESISFUO-IDE-SISTEMA */
                _.Display($"IDE SIST - {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA}");

                /*" -1175- DISPLAY 'COD FUNC - ' GESISFUO-COD-FUNCAO */
                _.Display($"COD FUNC - {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO}");

                /*" -1176- DISPLAY 'IDE SIST - ' GESISFUO-IDE-SISTEMA-OPER */
                _.Display($"IDE SIST - {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER}");

                /*" -1177- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1177- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V1COSHISTSIN-DB-SELECT-1 */
        public void R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1()
        {
            /*" -1165- EXEC SQL SELECT A.DTMOVTO INTO :WHOST-DTMOVTO FROM SEGUROS.V1COSSEG_HISTSIN A, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE A.CONGENER = :V1CHSI-CONGENER AND A.NUM_SINISTRO = :V1CHSI-NUM-SINI AND A.OCORHIST = :V1CHSI-OCORHIST AND B.IDE_SISTEMA = 'SI' AND B.COD_FUNCAO = :GESISORL-COD-FUNCAO AND B.IDE_SISTEMA_OPER = 'SI' AND B.COD_OPERACAO = A.OPERACAO AND B.NUM_FATOR = 1 END-EXEC. */

            var r1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1 = new R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1()
            {
                GESISORL_COD_FUNCAO = GESISORL.DCLGE_SIS_FUN_OPE_REL.GESISORL_COD_FUNCAO.ToString(),
                V1CHSI_CONGENER = V1CHSI_CONGENER.ToString(),
                V1CHSI_NUM_SINI = V1CHSI_NUM_SINI.ToString(),
                V1CHSI_OCORHIST = V1CHSI_OCORHIST.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTMOVTO, WHOST_DTMOVTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-SELECT-V1COSHISTSIN-SECTION */
        private void R1250_00_SELECT_V1COSHISTSIN_SECTION()
        {
            /*" -1190- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", WABEND.WNR_EXEC_SQL);

            /*" -1198- PERFORM R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1 */

            R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1();

            /*" -1201- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1202- DISPLAY 'R1250 - ERRO NO SELECT DA V1COSSEG-HISTSIN' */
                _.Display($"R1250 - ERRO NO SELECT DA V1COSSEG-HISTSIN");

                /*" -1203- DISPLAY 'COD EMPR - ' V1CHSI-COD-EMPR */
                _.Display($"COD EMPR - {V1CHSI_COD_EMPR}");

                /*" -1204- DISPLAY 'COD CONG - ' V1CHSI-CONGENER */
                _.Display($"COD CONG - {V1CHSI_CONGENER}");

                /*" -1205- DISPLAY 'SINISTRO - ' V1CHSI-NUM-SINI */
                _.Display($"SINISTRO - {V1CHSI_NUM_SINI}");

                /*" -1206- DISPLAY 'OC. HIST - ' V1CHSI-OCORHIST */
                _.Display($"OC. HIST - {V1CHSI_OCORHIST}");

                /*" -1207- DISPLAY 'OPERACAO - ' WHOST-OP-COR-PEND */
                _.Display($"OPERACAO - {WHOST_OP_COR_PEND}");

                /*" -1208- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1208- END-IF. */
            }


        }

        [StopWatch]
        /*" R1250-00-SELECT-V1COSHISTSIN-DB-SELECT-1 */
        public void R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1()
        {
            /*" -1198- EXEC SQL SELECT VALUE(SUM(VAL_OPERACAO),+0) INTO :WHOST-VAL-COR-PEND FROM SEGUROS.V1COSSEG_HISTSIN WHERE CONGENER = :V1CHSI-CONGENER AND NUM_SINISTRO = :V1CHSI-NUM-SINI AND OCORHIST = :V1CHSI-OCORHIST AND OPERACAO = :WHOST-OP-COR-PEND END-EXEC. */

            var r1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1 = new R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1()
            {
                WHOST_OP_COR_PEND = WHOST_OP_COR_PEND.ToString(),
                V1CHSI_CONGENER = V1CHSI_CONGENER.ToString(),
                V1CHSI_NUM_SINI = V1CHSI_NUM_SINI.ToString(),
                V1CHSI_OCORHIST = V1CHSI_OCORHIST.ToString(),
            };

            var executed_1 = R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1.Execute(r1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_VAL_COR_PEND, WHOST_VAL_COR_PEND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-CALC-CORR-NINDX-SECTION */
        private void R1300_00_CALC_CORR_NINDX_SECTION()
        {
            /*" -1221- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -1223- IF GESISFUO-NUM-FATOR = -1 AND (GEOPERAC-IND-TIPO-FUNCAO = 'IN' OR 'JUR-INDENI' ) */

            if (GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR == -1 && (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("IN", "JUR-INDENI")))
            {

                /*" -1224- PERFORM R1200-00-SELECT-V1COSHISTSIN */

                R1200_00_SELECT_V1COSHISTSIN_SECTION();

                /*" -1225- ELSE */
            }
            else
            {


                /*" -1226- MOVE V1CHSI-DTMOVTO TO WHOST-DTMOVTO */
                _.Move(V1CHSI_DTMOVTO, WHOST_DTMOVTO);

                /*" -1228- END-IF. */
            }


            /*" -1229- MOVE V0RELA-CODUNIMO TO V0COTA-CODUNIMO. */
            _.Move(V0RELA_CODUNIMO, V0COTA_CODUNIMO);

            /*" -1231- MOVE WHOST-DTMOVTO TO V0COTA-DTINIVIG. */
            _.Move(WHOST_DTMOVTO, V0COTA_DTINIVIG);

            /*" -1233- PERFORM R0500-00-SELECT-V0COTACAO. */

            R0500_00_SELECT_V0COTACAO_SECTION();

            /*" -1235- MOVE V0COTA-VAL-VENDA TO WCOTACAO-SINI. */
            _.Move(V0COTA_VAL_VENDA, AREA_DE_WORK.WCOTACAO_SINI);

            /*" -1236- MOVE V0RELA-CODUNIMO TO V0COTA-CODUNIMO. */
            _.Move(V0RELA_CODUNIMO, V0COTA_CODUNIMO);

            /*" -1238- MOVE V0RELA-PERI-INI TO V0COTA-DTINIVIG. */
            _.Move(V0RELA_PERI_INI, V0COTA_DTINIVIG);

            /*" -1240- PERFORM R0500-00-SELECT-V0COTACAO. */

            R0500_00_SELECT_V0COTACAO_SECTION();

            /*" -1242- MOVE V0COTA-VAL-VENDA TO WCOTACAO-SOL-INDX. */
            _.Move(V0COTA_VAL_VENDA, AREA_DE_WORK.WCOTACAO_SOL_INDX);

            /*" -1245- COMPUTE WHOST-VAL-OPER-IX ROUNDED = V1CHSI-VAL-OPER / WCOTACAO-SINI. */
            WHOST_VAL_OPER_IX.Value = V1CHSI_VAL_OPER / AREA_DE_WORK.WCOTACAO_SINI;

            /*" -1248- COMPUTE V0CHSI-VAL-OPER ROUNDED = WHOST-VAL-OPER-IX * WCOTACAO-SOL-INDX. */
            V0CHSI_VAL_OPER.Value = WHOST_VAL_OPER_IX * AREA_DE_WORK.WCOTACAO_SOL_INDX;

            /*" -1250- MOVE WS-OP-CM-LIB TO WHOST-OPER-COR. */
            _.Move(AREA_DE_WORK.WS_OP_CM_LIB, WHOST_OPER_COR);

            /*" -1252- MOVE WS-OP-CM-PEND TO WHOST-OP-COR-PEND. */
            _.Move(AREA_DE_WORK.WS_OP_CM_PEND, WHOST_OP_COR_PEND);

            /*" -1254- PERFORM R1250-00-SELECT-V1COSHISTSIN. */

            R1250_00_SELECT_V1COSHISTSIN_SECTION();

            /*" -1256- COMPUTE WHOST-VAL-CORR = V0CHSI-VAL-OPER - V1CHSI-VAL-OPER - WHOST-VAL-COR-PEND. */
            WHOST_VAL_CORR.Value = V0CHSI_VAL_OPER - V1CHSI_VAL_OPER - WHOST_VAL_COR_PEND;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-UPDATE-V0COSHISTSIN-SECTION */
        private void R1400_00_UPDATE_V0COSHISTSIN_SECTION()
        {
            /*" -1269- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -1278- PERFORM R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1 */

            R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1();

            /*" -1281- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1282- DISPLAY 'R1400 - ERRO NO UPDATE DA V0COSSEG-HISTSIN' */
                _.Display($"R1400 - ERRO NO UPDATE DA V0COSSEG-HISTSIN");

                /*" -1283- DISPLAY 'COD EMPR - ' V1CHSI-COD-EMPR */
                _.Display($"COD EMPR - {V1CHSI_COD_EMPR}");

                /*" -1284- DISPLAY 'COD CONG - ' V1CHSI-CONGENER */
                _.Display($"COD CONG - {V1CHSI_CONGENER}");

                /*" -1285- DISPLAY 'SINISTRO - ' V1CHSI-NUM-SINI */
                _.Display($"SINISTRO - {V1CHSI_NUM_SINI}");

                /*" -1286- DISPLAY 'OCR HIST - ' V1CHSI-OCORHIST */
                _.Display($"OCR HIST - {V1CHSI_OCORHIST}");

                /*" -1287- DISPLAY 'OPERACAO - ' V1CHSI-OPERACAO */
                _.Display($"OPERACAO - {V1CHSI_OPERACAO}");

                /*" -1288- DISPLAY 'DT MOVTO - ' V1CHSI-DTMOVTO */
                _.Display($"DT MOVTO - {V1CHSI_DTMOVTO}");

                /*" -1289- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1289- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-UPDATE-V0COSHISTSIN-DB-UPDATE-1 */
        public void R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1()
        {
            /*" -1278- EXEC SQL UPDATE SEGUROS.V0COSSEG_HISTSIN SET SIT_LIBRECUP = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE CONGENER = :V1CHSI-CONGENER AND NUM_SINISTRO = :V1CHSI-NUM-SINI AND OCORHIST = :V1CHSI-OCORHIST AND DTMOVTO = :V1CHSI-DTMOVTO AND OPERACAO = :V1CHSI-OPERACAO END-EXEC. */

            var r1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1 = new R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1()
            {
                V1CHSI_CONGENER = V1CHSI_CONGENER.ToString(),
                V1CHSI_NUM_SINI = V1CHSI_NUM_SINI.ToString(),
                V1CHSI_OCORHIST = V1CHSI_OCORHIST.ToString(),
                V1CHSI_OPERACAO = V1CHSI_OPERACAO.ToString(),
                V1CHSI_DTMOVTO = V1CHSI_DTMOVTO.ToString(),
            };

            R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1.Execute(r1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-INSERT-V0COSHISTSIN-SECTION */
        private void R1500_00_INSERT_V0COSHISTSIN_SECTION()
        {
            /*" -1302- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -1315- PERFORM R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1 */

            R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1();

            /*" -1318- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1319- DISPLAY 'R1500 - ERRO NO INSERT DA V0COSSEG_HISTSIN' */
                _.Display($"R1500 - ERRO NO INSERT DA V0COSSEG_HISTSIN");

                /*" -1320- DISPLAY 'COD EMPR - ' V1CHSI-COD-EMPR */
                _.Display($"COD EMPR - {V1CHSI_COD_EMPR}");

                /*" -1321- DISPLAY 'COD CONG - ' V1CHSI-CONGENER */
                _.Display($"COD CONG - {V1CHSI_CONGENER}");

                /*" -1322- DISPLAY 'SINISTRO - ' V1CHSI-NUM-SINI */
                _.Display($"SINISTRO - {V1CHSI_NUM_SINI}");

                /*" -1323- DISPLAY 'OCR HIST - ' V1CHSI-OCORHIST */
                _.Display($"OCR HIST - {V1CHSI_OCORHIST}");

                /*" -1324- DISPLAY 'OPERACAO - ' V0CHSI-OPERACAO */
                _.Display($"OPERACAO - {V0CHSI_OPERACAO}");

                /*" -1325- DISPLAY 'DT MOVTO - ' V0SIST-DTMOVABE */
                _.Display($"DT MOVTO - {V0SIST_DTMOVABE}");

                /*" -1326- DISPLAY 'VLR OPER - ' V1CHSI-VAL-OPER */
                _.Display($"VLR OPER - {V1CHSI_VAL_OPER}");

                /*" -1327- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1328- ELSE */
            }
            else
            {


                /*" -1329- ADD 1 TO AC-I-V0COSHISTSIN */
                AREA_DE_WORK.AC_I_V0COSHISTSIN.Value = AREA_DE_WORK.AC_I_V0COSHISTSIN + 1;

                /*" -1329- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-INSERT-V0COSHISTSIN-DB-INSERT-1 */
        public void R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1()
        {
            /*" -1315- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTSIN VALUES (:V1CHSI-COD-EMPR , :V1CHSI-CONGENER , :V1CHSI-NUM-SINI , :V1CHSI-OCORHIST , :V0CHSI-OPERACAO , :V0SIST-DTMOVABE , :V0CHSI-VAL-OPER , CURRENT TIMESTAMP , '1' , :V1CHSI-TIPSGU:VIND-TIP-SEGR, :V1CHSI-SIT-LIBREC:VIND-SIT-LIBR) END-EXEC. */

            var r1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1 = new R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1()
            {
                V1CHSI_COD_EMPR = V1CHSI_COD_EMPR.ToString(),
                V1CHSI_CONGENER = V1CHSI_CONGENER.ToString(),
                V1CHSI_NUM_SINI = V1CHSI_NUM_SINI.ToString(),
                V1CHSI_OCORHIST = V1CHSI_OCORHIST.ToString(),
                V0CHSI_OPERACAO = V0CHSI_OPERACAO.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
                V0CHSI_VAL_OPER = V0CHSI_VAL_OPER.ToString(),
                V1CHSI_TIPSGU = V1CHSI_TIPSGU.ToString(),
                VIND_TIP_SEGR = VIND_TIP_SEGR.ToString(),
                V1CHSI_SIT_LIBREC = V1CHSI_SIT_LIBREC.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
            };

            R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1.Execute(r1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-INSERT-V0COSHISTSIN-SECTION */
        private void R1600_00_INSERT_V0COSHISTSIN_SECTION()
        {
            /*" -1342- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -1355- PERFORM R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1 */

            R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1();

            /*" -1358- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1359- DISPLAY 'R1600 - ERRO NO INSERT DA V0COSSEG_HISTSIN' */
                _.Display($"R1600 - ERRO NO INSERT DA V0COSSEG_HISTSIN");

                /*" -1360- DISPLAY 'COD EMPR - ' V1CHSI-COD-EMPR */
                _.Display($"COD EMPR - {V1CHSI_COD_EMPR}");

                /*" -1361- DISPLAY 'COD CONG - ' V1CHSI-CONGENER */
                _.Display($"COD CONG - {V1CHSI_CONGENER}");

                /*" -1362- DISPLAY 'SINISTRO - ' V1CHSI-NUM-SINI */
                _.Display($"SINISTRO - {V1CHSI_NUM_SINI}");

                /*" -1363- DISPLAY 'OCR HIST - ' V1CHSI-OCORHIST */
                _.Display($"OCR HIST - {V1CHSI_OCORHIST}");

                /*" -1364- DISPLAY 'OPERACAO - ' WHOST-OPER-COR */
                _.Display($"OPERACAO - {WHOST_OPER_COR}");

                /*" -1365- DISPLAY 'DT MOVTO - ' V0SIST-DTMOVABE */
                _.Display($"DT MOVTO - {V0SIST_DTMOVABE}");

                /*" -1366- DISPLAY 'VLR OPER - ' V1CHSI-VAL-OPER */
                _.Display($"VLR OPER - {V1CHSI_VAL_OPER}");

                /*" -1367- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1368- ELSE */
            }
            else
            {


                /*" -1369- ADD 1 TO AC-I-V0COSHISTSIN */
                AREA_DE_WORK.AC_I_V0COSHISTSIN.Value = AREA_DE_WORK.AC_I_V0COSHISTSIN + 1;

                /*" -1369- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-INSERT-V0COSHISTSIN-DB-INSERT-1 */
        public void R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1()
        {
            /*" -1355- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTSIN VALUES (:V1CHSI-COD-EMPR , :V1CHSI-CONGENER , :V1CHSI-NUM-SINI , :V1CHSI-OCORHIST , :WHOST-OPER-COR , :V0SIST-DTMOVABE , :WHOST-VAL-CORR , CURRENT TIMESTAMP , :V1CHSI-SITUACAO:VIND-SIT-REGT, :V1CHSI-TIPSGU:VIND-TIP-SEGR, :V1CHSI-SIT-LIBREC:VIND-SIT-LIBR) END-EXEC. */

            var r1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1 = new R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1()
            {
                V1CHSI_COD_EMPR = V1CHSI_COD_EMPR.ToString(),
                V1CHSI_CONGENER = V1CHSI_CONGENER.ToString(),
                V1CHSI_NUM_SINI = V1CHSI_NUM_SINI.ToString(),
                V1CHSI_OCORHIST = V1CHSI_OCORHIST.ToString(),
                WHOST_OPER_COR = WHOST_OPER_COR.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
                WHOST_VAL_CORR = WHOST_VAL_CORR.ToString(),
                V1CHSI_SITUACAO = V1CHSI_SITUACAO.ToString(),
                VIND_SIT_REGT = VIND_SIT_REGT.ToString(),
                V1CHSI_TIPSGU = V1CHSI_TIPSGU.ToString(),
                VIND_TIP_SEGR = VIND_TIP_SEGR.ToString(),
                V1CHSI_SIT_LIBREC = V1CHSI_SIT_LIBREC.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
            };

            R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1.Execute(r1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-SELECT-V0HISTSINI-SECTION */
        private void R1700_00_SELECT_V0HISTSINI_SECTION()
        {
            /*" -1382- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", WABEND.WNR_EXEC_SQL);

            /*" -1390- PERFORM R1700_00_SELECT_V0HISTSINI_DB_SELECT_1 */

            R1700_00_SELECT_V0HISTSINI_DB_SELECT_1();

            /*" -1393- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1394- DISPLAY 'R1700 - ERRO NO SELECT DA V0HISTSINI' */
                _.Display($"R1700 - ERRO NO SELECT DA V0HISTSINI");

                /*" -1395- DISPLAY 'COD EMPR - ' V1CHSI-COD-EMPR */
                _.Display($"COD EMPR - {V1CHSI_COD_EMPR}");

                /*" -1396- DISPLAY 'COD CONG - ' V1CHSI-CONGENER */
                _.Display($"COD CONG - {V1CHSI_CONGENER}");

                /*" -1397- DISPLAY 'SINISTRO - ' V1CHSI-NUM-SINI */
                _.Display($"SINISTRO - {V1CHSI_NUM_SINI}");

                /*" -1398- DISPLAY 'OPERACAO - ' V0HSIN-OPERACAO */
                _.Display($"OPERACAO - {V0HSIN_OPERACAO}");

                /*" -1399- DISPLAY 'OCORHIST - ' V1CHSI-OCORHIST */
                _.Display($"OCORHIST - {V1CHSI_OCORHIST}");

                /*" -1400- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1400- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-V0HISTSINI-DB-SELECT-1 */
        public void R1700_00_SELECT_V0HISTSINI_DB_SELECT_1()
        {
            /*" -1390- EXEC SQL SELECT VAL_OPERACAO INTO :V0HSIN-VAL-OPER FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V1CHSI-NUM-SINI AND OPERACAO = :V0HSIN-OPERACAO AND OCORHIST = :V1CHSI-OCORHIST WITH UR END-EXEC. */

            var r1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 = new R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1()
            {
                V1CHSI_NUM_SINI = V1CHSI_NUM_SINI.ToString(),
                V0HSIN_OPERACAO = V0HSIN_OPERACAO.ToString(),
                V1CHSI_OCORHIST = V1CHSI_OCORHIST.ToString(),
            };

            var executed_1 = R1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1.Execute(r1700_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HSIN_VAL_OPER, V0HSIN_VAL_OPER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-COSCED-CHEQUE-SECTION */
        private void R1800_00_SELECT_COSCED_CHEQUE_SECTION()
        {
            /*" -1413- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", WABEND.WNR_EXEC_SQL);

            /*" -1422- PERFORM R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1 */

            R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1();

            /*" -1425- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1426- DISPLAY 'R1800 - ERRO NO SELECT DA V0COSCED-CHEQUE' */
                _.Display($"R1800 - ERRO NO SELECT DA V0COSCED-CHEQUE");

                /*" -1427- DISPLAY 'COD EMPRESA - ' V0RELA-COD-EMPR */
                _.Display($"COD EMPRESA - {V0RELA_COD_EMPR}");

                /*" -1428- DISPLAY 'COD CONGENR - ' V0RELA-CONGENER */
                _.Display($"COD CONGENR - {V0RELA_CONGENER}");

                /*" -1429- DISPLAY 'DAT MOVT AC - ' V0RELA-DATA-SOL */
                _.Display($"DAT MOVT AC - {V0RELA_DATA_SOL}");

                /*" -1430- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1430- END-IF. */
            }


        }

        [StopWatch]
        /*" R1800-00-SELECT-COSCED-CHEQUE-DB-SELECT-1 */
        public void R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1()
        {
            /*" -1422- EXEC SQL SELECT OUTRDEBIT, OUTRCREDT INTO :WHOST-OUTRDEBIT, :WHOST-OUTRCREDT FROM SEGUROS.V0COSCED_CHEQUE WHERE COD_EMPRESA = :V0RELA-COD-EMPR AND CONGENER = :V0RELA-CONGENER AND DTMOVTO_AC = :V0RELA-DATA-SOL END-EXEC. */

            var r1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 = new R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1()
            {
                V0RELA_COD_EMPR = V0RELA_COD_EMPR.ToString(),
                V0RELA_CONGENER = V0RELA_CONGENER.ToString(),
                V0RELA_DATA_SOL = V0RELA_DATA_SOL.ToString(),
            };

            var executed_1 = R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_OUTRDEBIT, WHOST_OUTRDEBIT);
                _.Move(executed_1.WHOST_OUTRCREDT, WHOST_OUTRCREDT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-UPDATE-COSCED-CHEQUE-SECTION */
        private void R2000_00_UPDATE_COSCED_CHEQUE_SECTION()
        {
            /*" -1443- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -1455- PERFORM R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1 */

            R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1();

            /*" -1458- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1459- DISPLAY 'R2000 - ERRO NO UPDATE DA V0COSCED-CHEQUE' */
                _.Display($"R2000 - ERRO NO UPDATE DA V0COSCED-CHEQUE");

                /*" -1460- DISPLAY 'COD EMPRESA - ' V0RELA-COD-EMPR */
                _.Display($"COD EMPRESA - {V0RELA_COD_EMPR}");

                /*" -1461- DISPLAY 'COD CONGENR - ' V0RELA-CONGENER */
                _.Display($"COD CONGENR - {V0RELA_CONGENER}");

                /*" -1462- DISPLAY 'DAT MOVT AC - ' V0RELA-DATA-SOL */
                _.Display($"DAT MOVT AC - {V0RELA_DATA_SOL}");

                /*" -1463- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1463- END-IF. */
            }


        }

        [StopWatch]
        /*" R2000-00-UPDATE-COSCED-CHEQUE-DB-UPDATE-1 */
        public void R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1()
        {
            /*" -1455- EXEC SQL UPDATE SEGUROS.V0COSCED_CHEQUE SET VLRSINI = :V0CCHQ-VLRSINI, VLDESPESA = :V0CCHQ-VLDESPESA, VLRHONOR = :V0CCHQ-VLRHONOR, VLRSALVD = :V0CCHQ-VLRSALVD, VLRESSARC = :V0CCHQ-VLRESSARC, OUTRDEBIT = :V0CCHQ-OUTRDEBIT, OUTRCREDT = :V0CCHQ-OUTRCREDT WHERE COD_EMPRESA = :V0RELA-COD-EMPR AND CONGENER = :V0RELA-CONGENER AND DTMOVTO_AC = :V0RELA-DATA-SOL END-EXEC. */

            var r2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1 = new R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1()
            {
                V0CCHQ_VLDESPESA = V0CCHQ_VLDESPESA.ToString(),
                V0CCHQ_VLRESSARC = V0CCHQ_VLRESSARC.ToString(),
                V0CCHQ_OUTRDEBIT = V0CCHQ_OUTRDEBIT.ToString(),
                V0CCHQ_OUTRCREDT = V0CCHQ_OUTRCREDT.ToString(),
                V0CCHQ_VLRHONOR = V0CCHQ_VLRHONOR.ToString(),
                V0CCHQ_VLRSALVD = V0CCHQ_VLRSALVD.ToString(),
                V0CCHQ_VLRSINI = V0CCHQ_VLRSINI.ToString(),
                V0RELA_COD_EMPR = V0RELA_COD_EMPR.ToString(),
                V0RELA_CONGENER = V0RELA_CONGENER.ToString(),
                V0RELA_DATA_SOL = V0RELA_DATA_SOL.ToString(),
            };

            R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1.Execute(r2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-DELETE-V0RELATORIOS-SECTION */
        private void R2100_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -1476- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -1484- PERFORM R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -1487- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1489- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1490- ELSE */
                }
                else
                {


                    /*" -1491- DISPLAY 'R2100 - ERRO NO DELETE DA V0RELATORIOS' */
                    _.Display($"R2100 - ERRO NO DELETE DA V0RELATORIOS");

                    /*" -1492- DISPLAY 'COD USUARIO - ' V0RELA-COD-USU */
                    _.Display($"COD USUARIO - {V0RELA_COD_USU}");

                    /*" -1493- DISPLAY 'DAT SOLICIT - ' V0RELA-DATA-SOL */
                    _.Display($"DAT SOLICIT - {V0RELA_DATA_SOL}");

                    /*" -1494- DISPLAY 'IDE SISTEMA - ' V0RELA-IDSISTEM */
                    _.Display($"IDE SISTEMA - {V0RELA_IDSISTEM}");

                    /*" -1495- DISPLAY 'COD RELAT   - ' V0RELA-CODRELAT */
                    _.Display($"COD RELAT   - {V0RELA_CODRELAT}");

                    /*" -1496- DISPLAY 'CONGENERE   - ' V0RELA-CONGENER */
                    _.Display($"CONGENERE   - {V0RELA_CONGENER}");

                    /*" -1497- DISPLAY 'COD EMPRESA - ' V0RELA-COD-EMPR */
                    _.Display($"COD EMPRESA - {V0RELA_COD_EMPR}");

                    /*" -1498- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1499- END-IF */
                }


                /*" -1499- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -1484- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODUSU = :V0RELA-COD-USU AND DATA_SOLICITACAO = :V0RELA-DATA-SOL AND IDSISTEM = :V0RELA-IDSISTEM AND CODRELAT = :V0RELA-CODRELAT AND CONGENER = :V0RELA-CONGENER AND COD_EMPRESA = :V0RELA-COD-EMPR END-EXEC. */

            var r2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
                V0RELA_COD_USU = V0RELA_COD_USU.ToString(),
                V0RELA_DATA_SOL = V0RELA_DATA_SOL.ToString(),
                V0RELA_IDSISTEM = V0RELA_IDSISTEM.ToString(),
                V0RELA_CODRELAT = V0RELA_CODRELAT.ToString(),
                V0RELA_CONGENER = V0RELA_CONGENER.ToString(),
                V0RELA_COD_EMPR = V0RELA_COD_EMPR.ToString(),
            };

            R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(r2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLICIT-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLICIT_SECTION()
        {
            /*" -1512- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -1513- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1514- DISPLAY '*   AC0816B - SINISTROS DE COSSEGURO       *' . */
            _.Display($"*   AC0816B - SINISTROS DE COSSEGURO       *");

            /*" -1515- DISPLAY '*   -------   ----------------------       *' . */
            _.Display($"*   -------   ----------------------       *");

            /*" -1516- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1517- DISPLAY '*    NAO HOUVE SOLICITACAO  NESTA DATA     *' . */
            _.Display($"*    NAO HOUVE SOLICITACAO  NESTA DATA     *");

            /*" -1518- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1518- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1531- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -1532- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1533- DISPLAY '*   AC0816B - COSSEGURO DE SINISTROS       *' . */
            _.Display($"*   AC0816B - COSSEGURO DE SINISTROS       *");

            /*" -1534- DISPLAY '*   -------   ----------------------       *' . */
            _.Display($"*   -------   ----------------------       *");

            /*" -1535- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1536- DISPLAY '*    NAO HOUVE MOVIMENTACAO NESTA DATA     *' . */
            _.Display($"*    NAO HOUVE MOVIMENTACAO NESTA DATA     *");

            /*" -1537- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1537- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1551- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1553- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1553- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1557- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1557- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}