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
using Sias.Sinistro.DB2.SI0120B;

namespace Code
{
    public class SI0120B
    {
        public bool IsCall { get; set; }

        public SI0120B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA              :    APOLICE                           //      */
        /*"      * PROGRAMA             :    SI0120B                           //      */
        /*"      * OBJETIVO             :    EMISSAO DE RELACAO DE PROTOCOLOS  //      */
        /*"      *                           LIBERADOS                         //      */
        /*"      * ANALISTA/PROGRAMADOR :    PROCAS/FREDERICO                  //      */
        /*"      * DATA                 :    ABRIL/92                          //      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *////////////////////////////////////////////////////////////*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0120M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0120M1
        {
            get
            {
                _.Move(REG_SI0120M1, _SI0120M1); VarBasis.RedefinePassValue(REG_SI0120M1, _SI0120M1, REG_SI0120M1); return _SI0120M1;
            }
        }
        /*"01  REG-SI0120M1.*/
        public SI0120B_REG_SI0120M1 REG_SI0120M1 { get; set; } = new SI0120B_REG_SI0120M1();
        public class SI0120B_REG_SI0120M1 : VarBasis
        {
            /*"    05          LINHA              PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          V1EMPRESA-COD-EMP      PIC S9(004)       COMP.*/
        public IntBasis V1EMPRESA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EMPRESA-NOM-EMP      PIC  X(040).*/
        public StringBasis V1EMPRESA_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           SISTEMA-DTMOVABE       PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           SISTEMA-DTCURRENT      PIC  X(010).*/
        public StringBasis SISTEMA_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELATO-DTINIVIG        PIC  X(010).*/
        public StringBasis RELATO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELATO-DTTERVIG        PIC  X(010).*/
        public StringBasis RELATO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           RELATO-FONTE           PIC  S9(004)    COMP.*/
        public IntBasis RELATO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           CONTSIN-FONTE          PIC S9(004)       COMP.*/
        public IntBasis CONTSIN_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           CONTSIN-PROTSINI       PIC S9(009)       COMP.*/
        public IntBasis CONTSIN_PROTSINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           CONTSIN-DAC            PIC  X(001).*/
        public StringBasis CONTSIN_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           CONTSIN-APOLICE        PIC S9(013)       COMP-3.*/
        public IntBasis CONTSIN_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           CONTSIN-TIMESTAMP      PIC  X(026).*/
        public StringBasis CONTSIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77           WTIMESTAMP-INI         PIC  X(026).*/
        public StringBasis WTIMESTAMP_INI { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77           WTIMESTAMP-FIM         PIC  X(026).*/
        public StringBasis WTIMESTAMP_FIM { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77           APOLICE-NOME           PIC  X(040).*/
        public StringBasis APOLICE_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77          TGEFONTE-NOMEFTE        PIC  X(030).*/
        public StringBasis TGEFONTE_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77          TGEFONTE-FONTE          PIC S9(004)       COMP.*/
        public IntBasis TGEFONTE_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WFONTE-INI              PIC S9(004) COMP VALUE +0.*/
        public IntBasis WFONTE_INI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WFONTE-FIM              PIC S9(004) COMP VALUE +0.*/
        public IntBasis WFONTE_FIM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01              W.*/
        public SI0120B_W W { get; set; } = new SI0120B_W();
        public class SI0120B_W : VarBasis
        {
            /*"  03            LC01.*/
            public SI0120B_LC01 LC01 { get; set; } = new SI0120B_LC01();
            public class SI0120B_LC01 : VarBasis
            {
                /*"    05          LC01-RELATORIO PIC  X(009) VALUE 'SI0120B.1'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0120B.1");
                /*"    05          FILLER              PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          LC01-EMPRESA        PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER              PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    05          LC01-PAG            PIC  ZZZ9.*/
                public IntBasis LC01_PAG { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  03            LC02.*/
            }
            public SI0120B_LC02 LC02 { get; set; } = new SI0120B_LC02();
            public class SI0120B_LC02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(050) VALUE SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    05          FILLER              PIC  X(055) VALUE SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"");
                /*"    05          FILLER              PIC  X(012) VALUE  SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    05          LC02-DATA           PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03            LC03.*/
            }
            public SI0120B_LC03 LC03 { get; set; } = new SI0120B_LC03();
            public class SI0120B_LC03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    05          LC03-HORA           PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  03            LC04B.*/
            }
            public SI0120B_LC04B LC04B { get; set; } = new SI0120B_LC04B();
            public class SI0120B_LC04B : VarBasis
            {
                /*"    05          FILLER              PIC  X(029) VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"    05          FILLER              PIC  X(046) VALUE                'RELACAO DE PROTOCOLOS LIBERADOS NO PERIODO DE'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"RELACAO DE PROTOCOLOS LIBERADOS NO PERIODO DE");
                /*"    05          LC04B-DATAI.*/
                public SI0120B_LC04B_DATAI LC04B_DATAI { get; set; } = new SI0120B_LC04B_DATAI();
                public class SI0120B_LC04B_DATAI : VarBasis
                {
                    /*"      07        LC04B-DDI          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04B_DDI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC04B-MMI          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04B_MMI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC04B-AAI          PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LC04B_AAI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(005) VALUE                ' ATE'.*/
                }
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @" ATE");
                /*"    05          LC04B-DATAT.*/
                public SI0120B_LC04B_DATAT LC04B_DATAT { get; set; } = new SI0120B_LC04B_DATAT();
                public class SI0120B_LC04B_DATAT : VarBasis
                {
                    /*"      07        LC04B-DDT          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04B_DDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC04B-MMT          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC04B_MMT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC04B-AAT          PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LC04B_AAT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                }
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"  03            LC05.*/
            }
            public SI0120B_LC05 LC05 { get; set; } = new SI0120B_LC05();
            public class SI0120B_LC05 : VarBasis
            {
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          FILLER              PIC  X(008) VALUE                'FONTE - '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"FONTE - ");
                /*"    05          LC05-FONTE          PIC  9(003) VALUE ZEROS.*/
                public IntBasis LC05_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          LC05-NOMEFTE        PIC  X(040) VALUE SPACES.*/
                public StringBasis LC05_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03            LC06.*/
            }
            public SI0120B_LC06 LC06 { get; set; } = new SI0120B_LC06();
            public class SI0120B_LC06 : VarBasis
            {
                /*"    05          FILLER              PIC  X(076) VALUE               '  PROTOCOLO     APOLICE       NOME'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "76", "X(076)"), @"  PROTOCOLO     APOLICE       NOME");
                /*"    05          FILLER              PIC  X(045) VALUE               '  DATA                HORA'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"  DATA                HORA");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"  03            LD01.*/
            }
            public SI0120B_LD01 LD01 { get; set; } = new SI0120B_LD01();
            public class SI0120B_LD01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          LD01-PROTOCOLO.*/
                public SI0120B_LD01_PROTOCOLO LD01_PROTOCOLO { get; set; } = new SI0120B_LD01_PROTOCOLO();
                public class SI0120B_LD01_PROTOCOLO : VarBasis
                {
                    /*"      07        LD01-PROTSINI       PIC  9(006).*/
                    public IntBasis LD01_PROTSINI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '-'.*/
                    public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"      07        LD01-DAC            PIC  9(001).*/
                    public IntBasis LD01_DAC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                }
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          LD01-APOLICE        PIC  9(013)  VALUE ZEROS.*/
                public IntBasis LD01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LD01-NOME           PIC  X(040) VALUE SPACES.*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    05          LD01-DATA.*/
                public SI0120B_LD01_DATA LD01_DATA { get; set; } = new SI0120B_LD01_DATA();
                public class SI0120B_LD01_DATA : VarBasis
                {
                    /*"      07        LD01-DD             PIC  9(002).*/
                    public IntBasis LD01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LD01-MM             PIC  9(002).*/
                    public IntBasis LD01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LD01-AA             PIC  9(004).*/
                    public IntBasis LD01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05          FILLER              PIC  X(011) VALUE SPACES.*/
                }
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    05          LD01-HORA.*/
                public SI0120B_LD01_HORA LD01_HORA { get; set; } = new SI0120B_LD01_HORA();
                public class SI0120B_LD01_HORA : VarBasis
                {
                    /*"      07        LD01-HOR            PIC  9(002).*/
                    public IntBasis LD01_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE ':'.*/
                    public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                    /*"      07        LD01-MIN            PIC  9(002).*/
                    public IntBasis LD01_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE ':'.*/
                    public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                    /*"      07        LD01-SEG            PIC  9(002).*/
                    public IntBasis LD01_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
                }
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WFIM-TRELATO        PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TRELATO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-TCONTSIN       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_TCONTSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_SI0120B_FILLER_33 _filler_33 { get; set; }
            public _REDEF_SI0120B_FILLER_33 FILLER_33
            {
                get { _filler_33 = new _REDEF_SI0120B_FILLER_33(); _.Move(WDATA_CURR, _filler_33); VarBasis.RedefinePassValue(WDATA_CURR, _filler_33, WDATA_CURR); _filler_33.ValueChanged += () => { _.Move(_filler_33, WDATA_CURR); }; return _filler_33; }
                set { VarBasis.RedefinePassValue(value, _filler_33, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0120B_FILLER_33 : VarBasis
            {
                /*"    05       WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       FILLER            PIC  X(001).*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       FILLER            PIC  X(001).*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WHORA-CURR.*/

                public _REDEF_SI0120B_FILLER_33()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_34.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_35.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public SI0120B_WHORA_CURR WHORA_CURR { get; set; } = new SI0120B_WHORA_CURR();
            public class SI0120B_WHORA_CURR : VarBasis
            {
                /*"    05          WHORA-HH-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-MM-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-SS-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-CC-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WTIMESTAMP.*/
            }
            public SI0120B_WTIMESTAMP WTIMESTAMP { get; set; } = new SI0120B_WTIMESTAMP();
            public class SI0120B_WTIMESTAMP : VarBasis
            {
                /*"    05          WTIMESTAMP-DATA     PIC  X(010).*/
                public StringBasis WTIMESTAMP_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WTIMESTAMP-HORA     PIC  X(008).*/
                public StringBasis WTIMESTAMP_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    05          FILLER              PIC  X(007).*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"  03            WAUX-HORA.*/
            }
            public SI0120B_WAUX_HORA WAUX_HORA { get; set; } = new SI0120B_WAUX_HORA();
            public class SI0120B_WAUX_HORA : VarBasis
            {
                /*"    05          WAUX-HOR            PIC  9(002).*/
                public IntBasis WAUX_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WAUX-MIN            PIC  9(002).*/
                public IntBasis WAUX_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WAUX-SEG            PIC  9(002).*/
                public IntBasis WAUX_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WDATA-CABEC.*/
            }
            public SI0120B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0120B_WDATA_CABEC();
            public class SI0120B_WDATA_CABEC : VarBasis
            {
                /*"    05          WDATA-DD-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-AA-CABEC      PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            WHORA-CABEC.*/
            }
            public SI0120B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0120B_WHORA_CABEC();
            public class SI0120B_WHORA_CABEC : VarBasis
            {
                /*"    05          WHORA-HH-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-SS-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WDATA               PIC  X(010).*/
            }
            public StringBasis WDATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03            FILLER  REDEFINES   WDATA.*/
            private _REDEF_SI0120B_FILLER_44 _filler_44 { get; set; }
            public _REDEF_SI0120B_FILLER_44 FILLER_44
            {
                get { _filler_44 = new _REDEF_SI0120B_FILLER_44(); _.Move(WDATA, _filler_44); VarBasis.RedefinePassValue(WDATA, _filler_44, WDATA); _filler_44.ValueChanged += () => { _.Move(_filler_44, WDATA); }; return _filler_44; }
                set { VarBasis.RedefinePassValue(value, _filler_44, WDATA); }
            }  //Redefines
            public class _REDEF_SI0120B_FILLER_44 : VarBasis
            {
                /*"    05          WDATA-AA            PIC  9(004).*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-MM            PIC  9(002).*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-DD            PIC  9(002).*/
                public IntBasis WDATA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WLIDOS              PIC  9(007) VALUE ZEROS.*/

                public _REDEF_SI0120B_FILLER_44()
                {
                    WDATA_AA.ValueChanged += OnValueChanged;
                    FILLER_45.ValueChanged += OnValueChanged;
                    WDATA_MM.ValueChanged += OnValueChanged;
                    FILLER_46.ValueChanged += OnValueChanged;
                    WDATA_DD.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WLIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            WLIDOS-REL          PIC  9(007) VALUE ZEROS.*/
            public IntBasis WLIDOS_REL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            WIMPRES             PIC  9(007) VALUE ZEROS.*/
            public IntBasis WIMPRES { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            WCONT-PAG           PIC  S9(004) COMP VALUE +0.*/
            public IntBasis WCONT_PAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03            WCONT-LIN           PIC  S9(004) COMP VALUE +70.*/
            public IntBasis WCONT_LIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +70);
            /*"  03            WFONTE-ANT          PIC S9(004) COMP VALUE +0.*/
            public IntBasis WFONTE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        WABEND.*/
            public SI0120B_WABEND WABEND { get; set; } = new SI0120B_WABEND();
            public class SI0120B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0120B'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0120B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01  WT.*/
            }
        }
        public SI0120B_WT WT { get; set; } = new SI0120B_WT();
        public class SI0120B_WT : VarBasis
        {
            /*"  03            WT1.*/
            public SI0120B_WT1 WT1 { get; set; } = new SI0120B_WT1();
            public class SI0120B_WT1 : VarBasis
            {
                /*"    05          WTIMESTAMP-INI-DATA     PIC  X(010).*/
                public StringBasis WTIMESTAMP_INI_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05          FILLER                  PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WTIMESTAMP-INI-HORA     PIC  X(008) VALUE                                        '00.00.00'.*/
                public StringBasis WTIMESTAMP_INI_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"00.00.00");
                /*"    05          FILLER                  PIC  X(007) VALUE                                        '.000000'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @".000000");
                /*"  03            WT2.*/
            }
            public SI0120B_WT2 WT2 { get; set; } = new SI0120B_WT2();
            public class SI0120B_WT2 : VarBasis
            {
                /*"    05          WTIMESTAMP-FIM-DATA     PIC  X(010).*/
                public StringBasis WTIMESTAMP_FIM_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05          FILLER                  PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WTIMESTAMP-FIM-HORA     PIC  X(008) VALUE                                        '23.59.59'.*/
                public StringBasis WTIMESTAMP_FIM_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"23.59.59");
                /*"    05          FILLER                  PIC  X(007) VALUE                                        '.999999'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @".999999");
                /*"01          LK-LINK.*/
            }
        }
        public SI0120B_LK_LINK LK_LINK { get; set; } = new SI0120B_LK_LINK();
        public class SI0120B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public SI0120B_V1RELATSINI V1RELATSINI { get; set; } = new SI0120B_V1RELATSINI();
        public SI0120B_V1CONTSINI V1CONTSINI { get; set; } = new SI0120B_V1CONTSINI();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0120M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0120M1.SetFile(SI0120M1_FILE_NAME_P);

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
            /*" -337- MOVE '000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL", W.WABEND.PARAGRAFO);

            /*" -338- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -340- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -342- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -346- PERFORM 030-000-INICIO. */

            M_030_000_INICIO_SECTION();

            /*" -348- PERFORM 060-000-LER-TSISTEMA. */

            M_060_000_LER_TSISTEMA_SECTION();

            /*" -350- PERFORM 015-000-CABECALHOS. */

            M_015_000_CABECALHOS_SECTION();

            /*" -352- PERFORM 090-000-CURSOR-TRELATO. */

            M_090_000_CURSOR_TRELATO_SECTION();

            /*" -354- PERFORM 300-000-LER-TRELATO. */

            M_300_000_LER_TRELATO_SECTION();

            /*" -355- IF WFIM-TRELATO EQUAL 'S' */

            if (W.WFIM_TRELATO == "S")
            {

                /*" -356- DISPLAY 'SI0120B - NAO HOUVE PEDIDO DE EMISSAO' */
                _.Display($"SI0120B - NAO HOUVE PEDIDO DE EMISSAO");

                /*" -359- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -363- PERFORM 120-000-PROCESSA UNTIL WFIM-TRELATO EQUAL 'S' . */

            while (!(W.WFIM_TRELATO == "S"))
            {

                M_120_000_PROCESSA_SECTION();
            }

            /*" -363- PERFORM 600-000-ATUALIZA-TRELATO. */

            M_600_000_ATUALIZA_TRELATO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -370- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

            /*" -370- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-015-000-CABECALHOS-SECTION */
        private void M_015_000_CABECALHOS_SECTION()
        {
            /*" -383- MOVE SISTEMA-DTCURRENT TO WDATA-CURR */
            _.Move(SISTEMA_DTCURRENT, W.WDATA_CURR);

            /*" -384- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -385- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(W.FILLER_33.WDATA_DD_CURR, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -386- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(W.FILLER_33.WDATA_MM_CURR, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -387- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(W.FILLER_33.WDATA_AA_CURR, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -388- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(W.WDATA_CABEC, W.LC02.LC02_DATA);

            /*" -389- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -390- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(W.WHORA_CURR.WHORA_MM_CURR, W.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -391- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, W.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -394- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(W.WHORA_CABEC, W.LC03.LC03_HORA);

            /*" -398- PERFORM M_015_000_CABECALHOS_DB_SELECT_1 */

            M_015_000_CABECALHOS_DB_SELECT_1();

            /*" -401- MOVE V1EMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPRESA_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -403- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -404- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -405- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, W.LC01.LC01_EMPRESA);

                /*" -406- ELSE */
            }
            else
            {


                /*" -407- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -407- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" M-015-000-CABECALHOS-DB-SELECT-1 */
        public void M_015_000_CABECALHOS_DB_SELECT_1()
        {
            /*" -398- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
            /*" -426- MOVE '030-000-INICIO' TO PARAGRAFO. */
            _.Move("030-000-INICIO", W.WABEND.PARAGRAFO);

            /*" -426- OPEN OUTPUT SI0120M1. */
            SI0120M1.Open(REG_SI0120M1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-SECTION */
        private void M_060_000_LER_TSISTEMA_SECTION()
        {
            /*" -441- MOVE '060' TO WNR-EXEC-SQL */
            _.Move("060", W.WABEND.WNR_EXEC_SQL);

            /*" -447- MOVE '060-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("060-000-LER-TSISTEMA", W.WABEND.PARAGRAFO);

            /*" -452- PERFORM M_060_000_LER_TSISTEMA_DB_SELECT_1 */

            M_060_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -455- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -456- DISPLAY 'SI0120B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"SI0120B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -456- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_060_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -452- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :SISTEMA-DTMOVABE, :SISTEMA-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_DTCURRENT, SISTEMA_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-TRELATO-SECTION */
        private void M_090_000_CURSOR_TRELATO_SECTION()
        {
            /*" -472- MOVE '090' TO WNR-EXEC-SQL */
            _.Move("090", W.WABEND.WNR_EXEC_SQL);

            /*" -478- MOVE '090-000-CURSOR-TRELATO' TO PARAGRAFO. */
            _.Move("090-000-CURSOR-TRELATO", W.WABEND.PARAGRAFO);

            /*" -488- PERFORM M_090_000_CURSOR_TRELATO_DB_DECLARE_1 */

            M_090_000_CURSOR_TRELATO_DB_DECLARE_1();

            /*" -490- PERFORM M_090_000_CURSOR_TRELATO_DB_OPEN_1 */

            M_090_000_CURSOR_TRELATO_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELATO-DB-DECLARE-1 */
        public void M_090_000_CURSOR_TRELATO_DB_DECLARE_1()
        {
            /*" -488- EXEC SQL DECLARE V1RELATSINI CURSOR FOR SELECT PERI_INICIAL, PERI_FINAL, FONTE FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'SI0120B' AND IDSISTEM = 'SI' AND DATA_SOLICITACAO = :SISTEMA-DTMOVABE ORDER BY FONTE, PERI_INICIAL, PERI_FINAL END-EXEC. */
            V1RELATSINI = new SI0120B_V1RELATSINI(true);
            string GetQuery_V1RELATSINI()
            {
                var query = @$"SELECT PERI_INICIAL
							, 
							PERI_FINAL
							, 
							FONTE 
							FROM SEGUROS.V1RELATORIOS 
							WHERE CODRELAT = 'SI0120B' 
							AND IDSISTEM = 'SI' 
							AND DATA_SOLICITACAO = '{SISTEMA_DTMOVABE}' 
							ORDER BY FONTE
							, PERI_INICIAL
							, PERI_FINAL";

                return query;
            }
            V1RELATSINI.GetQueryEvent += GetQuery_V1RELATSINI;

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELATO-DB-OPEN-1 */
        public void M_090_000_CURSOR_TRELATO_DB_OPEN_1()
        {
            /*" -490- EXEC SQL OPEN V1RELATSINI END-EXEC. */

            V1RELATSINI.Open();

        }

        [StopWatch]
        /*" M-150-000-CURSOR-TCONTSIN-DB-DECLARE-1 */
        public void M_150_000_CURSOR_TCONTSIN_DB_DECLARE_1()
        {
            /*" -555- EXEC SQL DECLARE V1CONTSINI CURSOR FOR SELECT FONTE, PROTSINI, DAC, NUM_APOLICE, TIMESTAMP FROM SEGUROS.V1CONTSINI WHERE FONTE >= :WFONTE-INI AND FONTE <= :WFONTE-FIM AND TIMESTAMP >= :WTIMESTAMP-INI AND TIMESTAMP <= :WTIMESTAMP-FIM ORDER BY FONTE, PROTSINI, DAC, TIMESTAMP END-EXEC. */
            V1CONTSINI = new SI0120B_V1CONTSINI(true);
            string GetQuery_V1CONTSINI()
            {
                var query = @$"SELECT FONTE
							, 
							PROTSINI
							, 
							DAC
							, 
							NUM_APOLICE
							, 
							TIMESTAMP 
							FROM SEGUROS.V1CONTSINI 
							WHERE FONTE >= '{WFONTE_INI}' 
							AND FONTE <= '{WFONTE_FIM}' 
							AND TIMESTAMP >= '{WTIMESTAMP_INI}' 
							AND TIMESTAMP <= '{WTIMESTAMP_FIM}' 
							ORDER BY FONTE
							, PROTSINI
							, DAC
							, TIMESTAMP";

                return query;
            }
            V1CONTSINI.GetQueryEvent += GetQuery_V1CONTSINI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-120-000-PROCESSA-SECTION */
        private void M_120_000_PROCESSA_SECTION()
        {
            /*" -509- MOVE '120-000-PROCESSA' TO PARAGRAFO. */
            _.Move("120-000-PROCESSA", W.WABEND.PARAGRAFO);

            /*" -511- MOVE 'N' TO WFIM-TCONTSIN. */
            _.Move("N", W.WFIM_TCONTSIN);

            /*" -511- PERFORM 150-000-CURSOR-TCONTSIN. */

            M_150_000_CURSOR_TCONTSIN_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_120_010_LOOP */

            M_120_010_LOOP();

        }

        [StopWatch]
        /*" M-120-010-LOOP */
        private void M_120_010_LOOP(bool isPerform = false)
        {
            /*" -515- PERFORM 180-000-LER-TCONTSIN */

            M_180_000_LER_TCONTSIN_SECTION();

            /*" -516- IF WFIM-TCONTSIN EQUAL 'N' */

            if (W.WFIM_TCONTSIN == "N")
            {

                /*" -517- PERFORM 400-000-IMPRIME */

                M_400_000_IMPRIME_SECTION();

                /*" -520- GO TO 120-010-LOOP. */
                new Task(() => M_120_010_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -521- MOVE 70 TO WCONT-LIN. */
            _.Move(70, W.WCONT_LIN);

            /*" -523- MOVE 0 TO WCONT-PAG. */
            _.Move(0, W.WCONT_PAG);

            /*" -523- PERFORM 300-000-LER-TRELATO. */

            M_300_000_LER_TRELATO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-150-000-CURSOR-TCONTSIN-SECTION */
        private void M_150_000_CURSOR_TCONTSIN_SECTION()
        {
            /*" -537- MOVE '120' TO WNR-EXEC-SQL */
            _.Move("120", W.WABEND.WNR_EXEC_SQL);

            /*" -540- MOVE '120-000-CURSOR-TCONTSIN' TO PARAGRAFO. */
            _.Move("120-000-CURSOR-TCONTSIN", W.WABEND.PARAGRAFO);

            /*" -541- MOVE WT1 TO WTIMESTAMP-INI. */
            _.Move(WT.WT1, WTIMESTAMP_INI);

            /*" -543- MOVE WT2 TO WTIMESTAMP-FIM. */
            _.Move(WT.WT2, WTIMESTAMP_FIM);

            /*" -555- PERFORM M_150_000_CURSOR_TCONTSIN_DB_DECLARE_1 */

            M_150_000_CURSOR_TCONTSIN_DB_DECLARE_1();

            /*" -557- PERFORM M_150_000_CURSOR_TCONTSIN_DB_OPEN_1 */

            M_150_000_CURSOR_TCONTSIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-150-000-CURSOR-TCONTSIN-DB-OPEN-1 */
        public void M_150_000_CURSOR_TCONTSIN_DB_OPEN_1()
        {
            /*" -557- EXEC SQL OPEN V1CONTSINI END-EXEC. */

            V1CONTSINI.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-180-000-LER-TCONTSIN-SECTION */
        private void M_180_000_LER_TCONTSIN_SECTION()
        {
            /*" -574- MOVE '180' TO WNR-EXEC-SQL */
            _.Move("180", W.WABEND.WNR_EXEC_SQL);

            /*" -580- MOVE '180-000-LER-TCONTSIN' TO PARAGRAFO. */
            _.Move("180-000-LER-TCONTSIN", W.WABEND.PARAGRAFO);

            /*" -586- PERFORM M_180_000_LER_TCONTSIN_DB_FETCH_1 */

            M_180_000_LER_TCONTSIN_DB_FETCH_1();

            /*" -589- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -589- PERFORM M_180_000_LER_TCONTSIN_DB_CLOSE_1 */

                M_180_000_LER_TCONTSIN_DB_CLOSE_1();

                /*" -591- MOVE 'S' TO WFIM-TCONTSIN */
                _.Move("S", W.WFIM_TCONTSIN);

                /*" -592- ELSE */
            }
            else
            {


                /*" -592- ADD 1 TO WLIDOS. */
                W.WLIDOS.Value = W.WLIDOS + 1;
            }


        }

        [StopWatch]
        /*" M-180-000-LER-TCONTSIN-DB-FETCH-1 */
        public void M_180_000_LER_TCONTSIN_DB_FETCH_1()
        {
            /*" -586- EXEC SQL FETCH V1CONTSINI INTO :CONTSIN-FONTE, :CONTSIN-PROTSINI, :CONTSIN-DAC, :CONTSIN-APOLICE, :CONTSIN-TIMESTAMP END-EXEC. */

            if (V1CONTSINI.Fetch())
            {
                _.Move(V1CONTSINI.CONTSIN_FONTE, CONTSIN_FONTE);
                _.Move(V1CONTSINI.CONTSIN_PROTSINI, CONTSIN_PROTSINI);
                _.Move(V1CONTSINI.CONTSIN_DAC, CONTSIN_DAC);
                _.Move(V1CONTSINI.CONTSIN_APOLICE, CONTSIN_APOLICE);
                _.Move(V1CONTSINI.CONTSIN_TIMESTAMP, CONTSIN_TIMESTAMP);
            }

        }

        [StopWatch]
        /*" M-180-000-LER-TCONTSIN-DB-CLOSE-1 */
        public void M_180_000_LER_TCONTSIN_DB_CLOSE_1()
        {
            /*" -589- EXEC SQL CLOSE V1CONTSINI END-EXEC */

            V1CONTSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_180_999_EXIT*/

        [StopWatch]
        /*" M-240-000-ACESSA-TGEFONTE-SECTION */
        private void M_240_000_ACESSA_TGEFONTE_SECTION()
        {
            /*" -606- MOVE '240-000-ACESSA-TGEFONTE' TO PARAGRAFO. */
            _.Move("240-000-ACESSA-TGEFONTE", W.WABEND.PARAGRAFO);

            /*" -608- DISPLAY PARAGRAFO. */
            _.Display(W.WABEND.PARAGRAFO);

            /*" -610- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", W.WABEND.WNR_EXEC_SQL);

            /*" -613- MOVE CONTSIN-FONTE TO TGEFONTE-FONTE. */
            _.Move(CONTSIN_FONTE, TGEFONTE_FONTE);

            /*" -619- PERFORM M_240_000_ACESSA_TGEFONTE_DB_SELECT_1 */

            M_240_000_ACESSA_TGEFONTE_DB_SELECT_1();

            /*" -622- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -623- DISPLAY 'SI0120B - NAO CONSTA FONTE CADASTRADA' */
                _.Display($"SI0120B - NAO CONSTA FONTE CADASTRADA");

                /*" -624- DISPLAY 'FONTE = ' TGEFONTE-FONTE */
                _.Display($"FONTE = {TGEFONTE_FONTE}");

                /*" -626- MOVE SPACES TO TGEFONTE-NOMEFTE. */
                _.Move("", TGEFONTE_NOMEFTE);
            }


            /*" -627- MOVE TGEFONTE-FONTE TO LC05-FONTE */
            _.Move(TGEFONTE_FONTE, W.LC05.LC05_FONTE);

            /*" -627- MOVE TGEFONTE-NOMEFTE TO LC05-NOMEFTE. */
            _.Move(TGEFONTE_NOMEFTE, W.LC05.LC05_NOMEFTE);

        }

        [StopWatch]
        /*" M-240-000-ACESSA-TGEFONTE-DB-SELECT-1 */
        public void M_240_000_ACESSA_TGEFONTE_DB_SELECT_1()
        {
            /*" -619- EXEC SQL SELECT NOMEFTE INTO :TGEFONTE-NOMEFTE FROM SEGUROS.V1FONTE WHERE FONTE = :TGEFONTE-FONTE END-EXEC. */

            var m_240_000_ACESSA_TGEFONTE_DB_SELECT_1_Query1 = new M_240_000_ACESSA_TGEFONTE_DB_SELECT_1_Query1()
            {
                TGEFONTE_FONTE = TGEFONTE_FONTE.ToString(),
            };

            var executed_1 = M_240_000_ACESSA_TGEFONTE_DB_SELECT_1_Query1.Execute(m_240_000_ACESSA_TGEFONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TGEFONTE_NOMEFTE, TGEFONTE_NOMEFTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/

        [StopWatch]
        /*" M-270-000-LER-TAPOLICE-SECTION */
        private void M_270_000_LER_TAPOLICE_SECTION()
        {
            /*" -644- MOVE '270' TO WNR-EXEC-SQL */
            _.Move("270", W.WABEND.WNR_EXEC_SQL);

            /*" -650- MOVE '270-000-LER-TAPOLICE' TO PARAGRAFO. */
            _.Move("270-000-LER-TAPOLICE", W.WABEND.PARAGRAFO);

            /*" -655- PERFORM M_270_000_LER_TAPOLICE_DB_SELECT_1 */

            M_270_000_LER_TAPOLICE_DB_SELECT_1();

            /*" -658- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -659- DISPLAY 'SI0120B - NAO CONSTA REGISTRO NA TAPOLICE' */
                _.Display($"SI0120B - NAO CONSTA REGISTRO NA TAPOLICE");

                /*" -660- DISPLAY 'NUM-APOLICE = ' CONTSIN-APOLICE */
                _.Display($"NUM-APOLICE = {CONTSIN_APOLICE}");

                /*" -660- MOVE SPACES TO APOLICE-NOME. */
                _.Move("", APOLICE_NOME);
            }


        }

        [StopWatch]
        /*" M-270-000-LER-TAPOLICE-DB-SELECT-1 */
        public void M_270_000_LER_TAPOLICE_DB_SELECT_1()
        {
            /*" -655- EXEC SQL SELECT NOME INTO :APOLICE-NOME FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :CONTSIN-APOLICE END-EXEC. */

            var m_270_000_LER_TAPOLICE_DB_SELECT_1_Query1 = new M_270_000_LER_TAPOLICE_DB_SELECT_1_Query1()
            {
                CONTSIN_APOLICE = CONTSIN_APOLICE.ToString(),
            };

            var executed_1 = M_270_000_LER_TAPOLICE_DB_SELECT_1_Query1.Execute(m_270_000_LER_TAPOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICE_NOME, APOLICE_NOME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_270_999_EXIT*/

        [StopWatch]
        /*" M-300-000-LER-TRELATO-SECTION */
        private void M_300_000_LER_TRELATO_SECTION()
        {
            /*" -674- MOVE '300' TO WNR-EXEC-SQL */
            _.Move("300", W.WABEND.WNR_EXEC_SQL);

            /*" -680- MOVE '300-000-LER-TRELATO' TO PARAGRAFO. */
            _.Move("300-000-LER-TRELATO", W.WABEND.PARAGRAFO);

            /*" -684- PERFORM M_300_000_LER_TRELATO_DB_FETCH_1 */

            M_300_000_LER_TRELATO_DB_FETCH_1();

            /*" -687- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -687- PERFORM M_300_000_LER_TRELATO_DB_CLOSE_1 */

                M_300_000_LER_TRELATO_DB_CLOSE_1();

                /*" -689- MOVE 'S' TO WFIM-TRELATO */
                _.Move("S", W.WFIM_TRELATO);

                /*" -692- GO TO 300-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/ //GOTO
                return;
            }


            /*" -693- IF RELATO-FONTE EQUAL 0 */

            if (RELATO_FONTE == 0)
            {

                /*" -694- MOVE ZEROS TO WFONTE-INI */
                _.Move(0, WFONTE_INI);

                /*" -695- MOVE ALL '9' TO WFONTE-FIM */
                _.MoveAll("9", WFONTE_FIM);

                /*" -696- ELSE */
            }
            else
            {


                /*" -699- MOVE RELATO-FONTE TO WFONTE-INI WFONTE-FIM. */
                _.Move(RELATO_FONTE, WFONTE_INI, WFONTE_FIM);
            }


            /*" -700- MOVE RELATO-DTINIVIG TO WTIMESTAMP-INI-DATA */
            _.Move(RELATO_DTINIVIG, WT.WT1.WTIMESTAMP_INI_DATA);

            /*" -702- MOVE RELATO-DTTERVIG TO WTIMESTAMP-FIM-DATA. */
            _.Move(RELATO_DTTERVIG, WT.WT2.WTIMESTAMP_FIM_DATA);

            /*" -703- MOVE RELATO-DTINIVIG TO WDATA. */
            _.Move(RELATO_DTINIVIG, W.WDATA);

            /*" -704- MOVE WDATA-DD TO LC04B-DDI. */
            _.Move(W.FILLER_44.WDATA_DD, W.LC04B.LC04B_DATAI.LC04B_DDI);

            /*" -705- MOVE WDATA-MM TO LC04B-MMI. */
            _.Move(W.FILLER_44.WDATA_MM, W.LC04B.LC04B_DATAI.LC04B_MMI);

            /*" -706- MOVE WDATA-AA TO LC04B-AAI. */
            _.Move(W.FILLER_44.WDATA_AA, W.LC04B.LC04B_DATAI.LC04B_AAI);

            /*" -707- MOVE RELATO-DTTERVIG TO WDATA. */
            _.Move(RELATO_DTTERVIG, W.WDATA);

            /*" -708- MOVE WDATA-DD TO LC04B-DDT. */
            _.Move(W.FILLER_44.WDATA_DD, W.LC04B.LC04B_DATAT.LC04B_DDT);

            /*" -709- MOVE WDATA-MM TO LC04B-MMT. */
            _.Move(W.FILLER_44.WDATA_MM, W.LC04B.LC04B_DATAT.LC04B_MMT);

            /*" -711- MOVE WDATA-AA TO LC04B-AAT. */
            _.Move(W.FILLER_44.WDATA_AA, W.LC04B.LC04B_DATAT.LC04B_AAT);

            /*" -711- ADD 1 TO WLIDOS-REL. */
            W.WLIDOS_REL.Value = W.WLIDOS_REL + 1;

        }

        [StopWatch]
        /*" M-300-000-LER-TRELATO-DB-FETCH-1 */
        public void M_300_000_LER_TRELATO_DB_FETCH_1()
        {
            /*" -684- EXEC SQL FETCH V1RELATSINI INTO :RELATO-DTINIVIG, :RELATO-DTTERVIG, :RELATO-FONTE END-EXEC. */

            if (V1RELATSINI.Fetch())
            {
                _.Move(V1RELATSINI.RELATO_DTINIVIG, RELATO_DTINIVIG);
                _.Move(V1RELATSINI.RELATO_DTTERVIG, RELATO_DTTERVIG);
                _.Move(V1RELATSINI.RELATO_FONTE, RELATO_FONTE);
            }

        }

        [StopWatch]
        /*" M-300-000-LER-TRELATO-DB-CLOSE-1 */
        public void M_300_000_LER_TRELATO_DB_CLOSE_1()
        {
            /*" -687- EXEC SQL CLOSE V1RELATSINI END-EXEC */

            V1RELATSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-400-000-IMPRIME-SECTION */
        private void M_400_000_IMPRIME_SECTION()
        {
            /*" -726- MOVE '400-000-IMPRIME' TO PARAGRAFO. */
            _.Move("400-000-IMPRIME", W.WABEND.PARAGRAFO);

            /*" -727- IF CONTSIN-FONTE NOT = WFONTE-ANT */

            if (CONTSIN_FONTE != W.WFONTE_ANT)
            {

                /*" -728- PERFORM 240-000-ACESSA-TGEFONTE */

                M_240_000_ACESSA_TGEFONTE_SECTION();

                /*" -730- MOVE CONTSIN-FONTE TO WFONTE-ANT LC05-FONTE */
                _.Move(CONTSIN_FONTE, W.WFONTE_ANT, W.LC05.LC05_FONTE);

                /*" -732- MOVE 77 TO WCONT-LIN. */
                _.Move(77, W.WCONT_LIN);
            }


            /*" -733- IF WCONT-LIN GREATER 60 */

            if (W.WCONT_LIN > 60)
            {

                /*" -735- PERFORM 430-000-CABEC. */

                M_430_000_CABEC_SECTION();
            }


            /*" -735- PERFORM 460-000-DETALHE. */

            M_460_000_DETALHE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_999_EXIT*/

        [StopWatch]
        /*" M-430-000-CABEC-SECTION */
        private void M_430_000_CABEC_SECTION()
        {
            /*" -754- MOVE '390-000-CABEC' TO PARAGRAFO. */
            _.Move("390-000-CABEC", W.WABEND.PARAGRAFO);

            /*" -755- ADD 1 TO WCONT-PAG. */
            W.WCONT_PAG.Value = W.WCONT_PAG + 1;

            /*" -757- MOVE WCONT-PAG TO LC01-PAG. */
            _.Move(W.WCONT_PAG, W.LC01.LC01_PAG);

            /*" -760- WRITE REG-SI0120M1 FROM LC01 AFTER NEW-PAGE. */
            _.Move(W.LC01.GetMoveValues(), REG_SI0120M1);

            SI0120M1.Write(REG_SI0120M1.GetMoveValues().ToString());

            /*" -763- WRITE REG-SI0120M1 FROM LC02 AFTER 1. */
            _.Move(W.LC02.GetMoveValues(), REG_SI0120M1);

            SI0120M1.Write(REG_SI0120M1.GetMoveValues().ToString());

            /*" -768- WRITE REG-SI0120M1 FROM LC03 AFTER 1. */
            _.Move(W.LC03.GetMoveValues(), REG_SI0120M1);

            SI0120M1.Write(REG_SI0120M1.GetMoveValues().ToString());

            /*" -769- MOVE RELATO-DTINIVIG TO WDATA */
            _.Move(RELATO_DTINIVIG, W.WDATA);

            /*" -770- MOVE WDATA-DD TO LC04B-DDI */
            _.Move(W.FILLER_44.WDATA_DD, W.LC04B.LC04B_DATAI.LC04B_DDI);

            /*" -771- MOVE WDATA-MM TO LC04B-MMI */
            _.Move(W.FILLER_44.WDATA_MM, W.LC04B.LC04B_DATAI.LC04B_MMI);

            /*" -772- MOVE WDATA-AA TO LC04B-AAI */
            _.Move(W.FILLER_44.WDATA_AA, W.LC04B.LC04B_DATAI.LC04B_AAI);

            /*" -773- MOVE RELATO-DTTERVIG TO WDATA */
            _.Move(RELATO_DTTERVIG, W.WDATA);

            /*" -774- MOVE WDATA-DD TO LC04B-DDT */
            _.Move(W.FILLER_44.WDATA_DD, W.LC04B.LC04B_DATAT.LC04B_DDT);

            /*" -775- MOVE WDATA-MM TO LC04B-MMT */
            _.Move(W.FILLER_44.WDATA_MM, W.LC04B.LC04B_DATAT.LC04B_MMT);

            /*" -776- MOVE WDATA-AA TO LC04B-AAT */
            _.Move(W.FILLER_44.WDATA_AA, W.LC04B.LC04B_DATAT.LC04B_AAT);

            /*" -779- WRITE REG-SI0120M1 FROM LC04B AFTER 1 */
            _.Move(W.LC04B.GetMoveValues(), REG_SI0120M1);

            SI0120M1.Write(REG_SI0120M1.GetMoveValues().ToString());

            /*" -782- WRITE REG-SI0120M1 FROM LC05 AFTER 2. */
            _.Move(W.LC05.GetMoveValues(), REG_SI0120M1);

            SI0120M1.Write(REG_SI0120M1.GetMoveValues().ToString());

            /*" -785- WRITE REG-SI0120M1 FROM LC06 AFTER 2. */
            _.Move(W.LC06.GetMoveValues(), REG_SI0120M1);

            SI0120M1.Write(REG_SI0120M1.GetMoveValues().ToString());

            /*" -785- MOVE 8 TO WCONT-LIN. */
            _.Move(8, W.WCONT_LIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_430_999_EXIT*/

        [StopWatch]
        /*" M-460-000-DETALHE-SECTION */
        private void M_460_000_DETALHE_SECTION()
        {
            /*" -802- MOVE '460-000-DETALHE' TO PARAGRAFO. */
            _.Move("460-000-DETALHE", W.WABEND.PARAGRAFO);

            /*" -803- MOVE CONTSIN-PROTSINI TO LD01-PROTSINI. */
            _.Move(CONTSIN_PROTSINI, W.LD01.LD01_PROTOCOLO.LD01_PROTSINI);

            /*" -805- MOVE CONTSIN-DAC TO LD01-DAC. */
            _.Move(CONTSIN_DAC, W.LD01.LD01_PROTOCOLO.LD01_DAC);

            /*" -807- MOVE CONTSIN-APOLICE TO LD01-APOLICE. */
            _.Move(CONTSIN_APOLICE, W.LD01.LD01_APOLICE);

            /*" -808- PERFORM 270-000-LER-TAPOLICE. */

            M_270_000_LER_TAPOLICE_SECTION();

            /*" -810- MOVE APOLICE-NOME TO LD01-NOME. */
            _.Move(APOLICE_NOME, W.LD01.LD01_NOME);

            /*" -811- MOVE CONTSIN-TIMESTAMP TO WTIMESTAMP. */
            _.Move(CONTSIN_TIMESTAMP, W.WTIMESTAMP);

            /*" -812- MOVE WTIMESTAMP-DATA TO WDATA. */
            _.Move(W.WTIMESTAMP.WTIMESTAMP_DATA, W.WDATA);

            /*" -813- MOVE WDATA-AA TO LD01-AA */
            _.Move(W.FILLER_44.WDATA_AA, W.LD01.LD01_DATA.LD01_AA);

            /*" -814- MOVE WDATA-MM TO LD01-MM */
            _.Move(W.FILLER_44.WDATA_MM, W.LD01.LD01_DATA.LD01_MM);

            /*" -815- MOVE WDATA-DD TO LD01-DD */
            _.Move(W.FILLER_44.WDATA_DD, W.LD01.LD01_DATA.LD01_DD);

            /*" -816- MOVE WTIMESTAMP-HORA TO WAUX-HORA. */
            _.Move(W.WTIMESTAMP.WTIMESTAMP_HORA, W.WAUX_HORA);

            /*" -817- MOVE WAUX-HOR TO LD01-HOR. */
            _.Move(W.WAUX_HORA.WAUX_HOR, W.LD01.LD01_HORA.LD01_HOR);

            /*" -818- MOVE WAUX-MIN TO LD01-MIN. */
            _.Move(W.WAUX_HORA.WAUX_MIN, W.LD01.LD01_HORA.LD01_MIN);

            /*" -821- MOVE WAUX-SEG TO LD01-SEG. */
            _.Move(W.WAUX_HORA.WAUX_SEG, W.LD01.LD01_HORA.LD01_SEG);

            /*" -824- WRITE REG-SI0120M1 FROM LD01 AFTER 2. */
            _.Move(W.LD01.GetMoveValues(), REG_SI0120M1);

            SI0120M1.Write(REG_SI0120M1.GetMoveValues().ToString());

            /*" -826- ADD 2 TO WCONT-LIN. */
            W.WCONT_LIN.Value = W.WCONT_LIN + 2;

            /*" -826- ADD 1 TO WIMPRES. */
            W.WIMPRES.Value = W.WIMPRES + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_460_999_EXIT*/

        [StopWatch]
        /*" M-600-000-ATUALIZA-TRELATO-SECTION */
        private void M_600_000_ATUALIZA_TRELATO_SECTION()
        {
            /*" -844- MOVE '600' TO WNR-EXEC-SQL */
            _.Move("600", W.WABEND.WNR_EXEC_SQL);

            /*" -850- MOVE '600-000-ATUALIZA-TRELATO' TO PARAGRAFO. */
            _.Move("600-000-ATUALIZA-TRELATO", W.WABEND.PARAGRAFO);

            /*" -856- PERFORM M_600_000_ATUALIZA_TRELATO_DB_DELETE_1 */

            M_600_000_ATUALIZA_TRELATO_DB_DELETE_1();

        }

        [StopWatch]
        /*" M-600-000-ATUALIZA-TRELATO-DB-DELETE-1 */
        public void M_600_000_ATUALIZA_TRELATO_DB_DELETE_1()
        {
            /*" -856- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0120B' AND DATA_SOLICITACAO = :SISTEMA-DTMOVABE END-EXEC. */

            var m_600_000_ATUALIZA_TRELATO_DB_DELETE_1_Delete1 = new M_600_000_ATUALIZA_TRELATO_DB_DELETE_1_Delete1()
            {
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            M_600_000_ATUALIZA_TRELATO_DB_DELETE_1_Delete1.Execute(m_600_000_ATUALIZA_TRELATO_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -876- MOVE '900-000-FINALIZA' TO PARAGRAFO. */
            _.Move("900-000-FINALIZA", W.WABEND.PARAGRAFO);

            /*" -879- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", W.WABEND.WNR_EXEC_SQL);

            /*" -881- CLOSE SI0120M1. */
            SI0120M1.Close();

            /*" -882- DISPLAY 'TOTAL LIDOS        = ' WLIDOS */
            _.Display($"TOTAL LIDOS        = {W.WLIDOS}");

            /*" -883- DISPLAY 'TOTAL LIDOS RELAT. = ' WLIDOS-REL. */
            _.Display($"TOTAL LIDOS RELAT. = {W.WLIDOS_REL}");

            /*" -886- DISPLAY 'TOTAL IMPRESSOS    = ' WIMPRES. */
            _.Display($"TOTAL IMPRESSOS    = {W.WIMPRES}");

            /*" -887- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -887- DISPLAY 'SI0120B        *** FIM NORMAL ***' . */
            _.Display($"SI0120B        *** FIM NORMAL ***");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -900- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -901- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -902- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W.WABEND.WSQLCODE1);

                /*" -903- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W.WABEND.WSQLCODE2);

                /*" -904- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, W.WSQLCODE3);
            }


            /*" -906- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -907- CLOSE SI0120M1. */
            SI0120M1.Close();

            /*" -907- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -908- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -910- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -910- GOBACK. */

            throw new GoBack();

        }
    }
}