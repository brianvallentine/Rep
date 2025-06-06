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
using Sias.Cosseguro.DB2.AC0041B;

namespace Code
{
    public class AC0041B
    {
        public bool IsCall { get; set; }

        public AC0041B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0041B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA/PROGRAMADOR....  GILSON                             *      */
        /*"      *   DATA CODIFICACAO .......  JULHO/1998                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  RECIBO DE PAGAMENTO DO SALDO DE    *      */
        /*"      *                             COSSEGURO CEDIDO E SINISTRO RECU-  *      */
        /*"      *                             PERADO.                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * EMPRESAS                            V1EMPRESA         INPUT    *      */
        /*"      * COSSEGCED_CHEQUE                    V0COSCED-CHEQUE   INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           08/09/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * IMPRESSAO VIA SAM               VANDO(PRODEXTER)   20/05/2002  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - 11/08/2008 - GILSON PINTO DA SILVA                 *      */
        /*"      *                          INIBIR AS LINHAS DE CONTROLE DE CANAL *      */
        /*"      *                          DE IMPRESSAO - PROCURAR GP0808        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CADMUS 53247 - 10/02/2011                                    *      */
        /*"      *   (M. LIGIA)     INIBIR ACESSO A TABELA LOTE-CHEQUE            *      */
        /*"      *                  WELLINGTON VERAS (TE39902)  PROCUR POR C53247 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   PROJSAP      - 17/02/2011                                    *      */
        /*"      *   (GILSON)     - CRIAR A ROTINA R0150-00-SELECT-V1SISTEMA-FI   *      */
        /*"      *                - COMPARAR A DATAS FI E AC                      *      */
        /*"      *                  WELLINGTON VERAS (TE39902)  PROCUR POR WV1102 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - ALTERAR O PROGRAMA PARA TRATAR/GERAR O RECIBO DE  *      */
        /*"      *              PAGAMENTO SOMENTE DA EMPRESA 00 (CAIXA SEGUROS)   *      */
        /*"      * 17/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RAC0041B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RAC0041B
        {
            get
            {
                _.Move(REG_AC0041B, _RAC0041B); VarBasis.RedefinePassValue(REG_AC0041B, _RAC0041B, REG_AC0041B); return _RAC0041B;
            }
        }
        /*"01              REG-AC0041B.*/
        public AC0041B_REG_AC0041B REG_AC0041B { get; set; } = new AC0041B_REG_AC0041B();
        public class AC0041B_REG_AC0041B : VarBasis
        {
            /*"  05            REG-AC0041BC       PIC  X(001).*/
            public StringBasis REG_AC0041BC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05            REG-AC0041BL       PIC  X(132).*/
            public StringBasis REG_AC0041BL { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         V1SIST-DTMOVABE-AC  PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE_AC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMOVABE-FI  PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE_FI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1EMPR-COD-EMP      PIC S9(009)               COMP.*/
        public IntBasis V1EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1EMPR-NOM-EMP      PIC  X(040).*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1EMPR-CGCCPF       PIC S9(015)               COMP-3.*/
        public IntBasis V1EMPR_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0CCCH-COD-EMPR     PIC S9(009)     VALUE +0  COMP.*/
        public IntBasis V0CCCH_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CCCH-CONGENER     PIC S9(004)     VALUE +0  COMP.*/
        public IntBasis V0CCCH_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CCCH-DTMOVTAC     PIC  X(010).*/
        public StringBasis V0CCCH_DTMOVTAC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CCCH-CODUSUAC     PIC  X(008).*/
        public StringBasis V0CCCH_CODUSUAC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0CCCH-DTLIBERA     PIC  X(010).*/
        public StringBasis V0CCCH_DTLIBERA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CCCH-NRCHQINT     PIC S9(009)     VALUE +0  COMP.*/
        public IntBasis V0CCCH_NRCHQINT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CCCH-DVCHQINT     PIC S9(004)     VALUE +0  COMP.*/
        public IntBasis V0CCCH_DVCHQINT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CCCH-VLPREMIO     PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-VLDESCON     PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-VLADIFRA     PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-VLRCOMIS     PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VLRCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-VLRSINI      PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VLRSINI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-VLDESPESA    PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VLDESPESA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-VLRHONOR     PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VLRHONOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-VLRSALVD     PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VLRSALVD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-VLRESSARC    PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VLRESSARC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-VALOR-EDI    PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VALOR_EDI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-VALOR-USS    PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VALOR_USS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-VLEQPVNDA    PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VLEQPVNDA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-VLDESPADM    PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VLDESPADM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-OUTRDEBIT    PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_OUTRDEBIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-OUTRCREDT    PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_OUTRCREDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-VLRSLDANT    PIC S9(013)V99  VALUE +0  COMP-3.*/
        public DoubleBasis V0CCCH_VLRSLDANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCCH-SITUACAO     PIC  X(001).*/
        public StringBasis V0CCCH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CCCH-COD-MOEDA    PIC S9(004)     VALUE +0  COMP.*/
        public IntBasis V0CCCH_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CCCH-DTMOVTFI     PIC  X(010).*/
        public StringBasis V0CCCH_DTMOVTFI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CCCH-CODUSUFI     PIC  X(008).*/
        public StringBasis V0CCCH_CODUSUFI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0CCCH-DTCORREC     PIC  X(010).*/
        public StringBasis V0CCCH_DTCORREC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1CONG-CONGENER     PIC S9(004)     VALUE +0  COMP.*/
        public IntBasis V1CONG_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CONG-NOMECONG     PIC  X(040).*/
        public StringBasis V1CONG_NOMECONG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0LTCH-BANCO        PIC S9(004)               COMP.*/
        public IntBasis V0LTCH_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0LTCH-AGENCIA      PIC S9(004)               COMP.*/
        public IntBasis V0LTCH_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0LTCH-NRCHQEXT     PIC S9(009)               COMP.*/
        public IntBasis V0LTCH_NRCHQEXT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0LTCH-DVCHQEXT     PIC S9(004)               COMP.*/
        public IntBasis V0LTCH_DVCHQEXT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0LTCH-NRCHQINT     PIC S9(009)               COMP.*/
        public IntBasis V0LTCH_NRCHQINT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0LTCH-DVCHQINT     PIC S9(004)               COMP.*/
        public IntBasis V0LTCH_DVCHQINT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0LTCH-SERCHQ       PIC  X(003).*/
        public StringBasis V0LTCH_SERCHQ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01           AREA-DE-WORK.*/
        public AC0041B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0041B_AREA_DE_WORK();
        public class AC0041B_AREA_DE_WORK : VarBasis
        {
            /*"  05         AC-LINHAS         PIC  9(003)    VALUE ZEROS.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05         AC-PAGINA         PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         AC-L-V0COSCEDCHQ  PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_L_V0COSCEDCHQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFIM-V0COSCEDCHQ  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0COSCEDCHQ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WCONG-ANT         PIC S9(004)    VALUE +0  COMP.*/
            public IntBasis WCONG_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WPRM-TOTAL        PIC S9(015)V99 VALUE +0  COMP-3.*/
            public DoubleBasis WPRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05         WTOT-PAGAR        PIC S9(015)V99 VALUE +0  COMP-3.*/
            public DoubleBasis WTOT_PAGAR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05         WTOT-RECUP        PIC S9(015)V99 VALUE +0  COMP-3.*/
            public DoubleBasis WTOT_RECUP { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05         WTOT-DBECR        PIC S9(015)V99 VALUE +0  COMP-3.*/
            public DoubleBasis WTOT_DBECR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05         WTOT-CONG         PIC S9(015)V99 VALUE +0  COMP-3.*/
            public DoubleBasis WTOT_CONG { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05         WTOT-GER-SD       PIC S9(015)V99 VALUE +0  COMP-3.*/
            public DoubleBasis WTOT_GER_SD { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05         WTOT-GER-PG       PIC S9(015)V99 VALUE +0  COMP-3.*/
            public DoubleBasis WTOT_GER_PG { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05         WTOT-GER-RC       PIC S9(015)V99 VALUE +0  COMP-3.*/
            public DoubleBasis WTOT_GER_RC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05         WTOT-GER-DC       PIC S9(015)V99 VALUE +0  COMP-3.*/
            public DoubleBasis WTOT_GER_DC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05         WTOT-GERAL        PIC S9(015)V99 VALUE +0  COMP-3.*/
            public DoubleBasis WTOT_GERAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05         WVLR-EXTENSO      PIC S9(015)V99 VALUE +0  COMP-3.*/
            public DoubleBasis WVLR_EXTENSO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05         WDATA-AUX.*/
            public AC0041B_WDATA_AUX WDATA_AUX { get; set; } = new AC0041B_WDATA_AUX();
            public class AC0041B_WDATA_AUX : VarBasis
            {
                /*"    10       WDATA-AA-AUX      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-AUX      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-AUX      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-EDIT.*/
            }
            public AC0041B_WDATA_EDIT WDATA_EDIT { get; set; } = new AC0041B_WDATA_EDIT();
            public class AC0041B_WDATA_EDIT : VarBasis
            {
                /*"    10       WDATA-DD-EDT      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-EDT      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-EDT      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_EDT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CURR.*/
            }
            public AC0041B_WHORA_CURR WHORA_CURR { get; set; } = new AC0041B_WHORA_CURR();
            public class AC0041B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CUR      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CUR      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CUR      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WHORA-EDIT.*/
            }
            public AC0041B_WHORA_EDIT WHORA_EDIT { get; set; } = new AC0041B_WHORA_EDIT();
            public class AC0041B_WHORA_EDIT : VarBasis
            {
                /*"    10       WHORA-HH-EDT      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-EDT      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-EDT      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01           RELATORIO.*/
            }
        }
        public AC0041B_RELATORIO RELATORIO { get; set; } = new AC0041B_RELATORIO();
        public class AC0041B_RELATORIO : VarBasis
        {
            /*"  05         LC01.*/
            public AC0041B_LC01 LC01 { get; set; } = new AC0041B_LC01();
            public class AC0041B_LC01 : VarBasis
            {
                /*"    10       FILLER            PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    10       FILLER            PIC  X(130)    VALUE  ALL '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"ALL");
                /*"    10       FILLER            PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  05         LC02.*/
            }
            public AC0041B_LC02 LC02 { get; set; } = new AC0041B_LC02();
            public class AC0041B_LC02 : VarBasis
            {
                /*"    10       FILLER            PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    10       FILLER            PIC  X(130)    VALUE  SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"");
                /*"    10       FILLER            PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  05         LC03.*/
            }
            public AC0041B_LC03 LC03 { get; set; } = new AC0041B_LC03();
            public class AC0041B_LC03 : VarBasis
            {
                /*"    10       FILLER            PIC  X(002)    VALUE '* '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"* ");
                /*"    10       FILLER            PIC  X(007)    VALUE 'AC0041B'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"AC0041B");
                /*"    10       FILLER            PIC  X(037)    VALUE  SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"");
                /*"    10       LC03-EMPRESA      PIC  X(040)    VALUE  SPACES.*/
                public StringBasis LC03_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10       FILLER            PIC  X(025)    VALUE  SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    10       FILLER            PIC  X(006)    VALUE 'PAGINA'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"PAGINA");
                /*"    10       FILLER            PIC  X(003)    VALUE ' : '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" : ");
                /*"    10       LC03-PAGINA       PIC  9(003).*/
                public IntBasis LC03_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       FILLER            PIC  X(008)    VALUE  SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10       FILLER            PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  05         LC04.*/
            }
            public AC0041B_LC04 LC04 { get; set; } = new AC0041B_LC04();
            public class AC0041B_LC04 : VarBasis
            {
                /*"    10       FILLER            PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    10       FILLER            PIC  X(010)    VALUE 'COD EMPR -'*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"COD EMPR -");
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       LC04-COD-EMPR     PIC  9(003)    VALUE  ZEROS.*/
                public IntBasis LC04_COD_EMPR { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LC04-NOM-EMPR     PIC  X(040)    VALUE  SPACES.*/
                public StringBasis LC04_NOM_EMPR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10       FILLER            PIC  X(055)    VALUE  SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"");
                /*"    10       FILLER            PIC  X(004)    VALUE 'DATA'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"DATA");
                /*"    10       FILLER            PIC  X(003)    VALUE ' : '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" : ");
                /*"    10       LC04-DATA         PIC  X(010)    VALUE  SPACES.*/
                public StringBasis LC04_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10       FILLER            PIC  X(002)    VALUE ' *'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"  05         LC05.*/
            }
            public AC0041B_LC05 LC05 { get; set; } = new AC0041B_LC05();
            public class AC0041B_LC05 : VarBasis
            {
                /*"    10       FILLER            PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    10       FILLER            PIC  X(030)    VALUE  SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    10       FILLER            PIC  X(059)    VALUE            'DEMONSTRATIVO DO ACERTO OPERACIONAL DE COSSEGURO CED            'IDO EM '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "59", "X(059)"), @"DEMONSTRATIVO DO ACERTO OPERACIONAL DE COSSEGURO CED            ");
                /*"    10       LC05-DTMOVTO      PIC  X(010)    VALUE  SPACES.*/
                public StringBasis LC05_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10       FILLER            PIC  X(013)    VALUE  SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    10       FILLER            PIC  X(004)    VALUE 'HORA'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"HORA");
                /*"    10       FILLER            PIC  X(003)    VALUE ' : '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" : ");
                /*"    10       LC05-HORA         PIC  X(008)    VALUE  SPACES.*/
                public StringBasis LC05_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       FILLER            PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  05         LC06.*/
            }
            public AC0041B_LC06 LC06 { get; set; } = new AC0041B_LC06();
            public class AC0041B_LC06 : VarBasis
            {
                /*"    10       FILLER            PIC  X(002)    VALUE '* '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"* ");
                /*"    10       FILLER            PIC  X(011)    VALUE            'CONGENERE -'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"CONGENERE -");
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       LC06-CONGENER     PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis LC06_CONGENER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(002)    VALUE  SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10       LC06-NOME-CONG    PIC  X(040)    VALUE  SPACES.*/
                public StringBasis LC06_NOME_CONG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10       FILLER            PIC  X(071)    VALUE  SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "71", "X(071)"), @"");
                /*"    10       FILLER            PIC  X(001)    VALUE '*'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  05         LC07.*/
            }
            public AC0041B_LC07 LC07 { get; set; } = new AC0041B_LC07();
            public class AC0041B_LC07 : VarBasis
            {
                /*"    10       FILLER            PIC  X(036)    VALUE            '*** S A L D O   D E V E D O R  -  R$'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"*** S A L D O   D E V E D O R  -  R$");
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       LC07-VLRSLDANT    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LC07_VLRSLDANT { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(077)    VALUE  SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "77", "X(077)"), @"");
                /*"  05         LC08.*/
            }
            public AC0041B_LC08 LC08 { get; set; } = new AC0041B_LC08();
            public class AC0041B_LC08 : VarBasis
            {
                /*"    10       FILLER            PIC  X(033)    VALUE            '*** MOVIMENTO LIBERADO ATE O DIA '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"*** MOVIMENTO LIBERADO ATE O DIA ");
                /*"    10       LC08-DTLIBERA     PIC  X(010)    VALUE  SPACES.*/
                public StringBasis LC08_DTLIBERA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10       FILLER            PIC  X(006)    VALUE '  EM  '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"  EM  ");
                /*"    10       LC08-DTMOVTAC     PIC  X(010)    VALUE  SPACES.*/
                public StringBasis LC08_DTMOVTAC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10       FILLER            PIC  X(073)    VALUE  SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "73", "X(073)"), @"");
                /*"  05         LC09.*/
            }
            public AC0041B_LC09 LC09 { get; set; } = new AC0041B_LC09();
            public class AC0041B_LC09 : VarBasis
            {
                /*"    10       FILLER            PIC  X(021)    VALUE            '*** P R E M I O S ***'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"*** P R E M I O S ***");
                /*"    10       FILLER            PIC  X(111)    VALUE  SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "111", "X(111)"), @"");
                /*"  05         LC10.*/
            }
            public AC0041B_LC10 LC10 { get; set; } = new AC0041B_LC10();
            public class AC0041B_LC10 : VarBasis
            {
                /*"    10       FILLER            PIC  X(007)    VALUE  SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10       FILLER            PIC  X(016)    VALUE            'PREMIO TARIFARIO'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"PREMIO TARIFARIO");
                /*"    10       FILLER            PIC  X(007)    VALUE  SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10       FILLER            PIC  X(014)    VALUE            'TOTAL DESCONTO'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"TOTAL DESCONTO");
                /*"    10       FILLER            PIC  X(006)    VALUE  SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10       FILLER            PIC  X(015)    VALUE            'TOTAL ADICIONAL'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"TOTAL ADICIONAL");
                /*"    10       FILLER            PIC  X(009)    VALUE  SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10       FILLER            PIC  X(012)    VALUE            'PREMIO TOTAL'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PREMIO TOTAL");
                /*"    10       FILLER            PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10       FILLER            PIC  X(017)    VALUE            'TOTAL DE COMISSAO'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"TOTAL DE COMISSAO");
                /*"    10       FILLER            PIC  X(008)    VALUE  SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10       FILLER            PIC  X(013)    VALUE            'TOTAL A PAGAR'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"TOTAL A PAGAR");
                /*"    10       FILLER            PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"  05         LC11.*/
            }
            public AC0041B_LC11 LC11 { get; set; } = new AC0041B_LC11();
            public class AC0041B_LC11 : VarBasis
            {
                /*"    10       FILLER            PIC  X(025)    VALUE            '*** S I N I S T R O S ***'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** S I N I S T R O S ***");
                /*"    10       FILLER            PIC  X(107)    VALUE  SPACES.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "107", "X(107)"), @"");
                /*"  05         LC12.*/
            }
            public AC0041B_LC12 LC12 { get; set; } = new AC0041B_LC12();
            public class AC0041B_LC12 : VarBasis
            {
                /*"    10       FILLER            PIC  X(006)    VALUE  SPACES.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10       FILLER            PIC  X(017)    VALUE            'TOTAL INDENIZACAO'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"TOTAL INDENIZACAO");
                /*"    10       FILLER            PIC  X(007)    VALUE  SPACES.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10       FILLER            PIC  X(014)    VALUE            'TOTAL DESPESAS'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"TOTAL DESPESAS");
                /*"    10       FILLER            PIC  X(005)    VALUE  SPACES.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10       FILLER            PIC  X(016)    VALUE            'TOTAL HONORARIOS'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"TOTAL HONORARIOS");
                /*"    10       FILLER            PIC  X(007)    VALUE  SPACES.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10       FILLER            PIC  X(014)    VALUE            'TOTAL SALVADOS'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"TOTAL SALVADOS");
                /*"    10       FILLER            PIC  X(002)    VALUE  SPACES.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10       FILLER            PIC  X(019)    VALUE            'TOTAL RESSARCIMENTO'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"TOTAL RESSARCIMENTO");
                /*"    10       FILLER            PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10       FILLER            PIC  X(017)    VALUE            'TOTAL A RECUPERAR'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"TOTAL A RECUPERAR");
                /*"    10       FILLER            PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"  05         LC13.*/
            }
            public AC0041B_LC13 LC13 { get; set; } = new AC0041B_LC13();
            public class AC0041B_LC13 : VarBasis
            {
                /*"    10       FILLER            PIC  X(025)    VALUE            '*** ACERTOS REALIZADO EM '.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ACERTOS REALIZADO EM ");
                /*"    10       LC13-DTMOVTFI     PIC  X(010)    VALUE  SPACES.*/
                public StringBasis LC13_DTMOVTFI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10       FILLER            PIC  X(097)    VALUE  SPACES.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "97", "X(097)"), @"");
                /*"  05         LC14.*/
            }
            public AC0041B_LC14 LC14 { get; set; } = new AC0041B_LC14();
            public class AC0041B_LC14 : VarBasis
            {
                /*"    10       FILLER            PIC  X(056)    VALUE            '*** O U T R O S    D E B I T O S  /  C R E D I T O S            ' ***'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"*** O U T R O S    D E B I T O S  /  C R E D I T O S            ");
                /*"    10       FILLER            PIC  X(076)    VALUE  SPACES.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "76", "X(076)"), @"");
                /*"  05         LC15.*/
            }
            public AC0041B_LC15 LC15 { get; set; } = new AC0041B_LC15();
            public class AC0041B_LC15 : VarBasis
            {
                /*"    10       FILLER            PIC  X(006)    VALUE  SPACES.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10       FILLER            PIC  X(017)    VALUE            'VALOR  DE  E.D.I.'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"VALOR  DE  E.D.I.");
                /*"    10       FILLER            PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10       FILLER            PIC  X(017)    VALUE            'VALOR  DA  U.S.S.'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"VALOR  DA  U.S.S.");
                /*"    10       FILLER            PIC  X(005)    VALUE  SPACES.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10       FILLER            PIC  X(016)    VALUE            'EQUIPE DE VENDAS'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"EQUIPE DE VENDAS");
                /*"    10       FILLER            PIC  X(007)    VALUE  SPACES.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10       FILLER            PIC  X(014)    VALUE            'DESPESAS  ADM.'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"DESPESAS  ADM.");
                /*"    10       FILLER            PIC  X(007)    VALUE  SPACES.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10       FILLER            PIC  X(014)    VALUE            'OUTROS DEBITOS'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"OUTROS DEBITOS");
                /*"    10       FILLER            PIC  X(006)    VALUE  SPACES.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10       FILLER            PIC  X(015)    VALUE            'OUTROS CREDITOS'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"OUTROS CREDITOS");
                /*"    10       FILLER            PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"  05         LD01.*/
            }
            public AC0041B_LD01 LD01 { get; set; } = new AC0041B_LD01();
            public class AC0041B_LD01 : VarBasis
            {
                /*"    10       FILLER            PIC  X(005)    VALUE  SPACES.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10       LD01-VLPREMIO     PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD01_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD01-VLDESCON     PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD01_VLDESCON { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD01-VLADIFRA     PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD01_VLADIFRA { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD01-PRM-TOTAL    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD01_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD01-VLRCOMIS     PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD01_VLRCOMIS { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD01-TOT-PAGAR    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD01_TOT_PAGAR { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"  05         LD02.*/
            }
            public AC0041B_LD02 LD02 { get; set; } = new AC0041B_LD02();
            public class AC0041B_LD02 : VarBasis
            {
                /*"    10       FILLER            PIC  X(005)    VALUE  SPACES.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10       LD02-VLRSINI      PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD02_VLRSINI { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD02-VLDESPESA    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD02_VLDESPESA { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD02-VLRHONOR     PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD02_VLRHONOR { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD02-VLRSALVD     PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD02_VLRSALVD { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD02-VLRESSARC    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD02_VLRESSARC { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD02-TOT-RECUP    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD02_TOT_RECUP { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"  05         LD03.*/
            }
            public AC0041B_LD03 LD03 { get; set; } = new AC0041B_LD03();
            public class AC0041B_LD03 : VarBasis
            {
                /*"    10       FILLER            PIC  X(005)    VALUE  SPACES.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10       LD03-VALOR-EDI    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD03_VALOR_EDI { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD03-VALOR-USS    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD03_VALOR_USS { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD03-VLEQPVNDA    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD03_VLEQPVNDA { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD03-VLDESPADM    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD03_VLDESPADM { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD03-OUTRDEBIT    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD03_OUTRDEBIT { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       LD03-OUTRCREDT    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD03_OUTRCREDT { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"  05         LD04.*/
            }
            public AC0041B_LD04 LD04 { get; set; } = new AC0041B_LD04();
            public class AC0041B_LD04 : VarBasis
            {
                /*"    10       FILLER            PIC  X(005)    VALUE '*****'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"*****");
                /*"    10       FILLER            PIC  X(003)    VALUE  SPACES.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       FILLER            PIC  X(032)    VALUE            'RESUMO  GERAL  DO  DEMONSTRATIVO'.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"RESUMO  GERAL  DO  DEMONSTRATIVO");
                /*"    10       FILLER            PIC  X(092)    VALUE  SPACES.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "92", "X(092)"), @"");
                /*"  05         LD05.*/
            }
            public AC0041B_LD05 LD05 { get; set; } = new AC0041B_LD05();
            public class AC0041B_LD05 : VarBasis
            {
                /*"    10       FILLER            PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10       FILLER            PIC  X(040)    VALUE  ALL '-'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"ALL");
                /*"    10       FILLER            PIC  X(088)    VALUE  SPACES.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "88", "X(088)"), @"");
                /*"  05         LD06.*/
            }
            public AC0041B_LD06 LD06 { get; set; } = new AC0041B_LD06();
            public class AC0041B_LD06 : VarBasis
            {
                /*"    10       FILLER            PIC  X(003)    VALUE '***'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"***");
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       FILLER            PIC  X(040)    VALUE            'TOTAL DO SALDO DEVEDOR        (-)    R$ '.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"TOTAL DO SALDO DEVEDOR        (-)    R$ ");
                /*"    10       LD06-TOT-SDANT    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD06_TOT_SDANT { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(070)    VALUE  SPACES.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"  05         LD07.*/
            }
            public AC0041B_LD07 LD07 { get; set; } = new AC0041B_LD07();
            public class AC0041B_LD07 : VarBasis
            {
                /*"    10       FILLER            PIC  X(003)    VALUE '***'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"***");
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       FILLER            PIC  X(040)    VALUE            'TOTAL DO PREMIO A PAGAR       (+)    R$ '.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"TOTAL DO PREMIO A PAGAR       (+)    R$ ");
                /*"    10       LD07-TOT-PAGAR    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD07_TOT_PAGAR { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(070)    VALUE  SPACES.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"  05         LD08.*/
            }
            public AC0041B_LD08 LD08 { get; set; } = new AC0041B_LD08();
            public class AC0041B_LD08 : VarBasis
            {
                /*"    10       FILLER            PIC  X(003)    VALUE '***'.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"***");
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       FILLER            PIC  X(040)    VALUE            'TOTAL DO SINISTRO A RECUPERAR (-)    R$ '.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"TOTAL DO SINISTRO A RECUPERAR (-)    R$ ");
                /*"    10       LD08-TOT-RECUP    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD08_TOT_RECUP { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(070)    VALUE  SPACES.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"  05         LD09.*/
            }
            public AC0041B_LD09 LD09 { get; set; } = new AC0041B_LD09();
            public class AC0041B_LD09 : VarBasis
            {
                /*"    10       FILLER            PIC  X(003)    VALUE '***'.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"***");
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       FILLER            PIC  X(040)    VALUE            'TOTAL DO DEBITO / CREDITO     (-)    R$ '.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"TOTAL DO DEBITO / CREDITO     (-)    R$ ");
                /*"    10       LD09-TOT-DBECR    PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD09_TOT_DBECR { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(070)    VALUE  SPACES.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"  05         LD10.*/
            }
            public AC0041B_LD10 LD10 { get; set; } = new AC0041B_LD10();
            public class AC0041B_LD10 : VarBasis
            {
                /*"    10       FILLER            PIC  X(004)    VALUE  SPACES.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10       FILLER            PIC  X(058)    VALUE  ALL  '-'.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "58", "X(058)"), @"ALL");
                /*"    10       FILLER            PIC  X(005)    VALUE  SPACES.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10       LD10-NRCHEQUE.*/
                public AC0041B_LD10_NRCHEQUE LD10_NRCHEQUE { get; set; } = new AC0041B_LD10_NRCHEQUE();
                public class AC0041B_LD10_NRCHEQUE : VarBasis
                {
                    /*"      15     LD10-TITL-CHQ     PIC  X(024)    VALUE  SPACES.*/
                    public StringBasis LD10_TITL_CHQ { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                    /*"      15     LD10-NRCHQINT     PIC  ---.---.---.-99.*/
                    public IntBasis LD10_NRCHQINT { get; set; } = new IntBasis(new PIC("9", "12", "---.---.---.-99."));
                    /*"      15     LD10-TRACO-01     PIC  X(003)    VALUE  SPACES.*/
                    public StringBasis LD10_TRACO_01 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                    /*"      15     LD10-DVCHQINT     PIC  9(001)    VALUE  ZEROS.*/
                    public IntBasis LD10_DVCHQINT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                    /*"    10       FILLER            PIC  X(022)    VALUE  SPACES.*/
                }
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"  05         LD11.*/
            }
            public AC0041B_LD11 LD11 { get; set; } = new AC0041B_LD11();
            public class AC0041B_LD11 : VarBasis
            {
                /*"    10       FILLER            PIC  X(008)    VALUE '********'.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"********");
                /*"    10       FILLER            PIC  X(005)    VALUE  SPACES.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10       FILLER            PIC  X(031)    VALUE            'RESULTADO FINAL             R$ '.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"RESULTADO FINAL             R$ ");
                /*"    10       LD11-TOT-CONG     PIC  ---.---.---.--9,99.*/
                public DoubleBasis LD11_TOT_CONG { get; set; } = new DoubleBasis(new PIC("9", "12", "---.---.---.--9V99."), 2);
                /*"    10       FILLER            PIC  X(005)    VALUE  SPACES.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10       LD11-NRCHEQUE.*/
                public AC0041B_LD11_NRCHEQUE LD11_NRCHEQUE { get; set; } = new AC0041B_LD11_NRCHEQUE();
                public class AC0041B_LD11_NRCHEQUE : VarBasis
                {
                    /*"      15     LD11-TITL-CHQ     PIC  X(024)    VALUE  SPACES.*/
                    public StringBasis LD11_TITL_CHQ { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                    /*"      15     LD11-BANCO        PIC  ZZ99.*/
                    public IntBasis LD11_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "ZZ99."));
                    /*"      15     LD11-BARRA-01     PIC  X(003)    VALUE  SPACES.*/
                    public StringBasis LD11_BARRA_01 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                    /*"      15     LD11-AGENCIA      PIC  ZZ99.*/
                    public IntBasis LD11_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "ZZ99."));
                    /*"      15     LD11-BARRA-02     PIC  X(003)    VALUE  SPACES.*/
                    public StringBasis LD11_BARRA_02 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                    /*"      15     LD11-SERCHQ       PIC  X(003)    VALUE  SPACES.*/
                    public StringBasis LD11_SERCHQ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                    /*"      15     FILLER            PIC  X(001)    VALUE  SPACES.*/
                    public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      15     LD11-NRCHQEXT     PIC  ---.---.---.-99.*/
                    public IntBasis LD11_NRCHQEXT { get; set; } = new IntBasis(new PIC("9", "12", "---.---.---.-99."));
                    /*"      15     LD11-TRACO-01     PIC  X(003)    VALUE  SPACES.*/
                    public StringBasis LD11_TRACO_01 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                    /*"      15     LD11-DVCHQEXT     PIC  9(001)    VALUE  ZEROS.*/
                    public IntBasis LD11_DVCHQEXT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                    /*"      15     FILLER            PIC  X(004)    VALUE  SPACES.*/
                    public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                    /*"    10       FILLER            REDEFINES      LD11-NRCHEQUE.*/
                }
                private _REDEF_AC0041B_FILLER_149 _filler_149 { get; set; }
                public _REDEF_AC0041B_FILLER_149 FILLER_149
                {
                    get { _filler_149 = new _REDEF_AC0041B_FILLER_149(); _.Move(LD11_NRCHEQUE, _filler_149); VarBasis.RedefinePassValue(LD11_NRCHEQUE, _filler_149, LD11_NRCHEQUE); _filler_149.ValueChanged += () => { _.Move(_filler_149, LD11_NRCHEQUE); }; return _filler_149; }
                    set { VarBasis.RedefinePassValue(value, _filler_149, LD11_NRCHEQUE); }
                }  //Redefines
                public class _REDEF_AC0041B_FILLER_149 : VarBasis
                {
                    /*"      15     LD11-TITL-01      PIC  X(030).*/
                    public StringBasis LD11_TITL_01 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                    /*"      15     LD11-TITL-02      PIC  X(018).*/
                    public StringBasis LD11_TITL_02 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
                    /*"      15     FILLER            PIC  X(017).*/
                    public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
                    /*"  05         LR01.*/

                    public _REDEF_AC0041B_FILLER_149()
                    {
                        LD11_TITL_01.ValueChanged += OnValueChanged;
                        LD11_TITL_02.ValueChanged += OnValueChanged;
                        FILLER_150.ValueChanged += OnValueChanged;
                    }

                }
            }
            public AC0041B_LR01 LR01 { get; set; } = new AC0041B_LR01();
            public class AC0041B_LR01 : VarBasis
            {
                /*"    10       FILLER            PIC  X(001)    VALUE '+'.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    10       FILLER            PIC  X(130)    VALUE ALL '-'.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"ALL");
                /*"    10       FILLER            PIC  X(001)    VALUE '+'.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  05         LR02.*/
            }
            public AC0041B_LR02 LR02 { get; set; } = new AC0041B_LR02();
            public class AC0041B_LR02 : VarBasis
            {
                /*"    10       FILLER            PIC  X(001)    VALUE 'I'.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    10       FILLER            PIC  X(130)    VALUE  SPACES.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"");
                /*"    10       FILLER            PIC  X(001)    VALUE 'I'.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  05         LR03.*/
            }
            public AC0041B_LR03 LR03 { get; set; } = new AC0041B_LR03();
            public class AC0041B_LR03 : VarBasis
            {
                /*"    10       FILLER            PIC  X(001)    VALUE 'I'.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    10       FILLER            PIC  X(035)    VALUE            ' RECEBI(EMOS) A IMPORTANCIA DE  R$ '.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" RECEBI(EMOS) A IMPORTANCIA DE  R$ ");
                /*"    10       LR03-TOTAL-LIQ    PIC  ***.***.***.***,**-.*/
                public StringBasis LR03_TOTAL_LIQ { get; set; } = new StringBasis(new PIC("X", "0", "***.***.***.***V**-."), @"");
                /*"    10       FILLER            PIC  X(001)    VALUE '('.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"    10       LR03-EXTENSO1     PIC  X(075)    VALUE  SPACES.*/
                public StringBasis LR03_EXTENSO1 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"");
                /*"    10       FILLER            PIC  X(001)    VALUE 'I'.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  05         LR04.*/
            }
            public AC0041B_LR04 LR04 { get; set; } = new AC0041B_LR04();
            public class AC0041B_LR04 : VarBasis
            {
                /*"    10       FILLER            PIC  X(002)    VALUE 'I'.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"I");
                /*"    10       LR04-EXTENSO2     PIC  X(053)    VALUE  SPACES.*/
                public StringBasis LR04_EXTENSO2 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"");
                /*"    10       FILLER            PIC  X(002)    VALUE ')'.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"    10       FILLER            PIC  X(074)    VALUE            'REFERENTE AO LIQUIDO DOS  PREMIOS  SUPRA RELACIONADO            'S.'.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "74", "X(074)"), @"REFERENTE AO LIQUIDO DOS  PREMIOS  SUPRA RELACIONADO            ");
                /*"    10       FILLER            PIC  X(001)    VALUE 'I'.*/
                public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  05         LR05.*/
            }
            public AC0041B_LR05 LR05 { get; set; } = new AC0041B_LR05();
            public class AC0041B_LR05 : VarBasis
            {
                /*"    10       FILLER            PIC  X(001)    VALUE 'I'.*/
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    10       FILLER            PIC  X(015)    VALUE  SPACES.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10       LR05-CIDADE       PIC  X(020)    VALUE  SPACES.*/
                public StringBasis LR05_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10       FILLER            PIC  X(001)    VALUE ','.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @",");
                /*"    10       FILLER            PIC  X(007)    VALUE  SPACES.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10       FILLER            PIC  X(002)    VALUE 'DE'.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"DE");
                /*"    10       FILLER            PIC  X(015)    VALUE  SPACES.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10       FILLER            PIC  X(002)    VALUE 'DE'.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"DE");
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       FILLER            PIC  X(017)    VALUE  SPACES.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"    10       FILLER            PIC  X(035)    VALUE ALL '-'.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"ALL");
                /*"    10       FILLER            PIC  X(015)    VALUE  SPACES.*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10       FILLER            PIC  X(001)    VALUE 'I'.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  05         LR06.*/
            }
            public AC0041B_LR06 LR06 { get; set; } = new AC0041B_LR06();
            public class AC0041B_LR06 : VarBasis
            {
                /*"    10       FILLER            PIC  X(001)    VALUE 'I'.*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    10       FILLER            PIC  X(092)    VALUE  SPACES.*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "92", "X(092)"), @"");
                /*"    10       FILLER            PIC  X(010)    VALUE            'ASSINATURA'.*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ASSINATURA");
                /*"    10       FILLER            PIC  X(028)    VALUE  SPACES.*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"");
                /*"    10       FILLER            PIC  X(001)    VALUE 'I'.*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"01           IDENTIFICA-FORM-DBM.*/
            }
        }
        public AC0041B_IDENTIFICA_FORM_DBM IDENTIFICA_FORM_DBM { get; set; } = new AC0041B_IDENTIFICA_FORM_DBM();
        public class AC0041B_IDENTIFICA_FORM_DBM : VarBasis
        {
            /*"    05       FDBM-POSICIONA    PIC  X(002)    VALUE '%!'.*/
            public StringBasis FDBM_POSICIONA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"%!");
            /*"    05       FDBM-LAND         PIC  X(018)    VALUE            '(land.jdt) STARTLM'.*/
            public StringBasis FDBM_LAND { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"(land.jdt) STARTLM");
            /*"    05       FDBM-EOF          PIC  X(005)    VALUE '%%EOF'.*/
            public StringBasis FDBM_EOF { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"%%EOF");
            /*"01          LK-LINK.*/
        }
        public AC0041B_LK_LINK LK_LINK { get; set; } = new AC0041B_LK_LINK();
        public class AC0041B_LK_LINK : VarBasis
        {
            /*"  05        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  05        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01          WEXTENSO.*/
        }
        public AC0041B_WEXTENSO WEXTENSO { get; set; } = new AC0041B_WEXTENSO();
        public class AC0041B_WEXTENSO : VarBasis
        {
            /*"  05        WVALOR-LIQ          PIC S9(015)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WVALOR_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05        WRESPOSTA           PIC  X(004).*/
            public StringBasis WRESPOSTA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05        WAREA-1.*/
            public AC0041B_WAREA_1 WAREA_1 { get; set; } = new AC0041B_WAREA_1();
            public class AC0041B_WAREA_1 : VarBasis
            {
                /*"    10      WTAM-1              PIC  9(003)    VALUE 75.*/
                public IntBasis WTAM_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 75);
                /*"    10      WLINHA-1            PIC  X(075).*/
                public StringBasis WLINHA_1 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)."), @"");
                /*"  05        WAREA-2.*/
            }
            public AC0041B_WAREA_2 WAREA_2 { get; set; } = new AC0041B_WAREA_2();
            public class AC0041B_WAREA_2 : VarBasis
            {
                /*"    10      WTAM-2              PIC  9(003)    VALUE 53.*/
                public IntBasis WTAM_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 53);
                /*"    10      WLINHA-2            PIC  X(053).*/
                public StringBasis WLINHA_2 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)."), @"");
                /*"01          WABEND.*/
            }
        }
        public AC0041B_WABEND WABEND { get; set; } = new AC0041B_WABEND();
        public class AC0041B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)     VALUE           ' AC0041B'.*/
            public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AC0041B");
            /*"  05        FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC -------999  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "-------999"));
        }


        public AC0041B_V0COSCEDCHQ V0COSCEDCHQ { get; set; } = new AC0041B_V0COSCEDCHQ();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RAC0041B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RAC0041B.SetFile(RAC0041B_FILE_NAME_P);

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
            /*" -645- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -646- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -649- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -652- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -656- OPEN OUTPUT RAC0041B. */
            RAC0041B.Open(REG_AC0041B);

            /*" -658- PERFORM R0100-00-SELECT-V1SISTEMA-AC. */

            R0100_00_SELECT_V1SISTEMA_AC_SECTION();

            /*" -660- PERFORM R0150-00-SELECT-V1SISTEMA-FI. */

            R0150_00_SELECT_V1SISTEMA_FI_SECTION();

            /*" -661- IF V1SIST-DTMOVABE-FI NOT EQUAL V1SIST-DTMOVABE-AC */

            if (V1SIST_DTMOVABE_FI != V1SIST_DTMOVABE_AC)
            {

                /*" -662- DISPLAY 'R0000 - DATA DO SISTEMA FI DIFERE DO AC' */
                _.Display($"R0000 - DATA DO SISTEMA FI DIFERE DO AC");

                /*" -663- DISPLAY 'DATA MOVTO FI - ' V1SIST-DTMOVABE-FI */
                _.Display($"DATA MOVTO FI - {V1SIST_DTMOVABE_FI}");

                /*" -664- DISPLAY 'DATA MOVTO AC - ' V1SIST-DTMOVABE-AC */
                _.Display($"DATA MOVTO AC - {V1SIST_DTMOVABE_AC}");

                /*" -666- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -668- PERFORM R0200-00-SELECT-V1EMPRESA. */

            R0200_00_SELECT_V1EMPRESA_SECTION();

            /*" -674- MOVE ZEROS TO WTOT-GER-SD WTOT-GER-PG WTOT-GER-RC WTOT-GER-DC WTOT-GERAL. */
            _.Move(0, AREA_DE_WORK.WTOT_GER_SD, AREA_DE_WORK.WTOT_GER_PG, AREA_DE_WORK.WTOT_GER_RC, AREA_DE_WORK.WTOT_GER_DC, AREA_DE_WORK.WTOT_GERAL);

            /*" -676- PERFORM R0400-00-DECLARE-V0COSCEDCHQ. */

            R0400_00_DECLARE_V0COSCEDCHQ_SECTION();

            /*" -678- PERFORM R0450-00-FETCH-V0COSCEDCHQ. */

            R0450_00_FETCH_V0COSCEDCHQ_SECTION();

            /*" -679- IF WFIM-V0COSCEDCHQ NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0COSCEDCHQ.IsEmpty())
            {

                /*" -684- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -687- PERFORM R0500-00-PROCESSA-CONGENERE UNTIL WFIM-V0COSCEDCHQ NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0COSCEDCHQ.IsEmpty()))
            {

                R0500_00_PROCESSA_CONGENERE_SECTION();
            }

            /*" -692- IF WTOT-GER-SD = ZEROS AND WTOT-GER-PG = ZEROS AND WTOT-GER-RC = ZEROS AND WTOT-GER-DC = ZEROS NEXT SENTENCE */

            if (AREA_DE_WORK.WTOT_GER_SD == 00 && AREA_DE_WORK.WTOT_GER_PG == 00 && AREA_DE_WORK.WTOT_GER_RC == 00 && AREA_DE_WORK.WTOT_GER_DC == 00)
            {

                /*" -693- ELSE */
            }
            else
            {


                /*" -693- PERFORM R4000-00-IMPRIME-TOTAL-GERAL. */

                R4000_00_IMPRIME_TOTAL_GERAL_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -701- CLOSE RAC0041B. */
            RAC0041B.Close();

            /*" -702- DISPLAY 'CHEQUE COSSEGURO *** ' . */
            _.Display($"CHEQUE COSSEGURO *** ");

            /*" -703- DISPLAY 'REGISTROS  LIDOS   - ' AC-L-V0COSCEDCHQ. */
            _.Display($"REGISTROS  LIDOS   - {AREA_DE_WORK.AC_L_V0COSCEDCHQ}");

            /*" -705- DISPLAY 'AC0041B - FIM NORMAL ' . */
            _.Display($"AC0041B - FIM NORMAL ");

            /*" -705- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -709- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -709- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-AC-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_AC_SECTION()
        {
            /*" -722- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -727- PERFORM R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1();

            /*" -730- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -731- DISPLAY 'R0100 - ERRO NO SELECT DA V1SISTEMA - AC' */
                _.Display($"R0100 - ERRO NO SELECT DA V1SISTEMA - AC");

                /*" -732- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -733- ELSE */
            }
            else
            {


                /*" -733- DISPLAY 'DATA DO MOVIMENTO (AC) - ' V1SIST-DTMOVABE-AC. */
                _.Display($"DATA DO MOVIMENTO (AC) - {V1SIST_DTMOVABE_AC}");
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-AC-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1()
        {
            /*" -727- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE-AC FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'AC' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE_AC, V1SIST_DTMOVABE_AC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-SELECT-V1SISTEMA-FI-SECTION */
        private void R0150_00_SELECT_V1SISTEMA_FI_SECTION()
        {
            /*" -746- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", WABEND.WNR_EXEC_SQL);

            /*" -753- PERFORM R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1 */

            R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1();

            /*" -756- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -757- DISPLAY 'R0150 - ERRO NO SELECT DA V1SISTEMA - FI' */
                _.Display($"R0150 - ERRO NO SELECT DA V1SISTEMA - FI");

                /*" -758- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -759- ELSE */
            }
            else
            {


                /*" -759- DISPLAY 'DATA DO MOVIMENTO (FI) - ' V1SIST-DTMOVABE-FI. */
                _.Display($"DATA DO MOVIMENTO (FI) - {V1SIST_DTMOVABE_FI}");
            }


        }

        [StopWatch]
        /*" R0150-00-SELECT-V1SISTEMA-FI-DB-SELECT-1 */
        public void R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1()
        {
            /*" -753- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE-FI, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'FI' END-EXEC. */

            var r0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1 = new R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1.Execute(r0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE_FI, V1SIST_DTMOVABE_FI);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V1EMPRESA-SECTION */
        private void R0200_00_SELECT_V1EMPRESA_SECTION()
        {
            /*" -772- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -779- PERFORM R0200_00_SELECT_V1EMPRESA_DB_SELECT_1 */

            R0200_00_SELECT_V1EMPRESA_DB_SELECT_1();

            /*" -782- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -783- DISPLAY 'R0200 - ERRO NO SELECT DA V1EMPRESA' */
                _.Display($"R0200 - ERRO NO SELECT DA V1EMPRESA");

                /*" -785- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -787- MOVE V1EMPR-NOM-EMP TO LK-TITULO. */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -789- CALL 'PROALN01' USING LK-LINK. */
            _.Call("PROALN01", LK_LINK);

            /*" -790- IF LK-RTCODE = ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -791- MOVE LK-TITULO TO LC03-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, RELATORIO.LC03.LC03_EMPRESA);

                /*" -792- ELSE */
            }
            else
            {


                /*" -793- DISPLAY 'R0200 - ERRO NO CALL DA SUB-ROTINA PROALN01' */
                _.Display($"R0200 - ERRO NO CALL DA SUB-ROTINA PROALN01");

                /*" -795- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -796- MOVE ZEROS TO V1EMPR-COD-EMP. */
            _.Move(0, V1EMPR_COD_EMP);

            /*" -798- MOVE SPACES TO V1EMPR-NOM-EMP. */
            _.Move("", V1EMPR_NOM_EMP);

            /*" -800- PERFORM R0300-00-SELECT-V1EMPRESA. */

            R0300_00_SELECT_V1EMPRESA_SECTION();

            /*" -801- MOVE V1EMPR-COD-EMP TO LC04-COD-EMPR. */
            _.Move(V1EMPR_COD_EMP, RELATORIO.LC04.LC04_COD_EMPR);

            /*" -803- MOVE V1EMPR-NOM-EMP TO LC04-NOM-EMPR. */
            _.Move(V1EMPR_NOM_EMP, RELATORIO.LC04.LC04_NOM_EMPR);

            /*" -804- MOVE V1SIST-DTCURRENT TO WDATA-AUX. */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_AUX);

            /*" -805- MOVE WDATA-DD-AUX TO WDATA-DD-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_DD_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDT);

            /*" -806- MOVE WDATA-MM-AUX TO WDATA-MM-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_MM_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDT);

            /*" -807- MOVE WDATA-AA-AUX TO WDATA-AA-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_AA_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDT);

            /*" -809- MOVE WDATA-EDIT TO LC04-DATA. */
            _.Move(AREA_DE_WORK.WDATA_EDIT, RELATORIO.LC04.LC04_DATA);

            /*" -810- MOVE V1SIST-DTMOVABE-FI TO WDATA-AUX. */
            _.Move(V1SIST_DTMOVABE_FI, AREA_DE_WORK.WDATA_AUX);

            /*" -811- MOVE WDATA-DD-AUX TO WDATA-DD-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_DD_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDT);

            /*" -812- MOVE WDATA-MM-AUX TO WDATA-MM-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_MM_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDT);

            /*" -813- MOVE WDATA-AA-AUX TO WDATA-AA-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_AA_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDT);

            /*" -815- MOVE WDATA-EDIT TO LC05-DTMOVTO. */
            _.Move(AREA_DE_WORK.WDATA_EDIT, RELATORIO.LC05.LC05_DTMOVTO);

            /*" -816- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -817- MOVE WHORA-HH-CUR TO WHORA-HH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CUR, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDT);

            /*" -818- MOVE WHORA-MM-CUR TO WHORA-MM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CUR, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDT);

            /*" -819- MOVE WHORA-SS-CUR TO WHORA-SS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CUR, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDT);

            /*" -819- MOVE WHORA-EDIT TO LC05-HORA. */
            _.Move(AREA_DE_WORK.WHORA_EDIT, RELATORIO.LC05.LC05_HORA);

        }

        [StopWatch]
        /*" R0200-00-SELECT-V1EMPRESA-DB-SELECT-1 */
        public void R0200_00_SELECT_V1EMPRESA_DB_SELECT_1()
        {
            /*" -779- EXEC SQL SELECT NOME_EMPRESA, CGCCPF INTO :V1EMPR-NOM-EMP, :V1EMPR-CGCCPF FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 99 END-EXEC. */

            var r0200_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1 = new R0200_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
                _.Move(executed_1.V1EMPR_CGCCPF, V1EMPR_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-SELECT-V1EMPRESA-SECTION */
        private void R0300_00_SELECT_V1EMPRESA_SECTION()
        {
            /*" -832- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -839- PERFORM R0300_00_SELECT_V1EMPRESA_DB_SELECT_1 */

            R0300_00_SELECT_V1EMPRESA_DB_SELECT_1();

            /*" -842- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -843- DISPLAY 'R0300 - ERRO NO SELECT DA V1EMPRESA' */
                _.Display($"R0300 - ERRO NO SELECT DA V1EMPRESA");

                /*" -844- DISPLAY 'COD EMPR - ' V1EMPR-COD-EMP */
                _.Display($"COD EMPR - {V1EMPR_COD_EMP}");

                /*" -845- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -845- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-SELECT-V1EMPRESA-DB-SELECT-1 */
        public void R0300_00_SELECT_V1EMPRESA_DB_SELECT_1()
        {
            /*" -839- EXEC SQL SELECT COD_EMPRESA, NOME_EMPRESA INTO :V1EMPR-COD-EMP, :V1EMPR-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = :V1EMPR-COD-EMP END-EXEC. */

            var r0300_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1 = new R0300_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1()
            {
                V1EMPR_COD_EMP = V1EMPR_COD_EMP.ToString(),
            };

            var executed_1 = R0300_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1.Execute(r0300_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_COD_EMP, V1EMPR_COD_EMP);
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-DECLARE-V0COSCEDCHQ-SECTION */
        private void R0400_00_DECLARE_V0COSCEDCHQ_SECTION()
        {
            /*" -858- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -890- PERFORM R0400_00_DECLARE_V0COSCEDCHQ_DB_DECLARE_1 */

            R0400_00_DECLARE_V0COSCEDCHQ_DB_DECLARE_1();

            /*" -892- PERFORM R0400_00_DECLARE_V0COSCEDCHQ_DB_OPEN_1 */

            R0400_00_DECLARE_V0COSCEDCHQ_DB_OPEN_1();

            /*" -895- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -896- DISPLAY 'R0400 - ERRO NO DECLARE DA V0COSCED-CHEQUE' */
                _.Display($"R0400 - ERRO NO DECLARE DA V0COSCED-CHEQUE");

                /*" -897- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -898- ELSE */
            }
            else
            {


                /*" -898- MOVE SPACES TO WFIM-V0COSCEDCHQ. */
                _.Move("", AREA_DE_WORK.WFIM_V0COSCEDCHQ);
            }


        }

        [StopWatch]
        /*" R0400-00-DECLARE-V0COSCEDCHQ-DB-DECLARE-1 */
        public void R0400_00_DECLARE_V0COSCEDCHQ_DB_DECLARE_1()
        {
            /*" -890- EXEC SQL DECLARE V0COSCEDCHQ CURSOR FOR SELECT COD_EMPRESA , CONGENER , DTMOVTO_AC , CODUSU_AC , DTLIBERA , NRCHEQUE , DVCHEQUE , VLPREMIO , VLRDESCON , VLRADIFRA , VLRCOMIS , VLRSINI , VLDESPESA , VLRHONOR , VLRSALVD , VLRESSARC , VALOR_EDI , VALOR_USS , VLEQPVNDA , VLDESPADM , OUTRDEBIT , OUTRCREDT , VLRSLDANT , SITUACAO , DTMOVTO_FI FROM SEGUROS.V0COSCED_CHEQUE WHERE COD_EMPRESA = :V1EMPR-COD-EMP AND DTMOVTO_FI = :V1SIST-DTMOVABE-FI AND SITUACAO = '1' ORDER BY COD_EMPRESA, CONGENER END-EXEC. */
            V0COSCEDCHQ = new AC0041B_V0COSCEDCHQ(true);
            string GetQuery_V0COSCEDCHQ()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							CONGENER
							, 
							DTMOVTO_AC
							, 
							CODUSU_AC
							, 
							DTLIBERA
							, 
							NRCHEQUE
							, 
							DVCHEQUE
							, 
							VLPREMIO
							, 
							VLRDESCON
							, 
							VLRADIFRA
							, 
							VLRCOMIS
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
							VALOR_EDI
							, 
							VALOR_USS
							, 
							VLEQPVNDA
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
							, 
							DTMOVTO_FI 
							FROM SEGUROS.V0COSCED_CHEQUE 
							WHERE COD_EMPRESA = '{V1EMPR_COD_EMP}' 
							AND DTMOVTO_FI = '{V1SIST_DTMOVABE_FI}' 
							AND SITUACAO = '1' 
							ORDER BY COD_EMPRESA
							, 
							CONGENER";

                return query;
            }
            V0COSCEDCHQ.GetQueryEvent += GetQuery_V0COSCEDCHQ;

        }

        [StopWatch]
        /*" R0400-00-DECLARE-V0COSCEDCHQ-DB-OPEN-1 */
        public void R0400_00_DECLARE_V0COSCEDCHQ_DB_OPEN_1()
        {
            /*" -892- EXEC SQL OPEN V0COSCEDCHQ END-EXEC. */

            V0COSCEDCHQ.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-FETCH-V0COSCEDCHQ-SECTION */
        private void R0450_00_FETCH_V0COSCEDCHQ_SECTION()
        {
            /*" -909- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0450_10_LER_V0COSCEDCHQ */

            R0450_10_LER_V0COSCEDCHQ();

        }

        [StopWatch]
        /*" R0450-10-LER-V0COSCEDCHQ */
        private void R0450_10_LER_V0COSCEDCHQ(bool isPerform = false)
        {
            /*" -939- PERFORM R0450_10_LER_V0COSCEDCHQ_DB_FETCH_1 */

            R0450_10_LER_V0COSCEDCHQ_DB_FETCH_1();

            /*" -942- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -943- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -944- MOVE 'S' TO WFIM-V0COSCEDCHQ */
                    _.Move("S", AREA_DE_WORK.WFIM_V0COSCEDCHQ);

                    /*" -944- PERFORM R0450_10_LER_V0COSCEDCHQ_DB_CLOSE_1 */

                    R0450_10_LER_V0COSCEDCHQ_DB_CLOSE_1();

                    /*" -946- ELSE */
                }
                else
                {


                    /*" -947- DISPLAY 'R0450 - ERRO NO FETCH DA V0COSCED-CHEQUE' */
                    _.Display($"R0450 - ERRO NO FETCH DA V0COSCED-CHEQUE");

                    /*" -948- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -949- ELSE */
                }

            }
            else
            {


                /*" -965- IF V0CCCH-VLPREMIO = ZEROS AND V0CCCH-VLDESCON = ZEROS AND V0CCCH-VLADIFRA = ZEROS AND V0CCCH-VLRCOMIS = ZEROS AND V0CCCH-VLRSINI = ZEROS AND V0CCCH-VLDESPESA = ZEROS AND V0CCCH-VLRHONOR = ZEROS AND V0CCCH-VLRSALVD = ZEROS AND V0CCCH-VLRESSARC = ZEROS AND V0CCCH-VALOR-EDI = ZEROS AND V0CCCH-VALOR-USS = ZEROS AND V0CCCH-VLEQPVNDA = ZEROS AND V0CCCH-VLDESPADM = ZEROS AND V0CCCH-OUTRDEBIT = ZEROS AND V0CCCH-OUTRCREDT = ZEROS AND V0CCCH-VLRSLDANT = ZEROS */

                if (V0CCCH_VLPREMIO == 00 && V0CCCH_VLDESCON == 00 && V0CCCH_VLADIFRA == 00 && V0CCCH_VLRCOMIS == 00 && V0CCCH_VLRSINI == 00 && V0CCCH_VLDESPESA == 00 && V0CCCH_VLRHONOR == 00 && V0CCCH_VLRSALVD == 00 && V0CCCH_VLRESSARC == 00 && V0CCCH_VALOR_EDI == 00 && V0CCCH_VALOR_USS == 00 && V0CCCH_VLEQPVNDA == 00 && V0CCCH_VLDESPADM == 00 && V0CCCH_OUTRDEBIT == 00 && V0CCCH_OUTRCREDT == 00 && V0CCCH_VLRSLDANT == 00)
                {

                    /*" -966- GO TO R0450-10-LER-V0COSCEDCHQ */
                    new Task(() => R0450_10_LER_V0COSCEDCHQ()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -967- ELSE */
                }
                else
                {


                    /*" -967- ADD 1 TO AC-L-V0COSCEDCHQ. */
                    AREA_DE_WORK.AC_L_V0COSCEDCHQ.Value = AREA_DE_WORK.AC_L_V0COSCEDCHQ + 1;
                }

            }


        }

        [StopWatch]
        /*" R0450-10-LER-V0COSCEDCHQ-DB-FETCH-1 */
        public void R0450_10_LER_V0COSCEDCHQ_DB_FETCH_1()
        {
            /*" -939- EXEC SQL FETCH V0COSCEDCHQ INTO :V0CCCH-COD-EMPR , :V0CCCH-CONGENER , :V0CCCH-DTMOVTAC , :V0CCCH-CODUSUAC , :V0CCCH-DTLIBERA , :V0CCCH-NRCHQINT , :V0CCCH-DVCHQINT , :V0CCCH-VLPREMIO , :V0CCCH-VLDESCON , :V0CCCH-VLADIFRA , :V0CCCH-VLRCOMIS , :V0CCCH-VLRSINI , :V0CCCH-VLDESPESA , :V0CCCH-VLRHONOR , :V0CCCH-VLRSALVD , :V0CCCH-VLRESSARC , :V0CCCH-VALOR-EDI , :V0CCCH-VALOR-USS , :V0CCCH-VLEQPVNDA , :V0CCCH-VLDESPADM , :V0CCCH-OUTRDEBIT , :V0CCCH-OUTRCREDT , :V0CCCH-VLRSLDANT , :V0CCCH-SITUACAO , :V0CCCH-DTMOVTFI END-EXEC. */

            if (V0COSCEDCHQ.Fetch())
            {
                _.Move(V0COSCEDCHQ.V0CCCH_COD_EMPR, V0CCCH_COD_EMPR);
                _.Move(V0COSCEDCHQ.V0CCCH_CONGENER, V0CCCH_CONGENER);
                _.Move(V0COSCEDCHQ.V0CCCH_DTMOVTAC, V0CCCH_DTMOVTAC);
                _.Move(V0COSCEDCHQ.V0CCCH_CODUSUAC, V0CCCH_CODUSUAC);
                _.Move(V0COSCEDCHQ.V0CCCH_DTLIBERA, V0CCCH_DTLIBERA);
                _.Move(V0COSCEDCHQ.V0CCCH_NRCHQINT, V0CCCH_NRCHQINT);
                _.Move(V0COSCEDCHQ.V0CCCH_DVCHQINT, V0CCCH_DVCHQINT);
                _.Move(V0COSCEDCHQ.V0CCCH_VLPREMIO, V0CCCH_VLPREMIO);
                _.Move(V0COSCEDCHQ.V0CCCH_VLDESCON, V0CCCH_VLDESCON);
                _.Move(V0COSCEDCHQ.V0CCCH_VLADIFRA, V0CCCH_VLADIFRA);
                _.Move(V0COSCEDCHQ.V0CCCH_VLRCOMIS, V0CCCH_VLRCOMIS);
                _.Move(V0COSCEDCHQ.V0CCCH_VLRSINI, V0CCCH_VLRSINI);
                _.Move(V0COSCEDCHQ.V0CCCH_VLDESPESA, V0CCCH_VLDESPESA);
                _.Move(V0COSCEDCHQ.V0CCCH_VLRHONOR, V0CCCH_VLRHONOR);
                _.Move(V0COSCEDCHQ.V0CCCH_VLRSALVD, V0CCCH_VLRSALVD);
                _.Move(V0COSCEDCHQ.V0CCCH_VLRESSARC, V0CCCH_VLRESSARC);
                _.Move(V0COSCEDCHQ.V0CCCH_VALOR_EDI, V0CCCH_VALOR_EDI);
                _.Move(V0COSCEDCHQ.V0CCCH_VALOR_USS, V0CCCH_VALOR_USS);
                _.Move(V0COSCEDCHQ.V0CCCH_VLEQPVNDA, V0CCCH_VLEQPVNDA);
                _.Move(V0COSCEDCHQ.V0CCCH_VLDESPADM, V0CCCH_VLDESPADM);
                _.Move(V0COSCEDCHQ.V0CCCH_OUTRDEBIT, V0CCCH_OUTRDEBIT);
                _.Move(V0COSCEDCHQ.V0CCCH_OUTRCREDT, V0CCCH_OUTRCREDT);
                _.Move(V0COSCEDCHQ.V0CCCH_VLRSLDANT, V0CCCH_VLRSLDANT);
                _.Move(V0COSCEDCHQ.V0CCCH_SITUACAO, V0CCCH_SITUACAO);
                _.Move(V0COSCEDCHQ.V0CCCH_DTMOVTFI, V0CCCH_DTMOVTFI);
            }

        }

        [StopWatch]
        /*" R0450-10-LER-V0COSCEDCHQ-DB-CLOSE-1 */
        public void R0450_10_LER_V0COSCEDCHQ_DB_CLOSE_1()
        {
            /*" -944- EXEC SQL CLOSE V0COSCEDCHQ END-EXEC */

            V0COSCEDCHQ.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-PROCESSA-CONGENERE-SECTION */
        private void R0500_00_PROCESSA_CONGENERE_SECTION()
        {
            /*" -980- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -982- PERFORM R0600-00-SELECT-V1CONGENERE. */

            R0600_00_SELECT_V1CONGENERE_SECTION();

            /*" -983- MOVE V1CONG-CONGENER TO LC06-CONGENER. */
            _.Move(V1CONG_CONGENER, RELATORIO.LC06.LC06_CONGENER);

            /*" -985- MOVE V1CONG-NOMECONG TO LC06-NOME-CONG. */
            _.Move(V1CONG_NOMECONG, RELATORIO.LC06.LC06_NOME_CONG);

            /*" -987- PERFORM R3000-00-IMPRIME-CABECALHO. */

            R3000_00_IMPRIME_CABECALHO_SECTION();

            /*" -989- MOVE V0CCCH-VLRSLDANT TO LC07-VLRSLDANT. */
            _.Move(V0CCCH_VLRSLDANT, RELATORIO.LC07.LC07_VLRSLDANT);

            /*" -990- MOVE V0CCCH-DTLIBERA TO WDATA-AUX. */
            _.Move(V0CCCH_DTLIBERA, AREA_DE_WORK.WDATA_AUX);

            /*" -991- MOVE WDATA-DD-AUX TO WDATA-DD-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_DD_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDT);

            /*" -992- MOVE WDATA-MM-AUX TO WDATA-MM-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_MM_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDT);

            /*" -993- MOVE WDATA-AA-AUX TO WDATA-AA-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_AA_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDT);

            /*" -995- MOVE WDATA-EDIT TO LC08-DTLIBERA. */
            _.Move(AREA_DE_WORK.WDATA_EDIT, RELATORIO.LC08.LC08_DTLIBERA);

            /*" -996- MOVE V0CCCH-DTMOVTAC TO WDATA-AUX. */
            _.Move(V0CCCH_DTMOVTAC, AREA_DE_WORK.WDATA_AUX);

            /*" -997- MOVE WDATA-DD-AUX TO WDATA-DD-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_DD_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDT);

            /*" -998- MOVE WDATA-MM-AUX TO WDATA-MM-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_MM_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDT);

            /*" -999- MOVE WDATA-AA-AUX TO WDATA-AA-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_AA_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDT);

            /*" -1001- MOVE WDATA-EDIT TO LC08-DTMOVTAC. */
            _.Move(AREA_DE_WORK.WDATA_EDIT, RELATORIO.LC08.LC08_DTMOVTAC);

            /*" -1002- MOVE V0CCCH-DTMOVTFI TO WDATA-AUX. */
            _.Move(V0CCCH_DTMOVTFI, AREA_DE_WORK.WDATA_AUX);

            /*" -1003- MOVE WDATA-DD-AUX TO WDATA-DD-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_DD_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDT);

            /*" -1004- MOVE WDATA-MM-AUX TO WDATA-MM-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_MM_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDT);

            /*" -1005- MOVE WDATA-AA-AUX TO WDATA-AA-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX.WDATA_AA_AUX, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDT);

            /*" -1007- MOVE WDATA-EDIT TO LC13-DTMOVTFI. */
            _.Move(AREA_DE_WORK.WDATA_EDIT, RELATORIO.LC13.LC13_DTMOVTFI);

            /*" -1008- MOVE V0CCCH-VLPREMIO TO LD01-VLPREMIO. */
            _.Move(V0CCCH_VLPREMIO, RELATORIO.LD01.LD01_VLPREMIO);

            /*" -1009- MOVE V0CCCH-VLDESCON TO LD01-VLDESCON. */
            _.Move(V0CCCH_VLDESCON, RELATORIO.LD01.LD01_VLDESCON);

            /*" -1011- MOVE V0CCCH-VLADIFRA TO LD01-VLADIFRA. */
            _.Move(V0CCCH_VLADIFRA, RELATORIO.LD01.LD01_VLADIFRA);

            /*" -1015- COMPUTE WPRM-TOTAL = V0CCCH-VLPREMIO - V0CCCH-VLDESCON + V0CCCH-VLADIFRA. */
            AREA_DE_WORK.WPRM_TOTAL.Value = V0CCCH_VLPREMIO - V0CCCH_VLDESCON + V0CCCH_VLADIFRA;

            /*" -1016- MOVE WPRM-TOTAL TO LD01-PRM-TOTAL. */
            _.Move(AREA_DE_WORK.WPRM_TOTAL, RELATORIO.LD01.LD01_PRM_TOTAL);

            /*" -1018- MOVE V0CCCH-VLRCOMIS TO LD01-VLRCOMIS. */
            _.Move(V0CCCH_VLRCOMIS, RELATORIO.LD01.LD01_VLRCOMIS);

            /*" -1021- COMPUTE WTOT-PAGAR = WPRM-TOTAL - V0CCCH-VLRCOMIS. */
            AREA_DE_WORK.WTOT_PAGAR.Value = AREA_DE_WORK.WPRM_TOTAL - V0CCCH_VLRCOMIS;

            /*" -1023- MOVE WTOT-PAGAR TO LD01-TOT-PAGAR. */
            _.Move(AREA_DE_WORK.WTOT_PAGAR, RELATORIO.LD01.LD01_TOT_PAGAR);

            /*" -1024- MOVE V0CCCH-VLRSINI TO LD02-VLRSINI. */
            _.Move(V0CCCH_VLRSINI, RELATORIO.LD02.LD02_VLRSINI);

            /*" -1025- MOVE V0CCCH-VLDESPESA TO LD02-VLDESPESA. */
            _.Move(V0CCCH_VLDESPESA, RELATORIO.LD02.LD02_VLDESPESA);

            /*" -1026- MOVE V0CCCH-VLRHONOR TO LD02-VLRHONOR. */
            _.Move(V0CCCH_VLRHONOR, RELATORIO.LD02.LD02_VLRHONOR);

            /*" -1027- MOVE V0CCCH-VLRSALVD TO LD02-VLRSALVD. */
            _.Move(V0CCCH_VLRSALVD, RELATORIO.LD02.LD02_VLRSALVD);

            /*" -1029- MOVE V0CCCH-VLRESSARC TO LD02-VLRESSARC. */
            _.Move(V0CCCH_VLRESSARC, RELATORIO.LD02.LD02_VLRESSARC);

            /*" -1035- COMPUTE WTOT-RECUP = V0CCCH-VLRSINI + V0CCCH-VLDESPESA + V0CCCH-VLRHONOR - V0CCCH-VLRSALVD - V0CCCH-VLRESSARC. */
            AREA_DE_WORK.WTOT_RECUP.Value = V0CCCH_VLRSINI + V0CCCH_VLDESPESA + V0CCCH_VLRHONOR - V0CCCH_VLRSALVD - V0CCCH_VLRESSARC;

            /*" -1037- MOVE WTOT-RECUP TO LD02-TOT-RECUP. */
            _.Move(AREA_DE_WORK.WTOT_RECUP, RELATORIO.LD02.LD02_TOT_RECUP);

            /*" -1038- MOVE V0CCCH-VALOR-EDI TO LD03-VALOR-EDI. */
            _.Move(V0CCCH_VALOR_EDI, RELATORIO.LD03.LD03_VALOR_EDI);

            /*" -1039- MOVE V0CCCH-VALOR-USS TO LD03-VALOR-USS. */
            _.Move(V0CCCH_VALOR_USS, RELATORIO.LD03.LD03_VALOR_USS);

            /*" -1040- MOVE V0CCCH-VLEQPVNDA TO LD03-VLEQPVNDA. */
            _.Move(V0CCCH_VLEQPVNDA, RELATORIO.LD03.LD03_VLEQPVNDA);

            /*" -1041- MOVE V0CCCH-VLDESPADM TO LD03-VLDESPADM. */
            _.Move(V0CCCH_VLDESPADM, RELATORIO.LD03.LD03_VLDESPADM);

            /*" -1042- MOVE V0CCCH-OUTRDEBIT TO LD03-OUTRDEBIT. */
            _.Move(V0CCCH_OUTRDEBIT, RELATORIO.LD03.LD03_OUTRDEBIT);

            /*" -1044- MOVE V0CCCH-OUTRCREDT TO LD03-OUTRCREDT. */
            _.Move(V0CCCH_OUTRCREDT, RELATORIO.LD03.LD03_OUTRCREDT);

            /*" -1051- COMPUTE WTOT-DBECR = V0CCCH-VALOR-EDI + V0CCCH-VALOR-USS + V0CCCH-VLEQPVNDA + V0CCCH-VLDESPADM + V0CCCH-OUTRDEBIT - V0CCCH-OUTRCREDT. */
            AREA_DE_WORK.WTOT_DBECR.Value = V0CCCH_VALOR_EDI + V0CCCH_VALOR_USS + V0CCCH_VLEQPVNDA + V0CCCH_VLDESPADM + V0CCCH_OUTRDEBIT - V0CCCH_OUTRCREDT;

            /*" -1057- COMPUTE WTOT-CONG = WTOT-PAGAR - WTOT-RECUP - WTOT-DBECR - V0CCCH-VLRSLDANT. */
            AREA_DE_WORK.WTOT_CONG.Value = AREA_DE_WORK.WTOT_PAGAR - AREA_DE_WORK.WTOT_RECUP - AREA_DE_WORK.WTOT_DBECR - V0CCCH_VLRSLDANT;

            /*" -1058- MOVE V0CCCH-VLRSLDANT TO LD06-TOT-SDANT. */
            _.Move(V0CCCH_VLRSLDANT, RELATORIO.LD06.LD06_TOT_SDANT);

            /*" -1059- MOVE WTOT-PAGAR TO LD07-TOT-PAGAR. */
            _.Move(AREA_DE_WORK.WTOT_PAGAR, RELATORIO.LD07.LD07_TOT_PAGAR);

            /*" -1060- MOVE WTOT-RECUP TO LD08-TOT-RECUP. */
            _.Move(AREA_DE_WORK.WTOT_RECUP, RELATORIO.LD08.LD08_TOT_RECUP);

            /*" -1061- MOVE WTOT-DBECR TO LD09-TOT-DBECR. */
            _.Move(AREA_DE_WORK.WTOT_DBECR, RELATORIO.LD09.LD09_TOT_DBECR);

            /*" -1063- MOVE WTOT-CONG TO LD11-TOT-CONG. */
            _.Move(AREA_DE_WORK.WTOT_CONG, RELATORIO.LD11.LD11_TOT_CONG);

            /*" -1066- MOVE SPACES TO LD10-NRCHEQUE LD11-NRCHEQUE. */
            _.Move("", RELATORIO.LD10.LD10_NRCHEQUE, RELATORIO.LD11.LD11_NRCHEQUE);

            /*" -1070- IF V0CCCH-NRCHQINT > ZEROS */

            if (V0CCCH_NRCHQINT > 00)
            {

                /*" -1075- MOVE ZEROS TO V0LTCH-BANCO V0LTCH-AGENCIA V0LTCH-NRCHQEXT V0LTCH-DVCHQEXT */
                _.Move(0, V0LTCH_BANCO, V0LTCH_AGENCIA, V0LTCH_NRCHQEXT, V0LTCH_DVCHQEXT);

                /*" -1077- MOVE SPACES TO V0LTCH-SERCHQ. */
                _.Move("", V0LTCH_SERCHQ);
            }


            /*" -1078- IF WTOT-CONG > ZEROS */

            if (AREA_DE_WORK.WTOT_CONG > 00)
            {

                /*" -1079- MOVE 'NR. DO CHEQUE INTERNO - ' TO LD10-TITL-CHQ */
                _.Move("NR. DO CHEQUE INTERNO - ", RELATORIO.LD10.LD10_NRCHEQUE.LD10_TITL_CHQ);

                /*" -1080- MOVE V0CCCH-NRCHQINT TO LD10-NRCHQINT */
                _.Move(V0CCCH_NRCHQINT, RELATORIO.LD10.LD10_NRCHEQUE.LD10_NRCHQINT);

                /*" -1081- MOVE ' - ' TO LD10-TRACO-01 */
                _.Move(" - ", RELATORIO.LD10.LD10_NRCHEQUE.LD10_TRACO_01);

                /*" -1082- MOVE V0CCCH-DVCHQINT TO LD10-DVCHQINT */
                _.Move(V0CCCH_DVCHQINT, RELATORIO.LD10.LD10_NRCHEQUE.LD10_DVCHQINT);

                /*" -1083- MOVE 'NR. DO CHEQUE EXTERNO - ' TO LD11-TITL-CHQ */
                _.Move("NR. DO CHEQUE EXTERNO - ", RELATORIO.LD11.LD11_NRCHEQUE.LD11_TITL_CHQ);

                /*" -1084- MOVE V0LTCH-BANCO TO LD11-BANCO */
                _.Move(V0LTCH_BANCO, RELATORIO.LD11.LD11_NRCHEQUE.LD11_BANCO);

                /*" -1085- MOVE ' / ' TO LD11-BARRA-01 */
                _.Move(" / ", RELATORIO.LD11.LD11_NRCHEQUE.LD11_BARRA_01);

                /*" -1086- MOVE V0LTCH-AGENCIA TO LD11-AGENCIA */
                _.Move(V0LTCH_AGENCIA, RELATORIO.LD11.LD11_NRCHEQUE.LD11_AGENCIA);

                /*" -1087- MOVE ' / ' TO LD11-BARRA-02 */
                _.Move(" / ", RELATORIO.LD11.LD11_NRCHEQUE.LD11_BARRA_02);

                /*" -1088- MOVE V0LTCH-SERCHQ TO LD11-SERCHQ */
                _.Move(V0LTCH_SERCHQ, RELATORIO.LD11.LD11_NRCHEQUE.LD11_SERCHQ);

                /*" -1089- MOVE V0LTCH-NRCHQEXT TO LD11-NRCHQEXT */
                _.Move(V0LTCH_NRCHQEXT, RELATORIO.LD11.LD11_NRCHEQUE.LD11_NRCHQEXT);

                /*" -1090- MOVE ' - ' TO LD11-TRACO-01 */
                _.Move(" - ", RELATORIO.LD11.LD11_NRCHEQUE.LD11_TRACO_01);

                /*" -1091- MOVE V0LTCH-DVCHQEXT TO LD11-DVCHQEXT */
                _.Move(V0LTCH_DVCHQEXT, RELATORIO.LD11.LD11_NRCHEQUE.LD11_DVCHQEXT);

                /*" -1092- ELSE */
            }
            else
            {


                /*" -1093- MOVE 'NAO HOUVE EMISSAO DE CHEQUE - ' TO LD11-TITL-01 */
                _.Move("NAO HOUVE EMISSAO DE CHEQUE - ", RELATORIO.LD11.FILLER_149.LD11_TITL_01);

                /*" -1094- IF WTOT-CONG = ZEROS */

                if (AREA_DE_WORK.WTOT_CONG == 00)
                {

                    /*" -1095- MOVE 'SALDO IGUAL A ZERO' TO LD11-TITL-02 */
                    _.Move("SALDO IGUAL A ZERO", RELATORIO.LD11.FILLER_149.LD11_TITL_02);

                    /*" -1096- ELSE */
                }
                else
                {


                    /*" -1098- MOVE 'SALDO A RECUPERAR' TO LD11-TITL-02. */
                    _.Move("SALDO A RECUPERAR", RELATORIO.LD11.FILLER_149.LD11_TITL_02);
                }

            }


            /*" -1100- PERFORM R3100-00-IMPRIME-CONGENERE. */

            R3100_00_IMPRIME_CONGENERE_SECTION();

            /*" -1102- PERFORM R3200-00-IMPRIME-RECIBO. */

            R3200_00_IMPRIME_RECIBO_SECTION();

            /*" -1103- ADD V0CCCH-VLRSLDANT TO WTOT-GER-SD. */
            AREA_DE_WORK.WTOT_GER_SD.Value = AREA_DE_WORK.WTOT_GER_SD + V0CCCH_VLRSLDANT;

            /*" -1104- ADD WTOT-PAGAR TO WTOT-GER-PG. */
            AREA_DE_WORK.WTOT_GER_PG.Value = AREA_DE_WORK.WTOT_GER_PG + AREA_DE_WORK.WTOT_PAGAR;

            /*" -1105- ADD WTOT-RECUP TO WTOT-GER-RC. */
            AREA_DE_WORK.WTOT_GER_RC.Value = AREA_DE_WORK.WTOT_GER_RC + AREA_DE_WORK.WTOT_RECUP;

            /*" -1107- ADD WTOT-DBECR TO WTOT-GER-DC. */
            AREA_DE_WORK.WTOT_GER_DC.Value = AREA_DE_WORK.WTOT_GER_DC + AREA_DE_WORK.WTOT_DBECR;

            /*" -1107- PERFORM R0450-00-FETCH-V0COSCEDCHQ. */

            R0450_00_FETCH_V0COSCEDCHQ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-SELECT-V1CONGENERE-SECTION */
        private void R0600_00_SELECT_V1CONGENERE_SECTION()
        {
            /*" -1120- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", WABEND.WNR_EXEC_SQL);

            /*" -1127- PERFORM R0600_00_SELECT_V1CONGENERE_DB_SELECT_1 */

            R0600_00_SELECT_V1CONGENERE_DB_SELECT_1();

            /*" -1130- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1131- DISPLAY 'R0600 - ERRO NO SELECT DA V1CONGENERE' */
                _.Display($"R0600 - ERRO NO SELECT DA V1CONGENERE");

                /*" -1132- DISPLAY 'CONGENRE - ' V0CCCH-CONGENER */
                _.Display($"CONGENRE - {V0CCCH_CONGENER}");

                /*" -1132- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0600-00-SELECT-V1CONGENERE-DB-SELECT-1 */
        public void R0600_00_SELECT_V1CONGENERE_DB_SELECT_1()
        {
            /*" -1127- EXEC SQL SELECT CONGENER, NOMECONG INTO :V1CONG-CONGENER, :V1CONG-NOMECONG FROM SEGUROS.V1CONGENERE WHERE CONGENER = :V0CCCH-CONGENER END-EXEC. */

            var r0600_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1 = new R0600_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1()
            {
                V0CCCH_CONGENER = V0CCCH_CONGENER.ToString(),
            };

            var executed_1 = R0600_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1.Execute(r0600_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CONG_CONGENER, V1CONG_CONGENER);
                _.Move(executed_1.V1CONG_NOMECONG, V1CONG_NOMECONG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-SELECT-V0LOTECHEQUE-SECTION */
        private void R0700_00_SELECT_V0LOTECHEQUE_SECTION()
        {
            /*" -1145- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -1159- PERFORM R0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1 */

            R0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1();

            /*" -1162- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1163- DISPLAY 'R0700 - ERRO NO SELECT DA V0LOTECHEQUE' */
                _.Display($"R0700 - ERRO NO SELECT DA V0LOTECHEQUE");

                /*" -1164- DISPLAY 'CHEQUE INT - ' V0CCCH-NRCHQINT */
                _.Display($"CHEQUE INT - {V0CCCH_NRCHQINT}");

                /*" -1165- DISPLAY 'DV CHQ INT - ' V0CCCH-DVCHQINT */
                _.Display($"DV CHQ INT - {V0CCCH_DVCHQINT}");

                /*" -1165- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0700-00-SELECT-V0LOTECHEQUE-DB-SELECT-1 */
        public void R0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1()
        {
            /*" -1159- EXEC SQL SELECT BANCO, AGENCIA, NUMCHQ, DIGCHQ, SERCHQ INTO :V0LTCH-BANCO, :V0LTCH-AGENCIA, :V0LTCH-NRCHQEXT, :V0LTCH-DVCHQEXT, :V0LTCH-SERCHQ FROM SEGUROS.V0LOTECHEQUE WHERE CHQINT = :V0CCCH-NRCHQINT AND DIGINT = :V0CCCH-DVCHQINT END-EXEC. */

            var r0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1_Query1 = new R0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1_Query1()
            {
                V0CCCH_NRCHQINT = V0CCCH_NRCHQINT.ToString(),
                V0CCCH_DVCHQINT = V0CCCH_DVCHQINT.ToString(),
            };

            var executed_1 = R0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1_Query1.Execute(r0700_00_SELECT_V0LOTECHEQUE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0LTCH_BANCO, V0LTCH_BANCO);
                _.Move(executed_1.V0LTCH_AGENCIA, V0LTCH_AGENCIA);
                _.Move(executed_1.V0LTCH_NRCHQEXT, V0LTCH_NRCHQEXT);
                _.Move(executed_1.V0LTCH_DVCHQEXT, V0LTCH_DVCHQEXT);
                _.Move(executed_1.V0LTCH_SERCHQ, V0LTCH_SERCHQ);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-IMPRIME-CABECALHO-SECTION */
        private void R3000_00_IMPRIME_CABECALHO_SECTION()
        {
            /*" -1178- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WABEND.WNR_EXEC_SQL);

            /*" -1179- ADD 1 TO AC-PAGINA. */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -1181- MOVE AC-PAGINA TO LC03-PAGINA. */
            _.Move(AREA_DE_WORK.AC_PAGINA, RELATORIO.LC03.LC03_PAGINA);

            /*" -1182- MOVE '1' TO REG-AC0041BC. */
            _.Move("1", REG_AC0041B.REG_AC0041BC);

            /*" -1183- MOVE LC01 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC01, REG_AC0041B.REG_AC0041BL);

            /*" -1185- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1186- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1187- MOVE LC02 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC02, REG_AC0041B.REG_AC0041BL);

            /*" -1189- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1190- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1191- MOVE LC03 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC03, REG_AC0041B.REG_AC0041BL);

            /*" -1193- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1194- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1195- MOVE LC04 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC04, REG_AC0041B.REG_AC0041BL);

            /*" -1197- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1198- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1199- MOVE LC05 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC05, REG_AC0041B.REG_AC0041BL);

            /*" -1201- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1202- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1203- MOVE LC02 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC02, REG_AC0041B.REG_AC0041BL);

            /*" -1205- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1206- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1207- MOVE LC06 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC06, REG_AC0041B.REG_AC0041BL);

            /*" -1209- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1210- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1211- MOVE LC02 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC02, REG_AC0041B.REG_AC0041BL);

            /*" -1213- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1214- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1215- MOVE LC01 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC01, REG_AC0041B.REG_AC0041BL);

            /*" -1217- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1217- MOVE 09 TO AC-LINHAS. */
            _.Move(09, AREA_DE_WORK.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-IMPRIME-CONGENERE-SECTION */
        private void R3100_00_IMPRIME_CONGENERE_SECTION()
        {
            /*" -1230- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -1231- MOVE '-' TO REG-AC0041BC. */
            _.Move("-", REG_AC0041B.REG_AC0041BC);

            /*" -1232- MOVE LC07 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC07, REG_AC0041B.REG_AC0041BL);

            /*" -1234- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1235- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1236- MOVE LC08 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC08, REG_AC0041B.REG_AC0041BL);

            /*" -1238- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1240- ADD 04 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 04;

            /*" -1241- MOVE '0' TO REG-AC0041BC. */
            _.Move("0", REG_AC0041B.REG_AC0041BC);

            /*" -1242- MOVE LC09 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC09, REG_AC0041B.REG_AC0041BL);

            /*" -1244- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1245- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1246- MOVE LC10 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC10, REG_AC0041B.REG_AC0041BL);

            /*" -1248- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1249- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1250- MOVE LD01 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD01, REG_AC0041B.REG_AC0041BL);

            /*" -1252- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1254- ADD 04 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 04;

            /*" -1255- MOVE '0' TO REG-AC0041BC. */
            _.Move("0", REG_AC0041B.REG_AC0041BC);

            /*" -1256- MOVE LC11 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC11, REG_AC0041B.REG_AC0041BL);

            /*" -1258- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1259- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1260- MOVE LC12 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC12, REG_AC0041B.REG_AC0041BL);

            /*" -1262- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1263- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1264- MOVE LD02 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD02, REG_AC0041B.REG_AC0041BL);

            /*" -1266- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1268- ADD 04 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 04;

            /*" -1269- MOVE '-' TO REG-AC0041BC. */
            _.Move("-", REG_AC0041B.REG_AC0041BC);

            /*" -1270- MOVE LC13 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC13, REG_AC0041B.REG_AC0041BL);

            /*" -1272- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1273- MOVE '0' TO REG-AC0041BC. */
            _.Move("0", REG_AC0041B.REG_AC0041BC);

            /*" -1274- MOVE LC14 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC14, REG_AC0041B.REG_AC0041BL);

            /*" -1276- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1277- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1278- MOVE LC15 TO REG-AC0041BL. */
            _.Move(RELATORIO.LC15, REG_AC0041B.REG_AC0041BL);

            /*" -1280- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1281- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1282- MOVE LD03 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD03, REG_AC0041B.REG_AC0041BL);

            /*" -1284- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1286- ADD 07 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 07;

            /*" -1287- MOVE '-' TO REG-AC0041BC. */
            _.Move("-", REG_AC0041B.REG_AC0041BC);

            /*" -1288- MOVE LD04 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD04, REG_AC0041B.REG_AC0041BL);

            /*" -1290- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1291- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1292- MOVE LD05 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD05, REG_AC0041B.REG_AC0041BL);

            /*" -1294- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1295- MOVE '0' TO REG-AC0041BC. */
            _.Move("0", REG_AC0041B.REG_AC0041BC);

            /*" -1296- MOVE LD06 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD06, REG_AC0041B.REG_AC0041BL);

            /*" -1298- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1299- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1300- MOVE LD07 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD07, REG_AC0041B.REG_AC0041BL);

            /*" -1302- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1303- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1304- MOVE LD08 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD08, REG_AC0041B.REG_AC0041BL);

            /*" -1306- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1307- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1308- MOVE LD09 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD09, REG_AC0041B.REG_AC0041BL);

            /*" -1310- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1311- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1312- MOVE LD10 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD10, REG_AC0041B.REG_AC0041BL);

            /*" -1314- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1315- MOVE '0' TO REG-AC0041BC. */
            _.Move("0", REG_AC0041B.REG_AC0041BC);

            /*" -1316- MOVE LD11 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD11, REG_AC0041B.REG_AC0041BL);

            /*" -1318- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1318- ADD 12 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 12;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-IMPRIME-RECIBO-SECTION */
        private void R3200_00_IMPRIME_RECIBO_SECTION()
        {
            /*" -1331- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", WABEND.WNR_EXEC_SQL);

            /*" -1332- IF WTOT-CONG < ZEROS */

            if (AREA_DE_WORK.WTOT_CONG < 00)
            {

                /*" -1333- MOVE ZEROS TO WVLR-EXTENSO */
                _.Move(0, AREA_DE_WORK.WVLR_EXTENSO);

                /*" -1334- ELSE */
            }
            else
            {


                /*" -1336- MOVE WTOT-CONG TO WVLR-EXTENSO. */
                _.Move(AREA_DE_WORK.WTOT_CONG, AREA_DE_WORK.WVLR_EXTENSO);
            }


            /*" -1339- MOVE WVLR-EXTENSO TO WVALOR-LIQ LR03-TOTAL-LIQ. */
            _.Move(AREA_DE_WORK.WVLR_EXTENSO, WEXTENSO.WVALOR_LIQ, RELATORIO.LR03.LR03_TOTAL_LIQ);

            /*" -1344- CALL 'PROEXTE1' USING WVALOR-LIQ , WRESPOSTA , WAREA-1 , WAREA-2. */
            _.Call("PROEXTE1", WEXTENSO);

            /*" -1345- IF WRESPOSTA = 'SIM' */

            if (WEXTENSO.WRESPOSTA == "SIM")
            {

                /*" -1346- MOVE WLINHA-1 TO LR03-EXTENSO1 */
                _.Move(WEXTENSO.WAREA_1.WLINHA_1, RELATORIO.LR03.LR03_EXTENSO1);

                /*" -1347- MOVE WLINHA-2 TO LR04-EXTENSO2 */
                _.Move(WEXTENSO.WAREA_2.WLINHA_2, RELATORIO.LR04.LR04_EXTENSO2);

                /*" -1348- ELSE */
            }
            else
            {


                /*" -1349- MOVE SPACES TO LR03-EXTENSO1 */
                _.Move("", RELATORIO.LR03.LR03_EXTENSO1);

                /*" -1350- MOVE SPACES TO LR04-EXTENSO2 */
                _.Move("", RELATORIO.LR04.LR04_EXTENSO2);

                /*" -1353- DISPLAY 'TAMANHO INSUFICIENTE NA WORKING - VALOR - ' WVLR-EXTENSO. */
                _.Display($"TAMANHO INSUFICIENTE NA WORKING - VALOR - {AREA_DE_WORK.WVLR_EXTENSO}");
            }


            /*" -1354- MOVE '0' TO REG-AC0041BC. */
            _.Move("0", REG_AC0041B.REG_AC0041BC);

            /*" -1355- MOVE LR01 TO REG-AC0041BL. */
            _.Move(RELATORIO.LR01, REG_AC0041B.REG_AC0041BL);

            /*" -1357- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1358- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1359- MOVE LR02 TO REG-AC0041BL. */
            _.Move(RELATORIO.LR02, REG_AC0041B.REG_AC0041BL);

            /*" -1361- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1362- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1363- MOVE LR03 TO REG-AC0041BL. */
            _.Move(RELATORIO.LR03, REG_AC0041B.REG_AC0041BL);

            /*" -1365- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1366- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1367- MOVE LR04 TO REG-AC0041BL. */
            _.Move(RELATORIO.LR04, REG_AC0041B.REG_AC0041BL);

            /*" -1369- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1370- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1371- MOVE LR02 TO REG-AC0041BL. */
            _.Move(RELATORIO.LR02, REG_AC0041B.REG_AC0041BL);

            /*" -1373- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1374- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1375- MOVE LR02 TO REG-AC0041BL. */
            _.Move(RELATORIO.LR02, REG_AC0041B.REG_AC0041BL);

            /*" -1377- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1378- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1379- MOVE LR02 TO REG-AC0041BL. */
            _.Move(RELATORIO.LR02, REG_AC0041B.REG_AC0041BL);

            /*" -1381- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1382- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1383- MOVE LR05 TO REG-AC0041BL. */
            _.Move(RELATORIO.LR05, REG_AC0041B.REG_AC0041BL);

            /*" -1385- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1386- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1387- MOVE LR06 TO REG-AC0041BL. */
            _.Move(RELATORIO.LR06, REG_AC0041B.REG_AC0041BL);

            /*" -1389- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1390- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1391- MOVE LR02 TO REG-AC0041BL. */
            _.Move(RELATORIO.LR02, REG_AC0041B.REG_AC0041BL);

            /*" -1393- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1394- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1395- MOVE LR01 TO REG-AC0041BL. */
            _.Move(RELATORIO.LR01, REG_AC0041B.REG_AC0041BL);

            /*" -1397- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1397- ADD 12 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 12;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-IMPRIME-TOTAL-GERAL-SECTION */
        private void R4000_00_IMPRIME_TOTAL_GERAL_SECTION()
        {
            /*" -1410- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WABEND.WNR_EXEC_SQL);

            /*" -1411- MOVE ZEROS TO LC06-CONGENER. */
            _.Move(0, RELATORIO.LC06.LC06_CONGENER);

            /*" -1413- MOVE SPACES TO LC06-NOME-CONG. */
            _.Move("", RELATORIO.LC06.LC06_NOME_CONG);

            /*" -1415- PERFORM R3000-00-IMPRIME-CABECALHO. */

            R3000_00_IMPRIME_CABECALHO_SECTION();

            /*" -1420- COMPUTE WTOT-GERAL = WTOT-GER-PG - WTOT-GER-RC - WTOT-GER-DC - WTOT-GER-SD. */
            AREA_DE_WORK.WTOT_GERAL.Value = AREA_DE_WORK.WTOT_GER_PG - AREA_DE_WORK.WTOT_GER_RC - AREA_DE_WORK.WTOT_GER_DC - AREA_DE_WORK.WTOT_GER_SD;

            /*" -1421- MOVE WTOT-GER-SD TO LD06-TOT-SDANT. */
            _.Move(AREA_DE_WORK.WTOT_GER_SD, RELATORIO.LD06.LD06_TOT_SDANT);

            /*" -1422- MOVE WTOT-GER-PG TO LD07-TOT-PAGAR. */
            _.Move(AREA_DE_WORK.WTOT_GER_PG, RELATORIO.LD07.LD07_TOT_PAGAR);

            /*" -1423- MOVE WTOT-GER-RC TO LD08-TOT-RECUP. */
            _.Move(AREA_DE_WORK.WTOT_GER_RC, RELATORIO.LD08.LD08_TOT_RECUP);

            /*" -1424- MOVE WTOT-GER-DC TO LD09-TOT-DBECR. */
            _.Move(AREA_DE_WORK.WTOT_GER_DC, RELATORIO.LD09.LD09_TOT_DBECR);

            /*" -1426- MOVE WTOT-GERAL TO LD11-TOT-CONG. */
            _.Move(AREA_DE_WORK.WTOT_GERAL, RELATORIO.LD11.LD11_TOT_CONG);

            /*" -1429- MOVE SPACES TO LD10-NRCHEQUE LD11-NRCHEQUE. */
            _.Move("", RELATORIO.LD10.LD10_NRCHEQUE, RELATORIO.LD11.LD11_NRCHEQUE);

            /*" -1430- MOVE '-' TO REG-AC0041BC. */
            _.Move("-", REG_AC0041B.REG_AC0041BC);

            /*" -1431- MOVE SPACES TO REG-AC0041BL. */
            _.Move("", REG_AC0041B.REG_AC0041BL);

            /*" -1433- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1434- MOVE '0' TO REG-AC0041BC. */
            _.Move("0", REG_AC0041B.REG_AC0041BC);

            /*" -1435- MOVE LD04 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD04, REG_AC0041B.REG_AC0041BL);

            /*" -1437- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1438- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1439- MOVE LD05 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD05, REG_AC0041B.REG_AC0041BL);

            /*" -1441- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1442- MOVE '0' TO REG-AC0041BC. */
            _.Move("0", REG_AC0041B.REG_AC0041BC);

            /*" -1443- MOVE LD06 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD06, REG_AC0041B.REG_AC0041BL);

            /*" -1445- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1446- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1447- MOVE LD07 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD07, REG_AC0041B.REG_AC0041BL);

            /*" -1449- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1450- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1451- MOVE LD08 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD08, REG_AC0041B.REG_AC0041BL);

            /*" -1453- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1454- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1455- MOVE LD09 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD09, REG_AC0041B.REG_AC0041BL);

            /*" -1457- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1458- MOVE SPACES TO REG-AC0041BC. */
            _.Move("", REG_AC0041B.REG_AC0041BC);

            /*" -1459- MOVE LD10 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD10, REG_AC0041B.REG_AC0041BL);

            /*" -1461- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1462- MOVE '0' TO REG-AC0041BC. */
            _.Move("0", REG_AC0041B.REG_AC0041BC);

            /*" -1463- MOVE LD11 TO REG-AC0041BL. */
            _.Move(RELATORIO.LD11, REG_AC0041B.REG_AC0041BL);

            /*" -1465- WRITE REG-AC0041B. */
            RAC0041B.Write(REG_AC0041B.GetMoveValues().ToString());

            /*" -1465- ADD 14 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 14;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1478- CLOSE RAC0041B. */
            RAC0041B.Close();

            /*" -1480- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1482- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1482- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1486- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1486- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}