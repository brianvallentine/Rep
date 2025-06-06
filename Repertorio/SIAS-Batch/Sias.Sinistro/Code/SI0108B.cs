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
using Sias.Sinistro.DB2.SI0108B;

namespace Code
{
    public class SI0108B
    {
        public bool IsCall { get; set; }

        public SI0108B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA              :    SINISTRO                          //      */
        /*"      * PROGRAMA             :    SI0108B                           //      */
        /*"      * OBJETIVO             :    EMISSAO DE RELATORIO DE RESUMO    //      */
        /*"      *                           DE SINISTROS A  PAGAR             //      */
        /*"      * ANALISTA/PROGRAMADOR :    PROCAS/ENRICO                     //      */
        /*"      * DATA                 :    27/06/91                          //      */
        /*"      *                           MARCO/92   -   FREDERICO          //      */
        /*"      *                           JULHO/92   -   EDUARDO            //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *////////////////////////////////////////////////////////////*      */
        #endregion


        #region VARIABLES

        public FileBasis _RELATORIO { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RELATORIO
        {
            get
            {
                _.Move(REG_RELAT, _RELATORIO); VarBasis.RedefinePassValue(REG_RELAT, _RELATORIO, REG_RELAT); return _RELATORIO;
            }
        }
        /*"01         REG-RELAT.*/
        public SI0108B_REG_RELAT REG_RELAT { get; set; } = new SI0108B_REG_RELAT();
        public class SI0108B_REG_RELAT : VarBasis
        {
            /*"  05       REG-LINHA                  PIC  X(132).*/
            public StringBasis REG_LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77          V1EMPRESA-COD-EMP      PIC S9(004)       COMP.*/
        public IntBasis V1EMPRESA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EMPRESA-NOM-EMP      PIC  X(040).*/
        public StringBasis V1EMPRESA_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           TSISTEM-IDSISTEM       PIC  X(02).*/
        public StringBasis TSISTEM_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"77           TSISTEM-DTMOVABE       PIC  X(10).*/
        public StringBasis TSISTEM_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77           TSISTEM-DTCURRENT      PIC  X(10).*/
        public StringBasis TSISTEM_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77           TGEUN-CODUNIMO        PIC  S9(04)       COMP.*/
        public IntBasis TGEUN_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77           TGEUN-DTINIVIG        PIC   X(10).*/
        public StringBasis TGEUN_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77           TGEUN-DTTERVIG        PIC   X(10).*/
        public StringBasis TGEUN_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77           TGEUN-VALCPR          PIC  S9(09)V9(6)  COMP-3.*/
        public DoubleBasis TGEUN_VALCPR { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(09)V9(6)"), 6);
        /*"77           TGEUN-VLCRUZAD        PIC  S9(06)V9(9)  COMP-3.*/
        public DoubleBasis TGEUN_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(9)"), 9);
        /*"77           WDTINIVIG            PIC   X(10).*/
        public StringBasis WDTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77           WDTTERVIG            PIC   X(10).*/
        public StringBasis WDTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77           RELSIN-DTINIVIG      PIC   X(10).*/
        public StringBasis RELSIN_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77           RELSIN-DTTERVIG      PIC   X(10).*/
        public StringBasis RELSIN_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77           THIST-APOL-SINI       PIC  S9(13)        COMP-3.*/
        public IntBasis THIST_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77           THIST-OPERACAO        PIC  S9(04)        COMP.*/
        public IntBasis THIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77           THIST-VAL-OPERACAO    PIC  S9(13)V99     COMP-3.*/
        public DoubleBasis THIST_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77           THIST-DTMOVTO         PIC   X(10).*/
        public StringBasis THIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77           THIST-VALPRI          PIC  S9(13)V99     COMP-3.*/
        public DoubleBasis THIST_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77           THIST-SITUACAO        PIC   X(01).*/
        public StringBasis THIST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77           THIST-LIMCRR          PIC  X(010).*/
        public StringBasis THIST_LIMCRR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           TMEST-APOL-SINI       PIC  S9(13)        COMP-3.*/
        public IntBasis TMEST_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77           TMEST-FONTE           PIC  S9(04)        COMP.*/
        public IntBasis TMEST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77           TGEFON-FONTE           PIC  S9(04)       COMP.*/
        public IntBasis TGEFON_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77           TGEFON-NOMEFTE         PIC   X(30).*/
        public StringBasis TGEFON_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"77           WH-FONTE               PIC  S9(04)       COMP.*/
        public IntBasis WH_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77           GEUNIMO-VLCRUZAD       PIC S9(006)V9(9)  COMP-3.*/
        public DoubleBasis GEUNIMO_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77           GEUNIMO-SIGLUNIM       PIC  X(006).*/
        public StringBasis GEUNIMO_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
        /*"77           MEST-COD-MD-SINI       PIC S9(004)       COMP.*/
        public IntBasis MEST_COD_MD_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           WMOEDA            PIC S9(004) COMP VALUE ZEROS.*/
        public IntBasis WMOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           WGEUNIMO-DTTERVIG     PIC X(010).*/
        public StringBasis WGEUNIMO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           WGEUNIMO-DTINIVIG     PIC X(010).*/
        public StringBasis WGEUNIMO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"  03            WSQLCODE3           PIC  S9(009)     COMP.*/
        public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  03         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
        public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  03         FILLER            REDEFINES      WDATA-CURR.*/
        private _REDEF_SI0108B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_SI0108B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_SI0108B_FILLER_0(); _.Move(WDATA_CURR, _filler_0); VarBasis.RedefinePassValue(WDATA_CURR, _filler_0, WDATA_CURR); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_CURR); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_CURR); }
        }  //Redefines
        public class _REDEF_SI0108B_FILLER_0 : VarBasis
        {
            /*"    05       WDATA-AA-CURR     PIC  9(004).*/
            public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05       FILLER            PIC  X(001).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05       WDATA-MM-CURR     PIC  9(002).*/
            public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05       FILLER            PIC  X(001).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05       WDATA-DD-CURR     PIC  9(002).*/
            public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03            WHORA-CURR.*/

            public _REDEF_SI0108B_FILLER_0()
            {
                WDATA_AA_CURR.ValueChanged += OnValueChanged;
                FILLER_1.ValueChanged += OnValueChanged;
                WDATA_MM_CURR.ValueChanged += OnValueChanged;
                FILLER_2.ValueChanged += OnValueChanged;
                WDATA_DD_CURR.ValueChanged += OnValueChanged;
            }

        }
        public SI0108B_WHORA_CURR WHORA_CURR { get; set; } = new SI0108B_WHORA_CURR();
        public class SI0108B_WHORA_CURR : VarBasis
        {
            /*"    05          WHORA-HH-CURR       PIC  9(002) VALUE ZEROS.*/
            public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05          WHORA-MM-CURR       PIC  9(002) VALUE ZEROS.*/
            public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05          WHORA-SS-CURR       PIC  9(002) VALUE ZEROS.*/
            public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05          WHORA-CC-CURR       PIC  9(002) VALUE ZEROS.*/
            public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03            WDATA-CABEC.*/
        }
        public SI0108B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0108B_WDATA_CABEC();
        public class SI0108B_WDATA_CABEC : VarBasis
        {
            /*"    05          WDATA-DD-CABEC      PIC  9(002) VALUE ZEROS.*/
            public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    05          WDATA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
            public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    05          WDATA-AA-CABEC      PIC  9(004) VALUE ZEROS.*/
            public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03            WHORA-CABEC.*/
        }
        public SI0108B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0108B_WHORA_CABEC();
        public class SI0108B_WHORA_CABEC : VarBasis
        {
            /*"    05          WHORA-HH-CABEC      PIC  9(002) VALUE ZEROS.*/
            public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
            /*"    05          WHORA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
            public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
            /*"    05          WHORA-SS-CABEC      PIC  9(002) VALUE ZEROS.*/
            public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03            WDATA-AUX.*/
        }
        public SI0108B_WDATA_AUX WDATA_AUX { get; set; } = new SI0108B_WDATA_AUX();
        public class SI0108B_WDATA_AUX : VarBasis
        {
            /*"    05          WDATA-AUX-AA        PIC  9(004).*/
            public IntBasis WDATA_AUX_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05          FILLER              PIC  X(001).*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05          WDATA-AUX-MM        PIC  9(002).*/
            public IntBasis WDATA_AUX_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05          FILLER              PIC  X(001).*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05          WDATA-AUX-DD        PIC  9(002).*/
            public IntBasis WDATA_AUX_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03            WDATA-AUX-R         REDEFINES   WDATA-AUX                                    PIC  X(010).*/
        }
        private _REDEF_StringBasis _wdata_aux_r { get; set; }
        public _REDEF_StringBasis WDATA_AUX_R
        {
            get { _wdata_aux_r = new _REDEF_StringBasis(new PIC("X", "010", "X(010).")); ; _.Move(WDATA_AUX, _wdata_aux_r); VarBasis.RedefinePassValue(WDATA_AUX, _wdata_aux_r, WDATA_AUX); _wdata_aux_r.ValueChanged += () => { _.Move(_wdata_aux_r, WDATA_AUX); }; return _wdata_aux_r; }
            set { VarBasis.RedefinePassValue(value, _wdata_aux_r, WDATA_AUX); }
        }  //Redefines
        /*"  03            WSINISTRO-ANT       PIC  9(13)    VALUE ZEROS.*/
        public IntBasis WSINISTRO_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"  03            FILLER              REDEFINES WSINISTRO-ANT.*/
        private _REDEF_SI0108B_FILLER_9 _filler_9 { get; set; }
        public _REDEF_SI0108B_FILLER_9 FILLER_9
        {
            get { _filler_9 = new _REDEF_SI0108B_FILLER_9(); _.Move(WSINISTRO_ANT, _filler_9); VarBasis.RedefinePassValue(WSINISTRO_ANT, _filler_9, WSINISTRO_ANT); _filler_9.ValueChanged += () => { _.Move(_filler_9, WSINISTRO_ANT); }; return _filler_9; }
            set { VarBasis.RedefinePassValue(value, _filler_9, WSINISTRO_ANT); }
        }  //Redefines
        public class _REDEF_SI0108B_FILLER_9 : VarBasis
        {
            /*"    05          WORGSIN-ANT         PIC  9(03).*/
            public IntBasis WORGSIN_ANT { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05          WRMOSIN-ANT         PIC  9(02).*/
            public IntBasis WRMOSIN_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05          WNUMSIN-ANT         PIC  9(08).*/
            public IntBasis WNUMSIN_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"  03            WTABG-GEUNIMO.*/

            public _REDEF_SI0108B_FILLER_9()
            {
                WORGSIN_ANT.ValueChanged += OnValueChanged;
                WRMOSIN_ANT.ValueChanged += OnValueChanged;
                WNUMSIN_ANT.ValueChanged += OnValueChanged;
            }

        }
        public SI0108B_WTABG_GEUNIMO WTABG_GEUNIMO { get; set; } = new SI0108B_WTABG_GEUNIMO();
        public class SI0108B_WTABG_GEUNIMO : VarBasis
        {
            /*"    05          WTABG-GEUNIMO-ZERA.*/
            public SI0108B_WTABG_GEUNIMO_ZERA WTABG_GEUNIMO_ZERA { get; set; } = new SI0108B_WTABG_GEUNIMO_ZERA();
            public class SI0108B_WTABG_GEUNIMO_ZERA : VarBasis
            {
                /*"      07        FILLER          PIC  S9(04)      COMP   VALUE +0*/
                public IntBasis FILLER_10 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                /*"      07        FILLER          PIC   X(10).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"      07        FILLER          PIC   X(10).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"      07        FILLER          PIC  S9(06)V9(9) COMP-3 VALUE +0*/
                public DoubleBasis FILLER_13 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(9)"), 9);
                /*"      07        FILLER          PIC  S9(06)V9(9) COMP-3 VALUE +0*/
                public DoubleBasis FILLER_14 { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(9)"), 9);
                /*"      07        WTABG-GEUNIMOGRUPO.*/
                public SI0108B_WTABG_GEUNIMOGRUPO WTABG_GEUNIMOGRUPO { get; set; } = new SI0108B_WTABG_GEUNIMOGRUPO();
                public class SI0108B_WTABG_GEUNIMOGRUPO : VarBasis
                {
                    /*"        09      WTABG-OCORREGEUNIMO  OCCURS   200  TIMES                                     INDEXED  BY   I01.*/
                    public ListBasis<SI0108B_WTABG_OCORREGEUNIMO> WTABG_OCORREGEUNIMO { get; set; } = new ListBasis<SI0108B_WTABG_OCORREGEUNIMO>(200);
                    public class SI0108B_WTABG_OCORREGEUNIMO : VarBasis
                    {
                        /*"          11    WTABG-CODUNIMO      PIC  S9(04)      COMP.*/
                        public IntBasis WTABG_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                        /*"          11    WTABG-DTINIVIG      PIC   X(10).*/
                        public StringBasis WTABG_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                        /*"          11    WTABG-DTTERVIG      PIC   X(10).*/
                        public StringBasis WTABG_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                        /*"          11    WTABG-VLCRUZAD      PIC  S9(06)V9(9) COMP-3.*/
                        public DoubleBasis WTABG_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(9)"), 9);
                        /*"          11    WTABG-VALCPR        PIC  S9(06)V9(9) COMP-3.*/
                        public DoubleBasis WTABG_VALCPR { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(9)"), 9);
                        /*"  03            WZEROS              PIC  9(03)    VALUE 0.*/
                    }
                }
            }
        }
        public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
        /*"  03            WHUM                PIC  9(03)    VALUE 1.*/
        public IntBasis WHUM { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"), 1);
        /*"  03            WFONTE-ANT          PIC  9(005)      VALUE ZEROS*/
        public IntBasis WFONTE_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"  03            WLINHA              PIC  9(005)      VALUE  70.*/
        public IntBasis WLINHA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"), 70);
        /*"  03            WFOLHA              PIC  9(005)      VALUE ZEROS*/
        public IntBasis WFOLHA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"  03            WFIM                PIC  X(001)      VALUE 'N'.*/
        public StringBasis WFIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            WFIM-RELSIN         PIC  X(001)      VALUE 'N'.*/
        public StringBasis WFIM_RELSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            WFIM-TSISTEMA       PIC  X(001)      VALUE 'N'.*/
        public StringBasis WFIM_TSISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03            WCT-LIDOS-RELSIN    PIC  9(010)      VALUE ZEROS*/
        public IntBasis WCT_LIDOS_RELSIN { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"  03            WCT-LIDOS           PIC  9(010)      VALUE ZEROS*/
        public IntBasis WCT_LIDOS { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"  03            WCT-IMPRES          PIC  9(010)      VALUE ZEROS*/
        public IntBasis WCT_IMPRES { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"  03            WACTOTSIN           PIC  9(010)      VALUE ZEROS*/
        public IntBasis WACTOTSIN { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"  03            WACTOTBT            PIC  9(011)V9(5) VALUE ZEROS*/
        public DoubleBasis WACTOTBT { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V9(5)"), 5);
        /*"  03            WACTOTCR            PIC  9(013)V99   VALUE ZEROS*/
        public DoubleBasis WACTOTCR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"  03            WQTDSIN             PIC  9(010)      VALUE ZEROS*/
        public IntBasis WQTDSIN { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"  03            WVALBT              PIC  9(11)V9(5)  VALUE ZEROS*/
        public DoubleBasis WVALBT { get; set; } = new DoubleBasis(new PIC("9", "11", "9(11)V9(5)"), 5);
        /*"  03            WVALCR              PIC  9(13)V99    VALUE ZEROS*/
        public DoubleBasis WVALCR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
        /*"  03            WACVALBT            PIC  9(11)V9(5)  VALUE ZEROS*/
        public DoubleBasis WACVALBT { get; set; } = new DoubleBasis(new PIC("9", "11", "9(11)V9(5)"), 5);
        /*"  03            WACVALCR            PIC  9(13)V99    VALUE ZEROS*/
        public DoubleBasis WACVALCR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
        /*"  03            WQTD-MOEDA      PIC 9(013)V9(4)   VALUE ZEROS.*/
        public DoubleBasis WQTD_MOEDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V9(4)"), 4);
        /*"  03            W-MOEDA-ATU     PIC S9(004) COMP  VALUE ZEROS.*/
        public IntBasis W_MOEDA_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  03            W-MOEDA-ANT     PIC S9(004) COMP  VALUE ZEROS.*/
        public IntBasis W_MOEDA_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  03            WGEUNIMO-CODUNIMO  PIC 9(004).*/
        public IntBasis WGEUNIMO_CODUNIMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        /*"  03             CH1-ON1           PIC 9(001)     VALUE ZEROS.*/
        public IntBasis CH1_ON1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"  03             CH2-ON1           PIC 9(001)     VALUE ZEROS.*/
        public IntBasis CH2_ON1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"  03             CH3-ON1           PIC 9(001)     VALUE ZEROS.*/
        public IntBasis CH3_ON1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01              W.*/
        public SI0108B_W W { get; set; } = new SI0108B_W();
        public class SI0108B_W : VarBasis
        {
            /*"  03            LC01.*/
            public SI0108B_LC01 LC01 { get; set; } = new SI0108B_LC01();
            public class SI0108B_LC01 : VarBasis
            {
                /*"    05          LC01-RELATORIO   PIC  X(009) VALUE 'SI0108B.1'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0108B.1");
                /*"    05          FILLER           PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          LC01-EMPRESA     PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER           PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER           PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    05          LC01-PAG         PIC  ZZZ9.*/
                public IntBasis LC01_PAG { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  03            LC02.*/
            }
            public SI0108B_LC02 LC02 { get; set; } = new SI0108B_LC02();
            public class SI0108B_LC02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(052) VALUE  SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"");
                /*"    05          FILLER              PIC  X(062) VALUE                '                     '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "62", "X(062)"), @"                     ");
                /*"    05          FILLER              PIC  X(003) VALUE  SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    05          LC02-DATA           PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03            LC03.*/
            }
            public SI0108B_LC03 LC03 { get; set; } = new SI0108B_LC03();
            public class SI0108B_LC03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    05          LC03-HORA           PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  03            LC04.*/
            }
            public SI0108B_LC04 LC04 { get; set; } = new SI0108B_LC04();
            public class SI0108B_LC04 : VarBasis
            {
                /*"    05          FILLER          PIC  X(035) VALUE SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    05          FILLER          PIC  X(035) VALUE                'RESUMO  DE SINISTROS  A  PAGAR  DE'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"RESUMO  DE SINISTROS  A  PAGAR  DE");
                /*"    05          LC04-DIA1       PIC  9(002).*/
                public IntBasis LC04_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER          PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          LC04-MES1       PIC  9(002).*/
                public IntBasis LC04_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER          PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          LC04-ANO1       PIC  9(004).*/
                public IntBasis LC04_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER          PIC  X(005) VALUE                ' ATE'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ATE");
                /*"    05          LC04-DIA2       PIC  9(002).*/
                public IntBasis LC04_DIA2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER          PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          LC04-MES2       PIC  9(002).*/
                public IntBasis LC04_MES2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER          PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          LC04-ANO2       PIC  9(004).*/
                public IntBasis LC04_ANO2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03            LC05.*/
            }
            public SI0108B_LC05 LC05 { get; set; } = new SI0108B_LC05();
            public class SI0108B_LC05 : VarBasis
            {
                /*"    05          FILLER          PIC  X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  03            LC06.*/
            }
            public SI0108B_LC06 LC06 { get; set; } = new SI0108B_LC06();
            public class SI0108B_LC06 : VarBasis
            {
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          FILLER              PIC  X(052) VALUE 'FONTE'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"FONTE");
                /*"    05          FILLER              PIC  X(027) VALUE                'QTDE. SINISTROS'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"QTDE. SINISTROS");
                /*"    05          FILLER              PIC  X(020) VALUE                'VALOR INDEXADO'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"VALOR INDEXADO");
                /*"    05          FILLER              PIC  X(012) VALUE                'MOEDA'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"MOEDA");
                /*"    05          FILLER              PIC  X(019) VALUE                'VALOR EM CRUZEIROS'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"VALOR EM CRUZEIROS");
                /*"  03            LC07.*/
            }
            public SI0108B_LC07 LC07 { get; set; } = new SI0108B_LC07();
            public class SI0108B_LC07 : VarBasis
            {
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          LC07-FONTE          PIC  9(003).*/
                public IntBasis LC07_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          LC07-NOMEFTE        PIC  X(040).*/
                public StringBasis LC07_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05          FILLER              PIC  X(009) VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    05          LC07-QTDESIN        PIC  ZZZ999.*/
                public IntBasis LC07_QTDESIN { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ999."));
                /*"    05          FILLER              PIC  X(011) VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    05          LC07-VLTOTBT        PIC  ZZ.ZZZ.ZZZ.ZZ9,99999.*/
                public DoubleBasis LC07_VLTOTBT { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZ.ZZZ.ZZZ.ZZ9V99999."), 5);
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LC07-MOEDA          PIC  X(006) VALUE SPACES.*/
                public StringBasis LC07_MOEDA { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC07-VLTOTCR        PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LC07_VLTOTCR { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  03            LC08.*/
            }
            public SI0108B_LC08 LC08 { get; set; } = new SI0108B_LC08();
            public class SI0108B_LC08 : VarBasis
            {
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          FILLER              PIC  X(054) VALUE               'TOTAL GERAL '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"TOTAL GERAL ");
                /*"    05          LC08-TOQTDE         PIC  ZZZZ999.*/
                public IntBasis LC08_TOQTDE { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ999."));
                /*"    05          FILLER              PIC  X(046) VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
                /*"    05          LC08-TOTCR          PIC  ZZ.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LC08_TOTCR { get; set; } = new DoubleBasis(new PIC("9", "14", "ZZ.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  03            LC09.*/
            }
            public SI0108B_LC09 LC09 { get; set; } = new SI0108B_LC09();
            public class SI0108B_LC09 : VarBasis
            {
                /*"    05          FILLER              PIC  X(040) VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(051) VALUE        '***** NAO  EXISTE  NENHUM  SINISTRO  A  PAGAR *****'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"***** NAO  EXISTE  NENHUM  SINISTRO  A  PAGAR *****");
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"  03        WABEND.*/
            }
            public SI0108B_WABEND WABEND { get; set; } = new SI0108B_WABEND();
            public class SI0108B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0108B'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0108B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public SI0108B_LK_LINK LK_LINK { get; set; } = new SI0108B_LK_LINK();
        public class SI0108B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0108B_RELSIN RELSIN { get; set; } = new SI0108B_RELSIN();
        public SI0108B_DESCR DESCR { get; set; } = new SI0108B_DESCR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RELATORIO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RELATORIO.SetFile(RELATORIO_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL-SECTION */

                M_000_000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-SECTION */
        private void M_000_000_PRINCIPAL_SECTION()
        {
            /*" -363- MOVE '000' TO WNR-EXEC-SQL */
            _.Move("000", W.WABEND.WNR_EXEC_SQL);

            /*" -367- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", W.WABEND.PARAGRAFO);

            /*" -368- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -370- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -372- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -377- PERFORM 030-000-INICIO. */

            M_030_000_INICIO_SECTION();

            /*" -379- PERFORM 060-000-LER-TSISTEMA. */

            M_060_000_LER_TSISTEMA_SECTION();

            /*" -382- PERFORM 015-000-CABECALHOS. */

            M_015_000_CABECALHOS_SECTION();

            /*" -384- MOVE TSISTEM-DTMOVABE TO WDATA-AUX-R */
            _.Move(TSISTEM_DTMOVABE, WDATA_AUX_R);

            /*" -385- PERFORM 080-000-CURSOR-RELATO. */

            M_080_000_CURSOR_RELATO_SECTION();

            /*" -387- PERFORM 085-000-LER-RELSIN. */

            M_085_000_LER_RELSIN_SECTION();

            /*" -388- IF WFIM-RELSIN EQUAL 'S' */

            if (WFIM_RELSIN == "S")
            {

                /*" -389- DISPLAY 'SI0108B - SEM SOLICITACAO PARA EMISSAO' */
                _.Display($"SI0108B - SEM SOLICITACAO PARA EMISSAO");

                /*" -391- GO TO 000-900-FINALIZA. */

                M_000_900_FINALIZA(); //GOTO
                return;
            }


            /*" -392- PERFORM 090-000-ABRIR-CURSOR. */

            M_090_000_ABRIR_CURSOR_SECTION();

            /*" -394- PERFORM 120-000-LER-DESCR. */

            M_120_000_LER_DESCR_SECTION();

            /*" -395- IF WFIM EQUAL 'S' */

            if (WFIM == "S")
            {

                /*" -396- PERFORM 300-000-CABEC */

                M_300_000_CABEC_SECTION();

                /*" -397- WRITE REG-RELAT FROM LC09 AFTER 16 */
                _.Move(W.LC09.GetMoveValues(), REG_RELAT);

                RELATORIO.Write(REG_RELAT.GetMoveValues().ToString());

                /*" -399- GO TO 000-900-FINALIZA. */

                M_000_900_FINALIZA(); //GOTO
                return;
            }


            /*" -401- MOVE TMEST-FONTE TO WFONTE-ANT. */
            _.Move(TMEST_FONTE, WFONTE_ANT);

            /*" -404- PERFORM 140-000-PROCESSA UNTIL WFIM EQUAL 'S' */

            while (!(WFIM == "S"))
            {

                M_140_000_PROCESSA_SECTION();
            }

            /*" -405- PERFORM 180-000-LER-TGEFONTE. */

            M_180_000_LER_TGEFONTE_SECTION();

            /*" -407- PERFORM 200-000-IMPRIME. */

            M_200_000_IMPRIME_SECTION();

            /*" -408- MOVE WACTOTSIN TO LC08-TOQTDE. */
            _.Move(WACTOTSIN, W.LC08.LC08_TOQTDE);

            /*" -411- MOVE WACTOTCR TO LC08-TOTCR. */
            _.Move(WACTOTCR, W.LC08.LC08_TOTCR);

            /*" -412- IF WLINHA GREATER 60 */

            if (WLINHA > 60)
            {

                /*" -414- PERFORM 300-000-CABEC. */

                M_300_000_CABEC_SECTION();
            }


            /*" -416- WRITE REG-RELAT FROM LC08 AFTER 5. */
            _.Move(W.LC08.GetMoveValues(), REG_RELAT);

            RELATORIO.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -416- PERFORM 500-000-DELETE-V0RELATORIOS. */

            M_500_000_DELETE_V0RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_000_900_FINALIZA */

            M_000_900_FINALIZA();

        }

        [StopWatch]
        /*" M-000-900-FINALIZA */
        private void M_000_900_FINALIZA(bool isPerform = false)
        {
            /*" -421- PERFORM 400-000-FINAL. */

            M_400_000_FINAL_SECTION();

            /*" -421- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-015-000-CABECALHOS-SECTION */
        private void M_015_000_CABECALHOS_SECTION()
        {
            /*" -435- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), WHORA_CURR);

            /*" -436- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(WHORA_CURR.WHORA_HH_CURR, WHORA_CABEC.WHORA_HH_CABEC);

            /*" -437- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(WHORA_CURR.WHORA_MM_CURR, WHORA_CABEC.WHORA_MM_CABEC);

            /*" -438- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(WHORA_CURR.WHORA_SS_CURR, WHORA_CABEC.WHORA_SS_CABEC);

            /*" -440- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(WHORA_CABEC, W.LC03.LC03_HORA);

            /*" -444- PERFORM M_015_000_CABECALHOS_DB_SELECT_1 */

            M_015_000_CABECALHOS_DB_SELECT_1();

            /*" -447- MOVE V1EMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPRESA_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -449- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -450- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -451- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, W.LC01.LC01_EMPRESA);

                /*" -452- ELSE */
            }
            else
            {


                /*" -453- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -453- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" M-015-000-CABECALHOS-DB-SELECT-1 */
        public void M_015_000_CABECALHOS_DB_SELECT_1()
        {
            /*" -444- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var m_015_000_CABECALHOS_DB_SELECT_1_Query1 = new M_015_000_CABECALHOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_015_000_CABECALHOS_DB_SELECT_1_Query1.Execute(m_015_000_CABECALHOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPRESA_NOM_EMP, V1EMPRESA_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_015_999_EXIT*/

        [StopWatch]
        /*" M-030-000-INICIO-SECTION */
        private void M_030_000_INICIO_SECTION()
        {
            /*" -467- MOVE '030-000-INICIO' TO PARAGRAFO. */
            _.Move("030-000-INICIO", W.WABEND.PARAGRAFO);

            /*" -469- OPEN OUTPUT RELATORIO. */
            RELATORIO.Open(REG_RELAT);

            /*" -469- MOVE WTABG-GEUNIMO-ZERA TO WTABG-GEUNIMOGRUPO. */
            _.Move(WTABG_GEUNIMO.WTABG_GEUNIMO_ZERA, WTABG_GEUNIMO.WTABG_GEUNIMO_ZERA.WTABG_GEUNIMOGRUPO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-SECTION */
        private void M_060_000_LER_TSISTEMA_SECTION()
        {
            /*" -482- MOVE '060-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("060-000-LER-TSISTEMA", W.WABEND.PARAGRAFO);

            /*" -484- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", W.WABEND.WNR_EXEC_SQL);

            /*" -490- PERFORM M_060_000_LER_TSISTEMA_DB_SELECT_1 */

            M_060_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -493- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -494- DISPLAY 'NAO HA REG. NA TSISTEMA - IDSITEM = SI ' */
                _.Display($"NAO HA REG. NA TSISTEMA - IDSITEM = SI ");

                /*" -496- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -497- MOVE TSISTEM-DTCURRENT TO WDATA-CURR */
            _.Move(TSISTEM_DTCURRENT, WDATA_CURR);

            /*" -498- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(FILLER_0.WDATA_DD_CURR, WDATA_CABEC.WDATA_DD_CABEC);

            /*" -499- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(FILLER_0.WDATA_MM_CURR, WDATA_CABEC.WDATA_MM_CABEC);

            /*" -500- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(FILLER_0.WDATA_AA_CURR, WDATA_CABEC.WDATA_AA_CABEC);

            /*" -500- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(WDATA_CABEC, W.LC02.LC02_DATA);

        }

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_060_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -490- EXEC SQL SELECT IDSISTEM, DTMOVABE, CURRENT DATE INTO :TSISTEM-IDSISTEM, :TSISTEM-DTMOVABE, :TSISTEM-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TSISTEM_IDSISTEM, TSISTEM_IDSISTEM);
                _.Move(executed_1.TSISTEM_DTMOVABE, TSISTEM_DTMOVABE);
                _.Move(executed_1.TSISTEM_DTCURRENT, TSISTEM_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-080-000-CURSOR-RELATO-SECTION */
        private void M_080_000_CURSOR_RELATO_SECTION()
        {
            /*" -513- MOVE '080-000-CURSOR-RELATO' TO PARAGRAFO. */
            _.Move("080-000-CURSOR-RELATO", W.WABEND.PARAGRAFO);

            /*" -515- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", W.WABEND.WNR_EXEC_SQL);

            /*" -524- PERFORM M_080_000_CURSOR_RELATO_DB_DECLARE_1 */

            M_080_000_CURSOR_RELATO_DB_DECLARE_1();

            /*" -527- PERFORM M_080_000_CURSOR_RELATO_DB_OPEN_1 */

            M_080_000_CURSOR_RELATO_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-080-000-CURSOR-RELATO-DB-DECLARE-1 */
        public void M_080_000_CURSOR_RELATO_DB_DECLARE_1()
        {
            /*" -524- EXEC SQL DECLARE RELSIN CURSOR FOR SELECT PERI_INICIAL, PERI_FINAL FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0108B' AND DATA_SOLICITACAO = :TSISTEM-DTMOVABE ORDER BY PERI_INICIAL, PERI_FINAL END-EXEC. */
            RELSIN = new SI0108B_RELSIN(true);
            string GetQuery_RELSIN()
            {
                var query = @$"SELECT PERI_INICIAL
							, 
							PERI_FINAL 
							FROM SEGUROS.V1RELATORIOS 
							WHERE 
							IDSISTEM = 'SI' 
							AND CODRELAT = 'SI0108B' 
							AND DATA_SOLICITACAO = '{TSISTEM_DTMOVABE}' 
							ORDER BY PERI_INICIAL
							, PERI_FINAL";

                return query;
            }
            RELSIN.GetQueryEvent += GetQuery_RELSIN;

        }

        [StopWatch]
        /*" M-080-000-CURSOR-RELATO-DB-OPEN-1 */
        public void M_080_000_CURSOR_RELATO_DB_OPEN_1()
        {
            /*" -527- EXEC SQL OPEN RELSIN END-EXEC. */

            RELSIN.Open();

        }

        [StopWatch]
        /*" M-090-000-ABRIR-CURSOR-DB-DECLARE-1 */
        public void M_090_000_ABRIR_CURSOR_DB_DECLARE_1()
        {
            /*" -592- EXEC SQL DECLARE DESCR CURSOR FOR SELECT A.NUM_APOL_SINISTRO, A.OPERACAO, A.DTMOVTO, A.VAL_OPERACAO, A.SITUACAO, A.LIMCRR, B.FONTE FROM SEGUROS.V1HISTSINI A, SEGUROS.V1MESTSINI B WHERE A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND A.OPERACAO IN (1081, 1082, 1083, 1084,9081) AND A.SITUACAO = '0' AND (A.DTMOVTO >= :RELSIN-DTINIVIG AND A.DTMOVTO <= :RELSIN-DTTERVIG) ORDER BY B.FONTE,A.NUM_APOL_SINISTRO END-EXEC. */
            DESCR = new SI0108B_DESCR(true);
            string GetQuery_DESCR()
            {
                var query = @$"SELECT A.NUM_APOL_SINISTRO
							, 
							A.OPERACAO
							, 
							A.DTMOVTO
							, 
							A.VAL_OPERACAO
							, 
							A.SITUACAO
							, 
							A.LIMCRR
							, 
							B.FONTE 
							FROM SEGUROS.V1HISTSINI A
							, SEGUROS.V1MESTSINI B 
							WHERE 
							A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO 
							AND A.OPERACAO IN (1081
							, 1082
							, 1083
							, 
							1084
							,9081) 
							AND A.SITUACAO = '0' 
							AND (A.DTMOVTO >= '{RELSIN_DTINIVIG}' 
							AND A.DTMOVTO <= '{RELSIN_DTTERVIG}') 
							ORDER BY B.FONTE
							,A.NUM_APOL_SINISTRO";

                return query;
            }
            DESCR.GetQueryEvent += GetQuery_DESCR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_080_999_EXIT*/

        [StopWatch]
        /*" M-085-000-LER-RELSIN-SECTION */
        private void M_085_000_LER_RELSIN_SECTION()
        {
            /*" -541- MOVE '085-000-LER-RELSIN' TO PARAGRAFO. */
            _.Move("085-000-LER-RELSIN", W.WABEND.PARAGRAFO);

            /*" -544- MOVE '085' TO WNR-EXEC-SQL. */
            _.Move("085", W.WABEND.WNR_EXEC_SQL);

            /*" -547- PERFORM M_085_000_LER_RELSIN_DB_FETCH_1 */

            M_085_000_LER_RELSIN_DB_FETCH_1();

            /*" -550- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -551- MOVE 'S' TO WFIM-RELSIN */
                _.Move("S", WFIM_RELSIN);

                /*" -551- PERFORM M_085_000_LER_RELSIN_DB_CLOSE_1 */

                M_085_000_LER_RELSIN_DB_CLOSE_1();

                /*" -553- ELSE */
            }
            else
            {


                /*" -554- ADD 1 TO WCT-LIDOS-RELSIN */
                WCT_LIDOS_RELSIN.Value = WCT_LIDOS_RELSIN + 1;

                /*" -555- MOVE RELSIN-DTINIVIG TO WDATA-AUX-R */
                _.Move(RELSIN_DTINIVIG, WDATA_AUX_R);

                /*" -556- MOVE WDATA-AUX-DD TO LC04-DIA1 */
                _.Move(WDATA_AUX.WDATA_AUX_DD, W.LC04.LC04_DIA1);

                /*" -557- MOVE WDATA-AUX-MM TO LC04-MES1 */
                _.Move(WDATA_AUX.WDATA_AUX_MM, W.LC04.LC04_MES1);

                /*" -558- MOVE WDATA-AUX-AA TO LC04-ANO1 */
                _.Move(WDATA_AUX.WDATA_AUX_AA, W.LC04.LC04_ANO1);

                /*" -559- MOVE RELSIN-DTTERVIG TO WDATA-AUX-R */
                _.Move(RELSIN_DTTERVIG, WDATA_AUX_R);

                /*" -560- MOVE WDATA-AUX-DD TO LC04-DIA2 */
                _.Move(WDATA_AUX.WDATA_AUX_DD, W.LC04.LC04_DIA2);

                /*" -561- MOVE WDATA-AUX-MM TO LC04-MES2 */
                _.Move(WDATA_AUX.WDATA_AUX_MM, W.LC04.LC04_MES2);

                /*" -561- MOVE WDATA-AUX-AA TO LC04-ANO2. */
                _.Move(WDATA_AUX.WDATA_AUX_AA, W.LC04.LC04_ANO2);
            }


        }

        [StopWatch]
        /*" M-085-000-LER-RELSIN-DB-FETCH-1 */
        public void M_085_000_LER_RELSIN_DB_FETCH_1()
        {
            /*" -547- EXEC SQL FETCH RELSIN INTO :RELSIN-DTINIVIG, :RELSIN-DTTERVIG END-EXEC. */

            if (RELSIN.Fetch())
            {
                _.Move(RELSIN.RELSIN_DTINIVIG, RELSIN_DTINIVIG);
                _.Move(RELSIN.RELSIN_DTTERVIG, RELSIN_DTTERVIG);
            }

        }

        [StopWatch]
        /*" M-085-000-LER-RELSIN-DB-CLOSE-1 */
        public void M_085_000_LER_RELSIN_DB_CLOSE_1()
        {
            /*" -551- EXEC SQL CLOSE RELSIN END-EXEC */

            RELSIN.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_085_999_EXIT*/

        [StopWatch]
        /*" M-090-000-ABRIR-CURSOR-SECTION */
        private void M_090_000_ABRIR_CURSOR_SECTION()
        {
            /*" -573- MOVE '090-000-ABRIR-CURSOR' TO PARAGRAFO. */
            _.Move("090-000-ABRIR-CURSOR", W.WABEND.PARAGRAFO);

            /*" -575- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", W.WABEND.WNR_EXEC_SQL);

            /*" -592- PERFORM M_090_000_ABRIR_CURSOR_DB_DECLARE_1 */

            M_090_000_ABRIR_CURSOR_DB_DECLARE_1();

            /*" -595- PERFORM M_090_000_ABRIR_CURSOR_DB_OPEN_1 */

            M_090_000_ABRIR_CURSOR_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-ABRIR-CURSOR-DB-OPEN-1 */
        public void M_090_000_ABRIR_CURSOR_DB_OPEN_1()
        {
            /*" -595- EXEC SQL OPEN DESCR END-EXEC. */

            DESCR.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-120-000-LER-DESCR-SECTION */
        private void M_120_000_LER_DESCR_SECTION()
        {
            /*" -609- MOVE '120-000-LER-DESCR' TO PARAGRAFO. */
            _.Move("120-000-LER-DESCR", W.WABEND.PARAGRAFO);

            /*" -609- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", W.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM M_120_010 */

            M_120_010();

        }

        [StopWatch]
        /*" M-120-010 */
        private void M_120_010(bool isPerform = false)
        {
            /*" -621- PERFORM M_120_010_DB_FETCH_1 */

            M_120_010_DB_FETCH_1();

            /*" -625- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -626- PERFORM 085-000-LER-RELSIN */

                M_085_000_LER_RELSIN_SECTION();

                /*" -627- IF WFIM-RELSIN EQUAL 'S' */

                if (WFIM_RELSIN == "S")
                {

                    /*" -628- MOVE 'S' TO WFIM */
                    _.Move("S", WFIM);

                    /*" -629- GO TO 120-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/ //GOTO
                    return;

                    /*" -630- ELSE */
                }
                else
                {


                    /*" -634- GO TO 120-000-LER-DESCR. */

                    M_120_000_LER_DESCR_SECTION(); //GOTO
                    return;
                }

            }


            /*" -634- ADD 1 TO WCT-LIDOS. */
            WCT_LIDOS.Value = WCT_LIDOS + 1;

        }

        [StopWatch]
        /*" M-120-010-DB-FETCH-1 */
        public void M_120_010_DB_FETCH_1()
        {
            /*" -621- EXEC SQL FETCH DESCR INTO :THIST-APOL-SINI, :THIST-OPERACAO, :THIST-DTMOVTO, :THIST-VAL-OPERACAO, :THIST-SITUACAO, :THIST-LIMCRR, :TMEST-FONTE END-EXEC. */

            if (DESCR.Fetch())
            {
                _.Move(DESCR.THIST_APOL_SINI, THIST_APOL_SINI);
                _.Move(DESCR.THIST_OPERACAO, THIST_OPERACAO);
                _.Move(DESCR.THIST_DTMOVTO, THIST_DTMOVTO);
                _.Move(DESCR.THIST_VAL_OPERACAO, THIST_VAL_OPERACAO);
                _.Move(DESCR.THIST_SITUACAO, THIST_SITUACAO);
                _.Move(DESCR.THIST_LIMCRR, THIST_LIMCRR);
                _.Move(DESCR.TMEST_FONTE, TMEST_FONTE);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-140-000-PROCESSA-SECTION */
        private void M_140_000_PROCESSA_SECTION()
        {
            /*" -646- MOVE '140-000-PROCESSA' TO PARAGRAFO. */
            _.Move("140-000-PROCESSA", W.WABEND.PARAGRAFO);

            /*" -648- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", W.WABEND.WNR_EXEC_SQL);

            /*" -649- IF TMEST-FONTE EQUAL WFONTE-ANT */

            if (TMEST_FONTE == WFONTE_ANT)
            {

                /*" -650- PERFORM 150-000-CHECA-CORRECAO */

                M_150_000_CHECA_CORRECAO_SECTION();

                /*" -651- IF THIST-APOL-SINI NOT EQUAL WSINISTRO-ANT */

                if (THIST_APOL_SINI != WSINISTRO_ANT)
                {

                    /*" -652- ADD 1 TO WQTDSIN */
                    WQTDSIN.Value = WQTDSIN + 1;

                    /*" -653- MOVE THIST-APOL-SINI TO WSINISTRO-ANT */
                    _.Move(THIST_APOL_SINI, WSINISTRO_ANT);

                    /*" -655- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -656- ELSE */
                }

            }
            else
            {


                /*" -658- PERFORM 145-000-QUEBRA. */

                M_145_000_QUEBRA_SECTION();
            }


            /*" -659- IF W-MOEDA-ATU NOT EQUAL W-MOEDA-ANT */

            if (W_MOEDA_ATU != W_MOEDA_ANT)
            {

                /*" -661- PERFORM 145-000-QUEBRA. */

                M_145_000_QUEBRA_SECTION();
            }


            /*" -661- PERFORM 120-000-LER-DESCR. */

            M_120_000_LER_DESCR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_140_999_EXIT*/

        [StopWatch]
        /*" M-145-000-QUEBRA-SECTION */
        private void M_145_000_QUEBRA_SECTION()
        {
            /*" -674- MOVE '145-000-QUEBRA' TO PARAGRAFO. */
            _.Move("145-000-QUEBRA", W.WABEND.PARAGRAFO);

            /*" -677- MOVE '145' TO WNR-EXEC-SQL. */
            _.Move("145", W.WABEND.WNR_EXEC_SQL);

            /*" -678- PERFORM 180-000-LER-TGEFONTE */

            M_180_000_LER_TGEFONTE_SECTION();

            /*" -679- PERFORM 200-000-IMPRIME */

            M_200_000_IMPRIME_SECTION();

            /*" -680- MOVE TMEST-FONTE TO WFONTE-ANT */
            _.Move(TMEST_FONTE, WFONTE_ANT);

            /*" -681- MOVE THIST-APOL-SINI TO WSINISTRO-ANT */
            _.Move(THIST_APOL_SINI, WSINISTRO_ANT);

            /*" -682- MOVE W-MOEDA-ATU TO W-MOEDA-ANT */
            _.Move(W_MOEDA_ATU, W_MOEDA_ANT);

            /*" -683- MOVE ZEROS TO WACVALBT */
            _.Move(0, WACVALBT);

            /*" -684- MOVE ZEROS TO WACVALCR */
            _.Move(0, WACVALCR);

            /*" -685- MOVE ZEROS TO WQTDSIN */
            _.Move(0, WQTDSIN);

            /*" -686- ADD 1 TO WQTDSIN */
            WQTDSIN.Value = WQTDSIN + 1;

            /*" -687- MOVE W-MOEDA-ATU TO W-MOEDA-ANT */
            _.Move(W_MOEDA_ATU, W_MOEDA_ANT);

            /*" -687- PERFORM 150-000-CHECA-CORRECAO. */

            M_150_000_CHECA_CORRECAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_145_999_EXIT*/

        [StopWatch]
        /*" M-150-000-CHECA-CORRECAO-SECTION */
        private void M_150_000_CHECA_CORRECAO_SECTION()
        {
            /*" -700- MOVE '150-000-CHECA-CORRECAO' TO PARAGRAFO. */
            _.Move("150-000-CHECA-CORRECAO", W.WABEND.PARAGRAFO);

            /*" -704- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", W.WABEND.WNR_EXEC_SQL);

            /*" -707- IF TMEST-FONTE EQUAL WFONTE-ANT AND THIST-APOL-SINI EQUAL WSINISTRO-ANT NEXT SENTENCE */

            if (TMEST_FONTE == WFONTE_ANT && THIST_APOL_SINI == WSINISTRO_ANT)
            {

                /*" -708- ELSE */
            }
            else
            {


                /*" -709- PERFORM 600-000-CALCULA-VALOR */

                M_600_000_CALCULA_VALOR_SECTION();

                /*" -710- ADD WQTD-MOEDA TO WACVALBT */
                WACVALBT.Value = WACVALBT + WQTD_MOEDA;

                /*" -710- ADD WVALCR TO WACVALCR. */
                WACVALCR.Value = WACVALCR + WVALCR;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-180-000-LER-TGEFONTE-SECTION */
        private void M_180_000_LER_TGEFONTE_SECTION()
        {
            /*" -722- MOVE '180-000-LER-TGEFONTE' TO PARAGRAFO. */
            _.Move("180-000-LER-TGEFONTE", W.WABEND.PARAGRAFO);

            /*" -724- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", W.WABEND.WNR_EXEC_SQL);

            /*" -726- MOVE WFONTE-ANT TO WH-FONTE. */
            _.Move(WFONTE_ANT, WH_FONTE);

            /*" -731- PERFORM M_180_000_LER_TGEFONTE_DB_SELECT_1 */

            M_180_000_LER_TGEFONTE_DB_SELECT_1();

            /*" -734- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -735- DISPLAY 'FONTE = ' TMEST-FONTE */
                _.Display($"FONTE = {TMEST_FONTE}");

                /*" -735- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-180-000-LER-TGEFONTE-DB-SELECT-1 */
        public void M_180_000_LER_TGEFONTE_DB_SELECT_1()
        {
            /*" -731- EXEC SQL SELECT NOMEFTE, FONTE INTO :TGEFON-NOMEFTE, :TGEFON-FONTE FROM SEGUROS.V1FONTE WHERE FONTE = :WH-FONTE END-EXEC. */

            var m_180_000_LER_TGEFONTE_DB_SELECT_1_Query1 = new M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1()
            {
                WH_FONTE = WH_FONTE.ToString(),
            };

            var executed_1 = M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1.Execute(m_180_000_LER_TGEFONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TGEFON_NOMEFTE, TGEFON_NOMEFTE);
                _.Move(executed_1.TGEFON_FONTE, TGEFON_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_180_999_EXIT*/

        [StopWatch]
        /*" M-200-000-IMPRIME-SECTION */
        private void M_200_000_IMPRIME_SECTION()
        {
            /*" -749- MOVE '200-000-IMPRIME' TO PARAGRAFO. */
            _.Move("200-000-IMPRIME", W.WABEND.PARAGRAFO);

            /*" -751- IF TMEST-FONTE EQUAL WFONTE-ANT AND THIST-APOL-SINI NOT EQUAL WSINISTRO-ANT */

            if (TMEST_FONTE == WFONTE_ANT && THIST_APOL_SINI != WSINISTRO_ANT)
            {

                /*" -753- ADD 1 TO WQTDSIN. */
                WQTDSIN.Value = WQTDSIN + 1;
            }


            /*" -755- ADD 1 TO WCT-IMPRES */
            WCT_IMPRES.Value = WCT_IMPRES + 1;

            /*" -756- IF WLINHA GREATER 60 */

            if (WLINHA > 60)
            {

                /*" -758- PERFORM 300-000-CABEC. */

                M_300_000_CABEC_SECTION();
            }


            /*" -759- MOVE WFONTE-ANT TO LC07-FONTE */
            _.Move(WFONTE_ANT, W.LC07.LC07_FONTE);

            /*" -760- MOVE TGEFON-NOMEFTE TO LC07-NOMEFTE */
            _.Move(TGEFON_NOMEFTE, W.LC07.LC07_NOMEFTE);

            /*" -761- MOVE WQTDSIN TO LC07-QTDESIN */
            _.Move(WQTDSIN, W.LC07.LC07_QTDESIN);

            /*" -762- MOVE WACVALBT TO LC07-VLTOTBT */
            _.Move(WACVALBT, W.LC07.LC07_VLTOTBT);

            /*" -765- MOVE WACVALCR TO LC07-VLTOTCR */
            _.Move(WACVALCR, W.LC07.LC07_VLTOTCR);

            /*" -766- ADD WQTDSIN TO WACTOTSIN */
            WACTOTSIN.Value = WACTOTSIN + WQTDSIN;

            /*" -767- ADD WACVALBT TO WACTOTBT */
            WACTOTBT.Value = WACTOTBT + WACVALBT;

            /*" -769- ADD WACVALCR TO WACTOTCR */
            WACTOTCR.Value = WACTOTCR + WACVALCR;

            /*" -771- WRITE REG-RELAT FROM LC07 AFTER 2 */
            _.Move(W.LC07.GetMoveValues(), REG_RELAT);

            RELATORIO.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -771- ADD 2 TO WLINHA. */
            WLINHA.Value = WLINHA + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_999_EXIT*/

        [StopWatch]
        /*" M-300-000-CABEC-SECTION */
        private void M_300_000_CABEC_SECTION()
        {
            /*" -785- MOVE '300-000-CABEC' TO PARAGRAFO. */
            _.Move("300-000-CABEC", W.WABEND.PARAGRAFO);

            /*" -787- ADD 1 TO WFOLHA */
            WFOLHA.Value = WFOLHA + 1;

            /*" -789- MOVE WFOLHA TO LC01-PAG. */
            _.Move(WFOLHA, W.LC01.LC01_PAG);

            /*" -791- WRITE REG-RELAT FROM LC01 AFTER NEW-PAGE. */
            _.Move(W.LC01.GetMoveValues(), REG_RELAT);

            RELATORIO.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -793- WRITE REG-RELAT FROM LC02 AFTER 1. */
            _.Move(W.LC02.GetMoveValues(), REG_RELAT);

            RELATORIO.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -795- WRITE REG-RELAT FROM LC03 AFTER 1. */
            _.Move(W.LC03.GetMoveValues(), REG_RELAT);

            RELATORIO.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -797- WRITE REG-RELAT FROM LC04 AFTER 1. */
            _.Move(W.LC04.GetMoveValues(), REG_RELAT);

            RELATORIO.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -799- WRITE REG-RELAT FROM LC05 AFTER 1. */
            _.Move(W.LC05.GetMoveValues(), REG_RELAT);

            RELATORIO.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -801- WRITE REG-RELAT FROM LC06 AFTER 1. */
            _.Move(W.LC06.GetMoveValues(), REG_RELAT);

            RELATORIO.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -804- WRITE REG-RELAT FROM LC05 AFTER 1. */
            _.Move(W.LC05.GetMoveValues(), REG_RELAT);

            RELATORIO.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -804- MOVE 6 TO WLINHA. */
            _.Move(6, WLINHA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-400-000-FINAL-SECTION */
        private void M_400_000_FINAL_SECTION()
        {
            /*" -817- MOVE '400-000-FINAL' TO PARAGRAFO. */
            _.Move("400-000-FINAL", W.WABEND.PARAGRAFO);

            /*" -819- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", W.WABEND.WNR_EXEC_SQL);

            /*" -819- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -825- CLOSE RELATORIO. */
            RELATORIO.Close();

            /*" -826- DISPLAY 'TOTAL DE REGS LIDOS     = ' WCT-LIDOS */
            _.Display($"TOTAL DE REGS LIDOS     = {WCT_LIDOS}");

            /*" -828- DISPLAY 'TOTAL DE REGS IMPRESSOS = ' WCT-IMPRES */
            _.Display($"TOTAL DE REGS IMPRESSOS = {WCT_IMPRES}");

            /*" -829- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -831- DISPLAY 'SI0108B        *** FIM NORMAL ***' . */
            _.Display($"SI0108B        *** FIM NORMAL ***");

            /*" -831- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-500-000-DELETE-V0RELATORIOS-SECTION */
        private void M_500_000_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -842- MOVE '500-000-DELETE-V0RELATORIOS' TO PARAGRAFO. */
            _.Move("500-000-DELETE-V0RELATORIOS", W.WABEND.PARAGRAFO);

            /*" -844- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", W.WABEND.WNR_EXEC_SQL);

            /*" -850- PERFORM M_500_000_DELETE_V0RELATORIOS_DB_DELETE_1 */

            M_500_000_DELETE_V0RELATORIOS_DB_DELETE_1();

        }

        [StopWatch]
        /*" M-500-000-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void M_500_000_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -850- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0108B' AND DATA_SOLICITACAO = :TSISTEM-DTMOVABE END-EXEC. */

            var m_500_000_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new M_500_000_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
                TSISTEM_DTMOVABE = TSISTEM_DTMOVABE.ToString(),
            };

            M_500_000_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(m_500_000_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_999_EXIT*/

        [StopWatch]
        /*" M-600-000-CALCULA-VALOR-SECTION */
        private void M_600_000_CALCULA_VALOR_SECTION()
        {
            /*" -865- PERFORM 620-000-LER-TMESTSINI. */

            M_620_000_LER_TMESTSINI_SECTION();

            /*" -869- MOVE MEST-COD-MD-SINI TO WGEUNIMO-CODUNIMO W-MOEDA-ATU WMOEDA. */
            _.Move(MEST_COD_MD_SINI, WGEUNIMO_CODUNIMO, W_MOEDA_ATU, WMOEDA);

            /*" -872- MOVE THIST-DTMOVTO TO WGEUNIMO-DTINIVIG WGEUNIMO-DTTERVIG. */
            _.Move(THIST_DTMOVTO, WGEUNIMO_DTINIVIG, WGEUNIMO_DTTERVIG);

            /*" -874- PERFORM 610-000-LER-TGEUNIMO. */

            M_610_000_LER_TGEUNIMO_SECTION();

            /*" -878- COMPUTE WQTD-MOEDA = THIST-VAL-OPERACAO / GEUNIMO-VLCRUZAD. */
            WQTD_MOEDA.Value = THIST_VAL_OPERACAO / GEUNIMO_VLCRUZAD;

            /*" -881- MOVE TSISTEM-DTMOVABE TO WGEUNIMO-DTINIVIG WGEUNIMO-DTTERVIG. */
            _.Move(TSISTEM_DTMOVABE, WGEUNIMO_DTINIVIG, WGEUNIMO_DTTERVIG);

            /*" -883- PERFORM 610-000-LER-TGEUNIMO. */

            M_610_000_LER_TGEUNIMO_SECTION();

            /*" -884- COMPUTE WVALCR = WQTD-MOEDA * GEUNIMO-VLCRUZAD. */
            WVALCR.Value = WQTD_MOEDA * GEUNIMO_VLCRUZAD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_EXIT*/

        [StopWatch]
        /*" M-610-000-LER-TGEUNIMO-SECTION */
        private void M_610_000_LER_TGEUNIMO_SECTION()
        {
            /*" -895- MOVE '610' TO WNR-EXEC-SQL */
            _.Move("610", W.WABEND.WNR_EXEC_SQL);

            /*" -898- MOVE '610-000-LER-TGEUNIMO' TO PARAGRAFO. */
            _.Move("610-000-LER-TGEUNIMO", W.WABEND.PARAGRAFO);

            /*" -907- PERFORM M_610_000_LER_TGEUNIMO_DB_SELECT_1 */

            M_610_000_LER_TGEUNIMO_DB_SELECT_1();

            /*" -910- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -914- DISPLAY 'SI0108B  - NAO CONSTA REGISTRO NA V1MOEDA ' ' - CODUNIMO = ' WMOEDA ' - DTINIVIG = ' WGEUNIMO-DTINIVIG ' - DTTERVIG = ' WGEUNIMO-DTTERVIG */

                $"SI0108B  - NAO CONSTA REGISTRO NA V1MOEDA  - CODUNIMO = {WMOEDA} - DTINIVIG = {WGEUNIMO_DTINIVIG} - DTTERVIG = {WGEUNIMO_DTTERVIG}"
                .Display();

                /*" -915- MOVE 'XXXXXX' TO GEUNIMO-SIGLUNIM */
                _.Move("XXXXXX", GEUNIMO_SIGLUNIM);

                /*" -916- MOVE 1 TO GEUNIMO-VLCRUZAD */
                _.Move(1, GEUNIMO_VLCRUZAD);

                /*" -921- GO TO 610-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_610_999_EXIT*/ //GOTO
                return;
            }


            /*" -921- MOVE GEUNIMO-SIGLUNIM TO LC07-MOEDA. */
            _.Move(GEUNIMO_SIGLUNIM, W.LC07.LC07_MOEDA);

        }

        [StopWatch]
        /*" M-610-000-LER-TGEUNIMO-DB-SELECT-1 */
        public void M_610_000_LER_TGEUNIMO_DB_SELECT_1()
        {
            /*" -907- EXEC SQL SELECT VLCRUZAD, SIGLUNIM INTO :GEUNIMO-VLCRUZAD, :GEUNIMO-SIGLUNIM FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :WMOEDA AND DTINIVIG <= :WGEUNIMO-DTINIVIG AND DTTERVIG >= :WGEUNIMO-DTTERVIG END-EXEC. */

            var m_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1 = new M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1()
            {
                WGEUNIMO_DTINIVIG = WGEUNIMO_DTINIVIG.ToString(),
                WGEUNIMO_DTTERVIG = WGEUNIMO_DTTERVIG.ToString(),
                WMOEDA = WMOEDA.ToString(),
            };

            var executed_1 = M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1.Execute(m_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEUNIMO_VLCRUZAD, GEUNIMO_VLCRUZAD);
                _.Move(executed_1.GEUNIMO_SIGLUNIM, GEUNIMO_SIGLUNIM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_610_999_EXIT*/

        [StopWatch]
        /*" M-620-000-LER-TMESTSINI-SECTION */
        private void M_620_000_LER_TMESTSINI_SECTION()
        {
            /*" -932- MOVE '620' TO WNR-EXEC-SQL */
            _.Move("620", W.WABEND.WNR_EXEC_SQL);

            /*" -935- MOVE '620-000-LER-TMESTSINI' TO PARAGRAFO. */
            _.Move("620-000-LER-TMESTSINI", W.WABEND.PARAGRAFO);

            /*" -940- PERFORM M_620_000_LER_TMESTSINI_DB_SELECT_1 */

            M_620_000_LER_TMESTSINI_DB_SELECT_1();

            /*" -943- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -945- DISPLAY 'SI0108B  - NAO CONSTA NO MESTRE' ' - APOLICE ===> ' THIST-APOL-SINI */

                $"SI0108B  - NAO CONSTA NO MESTRE - APOLICE ===> {THIST_APOL_SINI}"
                .Display();

                /*" -946- MOVE 9999 TO MEST-COD-MD-SINI */
                _.Move(9999, MEST_COD_MD_SINI);

                /*" -951- GO TO 620-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_620_999_EXIT*/ //GOTO
                return;
            }


            /*" -951- MOVE MEST-COD-MD-SINI TO W-MOEDA-ANT. */
            _.Move(MEST_COD_MD_SINI, W_MOEDA_ANT);

        }

        [StopWatch]
        /*" M-620-000-LER-TMESTSINI-DB-SELECT-1 */
        public void M_620_000_LER_TMESTSINI_DB_SELECT_1()
        {
            /*" -940- EXEC SQL SELECT COD_MOEDA_SINI INTO :MEST-COD-MD-SINI FROM SEGUROS.V1MESTSINI WHERE NUM_APOL_SINISTRO = :THIST-APOL-SINI END-EXEC. */

            var m_620_000_LER_TMESTSINI_DB_SELECT_1_Query1 = new M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1()
            {
                THIST_APOL_SINI = THIST_APOL_SINI.ToString(),
            };

            var executed_1 = M_620_000_LER_TMESTSINI_DB_SELECT_1_Query1.Execute(m_620_000_LER_TMESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MEST_COD_MD_SINI, MEST_COD_MD_SINI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_620_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -962- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -963- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -964- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W.WABEND.WSQLCODE1);

                /*" -965- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W.WABEND.WSQLCODE2);

                /*" -966- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, WSQLCODE3);

                /*" -967- ELSE */
            }
            else
            {


                /*" -968- MOVE 999 TO WSQLCODE3. */
                _.Move(999, WSQLCODE3);
            }


            /*" -970- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -972- CLOSE RELATORIO. */
            RELATORIO.Close();

            /*" -972- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -973- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -975- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -975- GOBACK. */

            throw new GoBack();

        }
    }
}