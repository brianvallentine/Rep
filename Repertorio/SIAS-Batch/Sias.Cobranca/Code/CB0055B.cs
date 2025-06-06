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
using Sias.Cobranca.DB2.CB0055B;

namespace Code
{
    public class CB0055B
    {
        public bool IsCall { get; set; }

        public CB0055B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB0055B                                   */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FLAVIO PIRES                       *      */
        /*"      *   PROGRAMADOR ............  FLAVIO PIRES                       *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO/1995                         *      */
        /*"      *   DATA ALTERACAO .........                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ACERTO DOS ADIANTAMENTOS DE COMIS- *      */
        /*"      *                             SAO DOS BILHETES SASSE FACIL       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * ENDOSSO                             V1ENDOSSO         INPUT    *      */
        /*"      * COMISSAO_ADIANTA                    V0ADIANTA         OUTPUT   *      */
        /*"      * RECUPERA_ADIANTA                    V0FORMAREC        OUTPUT   *      */
        /*"      * HISTORICO_RECUPERACAO               V0HISTOREC        OUTPUT   *      */
        /*"      * NUMERO_OUTROS                       V0NUMERO_OUTROS   I-O      *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              04/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           09/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77           WHOST-DTINIVIG    PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           WHOST-DATA        PIC  X(010).*/
        public StringBasis WHOST_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           WHOST-NUM-APOL    PIC S9(013)  VALUE +0  COMP-3.*/
        public IntBasis WHOST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ADIA-CODPDT        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-FONTE         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ADIA-NUMOPG        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-VALADT        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0ADIA_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0ADIA-QTPRESTA      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ADIA-NRPROPOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-NUM-APOL      PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0ADIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ADIA-NRENDOS       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-NRPARCEL      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ADIA-DTMOVTO       PIC  X(010).*/
        public StringBasis V0ADIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ADIA-SITUACAO      PIC  X(001).*/
        public StringBasis V0ADIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ADIA-COD-EMP       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0ADIA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ADIA-TIMESTAMP     PIC  X(026).*/
        public StringBasis V0ADIA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0ADIA-TIPO-ADT      PIC  X(001).*/
        public StringBasis V0ADIA_TIPO_ADT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FORM-CODPDT        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-FONTE         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0FORM_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FORM-NUMOPG        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-NRPROPOS      PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-NUM-APOL      PIC S9(013)      VALUE +0 COMP-3*/
        public IntBasis V0FORM_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0FORM-NRENDOS       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-NRPARCEL      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FORM-NUMPTC        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0FORM_NUMPTC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FORM-VALRCP        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0FORM_VALRCP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0FORM-PCGACM        PIC S9(002)V9(3) VALUE +0 COMP-3*/
        public DoubleBasis V0FORM_PCGACM { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V9(3)"), 3);
        /*"77         V0FORM-SITUACAO      PIC  X(001).*/
        public StringBasis V0FORM_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FORM-VALSDO        PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0FORM_VALSDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0FORM-DTMOVTO       PIC  X(010).*/
        public StringBasis V0FORM_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FORM-DTVENCTO      PIC  X(010).*/
        public StringBasis V0FORM_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FORM-COD-EMP       PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0FORM_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FORM-TIMESTAMP     PIC  X(026).*/
        public StringBasis V0FORM_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0HISR-CODPDT        PIC S9(009)               COMP.*/
        public IntBasis V0HISR_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-FONTE         PIC S9(004)               COMP.*/
        public IntBasis V0HISR_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISR-NUMOPG        PIC S9(009)               COMP.*/
        public IntBasis V0HISR_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-NRPROPOS      PIC S9(009)               COMP.*/
        public IntBasis V0HISR_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-NUM-APOL      PIC S9(013)               COMP-3*/
        public IntBasis V0HISR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HISR-NRENDOS       PIC S9(009)               COMP.*/
        public IntBasis V0HISR_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-NRPARCEL      PIC S9(004)               COMP.*/
        public IntBasis V0HISR_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISR-NUMPTC        PIC S9(004)               COMP.*/
        public IntBasis V0HISR_NUMPTC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISR-VALRCP        PIC S9(013)V99            COMP-3*/
        public DoubleBasis V0HISR_VALRCP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HISR-NUMREC        PIC S9(009)               COMP.*/
        public IntBasis V0HISR_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-DTMOVTO       PIC  X(010).*/
        public StringBasis V0HISR_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISR-OPERACAO      PIC S9(004)               COMP.*/
        public IntBasis V0HISR_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISR-HORSIS        PIC  X(008).*/
        public StringBasis V0HISR_HORSIS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0HISR-COD-EMP       PIC S9(009)               COMP.*/
        public IntBasis V0HISR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISR-TIMESTAMP     PIC  X(026).*/
        public StringBasis V0HISR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1ENDO-NUM-APOL      PIC S9(013)               COMP-3*/
        public IntBasis V1ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1ENDO-NUMBIL        PIC S9(015)               COMP-3*/
        public IntBasis V1ENDO_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1ADIA-NUMOPG        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V1ADIA_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01           AREA-DE-WORK.*/
        public CB0055B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB0055B_AREA_DE_WORK();
        public class CB0055B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WRESTO            PIC S9(003)    VALUE +0   COMP-3.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         WCH-DUPLICADO     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WCH_DUPLICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WWORK-NUMBIL      PIC  9(015)    VALUE ZEROS.*/
            public IntBasis WWORK_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUMBIL.*/
            private _REDEF_CB0055B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_CB0055B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_CB0055B_FILLER_0(); _.Move(WWORK_NUMBIL, _filler_0); VarBasis.RedefinePassValue(WWORK_NUMBIL, _filler_0, WWORK_NUMBIL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WWORK_NUMBIL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WWORK_NUMBIL); }
            }  //Redefines
            public class _REDEF_CB0055B_FILLER_0 : VarBasis
            {
                /*"    10       FILLER            PIC  9(004).*/
                public IntBasis FILLER_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-NRRCAP      PIC  9(009).*/
                public IntBasis WWORK_NRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       WWORK-DIGITO      PIC  9(002).*/
                public IntBasis WWORK_DIGITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         AC-L-ENDOSSO      PIC  9(007)    VALUE ZEROS.*/

                public _REDEF_CB0055B_FILLER_0()
                {
                    FILLER_1.ValueChanged += OnValueChanged;
                    WWORK_NRRCAP.ValueChanged += OnValueChanged;
                    WWORK_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AC_L_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-ADIANTA      PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_ADIANTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-DISPLAY      PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_DISPLAY { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-U-V0FORMAREC   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_U_V0FORMAREC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-U-V0HISTOREC   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_U_V0HISTOREC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-U-V0ADIANTA    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_U_V0ADIANTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-ENDOSSO      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-ADIANTA      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_ADIANTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WWORK-VALADT      PIC S9(013)V99 VALUE +0    COMP-3*/
            public DoubleBasis WWORK_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WTIME-DAY         PIC  99.99.99.99.*/
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05         FILLER            REDEFINES      WTIME-DAY.*/
            private _REDEF_CB0055B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_CB0055B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_CB0055B_FILLER_2(); _.Move(WTIME_DAY, _filler_2); VarBasis.RedefinePassValue(WTIME_DAY, _filler_2, WTIME_DAY); _filler_2.ValueChanged += () => { _.Move(_filler_2, WTIME_DAY); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_CB0055B_FILLER_2 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public CB0055B_WTIME_DAYR WTIME_DAYR { get; set; } = new CB0055B_WTIME_DAYR();
                public class CB0055B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA        PIC  9(002).*/
                    public IntBasis WTIME_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     WTIME-2PT1        PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU        PIC  9(002).*/
                    public IntBasis WTIME_MINU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     WTIME-2PT2        PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU        PIC  9(002).*/
                    public IntBasis WTIME_SEGU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       WTIME-2PT3        PIC  X(001).*/

                    public CB0055B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSG        PIC  9(002).*/
                public IntBasis WTIME_CCSG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WS-TIME.*/

                public _REDEF_CB0055B_FILLER_2()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSG.ValueChanged += OnValueChanged;
                }

            }
            public CB0055B_WS_TIME WS_TIME { get; set; } = new CB0055B_WS_TIME();
            public class CB0055B_WS_TIME : VarBasis
            {
                /*"    10       WS-HH-TIME        PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-MM-TIME        PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-SS-TIME        PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-CC-TIME        PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WHORA-SQL.*/
            }
            public CB0055B_WHORA_SQL WHORA_SQL { get; set; } = new CB0055B_WHORA_SQL();
            public class CB0055B_WHORA_SQL : VarBasis
            {
                /*"    10       WHORA-SQL-HH      PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WHORA_SQL_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER1           PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SQL-MM      PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WHORA_SQL_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER2           PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SQL-SS      PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WHORA_SQL_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WNR-AVISO         PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WNR_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WNR-AVISO.*/
            private _REDEF_CB0055B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_CB0055B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_CB0055B_FILLER_3(); _.Move(WNR_AVISO, _filler_3); VarBasis.RedefinePassValue(WNR_AVISO, _filler_3, WNR_AVISO); _filler_3.ValueChanged += () => { _.Move(_filler_3, WNR_AVISO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WNR_AVISO); }
            }  //Redefines
            public class _REDEF_CB0055B_FILLER_3 : VarBasis
            {
                /*"    10       WNR-AVS-ANO       PIC  9(004).*/
                public IntBasis WNR_AVS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WNR-AVS-MES       PIC  9(002).*/
                public IntBasis WNR_AVS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WNR-AVS-DIA       PIC  9(002).*/
                public IntBasis WNR_AVS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WAVISO            PIC  9(004)    VALUE ZEROS.*/

                public _REDEF_CB0055B_FILLER_3()
                {
                    WNR_AVS_ANO.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WNR_AVS_MES.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WNR_AVS_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         FILLER            REDEFINES      WAVISO.*/
            private _REDEF_CB0055B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_CB0055B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_CB0055B_FILLER_6(); _.Move(WAVISO, _filler_6); VarBasis.RedefinePassValue(WAVISO, _filler_6, WAVISO); _filler_6.ValueChanged += () => { _.Move(_filler_6, WAVISO); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WAVISO); }
            }  //Redefines
            public class _REDEF_CB0055B_FILLER_6 : VarBasis
            {
                /*"    10       WAVIS-DIA         PIC  9(002).*/
                public IntBasis WAVIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WAVIS-MES         PIC  9(002).*/
                public IntBasis WAVIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_CB0055B_FILLER_6()
                {
                    WAVIS_DIA.ValueChanged += OnValueChanged;
                    WAVIS_MES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_CB0055B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_CB0055B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_CB0055B_FILLER_7(); _.Move(WDATA_REL, _filler_7); VarBasis.RedefinePassValue(WDATA_REL, _filler_7, WDATA_REL); _filler_7.ValueChanged += () => { _.Move(_filler_7, WDATA_REL); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB0055B_FILLER_7 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDAT-REL-LIT.*/

                public _REDEF_CB0055B_FILLER_7()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB0055B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new CB0055B_WDAT_REL_LIT();
            public class CB0055B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WDATA-TABELA.*/
            }
            public CB0055B_WDATA_TABELA WDATA_TABELA { get; set; } = new CB0055B_WDATA_TABELA();
            public class CB0055B_WDATA_TABELA : VarBasis
            {
                /*"    10       WDAT-TAB-ANO      PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WDAT_TAB_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-TAB-MES      PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDAT_TAB_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-TAB-DIA      PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDAT_TAB_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-FITA.*/
            }
            public CB0055B_WDATA_FITA WDATA_FITA { get; set; } = new CB0055B_WDATA_FITA();
            public class CB0055B_WDATA_FITA : VarBasis
            {
                /*"    10       WDAT-FITA-DIA     PIC  X(002).*/
                public StringBasis WDAT_FITA_DIA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WDAT-FITA-MES     PIC  X(002).*/
                public StringBasis WDAT_FITA_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WDAT-FITA-ANO     PIC  X(004).*/
                public StringBasis WDAT_FITA_ANO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05         WS000-DATA        PIC  X(010).*/
            }
            public StringBasis WS000_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         FILLER            REDEFINES      WS000-DATA.*/
            private _REDEF_CB0055B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_CB0055B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_CB0055B_FILLER_14(); _.Move(WS000_DATA, _filler_14); VarBasis.RedefinePassValue(WS000_DATA, _filler_14, WS000_DATA); _filler_14.ValueChanged += () => { _.Move(_filler_14, WS000_DATA); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WS000_DATA); }
            }  //Redefines
            public class _REDEF_CB0055B_FILLER_14 : VarBasis
            {
                /*"    10       WS000-ANO         PIC  9(004).*/
                public IntBasis WS000_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS000-T1          PIC  X(001).*/
                public StringBasis WS000_T1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS000-MES         PIC  9(002).*/
                public IntBasis WS000_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS000-T2          PIC  X(001).*/
                public StringBasis WS000_T2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS000-DIA         PIC  9(002).*/
                public IntBasis WS000_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WS001-DATA.*/

                public _REDEF_CB0055B_FILLER_14()
                {
                    WS000_ANO.ValueChanged += OnValueChanged;
                    WS000_T1.ValueChanged += OnValueChanged;
                    WS000_MES.ValueChanged += OnValueChanged;
                    WS000_T2.ValueChanged += OnValueChanged;
                    WS000_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB0055B_WS001_DATA WS001_DATA { get; set; } = new CB0055B_WS001_DATA();
            public class CB0055B_WS001_DATA : VarBasis
            {
                /*"    10       WS001-DIA         PIC  9(002).*/
                public IntBasis WS001_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS001-MES         PIC  9(002).*/
                public IntBasis WS001_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS001-ANO         PIC  9(004).*/
                public IntBasis WS001_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05        WABEND.*/
            }
            public CB0055B_WABEND WABEND { get; set; } = new CB0055B_WABEND();
            public class CB0055B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(009) VALUE           'CB0055B '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"CB0055B ");
                /*"    10      FILLER              PIC  X(035) VALUE           ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public CB0055B_V1ENDOSSO V1ENDOSSO { get; set; } = new CB0055B_V1ENDOSSO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -307- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -308- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -311- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -314- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -314- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -323- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -324- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -326- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -328- MOVE V1SIST-DTMOVABE TO WHOST-DTINIVIG. */
            _.Move(V1SIST_DTMOVABE, WHOST_DTINIVIG);

            /*" -329- PERFORM R0900-00-DECLARE-ENDOSSO */

            R0900_00_DECLARE_ENDOSSO_SECTION();

            /*" -330- PERFORM R0910-00-FETCH-ENDOSSO */

            R0910_00_FETCH_ENDOSSO_SECTION();

            /*" -331- IF WFIM-ENDOSSO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_ENDOSSO.IsEmpty())
            {

                /*" -332- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -335- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -338- PERFORM R1000-00-PROCESSA UNTIL WFIM-ENDOSSO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_ENDOSSO.IsEmpty()))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -338- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -343- DISPLAY 'REGISTROS LIDOS           ' */
            _.Display($"REGISTROS LIDOS           ");

            /*" -344- DISPLAY '. ENDOSSO ..............  ' AC-L-ENDOSSO */
            _.Display($". ENDOSSO ..............  {AREA_DE_WORK.AC_L_ENDOSSO}");

            /*" -345- DISPLAY '. ADIANTA ..............  ' AC-L-ADIANTA */
            _.Display($". ADIANTA ..............  {AREA_DE_WORK.AC_L_ADIANTA}");

            /*" -346- DISPLAY 'REGISTROS INSERIDOS       ' */
            _.Display($"REGISTROS INSERIDOS       ");

            /*" -347- DISPLAY '. ADIANTAMENTOS FENAE...  ' AC-U-V0ADIANTA */
            _.Display($". ADIANTAMENTOS FENAE...  {AREA_DE_WORK.AC_U_V0ADIANTA}");

            /*" -348- DISPLAY '. FORMA RECUPERACAO.....  ' AC-U-V0FORMAREC */
            _.Display($". FORMA RECUPERACAO.....  {AREA_DE_WORK.AC_U_V0FORMAREC}");

            /*" -349- DISPLAY '. HISTORICO RECUPERACAO.  ' AC-U-V0HISTOREC */
            _.Display($". HISTORICO RECUPERACAO.  {AREA_DE_WORK.AC_U_V0HISTOREC}");

            /*" -350- DISPLAY '......................... ' */
            _.Display($"......................... ");

            /*" -352- DISPLAY 'CB0055B - FIM NORMAL' . */
            _.Display($"CB0055B - FIM NORMAL");

            /*" -354- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -354- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -367- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -372- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -375- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -376- DISPLAY 'CB0055B - SISTEMA DE COBRANCA NAO CADASTRADO' */
                _.Display($"CB0055B - SISTEMA DE COBRANCA NAO CADASTRADO");

                /*" -377- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                /*" -379- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -380- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -381- DISPLAY 'CB0055B - PROBLEMAS NO SELECT (V1SISTEMA) ' */
                _.Display($"CB0055B - PROBLEMAS NO SELECT (V1SISTEMA) ");

                /*" -383- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -384- MOVE V1SIST-DTMOVABE TO WNR-AVISO */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WNR_AVISO);

            /*" -385- MOVE WNR-AVS-DIA TO WAVIS-DIA */
            _.Move(AREA_DE_WORK.FILLER_3.WNR_AVS_DIA, AREA_DE_WORK.FILLER_6.WAVIS_DIA);

            /*" -385- MOVE WNR-AVS-MES TO WAVIS-MES. */
            _.Move(AREA_DE_WORK.FILLER_3.WNR_AVS_MES, AREA_DE_WORK.FILLER_6.WAVIS_MES);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -372- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-ENDOSSO-SECTION */
        private void R0900_00_DECLARE_ENDOSSO_SECTION()
        {
            /*" -398- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -399- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -402- DISPLAY 'INICIO DO DECLARE ENDOSSO ... HORA..' WS-TIME ' DATA SISTEMA = ' WHOST-DTINIVIG. */

            $"INICIO DO DECLARE ENDOSSO ... HORA..{AREA_DE_WORK.WS_TIME} DATA SISTEMA = {WHOST_DTINIVIG}"
            .Display();

            /*" -410- PERFORM R0900_00_DECLARE_ENDOSSO_DB_DECLARE_1 */

            R0900_00_DECLARE_ENDOSSO_DB_DECLARE_1();

            /*" -412- PERFORM R0900_00_DECLARE_ENDOSSO_DB_OPEN_1 */

            R0900_00_DECLARE_ENDOSSO_DB_OPEN_1();

            /*" -415- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -416- DISPLAY 'R0900-00 (PROBLEMAS NO DECLARE V1ENDOSSO     )' */
                _.Display($"R0900-00 (PROBLEMAS NO DECLARE V1ENDOSSO     )");

                /*" -418- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -419- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -420- DISPLAY 'FIM DO DECLARE ENDOSSO ... HORA..' WS-TIME. */
            _.Display($"FIM DO DECLARE ENDOSSO ... HORA..{AREA_DE_WORK.WS_TIME}");

        }

        [StopWatch]
        /*" R0900-00-DECLARE-ENDOSSO-DB-DECLARE-1 */
        public void R0900_00_DECLARE_ENDOSSO_DB_DECLARE_1()
        {
            /*" -410- EXEC SQL DECLARE V1ENDOSSO CURSOR FOR SELECT NUM_APOLICE, NUMBIL FROM SEGUROS.V1ENDOSSO WHERE NUMBIL > 0 AND DTEMIS = :WHOST-DTINIVIG AND RAMO IN (72,82) AND NRENDOS = 0 END-EXEC. */
            V1ENDOSSO = new CB0055B_V1ENDOSSO(true);
            string GetQuery_V1ENDOSSO()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NUMBIL 
							FROM SEGUROS.V1ENDOSSO 
							WHERE NUMBIL > 0 
							AND DTEMIS = '{WHOST_DTINIVIG}' 
							AND RAMO IN (72
							,82) 
							AND NRENDOS = 0";

                return query;
            }
            V1ENDOSSO.GetQueryEvent += GetQuery_V1ENDOSSO;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-ENDOSSO-DB-OPEN-1 */
        public void R0900_00_DECLARE_ENDOSSO_DB_OPEN_1()
        {
            /*" -412- EXEC SQL OPEN V1ENDOSSO END-EXEC. */

            V1ENDOSSO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-ENDOSSO-SECTION */
        private void R0910_00_FETCH_ENDOSSO_SECTION()
        {
            /*" -433- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -436- PERFORM R0910_00_FETCH_ENDOSSO_DB_FETCH_1 */

            R0910_00_FETCH_ENDOSSO_DB_FETCH_1();

            /*" -439- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -440- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -441- MOVE 'S' TO WFIM-ENDOSSO */
                    _.Move("S", AREA_DE_WORK.WFIM_ENDOSSO);

                    /*" -441- PERFORM R0910_00_FETCH_ENDOSSO_DB_CLOSE_1 */

                    R0910_00_FETCH_ENDOSSO_DB_CLOSE_1();

                    /*" -443- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -444- ELSE */
                }
                else
                {


                    /*" -445- DISPLAY 'R0910-00 (PROBLEMAS NO FETCH ENDOSSO)' */
                    _.Display($"R0910-00 (PROBLEMAS NO FETCH ENDOSSO)");

                    /*" -453- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -454- ADD +1 TO AC-L-ENDOSSO. */
            AREA_DE_WORK.AC_L_ENDOSSO.Value = AREA_DE_WORK.AC_L_ENDOSSO + +1;

            /*" -454- ADD +1 TO AC-L-DISPLAY. */
            AREA_DE_WORK.AC_L_DISPLAY.Value = AREA_DE_WORK.AC_L_DISPLAY + +1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-ENDOSSO-DB-FETCH-1 */
        public void R0910_00_FETCH_ENDOSSO_DB_FETCH_1()
        {
            /*" -436- EXEC SQL FETCH V1ENDOSSO INTO :V1ENDO-NUM-APOL, :V1ENDO-NUMBIL END-EXEC. */

            if (V1ENDOSSO.Fetch())
            {
                _.Move(V1ENDOSSO.V1ENDO_NUM_APOL, V1ENDO_NUM_APOL);
                _.Move(V1ENDOSSO.V1ENDO_NUMBIL, V1ENDO_NUMBIL);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-ENDOSSO-DB-CLOSE-1 */
        public void R0910_00_FETCH_ENDOSSO_DB_CLOSE_1()
        {
            /*" -441- EXEC SQL CLOSE V1ENDOSSO END-EXEC */

            V1ENDOSSO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -469- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -471- PERFORM R2000-00-SELECT-ADIANTA. */

            R2000_00_SELECT_ADIANTA_SECTION();

            /*" -472- IF WFIM-ADIANTA EQUAL 'N' */

            if (AREA_DE_WORK.WFIM_ADIANTA == "N")
            {

                /*" -474- PERFORM R4000-00-TRATA-BILHETES */

                R4000_00_TRATA_BILHETES_SECTION();

                /*" -475- IF AC-L-DISPLAY NOT LESS 100 */

                if (AREA_DE_WORK.AC_L_DISPLAY >= 100)
                {

                    /*" -476- ACCEPT WS-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

                    /*" -477- DISPLAY 'HORARIO ...........' WS-TIME */
                    _.Display($"HORARIO ...........{AREA_DE_WORK.WS_TIME}");

                    /*" -478- DISPLAY '*------------------------------------*' */
                    _.Display($"*------------------------------------*");

                    /*" -479- DISPLAY '* LIDOS ATE O MOMENTO  = ' AC-L-ENDOSSO */
                    _.Display($"* LIDOS ATE O MOMENTO  = {AREA_DE_WORK.AC_L_ENDOSSO}");

                    /*" -482- DISPLAY '* ALTERADOS V0ADIANTA  = ' AC-U-V0ADIANTA */
                    _.Display($"* ALTERADOS V0ADIANTA  = {AREA_DE_WORK.AC_U_V0ADIANTA}");

                    /*" -483- DISPLAY '*------------------------------------*' */
                    _.Display($"*------------------------------------*");

                    /*" -485- MOVE ZEROS TO AC-L-DISPLAY. */
                    _.Move(0, AREA_DE_WORK.AC_L_DISPLAY);
                }

            }


            /*" -485- PERFORM R0910-00-FETCH-ENDOSSO. */

            R0910_00_FETCH_ENDOSSO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-SELECT-ADIANTA-SECTION */
        private void R2000_00_SELECT_ADIANTA_SECTION()
        {
            /*" -501- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -503- MOVE V1ENDO-NUMBIL TO WHOST-NUM-APOL */
            _.Move(V1ENDO_NUMBIL, WHOST_NUM_APOL);

            /*" -509- PERFORM R2000_00_SELECT_ADIANTA_DB_SELECT_1 */

            R2000_00_SELECT_ADIANTA_DB_SELECT_1();

            /*" -512- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -513- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -515- DISPLAY 'PROBLEMAS NO SELECT (V1ADIANTA) ... ' ' BILHETE ' V1ENDO-NUMBIL */

                    $"PROBLEMAS NO SELECT (V1ADIANTA) ...  BILHETE {V1ENDO_NUMBIL}"
                    .Display();

                    /*" -516- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -517- ELSE */
                }
                else
                {


                    /*" -518- MOVE 'S' TO WFIM-ADIANTA */
                    _.Move("S", AREA_DE_WORK.WFIM_ADIANTA);

                    /*" -519- ELSE */
                }

            }
            else
            {


                /*" -520- MOVE 'N' TO WFIM-ADIANTA */
                _.Move("N", AREA_DE_WORK.WFIM_ADIANTA);

                /*" -520- ADD +1 TO AC-L-ADIANTA. */
                AREA_DE_WORK.AC_L_ADIANTA.Value = AREA_DE_WORK.AC_L_ADIANTA + +1;
            }


        }

        [StopWatch]
        /*" R2000-00-SELECT-ADIANTA-DB-SELECT-1 */
        public void R2000_00_SELECT_ADIANTA_DB_SELECT_1()
        {
            /*" -509- EXEC SQL SELECT NUMOPG INTO :V1ADIA-NUMOPG FROM SEGUROS.V0ADIANTA WHERE CODPDT = 17256 AND NUM_APOLICE = :WHOST-NUM-APOL AND NUMOPG > 0 END-EXEC. */

            var r2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1 = new R2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1()
            {
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
            };

            var executed_1 = R2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1.Execute(r2000_00_SELECT_ADIANTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ADIA_NUMOPG, V1ADIA_NUMOPG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TRATA-BILHETES-SECTION */
        private void R4000_00_TRATA_BILHETES_SECTION()
        {
            /*" -537- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -538- MOVE 17256 TO V0ADIA-CODPDT */
            _.Move(17256, V0ADIA_CODPDT);

            /*" -539- MOVE V1ENDO-NUM-APOL TO V0ADIA-NUM-APOL */
            _.Move(V1ENDO_NUM_APOL, V0ADIA_NUM_APOL);

            /*" -539- PERFORM R4200-00-UPDATE-V0ADIANTA. */

            R4200_00_UPDATE_V0ADIANTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-UPDATE-V0ADIANTA-SECTION */
        private void R4200_00_UPDATE_V0ADIANTA_SECTION()
        {
            /*" -556- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -564- PERFORM R4200_00_UPDATE_V0ADIANTA_DB_UPDATE_1 */

            R4200_00_UPDATE_V0ADIANTA_DB_UPDATE_1();

            /*" -567- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -571- DISPLAY 'R4200-00 (ERRO - UPDATE V0ADIANTA)...' 'APOLICE: ' V0ADIA-NUM-APOL '  ' ' NUMOPG ' V1ADIA-NUMOPG ' BILHETE: ' V1ENDO-NUMBIL */

                $"R4200-00 (ERRO - UPDATE V0ADIANTA)...APOLICE: {V0ADIA_NUM_APOL}   NUMOPG {V1ADIA_NUMOPG} BILHETE: {V1ENDO_NUMBIL}"
                .Display();

                /*" -572- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -577- ELSE */
            }
            else
            {


                /*" -581- ADD +1 TO AC-U-V0ADIANTA */
                AREA_DE_WORK.AC_U_V0ADIANTA.Value = AREA_DE_WORK.AC_U_V0ADIANTA + +1;

                /*" -582- MOVE 17256 TO V0FORM-CODPDT */
                _.Move(17256, V0FORM_CODPDT);

                /*" -583- MOVE V1ENDO-NUM-APOL TO V0FORM-NUM-APOL */
                _.Move(V1ENDO_NUM_APOL, V0FORM_NUM_APOL);

                /*" -587- PERFORM R4300-00-UPDATE-V0FORMAREC */

                R4300_00_UPDATE_V0FORMAREC_SECTION();

                /*" -588- MOVE 17256 TO V0HISR-CODPDT */
                _.Move(17256, V0HISR_CODPDT);

                /*" -589- MOVE V1ENDO-NUM-APOL TO V0HISR-NUM-APOL */
                _.Move(V1ENDO_NUM_APOL, V0HISR_NUM_APOL);

                /*" -589- PERFORM R4400-00-UPDATE-V0HISTOREC. */

                R4400_00_UPDATE_V0HISTOREC_SECTION();
            }


        }

        [StopWatch]
        /*" R4200-00-UPDATE-V0ADIANTA-DB-UPDATE-1 */
        public void R4200_00_UPDATE_V0ADIANTA_DB_UPDATE_1()
        {
            /*" -564- EXEC SQL UPDATE SEGUROS.V0ADIANTA SET NUM_APOLICE = :V0ADIA-NUM-APOL, TIMESTAMP = CURRENT TIMESTAMP WHERE CODPDT = 17256 AND NUMOPG = :V1ADIA-NUMOPG AND NUM_APOLICE = :WHOST-NUM-APOL END-EXEC. */

            var r4200_00_UPDATE_V0ADIANTA_DB_UPDATE_1_Update1 = new R4200_00_UPDATE_V0ADIANTA_DB_UPDATE_1_Update1()
            {
                V0ADIA_NUM_APOL = V0ADIA_NUM_APOL.ToString(),
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                V1ADIA_NUMOPG = V1ADIA_NUMOPG.ToString(),
            };

            R4200_00_UPDATE_V0ADIANTA_DB_UPDATE_1_Update1.Execute(r4200_00_UPDATE_V0ADIANTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-UPDATE-V0FORMAREC-SECTION */
        private void R4300_00_UPDATE_V0FORMAREC_SECTION()
        {
            /*" -605- MOVE '430' TO WNR-EXEC-SQL. */
            _.Move("430", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -612- PERFORM R4300_00_UPDATE_V0FORMAREC_DB_UPDATE_1 */

            R4300_00_UPDATE_V0FORMAREC_DB_UPDATE_1();

            /*" -615- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -619- DISPLAY 'PROBLEMAS NA UPDATE (V0FORMAREC) ... ' 'APOLICE ' V0FORM-NUM-APOL ' NUMOPG ' V1ADIA-NUMOPG ' BILHETE ' V1ENDO-NUMBIL */

                $"PROBLEMAS NA UPDATE (V0FORMAREC) ... APOLICE {V0FORM_NUM_APOL} NUMOPG {V1ADIA_NUMOPG} BILHETE {V1ENDO_NUMBIL}"
                .Display();

                /*" -621- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -621- ADD +1 TO AC-U-V0FORMAREC. */
            AREA_DE_WORK.AC_U_V0FORMAREC.Value = AREA_DE_WORK.AC_U_V0FORMAREC + +1;

        }

        [StopWatch]
        /*" R4300-00-UPDATE-V0FORMAREC-DB-UPDATE-1 */
        public void R4300_00_UPDATE_V0FORMAREC_DB_UPDATE_1()
        {
            /*" -612- EXEC SQL UPDATE SEGUROS.V0FORMAREC SET NUM_APOLICE = :V0FORM-NUM-APOL, TIMESTAMP = CURRENT TIMESTAMP WHERE NUMOPG = :V1ADIA-NUMOPG AND NUM_APOLICE = :WHOST-NUM-APOL END-EXEC. */

            var r4300_00_UPDATE_V0FORMAREC_DB_UPDATE_1_Update1 = new R4300_00_UPDATE_V0FORMAREC_DB_UPDATE_1_Update1()
            {
                V0FORM_NUM_APOL = V0FORM_NUM_APOL.ToString(),
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                V1ADIA_NUMOPG = V1ADIA_NUMOPG.ToString(),
            };

            R4300_00_UPDATE_V0FORMAREC_DB_UPDATE_1_Update1.Execute(r4300_00_UPDATE_V0FORMAREC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-UPDATE-V0HISTOREC-SECTION */
        private void R4400_00_UPDATE_V0HISTOREC_SECTION()
        {
            /*" -641- MOVE '440' TO WNR-EXEC-SQL. */
            _.Move("440", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -649- PERFORM R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1 */

            R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1();

            /*" -652- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -656- DISPLAY 'PROBLEMAS NA UPDATE (V0HISTOREC) ... ' 'APOLICE. ' V0HISR-NUM-APOL ' NUMOPG ' V1ADIA-NUMOPG ' BILHETE ' V1ENDO-NUMBIL */

                $"PROBLEMAS NA UPDATE (V0HISTOREC) ... APOLICE. {V0HISR_NUM_APOL} NUMOPG {V1ADIA_NUMOPG} BILHETE {V1ENDO_NUMBIL}"
                .Display();

                /*" -658- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -658- ADD +1 TO AC-U-V0HISTOREC. */
            AREA_DE_WORK.AC_U_V0HISTOREC.Value = AREA_DE_WORK.AC_U_V0HISTOREC + +1;

        }

        [StopWatch]
        /*" R4400-00-UPDATE-V0HISTOREC-DB-UPDATE-1 */
        public void R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1()
        {
            /*" -649- EXEC SQL UPDATE SEGUROS.V0HISTOREC SET NUM_APOLICE = :V0HISR-NUM-APOL, TIMESTAMP = CURRENT TIMESTAMP WHERE NUMOPG = :V1ADIA-NUMOPG AND NUM_APOLICE = :WHOST-NUM-APOL AND OPERACAO = 1401 END-EXEC. */

            var r4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1 = new R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1()
            {
                V0HISR_NUM_APOL = V0HISR_NUM_APOL.ToString(),
                WHOST_NUM_APOL = WHOST_NUM_APOL.ToString(),
                V1ADIA_NUMOPG = V1ADIA_NUMOPG.ToString(),
            };

            R4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1.Execute(r4400_00_UPDATE_V0HISTOREC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -676- MOVE V1SIST-DTMOVABE TO WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -677- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_7.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -678- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_7.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -680- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(AREA_DE_WORK.FILLER_7.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -681- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -682- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -683- DISPLAY '*   CB0055B - ACERTO COMISSAO FENAE        *' */
            _.Display($"*   CB0055B - ACERTO COMISSAO FENAE        *");

            /*" -684- DISPLAY '*   -------   ------ -------- -----        *' */
            _.Display($"*   -------   ------ -------- -----        *");

            /*" -685- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -686- DISPLAY '*    NAO HOUVE MOVIMENTACAO NESTA DATA     *' */
            _.Display($"*    NAO HOUVE MOVIMENTACAO NESTA DATA     *");

            /*" -688- DISPLAY '*               ' WDAT-REL-LIT '                   *' */

            $"*               {AREA_DE_WORK.WDAT_REL_LIT}                   *"
            .Display();

            /*" -689- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -689- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -704- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -706- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -706- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -708- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -712- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -712- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}