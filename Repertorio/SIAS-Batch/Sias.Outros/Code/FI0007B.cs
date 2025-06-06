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
using Sias.Outros.DB2.FI0007B;

namespace Code
{
    public class FI0007B
    {
        public bool IsCall { get; set; }

        public FI0007B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  FINANCEIRO                         *      */
        /*"      *   PROGRAMA ...............  FI0007B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CARLOS ALBERTO                     *      */
        /*"      *   PROGRAMADOR ............  CARLOS ALBERTO                     *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO / 1998                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ATUALIZA TABELA DE CHEQUES PARA    *      */
        /*"      *                             PAGAMENTOS DE COSSEGURO CEDIDO.    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * CONGENERES                          V1CONGENERE       INPUT    *      */
        /*"      * COSSEGURO CEDIDO CHEQUE             V0COSCED_CHEQUE   I-O      *      */
        /*"      * CHEQUES                             V0CHEQUES         OUTPUT   *      */
        /*"      * HISTORICO DE CHEQUES                V0HISTCHEQ        OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - SEGREGAR A GERACAO DO CHEQUE/PAGTO POR CODIGO DE  *      */
        /*"      *              EMPRESA DO GRUPO CAIXA SEGUROS E ATUALIZAR NA TAB.*      */
        /*"      *              CHEQUES EMITIDOS PARA ENVIO AO SAP                *      */
        /*"      * 16/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-CHQINT         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CHQINT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NUM-CHQINT      PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_NUM_CHQINT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SIST-DTMOVABE       PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMOVABE-FI    PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE_FI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CCHQ-COD-EMPR       PIC S9(009)             COMP.*/
        public IntBasis V0CCHQ_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CCHQ-CONGENER       PIC S9(004)             COMP.*/
        public IntBasis V0CCHQ_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CCHQ-DTMOVTO-AC     PIC X(010).*/
        public StringBasis V0CCHQ_DTMOVTO_AC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CCHQ-NRCHEQUE       PIC S9(009)             COMP.*/
        public IntBasis V0CCHQ_NRCHEQUE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CCHQ-DVCHEQUE       PIC S9(004)             COMP.*/
        public IntBasis V0CCHQ_DVCHEQUE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CCHQ-VLPREMIO       PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLRDESCON      PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VLRDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLRADIFRA      PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VLRADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLRCOMIS       PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VLRCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLRSINI        PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VLRSINI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLDESPESA      PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VLDESPESA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLRHONOR       PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VLRHONOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLRSALVD       PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VLRSALVD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLRESSARC      PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VLRESSARC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VALOR-EDI      PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VALOR_EDI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VALOR-USS      PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VALOR_USS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLEQPVNDA      PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VLEQPVNDA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLDESPADM      PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VLDESPADM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-OUTRDEBIT      PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_OUTRDEBIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-OUTRCREDT      PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_OUTRCREDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-VLRSLDANT      PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CCHQ_VLRSLDANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CCHQ-SITUACAO       PIC  X(001).*/
        public StringBasis V0CCHQ_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CONG-COD-CONG       PIC S9(004)             COMP.*/
        public IntBasis V1CONG_COD_CONG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CONG-NOMECONG       PIC  X(040).*/
        public StringBasis V1CONG_NOMECONG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0CHEQ-TPMOVTO        PIC  X(001).*/
        public StringBasis V0CHEQ_TPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CHEQ-FONTE          PIC S9(004)             COMP.*/
        public IntBasis V0CHEQ_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHEQ-NUMDOC         PIC  X(018).*/
        public StringBasis V0CHEQ_NUMDOC { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
        /*"77         V0CHEQ-NOMFAV         PIC  X(040).*/
        public StringBasis V0CHEQ_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0CHEQ-VALCHQ         PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CHEQ_VALCHQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHEQ-DTMOVTO        PIC  X(010).*/
        public StringBasis V0CHEQ_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CHEQ-DTEMIS         PIC  X(010).*/
        public StringBasis V0CHEQ_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CHEQ-CHQINT         PIC S9(009)             COMP.*/
        public IntBasis V0CHEQ_CHQINT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CHEQ-DIGINT         PIC S9(004)             COMP.*/
        public IntBasis V0CHEQ_DIGINT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHEQ-SITUACAO       PIC  X(001).*/
        public StringBasis V0CHEQ_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CHEQ-TIPPAG         PIC  X(001).*/
        public StringBasis V0CHEQ_TIPPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CHEQ-DATCMP         PIC  X(010).*/
        public StringBasis V0CHEQ_DATCMP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CHEQ-PRAPAG         PIC  X(020).*/
        public StringBasis V0CHEQ_PRAPAG { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77         V0CHEQ-NUMREC         PIC S9(009)             COMP.*/
        public IntBasis V0CHEQ_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CHEQ-OCORHIST       PIC S9(004)             COMP.*/
        public IntBasis V0CHEQ_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHEQ-OPERACAO       PIC S9(004)             COMP.*/
        public IntBasis V0CHEQ_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHEQ-CODDSA         PIC S9(004)             COMP.*/
        public IntBasis V0CHEQ_CODDSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHEQ-VALIRF         PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CHEQ_VALIRF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHEQ-VALISS         PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CHEQ_VALISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHEQ-VALIAP         PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CHEQ_VALIAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHEQ-CODLAN         PIC S9(004)             COMP.*/
        public IntBasis V0CHEQ_CODLAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHEQ-DATLAN         PIC  X(010).*/
        public StringBasis V0CHEQ_DATLAN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CHEQ-EMPRESA        PIC S9(009)             COMP.*/
        public IntBasis V0CHEQ_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CHEQ-CODFAV         PIC S9(009)             COMP.*/
        public IntBasis V0CHEQ_CODFAV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CHEQ-VALINSS        PIC S9(013)V99          COMP-3.*/
        public DoubleBasis V0CHEQ_VALINSS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HCHE-CHQINT         PIC S9(009)             COMP.*/
        public IntBasis V0HCHE_CHQINT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HCHE-DIGINT         PIC S9(004)             COMP.*/
        public IntBasis V0HCHE_DIGINT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HCHE-DTMOVTO        PIC  X(010).*/
        public StringBasis V0HCHE_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HCHE-HORAOPER       PIC  X(008).*/
        public StringBasis V0HCHE_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HCHE-OPERACAO       PIC S9(004)             COMP.*/
        public IntBasis V0HCHE_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HCHE-EMPRESA        PIC S9(009)             COMP.*/
        public IntBasis V0HCHE_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HCHE-DTCOMPSA       PIC  X(010).*/
        public StringBasis V0HCHE_DTCOMPSA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         AREA-DE-WORK.*/
        public FI0007B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new FI0007B_AREA_DE_WORK();
        public class FI0007B_AREA_DE_WORK : VarBasis
        {
            /*"  05       WFIM-COSCED-CHEQUE    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_COSCED_CHEQUE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       AC-L-COSCED-CHEQUE    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_COSCED_CHEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-I-V0CHEQUES        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0CHEQUES { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-I-V0HISTCHEQ       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0HISTCHEQ { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       AC-U-V0COSCEDCHQ      PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_U_V0COSCEDCHQ { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05       WPARM01-AUX           PIC S9(009)    VALUE +0 COMP.*/
            public IntBasis WPARM01_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WQUOCIENTE            PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WRESTO                PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WVLR-CHEQUE           PIC S9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WVLR_CHEQUE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05       WNUM-CHEQUE           PIC S9(009)    VALUE +0 COMP.*/
            public IntBasis WNUM_CHEQUE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WDIG-CHEQUE           PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WDIG_CHEQUE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WK-HORA-1.*/
            public FI0007B_WK_HORA_1 WK_HORA_1 { get; set; } = new FI0007B_WK_HORA_1();
            public class FI0007B_WK_HORA_1 : VarBasis
            {
                /*"    10     WK-HH-1               PIC 9(002)     VALUE ZEROS.*/
                public IntBasis WK_HH_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WK-MM-1               PIC 9(002)     VALUE ZEROS.*/
                public IntBasis WK_MM_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WK-SS-1               PIC 9(002)     VALUE ZEROS.*/
                public IntBasis WK_SS_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WK-CC-1               PIC 9(002)     VALUE ZEROS.*/
                public IntBasis WK_CC_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05       WK-HORA-2.*/
            }
            public FI0007B_WK_HORA_2 WK_HORA_2 { get; set; } = new FI0007B_WK_HORA_2();
            public class FI0007B_WK_HORA_2 : VarBasis
            {
                /*"    10     WK-HH-2               PIC 9(002)     VALUE ZEROS.*/
                public IntBasis WK_HH_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     FILLER                PIC X(001)     VALUE '.'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10     WK-MM-2               PIC 9(002)     VALUE ZEROS.*/
                public IntBasis WK_MM_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     FILLER                PIC X(001)     VALUE '.'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10     WK-SS-2               PIC 9(002)     VALUE ZEROS.*/
                public IntBasis WK_SS_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01         LPARM01X.*/
            }
        }
        public FI0007B_LPARM01X LPARM01X { get; set; } = new FI0007B_LPARM01X();
        public class FI0007B_LPARM01X : VarBasis
        {
            /*"  05       LPARM01               PIC  9(015).*/
            public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       LPARM01-R             REDEFINES      LPARM01.*/
            private _REDEF_FI0007B_LPARM01_R _lparm01_r { get; set; }
            public _REDEF_FI0007B_LPARM01_R LPARM01_R
            {
                get { _lparm01_r = new _REDEF_FI0007B_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
                set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
            }  //Redefines
            public class _REDEF_FI0007B_LPARM01_R : VarBasis
            {
                /*"    10     LPARM01-1             PIC  9(001).*/
                public IntBasis LPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-2             PIC  9(001).*/
                public IntBasis LPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-3             PIC  9(001).*/
                public IntBasis LPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-4             PIC  9(001).*/
                public IntBasis LPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-5             PIC  9(001).*/
                public IntBasis LPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-6             PIC  9(001).*/
                public IntBasis LPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-7             PIC  9(001).*/
                public IntBasis LPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-8             PIC  9(001).*/
                public IntBasis LPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-9             PIC  9(001).*/
                public IntBasis LPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-10            PIC  9(001).*/
                public IntBasis LPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-11            PIC  9(001).*/
                public IntBasis LPARM01_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-12            PIC  9(001).*/
                public IntBasis LPARM01_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-13            PIC  9(001).*/
                public IntBasis LPARM01_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-14            PIC  9(001).*/
                public IntBasis LPARM01_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10     LPARM01-15            PIC  9(001).*/
                public IntBasis LPARM01_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05       LPARM02               PIC S9(004)    COMP.*/

                public _REDEF_FI0007B_LPARM01_R()
                {
                    LPARM01_1.ValueChanged += OnValueChanged;
                    LPARM01_2.ValueChanged += OnValueChanged;
                    LPARM01_3.ValueChanged += OnValueChanged;
                    LPARM01_4.ValueChanged += OnValueChanged;
                    LPARM01_5.ValueChanged += OnValueChanged;
                    LPARM01_6.ValueChanged += OnValueChanged;
                    LPARM01_7.ValueChanged += OnValueChanged;
                    LPARM01_8.ValueChanged += OnValueChanged;
                    LPARM01_9.ValueChanged += OnValueChanged;
                    LPARM01_10.ValueChanged += OnValueChanged;
                    LPARM01_11.ValueChanged += OnValueChanged;
                    LPARM01_12.ValueChanged += OnValueChanged;
                    LPARM01_13.ValueChanged += OnValueChanged;
                    LPARM01_14.ValueChanged += OnValueChanged;
                    LPARM01_15.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       LPARM03               PIC  9(001).*/
            public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05       LPARM03-R             REDEFINES      LPARM03                                 PIC  X(001).*/
            private _REDEF_StringBasis _lparm03_r { get; set; }
            public _REDEF_StringBasis LPARM03_R
            {
                get { _lparm03_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM03, _lparm03_r); VarBasis.RedefinePassValue(LPARM03, _lparm03_r, LPARM03); _lparm03_r.ValueChanged += () => { _.Move(_lparm03_r, LPARM03); }; return _lparm03_r; }
                set { VarBasis.RedefinePassValue(value, _lparm03_r, LPARM03); }
            }  //Redefines
            /*"01         WABEND.*/
        }
        public FI0007B_WABEND WABEND { get; set; } = new FI0007B_WABEND();
        public class FI0007B_WABEND : VarBasis
        {
            /*"  05       FILLER                PIC  X(009)     VALUE          'FI0007B '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FI0007B ");
            /*"  05       FILLER                PIC  X(035)     VALUE          ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
            /*"  05       WNR-EXEC-SQL          PIC  X(003)     VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05       FILLER                PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05       WSQLCODE              PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }


        public FI0007B_COSCEDCHEQUE COSCEDCHEQUE { get; set; } = new FI0007B_COSCEDCHEQUE();
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
            /*" -250- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -251- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -254- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -257- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -261- PERFORM R0100-00-SELECT-V1SISTEMA-AC. */

            R0100_00_SELECT_V1SISTEMA_AC_SECTION();

            /*" -263- PERFORM R0150-00-SELECT-V1SISTEMA-FI. */

            R0150_00_SELECT_V1SISTEMA_FI_SECTION();

            /*" -264- IF V1SIST-DTMOVABE-FI NOT EQUAL V1SIST-DTMOVABE */

            if (V1SIST_DTMOVABE_FI != V1SIST_DTMOVABE)
            {

                /*" -265- DISPLAY 'R0000 - DATA DO SISTEMA FI DIFERE DO AC' */
                _.Display($"R0000 - DATA DO SISTEMA FI DIFERE DO AC");

                /*" -266- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -268- END-IF. */
            }


            /*" -270- PERFORM R0900-00-DECLARE-COSCED-CHEQUE. */

            R0900_00_DECLARE_COSCED_CHEQUE_SECTION();

            /*" -272- PERFORM R0950-00-FETCH-COSCED-CHEQUE. */

            R0950_00_FETCH_COSCED_CHEQUE_SECTION();

            /*" -273- IF WFIM-COSCED-CHEQUE NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_COSCED_CHEQUE.IsEmpty())
            {

                /*" -274- DISPLAY '*------------------------------*' */
                _.Display($"*------------------------------*");

                /*" -275- DISPLAY 'SEM MOVIMENTO PARA PROCESSAMENTO' */
                _.Display($"SEM MOVIMENTO PARA PROCESSAMENTO");

                /*" -276- DISPLAY '*------------------------------*' */
                _.Display($"*------------------------------*");

                /*" -277- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA(); //GOTO
                return;

                /*" -278- ELSE */
            }
            else
            {


                /*" -279- MOVE ZEROS TO WHOST-NUM-CHQINT */
                _.Move(0, WHOST_NUM_CHQINT);

                /*" -281- END-IF. */
            }


            /*" -283- PERFORM R0200-00-SELECT-V1CHEQUES. */

            R0200_00_SELECT_V1CHEQUES_SECTION();

            /*" -286- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-COSCED-CHEQUE NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_COSCED_CHEQUE.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -287- DISPLAY '* DOCUMENTOS LIDOS ...: ' AC-L-COSCED-CHEQUE. */
            _.Display($"* DOCUMENTOS LIDOS ...: {AREA_DE_WORK.AC_L_COSCED_CHEQUE}");

            /*" -288- DISPLAY ' ' . */
            _.Display($" ");

            /*" -289- DISPLAY '* CHEQUES INSERIDOS ..: ' AC-I-V0CHEQUES. */
            _.Display($"* CHEQUES INSERIDOS ..: {AREA_DE_WORK.AC_I_V0CHEQUES}");

            /*" -290- DISPLAY ' ' . */
            _.Display($" ");

            /*" -291- DISPLAY '* HST CHQ INSERIDOS ..: ' AC-I-V0HISTCHEQ. */
            _.Display($"* HST CHQ INSERIDOS ..: {AREA_DE_WORK.AC_I_V0HISTCHEQ}");

            /*" -292- DISPLAY ' ' . */
            _.Display($" ");

            /*" -293- DISPLAY '* COS CHQ ALTERADOS ..: ' AC-U-V0COSCEDCHQ. */
            _.Display($"* COS CHQ ALTERADOS ..: {AREA_DE_WORK.AC_U_V0COSCEDCHQ}");

            /*" -293- DISPLAY ' ' . */
            _.Display($" ");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -299- DISPLAY 'FI0007B - FIM NORMAL' . */
            _.Display($"FI0007B - FIM NORMAL");

            /*" -299- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -303- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -303- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-AC-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_AC_SECTION()
        {
            /*" -316- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -321- PERFORM R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1();

            /*" -324- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -325- DISPLAY 'R0100 - SISTEMA ADM. COSSG NAO CADASTRADO' */
                _.Display($"R0100 - SISTEMA ADM. COSSG NAO CADASTRADO");

                /*" -326- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -327- ELSE */
            }
            else
            {


                /*" -328- DISPLAY 'DATA DO SISTEMA AC - ' V1SIST-DTMOVABE */
                _.Display($"DATA DO SISTEMA AC - {V1SIST_DTMOVABE}");

                /*" -328- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-AC-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1()
        {
            /*" -321- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'AC' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_AC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-SELECT-V1SISTEMA-FI-SECTION */
        private void R0150_00_SELECT_V1SISTEMA_FI_SECTION()
        {
            /*" -341- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", WABEND.WNR_EXEC_SQL);

            /*" -346- PERFORM R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1 */

            R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1();

            /*" -349- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -350- DISPLAY 'R0150 - SISTEMA FINANCEIRO NAO CADASTRADO' */
                _.Display($"R0150 - SISTEMA FINANCEIRO NAO CADASTRADO");

                /*" -351- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -352- ELSE */
            }
            else
            {


                /*" -353- DISPLAY 'DATA DO SISTEMA FI - ' V1SIST-DTMOVABE-FI */
                _.Display($"DATA DO SISTEMA FI - {V1SIST_DTMOVABE_FI}");

                /*" -353- END-IF. */
            }


        }

        [StopWatch]
        /*" R0150-00-SELECT-V1SISTEMA-FI-DB-SELECT-1 */
        public void R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1()
        {
            /*" -346- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE-FI FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'FI' END-EXEC. */

            var r0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1 = new R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1.Execute(r0150_00_SELECT_V1SISTEMA_FI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE_FI, V1SIST_DTMOVABE_FI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V1CHEQUES-SECTION */
        private void R0200_00_SELECT_V1CHEQUES_SECTION()
        {
            /*" -366- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -370- PERFORM R0200_00_SELECT_V1CHEQUES_DB_SELECT_1 */

            R0200_00_SELECT_V1CHEQUES_DB_SELECT_1();

            /*" -373- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -374- DISPLAY 'R0200 - ERRO NO SELECT DA V1CHEQUES' */
                _.Display($"R0200 - ERRO NO SELECT DA V1CHEQUES");

                /*" -375- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -376- ELSE */
            }
            else
            {


                /*" -377- IF VIND-CHQINT LESS ZEROS */

                if (VIND_CHQINT < 00)
                {

                    /*" -378- MOVE ZEROS TO WHOST-NUM-CHQINT */
                    _.Move(0, WHOST_NUM_CHQINT);

                    /*" -379- END-IF */
                }


                /*" -381- END-IF. */
            }


            /*" -381- MOVE WHOST-NUM-CHQINT TO WNUM-CHEQUE. */
            _.Move(WHOST_NUM_CHQINT, AREA_DE_WORK.WNUM_CHEQUE);

        }

        [StopWatch]
        /*" R0200-00-SELECT-V1CHEQUES-DB-SELECT-1 */
        public void R0200_00_SELECT_V1CHEQUES_DB_SELECT_1()
        {
            /*" -370- EXEC SQL SELECT MAX(CHQINT) INTO :WHOST-NUM-CHQINT:VIND-CHQINT FROM SEGUROS.V1CHEQUES END-EXEC. */

            var r0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1 = new R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V1CHEQUES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NUM_CHQINT, WHOST_NUM_CHQINT);
                _.Move(executed_1.VIND_CHQINT, VIND_CHQINT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-COSCED-CHEQUE-SECTION */
        private void R0900_00_DECLARE_COSCED_CHEQUE_SECTION()
        {
            /*" -394- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -419- PERFORM R0900_00_DECLARE_COSCED_CHEQUE_DB_DECLARE_1 */

            R0900_00_DECLARE_COSCED_CHEQUE_DB_DECLARE_1();

            /*" -421- PERFORM R0900_00_DECLARE_COSCED_CHEQUE_DB_OPEN_1 */

            R0900_00_DECLARE_COSCED_CHEQUE_DB_OPEN_1();

            /*" -424- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -425- DISPLAY 'R0900 - ERRO NO DECLARE DA V0COSCED_CHEQUE' */
                _.Display($"R0900 - ERRO NO DECLARE DA V0COSCED_CHEQUE");

                /*" -426- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -427- ELSE */
            }
            else
            {


                /*" -428- MOVE SPACES TO WFIM-COSCED-CHEQUE */
                _.Move("", AREA_DE_WORK.WFIM_COSCED_CHEQUE);

                /*" -428- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-COSCED-CHEQUE-DB-DECLARE-1 */
        public void R0900_00_DECLARE_COSCED_CHEQUE_DB_DECLARE_1()
        {
            /*" -419- EXEC SQL DECLARE COSCEDCHEQUE CURSOR FOR SELECT COD_EMPRESA, CONGENER, DTMOVTO_AC, VLPREMIO, VLRDESCON, VLRADIFRA, VLRCOMIS, VLRSINI, VLDESPESA, VLRHONOR, VLRSALVD, VLRESSARC, VALOR_EDI, VALOR_USS, VLEQPVNDA, VLDESPADM, OUTRDEBIT, OUTRCREDT, VLRSLDANT FROM SEGUROS.V0COSCED_CHEQUE WHERE DTMOVTO_FI = :V1SIST-DTMOVABE-FI AND SITUACAO = '0' ORDER BY COD_EMPRESA, CONGENER END-EXEC. */
            COSCEDCHEQUE = new FI0007B_COSCEDCHEQUE(true);
            string GetQuery_COSCEDCHEQUE()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							CONGENER
							, 
							DTMOVTO_AC
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
							FROM SEGUROS.V0COSCED_CHEQUE 
							WHERE DTMOVTO_FI = '{V1SIST_DTMOVABE_FI}' 
							AND SITUACAO = '0' 
							ORDER BY COD_EMPRESA
							, 
							CONGENER";

                return query;
            }
            COSCEDCHEQUE.GetQueryEvent += GetQuery_COSCEDCHEQUE;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-COSCED-CHEQUE-DB-OPEN-1 */
        public void R0900_00_DECLARE_COSCED_CHEQUE_DB_OPEN_1()
        {
            /*" -421- EXEC SQL OPEN COSCEDCHEQUE END-EXEC. */

            COSCEDCHEQUE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-FETCH-COSCED-CHEQUE-SECTION */
        private void R0950_00_FETCH_COSCED_CHEQUE_SECTION()
        {
            /*" -441- MOVE '095' TO WNR-EXEC-SQL. */
            _.Move("095", WABEND.WNR_EXEC_SQL);

            /*" -461- PERFORM R0950_00_FETCH_COSCED_CHEQUE_DB_FETCH_1 */

            R0950_00_FETCH_COSCED_CHEQUE_DB_FETCH_1();

            /*" -464- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -465- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -466- MOVE 'S' TO WFIM-COSCED-CHEQUE */
                    _.Move("S", AREA_DE_WORK.WFIM_COSCED_CHEQUE);

                    /*" -466- PERFORM R0950_00_FETCH_COSCED_CHEQUE_DB_CLOSE_1 */

                    R0950_00_FETCH_COSCED_CHEQUE_DB_CLOSE_1();

                    /*" -468- ELSE */
                }
                else
                {


                    /*" -469- DISPLAY 'R0950 - ERRO NO FETCH DA V0COSCED_CHEQUE' */
                    _.Display($"R0950 - ERRO NO FETCH DA V0COSCED_CHEQUE");

                    /*" -470- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -471- END-IF */
                }


                /*" -472- ELSE */
            }
            else
            {


                /*" -473- ADD 1 TO AC-L-COSCED-CHEQUE */
                AREA_DE_WORK.AC_L_COSCED_CHEQUE.Value = AREA_DE_WORK.AC_L_COSCED_CHEQUE + 1;

                /*" -473- END-IF. */
            }


        }

        [StopWatch]
        /*" R0950-00-FETCH-COSCED-CHEQUE-DB-FETCH-1 */
        public void R0950_00_FETCH_COSCED_CHEQUE_DB_FETCH_1()
        {
            /*" -461- EXEC SQL FETCH COSCEDCHEQUE INTO :V0CCHQ-COD-EMPR, :V0CCHQ-CONGENER, :V0CCHQ-DTMOVTO-AC, :V0CCHQ-VLPREMIO, :V0CCHQ-VLRDESCON, :V0CCHQ-VLRADIFRA, :V0CCHQ-VLRCOMIS, :V0CCHQ-VLRSINI, :V0CCHQ-VLDESPESA, :V0CCHQ-VLRHONOR, :V0CCHQ-VLRSALVD, :V0CCHQ-VLRESSARC, :V0CCHQ-VALOR-EDI, :V0CCHQ-VALOR-USS, :V0CCHQ-VLEQPVNDA, :V0CCHQ-VLDESPADM, :V0CCHQ-OUTRDEBIT, :V0CCHQ-OUTRCREDT, :V0CCHQ-VLRSLDANT END-EXEC. */

            if (COSCEDCHEQUE.Fetch())
            {
                _.Move(COSCEDCHEQUE.V0CCHQ_COD_EMPR, V0CCHQ_COD_EMPR);
                _.Move(COSCEDCHEQUE.V0CCHQ_CONGENER, V0CCHQ_CONGENER);
                _.Move(COSCEDCHEQUE.V0CCHQ_DTMOVTO_AC, V0CCHQ_DTMOVTO_AC);
                _.Move(COSCEDCHEQUE.V0CCHQ_VLPREMIO, V0CCHQ_VLPREMIO);
                _.Move(COSCEDCHEQUE.V0CCHQ_VLRDESCON, V0CCHQ_VLRDESCON);
                _.Move(COSCEDCHEQUE.V0CCHQ_VLRADIFRA, V0CCHQ_VLRADIFRA);
                _.Move(COSCEDCHEQUE.V0CCHQ_VLRCOMIS, V0CCHQ_VLRCOMIS);
                _.Move(COSCEDCHEQUE.V0CCHQ_VLRSINI, V0CCHQ_VLRSINI);
                _.Move(COSCEDCHEQUE.V0CCHQ_VLDESPESA, V0CCHQ_VLDESPESA);
                _.Move(COSCEDCHEQUE.V0CCHQ_VLRHONOR, V0CCHQ_VLRHONOR);
                _.Move(COSCEDCHEQUE.V0CCHQ_VLRSALVD, V0CCHQ_VLRSALVD);
                _.Move(COSCEDCHEQUE.V0CCHQ_VLRESSARC, V0CCHQ_VLRESSARC);
                _.Move(COSCEDCHEQUE.V0CCHQ_VALOR_EDI, V0CCHQ_VALOR_EDI);
                _.Move(COSCEDCHEQUE.V0CCHQ_VALOR_USS, V0CCHQ_VALOR_USS);
                _.Move(COSCEDCHEQUE.V0CCHQ_VLEQPVNDA, V0CCHQ_VLEQPVNDA);
                _.Move(COSCEDCHEQUE.V0CCHQ_VLDESPADM, V0CCHQ_VLDESPADM);
                _.Move(COSCEDCHEQUE.V0CCHQ_OUTRDEBIT, V0CCHQ_OUTRDEBIT);
                _.Move(COSCEDCHEQUE.V0CCHQ_OUTRCREDT, V0CCHQ_OUTRCREDT);
                _.Move(COSCEDCHEQUE.V0CCHQ_VLRSLDANT, V0CCHQ_VLRSLDANT);
            }

        }

        [StopWatch]
        /*" R0950-00-FETCH-COSCED-CHEQUE-DB-CLOSE-1 */
        public void R0950_00_FETCH_COSCED_CHEQUE_DB_CLOSE_1()
        {
            /*" -466- EXEC SQL CLOSE COSCEDCHEQUE END-EXEC */

            COSCEDCHEQUE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -486- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -490- MOVE ZEROS TO WVLR-CHEQUE V0CCHQ-NRCHEQUE V0CCHQ-DVCHEQUE. */
            _.Move(0, AREA_DE_WORK.WVLR_CHEQUE, V0CCHQ_NRCHEQUE, V0CCHQ_DVCHEQUE);

            /*" -492- PERFORM R1300-00-SELECT-V1CONGENERE. */

            R1300_00_SELECT_V1CONGENERE_SECTION();

            /*" -509- COMPUTE WVLR-CHEQUE = V0CCHQ-VLPREMIO - V0CCHQ-VLRDESCON + V0CCHQ-VLRADIFRA - V0CCHQ-VLRCOMIS - V0CCHQ-VLRSINI - V0CCHQ-VLDESPESA - V0CCHQ-VLRHONOR + V0CCHQ-VLRSALVD + V0CCHQ-VLRESSARC - V0CCHQ-VALOR-EDI - V0CCHQ-VALOR-USS - V0CCHQ-VLEQPVNDA - V0CCHQ-VLDESPADM - V0CCHQ-OUTRDEBIT + V0CCHQ-OUTRCREDT - V0CCHQ-VLRSLDANT. */
            AREA_DE_WORK.WVLR_CHEQUE.Value = V0CCHQ_VLPREMIO - V0CCHQ_VLRDESCON + V0CCHQ_VLRADIFRA - V0CCHQ_VLRCOMIS - V0CCHQ_VLRSINI - V0CCHQ_VLDESPESA - V0CCHQ_VLRHONOR + V0CCHQ_VLRSALVD + V0CCHQ_VLRESSARC - V0CCHQ_VALOR_EDI - V0CCHQ_VALOR_USS - V0CCHQ_VLEQPVNDA - V0CCHQ_VLDESPADM - V0CCHQ_OUTRDEBIT + V0CCHQ_OUTRCREDT - V0CCHQ_VLRSLDANT;

            /*" -510- IF WVLR-CHEQUE GREATER ZEROS */

            if (AREA_DE_WORK.WVLR_CHEQUE > 00)
            {

                /*" -512- PERFORM R1500-00-CALCULA-DIGITO */

                R1500_00_CALCULA_DIGITO_SECTION();

                /*" -514- PERFORM R1600-00-MONTA-V0CHEQUES */

                R1600_00_MONTA_V0CHEQUES_SECTION();

                /*" -516- PERFORM R1700-00-MONTA-V0HISTCHEQ */

                R1700_00_MONTA_V0HISTCHEQ_SECTION();

                /*" -518- PERFORM R2000-00-INSERE-V0CHEQUES */

                R2000_00_INSERE_V0CHEQUES_SECTION();

                /*" -519- PERFORM R2100-00-INSERE-V0HISTCHEQ */

                R2100_00_INSERE_V0HISTCHEQ_SECTION();

                /*" -521- END-IF. */
            }


            /*" -523- PERFORM R2200-00-UPDATE-COSCED-CHEQUE. */

            R2200_00_UPDATE_COSCED_CHEQUE_SECTION();

            /*" -523- PERFORM R0950-00-FETCH-COSCED-CHEQUE. */

            R0950_00_FETCH_COSCED_CHEQUE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V1CONGENERE-SECTION */
        private void R1300_00_SELECT_V1CONGENERE_SECTION()
        {
            /*" -536- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -541- PERFORM R1300_00_SELECT_V1CONGENERE_DB_SELECT_1 */

            R1300_00_SELECT_V1CONGENERE_DB_SELECT_1();

            /*" -544- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -545- DISPLAY 'R1300 - ERRO NO SELECT DA V1CONGENERE' */
                _.Display($"R1300 - ERRO NO SELECT DA V1CONGENERE");

                /*" -546- DISPLAY 'CONGENERE - ' V0CCHQ-CONGENER */
                _.Display($"CONGENERE - {V0CCHQ_CONGENER}");

                /*" -547- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -547- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V1CONGENERE-DB-SELECT-1 */
        public void R1300_00_SELECT_V1CONGENERE_DB_SELECT_1()
        {
            /*" -541- EXEC SQL SELECT NOMECONG INTO :V1CONG-NOMECONG FROM SEGUROS.V1CONGENERE WHERE CONGENER = :V0CCHQ-CONGENER END-EXEC. */

            var r1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1 = new R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1()
            {
                V0CCHQ_CONGENER = V0CCHQ_CONGENER.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V1CONGENERE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CONG_NOMECONG, V1CONG_NOMECONG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-CALCULA-DIGITO-SECTION */
        private void R1500_00_CALCULA_DIGITO_SECTION()
        {
            /*" -560- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -562- ADD 1 TO WNUM-CHEQUE. */
            AREA_DE_WORK.WNUM_CHEQUE.Value = AREA_DE_WORK.WNUM_CHEQUE + 1;

            /*" -564- MOVE WNUM-CHEQUE TO LPARM01. */
            _.Move(AREA_DE_WORK.WNUM_CHEQUE, LPARM01X.LPARM01);

            /*" -580- COMPUTE WPARM01-AUX = LPARM01-1 * 8 + LPARM01-2 * 7 + LPARM01-3 * 6 + LPARM01-4 * 5 + LPARM01-5 * 4 + LPARM01-6 * 3 + LPARM01-7 * 2 + LPARM01-8 * 9 + LPARM01-9 * 8 + LPARM01-10 * 7 + LPARM01-11 * 6 + LPARM01-12 * 5 + LPARM01-13 * 4 + LPARM01-14 * 3 + LPARM01-15 * 2. */
            AREA_DE_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_1 * 8 + LPARM01X.LPARM01_R.LPARM01_2 * 7 + LPARM01X.LPARM01_R.LPARM01_3 * 6 + LPARM01X.LPARM01_R.LPARM01_4 * 5 + LPARM01X.LPARM01_R.LPARM01_5 * 4 + LPARM01X.LPARM01_R.LPARM01_6 * 3 + LPARM01X.LPARM01_R.LPARM01_7 * 2 + LPARM01X.LPARM01_R.LPARM01_8 * 9 + LPARM01X.LPARM01_R.LPARM01_9 * 8 + LPARM01X.LPARM01_R.LPARM01_10 * 7 + LPARM01X.LPARM01_R.LPARM01_11 * 6 + LPARM01X.LPARM01_R.LPARM01_12 * 5 + LPARM01X.LPARM01_R.LPARM01_13 * 4 + LPARM01X.LPARM01_R.LPARM01_14 * 3 + LPARM01X.LPARM01_R.LPARM01_15 * 2;

            /*" -583- DIVIDE WPARM01-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO. */
            _.Divide(AREA_DE_WORK.WPARM01_AUX, 11, AREA_DE_WORK.WQUOCIENTE, AREA_DE_WORK.WRESTO);

            /*" -584- IF WRESTO EQUAL 1 */

            if (AREA_DE_WORK.WRESTO == 1)
            {

                /*" -585- MOVE 0 TO LPARM03 */
                _.Move(0, LPARM01X.LPARM03);

                /*" -586- ELSE */
            }
            else
            {


                /*" -587- IF WRESTO EQUAL ZEROS */

                if (AREA_DE_WORK.WRESTO == 00)
                {

                    /*" -588- MOVE 1 TO LPARM03 */
                    _.Move(1, LPARM01X.LPARM03);

                    /*" -589- ELSE */
                }
                else
                {


                    /*" -591- SUBTRACT WRESTO FROM 11 GIVING LPARM03 */
                    LPARM01X.LPARM03.Value = 11 - AREA_DE_WORK.WRESTO;

                    /*" -592- END-IF */
                }


                /*" -594- END-IF. */
            }


            /*" -594- MOVE LPARM03 TO WDIG-CHEQUE. */
            _.Move(LPARM01X.LPARM03, AREA_DE_WORK.WDIG_CHEQUE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-MONTA-V0CHEQUES-SECTION */
        private void R1600_00_MONTA_V0CHEQUES_SECTION()
        {
            /*" -607- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", WABEND.WNR_EXEC_SQL);

            /*" -608- MOVE '6' TO V0CHEQ-TPMOVTO. */
            _.Move("6", V0CHEQ_TPMOVTO);

            /*" -609- MOVE V0CCHQ-CONGENER TO V0CHEQ-FONTE. */
            _.Move(V0CCHQ_CONGENER, V0CHEQ_FONTE);

            /*" -610- MOVE 'FI0007B' TO V0CHEQ-NUMDOC. */
            _.Move("FI0007B", V0CHEQ_NUMDOC);

            /*" -612- MOVE V1CONG-NOMECONG TO V0CHEQ-NOMFAV. */
            _.Move(V1CONG_NOMECONG, V0CHEQ_NOMFAV);

            /*" -613- MOVE WVLR-CHEQUE TO V0CHEQ-VALCHQ. */
            _.Move(AREA_DE_WORK.WVLR_CHEQUE, V0CHEQ_VALCHQ);

            /*" -614- MOVE V1SIST-DTMOVABE-FI TO V0CHEQ-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE_FI, V0CHEQ_DTMOVTO);

            /*" -616- MOVE SPACES TO V0CHEQ-DTEMIS. */
            _.Move("", V0CHEQ_DTEMIS);

            /*" -619- MOVE WNUM-CHEQUE TO V0CHEQ-CHQINT V0CCHQ-NRCHEQUE. */
            _.Move(AREA_DE_WORK.WNUM_CHEQUE, V0CHEQ_CHQINT, V0CCHQ_NRCHEQUE);

            /*" -622- MOVE WDIG-CHEQUE TO V0CHEQ-DIGINT V0CCHQ-DVCHEQUE. */
            _.Move(AREA_DE_WORK.WDIG_CHEQUE, V0CHEQ_DIGINT, V0CCHQ_DVCHEQUE);

            /*" -623- MOVE '0' TO V0CHEQ-SITUACAO. */
            _.Move("0", V0CHEQ_SITUACAO);

            /*" -624- MOVE '1' TO V0CHEQ-TIPPAG. */
            _.Move("1", V0CHEQ_TIPPAG);

            /*" -626- MOVE V0CCHQ-DTMOVTO-AC TO V0CHEQ-DATCMP. */
            _.Move(V0CCHQ_DTMOVTO_AC, V0CHEQ_DATCMP);

            /*" -627- MOVE SPACES TO V0CHEQ-PRAPAG. */
            _.Move("", V0CHEQ_PRAPAG);

            /*" -628- MOVE ZEROS TO V0CHEQ-NUMREC. */
            _.Move(0, V0CHEQ_NUMREC);

            /*" -629- MOVE 01 TO V0CHEQ-OCORHIST. */
            _.Move(01, V0CHEQ_OCORHIST);

            /*" -630- MOVE 0101 TO V0CHEQ-OPERACAO. */
            _.Move(0101, V0CHEQ_OPERACAO);

            /*" -632- MOVE 1304 TO V0CHEQ-CODDSA. */
            _.Move(1304, V0CHEQ_CODDSA);

            /*" -633- MOVE ZEROS TO V0CHEQ-VALIRF. */
            _.Move(0, V0CHEQ_VALIRF);

            /*" -634- MOVE ZEROS TO V0CHEQ-VALISS. */
            _.Move(0, V0CHEQ_VALISS);

            /*" -635- MOVE ZEROS TO V0CHEQ-VALIAP. */
            _.Move(0, V0CHEQ_VALIAP);

            /*" -637- MOVE ZEROS TO V0CHEQ-CODLAN. */
            _.Move(0, V0CHEQ_CODLAN);

            /*" -641- MOVE V1SIST-DTMOVABE-FI TO V0CHEQ-DATLAN. */
            _.Move(V1SIST_DTMOVABE_FI, V0CHEQ_DATLAN);

            /*" -643- MOVE V0CCHQ-COD-EMPR TO V0CHEQ-EMPRESA. */
            _.Move(V0CCHQ_COD_EMPR, V0CHEQ_EMPRESA);

            /*" -645- MOVE V0CCHQ-CONGENER TO V0CHEQ-CODFAV. */
            _.Move(V0CCHQ_CONGENER, V0CHEQ_CODFAV);

            /*" -645- MOVE ZEROS TO V0CHEQ-VALINSS. */
            _.Move(0, V0CHEQ_VALINSS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-MONTA-V0HISTCHEQ-SECTION */
        private void R1700_00_MONTA_V0HISTCHEQ_SECTION()
        {
            /*" -658- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", WABEND.WNR_EXEC_SQL);

            /*" -659- MOVE WNUM-CHEQUE TO V0HCHE-CHQINT. */
            _.Move(AREA_DE_WORK.WNUM_CHEQUE, V0HCHE_CHQINT);

            /*" -660- MOVE WDIG-CHEQUE TO V0HCHE-DIGINT. */
            _.Move(AREA_DE_WORK.WDIG_CHEQUE, V0HCHE_DIGINT);

            /*" -662- MOVE V1SIST-DTMOVABE-FI TO V0HCHE-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE_FI, V0HCHE_DTMOVTO);

            /*" -663- ACCEPT WK-HORA-1 FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WK_HORA_1);

            /*" -664- MOVE WK-HH-1 TO WK-HH-2. */
            _.Move(AREA_DE_WORK.WK_HORA_1.WK_HH_1, AREA_DE_WORK.WK_HORA_2.WK_HH_2);

            /*" -665- MOVE WK-MM-1 TO WK-MM-2. */
            _.Move(AREA_DE_WORK.WK_HORA_1.WK_MM_1, AREA_DE_WORK.WK_HORA_2.WK_MM_2);

            /*" -666- MOVE WK-SS-1 TO WK-SS-2. */
            _.Move(AREA_DE_WORK.WK_HORA_1.WK_SS_1, AREA_DE_WORK.WK_HORA_2.WK_SS_2);

            /*" -668- MOVE WK-HORA-2 TO V0HCHE-HORAOPER. */
            _.Move(AREA_DE_WORK.WK_HORA_2, V0HCHE_HORAOPER);

            /*" -672- MOVE 0101 TO V0HCHE-OPERACAO. */
            _.Move(0101, V0HCHE_OPERACAO);

            /*" -674- MOVE V0CCHQ-COD-EMPR TO V0HCHE-EMPRESA. */
            _.Move(V0CCHQ_COD_EMPR, V0HCHE_EMPRESA);

            /*" -674- MOVE SPACES TO V0HCHE-DTCOMPSA. */
            _.Move("", V0HCHE_DTCOMPSA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-INSERE-V0CHEQUES-SECTION */
        private void R2000_00_INSERE_V0CHEQUES_SECTION()
        {
            /*" -687- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -715- PERFORM R2000_00_INSERE_V0CHEQUES_DB_INSERT_1 */

            R2000_00_INSERE_V0CHEQUES_DB_INSERT_1();

            /*" -718- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -719- DISPLAY 'R2000 - ERRO NO INSERT DA V0CHEQUES' */
                _.Display($"R2000 - ERRO NO INSERT DA V0CHEQUES");

                /*" -720- DISPLAY 'FONTE   - ' V0CHEQ-FONTE */
                _.Display($"FONTE   - {V0CHEQ_FONTE}");

                /*" -721- DISPLAY 'CHEQUE  - ' V0CHEQ-CHQINT */
                _.Display($"CHEQUE  - {V0CHEQ_CHQINT}");

                /*" -722- DISPLAY 'DIGITO  - ' V0CHEQ-DIGINT */
                _.Display($"DIGITO  - {V0CHEQ_DIGINT}");

                /*" -723- DISPLAY 'TP MOV  - ' V0CHEQ-TPMOVTO */
                _.Display($"TP MOV  - {V0CHEQ_TPMOVTO}");

                /*" -724- DISPLAY 'DT MOV  - ' V0CHEQ-DTMOVTO */
                _.Display($"DT MOV  - {V0CHEQ_DTMOVTO}");

                /*" -725- DISPLAY 'EMPRESA - ' V0CHEQ-EMPRESA */
                _.Display($"EMPRESA - {V0CHEQ_EMPRESA}");

                /*" -726- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -727- ELSE */
            }
            else
            {


                /*" -728- ADD 1 TO AC-I-V0CHEQUES */
                AREA_DE_WORK.AC_I_V0CHEQUES.Value = AREA_DE_WORK.AC_I_V0CHEQUES + 1;

                /*" -728- END-IF. */
            }


        }

        [StopWatch]
        /*" R2000-00-INSERE-V0CHEQUES-DB-INSERT-1 */
        public void R2000_00_INSERE_V0CHEQUES_DB_INSERT_1()
        {
            /*" -715- EXEC SQL INSERT INTO SEGUROS.V0CHEQUES VALUES (:V0CHEQ-TPMOVTO , :V0CHEQ-FONTE , :V0CHEQ-NUMDOC , :V0CHEQ-NOMFAV , :V0CHEQ-VALCHQ , :V0CHEQ-DTMOVTO , NULL , :V0CHEQ-CHQINT , :V0CHEQ-DIGINT , :V0CHEQ-SITUACAO, :V0CHEQ-TIPPAG , :V0CHEQ-DATCMP , :V0CHEQ-PRAPAG , :V0CHEQ-NUMREC , :V0CHEQ-OCORHIST, :V0CHEQ-OPERACAO, :V0CHEQ-CODDSA , :V0CHEQ-VALIRF , :V0CHEQ-VALISS , :V0CHEQ-VALIAP , :V0CHEQ-CODLAN , :V0CHEQ-DATLAN , :V0CHEQ-EMPRESA , CURRENT TIMESTAMP, :V0CHEQ-CODFAV, NULL) END-EXEC. */

            var r2000_00_INSERE_V0CHEQUES_DB_INSERT_1_Insert1 = new R2000_00_INSERE_V0CHEQUES_DB_INSERT_1_Insert1()
            {
                V0CHEQ_TPMOVTO = V0CHEQ_TPMOVTO.ToString(),
                V0CHEQ_FONTE = V0CHEQ_FONTE.ToString(),
                V0CHEQ_NUMDOC = V0CHEQ_NUMDOC.ToString(),
                V0CHEQ_NOMFAV = V0CHEQ_NOMFAV.ToString(),
                V0CHEQ_VALCHQ = V0CHEQ_VALCHQ.ToString(),
                V0CHEQ_DTMOVTO = V0CHEQ_DTMOVTO.ToString(),
                V0CHEQ_CHQINT = V0CHEQ_CHQINT.ToString(),
                V0CHEQ_DIGINT = V0CHEQ_DIGINT.ToString(),
                V0CHEQ_SITUACAO = V0CHEQ_SITUACAO.ToString(),
                V0CHEQ_TIPPAG = V0CHEQ_TIPPAG.ToString(),
                V0CHEQ_DATCMP = V0CHEQ_DATCMP.ToString(),
                V0CHEQ_PRAPAG = V0CHEQ_PRAPAG.ToString(),
                V0CHEQ_NUMREC = V0CHEQ_NUMREC.ToString(),
                V0CHEQ_OCORHIST = V0CHEQ_OCORHIST.ToString(),
                V0CHEQ_OPERACAO = V0CHEQ_OPERACAO.ToString(),
                V0CHEQ_CODDSA = V0CHEQ_CODDSA.ToString(),
                V0CHEQ_VALIRF = V0CHEQ_VALIRF.ToString(),
                V0CHEQ_VALISS = V0CHEQ_VALISS.ToString(),
                V0CHEQ_VALIAP = V0CHEQ_VALIAP.ToString(),
                V0CHEQ_CODLAN = V0CHEQ_CODLAN.ToString(),
                V0CHEQ_DATLAN = V0CHEQ_DATLAN.ToString(),
                V0CHEQ_EMPRESA = V0CHEQ_EMPRESA.ToString(),
                V0CHEQ_CODFAV = V0CHEQ_CODFAV.ToString(),
            };

            R2000_00_INSERE_V0CHEQUES_DB_INSERT_1_Insert1.Execute(r2000_00_INSERE_V0CHEQUES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-INSERE-V0HISTCHEQ-SECTION */
        private void R2100_00_INSERE_V0HISTCHEQ_SECTION()
        {
            /*" -741- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WABEND.WNR_EXEC_SQL);

            /*" -751- PERFORM R2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1 */

            R2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1();

            /*" -754- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -755- DISPLAY 'R2100 - ERRO NO INSERT DA V0HISTCHEQ' */
                _.Display($"R2100 - ERRO NO INSERT DA V0HISTCHEQ");

                /*" -756- DISPLAY 'FONTE   - ' V0CHEQ-FONTE */
                _.Display($"FONTE   - {V0CHEQ_FONTE}");

                /*" -757- DISPLAY 'CHEQUE  - ' V0CHEQ-CHQINT */
                _.Display($"CHEQUE  - {V0CHEQ_CHQINT}");

                /*" -758- DISPLAY 'DIGITO  - ' V0CHEQ-DIGINT */
                _.Display($"DIGITO  - {V0CHEQ_DIGINT}");

                /*" -759- DISPLAY 'TP MOV  - ' V0CHEQ-TPMOVTO */
                _.Display($"TP MOV  - {V0CHEQ_TPMOVTO}");

                /*" -760- DISPLAY 'DT MOV  - ' V0CHEQ-DTMOVTO */
                _.Display($"DT MOV  - {V0CHEQ_DTMOVTO}");

                /*" -761- DISPLAY 'EMPRESA - ' V0CHEQ-EMPRESA */
                _.Display($"EMPRESA - {V0CHEQ_EMPRESA}");

                /*" -762- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -763- ELSE */
            }
            else
            {


                /*" -764- ADD 1 TO AC-I-V0HISTCHEQ */
                AREA_DE_WORK.AC_I_V0HISTCHEQ.Value = AREA_DE_WORK.AC_I_V0HISTCHEQ + 1;

                /*" -764- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-INSERE-V0HISTCHEQ-DB-INSERT-1 */
        public void R2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1()
        {
            /*" -751- EXEC SQL INSERT INTO SEGUROS.V0HISTCHEQ VALUES (:V0HCHE-CHQINT , :V0HCHE-DIGINT , :V0HCHE-DTMOVTO , :V0HCHE-HORAOPER, :V0HCHE-OPERACAO, :V0HCHE-EMPRESA , CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1_Insert1 = new R2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1_Insert1()
            {
                V0HCHE_CHQINT = V0HCHE_CHQINT.ToString(),
                V0HCHE_DIGINT = V0HCHE_DIGINT.ToString(),
                V0HCHE_DTMOVTO = V0HCHE_DTMOVTO.ToString(),
                V0HCHE_HORAOPER = V0HCHE_HORAOPER.ToString(),
                V0HCHE_OPERACAO = V0HCHE_OPERACAO.ToString(),
                V0HCHE_EMPRESA = V0HCHE_EMPRESA.ToString(),
            };

            R2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1_Insert1.Execute(r2100_00_INSERE_V0HISTCHEQ_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-UPDATE-COSCED-CHEQUE-SECTION */
        private void R2200_00_UPDATE_COSCED_CHEQUE_SECTION()
        {
            /*" -777- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WABEND.WNR_EXEC_SQL);

            /*" -786- PERFORM R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1 */

            R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1();

            /*" -789- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -790- DISPLAY 'R2200 - ERRO NO UPDATE DA V0COSCED_CHEQUE' */
                _.Display($"R2200 - ERRO NO UPDATE DA V0COSCED_CHEQUE");

                /*" -791- DISPLAY 'EMPRESA     - ' V0CCHQ-COD-EMPR */
                _.Display($"EMPRESA     - {V0CCHQ_COD_EMPR}");

                /*" -792- DISPLAY 'CONGENERE   - ' V0CCHQ-CONGENER */
                _.Display($"CONGENERE   - {V0CCHQ_CONGENER}");

                /*" -793- DISPLAY 'NR CHEQUE   - ' V0CHEQ-CHQINT */
                _.Display($"NR CHEQUE   - {V0CHEQ_CHQINT}");

                /*" -794- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -795- ELSE */
            }
            else
            {


                /*" -796- ADD 1 TO AC-U-V0COSCEDCHQ */
                AREA_DE_WORK.AC_U_V0COSCEDCHQ.Value = AREA_DE_WORK.AC_U_V0COSCEDCHQ + 1;

                /*" -796- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-UPDATE-COSCED-CHEQUE-DB-UPDATE-1 */
        public void R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1()
        {
            /*" -786- EXEC SQL UPDATE SEGUROS.V0COSCED_CHEQUE SET SITUACAO = '1' , NRCHEQUE = :V0CCHQ-NRCHEQUE, DVCHEQUE = :V0CCHQ-DVCHEQUE WHERE COD_EMPRESA = :V0CCHQ-COD-EMPR AND CONGENER = :V0CCHQ-CONGENER AND DTMOVTO_FI = :V1SIST-DTMOVABE-FI AND SITUACAO = '0' END-EXEC. */

            var r2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1 = new R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1()
            {
                V0CCHQ_NRCHEQUE = V0CCHQ_NRCHEQUE.ToString(),
                V0CCHQ_DVCHEQUE = V0CCHQ_DVCHEQUE.ToString(),
                V1SIST_DTMOVABE_FI = V1SIST_DTMOVABE_FI.ToString(),
                V0CCHQ_COD_EMPR = V0CCHQ_COD_EMPR.ToString(),
                V0CCHQ_CONGENER = V0CCHQ_CONGENER.ToString(),
            };

            R2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1.Execute(r2200_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -810- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -812- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -812- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -816- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -816- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}