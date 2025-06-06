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
using Sias.Cosseguro.DB2.AC0820B;

namespace Code
{
    public class AC0820B
    {
        public bool IsCall { get; set; }

        public AC0820B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0820B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  GILSON                             *      */
        /*"      *   PROGRAMADOR.............  WELLINGTON FRC VERAS               *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO/2018                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  PAGAMENTO DE COSSEGURO CEDIDO A    *      */
        /*"      *                             CONGENERE (5193 - PREVISUL)        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V0SISTEMA         INPUT    *      */
        /*"      * EMPRESAS                            V0EMPRESA         INPUT    *      */
        /*"      * COSSEGCED_CHEQUE                    V0COSCED-CHEQUE   INPUT    *      */
        /*"      * APOLICES                            V0APOLICE         INPUT    *      */
        /*"      * CONGENERES                          V0CONGENERE       INPUT    *      */
        /*"      * COSSEGURO_HIST_PRE                  V0COSSEG_HISTPRE  INPUT    *      */
        /*"      * COSSEGURO_HIST_SIN                  V0COSSEG_HISTSIN  INPUT    *      */
        /*"      * SINISTRO_MESTRE                     V0MESTSINI        INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - ALTERAR O PROGRAMA PARA TRATAR/GERAR O ARQUIVO POR*      */
        /*"      *              EMPRESAS DO GRUPO CAIXA SEGUROS                   *      */
        /*"      * 18/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - ALTERAR O PROGRAMA PARA FAZER AJUSTE DO VALOR DO  *      */
        /*"      *              SALDO FINANCEIRO DO MES ANTERIOR                  *      */
        /*"      * 05/11/2020 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 264008 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _AC0820B1 { get; set; } = new FileBasis(new PIC("X", "140", "X(140)"));

        public FileBasis AC0820B1
        {
            get
            {
                _.Move(REG_AC0820B1, _AC0820B1); VarBasis.RedefinePassValue(REG_AC0820B1, _AC0820B1, REG_AC0820B1); return _AC0820B1;
            }
        }
        public FileBasis _AC0820B2 { get; set; } = new FileBasis(new PIC("X", "140", "X(140)"));

        public FileBasis AC0820B2
        {
            get
            {
                _.Move(REG_AC0820B2, _AC0820B2); VarBasis.RedefinePassValue(REG_AC0820B2, _AC0820B2, REG_AC0820B2); return _AC0820B2;
            }
        }
        public FileBasis _AC0820B3 { get; set; } = new FileBasis(new PIC("X", "140", "X(140)"));

        public FileBasis AC0820B3
        {
            get
            {
                _.Move(REG_AC0820B3, _AC0820B3); VarBasis.RedefinePassValue(REG_AC0820B3, _AC0820B3, REG_AC0820B3); return _AC0820B3;
            }
        }
        /*"01              REG-AC0820B1       PIC  X(140).*/
        public StringBasis REG_AC0820B1 { get; set; } = new StringBasis(new PIC("X", "140", "X(140)."), @"");
        /*"01              REG-AC0820B2       PIC  X(140).*/
        public StringBasis REG_AC0820B2 { get; set; } = new StringBasis(new PIC("X", "140", "X(140)."), @"");
        /*"01              REG-AC0820B3       PIC  X(140).*/
        public StringBasis REG_AC0820B3 { get; set; } = new StringBasis(new PIC("X", "140", "X(140)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77        WHOST-COD-RAMO       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis WHOST_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0SIST-DTMOVABE-AC   PIC  X(010)       VALUE SPACES.*/
        public StringBasis V0SIST_DTMOVABE_AC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0SIST-DTMOVABE-FI   PIC  X(010)       VALUE SPACES.*/
        public StringBasis V0SIST_DTMOVABE_FI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0SIST-DTCURRENT     PIC  X(010)       VALUE SPACES.*/
        public StringBasis V0SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0EMPR-COD-EMP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V0EMPR-NOM-EMP       PIC  X(040)       VALUE SPACES.*/
        public StringBasis V0EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"77        V0EMPR-CGCCPF        PIC S9(015)       VALUE +0 COMP-3*/
        public IntBasis V0EMPR_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77        V0CCCH-COD-EMPR      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0CCCH_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V0CCCH-CONGENER      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0CCCH_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0CCCH-DTMOVTAC      PIC  X(010)       VALUE SPACES.*/
        public StringBasis V0CCCH_DTMOVTAC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0CCCH-DTLIBERA      PIC  X(010)       VALUE SPACES.*/
        public StringBasis V0CCCH_DTLIBERA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0CCCH-VLPREMIO      PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CCCH_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CCCH-VLRSINI       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CCCH_VLRSINI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CCCH-VLDESPESA     PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CCCH_VLDESPESA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CCCH-VLRHONOR      PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CCCH_VLRHONOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CCCH-VLRSALVD      PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CCCH_VLRSALVD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CCCH-VLRESSARC     PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CCCH_VLRESSARC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CCCH-VLDESPADM     PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CCCH_VLDESPADM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CCCH-OUTRDEBIT     PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CCCH_OUTRDEBIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CCCH-OUTRCREDT     PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CCCH_OUTRCREDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CCCH-VLRSLDANT     PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CCCH_VLRSLDANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CCCH-SITUACAO      PIC  X(001)       VALUE SPACES.*/
        public StringBasis V0CCCH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77        V0CCCH-DTMOVTFI      PIC  X(010)       VALUE SPACES.*/
        public StringBasis V0CCCH_DTMOVTFI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0CONG-CONGENER      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0CONG_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0CONG-NOMECONG      PIC  X(040)       VALUE SPACES.*/
        public StringBasis V0CONG_NOMECONG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"77        V0MEST-NUM-SINI      PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0MEST_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77        V0MEST-RAMO          PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0CHSP-NUM-APOL      PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0CHSP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77        V0CHSP-NRENDOS       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0CHSP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        V0CHSP-NRPARCEL      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0CHSP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0CHSP-OCORHIST      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0CHSP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0CHSP-OPERACAO      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0CHSP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0CHSP-DTMOVTO       PIC  X(010)       VALUE SPACES.*/
        public StringBasis V0CHSP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0CHSP-PRM-TAR       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CHSP_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CHSP-VAL-DESC      PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CHSP_VAL_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CHSP-VLPRMLIQ      PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CHSP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CHSP-VLADIFRA      PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CHSP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CHSP-VLCOMIS       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CHSP_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CHSP-VLPRMTOT      PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CHSP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        V0CHIS-NUM-SINI      PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0CHIS_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77        V0CHIS-OCORHIST      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0CHIS_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0CHIS-OPERACAO      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0CHIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        V0CHIS-DTMOVTO       PIC  X(010)       VALUE SPACES.*/
        public StringBasis V0CHIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77        V0CHIS-VAL-OPER      PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0CHIS_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01        AREA-DE-WORK.*/
        public AC0820B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0820B_AREA_DE_WORK();
        public class AC0820B_AREA_DE_WORK : VarBasis
        {
            /*"  05      WSTATUS              PIC  9(002)       VALUE ZEROS.*/
            public IntBasis WSTATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WFIM-V0COSCEDCHQ     PIC  X(001)       VALUE SPACES.*/
            public StringBasis WFIM_V0COSCEDCHQ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-V0COSSEGCED     PIC  X(001)       VALUE SPACES.*/
            public StringBasis WFIM_V0COSSEGCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-V0COSHISPRE     PIC  X(001)       VALUE SPACES.*/
            public StringBasis WFIM_V0COSHISPRE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-V0COSHISSIN     PIC  X(001)       VALUE SPACES.*/
            public StringBasis WFIM_V0COSHISSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      AC-L-V0COSCEDCHQ     PIC  9(006)       VALUE ZEROS.*/
            public IntBasis AC_L_V0COSCEDCHQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      AC-L-V0COSSEGCED     PIC  9(006)       VALUE ZEROS.*/
            public IntBasis AC_L_V0COSSEGCED { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      AC-L-V0COSHISPRE     PIC  9(006)       VALUE ZEROS.*/
            public IntBasis AC_L_V0COSHISPRE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      AC-L-V0COSHISSIN     PIC  9(006)       VALUE ZEROS.*/
            public IntBasis AC_L_V0COSHISSIN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      WCOD-EMPR-ANT        PIC S9(009)       VALUE +0 COMP.*/
            public IntBasis WCOD_EMPR_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05      WCOD-CONG-ANT        PIC S9(004)       VALUE +0 COMP.*/
            public IntBasis WCOD_CONG_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      WCOD-RAMO-ANT        PIC S9(004)       VALUE +0 COMP.*/
            public IntBasis WCOD_RAMO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      WS-PREMIO-P          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WS_PREMIO_P { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WS-COMISS-P          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WS_COMISS_P { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WS-PREMIO-R          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WS_PREMIO_R { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WS-COMISS-R          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WS_COMISS_R { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WS-VLR-SINI          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WS_VLR_SINI { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WS-TOT-TITL          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WS_TOT_TITL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WS-TOT-CONG          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WS_TOT_CONG { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WPREM-SQG-P          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WPREM_SQG_P { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WPREM-SQG-R          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WPREM_SQG_R { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WCOMS-SQG-T          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WCOMS_SQG_T { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WPREM-PRT-P          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WPREM_PRT_P { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WPREM-PRT-R          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WPREM_PRT_R { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WCOMS-PRT-T          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WCOMS_PRT_T { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WPREM-DIT-P          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WPREM_DIT_P { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WPREM-DIT-R          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WPREM_DIT_R { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WCOMS-DIT-T          PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WCOMS_DIT_T { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WVLR-SIN-SQG         PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WVLR_SIN_SQG { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WVLR-SIN-PRT         PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WVLR_SIN_PRT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WVLR-SIN-DIT         PIC S9(015)V99    VALUE +0 COMP-3*/
            public DoubleBasis WVLR_SIN_DIT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05      WDATA-AUX.*/
            public AC0820B_WDATA_AUX WDATA_AUX { get; set; } = new AC0820B_WDATA_AUX();
            public class AC0820B_WDATA_AUX : VarBasis
            {
                /*"    10    WDATA-AA-AUX         PIC  9(004)       VALUE ZEROS.*/
                public IntBasis WDATA_AA_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    FILLER               PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDATA-MM-AUX         PIC  9(002)       VALUE ZEROS.*/
                public IntBasis WDATA_MM_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER               PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDATA-DD-AUX         PIC  9(002)       VALUE ZEROS.*/
                public IntBasis WDATA_DD_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      WDATA-EDIT.*/
            }
            public AC0820B_WDATA_EDIT WDATA_EDIT { get; set; } = new AC0820B_WDATA_EDIT();
            public class AC0820B_WDATA_EDIT : VarBasis
            {
                /*"    10    WDATA-DD-EDT         PIC  9(002)       VALUE ZEROS.*/
                public IntBasis WDATA_DD_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER               PIC  X(001)       VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDATA-MM-EDT         PIC  9(002)       VALUE ZEROS.*/
                public IntBasis WDATA_MM_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER               PIC  X(001)       VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDATA-AA-EDT         PIC  9(004)       VALUE ZEROS.*/
                public IntBasis WDATA_AA_EDT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05      WHORA-CURR.*/
            }
            public AC0820B_WHORA_CURR WHORA_CURR { get; set; } = new AC0820B_WHORA_CURR();
            public class AC0820B_WHORA_CURR : VarBasis
            {
                /*"    10    WHORA-HH-CUR         PIC  9(002)       VALUE ZEROS.*/
                public IntBasis WHORA_HH_CUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WHORA-MM-CUR         PIC  9(002)       VALUE ZEROS.*/
                public IntBasis WHORA_MM_CUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WHORA-SS-CUR         PIC  9(002)       VALUE ZEROS.*/
                public IntBasis WHORA_SS_CUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      WHORA-EDIT.*/
            }
            public AC0820B_WHORA_EDIT WHORA_EDIT { get; set; } = new AC0820B_WHORA_EDIT();
            public class AC0820B_WHORA_EDIT : VarBasis
            {
                /*"    10    WHORA-HH-EDT         PIC  9(002)       VALUE ZEROS.*/
                public IntBasis WHORA_HH_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER               PIC  X(001)       VALUE '.'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10    WHORA-MM-EDT         PIC  9(002)       VALUE ZEROS.*/
                public IntBasis WHORA_MM_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER               PIC  X(001)       VALUE '.'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10    WHORA-SS-EDT         PIC  9(002)       VALUE ZEROS.*/
                public IntBasis WHORA_SS_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01        RELATORIO.*/
            }
        }
        public AC0820B_RELATORIO RELATORIO { get; set; } = new AC0820B_RELATORIO();
        public class AC0820B_RELATORIO : VarBasis
        {
            /*"  05      LC01.*/
            public AC0820B_LC01 LC01 { get; set; } = new AC0820B_LC01();
            public class AC0820B_LC01 : VarBasis
            {
                /*"    10    FILLER               PIC  X(007)  VALUE 'AC0820B'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"AC0820B");
                /*"    10    FILLER               PIC  X(010)  VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    LC01-EMPRESA         PIC  X(040)  VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE  SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE  SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE  SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(009)  VALUE '  DATA : '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  DATA : ");
                /*"    10    LC01-DATA            PIC  X(010)  VALUE  SPACES.*/
                public StringBasis LC01_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"  05      LC02.*/
            }
            public AC0820B_LC02 LC02 { get; set; } = new AC0820B_LC02();
            public class AC0820B_LC02 : VarBasis
            {
                /*"    10    FILLER               PIC  X(010)  VALUE 'COD EMPR -'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"COD EMPR -");
                /*"    10    FILLER               PIC  X(001)  VALUE  SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LC02-COD-EMPR        PIC  9(003)  VALUE  ZEROS.*/
                public IntBasis LC02_COD_EMPR { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    10    FILLER               PIC  X(003)  VALUE  SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10    LC02-NOM-EMPR        PIC  X(040)  VALUE  SPACES.*/
                public StringBasis LC02_NOM_EMPR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE  SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE  SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE  SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE  SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"  05      LC03.*/
            }
            public AC0820B_LC03 LC03 { get; set; } = new AC0820B_LC03();
            public class AC0820B_LC03 : VarBasis
            {
                /*"    10    FILLER               PIC  X(045)  VALUE         'PAGAMENTO DE COSSEGURO CEDIDO A CONGENERE EM '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"PAGAMENTO DE COSSEGURO CEDIDO A CONGENERE EM ");
                /*"    10    LC03-DTMOVTO         PIC  X(010)  VALUE  SPACES.*/
                public StringBasis LC03_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER               PIC  X(002)  VALUE  SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE         ' MOVIMENTO LIBERADO'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @" MOVIMENTO LIBERADO");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(005)  VALUE ' ATE '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ATE ");
                /*"    10    LC03-DTLIBERA        PIC  X(010)  VALUE  SPACES.*/
                public StringBasis LC03_DTLIBERA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER               PIC  X(004)  VALUE  SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE  SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(009)  VALUE '  HORA : '.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  HORA : ");
                /*"    10    LC03-HORA            PIC  X(008)  VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10    FILLER               PIC  X(002)  VALUE  SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"  05      LC04.*/
            }
            public AC0820B_LC04 LC04 { get; set; } = new AC0820B_LC04();
            public class AC0820B_LC04 : VarBasis
            {
                /*"    10    FILLER               PIC  X(011)  VALUE 'CONGENERE -'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"CONGENERE -");
                /*"    10    FILLER               PIC  X(001)  VALUE  SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LC04-CONGENER        PIC  9(004)  VALUE  ZEROS.*/
                public IntBasis LC04_CONGENER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    FILLER               PIC  X(001)  VALUE  SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LC04-NOME-CONG       PIC  X(040)  VALUE  SPACES.*/
                public StringBasis LC04_NOME_CONG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE  SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE  SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE  SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE  SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"  05      LC05.*/
            }
            public AC0820B_LC05 LC05 { get; set; } = new AC0820B_LC05();
            public class AC0820B_LC05 : VarBasis
            {
                /*"    10    FILLER               PIC  X(027)  VALUE  SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
                /*"    10    FILLER               PIC  X(030)  VALUE         'VALORES EM (R$)               '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"VALORES EM (R$)               ");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE         '        SQG        '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"        SQG        ");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE         '  PRESTAMISTA - 77 '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"  PRESTAMISTA - 77 ");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE         '      DIT          '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"      DIT          ");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER               PIC  X(019)  VALUE         '    TOTAL GERAL    '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"    TOTAL GERAL    ");
                /*"    10    FILLER               PIC  X(001)  VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"  05      LD01.*/
            }
            public AC0820B_LD01 LD01 { get; set; } = new AC0820B_LD01();
            public class AC0820B_LD01 : VarBasis
            {
                /*"    10    FILLER               PIC  X(027)  VALUE  SPACES.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
                /*"    10    LD01-DESCR-VLR       PIC  X(030)  VALUE  SPACES.*/
                public StringBasis LD01_DESCR_VLR { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    10    FILLER               PIC  X(002)  VALUE '; '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"; ");
                /*"    10    LD01-VALOR-01        PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD01_VALOR_01 { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10    FILLER               PIC  X(002)  VALUE '; '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"; ");
                /*"    10    LD01-VALOR-02        PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD01_VALOR_02 { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10    FILLER               PIC  X(002)  VALUE '; '.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"; ");
                /*"    10    LD01-VALOR-03        PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD01_VALOR_03 { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10    FILLER               PIC  X(002)  VALUE '; '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"; ");
                /*"    10    LD01-VALOR-04        PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD01_VALOR_04 { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10    FILLER               PIC  X(002)  VALUE '; '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"; ");
                /*"01        LK-LINK.*/
            }
        }
        public AC0820B_LK_LINK LK_LINK { get; set; } = new AC0820B_LK_LINK();
        public class AC0820B_LK_LINK : VarBasis
        {
            /*"  05      LK-RTCODE            PIC S9(004)      VALUE +0  COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      LK-TAMANHO           PIC S9(004)      VALUE +40 COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  05      LK-TITULO            PIC  X(132)      VALUE SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01        WABEND.*/
        }
        public AC0820B_WABEND WABEND { get; set; } = new AC0820B_WABEND();
        public class AC0820B_WABEND : VarBasis
        {
            /*"  05      FILLER               PIC  X(010)      VALUE         ' AC0820B'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AC0820B");
            /*"  05      FILLER               PIC  X(026)      VALUE         ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05      WNR-EXEC-SQL         PIC  X(004)      VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05      FILLER               PIC  X(013)      VALUE         ' *** SQLCODE '.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05      WSQLCODE             PIC -------999   VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "-------999"));
        }


        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public AC0820B_V0COSCEDCHQ V0COSCEDCHQ { get; set; } = new AC0820B_V0COSCEDCHQ();
        public AC0820B_V0COSSEGCED V0COSSEGCED { get; set; } = new AC0820B_V0COSSEGCED();
        public AC0820B_V0COSHISTPRE V0COSHISTPRE { get; set; } = new AC0820B_V0COSHISTPRE();
        public AC0820B_V0COSHISTSIN V0COSHISTSIN { get; set; } = new AC0820B_V0COSHISTSIN();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string AC0820B1_FILE_NAME_P, string AC0820B2_FILE_NAME_P, string AC0820B3_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                AC0820B1.SetFile(AC0820B1_FILE_NAME_P);
                AC0820B2.SetFile(AC0820B2_FILE_NAME_P);
                AC0820B3.SetFile(AC0820B3_FILE_NAME_P);

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
            /*" -427- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -428- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -431- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -434- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -440- OPEN OUTPUT AC0820B1. */
            AC0820B1.Open(REG_AC0820B1, AREA_DE_WORK.WSTATUS);

            /*" -441- IF WSTATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTATUS != 00)
            {

                /*" -442- DISPLAY 'R0000 - ERRO NO OPEN DO AC0820B1' */
                _.Display($"R0000 - ERRO NO OPEN DO AC0820B1");

                /*" -443- DISPLAY 'STATUS    - ' WSTATUS */
                _.Display($"STATUS    - {AREA_DE_WORK.WSTATUS}");

                /*" -444- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -448- END-IF. */
            }


            /*" -450- OPEN OUTPUT AC0820B2. */
            AC0820B2.Open(REG_AC0820B2, AREA_DE_WORK.WSTATUS);

            /*" -451- IF WSTATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTATUS != 00)
            {

                /*" -452- DISPLAY 'R0000 - ERRO NO OPEN DO AC0820B2' */
                _.Display($"R0000 - ERRO NO OPEN DO AC0820B2");

                /*" -453- DISPLAY 'STATUS    - ' WSTATUS */
                _.Display($"STATUS    - {AREA_DE_WORK.WSTATUS}");

                /*" -454- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -458- END-IF. */
            }


            /*" -460- OPEN OUTPUT AC0820B3. */
            AC0820B3.Open(REG_AC0820B3, AREA_DE_WORK.WSTATUS);

            /*" -461- IF WSTATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTATUS != 00)
            {

                /*" -462- DISPLAY 'R0000 - ERRO NO OPEN DO AC0820B3' */
                _.Display($"R0000 - ERRO NO OPEN DO AC0820B3");

                /*" -463- DISPLAY 'STATUS    - ' WSTATUS */
                _.Display($"STATUS    - {AREA_DE_WORK.WSTATUS}");

                /*" -464- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -466- END-IF. */
            }


            /*" -468- PERFORM R0100-00-SELECT-V0SISTEMA-AC. */

            R0100_00_SELECT_V0SISTEMA_AC_SECTION();

            /*" -470- PERFORM R0150-00-SELECT-V0SISTEMA-FI. */

            R0150_00_SELECT_V0SISTEMA_FI_SECTION();

            /*" -471- IF V0SIST-DTMOVABE-FI NOT EQUAL V0SIST-DTMOVABE-AC */

            if (V0SIST_DTMOVABE_FI != V0SIST_DTMOVABE_AC)
            {

                /*" -472- DISPLAY 'R0000 - DATA DO SISTEMA FI DIFERE DO AC' */
                _.Display($"R0000 - DATA DO SISTEMA FI DIFERE DO AC");

                /*" -473- DISPLAY 'DATA MOVTO FI - ' V0SIST-DTMOVABE-FI */
                _.Display($"DATA MOVTO FI - {V0SIST_DTMOVABE_FI}");

                /*" -474- DISPLAY 'DATA MOVTO AC - ' V0SIST-DTMOVABE-AC */
                _.Display($"DATA MOVTO AC - {V0SIST_DTMOVABE_AC}");

                /*" -475- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -477- END-IF. */
            }


            /*" -479- PERFORM R0200-00-SELECT-V0EMPRESA. */

            R0200_00_SELECT_V0EMPRESA_SECTION();

            /*" -481- MOVE 5193 TO V0CCCH-CONGENER. */
            _.Move(5193, V0CCCH_CONGENER);

            /*" -483- PERFORM R0300-00-DECLARE-V0COSCEDCHQ. */

            R0300_00_DECLARE_V0COSCEDCHQ_SECTION();

            /*" -485- PERFORM R0400-00-FETCH-V0COSCEDCHQ. */

            R0400_00_FETCH_V0COSCEDCHQ_SECTION();

            /*" -486- IF WFIM-V0COSCEDCHQ NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0COSCEDCHQ.IsEmpty())
            {

                /*" -487- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA(); //GOTO
                return;

                /*" -488- ELSE */
            }
            else
            {


                /*" -490- PERFORM R0500-00-PROCESSA-COSCEDCHQ UNTIL WFIM-V0COSCEDCHQ NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_V0COSCEDCHQ.IsEmpty()))
                {

                    R0500_00_PROCESSA_COSCEDCHQ_SECTION();
                }

                /*" -490- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -496- CLOSE AC0820B1. */
            AC0820B1.Close();

            /*" -498- CLOSE AC0820B2. */
            AC0820B2.Close();

            /*" -500- CLOSE AC0820B3. */
            AC0820B3.Close();

            /*" -501- DISPLAY ' ' . */
            _.Display($" ");

            /*" -502- DISPLAY 'PAGAMENTO DE COSSEGURO CEDIDO A CONGENERE' */
            _.Display($"PAGAMENTO DE COSSEGURO CEDIDO A CONGENERE");

            /*" -503- DISPLAY ' ' . */
            _.Display($" ");

            /*" -504- DISPLAY 'REG. LIDOS COSCED_CHEQUE  - ' AC-L-V0COSCEDCHQ. */
            _.Display($"REG. LIDOS COSCED_CHEQUE  - {AREA_DE_WORK.AC_L_V0COSCEDCHQ}");

            /*" -505- DISPLAY 'REG. LIDOS COSSEG_CED     - ' AC-L-V0COSSEGCED. */
            _.Display($"REG. LIDOS COSSEG_CED     - {AREA_DE_WORK.AC_L_V0COSSEGCED}");

            /*" -506- DISPLAY 'REG. LIDOS COSSEG_HISTPRE - ' AC-L-V0COSHISPRE. */
            _.Display($"REG. LIDOS COSSEG_HISTPRE - {AREA_DE_WORK.AC_L_V0COSHISPRE}");

            /*" -507- DISPLAY 'REG. LIDOS COSSEG_HISTSIN - ' AC-L-V0COSHISSIN. */
            _.Display($"REG. LIDOS COSSEG_HISTSIN - {AREA_DE_WORK.AC_L_V0COSHISSIN}");

            /*" -508- DISPLAY ' ' . */
            _.Display($" ");

            /*" -510- DISPLAY 'AC0820B - FIM NORMAL ' . */
            _.Display($"AC0820B - FIM NORMAL ");

            /*" -510- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -514- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -514- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-AC-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_AC_SECTION()
        {
            /*" -527- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -533- PERFORM R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1();

            /*" -536- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -537- DISPLAY 'R0100 - ERRO NO SELECT DA V0SISTEMA - AC' */
                _.Display($"R0100 - ERRO NO SELECT DA V0SISTEMA - AC");

                /*" -538- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -539- ELSE */
            }
            else
            {


                /*" -539- DISPLAY 'DATA DO MOVIMENTO (AC) - ' V0SIST-DTMOVABE-AC. */
                _.Display($"DATA DO MOVIMENTO (AC) - {V0SIST_DTMOVABE_AC}");
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-AC-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1()
        {
            /*" -533- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE-AC FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'AC' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE_AC, V0SIST_DTMOVABE_AC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-SELECT-V0SISTEMA-FI-SECTION */
        private void R0150_00_SELECT_V0SISTEMA_FI_SECTION()
        {
            /*" -552- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", WABEND.WNR_EXEC_SQL);

            /*" -560- PERFORM R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1 */

            R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1();

            /*" -563- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -564- DISPLAY 'R0150 - ERRO NO SELECT DA V0SISTEMA - FI' */
                _.Display($"R0150 - ERRO NO SELECT DA V0SISTEMA - FI");

                /*" -565- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -566- ELSE */
            }
            else
            {


                /*" -566- DISPLAY 'DATA DO MOVIMENTO (FI) - ' V0SIST-DTMOVABE-FI. */
                _.Display($"DATA DO MOVIMENTO (FI) - {V0SIST_DTMOVABE_FI}");
            }


        }

        [StopWatch]
        /*" R0150-00-SELECT-V0SISTEMA-FI-DB-SELECT-1 */
        public void R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1()
        {
            /*" -560- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V0SIST-DTMOVABE-FI, :V0SIST-DTCURRENT FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'FI' WITH UR END-EXEC. */

            var r0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1 = new R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1.Execute(r0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE_FI, V0SIST_DTMOVABE_FI);
                _.Move(executed_1.V0SIST_DTCURRENT, V0SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V0EMPRESA-SECTION */
        private void R0200_00_SELECT_V0EMPRESA_SECTION()
        {
            /*" -579- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -587- PERFORM R0200_00_SELECT_V0EMPRESA_DB_SELECT_1 */

            R0200_00_SELECT_V0EMPRESA_DB_SELECT_1();

            /*" -590- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -591- DISPLAY 'R0200 - ERRO NO SELECT DA V0EMPRESA' */
                _.Display($"R0200 - ERRO NO SELECT DA V0EMPRESA");

                /*" -592- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -594- END-IF. */
            }


            /*" -596- MOVE V0EMPR-NOM-EMP TO LK-TITULO. */
            _.Move(V0EMPR_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -598- CALL 'PROALN01' USING LK-LINK. */
            _.Call("PROALN01", LK_LINK);

            /*" -599- IF LK-RTCODE NOT EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE != 00)
            {

                /*" -600- DISPLAY 'R0200 - ERRO NO CALL DA SUB-ROTINA PROALN01' */
                _.Display($"R0200 - ERRO NO CALL DA SUB-ROTINA PROALN01");

                /*" -601- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -601- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-SELECT-V0EMPRESA-DB-SELECT-1 */
        public void R0200_00_SELECT_V0EMPRESA_DB_SELECT_1()
        {
            /*" -587- EXEC SQL SELECT NOME_EMPRESA, CGCCPF INTO :V0EMPR-NOM-EMP, :V0EMPR-CGCCPF FROM SEGUROS.V0EMPRESA WHERE COD_EMPRESA = 99 WITH UR END-EXEC. */

            var r0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1 = new R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0EMPR_NOM_EMP, V0EMPR_NOM_EMP);
                _.Move(executed_1.V0EMPR_CGCCPF, V0EMPR_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-V0COSCEDCHQ-SECTION */
        private void R0300_00_DECLARE_V0COSCEDCHQ_SECTION()
        {
            /*" -614- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -638- PERFORM R0300_00_DECLARE_V0COSCEDCHQ_DB_DECLARE_1 */

            R0300_00_DECLARE_V0COSCEDCHQ_DB_DECLARE_1();

            /*" -640- PERFORM R0300_00_DECLARE_V0COSCEDCHQ_DB_OPEN_1 */

            R0300_00_DECLARE_V0COSCEDCHQ_DB_OPEN_1();

            /*" -643- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -644- DISPLAY 'R0300 - ERRO NO DECLARE DA V0COSCED-CHEQUE' */
                _.Display($"R0300 - ERRO NO DECLARE DA V0COSCED-CHEQUE");

                /*" -645- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -646- ELSE */
            }
            else
            {


                /*" -647- MOVE SPACES TO WFIM-V0COSCEDCHQ */
                _.Move("", AREA_DE_WORK.WFIM_V0COSCEDCHQ);

                /*" -647- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0COSCEDCHQ-DB-DECLARE-1 */
        public void R0300_00_DECLARE_V0COSCEDCHQ_DB_DECLARE_1()
        {
            /*" -638- EXEC SQL DECLARE V0COSCEDCHQ CURSOR FOR SELECT COD_EMPRESA , CONGENER , DTMOVTO_AC , DTLIBERA , VLPREMIO , VLRSINI , VLDESPESA , VLRHONOR , VLRSALVD , VLRESSARC , VLDESPADM , OUTRDEBIT , OUTRCREDT , VLRSLDANT , SITUACAO FROM SEGUROS.V0COSCED_CHEQUE WHERE CONGENER = :V0CCCH-CONGENER AND DTMOVTO_FI = :V0SIST-DTMOVABE-FI AND SITUACAO = '1' ORDER BY COD_EMPRESA, CONGENER WITH UR END-EXEC. */
            V0COSCEDCHQ = new AC0820B_V0COSCEDCHQ(true);
            string GetQuery_V0COSCEDCHQ()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							CONGENER
							, 
							DTMOVTO_AC
							, 
							DTLIBERA
							, 
							VLPREMIO
							, 
							VLRSINI
							, 
							VLDESPESA
							, 
							VLRHONOR
							, 
							VLRSALVD
							, 
							VLRESSARC
							, 
							VLDESPADM
							, 
							OUTRDEBIT
							, 
							OUTRCREDT
							, 
							VLRSLDANT
							, 
							SITUACAO 
							FROM SEGUROS.V0COSCED_CHEQUE 
							WHERE CONGENER = '{V0CCCH_CONGENER}' 
							AND DTMOVTO_FI = '{V0SIST_DTMOVABE_FI}' 
							AND SITUACAO = '1' 
							ORDER BY 
							COD_EMPRESA
							, 
							CONGENER";

                return query;
            }
            V0COSCEDCHQ.GetQueryEvent += GetQuery_V0COSCEDCHQ;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0COSCEDCHQ-DB-OPEN-1 */
        public void R0300_00_DECLARE_V0COSCEDCHQ_DB_OPEN_1()
        {
            /*" -640- EXEC SQL OPEN V0COSCEDCHQ END-EXEC. */

            V0COSCEDCHQ.Open();

        }

        [StopWatch]
        /*" R1100-00-DECLARE-V0COSSEG-CED-DB-DECLARE-1 */
        public void R1100_00_DECLARE_V0COSSEG_CED_DB_DECLARE_1()
        {
            /*" -947- EXEC SQL DECLARE V0COSSEGCED CURSOR FOR SELECT DISTINCT B.RAMO FROM SEGUROS.V0COSSEG_HISTPRE A, SEGUROS.V0APOLICE B WHERE A.TIPSGU = '1' AND A.COD_EMPRESA = :V0CCCH-COD-EMPR AND A.CONGENER = :V0CCCH-CONGENER AND A.DTMOVTO = :V0CCCH-DTMOVTAC AND A.OPERACAO BETWEEN 0900 AND 0999 AND B.TIPSGU = A.TIPSGU AND B.NUM_APOLICE = A.NUM_APOLICE UNION SELECT DISTINCT B.RAMO FROM SEGUROS.V0COSSEG_HISTSIN A, SEGUROS.V0MESTSINI B WHERE A.TIPSGU = '1' AND A.COD_EMPRESA = :V0CCCH-COD-EMPR AND A.CONGENER = :V0CCCH-CONGENER AND A.DTMOVTO = :V0CCCH-DTMOVTAC AND A.OPERACAO BETWEEN 0900 AND 0999 AND A.SITUACAO = '1' AND A.SIT_LIBRECUP = '0' AND B.NUM_APOL_SINISTRO = A.NUM_SINISTRO ORDER BY 1 WITH UR END-EXEC. */
            V0COSSEGCED = new AC0820B_V0COSSEGCED(true);
            string GetQuery_V0COSSEGCED()
            {
                var query = @$"SELECT DISTINCT B.RAMO 
							FROM SEGUROS.V0COSSEG_HISTPRE A
							, 
							SEGUROS.V0APOLICE B 
							WHERE A.TIPSGU = '1' 
							AND A.COD_EMPRESA = '{V0CCCH_COD_EMPR}' 
							AND A.CONGENER = '{V0CCCH_CONGENER}' 
							AND A.DTMOVTO = '{V0CCCH_DTMOVTAC}' 
							AND A.OPERACAO BETWEEN 0900 AND 0999 
							AND B.TIPSGU = A.TIPSGU 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							UNION 
							SELECT DISTINCT B.RAMO 
							FROM SEGUROS.V0COSSEG_HISTSIN A
							, 
							SEGUROS.V0MESTSINI B 
							WHERE A.TIPSGU = '1' 
							AND A.COD_EMPRESA = '{V0CCCH_COD_EMPR}' 
							AND A.CONGENER = '{V0CCCH_CONGENER}' 
							AND A.DTMOVTO = '{V0CCCH_DTMOVTAC}' 
							AND A.OPERACAO BETWEEN 0900 AND 0999 
							AND A.SITUACAO = '1' 
							AND A.SIT_LIBRECUP = '0' 
							AND B.NUM_APOL_SINISTRO = A.NUM_SINISTRO 
							ORDER BY 1";

                return query;
            }
            V0COSSEGCED.GetQueryEvent += GetQuery_V0COSSEGCED;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-FETCH-V0COSCEDCHQ-SECTION */
        private void R0400_00_FETCH_V0COSCEDCHQ_SECTION()
        {
            /*" -660- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -676- PERFORM R0400_00_FETCH_V0COSCEDCHQ_DB_FETCH_1 */

            R0400_00_FETCH_V0COSCEDCHQ_DB_FETCH_1();

            /*" -679- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -680- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -681- MOVE 'S' TO WFIM-V0COSCEDCHQ */
                    _.Move("S", AREA_DE_WORK.WFIM_V0COSCEDCHQ);

                    /*" -681- PERFORM R0400_00_FETCH_V0COSCEDCHQ_DB_CLOSE_1 */

                    R0400_00_FETCH_V0COSCEDCHQ_DB_CLOSE_1();

                    /*" -683- ELSE */
                }
                else
                {


                    /*" -684- DISPLAY 'R0400 - ERRO NO FETCH DA V0COSCED-CHEQUE' */
                    _.Display($"R0400 - ERRO NO FETCH DA V0COSCED-CHEQUE");

                    /*" -685- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -686- END-IF */
                }


                /*" -687- ELSE */
            }
            else
            {


                /*" -688- ADD 1 TO AC-L-V0COSCEDCHQ */
                AREA_DE_WORK.AC_L_V0COSCEDCHQ.Value = AREA_DE_WORK.AC_L_V0COSCEDCHQ + 1;

                /*" -688- END-IF. */
            }


        }

        [StopWatch]
        /*" R0400-00-FETCH-V0COSCEDCHQ-DB-FETCH-1 */
        public void R0400_00_FETCH_V0COSCEDCHQ_DB_FETCH_1()
        {
            /*" -676- EXEC SQL FETCH V0COSCEDCHQ INTO :V0CCCH-COD-EMPR , :V0CCCH-CONGENER , :V0CCCH-DTMOVTAC , :V0CCCH-DTLIBERA , :V0CCCH-VLPREMIO , :V0CCCH-VLRSINI , :V0CCCH-VLDESPESA , :V0CCCH-VLRHONOR , :V0CCCH-VLRSALVD , :V0CCCH-VLRESSARC , :V0CCCH-VLDESPADM , :V0CCCH-OUTRDEBIT , :V0CCCH-OUTRCREDT , :V0CCCH-VLRSLDANT , :V0CCCH-SITUACAO END-EXEC. */

            if (V0COSCEDCHQ.Fetch())
            {
                _.Move(V0COSCEDCHQ.V0CCCH_COD_EMPR, V0CCCH_COD_EMPR);
                _.Move(V0COSCEDCHQ.V0CCCH_CONGENER, V0CCCH_CONGENER);
                _.Move(V0COSCEDCHQ.V0CCCH_DTMOVTAC, V0CCCH_DTMOVTAC);
                _.Move(V0COSCEDCHQ.V0CCCH_DTLIBERA, V0CCCH_DTLIBERA);
                _.Move(V0COSCEDCHQ.V0CCCH_VLPREMIO, V0CCCH_VLPREMIO);
                _.Move(V0COSCEDCHQ.V0CCCH_VLRSINI, V0CCCH_VLRSINI);
                _.Move(V0COSCEDCHQ.V0CCCH_VLDESPESA, V0CCCH_VLDESPESA);
                _.Move(V0COSCEDCHQ.V0CCCH_VLRHONOR, V0CCCH_VLRHONOR);
                _.Move(V0COSCEDCHQ.V0CCCH_VLRSALVD, V0CCCH_VLRSALVD);
                _.Move(V0COSCEDCHQ.V0CCCH_VLRESSARC, V0CCCH_VLRESSARC);
                _.Move(V0COSCEDCHQ.V0CCCH_VLDESPADM, V0CCCH_VLDESPADM);
                _.Move(V0COSCEDCHQ.V0CCCH_OUTRDEBIT, V0CCCH_OUTRDEBIT);
                _.Move(V0COSCEDCHQ.V0CCCH_OUTRCREDT, V0CCCH_OUTRCREDT);
                _.Move(V0COSCEDCHQ.V0CCCH_VLRSLDANT, V0CCCH_VLRSLDANT);
                _.Move(V0COSCEDCHQ.V0CCCH_SITUACAO, V0CCCH_SITUACAO);
            }

        }

        [StopWatch]
        /*" R0400-00-FETCH-V0COSCEDCHQ-DB-CLOSE-1 */
        public void R0400_00_FETCH_V0COSCEDCHQ_DB_CLOSE_1()
        {
            /*" -681- EXEC SQL CLOSE V0COSCEDCHQ END-EXEC */

            V0COSCEDCHQ.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-PROCESSA-COSCEDCHQ-SECTION */
        private void R0500_00_PROCESSA_COSCEDCHQ_SECTION()
        {
            /*" -701- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -702- MOVE ZEROS TO V0EMPR-COD-EMP. */
            _.Move(0, V0EMPR_COD_EMP);

            /*" -704- MOVE SPACES TO V0EMPR-NOM-EMP. */
            _.Move("", V0EMPR_NOM_EMP);

            /*" -706- PERFORM R0600-00-SELECT-V0EMPRESA. */

            R0600_00_SELECT_V0EMPRESA_SECTION();

            /*" -708- MOVE V0CCCH-COD-EMPR TO WCOD-EMPR-ANT. */
            _.Move(V0CCCH_COD_EMPR, AREA_DE_WORK.WCOD_EMPR_ANT);

            /*" -710- PERFORM R0700-00-PROCESSA-EMPRESA UNTIL WFIM-V0COSCEDCHQ NOT EQUAL SPACES OR V0CCCH-COD-EMPR NOT EQUAL WCOD-EMPR-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V0COSCEDCHQ.IsEmpty() || V0CCCH_COD_EMPR != AREA_DE_WORK.WCOD_EMPR_ANT))
            {

                R0700_00_PROCESSA_EMPRESA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-SELECT-V0EMPRESA-SECTION */
        private void R0600_00_SELECT_V0EMPRESA_SECTION()
        {
            /*" -723- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", WABEND.WNR_EXEC_SQL);

            /*" -731- PERFORM R0600_00_SELECT_V0EMPRESA_DB_SELECT_1 */

            R0600_00_SELECT_V0EMPRESA_DB_SELECT_1();

            /*" -734- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -735- DISPLAY 'R0600 - ERRO NO SELECT DA V0EMPRESA' */
                _.Display($"R0600 - ERRO NO SELECT DA V0EMPRESA");

                /*" -736- DISPLAY 'COD EMPR - ' V0CCCH-COD-EMPR */
                _.Display($"COD EMPR - {V0CCCH_COD_EMPR}");

                /*" -737- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -737- END-IF. */
            }


        }

        [StopWatch]
        /*" R0600-00-SELECT-V0EMPRESA-DB-SELECT-1 */
        public void R0600_00_SELECT_V0EMPRESA_DB_SELECT_1()
        {
            /*" -731- EXEC SQL SELECT COD_EMPRESA, NOME_EMPRESA INTO :V0EMPR-COD-EMP, :V0EMPR-NOM-EMP FROM SEGUROS.V0EMPRESA WHERE COD_EMPRESA = :V0CCCH-COD-EMPR WITH UR END-EXEC. */

            var r0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1 = new R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1()
            {
                V0CCCH_COD_EMPR = V0CCCH_COD_EMPR.ToString(),
            };

            var executed_1 = R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1.Execute(r0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0EMPR_COD_EMP, V0EMPR_COD_EMP);
                _.Move(executed_1.V0EMPR_NOM_EMP, V0EMPR_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROCESSA-EMPRESA-SECTION */
        private void R0700_00_PROCESSA_EMPRESA_SECTION()
        {
            /*" -750- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -764- MOVE ZEROS TO WPREM-SQG-P WPREM-SQG-R WCOMS-SQG-T WPREM-PRT-P WPREM-PRT-R WCOMS-PRT-T WPREM-DIT-P WPREM-DIT-R WCOMS-DIT-T WVLR-SIN-SQG WVLR-SIN-PRT WVLR-SIN-DIT WS-TOT-CONG. */
            _.Move(0, AREA_DE_WORK.WPREM_SQG_P, AREA_DE_WORK.WPREM_SQG_R, AREA_DE_WORK.WCOMS_SQG_T, AREA_DE_WORK.WPREM_PRT_P, AREA_DE_WORK.WPREM_PRT_R, AREA_DE_WORK.WCOMS_PRT_T, AREA_DE_WORK.WPREM_DIT_P, AREA_DE_WORK.WPREM_DIT_R, AREA_DE_WORK.WCOMS_DIT_T, AREA_DE_WORK.WVLR_SIN_SQG, AREA_DE_WORK.WVLR_SIN_PRT, AREA_DE_WORK.WVLR_SIN_DIT, AREA_DE_WORK.WS_TOT_CONG);

            /*" -766- PERFORM R0800-00-SELECT-V0CONGENERE. */

            R0800_00_SELECT_V0CONGENERE_SECTION();

            /*" -768- PERFORM R0900-00-IMPRIME-CABECALHO. */

            R0900_00_IMPRIME_CABECALHO_SECTION();

            /*" -770- MOVE V0CCCH-CONGENER TO WCOD-CONG-ANT. */
            _.Move(V0CCCH_CONGENER, AREA_DE_WORK.WCOD_CONG_ANT);

            /*" -773- PERFORM R1000-00-PROCESSA-CONGENERE UNTIL WFIM-V0COSCEDCHQ NOT EQUAL SPACES OR V0CCCH-COD-EMPR NOT EQUAL WCOD-EMPR-ANT OR V0CCCH-CONGENER NOT EQUAL WCOD-CONG-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V0COSCEDCHQ.IsEmpty() || V0CCCH_COD_EMPR != AREA_DE_WORK.WCOD_EMPR_ANT || V0CCCH_CONGENER != AREA_DE_WORK.WCOD_CONG_ANT))
            {

                R1000_00_PROCESSA_CONGENERE_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-SELECT-V0CONGENERE-SECTION */
        private void R0800_00_SELECT_V0CONGENERE_SECTION()
        {
            /*" -786- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", WABEND.WNR_EXEC_SQL);

            /*" -794- PERFORM R0800_00_SELECT_V0CONGENERE_DB_SELECT_1 */

            R0800_00_SELECT_V0CONGENERE_DB_SELECT_1();

            /*" -797- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -798- DISPLAY 'R0800 - ERRO NO SELECT DA V0CONGENERE' */
                _.Display($"R0800 - ERRO NO SELECT DA V0CONGENERE");

                /*" -799- DISPLAY 'CONGENERE - ' V0CCCH-CONGENER */
                _.Display($"CONGENERE - {V0CCCH_CONGENER}");

                /*" -800- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -800- END-IF. */
            }


        }

        [StopWatch]
        /*" R0800-00-SELECT-V0CONGENERE-DB-SELECT-1 */
        public void R0800_00_SELECT_V0CONGENERE_DB_SELECT_1()
        {
            /*" -794- EXEC SQL SELECT CONGENER, NOMECONG INTO :V0CONG-CONGENER, :V0CONG-NOMECONG FROM SEGUROS.V0CONGENERE WHERE CONGENER = :V0CCCH-CONGENER WITH UR END-EXEC. */

            var r0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1 = new R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1()
            {
                V0CCCH_CONGENER = V0CCCH_CONGENER.ToString(),
            };

            var executed_1 = R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1.Execute(r0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONG_CONGENER, V0CONG_CONGENER);
                _.Move(executed_1.V0CONG_NOMECONG, V0CONG_NOMECONG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-IMPRIME-CABECALHO-SECTION */
        private void R0900_00_IMPRIME_CABECALHO_SECTION()
        {
            /*" -813- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -815- MOVE LK-TITULO TO LC01-EMPRESA. */
            _.Move(LK_LINK.LK_TITULO, RELATORIO.LC01.LC01_EMPRESA);

            /*" -816- MOVE V0SIST-DTCURRENT TO WDATA-AUX. */
            _.Move(V0SIST_DTCURRENT, AREA_DE_WORK.WDATA_AUX);

            /*" -817- MOVE WDATA-DD-AUX TO WDATA-DD-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_DD_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDT);

            /*" -818- MOVE WDATA-MM-AUX TO WDATA-MM-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_MM_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDT);

            /*" -819- MOVE WDATA-AA-AUX TO WDATA-AA-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_AA_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDT);

            /*" -821- MOVE WDATA-EDIT TO LC01-DATA. */
            _.Move(AREA_DE_WORK.WDATA_EDIT, RELATORIO.LC01.LC01_DATA);

            /*" -822- MOVE V0EMPR-COD-EMP TO LC02-COD-EMPR. */
            _.Move(V0EMPR_COD_EMP, RELATORIO.LC02.LC02_COD_EMPR);

            /*" -824- MOVE V0EMPR-NOM-EMP TO LC02-NOM-EMPR. */
            _.Move(V0EMPR_NOM_EMP, RELATORIO.LC02.LC02_NOM_EMPR);

            /*" -825- MOVE V0SIST-DTMOVABE-FI TO WDATA-AUX. */
            _.Move(V0SIST_DTMOVABE_FI, AREA_DE_WORK.WDATA_AUX);

            /*" -826- MOVE WDATA-DD-AUX TO WDATA-DD-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_DD_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDT);

            /*" -827- MOVE WDATA-MM-AUX TO WDATA-MM-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_MM_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDT);

            /*" -828- MOVE WDATA-AA-AUX TO WDATA-AA-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_AA_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDT);

            /*" -830- MOVE WDATA-EDIT TO LC03-DTMOVTO. */
            _.Move(AREA_DE_WORK.WDATA_EDIT, RELATORIO.LC03.LC03_DTMOVTO);

            /*" -831- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -832- MOVE WHORA-HH-CUR TO WHORA-HH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CUR, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDT);

            /*" -833- MOVE WHORA-MM-CUR TO WHORA-MM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CUR, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDT);

            /*" -834- MOVE WHORA-SS-CUR TO WHORA-SS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CUR, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDT);

            /*" -836- MOVE WHORA-EDIT TO LC03-HORA. */
            _.Move(AREA_DE_WORK.WHORA_EDIT, RELATORIO.LC03.LC03_HORA);

            /*" -837- MOVE V0CCCH-DTLIBERA TO WDATA-AUX */
            _.Move(V0CCCH_DTLIBERA, AREA_DE_WORK.WDATA_AUX);

            /*" -838- MOVE WDATA-DD-AUX TO WDATA-DD-EDT */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_DD_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDT);

            /*" -839- MOVE WDATA-MM-AUX TO WDATA-MM-EDT */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_MM_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDT);

            /*" -840- MOVE WDATA-AA-AUX TO WDATA-AA-EDT */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_AA_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDT);

            /*" -842- MOVE WDATA-EDIT TO LC03-DTLIBERA */
            _.Move(AREA_DE_WORK.WDATA_EDIT, RELATORIO.LC03.LC03_DTLIBERA);

            /*" -843- MOVE V0CONG-CONGENER TO LC04-CONGENER. */
            _.Move(V0CONG_CONGENER, RELATORIO.LC04.LC04_CONGENER);

            /*" -845- MOVE V0CONG-NOMECONG TO LC04-NOME-CONG. */
            _.Move(V0CONG_NOMECONG, RELATORIO.LC04.LC04_NOME_CONG);

            /*" -846- IF V0CCCH-COD-EMPR = 00 */

            if (V0CCCH_COD_EMPR == 00)
            {

                /*" -847- WRITE REG-AC0820B1 FROM LC01 */
                _.Move(RELATORIO.LC01.GetMoveValues(), REG_AC0820B1);

                AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

                /*" -848- WRITE REG-AC0820B1 FROM LC02 */
                _.Move(RELATORIO.LC02.GetMoveValues(), REG_AC0820B1);

                AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

                /*" -849- WRITE REG-AC0820B1 FROM LC03 */
                _.Move(RELATORIO.LC03.GetMoveValues(), REG_AC0820B1);

                AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

                /*" -850- WRITE REG-AC0820B1 FROM LC04 */
                _.Move(RELATORIO.LC04.GetMoveValues(), REG_AC0820B1);

                AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

                /*" -851- WRITE REG-AC0820B1 FROM LC05 */
                _.Move(RELATORIO.LC05.GetMoveValues(), REG_AC0820B1);

                AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

                /*" -852- ELSE */
            }
            else
            {


                /*" -853- IF V0CCCH-COD-EMPR = 10 */

                if (V0CCCH_COD_EMPR == 10)
                {

                    /*" -854- WRITE REG-AC0820B2 FROM LC01 */
                    _.Move(RELATORIO.LC01.GetMoveValues(), REG_AC0820B2);

                    AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

                    /*" -855- WRITE REG-AC0820B2 FROM LC02 */
                    _.Move(RELATORIO.LC02.GetMoveValues(), REG_AC0820B2);

                    AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

                    /*" -856- WRITE REG-AC0820B2 FROM LC03 */
                    _.Move(RELATORIO.LC03.GetMoveValues(), REG_AC0820B2);

                    AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

                    /*" -857- WRITE REG-AC0820B2 FROM LC04 */
                    _.Move(RELATORIO.LC04.GetMoveValues(), REG_AC0820B2);

                    AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

                    /*" -858- WRITE REG-AC0820B2 FROM LC05 */
                    _.Move(RELATORIO.LC05.GetMoveValues(), REG_AC0820B2);

                    AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

                    /*" -859- ELSE */
                }
                else
                {


                    /*" -860- WRITE REG-AC0820B3 FROM LC01 */
                    _.Move(RELATORIO.LC01.GetMoveValues(), REG_AC0820B3);

                    AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

                    /*" -861- WRITE REG-AC0820B3 FROM LC02 */
                    _.Move(RELATORIO.LC02.GetMoveValues(), REG_AC0820B3);

                    AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

                    /*" -862- WRITE REG-AC0820B3 FROM LC03 */
                    _.Move(RELATORIO.LC03.GetMoveValues(), REG_AC0820B3);

                    AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

                    /*" -863- WRITE REG-AC0820B3 FROM LC04 */
                    _.Move(RELATORIO.LC04.GetMoveValues(), REG_AC0820B3);

                    AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

                    /*" -864- WRITE REG-AC0820B3 FROM LC05 */
                    _.Move(RELATORIO.LC05.GetMoveValues(), REG_AC0820B3);

                    AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

                    /*" -865- END-IF */
                }


                /*" -865- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-CONGENERE-SECTION */
        private void R1000_00_PROCESSA_CONGENERE_SECTION()
        {
            /*" -878- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -883- MOVE ZEROS TO WCOD-RAMO-ANT WHOST-COD-RAMO. */
            _.Move(0, AREA_DE_WORK.WCOD_RAMO_ANT, WHOST_COD_RAMO);

            /*" -885- PERFORM R1100-00-DECLARE-V0COSSEG-CED. */

            R1100_00_DECLARE_V0COSSEG_CED_SECTION();

            /*" -887- PERFORM R1200-00-FETCH-V0COSSEG-CED. */

            R1200_00_FETCH_V0COSSEG_CED_SECTION();

            /*" -892- PERFORM R1300-00-PROCESSA-COSSEG-CED UNTIL WFIM-V0COSSEGCED NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0COSSEGCED.IsEmpty()))
            {

                R1300_00_PROCESSA_COSSEG_CED_SECTION();
            }

            /*" -893- IF V0CCCH-COD-EMPR = 00 */

            if (V0CCCH_COD_EMPR == 00)
            {

                /*" -894- PERFORM R3000-00-GRAVA-AC0820B1 */

                R3000_00_GRAVA_AC0820B1_SECTION();

                /*" -895- ELSE */
            }
            else
            {


                /*" -896- IF V0CCCH-COD-EMPR = 10 */

                if (V0CCCH_COD_EMPR == 10)
                {

                    /*" -897- PERFORM R3100-00-GRAVA-AC0820B2 */

                    R3100_00_GRAVA_AC0820B2_SECTION();

                    /*" -898- ELSE */
                }
                else
                {


                    /*" -899- PERFORM R3200-00-GRAVA-AC0820B3 */

                    R3200_00_GRAVA_AC0820B3_SECTION();

                    /*" -900- END-IF */
                }


                /*" -904- END-IF. */
            }


            /*" -904- PERFORM R0400-00-FETCH-V0COSCEDCHQ. */

            R0400_00_FETCH_V0COSCEDCHQ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-DECLARE-V0COSSEG-CED-SECTION */
        private void R1100_00_DECLARE_V0COSSEG_CED_SECTION()
        {
            /*" -917- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -947- PERFORM R1100_00_DECLARE_V0COSSEG_CED_DB_DECLARE_1 */

            R1100_00_DECLARE_V0COSSEG_CED_DB_DECLARE_1();

            /*" -949- PERFORM R1100_00_DECLARE_V0COSSEG_CED_DB_OPEN_1 */

            R1100_00_DECLARE_V0COSSEG_CED_DB_OPEN_1();

            /*" -952- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -953- DISPLAY 'R1100 - ERRO NO DECLARE DA V0COSSEGCED' */
                _.Display($"R1100 - ERRO NO DECLARE DA V0COSSEGCED");

                /*" -954- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -955- ELSE */
            }
            else
            {


                /*" -956- MOVE SPACES TO WFIM-V0COSSEGCED */
                _.Move("", AREA_DE_WORK.WFIM_V0COSSEGCED);

                /*" -956- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-DECLARE-V0COSSEG-CED-DB-OPEN-1 */
        public void R1100_00_DECLARE_V0COSSEG_CED_DB_OPEN_1()
        {
            /*" -949- EXEC SQL OPEN V0COSSEGCED END-EXEC. */

            V0COSSEGCED.Open();

        }

        [StopWatch]
        /*" R1600-00-DECLARE-V0COSHISTPRE-DB-DECLARE-1 */
        public void R1600_00_DECLARE_V0COSHISTPRE_DB_DECLARE_1()
        {
            /*" -1123- EXEC SQL DECLARE V0COSHISTPRE CURSOR FOR SELECT A.NUM_APOLICE, A.NRENDOS, A.NRPARCEL, A.OCORHIST, A.DTMOVTO, A.OPERACAO, A.PRM_TARIFARIO, A.VAL_DESCONTO, A.VLPRMLIQ, A.VLADIFRA, A.VLCOMIS, A.VLPRMTOT FROM SEGUROS.V0COSSEG_HISTPRE A, SEGUROS.V0APOLICE B WHERE A.TIPSGU = '1' AND A.COD_EMPRESA = :V0CCCH-COD-EMPR AND A.CONGENER = :V0CCCH-CONGENER AND A.DTMOVTO = :V0CCCH-DTMOVTAC AND A.OPERACAO BETWEEN 0900 AND 0999 AND B.TIPSGU = A.TIPSGU AND B.NUM_APOLICE = A.NUM_APOLICE AND B.RAMO = :WHOST-COD-RAMO ORDER BY A.NUM_APOLICE, A.NRENDOS, A.NRPARCEL, A.OCORHIST WITH UR END-EXEC. */
            V0COSHISTPRE = new AC0820B_V0COSHISTPRE(true);
            string GetQuery_V0COSHISTPRE()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.OCORHIST
							, 
							A.DTMOVTO
							, 
							A.OPERACAO
							, 
							A.PRM_TARIFARIO
							, 
							A.VAL_DESCONTO
							, 
							A.VLPRMLIQ
							, 
							A.VLADIFRA
							, 
							A.VLCOMIS
							, 
							A.VLPRMTOT 
							FROM SEGUROS.V0COSSEG_HISTPRE A
							, 
							SEGUROS.V0APOLICE B 
							WHERE A.TIPSGU = '1' 
							AND A.COD_EMPRESA = '{V0CCCH_COD_EMPR}' 
							AND A.CONGENER = '{V0CCCH_CONGENER}' 
							AND A.DTMOVTO = '{V0CCCH_DTMOVTAC}' 
							AND A.OPERACAO BETWEEN 0900 AND 0999 
							AND B.TIPSGU = A.TIPSGU 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.RAMO = '{WHOST_COD_RAMO}' 
							ORDER BY 
							A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.OCORHIST";

                return query;
            }
            V0COSHISTPRE.GetQueryEvent += GetQuery_V0COSHISTPRE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-FETCH-V0COSSEG-CED-SECTION */
        private void R1200_00_FETCH_V0COSSEG_CED_SECTION()
        {
            /*" -969- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -971- PERFORM R1200_00_FETCH_V0COSSEG_CED_DB_FETCH_1 */

            R1200_00_FETCH_V0COSSEG_CED_DB_FETCH_1();

            /*" -974- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -975- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -976- MOVE 'S' TO WFIM-V0COSSEGCED */
                    _.Move("S", AREA_DE_WORK.WFIM_V0COSSEGCED);

                    /*" -976- PERFORM R1200_00_FETCH_V0COSSEG_CED_DB_CLOSE_1 */

                    R1200_00_FETCH_V0COSSEG_CED_DB_CLOSE_1();

                    /*" -978- ELSE */
                }
                else
                {


                    /*" -979- DISPLAY 'R1200 - ERRO NO FETCH DA V0COSSEG_CED' */
                    _.Display($"R1200 - ERRO NO FETCH DA V0COSSEG_CED");

                    /*" -980- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -981- END-IF */
                }


                /*" -982- ELSE */
            }
            else
            {


                /*" -983- ADD 1 TO AC-L-V0COSSEGCED */
                AREA_DE_WORK.AC_L_V0COSSEGCED.Value = AREA_DE_WORK.AC_L_V0COSSEGCED + 1;

                /*" -983- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-FETCH-V0COSSEG-CED-DB-FETCH-1 */
        public void R1200_00_FETCH_V0COSSEG_CED_DB_FETCH_1()
        {
            /*" -971- EXEC SQL FETCH V0COSSEGCED INTO :WHOST-COD-RAMO END-EXEC. */

            if (V0COSSEGCED.Fetch())
            {
                _.Move(V0COSSEGCED.WHOST_COD_RAMO, WHOST_COD_RAMO);
            }

        }

        [StopWatch]
        /*" R1200-00-FETCH-V0COSSEG-CED-DB-CLOSE-1 */
        public void R1200_00_FETCH_V0COSSEG_CED_DB_CLOSE_1()
        {
            /*" -976- EXEC SQL CLOSE V0COSSEGCED END-EXEC */

            V0COSSEGCED.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-PROCESSA-COSSEG-CED-SECTION */
        private void R1300_00_PROCESSA_COSSEG_CED_SECTION()
        {
            /*" -996- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -1002- MOVE ZEROS TO WS-PREMIO-P WS-COMISS-P WS-PREMIO-R WS-COMISS-R WS-VLR-SINI. */
            _.Move(0, AREA_DE_WORK.WS_PREMIO_P, AREA_DE_WORK.WS_COMISS_P, AREA_DE_WORK.WS_PREMIO_R, AREA_DE_WORK.WS_COMISS_R, AREA_DE_WORK.WS_VLR_SINI);

            /*" -1004- MOVE WHOST-COD-RAMO TO WCOD-RAMO-ANT. */
            _.Move(WHOST_COD_RAMO, AREA_DE_WORK.WCOD_RAMO_ANT);

            /*" -1010- PERFORM R1400-00-PROCESSA-RAMO UNTIL WFIM-V0COSSEGCED NOT EQUAL SPACES OR WHOST-COD-RAMO NOT EQUAL WCOD-RAMO-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V0COSSEGCED.IsEmpty() || WHOST_COD_RAMO != AREA_DE_WORK.WCOD_RAMO_ANT))
            {

                R1400_00_PROCESSA_RAMO_SECTION();
            }

            /*" -1011- IF WCOD-RAMO-ANT = 48 OR 60 */

            if (AREA_DE_WORK.WCOD_RAMO_ANT.In("48", "60"))
            {

                /*" -1012- ADD WS-PREMIO-P TO WPREM-SQG-P */
                AREA_DE_WORK.WPREM_SQG_P.Value = AREA_DE_WORK.WPREM_SQG_P + AREA_DE_WORK.WS_PREMIO_P;

                /*" -1013- ADD WS-PREMIO-R TO WPREM-SQG-R */
                AREA_DE_WORK.WPREM_SQG_R.Value = AREA_DE_WORK.WPREM_SQG_R + AREA_DE_WORK.WS_PREMIO_R;

                /*" -1016- COMPUTE WCOMS-SQG-T = WCOMS-SQG-T - (WS-COMISS-P + WS-COMISS-R) */
                AREA_DE_WORK.WCOMS_SQG_T.Value = AREA_DE_WORK.WCOMS_SQG_T - (AREA_DE_WORK.WS_COMISS_P + AREA_DE_WORK.WS_COMISS_R);

                /*" -1018- COMPUTE WVLR-SIN-SQG = WVLR-SIN-SQG - WS-VLR-SINI */
                AREA_DE_WORK.WVLR_SIN_SQG.Value = AREA_DE_WORK.WVLR_SIN_SQG - AREA_DE_WORK.WS_VLR_SINI;

                /*" -1019- ELSE */
            }
            else
            {


                /*" -1020- IF WCOD-RAMO-ANT = 77 */

                if (AREA_DE_WORK.WCOD_RAMO_ANT == 77)
                {

                    /*" -1021- ADD WS-PREMIO-P TO WPREM-PRT-P */
                    AREA_DE_WORK.WPREM_PRT_P.Value = AREA_DE_WORK.WPREM_PRT_P + AREA_DE_WORK.WS_PREMIO_P;

                    /*" -1022- ADD WS-PREMIO-R TO WPREM-PRT-R */
                    AREA_DE_WORK.WPREM_PRT_R.Value = AREA_DE_WORK.WPREM_PRT_R + AREA_DE_WORK.WS_PREMIO_R;

                    /*" -1025- COMPUTE WCOMS-PRT-T = WCOMS-PRT-T - (WS-COMISS-P + WS-COMISS-R) */
                    AREA_DE_WORK.WCOMS_PRT_T.Value = AREA_DE_WORK.WCOMS_PRT_T - (AREA_DE_WORK.WS_COMISS_P + AREA_DE_WORK.WS_COMISS_R);

                    /*" -1027- COMPUTE WVLR-SIN-PRT = WVLR-SIN-PRT - WS-VLR-SINI */
                    AREA_DE_WORK.WVLR_SIN_PRT.Value = AREA_DE_WORK.WVLR_SIN_PRT - AREA_DE_WORK.WS_VLR_SINI;

                    /*" -1028- ELSE */
                }
                else
                {


                    /*" -1029- ADD WS-PREMIO-P TO WPREM-DIT-P */
                    AREA_DE_WORK.WPREM_DIT_P.Value = AREA_DE_WORK.WPREM_DIT_P + AREA_DE_WORK.WS_PREMIO_P;

                    /*" -1030- ADD WS-PREMIO-R TO WPREM-DIT-R */
                    AREA_DE_WORK.WPREM_DIT_R.Value = AREA_DE_WORK.WPREM_DIT_R + AREA_DE_WORK.WS_PREMIO_R;

                    /*" -1033- COMPUTE WCOMS-DIT-T = WCOMS-DIT-T - (WS-COMISS-P + WS-COMISS-R) */
                    AREA_DE_WORK.WCOMS_DIT_T.Value = AREA_DE_WORK.WCOMS_DIT_T - (AREA_DE_WORK.WS_COMISS_P + AREA_DE_WORK.WS_COMISS_R);

                    /*" -1035- COMPUTE WVLR-SIN-DIT = WVLR-SIN-DIT - WS-VLR-SINI */
                    AREA_DE_WORK.WVLR_SIN_DIT.Value = AREA_DE_WORK.WVLR_SIN_DIT - AREA_DE_WORK.WS_VLR_SINI;

                    /*" -1036- END-IF */
                }


                /*" -1036- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-PROCESSA-RAMO-SECTION */
        private void R1400_00_PROCESSA_RAMO_SECTION()
        {
            /*" -1049- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -1050- IF V0CCCH-VLPREMIO NOT EQUAL ZEROS */

            if (V0CCCH_VLPREMIO != 00)
            {

                /*" -1051- PERFORM R1500-00-PROCESSA-PREMIOS */

                R1500_00_PROCESSA_PREMIOS_SECTION();

                /*" -1053- END-IF. */
            }


            /*" -1058- IF V0CCCH-VLRSINI NOT EQUAL ZEROS OR V0CCCH-VLDESPESA NOT EQUAL ZEROS OR V0CCCH-VLRHONOR NOT EQUAL ZEROS OR V0CCCH-VLRSALVD NOT EQUAL ZEROS OR V0CCCH-VLRESSARC NOT EQUAL ZEROS */

            if (V0CCCH_VLRSINI != 00 || V0CCCH_VLDESPESA != 00 || V0CCCH_VLRHONOR != 00 || V0CCCH_VLRSALVD != 00 || V0CCCH_VLRESSARC != 00)
            {

                /*" -1059- PERFORM R2000-00-PROCESSA-SINISTROS */

                R2000_00_PROCESSA_SINISTROS_SECTION();

                /*" -1063- END-IF. */
            }


            /*" -1063- PERFORM R1200-00-FETCH-V0COSSEG-CED. */

            R1200_00_FETCH_V0COSSEG_CED_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-PROCESSA-PREMIOS-SECTION */
        private void R1500_00_PROCESSA_PREMIOS_SECTION()
        {
            /*" -1076- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -1078- PERFORM R1600-00-DECLARE-V0COSHISTPRE. */

            R1600_00_DECLARE_V0COSHISTPRE_SECTION();

            /*" -1080- PERFORM R1700-00-FETCH-V0COSHISPRE. */

            R1700_00_FETCH_V0COSHISPRE_SECTION();

            /*" -1081- PERFORM R1800-00-PROCESSA-COSG-HSTPR UNTIL WFIM-V0COSHISPRE NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0COSHISPRE.IsEmpty()))
            {

                R1800_00_PROCESSA_COSG_HSTPR_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-DECLARE-V0COSHISTPRE-SECTION */
        private void R1600_00_DECLARE_V0COSHISTPRE_SECTION()
        {
            /*" -1094- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -1123- PERFORM R1600_00_DECLARE_V0COSHISTPRE_DB_DECLARE_1 */

            R1600_00_DECLARE_V0COSHISTPRE_DB_DECLARE_1();

            /*" -1125- PERFORM R1600_00_DECLARE_V0COSHISTPRE_DB_OPEN_1 */

            R1600_00_DECLARE_V0COSHISTPRE_DB_OPEN_1();

            /*" -1128- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1129- DISPLAY 'R1600 - ERRO NO DECLARE DA V0COSSEG_HISTPRE' */
                _.Display($"R1600 - ERRO NO DECLARE DA V0COSSEG_HISTPRE");

                /*" -1130- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1131- ELSE */
            }
            else
            {


                /*" -1132- MOVE SPACES TO WFIM-V0COSHISPRE */
                _.Move("", AREA_DE_WORK.WFIM_V0COSHISPRE);

                /*" -1132- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-DECLARE-V0COSHISTPRE-DB-OPEN-1 */
        public void R1600_00_DECLARE_V0COSHISTPRE_DB_OPEN_1()
        {
            /*" -1125- EXEC SQL OPEN V0COSHISTPRE END-EXEC. */

            V0COSHISTPRE.Open();

        }

        [StopWatch]
        /*" R2100-00-DECLARE-V0COSHISTSIN-DB-DECLARE-1 */
        public void R2100_00_DECLARE_V0COSHISTSIN_DB_DECLARE_1()
        {
            /*" -1288- EXEC SQL DECLARE V0COSHISTSIN CURSOR FOR SELECT A.NUM_SINISTRO , A.OCORHIST , A.OPERACAO , A.DTMOVTO , A.VAL_OPERACAO , D.IDE_SISTEMA , D.COD_FUNCAO , D.IDE_SISTEMA_OPER , D.NUM_FATOR , C.IND_TIPO_FUNCAO FROM SEGUROS.V0COSSEG_HISTSIN A, SEGUROS.V0MESTSINI B, SEGUROS.GE_OPERACAO C, SEGUROS.GE_SIS_FUNCAO_OPER D WHERE A.TIPSGU = '1' AND A.COD_EMPRESA = :V0CCCH-COD-EMPR AND A.CONGENER = :V0CCCH-CONGENER AND A.DTMOVTO = :V0CCCH-DTMOVTAC AND A.SITUACAO = '1' AND A.SIT_LIBRECUP = '0' AND B.NUM_APOL_SINISTRO = A.NUM_SINISTRO AND B.RAMO = :WHOST-COD-RAMO AND C.IDE_SISTEMA = 'AC' AND C.COD_OPERACAO = A.OPERACAO AND D.IDE_SISTEMA = C.IDE_SISTEMA AND D.COD_FUNCAO = 01 AND D.IDE_SISTEMA_OPER = C.IDE_SISTEMA AND D.COD_OPERACAO = C.COD_OPERACAO ORDER BY A.NUM_SINISTRO, A.OCORHIST, A.OPERACAO WITH UR END-EXEC. */
            V0COSHISTSIN = new AC0820B_V0COSHISTSIN(true);
            string GetQuery_V0COSHISTSIN()
            {
                var query = @$"SELECT A.NUM_SINISTRO
							, 
							A.OCORHIST
							, 
							A.OPERACAO
							, 
							A.DTMOVTO
							, 
							A.VAL_OPERACAO
							, 
							D.IDE_SISTEMA
							, 
							D.COD_FUNCAO
							, 
							D.IDE_SISTEMA_OPER
							, 
							D.NUM_FATOR
							, 
							C.IND_TIPO_FUNCAO 
							FROM SEGUROS.V0COSSEG_HISTSIN A
							, 
							SEGUROS.V0MESTSINI B
							, 
							SEGUROS.GE_OPERACAO C
							, 
							SEGUROS.GE_SIS_FUNCAO_OPER D 
							WHERE A.TIPSGU = '1' 
							AND A.COD_EMPRESA = '{V0CCCH_COD_EMPR}' 
							AND A.CONGENER = '{V0CCCH_CONGENER}' 
							AND A.DTMOVTO = '{V0CCCH_DTMOVTAC}' 
							AND A.SITUACAO = '1' 
							AND A.SIT_LIBRECUP = '0' 
							AND B.NUM_APOL_SINISTRO = A.NUM_SINISTRO 
							AND B.RAMO = '{WHOST_COD_RAMO}' 
							AND C.IDE_SISTEMA = 'AC' 
							AND C.COD_OPERACAO = A.OPERACAO 
							AND D.IDE_SISTEMA = C.IDE_SISTEMA 
							AND D.COD_FUNCAO = 01 
							AND D.IDE_SISTEMA_OPER = C.IDE_SISTEMA 
							AND D.COD_OPERACAO = C.COD_OPERACAO 
							ORDER BY 
							A.NUM_SINISTRO
							, 
							A.OCORHIST
							, 
							A.OPERACAO";

                return query;
            }
            V0COSHISTSIN.GetQueryEvent += GetQuery_V0COSHISTSIN;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-FETCH-V0COSHISPRE-SECTION */
        private void R1700_00_FETCH_V0COSHISPRE_SECTION()
        {
            /*" -1143- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1700_10_LER_V0COSHISPRE */

            R1700_10_LER_V0COSHISPRE();

        }

        [StopWatch]
        /*" R1700-10-LER-V0COSHISPRE */
        private void R1700_10_LER_V0COSHISPRE(bool isPerform = false)
        {
            /*" -1160- PERFORM R1700_10_LER_V0COSHISPRE_DB_FETCH_1 */

            R1700_10_LER_V0COSHISPRE_DB_FETCH_1();

            /*" -1163- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1164- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1165- MOVE 'S' TO WFIM-V0COSHISPRE */
                    _.Move("S", AREA_DE_WORK.WFIM_V0COSHISPRE);

                    /*" -1165- PERFORM R1700_10_LER_V0COSHISPRE_DB_CLOSE_1 */

                    R1700_10_LER_V0COSHISPRE_DB_CLOSE_1();

                    /*" -1167- ELSE */
                }
                else
                {


                    /*" -1168- DISPLAY 'R1700 - ERRO NO FETCH DA V0COSSEG_HISTPRE' */
                    _.Display($"R1700 - ERRO NO FETCH DA V0COSSEG_HISTPRE");

                    /*" -1169- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1170- END-IF */
                }


                /*" -1171- ELSE */
            }
            else
            {


                /*" -1175- IF V0CHSP-OPERACAO NOT = 0910 AND 0911 AND 0930 AND 0931 AND 0940 AND 0941 AND 0950 AND 0951 */

                if (!V0CHSP_OPERACAO.In("0910", "0911", "0930", "0931", "0940", "0941", "0950", "0951"))
                {

                    /*" -1176- GO TO R1700-10-LER-V0COSHISPRE */
                    new Task(() => R1700_10_LER_V0COSHISPRE()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1177- ELSE */
                }
                else
                {


                    /*" -1178- ADD 1 TO AC-L-V0COSHISPRE */
                    AREA_DE_WORK.AC_L_V0COSHISPRE.Value = AREA_DE_WORK.AC_L_V0COSHISPRE + 1;

                    /*" -1179- END-IF */
                }


                /*" -1179- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-10-LER-V0COSHISPRE-DB-FETCH-1 */
        public void R1700_10_LER_V0COSHISPRE_DB_FETCH_1()
        {
            /*" -1160- EXEC SQL FETCH V0COSHISTPRE INTO :V0CHSP-NUM-APOL, :V0CHSP-NRENDOS, :V0CHSP-NRPARCEL, :V0CHSP-OCORHIST, :V0CHSP-DTMOVTO, :V0CHSP-OPERACAO, :V0CHSP-PRM-TAR, :V0CHSP-VAL-DESC, :V0CHSP-VLPRMLIQ, :V0CHSP-VLADIFRA, :V0CHSP-VLCOMIS, :V0CHSP-VLPRMTOT END-EXEC. */

            if (V0COSHISTPRE.Fetch())
            {
                _.Move(V0COSHISTPRE.V0CHSP_NUM_APOL, V0CHSP_NUM_APOL);
                _.Move(V0COSHISTPRE.V0CHSP_NRENDOS, V0CHSP_NRENDOS);
                _.Move(V0COSHISTPRE.V0CHSP_NRPARCEL, V0CHSP_NRPARCEL);
                _.Move(V0COSHISTPRE.V0CHSP_OCORHIST, V0CHSP_OCORHIST);
                _.Move(V0COSHISTPRE.V0CHSP_DTMOVTO, V0CHSP_DTMOVTO);
                _.Move(V0COSHISTPRE.V0CHSP_OPERACAO, V0CHSP_OPERACAO);
                _.Move(V0COSHISTPRE.V0CHSP_PRM_TAR, V0CHSP_PRM_TAR);
                _.Move(V0COSHISTPRE.V0CHSP_VAL_DESC, V0CHSP_VAL_DESC);
                _.Move(V0COSHISTPRE.V0CHSP_VLPRMLIQ, V0CHSP_VLPRMLIQ);
                _.Move(V0COSHISTPRE.V0CHSP_VLADIFRA, V0CHSP_VLADIFRA);
                _.Move(V0COSHISTPRE.V0CHSP_VLCOMIS, V0CHSP_VLCOMIS);
                _.Move(V0COSHISTPRE.V0CHSP_VLPRMTOT, V0CHSP_VLPRMTOT);
            }

        }

        [StopWatch]
        /*" R1700-10-LER-V0COSHISPRE-DB-CLOSE-1 */
        public void R1700_10_LER_V0COSHISPRE_DB_CLOSE_1()
        {
            /*" -1165- EXEC SQL CLOSE V0COSHISTPRE END-EXEC */

            V0COSHISTPRE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-PROCESSA-COSG-HSTPR-SECTION */
        private void R1800_00_PROCESSA_COSG_HSTPR_SECTION()
        {
            /*" -1192- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", WABEND.WNR_EXEC_SQL);

            /*" -1194- IF V0CHSP-OPERACAO = 0911 OR 0950 OR 0930 OR 0941 */

            if (V0CHSP_OPERACAO.In("0911", "0950", "0930", "0941"))
            {

                /*" -1195- COMPUTE V0CHSP-PRM-TAR = V0CHSP-PRM-TAR * -1 */
                V0CHSP_PRM_TAR.Value = V0CHSP_PRM_TAR * -1;

                /*" -1196- COMPUTE V0CHSP-VAL-DESC = V0CHSP-VAL-DESC * -1 */
                V0CHSP_VAL_DESC.Value = V0CHSP_VAL_DESC * -1;

                /*" -1197- COMPUTE V0CHSP-VLADIFRA = V0CHSP-VLADIFRA * -1 */
                V0CHSP_VLADIFRA.Value = V0CHSP_VLADIFRA * -1;

                /*" -1198- COMPUTE V0CHSP-VLCOMIS = V0CHSP-VLCOMIS * -1 */
                V0CHSP_VLCOMIS.Value = V0CHSP_VLCOMIS * -1;

                /*" -1199- COMPUTE V0CHSP-VLPRMTOT = V0CHSP-VLPRMTOT * -1 */
                V0CHSP_VLPRMTOT.Value = V0CHSP_VLPRMTOT * -1;

                /*" -1201- END-IF. */
            }


            /*" -1203- IF V0CHSP-OPERACAO = 0911 OR 0951 OR 0931 OR 0941 */

            if (V0CHSP_OPERACAO.In("0911", "0951", "0931", "0941"))
            {

                /*" -1208- COMPUTE WS-PREMIO-R = WS-PREMIO-R + (V0CHSP-PRM-TAR - V0CHSP-VAL-DESC + V0CHSP-VLADIFRA) */
                AREA_DE_WORK.WS_PREMIO_R.Value = AREA_DE_WORK.WS_PREMIO_R + (V0CHSP_PRM_TAR - V0CHSP_VAL_DESC + V0CHSP_VLADIFRA);

                /*" -1209- COMPUTE WS-COMISS-R = WS-COMISS-R + V0CHSP-VLCOMIS */
                AREA_DE_WORK.WS_COMISS_R.Value = AREA_DE_WORK.WS_COMISS_R + V0CHSP_VLCOMIS;

                /*" -1210- ELSE */
            }
            else
            {


                /*" -1215- COMPUTE WS-PREMIO-P = WS-PREMIO-P + (V0CHSP-PRM-TAR - V0CHSP-VAL-DESC + V0CHSP-VLADIFRA) */
                AREA_DE_WORK.WS_PREMIO_P.Value = AREA_DE_WORK.WS_PREMIO_P + (V0CHSP_PRM_TAR - V0CHSP_VAL_DESC + V0CHSP_VLADIFRA);

                /*" -1216- COMPUTE WS-COMISS-P = WS-COMISS-P + V0CHSP-VLCOMIS */
                AREA_DE_WORK.WS_COMISS_P.Value = AREA_DE_WORK.WS_COMISS_P + V0CHSP_VLCOMIS;

                /*" -1220- END-IF. */
            }


            /*" -1220- PERFORM R1700-00-FETCH-V0COSHISPRE. */

            R1700_00_FETCH_V0COSHISPRE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-SINISTROS-SECTION */
        private void R2000_00_PROCESSA_SINISTROS_SECTION()
        {
            /*" -1233- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -1235- PERFORM R2100-00-DECLARE-V0COSHISTSIN. */

            R2100_00_DECLARE_V0COSHISTSIN_SECTION();

            /*" -1237- PERFORM R2200-00-FETCH-V0COSHISSIN. */

            R2200_00_FETCH_V0COSHISSIN_SECTION();

            /*" -1238- PERFORM R2300-00-PROCESSA-COSG-HSTSI UNTIL WFIM-V0COSHISSIN NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0COSHISSIN.IsEmpty()))
            {

                R2300_00_PROCESSA_COSG_HSTSI_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-DECLARE-V0COSHISTSIN-SECTION */
        private void R2100_00_DECLARE_V0COSHISTSIN_SECTION()
        {
            /*" -1251- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -1288- PERFORM R2100_00_DECLARE_V0COSHISTSIN_DB_DECLARE_1 */

            R2100_00_DECLARE_V0COSHISTSIN_DB_DECLARE_1();

            /*" -1290- PERFORM R2100_00_DECLARE_V0COSHISTSIN_DB_OPEN_1 */

            R2100_00_DECLARE_V0COSHISTSIN_DB_OPEN_1();

            /*" -1293- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1294- DISPLAY 'R2100 - ERRO NO DECLARE DA V0COSSEG_HISTSIN' */
                _.Display($"R2100 - ERRO NO DECLARE DA V0COSSEG_HISTSIN");

                /*" -1295- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1296- ELSE */
            }
            else
            {


                /*" -1297- MOVE SPACES TO WFIM-V0COSHISSIN */
                _.Move("", AREA_DE_WORK.WFIM_V0COSHISSIN);

                /*" -1297- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-DECLARE-V0COSHISTSIN-DB-OPEN-1 */
        public void R2100_00_DECLARE_V0COSHISTSIN_DB_OPEN_1()
        {
            /*" -1290- EXEC SQL OPEN V0COSHISTSIN END-EXEC. */

            V0COSHISTSIN.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-FETCH-V0COSHISSIN-SECTION */
        private void R2200_00_FETCH_V0COSHISSIN_SECTION()
        {
            /*" -1310- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -1321- PERFORM R2200_00_FETCH_V0COSHISSIN_DB_FETCH_1 */

            R2200_00_FETCH_V0COSHISSIN_DB_FETCH_1();

            /*" -1324- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1325- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1326- MOVE 'S' TO WFIM-V0COSHISSIN */
                    _.Move("S", AREA_DE_WORK.WFIM_V0COSHISSIN);

                    /*" -1326- PERFORM R2200_00_FETCH_V0COSHISSIN_DB_CLOSE_1 */

                    R2200_00_FETCH_V0COSHISSIN_DB_CLOSE_1();

                    /*" -1328- ELSE */
                }
                else
                {


                    /*" -1329- DISPLAY 'R2200 - ERRO NO FETCH DA V0COSSEG_HISTSIN' */
                    _.Display($"R2200 - ERRO NO FETCH DA V0COSSEG_HISTSIN");

                    /*" -1330- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1331- END-IF */
                }


                /*" -1332- ELSE */
            }
            else
            {


                /*" -1333- ADD 1 TO AC-L-V0COSHISSIN */
                AREA_DE_WORK.AC_L_V0COSHISSIN.Value = AREA_DE_WORK.AC_L_V0COSHISSIN + 1;

                /*" -1333- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-FETCH-V0COSHISSIN-DB-FETCH-1 */
        public void R2200_00_FETCH_V0COSHISSIN_DB_FETCH_1()
        {
            /*" -1321- EXEC SQL FETCH V0COSHISTSIN INTO :V0CHIS-NUM-SINI , :V0CHIS-OCORHIST , :V0CHIS-OPERACAO , :V0CHIS-DTMOVTO , :V0CHIS-VAL-OPER , :GESISFUO-IDE-SISTEMA , :GESISFUO-COD-FUNCAO , :GESISFUO-IDE-SISTEMA-OPER , :GESISFUO-NUM-FATOR , :GEOPERAC-IND-TIPO-FUNCAO END-EXEC. */

            if (V0COSHISTSIN.Fetch())
            {
                _.Move(V0COSHISTSIN.V0CHIS_NUM_SINI, V0CHIS_NUM_SINI);
                _.Move(V0COSHISTSIN.V0CHIS_OCORHIST, V0CHIS_OCORHIST);
                _.Move(V0COSHISTSIN.V0CHIS_OPERACAO, V0CHIS_OPERACAO);
                _.Move(V0COSHISTSIN.V0CHIS_DTMOVTO, V0CHIS_DTMOVTO);
                _.Move(V0COSHISTSIN.V0CHIS_VAL_OPER, V0CHIS_VAL_OPER);
                _.Move(V0COSHISTSIN.GESISFUO_IDE_SISTEMA, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA);
                _.Move(V0COSHISTSIN.GESISFUO_COD_FUNCAO, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO);
                _.Move(V0COSHISTSIN.GESISFUO_IDE_SISTEMA_OPER, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER);
                _.Move(V0COSHISTSIN.GESISFUO_NUM_FATOR, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);
                _.Move(V0COSHISTSIN.GEOPERAC_IND_TIPO_FUNCAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO);
            }

        }

        [StopWatch]
        /*" R2200-00-FETCH-V0COSHISSIN-DB-CLOSE-1 */
        public void R2200_00_FETCH_V0COSHISSIN_DB_CLOSE_1()
        {
            /*" -1326- EXEC SQL CLOSE V0COSHISTSIN END-EXEC */

            V0COSHISTSIN.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-PROCESSA-COSG-HSTSI-SECTION */
        private void R2300_00_PROCESSA_COSG_HSTSI_SECTION()
        {
            /*" -1346- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -1347- IF GEOPERAC-IND-TIPO-FUNCAO = 'SA' OR 'RESSA-RECE' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("SA", "RESSA-RECE"))
            {

                /*" -1348- COMPUTE GESISFUO-NUM-FATOR = GESISFUO-NUM-FATOR * -1 */
                GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR.Value = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR * -1;

                /*" -1350- END-IF. */
            }


            /*" -1353- COMPUTE V0CHIS-VAL-OPER = V0CHIS-VAL-OPER * GESISFUO-NUM-FATOR. */
            V0CHIS_VAL_OPER.Value = V0CHIS_VAL_OPER * GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR;

            /*" -1357- ADD V0CHIS-VAL-OPER TO WS-VLR-SINI. */
            AREA_DE_WORK.WS_VLR_SINI.Value = AREA_DE_WORK.WS_VLR_SINI + V0CHIS_VAL_OPER;

            /*" -1357- PERFORM R2200-00-FETCH-V0COSHISSIN. */

            R2200_00_FETCH_V0COSHISSIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-GRAVA-AC0820B1-SECTION */
        private void R3000_00_GRAVA_AC0820B1_SECTION()
        {
            /*" -1370- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WABEND.WNR_EXEC_SQL);

            /*" -1372- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1373- MOVE 'PREMIOS     ' TO LD01-DESCR-VLR. */
            _.Move("PREMIOS     ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1374- MOVE WPREM-SQG-P TO LD01-VALOR-01. */
            _.Move(AREA_DE_WORK.WPREM_SQG_P, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1375- MOVE WPREM-PRT-P TO LD01-VALOR-02. */
            _.Move(AREA_DE_WORK.WPREM_PRT_P, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1377- MOVE WPREM-DIT-P TO LD01-VALOR-03. */
            _.Move(AREA_DE_WORK.WPREM_DIT_P, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1379- MOVE ZEROS TO WS-TOT-TITL. */
            _.Move(0, AREA_DE_WORK.WS_TOT_TITL);

            /*" -1382- COMPUTE WS-TOT-TITL = WPREM-SQG-P + WPREM-PRT-P + WPREM-DIT-P. */
            AREA_DE_WORK.WS_TOT_TITL.Value = AREA_DE_WORK.WPREM_SQG_P + AREA_DE_WORK.WPREM_PRT_P + AREA_DE_WORK.WPREM_DIT_P;

            /*" -1384- MOVE WS-TOT-TITL TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_TITL, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1386- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

            /*" -1388- ADD WS-TOT-TITL TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + AREA_DE_WORK.WS_TOT_TITL;

            /*" -1390- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1391- MOVE 'COMISSOES   ' TO LD01-DESCR-VLR. */
            _.Move("COMISSOES   ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1392- MOVE WCOMS-SQG-T TO LD01-VALOR-01. */
            _.Move(AREA_DE_WORK.WCOMS_SQG_T, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1393- MOVE WCOMS-PRT-T TO LD01-VALOR-02. */
            _.Move(AREA_DE_WORK.WCOMS_PRT_T, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1395- MOVE WCOMS-DIT-T TO LD01-VALOR-03. */
            _.Move(AREA_DE_WORK.WCOMS_DIT_T, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1397- MOVE ZEROS TO WS-TOT-TITL. */
            _.Move(0, AREA_DE_WORK.WS_TOT_TITL);

            /*" -1400- COMPUTE WS-TOT-TITL = WCOMS-SQG-T + WCOMS-PRT-T + WCOMS-DIT-T. */
            AREA_DE_WORK.WS_TOT_TITL.Value = AREA_DE_WORK.WCOMS_SQG_T + AREA_DE_WORK.WCOMS_PRT_T + AREA_DE_WORK.WCOMS_DIT_T;

            /*" -1402- MOVE WS-TOT-TITL TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_TITL, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1404- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

            /*" -1406- ADD WS-TOT-TITL TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + AREA_DE_WORK.WS_TOT_TITL;

            /*" -1408- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1409- MOVE 'RESTITUICOES' TO LD01-DESCR-VLR. */
            _.Move("RESTITUICOES", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1410- MOVE WPREM-SQG-R TO LD01-VALOR-01. */
            _.Move(AREA_DE_WORK.WPREM_SQG_R, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1411- MOVE WPREM-PRT-R TO LD01-VALOR-02. */
            _.Move(AREA_DE_WORK.WPREM_PRT_R, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1413- MOVE WPREM-DIT-R TO LD01-VALOR-03. */
            _.Move(AREA_DE_WORK.WPREM_DIT_R, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1415- MOVE ZEROS TO WS-TOT-TITL. */
            _.Move(0, AREA_DE_WORK.WS_TOT_TITL);

            /*" -1418- COMPUTE WS-TOT-TITL = WPREM-SQG-R + WPREM-PRT-R + WPREM-DIT-R. */
            AREA_DE_WORK.WS_TOT_TITL.Value = AREA_DE_WORK.WPREM_SQG_R + AREA_DE_WORK.WPREM_PRT_R + AREA_DE_WORK.WPREM_DIT_R;

            /*" -1420- MOVE WS-TOT-TITL TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_TITL, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1422- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

            /*" -1424- ADD WS-TOT-TITL TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + AREA_DE_WORK.WS_TOT_TITL;

            /*" -1426- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1427- MOVE 'SINISTROS (VALOR A RECUPERAR) ' TO LD01-DESCR-VLR. */
            _.Move("SINISTROS (VALOR A RECUPERAR) ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1428- MOVE WVLR-SIN-SQG TO LD01-VALOR-01. */
            _.Move(AREA_DE_WORK.WVLR_SIN_SQG, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1429- MOVE WVLR-SIN-PRT TO LD01-VALOR-02. */
            _.Move(AREA_DE_WORK.WVLR_SIN_PRT, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1431- MOVE WVLR-SIN-DIT TO LD01-VALOR-03. */
            _.Move(AREA_DE_WORK.WVLR_SIN_DIT, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1433- MOVE ZEROS TO WS-TOT-TITL. */
            _.Move(0, AREA_DE_WORK.WS_TOT_TITL);

            /*" -1436- COMPUTE WS-TOT-TITL = WVLR-SIN-SQG + WVLR-SIN-PRT + WVLR-SIN-DIT. */
            AREA_DE_WORK.WS_TOT_TITL.Value = AREA_DE_WORK.WVLR_SIN_SQG + AREA_DE_WORK.WVLR_SIN_PRT + AREA_DE_WORK.WVLR_SIN_DIT;

            /*" -1438- MOVE WS-TOT-TITL TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_TITL, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1440- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

            /*" -1442- ADD WS-TOT-TITL TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + AREA_DE_WORK.WS_TOT_TITL;

            /*" -1444- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1446- MOVE 'CUSTO DE EMISSAO ' TO LD01-DESCR-VLR. */
            _.Move("CUSTO DE EMISSAO ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1451- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1453- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

            /*" -1455- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1457- MOVE 'PRO-LABORE ' TO LD01-DESCR-VLR. */
            _.Move("PRO-LABORE ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1462- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1464- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

            /*" -1466- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1468- MOVE 'RESTUICOES S/ CE E PRO-LABORE ' TO LD01-DESCR-VLR. */
            _.Move("RESTUICOES S/ CE E PRO-LABORE ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1473- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1475- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

            /*" -1477- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1479- MOVE 'DESPESAS BANCARIAS (TARIFAS)  ' TO LD01-DESCR-VLR. */
            _.Move("DESPESAS BANCARIAS (TARIFAS)  ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1484- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1486- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

            /*" -1488- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1490- MOVE 'OUTROS DEBITOS ' TO LD01-DESCR-VLR. */
            _.Move("OUTROS DEBITOS ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1492- COMPUTE V0CCCH-OUTRDEBIT = V0CCCH-OUTRDEBIT * -1. */
            V0CCCH_OUTRDEBIT.Value = V0CCCH_OUTRDEBIT * -1;

            /*" -1493- MOVE ZEROS TO LD01-VALOR-01 */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1494- MOVE V0CCCH-OUTRDEBIT TO LD01-VALOR-02 */
            _.Move(V0CCCH_OUTRDEBIT, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1496- MOVE ZEROS TO LD01-VALOR-03. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1498- MOVE V0CCCH-OUTRDEBIT TO LD01-VALOR-04. */
            _.Move(V0CCCH_OUTRDEBIT, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1500- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

            /*" -1502- ADD V0CCCH-OUTRDEBIT TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + V0CCCH_OUTRDEBIT;

            /*" -1504- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1506- MOVE 'OUTROS CREDITOS ' TO LD01-DESCR-VLR. */
            _.Move("OUTROS CREDITOS ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1507- MOVE ZEROS TO LD01-VALOR-01 */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1508- MOVE V0CCCH-OUTRCREDT TO LD01-VALOR-02 */
            _.Move(V0CCCH_OUTRCREDT, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1510- MOVE ZEROS TO LD01-VALOR-03. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1512- MOVE V0CCCH-OUTRCREDT TO LD01-VALOR-04. */
            _.Move(V0CCCH_OUTRCREDT, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1514- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

            /*" -1516- ADD V0CCCH-OUTRCREDT TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + V0CCCH_OUTRCREDT;

            /*" -1518- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1520- MOVE 'TOTAL LIQ. POR PRODUTO ' TO LD01-DESCR-VLR. */
            _.Move("TOTAL LIQ. POR PRODUTO ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1525- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1527- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

            /*" -1529- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1531- MOVE 'ACERTO DE SALDO ANTERIOR      ' TO LD01-DESCR-VLR. */
            _.Move("ACERTO DE SALDO ANTERIOR      ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1536- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1538- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

            /*" -1540- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1542- MOVE 'SALDO ANTERIOR A RECUPERAR    ' TO LD01-DESCR-VLR. */
            _.Move("SALDO ANTERIOR A RECUPERAR    ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1547- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1549- COMPUTE V0CCCH-VLRSLDANT = V0CCCH-VLRSLDANT * -1. */
            V0CCCH_VLRSLDANT.Value = V0CCCH_VLRSLDANT * -1;

            /*" -1551- MOVE V0CCCH-VLRSLDANT TO LD01-VALOR-04. */
            _.Move(V0CCCH_VLRSLDANT, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1553- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

            /*" -1555- ADD V0CCCH-VLRSLDANT TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + V0CCCH_VLRSLDANT;

            /*" -1557- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1559- MOVE 'TOTAL CONGENERE ' TO LD01-DESCR-VLR. */
            _.Move("TOTAL CONGENERE ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1563- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1565- MOVE WS-TOT-CONG TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_CONG, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1565- WRITE REG-AC0820B1 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B1);

            AC0820B1.Write(REG_AC0820B1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-GRAVA-AC0820B2-SECTION */
        private void R3100_00_GRAVA_AC0820B2_SECTION()
        {
            /*" -1578- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -1580- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1581- MOVE 'PREMIOS     ' TO LD01-DESCR-VLR. */
            _.Move("PREMIOS     ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1582- MOVE WPREM-SQG-P TO LD01-VALOR-01. */
            _.Move(AREA_DE_WORK.WPREM_SQG_P, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1583- MOVE WPREM-PRT-P TO LD01-VALOR-02. */
            _.Move(AREA_DE_WORK.WPREM_PRT_P, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1585- MOVE WPREM-DIT-P TO LD01-VALOR-03. */
            _.Move(AREA_DE_WORK.WPREM_DIT_P, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1587- MOVE ZEROS TO WS-TOT-TITL. */
            _.Move(0, AREA_DE_WORK.WS_TOT_TITL);

            /*" -1590- COMPUTE WS-TOT-TITL = WPREM-SQG-P + WPREM-PRT-P + WPREM-DIT-P. */
            AREA_DE_WORK.WS_TOT_TITL.Value = AREA_DE_WORK.WPREM_SQG_P + AREA_DE_WORK.WPREM_PRT_P + AREA_DE_WORK.WPREM_DIT_P;

            /*" -1592- MOVE WS-TOT-TITL TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_TITL, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1594- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

            /*" -1596- ADD WS-TOT-TITL TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + AREA_DE_WORK.WS_TOT_TITL;

            /*" -1598- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1599- MOVE 'COMISSOES   ' TO LD01-DESCR-VLR. */
            _.Move("COMISSOES   ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1600- MOVE WCOMS-SQG-T TO LD01-VALOR-01. */
            _.Move(AREA_DE_WORK.WCOMS_SQG_T, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1601- MOVE WCOMS-PRT-T TO LD01-VALOR-02. */
            _.Move(AREA_DE_WORK.WCOMS_PRT_T, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1603- MOVE WCOMS-DIT-T TO LD01-VALOR-03. */
            _.Move(AREA_DE_WORK.WCOMS_DIT_T, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1605- MOVE ZEROS TO WS-TOT-TITL. */
            _.Move(0, AREA_DE_WORK.WS_TOT_TITL);

            /*" -1608- COMPUTE WS-TOT-TITL = WCOMS-SQG-T + WCOMS-PRT-T + WCOMS-DIT-T. */
            AREA_DE_WORK.WS_TOT_TITL.Value = AREA_DE_WORK.WCOMS_SQG_T + AREA_DE_WORK.WCOMS_PRT_T + AREA_DE_WORK.WCOMS_DIT_T;

            /*" -1610- MOVE WS-TOT-TITL TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_TITL, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1612- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

            /*" -1614- ADD WS-TOT-TITL TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + AREA_DE_WORK.WS_TOT_TITL;

            /*" -1616- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1617- MOVE 'RESTITUICOES' TO LD01-DESCR-VLR. */
            _.Move("RESTITUICOES", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1618- MOVE WPREM-SQG-R TO LD01-VALOR-01. */
            _.Move(AREA_DE_WORK.WPREM_SQG_R, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1619- MOVE WPREM-PRT-R TO LD01-VALOR-02. */
            _.Move(AREA_DE_WORK.WPREM_PRT_R, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1621- MOVE WPREM-DIT-R TO LD01-VALOR-03. */
            _.Move(AREA_DE_WORK.WPREM_DIT_R, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1623- MOVE ZEROS TO WS-TOT-TITL. */
            _.Move(0, AREA_DE_WORK.WS_TOT_TITL);

            /*" -1626- COMPUTE WS-TOT-TITL = WPREM-SQG-R + WPREM-PRT-R + WPREM-DIT-R. */
            AREA_DE_WORK.WS_TOT_TITL.Value = AREA_DE_WORK.WPREM_SQG_R + AREA_DE_WORK.WPREM_PRT_R + AREA_DE_WORK.WPREM_DIT_R;

            /*" -1628- MOVE WS-TOT-TITL TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_TITL, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1630- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

            /*" -1632- ADD WS-TOT-TITL TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + AREA_DE_WORK.WS_TOT_TITL;

            /*" -1634- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1635- MOVE 'SINISTROS (VALOR A RECUPERAR) ' TO LD01-DESCR-VLR. */
            _.Move("SINISTROS (VALOR A RECUPERAR) ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1636- MOVE WVLR-SIN-SQG TO LD01-VALOR-01. */
            _.Move(AREA_DE_WORK.WVLR_SIN_SQG, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1637- MOVE WVLR-SIN-PRT TO LD01-VALOR-02. */
            _.Move(AREA_DE_WORK.WVLR_SIN_PRT, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1639- MOVE WVLR-SIN-DIT TO LD01-VALOR-03. */
            _.Move(AREA_DE_WORK.WVLR_SIN_DIT, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1641- MOVE ZEROS TO WS-TOT-TITL. */
            _.Move(0, AREA_DE_WORK.WS_TOT_TITL);

            /*" -1644- COMPUTE WS-TOT-TITL = WVLR-SIN-SQG + WVLR-SIN-PRT + WVLR-SIN-DIT. */
            AREA_DE_WORK.WS_TOT_TITL.Value = AREA_DE_WORK.WVLR_SIN_SQG + AREA_DE_WORK.WVLR_SIN_PRT + AREA_DE_WORK.WVLR_SIN_DIT;

            /*" -1646- MOVE WS-TOT-TITL TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_TITL, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1648- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

            /*" -1650- ADD WS-TOT-TITL TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + AREA_DE_WORK.WS_TOT_TITL;

            /*" -1652- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1654- MOVE 'CUSTO DE EMISSAO ' TO LD01-DESCR-VLR. */
            _.Move("CUSTO DE EMISSAO ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1659- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1661- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

            /*" -1663- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1665- MOVE 'PRO-LABORE ' TO LD01-DESCR-VLR. */
            _.Move("PRO-LABORE ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1670- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1672- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

            /*" -1674- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1676- MOVE 'RESTUICOES S/ CE E PRO-LABORE ' TO LD01-DESCR-VLR. */
            _.Move("RESTUICOES S/ CE E PRO-LABORE ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1681- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1683- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

            /*" -1685- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1687- MOVE 'DESPESAS BANCARIAS (TARIFAS)  ' TO LD01-DESCR-VLR. */
            _.Move("DESPESAS BANCARIAS (TARIFAS)  ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1692- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1694- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

            /*" -1696- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1698- MOVE 'OUTROS DEBITOS ' TO LD01-DESCR-VLR. */
            _.Move("OUTROS DEBITOS ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1700- COMPUTE V0CCCH-OUTRDEBIT = V0CCCH-OUTRDEBIT * -1. */
            V0CCCH_OUTRDEBIT.Value = V0CCCH_OUTRDEBIT * -1;

            /*" -1701- MOVE ZEROS TO LD01-VALOR-01 */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1702- MOVE V0CCCH-OUTRDEBIT TO LD01-VALOR-02 */
            _.Move(V0CCCH_OUTRDEBIT, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1704- MOVE ZEROS TO LD01-VALOR-03. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1706- MOVE V0CCCH-OUTRDEBIT TO LD01-VALOR-04. */
            _.Move(V0CCCH_OUTRDEBIT, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1708- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

            /*" -1710- ADD V0CCCH-OUTRDEBIT TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + V0CCCH_OUTRDEBIT;

            /*" -1712- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1714- MOVE 'OUTROS CREDITOS ' TO LD01-DESCR-VLR. */
            _.Move("OUTROS CREDITOS ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1715- MOVE ZEROS TO LD01-VALOR-01 */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1716- MOVE V0CCCH-OUTRCREDT TO LD01-VALOR-02 */
            _.Move(V0CCCH_OUTRCREDT, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1718- MOVE ZEROS TO LD01-VALOR-03. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1720- MOVE V0CCCH-OUTRCREDT TO LD01-VALOR-04. */
            _.Move(V0CCCH_OUTRCREDT, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1722- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

            /*" -1724- ADD V0CCCH-OUTRCREDT TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + V0CCCH_OUTRCREDT;

            /*" -1726- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1728- MOVE 'TOTAL LIQ. POR PRODUTO ' TO LD01-DESCR-VLR. */
            _.Move("TOTAL LIQ. POR PRODUTO ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1733- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1735- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

            /*" -1737- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1739- MOVE 'ACERTO DE SALDO ANTERIOR      ' TO LD01-DESCR-VLR. */
            _.Move("ACERTO DE SALDO ANTERIOR      ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1744- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1746- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

            /*" -1748- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1750- MOVE 'SALDO ANTERIOR A RECUPERAR    ' TO LD01-DESCR-VLR. */
            _.Move("SALDO ANTERIOR A RECUPERAR    ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1755- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1757- COMPUTE V0CCCH-VLRSLDANT = V0CCCH-VLRSLDANT * -1. */
            V0CCCH_VLRSLDANT.Value = V0CCCH_VLRSLDANT * -1;

            /*" -1759- MOVE V0CCCH-VLRSLDANT TO LD01-VALOR-04. */
            _.Move(V0CCCH_VLRSLDANT, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1761- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

            /*" -1763- ADD V0CCCH-VLRSLDANT TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + V0CCCH_VLRSLDANT;

            /*" -1765- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1767- MOVE 'TOTAL CONGENERE ' TO LD01-DESCR-VLR. */
            _.Move("TOTAL CONGENERE ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1771- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1773- MOVE WS-TOT-CONG TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_CONG, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1773- WRITE REG-AC0820B2 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B2);

            AC0820B2.Write(REG_AC0820B2.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-GRAVA-AC0820B3-SECTION */
        private void R3200_00_GRAVA_AC0820B3_SECTION()
        {
            /*" -1786- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", WABEND.WNR_EXEC_SQL);

            /*" -1788- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1789- MOVE 'PREMIOS     ' TO LD01-DESCR-VLR. */
            _.Move("PREMIOS     ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1790- MOVE WPREM-SQG-P TO LD01-VALOR-01. */
            _.Move(AREA_DE_WORK.WPREM_SQG_P, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1791- MOVE WPREM-PRT-P TO LD01-VALOR-02. */
            _.Move(AREA_DE_WORK.WPREM_PRT_P, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1793- MOVE WPREM-DIT-P TO LD01-VALOR-03. */
            _.Move(AREA_DE_WORK.WPREM_DIT_P, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1795- MOVE ZEROS TO WS-TOT-TITL. */
            _.Move(0, AREA_DE_WORK.WS_TOT_TITL);

            /*" -1798- COMPUTE WS-TOT-TITL = WPREM-SQG-P + WPREM-PRT-P + WPREM-DIT-P. */
            AREA_DE_WORK.WS_TOT_TITL.Value = AREA_DE_WORK.WPREM_SQG_P + AREA_DE_WORK.WPREM_PRT_P + AREA_DE_WORK.WPREM_DIT_P;

            /*" -1800- MOVE WS-TOT-TITL TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_TITL, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1802- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

            /*" -1804- ADD WS-TOT-TITL TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + AREA_DE_WORK.WS_TOT_TITL;

            /*" -1806- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1807- MOVE 'COMISSOES   ' TO LD01-DESCR-VLR. */
            _.Move("COMISSOES   ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1808- MOVE WCOMS-SQG-T TO LD01-VALOR-01. */
            _.Move(AREA_DE_WORK.WCOMS_SQG_T, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1809- MOVE WCOMS-PRT-T TO LD01-VALOR-02. */
            _.Move(AREA_DE_WORK.WCOMS_PRT_T, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1811- MOVE WCOMS-DIT-T TO LD01-VALOR-03. */
            _.Move(AREA_DE_WORK.WCOMS_DIT_T, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1813- MOVE ZEROS TO WS-TOT-TITL. */
            _.Move(0, AREA_DE_WORK.WS_TOT_TITL);

            /*" -1816- COMPUTE WS-TOT-TITL = WCOMS-SQG-T + WCOMS-PRT-T + WCOMS-DIT-T. */
            AREA_DE_WORK.WS_TOT_TITL.Value = AREA_DE_WORK.WCOMS_SQG_T + AREA_DE_WORK.WCOMS_PRT_T + AREA_DE_WORK.WCOMS_DIT_T;

            /*" -1818- MOVE WS-TOT-TITL TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_TITL, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1820- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

            /*" -1822- ADD WS-TOT-TITL TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + AREA_DE_WORK.WS_TOT_TITL;

            /*" -1824- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1825- MOVE 'RESTITUICOES' TO LD01-DESCR-VLR. */
            _.Move("RESTITUICOES", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1826- MOVE WPREM-SQG-R TO LD01-VALOR-01. */
            _.Move(AREA_DE_WORK.WPREM_SQG_R, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1827- MOVE WPREM-PRT-R TO LD01-VALOR-02. */
            _.Move(AREA_DE_WORK.WPREM_PRT_R, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1829- MOVE WPREM-DIT-R TO LD01-VALOR-03. */
            _.Move(AREA_DE_WORK.WPREM_DIT_R, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1831- MOVE ZEROS TO WS-TOT-TITL. */
            _.Move(0, AREA_DE_WORK.WS_TOT_TITL);

            /*" -1834- COMPUTE WS-TOT-TITL = WPREM-SQG-R + WPREM-PRT-R + WPREM-DIT-R. */
            AREA_DE_WORK.WS_TOT_TITL.Value = AREA_DE_WORK.WPREM_SQG_R + AREA_DE_WORK.WPREM_PRT_R + AREA_DE_WORK.WPREM_DIT_R;

            /*" -1836- MOVE WS-TOT-TITL TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_TITL, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1838- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

            /*" -1840- ADD WS-TOT-TITL TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + AREA_DE_WORK.WS_TOT_TITL;

            /*" -1842- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1843- MOVE 'SINISTROS (VALOR A RECUPERAR) ' TO LD01-DESCR-VLR. */
            _.Move("SINISTROS (VALOR A RECUPERAR) ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1844- MOVE WVLR-SIN-SQG TO LD01-VALOR-01. */
            _.Move(AREA_DE_WORK.WVLR_SIN_SQG, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1845- MOVE WVLR-SIN-PRT TO LD01-VALOR-02. */
            _.Move(AREA_DE_WORK.WVLR_SIN_PRT, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1847- MOVE WVLR-SIN-DIT TO LD01-VALOR-03. */
            _.Move(AREA_DE_WORK.WVLR_SIN_DIT, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1849- MOVE ZEROS TO WS-TOT-TITL. */
            _.Move(0, AREA_DE_WORK.WS_TOT_TITL);

            /*" -1852- COMPUTE WS-TOT-TITL = WVLR-SIN-SQG + WVLR-SIN-PRT + WVLR-SIN-DIT. */
            AREA_DE_WORK.WS_TOT_TITL.Value = AREA_DE_WORK.WVLR_SIN_SQG + AREA_DE_WORK.WVLR_SIN_PRT + AREA_DE_WORK.WVLR_SIN_DIT;

            /*" -1854- MOVE WS-TOT-TITL TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_TITL, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1856- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

            /*" -1858- ADD WS-TOT-TITL TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + AREA_DE_WORK.WS_TOT_TITL;

            /*" -1860- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1862- MOVE 'CUSTO DE EMISSAO ' TO LD01-DESCR-VLR. */
            _.Move("CUSTO DE EMISSAO ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1867- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1869- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

            /*" -1871- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1873- MOVE 'PRO-LABORE ' TO LD01-DESCR-VLR. */
            _.Move("PRO-LABORE ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1878- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1880- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

            /*" -1882- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1884- MOVE 'RESTUICOES S/ CE E PRO-LABORE ' TO LD01-DESCR-VLR. */
            _.Move("RESTUICOES S/ CE E PRO-LABORE ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1889- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1891- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

            /*" -1893- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1895- MOVE 'DESPESAS BANCARIAS (TARIFAS)  ' TO LD01-DESCR-VLR. */
            _.Move("DESPESAS BANCARIAS (TARIFAS)  ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1900- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1902- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

            /*" -1904- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1906- MOVE 'OUTROS DEBITOS ' TO LD01-DESCR-VLR. */
            _.Move("OUTROS DEBITOS ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1908- COMPUTE V0CCCH-OUTRDEBIT = V0CCCH-OUTRDEBIT * -1. */
            V0CCCH_OUTRDEBIT.Value = V0CCCH_OUTRDEBIT * -1;

            /*" -1909- MOVE ZEROS TO LD01-VALOR-01 */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1910- MOVE V0CCCH-OUTRDEBIT TO LD01-VALOR-02 */
            _.Move(V0CCCH_OUTRDEBIT, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1912- MOVE ZEROS TO LD01-VALOR-03. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1914- MOVE V0CCCH-OUTRDEBIT TO LD01-VALOR-04. */
            _.Move(V0CCCH_OUTRDEBIT, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1916- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

            /*" -1918- ADD V0CCCH-OUTRDEBIT TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + V0CCCH_OUTRDEBIT;

            /*" -1920- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1922- MOVE 'OUTROS CREDITOS ' TO LD01-DESCR-VLR. */
            _.Move("OUTROS CREDITOS ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1923- MOVE ZEROS TO LD01-VALOR-01 */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01);

            /*" -1924- MOVE V0CCCH-OUTRCREDT TO LD01-VALOR-02 */
            _.Move(V0CCCH_OUTRCREDT, RELATORIO.LD01.LD01_VALOR_02);

            /*" -1926- MOVE ZEROS TO LD01-VALOR-03. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1928- MOVE V0CCCH-OUTRCREDT TO LD01-VALOR-04. */
            _.Move(V0CCCH_OUTRCREDT, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1930- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

            /*" -1932- ADD V0CCCH-OUTRCREDT TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + V0CCCH_OUTRCREDT;

            /*" -1934- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1936- MOVE 'TOTAL LIQ. POR PRODUTO ' TO LD01-DESCR-VLR. */
            _.Move("TOTAL LIQ. POR PRODUTO ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1941- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1943- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

            /*" -1945- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1947- MOVE 'ACERTO DE SALDO ANTERIOR      ' TO LD01-DESCR-VLR. */
            _.Move("ACERTO DE SALDO ANTERIOR      ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1952- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1954- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

            /*" -1956- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1958- MOVE 'SALDO ANTERIOR A RECUPERAR    ' TO LD01-DESCR-VLR. */
            _.Move("SALDO ANTERIOR A RECUPERAR    ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1963- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03 LD01-VALOR-04. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1965- COMPUTE V0CCCH-VLRSLDANT = V0CCCH-VLRSLDANT * -1. */
            V0CCCH_VLRSLDANT.Value = V0CCCH_VLRSLDANT * -1;

            /*" -1967- MOVE V0CCCH-VLRSLDANT TO LD01-VALOR-04. */
            _.Move(V0CCCH_VLRSLDANT, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1969- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

            /*" -1971- ADD V0CCCH-VLRSLDANT TO WS-TOT-CONG. */
            AREA_DE_WORK.WS_TOT_CONG.Value = AREA_DE_WORK.WS_TOT_CONG + V0CCCH_VLRSLDANT;

            /*" -1973- MOVE SPACES TO LD01-DESCR-VLR. */
            _.Move("", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1975- MOVE 'TOTAL CONGENERE ' TO LD01-DESCR-VLR. */
            _.Move("TOTAL CONGENERE ", RELATORIO.LD01.LD01_DESCR_VLR);

            /*" -1979- MOVE ZEROS TO LD01-VALOR-01 LD01-VALOR-02 LD01-VALOR-03. */
            _.Move(0, RELATORIO.LD01.LD01_VALOR_01, RELATORIO.LD01.LD01_VALOR_02, RELATORIO.LD01.LD01_VALOR_03);

            /*" -1981- MOVE WS-TOT-CONG TO LD01-VALOR-04. */
            _.Move(AREA_DE_WORK.WS_TOT_CONG, RELATORIO.LD01.LD01_VALOR_04);

            /*" -1981- WRITE REG-AC0820B3 FROM LD01. */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_AC0820B3);

            AC0820B3.Write(REG_AC0820B3.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1994- CLOSE AC0820B1. */
            AC0820B1.Close();

            /*" -1996- CLOSE AC0820B2. */
            AC0820B2.Close();

            /*" -1998- CLOSE AC0820B3. */
            AC0820B3.Close();

            /*" -2000- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2002- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -2002- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2006- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2006- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}